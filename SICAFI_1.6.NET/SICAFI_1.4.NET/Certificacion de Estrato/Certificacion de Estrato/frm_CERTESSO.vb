Imports REGLAS_DEL_NEGOCIO
Imports System
Imports System.IO
Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration
Imports System.Text

Public Class frm_CERTESSO

    '===============================================
    '*** CERTIFICACION DE ESTRATO SOCIOECONOMICO ***
    '===============================================

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

    Public Shared Function instance() As frm_CERTESSO
        If frm_Instance Is Nothing OrElse frm_Instance.isdisposed = True Then
            frm_Instance = New frm_CERTESSO
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

            tblRutas = objRutas.fun_Buscar_CODIGO_MANT_RUTAS(23)

            If tblRutas.Rows.Count > 0 Then

                ' directorio pricipal
                stRuta = Trim(tblRutas.Rows(0).Item("RUTARUTA")) & "\"

                ' directorio expediente 
                stCarpetaABuscar = Trim(Me.dgvCERTESSO.SelectedRows.Item(0).Cells("CEESNURA").Value.ToString) & "-" & _
                                   Trim(Me.dgvCERTESSO.SelectedRows.Item(0).Cells("CEESFERA").Value.ToString)

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

#Region "PROCEDIMIENTO ESTRATO SOCIOECONOMICO"

    Private Sub pro_ReconsultarCertificacionDeEstratoSocioeconomico()

        Try
            Dim objdatos As New cla_CERTESSO

            If boCONSULTA = False Then
                Me.BindingSource_CERTESSO_1.DataSource = objdatos.fun_Consultar_CERTESSO
            Else
                Me.BindingSource_CERTESSO_1.DataSource = objdatos.fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_CERTESSO(vp_inConsulta)
            End If

            Me.dgvCERTESSO.DataSource = BindingSource_CERTESSO_1
            Me.BindingNavigator_CERTESSO_1.BindingSource = BindingSource_CERTESSO_1

            '=================================================
            '*** CONFIGURA OBJETOS DEL FORMULARIO MAESTRO ***
            '=================================================

            Me.strBARRESTA.Items(2).Text = "Registros : " & Me.BindingSource_CERTESSO_1.Count

            Me.dgvCERTESSO.Columns("ACADDESC").HeaderText = "Clasificación"
            Me.dgvCERTESSO.Columns("MEREDESC").HeaderText = "Medio de Resepción"
            Me.dgvCERTESSO.Columns("CEESNURA").HeaderText = "Nro. Radicado"
            Me.dgvCERTESSO.Columns("CEESFERA").HeaderText = "Fecha Radicado"
            Me.dgvCERTESSO.Columns("CEESFEIN").HeaderText = "Fecha Ingreso"
            Me.dgvCERTESSO.Columns("CEESFEFI").HeaderText = "Fecha Finalización"
            Me.dgvCERTESSO.Columns("ESTADESC").HeaderText = "Estado"

            Me.dgvCERTESSO.Columns("CEESIDRE").Visible = False
            Me.dgvCERTESSO.Columns("CEESSECU").Visible = False
            Me.dgvCERTESSO.Columns("CEESCLAS").Visible = False
            Me.dgvCERTESSO.Columns("CEESMERE").Visible = False
            Me.dgvCERTESSO.Columns("CEESVIRA").Visible = False
            Me.dgvCERTESSO.Columns("CEESVIGE").Visible = False
            Me.dgvCERTESSO.Columns("CEESASUN").Visible = False
            Me.dgvCERTESSO.Columns("CEESOFSA").Visible = False
            Me.dgvCERTESSO.Columns("CEESESTA").Visible = False
            Me.dgvCERTESSO.Columns("CEESNDIN").Visible = False
            Me.dgvCERTESSO.Columns("CEESUSFI").Visible = False
            Me.dgvCERTESSO.Columns("CEESNDFI").Visible = False
            Me.dgvCERTESSO.Columns("CEESMAQU").Visible = False
            Me.dgvCERTESSO.Columns("CEESUSIN").Visible = False
            Me.dgvCERTESSO.Columns("CEESOBSE").Visible = False

            '==================================================
            '*** ASIGNA LOS PRIVILEGIOS DE LA BARRA DE MENU ***
            '==================================================

            Dim ContarRegistros As Integer = Me.BindingSource_CERTESSO_1.Count

            Dim boCONTAGRE As Boolean = False
            Dim boCONTMODI As Boolean = False
            Dim boCONTELIM As Boolean = False
            Dim boCONTCONS As Boolean = False
            Dim boCONTRECO As Boolean = False

            pro_Permiso_Barra_De_Menu_Formulario_SubFormulario(ContarRegistros, Trim(Me.BindingNavigator_CERTESSO_1.Name), boCONTAGRE, boCONTMODI, boCONTELIM, boCONTCONS, boCONTRECO)

            Me.cmdAGREGAR_CERTESSO.Enabled = boCONTAGRE
            Me.cmdMODIFICAR_CERTESSO.Enabled = boCONTMODI
            Me.cmdELIMINAR_CERTESSO.Enabled = boCONTELIM
            Me.cmdCONSULTAR_CERTESSO.Enabled = True
            Me.cmdRECONSULTAR_CERTESSO.Enabled = boCONTRECO

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub pro_ListaDeValoresCertificacionDeEstratoSocioeconomico()

        Try
            If Me.dgvCERTESSO.RowCount > 0 Then

                Dim objdatos As New cla_CERTESSO
                Dim tbldatos As New DataTable

                tbldatos = objdatos.fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_CERTESSO(CInt(Me.dgvCERTESSO.SelectedRows.Item(0).Cells("CEESIDRE").Value.ToString()))

                If tbldatos.Rows.Count > 0 Then

                    Me.txtCEESSECU.Text = Trim(tbldatos.Rows(0).Item("CEESSECU").ToString)
                    Me.txtCEESNURA.Text = Trim(tbldatos.Rows(0).Item("CEESNURA").ToString)
                    Me.txtCEESFERA.Text = Trim(tbldatos.Rows(0).Item("CEESFERA").ToString)
                    Me.txtCEESVIRA.Text = Trim(tbldatos.Rows(0).Item("CEESVIRA").ToString)
                    Me.txtCEESFEIN.Text = Trim(tbldatos.Rows(0).Item("CEESFEIN").ToString)
                    Me.txtCEESFEFI.Text = Trim(tbldatos.Rows(0).Item("CEESFEFI").ToString)
                    Me.txtCEESASUN.Text = Trim(tbldatos.Rows(0).Item("CEESASUN").ToString)
                    Me.txtCEESOFSA.Text = Trim(tbldatos.Rows(0).Item("CEESOFSA").ToString)
                    Me.txtCEESOBSE.Text = Trim(tbldatos.Rows(0).Item("CEESOBSE").ToString)

                    Me.txtCEESNDIN.Text = CType(fun_Buscar_Lista_Valores_USUARIO(Trim(tbldatos.Rows(0).Item("CEESNDIN"))), String)
                    Me.txtCEESNDFI.Text = CType(fun_Buscar_Lista_Valores_USUARIO(Trim(tbldatos.Rows(0).Item("CEESNDFI"))), String)

                End If

                pro_ReconsultarSolicitante()
                pro_ListaDeValoresSolicitante()

                pro_ReconsultarPredio()
                pro_ListaDeValoresPredio()

                pro_ControldeBindingNavigator()
                pro_LimpiarDocumentos()

                pro_ListadoArchivosDocumentos()

            Else
                pro_LimpiarCamposCertificacionDeEstratoSocioeconomico()
                pro_LimpiarCamposSolicitante()
                pro_LimpiarCamposPredio()
                pro_LimpiarDocumentos()

                Me.BindingNavigator_CEESSOLI_1.Enabled = False
                Me.BindingNavigator_CEESPRED_1.Enabled = False

            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub pro_ControldeBindingNavigator()

        If Me.dgvCERTESSO.RowCount > 0 Then

            Me.BindingNavigator_CERTESSO_1.Enabled = True
            Me.BindingNavigator_CEESSOLI_1.Enabled = True
            Me.BindingNavigator_CEESPRED_1.Enabled = True

        Else
            Me.BindingNavigator_CERTESSO_1.Enabled = False
            Me.BindingNavigator_CEESSOLI_1.Enabled = False
            Me.BindingNavigator_CEESPRED_1.Enabled = False


        End If

    End Sub
    Private Sub pro_LimpiarCamposCertificacionDeEstratoSocioeconomico()

        Me.txtCEESSECU.Text = ""
        Me.txtCEESNURA.Text = ""
        Me.txtCEESFERA.Text = ""
        Me.txtCEESVIRA.Text = ""
        Me.txtCEESNDIN.Text = ""
        Me.txtCEESFEIN.Text = ""
        Me.txtCEESNDFI.Text = ""
        Me.txtCEESFEFI.Text = ""
        Me.txtCEESASUN.Text = ""
        Me.txtCEESOFSA.Text = ""
        Me.txtCEESOBSE.Text = ""

        Me.strBARRESTA.Items(2).Text = "Registros : 0"

    End Sub
    Private Sub pro_LimpiarDocumentos()

        Me.lstLISTADO_DOCUMENTOS_PDF.Items.Clear()

    End Sub
    Private Sub pro_EjecutarBotonObservaciones()

        Try
            If Me.dgvCERTESSO.RowCount > 0 Then

                If MessageBox.Show("¿ Desea ingresar una observación ? ", "Mensaje...", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then

                    Dim stObservacionNueva As String = InputBox("Ingrese la observación.", "Mensaje")

                    If Trim(stObservacionNueva) = "" Then
                        MessageBox.Show("Se requiere una observación.", "Mensaje...", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                        mod_MENSAJE.No_Se_Modifico_El_Registro_En_La_Base_De_Datos()
                    Else

                        Dim stREMUOBSE_ACTUAL As String = ""
                        Dim stREMUOBSE_NUEVA As String = Trim(stObservacionNueva.ToString.ToUpper)

                        Dim obMOGEGEOG As New cla_CERTESSO
                        Dim dtAJUSGEOG As New DataTable

                        dtAJUSGEOG = obMOGEGEOG.fun_Buscar_ID_CERTESSO(Me.dgvCERTESSO.SelectedRows.Item(0).Cells("CEESIDRE").Value.ToString())

                        If dtAJUSGEOG.Rows.Count > 0 Then
                            stREMUOBSE_ACTUAL = Trim(dtAJUSGEOG.Rows(0).Item("CEESOBSE").ToString)
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
                        Dim inMOGEIDRE As Integer = Integer.Parse(Me.dgvCERTESSO.SelectedRows.Item(0).Cells("CEESIDRE").Value.ToString())

                        ' parametros de la consulta
                        Dim ParametrosConsulta As String = ""

                        ' Concatena la condicion de la consulta
                        ParametrosConsulta += "update CERTESSO "
                        ParametrosConsulta += "set CEESOBSE = '" & stREMUOBSE_ACTUAL & "' "
                        ParametrosConsulta += "where CEESIDRE = '" & inMOGEIDRE & "' "

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

                        pro_ReconsultarCertificacionDeEstratoSocioeconomico()
                        pro_ListaDeValoresCertificacionDeEstratoSocioeconomico()

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

            tblRutas = objRutas.fun_Buscar_CODIGO_MANT_RUTAS(23)

            If tblRutas.Rows.Count > 0 AndAlso fun_VerificarCarpetaExistenteDocumentos() = True Then

                stNewPath = Trim(tblRutas.Rows(0).Item("RUTARUTA")) & "\" & Trim(Me.dgvCERTESSO.SelectedRows.Item(0).Cells("CEESNURA").Value.ToString) & "-" & _
                                                                            Trim(Me.dgvCERTESSO.SelectedRows.Item(0).Cells("CEESFERA").Value.ToString)

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

#End Region

#Region "PROCEDIMIENTO SOLICITANTE"

    Private Sub pro_ReconsultarSolicitante()

        Try
            Dim objdatos As New cla_CEESSOLI

            If boCONSULTA = False Then
                Me.BindingSource_CEESSOLI_1.DataSource = objdatos.fun_Buscar_SECU_X_CONSULTA_PARAMETRIZADA_CEESSOLI(Me.dgvCERTESSO.SelectedRows.Item(0).Cells("CEESSECU").Value.ToString())
            Else
                Me.BindingSource_CEESSOLI_1.DataSource = objdatos.fun_Buscar_SECU_X_CONSULTA_PARAMETRIZADA_CEESSOLI(Me.dgvCERTESSO.SelectedRows.Item(0).Cells("CEESSECU").Value.ToString())
            End If

            Me.dgvCEESSOLI_1.DataSource = BindingSource_CEESSOLI_1
            Me.dgvCEESSOLI_2.DataSource = BindingSource_CEESSOLI_1
            Me.dgvCEESSOLI_3.DataSource = BindingSource_CEESSOLI_1
            Me.BindingNavigator_CEESSOLI_1.BindingSource = BindingSource_CEESSOLI_1

            '=================================================
            '*** CONFIGURA OBJETOS DEL FORMULARIO MAESTRO ***
            '=================================================

            Me.strBARRESTA.Items(2).Text = "Registros : " & Me.BindingSource_CERTESSO_1.Count

            Me.dgvCEESSOLI_1.Columns("SOLIDESC").HeaderText = "Solicitante"
            Me.dgvCEESSOLI_1.Columns("CESONUDO").HeaderText = "Nro. Documento"
            Me.dgvCEESSOLI_1.Columns("CESONOMB").HeaderText = "Nombre(s)"
            Me.dgvCEESSOLI_1.Columns("CESOPRAP").HeaderText = "Primer apellido"
            Me.dgvCEESSOLI_1.Columns("CESOSEAP").HeaderText = "Segundo apellido"

            Me.dgvCEESSOLI_1.Columns("CESOIDRE").Visible = False
            Me.dgvCEESSOLI_1.Columns("CESOSOLI").Visible = False
            Me.dgvCEESSOLI_1.Columns("CESODIPR").Visible = False
            Me.dgvCEESSOLI_1.Columns("CESODINO").Visible = False
            Me.dgvCEESSOLI_1.Columns("CESODINO").Visible = False
            Me.dgvCEESSOLI_1.Columns("CESOTELE").Visible = False
            Me.dgvCEESSOLI_1.Columns("CESOCELU").Visible = False
            Me.dgvCEESSOLI_1.Columns("CESOCOEL").Visible = False
            Me.dgvCEESSOLI_1.Columns("CESOCOPO").Visible = False
            Me.dgvCEESSOLI_1.Columns("CESORESO").Visible = False
            Me.dgvCEESSOLI_1.Columns("CESONURA").Visible = False
            Me.dgvCEESSOLI_1.Columns("CESOFERA").Visible = False
            Me.dgvCEESSOLI_1.Columns("CESOSECU").Visible = False
            Me.dgvCEESSOLI_1.Columns("CESOESTA").Visible = False
            Me.dgvCEESSOLI_1.Columns("CESOPROY").Visible = False
            Me.dgvCEESSOLI_1.Columns("ESTADESC").Visible = False

            Me.dgvCEESSOLI_2.Columns("CESODIPR").HeaderText = "Dirección del predio"
            Me.dgvCEESSOLI_2.Columns("CESODINO").HeaderText = "Dirección de notificación"
            Me.dgvCEESSOLI_2.Columns("CESOPROY").HeaderText = "Proyecto"

            Me.dgvCEESSOLI_2.Columns("CESOIDRE").Visible = False
            Me.dgvCEESSOLI_2.Columns("CESOSOLI").Visible = False
            Me.dgvCEESSOLI_2.Columns("CESONUDO").Visible = False
            Me.dgvCEESSOLI_2.Columns("CESONOMB").Visible = False
            Me.dgvCEESSOLI_2.Columns("CESOPRAP").Visible = False
            Me.dgvCEESSOLI_2.Columns("CESOSEAP").Visible = False
            Me.dgvCEESSOLI_2.Columns("CESONURA").Visible = False
            Me.dgvCEESSOLI_2.Columns("CESOFERA").Visible = False
            Me.dgvCEESSOLI_2.Columns("CESOSECU").Visible = False
            Me.dgvCEESSOLI_2.Columns("SOLIDESC").Visible = False
            Me.dgvCEESSOLI_2.Columns("CESOTELE").Visible = False
            Me.dgvCEESSOLI_2.Columns("CESOCELU").Visible = False
            Me.dgvCEESSOLI_2.Columns("CESOCOPO").Visible = False
            Me.dgvCEESSOLI_2.Columns("ESTADESC").Visible = False
            Me.dgvCEESSOLI_2.Columns("CESOESTA").Visible = False
            Me.dgvCEESSOLI_2.Columns("CESORESO").Visible = False
            Me.dgvCEESSOLI_2.Columns("CESOCOEL").Visible = False

            Me.dgvCEESSOLI_3.Columns("CESOTELE").HeaderText = "Telefono"
            Me.dgvCEESSOLI_3.Columns("CESOCELU").HeaderText = "Celular"
            Me.dgvCEESSOLI_3.Columns("CESOCOEL").HeaderText = "Correo electronico"
            Me.dgvCEESSOLI_3.Columns("CESOCOPO").HeaderText = "Código postal"
            Me.dgvCEESSOLI_3.Columns("ESTADESC").HeaderText = "Estado"

            Me.dgvCEESSOLI_3.Columns("CESOIDRE").Visible = False
            Me.dgvCEESSOLI_3.Columns("SOLIDESC").Visible = False
            Me.dgvCEESSOLI_3.Columns("CESOSOLI").Visible = False
            Me.dgvCEESSOLI_3.Columns("CESONUDO").Visible = False
            Me.dgvCEESSOLI_3.Columns("CESONOMB").Visible = False
            Me.dgvCEESSOLI_3.Columns("CESOPRAP").Visible = False
            Me.dgvCEESSOLI_3.Columns("CESOSEAP").Visible = False
            Me.dgvCEESSOLI_3.Columns("CESODIPR").Visible = False
            Me.dgvCEESSOLI_3.Columns("CESODINO").Visible = False
            Me.dgvCEESSOLI_3.Columns("CESODINO").Visible = False
            Me.dgvCEESSOLI_3.Columns("CESORESO").Visible = False
            Me.dgvCEESSOLI_3.Columns("CESONURA").Visible = False
            Me.dgvCEESSOLI_3.Columns("CESOFERA").Visible = False
            Me.dgvCEESSOLI_3.Columns("CESOSECU").Visible = False
            Me.dgvCEESSOLI_3.Columns("CESOESTA").Visible = False
            Me.dgvCEESSOLI_3.Columns("CESOPROY").Visible = False

            '==================================================
            '*** ASIGNA LOS PRIVILEGIOS DE LA BARRA DE MENU ***
            '==================================================

            Dim ContarRegistros As Integer = Me.BindingSource_CEESSOLI_1.Count

            Dim boCONTAGRE As Boolean = False
            Dim boCONTMODI As Boolean = False
            Dim boCONTELIM As Boolean = False
            Dim boCONTCONS As Boolean = False
            Dim boCONTRECO As Boolean = False

            pro_Permiso_Barra_De_Menu_Formulario_SubFormulario(ContarRegistros, Trim(Me.BindingNavigator_CEESSOLI_1.Name), boCONTAGRE, boCONTMODI, boCONTELIM, boCONTCONS, boCONTRECO)

            Me.cmdAGREGAR_CEESSOLI.Enabled = boCONTAGRE
            Me.cmdMODIFICAR_CEESSOLI.Enabled = boCONTMODI
            Me.cmdELIMINAR_CEESSOLI.Enabled = boCONTELIM
            Me.cmdCONSULTAR_CEESSOLI.Enabled = boCONTCONS
            Me.cmdRECONSULTAR_CEESSOLI.Enabled = boCONTRECO

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub pro_ListaDeValoresSolicitante()

    End Sub
    Private Sub pro_LimpiarCamposSolicitante()

        Me.dgvCEESSOLI_1.DataSource = New DataTable
        Me.dgvCEESSOLI_2.DataSource = New DataTable
        Me.dgvCEESSOLI_3.DataSource = New DataTable

    End Sub

#End Region

#Region "PROCEDIMIENTO PREDIO"

    Private Sub pro_ReconsultarPredio()

        Try
            Dim objdatos As New cla_CEESPRED

            If boCONSULTA = False Then
                Me.BindingSource_CEESPRED_1.DataSource = objdatos.fun_Buscar_SECU_X_CONSULTA_PARAMETRIZADA_CEESPRED(Me.dgvCERTESSO.SelectedRows.Item(0).Cells("CEESSECU").Value.ToString())
            Else
                Me.BindingSource_CEESPRED_1.DataSource = objdatos.fun_Buscar_SECU_X_CONSULTA_PARAMETRIZADA_CEESPRED(Me.dgvCERTESSO.SelectedRows.Item(0).Cells("CEESSECU").Value.ToString())
            End If

            Me.dgvCEESPRED_1.DataSource = BindingSource_CEESPRED_1
            Me.dgvCEESPRED_2.DataSource = BindingSource_CEESPRED_1
            Me.dgvCEESPRED_3.DataSource = BindingSource_CEESPRED_1
            Me.BindingNavigator_CEESPRED_1.BindingSource = BindingSource_CEESPRED_1

            '=================================================
            '*** CONFIGURA OBJETOS DEL FORMULARIO MAESTRO ***
            '=================================================

            Me.strBARRESTA.Items(2).Text = "Registros : " & Me.BindingSource_CERTESSO_1.Count

            Me.dgvCEESPRED_1.Columns("CEPRMUNI").HeaderText = "Municipio"
            Me.dgvCEESPRED_1.Columns("CEPRCORR").HeaderText = "Corregimiento"
            Me.dgvCEESPRED_1.Columns("CEPRBARR").HeaderText = "Barrio"
            Me.dgvCEESPRED_1.Columns("CEPRMANZ").HeaderText = "Manzana Vereda"
            Me.dgvCEESPRED_1.Columns("CEPRPRED").HeaderText = "Predio"
            Me.dgvCEESPRED_1.Columns("CEPREDIF").HeaderText = "Edificio"
            Me.dgvCEESPRED_1.Columns("CEPRUNPR").HeaderText = "Unidad Predial"
            Me.dgvCEESPRED_1.Columns("CLSEDESC").HeaderText = "Clase o Sector"

            Me.dgvCEESPRED_1.Columns("CEPRIDRE").Visible = False
            Me.dgvCEESPRED_1.Columns("CEPRNURA").Visible = False
            Me.dgvCEESPRED_1.Columns("CEPRFERA").Visible = False
            Me.dgvCEESPRED_1.Columns("CEPRSECU").Visible = False

            Me.dgvCEESPRED_1.Columns("CEPRDIPR").Visible = False
            Me.dgvCEESPRED_1.Columns("CEPRMAIN").Visible = False
            Me.dgvCEESPRED_1.Columns("CEPRNUFI").Visible = False
            Me.dgvCEESPRED_1.Columns("CEPRARTE").Visible = False
            Me.dgvCEESPRED_1.Columns("CEPRVATP").Visible = False
            Me.dgvCEESPRED_1.Columns("CEPRVACP").Visible = False
            Me.dgvCEESPRED_1.Columns("CEPRAVCA").Visible = False
            Me.dgvCEESPRED_1.Columns("ZOPLDESC").Visible = False
            Me.dgvCEESPRED_1.Columns("ESTADESC").Visible = False
            Me.dgvCEESPRED_1.Columns("CEPRZOPL").Visible = False
            Me.dgvCEESPRED_1.Columns("CEPRESTA").Visible = False
            Me.dgvCEESPRED_1.Columns("CEPRCLSE").Visible = False
            Me.dgvCEESPRED_1.Columns("CEPRUNID").Visible = False
            Me.dgvCEESPRED_1.Columns("SERVDESC").Visible = False
            Me.dgvCEESPRED_1.Columns("CEPRPRPH").Visible = False

            Me.dgvCEESPRED_2.Columns("CEPRUNID").HeaderText = "Nro. Unidades"
            Me.dgvCEESPRED_2.Columns("CEPRDIPR").HeaderText = "Dirección Predio"
            Me.dgvCEESPRED_2.Columns("CEPRMAIN").HeaderText = "Matricula Inmobiliria"
            Me.dgvCEESPRED_2.Columns("ZOPLDESC").HeaderText = "Zona de Planificación"
            Me.dgvCEESPRED_2.Columns("SERVDESC").HeaderText = "Servicios"
            Me.dgvCEESPRED_2.Columns("CEPRPRPH").HeaderText = "Predio en R.P.H."

            Me.dgvCEESPRED_2.Columns("CEPRIDRE").Visible = False
            Me.dgvCEESPRED_2.Columns("CEPRNURA").Visible = False
            Me.dgvCEESPRED_2.Columns("CEPRFERA").Visible = False
            Me.dgvCEESPRED_2.Columns("CEPRSECU").Visible = False

            Me.dgvCEESPRED_2.Columns("CLSEDESC").Visible = False
            Me.dgvCEESPRED_2.Columns("CEPRMUNI").Visible = False
            Me.dgvCEESPRED_2.Columns("CEPRCORR").Visible = False
            Me.dgvCEESPRED_2.Columns("CEPRBARR").Visible = False
            Me.dgvCEESPRED_2.Columns("CEPRMANZ").Visible = False
            Me.dgvCEESPRED_2.Columns("CEPRPRED").Visible = False
            Me.dgvCEESPRED_2.Columns("CEPREDIF").Visible = False
            Me.dgvCEESPRED_2.Columns("CEPRUNPR").Visible = False
            Me.dgvCEESPRED_2.Columns("CEPRARTE").Visible = False
            Me.dgvCEESPRED_2.Columns("CEPRVATP").Visible = False
            Me.dgvCEESPRED_2.Columns("CEPRVACP").Visible = False
            Me.dgvCEESPRED_2.Columns("CEPRAVCA").Visible = False
            Me.dgvCEESPRED_2.Columns("CEPRZOPL").Visible = False
            Me.dgvCEESPRED_2.Columns("CEPRESTA").Visible = False
            Me.dgvCEESPRED_2.Columns("ESTADESC").Visible = False
            Me.dgvCEESPRED_2.Columns("CEPRCLSE").Visible = False
            Me.dgvCEESPRED_2.Columns("CEPRNUFI").Visible = False

            Me.dgvCEESPRED_3.Columns("CEPRNUFI").HeaderText = "Nro. Ficha Predial"
            Me.dgvCEESPRED_3.Columns("CEPRARTE").HeaderText = "Área de terreno m2"
            Me.dgvCEESPRED_3.Columns("CEPRVATP").HeaderText = "Valor Terreno"
            Me.dgvCEESPRED_3.Columns("CEPRVACP").HeaderText = "Valor Construcción"
            Me.dgvCEESPRED_3.Columns("CEPRAVCA").HeaderText = "Avalúo Catastral"
            Me.dgvCEESPRED_3.Columns("ESTADESC").HeaderText = "Estado"

            Me.dgvCEESPRED_3.Columns("CEPRIDRE").Visible = False
            Me.dgvCEESPRED_3.Columns("CEPRNURA").Visible = False
            Me.dgvCEESPRED_3.Columns("CEPRFERA").Visible = False
            Me.dgvCEESPRED_3.Columns("CEPRSECU").Visible = False

            Me.dgvCEESPRED_3.Columns("CEPRMUNI").Visible = False
            Me.dgvCEESPRED_3.Columns("CEPRCORR").Visible = False
            Me.dgvCEESPRED_3.Columns("CEPRBARR").Visible = False
            Me.dgvCEESPRED_3.Columns("CEPRMANZ").Visible = False
            Me.dgvCEESPRED_3.Columns("CEPRPRED").Visible = False
            Me.dgvCEESPRED_3.Columns("CEPREDIF").Visible = False
            Me.dgvCEESPRED_3.Columns("CEPRUNPR").Visible = False
            Me.dgvCEESPRED_3.Columns("CLSEDESC").Visible = False
            Me.dgvCEESPRED_3.Columns("CEPRDIPR").Visible = False
            Me.dgvCEESPRED_3.Columns("CEPRMAIN").Visible = False
            Me.dgvCEESPRED_3.Columns("ZOPLDESC").Visible = False
            Me.dgvCEESPRED_3.Columns("CEPRZOPL").Visible = False
            Me.dgvCEESPRED_3.Columns("CEPRESTA").Visible = False
            Me.dgvCEESPRED_3.Columns("CEPRCLSE").Visible = False
            Me.dgvCEESPRED_3.Columns("CEPRUNID").Visible = False
            Me.dgvCEESPRED_3.Columns("SERVDESC").Visible = False
            Me.dgvCEESPRED_3.Columns("CEPRPRPH").Visible = False

            Me.dgvCEESPRED_3.Columns("CEPRVATP").DefaultCellStyle.Format = "c"
            Me.dgvCEESPRED_3.Columns("CEPRVACP").DefaultCellStyle.Format = "c"
            Me.dgvCEESPRED_3.Columns("CEPRAVCA").DefaultCellStyle.Format = "c"
            Me.dgvCEESPRED_3.Columns("CEPRARTE").DefaultCellStyle.Format = "n"

            Me.dgvCEESPRED_3.Columns("CEPRVATP").DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopRight
            Me.dgvCEESPRED_3.Columns("CEPRVACP").DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopRight
            Me.dgvCEESPRED_3.Columns("CEPRAVCA").DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopRight

            Me.dgvCEESPRED_2.Columns("CEPRDIPR").Width = 300

            '==================================================
            '*** ASIGNA LOS PRIVILEGIOS DE LA BARRA DE MENU ***
            '==================================================

            Dim ContarRegistros As Integer = Me.BindingSource_CEESPRED_1.Count

            Dim boCONTAGRE As Boolean = False
            Dim boCONTMODI As Boolean = False
            Dim boCONTELIM As Boolean = False
            Dim boCONTCONS As Boolean = False
            Dim boCONTRECO As Boolean = False

            pro_Permiso_Barra_De_Menu_Formulario_SubFormulario(ContarRegistros, Trim(Me.BindingNavigator_CEESPRED_1.Name), boCONTAGRE, boCONTMODI, boCONTELIM, boCONTCONS, boCONTRECO)

            Me.cmdAGREGAR_CEESPRED.Enabled = boCONTAGRE
            Me.cmdMODIFICAR_CEESPRED.Enabled = boCONTMODI
            Me.cmdELIMINAR_CEESPRED.Enabled = boCONTELIM
            Me.cmdCONSULTAR_CEESPRED.Enabled = boCONTCONS
            Me.cmdRECONSULTAR_CEESPRED.Enabled = boCONTRECO

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub pro_ListaDeValoresPredio()

    End Sub
    Private Sub pro_LimpiarCamposPredio()

        Me.dgvCEESPRED_1.DataSource = New DataTable
        Me.dgvCEESPRED_2.DataSource = New DataTable
        Me.dgvCEESPRED_3.DataSource = New DataTable

    End Sub

#End Region

#Region "MENU ESTRATO SOCIOECONOMICO"

    Private Sub cmdAGREGAR_CERTESSO_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAGREGAR_CERTESSO.Click

        Try

            If Me.dgvCERTESSO.RowCount > 0 Then
                Dim frm_insertar As New frm_insertar_CERTESSO(Integer.Parse(Me.dgvCERTESSO.SelectedRows.Item(0).Cells("CEESIDRE").Value.ToString()))
                frm_insertar.ShowDialog()
            Else
                frm_insertar_CERTESSO.ShowDialog()
            End If

            If vp_inConsulta > 0 Then
                boCONSULTA = True
            Else
                boCONSULTA = False
            End If

            pro_ReconsultarCertificacionDeEstratoSocioeconomico()
            pro_ListaDeValoresCertificacionDeEstratoSocioeconomico()

            If MessageBox.Show("Desea diligenciar el solicitante", "Mensaje ...", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then
                TabMAESTRO_2.SelectTab(TabSolicitante)
                cmdAGREGAR_CEESSOLI.PerformClick()
            Else
                TabMAESTRO_2.SelectTab(TabRadicacion)
            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub cmdMODIFICAR_CERTESSO_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdMODIFICAR_CERTESSO.Click

        Try
            Dim frm_modificar As New frm_modificar_CERTESSO(Integer.Parse(Me.dgvCERTESSO.SelectedRows.Item(0).Cells("CEESIDRE").Value.ToString()))
            frm_modificar.ShowDialog()

            If vp_inConsulta <> 0 Then
                boCONSULTA = True
            End If

            pro_ReconsultarCertificacionDeEstratoSocioeconomico()
            pro_ListaDeValoresCertificacionDeEstratoSocioeconomico()

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub cmdELIMINAR_CERTESSO_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdELIMINAR_CERTESSO.Click

        Try
            If MessageBox.Show("¿ Desea eliminar el registro seleccionado ? ", "Mensaje...", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then
                Dim objdatos As New cla_CERTESSO

                If objdatos.fun_Eliminar_IDRE_CERTESSO(Integer.Parse(Me.dgvCERTESSO.SelectedRows.Item(0).Cells("CEESIDRE").Value.ToString())) Then

                    boCONSULTA = False

                    pro_LimpiarCamposCertificacionDeEstratoSocioeconomico()
                    pro_ReconsultarCertificacionDeEstratoSocioeconomico()
                    pro_ListaDeValoresCertificacionDeEstratoSocioeconomico()
                Else
                    frm_INCO_eliminar_registro_padre_con_relación_de_registros_hijos.ShowDialog()
                End If

            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub cmdCONSULTAR_CERTESSO_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCONSULTAR_CERTESSO.Click

        Try
            vp_inConsulta = 0

            If Me.dgvCERTESSO.RowCount > 0 Then
                Dim frm_consultar As New frm_consultar_CERTESSO(Integer.Parse(Me.dgvCERTESSO.SelectedRows.Item(0).Cells("CEESIDRE").Value.ToString()))
                frm_consultar.ShowDialog()
            Else
                Dim frm_consultar As New frm_consultar_CERTESSO()
                frm_consultar.ShowDialog()
            End If

            If vp_inConsulta > 0 Then
                boCONSULTA = True
            Else
                boCONSULTA = False
            End If

            pro_ReconsultarCertificacionDeEstratoSocioeconomico()
            pro_ListaDeValoresCertificacionDeEstratoSocioeconomico()

            Me.TabMAESTRO_2.SelectTab(TabRadicacion)

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub cmdRECONSULTAR_CERTESSO_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdRECONSULTAR_CERTESSO.Click

        Try
            If Me.dgvCERTESSO.RowCount > 0 Then
                boCONSULTA = True
            Else
                boCONSULTA = False
            End If

            pro_ReconsultarCertificacionDeEstratoSocioeconomico()
            pro_ListaDeValoresCertificacionDeEstratoSocioeconomico()

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
            If Me.dgvCERTESSO.RowCount > 0 Then

                Dim frm_inserta_archivo As New frm_insertar_archivo_CERTESSO(Me.dgvCERTESSO.SelectedRows.Item(0).Cells("CEESNURA").Value.ToString(), _
                                                                             Me.dgvCERTESSO.SelectedRows.Item(0).Cells("CEESFERA").Value.ToString())
                frm_inserta_archivo.ShowDialog()

                pro_ListadoArchivosDocumentos()

                vp_inConsulta = Me.dgvCERTESSO.SelectedRows.Item(0).Cells("CEESIDRE").Value.ToString()

                If vp_inConsulta <> 0 Then
                    boCONSULTA = True
                Else
                    boCONSULTA = False
                End If

                pro_ReconsultarCertificacionDeEstratoSocioeconomico()
                pro_ListaDeValoresCertificacionDeEstratoSocioeconomico()

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
            pro_ListaDeValoresCertificacionDeEstratoSocioeconomico()

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub ToolStripButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton2.Click

        Try
            pro_ListaDeValoresCertificacionDeEstratoSocioeconomico()

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub ToolStripButton3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton3.Click

        Try
            pro_ListaDeValoresCertificacionDeEstratoSocioeconomico()

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub ToolStripButton4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton4.Click

        Try
            pro_ListaDeValoresCertificacionDeEstratoSocioeconomico()

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub

#End Region

#Region "MENU SOLICITANTE"

    Private Sub cmdAGREGAR_CEESSOLI_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAGREGAR_CEESSOLI.Click

        Try
            If Me.dgvCERTESSO.RowCount > 0 Then
                Dim frm_insertar As New frm_insertar_CEESSOLI(Me.dgvCERTESSO.SelectedRows.Item(0).Cells("CEESSECU").Value.ToString(), _
                                                              Me.dgvCERTESSO.SelectedRows.Item(0).Cells("CEESNURA").Value.ToString(), _
                                                              Me.dgvCERTESSO.SelectedRows.Item(0).Cells("CEESFERA").Value.ToString())
                frm_insertar.ShowDialog()
            End If

            boCONSULTA = False

            pro_ReconsultarSolicitante()
            pro_ListaDeValoresSolicitante()

            If MessageBox.Show("Desea diligenciar el predio", "Mensaje ...", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then
                TabMAESTRO_2.SelectTab(TabPredios)
                cmdAGREGAR_CEESPRED.PerformClick()
            Else
                TabMAESTRO_2.SelectTab(TabSolicitante)
            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub cmdMODIFICAR_CEESSOLI_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdMODIFICAR_CEESSOLI.Click

        Try
            Dim frm_modificar As New frm_insertar_CEESSOLI(Me.dgvCEESSOLI_1.SelectedRows.Item(0).Cells("CESOIDRE").Value.ToString(), _
                                                           Me.dgvCERTESSO.SelectedRows.Item(0).Cells("CEESSECU").Value.ToString(), _
                                                           Me.dgvCERTESSO.SelectedRows.Item(0).Cells("CEESNURA").Value.ToString(), _
                                                           Me.dgvCERTESSO.SelectedRows.Item(0).Cells("CEESFERA").Value.ToString())
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
    Private Sub cmdELIMINAR_CEESSOLI_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdELIMINAR_CEESSOLI.Click

        Try
            If MessageBox.Show("¿ Desea eliminar el registro seleccionado ? ", "Mensaje...", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then
                Dim objdatos As New cla_CEESSOLI

                'If objdatos.fun_Eliminar_IDRE_CEESSOLI(Integer.Parse(Me.dgvCEESSOLI_1.SelectedRows.Item(0).Cells("OUSOIDRE").Value.ToString())) Then

                '    boCONSULTA = False

                '    pro_LimpiarCamposSolicitante()
                '    pro_ReconsultarSolicitante()
                '    pro_ListaDeValoresSolicitante()
                'Else
                '    frm_INCO_eliminar_registro_padre_con_relación_de_registros_hijos.ShowDialog()
                'End If

            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub cmdCONSULTAR_CEESSOLI_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCONSULTAR_CEESSOLI.Click

        vp_inConsulta = 0

        'Dim frm_consultar As New frm_consultar_CERTESSO(Integer.Parse(Me.dgvCERTESSO.SelectedRows.Item(0).Cells("CEESIDRE").Value.ToString()))
        'frm_consultar.ShowDialog()

        If vp_inConsulta > 0 Then
            boCONSULTA = True
        Else
            boCONSULTA = False
        End If

        pro_ReconsultarCertificacionDeEstratoSocioeconomico()
        pro_ListaDeValoresCertificacionDeEstratoSocioeconomico()

        Me.TabMAESTRO_2.SelectTab(TabSolicitante)

    End Sub
    Private Sub cmdRECONSULTAR_CEESSOLI_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdRECONSULTAR_CEESSOLI.Click

        boCONSULTA = False
        pro_ReconsultarSolicitante()
        pro_ListaDeValoresSolicitante()

    End Sub

#End Region

#Region "MENU PREDIO"

    Private Sub cmdAGREGAR_CEESPRED_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAGREGAR_CEESPRED.Click

        Try
            If Me.dgvCERTESSO.RowCount > 0 Then
                Dim frm_insertar As New frm_insertar_CEESPRED(Me.dgvCERTESSO.SelectedRows.Item(0).Cells("CEESSECU").Value.ToString(), _
                                                              Me.dgvCERTESSO.SelectedRows.Item(0).Cells("CEESNURA").Value.ToString(), _
                                                              Me.dgvCERTESSO.SelectedRows.Item(0).Cells("CEESFERA").Value.ToString())
                frm_insertar.ShowDialog()
            End If

            boCONSULTA = False

            pro_ReconsultarPredio()
            pro_ListaDeValoresPredio()


        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub cmdMODIFICAR_CEESPRED_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdMODIFICAR_CEESPRED.Click

        Try
            Dim frm_modificar As New frm_insertar_CEESPRED(Me.dgvCEESPRED_1.SelectedRows.Item(0).Cells("CEPRIDRE").Value.ToString(), _
                                                           Me.dgvCERTESSO.SelectedRows.Item(0).Cells("CEESSECU").Value.ToString(), _
                                                           Me.dgvCERTESSO.SelectedRows.Item(0).Cells("CEESNURA").Value.ToString(), _
                                                           Me.dgvCERTESSO.SelectedRows.Item(0).Cells("CEESFERA").Value.ToString())
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
    Private Sub cmdELIMINAR_CEESPRED_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdELIMINAR_CEESPRED.Click

        Try
            If MessageBox.Show("¿ Desea eliminar el registro seleccionado ? ", "Mensaje...", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then
                Dim objdatos As New cla_CEESPRED

                'If objdatos.fun_Eliminar_IDRE_CEESPRED(Integer.Parse(Me.dgvCEESPRED_1.SelectedRows.Item(0).Cells("OUPRIDRE").Value.ToString())) Then

                '    boCONSULTA = False

                '    pro_LimpiarCamposPredio()
                '    pro_ReconsultarPredio()
                '    pro_ListaDeValoresPredio()
                'Else
                '    frm_INCO_eliminar_registro_padre_con_relación_de_registros_hijos.ShowDialog()
                'End If

            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub cmdCONSULTAR_CEESPRED_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCONSULTAR_CEESPRED.Click

        vp_inConsulta = 0

        'Dim frm_consultar As New frm_consultar_CERTESSO(Integer.Parse(Me.dgvCERTESSO.SelectedRows.Item(0).Cells("CEESIDRE").Value.ToString()))
        'frm_consultar.ShowDialog()

        If vp_inConsulta > 0 Then
            boCONSULTA = True
        Else
            boCONSULTA = False
        End If

        pro_ReconsultarCertificacionDeEstratoSocioeconomico()
        pro_ListaDeValoresCertificacionDeEstratoSocioeconomico()

        Me.TabMAESTRO_2.SelectTab(TabPredios)

    End Sub
    Private Sub cmdRECONSULTAR_CEESPRED_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdRECONSULTAR_CEESPRED.Click

        boCONSULTA = False
        pro_ReconsultarPredio()
        pro_ListaDeValoresPredio()

    End Sub

#End Region

#Region "FORMULARIO"

#Region "Load"

    Private Sub frm_RESOLICE_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Me.Load
        pro_ReconsultarCertificacionDeEstratoSocioeconomico()
        pro_ListadoArchivosDocumentos()
        Me.strBARRESTA.Items(0).Text = "Obligación urbanistica"
    End Sub

#End Region

#Region "GotFocus"

    Private Sub frm_RESOLICE_GotFocus1(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.GotFocus
        pro_ListaDeValoresCertificacionDeEstratoSocioeconomico()
    End Sub

#End Region

#Region "KeyDown"

    Private Sub dgvREGIMUTA_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgvCERTESSO.KeyDown
        '===============================================================================================
        '*** INSERTAR REGISTROS ***
        '===============================================================================================


        If e.KeyCode = Keys.F2 Then
            If Me.cmdAGREGAR_CERTESSO.Enabled = True Then
                Me.cmdAGREGAR_CERTESSO.PerformClick()
            Else
                mod_MENSAJE.Usuario_No_Tiene_Permiso_Para_Realizar_La_Operacion()
            End If
        End If

        '===============================================================================================
        'MODIFICAR REGISTROS
        '===============================================================================================

        If e.KeyCode = Keys.F3 Then
            If Me.cmdMODIFICAR_CERTESSO.Enabled = True Then
                Me.cmdMODIFICAR_CERTESSO.PerformClick()
            Else
                Dim ContarRegistros As Integer = Me.BindingSource_CEESSOLI_1.Count

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
            If Me.cmdELIMINAR_CERTESSO.Enabled = True Then
                Me.cmdELIMINAR_CERTESSO.PerformClick()
            Else
                Dim ContarRegistros As Integer = Me.BindingSource_CEESSOLI_1.Count

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
            If Me.cmdCONSULTAR_CERTESSO.Enabled = True Then
                Me.cmdCONSULTAR_CERTESSO.PerformClick()
            Else
                mod_MENSAJE.No_Existen_Registros_En_Base_De_Datos()
            End If
        End If

        '===============================================================================================
        '*** RECONSULTAR REGISTROS ***
        '===============================================================================================

        If e.KeyCode = Keys.F8 Then
            If Me.cmdCONSULTAR_CERTESSO.Enabled = True Then
                Me.cmdRECONSULTAR_CERTESSO.PerformClick()
            Else
                mod_MENSAJE.No_Existen_Registros_En_Base_De_Datos()
            End If
        End If

    End Sub

#End Region

#Region "KeyUp"

    Private Sub dgvREGIMUTA_1_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgvCERTESSO.KeyUp
        If e.KeyCode = Keys.Down Or e.KeyCode = Keys.Up Or e.KeyCode = Keys.Enter Or e.KeyCode = Keys.PageUp Or e.KeyCode = Keys.PageDown Then
            pro_ListaDeValoresCertificacionDeEstratoSocioeconomico()
        End If
    End Sub

#End Region

#Region "CellClick"

    Private Sub dgvREGIMUTA_1_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvCERTESSO.CellClick, dgvCERTESSO.CellClick
        pro_ListaDeValoresCertificacionDeEstratoSocioeconomico()
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