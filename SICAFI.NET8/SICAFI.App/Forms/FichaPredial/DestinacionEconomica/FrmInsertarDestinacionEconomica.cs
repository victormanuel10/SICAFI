using System;
using System.Data;
using System.Windows.Forms;
using SICAFI.Datos;
using Microsoft.Data.SqlClient;

namespace SICAFI.App.Forms.FichaPredial.DestinacionEconomica
{
    public partial class FrmInsertarDestinacionEconomica : Form
    {
        //=====================================
        //*** INSERTAR DESTINACIÓN ECONÓMICA ***
        //=====================================

        #region Variables Locales

        // Variables que recibe del formulario de Ficha Predial
        private int vl_inFIPRNURE;
        private string vl_stRESODEPA = "";
        private string vl_stRESOMUNI = "";
        private int vl_inRESOTIRE;
        private int vl_inRESOCLSE;
        private int vl_inRESOVIGE;
        private int vl_inRESORESO;

        // Controles del formulario
        private TextBox txtFPDECODI;
        private ComboBox cboFPDEDEEC;
        private TextBox txtFPDEPERC;
        private ComboBox cboFPDEESTA;
        private DataGridView dgvFIPRDEEC;
        private BindingNavigator BindingNavigator_FIPRDEEC_1;
        private BindingSource BindingSource_FIPRDEEC_1;
        private Button btnGuardar;
        private Button btnCancelar;
        private Button btnLimpiar;
        private StatusStrip strBARRESTA;
        private ToolStripStatusLabel lblRegistros;

        #endregion

        #region Constructor

        public FrmInsertarDestinacionEconomica(int inFIPRNUFI, int inFIPRNURE, string stRESODEPA, 
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
            pro_ReconsultarDestinoEconomico();
            pro_Sumar_Porcentaje();
        }

        #endregion

        #region Inicialización

        private void InitializeComponent()
        {
            // Configurar formulario
            this.Text = "SICAFI - Insertar Destinación Económica";
            this.Size = new System.Drawing.Size(900, 600);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.WindowState = FormWindowState.Normal;

            // Crear controles
            CreateControls();

            // Configurar layout
            SetupLayout();
        }

        private void CreateControls()
        {
            // Crear BindingSource
            this.BindingSource_FIPRDEEC_1 = new BindingSource();

            // Crear BindingNavigator
            this.BindingNavigator_FIPRDEEC_1 = new BindingNavigator();
            this.BindingNavigator_FIPRDEEC_1.Dock = DockStyle.Top;

            // Crear DataGridView
            this.dgvFIPRDEEC = new DataGridView();
            this.dgvFIPRDEEC.Dock = DockStyle.Bottom;
            this.dgvFIPRDEEC.Height = 250;
            this.dgvFIPRDEEC.AllowUserToAddRows = false;
            this.dgvFIPRDEEC.AllowUserToDeleteRows = false;
            this.dgvFIPRDEEC.ReadOnly = true;
            this.dgvFIPRDEEC.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dgvFIPRDEEC.MultiSelect = false;
            this.dgvFIPRDEEC.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            // Crear TextBoxes
            this.txtFPDECODI = new TextBox { Size = new System.Drawing.Size(100, 25), ReadOnly = true };
            this.txtFPDEPERC = new TextBox { Size = new System.Drawing.Size(100, 25) };

            // Crear ComboBoxes
            this.cboFPDEDEEC = new ComboBox { Size = new System.Drawing.Size(250, 25), DropDownStyle = ComboBoxStyle.DropDownList };
            this.cboFPDEESTA = new ComboBox { Size = new System.Drawing.Size(150, 25), DropDownStyle = ComboBoxStyle.DropDownList };

            // Crear botones
            this.btnGuardar = new Button { Text = "Guardar", Size = new System.Drawing.Size(100, 35) };
            this.btnGuardar.Click += new EventHandler(BtnGuardar_Click);

            this.btnCancelar = new Button { Text = "Cancelar", Size = new System.Drawing.Size(100, 35) };
            this.btnCancelar.Click += new EventHandler(BtnCancelar_Click);

            this.btnLimpiar = new Button { Text = "Limpiar", Size = new System.Drawing.Size(100, 35) };
            this.btnLimpiar.Click += new EventHandler(BtnLimpiar_Click);

            // Crear StatusStrip
            this.strBARRESTA = new StatusStrip();
            this.lblRegistros = new ToolStripStatusLabel("Registros: 0");
            this.strBARRESTA.Items.Add(this.lblRegistros);
        }

