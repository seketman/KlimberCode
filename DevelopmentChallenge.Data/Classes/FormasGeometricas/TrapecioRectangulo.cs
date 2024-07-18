using System.Globalization;
using System.Resources;
using System;

namespace DevelopmentChallenge.Data.Classes
{
    public class TrapecioRectangulo : Cuadrilatero
    {
        private readonly decimal _baseMayor;
        private readonly decimal _baseMenor;
        private readonly decimal _altura;

        public TrapecioRectangulo(decimal baseMayor, decimal baseMenor, decimal altura)
            : base(baseMayor, baseMenor, altura, (decimal)Math.Sqrt((double)(altura * altura + (baseMayor - baseMenor) * (baseMayor - baseMenor))))
        {
            _baseMayor = baseMayor;
            _baseMenor = baseMenor;
            _altura = altura;
        }

        public override decimal CalcularArea()
        {
            return ((_baseMayor + _baseMenor) / 2) * _altura;
        }

        public override string TraducirForma(int cantidad, ResourceManager resManager, CultureInfo cultura)
        {
            return cantidad == 1 ? resManager.GetString("RightTrapezoidSingular", cultura) : resManager.GetString("RightTrapezoidPlural", cultura);
        }
    }
}
