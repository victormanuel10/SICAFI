Imports REGLAS_DEL_NEGOCIO
Imports System
Imports System.IO
Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration
Imports System.Text

Public Class frm_insertar_archivo_REVIAVAL

    '===========================================
    '*** INSERTAR ARCHIVO REVISION DE AVALUO ***
    '===========================================

#Region "VARIABLE"

    Dim dt1 As New DataTable
    Dim dr1 As DataRow

    Dim oLeer As New OpenFileDialog

    Dim lv_inFIPRSECU As Integer = 0
    Dim lv_inFIPRNUFI As Integer = 0
    Dim vl_stFIPRMUNI As String = ""
    Dim vl_stFIPRCORR As String = ""
    Dim vl_stFIPRBARR As String = ""
    Dim vl_stFIPRMANZ As String = ""
    Dim vl_stFIPRPRED As String = ""
    Dim vl_stFIPREDIF As String = ""
    Dim vl_stFIPRUNPR As String = ""
    Dim vl_inFIPRCLSE As Integer = 0
    Dim vl_inFIPRVIGE As Integer = 0
    Dim vl_inFIPRESCR As Integer = 0

    Dim vl_stRutaDocumentos As String = ""
    Dim vl_stRutaDocumentosIndividual As String = ""

    Dim boArchivoIndivial As Boolean = False

#End Region

#Region "CONSTRUCTOR"

    Public Sub New(ByVal inFIPRSECU As Integer, _
                   ByVal stFIPRMUNI As String, _
                   ByVal stFIPRCORR As String, _
                   ByVal stFIPRBARR As String, _
                   ByVal stFIPRMANZ As String, _
                   ByVal stFIPRPRED As String, _
                   ByVal stFIPREDIF As String, _
                   ByVal stFIPRUNPR As String, _
                   ByVal inFIPRCLSE As Integer, _
                   ByVal inFIPRVIGE As Integer)

        lv_inFIPRSECU = inFIPRSECU
        vl_stFIPRMUNI = Trim(stFIPRMUNI)
        vl_stFIPRCORR = Trim(stFIPRCORR)
        vl_stFIPRBARR = Trim(stFIPRBARR)
        vl_stFIPRMANZ = Trim(stFIPRMANZ)
        vl_stFIPRPRED = Trim(stFIPRPRED)
        vl_stFIPREDIF = Trim(stFIPREDIF)
        vl_stFIPRUNPR = Trim(stFIPRUNPR)
        vl_inFIPRCLSE = inFIPRCLSE
        vl_inFIPRVIGE = inFIPRVIGE

        InitializeComponent()
        pro_LimpiarCampos()
        pro_inicializarControles()
        pro_ListadoArchivosDocumentos()

    End Sub

#End Region

