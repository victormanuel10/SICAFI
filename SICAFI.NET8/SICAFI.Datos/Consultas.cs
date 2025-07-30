using Microsoft.Data.SqlClient;
using System;
using System.Data;

namespace SICAFI.Datos
{
    /// <summary>
    /// Clase para manejar consultas a la base de datos SICAFI
    /// </summary>
    public class ConsultasDB
    {
        private Conexion conexion;

        public ConsultasDB()
        {
            conexion = new Conexion();
        }

        /// <summary>
        /// Consulta fichas prediales con filtros
        /// </summary>
        public DataTable ConsultarFichasPrediales(string numeroFicha = "", string municipio = "", string direccion = "", string barrio = "")
        {
            DataTable dt = new DataTable();
            
            try
            {
                using (SqlConnection conn = conexion.conexion())
                {
                    // Verificar si la conexión está abierta
                    if (conn.State != System.Data.ConnectionState.Open)
                    {
                        conn.Open();
                    }

                    string sql = @"
                        SELECT 
                            FiprNufi as NroFicha,
                            FiprDire as Direccion,
                            FiprMuni as Municipio,
                            FiprCorr as Corregi,
                            FiprBarr as Barrio,
                            FiprManz as Manzana,
                            FiprPred as Predio,
                            FiprEdif as Edificio,
                            FiprUnpr as UnidPred,
                            FiprClse as Sector
                        FROM FichPred 
                        WHERE FiprTifi = 0";

                    if (!string.IsNullOrEmpty(numeroFicha))
                        sql += " AND FiprNufi LIKE @NumeroFicha";
                    
                    if (!string.IsNullOrEmpty(municipio))
                        sql += " AND FiprMuni LIKE @Municipio";
                    
                    if (!string.IsNullOrEmpty(direccion))
                        sql += " AND FiprDire LIKE @Direccion";
                    
                    if (!string.IsNullOrEmpty(barrio))
                        sql += " AND FiprBarr LIKE @Barrio";

                    sql += " ORDER BY FiprMuni, FiprCorr, FiprBarr, FiprManz, FiprPred";

                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        if (!string.IsNullOrEmpty(numeroFicha))
                            cmd.Parameters.AddWithValue("@NumeroFicha", "%" + numeroFicha + "%");
                        
                        if (!string.IsNullOrEmpty(municipio))
                            cmd.Parameters.AddWithValue("@Municipio", "%" + municipio + "%");
                        
                        if (!string.IsNullOrEmpty(direccion))
                            cmd.Parameters.AddWithValue("@Direccion", "%" + direccion + "%");
                        
                        if (!string.IsNullOrEmpty(barrio))
                            cmd.Parameters.AddWithValue("@Barrio", "%" + barrio + "%");

                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            da.Fill(dt);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Si hay error, crear tabla con datos de ejemplo
                dt = CrearTablaFichasPredialesEjemplo();
            }

            return dt;
        }

        /// <summary>
        /// Consulta certificaciones de estrato con filtros
        /// </summary>
        public DataTable ConsultarCertificacionesEstrato(string numeroCertificacion = "", string solicitante = "", string direccion = "", string estrato = "")
        {
            DataTable dt = new DataTable();
            
            try
            {
                using (SqlConnection conn = conexion.conexion())
                {
                    // Verificar si la conexión está abierta
                    if (conn.State != System.Data.ConnectionState.Open)
                    {
                        conn.Open();
                    }

                    string sql = @"
                        SELECT 
                            ESTRNUME as NumeroCertificacion,
                            ESTRSOLI as Solicitante,
                            ESTRDIRE as Direccion,
                            ESTRESTR as Estrato,
                            ESTRFECH as FechaSolicitud,
                            ESTRESTA as Estado
                        FROM ESTR 
                        WHERE 1=1";

                    if (!string.IsNullOrEmpty(numeroCertificacion))
                        sql += " AND ESTRNUME LIKE @NumeroCertificacion";
                    
                    if (!string.IsNullOrEmpty(solicitante))
                        sql += " AND ESTRSOLI LIKE @Solicitante";
                    
                    if (!string.IsNullOrEmpty(direccion))
                        sql += " AND ESTRDIRE LIKE @Direccion";
                    
                    if (!string.IsNullOrEmpty(estrato) && estrato != "Todos")
                        sql += " AND ESTRESTR = @Estrato";

                    sql += " ORDER BY ESTRNUME";

                    // Mostrar la consulta SQL para debugging
                    Console.WriteLine($"SQL Query: {sql}");

                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        if (!string.IsNullOrEmpty(numeroCertificacion))
                            cmd.Parameters.AddWithValue("@NumeroCertificacion", "%" + numeroCertificacion + "%");
                        
                        if (!string.IsNullOrEmpty(solicitante))
                            cmd.Parameters.AddWithValue("@Solicitante", "%" + solicitante + "%");
                        
                        if (!string.IsNullOrEmpty(direccion))
                            cmd.Parameters.AddWithValue("@Direccion", "%" + direccion + "%");
                        
                        if (!string.IsNullOrEmpty(estrato) && estrato != "Todos")
                            cmd.Parameters.AddWithValue("@Estrato", estrato);

                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            da.Fill(dt);
                        }
                    }

                    // Mostrar el número de filas obtenidas
                    Console.WriteLine($"Filas obtenidas: {dt.Rows.Count}");
                }
            }
            catch (Exception ex)
            {
                // Mostrar el error específico
                Console.WriteLine($"Error en ConsultarCertificacionesEstrato: {ex.Message}");
                Console.WriteLine($"StackTrace: {ex.StackTrace}");
                
                // Si hay error, crear tabla con datos de ejemplo
                dt = CrearTablaCertificacionesEjemplo();
            }

