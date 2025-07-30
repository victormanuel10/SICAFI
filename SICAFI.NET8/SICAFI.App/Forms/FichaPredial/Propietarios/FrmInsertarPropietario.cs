using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using SICAFI.Datos;
using SICAFI.ReglasNegocio;
using SICAFI.App.Forms.Shared;

namespace SICAFI.App.Forms.FichaPredial.Propietarios
{
    public class FrmInsertarPropietario : Form
    {
        private static FrmInsertarPropietario instance;
        
        // Controles del formulario - basados en el original VB
        private TextBox txtFichaPredial;
        private TextBox txtNroPropietario;
        private TextBox txtPrimerApellido;
        private TextBox txtSegundoApellido;
        private TextBox txtNombre;
        private ComboBox cboTipoDocumento;
        private TextBox txtDocumento;
        private ComboBox cboSexo;
        private ComboBox cboDepartamento;
        private ComboBox cboMunicipio;
        private ComboBox cboNotaria;
        private TextBox txtEscritura;
        private TextBox txtTomo;
        private TextBox txtFechaEscritura;
        private TextBox txtFechaRegistro;
        private TextBox txtDerecho;
        private ComboBox cboCapacidad;
        private TextBox txtSiglaComercial;
        private CheckBox chkGravamen;
        private ComboBox cboModoAdquisicion;
        private ComboBox cboEstado;
        private Label lblSecuencia;
        private Label lblTotalPorcentaje;
        
        private Button btnGuardar;
        private Button btnSalir;
        private DataGridView dgvPropietarios;
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
        private bool verificarDatoAlGuardar = true;
        private string modoAdquisicion;
        private int capacidadPropietario = 0;
        private double totalDerecho = 0.0;

