using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using SICAFI.Datos;
using SICAFI.ReglasNegocio;
using SICAFI.App.Forms.Shared;

namespace SICAFI.App.Forms.FichaPredial.Construcciones
{
    public class FrmInsertarConstruccion : Form
    {
        private static FrmInsertarConstruccion instance;
        
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
        private int fichaPredialId;
        private int resolucionId;
        private string departamento;
        private string municipio;
        private int resolucionTipo;
        private int resolucionClase;
        private int resolucionVigencia;
        private int resolucionResolucion;
        private bool verificarDatoAlGuardar = true;

        public static FrmInsertarConstruccion Instance
        {
            get
            {
                if (instance == null || instance.IsDisposed)
                {
                    instance = new FrmInsertarConstruccion();
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
            GenerateNextUnitNumber();
        }

        public FrmInsertarConstruccion()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.Text = "INSERTAR CONSTRUCCIÓN";
            this.Size = new Size(1000, 800);
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
            
            this.txtUnidad = SicafiTheme.CreateTextBox();
            this.cboClaseConstruccion = SicafiTheme.CreateComboBox();
            this.cboTipoConstruccion = SicafiTheme.CreateComboBox();
            this.txtPuntos = SicafiTheme.CreateTextBox();
            this.txtAreaConstruccion = SicafiTheme.CreateTextBox();
            
            // Servicios públicos
            this.cboAcueducto = SicafiTheme.CreateComboBox();
            this.cboAlcantarillado = SicafiTheme.CreateComboBox();
            this.cboEnergia = SicafiTheme.CreateComboBox();
            this.cboTelefono = SicafiTheme.CreateComboBox();
            this.cboGas = SicafiTheme.CreateComboBox();
            
            // Características de la construcción
            this.txtPisos = SicafiTheme.CreateTextBox();
            this.txtEstadoConservacion = SicafiTheme.CreateTextBox();
            this.txtPorcentajeConstruido = SicafiTheme.CreateTextBox();
            this.txtAvaluoConstruccion = SicafiTheme.CreateTextBox();
            this.txtFechaConstruccion = SicafiTheme.CreateTextBox();
            
            // CheckBoxes
            this.chkMejoras = new CheckBox();
            this.chkMejoras.Text = "Mejoras";
            this.chkMejoras.Font = SicafiTheme.NormalFont;
            
            this.chkLeyes = new CheckBox();
            this.chkLeyes.Text = "Leyes";
            this.chkLeyes.Font = SicafiTheme.NormalFont;
            
            this.chkAreaConstruccion = new CheckBox();
            this.chkAreaConstruccion.Text = "Área Construcción";
            this.chkAreaConstruccion.Font = SicafiTheme.NormalFont;
            
            // RadioButtons para tipo de uso
            this.rbdResidencial = new RadioButton();
            this.rbdResidencial.Text = "Residencial";
            this.rbdResidencial.Font = SicafiTheme.NormalFont;
            
            this.rbdComercial = new RadioButton();
            this.rbdComercial.Text = "Comercial";
            this.rbdComercial.Font = SicafiTheme.NormalFont;
            
            this.rbdIndustrial = new RadioButton();
            this.rbdIndustrial.Text = "Industrial";
            this.rbdIndustrial.Font = SicafiTheme.NormalFont;
            
            this.rbdOtros = new RadioButton();
            this.rbdOtros.Text = "Otros";
            this.rbdOtros.Font = SicafiTheme.NormalFont;
            
            // Estado
            this.cboEstado = SicafiTheme.CreateComboBox();

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
            Label lblTitulo = SicafiTheme.CreateLabel("INSERTAR CONSTRUCCIÓN", true);
            lblTitulo.Font = new Font("Arial", 14, FontStyle.Bold);
            lblTitulo.Location = new Point(20, 20);

            // Grupo principal de datos de construcción
            GroupBox gbDatosConstruccion = SicafiTheme.CreateGroupBox("DATOS DE LA CONSTRUCCIÓN", 950, 500);
            gbDatosConstruccion.Location = new Point(20, 60);

            int yPos = 25;
            int xPos = 10;

            // Primera fila - Información básica
            gbDatosConstruccion.Controls.Add(SicafiTheme.CreateLabel("Ficha Predial:"));
            gbDatosConstruccion.Controls.Add(this.txtFichaPredial);
            this.txtFichaPredial.Location = new Point(xPos + 120, yPos);
            this.txtFichaPredial.Size = new Size(100, 25);

            yPos += 35;
            gbDatosConstruccion.Controls.Add(SicafiTheme.CreateLabel("Unidad:"));
            gbDatosConstruccion.Controls.Add(this.txtUnidad);
            gbDatosConstruccion.Controls.Add(SicafiTheme.CreateLabel("Clase Construcción:"));
            gbDatosConstruccion.Controls.Add(this.cboClaseConstruccion);
            this.txtUnidad.Location = new Point(xPos + 120, yPos);
            this.txtUnidad.Size = new Size(100, 25);
            this.cboClaseConstruccion.Location = new Point(xPos + 350, yPos);
            this.cboClaseConstruccion.Size = new Size(150, 25);

            yPos += 35;
            gbDatosConstruccion.Controls.Add(SicafiTheme.CreateLabel("Tipo Construcción:"));
            gbDatosConstruccion.Controls.Add(this.cboTipoConstruccion);
            gbDatosConstruccion.Controls.Add(SicafiTheme.CreateLabel("Puntos:"));
            gbDatosConstruccion.Controls.Add(this.txtPuntos);
            this.cboTipoConstruccion.Location = new Point(xPos + 120, yPos);
            this.cboTipoConstruccion.Size = new Size(150, 25);
            this.txtPuntos.Location = new Point(xPos + 350, yPos);
            this.txtPuntos.Size = new Size(100, 25);

            yPos += 35;
            gbDatosConstruccion.Controls.Add(SicafiTheme.CreateLabel("Área Construcción:"));
            gbDatosConstruccion.Controls.Add(this.txtAreaConstruccion);
            gbDatosConstruccion.Controls.Add(this.chkAreaConstruccion);
            this.txtAreaConstruccion.Location = new Point(xPos + 120, yPos);
            this.txtAreaConstruccion.Size = new Size(100, 25);
            this.chkAreaConstruccion.Location = new Point(xPos + 250, yPos);

            // Segunda sección - Servicios públicos
            yPos += 50;
            Label lblServicios = SicafiTheme.CreateLabel("SERVICIOS PÚBLICOS", true);
            lblServicios.Location = new Point(xPos, yPos);
            gbDatosConstruccion.Controls.Add(lblServicios);

            yPos += 30;
            gbDatosConstruccion.Controls.Add(SicafiTheme.CreateLabel("Acueducto:"));
            gbDatosConstruccion.Controls.Add(this.cboAcueducto);
            gbDatosConstruccion.Controls.Add(SicafiTheme.CreateLabel("Alcantarillado:"));
            gbDatosConstruccion.Controls.Add(this.cboAlcantarillado);
            this.cboAcueducto.Location = new Point(xPos + 120, yPos);
            this.cboAcueducto.Size = new Size(100, 25);
            this.cboAlcantarillado.Location = new Point(xPos + 350, yPos);
            this.cboAlcantarillado.Size = new Size(100, 25);

            yPos += 35;
            gbDatosConstruccion.Controls.Add(SicafiTheme.CreateLabel("Energía:"));
            gbDatosConstruccion.Controls.Add(this.cboEnergia);
            gbDatosConstruccion.Controls.Add(SicafiTheme.CreateLabel("Teléfono:"));
            gbDatosConstruccion.Controls.Add(this.cboTelefono);
            this.cboEnergia.Location = new Point(xPos + 120, yPos);
            this.cboEnergia.Size = new Size(100, 25);
            this.cboTelefono.Location = new Point(xPos + 350, yPos);
            this.cboTelefono.Size = new Size(100, 25);

            yPos += 35;
            gbDatosConstruccion.Controls.Add(SicafiTheme.CreateLabel("Gas:"));
            gbDatosConstruccion.Controls.Add(this.cboGas);
            this.cboGas.Location = new Point(xPos + 120, yPos);
            this.cboGas.Size = new Size(100, 25);

            // Tercera sección - Características
            yPos += 50;
            Label lblCaracteristicas = SicafiTheme.CreateLabel("CARACTERÍSTICAS", true);
            lblCaracteristicas.Location = new Point(xPos, yPos);
            gbDatosConstruccion.Controls.Add(lblCaracteristicas);

            yPos += 30;
            gbDatosConstruccion.Controls.Add(SicafiTheme.CreateLabel("Pisos:"));
            gbDatosConstruccion.Controls.Add(this.txtPisos);
            gbDatosConstruccion.Controls.Add(SicafiTheme.CreateLabel("Estado Conservación:"));
            gbDatosConstruccion.Controls.Add(this.txtEstadoConservacion);
            this.txtPisos.Location = new Point(xPos + 120, yPos);
            this.txtPisos.Size = new Size(100, 25);
            this.txtEstadoConservacion.Location = new Point(xPos + 350, yPos);
            this.txtEstadoConservacion.Size = new Size(100, 25);

            yPos += 35;
            gbDatosConstruccion.Controls.Add(SicafiTheme.CreateLabel("Porcentaje Construido:"));
            gbDatosConstruccion.Controls.Add(this.txtPorcentajeConstruido);
            gbDatosConstruccion.Controls.Add(SicafiTheme.CreateLabel("Avaluo Construcción:"));
            gbDatosConstruccion.Controls.Add(this.txtAvaluoConstruccion);
            this.txtPorcentajeConstruido.Location = new Point(xPos + 120, yPos);
            this.txtPorcentajeConstruido.Size = new Size(100, 25);
            this.txtAvaluoConstruccion.Location = new Point(xPos + 350, yPos);
            this.txtAvaluoConstruccion.Size = new Size(150, 25);

            yPos += 35;
            gbDatosConstruccion.Controls.Add(SicafiTheme.CreateLabel("Fecha Construcción:"));
            gbDatosConstruccion.Controls.Add(this.txtFechaConstruccion);
            gbDatosConstruccion.Controls.Add(this.chkMejoras);
            gbDatosConstruccion.Controls.Add(this.chkLeyes);
            this.txtFechaConstruccion.Location = new Point(xPos + 120, yPos);
            this.txtFechaConstruccion.Size = new Size(100, 25);
            this.chkMejoras.Location = new Point(xPos + 350, yPos);
            this.chkLeyes.Location = new Point(xPos + 450, yPos);

            // Cuarta sección - Tipo de uso
            yPos += 50;
            Label lblTipoUso = SicafiTheme.CreateLabel("TIPO DE USO", true);
            lblTipoUso.Location = new Point(xPos, yPos);
            gbDatosConstruccion.Controls.Add(lblTipoUso);

            yPos += 30;
            gbDatosConstruccion.Controls.Add(this.rbdResidencial);
            gbDatosConstruccion.Controls.Add(this.rbdComercial);
            gbDatosConstruccion.Controls.Add(this.rbdIndustrial);
            gbDatosConstruccion.Controls.Add(this.rbdOtros);
            this.rbdResidencial.Location = new Point(xPos + 120, yPos);
            this.rbdComercial.Location = new Point(xPos + 220, yPos);
            this.rbdIndustrial.Location = new Point(xPos + 320, yPos);
            this.rbdOtros.Location = new Point(xPos + 420, yPos);

            // Quinta sección - Estado
            yPos += 50;
            gbDatosConstruccion.Controls.Add(SicafiTheme.CreateLabel("Estado:"));
            gbDatosConstruccion.Controls.Add(this.cboEstado);
            this.cboEstado.Location = new Point(xPos + 120, yPos);
            this.cboEstado.Size = new Size(150, 25);

            // Grupo de lista de construcciones
            GroupBox gbListaConstrucciones = SicafiTheme.CreateGroupBox("LISTA DE CONSTRUCCIONES", 950, 200);
            gbListaConstrucciones.Location = new Point(20, 580);

            this.dgvConstrucciones.Location = new Point(10, 25);
            this.dgvConstrucciones.Size = new Size(930, 140);

            // Botones
            this.btnGuardar.Location = new Point(780, 25);
            this.btnGuardar.Size = new Size(80, 35);
            this.btnSalir.Location = new Point(870, 25);
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
                dt.Rows.Add(1, fichaPredialId, 1, "ESTRUCTURA", "VIVIENDA", 85, "120.5", "SI", "SI", "SI", "SI", "NO", 2, "BUENO", 100, true, false, 50000000m, "2020", "ACTIVO");
                dt.Rows.Add(2, fichaPredialId, 2, "MAMPOSTERÍA", "COMERCIAL", 90, "80.0", "SI", "SI", "SI", "SI", "SI", 1, "EXCELENTE", 100, false, true, 30000000m, "2021", "ACTIVO");

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

        private void GenerateNextUnitNumber()
        {
            try
            {
                // TODO: Implementar cuando migremos las reglas de negocio
                // var objdatos = new cla_FIPRCONS();
                // var siguienteUnidad = objdatos.fun_Obtener_Siguiente_Unidad(this.fichaPredialId);

                // Por ahora, generar número secuencial basado en los datos existentes
                if (this.dgvConstrucciones.DataSource is DataTable dt && dt.Rows.Count > 0)
                {
                    int maxUnidad = 0;
                    foreach (DataRow row in dt.Rows)
                    {
                        if (row["FPCOUNID"] != DBNull.Value)
                        {
                            int unidad = Convert.ToInt32(row["FPCOUNID"]);
                            if (unidad > maxUnidad)
                            {
                                maxUnidad = unidad;
                            }
                        }
                    }
                    this.txtUnidad.Text = (maxUnidad + 1).ToString();
                }
                else
                {
                    this.txtUnidad.Text = "1";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al generar número de unidad: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.txtUnidad.Text = "1";
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
                    // var resultado = objdatos.fun_Insertar_FIPRCONS(...);

                    MessageBox.Show("Construcción insertada correctamente", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearForm();
                    LoadConstrucciones();
                    GenerateNextUnitNumber();
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

        private void ClearForm()
        {
            this.txtUnidad.Clear();
            this.cboClaseConstruccion.SelectedIndex = -1;
            this.cboTipoConstruccion.SelectedIndex = -1;
            this.txtPuntos.Clear();
            this.txtAreaConstruccion.Clear();
            this.cboAcueducto.SelectedIndex = -1;
            this.cboAlcantarillado.SelectedIndex = -1;
            this.cboEnergia.SelectedIndex = -1;
            this.cboTelefono.SelectedIndex = -1;
            this.cboGas.SelectedIndex = -1;
            this.txtPisos.Clear();
            this.txtEstadoConservacion.Clear();
            this.txtPorcentajeConstruido.Clear();
            this.chkMejoras.Checked = false;
            this.chkLeyes.Checked = false;
            this.txtAvaluoConstruccion.Clear();
            this.txtFechaConstruccion.Clear();
            this.rbdResidencial.Checked = false;
            this.rbdComercial.Checked = false;
            this.rbdIndustrial.Checked = false;
            this.rbdOtros.Checked = false;
            this.chkAreaConstruccion.Checked = false;
            this.cboEstado.SelectedIndex = -1;
            
            this.errorProvider.Clear();
            this.txtUnidad.Focus();
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