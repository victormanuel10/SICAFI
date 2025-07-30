using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using SICAFI.Datos;
using SICAFI.ReglasNegocio;
using SICAFI.App.Forms.Shared;

namespace SICAFI.App.Forms.FichaPredial.Linderos
{
    public class FrmInsertarLinderos : Form
    {
        private static FrmInsertarLinderos instance;
        
        // Controles del formulario - basados en el original VB
        private TextBox txtFichaPredial;
        private TextBox txtNroLindero;
        private ComboBox cboPuntoCardinal;
        private TextBox txtLongitud;
        private TextBox txtDescripcion;
        private ComboBox cboEstado;
        private Label lblSecuencia;
        
        private Button btnGuardar;
        private Button btnSalir;
        private DataGridView dgvLinderos;
        private BindingNavigator bindingNavigator;
        private StatusStrip statusStrip;
        private ToolStripStatusLabel lblRegistros;
        private ErrorProvider errorProvider;

        // Variables de contexto - basadas en el original VB
        private int fichaPredialId;
        private int resolucionId;
        private string departamento;
        private string municipio;
        private int resolucionTipo;
        private int resolucionClase;
        private int resolucionVigencia;
        private int resolucionResolucion;

        public static FrmInsertarLinderos Instance
        {
            get
            {
                if (instance == null || instance.IsDisposed)
                {
                    instance = new FrmInsertarLinderos();
                }
                return instance;
            }
        }

        public void InitializeWithContext(int fichaPredialId, int resolucionId, string departamento, 
                                        string municipio, int resolucionTipo, int resolucionClase, 
                                        int resolucionVigencia, int resolucionResolucion)
        {
            this.fichaPredialId = fichaPredialId;
            this.resolucionId = resolucionId;
            this.departamento = departamento;
            this.municipio = municipio;
            this.resolucionTipo = resolucionTipo;
            this.resolucionClase = resolucionClase;
            this.resolucionVigencia = resolucionVigencia;
            this.resolucionResolucion = resolucionResolucion;

            this.txtFichaPredial.Text = fichaPredialId.ToString();
            LoadData();
            GenerateNextSequenceNumber();
            ClearForm();
        }

        public FrmInsertarLinderos()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.Text = "INSERTAR LINDEROS";
            this.Size = new Size(900, 700);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.BackColor = Color.FromArgb(240, 240, 240);
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;

            // Aplicar tema SICAFI
            SicafiTheme.ApplyFormTheme(this);

            CreateControls();
            SetupLayout();
            LoadData();
        }

        private void CreateControls()
        {
            // Crear controles principales
            this.txtFichaPredial = SicafiTheme.CreateTextBox();
            this.txtFichaPredial.ReadOnly = true;
            
            this.txtNroLindero = SicafiTheme.CreateTextBox();
            this.cboPuntoCardinal = SicafiTheme.CreateComboBox();
            this.txtLongitud = SicafiTheme.CreateTextBox();
            this.txtDescripcion = SicafiTheme.CreateTextBox();
            this.cboEstado = SicafiTheme.CreateComboBox();
            
            // Label para secuencia
            this.lblSecuencia = SicafiTheme.CreateLabel("Secuencia: 1");
            this.lblSecuencia.Font = new Font("Arial", 10, FontStyle.Bold);
            this.lblSecuencia.ForeColor = Color.Blue;

            // Configurar ComboBoxes con datos del original
            this.cboPuntoCardinal.Items.AddRange(new object[] { 
                "NORTE", "SUR", "ESTE", "OESTE", "NORESTE", "NOROESTE", "SURESTE", "SUROESTE" 
            });
            this.cboEstado.Items.AddRange(new object[] { "ACTIVO", "INACTIVO", "SUSPENDIDO" });

            // Crear botones
            this.btnGuardar = SicafiTheme.CreateButton("Guardar", true);
            this.btnSalir = SicafiTheme.CreateButton("Salir");

            // Crear DataGridView
            this.dgvLinderos = SicafiTheme.CreateDataGridView();
            this.dgvLinderos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dgvLinderos.MultiSelect = false;

            // Crear BindingNavigator
            this.bindingNavigator = SicafiTheme.CreateBindingNavigator();

            // Crear StatusStrip
            this.statusStrip = SicafiTheme.CreateStatusStrip();
            this.lblRegistros = new ToolStripStatusLabel("Registros: 0");
            this.statusStrip.Items.Add(this.lblRegistros);

            // Crear ErrorProvider
            this.errorProvider = new ErrorProvider();
            this.errorProvider.ContainerControl = this;

            // Eventos
            this.btnGuardar.Click += BtnGuardar_Click;
            this.btnSalir.Click += BtnSalir_Click;
            this.dgvLinderos.SelectionChanged += DgvLinderos_SelectionChanged;
        }

