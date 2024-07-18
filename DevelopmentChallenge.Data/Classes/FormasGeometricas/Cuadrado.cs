using System.Globalization;
using System.Resources;

namespace DevelopmentChallenge.Data.Classes
{
    public class Cuadrado : Cuadrilatero
    {
        private readonly decimal _lado;

        public Cuadrado(decimal lado) : base(lado, lado, lado, lado)
        {
            _lado = lado;
        }

        public override decimal CalcularArea()
        {
            return _lado * _lado;
        }

        public override string TraducirForma(int cantidad, ResourceManager resManager, CultureInfo cultura)
        {
            return cantidad == 1 ? resManager.GetString("SquareSingular", cultura) : resManager.GetString("SquarePlural", cultura);
        }
    }
}
