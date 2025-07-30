using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using SICAFI.App.Forms.Shared;
using SICAFI.Datos;

namespace SICAFI.App.Forms.Tercero
{
    public partial class FrmConsultarTerceros : Form
    {
        private DataTable dtTerceros;
        private ConsultasDB consultas;

        public FrmConsultarTerceros()
        {
            InitializeComponent();
            InitializeForm();
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();

            // Configurar formulario
            this.Text = "Consultar Terceros";
            this.Size = new Size(1000, 700);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;

            // Aplicar tema
            SicafiTheme.ApplyFormTheme(this);

            // Crear controles
            CreateControls();

            this.ResumeLayout(false);
        }

        private void CreateControls()
        {
            // Panel principal
            Panel mainPanel = new Panel
            {
                Dock = DockStyle.Fill,
                Padding = new Padding(10)
            };

            // GroupBox de filtros
            GroupBox gbFiltros = SicafiTheme.CreateGroupBox("Filtros de Búsqueda", 950, 120);
            gbFiltros.Location = new Point(10, 10);

            // Controles de filtros
            Label lblNumeroDocumento = SicafiTheme.CreateLabel("Número de Documento:");
            lblNumeroDocumento.Location = new Point(20, 30);

            TextBox txtNumeroDocumento = SicafiTheme.CreateTextBox();
            txtNumeroDocumento.Location = new Point(180, 30);
            txtNumeroDocumento.Name = "txtNumeroDocumento";

            Label lblNombre = SicafiTheme.CreateLabel("Nombre:");
            lblNombre.Location = new Point(20, 70);

            TextBox txtNombre = SicafiTheme.CreateTextBox();
            txtNombre.Location = new Point(180, 70);
            txtNombre.Name = "txtNombre";

            Label lblTipoDocumento = SicafiTheme.CreateLabel("Tipo de Documento:");
            lblTipoDocumento.Location = new Point(400, 30);

            ComboBox cboTipoDocumento = SicafiTheme.CreateComboBox();
            cboTipoDocumento.Location = new Point(520, 30);
            cboTipoDocumento.Name = "cboTipoDocumento";
            cboTipoDocumento.Items.AddRange(new object[] { "Todos", "CC", "CE", "NIT", "TI", "PP" });
            cboTipoDocumento.SelectedIndex = 0;

            Label lblEstado = SicafiTheme.CreateLabel("Estado:");
            lblEstado.Location = new Point(400, 70);

            ComboBox cboEstado = SicafiTheme.CreateComboBox();
            cboEstado.Location = new Point(520, 70);
            cboEstado.Name = "cboEstado";
            cboEstado.Items.AddRange(new object[] { "Todos", "Activo", "Inactivo" });
            cboEstado.SelectedIndex = 0;

            // Botones
            Button btnBuscar = SicafiTheme.CreateButton("Buscar", true);
            btnBuscar.Location = new Point(700, 30);
            btnBuscar.Click += BtnBuscar_Click;

            Button btnLimpiar = SicafiTheme.CreateButton("Limpiar");
            btnLimpiar.Location = new Point(700, 70);
            btnLimpiar.Click += BtnLimpiar_Click;

            // Agregar controles al GroupBox
            gbFiltros.Controls.AddRange(new Control[] {
                lblNumeroDocumento, txtNumeroDocumento,
                lblNombre, txtNombre,
                lblTipoDocumento, cboTipoDocumento,
                lblEstado, cboEstado,
                btnBuscar, btnLimpiar
            });

            // DataGridView para resultados
            DataGridView dgvTerceros = SicafiTheme.CreateDataGridView();
            dgvTerceros.Location = new Point(10, 150);
            dgvTerceros.Size = new Size(950, 400);
            dgvTerceros.Name = "dgvTerceros";
            dgvTerceros.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvTerceros.MultiSelect = false;
            dgvTerceros.AllowUserToAddRows = false;
            dgvTerceros.AllowUserToDeleteRows = false;
            dgvTerceros.ReadOnly = true;
            dgvTerceros.DoubleClick += DgvTerceros_DoubleClick;

            // Configurar columnas
            dgvTerceros.Columns.Add("NumeroDocumento", "Número de Documento");
            dgvTerceros.Columns.Add("TipoDocumento", "Tipo de Documento");
            dgvTerceros.Columns.Add("Nombre", "Nombre");
            dgvTerceros.Columns.Add("Direccion", "Dirección");
            dgvTerceros.Columns.Add("Telefono", "Teléfono");
            dgvTerceros.Columns.Add("Email", "Email");
            dgvTerceros.Columns.Add("Estado", "Estado");

            // Botones de acción
            Button btnVerDetalle = SicafiTheme.CreateButton("Ver Detalle", true);
            btnVerDetalle.Location = new Point(10, 570);
            btnVerDetalle.Click += BtnVerDetalle_Click;

            Button btnModificar = SicafiTheme.CreateButton("Modificar");
            btnModificar.Location = new Point(120, 570);
            btnModificar.Click += BtnModificar_Click;

            Button btnCerrar = SicafiTheme.CreateButton("Cerrar");
            btnCerrar.Location = new Point(880, 570);
            btnCerrar.Click += BtnCerrar_Click;

            // Agregar controles al panel principal
            mainPanel.Controls.AddRange(new Control[] {
                gbFiltros, dgvTerceros, btnVerDetalle, btnModificar, btnCerrar
            });

            this.Controls.Add(mainPanel);
        }

