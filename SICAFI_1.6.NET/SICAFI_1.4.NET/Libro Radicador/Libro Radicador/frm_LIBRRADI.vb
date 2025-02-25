Imports REGLAS_DEL_NEGOCIO
Imports System
Imports System.IO
Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration
Imports System.Text

Public Class frm_LIBRRADI

    '=======================
    '*** LIBRO RADICADOR ***
    '=======================

#Region "VARIABLES"

    Dim boCONSULTA As Boolean = False

    Dim vl_stRutaDocumentos As String = ""
    Dim vl_stRutaImagenes As String = ""
    Dim vl_stRutaResolucion As String = ""

    Private oEjecutar As New SqlCommand
    Private oConexion As New SqlConnection
    Private oAdapter As New SqlDataAdapter
    Private oReader As SqlDataReader
    Private ds As New DataSet
    Private dt As New DataTable

#End Region

#Region "INSTANCIAR FORMULARIO"

    Private Shared frm_Instance = Nothing

    Public Shared Function instance() As frm_LIBRRADI
        If frm_Instance Is Nothing OrElse frm_Instance.isdisposed = True Then
            frm_Instance = New frm_LIBRRADI
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

#Region "CONSTRUCTOR"

    Public Sub New(ByVal idCodigo As Integer)

        vp_inConsulta = idCodigo
        InitializeComponent()

    End Sub

#End Region

#Region "FUNCIONES"

    Private Function fun_VerificarCarpetaExistenteDocumentos() As Boolean

        Try
            Dim stRuta As String = ""
            Dim stCarpetaABuscar As String = ""

            ' instancia la clase
            Dim objRutas As New cla_RUTAS
            Dim tblRutas As New DataTable

            tblRutas = objRutas.fun_Buscar_CODIGO_MANT_RUTAS(17)

            If tblRutas.Rows.Count > 0 Then

                ' directorio pricipal
                stRuta = Trim(tblRutas.Rows(0).Item("RUTARUTA")) & "\"

                ' directorio expediente 
                stCarpetaABuscar = Trim(Me.dgvLIBRRADI_1.SelectedRows.Item(0).Cells("LIRANURA").Value.ToString) & "-" & _
                                   Trim(Me.dgvLIBRRADI_1.SelectedRows.Item(0).Cells("LIRAFERA").Value.ToString)

                Dim Ruta As New DirectoryInfo(stRuta)

                Dim TodasLasCarpetas(), CarpetaABuscar As DirectoryInfo

                ' declara la variable 
                Dim sw As Byte = 1

                TodasLasCarpetas = Ruta.GetDirectories()

                ' recorre el directorio
                For Each CarpetaABuscar In TodasLasCarpetas

                    If CarpetaABuscar.FullName = Ruta.FullName & stCarpetaABuscar Then
                        sw = 0

                        If sw = 0 Then
                            Exit For
                        End If

                    End If

                Next

                ' retorna la respuesta
                If sw = 1 Then
                    Return False
                Else
                    Return True
                End If

            Else
                Return False
            End If

        Catch ex As Exception
            Return False
        End Try

    End Function

#End Region

