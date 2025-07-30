using System;
using System.Data;
using System.Windows.Forms;
using System.IO;
using SICAFI.Datos;
using Microsoft.Data.SqlClient;

namespace SICAFI.App.Forms.CertificacionEstrato
{
    public partial class FrmCertEstrato : Form
    {
        //===============================================
        //*** CERTIFICACION DE ESTRATO SOCIOECONOMICO ***
        //===============================================

        #region Variables

        private bool boCONSULTA = false;

        private string vl_stRutaDocumentosTIF = "";
        private string vl_stRutaDocumentosPDF = "";

        private bool vl_boControlDeComandos = false;

        private SqlCommand oEjecutar = new SqlCommand();
        private SqlConnection oConexion = new SqlConnection();
        private SqlDataAdapter oAdapter = new SqlDataAdapter();
        private SqlDataReader? oReader;
        private DataSet ds = new DataSet();
        private DataTable dt = new DataTable();

        // Controles del formulario
        private DataGridView dgvCERTESSO;
        private BindingNavigator BindingNavigator_CERTESSO_1;
        private Button btnNuevo;
        private Button btnEditar;
        private Button btnEliminar;
        private Button btnConsultar;
        private Button btnSalir;

        #endregion

        #region Constructor

        public FrmCertEstrato()
        {
            InitializeComponent();
            InitializeForm();
        }

        public FrmCertEstrato(int idCodigo)
        {
            VariablesPublicas.vp_inConsulta = idCodigo;
            InitializeComponent();
            InitializeForm();
        }

        #endregion

        #region Inicialización

        private void InitializeComponent()
        {
            // Configurar formulario
            this.Text = "SICAFI - Certificación de Estrato Socioeconómico";
            this.Size = new System.Drawing.Size(1200, 800);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.WindowState = FormWindowState.Maximized;

            // Crear controles
            CreateControls();

            // Configurar layout
            SetupLayout();
        }

        private void CreateControls()
        {
            // Crear BindingNavigator
            this.BindingNavigator_CERTESSO_1 = new BindingNavigator();
            this.BindingNavigator_CERTESSO_1.Dock = DockStyle.Top;

            // Crear DataGridView
            this.dgvCERTESSO = new DataGridView();
            this.dgvCERTESSO.Dock = DockStyle.Fill;
            this.dgvCERTESSO.AllowUserToAddRows = false;
            this.dgvCERTESSO.AllowUserToDeleteRows = false;
            this.dgvCERTESSO.ReadOnly = true;
            this.dgvCERTESSO.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dgvCERTESSO.MultiSelect = false;
            this.dgvCERTESSO.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            // Crear botones
            this.btnNuevo = new Button();
            this.btnEditar = new Button();
            this.btnEliminar = new Button();
            this.btnConsultar = new Button();
            this.btnSalir = new Button();

            // Configurar botones
            this.btnNuevo.Text = "Nuevo";
            this.btnNuevo.Size = new System.Drawing.Size(80, 30);
            this.btnNuevo.Click += new EventHandler(BtnNuevo_Click);

            this.btnEditar.Text = "Editar";
            this.btnEditar.Size = new System.Drawing.Size(80, 30);
            this.btnEditar.Click += new EventHandler(BtnEditar_Click);

            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.Size = new System.Drawing.Size(80, 30);
            this.btnEliminar.Click += new EventHandler(BtnEliminar_Click);

            this.btnConsultar.Text = "Consultar";
            this.btnConsultar.Size = new System.Drawing.Size(80, 30);
            this.btnConsultar.Click += new EventHandler(BtnConsultar_Click);

            this.btnSalir.Text = "Salir";
            this.btnSalir.Size = new System.Drawing.Size(80, 30);
            this.btnSalir.Click += new EventHandler(BtnSalir_Click);
        }

