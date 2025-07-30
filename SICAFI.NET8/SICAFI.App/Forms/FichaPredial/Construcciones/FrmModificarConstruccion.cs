using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using SICAFI.Datos;
using SICAFI.ReglasNegocio;
using SICAFI.App.Forms.Shared;

namespace SICAFI.App.Forms.FichaPredial.Construcciones
{
    public class FrmModificarConstruccion : Form
    {
        private static FrmModificarConstruccion instance;
        
        // Controles del formulario - basados en el original VB
        private TextBox txtFichaPredial;
        private TextBox txtUnidad;
        private ComboBox cboClaseConstruccion;
        private ComboBox cboTipoConstruccion;
        private TextBox txtPuntos;
        private TextBox txtAreaConstruccion;
        private ComboBox cboAcueducto;
        private ComboBox cboAlcantarillado;
        private ComboBox cboEnergia;
        private ComboBox cboTelefono;
        private ComboBox cboGas;
        private TextBox txtPisos;
        private TextBox txtEstadoConservacion;
        private TextBox txtPorcentajeConstruido;
        private CheckBox chkMejoras;
        private CheckBox chkLeyes;
        private TextBox txtAvaluoConstruccion;
        private TextBox txtFechaConstruccion;
        private RadioButton rbdResidencial;
        private RadioButton rbdComercial;
        private RadioButton rbdIndustrial;
        private RadioButton rbdOtros;
        private CheckBox chkAreaConstruccion;
        private ComboBox cboEstado;
        
        private Button btnGuardar;
        private Button btnSalir;
        private DataGridView dgvConstrucciones;
        private BindingNavigator bindingNavigator;
        private StatusStrip statusStrip;
        private ToolStripStatusLabel lblRegistros;
        private ErrorProvider errorProvider;

        // Variables de contexto - basadas en el original VB
        private int construccionId;
        private int fichaPredialId;
        private int resolucionId;
        private string departamento;
        private string municipio;
        private int resolucionTipo;
        private int resolucionClase;
        private int resolucionVigencia;
        private int resolucionResolucion;
        private bool verificarDatoAlGuardar = true;

        public static FrmModificarConstruccion Instance
        {
            get
            {
                if (instance == null || instance.IsDisposed)
                {
                    instance = new FrmModificarConstruccion();
                }
                return instance;
            }
        }

        public void InitializeWithContext(int construccionId, int fichaPredialId, int resolucionId, 
                                        string departamento, string municipio, int resolucionTipo, 
                                        int resolucionClase, int resolucionVigencia, int resolucionResolucion)
        {
            this.construccionId = construccionId;
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
            LoadConstruccionData();
        }

        public FrmModificarConstruccion()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.Text = "MODIFICAR CONSTRUCCIÓN";
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
            // Crear controles principales
            this.txtFichaPredial = SicafiTheme.CreateTextBox(TextBoxSize.Small);
            this.txtFichaPredial.ReadOnly = true;
            
            this.txtUnidad = SicafiTheme.CreateTextBox(TextBoxSize.Small);
            this.cboClaseConstruccion = SicafiTheme.CreateComboBox(ComboBoxSize.Standard);
            this.cboTipoConstruccion = SicafiTheme.CreateComboBox(ComboBoxSize.Standard);
            this.txtPuntos = SicafiTheme.CreateTextBox(TextBoxSize.Small);
            this.txtAreaConstruccion = SicafiTheme.CreateTextBox(TextBoxSize.Small);
            
            // Servicios públicos
            this.cboAcueducto = SicafiTheme.CreateComboBox(ComboBoxSize.Small);
            this.cboAlcantarillado = SicafiTheme.CreateComboBox(ComboBoxSize.Small);
            this.cboEnergia = SicafiTheme.CreateComboBox(ComboBoxSize.Small);
            this.cboTelefono = SicafiTheme.CreateComboBox(ComboBoxSize.Small);
            this.cboGas = SicafiTheme.CreateComboBox(ComboBoxSize.Small);
            
