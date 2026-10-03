using ScottPlot;
namespace Main
{
    // Dibuja el diagrama de Venn sobre un Plot. Solo recibe datos y dibuja.
    public class DiagramaVenn
    {
        private const double Radio = GeometriaVenn.Radio;

        private const int SemillaPosiciones = 7;          // semilla fija: el diagrama no "salta" en cada clic
        private const int PasosPorArco = 60;
        private const double DistanciaNombre = 0.3;       // separación entre el círculo y su nombre

        private const double AlfaUniverso = 0.15;
        private const double AlfaCirculo = 0.35;
        private const double AlfaResaltado = 0.75;
        private const double MargenVista = 0.2;

        // ---------------------------------------------------------------
        // DIBUJAR
        // ---------------------------------------------------------------
        // NUEVO: parámetro "personalizada"
        public void Dibujar(Plot plt, List<Conjunto> conjuntos, Conjunto universo,
                            Operacion op = Operacion.Ninguna, Func<int, bool> personalizada = null)
        {
            plt.Clear();

            var centros = GeometriaVenn.CalcularCentros(conjuntos.Count);
            var caja = GeometriaVenn.CalcularCaja(centros);

            // El orden importa: lo primero que se dibuja queda detrás
            DibujarUniverso(plt, universo, caja);
            ResaltarOperacion(plt, centros, op);
            ResaltarPersonalizada(plt, centros, caja, personalizada);   // NUEVO
            DibujarConjuntos(plt, conjuntos, centros);
            DibujarElementos(plt, conjuntos, universo, centros, caja);
            AjustarVista(plt, caja);
        }

        // Cuadro del universo con su título "U"
        private static void DibujarUniverso(Plot plt, Conjunto universo, Caja caja)
        {
            var colorU = ScottPlot.Color.FromColor(universo.Color);

            var cuadro = plt.Add.Rectangle(caja.Izquierda, caja.Derecha, caja.Abajo, caja.Arriba);
            cuadro.FillColor = colorU.WithAlpha(AlfaUniverso);
            cuadro.LineColor = colorU;
            cuadro.LineWidth = 3;

            var titulo = plt.Add.Text("U", caja.Izquierda + 0.15, caja.Arriba - 0.1);
            titulo.LabelFontSize = 20;
            titulo.LabelBold = true;
            titulo.Alignment = Alignment.UpperLeft;
        }

        // Un círculo y un nombre por conjunto
        private static void DibujarConjuntos(Plot plt, List<Conjunto> conjuntos, IReadOnlyList<Punto> centros)
        {
            for (int i = 0; i < conjuntos.Count; i++)
            {
                var color = ScottPlot.Color.FromColor(conjuntos[i].Color);

                var circulo = plt.Add.Circle(centros[i].X, centros[i].Y, Radio);
                circulo.FillColor = color.WithAlpha(AlfaCirculo);
                circulo.LineColor = color;
                circulo.LineWidth = 2;

                Punto posicion = PosicionNombre(conjuntos.Count, centros[i]);
                var nombre = plt.Add.Text(conjuntos[i].Nombre, posicion.X, posicion.Y);
                nombre.LabelFontSize = 18;
                nombre.LabelBold = true;
                nombre.Alignment = Alignment.MiddleCenter;
            }
        }

        // Con 2 conjuntos el nombre va arriba; con más, hacia afuera del diagrama
        private static Punto PosicionNombre(int totalConjuntos, Punto centro)
        {
            if (totalConjuntos == 2)
                return new Punto(centro.X, Radio + DistanciaNombre);

            Punto direccion = GeometriaVenn.Direccion(centro);
            return new Punto(
                centro.X + direccion.X * (Radio + DistanciaNombre),
                centro.Y + direccion.Y * (Radio + DistanciaNombre));
        }

        // Cada elemento en su propia etiqueta, en un punto aleatorio de su región
        private static void DibujarElementos(Plot plt, List<Conjunto> conjuntos, Conjunto universo,
                                             IReadOnlyList<Punto> centros, Caja caja)
        {
            var rnd = new Random(SemillaPosiciones);

            foreach (var region in DistribucionElementos.AgruparPorRegion(conjuntos, universo))
            {
                int mascara = region.Key;          // 0 = solo en el universo
                var elementos = region.Value;

                float tamano = DistribucionElementos.TamanoFuente(elementos.Count);
                var puntos = DistribucionElementos.PuntosEnRegion(mascara, centros, elementos.Count, rnd, caja);

                for (int k = 0; k < elementos.Count; k++)
                {
                    var etiqueta = plt.Add.Text(elementos[k], puntos[k].X, puntos[k].Y);
                    etiqueta.LabelFontSize = tamano;
                    etiqueta.Alignment = Alignment.MiddleCenter;
                }
            }
        }

        // Vista ajustada al cuadro, sin ejes ni cuadrícula
        private static void AjustarVista(Plot plt, Caja caja)
        {
            plt.Axes.SetLimits(
                caja.Izquierda - MargenVista, caja.Derecha + MargenVista,
                caja.Abajo - MargenVista, caja.Arriba + MargenVista);
            plt.Axes.SquareUnits();
            plt.HideAxesAndGrid();
        }

