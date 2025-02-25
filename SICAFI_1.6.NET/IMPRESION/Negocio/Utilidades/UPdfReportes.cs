using iTextSharp.text;
using iTextSharp.text.pdf;

namespace JEJ.ImprimirFicha.Negocio.Utilidades
{
    public static class UPdfReportes
    {
        // public static Font fuenteTexto = FontFactory.GetFont("Arial", 11, BaseColor.BLACK);
        public static Font fuenteValores = FontFactory.GetFont("Arial", 10, BaseColor.BLACK);
        public static Font fuenteTitulos = FontFactory.GetFont("Arial", 12, Font.BOLD, BaseColor.BLACK);
        public static Font fuenteSubTitulos = FontFactory.GetFont("Arial", 11, Font.BOLD, BaseColor.BLACK);
        public static Font fuenteTituloEncabezado = FontFactory.GetFont("Arial", 20, Font.BOLD, BaseColor.BLACK);
        public static Font fuentesX = FontFactory.GetFont("Arial", 7, Font.BOLD, BaseColor.BLACK);

        public static PdfPTable configurarTabla(int intColumnas, float[] widths)
        {
            PdfPTable table = new PdfPTable(intColumnas);
            table.WidthPercentage = 100;
            table.SetWidths(widths);
            table.HorizontalAlignment = 0;
            table.SpacingAfter = 10f;
            return table;
        }

        public static PdfPCell CellTitulo(string strTitulo, int intColspan)
        {
            PdfPCell cellTitulo = new PdfPCell(new Phrase(strTitulo, fuenteTitulos));
            cellTitulo.Colspan = intColspan;
            cellTitulo.HorizontalAlignment = 1;
            cellTitulo.BackgroundColor = BaseColor.LIGHT_GRAY;
            return cellTitulo;
        }

        public static PdfPCell CellSubtitulo(string strTitulo, int intColspan, int intAlignment)
        {
            PdfPCell cellSubTitulo = new PdfPCell(new Phrase(strTitulo, fuenteSubTitulos));
            cellSubTitulo.Colspan = intColspan;
            cellSubTitulo.HorizontalAlignment = intAlignment;
            return cellSubTitulo;
        }

        public static PdfPCell CellValores(string strTitulo, int intColspan, int intAlignment)
        {
            PdfPCell cellSubTitulo = new PdfPCell(new Phrase(strTitulo, fuenteValores));
            cellSubTitulo.Colspan = intColspan;
            cellSubTitulo.HorizontalAlignment = intAlignment;
            return cellSubTitulo;
        }

        public static PdfPCell CellFotosConstruccion(string strFoto, string strTitulo)
        {
            PdfPTable tableP = new PdfPTable(1);
            tableP.WidthPercentage = 100;
            tableP.SetWidths(new float[] { 20f });
            tableP.DefaultCell.Border = 2;

            PdfPCell cellSubTitulo = new PdfPCell(new Phrase(strTitulo, fuenteValores));
            cellSubTitulo.Colspan = 1;
            cellSubTitulo.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
            cellSubTitulo.Border = 2;

            Image imagen= Image.GetInstance(strFoto);
            

            PdfPCell cellFoto = new PdfPCell(imagen);
            cellFoto.Colspan = 1;
            cellFoto.HorizontalAlignment = 1;
            cellFoto.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;
            cellFoto.Border = 2;
            cellFoto.UseBorderPadding = true;
            cellFoto.Padding = 10f;

            tableP.AddCell(cellFoto);
            tableP.AddCell(cellSubTitulo);

            PdfPCell cellTabla = new PdfPCell(tableP);
            cellFoto.Colspan = 1;
            cellFoto.Border = 2;
            
            return cellTabla;
        }
    }
}