        private void SetupLayout()
        {
            // Panel principal
            Panel mainPanel = new Panel
            {
                Dock = DockStyle.Fill,
                BackColor = System.Drawing.Color.WhiteSmoke
            };

            // Panel superior para formulario
            Panel formPanel = new Panel
            {
                Dock = DockStyle.Top,
                Height = 150,
                BackColor = System.Drawing.Color.LightGray
            };

            // Labels
            Label lblCodigo = new Label { Text = "Código:", Location = new System.Drawing.Point(20, 20), Size = new System.Drawing.Size(100, 20) };
            Label lblDestinacionEconomica = new Label { Text = "Destinación Económica:", Location = new System.Drawing.Point(20, 50), Size = new System.Drawing.Size(150, 20) };
            Label lblPorcentaje = new Label { Text = "Porcentaje (%):", Location = new System.Drawing.Point(20, 80), Size = new System.Drawing.Size(100, 20) };
            Label lblEstado = new Label { Text = "Estado:", Location = new System.Drawing.Point(20, 110), Size = new System.Drawing.Size(100, 20) };

            // Posicionar controles
            this.txtFPDECODI.Location = new System.Drawing.Point(180, 18);
            this.cboFPDEDEEC.Location = new System.Drawing.Point(180, 48);
            this.txtFPDEPERC.Location = new System.Drawing.Point(180, 78);
            this.cboFPDEESTA.Location = new System.Drawing.Point(180, 108);

            // Posicionar botones
            this.btnGuardar.Location = new System.Drawing.Point(450, 18);
            this.btnCancelar.Location = new System.Drawing.Point(560, 18);
            this.btnLimpiar.Location = new System.Drawing.Point(670, 18);

            // Agregar controles al panel de formulario
            formPanel.Controls.AddRange(new Control[] { 
                lblCodigo, lblDestinacionEconomica, lblPorcentaje, lblEstado,
                this.txtFPDECODI, this.cboFPDEDEEC, this.txtFPDEPERC, this.cboFPDEESTA,
                this.btnGuardar, this.btnCancelar, this.btnLimpiar
            });

            // Agregar controles al panel principal
            mainPanel.Controls.Add(this.dgvFIPRDEEC);
            mainPanel.Controls.Add(formPanel);

            // Agregar controles al formulario
            this.Controls.Add(this.BindingNavigator_FIPRDEEC_1);
            this.Controls.Add(mainPanel);
            this.Controls.Add(this.strBARRESTA);
        }

        #endregion

        #region Procedimientos

