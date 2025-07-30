namespace SICAFI.Datos
{
    /// <summary>
    /// Clase para configurar la instancia de conexión
    /// Migrada de VB.NET a C# con .NET 8
    /// </summary>
    public class ConnectionInstance
    {
        /// <summary>
        /// Constructor que almacena en la variable pública el nombre de la instancia
        /// </summary>
        /// <param name="stInstancia">Nombre de la instancia (LOCAL o RED)</param>
        public ConnectionInstance(string stInstancia)
        {
            VariablesPublicas.vp_st_Instancia = stInstancia;
        }
    }
} 