namespace SICAFI.Datos
{
    /// <summary>
    /// Variables públicas para la configuración de conexión a base de datos
    /// </summary>
    public static class VariablesPublicas
    {
        // Variable cadena de conexion
        public static string vp_stConexionBD = "";
        public static string vp_stConexionLOCAL = "";
        public static string vp_stConexionRED = "";

        // variables de conexion base de datos
        public static string vp_stDataSource = "";
        public static string vp_stInitialCatalog = "";
        public static string vp_stUserID = "";
        public static string vp_stPassword = "";

        // Variable cadena de instancia
        public static string vp_st_Instancia = "LOCAL";

        // Variables de usuario
        public static string vp_usuario = "";
        public static string vp_nombres = "";
        public static string vp_cedula = "";
        public static string vp_Instancia = "";
        public static string vp_stConeccion = "";

        // Variables de Ficha Predial
        public static int vp_FichaPredial = 0;
        public static System.Data.DataTable? vp_tblConsulta = null;

        // Variables de Certificación de Estrato
        public static int vp_inConsulta = 0;
    }
} 