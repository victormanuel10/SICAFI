using System;
using System.Data;
using System.Windows.Forms;
using SICAFI.Datos;
using Microsoft.Data.SqlClient;

namespace SICAFI.App.Forms.ImpuestoPredial
{
    public partial class FrmImpuestoPredial : Form
    {
        //============================
        //*** IMPUESTO PREDIAL ***
        //============================

        #region Variables

        private DataGridView dgvImpuestoPredial;
        private BindingNavigator BindingNavigator_ImpuestoPredial_1;
        private BindingSource BindingSource_ImpuestoPredial_1;
        private TextBox txtFichaPredial;
        private TextBox txtPropietario;
        private ComboBox cboPeriodo;
        private ComboBox cboEstado;
        private Button btnBuscar;
        private Button btnLiquidar;
        private Button btnConsultar;
        private Button btnLimpiar;
        private StatusStrip strBarraEstado;
        private ToolStripStatusLabel lblRegistros;

        #endregion

        #region Constructor

        public FrmImpuestoPredial()
        {
            InitializeComponent();
            InitializeForm();
        }

        #endregion

        #region Inicialización

        private void InitializeComponent()
        {
            // Configurar formulario
            this.Text = "SICAFI - Gestión de Impuesto Predial";
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
            this.BindingSource_ImpuestoPredial_1 = new BindingSource();

            // Crear BindingNavigator
            this.BindingNavigator_ImpuestoPredial_1 = new BindingNavigator();
            this.BindingNavigator_ImpuestoPredial_1.Dock = DockStyle.Top;

            // Crear DataGridView
            this.dgvImpuestoPredial = new DataGridView();
            this.dgvImpuestoPredial.Dock = DockStyle.Fill;
            this.dgvImpuestoPredial.AllowUserToAddRows = false;
            this.dgvImpuestoPredial.AllowUserToDeleteRows = false;
            this.dgvImpuestoPredial.ReadOnly = true;
            this.dgvImpuestoPredial.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dgvImpuestoPredial.MultiSelect = false;
            this.dgvImpuestoPredial.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            // Crear controles de filtro
            this.txtFichaPredial = new TextBox();
            this.txtFichaPredial.Size = new System.Drawing.Size(150, 25);
            this.txtFichaPredial.PlaceholderText = "Ficha Predial";

            this.txtPropietario = new TextBox();
            this.txtPropietario.Size = new System.Drawing.Size(200, 25);
            this.txtPropietario.PlaceholderText = "Propietario";

            this.cboPeriodo = new ComboBox();
            this.cboPeriodo.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cboPeriodo.Size = new System.Drawing.Size(100, 25);

            this.cboEstado = new ComboBox();
            this.cboEstado.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cboEstado.Size = new System.Drawing.Size(120, 25);

            // Crear botones
            this.btnBuscar = new Button();
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.Size = new System.Drawing.Size(80, 30);
            this.btnBuscar.Click += new EventHandler(BtnBuscar_Click);

            this.btnLiquidar = new Button();
            this.btnLiquidar.Text = "Liquidar";
            this.btnLiquidar.Size = new System.Drawing.Size(80, 30);
            this.btnLiquidar.Click += new EventHandler(BtnLiquidar_Click);

            this.btnConsultar = new Button();
            this.btnConsultar.Text = "Consultar";
            this.btnConsultar.Size = new System.Drawing.Size(80, 30);
            this.btnConsultar.Click += new EventHandler(BtnConsultar_Click);

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
                Height = 100,
                BackColor = System.Drawing.Color.LightGray
            };

            // Labels
            Label lblFichaPredial = new Label
            {
                Text = "Ficha Predial:",
                Location = new System.Drawing.Point(20, 20),
                Size = new System.Drawing.Size(100, 20)
            };

            Label lblPropietario = new Label
            {
                Text = "Propietario:",
                Location = new System.Drawing.Point(20, 50),
                Size = new System.Drawing.Size(100, 20)
            };

            Label lblPeriodo = new Label
            {
                Text = "Período:",
                Location = new System.Drawing.Point(200, 20),
                Size = new System.Drawing.Size(100, 20)
            };

