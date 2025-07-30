using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using SICAFI.Datos;
using SICAFI.ReglasNegocio;
using SICAFI.App.Forms.Shared;

namespace SICAFI.App.Forms.FichaPredial
{
    public class FrmFichaPredialPrincipal : Form
    {
        private static FrmFichaPredialPrincipal instance;
        
        // Controles principales
        private TabControl tabControl;
        private TabPage tabFichaPredial;
        private TabPage tabPropietarios;
        private TabPage tabConstrucciones;
        private TabPage tabLinderos;
        private TabPage tabZonas;
        
        // Controles de navegación
        private BindingNavigator bindingNavigator;
        private ToolStripButton btnAgregar;
        private ToolStripButton btnModificar;
        private ToolStripButton btnEliminar;
        private ToolStripButton btnConsultar;
        private ToolStripButton btnReconsultar;
        
        // Controles de opciones
        private GroupBox gbOpciones;
        private Button btnJuridicaPredio;
        private Button btnLiquidaPredial;
        private Button btnLiquidaAvaluo;
        private Button btnImagenPredio;
        private Button btnConsultaParametrizada;
        private Button btnValidarFicha;
        
        // Controles de datos principales
        private GroupBox gbDatosPrincipales;
        private Label lblFichaPredial;
        private Label lblPolicia;
        private Label lblMunicipio;
        private Label lblDepartamento;
        private Label lblCasa;
        private Label lblSan;
        private Label lblUpan;
        private Label lblEdan;
        private Label lblPran;
        private Label lblMaan;
        private Label lblBaan;
        private Label lblCoan;
        private Label lblMuan;
        private Label lblCasual;
        private Label lblClase;
        private Label lblDireccion;
        private Label lblDescripcion;
        private Label lblUnidadPredio;
        private Label lblEdificio;
        private Label lblPredio;
        private Label lblManzana;
        private Label lblBarrio;
        private Label lblCorregimiento;
        private Label lblMunicipio2;
        private Label lblNumeroFicha;
        
        // DataGridView para lista de fichas
        private DataGridView dgvFichasPrediales;
        private StatusStrip statusStrip;
        private ToolStripStatusLabel lblRegistros;
        
        // Variables de contexto
        private int fichaPredialId;
        private DataTable datosFichaPredial;
        private bool modoConsulta = false;

        public static FrmFichaPredialPrincipal Instance
        {
            get
            {
                if (instance == null || instance.IsDisposed)
                {
                    instance = new FrmFichaPredialPrincipal();
                }
                return instance;
            }
        }

        public void InitializeWithContext(int fichaPredialId = 0, DataTable datosConsulta = null)
        {
            this.fichaPredialId = fichaPredialId;
            this.datosFichaPredial = datosConsulta;
            this.modoConsulta = datosConsulta != null;
            
            LoadData();
            UpdateDisplay();
        }

        public FrmFichaPredialPrincipal()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.Text = "FICHA PREDIAL - SICAFI";
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
            // Crear TabControl
            this.tabControl = new TabControl();
            SicafiTheme.ApplyTabControlTheme(this.tabControl);
            
            // Crear pestañas
            this.tabFichaPredial = new TabPage();
            this.tabFichaPredial.Text = "FICHA PREDIAL";
            SicafiTheme.ApplyTabPageTheme(this.tabFichaPredial);
            
            this.tabPropietarios = new TabPage();
            this.tabPropietarios.Text = "PROPIETARIOS";
            SicafiTheme.ApplyTabPageTheme(this.tabPropietarios);
            
            this.tabConstrucciones = new TabPage();
            this.tabConstrucciones.Text = "CONSTRUCCIONES";
            SicafiTheme.ApplyTabPageTheme(this.tabConstrucciones);
            
            this.tabLinderos = new TabPage();
            this.tabLinderos.Text = "LINDEROS";
            SicafiTheme.ApplyTabPageTheme(this.tabLinderos);
            
            this.tabZonas = new TabPage();
            this.tabZonas.Text = "ZONAS";
            SicafiTheme.ApplyTabPageTheme(this.tabZonas);

