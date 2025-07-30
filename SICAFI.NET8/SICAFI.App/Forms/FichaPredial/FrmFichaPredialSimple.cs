using System;
using System.Drawing;
using System.Windows.Forms;
using SICAFI.Datos;

namespace SICAFI.App.Forms.FichaPredial
{
    public partial class FrmFichaPredialSimple : Form
    {
        #region Variables

        // Controles de resolución
        private TextBox txtRESODEPA;
        private TextBox txtRESOMUNI;
        private TextBox txtRESOTIRE;
        private TextBox txtRESOCLSE;
        private TextBox txtRESOVIGE;
        private TextBox txtRESOCODI;
        private Label lblRESODEPA;
        private Label lblRESOMUNI;

        // Controles de cédula catastral
        private TextBox txtNroFichaPredial;
        private TextBox txtMunicipio;
        private TextBox txtCorregimiento;
        private TextBox txtBarrio;
        private TextBox txtManzaVered;
        private TextBox txtPredio;
        private TextBox txtEdificio;
        private TextBox txtUnidadPredial;

        // Pestañas
        private Panel pnlTabs;
        private Button btnFichaPredial;
        private Button btnDestinoEconomico;
        private Button btnPropietarios;
        private Button btnConstruccion;
        private Button btnCalificacion;
        private Button btnLinderos;
        private Button btnCartografia;
        private Button btnZonaFisica;
        private Button btnZonaEconomica;
        private Button btnRegistro;

        // Paneles de contenido
        private Panel pnlFichaPredial;
        private Panel pnlDestinoEconomico;
        private Panel pnlPropietarios;
        private Panel pnlConstruccion;
        private Panel pnlCalificacion;
        private Panel pnlLinderos;
        private Panel pnlCartografia;
        private Panel pnlZonaFisica;
        private Panel pnlZonaEconomica;
        private Panel pnlRegistro;

        // BindingNavigator
        private BindingNavigator bindingNavigator;

        #endregion

        #region Constructor

        public FrmFichaPredialSimple()
        {
            InitializeComponent();
            InitializeForm();
        }

        #endregion

        #region Inicialización

        private void InitializeComponent()
        {
            // Configurar formulario
            this.Text = "FICHA PREDIAL";
            this.Size = new System.Drawing.Size(1200, 800);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.WindowState = FormWindowState.Maximized;
            this.BackColor = Color.FromArgb(240, 240, 240); // Color del SICAFI original

            // Crear controles
            CreateControls();

            // Configurar layout
            SetupLayout();

            // Activar primera pestaña
            ActivateTab(btnFichaPredial);
        }

        private void CreateControls()
        {
            // Crear controles de resolución
            this.txtRESODEPA = CreateTextBox();
            this.txtRESOMUNI = CreateTextBox();
            this.txtRESOTIRE = CreateTextBox();
            this.txtRESOCLSE = CreateTextBox();
            this.txtRESOVIGE = CreateTextBox();
            this.txtRESOCODI = CreateTextBox();
            this.lblRESODEPA = CreateLabel("ANTIOQUIA", Color.FromArgb(0, 102, 204));
            this.lblRESOMUNI = CreateLabel("MEDELLÍN", Color.FromArgb(0, 102, 204));

            // Crear controles de cédula catastral
            this.txtNroFichaPredial = CreateTextBox();
            this.txtMunicipio = CreateTextBox();
            this.txtCorregimiento = CreateTextBox();
            this.txtBarrio = CreateTextBox();
            this.txtManzaVered = CreateTextBox();
            this.txtPredio = CreateTextBox();
            this.txtEdificio = CreateTextBox();
            this.txtUnidadPredial = CreateTextBox();

            // Crear pestañas
            CreateTabs();

            // Crear paneles de contenido
            CreateContentPanels();

            // Crear BindingNavigator
            this.bindingNavigator = new BindingNavigator();
            this.bindingNavigator.BackColor = Color.FromArgb(240, 240, 240);
            this.bindingNavigator.Font = new Font("Arial", 9);
        }

