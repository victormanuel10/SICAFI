using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using JEJ.ImprimirFicha.Modelo.Listas;
using JEJ.ImprimirFicha.Negocio.Utilidades;

namespace JEJ.ImprimirFicha.Negocio.Reportes
{
    public class m_InformacionGrafica : _formatoReporte
    {
        #region Variables
        private List<Consultar_Informacion_Geografica_Result> lstInformacion;
        private float[] widths = new float[] { 2f, 2f, 2f, 2f, 2f, 2f, 2f, 2f, 2f, 2f
                                              ,2f, 2f, 2f, 2f, 2f, 2f, 2f, 2f, 2f, 2f};
        private int intColumnas = 20;
        #endregion
        #region Constructor
        public m_InformacionGrafica(List<Consultar_Informacion_Geografica_Result> lstInformacion)
        {
            this.lstInformacion = lstInformacion;
            crearTabla();
        }
        #endregion
        #region Metodos Privados
        private void crearTabla()
        {
            table = UPdfReportes.configurarTabla(intColumnas, widths);
            int Contador = 1;
            #region Informacion Grafica
            PdfPCell cellTextoInformacionGrafica = UPdfReportes.CellTitulo("INFORMACIÓN GRÁFICA ", 20);
            PdfPCell cellTextoCedulaNO = UPdfReportes.CellSubtitulo("NO", 1, 1);
            PdfPCell cellTextoPlancha = UPdfReportes.CellSubtitulo("PLANCHA", 7, 1);
            PdfPCell cellTextoVentana = UPdfReportes.CellSubtitulo("VENTANA", 4, 1);
            PdfPCell cellTextoEscala = UPdfReportes.CellSubtitulo("ESCALA", 6, 1);
            PdfPCell cellTextoAnio = UPdfReportes.CellSubtitulo("AÑO", 2, 1);
            table.AddCell(cellTextoInformacionGrafica);
            table.AddCell(cellTextoCedulaNO);
            table.AddCell(cellTextoPlancha);
            table.AddCell(cellTextoVentana);
            table.AddCell(cellTextoEscala);
            table.AddCell(cellTextoAnio);
            foreach (Consultar_Informacion_Geografica_Result Grafica in lstInformacion)
            {
                PdfPCell cellCedulaNO = UPdfReportes.CellValores(Convert.ToString(Contador), 1, 1);
                PdfPCell cellPlancha = UPdfReportes.CellValores(Grafica.strPlancha, 7, 1);
                PdfPCell cellVentana = UPdfReportes.CellValores(Grafica.strVentana, 4, 1);
                PdfPCell cellEscala = UPdfReportes.CellValores(Grafica.strEscala, 6, 1);
                PdfPCell cellAnio = UPdfReportes.CellValores(Grafica.strVegencia, 2, 1);
                
                table.AddCell(cellCedulaNO);
                table.AddCell(cellPlancha);
                table.AddCell(cellVentana);
                table.AddCell(cellEscala);
                table.AddCell(cellAnio);
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
