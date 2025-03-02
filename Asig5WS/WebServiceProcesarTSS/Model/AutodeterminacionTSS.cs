namespace WebServiceProcesarTSS.Model
{
    public class AutodeterminacionTSS
    {
        public int IdRegistro { get; set; }
        public string RncEmpresa { get; set; }
        public DateTime FechaTransmision { get; set; }
        public string PeriodoCotizable { get; set; }
        public string Nss { get; set; }
        public string Cedula { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public decimal SueldoMensual { get; set; }
        public decimal MontoCotizable { get; set; }
        public DateTime FechaIngreso { get; set; }
        public string TipoContrato { get; set; }
        public string Estado { get; set; }
    }
}