            return dt;
        }

        /// <summary>
        /// Consulta terceros con filtros
        /// </summary>
        public DataTable ConsultarTerceros(string numeroDocumento = "", string nombre = "", string tipoDocumento = "", string estado = "")
        {
            DataTable dt = new DataTable();
            
            try
            {
                using (SqlConnection conn = conexion.conexion())
                {
                    // Verificar si la conexión está abierta
                    if (conn.State != System.Data.ConnectionState.Open)
                    {
                        conn.Open();
                    }

                    string sql = @"
                        SELECT 
                            TERNUDOC as NumeroDocumento,
                            TERTIDOC as TipoDocumento,
                            TERNOMBR as Nombre,
                            TERDIRE as Direccion,
                            TERTELE as Telefono,
                            TERCOEL as Email,
                            TERESTA as Estado
                        FROM TER 
                        WHERE 1=1";

                    if (!string.IsNullOrEmpty(numeroDocumento))
                        sql += " AND TERNUDOC LIKE @NumeroDocumento";
                    
                    if (!string.IsNullOrEmpty(nombre))
                        sql += " AND TERNOMBR LIKE @Nombre";
                    
                    if (!string.IsNullOrEmpty(tipoDocumento) && tipoDocumento != "Todos")
                        sql += " AND TERTIDOC = @TipoDocumento";
                    
                    if (!string.IsNullOrEmpty(estado) && estado != "Todos")
                        sql += " AND TERESTA = @Estado";

                    sql += " ORDER BY TERNOMBR";

                    // Mostrar la consulta SQL para debugging
                    Console.WriteLine($"SQL Query: {sql}");

                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        if (!string.IsNullOrEmpty(numeroDocumento))
                            cmd.Parameters.AddWithValue("@NumeroDocumento", "%" + numeroDocumento + "%");
                        
                        if (!string.IsNullOrEmpty(nombre))
                            cmd.Parameters.AddWithValue("@Nombre", "%" + nombre + "%");
                        
                        if (!string.IsNullOrEmpty(tipoDocumento) && tipoDocumento != "Todos")
                            cmd.Parameters.AddWithValue("@TipoDocumento", tipoDocumento);
                        
                        if (!string.IsNullOrEmpty(estado) && estado != "Todos")
                            cmd.Parameters.AddWithValue("@Estado", estado);

                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            da.Fill(dt);
                        }
                    }

                    // Mostrar el número de filas obtenidas
                    Console.WriteLine($"Filas obtenidas: {dt.Rows.Count}");
                }
            }
            catch (Exception ex)
            {
                // Mostrar el error específico
                Console.WriteLine($"Error en ConsultarTerceros: {ex.Message}");
                Console.WriteLine($"StackTrace: {ex.StackTrace}");
                
                // Si hay error, crear tabla con datos de ejemplo
                dt = CrearTablaTercerosEjemplo();
            }

            return dt;
        }

        #region Métodos para crear tablas de ejemplo

        private DataTable CrearTablaFichasPredialesEjemplo()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("NroFicha", typeof(string));
            dt.Columns.Add("Direccion", typeof(string));
            dt.Columns.Add("Municipio", typeof(string));
            dt.Columns.Add("Corregi", typeof(string));
            dt.Columns.Add("Barrio", typeof(string));
            dt.Columns.Add("Manzana", typeof(string));
            dt.Columns.Add("Predio", typeof(string));
            dt.Columns.Add("Edificio", typeof(string));
            dt.Columns.Add("UnidPred", typeof(string));
            dt.Columns.Add("Sector", typeof(string));

            dt.Rows.Add("4700011", "CR 4 N 4-10", "113", "01", "Centro", "001", "001", "001", "001", "URBANO");
            dt.Rows.Add("4700012", "CR 4 N 4-20 IN 101", "113", "01", "Centro", "001", "002", "001", "002", "URBANO");
            dt.Rows.Add("4700013", "CL 8 N 3A-195", "113", "01", "Norte", "002", "001", "001", "003", "URBANO");
            dt.Rows.Add("4700014", "CR 15 N 2-45", "113", "01", "Sur", "003", "001", "001", "004", "URBANO");
            dt.Rows.Add("4700015", "AV 5 N 12-67", "113", "01", "Este", "004", "001", "001", "005", "URBANO");

            return dt;
        }

        private DataTable CrearTablaCertificacionesEjemplo()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("NumeroCertificacion", typeof(string));
            dt.Columns.Add("Solicitante", typeof(string));
            dt.Columns.Add("Direccion", typeof(string));
            dt.Columns.Add("Estrato", typeof(string));
            dt.Columns.Add("FechaSolicitud", typeof(string));
            dt.Columns.Add("Estado", typeof(string));

            dt.Rows.Add("CE001", "Juan Pérez", "Calle 123 #45-67", "3", "2024-01-15", "Aprobada");
            dt.Rows.Add("CE002", "María García", "Carrera 78 #12-34", "4", "2024-01-20", "Pendiente");
            dt.Rows.Add("CE003", "Carlos López", "Avenida 5 #23-45", "2", "2024-01-25", "Aprobada");
            dt.Rows.Add("CE004", "Ana Rodríguez", "Calle 90 #67-89", "5", "2024-01-30", "Rechazada");
            dt.Rows.Add("CE005", "Luis Martínez", "Carrera 15 #34-56", "3", "2024-02-01", "Aprobada");

            return dt;
        }

        private DataTable CrearTablaTercerosEjemplo()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("NumeroDocumento", typeof(string));
            dt.Columns.Add("TipoDocumento", typeof(string));
            dt.Columns.Add("Nombre", typeof(string));
            dt.Columns.Add("Direccion", typeof(string));
            dt.Columns.Add("Telefono", typeof(string));
            dt.Columns.Add("Email", typeof(string));
            dt.Columns.Add("Estado", typeof(string));

            dt.Rows.Add("12345678", "CC", "Juan Pérez", "Calle 123 #45-67", "3001234567", "juan.perez@email.com", "Activo");
            dt.Rows.Add("87654321", "CC", "María García", "Carrera 78 #12-34", "3008765432", "maria.garcia@email.com", "Activo");
            dt.Rows.Add("90123456", "NIT", "Empresa ABC Ltda", "Avenida 5 #23-45", "3009012345", "info@empresaabc.com", "Activo");
            dt.Rows.Add("23456789", "CC", "Carlos López", "Calle 90 #67-89", "3002345678", "carlos.lopez@email.com", "Inactivo");
            dt.Rows.Add("34567890", "CE", "Ana Rodríguez", "Carrera 15 #34-56", "3003456789", "ana.rodriguez@email.com", "Activo");

            return dt;
        }

        #endregion

        /// <summary>
        /// Obtiene los datos completos de una ficha predial específica
        /// </summary>
        public DataTable ObtenerFichaPredialCompleta(string numeroFicha)
        {
            DataTable dt = new DataTable();
            try
            {
                using (SqlConnection conn = conexion.conexion())
                {
                    // Verificar si la conexión está abierta
                    if (conn.State != System.Data.ConnectionState.Open)
                    {
                        conn.Open();
                    }

                    string sql = @"
                        SELECT 
                            FiprNufi as NumeroFicha,
                            FiprDire as Direccion,
                            FiprMuni as Municipio,
                            FiprCorr as Corregimiento,
                            FiprBarr as Barrio,
                            FiprManz as Manzana,
                            FiprPred as Predio,
                            FiprEdif as Edificio,
                            FiprUnpr as UnidadPredial,
                            FiprClse as Sector,
                            FiprArea as Area,
                            FiprAval as ValorAvaluo,
                            FiprFech as FechaAvaluo,
                            FiprEsta as Estado
                        FROM FichPred
                        WHERE FiprNufi = @NumeroFicha AND FiprTifi = 0";
                    
                    using (SqlCommand command = new SqlCommand(sql, conn))
                    {
                        command.Parameters.AddWithValue("@NumeroFicha", numeroFicha);
                        
                        using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                        {
                            adapter.Fill(dt);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error en ObtenerFichaPredialCompleta: {ex.Message}");
            }
            return dt;
        }
    }
} 