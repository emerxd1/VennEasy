namespace Main
{
    // Punto 2D en las coordenadas del gráfico.
    internal readonly record struct Punto(double X, double Y);

    // Rectángulo definido por sus cuatro bordes.
    internal readonly record struct Caja(double Izquierda, double Derecha, double Abajo, double Arriba);

    // Cálculos geométricos del diagrama. No dibuja nada ni conoce a ScottPlot.
    internal static class GeometriaVenn
    {
        public const double Radio = 1.0;

        private const double MitadSeparacionDosCirculos = 0.55;
        private const double RadioAnillo = 0.7;          // 3 o más círculos: distancia al origen
        private const double MargenLateral = 0.9;        // espacio entre círculos y cuadro (izq. y der.)
        private const double MargenInferior = 0.7;
        private const double MargenSuperior = 0.9;
        private const double MargenBorde = 0.15;         // margen para no pegar elementos al borde de un círculo

        // Centro de cada círculo
        public static List<Punto> CalcularCentros(int cantidad)
        {
            if (cantidad == 1)
                return new List<Punto> { new Punto(0, 0) };

            if (cantidad == 2)
                return new List<Punto>
                {
                    new Punto(-MitadSeparacionDosCirculos, 0),
                    new Punto(MitadSeparacionDosCirculos, 0)
                };

            // 3 o más: en anillo, uno por vértice de un polígono
            var centros = new List<Punto>();
            for (int i = 0; i < cantidad; i++)
            {
                double angulo = Math.PI / 2 + i * 2 * Math.PI / cantidad;
                centros.Add(new Punto(RadioAnillo * Math.Cos(angulo), RadioAnillo * Math.Sin(angulo)));
            }
            return centros;
        }

        // Cuadro que rodea a todos los círculos, con margen para nombres y elementos
        public static Caja CalcularCaja(IReadOnlyList<Punto> centros)
        {
            return new Caja(
                Izquierda: centros.Min(c => c.X) - Radio - MargenLateral,
                Derecha: centros.Max(c => c.X) + Radio + MargenLateral,
                Abajo: centros.Min(c => c.Y) - Radio - MargenInferior,
                Arriba: centros.Max(c => c.Y) + Radio + MargenSuperior);
        }

        // Vector de longitud 1 desde el origen hacia un punto ("hacia afuera")
        public static Punto Direccion(Punto p)
        {
            double largo = Math.Sqrt(p.X * p.X + p.Y * p.Y);
            return largo == 0 ? new Punto(0, 0) : new Punto(p.X / largo, p.Y / largo);
        }

        public static double Distancia(Punto a, Punto b)
        {
            return Math.Sqrt((a.X - b.X) * (a.X - b.X) + (a.Y - b.Y) * (a.Y - b.Y));
        }

        // Máscara: bit 0 = A, bit 1 = B, bit 2 = C... (A y B = 3). Máscara 0 = solo universo.
        public static bool PerteneceAlConjunto(int mascara, int indiceConjunto)
        {
            return (mascara & (1 << indiceConjunto)) != 0;
        }

        // Centros de los círculos que forman la región indicada por la máscara
        public static List<Punto> CentrosDeRegion(int mascara, IReadOnlyList<Punto> centros)
        {
            return centros.Where((c, i) => PerteneceAlConjunto(mascara, i)).ToList();
        }

        // ¿El punto está dentro de los círculos de la región y fuera de los demás?
        public static bool EstaEnRegion(Punto punto, int mascara, IReadOnlyList<Punto> centros)
        {
            for (int i = 0; i < centros.Count; i++)
            {
                double distancia = Distancia(punto, centros[i]);

                if (PerteneceAlConjunto(mascara, i))
                {
                    if (distancia > Radio - MargenBorde) return false;
                }
                else
                {
                    if (distancia < Radio + MargenBorde) return false;
                }
            }
            return true;
        }
    }
}
