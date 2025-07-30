using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using SICAFI.App.Forms.Shared;
using SICAFI.Datos;
using System.Linq; // Added for .Where() and .ToArray()

namespace SICAFI.App.Forms.FichaPredial
{
    public partial class FrmConsultarFichaPredial : Form
    {
        // Declaraciones de controles
        private TextBox txtNumeroFicha;
        private TextBox txtDireccion;
        private TextBox txtMunicipio;
        private TextBox txtBarrio;
        private Button btnBuscar;
        private Button btnLimpiar;
        private Button btnVerDetalle;
        private Button btnModificar;
        private Button btnCerrar;
        private DataGridView dgvFichasPrediales;
        private StatusStrip statusStrip;
        private ToolStripStatusLabel lblRegistros;

        private DataTable dtFichasPrediales;
        private FichaPredialData fichaPredialData;

        public FrmConsultarFichaPredial()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.Text = "CONSULTAR FICHAS PREDIALES";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;

            // Aplicar tema SICAFI con tamaño específico para formularios de Ficha Predial
            SicafiTheme.ApplyFormTheme(this, FormSize.FichaPredial);

            CreateControls();
            SetupLayout();
            LoadData();
        }

        private void CreateControls()
        {
            // Crear controles de búsqueda con mejor diseño
            this.txtNumeroFicha = SicafiTheme.CreateTextBox(TextBoxSize.Small);
            this.txtDireccion = SicafiTheme.CreateTextBox(TextBoxSize.Standard);
            this.txtMunicipio = SicafiTheme.CreateTextBox(TextBoxSize.Small);
            this.txtBarrio = SicafiTheme.CreateTextBox(TextBoxSize.Small);

            // Crear botones con mejor diseño
            this.btnBuscar = new Button();
            this.btnBuscar.Text = "🔍 Buscar";
            this.btnBuscar.Size = new Size(100, 32);
            this.btnBuscar.FlatStyle = FlatStyle.Flat;
            this.btnBuscar.BackColor = Color.FromArgb(0, 122, 204);
            this.btnBuscar.ForeColor = Color.White;
            this.btnBuscar.Font = new Font("Segoe UI", 9, FontStyle.Bold);
            this.btnBuscar.Cursor = Cursors.Hand;
            this.btnBuscar.Click += BtnBuscar_Click;

            this.btnLimpiar = new Button();
            this.btnLimpiar.Text = "🧹 Limpiar";
            this.btnLimpiar.Size = new Size(100, 32);
            this.btnLimpiar.FlatStyle = FlatStyle.Flat;
            this.btnLimpiar.BackColor = Color.FromArgb(108, 117, 125);
            this.btnLimpiar.ForeColor = Color.White;
            this.btnLimpiar.Font = new Font("Segoe UI", 9, FontStyle.Bold);
            this.btnLimpiar.Cursor = Cursors.Hand;
            this.btnLimpiar.Click += BtnLimpiar_Click;

            this.btnVerDetalle = new Button();
            this.btnVerDetalle.Text = "👁️ Ver Detalle";
            this.btnVerDetalle.Size = new Size(120, 35);
            this.btnVerDetalle.FlatStyle = FlatStyle.Flat;
            this.btnVerDetalle.BackColor = Color.FromArgb(0, 200, 83);
            this.btnVerDetalle.ForeColor = Color.White;
            this.btnVerDetalle.Font = new Font("Segoe UI", 9, FontStyle.Bold);
            this.btnVerDetalle.Cursor = Cursors.Hand;
            this.btnVerDetalle.Click += BtnVerDetalle_Click;

            this.btnModificar = new Button();
            this.btnModificar.Text = "✏️ Modificar";
            this.btnModificar.Size = new Size(120, 35);
            this.btnModificar.FlatStyle = FlatStyle.Flat;
            this.btnModificar.BackColor = Color.FromArgb(255, 149, 0);
            this.btnModificar.ForeColor = Color.White;
            this.btnModificar.Font = new Font("Segoe UI", 9, FontStyle.Bold);
            this.btnModificar.Cursor = Cursors.Hand;
            this.btnModificar.Click += BtnModificar_Click;

            this.btnCerrar = new Button();
            this.btnCerrar.Text = "❌ Cerrar";
            this.btnCerrar.Size = new Size(120, 35);
            this.btnCerrar.FlatStyle = FlatStyle.Flat;
            this.btnCerrar.BackColor = Color.FromArgb(244, 67, 54);
            this.btnCerrar.ForeColor = Color.White;
            this.btnCerrar.Font = new Font("Segoe UI", 9, FontStyle.Bold);
            this.btnCerrar.Cursor = Cursors.Hand;
            this.btnCerrar.Click += BtnCerrar_Click;

            // Crear DataGridView con mejor diseño
            this.dgvFichasPrediales = new DataGridView();
            this.dgvFichasPrediales.BackgroundColor = Color.FromArgb(45, 45, 48);
            this.dgvFichasPrediales.BorderStyle = BorderStyle.None;
            this.dgvFichasPrediales.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvFichasPrediales.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            this.dgvFichasPrediales.EnableHeadersVisualStyles = false;
            this.dgvFichasPrediales.GridColor = Color.FromArgb(60, 60, 60);
            this.dgvFichasPrediales.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            this.dgvFichasPrediales.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dgvFichasPrediales.MultiSelect = false;
            this.dgvFichasPrediales.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(0, 122, 204);
            this.dgvFichasPrediales.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            this.dgvFichasPrediales.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9, FontStyle.Bold);
            this.dgvFichasPrediales.ColumnHeadersHeight = 35;
            this.dgvFichasPrediales.RowsDefaultCellStyle.BackColor = Color.FromArgb(45, 45, 48);
            this.dgvFichasPrediales.RowsDefaultCellStyle.ForeColor = Color.White;
            this.dgvFichasPrediales.RowsDefaultCellStyle.Font = new Font("Segoe UI", 9);
            this.dgvFichasPrediales.RowsDefaultCellStyle.SelectionBackColor = Color.FromArgb(0, 153, 255);
            this.dgvFichasPrediales.RowsDefaultCellStyle.SelectionForeColor = Color.White;
            this.dgvFichasPrediales.RowTemplate.Height = 25;
            this.dgvFichasPrediales.SelectionChanged += DgvFichasPrediales_SelectionChanged;
            this.dgvFichasPrediales.DoubleClick += DgvFichasPrediales_DoubleClick;