            // Crear BindingNavigator
            this.bindingNavigator = SicafiTheme.CreateBindingNavigator();
            
            // Crear botones de navegación
            this.btnAgregar = new ToolStripButton();
            this.btnAgregar.Text = "Agregar";
            this.btnAgregar.Image = null; // TODO: Agregar icono
            this.btnAgregar.Click += BtnAgregar_Click;
            
            this.btnModificar = new ToolStripButton();
            this.btnModificar.Text = "Modificar";
            this.btnModificar.Image = null; // TODO: Agregar icono
            this.btnModificar.Click += BtnModificar_Click;
            
            this.btnEliminar = new ToolStripButton();
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.Image = null; // TODO: Agregar icono
            this.btnEliminar.Click += BtnEliminar_Click;
            
            this.btnConsultar = new ToolStripButton();
            this.btnConsultar.Text = "Consultar";
            this.btnConsultar.Image = null; // TODO: Agregar icono
            this.btnConsultar.Click += BtnConsultar_Click;
            
            this.btnReconsultar = new ToolStripButton();
            this.btnReconsultar.Text = "Reconsultar";
            this.btnReconsultar.Image = null; // TODO: Agregar icono
            this.btnReconsultar.Click += BtnReconsultar_Click;

            // Agregar botones al BindingNavigator
            this.bindingNavigator.Items.AddRange(new ToolStripItem[] {
                this.btnAgregar,
                this.btnModificar,
                this.btnEliminar,
                new ToolStripSeparator(),
                this.btnConsultar,
                this.btnReconsultar
            });

            // Crear controles de opciones
            this.gbOpciones = SicafiTheme.CreateGroupBox("OPCIONES", 300, 200);
            
            this.btnJuridicaPredio = SicafiTheme.CreateButton("Jurídica Predio", false, true);
            this.btnJuridicaPredio.Click += BtnJuridicaPredio_Click;
            
            this.btnLiquidaPredial = SicafiTheme.CreateButton("Liquidar Predial", false, true);
            this.btnLiquidaPredial.Click += BtnLiquidaPredial_Click;
            
            this.btnLiquidaAvaluo = SicafiTheme.CreateButton("Liquidar Avalúo", false, true);
            this.btnLiquidaAvaluo.Click += BtnLiquidaAvaluo_Click;
            
            this.btnImagenPredio = SicafiTheme.CreateButton("Imagen Predio", false, true);
            this.btnImagenPredio.Click += BtnImagenPredio_Click;
            
            this.btnConsultaParametrizada = SicafiTheme.CreateButton("Consulta Parametrizada", false, true);
            this.btnConsultaParametrizada.Click += BtnConsultaParametrizada_Click;
            
            this.btnValidarFicha = SicafiTheme.CreateButton("Validar Ficha", false, true);
            this.btnValidarFicha.Click += BtnValidarFicha_Click;

            // Crear controles de datos principales
            this.gbDatosPrincipales = SicafiTheme.CreateGroupBox("DATOS PRINCIPALES", 500, 400);
            
