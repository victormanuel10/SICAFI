using System;
using System.Configuration;

namespace SICAFI.Datos
{
    public static class ConnectionConfig
    {
        // Configuraciones de conexión basadas en la aplicación original
        public static class Soporte
        {
            public static string Server = "DESKTOP-3T43PDR";
            public static string Instance = "SQLEXPRESS";
            public static string Database = "SICAFI";
            public static string UserId = "sa";
            public static string Password = "Sql#2o25*.";
        }

        public static class Pruebas
        {
            public static string Server = "RRM-HP";
            public static string Instance = "SQL2017";
            public static string Database = "SICAFI";
            public static string UserId = "sa";
            public static string Password = "12345.*#";
        }

        public static string GetConnectionString(string environment = "Soporte", string connectionType = "LOCAL")
        {
            string server, instance, database, userId, password;

            if (environment.Equals("Soporte", StringComparison.OrdinalIgnoreCase))
            {
                server = Soporte.Server;
                instance = Soporte.Instance;
                database = Soporte.Database;
                userId = Soporte.UserId;
                password = Soporte.Password;
            }
            else
            {
                server = Pruebas.Server;
                instance = Pruebas.Instance;
                database = Pruebas.Database;
                userId = Pruebas.UserId;
                password = Pruebas.Password;
            }

            // Si es LOCAL, usar el nombre de la máquina actual
            if (connectionType.Equals("LOCAL", StringComparison.OrdinalIgnoreCase))
            {
                server = Environment.MachineName;
            }

            return $"Data Source={server}\\{instance};Initial Catalog={database};User ID={userId};Password={password};";
        }

        public static string GetCurrentConnectionString()
        {
            // Intentar detectar automáticamente el entorno
            string currentMachine = Environment.MachineName;
            
            // Si estamos en la máquina de soporte, usar configuración de soporte
            if (currentMachine.Equals("DESKTOP-3T43PDR", StringComparison.OrdinalIgnoreCase))
            {
                return GetConnectionString("Soporte", "LOCAL");
            }
            // Si estamos en la máquina de pruebas, usar configuración de pruebas
            else if (currentMachine.Equals("RRM-HP", StringComparison.OrdinalIgnoreCase))
            {
                return GetConnectionString("Pruebas", "LOCAL");
            }
            else
            {
                // Por defecto, intentar con configuración local
                return GetConnectionString("Soporte", "LOCAL");
            }
        }

        // Método para probar la conexión
        public static bool TestConnection(string connectionString = null)
        {
            if (connectionString == null)
                connectionString = GetCurrentConnectionString();

            try
            {
                using (var connection = new System.Data.SqlClient.SqlConnection(connectionString))
                {
                    connection.Open();
                    Console.WriteLine($"Conexión exitosa a: {connection.DataSource}");
                    return true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error de conexión: {ex.Message}");
                return false;
            }
        }
    }
} 