using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using SICAFI.Datos;
using SICAFI.ReglasNegocio;
using SICAFI.App.Forms.Shared;

namespace SICAFI.App.Forms.FichaPredial.Propietarios
{
    public class FrmModificarPropietario : Form
    {
        private static FrmModificarPropietario instance;
        
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
        private int propietarioId;
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

        public static FrmModificarPropietario Instance
        {
            get
            {
                if (instance == null || instance.IsDisposed)
                {
                    instance = new FrmModificarPropietario();
                }
                return instance;
            }
        }

        public void InitializeWithContext(int propietarioId, int fichaPredialId, int resolucionId, 
                                        string departamento, string municipio, int resolucionTipo, 
                                        int resolucionClase, int resolucionVigencia, int resolucionResolucion)
        {
            this.propietarioId = propietarioId;
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
            LoadPropietarioData();
        }

        public FrmModificarPropietario()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.Text = "MODIFICAR PROPIETARIO";
            this.Size = new Size(1200, 800);
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
            
            // Documento
            this.cboTipoDocumento = SicafiTheme.CreateComboBox();
            this.txtDocumento = SicafiTheme.CreateTextBox();
            this.cboSexo = SicafiTheme.CreateComboBox();
            
            // Ubicación
            this.cboDepartamento = SicafiTheme.CreateComboBox();
            this.cboMunicipio = SicafiTheme.CreateComboBox();
            
            // Escritura
            this.cboNotaria = SicafiTheme.CreateComboBox();
            this.txtEscritura = SicafiTheme.CreateTextBox();
            this.txtTomo = SicafiTheme.CreateTextBox();
            this.txtFechaEscritura = SicafiTheme.CreateTextBox();
            this.txtFechaRegistro = SicafiTheme.CreateTextBox();
            
            // Derechos
            this.txtDerecho = SicafiTheme.CreateTextBox();
            this.cboCapacidad = SicafiTheme.CreateComboBox();
            this.txtSiglaComercial = SicafiTheme.CreateTextBox();
            this.chkGravamen = new CheckBox();
            this.chkGravamen.Text = "Gravamen";
            this.chkGravamen.Font = SicafiTheme.NormalFont;
            
            this.cboModoAdquisicion = SicafiTheme.CreateComboBox();
            this.cboEstado = SicafiTheme.CreateComboBox();

            // Labels informativos
            this.lblSecuencia = SicafiTheme.CreateLabel("Secuencia: 0");
            this.lblTotalPorcentaje = SicafiTheme.CreateLabel("Total: 0.00%");

            // Configurar ComboBoxes con datos del original
            this.cboTipoDocumento.Items.AddRange(new object[] { 
                "CC", "CE", "NIT", "TI", "PASAPORTE", "OTROS" 
            });
            this.cboSexo.Items.AddRange(new object[] { "M", "F" });
            this.cboDepartamento.Items.AddRange(new object[] { "ANTIOQUIA", "CUNDINAMARCA", "VALLE", "ATLANTICO" });
            this.cboMunicipio.Items.AddRange(new object[] { "MEDELLIN", "BOGOTA", "CALI", "BARRANQUILLA" });
            this.cboNotaria.Items.AddRange(new object[] { "PRIMERA", "SEGUNDA", "TERCERA", "CUARTA", "QUINTA" });
            this.cboCapacidad.Items.AddRange(new object[] { "MAYOR DE EDAD", "MENOR DE EDAD", "INTERDICTO", "OTROS" });
            this.cboModoAdquisicion.Items.AddRange(new object[] { "COMPRAVENTA", "HERENCIA", "DONACION", "PERMUTA", "OTROS" });
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
            Label lblTitulo = SicafiTheme.CreateLabel("MODIFICAR PROPIETARIO", true);
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
            this.txtFichaPredial.Location = new Point(xPos + 120, yPos);
            this.txtFichaPredial.Size = new Size(100, 25);

            yPos += 35;
            gbDatosPropietario.Controls.Add(SicafiTheme.CreateLabel("Nro Propietario:"));
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

            // Segunda sección - Documento
            yPos += 50;
            Label lblDocumento = SicafiTheme.CreateLabel("DOCUMENTO", true);
            lblDocumento.Location = new Point(xPos, yPos);
            gbDatosPropietario.Controls.Add(lblDocumento);

