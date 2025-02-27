using FormGenerarTSS.Model;

namespace FormGenerarTSS
{
    public partial class Form1 : Form
    {
        private ArchivoTSS ArchivoTSS { get; set; }
        private List<Empleado> Empleados { get; set; }
        private const string RUTA_ARCHIVO = @"C:\Users\Johan\Documents\Github\iso810_WS_TSS\files";

        public Form1()
        {
            InitializeComponent();
            ArchivoTSS = new ArchivoTSS();
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

        private void btnGenerarArchivo_Click(object sender, EventArgs e)
        {
            if (!Validar())
                return;
            try
            {
                CrearObjTSS();
                if (!ArchivoTSS.EsValido())
                {
                    MessageBox.Show("El archivo de no pudo ser generado correctamente.");
                    return;
                }

                //fijo por ahora
                if (!Directory.Exists(RUTA_ARCHIVO))
                    Directory.CreateDirectory(RUTA_ARCHIVO);

                string sufijoUnico = Guid.NewGuid().ToString().Substring(0, 8);
                string rutaArchivo = Path.Combine(RUTA_ARCHIVO, $"autodeterminacion_tss_{sufijoUnico}.txt");

                File.WriteAllText(rutaArchivo, ArchivoTSS.GenerarArchivo());
                MessageBox.Show($"Archivo generado exitosamente en: {rutaArchivo}");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocurri� un error al generar el archivo: {ex.Message}");
            }
        }

        private void CrearObjTSS()
        {
            ArchivoTSS = new ArchivoTSS
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
                MessageBox.Show("Debe ingresar un RNC v�lido");
                return false;
            }
            if (ddlPeriodoMes.SelectedItem == null || ddlPeriodoAno.SelectedItem == null)
            {
                MessageBox.Show("Para el Periodo debe seleccionar un mes y a�o v�lidos");
                return false;
            }
            return true;
        }
    }
}
