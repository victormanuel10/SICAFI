using System;
using System.Data;
using System.Windows.Forms;
using SICAFI.Datos;
using SICAFI.App.Forms.Shared;
using Microsoft.Data.SqlClient;

namespace SICAFI.App.Forms.FichaPredial.ZonaEconomica
{
    public partial class FrmInsertarZonaEconomica : Form
    {
        //=========================================
        //*** INSERTAR ZONA ECONÓMICA ***
        //=========================================

        #region Variables

        //*** VARIABLES QUE RECIBE DEL FORMULARIO DE FICHA PREDIAL ***
        private int vl_inFIPRNURE;
        private string vl_stRESODEPA = "";
        private string vl_stRESOMUNI = "";
        private int vl_inRESOTIRE;
        private int vl_inRESOCLSE;
        private int vl_inRESOVIGE;
        private int vl_inRESORESO;
        private bool vl_boSWVerificaDatoAlGuardar = true;

        // Controles del formulario
        private TextBox txtFPZECODI;
        private ComboBox cboFPZEZOEC;
        private TextBox txtFPZEPERC;
        private ComboBox cboFPZEESTA;
        private DateTimePicker dtpFPZEFECI;
        private DateTimePicker dtpFPZEFECF;
        private Button btnGuardar;
        private Button btnCancelar;
        private Button btnLimpiar;
        private DataGridView dgvFIPRZOEC;
        private BindingNavigator BindingNavigator_FIPRZOEC_1;
        private BindingSource BindingSource_FIPRZOEC_1;

        #endregion

        #region Constructor

        public FrmInsertarZonaEconomica(int inFIPRNUFI, int inFIPRNURE, string stRESODEPA, 
                                       string stRESOMUNI, int inRESOTIRE, int inRESOCLSE, 
                                       int inRESOVIGE, int inRESORESO)
        {
            VariablesPublicas.vp_FichaPredial = inFIPRNUFI;
            this.vl_inFIPRNURE = inFIPRNURE;
            this.vl_stRESODEPA = stRESODEPA;
            this.vl_stRESOMUNI = stRESOMUNI;
            this.vl_inRESOTIRE = inRESOTIRE;
            this.vl_inRESOCLSE = inRESOCLSE;
            this.vl_inRESOVIGE = inRESOVIGE;
            this.vl_inRESORESO = inRESORESO;

            InitializeComponent();
            pro_LimpiarCampos();
            pro_inicializarControles();
            pro_NumeroDeSecuenciaDeRegistro();
            pro_ReconsultarZonaEconomica();
            pro_Sumar_Porcentaje();
        }

        public FrmInsertarZonaEconomica()
        {
            // Constructor sin parámetros para uso desde menú principal
            InitializeComponent();
            pro_LimpiarCampos();
            pro_inicializarControles();
            pro_NumeroDeSecuenciaDeRegistro();
            pro_ReconsultarZonaEconomica();
            pro_Sumar_Porcentaje();
        }

        #endregion

        #region Inicialización

        private void InitializeComponent()
        {
            // Configurar formulario
            this.Text = "SICAFI - Insertar Zona Económica";
            this.Size = new System.Drawing.Size(800, 600);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.WindowState = FormWindowState.Normal;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;

            // Aplicar tema SICAFI
            SicafiTheme.ApplyFormTheme(this);

            // Crear controles
            CreateControls();

            // Configurar layout
            SetupLayout();
        }