            // Características de la construcción
            this.txtPisos = SicafiTheme.CreateTextBox(TextBoxSize.Small);
            this.txtEstadoConservacion = SicafiTheme.CreateTextBox(TextBoxSize.Small);
            this.txtPorcentajeConstruido = SicafiTheme.CreateTextBox(TextBoxSize.Small);
            this.txtAvaluoConstruccion = SicafiTheme.CreateTextBox(TextBoxSize.Standard);
            this.txtFechaConstruccion = SicafiTheme.CreateTextBox(TextBoxSize.Small);
            
            // CheckBoxes
            this.chkMejoras = new CheckBox();
            this.chkMejoras.Text = "Mejoras";
            this.chkMejoras.Font = SicafiTheme.NormalFont;
            this.chkMejoras.ForeColor = SicafiTheme.TextSecondaryColor;
            this.chkMejoras.BackColor = Color.Transparent;
            
            this.chkLeyes = new CheckBox();
            this.chkLeyes.Text = "Leyes";
            this.chkLeyes.Font = SicafiTheme.NormalFont;
            this.chkLeyes.ForeColor = SicafiTheme.TextSecondaryColor;
            this.chkLeyes.BackColor = Color.Transparent;
            
            this.chkAreaConstruccion = new CheckBox();
            this.chkAreaConstruccion.Text = "Área Construcción";
            this.chkAreaConstruccion.Font = SicafiTheme.NormalFont;
            this.chkAreaConstruccion.ForeColor = SicafiTheme.TextSecondaryColor;
            this.chkAreaConstruccion.BackColor = Color.Transparent;
            
            // RadioButtons para tipo de uso
            this.rbdResidencial = new RadioButton();
            this.rbdResidencial.Text = "Residencial";
            this.rbdResidencial.Font = SicafiTheme.NormalFont;
            this.rbdResidencial.ForeColor = SicafiTheme.TextSecondaryColor;
            this.rbdResidencial.BackColor = Color.Transparent;
            
            this.rbdComercial = new RadioButton();
            this.rbdComercial.Text = "Comercial";
            this.rbdComercial.Font = SicafiTheme.NormalFont;
            this.rbdComercial.ForeColor = SicafiTheme.TextSecondaryColor;
            this.rbdComercial.BackColor = Color.Transparent;
            
            this.rbdIndustrial = new RadioButton();
            this.rbdIndustrial.Text = "Industrial";
            this.rbdIndustrial.Font = SicafiTheme.NormalFont;
            this.rbdIndustrial.ForeColor = SicafiTheme.TextSecondaryColor;
            this.rbdIndustrial.BackColor = Color.Transparent;
            
            this.rbdOtros = new RadioButton();
            this.rbdOtros.Text = "Otros";
            this.rbdOtros.Font = SicafiTheme.NormalFont;
            this.rbdOtros.ForeColor = SicafiTheme.TextSecondaryColor;
            this.rbdOtros.BackColor = Color.Transparent;
            
            // Estado
            this.cboEstado = SicafiTheme.CreateComboBox(ComboBoxSize.Standard);

            // Configurar ComboBoxes con datos del original
            this.cboClaseConstruccion.Items.AddRange(new object[] { 
                "ESTRUCTURA", "MAMPOSTERÍA", "MIXTA", "PREFABRICADA", "OTROS" 
            });
            this.cboTipoConstruccion.Items.AddRange(new object[] { 
                "VIVIENDA", "COMERCIAL", "INDUSTRIAL", "INSTITUCIONAL", "RECREATIVO", "OTROS" 
            });
            
            // Servicios públicos
            this.cboAcueducto.Items.AddRange(new object[] { "SI", "NO", "PENDIENTE" });
            this.cboAlcantarillado.Items.AddRange(new object[] { "SI", "NO", "PENDIENTE" });
            this.cboEnergia.Items.AddRange(new object[] { "SI", "NO", "PENDIENTE" });
            this.cboTelefono.Items.AddRange(new object[] { "SI", "NO", "PENDIENTE" });
            this.cboGas.Items.AddRange(new object[] { "SI", "NO", "PENDIENTE" });
            
