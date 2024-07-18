using System.Globalization;
using System.Resources;
using System;

namespace DevelopmentChallenge.Data.Classes
{
    public class TrianguloEquilatero : FormaGeometrica
    {
        private readonly decimal _lado;

        public TrianguloEquilatero(decimal lado)
        {
            _lado = lado;
        }

        public override decimal CalcularArea()
        {
            return ((decimal)Math.Sqrt(3) / 4) * _lado * _lado;
        }

        public override decimal CalcularPerimetro()
        {
            return _lado * 3;
        }

        public override string TraducirForma(int cantidad, ResourceManager resManager, CultureInfo cultura)
        {
            return cantidad == 1 ? resManager.GetString("TriangleSingular", cultura) : resManager.GetString("TrianglePlural", cultura);
        }
    }
}
