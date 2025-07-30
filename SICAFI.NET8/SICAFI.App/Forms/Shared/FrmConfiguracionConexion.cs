using System;
using System.Drawing;
using System.Windows.Forms;
using SICAFI.App.Forms.Shared;
using SICAFI.Datos;

namespace SICAFI.App.Forms.Shared
{
    public class FrmConfiguracionConexion : Form
    {
        private TextBox txtServer;
        private TextBox txtInstance;
        private TextBox txtDatabase;
        private TextBox txtUserId;
        private TextBox txtPassword;
        private ComboBox cboEnvironment;
        private Button btnTestConnection;
        private Button btnSave;
        private Button btnCancel;
        private Label lblStatus;

        public FrmConfiguracionConexion()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.Text = "CONFIGURACIÓN DE CONEXIÓN";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Size = new Size(500, 400);

            SicafiTheme.ApplyFormTheme(this, FormSize.Small);

            CreateControls();
            SetupLayout();
            LoadCurrentConfig();
        }

        private void CreateControls()
        {
            // ComboBox para entorno
            this.cboEnvironment = new ComboBox();
            this.cboEnvironment.Items.AddRange(new string[] { "Soporte", "Pruebas", "Personalizado" });
            this.cboEnvironment.SelectedIndex = 0;
            this.cboEnvironment.SelectedIndexChanged += CboEnvironment_SelectedIndexChanged;

            // Campos de conexión
            this.txtServer = new TextBox();
            this.txtInstance = new TextBox();
            this.txtDatabase = new TextBox();
            this.txtUserId = new TextBox();
            this.txtPassword = new TextBox();
            this.txtPassword.UseSystemPasswordChar = true;

            // Botones
            this.btnTestConnection = new Button();
            this.btnTestConnection.Text = "🔍 Probar Conexión";
            this.btnTestConnection.Size = new Size(150, 35);
            this.btnTestConnection.FlatStyle = FlatStyle.Flat;
            this.btnTestConnection.BackColor = Color.FromArgb(0, 122, 204);
            this.btnTestConnection.ForeColor = Color.White;
            this.btnTestConnection.Font = new Font("Segoe UI", 9, FontStyle.Bold);
            this.btnTestConnection.Click += BtnTestConnection_Click;

            this.btnSave = new Button();
            this.btnSave.Text = "💾 Guardar";
            this.btnSave.Size = new Size(100, 35);
            this.btnSave.FlatStyle = FlatStyle.Flat;
            this.btnSave.BackColor = Color.FromArgb(0, 200, 83);
            this.btnSave.ForeColor = Color.White;
            this.btnSave.Font = new Font("Segoe UI", 9, FontStyle.Bold);
            this.btnSave.Click += BtnSave_Click;

            this.btnCancel = new Button();
            this.btnCancel.Text = "❌ Cancelar";
            this.btnCancel.Size = new Size(100, 35);
            this.btnCancel.FlatStyle = FlatStyle.Flat;
            this.btnCancel.BackColor = Color.FromArgb(244, 67, 54);
            this.btnCancel.ForeColor = Color.White;
            this.btnCancel.Font = new Font("Segoe UI", 9, FontStyle.Bold);
            this.btnCancel.Click += BtnCancel_Click;

            // Label de estado
            this.lblStatus = new Label();
            this.lblStatus.Text = "Estado: Sin probar";
            this.lblStatus.Font = new Font("Segoe UI", 9, FontStyle.Bold);
            this.lblStatus.ForeColor = Color.Orange;
        }

