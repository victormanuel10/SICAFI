using JEJ.ImprimirFicha.Negocio.Utilidades.Enum;
using System;
using System.Collections.Generic;

using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JEJ.ImprimirFicha.Modelo.sqlite
{
    public class Entity : Conexion
    {
        /*public Entity(string strRutaArchivo)
            : base(strRutaArchivo)
        {

        }
        public bool InsertarDatosPredio(ref string strMensaje, string strNumeroFicha, string strRutaPredios, string strRutaConstruccion
                                        , string strUsuario, string strClave, string strInstancia
                                        ,string strUi, string strRuta_GDB)
        {
            bool Resultado = true;
            try
            {
                string sql = string.Empty;
                sql += "insert into Predio (numero_ficha, ruta_predios,ruta_construccion,ruta_GDB,usuario,clave,instancia,ui,estado) \n";
                sql += " values( ";
                sql += strNumeroFicha + ",'" + strRutaPredios + "','" + strRutaConstruccion + "','" + strRuta_GDB + "','" + strUsuario + "','" + strClave + "'";
                sql += ",'" + strInstancia + "','" + strUi + "',1";
                sql += " ) ";
                Resultado = this.EjecutarQuery(sql);
                this.CerrarConxion();
                return Resultado;
            }
            catch (Exception ex)
            {
                Resultado = false;
                strMensaje = ex.Message;
                return Resultado;
            }
        }
        /*public bool ConsultarEstado(ref TipoEstadoPlano intResultado, ref string strMensaje, string strUi)
        {
            bool Resultado = true;
            try
            {
                string sql = string.Empty;
                sql="select estado from Predio where ui='" + strUi + "'";
                Resultado = this.EjecutarQuery(sql);
                SQLiteDataReader read = this.EjecutarConsulta(sql);
                if (read.HasRows)
                {
                    while (read.Read())
                    {
                        intResultado = (read[0] == null ? TipoEstadoPlano.error :(TipoEstadoPlano) read.GetInt32(0));
                        Resultado = true ;
                    }
                }
                else
                {
                    Resultado = false;
                    intResultado = TipoEstadoPlano.ninguno;
                }
                read.Dispose();
                this.CerrarConxion();
                return Resultado;
            }
            catch (Exception ex)
            {
                intResultado= TipoEstadoPlano.ninguno;
                Resultado = false;
                strMensaje = ex.Message;
                return Resultado;
            }
        }*/
           
       
    }
}
