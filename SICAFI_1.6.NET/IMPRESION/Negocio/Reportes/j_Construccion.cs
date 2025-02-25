using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using JEJ.ImprimirFicha.Modelo.Listas;
using JEJ.ImprimirFicha.Negocio.Utilidades;

namespace JEJ.ImprimirFicha.Negocio.Reportes
{
    public class j_Construccion : _formatoReporte
    {
        #region Variables
        private List<Consultar_Construcciones_Result> lstConstruccion;
        private Consultar_Predio_Result Predio;
        private float[] widths = new float[] { 2f, 2f, 2f, 2f, 2f, 2f, 2f, 2f, 2f, 2f, 2f, 2f };
        private DataTablesFichaPredial entity;
        private string strRutaCarpeta;
        private Document doc;
        private int intColumnas = 12;
        #endregion
        #region Constructor
        public j_Construccion(List<Consultar_Construcciones_Result> lstConstruccion
            , DataTablesFichaPredial entity
            , Consultar_Predio_Result Predio
            , string strRutaCarpeta
            , Document doc)
        {
            this.lstConstruccion = lstConstruccion;
            this.entity = entity;
            this.Predio = Predio;
            this.strRutaCarpeta = strRutaCarpeta;
            this.doc = doc;

        }
        #endregion
        #region Metodos Privados
        public void crearTabla()
        {

            PdfPCell cellTextoCodigoIndentificador = UPdfReportes.CellSubtitulo("INDENTIFICADOR", 2, 1);
            PdfPCell cellTextoIndentificador = UPdfReportes.CellSubtitulo("DESCRIPCIÓN INDENTIFICADOR", 5, 1);
            PdfPCell cellTextoPuntos = UPdfReportes.CellSubtitulo("PUNTOS", 1, 1);
            PdfPCell cellTextoAreaConstruida = UPdfReportes.CellSubtitulo("AREA CONSTRUIDA", 2, 1);
            PdfPCell cellTextoMejora = UPdfReportes.CellSubtitulo("MEJORA", 1, 1);
            PdfPCell cellTextoLey56 = UPdfReportes.CellSubtitulo("LEY 56", 1, 1);
            
            foreach (Consultar_Construcciones_Result Construccion in lstConstruccion)
            {
                table = UPdfReportes.configurarTabla(intColumnas, widths);

                List<Consultar_Tipo_Foto_Result> lstTipoFotoConstruccion = this.entity.ConsultarRutasFotos("05", Predio.strMunicipio, Predio.strSector);
                string strDescripcionSubcalificacion = string.Empty;
                PdfPCell cellTextoTitulo = UPdfReportes.CellTitulo("CONSTRUCCIÓN " + Construccion.strUnidad, 12);

                table.AddCell(cellTextoTitulo);
                table.AddCell(cellTextoCodigoIndentificador);
                table.AddCell(cellTextoIndentificador);
                table.AddCell(cellTextoPuntos);
                table.AddCell(cellTextoAreaConstruida);
                table.AddCell(cellTextoMejora);
                table.AddCell(cellTextoLey56);

                PdfPCell cellCodigoIdentificador = UPdfReportes.CellValores(Construccion.strIdentificador, 2, 1);
                PdfPCell cellIndentificador = UPdfReportes.CellValores(Construccion.strDescripcionIdentificador, 5, 1);
                PdfPCell cellPuntos = UPdfReportes.CellValores(Construccion.strTotalPuntos, 1, 1);
                PdfPCell cellAreaConstruida = UPdfReportes.CellValores(Construccion.strArea, 2, 1);
                PdfPCell cellMejora = UPdfReportes.CellValores(Construccion.strMejora, 1, 1);
                PdfPCell cellLey56 = UPdfReportes.CellValores(Construccion.strLey59, 1, 1);

                table.AddCell(cellCodigoIdentificador);
                table.AddCell(cellIndentificador);
                table.AddCell(cellPuntos);
                table.AddCell(cellAreaConstruida);
                table.AddCell(cellMejora);
                table.AddCell(cellLey56);
                doc.Add(getTable());              

                List<Consultar_Calificacion_Result> lstCalificacion =
                    this.entity.ConsultarCalificacion(Convert.ToInt32(Construccion.strNufi), Construccion.strUnidad);
                if (lstCalificacion.Count > 0)
                {
                    ja_Calificacion objJa_Calificacion = new ja_Calificacion(lstCalificacion);
                    doc.Add(objJa_Calificacion.getTable());
                }
                

                if (lstTipoFotoConstruccion.Count > 0)
                 {
                    jb_Fotos objFotos = new jb_Fotos(lstTipoFotoConstruccion, Construccion.strUnidad, Construccion.strNufi, strRutaCarpeta);
                    doc.Add(objFotos.getTable());
                     
                 }
            }
        }
        #endregion
        #region Metodos Publicos
        public void setLstConstruccion(List<Consultar_Construcciones_Result> lstConstruccion)
        {
            this.lstConstruccion = lstConstruccion;

        }
        public List<Consultar_Construcciones_Result> getLstConstruccion()
        {
            return this.lstConstruccion;
        }

        #endregion
    }
}
