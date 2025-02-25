using iTextSharp.text.pdf;
using JEJ.ImprimirFicha.Modelo.Listas;
using JEJ.ImprimirFicha.Negocio.Utilidades;
using System;
using System.Collections.Generic;

namespace JEJ.ImprimirFicha.Negocio.Reportes
{
    public class i_JustificacionPropietario: _formatoReporte
    {
        #region Variables
        private List<Consultar_Propietario_Result> lstPropietario;
        private float[] widths = new float[] { 2f, 2f, 2f, 2f, 2f, 2f, 2f, 2f
                                                , 2f, 2f, 2f, 2f, 2f, 2f, 2f, 2f
                                                , 2f, 2f, 2f, 2f, 2f, 2f, 2f, 2f};
        private int intColumnas = 24;
        #endregion

        #region Constructor
        public i_JustificacionPropietario(List<Consultar_Propietario_Result> lstPropietario)
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

            #region PROPIETARIO ANTERIOR
            PdfPCell cellTextoJustificacionDerecho = UPdfReportes.CellTitulo("JUSTIFICACIÓN DEL DERECHO DE PROPIEDAD O DE POSESIÓN", 24);            
            Acomulador = 1;

            PdfPCell cellTextoNo = UPdfReportes.CellSubtitulo("Nro", 1, 1);
            PdfPCell cellTextoCA = UPdfReportes.CellSubtitulo("CA", 1, 1);
            PdfPCell cellTextoPropietarioAnterior = UPdfReportes.CellSubtitulo("PROPIETARIO ANTERIOR", 6, 1);
            PdfPCell cellTextoEscritura = UPdfReportes.CellSubtitulo("ESCRITURA", 3, 1);
            PdfPCell cellTextoDepartamento = UPdfReportes.CellSubtitulo("DEPT.", 2, 1);
            PdfPCell cellTextoMunicipio = UPdfReportes.CellSubtitulo("MPIO.", 2, 1);
            PdfPCell cellTextoNotaria = UPdfReportes.CellSubtitulo("NOTARIA", 3, 1);
            PdfPCell cellTextoFecha = UPdfReportes.CellSubtitulo("FECHA ESC.", 3, 1);
            PdfPCell cellTextoFechaRegistro = UPdfReportes.CellSubtitulo("FECHA REG.", 3, 1);
            table.AddCell(cellTextoJustificacionDerecho);
            table.AddCell(cellTextoNo);
            table.AddCell(cellTextoCA);
            table.AddCell(cellTextoPropietarioAnterior);
            table.AddCell(cellTextoEscritura);
            table.AddCell(cellTextoDepartamento);
            table.AddCell(cellTextoMunicipio);
            table.AddCell(cellTextoNotaria);
            table.AddCell(cellTextoFecha);
            table.AddCell(cellTextoFechaRegistro);


            foreach (Consultar_Propietario_Result Propietario in lstPropietario)
            {
                PdfPCell cellNo = UPdfReportes.CellValores(Convert.ToString(Acomulador), 1, 1);
                PdfPCell cellCA = UPdfReportes.CellValores(Propietario.strCausaActo, 1, 1);
                PdfPCell cellPropietarioAnterior = UPdfReportes.CellValores(Propietario.strPropietarioAnterior, 6, 1);
                PdfPCell cellEscritura = UPdfReportes.CellValores(Propietario.strEscritura, 3, 1);
                PdfPCell cellDepartamento = UPdfReportes.CellValores(Propietario.strDepartamento, 2, 1);
                PdfPCell cellMunicipio = UPdfReportes.CellValores(Propietario.strMunicipio, 2, 1);
                PdfPCell cellNotaria = UPdfReportes.CellValores(Propietario.strEntidad, 3, 1);
                PdfPCell cellFecha = UPdfReportes.CellValores(Propietario.strFecha, 3, 1);
                PdfPCell cellFechaRegistro = UPdfReportes.CellValores(Propietario.strFechaRegistro, 3, 1);
               
                table.AddCell(cellNo);
                table.AddCell(cellCA);
                table.AddCell(cellPropietarioAnterior);
                table.AddCell(cellEscritura);
                table.AddCell(cellDepartamento);
                table.AddCell(cellMunicipio);
                table.AddCell(cellNotaria);
                table.AddCell(cellFecha);
                table.AddCell(cellFechaRegistro);
            }
            #endregion
        }
        #endregion
    }
}
