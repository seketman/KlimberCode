using System.Globalization;
using System.Resources;

namespace DevelopmentChallenge.Data.Classes
{
    public abstract class FormaGeometrica : IFormaGeometrica
    {
        public abstract decimal CalcularArea();
        public abstract decimal CalcularPerimetro();
        public abstract string TraducirForma(int cantidad, ResourceManager resManager, CultureInfo cultura);
    }
}
