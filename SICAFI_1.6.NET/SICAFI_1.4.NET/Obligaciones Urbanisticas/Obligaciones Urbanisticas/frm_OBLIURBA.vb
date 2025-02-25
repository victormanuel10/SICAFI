Imports REGLAS_DEL_NEGOCIO
Imports System
Imports System.IO
Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration
Imports System.Text

Public Class frm_OBLIURBA

    '=================================
    '*** OBLIGACIONES URBANISTICAS ***
    '=================================

#Region "VARIABLES"

    Dim boCONSULTA As Boolean = False

    Dim vl_stRutaDocumentosTIF As String = ""
    Dim vl_stRutaDocumentosPDF As String = ""

    Dim vl_boControlDeComandos As Boolean = False

    Private oEjecutar As New SqlCommand
    Private oConexion As New SqlConnection
    Private oAdapter As New SqlDataAdapter
    Private oReader As SqlDataReader
    Private ds As New DataSet
    Private dt As New DataTable

#End Region

#Region "INSTANCIAR FORMULARIO"

    Private Shared frm_Instance = Nothing

    Public Shared Function instance() As frm_OBLIURBA
        If frm_Instance Is Nothing OrElse frm_Instance.isdisposed = True Then
            frm_Instance = New frm_OBLIURBA
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

            tblRutas = objRutas.fun_Buscar_CODIGO_MANT_RUTAS(22)

            If tblRutas.Rows.Count > 0 Then

                ' directorio pricipal
                stRuta = Trim(tblRutas.Rows(0).Item("RUTARUTA")) & "\"

                ' directorio expediente 
                stCarpetaABuscar = Trim(Me.dgvOBLIURBA.SelectedRows.Item(0).Cells("OBURCLEN").Value.ToString) & "-" & _
                                   Trim(Me.dgvOBLIURBA.SelectedRows.Item(0).Cells("OBURNURE").Value.ToString) & "-" & _
                                   Trim(Me.dgvOBLIURBA.SelectedRows.Item(0).Cells("OBURVIRE").Value.ToString)

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

