Imports REGLAS_DEL_NEGOCIO
Imports System
Imports System.IO
Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration
Imports System.Text

Public Class frm_RESOLICE

    '================================
    '*** RESOLUCIONES Y LICENCIAS ***
    '================================

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

    Public Shared Function instance() As frm_RESOLICE
        If frm_Instance Is Nothing OrElse frm_Instance.isdisposed = True Then
            frm_Instance = New frm_RESOLICE
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

            tblRutas = objRutas.fun_Buscar_CODIGO_MANT_RUTAS(18)

            If tblRutas.Rows.Count > 0 Then

                ' directorio pricipal
                stRuta = Trim(tblRutas.Rows(0).Item("RUTARUTA")) & "\"

                ' directorio expediente 
                stCarpetaABuscar = Trim(Me.dgvRESOLICE.SelectedRows.Item(0).Cells("RELICLEN").Value.ToString) & "-" & _
                                   Trim(Me.dgvRESOLICE.SelectedRows.Item(0).Cells("RELINURA").Value.ToString) & "-" & _
                                   Trim(Me.dgvRESOLICE.SelectedRows.Item(0).Cells("RELIVIGE").Value.ToString)

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
    Private Function fun_ControlDePermisos() As Boolean

        Try
            Dim boRespuesta As Boolean = False

            Dim dtRELIPERM As New DataTable

            dtRELIPERM = BindingSource_RELIPERM_1.DataSource

            If dtRELIPERM.Rows.Count > 0 Then

                Dim i As Integer = 0

                For i = 0 To dtRELIPERM.Rows.Count - 1

                    If Trim(dtRELIPERM.Rows(i).Item("RLPEUSUA").ToString) = Trim(vp_usuario) Then

                        boRespuesta = True

                    End If

                Next

            End If

            Return boRespuesta

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Function

#End Region

