using System;
using System.Data;
using System.Windows.Forms;
using SICAFI.Datos;
using Microsoft.Data.SqlClient;

namespace SICAFI.App.Forms.FichaPredial.ZonaFisica
{
    public partial class FrmInsertarZonaFisica : Form
    {
        //============================
        //*** INSERTAR ZONA FÍSICA ***
        //============================

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
        private TextBox txtFPZFCODI;
        private ComboBox cboFPZFZOFI;
        private TextBox txtFPZFPERC;
        private ComboBox cboFPZFESTA;
        private DataGridView dgvFIPRZOFI;
        private BindingNavigator BindingNavigator_FIPRZOFI_1;
        private BindingSource BindingSource_FIPRZOFI_1;
        private Button btnGuardar;
        private Button btnCancelar;
        private Button btnLimpiar;
        private StatusStrip strBARRESTA;
        private ToolStripStatusLabel lblRegistros;

        #endregion

        #region Constructor

        public FrmInsertarZonaFisica(int inFIPRNUFI, int inFIPRNURE, string stRESODEPA, 
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
            pro_ReconsultarZonaFisica();
            pro_Sumar_Porcentaje();
        }

        #endregion

        #region Inicialización

        private void InitializeComponent()
        {
            // Configurar formulario
            this.Text = "SICAFI - Insertar Zona Física";
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
            this.BindingSource_FIPRZOFI_1 = new BindingSource();

            // Crear BindingNavigator
            this.BindingNavigator_FIPRZOFI_1 = new BindingNavigator();
            this.BindingNavigator_FIPRZOFI_1.Dock = DockStyle.Top;

            // Crear DataGridView
            this.dgvFIPRZOFI = new DataGridView();
            this.dgvFIPRZOFI.Dock = DockStyle.Bottom;
            this.dgvFIPRZOFI.Height = 250;
            this.dgvFIPRZOFI.AllowUserToAddRows = false;
            this.dgvFIPRZOFI.AllowUserToDeleteRows = false;
            this.dgvFIPRZOFI.ReadOnly = true;
            this.dgvFIPRZOFI.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dgvFIPRZOFI.MultiSelect = false;
            this.dgvFIPRZOFI.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            // Crear TextBoxes
            this.txtFPZFCODI = new TextBox { Size = new System.Drawing.Size(100, 25), ReadOnly = true };
            this.txtFPZFPERC = new TextBox { Size = new System.Drawing.Size(100, 25) };

            // Crear ComboBoxes
            this.cboFPZFZOFI = new ComboBox { Size = new System.Drawing.Size(200, 25), DropDownStyle = ComboBoxStyle.DropDownList };
            this.cboFPZFESTA = new ComboBox { Size = new System.Drawing.Size(150, 25), DropDownStyle = ComboBoxStyle.DropDownList };

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
            Label lblZonaFisica = new Label { Text = "Zona Física:", Location = new System.Drawing.Point(20, 50), Size = new System.Drawing.Size(100, 20) };
            Label lblPorcentaje = new Label { Text = "Porcentaje (%):", Location = new System.Drawing.Point(20, 80), Size = new System.Drawing.Size(100, 20) };
            Label lblEstado = new Label { Text = "Estado:", Location = new System.Drawing.Point(20, 110), Size = new System.Drawing.Size(100, 20) };

            // Posicionar controles
            this.txtFPZFCODI.Location = new System.Drawing.Point(130, 18);
            this.cboFPZFZOFI.Location = new System.Drawing.Point(130, 48);
            this.txtFPZFPERC.Location = new System.Drawing.Point(130, 78);
            this.cboFPZFESTA.Location = new System.Drawing.Point(130, 108);

            // Posicionar botones
            this.btnGuardar.Location = new System.Drawing.Point(350, 18);
            this.btnCancelar.Location = new System.Drawing.Point(460, 18);
            this.btnLimpiar.Location = new System.Drawing.Point(570, 18);

            // Agregar controles al panel de formulario
            formPanel.Controls.AddRange(new Control[] { 
                lblCodigo, lblZonaFisica, lblPorcentaje, lblEstado,
                this.txtFPZFCODI, this.cboFPZFZOFI, this.txtFPZFPERC, this.cboFPZFESTA,
                this.btnGuardar, this.btnCancelar, this.btnLimpiar
            });

            // Agregar controles al panel principal
            mainPanel.Controls.Add(this.dgvFIPRZOFI);
            mainPanel.Controls.Add(formPanel);

            // Agregar controles al formulario
            this.Controls.Add(this.BindingNavigator_FIPRZOFI_1);
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

                this.cboFPZFESTA.DataSource = estados;
                this.cboFPZFESTA.DisplayMember = "ESTADESC";
                this.cboFPZFESTA.ValueMember = "ESTACODI";

                // Cargar zonas físicas
                this.cboFPZFZOFI.Items.Clear();
                this.cboFPZFZOFI.Items.Add("Residencial");
                this.cboFPZFZOFI.Items.Add("Comercial");
                this.cboFPZFZOFI.Items.Add("Industrial");
                this.cboFPZFZOFI.Items.Add("Institucional");
                this.cboFPZFZOFI.Items.Add("Recreativo");
                this.cboFPZFZOFI.Items.Add("Rural");
                this.cboFPZFZOFI.Items.Add("Mixto");

                this.cboFPZFZOFI.Focus();
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
                this.cboFPZFZOFI.SelectedIndex = -1;
                this.txtFPZFPERC.Clear();
                if (this.cboFPZFESTA.Items.Count > 0)
                {
                    this.cboFPZFESTA.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al limpiar campos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void pro_ReconsultarZonaFisica()
        {
            try
            {
                // TODO: Implementar cuando migremos las reglas de negocio
                // var objdatos = new cla_FIPRZOFI();
                // var datos = objdatos.fun_Consultar_FIPRZOFI(vp_FichaPredial);

                // Por ahora, datos de ejemplo
                var datos = new DataTable();
                datos.Columns.Add("ID", typeof(int));
                datos.Columns.Add("FichaPredial", typeof(int));
                datos.Columns.Add("ZonaFisica", typeof(string));
                datos.Columns.Add("Porcentaje", typeof(decimal));
                datos.Columns.Add("Estado", typeof(string));

                datos.Rows.Add(1, VariablesPublicas.vp_FichaPredial, "Residencial", 60.0, "Activo");
                datos.Rows.Add(2, VariablesPublicas.vp_FichaPredial, "Comercial", 40.0, "Activo");

                this.BindingSource_FIPRZOFI_1.DataSource = datos;
                this.dgvFIPRZOFI.DataSource = this.BindingSource_FIPRZOFI_1.DataSource;
                this.BindingNavigator_FIPRZOFI_1.BindingSource = this.BindingSource_FIPRZOFI_1;

                // Ocultar columnas sensibles
                if (this.dgvFIPRZOFI.Columns.Count > 0)
                {
                    this.dgvFIPRZOFI.Columns[0].Visible = false;
                    this.dgvFIPRZOFI.Columns[1].Visible = false;
                }

                this.lblRegistros.Text = $"Registros: {this.BindingSource_FIPRZOFI_1.Count}";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al reconsultar zona física: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void pro_NumeroDeSecuenciaDeRegistro()
        {
            try
            {
                // TODO: Implementar cuando migremos las reglas de negocio
                // var objdatos5 = new cla_FIPRZOFI();
                // var tbl10 = objdatos5.fun_Buscar_NRO_SECUENCIA_FIPRZOFI_X_FICHA_PREDIAL(vp_FichaPredial);

                // Por ahora, simular secuencia
                int inFPZFSECU = 1; // Por defecto
                this.txtFPZFCODI.Text = inFPZFSECU.ToString();
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
                // Sumar porcentajes de todas las zonas físicas
                decimal totalPorcentaje = 0.0m;
                
                if (this.BindingSource_FIPRZOFI_1.DataSource is DataTable dt)
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
                this.lblRegistros.Text = $"Registros: {this.BindingSource_FIPRZOFI_1.Count} | Total %: {totalPorcentaje:F1}%";
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
                    MessageBox.Show("Zona física guardada exitosamente", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    pro_ReconsultarZonaFisica();
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
            if (this.cboFPZFZOFI.SelectedItem == null)
            {
                MessageBox.Show("Debe seleccionar una zona física", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.cboFPZFZOFI.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(this.txtFPZFPERC.Text))
            {
                MessageBox.Show("Debe ingresar el porcentaje de la zona física", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.txtFPZFPERC.Focus();
                return false;
            }

            if (!decimal.TryParse(this.txtFPZFPERC.Text, out decimal porcentaje) || porcentaje <= 0 || porcentaje > 100)
            {
                MessageBox.Show("El porcentaje debe ser un número válido entre 0 y 100", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.txtFPZFPERC.Focus();
                return false;
            }

            return true;
        }

        #endregion
    }
} 