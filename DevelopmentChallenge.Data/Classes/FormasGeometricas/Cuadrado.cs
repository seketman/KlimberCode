using System.Globalization;
using System.Resources;

namespace DevelopmentChallenge.Data.Classes
{
    public class Cuadrado : FormaGeometrica
    {
        private readonly decimal _lado;

        public Cuadrado(decimal lado)
        {
            _lado = lado;
        }

        public override decimal CalcularArea()
        {
            return _lado * _lado;
        }

        public override decimal CalcularPerimetro()
        {
            return _lado * 4;
        }

        public override string TraducirForma(int cantidad, ResourceManager resManager, CultureInfo cultura)
        {
            return cantidad == 1 ? resManager.GetString("SquareSingular", cultura) : resManager.GetString("SquarePlural", cultura);
        }
    }
}
