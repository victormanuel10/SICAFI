using iTextSharp.text;
using iTextSharp.text.pdf;
using JEJ.ImprimirFicha.Modelo.Listas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JEJ.ImprimirFicha.Negocio.Reportes
{
    class r_InformacionResumenGenerales: _formatoReporte
    {
        #region Variables
        private Consultar_Predio_Result FichaResumen;
        private float[] widths = new float[] { 2f, 2f, 2f, 2f };
        DataTablesFichaPredial objDT;
        #endregion

        #region Constructor
        public r_InformacionResumenGenerales(Consultar_Predio_Result FichaResumen)
        {
            this.FichaResumen = FichaResumen;
            CrearTabla();
        }
        #endregion
        #region Metodos Publicos
        public void setLstPredio(Consultar_Predio_Result lstPredio)
        {
            this.FichaResumen = lstPredio;
            this.CrearTabla();
        }
        public Consultar_Predio_Result getLstPredio()
        {
            return this.FichaResumen;
        }
        #endregion
        #region Metodos Privados
        private void CrearTabla()
        {
            string strMensaje = string.Empty;
            table = new PdfPTable(4);
            table.WidthPercentage = 100;
            table.SetWidths(this.widths);
            table.HorizontalAlignment = 0;

            Font fuenteValores = Negocio.Utilidades.UPdfReportes.fuenteValores;
            Font fuenteTitulo = Negocio.Utilidades.UPdfReportes.fuenteTitulos;
            Font fuenteSubTitulo = Negocio.Utilidades.UPdfReportes.fuenteSubTitulos;

            PdfPCell cellGenrelaes = new PdfPCell(new Phrase("TOTAL GENERALES", fuenteTitulo));
            cellGenrelaes.Colspan = 4;
            cellGenrelaes.HorizontalAlignment = 1;
            cellGenrelaes.BackgroundColor = BaseColor.LIGHT_GRAY;

            PdfPCell cellTextoEdificios = new PdfPCell(new Phrase("Edificios", fuenteSubTitulo));
            cellTextoEdificios.Colspan = 1;
            cellTextoEdificios.HorizontalAlignment = 1;

            PdfPCell cellEdificios = new PdfPCell(new Phrase(FichaResumen.strTotalEdificios, fuenteValores));
            cellEdificios.Colspan = 1;
            cellEdificios.HorizontalAlignment = 1;

            PdfPCell cellTextoUnidadesCondominio = new PdfPCell(new Phrase("Unidades en Condominio", fuenteSubTitulo));
            cellTextoUnidadesCondominio.Colspan = 1;
            cellTextoUnidadesCondominio.HorizontalAlignment = 1;

            PdfPCell cellUnidadesCondominio = new PdfPCell(new Phrase(FichaResumen.strUnidadesEnCondominio, fuenteValores));
            cellUnidadesCondominio.Colspan = 1;
            cellUnidadesCondominio.HorizontalAlignment = 1;

            PdfPCell cellTextoUnidadesRPH = new PdfPCell(new Phrase("Unidades en R.P.H.", fuenteSubTitulo));
            cellTextoUnidadesRPH.Colspan = 1;
            cellTextoUnidadesRPH.HorizontalAlignment = 1;

            PdfPCell cellUnidadesRPH = new PdfPCell(new Phrase(FichaResumen.strUnidadesRPH, fuenteValores));
            cellUnidadesRPH.Colspan = 1;
            cellUnidadesRPH.HorizontalAlignment = 1;

            PdfPCell cellTextoApartamentosCasas = new PdfPCell(new Phrase("Apartamentos o Casas", fuenteSubTitulo));
            cellTextoApartamentosCasas.Colspan = 1;
            cellTextoApartamentosCasas.HorizontalAlignment = 1;

            PdfPCell cellApartamentosCasas = new PdfPCell(new Phrase(FichaResumen.strAparatamentosOCasas, fuenteValores));
            cellApartamentosCasas.Colspan = 1;
            cellApartamentosCasas.HorizontalAlignment = 1;

            PdfPCell cellTextoLocales = new PdfPCell(new Phrase("Locales", fuenteSubTitulo));
            cellTextoLocales.Colspan = 1;
            cellTextoLocales.HorizontalAlignment = 1;

            PdfPCell cellLocales = new PdfPCell(new Phrase(FichaResumen.strLocales, fuenteValores));
            cellLocales.Colspan = 1;
            cellLocales.HorizontalAlignment = 1;

            PdfPCell cellTextoCuartosUtiles = new PdfPCell(new Phrase("Cuartos Útiles", fuenteSubTitulo));
            cellTextoCuartosUtiles.Colspan = 1;
            cellTextoCuartosUtiles.HorizontalAlignment = 1;

            PdfPCell cellCuartosUtiles = new PdfPCell(new Phrase(FichaResumen.strCuartosUriles, fuenteValores));
            cellCuartosUtiles.Colspan = 1;
            cellCuartosUtiles.HorizontalAlignment = 1;

            PdfPCell cellTextoGarajesCubiertos = new PdfPCell(new Phrase("Garajes Cubiertos", fuenteSubTitulo));
            cellTextoGarajesCubiertos.Colspan = 1;
            cellTextoGarajesCubiertos.HorizontalAlignment = 1;

            PdfPCell cellGarajesCubiertos = new PdfPCell(new Phrase(FichaResumen.strGarajesCubiertos, fuenteValores));
            cellGarajesCubiertos.Colspan = 1;
            cellGarajesCubiertos.HorizontalAlignment = 1;

            PdfPCell cellTextoGarajesDescubieros = new PdfPCell(new Phrase("Garajes Descubiertos", fuenteSubTitulo));
            cellTextoGarajesDescubieros.Colspan = 1;
            cellTextoGarajesDescubieros.HorizontalAlignment = 1;

            PdfPCell cellGarajesDescubieros = new PdfPCell(new Phrase(FichaResumen.strGarejesDescubierto, fuenteValores));
            cellGarajesDescubieros.Colspan = 1;
            cellGarajesDescubieros.HorizontalAlignment = 1;

            PdfPCell cellTextoPisos = new PdfPCell(new Phrase("Pisos", fuenteSubTitulo));
            cellTextoPisos.Colspan = 1;
            cellTextoPisos.HorizontalAlignment = 1;

            PdfPCell cellPisos = new PdfPCell(new Phrase(FichaResumen.strPisos, fuenteValores));
            cellPisos.Colspan = 1;
            cellPisos.HorizontalAlignment = 1;

            table.AddCell(cellGenrelaes);
            table.AddCell(cellTextoEdificios);
            table.AddCell(cellEdificios);
            table.AddCell(cellTextoUnidadesCondominio);
            table.AddCell(cellUnidadesCondominio);
            table.AddCell(cellTextoUnidadesRPH);
            table.AddCell(cellUnidadesRPH);
            table.AddCell(cellTextoApartamentosCasas);
            table.AddCell(cellApartamentosCasas);
            table.AddCell(cellTextoLocales);
            table.AddCell(cellLocales);
            table.AddCell(cellTextoCuartosUtiles);
            table.AddCell(cellCuartosUtiles);
            table.AddCell(cellTextoGarajesCubiertos);
            table.AddCell(cellGarajesCubiertos);
            table.AddCell(cellTextoGarajesDescubieros);
            table.AddCell(cellGarajesDescubieros);
            table.AddCell(cellTextoPisos);
            table.AddCell(cellPisos);


        }
        #endregion
    }
}
