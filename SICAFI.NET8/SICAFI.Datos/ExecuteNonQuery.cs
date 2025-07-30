using Microsoft.Data.SqlClient;
using System;
using System.Data;

namespace SICAFI.Datos
{
    /// <summary>
    /// Clase para ejecutar comandos que no retornan datos (INSERT, UPDATE, DELETE)
    /// Migrada de VB.NET a C# con .NET 8
    /// </summary>
    public class ExecuteNonQuery
    {
        private SqlCommand oCommand = new SqlCommand();
        private Conexion oConexion = new Conexion();
        private SqlDataAdapter oAdapter = new SqlDataAdapter();
        private SqlDataReader? oReader;

        /// <summary>
        /// Función que recibe los parámetros y el procedimiento StoredProcedure para actualizar, insertar y eliminar
        /// </summary>
        /// <param name="pParametros">Array de parámetros SQL</param>
        /// <param name="pProcedimiento">Nombre del stored procedure</param>
        /// <returns>True si se ejecutó correctamente</returns>
        public bool ActualizarDb(SqlParameter[] pParametros, string pProcedimiento)
        {
            try
            {
                oConexion = new Conexion();
                oCommand = new SqlCommand(pProcedimiento, oConexion.conexion());

                oCommand.CommandTimeout = 0;
                oCommand.CommandType = CommandType.StoredProcedure;

                foreach (SqlParameter Param in pParametros)
                {
                    oCommand.Parameters.Add(Param).Value = Param.Value;
                }

                oAdapter.SelectCommand = oCommand;
                oReader = oCommand.ExecuteReader();

                oConexion.cerrar_base();
                oReader?.Dispose();
                oReader = null;

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error en ActualizarDb con parámetros: {ex.Message}", ex);
            }
            finally
            {
                oReader?.Dispose();
                oReader = null;
            }
        }

        /// <summary>
        /// Función que recibe el procedimiento StoredProcedure para actualizar, insertar y eliminar
        /// </summary>
        /// <param name="pProcedimiento">Nombre del stored procedure</param>
        /// <returns>True si se ejecutó correctamente</returns>
        public bool ActualizarDb(string pProcedimiento)
        {
            try
            {
                oConexion = new Conexion();
                oCommand = new SqlCommand(pProcedimiento, oConexion.conexion());

                oCommand.CommandTimeout = 0;
                oCommand.CommandType = CommandType.StoredProcedure;

                oAdapter.SelectCommand = oCommand;
                oReader = oCommand.ExecuteReader();

                oConexion.cerrar_base();
                oReader?.Dispose();
                oReader = null;

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error en ActualizarDb: {ex.Message}", ex);
            }
            finally
            {
                oReader?.Dispose();
                oReader = null;
            }
        }

        /// <summary>
        /// Función que recibe el procedimiento SQL Text para actualizar, insertar y eliminar
        /// </summary>
        /// <param name="pProcedimiento">Comando SQL como texto</param>
        /// <returns>True si se ejecutó correctamente</returns>
        public bool ActualizarDb_Text_SQL(string pProcedimiento)
        {
            try
            {
                oConexion = new Conexion();
                oCommand = new SqlCommand(pProcedimiento, oConexion.conexion());

                oCommand.CommandTimeout = 0;
                oCommand.CommandType = CommandType.Text;

                oAdapter.SelectCommand = oCommand;
                oReader = oCommand.ExecuteReader();

                oConexion.cerrar_base();
                oReader?.Dispose();
                oReader = null;

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error en ActualizarDb_Text_SQL: {ex.Message}", ex);
            }
            finally
            {
                oReader?.Dispose();
                oReader = null;
            }
        }
    }
} 