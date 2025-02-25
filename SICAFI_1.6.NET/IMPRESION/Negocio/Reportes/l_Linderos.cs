using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JEJ.ImprimirFicha.Modelo.Listas;
using iTextSharp.text;
using iTextSharp.text.pdf;
using JEJ.ImprimirFicha.Negocio.Utilidades;

namespace JEJ.ImprimirFicha.Negocio.Reportes
{
    public class l_Linderos : _formatoReporte
    {
        #region Variables
        private List<Consultar_Colindantes_Result> lstLindero;       
        private float[] widths = new float[] { 2f, 2f, 2f, 2f, 2f, 2f, 2f, 2f, 2f, 2f };
        private int intColumnas = 10;
        #endregion

        #region Constructor
        public l_Linderos(List<Consultar_Colindantes_Result> lstLindero)
        {
            this.lstLindero = lstLindero;
            creatTable();
        }
        #endregion

        #region Metodos Privados
        private void creatTable()
        {
            table = UPdfReportes.configurarTabla(intColumnas, widths);
            int Contador = 1;
            PdfPCell cellTextoTituloColindante = UPdfReportes.CellTitulo("COLINDANTES ", 10);
            PdfPCell cellTextoCedulaNO = UPdfReportes.CellSubtitulo("NO", 1, 1);
            PdfPCell cellTextoPuntoCardinal = UPdfReportes.CellSubtitulo("PUNTO CARDINAL", 3, 1);
            PdfPCell cellTextoColindante = UPdfReportes.CellSubtitulo("PUNTO COLINDANTE", 7, 1);                       
            table.AddCell(cellTextoTituloColindante);
            table.AddCell(cellTextoCedulaNO);
            table.AddCell(cellTextoPuntoCardinal);
            table.AddCell(cellTextoColindante);
            foreach(Consultar_Colindantes_Result lindero in lstLindero)
            {
                PdfPCell cellCedulaNO = UPdfReportes.CellValores(Convert.ToString(Contador), 1, 1);
                PdfPCell cellPuntoCardinal = UPdfReportes.CellValores(lindero.strOrientacion, 3, 0);
                PdfPCell cellColindante = UPdfReportes.CellValores(lindero.strColindante, 7, 0);
                table.AddCell(cellCedulaNO);
                table.AddCell(cellPuntoCardinal);
                table.AddCell(cellColindante);
                Contador++;
            }
        }
        #endregion

        #region Metodos Publicos
        public List<Consultar_Colindantes_Result> getLstLindero()
        {
            return this.lstLindero;
        }
        public void setLstLindero(List<Consultar_Colindantes_Result> lstLindero)
        {
            this.lstLindero = lstLindero;
        }
        #endregion
    }
}
