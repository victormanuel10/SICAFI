Imports System.Data
Imports System.IO
Imports Microsoft.Office.Interop


Public Class cla_ExportarTablaExcel

    '==============================
    '*** EXPORTAR TABLA A EXCEL ***
    '==============================

    Public Sub DataTableToExcel(ByVal pDataTable As DataTable)

        Dim vFileName As String = Path.GetTempFileName()

        FileOpen(1, vFileName, OpenMode.Output)

        Dim sb As String = ""
        Dim dc As DataColumn
        For Each dc In pDataTable.Columns
            sb &= dc.Caption & Microsoft.VisualBasic.ControlChars.Tab
        Next
        PrintLine(1, sb)

        Dim i As Integer = 0
        Dim dr As DataRow
        For Each dr In pDataTable.Rows

            i = 0 : sb = ""
            For Each dc In pDataTable.Columns
                If Not IsDBNull(dr(i)) Then
                    sb &= CStr(dr(i)) & Microsoft.VisualBasic.ControlChars.Tab
                Else
                    sb &= Microsoft.VisualBasic.ControlChars.Tab
                End If
                i += 1
            Next

            PrintLine(1, sb)
        Next
        FileClose(1)
        TextToExcel(vFileName)

    End Sub

    Public Sub TextToExcel(ByVal pFileName As String)

        Dim vFormato As Excel.XlRangeAutoFormat

        Dim vCultura As System.Globalization.CultureInfo = System.Threading.Thread.CurrentThread.CurrentCulture
        System.Threading.Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.CreateSpecificCulture("en-US")

        Dim Exc As Excel.Application = New Excel.Application
        Exc.Workbooks.OpenText(pFileName, , , , Excel.XlTextQualifier.xlTextQualifierNone, , True)

        Dim Wb As Excel.Workbook = Exc.ActiveWorkbook
        Dim Ws As Excel.Worksheet = Wb.ActiveSheet

        'Se le indica el formato al que queremos exportarlo
        Dim valor As Integer = 14
        If valor > -1 Then
            Select Case valor

                Case 0 : vFormato = Excel.XlRangeAutoFormat.xlRangeAutoFormatNone
                Case 1 : vFormato = Excel.XlRangeAutoFormat.xlRangeAutoFormatSimple
                Case 2 : vFormato = Excel.XlRangeAutoFormat.xlRangeAutoFormatClassic1
                Case 3 : vFormato = Excel.XlRangeAutoFormat.xlRangeAutoFormatClassic2
                Case 4 : vFormato = Excel.XlRangeAutoFormat.xlRangeAutoFormatClassic3
                Case 5 : vFormato = Excel.XlRangeAutoFormat.xlRangeAutoFormatAccounting1
                Case 6 : vFormato = Excel.XlRangeAutoFormat.xlRangeAutoFormatAccounting2
                Case 7 : vFormato = Excel.XlRangeAutoFormat.xlRangeAutoFormatAccounting3
                Case 8 : vFormato = Excel.XlRangeAutoFormat.xlRangeAutoFormatAccounting4
                Case 9 : vFormato = Excel.XlRangeAutoFormat.xlRangeAutoFormatColor1
                Case 10 : vFormato = Excel.XlRangeAutoFormat.xlRangeAutoFormatColor2
                Case 11 : vFormato = Excel.XlRangeAutoFormat.xlRangeAutoFormatColor3
                Case 12 : vFormato = Excel.XlRangeAutoFormat.xlRangeAutoFormatList1
                Case 13 : vFormato = Excel.XlRangeAutoFormat.xlRangeAutoFormatList2
                Case 14 : vFormato = Excel.XlRangeAutoFormat.xlRangeAutoFormatList3
                Case 15 : vFormato = Excel.XlRangeAutoFormat.xlRangeAutoFormat3DEffects1
                Case 16 : vFormato = Excel.XlRangeAutoFormat.xlRangeAutoFormat3DEffects2
                Case 17 : vFormato = Excel.XlRangeAutoFormat.xlRangeAutoFormatReport1

            End Select

            Ws.Range(Ws.Cells(1, 1), Ws.Cells(Ws.UsedRange.Rows.Count, Ws.UsedRange.Columns.Count)).AutoFormat(vFormato)

            pFileName = Path.GetTempFileName.Replace("tmp", "xls")
            File.Delete(pFileName)
            Exc.ActiveWorkbook.SaveAs(pFileName, Excel.XlTextQualifier.xlTextQualifierNone - 1)
        End If
        Exc.Quit()

        Ws = Nothing
        Wb = Nothing
        Exc = Nothing

        GC.Collect()

        If valor > -1 Then
            'Dim p As System.Diagnostics.Process = New System.Diagnostics.Process
            'p.EnableRaisingEvents = False
            'p.Start("Excel.exe", pFileName)
            Process.Start(pFileName)
        End If
        System.Threading.Thread.CurrentThread.CurrentCulture = vCultura
    End Sub




End Class