#Region "FUNCIONES"

    Private Function fun_ConsultarRutaInicial() As String

        Try
            Dim stRutaInicial As String = ""

            stRutaInicial = vl_stRutaDocumentos & "\" & Me.lstLISTADO_DOCUMENTOS.SelectedItem

            Return stRutaInicial

        Catch ex As Exception
            MessageBox.Show(Err.Description)
            Return ""
        End Try

    End Function
    Private Function fun_consultarRutaDestino() As String

        Try
            Dim stRutaDestino As String = ""
            Dim stRuta As String = ""

            If Me.rbdDocumentosImagenes.Checked = True Then

                ' instancia la clase
                Dim objRutas As New cla_RUTAS
                Dim tblRutas As New DataTable

                tblRutas = objRutas.fun_Buscar_CODIGO_MANT_RUTAS(14)

                If tblRutas.Rows.Count > 0 Then

                    ' directorio pricipal
                    stRuta = Trim(tblRutas.Rows(0).Item("RUTARUTA")) & "\"

                    ' instancia la clase
                    Dim objActoAdministrativo1 As New cla_REAVACAD
                    Dim tblActoAdministrativo1 As New DataTable

                    tblActoAdministrativo1 = objActoAdministrativo1.fun_Buscar_CODIGO_X_REAVACAD(lv_inFIPRSECU)

                    If tblActoAdministrativo1.Rows.Count > 0 Then

                        Dim stRAAANUEM As String = Trim(tblActoAdministrativo1.Rows(0).Item("RAAANUEM"))
                        Dim stRAAAFEEM As String = Trim(tblActoAdministrativo1.Rows(0).Item("RAAAFEEM"))

                        If tblRutas.Rows.Count > 0 AndAlso Trim(stRAAANUEM) <> "" AndAlso Trim(stRAAAFEEM).ToString.Length = 10 Then

                            stRuta += fun_Formato_Mascara_3_String(Trim(stRAAANUEM)) & "-" & fun_Formato_Mascara_4_String(Trim(stRAAAFEEM.ToString.Substring(6, 4))) & "\" & Me.lstLISTADO_DOCUMENTOS.SelectedItem
                        Else
                            stRuta = ""

                        End If

                    End If

                End If

            ElseIf Me.rbdResolucionesAdminsitrativas.Checked = True Then

                Dim objRutas1 As New cla_RUTAS
                Dim tblRutas1 As New DataTable

                tblRutas1 = objRutas1.fun_Buscar_CODIGO_MANT_RUTAS(5)

                If tblRutas1.Rows.Count > 0 Then

                    ' directorio pricipal
                    stRuta = Trim(tblRutas1.Rows(0).Item("RUTARUTA")) & "\"

                    ' instancia la clase
                    Dim objActoAdministrativo2 As New cla_REAVACAD
                    Dim tblActoAdministrativo2 As New DataTable

                    tblActoAdministrativo2 = objActoAdministrativo2.fun_Buscar_CODIGO_X_REAVACAD(lv_inFIPRSECU)

                    If tblActoAdministrativo2.Rows.Count > 0 Then

                        Dim stRAAANURA As String = Trim(tblActoAdministrativo2.Rows(0).Item("RAAANURA"))
                        Dim stRAAAFERA As String = Trim(tblActoAdministrativo2.Rows(0).Item("RAAAFERA"))

                        If tblRutas1.Rows.Count > 0 AndAlso Trim(stRAAANURA) <> "" AndAlso Trim(stRAAAFERA).ToString.Length = 10 Then

                            stRuta += Trim(stRAAANURA) & "-" & fun_Formato_Mascara_4_String(Trim(stRAAAFERA.ToString.Substring(6, 4))) & "\" & Me.lstLISTADO_DOCUMENTOS.SelectedItem
                        Else
                            stRuta = ""

                        End If

                    End If

                End If

            End If

            ' directorio expediente 
            stRutaDestino = stRuta

            Return stRutaDestino

        Catch ex As Exception
            MessageBox.Show(Err.Description)
            Return ""
        End Try

    End Function

#End Region

