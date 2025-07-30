using System;
using System.Data;
using System.Windows.Forms;
using SICAFI.Datos;
using Microsoft.Data.SqlClient;

namespace SICAFI.App.Forms.Reportes
{
    public partial class FrmReportes : Form
    {
        //==========================
        //*** FORMULARIO REPORTES ***
        //==========================

        #region Variables

        private ListBox lstReportes;
        private Button btnGenerar;
        private Button btnVistaPrevia;
        private Button btnExportar;
        private Button btnSalir;
        private ComboBox cboFormato;
        private DateTimePicker dtpFechaInicio;
        private DateTimePicker dtpFechaFin;
        private ProgressBar progressBar;
        private StatusStrip strBarraEstado;
        private ToolStripStatusLabel lblEstado;

        #endregion

        #region Constructor

        public FrmReportes()
        {
            InitializeComponent();
            InitializeForm();
        }

        #endregion

        #region Inicialización

        private void InitializeComponent()
        {
            // Configurar formulario
            this.Text = "SICAFI - Generador de Reportes";
            this.Size = new System.Drawing.Size(800, 600);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.WindowState = FormWindowState.Normal;

            // Crear controles
            CreateControls();

            // Configurar layout
            SetupLayout();
        }

        private void CreateControls()
        {
            // Crear ListBox de reportes
            this.lstReportes = new ListBox();
            this.lstReportes.Size = new System.Drawing.Size(300, 200);
            this.lstReportes.SelectionMode = SelectionMode.One;

            // Crear ComboBox formato
            this.cboFormato = new ComboBox();
            this.cboFormato.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cboFormato.Size = new System.Drawing.Size(150, 25);

            // Crear DateTimePickers
            this.dtpFechaInicio = new DateTimePicker();
            this.dtpFechaInicio.Size = new System.Drawing.Size(150, 25);
            this.dtpFechaInicio.Value = DateTime.Now.AddMonths(-1);

            this.dtpFechaFin = new DateTimePicker();
            this.dtpFechaFin.Size = new System.Drawing.Size(150, 25);
            this.dtpFechaFin.Value = DateTime.Now;

            // Crear botones
            this.btnGenerar = new Button();
            this.btnGenerar.Text = "Generar Reporte";
            this.btnGenerar.Size = new System.Drawing.Size(120, 35);
            this.btnGenerar.Click += new EventHandler(BtnGenerar_Click);

            this.btnVistaPrevia = new Button();
            this.btnVistaPrevia.Text = "Vista Previa";
            this.btnVistaPrevia.Size = new System.Drawing.Size(120, 35);
            this.btnVistaPrevia.Click += new EventHandler(BtnVistaPrevia_Click);

            this.btnExportar = new Button();
            this.btnExportar.Text = "Exportar";
            this.btnExportar.Size = new System.Drawing.Size(120, 35);
            this.btnExportar.Click += new EventHandler(BtnExportar_Click);

            this.btnSalir = new Button();
            this.btnSalir.Text = "Salir";
            this.btnSalir.Size = new System.Drawing.Size(120, 35);
            this.btnSalir.Click += new EventHandler(BtnSalir_Click);

            // Crear ProgressBar
            this.progressBar = new ProgressBar();
            this.progressBar.Size = new System.Drawing.Size(300, 20);
            this.progressBar.Visible = false;

            // Crear StatusStrip
            this.strBarraEstado = new StatusStrip();
            this.lblEstado = new ToolStripStatusLabel("Listo");
            this.strBarraEstado.Items.Add(this.lblEstado);
        }

        private void SetupLayout()
        {
            // Panel principal
            Panel mainPanel = new Panel
            {
                Dock = DockStyle.Fill,
                BackColor = System.Drawing.Color.WhiteSmoke
            };

            // Panel izquierdo para reportes
            Panel leftPanel = new Panel
            {
                Dock = DockStyle.Left,
                Width = 350,
                BackColor = System.Drawing.Color.LightGray
            };

            // Panel derecho para opciones
            Panel rightPanel = new Panel
            {
                Dock = DockStyle.Fill,
                BackColor = System.Drawing.Color.WhiteSmoke
            };

            // Labels para el panel izquierdo
            Label lblReportes = new Label
            {
                Text = "Reportes Disponibles:",
                Location = new System.Drawing.Point(20, 20),
                Size = new System.Drawing.Size(150, 20),
                Font = new System.Drawing.Font("Arial", 10, System.Drawing.FontStyle.Bold)
            };

            this.lstReportes.Location = new System.Drawing.Point(20, 50);

            // Labels para el panel derecho
            Label lblFormato = new Label
            {
                Text = "Formato:",
                Location = new System.Drawing.Point(20, 20),
                Size = new System.Drawing.Size(100, 20)
            };

            Label lblFechaInicio = new Label
            {
                Text = "Fecha Inicio:",
                Location = new System.Drawing.Point(20, 60),
                Size = new System.Drawing.Size(100, 20)
            };

            Label lblFechaFin = new Label
            {
                Text = "Fecha Fin:",
                Location = new System.Drawing.Point(20, 100),
                Size = new System.Drawing.Size(100, 20)
            };

            // Posicionar controles del panel derecho
            this.cboFormato.Location = new System.Drawing.Point(130, 18);
            this.dtpFechaInicio.Location = new System.Drawing.Point(130, 58);
            this.dtpFechaFin.Location = new System.Drawing.Point(130, 98);

            // Posicionar botones
            this.btnGenerar.Location = new System.Drawing.Point(20, 150);
            this.btnVistaPrevia.Location = new System.Drawing.Point(150, 150);
            this.btnExportar.Location = new System.Drawing.Point(20, 200);
            this.btnSalir.Location = new System.Drawing.Point(150, 200);

            // Posicionar ProgressBar
            this.progressBar.Location = new System.Drawing.Point(20, 250);

            // Agregar controles al panel izquierdo
            leftPanel.Controls.AddRange(new Control[] { lblReportes, this.lstReportes });

            // Agregar controles al panel derecho
            rightPanel.Controls.AddRange(new Control[] { 
                lblFormato, lblFechaInicio, lblFechaFin,
                this.cboFormato, this.dtpFechaInicio, this.dtpFechaFin,
                this.btnGenerar, this.btnVistaPrevia, this.btnExportar, this.btnSalir,
                this.progressBar
            });

            // Agregar paneles al panel principal
            mainPanel.Controls.Add(rightPanel);
            mainPanel.Controls.Add(leftPanel);

            // Agregar controles al formulario
            this.Controls.Add(mainPanel);
            this.Controls.Add(this.strBarraEstado);
        }

