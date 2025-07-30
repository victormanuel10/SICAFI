using System;
using System.Windows.Forms;
using SICAFI.App.Forms.Shared;

namespace SICAFI.App.Forms.FichaPredial
{
    public class FrmInsertarFichaPredial : Form
    {
        public FrmInsertarFichaPredial()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.Text = "INSERTAR FICHA PREDIAL";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;

            SicafiTheme.ApplyFormTheme(this, FormSize.Standard);

            var panel = SicafiTheme.CreateMainPanel();
            var label = SicafiTheme.CreateLabel("Formulario de Inserción de Ficha Predial en desarrollo", true);
            label.Location = new Point(50, 50);
            label.Size = new Size(400, 30);

            var btnCerrar = SicafiTheme.CreateButton("Cerrar");
            btnCerrar.Location = new Point(150, 100);
            btnCerrar.Click += (s, e) => this.Close();

            panel.Controls.Add(label);
            panel.Controls.Add(btnCerrar);
            this.Controls.Add(panel);
        }
    }
} 