using System;
using System.Data;
using Microsoft.Data.SqlClient;
using SICAFI.Datos;

namespace SICAFI.ReglasNegocio
{
    /// <summary>
    /// Clase para manejo de contraseñas y autenticación de usuarios
    /// Migrada de VB.NET a C# con .NET 8
    /// </summary>
    public class Contrasena
    {
        #region Variables

        private SqlCommand ejecutar = new SqlCommand();
        private SqlConnection conexion = new SqlConnection();
        private SqlDataAdapter adapter = new SqlDataAdapter();
        private SqlDataReader reader;
        private DataSet ds = new DataSet();
        private DataTable dt = new DataTable();

        #endregion

        #region Funciones de Consulta

        /// <summary>
        /// Consulta para llenar el DataGridView y colocar el nombre del encabezado de la columna
        /// </summary>
        /// <returns>DataTable con datos de contraseñas</returns>
        public DataTable ConsultarContrasena()
        {
            try
            {
                dt = new DataTable();
                adapter = new SqlDataAdapter();
                conexion = new SqlConnection(VariablesPublicas.vp_stConexionBD);
                conexion.Open();
                ejecutar = new SqlCommand("Consultar_CONTRASENA", conexion);
                ejecutar.CommandTimeout = 360;
                ejecutar.CommandType = CommandType.StoredProcedure;
                adapter.SelectCommand = ejecutar;
                adapter.Fill(dt);
                conexion.Close();

                return dt;
            }
            catch (Exception ex)
            {
                conexion.Close();
                dt = null;
                throw new Exception($"Error en ConsultarContrasena: {ex.Message}", ex);
            }
        }

        /// <summary>
        /// Llena el ComboBox con datos activos e inactivos formulario principal
        /// </summary>
        /// <returns>DataTable con campos de contraseña</returns>
        public DataTable ConsultarCamposContrasena()
        {
            try
            {
                dt = new DataTable();
                adapter = new SqlDataAdapter();
                conexion = new SqlConnection(VariablesPublicas.vp_stConexionBD);
                conexion.Open();
                ejecutar = new SqlCommand("Consultar_CAMPOS_CONTRASENA", conexion);
                ejecutar.CommandTimeout = 360;
                ejecutar.CommandType = CommandType.StoredProcedure;
                adapter.SelectCommand = ejecutar;
                adapter.Fill(dt);
                conexion.Close();

                return dt;
            }
            catch (Exception ex)
            {
                conexion.Close();
                dt = null;
                throw new Exception($"Error en ConsultarCamposContrasena: {ex.Message}", ex);
            }
        }

        /// <summary>
        /// Llena el ComboBox con datos activos formulario insertar y modificar
        /// </summary>
        /// <returns>DataTable con usuarios por estado</returns>
        public DataTable ConsultarUsuarioContrasenaPorEstado()
        {
            try
            {
                dt = new DataTable();
                adapter = new SqlDataAdapter();
                conexion = new SqlConnection(VariablesPublicas.vp_stConexionBD);
                conexion.Open();
                ejecutar = new SqlCommand("Consultar_USUARIO_CONTRASENA_X_ESTADO", conexion);
                ejecutar.CommandTimeout = 360;
                ejecutar.CommandType = CommandType.StoredProcedure;
                adapter.SelectCommand = ejecutar;
                adapter.Fill(dt);
                conexion.Close();

                return dt;
            }
            catch (Exception ex)
            {
                conexion.Close();
                dt = null;
                throw new Exception($"Error en ConsultarUsuarioContrasenaPorEstado: {ex.Message}", ex);
            }
        }

        #endregion

        #region Funciones de Búsqueda

        /// <summary>
        /// Busca contraseña por ID
        /// </summary>
        /// <param name="id">ID de la contraseña</param>
        /// <returns>DataTable con datos de la contraseña</returns>
        public DataTable BuscarIdContrasena(int id)
        {
            try
            {
                dt = new DataTable();
                adapter = new SqlDataAdapter();
                conexion = new SqlConnection(VariablesPublicas.vp_stConexionBD);
                conexion.Open();
                ejecutar = new SqlCommand("buscar_ID_CONTRASENA", conexion);
                ejecutar.CommandTimeout = 360;

                ejecutar.Parameters.Add("@CONTID", SqlDbType.Int).Value = id;

                ejecutar.CommandType = CommandType.StoredProcedure;
                adapter.SelectCommand = ejecutar;
                adapter.Fill(dt);
                conexion.Close();
                return dt;
            }
            catch (Exception ex)
            {
                conexion.Close();
                dt = null;
                throw new Exception($"Error en BuscarIdContrasena: {ex.Message}", ex);
            }
        }

