using System;
using System.Data;
using System.Windows.Forms;
using SICAFI.Datos;
using Microsoft.Data.SqlClient;
using SICAFI.App.Forms.Shared;
using SharedVars = SICAFI.App.Shared;

namespace SICAFI.App.Forms.FichaPredial
{
    public partial class FrmFichPred : Form
    {
        //================================
        //*** FORMULARIO FICHA PREDIAL ***
        //================================

        #region Constructores

        public FrmFichPred(int id)
        {
            SharedVars.VariablesPublicas.vp_FichaPredial = id;
            InitializeComponent();
            InitializeForm();
        }

        public FrmFichPred(DataTable tbl)
        {
            SharedVars.VariablesPublicas.vp_tblConsulta = tbl;
            InitializeComponent();
            InitializeForm();
        }

        public FrmFichPred()
        {
            InitializeComponent();
            InitializeForm();
        }

        #endregion

        #region Variables Locales

        private int id;
        private DataTable tbl;

        // Almacena que tipo de calificación para el form insertar código de calificación
        private string stFPCCTIPO = "";

        private SqlCommand oEjecutar = new SqlCommand();
        private SqlConnection oConexion = new SqlConnection();
        private SqlDataAdapter oAdapter = new SqlDataAdapter();
        private SqlDataReader? oReader;
        private DataSet ds = new DataSet();
        private DataTable dt = new DataTable();

        // variable resolución concatenada
        private string vl_stFIPRCORE = "";

        // Controles del formulario
        private TextBox txtRESODEPA;
        private TextBox txtRESOMUNI;
        private TextBox txtRESOTIRE;
        private TextBox txtRESOCLSE;
        private TextBox txtRESOVIGE;
        private TextBox txtRESOCODI;
        private Label lblRESODESC;
        private Label lblRESODEPA;
        private Label lblRESOMUNI;
        private Label lblRESOTIRE;
        private Label lblRESOCLSE;
        private Label lblRESOVIGE;
        private BindingNavigator BindingNavigator_FICHPRED_1;

        #endregion

        #region Inicialización

        private void InitializeComponent()
        {
            // Configurar formulario
            this.Text = "SICAFI - Ficha Predial";
            this.Size = new System.Drawing.Size(1200, 800);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.WindowState = FormWindowState.Maximized;

            // Aplicar tema SICAFI
            SicafiTheme.ApplyFormTheme(this);

            // Crear controles
            CreateControls();

            // Configurar layout
            SetupLayout();

            // Crear menú
            CreateMenu();
        }

        private void CreateControls()
        {
            // Crear BindingNavigator
            this.BindingNavigator_FICHPRED_1 = SicafiTheme.CreateBindingNavigator();
            this.BindingNavigator_FICHPRED_1.Dock = DockStyle.Bottom;

            // Crear controles de resolución
            this.txtRESODEPA = SicafiTheme.CreateTextBox();
            this.txtRESOMUNI = SicafiTheme.CreateTextBox();
            this.txtRESOTIRE = SicafiTheme.CreateTextBox();
            this.txtRESOCLSE = SicafiTheme.CreateTextBox();
            this.txtRESOVIGE = SicafiTheme.CreateTextBox();
            this.txtRESOCODI = SicafiTheme.CreateTextBox();

            // Crear labels
            this.lblRESODESC = SicafiTheme.CreateLabel("RESOLUCIÓN", true);
            this.lblRESODEPA = SicafiTheme.CreateLabel("Departamento:");
            this.lblRESOMUNI = SicafiTheme.CreateLabel("Municipio:");
            this.lblRESOTIRE = SicafiTheme.CreateLabel("Tipo:");
            this.lblRESOCLSE = SicafiTheme.CreateLabel("Clase:");
            this.lblRESOVIGE = SicafiTheme.CreateLabel("Vigencia:");
        }

