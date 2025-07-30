using Microsoft.Data.SqlClient;
using System;
using System.Data;

namespace SICAFI.Datos
{
    /// <summary>
    /// Clase para ejecutar consultas que retornan datos (SELECT)
    /// Migrada de VB.NET a C# con .NET 8
    /// </summary>
    public class ExecuteQuery
    {
        private Conexion oConexion = new Conexion();
        private SqlCommand oCommand = new SqlCommand();
        private SqlDataAdapter oAdapter = new SqlDataAdapter();

        private DataTable Dt = new DataTable();
        private DataSet Ds = new DataSet();

        /// <summary>
        /// Función que recibe el parámetro y el procedimiento StoredProcedure para consultar
        /// </summary>
        /// <param name="pParametros">Array de parámetros SQL</param>
        /// <param name="pProcedimiento">Nombre del stored procedure</param>
        /// <returns>DataTable con los resultados</returns>
        public DataTable? ConsultarDb(SqlParameter[] pParametros, string pProcedimiento)
        {
            try
            {
                oCommand = new SqlCommand(pProcedimiento, oConexion.conexion());

                oCommand.CommandTimeout = 0;
                oCommand.CommandType = CommandType.StoredProcedure;

                foreach (SqlParameter param in pParametros)
                {
                    oCommand.Parameters.Add(param).Value = param.Value;
                }

                oAdapter = new SqlDataAdapter();
                oAdapter.SelectCommand = oCommand;

                Dt = new DataTable();
                oAdapter.Fill(Dt);

                oConexion.cerrar_base();

                return Dt;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error en ConsultarDb con parámetros: {ex.Message}", ex);
            }
        }

        /// <summary>
        /// Función que recibe el procedimiento StoredProcedure para consultar
        /// </summary>
        /// <param name="pProcedimiento">Nombre del stored procedure</param>
        /// <returns>DataTable con los resultados</returns>
        public DataTable? ConsultarDb(string pProcedimiento)
        {
            try
            {
                oCommand = new SqlCommand(pProcedimiento, oConexion.conexion());

                oCommand.CommandTimeout = 0;
                oCommand.CommandType = CommandType.StoredProcedure;

                oAdapter = new SqlDataAdapter();
                oAdapter.SelectCommand = oCommand;

                Dt = new DataTable();
                oAdapter.Fill(Dt);

                oConexion.cerrar_base();

                return Dt;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error en ConsultarDb: {ex.Message}", ex);
            }
        }

        /// <summary>
        /// Función que recibe el parámetro y el procedimiento StoredProcedure para consultar
        /// </summary>
        /// <param name="pParametros">Array de parámetros SQL</param>
        /// <param name="pProcedimiento">Nombre del stored procedure</param>
        /// <returns>DataSet con los resultados</returns>
        public DataSet? Consultarset(SqlParameter[] pParametros, string pProcedimiento)
        {
            try
            {
                oCommand = new SqlCommand(pProcedimiento, oConexion.conexion());

                oCommand.CommandTimeout = 0;
                oCommand.CommandType = CommandType.StoredProcedure;

                foreach (SqlParameter param in pParametros)
                {
                    oCommand.Parameters.Add(param).Value = param.Value;
                }

                oAdapter = new SqlDataAdapter();
                oAdapter.SelectCommand = oCommand;

                Ds = new DataSet();
                oAdapter.Fill(Ds);

                oConexion.cerrar_base();

                return Ds;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error en Consultarset con parámetros: {ex.Message}", ex);
            }
        }

        /// <summary>
        /// Función que recibe el procedimiento StoredProcedure para consultar
        /// </summary>
        /// <param name="pProcedimiento">Nombre del stored procedure</param>
        /// <returns>DataSet con los resultados</returns>
        public DataSet? Consultarset(string pProcedimiento)
        {
            try
            {
                oCommand = new SqlCommand(pProcedimiento, oConexion.conexion());

                oCommand.CommandTimeout = 0;
                oCommand.CommandType = CommandType.StoredProcedure;

                oAdapter = new SqlDataAdapter();
                oAdapter.SelectCommand = oCommand;

                Ds = new DataSet();
                oAdapter.Fill(Ds);

                oConexion.cerrar_base();

                return Ds;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error en Consultarset: {ex.Message}", ex);
            }
        }

        /// <summary>
        /// Función que recibe el procedimiento SQL Text para consultar
        /// </summary>
        /// <param name="pProcedimiento">Comando SQL como texto</param>
        /// <returns>DataTable con los resultados</returns>
        public DataTable? ConsultarDb_Text_SQL(string pProcedimiento)
        {
            try
            {
                oCommand = new SqlCommand(pProcedimiento, oConexion.conexion());

                oCommand.CommandTimeout = 0;
                oCommand.CommandType = CommandType.Text;

                oAdapter = new SqlDataAdapter();
                oAdapter.SelectCommand = oCommand;

                Dt = new DataTable();
                oAdapter.Fill(Dt);

                oConexion.cerrar_base();

                return Dt;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error en ConsultarDb_Text_SQL: {ex.Message}", ex);
            }
        }
    }
} 