        private void CreateControls()
        {
            // Crear BindingSource y BindingNavigator
            this.BindingSource_FIPRZOEC_1 = new BindingSource();
            this.BindingNavigator_FIPRZOEC_1 = SicafiTheme.CreateBindingNavigator();
            this.BindingNavigator_FIPRZOEC_1.BindingSource = this.BindingSource_FIPRZOEC_1;

            // Crear DataGridView
            this.dgvFIPRZOEC = SicafiTheme.CreateDataGridView();
            this.dgvFIPRZOEC.Location = new System.Drawing.Point(20, 300);
            this.dgvFIPRZOEC.Size = new System.Drawing.Size(750, 200);

            // Crear TextBoxes
            this.txtFPZECODI = SicafiTheme.CreateTextBox();
            this.txtFPZECODI.Location = new System.Drawing.Point(130, 20);
            this.txtFPZECODI.ReadOnly = true;

            this.txtFPZEPERC = SicafiTheme.CreateTextBox();
            this.txtFPZEPERC.Location = new System.Drawing.Point(130, 80);

            // Crear ComboBoxes
            this.cboFPZEZOEC = SicafiTheme.CreateComboBox();
            this.cboFPZEZOEC.Location = new System.Drawing.Point(130, 50);

            this.cboFPZEESTA = SicafiTheme.CreateComboBox();
            this.cboFPZEESTA.Location = new System.Drawing.Point(130, 110);

            // Crear DateTimePickers
            this.dtpFPZEFECI = new DateTimePicker();
            this.dtpFPZEFECI.Location = new System.Drawing.Point(130, 140);
            this.dtpFPZEFECI.Size = new System.Drawing.Size(200, 25);
            this.dtpFPZEFECI.Value = DateTime.Now;

            this.dtpFPZEFECF = new DateTimePicker();
            this.dtpFPZEFECF.Location = new System.Drawing.Point(130, 170);
            this.dtpFPZEFECF.Size = new System.Drawing.Size(200, 25);
            this.dtpFPZEFECF.Value = DateTime.Now.AddYears(1);

            // Crear botones
            this.btnGuardar = SicafiTheme.CreateButton("Guardar", true);
            this.btnGuardar.Location = new System.Drawing.Point(130, 220);
            this.btnGuardar.Click += new EventHandler(BtnGuardar_Click);

            this.btnCancelar = SicafiTheme.CreateButton("Cancelar");
            this.btnCancelar.Location = new System.Drawing.Point(240, 220);
            this.btnCancelar.Click += new EventHandler(BtnCancelar_Click);

            this.btnLimpiar = SicafiTheme.CreateButton("Limpiar");
            this.btnLimpiar.Location = new System.Drawing.Point(350, 220);
            this.btnLimpiar.Click += new EventHandler(BtnLimpiar_Click);
        }

        private void SetupLayout()
        {
            // Panel principal
            Panel mainPanel = SicafiTheme.CreateMainPanel();

            // GroupBox para datos de zona económica
            GroupBox gbZonaEconomica = SicafiTheme.CreateGroupBox("Datos de Zona Económica", 750, 250);
            gbZonaEconomica.Location = new System.Drawing.Point(20, 20);

            // Labels
            Label lblCodigo = SicafiTheme.CreateLabel("Código:");
            lblCodigo.Location = new System.Drawing.Point(20, 25);
            lblCodigo.Size = new System.Drawing.Size(100, 20);

            Label lblZonaEconomica = SicafiTheme.CreateLabel("Zona Económica:");
            lblZonaEconomica.Location = new System.Drawing.Point(20, 55);
            lblZonaEconomica.Size = new System.Drawing.Size(100, 20);

            Label lblPorcentaje = SicafiTheme.CreateLabel("Porcentaje (%):");
            lblPorcentaje.Location = new System.Drawing.Point(20, 85);
            lblPorcentaje.Size = new System.Drawing.Size(100, 20);

            Label lblEstado = SicafiTheme.CreateLabel("Estado:");
            lblEstado.Location = new System.Drawing.Point(20, 115);
            lblEstado.Size = new System.Drawing.Size(100, 20);

            Label lblFechaInicio = SicafiTheme.CreateLabel("Fecha Inicio:");
            lblFechaInicio.Location = new System.Drawing.Point(20, 145);
            lblFechaInicio.Size = new System.Drawing.Size(100, 20);

            Label lblFechaFin = SicafiTheme.CreateLabel("Fecha Fin:");
            lblFechaFin.Location = new System.Drawing.Point(20, 175);
            lblFechaFin.Size = new System.Drawing.Size(100, 20);

            // Agregar controles al GroupBox
            gbZonaEconomica.Controls.Add(lblCodigo);
            gbZonaEconomica.Controls.Add(lblZonaEconomica);
            gbZonaEconomica.Controls.Add(lblPorcentaje);
            gbZonaEconomica.Controls.Add(lblEstado);
            gbZonaEconomica.Controls.Add(lblFechaInicio);
            gbZonaEconomica.Controls.Add(lblFechaFin);
            gbZonaEconomica.Controls.Add(this.txtFPZECODI);
            gbZonaEconomica.Controls.Add(this.cboFPZEZOEC);
            gbZonaEconomica.Controls.Add(this.txtFPZEPERC);
            gbZonaEconomica.Controls.Add(this.cboFPZEESTA);
            gbZonaEconomica.Controls.Add(this.dtpFPZEFECI);
            gbZonaEconomica.Controls.Add(this.dtpFPZEFECF);
            gbZonaEconomica.Controls.Add(this.btnGuardar);
            gbZonaEconomica.Controls.Add(this.btnCancelar);
            gbZonaEconomica.Controls.Add(this.btnLimpiar);

            // Agregar controles al formulario
            this.Controls.Add(this.BindingNavigator_FIPRZOEC_1);
            this.Controls.Add(gbZonaEconomica);
            this.Controls.Add(this.dgvFIPRZOEC);
        }

        #endregion

        #region Procedimientos

