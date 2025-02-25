using iTextSharp.text.pdf;
using JEJ.ImprimirFicha.Modelo.Listas;
using JEJ.ImprimirFicha.Negocio.Utilidades;
using System;
using System.Collections.Generic;

namespace JEJ.ImprimirFicha.Negocio.Reportes
{
    public class n_InformacionAerografica : _formatoReporte
    {
        #region Variables
        private List<Consultar_Informacion_Geografica_Result> lstInformacion;
        private float[] widths = new float[] { 2f, 2f, 2f, 2f, 2f, 2f, 2f, 2f, 2f, 2f
                                              ,2f, 2f, 2f, 2f, 2f, 2f, 2f, 2f, 2f, 2f};
        private int intColumnas = 20;
        #endregion
        #region Constructor
        public n_InformacionAerografica(List<Consultar_Informacion_Geografica_Result> lstInformacion)
        {
            this.lstInformacion = lstInformacion;
            crearTabla();
        }
        #endregion
        #region Metodos Privados
        private void crearTabla()
        {
            this.table = UPdfReportes.configurarTabla(intColumnas, widths);
            int Contador = 1;

            #region Informacion Aerografica
            PdfPCell cellTextoInformacionAerografica = UPdfReportes.CellTitulo("INFORMACIÓN AEROGRÁFICA ", 20);
            PdfPCell cellTextoCedulaNO = UPdfReportes.CellSubtitulo("NO", 1, 1);
            PdfPCell cellTextoVuelo = UPdfReportes.CellSubtitulo("VUELO", 5, 1);
            PdfPCell cellTextoFaja = UPdfReportes.CellSubtitulo("FAJA", 2, 1);
            PdfPCell cellTextoFoto = UPdfReportes.CellSubtitulo("FOTO", 3, 1);
            PdfPCell cellTextoAnioGrafica = UPdfReportes.CellSubtitulo("AÑO", 2, 1);
            PdfPCell cellTextoAmpliacion = UPdfReportes.CellSubtitulo("AMPLIACIÓN", 4, 1);
            PdfPCell cellTextoEscalaGrafica = UPdfReportes.CellSubtitulo("ESCALA", 3, 1);
            table.AddCell(cellTextoInformacionAerografica);
            table.AddCell(cellTextoCedulaNO);
            table.AddCell(cellTextoVuelo);
            table.AddCell(cellTextoFaja);
            table.AddCell(cellTextoFoto);
            table.AddCell(cellTextoAnioGrafica);
            table.AddCell(cellTextoAmpliacion);
            table.AddCell(cellTextoEscalaGrafica);
            Contador = 1;
            foreach (Consultar_Informacion_Geografica_Result Grafica in lstInformacion)
            {
                PdfPCell cellCedulaNO = UPdfReportes.CellValores(Convert.ToString(Contador), 1, 1);
                PdfPCell cellVuelo = UPdfReportes.CellValores(Grafica.strVuelo, 5, 1);
                PdfPCell cellFaja = UPdfReportes.CellValores(Grafica.strFaja, 2, 1);
                PdfPCell cellFoto = UPdfReportes.CellValores(Grafica.strFoto, 3, 1);
                PdfPCell cellAnioGrafica = UPdfReportes.CellValores(Grafica.strAnio, 2, 1);
                PdfPCell cellAmpliacion = UPdfReportes.CellValores(Grafica.strAmpliacion, 4, 1);
                PdfPCell cellEscalaGrafica = UPdfReportes.CellValores(Grafica.strEscalaAerografica, 3, 1);
                table.AddCell(cellCedulaNO);
                table.AddCell(cellVuelo);
                table.AddCell(cellFaja);
                table.AddCell(cellFoto);
                table.AddCell(cellAnioGrafica);
                table.AddCell(cellAmpliacion);
                table.AddCell(cellEscalaGrafica);
                Contador++;
            }
            #endregion
        }
        #endregion
        #region Metodos Publicos
        public List<Consultar_Informacion_Geografica_Result> getLstInformacion()
        {
            return this.lstInformacion;
        }
        public void getLstInformacion(List<Consultar_Informacion_Geografica_Result> lstInformacion)
        {
            this.lstInformacion = lstInformacion;
        }
        #endregion
    }
}
