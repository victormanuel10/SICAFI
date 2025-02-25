using iTextSharp.text;
using iTextSharp.text.pdf;
using JEJ.ImprimirFicha.Modelo.Listas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JEJ.ImprimirFicha.Negocio.Reportes
{
    public class q_InformacionResumen: _formatoReporte
    {
        #region Variables
        private Consultar_Predio_Result FichaResumen;
        private float[] widths = new float[] {  2f, 2f, 2f, 2f };
        #endregion

        #region Constructor
        public q_InformacionResumen(Consultar_Predio_Result FichaResumen)
        {
            this.FichaResumen = FichaResumen;            
            CrearTabla();
        }
        #endregion
        #region Metodos Publicos
        public void setLstPredio(Consultar_Predio_Result lstPredio)
        {
            this.FichaResumen = lstPredio;
            this.CrearTabla();
        }
        public Consultar_Predio_Result getLstPredio()
        {
            return this.FichaResumen;
        }
        #endregion
        #region Metodos Privados
        private void CrearTabla()
        {
            string strMensaje = string.Empty;
            table = new PdfPTable(4);
            table.WidthPercentage = 100;
            table.SetWidths(this.widths);
            table.HorizontalAlignment = 0;

            

            Font fuenteValores = Negocio.Utilidades.UPdfReportes.fuenteValores;
            Font fuenteTitulo = Negocio.Utilidades.UPdfReportes.fuenteTitulos;

            PdfPCell cellTextoInformacion = new PdfPCell(new Phrase("INFORMACIÓN FICHA RESUMEN", fuenteTitulo));
            cellTextoInformacion.Colspan = 4;
            cellTextoInformacion.HorizontalAlignment = 1;
            cellTextoInformacion.BackgroundColor = BaseColor.LIGHT_GRAY;
            

            PdfPCell cellTextoAreaLote = new PdfPCell(new Phrase("Área Total Lote", fuenteTitulo));
            cellTextoAreaLote.Colspan = 1;
            cellTextoAreaLote.HorizontalAlignment = 1;

            PdfPCell cellAreaLote = new PdfPCell(new Phrase(FichaResumen.strAreaTotalLote, fuenteValores));
            cellAreaLote.Colspan = 1;
            cellAreaLote.HorizontalAlignment = 1;

            PdfPCell cellTextoAreaComunLote = new PdfPCell(new Phrase("Área Común Lote", fuenteTitulo));
            cellTextoAreaComunLote.Colspan = 1;
            cellTextoAreaComunLote.HorizontalAlignment = 1;

            PdfPCell cellAreaComunLote = new PdfPCell(new Phrase(FichaResumen.strAreaComunLote, fuenteValores));
            cellAreaComunLote.Colspan = 1;
            cellAreaComunLote.HorizontalAlignment = 1;

            PdfPCell cellTextoAreaPrivadaLote = new PdfPCell(new Phrase("Área Privada Lote", fuenteTitulo));
            cellTextoAreaPrivadaLote.Colspan = 1;
            cellTextoAreaPrivadaLote.HorizontalAlignment = 1;           

            PdfPCell cellAreaPrivadaLote = new PdfPCell(new Phrase(FichaResumen.strAreaPrivadaLote, fuenteValores));
            cellAreaPrivadaLote.Colspan = 1;
            cellAreaPrivadaLote.HorizontalAlignment = 1;

            PdfPCell cellTextoAreaConstruccionComun = new PdfPCell(new Phrase("Área Construcción Común", fuenteTitulo));
            cellTextoAreaConstruccionComun.Colspan = 1;
            cellTextoAreaConstruccionComun.HorizontalAlignment = 1;

            PdfPCell cellAreaConstruccionComun = new PdfPCell(new Phrase(FichaResumen.strAreaConstruccion, fuenteValores));
            cellAreaConstruccionComun.Colspan = 1;
            cellAreaConstruccionComun.HorizontalAlignment = 1;

            table.AddCell(cellTextoInformacion);
            table.AddCell(cellTextoAreaLote);
            table.AddCell(cellTextoAreaComunLote);
            table.AddCell(cellTextoAreaPrivadaLote);
            table.AddCell(cellTextoAreaConstruccionComun);
            table.AddCell(cellAreaLote);
            table.AddCell(cellAreaComunLote);
            table.AddCell(cellAreaPrivadaLote);
            table.AddCell(cellAreaConstruccionComun);
        }
        #endregion

    }
}