        private void SetupLayout()
        {
            var mainPanel = new Panel();
            mainPanel.Dock = DockStyle.Fill;
            mainPanel.BackColor = Color.FromArgb(45, 45, 48);
            mainPanel.Padding = new Padding(20);

            // Título
            var lblTitulo = new Label();
            lblTitulo.Text = "CONFIGURACIÓN DE CONEXIÓN A BASE DE DATOS";
            lblTitulo.Font = new Font("Segoe UI", 14, FontStyle.Bold);
            lblTitulo.ForeColor = Color.FromArgb(0, 153, 255);
            lblTitulo.Location = new Point(20, 20);
            lblTitulo.Size = new Size(400, 30);
            lblTitulo.BackColor = Color.Transparent;
            mainPanel.Controls.Add(lblTitulo);

            int yPos = 60;
            int labelWidth = 120;
            int controlWidth = 200;

            // Entorno
            var lblEnvironment = CreateLabel("Entorno:", 20, yPos);
            mainPanel.Controls.Add(lblEnvironment);
            this.cboEnvironment.Location = new Point(20 + labelWidth, yPos);
            this.cboEnvironment.Size = new Size(controlWidth, 25);
            mainPanel.Controls.Add(this.cboEnvironment);

            yPos += 40;

            // Servidor
            var lblServer = CreateLabel("Servidor:", 20, yPos);
            mainPanel.Controls.Add(lblServer);
            this.txtServer.Location = new Point(20 + labelWidth, yPos);
            this.txtServer.Size = new Size(controlWidth, 25);
            mainPanel.Controls.Add(this.txtServer);

            yPos += 40;

            // Instancia
            var lblInstance = CreateLabel("Instancia:", 20, yPos);
            mainPanel.Controls.Add(lblInstance);
            this.txtInstance.Location = new Point(20 + labelWidth, yPos);
            this.txtInstance.Size = new Size(controlWidth, 25);
            mainPanel.Controls.Add(this.txtInstance);

            yPos += 40;

            // Base de datos
            var lblDatabase = CreateLabel("Base de datos:", 20, yPos);
            mainPanel.Controls.Add(lblDatabase);
            this.txtDatabase.Location = new Point(20 + labelWidth, yPos);
            this.txtDatabase.Size = new Size(controlWidth, 25);
            mainPanel.Controls.Add(this.txtDatabase);

            yPos += 40;

            // Usuario
            var lblUserId = CreateLabel("Usuario:", 20, yPos);
            mainPanel.Controls.Add(lblUserId);
            this.txtUserId.Location = new Point(20 + labelWidth, yPos);
            this.txtUserId.Size = new Size(controlWidth, 25);
            mainPanel.Controls.Add(this.txtUserId);

            yPos += 40;

            // Contraseña
            var lblPassword = CreateLabel("Contraseña:", 20, yPos);
            mainPanel.Controls.Add(lblPassword);
            this.txtPassword.Location = new Point(20 + labelWidth, yPos);
            this.txtPassword.Size = new Size(controlWidth, 25);
            mainPanel.Controls.Add(this.txtPassword);

            yPos += 50;

            // Botón de prueba
            this.btnTestConnection.Location = new Point(20, yPos);
            mainPanel.Controls.Add(this.btnTestConnection);

            // Label de estado
            this.lblStatus.Location = new Point(180, yPos + 8);
            this.lblStatus.Size = new Size(250, 20);
            mainPanel.Controls.Add(this.lblStatus);

            yPos += 50;

            // Botones de acción
            this.btnSave.Location = new Point(20, yPos);
            mainPanel.Controls.Add(this.btnSave);

            this.btnCancel.Location = new Point(130, yPos);
            mainPanel.Controls.Add(this.btnCancel);

            this.Controls.Add(mainPanel);
        }

        private Label CreateLabel(string text, int x, int y)
        {
            var label = new Label();
            label.Text = text;
            label.Font = new Font("Segoe UI", 9, FontStyle.Bold);
            label.ForeColor = Color.White;
            label.Location = new Point(x, y);
            label.Size = new Size(110, 25);
            label.BackColor = Color.Transparent;
            return label;
        }

        private void LoadCurrentConfig()
        {
            // Cargar configuración actual
            this.txtServer.Text = Environment.MachineName;
            this.txtInstance.Text = "SQLEXPRESS";
            this.txtDatabase.Text = "SICAFI";
            this.txtUserId.Text = "sa";
            this.txtPassword.Text = "Sql#2o25*.";
        }

        private void CboEnvironment_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (this.cboEnvironment.SelectedIndex)
            {
                case 0: // Soporte
                    this.txtServer.Text = "DESKTOP-3T43PDR";
                    this.txtInstance.Text = "SQLEXPRESS";
                    this.txtDatabase.Text = "SICAFI";
                    this.txtUserId.Text = "sa";
                    this.txtPassword.Text = "Sql#2o25*.";
                    break;
                case 1: // Pruebas
                    this.txtServer.Text = "RRM-HP";
                    this.txtInstance.Text = "SQL2017";
                    this.txtDatabase.Text = "SICAFI";
                    this.txtUserId.Text = "sa";
                    this.txtPassword.Text = "12345.*#";
                    break;
                case 2: // Personalizado
                    LoadCurrentConfig();
                    break;
            }
        }

        private void BtnTestConnection_Click(object sender, EventArgs e)
        {
            try
            {
                string connectionString = $"Data Source={this.txtServer.Text}\\{this.txtInstance.Text};Initial Catalog={this.txtDatabase.Text};User ID={this.txtUserId.Text};Password={this.txtPassword.Text};";
                
                bool success = ConnectionConfig.TestConnection(connectionString);
                
                if (success)
                {
                    this.lblStatus.Text = "Estado: Conexión exitosa";
                    this.lblStatus.ForeColor = Color.Green;
                }
                else
                {
                    this.lblStatus.Text = "Estado: Error de conexión";
                    this.lblStatus.ForeColor = Color.Red;
                }
            }
            catch (Exception ex)
            {
                this.lblStatus.Text = $"Estado: Error - {ex.Message}";
                this.lblStatus.ForeColor = Color.Red;
            }
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            // Aquí podrías guardar la configuración en un archivo
            MessageBox.Show("Configuración guardada. Reinicie la aplicación para aplicar los cambios.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
} 