#Region "IMPORTS FORMULARIO"

Imports REGLAS_DEL_NEGOCIO
Imports System
Imports System.IO
Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration
Imports System.Text

#End Region

#Region "IMPORTS BARRA DE PROGRESO"

Imports System.Collections
Imports System.ComponentModel
Imports System.Drawing
Imports System.Threading
Imports System.Windows.Forms

#End Region

Public Class frm_Duplicar_Fotografias

    '============================
    '*** DUPLICAR FOTOGRAFIAS ***
    '============================

#Region "INSTANCIAR FORMULARIO"

    Private Shared frm_Instance = Nothing

    Public Shared Function instance() As frm_Duplicar_Fotografias
        If frm_Instance Is Nothing OrElse frm_Instance.isdisposed = True Then
            frm_Instance = New frm_Duplicar_Fotografias
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

    ' crea las variables de conexion
    Private oEjecutar As New SqlCommand
    Private oConexion As New SqlConnection
    Private oAdapter As New SqlDataAdapter
    Private ds As New DataSet
    Private dt As New DataTable

    ' crea el objeto para abrir el archivo
    Dim oLeer As New OpenFileDialog

    ' otros procesos
    Dim inProceso As Integer = 0

    Dim stRutaArchivo As String = ""
    Dim stCarpetaDestino As String = ""

    Private inNumberToCompute As Integer = 0
    Private inHighesPorcentageReached As Integer = 0

#End Region

#Region "FUNCIONES"

    Function fun_BarraDeProgreso(ByVal inNroRegistro As Integer, ByVal worker As BackgroundWorker, ByVal e As DoWorkEventArgs) As Long

        Try
            Dim loResult As Long = 0

            If worker.CancellationPending Then
                e.Cancel = True

            Else

                Dim inPorcetajeCompletado As Integer = CSng(inNroRegistro) / CSng(inNumberToCompute) * 100

                If inPorcetajeCompletado > inHighesPorcentageReached Then

                    inHighesPorcentageReached = inPorcetajeCompletado
                    worker.ReportProgress(inPorcetajeCompletado)

                End If

            End If

            Return loResult

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Function

#End Region

#Region "PROCEDIMIENTOS"

    Private Sub pro_CopiarDocumento(ByVal stRutaInicial As String, ByVal stRutaDestino As String)

        Try
            If File.Exists(Trim(stRutaDestino)) = False Then
                File.Copy(Trim(stRutaInicial), Trim(stRutaDestino))

                'MessageBox.Show("Se copio el archivo correctamente ", "Mensaje ...", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            ElseIf File.Exists(Trim(stRutaDestino)) = True Then

                MessageBox.Show("Archivo existente", "Mensaje ...", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1)
            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub

#End Region

