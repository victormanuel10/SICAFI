Imports Microsoft.Office.Interop

Public Class Comienzo

    Private Sub cmdConvertir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdConvertir.Click

        'Creating the instance of Word Application
        Dim newApp As New Word.Application()

        ' Pon unos caminos que sean buenos
        Dim Source As Object = "c:\temp\Imagenes.docx"
        Dim Target As Object = "c:\temp\Imagenes.pdf"

        ' Use for the parameter whose type are not known or say Missing
        Dim Unknown As Object = Type.Missing

        ' Source document open here
        ' Additional Parameters are not known so that are
        ' set as a missing type
        newApp.Documents.Open(Source, Unknown, Unknown, Unknown, Unknown, Unknown, Unknown, Unknown, Unknown, Unknown, Unknown, Unknown, Unknown, Unknown, Unknown)

        ' Specifying the format in which you want the output file
        Dim format As Object = Word.WdSaveFormat.wdFormatPDF

        'Changing the format of the document
        newApp.ActiveDocument.SaveAs(Target, format, Unknown, Unknown, Unknown, Unknown, Unknown, Unknown, Unknown, Unknown, Unknown, Unknown, Unknown, Unknown, Unknown, Unknown)

        ' for closing the application
        newApp.Quit(Unknown, Unknown, Unknown)

    End Sub
End Class