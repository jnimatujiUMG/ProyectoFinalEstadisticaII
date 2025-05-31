using System;

namespace ProyectoFinalEstadisticaII
{
    public class PruebaF
    {
        private readonly float[] varianzas;
        private readonly int[] tamanos;

        public PruebaF(float[] varianzas, int[] tamanos)
        {
            this.varianzas = varianzas;
            this.tamanos = tamanos;
        }

        public float CalcularEstadisticoF()
        {
            float mayor = Math.Max(varianzas[0], varianzas[1]);
            float menor = Math.Min(varianzas[0], varianzas[1]);
            return mayor / menor;
        }

        public string ObtenerInterpretacion()
        {
            float f = CalcularEstadisticoF();
            int glMayor = tamanos[varianzas[0] > varianzas[1] ? 0 : 1] - 1;
            int glMenor = tamanos[varianzas[0] > varianzas[1] ? 1 : 0] - 1;

            return $"Estadístico F = {f:F4}\n" +
                   $"Grados de libertad: Mayor = {glMayor}, Menor = {glMenor}\n\n" +
                   "Compara con una tabla F crítica para decidir si rechazas H0.";
        }
    }
}
