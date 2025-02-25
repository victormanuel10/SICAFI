Imports Microsoft.Office.Interop.Word
Imports System.IO
Imports Microsoft.Office.Interop

Public Class frm_AutomatizarWord

    Dim MSWord As New Word.Application
    Dim Documento As Word.Document


    Private Sub cmdGenerarArchivoWord_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGenerarArchivoWord.Click

        FileCopy("C:\Hoja de Vida\Plantilla.docx", "C:\Hoja de Vida\Plantilla1.docx")

        Documento = MSWord.Documents.Open("C:\Hoja de Vida\Plantilla.docx")

        Documento.Bookmarks.Item("WNombre").Range.Text = txtNombre.Text
        Documento.Bookmarks.Item("WDireccion").Range.Text = txtDireccion.Text
        Documento.Bookmarks.Item("WTelefono").Range.Text = txtTelefono.Text

        Documento.Save()
        MSWord.Visible = True



    End Sub

End Class