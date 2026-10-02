namespace Main
{
    // Decide en qué región cae cada elemento y en qué punto concreto se coloca.
    internal static class DistribucionElementos
    {
        private const double DistanciaMinimaInicial = 0.45;
        private const double FactorAcercamiento = 0.85;   // si no cabe, los textos se acercan
        private const int RondasMaximas = 12;
        private const int IntentosPorRonda = 100;
        private const double MargenCajaUniverso = 0.2;
        private const double MargenSuperiorLibre = 0.5;   // deja libre la "U"
        private const double MargenRespaldoUniverso = 0.3;
        private const double DesplazamientoRespaldo = 0.45;

        // Clasifica cada elemento según en qué conjuntos está.
        public static Dictionary<int, List<string>> AgruparPorRegion(List<Conjunto> conjuntos, Conjunto universo)
        {
            var regiones = new Dictionary<int, List<string>>();
            var todos = conjuntos.SelectMany(c => c.Elementos)
                                 .Concat(universo.Elementos)
                                 .Distinct();

            foreach (string elemento in todos)
            {
                int mascara = 0;
                for (int i = 0; i < conjuntos.Count; i++)
                    if (conjuntos[i].Elementos.Contains(elemento)) mascara |= 1 << i;

                if (!regiones.ContainsKey(mascara)) regiones[mascara] = new List<string>();
                regiones[mascara].Add(elemento);
            }
            return regiones;
        }

        // Más elementos en una región, texto más pequeño
        public static float TamanoFuente(int cantidadElementos)
        {
            return cantidadElementos > 25 ? 10 : cantidadElementos > 12 ? 12 : 16;
        }

        // Genera "cantidad" puntos aleatorios dentro de una región, separados entre sí.
        // Usa solo bucles "for" con tope, así que siempre termina.
        public static List<Punto> PuntosEnRegion(
            int mascara, IReadOnlyList<Punto> centros, int cantidad, Random rnd, Caja caja)
        {
            var puntos = new List<Punto>();
            Caja zonaBusqueda = ZonaDeBusqueda(mascara, centros, caja);
            Punto respaldo = PuntoDeRespaldo(mascara, centros, caja);
            double distanciaMin = DistanciaMinimaInicial;

            for (int k = 0; k < cantidad; k++)
            {
                Punto? colocado = IntentarColocar(puntos, mascara, centros, zonaBusqueda, rnd, ref distanciaMin);
                puntos.Add(colocado ?? respaldo);
            }
            return puntos;
        }

        // Caja donde buscar puntos candidatos
        private static Caja ZonaDeBusqueda(int mascara, IReadOnlyList<Punto> centros, Caja caja)
        {
            if (mascara == 0)
            {
                return new Caja(
                    Izquierda: caja.Izquierda + MargenCajaUniverso,
                    Derecha: caja.Derecha - MargenCajaUniverso,
                    Abajo: caja.Abajo + MargenCajaUniverso,
                    Arriba: caja.Arriba - MargenSuperiorLibre);
            }

            var miembros = GeometriaVenn.CentrosDeRegion(mascara, centros);
            return new Caja(
                Izquierda: miembros.Max(c => c.X - GeometriaVenn.Radio),
                Derecha: miembros.Min(c => c.X + GeometriaVenn.Radio),
                Abajo: miembros.Max(c => c.Y - GeometriaVenn.Radio),
                Arriba: miembros.Min(c => c.Y + GeometriaVenn.Radio));
        }

        // Punto que se usa si la región es imposible de llenar
        private static Punto PuntoDeRespaldo(int mascara, IReadOnlyList<Punto> centros, Caja caja)
        {
            if (mascara == 0)
                return new Punto(caja.Izquierda + MargenRespaldoUniverso, caja.Abajo + MargenRespaldoUniverso);

            var miembros = GeometriaVenn.CentrosDeRegion(mascara, centros);
            double x = miembros.Average(c => c.X);
            double y = miembros.Average(c => c.Y);

            if (miembros.Count == 1)
            {
                Punto direccion = GeometriaVenn.Direccion(miembros[0]);
                x += direccion.X * DesplazamientoRespaldo;
                y += direccion.Y * DesplazamientoRespaldo;
            }
            return new Punto(x, y);
        }

        // Busca un lugar para un elemento. Si en una ronda no cabe, acerca los textos y reintenta.
        // distanciaMin se pasa por referencia porque el acercamiento se mantiene para los siguientes elementos.
        private static Punto? IntentarColocar(
            List<Punto> yaColocados, int mascara, IReadOnlyList<Punto> centros,
            Caja zona, Random rnd, ref double distanciaMin)
        {
            for (int ronda = 0; ronda < RondasMaximas; ronda++)
            {
                Punto? punto = IntentarEnRonda(yaColocados, mascara, centros, zona, rnd, distanciaMin);
                if (punto != null) return punto;

                distanciaMin *= FactorAcercamiento;
            }
            return null;
        }

        private static Punto? IntentarEnRonda(
            List<Punto> yaColocados, int mascara, IReadOnlyList<Punto> centros,
            Caja zona, Random rnd, double distanciaMin)
        {
            for (int intento = 0; intento < IntentosPorRonda; intento++)
            {
                double x = zona.Izquierda + rnd.NextDouble() * (zona.Derecha - zona.Izquierda);
                double y = zona.Abajo + rnd.NextDouble() * (zona.Arriba - zona.Abajo);
                var candidato = new Punto(x, y);

                if (!GeometriaVenn.EstaEnRegion(candidato, mascara, centros)) continue;
                if (!yaColocados.All(p => GeometriaVenn.Distancia(p, candidato) >= distanciaMin)) continue;

                return candidato;
            }
            return null;
        }
    }
}
