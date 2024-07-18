using System;
using System.Collections.Generic;
using System.Globalization;
using System.Resources;

using DevelopmentChallenge.Data.Classes;
using NUnit.Framework;

namespace DevelopmentChallenge.Data.Tests
{
    [TestFixture]
    internal class FormaGeometricaTests
    {
        private List<FormaGeometrica> formasGeometricas;
        private ResourceManager resManager;

        [SetUp]
        public void SetUp()
        {
            formasGeometricas = new List<FormaGeometrica>();
            resManager = new ResourceManager("DevelopmentChallenge.Data.Properties.Resources", typeof(FormaGeometrica).Assembly);
        }

        [Test]
        public void TestResumenListaVaciaEnEspaniol()
        {
            Assert.AreEqual("<h1>Lista vacía de formas!</h1>",
                ReporteFormas.Imprimir(formasGeometricas, resManager, new CultureInfo("es-AR")));
        }

        [Test]
        public void TestResumenListaVaciaFormasEnIngles()
        {
            Assert.AreEqual("<h1>Empty list of shapes!</h1>",
                ReporteFormas.Imprimir(new List<FormaGeometrica>(), resManager, new CultureInfo("en-US")));
        }

        [Test]
        public void TestResumenListaVaciaFormasEnPortugues()
        {
            Assert.AreEqual("<h1>Lista de formas vazia!</h1>",
                ReporteFormas.Imprimir(new List<FormaGeometrica>(), resManager, new CultureInfo("pt-BR")));
        }

        [Test]
        public void TestResumenListaConUnCuadrado()
        {
            formasGeometricas.Add(new Cuadrado(5));

            var reporte = ReporteFormas.Imprimir(formasGeometricas, resManager, new CultureInfo("es-AR"));
            Assert.AreEqual(
                "<h1>Reporte de Formas</h1>1 Cuadrado | Area 25 | Perímetro 20 <br/>TOTAL:<br/>1 formas | Perímetro 20 | Area 25", 
                reporte);
        }

        [Test]
        public void TestResumenListaConMasCuadrados()
        {
            formasGeometricas.Add(new Cuadrado(5));
            formasGeometricas.Add(new Cuadrado(1));
            formasGeometricas.Add(new Cuadrado(3));

            var reporte = ReporteFormas.Imprimir(formasGeometricas, resManager, new CultureInfo("en-US"));
            Assert.AreEqual(
                "<h1>Shapes report</h1>3 Squares | Area 35 | Perimeter 36 <br/>TOTAL:<br/>3 shapes | Perimeter 36 | Area 35",
                reporte);
        }

        [Test]
        public void TestResumenListaConMasTiposEnEspaniol()
        {
            formasGeometricas.Add(new Cuadrado(5));
            formasGeometricas.Add(new Circulo(3));
            formasGeometricas.Add(new TrianguloEquilatero(4));
            formasGeometricas.Add(new Cuadrado(2));
            formasGeometricas.Add(new TrianguloEquilatero(9));
            formasGeometricas.Add(new Circulo(2.75m));
            formasGeometricas.Add(new TrianguloEquilatero(4.2m));

            var reporte = ReporteFormas.Imprimir(formasGeometricas, resManager, new CultureInfo("es-AR"));
            Assert.AreEqual(
                "<h1>Reporte de Formas</h1>2 Cuadrados | Area 29 | Perímetro 28 <br/>2 Círculos | Area 52,03 | Perímetro 36,13 <br/>3 Triángulos | Area 49,64 | Perímetro 51,6 <br/>TOTAL:<br/>7 formas | Perímetro 115,73 | Area 130,67",
                reporte);
        }

        [Test]
        public void TestResumenListaConMasTiposEnIngles()
        {
            formasGeometricas.Add(new Cuadrado(5));
            formasGeometricas.Add(new Circulo(3));
            formasGeometricas.Add(new TrianguloEquilatero(4));
            formasGeometricas.Add(new Cuadrado(2));
            formasGeometricas.Add(new TrianguloEquilatero(9));
            formasGeometricas.Add(new Circulo(2.75m));
            formasGeometricas.Add(new TrianguloEquilatero(4.2m));

            var reporte = ReporteFormas.Imprimir(formasGeometricas, resManager, new CultureInfo("en-US"));
            Assert.AreEqual(
                "<h1>Shapes report</h1>2 Squares | Area 29 | Perimeter 28 <br/>2 Circles | Area 52,03 | Perimeter 36,13 <br/>3 Triangles | Area 49,64 | Perimeter 51,6 <br/>TOTAL:<br/>7 shapes | Perimeter 115,73 | Area 130,67",
                reporte);
        }

        [Test]
        public void TestCalcularAreaCuadrado()
        {
            var cuadrado = new Cuadrado(5);
            var area = cuadrado.CalcularArea();
            Assert.AreEqual(25, area);
        }

        [Test]
        public void TestCalcularPerimetroCuadrado()
        {
            var cuadrado = new Cuadrado(5);
            var perimetro = cuadrado.CalcularPerimetro();
            Assert.AreEqual(20, perimetro);
        }