        private void SetupLayout()
        {
            // Panel principal
            Panel mainPanel = SicafiTheme.CreateMainPanel();

            // Título
            Label lblTitulo = SicafiTheme.CreateLabel("INSERTAR LINDEROS", true);
            lblTitulo.Font = new Font("Arial", 14, FontStyle.Bold);
            lblTitulo.Location = new Point(20, 20);

            // Grupo principal de datos de linderos
            GroupBox gbDatosLinderos = SicafiTheme.CreateGroupBox("DATOS DE LOS LINDEROS", 850, 300);
            gbDatosLinderos.Location = new Point(20, 60);

            int yPos = 25;
            int xPos = 10;

            // Primera fila - Información básica
            gbDatosLinderos.Controls.Add(SicafiTheme.CreateLabel("Ficha Predial:"));
            gbDatosLinderos.Controls.Add(this.txtFichaPredial);
            gbDatosLinderos.Controls.Add(this.lblSecuencia);
            this.txtFichaPredial.Location = new Point(xPos + 120, yPos);
            this.txtFichaPredial.Size = new Size(100, 25);
            this.lblSecuencia.Location = new Point(xPos + 250, yPos);

            yPos += 35;
            gbDatosLinderos.Controls.Add(SicafiTheme.CreateLabel("Nro. Lindero:"));
            gbDatosLinderos.Controls.Add(this.txtNroLindero);
            gbDatosLinderos.Controls.Add(SicafiTheme.CreateLabel("Punto Cardinal:"));
            gbDatosLinderos.Controls.Add(this.cboPuntoCardinal);
            this.txtNroLindero.Location = new Point(xPos + 120, yPos);
            this.txtNroLindero.Size = new Size(100, 25);
            this.cboPuntoCardinal.Location = new Point(xPos + 350, yPos);
            this.cboPuntoCardinal.Size = new Size(150, 25);

            yPos += 35;
            gbDatosLinderos.Controls.Add(SicafiTheme.CreateLabel("Longitud (m):"));
            gbDatosLinderos.Controls.Add(this.txtLongitud);
            gbDatosLinderos.Controls.Add(SicafiTheme.CreateLabel("Estado:"));
            gbDatosLinderos.Controls.Add(this.cboEstado);
            this.txtLongitud.Location = new Point(xPos + 120, yPos);
            this.txtLongitud.Size = new Size(100, 25);
            this.cboEstado.Location = new Point(xPos + 350, yPos);
            this.cboEstado.Size = new Size(150, 25);

            yPos += 35;
            gbDatosLinderos.Controls.Add(SicafiTheme.CreateLabel("Descripción:"));
            gbDatosLinderos.Controls.Add(this.txtDescripcion);
            this.txtDescripcion.Location = new Point(xPos + 120, yPos);
            this.txtDescripcion.Size = new Size(500, 25);

            // Grupo de lista de linderos
            GroupBox gbListaLinderos = SicafiTheme.CreateGroupBox("LISTA DE LINDEROS", 850, 300);
            gbListaLinderos.Location = new Point(20, 380);

            this.dgvLinderos.Location = new Point(10, 25);
            this.dgvLinderos.Size = new Size(830, 240);

            // Botones
            this.btnGuardar.Location = new Point(680, 25);
            this.btnGuardar.Size = new Size(80, 35);
            this.btnSalir.Location = new Point(770, 25);
            this.btnSalir.Size = new Size(80, 35);

            gbListaLinderos.Controls.AddRange(new Control[] {
                this.dgvLinderos, this.btnGuardar, this.btnSalir
            });

            // Agregar controles al formulario
            this.Controls.Add(lblTitulo);
            this.Controls.Add(mainPanel);
            mainPanel.Controls.Add(gbDatosLinderos);
            mainPanel.Controls.Add(gbListaLinderos);
            this.Controls.Add(this.bindingNavigator);
            this.Controls.Add(this.statusStrip);
        }

