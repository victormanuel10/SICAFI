using System.Data;

namespace SICAFI.App.Shared
{
    public static class VariablesPublicas
    {
        // Variables para Ficha Predial
        public static int vp_FichaPredial { get; set; } = 1;
        public static DataTable vp_tblConsulta { get; set; } = new DataTable();
        
        // Variables para Resolución
        public static string vp_ResolucionDepartamento { get; set; } = "05";
        public static string vp_ResolucionMunicipio { get; set; } = "001";
        public static int vp_ResolucionTipo { get; set; } = 1;
        public static int vp_ResolucionClase { get; set; } = 1;
        public static int vp_ResolucionVigencia { get; set; } = 2024;
        public static int vp_ResolucionResolucion { get; set; } = 1;
        
        // Variables para otros módulos
        public static string vp_UsuarioActual { get; set; } = "ADMIN";
        public static DateTime vp_FechaActual { get; set; } = DateTime.Now;
        
        // Variables de configuración
        public static string vp_ConexionString { get; set; } = "";
        public static bool vp_ModoDesarrollo { get; set; } = true;
    }
} 