#Region "MENU"

    Private Sub cmdEjecutarCopia_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdEjecutarCopia.Click

        Try
            ' declara la variable
            Dim inNroFicha As Integer = CInt(Me.txtNroFichaPredial.Text)
            Dim i As Integer = 0

            ' Valores predeterminados ProgressBar
            inProceso = 0
            Me.pbPROCESO.Value = 0
            Me.pbPROCESO.Maximum = Me.nudNroRepeticiones.Value + 1
            Me.Timer1.Enabled = True

            ' almacena y procesa las repeticiones
            'inHighesPorcentageReached = 0
            'inNumberToCompute = Me.nudNroRepeticiones.Value
            'BackgroundWorker1.RunWorkerAsync(inNumberToCompute)

            For i = 0 To Me.nudNroRepeticiones.Value - 1

                ' almacena la ruta
                Dim stRutaInicial As String = Trim(stRutaArchivo)
                Dim stRutaDestino As String = ""

                ' verifica la condicion
                If Me.chkDuplicarCroquis.Checked = True Then

                    stRutaDestino = Trim(stCarpetaDestino) & "\" & CInt(inNroFicha) & ".jpg"

                ElseIf Me.chkDuplicarCroquis.Checked = False Then

                    stRutaDestino = Trim(stCarpetaDestino) & "\" & CInt(inNroFicha) & "-" & Me.nudNroConstrucciones.Value & "-" & Me.nudFotografia.Value & ".jpg"

                End If

                ' realiza la copia
                pro_CopiarDocumento(stRutaInicial, stRutaDestino)

                ' incrementa la ficha
                inNroFicha += 1

                ' Incrementa la barra
                inProceso = inProceso + 1
                pbPROCESO.Value = inProceso

            Next

            ' inicia la barra de progreso
            Me.pbPROCESO.Value = 0

            MessageBox.Show("Se copio el archivo correctamente ", "Mensaje ...", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub cmdAbrirArchivo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAbrirArchivo.Click

        Try
            ' enruta el archivo
            oLeer.InitialDirectory = "C:\Documents and Settings\Estudiante\Mis documentos"
            oLeer.Filter = "Archivo de imagen (*.jpg)|*.jpg" 'Colocar varias extensiones
            oLeer.FilterIndex = 1 'coloca por defecto el *.txt
            oLeer.FileName = ""
            oLeer.ShowDialog()

            stRutaArchivo = Trim(oLeer.FileName)

            If Trim(stRutaArchivo) <> "" Then
                Me.lblRutaArchivo.Text = stRutaArchivo
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

            stCarpetaDestino = stNewPath

            If Trim(stCarpetaDestino) <> "" Then
                Me.lblCarpetaDestino.Text = stCarpetaDestino
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
        Me.strBARRESTA.Items(0).Text = "Duplicar fotografía"
    End Sub

#End Region

#Region "TextChanged"

    Private Sub lblRutaArchivo_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles lblRutaArchivo.TextChanged, lblCarpetaDestino.TextChanged

        If Me.lblRutaArchivo.Text <> "" And Me.lblCarpetaDestino.Text <> "" Then
            Me.cmdEjecutarCopia.Enabled = True
        Else
            Me.cmdEjecutarCopia.Enabled = False
        End If

    End Sub

#End Region

#Region "CheckedChanged"

    Private Sub chkDuplicarCroquis_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkDuplicarCroquis.CheckedChanged

        If Me.chkDuplicarCroquis.Checked = True Then

            Me.nudNroConstrucciones.Enabled = False
            Me.nudFotografia.Enabled = False

            Me.nudNroConstrucciones.Value = 0
            Me.nudFotografia.Value = 0

        ElseIf Me.chkDuplicarCroquis.Checked = False Then

            Me.nudNroConstrucciones.Enabled = True
            Me.nudFotografia.Enabled = True

        End If

    End Sub

#End Region

#Region "DoWork"

    Private Sub BackgroundWorker1_DoWork(ByVal sender As Object, ByVal e As DoWorkEventArgs) Handles BackgroundWorker1.DoWork

        Try
            'Dim woker As BackgroundWorker = CType(sender, BackgroundWorker)

            'e.Result = fun_BarraDeProgreso(e.Argument, woker, e)

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub

#End Region

#Region "RunWorkerCompleted"

    Private Sub BackgroundWorker1_RunWorkerCompleted(ByVal sender As Object, ByVal e As RunWorkerCompletedEventArgs) Handles BackgroundWorker1.RunWorkerCompleted

        Try
            'If (e.Error IsNot Nothing) Then
            '    MessageBox.Show(e.Error.Message)

            'ElseIf e.Cancelled Then
            '    MessageBox.Show("El proceso fue cancelado", "Mensaje...")

            'End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub

#End Region

#Region "ProgressChanged"

    Private Sub BackgroundWorker1_ProgressChanged(ByVal sender As Object, ByVal e As ProgressChangedEventArgs) Handles BackgroundWorker1.ProgressChanged

        Try
            'Me.pbPROCESO.Value = e.ProgressPercentage

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub

#End Region

#End Region

End Class