        private void pro_inicializarControles()
        {
            try
            {
                // TODO: Implementar cuando migremos las reglas de negocio
                // var objdatos4 = new cla_ESTADO();
                // var estados = objdatos4.fun_Consultar_ESTADO_X_ESTADO();

                // Por ahora, datos de ejemplo
                var estados = new DataTable();
                estados.Columns.Add("ESTACODI", typeof(int));
                estados.Columns.Add("ESTADESC", typeof(string));

                estados.Rows.Add(1, "Activo");
                estados.Rows.Add(2, "Inactivo");

                this.cboFPDEESTA.DataSource = estados;
                this.cboFPDEESTA.DisplayMember = "ESTADESC";
                this.cboFPDEESTA.ValueMember = "ESTACODI";

                // Cargar destinaciones económicas
                this.cboFPDEDEEC.Items.Clear();
                this.cboFPDEDEEC.Items.Add("Vivienda Familiar");
                this.cboFPDEDEEC.Items.Add("Vivienda Colectiva");
                this.cboFPDEDEEC.Items.Add("Comercio y Servicios");
                this.cboFPDEDEEC.Items.Add("Industria");
                this.cboFPDEDEEC.Items.Add("Institucional");
                this.cboFPDEDEEC.Items.Add("Recreativo y Deportivo");
                this.cboFPDEDEEC.Items.Add("Agropecuario");
                this.cboFPDEDEEC.Items.Add("Minero");
                this.cboFPDEDEEC.Items.Add("Infraestructura");
                this.cboFPDEDEEC.Items.Add("Mixto");

                this.cboFPDEDEEC.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al inicializar controles: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void pro_LimpiarCampos()
        {
            try
            {
                this.cboFPDEDEEC.SelectedIndex = -1;
                this.txtFPDEPERC.Clear();
                if (this.cboFPDEESTA.Items.Count > 0)
                {
                    this.cboFPDEESTA.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al limpiar campos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void pro_ReconsultarDestinoEconomico()
        {
            try
            {
                // TODO: Implementar cuando migremos las reglas de negocio
                // var objdatos = new cla_FIPRDEEC();
                // var datos = objdatos.fun_Consultar_FIPRDEEC(vp_FichaPredial);

                // Por ahora, datos de ejemplo
                var datos = new DataTable();
                datos.Columns.Add("ID", typeof(int));
                datos.Columns.Add("FichaPredial", typeof(int));
                datos.Columns.Add("DestinacionEconomica", typeof(string));
                datos.Columns.Add("Porcentaje", typeof(decimal));
                datos.Columns.Add("Estado", typeof(string));

                datos.Rows.Add(1, VariablesPublicas.vp_FichaPredial, "Vivienda Familiar", 70.0, "Activo");
                datos.Rows.Add(2, VariablesPublicas.vp_FichaPredial, "Comercio y Servicios", 30.0, "Activo");

                this.BindingSource_FIPRDEEC_1.DataSource = datos;
                this.dgvFIPRDEEC.DataSource = this.BindingSource_FIPRDEEC_1.DataSource;
                this.BindingNavigator_FIPRDEEC_1.BindingSource = this.BindingSource_FIPRDEEC_1;

                // Ocultar columnas sensibles
                if (this.dgvFIPRDEEC.Columns.Count > 0)
                {
                    this.dgvFIPRDEEC.Columns[0].Visible = false;
                    this.dgvFIPRDEEC.Columns[1].Visible = false;
                }

                this.lblRegistros.Text = $"Registros: {this.BindingSource_FIPRDEEC_1.Count}";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al reconsultar destinación económica: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void pro_NumeroDeSecuenciaDeRegistro()
        {
            try
            {
                // TODO: Implementar cuando migremos las reglas de negocio
                // var objdatos5 = new cla_FIPRDEEC();
                // var tbl10 = objdatos5.fun_Buscar_NRO_SECUENCIA_FIPRDEEC_X_FICHA_PREDIAL(vp_FichaPredial);

                // Por ahora, simular secuencia
                int inFPDESECU = 1; // Por defecto
                this.txtFPDECODI.Text = inFPDESECU.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al obtener número de secuencia: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void pro_Sumar_Porcentaje()
        {
            try
            {
                // TODO: Implementar cuando migremos las reglas de negocio
                // Sumar porcentajes de todas las destinaciones económicas
                decimal totalPorcentaje = 0.0m;
                
                if (this.BindingSource_FIPRDEEC_1.DataSource is DataTable dt)
                {
                    foreach (DataRow row in dt.Rows)
                    {
                        if (decimal.TryParse(row["Porcentaje"].ToString(), out decimal porcentaje))
                        {
                            totalPorcentaje += porcentaje;
                        }
                    }
                }

                // Mostrar total en el status bar
                this.lblRegistros.Text = $"Registros: {this.BindingSource_FIPRDEEC_1.Count} | Total %: {totalPorcentaje:F1}%";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al sumar porcentaje: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        #region Eventos

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidarCampos())
                {
                    // TODO: Implementar guardado real cuando migremos las reglas de negocio
                    MessageBox.Show("Destinación económica guardada exitosamente", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    pro_ReconsultarDestinoEconomico();
                    pro_LimpiarCampos();
                    pro_NumeroDeSecuenciaDeRegistro();
                    pro_Sumar_Porcentaje();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al guardar: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private bool ValidarCampos()
        {
            if (this.cboFPDEDEEC.SelectedItem == null)
            {
                MessageBox.Show("Debe seleccionar una destinación económica", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.cboFPDEDEEC.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(this.txtFPDEPERC.Text))
            {
                MessageBox.Show("Debe ingresar el porcentaje de la destinación económica", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.txtFPDEPERC.Focus();
                return false;
            }

            if (!decimal.TryParse(this.txtFPDEPERC.Text, out decimal porcentaje) || porcentaje <= 0 || porcentaje > 100)
            {
                MessageBox.Show("El porcentaje debe ser un número válido entre 0 y 100", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.txtFPDEPERC.Focus();
                return false;
            }

            return true;
        }

        #endregion
    }
} 