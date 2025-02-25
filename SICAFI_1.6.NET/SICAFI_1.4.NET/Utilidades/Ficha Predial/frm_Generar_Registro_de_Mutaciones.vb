Imports REGLAS_DEL_NEGOCIO
Imports System
Imports System.IO
Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration
Imports System.Text

Public Class frm_Generar_Registro_de_Mutaciones

    '======================================
    '*** GENERAR REGISTRO DE MUTACIONES ***
    '======================================

#Region "INSTANCIAR FORMULARIO"

    Private Shared frm_Instance = Nothing

    Public Shared Function instance() As frm_Generar_Registro_de_Mutaciones
        If frm_Instance Is Nothing OrElse frm_Instance.isdisposed = True Then
            frm_Instance = New frm_Generar_Registro_de_Mutaciones
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

#Region "VARIABLES LOCALES"

    Private oLeer As New OpenFileDialog

    ' otros procesos
    Private stRutaArchivo As String
    Private inTotalRegistros As Integer
    Private inProceso As Integer

    ' variables de conexion
    Private oEjecutar As New SqlCommand
    Private oConexion As New SqlConnection
    Private oAdapter As New SqlDataAdapter
    Private oReader As SqlDataReader
    Private ds As New DataSet
    Private dt As New DataTable

    Private stCarpetaDestino As String = ""

#End Region

#Region "FUNCIONES"

    Private Function fun_ExisteArchivoMutaciones(ByVal stRutaCaperta As String) As Boolean

        Try
            Dim boExisteArchivo As Boolean = False

            Dim ContadorDeArchivos = My.Computer.FileSystem.GetFiles(Trim(stRutaCaperta))

            If ContadorDeArchivos.Count > 0 Then
                boExisteArchivo = True
            End If

            Return boExisteArchivo

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Function
    Private Function fun_ContarDiasDelMes(ByVal inVigencia As Integer, ByVal inMes As Integer) As Integer

        Try
            Dim dateNow As DateTime = DateTime.Now

            Dim inNroDias As Integer = DateTime.DaysInMonth(inVigencia, inMes)

            Return inNroDias

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Function

#End Region

#Region "PROCEDIMIENTOS"

    Private Sub pro_InicialComponenetes()

        Try
            Dim objdatos As New cla_REGIMUTA

            Me.BindingSource_REGIMUTA_1.DataSource = objdatos.fun_Consultar_REGIMUTA

            Me.dgvREGIMUTA_1.DataSource = BindingSource_REGIMUTA_1
            Me.BindingNavigator_REGIMUTA_1.BindingSource = BindingSource_REGIMUTA_1

            '=================================================
            '*** CONFIGURA OBJETOS DEL FORMULARIO MAESTRO ***
            '=================================================

            Me.strBARRESTA.Items(2).Text = "Registros : " & Me.BindingSource_REGIMUTA_1.Count

            Me.dgvREGIMUTA_1.Columns("REMUIDRE").HeaderText = "Id"
            Me.dgvREGIMUTA_1.Columns("REMUSECU").HeaderText = "Nro. Secuencia"

            Me.dgvREGIMUTA_1.Columns("REMUVIGE").HeaderText = "Vigencia"
            Me.dgvREGIMUTA_1.Columns("PERIDESC").HeaderText = "Mes"
            Me.dgvREGIMUTA_1.Columns("REMUFEIN").HeaderText = "Fecha Ingreso"
            Me.dgvREGIMUTA_1.Columns("REMUFEAS").HeaderText = "Fecha Asignación"
            Me.dgvREGIMUTA_1.Columns("REMUFEFI").HeaderText = "Fecha Finalización"
            Me.dgvREGIMUTA_1.Columns("REMUUSUA").HeaderText = "Usuario"
            Me.dgvREGIMUTA_1.Columns("ESTADESC").HeaderText = "Estado"

            Me.dgvREGIMUTA_1.Columns("REMUIDRE").Visible = False
            Me.dgvREGIMUTA_1.Columns("REMUMES").Visible = False
            Me.dgvREGIMUTA_1.Columns("REMUNUPR").Visible = False
            Me.dgvREGIMUTA_1.Columns("REMUNUAR").Visible = False
            Me.dgvREGIMUTA_1.Columns("REMUNUDO").Visible = False
            Me.dgvREGIMUTA_1.Columns("REMUOBSE").Visible = False

            If Me.dgvREGIMUTA_1.RowCount = 0 Then
                Me.cmdCarpetaDestino.Enabled = False
            Else
                Me.cmdCarpetaDestino.Enabled = True
            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub pro_LimpiarCampos()

        Me.lblRutaArchivo.Text = ""

        Me.cmdEjecutar.Enabled = False

        Me.strBARRESTA.Items(2).Text = "Registro : 0"

    End Sub

