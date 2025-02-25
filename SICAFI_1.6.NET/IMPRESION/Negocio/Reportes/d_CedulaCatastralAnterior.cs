using iTextSharp.text.pdf;
using JEJ.ImprimirFicha.Modelo.Listas;
using JEJ.ImprimirFicha.Negocio.Utilidades;

namespace JEJ.ImprimirFicha.Negocio.Reportes
{
    public class d_CedulaCatastralAnterior : _formatoReporte
    {
        #region Variables
        private Consultar_Predio_Result lstPredio;
        private float[] widths = new float[] { 2f, 2f, 2f, 2f, 2f, 2f, 2f, 2f };
        private int intColumnas = 8;

        #endregion

        #region Constructor
        public d_CedulaCatastralAnterior(Consultar_Predio_Result lstPredio)
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
            PdfPCell cellTextoCedulaCatastralAnterior = UPdfReportes.CellTitulo("CEDULA CATASTRAL ANTERIOR", 8);

            PdfPCell cellTextoMunicipio = UPdfReportes.CellSubtitulo("MUNICIPIO", 1, 1);
            PdfPCell cellTextoSector = UPdfReportes.CellSubtitulo("SECTOR", 1, 1);
            PdfPCell cellTextoCorregimiento = UPdfReportes.CellSubtitulo("CORREGI.", 1, 1);
            PdfPCell cellTextoBarrio = UPdfReportes.CellSubtitulo("BARRIO", 1, 1);
            PdfPCell cellTextoManzana = UPdfReportes.CellSubtitulo("MANZ/VERE", 1, 1);
            PdfPCell cellTextoPredio = UPdfReportes.CellSubtitulo("PREDIO", 1, 1);
            PdfPCell cellTextoEdificio = UPdfReportes.CellSubtitulo("EDIFICIO", 1, 1);
            PdfPCell cellTextoUnidadPredial = UPdfReportes.CellSubtitulo("U. PREDIAL", 1, 1);

            //Anterior
            PdfPCell cellAntMunicipio = UPdfReportes.CellValores(this.lstPredio.strAntMunicipio, 1, 1);
            PdfPCell cellAntSector = UPdfReportes.CellValores((this.lstPredio.strAntSector == "1" ? "URBANO" : "RURAL"), 1, 1);
            PdfPCell cellAntCorregimiento = UPdfReportes.CellValores(this.lstPredio.strAntCorregimiento, 1, 1);
            PdfPCell cellAntBarrio = UPdfReportes.CellValores(this.lstPredio.strAntBarrio, 1, 1);
            PdfPCell cellAntManzana = UPdfReportes.CellValores(this.lstPredio.strAntManzana, 1, 1);
            PdfPCell cellAntPredio = UPdfReportes.CellValores(this.lstPredio.strAntPredio, 1, 1);
            PdfPCell cellAntEdificio = UPdfReportes.CellValores(this.lstPredio.strAntEdificio, 1, 1);
            PdfPCell cellAntUnidadPredial = UPdfReportes.CellValores(this.lstPredio.strAntUnidadPredial, 1, 1);
                    
            table.AddCell(cellTextoCedulaCatastralAnterior);
            table.AddCell(cellTextoMunicipio);
            table.AddCell(cellTextoSector);
            table.AddCell(cellTextoCorregimiento);
            table.AddCell(cellTextoBarrio);
            table.AddCell(cellTextoManzana);
            table.AddCell(cellTextoPredio);
            table.AddCell(cellTextoEdificio);
            table.AddCell(cellTextoUnidadPredial);

            table.AddCell(cellAntMunicipio);
            table.AddCell(cellAntSector);
            table.AddCell(cellAntCorregimiento);
            table.AddCell(cellAntBarrio);
            table.AddCell(cellAntManzana);
            table.AddCell(cellAntPredio);
            table.AddCell(cellAntEdificio);
            table.AddCell(cellAntUnidadPredial);

            #endregion
        }
        #endregion
    }
}
