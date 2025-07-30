using System;
using System.Data;
using Microsoft.Data.SqlClient;
using SICAFI.Datos;

namespace SICAFI.ReglasNegocio
{
    /// <summary>
    /// Clase para manejo de usuarios del sistema
    /// Migrada de VB.NET a C# con .NET 8
    /// </summary>
    public class Usuario
    {
        #region Variables

        private SqlCommand ejecutar = new SqlCommand();
        private SqlConnection conexion = new SqlConnection();
        private SqlDataAdapter adapter = new SqlDataAdapter();
        private DataSet ds = new DataSet();
        private DataTable dt = new DataTable();
        private SqlDataReader reader;

        #endregion

        #region Funciones de Consulta

        /// <summary>
        /// Consulta para llenar el DataGridView y colocar el nombre del encabezado de la columna
        /// </summary>
        /// <returns>DataTable con datos de usuarios</returns>
        public DataTable ConsultarUsuario()
        {
            try
            {
                dt = new DataTable();
                adapter = new SqlDataAdapter();
                conexion = new SqlConnection(VariablesPublicas.vp_stConexionBD);
                conexion.Open();
                ejecutar = new SqlCommand("Consultar_USUARIO", conexion);
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
                throw new Exception($"Error en ConsultarUsuario: {ex.Message}", ex);
            }
        }

        /// <summary>
        /// Llena el ComboBox con datos activos formulario insertar y modificar
        /// </summary>
        /// <returns>DataTable con usuarios por estado</returns>
        public DataTable ConsultarUsuarioPorEstado()
        {
            try
            {
                dt = new DataTable();
                adapter = new SqlDataAdapter();
                conexion = new SqlConnection(VariablesPublicas.vp_stConexionBD);
                conexion.Open();
                ejecutar = new SqlCommand("Consultar_USUARIO_X_ESTADO", conexion);
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
                throw new Exception($"Error en ConsultarUsuarioPorEstado: {ex.Message}", ex);
            }
        }

        #endregion

        #region Funciones de Búsqueda

        /// <summary>
        /// Busca usuario por código
        /// </summary>
        /// <param name="codigo">Código del usuario</param>
        /// <returns>DataTable con datos del usuario</returns>
        public DataTable BuscarCodigoUsuario(string codigo)
        {
            try
            {
                dt = new DataTable();
                adapter = new SqlDataAdapter();
                conexion = new SqlConnection(VariablesPublicas.vp_stConexionBD);
                conexion.Open();
                ejecutar = new SqlCommand("buscar_CODIGO_USUARIO", conexion);
                ejecutar.CommandTimeout = 360;

                ejecutar.Parameters.Add("@USUANUDO", SqlDbType.Char, 14).Value = codigo;

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
                throw new Exception($"Error en BuscarCodigoUsuario: {ex.Message}", ex);
            }
        }

        /// <summary>
        /// Busca usuario por ID
        /// </summary>
        /// <param name="id">ID del usuario</param>
        /// <returns>DataTable con datos del usuario</returns>
        public DataTable BuscarIdUsuario(int id)
        {
            try
            {
                dt = new DataTable();
                adapter = new SqlDataAdapter();
                conexion = new SqlConnection(VariablesPublicas.vp_stConexionBD);
                conexion.Open();
                ejecutar = new SqlCommand("buscar_ID_USUARIO", conexion);
                ejecutar.CommandTimeout = 360;

                ejecutar.Parameters.Add("@USUAID", SqlDbType.Int).Value = id;

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
                throw new Exception($"Error en BuscarIdUsuario: {ex.Message}", ex);
            }
        }

        /// <summary>
        /// Busca usuario por nombre
        /// </summary>
        /// <param name="nombre">Nombre del usuario</param>
        /// <returns>DataTable con datos del usuario</returns>
        public DataTable BuscarNombreUsuario(string nombre)
        {
            try
            {
                dt = new DataTable();
                adapter = new SqlDataAdapter();
                conexion = new SqlConnection(VariablesPublicas.vp_stConexionBD);
                conexion.Open();
                ejecutar = new SqlCommand("buscar_NOMBRE_USUARIO", conexion);
                ejecutar.CommandTimeout = 360;

                ejecutar.Parameters.Add("@USUANOMB", SqlDbType.VarChar, 50).Value = nombre;

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
                throw new Exception($"Error en BuscarNombreUsuario: {ex.Message}", ex);
            }
        }

        #endregion

        #region Funciones de Inserción