        private void CreateTabs()
        {
            this.pnlTabs = new Panel
            {
                Height = 35,
                BackColor = Color.FromArgb(220, 220, 220),
                Dock = DockStyle.Top
            };

            // Crear botones de pestañas con el estilo del SICAFI original
            this.btnFichaPredial = CreateTabButton("Ficha Predial", true);
            this.btnDestinoEconomico = CreateTabButton("Destino Econó.");
            this.btnPropietarios = CreateTabButton("Propietarios");
            this.btnConstruccion = CreateTabButton("Construcción");
            this.btnCalificacion = CreateTabButton("Calificación");
            this.btnLinderos = CreateTabButton("Linderos");
            this.btnCartografia = CreateTabButton("Cartografia");
            this.btnZonaFisica = CreateTabButton("Zona Física");
            this.btnZonaEconomica = CreateTabButton("Zona Económica");
            this.btnRegistro = CreateTabButton("Registro");

            // Posicionar pestañas horizontalmente
            int xPos = 5;
            int yPos = 5;
            int buttonWidth = 110;
            int buttonHeight = 25;
            int spacing = 2;

            this.btnFichaPredial.Location = new Point(xPos, yPos);
            this.btnFichaPredial.Size = new Size(buttonWidth, buttonHeight);
            xPos += buttonWidth + spacing;

            this.btnDestinoEconomico.Location = new Point(xPos, yPos);
            this.btnDestinoEconomico.Size = new Size(buttonWidth, buttonHeight);
            xPos += buttonWidth + spacing;

            this.btnPropietarios.Location = new Point(xPos, yPos);
            this.btnPropietarios.Size = new Size(buttonWidth, buttonHeight);
            xPos += buttonWidth + spacing;

            this.btnConstruccion.Location = new Point(xPos, yPos);
            this.btnConstruccion.Size = new Size(buttonWidth, buttonHeight);
            xPos += buttonWidth + spacing;

            this.btnCalificacion.Location = new Point(xPos, yPos);
            this.btnCalificacion.Size = new Size(buttonWidth, buttonHeight);
            xPos += buttonWidth + spacing;

            this.btnLinderos.Location = new Point(xPos, yPos);
            this.btnLinderos.Size = new Size(buttonWidth, buttonHeight);
            xPos += buttonWidth + spacing;

            this.btnCartografia.Location = new Point(xPos, yPos);
            this.btnCartografia.Size = new Size(buttonWidth, buttonHeight);
            xPos += buttonWidth + spacing;

            this.btnZonaFisica.Location = new Point(xPos, yPos);
            this.btnZonaFisica.Size = new Size(buttonWidth, buttonHeight);
            xPos += buttonWidth + spacing;

            this.btnZonaEconomica.Location = new Point(xPos, yPos);
            this.btnZonaEconomica.Size = new Size(buttonWidth, buttonHeight);
            xPos += buttonWidth + spacing;

            this.btnRegistro.Location = new Point(xPos, yPos);
            this.btnRegistro.Size = new Size(buttonWidth, buttonHeight);

            // Agregar controles al panel de pestañas
            this.pnlTabs.Controls.AddRange(new Control[] {
                this.btnFichaPredial, this.btnDestinoEconomico, this.btnPropietarios,
                this.btnConstruccion, this.btnCalificacion, this.btnLinderos,
                this.btnCartografia, this.btnZonaFisica, this.btnZonaEconomica, this.btnRegistro
            });
        }

        private void CreateContentPanels()
        {
            // Crear paneles de contenido para cada pestaña
            this.pnlFichaPredial = CreateContentPanel();
            this.pnlDestinoEconomico = CreateContentPanel();
            this.pnlPropietarios = CreateContentPanel();
            this.pnlConstruccion = CreateContentPanel();
            this.pnlCalificacion = CreateContentPanel();
            this.pnlLinderos = CreateContentPanel();
            this.pnlCartografia = CreateContentPanel();
            this.pnlZonaFisica = CreateContentPanel();
            this.pnlZonaEconomica = CreateContentPanel();
            this.pnlRegistro = CreateContentPanel();

            // Configurar contenido de cada panel
            SetupFichaPredialContent();
            SetupDestinoEconomicoContent();
            SetupPropietariosContent();
            SetupConstruccionContent();
            SetupCalificacionContent();
            SetupLinderosContent();
            SetupCartografiaContent();
            SetupZonaFisicaContent();
            SetupZonaEconomicaContent();
            SetupRegistroContent();
        }

        private Panel CreateContentPanel()
        {
            return new Panel
            {
                Dock = DockStyle.Fill,
                BackColor = Color.FromArgb(245, 245, 245),
                Padding = new Padding(10),
                Visible = false
            };
        }

        private Button CreateTabButton(string text, bool isActive = false)
        {
            var button = new Button
            {
                Text = text,
                Font = new Font("Arial", 9, FontStyle.Bold),
                FlatStyle = FlatStyle.Flat,
                BackColor = isActive ? Color.FromArgb(245, 245, 245) : Color.FromArgb(220, 220, 220),
                ForeColor = Color.Black,
                Cursor = Cursors.Hand
            };
            button.Click += (s, e) => ActivateTab(button);
            return button;
        }

        private TextBox CreateTextBox()
        {
            return new TextBox
            {
                Font = new Font("Arial", 9),
                BackColor = Color.White,
                BorderStyle = BorderStyle.FixedSingle,
                Size = new Size(120, 20)
            };
        }

        private Label CreateLabel(string text, Color? color = null)
        {
            return new Label
            {
                Text = text,
                Font = new Font("Arial", 9),
                ForeColor = color ?? Color.Black,
                AutoSize = true
            };
        }

        private GroupBox CreateGroupBox(string text)
        {
            return new GroupBox
            {
                Text = text,
                Font = new Font("Arial", 9, FontStyle.Bold),
                BackColor = Color.FromArgb(240, 240, 240),
                ForeColor = Color.Black
            };
        }

