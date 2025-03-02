namespace WebServiceProcesarTSS.Model
{
    public class AutodeterminacionWrapper
    {
        public EncabezadoDTO Encabezado { get; set; }
        public List<EmpleadoDTO> Detalles { get; set; }
        public SumarioDTO Sumario { get; set; }

        public class EncabezadoDTO
        {
            public string TipoRegistro { get; set; } = "E"; // Valor fijo
            public string RncEmpresa { get; set; }
            public DateTime FechaTransmision { get; set; }
            public string PeriodoCotizable { get; set; }
        }

        public class EmpleadoDTO
        {
            public string TipoRegistro { get; set; } = "D";
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

        public class SumarioDTO
        {
            public string TipoRegistro { get; set; } = "S"; // Valor fijo
            public int CantidadRegistros { get; set; }
        }
    }
}
