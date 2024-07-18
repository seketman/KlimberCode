using System.Globalization;
using System.Resources;

namespace DevelopmentChallenge.Data.Classes
{
    public interface IFormaGeometrica
    {
        decimal CalcularArea();
        decimal CalcularPerimetro();
        string TraducirForma(int cantidad, ResourceManager resManager, CultureInfo cultura);
    }
}