        private void SetupLayout()
        {
            // Panel principal
            Panel mainPanel = SicafiTheme.CreateMainPanel();

            // Título
            Label lblTitulo = SicafiTheme.CreateLabel("SISTEMA INTEGRADO DE CATASTRO FISCAL - SICAFI", true);
            lblTitulo.Font = new System.Drawing.Font("Arial", 16, System.Drawing.FontStyle.Bold);
            lblTitulo.Location = new System.Drawing.Point(20, 20);
            lblTitulo.Size = new System.Drawing.Size(600, 30);

            // Grupo de información de resolución
            GroupBox gbResolucion = SicafiTheme.CreateGroupBox("INFORMACIÓN DE RESOLUCIÓN", 800, 150);
            gbResolucion.Location = new System.Drawing.Point(20, 70);

            int yPos = 25;
            int xPos = 10;

            // Primera fila
            gbResolucion.Controls.Add(this.lblRESODEPA);
            gbResolucion.Controls.Add(this.txtRESODEPA);
            gbResolucion.Controls.Add(this.lblRESOMUNI);
            gbResolucion.Controls.Add(this.txtRESOMUNI);
            this.lblRESODEPA.Location = new System.Drawing.Point(xPos, yPos);
            this.txtRESODEPA.Location = new System.Drawing.Point(xPos + 120, yPos);
            this.txtRESODEPA.Size = new System.Drawing.Size(100, 25);
            this.lblRESOMUNI.Location = new System.Drawing.Point(xPos + 250, yPos);
            this.txtRESOMUNI.Location = new System.Drawing.Point(xPos + 320, yPos);
            this.txtRESOMUNI.Size = new System.Drawing.Size(100, 25);

            yPos += 35;
            gbResolucion.Controls.Add(this.lblRESOTIRE);
            gbResolucion.Controls.Add(this.txtRESOTIRE);
            gbResolucion.Controls.Add(this.lblRESOCLSE);
            gbResolucion.Controls.Add(this.txtRESOCLSE);
            this.lblRESOTIRE.Location = new System.Drawing.Point(xPos, yPos);
            this.txtRESOTIRE.Location = new System.Drawing.Point(xPos + 120, yPos);
            this.txtRESOTIRE.Size = new System.Drawing.Size(100, 25);
            this.lblRESOCLSE.Location = new System.Drawing.Point(xPos + 250, yPos);
            this.txtRESOCLSE.Location = new System.Drawing.Point(xPos + 320, yPos);
            this.txtRESOCLSE.Size = new System.Drawing.Size(100, 25);

            yPos += 35;
            gbResolucion.Controls.Add(this.lblRESOVIGE);
            gbResolucion.Controls.Add(this.txtRESOVIGE);
            this.lblRESOVIGE.Location = new System.Drawing.Point(xPos, yPos);
            this.txtRESOVIGE.Location = new System.Drawing.Point(xPos + 120, yPos);
            this.txtRESOVIGE.Size = new System.Drawing.Size(100, 25);

            // Grupo de información de ficha predial
            GroupBox gbFichaPredial = SicafiTheme.CreateGroupBox("INFORMACIÓN DE FICHA PREDIAL", 800, 100);
            gbFichaPredial.Location = new System.Drawing.Point(20, 240);

            Label lblFichaPredial = SicafiTheme.CreateLabel("Ficha Predial:");
            TextBox txtFichaPredial = SicafiTheme.CreateTextBox();
            txtFichaPredial.Text = SharedVars.VariablesPublicas.vp_FichaPredial.ToString();
            txtFichaPredial.ReadOnly = true;

            lblFichaPredial.Location = new System.Drawing.Point(10, 25);
            txtFichaPredial.Location = new System.Drawing.Point(120, 22);
            txtFichaPredial.Size = new System.Drawing.Size(150, 25);

            gbFichaPredial.Controls.Add(lblFichaPredial);
            gbFichaPredial.Controls.Add(txtFichaPredial);

            // Agregar controles al formulario
            this.Controls.Add(lblTitulo);
            this.Controls.Add(mainPanel);
            mainPanel.Controls.Add(gbResolucion);
            mainPanel.Controls.Add(gbFichaPredial);
            this.Controls.Add(this.BindingNavigator_FICHPRED_1);
        }