#Region "PROCEDIMIENTOS"

    Private Sub pro_LimpiarCampos()

        Me.lstLISTADO_DOCUMENTOS.Items.Clear()

    End Sub
    Private Sub pro_inicializarControles()

        Try

            Dim objRuta As New cla_RUTAS
            Dim tblRuta As New DataTable

            tblRuta = objRuta.fun_Buscar_CODIGO_MANT_RUTAS(10)

            If tblRuta.Rows.Count > 0 Then
                Me.lblRuta.Text = Trim(tblRuta.Rows(0).Item("RUTARUTA").ToString)
            Else
                Me.lblRuta.Text = ""
            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub pro_ListadoArchivosDocumentos()

        Try
            Me.lstLISTADO_DOCUMENTOS.Items.Clear()

            ' declara la variable
            Dim stRuta As String = ""
            Dim stNewPath As String = ""
            Dim ContentItem As String

            ' instancia la clase
            Dim objRutas As New cla_RUTAS
            Dim tblRutas As New DataTable

            tblRutas = objRutas.fun_Buscar_CODIGO_MANT_RUTAS(10)

            If tblRutas.Rows.Count > 0 Then

                stNewPath = Trim(tblRutas.Rows(0).Item("RUTARUTA"))

                vl_stRutaDocumentos = stNewPath

                ChDir(stNewPath)

                Me.lstLISTADO_DOCUMENTOS.Items.Clear()

                ContentItem = Dir("*.*")

                If ContentItem <> "" Then
                    Me.lstLISTADO_DOCUMENTOS.Focus()
                End If

                Dim i As Integer = 0

                Do Until ContentItem = ""
                    ' agrega a la lista
                    Me.lstLISTADO_DOCUMENTOS.Items.Add(ContentItem)

                    'desplaza el registro
                    ContentItem = Dir()

                    ' cuenta los registros
                    i += 1
                Loop

                Me.strBARRESTA.Items(2).Text = "Registro: " & i
            Else
                Me.lstLISTADO_DOCUMENTOS.Items.Clear()
                Me.strBARRESTA.Items(2).Text = "Registro: " & 0
            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub pro_ListadoArchivosDocumentos(ByVal stRutaCarpeta As String)

        Try
            Me.lstLISTADO_DOCUMENTOS.Items.Clear()

            ' declara la variable
            Dim stRuta As String = ""
            Dim stNewPath As String = ""
            Dim ContentItem As String

            If stRutaCarpeta <> "" Then

                stNewPath = Trim(stRutaCarpeta)

                vl_stRutaDocumentos = stNewPath

                ChDir(stNewPath)

                Me.lstLISTADO_DOCUMENTOS.Items.Clear()

                ContentItem = Dir("*.*")

                If ContentItem <> "" Then
                    Me.lstLISTADO_DOCUMENTOS.Focus()
                End If

                Dim i As Integer = 0

                Do Until ContentItem = ""
                    ' agrega a la lista
                    Me.lstLISTADO_DOCUMENTOS.Items.Add(ContentItem)

                    'desplaza el registro
                    ContentItem = Dir()

                    ' cuenta los registros
                    i += 1
                Loop

                Me.strBARRESTA.Items(2).Text = "Registro: " & i
            Else
                Me.lstLISTADO_DOCUMENTOS.Items.Clear()
                Me.strBARRESTA.Items(2).Text = "Registro: " & 0
            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
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
    Private Sub pro_EliminarDocumento(ByVal stRutaDestino As String)

        Try
            If File.Exists(Trim(stRutaDestino)) = True Then
                File.Delete(Trim(stRutaDestino))

                'MessageBox.Show("Se elimino el archivo", "Mensaje ...", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            Else
                MessageBox.Show("Archivo no existente", "Mensaje ...", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1)
            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub

#End Region