        private void SetupLayout()
        {
            // Panel principal que contendrá todo
            Panel mainPanel = new Panel
            {
                Dock = DockStyle.Fill,
                BackColor = Color.FromArgb(240, 240, 240)
            };

            // Sección RESOLUCIÓN
            GroupBox gbResolucion = CreateGroupBox("RESOLUCIÓN");
            gbResolucion.Location = new Point(10, 10);
            gbResolucion.Size = new Size(800, 120);

            int yPos = 20;
            int xPos = 10;

            gbResolucion.Controls.Add(CreateLabel("Departamento:"));
            gbResolucion.Controls.Add(this.txtRESODEPA);
            gbResolucion.Controls.Add(this.lblRESODEPA);
            this.txtRESODEPA.Location = new Point(xPos + 90, yPos);
            this.lblRESODEPA.Location = new Point(xPos + 220, yPos);

            yPos += 25;
            gbResolucion.Controls.Add(CreateLabel("Municipio:"));
            gbResolucion.Controls.Add(this.txtRESOMUNI);
            gbResolucion.Controls.Add(this.lblRESOMUNI);
            this.txtRESOMUNI.Location = new Point(xPos + 90, yPos);
            this.lblRESOMUNI.Location = new Point(xPos + 220, yPos);

            yPos += 25;
            gbResolucion.Controls.Add(CreateLabel("Tipo Resolución:"));
            gbResolucion.Controls.Add(this.txtRESOTIRE);
            this.txtRESOTIRE.Location = new Point(xPos + 90, yPos);

            yPos += 25;
            gbResolucion.Controls.Add(CreateLabel("Clase o Sector:"));
            gbResolucion.Controls.Add(this.txtRESOCLSE);
            this.txtRESOCLSE.Location = new Point(xPos + 90, yPos);

            yPos += 25;
            gbResolucion.Controls.Add(CreateLabel("Vigencia:"));
            gbResolucion.Controls.Add(this.txtRESOVIGE);
            gbResolucion.Controls.Add(CreateLabel("Resolución:"));
            gbResolucion.Controls.Add(this.txtRESOCODI);
            this.txtRESOVIGE.Location = new Point(xPos + 90, yPos);
            this.txtRESOCODI.Location = new Point(xPos + 250, yPos);

            // Sección CÉDULA CATASTRAL
            GroupBox gbCedulaCatastral = CreateGroupBox("CÉDULA CATASTRAL");
            gbCedulaCatastral.Location = new Point(10, 140);
            gbCedulaCatastral.Size = new Size(800, 80);

            yPos = 20;
            gbCedulaCatastral.Controls.Add(CreateLabel("NRO. FICHA PREDIAL:"));
            gbCedulaCatastral.Controls.Add(this.txtNroFichaPredial);
            this.txtNroFichaPredial.Location = new Point(xPos + 120, yPos);
            this.txtNroFichaPredial.Size = new Size(200, 20);

            yPos += 25;
            // Headers grises
            int headerX = 10;
            int textBoxY = 45;
            int spacing = 100;

            gbCedulaCatastral.Controls.Add(CreateLabel("Municipio"));
            gbCedulaCatastral.Controls.Add(CreateLabel("Corregimiento"));
            gbCedulaCatastral.Controls.Add(CreateLabel("Barrio"));
            gbCedulaCatastral.Controls.Add(CreateLabel("Manza / Vered"));
            gbCedulaCatastral.Controls.Add(CreateLabel("Predio"));
            gbCedulaCatastral.Controls.Add(CreateLabel("Edificio"));
            gbCedulaCatastral.Controls.Add(CreateLabel("Unidad Predial"));

            // Posicionar headers
            gbCedulaCatastral.Controls[gbCedulaCatastral.Controls.Count - 7].Location = new Point(headerX, yPos);
            gbCedulaCatastral.Controls[gbCedulaCatastral.Controls.Count - 6].Location = new Point(headerX + spacing, yPos);
            gbCedulaCatastral.Controls[gbCedulaCatastral.Controls.Count - 5].Location = new Point(headerX + spacing * 2, yPos);
            gbCedulaCatastral.Controls[gbCedulaCatastral.Controls.Count - 4].Location = new Point(headerX + spacing * 3, yPos);
            gbCedulaCatastral.Controls[gbCedulaCatastral.Controls.Count - 3].Location = new Point(headerX + spacing * 4, yPos);
            gbCedulaCatastral.Controls[gbCedulaCatastral.Controls.Count - 2].Location = new Point(headerX + spacing * 5, yPos);
            gbCedulaCatastral.Controls[gbCedulaCatastral.Controls.Count - 1].Location = new Point(headerX + spacing * 6, yPos);

            // TextBoxes debajo de los headers
            gbCedulaCatastral.Controls.Add(this.txtMunicipio);
            gbCedulaCatastral.Controls.Add(this.txtCorregimiento);
            gbCedulaCatastral.Controls.Add(this.txtBarrio);
            gbCedulaCatastral.Controls.Add(this.txtManzaVered);
            gbCedulaCatastral.Controls.Add(this.txtPredio);
            gbCedulaCatastral.Controls.Add(this.txtEdificio);
            gbCedulaCatastral.Controls.Add(this.txtUnidadPredial);

            this.txtMunicipio.Location = new Point(headerX, textBoxY);
            this.txtCorregimiento.Location = new Point(headerX + spacing, textBoxY);
            this.txtBarrio.Location = new Point(headerX + spacing * 2, textBoxY);
            this.txtManzaVered.Location = new Point(headerX + spacing * 3, textBoxY);
            this.txtPredio.Location = new Point(headerX + spacing * 4, textBoxY);
            this.txtEdificio.Location = new Point(headerX + spacing * 5, textBoxY);
            this.txtUnidadPredial.Location = new Point(headerX + spacing * 6, textBoxY);

            // Panel de contenido principal (área de trabajo)
            Panel contentPanel = new Panel
            {
                Location = new Point(10, 230),
                Size = new Size(800, 400),
                BackColor = Color.FromArgb(245, 245, 245),
                BorderStyle = BorderStyle.FixedSingle
            };

            // Agregar controles al formulario
            this.Controls.Add(this.pnlTabs);
            this.Controls.Add(this.bindingNavigator);
            this.Controls.Add(mainPanel);

            mainPanel.Controls.Add(gbResolucion);
            mainPanel.Controls.Add(gbCedulaCatastral);
            mainPanel.Controls.Add(contentPanel);

            // Agregar paneles de contenido al panel principal
            contentPanel.Controls.Add(this.pnlFichaPredial);
            contentPanel.Controls.Add(this.pnlDestinoEconomico);
            contentPanel.Controls.Add(this.pnlPropietarios);
            contentPanel.Controls.Add(this.pnlConstruccion);
            contentPanel.Controls.Add(this.pnlCalificacion);
            contentPanel.Controls.Add(this.pnlLinderos);
            contentPanel.Controls.Add(this.pnlCartografia);
            contentPanel.Controls.Add(this.pnlZonaFisica);
            contentPanel.Controls.Add(this.pnlZonaEconomica);
            contentPanel.Controls.Add(this.pnlRegistro);

            // Posicionar BindingNavigator debajo de las pestañas
            this.bindingNavigator.Location = new Point(10, 230);
            this.bindingNavigator.Size = new Size(800, 25);

            // Configurar los paneles de contenido para que ocupen todo el espacio disponible
            foreach (Panel panel in new Panel[] { 
                this.pnlFichaPredial, this.pnlDestinoEconomico, this.pnlPropietarios,
                this.pnlConstruccion, this.pnlCalificacion, this.pnlLinderos,
                this.pnlCartografia, this.pnlZonaFisica, this.pnlZonaEconomica, this.pnlRegistro
            })
            {
                panel.Dock = DockStyle.Fill;
            }
        }