        private void SetupLayout()
        {
            // Panel principal
            Panel mainPanel = new Panel
            {
                Dock = DockStyle.Fill,
                BackColor = System.Drawing.Color.WhiteSmoke
            };

            // Panel de botones
            Panel buttonPanel = new Panel
            {
                Dock = DockStyle.Bottom,
                Height = 50,
                BackColor = System.Drawing.Color.LightGray
            };

            // Layout de botones
            int buttonX = 20;
            int buttonY = 10;

            this.btnNuevo.Location = new System.Drawing.Point(buttonX, buttonY);
            buttonX += 100;

            this.btnEditar.Location = new System.Drawing.Point(buttonX, buttonY);
            buttonX += 100;

            this.btnEliminar.Location = new System.Drawing.Point(buttonX, buttonY);
            buttonX += 100;

            this.btnConsultar.Location = new System.Drawing.Point(buttonX, buttonY);
            buttonX += 100;

            this.btnSalir.Location = new System.Drawing.Point(buttonX, buttonY);

            // Agregar botones al panel
            buttonPanel.Controls.AddRange(new Control[] {
                this.btnNuevo, this.btnEditar, this.btnEliminar, this.btnConsultar, this.btnSalir
            });

            // Agregar controles al panel principal
            mainPanel.Controls.Add(this.dgvCERTESSO);
            mainPanel.Controls.Add(buttonPanel);

            // Agregar controles al formulario
            this.Controls.Add(this.BindingNavigator_CERTESSO_1);
            this.Controls.Add(mainPanel);
        }

        private void InitializeForm()
        {
            // Cargar datos iniciales
            LoadData();
        }

        #endregion

        #region Funciones

        private bool fun_VerificarCarpetaExistenteDocumentos()
        {
            try
            {
                string stRuta = "";
                string stCarpetaABuscar = "";

                // TODO: Implementar cuando migremos las reglas de negocio
                // var objRutas = new cla_RUTAS();
                // var tblRutas = objRutas.fun_Buscar_CODIGO_MANT_RUTAS(23);

                // Por ahora, validación simple
                if (this.dgvCERTESSO.SelectedRows.Count > 0)
                {
                    // stCarpetaABuscar = this.dgvCERTESSO.SelectedRows[0].Cells["CEESNURA"].Value.ToString() + "-" +
                    //                    this.dgvCERTESSO.SelectedRows[0].Cells["CEESFERA"].Value.ToString();

                    // Verificar si existe el directorio
                    if (Directory.Exists(stRuta + stCarpetaABuscar))
                    {
                        return true;
                    }
                }

                return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al verificar carpeta: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private void LoadData()
        {
            try
            {
                // TODO: Implementar cuando migremos las reglas de negocio
                // var objdatos = new cla_CERTESSO();
                // var tbl = objdatos.fun_Buscar_Todos_CERTESSO();

                // Por ahora, datos de ejemplo
                var dt = new DataTable();
                dt.Columns.Add("ID", typeof(int));
                dt.Columns.Add("Número Radicado", typeof(string));
                dt.Columns.Add("Fecha Radicado", typeof(string));
                dt.Columns.Add("Solicitante", typeof(string));
                dt.Columns.Add("Estado", typeof(string));

                dt.Rows.Add(1, "2024-001", "01/01/2024", "Juan Pérez", "Activo");
                dt.Rows.Add(2, "2024-002", "02/01/2024", "María García", "Activo");
                dt.Rows.Add(3, "2024-003", "03/01/2024", "Carlos López", "Pendiente");

                this.dgvCERTESSO.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar datos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        #region Eventos

        private void BtnNuevo_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Función Nuevo - En desarrollo", "SICAFI", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void BtnEditar_Click(object sender, EventArgs e)
        {
            if (this.dgvCERTESSO.SelectedRows.Count > 0)
            {
                MessageBox.Show("Función Editar - En desarrollo", "SICAFI", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Debe seleccionar un registro para editar", "SICAFI", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void BtnEliminar_Click(object sender, EventArgs e)
        {
            if (this.dgvCERTESSO.SelectedRows.Count > 0)
            {
                if (MessageBox.Show("¿Está seguro de eliminar el registro seleccionado?", "Confirmar", 
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    MessageBox.Show("Función Eliminar - En desarrollo", "SICAFI", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Debe seleccionar un registro para eliminar", "SICAFI", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void BtnConsultar_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Función Consultar - En desarrollo", "SICAFI", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void BtnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion
    }
} 