        /// <summary>
        /// Busca contraseña por código
        /// </summary>
        /// <param name="codigo">Código de la contraseña</param>
        /// <returns>DataTable con datos de la contraseña</returns>
        public DataTable BuscarCodigoContrasena(string codigo)
        {
            try
            {
                dt = new DataTable();
                adapter = new SqlDataAdapter();
                conexion = new SqlConnection(VariablesPublicas.vp_stConexionBD);
                conexion.Open();
                ejecutar = new SqlCommand("buscar_CODIGO_CONTRASENA", conexion);
                ejecutar.CommandTimeout = 360;

                ejecutar.Parameters.Add("@CONTNUDO", SqlDbType.Char, 14).Value = codigo;

                ejecutar.CommandType = CommandType.StoredProcedure;
                adapter.SelectCommand = ejecutar;
                adapter.Fill(dt);
                conexion.Close();
                return dt;
            }
            catch (Exception ex)
            {
                conexion.Close();
                dt = null;
                throw new Exception($"Error en BuscarCodigoContrasena: {ex.Message}", ex);
            }
        }

        /// <summary>
        /// Función que busca el USUARIO DE LA CONTRASEÑA para encontrar el ID del usuario
        /// </summary>
        /// <param name="usuario">Nombre de usuario</param>
        /// <returns>DataTable con datos del usuario</returns>
        public DataTable BuscarUsuarioContrasena(string usuario)
        {
            try
            {
                dt = new DataTable();
                adapter = new SqlDataAdapter();
                conexion = new SqlConnection(VariablesPublicas.vp_stConexionBD);
                conexion.Open();
                ejecutar = new SqlCommand("buscar_USUARIO_CONTRASENA", conexion);
                ejecutar.CommandTimeout = 360;

                ejecutar.Parameters.Add("@CONTUSUA", SqlDbType.Char, 14).Value = usuario;

                ejecutar.CommandType = CommandType.StoredProcedure;
                adapter.SelectCommand = ejecutar;
                adapter.Fill(dt);
                conexion.Close();
                return dt;
            }
            catch (Exception ex)
            {
                conexion.Close();
                dt = null;
                throw new Exception($"Error en BuscarUsuarioContrasena: {ex.Message}", ex);
            }
        }

        #endregion

        #region Funciones de Inserción

        /// <summary>
        /// Inserta una nueva contraseña
        /// </summary>
        /// <param name="idUsuario">ID del usuario</param>
        /// <param name="usuario">Nombre de usuario</param>
        /// <param name="contrasenaEncriptada">Contraseña encriptada</param>
        /// <param name="estado">Estado de la contraseña</param>
        /// <param name="puedeAgregar">Si puede agregar</param>
        /// <param name="puedeModificar">Si puede modificar</param>
        /// <param name="puedeEliminar">Si puede eliminar</param>
        /// <param name="puedeConsultar">Si puede consultar</param>
        /// <param name="puedeRecuperar">Si puede recuperar</param>
        /// <returns>True si se insertó correctamente</returns>
        public bool InsertarContrasena(string idUsuario, string usuario, string contrasenaEncriptada, 
            string estado, bool puedeAgregar, bool puedeModificar, bool puedeEliminar, 
            bool puedeConsultar, bool puedeRecuperar)
        {
            try
            {
                conexion = new SqlConnection(VariablesPublicas.vp_stConexionBD);
                conexion.Open();
                ejecutar = new SqlCommand("Insertar_CONTRASENA", conexion);
                ejecutar.CommandTimeout = 360;

                ejecutar.Parameters.Add("@CONTNUDO", SqlDbType.Char, 14).Value = idUsuario;
                ejecutar.Parameters.Add("@CONTUSUA", SqlDbType.Char, 14).Value = usuario;
                ejecutar.Parameters.Add("@CONTCONT", SqlDbType.VarChar, 255).Value = contrasenaEncriptada;
                ejecutar.Parameters.Add("@CONTESTA", SqlDbType.Char, 1).Value = estado;
                ejecutar.Parameters.Add("@CONTAGRE", SqlDbType.Bit).Value = puedeAgregar;
                ejecutar.Parameters.Add("@CONTMODI", SqlDbType.Bit).Value = puedeModificar;
                ejecutar.Parameters.Add("@CONTELIM", SqlDbType.Bit).Value = puedeEliminar;
                ejecutar.Parameters.Add("@CONTCONS", SqlDbType.Bit).Value = puedeConsultar;
                ejecutar.Parameters.Add("@CONTRECO", SqlDbType.Bit).Value = puedeRecuperar;

                ejecutar.CommandType = CommandType.StoredProcedure;
                int resultado = ejecutar.ExecuteNonQuery();
                conexion.Close();

                return resultado > 0;
            }
            catch (Exception ex)
            {
                conexion.Close();
                throw new Exception($"Error en InsertarContrasena: {ex.Message}", ex);
            }
        }

        #endregion
    }
} 