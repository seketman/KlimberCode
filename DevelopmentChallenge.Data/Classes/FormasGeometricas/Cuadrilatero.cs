namespace DevelopmentChallenge.Data.Classes
{
    public abstract class Cuadrilatero: FormaGeometrica
    {
        private readonly decimal _ladoA;
        private readonly decimal _ladoB;
        private readonly decimal _ladoC;
        private readonly decimal _ladoD;

        public Cuadrilatero(decimal ladoA, decimal ladoB, decimal ladoC, decimal ladoD)
        {
            _ladoA = ladoA;
            _ladoB = ladoB;
            _ladoC = ladoC;
            _ladoD = ladoD;
        }

        public override decimal CalcularPerimetro()
        {
            return _ladoA + _ladoB + _ladoC + _ladoD;
        }
    }
}