        public static FrmInsertarPropietario Instance
        {
            get
            {
                if (instance == null || instance.IsDisposed)
                {
                    instance = new FrmInsertarPropietario();
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
            GenerateNextOwnerNumber();
            ClearForm();
            CalculateTotalPercentage();
        }

        public FrmInsertarPropietario()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.Text = "INSERTAR PROPIETARIO";
            this.Size = new Size(1200, 900);
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
            
            this.txtNroPropietario = SicafiTheme.CreateTextBox();
            this.txtPrimerApellido = SicafiTheme.CreateTextBox();
            this.txtSegundoApellido = SicafiTheme.CreateTextBox();
            this.txtNombre = SicafiTheme.CreateTextBox();
            
            // Documento e identificación
            this.cboTipoDocumento = SicafiTheme.CreateComboBox();
            this.txtDocumento = SicafiTheme.CreateTextBox();
            this.cboSexo = SicafiTheme.CreateComboBox();
            
            // Ubicación
            this.cboDepartamento = SicafiTheme.CreateComboBox();
            this.cboMunicipio = SicafiTheme.CreateComboBox();
            this.cboNotaria = SicafiTheme.CreateComboBox();
            
            // Información de escritura
            this.txtEscritura = SicafiTheme.CreateTextBox();
            this.txtTomo = SicafiTheme.CreateTextBox();
            this.txtFechaEscritura = SicafiTheme.CreateTextBox();
            this.txtFechaRegistro = SicafiTheme.CreateTextBox();
            
            // Derechos y capacidad
            this.txtDerecho = SicafiTheme.CreateTextBox();
            this.cboCapacidad = SicafiTheme.CreateComboBox();
            this.txtSiglaComercial = SicafiTheme.CreateTextBox();
            this.chkGravamen = new CheckBox();
            this.chkGravamen.Text = "Gravamen";
            this.chkGravamen.Font = SicafiTheme.NormalFont;
            
            // Modo de adquisición y estado
            this.cboModoAdquisicion = SicafiTheme.CreateComboBox();
            this.cboEstado = SicafiTheme.CreateComboBox();
            
            // Labels informativos
            this.lblSecuencia = SicafiTheme.CreateLabel("Secuencia: 1");
            this.lblSecuencia.Font = new Font("Arial", 10, FontStyle.Bold);
            this.lblSecuencia.ForeColor = Color.Blue;
            
            this.lblTotalPorcentaje = SicafiTheme.CreateLabel("Total %: 0.00");
            this.lblTotalPorcentaje.Font = new Font("Arial", 10, FontStyle.Bold);
            this.lblTotalPorcentaje.ForeColor = Color.Red;

            // Configurar ComboBoxes con datos del original
            this.cboTipoDocumento.Items.AddRange(new object[] { 
                "CC", "CE", "NIT", "TI", "PASAPORTE", "CÉDULA EXTRANJERÍA", "TARJETA IDENTIDAD" 
            });
            this.cboSexo.Items.AddRange(new object[] { "MASCULINO", "FEMENINO" });
            
            // Departamentos y municipios (ejemplo)
            this.cboDepartamento.Items.AddRange(new object[] { "ANTIOQUIA", "CUNDINAMARCA", "VALLE DEL CAUCA", "ATLÁNTICO" });
            this.cboMunicipio.Items.AddRange(new object[] { "MEDELLÍN", "BOGOTÁ", "CALI", "BARRANQUILLA" });
            this.cboNotaria.Items.AddRange(new object[] { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10" });
            
            this.cboCapacidad.Items.AddRange(new object[] { 
                "MAYOR DE EDAD", "MENOR DE EDAD", "INTERDICTO", "REPRESENTANTE LEGAL", "TUTOR" 
            });
            this.cboModoAdquisicion.Items.AddRange(new object[] { 
                "COMPRAVENTA", "HERENCIA", "DONACIÓN", "PERMUTA", "ADJUDICACIÓN", "OTROS" 
            });
            this.cboEstado.Items.AddRange(new object[] { "ACTIVO", "INACTIVO", "SUSPENDIDO" });

            // Crear botones
            this.btnGuardar = SicafiTheme.CreateButton("Guardar", true);
            this.btnSalir = SicafiTheme.CreateButton("Salir");

            // Crear DataGridView
            this.dgvPropietarios = SicafiTheme.CreateDataGridView();
            this.dgvPropietarios.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dgvPropietarios.MultiSelect = false;

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
            this.dgvPropietarios.SelectionChanged += DgvPropietarios_SelectionChanged;
            this.txtDerecho.TextChanged += TxtDerecho_TextChanged;
        }

        private void SetupLayout()
        {
            // Panel principal
            Panel mainPanel = SicafiTheme.CreateMainPanel();

            // Título
            Label lblTitulo = SicafiTheme.CreateLabel("INSERTAR PROPIETARIO", true);
            lblTitulo.Font = new Font("Arial", 14, FontStyle.Bold);
            lblTitulo.Location = new Point(20, 20);

            // Grupo principal de datos del propietario
            GroupBox gbDatosPropietario = SicafiTheme.CreateGroupBox("DATOS DEL PROPIETARIO", 1150, 600);
            gbDatosPropietario.Location = new Point(20, 60);

            int yPos = 25;
            int xPos = 10;

            // Primera fila - Información básica
            gbDatosPropietario.Controls.Add(SicafiTheme.CreateLabel("Ficha Predial:"));
            gbDatosPropietario.Controls.Add(this.txtFichaPredial);
            gbDatosPropietario.Controls.Add(this.lblSecuencia);
            gbDatosPropietario.Controls.Add(this.lblTotalPorcentaje);
            this.txtFichaPredial.Location = new Point(xPos + 120, yPos);
            this.txtFichaPredial.Size = new Size(100, 25);
            this.lblSecuencia.Location = new Point(xPos + 250, yPos);
            this.lblTotalPorcentaje.Location = new Point(xPos + 400, yPos);

            yPos += 35;
            gbDatosPropietario.Controls.Add(SicafiTheme.CreateLabel("Nro. Propietario:"));
            gbDatosPropietario.Controls.Add(this.txtNroPropietario);
            gbDatosPropietario.Controls.Add(SicafiTheme.CreateLabel("Primer Apellido:"));
            gbDatosPropietario.Controls.Add(this.txtPrimerApellido);
            this.txtNroPropietario.Location = new Point(xPos + 120, yPos);
            this.txtNroPropietario.Size = new Size(100, 25);
            this.txtPrimerApellido.Location = new Point(xPos + 350, yPos);
            this.txtPrimerApellido.Size = new Size(150, 25);

            yPos += 35;
            gbDatosPropietario.Controls.Add(SicafiTheme.CreateLabel("Segundo Apellido:"));
            gbDatosPropietario.Controls.Add(this.txtSegundoApellido);
            gbDatosPropietario.Controls.Add(SicafiTheme.CreateLabel("Nombre:"));
            gbDatosPropietario.Controls.Add(this.txtNombre);
            this.txtSegundoApellido.Location = new Point(xPos + 120, yPos);
            this.txtSegundoApellido.Size = new Size(150, 25);
            this.txtNombre.Location = new Point(xPos + 350, yPos);
            this.txtNombre.Size = new Size(150, 25);

            // Segunda sección - Documento e identificación
            yPos += 50;
            Label lblDocumento = SicafiTheme.CreateLabel("DOCUMENTO E IDENTIFICACIÓN", true);
            lblDocumento.Location = new Point(xPos, yPos);
            gbDatosPropietario.Controls.Add(lblDocumento);

            yPos += 30;
            gbDatosPropietario.Controls.Add(SicafiTheme.CreateLabel("Tipo Documento:"));
            gbDatosPropietario.Controls.Add(this.cboTipoDocumento);
            gbDatosPropietario.Controls.Add(SicafiTheme.CreateLabel("Número Documento:"));
            gbDatosPropietario.Controls.Add(this.txtDocumento);
            this.cboTipoDocumento.Location = new Point(xPos + 120, yPos);
            this.cboTipoDocumento.Size = new Size(150, 25);
            this.txtDocumento.Location = new Point(xPos + 350, yPos);
            this.txtDocumento.Size = new Size(150, 25);

            yPos += 35;
            gbDatosPropietario.Controls.Add(SicafiTheme.CreateLabel("Sexo:"));
            gbDatosPropietario.Controls.Add(this.cboSexo);
            this.cboSexo.Location = new Point(xPos + 120, yPos);
            this.cboSexo.Size = new Size(150, 25);

            // Tercera sección - Ubicación
            yPos += 50;
            Label lblUbicacion = SicafiTheme.CreateLabel("UBICACIÓN", true);
            lblUbicacion.Location = new Point(xPos, yPos);
            gbDatosPropietario.Controls.Add(lblUbicacion);

            yPos += 30;
            gbDatosPropietario.Controls.Add(SicafiTheme.CreateLabel("Departamento:"));
            gbDatosPropietario.Controls.Add(this.cboDepartamento);
            gbDatosPropietario.Controls.Add(SicafiTheme.CreateLabel("Municipio:"));
            gbDatosPropietario.Controls.Add(this.cboMunicipio);
            this.cboDepartamento.Location = new Point(xPos + 120, yPos);
            this.cboDepartamento.Size = new Size(150, 25);
            this.cboMunicipio.Location = new Point(xPos + 350, yPos);
            this.cboMunicipio.Size = new Size(150, 25);

            yPos += 35;
            gbDatosPropietario.Controls.Add(SicafiTheme.CreateLabel("Notaría:"));
            gbDatosPropietario.Controls.Add(this.cboNotaria);
            this.cboNotaria.Location = new Point(xPos + 120, yPos);
            this.cboNotaria.Size = new Size(100, 25);

            // Cuarta sección - Información de escritura
            yPos += 50;
            Label lblEscritura = SicafiTheme.CreateLabel("INFORMACIÓN DE ESCRITURA", true);
            lblEscritura.Location = new Point(xPos, yPos);
            gbDatosPropietario.Controls.Add(lblEscritura);

            yPos += 30;
            gbDatosPropietario.Controls.Add(SicafiTheme.CreateLabel("Escritura:"));
            gbDatosPropietario.Controls.Add(this.txtEscritura);
            gbDatosPropietario.Controls.Add(SicafiTheme.CreateLabel("Tomo:"));
            gbDatosPropietario.Controls.Add(this.txtTomo);
            this.txtEscritura.Location = new Point(xPos + 120, yPos);
            this.txtEscritura.Size = new Size(100, 25);
            this.txtTomo.Location = new Point(xPos + 350, yPos);
            this.txtTomo.Size = new Size(100, 25);

            yPos += 35;
            gbDatosPropietario.Controls.Add(SicafiTheme.CreateLabel("Fecha Escritura:"));
            gbDatosPropietario.Controls.Add(this.txtFechaEscritura);
            gbDatosPropietario.Controls.Add(SicafiTheme.CreateLabel("Fecha Registro:"));
            gbDatosPropietario.Controls.Add(this.txtFechaRegistro);
            this.txtFechaEscritura.Location = new Point(xPos + 120, yPos);
            this.txtFechaEscritura.Size = new Size(100, 25);
            this.txtFechaRegistro.Location = new Point(xPos + 350, yPos);
            this.txtFechaRegistro.Size = new Size(100, 25);

            // Quinta sección - Derechos y capacidad
            yPos += 50;
            Label lblDerechos = SicafiTheme.CreateLabel("DERECHOS Y CAPACIDAD", true);
            lblDerechos.Location = new Point(xPos, yPos);
            gbDatosPropietario.Controls.Add(lblDerechos);

            yPos += 30;
            gbDatosPropietario.Controls.Add(SicafiTheme.CreateLabel("Derecho (%):"));
            gbDatosPropietario.Controls.Add(this.txtDerecho);
            gbDatosPropietario.Controls.Add(SicafiTheme.CreateLabel("Capacidad:"));
            gbDatosPropietario.Controls.Add(this.cboCapacidad);
            this.txtDerecho.Location = new Point(xPos + 120, yPos);
            this.txtDerecho.Size = new Size(100, 25);
            this.cboCapacidad.Location = new Point(xPos + 350, yPos);
            this.cboCapacidad.Size = new Size(150, 25);

            yPos += 35;
            gbDatosPropietario.Controls.Add(SicafiTheme.CreateLabel("Sigla Comercial:"));
            gbDatosPropietario.Controls.Add(this.txtSiglaComercial);
            gbDatosPropietario.Controls.Add(this.chkGravamen);
            this.txtSiglaComercial.Location = new Point(xPos + 120, yPos);
            this.txtSiglaComercial.Size = new Size(100, 25);
            this.chkGravamen.Location = new Point(xPos + 350, yPos);

            // Sexta sección - Modo de adquisición y estado
            yPos += 50;
            Label lblAdquisicion = SicafiTheme.CreateLabel("MODO DE ADQUISICIÓN Y ESTADO", true);
            lblAdquisicion.Location = new Point(xPos, yPos);
            gbDatosPropietario.Controls.Add(lblAdquisicion);

            yPos += 30;
            gbDatosPropietario.Controls.Add(SicafiTheme.CreateLabel("Modo Adquisición:"));
            gbDatosPropietario.Controls.Add(this.cboModoAdquisicion);
            gbDatosPropietario.Controls.Add(SicafiTheme.CreateLabel("Estado:"));
            gbDatosPropietario.Controls.Add(this.cboEstado);
            this.cboModoAdquisicion.Location = new Point(xPos + 120, yPos);
            this.cboModoAdquisicion.Size = new Size(150, 25);
            this.cboEstado.Location = new Point(xPos + 350, yPos);
            this.cboEstado.Size = new Size(150, 25);

            // Grupo de lista de propietarios
            GroupBox gbListaPropietarios = SicafiTheme.CreateGroupBox("LISTA DE PROPIETARIOS", 1150, 200);
            gbListaPropietarios.Location = new Point(20, 680);

            this.dgvPropietarios.Location = new Point(10, 25);
            this.dgvPropietarios.Size = new Size(1130, 140);

            // Botones
            this.btnGuardar.Location = new Point(980, 25);
            this.btnGuardar.Size = new Size(80, 35);
            this.btnSalir.Location = new Point(1070, 25);
            this.btnSalir.Size = new Size(80, 35);

            gbListaPropietarios.Controls.AddRange(new Control[] {
                this.dgvPropietarios, this.btnGuardar, this.btnSalir
            });

            // Agregar controles al formulario
            this.Controls.Add(lblTitulo);
            this.Controls.Add(mainPanel);
            mainPanel.Controls.Add(gbDatosPropietario);
            mainPanel.Controls.Add(gbListaPropietarios);
            this.Controls.Add(this.bindingNavigator);
            this.Controls.Add(this.statusStrip);
        }

        private void LoadData()
        {
            try
            {
                LoadPropietarios();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar datos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadPropietarios()
        {
            try
            {
                // TODO: Implementar cuando migremos las reglas de negocio
                // var objdatos = new cla_FIPRPROP();
                // var datos = objdatos.fun_Consultar_FIPRPROP(this.fichaPredialId);

                // Por ahora, datos de ejemplo basados en el original
                DataTable dt = new DataTable();
                dt.Columns.Add("FPPRIDRE", typeof(int)); // ID del propietario
                dt.Columns.Add("FPPRNUFI", typeof(int)); // Ficha Predial
                dt.Columns.Add("FPPRNUDO", typeof(int)); // Número Propietario
                dt.Columns.Add("FPPRPRAP", typeof(string)); // Primer Apellido
                dt.Columns.Add("FPPRSEAP", typeof(string)); // Segundo Apellido
                dt.Columns.Add("FPPRNOMB", typeof(string)); // Nombre
                dt.Columns.Add("FPPRTIDO", typeof(string)); // Tipo Documento
                dt.Columns.Add("FPPRDOCU", typeof(string)); // Documento
                dt.Columns.Add("FPPRSEXO", typeof(string)); // Sexo
                dt.Columns.Add("FPPRDEPA", typeof(string)); // Departamento
                dt.Columns.Add("FPPRMUNI", typeof(string)); // Municipio
                dt.Columns.Add("FPPRNOTA", typeof(string)); // Notaría
                dt.Columns.Add("FPPRESCR", typeof(string)); // Escritura
                dt.Columns.Add("FPPRTOMO", typeof(string)); // Tomo
                dt.Columns.Add("FPPRFEES", typeof(string)); // Fecha Escritura
                dt.Columns.Add("FPPRFERE", typeof(string)); // Fecha Registro
                dt.Columns.Add("FPPRDERE", typeof(decimal)); // Derecho
                dt.Columns.Add("FPPRCAPR", typeof(string)); // Capacidad
                dt.Columns.Add("FPPRSICO", typeof(string)); // Sigla Comercial
                dt.Columns.Add("FPPRGRAV", typeof(bool)); // Gravamen
                dt.Columns.Add("FPPRMOAD", typeof(string)); // Modo Adquisición
                dt.Columns.Add("FPPRESTA", typeof(string)); // Estado

                // Datos de ejemplo
                dt.Rows.Add(1, fichaPredialId, 1, "GARCÍA", "LÓPEZ", "JUAN CARLOS", "CC", "12345678", "MASCULINO", "ANTIOQUIA", "MEDELLÍN", "1", "123", "A", "2020-01-15", "2020-01-20", 60.5m, "MAYOR DE EDAD", "", false, "COMPRAVENTA", "ACTIVO");
                dt.Rows.Add(2, fichaPredialId, 2, "RODRÍGUEZ", "MARTÍNEZ", "MARÍA ELENA", "CC", "87654321", "FEMENINO", "ANTIOQUIA", "MEDELLÍN", "2", "456", "B", "2020-02-10", "2020-02-15", 39.5m, "MAYOR DE EDAD", "", false, "COMPRAVENTA", "ACTIVO");

                this.dgvPropietarios.DataSource = dt;
                this.lblRegistros.Text = $"Registros: {dt.Rows.Count}";

                // Ocultar columnas sensibles como en el original
                if (this.dgvPropietarios.Columns.Count > 1)
                {
                    this.dgvPropietarios.Columns[0].Visible = false; // FPPRIDRE
                    this.dgvPropietarios.Columns[1].Visible = false; // FPPRNUFI
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar propietarios: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void GenerateNextOwnerNumber()
        {
            try
            {
                // TODO: Implementar lógica real basada en el original VB
                // var objdatos5 = new cla_FIPRPROP();
                // var tbl10 = objdatos5.fun_Buscar_NRO_SECUENCIA_FIPRPROP_X_FICHA_PREDIAL(this.fichaPredialId);

                int nextNumber = 1;
                if (this.dgvPropietarios.DataSource is DataTable dt && dt.Rows.Count > 0)
                {
                    // Buscar el número de propietario mayor
                    int maxNumber = 0;
                    foreach (DataRow row in dt.Rows)
                    {
                        if (row["FPPRNUDO"] != DBNull.Value)
                        {
                            int number = Convert.ToInt32(row["FPPRNUDO"]);
                            if (number > maxNumber)
                                maxNumber = number;
                        }
                    }
                    nextNumber = maxNumber + 1;
                }
                
                this.txtNroPropietario.Text = nextNumber.ToString();
                this.lblSecuencia.Text = $"Secuencia: {nextNumber}";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al generar número de propietario: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CalculateTotalPercentage()
        {
            try
            {
                double total = 0.0;
                if (this.dgvPropietarios.DataSource is DataTable dt)
                {
                    foreach (DataRow row in dt.Rows)
                    {
                        if (row["FPPRDERE"] != DBNull.Value)
                        {
                            total += Convert.ToDouble(row["FPPRDERE"]);
                        }
                    }
                }
                
                this.totalDerecho = total;
                this.lblTotalPorcentaje.Text = $"Total %: {total:F2}";
                
                // Cambiar color según el total
                if (total > 100)
                {
                    this.lblTotalPorcentaje.ForeColor = Color.Red;
                }
                else if (total == 100)
                {
                    this.lblTotalPorcentaje.ForeColor = Color.Green;
                }
                else
                {
                    this.lblTotalPorcentaje.ForeColor = Color.Orange;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al calcular porcentaje total: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidateForm())
                {
                    // TODO: Implementar guardado real cuando migremos las reglas de negocio
                    // var objdatos = new cla_FIPRPROP();
                    // var resultado = objdatos.fun_Insertar_FIPRPROP(...);

                    MessageBox.Show("Propietario insertado correctamente", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadPropietarios();
                    ClearForm();
                    GenerateNextOwnerNumber();
                    CalculateTotalPercentage();
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

        private void DgvPropietarios_SelectionChanged(object sender, EventArgs e)
        {
            if (this.dgvPropietarios.SelectedRows.Count > 0)
            {
                DataGridViewRow row = this.dgvPropietarios.SelectedRows[0];
                LoadPropietarioData(row);
            }
        }

        private void LoadPropietarioData(DataGridViewRow row)
        {
            try
            {
                this.txtNroPropietario.Text = row.Cells["FPPRNUDO"].Value?.ToString() ?? "";
                this.txtPrimerApellido.Text = row.Cells["FPPRPRAP"].Value?.ToString() ?? "";
                this.txtSegundoApellido.Text = row.Cells["FPPRSEAP"].Value?.ToString() ?? "";
                this.txtNombre.Text = row.Cells["FPPRNOMB"].Value?.ToString() ?? "";
                this.cboTipoDocumento.Text = row.Cells["FPPRTIDO"].Value?.ToString() ?? "";
                this.txtDocumento.Text = row.Cells["FPPRDOCU"].Value?.ToString() ?? "";
                this.cboSexo.Text = row.Cells["FPPRSEXO"].Value?.ToString() ?? "";
                this.cboDepartamento.Text = row.Cells["FPPRDEPA"].Value?.ToString() ?? "";
                this.cboMunicipio.Text = row.Cells["FPPRMUNI"].Value?.ToString() ?? "";
                this.cboNotaria.Text = row.Cells["FPPRNOTA"].Value?.ToString() ?? "";
                this.txtEscritura.Text = row.Cells["FPPRESCR"].Value?.ToString() ?? "";
                this.txtTomo.Text = row.Cells["FPPRTOMO"].Value?.ToString() ?? "";
                this.txtFechaEscritura.Text = row.Cells["FPPRFEES"].Value?.ToString() ?? "";
                this.txtFechaRegistro.Text = row.Cells["FPPRFERE"].Value?.ToString() ?? "";
                this.txtDerecho.Text = row.Cells["FPPRDERE"].Value?.ToString() ?? "";
                this.cboCapacidad.Text = row.Cells["FPPRCAPR"].Value?.ToString() ?? "";
                this.txtSiglaComercial.Text = row.Cells["FPPRSICO"].Value?.ToString() ?? "";
                this.chkGravamen.Checked = Convert.ToBoolean(row.Cells["FPPRGRAV"].Value ?? false);
                this.cboModoAdquisicion.Text = row.Cells["FPPRMOAD"].Value?.ToString() ?? "";
                this.cboEstado.Text = row.Cells["FPPRESTA"].Value?.ToString() ?? "";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar datos del propietario: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void TxtDerecho_TextChanged(object sender, EventArgs e)
        {
            // Validación en tiempo real del porcentaje
            if (decimal.TryParse(this.txtDerecho.Text, out decimal porcentaje))
            {
                if (porcentaje < 0 || porcentaje > 100)
                {
                    this.errorProvider.SetError(this.txtDerecho, "El porcentaje debe estar entre 0 y 100");
                }
                else
                {
                    this.errorProvider.SetError(this.txtDerecho, "");
                }
            }
        }

        private bool ValidateForm()
        {
            // Validaciones basadas en el original VB
            if (string.IsNullOrWhiteSpace(this.txtPrimerApellido.Text))
            {
                this.errorProvider.SetError(this.txtPrimerApellido, "El primer apellido es obligatorio");
                MessageBox.Show("Debe ingresar el primer apellido", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.txtPrimerApellido.Focus();
                return false;
            }
            this.errorProvider.SetError(this.txtPrimerApellido, "");

            if (string.IsNullOrWhiteSpace(this.txtNombre.Text))
            {
                MessageBox.Show("Debe ingresar el nombre", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.txtNombre.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(this.cboTipoDocumento.Text))
            {
                MessageBox.Show("Debe seleccionar el tipo de documento", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.cboTipoDocumento.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(this.txtDocumento.Text))
            {
                MessageBox.Show("Debe ingresar el número de documento", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.txtDocumento.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(this.cboSexo.Text))
            {
                MessageBox.Show("Debe seleccionar el sexo", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.cboSexo.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(this.txtDerecho.Text))
            {
                MessageBox.Show("Debe ingresar el derecho", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.txtDerecho.Focus();
                return false;
            }

            if (!decimal.TryParse(this.txtDerecho.Text, out decimal porcentaje) || porcentaje <= 0 || porcentaje > 100)
            {
                MessageBox.Show("El derecho debe ser un número válido entre 0 y 100", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.txtDerecho.Focus();
                return false;
            }

            // Validar que el total no exceda 100%
            if (this.totalDerecho + (double)porcentaje > 100)
            {
                MessageBox.Show($"El total de derechos no puede exceder 100%. Actual: {this.totalDerecho:F2}% + {porcentaje:F2}% = {(this.totalDerecho + (double)porcentaje):F2}%", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.txtDerecho.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(this.cboCapacidad.Text))
            {
                MessageBox.Show("Debe seleccionar la capacidad", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.cboCapacidad.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(this.cboModoAdquisicion.Text))
            {
                MessageBox.Show("Debe seleccionar el modo de adquisición", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.cboModoAdquisicion.Focus();
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
            this.txtNroPropietario.Clear();
            this.txtPrimerApellido.Clear();
            this.txtSegundoApellido.Clear();
            this.txtNombre.Clear();
            this.cboTipoDocumento.SelectedIndex = -1;
            this.txtDocumento.Clear();
            this.cboSexo.SelectedIndex = -1;
            this.cboDepartamento.SelectedIndex = -1;
            this.cboMunicipio.SelectedIndex = -1;
            this.cboNotaria.SelectedIndex = -1;
            this.txtEscritura.Clear();
            this.txtTomo.Clear();
            this.txtFechaEscritura.Clear();
            this.txtFechaRegistro.Clear();
            this.txtDerecho.Clear();
            this.cboCapacidad.SelectedIndex = -1;
            this.txtSiglaComercial.Clear();
            this.chkGravamen.Checked = false;
            this.cboModoAdquisicion.SelectedIndex = -1;
            this.cboEstado.SelectedIndex = -1;
            
            this.errorProvider.Clear();
            this.txtPrimerApellido.Focus();
        }
    }
} 