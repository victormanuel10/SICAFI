Imports REGLAS_DEL_NEGOCIO
Imports System
Imports System.IO
Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration
Imports System.Text

Public Class frm_visor_PDF

    '====================
    '*** VISOR DE PDF ***
    '====================

#Region "VARIABLE"

    Private vl_stRutaPDF As String = ""
    Private vl_boPermisoControlComando As Boolean = False

#End Region

#Region "CONSTRUCTOR"

    Public Sub New(ByVal stRutaPDF As String, ByVal boPermisoControlComando As Boolean)

        vl_stRutaPDF = stRutaPDF
        vl_boPermisoControlComando = boPermisoControlComando

        InitializeComponent()

        If vl_stRutaPDF <> "" Then
            pro_MostrarImagen()
            pro_PermisoControlDeComandos()
        Else
            pro_Cerrar()
        End If

    End Sub

#End Region

#Region "PROCEDIMIENTOS"

    Private Sub pro_PermisoControlDeComandos()

        Try

            Me.axaVisorDocumentoPDF.setShowToolbar(vl_boPermisoControlComando)

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub pro_MostrarImagen()

        Try
            ' visualiza el archivo
            Me.axaVisorDocumentoPDF.LoadFile(vl_stRutaPDF)
            Me.axaVisorDocumentoPDF.gotoFirstPage()
            Me.axaVisorDocumentoPDF.setZoom(100)

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub pro_Cerrar()
        Me.Close()
    End Sub

#End Region

#Region "MENU"

    Private Sub cmdSALIR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSALIR.Click
        Me.Close()
    End Sub

#End Region

End Class