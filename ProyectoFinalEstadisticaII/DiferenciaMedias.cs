namespace ProyectoFinalEstadisticaII
{
    public class DiferenciaMedias
    {
        public string Nombre { get; set; }
        public double Promedio1 { get; set; }
        public double Promedio2 { get; set; }

        public DiferenciaMedias(string nombre, double promedio1, double promedio2)
        {
            Nombre = nombre;
            Promedio1 = promedio1;
            Promedio2 = promedio2;
        }

        public double CalcularDiferencia()
        {
            return Promedio1 - Promedio2;
        }
    }
}
