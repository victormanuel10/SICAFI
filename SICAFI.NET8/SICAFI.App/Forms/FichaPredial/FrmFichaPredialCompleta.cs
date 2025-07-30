using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using SICAFI.App.Forms.Shared;
using SICAFI.Datos;

namespace SICAFI.App.Forms.FichaPredial
{
    public partial class FrmFichaPredialCompleta : Form
    {
        private DataTable dtFichaPredial;
        private ConsultasDB consultas;
        private bool modoEdicion = false;
        private string numeroFichaActual = "";

        public FrmFichaPredialCompleta()
        {
            InitializeComponent();
            InitializeForm();
        }

        public FrmFichaPredialCompleta(string numeroFicha)
        {
            numeroFichaActual = numeroFicha;
            InitializeComponent();
            InitializeForm();
            CargarFichaPredial(numeroFicha);
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();

            // Configurar formulario
            this.Text = "Ficha Predial - SICAFI";
            this.Size = new Size(1400, 900);
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
            Panel mainPanel = SicafiTheme.CreateMainPanel();

            // Título del formulario
            Label titleLabel = SicafiTheme.CreateLabel("FICHA PREDIAL", true, true);
            titleLabel.Dock = DockStyle.Top;
            titleLabel.TextAlign = ContentAlignment.MiddleCenter;
            titleLabel.Height = 50;
            titleLabel.Margin = new Padding(0, 0, 0, SicafiTheme.LargeMargin);
            mainPanel.Controls.Add(titleLabel);

            // Panel de contenido principal
            Panel contentPanel = new Panel
            {
                Dock = DockStyle.Fill,
                BackColor = Color.Transparent
            };

            // Crear TabControl para organizar las secciones
            TabControl tabControl = new TabControl
            {
                Dock = DockStyle.Fill,
                BackColor = SicafiTheme.BackgroundColor,
                ForeColor = SicafiTheme.TextPrimaryColor
            };

            // Tab 1: Información General
            TabPage tabGeneral = new TabPage("Información General");
            tabGeneral.BackColor = SicafiTheme.BackgroundColor;
            tabGeneral.ForeColor = SicafiTheme.TextPrimaryColor;
            CreateTabGeneral(tabGeneral);
            tabControl.TabPages.Add(tabGeneral);

            // Tab 2: Propietarios
            TabPage tabPropietarios = new TabPage("Propietarios");
            tabPropietarios.BackColor = SicafiTheme.BackgroundColor;
            tabPropietarios.ForeColor = SicafiTheme.TextPrimaryColor;
            CreateTabPropietarios(tabPropietarios);
            tabControl.TabPages.Add(tabPropietarios);

            // Tab 3: Construcciones
            TabPage tabConstrucciones = new TabPage("Construcciones");
            tabConstrucciones.BackColor = SicafiTheme.BackgroundColor;
            tabConstrucciones.ForeColor = SicafiTheme.TextPrimaryColor;
            CreateTabConstrucciones(tabConstrucciones);
            tabControl.TabPages.Add(tabConstrucciones);

            // Tab 4: Linderos
            TabPage tabLinderos = new TabPage("Linderos");
            tabLinderos.BackColor = SicafiTheme.BackgroundColor;
            tabLinderos.ForeColor = SicafiTheme.TextPrimaryColor;
            CreateTabLinderos(tabLinderos);
            tabControl.TabPages.Add(tabLinderos);

            // Tab 5: Zona Económica
            TabPage tabZonaEconomica = new TabPage("Zona Económica");
            tabZonaEconomica.BackColor = SicafiTheme.BackgroundColor;
            tabZonaEconomica.ForeColor = SicafiTheme.TextPrimaryColor;
            CreateTabZonaEconomica(tabZonaEconomica);
            tabControl.TabPages.Add(tabZonaEconomica);

            contentPanel.Controls.Add(tabControl);

            // Panel de botones de acción
            Panel actionPanel = new Panel
            {
                Dock = DockStyle.Bottom,
                Height = 70,
                BackColor = Color.Transparent,
                Padding = new Padding(0, SicafiTheme.LargeMargin, 0, 0)
            };

            FlowLayoutPanel actionButtonFlow = SicafiTheme.CreateFlowLayoutPanel();
            actionButtonFlow.Dock = DockStyle.Fill;
            actionButtonFlow.FlowDirection = FlowDirection.RightToLeft;

            Button btnCerrar = SicafiTheme.CreateButton("Cerrar", false, true);
            btnCerrar.Click += BtnCerrar_Click;

            Button btnEliminar = SicafiTheme.CreateButton("Eliminar", false, true);
            btnEliminar.Click += BtnEliminar_Click;

            Button btnGuardar = SicafiTheme.CreateButton("Guardar", true, true);
            btnGuardar.Click += BtnGuardar_Click;

            Button btnNuevo = SicafiTheme.CreateButton("Nuevo", false, true);
            btnNuevo.Click += BtnNuevo_Click;

            actionButtonFlow.Controls.Add(btnCerrar);
            actionButtonFlow.Controls.Add(btnEliminar);
            actionButtonFlow.Controls.Add(btnGuardar);
            actionButtonFlow.Controls.Add(btnNuevo);
            actionPanel.Controls.Add(actionButtonFlow);

            // Agregar controles al panel de contenido
            contentPanel.Controls.Add(actionPanel);

            // Agregar panel de contenido al panel principal
            mainPanel.Controls.Add(contentPanel);

            // Agregar panel principal al formulario
            this.Controls.Add(mainPanel);
        }