            Label lblEstado = new Label
            {
                Text = "Estado:",
                Location = new System.Drawing.Point(200, 50),
                Size = new System.Drawing.Size(100, 20)
            };

            // Posicionar controles
            this.txtFichaPredial.Location = new System.Drawing.Point(130, 18);
            this.txtPropietario.Location = new System.Drawing.Point(130, 48);
            this.cboPeriodo.Location = new System.Drawing.Point(310, 18);
            this.cboEstado.Location = new System.Drawing.Point(310, 48);

            // Posicionar botones
            this.btnBuscar.Location = new System.Drawing.Point(450, 18);
            this.btnLiquidar.Location = new System.Drawing.Point(540, 18);
            this.btnConsultar.Location = new System.Drawing.Point(450, 48);
            this.btnLimpiar.Location = new System.Drawing.Point(540, 48);

            // Agregar controles al panel de filtros
            filterPanel.Controls.AddRange(new Control[] { 
                lblFichaPredial, lblPropietario, lblPeriodo, lblEstado,
                this.txtFichaPredial, this.txtPropietario, this.cboPeriodo, this.cboEstado,
                this.btnBuscar, this.btnLiquidar, this.btnConsultar, this.btnLimpiar
            });

            // Agregar controles al panel principal
            mainPanel.Controls.Add(this.dgvImpuestoPredial);
            mainPanel.Controls.Add(filterPanel);

            // Agregar controles al formulario
            this.Controls.Add(this.BindingNavigator_ImpuestoPredial_1);
            this.Controls.Add(mainPanel);
            this.Controls.Add(this.strBarraEstado);
        }

        private void InitializeForm()
        {
            // Cargar datos iniciales
            LoadPeriodos();
            LoadEstados();
            LoadData();
        }

        #endregion

        #region Métodos

