namespace FormGenerarTSS.Model
{
    public class Encabezado
    {
        public string TipoRegistro { get; set; } = "E"; // Valor fijo
        public string RncEmpresa { get; set; }
        public DateTime FechaTransmision { get; set; }
        public string PeriodoCotizable { get; set; }
    }
}