#Region "PROCEDIMIENTO OBLIGACION URBANISTICA"

    Private Sub pro_ReconsultarObligacionesUrbanisticas()

        Try
            Dim objdatos As New cla_OBLIURBA

            If boCONSULTA = False Then
                Me.BindingSource_OBLIURBA_1.DataSource = objdatos.fun_Consultar_OBLIURBA
            Else
                Me.BindingSource_OBLIURBA_1.DataSource = objdatos.fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_OBLIURBA(vp_inConsulta)
            End If

            Me.dgvOBLIURBA.DataSource = BindingSource_OBLIURBA_1
            Me.BindingNavigator_OBLIURBA_1.BindingSource = BindingSource_OBLIURBA_1

            '=================================================
            '*** CONFIGURA OBJETOS DEL FORMULARIO MAESTRO ***
            '=================================================

            Me.strBARRESTA.Items(2).Text = "Registros : " & Me.BindingSource_OBLIURBA_1.Count

            Me.dgvOBLIURBA.Columns("OBURSECU").HeaderText = "Nro. Liquidación"
            Me.dgvOBLIURBA.Columns("CLENDESC").HeaderText = "Clase de Entidad"
            Me.dgvOBLIURBA.Columns("OBURNURE").HeaderText = "Nro. Radicado"
            Me.dgvOBLIURBA.Columns("OBURFERE").HeaderText = "Fecha de Radicado"
            Me.dgvOBLIURBA.Columns("OBURVIRE").HeaderText = "Vigencia del Radicado"
            Me.dgvOBLIURBA.Columns("OBURFEIN").HeaderText = "Fecha de Ingreso"
            Me.dgvOBLIURBA.Columns("ESTADESC").HeaderText = "Estado"

            Me.dgvOBLIURBA.Columns("OBURIDRE").Visible = False
            Me.dgvOBLIURBA.Columns("OBURCLEN").Visible = False
            Me.dgvOBLIURBA.Columns("OBURESTA").Visible = False
            Me.dgvOBLIURBA.Columns("OBURNDIN").Visible = False
            Me.dgvOBLIURBA.Columns("OBURUSFI").Visible = False
            Me.dgvOBLIURBA.Columns("OBURNDFI").Visible = False
            Me.dgvOBLIURBA.Columns("OBURFEFI").Visible = False
            Me.dgvOBLIURBA.Columns("OBURMAQU").Visible = False
            Me.dgvOBLIURBA.Columns("OBURUSIN").Visible = False
            Me.dgvOBLIURBA.Columns("OBUROBSE").Visible = False
            Me.dgvOBLIURBA.Columns("OBURVILI").Visible = False
            Me.dgvOBLIURBA.Columns("OBURFELI").Visible = False
            Me.dgvOBLIURBA.Columns("OBURGRCO").Visible = False
            Me.dgvOBLIURBA.Columns("OBURAJLI").Visible = False

            Me.dgvOBLIURBA.Columns("CLENDESC").Width = 200

            '==================================================
            '*** ASIGNA LOS PRIVILEGIOS DE LA BARRA DE MENU ***
            '==================================================

            Dim ContarRegistros As Integer = Me.BindingSource_OBLIURBA_1.Count

            Dim boCONTAGRE As Boolean = False
            Dim boCONTMODI As Boolean = False
            Dim boCONTELIM As Boolean = False
            Dim boCONTCONS As Boolean = False
            Dim boCONTRECO As Boolean = False

            pro_Permiso_Barra_De_Menu_Formulario_SubFormulario(ContarRegistros, Trim(Me.BindingNavigator_OBLIURBA_1.Name), boCONTAGRE, boCONTMODI, boCONTELIM, boCONTCONS, boCONTRECO)

            Me.cmdAGREGAR_OBLIURBA.Enabled = boCONTAGRE
            Me.cmdMODIFICAR_OBLIURBA.Enabled = boCONTMODI
            Me.cmdELIMINAR_OBLIURBA.Enabled = boCONTELIM
            Me.cmdCONSULTAR_OBLIURBA.Enabled = True
            Me.cmdRECONSULTAR_OBLIURBA.Enabled = boCONTRECO

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub pro_ListaDeValoresObligacionesUrbanisticas()

        Try
            If Me.dgvOBLIURBA.RowCount > 0 Then

                Dim objdatos As New cla_OBLIURBA
                Dim tbldatos As New DataTable

                tbldatos = objdatos.fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_OBLIURBA(CInt(Me.dgvOBLIURBA.SelectedRows.Item(0).Cells("OBURIDRE").Value.ToString()))

                If tbldatos.Rows.Count > 0 Then

                    Me.txtRECONURE.Text = Trim(tbldatos.Rows(0).Item("OBURNURE").ToString)
                    Me.txtRECOFERE.Text = Trim(tbldatos.Rows(0).Item("OBURFERE").ToString)
                    Me.txtRECOVIRE.Text = Trim(tbldatos.Rows(0).Item("OBURVIRE").ToString)
                    Me.txtOBURFEIN.Text = Trim(tbldatos.Rows(0).Item("OBURFEIN").ToString)
                    Me.txtOBURFEFI.Text = Trim(tbldatos.Rows(0).Item("OBURFEFI").ToString)
                    Me.txtLIRAOBSE.Text = Trim(tbldatos.Rows(0).Item("OBUROBSE").ToString)

                    Me.txtRECOCLEN.Text = fun_Buscar_Lista_Valores_CLASENTI(Trim(tbldatos.Rows(0).Item("OBURCLEN").ToString))
                    Me.txtOBURNDIN.Text = CType(fun_Buscar_Lista_Valores_USUARIO(Trim(tbldatos.Rows(0).Item("OBURNDIN"))), String)
                    Me.txtOBURNDFI.Text = CType(fun_Buscar_Lista_Valores_USUARIO(Trim(tbldatos.Rows(0).Item("OBURNDFI"))), String)
                    Me.txtOBURFELI.Text = Trim(tbldatos.Rows(0).Item("OBURFELI").ToString)
                    Me.txtOBURVILI.Text = Trim(tbldatos.Rows(0).Item("OBURVILI").ToString)
                    Me.chkOBURGRCO.Checked = CBool(tbldatos.Rows(0).Item("OBURGRCO"))
                    Me.chkOBURAJLI.Checked = CBool(tbldatos.Rows(0).Item("OBURAJLI"))

                End If

                pro_ReconsultarSolicitante()
                pro_ListaDeValoresSolicitante()

                pro_ReconsultarPredio()
                pro_ListaDeValoresPredio()

                pro_ReconsultarAvaluoComercial()
                pro_ListaDeValoresAvaluoComercial()

                pro_ReconsultarInformacionGeneral()
                pro_ListaDeValoresInformacionGeneral()

                pro_ReconsultarPlanParcial()
                pro_ListaDeValoresPlanParcial()

                pro_ReconsultarLiquidacionGeneral()
                pro_ListaDeValoresLiquidacionGeneral()

                pro_ReconsultarAjusteDeLiquidacion()
                pro_ListaDeValoresAjusteDeLiquidacion()

                pro_ReconsultarReportes()
                pro_ListaDeValoresReportes()

                pro_ReconsultarAdquisicionDePredios()
                pro_ListaDeValoresAdquisicionDePredios()

                pro_ReconsultarEjecucionDeObra()
                pro_ListaDeValoresEjecucionDeObra()

                pro_ReconsultarReportes()
                pro_ListaDeValoresReportes()

                pro_ControldeBindingNavigator()
                pro_LimpiarDocumentos()

                pro_ListadoArchivosDocumentos()

            Else
                pro_LimpiarCamposObligacionesUrbanisticas()
                pro_LimpiarCamposSolicitante()
                pro_LimpiarCamposPredio()
                pro_LimpiarCamposAvaluoCoermcial()
                pro_LimpiarCamposInformacionGeneral()
                pro_LimpiarPlanParcial()
                pro_LimpiarLiquidacionGeneral()
                pro_LimpiarAjusteDeLiquidacion()
                pro_LimpiarReportes()
                pro_LimpiarAdquisicionDePredios()
                pro_LimpiarEjecucionDeObra()
                pro_LimpiarReportes()
                pro_LimpiarDocumentos()

                Me.BindingNavigator_OBURSOLI_1.Enabled = False
                Me.BindingNavigator_OBURPRED_1.Enabled = False
                Me.BindingNavigator_OBURAVCO_1.Enabled = False
                Me.BindingNavigator_OBURINGE_1.Enabled = False
                Me.BindingNavigator_OBURREPO_1.Enabled = False
                Me.BindingNavigator_OBURAJLI_1.Enabled = False
                Me.BindingNavigator_OBURADPR_1.Enabled = False
                Me.BindingNavigator_OBUREJOB_1.Enabled = False

            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub pro_ControldeBindingNavigator()

        If Me.dgvOBLIURBA.RowCount > 0 Then

            Me.BindingNavigator_OBURSOLI_1.Enabled = True
            Me.BindingNavigator_OBURPRED_1.Enabled = True
            Me.BindingNavigator_OBURAVCO_1.Enabled = True
            Me.BindingNavigator_OBURINGE_1.Enabled = True
            Me.BindingNavigator_OBURREPO_1.Enabled = True
            Me.BindingNavigator_OBURAJLI_1.Enabled = True
            Me.BindingNavigator_OBURADPR_1.Enabled = True
            Me.BindingNavigator_OBUREJOB_1.Enabled = True
        Else
            Me.BindingNavigator_OBURSOLI_1.Enabled = False
            Me.BindingNavigator_OBURPRED_1.Enabled = False
            Me.BindingNavigator_OBURAVCO_1.Enabled = False
            Me.BindingNavigator_OBURINGE_1.Enabled = False
            Me.BindingNavigator_OBURREPO_1.Enabled = False
            Me.BindingNavigator_OBURAJLI_1.Enabled = False
            Me.BindingNavigator_OBURADPR_1.Enabled = False
            Me.BindingNavigator_OBUREJOB_1.Enabled = False

        End If

    End Sub
    Private Sub pro_LimpiarCamposObligacionesUrbanisticas()

        Me.txtRECONURE.Text = ""
        Me.txtRECOFERE.Text = ""
        Me.txtRECOVIRE.Text = ""
        Me.txtRECOCLEN.Text = ""
        Me.txtOBURNDIN.Text = ""
        Me.txtOBURFEIN.Text = ""
        Me.txtOBURNDFI.Text = ""
        Me.txtOBURFEFI.Text = ""
        Me.txtLIRAOBSE.Text = ""
        Me.txtOBURFELI.Text = ""
        Me.txtOBURVILI.Text = ""

        Me.chkOBURGRCO.Checked = False
        Me.chkOBURAJLI.Checked = False

        Me.strBARRESTA.Items(2).Text = "Registros : 0"

    End Sub
    Private Sub pro_LimpiarDocumentos()

        Me.lstLISTADO_DOCUMENTOS_PDF.Items.Clear()

    End Sub
    Private Sub pro_EjecutarBotonObservaciones()

        Try
            If Me.dgvOBLIURBA.RowCount > 0 Then

                If MessageBox.Show("¿ Desea ingresar una observación ? ", "Mensaje...", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then

                    Dim stObservacionNueva As String = InputBox("Ingrese la observación.", "Mensaje")

                    If Trim(stObservacionNueva) = "" Then
                        MessageBox.Show("Se requiere una observación.", "Mensaje...", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                        mod_MENSAJE.No_Se_Modifico_El_Registro_En_La_Base_De_Datos()
                    Else

                        Dim stREMUOBSE_ACTUAL As String = ""
                        Dim stREMUOBSE_NUEVA As String = Trim(stObservacionNueva.ToString.ToUpper)

                        Dim obMOGEGEOG As New cla_OBLIURBA
                        Dim dtAJUSGEOG As New DataTable

                        dtAJUSGEOG = obMOGEGEOG.fun_Buscar_ID_OBLIURBA(Me.dgvOBLIURBA.SelectedRows.Item(0).Cells("OBURIDRE").Value.ToString())

                        If dtAJUSGEOG.Rows.Count > 0 Then
                            stREMUOBSE_ACTUAL = Trim(dtAJUSGEOG.Rows(0).Item("OBUROBSE").ToString)
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
                        Dim inMOGEIDRE As Integer = Integer.Parse(Me.dgvOBLIURBA.SelectedRows.Item(0).Cells("OBURIDRE").Value.ToString())

                        ' parametros de la consulta
                        Dim ParametrosConsulta As String = ""

                        ' Concatena la condicion de la consulta
                        ParametrosConsulta += "update OBLIURBA "
                        ParametrosConsulta += "set OBUROBSE = '" & stREMUOBSE_ACTUAL & "' "
                        ParametrosConsulta += "where OBURIDRE = '" & inMOGEIDRE & "' "

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

                        pro_ReconsultarObligacionesUrbanisticas()
                        pro_ListaDeValoresObligacionesUrbanisticas()

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
    Private Sub pro_ListadoArchivosDocumentos()

        Try
            Me.lstLISTADO_DOCUMENTOS_PDF.Items.Clear()

            ' declara la variable
            Dim stRuta As String = ""
            Dim stNewPath As String = ""
            Dim ContentItem As String

            ' instancia la clase
            Dim objRutas As New cla_RUTAS
            Dim tblRutas As New DataTable

            tblRutas = objRutas.fun_Buscar_CODIGO_MANT_RUTAS(22)

            If tblRutas.Rows.Count > 0 AndAlso fun_VerificarCarpetaExistenteDocumentos() = True Then

                stNewPath = Trim(tblRutas.Rows(0).Item("RUTARUTA")) & "\" & Trim(Me.dgvOBLIURBA.SelectedRows.Item(0).Cells("OBURCLEN").Value.ToString) & "-" & _
                                                                            Trim(Me.dgvOBLIURBA.SelectedRows.Item(0).Cells("OBURNURE").Value.ToString) & "-" & _
                                                                            Trim(Me.dgvOBLIURBA.SelectedRows.Item(0).Cells("OBURVIRE").Value.ToString)

                vl_stRutaDocumentosPDF = stNewPath


                ChDir(stNewPath)
                Me.lstLISTADO_DOCUMENTOS_PDF.Items.Clear()

                ContentItem = Dir("*.*")

                If ContentItem <> "" Then
                    Me.lstLISTADO_DOCUMENTOS_PDF.Focus()
                End If

                Do Until ContentItem = ""
                    ' agrega a la lista
                    Me.lstLISTADO_DOCUMENTOS_PDF.Items.Add(ContentItem)

                    'desplaza el registro
                    ContentItem = Dir()
                Loop

            Else
                Me.lstLISTADO_DOCUMENTOS_PDF.Items.Clear()
            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub pro_ActualizaLiquidacionConJustesObligacionUrbanistica(ByVal inOUIGSECU As Integer, _
                                                                       ByVal stOUIGCLEN As String, _
                                                                       ByVal inOUIGNURE As Integer, _
                                                                       ByVal stOUIGFERE As String, _
                                                                       ByVal boOBURAJLI As Boolean)

        Try
            ' buscar cadena de conexion
            Dim oCadenaConexion As New REGLAS_DEL_NEGOCIO.cla_ConnectionString
            Dim stCadenaConexion As String = oCadenaConexion.fun_ConnectionString

            ' crear conexión
            oAdapter = New SqlDataAdapter
            oConexion = New SqlConnection(stCadenaConexion)

            ' abre la conexion
            oConexion.Open()

            ' parametros de la consulta
            Dim ParametrosConsulta As String = ""

            ' Concatena la condicion de la consulta
            ParametrosConsulta += "UPDATE "
            ParametrosConsulta += "OBLIURBA "
            ParametrosConsulta += "SET "
            ParametrosConsulta += "OBURAJLI = '" & CBool(boOBURAJLI) & "' "
            ParametrosConsulta += "WHERE "
            ParametrosConsulta += "OBURSECU = '" & CInt(inOUIGSECU) & "' AND "
            ParametrosConsulta += "OBURCLEN = '" & CStr(Trim(stOUIGCLEN)) & "' AND "
            ParametrosConsulta += "OBURNURE = '" & CInt(inOUIGNURE) & "' AND "
            ParametrosConsulta += "OBURFERE = '" & CStr(Trim(stOUIGFERE)) & "' "

            ' ejecuta la consulta
            oEjecutar = New SqlCommand(ParametrosConsulta, oConexion)

            ' procesa la consulta 
            oEjecutar.CommandTimeout = 0
            oEjecutar.CommandType = CommandType.Text

            oReader = oEjecutar.ExecuteReader

            ' cierra la conexion
            oConexion.Close()
            oReader = Nothing

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub

#End Region

#Region "PROCEDIMIENTO SOLICITANTE"

    Private Sub pro_ReconsultarSolicitante()

        Try
            Dim objdatos As New cla_OBURSOLI

            If boCONSULTA = False Then
                Me.BindingSource_OBURSOLI_1.DataSource = objdatos.fun_Buscar_SECU_X_CONSULTA_PARAMETRIZADA_OBURSOLI(Me.dgvOBLIURBA.SelectedRows.Item(0).Cells("OBURSECU").Value.ToString())
            Else
                Me.BindingSource_OBURSOLI_1.DataSource = objdatos.fun_Buscar_SECU_X_CONSULTA_PARAMETRIZADA_OBURSOLI(Me.dgvOBLIURBA.SelectedRows.Item(0).Cells("OBURSECU").Value.ToString())
            End If

            Me.dgvOBURSOLI_1.DataSource = BindingSource_OBURSOLI_1
            Me.dgvOBURSOLI_2.DataSource = BindingSource_OBURSOLI_1
            Me.BindingNavigator_OBURSOLI_1.BindingSource = BindingSource_OBURSOLI_1

            '=================================================
            '*** CONFIGURA OBJETOS DEL FORMULARIO MAESTRO ***
            '=================================================

            Me.strBARRESTA.Items(2).Text = "Registros : " & Me.BindingSource_OBLIURBA_1.Count

            Me.dgvOBURSOLI_1.Columns("SOLIDESC").HeaderText = "Solicitante"
            Me.dgvOBURSOLI_1.Columns("OUSONUDO").HeaderText = "Nro. Documento"
            Me.dgvOBURSOLI_1.Columns("OUSONOMB").HeaderText = "Nombre(s)"
            Me.dgvOBURSOLI_1.Columns("OUSOPRAP").HeaderText = "Primer apellido"
            Me.dgvOBURSOLI_1.Columns("OUSOSEAP").HeaderText = "Segundo apellido"
            Me.dgvOBURSOLI_1.Columns("OUSODIPR").HeaderText = "Dirección del predio"

            Me.dgvOBURSOLI_1.Columns("OUSOIDRE").Visible = False
            Me.dgvOBURSOLI_1.Columns("OUSOSOLI").Visible = False
            Me.dgvOBURSOLI_1.Columns("OUSOCLEN").Visible = False
            Me.dgvOBURSOLI_1.Columns("OUSODINO").Visible = False
            Me.dgvOBURSOLI_1.Columns("OUSOTELE").Visible = False
            Me.dgvOBURSOLI_1.Columns("OUSOCELU").Visible = False
            Me.dgvOBURSOLI_1.Columns("OUSOCOEL").Visible = False
            Me.dgvOBURSOLI_1.Columns("OUSOCOPO").Visible = False
            Me.dgvOBURSOLI_1.Columns("OUSORESO").Visible = False
            Me.dgvOBURSOLI_1.Columns("OUSONURE").Visible = False
            Me.dgvOBURSOLI_1.Columns("OUSOFERE").Visible = False
            Me.dgvOBURSOLI_1.Columns("OUSOSECU").Visible = False
            Me.dgvOBURSOLI_1.Columns("OUSOESTA").Visible = False
            Me.dgvOBURSOLI_1.Columns("ESTADESC").Visible = False

            Me.dgvOBURSOLI_2.Columns("OUSODINO").HeaderText = "Dirección de notificación"
            Me.dgvOBURSOLI_2.Columns("OUSOTELE").HeaderText = "Telefono"
            Me.dgvOBURSOLI_2.Columns("OUSOCELU").HeaderText = "Celular"
            Me.dgvOBURSOLI_2.Columns("OUSOCOPO").HeaderText = "Nombre del proyecto"
            Me.dgvOBURSOLI_2.Columns("ESTADESC").HeaderText = "Estado"

            Me.dgvOBURSOLI_2.Columns("OUSOIDRE").Visible = False
            Me.dgvOBURSOLI_2.Columns("OUSOSOLI").Visible = False
            Me.dgvOBURSOLI_2.Columns("OUSOCLEN").Visible = False
            Me.dgvOBURSOLI_2.Columns("OUSONUDO").Visible = False
            Me.dgvOBURSOLI_2.Columns("OUSONOMB").Visible = False
            Me.dgvOBURSOLI_2.Columns("OUSOPRAP").Visible = False
            Me.dgvOBURSOLI_2.Columns("OUSOSEAP").Visible = False
            Me.dgvOBURSOLI_2.Columns("OUSODIPR").Visible = False
            Me.dgvOBURSOLI_2.Columns("OUSONURE").Visible = False
            Me.dgvOBURSOLI_2.Columns("OUSOFERE").Visible = False
            Me.dgvOBURSOLI_2.Columns("OUSOSECU").Visible = False
            Me.dgvOBURSOLI_2.Columns("SOLIDESC").Visible = False
            Me.dgvOBURSOLI_2.Columns("OUSOESTA").Visible = False
            Me.dgvOBURSOLI_2.Columns("OUSORESO").Visible = False
            Me.dgvOBURSOLI_2.Columns("OUSOCOEL").Visible = False

            Me.dgvOBURSOLI_1.Columns("OUSODIPR").Width = 200
            Me.dgvOBURSOLI_2.Columns("OUSODINO").Width = 200
            Me.dgvOBURSOLI_2.Columns("OUSOCOPO").Width = 300

            '==================================================
            '*** ASIGNA LOS PRIVILEGIOS DE LA BARRA DE MENU ***
            '==================================================

            Dim ContarRegistros As Integer = Me.BindingSource_OBURSOLI_1.Count

            Dim boCONTAGRE As Boolean = False
            Dim boCONTMODI As Boolean = False
            Dim boCONTELIM As Boolean = False
            Dim boCONTCONS As Boolean = False
            Dim boCONTRECO As Boolean = False

            pro_Permiso_Barra_De_Menu_Formulario_SubFormulario(ContarRegistros, Trim(Me.BindingNavigator_OBURSOLI_1.Name), boCONTAGRE, boCONTMODI, boCONTELIM, boCONTCONS, boCONTRECO)

            Me.cmdAGREGAR_OBURSOLI.Enabled = boCONTAGRE
            Me.cmdMODIFICAR_OBURSOLI.Enabled = boCONTMODI
            Me.cmdELIMINAR_OBURSOLI.Enabled = boCONTELIM
            Me.cmdCONSULTAR_OBURSOLI.Enabled = boCONTCONS
            Me.cmdRECONSULTAR_OBURSOLI.Enabled = boCONTRECO

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub pro_ListaDeValoresSolicitante()

    End Sub
    Private Sub pro_LimpiarCamposSolicitante()

        Me.dgvOBURSOLI_1.DataSource = New DataTable
        Me.dgvOBURSOLI_2.DataSource = New DataTable

    End Sub

#End Region

#Region "PROCEDIMIENTO PREDIO"

    Private Sub pro_ReconsultarPredio()

        Try
            Dim objdatos As New cla_OBURPRED

            If boCONSULTA = False Then
                Me.BindingSource_OBURPRED_1.DataSource = objdatos.fun_Buscar_SECU_X_CONSULTA_PARAMETRIZADA_OBURPRED(Me.dgvOBLIURBA.SelectedRows.Item(0).Cells("OBURSECU").Value.ToString())
            Else
                Me.BindingSource_OBURPRED_1.DataSource = objdatos.fun_Buscar_SECU_X_CONSULTA_PARAMETRIZADA_OBURPRED(Me.dgvOBLIURBA.SelectedRows.Item(0).Cells("OBURSECU").Value.ToString())
            End If

            Me.dgvOBURPRED_1.DataSource = BindingSource_OBURPRED_1
            Me.dgvOBURPRED_2.DataSource = BindingSource_OBURPRED_1
            Me.BindingNavigator_OBURPRED_1.BindingSource = BindingSource_OBURPRED_1

            '=================================================
            '*** CONFIGURA OBJETOS DEL FORMULARIO MAESTRO ***
            '=================================================

            Me.strBARRESTA.Items(2).Text = "Registros : " & Me.BindingSource_OBLIURBA_1.Count

            Me.dgvOBURPRED_1.Columns("OUPRMUNI").HeaderText = "Municipio"
            Me.dgvOBURPRED_1.Columns("OUPRCORR").HeaderText = "Corregimiento"
            Me.dgvOBURPRED_1.Columns("OUPRBARR").HeaderText = "Barrio"
            Me.dgvOBURPRED_1.Columns("OUPRMANZ").HeaderText = "Manzana Vereda"
            Me.dgvOBURPRED_1.Columns("OUPRPRED").HeaderText = "Predio"
            Me.dgvOBURPRED_1.Columns("OUPREDIF").HeaderText = "Edificio"
            Me.dgvOBURPRED_1.Columns("OUPRUNPR").HeaderText = "Unidad Predial"
            Me.dgvOBURPRED_1.Columns("CLSEDESC").HeaderText = "Sector"

            Me.dgvOBURPRED_1.Columns("OUPRIDRE").Visible = False
            Me.dgvOBURPRED_1.Columns("OUPRCLEN").Visible = False
            Me.dgvOBURPRED_1.Columns("OUPRNURE").Visible = False
            Me.dgvOBURPRED_1.Columns("OUPRFERE").Visible = False
            Me.dgvOBURPRED_1.Columns("OUPRSECU").Visible = False

            Me.dgvOBURPRED_1.Columns("OUPRNUFI").Visible = False
            Me.dgvOBURPRED_1.Columns("OUPRARTE").Visible = False
            Me.dgvOBURPRED_1.Columns("OUPRVATP").Visible = False
            Me.dgvOBURPRED_1.Columns("OUPRVACP").Visible = False
            Me.dgvOBURPRED_1.Columns("OUPRAVCA").Visible = False
            Me.dgvOBURPRED_1.Columns("ZOPLDESC").Visible = False
            Me.dgvOBURPRED_1.Columns("ESTADESC").Visible = False
            Me.dgvOBURPRED_1.Columns("OUPRZOPL").Visible = False
            Me.dgvOBURPRED_1.Columns("OUPRESTA").Visible = False
            Me.dgvOBURPRED_1.Columns("OUPRMAIN").Visible = False
            Me.dgvOBURPRED_1.Columns("OUPRCLSE").Visible = False

            Me.dgvOBURPRED_2.Columns("OUPRMAIN").HeaderText = "Matricula Inmobiliria"
            Me.dgvOBURPRED_2.Columns("OUPRNUFI").HeaderText = "Nro. Ficha Predial"
            Me.dgvOBURPRED_2.Columns("OUPRARTE").HeaderText = "Área de terreno m2"
            Me.dgvOBURPRED_2.Columns("OUPRVATP").HeaderText = "Valor Terreno"
            Me.dgvOBURPRED_2.Columns("OUPRVACP").HeaderText = "Valor Construcción"
            Me.dgvOBURPRED_2.Columns("OUPRAVCA").HeaderText = "Avalúo Catastral"
            Me.dgvOBURPRED_2.Columns("ZOPLDESC").HeaderText = "Zona de Planificación"
            Me.dgvOBURPRED_2.Columns("ESTADESC").HeaderText = "Estado"

            Me.dgvOBURPRED_2.Columns("OUPRIDRE").Visible = False
            Me.dgvOBURPRED_2.Columns("OUPRCLEN").Visible = False
            Me.dgvOBURPRED_2.Columns("OUPRNURE").Visible = False
            Me.dgvOBURPRED_2.Columns("OUPRFERE").Visible = False
            Me.dgvOBURPRED_2.Columns("OUPRSECU").Visible = False

            Me.dgvOBURPRED_2.Columns("OUPRMUNI").Visible = False
            Me.dgvOBURPRED_2.Columns("OUPRCORR").Visible = False
            Me.dgvOBURPRED_2.Columns("OUPRBARR").Visible = False
            Me.dgvOBURPRED_2.Columns("OUPRMANZ").Visible = False
            Me.dgvOBURPRED_2.Columns("OUPRPRED").Visible = False
            Me.dgvOBURPRED_2.Columns("OUPREDIF").Visible = False
            Me.dgvOBURPRED_2.Columns("OUPRUNPR").Visible = False
            Me.dgvOBURPRED_2.Columns("CLSEDESC").Visible = False
            Me.dgvOBURPRED_2.Columns("OUPRZOPL").Visible = False
            Me.dgvOBURPRED_2.Columns("OUPRESTA").Visible = False
            Me.dgvOBURPRED_2.Columns("OUPRCLSE").Visible = False

            Me.dgvOBURPRED_2.Columns("OUPRVATP").DefaultCellStyle.Format = "c"
            Me.dgvOBURPRED_2.Columns("OUPRVACP").DefaultCellStyle.Format = "c"
            Me.dgvOBURPRED_2.Columns("OUPRAVCA").DefaultCellStyle.Format = "c"
            Me.dgvOBURPRED_2.Columns("OUPRARTE").DefaultCellStyle.Format = "n"

            Me.dgvOBURPRED_2.Columns("OUPRVATP").DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopRight
            Me.dgvOBURPRED_2.Columns("OUPRVACP").DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopRight
            Me.dgvOBURPRED_2.Columns("OUPRAVCA").DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopRight

            '==================================================
            '*** ASIGNA LOS PRIVILEGIOS DE LA BARRA DE MENU ***
            '==================================================

            Dim ContarRegistros As Integer = Me.BindingSource_OBURPRED_1.Count

            Dim boCONTAGRE As Boolean = False
            Dim boCONTMODI As Boolean = False
            Dim boCONTELIM As Boolean = False
            Dim boCONTCONS As Boolean = False
            Dim boCONTRECO As Boolean = False

            pro_Permiso_Barra_De_Menu_Formulario_SubFormulario(ContarRegistros, Trim(Me.BindingNavigator_OBURPRED_1.Name), boCONTAGRE, boCONTMODI, boCONTELIM, boCONTCONS, boCONTRECO)

            Me.cmdAGREGAR_OBURPRED.Enabled = boCONTAGRE
            Me.cmdMODIFICAR_OBURPRED.Enabled = boCONTMODI
            Me.cmdELIMINAR_OBURPRED.Enabled = boCONTELIM
            Me.cmdCONSULTAR_OBURPRED.Enabled = boCONTCONS
            Me.cmdRECONSULTAR_OBURPRED.Enabled = boCONTRECO

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub pro_ListaDeValoresPredio()

    End Sub
    Private Sub pro_LimpiarCamposPredio()

        Me.dgvOBURPRED_1.DataSource = New DataTable
        Me.dgvOBURPRED_2.DataSource = New DataTable

    End Sub

#End Region

#Region "PROCEDIMIENTO AVALUO COMERCIAL"

    Private Sub pro_ReconsultarAvaluoComercial()

        Try
            Dim objdatos As New cla_OBURAVCO

            If boCONSULTA = False Then
                Me.BindingSource_OBURAVCO_1.DataSource = objdatos.fun_Buscar_SECU_X_CONSULTA_PARAMETRIZADA_OBURAVCO(Me.dgvOBLIURBA.SelectedRows.Item(0).Cells("OBURSECU").Value.ToString())
            Else
                Me.BindingSource_OBURAVCO_1.DataSource = objdatos.fun_Buscar_SECU_X_CONSULTA_PARAMETRIZADA_OBURAVCO(Me.dgvOBLIURBA.SelectedRows.Item(0).Cells("OBURSECU").Value.ToString())
            End If

            Me.dgvOBURAVCO_1.DataSource = BindingSource_OBURAVCO_1
            Me.dgvOBURAVCO_2.DataSource = BindingSource_OBURAVCO_1
            Me.BindingNavigator_OBURPRED_1.BindingSource = BindingSource_OBURAVCO_1

            '================================================
            '*** CONFIGURA OBJETOS DEL FORMULARIO MAESTRO ***
            '================================================

            Me.strBARRESTA.Items(2).Text = "Registros : " & Me.BindingSource_OBLIURBA_1.Count

            Me.dgvOBURAVCO_1.Columns("OUACNUAV").HeaderText = "Nro. Avalúo Comercial"
            Me.dgvOBURAVCO_1.Columns("OUACVIAV").HeaderText = "Vigencia del Avalúo"
            Me.dgvOBURAVCO_1.Columns("OUACEMPR").HeaderText = "Empresa"
            Me.dgvOBURAVCO_1.Columns("OUACFEVI").HeaderText = "Fecha de Visita"
            Me.dgvOBURAVCO_1.Columns("OUACFEIN").HeaderText = "Fecha de Informe"
            Me.dgvOBURAVCO_1.Columns("OUACSOLI").HeaderText = "Solicitante"

            Me.dgvOBURAVCO_1.Columns("OUACIDRE").Visible = False
            Me.dgvOBURAVCO_1.Columns("OUACCLEN").Visible = False
            Me.dgvOBURAVCO_1.Columns("OUACNURE").Visible = False
            Me.dgvOBURAVCO_1.Columns("OUACFERE").Visible = False
            Me.dgvOBURAVCO_1.Columns("OUACSECU").Visible = False

            Me.dgvOBURAVCO_1.Columns("OUACPUNT").Visible = False
            Me.dgvOBURAVCO_1.Columns("OUACPROY").Visible = False
            Me.dgvOBURAVCO_1.Columns("OUACDIRE").Visible = False
            Me.dgvOBURAVCO_1.Columns("OUACARTE").Visible = False
            Me.dgvOBURAVCO_1.Columns("OUACAVCO").Visible = False
            Me.dgvOBURAVCO_1.Columns("OUACACM2").Visible = False
            Me.dgvOBURAVCO_1.Columns("ESTADESC").Visible = False
            Me.dgvOBURAVCO_1.Columns("OUACESTA").Visible = False

            Me.dgvOBURAVCO_2.Columns("OUACPUNT").HeaderText = "Punto"
            Me.dgvOBURAVCO_2.Columns("OUACPROY").HeaderText = "Proyecto"
            Me.dgvOBURAVCO_2.Columns("OUACDIRE").HeaderText = "Dirección"
            Me.dgvOBURAVCO_2.Columns("OUACARTE").HeaderText = "Área de terreno"
            Me.dgvOBURAVCO_2.Columns("OUACAVCO").HeaderText = "Avalúo Comercial"
            Me.dgvOBURAVCO_2.Columns("OUACACM2").HeaderText = "Avalúo Comercial m2"
            Me.dgvOBURAVCO_2.Columns("ESTADESC").HeaderText = "Estado"

            Me.dgvOBURAVCO_2.Columns("OUACIDRE").Visible = False
            Me.dgvOBURAVCO_2.Columns("OUACCLEN").Visible = False
            Me.dgvOBURAVCO_2.Columns("OUACNURE").Visible = False
            Me.dgvOBURAVCO_2.Columns("OUACFERE").Visible = False
            Me.dgvOBURAVCO_2.Columns("OUACSECU").Visible = False

            Me.dgvOBURAVCO_2.Columns("OUACNUAV").Visible = False
            Me.dgvOBURAVCO_2.Columns("OUACVIAV").Visible = False
            Me.dgvOBURAVCO_2.Columns("OUACEMPR").Visible = False
            Me.dgvOBURAVCO_2.Columns("OUACFEVI").Visible = False
            Me.dgvOBURAVCO_2.Columns("OUACFEIN").Visible = False
            Me.dgvOBURAVCO_2.Columns("OUACSOLI").Visible = False
            Me.dgvOBURAVCO_2.Columns("OUACESTA").Visible = False

            Me.dgvOBURAVCO_2.Columns("OUACAVCO").DefaultCellStyle.Format = "c"
            Me.dgvOBURAVCO_2.Columns("OUACACM2").DefaultCellStyle.Format = "c"
            Me.dgvOBURAVCO_2.Columns("OUACARTE").DefaultCellStyle.Format = "n"

            Me.dgvOBURAVCO_2.Columns("OUACAVCO").DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopRight
            Me.dgvOBURAVCO_2.Columns("OUACACM2").DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopRight

            '==================================================
            '*** ASIGNA LOS PRIVILEGIOS DE LA BARRA DE MENU ***
            '==================================================

            Dim ContarRegistros As Integer = Me.BindingSource_OBURAVCO_1.Count

            Dim boCONTAGRE As Boolean = False
            Dim boCONTMODI As Boolean = False
            Dim boCONTELIM As Boolean = False
            Dim boCONTCONS As Boolean = False
            Dim boCONTRECO As Boolean = False

            pro_Permiso_Barra_De_Menu_Formulario_SubFormulario(ContarRegistros, Trim(Me.BindingNavigator_OBURAVCO_1.Name), boCONTAGRE, boCONTMODI, boCONTELIM, boCONTCONS, boCONTRECO)

            Me.cmdAGREGAR_OBURAVCO.Enabled = boCONTAGRE
            Me.cmdMODIFICAR_OBURAVCO.Enabled = boCONTMODI
            Me.cmdELIMINAR_OBURAVCO.Enabled = boCONTELIM
            Me.cmdCONSULTAR_OBURAVCO.Enabled = boCONTCONS
            Me.cmdRECONSULTAR_OBURAVCO.Enabled = boCONTRECO

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub pro_ListaDeValoresAvaluoComercial()

    End Sub
    Private Sub pro_LimpiarCamposAvaluoCoermcial()

        Me.dgvOBURAVCO_1.DataSource = New DataTable
        Me.dgvOBURAVCO_2.DataSource = New DataTable

    End Sub

#End Region

#Region "PROCEDIMIENTO INFORMACION GENERAL"

    Private Sub pro_ReconsultarInformacionGeneral()

        Try
            Dim objdatos As New cla_OBURINGE

            If boCONSULTA = False Then
                Me.BindingSource_OBURINGE_1.DataSource = objdatos.fun_Buscar_SECU_X_CONSULTA_PARAMETRIZADA_OBURINGE(Me.dgvOBLIURBA.SelectedRows.Item(0).Cells("OBURSECU").Value.ToString())
            Else
                Me.BindingSource_OBURINGE_1.DataSource = objdatos.fun_Buscar_SECU_X_CONSULTA_PARAMETRIZADA_OBURINGE(Me.dgvOBLIURBA.SelectedRows.Item(0).Cells("OBURSECU").Value.ToString())
            End If

            Me.dgvOBURINGE_1.DataSource = BindingSource_OBURINGE_1
            Me.dgvOBURINGE_2.DataSource = BindingSource_OBURINGE_1
            Me.BindingNavigator_OBURINGE_1.BindingSource = BindingSource_OBURINGE_1

            '================================================
            '*** CONFIGURA OBJETOS DEL FORMULARIO MAESTRO ***
            '================================================

            Me.strBARRESTA.Items(2).Text = "Registros : " & Me.BindingSource_OBURINGE_1.Count

            Me.dgvOBURINGE_1.Columns("CLOUDESC").HeaderText = "Clase de Obligación"
            Me.dgvOBURINGE_1.Columns("TILIDESC").HeaderText = "Tipo de Liquidación"
            Me.dgvOBURINGE_1.Columns("CLSEDESC").HeaderText = "Clase o Sector"
            Me.dgvOBURINGE_1.Columns("OUIGATLO").HeaderText = "Área Total de Terreno"
            Me.dgvOBURINGE_1.Columns("OUIGATCO").HeaderText = "Área Total de Construcción"
            Me.dgvOBURINGE_1.Columns("OUIGDENS").HeaderText = "Densidad"
            Me.dgvOBURINGE_1.Columns("OUIGUNID").HeaderText = "Nro. de Unidades"
            Me.dgvOBURINGE_1.Columns("OUIGAJLI").HeaderText = "Ajuste de Liquidación"
            Me.dgvOBURINGE_1.Columns("OUIGADLI").HeaderText = "Adición de Liquidación"

            Me.dgvOBURINGE_1.Columns("OUIGIDRE").Visible = False
            Me.dgvOBURINGE_1.Columns("OUIGCLEN").Visible = False
            Me.dgvOBURINGE_1.Columns("OUIGNURE").Visible = False
            Me.dgvOBURINGE_1.Columns("OUIGFERE").Visible = False
            Me.dgvOBURINGE_1.Columns("OUIGSECU").Visible = False

            Me.dgvOBURINGE_1.Columns("OUIGNULI").Visible = False
            Me.dgvOBURINGE_1.Columns("OUIGCLOU").Visible = False
            Me.dgvOBURINGE_1.Columns("OUIGTILI").Visible = False
            Me.dgvOBURINGE_1.Columns("OUIGCLSE").Visible = False
            Me.dgvOBURINGE_1.Columns("OUIGSMLV").Visible = False
            Me.dgvOBURINGE_1.Columns("OUIGESSO").Visible = False
            Me.dgvOBURINGE_1.Columns("ESTRDESC").Visible = False
            Me.dgvOBURINGE_1.Columns("OUIGTIPO").Visible = False
            Me.dgvOBURINGE_1.Columns("TICADESC").Visible = False
            Me.dgvOBURINGE_1.Columns("OUIGAVCA").Visible = False
            Me.dgvOBURINGE_1.Columns("OUIGAVCO").Visible = False
            Me.dgvOBURINGE_1.Columns("OUIGLIQU").Visible = False
            Me.dgvOBURINGE_1.Columns("OUIGPLPA").Visible = False
            Me.dgvOBURINGE_1.Columns("OUIGOBSE").Visible = False
            Me.dgvOBURINGE_1.Columns("ESTADESC").Visible = False

            Me.dgvOBURINGE_2.Columns("OUIGSMLV").HeaderText = "SMMLV"
            Me.dgvOBURINGE_2.Columns("ESTRDESC").HeaderText = "Estrato Socioeconómico"
            Me.dgvOBURINGE_2.Columns("TICADESC").HeaderText = "Tipo"
            Me.dgvOBURINGE_2.Columns("OUIGAVCA").HeaderText = "Avalúo Terreno Catastral m2"
            Me.dgvOBURINGE_2.Columns("OUIGAVCO").HeaderText = "Avalúo Comercial m2"
            Me.dgvOBURINGE_2.Columns("OUIGLIQU").HeaderText = "Valor Liquidado"
            Me.dgvOBURINGE_2.Columns("OUIGPLPA").HeaderText = "Plan Parcial"
            Me.dgvOBURINGE_2.Columns("ESTADESC").HeaderText = "Estado"

            Me.dgvOBURINGE_2.Columns("OUIGIDRE").Visible = False
            Me.dgvOBURINGE_2.Columns("OUIGCLEN").Visible = False
            Me.dgvOBURINGE_2.Columns("OUIGNURE").Visible = False
            Me.dgvOBURINGE_2.Columns("OUIGFERE").Visible = False
            Me.dgvOBURINGE_2.Columns("OUIGSECU").Visible = False
            Me.dgvOBURINGE_2.Columns("OUIGCLOU").Visible = False
            Me.dgvOBURINGE_2.Columns("OUIGNULI").Visible = False

            Me.dgvOBURINGE_2.Columns("OUIGCLOU").Visible = False
            Me.dgvOBURINGE_2.Columns("OUIGTILI").Visible = False
            Me.dgvOBURINGE_2.Columns("TILIDESC").Visible = False
            Me.dgvOBURINGE_2.Columns("CLSEDESC").Visible = False
            Me.dgvOBURINGE_2.Columns("OUIGDENS").Visible = False
            Me.dgvOBURINGE_2.Columns("OUIGATLO").Visible = False
            Me.dgvOBURINGE_2.Columns("OUIGATCO").Visible = False
            Me.dgvOBURINGE_2.Columns("OUIGUNID").Visible = False
            Me.dgvOBURINGE_2.Columns("OUIGESSO").Visible = False
            Me.dgvOBURINGE_2.Columns("OUIGTIPO").Visible = False
            Me.dgvOBURINGE_2.Columns("CLOUDESC").Visible = False
            Me.dgvOBURINGE_2.Columns("OUIGOBSE").Visible = False
            Me.dgvOBURINGE_2.Columns("OUIGCLSE").Visible = False
            Me.dgvOBURINGE_2.Columns("OUIGAJLI").Visible = False
            Me.dgvOBURINGE_2.Columns("OUIGADLI").Visible = False

            Me.dgvOBURINGE_2.Columns("OUIGAVCA").DefaultCellStyle.Format = "c"
            Me.dgvOBURINGE_2.Columns("OUIGAVCO").DefaultCellStyle.Format = "c"
            Me.dgvOBURINGE_2.Columns("OUIGLIQU").DefaultCellStyle.Format = "c"
            Me.dgvOBURINGE_2.Columns("OUIGSMLV").DefaultCellStyle.Format = "c"
            Me.dgvOBURINGE_1.Columns("OUIGATLO").DefaultCellStyle.Format = "n"
            Me.dgvOBURINGE_1.Columns("OUIGATCO").DefaultCellStyle.Format = "n"

            Me.dgvOBURINGE_2.Columns("OUIGAVCA").DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopRight
            Me.dgvOBURINGE_2.Columns("OUIGAVCO").DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopRight
            Me.dgvOBURINGE_2.Columns("OUIGLIQU").DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopRight

            Me.dgvOBURINGE_1.Columns("CLOUDESC").Width = 150

            '==================================================
            '*** ASIGNA LOS PRIVILEGIOS DE LA BARRA DE MENU ***
            '==================================================

            Dim ContarRegistros As Integer = Me.BindingSource_OBURINGE_1.Count

            Dim boCONTAGRE As Boolean = False
            Dim boCONTMODI As Boolean = False
            Dim boCONTELIM As Boolean = False
            Dim boCONTCONS As Boolean = False
            Dim boCONTRECO As Boolean = False

            pro_Permiso_Barra_De_Menu_Formulario_SubFormulario(ContarRegistros, Trim(Me.BindingNavigator_OBURINGE_1.Name), boCONTAGRE, boCONTMODI, boCONTELIM, boCONTCONS, boCONTRECO)

            Me.cmdAGREGAR_OBURINGE.Enabled = boCONTAGRE
            Me.cmdMODIFICAR_OBURINGE.Enabled = boCONTMODI
            Me.cmdELIMINAR_OBURINGE.Enabled = boCONTELIM
            Me.cmdCONSULTAR_OBURINGE.Enabled = boCONTCONS
            Me.cmdRECONSULTAR_OBURINGE.Enabled = boCONTRECO

            If Me.dgvOBLIURBA.RowCount > 0 And Me.dgvOBURINGE_1.RowCount > 0 Then
                Me.cmdLIQUIDAR_OBURINGE.Enabled = boCONTAGRE
                Me.cmdGENERAR_OBURINGE.Enabled = boCONTAGRE
            Else
                Me.cmdLIQUIDAR_OBURINGE.Enabled = False
                Me.cmdGENERAR_OBURINGE.Enabled = False
            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub pro_ListaDeValoresInformacionGeneral()

        Try

            If Me.dgvOBURINGE_1.RowCount > 0 Then

                Dim objdatos As New cla_OBURINGE
                Dim tbldatos As New DataTable

                tbldatos = objdatos.fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_OBURINGE(CInt(Me.dgvOBURINGE_1.SelectedRows.Item(0).Cells("OUIGIDRE").Value.ToString()))

                If tbldatos.Rows.Count > 0 Then

                    Me.txtOUIGOBSE.Text = Trim(tbldatos.Rows(0).Item("OUIGOBSE").ToString)

                End If

            End If

            pro_ReconsultarLiquidacionGeneral()
            pro_ListaDeValoresLiquidacionGeneral()

            pro_ReconsultarAjusteDeLiquidacion()
            pro_ListaDeValoresAjusteDeLiquidacion()

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub pro_LimpiarCamposInformacionGeneral()

        Me.dgvOBURINGE_1.DataSource = New DataTable
        Me.dgvOBURINGE_2.DataSource = New DataTable

        Me.txtOUIGOBSE.Text = ""
        Me.txtOUIGLIQU.Text = ""

    End Sub

#End Region

#Region "PROCEDIMIENTO PLAN PARCIAL"

    Private Sub pro_ReconsultarPlanParcial()

        Try
            ' verifica que exista registro
            If Me.dgvOBURINGE_1.RowCount > 0 Then

                ' instancia la clase
                Dim objdatos1 As New cla_OBURPLPA

                If boCONSULTA = False Then
                    Me.BindingSource_OBURPLPA_1.DataSource = objdatos1.fun_Buscar_CONSULTA_PARAMETRIZADA_OBURPLPA(Me.dgvOBURINGE_1.SelectedRows.Item(0).Cells("OUIGSECU").Value.ToString(), Me.dgvOBURINGE_1.SelectedRows.Item(0).Cells("OUIGCLOU").Value.ToString(), Me.dgvOBURINGE_1.SelectedRows.Item(0).Cells("OUIGNULI").Value.ToString())
                Else
                    Me.BindingSource_OBURPLPA_1.DataSource = objdatos1.fun_Buscar_CONSULTA_PARAMETRIZADA_OBURPLPA(Me.dgvOBURINGE_1.SelectedRows.Item(0).Cells("OUIGSECU").Value.ToString(), Me.dgvOBURINGE_1.SelectedRows.Item(0).Cells("OUIGCLOU").Value.ToString(), Me.dgvOBURINGE_1.SelectedRows.Item(0).Cells("OUIGNULI").Value.ToString())
                End If

                Me.dgvOBURPLPA.DataSource = BindingSource_OBURPLPA_1

                '================================================
                '*** CONFIGURA OBJETOS DEL FORMULARIO MAESTRO ***
                '================================================

                Me.strBARRESTA.Items(2).Text = "Registros : " & Me.BindingSource_OBURPLPA_1.Count

                'Me.dgvOBURPLPA.Columns("OUPPRESO").HeaderText = "Nro. Resolución"
                'Me.dgvOBURPLPA.Columns("OUPPFECH").HeaderText = "Fecha Resolución"
                Me.dgvOBURPLPA.Columns("PLPADESC").HeaderText = "Proyecto Plan Parcial"
                Me.dgvOBURPLPA.Columns("CBPPDESC").HeaderText = "Carga y Beneficio"
                Me.dgvOBURPLPA.Columns("OUPPUAU").HeaderText = "Unidad de Actuación"
                Me.dgvOBURPLPA.Columns("FPPPDESC").HeaderText = "Forma de Pago"
                Me.dgvOBURPLPA.Columns("COFPDESC").HeaderText = "Control de Pago"

                Me.dgvOBURPLPA.Columns("ESTADESC").HeaderText = "Estado"

                Me.dgvOBURPLPA.Columns("OUPPIDRE").Visible = False
                Me.dgvOBURPLPA.Columns("OUPPRESO").Visible = False
                Me.dgvOBURPLPA.Columns("OUPPFECH").Visible = False
                Me.dgvOBURPLPA.Columns("OUPPSECU").Visible = False
                Me.dgvOBURPLPA.Columns("OUPPCLEN").Visible = False
                Me.dgvOBURPLPA.Columns("OUPPNURE").Visible = False
                Me.dgvOBURPLPA.Columns("OUPPFERE").Visible = False
                Me.dgvOBURPLPA.Columns("OUPPFEIN").Visible = False
                Me.dgvOBURPLPA.Columns("OUPPCLOU").Visible = False
                Me.dgvOBURPLPA.Columns("CLOUDESC").Visible = False
                Me.dgvOBURPLPA.Columns("OUPPNULI").Visible = False
                Me.dgvOBURPLPA.Columns("OUPPCABE").Visible = False
                Me.dgvOBURPLPA.Columns("OUPPVIGE").Visible = False
                Me.dgvOBURPLPA.Columns("OUPPFOPA").Visible = False
                Me.dgvOBURPLPA.Columns("OUPPCOFP").Visible = False
                Me.dgvOBURPLPA.Columns("OUPPESTA").Visible = False

                Me.dgvOBURPLPA.Columns("PLPADESC").Width = 200
                Me.dgvOBURPLPA.Columns("CBPPDESC").Width = 300
                'Me.dgvOBURPLPA.Columns("ESTADESC").Width = 100

            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub pro_ListaDeValoresPlanParcial()

        Try



        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub pro_LimpiarPlanParcial()

        Try
            Me.dgvOBURPLPA.DataSource = New DataTable

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub pro_InsertaPlanParcial(ByVal boINSERTAR As Boolean, ByVal boMODIFICAR As Boolean)

        Try

            ' declara la variable
            Dim inOUIGSECU As Integer = 0
            Dim inOUIGCLOU As Integer = 0
            Dim inOUIGNULI As Integer = 0

            ' inserta el registro
            If boINSERTAR = True Then

                ' instancia la clase
                Dim obOBURINGE As New cla_OBURINGE
                Dim dtOBURINGE As New DataTable

                dtOBURINGE = obOBURINGE.fun_Buscar_SECU_X_CONSULTA_PARAMETRIZADA_OBURINGE(Me.dgvOBLIURBA.SelectedRows.Item(0).Cells("OBURSECU").Value.ToString())

                If dtOBURINGE.Rows.Count > 0 Then

                    ' declaro la variable
                    Dim i As Integer = 0

                    For i = 0 To dtOBURINGE.Rows.Count - 1

                        ' almacena los datos
                        inOUIGSECU = CInt(dtOBURINGE.Rows(i).Item("OUIGSECU"))
                        inOUIGCLOU = CInt(dtOBURINGE.Rows(i).Item("OUIGCLOU"))
                        inOUIGNULI = CInt(dtOBURINGE.Rows(i).Item("OUIGNULI"))

                        ' instancia la clase
                        Dim obOBURPLPA As New cla_OBURPLPA
                        Dim dtOBURPLPA As New DataTable

                        dtOBURPLPA = obOBURPLPA.fun_Buscar_CONSULTA_PARAMETRIZADA_OBURPLPA(inOUIGSECU, inOUIGCLOU, inOUIGNULI)

                        ' marcado como plan parcial sin registro
                        If CBool(dtOBURINGE.Rows(i).Item("OUIGPLPA")) = True And dtOBURPLPA.Rows.Count = 0 Then

                            Dim frm_consultar As New frm_insertar_OBURPLPA(Me.dgvOBLIURBA.SelectedRows.Item(0).Cells("OBURSECU").Value.ToString(), _
                                                                           Me.dgvOBLIURBA.SelectedRows.Item(0).Cells("OBURCLEN").Value.ToString(), _
                                                                           Me.dgvOBLIURBA.SelectedRows.Item(0).Cells("OBURNURE").Value.ToString(), _
                                                                           Me.dgvOBLIURBA.SelectedRows.Item(0).Cells("OBURFERE").Value.ToString(), _
                                                                           inOUIGCLOU, _
                                                                           inOUIGNULI)
                            frm_consultar.ShowDialog()

                            ' elimina el registro
                        ElseIf CBool(dtOBURINGE.Rows(i).Item("OUIGPLPA")) = False Then

                            ' instancia la clase
                            Dim obOBURPLPA1 As New cla_OBURPLPA

                            obOBURPLPA1.fun_Eliminar_OBURPLPA(inOUIGSECU, inOUIGCLOU, inOUIGNULI)

                        End If

                    Next

                End If

            End If

            ' modifica el registro
            If boMODIFICAR = True Then

                ' instancia la clase
                Dim obOBURINGE As New cla_OBURINGE
                Dim dtOBURINGE As New DataTable

                dtOBURINGE = obOBURINGE.fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_OBURINGE(Me.dgvOBURINGE_1.SelectedRows.Item(0).Cells("OUIGIDRE").Value.ToString())

                If dtOBURINGE.Rows.Count > 0 Then

                    ' almacena los datos
                    inOUIGSECU = CInt(dtOBURINGE.Rows(0).Item("OUIGSECU"))
                    inOUIGCLOU = CInt(dtOBURINGE.Rows(0).Item("OUIGCLOU"))
                    inOUIGNULI = CInt(dtOBURINGE.Rows(0).Item("OUIGNULI"))

                    ' instancia la clase
                    Dim obOBURPLPA As New cla_OBURPLPA
                    Dim dtOBURPLPA As New DataTable

                    dtOBURPLPA = obOBURPLPA.fun_Buscar_CONSULTA_PARAMETRIZADA_OBURPLPA(inOUIGSECU, inOUIGCLOU, inOUIGNULI)

                    ' marcado como plan parcial sin registro
                    If CBool(dtOBURINGE.Rows(0).Item("OUIGPLPA")) = True And dtOBURPLPA.Rows.Count = 0 Then

                        Dim frm_consultar As New frm_insertar_OBURPLPA(Me.dgvOBLIURBA.SelectedRows.Item(0).Cells("OBURSECU").Value.ToString(), _
                                                                       Me.dgvOBLIURBA.SelectedRows.Item(0).Cells("OBURCLEN").Value.ToString(), _
                                                                       Me.dgvOBLIURBA.SelectedRows.Item(0).Cells("OBURNURE").Value.ToString(), _
                                                                       Me.dgvOBLIURBA.SelectedRows.Item(0).Cells("OBURFERE").Value.ToString(), _
                                                                       inOUIGCLOU, _
                                                                       inOUIGNULI)
                        frm_consultar.ShowDialog()

                    ElseIf CBool(dtOBURINGE.Rows(0).Item("OUIGPLPA")) = False Then

                        ' instancia la clase
                        Dim obOBURPLPA1 As New cla_OBURPLPA

                        obOBURPLPA1.fun_Eliminar_OBURPLPA(inOUIGSECU, inOUIGCLOU, inOUIGNULI)

                    End If

                End If

            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub

#End Region

#Region "PROCEDIMIENTO LIQUIDACION GENERAL"

    Private Sub pro_ReconsultarLiquidacionGeneral()

        Try


            Dim objdatos As New cla_OBURINGE

            Me.BindingSource_OBURLIGE_1.DataSource = objdatos.fun_Buscar_LIQUIDACION_X_CLASE_OBLIGACION_X_OBURINGE(Me.dgvOBLIURBA.SelectedRows.Item(0).Cells("OBURCLEN").Value.ToString(), _
                                                                                                                   Me.dgvOBLIURBA.SelectedRows.Item(0).Cells("OBURNURE").Value.ToString(), _
                                                                                                                   Me.dgvOBLIURBA.SelectedRows.Item(0).Cells("OBURFERE").Value.ToString())


            Me.dgvOBURLIGE.DataSource = BindingSource_OBURLIGE_1
            Me.BindingNavigator_OBURLIGE_1.BindingSource = BindingSource_OBURLIGE_1

            Me.dgvOBURLIGE.Columns("CLOUDESC").HeaderText = "Clase de Obligación"
            Me.dgvOBURLIGE.Columns("OUIGADLI").HeaderText = "Adición de Liquidación"
            Me.dgvOBURLIGE.Columns("CLOULIQU").HeaderText = "Valor Liquidado"

            Me.dgvOBURLIGE.Columns("OUIGCLOU").Visible = False
            Me.dgvOBURLIGE.Columns("CLOULIQU").DefaultCellStyle.Format = "c"
            Me.dgvOBURLIGE.Columns("CLOULIQU").DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopRight

            Dim obOBURINGE As New DataTable

            obOBURINGE = objdatos.fun_Buscar_LIQUIDACION_TOTAL_OBURINGE(Me.dgvOBLIURBA.SelectedRows.Item(0).Cells("OBURCLEN").Value.ToString(), _
                                                                        Me.dgvOBLIURBA.SelectedRows.Item(0).Cells("OBURNURE").Value.ToString(), _
                                                                        Me.dgvOBLIURBA.SelectedRows.Item(0).Cells("OBURFERE").Value.ToString())
            If obOBURINGE.Rows.Count > 0 Then
                Me.txtOULGLIQU.Text = "$ " & fun_Formato_Mascara_Pesos_Enteros(CStr(Trim(obOBURINGE.Rows(0).Item(0).ToString)))
                Me.txtOUIGLIQU.Text = "$ " & fun_Formato_Mascara_Pesos_Enteros(CStr(Trim(obOBURINGE.Rows(0).Item(0).ToString)))
            Else
                Me.txtOULGLIQU.Text = "$ 0"
                Me.txtOUIGLIQU.Text = "$ 0"
            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub pro_ListaDeValoresLiquidacionGeneral()

        Try



        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub pro_LimpiarLiquidacionGeneral()

        Me.txtOULGLIQU.Text = ""

        Me.dgvOBURLIGE.DataSource = New DataTable

    End Sub
    Private Sub pro_GenerarLiquidacionPDF()

        Try
            If MessageBox.Show("¿ Desea generar el documento de liquidación ? ", "Mensaje...", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then

                ' declara la variable
                Dim inTipoReporte As Integer = 0

                If Me.dgvOBURLIGE.SelectedRows.Item(0).Cells("OUIGCLOU").Value.ToString() = 1 Or _
                   Me.dgvOBURLIGE.SelectedRows.Item(0).Cells("OUIGCLOU").Value.ToString() = 2 Or _
                   Me.dgvOBURLIGE.SelectedRows.Item(0).Cells("OUIGCLOU").Value.ToString() = 6 Then
                    inTipoReporte = 1

                ElseIf Me.dgvOBURLIGE.SelectedRows.Item(0).Cells("OUIGCLOU").Value.ToString() = 5 Then
                    inTipoReporte = 2
                End If

                pro_Genera_Reporte_Liquidacion_Obligaciones_Urbanisticas(CInt(Me.dgvOBLIURBA.SelectedRows.Item(0).Cells("OBURIDRE").Value.ToString()), inTipoReporte, CBool(Me.dgvOBURLIGE.SelectedRows.Item(0).Cells("OUIGADLI").Value.ToString()))

                pro_ListadoArchivosDocumentos()
                Me.TabMAESTRO_2.SelectTab(TabDocumentos)

            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub

#End Region

#Region "PROCEDIMIENTO AJUSTE DE LIQUIDACION"

    Private Sub pro_ReconsultarAjusteDeLiquidacion()

        Try
            ' instancia la clase
            Dim objdatos1 As New cla_OBURINGE

            If boCONSULTA = False Then
                Me.BindingSource_OBURINGE_1.DataSource = objdatos1.fun_Buscar_SECU_X_CONSULTA_PARAMETRIZADA_OBURINGE(Me.dgvOBLIURBA.SelectedRows.Item(0).Cells("OBURSECU").Value.ToString())
            Else
                Me.BindingSource_OBURINGE_1.DataSource = objdatos1.fun_Buscar_SECU_X_CONSULTA_PARAMETRIZADA_OBURINGE(Me.dgvOBLIURBA.SelectedRows.Item(0).Cells("OBURSECU").Value.ToString())
            End If

            Me.dgvOBURAJLI_1.DataSource = BindingSource_OBURINGE_1

            '================================================
            '*** CONFIGURA OBJETOS DEL FORMULARIO MAESTRO ***
            '================================================

            Me.strBARRESTA.Items(2).Text = "Registros : " & Me.BindingSource_OBURINGE_1.Count

            Me.dgvOBURAJLI_1.Columns("CLOUDESC").HeaderText = "Clase de Obligación"
            Me.dgvOBURAJLI_1.Columns("TILIDESC").HeaderText = "Tipo de Liquidación"
            Me.dgvOBURAJLI_1.Columns("CLSEDESC").HeaderText = "Clase o Sector"
            Me.dgvOBURAJLI_1.Columns("ESTRDESC").HeaderText = "Estrato Socioeconómico"
            Me.dgvOBURAJLI_1.Columns("TICADESC").HeaderText = "Tipo"
            Me.dgvOBURAJLI_1.Columns("OUIGLIQU").HeaderText = "Valor Liquidado"
            Me.dgvOBURAJLI_1.Columns("OUIGPLPA").HeaderText = "Plan Parcial"
            Me.dgvOBURAJLI_1.Columns("ESTADESC").HeaderText = "Estado"

            Me.dgvOBURAJLI_1.Columns("OUIGIDRE").Visible = False
            Me.dgvOBURAJLI_1.Columns("OUIGCLEN").Visible = False
            Me.dgvOBURAJLI_1.Columns("OUIGNURE").Visible = False
            Me.dgvOBURAJLI_1.Columns("OUIGFERE").Visible = False
            Me.dgvOBURAJLI_1.Columns("OUIGSECU").Visible = False

            Me.dgvOBURAJLI_1.Columns("OUIGNULI").Visible = False
            Me.dgvOBURAJLI_1.Columns("OUIGCLOU").Visible = False
            Me.dgvOBURAJLI_1.Columns("OUIGTILI").Visible = False
            Me.dgvOBURAJLI_1.Columns("OUIGCLSE").Visible = False
            Me.dgvOBURAJLI_1.Columns("OUIGSMLV").Visible = False
            Me.dgvOBURAJLI_1.Columns("OUIGESSO").Visible = False
            Me.dgvOBURAJLI_1.Columns("OUIGTIPO").Visible = False
            Me.dgvOBURAJLI_1.Columns("OUIGAVCA").Visible = False
            Me.dgvOBURAJLI_1.Columns("OUIGAVCO").Visible = False
            Me.dgvOBURAJLI_1.Columns("OUIGOBSE").Visible = False
            Me.dgvOBURAJLI_1.Columns("OUIGCLOU").Visible = False
            Me.dgvOBURAJLI_1.Columns("OUIGTILI").Visible = False
            Me.dgvOBURAJLI_1.Columns("OUIGDENS").Visible = False
            Me.dgvOBURAJLI_1.Columns("OUIGATLO").Visible = False
            Me.dgvOBURAJLI_1.Columns("OUIGATCO").Visible = False
            Me.dgvOBURAJLI_1.Columns("OUIGUNID").Visible = False
            Me.dgvOBURAJLI_1.Columns("OUIGESSO").Visible = False
            Me.dgvOBURAJLI_1.Columns("OUIGTIPO").Visible = False
            Me.dgvOBURAJLI_1.Columns("OUIGOBSE").Visible = False
            Me.dgvOBURAJLI_1.Columns("OUIGCLSE").Visible = False
            Me.dgvOBURAJLI_1.Columns("OUIGATLO").Visible = False
            Me.dgvOBURAJLI_1.Columns("OUIGATCO").Visible = False
            Me.dgvOBURAJLI_1.Columns("OUIGDENS").Visible = False
            Me.dgvOBURAJLI_1.Columns("OUIGUNID").Visible = False
            Me.dgvOBURAJLI_1.Columns("OUIGAJLI").Visible = False
            Me.dgvOBURAJLI_1.Columns("OUIGADLI").Visible = False

            Me.dgvOBURAJLI_1.Columns("OUIGLIQU").DefaultCellStyle.Format = "c"
            Me.dgvOBURAJLI_1.Columns("OUIGLIQU").DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopRight
            Me.dgvOBURAJLI_1.Columns("CLOUDESC").Width = 150

            ' verifica los datos principales
            If Me.dgvOBURAJLI_1.RowCount > 0 Then

                ' instancia la clase
                Dim objdatos As New cla_OBURAJLI

                If boCONSULTA = False Then
                    Me.BindingSource_OBURAJLI_1.DataSource = objdatos.fun_Buscar_AJLI_X_CONSULTA_PARAMETRIZADA_OBURAJLI(Me.dgvOBURAJLI_1.SelectedRows.Item(0).Cells("OUIGSECU").Value.ToString(), _
                                                                                                                        Me.dgvOBURAJLI_1.SelectedRows.Item(0).Cells("OUIGCLEN").Value.ToString(), _
                                                                                                                        Me.dgvOBURAJLI_1.SelectedRows.Item(0).Cells("OUIGNURE").Value.ToString(), _
                                                                                                                        Me.dgvOBURAJLI_1.SelectedRows.Item(0).Cells("OUIGFERE").Value.ToString(), _
                                                                                                                        Me.dgvOBURAJLI_1.SelectedRows.Item(0).Cells("OUIGCLOU").Value.ToString(), _
                                                                                                                        Me.dgvOBURAJLI_1.SelectedRows.Item(0).Cells("OUIGNULI").Value.ToString())
                Else
                    Me.BindingSource_OBURAJLI_1.DataSource = objdatos.fun_Buscar_AJLI_X_CONSULTA_PARAMETRIZADA_OBURAJLI(Me.dgvOBURAJLI_1.SelectedRows.Item(0).Cells("OUIGSECU").Value.ToString(), _
                                                                                                                        Me.dgvOBURAJLI_1.SelectedRows.Item(0).Cells("OUIGCLEN").Value.ToString(), _
                                                                                                                        Me.dgvOBURAJLI_1.SelectedRows.Item(0).Cells("OUIGNURE").Value.ToString(), _
                                                                                                                        Me.dgvOBURAJLI_1.SelectedRows.Item(0).Cells("OUIGFERE").Value.ToString(), _
                                                                                                                        Me.dgvOBURAJLI_1.SelectedRows.Item(0).Cells("OUIGCLOU").Value.ToString(), _
                                                                                                                        Me.dgvOBURAJLI_1.SelectedRows.Item(0).Cells("OUIGNULI").Value.ToString())
                End If

                Me.dgvOBURAJLI_2.DataSource = BindingSource_OBURAJLI_1
                Me.BindingNavigator_OBURAJLI_1.BindingSource = BindingSource_OBURAJLI_1

                '================================================
                '*** CONFIGURA OBJETOS DEL FORMULARIO MAESTRO ***
                '================================================

                Me.strBARRESTA.Items(2).Text = "Registros : " & Me.BindingSource_OBURINGE_1.Count

                Me.dgvOBURAJLI_2.Columns("OUALLIQU").HeaderText = "Liquidación Anterior"
                Me.dgvOBURAJLI_2.Columns("OUALLIAJ").HeaderText = "Liquidación Actual"
                Me.dgvOBURAJLI_2.Columns("OUALFEIN").HeaderText = "Fecha de Ingreso"
                Me.dgvOBURAJLI_2.Columns("OUALUSIN").HeaderText = "Usuario"
                Me.dgvOBURAJLI_2.Columns("OUALMAQU").HeaderText = "Estación"

                Me.dgvOBURAJLI_2.Columns("OUALIDRE").Visible = False
                Me.dgvOBURAJLI_2.Columns("CLOUDESC").Visible = False
                Me.dgvOBURAJLI_2.Columns("OUALSECU").Visible = False
                Me.dgvOBURAJLI_2.Columns("OUALCLEN").Visible = False
                Me.dgvOBURAJLI_2.Columns("OUALNURE").Visible = False
                Me.dgvOBURAJLI_2.Columns("OUALFERE").Visible = False
                Me.dgvOBURAJLI_2.Columns("OUALCLOU").Visible = False
                Me.dgvOBURAJLI_2.Columns("OUALNULI").Visible = False
                Me.dgvOBURAJLI_2.Columns("OUALNUAL").Visible = False
                Me.dgvOBURAJLI_2.Columns("OUALOBSE").Visible = False

                Me.dgvOBURAJLI_2.Columns("OUALLIQU").DefaultCellStyle.Format = "c"
                Me.dgvOBURAJLI_2.Columns("OUALLIAJ").DefaultCellStyle.Format = "c"
                Me.dgvOBURAJLI_2.Columns("OUALLIQU").DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopRight
                Me.dgvOBURAJLI_2.Columns("OUALLIAJ").DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopRight

            End If


            '==================================================
            '*** ASIGNA LOS PRIVILEGIOS DE LA BARRA DE MENU ***
            '==================================================

            Dim ContarRegistros As Integer = Me.BindingSource_OBURAJLI_1.Count

            Dim boCONTAGRE As Boolean = False
            Dim boCONTMODI As Boolean = False
            Dim boCONTELIM As Boolean = False
            Dim boCONTCONS As Boolean = False
            Dim boCONTRECO As Boolean = False

            pro_Permiso_Barra_De_Menu_Formulario_SubFormulario(ContarRegistros, Trim(Me.BindingNavigator_OBURAJLI_1.Name), boCONTAGRE, boCONTMODI, boCONTELIM, boCONTCONS, boCONTRECO)

            Me.cmdAGREGAR_OBURAJLI.Enabled = boCONTAGRE
            Me.cmdMODIFICAR_OBURAJLI.Enabled = boCONTMODI
            Me.cmdELIMINAR_OBURAJLI.Enabled = boCONTELIM
            Me.cmdCONSULTAR_OBURAJLI.Enabled = boCONTCONS
            Me.cmdRECONSULTAR_OBURAJLI.Enabled = boCONTRECO


        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub pro_ListaDeValoresAjusteDeLiquidacion()

        Try
            If Me.dgvOBURAJLI_2.RowCount > 0 Then

                Dim objdatos As New cla_OBURAJLI
                Dim tbldatos As New DataTable

                tbldatos = objdatos.fun_Buscar_AJLI_X_CONSULTA_PARAMETRIZADA_OBURAJLI(CInt(Me.dgvOBURAJLI_2.SelectedRows.Item(0).Cells("OUALSECU").Value.ToString()), _
                                                                                      CStr(Me.dgvOBURAJLI_2.SelectedRows.Item(0).Cells("OUALCLEN").Value.ToString()), _
                                                                                      CInt(Me.dgvOBURAJLI_2.SelectedRows.Item(0).Cells("OUALNURE").Value.ToString()), _
                                                                                      CStr(Me.dgvOBURAJLI_2.SelectedRows.Item(0).Cells("OUALFERE").Value.ToString()), _
                                                                                      CInt(Me.dgvOBURAJLI_2.SelectedRows.Item(0).Cells("OUALCLOU").Value.ToString()), _
                                                                                      CInt(Me.dgvOBURAJLI_2.SelectedRows.Item(0).Cells("OUALNULI").Value.ToString()))



                If tbldatos.Rows.Count > 0 Then

                    Me.txtOUALOBSE.Text = Trim(tbldatos.Rows(0).Item("OUALOBSE").ToString)

                End If

            Else

                Me.txtOUALOBSE.Text = ""

            End If

            If Me.dgvOBLIURBA.RowCount > 0 Then

                ' instancia la clase
                Dim obOBURAJLI As New cla_OBURAJLI
                Dim dtOBURAJLI As New DataTable

                dtOBURAJLI = obOBURAJLI.fun_Buscar_SECU_X_CONSULTA_PARAMETRIZADA_OBURAJLI(Me.dgvOBLIURBA.SelectedRows.Item(0).Cells("OBURSECU").Value.ToString())

                If dtOBURAJLI.Rows.Count = 0 Then

                    pro_ActualizaLiquidacionConJustesObligacionUrbanistica(CInt(Me.dgvOBLIURBA.SelectedRows.Item(0).Cells("OBURSECU").Value.ToString()), _
                                                                           CStr(Me.dgvOBLIURBA.SelectedRows.Item(0).Cells("OBURCLEN").Value.ToString()), _
                                                                           CInt(Me.dgvOBLIURBA.SelectedRows.Item(0).Cells("OBURNURE").Value.ToString()), _
                                                                           CStr(Me.dgvOBLIURBA.SelectedRows.Item(0).Cells("OBURFERE").Value.ToString()), False)
                End If

            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub pro_ListaDeValoresAjusteDeLiquidacionPorAjuste()

        Try
            If Me.dgvOBURAJLI_2.RowCount > 0 Then

                Dim objdatos As New cla_OBURAJLI
                Dim tbldatos As New DataTable

                tbldatos = objdatos.fun_Buscar_AJLI_X_CONSULTA_PARAMETRIZADA_OBURAJLI(CInt(Me.dgvOBURAJLI_2.SelectedRows.Item(0).Cells("OUALSECU").Value.ToString()), _
                                                                                      CStr(Me.dgvOBURAJLI_2.SelectedRows.Item(0).Cells("OUALCLEN").Value.ToString()), _
                                                                                      CInt(Me.dgvOBURAJLI_2.SelectedRows.Item(0).Cells("OUALNURE").Value.ToString()), _
                                                                                      CStr(Me.dgvOBURAJLI_2.SelectedRows.Item(0).Cells("OUALFERE").Value.ToString()), _
                                                                                      CInt(Me.dgvOBURAJLI_2.SelectedRows.Item(0).Cells("OUALCLOU").Value.ToString()), _
                                                                                      CInt(Me.dgvOBURAJLI_2.SelectedRows.Item(0).Cells("OUALNULI").Value.ToString()), _
                                                                                      CInt(Me.dgvOBURAJLI_2.SelectedRows.Item(0).Cells("OUALNUAL").Value.ToString()))



                If tbldatos.Rows.Count > 0 Then

                    Me.txtOUALOBSE.Text = Trim(tbldatos.Rows(0).Item("OUALOBSE").ToString)

                End If

            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub pro_LimpiarAjusteDeLiquidacion()

        Try
            Me.dgvOBURAJLI_1.DataSource = New DataTable
            Me.dgvOBURAJLI_2.DataSource = New DataTable

            Me.txtOUALOBSE.Text = ""

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub

#End Region

#Region "PROCEDIMIENTO REPORTES"

    Private Sub pro_ReconsultarReportes()

        Try
            '==================================================
            '*** ASIGNA LOS PRIVILEGIOS DE LA BARRA DE MENU ***
            '==================================================

            Dim ContarRegistros As Integer = 1

            Dim boCONTAGRE As Boolean = False
            Dim boCONTMODI As Boolean = False
            Dim boCONTELIM As Boolean = False
            Dim boCONTCONS As Boolean = False
            Dim boCONTRECO As Boolean = False

            pro_Permiso_Barra_De_Menu_Formulario_SubFormulario(ContarRegistros, Trim(Me.BindingNavigator_OBURREPO_1.Name), boCONTAGRE, boCONTMODI, boCONTELIM, boCONTCONS, boCONTRECO)

            Me.BindingNavigator_OBURREPO_1.Enabled = boCONTAGRE

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub pro_ListaDeValoresReportes()

        Try


        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub pro_LimpiarReportes()

        Me.txtREPOTOTA.Text = ""

        Me.dgvOBURREPO.DataSource = New DataTable

    End Sub

    Private Sub pro_01_LiquidaciónTotal()

        Try
            ' limpia el total
            Me.txtREPOTOTA.Text = ""

            ' buscar cadena de conexion
            Dim oCadenaConexion As New REGLAS_DEL_NEGOCIO.cla_ConnectionString
            Dim stCadenaConexion As String = oCadenaConexion.fun_ConnectionString

            ' crea el datatable
            dt = New DataTable

            ' crear conexión
            oAdapter = New SqlDataAdapter
            oConexion = New SqlConnection(stCadenaConexion)

            ' abre la conexion
            oConexion.Open()

            ' parametros de la consulta
            Dim ParametrosConsulta As String = ""

            ' Concatena la condicion de la consulta
            ParametrosConsulta += "SELECT "
            ParametrosConsulta += "SUM(OUIGLIQU) AS 'Total_liquidado' "
            ParametrosConsulta += "FROM "
            ParametrosConsulta += "OBURINGE "
            ParametrosConsulta += "WHERE "
            ParametrosConsulta += "OUIGESTA = 'ac' AND "
            ParametrosConsulta += "EXISTS(SELECT 1 FROM OBLIURBA WHERE OBURCLEN = OUIGCLEN AND OBURNURE = OUIGNURE AND OBURFERE = OUIGFERE AND OBURESTA = 'ac') "


            ' ejecuta la consulta
            oEjecutar = New SqlCommand(ParametrosConsulta, oConexion)

            ' procesa la consulta 
            oEjecutar.CommandTimeout = 0
            oEjecutar.CommandType = CommandType.Text
            oAdapter.SelectCommand = oEjecutar

            ' llena el datatable 
            oAdapter.Fill(dt)

            ' cierra la conexion
            oConexion.Close()

            ' realiza la insercion mediante la consulta
            If dt.Rows.Count > 0 Then

                Me.BindingSource_OBURREPO_1.DataSource = dt
                Me.dgvOBURREPO.DataSource = Me.BindingSource_OBURREPO_1.DataSource
                Me.BindingNavigator_OBURREPO_1.BindingSource = Me.BindingSource_OBURREPO_1

                Me.dgvOBURREPO.Columns("Total_liquidado").HeaderText = "Total liquidado"
                Me.dgvOBURREPO.Columns("Total_liquidado").DefaultCellStyle.Format = "c"

            Else
                Me.BindingSource_OBURREPO_1.DataSource = dt
                Me.dgvOBURREPO.DataSource = Me.BindingSource_OBURREPO_1.DataSource
                Me.BindingNavigator_OBURREPO_1.BindingSource = Me.BindingSource_OBURREPO_1

                mod_MENSAJE.Consulta_No_Encontro_Registros()
            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub pro_02_LiquidacionClaseDeObligacion()

        Try
            ' limpia el total
            Me.txtREPOTOTA.Text = ""

            ' buscar cadena de conexion
            Dim oCadenaConexion As New REGLAS_DEL_NEGOCIO.cla_ConnectionString
            Dim stCadenaConexion As String = oCadenaConexion.fun_ConnectionString

            ' crea el datatable
            dt = New DataTable

            ' crear conexión
            oAdapter = New SqlDataAdapter
            oConexion = New SqlConnection(stCadenaConexion)

            ' abre la conexion
            oConexion.Open()

            ' parametros de la consulta
            Dim ParametrosConsulta As String = ""

            ' Concatena la condicion de la consulta
            ParametrosConsulta += "SELECT "
            ParametrosConsulta += "CLOUDESC AS 'Clase_De_Obligacion', "
            ParametrosConsulta += "SUM(OUIGLIQU) AS 'Total_liquidado' "
            ParametrosConsulta += "FROM "
            ParametrosConsulta += "OBURINGE, MANT_CLASOBUR "
            ParametrosConsulta += "WHERE "
            ParametrosConsulta += "OUIGCLOU = CLOUCODI AND "
            ParametrosConsulta += "OUIGESTA = 'ac' AND "
            ParametrosConsulta += "EXISTS(SELECT 1 FROM OBLIURBA WHERE OBURCLEN = OUIGCLEN AND OBURNURE = OUIGNURE AND OBURFERE = OUIGFERE AND OBURESTA = 'ac') "
            ParametrosConsulta += "GROUP BY "
            ParametrosConsulta += "CLOUDESC "

            ' ejecuta la consulta
            oEjecutar = New SqlCommand(ParametrosConsulta, oConexion)

            ' procesa la consulta 
            oEjecutar.CommandTimeout = 0
            oEjecutar.CommandType = CommandType.Text
            oAdapter.SelectCommand = oEjecutar

            ' llena el datatable 
            oAdapter.Fill(dt)

            ' cierra la conexion
            oConexion.Close()

            ' realiza la insercion mediante la consulta
            If dt.Rows.Count > 0 Then

                Me.BindingSource_OBURREPO_1.DataSource = dt
                Me.dgvOBURREPO.DataSource = Me.BindingSource_OBURREPO_1.DataSource
                Me.BindingNavigator_OBURREPO_1.BindingSource = Me.BindingSource_OBURREPO_1

                Me.dgvOBURREPO.Columns("Clase_De_Obligacion").HeaderText = "Clase de Obligación"
                Me.dgvOBURREPO.Columns("Total_liquidado").HeaderText = "Total liquidado"
                Me.dgvOBURREPO.Columns("Total_liquidado").DefaultCellStyle.Format = "c"

                Dim loTotal As Long = 0
                Dim i As Integer = 0

                For i = 0 To dt.Rows.Count - 1
                    loTotal += CLng(dt.Rows(i).Item("Total_liquidado"))
                Next

                Me.txtREPOTOTA.Text = "$ " & fun_Formato_Mascara_Pesos_Enteros(CStr(loTotal))

            Else
                Me.BindingSource_OBURREPO_1.DataSource = New DataTable
                Me.dgvOBURREPO.DataSource = Me.BindingSource_OBURREPO_1.DataSource
                Me.BindingNavigator_OBURREPO_1.BindingSource = Me.BindingSource_OBURREPO_1

                Me.txtREPOTOTA.Text = ""

                mod_MENSAJE.Consulta_No_Encontro_Registros()
            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub pro_03_LiquidacionClaseDeObligacionPorVigencia()

        Try
            ' limpia el total
            Me.txtREPOTOTA.Text = ""

            ' buscar cadena de conexion
            Dim oCadenaConexion As New REGLAS_DEL_NEGOCIO.cla_ConnectionString
            Dim stCadenaConexion As String = oCadenaConexion.fun_ConnectionString

            ' crea el datatable
            dt = New DataTable

            ' crear conexión
            oAdapter = New SqlDataAdapter
            oConexion = New SqlConnection(stCadenaConexion)

            ' abre la conexion
            oConexion.Open()

            ' parametros de la consulta
            Dim ParametrosConsulta As String = ""

            ' Concatena la condicion de la consulta
            ParametrosConsulta += "SELECT "
            ParametrosConsulta += "VIGECODI AS 'Vigencia', "
            ParametrosConsulta += "CLOUDESC AS 'Clase_De_Obligacion', "
            ParametrosConsulta += "SUM(OUIGLIQU) AS 'Total_liquidado' "
            ParametrosConsulta += "FROM "
            ParametrosConsulta += "OBLIURBA, OBURINGE, MANT_CLASOBUR, VIGENCIA "
            ParametrosConsulta += "WHERE "
            ParametrosConsulta += "OBURCLEN = OUIGCLEN AND "
            ParametrosConsulta += "OBURNURE = OUIGNURE AND "
            ParametrosConsulta += "OBURFERE = OUIGFERE AND "
            ParametrosConsulta += "OBURVILI = VIGECODI AND "
            ParametrosConsulta += "OUIGCLOU = CLOUCODI AND "
            ParametrosConsulta += "OUIGESTA = 'ac' AND "
            ParametrosConsulta += "OBURESTA = 'ac' "
            ParametrosConsulta += "GROUP BY "
            ParametrosConsulta += "VIGECODI, CLOUDESC "
            ParametrosConsulta += "ORDER BY "
            ParametrosConsulta += "VIGECODI, CLOUDESC "

            ' ejecuta la consulta
            oEjecutar = New SqlCommand(ParametrosConsulta, oConexion)

            ' procesa la consulta 
            oEjecutar.CommandTimeout = 0
            oEjecutar.CommandType = CommandType.Text
            oAdapter.SelectCommand = oEjecutar

            ' llena el datatable 
            oAdapter.Fill(dt)

            ' cierra la conexion
            oConexion.Close()

            ' realiza la insercion mediante la consulta
            If dt.Rows.Count > 0 Then

                Me.BindingSource_OBURREPO_1.DataSource = dt
                Me.dgvOBURREPO.DataSource = Me.BindingSource_OBURREPO_1.DataSource
                Me.BindingNavigator_OBURREPO_1.BindingSource = Me.BindingSource_OBURREPO_1

                Me.dgvOBURREPO.Columns("Vigencia").HeaderText = "Vigencia"
                Me.dgvOBURREPO.Columns("Clase_De_Obligacion").HeaderText = "Clase de Obligación"
                Me.dgvOBURREPO.Columns("Total_liquidado").HeaderText = "Total liquidado"
                Me.dgvOBURREPO.Columns("Total_liquidado").DefaultCellStyle.Format = "c"

                Dim loTotal As Long = 0
                Dim i As Integer = 0

                For i = 0 To dt.Rows.Count - 1
                    loTotal += CLng(dt.Rows(i).Item("Total_liquidado"))
                Next

                Me.txtREPOTOTA.Text = "$ " & fun_Formato_Mascara_Pesos_Enteros(CStr(loTotal))

            Else
                Me.BindingSource_OBURREPO_1.DataSource = New DataTable
                Me.dgvOBURREPO.DataSource = Me.BindingSource_OBURREPO_1.DataSource
                Me.BindingNavigator_OBURREPO_1.BindingSource = Me.BindingSource_OBURREPO_1

                Me.txtREPOTOTA.Text = ""

                mod_MENSAJE.Consulta_No_Encontro_Registros()
            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub pro_04_LiquidacionTotalPorVigencia()

        Try
            ' limpia el total
            Me.txtREPOTOTA.Text = ""

            ' buscar cadena de conexion
            Dim oCadenaConexion As New REGLAS_DEL_NEGOCIO.cla_ConnectionString
            Dim stCadenaConexion As String = oCadenaConexion.fun_ConnectionString

            ' crea el datatable
            dt = New DataTable

            ' crear conexión
            oAdapter = New SqlDataAdapter
            oConexion = New SqlConnection(stCadenaConexion)

            ' abre la conexion
            oConexion.Open()

            ' parametros de la consulta
            Dim ParametrosConsulta As String = ""

            ' Concatena la condicion de la consulta
            ParametrosConsulta += "SELECT "
            ParametrosConsulta += "VIGECODI AS 'Vigencia', "
            ParametrosConsulta += "SUM(OUIGLIQU) AS 'Total_liquidado' "
            ParametrosConsulta += "FROM "
            ParametrosConsulta += "OBLIURBA, OBURINGE, VIGENCIA "
            ParametrosConsulta += "WHERE "
            ParametrosConsulta += "OBURCLEN = OUIGCLEN AND "
            ParametrosConsulta += "OBURNURE = OUIGNURE AND "
            ParametrosConsulta += "OBURFERE = OUIGFERE AND "
            ParametrosConsulta += "OBURVILI = VIGECODI AND "
            ParametrosConsulta += "OUIGESTA = 'ac' AND "
            ParametrosConsulta += "OBURESTA = 'ac' "
            ParametrosConsulta += "GROUP BY "
            ParametrosConsulta += "VIGECODI "
            ParametrosConsulta += "ORDER BY "
            ParametrosConsulta += "VIGECODI "

            ' ejecuta la consulta
            oEjecutar = New SqlCommand(ParametrosConsulta, oConexion)

            ' procesa la consulta 
            oEjecutar.CommandTimeout = 0
            oEjecutar.CommandType = CommandType.Text
            oAdapter.SelectCommand = oEjecutar

            ' llena el datatable 
            oAdapter.Fill(dt)

            ' cierra la conexion
            oConexion.Close()

            ' realiza la insercion mediante la consulta
            If dt.Rows.Count > 0 Then

                Me.BindingSource_OBURREPO_1.DataSource = dt
                Me.dgvOBURREPO.DataSource = Me.BindingSource_OBURREPO_1.DataSource
                Me.BindingNavigator_OBURREPO_1.BindingSource = Me.BindingSource_OBURREPO_1

                Me.dgvOBURREPO.Columns("Vigencia").HeaderText = "Vigencia"
                Me.dgvOBURREPO.Columns("Total_liquidado").HeaderText = "Total liquidado"
                Me.dgvOBURREPO.Columns("Total_liquidado").DefaultCellStyle.Format = "c"

                Dim loTotal As Long = 0
                Dim i As Integer = 0

                For i = 0 To dt.Rows.Count - 1
                    loTotal += CLng(dt.Rows(i).Item("Total_liquidado"))
                Next

                Me.txtREPOTOTA.Text = "$ " & fun_Formato_Mascara_Pesos_Enteros(CStr(loTotal))

            Else
                Me.BindingSource_OBURREPO_1.DataSource = New DataTable
                Me.dgvOBURREPO.DataSource = Me.BindingSource_OBURREPO_1.DataSource
                Me.BindingNavigator_OBURREPO_1.BindingSource = Me.BindingSource_OBURREPO_1

                Me.txtREPOTOTA.Text = ""

                mod_MENSAJE.Consulta_No_Encontro_Registros()
            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub pro_05_LiquidacionZonaDePlanificacion()

        Try
            ' limpia el total
            Me.txtREPOTOTA.Text = ""

            ' buscar cadena de conexion
            Dim oCadenaConexion As New REGLAS_DEL_NEGOCIO.cla_ConnectionString
            Dim stCadenaConexion As String = oCadenaConexion.fun_ConnectionString

            ' crea el datatable
            dt = New DataTable

            ' crear conexión
            oAdapter = New SqlDataAdapter
            oConexion = New SqlConnection(stCadenaConexion)

            ' abre la conexion
            oConexion.Open()

            ' parametros de la consulta
            Dim ParametrosConsulta As String = ""

            ' Concatena la condicion de la consulta
            ParametrosConsulta += "SELECT "
            ParametrosConsulta += "OBURSECU AS NRO_LIQUIDACION, "
            ParametrosConsulta += "OBURNURE AS NRO_RADICADO, "
            ParametrosConsulta += "OBURCLEN AS CLASE_ENTIDAD, "
            ParametrosConsulta += "OBURFERE AS FECHA_RESOLUCION, "
            ParametrosConsulta += "(SELECT TOP 1 OUPRZOPL FROM OBURPRED WHERE OBURCLEN = OUPRCLEN  AND OBURFERE = OUPRFERE  AND OBURNURE = OUPRNURE )  AS ZONA_PLANIFICACION, "
            ParametrosConsulta += "(SELECT SUM(OUIGLIQU)  FROM OBURINGE WHERE OBURCLEN = OUIGCLEN  AND OBURFERE = OUIGFERE  AND OBURNURE = OUIGNURE  AND OUIGCLOU = 1)  AS EQUIPAMIENTO, "
            ParametrosConsulta += "(SELECT SUM(OUIGLIQU)  FROM OBURINGE WHERE OBURCLEN = OUIGCLEN  AND OBURFERE = OUIGFERE  AND OBURNURE = OUIGNURE  AND OUIGCLOU = 2)  AS ESPACIO_PUBLICO, "
            ParametrosConsulta += "(SELECT SUM(OUIGLIQU)  FROM OBURINGE WHERE OBURCLEN = OUIGCLEN  AND OBURFERE = OUIGFERE  AND OBURNURE = OUIGNURE  AND OUIGCLOU = 5)  AS DENSIDAD_ADICIONAL, "
            ParametrosConsulta += "(SELECT SUM(OUIGLIQU)  FROM OBURINGE WHERE OBURCLEN = OUIGCLEN  AND OBURFERE = OUIGFERE  AND OBURNURE = OUIGNURE  AND OUIGCLOU = 6)  AS COMPENSACION "
            ParametrosConsulta += "FROM "
            ParametrosConsulta += "OBLIURBA "
            ParametrosConsulta += "WHERE "
            ParametrosConsulta += "OBURESTA = 'ac' "
            ParametrosConsulta += "GROUP BY "
            ParametrosConsulta += "OBURSECU, OBURNURE, OBURCLEN, OBURFERE "
            ParametrosConsulta += "ORDER BY "
            ParametrosConsulta += "OBURSECU "

            ' ejecuta la consulta
            oEjecutar = New SqlCommand(ParametrosConsulta, oConexion)

            ' procesa la consulta 
            oEjecutar.CommandTimeout = 0
            oEjecutar.CommandType = CommandType.Text
            oAdapter.SelectCommand = oEjecutar

            ' llena el datatable 
            oAdapter.Fill(dt)

            ' cierra la conexion
            oConexion.Close()

            ' realiza la insercion mediante la consulta
            If dt.Rows.Count > 0 Then

                Me.BindingSource_OBURREPO_1.DataSource = dt
                Me.dgvOBURREPO.DataSource = Me.BindingSource_OBURREPO_1.DataSource
                Me.BindingNavigator_OBURREPO_1.BindingSource = Me.BindingSource_OBURREPO_1

                Me.dgvOBURREPO.Columns("EQUIPAMIENTO").DefaultCellStyle.Format = "c"
                Me.dgvOBURREPO.Columns("ESPACIO_PUBLICO").DefaultCellStyle.Format = "c"
                Me.dgvOBURREPO.Columns("DENSIDAD_ADICIONAL").DefaultCellStyle.Format = "c"
                Me.dgvOBURREPO.Columns("COMPENSACION").DefaultCellStyle.Format = "c"

                Me.txtREPOTOTA.Text = ""
            Else
                Me.BindingSource_OBURREPO_1.DataSource = New DataTable
                Me.dgvOBURREPO.DataSource = Me.BindingSource_OBURREPO_1.DataSource
                Me.BindingNavigator_OBURREPO_1.BindingSource = Me.BindingSource_OBURREPO_1

                Me.txtREPOTOTA.Text = ""

                mod_MENSAJE.Consulta_No_Encontro_Registros()
            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub pro_06_LiquidacionZonaDePlanificacionPorVigencia()

        Try
            ' limpia el total
            Me.txtREPOTOTA.Text = ""

            ' buscar cadena de conexion
            Dim oCadenaConexion As New REGLAS_DEL_NEGOCIO.cla_ConnectionString
            Dim stCadenaConexion As String = oCadenaConexion.fun_ConnectionString

            ' crea el datatable
            dt = New DataTable

            ' crear conexión
            oAdapter = New SqlDataAdapter
            oConexion = New SqlConnection(stCadenaConexion)

            ' abre la conexion
            oConexion.Open()

            ' parametros de la consulta
            Dim ParametrosConsulta As String = ""

            ' Concatena la condicion de la consulta
            ParametrosConsulta += "SELECT "
            ParametrosConsulta += "OBURSECU AS NRO_LIQUIDACION, "
            ParametrosConsulta += "OBURNURE AS NRO_RADICADO, "
            ParametrosConsulta += "OBURCLEN AS CLASE_ENTIDAD, "
            ParametrosConsulta += "OBURFERE AS FECHA_RESOLUCION, "
            ParametrosConsulta += "VIGECODI AS VIGENCIA, "
            ParametrosConsulta += "(SELECT TOP 1 OUPRZOPL FROM OBURPRED WHERE OBURCLEN = OUPRCLEN  AND OBURFERE = OUPRFERE  AND OBURNURE = OUPRNURE )  AS ZONA_PLANIFICACION, "
            ParametrosConsulta += "(SELECT SUM(OUIGLIQU)  FROM OBURINGE WHERE OBURCLEN = OUIGCLEN  AND OBURFERE = OUIGFERE  AND OBURNURE = OUIGNURE  AND OUIGCLOU = 1)  AS EQUIPAMIENTO, "
            ParametrosConsulta += "(SELECT SUM(OUIGLIQU)  FROM OBURINGE WHERE OBURCLEN = OUIGCLEN  AND OBURFERE = OUIGFERE  AND OBURNURE = OUIGNURE  AND OUIGCLOU = 2)  AS ESPACIO_PUBLICO, "
            ParametrosConsulta += "(SELECT SUM(OUIGLIQU)  FROM OBURINGE WHERE OBURCLEN = OUIGCLEN  AND OBURFERE = OUIGFERE  AND OBURNURE = OUIGNURE  AND OUIGCLOU = 5)  AS DENSIDAD_ADICIONAL, "
            ParametrosConsulta += "(SELECT SUM(OUIGLIQU)  FROM OBURINGE WHERE OBURCLEN = OUIGCLEN  AND OBURFERE = OUIGFERE  AND OBURNURE = OUIGNURE  AND OUIGCLOU = 6)  AS COMPENSACION "
            ParametrosConsulta += "FROM "
            ParametrosConsulta += "OBLIURBA, VIGENCIA "
            ParametrosConsulta += "WHERE "
            ParametrosConsulta += "OBURVILI = VIGECODI AND "
            ParametrosConsulta += "OBURESTA = 'ac' "
            ParametrosConsulta += "GROUP BY "
            ParametrosConsulta += "OBURSECU, OBURNURE, OBURCLEN, OBURFERE, VIGECODI "
            ParametrosConsulta += "ORDER BY "
            ParametrosConsulta += "OBURSECU "

            ' ejecuta la consulta
            oEjecutar = New SqlCommand(ParametrosConsulta, oConexion)

            ' procesa la consulta 
            oEjecutar.CommandTimeout = 0
            oEjecutar.CommandType = CommandType.Text
            oAdapter.SelectCommand = oEjecutar

            ' llena el datatable 
            oAdapter.Fill(dt)

            ' cierra la conexion
            oConexion.Close()

            ' realiza la insercion mediante la consulta
            If dt.Rows.Count > 0 Then

                Me.BindingSource_OBURREPO_1.DataSource = dt
                Me.dgvOBURREPO.DataSource = Me.BindingSource_OBURREPO_1.DataSource
                Me.BindingNavigator_OBURREPO_1.BindingSource = Me.BindingSource_OBURREPO_1

                Me.dgvOBURREPO.Columns("EQUIPAMIENTO").DefaultCellStyle.Format = "c"
                Me.dgvOBURREPO.Columns("ESPACIO_PUBLICO").DefaultCellStyle.Format = "c"
                Me.dgvOBURREPO.Columns("DENSIDAD_ADICIONAL").DefaultCellStyle.Format = "c"
                Me.dgvOBURREPO.Columns("COMPENSACION").DefaultCellStyle.Format = "c"

                Me.txtREPOTOTA.Text = ""
            Else
                Me.BindingSource_OBURREPO_1.DataSource = New DataTable
                Me.dgvOBURREPO.DataSource = Me.BindingSource_OBURREPO_1.DataSource
                Me.BindingNavigator_OBURREPO_1.BindingSource = Me.BindingSource_OBURREPO_1

                Me.txtREPOTOTA.Text = ""

                mod_MENSAJE.Consulta_No_Encontro_Registros()
            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub pro_07_LiquidacionClaseDeObligacionPorTipoDeLiquidacion()

        Try
            ' limpia el total
            Me.txtREPOTOTA.Text = ""

            ' buscar cadena de conexion
            Dim oCadenaConexion As New REGLAS_DEL_NEGOCIO.cla_ConnectionString
            Dim stCadenaConexion As String = oCadenaConexion.fun_ConnectionString

            ' crea el datatable
            dt = New DataTable

            ' crear conexión
            oAdapter = New SqlDataAdapter
            oConexion = New SqlConnection(stCadenaConexion)

            ' abre la conexion
            oConexion.Open()

            ' parametros de la consulta
            Dim ParametrosConsulta As String = ""

            ' Concatena la condicion de la consulta
            ParametrosConsulta += "SELECT "
            ParametrosConsulta += "OBURSECU AS NRO_LIQUIDACION, "
            ParametrosConsulta += "OBURNURE AS NRO_RADICADO, "
            ParametrosConsulta += "OBURCLEN AS CLASE_ENTIDAD, "
            ParametrosConsulta += "OBURFERE AS FECHA_RESOLUCION, "
            ParametrosConsulta += "(SELECT TOP 1 RTRIM(TILIDESC) FROM OBURINGE, MANT_TIPOLIQU WHERE TILICODI = OUIGTILI AND OBURCLEN = OUIGCLEN  AND OBURFERE = OUIGFERE  AND OBURNURE = OUIGNURE )  AS TIPO_LIQUIDACION, "
            ParametrosConsulta += "(SELECT SUM(OUIGLIQU)  FROM OBURINGE WHERE OBURCLEN = OUIGCLEN  AND OBURFERE = OUIGFERE  AND OBURNURE = OUIGNURE  AND OUIGCLOU = 1)  AS EQUIPAMIENTO, "
            ParametrosConsulta += "(SELECT SUM(OUIGLIQU)  FROM OBURINGE WHERE OBURCLEN = OUIGCLEN  AND OBURFERE = OUIGFERE  AND OBURNURE = OUIGNURE  AND OUIGCLOU = 2)  AS ESPACIO_PUBLICO, "
            ParametrosConsulta += "(SELECT SUM(OUIGLIQU)  FROM OBURINGE WHERE OBURCLEN = OUIGCLEN  AND OBURFERE = OUIGFERE  AND OBURNURE = OUIGNURE  AND OUIGCLOU = 5)  AS DENSIDAD_ADICIONAL, "
            ParametrosConsulta += "(SELECT SUM(OUIGLIQU)  FROM OBURINGE WHERE OBURCLEN = OUIGCLEN  AND OBURFERE = OUIGFERE  AND OBURNURE = OUIGNURE  AND OUIGCLOU = 6)  AS COMPENSACION "
            ParametrosConsulta += "FROM "
            ParametrosConsulta += "OBLIURBA "
            ParametrosConsulta += "WHERE "
            ParametrosConsulta += "OBURESTA = 'ac' "
            ParametrosConsulta += "GROUP BY "
            ParametrosConsulta += "OBURSECU, OBURNURE, OBURCLEN, OBURFERE "
            ParametrosConsulta += "ORDER BY "
            ParametrosConsulta += "OBURSECU "

            ' ejecuta la consulta
            oEjecutar = New SqlCommand(ParametrosConsulta, oConexion)

            ' procesa la consulta 
            oEjecutar.CommandTimeout = 0
            oEjecutar.CommandType = CommandType.Text
            oAdapter.SelectCommand = oEjecutar

            ' llena el datatable 
            oAdapter.Fill(dt)

            ' cierra la conexion
            oConexion.Close()

            ' realiza la insercion mediante la consulta
            If dt.Rows.Count > 0 Then

                Me.BindingSource_OBURREPO_1.DataSource = dt
                Me.dgvOBURREPO.DataSource = Me.BindingSource_OBURREPO_1.DataSource
                Me.BindingNavigator_OBURREPO_1.BindingSource = Me.BindingSource_OBURREPO_1

                Me.dgvOBURREPO.Columns("EQUIPAMIENTO").DefaultCellStyle.Format = "c"
                Me.dgvOBURREPO.Columns("ESPACIO_PUBLICO").DefaultCellStyle.Format = "c"
                Me.dgvOBURREPO.Columns("DENSIDAD_ADICIONAL").DefaultCellStyle.Format = "c"
                Me.dgvOBURREPO.Columns("COMPENSACION").DefaultCellStyle.Format = "c"

                Me.txtREPOTOTA.Text = ""
            Else
                Me.BindingSource_OBURREPO_1.DataSource = New DataTable
                Me.dgvOBURREPO.DataSource = Me.BindingSource_OBURREPO_1.DataSource
                Me.BindingNavigator_OBURREPO_1.BindingSource = Me.BindingSource_OBURREPO_1

                Me.txtREPOTOTA.Text = ""

                mod_MENSAJE.Consulta_No_Encontro_Registros()
            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub pro_08_LiquidacionClaseDeObligacionyTipoDeLiquidacionPorVigencia()

        Try
            ' limpia el total
            Me.txtREPOTOTA.Text = ""

            ' buscar cadena de conexion
            Dim oCadenaConexion As New REGLAS_DEL_NEGOCIO.cla_ConnectionString
            Dim stCadenaConexion As String = oCadenaConexion.fun_ConnectionString

            ' crea el datatable
            dt = New DataTable

            ' crear conexión
            oAdapter = New SqlDataAdapter
            oConexion = New SqlConnection(stCadenaConexion)

            ' abre la conexion
            oConexion.Open()

            ' parametros de la consulta
            Dim ParametrosConsulta As String = ""

            ' Concatena la condicion de la consulta
            ParametrosConsulta += "SELECT "
            ParametrosConsulta += "OBURSECU AS NRO_LIQUIDACION, "
            ParametrosConsulta += "OBURNURE AS NRO_RADICADO, "
            ParametrosConsulta += "OBURCLEN AS CLASE_ENTIDAD, "
            ParametrosConsulta += "OBURFERE AS FECHA_RESOLUCION, "
            ParametrosConsulta += "VIGECODI AS VIGENCIA, "
            ParametrosConsulta += "(SELECT TOP 1 RTRIM(TILIDESC) FROM OBURINGE, MANT_TIPOLIQU WHERE TILICODI = OUIGTILI AND OBURCLEN = OUIGCLEN  AND OBURFERE = OUIGFERE  AND OBURNURE = OUIGNURE )  AS TIPO_LIQUIDACION, "
            ParametrosConsulta += "(SELECT SUM(OUIGLIQU)  FROM OBURINGE WHERE OBURCLEN = OUIGCLEN  AND OBURFERE = OUIGFERE  AND OBURNURE = OUIGNURE  AND OUIGCLOU = 1)  AS EQUIPAMIENTO, "
            ParametrosConsulta += "(SELECT SUM(OUIGLIQU)  FROM OBURINGE WHERE OBURCLEN = OUIGCLEN  AND OBURFERE = OUIGFERE  AND OBURNURE = OUIGNURE  AND OUIGCLOU = 2)  AS ESPACIO_PUBLICO, "
            ParametrosConsulta += "(SELECT SUM(OUIGLIQU)  FROM OBURINGE WHERE OBURCLEN = OUIGCLEN  AND OBURFERE = OUIGFERE  AND OBURNURE = OUIGNURE  AND OUIGCLOU = 5)  AS DENSIDAD_ADICIONAL, "
            ParametrosConsulta += "(SELECT SUM(OUIGLIQU)  FROM OBURINGE WHERE OBURCLEN = OUIGCLEN  AND OBURFERE = OUIGFERE  AND OBURNURE = OUIGNURE  AND OUIGCLOU = 6)  AS COMPENSACION "
            ParametrosConsulta += "FROM "
            ParametrosConsulta += "OBLIURBA, VIGENCIA "
            ParametrosConsulta += "WHERE "
            ParametrosConsulta += "OBURVILI = VIGECODI AND "
            ParametrosConsulta += "OBURESTA = 'ac' "
            ParametrosConsulta += "GROUP BY "
            ParametrosConsulta += "OBURSECU, OBURNURE, OBURCLEN, OBURFERE, VIGECODI "
            ParametrosConsulta += "ORDER BY "
            ParametrosConsulta += "OBURSECU "

            ' ejecuta la consulta
            oEjecutar = New SqlCommand(ParametrosConsulta, oConexion)

            ' procesa la consulta 
            oEjecutar.CommandTimeout = 0
            oEjecutar.CommandType = CommandType.Text
            oAdapter.SelectCommand = oEjecutar

            ' llena el datatable 
            oAdapter.Fill(dt)

            ' cierra la conexion
            oConexion.Close()

            ' realiza la insercion mediante la consulta
            If dt.Rows.Count > 0 Then

                Me.BindingSource_OBURREPO_1.DataSource = dt
                Me.dgvOBURREPO.DataSource = Me.BindingSource_OBURREPO_1.DataSource
                Me.BindingNavigator_OBURREPO_1.BindingSource = Me.BindingSource_OBURREPO_1

                Me.dgvOBURREPO.Columns("EQUIPAMIENTO").DefaultCellStyle.Format = "c"
                Me.dgvOBURREPO.Columns("ESPACIO_PUBLICO").DefaultCellStyle.Format = "c"
                Me.dgvOBURREPO.Columns("DENSIDAD_ADICIONAL").DefaultCellStyle.Format = "c"
                Me.dgvOBURREPO.Columns("COMPENSACION").DefaultCellStyle.Format = "c"

                Me.txtREPOTOTA.Text = ""
            Else
                Me.BindingSource_OBURREPO_1.DataSource = New DataTable
                Me.dgvOBURREPO.DataSource = Me.BindingSource_OBURREPO_1.DataSource
                Me.BindingNavigator_OBURREPO_1.BindingSource = Me.BindingSource_OBURREPO_1

                Me.txtREPOTOTA.Text = ""

                mod_MENSAJE.Consulta_No_Encontro_Registros()
            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub pro_09_ListadoDeSolicitantesyClaseDeObligacion()

        Try
            ' limpia el total
            Me.txtREPOTOTA.Text = ""

            ' buscar cadena de conexion
            Dim oCadenaConexion As New REGLAS_DEL_NEGOCIO.cla_ConnectionString
            Dim stCadenaConexion As String = oCadenaConexion.fun_ConnectionString

            ' crea el datatable
            dt = New DataTable

            ' crear conexión
            oAdapter = New SqlDataAdapter
            oConexion = New SqlConnection(stCadenaConexion)

            ' abre la conexion
            oConexion.Open()

            ' parametros de la consulta
            Dim ParametrosConsulta As String = ""

            ' Concatena la condicion de la consulta
            ParametrosConsulta += "SELECT "
            ParametrosConsulta += "OBURSECU AS NRO_LIQUIDACION, "
            ParametrosConsulta += "OBURNURE AS NRO_RADICADO, "
            ParametrosConsulta += "OBURCLEN AS CLASE_ENTIDAD, "
            ParametrosConsulta += "OBURFERE + ' .' AS FECHA_RESOLUCION, "
            ParametrosConsulta += "(SELECT TOP 1 (RTRIM(OUSONUDO)) AS NRO_DOCUMENTO FROM OBURSOLI WHERE OBURCLEN = OUSOCLEN  AND OBURFERE = OUSOFERE  AND OBURNURE = OUSONURE )  AS NRO_DOCUMENTO, "
            ParametrosConsulta += "(SELECT TOP 1 (RTRIM(OUSONOMB) + ' ' + RTRIM(OUSOPRAP) + ' ' + RTRIM(OUSOSEAP)) AS NOMBRE_APELLIDOS FROM OBURSOLI WHERE OBURCLEN = OUSOCLEN  AND OBURFERE = OUSOFERE  AND OBURNURE = OUSONURE )  AS SOLICITANTE, "
            ParametrosConsulta += "(SELECT TOP 1 (RTRIM(OUSOCOPO)) AS PROYECTO FROM OBURSOLI WHERE OBURCLEN = OUSOCLEN  AND OBURFERE = OUSOFERE  AND OBURNURE = OUSONURE )  AS PROYECTO, "
            ParametrosConsulta += "(SELECT TOP 1 (RTRIM(OUSODIPR)) AS DIRECCION FROM OBURSOLI WHERE OBURCLEN = OUSOCLEN  AND OBURFERE = OUSOFERE  AND OBURNURE = OUSONURE )  AS DIRECCION_PREDIO, "
            ParametrosConsulta += "(SELECT TOP 1 OUIGFELI  FROM OBURINGE WHERE OBURCLEN = OUIGCLEN  AND OBURFERE = OUIGFERE  AND OBURNURE = OUIGNURE) + ' .' AS FECHA_LIQUIDACION, "
            ParametrosConsulta += "(SELECT SUM(OUIGLIQU)  FROM OBURINGE WHERE OBURCLEN = OUIGCLEN  AND OBURFERE = OUIGFERE  AND OBURNURE = OUIGNURE  AND OUIGCLOU = 1)  AS EQUIPAMIENTO, "
            ParametrosConsulta += "(SELECT SUM(OUIGLIQU)  FROM OBURINGE WHERE OBURCLEN = OUIGCLEN  AND OBURFERE = OUIGFERE  AND OBURNURE = OUIGNURE  AND OUIGCLOU = 2)  AS ESPACIO_PUBLICO, "
            ParametrosConsulta += "(SELECT SUM(OUIGLIQU)  FROM OBURINGE WHERE OBURCLEN = OUIGCLEN  AND OBURFERE = OUIGFERE  AND OBURNURE = OUIGNURE  AND OUIGCLOU = 5)  AS DENSIDAD_ADICIONAL, "
            ParametrosConsulta += "(SELECT SUM(OUIGLIQU)  FROM OBURINGE WHERE OBURCLEN = OUIGCLEN  AND OBURFERE = OUIGFERE  AND OBURNURE = OUIGNURE  AND OUIGCLOU = 6)  AS COMPENSACION "
            ParametrosConsulta += "FROM "
            ParametrosConsulta += "OBLIURBA "
            ParametrosConsulta += "WHERE "
            ParametrosConsulta += "OBURESTA = 'ac' "
            ParametrosConsulta += "GROUP BY "
            ParametrosConsulta += "OBURSECU, OBURNURE, OBURCLEN, OBURFERE "
            ParametrosConsulta += "ORDER BY "
            ParametrosConsulta += "OBURSECU "

            ' ejecuta la consulta
            oEjecutar = New SqlCommand(ParametrosConsulta, oConexion)

            ' procesa la consulta 
            oEjecutar.CommandTimeout = 0
            oEjecutar.CommandType = CommandType.Text
            oAdapter.SelectCommand = oEjecutar

            ' llena el datatable 
            oAdapter.Fill(dt)

            ' cierra la conexion
            oConexion.Close()

            ' realiza la insercion mediante la consulta
            If dt.Rows.Count > 0 Then

                Me.BindingSource_OBURREPO_1.DataSource = dt
                Me.dgvOBURREPO.DataSource = Me.BindingSource_OBURREPO_1.DataSource
                Me.BindingNavigator_OBURREPO_1.BindingSource = Me.BindingSource_OBURREPO_1

                Me.dgvOBURREPO.Columns("EQUIPAMIENTO").DefaultCellStyle.Format = "c"
                Me.dgvOBURREPO.Columns("ESPACIO_PUBLICO").DefaultCellStyle.Format = "c"
                Me.dgvOBURREPO.Columns("DENSIDAD_ADICIONAL").DefaultCellStyle.Format = "c"
                Me.dgvOBURREPO.Columns("COMPENSACION").DefaultCellStyle.Format = "c"

                Me.txtREPOTOTA.Text = ""
            Else
                Me.BindingSource_OBURREPO_1.DataSource = New DataTable
                Me.dgvOBURREPO.DataSource = Me.BindingSource_OBURREPO_1.DataSource
                Me.BindingNavigator_OBURREPO_1.BindingSource = Me.BindingSource_OBURREPO_1

                Me.txtREPOTOTA.Text = ""

                mod_MENSAJE.Consulta_No_Encontro_Registros()
            End If


        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub pro_10_ListadoDetallePorClaseDeObligacion()

        Try

            ' limpia el total
            Me.txtREPOTOTA.Text = ""

            ' buscar cadena de conexion
            Dim oCadenaConexion As New REGLAS_DEL_NEGOCIO.cla_ConnectionString
            Dim stCadenaConexion As String = oCadenaConexion.fun_ConnectionString

            ' crea el datatable
            dt = New DataTable

            ' crear conexión
            oAdapter = New SqlDataAdapter
            oConexion = New SqlConnection(stCadenaConexion)

            ' abre la conexion
            oConexion.Open()

            ' parametros de la consulta
            Dim ParametrosConsulta As String = ""

            ' Concatena la condicion de la consulta
            ParametrosConsulta += "SELECT "
            ParametrosConsulta += "OUIGSECU AS NRO_LIQUIDACION, "
            ParametrosConsulta += "OUIGNURE AS NRO_RADICADO, "
            ParametrosConsulta += "RTRIM(CLENDESC) AS CLASE_ENTIDAD, "
            ParametrosConsulta += "OUIGFERE + ' .' AS FECHA_RESOLUCION, "
            ParametrosConsulta += "OUIGFELI + ' .' AS FECHA_LIQUIDACION, "
            ParametrosConsulta += "OBURGRCO AS GRANDES_CONTRIBUYENTES, "
            ParametrosConsulta += "OUIGUNID AS NRO_UNIDADES, "
            ParametrosConsulta += "RTRIM(CLOUDESC) AS DESCRIPCION, "
            ParametrosConsulta += "OUIGLIQU AS LIQUIDACION "
            ParametrosConsulta += "FROM "
            ParametrosConsulta += "OBLIURBA, OBURINGE, MANT_CLASOBUR, MANT_CLASENTI "
            ParametrosConsulta += "WHERE "
            ParametrosConsulta += "OBURCLEN = OUIGCLEN AND "
            ParametrosConsulta += "OBURNURE = OUIGNURE AND "
            ParametrosConsulta += "OBURFERE = OUIGFERE AND "
            ParametrosConsulta += "OUIGCLOU = CLOUCODI AND "
            ParametrosConsulta += "OUIGCLEN = CLENCODI AND "
            ParametrosConsulta += "OBURESTA = 'ac' "
            ParametrosConsulta += "ORDER BY "
            ParametrosConsulta += "OUIGSECU, OUIGCLOU "

            ' ejecuta la consulta
            oEjecutar = New SqlCommand(ParametrosConsulta, oConexion)

            ' procesa la consulta 
            oEjecutar.CommandTimeout = 0
            oEjecutar.CommandType = CommandType.Text
            oAdapter.SelectCommand = oEjecutar

            ' llena el datatable 
            oAdapter.Fill(dt)

            ' cierra la conexion
            oConexion.Close()

            ' realiza la insercion mediante la consulta
            If dt.Rows.Count > 0 Then

                Me.BindingSource_OBURREPO_1.DataSource = dt
                Me.dgvOBURREPO.DataSource = Me.BindingSource_OBURREPO_1.DataSource
                Me.BindingNavigator_OBURREPO_1.BindingSource = Me.BindingSource_OBURREPO_1

                Me.dgvOBURREPO.Columns("LIQUIDACION").DefaultCellStyle.Format = "c"

                Dim loTotal As Long = 0
                Dim i As Integer = 0

                For i = 0 To dt.Rows.Count - 1
                    loTotal += CLng(dt.Rows(i).Item("LIQUIDACION"))
                Next

                Me.txtREPOTOTA.Text = "$ " & fun_Formato_Mascara_Pesos_Enteros(CStr(loTotal))

            Else
                Me.BindingSource_OBURREPO_1.DataSource = New DataTable
                Me.dgvOBURREPO.DataSource = Me.BindingSource_OBURREPO_1.DataSource
                Me.BindingNavigator_OBURREPO_1.BindingSource = Me.BindingSource_OBURREPO_1

                Me.txtREPOTOTA.Text = ""

                mod_MENSAJE.Consulta_No_Encontro_Registros()
            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub pro_11_ListadoDeRadicadoSolicitanteDireccionPredio()

        Try
            ' limpia el total
            Me.txtREPOTOTA.Text = ""

            ' buscar cadena de conexion
            Dim oCadenaConexion As New REGLAS_DEL_NEGOCIO.cla_ConnectionString
            Dim stCadenaConexion As String = oCadenaConexion.fun_ConnectionString

            ' crea el datatable
            dt = New DataTable

            ' crear conexión
            oAdapter = New SqlDataAdapter
            oConexion = New SqlConnection(stCadenaConexion)

            ' abre la conexion
            oConexion.Open()

            ' parametros de la consulta
            Dim ParametrosConsulta As String = ""

            ' Concatena la condicion de la consulta
            ParametrosConsulta += "SELECT "
            ParametrosConsulta += "OBURSECU AS NRO_LIQUIDACION, "
            ParametrosConsulta += "OBURNURE AS NRO_RADICADO, "
            ParametrosConsulta += "OBURCLEN AS CLASE_ENTIDAD, "
            ParametrosConsulta += "OBURFERE + ' .' AS FECHA_RESOLUCION, "
            ParametrosConsulta += "(SELECT TOP 1 (RTRIM(OUSONOMB) + ' ' + RTRIM(OUSOPRAP) + ' ' + RTRIM(OUSOSEAP)) AS NOMBRE_APELLIDOS FROM OBURSOLI WHERE OBURCLEN = OUSOCLEN  AND OBURFERE = OUSOFERE  AND OBURNURE = OUSONURE )  AS SOLICITANTE, "
            ParametrosConsulta += "(SELECT TOP 1 (RTRIM(OUSOCOPO)) AS PROYECTO FROM OBURSOLI WHERE OBURCLEN = OUSOCLEN  AND OBURFERE = OUSOFERE  AND OBURNURE = OUSONURE )  AS PROYECTO, "
            ParametrosConsulta += "(SELECT TOP 1 (RTRIM(OUSODIPR)) AS DIRECCION FROM OBURSOLI WHERE OBURCLEN = OUSOCLEN  AND OBURFERE = OUSOFERE  AND OBURNURE = OUSONURE )  AS DIRECCION_PREDIO "
            'ParametrosConsulta += "(SELECT SUM(OUIGLIQU)  FROM OBURINGE WHERE OBURCLEN = OUIGCLEN  AND OBURFERE = OUIGFERE  AND OBURNURE = OUIGNURE  AND OUIGCLOU = 1)  AS EQUIPAMIENTO, "
            'ParametrosConsulta += "(SELECT SUM(OUIGLIQU)  FROM OBURINGE WHERE OBURCLEN = OUIGCLEN  AND OBURFERE = OUIGFERE  AND OBURNURE = OUIGNURE  AND OUIGCLOU = 2)  AS ESPACIO_PUBLICO, "
            'ParametrosConsulta += "(SELECT SUM(OUIGLIQU)  FROM OBURINGE WHERE OBURCLEN = OUIGCLEN  AND OBURFERE = OUIGFERE  AND OBURNURE = OUIGNURE  AND OUIGCLOU = 5)  AS DENSIDAD_ADICIONAL, "
            'ParametrosConsulta += "(SELECT SUM(OUIGLIQU)  FROM OBURINGE WHERE OBURCLEN = OUIGCLEN  AND OBURFERE = OUIGFERE  AND OBURNURE = OUIGNURE  AND OUIGCLOU = 6)  AS COMPENSACION "
            ParametrosConsulta += "FROM "
            ParametrosConsulta += "OBLIURBA "
            ParametrosConsulta += "WHERE "
            ParametrosConsulta += "OBURESTA = 'ac' "
            ParametrosConsulta += "GROUP BY "
            ParametrosConsulta += "OBURSECU, OBURNURE, OBURCLEN, OBURFERE "
            ParametrosConsulta += "ORDER BY "
            ParametrosConsulta += "OBURSECU "

            ' ejecuta la consulta
            oEjecutar = New SqlCommand(ParametrosConsulta, oConexion)

            ' procesa la consulta 
            oEjecutar.CommandTimeout = 0
            oEjecutar.CommandType = CommandType.Text
            oAdapter.SelectCommand = oEjecutar

            ' llena el datatable 
            oAdapter.Fill(dt)

            ' cierra la conexion
            oConexion.Close()

            ' realiza la insercion mediante la consulta
            If dt.Rows.Count > 0 Then

                Me.BindingSource_OBURREPO_1.DataSource = dt
                Me.dgvOBURREPO.DataSource = Me.BindingSource_OBURREPO_1.DataSource
                Me.BindingNavigator_OBURREPO_1.BindingSource = Me.BindingSource_OBURREPO_1

                'Me.dgvOBURREPO.Columns("EQUIPAMIENTO").DefaultCellStyle.Format = "c"
                'Me.dgvOBURREPO.Columns("ESPACIO_PUBLICO").DefaultCellStyle.Format = "c"
                'Me.dgvOBURREPO.Columns("DENSIDAD_ADICIONAL").DefaultCellStyle.Format = "c"
                'Me.dgvOBURREPO.Columns("COMPENSACION").DefaultCellStyle.Format = "c"

                Me.txtREPOTOTA.Text = ""
            Else
                Me.BindingSource_OBURREPO_1.DataSource = New DataTable
                Me.dgvOBURREPO.DataSource = Me.BindingSource_OBURREPO_1.DataSource
                Me.BindingNavigator_OBURREPO_1.BindingSource = Me.BindingSource_OBURREPO_1

                Me.txtREPOTOTA.Text = ""

                mod_MENSAJE.Consulta_No_Encontro_Registros()
            End If


        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub

#End Region

#Region "PROCEDIMIENTO ADQUISICION DE PREDIOS"

    Private Sub pro_ReconsultarAdquisicionDePredios()

        Try
            Dim objdatos As New cla_OBURADPR

            If boCONSULTA = False Then
                Me.BindingSource_OBURADPR_1.DataSource = objdatos.fun_Buscar_SECU_X_CONSULTA_PARAMETRIZADA_OBURADPR(Me.dgvOBLIURBA.SelectedRows.Item(0).Cells("OBURSECU").Value.ToString())
            Else
                Me.BindingSource_OBURADPR_1.DataSource = objdatos.fun_Buscar_SECU_X_CONSULTA_PARAMETRIZADA_OBURADPR(Me.dgvOBLIURBA.SelectedRows.Item(0).Cells("OBURSECU").Value.ToString())
            End If

            Me.dgvOBURADPR_1.DataSource = BindingSource_OBURADPR_1
            Me.dgvOBURADPR_2.DataSource = BindingSource_OBURADPR_1
            Me.BindingNavigator_OBURADPR_1.BindingSource = BindingSource_OBURADPR_1

            '=================================================
            '*** CONFIGURA OBJETOS DEL FORMULARIO MAESTRO ***
            '=================================================

            Me.strBARRESTA.Items(2).Text = "Registros : " & Me.BindingSource_OBLIURBA_1.Count

            Me.dgvOBURADPR_1.Columns("CLOUDESC").HeaderText = "Clase de Obligación"
            Me.dgvOBURADPR_1.Columns("OUAPNUOF").HeaderText = "Nro. Oficio"
            Me.dgvOBURADPR_1.Columns("OUAPMAIN").HeaderText = "Matricula Inmobiliria"
            Me.dgvOBURADPR_1.Columns("OUAPMUNI").HeaderText = "Municipio"
            Me.dgvOBURADPR_1.Columns("OUAPCORR").HeaderText = "Correg."
            Me.dgvOBURADPR_1.Columns("OUAPBARR").HeaderText = "Barrio"
            Me.dgvOBURADPR_1.Columns("OUAPMANZ").HeaderText = "Manzana Vereda"
            Me.dgvOBURADPR_1.Columns("OUAPPRED").HeaderText = "Predio"
            Me.dgvOBURADPR_1.Columns("OUAPEDIF").HeaderText = "Edificio"
            Me.dgvOBURADPR_1.Columns("OUAPUNPR").HeaderText = "Unidad Predial"
            Me.dgvOBURADPR_1.Columns("CLSEDESC").HeaderText = "Sector"

            Me.dgvOBURADPR_1.Columns("OUAPIDRE").Visible = False
            Me.dgvOBURADPR_1.Columns("OUAPCLEN").Visible = False
            Me.dgvOBURADPR_1.Columns("OUAPNURE").Visible = False
            Me.dgvOBURADPR_1.Columns("OUAPFERE").Visible = False
            Me.dgvOBURADPR_1.Columns("OUAPSECU").Visible = False
            Me.dgvOBURADPR_1.Columns("OUAPDESC").Visible = False
            Me.dgvOBURADPR_1.Columns("OUAPOBSE").Visible = False
            Me.dgvOBURADPR_1.Columns("OUAPSUPE").Visible = False
            Me.dgvOBURADPR_1.Columns("OUAPNDSU").Visible = False
            Me.dgvOBURADPR_1.Columns("USUANOMB").Visible = False
            Me.dgvOBURADPR_1.Columns("USUAPRAP").Visible = False
            Me.dgvOBURADPR_1.Columns("USUASEAP").Visible = False

            Me.dgvOBURADPR_1.Columns("OUAPARTE").Visible = False
            Me.dgvOBURADPR_1.Columns("OUAPAVCA").Visible = False
            Me.dgvOBURADPR_1.Columns("OUAPAVCO").Visible = False
            Me.dgvOBURADPR_1.Columns("OUAPVACO").Visible = False
            Me.dgvOBURADPR_1.Columns("OUAPESTA").Visible = False
            Me.dgvOBURADPR_1.Columns("OUAPESTA").Visible = False
            Me.dgvOBURADPR_1.Columns("ESTADESC").Visible = False
            Me.dgvOBURADPR_1.Columns("OUAPCLOU").Visible = False
            Me.dgvOBURADPR_1.Columns("OUAPDIRE").Visible = False
            Me.dgvOBURADPR_1.Columns("USUARIO").Visible = False
            Me.dgvOBURADPR_1.Columns("OUAPCLOU").Visible = False

            Me.dgvOBURADPR_2.Columns("USUARIO").HeaderText = "Supervisor"
            Me.dgvOBURADPR_2.Columns("OUAPDIRE").HeaderText = "Dirección"
            Me.dgvOBURADPR_2.Columns("OUAPARTE").HeaderText = "Área de terreno m2"
            Me.dgvOBURADPR_2.Columns("OUAPAVCA").HeaderText = "Avalúo Catastral"
            Me.dgvOBURADPR_2.Columns("OUAPAVCO").HeaderText = "Avalúo Comercial"
            Me.dgvOBURADPR_2.Columns("OUAPVACO").HeaderText = "Valor Compra"
            Me.dgvOBURADPR_2.Columns("ESTADESC").HeaderText = "Estado"

            Me.dgvOBURADPR_2.Columns("OUAPIDRE").Visible = False
            Me.dgvOBURADPR_2.Columns("OUAPCLEN").Visible = False
            Me.dgvOBURADPR_2.Columns("OUAPNURE").Visible = False
            Me.dgvOBURADPR_2.Columns("OUAPFERE").Visible = False
            Me.dgvOBURADPR_2.Columns("OUAPSECU").Visible = False
            Me.dgvOBURADPR_2.Columns("OUAPDESC").Visible = False
            Me.dgvOBURADPR_2.Columns("OUAPOBSE").Visible = False
            Me.dgvOBURADPR_2.Columns("OUAPSUPE").Visible = False
            Me.dgvOBURADPR_2.Columns("OUAPNDSU").Visible = False

            Me.dgvOBURADPR_2.Columns("OUAPMUNI").Visible = False
            Me.dgvOBURADPR_2.Columns("OUAPCORR").Visible = False
            Me.dgvOBURADPR_2.Columns("OUAPBARR").Visible = False
            Me.dgvOBURADPR_2.Columns("OUAPMANZ").Visible = False
            Me.dgvOBURADPR_2.Columns("OUAPPRED").Visible = False
            Me.dgvOBURADPR_2.Columns("OUAPEDIF").Visible = False
            Me.dgvOBURADPR_2.Columns("OUAPUNPR").Visible = False
            Me.dgvOBURADPR_2.Columns("CLSEDESC").Visible = False
            Me.dgvOBURADPR_2.Columns("OUAPESTA").Visible = False
            Me.dgvOBURADPR_2.Columns("OUAPMAIN").Visible = False
            Me.dgvOBURADPR_2.Columns("OUAPNUOF").Visible = False
            Me.dgvOBURADPR_2.Columns("USUANOMB").Visible = False
            Me.dgvOBURADPR_2.Columns("USUAPRAP").Visible = False
            Me.dgvOBURADPR_2.Columns("USUASEAP").Visible = False
            Me.dgvOBURADPR_2.Columns("OUAPCLOU").Visible = False
            Me.dgvOBURADPR_2.Columns("CLOUDESC").Visible = False

            Me.dgvOBURADPR_2.Columns("OUAPAVCA").DefaultCellStyle.Format = "c"
            Me.dgvOBURADPR_2.Columns("OUAPAVCO").DefaultCellStyle.Format = "c"
            Me.dgvOBURADPR_2.Columns("OUAPVACO").DefaultCellStyle.Format = "c"
            Me.dgvOBURADPR_2.Columns("OUAPARTE").DefaultCellStyle.Format = "n"

            Me.dgvOBURADPR_1.Columns("CLOUDESC").Width = 150
            Me.dgvOBURADPR_2.Columns("USUARIO").Width = 250
            Me.dgvOBURADPR_2.Columns("OUAPDIRE").Width = 250

            Me.dgvOBURADPR_2.Columns("OUAPAVCA").DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopRight
            Me.dgvOBURADPR_2.Columns("OUAPAVCO").DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopRight
            Me.dgvOBURADPR_2.Columns("OUAPVACO").DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopRight

            '==================================================
            '*** ASIGNA LOS PRIVILEGIOS DE LA BARRA DE MENU ***
            '==================================================

            Dim ContarRegistros As Integer = Me.BindingSource_OBURADPR_1.Count

            Dim boCONTAGRE As Boolean = False
            Dim boCONTMODI As Boolean = False
            Dim boCONTELIM As Boolean = False
            Dim boCONTCONS As Boolean = False
            Dim boCONTRECO As Boolean = False

            pro_Permiso_Barra_De_Menu_Formulario_SubFormulario(ContarRegistros, Trim(Me.BindingNavigator_OBURADPR_1.Name), boCONTAGRE, boCONTMODI, boCONTELIM, boCONTCONS, boCONTRECO)

            Me.cmdAGREGAR_OBURADPR.Enabled = boCONTAGRE
            Me.cmdMODIFICAR_OBURADPR.Enabled = boCONTMODI
            Me.cmdELIMINAR_OBURADPR.Enabled = boCONTELIM
            Me.cmdCONSULTAR_OBURADPR.Enabled = boCONTCONS
            Me.cmdRECONSULTAR_OBURADPR.Enabled = boCONTRECO

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub pro_ListaDeValoresAdquisicionDePredios()

        Try
            If Me.dgvOBURADPR_1.RowCount > 0 Then

                Dim objdatos As New cla_OBURADPR
                Dim tbldatos As New DataTable

                tbldatos = objdatos.fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_OBURADPR(CInt(Me.dgvOBURADPR_1.SelectedRows.Item(0).Cells("OUAPIDRE").Value.ToString()))

                If tbldatos.Rows.Count > 0 Then

                    Me.txtOUAPDESC.Text = Trim(tbldatos.Rows(0).Item("OUAPDESC").ToString)
                    Me.txtOUAPOBSE.Text = Trim(tbldatos.Rows(0).Item("OUAPOBSE").ToString)

                End If

            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub pro_LimpiarAdquisicionDePredios()

        Me.dgvOBURADPR_1.DataSource = New DataTable
        Me.dgvOBURADPR_2.DataSource = New DataTable

        Me.txtOUAPDESC.Text = ""
        Me.txtOUAPOBSE.Text = ""

    End Sub

#End Region

#Region "PROCEDIMIENTO EJECUCION DE OBRA"

    Private Sub pro_ReconsultarEjecucionDeObra()

        Try
            Dim objdatos As New cla_OBUREJOB

            If boCONSULTA = False Then
                Me.BindingSource_OBUREJOB_1.DataSource = objdatos.fun_Buscar_SECU_X_CONSULTA_PARAMETRIZADA_OBUREJOB(Me.dgvOBLIURBA.SelectedRows.Item(0).Cells("OBURSECU").Value.ToString())
            Else
                Me.BindingSource_OBUREJOB_1.DataSource = objdatos.fun_Buscar_SECU_X_CONSULTA_PARAMETRIZADA_OBUREJOB(Me.dgvOBLIURBA.SelectedRows.Item(0).Cells("OBURSECU").Value.ToString())
            End If

            Me.dgvOBUREJOB_1.DataSource = BindingSource_OBUREJOB_1
            Me.dgvOBUREJOB_2.DataSource = BindingSource_OBUREJOB_1
            Me.BindingNavigator_OBUREJOB_1.BindingSource = BindingSource_OBUREJOB_1

            '=================================================
            '*** CONFIGURA OBJETOS DEL FORMULARIO MAESTRO ***
            '=================================================

            Me.strBARRESTA.Items(2).Text = "Registros : " & Me.BindingSource_OBLIURBA_1.Count

            Me.dgvOBUREJOB_1.Columns("OUEOCOCO").HeaderText = "Código Convenio"
            Me.dgvOBUREJOB_1.Columns("OUEOCOOB").HeaderText = "Código Obra"
            Me.dgvOBUREJOB_1.Columns("CLOUDESC").HeaderText = "Clase de Obligación"
            Me.dgvOBUREJOB_1.Columns("OUEONUOF").HeaderText = "Nro. Oficio"
            Me.dgvOBUREJOB_1.Columns("OUEOVAOB").HeaderText = "Valor Obra"
            Me.dgvOBUREJOB_1.Columns("OUEOVACO").HeaderText = "Valor Convenio"
            Me.dgvOBUREJOB_1.Columns("OUEOVADI").HeaderText = "Valor Disponible"
            Me.dgvOBUREJOB_1.Columns("FPPPDESC").HeaderText = "Forma de Pago"
            Me.dgvOBUREJOB_1.Columns("OUEONUCU").HeaderText = "Nro. Cuotas"
            Me.dgvOBUREJOB_1.Columns("OUEOAPCO").HeaderText = "Aplica Convenio"

            Me.dgvOBUREJOB_1.Columns("OUEOIDRE").Visible = False
            Me.dgvOBUREJOB_1.Columns("OUEOCLEN").Visible = False
            Me.dgvOBUREJOB_1.Columns("OUEONURE").Visible = False
            Me.dgvOBUREJOB_1.Columns("OUEOFERE").Visible = False
            Me.dgvOBUREJOB_1.Columns("OUEOSECU").Visible = False
            Me.dgvOBUREJOB_1.Columns("OUEONUME").Visible = False
            Me.dgvOBUREJOB_1.Columns("OUEODESC").Visible = False
            Me.dgvOBUREJOB_1.Columns("OUEOOBSE").Visible = False
            Me.dgvOBUREJOB_1.Columns("OUEOCONT").Visible = False
            Me.dgvOBUREJOB_1.Columns("OUEOFOPA").Visible = False
            Me.dgvOBUREJOB_1.Columns("OUEOSUPE").Visible = False
            Me.dgvOBUREJOB_1.Columns("OUEONDSU").Visible = False
            Me.dgvOBUREJOB_1.Columns("USUANOMB").Visible = False
            Me.dgvOBUREJOB_1.Columns("USUAPRAP").Visible = False
            Me.dgvOBUREJOB_1.Columns("USUASEAP").Visible = False
            Me.dgvOBUREJOB_1.Columns("OUEOCLOU").Visible = False
            Me.dgvOBUREJOB_1.Columns("USUARIO").Visible = False
            Me.dgvOBUREJOB_1.Columns("OUEOESTA").Visible = False
            Me.dgvOBUREJOB_1.Columns("ESTADESC").Visible = False
            Me.dgvOBUREJOB_1.Columns("OUEOFEIN").Visible = False
            Me.dgvOBUREJOB_1.Columns("OUEOFEFI").Visible = False
            Me.dgvOBUREJOB_1.Columns("OUEOOBCO").Visible = False
            Me.dgvOBUREJOB_1.Columns("OUEOPLDI").Visible = False
            Me.dgvOBUREJOB_1.Columns("OUEOACLI").Visible = False
            Me.dgvOBUREJOB_1.Columns("OUEONUPO").Visible = False
            Me.dgvOBUREJOB_1.Columns("OUEONUCA").Visible = False

            Me.dgvOBUREJOB_2.Columns("OUEOACLI").HeaderText = "Acta de Liquidación"
            Me.dgvOBUREJOB_2.Columns("OUEOPLDI").HeaderText = "Plazo Días"
            Me.dgvOBUREJOB_2.Columns("OUEOCONT").HeaderText = "Contratista"
            Me.dgvOBUREJOB_2.Columns("USUARIO").HeaderText = "Supervisor"
            Me.dgvOBUREJOB_2.Columns("OUEONUPO").HeaderText = "Nro. Poliza"
            Me.dgvOBUREJOB_2.Columns("OUEONUCA").HeaderText = "Nro. Carpeta"
            Me.dgvOBUREJOB_2.Columns("OUEOFEIN").HeaderText = "Fecha de Inicio"
            Me.dgvOBUREJOB_2.Columns("OUEOFEFI").HeaderText = "Fecha de Finalización"
            Me.dgvOBUREJOB_2.Columns("ESTADESC").HeaderText = "Estado"

            Me.dgvOBUREJOB_2.Columns("OUEOIDRE").Visible = False
            Me.dgvOBUREJOB_2.Columns("OUEOCOCO").Visible = False
            Me.dgvOBUREJOB_2.Columns("OUEOCLEN").Visible = False
            Me.dgvOBUREJOB_2.Columns("OUEOCOOB").Visible = False
            Me.dgvOBUREJOB_2.Columns("OUEONURE").Visible = False
            Me.dgvOBUREJOB_2.Columns("OUEOFERE").Visible = False
            Me.dgvOBUREJOB_2.Columns("OUEOSECU").Visible = False
            Me.dgvOBUREJOB_2.Columns("OUEODESC").Visible = False
            Me.dgvOBUREJOB_2.Columns("OUEOOBSE").Visible = False
            Me.dgvOBUREJOB_2.Columns("OUEOSUPE").Visible = False
            Me.dgvOBUREJOB_2.Columns("OUEONDSU").Visible = False
            Me.dgvOBUREJOB_2.Columns("OUEOVAOB").Visible = False
            Me.dgvOBUREJOB_2.Columns("OUEOVADI").Visible = False
            Me.dgvOBUREJOB_2.Columns("OUEOOBCO").Visible = False
            Me.dgvOBUREJOB_2.Columns("OUEOVACO").Visible = False
            Me.dgvOBUREJOB_2.Columns("OUEOCOOB").Visible = False

            Me.dgvOBUREJOB_2.Columns("OUEOESTA").Visible = False
            Me.dgvOBUREJOB_2.Columns("OUEONUME").Visible = False
            Me.dgvOBUREJOB_2.Columns("OUEONUOF").Visible = False
            Me.dgvOBUREJOB_2.Columns("USUANOMB").Visible = False
            Me.dgvOBUREJOB_2.Columns("USUAPRAP").Visible = False
            Me.dgvOBUREJOB_2.Columns("USUASEAP").Visible = False
            Me.dgvOBUREJOB_2.Columns("OUEOCLOU").Visible = False
            Me.dgvOBUREJOB_2.Columns("CLOUDESC").Visible = False
            Me.dgvOBUREJOB_2.Columns("OUEOFOPA").Visible = False
            Me.dgvOBUREJOB_2.Columns("FPPPDESC").Visible = False
            Me.dgvOBUREJOB_2.Columns("OUEONUCU").Visible = False
            Me.dgvOBUREJOB_2.Columns("OUEOAPCO").Visible = False

            Me.dgvOBUREJOB_1.Columns("OUEOVAOB").DefaultCellStyle.Format = "c"
            Me.dgvOBUREJOB_1.Columns("OUEOVACO").DefaultCellStyle.Format = "c"
            Me.dgvOBUREJOB_1.Columns("OUEOVADI").DefaultCellStyle.Format = "c"

            Me.dgvOBUREJOB_2.Columns("OUEOCONT").Width = 200
            Me.dgvOBUREJOB_2.Columns("USUARIO").Width = 200

            Me.dgvOBUREJOB_1.Columns("OUEOVAOB").DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopRight
            Me.dgvOBUREJOB_1.Columns("OUEOVACO").DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopRight
            Me.dgvOBUREJOB_1.Columns("OUEOVADI").DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopRight

            '==================================================
            '*** ASIGNA LOS PRIVILEGIOS DE LA BARRA DE MENU ***
            '==================================================

            Dim ContarRegistros As Integer = Me.BindingSource_OBUREJOB_1.Count

            Dim boCONTAGRE As Boolean = False
            Dim boCONTMODI As Boolean = False
            Dim boCONTELIM As Boolean = False
            Dim boCONTCONS As Boolean = False
            Dim boCONTRECO As Boolean = False

            pro_Permiso_Barra_De_Menu_Formulario_SubFormulario(ContarRegistros, Trim(Me.BindingNavigator_OBUREJOB_1.Name), boCONTAGRE, boCONTMODI, boCONTELIM, boCONTCONS, boCONTRECO)

            Me.cmdAGREGAR_OBUREJOB.Enabled = boCONTAGRE
            Me.cmdMODIFICAR_OBUREJOB.Enabled = boCONTMODI
            Me.cmdELIMINAR_OBUREJOB.Enabled = boCONTELIM
            Me.cmdCONSULTAR_OBUREJOB.Enabled = boCONTCONS
            Me.cmdRECONSULTAR_OBUREJOB.Enabled = boCONTRECO

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub pro_ListaDeValoresEjecucionDeObra()

        Try
            If Me.dgvOBUREJOB_1.RowCount > 0 Then

                Dim objdatos As New cla_OBUREJOB
                Dim tbldatos As New DataTable

                tbldatos = objdatos.fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_OBUREJOB(CInt(Me.dgvOBUREJOB_1.SelectedRows.Item(0).Cells("OUEOIDRE").Value.ToString()))

                If tbldatos.Rows.Count > 0 Then

                    Me.txtOUEODESC.Text = Trim(tbldatos.Rows(0).Item("OUEODESC").ToString)
                    Me.txtOUEOOBSE.Text = Trim(tbldatos.Rows(0).Item("OUEOOBSE").ToString)
                    Me.txtOUEOOBCO.Text = Trim(tbldatos.Rows(0).Item("OUEOOBCO").ToString)

                End If

            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub pro_LimpiarEjecucionDeObra()

        Me.dgvOBUREJOB_1.DataSource = New DataTable
        Me.dgvOBUREJOB_2.DataSource = New DataTable

        Me.txtOUEODESC.Text = ""
        Me.txtOUEOOBSE.Text = ""
        Me.txtOUEOOBCO.Text = ""

    End Sub

#End Region

#Region "PROCEDIMIENTO PAGOS REALIZADOS"

    Private Sub pro_ReconsultarPagosRealizados()

        Try


        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub pro_ListaDeValoresPagosRealizados()

        Try


        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub pro_LimpiarPagosRealizados()

        Me.dgvOBURPARE_1.DataSource = New DataTable
        Me.dgvOBURPARE_2.DataSource = New DataTable

    End Sub

#End Region

#Region "PROCEDIMIENTO ARCHIVO FISICO"

    Private Sub pro_ReconsultarArchivoFisico()

        Try


        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub pro_ListaDeValoresArchivoFisico()

        Try


        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub pro_LimpiarArchivoFisico()

        Me.dgvOBURARFI.DataSource = New DataTable

    End Sub

#End Region

#Region "MENU OBLIGACIONES URBANISTICAS"

    Private Sub cmdAGREGAR_OBLIURBA_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAGREGAR_OBLIURBA.Click

        Try

            If Me.dgvOBLIURBA.RowCount > 0 Then
                Dim frm_insertar As New frm_insertar_OBLIURBA(Integer.Parse(Me.dgvOBLIURBA.SelectedRows.Item(0).Cells("OBURIDRE").Value.ToString()))
                frm_insertar.ShowDialog()
            Else
                frm_insertar_OBLIURBA.ShowDialog()
            End If

            If vp_inConsulta > 0 Then
                boCONSULTA = True
            Else
                boCONSULTA = False
            End If

            pro_ReconsultarObligacionesUrbanisticas()
            pro_ListaDeValoresObligacionesUrbanisticas()

            If MessageBox.Show("Desea diligenciar el solicitante", "Mensaje ...", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then
                TabMAESTRO_2.SelectTab(TabSolicitante)
                cmdAGREGAR_OBURSOLI.PerformClick()
            Else
                TabMAESTRO_2.SelectTab(TabRadicacion)
            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub cmdMODIFICAR_OBLIURBA_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdMODIFICAR_OBLIURBA.Click

        Try
            Dim frm_modificar As New frm_modificar_OBLIURBA(Integer.Parse(Me.dgvOBLIURBA.SelectedRows.Item(0).Cells("OBURIDRE").Value.ToString()))
            frm_modificar.ShowDialog()

            If vp_inConsulta <> 0 Then
                boCONSULTA = True
            End If

            pro_ReconsultarObligacionesUrbanisticas()
            pro_ListaDeValoresObligacionesUrbanisticas()

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub cmdELIMINAR_OBLIURBA_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdELIMINAR_OBLIURBA.Click

        Try
            If MessageBox.Show("¿ Desea eliminar el registro seleccionado ? ", "Mensaje...", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then
                Dim objdatos As New cla_OBLIURBA

                If objdatos.fun_Eliminar_IDRE_OBLIURBA(Integer.Parse(Me.dgvOBLIURBA.SelectedRows.Item(0).Cells("OBURIDRE").Value.ToString())) Then

                    boCONSULTA = False

                    pro_LimpiarCamposObligacionesUrbanisticas()
                    pro_ReconsultarObligacionesUrbanisticas()
                    pro_ListaDeValoresObligacionesUrbanisticas()
                Else
                    frm_INCO_eliminar_registro_padre_con_relación_de_registros_hijos.ShowDialog()
                End If

            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub cmdCONSULTAR_OBLIURBA_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCONSULTAR_OBLIURBA.Click

        Try
            vp_inConsulta = 0

            If Me.dgvOBLIURBA.RowCount > 0 Then
                Dim frm_consultar As New frm_consultar_OBLIURBA(Integer.Parse(Me.dgvOBLIURBA.SelectedRows.Item(0).Cells("OBURIDRE").Value.ToString()))
                frm_consultar.ShowDialog()
            Else
                Dim frm_consultar As New frm_consultar_OBLIURBA()
                frm_consultar.ShowDialog()
            End If

            If vp_inConsulta > 0 Then
                boCONSULTA = True
            Else
                boCONSULTA = False
            End If

            pro_ReconsultarObligacionesUrbanisticas()
            pro_ListaDeValoresObligacionesUrbanisticas()

            Me.TabMAESTRO_2.SelectTab(TabRadicacion)

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub cmdRECONSULTAR_OBLIURBA_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdRECONSULTAR_OBLIURBA.Click

        Try
            If Me.dgvOBLIURBA.RowCount > 0 Then
                boCONSULTA = True
            Else
                boCONSULTA = False
            End If

            pro_ReconsultarObligacionesUrbanisticas()
            pro_ListaDeValoresObligacionesUrbanisticas()

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
            If Me.dgvOBLIURBA.RowCount > 0 Then

                Dim frm_inserta_archivo As New frm_insertar_archivo_OBLIURBA(Me.dgvOBLIURBA.SelectedRows.Item(0).Cells("OBURCLEN").Value.ToString(), _
                                                                             Me.dgvOBLIURBA.SelectedRows.Item(0).Cells("OBURNURE").Value.ToString(), _
                                                                             Me.dgvOBLIURBA.SelectedRows.Item(0).Cells("OBURVIRE").Value.ToString())
                frm_inserta_archivo.ShowDialog()

                pro_ListadoArchivosDocumentos()

                vp_inConsulta = Me.dgvOBLIURBA.SelectedRows.Item(0).Cells("OBURIDRE").Value.ToString()

                If vp_inConsulta <> 0 Then
                    boCONSULTA = True
                Else
                    boCONSULTA = False
                End If

                pro_ReconsultarObligacionesUrbanisticas()
                pro_ListaDeValoresObligacionesUrbanisticas()

                mod_MENSAJE.Proceso_Termino_Correctamente()

            Else
                mod_MENSAJE.No_Existe_Un_Registro_Seleccionado()
            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub

    Private Sub cmdOBSERVACIONES_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOBSERVACIONES.Click
        pro_EjecutarBotonObservaciones()
    End Sub

    Private Sub ToolStripButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton1.Click

        Try
            pro_ListaDeValoresObligacionesUrbanisticas()

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub ToolStripButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton2.Click

        Try
            pro_ListaDeValoresObligacionesUrbanisticas()

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub ToolStripButton3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton3.Click

        Try
            pro_ListaDeValoresObligacionesUrbanisticas()

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub ToolStripButton4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton4.Click

        Try
            pro_ListaDeValoresObligacionesUrbanisticas()

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub

#End Region

#Region "MENU SOLICITANTE"

    Private Sub cmdAGREGAR_OBURSOLI_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAGREGAR_OBURSOLI.Click

        Try
            If Me.dgvOBLIURBA.RowCount > 0 Then
                Dim frm_insertar As New frm_insertar_OBURSOLI(Me.dgvOBLIURBA.SelectedRows.Item(0).Cells("OBURSECU").Value.ToString(), _
                                                              Me.dgvOBLIURBA.SelectedRows.Item(0).Cells("OBURCLEN").Value.ToString(), _
                                                              Me.dgvOBLIURBA.SelectedRows.Item(0).Cells("OBURNURE").Value.ToString(), _
                                                              Me.dgvOBLIURBA.SelectedRows.Item(0).Cells("OBURFERE").Value.ToString())
                frm_insertar.ShowDialog()
            End If

            boCONSULTA = False

            pro_ReconsultarSolicitante()
            pro_ListaDeValoresSolicitante()

            If MessageBox.Show("Desea diligenciar el predio", "Mensaje ...", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then
                TabMAESTRO_2.SelectTab(TabPredios)
                cmdAGREGAR_OBURPRED.PerformClick()
            Else
                TabMAESTRO_2.SelectTab(TabSolicitante)
            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub cmdMODIFICAR_OBURSOLI_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdMODIFICAR_OBURSOLI.Click

        Try
            Dim frm_modificar As New frm_insertar_OBURSOLI(Me.dgvOBURSOLI_1.SelectedRows.Item(0).Cells("OUSOIDRE").Value.ToString(), _
                                                           Me.dgvOBLIURBA.SelectedRows.Item(0).Cells("OBURSECU").Value.ToString(), _
                                                           Me.dgvOBLIURBA.SelectedRows.Item(0).Cells("OBURCLEN").Value.ToString(), _
                                                           Me.dgvOBLIURBA.SelectedRows.Item(0).Cells("OBURNURE").Value.ToString(), _
                                                           Me.dgvOBLIURBA.SelectedRows.Item(0).Cells("OBURFERE").Value.ToString())
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
    Private Sub cmdELIMINAR_OBURSOLI_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdELIMINAR_OBURSOLI.Click

        Try
            If MessageBox.Show("¿ Desea eliminar el registro seleccionado ? ", "Mensaje...", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then
                Dim objdatos As New cla_OBURSOLI

                If objdatos.fun_Eliminar_IDRE_OBURSOLI(Integer.Parse(Me.dgvOBURSOLI_1.SelectedRows.Item(0).Cells("OUSOIDRE").Value.ToString())) Then

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
    Private Sub cmdCONSULTAR_OBURSOLI_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCONSULTAR_OBURSOLI.Click

        vp_inConsulta = 0

        Dim frm_consultar As New frm_consultar_OBLIURBA(Integer.Parse(Me.dgvOBLIURBA.SelectedRows.Item(0).Cells("OBURIDRE").Value.ToString()))
        frm_consultar.ShowDialog()

        If vp_inConsulta > 0 Then
            boCONSULTA = True
        Else
            boCONSULTA = False
        End If

        pro_ReconsultarObligacionesUrbanisticas()
        pro_ListaDeValoresObligacionesUrbanisticas()

        Me.TabMAESTRO_2.SelectTab(TabSolicitante)

    End Sub
    Private Sub cmdRECONSULTAR_MATEREGI_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdRECONSULTAR_OBURSOLI.Click

        boCONSULTA = False
        pro_ReconsultarSolicitante()
        pro_ListaDeValoresSolicitante()

    End Sub

#End Region

#Region "MENU PREDIO"

    Private Sub cmdAGREGAR_OBURPRED_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAGREGAR_OBURPRED.Click

        Try
            If Me.dgvOBLIURBA.RowCount > 0 Then
                Dim frm_insertar As New frm_insertar_OBURPRED(Me.dgvOBLIURBA.SelectedRows.Item(0).Cells("OBURSECU").Value.ToString(), _
                                                              Me.dgvOBLIURBA.SelectedRows.Item(0).Cells("OBURCLEN").Value.ToString(), _
                                                              Me.dgvOBLIURBA.SelectedRows.Item(0).Cells("OBURNURE").Value.ToString(), _
                                                              Me.dgvOBLIURBA.SelectedRows.Item(0).Cells("OBURFERE").Value.ToString())
                frm_insertar.ShowDialog()
            End If

            boCONSULTA = False

            pro_ReconsultarPredio()
            pro_ListaDeValoresPredio()

            If MessageBox.Show("Desea diligenciar el avalúo comercial", "Mensaje ...", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then
                TabMAESTRO_2.SelectTab(TabAvaluoComercial)
                cmdAGREGAR_OBURAVCO.PerformClick()
            Else
                If MessageBox.Show("Desea diligenciar la información general", "Mensaje ...", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then
                    TabMAESTRO_2.SelectTab(TabInformacionGeneral)
                    cmdAGREGAR_OBURINGE.PerformClick()
                Else
                    TabMAESTRO_2.SelectTab(TabPredios)
                End If
            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub cmdMODIFICAR_OBURPRED_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdMODIFICAR_OBURPRED.Click

        Try
            Dim frm_modificar As New frm_insertar_OBURPRED(Me.dgvOBURPRED_1.SelectedRows.Item(0).Cells("OUPRIDRE").Value.ToString(), _
                                                           Me.dgvOBLIURBA.SelectedRows.Item(0).Cells("OBURSECU").Value.ToString(), _
                                                           Me.dgvOBLIURBA.SelectedRows.Item(0).Cells("OBURCLEN").Value.ToString(), _
                                                           Me.dgvOBLIURBA.SelectedRows.Item(0).Cells("OBURNURE").Value.ToString(), _
                                                           Me.dgvOBLIURBA.SelectedRows.Item(0).Cells("OBURFERE").Value.ToString())
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
    Private Sub cmdELIMINAR_OBURPRED_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdELIMINAR_OBURPRED.Click

        Try
            If MessageBox.Show("¿ Desea eliminar el registro seleccionado ? ", "Mensaje...", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then
                Dim objdatos As New cla_OBURPRED

                If objdatos.fun_Eliminar_IDRE_OBURPRED(Integer.Parse(Me.dgvOBURPRED_1.SelectedRows.Item(0).Cells("OUPRIDRE").Value.ToString())) Then

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
    Private Sub cmdCONSULTAR_OBURPRED_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCONSULTAR_OBURPRED.Click

        vp_inConsulta = 0

        Dim frm_consultar As New frm_consultar_OBLIURBA(Integer.Parse(Me.dgvOBLIURBA.SelectedRows.Item(0).Cells("OBURIDRE").Value.ToString()))
        frm_consultar.ShowDialog()

        If vp_inConsulta > 0 Then
            boCONSULTA = True
        Else
            boCONSULTA = False
        End If

        pro_ReconsultarObligacionesUrbanisticas()
        pro_ListaDeValoresObligacionesUrbanisticas()

        Me.TabMAESTRO_2.SelectTab(TabPredios)

    End Sub
    Private Sub cmdRECONSULTAR_OBURPRED_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdRECONSULTAR_OBURPRED.Click

        boCONSULTA = False
        pro_ReconsultarPredio()
        pro_ListaDeValoresPredio()

    End Sub

#End Region

#Region "MENU AVALUO COMERCIAL"

    Private Sub cmdAGREGAR_OBURAVCO_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAGREGAR_OBURAVCO.Click

        Try
            If Me.dgvOBLIURBA.RowCount > 0 Then
                Dim frm_insertar As New frm_insertar_OBURAVCO(Me.dgvOBLIURBA.SelectedRows.Item(0).Cells("OBURSECU").Value.ToString(), _
                                                              Me.dgvOBLIURBA.SelectedRows.Item(0).Cells("OBURCLEN").Value.ToString(), _
                                                              Me.dgvOBLIURBA.SelectedRows.Item(0).Cells("OBURNURE").Value.ToString(), _
                                                              Me.dgvOBLIURBA.SelectedRows.Item(0).Cells("OBURFERE").Value.ToString())
                frm_insertar.ShowDialog()
            End If

            boCONSULTA = False

            pro_ReconsultarAvaluoComercial()
            pro_ListaDeValoresAvaluoComercial()

            If MessageBox.Show("Desea diligenciar la información general", "Mensaje ...", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then
                TabMAESTRO_2.SelectTab(TabInformacionGeneral)
                cmdAGREGAR_OBURINGE.PerformClick()
            Else
                TabMAESTRO_2.SelectTab(TabAvaluoComercial)
            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub cmdMODIFICAR_OBURAVCO_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdMODIFICAR_OBURAVCO.Click

        Try
            Dim frm_modificar As New frm_insertar_OBURAVCO(Me.dgvOBURAVCO_1.SelectedRows.Item(0).Cells("OUACIDRE").Value.ToString(), _
                                                           Me.dgvOBLIURBA.SelectedRows.Item(0).Cells("OBURSECU").Value.ToString(), _
                                                           Me.dgvOBLIURBA.SelectedRows.Item(0).Cells("OBURCLEN").Value.ToString(), _
                                                           Me.dgvOBLIURBA.SelectedRows.Item(0).Cells("OBURNURE").Value.ToString(), _
                                                           Me.dgvOBLIURBA.SelectedRows.Item(0).Cells("OBURFERE").Value.ToString())
            frm_modificar.ShowDialog()

            If vp_inConsulta <> 0 Then
                boCONSULTA = True
            End If

            pro_ReconsultarAvaluoComercial()
            pro_ListaDeValoresAvaluoComercial()

            Me.TabMAESTRO_2.SelectTab(TabAvaluoComercial)

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub cmdELIMINAR_OBURAVCO_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdELIMINAR_OBURAVCO.Click

        Try
            If MessageBox.Show("¿ Desea eliminar el registro seleccionado ? ", "Mensaje...", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then
                Dim objdatos As New cla_OBURAVCO

                If objdatos.fun_Eliminar_IDRE_OBURAVCO(Integer.Parse(Me.dgvOBURAVCO_1.SelectedRows.Item(0).Cells("OUACIDRE").Value.ToString())) Then

                    boCONSULTA = False

                    pro_LimpiarCamposPredio()
                    pro_ReconsultarAvaluoComercial()
                    pro_ListaDeValoresAvaluoComercial()
                Else
                    frm_INCO_eliminar_registro_padre_con_relación_de_registros_hijos.ShowDialog()
                End If

            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub cmdCONSULTAR_OBURAVCO_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCONSULTAR_OBURAVCO.Click

        vp_inConsulta = 0

        Dim frm_consultar As New frm_consultar_OBLIURBA(Integer.Parse(Me.dgvOBLIURBA.SelectedRows.Item(0).Cells("OBURIDRE").Value.ToString()))
        frm_consultar.ShowDialog()

        If vp_inConsulta > 0 Then
            boCONSULTA = True
        Else
            boCONSULTA = False
        End If

        pro_ReconsultarObligacionesUrbanisticas()
        pro_ListaDeValoresObligacionesUrbanisticas()

        Me.TabMAESTRO_2.SelectTab(TabPredios)

    End Sub
    Private Sub cmdRECONSULTAR_OBURAVCO_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdRECONSULTAR_OBURAVCO.Click

        boCONSULTA = False
        pro_ReconsultarAvaluoComercial()
        pro_ListaDeValoresAvaluoComercial()

    End Sub

#End Region

#Region "MENU INFORMACION GENERAL"

    Private Sub cmdAGREGAR_OBURINGE_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAGREGAR_OBURINGE.Click

        Try
            If Me.dgvOBLIURBA.RowCount > 0 Then
                Dim frm_insertar As New frm_insertar_OBURINGE(Me.dgvOBLIURBA.SelectedRows.Item(0).Cells("OBURSECU").Value.ToString(), _
                                                              Me.dgvOBLIURBA.SelectedRows.Item(0).Cells("OBURCLEN").Value.ToString(), _
                                                              Me.dgvOBLIURBA.SelectedRows.Item(0).Cells("OBURNURE").Value.ToString(), _
                                                              Me.dgvOBLIURBA.SelectedRows.Item(0).Cells("OBURFERE").Value.ToString())
                frm_insertar.ShowDialog()
            End If

            ' verifica los registros
            If Me.dgvOBLIURBA.RowCount > 0 Then

                ' proceso plan parcial
                pro_InsertaPlanParcial(True, False)

                ' instancia la clase
                Dim obOBURINGE As New cla_OBURINGE
                Dim dtOBURINGE As New DataTable

                dtOBURINGE = obOBURINGE.fun_Buscar_SECU_X_CONSULTA_PARAMETRIZADA_OBURINGE(CInt(Me.dgvOBLIURBA.SelectedRows.Item(0).Cells("OBURSECU").Value.ToString()))

                If dtOBURINGE.Rows.Count > 0 Then

                    ' declara la variable
                    Dim i As Integer = 0

                    For i = 0 To dtOBURINGE.Rows.Count - 1

                        Dim inOUIGSECU As Integer = CInt(dtOBURINGE.Rows(i).Item("OUIGSECU"))
                        Dim stOUIGCLEN As String = CStr(Trim(dtOBURINGE.Rows(i).Item("OUIGCLEN")))
                        Dim inOUIGNURE As Integer = CInt(dtOBURINGE.Rows(i).Item("OUIGNURE"))
                        Dim stOUIGFERE As String = CStr(Trim(dtOBURINGE.Rows(i).Item("OUIGFERE")))
                        Dim inOUIGCLOU As Integer = CInt(dtOBURINGE.Rows(i).Item("OUIGCLOU"))
                        Dim inOUIGNULI As Integer = CInt(dtOBURINGE.Rows(i).Item("OUIGNULI"))
                        Dim boOUIGAJLI As Boolean = CBool(dtOBURINGE.Rows(i).Item("OUIGAJLI"))

                        ' liquida obligaciones
                        pro_LIQUIDA_OBLIGACIONES_URBANISTICAS(inOUIGSECU, stOUIGCLEN, inOUIGNURE, stOUIGFERE, inOUIGCLOU, inOUIGNULI, boOUIGAJLI)

                    Next

                End If

            End If

            boCONSULTA = False

            pro_ReconsultarPlanParcial()
            pro_ListaDeValoresPlanParcial()

            pro_ReconsultarInformacionGeneral()
            pro_ListaDeValoresInformacionGeneral()

            Me.TabMAESTRO_2.SelectTab(TabInformacionGeneral)

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub cmdMODIFICAR_OBURINGE_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdMODIFICAR_OBURINGE.Click

        Try
            Dim frm_modificar As New frm_insertar_OBURINGE(Me.dgvOBURINGE_1.SelectedRows.Item(0).Cells("OUIGIDRE").Value.ToString(), _
                                                           Me.dgvOBLIURBA.SelectedRows.Item(0).Cells("OBURSECU").Value.ToString(), _
                                                           Me.dgvOBLIURBA.SelectedRows.Item(0).Cells("OBURCLEN").Value.ToString(), _
                                                           Me.dgvOBLIURBA.SelectedRows.Item(0).Cells("OBURNURE").Value.ToString(), _
                                                           Me.dgvOBLIURBA.SelectedRows.Item(0).Cells("OBURFERE").Value.ToString())
            frm_modificar.ShowDialog()

            ' verifica los registros
            If Me.dgvOBLIURBA.RowCount > 0 And Me.dgvOBURINGE_1.RowCount > 0 Then

                ' proceso plan parcial
                pro_InsertaPlanParcial(True, False)

                ' instancia la clase
                Dim obOBURINGE As New cla_OBURINGE
                Dim dtOBURINGE As New DataTable

                dtOBURINGE = obOBURINGE.fun_Buscar_SECU_X_CONSULTA_PARAMETRIZADA_OBURINGE(CInt(Me.dgvOBURINGE_1.SelectedRows.Item(0).Cells("OUIGSECU").Value.ToString()))

                If dtOBURINGE.Rows.Count > 0 Then

                    ' declara la variable
                    Dim i As Integer = 0

                    For i = 0 To dtOBURINGE.Rows.Count - 1

                        Dim inOUIGSECU As Integer = CInt(dtOBURINGE.Rows(i).Item("OUIGSECU"))
                        Dim stOUIGCLEN As String = CStr(Trim(dtOBURINGE.Rows(i).Item("OUIGCLEN")))
                        Dim inOUIGNURE As Integer = CInt(dtOBURINGE.Rows(i).Item("OUIGNURE"))
                        Dim stOUIGFERE As String = CStr(Trim(dtOBURINGE.Rows(i).Item("OUIGFERE")))
                        Dim inOUIGCLOU As Integer = CInt(dtOBURINGE.Rows(i).Item("OUIGCLOU"))
                        Dim inOUIGNULI As Integer = CInt(dtOBURINGE.Rows(i).Item("OUIGNULI"))
                        Dim boOUIGAJLI As Boolean = CBool(dtOBURINGE.Rows(i).Item("OUIGAJLI"))

                        ' liquida obligaciones
                        pro_LIQUIDA_OBLIGACIONES_URBANISTICAS(inOUIGSECU, stOUIGCLEN, inOUIGNURE, stOUIGFERE, inOUIGCLOU, inOUIGNULI, boOUIGAJLI)

                    Next

                End If

            End If

            If vp_inConsulta <> 0 Then
                boCONSULTA = True
            End If

            pro_ReconsultarPlanParcial()
            pro_ListaDeValoresPlanParcial()

            pro_ReconsultarInformacionGeneral()
            pro_ListaDeValoresInformacionGeneral()

            Me.TabMAESTRO_2.SelectTab(TabInformacionGeneral)

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub cmdELIMINAR_OBURINGE_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdELIMINAR_OBURINGE.Click

        Try
            If MessageBox.Show("¿ Desea eliminar el registro seleccionado ? ", "Mensaje...", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then

                ' instancia la clase
                Dim obOBURINGE As New cla_OBURINGE
                Dim dtOBURINGE As New DataTable

                dtOBURINGE = obOBURINGE.fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_OBURINGE(Me.dgvOBURINGE_1.SelectedRows.Item(0).Cells("OUIGIDRE").Value.ToString())

                If dtOBURINGE.Rows.Count > 0 Then

                    ' almacena los datos
                    Dim inOUIGSECU As Integer = CInt(dtOBURINGE.Rows(0).Item("OUIGSECU"))
                    Dim inOUIGCLOU As Integer = CInt(dtOBURINGE.Rows(0).Item("OUIGCLOU"))
                    Dim inOUIGNULI As Integer = CInt(dtOBURINGE.Rows(0).Item("OUIGNULI"))

                    ' instancia la clase
                    Dim obOBURPLPA1 As New cla_OBURPLPA

                    obOBURPLPA1.fun_Eliminar_OBURPLPA(inOUIGSECU, inOUIGCLOU, inOUIGNULI)

                End If

                Dim objdatos As New cla_OBURINGE

                If objdatos.fun_Eliminar_IDRE_OBURINGE(Integer.Parse(Me.dgvOBURINGE_1.SelectedRows.Item(0).Cells("OUIGIDRE").Value.ToString())) = True Then

                    boCONSULTA = False

                    pro_LimpiarPlanParcial()
                    pro_ReconsultarPlanParcial()
                    pro_ListaDeValoresPlanParcial()

                    pro_LimpiarCamposInformacionGeneral()
                    pro_ReconsultarInformacionGeneral()
                    pro_ListaDeValoresInformacionGeneral()
                Else
                    frm_INCO_eliminar_registro_padre_con_relación_de_registros_hijos.ShowDialog()
                End If

            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub cmdCONSULTAR_OBURINGE_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCONSULTAR_OBURINGE.Click

        vp_inConsulta = 0

        Dim frm_consultar As New frm_consultar_OBLIURBA(Integer.Parse(Me.dgvOBLIURBA.SelectedRows.Item(0).Cells("OBURIDRE").Value.ToString()))
        frm_consultar.ShowDialog()

        If vp_inConsulta > 0 Then
            boCONSULTA = True
        Else
            boCONSULTA = False
        End If

        pro_ReconsultarObligacionesUrbanisticas()
        pro_ListaDeValoresObligacionesUrbanisticas()

        Me.TabMAESTRO_2.SelectTab(TabInformacionGeneral)

    End Sub
    Private Sub cmdRECONSULTAR_OBURINGE_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdRECONSULTAR_OBURINGE.Click

        boCONSULTA = False
        pro_ReconsultarInformacionGeneral()
        pro_ListaDeValoresInformacionGeneral()

    End Sub
    Private Sub cmdLIQUIDAR_OBURINGE_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdLIQUIDAR_OBURINGE.Click

        Try
            If MessageBox.Show("¿ Desea liquidar el registro seleccionado ? ", "Mensaje...", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then

                If Me.dgvOBLIURBA.RowCount > 0 And _
                   Me.dgvOBURINGE_1.RowCount > 0 Then

                    pro_LIQUIDA_OBLIGACIONES_URBANISTICAS(CInt(Me.dgvOBURINGE_1.SelectedRows.Item(0).Cells("OUIGSECU").Value.ToString()), _
                                                          CStr(Trim(Me.dgvOBURINGE_1.SelectedRows.Item(0).Cells("OUIGCLEN").Value.ToString())), _
                                                          CInt(Me.dgvOBURINGE_1.SelectedRows.Item(0).Cells("OUIGNURE").Value.ToString()), _
                                                          CStr(Trim(Me.dgvOBURINGE_1.SelectedRows.Item(0).Cells("OUIGFERE").Value.ToString())), _
                                                          CInt(Me.dgvOBURINGE_1.SelectedRows.Item(0).Cells("OUIGCLOU").Value.ToString()), _
                                                          CInt(Me.dgvOBURINGE_1.SelectedRows.Item(0).Cells("OUIGNULI").Value.ToString()), _
                                                          CBool(Me.dgvOBURINGE_1.SelectedRows.Item(0).Cells("OUIGAJLI").Value.ToString()))


                    pro_ReconsultarInformacionGeneral()
                    pro_ListaDeValoresInformacionGeneral()

                End If

            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub

#End Region

#Region "MENU PLAN PARCIAL"


#End Region

#Region "MENU LIQUIDACION GENERAR"

    Private Sub cmdGENERAR_OBURINGE_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGENERAR_OBURINGE.Click

        Try
            ' configura el boton
            Me.cmdGENERAR_OBURINGE.Enabled = False

            ' instancia la clase
            Dim obOBURINGE As New cla_OBURINGE
            Dim dtOBURINGE As New DataTable

            dtOBURINGE = obOBURINGE.fun_Buscar_SECU_X_CONSULTA_PARAMETRIZADA_OBURINGE(Me.dgvOBLIURBA.SelectedRows.Item(0).Cells("OBURSECU").Value.ToString())

            If dtOBURINGE.Rows.Count > 0 Then

                ' declara la variable
                Dim boLiquidar As Boolean = False

                Dim sw1 As Byte = 0
                Dim j1 As Integer = 0

                While j1 < dtOBURINGE.Rows.Count And sw1 = 0
                    If dtOBURINGE.Rows(j1).Item("OUIGLIQU") = 0 Then
                        sw1 = 1
                    Else
                        j1 = j1 + 1
                    End If
                End While

                If sw1 = 0 Then
                    pro_GenerarLiquidacionPDF()
                Else
                    MessageBox.Show("Existe liquidación en cero.", "Mensaje ...", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1)
                End If

            Else
                mod_MENSAJE.No_Existe_Un_Registro_Seleccionado()
            End If

            ' configura el boton
            Me.cmdGENERAR_OBURINGE.Enabled = True

        Catch ex As Exception

        End Try

    End Sub

#End Region

#Region "MENU AJUSTE DE LIQUIDACION"

    Private Sub cmdAGREGAR_OBURAJLI_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAGREGAR_OBURAJLI.Click

        Try
            If Me.dgvOBURAJLI_1.RowCount > 0 Then

                Dim frm_insertar As New frm_insertar_OBURAJLI(Me.dgvOBURAJLI_1.SelectedRows.Item(0).Cells("OUIGIDRE").Value.ToString(), _
                                                              Me.dgvOBURAJLI_1.SelectedRows.Item(0).Cells("OUIGSECU").Value.ToString(), _
                                                              Me.dgvOBURAJLI_1.SelectedRows.Item(0).Cells("OUIGCLEN").Value.ToString(), _
                                                              Me.dgvOBURAJLI_1.SelectedRows.Item(0).Cells("OUIGNURE").Value.ToString(), _
                                                              Me.dgvOBURAJLI_1.SelectedRows.Item(0).Cells("OUIGFERE").Value.ToString(), _
                                                              Me.dgvOBURAJLI_1.SelectedRows.Item(0).Cells("OUIGCLOU").Value.ToString(), _
                                                              Me.dgvOBURAJLI_1.SelectedRows.Item(0).Cells("OUIGNULI").Value.ToString())
                frm_insertar.ShowDialog()

            End If

            boCONSULTA = False

            pro_ReconsultarInformacionGeneral()
            pro_ListaDeValoresInformacionGeneral()

            pro_ReconsultarAjusteDeLiquidacion()
            pro_ListaDeValoresAjusteDeLiquidacion()

            Me.TabMAESTRO_2.SelectTab(TabAjusteLiquidacion)

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub cmdMODIFICAR_OBURAJLI_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdMODIFICAR_OBURAJLI.Click

        Try
            Dim frm_modificar As New frm_insertar_OBURAJLI(Me.dgvOBURAJLI_2.SelectedRows.Item(0).Cells("OUALIDRE").Value.ToString(), _
                                                           Me.dgvOBURAJLI_2.SelectedRows.Item(0).Cells("OUALSECU").Value.ToString(), _
                                                           Me.dgvOBURAJLI_2.SelectedRows.Item(0).Cells("OUALCLEN").Value.ToString(), _
                                                           Me.dgvOBURAJLI_2.SelectedRows.Item(0).Cells("OUALNURE").Value.ToString(), _
                                                           Me.dgvOBURAJLI_2.SelectedRows.Item(0).Cells("OUALFERE").Value.ToString(), _
                                                           Me.dgvOBURAJLI_2.SelectedRows.Item(0).Cells("OUALCLOU").Value.ToString(), _
                                                           Me.dgvOBURAJLI_2.SelectedRows.Item(0).Cells("OUALNULI").Value.ToString(), _
                                                           Me.dgvOBURAJLI_2.SelectedRows.Item(0).Cells("OUALNUAL").Value.ToString())
            frm_modificar.ShowDialog()

            If vp_inConsulta <> 0 Then
                boCONSULTA = True
            End If

            pro_ReconsultarInformacionGeneral()
            pro_ListaDeValoresInformacionGeneral()

            pro_ReconsultarAjusteDeLiquidacion()
            pro_ListaDeValoresAjusteDeLiquidacion()
            pro_ListaDeValoresAjusteDeLiquidacionPorAjuste()

            Me.TabMAESTRO_2.SelectTab(TabAjusteLiquidacion)

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub cmdELIMINAR_OBURAJLI_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdELIMINAR_OBURAJLI.Click

        Try
            If MessageBox.Show("¿ Desea eliminar el registro seleccionado ? ", "Mensaje...", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then
                Dim objdatos As New cla_OBURAJLI

                If objdatos.fun_Eliminar_IDRE_OBURAJLI(Integer.Parse(Me.dgvOBURAJLI_2.SelectedRows.Item(0).Cells("OUALIDRE").Value.ToString())) Then

                    boCONSULTA = False

                    pro_LimpiarAjusteDeLiquidacion()
                    pro_ReconsultarAjusteDeLiquidacion()
                    pro_ListaDeValoresAjusteDeLiquidacion()
                Else
                    frm_INCO_eliminar_registro_padre_con_relación_de_registros_hijos.ShowDialog()
                End If

            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub cmdCONSULTAR_OBURAJLI_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCONSULTAR_OBURAJLI.Click

        vp_inConsulta = 0

        Dim frm_consultar As New frm_consultar_OBLIURBA(Integer.Parse(Me.dgvOBLIURBA.SelectedRows.Item(0).Cells("OBURIDRE").Value.ToString()))
        frm_consultar.ShowDialog()

        If vp_inConsulta > 0 Then
            boCONSULTA = True
        Else
            boCONSULTA = False
        End If

        pro_ReconsultarObligacionesUrbanisticas()
        pro_ListaDeValoresObligacionesUrbanisticas()

        Me.TabMAESTRO_2.SelectTab(TabInformacionGeneral)

    End Sub
    Private Sub cmdRECONSULTAR_OBURAJLI_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdRECONSULTAR_OBURAJLI.Click

        boCONSULTA = False
        pro_ReconsultarAjusteDeLiquidacion()
        pro_ListaDeValoresAjusteDeLiquidacion()

    End Sub

#End Region

#Region "MENU REPORTE"

    Private Sub cmdGENERAR_OBURREPO_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGENERAR_OBURREPO.Click

        Try
            If Me.cboSELECCION_OBURREPO.SelectedIndex = 0 Then
                pro_01_LiquidaciónTotal()
            End If
            If Me.cboSELECCION_OBURREPO.SelectedIndex = 1 Then
                pro_02_LiquidacionClaseDeObligacion()
            End If
            If Me.cboSELECCION_OBURREPO.SelectedIndex = 2 Then
                pro_03_LiquidacionClaseDeObligacionPorVigencia()
            End If
            If Me.cboSELECCION_OBURREPO.SelectedIndex = 3 Then
                pro_04_LiquidacionTotalPorVigencia()
            End If
            If Me.cboSELECCION_OBURREPO.SelectedIndex = 4 Then
                pro_05_LiquidacionZonaDePlanificacion()
            End If
            If Me.cboSELECCION_OBURREPO.SelectedIndex = 5 Then
                pro_06_LiquidacionZonaDePlanificacionPorVigencia()
            End If
            If Me.cboSELECCION_OBURREPO.SelectedIndex = 6 Then
                pro_07_LiquidacionClaseDeObligacionPorTipoDeLiquidacion()
            End If
            If Me.cboSELECCION_OBURREPO.SelectedIndex = 7 Then
                pro_08_LiquidacionClaseDeObligacionyTipoDeLiquidacionPorVigencia()
            End If
            If Me.cboSELECCION_OBURREPO.SelectedIndex = 8 Then
                pro_09_ListadoDeSolicitantesyClaseDeObligacion()
            End If
            If Me.cboSELECCION_OBURREPO.SelectedIndex = 9 Then
                pro_10_ListadoDetallePorClaseDeObligacion()
            End If
            If Me.cboSELECCION_OBURREPO.SelectedIndex = 10 Then
                pro_11_ListadoDeRadicadoSolicitanteDireccionPredio()
            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub cboEXPORAR_OBUREXPO_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdEXPORTAR_OBUREXPO.Click

        Try
            If Me.dgvOBURREPO.RowCount = 0 Then
                MessageBox.Show("No existe datos para exportar", "Mensaje ...", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1)
            Else
                Dim oExp As New cla_ExportarTablaExcel
                oExp.DataTableToExcel(CType(Me.dgvOBURREPO.DataSource, DataTable))
            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub

#End Region

#Region "MENU ADQUISICION DE PREDIOS"

    Private Sub cmdAGREGAR_OBURADPR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAGREGAR_OBURADPR.Click

        Try
            If Me.dgvOBLIURBA.RowCount > 0 Then
                Dim frm_insertar As New frm_insertar_OBURADPR(Me.dgvOBLIURBA.SelectedRows.Item(0).Cells("OBURSECU").Value.ToString(), _
                                                              Me.dgvOBLIURBA.SelectedRows.Item(0).Cells("OBURCLEN").Value.ToString(), _
                                                              Me.dgvOBLIURBA.SelectedRows.Item(0).Cells("OBURNURE").Value.ToString(), _
                                                              Me.dgvOBLIURBA.SelectedRows.Item(0).Cells("OBURFERE").Value.ToString())
                frm_insertar.ShowDialog()
            End If

            boCONSULTA = False

            pro_ReconsultarAdquisicionDePredios()
            pro_ListaDeValoresAdquisicionDePredios()

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try


    End Sub
    Private Sub cmdMODIFICAR_OBURADPR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdMODIFICAR_OBURADPR.Click

        Try
            Dim frm_modificar As New frm_insertar_OBURADPR(Me.dgvOBURADPR_1.SelectedRows.Item(0).Cells("OUAPIDRE").Value.ToString(), _
                                                           Me.dgvOBLIURBA.SelectedRows.Item(0).Cells("OBURSECU").Value.ToString(), _
                                                           Me.dgvOBLIURBA.SelectedRows.Item(0).Cells("OBURCLEN").Value.ToString(), _
                                                           Me.dgvOBLIURBA.SelectedRows.Item(0).Cells("OBURNURE").Value.ToString(), _
                                                           Me.dgvOBLIURBA.SelectedRows.Item(0).Cells("OBURFERE").Value.ToString(), _
                                                           Me.dgvOBURADPR_1.SelectedRows.Item(0).Cells("OUAPNDSU").Value.ToString())
            frm_modificar.ShowDialog()

            If vp_inConsulta <> 0 Then
                boCONSULTA = True
            End If

            pro_ReconsultarAdquisicionDePredios()
            pro_ListaDeValoresAdquisicionDePredios()

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub cmdELIMINAR_OBURADPR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdELIMINAR_OBURADPR.Click

        Try
            If MessageBox.Show("¿ Desea eliminar el registro seleccionado ? ", "Mensaje...", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then
                Dim objdatos As New cla_OBURADPR

                If objdatos.fun_Eliminar_IDRE_OBURADPR(Integer.Parse(Me.dgvOBURADPR_1.SelectedRows.Item(0).Cells("OUAPIDRE").Value.ToString())) Then

                    boCONSULTA = False

                    pro_LimpiarAdquisicionDePredios()
                    pro_ReconsultarAdquisicionDePredios()
                    pro_ListaDeValoresAdquisicionDePredios()
                Else
                    frm_INCO_eliminar_registro_padre_con_relación_de_registros_hijos.ShowDialog()
                End If

            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub cmdCONSULTAR_OBURADPR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCONSULTAR_OBURADPR.Click

        Try
            vp_inConsulta = 0

            Dim frm_consultar As New frm_consultar_OBLIURBA(Integer.Parse(Me.dgvOBLIURBA.SelectedRows.Item(0).Cells("OBURIDRE").Value.ToString()))
            frm_consultar.ShowDialog()

            If vp_inConsulta > 0 Then
                boCONSULTA = True
            Else
                boCONSULTA = False
            End If

            pro_ReconsultarObligacionesUrbanisticas()
            pro_ListaDeValoresObligacionesUrbanisticas()

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub cmdRECONSULTAR_OBURADPR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdRECONSULTAR_OBURADPR.Click

        Try
            boCONSULTA = False
            pro_ReconsultarAdquisicionDePredios()
            pro_ListaDeValoresAdquisicionDePredios()

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub

#End Region

#Region "MENU EJECUCION DE OBRA"

    Private Sub cmdAGREGAR_OBUREJOB_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAGREGAR_OBUREJOB.Click

        Try
            If Me.dgvOBLIURBA.RowCount > 0 Then
                Dim frm_insertar As New frm_insertar_OBUREJOB(Me.dgvOBLIURBA.SelectedRows.Item(0).Cells("OBURSECU").Value.ToString(), _
                                                              Me.dgvOBLIURBA.SelectedRows.Item(0).Cells("OBURCLEN").Value.ToString(), _
                                                              Me.dgvOBLIURBA.SelectedRows.Item(0).Cells("OBURNURE").Value.ToString(), _
                                                              Me.dgvOBLIURBA.SelectedRows.Item(0).Cells("OBURFERE").Value.ToString())
                frm_insertar.ShowDialog()
            End If

            boCONSULTA = False

            pro_ReconsultarEjecucionDeObra()
            pro_ListaDeValoresEjecucionDeObra()


        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub cmdMODIFICAR_OBUREJOB_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdMODIFICAR_OBUREJOB.Click

        Try
            Dim frm_modificar As New frm_insertar_OBUREJOB(Me.dgvOBUREJOB_1.SelectedRows.Item(0).Cells("OUEOIDRE").Value.ToString(), _
                                                           Me.dgvOBLIURBA.SelectedRows.Item(0).Cells("OBURSECU").Value.ToString(), _
                                                           Me.dgvOBLIURBA.SelectedRows.Item(0).Cells("OBURCLEN").Value.ToString(), _
                                                           Me.dgvOBLIURBA.SelectedRows.Item(0).Cells("OBURNURE").Value.ToString(), _
                                                           Me.dgvOBLIURBA.SelectedRows.Item(0).Cells("OBURFERE").Value.ToString(), _
                                                           Me.dgvOBUREJOB_1.SelectedRows.Item(0).Cells("OUEONDSU").Value.ToString())
            frm_modificar.ShowDialog()

            If vp_inConsulta <> 0 Then
                boCONSULTA = True
            End If

            pro_ReconsultarEjecucionDeObra()
            pro_ListaDeValoresEjecucionDeObra()

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub cmdELIMINAR_OBUREJOB_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdELIMINAR_OBUREJOB.Click

        Try
            If MessageBox.Show("¿ Desea eliminar el registro seleccionado ? ", "Mensaje...", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then
                Dim objdatos As New cla_OBUREJOB

                If objdatos.fun_Eliminar_IDRE_OBUREJOB(Integer.Parse(Me.dgvOBUREJOB_1.SelectedRows.Item(0).Cells("OUEOIDRE").Value.ToString())) Then

                    boCONSULTA = False

                    pro_LimpiarEjecucionDeObra()
                    pro_ReconsultarEjecucionDeObra()
                    pro_ListaDeValoresEjecucionDeObra()
                Else
                    frm_INCO_eliminar_registro_padre_con_relación_de_registros_hijos.ShowDialog()
                End If

            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub cmdCONSULTAR_OBUREJOB_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCONSULTAR_OBUREJOB.Click

        Try
            vp_inConsulta = 0

            Dim frm_consultar As New frm_consultar_OBLIURBA(Integer.Parse(Me.dgvOBLIURBA.SelectedRows.Item(0).Cells("OBURIDRE").Value.ToString()))
            frm_consultar.ShowDialog()

            If vp_inConsulta > 0 Then
                boCONSULTA = True
            Else
                boCONSULTA = False
            End If

            pro_ReconsultarObligacionesUrbanisticas()
            pro_ListaDeValoresObligacionesUrbanisticas()

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub cmdRECONSULTAR_OBUREJOB_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdRECONSULTAR_OBUREJOB.Click

        Try
            boCONSULTA = False
            pro_ReconsultarEjecucionDeObra()
            pro_ListaDeValoresEjecucionDeObra()

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub

#End Region

#Region "MENU PAGOS REALIZADOS"

    Private Sub cmdAGREGAR_OBURPARE_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAGREGAR_OBURPARE.Click

        Try

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub cmdMODIFICAR_OBURPARE_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdMODIFICAR_OBURPARE.Click

        Try

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub cmdELIMINAR_OBURPARE_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdELIMINAR_OBURPARE.Click

        Try

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub cmdCONSULTAR_OBURPARE_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCONSULTAR_OBURPARE.Click

        Try

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub cmdRECONSULTAR_OBURPARE_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdRECONSULTAR_OBURPARE.Click

        Try

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub

#End Region

#Region "MENU ARCHIVO FISICO"

    Private Sub cmdAGREGAR_OBURARFI_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAGREGAR_OBURARFI.Click

        Try

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub cmdMODIFICAR_OBURARFI_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdMODIFICAR_OBURARFI.Click

        Try

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub cmdELIMINAR_OBURARFI_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdELIMINAR_OBURARFI.Click

        Try

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub cmdCONSULTAR_OBURARFI_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCONSULTAR_OBURARFI.Click

        Try

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub cmdRECONSULTAR_OBURARFI_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdRECONSULTAR_OBURARFI.Click

        Try

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub

#End Region

#Region "FORMULARIO"

#Region "Load"

    Private Sub frm_RESOLICE_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Me.Load
        pro_ReconsultarObligacionesUrbanisticas()
        pro_ListadoArchivosDocumentos()
        Me.strBARRESTA.Items(0).Text = "Obligación urbanistica"
    End Sub

#End Region

#Region "GotFocus"

    Private Sub frm_RESOLICE_GotFocus1(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.GotFocus
        pro_ListaDeValoresObligacionesUrbanisticas()
    End Sub

#End Region

#Region "KeyUp"

    Private Sub dgvREGIMUTA_1_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgvOBLIURBA.KeyUp
        If e.KeyCode = Keys.Down Or e.KeyCode = Keys.Up Or e.KeyCode = Keys.Enter Or e.KeyCode = Keys.PageUp Or e.KeyCode = Keys.PageDown Then
            pro_ListaDeValoresObligacionesUrbanisticas()
        End If
    End Sub
    Private Sub dgvOBURINGE_1_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgvOBURINGE_1.KeyUp, dgvOBURINGE_2.KeyUp
        If e.KeyCode = Keys.Down Or e.KeyCode = Keys.Up Or e.KeyCode = Keys.Enter Or e.KeyCode = Keys.PageUp Or e.KeyCode = Keys.PageDown Then
            pro_ReconsultarPlanParcial()
            pro_ListaDeValoresInformacionGeneral()
        End If
    End Sub
    Private Sub dgvOBURAJLI_1_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgvOBURAJLI_1.KeyUp
        If e.KeyCode = Keys.Down Or e.KeyCode = Keys.Up Or e.KeyCode = Keys.Enter Or e.KeyCode = Keys.PageUp Or e.KeyCode = Keys.PageDown Then
            pro_ReconsultarAjusteDeLiquidacion()
            pro_ListaDeValoresAjusteDeLiquidacion()
        End If
    End Sub
    Private Sub dgvOBURAJLI_2_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgvOBURAJLI_2.KeyUp
        If e.KeyCode = Keys.Down Or e.KeyCode = Keys.Up Or e.KeyCode = Keys.Enter Or e.KeyCode = Keys.PageUp Or e.KeyCode = Keys.PageDown Then
            pro_ListaDeValoresAjusteDeLiquidacionPorAjuste()
        End If
    End Sub
    Private Sub dgvOBURADPR_1_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgvOBURADPR_1.KeyUp, dgvOBURADPR_2.KeyUp
        If e.KeyCode = Keys.Down Or e.KeyCode = Keys.Up Or e.KeyCode = Keys.Enter Or e.KeyCode = Keys.PageUp Or e.KeyCode = Keys.PageDown Then
            pro_ReconsultarAdquisicionDePredios()
            pro_ListaDeValoresAdquisicionDePredios()
        End If
    End Sub
    Private Sub dgvOBUREJOB_1_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgvOBUREJOB_1.KeyUp, dgvOBUREJOB_2.KeyUp
        If e.KeyCode = Keys.Down Or e.KeyCode = Keys.Up Or e.KeyCode = Keys.Enter Or e.KeyCode = Keys.PageUp Or e.KeyCode = Keys.PageDown Then
            pro_ReconsultarEjecucionDeObra()
            pro_ListaDeValoresEjecucionDeObra()
        End If
    End Sub

#End Region

#Region "KeyDown"

    Private Sub dgvREGIMUTA_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgvOBLIURBA.KeyDown
        '===============================================================================================
        '*** INSERTAR REGISTROS ***
        '===============================================================================================


        If e.KeyCode = Keys.F2 Then
            If Me.cmdAGREGAR_OBLIURBA.Enabled = True Then
                Me.cmdAGREGAR_OBLIURBA.PerformClick()
            Else
                mod_MENSAJE.Usuario_No_Tiene_Permiso_Para_Realizar_La_Operacion()
            End If
        End If

        '===============================================================================================
        'MODIFICAR REGISTROS
        '===============================================================================================

        If e.KeyCode = Keys.F3 Then
            If Me.cmdMODIFICAR_OBLIURBA.Enabled = True Then
                Me.cmdMODIFICAR_OBLIURBA.PerformClick()
            Else
                Dim ContarRegistros As Integer = Me.BindingSource_OBURSOLI_1.Count

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
            If Me.cmdELIMINAR_OBLIURBA.Enabled = True Then
                Me.cmdELIMINAR_OBLIURBA.PerformClick()
            Else
                Dim ContarRegistros As Integer = Me.BindingSource_OBURSOLI_1.Count

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
            If Me.cmdCONSULTAR_OBLIURBA.Enabled = True Then
                Me.cmdCONSULTAR_OBLIURBA.PerformClick()
            Else
                mod_MENSAJE.No_Existen_Registros_En_Base_De_Datos()
            End If
        End If

        '===============================================================================================
        '*** RECONSULTAR REGISTROS ***
        '===============================================================================================

        If e.KeyCode = Keys.F8 Then
            If Me.cmdCONSULTAR_OBLIURBA.Enabled = True Then
                Me.cmdRECONSULTAR_OBLIURBA.PerformClick()
            Else
                mod_MENSAJE.No_Existen_Registros_En_Base_De_Datos()
            End If
        End If

    End Sub

#End Region

#Region "CellClick"

    Private Sub dgvOBLIURBA_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvOBLIURBA.CellClick
        pro_ListaDeValoresObligacionesUrbanisticas()
    End Sub
    Private Sub dgvOBURINGE_1_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvOBURINGE_1.CellClick, dgvOBURINGE_2.CellClick
        pro_ReconsultarPlanParcial()
        pro_ListaDeValoresInformacionGeneral()
    End Sub
    Private Sub dgvOBURAJLI_1_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvOBURAJLI_1.CellClick
        pro_ReconsultarAjusteDeLiquidacion()
        pro_ListaDeValoresAjusteDeLiquidacion()
    End Sub
    Private Sub dgvOBURAJLI_2_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvOBURAJLI_2.CellClick
        pro_ListaDeValoresAjusteDeLiquidacionPorAjuste()
    End Sub
    Private Sub dgvOBURADPR_1_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvOBURADPR_1.CellClick, dgvOBURADPR_2.CellClick
        pro_ListaDeValoresAdquisicionDePredios()
    End Sub
    Private Sub dgvOBUREJOB_1_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvOBUREJOB_1.CellClick, dgvOBUREJOB_2.CellClick
        pro_ListaDeValoresEjecucionDeObra()
    End Sub

#End Region

#Region "DoubleClick"

    Private Sub lstLISTADO_DOCUMENTOS_PDF_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles lstLISTADO_DOCUMENTOS_PDF.DoubleClick

        Try
            If lstLISTADO_DOCUMENTOS_PDF.SelectedIndex <> -1 Then

                Dim stArchivo As String = lstLISTADO_DOCUMENTOS_PDF.SelectedItem
                Process.Start(vl_stRutaDocumentosPDF & "\" & stArchivo)
            Else

                If lstLISTADO_DOCUMENTOS_PDF.Items.Count > 0 Then
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