using System;

namespace DevelopmentChallenge.Data.Classes
{
    public static class FormaGeometricaFactory
    {
        public static FormaGeometrica CrearForma(int tipo, params decimal[] dimensiones)
        {
            switch (tipo)
            {
                case 1: return new Cuadrado(dimensiones[0]);
                case 2: return new TrianguloEquilatero(dimensiones[0]);
                case 3: return new Circulo(dimensiones[0]);
                case 4: return new TrapecioRectangulo(dimensiones[0], dimensiones[1], dimensiones[2]);
                default: throw new ArgumentOutOfRangeException("Tipo de forma desconocido");
            }
        }
    }
}
