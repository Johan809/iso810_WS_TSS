namespace iso810_asignacion2
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            dataGridView1 = new DataGridView();
            btnGenerarArchivo = new Button();
            groupBox1 = new GroupBox();
            groupBox2 = new GroupBox();
            ddlPeriodoMes = new ComboBox();
            ddlPeriodoAno = new ComboBox();
            txtRnc = new TextBox();
            dtpFechaTransmicion = new DateTimePicker();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(6, 47);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 72;
            dataGridView1.Size = new Size(1268, 307);
            dataGridView1.TabIndex = 0;
            // 
            // btnGenerarArchivo
            // 
            btnGenerarArchivo.Location = new Point(1115, 680);
            btnGenerarArchivo.Name = "btnGenerarArchivo";
            btnGenerarArchivo.Size = new Size(194, 40);
            btnGenerarArchivo.TabIndex = 2;
            btnGenerarArchivo.Text = "Generar Archivo";
            btnGenerarArchivo.UseVisualStyleBackColor = true;
            btnGenerarArchivo.Click += btnGenerarArchivo_Click;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(dataGridView1);
            groupBox1.Location = new Point(29, 301);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(1280, 360);
            groupBox1.TabIndex = 3;
            groupBox1.TabStop = false;
            groupBox1.Text = "Detalles Empleados";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(ddlPeriodoMes);
            groupBox2.Controls.Add(ddlPeriodoAno);
            groupBox2.Controls.Add(txtRnc);
            groupBox2.Controls.Add(dtpFechaTransmicion);
            groupBox2.Controls.Add(label3);
            groupBox2.Controls.Add(label2);
            groupBox2.Controls.Add(label1);
            groupBox2.Location = new Point(35, 36);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(1274, 250);
            groupBox2.TabIndex = 4;
            groupBox2.TabStop = false;
            groupBox2.Text = "Datos Empresa";
            // 
            // ddlPeriodoMes
            // 
            ddlPeriodoMes.DropDownStyle = ComboBoxStyle.DropDownList;
            ddlPeriodoMes.FormattingEnabled = true;
            ddlPeriodoMes.Items.AddRange(new object[] { "01", "02", "03", "04", "05", "06", "07", "08", "09", "10", "11", "12" });
            ddlPeriodoMes.Location = new Point(307, 186);
            ddlPeriodoMes.Name = "ddlPeriodoMes";
            ddlPeriodoMes.Size = new Size(158, 38);
            ddlPeriodoMes.TabIndex = 6;
            // 
            // ddlPeriodoAno
            // 
            ddlPeriodoAno.DropDownStyle = ComboBoxStyle.DropDownList;
            ddlPeriodoAno.FormattingEnabled = true;
            ddlPeriodoAno.Items.AddRange(new object[] { "2024", "2025" });
            ddlPeriodoAno.Location = new Point(499, 186);
            ddlPeriodoAno.Name = "ddlPeriodoAno";
            ddlPeriodoAno.Size = new Size(158, 38);
            ddlPeriodoAno.TabIndex = 5;
            // 
            // txtRnc
            // 
            txtRnc.Location = new Point(307, 53);
            txtRnc.Name = "txtRnc";
            txtRnc.Size = new Size(350, 35);
            txtRnc.TabIndex = 4;
            txtRnc.TextChanged += txtRncEmpresa_TextChanged;
            txtRnc.KeyPress += txtRncEmpresa_KeyPress;
            // 
            // dtpFechaTransmicion
            // 
            dtpFechaTransmicion.Enabled = false;
            dtpFechaTransmicion.Format = DateTimePickerFormat.Short;
            dtpFechaTransmicion.ImeMode = ImeMode.Off;
            dtpFechaTransmicion.Location = new Point(307, 123);
            dtpFechaTransmicion.Name = "dtpFechaTransmicion";
            dtpFechaTransmicion.Size = new Size(350, 35);
            dtpFechaTransmicion.TabIndex = 3;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(6, 189);
            label3.Name = "label3";
            label3.Size = new Size(175, 30);
            label3.TabIndex = 2;
            label3.Text = "Periodo Cotizable";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(6, 123);
            label2.Name = "label2";
            label2.Size = new Size(217, 30);
            label2.TabIndex = 1;
            label2.Text = " Fecha de Transmisión";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(6, 56);
            label1.Name = "label1";
            label1.Size = new Size(55, 30);
            label1.TabIndex = 0;
            label1.Text = "RNC";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(12F, 30F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1338, 746);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Controls.Add(btnGenerarArchivo);
            Name = "Form1";
            Text = "Generar Archivo TSS";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dataGridView1;
        private Button btnGenerarArchivo;
        private GroupBox groupBox1;
        private GroupBox groupBox2;
        private Label label1;
        private DateTimePicker dtpFechaTransmicion;
        private Label label3;
        private Label label2;
        private ComboBox ddlPeriodoAno;
        private TextBox txtRnc;
        private ComboBox ddlPeriodoMes;
    }
}