        private void SetupFichaPredialContent()
        {
            // Contenido de la pestaña Ficha Predial
            Label lblTitulo = CreateLabel("INFORMACIÓN DE FICHA PREDIAL");
            lblTitulo.Font = new Font("Arial", 12, FontStyle.Bold);
            lblTitulo.Location = new Point(20, 20);

            // Grupo de información general
            GroupBox gbInformacionGeneral = CreateGroupBox("INFORMACIÓN GENERAL");
            gbInformacionGeneral.Location = new Point(20, 60);
            gbInformacionGeneral.Size = new Size(400, 200);

            Label lblFicha = CreateLabel("Ficha:");
            lblFicha.Location = new Point(10, 25);
            TextBox txtFicha = CreateTextBox();
            txtFicha.Location = new Point(100, 22);
            txtFicha.Size = new Size(150, 20);

            Label lblDestino = CreateLabel("Destino:");
            lblDestino.Location = new Point(10, 55);
            TextBox txtDestino = CreateTextBox();
            txtDestino.Location = new Point(100, 52);
            txtDestino.Size = new Size(150, 20);

            Label lblPropietarios = CreateLabel("Propietarios:");
            lblPropietarios.Location = new Point(10, 85);
            TextBox txtPropietarios = CreateTextBox();
            txtPropietarios.Location = new Point(100, 82);
            txtPropietarios.Size = new Size(150, 20);

            Label lblDireccion = CreateLabel("Dirección:");
            lblDireccion.Location = new Point(10, 115);
            TextBox txtDireccion = CreateTextBox();
            txtDireccion.Location = new Point(100, 112);
            txtDireccion.Size = new Size(250, 20);

            Label lblDescripcion = CreateLabel("Descripción:");
            lblDescripcion.Location = new Point(10, 145);
            TextBox txtDescripcion = CreateTextBox();
            txtDescripcion.Location = new Point(100, 142);
            txtDescripcion.Size = new Size(250, 20);

            gbInformacionGeneral.Controls.AddRange(new Control[] {
                lblFicha, txtFicha, lblDestino, txtDestino, lblPropietarios, txtPropietarios,
                lblDireccion, txtDireccion, lblDescripcion, txtDescripcion
            });

            // Grupo de información catastral
            GroupBox gbInformacionCatastral = CreateGroupBox("INFORMACIÓN CATASTRAL");
            gbInformacionCatastral.Location = new Point(440, 60);
            gbInformacionCatastral.Size = new Size(350, 200);

            Label lblArea = CreateLabel("Área (m²):");
            lblArea.Location = new Point(10, 25);
            TextBox txtArea = CreateTextBox();
            txtArea.Location = new Point(100, 22);
            txtArea.Size = new Size(100, 20);

            Label lblValor = CreateLabel("Valor Catastral:");
            lblValor.Location = new Point(10, 55);
            TextBox txtValor = CreateTextBox();
            txtValor.Location = new Point(100, 52);
            txtValor.Size = new Size(150, 20);

            Label lblEstado = CreateLabel("Estado:");
            lblEstado.Location = new Point(10, 85);
            ComboBox cboEstado = new ComboBox();
            cboEstado.Location = new Point(100, 82);
            cboEstado.Size = new Size(150, 20);
            cboEstado.Items.AddRange(new object[] { "Activo", "Inactivo", "Suspendido" });

            Label lblFecha = CreateLabel("Fecha Registro:");
            lblFecha.Location = new Point(10, 115);
            DateTimePicker dtpFecha = new DateTimePicker();
            dtpFecha.Location = new Point(100, 112);
            dtpFecha.Size = new Size(150, 20);

            Label lblUsuario = CreateLabel("Usuario:");
            lblUsuario.Location = new Point(10, 145);
            TextBox txtUsuario = CreateTextBox();
            txtUsuario.Location = new Point(100, 142);
            txtUsuario.Size = new Size(150, 20);

            gbInformacionCatastral.Controls.AddRange(new Control[] {
                lblArea, txtArea, lblValor, txtValor, lblEstado, cboEstado,
                lblFecha, dtpFecha, lblUsuario, txtUsuario
            });

            // Grupo de información adicional
            GroupBox gbInformacionAdicional = CreateGroupBox("INFORMACIÓN ADICIONAL");
            gbInformacionAdicional.Location = new Point(20, 280);
            gbInformacionAdicional.Size = new Size(770, 120);

            Label lblObservaciones = CreateLabel("Observaciones:");
            lblObservaciones.Location = new Point(10, 25);
            TextBox txtObservaciones = CreateTextBox();
            txtObservaciones.Location = new Point(100, 22);
            txtObservaciones.Size = new Size(650, 20);
            txtObservaciones.Multiline = true;
            txtObservaciones.Height = 60;

            gbInformacionAdicional.Controls.AddRange(new Control[] {
                lblObservaciones, txtObservaciones
            });

            this.pnlFichaPredial.Controls.AddRange(new Control[] {
                lblTitulo, gbInformacionGeneral, gbInformacionCatastral, gbInformacionAdicional
            });
        }

