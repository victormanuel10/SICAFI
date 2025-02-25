#Region "IMPORTS FORMULARIO"

Imports REGLAS_DEL_NEGOCIO
Imports System
Imports System.IO
Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration
Imports System.Text
Imports System.Drawing.Imaging

#End Region


Public Class frm_Reducir_Tamano_Fotografia

    '=============================================
    '*** REDUCIR TAMAÑO DE ARCHIVO FOTOGRAFICO ***
    '=============================================

#Region "INSTANCIAR FORMULARIO"

    Private Shared frm_Instance = Nothing

    Public Shared Function instance() As frm_Reducir_Tamano_Fotografia
        If frm_Instance Is Nothing OrElse frm_Instance.isdisposed = True Then
            frm_Instance = New frm_Reducir_Tamano_Fotografia
        End If

        frm_Instance.bringtofront()

        Return frm_Instance

    End Function

    Private Sub New()
        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()
        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
    End Sub

#End Region

#Region "VARIABLES"

    ' crea el objeto para abrir el archivo
    Dim oLeer As New OpenFileDialog

    ' otros procesos
    Dim inProceso As Integer = 0

    Dim vl_stRutaArchivo As String = ""
    Dim vl_stCarpetaDestino As String = ""

#End Region

#Region "FUNCIONES"

    Private Function GetEncoder(ByVal format As ImageFormat) As ImageCodecInfo

        Dim codecs As ImageCodecInfo() = ImageCodecInfo.GetImageDecoders()

        Dim codec As ImageCodecInfo
        For Each codec In codecs
            If codec.FormatID = format.Guid Then
                Return codec
            End If
        Next codec
        Return Nothing

    End Function

#End Region

#Region "PROCEDIMIENTOS"

    Private Sub pro_ListadoArchivosDocumentos(ByVal stRutaCarpeta As String)

        Try
            Me.lstLISTADO_DOCUMENTOS.Items.Clear()

            ' declara la variable
            Dim ContentItem As String

            If stRutaCarpeta <> "" Then

                vl_stRutaArchivo = Trim(stRutaCarpeta)

                ChDir(vl_stRutaArchivo)

                Me.lstLISTADO_DOCUMENTOS.Items.Clear()

                ContentItem = Dir("*.jpg")

                If ContentItem <> "" Then
                    Me.lstLISTADO_DOCUMENTOS.Focus()
                End If

                Dim i As Integer = 0

                Do Until ContentItem = ""
                    ' agrega a la lista
                    Me.lstLISTADO_DOCUMENTOS.Items.Add(ContentItem)

                    ' desplaza el registro
                    ContentItem = Dir()

                    ' cuenta los registros
                    i += 1
                Loop

                Me.strBARRESTA.Items(2).Text = "Nro. Registros: " & i

            Else
                Me.lstLISTADO_DOCUMENTOS.Items.Clear()

                Me.strBARRESTA.Items(2).Text = "Nro. Registros: " & 0
            End If

            Me.lstLISTADO_DOCUMENTOS.Focus()

            If Me.lstLISTADO_DOCUMENTOS.Items.Count > 0 Then
                Me.lstLISTADO_DOCUMENTOS.SelectedIndex = 0
            End If


        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub pro_LimpiarCampos()

        Me.lblCarpetaDestino.Text = ""
        Me.lblRutaArchivo.Text = ""

        Me.lstLISTADO_DOCUMENTOS.Items.Clear()

    End Sub

#End Region

#Region "MENU"

    Private Sub cmdEjecutarReduccion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdEjecutarReduccion.Click

        Try
            ' declara la variable
            Dim i As Integer = 0

            ' Valores predeterminados ProgressBar
            inProceso = 0
            Me.pbPROCESO.Value = 0
            Me.pbPROCESO.Maximum = Me.lstLISTADO_DOCUMENTOS.Items.Count + 1
            Me.Timer1.Enabled = True

            If lstLISTADO_DOCUMENTOS.Items.Count > 0 Then

                While lstLISTADO_DOCUMENTOS.Items.Count > 0

                    Me.lstLISTADO_DOCUMENTOS.SelectedIndex = lstLISTADO_DOCUMENTOS.Items.Count - 1

                    Dim bmp1 As New Bitmap(Trim(vl_stRutaArchivo & "\" & Me.lstLISTADO_DOCUMENTOS.SelectedItem))

                    Dim jgpEncoder As ImageCodecInfo = GetEncoder(ImageFormat.Jpeg)
                    Dim myEncoder As System.Drawing.Imaging.Encoder = System.Drawing.Imaging.Encoder.Quality
                    Dim myEncoderParameters As New EncoderParameters(1)

                    Dim myEncoderParameter As New EncoderParameter(myEncoder, 50&)
                    myEncoderParameters.Param(0) = myEncoderParameter
                    bmp1.Save(Trim(vl_stCarpetaDestino & "\" & Me.lstLISTADO_DOCUMENTOS.SelectedItem), jgpEncoder, myEncoderParameters)

                    Me.lstLISTADO_DOCUMENTOS.Items.RemoveAt(lstLISTADO_DOCUMENTOS.SelectedIndex)

                    ' Incrementa la barra
                    inProceso = inProceso + 1
                    pbPROCESO.Value = inProceso

                End While

            End If

            ' inicia la barra de progreso
            Me.pbPROCESO.Value = 0

            MessageBox.Show("Se realizo el proceso correctamente ", "Mensaje ...", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub cmdAbrirArchivo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAbrirArchivo.Click

        Try
             Dim oCarpetas As New FolderBrowserDialog
            Dim stNewPath As String = ""

            oCarpetas.ShowDialog()
            stNewPath = oCarpetas.SelectedPath

            vl_stRutaArchivo = stNewPath

            If Trim(vl_stRutaArchivo) <> "" Then
                Me.lblRutaArchivo.Text = vl_stRutaArchivo

                pro_ListadoArchivosDocumentos(vl_stRutaArchivo)

            Else
                Me.lblRutaArchivo.Text = ""
            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub cmdCarpetaDestino_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCarpetaDestino.Click

        Try
            Dim oCarpetas As New FolderBrowserDialog
            Dim stNewPath As String = ""

            oCarpetas.ShowDialog()
            stNewPath = oCarpetas.SelectedPath

            vl_stCarpetaDestino = stNewPath

            If Trim(vl_stCarpetaDestino) <> "" Then
                Me.lblCarpetaDestino.Text = vl_stCarpetaDestino
            Else
                Me.lblCarpetaDestino.Text = ""
            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub

#End Region

#Region "FORMULARIO"

#Region "Load"

    Private Sub frm_insertar_archivo_MUTACIONES_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        pro_LimpiarCampos()

        Me.strBARRESTA.Items(0).Text = "Reducir tamaño archivo"
    End Sub

#End Region

#Region "TextChanged"

    Private Sub lblRutaArchivo_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles lblRutaArchivo.TextChanged, lblCarpetaDestino.TextChanged

        If Me.lblRutaArchivo.Text <> "" And Me.lblCarpetaDestino.Text <> "" Then
            Me.cmdEjecutarReduccion.Enabled = True
        Else
            Me.cmdEjecutarReduccion.Enabled = False
        End If

    End Sub

#End Region

#End Region

End Class