            yPos += 30;
            gbDatosPropietario.Controls.Add(SicafiTheme.CreateLabel("Tipo Documento:"));
            gbDatosPropietario.Controls.Add(this.cboTipoDocumento);
            gbDatosPropietario.Controls.Add(SicafiTheme.CreateLabel("Número:"));
            gbDatosPropietario.Controls.Add(this.txtDocumento);
            this.cboTipoDocumento.Location = new Point(xPos + 120, yPos);
            this.cboTipoDocumento.Size = new Size(100, 25);
            this.txtDocumento.Location = new Point(xPos + 350, yPos);
            this.txtDocumento.Size = new Size(150, 25);

            yPos += 35;
            gbDatosPropietario.Controls.Add(SicafiTheme.CreateLabel("Sexo:"));
            gbDatosPropietario.Controls.Add(this.cboSexo);
            this.cboSexo.Location = new Point(xPos + 120, yPos);
            this.cboSexo.Size = new Size(100, 25);

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

            // Cuarta sección - Escritura
            yPos += 50;
            Label lblEscritura = SicafiTheme.CreateLabel("ESCRITURA", true);
            lblEscritura.Location = new Point(xPos, yPos);
            gbDatosPropietario.Controls.Add(lblEscritura);

            yPos += 30;
            gbDatosPropietario.Controls.Add(SicafiTheme.CreateLabel("Notaría:"));
            gbDatosPropietario.Controls.Add(this.cboNotaria);
            gbDatosPropietario.Controls.Add(SicafiTheme.CreateLabel("Escritura:"));
            gbDatosPropietario.Controls.Add(this.txtEscritura);
            this.cboNotaria.Location = new Point(xPos + 120, yPos);
            this.cboNotaria.Size = new Size(100, 25);
            this.txtEscritura.Location = new Point(xPos + 350, yPos);
            this.txtEscritura.Size = new Size(100, 25);

            yPos += 35;
            gbDatosPropietario.Controls.Add(SicafiTheme.CreateLabel("Tomo:"));
            gbDatosPropietario.Controls.Add(this.txtTomo);
            gbDatosPropietario.Controls.Add(SicafiTheme.CreateLabel("Fecha Escritura:"));
            gbDatosPropietario.Controls.Add(this.txtFechaEscritura);
            this.txtTomo.Location = new Point(xPos + 120, yPos);
            this.txtTomo.Size = new Size(100, 25);
            this.txtFechaEscritura.Location = new Point(xPos + 350, yPos);
            this.txtFechaEscritura.Size = new Size(100, 25);

            yPos += 35;
            gbDatosPropietario.Controls.Add(SicafiTheme.CreateLabel("Fecha Registro:"));
            gbDatosPropietario.Controls.Add(this.txtFechaRegistro);
            this.txtFechaRegistro.Location = new Point(xPos + 120, yPos);
            this.txtFechaRegistro.Size = new Size(100, 25);

            // Quinta sección - Derechos
            yPos += 50;
            Label lblDerechos = SicafiTheme.CreateLabel("DERECHOS", true);
            lblDerechos.Location = new Point(xPos, yPos);
            gbDatosPropietario.Controls.Add(lblDerechos);

            yPos += 30;
            gbDatosPropietario.Controls.Add(SicafiTheme.CreateLabel("Derecho (%):"));
            gbDatosPropietario.Controls.Add(this.txtDerecho);
            gbDatosPropietario.Controls.Add(this.lblTotalPorcentaje);
            this.txtDerecho.Location = new Point(xPos + 120, yPos);
            this.txtDerecho.Size = new Size(100, 25);
            this.lblTotalPorcentaje.Location = new Point(xPos + 350, yPos);

            yPos += 35;
            gbDatosPropietario.Controls.Add(SicafiTheme.CreateLabel("Capacidad:"));
            gbDatosPropietario.Controls.Add(this.cboCapacidad);
            gbDatosPropietario.Controls.Add(SicafiTheme.CreateLabel("Sigla Comercial:"));
            gbDatosPropietario.Controls.Add(this.txtSiglaComercial);
            this.cboCapacidad.Location = new Point(xPos + 120, yPos);
            this.cboCapacidad.Size = new Size(150, 25);
            this.txtSiglaComercial.Location = new Point(xPos + 350, yPos);
            this.txtSiglaComercial.Size = new Size(150, 25);

            yPos += 35;
            gbDatosPropietario.Controls.Add(this.chkGravamen);
            gbDatosPropietario.Controls.Add(SicafiTheme.CreateLabel("Modo Adquisición:"));
            gbDatosPropietario.Controls.Add(this.cboModoAdquisicion);
            this.chkGravamen.Location = new Point(xPos + 120, yPos);
            this.cboModoAdquisicion.Location = new Point(xPos + 350, yPos);
            this.cboModoAdquisicion.Size = new Size(150, 25);