        private void SetupDestinoEconomicoContent()
        {
            // Contenido de la pestaña Destino Económico
            Label lblTitulo = CreateLabel("DESTINO ECONÓMICO");
            lblTitulo.Font = new Font("Arial", 12, FontStyle.Bold);
            lblTitulo.Location = new Point(20, 20);

            GroupBox gbDestinoEconomico = CreateGroupBox("DESTINO ECONÓMICO DEL PREDIO");
            gbDestinoEconomico.Location = new Point(20, 60);
            gbDestinoEconomico.Size = new Size(500, 250);

            Label lblDestinoEco = CreateLabel("Destino Económico:");
            lblDestinoEco.Location = new Point(10, 25);
            ComboBox cboDestinoEco = new ComboBox();
            cboDestinoEco.Location = new Point(150, 22);
            cboDestinoEco.Size = new Size(200, 20);
            cboDestinoEco.Items.AddRange(new object[] { "Residencial", "Comercial", "Industrial", "Mixto" });

            Label lblActividad = CreateLabel("Actividad Principal:");
            lblActividad.Location = new Point(10, 55);
            TextBox txtActividad = CreateTextBox();
            txtActividad.Location = new Point(150, 52);
            txtActividad.Size = new Size(200, 20);

            Label lblDescripcion = CreateLabel("Descripción:");
            lblDescripcion.Location = new Point(10, 85);
            TextBox txtDescripcion = CreateTextBox();
            txtDescripcion.Location = new Point(150, 82);
            txtDescripcion.Size = new Size(300, 20);

            gbDestinoEconomico.Controls.AddRange(new Control[] {
                lblDestinoEco, cboDestinoEco, lblActividad, txtActividad, lblDescripcion, txtDescripcion
            });

            this.pnlDestinoEconomico.Controls.AddRange(new Control[] {
                lblTitulo, gbDestinoEconomico
            });
        }

