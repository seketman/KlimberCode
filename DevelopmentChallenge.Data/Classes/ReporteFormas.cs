using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Resources;
using System.Text;

namespace DevelopmentChallenge.Data.Classes
{
    public static class ReporteFormas
    {
        public static string Imprimir(List<FormaGeometrica> formas, ResourceManager resManager, CultureInfo cultura)
        {
            var sb = new StringBuilder();

            if (!formas.Any())
            {
                sb.Append($"<h1>{resManager.GetString("EmptyList", cultura)}</h1>");
            }
            else
            {
                sb.Append($"<h1>{resManager.GetString("ShapesReport", cultura)}</h1>");

                var resumen = formas
                    .GroupBy(f => f.GetType())
                    .Select(g => new
                    {
                        Tipo = g.First(),
                        Cantidad = g.Count(),
                        Area = g.Sum(f => f.CalcularArea()),
                        Perimetro = g.Sum(f => f.CalcularPerimetro())
                    })
                    .ToList();

                foreach (var item in resumen)
                {
                    sb.Append($"{item.Cantidad} {item.Tipo.TraducirForma(item.Cantidad, resManager, cultura)} | ");
                    sb.Append($"{resManager.GetString("Area", cultura)} {item.Area:#.##} | ");
                    sb.Append($"{resManager.GetString("Perimeter", cultura)} {item.Perimetro:#.##} <br/>");
                }

                var totalFormas = resumen.Sum(r => r.Cantidad);
                var totalArea = resumen.Sum(r => r.Area);
                var totalPerimetro = resumen.Sum(r => r.Perimetro);

                sb.Append($"TOTAL:<br/>{totalFormas} ");
                sb.Append($"{resManager.GetString("Shapes", cultura)} | ");
                sb.Append($"{resManager.GetString("Perimeter", cultura)} {totalPerimetro:#.##} | ");
                sb.Append($"{resManager.GetString("Area", cultura)} {totalArea:#.##}");
            }

            return sb.ToString();
        }
    }
}