        // ---------------------------------------------------------------
        // RESALTADO DE OPERACIONES (siempre entre el conjunto 0 = A y el 1 = B)
        // ---------------------------------------------------------------
        private static void ResaltarOperacion(Plot plt, IReadOnlyList<Punto> centros, Operacion op)
        {
            if (op == Operacion.Ninguna || centros.Count < 2) return;

            var par = new ParDeCirculos(centros[0], centros[1]);
            var color = ScottPlot.Colors.Gold.WithAlpha(AlfaResaltado);

            foreach (var poligono in PoligonosDeOperacion(op, par))
                Rellenar(plt, poligono, color);
        }

        private static IEnumerable<Coordinates[]> PoligonosDeOperacion(Operacion op, ParDeCirculos par)
        {
            switch (op)
            {
                case Operacion.Union: return new[] { par.Union() };
                case Operacion.Interseccion: return new[] { par.Interseccion() };
                case Operacion.DiferenciaAB: return new[] { par.SoloA() };
                case Operacion.DiferenciaBA: return new[] { par.SoloB() };
                case Operacion.DiferenciaSimetrica: return new[] { par.SoloA(), par.SoloB() };
                default: return Array.Empty<Coordinates[]>();
            }
        }

        // ---------------------------------------------------------------
        // NUEVO: RESALTADO DE OPERACIÓN PERSONALIZADA
        // Recorre el cuadro en franjas y pinta las zonas cuya región (máscara)
        // pertenece al resultado.
        // ---------------------------------------------------------------
        private static void ResaltarPersonalizada(Plot plt, IReadOnlyList<Punto> centros, Caja caja,
                                                  Func<int, bool> incluye)
        {
            if (incluye == null) return;

            const double paso = 0.03;
            var color = ScottPlot.Colors.Gold.WithAlpha(AlfaResaltado);
            int filas = (int)Math.Ceiling((caja.Arriba - caja.Abajo) / paso);
            int columnas = (int)Math.Ceiling((caja.Derecha - caja.Izquierda) / paso);

            for (int f = 0; f < filas; f++)
            {
                double y0 = caja.Abajo + f * paso;
                double yCentro = y0 + paso / 2;
                int inicio = -1;

                for (int c = 0; c <= columnas; c++)
                {
                    bool dentro = false;
                    if (c < columnas)
                    {
                        var p = new Punto(caja.Izquierda + (c + 0.5) * paso, yCentro);
                        dentro = incluye(MascaraDe(p, centros));
                    }

                    if (dentro && inicio < 0) inicio = c;
                    else if (!dentro && inicio >= 0)
                    {
                        var rect = plt.Add.Rectangle(
                            caja.Izquierda + inicio * paso, caja.Izquierda + c * paso, y0, y0 + paso);
                        rect.FillColor = color;
                        rect.LineWidth = 0;
                        inicio = -1;
                    }
                }
            }
        }

        // NUEVO: en qué círculos está un punto (bit i = dentro del círculo i)
        private static int MascaraDe(Punto p, IReadOnlyList<Punto> centros)
        {
            int mascara = 0;
            for (int i = 0; i < centros.Count; i++)
                if (GeometriaVenn.Distancia(p, centros[i]) <= Radio) mascara |= 1 << i;
            return mascara;
        }

        // Puntos sobre un círculo de radio Radio, de un ángulo a otro (puede ir en ambos sentidos)
        private static Coordinates[] Arco(Punto centro, double desde, double hasta)
        {
            var puntos = new Coordinates[PasosPorArco + 1];
            for (int i = 0; i <= PasosPorArco; i++)
            {
                double angulo = desde + (hasta - desde) * i / PasosPorArco;
                puntos[i] = new Coordinates(
                    centro.X + Radio * Math.Cos(angulo),
                    centro.Y + Radio * Math.Sin(angulo));
            }
            return puntos;
        }

        private static void Rellenar(Plot plt, Coordinates[] puntos, ScottPlot.Color color)
        {
            var poligono = plt.Add.Polygon(puntos);
            poligono.FillColor = color;
            poligono.LineWidth = 0;
        }

        // Las zonas de dos círculos que se cortan, formadas por arcos de uno y de otro
        private readonly struct ParDeCirculos
        {
            private readonly Punto a;
            private readonly Punto b;
            private readonly double direccion;   // ángulo de A hacia B
            private readonly double corte;       // ángulo de los puntos de corte

            public ParDeCirculos(Punto a, Punto b)
            {
                this.a = a;
                this.b = b;

                double dx = b.X - a.X, dy = b.Y - a.Y;
                double distancia = Math.Sqrt(dx * dx + dy * dy);
                direccion = Math.Atan2(dy, dx);
                corte = Math.Acos(Math.Min(1.0, distancia / (2 * Radio)));
            }

            public Coordinates[] Interseccion() =>
                Arco(a, direccion - corte, direccion + corte)
                    .Concat(Arco(b, direccion + Math.PI - corte, direccion + Math.PI + corte)).ToArray();

            public Coordinates[] SoloA() =>
                Arco(a, direccion + corte, direccion + 2 * Math.PI - corte)
                    .Concat(Arco(b, direccion + Math.PI + corte, direccion + Math.PI - corte)).ToArray();

            public Coordinates[] SoloB() =>
                Arco(b, direccion - Math.PI + corte, direccion + Math.PI - corte)
                    .Concat(Arco(a, direccion + corte, direccion - corte)).ToArray();

            public Coordinates[] Union() =>
                Arco(a, direccion + corte, direccion + 2 * Math.PI - corte)
                    .Concat(Arco(b, direccion - Math.PI + corte, direccion + Math.PI - corte)).ToArray();
        }
    }
}