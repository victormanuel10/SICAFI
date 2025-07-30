using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using SICAFI.App.Forms.Shared;
using SICAFI.Datos;

namespace SICAFI.App.Forms.CertificacionEstrato
{
    public partial class FrmConsultarCertificaciones : Form
    {
        private DataTable dtCertificaciones;
        private ConsultasDB consultas;

        public FrmConsultarCertificaciones()
        {
            InitializeComponent();
            InitializeForm();
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();

            // Configurar formulario
            this.Text = "Consultar Certificaciones de Estrato";
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
            Label lblNumeroCertificacion = SicafiTheme.CreateLabel("Número de Certificación:");
            lblNumeroCertificacion.Location = new Point(20, 30);

            TextBox txtNumeroCertificacion = SicafiTheme.CreateTextBox();
            txtNumeroCertificacion.Location = new Point(180, 30);
            txtNumeroCertificacion.Name = "txtNumeroCertificacion";

            Label lblSolicitante = SicafiTheme.CreateLabel("Solicitante:");
            lblSolicitante.Location = new Point(20, 70);

            TextBox txtSolicitante = SicafiTheme.CreateTextBox();
            txtSolicitante.Location = new Point(180, 70);
            txtSolicitante.Name = "txtSolicitante";

            Label lblDireccion = SicafiTheme.CreateLabel("Dirección:");
            lblDireccion.Location = new Point(400, 30);

            TextBox txtDireccion = SicafiTheme.CreateTextBox();
            txtDireccion.Location = new Point(480, 30);
            txtDireccion.Name = "txtDireccion";

            Label lblEstrato = SicafiTheme.CreateLabel("Estrato:");
            lblEstrato.Location = new Point(400, 70);

            ComboBox cboEstrato = SicafiTheme.CreateComboBox();
            cboEstrato.Location = new Point(480, 70);
            cboEstrato.Name = "cboEstrato";
            cboEstrato.Items.AddRange(new object[] { "Todos", "1", "2", "3", "4", "5", "6" });
            cboEstrato.SelectedIndex = 0;

            // Botones
            Button btnBuscar = SicafiTheme.CreateButton("Buscar", true);
            btnBuscar.Location = new Point(700, 30);
            btnBuscar.Click += BtnBuscar_Click;

            Button btnLimpiar = SicafiTheme.CreateButton("Limpiar");
            btnLimpiar.Location = new Point(700, 70);
            btnLimpiar.Click += BtnLimpiar_Click;

            // Agregar controles al GroupBox
            gbFiltros.Controls.AddRange(new Control[] {
                lblNumeroCertificacion, txtNumeroCertificacion,
                lblSolicitante, txtSolicitante,
                lblDireccion, txtDireccion,
                lblEstrato, cboEstrato,
                btnBuscar, btnLimpiar
            });

            // DataGridView para resultados
            DataGridView dgvCertificaciones = SicafiTheme.CreateDataGridView();
            dgvCertificaciones.Location = new Point(10, 150);
            dgvCertificaciones.Size = new Size(950, 400);
            dgvCertificaciones.Name = "dgvCertificaciones";
            dgvCertificaciones.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvCertificaciones.MultiSelect = false;
            dgvCertificaciones.AllowUserToAddRows = false;
            dgvCertificaciones.AllowUserToDeleteRows = false;
            dgvCertificaciones.ReadOnly = true;
            dgvCertificaciones.DoubleClick += DgvCertificaciones_DoubleClick;

            // Configurar columnas
            dgvCertificaciones.Columns.Add("NumeroCertificacion", "Número de Certificación");
            dgvCertificaciones.Columns.Add("Solicitante", "Solicitante");
            dgvCertificaciones.Columns.Add("Direccion", "Dirección");
            dgvCertificaciones.Columns.Add("Estrato", "Estrato");
            dgvCertificaciones.Columns.Add("FechaSolicitud", "Fecha de Solicitud");
            dgvCertificaciones.Columns.Add("Estado", "Estado");

            // Botones de acción
            Button btnVerDetalle = SicafiTheme.CreateButton("Ver Detalle", true);
            btnVerDetalle.Location = new Point(10, 570);
            btnVerDetalle.Click += BtnVerDetalle_Click;

            Button btnImprimir = SicafiTheme.CreateButton("Imprimir");
            btnImprimir.Location = new Point(120, 570);
            btnImprimir.Click += BtnImprimir_Click;

            Button btnCerrar = SicafiTheme.CreateButton("Cerrar");
            btnCerrar.Location = new Point(880, 570);
            btnCerrar.Click += BtnCerrar_Click;

            // Agregar controles al panel principal
            mainPanel.Controls.AddRange(new Control[] {
                gbFiltros, dgvCertificaciones, btnVerDetalle, btnImprimir, btnCerrar
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
                dtCertificaciones = consultas.ConsultarCertificacionesEstrato();
                ActualizarGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar datos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ActualizarGrid()
        {
            DataGridView dgvCertificaciones = (DataGridView)this.Controls.Find("dgvCertificaciones", true)[0];
            dgvCertificaciones.DataSource = dtCertificaciones;
        }

        private void BtnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                TextBox txtNumeroCertificacion = (TextBox)this.Controls.Find("txtNumeroCertificacion", true)[0];
                TextBox txtSolicitante = (TextBox)this.Controls.Find("txtSolicitante", true)[0];
                TextBox txtDireccion = (TextBox)this.Controls.Find("txtDireccion", true)[0];
                ComboBox cboEstrato = (ComboBox)this.Controls.Find("cboEstrato", true)[0];

                // Buscar datos en la base de datos con los filtros
                dtCertificaciones = consultas.ConsultarCertificacionesEstrato(
                    txtNumeroCertificacion.Text.Trim(),
                    txtSolicitante.Text.Trim(),
                    txtDireccion.Text.Trim(),
                    cboEstrato.Text
                );

                DataGridView dgvCertificaciones = (DataGridView)this.Controls.Find("dgvCertificaciones", true)[0];
                dgvCertificaciones.DataSource = dtCertificaciones;
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
                TextBox txtNumeroCertificacion = (TextBox)this.Controls.Find("txtNumeroCertificacion", true)[0];
                TextBox txtSolicitante = (TextBox)this.Controls.Find("txtSolicitante", true)[0];
                TextBox txtDireccion = (TextBox)this.Controls.Find("txtDireccion", true)[0];
                ComboBox cboEstrato = (ComboBox)this.Controls.Find("cboEstrato", true)[0];

                txtNumeroCertificacion.Clear();
                txtSolicitante.Clear();
                txtDireccion.Clear();
                cboEstrato.SelectedIndex = 0;

                ActualizarGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al limpiar filtros: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DgvCertificaciones_DoubleClick(object sender, EventArgs e)
        {
            BtnVerDetalle_Click(sender, e);
        }

        private void BtnVerDetalle_Click(object sender, EventArgs e)
        {
            try
            {
                DataGridView dgvCertificaciones = (DataGridView)this.Controls.Find("dgvCertificaciones", true)[0];
                
                if (dgvCertificaciones.CurrentRow != null)
                {
                    string numeroCertificacion = dgvCertificaciones.CurrentRow.Cells["NumeroCertificacion"].Value?.ToString();
                    if (!string.IsNullOrEmpty(numeroCertificacion))
                    {
                        // Abrir formulario de detalle de certificación
                        using (var form = new FrmCertEstrato())
                        {
                            form.ShowDialog();
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Por favor seleccione una certificación para ver su detalle.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al abrir detalle: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnImprimir_Click(object sender, EventArgs e)
        {
            try
            {
                DataGridView dgvCertificaciones = (DataGridView)this.Controls.Find("dgvCertificaciones", true)[0];
                
                if (dgvCertificaciones.CurrentRow != null)
                {
                    string numeroCertificacion = dgvCertificaciones.CurrentRow.Cells["NumeroCertificacion"].Value?.ToString();
                    if (!string.IsNullOrEmpty(numeroCertificacion))
                    {
                        // Aquí se implementaría la lógica de impresión
                        MessageBox.Show($"Imprimiendo certificación {numeroCertificacion}...", "Impresión", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    MessageBox.Show("Por favor seleccione una certificación para imprimir.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al imprimir: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
} 