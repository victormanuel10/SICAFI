using iTextSharp.text;
using iTextSharp.text.pdf;
using JEJ.ImprimirFicha.Modelo.Listas;
using JEJ.ImprimirFicha.Negocio.Utilidades;

namespace JEJ.ImprimirFicha.Negocio.Reportes
{
    public class g_Adquisicion : _formatoReporte
    {
        #region Variables
        private Consultar_Predio_Result lstPredio;
        private float[] widths = new float[] { 2f, 2f, 2f, 2f, 2f, 2f, 2f, 2f };
        private int intColumnas = 8;
        #endregion

        #region Constructor
        public g_Adquisicion(Consultar_Predio_Result lstPredio)
        {
            this.lstPredio = lstPredio;
            CrearTabla();
        }
        #endregion
        #region Metodos Publicos
        public void setLstPredio(Consultar_Predio_Result lstPredio)
        {
            this.lstPredio = lstPredio;
            this.CrearTabla();
        }
        public Consultar_Predio_Result getLstPredio()
        {
            return this.lstPredio;
        }
        #endregion
        #region Metodos Privados
        private void CrearTabla()
        {
            table = UPdfReportes.configurarTabla(intColumnas, widths);

            #region Adquisicion
            PdfPCell cellTextoModoAdquisicion = UPdfReportes.CellTitulo("MODO DE ADQUISICIÓN", 8);

            PdfPCell cellTextoAdquisicion = UPdfReportes.CellSubtitulo("Adquisición", 2, 1);
            PdfPCell cellTextoLitigio = UPdfReportes.CellSubtitulo("Litigio (%)", 3, 1);
            PdfPCell cellTextoTomo = UPdfReportes.CellSubtitulo("Tomo", 1, 1);
            PdfPCell cellTextoMatricula = UPdfReportes.CellSubtitulo("Matrícula Inmobiliaria", 2, 1);

            PdfPCell cellModoAdquisicion = UPdfReportes.CellValores(lstPredio.strModoAdquisicionDescripcion, 2, 1);
            PdfPCell cellLitigio = UPdfReportes.CellValores((lstPredio.strLitigio == "0" ? "NO" : "SI"), 1, 1);
            PdfPCell cellLitigioPorcentaje = UPdfReportes.CellValores(lstPredio.strPorcentajeLitigio, 2, 1);
            PdfPCell cellTomo = UPdfReportes.CellValores(lstPredio.strTomo, 1, 1);
            PdfPCell cellMatricula = UPdfReportes.CellValores(lstPredio.strMatricula, 2, 1);

            table.AddCell(cellTextoModoAdquisicion);
            table.AddCell(cellTextoAdquisicion);
            table.AddCell(cellTextoLitigio);
            table.AddCell(cellTextoTomo);
            table.AddCell(cellTextoMatricula);

            table.AddCell(cellModoAdquisicion);
            table.AddCell(cellLitigio);
            table.AddCell(cellLitigioPorcentaje);
            table.AddCell(cellTomo);
            table.AddCell(cellMatricula);
            #endregion
        }
        #endregion
    }
}
