using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JEJ.ImprimirFicha.Negocio.Reportes
{
    public class _formatoReporte
    {
        protected PdfPTable table;

        public PdfPTable getTable()
        {
            PdfPTable tableP = new PdfPTable(1);
            tableP.WidthPercentage = 100;
            tableP.SetWidths(new float[] { 20f });
            tableP.HorizontalAlignment = 0;
            tableP.SpacingAfter = 10f;

            PdfPCell cellPrincipa = new PdfPCell(this.table);
            cellPrincipa.Colspan = 1;
            cellPrincipa.HorizontalAlignment = 1;
            cellPrincipa.BorderWidth = 2;
            tableP.AddCell(cellPrincipa);
            return tableP;

        }
    }
}
