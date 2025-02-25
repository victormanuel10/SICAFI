using iTextSharp.text;
using iTextSharp.text.pdf;
using JEJ.ImprimirFicha.Negocio.Utilidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JEJ.ImprimirFicha.Negocio.Reportes
{
    class t_InformacionFecha: _formatoReporte
    {
        string strFechaAlfanumerica;
        string strFechaGrafica;
        private float[] widths = new float[] { 2f, 2f };
        private int intColumnas = 2;

        public t_InformacionFecha(string strFechaAlfanumerica, string strFechaGrafica)
        {
            this.strFechaAlfanumerica = strFechaAlfanumerica;
            this.strFechaGrafica = strFechaGrafica;
            crearTabla();
        }
        private void crearTabla()
        {
            table = UPdfReportes.configurarTabla(intColumnas, widths);
            PdfPCell cellTextoTituloFechaArchivos = UPdfReportes.CellTitulo("FECHAS DE ARCHIVOS", 2);
            PdfPCell cellTextoFechaAlfanumerico = UPdfReportes.CellSubtitulo("Fecha Modificación Alfanumerico", 1, 1);
            PdfPCell cellTextoFechaGrafico = UPdfReportes.CellSubtitulo("Fecha Modificación Grafico", 1, 1);
            PdfPCell cellFechaAlfanumerico = UPdfReportes.CellValores(strFechaAlfanumerica, 1, 1);
            PdfPCell cellFechaGrafico = UPdfReportes.CellValores(strFechaGrafica, 1, 1);
            this.table.AddCell(cellTextoTituloFechaArchivos);
            this.table.AddCell(cellTextoFechaAlfanumerico);
            this.table.AddCell(cellTextoFechaGrafico);
            this.table.AddCell(cellFechaAlfanumerico);
            this.table.AddCell(cellFechaGrafico);            
        }
    }
}