#Region "PROCEDIMIENTOS RESOLUCIONES Y LICENCIAS"

    Private Sub pro_ReconsultarResolucionesyLicencias()

        Try
            Dim objdatos As New cla_RESOLICE

            If boCONSULTA = False Then
                Me.BindingSource_RESOLICE_1.DataSource = objdatos.fun_Consultar_RESOLICE
            Else
                Me.BindingSource_RESOLICE_1.DataSource = objdatos.fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_RESOLICE(vp_inConsulta)
            End If

            Me.dgvRESOLICE.DataSource = BindingSource_RESOLICE_1
            Me.BindingNavigator_RESOLICE_1.BindingSource = BindingSource_RESOLICE_1

            '=================================================
            '*** CONFIGURA OBJETOS DEL FORMULARIO MAESTRO ***
            '=================================================

            Me.strBARRESTA.Items(2).Text = "Registros : " & Me.BindingSource_RESOLICE_1.Count

            Me.dgvRESOLICE.Columns("CLENDESC").HeaderText = "Clase de Entidad"
            Me.dgvRESOLICE.Columns("RELINURA").HeaderText = "Nro. Resolución"
            Me.dgvRESOLICE.Columns("RELIFERA").HeaderText = "Fecha de Resolución"
            Me.dgvRESOLICE.Columns("RELIVIGE").HeaderText = "Año de Elaboración"
            Me.dgvRESOLICE.Columns("RELIFEAS").HeaderText = "Fecha de Asignación"
            Me.dgvRESOLICE.Columns("RELIFEIN").HeaderText = "Fecha de Ingreso"
            Me.dgvRESOLICE.Columns("RELIMAIN").HeaderText = "Matricula Inmobiliaria"
            Me.dgvRESOLICE.Columns("ESTADESC").HeaderText = "Estado"

            Me.dgvRESOLICE.Columns("RELIIDRE").Visible = False
            Me.dgvRESOLICE.Columns("RELISECU").Visible = False
            Me.dgvRESOLICE.Columns("RELICLEN").Visible = False
            Me.dgvRESOLICE.Columns("RELIOBSE").Visible = False

            Me.dgvRESOLICE.Columns("CLENDESC").Width = 200

            '==================================================
            '*** ASIGNA LOS PRIVILEGIOS DE LA BARRA DE MENU ***
            '==================================================

            Dim ContarRegistros As Integer = Me.BindingSource_RESOLICE_1.Count

            Dim boCONTAGRE As Boolean = False
            Dim boCONTMODI As Boolean = False
            Dim boCONTELIM As Boolean = False
            Dim boCONTCONS As Boolean = False
            Dim boCONTRECO As Boolean = False

            pro_Permiso_Barra_De_Menu_Formulario_SubFormulario(ContarRegistros, Trim(Me.BindingNavigator_RESOLICE_1.Name), boCONTAGRE, boCONTMODI, boCONTELIM, boCONTCONS, boCONTRECO)

            Me.cmdAGREGAR_RESOLICE.Enabled = boCONTAGRE
            Me.cmdMODIFICAR_RESOLICE.Enabled = boCONTMODI
            Me.cmdELIMINAR_RESOLICE.Enabled = boCONTELIM
            Me.cmdCONSULTAR_RESOLICE.Enabled = True
            Me.cmdRECONSULTAR_RESOLICE.Enabled = boCONTRECO

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub pro_ListaDeValoresResolucionesyLicencias()

        Try
            If Me.dgvRESOLICE.RowCount > 0 Then

                Dim objdatos As New cla_RESOLICE
                Dim tbldatos As New DataTable

                tbldatos = objdatos.fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_RESOLICE(CInt(Me.dgvRESOLICE.SelectedRows.Item(0).Cells("RELIIDRE").Value.ToString()))

                If tbldatos.Rows.Count > 0 Then
                    Me.txtLIRAOBSE.Text = Trim(tbldatos.Rows(0).Item("RELIOBSE").ToString)
                End If

                pro_ReconsultarSolicitante()
                pro_ListaDeValoresSolicitante()

                pro_ReconsultarPredio()
                pro_ListaDeValoresPredio()

                pro_ReconsultarPropietario()
                pro_ListaDeValoresPropietario()

                pro_ReconsultarMaterialDeFaltante()
                pro_ListaDeValoresMaterialDeFaltante()

                pro_ReconsultarMaterialEntregado()
                pro_ListaDeValoresMaterialEntregado()

                pro_ReconsultarPermisos()
                pro_ListaDeValoresPermisos()

                pro_ControldeBindingNavigator()
                pro_LimpiarDocumentos()

                pro_PermisoControlDeComandos()

                pro_ListadoArchivosDocumentosTIF()
                pro_ListadoArchivosDocumentosPDF()

            Else
                pro_LimpiarCamposResolucionesyLicencias()
                pro_LimpiarCamposSolicitante()
                pro_LimpiarCamposPredio()
                pro_LimpiarCamposPropietario()
                pro_LimpiarMaterialEntregado()
                pro_LimpiarMaterialFaltante()
                pro_LimpiarCamposPermisos()

                Me.BindingNavigator_RELISOLI_1.Enabled = False
                Me.BindingNavigator_RELIPRED_1.Enabled = False
                Me.BindingNavigator_RELIPROP_1.Enabled = False
                Me.BindingNavigator_RELIMAEN_1.Enabled = False
                Me.BindingNavigator_RELIMAFA_1.Enabled = False
                Me.BindingNavigator_RELIPERM_1.Enabled = False

            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub pro_ControldeBindingNavigator()

        If Me.dgvRESOLICE.RowCount > 0 Then

            Me.BindingNavigator_RELISOLI_1.Enabled = True
            Me.BindingNavigator_RELIPRED_1.Enabled = True
            Me.BindingNavigator_RELIPROP_1.Enabled = True
            Me.BindingNavigator_RELIMAEN_1.Enabled = True
            Me.BindingNavigator_RELIMAFA_1.Enabled = True
            Me.BindingNavigator_RELIPERM_1.Enabled = True
        Else
            Me.BindingNavigator_RELISOLI_1.Enabled = False
            Me.BindingNavigator_RELIPRED_1.Enabled = False
            Me.BindingNavigator_RELIPROP_1.Enabled = False
            Me.BindingNavigator_RELIMAEN_1.Enabled = False
            Me.BindingNavigator_RELIMAFA_1.Enabled = False
            Me.BindingNavigator_RELIPERM_1.Enabled = False

        End If

    End Sub
    Private Sub pro_LimpiarCamposResolucionesyLicencias()

        Me.strBARRESTA.Items(2).Text = "Registros : 0"

    End Sub
    Private Sub pro_LimpiarDocumentos()

        Me.lstLISTADO_DOCUMENTOS_TIF.Items.Clear()
        Me.lstLISTADO_DOCUMENTOS_PDF.Items.Clear()

        Me.pibImagenDocumentos.Image = Nothing

    End Sub

    Private Sub pro_EjecutarBotonObservaciones()

        Try
            If Me.dgvRESOLICE.RowCount > 0 Then

                If MessageBox.Show("¿ Desea ingresar una observación ? ", "Mensaje...", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then

                    Dim stObservacionNueva As String = InputBox("Ingrese la observación.", "Mensaje")

                    If Trim(stObservacionNueva) = "" Then
                        MessageBox.Show("Se requiere una observación.", "Mensaje...", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                        mod_MENSAJE.No_Se_Modifico_El_Registro_En_La_Base_De_Datos()
                    Else

                        Dim stREMUOBSE_ACTUAL As String = ""
                        Dim stREMUOBSE_NUEVA As String = Trim(stObservacionNueva.ToString.ToUpper)

                        Dim obMOGEGEOG As New cla_RESOLICE
                        Dim dtAJUSGEOG As New DataTable

                        dtAJUSGEOG = obMOGEGEOG.fun_Buscar_ID_RESOLICE(Me.dgvRESOLICE.SelectedRows.Item(0).Cells("RELIIDRE").Value.ToString())

                        If dtAJUSGEOG.Rows.Count > 0 Then
                            stREMUOBSE_ACTUAL = Trim(dtAJUSGEOG.Rows(0).Item("RELIOBSE").ToString)
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
                        Dim inMOGEIDRE As Integer = Integer.Parse(Me.dgvRESOLICE.SelectedRows.Item(0).Cells("RELIIDRE").Value.ToString())

                        ' parametros de la consulta
                        Dim ParametrosConsulta As String = ""

                        ' Concatena la condicion de la consulta
                        ParametrosConsulta += "update RESOLICE "
                        ParametrosConsulta += "set RELIOBSE = '" & stREMUOBSE_ACTUAL & "' "
                        ParametrosConsulta += "where RELIIDRE = '" & inMOGEIDRE & "' "

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

                        pro_ReconsultarResolucionesyLicencias()
                        pro_ListaDeValoresResolucionesyLicencias()

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

    Private Sub pro_ListadoArchivosDocumentosTIF()

        Try
            Me.lstLISTADO_DOCUMENTOS_TIF.Items.Clear()

            ' declara la variable
            Dim stRuta As String = ""
            Dim stNewPath As String = ""
            Dim ContentItem As String

            ' instancia la clase
            Dim objRutas As New cla_RUTAS
            Dim tblRutas As New DataTable

            tblRutas = objRutas.fun_Buscar_CODIGO_MANT_RUTAS(18)

            If tblRutas.Rows.Count > 0 AndAlso fun_VerificarCarpetaExistenteDocumentos() = True Then

                stNewPath = Trim(tblRutas.Rows(0).Item("RUTARUTA")) & "\" & Trim(Me.dgvRESOLICE.SelectedRows.Item(0).Cells("RELICLEN").Value.ToString) & "-" & _
                                                                            Trim(Me.dgvRESOLICE.SelectedRows.Item(0).Cells("RELINURA").Value.ToString) & "-" & _
                                                                            Trim(Me.dgvRESOLICE.SelectedRows.Item(0).Cells("RELIVIGE").Value.ToString)

                vl_stRutaDocumentosTIF = stNewPath


                ChDir(stNewPath)
                Me.lstLISTADO_DOCUMENTOS_TIF.Items.Clear()

                ContentItem = Dir("*.tif")

                If ContentItem <> "" Then
                    Me.lstLISTADO_DOCUMENTOS_TIF.Focus()
                End If

                Do Until ContentItem = ""
                    ' agrega a la lista
                    Me.lstLISTADO_DOCUMENTOS_TIF.Items.Add(ContentItem)

                    'desplaza el registro
                    ContentItem = Dir()
                Loop

            Else
                Me.lstLISTADO_DOCUMENTOS_TIF.Items.Clear()
            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub pro_ListadoArchivosDocumentosPDF()

        Try
            Me.lstLISTADO_DOCUMENTOS_PDF.Items.Clear()

            ' declara la variable
            Dim stRuta As String = ""
            Dim stNewPath As String = ""
            Dim ContentItem As String

            ' instancia la clase
            Dim objRutas As New cla_RUTAS
            Dim tblRutas As New DataTable

            tblRutas = objRutas.fun_Buscar_CODIGO_MANT_RUTAS(18)

            If tblRutas.Rows.Count > 0 AndAlso fun_VerificarCarpetaExistenteDocumentos() = True Then

                stNewPath = Trim(tblRutas.Rows(0).Item("RUTARUTA")) & "\" & Trim(Me.dgvRESOLICE.SelectedRows.Item(0).Cells("RELICLEN").Value.ToString) & "-" & _
                                                                            Trim(Me.dgvRESOLICE.SelectedRows.Item(0).Cells("RELINURA").Value.ToString) & "-" & _
                                                                            Trim(Me.dgvRESOLICE.SelectedRows.Item(0).Cells("RELIVIGE").Value.ToString)

                vl_stRutaDocumentosPDF = stNewPath


                ChDir(stNewPath)
                Me.lstLISTADO_DOCUMENTOS_PDF.Items.Clear()

                ContentItem = Dir("*.pdf")

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

    Private Sub pro_PermisoControlDeComandos()

        Try
            vl_boControlDeComandos = fun_PermisoControlDeComandos(vp_usuario, Me.Name, Me.axaVisorDocumentoPDF.Name)
            Me.axaVisorDocumentoPDF.setShowToolbar(vl_boControlDeComandos)

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub

#End Region

#Region "PROCEDIMIENTO SOLICITANTE"

    Private Sub pro_ReconsultarSolicitante()

        Try
            Dim objdatos As New cla_RELISOLI

            If boCONSULTA = False Then
                Me.BindingSource_RELISOLI_1.DataSource = objdatos.fun_Buscar_SECU_X_CONSULTA_PARAMETRIZADA_RELISOLI(Me.dgvRESOLICE.SelectedRows.Item(0).Cells("RELISECU").Value.ToString())
            Else
                Me.BindingSource_RELISOLI_1.DataSource = objdatos.fun_Buscar_SECU_X_CONSULTA_PARAMETRIZADA_RELISOLI(Me.dgvRESOLICE.SelectedRows.Item(0).Cells("RELISECU").Value.ToString())
            End If

            Me.dgvRELISOLI_1.DataSource = BindingSource_RELISOLI_1
            Me.dgvRELISOLI_2.DataSource = BindingSource_RELISOLI_1
            Me.BindingNavigator_RELISOLI_1.BindingSource = BindingSource_RELISOLI_1

            '=================================================
            '*** CONFIGURA OBJETOS DEL FORMULARIO MAESTRO ***
            '=================================================

            Me.strBARRESTA.Items(2).Text = "Registros : " & Me.BindingSource_RESOLICE_1.Count

            Me.dgvRELISOLI_1.Columns("SOLIDESC").HeaderText = "Solicitante"
            Me.dgvRELISOLI_1.Columns("RLSONUDO").HeaderText = "Nro. Documento"
            Me.dgvRELISOLI_1.Columns("RLSONOMB").HeaderText = "Nombre(s)"
            Me.dgvRELISOLI_1.Columns("RLSOPRAP").HeaderText = "Primer apellido"
            Me.dgvRELISOLI_1.Columns("RLSOSEAP").HeaderText = "Segundo apellido"
            Me.dgvRELISOLI_1.Columns("RLSODIPR").HeaderText = "Dirección del predio"

            Me.dgvRELISOLI_1.Columns("RLSOIDRE").Visible = False
            Me.dgvRELISOLI_1.Columns("RLSODINO").Visible = False
            Me.dgvRELISOLI_1.Columns("RLSOTELE").Visible = False
            Me.dgvRELISOLI_1.Columns("RLSOCELU").Visible = False
            Me.dgvRELISOLI_1.Columns("RLSOCOEL").Visible = False
            Me.dgvRELISOLI_1.Columns("RLSOCOPO").Visible = False
            Me.dgvRELISOLI_1.Columns("RLSORESO").Visible = False
            Me.dgvRELISOLI_1.Columns("RLSONURA").Visible = False
            Me.dgvRELISOLI_1.Columns("RLSOFERA").Visible = False
            Me.dgvRELISOLI_1.Columns("RLSOSECU").Visible = False

            Me.dgvRELISOLI_2.Columns("RLSODINO").HeaderText = "Dirección de notificación"
            Me.dgvRELISOLI_2.Columns("RLSOTELE").HeaderText = "Telefono"
            Me.dgvRELISOLI_2.Columns("RLSOCELU").HeaderText = "Celular"
            Me.dgvRELISOLI_2.Columns("RLSOCOEL").HeaderText = "Correo electronico"
            Me.dgvRELISOLI_2.Columns("RLSOCOPO").HeaderText = "Código postal"
            Me.dgvRELISOLI_2.Columns("RLSORESO").HeaderText = "Redes sociales"

            Me.dgvRELISOLI_2.Columns("RLSOIDRE").Visible = False
            Me.dgvRELISOLI_2.Columns("RLSONUDO").Visible = False
            Me.dgvRELISOLI_2.Columns("RLSONOMB").Visible = False
            Me.dgvRELISOLI_2.Columns("RLSOPRAP").Visible = False
            Me.dgvRELISOLI_2.Columns("RLSOSEAP").Visible = False
            Me.dgvRELISOLI_2.Columns("RLSODIPR").Visible = False
            Me.dgvRELISOLI_2.Columns("RLSONURA").Visible = False
            Me.dgvRELISOLI_2.Columns("RLSOFERA").Visible = False
            Me.dgvRELISOLI_2.Columns("RLSOSECU").Visible = False
            Me.dgvRELISOLI_2.Columns("SOLIDESC").Visible = False

            Me.dgvRELISOLI_1.Columns("RLSODIPR").Width = 300
            Me.dgvRELISOLI_2.Columns("RLSODINO").Width = 300

            '==================================================
            '*** ASIGNA LOS PRIVILEGIOS DE LA BARRA DE MENU ***
            '==================================================

            Dim ContarRegistros As Integer = Me.BindingSource_RELISOLI_1.Count

            Dim boCONTAGRE As Boolean = False
            Dim boCONTMODI As Boolean = False
            Dim boCONTELIM As Boolean = False
            Dim boCONTCONS As Boolean = False
            Dim boCONTRECO As Boolean = False

            pro_Permiso_Barra_De_Menu_Formulario_SubFormulario(ContarRegistros, Trim(Me.BindingNavigator_RELISOLI_1.Name), boCONTAGRE, boCONTMODI, boCONTELIM, boCONTCONS, boCONTRECO)

            Me.cmdAGREGAR_RELISOLI.Enabled = boCONTAGRE
            Me.cmdMODIFICAR_RELISOLI.Enabled = boCONTMODI
            Me.cmdELIMINAR_RELISOLI.Enabled = boCONTELIM
            Me.cmdCONSULTAR_RELISOLI.Enabled = boCONTCONS
            Me.cmdRECONSULTAR_RELISOLI.Enabled = boCONTRECO

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub pro_ListaDeValoresSolicitante()

    End Sub
    Private Sub pro_LimpiarCamposSolicitante()

        Me.dgvRELISOLI_1.DataSource = New DataTable
        Me.dgvRELISOLI_2.DataSource = New DataTable

    End Sub

#End Region

#Region "PROCEDIMIENTO PREDIO"

    Private Sub pro_ReconsultarPredio()

        Try
            Dim objdatos As New cla_RELIPRED

            If boCONSULTA = False Then
                Me.BindingSource_RELIPRED_1.DataSource = objdatos.fun_Buscar_SECU_X_CONSULTA_PARAMETRIZADA_RELIPRED(Me.dgvRESOLICE.SelectedRows.Item(0).Cells("RELISECU").Value.ToString())
            Else
                Me.BindingSource_RELIPRED_1.DataSource = objdatos.fun_Buscar_SECU_X_CONSULTA_PARAMETRIZADA_RELIPRED(Me.dgvRESOLICE.SelectedRows.Item(0).Cells("RELISECU").Value.ToString())
            End If

            Me.dgvRELIPRED.DataSource = BindingSource_RELIPRED_1
            Me.BindingNavigator_RELIPRED_1.BindingSource = BindingSource_RELIPRED_1

            '=================================================
            '*** CONFIGURA OBJETOS DEL FORMULARIO MAESTRO ***
            '=================================================

            Me.strBARRESTA.Items(2).Text = "Registros : " & Me.BindingSource_RESOLICE_1.Count

            Me.dgvRELIPRED.Columns("RLPRMUNI").HeaderText = "Municipio"
            Me.dgvRELIPRED.Columns("RLPRCORR").HeaderText = "Corregimiento"
            Me.dgvRELIPRED.Columns("RLPRBARR").HeaderText = "Barrio"
            Me.dgvRELIPRED.Columns("RLPRMANZ").HeaderText = "Manzana Vereda"
            Me.dgvRELIPRED.Columns("RLPRPRED").HeaderText = "Predio"
            Me.dgvRELIPRED.Columns("RLPREDIF").HeaderText = "Edificio"
            Me.dgvRELIPRED.Columns("RLPRUNPR").HeaderText = "Unidad Predial"
            Me.dgvRELIPRED.Columns("CLSEDESC").HeaderText = "Sector"
            Me.dgvRELIPRED.Columns("RLPRMAIN").HeaderText = "Matricula Inmobiliria"
            Me.dgvRELIPRED.Columns("RLPRNUFI").HeaderText = "Nro. Ficha Predial"

            Me.dgvRELIPRED.Columns("RLPRIDRE").Visible = False
            Me.dgvRELIPRED.Columns("RLPRNURA").Visible = False
            Me.dgvRELIPRED.Columns("RLPRFERA").Visible = False
            Me.dgvRELIPRED.Columns("RLPRSECU").Visible = False

            '==================================================
            '*** ASIGNA LOS PRIVILEGIOS DE LA BARRA DE MENU ***
            '==================================================

            Dim ContarRegistros As Integer = Me.BindingSource_RELIPRED_1.Count

            Dim boCONTAGRE As Boolean = False
            Dim boCONTMODI As Boolean = False
            Dim boCONTELIM As Boolean = False
            Dim boCONTCONS As Boolean = False
            Dim boCONTRECO As Boolean = False

            pro_Permiso_Barra_De_Menu_Formulario_SubFormulario(ContarRegistros, Trim(Me.BindingNavigator_RELIPRED_1.Name), boCONTAGRE, boCONTMODI, boCONTELIM, boCONTCONS, boCONTRECO)

            Me.cmdAGREGAR_RELIPRED.Enabled = boCONTAGRE
            Me.cmdMODIFICAR_RELIPRED.Enabled = boCONTMODI
            Me.cmdELIMINAR_RELIPRED.Enabled = boCONTELIM
            Me.cmdCONSULTAR_RELIPRED.Enabled = boCONTCONS
            Me.cmdRECONSULTAR_RELIPRED.Enabled = boCONTRECO

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub pro_ListaDeValoresPredio()

    End Sub
    Private Sub pro_LimpiarCamposPredio()

        Me.dgvRELIPRED.DataSource = New DataTable

    End Sub

#End Region

#Region "PROCEDIMIENTO PROPIETARIO"

    Private Sub pro_ReconsultarPropietario()

        Try
            Dim objdatos As New cla_RELIPROP

            If boCONSULTA = False Then
                Me.BindingSource_RELIPROP_1.DataSource = objdatos.fun_Buscar_SECU_X_CONSULTA_PARAMETRIZADA_RELIPROP(Me.dgvRESOLICE.SelectedRows.Item(0).Cells("RELISECU").Value.ToString())
            Else
                Me.BindingSource_RELIPROP_1.DataSource = objdatos.fun_Buscar_SECU_X_CONSULTA_PARAMETRIZADA_RELIPROP(Me.dgvRESOLICE.SelectedRows.Item(0).Cells("RELISECU").Value.ToString())
            End If

            Me.dgvRELIPROP.DataSource = BindingSource_RELIPROP_1
            Me.BindingNavigator_RELIPROP_1.BindingSource = BindingSource_RELIPROP_1

            '=================================================
            '*** CONFIGURA OBJETOS DEL FORMULARIO MAESTRO ***
            '=================================================

            Me.strBARRESTA.Items(2).Text = "Registros : " & Me.BindingSource_RELIPROP_1.Count

            Me.dgvRELIPROP.Columns("RLPRNUDO").HeaderText = "Nro. Documento"
            Me.dgvRELIPROP.Columns("RLPRNOMB").HeaderText = "Nombre(s)"
            Me.dgvRELIPROP.Columns("RLPRPRAP").HeaderText = "Primer apellido"
            Me.dgvRELIPROP.Columns("RLPRSEAP").HeaderText = "Segundo apellido"
            Me.dgvRELIPROP.Columns("RLPRDERE").HeaderText = "Derecho"

            Me.dgvRELIPROP.Columns("RLPRIDRE").Visible = False
            Me.dgvRELIPROP.Columns("RLPRNURA").Visible = False
            Me.dgvRELIPROP.Columns("RLPRFERA").Visible = False
            Me.dgvRELIPROP.Columns("RLPRSECU").Visible = False

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub pro_ListaDeValoresPropietario()

    End Sub
    Private Sub pro_LimpiarCamposPropietario()

        Me.dgvRELIPROP.DataSource = New DataTable

    End Sub

#End Region

#Region "PROCEDIMIENTOS METERIAL ENTREGADO"

    Private Sub pro_ReconsultarMaterialEntregado()

        Try
            Dim objdatos As New cla_RELIMAEN

            If boCONSULTA = False Then
                Me.BindingSource_RELIMAEN_1.DataSource = objdatos.fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_RELIMAEN(Me.dgvRESOLICE.SelectedRows.Item(0).Cells("RELISECU").Value.ToString)
            Else
                Me.BindingSource_RELIMAEN_1.DataSource = objdatos.fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_RELIMAEN(Me.dgvRESOLICE.SelectedRows.Item(0).Cells("RELISECU").Value.ToString)
            End If

            Me.dgvRELIMAEN.DataSource = Me.BindingSource_RELIMAEN_1
            Me.BindingNavigator_RELIMAEN_1.BindingSource = Me.BindingSource_RELIMAEN_1

            '==================================================
            '*** CONFIGURA OBJETOS DEL FORMULARIO MAESTRO ***
            '==================================================

            Me.dgvRELIMAEN.Columns("RLMEIDRE").HeaderText = "idre"
            Me.dgvRELIMAEN.Columns("RLMESECU").HeaderText = "Secuencia"

            Me.dgvRELIMAEN.Columns("RLMEMACA").HeaderText = "Código"
            Me.dgvRELIMAEN.Columns("MACADESC").HeaderText = "Descripción"
            Me.dgvRELIMAEN.Columns("RLMEFECH").HeaderText = "Fecha"
            Me.dgvRELIMAEN.Columns("RLMEOBSE").HeaderText = "Observación"

            Me.dgvRELIMAEN.Columns("RLMEIDRE").Visible = False
            Me.dgvRELIMAEN.Columns("RLMESECU").Visible = False
            Me.dgvRELIMAEN.Columns("RLMEOBSE").Visible = False

            Me.dgvRELIMAEN.Columns("RLMEMACA").Width = 30
            Me.dgvRELIMAEN.Columns("MACADESC").Width = 100
            Me.dgvRELIMAEN.Columns("RLMEFECH").Width = 100

            '==================================================
            '*** ASIGNA LOS PRIVILEGIOS DE LA BARRA DE MENU ***
            '==================================================

            Dim ContarRegistros As Integer = Me.BindingSource_RELIMAEN_1.Count

            Dim boCONTAGRE As Boolean = False
            Dim boCONTMODI As Boolean = False
            Dim boCONTELIM As Boolean = False
            Dim boCONTCONS As Boolean = False
            Dim boCONTRECO As Boolean = False

            pro_Permiso_Barra_De_Menu_Formulario_SubFormulario(ContarRegistros, Trim(Me.BindingNavigator_RELIMAEN_1.Name), boCONTAGRE, boCONTMODI, boCONTELIM, boCONTCONS, boCONTRECO)

            Me.cmdAGREGAR_RELIMAEN.Enabled = boCONTAGRE
            Me.cmdMODIFICAR_RELIMAEN.Enabled = boCONTMODI
            Me.cmdELIMINAR_RELIMAEN.Enabled = boCONTELIM
            Me.cmdCONSULTAR_RELIMAEN.Enabled = boCONTCONS
            Me.cmdRECONSULTAR_RELIMAEN.Enabled = boCONTRECO


        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try
    End Sub
    Private Sub pro_ListaDeValoresMaterialEntregado()

        Try
            If Me.dgvRELIMAEN.RowCount = 0 Then

                pro_LimpiarMaterialEntregado()

            End If

            Dim objdatos As New cla_RELIOBME
            Dim tbl As New DataTable

            tbl = objdatos.fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_RELIOBME(Me.dgvRESOLICE.SelectedRows.Item(0).Cells("RELISECU").Value.ToString)

            If tbl.Rows.Count > 0 Then
                Me.txtRLMEOBSE.Text = Trim(tbl.Rows(0).Item("ROMEOBSE"))
            Else
                Me.txtRLMEOBSE.Text = ""
            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub pro_LimpiarMaterialEntregado()

        Me.txtRLMEOBSE.Text = ""

    End Sub

#End Region

#Region "PROCEDIMIENTOS METERIAL FALTANTE"

    Private Sub pro_ReconsultarMaterialDeFaltante()

        Try
            Dim objdatos As New cla_RELIMAFA

            If boCONSULTA = False Then
                Me.BindingSource_RELIMAFA_1.DataSource = objdatos.fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_RELIMAFA(Me.dgvRESOLICE.SelectedRows.Item(0).Cells("RELISECU").Value.ToString)
            Else
                Me.BindingSource_RELIMAFA_1.DataSource = objdatos.fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_RELIMAFA(Me.dgvRESOLICE.SelectedRows.Item(0).Cells("RELISECU").Value.ToString)
            End If

            Me.dgvRELIMAFA.DataSource = Me.BindingSource_RELIMAFA_1
            Me.BindingNavigator_RELIMAFA_1.BindingSource = Me.BindingSource_RELIMAFA_1

            '==================================================
            '*** CONFIGURA OBJETOS DEL FORMULARIO MAESTRO ***
            '==================================================

            Me.dgvRELIMAFA.Columns("RLMFIDRE").HeaderText = "idre"
            Me.dgvRELIMAFA.Columns("RLMFSECU").HeaderText = "Secuencia"

            Me.dgvRELIMAFA.Columns("RLMFMACA").HeaderText = "Código"
            Me.dgvRELIMAFA.Columns("MACADESC").HeaderText = "Descripción"
            Me.dgvRELIMAFA.Columns("RLMFFECH").HeaderText = "Fecha"
            Me.dgvRELIMAFA.Columns("RLMFOBSE").HeaderText = "Observación"

            Me.dgvRELIMAFA.Columns("RLMFIDRE").Visible = False
            Me.dgvRELIMAFA.Columns("RLMFSECU").Visible = False
            Me.dgvRELIMAFA.Columns("RLMFOBSE").Visible = False

            Me.dgvRELIMAFA.Columns("RLMFMACA").Width = 30
            Me.dgvRELIMAFA.Columns("MACADESC").Width = 100
            Me.dgvRELIMAFA.Columns("RLMFFECH").Width = 100

            '==================================================
            '*** ASIGNA LOS PRIVILEGIOS DE LA BARRA DE MENU ***
            '==================================================

            Dim ContarRegistros As Integer = Me.BindingSource_RELIMAFA_1.Count

            Dim boCONTAGRE As Boolean = False
            Dim boCONTMODI As Boolean = False
            Dim boCONTELIM As Boolean = False
            Dim boCONTCONS As Boolean = False
            Dim boCONTRECO As Boolean = False

            pro_Permiso_Barra_De_Menu_Formulario_SubFormulario(ContarRegistros, Trim(Me.BindingNavigator_RELIMAFA_1.Name), boCONTAGRE, boCONTMODI, boCONTELIM, boCONTCONS, boCONTRECO)

            Me.cmdAGREGAR_RELIMAFA.Enabled = boCONTAGRE
            Me.cmdMODIFICAR_RELIMAFA.Enabled = boCONTMODI
            Me.cmdELIMINAR_RELIMAFA.Enabled = boCONTELIM
            Me.cmdCONSULTAR_RELIMAFA.Enabled = boCONTCONS
            Me.cmdRECONSULTAR_RELIMAFA.Enabled = boCONTRECO

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try
    End Sub
    Private Sub pro_ListaDeValoresMaterialDeFaltante()

        Try
            Dim objdatos As New cla_RELIOBMF
            Dim tbl As New DataTable

            tbl = objdatos.fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_RELIOBMF(Me.dgvRESOLICE.SelectedRows.Item(0).Cells("RELISECU").Value.ToString)

            If tbl.Rows.Count > 0 Then
                Me.txtRLMFOBSE.Text = Trim(tbl.Rows(0).Item("ROMFOBSE"))
            Else
                Me.txtRLMFOBSE.Text = ""
            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub pro_LimpiarMaterialFaltante()

        Me.txtRLMFOBSE.Text = ""

        'Me.dgvRELIMAFA.DataSource = New DataTable

    End Sub

#End Region

#Region "PROCEDIMIENTOS PERMISOS"

    Private Sub pro_ReconsultarPermisos()

        Try
            Dim objdatos As New cla_RELIPERM

            If boCONSULTA = False Then
                Me.BindingSource_RELIPERM_1.DataSource = objdatos.fun_Buscar_SECU_X_CONSULTA_PARAMETRIZADA_RELIPERM(Me.dgvRESOLICE.SelectedRows.Item(0).Cells("RELISECU").Value.ToString())
            Else
                Me.BindingSource_RELIPERM_1.DataSource = objdatos.fun_Buscar_SECU_X_CONSULTA_PARAMETRIZADA_RELIPERM(Me.dgvRESOLICE.SelectedRows.Item(0).Cells("RELISECU").Value.ToString())
            End If

            Me.dgvRELIPERM.DataSource = BindingSource_RELIPERM_1
            Me.BindingNavigator_RELIPERM_1.BindingSource = BindingSource_RELIPERM_1

            '=================================================
            '*** CONFIGURA OBJETOS DEL FORMULARIO MAESTRO ***
            '=================================================

            Me.strBARRESTA.Items(2).Text = "Registros : " & Me.BindingSource_RELIPERM_1.Count

            Me.dgvRELIPERM.Columns("RLPEUSUA").HeaderText = "Usuario"
            Me.dgvRELIPERM.Columns("RLPENUDO").HeaderText = "Nro. Documento"
            Me.dgvRELIPERM.Columns("USUANOMB").HeaderText = "Nombre(s)"
            Me.dgvRELIPERM.Columns("USUAPRAP").HeaderText = "Primer Apellido"
            Me.dgvRELIPERM.Columns("USUASEAP").HeaderText = "Segundo Apellido"
            Me.dgvRELIPERM.Columns("RLPEFEIN").HeaderText = "Fecha de Ingreso"

            Me.dgvRELIPERM.Columns("RLPEIDRE").Visible = False
            Me.dgvRELIPERM.Columns("RLPESECU").Visible = False
            Me.dgvRELIPERM.Columns("RLPEOBSE").Visible = False

            '==================================================
            '*** ASIGNA LOS PRIVILEGIOS DE LA BARRA DE MENU ***
            '==================================================

            Dim ContarRegistros As Integer = Me.BindingSource_RELIPERM_1.Count

            Dim boCONTAGRE As Boolean = False
            Dim boCONTMODI As Boolean = False
            Dim boCONTELIM As Boolean = False
            Dim boCONTCONS As Boolean = False
            Dim boCONTRECO As Boolean = False

            pro_Permiso_Barra_De_Menu_Formulario_SubFormulario(ContarRegistros, Trim(Me.BindingNavigator_RELIPERM_1.Name), boCONTAGRE, boCONTMODI, boCONTELIM, boCONTCONS, boCONTRECO)

            Me.cmdAGREGAR_RELIPERM.Enabled = boCONTAGRE
            Me.cmdMODIFICAR_RELIPERM.Enabled = boCONTMODI
            Me.cmdELIMINAR_RELIPERM.Enabled = boCONTELIM
            Me.cmdCONSULTAR_RELIPERM.Enabled = boCONTCONS
            Me.cmdRECONSULTAR_RELIPERM.Enabled = boCONTRECO

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub pro_ListaDeValoresPermisos()

        If Me.dgvRELIPERM.RowCount > 0 Then

            Dim objdatos As New cla_RELIPERM
            Dim tbl As New DataTable

            tbl = objdatos.fun_Buscar_ID_X_RELIPERM(Me.dgvRELIPERM.SelectedRows.Item(0).Cells("RLPEIDRE").Value.ToString)

            If tbl.Rows.Count > 0 Then
                Me.txtRLPEOBSE.Text = Trim(tbl.Rows(0).Item("RLPEOBSE"))
            Else
                Me.txtRLPEOBSE.Text = ""
            End If
        Else
            pro_LimpiarCamposPermisos()
        End If

    End Sub
    Private Sub pro_LimpiarCamposPermisos()

        'Me.dgvRELIPERM.DataSource = New DataTable
        Me.txtRLPEOBSE.Text = ""

    End Sub

#End Region

#Region "MENU RESOLUCIONES Y LICENCIAS"

    Private Sub cmdAGREGAR_RESOLICE_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAGREGAR_RESOLICE.Click

        Try

            If Me.dgvRESOLICE.RowCount > 0 Then
                Dim frm_insertar As New frm_insertar_RESOLICE(Integer.Parse(Me.dgvRESOLICE.SelectedRows.Item(0).Cells("RELIIDRE").Value.ToString()))
                frm_insertar.ShowDialog()
            Else
                frm_insertar_RESOLICE.ShowDialog()
            End If

            If vp_inConsulta > 0 Then
                boCONSULTA = True
            Else
                boCONSULTA = False
            End If

            pro_ReconsultarResolucionesyLicencias()
            pro_ListaDeValoresResolucionesyLicencias()

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub cmdMODIFICAR_RESOLICE_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdMODIFICAR_RESOLICE.Click

        Try
            Dim frm_modificar As New frm_modificar_RESOLICE(Integer.Parse(Me.dgvRESOLICE.SelectedRows.Item(0).Cells("RELIIDRE").Value.ToString()))
            frm_modificar.ShowDialog()

            If vp_inConsulta <> 0 Then
                boCONSULTA = True
            End If

            pro_ReconsultarResolucionesyLicencias()
            pro_ListaDeValoresResolucionesyLicencias()

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub cmdELIMINAR_RESOLICE_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdELIMINAR_RESOLICE.Click

        Try
            If MessageBox.Show("¿ Desea eliminar el registro seleccionado ? ", "Mensaje...", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then
                Dim objdatos As New cla_RESOLICE

                If objdatos.fun_Eliminar_IDRE_RESOLICE(Integer.Parse(Me.dgvRESOLICE.SelectedRows.Item(0).Cells("RELIIDRE").Value.ToString())) Then

                    boCONSULTA = False

                    pro_LimpiarCamposResolucionesyLicencias()
                    pro_ReconsultarResolucionesyLicencias()
                    pro_ListaDeValoresResolucionesyLicencias()
                Else
                    frm_INCO_eliminar_registro_padre_con_relación_de_registros_hijos.ShowDialog()
                End If

            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub cmdCONSULTAR_RESOLICE_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCONSULTAR_RESOLICE.Click

        Try
            vp_inConsulta = 0

            If Me.dgvRESOLICE.RowCount > 0 Then
                Dim frm_consultar As New frm_consultar_RESOLICE(Integer.Parse(Me.dgvRESOLICE.SelectedRows.Item(0).Cells("RELIIDRE").Value.ToString()))
                frm_consultar.ShowDialog()
            Else
                Dim frm_consultar As New frm_consultar_RESOLICE()
                frm_consultar.ShowDialog()
            End If

            If vp_inConsulta > 0 Then
                boCONSULTA = True
            Else
                boCONSULTA = False
            End If

            pro_ReconsultarResolucionesyLicencias()
            pro_ListaDeValoresResolucionesyLicencias()

            Me.TabMAESTRO_2.SelectTab(TabSolicitante)

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub cmdRECONSULTAR_RESOLICE_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdRECONSULTAR_RESOLICE.Click

        Try
            If Me.dgvRESOLICE.RowCount > 0 Then
                boCONSULTA = True
            Else
                boCONSULTA = False
            End If

            pro_ReconsultarResolucionesyLicencias()
            pro_ListaDeValoresResolucionesyLicencias()

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
            If Me.dgvRESOLICE.RowCount > 0 Then

                Dim frm_inserta_archivo As New frm_insertar_archivo_RESOLICE(Me.dgvRESOLICE.SelectedRows.Item(0).Cells("RELICLEN").Value.ToString(), _
                                                                             Me.dgvRESOLICE.SelectedRows.Item(0).Cells("RELINURA").Value.ToString(), _
                                                                             Me.dgvRESOLICE.SelectedRows.Item(0).Cells("RELIVIGE").Value.ToString())
                frm_inserta_archivo.ShowDialog()

                pro_ListadoArchivosDocumentosPDF()
                pro_ListadoArchivosDocumentosTIF()

                vp_inConsulta = Me.dgvRESOLICE.SelectedRows.Item(0).Cells("RELIIDRE").Value.ToString()

                If vp_inConsulta <> 0 Then
                    boCONSULTA = True
                Else
                    boCONSULTA = False
                End If

                pro_ReconsultarResolucionesyLicencias()
                pro_ListaDeValoresResolucionesyLicencias()

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
            pro_ListaDeValoresResolucionesyLicencias()

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub ToolStripButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton2.Click

        Try
            pro_ListaDeValoresResolucionesyLicencias()

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub ToolStripButton3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton3.Click

        Try
            pro_ListaDeValoresResolucionesyLicencias()

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub ToolStripButton4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton4.Click

        Try
            pro_ListaDeValoresResolucionesyLicencias()

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub

#End Region

#Region "MENU SOLICITANTE"

    Private Sub cmdAGREGAR_RELISOLI_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAGREGAR_RELISOLI.Click

        Try
            If Me.dgvRESOLICE.RowCount > 0 Then
                Dim frm_insertar As New frm_insertar_RELISOLI(Me.dgvRESOLICE.SelectedRows.Item(0).Cells("RELISECU").Value.ToString(), _
                                                              Me.dgvRESOLICE.SelectedRows.Item(0).Cells("RELINURA").Value.ToString(), _
                                                              Me.dgvRESOLICE.SelectedRows.Item(0).Cells("RELIFERA").Value.ToString())
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
    Private Sub cmdMODIFICAR_RELISOLI_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdMODIFICAR_RELISOLI.Click

        Try
            Dim frm_modificar As New frm_insertar_RELISOLI(Me.dgvRELISOLI_1.SelectedRows.Item(0).Cells("RLSOIDRE").Value.ToString(), _
                                                           Me.dgvRESOLICE.SelectedRows.Item(0).Cells("RELISECU").Value.ToString(), _
                                                           Me.dgvRESOLICE.SelectedRows.Item(0).Cells("RELINURA").Value.ToString(), _
                                                           Me.dgvRESOLICE.SelectedRows.Item(0).Cells("RELIFERA").Value.ToString())
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
    Private Sub cmdELIMINAR_RELISOLI_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdELIMINAR_RELISOLI.Click

        Try
            If MessageBox.Show("¿ Desea eliminar el registro seleccionado ? ", "Mensaje...", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then
                Dim objdatos As New cla_RELISOLI

                If objdatos.fun_Eliminar_IDRE_RELISOLI(Integer.Parse(Me.dgvRELISOLI_1.SelectedRows.Item(0).Cells("RLSOIDRE").Value.ToString())) Then

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
    Private Sub cmdCONSULTAR_RELISOLI_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCONSULTAR_RELISOLI.Click

        vp_inConsulta = 0

        Dim frm_consultar As New frm_consultar_RESOLICE(Integer.Parse(Me.dgvRESOLICE.SelectedRows.Item(0).Cells("RELIIDRE").Value.ToString()))
        frm_consultar.ShowDialog()

        If vp_inConsulta > 0 Then
            boCONSULTA = True
        Else
            boCONSULTA = False
        End If

        pro_ReconsultarResolucionesyLicencias()
        pro_ListaDeValoresResolucionesyLicencias()

        Me.TabMAESTRO_2.SelectTab(TabSolicitante)

    End Sub
    Private Sub cmdRECONSULTAR_MATEREGI_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdRECONSULTAR_RELISOLI.Click

        boCONSULTA = False
        pro_ReconsultarResolucionesyLicencias()
        pro_ListaDeValoresResolucionesyLicencias()

    End Sub

#End Region

#Region "MENU PREDIO"

    Private Sub cmdAGREGAR_RELIPRED_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAGREGAR_RELIPRED.Click

        Try
            If Me.dgvRESOLICE.RowCount > 0 Then
                Dim frm_insertar As New frm_insertar_RELIPRED(Me.dgvRESOLICE.SelectedRows.Item(0).Cells("RELISECU").Value.ToString(), _
                                                              Me.dgvRESOLICE.SelectedRows.Item(0).Cells("RELINURA").Value.ToString(), _
                                                              Me.dgvRESOLICE.SelectedRows.Item(0).Cells("RELIFERA").Value.ToString())
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
    Private Sub cmdMODIFICAR_RELIPRED_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdMODIFICAR_RELIPRED.Click

        Try
            Dim frm_modificar As New frm_insertar_RELIPRED(Me.dgvRELIPRED.SelectedRows.Item(0).Cells("RLPRIDRE").Value.ToString(), _
                                                           Me.dgvRESOLICE.SelectedRows.Item(0).Cells("RELISECU").Value.ToString(), _
                                                           Me.dgvRESOLICE.SelectedRows.Item(0).Cells("RELINURA").Value.ToString(), _
                                                           Me.dgvRESOLICE.SelectedRows.Item(0).Cells("RELIFERA").Value.ToString())
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
    Private Sub cmdELIMINAR_RELIPRED_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdELIMINAR_RELIPRED.Click

        Try
            If MessageBox.Show("¿ Desea eliminar el registro seleccionado ? ", "Mensaje...", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then
                Dim objdatos As New cla_RELIPRED

                If objdatos.fun_Eliminar_IDRE_RELIPRED(Integer.Parse(Me.dgvRELIPRED.SelectedRows.Item(0).Cells("RLPRIDRE").Value.ToString())) Then

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
    Private Sub cmdCONSULTAR_RELIPRED_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCONSULTAR_RELIPRED.Click

        vp_inConsulta = 0

        Dim frm_consultar As New frm_consultar_RESOLICE(Integer.Parse(Me.dgvRESOLICE.SelectedRows.Item(0).Cells("RELIIDRE").Value.ToString()))
        frm_consultar.ShowDialog()

        If vp_inConsulta > 0 Then
            boCONSULTA = True
        Else
            boCONSULTA = False
        End If

        pro_ReconsultarResolucionesyLicencias()
        pro_ListaDeValoresResolucionesyLicencias()

        Me.TabMAESTRO_2.SelectTab(TabSolicitante)

    End Sub
    Private Sub cmdRECONSULTAR_RELIPRED_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdRECONSULTAR_RELIPRED.Click

        boCONSULTA = False
        pro_ReconsultarResolucionesyLicencias()
        pro_ListaDeValoresResolucionesyLicencias()

    End Sub

#End Region

#Region "MENU MATERIAL ENTREGADO"

    Private Sub cmdAGREGAR_MATEENTR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAGREGAR_RELIMAEN.Click

        Try
            Dim frm_modificar As New frm_insertar_RELIMAEN(Integer.Parse(Me.dgvRESOLICE.SelectedRows.Item(0).Cells("RELISECU").Value.ToString()), _
                                                           Integer.Parse(Me.dgvRESOLICE.SelectedRows.Item(0).Cells("RELINURA").Value.ToString()), _
                                                                         Me.dgvRESOLICE.SelectedRows.Item(0).Cells("RELIFERA").Value.ToString(), _
                                                                         Me.Name)
            frm_modificar.ShowDialog()

            boCONSULTA = False

            pro_ReconsultarMaterialEntregado()
            pro_ListaDeValoresMaterialEntregado()

            pro_ReconsultarMaterialDeFaltante()
            pro_ListaDeValoresMaterialDeFaltante()

            pro_ListadoArchivosDocumentosPDF()
            pro_ListadoArchivosDocumentosTIF()

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub cmdMODIFICAR_MATEENTR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdMODIFICAR_RELIMAEN.Click

        Try
            Dim frm_modificar As New frm_insertar_RELIMAEN(Integer.Parse(Me.dgvRESOLICE.SelectedRows.Item(0).Cells("RELISECU").Value.ToString()), _
                                                           Integer.Parse(Me.dgvRESOLICE.SelectedRows.Item(0).Cells("RELINURA").Value.ToString()), _
                                                                         Me.dgvRESOLICE.SelectedRows.Item(0).Cells("RELIFERA").Value.ToString(), _
                                                                         Me.Name)
            frm_modificar.ShowDialog()

            boCONSULTA = False

            pro_ReconsultarMaterialEntregado()
            pro_ListaDeValoresMaterialEntregado()

            pro_ReconsultarMaterialDeFaltante()
            pro_ListaDeValoresMaterialDeFaltante()

            pro_ListadoArchivosDocumentosPDF()
            pro_ListadoArchivosDocumentosTIF()

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub cmdELIMINAR_MATEENTR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdELIMINAR_RELIMAEN.Click

        Try
            If MessageBox.Show("¿ Desea eliminar el registro seleccionado ? ", "Mensaje...", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then
                Dim objdatos As New cla_RELIMAEN

                If objdatos.fun_Eliminar_SECU_X_MACA_RELIMAEN(Integer.Parse(Me.dgvRELIMAEN.SelectedRows.Item(0).Cells("RLMESECU").Value.ToString()), _
                                                              Integer.Parse(Me.dgvRELIMAEN.SelectedRows.Item(0).Cells("RLMEMACA").Value.ToString())) Then
                    boCONSULTA = False

                    pro_LimpiarMaterialEntregado()
                    pro_ReconsultarMaterialEntregado()
                    pro_ListaDeValoresMaterialEntregado()
                Else
                    frm_INCO_eliminar_registro_padre_con_relación_de_registros_hijos.ShowDialog()
                End If

            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub cmdCONSULTAR_MATEENTR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCONSULTAR_RELIMAEN.Click

        Try
            vp_inConsulta = 0

            Dim frm_consultar As New frm_consultar_RESOLICE(Integer.Parse(Me.dgvRESOLICE.SelectedRows.Item(0).Cells(0).Value.ToString()))
            frm_consultar.ShowDialog()

            If vp_inConsulta > 0 Then
                boCONSULTA = True
            Else
                boCONSULTA = False
            End If

            pro_ReconsultarResolucionesyLicencias()
            pro_ListaDeValoresResolucionesyLicencias()

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub cmdRECONSULTAR_MATEENTR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdRECONSULTAR_RELIMAEN.Click

        Try
            boCONSULTA = False
            pro_ReconsultarResolucionesyLicencias()
            pro_ListaDeValoresResolucionesyLicencias()

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub

    Private Sub ToolStripButton55_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton55.Click
        pro_ListaDeValoresMaterialEntregado()
    End Sub
    Private Sub ToolStripButton56_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton56.Click
        pro_ListaDeValoresMaterialEntregado()
    End Sub
    Private Sub ToolStripButton57_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton57.Click
        pro_ListaDeValoresMaterialEntregado()
    End Sub
    Private Sub ToolStripButton58_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton58.Click
        pro_ListaDeValoresMaterialEntregado()
    End Sub

#End Region

#Region "MENU MATERIAL FALTANTE"

    Private Sub cmdAGREGAR_MATEFALT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAGREGAR_RELIMAFA.Click

        Try
            Dim frm_modificar As New frm_insertar_RELIMAFA(Integer.Parse(Me.dgvRESOLICE.SelectedRows.Item(0).Cells("RELISECU").Value.ToString()), _
                                                           Integer.Parse(Me.dgvRESOLICE.SelectedRows.Item(0).Cells("RELINURA").Value.ToString()), _
                                                                         Me.dgvRESOLICE.SelectedRows.Item(0).Cells("RELIFERA").Value.ToString(), _
                                                                         Me.Name)
            frm_modificar.ShowDialog()
            boCONSULTA = False

            pro_ReconsultarMaterialDeFaltante()
            pro_ListaDeValoresMaterialDeFaltante()

            pro_ReconsultarMaterialEntregado()
            pro_ListaDeValoresMaterialEntregado()

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub cmdMODIFICAR_MATEFALT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdMODIFICAR_RELIMAFA.Click

        Try
            Dim frm_modificar As New frm_insertar_RELIMAFA(Integer.Parse(Me.dgvRESOLICE.SelectedRows.Item(0).Cells("RELISECU").Value.ToString()), _
                                                           Integer.Parse(Me.dgvRESOLICE.SelectedRows.Item(0).Cells("RELINURA").Value.ToString()), _
                                                                         Me.dgvRESOLICE.SelectedRows.Item(0).Cells("RELIFERA").Value.ToString(), _
                                                                         Me.Name)
            frm_modificar.ShowDialog()
            boCONSULTA = False

            pro_ReconsultarMaterialDeFaltante()
            pro_ListaDeValoresMaterialDeFaltante()

            pro_ReconsultarMaterialEntregado()
            pro_ListaDeValoresMaterialEntregado()

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub cmdELIMINAR_MATEFALT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdELIMINAR_RELIMAFA.Click

        Try
            If MessageBox.Show("¿ Desea eliminar el registro seleccionado ? ", "Mensaje...", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then
                Dim objdatos As New cla_RELIMAFA

                If objdatos.fun_Eliminar_SECU_X_MACA_RELIMAFA(Integer.Parse(Me.dgvRELIMAFA.SelectedRows.Item(0).Cells("RLMFSECU").Value.ToString()), _
                                                              Integer.Parse(Me.dgvRELIMAFA.SelectedRows.Item(0).Cells("RLMFMACA").Value.ToString())) Then
                    boCONSULTA = False

                    pro_LimpiarMaterialFaltante()
                    pro_ReconsultarMaterialDeFaltante()
                    pro_ListaDeValoresMaterialDeFaltante()
                Else
                    frm_INCO_eliminar_registro_padre_con_relación_de_registros_hijos.ShowDialog()
                End If

            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub cmdCONSULTAR_MATEFALT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCONSULTAR_RELIMAFA.Click

        Try
            vp_inConsulta = 0

            Dim frm_consultar As New frm_consultar_RESOLICE(Integer.Parse(Me.dgvRESOLICE.SelectedRows.Item(0).Cells(0).Value.ToString()))
            frm_consultar.ShowDialog()

            If vp_inConsulta > 0 Then
                boCONSULTA = True
            Else
                boCONSULTA = False
            End If

            pro_ReconsultarResolucionesyLicencias()
            pro_ListaDeValoresResolucionesyLicencias()

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub cmdRECONSULTAR_MATEFALT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdRECONSULTAR_RELIMAFA.Click

        Try
            boCONSULTA = False
            pro_ReconsultarResolucionesyLicencias()
            pro_ListaDeValoresResolucionesyLicencias()

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub

    Private Sub ToolStripButton82_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton82.Click

        Try
            pro_ListaDeValoresMaterialDeFaltante()

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub ToolStripButton83_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton83.Click

        Try
            pro_ListaDeValoresMaterialDeFaltante()

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub ToolStripButton84_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton84.Click

        Try
            pro_ListaDeValoresMaterialDeFaltante()

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub ToolStripButton85_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton85.Click

        Try
            pro_ListaDeValoresMaterialDeFaltante()

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub

#End Region

#Region "PERMISOS"

    Private Sub cmdAGREGAR_RELIPERM_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAGREGAR_RELIPERM.Click

        Try
            If Me.dgvRESOLICE.RowCount > 0 Then
                Dim frm_insertar As New frm_insertar_RELIPERM(Me.dgvRESOLICE.SelectedRows.Item(0).Cells("RELISECU").Value.ToString(), _
                                                              Me.dgvRESOLICE.SelectedRows.Item(0).Cells("RELINURA").Value.ToString(), _
                                                              Me.dgvRESOLICE.SelectedRows.Item(0).Cells("RELIFERA").Value.ToString())
                frm_insertar.ShowDialog()
            End If

            boCONSULTA = False

            pro_ReconsultarPermisos()
            pro_ListaDeValoresPermisos()

            Me.TabMAESTRO_2.SelectTab(TabPermisos)

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub cmdMODIFICAR_RELIPERM_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdMODIFICAR_RELIPERM.Click

        Dim frm_modificar As New frm_insertar_RELIPERM(Me.dgvRELIPERM.SelectedRows.Item(0).Cells("RLPEIDRE").Value.ToString())
        frm_modificar.ShowDialog()

        If vp_inConsulta <> 0 Then
            boCONSULTA = True
        End If

        pro_ReconsultarPermisos()
        pro_ListaDeValoresPermisos()

        Me.TabMAESTRO_2.SelectTab(TabPermisos)

    End Sub
    Private Sub cmdELIMINAR_RELIPERM_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdELIMINAR_RELIPERM.Click

        Try
            If MessageBox.Show("¿ Desea eliminar el registro seleccionado ? ", "Mensaje...", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then
                Dim objdatos As New cla_RELIPERM

                If objdatos.fun_Eliminar_IDRE_RELIPERM(Integer.Parse(Me.dgvRELIPERM.SelectedRows.Item(0).Cells("RLPEIDRE").Value.ToString())) Then

                    boCONSULTA = False

                    pro_LimpiarCamposPermisos()
                    pro_ReconsultarPermisos()
                    pro_ListaDeValoresPermisos()
                Else
                    frm_INCO_eliminar_registro_padre_con_relación_de_registros_hijos.ShowDialog()
                End If

            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub cmdCONSULTAR_RELIPERM_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCONSULTAR_RELIPERM.Click

        vp_inConsulta = 0

        Dim frm_consultar As New frm_consultar_RESOLICE(Integer.Parse(Me.dgvRESOLICE.SelectedRows.Item(0).Cells("RELIIDRE").Value.ToString()))
        frm_consultar.ShowDialog()

        If vp_inConsulta > 0 Then
            boCONSULTA = True
        Else
            boCONSULTA = False
        End If

        pro_ReconsultarResolucionesyLicencias()
        pro_ListaDeValoresResolucionesyLicencias()

        Me.TabMAESTRO_2.SelectTab(TabSolicitante)

    End Sub
    Private Sub cmdRECONSULTAR_RELIPERM_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdRECONSULTAR_RELIPERM.Click

        boCONSULTA = False
        pro_ReconsultarResolucionesyLicencias()
        pro_ListaDeValoresResolucionesyLicencias()

    End Sub

#End Region

#Region "FORMULARIO"

#Region "Load"

    Private Sub frm_RESOLICE_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Me.Load
        pro_ReconsultarResolucionesyLicencias()
        pro_ListadoArchivosDocumentosPDF()
        pro_ListadoArchivosDocumentosTIF()
        Me.strBARRESTA.Items(0).Text = "Resoluciones y licencias"
    End Sub

#End Region

#Region "GotFocus"

    Private Sub frm_RESOLICE_GotFocus1(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.GotFocus
        pro_ListaDeValoresResolucionesyLicencias()
    End Sub

#End Region

#Region "KeyDown"

    Private Sub dgvREGIMUTA_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgvRESOLICE.KeyDown
        '===============================================================================================
        '*** INSERTAR REGISTROS ***
        '===============================================================================================


        If e.KeyCode = Keys.F2 Then
            If Me.cmdAGREGAR_RESOLICE.Enabled = True Then
                Me.cmdAGREGAR_RESOLICE.PerformClick()
            Else
                mod_MENSAJE.Usuario_No_Tiene_Permiso_Para_Realizar_La_Operacion()
            End If
        End If

        '===============================================================================================
        'MODIFICAR REGISTROS
        '===============================================================================================

        If e.KeyCode = Keys.F3 Then
            If Me.cmdMODIFICAR_RESOLICE.Enabled = True Then
                Me.cmdMODIFICAR_RESOLICE.PerformClick()
            Else
                Dim ContarRegistros As Integer = Me.BindingSource_RELISOLI_1.Count

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
            If Me.cmdELIMINAR_RESOLICE.Enabled = True Then
                Me.cmdELIMINAR_RESOLICE.PerformClick()
            Else
                Dim ContarRegistros As Integer = Me.BindingSource_RELISOLI_1.Count

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
            If Me.cmdCONSULTAR_RESOLICE.Enabled = True Then
                Me.cmdCONSULTAR_RESOLICE.PerformClick()
            Else
                mod_MENSAJE.No_Existen_Registros_En_Base_De_Datos()
            End If
        End If

        '===============================================================================================
        '*** RECONSULTAR REGISTROS ***
        '===============================================================================================

        If e.KeyCode = Keys.F8 Then
            If Me.cmdCONSULTAR_RESOLICE.Enabled = True Then
                Me.cmdRECONSULTAR_RESOLICE.PerformClick()
            Else
                mod_MENSAJE.No_Existen_Registros_En_Base_De_Datos()
            End If
        End If

    End Sub

#End Region

#Region "KeyUp"

    Private Sub dgvREGIMUTA_1_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgvRESOLICE.KeyUp
        If e.KeyCode = Keys.Down Or e.KeyCode = Keys.Up Or e.KeyCode = Keys.Enter Or e.KeyCode = Keys.PageUp Or e.KeyCode = Keys.PageDown Then
            pro_ListaDeValoresResolucionesyLicencias()
        End If
    End Sub
    Private Sub dgvREGIMUTA_2_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgvRELIPERM.KeyUp
        If e.KeyCode = Keys.Down Or e.KeyCode = Keys.Up Or e.KeyCode = Keys.Enter Or e.KeyCode = Keys.PageUp Or e.KeyCode = Keys.PageDown Then
            pro_ListaDeValoresPermisos()
        End If
    End Sub

#End Region

#Region "CellClick"

    Private Sub dgvREGIMUTA_1_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvRESOLICE.CellClick
        pro_ListaDeValoresResolucionesyLicencias()
    End Sub
    Private Sub dgvRELIPERM_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvRELIPERM.CellClick
        pro_ListaDeValoresPermisos()
    End Sub

#End Region

#Region "Click"

    Private Sub pibImagenDocumentos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pibImagenDocumentos.Click

        Try
            If vl_stRutaDocumentosTIF <> "" Then
                Dim o_frm_Visor As New frm_visor_imagen(Trim(vl_stRutaDocumentosTIF) & "\" & Me.lstLISTADO_DOCUMENTOS_TIF.SelectedItem)
                o_frm_Visor.ShowDialog()
            End If
        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub cmdAbrirArchivoPDF_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAbrirArchivoPDF.Click

        Try
            If lstLISTADO_DOCUMENTOS_PDF.SelectedIndex <> -1 Then

                If vl_boControlDeComandos = True Or fun_ControlDePermisos() = True Then
                    Process.Start(vl_stRutaDocumentosPDF & "\" & Me.lstLISTADO_DOCUMENTOS_PDF.SelectedItem)
                Else
                    mod_MENSAJE.Usuario_No_Tiene_Permiso_Para_Realizar_La_Operacion()
                End If

            Else

                If lstLISTADO_DOCUMENTOS_PDF.Items.Count > 0 Then
                    mod_MENSAJE.Se_Requiere_Realizar_Una_Seleccion()
                End If

            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub cmdAbrirArchivoTIF_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAbrirArchivoTIF.Click

        Try
            If lstLISTADO_DOCUMENTOS_TIF.SelectedIndex <> -1 Then

                If vl_boControlDeComandos = True Or fun_ControlDePermisos() = True Then
                    Process.Start(vl_stRutaDocumentosTIF & "\" & Me.lstLISTADO_DOCUMENTOS_TIF.SelectedItem)
                Else
                    mod_MENSAJE.Usuario_No_Tiene_Permiso_Para_Realizar_La_Operacion()
                End If

            Else

                If lstLISTADO_DOCUMENTOS_TIF.Items.Count > 0 Then
                    mod_MENSAJE.Se_Requiere_Realizar_Una_Seleccion()
                End If

            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub lstLISTADO_DOCUMENTOS_TIF_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lstLISTADO_DOCUMENTOS_TIF.Click

        Try
            If lstLISTADO_DOCUMENTOS_TIF.SelectedIndex <> -1 Then

                Me.pibImagenDocumentos.Image = Nothing

                Me.pibImagenDocumentos.Image = Image.FromFile(vl_stRutaDocumentosTIF & "\" & Me.lstLISTADO_DOCUMENTOS_TIF.SelectedItem)
                Me.pibImagenDocumentos.SizeMode = PictureBoxSizeMode.Zoom

            Else
                If lstLISTADO_DOCUMENTOS_TIF.Items.Count > 0 Then
                    MessageBox.Show("Seleccione un archivo de la lista", "mensaje...", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                End If

            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub lstLISTADO_DOCUMENTOS_PDF_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lstLISTADO_DOCUMENTOS_PDF.Click

        Try
            If lstLISTADO_DOCUMENTOS_PDF.SelectedIndex <> -1 Then

                ' visualiza el archivo
                Me.axaVisorDocumentoPDF.LoadFile(vl_stRutaDocumentosPDF & "\" & Me.lstLISTADO_DOCUMENTOS_PDF.SelectedItem)
                Me.axaVisorDocumentoPDF.gotoFirstPage()

                pro_PermisoControlDeComandos()

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