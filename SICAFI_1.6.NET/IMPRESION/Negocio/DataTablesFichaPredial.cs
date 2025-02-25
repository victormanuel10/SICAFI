using JEJ.ImprimirFicha.Modelo;
using JEJ.ImprimirFicha.Modelo.Listas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace JEJ.ImprimirFicha.Negocio
{
    public class DataTablesFichaPredial
    {

        #region Variables de la calse
        /// <summary>
        /// objeto donde se consultas las tablas de sicafi
        /// </summary>
        EntitySicafi objEntitySicafi;
        #endregion
        #region CONSTRUCTOR
        /// <summary>
        /// consturctor
        /// </summary>
        /// <param name="strServidor">Servidor donde se ejecuta el sicafi</param>
        /// <param name="strBaseDatos">Base de datos Sicafi</param>
        /// <param name="strUsuario">Usuario del sicafi</param>
        /// <param name="strClave">clave del sicafi</param>
        public DataTablesFichaPredial(string strServidor, string strBaseDatos, string strUsuario, string strClave)
        {
            this.objEntitySicafi = new EntitySicafi(strServidor, strBaseDatos, strUsuario, strClave);
        }
        #endregion
        #region METODOS PUBLICO
        /// <summary>
        /// Consulta la lista de predios
        /// </summary>
        /// <param name="strMunicipio">Municipio</param>
        /// <param name="strSector">Sector</param>
        /// <param name="strCorregimiento">Corregimiento</param>
        /// <param name="strBarrio">Barrio</param>
        /// <param name="strManzna">Manzana</param>
        /// <param name="strPredio">Predio</param>
        /// <param name="strEdificio">Edificio</param>
        /// <param name="strUnidadPredial">Unidad Predial</param>
        /// <returns>Retorna una lisat de predios</returns>
        public List<Consultar_Predio_Result> ConsultarPredio(string strMunicipio
                                    , string strSector
                                    , string strCorregimiento
                                    , string strBarrio
                                    , string strManzna
                                    , string strPredio
                                    , string strEdificio
                                    , string strUnidadPredial
                                    , string strNumeroFicha
                                    , ref string strMensaje)
        {
            List<Consultar_Predio_Result> lstPredio = new List<Consultar_Predio_Result>();
            try
            {
                lstPredio = this.objEntitySicafi.Consultar_Predio(strMunicipio
                                    , strSector
                                    , strCorregimiento
                                    , strBarrio
                                    , strManzna
                                    , strPredio
                                    , strEdificio
                                    , strUnidadPredial
                                    , strNumeroFicha);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                strMensaje = ex.Message;
                lstPredio = new List<Consultar_Predio_Result>();
            }
            return lstPredio;
        }

        public List<Consultar_Predio_Result> ConsultarPredioResumen(string strMunicipio
                                   , string strSector
                                   , string strCorregimiento
                                   , string strBarrio
                                   , string strManzna
                                   , string strPredio
                                   , ref string strMensaje)
        {
            List<Consultar_Predio_Result> lstPredio = new List<Consultar_Predio_Result>();
            try
            {
                lstPredio = this.objEntitySicafi.Consultar_Predio_Resumen(strMunicipio
                                    , strSector
                                    , strCorregimiento
                                    , strBarrio
                                    , strManzna
                                    , strPredio);
            }
            catch (Exception ex)
            {
                strMensaje = ex.Message;
                lstPredio = new List<Consultar_Predio_Result>();
            }
            return lstPredio;
        }


        /// <summary>
        /// Genera el data table del propietario
        /// </summary>
        /// <param name="NumeroFicha">Numero de ficha</param>
        /// <returns>retorna el una datatable con la informacion del propietario</returns>
        public List<Consultar_Propietario_Result> ConsultarDatatablePropietario(int NumeroFicha, ref string strMensaje)
        {
            List<Consultar_Propietario_Result> lstPropietario;
            try
            {
                lstPropietario = this.objEntitySicafi.Consultar_Propietario(NumeroFicha);
            }
            catch (Exception ex)
            {
                strMensaje = ex.Message;
                lstPropietario = new List<Consultar_Propietario_Result>();
            }
            return lstPropietario;

        }
        /// <summary>
        /// Genera el datatable de la informacion de el propietario
        /// </summary>
        /// <param name="NumeroFicha"></param>
        /// <returns></returns>
        public List<Consultar_Propietario_Result> ConsultarDatatableInfromacionEscritura(int NumeroFicha, ref string strMensaje)
        {
            List<Consultar_Propietario_Result> lstPropietario = new List<Consultar_Propietario_Result>();
            try
            {
                lstPropietario = this.objEntitySicafi.Consultar_Propietario(NumeroFicha);
            }
            catch (Exception ex)
            {
                strMensaje = ex.Message;
            }
            return lstPropietario;
        }
        /// <summary>
        /// Crea la datatabla de lindero 
        /// </summary>
        /// <param name="NumeroFicha">numero de ficha</param>
        /// <returns>devuelve un data table</returns>
        public List<Consultar_Colindantes_Result> ConsultarLindero(int NumeroFicha)
        {
            List<Consultar_Colindantes_Result> lstLindero = new List<Consultar_Colindantes_Result>();
            this.ConsultarCadaLindero(ref lstLindero, NumeroFicha, "N");
            this.ConsultarCadaLindero(ref lstLindero, NumeroFicha, "E");
            this.ConsultarCadaLindero(ref lstLindero, NumeroFicha, "S");
            this.ConsultarCadaLindero(ref lstLindero, NumeroFicha, "O");
            this.ConsultarCadaLindero(ref lstLindero, NumeroFicha, "ZE");
            this.ConsultarCadaLindero(ref lstLindero, NumeroFicha, "NA");
            return lstLindero;
        }
        /// <summary>
        /// Consulta 
        /// </summary>
        /// <param name="NumeroFicha"></param>
        /// <returns></returns>
        public List<Consultar_Informacion_Complementaria_Result> ConsultarInformacionComplementaria(int NumeroFicha, ref string strMensaje)
        {

            List<Consultar_Informacion_Complementaria_Result> lst = new List<Consultar_Informacion_Complementaria_Result>();
            try
            {
                lst = this.objEntitySicafi.Consultar_Inforamcion_Complementaria(NumeroFicha);
            }
            catch (Exception ex)
            {
                lst = new List<Consultar_Informacion_Complementaria_Result>();
            }
            return lst;
        }
        /// <summary>
        /// Consulta la infomacion Cartografica
        /// </summary>
        /// <param name="Numeroficha"></param>
        /// <returns></returns>
        public List<Consultar_Informacion_Geografica_Result> ConsultarCartografia(int Numeroficha, ref string strMensaje)
        {
            List<Consultar_Informacion_Geografica_Result> ls = new List<Consultar_Informacion_Geografica_Result>();
            try
            {
                ls = this.objEntitySicafi.Consultar_Informacion_Geografico(Numeroficha);
            }
            catch (Exception ex)
            {
                strMensaje = ex.Message;
                ls = new List<Consultar_Informacion_Geografica_Result>();
            }
            return ls;
        }

        /// <summary>
        /// Consulta las COnstrucciones Con clase 1
        /// </summary>
        /// <param name="intNumeroFicha">Numero de ficha</param>
        /// <returns>retorna datatable</returns>
        public List<Consultar_Construcciones_Result> ConsultarConstruccionNormal(int intNumeroFicha, string strTipo, ref string strMensaje)
        {
            List<Consultar_Construcciones_Result> lst = new List<Consultar_Construcciones_Result>();
            try
            {
                lst = this.objEntitySicafi.Consultar_Construcciones(intNumeroFicha, strTipo);
            }
            catch (Exception ex)
            {
                strMensaje = ex.Message;
                lst = new List<Consultar_Construcciones_Result>();
            }
            return lst;
        }


        public List<Consultar_Calificacion_Result> ConsultarCalificacion(int intNumeroFicha, string NumeroConstruccion)
        {
            List<Consultar_Calificacion_Result> lstClificacion = new List<Consultar_Calificacion_Result>();
            lstClificacion = this.objEntitySicafi.Consultar_Calificacion(intNumeroFicha, NumeroConstruccion);
            return lstClificacion;
        }

        public List<Consultar_Tipo_Foto_Result> ConsultarRutasFotos(string strDepartamento, string strMunicipio, string strSecto)
        {
            List<Consultar_Tipo_Foto_Result> lstRutas = new List<Consultar_Tipo_Foto_Result>();
            lstRutas = this.objEntitySicafi.Consultar_Rutas(strDepartamento, strMunicipio, strSecto);
            return lstRutas;
        }

        public Consultar_CategoriaPredio_Result ConsultarCategoriaPredio(string strNufi)
        {
            List<Consultar_CategoriaPredio_Result> lst = new List<Consultar_CategoriaPredio_Result>();
            Consultar_CategoriaPredio_Result objCategoriaPredio;
            lst = this.objEntitySicafi.Consultar_Categoria_Predio(strNufi);
            if (lst.Count >= 1)
            {
                objCategoriaPredio = lst[0];
            }
            else
            {
                objCategoriaPredio = new Consultar_CategoriaPredio_Result()
                {
                    strNufi = string.Empty,
                    strCodigo = string.Empty,
                    strDescripcion = string.Empty
                };
            }
            return objCategoriaPredio;
        }
        #endregion
        #region Zonas
        public List<Consultar_Zonas_Fisicas_Result> Consultar_Zonas_Fisicas(string strNufi)
        {
            List<Consultar_Zonas_Fisicas_Result> lstZonas = this.objEntitySicafi.Consultar_Zonas_Fisicas(strNufi);
            return lstZonas;
        }
        public List<Consultar_Zonas_Economicas_Result> Consultar_Zonas_Economicas(string strNufi)
        {
            List<Consultar_Zonas_Economicas_Result> lstZonas = this.objEntitySicafi.Consultar_Zonas_Economicas(strNufi);
            return lstZonas;
        }
        #endregion

        #region METODOS DE COMPARACION
        public Consultar_Estado_Impresion Consultar_Estado_Impresion(int intNufi, string strUi)
        {
            Consultar_Estado_Impresion lst = this.objEntitySicafi.Consultar_Estado_Impresion(intNufi, strUi);
            return lst;
        }

        public bool Insertar_Estado_Impresion(int intNufi
                                            , string strRutaPredio
                                            , string strRutaConstrucion
                                            , string strRutaGDB
                                            , string strUi
                                            , int intEstado)
        {
            int numeroResultado = 0;
            numeroResultado= this.objEntitySicafi.Insertar_Estado_Impresion(intNufi
                                            , strRutaPredio
                                            , strRutaConstrucion
                                            , strRutaGDB
                                            , strUi
                                            , intEstado);
            if (numeroResultado > 0)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        
        public bool Eliminar_Estado_Impresion(int intNufi, string strUi)
        {
            int numeroResultado = 0;
            numeroResultado = this.objEntitySicafi.Eliminar_Estado_Impresion(intNufi, strUi);
            if (numeroResultado > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        #endregion

        #region METODOS PRIVADOS
        /// <summary>
        /// Consulta cada lindero
        /// </summary>
        /// <param name="dt">data table donde se cra los rows</param>
        /// <param name="NumeroFicha">Numero de ficha</param>
        /// <param name="strColindante">colindante a consultar</param>
        /// <param name="intNumero">numero autonumerico</param>
        private void ConsultarCadaLindero(ref List<Consultar_Colindantes_Result> lstLindero, int NumeroFicha, string strColindante)
        {
            List<Consultar_Colindantes_Result> lst = this.objEntitySicafi.Consultar_Colindantes(NumeroFicha, strColindante);
            foreach (Consultar_Colindantes_Result Colindante in lst)
            {
                lstLindero.Add(Colindante);
            }
        }


        #endregion

    }
}