        private void SetupPropietariosContent()
        {
            // Contenido de la pestaña Propietarios
            Label lblTitulo = CreateLabel("PROPIETARIOS");
            lblTitulo.Font = new Font("Arial", 12, FontStyle.Bold);
            lblTitulo.Location = new Point(20, 20);

            GroupBox gbPropietarios = CreateGroupBox("INFORMACIÓN DE PROPIETARIOS");
            gbPropietarios.Location = new Point(20, 60);
            gbPropietarios.Size = new Size(600, 300);

            // DataGridView para mostrar propietarios
            DataGridView dgvPropietarios = new DataGridView();
            dgvPropietarios.Location = new Point(10, 25);
            dgvPropietarios.Size = new Size(580, 200);
            dgvPropietarios.AllowUserToAddRows = false;
            dgvPropietarios.ReadOnly = true;
            dgvPropietarios.BackgroundColor = Color.White;

            // Agregar columnas
            dgvPropietarios.Columns.Add("Documento", "Documento");
            dgvPropietarios.Columns.Add("Nombre", "Nombre");
            dgvPropietarios.Columns.Add("Porcentaje", "Porcentaje");
            dgvPropietarios.Columns.Add("Tipo", "Tipo");

            // Botones
            Button btnAgregar = new Button();
            btnAgregar.Text = "Agregar Propietario";
            btnAgregar.Location = new Point(10, 240);
            btnAgregar.Size = new Size(120, 30);

            Button btnModificar = new Button();
            btnModificar.Text = "Modificar";
            btnModificar.Location = new Point(140, 240);
            btnModificar.Size = new Size(100, 30);

            Button btnEliminar = new Button();
            btnEliminar.Text = "Eliminar";
            btnEliminar.Location = new Point(250, 240);
            btnEliminar.Size = new Size(100, 30);

            gbPropietarios.Controls.AddRange(new Control[] {
                dgvPropietarios, btnAgregar, btnModificar, btnEliminar
            });

            this.pnlPropietarios.Controls.AddRange(new Control[] {
                lblTitulo, gbPropietarios
            });
        }

        private void SetupConstruccionContent()
        {
            // Contenido de la pestaña Construcción
            Label lblTitulo = CreateLabel("CONSTRUCCIÓN");
            lblTitulo.Font = new Font("Arial", 12, FontStyle.Bold);
            lblTitulo.Location = new Point(20, 20);

            GroupBox gbConstruccion = CreateGroupBox("INFORMACIÓN DE CONSTRUCCIÓN");
            gbConstruccion.Location = new Point(20, 60);
            gbConstruccion.Size = new Size(500, 300);

            Label lblTipoConst = CreateLabel("Tipo de Construcción:");
            lblTipoConst.Location = new Point(10, 25);
            ComboBox cboTipoConst = new ComboBox();
            cboTipoConst.Location = new Point(150, 22);
            cboTipoConst.Size = new Size(200, 20);
            cboTipoConst.Items.AddRange(new object[] { "Casa", "Apartamento", "Local Comercial", "Oficina", "Industrial" });

            Label lblArea = CreateLabel("Área Construida (m²):");
            lblArea.Location = new Point(10, 55);
            TextBox txtArea = CreateTextBox();
            txtArea.Location = new Point(150, 52);
            txtArea.Size = new Size(100, 20);

            Label lblPisos = CreateLabel("Número de Pisos:");
            lblPisos.Location = new Point(10, 85);
            TextBox txtPisos = CreateTextBox();
            txtPisos.Location = new Point(150, 82);
            txtPisos.Size = new Size(100, 20);

            Label lblEstado = CreateLabel("Estado:");
            lblEstado.Location = new Point(10, 115);
            ComboBox cboEstado = new ComboBox();
            cboEstado.Location = new Point(150, 112);
            cboEstado.Size = new Size(200, 20);
            cboEstado.Items.AddRange(new object[] { "Excelente", "Bueno", "Regular", "Malo" });

            gbConstruccion.Controls.AddRange(new Control[] {
                lblTipoConst, cboTipoConst, lblArea, txtArea, lblPisos, txtPisos, lblEstado, cboEstado
            });

            this.pnlConstruccion.Controls.AddRange(new Control[] {
                lblTitulo, gbConstruccion
            });
        }

        private void SetupCalificacionContent()
        {
            // Contenido de la pestaña Calificación
            Label lblTitulo = CreateLabel("CALIFICACIÓN");
            lblTitulo.Font = new Font("Arial", 12, FontStyle.Bold);
            lblTitulo.Location = new Point(20, 20);

            GroupBox gbCalificacion = CreateGroupBox("CALIFICACIÓN DE CONSTRUCCIÓN");
            gbCalificacion.Location = new Point(20, 60);
            gbCalificacion.Size = new Size(500, 250);

            Label lblCalificacion = CreateLabel("Calificación:");
            lblCalificacion.Location = new Point(10, 25);
            ComboBox cboCalificacion = new ComboBox();
            cboCalificacion.Location = new Point(150, 22);
            cboCalificacion.Size = new Size(200, 20);
            cboCalificacion.Items.AddRange(new object[] { "A", "B", "C", "D", "E" });

            Label lblDescripcionCal = CreateLabel("Descripción:");
            lblDescripcionCal.Location = new Point(10, 55);
            TextBox txtDescripcionCal = CreateTextBox();
            txtDescripcionCal.Location = new Point(150, 52);
            txtDescripcionCal.Size = new Size(300, 20);

            gbCalificacion.Controls.AddRange(new Control[] {
                lblCalificacion, cboCalificacion, lblDescripcionCal, txtDescripcionCal
            });

            this.pnlCalificacion.Controls.AddRange(new Control[] {
                lblTitulo, gbCalificacion
            });
        }

