using iTextSharp.text.pdf;
using JEJ.ImprimirFicha.Modelo.Listas;
using JEJ.ImprimirFicha.Negocio.Utilidades;
using System;
using System.Collections.Generic;

namespace JEJ.ImprimirFicha.Negocio.Reportes
{
    public class h_Propietario : _formatoReporte
    {
        #region Variables
        private List<Consultar_Propietario_Result> lstPropietario;
        private float[] widths = new float[] { 2f, 2f, 2f, 2f, 2f, 2f, 2f, 2f
                                                , 2f, 2f, 2f, 2f, 2f, 2f, 2f, 2f
                                                , 2f, 2f, 2f, 2f, 2f, 2f, 2f, 2f};
        private int intColumnas = 24;
        #endregion

        #region Constructor
        public h_Propietario(List<Consultar_Propietario_Result> lstPropietario)
        {
            this.lstPropietario = lstPropietario;
            CrearTable();
        }
        #endregion

        #region Metodos Publicos
        public void setLstPropietario(List<Consultar_Propietario_Result> lstPropietario)
        {
            this.lstPropietario = lstPropietario;
            CrearTable();
        }
        public List<Consultar_Propietario_Result> getLstPropietario()
        {
            return lstPropietario;
        }
       
        #endregion

        #region Metodos Privados
        private void CrearTable()
        {
            this.table = UPdfReportes.configurarTabla(intColumnas, widths);
            int Acomulador = 1;

            #region PROPIETARIO
            PdfPCell cellTextoPropietario = UPdfReportes.CellTitulo("PERSONA NATURAL O JURIDICA", 24);

            PdfPCell cellTextoNo = UPdfReportes.CellSubtitulo("Nro", 1, 1);
            PdfPCell cellTextoCDP = UPdfReportes.CellSubtitulo("Calidad prop.", 3, 1);
            PdfPCell cellTextoG = UPdfReportes.CellSubtitulo("G", 1, 1);
            PdfPCell cellTextoS = UPdfReportes.CellSubtitulo("Sexo", 3, 1);
            PdfPCell cellTextoCD = UPdfReportes.CellSubtitulo("Clase Doc.", 3, 1);
            PdfPCell cellTextoDocumento = UPdfReportes.CellSubtitulo("DOCUMENTO", 3, 1);
            PdfPCell cellTextoDerecho = UPdfReportes.CellSubtitulo("DERECHO%", 3, 1);
            PdfPCell cellTextoNombreCompleto = UPdfReportes.CellSubtitulo("NOMBRE Y APELLIDO", 7, 1);

            this.table.AddCell(cellTextoPropietario);
            this.table.AddCell(cellTextoNo);
            this.table.AddCell(cellTextoCDP);
            this.table.AddCell(cellTextoG);
            this.table.AddCell(cellTextoS);
            this.table.AddCell(cellTextoNombreCompleto);            
            this.table.AddCell(cellTextoCD);
            this.table.AddCell(cellTextoDocumento);
            this.table.AddCell(cellTextoDerecho);
            
            foreach(Consultar_Propietario_Result Propietario in lstPropietario)
            {
                PdfPCell cellNo = UPdfReportes.CellValores(Convert.ToString(Acomulador), 1, 1);
                PdfPCell cellCDP = UPdfReportes.CellValores(Propietario.strDescripcionCalidadPropietario, 3, 1);
                PdfPCell cellG = UPdfReportes.CellValores(Propietario.strGravable, 1, 1);
                PdfPCell cellS = UPdfReportes.CellValores(Propietario.strDescripcionSexo, 3, 1);
                PdfPCell cellCD = UPdfReportes.CellValores(Propietario.strDescripcionTipoDocumento, 3, 1);
                PdfPCell cellDocumento = UPdfReportes.CellValores(Propietario.strDocumento, 3, 1);
                PdfPCell cellDerecho = UPdfReportes.CellValores(Propietario.strDerecho, 3, 1);
                PdfPCell cellNombreCompleto = UPdfReportes.CellValores(Propietario.strNombreApellido, 7, 1);
   
                this.table.AddCell(cellNo);
                this.table.AddCell(cellCDP);
                this.table.AddCell(cellG);
                this.table.AddCell(cellS);
                this.table.AddCell(cellNombreCompleto);
                this.table.AddCell(cellCD);
                this.table.AddCell(cellDocumento);
                this.table.AddCell(cellDerecho);
                Acomulador++;
            }

            #endregion
        }
        #endregion
    }
}