            // Crear StatusStrip
            this.statusStrip = SicafiTheme.CreateStatusStrip();
            this.lblRegistros = new ToolStripStatusLabel("Registros: 0");
            this.statusStrip.Items.Add(this.lblRegistros);
        }

        private void SetupLayout()
        {
            // Panel principal
            var mainPanel = new Panel();
            mainPanel.Dock = DockStyle.Fill;
            mainPanel.BackColor = Color.FromArgb(45, 45, 48);
            mainPanel.Padding = new Padding(15);

            // Título principal
            var lblTitulo = new Label();
            lblTitulo.Text = "CONSULTAR FICHAS PREDIALES";
            lblTitulo.Font = new Font("Segoe UI", 16, FontStyle.Bold);
            lblTitulo.ForeColor = Color.FromArgb(0, 153, 255);
            lblTitulo.Location = new Point(15, 15);
            lblTitulo.Size = new Size(400, 30);
            lblTitulo.BackColor = Color.Transparent;
            mainPanel.Controls.Add(lblTitulo);

            // Panel de búsqueda
            var panelBusqueda = new Panel();
            panelBusqueda.Location = new Point(15, 60);
            panelBusqueda.Size = new Size(850, 120);
            panelBusqueda.BackColor = Color.FromArgb(37, 37, 38);
            panelBusqueda.Padding = new Padding(15);

            var lblBusqueda = new Label();
            lblBusqueda.Text = "CRITERIOS DE BÚSQUEDA";
            lblBusqueda.Font = new Font("Segoe UI", 12, FontStyle.Bold);
            lblBusqueda.ForeColor = Color.FromArgb(0, 153, 255);
            lblBusqueda.Location = new Point(0, 0);
            lblBusqueda.Size = new Size(250, 25);
            lblBusqueda.BackColor = Color.Transparent;
            panelBusqueda.Controls.Add(lblBusqueda);

            // Configurar controles de búsqueda
            int yPos = 35;
            int xPos = 0;

            var lblNumeroFicha = new Label();
            lblNumeroFicha.Text = "Número de Ficha:";
            lblNumeroFicha.Font = new Font("Segoe UI", 9, FontStyle.Bold);
            lblNumeroFicha.ForeColor = Color.White;
            lblNumeroFicha.Location = new Point(xPos, yPos);
            lblNumeroFicha.Size = new Size(120, 25);
            lblNumeroFicha.BackColor = Color.Transparent;
            panelBusqueda.Controls.Add(lblNumeroFicha);

            this.txtNumeroFicha.Location = new Point(xPos + 130, yPos);
            this.txtNumeroFicha.Size = new Size(120, 28);
            panelBusqueda.Controls.Add(this.txtNumeroFicha);

            var lblDireccion = new Label();
            lblDireccion.Text = "Dirección:";
            lblDireccion.Font = new Font("Segoe UI", 9, FontStyle.Bold);
            lblDireccion.ForeColor = Color.White;
            lblDireccion.Location = new Point(xPos + 270, yPos);
            lblDireccion.Size = new Size(80, 25);
            lblDireccion.BackColor = Color.Transparent;
            panelBusqueda.Controls.Add(lblDireccion);

            this.txtDireccion.Location = new Point(xPos + 360, yPos);
            this.txtDireccion.Size = new Size(200, 28);
            panelBusqueda.Controls.Add(this.txtDireccion);

            yPos += 40;
            var lblMunicipio = new Label();
            lblMunicipio.Text = "Municipio:";
            lblMunicipio.Font = new Font("Segoe UI", 9, FontStyle.Bold);
            lblMunicipio.ForeColor = Color.White;
            lblMunicipio.Location = new Point(xPos, yPos);
            lblMunicipio.Size = new Size(80, 25);
            lblMunicipio.BackColor = Color.Transparent;
            panelBusqueda.Controls.Add(lblMunicipio);

            this.txtMunicipio.Location = new Point(xPos + 130, yPos);
            this.txtMunicipio.Size = new Size(120, 28);
            panelBusqueda.Controls.Add(this.txtMunicipio);

            var lblBarrio = new Label();
            lblBarrio.Text = "Barrio:";
            lblBarrio.Font = new Font("Segoe UI", 9, FontStyle.Bold);
            lblBarrio.ForeColor = Color.White;
            lblBarrio.Location = new Point(xPos + 270, yPos);
            lblBarrio.Size = new Size(80, 25);
            lblBarrio.BackColor = Color.Transparent;
            panelBusqueda.Controls.Add(lblBarrio);

            this.txtBarrio.Location = new Point(xPos + 360, yPos);
            this.txtBarrio.Size = new Size(200, 28);
            panelBusqueda.Controls.Add(this.txtBarrio);

            // Botón de búsqueda
            this.btnBuscar.Location = new Point(xPos + 580, yPos);
            panelBusqueda.Controls.Add(this.btnBuscar);

            // Botón de limpiar
            this.btnLimpiar.Location = new Point(xPos + 690, yPos);
            panelBusqueda.Controls.Add(this.btnLimpiar);

            mainPanel.Controls.Add(panelBusqueda);

            // Panel de resultados
            var panelResultados = new Panel();
            panelResultados.Location = new Point(15, 200);
            panelResultados.Size = new Size(850, 300);
            panelResultados.BackColor = Color.FromArgb(37, 37, 38);
            panelResultados.Padding = new Padding(15);

            var lblResultados = new Label();
            lblResultados.Text = "RESULTADOS DE LA BÚSQUEDA";
            lblResultados.Font = new Font("Segoe UI", 12, FontStyle.Bold);
            lblResultados.ForeColor = Color.FromArgb(0, 153, 255);
            lblResultados.Location = new Point(0, 0);
            lblResultados.Size = new Size(300, 25);
            lblResultados.BackColor = Color.Transparent;
            panelResultados.Controls.Add(lblResultados);

            // DataGridView
            this.dgvFichasPrediales.Location = new Point(0, 35);
            this.dgvFichasPrediales.Size = new Size(820, 230);
            panelResultados.Controls.Add(this.dgvFichasPrediales);

            mainPanel.Controls.Add(panelResultados);

            // Panel de botones
            var panelBotones = new Panel();
            panelBotones.Location = new Point(15, 520);
            panelBotones.Size = new Size(850, 50);
            panelBotones.BackColor = Color.Transparent;

            this.btnVerDetalle.Location = new Point(500, 0);
            panelBotones.Controls.Add(this.btnVerDetalle);

            this.btnModificar.Location = new Point(630, 0);
            panelBotones.Controls.Add(this.btnModificar);

            this.btnCerrar.Location = new Point(760, 0);
            panelBotones.Controls.Add(this.btnCerrar);

            mainPanel.Controls.Add(panelBotones);

            // Agregar controles al formulario
            this.Controls.Add(mainPanel);
            this.Controls.Add(this.statusStrip);
        }

        private void BtnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                // Buscar datos con los filtros ingresados
                string numeroFicha = this.txtNumeroFicha.Text.Trim();
                string municipio = this.txtMunicipio.Text.Trim();
                string direccion = this.txtDireccion.Text.Trim();
                string barrio = this.txtBarrio.Text.Trim();

                // Si no hay criterios de búsqueda, mostrar todos los datos
                if (string.IsNullOrEmpty(numeroFicha) && string.IsNullOrEmpty(municipio) && 
                    string.IsNullOrEmpty(direccion) && string.IsNullOrEmpty(barrio))
                {
                    dtFichasPrediales = fichaPredialData.ConsultarFichasPrediales();
                }
                else
                {
                    // Buscar con filtros
                    dtFichasPrediales = fichaPredialData.ConsultarFichasPrediales(numeroFicha, municipio, direccion, barrio);
                }

                this.dgvFichasPrediales.DataSource = dtFichasPrediales;
                this.lblRegistros.Text = $"Registros: {dtFichasPrediales.Rows.Count}";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al buscar: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnLimpiar_Click(object sender, EventArgs e)
        {
            try
            {
                this.txtNumeroFicha.Clear();
                this.txtMunicipio.Clear();
                this.txtDireccion.Clear();
                this.txtBarrio.Clear();

                // Limpiar el grid y recargar datos originales
                this.dgvFichasPrediales.DataSource = dtFichasPrediales;
                this.lblRegistros.Text = $"Registros: {dtFichasPrediales.Rows.Count}";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al limpiar filtros: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DgvFichas_DoubleClick(object sender, EventArgs e)
        {
            BtnVerDetalle_Click(sender, e);
        }

        private void BtnVerDetalle_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.dgvFichasPrediales.SelectedRows.Count > 0)
                {
                    DataGridViewRow row = this.dgvFichasPrediales.SelectedRows[0];
                    int fichaPredialId = Convert.ToInt32(row.Cells["FIPRIDRE"].Value);
                    
                    // Abrir el formulario principal de Ficha Predial con el ID seleccionado
                    var form = FrmFichaPredialPrincipal.Instance;
                    form.InitializeWithContext(fichaPredialId);
                    form.Show();
                    form.BringToFront();
                }
                else
                {
                    MessageBox.Show("Debe seleccionar una ficha predial para ver el detalle", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al abrir detalle: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnModificar_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.dgvFichasPrediales.SelectedRows.Count > 0)
                {
                    DataGridViewRow row = this.dgvFichasPrediales.SelectedRows[0];
                    int fichaPredialId = Convert.ToInt32(row.Cells["FIPRIDRE"].Value);
                    
                    // Abrir el formulario de modificación de Ficha Predial
                    var form = new FrmModificarFichaPredial();
                    form.InitializeWithContext(fichaPredialId);
                    form.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Debe seleccionar una ficha predial para modificar", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al abrir modificación: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void LoadData()
        {
            try
            {
                // Inicializar la clase de datos
                fichaPredialData = new FichaPredialData();
                
                // Cargar datos desde la base de datos
                dtFichasPrediales = fichaPredialData.ConsultarFichasPrediales();
                
                this.dgvFichasPrediales.DataSource = dtFichasPrediales;
                this.lblRegistros.Text = $"Registros: {dtFichasPrediales.Rows.Count}";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar datos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DgvFichasPrediales_SelectionChanged(object sender, EventArgs e)
        {
            // Habilitar/deshabilitar botones según la selección
            bool hasSelection = this.dgvFichasPrediales.SelectedRows.Count > 0;
            this.btnVerDetalle.Enabled = hasSelection;
            this.btnModificar.Enabled = hasSelection;
        }

        private void DgvFichasPrediales_DoubleClick(object sender, EventArgs e)
        {
            // Al hacer doble clic en una fila, abrir el detalle
            BtnVerDetalle_Click(sender, e);
        }
    }
} 