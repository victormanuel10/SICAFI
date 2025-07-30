using System;
using System.Windows.Forms;

namespace SICAFI.App
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            
            try
            {
                // Mostrar el formulario principal que maneja el login
                var mainForm = new Form1();
                Application.Run(mainForm);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al iniciar la aplicación: {ex.Message}", 
                              "Error de Inicio", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}