        private void InitializeForm()
        {
            try
            {
                // Inicializar controles de resolución
                pro_inicializarControlesResolucion();
                
                // Cargar lista de valores de resolución
                pro_listaDeValoresResolucion();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al inicializar formulario: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void pro_inicializarControlesResolucion()
        {
            try
            {
                // Cargar valores por defecto
                            this.txtRESODEPA.Text = SharedVars.VariablesPublicas.vp_ResolucionDepartamento;
            this.txtRESOMUNI.Text = SharedVars.VariablesPublicas.vp_ResolucionMunicipio;
            this.txtRESOTIRE.Text = SharedVars.VariablesPublicas.vp_ResolucionTipo.ToString();
            this.txtRESOCLSE.Text = SharedVars.VariablesPublicas.vp_ResolucionClase.ToString();
            this.txtRESOVIGE.Text = SharedVars.VariablesPublicas.vp_ResolucionVigencia.ToString();
            this.txtRESOCODI.Text = SharedVars.VariablesPublicas.vp_ResolucionResolucion.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al inicializar controles de resolución: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void pro_listaDeValoresResolucion()
        {
            try
            {
                // TODO: Implementar procedimientos de Ficha Predial cuando migremos las reglas de negocio
                // Por ahora, usar valores por defecto
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar lista de valores de resolución: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // TODO: Implementar procedimientos de Ficha Predial cuando migremos las reglas de negocio

        #endregion

        #region Menú y Navegación

        private void CreateMenu()
        {
            // Crear menú principal
            MenuStrip mainMenu = new MenuStrip();
            mainMenu.Dock = DockStyle.Top;

            // Menú Ficha Predial
            ToolStripMenuItem menuFichaPredial = new ToolStripMenuItem("Ficha Predial");
            
            // Submenús
            ToolStripMenuItem menuPropietarios = new ToolStripMenuItem("Propietarios");
            menuPropietarios.Click += (s, e) => OpenPropietarios();
            
            ToolStripMenuItem menuConstrucciones = new ToolStripMenuItem("Construcciones");
            menuConstrucciones.Click += (s, e) => OpenConstrucciones();
            
            ToolStripMenuItem menuLinderos = new ToolStripMenuItem("Linderos");
            menuLinderos.Click += (s, e) => OpenLinderos();

            ToolStripMenuItem menuZonaFisica = new ToolStripMenuItem("Zona Física");
            menuZonaFisica.Click += (s, e) => OpenZonaFisica();

            ToolStripMenuItem menuDestinacionEconomica = new ToolStripMenuItem("Destinación Económica");
            menuDestinacionEconomica.Click += (s, e) => OpenDestinacionEconomica();

            ToolStripMenuItem menuZonaEconomica = new ToolStripMenuItem("Zona Económica");
            menuZonaEconomica.Click += (s, e) => OpenZonaEconomica();

            // Agregar submenús al menú principal
            menuFichaPredial.DropDownItems.Add(menuPropietarios);
            menuFichaPredial.DropDownItems.Add(menuConstrucciones);
            menuFichaPredial.DropDownItems.Add(menuLinderos);
            menuFichaPredial.DropDownItems.Add(menuZonaFisica);
            menuFichaPredial.DropDownItems.Add(menuDestinacionEconomica);
            menuFichaPredial.DropDownItems.Add(menuZonaEconomica);

            // Agregar menú principal
            mainMenu.Items.Add(menuFichaPredial);

            // Agregar menú al formulario
            this.Controls.Add(mainMenu);
        }

        private void OpenPropietarios()
        {
            try
            {
                var form = Propietarios.FrmInsertarPropietario.Instance;
                form.InitializeWithContext(
                    SharedVars.VariablesPublicas.vp_FichaPredial, 
                    1, 
                    SharedVars.VariablesPublicas.vp_ResolucionDepartamento, 
                    SharedVars.VariablesPublicas.vp_ResolucionMunicipio, 
                    SharedVars.VariablesPublicas.vp_ResolucionTipo, 
                    SharedVars.VariablesPublicas.vp_ResolucionClase, 
                    SharedVars.VariablesPublicas.vp_ResolucionVigencia, 
                    SharedVars.VariablesPublicas.vp_ResolucionResolucion);
                form.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al abrir Propietarios: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void OpenConstrucciones()
        {
            try
            {
                var form = Construcciones.FrmInsertarConstruccion.Instance;
                form.InitializeWithContext(
                    SharedVars.VariablesPublicas.vp_FichaPredial, 
                    1, 
                    SharedVars.VariablesPublicas.vp_ResolucionDepartamento, 
                    SharedVars.VariablesPublicas.vp_ResolucionMunicipio, 
                    SharedVars.VariablesPublicas.vp_ResolucionTipo, 
                    SharedVars.VariablesPublicas.vp_ResolucionClase, 
                    SharedVars.VariablesPublicas.vp_ResolucionVigencia, 
                    SharedVars.VariablesPublicas.vp_ResolucionResolucion);
                form.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al abrir Construcciones: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void OpenLinderos()
        {
            try
            {
                var form = Linderos.FrmInsertarLinderos.Instance;
                form.InitializeWithContext(
                    SharedVars.VariablesPublicas.vp_FichaPredial, 
                    1, 
                    SharedVars.VariablesPublicas.vp_ResolucionDepartamento, 
                    SharedVars.VariablesPublicas.vp_ResolucionMunicipio, 
                    SharedVars.VariablesPublicas.vp_ResolucionTipo, 
                    SharedVars.VariablesPublicas.vp_ResolucionClase, 
                    SharedVars.VariablesPublicas.vp_ResolucionVigencia, 
                    SharedVars.VariablesPublicas.vp_ResolucionResolucion);
                form.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al abrir Linderos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void OpenZonaFisica()
        {
            try
            {
                MessageBox.Show("Formulario de Zona Física aún no migrado", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al abrir Zona Física: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void OpenDestinacionEconomica()
        {
            try
            {
                MessageBox.Show("Formulario de Destinación Económica aún no migrado", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al abrir Destinación Económica: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void OpenZonaEconomica()
        {
            try
            {
                MessageBox.Show("Formulario de Zona Económica aún no migrado", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al abrir Zona Económica: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion
    }
} 