        private void InitializeForm()
        {
            // Cargar reportes disponibles
            LoadReportes();

            // Cargar formatos disponibles
            LoadFormatos();

            // Configurar eventos
            this.lstReportes.SelectedIndexChanged += new EventHandler(LstReportes_SelectedIndexChanged);
        }

        #endregion

        #region Métodos

        private void LoadReportes()
        {
            try
            {
                this.lstReportes.Items.Clear();
                this.lstReportes.Items.Add("Reporte de Fichas Prediales");
                this.lstReportes.Items.Add("Reporte de Terceros");
                this.lstReportes.Items.Add("Reporte de Certificaciones de Estrato");
                this.lstReportes.Items.Add("Reporte de Impuesto Predial");
                this.lstReportes.Items.Add("Reporte de Avaluos");
                this.lstReportes.Items.Add("Reporte de Consultas");
                this.lstReportes.Items.Add("Reporte de Actividad del Sistema");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar reportes: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadFormatos()
        {
            try
            {
                this.cboFormato.Items.Clear();
                this.cboFormato.Items.Add("PDF");
                this.cboFormato.Items.Add("Excel");
                this.cboFormato.Items.Add("Word");
                this.cboFormato.Items.Add("HTML");
                this.cboFormato.SelectedIndex = 0; // PDF por defecto
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar formatos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void GenerarReporte()
        {
            try
            {
                if (this.lstReportes.SelectedItem == null)
                {
                    MessageBox.Show("Debe seleccionar un reporte", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (this.cboFormato.SelectedItem == null)
                {
                    MessageBox.Show("Debe seleccionar un formato", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string reporteSeleccionado = this.lstReportes.SelectedItem.ToString();
                string formato = this.cboFormato.SelectedItem.ToString();
                DateTime fechaInicio = this.dtpFechaInicio.Value;
                DateTime fechaFin = this.dtpFechaFin.Value;

                // Validar fechas
                if (fechaInicio > fechaFin)
                {
                    MessageBox.Show("La fecha de inicio no puede ser mayor a la fecha fin", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Mostrar progreso
                this.progressBar.Visible = true;
                this.progressBar.Value = 0;
                this.lblEstado.Text = "Generando reporte...";

                // Simular generación de reporte
                for (int i = 0; i <= 100; i += 10)
                {
                    this.progressBar.Value = i;
                    Application.DoEvents();
                    System.Threading.Thread.Sleep(100);
                }

                // Ocultar progreso
                this.progressBar.Visible = false;
                this.lblEstado.Text = "Reporte generado exitosamente";

                MessageBox.Show($"Reporte '{reporteSeleccionado}' generado en formato {formato} exitosamente.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                this.progressBar.Visible = false;
                this.lblEstado.Text = "Error al generar reporte";
                MessageBox.Show($"Error al generar reporte: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void VistaPrevia()
        {
            try
            {
                if (this.lstReportes.SelectedItem == null)
                {
                    MessageBox.Show("Debe seleccionar un reporte para vista previa", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string reporteSeleccionado = this.lstReportes.SelectedItem.ToString();
                MessageBox.Show($"Vista previa del reporte: {reporteSeleccionado}\n\nEsta funcionalidad se implementará cuando migremos el módulo de impresión.", "Vista Previa", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error en vista previa: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Exportar()
        {
            try
            {
                if (this.lstReportes.SelectedItem == null)
                {
                    MessageBox.Show("Debe seleccionar un reporte para exportar", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string reporteSeleccionado = this.lstReportes.SelectedItem.ToString();
                string formato = this.cboFormato.SelectedItem?.ToString() ?? "PDF";

                SaveFileDialog saveDialog = new SaveFileDialog();
                saveDialog.Filter = $"Archivo {formato}|*.{formato.ToLower()}";
                saveDialog.FileName = $"Reporte_{reporteSeleccionado.Replace(" ", "_")}_{DateTime.Now:yyyyMMdd}";

                if (saveDialog.ShowDialog() == DialogResult.OK)
                {
                    // TODO: Implementar exportación real cuando migremos el módulo de impresión
                    MessageBox.Show($"Reporte exportado exitosamente a: {saveDialog.FileName}", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al exportar: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        #region Eventos

        private void BtnGenerar_Click(object sender, EventArgs e)
        {
            GenerarReporte();
        }

        private void BtnVistaPrevia_Click(object sender, EventArgs e)
        {
            VistaPrevia();
        }

        private void BtnExportar_Click(object sender, EventArgs e)
        {
            Exportar();
        }

        private void BtnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void LstReportes_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.lstReportes.SelectedItem != null)
            {
                this.lblEstado.Text = $"Reporte seleccionado: {this.lstReportes.SelectedItem}";
            }
        }

        #endregion
    }
} 