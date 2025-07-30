using System;
using System.Windows.Forms;
using SICAFI.Datos;
using SICAFI.App.Forms.Shared;
using SICAFI.App.Forms.FichaPredial;
using SICAFI.App.Forms.CertificacionEstrato;
using SICAFI.App.Forms.Tercero;
using SICAFI.App.Forms.Consultas;
using SICAFI.App.Forms.Reportes;
using SICAFI.App.Forms.Mantenimiento.Estado;
using SICAFI.App.Forms.ImpuestoPredial;

namespace SICAFI.App.Forms
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            InitializeMainForm();
        }

        private void InitializeComponent()
        {
            // Configurar formulario principal
            this.Text = $"SICAFI - Sistema de Catastro Fiscal - Usuario: {VariablesPublicas.vp_usuario}";
            this.Size = new System.Drawing.Size(1200, 800);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.WindowState = FormWindowState.Maximized;

            // Aplicar tema SICAFI
            SicafiTheme.ApplyFormTheme(this);

            // Crear menú principal
            CreateMainMenu();

            // Crear barra de estado
            CreateStatusBar();

            // Crear panel principal
            CreateMainPanel();
        }

        private void InitializeMainForm()
        {
            // Mostrar información del usuario en la barra de estado
            UpdateStatusBar();
        }

        private void CreateMainMenu()
        {
            MenuStrip mainMenu = new MenuStrip();
            this.MainMenuStrip = mainMenu;

            // Menú Ficha Predial
            ToolStripMenuItem menuFichaPredial = new ToolStripMenuItem("&Ficha Predial");
            menuFichaPredial.DropDownItems.Add("&Nueva Ficha Predial", null, (s, e) => OpenFichaPredial());
            menuFichaPredial.DropDownItems.Add("&Consultar Ficha Predial", null, (s, e) => OpenConsultarFichaPredial());
            menuFichaPredial.DropDownItems.Add("-");
            
            // Submenú Propietarios
            ToolStripMenuItem subMenuPropietarios = new ToolStripMenuItem("&Propietarios");
            subMenuPropietarios.DropDownItems.Add("&Insertar Propietario", null, (s, e) => OpenPropietarios());
            subMenuPropietarios.DropDownItems.Add("&Modificar Propietario", null, (s, e) => OpenModificarPropietario());
            
            // Submenú Construcciones
            ToolStripMenuItem subMenuConstrucciones = new ToolStripMenuItem("&Construcciones");
            subMenuConstrucciones.DropDownItems.Add("&Insertar Construcción", null, (s, e) => OpenConstrucciones());
            subMenuConstrucciones.DropDownItems.Add("&Modificar Construcción", null, (s, e) => OpenModificarConstruccion());
            
            menuFichaPredial.DropDownItems.Add(subMenuPropietarios);
            menuFichaPredial.DropDownItems.Add(subMenuConstrucciones);
            menuFichaPredial.DropDownItems.Add("&Linderos", null, (s, e) => OpenLinderos());
            menuFichaPredial.DropDownItems.Add("&Zona Económica", null, (s, e) => OpenZonaEconomica());
            menuFichaPredial.DropDownItems.Add("&Ficha Predial Simple", null, (s, e) => OpenFichaPredialSimple());

            // Menú Certificación de Estrato
            ToolStripMenuItem menuCertificacionEstrato = new ToolStripMenuItem("&Certificación de Estrato");
            menuCertificacionEstrato.DropDownItems.Add("&Nueva Certificación", null, (s, e) => OpenCertificacionEstrato());
            menuCertificacionEstrato.DropDownItems.Add("&Consultar Certificaciones", null, (s, e) => OpenConsultarCertificaciones());

            // Menú Tercero
            ToolStripMenuItem menuTercero = new ToolStripMenuItem("&Tercero");
            menuTercero.DropDownItems.Add("&Nuevo Tercero", null, (s, e) => OpenTercero());
            menuTercero.DropDownItems.Add("&Consultar Terceros", null, (s, e) => OpenConsultarTerceros());

            // Menú Consultas
            ToolStripMenuItem menuConsultas = new ToolStripMenuItem("&Consultas");
            menuConsultas.DropDownItems.Add("&Consulta General", null, (s, e) => OpenConsultaGeneral());
            menuConsultas.DropDownItems.Add("&Consulta por Filtros", null, (s, e) => OpenConsultaPorFiltros());

            // Menú Reportes
            ToolStripMenuItem menuReportes = new ToolStripMenuItem("&Reportes");
            menuReportes.DropDownItems.Add("&Reporte de Fichas Prediales", null, (s, e) => OpenReporteFichasPrediales());
            menuReportes.DropDownItems.Add("&Reporte de Certificaciones", null, (s, e) => OpenReporteCertificaciones());

            // Menú Mantenimiento
            ToolStripMenuItem menuMantenimiento = new ToolStripMenuItem("&Mantenimiento");
            ToolStripMenuItem subMenuEstado = new ToolStripMenuItem("&Estado");
            subMenuEstado.DropDownItems.Add("&Gestionar Estados", null, (s, e) => OpenGestionarEstados());
            menuMantenimiento.DropDownItems.Add(subMenuEstado);

            // Menú Impuesto Predial
            ToolStripMenuItem menuImpuestoPredial = new ToolStripMenuItem("&Impuesto Predial");
            menuImpuestoPredial.DropDownItems.Add("&Liquidar Impuesto", null, (s, e) => OpenLiquidarImpuesto());
            menuImpuestoPredial.DropDownItems.Add("&Consultar Liquidaciones", null, (s, e) => OpenConsultarLiquidaciones());

            // Menú Sistema
            ToolStripMenuItem menuSistema = new ToolStripMenuItem("&Sistema");
            menuSistema.DropDownItems.Add("&Cambiar Usuario", null, (s, e) => ChangeUser());
            menuSistema.DropDownItems.Add("-");
            menuSistema.DropDownItems.Add("&Salir", null, (s, e) => ExitApplication());

            // Agregar menús al menú principal
            mainMenu.Items.AddRange(new ToolStripItem[] {
                menuFichaPredial,
                menuCertificacionEstrato,
                menuTercero,
                menuConsultas,
                menuReportes,
                menuMantenimiento,
                menuImpuestoPredial,
                menuSistema
            });

            this.Controls.Add(mainMenu);
        }

        private void CreateStatusBar()
        {
            StatusStrip statusStrip = new StatusStrip();
            
            ToolStripStatusLabel lblUsuario = new ToolStripStatusLabel();
            lblUsuario.Name = "lblUsuario";
            lblUsuario.Text = $"Usuario: {VariablesPublicas.vp_usuario}";
            
            ToolStripStatusLabel lblNombre = new ToolStripStatusLabel();
            lblNombre.Name = "lblNombre";
            lblNombre.Text = $"Nombre: {VariablesPublicas.vp_nombres}";
            
            ToolStripStatusLabel lblInstancia = new ToolStripStatusLabel();
            lblInstancia.Name = "lblInstancia";
            lblInstancia.Text = $"Instancia: {VariablesPublicas.vp_Instancia}";
            
            ToolStripStatusLabel lblFecha = new ToolStripStatusLabel();
            lblFecha.Name = "lblFecha";
            lblFecha.Text = $"Fecha: {DateTime.Now:dd/MM/yyyy}";
            
            statusStrip.Items.AddRange(new ToolStripItem[] {
                lblUsuario,
                new ToolStripSeparator(),
                lblNombre,
                new ToolStripSeparator(),
                lblInstancia,
                new ToolStripSeparator(),
                lblFecha
            });
            
            this.Controls.Add(statusStrip);
        }

        private void CreateMainPanel()
        {
            Panel mainPanel = new Panel();
            mainPanel.Dock = DockStyle.Fill;
            mainPanel.BackColor = System.Drawing.Color.White;
            
            // Crear imagen de bienvenida o logo
            Label lblBienvenida = new Label();
            lblBienvenida.Text = "Bienvenido al Sistema de Catastro Fiscal (SICAFI)";
            lblBienvenida.Font = new System.Drawing.Font("Arial", 16, System.Drawing.FontStyle.Bold);
            lblBienvenida.ForeColor = System.Drawing.Color.Navy;
            lblBienvenida.TextAlign = ContentAlignment.MiddleCenter;
            lblBienvenida.Dock = DockStyle.Fill;
            
            mainPanel.Controls.Add(lblBienvenida);
            this.Controls.Add(mainPanel);
        }

        private void UpdateStatusBar()
        {
            // Buscar el StatusStrip en los controles
            foreach (Control control in this.Controls)
            {
                if (control is StatusStrip statusStrip)
                {
                    foreach (ToolStripItem item in statusStrip.Items)
                    {
                        if (item is ToolStripStatusLabel statusLabel)
                        {
                            if (statusLabel.Name == "lblUsuario")
                            {
                                statusLabel.Text = $"Usuario: {VariablesPublicas.vp_usuario}";
                            }
                            else if (statusLabel.Name == "lblNombre")
                            {
                                statusLabel.Text = $"Nombre: {VariablesPublicas.vp_nombres}";
                            }
                            else if (statusLabel.Name == "lblInstancia")
                            {
                                statusLabel.Text = $"Instancia: {VariablesPublicas.vp_Instancia}";
                            }
                        }
                    }
                    break;
                }
            }
        }

        #region Eventos de Menú

        private void OpenFichaPredial()
        {
            try
            {
                var form = FrmFichaPredialPrincipal.Instance;
                form.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al abrir ficha predial: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void OpenConsultarFichaPredial()
        {
            try
            {
                var form = new SICAFI.App.Forms.FichaPredial.FrmConsultarFichaPredial();
                form.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al abrir consulta: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void OpenPropietarios()
        {
            try
            {
                var form = new SICAFI.App.Forms.FichaPredial.Propietarios.FrmInsertarPropietario();
                form.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al abrir propietarios: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void OpenConstrucciones()
        {
            try
            {
                var form = new SICAFI.App.Forms.FichaPredial.Construcciones.FrmInsertarConstruccion();
                form.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al abrir construcciones: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void OpenModificarPropietario()
        {
            try
            {
                var form = new SICAFI.App.Forms.FichaPredial.Propietarios.FrmModificarPropietario();
                form.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al abrir modificar propietario: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void OpenModificarConstruccion()
        {
            try
            {
                var form = new SICAFI.App.Forms.FichaPredial.Construcciones.FrmModificarConstruccion();
                form.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al abrir modificar construcción: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void OpenZonaEconomica()
        {
            try
            {
                var form = new SICAFI.App.Forms.FichaPredial.ZonaEconomica.FrmInsertarZonaEconomica();
                form.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al abrir zona económica: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void OpenFichaPredialSimple()
        {
            try
            {
                var form = new SICAFI.App.Forms.FichaPredial.FrmFichaPredialSimple();
                form.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al abrir ficha predial simple: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void OpenLinderos()
        {
            try
            {
                var form = new SICAFI.App.Forms.FichaPredial.Linderos.FrmInsertarLinderos();
                form.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al abrir linderos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void OpenCertificacionEstrato()
        {
            try
            {
                var form = new SICAFI.App.Forms.CertificacionEstrato.FrmCertEstrato();
                form.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al abrir certificación de estrato: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void OpenConsultarCertificaciones()
        {
            try
            {
                var form = new SICAFI.App.Forms.CertificacionEstrato.FrmConsultarCertificaciones();
                form.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al abrir consulta de certificaciones: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void OpenTercero()
        {
            try
            {
                var form = new SICAFI.App.Forms.Tercero.FrmTercero();
                form.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al abrir tercero: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void OpenConsultarTerceros()
        {
            try
            {
                var form = new SICAFI.App.Forms.Tercero.FrmConsultarTerceros();
                form.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al abrir consulta de terceros: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void OpenConsultaGeneral()
        {
            try
            {
                var form = new SICAFI.App.Forms.Consultas.FrmConsultas();
                form.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al abrir consulta general: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void OpenConsultaPorFiltros()
        {
            try
            {
                var form = new SICAFI.App.Forms.Consultas.FrmConsultas();
                form.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al abrir consulta por filtros: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void OpenReporteFichasPrediales()
        {
            try
            {
                var form = new SICAFI.App.Forms.Reportes.FrmReportes();
                form.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al abrir reporte de fichas prediales: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void OpenReporteCertificaciones()
        {
            try
            {
                var form = new SICAFI.App.Forms.Reportes.FrmReportes();
                form.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al abrir reporte de certificaciones: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void OpenGestionarEstados()
        {
            try
            {
                var form = new SICAFI.App.Forms.Mantenimiento.Estado.FrmEstado();
                form.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al abrir gestión de estados: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void OpenLiquidarImpuesto()
        {
            try
            {
                var form = new SICAFI.App.Forms.ImpuestoPredial.FrmImpuestoPredial();
                form.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al abrir liquidación de impuesto: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void OpenConsultarLiquidaciones()
        {
            try
            {
                var form = new SICAFI.App.Forms.ImpuestoPredial.FrmImpuestoPredial();
                form.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al abrir consulta de liquidaciones: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ChangeUser()
        {
            if (MessageBox.Show("¿Desea cambiar de usuario?", "Cambiar Usuario", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Close();
                Application.Restart();
            }
        }

        private void ExitApplication()
        {
            if (MessageBox.Show("¿Está seguro que desea salir del sistema?", "Salir", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        #endregion
    }
} 