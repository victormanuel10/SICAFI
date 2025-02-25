using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JEJ.ImprimirFicha.Utilidades
{
   public static class PythonUtilities
    {
        public static string ExecuteCommand(string file, List<string> lstParametros, string strRutaPython, ref string strscript)
        {
            //string commandExecute = "\"" + strRutaPython + "\"" + " " + "\"" + file + "\"";
            string commandExecute =  strRutaPython  + " " + "\"" + file + "\"";
            foreach(string strParametros in lstParametros)
            {
                commandExecute += " "+strParametros ;
            }
            strscript = commandExecute;
            //Indicamos que deseamos inicializar el proceso cmd.exe junto a un comando de arranque. 
            //(/C, le indicamos al proceso cmd que deseamos que cuando termine la tarea asignada se cierre el proceso).
            //Para mas informacion consulte la ayuda de la consola con cmd.exe /? 

            System.Diagnostics.ProcessStartInfo procStartInfo = new System.Diagnostics.ProcessStartInfo("cmd", "/c "+commandExecute );
            //procStartInfo.Arguments = "/C " + commandExecute;
            strscript = procStartInfo.Arguments;
            // Indicamos que la salida del proceso se redireccione en un Stream
            procStartInfo.RedirectStandardOutput = true;
            procStartInfo.UseShellExecute = false;
            //Indica que el proceso no despliegue una pantalla negra (El proceso se ejecuta en background)
            procStartInfo.CreateNoWindow = true;
            procStartInfo.ErrorDialog = true;
            
            //Inicializa el proceso
            System.Diagnostics.Process proc = new System.Diagnostics.Process();
            
            proc.StartInfo = procStartInfo;
            proc.EnableRaisingEvents = false;
            
            proc.Start();
            //Consigue la salida de la Consola(Stream) y devuelve una cadena de texto
            string result = proc.StandardOutput.ReadToEnd();
            //strscript = result;
            //Muestra en pantalla la salida del Comando
            return result;
        }
    }
}
