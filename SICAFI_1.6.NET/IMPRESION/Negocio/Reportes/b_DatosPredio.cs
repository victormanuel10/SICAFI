using iTextSharp.text.pdf;
using JEJ.ImprimirFicha.Modelo.Listas;
using JEJ.ImprimirFicha.Negocio.Utilidades;

namespace JEJ.ImprimirFicha.Negocio.Reportes
{
    public class b_DatosPredio : _formatoReporte
    {
        #region Variables
        private Consultar_Predio_Result lstPredio;
        private float[] widths = new float[] { 2f, 2f, 2f, 2f, 2f, 2f, 2f, 2f };
        private int intColumnas = 8;
        #endregion

        #region Constructor
        public b_DatosPredio(Consultar_Predio_Result lstPredio)
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

            #region Cedula Catastral
            PdfPCell cellUbicacionPredio = UPdfReportes.CellTitulo("UBICACIÓN DEL PREDIO ", 8);
            table.AddCell(cellUbicacionPredio);
            PdfPCell cellNumeroFicha = UPdfReportes.CellSubtitulo("NUMERO DE FICHA: " + lstPredio.strNumeroFicha, 8, 2);
            table.AddCell(cellNumeroFicha);
            PdfPCell cellNombreMunicipio = UPdfReportes.CellSubtitulo("MUNICIPIO: " + lstPredio.strNombreMunicipio, 4, 0);
            table.AddCell(cellNombreMunicipio);
            PdfPCell cellNombreCorregimiento = UPdfReportes.CellSubtitulo("CORREGIMIENTO: " + lstPredio.strNombreCorregimiento, 4, 0);
            table.AddCell(cellNombreCorregimiento);
            PdfPCell cellNombreBarrio;
            PdfPCell cellNombreVereda;
            if (lstPredio.strSector == "2")
            {
                cellNombreBarrio = UPdfReportes.CellSubtitulo("BARRIO: " + lstPredio.strNombreBarrio, 4, 0);
                table.AddCell(cellNombreBarrio);
                cellNombreVereda = UPdfReportes.CellSubtitulo("VEREDA: " + lstPredio.strNombreVereda, 4, 0);
                table.AddCell(cellNombreVereda);
            }
            else {
                cellNombreBarrio = UPdfReportes.CellSubtitulo("BARRIO: " + lstPredio.strNombreBarrio, 8, 0);
                table.AddCell(cellNombreBarrio);
            }

            PdfPCell cellDirreccion = UPdfReportes.CellSubtitulo("DIRRECIÓN: " + lstPredio.strDirreccion, 4, 0);
            table.AddCell(cellDirreccion);
            PdfPCell cellDescripcionPredio = UPdfReportes.CellSubtitulo("DESCRIPCIÓN: " + this.lstPredio.strDescripcionPredio, 4, 0);
            table.AddCell(cellDescripcionPredio);
            #endregion
        }
        #endregion
    }
}
