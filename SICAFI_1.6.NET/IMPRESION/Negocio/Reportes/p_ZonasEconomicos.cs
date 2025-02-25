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
    public class p_ZonasEconomicos : _formatoReporte
    {
        #region Variables
        private List<Consultar_Zonas_Economicas_Result> lstZonasEconomicas;
        private float[] widths = new float[] { 2f, 2f, 2f, 2f, 2f, 2f, 2f, 2f };
        private int intColumnas = 8;
        #endregion

        #region Constructor
        public p_ZonasEconomicos(List<Consultar_Zonas_Economicas_Result> lstZonasEconomicas)
        {
            this.lstZonasEconomicas = lstZonasEconomicas;
            creatTable();
        }
        #endregion
        #region Metodos Privados
        private void creatTable()
        {
            this.table = UPdfReportes.configurarTabla(intColumnas, widths);
            int Contador = 1;

            PdfPCell cellTextoTituloZonasEconomicas = UPdfReportes.CellTitulo("ZONAS ECONÓMICAS ", 8);
            PdfPCell cellTextoNO = UPdfReportes.CellSubtitulo("NO", 1, 1);
            PdfPCell cellTextoCodigo = UPdfReportes.CellSubtitulo("Código", 4, 1);
            PdfPCell cellTextoPorcentaje = UPdfReportes.CellSubtitulo("Porcentaje", 3, 1);
            table.AddCell(cellTextoTituloZonasEconomicas);
            table.AddCell(cellTextoNO);
            table.AddCell(cellTextoCodigo);
            table.AddCell(cellTextoPorcentaje);
            foreach (Consultar_Zonas_Economicas_Result Zonas in lstZonasEconomicas)
            {
                PdfPCell cellNO = UPdfReportes.CellValores(Convert.ToString(Contador), 1, 1);
                PdfPCell cellCodigo = UPdfReportes.CellValores(Zonas.strCodigo, 4, 1);
                PdfPCell cellPorcentaje = UPdfReportes.CellValores(Zonas.strPortcentaje, 3, 1);
                
                table.AddCell(cellNO);
                table.AddCell(cellCodigo);
                table.AddCell(cellPorcentaje);

                Contador++;
            }
        }
        #endregion
        #region Metodos Publicos
        public List<Consultar_Zonas_Economicas_Result> getLstLindero()
        {
            return this.lstZonasEconomicas;
        }
        public void setLstLindero(List<Consultar_Zonas_Economicas_Result> lstZonasFisicas)
        {
            this.lstZonasEconomicas = lstZonasFisicas;
        }
        #endregion
    }
}