            // Estado
            this.cboEstado.Items.AddRange(new object[] { "ACTIVO", "INACTIVO", "SUSPENDIDO" });

            // Crear botones
            this.btnGuardar = SicafiTheme.CreateButton("Guardar", true);
            this.btnSalir = SicafiTheme.CreateButton("Salir");

            // Crear DataGridView
            this.dgvConstrucciones = SicafiTheme.CreateDataGridView();
            this.dgvConstrucciones.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dgvConstrucciones.MultiSelect = false;

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
            this.dgvConstrucciones.SelectionChanged += DgvConstrucciones_SelectionChanged;
        }

        private void SetupLayout()
        {
            // Panel principal
            Panel mainPanel = SicafiTheme.CreateMainPanel();

            // Título
            Label lblTitulo = SicafiTheme.CreateLabel("MODIFICAR CONSTRUCCIÓN", true);
            lblTitulo.Font = new Font("Segoe UI", 16, FontStyle.Bold);
            lblTitulo.Location = new Point(20, 20);
            lblTitulo.Size = new Size(400, 30);

            // Grupo principal de datos de construcción
            GroupBox gbDatosConstruccion = SicafiTheme.CreateGroupBox("DATOS DE LA CONSTRUCCIÓN", 860, 450);
            gbDatosConstruccion.Location = new Point(20, 60);

            int yPos = 30;
            int xPos = 20;
            int labelWidth = 120;
            int controlSpacing = 40;

            // Primera fila - Información básica
            var lblFichaPredial = SicafiTheme.CreateLabel("Ficha Predial:");
            lblFichaPredial.Location = new Point(xPos, yPos);
            lblFichaPredial.Size = new Size(labelWidth, 25);
            gbDatosConstruccion.Controls.Add(lblFichaPredial);

            this.txtFichaPredial.Location = new Point(xPos + labelWidth + 10, yPos);
            gbDatosConstruccion.Controls.Add(this.txtFichaPredial);

            yPos += controlSpacing;
            var lblUnidad = SicafiTheme.CreateLabel("Unidad:");
            lblUnidad.Location = new Point(xPos, yPos);
            lblUnidad.Size = new Size(labelWidth, 25);
            gbDatosConstruccion.Controls.Add(lblUnidad);

            this.txtUnidad.Location = new Point(xPos + labelWidth + 10, yPos);
            gbDatosConstruccion.Controls.Add(this.txtUnidad);

            var lblClaseConstruccion = SicafiTheme.CreateLabel("Clase Construcción:");
            lblClaseConstruccion.Location = new Point(xPos + 300, yPos);
            lblClaseConstruccion.Size = new Size(labelWidth, 25);
            gbDatosConstruccion.Controls.Add(lblClaseConstruccion);

            this.cboClaseConstruccion.Location = new Point(xPos + 430, yPos);
            gbDatosConstruccion.Controls.Add(this.cboClaseConstruccion);

            yPos += controlSpacing;
            var lblTipoConstruccion = SicafiTheme.CreateLabel("Tipo Construcción:");
            lblTipoConstruccion.Location = new Point(xPos, yPos);
            lblTipoConstruccion.Size = new Size(labelWidth, 25);
            gbDatosConstruccion.Controls.Add(lblTipoConstruccion);

            this.cboTipoConstruccion.Location = new Point(xPos + labelWidth + 10, yPos);
            gbDatosConstruccion.Controls.Add(this.cboTipoConstruccion);

            var lblPuntos = SicafiTheme.CreateLabel("Puntos:");
            lblPuntos.Location = new Point(xPos + 300, yPos);
            lblPuntos.Size = new Size(labelWidth, 25);
            gbDatosConstruccion.Controls.Add(lblPuntos);

            this.txtPuntos.Location = new Point(xPos + 430, yPos);
            gbDatosConstruccion.Controls.Add(this.txtPuntos);

            yPos += controlSpacing;
            var lblAreaConstruccion = SicafiTheme.CreateLabel("Área Construcción:");
            lblAreaConstruccion.Location = new Point(xPos, yPos);
            lblAreaConstruccion.Size = new Size(labelWidth, 25);
            gbDatosConstruccion.Controls.Add(lblAreaConstruccion);

            this.txtAreaConstruccion.Location = new Point(xPos + labelWidth + 10, yPos);
            gbDatosConstruccion.Controls.Add(this.txtAreaConstruccion);

            this.chkAreaConstruccion.Location = new Point(xPos + 300, yPos);
            gbDatosConstruccion.Controls.Add(this.chkAreaConstruccion);

            // Segunda sección - Servicios públicos
            yPos += 60;
            Label lblServicios = SicafiTheme.CreateLabel("SERVICIOS PÚBLICOS", true);
            lblServicios.Location = new Point(xPos, yPos);
            lblServicios.Size = new Size(200, 25);
            gbDatosConstruccion.Controls.Add(lblServicios);

            yPos += 35;
            var lblAcueducto = SicafiTheme.CreateLabel("Acueducto:");
            lblAcueducto.Location = new Point(xPos, yPos);
            lblAcueducto.Size = new Size(labelWidth, 25);
            gbDatosConstruccion.Controls.Add(lblAcueducto);

            this.cboAcueducto.Location = new Point(xPos + labelWidth + 10, yPos);
            gbDatosConstruccion.Controls.Add(this.cboAcueducto);

            var lblAlcantarillado = SicafiTheme.CreateLabel("Alcantarillado:");
            lblAlcantarillado.Location = new Point(xPos + 300, yPos);
            lblAlcantarillado.Size = new Size(labelWidth, 25);
            gbDatosConstruccion.Controls.Add(lblAlcantarillado);

            this.cboAlcantarillado.Location = new Point(xPos + 430, yPos);
            gbDatosConstruccion.Controls.Add(this.cboAlcantarillado);

            yPos += controlSpacing;
            var lblEnergia = SicafiTheme.CreateLabel("Energía:");
            lblEnergia.Location = new Point(xPos, yPos);
            lblEnergia.Size = new Size(labelWidth, 25);
            gbDatosConstruccion.Controls.Add(lblEnergia);

            this.cboEnergia.Location = new Point(xPos + labelWidth + 10, yPos);
            gbDatosConstruccion.Controls.Add(this.cboEnergia);

            var lblTelefono = SicafiTheme.CreateLabel("Teléfono:");
            lblTelefono.Location = new Point(xPos + 300, yPos);
            lblTelefono.Size = new Size(labelWidth, 25);
            gbDatosConstruccion.Controls.Add(lblTelefono);

            this.cboTelefono.Location = new Point(xPos + 430, yPos);
            gbDatosConstruccion.Controls.Add(this.cboTelefono);

            yPos += controlSpacing;
            var lblGas = SicafiTheme.CreateLabel("Gas:");
            lblGas.Location = new Point(xPos, yPos);
            lblGas.Size = new Size(labelWidth, 25);
            gbDatosConstruccion.Controls.Add(lblGas);

            this.cboGas.Location = new Point(xPos + labelWidth + 10, yPos);
            gbDatosConstruccion.Controls.Add(this.cboGas);

            // Tercera sección - Características
            yPos += 60;
            Label lblCaracteristicas = SicafiTheme.CreateLabel("CARACTERÍSTICAS", true);
            lblCaracteristicas.Location = new Point(xPos, yPos);
            lblCaracteristicas.Size = new Size(200, 25);
            gbDatosConstruccion.Controls.Add(lblCaracteristicas);

            yPos += 35;
            var lblPisos = SicafiTheme.CreateLabel("Pisos:");
            lblPisos.Location = new Point(xPos, yPos);
            lblPisos.Size = new Size(labelWidth, 25);
            gbDatosConstruccion.Controls.Add(lblPisos);

            this.txtPisos.Location = new Point(xPos + labelWidth + 10, yPos);
            gbDatosConstruccion.Controls.Add(this.txtPisos);

            var lblEstadoConservacion = SicafiTheme.CreateLabel("Estado Conservación:");
            lblEstadoConservacion.Location = new Point(xPos + 300, yPos);
            lblEstadoConservacion.Size = new Size(labelWidth, 25);
            gbDatosConstruccion.Controls.Add(lblEstadoConservacion);

            this.txtEstadoConservacion.Location = new Point(xPos + 430, yPos);
            gbDatosConstruccion.Controls.Add(this.txtEstadoConservacion);

            yPos += controlSpacing;
            var lblPorcentajeConstruido = SicafiTheme.CreateLabel("Porcentaje Construido:");
            lblPorcentajeConstruido.Location = new Point(xPos, yPos);
            lblPorcentajeConstruido.Size = new Size(labelWidth, 25);
            gbDatosConstruccion.Controls.Add(lblPorcentajeConstruido);

            this.txtPorcentajeConstruido.Location = new Point(xPos + labelWidth + 10, yPos);
            gbDatosConstruccion.Controls.Add(this.txtPorcentajeConstruido);

            var lblAvaluoConstruccion = SicafiTheme.CreateLabel("Avaluo Construcción:");
            lblAvaluoConstruccion.Location = new Point(xPos + 300, yPos);
            lblAvaluoConstruccion.Size = new Size(labelWidth, 25);
            gbDatosConstruccion.Controls.Add(lblAvaluoConstruccion);

            this.txtAvaluoConstruccion.Location = new Point(xPos + 430, yPos);
            gbDatosConstruccion.Controls.Add(this.txtAvaluoConstruccion);

            yPos += controlSpacing;
            var lblFechaConstruccion = SicafiTheme.CreateLabel("Fecha Construcción:");
            lblFechaConstruccion.Location = new Point(xPos, yPos);
            lblFechaConstruccion.Size = new Size(labelWidth, 25);
            gbDatosConstruccion.Controls.Add(lblFechaConstruccion);

            this.txtFechaConstruccion.Location = new Point(xPos + labelWidth + 10, yPos);
            gbDatosConstruccion.Controls.Add(this.txtFechaConstruccion);

            this.chkMejoras.Location = new Point(xPos + 300, yPos);
            gbDatosConstruccion.Controls.Add(this.chkMejoras);

            this.chkLeyes.Location = new Point(xPos + 400, yPos);
            gbDatosConstruccion.Controls.Add(this.chkLeyes);

            // Cuarta sección - Tipo de uso
            yPos += 60;
            Label lblTipoUso = SicafiTheme.CreateLabel("TIPO DE USO", true);
            lblTipoUso.Location = new Point(xPos, yPos);
            lblTipoUso.Size = new Size(200, 25);
            gbDatosConstruccion.Controls.Add(lblTipoUso);

            yPos += 35;
            this.rbdResidencial.Location = new Point(xPos + labelWidth + 10, yPos);
            gbDatosConstruccion.Controls.Add(this.rbdResidencial);

            this.rbdComercial.Location = new Point(xPos + 200, yPos);
            gbDatosConstruccion.Controls.Add(this.rbdComercial);

            this.rbdIndustrial.Location = new Point(xPos + 300, yPos);
            gbDatosConstruccion.Controls.Add(this.rbdIndustrial);

            this.rbdOtros.Location = new Point(xPos + 400, yPos);
            gbDatosConstruccion.Controls.Add(this.rbdOtros);

            // Quinta sección - Estado
            yPos += 60;
            var lblEstado = SicafiTheme.CreateLabel("Estado:");
            lblEstado.Location = new Point(xPos, yPos);
            lblEstado.Size = new Size(labelWidth, 25);
            gbDatosConstruccion.Controls.Add(lblEstado);

            this.cboEstado.Location = new Point(xPos + labelWidth + 10, yPos);
            gbDatosConstruccion.Controls.Add(this.cboEstado);

            // Grupo de lista de construcciones
            GroupBox gbListaConstrucciones = SicafiTheme.CreateGroupBox("LISTA DE CONSTRUCCIONES", 860, 180);
            gbListaConstrucciones.Location = new Point(20, 530);

            this.dgvConstrucciones.Location = new Point(20, 30);
            this.dgvConstrucciones.Size = new Size(820, 120);

            // Botones
            this.btnGuardar.Location = new Point(680, 30);
            this.btnGuardar.Size = new Size(80, 35);
            this.btnSalir.Location = new Point(770, 30);
            this.btnSalir.Size = new Size(80, 35);

            gbListaConstrucciones.Controls.AddRange(new Control[] {
                this.dgvConstrucciones, this.btnGuardar, this.btnSalir
            });

            // Agregar controles al formulario
            this.Controls.Add(lblTitulo);
            this.Controls.Add(mainPanel);
            mainPanel.Controls.Add(gbDatosConstruccion);
            mainPanel.Controls.Add(gbListaConstrucciones);
            this.Controls.Add(this.bindingNavigator);
            this.Controls.Add(this.statusStrip);
        }