        [Test]
        public void TestCalcularAreaCirculo()
        {
            var circulo = new Circulo(5);
            var area = circulo.CalcularArea();
            Assert.AreEqual((decimal)Math.PI * 25, area);
        }

        [Test]
        public void TestCalcularPerimetroCirculo()
        {
            var circulo = new Circulo(5);
            var perimetro = circulo.CalcularPerimetro();
            Assert.AreEqual((decimal)Math.PI * 10, perimetro);
        }

        [Test]
        public void TestCalcularAreaTrianguloEquilatero()
        {
            var triangulo = new TrianguloEquilatero(5);
            var area = triangulo.CalcularArea();
            Assert.AreEqual((decimal)Math.Sqrt(3) / 4 * 25, area);
        }

        [Test]
        public void TestCalcularPerimetroTrianguloEquilatero()
        {
            var triangulo = new TrianguloEquilatero(5);
            var perimetro = triangulo.CalcularPerimetro();
            Assert.AreEqual(15, perimetro);
        }

        [Test]
        public void TestCalcularAreaTrapecioRectangulo()
        {
            var trapecio = new TrapecioRectangulo(6, 4, 5);
            var area = trapecio.CalcularArea();
            Assert.AreEqual(25, area);
        }

        [Test]
        public void TestCalcularPerimetroTrapecioRectangulo()
        {
            var trapecio = new TrapecioRectangulo(6, 4, 5);
            var perimetro = trapecio.CalcularPerimetro();
            Assert.AreEqual(20.3851648071345, perimetro);
        }

        [Test]
        public void TestImprimirReporteEnEspaniol()
        {
            formasGeometricas.Add(new Cuadrado(5));
            formasGeometricas.Add(new TrianguloEquilatero(5));
            formasGeometricas.Add(new Circulo(5));
            formasGeometricas.Add(new TrapecioRectangulo(6, 4, 5));

            var reporte = ReporteFormas.Imprimir(formasGeometricas, resManager, new CultureInfo("es-AR"));
            Assert.IsTrue(reporte.Contains("<h1>Reporte de Formas</h1>"));
            Assert.IsTrue(reporte.Contains("1 Cuadrado | Area 25 | Perímetro 20 <br/>"));
            Assert.IsTrue(reporte.Contains("1 Triángulo | Area 10,83 | Perímetro 15 <br/>"));
            Assert.IsTrue(reporte.Contains("1 Círculo | Area 78,54 | Perímetro 31,42 <br/>"));
            Assert.IsTrue(reporte.Contains("1 Trapecio Rectángulo | Area 25 | Perímetro 20,39 <br/>"));
            Assert.IsTrue(reporte.Contains("TOTAL:<br/>4 formas | Perímetro 86,8 | Area 139,37"));
        }

        [Test]
        public void TestImprimirReporteEnIngles()
        {
            formasGeometricas.Add(new Cuadrado(5));
            formasGeometricas.Add(new TrianguloEquilatero(5));
            formasGeometricas.Add(new Circulo(5));
            formasGeometricas.Add(new TrapecioRectangulo(6, 4, 5));

            var reporte = ReporteFormas.Imprimir(formasGeometricas, resManager, new CultureInfo("en-US"));
            Assert.IsTrue(reporte.Contains("<h1>Shapes report</h1>"));
            Assert.IsTrue(reporte.Contains("1 Square | Area 25 | Perimeter 20 <br/>"));
            Assert.IsTrue(reporte.Contains("1 Triangle | Area 10,83 | Perimeter 15 <br/>"));
            Assert.IsTrue(reporte.Contains("1 Circle | Area 78,54 | Perimeter 31,42 <br/>"));
            Assert.IsTrue(reporte.Contains("1 Right Trapezoid | Area 25 | Perimeter 20,39 <br/>"));
            Assert.IsTrue(reporte.Contains("TOTAL:<br/>4 shapes | Perimeter 86,8 | Area 139,37"));
        }

        [Test]
        public void TestImprimirReporteEnPortugues()
        {
            formasGeometricas.Add(new Cuadrado(5));
            formasGeometricas.Add(new TrianguloEquilatero(5));
            formasGeometricas.Add(new Circulo(5));
            formasGeometricas.Add(new TrapecioRectangulo(6, 4, 5));

            var reporte = ReporteFormas.Imprimir(formasGeometricas, resManager, new CultureInfo("pt-BR"));
            Assert.IsTrue(reporte.Contains("<h1>Relatório de Formas</h1>"));
            Assert.IsTrue(reporte.Contains("1 Quadrado | Área 25 | Perímetro 20 <br/>"));
            Assert.IsTrue(reporte.Contains("1 Triângulo | Área 10,83 | Perímetro 15 <br/>"));
            Assert.IsTrue(reporte.Contains("1 Círculo | Área 78,54 | Perímetro 31,42 <br/>"));
            Assert.IsTrue(reporte.Contains("1 Trapézio Retângulo | Área 25 | Perímetro 20,39 <br/>"));
            Assert.IsTrue(reporte.Contains("TOTAL:<br/>4 formas | Perímetro 86,8 | Área 139,37"));
        }
    }
}
