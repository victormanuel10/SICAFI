using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JEJ.ImprimirFicha.Negocio.Reportes
{
    public class k_PlanoConstruccion 
    {
        #region Variables
        private float[] widths = new float[] { 2f };
        private string NumeroFicha;
        private string strRutaCarpeta;
        PdfPTable table;
        #endregion
        #region Constructor
        public k_PlanoConstruccion(string NumeroFicha, string strRutaCarpeta)
        {
            this.NumeroFicha = NumeroFicha;
            this.strRutaCarpeta = strRutaCarpeta;
            CrearTabla();
        }
        public PdfPTable getTable()
        {
            return this.table;
        }
        #endregion
        #region Metodos Publicos
       
        #endregion
        #region Metodos Privados
        private void CrearTabla()
        {
            this.table = new PdfPTable(1);
            this.table.WidthPercentage = 100;
            this.table.SetWidths(this.widths);
            this.table.HorizontalAlignment = 0;
            this.table.DefaultCell.BorderColor= BaseColor.WHITE;
            this.table.DefaultCell.BorderWidth = 0;

            string strNombreArchivo = this.strRutaCarpeta + "\\" + this.NumeroFicha + ".jpg";
            if (System.IO.File.Exists(strNombreArchivo))
            {
                Image gif = Image.GetInstance(strNombreArchivo);
                PdfPCell cellNumeroFicha = new PdfPCell(gif);
                cellNumeroFicha.Colspan = 1;
                cellNumeroFicha.HorizontalAlignment = 1;
                cellNumeroFicha.BorderColor = BaseColor.WHITE;
            
                this.table.AddCell(cellNumeroFicha);
            }
            int Contador = 1;
            while (System.IO.File.Exists(this.strRutaCarpeta + "\\" + this.NumeroFicha+"-"+Contador + ".jpg"))
            {
                Image gif2 = Image.GetInstance(this.strRutaCarpeta + "\\" + this.NumeroFicha + "-" + Contador + ".jpg");
                PdfPCell cellNumeroFicha2 = new PdfPCell(gif2);
                cellNumeroFicha2.Colspan = 1;
                cellNumeroFicha2.HorizontalAlignment = 1;
                cellNumeroFicha2.BorderColor = BaseColor.WHITE;
                this.table.AddCell(cellNumeroFicha2);
                Contador++;
            }


        }
        #endregion
    }
}