        private void LoadData()
        {
            try
            {
                LoadLinderos();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar datos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadLinderos()
        {
            try
            {
                // TODO: Implementar cuando migremos las reglas de negocio
                // var objdatos = new cla_FIPRLIND();
                // var datos = objdatos.fun_Consultar_FIPRLIND(this.fichaPredialId);

                // Por ahora, datos de ejemplo basados en el original
                DataTable dt = new DataTable();
                dt.Columns.Add("FPLIIDRE", typeof(int)); // ID del lindero
                dt.Columns.Add("FPLINUFI", typeof(int)); // Ficha Predial
                dt.Columns.Add("FPLINUDO", typeof(int)); // Número Lindero
                dt.Columns.Add("FPLIPUCA", typeof(string)); // Punto Cardinal
                dt.Columns.Add("FPLILONG", typeof(decimal)); // Longitud
                dt.Columns.Add("FPLIDESC", typeof(string)); // Descripción
                dt.Columns.Add("FPLIESTA", typeof(string)); // Estado

                // Datos de ejemplo
                dt.Rows.Add(1, fichaPredialId, 1, "NORTE", 25.5m, "Lindero con calle principal", "ACTIVO");
                dt.Rows.Add(2, fichaPredialId, 2, "ESTE", 30.0m, "Lindero con propiedad vecina", "ACTIVO");
                dt.Rows.Add(3, fichaPredialId, 3, "SUR", 25.5m, "Lindero con calle secundaria", "ACTIVO");
                dt.Rows.Add(4, fichaPredialId, 4, "OESTE", 30.0m, "Lindero con propiedad vecina", "ACTIVO");

                this.dgvLinderos.DataSource = dt;
                this.lblRegistros.Text = $"Registros: {dt.Rows.Count}";

                // Ocultar columnas sensibles como en el original
                if (this.dgvLinderos.Columns.Count > 1)
                {
                    this.dgvLinderos.Columns[0].Visible = false; // FPLIIDRE
                    this.dgvLinderos.Columns[1].Visible = false; // FPLINUFI
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar linderos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void GenerateNextSequenceNumber()
        {
            try
            {
                // TODO: Implementar lógica real basada en el original VB
                // var objdatos5 = new cla_FIPRLIND();
                // var tbl10 = objdatos5.fun_Buscar_NRO_SECUENCIA_FIPRLIND_X_FICHA_PREDIAL(this.fichaPredialId);

                int nextNumber = 1;
                if (this.dgvLinderos.DataSource is DataTable dt && dt.Rows.Count > 0)
                {
                    // Buscar el número de lindero mayor
                    int maxNumber = 0;
                    foreach (DataRow row in dt.Rows)
                    {
                        if (row["FPLINUDO"] != DBNull.Value)
                        {
                            int number = Convert.ToInt32(row["FPLINUDO"]);
                            if (number > maxNumber)
                                maxNumber = number;
                        }
                    }
                    nextNumber = maxNumber + 1;
                }
                
                this.txtNroLindero.Text = nextNumber.ToString();
                this.lblSecuencia.Text = $"Secuencia: {nextNumber}";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al generar número de lindero: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidateForm())
                {
                    // TODO: Implementar guardado real cuando migremos las reglas de negocio
                    // var objdatos = new cla_FIPRLIND();
                    // var resultado = objdatos.fun_Insertar_FIPRLIND(...);

                    MessageBox.Show("Lindero insertado correctamente", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadLinderos();
                    ClearForm();
                    GenerateNextSequenceNumber();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al guardar: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void DgvLinderos_SelectionChanged(object sender, EventArgs e)
        {
            if (this.dgvLinderos.SelectedRows.Count > 0)
            {
                DataGridViewRow row = this.dgvLinderos.SelectedRows[0];
                LoadLinderoData(row);
            }
        }

        private void LoadLinderoData(DataGridViewRow row)
        {
            try
            {
                this.txtNroLindero.Text = row.Cells["FPLINUDO"].Value?.ToString() ?? "";
                this.cboPuntoCardinal.Text = row.Cells["FPLIPUCA"].Value?.ToString() ?? "";
                this.txtLongitud.Text = row.Cells["FPLILONG"].Value?.ToString() ?? "";
                this.txtDescripcion.Text = row.Cells["FPLIDESC"].Value?.ToString() ?? "";
                this.cboEstado.Text = row.Cells["FPLIESTA"].Value?.ToString() ?? "";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar datos del lindero: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool ValidateForm()
        {
            // Validaciones basadas en el original VB
            if (string.IsNullOrWhiteSpace(this.cboPuntoCardinal.Text))
            {
                this.errorProvider.SetError(this.cboPuntoCardinal, "El punto cardinal es obligatorio");
                MessageBox.Show("Debe seleccionar el punto cardinal", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.cboPuntoCardinal.Focus();
                return false;
            }
            this.errorProvider.SetError(this.cboPuntoCardinal, "");

            if (string.IsNullOrWhiteSpace(this.txtLongitud.Text))
            {
                MessageBox.Show("Debe ingresar la longitud", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.txtLongitud.Focus();
                return false;
            }

            if (!decimal.TryParse(this.txtLongitud.Text, out decimal longitud) || longitud <= 0)
            {
                MessageBox.Show("La longitud debe ser un número válido mayor a 0", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.txtLongitud.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(this.txtDescripcion.Text))
            {
                MessageBox.Show("Debe ingresar la descripción", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.txtDescripcion.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(this.cboEstado.Text))
            {
                MessageBox.Show("Debe seleccionar el estado", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.cboEstado.Focus();
                return false;
            }

            // Validar que no exista el código
            // TODO: Implementar validación de código existente como en el original VB

            return true;
        }

        private void ClearForm()
        {
            this.txtNroLindero.Clear();
            this.cboPuntoCardinal.SelectedIndex = -1;
            this.txtLongitud.Clear();
            this.txtDescripcion.Clear();
            this.cboEstado.SelectedIndex = -1;
            
            this.errorProvider.Clear();
            this.cboPuntoCardinal.Focus();
        }
    }
} 