        private void SetupLinderosContent()
        {
            // Contenido de la pestaña Linderos
            Label lblTitulo = CreateLabel("LINDEROS");
            lblTitulo.Font = new Font("Arial", 12, FontStyle.Bold);
            lblTitulo.Location = new Point(20, 20);

            GroupBox gbLinderos = CreateGroupBox("LINDEROS DEL PREDIO");
            gbLinderos.Location = new Point(20, 60);
            gbLinderos.Size = new Size(500, 300);

            // DataGridView para linderos
            DataGridView dgvLinderos = new DataGridView();
            dgvLinderos.Location = new Point(10, 25);
            dgvLinderos.Size = new Size(480, 200);
            dgvLinderos.AllowUserToAddRows = false;
            dgvLinderos.ReadOnly = true;
            dgvLinderos.BackgroundColor = Color.White;

            // Agregar columnas
            dgvLinderos.Columns.Add("Punto", "Punto");
            dgvLinderos.Columns.Add("Norte", "Norte");
            dgvLinderos.Columns.Add("Este", "Este");
            dgvLinderos.Columns.Add("Descripción", "Descripción");

            // Botones
            Button btnAgregarLinderos = new Button();
            btnAgregarLinderos.Text = "Agregar Linderos";
            btnAgregarLinderos.Location = new Point(10, 240);
            btnAgregarLinderos.Size = new Size(120, 30);

            gbLinderos.Controls.AddRange(new Control[] {
                dgvLinderos, btnAgregarLinderos
            });

            this.pnlLinderos.Controls.AddRange(new Control[] {
                lblTitulo, gbLinderos
            });
        }

        private void SetupCartografiaContent()
        {
            // Contenido de la pestaña Cartografía
            Label lblTitulo = CreateLabel("CARTOGRAFÍA");
            lblTitulo.Font = new Font("Arial", 12, FontStyle.Bold);
            lblTitulo.Location = new Point(20, 20);

            GroupBox gbCartografia = CreateGroupBox("INFORMACIÓN CARTOGRÁFICA");
            gbCartografia.Location = new Point(20, 60);
            gbCartografia.Size = new Size(500, 250);

            Label lblCoordenadas = CreateLabel("Coordenadas:");
            lblCoordenadas.Location = new Point(10, 25);
            TextBox txtCoordenadas = CreateTextBox();
            txtCoordenadas.Location = new Point(150, 22);
            txtCoordenadas.Size = new Size(200, 20);

            Label lblPlano = CreateLabel("Número de Plano:");
            lblPlano.Location = new Point(10, 55);
            TextBox txtPlano = CreateTextBox();
            txtPlano.Location = new Point(150, 52);
            txtPlano.Size = new Size(200, 20);

            gbCartografia.Controls.AddRange(new Control[] {
                lblCoordenadas, txtCoordenadas, lblPlano, txtPlano
            });

            this.pnlCartografia.Controls.AddRange(new Control[] {
                lblTitulo, gbCartografia
            });
        }

        private void SetupZonaFisicaContent()
        {
            // Contenido de la pestaña Zona Física
            Label lblTitulo = CreateLabel("ZONA FÍSICA");
            lblTitulo.Font = new Font("Arial", 12, FontStyle.Bold);
            lblTitulo.Location = new Point(20, 20);

            GroupBox gbZonaFisica = CreateGroupBox("ZONA FÍSICA");
            gbZonaFisica.Location = new Point(20, 60);
            gbZonaFisica.Size = new Size(500, 250);

            Label lblZonaFisica = CreateLabel("Zona Física:");
            lblZonaFisica.Location = new Point(10, 25);
            ComboBox cboZonaFisica = new ComboBox();
            cboZonaFisica.Location = new Point(150, 22);
            cboZonaFisica.Size = new Size(200, 20);
            cboZonaFisica.Items.AddRange(new object[] { "Urbana", "Rural", "Mixta" });

            Label lblDescripcionZona = CreateLabel("Descripción:");
            lblDescripcionZona.Location = new Point(10, 55);
            TextBox txtDescripcionZona = CreateTextBox();
            txtDescripcionZona.Location = new Point(150, 52);
            txtDescripcionZona.Size = new Size(300, 20);

            gbZonaFisica.Controls.AddRange(new Control[] {
                lblZonaFisica, cboZonaFisica, lblDescripcionZona, txtDescripcionZona
            });

            this.pnlZonaFisica.Controls.AddRange(new Control[] {
                lblTitulo, gbZonaFisica
            });
        }

