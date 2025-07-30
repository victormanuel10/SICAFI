using System;
using System.Data;
using System.Windows.Forms;
using SICAFI.Datos;
using Microsoft.Data.SqlClient;

namespace SICAFI.App.Forms.Mantenimiento.Estado
{
    public partial class FrmEstado : Form
    {
        //============================
        //*** MANTENIMIENTO ESTADO ***
        //============================

        #region Variables

        private DataGridView dgvESTAESTA;
        private BindingNavigator BindingNavigator_ESTADO_1;
        private BindingSource BindingSource_ESTADO_1;
        private Button cmdAGREGAR;
        private Button cmdMODIFICAR;
        private Button cmdELIMINAR;
        private Button cmdCONSULTAR;
        private Button cmdRECONSULTAR;
        private StatusStrip strBARRESTA;
        private ToolStripStatusLabel lblRegistros;

        #endregion

        #region Constructor

        public FrmEstado()
        {
            InitializeComponent();
            InitializeForm();
        }

        #endregion

        #region Inicialización

        private void InitializeComponent()
        {
            // Configurar formulario
            this.Text = "SICAFI - Mantenimiento de Estados";
            this.Size = new System.Drawing.Size(1000, 700);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.WindowState = FormWindowState.Normal;

            // Crear controles
            CreateControls();

            // Configurar layout
            SetupLayout();
        }

        private void CreateControls()
        {
            // Crear BindingSource
            this.BindingSource_ESTADO_1 = new BindingSource();

            // Crear BindingNavigator
            this.BindingNavigator_ESTADO_1 = new BindingNavigator();
            this.BindingNavigator_ESTADO_1.Dock = DockStyle.Top;

            // Crear DataGridView
            this.dgvESTAESTA = new DataGridView();
            this.dgvESTAESTA.Dock = DockStyle.Fill;
            this.dgvESTAESTA.AllowUserToAddRows = false;
            this.dgvESTAESTA.AllowUserToDeleteRows = false;
            this.dgvESTAESTA.ReadOnly = true;
            this.dgvESTAESTA.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dgvESTAESTA.MultiSelect = false;
            this.dgvESTAESTA.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            // Crear botones
            this.cmdAGREGAR = new Button();
            this.cmdAGREGAR.Text = "Agregar";
            this.cmdAGREGAR.Size = new System.Drawing.Size(100, 35);
            this.cmdAGREGAR.Click += new EventHandler(CmdAGREGAR_Click);

            this.cmdMODIFICAR = new Button();
            this.cmdMODIFICAR.Text = "Modificar";
            this.cmdMODIFICAR.Size = new System.Drawing.Size(100, 35);
            this.cmdMODIFICAR.Click += new EventHandler(CmdMODIFICAR_Click);

            this.cmdELIMINAR = new Button();
            this.cmdELIMINAR.Text = "Eliminar";
            this.cmdELIMINAR.Size = new System.Drawing.Size(100, 35);
            this.cmdELIMINAR.Click += new EventHandler(CmdELIMINAR_Click);

            this.cmdCONSULTAR = new Button();
            this.cmdCONSULTAR.Text = "Consultar";
            this.cmdCONSULTAR.Size = new System.Drawing.Size(100, 35);
            this.cmdCONSULTAR.Click += new EventHandler(CmdCONSULTAR_Click);

            this.cmdRECONSULTAR = new Button();
            this.cmdRECONSULTAR.Text = "Reconsultar";
            this.cmdRECONSULTAR.Size = new System.Drawing.Size(100, 35);
            this.cmdRECONSULTAR.Click += new EventHandler(CmdRECONSULTAR_Click);

            // Crear StatusStrip
            this.strBARRESTA = new StatusStrip();
            this.lblRegistros = new ToolStripStatusLabel("Registros: 0");
            this.strBARRESTA.Items.Add(this.lblRegistros);
        }

        private void SetupLayout()
        {
            // Panel principal
            Panel mainPanel = new Panel
            {
                Dock = DockStyle.Fill,
                BackColor = System.Drawing.Color.WhiteSmoke
            };

            // Panel de botones
            Panel buttonPanel = new Panel
            {
                Dock = DockStyle.Bottom,
                Height = 60,
                BackColor = System.Drawing.Color.LightGray
            };

            // Layout de botones
            int buttonX = 20;
            int buttonY = 12;

            this.cmdAGREGAR.Location = new System.Drawing.Point(buttonX, buttonY);
            buttonX += 110;

            this.cmdMODIFICAR.Location = new System.Drawing.Point(buttonX, buttonY);
            buttonX += 110;

            this.cmdELIMINAR.Location = new System.Drawing.Point(buttonX, buttonY);
            buttonX += 110;

            this.cmdCONSULTAR.Location = new System.Drawing.Point(buttonX, buttonY);
            buttonX += 110;

            this.cmdRECONSULTAR.Location = new System.Drawing.Point(buttonX, buttonY);

            // Agregar botones al panel
            buttonPanel.Controls.AddRange(new Control[] {
                this.cmdAGREGAR, this.cmdMODIFICAR, this.cmdELIMINAR, 
                this.cmdCONSULTAR, this.cmdRECONSULTAR
            });

            // Agregar controles al panel principal
            mainPanel.Controls.Add(this.dgvESTAESTA);
            mainPanel.Controls.Add(buttonPanel);

            // Agregar controles al formulario
            this.Controls.Add(this.BindingNavigator_ESTADO_1);
            this.Controls.Add(mainPanel);
            this.Controls.Add(this.strBARRESTA);
        }