            yPos += 35;
            gbDatosPropietario.Controls.Add(SicafiTheme.CreateLabel("Estado:"));
            gbDatosPropietario.Controls.Add(this.cboEstado);
            this.cboEstado.Location = new Point(xPos + 120, yPos);
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
                dt.Columns.Add("FPPROIDRE", typeof(int)); // ID del propietario
                dt.Columns.Add("FPPRONUFI", typeof(int)); // Ficha Predial
                dt.Columns.Add("FPPRONPRO", typeof(int)); // Nro Propietario
                dt.Columns.Add("FPPROPAAP", typeof(string)); // Primer Apellido
                dt.Columns.Add("FPPROSGAP", typeof(string)); // Segundo Apellido
                dt.Columns.Add("FPPRONOMP", typeof(string)); // Nombre
                dt.Columns.Add("FPPROTIDO", typeof(string)); // Tipo Documento
                dt.Columns.Add("FPPRONUDO", typeof(string)); // Número Documento
                dt.Columns.Add("FPPROSEXO", typeof(string)); // Sexo
                dt.Columns.Add("FPPRODEPA", typeof(string)); // Departamento
                dt.Columns.Add("FPPROMUNI", typeof(string)); // Municipio
                dt.Columns.Add("FPPRONOTA", typeof(string)); // Notaría
                dt.Columns.Add("FPPROESCR", typeof(string)); // Escritura
                dt.Columns.Add("FPPROTOMO", typeof(string)); // Tomo
                dt.Columns.Add("FPPROFECH", typeof(string)); // Fecha Escritura
                dt.Columns.Add("FPPROFREG", typeof(string)); // Fecha Registro
                dt.Columns.Add("FPPRODERC", typeof(decimal)); // Derecho
                dt.Columns.Add("FPPROCAPA", typeof(string)); // Capacidad
                dt.Columns.Add("FPPROSIGL", typeof(string)); // Sigla Comercial
                dt.Columns.Add("FPPROGRAV", typeof(bool)); // Gravamen
                dt.Columns.Add("FPPROMOAD", typeof(string)); // Modo Adquisición
                dt.Columns.Add("FPPROESTA", typeof(string)); // Estado

                // Datos de ejemplo
                dt.Rows.Add(propietarioId, fichaPredialId, 1, "GARCIA", "LOPEZ", "JUAN CARLOS", "CC", "12345678", "M", "ANTIOQUIA", "MEDELLIN", "PRIMERA", "123", "A", "2020-01-15", "2020-01-20", 50.0m, "MAYOR DE EDAD", "JCL", false, "COMPRAVENTA", "ACTIVO");
                dt.Rows.Add(propietarioId + 1, fichaPredialId, 2, "RODRIGUEZ", "MARTINEZ", "MARIA ISABEL", "CC", "87654321", "F", "ANTIOQUIA", "MEDELLIN", "SEGUNDA", "456", "B", "2020-02-10", "2020-02-15", 50.0m, "MAYOR DE EDAD", "MIR", false, "COMPRAVENTA", "ACTIVO");

                this.dgvPropietarios.DataSource = dt;
                this.lblRegistros.Text = $"Registros: {dt.Rows.Count}";

