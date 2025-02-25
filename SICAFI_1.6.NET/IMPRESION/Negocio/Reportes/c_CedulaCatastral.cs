using iTextSharp.text;
using iTextSharp.text.pdf;
using JEJ.ImprimirFicha.Modelo.Listas;
using JEJ.ImprimirFicha.Negocio.Utilidades;

namespace JEJ.ImprimirFicha.Negocio.Reportes
{
    public class c_CedulaCatastral: _formatoReporte
    {
        #region Variables
        private Consultar_Predio_Result lstPredio;
        private float[] widths = new float[] {2f, 2f, 2f, 2f, 2f, 2f, 2f, 2f };
        private int intColumnas = 8;
        #endregion

        #region Constructor
        public c_CedulaCatastral(Consultar_Predio_Result lstPredio)
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
            PdfPCell cellTextoCedulaCatastral = UPdfReportes.CellTitulo("CEDULA CATASTRAL", 8);

            PdfPCell cellTextoMunicipio = UPdfReportes.CellSubtitulo("MUNICIPIO" , 1, 1);
            PdfPCell cellTextoSector = UPdfReportes.CellSubtitulo("SECTOR" , 1, 1);
            PdfPCell cellTextoCorregimiento = UPdfReportes.CellSubtitulo("CORREGI.", 1, 1);
            PdfPCell cellTextoBarrio = UPdfReportes.CellSubtitulo("BARRIO" , 1, 1);
            PdfPCell cellTextoManzana = UPdfReportes.CellSubtitulo("MANZ/VERE" , 1, 1);
            PdfPCell cellTextoPredio = UPdfReportes.CellSubtitulo("PREDIO" , 1, 1);
            PdfPCell cellTextoEdificio = UPdfReportes.CellSubtitulo("EDIFICIO" , 1, 1);
            PdfPCell cellTextoUnidadPredial = UPdfReportes.CellSubtitulo("U. PREDIAL"  , 1, 1);

            PdfPCell cellMunicipio=UPdfReportes.CellValores(this.lstPredio.strMunicipio, 1, 1);
            PdfPCell cellSector = UPdfReportes.CellValores((this.lstPredio.strSector == "1" ? "URBANO" : "RURAL"), 1, 1);
            PdfPCell cellCorregimiento = UPdfReportes.CellValores(this.lstPredio.strCorregimiento, 1, 1);
            PdfPCell cellBarrio = UPdfReportes.CellValores(this.lstPredio.strBarrio, 1, 1);
            PdfPCell cellManzana = UPdfReportes.CellValores(this.lstPredio.strManzana, 1, 1);
            PdfPCell cellPredio = UPdfReportes.CellValores(this.lstPredio.strPredio, 1, 1);
            PdfPCell cellEdificio = UPdfReportes.CellValores(this.lstPredio.strEdificio, 1, 1);
            PdfPCell cellUnidadPredial = UPdfReportes.CellValores(this.lstPredio.strUnidadPredial, 1, 1);
           
            table.AddCell(cellTextoCedulaCatastral);

            table.AddCell(cellTextoMunicipio);
            table.AddCell(cellTextoSector);
            table.AddCell(cellTextoCorregimiento);
            table.AddCell(cellTextoBarrio);
            table.AddCell(cellTextoManzana);
            table.AddCell(cellTextoPredio);
            table.AddCell(cellTextoEdificio);
            table.AddCell(cellTextoUnidadPredial);

            table.AddCell(cellMunicipio);
            table.AddCell(cellSector);
            table.AddCell(cellCorregimiento);
            table.AddCell(cellBarrio);
            table.AddCell(cellManzana);
            table.AddCell(cellPredio);
            table.AddCell(cellEdificio);
            table.AddCell(cellUnidadPredial);          

            #endregion
        }
        #endregion
    }
}