#End Region

#Region "MENU"

    Private Sub cmdEjecutar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdEjecutar.Click

        Try
            ' declara la variable
            Dim inVigencia As Integer = CInt(Me.dgvREGIMUTA_1.SelectedRows.Item(0).Cells("REMUVIGE").Value.ToString)
            Dim inMes As Integer = CInt(Me.dgvREGIMUTA_1.SelectedRows.Item(0).Cells("REMUMES").Value.ToString)
            Dim inIdRegistro As Integer = CInt(Me.dgvREGIMUTA_1.SelectedRows.Item(0).Cells("REMUIDRE").Value.ToString)
            Dim inSecuencia As Integer = CInt(Me.dgvREGIMUTA_1.SelectedRows.Item(0).Cells("REMUSECU").Value.ToString)
            Dim inCatidadDiasDelMes As Integer = CInt(fun_ContarDiasDelMes(inVigencia, inMes))
            Dim inNroRegistros As Integer = 0
          
            ' instancia la clase
            Dim obMUTACIONES As New cla_MUTACIONES
            Dim dtMUTACIONES As New DataTable

            dtMUTACIONES = obMUTACIONES.fun_Consultar_Parametros_X_MUTACIONES(inVigencia, fun_Formato_Mascara_2_String(inMes), inCatidadDiasDelMes)

            ' verifica registros
            If dtMUTACIONES.Rows.Count > 0 Then

                ' Valores predeterminados ProgressBar
                inProceso = 0
                Me.pbPROCESO.Value = 0
                Me.pbPROCESO.Maximum = dtMUTACIONES.Rows.Count + 1
                Me.Timer1.Enabled = True

                ' declara la variable
                Dim i As Integer = 0

                For i = 0 To dtMUTACIONES.Rows.Count - 1

                    ' declaro la variable
                    Dim stMUTADEPA As String = Trim(dtMUTACIONES.Rows(i).Item("MUTADEPA").ToString)
                    Dim stMUTAMUNI As String = Trim(dtMUTACIONES.Rows(i).Item("MUTAMUNI").ToString)
                    Dim stMUTACLSE As String = Trim(dtMUTACIONES.Rows(i).Item("MUTACLSE").ToString)
                    Dim stMUTACORR As String = Trim(dtMUTACIONES.Rows(i).Item("MUTACORR").ToString)
                    Dim stMUTABARR As String = Trim(dtMUTACIONES.Rows(i).Item("MUTABARR").ToString)
                    Dim stMUTAMANZ As String = Trim(dtMUTACIONES.Rows(i).Item("MUTAMANZ").ToString)
                    Dim stMUTAPRED As String = Trim(dtMUTACIONES.Rows(i).Item("MUTAPRED").ToString)
                    Dim stMUTAEDIF As String = Trim(dtMUTACIONES.Rows(i).Item("MUTAEDIF").ToString)
                    Dim stMUTAUNPR As String = Trim(dtMUTACIONES.Rows(i).Item("MUTAUNPR").ToString)
                    Dim stMUTAVIGE As String = Trim(dtMUTACIONES.Rows(i).Item("MUTAVIGE").ToString)
                    Dim stMUTANUFI As String = Trim(dtMUTACIONES.Rows(i).Item("MUTANUFI").ToString)
                    Dim stMUTAMAIN As String = Trim(dtMUTACIONES.Rows(i).Item("MUTAMAIN").ToString)
                    Dim stMUTAESCR As String = Trim(dtMUTACIONES.Rows(i).Item("MUTAESCR").ToString)
                    Dim stMUTAFEES As String = Trim(dtMUTACIONES.Rows(i).Item("MUTAFEES").ToString)

                    Dim boExisteCarpeta As Boolean = False
                    Dim boExisteArchivo As Boolean = False

                    ' instancia la clase
                    Dim objRutas As New cla_RUTAS
                    Dim tblRutas As New DataTable

                    ' ruta de mutaciones
                    tblRutas = objRutas.fun_Buscar_CODIGO_MANT_RUTAS(7)

                    If tblRutas.Rows.Count > 0 Then

                        ' declara la variable
                        Dim stRutaMutaciones As String = Trim(tblRutas.Rows(0).Item("RUTARUTA"))
                        Dim stNombreCarpeta As String = stMUTAMUNI & "-" & stMUTACLSE & "-" & stMUTACORR & "-" & stMUTABARR & "-" & stMUTAMANZ & "-" & stMUTAPRED & "-" & stMUTAEDIF & "-" & stMUTAUNPR & "-" & stMUTAVIGE

                        ' verifica exisencia de carpeta 
                        If System.IO.Directory.Exists(Trim(stRutaMutaciones) & "\" & stNombreCarpeta) = True Then

                            boExisteArchivo = fun_ExisteArchivoMutaciones(Trim(stRutaMutaciones) & "\" & stNombreCarpeta)

                            ' existe archivo en carpeta
                            If boExisteArchivo = True Then

                                ' instancia la clase
                                Dim objRutas1 As New cla_RUTAS
                                Dim tblRutas1 As New DataTable

                                ' ruta de registro mutaciones
                                tblRutas1 = objRutas1.fun_Buscar_CODIGO_MANT_RUTAS(15)

                                If tblRutas1.Rows.Count > 0 Then

                                    ' declara la variable
                                    Dim stRutaRegistroMutaciones As String = Trim(tblRutas1.Rows(0).Item("RUTARUTA"))

                                    ' verifica exisencia de carpeta 
                                    If System.IO.Directory.Exists(Trim(stRutaRegistroMutaciones) & "\" & inMes & "-" & inVigencia) = False Then

                                        ' crea la carpeta en registro mutaciones
                                        System.IO.Directory.CreateDirectory(Trim(stRutaRegistroMutaciones) & "\" & inMes & "-" & inVigencia)

                                        ' realiza copia de carpeta y archivos en ruta seleccionada
                                        My.Computer.FileSystem.CopyDirectory(Trim(stRutaMutaciones) & "\" & stNombreCarpeta, Trim(stCarpetaDestino) & "\" & inMes & "-" & inVigencia & "\" & stNombreCarpeta, True)

                                    Else
                                        ' realiza copia de carpeta y archivos en ruta seleccionada
                                        My.Computer.FileSystem.CopyDirectory(Trim(stRutaMutaciones) & "\" & stNombreCarpeta, Trim(stCarpetaDestino) & "\" & inMes & "-" & inVigencia & "\" & stNombreCarpeta, True)

                                    End If

                                End If

                            End If

                        End If

                    End If

                    ' Incrementa la barra
                    inProceso = inProceso + 1
                    Me.pbPROCESO.Value = inProceso

                Next

                ' inicia la barra de progreso
                Me.pbPROCESO.Value = 0

                mod_MENSAJE.Proceso_Termino_Correctamente()

            Else
                mod_MENSAJE.No_Se_Encontro_Ningun_registro()
            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub cmdRuraArchivo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCarpetaDestino.Click

        Try
            Dim oCarpetas As New FolderBrowserDialog
            Dim stNewPath As String = ""

            oCarpetas.ShowDialog()
            stNewPath = oCarpetas.SelectedPath

            stCarpetaDestino = stNewPath

            If Trim(stCarpetaDestino) <> "" Then
                Me.lblRutaArchivo.Text = stCarpetaDestino
            Else
                Me.lblRutaArchivo.Text = ""
            End If

            If Me.lblRutaArchivo.Text = "" Then
                Me.cmdEjecutar.Enabled = False
            Else
                Me.cmdEjecutar.Enabled = True
            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub cmdReconsultar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdReconsultar.Click
        pro_InicialComponenetes()
    End Sub
    Private Sub cmdSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSalir.Click
        Me.Close()
    End Sub
    Private Sub cmdLimpiar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdLimpiar.Click
        pro_LimpiarCampos()
    End Sub

#End Region

#Region "FORMULARIO"

#Region "Load"

    Private Sub frm_Generar_Registro_de_Mutaciones_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        pro_InicialComponenetes()
        Me.strBARRESTA.Items(0).Text = "Generar mutaciones"
    End Sub

#End Region

#End Region

End Class