using iTextSharp.text.pdf;
using JEJ.ImprimirFicha.Modelo.Listas;
using JEJ.ImprimirFicha.Negocio.Utilidades;
using System;
using System.Collections.Generic;

namespace JEJ.ImprimirFicha.Negocio.Reportes
{
    public class o_ZonasFisicas: _formatoReporte
    {
        #region Variables
        private List<Consultar_Zonas_Fisicas_Result> lstZonasFisicas;
        private float[] widths = new float[] { 2f, 2f, 2f, 2f, 2f, 2f, 2f, 2f, 2f, 2f };
        private int intColumnas = 10;
        #endregion

        #region Constructor
        public o_ZonasFisicas(List<Consultar_Zonas_Fisicas_Result> lstZonasFisicas)
        {
            this.lstZonasFisicas = lstZonasFisicas;
            creatTable();
        }
        #endregion
        #region Metodos Privados
        private void creatTable()
        {
            this.table = UPdfReportes.configurarTabla(intColumnas, widths);
            int Contador = 1;

            PdfPCell cellTextoTituloZonasFisicas = UPdfReportes.CellTitulo("ZONAS FÍSICAS ", 10);
            PdfPCell cellTextoNO = UPdfReportes.CellSubtitulo("NO", 1, 1);
            PdfPCell cellTextoCodigo = UPdfReportes.CellSubtitulo("Código", 2, 1);
            PdfPCell cellTextoPorcentaje = UPdfReportes.CellSubtitulo("Porcentaje", 2, 1);
            PdfPCell cellTextoDescripcion = UPdfReportes.CellSubtitulo("Descripción", 5, 1);            
            table.AddCell(cellTextoTituloZonasFisicas);
            table.AddCell(cellTextoNO);
            table.AddCell(cellTextoCodigo);
            table.AddCell(cellTextoPorcentaje);
            table.AddCell(cellTextoDescripcion);

            foreach (Consultar_Zonas_Fisicas_Result Zonas in lstZonasFisicas)
            {
                PdfPCell cellNO = UPdfReportes.CellValores(Convert.ToString(Contador), 1, 1);
                PdfPCell cellCodigo = UPdfReportes.CellValores(Zonas.strCodigo, 2, 1);
                PdfPCell cellPorcentaje = UPdfReportes.CellValores(Zonas.strPortcentaje, 2, 1);
                PdfPCell cellDescripcion = UPdfReportes.CellValores(Zonas.strDescripcion, 5, 1);
                this.table.AddCell(cellNO);
                this.table.AddCell(cellCodigo);
                this.table.AddCell(cellPorcentaje);
                this.table.AddCell(cellDescripcion);
                Contador++;
            }
        }
        #endregion
        #region Metodos Publicos
        public List<Consultar_Zonas_Fisicas_Result> getLstLindero()
        {
            return this.lstZonasFisicas;
        }
        public void setLstLindero(List<Consultar_Zonas_Fisicas_Result> lstZonasFisicas)
        {
            this.lstZonasFisicas = lstZonasFisicas;
        }
        #endregion

    }
}