        private void CreateTabGeneral(TabPage tab)
        {
            // Panel principal del tab
            Panel panel = new Panel
            {
                Dock = DockStyle.Fill,
                BackColor = Color.Transparent,
                Padding = new Padding(SicafiTheme.LargePadding)
            };

            // GroupBox de información básica
            GroupBox gbInfoBasica = SicafiTheme.CreateGroupBox("Información Básica", 1200, 200);
            gbInfoBasica.Location = new Point(0, 0);

            TableLayoutPanel layoutBasica = SicafiTheme.CreateTableLayoutPanel();
            layoutBasica.ColumnCount = 4;
            layoutBasica.RowCount = 4;
            layoutBasica.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 15F));
            layoutBasica.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 35F));
            layoutBasica.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 15F));
            layoutBasica.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 35F));
            layoutBasica.RowStyles.Add(new RowStyle(SizeType.Absolute, 35F));
            layoutBasica.RowStyles.Add(new RowStyle(SizeType.Absolute, 35F));
            layoutBasica.RowStyles.Add(new RowStyle(SizeType.Absolute, 35F));
            layoutBasica.RowStyles.Add(new RowStyle(SizeType.Absolute, 35F));
            layoutBasica.Dock = DockStyle.Fill;
            layoutBasica.Padding = new Padding(SicafiTheme.LargePadding);

            // Primera fila
            Label lblNumeroFicha = SicafiTheme.CreateLabel("Número de Ficha:");
            TextBox txtNumeroFicha = SicafiTheme.CreateTextBox();
            txtNumeroFicha.Name = "txtNumeroFicha";
            txtNumeroFicha.ReadOnly = true;

            Label lblDireccion = SicafiTheme.CreateLabel("Dirección:");
            TextBox txtDireccion = SicafiTheme.CreateTextBox();
            txtDireccion.Name = "txtDireccion";

            // Segunda fila
            Label lblMunicipio = SicafiTheme.CreateLabel("Municipio:");
            TextBox txtMunicipio = SicafiTheme.CreateTextBox();
            txtMunicipio.Name = "txtMunicipio";

            Label lblBarrio = SicafiTheme.CreateLabel("Barrio:");
            TextBox txtBarrio = SicafiTheme.CreateTextBox();
            txtBarrio.Name = "txtBarrio";

            // Tercera fila
            Label lblCorregimiento = SicafiTheme.CreateLabel("Corregimiento:");
            TextBox txtCorregimiento = SicafiTheme.CreateTextBox();
            txtCorregimiento.Name = "txtCorregimiento";

            Label lblManzana = SicafiTheme.CreateLabel("Manzana:");
            TextBox txtManzana = SicafiTheme.CreateTextBox();
            txtManzana.Name = "txtManzana";

            // Cuarta fila
            Label lblPredio = SicafiTheme.CreateLabel("Predio:");
            TextBox txtPredio = SicafiTheme.CreateTextBox();
            txtPredio.Name = "txtPredio";

            Label lblEdificio = SicafiTheme.CreateLabel("Edificio:");
            TextBox txtEdificio = SicafiTheme.CreateTextBox();
            txtEdificio.Name = "txtEdificio";

            // Agregar controles al layout
            layoutBasica.Controls.Add(lblNumeroFicha, 0, 0);
            layoutBasica.Controls.Add(txtNumeroFicha, 1, 0);
            layoutBasica.Controls.Add(lblDireccion, 2, 0);
            layoutBasica.Controls.Add(txtDireccion, 3, 0);
            layoutBasica.Controls.Add(lblMunicipio, 0, 1);
            layoutBasica.Controls.Add(txtMunicipio, 1, 1);
            layoutBasica.Controls.Add(lblBarrio, 2, 1);
            layoutBasica.Controls.Add(txtBarrio, 3, 1);
            layoutBasica.Controls.Add(lblCorregimiento, 0, 2);
            layoutBasica.Controls.Add(txtCorregimiento, 1, 2);
            layoutBasica.Controls.Add(lblManzana, 2, 2);
            layoutBasica.Controls.Add(txtManzana, 3, 2);
            layoutBasica.Controls.Add(lblPredio, 0, 3);
            layoutBasica.Controls.Add(txtPredio, 1, 3);
            layoutBasica.Controls.Add(lblEdificio, 2, 3);
            layoutBasica.Controls.Add(txtEdificio, 3, 3);

            gbInfoBasica.Controls.Add(layoutBasica);

            // GroupBox de información adicional
            GroupBox gbInfoAdicional = SicafiTheme.CreateGroupBox("Información Adicional", 1200, 150);
            gbInfoAdicional.Location = new Point(0, 220);

            TableLayoutPanel layoutAdicional = SicafiTheme.CreateTableLayoutPanel();
            layoutAdicional.ColumnCount = 4;
            layoutAdicional.RowCount = 3;
            layoutAdicional.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 15F));
            layoutAdicional.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 35F));
            layoutAdicional.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 15F));
            layoutAdicional.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 35F));
            layoutAdicional.RowStyles.Add(new RowStyle(SizeType.Absolute, 35F));
            layoutAdicional.RowStyles.Add(new RowStyle(SizeType.Absolute, 35F));
            layoutAdicional.RowStyles.Add(new RowStyle(SizeType.Absolute, 35F));
            layoutAdicional.Dock = DockStyle.Fill;
            layoutAdicional.Padding = new Padding(SicafiTheme.LargePadding);

            // Primera fila
            Label lblUnidadPredial = SicafiTheme.CreateLabel("Unidad Predial:");
            TextBox txtUnidadPredial = SicafiTheme.CreateTextBox();
            txtUnidadPredial.Name = "txtUnidadPredial";

            Label lblSector = SicafiTheme.CreateLabel("Sector:");
            TextBox txtSector = SicafiTheme.CreateTextBox();
            txtSector.Name = "txtSector";

            // Segunda fila
            Label lblArea = SicafiTheme.CreateLabel("Área (m²):");
            TextBox txtArea = SicafiTheme.CreateTextBox();
            txtArea.Name = "txtArea";

            Label lblValorAvaluo = SicafiTheme.CreateLabel("Valor Avalúo:");
            TextBox txtValorAvaluo = SicafiTheme.CreateTextBox();
            txtValorAvaluo.Name = "txtValorAvaluo";

            // Tercera fila
            Label lblFechaAvaluo = SicafiTheme.CreateLabel("Fecha Avalúo:");
            DateTimePicker dtpFechaAvaluo = new DateTimePicker();
            dtpFechaAvaluo.Name = "dtpFechaAvaluo";
            dtpFechaAvaluo.Format = DateTimePickerFormat.Short;
            dtpFechaAvaluo.BackColor = SicafiTheme.SurfaceColor;
            dtpFechaAvaluo.ForeColor = SicafiTheme.TextPrimaryColor;
            dtpFechaAvaluo.Font = SicafiTheme.NormalFont;

            Label lblEstado = SicafiTheme.CreateLabel("Estado:");
            ComboBox cboEstado = SicafiTheme.CreateComboBox();
            cboEstado.Name = "cboEstado";
            cboEstado.Items.AddRange(new object[] { "Activo", "Inactivo", "En Trámite" });

            // Agregar controles al layout
            layoutAdicional.Controls.Add(lblUnidadPredial, 0, 0);
            layoutAdicional.Controls.Add(txtUnidadPredial, 1, 0);
            layoutAdicional.Controls.Add(lblSector, 2, 0);
            layoutAdicional.Controls.Add(txtSector, 3, 0);
            layoutAdicional.Controls.Add(lblArea, 0, 1);
            layoutAdicional.Controls.Add(txtArea, 1, 1);
            layoutAdicional.Controls.Add(lblValorAvaluo, 2, 1);
            layoutAdicional.Controls.Add(txtValorAvaluo, 3, 1);
            layoutAdicional.Controls.Add(lblFechaAvaluo, 0, 2);
            layoutAdicional.Controls.Add(dtpFechaAvaluo, 1, 2);
            layoutAdicional.Controls.Add(lblEstado, 2, 2);
            layoutAdicional.Controls.Add(cboEstado, 3, 2);

            gbInfoAdicional.Controls.Add(layoutAdicional);

            panel.Controls.Add(gbInfoBasica);
            panel.Controls.Add(gbInfoAdicional);
            tab.Controls.Add(panel);
        }

        private void CreateTabPropietarios(TabPage tab)
        {
            Panel panel = new Panel
            {
                Dock = DockStyle.Fill,
                BackColor = Color.Transparent,
                Padding = new Padding(SicafiTheme.LargePadding)
            };

            // DataGridView para propietarios
            DataGridView dgvPropietarios = SicafiTheme.CreateDataGridView();
            dgvPropietarios.Name = "dgvPropietarios";
            dgvPropietarios.Dock = DockStyle.Fill;
            dgvPropietarios.DoubleClick += DgvPropietarios_DoubleClick;

            // Panel de botones para propietarios
            Panel buttonPanel = new Panel
            {
                Dock = DockStyle.Bottom,
                Height = 50,
                BackColor = Color.Transparent
            };

            FlowLayoutPanel buttonFlow = SicafiTheme.CreateFlowLayoutPanel();
            buttonFlow.Dock = DockStyle.Fill;
            buttonFlow.FlowDirection = FlowDirection.RightToLeft;

            Button btnEliminarPropietario = SicafiTheme.CreateButton("Eliminar", false, false);
            btnEliminarPropietario.Click += BtnEliminarPropietario_Click;

            Button btnModificarPropietario = SicafiTheme.CreateButton("Modificar", false, false);
            btnModificarPropietario.Click += BtnModificarPropietario_Click;

            Button btnAgregarPropietario = SicafiTheme.CreateButton("Agregar", true, false);
            btnAgregarPropietario.Click += BtnAgregarPropietario_Click;

            buttonFlow.Controls.Add(btnEliminarPropietario);
            buttonFlow.Controls.Add(btnModificarPropietario);
            buttonFlow.Controls.Add(btnAgregarPropietario);
            buttonPanel.Controls.Add(buttonFlow);

            panel.Controls.Add(dgvPropietarios);
            panel.Controls.Add(buttonPanel);
            tab.Controls.Add(panel);
        }

        private void CreateTabConstrucciones(TabPage tab)
        {
            Panel panel = new Panel
            {
                Dock = DockStyle.Fill,
                BackColor = Color.Transparent,
                Padding = new Padding(SicafiTheme.LargePadding)
            };

            // DataGridView para construcciones
            DataGridView dgvConstrucciones = SicafiTheme.CreateDataGridView();
            dgvConstrucciones.Name = "dgvConstrucciones";
            dgvConstrucciones.Dock = DockStyle.Fill;
            dgvConstrucciones.DoubleClick += DgvConstrucciones_DoubleClick;

            // Panel de botones para construcciones
            Panel buttonPanel = new Panel
            {
                Dock = DockStyle.Bottom,
                Height = 50,
                BackColor = Color.Transparent
            };

            FlowLayoutPanel buttonFlow = SicafiTheme.CreateFlowLayoutPanel();
            buttonFlow.Dock = DockStyle.Fill;
            buttonFlow.FlowDirection = FlowDirection.RightToLeft;

            Button btnEliminarConstruccion = SicafiTheme.CreateButton("Eliminar", false, false);
            btnEliminarConstruccion.Click += BtnEliminarConstruccion_Click;

            Button btnModificarConstruccion = SicafiTheme.CreateButton("Modificar", false, false);
            btnModificarConstruccion.Click += BtnModificarConstruccion_Click;

            Button btnAgregarConstruccion = SicafiTheme.CreateButton("Agregar", true, false);
            btnAgregarConstruccion.Click += BtnAgregarConstruccion_Click;

            buttonFlow.Controls.Add(btnEliminarConstruccion);
            buttonFlow.Controls.Add(btnModificarConstruccion);
            buttonFlow.Controls.Add(btnAgregarConstruccion);
            buttonPanel.Controls.Add(buttonFlow);

            panel.Controls.Add(dgvConstrucciones);
            panel.Controls.Add(buttonPanel);
            tab.Controls.Add(panel);
        }

        private void CreateTabLinderos(TabPage tab)
        {
            Panel panel = new Panel
            {
                Dock = DockStyle.Fill,
                BackColor = Color.Transparent,
                Padding = new Padding(SicafiTheme.LargePadding)
            };

            // DataGridView para linderos
            DataGridView dgvLinderos = SicafiTheme.CreateDataGridView();
            dgvLinderos.Name = "dgvLinderos";
            dgvLinderos.Dock = DockStyle.Fill;
            dgvLinderos.DoubleClick += DgvLinderos_DoubleClick;

            // Panel de botones para linderos
            Panel buttonPanel = new Panel
            {
                Dock = DockStyle.Bottom,
                Height = 50,
                BackColor = Color.Transparent
            };

            FlowLayoutPanel buttonFlow = SicafiTheme.CreateFlowLayoutPanel();
            buttonFlow.Dock = DockStyle.Fill;
            buttonFlow.FlowDirection = FlowDirection.RightToLeft;

            Button btnEliminarLinderos = SicafiTheme.CreateButton("Eliminar", false, false);
            btnEliminarLinderos.Click += BtnEliminarLinderos_Click;

            Button btnModificarLinderos = SicafiTheme.CreateButton("Modificar", false, false);
            btnModificarLinderos.Click += BtnModificarLinderos_Click;

            Button btnAgregarLinderos = SicafiTheme.CreateButton("Agregar", true, false);
            btnAgregarLinderos.Click += BtnAgregarLinderos_Click;

            buttonFlow.Controls.Add(btnEliminarLinderos);
            buttonFlow.Controls.Add(btnModificarLinderos);
            buttonFlow.Controls.Add(btnAgregarLinderos);
            buttonPanel.Controls.Add(buttonFlow);

            panel.Controls.Add(dgvLinderos);
            panel.Controls.Add(buttonPanel);
            tab.Controls.Add(panel);
        }

        private void CreateTabZonaEconomica(TabPage tab)
        {
            Panel panel = new Panel
            {
                Dock = DockStyle.Fill,
                BackColor = Color.Transparent,
                Padding = new Padding(SicafiTheme.LargePadding)
            };

            // DataGridView para zona económica
            DataGridView dgvZonaEconomica = SicafiTheme.CreateDataGridView();
            dgvZonaEconomica.Name = "dgvZonaEconomica";
            dgvZonaEconomica.Dock = DockStyle.Fill;
            dgvZonaEconomica.DoubleClick += DgvZonaEconomica_DoubleClick;

            // Panel de botones para zona económica
            Panel buttonPanel = new Panel
            {
                Dock = DockStyle.Bottom,
                Height = 50,
                BackColor = Color.Transparent
            };

            FlowLayoutPanel buttonFlow = SicafiTheme.CreateFlowLayoutPanel();
            buttonFlow.Dock = DockStyle.Fill;
            buttonFlow.FlowDirection = FlowDirection.RightToLeft;

            Button btnEliminarZonaEconomica = SicafiTheme.CreateButton("Eliminar", false, false);
            btnEliminarZonaEconomica.Click += BtnEliminarZonaEconomica_Click;

            Button btnModificarZonaEconomica = SicafiTheme.CreateButton("Modificar", false, false);
            btnModificarZonaEconomica.Click += BtnModificarZonaEconomica_Click;

            Button btnAgregarZonaEconomica = SicafiTheme.CreateButton("Agregar", true, false);
            btnAgregarZonaEconomica.Click += BtnAgregarZonaEconomica_Click;

            buttonFlow.Controls.Add(btnEliminarZonaEconomica);
            buttonFlow.Controls.Add(btnModificarZonaEconomica);
            buttonFlow.Controls.Add(btnAgregarZonaEconomica);
            buttonPanel.Controls.Add(buttonFlow);

            panel.Controls.Add(dgvZonaEconomica);
            panel.Controls.Add(buttonPanel);
            tab.Controls.Add(panel);
        }

        private void InitializeForm()
        {
            try
            {
                consultas = new ConsultasDB();
                
                if (string.IsNullOrEmpty(numeroFichaActual))
                {
                    // Modo nuevo
                    modoEdicion = false;
                    GenerarNuevoNumeroFicha();
                }
                else
                {
                    // Modo edición
                    modoEdicion = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al inicializar formulario: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void GenerarNuevoNumeroFicha()
        {
            try
            {
                // Generar un número de ficha único (esto debería venir de la base de datos)
                string nuevoNumero = DateTime.Now.ToString("yyyyMMddHHmmss");
                TextBox txtNumeroFicha = (TextBox)this.Controls.Find("txtNumeroFicha", true)[0];
                if (txtNumeroFicha != null)
                {
                    txtNumeroFicha.Text = nuevoNumero;
                    numeroFichaActual = nuevoNumero;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al generar número de ficha: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CargarFichaPredial(string numeroFicha)
        {
            try
            {
                // Obtener datos de la ficha predial desde la base de datos
                DataTable dtFicha = consultas.ObtenerFichaPredialCompleta(numeroFicha);
                
                if (dtFicha != null && dtFicha.Rows.Count > 0)
                {
                    DataRow row = dtFicha.Rows[0];
                    
                    // Cargar datos en los controles del formulario
                    CargarDatosEnControles(row);
                }
                else
                {
                    MessageBox.Show($"No se encontró la ficha predial número: {numeroFicha}", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar ficha predial: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CargarDatosEnControles(DataRow row)
        {
            try
            {
                // Buscar y llenar los controles con los datos
                TextBox txtNumeroFicha = (TextBox)this.Controls.Find("txtNumeroFicha", true)[0];
                TextBox txtDireccion = (TextBox)this.Controls.Find("txtDireccion", true)[0];
                TextBox txtMunicipio = (TextBox)this.Controls.Find("txtMunicipio", true)[0];
                TextBox txtBarrio = (TextBox)this.Controls.Find("txtBarrio", true)[0];
                TextBox txtCorregimiento = (TextBox)this.Controls.Find("txtCorregimiento", true)[0];
                TextBox txtManzana = (TextBox)this.Controls.Find("txtManzana", true)[0];
                TextBox txtPredio = (TextBox)this.Controls.Find("txtPredio", true)[0];
                TextBox txtEdificio = (TextBox)this.Controls.Find("txtEdificio", true)[0];
                TextBox txtUnidadPredial = (TextBox)this.Controls.Find("txtUnidadPredial", true)[0];
                TextBox txtSector = (TextBox)this.Controls.Find("txtSector", true)[0];
                TextBox txtArea = (TextBox)this.Controls.Find("txtArea", true)[0];
                TextBox txtValorAvaluo = (TextBox)this.Controls.Find("txtValorAvaluo", true)[0];
                DateTimePicker dtpFechaAvaluo = (DateTimePicker)this.Controls.Find("dtpFechaAvaluo", true)[0];
                ComboBox cboEstado = (ComboBox)this.Controls.Find("cboEstado", true)[0];

                // Asignar valores a los controles
                if (txtNumeroFicha != null) txtNumeroFicha.Text = row["NumeroFicha"]?.ToString() ?? "";
                if (txtDireccion != null) txtDireccion.Text = row["Direccion"]?.ToString() ?? "";
                if (txtMunicipio != null) txtMunicipio.Text = row["Municipio"]?.ToString() ?? "";
                if (txtBarrio != null) txtBarrio.Text = row["Barrio"]?.ToString() ?? "";
                if (txtCorregimiento != null) txtCorregimiento.Text = row["Corregimiento"]?.ToString() ?? "";
                if (txtManzana != null) txtManzana.Text = row["Manzana"]?.ToString() ?? "";
                if (txtPredio != null) txtPredio.Text = row["Predio"]?.ToString() ?? "";
                if (txtEdificio != null) txtEdificio.Text = row["Edificio"]?.ToString() ?? "";
                if (txtUnidadPredial != null) txtUnidadPredial.Text = row["UnidadPredial"]?.ToString() ?? "";
                if (txtSector != null) txtSector.Text = row["Sector"]?.ToString() ?? "";
                if (txtArea != null) txtArea.Text = row["Area"]?.ToString() ?? "";
                if (txtValorAvaluo != null) txtValorAvaluo.Text = row["ValorAvaluo"]?.ToString() ?? "";

                // Fecha de avalúo
                if (dtpFechaAvaluo != null)
                {
                    if (DateTime.TryParse(row["FechaAvaluo"]?.ToString(), out DateTime fecha))
                    {
                        dtpFechaAvaluo.Value = fecha;
                    }
                    else
                    {
                        dtpFechaAvaluo.Value = DateTime.Now;
                    }
                }

                // Estado
                if (cboEstado != null)
                {
                    string estado = row["Estado"]?.ToString() ?? "";
                    if (!string.IsNullOrEmpty(estado))
                    {
                        int index = cboEstado.Items.IndexOf(estado);
                        if (index >= 0)
                        {
                            cboEstado.SelectedIndex = index;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar datos en controles: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Eventos de botones principales
        private void BtnNuevo_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("¿Desea crear una nueva ficha predial?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    LimpiarFormulario();
                    modoEdicion = false;
                    GenerarNuevoNumeroFicha();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al crear nueva ficha: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidarFormulario())
                {
                    GuardarFichaPredial();
                    MessageBox.Show("Ficha predial guardada exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    modoEdicion = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al guardar ficha predial: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(numeroFichaActual))
                {
                    MessageBox.Show("No hay ficha predial para eliminar.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                if (MessageBox.Show("¿Está seguro de que desea eliminar esta ficha predial?", "Confirmar Eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    EliminarFichaPredial();
                    MessageBox.Show("Ficha predial eliminada exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al eliminar ficha predial: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // Métodos auxiliares
        private void LimpiarFormulario()
        {
            try
            {
                // Limpiar todos los controles del formulario
                foreach (Control control in this.Controls)
                {
                    if (control is TextBox)
                    {
                        ((TextBox)control).Clear();
                    }
                    else if (control is ComboBox)
                    {
                        ((ComboBox)control).SelectedIndex = -1;
                    }
                    else if (control is DateTimePicker)
                    {
                        ((DateTimePicker)control).Value = DateTime.Now;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al limpiar formulario: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool ValidarFormulario()
        {
            try
            {
                // Validaciones básicas
                TextBox txtDireccion = (TextBox)this.Controls.Find("txtDireccion", true)[0];
                TextBox txtMunicipio = (TextBox)this.Controls.Find("txtMunicipio", true)[0];

                if (string.IsNullOrWhiteSpace(txtDireccion?.Text))
                {
                    MessageBox.Show("La dirección es obligatoria.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtDireccion?.Focus();
                    return false;
                }

                if (string.IsNullOrWhiteSpace(txtMunicipio?.Text))
                {
                    MessageBox.Show("El municipio es obligatorio.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtMunicipio?.Focus();
                    return false;
                }

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error en validación: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private void GuardarFichaPredial()
        {
            try
            {
                // TODO: Implementar guardado en base de datos
                // Por ahora solo mostramos un mensaje
                Console.WriteLine($"Guardando ficha predial: {numeroFichaActual}");
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al guardar en base de datos: {ex.Message}");
            }
        }

        private void EliminarFichaPredial()
        {
            try
            {
                // TODO: Implementar eliminación en base de datos
                // Por ahora solo mostramos un mensaje
                Console.WriteLine($"Eliminando ficha predial: {numeroFichaActual}");
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al eliminar de base de datos: {ex.Message}");
            }
        }

        // Eventos de DataGridViews (placeholder)
        private void DgvPropietarios_DoubleClick(object sender, EventArgs e) { }
        private void DgvConstrucciones_DoubleClick(object sender, EventArgs e) { }
        private void DgvLinderos_DoubleClick(object sender, EventArgs e) { }
        private void DgvZonaEconomica_DoubleClick(object sender, EventArgs e) { }

        // Eventos de botones de propietarios (placeholder)
        private void BtnAgregarPropietario_Click(object sender, EventArgs e) { }
        private void BtnModificarPropietario_Click(object sender, EventArgs e) { }
        private void BtnEliminarPropietario_Click(object sender, EventArgs e) { }

        // Eventos de botones de construcciones (placeholder)
        private void BtnAgregarConstruccion_Click(object sender, EventArgs e) { }
        private void BtnModificarConstruccion_Click(object sender, EventArgs e) { }
        private void BtnEliminarConstruccion_Click(object sender, EventArgs e) { }

        // Eventos de botones de linderos (placeholder)
        private void BtnAgregarLinderos_Click(object sender, EventArgs e) { }
        private void BtnModificarLinderos_Click(object sender, EventArgs e) { }
        private void BtnEliminarLinderos_Click(object sender, EventArgs e) { }

        // Eventos de botones de zona económica (placeholder)
        private void BtnAgregarZonaEconomica_Click(object sender, EventArgs e) { }
        private void BtnModificarZonaEconomica_Click(object sender, EventArgs e) { }
        private void BtnEliminarZonaEconomica_Click(object sender, EventArgs e) { }
    }
} 