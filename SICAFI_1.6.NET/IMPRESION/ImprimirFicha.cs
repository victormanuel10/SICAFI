using iTextSharp.text;
using iTextSharp.text.pdf;
using JEJ.ImprimirFicha.Modelo.Listas;
using JEJ.ImprimirFicha.Negocio;
using JEJ.ImprimirFicha.Negocio.Reportes;
using JEJ.ImprimirFicha.Negocio.Utilidades.Enum;
using JEJ.ImprimirFicha.Utilidades;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;


namespace JEJ.ImprimirFicha
{
    public class ImprimirFicha
    {
        #region Varibales
        string strInstancia;
        string strUsuario;
        string strClave;
        string strNumeroFicha;
        string strShapePredios;
        string strShapeConstruccion;
        string strRutaEjecutable;
        string RutaOrtoforto;
        string strRutaAplicacion;
        string strRutaPython;
        bool blPlano;
        Guid g;
        #endregion
        #region Constructor
        public ImprimirFicha(
            string strRutaPython
            , string strRutaAplicacion
            ,string strInstancia
            , string strUsuario
            , string strClave
            , string strNumeroFicha
            , string strShapePredios
            , string strShapeConstruccion
            ,string strRutaEjecutable
            ,string RutaOrtoforto
            , bool blPlano)
        {
            this.strInstancia = strInstancia;
            this.strUsuario = strUsuario;
            this.strClave = strClave;
            this.strNumeroFicha = strNumeroFicha;
            this.strShapePredios = strShapePredios;
            this.strShapeConstruccion = strShapeConstruccion;
            this.strRutaEjecutable = strRutaEjecutable;
            this.RutaOrtoforto = RutaOrtoforto;
            this.strRutaAplicacion = strRutaAplicacion;
            this.strRutaPython = strRutaPython;
            this.blPlano = blPlano;
        }
        #endregion
        #region Metodos Privados
        private void DirectoryCopy(string sourceDirName, string destDirName, bool copySubDirs)
        {
            // Get the subdirectories for the specified directory.
            DirectoryInfo dir = new DirectoryInfo(sourceDirName);

            if (!dir.Exists)
            {
                throw new DirectoryNotFoundException(
                    "Source directory does not exist or could not be found: "
                    + sourceDirName);
            }

            DirectoryInfo[] dirs = dir.GetDirectories();
            // If the destination directory doesn't exist, create it.
            if (!Directory.Exists(destDirName))
            {
                Directory.CreateDirectory(destDirName);
            }

            // Get the files in the directory and copy them to the new location.
            FileInfo[] files = dir.GetFiles();
            foreach (FileInfo file in files)
            {
                string temppath = Path.Combine(destDirName, file.Name);
                file.CopyTo(temppath, false);
            }

            // If copying subdirectories, copy them and their contents to new location.
            if (copySubDirs)
            {
                foreach (DirectoryInfo subdir in dirs)
                {
                    string temppath = Path.Combine(destDirName, subdir.Name);
                    DirectoryCopy(subdir.FullName, temppath, copySubDirs);
                }
            }
        }
        #endregion
        #region Metodos Publicos
        public bool Imprimir(string strRutaExportar, ref string strscript)
        {
            string strNombrePdf;
            bool Resultado;

            string strNombreArchivo;
            string strRutaCarpeta = string.Empty;
            string strRutaNuevoPredio = string.Empty;
            string strRutaNuevoConstruccion = string.Empty;
            FileInfo infoShapePredio;
            FileInfo infoShapeConstruccion;
            DirectoryInfo ifDirectorioPredio;
            DirectoryInfo ifDirectorioConstruccion;
            DateTime dtLasPredio;
            try
            {
                string strMensaje = string.Empty;                
                DataTablesFichaPredial objDT = new DataTablesFichaPredial(this.strInstancia
                                                                   , "SICAFI"
                                                                   , this.strUsuario
                                                                   , this.strClave);
                List<Consultar_Predio_Result> lstPredio = objDT.ConsultarPredio("266"
                                                                            , string.Empty
                                                                            , string.Empty
                                                                            , string.Empty
                                                                            , string.Empty
                                                                            , string.Empty
                                                                            , string.Empty
                                                                            , string.Empty
                                                                            , this.strNumeroFicha
                                                                            , ref strMensaje);
                if (lstPredio.Count > 0)
                {
                    Consultar_Predio_Result Predio = lstPredio[0];
                    string strRutaAplicacion = this.strRutaAplicacion;
                    g = Guid.NewGuid(); strNombreArchivo = g.ToString();
                    strRutaCarpeta += strRutaAplicacion+ "\\" + strNombreArchivo;
                    if (!Directory.Exists(strRutaCarpeta))
                    {
                        Directory.CreateDirectory(strRutaCarpeta);
                    }
                    Resultado = CopiarArchivos.CopiarEjecutables(strNombreArchivo, strRutaCarpeta);
                    if (Resultado)
                    {
                        infoShapePredio = new FileInfo(strShapePredios);
                        infoShapeConstruccion = new FileInfo(strShapeConstruccion);
                        dtLasPredio = infoShapePredio.LastWriteTime;

                        ifDirectorioPredio = infoShapePredio.Directory;
                        ifDirectorioConstruccion = infoShapeConstruccion.Directory;
                        strRutaNuevoPredio = strRutaCarpeta + "\\" + ifDirectorioPredio.Name;
                        strRutaNuevoConstruccion = strRutaCarpeta + "\\" + ifDirectorioConstruccion.Name;
                        DirectoryCopy(ifDirectorioPredio.FullName, strRutaNuevoPredio, true);
                        DirectoryCopy(ifDirectorioConstruccion.FullName, strRutaNuevoConstruccion, true);
                        Resultado = CopiarArchivos.CopiarMXD(strRutaCarpeta);
                        Resultado = CopiarArchivos.CopiarArchivosStaticos(strRutaCarpeta);
                        if (Resultado)
                        {
                            if (blPlano)
                            {
                                List<string> lstParametros = new List<string>();
                                lstParametros.Add(Predio.strNumeroFicha);
                                lstParametros.Add("\"" + strRutaNuevoPredio + "\\" + infoShapePredio.Name + "\"");
                                lstParametros.Add("\"" + strRutaNuevoConstruccion + "\\" + infoShapeConstruccion.Name + "\"");
                                lstParametros.Add("\"" + strRutaCarpeta + "\\JEJCatastro.mdb" + "\"");
                                lstParametros.Add("\"" + this.strUsuario + "\"");
                                lstParametros.Add("\"" + this.strClave + "\"");
                                lstParametros.Add("\"" + this.strInstancia + "\"");
                                lstParametros.Add("\"" + strRutaCarpeta + "\"");
                                lstParametros.Add("\"" + this.RutaOrtoforto + "\"");


                                PythonUtilities.ExecuteCommand(this.strRutaEjecutable, lstParametros, this.strRutaPython, ref strscript);
                            }
                            
                            List<Consultar_Propietario_Result> lstPropietario = objDT.ConsultarDatatablePropietario(Convert.ToInt32(Predio.strNumeroFicha)
                                                                                                            , ref strMensaje);
                            List<Consultar_Construcciones_Result> lstConstruccionNormal = objDT.ConsultarConstruccionNormal(Convert.ToInt32(Predio.strNumeroFicha), "1"
                                                                                                                    , ref strMensaje);

                            Consultar_CategoriaPredio_Result objCategoriaPredio = objDT.ConsultarCategoriaPredio(Predio.strNumeroFicha);
                            List<Consultar_Colindantes_Result> lstColindante = objDT.ConsultarLindero(Convert.ToInt32(Predio.strNumeroFicha));
                            List<Consultar_Informacion_Geografica_Result> lstCartografia = objDT.ConsultarCartografia(Convert.ToInt32(Predio.strNumeroFicha), ref strMensaje);
                            List<Consultar_Zonas_Economicas_Result> lstZonasEconomicas = objDT.Consultar_Zonas_Economicas(Predio.strNumeroFicha);
                            List<Consultar_Zonas_Fisicas_Result> lstZonasFisicas = objDT.Consultar_Zonas_Fisicas(Predio.strNumeroFicha);
                            strNombrePdf = strRutaExportar + "\\" + Predio.strNumeroFicha + ".pdf";
                            Document document = new Document(PageSize.LETTER.Rotate(), 50, 30, 40, 30);
                            PdfWriter.GetInstance(document, new FileStream(strNombrePdf, FileMode.Create));
                            a_Encabezado objEncabezado = new a_Encabezado(strRutaCarpeta + "\\Portada.png");
                            b_DatosPredio objDatosPredio = new b_DatosPredio(Predio);
                            c_CedulaCatastral objCedula = new c_CedulaCatastral(Predio);
                            d_CedulaCatastralAnterior objCedulaCatastralAnterior = new d_CedulaCatastralAnterior(Predio);
                            e_DestinoEconomico objDestino = new e_DestinoEconomico(Predio, objCategoriaPredio);
                            f_CaracteristicaPredio objCaracteristica = new f_CaracteristicaPredio(Predio);
                            g_Adquisicion objAdquisicion = new g_Adquisicion(Predio);
                            h_Propietario objPropietario = new h_Propietario(lstPropietario);
                            i_JustificacionPropietario objJustificacionPropietario = new i_JustificacionPropietario(lstPropietario);
                            j_Construccion objConstruccion = new j_Construccion(lstConstruccionNormal, objDT, Predio, strRutaCarpeta, document);
                            k_PlanoConstruccion objPlanoConstruccion = new k_PlanoConstruccion(Predio.strNumeroFicha, strRutaCarpeta);
                            l_Linderos objLindero = new l_Linderos(lstColindante);
                            m_InformacionGrafica objInformacionGrafica = new m_InformacionGrafica(lstCartografia);
                            n_InformacionAerografica objinformacionAerografica = new n_InformacionAerografica(lstCartografia);
                            o_ZonasFisicas objZonasFisicas = new o_ZonasFisicas(lstZonasFisicas);
                            p_ZonasEconomicos objZonasEconomicas = new p_ZonasEconomicos(lstZonasEconomicas);
                            s_InformacionComplementaria objInformacionComplementaria = new s_InformacionComplementaria(Predio.strObservacionFicha);
                            t_InformacionFecha objInformacionFechas = new t_InformacionFecha(Predio.strFechaModificacion.ToShortDateString(), infoShapePredio.LastWriteTime.ToShortDateString());
                            document.Open();
                            document.Add(objEncabezado.getTable());
                            document.Add(objDatosPredio.getTable());
                            document.Add(objCedula.getTable());
                            document.Add(objCedulaCatastralAnterior.getTable());
                            document.Add(objDestino.getTable());
                            document.Add(objCaracteristica.getTable());
                            document.Add(objAdquisicion.getTable());
                            document.Add(objPropietario.getTable());
                            document.Add(objJustificacionPropietario.getTable());
                            objConstruccion.crearTabla();
                            if (blPlano)
                            {
                                document.Add(objPlanoConstruccion.getTable());
                            }                            
                            document.Add(objLindero.getTable());
                            document.Add(objInformacionGrafica.getTable());
                            document.Add(objinformacionAerografica.getTable());
                            document.Add(objZonasFisicas.getTable());
                            document.Add(objZonasEconomicas.getTable());
                            if (Predio.strCaracteristicaPredio == "2" || Predio.strCaracteristicaPredio == "3" || Predio.strCaracteristicaPredio == "4")
                            {
                                Consultar_Predio_Result FichaResumen = new Consultar_Predio_Result();
                                List<Consultar_Predio_Result> lstFichaResumen = objDT.ConsultarPredioResumen(Predio.strMunicipio
                                                                                                        , Predio.strSector
                                                                                                        , Predio.strCorregimiento
                                                                                                        , Predio.strBarrio
                                                                                                        , Predio.strManzana
                                                                                                        , Predio.strPredio
                                                                                                        , ref strMensaje);
                                foreach (Consultar_Predio_Result fr in lstFichaResumen)
                                {
                                    if (fr.strTipoFicha == "2")
                                    {
                                        FichaResumen = fr;
                                    }
                                }
                                q_InformacionResumen objInformacionResumen = new q_InformacionResumen(FichaResumen);
                                r_InformacionResumenGenerales objInformacionResumenGenerales = new r_InformacionResumenGenerales(FichaResumen);
                                document.Add(objInformacionResumen.getTable());
                                document.Add(objInformacionResumenGenerales.getTable());
                            }
                            document.Add(objInformacionComplementaria.getTable());
                            document.Add(objInformacionFechas.getTable());
                            document.Close();
                            if (Directory.Exists(strRutaCarpeta))
                            {
                                Directory.Delete(strRutaCarpeta, true);
                            }
                            objDT.Eliminar_Estado_Impresion(Convert.ToInt32(Predio.strNumeroFicha), strNombreArchivo);
                            return true;
                        }
                        else
                        {
                            if (Directory.Exists(strRutaCarpeta))
                            {
                                System.IO.Directory.Delete(strRutaCarpeta, true);
                            }
                            return Resultado;
                        }
                    }
                    else
                    {
                        if (Directory.Exists(strRutaCarpeta))
                        {
                            Directory.Delete(strRutaCarpeta, true);
                        }
                        return Resultado;
                    }
                }
                else
                {
                    MessageBox.Show("El predio no existe en la base de datos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    if (Directory.Exists(strRutaCarpeta))
                    {
                        Directory.Delete(strRutaCarpeta, true);
                    }
                    return false;
                }

            }
            catch (Exception ex)
            {
                try
                {
                    if (Directory.Exists(strRutaCarpeta))
                    {
                        Directory.Delete(strRutaCarpeta, true);
                    }
                }
                catch (Exception exc)
                {

                }
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
        #endregion
    }
}
