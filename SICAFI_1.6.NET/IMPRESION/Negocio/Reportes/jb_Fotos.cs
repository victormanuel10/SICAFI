using iTextSharp.text.pdf;
using JEJ.ImprimirFicha.Modelo.Listas;
using JEJ.ImprimirFicha.Negocio.Utilidades;
using JEJ.ImprimirFicha.Negocio.Utilidades.TipoDato;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JEJ.ImprimirFicha.Negocio.Reportes
{
    public class jb_Fotos : _formatoReporte
    {
        #region Variables
        private float[] widths = new float[] { 2f, 2f };
        private int intColumnas = 2;
        private List<Consultar_Tipo_Foto_Result> lstTipoFotoConstruccion;
        private string strUnidad;
        private string strNumeroFicha;
        private string strRutaCarpeta;
        #endregion

        #region Constructor
        public jb_Fotos(List<Consultar_Tipo_Foto_Result> lstTipoFotoConstruccion, string strUnidad, string strNumeroFicha, string strRutaCarpeta)
        {
            this.lstTipoFotoConstruccion = lstTipoFotoConstruccion;
            this.strUnidad = strUnidad;
            this.strNumeroFicha = strNumeroFicha;
            this.strRutaCarpeta = strRutaCarpeta;
            crearTabla();
        }
        #endregion

        #region Metodos Publicos
        public void crearTabla()
        {
            int contador = 0;
            int intFaltante = 0;
            table = UPdfReportes.configurarTabla(intColumnas, widths);
            IMPRESION.Properties.Resources.FondoBlanco400.Save(strRutaCarpeta + "\\FondoBlanco400.png");
            foreach (Consultar_Tipo_Foto_Result tipoFoto in lstTipoFotoConstruccion)
            {
               
                string strFoto = tipoFoto.strRuta + "\\" + strNumeroFicha + "-" + strUnidad + "-" + tipoFoto.strTipoFoto + ".jpg";
                if (File.Exists(strFoto))
                {
                    FileInfo infoImagen = new FileInfo(strFoto);
                    string struevaImagen = strRutaCarpeta + "\\" + infoImagen.Name;
                    File.Copy(strFoto, struevaImagen);
                    tipoImagenes.ReziseHeight(struevaImagen, 120);
                    PdfPCell cellImagen = UPdfReportes.CellFotosConstruccion(struevaImagen, tipoFoto.strNombreTipo);
                    table.AddCell(cellImagen);
                }
                else
                {
                    PdfPCell cellImagen = UPdfReportes.CellFotosConstruccion(strRutaCarpeta + "\\FondoBlanco400.png", tipoFoto.strNombreTipo);
                    table.AddCell(cellImagen);
                }
                contador++;
            }
            if (contador < 2)
            {
                intFaltante = 1;
            }else if (contador > 2)
            {
                intFaltante = contador % 2;
            }
            for (int i = 0; i < intFaltante; i++)
            {
                PdfPCell cellFoto = UPdfReportes.CellFotosConstruccion(strRutaCarpeta + "\\FondoBlanco400.png", string.Empty);
                table.AddCell(cellFoto);
            }
        }
        #endregion

    }
}