        private void LoadData()
        {
            try
            {
                LoadConstrucciones();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar datos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadConstrucciones()
        {
            try
            {
                // TODO: Implementar cuando migremos las reglas de negocio
                // var objdatos = new cla_FIPRCONS();
                // var datos = objdatos.fun_Consultar_FIPRCONS(this.fichaPredialId);

                // Por ahora, datos de ejemplo basados en el original
                DataTable dt = new DataTable();
                dt.Columns.Add("FPCOIDRE", typeof(int)); // ID de la construcción
                dt.Columns.Add("FPCONUFI", typeof(int)); // Ficha Predial
                dt.Columns.Add("FPCOUNID", typeof(int)); // Unidad
                dt.Columns.Add("FPCOCLCO", typeof(string)); // Clase Construcción
                dt.Columns.Add("FPCOTICO", typeof(string)); // Tipo Construcción
                dt.Columns.Add("FPCOPUNT", typeof(int)); // Puntos
                dt.Columns.Add("FPCOARCO", typeof(string)); // Área Construcción
                dt.Columns.Add("FPCOACUE", typeof(string)); // Acueducto
                dt.Columns.Add("FPCOALCA", typeof(string)); // Alcantarillado
                dt.Columns.Add("FPCOENER", typeof(string)); // Energía
                dt.Columns.Add("FPCOTELE", typeof(string)); // Teléfono
                dt.Columns.Add("FPCOGAS", typeof(string)); // Gas
                dt.Columns.Add("FPCOPISO", typeof(int)); // Pisos
                dt.Columns.Add("FPCOEDCO", typeof(string)); // Estado Conservación
                dt.Columns.Add("FPCOPOCO", typeof(int)); // Porcentaje Construido
                dt.Columns.Add("FPCOMEJO", typeof(bool)); // Mejoras
                dt.Columns.Add("FPCOLEY", typeof(bool)); // Leyes
                dt.Columns.Add("FPCOAVCO", typeof(decimal)); // Avaluo Construcción
                dt.Columns.Add("FPCOFECH", typeof(string)); // Fecha Construcción
                dt.Columns.Add("FPCOESTA", typeof(string)); // Estado

                // Datos de ejemplo
                dt.Rows.Add(construccionId, fichaPredialId, 1, "ESTRUCTURA", "VIVIENDA", 85, "120.5", "SI", "SI", "SI", "SI", "NO", 2, "BUENO", 100, true, false, 50000000m, "2020", "ACTIVO");
                dt.Rows.Add(construccionId + 1, fichaPredialId, 2, "MAMPOSTERÍA", "COMERCIAL", 90, "80.0", "SI", "SI", "SI", "SI", "SI", 1, "EXCELENTE", 100, false, true, 30000000m, "2021", "ACTIVO");

                this.dgvConstrucciones.DataSource = dt;
                this.lblRegistros.Text = $"Registros: {dt.Rows.Count}";

                // Ocultar columnas sensibles como en el original
                if (this.dgvConstrucciones.Columns.Count > 1)
                {
                    this.dgvConstrucciones.Columns[0].Visible = false; // FPCOIDRE
                    this.dgvConstrucciones.Columns[1].Visible = false; // FPCONUFI
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar construcciones: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadConstruccionData()
        {
            try
            {
                // TODO: Implementar cuando migremos las reglas de negocio
                // var objdatos10 = new cla_FIPRCONS();
                // var tbl10 = objdatos10.fun_Buscar_ID_FIPRCONS(this.construccionId);

                // Por ahora, cargar datos de ejemplo
                if (this.dgvConstrucciones.DataSource is DataTable dt && dt.Rows.Count > 0)
                {
                    DataRow row = dt.Rows[0]; // Tomar el primer registro como ejemplo
                    
                    this.txtUnidad.Text = row["FPCOUNID"].ToString();
                    this.cboClaseConstruccion.Text = row["FPCOCLCO"].ToString();
                    this.cboTipoConstruccion.Text = row["FPCOTICO"].ToString();
                    this.txtPuntos.Text = row["FPCOPUNT"].ToString();
                    this.txtAreaConstruccion.Text = row["FPCOARCO"].ToString();
                    this.cboAcueducto.Text = row["FPCOACUE"].ToString();
                    this.cboAlcantarillado.Text = row["FPCOALCA"].ToString();
                    this.cboEnergia.Text = row["FPCOENER"].ToString();
                    this.cboTelefono.Text = row["FPCOTELE"].ToString();
                    this.cboGas.Text = row["FPCOGAS"].ToString();
                    this.txtPisos.Text = row["FPCOPISO"].ToString();
                    this.txtEstadoConservacion.Text = row["FPCOEDCO"].ToString();
                    this.txtPorcentajeConstruido.Text = row["FPCOPOCO"].ToString();
                    this.chkMejoras.Checked = Convert.ToBoolean(row["FPCOMEJO"]);
                    this.chkLeyes.Checked = Convert.ToBoolean(row["FPCOLEY"]);
                    this.txtAvaluoConstruccion.Text = row["FPCOAVCO"].ToString();
                    this.txtFechaConstruccion.Text = row["FPCOFECH"].ToString();
                    this.cboEstado.Text = row["FPCOESTA"].ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar datos de la construcción: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidateForm())
                {
                    // TODO: Implementar guardado real cuando migremos las reglas de negocio
                    // var objdatos = new cla_FIPRCONS();
                    // var resultado = objdatos.fun_Modificar_FIPRCONS(...);

                    MessageBox.Show("Construcción modificada correctamente", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadConstrucciones();
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

        private void DgvConstrucciones_SelectionChanged(object sender, EventArgs e)
        {
            if (this.dgvConstrucciones.SelectedRows.Count > 0)
            {
                DataGridViewRow row = this.dgvConstrucciones.SelectedRows[0];
                LoadConstruccionDataFromGrid(row);
            }
        }

        private void LoadConstruccionDataFromGrid(DataGridViewRow row)
        {
            try
            {
                this.txtUnidad.Text = row.Cells["FPCOUNID"].Value?.ToString() ?? "";
                this.cboClaseConstruccion.Text = row.Cells["FPCOCLCO"].Value?.ToString() ?? "";
                this.cboTipoConstruccion.Text = row.Cells["FPCOTICO"].Value?.ToString() ?? "";
                this.txtPuntos.Text = row.Cells["FPCOPUNT"].Value?.ToString() ?? "";
                this.txtAreaConstruccion.Text = row.Cells["FPCOARCO"].Value?.ToString() ?? "";
                this.cboAcueducto.Text = row.Cells["FPCOACUE"].Value?.ToString() ?? "";
                this.cboAlcantarillado.Text = row.Cells["FPCOALCA"].Value?.ToString() ?? "";
                this.cboEnergia.Text = row.Cells["FPCOENER"].Value?.ToString() ?? "";
                this.cboTelefono.Text = row.Cells["FPCOTELE"].Value?.ToString() ?? "";
                this.cboGas.Text = row.Cells["FPCOGAS"].Value?.ToString() ?? "";
                this.txtPisos.Text = row.Cells["FPCOPISO"].Value?.ToString() ?? "";
                this.txtEstadoConservacion.Text = row.Cells["FPCOEDCO"].Value?.ToString() ?? "";
                this.txtPorcentajeConstruido.Text = row.Cells["FPCOPOCO"].Value?.ToString() ?? "";
                this.chkMejoras.Checked = Convert.ToBoolean(row.Cells["FPCOMEJO"].Value ?? false);
                this.chkLeyes.Checked = Convert.ToBoolean(row.Cells["FPCOLEY"].Value ?? false);
                this.txtAvaluoConstruccion.Text = row.Cells["FPCOAVCO"].Value?.ToString() ?? "";
                this.txtFechaConstruccion.Text = row.Cells["FPCOFECH"].Value?.ToString() ?? "";
                this.cboEstado.Text = row.Cells["FPCOESTA"].Value?.ToString() ?? "";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar datos de la construcción: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool ValidateForm()
        {
            // Validaciones basadas en el original VB
            if (string.IsNullOrWhiteSpace(this.txtUnidad.Text))
            {
                this.errorProvider.SetError(this.txtUnidad, "La unidad es obligatoria");
                MessageBox.Show("Debe ingresar la unidad de la construcción", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.txtUnidad.Focus();
                return false;
            }
            this.errorProvider.SetError(this.txtUnidad, "");

            if (string.IsNullOrWhiteSpace(this.cboClaseConstruccion.Text))
            {
                MessageBox.Show("Debe seleccionar la clase de construcción", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.cboClaseConstruccion.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(this.cboTipoConstruccion.Text))
            {
                MessageBox.Show("Debe seleccionar el tipo de construcción", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.cboTipoConstruccion.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(this.txtPuntos.Text))
            {
                MessageBox.Show("Debe ingresar los puntos", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.txtPuntos.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(this.txtAreaConstruccion.Text))
            {
                MessageBox.Show("Debe ingresar el área de construcción", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.txtAreaConstruccion.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(this.cboAcueducto.Text))
            {
                MessageBox.Show("Debe seleccionar el estado del acueducto", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.cboAcueducto.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(this.cboAlcantarillado.Text))
            {
                MessageBox.Show("Debe seleccionar el estado del alcantarillado", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.cboAlcantarillado.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(this.cboEnergia.Text))
            {
                MessageBox.Show("Debe seleccionar el estado de la energía", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.cboEnergia.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(this.cboTelefono.Text))
            {
                MessageBox.Show("Debe seleccionar el estado del teléfono", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.cboTelefono.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(this.cboGas.Text))
            {
                MessageBox.Show("Debe seleccionar el estado del gas", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.cboGas.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(this.txtPisos.Text))
            {
                MessageBox.Show("Debe ingresar el número de pisos", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.txtPisos.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(this.txtEstadoConservacion.Text))
            {
                MessageBox.Show("Debe ingresar el estado de conservación", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.txtEstadoConservacion.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(this.txtPorcentajeConstruido.Text))
            {
                MessageBox.Show("Debe ingresar el porcentaje construido", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.txtPorcentajeConstruido.Focus();
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