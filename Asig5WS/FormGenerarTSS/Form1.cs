using FormGenerarTSS.Model;
using System.Text;

namespace FormGenerarTSS
{
    public partial class Form1 : Form
    {
        private AutodeterminacionTSS ArchivoTSS { get; set; }
        private List<Empleado> Empleados { get; set; }
        private const string RUTA_ARCHIVO = @"C:\Users\Johan\Documents\Github\iso810_WS_TSS\files";
        private const string API_URL = "https://localhost:7175/Autodeterminacion";

        public Form1()
        {
            InitializeComponent();
            ArchivoTSS = new AutodeterminacionTSS();
            dtpFechaTransmicion.Value = DateTime.Now;
            Empleados = [.. Empleado.GetEmpleados()];
            dataGridView1.DataSource = Empleados;
            ConfigurarEncabezados();
        }

        private void ConfigurarEncabezados()
        {
            if (dataGridView1.Columns["TipoRegistro"] != null)
                dataGridView1.Columns["TipoRegistro"].Visible = false;

            if (dataGridView1.Columns["Nss"] != null)
                dataGridView1.Columns["Nss"].HeaderText = "NSS";

            if (dataGridView1.Columns["Cedula"] != null)
                dataGridView1.Columns["Cedula"].HeaderText = "Cédula";

            if (dataGridView1.Columns["Nombres"] != null)
                dataGridView1.Columns["Nombres"].HeaderText = "Nombres";

            if (dataGridView1.Columns["Apellidos"] != null)
                dataGridView1.Columns["Apellidos"].HeaderText = "Apellidos";

            if (dataGridView1.Columns["SueldoMensual"] != null)
                dataGridView1.Columns["SueldoMensual"].HeaderText = "Sueldo Mensual";

            if (dataGridView1.Columns["MontoCotizable"] != null)
                dataGridView1.Columns["MontoCotizable"].HeaderText = "Monto Cotizable";

            if (dataGridView1.Columns["FechaIngreso"] != null)
                dataGridView1.Columns["FechaIngreso"].HeaderText = "Fecha Ingreso";

            if (dataGridView1.Columns["TipoContrato"] != null)
                dataGridView1.Columns["TipoContrato"].HeaderText = "Tipo Contrato";

            if (dataGridView1.Columns["Estado"] != null)
                dataGridView1.Columns["Estado"].HeaderText = "Estado";
        }

        private void txtRncEmpresa_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)8)
            {
                e.Handled = true;
            }
        }

        private void txtRncEmpresa_TextChanged(object sender, EventArgs e)
        {
            if (txtRnc.Text.Length > 11)
            {
                txtRnc.Text = txtRnc.Text.Substring(0, 11);
                txtRnc.SelectionStart = txtRnc.Text.Length;
            }
        }

        private async void btnGenerarArchivo_Click(object sender, EventArgs e)
        {
            if (!Validar())
                return;

            try
            {
                CrearObjTSS();
                if (!ArchivoTSS.EsValido())
                {
                    MessageBox.Show("No se pudo enviar la autodeterminación correctamente.");
                    return;
                }

                string json = ArchivoTSS.GenerarJSON();
                var (exito, mensaje) = await EnviarJsonAlWebService(json);

                if (exito)
                    MessageBox.Show("Autodeterminación enviada exitosamente.");
                else
                    MessageBox.Show("Ocurrió un error al enviar la autodeterminación.");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al procesar la autodeterminación: {ex.Message}");
            }
        }

        private async Task<(bool Exito, string Mensaje)> EnviarJsonAlWebService(string json)
        {
            try
            {
                using HttpClient client = new();
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await client.PostAsync(API_URL, content);
                string message = await response.Content.ReadAsStringAsync();
                return (response.IsSuccessStatusCode, message);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al conectar con el webservice: {ex.Message}");
                return (false, ex.Message);
            }
        }

        private void CrearObjTSS()
        {
            ArchivoTSS = new AutodeterminacionTSS
            {
                Encabezado = new Encabezado()
                {
                    RncEmpresa = txtRnc.Text,
                    FechaTransmision = dtpFechaTransmicion.Value,
                    PeriodoCotizable = $"{ddlPeriodoMes.SelectedItem}/{ddlPeriodoAno.SelectedItem}"
                },
                Detalles = Empleados,
                Sumario = new Sumario()
                {
                    CantidadRegistros = Empleados.Count,
                }
            };
        }

        private bool Validar()
        {
            if (string.IsNullOrEmpty(txtRnc.Text) || txtRnc.Text.Length < 9)
            {
                MessageBox.Show("Debe ingresar un RNC válido");
                return false;
            }
            if (ddlPeriodoMes.SelectedItem == null || ddlPeriodoAno.SelectedItem == null)
            {
                MessageBox.Show("Para el Periodo debe seleccionar un mes y año válidos");
                return false;
            }
            return true;
        }
    }
}