        private void InitializeForm()
        {
            // Cargar datos iniciales
            pro_Reconsultar();
        }

        #endregion

        #region Procedimientos

        private void pro_Reconsultar()
        {
            try
            {
                // TODO: Implementar cuando migremos las reglas de negocio
                // var objdatos = new cla_ESTADO();
                // var datos = objdatos.fun_Consultar_ESTADO();

                // Por ahora, datos de ejemplo
                var datos = new DataTable();
                datos.Columns.Add("ESTACODI", typeof(int));
                datos.Columns.Add("ESTADESC", typeof(string));
                datos.Columns.Add("ESTAACTI", typeof(string));

                datos.Rows.Add(1, "Activo", "S");
                datos.Rows.Add(2, "Inactivo", "N");
                datos.Rows.Add(3, "Suspendido", "S");
                datos.Rows.Add(4, "Cancelado", "N");

                this.BindingSource_ESTADO_1.DataSource = datos;
                this.dgvESTAESTA.DataSource = this.BindingSource_ESTADO_1;
                this.BindingNavigator_ESTADO_1.BindingSource = this.BindingSource_ESTADO_1;

                // Actualizar contador de registros
                this.lblRegistros.Text = $"Registros: {this.BindingSource_ESTADO_1.Count}";

                // Ocultar columna ID
                if (this.dgvESTAESTA.Columns.Count > 0)
                {
                    this.dgvESTAESTA.Columns[0].Visible = false;
                }

                // Configurar anchos de columnas
                if (this.dgvESTAESTA.Columns.Count >= 3)
                {
                    this.dgvESTAESTA.Columns[1].Width = 100;
                    this.dgvESTAESTA.Columns[2].Width = 200;
                    this.dgvESTAESTA.Columns[3].Width = 100;
                }

                // Configurar permisos de botones
                ConfigurarPermisosBotones();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al recargar datos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ConfigurarPermisosBotones()
        {
            try
            {
                int contarRegistros = this.BindingSource_ESTADO_1.Count;

                // TODO: Implementar cuando migremos el sistema de seguridad
                // var objdatos1 = new cla_CONTRASENA();
                // var tbl1 = objdatos1.fun_Buscar_USUARIO_CONTRASENA(vp_usuario);

                // Por ahora, todos los permisos habilitados
                bool boCONTAGRE = true;
                bool boCONTMODI = true;
                bool boCONTELIM = true;

                // Configurar botón Agregar
                this.cmdAGREGAR.Enabled = boCONTAGRE;

                // Configurar botón Modificar
                if (contarRegistros == 0)
                {
                    this.cmdMODIFICAR.Enabled = false;
                }
                else
                {
                    this.cmdMODIFICAR.Enabled = boCONTMODI;
                }

                // Configurar botón Eliminar
                if (contarRegistros == 0)
                {
                    this.cmdELIMINAR.Enabled = false;
                }
                else
                {
                    this.cmdELIMINAR.Enabled = boCONTELIM;
                }

                // Configurar botones de consulta
                if (contarRegistros == 0)
                {
                    this.cmdCONSULTAR.Enabled = false;
                    this.cmdRECONSULTAR.Enabled = false;
                }
                else
                {
                    this.cmdCONSULTAR.Enabled = true;
                    this.cmdRECONSULTAR.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al configurar permisos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        #region Eventos

        private void CmdAGREGAR_Click(object sender, EventArgs e)
        {
            try
            {
                MessageBox.Show("Función Agregar Estado - En desarrollo\n\nSe implementará cuando migremos las reglas de negocio.", "SICAFI", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al agregar: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CmdMODIFICAR_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.dgvESTAESTA.SelectedRows.Count > 0)
                {
                    var selectedRow = this.dgvESTAESTA.SelectedRows[0];
                    string estadoDesc = selectedRow.Cells["ESTADESC"].Value?.ToString() ?? "";
                    MessageBox.Show($"Función Modificar Estado - En desarrollo\n\nEstado seleccionado: {estadoDesc}", "SICAFI", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Debe seleccionar un estado para modificar", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al modificar: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CmdELIMINAR_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.dgvESTAESTA.SelectedRows.Count > 0)
                {
                    var selectedRow = this.dgvESTAESTA.SelectedRows[0];
                    string estadoDesc = selectedRow.Cells["ESTADESC"].Value?.ToString() ?? "";

                    if (MessageBox.Show($"¿Está seguro de eliminar el estado '{estadoDesc}'?", "Confirmar Eliminación", 
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        MessageBox.Show($"Función Eliminar Estado - En desarrollo\n\nEstado a eliminar: {estadoDesc}", "SICAFI", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    MessageBox.Show("Debe seleccionar un estado para eliminar", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al eliminar: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CmdCONSULTAR_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.dgvESTAESTA.SelectedRows.Count > 0)
                {
                    var selectedRow = this.dgvESTAESTA.SelectedRows[0];
                    string estadoDesc = selectedRow.Cells["ESTADESC"].Value?.ToString() ?? "";
                    MessageBox.Show($"Función Consultar Estado - En desarrollo\n\nEstado seleccionado: {estadoDesc}", "SICAFI", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Debe seleccionar un estado para consultar", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al consultar: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CmdRECONSULTAR_Click(object sender, EventArgs e)
        {
            try
            {
                pro_Reconsultar();
                MessageBox.Show("Datos recargados exitosamente", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al reconsultar: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion
    }
} 