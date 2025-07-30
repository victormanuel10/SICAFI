using System;
using System.Windows.Forms;
using SICAFI.Datos;
using SICAFI.App.Forms.Login;

namespace SICAFI.App
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.Text = "SICAFI - Sistema de Catastro Fiscal";
            this.WindowState = FormWindowState.Maximized;
            
            // Mostrar formulario de login
            ShowLoginForm();
        }

        private void ShowLoginForm()
        {
            using (var loginForm = new FrmLogin())
            {
                if (loginForm.ShowDialog() == DialogResult.OK)
                {
                    // Login exitoso, mostrar formulario principal
                    this.Hide();
                    using (var mainForm = new SICAFI.App.Forms.MainForm())
                    {
                        mainForm.ShowDialog();
                    }
                    Application.Exit();
                }
                else
                {
                    // Usuario canceló el login
                    Application.Exit();
                }
            }
        }
    }
}