        /// <summary>
        /// Inserta un nuevo usuario
        /// </summary>
        /// <param name="numeroDocumento">Número de documento</param>
        /// <param name="nombre">Nombre del usuario</param>
        /// <param name="primerApellido">Primer apellido</param>
        /// <param name="segundoApellido">Segundo apellido</param>
        /// <param name="tipoDocumento">Tipo de documento</param>
        /// <param name="sexo">Sexo</param>
        /// <param name="departamento">Departamento</param>
        /// <param name="municipio">Municipio</param>
        /// <param name="direccion">Dirección</param>
        /// <param name="telefono">Teléfono</param>
        /// <param name="email">Email</param>
        /// <param name="estado">Estado del usuario</param>
        /// <returns>True si se insertó correctamente</returns>
        public bool InsertarUsuario(string numeroDocumento, string nombre, string primerApellido, 
            string segundoApellido, string tipoDocumento, string sexo, string departamento, 
            string municipio, string direccion, string telefono, string email, string estado)
        {
            try
            {
                conexion = new SqlConnection(VariablesPublicas.vp_stConexionBD);
                conexion.Open();
                ejecutar = new SqlCommand("Insertar_USUARIO", conexion);
                ejecutar.CommandTimeout = 360;

                ejecutar.Parameters.Add("@USUANUDO", SqlDbType.Char, 14).Value = numeroDocumento;
                ejecutar.Parameters.Add("@USUANOMB", SqlDbType.VarChar, 50).Value = nombre;
                ejecutar.Parameters.Add("@USUAPRAP", SqlDbType.VarChar, 30).Value = primerApellido;
                ejecutar.Parameters.Add("@USUASEAP", SqlDbType.VarChar, 30).Value = segundoApellido;
                ejecutar.Parameters.Add("@USUATIDO", SqlDbType.Char, 2).Value = tipoDocumento;
                ejecutar.Parameters.Add("@USUASEXO", SqlDbType.Char, 1).Value = sexo;
                ejecutar.Parameters.Add("@USUADEPA", SqlDbType.Char, 2).Value = departamento;
                ejecutar.Parameters.Add("@USUAMUNI", SqlDbType.Char, 3).Value = municipio;
                ejecutar.Parameters.Add("@USUADIRE", SqlDbType.VarChar, 100).Value = direccion;
                ejecutar.Parameters.Add("@USUATELE", SqlDbType.VarChar, 20).Value = telefono;
                ejecutar.Parameters.Add("@USUAEMAI", SqlDbType.VarChar, 100).Value = email;
                ejecutar.Parameters.Add("@USUAESTA", SqlDbType.Char, 1).Value = estado;

                ejecutar.CommandType = CommandType.StoredProcedure;
                int resultado = ejecutar.ExecuteNonQuery();
                conexion.Close();

                return resultado > 0;
            }
            catch (Exception ex)
            {
                conexion.Close();
                throw new Exception($"Error en InsertarUsuario: {ex.Message}", ex);
            }
        }

        #endregion

        #region Funciones de Actualización

        /// <summary>
        /// Actualiza un usuario existente
        /// </summary>
        /// <param name="id">ID del usuario</param>
        /// <param name="numeroDocumento">Número de documento</param>
        /// <param name="nombre">Nombre del usuario</param>
        /// <param name="primerApellido">Primer apellido</param>
        /// <param name="segundoApellido">Segundo apellido</param>
        /// <param name="tipoDocumento">Tipo de documento</param>
        /// <param name="sexo">Sexo</param>
        /// <param name="departamento">Departamento</param>
        /// <param name="municipio">Municipio</param>
        /// <param name="direccion">Dirección</param>
        /// <param name="telefono">Teléfono</param>
        /// <param name="email">Email</param>
        /// <param name="estado">Estado del usuario</param>
        /// <returns>True si se actualizó correctamente</returns>
        public bool ActualizarUsuario(int id, string numeroDocumento, string nombre, string primerApellido, 
            string segundoApellido, string tipoDocumento, string sexo, string departamento, 
            string municipio, string direccion, string telefono, string email, string estado)
        {
            try
            {
                conexion = new SqlConnection(VariablesPublicas.vp_stConexionBD);
                conexion.Open();
                ejecutar = new SqlCommand("Actualizar_USUARIO", conexion);
                ejecutar.CommandTimeout = 360;

                ejecutar.Parameters.Add("@USUAID", SqlDbType.Int).Value = id;
                ejecutar.Parameters.Add("@USUANUDO", SqlDbType.Char, 14).Value = numeroDocumento;
                ejecutar.Parameters.Add("@USUANOMB", SqlDbType.VarChar, 50).Value = nombre;
                ejecutar.Parameters.Add("@USUAPRAP", SqlDbType.VarChar, 30).Value = primerApellido;
                ejecutar.Parameters.Add("@USUASEAP", SqlDbType.VarChar, 30).Value = segundoApellido;
                ejecutar.Parameters.Add("@USUATIDO", SqlDbType.Char, 2).Value = tipoDocumento;
                ejecutar.Parameters.Add("@USUASEXO", SqlDbType.Char, 1).Value = sexo;
                ejecutar.Parameters.Add("@USUADEPA", SqlDbType.Char, 2).Value = departamento;
                ejecutar.Parameters.Add("@USUAMUNI", SqlDbType.Char, 3).Value = municipio;
                ejecutar.Parameters.Add("@USUADIRE", SqlDbType.VarChar, 100).Value = direccion;
                ejecutar.Parameters.Add("@USUATELE", SqlDbType.VarChar, 20).Value = telefono;
                ejecutar.Parameters.Add("@USUAEMAI", SqlDbType.VarChar, 100).Value = email;
                ejecutar.Parameters.Add("@USUAESTA", SqlDbType.Char, 1).Value = estado;

                ejecutar.CommandType = CommandType.StoredProcedure;
                int resultado = ejecutar.ExecuteNonQuery();
                conexion.Close();

                return resultado > 0;
            }
            catch (Exception ex)
            {
                conexion.Close();
                throw new Exception($"Error en ActualizarUsuario: {ex.Message}", ex);
            }
        }

        #endregion
    }
} 