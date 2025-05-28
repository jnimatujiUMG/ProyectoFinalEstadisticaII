using System;

namespace ProyectoFinalEstadisticaII
{
    public class PruebaT
    {
        public float[] Promedios { get; set; } = new float[2];
        public float[] Varianzas { get; set; } = new float[2];
        public int[] Muestras { get; set; } = new int[2];

        public int GradosLibertad => Muestras[0] + Muestras[1] - 2;

        public float ValorCriticoT { get; set; } = 2.021f; // Para alfa=0.05 y gl=40 por defecto
        public float Alfa { get; set; } = 0.05f;

        public PruebaT(float[] promedios, float[] varianzas, int[] muestras)
        {
            if (promedios.Length != 2 || varianzas.Length != 2 || muestras.Length != 2)
                throw new ArgumentException("Los arreglos deben tener exactamente 2 elementos.");

            Promedios = promedios;
            Varianzas = varianzas;
            Muestras = muestras;
        }

        public float CalcularVarianzaAgrupada()
        {
            int n1 = Muestras[0];
            int n2 = Muestras[1];

            float Sp2 = (((n1 - 1) * Varianzas[0]) + ((n2 - 1) * Varianzas[1])) / (n1 + n2 - 2);
            return Sp2;
        }

        public float CalcularEstadisticoT()
        {
            int n1 = Muestras[0];
            int n2 = Muestras[1];

            float Sp2 = CalcularVarianzaAgrupada();
            if (Sp2 < 0) throw new Exception("Varianza agrupada negativa, datos inválidos.");

            float numerador = Promedios[0] - Promedios[1];
            float denominador = (float)(Math.Sqrt(Sp2) * Math.Sqrt((1.0 / n1) + (1.0 / n2)));

            if (denominador == 0)
                throw new DivideByZeroException("Denominador cero en cálculo de estadístico t.");

            return numerador / denominador;
        }

        public string ObtenerInterpretacion()
        {
            float tCalc = CalcularEstadisticoT();
            int gl = GradosLibertad;

            if (Math.Abs(tCalc) > ValorCriticoT)
            {
                return $"t calculado = {tCalc:F2} > t crítico = {ValorCriticoT}, " +
                       $"con {gl} grados de libertad y alfa = {Alfa}, se RECHAZA la hipótesis nula.\n" +
                       "Hay diferencia significativa entre los grupos.";
            }
            else
            {
                return $"t calculado = {tCalc:F2} ≤ t crítico = {ValorCriticoT}, " +
                       $"con {gl} grados de libertad y alfa = {Alfa}, NO se rechaza la hipótesis nula.\n" +
                       "No hay diferencia significativa entre los grupos.";
            }
        }
    }
}
