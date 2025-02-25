using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JEJ.ImprimirFicha.Negocio.Reportes
{
    public class a_Encabezado
    {
        private string strImagen;
        private PdfPTable table;
        private float[] widths = new float[] { 2f };
        public a_Encabezado( string strImagen)
        {
            this.strImagen = strImagen;
            crearTabla();
        }

        public PdfPTable getTable()
        {
            return table;
        }
        private void crearTabla()
        {
            table = new PdfPTable(1);
            table.WidthPercentage = 100;
            table.SetWidths(widths);
            table.HorizontalAlignment = 0;
            table.DefaultCell.BorderWidth = 0;
            if (System.IO.File.Exists(strImagen))
            {
                Image gif = Image.GetInstance(strImagen);
                PdfPCell cellNumeroFicha = new PdfPCell(gif);
                cellNumeroFicha.Colspan = 1;
                cellNumeroFicha.HorizontalAlignment = 1;
                cellNumeroFicha.BorderColor = BaseColor.WHITE;
                cellNumeroFicha.BorderWidth = 0;
                table.AddCell(cellNumeroFicha);
            }
        }
    }
}
