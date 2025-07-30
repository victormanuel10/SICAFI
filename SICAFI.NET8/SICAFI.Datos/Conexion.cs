using Microsoft.Data.SqlClient;
using System;
using System.Data;
using System.Security.Principal;
using System.Security.Permissions;
using System.IO;

namespace SICAFI.Datos
{
    /// <summary>
    /// Clase para manejo de conexiones a SQL Server
    /// Migrada de VB.NET a C# con .NET 8
    /// </summary>
    public class Conexion
    {
        #region Variables

        private SqlConnection cnn = new SqlConnection();
        private string stMaquina = "";
        private string stInstancia = "";

        #endregion

        #region Procedimientos

        /// <summary>
        /// Configura la conexión para ambiente de soporte
        /// </summary>
        private void Pro_Conexion_Soporte()
        {
            try
            {
                if (VariablesPublicas.vp_st_Instancia?.Trim() == "RED")
                {
                    stMaquina = "JOSEESTRADA";
                    stInstancia = "SQLEXPRESS";
                    cnn.ConnectionString = $"Data Source={stMaquina}\\{stInstancia};Initial Catalog=SICAFI;User ID=sa;Password=Jose1026*;TrustServerCertificate=true;Encrypt=false";

                    // variables de conexion 
                    VariablesPublicas.vp_stDataSource = $"{stMaquina?.Trim()}\\{stInstancia?.Trim()}";
                    VariablesPublicas.vp_stInitialCatalog = "SICAFI";
                    VariablesPublicas.vp_stUserID = "sa";
                    VariablesPublicas.vp_stPassword = "Jose1026*";

                    VariablesPublicas.vp_stConexionRED = cnn.ConnectionString;
                }
                else if (VariablesPublicas.vp_st_Instancia?.Trim() == "LOCAL")
                {
                    stMaquina = "JOSEESTRADA";
                    stInstancia = "SQLEXPRESS";
                    cnn.ConnectionString = $"Data Source={stMaquina}\\{stInstancia};Initial Catalog=SICAFI;User ID=sa;Password=Jose1026*;TrustServerCertificate=true;Encrypt=false";

                    // variables de conexion 
                    VariablesPublicas.vp_stDataSource = $"{stMaquina?.Trim()}\\{stInstancia?.Trim()}";
                    VariablesPublicas.vp_stInitialCatalog = "SICAFI";
                    VariablesPublicas.vp_stUserID = "sa";
                    VariablesPublicas.vp_stPassword = "Jose1026*";

                    VariablesPublicas.vp_stConexionLOCAL = cnn.ConnectionString;
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error en Pro_Conexion_Soporte: {ex.Message}", ex);
            }
        }

        /// <summary>
        /// Configura la conexión para ambiente de pruebas
        /// </summary>
        private void Pro_Conexion_Pruebas()
        {
            try
            {
                if (VariablesPublicas.vp_st_Instancia?.Trim() == "RED")
                {
                    stMaquina = "RRM-HP";
                    stInstancia = "SQL2017";
                    cnn.ConnectionString = $"Data Source={stMaquina}\\{stInstancia};Initial Catalog=SICAFI;User ID=sa;Password=12345.*#";

                    // variables de conexion 
                    VariablesPublicas.vp_stDataSource = $"{stMaquina?.Trim()}\\{stInstancia?.Trim()}";
                    VariablesPublicas.vp_stInitialCatalog = "SICAFI";
                    VariablesPublicas.vp_stUserID = "Backup";
                    VariablesPublicas.vp_stPassword = "Clave.Bck0";

                    VariablesPublicas.vp_stConexionRED = cnn.ConnectionString;
                }
                else if (VariablesPublicas.vp_st_Instancia?.Trim() == "LOCAL")
                {
                    stMaquina = Environment.MachineName;
                    stInstancia = "SQL2017";
                    cnn.ConnectionString = $"Data Source={stMaquina}\\{stInstancia};Initial Catalog=SICAFI;User ID=sa;Password=12345.*#";

                    // variables de conexion 
                    VariablesPublicas.vp_stDataSource = $"{stMaquina?.Trim()}\\{stInstancia?.Trim()}";
                    VariablesPublicas.vp_stInitialCatalog = "SICAFI";
                    VariablesPublicas.vp_stUserID = "Backup";
                    VariablesPublicas.vp_stPassword = "Clave.Bck0";

                    VariablesPublicas.vp_stConexionLOCAL = cnn.ConnectionString;
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error en Pro_Conexion_Pruebas: {ex.Message}", ex);
            }
        }

        /// <summary>
        /// Establece la conexión a la base de datos
        /// </summary>
        /// <returns>SqlConnection abierta</returns>
        public SqlConnection conexion()
        {
            try
            {
                cnn = new SqlConnection();

                if (cnn.State == ConnectionState.Open)
                    cnn.Close();

                // Realiza la conexion
                Pro_Conexion_Soporte();
                //Pro_Conexion_Pruebas();

                VariablesPublicas.vp_stConexionBD = cnn.ConnectionString;

                cnn.Open();

                return cnn;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al conectar a la base de datos: {ex.Message}", ex);
            }
        }

        /// <summary>
        /// Cierra la conexión a la base de datos
        /// </summary>
        /// <returns>True si se cerró correctamente</returns>
        public bool cerrar_base()
        {
            try
            {
                if (cnn.State == ConnectionState.Open)
                {
                    cnn.Close();
                }
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al cerrar la conexión: {ex.Message}", ex);
            }
        }

        #endregion
    }
} 