        private void InitializeForm()
        {
            consultas = new ConsultasDB();
            CargarDatosIniciales();
        }

        private void CargarDatosIniciales()
        {
            try
            {
                // Cargar datos desde la base de datos
                dtTerceros = consultas.ConsultarTerceros();
                ActualizarGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar datos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ActualizarGrid()
        {
            DataGridView dgvTerceros = (DataGridView)this.Controls.Find("dgvTerceros", true)[0];
            dgvTerceros.DataSource = dtTerceros;
        }

        private void BtnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                TextBox txtNumeroDocumento = (TextBox)this.Controls.Find("txtNumeroDocumento", true)[0];
                TextBox txtNombre = (TextBox)this.Controls.Find("txtNombre", true)[0];
                ComboBox cboTipoDocumento = (ComboBox)this.Controls.Find("cboTipoDocumento", true)[0];
                ComboBox cboEstado = (ComboBox)this.Controls.Find("cboEstado", true)[0];

                // Buscar datos en la base de datos con los filtros
                dtTerceros = consultas.ConsultarTerceros(
                    txtNumeroDocumento.Text.Trim(),
                    txtNombre.Text.Trim(),
                    cboTipoDocumento.Text,
                    cboEstado.Text
                );

                DataGridView dgvTerceros = (DataGridView)this.Controls.Find("dgvTerceros", true)[0];
                dgvTerceros.DataSource = dtTerceros;
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
                TextBox txtNumeroDocumento = (TextBox)this.Controls.Find("txtNumeroDocumento", true)[0];
                TextBox txtNombre = (TextBox)this.Controls.Find("txtNombre", true)[0];
                ComboBox cboTipoDocumento = (ComboBox)this.Controls.Find("cboTipoDocumento", true)[0];
                ComboBox cboEstado = (ComboBox)this.Controls.Find("cboEstado", true)[0];

                txtNumeroDocumento.Clear();
                txtNombre.Clear();
                cboTipoDocumento.SelectedIndex = 0;
                cboEstado.SelectedIndex = 0;

                ActualizarGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al limpiar filtros: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DgvTerceros_DoubleClick(object sender, EventArgs e)
        {
            BtnVerDetalle_Click(sender, e);
        }

        private void BtnVerDetalle_Click(object sender, EventArgs e)
        {
            try
            {
                DataGridView dgvTerceros = (DataGridView)this.Controls.Find("dgvTerceros", true)[0];
                
                if (dgvTerceros.CurrentRow != null)
                {
                    string numeroDocumento = dgvTerceros.CurrentRow.Cells["NumeroDocumento"].Value?.ToString();
                    if (!string.IsNullOrEmpty(numeroDocumento))
                    {
                        // Abrir formulario de detalle de tercero
                        using (var form = new FrmTercero())
                        {
                            form.ShowDialog();
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Por favor seleccione un tercero para ver su detalle.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                DataGridView dgvTerceros = (DataGridView)this.Controls.Find("dgvTerceros", true)[0];
                
                if (dgvTerceros.CurrentRow != null)
                {
                    string numeroDocumento = dgvTerceros.CurrentRow.Cells["NumeroDocumento"].Value?.ToString();
                    if (!string.IsNullOrEmpty(numeroDocumento))
                    {
                        // Abrir formulario de modificación de tercero
                        using (var form = new FrmTercero())
                        {
                            form.ShowDialog();
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Por favor seleccione un tercero para modificar.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
    }
} 