        private void pro_inicializarControles()
        {
            //=========================================
            // CARGA LOS COMBOBOX CON LOS DATOS ACTIVOS
            //=========================================

            // Cargar estados (simulado)
            this.cboFPZEESTA.Items.Clear();
            this.cboFPZEESTA.Items.Add("ACTIVO");
            this.cboFPZEESTA.Items.Add("INACTIVO");

            // Cargar zonas económicas (simulado)
            this.cboFPZEZOEC.Items.Clear();
            this.cboFPZEZOEC.Items.Add("RESIDENCIAL");
            this.cboFPZEZOEC.Items.Add("COMERCIAL");
            this.cboFPZEZOEC.Items.Add("INDUSTRIAL");
            this.cboFPZEZOEC.Items.Add("MIXTO");

            this.cboFPZEZOEC.Focus();
        }

        private void pro_ReconsultarZonaEconomica()
        {
            try
            {
                // Simular datos de zona económica
                DataTable dt = new DataTable();
                dt.Columns.Add("Código", typeof(int));
                dt.Columns.Add("Zona Económica", typeof(string));
                dt.Columns.Add("Porcentaje", typeof(decimal));
                dt.Columns.Add("Estado", typeof(string));
                dt.Columns.Add("Fecha Inicio", typeof(DateTime));
                dt.Columns.Add("Fecha Fin", typeof(DateTime));

                // Agregar datos de ejemplo
                dt.Rows.Add(1, "RESIDENCIAL", 60.0, "ACTIVO", DateTime.Now, DateTime.Now.AddYears(1));
                dt.Rows.Add(2, "COMERCIAL", 40.0, "ACTIVO", DateTime.Now, DateTime.Now.AddYears(1));

                this.BindingSource_FIPRZOEC_1.DataSource = dt;
                this.dgvFIPRZOEC.DataSource = this.BindingSource_FIPRZOEC_1.DataSource;

                // Ocultar columnas de ID
                if (this.dgvFIPRZOEC.Columns.Count > 1)
                {
                    this.dgvFIPRZOEC.Columns[0].Visible = false;
                }

                MessageBox.Show($"Registros: {this.BindingSource_FIPRZOEC_1.Count}");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }

        private void pro_NumeroDeSecuenciaDeRegistro()
        {
            // Simular número de secuencia
            int inFPZESECU = 1;
            
            // En la implementación real, buscaría el siguiente número disponible
            this.txtFPZECODI.Text = inFPZESECU.ToString();
        }

        private void pro_Sumar_Porcentaje()
        {
            // Simular suma de porcentajes
            double totalPorcentaje = 0.0;
            
            // En la implementación real, sumaría todos los porcentajes de zonas económicas
            MessageBox.Show($"Total de porcentajes: {totalPorcentaje}%");
        }

        private void pro_LimpiarCampos()
        {
            this.txtFPZECODI.Text = "";
            this.cboFPZEZOEC.SelectedIndex = -1;
            this.txtFPZEPERC.Text = "";
            
            if (this.cboFPZEESTA.Items.Count > 0)
                this.cboFPZEESTA.SelectedIndex = 0;
                
            this.dtpFPZEFECI.Value = DateTime.Now;
            this.dtpFPZEFECF.Value = DateTime.Now.AddYears(1);
        }

        #endregion

        #region Eventos

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            if (ValidarCampos())
            {
                // Simular guardado
                MessageBox.Show("Zona económica guardada exitosamente", "SICAFI", 
                              MessageBoxButtons.OK, MessageBoxIcon.Information);
                
                pro_ReconsultarZonaEconomica();
                pro_LimpiarCampos();
            }
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnLimpiar_Click(object sender, EventArgs e)
        {
            pro_LimpiarCampos();
        }

        #endregion

        #region Validaciones

        private bool ValidarCampos()
        {
            if (string.IsNullOrEmpty(this.cboFPZEZOEC.Text))
            {
                MessageBox.Show("Debe seleccionar una zona económica", "SICAFI", 
                              MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.cboFPZEZOEC.Focus();
                return false;
            }

            if (string.IsNullOrEmpty(this.txtFPZEPERC.Text))
            {
                MessageBox.Show("Debe ingresar el porcentaje", "SICAFI", 
                              MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.txtFPZEPERC.Focus();
                return false;
            }

            if (!decimal.TryParse(this.txtFPZEPERC.Text, out decimal porcentaje))
            {
                MessageBox.Show("El porcentaje debe ser un número válido", "SICAFI", 
                              MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.txtFPZEPERC.Focus();
                return false;
            }

            if (porcentaje <= 0 || porcentaje > 100)
            {
                MessageBox.Show("El porcentaje debe estar entre 0 y 100", "SICAFI", 
                              MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.txtFPZEPERC.Focus();
                return false;
            }

            return true;
        }

        #endregion
    }
} 