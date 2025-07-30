using System;
using System.Data;
using System.Windows.Forms;
using SICAFI.Datos;
using Microsoft.Data.SqlClient;

namespace SICAFI.App.Forms.Consultas
{
    public partial class FrmConsultas : Form
    {
        //==========================
        //*** FORMULARIO CONSULTAS ***
        //==========================

        #region Variables

        private DataGridView dgvConsultas;
        private BindingNavigator BindingNavigator_Consultas_1;
        private ComboBox cboTipoConsulta;
        private TextBox txtFiltro;
        private Button btnBuscar;
        private Button btnLimpiar;
        private StatusStrip strBarraEstado;
        private ToolStripStatusLabel lblRegistros;

        #endregion

        #region Constructor

        public FrmConsultas()
        {
            InitializeComponent();
            InitializeForm();
        }

        #endregion

        #region Inicialización

        private void InitializeComponent()
        {
            // Configurar formulario
            this.Text = "SICAFI - Consultas Generales";
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
            this.BindingNavigator_Consultas_1 = new BindingNavigator();
            this.BindingNavigator_Consultas_1.Dock = DockStyle.Top;

            // Crear DataGridView
            this.dgvConsultas = new DataGridView();
            this.dgvConsultas.Dock = DockStyle.Fill;
            this.dgvConsultas.AllowUserToAddRows = false;
            this.dgvConsultas.AllowUserToDeleteRows = false;
            this.dgvConsultas.ReadOnly = true;
            this.dgvConsultas.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dgvConsultas.MultiSelect = false;
            this.dgvConsultas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            // Crear ComboBox Tipo Consulta
            this.cboTipoConsulta = new ComboBox();
            this.cboTipoConsulta.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cboTipoConsulta.Size = new System.Drawing.Size(200, 25);

            // Crear TextBox Filtro
            this.txtFiltro = new TextBox();
            this.txtFiltro.Size = new System.Drawing.Size(200, 25);

            // Crear botones
            this.btnBuscar = new Button();
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.Size = new System.Drawing.Size(80, 30);
            this.btnBuscar.Click += new EventHandler(BtnBuscar_Click);

            this.btnLimpiar = new Button();
            this.btnLimpiar.Text = "Limpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(80, 30);
            this.btnLimpiar.Click += new EventHandler(BtnLimpiar_Click);

            // Crear StatusStrip
            this.strBarraEstado = new StatusStrip();
            this.lblRegistros = new ToolStripStatusLabel("Registros: 0");
            this.strBarraEstado.Items.Add(this.lblRegistros);
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
                Height = 80,
                BackColor = System.Drawing.Color.LightGray
            };

            // Labels
            Label lblTipoConsulta = new Label
            {
                Text = "Tipo Consulta:",
                Location = new System.Drawing.Point(20, 20),
                Size = new System.Drawing.Size(100, 20)
            };

            Label lblFiltro = new Label
            {
                Text = "Filtro:",
                Location = new System.Drawing.Point(20, 50),
                Size = new System.Drawing.Size(100, 20)
            };

            // Posicionar controles
            this.cboTipoConsulta.Location = new System.Drawing.Point(130, 18);
            this.txtFiltro.Location = new System.Drawing.Point(130, 48);
            this.btnBuscar.Location = new System.Drawing.Point(350, 18);
            this.btnLimpiar.Location = new System.Drawing.Point(440, 18);

            // Agregar controles al panel de filtros
            filterPanel.Controls.AddRange(new Control[] { 
                lblTipoConsulta, lblFiltro, this.cboTipoConsulta, this.txtFiltro, 
                this.btnBuscar, this.btnLimpiar 
            });

            // Agregar controles al panel principal
            mainPanel.Controls.Add(this.dgvConsultas);
            mainPanel.Controls.Add(filterPanel);

            // Agregar controles al formulario
            this.Controls.Add(this.BindingNavigator_Consultas_1);
            this.Controls.Add(mainPanel);
            this.Controls.Add(this.strBarraEstado);
        }

        private void InitializeForm()
        {
            // Cargar tipos de consulta
            LoadTiposConsulta();

            // Cargar datos iniciales
            LoadData();
        }

        #endregion

        #region Métodos

        private void LoadTiposConsulta()
        {
            try
            {
                var tipos = new DataTable();
                tipos.Columns.Add("ID", typeof(int));
                tipos.Columns.Add("Descripcion", typeof(string));

                tipos.Rows.Add(1, "Ficha Predial");
                tipos.Rows.Add(2, "Terceros");
                tipos.Rows.Add(3, "Certificación de Estrato");
                tipos.Rows.Add(4, "Impuesto Predial");
                tipos.Rows.Add(5, "Avaluos");

                this.cboTipoConsulta.DataSource = tipos;
                this.cboTipoConsulta.DisplayMember = "Descripcion";
                this.cboTipoConsulta.ValueMember = "ID";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar tipos de consulta: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadData()
        {
            try
            {
                // Datos de ejemplo
                var datos = new DataTable();
                datos.Columns.Add("ID", typeof(int));
                datos.Columns.Add("Descripcion", typeof(string));
                datos.Columns.Add("Estado", typeof(string));
                datos.Columns.Add("Fecha", typeof(string));

                datos.Rows.Add(1, "Consulta de ejemplo 1", "Activo", "01/01/2024");
                datos.Rows.Add(2, "Consulta de ejemplo 2", "Activo", "02/01/2024");
                datos.Rows.Add(3, "Consulta de ejemplo 3", "Pendiente", "03/01/2024");

                this.dgvConsultas.DataSource = datos;
                this.lblRegistros.Text = $"Registros: {datos.Rows.Count}";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar datos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BuscarDatos()
        {
            try
            {
                if (this.cboTipoConsulta.SelectedItem == null)
                {
                    MessageBox.Show("Debe seleccionar un tipo de consulta", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string filtro = this.txtFiltro.Text.Trim();
                int tipoConsulta = Convert.ToInt32(this.cboTipoConsulta.SelectedValue);

                // TODO: Implementar búsqueda real cuando migremos las reglas de negocio
                // Por ahora, simulamos la búsqueda
                var datos = new DataTable();
                datos.Columns.Add("ID", typeof(int));
                datos.Columns.Add("Descripcion", typeof(string));
                datos.Columns.Add("Estado", typeof(string));
                datos.Columns.Add("Fecha", typeof(string));

                // Simular resultados de búsqueda
                if (string.IsNullOrEmpty(filtro))
                {
                    datos.Rows.Add(1, $"Consulta {tipoConsulta} - Resultado 1", "Activo", "01/01/2024");
                    datos.Rows.Add(2, $"Consulta {tipoConsulta} - Resultado 2", "Activo", "02/01/2024");
                }
                else
                {
                    datos.Rows.Add(1, $"Consulta {tipoConsulta} - {filtro}", "Activo", "01/01/2024");
                }

                this.dgvConsultas.DataSource = datos;
                this.lblRegistros.Text = $"Registros: {datos.Rows.Count}";

                MessageBox.Show($"Búsqueda completada. Se encontraron {datos.Rows.Count} registros.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error en la búsqueda: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        #region Eventos

        private void BtnBuscar_Click(object sender, EventArgs e)
        {
            BuscarDatos();
        }

        private void BtnLimpiar_Click(object sender, EventArgs e)
        {
            this.txtFiltro.Clear();
            this.cboTipoConsulta.SelectedIndex = -1;
            LoadData();
        }

        #endregion
    }
} 