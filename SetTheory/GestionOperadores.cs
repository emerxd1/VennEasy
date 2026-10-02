namespace Main
{
    public enum Operacion
    {
        Ninguna,
        Union,
        Interseccion,
        DiferenciaAB,
        DiferenciaBA,
        DiferenciaSimetrica
    }

    public class GestionOperadores
    {
        public Operacion Actual { get; private set; } = Operacion.Ninguna;

        public void OperadorUnion() => Actual = Operacion.Union;
        public void OperadorInterseccion() => Actual = Operacion.Interseccion;
        public void OperadorDiferenciaAB() => Actual = Operacion.DiferenciaAB;
        public void OperadorDiferenciaBA() => Actual = Operacion.DiferenciaBA;
        public void OperadorDiferenciaSimetrica() => Actual = Operacion.DiferenciaSimetrica;
        public void Limpiar() => Actual = Operacion.Ninguna;
    }
}