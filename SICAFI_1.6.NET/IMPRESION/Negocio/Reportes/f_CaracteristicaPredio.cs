using iTextSharp.text.pdf;
using JEJ.ImprimirFicha.Modelo.Listas;
using JEJ.ImprimirFicha.Negocio.Utilidades;

namespace JEJ.ImprimirFicha.Negocio.Reportes
{
    public class f_CaracteristicaPredio : _formatoReporte
    {
        #region Variables
        private Consultar_Predio_Result lstPredio;
        private float[] widths = new float[] { 2f, 2f, 2f, 2f, 2f, 2f, 2f, 2f, 2f, 2f, 2f, 2f };
        private int intColumnas = 12;
        #endregion

        #region Constructor
        public f_CaracteristicaPredio(Consultar_Predio_Result lstPredio)
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

            #region Caracteristica de predio
            PdfPCell cellTextoCaracteristicaPredio = UPdfReportes.CellTitulo("CARACTERISTICA DEL PREDIO", 4);
            table.AddCell(cellTextoCaracteristicaPredio);

            PdfPCell cellTextoAreaTerreno = UPdfReportes.CellTitulo("Área de terreno", 2);
            cellTextoAreaTerreno.Rowspan = 2;
            table.AddCell(cellTextoAreaTerreno);

            PdfPCell cellTextoCoeficienteEdificio = UPdfReportes.CellTitulo("Coeficiente de edificio", 2);
            cellTextoCoeficienteEdificio.Rowspan = 2;
            table.AddCell(cellTextoCoeficienteEdificio);

            PdfPCell cellTextoEstrato = UPdfReportes.CellTitulo("ESTRATO", 4);
            table.AddCell(cellTextoEstrato);

            PdfPCell cellTextoCodigo = UPdfReportes.CellSubtitulo("Código", 1, 1);
            PdfPCell cellTextoDescripcion = UPdfReportes.CellSubtitulo("Descripción", 3, 1);

            table.AddCell(cellTextoCodigo);
            table.AddCell(cellTextoDescripcion);
            table.AddCell(cellTextoCodigo);
            table.AddCell(cellTextoDescripcion);

            #region Caracteristica del predio
            PdfPCell cellCodigoCaracteristicaPredio = UPdfReportes.CellValores(lstPredio.strCaracteristicaPredio, 1, 1);
            table.AddCell(cellCodigoCaracteristicaPredio);
            PdfPCell cellDescripcionCaracteristicaPredio = UPdfReportes.CellValores(lstPredio.strCaracteristicaPredioDescripcion, 3, 1);
            table.AddCell(cellDescripcionCaracteristicaPredio);
            #endregion

            #region Area y Coeficiente
            PdfPCell cellDescripcionAreaTerreno = UPdfReportes.CellValores(lstPredio.strAreaTerreno, 2, 1);
            table.AddCell(cellDescripcionAreaTerreno);

            PdfPCell cellDescripcionCOeficientePredio = UPdfReportes.CellValores(lstPredio.strCoeficientePredio, 2, 1);
            table.AddCell(cellDescripcionCOeficientePredio);
            #endregion
            #region Estrato
            PdfPCell cellCodigoEstrato = UPdfReportes.CellValores(lstPredio.strCodigoEstrado, 1, 1);
            table.AddCell(cellCodigoEstrato);
            PdfPCell cellDescripcionEstrato = UPdfReportes.CellValores(lstPredio.strDescripcionEstrato, 3, 1);
            table.AddCell(cellDescripcionEstrato);
            #endregion

            #endregion

        }
        #endregion
    }
}
