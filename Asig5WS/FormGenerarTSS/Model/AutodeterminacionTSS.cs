﻿using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace FormGenerarTSS.Model
{
    public class AutodeterminacionTSS
    {
        [JsonIgnore]
        private JsonSerializerOptions serializerOptions = new()
        {
            WriteIndented = true,
        };

        public Encabezado Encabezado { get; set; }
        public List<Empleado> Detalles { get; set; }
        public Sumario Sumario { get; set; }

        public AutodeterminacionTSS()
        {
            Detalles = new List<Empleado>();
        }

        public bool EsValido()
        {
            return Encabezado != null && Sumario != null && Detalles.Count > 0;
        }

        public string GenerarJSON()
        {
            if (!EsValido())
                return string.Empty;

            return JsonSerializer.Serialize(this, serializerOptions);
        }

        public string GenerarArchivo()
        {
            StringBuilder strBuilder = new();
            if (!EsValido())
                return string.Empty;

            // Generar Encabezado
            string rncFormateado = Encabezado.RncEmpresa.PadLeft(11, '0');
            string fechaTransmisionFormateada = Encabezado.FechaTransmision.ToString("dd/MM/yyyy");
            string encabezado = $"{Encabezado.TipoRegistro},{rncFormateado},{fechaTransmisionFormateada},{Encabezado.PeriodoCotizable}";
            strBuilder.AppendLine(encabezado);

            // Generar Detalles
            foreach (var empleado in Detalles)
            {
                string detalle =
                    $"{empleado.TipoRegistro}," +
                    $"{empleado.Nss.PadLeft(12, '0')}," +
                    $"{empleado.Cedula.PadLeft(9, '0')}," +
                    $"{empleado.Nombres}," +
                    $"{empleado.Apellidos}," +
                    $"{empleado.SueldoMensual:F2}," +
                    $"{empleado.MontoCotizable:F2}," +
                    $"{empleado.FechaIngreso:dd/MM/yyyy}," +
                    $"{empleado.TipoContrato}," +
                    $"{empleado.Estado}";

                strBuilder.AppendLine(detalle);
            }

            //Sumario
            strBuilder.AppendLine($"{Sumario.TipoRegistro},{Sumario.CantidadRegistros}");

            return strBuilder.ToString();
        }
    }
}