#Region "MENU"

    Private Sub cmdGUARDAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGUARDAR.Click

        Try
            If Me.chkImportarTodos.Checked = False Then

                If Me.lstLISTADO_DOCUMENTOS.SelectedIndex <> -1 Then

                    Dim stRutaInicial As String = fun_ConsultarRutaInicial()
                    Dim stRutaDestino As String = fun_consultarRutaDestino()

                    If Trim(stRutaDestino) <> "" Then

                        pro_CopiarDocumento(stRutaInicial, stRutaDestino)

                        If Me.chkRealizarCopia.Checked = False Then
                            pro_EliminarDocumento(stRutaInicial)
                        End If

                        Me.lstLISTADO_DOCUMENTOS.Items.RemoveAt(lstLISTADO_DOCUMENTOS.SelectedIndex)

                        MessageBox.Show("Se copio el archivo correctamente ", "Mensaje ...", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)

                    Else
                        MessageBox.Show("NO se copio el archivo debido que la ruta no esta completa ", "Mensaje ...", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1)
                    End If

                Else
                    If Me.lstLISTADO_DOCUMENTOS.Items.Count > 0 Then
                        MessageBox.Show("Para guardar un documento, debe seleccionarlo previamente", "Mensaje ...", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Else
                        MessageBox.Show("No existen documentos cargados", "Mensaje ...", MessageBoxButtons.OK, MessageBoxIcon.Hand)
                    End If

                End If

            ElseIf Me.chkImportarTodos.Checked = True Then

                If lstLISTADO_DOCUMENTOS.Items.Count > 0 Then

                    While lstLISTADO_DOCUMENTOS.Items.Count > 0

                        lstLISTADO_DOCUMENTOS.SelectedIndex = lstLISTADO_DOCUMENTOS.Items.Count - 1

                        Dim stRutaInicial As String = fun_ConsultarRutaInicial()
                        Dim stRutaDestino As String = fun_consultarRutaDestino()

                        pro_CopiarDocumento(stRutaInicial, stRutaDestino)

                        If Me.chkRealizarCopia.Checked = False Then
                            pro_EliminarDocumento(stRutaInicial)
                        End If

                        Me.lstLISTADO_DOCUMENTOS.Items.RemoveAt(lstLISTADO_DOCUMENTOS.SelectedIndex)

                    End While

                    Me.Close()

                    MessageBox.Show("Se copio el archivo correctamente ", "Mensaje ...", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)

                Else
                    MessageBox.Show("No existen documentos cargados", "Mensaje ...", MessageBoxButtons.OK, MessageBoxIcon.Hand)

                End If

            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub cmdSALIR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSALIR.Click
        Me.Close()
    End Sub
    Private Sub cmdAbrirArchivoMunicipio_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAbrirCarpeta.Click

        Try

            Dim oCarpetas As New FolderBrowserDialog
            Dim stNewPath As String = ""

            oCarpetas.ShowDialog()
            stNewPath = oCarpetas.SelectedPath

            vl_stRutaDocumentos = stNewPath

            If Trim(vl_stRutaDocumentos) <> "" Then

                pro_ListadoArchivosDocumentos(Trim(vl_stRutaDocumentos))

                Me.lblRuta.Text = vl_stRutaDocumentos

            Else
                Me.lstLISTADO_DOCUMENTOS.Items.Clear()
                Me.lblRuta.Text = ""

            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub

#End Region

#Region "FORMULARIO"

#Region "Load"

    Private Sub frm_insertar_archivo_MUTACIONES_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.strBARRESTA.Items(0).Text = "Importar documentos"
    End Sub

#End Region

#Region "GotFocus"

    Private Sub cmd_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdGUARDAR.GotFocus, cmdSALIR.GotFocus
        pp_pro_DescripcionCampo(Me.strBARRESTA.Items(0), sender)
    End Sub
    Private Sub dgv_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs)
        pp_pro_DescripcionCampo(Me.strBARRESTA.Items(0), sender)
    End Sub

#End Region

#Region "ResizeBegin"

    Private Sub frm_ResizeBegin(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.ResizeBegin
        Me.Opacity = vp_Opacity
    End Sub

#End Region

#Region "ResizeEnd"

    Private Sub frm_ResizeEnd(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.ResizeEnd
        Dim opacity As Double = Convert.ToDouble(100)
        Me.Opacity = opacity
    End Sub

#End Region

#Region "DoubleClick"

    Private Sub lstLISTADO_DOCUMENTOS_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles lstLISTADO_DOCUMENTOS.DoubleClick

        Try
            If lstLISTADO_DOCUMENTOS.SelectedIndex <> -1 Then

                Dim stArchivo As String = lstLISTADO_DOCUMENTOS.SelectedItem
                Process.Start(vl_stRutaDocumentos & "\" & stArchivo)

            Else

                If lstLISTADO_DOCUMENTOS.Items.Count > 0 Then
                    MessageBox.Show("Seleccione un archivo de la lista", "mensaje...", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                End If

            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try
    End Sub

#End Region

#End Region

End Class