        private void SetupZonaEconomicaContent()
        {
            // Contenido de la pestaña Zona Económica
            Label lblTitulo = CreateLabel("ZONA ECONÓMICA");
            lblTitulo.Font = new Font("Arial", 12, FontStyle.Bold);
            lblTitulo.Location = new Point(20, 20);

            GroupBox gbZonaEconomica = CreateGroupBox("ZONA ECONÓMICA");
            gbZonaEconomica.Location = new Point(20, 60);
            gbZonaEconomica.Size = new Size(500, 250);

            Label lblZonaEconomica = CreateLabel("Zona Económica:");
            lblZonaEconomica.Location = new Point(10, 25);
            ComboBox cboZonaEconomica = new ComboBox();
            cboZonaEconomica.Location = new Point(150, 22);
            cboZonaEconomica.Size = new Size(200, 20);
            cboZonaEconomica.Items.AddRange(new object[] { "Alta", "Media", "Baja" });

            Label lblValorM2 = CreateLabel("Valor por m²:");
            lblValorM2.Location = new Point(10, 55);
            TextBox txtValorM2 = CreateTextBox();
            txtValorM2.Location = new Point(150, 52);
            txtValorM2.Size = new Size(150, 20);

            gbZonaEconomica.Controls.AddRange(new Control[] {
                lblZonaEconomica, cboZonaEconomica, lblValorM2, txtValorM2
            });

            this.pnlZonaEconomica.Controls.AddRange(new Control[] {
                lblTitulo, gbZonaEconomica
            });
        }

        private void SetupRegistroContent()
        {
            // Contenido de la pestaña Registro
            Label lblTitulo = CreateLabel("REGISTRO");
            lblTitulo.Font = new Font("Arial", 12, FontStyle.Bold);
            lblTitulo.Location = new Point(20, 20);

            GroupBox gbRegistro = CreateGroupBox("INFORMACIÓN DE REGISTRO");
            gbRegistro.Location = new Point(20, 60);
            gbRegistro.Size = new Size(500, 250);

            Label lblFechaRegistro = CreateLabel("Fecha de Registro:");
            lblFechaRegistro.Location = new Point(10, 25);
            DateTimePicker dtpFechaRegistro = new DateTimePicker();
            dtpFechaRegistro.Location = new Point(150, 22);
            dtpFechaRegistro.Size = new Size(200, 20);

            Label lblUsuario = CreateLabel("Usuario:");
            lblUsuario.Location = new Point(10, 55);
            TextBox txtUsuario = CreateTextBox();
            txtUsuario.Location = new Point(150, 52);
            txtUsuario.Size = new Size(200, 20);

            Label lblObservaciones = CreateLabel("Observaciones:");
            lblObservaciones.Location = new Point(10, 85);
            TextBox txtObservaciones = CreateTextBox();
            txtObservaciones.Location = new Point(150, 82);
            txtObservaciones.Size = new Size(300, 20);

            gbRegistro.Controls.AddRange(new Control[] {
                lblFechaRegistro, dtpFechaRegistro, lblUsuario, txtUsuario, lblObservaciones, txtObservaciones
            });

            this.pnlRegistro.Controls.AddRange(new Control[] {
                lblTitulo, gbRegistro
            });
        }

        private void ActivateTab(Button activeButton)
        {
            // Desactivar todas las pestañas
            btnFichaPredial.BackColor = Color.FromArgb(220, 220, 220);
            btnDestinoEconomico.BackColor = Color.FromArgb(220, 220, 220);
            btnPropietarios.BackColor = Color.FromArgb(220, 220, 220);
            btnConstruccion.BackColor = Color.FromArgb(220, 220, 220);
            btnCalificacion.BackColor = Color.FromArgb(220, 220, 220);
            btnLinderos.BackColor = Color.FromArgb(220, 220, 220);
            btnCartografia.BackColor = Color.FromArgb(220, 220, 220);
            btnZonaFisica.BackColor = Color.FromArgb(220, 220, 220);
            btnZonaEconomica.BackColor = Color.FromArgb(220, 220, 220);
            btnRegistro.BackColor = Color.FromArgb(220, 220, 220);

            // Ocultar todos los paneles
            pnlFichaPredial.Visible = false;
            pnlDestinoEconomico.Visible = false;
            pnlPropietarios.Visible = false;
            pnlConstruccion.Visible = false;
            pnlCalificacion.Visible = false;
            pnlLinderos.Visible = false;
            pnlCartografia.Visible = false;
            pnlZonaFisica.Visible = false;
            pnlZonaEconomica.Visible = false;
            pnlRegistro.Visible = false;

            // Activar la pestaña seleccionada
            activeButton.BackColor = Color.FromArgb(245, 245, 245);

            // Mostrar el panel correspondiente
            if (activeButton == btnFichaPredial)
                pnlFichaPredial.Visible = true;
            else if (activeButton == btnDestinoEconomico)
                pnlDestinoEconomico.Visible = true;
            else if (activeButton == btnPropietarios)
                pnlPropietarios.Visible = true;
            else if (activeButton == btnConstruccion)
                pnlConstruccion.Visible = true;
            else if (activeButton == btnCalificacion)
                pnlCalificacion.Visible = true;
            else if (activeButton == btnLinderos)
                pnlLinderos.Visible = true;
            else if (activeButton == btnCartografia)
                pnlCartografia.Visible = true;
            else if (activeButton == btnZonaFisica)
                pnlZonaFisica.Visible = true;
            else if (activeButton == btnZonaEconomica)
                pnlZonaEconomica.Visible = true;
            else if (activeButton == btnRegistro)
                pnlRegistro.Visible = true;
        }

        private void InitializeForm()
        {
            // Aquí se pueden inicializar datos, cargar información, etc.
        }

        #endregion
    }
} 