using iTextSharp.text;
using iTextSharp.text.pdf;
using JEJ.ImprimirFicha.Modelo.Listas;
using JEJ.ImprimirFicha.Negocio.Utilidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JEJ.ImprimirFicha.Negocio.Reportes
{
    public class e_DestinoEconomico : _formatoReporte
    {
        #region Variables
        private Consultar_Predio_Result lstPredio;
        private float[] widths = new float[] { 2f, 2f, 2f, 2f, 2f, 2f, 2f, 2f, 2f, 2f, 2f, 2f };
        private int intColumnas = 12;
        private Consultar_CategoriaPredio_Result CategoriaPredio;

        #endregion

        #region Constructor
        public e_DestinoEconomico(Consultar_Predio_Result lstPredio, Consultar_CategoriaPredio_Result CategoriaPredio)
        {
            this.lstPredio = lstPredio;
            this.CategoriaPredio = CategoriaPredio;
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

            #region Destino Economico
            PdfPCell cellTextoDestinoEconomico = UPdfReportes.CellTitulo("DESTINO ECONÓMICO", 6);


            PdfPCell cellTextoCodigoDestinoEconomico = UPdfReportes.CellSubtitulo("Código ", 1, 1);

            PdfPCell cellTextoDescripcionDestinoEconomico = UPdfReportes.CellSubtitulo("Descripción", 3, 1);

            PdfPCell cellTextoPorcentajeDestinoEconomico = UPdfReportes.CellSubtitulo("Porcentaje", 2, 1);

            PdfPCell cellCodigoDestinoEconomico = UPdfReportes.CellValores(lstPredio.strDestinoEconomico, 1, 1);

            PdfPCell cellDescripcionDestinoEconomico = UPdfReportes.CellValores(lstPredio.strDestinoEconomicoDescripcion, 3, 1);

            PdfPCell cellPorcentajeDestinoEconomico = UPdfReportes.CellValores("100%", 2, 1);
            #endregion

            #region Categoria

            PdfPCell cellTextoCategoria = UPdfReportes.CellTitulo("CATEGORIA DEL SUELO", 3);

            PdfPCell cellTextoCodigo = UPdfReportes.CellSubtitulo("Código ", 1, 1);

            PdfPCell cellTextoDescripcion = UPdfReportes.CellSubtitulo("Descripción", 2, 1);

            PdfPCell cellCodigoCategoria = UPdfReportes.CellSubtitulo(lstPredio.strCodigoCategoriaSuelo, 1, 1);

            PdfPCell cellDescripcionCategoria = UPdfReportes.CellSubtitulo(lstPredio.strDescripcionCategoriaSuelo, 2, 1);

            #endregion

            #region Caracteristica 
            PdfPCell cellTextoCaracteristica = UPdfReportes.CellTitulo("CATEGORIA DEL PREDIO", 3);
            PdfPCell cellCodigoCaracteristicaPredio = UPdfReportes.CellSubtitulo(CategoriaPredio.strCodigo, 1, 1);
            PdfPCell cellCaracteristicaPredio = UPdfReportes.CellSubtitulo(CategoriaPredio.strDescripcion, 2, 1);
            #endregion
            table.AddCell(cellTextoDestinoEconomico);
            table.AddCell(cellTextoCategoria);
            table.AddCell(cellTextoCaracteristica);

            table.AddCell(cellTextoCodigoDestinoEconomico);
            table.AddCell(cellTextoDescripcionDestinoEconomico);
            table.AddCell(cellTextoPorcentajeDestinoEconomico);

            table.AddCell(cellTextoCodigo);
            table.AddCell(cellTextoDescripcion);

            table.AddCell(cellTextoCodigo);
            table.AddCell(cellTextoDescripcion);

            table.AddCell(cellCodigoDestinoEconomico);
            table.AddCell(cellDescripcionDestinoEconomico);
            table.AddCell(cellPorcentajeDestinoEconomico);

            table.AddCell(cellCodigoCategoria);
            table.AddCell(cellDescripcionCategoria);

            table.AddCell(cellCodigoCaracteristicaPredio);
            table.AddCell(cellCaracteristicaPredio);


        }
        #endregion
    }
}