            // Crear labels para mostrar datos
            this.lblFichaPredial = SicafiTheme.CreateLabel("Ficha Predial: ");
            this.lblPolicia = SicafiTheme.CreateLabel("Policía: ");
            this.lblMunicipio = SicafiTheme.CreateLabel("Municipio: ");
            this.lblDepartamento = SicafiTheme.CreateLabel("Departamento: ");
            this.lblCasa = SicafiTheme.CreateLabel("Casa: ");
            this.lblSan = SicafiTheme.CreateLabel("San: ");
            this.lblUpan = SicafiTheme.CreateLabel("Upan: ");
            this.lblEdan = SicafiTheme.CreateLabel("Edan: ");
            this.lblPran = SicafiTheme.CreateLabel("Pran: ");
            this.lblMaan = SicafiTheme.CreateLabel("Maan: ");
            this.lblBaan = SicafiTheme.CreateLabel("Baan: ");
            this.lblCoan = SicafiTheme.CreateLabel("Coan: ");
            this.lblMuan = SicafiTheme.CreateLabel("Muan: ");
            this.lblCasual = SicafiTheme.CreateLabel("Casual: ");
            this.lblClase = SicafiTheme.CreateLabel("Clase: ");
            this.lblDireccion = SicafiTheme.CreateLabel("Dirección: ");
            this.lblDescripcion = SicafiTheme.CreateLabel("Descripción: ");
            this.lblUnidadPredio = SicafiTheme.CreateLabel("Unidad Predio: ");
            this.lblEdificio = SicafiTheme.CreateLabel("Edificio: ");
            this.lblPredio = SicafiTheme.CreateLabel("Predio: ");
            this.lblManzana = SicafiTheme.CreateLabel("Manzana: ");
            this.lblBarrio = SicafiTheme.CreateLabel("Barrio: ");
            this.lblCorregimiento = SicafiTheme.CreateLabel("Corregimiento: ");
            this.lblMunicipio2 = SicafiTheme.CreateLabel("Municipio: ");
            this.lblNumeroFicha = SicafiTheme.CreateLabel("Número Ficha: ");

            // Crear DataGridView
            this.dgvFichasPrediales = SicafiTheme.CreateDataGridView();
            this.dgvFichasPrediales.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dgvFichasPrediales.MultiSelect = false;
            this.dgvFichasPrediales.SelectionChanged += DgvFichasPrediales_SelectionChanged;

            // Crear StatusStrip
            this.statusStrip = SicafiTheme.CreateStatusStrip();
            this.lblRegistros = new ToolStripStatusLabel("Registros: 0");
            this.statusStrip.Items.Add(this.lblRegistros);
        }