        private void LoadPeriodos()
        {
            try
            {
                this.cboPeriodo.Items.Clear();
                int currentYear = DateTime.Now.Year;
                
                // Agregar últimos 5 años
                for (int i = currentYear; i >= currentYear - 4; i--)
                {
                    this.cboPeriodo.Items.Add(i.ToString());
                }
                
                this.cboPeriodo.SelectedIndex = 0; // Año actual
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar períodos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadEstados()
        {
            try
            {
                this.cboEstado.Items.Clear();
                this.cboEstado.Items.Add("Todos");
                this.cboEstado.Items.Add("Pendiente");
                this.cboEstado.Items.Add("Liquidado");
                this.cboEstado.Items.Add("Pagado");
                this.cboEstado.Items.Add("Vencido");
                this.cboEstado.SelectedIndex = 0; // Todos
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar estados: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadData()
        {
            try
            {
                // Datos de ejemplo
                var datos = new DataTable();
                datos.Columns.Add("ID", typeof(int));
                datos.Columns.Add("FichaPredial", typeof(string));
                datos.Columns.Add("Propietario", typeof(string));
                datos.Columns.Add("Periodo", typeof(string));
                datos.Columns.Add("Avaluo", typeof(decimal));
                datos.Columns.Add("Impuesto", typeof(decimal));
                datos.Columns.Add("Estado", typeof(string));

                datos.Rows.Add(1, "2024-001", "Juan Pérez", "2024", 50000000, 2500000, "Pendiente");
                datos.Rows.Add(2, "2024-002", "María García", "2024", 75000000, 3750000, "Liquidado");
                datos.Rows.Add(3, "2024-003", "Carlos López", "2024", 30000000, 1500000, "Pagado");

                this.BindingSource_ImpuestoPredial_1.DataSource = datos;
                this.dgvImpuestoPredial.DataSource = this.BindingSource_ImpuestoPredial_1;
                this.BindingNavigator_ImpuestoPredial_1.BindingSource = this.BindingSource_ImpuestoPredial_1;

                this.lblRegistros.Text = $"Registros: {datos.Rows.Count}";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar datos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BuscarImpuestos()
        {
            try
            {
                string fichaPredial = this.txtFichaPredial.Text.Trim();
                string propietario = this.txtPropietario.Text.Trim();
                string periodo = this.cboPeriodo.SelectedItem?.ToString() ?? "";
                string estado = this.cboEstado.SelectedItem?.ToString() ?? "";

                // TODO: Implementar búsqueda real cuando migremos las reglas de negocio
                // Por ahora, simulamos la búsqueda
                var datos = new DataTable();
                datos.Columns.Add("ID", typeof(int));
                datos.Columns.Add("FichaPredial", typeof(string));
                datos.Columns.Add("Propietario", typeof(string));
                datos.Columns.Add("Periodo", typeof(string));
                datos.Columns.Add("Avaluo", typeof(decimal));
                datos.Columns.Add("Impuesto", typeof(decimal));
                datos.Columns.Add("Estado", typeof(string));

                // Simular resultados de búsqueda
                if (!string.IsNullOrEmpty(fichaPredial))
                {
                    datos.Rows.Add(1, fichaPredial, "Propietario encontrado", periodo, 50000000, 2500000, "Pendiente");
                }
                else if (!string.IsNullOrEmpty(propietario))
                {
                    datos.Rows.Add(1, "2024-001", propietario, periodo, 50000000, 2500000, "Pendiente");
                }
                else
                {
                    datos.Rows.Add(1, "2024-001", "Juan Pérez", periodo, 50000000, 2500000, estado);
                    datos.Rows.Add(2, "2024-002", "María García", periodo, 75000000, 3750000, estado);
                }

                this.BindingSource_ImpuestoPredial_1.DataSource = datos;
                this.lblRegistros.Text = $"Registros: {datos.Rows.Count}";

                MessageBox.Show($"Búsqueda completada. Se encontraron {datos.Rows.Count} registros.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error en la búsqueda: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LiquidarImpuesto()
        {
            try
            {
                if (this.dgvImpuestoPredial.SelectedRows.Count > 0)
                {
                    var selectedRow = this.dgvImpuestoPredial.SelectedRows[0];
                    string fichaPredial = selectedRow.Cells["FichaPredial"].Value?.ToString() ?? "";

                    if (MessageBox.Show($"¿Está seguro de liquidar el impuesto para la ficha predial '{fichaPredial}'?", "Confirmar Liquidación", 
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        // TODO: Implementar liquidación real cuando migremos las reglas de negocio
                        MessageBox.Show($"Liquidación del impuesto para ficha predial '{fichaPredial}' completada exitosamente.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadData(); // Recargar datos
                    }
                }
                else
                {
                    MessageBox.Show("Debe seleccionar un registro para liquidar", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al liquidar impuesto: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        #region Eventos

        private void BtnBuscar_Click(object sender, EventArgs e)
        {
            BuscarImpuestos();
        }

        private void BtnLiquidar_Click(object sender, EventArgs e)
        {
            LiquidarImpuesto();
        }

        private void BtnConsultar_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.dgvImpuestoPredial.SelectedRows.Count > 0)
                {
                    var selectedRow = this.dgvImpuestoPredial.SelectedRows[0];
                    string fichaPredial = selectedRow.Cells["FichaPredial"].Value?.ToString() ?? "";
                    string propietario = selectedRow.Cells["Propietario"].Value?.ToString() ?? "";
                    decimal impuesto = Convert.ToDecimal(selectedRow.Cells["Impuesto"].Value ?? 0);

                    MessageBox.Show($"Detalles del Impuesto Predial:\n\n" +
                                  $"Ficha Predial: {fichaPredial}\n" +
                                  $"Propietario: {propietario}\n" +
                                  $"Impuesto: ${impuesto:N0}\n\n" +
                                  $"Función de consulta detallada - En desarrollo", "Consulta", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Debe seleccionar un registro para consultar", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al consultar: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnLimpiar_Click(object sender, EventArgs e)
        {
            this.txtFichaPredial.Clear();
            this.txtPropietario.Clear();
            this.cboPeriodo.SelectedIndex = 0;
            this.cboEstado.SelectedIndex = 0;
            LoadData();
        }

        #endregion
    }
} 