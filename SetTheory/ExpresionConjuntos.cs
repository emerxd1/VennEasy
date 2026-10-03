using System;

namespace Main
{
    // Convierte un texto como "AuB∩C" en una función: dada una región (máscara de bits
    // donde el bit i = "está en el conjunto i"), dice si pertenece al resultado.
    public static class ExpresionConjuntos
    {
        public static bool TryParse(string texto, int cantidadConjuntos,
                                    out Func<int, bool> predicado, out string error)
        {
            predicado = null;
            error = null;
            try
            {
                predicado = new Analizador(texto, cantidadConjuntos).Analizar();
                return true;
            }
            catch (FormatException ex)
            {
                error = ex.Message;
                return false;
            }
        }

        private sealed class Analizador
        {
            private readonly string t;
            private readonly int n;
            private int pos;

            public Analizador(string texto, int cantidad) { t = texto; n = cantidad; }

            // Símbolos aceptados
            private static bool EsUnion(char c) => c == '\u222A' || c == 'u' || c == 'U' || c == '|' || c == '+';
            private static bool EsInterseccion(char c) => c == '\u2229' || c == 'n' || c == 'N' || c == '&' || c == '*';
            private static bool EsResta(char c) => c == '-' || c == '\u2212' || c == '\u2013' || c == '\u2014' || c == '\\';
            private static bool EsSimetrica(char c) => c == '\u25B3' || c == '\u0394' || c == '\u2206' || c == '^';
            private static bool EsNegacionPrefija(char c) => c == '!' || c == '\u00AC' || c == '~';
            private static bool EsNegacionPosfija(char c) => c == '\'' || c == '\u2019';

            private char? Mirar()
            {
                while (pos < t.Length && char.IsWhiteSpace(t[pos])) pos++;
                return pos < t.Length ? t[pos] : (char?)null;
            }

            public Func<int, bool> Analizar()
            {
                var f = Expresion();
                if (Mirar() != null)
                    throw new FormatException($"Símbolo inesperado '{t[pos]}' en la posición {pos + 1}.");
                return f;
            }

            // ∪, − y △ tienen la misma prioridad (de izquierda a derecha)
            private Func<int, bool> Expresion()
            {
                var izq = Termino();
                while (true)
                {
                    char? c = Mirar();
                    if (c == null) break;

                    var l = izq;
                    if (EsUnion(c.Value)) { pos++; var r = Termino(); izq = m => l(m) || r(m); }
                    else if (EsResta(c.Value)) { pos++; var r = Termino(); izq = m => l(m) && !r(m); }
                    else if (EsSimetrica(c.Value)) { pos++; var r = Termino(); izq = m => l(m) != r(m); }
                    else break;
                }
                return izq;
            }

            // ∩ tiene más prioridad que ∪, − y △
            private Func<int, bool> Termino()
            {
                var izq = Factor();
                while (true)
                {
                    char? c = Mirar();
                    if (c == null || !EsInterseccion(c.Value)) break;

                    pos++;
                    var l = izq;
                    var r = Factor();
                    izq = m => l(m) && r(m);
                }
                return izq;
            }

            // Complemento: !A  o  A'
            private Func<int, bool> Factor()
            {
                char? c = Mirar();
                if (c != null && EsNegacionPrefija(c.Value))
                {
                    pos++;
                    var f = Factor();
                    return m => !f(m);
                }

                var p = Primario();
                while (Mirar() is char s && EsNegacionPosfija(s))
                {
                    pos++;
                    var q = p;
                    p = m => !q(m);
                }
                return p;
            }

            private Func<int, bool> Primario()
            {
                char? c = Mirar();
                if (c == null) throw new FormatException("La expresión está incompleta.");

                if (c == '(')
                {
                    pos++;
                    var f = Expresion();
                    if (Mirar() != ')') throw new FormatException("Falta cerrar un paréntesis.");
                    pos++;
                    return f;
                }

                char letra = char.ToUpper(c.Value);
                if (letra >= 'A' && letra <= 'D')
                {
                    int indice = letra - 'A';
                    if (indice >= n)
                        throw new FormatException($"El Conjunto {letra} no existe (solo hay {n} conjuntos).");
                    pos++;
                    return m => ((m >> indice) & 1) == 1;
                }

                throw new FormatException($"Símbolo no válido '{c}' en la posición {pos + 1}.");
            }
        }
    }
}