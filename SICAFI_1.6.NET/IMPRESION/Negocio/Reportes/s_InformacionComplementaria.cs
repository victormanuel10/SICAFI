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
    public class s_InformacionComplementaria : _formatoReporte
    {
        #region Variables
        private string strObservaciones;
        private float[] widths = new float[] { 2f };
        private int intColumnas = 1;

        #endregion

        #region Constructor
        public s_InformacionComplementaria(string strObservaciones)
        {
            this.strObservaciones = strObservaciones;
            CrearTabla();
        }
        #endregion
        #region Metodos Publicos

        #endregion
        #region Metodos Privados
        private void CrearTabla()
        {
            table = UPdfReportes.configurarTabla(intColumnas, widths);
            PdfPCell cellTextoObservaciones = UPdfReportes.CellTitulo("OBSERVACIONES ", 1);
            PdfPCell cellObservacion = UPdfReportes.CellValores(strObservaciones, 1, 1);
            this.table.AddCell(cellTextoObservaciones);
            this.table.AddCell(cellObservacion);
        }
        #endregion
    }
}
