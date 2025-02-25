using iTextSharp.text.pdf;
using JEJ.ImprimirFicha.Modelo.Listas;
using JEJ.ImprimirFicha.Negocio.Utilidades;
using System.Collections.Generic;

namespace JEJ.ImprimirFicha.Negocio.Reportes
{
    public class ja_Calificacion : _formatoReporte
    {
        #region Variables
        List<Consultar_Calificacion_Result> lstCalificacion;
        private float[] widths = new float[] { 2f, 2f, 2f, 2f, 2f, 2f, 2f, 2f, 2f, 2f, 2f, 2f };
        private int intColumnas = 12;
        #endregion

        #region Constructor
        public ja_Calificacion(List<Consultar_Calificacion_Result> lstCalificacion)
        {
            this.lstCalificacion = lstCalificacion;
            crearTabla();
        }
        #endregion

        #region Metodos Privados
        public void crearTabla()
        {
            PdfPCell cellTextoSubcalificacion = UPdfReportes.CellSubtitulo("SUBCALIFICACIÓN", 3, 1);
            PdfPCell cellTextoCodigo = UPdfReportes.CellSubtitulo("N°", 1, 1);
            PdfPCell cellTextoDescripcion = UPdfReportes.CellSubtitulo("DESCRIPCIÓN", 6, 1);
            PdfPCell cellTextoPuntosCalificacion = UPdfReportes.CellSubtitulo("PUNTOS", 2, 1);

            table = UPdfReportes.configurarTabla(intColumnas, widths);
            table.AddCell(cellTextoSubcalificacion);
            table.AddCell(cellTextoCodigo);
            table.AddCell(cellTextoDescripcion);
            table.AddCell(cellTextoPuntosCalificacion);

            PdfPCell cellDescripcionSubcalificacion;
            PdfPCell celltableCalifiacion;
            PdfPTable tableCalifiacion = new PdfPTable(9);
            string strDescripcionSubcalificacion = string.Empty;
            
            foreach (Consultar_Calificacion_Result Calificacion in lstCalificacion)
            {
                if (strDescripcionSubcalificacion != Calificacion.strDescripcionSubCalificacion)
                {
                    cellDescripcionSubcalificacion= UPdfReportes.CellValores(strDescripcionSubcalificacion, 3, 0);
                    

                    celltableCalifiacion = new PdfPCell(tableCalifiacion);
                    celltableCalifiacion.Colspan = 9;
                    celltableCalifiacion.HorizontalAlignment = 0;

                    table.AddCell(cellDescripcionSubcalificacion);
                    table.AddCell(celltableCalifiacion);

                    tableCalifiacion = new PdfPTable(9);
                    strDescripcionSubcalificacion = Calificacion.strDescripcionSubCalificacion;

                }
                PdfPCell cellCodigo = UPdfReportes.CellValores(Calificacion.strCodigoCalificacion, 1, 0);
                PdfPCell cellDescripcion = UPdfReportes.CellValores(Calificacion.strDescripcion, 6, 0);
                PdfPCell cellPuntosCalificacion = UPdfReportes.CellValores(Calificacion.strPuntos, 2, 1);
                
                tableCalifiacion.AddCell(cellCodigo);
                tableCalifiacion.AddCell(cellDescripcion);
                tableCalifiacion.AddCell(cellPuntosCalificacion);
            }
            cellDescripcionSubcalificacion =  UPdfReportes.CellValores(strDescripcionSubcalificacion, 3, 0);

            celltableCalifiacion = new PdfPCell(tableCalifiacion);
            celltableCalifiacion.Colspan = 9;
            celltableCalifiacion.HorizontalAlignment = 1;

            table.AddCell(cellDescripcionSubcalificacion);
            table.AddCell(celltableCalifiacion);

        }
        #endregion

        #region Metodos Publicos

        #endregion

    }
}
