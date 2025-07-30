using System;
using System.Data;
using System.Windows.Forms;
using SICAFI.Datos;
using Microsoft.Data.SqlClient;

namespace SICAFI.App.Forms.Tercero
{
    public partial class FrmTercero : Form
    {
        //==========================
        //*** FORMULARIO TERCERO ***
        //==========================

        #region Variables

        private bool boCONSULTA = false;

        private string stNroDocumento = "";
        private string stRutaImagen = "";

        // Controles del formulario
        private DataGridView dgvTERCERO;
        private BindingNavigator BindingNavigator_TERCERO_1;
        private BindingSource BindingSource_TERCERO_1;
        private ComboBox cboTERCESTA;
        private StatusStrip strBARRESTA;
        private ToolStripStatusLabel lblRegistros;

        #endregion

        #region Constructor

        public FrmTercero()
        {
            InitializeComponent();
            InitializeForm();
        }

        public FrmTercero(int id)
        {
            VariablesPublicas.vp_inConsulta = id;
            InitializeComponent();
            InitializeForm();
        }

        #endregion

        #region Inicialización

        private void InitializeComponent()
        {
            // Configurar formulario
            this.Text = "SICAFI - Gestión de Terceros";
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
            // Crear BindingSource
            this.BindingSource_TERCERO_1 = new BindingSource();

            // Crear BindingNavigator
            this.BindingNavigator_TERCERO_1 = new BindingNavigator();
            this.BindingNavigator_TERCERO_1.Dock = DockStyle.Top;

            // Crear DataGridView
            this.dgvTERCERO = new DataGridView();
            this.dgvTERCERO.Dock = DockStyle.Fill;
            this.dgvTERCERO.AllowUserToAddRows = false;
            this.dgvTERCERO.AllowUserToDeleteRows = false;
            this.dgvTERCERO.ReadOnly = true;
            this.dgvTERCERO.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dgvTERCERO.MultiSelect = false;
            this.dgvTERCERO.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            // Crear ComboBox Estado
            this.cboTERCESTA = new ComboBox();
            this.cboTERCESTA.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cboTERCESTA.Size = new System.Drawing.Size(150, 25);

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

            // Panel superior para filtros
            Panel filterPanel = new Panel
            {
                Dock = DockStyle.Top,
                Height = 60,
                BackColor = System.Drawing.Color.LightGray
            };

            // Label para Estado
            Label lblEstado = new Label
            {
                Text = "Estado:",
                Location = new System.Drawing.Point(20, 20),
                Size = new System.Drawing.Size(50, 20)
            };

            // Posicionar ComboBox
            this.cboTERCESTA.Location = new System.Drawing.Point(80, 18);

            // Agregar controles al panel de filtros
            filterPanel.Controls.AddRange(new Control[] { lblEstado, this.cboTERCESTA });

            // Agregar controles al panel principal
            mainPanel.Controls.Add(this.dgvTERCERO);
            mainPanel.Controls.Add(filterPanel);

            // Agregar controles al formulario
            this.Controls.Add(this.BindingNavigator_TERCERO_1);
            this.Controls.Add(mainPanel);
            this.Controls.Add(this.strBARRESTA);
        }

        private void InitializeForm()
        {
            // Inicializar controles
            pro_inicializarControles();

            // Cargar datos
            pro_Reconsultar();
        }

        #endregion

        #region Procedimientos

        private void pro_inicializarControles()
        {
            try
            {
                // TODO: Implementar cuando migremos las reglas de negocio
                // var objdatos7 = new cla_ESTADO();
                // var estados = objdatos7.fun_Consultar_TODOS_LOS_ESTADOS();

                // Por ahora, datos de ejemplo
                var estados = new DataTable();
                estados.Columns.Add("ESTACODI", typeof(int));
                estados.Columns.Add("ESTADESC", typeof(string));

                estados.Rows.Add(1, "Activo");
                estados.Rows.Add(2, "Inactivo");
                estados.Rows.Add(3, "Suspendido");

                this.cboTERCESTA.DataSource = estados;
                this.cboTERCESTA.DisplayMember = "ESTADESC";
                this.cboTERCESTA.ValueMember = "ESTACODI";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al inicializar controles: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void pro_Reconsultar()
        {
            try
            {
                // TODO: Implementar cuando migremos las reglas de negocio
                // var objdatos = new cla_TERCERO();

                if (boCONSULTA == false)
                {
                    this.BindingSource_TERCERO_1.DataSource = new DataTable();
                }
                else if (boCONSULTA == true)
                {
                    // var datos = objdatos.fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_TERCERO(vp_inConsulta);
                    // this.BindingSource_TERCERO_1.DataSource = datos;

                    // Por ahora, datos de ejemplo
                    var datos = new DataTable();
                    datos.Columns.Add("ID", typeof(int));
                    datos.Columns.Add("Documento", typeof(string));
                    datos.Columns.Add("Nombres", typeof(string));
                    datos.Columns.Add("Apellidos", typeof(string));
                    datos.Columns.Add("Estado", typeof(string));

                    datos.Rows.Add(1, "12345678", "Juan", "Pérez", "Activo");
                    datos.Rows.Add(2, "87654321", "María", "García", "Activo");
                    datos.Rows.Add(3, "11223344", "Carlos", "López", "Inactivo");

                    this.BindingSource_TERCERO_1.DataSource = datos;

                    // Ocultar columnas sensibles
                    if (this.dgvTERCERO.Columns.Count > 0)
                    {
                        this.dgvTERCERO.Columns[0].Visible = false;
                        this.dgvTERCERO.Columns[1].Visible = false;
                        this.dgvTERCERO.Columns[2].Visible = false;
                        this.dgvTERCERO.Columns[3].Visible = false;
                        if (this.dgvTERCERO.Columns.Count > 8)
                            this.dgvTERCERO.Columns[8].Visible = false;
                    }
                }

                this.dgvTERCERO.DataSource = this.BindingSource_TERCERO_1;
                this.BindingNavigator_TERCERO_1.BindingSource = this.BindingSource_TERCERO_1;

                // Actualizar contador de registros
                this.lblRegistros.Text = $"Registros: {this.BindingSource_TERCERO_1.Count}";

                // Configurar permisos de la barra de menú
                int contarRegistros = this.BindingSource_TERCERO_1.Count;
                bool boCONTAGRE = false;
                bool boCONTMODI = false;
                bool boCONTELIM = false;
                bool boCONTCONS = false;
                bool boCONTRECO = false;

                pro_Permiso_Barra_De_Menu_Formulario_Formulario(contarRegistros, this.Name, boCONTAGRE, boCONTMODI, boCONTELIM, boCONTCONS, boCONTRECO);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al recargar datos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void pro_Permiso_Barra_De_Menu_Formulario_Formulario(int contarRegistros, string nombreFormulario, bool boCONTAGRE, bool boCONTMODI, bool boCONTELIM, bool boCONTCONS, bool boCONTRECO)
        {
            // TODO: Implementar permisos cuando migremos el sistema de seguridad
            // Por ahora, todos los botones están habilitados
        }

        #endregion
    }
} 