                // Ocultar columnas sensibles como en el original
                if (this.dgvPropietarios.Columns.Count > 1)
                {
                    this.dgvPropietarios.Columns[0].Visible = false; // FPPROIDRE
                    this.dgvPropietarios.Columns[1].Visible = false; // FPPRONUFI
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar propietarios: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadPropietarioData()
        {
            try
            {
                // TODO: Implementar cuando migremos las reglas de negocio
                // var objdatos10 = new cla_FIPRPROP();
                // var tbl10 = objdatos10.fun_Buscar_ID_FIPRPROP(this.propietarioId);

                // Por ahora, cargar datos de ejemplo
                if (this.dgvPropietarios.DataSource is DataTable dt && dt.Rows.Count > 0)
                {
                    DataRow row = dt.Rows[0]; // Tomar el primer registro como ejemplo
                    
                    this.txtNroPropietario.Text = row["FPPRONPRO"].ToString();
                    this.txtPrimerApellido.Text = row["FPPROPAAP"].ToString();
                    this.txtSegundoApellido.Text = row["FPPROSGAP"].ToString();
                    this.txtNombre.Text = row["FPPRONOMP"].ToString();
                    this.cboTipoDocumento.Text = row["FPPROTIDO"].ToString();
                    this.txtDocumento.Text = row["FPPRONUDO"].ToString();
                    this.cboSexo.Text = row["FPPROSEXO"].ToString();
                    this.cboDepartamento.Text = row["FPPRODEPA"].ToString();
                    this.cboMunicipio.Text = row["FPPROMUNI"].ToString();
                    this.cboNotaria.Text = row["FPPRONOTA"].ToString();
                    this.txtEscritura.Text = row["FPPROESCR"].ToString();
                    this.txtTomo.Text = row["FPPROTOMO"].ToString();
                    this.txtFechaEscritura.Text = row["FPPROFECH"].ToString();
                    this.txtFechaRegistro.Text = row["FPPROFREG"].ToString();
                    this.txtDerecho.Text = row["FPPRODERC"].ToString();
                    this.cboCapacidad.Text = row["FPPROCAPA"].ToString();
                    this.txtSiglaComercial.Text = row["FPPROSIGL"].ToString();
                    this.chkGravamen.Checked = Convert.ToBoolean(row["FPPROGRAV"]);
                    this.cboModoAdquisicion.Text = row["FPPROMOAD"].ToString();
                    this.cboEstado.Text = row["FPPROESTA"].ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar datos del propietario: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    // var resultado = objdatos.fun_Modificar_FIPRPROP(...);

                    MessageBox.Show("Propietario modificado correctamente", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadPropietarios();
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
                LoadPropietarioDataFromGrid(row);
            }
        }

        private void LoadPropietarioDataFromGrid(DataGridViewRow row)
        {
            try
            {
                this.txtNroPropietario.Text = row.Cells["FPPRONPRO"].Value?.ToString() ?? "";
                this.txtPrimerApellido.Text = row.Cells["FPPROPAAP"].Value?.ToString() ?? "";
                this.txtSegundoApellido.Text = row.Cells["FPPROSGAP"].Value?.ToString() ?? "";
                this.txtNombre.Text = row.Cells["FPPRONOMP"].Value?.ToString() ?? "";
                this.cboTipoDocumento.Text = row.Cells["FPPROTIDO"].Value?.ToString() ?? "";
                this.txtDocumento.Text = row.Cells["FPPRONUDO"].Value?.ToString() ?? "";
                this.cboSexo.Text = row.Cells["FPPROSEXO"].Value?.ToString() ?? "";
                this.cboDepartamento.Text = row.Cells["FPPRODEPA"].Value?.ToString() ?? "";
                this.cboMunicipio.Text = row.Cells["FPPROMUNI"].Value?.ToString() ?? "";
                this.cboNotaria.Text = row.Cells["FPPRONOTA"].Value?.ToString() ?? "";
                this.txtEscritura.Text = row.Cells["FPPROESCR"].Value?.ToString() ?? "";
                this.txtTomo.Text = row.Cells["FPPROTOMO"].Value?.ToString() ?? "";
                this.txtFechaEscritura.Text = row.Cells["FPPROFECH"].Value?.ToString() ?? "";
                this.txtFechaRegistro.Text = row.Cells["FPPROFREG"].Value?.ToString() ?? "";
                this.txtDerecho.Text = row.Cells["FPPRODERC"].Value?.ToString() ?? "";
                this.cboCapacidad.Text = row.Cells["FPPROCAPA"].Value?.ToString() ?? "";
                this.txtSiglaComercial.Text = row.Cells["FPPROSIGL"].Value?.ToString() ?? "";
                this.chkGravamen.Checked = Convert.ToBoolean(row.Cells["FPPROGRAV"].Value ?? false);
                this.cboModoAdquisicion.Text = row.Cells["FPPROMOAD"].Value?.ToString() ?? "";
                this.cboEstado.Text = row.Cells["FPPROESTA"].Value?.ToString() ?? "";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar datos del propietario: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void TxtDerecho_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (decimal.TryParse(this.txtDerecho.Text, out decimal porcentaje))
                {
                    this.totalDerecho = (double)porcentaje;
                    this.lblTotalPorcentaje.Text = $"Total: {this.totalDerecho:F2}%";
                }
                else
                {
                    this.lblTotalPorcentaje.Text = "Total: 0.00%";
                }
            }
            catch (Exception ex)
            {
                this.lblTotalPorcentaje.Text = "Total: 0.00%";
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

            return true;
        }
    }
} 