#Region "PROCEDIMIENTOS LIBRO RADICADOR"

    Private Sub pro_ReconsultarLibroRadicador()

        Try
            Dim objdatos As New cla_LIBRRADI

            If boCONSULTA = False Then
                Me.BindingSource_LIBRRADI_1.DataSource = objdatos.fun_Consultar_LIBRRADI
            Else
                Me.BindingSource_LIBRRADI_1.DataSource = objdatos.fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_LIBRRADI(vp_inConsulta)
            End If

            Me.dgvLIBRRADI_1.DataSource = BindingSource_LIBRRADI_1
            Me.dgvLIBRRADI_2.DataSource = BindingSource_LIBRRADI_1
            Me.BindingNavigator_LIBRRADI_1.BindingSource = BindingSource_LIBRRADI_1

            '=================================================
            '*** CONFIGURA OBJETOS DEL FORMULARIO MAESTRO ***
            '=================================================

            Me.strBARRESTA.Items(2).Text = "Registros : " & Me.BindingSource_LIBRRADI_1.Count

            Me.dgvLIBRRADI_1.Columns("ACADDESC").HeaderText = "Clasificación"
            Me.dgvLIBRRADI_1.Columns("MEREDESC").HeaderText = "Medio de Recepción"
            Me.dgvLIBRRADI_1.Columns("LIRANURA").HeaderText = "Nro. Radicado"
            Me.dgvLIBRRADI_1.Columns("LIRAFERA").HeaderText = "Fecha de Radicado"
            Me.dgvLIBRRADI_1.Columns("LIRAFEAS").HeaderText = "Fecha de Asignación"
            Me.dgvLIBRRADI_1.Columns("LIRAFEFI").HeaderText = "Fecha de Finalización"
            Me.dgvLIBRRADI_1.Columns("LIRAASUN").HeaderText = "Asunto"

            Me.dgvLIBRRADI_1.Columns("LIRAIDRE").Visible = False
            Me.dgvLIBRRADI_1.Columns("LIRASECU").Visible = False
            Me.dgvLIBRRADI_1.Columns("LIRAACAD").Visible = False
            Me.dgvLIBRRADI_1.Columns("LIRAMERE").Visible = False
            Me.dgvLIBRRADI_1.Columns("LIRAESTA").Visible = False
            Me.dgvLIBRRADI_1.Columns("LIRADIVI").Visible = False
            Me.dgvLIBRRADI_1.Columns("LIRAMENO").Visible = False
            Me.dgvLIBRRADI_1.Columns("LIRAFEMN").Visible = False
            Me.dgvLIBRRADI_1.Columns("LIRADIVI").Visible = False
            Me.dgvLIBRRADI_1.Columns("DIVIDESC").Visible = False
            Me.dgvLIBRRADI_1.Columns("LIRAFEIN").Visible = False
            Me.dgvLIBRRADI_1.Columns("LIRAVIGE").Visible = False
            Me.dgvLIBRRADI_1.Columns("LIRAOBSE").Visible = False
            Me.dgvLIBRRADI_1.Columns("MENODESC").Visible = False
            Me.dgvLIBRRADI_1.Columns("LIRANUDO").Visible = False
            Me.dgvLIBRRADI_1.Columns("LIRAUSUA").Visible = False
            Me.dgvLIBRRADI_1.Columns("LIRAOFSA").Visible = False
            Me.dgvLIBRRADI_1.Columns("ESTADESC").Visible = False

            Me.dgvLIBRRADI_2.Columns("MENODESC").HeaderText = "Medio de Notificación"
            Me.dgvLIBRRADI_2.Columns("LIRAFEMN").HeaderText = "Fecha de Notificación"
            Me.dgvLIBRRADI_2.Columns("DIVIDESC").HeaderText = "División"
            Me.dgvLIBRRADI_2.Columns("LIRAUSUA").HeaderText = "Usuario"
            Me.dgvLIBRRADI_2.Columns("LIRAFEIN").HeaderText = "Fecha de Ingreso"
            Me.dgvLIBRRADI_2.Columns("LIRAVIGE").HeaderText = "Vigencia"
            Me.dgvLIBRRADI_2.Columns("LIRAOFSA").HeaderText = "Oficio de Salida"
            Me.dgvLIBRRADI_2.Columns("ESTADESC").HeaderText = "Estado"

            Me.dgvLIBRRADI_2.Columns("LIRAIDRE").Visible = False
            Me.dgvLIBRRADI_2.Columns("LIRASECU").Visible = False
            Me.dgvLIBRRADI_2.Columns("LIRAACAD").Visible = False
            Me.dgvLIBRRADI_2.Columns("LIRAMERE").Visible = False
            Me.dgvLIBRRADI_2.Columns("LIRANURA").Visible = False
            Me.dgvLIBRRADI_2.Columns("LIRAFERA").Visible = False
            Me.dgvLIBRRADI_2.Columns("LIRAASUN").Visible = False
            Me.dgvLIBRRADI_2.Columns("LIRADIVI").Visible = False
            Me.dgvLIBRRADI_2.Columns("LIRAOBSE").Visible = False
            Me.dgvLIBRRADI_2.Columns("LIRAESTA").Visible = False
            Me.dgvLIBRRADI_2.Columns("ACADDESC").Visible = False
            Me.dgvLIBRRADI_2.Columns("MEREDESC").Visible = False
            Me.dgvLIBRRADI_2.Columns("LIRAMENO").Visible = False
            Me.dgvLIBRRADI_2.Columns("LIRANUDO").Visible = False
            Me.dgvLIBRRADI_2.Columns("LIRAFEAS").Visible = False
            Me.dgvLIBRRADI_2.Columns("LIRAFEFI").Visible = False

            Me.dgvLIBRRADI_2.Columns("LIRAOFSA").Width = 130
            Me.dgvLIBRRADI_2.Columns("LIRAUSUA").Width = 130
            Me.dgvLIBRRADI_1.Columns("LIRAASUN").Width = 300
            Me.dgvLIBRRADI_2.Columns("DIVIDESC").Width = 170

            '==================================================
            '*** ASIGNA LOS PRIVILEGIOS DE LA BARRA DE MENU ***
            '==================================================

            Dim ContarRegistros As Integer = Me.BindingSource_LIBRRADI_1.Count

            Dim boCONTAGRE As Boolean = False
            Dim boCONTMODI As Boolean = False
            Dim boCONTELIM As Boolean = False
            Dim boCONTCONS As Boolean = False
            Dim boCONTRECO As Boolean = False

            pro_Permiso_Barra_De_Menu_Formulario_SubFormulario(ContarRegistros, Trim(Me.BindingNavigator_LIBRRADI_1.Name), boCONTAGRE, boCONTMODI, boCONTELIM, boCONTCONS, boCONTRECO)

            Me.cmdAGREGAR_LIBRRADI.Enabled = boCONTAGRE
            Me.cmdMODIFICAR_LIBRRADI.Enabled = boCONTMODI
            Me.cmdELIMINAR_LIBRRADI.Enabled = boCONTELIM
            Me.cmdCONSULTAR_LIBRRADI.Enabled = True
            Me.cmdRECONSULTAR_LIBRRADI.Enabled = boCONTRECO

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub pro_ListaDeValoresLibroRadicador()

        Try
            If Me.dgvLIBRRADI_1.RowCount > 0 Then

                Dim objdatos As New cla_LIBRRADI
                Dim tbldatos As New DataTable

                tbldatos = objdatos.fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_LIBRRADI(CInt(Me.dgvLIBRRADI_1.SelectedRows.Item(0).Cells("LIRAIDRE").Value.ToString()))

                If tbldatos.Rows.Count > 0 Then
                    Me.txtLIRAOBSE.Text = Trim(tbldatos.Rows(0).Item("LIRAOBSE").ToString)
                End If

                pro_ReconsultarSolicitante()
                pro_ListaDeValoresSolicitante()

                pro_ReconsultarPredio()
                pro_ListaDeValoresPredio()

                pro_ReconsultarDestinatarioDivision()
                pro_ListaDeValoresDestinatarioDivision()

                pro_ReconsultarDestinatarioFuncionario()
                pro_ListaDeValoresDestinatarioFuncionario()

                pro_ListadoArchivosDocumentos()
                pro_ControldeBindingNavigatorPorusuario()
                pro_OperarBotonFinalizar()

            Else
                pro_LimpiarCamposLibroRadicador()
                pro_LimpiarCamposSolicitante()
                pro_LimpiarCamposPredio()
                pro_LimpiarCamposDestinatarioDivision()
                pro_LimpiarCamposDestinatarioFuncionario()

                Me.BindingNavigator_LIRASOLI_1.Enabled = False
                Me.BindingNavigator_LIRAPRED_1.Enabled = False
                Me.BindingNavigator_LIRADEDI_1.Enabled = False
                Me.BindingNavigator_LIRADEFU_1.Enabled = False

            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub pro_ControldeBindingNavigatorPorusuario()

        If Me.dgvLIBRRADI_1.RowCount > 0 Then
            If Trim(Me.dgvLIBRRADI_1.SelectedRows.Item(0).Cells("LIRAUSUA").Value.ToString()) = Trim(vp_usuario) Then

                Me.BindingNavigator_LIBRRADI_1.Enabled = True
                Me.BindingNavigator_LIRASOLI_1.Enabled = True
                Me.BindingNavigator_LIRAPRED_1.Enabled = True
                Me.BindingNavigator_LIRADEDI_1.Enabled = True
                Me.BindingNavigator_LIRADEFU_1.Enabled = True

            Else

                'Me.cmdAGREGAR_LIBRRADI.Enabled = False
                Me.cmdMODIFICAR_LIBRRADI.Enabled = False
                Me.cmdELIMINAR_LIBRRADI.Enabled = False
                Me.cmdCONSULTAR_LIBRRADI.Enabled = True
                Me.cmdRECONSULTAR_LIBRRADI.Enabled = True

                Me.BindingNavigator_LIRASOLI_1.Enabled = False
                Me.BindingNavigator_LIRAPRED_1.Enabled = False
                Me.BindingNavigator_LIRADEDI_1.Enabled = False
                Me.BindingNavigator_LIRADEFU_1.Enabled = False

            End If
        End If

    End Sub
    Private Sub pro_LimpiarCamposLibroRadicador()

        Me.strBARRESTA.Items(2).Text = "Registros : 0"

    End Sub

    Private Sub pro_EjecutarBotonObservaciones()

        Try
            If Me.dgvLIBRRADI_1.RowCount > 0 Then

                If MessageBox.Show("¿ Desea ingresar una observación ? ", "Mensaje...", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then

                    Dim stObservacionNueva As String = InputBox("Ingrese la observación.", "Mensaje")

                    If Trim(stObservacionNueva) = "" Then
                        MessageBox.Show("Se requiere una observación.", "Mensaje...", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                        mod_MENSAJE.No_Se_Modifico_El_Registro_En_La_Base_De_Datos()
                    Else

                        Dim stREMUOBSE_ACTUAL As String = ""
                        Dim stREMUOBSE_NUEVA As String = Trim(stObservacionNueva.ToString.ToUpper)

                        Dim obMOGEGEOG As New cla_LIBRRADI
                        Dim dtAJUSGEOG As New DataTable

                        dtAJUSGEOG = obMOGEGEOG.fun_Buscar_ID_LIBRRADI(Me.dgvLIBRRADI_1.SelectedRows.Item(0).Cells("LIRAIDRE").Value.ToString())

                        If dtAJUSGEOG.Rows.Count > 0 Then
                            stREMUOBSE_ACTUAL = Trim(dtAJUSGEOG.Rows(0).Item("LIRAOBSE").ToString)
                        End If

                        If Trim(stREMUOBSE_ACTUAL) <> "" And Trim(stREMUOBSE_NUEVA) <> "" Then
                            stREMUOBSE_ACTUAL += vbCrLf & " Nota ingresada por " & vp_usuario & " " & fun_fecha() & " : " & stREMUOBSE_NUEVA & ". "

                        ElseIf Trim(stREMUOBSE_ACTUAL) = "" And Trim(stREMUOBSE_NUEVA) <> "" Then
                            stREMUOBSE_ACTUAL = " Nota ingresada por " & vp_usuario & " " & fun_fecha() & " : " & stREMUOBSE_NUEVA & ". "

                        End If

                        ' buscar cadena de conexion
                        Dim oCadenaConexion As New REGLAS_DEL_NEGOCIO.cla_ConnectionString
                        Dim stCadenaConexion As String = oCadenaConexion.fun_ConnectionString

                        ' crear conexión
                        oAdapter = New SqlDataAdapter
                        oConexion = New SqlConnection(stCadenaConexion)

                        ' abre la conexion
                        oConexion.Open()

                        ' variables
                        Dim inMOGEIDRE As Integer = Integer.Parse(Me.dgvLIBRRADI_1.SelectedRows.Item(0).Cells("LIRAIDRE").Value.ToString())

                        ' parametros de la consulta
                        Dim ParametrosConsulta As String = ""

                        ' Concatena la condicion de la consulta
                        ParametrosConsulta += "update LIBRRADI "
                        ParametrosConsulta += "set LIRAOBSE = '" & stREMUOBSE_ACTUAL & "' "
                        ParametrosConsulta += "where LIRAIDRE = '" & inMOGEIDRE & "' "

                        ' ejecuta la consulta
                        oEjecutar = New SqlCommand(ParametrosConsulta, oConexion)

                        ' procesa la consulta 
                        oEjecutar.CommandTimeout = 0
                        oEjecutar.CommandType = CommandType.Text

                        oReader = oEjecutar.ExecuteReader

                        Dim i As Integer = oReader.RecordsAffected

                        ' cierra la conexion
                        oConexion.Close()
                        oReader = Nothing

                        mod_MENSAJE.Se_Modificaron_Los_Datos_Correctamente()

                        vp_inConsulta = inMOGEIDRE

                        boCONSULTA = True

                        pro_ReconsultarLibroRadicador()
                        pro_ListaDeValoresLibroRadicador()

                        Me.TabMAESTRO_2.SelectTab(TabObservaciones)

                    End If

                End If
            Else
                mod_MENSAJE.No_Existe_Un_Registro_Seleccionado()
            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub pro_EjecutarBotonFinalizar()

        Try
            ' declara la variable
            Dim boUSUARIO As Boolean = False

            If Trim(Me.dgvLIBRRADI_1.SelectedRows.Item(0).Cells("LIRAESTA").Value.ToString()) = "ac" Or _
               Trim(Me.dgvLIBRRADI_1.SelectedRows.Item(0).Cells("LIRAESTA").Value.ToString()) = "as" Then

                ' declara la tabla y la variable
                Dim obLIRADEFU As New DataTable

                obLIRADEFU = Me.BindingSource_LIRADEFU_1.DataSource

                Dim i1 As Integer = 0

                For i1 = 0 To obLIRADEFU.Rows.Count - 1

                    Dim stLRDFUSUA As String = Trim(obLIRADEFU.Rows(i1).Item("LRDFUSUA").ToString)

                    If Trim(stLRDFUSUA) = Trim(vp_usuario) Then
                        boUSUARIO = True
                    End If

                Next

                ' declara la tabla 
                Dim obLIBRRADI As New DataTable

                obLIBRRADI = Me.BindingSource_LIBRRADI_1.DataSource

                Dim i2 As Integer = 0

                For i2 = 0 To obLIBRRADI.Rows.Count - 1

                    Dim stLIRAUSUA As String = Trim(obLIBRRADI.Rows(i2).Item("LIRAUSUA").ToString)

                    If Trim(stLIRAUSUA) = Trim(vp_usuario) Then
                        boUSUARIO = True
                    End If

                Next

                If Trim("ADMINISTRADOR") = Trim(vp_usuario) Then
                    boUSUARIO = True
                End If

            End If

            ' verifica el permiso de usuario
            If boUSUARIO = True Then

                If MessageBox.Show("¿ Desea finalizar el radicado Nro. " & Me.dgvLIBRRADI_1.SelectedRows.Item(0).Cells("LIRANURA").Value.ToString() & " ? ", "Mensaje...", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then

                    Dim stRECLOBSE_ACTUAL As String = ""
                    Dim stRECLOBSE_NUEVA As String = " Nota de registro: " & " El usuario: " & vp_usuario & " " & fun_fecha() & " finalizo el tramite. "

                    Dim obRECLGEOG As New cla_LIBRRADI
                    Dim dtRECLGEOG As New DataTable

                    dtRECLGEOG = obRECLGEOG.fun_Buscar_ID_LIBRRADI(Me.dgvLIBRRADI_1.SelectedRows.Item(0).Cells("LIRAIDRE").Value.ToString())

                    If dtRECLGEOG.Rows.Count > 0 Then
                        stRECLOBSE_ACTUAL = Trim(dtRECLGEOG.Rows(0).Item("LIRAOBSE").ToString)
                    End If

                    If Trim(stRECLOBSE_ACTUAL) <> "" And Trim(stRECLOBSE_NUEVA) <> "" Then
                        stRECLOBSE_ACTUAL += vbCrLf & stRECLOBSE_NUEVA & ". "

                    ElseIf Trim(stRECLOBSE_ACTUAL) = "" And Trim(stRECLOBSE_NUEVA) <> "" Then
                        stRECLOBSE_ACTUAL = stRECLOBSE_NUEVA & ". "

                    End If

                    ' buscar cadena de conexion
                    Dim oCadenaConexion As New REGLAS_DEL_NEGOCIO.cla_ConnectionString
                    Dim stCadenaConexion As String = oCadenaConexion.fun_ConnectionString

                    ' crear conexión
                    oAdapter = New SqlDataAdapter
                    oConexion = New SqlConnection(stCadenaConexion)

                    ' abre la conexion
                    oConexion.Open()

                    ' variables
                    Dim inMOGEIDRE As Integer = Integer.Parse(Me.dgvLIBRRADI_1.SelectedRows.Item(0).Cells("LIRAIDRE").Value.ToString())
                    Dim stMOGEESTA As String = "fi"

                    Dim stLIRAFEFI As String = Trim(fun_fecha())

                    ' parametros de la consulta
                    Dim ParametrosConsulta As String = ""

                    ' Concatena la condicion de la consulta
                    ParametrosConsulta += "Update LIBRRADI "
                    ParametrosConsulta += "Set LIRAESTA = '" & stMOGEESTA & "', "
                    ParametrosConsulta += "LIRAFEFI = '" & stLIRAFEFI & "', "
                    ParametrosConsulta += "LIRAOBSE = '" & stRECLOBSE_ACTUAL & "' "
                    ParametrosConsulta += "where LIRAIDRE = '" & inMOGEIDRE & "' "

                    ' ejecuta la consulta
                    oEjecutar = New SqlCommand(ParametrosConsulta, oConexion)

                    ' procesa la consulta 
                    oEjecutar.CommandTimeout = 0
                    oEjecutar.CommandType = CommandType.Text

                    oReader = oEjecutar.ExecuteReader

                    Dim ii As Integer = oReader.RecordsAffected

                    ' cierra la conexion
                    oConexion.Close()
                    oReader = Nothing

                    mod_MENSAJE.Se_Modificaron_Los_Datos_Correctamente()

                    boCONSULTA = True

                    vp_inConsulta = Me.dgvLIBRRADI_1.SelectedRows.Item(0).Cells("LIRAIDRE").Value.ToString()

                    pro_ReconsultarLibroRadicador()
                    pro_ListaDeValoresLibroRadicador()

                End If

            Else
                mod_MENSAJE.Usuario_No_Tiene_Permiso_Para_Realizar_La_Operacion()
            End If


        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub pro_OperarBotonFinalizar()

        Try
            ' declara la variable
            Dim boUSUARIO As Boolean = False

            If Trim(Me.dgvLIBRRADI_1.SelectedRows.Item(0).Cells("LIRAESTA").Value.ToString()) = "ac" Then

                ' declara la tabla y la variable
                Dim obLIRADEFU As New DataTable

                obLIRADEFU = Me.BindingSource_LIRADEFU_1.DataSource

                Dim i1 As Integer = 0

                For i1 = 0 To obLIRADEFU.Rows.Count - 1

                    Dim stLRDFUSUA As String = Trim(obLIRADEFU.Rows(i1).Item("LRDFUSUA").ToString)

                    If Trim(stLRDFUSUA) = Trim(vp_usuario) Then
                        boUSUARIO = True
                    End If

                Next

                ' declara la tabla 
                Dim obLIBRRADI As New DataTable

                obLIBRRADI = Me.BindingSource_LIBRRADI_1.DataSource

                Dim i2 As Integer = 0

                For i2 = 0 To obLIBRRADI.Rows.Count - 1

                    Dim stLIRAUSUA As String = Trim(obLIBRRADI.Rows(i2).Item("LIRAUSUA").ToString)

                    If Trim(stLIRAUSUA) = Trim(vp_usuario) Then
                        boUSUARIO = True
                    End If

                Next

            End If

            Me.cmdFinalizar.Enabled = boUSUARIO

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub

#End Region

#Region "PROCEDIMIENTO SOLICITANTE"

    Private Sub pro_ReconsultarSolicitante()

        Try
            Dim objdatos As New cla_LIRASOLI

            If boCONSULTA = False Then
                Me.BindingSource_LIRASOLI_1.DataSource = objdatos.fun_Buscar_SECU_X_CONSULTA_PARAMETRIZADA_LIRASOLI(Me.dgvLIBRRADI_1.SelectedRows.Item(0).Cells("LIRASECU").Value.ToString())
            Else
                Me.BindingSource_LIRASOLI_1.DataSource = objdatos.fun_Buscar_SECU_X_CONSULTA_PARAMETRIZADA_LIRASOLI(Me.dgvLIBRRADI_1.SelectedRows.Item(0).Cells("LIRASECU").Value.ToString())
            End If

            Me.dgvLIRASOLI_1.DataSource = BindingSource_LIRASOLI_1
            Me.dgvLIRASOLI_2.DataSource = BindingSource_LIRASOLI_1
            Me.BindingNavigator_LIRASOLI_1.BindingSource = BindingSource_LIRASOLI_1

            '=================================================
            '*** CONFIGURA OBJETOS DEL FORMULARIO MAESTRO ***
            '=================================================

            Me.strBARRESTA.Items(2).Text = "Registros : " & Me.BindingSource_LIBRRADI_1.Count

            Me.dgvLIRASOLI_1.Columns("SOLIDESC").HeaderText = "Solicitante"
            Me.dgvLIRASOLI_1.Columns("LRSONUDO").HeaderText = "Nro. Documento"
            Me.dgvLIRASOLI_1.Columns("LRSONOMB").HeaderText = "Nombre(s)"
            Me.dgvLIRASOLI_1.Columns("LRSOPRAP").HeaderText = "Primer apellido"
            Me.dgvLIRASOLI_1.Columns("LRSOSEAP").HeaderText = "Segundo apellido"
            Me.dgvLIRASOLI_1.Columns("LRSODIPR").HeaderText = "Dirección del predio"

            Me.dgvLIRASOLI_1.Columns("LRSOIDRE").Visible = False
            Me.dgvLIRASOLI_1.Columns("LRSODINO").Visible = False
            Me.dgvLIRASOLI_1.Columns("LRSOTELE").Visible = False
            Me.dgvLIRASOLI_1.Columns("LRSOCELU").Visible = False
            Me.dgvLIRASOLI_1.Columns("LRSOCOEL").Visible = False
            Me.dgvLIRASOLI_1.Columns("LRSOCOPO").Visible = False
            Me.dgvLIRASOLI_1.Columns("LRSORESO").Visible = False
            Me.dgvLIRASOLI_1.Columns("LRSONURA").Visible = False
            Me.dgvLIRASOLI_1.Columns("LRSOFERA").Visible = False
            Me.dgvLIRASOLI_1.Columns("LRSOSECU").Visible = False

            Me.dgvLIRASOLI_2.Columns("LRSODINO").HeaderText = "Dirección de notificación"
            Me.dgvLIRASOLI_2.Columns("LRSOTELE").HeaderText = "Telefono"
            Me.dgvLIRASOLI_2.Columns("LRSOCELU").HeaderText = "Celular"
            Me.dgvLIRASOLI_2.Columns("LRSOCOEL").HeaderText = "Correo electronico"
            Me.dgvLIRASOLI_2.Columns("LRSOCOPO").HeaderText = "Código postal"
            Me.dgvLIRASOLI_2.Columns("LRSORESO").HeaderText = "Redes sociales"

            Me.dgvLIRASOLI_2.Columns("LRSOIDRE").Visible = False
            Me.dgvLIRASOLI_2.Columns("LRSONUDO").Visible = False
            Me.dgvLIRASOLI_2.Columns("LRSONOMB").Visible = False
            Me.dgvLIRASOLI_2.Columns("LRSOPRAP").Visible = False
            Me.dgvLIRASOLI_2.Columns("LRSOSEAP").Visible = False
            Me.dgvLIRASOLI_2.Columns("LRSODIPR").Visible = False
            Me.dgvLIRASOLI_2.Columns("LRSONURA").Visible = False
            Me.dgvLIRASOLI_2.Columns("LRSOFERA").Visible = False
            Me.dgvLIRASOLI_2.Columns("LRSOSECU").Visible = False
            Me.dgvLIRASOLI_2.Columns("SOLIDESC").Visible = False

            Me.dgvLIRASOLI_1.Columns("LRSODIPR").Width = 300
            Me.dgvLIRASOLI_2.Columns("LRSODINO").Width = 300
           
            '==================================================
            '*** ASIGNA LOS PRIVILEGIOS DE LA BARRA DE MENU ***
            '==================================================

            Dim ContarRegistros As Integer = Me.BindingSource_LIRASOLI_1.Count

            Dim boCONTAGRE As Boolean = False
            Dim boCONTMODI As Boolean = False
            Dim boCONTELIM As Boolean = False
            Dim boCONTCONS As Boolean = False
            Dim boCONTRECO As Boolean = False

            pro_Permiso_Barra_De_Menu_Formulario_SubFormulario(ContarRegistros, Trim(Me.BindingNavigator_LIRASOLI_1.Name), boCONTAGRE, boCONTMODI, boCONTELIM, boCONTCONS, boCONTRECO)

            Me.cmdAGREGAR_LIRASOLI.Enabled = boCONTAGRE
            Me.cmdMODIFICAR_LIRASOLI.Enabled = boCONTMODI
            Me.cmdELIMINAR_LIRASOLI.Enabled = boCONTELIM
            Me.cmdCONSULTAR_LIRASOLI.Enabled = boCONTCONS
            Me.cmdRECONSULTAR_LIRASOLI.Enabled = boCONTRECO

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub pro_ListaDeValoresSolicitante()

    End Sub
    Private Sub pro_LimpiarCamposSolicitante()

        Me.dgvLIRASOLI_1.DataSource = New DataTable
        Me.dgvLIRASOLI_2.DataSource = New DataTable

    End Sub

#End Region

#Region "PROCEDIMIENTO PREDIO"

    Private Sub pro_ReconsultarPredio()

        Try
            Dim objdatos As New cla_LIRAPRED

            If boCONSULTA = False Then
                Me.BindingSource_LIRAPRED_1.DataSource = objdatos.fun_Buscar_SECU_X_CONSULTA_PARAMETRIZADA_LIRAPRED(Me.dgvLIBRRADI_1.SelectedRows.Item(0).Cells("LIRASECU").Value.ToString())
            Else
                Me.BindingSource_LIRAPRED_1.DataSource = objdatos.fun_Buscar_SECU_X_CONSULTA_PARAMETRIZADA_LIRAPRED(Me.dgvLIBRRADI_1.SelectedRows.Item(0).Cells("LIRASECU").Value.ToString())
            End If

            Me.dgvLIRAPRED.DataSource = BindingSource_LIRAPRED_1
            Me.BindingNavigator_LIRAPRED_1.BindingSource = BindingSource_LIRAPRED_1

            '=================================================
            '*** CONFIGURA OBJETOS DEL FORMULARIO MAESTRO ***
            '=================================================

            Me.strBARRESTA.Items(2).Text = "Registros : " & Me.BindingSource_LIBRRADI_1.Count

            Me.dgvLIRAPRED.Columns("LRPRMUNI").HeaderText = "Municipio"
            Me.dgvLIRAPRED.Columns("LRPRCORR").HeaderText = "Corregimiento"
            Me.dgvLIRAPRED.Columns("LRPRBARR").HeaderText = "Barrio"
            Me.dgvLIRAPRED.Columns("LRPRMANZ").HeaderText = "Manzana Vereda"
            Me.dgvLIRAPRED.Columns("LRPRPRED").HeaderText = "Predio"
            Me.dgvLIRAPRED.Columns("LRPREDIF").HeaderText = "Edificio"
            Me.dgvLIRAPRED.Columns("LRPRUNPR").HeaderText = "Unidad Predial"
            Me.dgvLIRAPRED.Columns("CLSEDESC").HeaderText = "Sector"
            Me.dgvLIRAPRED.Columns("LRPRMAIN").HeaderText = "Matricula Inmobiliria"
            Me.dgvLIRAPRED.Columns("LRPRNUFI").HeaderText = "Nro. Ficha Predial"

            Me.dgvLIRAPRED.Columns("LRPRIDRE").Visible = False
            Me.dgvLIRAPRED.Columns("LRPRNURA").Visible = False
            Me.dgvLIRAPRED.Columns("LRPRFERA").Visible = False
            Me.dgvLIRAPRED.Columns("LRPRSECU").Visible = False

            '==================================================
            '*** ASIGNA LOS PRIVILEGIOS DE LA BARRA DE MENU ***
            '==================================================

            Dim ContarRegistros As Integer = Me.BindingSource_LIRAPRED_1.Count

            Dim boCONTAGRE As Boolean = False
            Dim boCONTMODI As Boolean = False
            Dim boCONTELIM As Boolean = False
            Dim boCONTCONS As Boolean = False
            Dim boCONTRECO As Boolean = False

            pro_Permiso_Barra_De_Menu_Formulario_SubFormulario(ContarRegistros, Trim(Me.BindingNavigator_LIRAPRED_1.Name), boCONTAGRE, boCONTMODI, boCONTELIM, boCONTCONS, boCONTRECO)

            Me.cmdAGREGAR_LIRAPRED.Enabled = boCONTAGRE
            Me.cmdMODIFICAR_LIRAPRED.Enabled = boCONTMODI
            Me.cmdELIMINAR_LIRAPRED.Enabled = boCONTELIM
            Me.cmdCONSULTAR_LIRAPRED.Enabled = boCONTCONS
            Me.cmdRECONSULTAR_LIRAPRED.Enabled = boCONTRECO

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub pro_ListaDeValoresPredio()

    End Sub
    Private Sub pro_LimpiarCamposPredio()

        Me.dgvLIRAPRED.DataSource = New DataTable

    End Sub

#End Region

#Region "PROCEDIMIENTO DESTINATARIO DIVISION"

    Private Sub pro_ReconsultarDestinatarioDivision()

        Try
            Dim objdatos As New cla_LIRADEDI

            If boCONSULTA = False Then
                Me.BindingSource_LIRADEDI_1.DataSource = objdatos.fun_Buscar_SECU_X_CONSULTA_PARAMETRIZADA_LIRADEDI(Me.dgvLIBRRADI_1.SelectedRows.Item(0).Cells("LIRASECU").Value.ToString())
            Else
                Me.BindingSource_LIRADEDI_1.DataSource = objdatos.fun_Buscar_SECU_X_CONSULTA_PARAMETRIZADA_LIRADEDI(Me.dgvLIBRRADI_1.SelectedRows.Item(0).Cells("LIRASECU").Value.ToString())
            End If

            Me.dgvLIRADEDI.DataSource = BindingSource_LIRADEDI_1
            Me.BindingNavigator_LIRADEDI_1.BindingSource = BindingSource_LIRADEDI_1

            '=================================================
            '*** CONFIGURA OBJETOS DEL FORMULARIO MAESTRO ***
            '=================================================

            Me.strBARRESTA.Items(2).Text = "Registros : " & Me.BindingSource_LIRADEDI_1.Count

            Me.dgvLIRADEDI.Columns("DIVIDESC").HeaderText = "División"
            Me.dgvLIRADEDI.Columns("LRDDFEAS").HeaderText = "Fecha de Asignación"
            Me.dgvLIRADEDI.Columns("LRDDNRDE").HeaderText = "Nro. Radicado"
            Me.dgvLIRADEDI.Columns("LRDDFEDE").HeaderText = "Fecha de Radicado"

            Me.dgvLIRADEDI.Columns("LRDDIDRE").Visible = False
            Me.dgvLIRADEDI.Columns("LRDDNURA").Visible = False
            Me.dgvLIRADEDI.Columns("LRDDFERA").Visible = False
            Me.dgvLIRADEDI.Columns("LRDDSECU").Visible = False
            Me.dgvLIRADEDI.Columns("LRDDNUDO").Visible = False
            Me.dgvLIRADEDI.Columns("LRDDFEIN").Visible = False
            Me.dgvLIRADEDI.Columns("LRDDUSUA").Visible = False

            '==================================================
            '*** ASIGNA LOS PRIVILEGIOS DE LA BARRA DE MENU ***
            '==================================================

            Dim ContarRegistros As Integer = Me.BindingSource_LIRADEDI_1.Count

            Dim boCONTAGRE As Boolean = False
            Dim boCONTMODI As Boolean = False
            Dim boCONTELIM As Boolean = False
            Dim boCONTCONS As Boolean = False
            Dim boCONTRECO As Boolean = False

            pro_Permiso_Barra_De_Menu_Formulario_SubFormulario(ContarRegistros, Trim(Me.BindingNavigator_LIRADEDI_1.Name), boCONTAGRE, boCONTMODI, boCONTELIM, boCONTCONS, boCONTRECO)

            Me.cmdAGREGAR_LIRADEDI.Enabled = boCONTAGRE
            Me.cmdMODIFICAR_LIRADEDI.Enabled = boCONTMODI
            Me.cmdELIMINAR_LIRADEDI.Enabled = boCONTELIM
            Me.cmdCONSULTAR_LIRADEDI.Enabled = boCONTCONS
            Me.cmdRECONSULTAR_LIRADEDI.Enabled = boCONTRECO

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub pro_ListaDeValoresDestinatarioDivision()

    End Sub
    Private Sub pro_LimpiarCamposDestinatarioDivision()

        Me.dgvLIRADEDI.DataSource = New DataTable

    End Sub

#End Region

#Region "PROCEDIMIENTO DESTINATARIO FUNCIONARIO"

    Private Sub pro_ReconsultarDestinatarioFuncionario()

        Try

            Dim objdatos As New cla_LIRADEFU

            If boCONSULTA = False Then
                Me.BindingSource_LIRADEFU_1.DataSource = objdatos.fun_Buscar_SECU_X_CONSULTA_PARAMETRIZADA_LIRADEFU(Me.dgvLIBRRADI_1.SelectedRows.Item(0).Cells("LIRASECU").Value.ToString())
            Else
                Me.BindingSource_LIRADEFU_1.DataSource = objdatos.fun_Buscar_SECU_X_CONSULTA_PARAMETRIZADA_LIRADEFU(Me.dgvLIBRRADI_1.SelectedRows.Item(0).Cells("LIRASECU").Value.ToString())
            End If

            Me.dgvLIRADEFU.DataSource = BindingSource_LIRADEFU_1
            Me.BindingNavigator_LIRADEFU_1.BindingSource = BindingSource_LIRADEFU_1

            '=================================================
            '*** CONFIGURA OBJETOS DEL FORMULARIO MAESTRO ***
            '=================================================

            Me.strBARRESTA.Items(2).Text = "Registros : " & Me.BindingSource_LIRADEFU_1.Count

            Me.dgvLIRADEFU.Columns("LRDFUSUA").HeaderText = "Usuario"
            Me.dgvLIRADEFU.Columns("USUANOMB").HeaderText = "Nombre(s)"
            Me.dgvLIRADEFU.Columns("USUAPRAP").HeaderText = "Primer Apellido"
            Me.dgvLIRADEFU.Columns("USUASEAP").HeaderText = "Segundo Apellido"
            Me.dgvLIRADEFU.Columns("LRDFFEAS").HeaderText = "Fecha de Asignación"
            Me.dgvLIRADEFU.Columns("LRDFNRDE").HeaderText = "Nro. Radicado"
            Me.dgvLIRADEFU.Columns("LRDFFEDE").HeaderText = "Fecha de Radicado"

            Me.dgvLIRADEFU.Columns("LRDFIDRE").Visible = False
            Me.dgvLIRADEFU.Columns("LRDFNURA").Visible = False
            Me.dgvLIRADEFU.Columns("LRDFFERA").Visible = False
            Me.dgvLIRADEFU.Columns("LRDFSECU").Visible = False
            Me.dgvLIRADEFU.Columns("LRDFFEIN").Visible = False
            Me.dgvLIRADEFU.Columns("LRDFNUDO").Visible = False

            '==================================================
            '*** ASIGNA LOS PRIVILEGIOS DE LA BARRA DE MENU ***
            '==================================================

            Dim ContarRegistros As Integer = Me.BindingSource_LIRADEFU_1.Count

            Dim boCONTAGRE As Boolean = False
            Dim boCONTMODI As Boolean = False
            Dim boCONTELIM As Boolean = False
            Dim boCONTCONS As Boolean = False
            Dim boCONTRECO As Boolean = False

            pro_Permiso_Barra_De_Menu_Formulario_SubFormulario(ContarRegistros, Trim(Me.BindingNavigator_LIRADEFU_1.Name), boCONTAGRE, boCONTMODI, boCONTELIM, boCONTCONS, boCONTRECO)

            Me.cmdAGREGAR_LIRADEFU.Enabled = boCONTAGRE
            Me.cmdMODIFICAR_LIRADEFU.Enabled = boCONTMODI
            Me.cmdELIMINAR_LIRADEFU.Enabled = boCONTELIM
            Me.cmdCONSULTAR_LIRADEFU.Enabled = boCONTCONS
            Me.cmdRECONSULTAR_LIRADEFU.Enabled = boCONTRECO

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub pro_ListaDeValoresDestinatarioFuncionario()

    End Sub
    Private Sub pro_LimpiarCamposDestinatarioFuncionario()

        Me.dgvLIRADEFU.DataSource = New DataTable

    End Sub

#End Region

#Region "PROCEDIMIENTOS DOCUMENTOS"

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

            tblRutas = objRutas.fun_Buscar_CODIGO_MANT_RUTAS(17)

            If tblRutas.Rows.Count > 0 AndAlso fun_VerificarCarpetaExistenteDocumentos() = True Then

                stNewPath = Trim(tblRutas.Rows(0).Item("RUTARUTA")) & "\" & Trim(Me.dgvLIBRRADI_1.SelectedRows.Item(0).Cells("LIRANURA").Value.ToString) & "-" & _
                                                                            Trim(Me.dgvLIBRRADI_1.SelectedRows.Item(0).Cells("LIRAFERA").Value.ToString)

                vl_stRutaDocumentos = stNewPath


                ChDir(stNewPath)
                Me.lstLISTADO_DOCUMENTOS.Items.Clear()

                ContentItem = Dir("*.*")

                If ContentItem <> "" Then
                    Me.lstLISTADO_DOCUMENTOS.Focus()
                End If

                Do Until ContentItem = ""
                    ' agrega a la lista
                    Me.lstLISTADO_DOCUMENTOS.Items.Add(ContentItem)

                    'desplaza el registro
                    ContentItem = Dir()
                Loop

            Else
                Me.lstLISTADO_DOCUMENTOS.Items.Clear()
            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub pro_LimpiarDocumentos()

        Me.lstLISTADO_DOCUMENTOS.Items.Clear()

    End Sub

#End Region

#Region "MENU LIBRO RADICADOR"

    Private Sub cmdAGREGAR_LIBRRADI_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAGREGAR_LIBRRADI.Click

        Try

            If Me.dgvLIBRRADI_1.RowCount > 0 Then
                Dim frm_insertar As New frm_insertar_LIBRRADI(Integer.Parse(Me.dgvLIBRRADI_1.SelectedRows.Item(0).Cells("LIRAIDRE").Value.ToString()))
                frm_insertar.ShowDialog()
            Else
                frm_insertar_LIBRRADI.ShowDialog()
            End If

            If vp_inConsulta > 0 Then
                boCONSULTA = True
            Else
                boCONSULTA = False
            End If

            pro_ReconsultarLibroRadicador()
            pro_ListaDeValoresLibroRadicador()

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub cmdMODIFICAR_LIBRRADI_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdMODIFICAR_LIBRRADI.Click

        Try
            Dim frm_modificar As New frm_modificar_LIBRRADI(Integer.Parse(Me.dgvLIBRRADI_1.SelectedRows.Item(0).Cells("LIRAIDRE").Value.ToString()))
            frm_modificar.ShowDialog()

            If vp_inConsulta <> 0 Then
                boCONSULTA = True
            End If

            pro_ReconsultarLibroRadicador()
            pro_ListaDeValoresLibroRadicador()

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub cmdELIMINAR_LIBRRADI_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdELIMINAR_LIBRRADI.Click

        Try
            If MessageBox.Show("¿ Desea eliminar el registro seleccionado ? ", "Mensaje...", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then
                Dim objdatos As New cla_LIBRRADI

                If objdatos.fun_Eliminar_IDRE_LIBRRADI(Integer.Parse(Me.dgvLIBRRADI_1.SelectedRows.Item(0).Cells("LIRAIDRE").Value.ToString())) Then

                    boCONSULTA = False

                    pro_LimpiarCamposLibroRadicador()
                    pro_ReconsultarLibroRadicador()
                    pro_ListaDeValoresLibroRadicador()
                Else
                    frm_INCO_eliminar_registro_padre_con_relación_de_registros_hijos.ShowDialog()
                End If

            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub cmdCONSULTAR_LIBRRADI_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCONSULTAR_LIBRRADI.Click

        Try
            vp_inConsulta = 0

            If Me.dgvLIBRRADI_1.RowCount > 0 Then
                Dim frm_consultar As New frm_consultar_LIBRRADI(Integer.Parse(Me.dgvLIBRRADI_1.SelectedRows.Item(0).Cells("LIRAIDRE").Value.ToString()))
                frm_consultar.ShowDialog()
            Else
                Dim frm_consultar As New frm_consultar_LIBRRADI()
                frm_consultar.ShowDialog()
            End If

            If vp_inConsulta > 0 Then
                boCONSULTA = True
            Else
                boCONSULTA = False
            End If

            pro_ReconsultarLibroRadicador()
            pro_ListaDeValoresLibroRadicador()

            Me.TabMAESTRO_2.SelectTab(TabSolicitante)

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub cmdRECONSULTAR_LIBRRADI_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdRECONSULTAR_LIBRRADI.Click

        Try
            If Me.dgvLIBRRADI_1.RowCount > 0 Then
                boCONSULTA = True
            Else
                boCONSULTA = False
            End If

            pro_ReconsultarLibroRadicador()
            pro_ListaDeValoresLibroRadicador()

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub cmdSALIR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSALIR.Click

        Try
            Me.Close()

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub cmdIMPORTAR_DOCUMENTOS_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdIMPORTAR_DOCUMENTOS.Click

        Try
            If Me.dgvLIBRRADI_1.RowCount > 0 Then

                Dim frm_inserta_archivo As New frm_insertar_archivo_LIBRRADI(Me.dgvLIBRRADI_1.SelectedRows.Item(0).Cells("LIRANURA").Value.ToString(), _
                                                                             Me.dgvLIBRRADI_1.SelectedRows.Item(0).Cells("LIRAFERA").Value.ToString())
                frm_inserta_archivo.ShowDialog()

                pro_ListadoArchivosDocumentos()

                vp_inConsulta = Me.dgvLIBRRADI_1.SelectedRows.Item(0).Cells("LIRAIDRE").Value.ToString()

                If vp_inConsulta <> 0 Then
                    boCONSULTA = True
                Else
                    boCONSULTA = False
                End If

                pro_ReconsultarLibroRadicador()
                pro_ListaDeValoresLibroRadicador()

                mod_MENSAJE.Proceso_Termino_Correctamente()

            Else
                mod_MENSAJE.No_Existe_Un_Registro_Seleccionado()
            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub cmdFinalizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdFinalizar.Click
        pro_EjecutarBotonFinalizar()
        pro_EjecutarBotonObservaciones()
    End Sub

    Private Sub cmdOBSERVACIONES_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOBSERVACIONES.Click
        pro_EjecutarBotonObservaciones()
    End Sub

    Private Sub ToolStripButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton1.Click

        Try
            pro_ListaDeValoresLibroRadicador()

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub ToolStripButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton2.Click

        Try
            pro_ListaDeValoresLibroRadicador()

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub ToolStripButton3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton3.Click

        Try
            pro_ListaDeValoresLibroRadicador()

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub ToolStripButton4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton4.Click

        Try
            pro_ListaDeValoresLibroRadicador()

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub

#End Region

#Region "MENU SOLICITANTE"

    Private Sub cmdAGREGAR_LIRASOLI_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAGREGAR_LIRASOLI.Click

        Try
            If Me.dgvLIBRRADI_1.RowCount > 0 Then
                Dim frm_insertar As New frm_insertar_LIRASOLI(Me.dgvLIBRRADI_1.SelectedRows.Item(0).Cells("LIRASECU").Value.ToString(), _
                                                              Me.dgvLIBRRADI_1.SelectedRows.Item(0).Cells("LIRANURA").Value.ToString(), _
                                                              Me.dgvLIBRRADI_1.SelectedRows.Item(0).Cells("LIRAFERA").Value.ToString())
                frm_insertar.ShowDialog()
            End If

            boCONSULTA = False

            pro_ReconsultarSolicitante()
            pro_ListaDeValoresSolicitante()

            Me.TabMAESTRO_2.SelectTab(TabSolicitante)

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub cmdMODIFICAR_LIRASOLI_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdMODIFICAR_LIRASOLI.Click

        Try
            Dim frm_modificar As New frm_insertar_LIRASOLI(Me.dgvLIRASOLI_1.SelectedRows.Item(0).Cells("LRSOIDRE").Value.ToString(), _
                                                           Me.dgvLIBRRADI_1.SelectedRows.Item(0).Cells("LIRASECU").Value.ToString(), _
                                                           Me.dgvLIBRRADI_1.SelectedRows.Item(0).Cells("LIRANURA").Value.ToString(), _
                                                           Me.dgvLIBRRADI_1.SelectedRows.Item(0).Cells("LIRAFERA").Value.ToString())
            frm_modificar.ShowDialog()

            If vp_inConsulta <> 0 Then
                boCONSULTA = True
            End If

            pro_ReconsultarSolicitante()
            pro_ListaDeValoresSolicitante()

            Me.TabMAESTRO_2.SelectTab(TabSolicitante)

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub cmdELIMINAR_LIRASOLI_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdELIMINAR_LIRASOLI.Click

        Try
            If MessageBox.Show("¿ Desea eliminar el registro seleccionado ? ", "Mensaje...", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then
                Dim objdatos As New cla_LIRASOLI

                If objdatos.fun_Eliminar_IDRE_LIRASOLI(Integer.Parse(Me.dgvLIRASOLI_1.SelectedRows.Item(0).Cells("LRSOIDRE").Value.ToString())) Then

                    boCONSULTA = False

                    pro_LimpiarCamposSolicitante()
                    pro_ReconsultarSolicitante()
                    pro_ListaDeValoresSolicitante()
                Else
                    frm_INCO_eliminar_registro_padre_con_relación_de_registros_hijos.ShowDialog()
                End If

            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub cmdCONSULTAR_LIRASOLI_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCONSULTAR_LIRASOLI.Click

        vp_inConsulta = 0

        Dim frm_consultar As New frm_consultar_LIBRRADI(Integer.Parse(Me.dgvLIBRRADI_1.SelectedRows.Item(0).Cells("LIRAIDRE").Value.ToString()))
        frm_consultar.ShowDialog()

        If vp_inConsulta > 0 Then
            boCONSULTA = True
        Else
            boCONSULTA = False
        End If

        pro_ReconsultarLibroRadicador()
        pro_ListaDeValoresLibroRadicador()

        Me.TabMAESTRO_2.SelectTab(TabSolicitante)

    End Sub
    Private Sub cmdRECONSULTAR_MATEREGI_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdRECONSULTAR_LIRASOLI.Click

        boCONSULTA = False
        pro_ReconsultarLibroRadicador()
        pro_ListaDeValoresLibroRadicador()

    End Sub

#End Region

#Region "MENU PREDIO"

    Private Sub cmdAGREGAR_LIRAPRED_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAGREGAR_LIRAPRED.Click

        Try
            If Me.dgvLIBRRADI_1.RowCount > 0 Then
                Dim frm_insertar As New frm_insertar_LIRAPRED(Me.dgvLIBRRADI_1.SelectedRows.Item(0).Cells("LIRASECU").Value.ToString(), _
                                                              Me.dgvLIBRRADI_1.SelectedRows.Item(0).Cells("LIRANURA").Value.ToString(), _
                                                              Me.dgvLIBRRADI_1.SelectedRows.Item(0).Cells("LIRAFERA").Value.ToString())
                frm_insertar.ShowDialog()
            End If

            boCONSULTA = False

            pro_ReconsultarPredio()
            pro_ListaDeValoresPredio()

            Me.TabMAESTRO_2.SelectTab(TabPredios)

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub cmdMODIFICAR_LIRAPRED_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdMODIFICAR_LIRAPRED.Click

        Try
            Dim frm_modificar As New frm_insertar_LIRAPRED(Me.dgvLIRAPRED.SelectedRows.Item(0).Cells("LRPRIDRE").Value.ToString(), _
                                                           Me.dgvLIBRRADI_1.SelectedRows.Item(0).Cells("LIRASECU").Value.ToString(), _
                                                           Me.dgvLIBRRADI_1.SelectedRows.Item(0).Cells("LIRANURA").Value.ToString(), _
                                                           Me.dgvLIBRRADI_1.SelectedRows.Item(0).Cells("LIRAFERA").Value.ToString())
            frm_modificar.ShowDialog()

            If vp_inConsulta <> 0 Then
                boCONSULTA = True
            End If

            pro_ReconsultarPredio()
            pro_ListaDeValoresPredio()

            Me.TabMAESTRO_2.SelectTab(TabPredios)

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub cmdELIMINAR_LIRAPRED_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdELIMINAR_LIRAPRED.Click

        Try
            If MessageBox.Show("¿ Desea eliminar el registro seleccionado ? ", "Mensaje...", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then
                Dim objdatos As New cla_LIRAPRED

                If objdatos.fun_Eliminar_IDRE_LIRAPRED(Integer.Parse(Me.dgvLIRAPRED.SelectedRows.Item(0).Cells("LRPRIDRE").Value.ToString())) Then

                    boCONSULTA = False

                    pro_LimpiarCamposPredio()
                    pro_ReconsultarPredio()
                    pro_ListaDeValoresPredio()
                Else
                    frm_INCO_eliminar_registro_padre_con_relación_de_registros_hijos.ShowDialog()
                End If

            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub cmdCONSULTAR_LIRAPRED_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCONSULTAR_LIRAPRED.Click

        vp_inConsulta = 0

        Dim frm_consultar As New frm_consultar_LIBRRADI(Integer.Parse(Me.dgvLIBRRADI_1.SelectedRows.Item(0).Cells("LIRAIDRE").Value.ToString()))
        frm_consultar.ShowDialog()

        If vp_inConsulta > 0 Then
            boCONSULTA = True
        Else
            boCONSULTA = False
        End If

        pro_ReconsultarLibroRadicador()
        pro_ListaDeValoresLibroRadicador()

        Me.TabMAESTRO_2.SelectTab(TabSolicitante)

    End Sub
    Private Sub cmdRECONSULTAR_LIRAPRED_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdRECONSULTAR_LIRAPRED.Click

        boCONSULTA = False
        pro_ReconsultarLibroRadicador()
        pro_ListaDeValoresLibroRadicador()

    End Sub

#End Region

#Region "MENU DESTINATARIO DIVISION"

    Private Sub cmdAGREGAR_LIRADEDI_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAGREGAR_LIRADEDI.Click

        Try
            If Me.dgvLIBRRADI_1.RowCount > 0 Then
                Dim frm_insertar As New frm_insertar_LIRADEDI(Me.dgvLIBRRADI_1.SelectedRows.Item(0).Cells("LIRASECU").Value.ToString(), _
                                                              Me.dgvLIBRRADI_1.SelectedRows.Item(0).Cells("LIRANURA").Value.ToString(), _
                                                              Me.dgvLIBRRADI_1.SelectedRows.Item(0).Cells("LIRAFERA").Value.ToString())
                frm_insertar.ShowDialog()
            End If

            boCONSULTA = False

            pro_ReconsultarDestinatarioDivision()
            pro_ListaDeValoresDestinatarioDivision()

            Me.TabMAESTRO_2.SelectTab(TabDestinatario)

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub cmdMODIFICAR_LIRADEDI_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdMODIFICAR_LIRADEDI.Click

        Try
            Dim frm_modificar As New frm_insertar_LIRADEDI(Me.dgvLIRADEDI.SelectedRows.Item(0).Cells("LRDDIDRE").Value.ToString(), _
                                                           Me.dgvLIBRRADI_1.SelectedRows.Item(0).Cells("LIRASECU").Value.ToString(), _
                                                           Me.dgvLIBRRADI_1.SelectedRows.Item(0).Cells("LIRANURA").Value.ToString(), _
                                                           Me.dgvLIBRRADI_1.SelectedRows.Item(0).Cells("LIRAFERA").Value.ToString())
            frm_modificar.ShowDialog()

            If vp_inConsulta <> 0 Then
                boCONSULTA = True
            End If

            pro_ReconsultarDestinatarioDivision()
            pro_ListaDeValoresDestinatarioDivision()

            Me.TabMAESTRO_2.SelectTab(TabDestinatario)

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub cmdELIMINAR_LIRADEDI_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdELIMINAR_LIRADEDI.Click

        Try
            If MessageBox.Show("¿ Desea eliminar el registro seleccionado ? ", "Mensaje...", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then
                Dim objdatos As New cla_LIRADEDI

                If objdatos.fun_Eliminar_IDRE_LIRADEDI(Integer.Parse(Me.dgvLIRADEDI.SelectedRows.Item(0).Cells("LRDDIDRE").Value.ToString())) Then

                    boCONSULTA = False

                    pro_LimpiarCamposDestinatarioDivision()
                    pro_ReconsultarDestinatarioDivision()
                    pro_ListaDeValoresDestinatarioDivision()
                Else
                    frm_INCO_eliminar_registro_padre_con_relación_de_registros_hijos.ShowDialog()
                End If

            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub cmdCONSULTAR_LIRADEDI_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCONSULTAR_LIRADEDI.Click

        vp_inConsulta = 0

        Dim frm_consultar As New frm_consultar_LIBRRADI(Integer.Parse(Me.dgvLIBRRADI_1.SelectedRows.Item(0).Cells("LIRAIDRE").Value.ToString()))
        frm_consultar.ShowDialog()

        If vp_inConsulta > 0 Then
            boCONSULTA = True
        Else
            boCONSULTA = False
        End If

        pro_ReconsultarLibroRadicador()
        pro_ListaDeValoresLibroRadicador()

        Me.TabMAESTRO_2.SelectTab(TabSolicitante)

    End Sub
    Private Sub cmdRECONSULTAR_LIRADEDI_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdRECONSULTAR_LIRADEDI.Click

        boCONSULTA = False
        pro_ReconsultarLibroRadicador()
        pro_ListaDeValoresLibroRadicador()

    End Sub

#End Region

#Region "MENU DESTINATARIO FUNCIONARIO"

    Private Sub cmdAGREGAR_LIRADEFU_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAGREGAR_LIRADEFU.Click

        Try
            If Me.dgvLIBRRADI_1.RowCount > 0 Then
                Dim frm_insertar As New frm_insertar_LIRADEFU(Me.dgvLIBRRADI_1.SelectedRows.Item(0).Cells("LIRASECU").Value.ToString(), _
                                                              Me.dgvLIBRRADI_1.SelectedRows.Item(0).Cells("LIRANURA").Value.ToString(), _
                                                              Me.dgvLIBRRADI_1.SelectedRows.Item(0).Cells("LIRAFERA").Value.ToString())
                frm_insertar.ShowDialog()
            End If

            boCONSULTA = False

            pro_ReconsultarDestinatarioFuncionario()
            pro_ListaDeValoresDestinatarioFuncionario()

            Me.TabMAESTRO_2.SelectTab(TabDestinatario)

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub cmdMODIFICAR_LIRADEFU_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdMODIFICAR_LIRADEFU.Click

        Try
            Dim frm_modificar As New frm_insertar_LIRADEFU(Me.dgvLIRADEFU.SelectedRows.Item(0).Cells("LRDFIDRE").Value.ToString(), _
                                                           Me.dgvLIBRRADI_1.SelectedRows.Item(0).Cells("LIRASECU").Value.ToString(), _
                                                           Me.dgvLIBRRADI_1.SelectedRows.Item(0).Cells("LIRANURA").Value.ToString(), _
                                                           Me.dgvLIBRRADI_1.SelectedRows.Item(0).Cells("LIRAFERA").Value.ToString(), _
                                                           Me.dgvLIRADEFU.SelectedRows.Item(0).Cells("LRDFNUDO").Value.ToString())
            frm_modificar.ShowDialog()

            If vp_inConsulta <> 0 Then
                boCONSULTA = True
            End If

            pro_ReconsultarDestinatarioFuncionario()
            pro_ListaDeValoresDestinatarioFuncionario()

            Me.TabMAESTRO_2.SelectTab(TabDestinatario)

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub cmdELIMINAR_LIRADEFU_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdELIMINAR_LIRADEFU.Click

        Try
            If MessageBox.Show("¿ Desea eliminar el registro seleccionado ? ", "Mensaje...", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then
                Dim objdatos As New cla_LIRADEFU

                If objdatos.fun_Eliminar_IDRE_LIRADEFU(Integer.Parse(Me.dgvLIRADEFU.SelectedRows.Item(0).Cells("LRDFIDRE").Value.ToString())) Then

                    boCONSULTA = False

                    pro_LimpiarCamposDestinatarioFuncionario()
                    pro_ReconsultarDestinatarioFuncionario()
                    pro_ListaDeValoresDestinatarioFuncionario()
                Else
                    frm_INCO_eliminar_registro_padre_con_relación_de_registros_hijos.ShowDialog()
                End If

            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub cmdCONSULTAR_LIRADEFU_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCONSULTAR_LIRADEFU.Click

        vp_inConsulta = 0

        Dim frm_consultar As New frm_consultar_LIBRRADI(Integer.Parse(Me.dgvLIBRRADI_1.SelectedRows.Item(0).Cells("LIRAIDRE").Value.ToString()))
        frm_consultar.ShowDialog()

        If vp_inConsulta > 0 Then
            boCONSULTA = True
        Else
            boCONSULTA = False
        End If

        pro_ReconsultarLibroRadicador()
        pro_ListaDeValoresLibroRadicador()

        Me.TabMAESTRO_2.SelectTab(TabSolicitante)

    End Sub
    Private Sub cmdRECONSULTAR_LIRADEFU_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdRECONSULTAR_LIRADEFU.Click

        boCONSULTA = False
        pro_ReconsultarLibroRadicador()
        pro_ListaDeValoresLibroRadicador()

    End Sub

#End Region

#Region "FORMULARIO"

#Region "Load"

    Private Sub frm_LIBRRADI_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Me.Load
        pro_ReconsultarLibroRadicador()
        pro_ListadoArchivosDocumentos()
        Me.strBARRESTA.Items(0).Text = "Libro radicador"
    End Sub

#End Region

#Region "GotFocus"

    Private Sub frm_LIBRRADI_GotFocus1(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.GotFocus
        pro_ListaDeValoresLibroRadicador()
    End Sub

#End Region

#Region "KeyDown"

    Private Sub dgvREGIMUTA_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgvLIBRRADI_1.KeyDown, dgvLIBRRADI_2.KeyDown
        '===============================================================================================
        '*** INSERTAR REGISTROS ***
        '===============================================================================================


        If e.KeyCode = Keys.F2 Then
            If Me.cmdAGREGAR_LIBRRADI.Enabled = True Then
                Me.cmdAGREGAR_LIBRRADI.PerformClick()
            Else
                mod_MENSAJE.Usuario_No_Tiene_Permiso_Para_Realizar_La_Operacion()
            End If
        End If

        '===============================================================================================
        'MODIFICAR REGISTROS
        '===============================================================================================

        If e.KeyCode = Keys.F3 Then
            If Me.cmdMODIFICAR_LIBRRADI.Enabled = True Then
                Me.cmdMODIFICAR_LIBRRADI.PerformClick()
            Else
                Dim ContarRegistros As Integer = Me.BindingSource_LIRASOLI_1.Count

                If ContarRegistros = 0 Then
                    mod_MENSAJE.No_Existen_Registros_En_Base_De_Datos()
                Else
                    mod_MENSAJE.Usuario_No_Tiene_Permiso_Para_Realizar_La_Operacion()
                End If

            End If
        End If

        '===============================================================================================
        '*** ELIMINAR REGISTROS ***
        '===============================================================================================

        If e.KeyCode = Keys.Delete Then
            If Me.cmdELIMINAR_LIBRRADI.Enabled = True Then
                Me.cmdELIMINAR_LIBRRADI.PerformClick()
            Else
                Dim ContarRegistros As Integer = Me.BindingSource_LIRASOLI_1.Count

                If ContarRegistros = 0 Then
                    mod_MENSAJE.No_Existen_Registros_En_Base_De_Datos()
                Else
                    mod_MENSAJE.Usuario_No_Tiene_Permiso_Para_Realizar_La_Operacion()
                End If

            End If
        End If

        '===============================================================================================
        '*** CONSULTAR REGISTROS ***
        '===============================================================================================

        If e.KeyCode = Keys.F7 Then
            If Me.cmdCONSULTAR_LIBRRADI.Enabled = True Then
                Me.cmdCONSULTAR_LIBRRADI.PerformClick()
            Else
                mod_MENSAJE.No_Existen_Registros_En_Base_De_Datos()
            End If
        End If

        '===============================================================================================
        '*** RECONSULTAR REGISTROS ***
        '===============================================================================================

        If e.KeyCode = Keys.F8 Then
            If Me.cmdCONSULTAR_LIBRRADI.Enabled = True Then
                Me.cmdRECONSULTAR_LIBRRADI.PerformClick()
            Else
                mod_MENSAJE.No_Existen_Registros_En_Base_De_Datos()
            End If
        End If

    End Sub

#End Region

#Region "KeyUp"

    Private Sub dgvREGIMUTA_1_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgvLIBRRADI_1.KeyUp
        If e.KeyCode = Keys.Down Or e.KeyCode = Keys.Up Or e.KeyCode = Keys.Enter Or e.KeyCode = Keys.PageUp Or e.KeyCode = Keys.PageDown Then
            pro_ListaDeValoresLibroRadicador()
        End If
    End Sub
    Private Sub dgvREGIMUTA_2_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgvLIBRRADI_2.KeyUp
        If e.KeyCode = Keys.Down Or e.KeyCode = Keys.Up Or e.KeyCode = Keys.Enter Or e.KeyCode = Keys.PageUp Or e.KeyCode = Keys.PageDown Then
            pro_ListaDeValoresLibroRadicador()
        End If
    End Sub

#End Region

#Region "CellClick"

    Private Sub dgvREGIMUTA_1_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvLIBRRADI_1.CellClick
        pro_ListaDeValoresLibroRadicador()
    End Sub
    Private Sub dgvREGIMUTA_2_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvLIBRRADI_2.CellClick
        pro_ListaDeValoresLibroRadicador()
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