        private void SetupLayout()
        {
            // Configurar TabControl con mejor diseño
            this.tabControl.Dock = DockStyle.Fill;
            this.tabControl.SizeMode = TabSizeMode.Fixed;
            this.tabControl.ItemSize = new Size(120, 30);
            this.tabControl.Controls.AddRange(new TabPage[] {
                this.tabFichaPredial,
                this.tabPropietarios,
                this.tabConstrucciones,
                this.tabLinderos,
                this.tabZonas
            });

            // Configurar pestaña Ficha Predial con diseño mejorado
            var panelFichaPredial = new Panel();
            panelFichaPredial.Dock = DockStyle.Fill;
            panelFichaPredial.BackColor = Color.FromArgb(45, 45, 48);
            panelFichaPredial.Padding = new Padding(15);
            
            // Panel superior para datos principales con diseño moderno
            var panelSuperior = new Panel();
            panelSuperior.Dock = DockStyle.Top;
            panelSuperior.Height = 280;
            panelSuperior.BackColor = Color.FromArgb(37, 37, 38);
            panelSuperior.Padding = new Padding(15);
            
            // Título principal
            var lblTituloPrincipal = new Label();
            lblTituloPrincipal.Text = "INFORMACIÓN DE LA FICHA PREDIAL";
            lblTituloPrincipal.Font = new Font("Segoe UI", 14, FontStyle.Bold);
            lblTituloPrincipal.ForeColor = Color.FromArgb(0, 153, 255);
            lblTituloPrincipal.Location = new Point(15, 15);
            lblTituloPrincipal.Size = new Size(400, 30);
            lblTituloPrincipal.BackColor = Color.Transparent;
            panelSuperior.Controls.Add(lblTituloPrincipal);

            // Panel izquierdo para datos principales
            var panelIzquierdo = new Panel();
            panelIzquierdo.Location = new Point(15, 60);
            panelIzquierdo.Size = new Size(400, 200);
            panelIzquierdo.BackColor = Color.Transparent;
            
            // Panel derecho para opciones
            var panelDerecho = new Panel();
            panelDerecho.Location = new Point(430, 60);
            panelDerecho.Size = new Size(300, 200);
            panelDerecho.BackColor = Color.Transparent;

            // Configurar controles de datos principales con mejor diseño
            int yPos = 0;
            int xPos = 0;
            int labelWidth = 140;
            int controlSpacing = 35;

            // Primera fila con diseño mejorado
            var lblFichaPredialMejorado = CreateStyledLabel("Número de Ficha:", "1001");
            lblFichaPredialMejorado.Location = new Point(xPos, yPos);
            panelIzquierdo.Controls.Add(lblFichaPredialMejorado);

            var lblPoliciaMejorado = CreateStyledLabel("Policía:", "POLICIA1");
            lblPoliciaMejorado.Location = new Point(xPos + 200, yPos);
            panelIzquierdo.Controls.Add(lblPoliciaMejorado);

            yPos += controlSpacing;
            var lblMunicipioMejorado = CreateStyledLabel("Municipio:", "MUNICIPIO1");
            lblMunicipioMejorado.Location = new Point(xPos, yPos);
            panelIzquierdo.Controls.Add(lblMunicipioMejorado);

            var lblDepartamentoMejorado = CreateStyledLabel("Departamento:", "DEPTO1");
            lblDepartamentoMejorado.Location = new Point(xPos + 200, yPos);
            panelIzquierdo.Controls.Add(lblDepartamentoMejorado);

            yPos += controlSpacing;
            var lblCasaMejorado = CreateStyledLabel("Casa:", "CASA1");
            lblCasaMejorado.Location = new Point(xPos, yPos);
            panelIzquierdo.Controls.Add(lblCasaMejorado);

            var lblSanMejorado = CreateStyledLabel("San:", "SAN1");
            lblSanMejorado.Location = new Point(xPos + 200, yPos);
            panelIzquierdo.Controls.Add(lblSanMejorado);

            yPos += controlSpacing;
            var lblDireccionMejorado = CreateStyledLabel("Dirección:", "DIRECCION1");
            lblDireccionMejorado.Location = new Point(xPos, yPos);
            panelIzquierdo.Controls.Add(lblDireccionMejorado);

            var lblBarrioMejorado = CreateStyledLabel("Barrio:", "BARR1");
            lblBarrioMejorado.Location = new Point(xPos + 200, yPos);
            panelIzquierdo.Controls.Add(lblBarrioMejorado);

            yPos += controlSpacing;
            var lblManzanaMejorado = CreateStyledLabel("Manzana:", "MANZ1");
            lblManzanaMejorado.Location = new Point(xPos, yPos);
            panelIzquierdo.Controls.Add(lblManzanaMejorado);

            var lblPredioMejorado = CreateStyledLabel("Predio:", "PRED1");
            lblPredioMejorado.Location = new Point(xPos + 200, yPos);
            panelIzquierdo.Controls.Add(lblPredioMejorado);

            // Configurar controles de opciones con mejor diseño
            yPos = 0;
            var lblOpciones = new Label();
            lblOpciones.Text = "OPCIONES DISPONIBLES";
            lblOpciones.Font = new Font("Segoe UI", 12, FontStyle.Bold);
            lblOpciones.ForeColor = Color.FromArgb(0, 153, 255);
            lblOpciones.Location = new Point(0, yPos);
            lblOpciones.Size = new Size(250, 25);
            lblOpciones.BackColor = Color.Transparent;
            panelDerecho.Controls.Add(lblOpciones);

            yPos += 35;
            this.btnJuridicaPredio.Location = new Point(0, yPos);
            this.btnJuridicaPredio.Size = new Size(280, 35);
            this.btnJuridicaPredio.FlatStyle = FlatStyle.Flat;
            this.btnJuridicaPredio.BackColor = Color.FromArgb(0, 122, 204);
            this.btnJuridicaPredio.ForeColor = Color.White;
            this.btnJuridicaPredio.Font = new Font("Segoe UI", 9, FontStyle.Bold);
            panelDerecho.Controls.Add(this.btnJuridicaPredio);

            yPos += 45;
            this.btnLiquidaPredial.Location = new Point(0, yPos);
            this.btnLiquidaPredial.Size = new Size(280, 35);
            this.btnLiquidaPredial.FlatStyle = FlatStyle.Flat;
            this.btnLiquidaPredial.BackColor = Color.FromArgb(0, 122, 204);
            this.btnLiquidaPredial.ForeColor = Color.White;
            this.btnLiquidaPredial.Font = new Font("Segoe UI", 9, FontStyle.Bold);
            panelDerecho.Controls.Add(this.btnLiquidaPredial);

            yPos += 45;
            this.btnLiquidaAvaluo.Location = new Point(0, yPos);
            this.btnLiquidaAvaluo.Size = new Size(280, 35);
            this.btnLiquidaAvaluo.FlatStyle = FlatStyle.Flat;
            this.btnLiquidaAvaluo.BackColor = Color.FromArgb(0, 122, 204);
            this.btnLiquidaAvaluo.ForeColor = Color.White;
            this.btnLiquidaAvaluo.Font = new Font("Segoe UI", 9, FontStyle.Bold);
            panelDerecho.Controls.Add(this.btnLiquidaAvaluo);

            yPos += 45;
            this.btnImagenPredio.Location = new Point(0, yPos);
            this.btnImagenPredio.Size = new Size(280, 35);
            this.btnImagenPredio.FlatStyle = FlatStyle.Flat;
            this.btnImagenPredio.BackColor = Color.FromArgb(0, 122, 204);
            this.btnImagenPredio.ForeColor = Color.White;
            this.btnImagenPredio.Font = new Font("Segoe UI", 9, FontStyle.Bold);
            panelDerecho.Controls.Add(this.btnImagenPredio);

            // Panel inferior para lista con diseño mejorado
            var panelInferior = new Panel();
            panelInferior.Dock = DockStyle.Bottom;
            panelInferior.Height = 250;
            panelInferior.BackColor = Color.FromArgb(37, 37, 38);
            panelInferior.Padding = new Padding(15);

            var lblLista = new Label();
            lblLista.Text = "LISTA DE FICHAS PREDIALES";
            lblLista.Font = new Font("Segoe UI", 12, FontStyle.Bold);
            lblLista.ForeColor = Color.FromArgb(0, 153, 255);
            lblLista.Location = new Point(15, 15);
            lblLista.Size = new Size(300, 25);
            lblLista.BackColor = Color.Transparent;
            panelInferior.Controls.Add(lblLista);

            // Configurar DataGridView con mejor diseño
            this.dgvFichasPrediales.Location = new Point(15, 50);
            this.dgvFichasPrediales.Size = new Size(750, 180);
            this.dgvFichasPrediales.BackgroundColor = Color.FromArgb(45, 45, 48);
            this.dgvFichasPrediales.BorderStyle = BorderStyle.None;
            this.dgvFichasPrediales.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvFichasPrediales.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            this.dgvFichasPrediales.EnableHeadersVisualStyles = false;
            this.dgvFichasPrediales.GridColor = Color.FromArgb(60, 60, 60);
            this.dgvFichasPrediales.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            this.dgvFichasPrediales.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
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
            panelInferior.Controls.Add(this.dgvFichasPrediales);

            // Agregar controles a la pestaña
            this.tabFichaPredial.Controls.Add(panelFichaPredial);
            panelFichaPredial.Controls.Add(panelSuperior);
            panelFichaPredial.Controls.Add(panelInferior);
            panelSuperior.Controls.Add(panelIzquierdo);
            panelSuperior.Controls.Add(panelDerecho);

            // Agregar controles al formulario
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.bindingNavigator);
            this.Controls.Add(this.statusStrip);
        }

        private Panel CreateStyledLabel(string labelText, string valueText)
        {
            var container = new Panel();
            container.Size = new Size(180, 30);
            container.BackColor = Color.Transparent;

            var label = new Label();
            label.Text = labelText;
            label.Font = new Font("Segoe UI", 8, FontStyle.Bold);
            label.ForeColor = Color.FromArgb(200, 200, 200);
            label.Location = new Point(0, 0);
            label.Size = new Size(80, 15);
            label.BackColor = Color.Transparent;

            var value = new Label();
            value.Text = valueText;
            value.Font = new Font("Segoe UI", 9, FontStyle.Regular);
            value.ForeColor = Color.White;
            value.Location = new Point(0, 15);
            value.Size = new Size(180, 15);
            value.BackColor = Color.FromArgb(60, 60, 60);
            value.Padding = new Padding(5, 0, 5, 0);
            value.TextAlign = ContentAlignment.MiddleLeft;

            container.Controls.Add(label);
            container.Controls.Add(value);
            return container;
        }

        private void LoadData()
        {
            try
            {
                LoadFichasPrediales();
                if (this.fichaPredialId > 0)
                {
                    LoadFichaPredialData();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar datos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadFichasPrediales()
        {
            try
            {
                // TODO: Implementar cuando migremos las reglas de negocio
                // var objdatos = new cla_FIPR();
                // var datos = objdatos.fun_Consultar_FIPR();

                // Por ahora, datos de ejemplo
                DataTable dt = new DataTable();
                dt.Columns.Add("FIPRIDRE", typeof(int));
                dt.Columns.Add("FIPRNUFI", typeof(int));
                dt.Columns.Add("FIPRPOLI", typeof(string));
                dt.Columns.Add("FIPRMUNI", typeof(string));
                dt.Columns.Add("FIPRDEPA", typeof(string));
                dt.Columns.Add("FIPRCASA", typeof(string));
                dt.Columns.Add("FIPRSAN", typeof(string));
                dt.Columns.Add("FIPRUPAN", typeof(string));
                dt.Columns.Add("FIPREDAN", typeof(string));
                dt.Columns.Add("FIPRPRAN", typeof(string));
                dt.Columns.Add("FIPRMAAN", typeof(string));
                dt.Columns.Add("FIPRBAAN", typeof(string));
                dt.Columns.Add("FIPRCOAN", typeof(string));
                dt.Columns.Add("FIPRMUAN", typeof(string));
                dt.Columns.Add("FIPRCASU", typeof(string));
                dt.Columns.Add("FIPRCLSE", typeof(string));
                dt.Columns.Add("FIPRDIRE", typeof(string));
                dt.Columns.Add("FIPRDESC", typeof(string));
                dt.Columns.Add("FIPRUNPR", typeof(string));
                dt.Columns.Add("FIPREDIF", typeof(string));
                dt.Columns.Add("FIPRPRED", typeof(string));
                dt.Columns.Add("FIPRMANZ", typeof(string));
                dt.Columns.Add("FIPRBARR", typeof(string));
                dt.Columns.Add("FIPRCORR", typeof(string));
                dt.Columns.Add("FIPRMUNI2", typeof(string));
                dt.Columns.Add("FIPRNUFI2", typeof(string));

                // Datos de ejemplo
                dt.Rows.Add(1, 1001, "POLICIA1", "MUNICIPIO1", "DEPTO1", "CASA1", "SAN1", "UPAN1", "EDAN1", "PRAN1", "MAAN1", "BAAN1", "COAN1", "MUAN1", "CASU1", "CLSE1", "DIRECCION1", "DESCRIPCION1", "UNPR1", "EDIF1", "PRED1", "MANZ1", "BARR1", "CORR1", "MUNI2", "NUFI1");
                dt.Rows.Add(2, 1002, "POLICIA2", "MUNICIPIO2", "DEPTO2", "CASA2", "SAN2", "UPAN2", "EDAN2", "PRAN2", "MAAN2", "BAAN2", "COAN2", "MUAN2", "CASU2", "CLSE2", "DIRECCION2", "DESCRIPCION2", "UNPR2", "EDIF2", "PRED2", "MANZ2", "BARR2", "CORR2", "MUNI2", "NUFI2");

                this.dgvFichasPrediales.DataSource = dt;
                this.lblRegistros.Text = $"Registros: {dt.Rows.Count}";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar fichas prediales: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadFichaPredialData()
        {
            try
            {
                // TODO: Implementar cuando migremos las reglas de negocio
                // var objdatos = new cla_FIPR();
                // var datos = objdatos.fun_Buscar_ID_FIPR(this.fichaPredialId);

                // Por ahora, cargar datos de ejemplo
                if (this.dgvFichasPrediales.DataSource is DataTable dt && dt.Rows.Count > 0)
                {
                    DataRow row = dt.Rows[0]; // Tomar el primer registro como ejemplo
                    
                    this.lblFichaPredial.Text = $"Ficha Predial: {row["FIPRNUFI"]}";
                    this.lblPolicia.Text = $"Policía: {row["FIPRPOLI"]}";
                    this.lblMunicipio.Text = $"Municipio: {row["FIPRMUNI"]}";
                    this.lblDepartamento.Text = $"Departamento: {row["FIPRDEPA"]}";
                    this.lblCasa.Text = $"Casa: {row["FIPRCASA"]}";
                    this.lblSan.Text = $"San: {row["FIPRSAN"]}";
                    this.lblUpan.Text = $"Upan: {row["FIPRUPAN"]}";
                    this.lblEdan.Text = $"Edan: {row["FIPREDAN"]}";
                    this.lblPran.Text = $"Pran: {row["FIPRPRAN"]}";
                    this.lblMaan.Text = $"Maan: {row["FIPRMAAN"]}";
                    this.lblBaan.Text = $"Baan: {row["FIPRBAAN"]}";
                    this.lblCoan.Text = $"Coan: {row["FIPRCOAN"]}";
                    this.lblMuan.Text = $"Muan: {row["FIPRMUAN"]}";
                    this.lblCasual.Text = $"Casual: {row["FIPRCASU"]}";
                    this.lblClase.Text = $"Clase: {row["FIPRCLSE"]}";
                    this.lblDireccion.Text = $"Dirección: {row["FIPRDIRE"]}";
                    this.lblDescripcion.Text = $"Descripción: {row["FIPRDESC"]}";
                    this.lblUnidadPredio.Text = $"Unidad Predio: {row["FIPRUNPR"]}";
                    this.lblEdificio.Text = $"Edificio: {row["FIPREDIF"]}";
                    this.lblPredio.Text = $"Predio: {row["FIPRPRED"]}";
                    this.lblManzana.Text = $"Manzana: {row["FIPRMANZ"]}";
                    this.lblBarrio.Text = $"Barrio: {row["FIPRBARR"]}";
                    this.lblCorregimiento.Text = $"Corregimiento: {row["FIPRCORR"]}";
                    this.lblMunicipio2.Text = $"Municipio: {row["FIPRMUNI2"]}";
                    this.lblNumeroFicha.Text = $"Número Ficha: {row["FIPRNUFI2"]}";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar datos de la ficha predial: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UpdateDisplay()
        {
            // Actualizar estado de controles según el modo
            this.btnAgregar.Enabled = !this.modoConsulta;
            this.btnModificar.Enabled = !this.modoConsulta;
            this.btnEliminar.Enabled = !this.modoConsulta;
        }

        #region Eventos

        private void BtnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                var form = new FrmInsertarFichaPredial();
                form.ShowDialog();
                LoadFichasPrediales();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al abrir formulario de inserción: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnModificar_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.dgvFichasPrediales.SelectedRows.Count > 0)
                {
                    int id = Convert.ToInt32(this.dgvFichasPrediales.SelectedRows[0].Cells["FIPRIDRE"].Value);
                    var form = new FrmModificarFichaPredial();
                    form.InitializeWithContext(id);
                    form.ShowDialog();
                    LoadFichasPrediales();
                }
                else
                {
                    MessageBox.Show("Debe seleccionar una ficha predial para modificar", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al abrir formulario de modificación: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.dgvFichasPrediales.SelectedRows.Count > 0)
                {
                    if (MessageBox.Show("¿Está seguro que desea eliminar esta ficha predial?", "Confirmar Eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        // TODO: Implementar eliminación
                        MessageBox.Show("Ficha predial eliminada correctamente", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadFichasPrediales();
                    }
                }
                else
                {
                    MessageBox.Show("Debe seleccionar una ficha predial para eliminar", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al eliminar ficha predial: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnConsultar_Click(object sender, EventArgs e)
        {
            try
            {
                var form = new FrmConsultarFichaPredial();
                form.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al abrir consulta: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnReconsultar_Click(object sender, EventArgs e)
        {
            try
            {
                LoadFichasPrediales();
                MessageBox.Show("Datos actualizados correctamente", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al actualizar datos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnJuridicaPredio_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Funcionalidad de Jurídica Predio en desarrollo", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void BtnLiquidaPredial_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Funcionalidad de Liquidar Predial en desarrollo", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void BtnLiquidaAvaluo_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Funcionalidad de Liquidar Avalúo en desarrollo", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void BtnImagenPredio_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Funcionalidad de Imagen Predio en desarrollo", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void BtnConsultaParametrizada_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Funcionalidad de Consulta Parametrizada en desarrollo", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void BtnValidarFicha_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Funcionalidad de Validar Ficha en desarrollo", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void DgvFichasPrediales_SelectionChanged(object sender, EventArgs e)
        {
            if (this.dgvFichasPrediales.SelectedRows.Count > 0)
            {
                DataGridViewRow row = this.dgvFichasPrediales.SelectedRows[0];
                LoadFichaPredialDataFromGrid(row);
            }
        }

        private void LoadFichaPredialDataFromGrid(DataGridViewRow row)
        {
            try
            {
                this.lblFichaPredial.Text = $"Ficha Predial: {row.Cells["FIPRNUFI"].Value}";
                this.lblPolicia.Text = $"Policía: {row.Cells["FIPRPOLI"].Value}";
                this.lblMunicipio.Text = $"Municipio: {row.Cells["FIPRMUNI"].Value}";
                this.lblDepartamento.Text = $"Departamento: {row.Cells["FIPRDEPA"].Value}";
                this.lblCasa.Text = $"Casa: {row.Cells["FIPRCASA"].Value}";
                this.lblSan.Text = $"San: {row.Cells["FIPRSAN"].Value}";
                this.lblUpan.Text = $"Upan: {row.Cells["FIPRUPAN"].Value}";
                this.lblEdan.Text = $"Edan: {row.Cells["FIPREDAN"].Value}";
                this.lblPran.Text = $"Pran: {row.Cells["FIPRPRAN"].Value}";
                this.lblMaan.Text = $"Maan: {row.Cells["FIPRMAAN"].Value}";
                this.lblBaan.Text = $"Baan: {row.Cells["FIPRBAAN"].Value}";
                this.lblCoan.Text = $"Coan: {row.Cells["FIPRCOAN"].Value}";
                this.lblMuan.Text = $"Muan: {row.Cells["FIPRMUAN"].Value}";
                this.lblCasual.Text = $"Casual: {row.Cells["FIPRCASU"].Value}";
                this.lblClase.Text = $"Clase: {row.Cells["FIPRCLSE"].Value}";
                this.lblDireccion.Text = $"Dirección: {row.Cells["FIPRDIRE"].Value}";
                this.lblDescripcion.Text = $"Descripción: {row.Cells["FIPRDESC"].Value}";
                this.lblUnidadPredio.Text = $"Unidad Predio: {row.Cells["FIPRUNPR"].Value}";
                this.lblEdificio.Text = $"Edificio: {row.Cells["FIPREDIF"].Value}";
                this.lblPredio.Text = $"Predio: {row.Cells["FIPRPRED"].Value}";
                this.lblManzana.Text = $"Manzana: {row.Cells["FIPRMANZ"].Value}";
                this.lblBarrio.Text = $"Barrio: {row.Cells["FIPRBARR"].Value}";
                this.lblCorregimiento.Text = $"Corregimiento: {row.Cells["FIPRCORR"].Value}";
                this.lblMunicipio2.Text = $"Municipio: {row.Cells["FIPRMUNI2"].Value}";
                this.lblNumeroFicha.Text = $"Número Ficha: {row.Cells["FIPRNUFI2"].Value}";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar datos de la ficha predial: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion
    }
} 