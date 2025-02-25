Imports REGLAS_DEL_NEGOCIO
Imports System
Imports System.IO
Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration
Imports System.Text

Public Class frm_MUTACIONES

    '==================
    '*** MUTACIONES ***
    '==================

#Region "VARIABLES"

    Dim boCONSULTA As Boolean = False

    Dim vl_stRutaDocumentos As String = ""

    Dim stMensaje01 As String = "¿ Desea cambiar el estado del tramite ? "

    Private oEjecutar As New SqlCommand
    Private oConexion As New SqlConnection
    Private oAdapter As New SqlDataAdapter
    Private oReader As SqlDataReader
    Private ds As New DataSet
    Private dt As New DataTable

#End Region

#Region "INSTANCIAR FORMULARIO"

    Private Shared frm_Instance = Nothing

    Public Shared Function instance() As frm_MUTACIONES
        If frm_Instance Is Nothing OrElse frm_Instance.isdisposed = True Then
            frm_Instance = New frm_MUTACIONES
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

            tblRutas = objRutas.fun_Buscar_CODIGO_MANT_RUTAS(7)

            If tblRutas.Rows.Count > 0 Then

                ' directorio pricipal
                stRuta = Trim(tblRutas.Rows(0).Item("RUTARUTA")) & "\"

                ' directorio expediente 
                stCarpetaABuscar = Trim(Me.dgvMUTACIONES.SelectedRows.Item(0).Cells("MUTAMUNI").Value.ToString) & "-" & Trim(Me.dgvMUTACIONES.SelectedRows.Item(0).Cells("MUTACLSE").Value.ToString) & "-" & Trim(Me.dgvMUTACIONES.SelectedRows.Item(0).Cells("MUTACORR").Value.ToString) & "-" & Trim(Me.dgvMUTACIONES.SelectedRows.Item(0).Cells("MUTABARR").Value.ToString) & "-" & Trim(Me.dgvMUTACIONES.SelectedRows.Item(0).Cells("MUTAMANZ").Value.ToString) & "-" & Trim(Me.dgvMUTACIONES.SelectedRows.Item(0).Cells("MUTAPRED").Value.ToString) & "-" & Trim(Me.dgvMUTACIONES.SelectedRows.Item(0).Cells("MUTAEDIF").Value.ToString) & "-" & Trim(Me.dgvMUTACIONES.SelectedRows.Item(0).Cells("MUTAUNPR").Value.ToString) & "-" & Me.txtMUTAVIGE.Text

                Dim Ruta As New DirectoryInfo(stRuta)

                Dim TodasLasCarpetas(), CarpetaABuscar As DirectoryInfo

                ' declara la variable 
                Dim sw As Byte = 1

                TodasLasCarpetas = Ruta.GetDirectories()

                ' recorre el directorio
                For Each CarpetaABuscar In TodasLasCarpetas

                    If CarpetaABuscar.FullName = Ruta.FullName & stCarpetaABuscar Then
                        sw = 0
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

#Region "PROCEDIMIENTOS MUTACIONES"

    Private Sub pro_ReconsultarMutaciones()

        Try
            Dim objdatos As New cla_MUTACIONES

            If boCONSULTA = False Then
                Me.BindingSource_MUTACIONES_1.DataSource = objdatos.fun_Consultar_MUTACIONES
            Else
                Me.BindingSource_MUTACIONES_1.DataSource = objdatos.fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_MUTACIONES(vp_inConsulta)
            End If

            Me.dgvMUTACIONES.DataSource = BindingSource_MUTACIONES_1
            Me.BindingNavigator_MUTACIONES_1.BindingSource = BindingSource_MUTACIONES_1

            '==================================================
            '*** CONFIGURA OBJETOS DEL FORMULARIO MAESTRO ***
            '==================================================

            Me.strBARRESTA.Items(2).Text = "Registros : " & Me.BindingSource_MUTACIONES_1.Count

            Me.dgvMUTACIONES.Columns("MUTAIDRE").HeaderText = "idre"
            Me.dgvMUTACIONES.Columns("MUTASECU").HeaderText = "Secuencia"

            Me.dgvMUTACIONES.Columns("MUTADEPA").HeaderText = "Departamento"
            Me.dgvMUTACIONES.Columns("MUTAMUNI").HeaderText = "Municipio"
            Me.dgvMUTACIONES.Columns("MUTACORR").HeaderText = "Corregimiento"
            Me.dgvMUTACIONES.Columns("MUTABARR").HeaderText = "Barrio"
            Me.dgvMUTACIONES.Columns("MUTAMANZ").HeaderText = "Manzana Vereda"
            Me.dgvMUTACIONES.Columns("MUTAPRED").HeaderText = "Predio"
            Me.dgvMUTACIONES.Columns("MUTAEDIF").HeaderText = "Edificio"
            Me.dgvMUTACIONES.Columns("MUTAUNPR").HeaderText = "Unidad"
            Me.dgvMUTACIONES.Columns("CLSEDESC").HeaderText = "Sector"
            Me.dgvMUTACIONES.Columns("ESTADESC").HeaderText = "Estado"

            Me.dgvMUTACIONES.Columns("MUTAIDRE").Visible = False
            Me.dgvMUTACIONES.Columns("MUTASECU").Visible = False
            Me.dgvMUTACIONES.Columns("MUTAMACA").Visible = False
            Me.dgvMUTACIONES.Columns("MUTAFEIN").Visible = False
            Me.dgvMUTACIONES.Columns("MUTAVIGE").Visible = False
            Me.dgvMUTACIONES.Columns("MUTANUFI").Visible = False
            Me.dgvMUTACIONES.Columns("MUTADEPA").Visible = False
            Me.dgvMUTACIONES.Columns("MUTAFEES").Visible = False
            Me.dgvMUTACIONES.Columns("MUTAESCR").Visible = False
            Me.dgvMUTACIONES.Columns("MUTANURA").Visible = False
            Me.dgvMUTACIONES.Columns("MUTAFERA").Visible = False
            Me.dgvMUTACIONES.Columns("MUTAOBSE").Visible = False
            Me.dgvMUTACIONES.Columns("MUTADESC").Visible = False
            Me.dgvMUTACIONES.Columns("MUTAMAIN").Visible = False
            Me.dgvMUTACIONES.Columns("MUTAVACO").Visible = False
            Me.dgvMUTACIONES.Columns("MUTAESTA").Visible = False
            Me.dgvMUTACIONES.Columns("MUTACLSE").Visible = False
            Me.dgvMUTACIONES.Columns("MUTANURE").Visible = False
            Me.dgvMUTACIONES.Columns("MUTAFERE").Visible = False

            '==================================================
            '*** ASIGNA LOS PRIVILEGIOS DE LA BARRA DE MENU ***
            '==================================================

            Dim ContarRegistros As Integer = Me.BindingSource_MUTACIONES_1.Count

            Dim boCONTAGRE As Boolean = False
            Dim boCONTMODI As Boolean = False
            Dim boCONTELIM As Boolean = False
            Dim boCONTCONS As Boolean = False
            Dim boCONTRECO As Boolean = False

           pro_Permiso_Barra_De_Menu_Formulario_SubFormulario(ContarRegistros, Trim(Me.BindingNavigator_MUTACIONES_1.Name), boCONTAGRE, boCONTMODI, boCONTELIM, boCONTCONS, boCONTRECO)

            Me.cmdAGREGAR_MUTACIONES.Enabled = boCONTAGRE
            Me.cmdMODIFICAR_MUTACIONES.Enabled = boCONTMODI
            Me.cmdELIMINAR_MUTACIONES.Enabled = boCONTELIM
            Me.cmdCONSULTAR_MUTACIONES.Enabled = True
            Me.cmdRECONSULTAR_MUTACIONES.Enabled = boCONTRECO

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub pro_ListaDeValoresMutaciones()

        Try
            If Me.dgvMUTACIONES.RowCount > 0 Then

                Dim objdatos As New cla_MUTACIONES
                Dim tbl As New DataTable

                tbl = objdatos.fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_MUTACIONES(Me.dgvMUTACIONES.SelectedRows.Item(0).Cells("MUTAIDRE").Value.ToString)

                Me.txtMUTAFEES.Text = Trim(Me.dgvMUTACIONES.SelectedRows.Item(0).Cells("MUTAFEES").Value.ToString)
                Me.txtMUTAESCR.Text = Trim(Me.dgvMUTACIONES.SelectedRows.Item(0).Cells("MUTAESCR").Value.ToString)
                Me.txtMUTANURA.Text = Trim(Me.dgvMUTACIONES.SelectedRows.Item(0).Cells("MUTANURA").Value.ToString)
                Me.txtMUTAFERA.Text = Trim(Me.dgvMUTACIONES.SelectedRows.Item(0).Cells("MUTAFERA").Value.ToString)
                Me.txtMUTANURE.Text = Trim(Me.dgvMUTACIONES.SelectedRows.Item(0).Cells("MUTANURE").Value.ToString)
                Me.txtMUTAFERE.Text = Trim(Me.dgvMUTACIONES.SelectedRows.Item(0).Cells("MUTAFERE").Value.ToString)
                Me.txtMUTAOBSE.Text = Trim(Me.dgvMUTACIONES.SelectedRows.Item(0).Cells("MUTAOBSE").Value.ToString)
                Me.txtMUTAVIGE.Text = Trim(Me.dgvMUTACIONES.SelectedRows.Item(0).Cells("MUTAVIGE").Value.ToString)
                Me.txtMUTACLSE.Text = Trim(Me.dgvMUTACIONES.SelectedRows.Item(0).Cells("MUTACLSE").Value.ToString)
                Me.txtMUTADESC.Text = Trim(Me.dgvMUTACIONES.SelectedRows.Item(0).Cells("MUTADESC").Value.ToString)
                Me.txtMUTAFEIN.Text = Trim(Me.dgvMUTACIONES.SelectedRows.Item(0).Cells("MUTAFEIN").Value.ToString).ToString.Replace("/", "-")
                Me.txtMUTANUFI.Text = Trim(Me.dgvMUTACIONES.SelectedRows.Item(0).Cells("MUTANUFI").Value.ToString)
                Me.txtMUTAMAIN.Text = Trim(Me.dgvMUTACIONES.SelectedRows.Item(0).Cells("MUTAMAIN").Value.ToString)
                Me.txtMUTAVACO.Text = fun_Formato_Mascara_Pesos_Enteros(Trim(Me.dgvMUTACIONES.SelectedRows.Item(0).Cells("MUTAVACO").Value.ToString))

                Me.lblMUTAMUNI.Text = CType(fun_Buscar_Lista_Valores_MUNICIPIO(Me.dgvMUTACIONES.SelectedRows.Item(0).Cells("MUTADEPA").Value.ToString, Me.dgvMUTACIONES.SelectedRows.Item(0).Cells("MUTAMUNI").Value.ToString), String)
                Me.lblMUTACLSE.Text = CType(fun_Buscar_Lista_Valores_CLASSECT(Me.dgvMUTACIONES.SelectedRows.Item(0).Cells("MUTACLSE").Value.ToString), String)
                Me.lblMUTAVIGE.Text = CType(fun_Buscar_Lista_Valores_VIGENCIA(Me.dgvMUTACIONES.SelectedRows.Item(0).Cells("MUTAVIGE").Value.ToString), String)
                Me.txtMUTAMACA.Text = CType(fun_Buscar_Lista_Valores_USUARIO(tbl.Rows(0).Item("MUTAMACA")), String)

                Me.lblMUTACORR.Text = CType(fun_Buscar_Lista_Valores_CORREGIMIENTO(Me.dgvMUTACIONES.SelectedRows.Item(0).Cells("MUTADEPA").Value.ToString, Me.dgvMUTACIONES.SelectedRows.Item(0).Cells("MUTAMUNI").Value.ToString, Me.dgvMUTACIONES.SelectedRows.Item(0).Cells("MUTACLSE").Value.ToString, Me.dgvMUTACIONES.SelectedRows.Item(0).Cells("MUTACORR").Value.ToString), String)

                If CInt(Me.dgvMUTACIONES.SelectedRows.Item(0).Cells("MUTACLSE").Value.ToString) = 1 Then
                    Me.lblMUTABAVE.Text = CType(fun_Buscar_Lista_Valores_BARRIO(Me.dgvMUTACIONES.SelectedRows.Item(0).Cells("MUTADEPA").Value.ToString, Me.dgvMUTACIONES.SelectedRows.Item(0).Cells("MUTAMUNI").Value.ToString, Me.dgvMUTACIONES.SelectedRows.Item(0).Cells("MUTACLSE").Value.ToString, Me.dgvMUTACIONES.SelectedRows.Item(0).Cells("MUTABARR").Value.ToString, Me.dgvMUTACIONES.SelectedRows.Item(0).Cells("MUTACORR").Value.ToString), String)
                ElseIf CInt(Me.dgvMUTACIONES.SelectedRows.Item(0).Cells("MUTACLSE").Value.ToString) = 2 Then
                    Me.lblMUTABAVE.Text = CType(fun_Buscar_Lista_Valores_VEREDA(Me.dgvMUTACIONES.SelectedRows.Item(0).Cells("MUTADEPA").Value.ToString, Me.dgvMUTACIONES.SelectedRows.Item(0).Cells("MUTAMUNI").Value.ToString, Me.dgvMUTACIONES.SelectedRows.Item(0).Cells("MUTACLSE").Value.ToString, Me.dgvMUTACIONES.SelectedRows.Item(0).Cells("MUTAMANZ").Value.ToString, Me.dgvMUTACIONES.SelectedRows.Item(0).Cells("MUTACORR").Value.ToString), String)
                ElseIf CInt(Me.dgvMUTACIONES.SelectedRows.Item(0).Cells("MUTACLSE").Value.ToString) = 3 Then
                    Me.lblMUTABAVE.Text = CType(fun_Buscar_Lista_Valores_BARRIO(Me.dgvMUTACIONES.SelectedRows.Item(0).Cells("MUTADEPA").Value.ToString, Me.dgvMUTACIONES.SelectedRows.Item(0).Cells("MUTAMUNI").Value.ToString, Me.dgvMUTACIONES.SelectedRows.Item(0).Cells("MUTACLSE").Value.ToString, Me.dgvMUTACIONES.SelectedRows.Item(0).Cells("MUTABARR").Value.ToString, Me.dgvMUTACIONES.SelectedRows.Item(0).Cells("MUTACORR").Value.ToString), String)
                End If

                Me.lblMUTACLSE.Text = CType(fun_Buscar_Lista_Valores_CLASSECT(Me.dgvMUTACIONES.SelectedRows.Item(0).Cells("MUTACLSE").Value.ToString), String)
                Me.lblMUTACLSE_1.Text = CType(fun_Buscar_Lista_Valores_CLASSECT(Me.dgvMUTACIONES.SelectedRows.Item(0).Cells("MUTACLSE").Value.ToString), String)

                If Trim(Me.dgvMUTACIONES.SelectedRows.Item(0).Cells("MUTAESTA").Value.ToString) = "fi" Then
                    Me.cmdFinalizar.Enabled = False
                Else
                    pro_PermisoControlDeComandos()
                End If

                pro_ReconsultarMaterialDeRegistro()
                pro_ListaDeValoresMaterialDeRegistro()

                pro_ReconsultarInformacionDeUsuario()
                pro_ListaDeValoresInformacionDeUsuario()

                pro_ReconsultarMaterialDeUsuario()
                pro_ListaDeValoresMaterialDeUsuario()

                pro_ReconsultarMaterialDeFaltante()
                pro_ListaDeValoresMaterialDeFaltante()

                pro_ReconsultarLevantamiento()
                pro_ListaDeValoresLevantamiento()

                pro_ReconsultarDigitacion()
                pro_ListaDeValoresDigitacion()

                pro_ReconsultarArchivo()
                pro_ListaDeValoresArchivo()

                pro_ReconsultarMatriculasAnexas()
                pro_ListaDeValoresMatriculasAnexas()

                pro_ListadoArchivosDocumentos()

                Me.BindingNavigator_MUTAMARE_1.Enabled = True
                Me.BindingNavigator_MUTAINUS_1.Enabled = True
                Me.BindingNavigator_MUTAMAEN_1.Enabled = True
                Me.BindingNavigator_MUTAMAFA_1.Enabled = True
                Me.BindingNavigator_MUTAMUNI_1.Enabled = True
                Me.BindingNavigator_MUTADEPA_1.Enabled = True
                Me.BindingNavigator_MUTAARCH_1.Enabled = True
                Me.BindingNavigator_MUTAMATR_1.Enabled = True

            Else
                pro_LimpiarCamposMutaciones()
                pro_LimpiarMaterialRegistro()
                pro_LimpiarInformacionUsuario()
                pro_LimpiarMaterialUsuario()
                pro_LimpiarMaterialFaltante()
                pro_LimpiarLevantamiento()
                pro_LimpiarDigitacion()
                pro_LimpiarArchivo()
                pro_LimpiarMatriculasAnexas()

                Me.BindingNavigator_MUTAMARE_1.Enabled = False
                Me.BindingNavigator_MUTAINUS_1.Enabled = False
                Me.BindingNavigator_MUTAMAEN_1.Enabled = False
                Me.BindingNavigator_MUTAMAFA_1.Enabled = False
                Me.BindingNavigator_MUTAMUNI_1.Enabled = False
                Me.BindingNavigator_MUTADEPA_1.Enabled = False
                Me.BindingNavigator_MUTAARCH_1.Enabled = False
                Me.BindingNavigator_MUTAMATR_1.Enabled = False

            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub pro_LimpiarCamposMutaciones()

        Me.lblMUTAMUNI.Text = ""
        Me.lblMUTACLSE.Text = ""
        Me.lblMUTAVIGE.Text = ""
        Me.txtMUTAFEES.Text = ""
        Me.txtMUTAESCR.Text = ""
        Me.txtMUTANURA.Text = ""
        Me.txtMUTAFERA.Text = ""
        Me.txtMUTAOBSE.Text = ""
        Me.txtMUTAVIGE.Text = ""
        Me.txtMUTACLSE.Text = ""
        Me.txtMUTAMACA.Text = ""
        Me.txtMUTADESC.Text = ""
        Me.txtMUTANUFI.Text = ""
        Me.txtMUTAFEIN.Text = ""
        Me.txtMUTAMAIN.Text = ""
        Me.txtMUTAVACO.Text = ""

        Me.lstLISTADO_DOCUMENTOS.Items.Clear()

        Me.strBARRESTA.Items(2).Text = "Registros : 0"

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

            tblRutas = objRutas.fun_Buscar_CODIGO_MANT_RUTAS(7)

            If tblRutas.Rows.Count > 0 AndAlso fun_VerificarCarpetaExistenteDocumentos() = True Then

                stNewPath = Trim(tblRutas.Rows(0).Item("RUTARUTA")) & "\" & Trim(Me.dgvMUTACIONES.SelectedRows.Item(0).Cells("MUTAMUNI").Value.ToString) & "-" & Trim(Me.dgvMUTACIONES.SelectedRows.Item(0).Cells("MUTACLSE").Value.ToString) & "-" & Trim(Me.dgvMUTACIONES.SelectedRows.Item(0).Cells("MUTACORR").Value.ToString) & "-" & Trim(Me.dgvMUTACIONES.SelectedRows.Item(0).Cells("MUTABARR").Value.ToString) & "-" & Trim(Me.dgvMUTACIONES.SelectedRows.Item(0).Cells("MUTAMANZ").Value.ToString) & "-" & Trim(Me.dgvMUTACIONES.SelectedRows.Item(0).Cells("MUTAPRED").Value.ToString) & "-" & Trim(Me.dgvMUTACIONES.SelectedRows.Item(0).Cells("MUTAEDIF").Value.ToString) & "-" & Trim(Me.dgvMUTACIONES.SelectedRows.Item(0).Cells("MUTAUNPR").Value.ToString) & "-" & Me.txtMUTAVIGE.Text

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
    Private Sub pro_PermisoControlDeComandos()

        Try
            Me.cmdFinalizar.Enabled = fun_PermisoControlDeComandos(vp_usuario, Me.Name, Me.cmdFinalizar.Name)

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub

    Private Sub pro_EjecutarBotonFinalizar()

        Try
            If Me.dgvMUTACIONES.RowCount > 0 Then

                If MessageBox.Show("¿ Desea finalizar el tramite Nro. " & Me.dgvMUTACIONES.SelectedRows.Item(0).Cells("MUTASECU").Value.ToString() & " ? ", "Mensaje...", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then

                    Dim stRECLOBSE_ACTUAL As String = ""
                    Dim stRECLOBSE_NUEVA As String = " Nota de registro: " & " El usuario: " & vp_usuario & " " & fun_fecha() & " finalizo el tramite. "

                    Dim obRECLGEOG As New cla_MUTACIONES
                    Dim dtRECLGEOG As New DataTable

                    dtRECLGEOG = obRECLGEOG.fun_Buscar_ID_MUTACIONES(Me.dgvMUTACIONES.SelectedRows.Item(0).Cells("MUTAIDRE").Value.ToString())

                    If dtRECLGEOG.Rows.Count > 0 Then
                        stRECLOBSE_ACTUAL = Trim(dtRECLGEOG.Rows(0).Item("MUTAOBSE").ToString)
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
                    Dim inMOGEIDRE As Integer = Integer.Parse(Me.dgvMUTACIONES.SelectedRows.Item(0).Cells("MUTAIDRE").Value.ToString())
                    Dim stMOGEESTA As String = "fi"

                    ' parametros de la consulta
                    Dim ParametrosConsulta As String = ""

                    ' Concatena la condicion de la consulta
                    ParametrosConsulta += "update MUTACIONES "
                    ParametrosConsulta += "set MUTAESTA = '" & stMOGEESTA & "', "
                    ParametrosConsulta += "MUTAOBSE = '" & stRECLOBSE_ACTUAL & "'  "
                    ParametrosConsulta += "where MUTAIDRE = '" & inMOGEIDRE & "'  "

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

                    boCONSULTA = True

                    vp_inConsulta = Me.dgvMUTACIONES.SelectedRows.Item(0).Cells("MUTAIDRE").Value.ToString()

                    pro_ReconsultarMutaciones()
                    pro_ListaDeValoresMutaciones()

                    Me.tabMaestro_2.SelectTab(TabObservaciones)

                End If

            Else
                mod_MENSAJE.No_Existe_Un_Registro_Seleccionado()
            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub pro_EjecutarBotonObservaciones()

        Try
            If Me.dgvMUTACIONES.RowCount > 0 Then

                If MessageBox.Show("¿ Desea ingresar una observación al tramite Nro. " & Me.dgvMUTACIONES.SelectedRows.Item(0).Cells("MUTASECU").Value.ToString() & " ? ", "Mensaje...", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then

                    Dim stObservacionNueva As String = InputBox("Ingrese la observación.", "Mensaje")

                    If Trim(stObservacionNueva) = "" Then
                        MessageBox.Show("Se requiere una observación.", "Mensaje...", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                        mod_MENSAJE.No_Se_Modifico_El_Registro_En_La_Base_De_Datos()
                    Else

                        Dim stRECLOBSE_ACTUAL As String = ""
                        Dim stRECLOBSE_NUEVA As String = Trim(stObservacionNueva.ToString.ToUpper)

                        Dim obMOGEGEOG As New cla_MUTACIONES
                        Dim dtAJUSGEOG As New DataTable

                        dtAJUSGEOG = obMOGEGEOG.fun_Buscar_ID_MUTACIONES(Me.dgvMUTACIONES.SelectedRows.Item(0).Cells("MUTAIDRE").Value.ToString())

                        If dtAJUSGEOG.Rows.Count > 0 Then
                            stRECLOBSE_ACTUAL = Trim(dtAJUSGEOG.Rows(0).Item("MUTAOBSE").ToString)
                        End If

                        If Trim(stRECLOBSE_ACTUAL) <> "" And Trim(stRECLOBSE_NUEVA) <> "" Then
                            stRECLOBSE_ACTUAL += vbCrLf & " Nota ingresada por " & vp_usuario & " " & fun_fecha() & " : " & stRECLOBSE_NUEVA & ". "

                        ElseIf Trim(stRECLOBSE_ACTUAL) = "" And Trim(stRECLOBSE_NUEVA) <> "" Then
                            stRECLOBSE_ACTUAL = " Nota ingresada por " & vp_usuario & " " & fun_fecha() & " : " & stRECLOBSE_NUEVA & ". "

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
                        Dim inMOGEIDRE As Integer = Integer.Parse(Me.dgvMUTACIONES.SelectedRows.Item(0).Cells("MUTAIDRE").Value.ToString())

                        ' parametros de la consulta
                        Dim ParametrosConsulta As String = ""

                        ' Concatena la condicion de la consulta
                        ParametrosConsulta += "update MUTACIONES "
                        ParametrosConsulta += "set MUTAOBSE = '" & stRECLOBSE_ACTUAL & "' "
                        ParametrosConsulta += "where MUTAIDRE = '" & inMOGEIDRE & "' "

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

                        pro_ReconsultarMutaciones()
                        pro_ListaDeValoresMutaciones()

                        Me.tabMaestro_2.SelectTab(TabObservaciones)

                    End If

                End If
            Else
                mod_MENSAJE.No_Existe_Un_Registro_Seleccionado()
            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub

    Private Sub pro_Mensaje01()

        'If Me.dgvLEVANTAMIENTO.RowCount = 0 And Me.dgvDIGITACION.RowCount = 0 And Me.dgvLIQUIDACION.RowCount = 0 And Me.dgvARCHIVO.RowCount = 0 Then
        '    If MessageBox.Show(stMensaje01, "mensaje", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then
        '        Me.cmdMODIFICAR_MUTACIONES.PerformClick()
        '    End If
        'End If

    End Sub
    Private Sub pro_Mensaje02()

        If Me.dgvARCHIVO.RowCount = 1 Then
            If MessageBox.Show(stMensaje01, "mensaje", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then
                Me.cmdMODIFICAR_MUTACIONES.PerformClick()
            End If
        End If

    End Sub

#End Region

#Region "PROCEDIMIENTOS METERIAL DE REGISTRO"

    Private Sub pro_ReconsultarMaterialDeRegistro()

        Try
            Dim objdatos As New cla_MUTAMARE

            If boCONSULTA = False Then
                Me.BindingSource_MATEREGI_1.DataSource = objdatos.fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_MUTAMARE(Me.dgvMUTACIONES.SelectedRows.Item(0).Cells("MUTASECU").Value.ToString)
            Else
                Me.BindingSource_MATEREGI_1.DataSource = objdatos.fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_MUTAMARE(Me.dgvMUTACIONES.SelectedRows.Item(0).Cells("MUTASECU").Value.ToString)
            End If

            Me.dgvMATEREGI.DataSource = Me.BindingSource_MATEREGI_1
            Me.BindingNavigator_MUTAMARE_1.BindingSource = Me.BindingSource_MATEREGI_1

            '================================================
            '*** CONFIGURA OBJETOS DEL FORMULARIO MAESTRO ***
            '================================================

            Me.dgvMATEREGI.Columns("MUMRIDRE").HeaderText = "idre"
            Me.dgvMATEREGI.Columns("MUMRSECU").HeaderText = "Secuencia"

            Me.dgvMATEREGI.Columns("MUMRMACA").HeaderText = "Código"
            Me.dgvMATEREGI.Columns("MACADESC").HeaderText = "Descripción"
            Me.dgvMATEREGI.Columns("MUMRFECH").HeaderText = "Fecha"
            Me.dgvMATEREGI.Columns("MUMROBSE").HeaderText = "Observación"

            Me.dgvMATEREGI.Columns("MUMRIDRE").Visible = False
            Me.dgvMATEREGI.Columns("MUMRSECU").Visible = False
            Me.dgvMATEREGI.Columns("MUMROBSE").Visible = False

            Me.dgvMATEREGI.Columns("MUMRMACA").Width = 30
            Me.dgvMATEREGI.Columns("MACADESC").Width = 100
            Me.dgvMATEREGI.Columns("MUMRFECH").Width = 100

            '==================================================
            '*** ASIGNA LOS PRIVILEGIOS DE LA BARRA DE MENU ***
            '==================================================

            Dim ContarRegistros As Integer = Me.BindingSource_MATEREGI_1.Count

            Dim boCONTAGRE As Boolean = False
            Dim boCONTMODI As Boolean = False
            Dim boCONTELIM As Boolean = False
            Dim boCONTCONS As Boolean = False
            Dim boCONTRECO As Boolean = False

            'pro_Permiso_Barra_De_Menu_Formulario_Formulario(ContarRegistros, Trim(Me.Name), boCONTAGRE, boCONTMODI, boCONTELIM, boCONTCONS, boCONTRECO)
            pro_Permiso_Barra_De_Menu_Formulario_SubFormulario(ContarRegistros, Trim(Me.BindingNavigator_MUTAMARE_1.Name), boCONTAGRE, boCONTMODI, boCONTELIM, boCONTCONS, boCONTRECO)

            Me.cmdAGREGAR_MATEREGI.Enabled = boCONTAGRE
            Me.cmdMODIFICAR_MATEREGI.Enabled = boCONTMODI
            Me.cmdELIMINAR_MATEREGI.Enabled = boCONTELIM
            Me.cmdCONSULTAR_MATEREGI.Enabled = boCONTCONS
            Me.cmdRECONSULTAR_MATEREGI.Enabled = boCONTRECO

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try
    End Sub
    Private Sub pro_ListaDeValoresMaterialDeRegistro()

        Try
            If Me.dgvMATEREGI.RowCount > 0 Then

                Dim objdatos As New cla_MUTAMARE
                Dim tbl As New DataTable

                tbl = objdatos.fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_MUTAMARE(Me.dgvMUTACIONES.SelectedRows.Item(0).Cells("MUTASECU").Value.ToString)

                If tbl.Rows.Count > 0 Then
                    Me.txtMAREOBSE.Text = Trim(tbl.Rows(0).Item("MUMROBSE"))
                Else
                    Me.txtMAREOBSE.Text = ""
                End If

            Else
                pro_LimpiarMaterialRegistro()

            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub pro_LimpiarMaterialRegistro()

        Me.txtMAREOBSE.Text = ""

        'Me.dgvMATEREGI.DataSource = New DataTable

    End Sub

#End Region

#Region "PROCEDIMIENTOS INFORMACION DE USUARIO"

    Private Sub pro_ReconsultarInformacionDeUsuario()

        Try
            Dim objdatos As New cla_MUTAINUS

            If boCONSULTA = False Then
                Me.BindingSource_INFOUSUA_1.DataSource = objdatos.fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_MUTAINUS(Me.dgvMUTACIONES.SelectedRows.Item(0).Cells("MUTASECU").Value.ToString)
            Else
                Me.BindingSource_INFOUSUA_1.DataSource = objdatos.fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_MUTAINUS(Me.dgvMUTACIONES.SelectedRows.Item(0).Cells("MUTASECU").Value.ToString)
            End If

            Me.BindingNavigator_MUTAINUS_1.BindingSource = Me.BindingSource_INFOUSUA_1

            '==================================================
            '*** ASIGNA LOS PRIVILEGIOS DE LA BARRA DE MENU ***
            '==================================================

            Dim ContarRegistros As Integer = Me.BindingSource_INFOUSUA_1.Count

            Dim boCONTAGRE As Boolean = False
            Dim boCONTMODI As Boolean = False
            Dim boCONTELIM As Boolean = False
            Dim boCONTCONS As Boolean = False
            Dim boCONTRECO As Boolean = False

            'pro_Permiso_Barra_De_Menu_Formulario_Formulario(ContarRegistros, Trim(Me.Name), boCONTAGRE, boCONTMODI, boCONTELIM, boCONTCONS, boCONTRECO)
            pro_Permiso_Barra_De_Menu_Formulario_SubFormulario(ContarRegistros, Trim(Me.BindingNavigator_MUTAINUS_1.Name), boCONTAGRE, boCONTMODI, boCONTELIM, boCONTCONS, boCONTRECO)

            Me.cmdAGREGAR_INFOUSUA.Enabled = boCONTAGRE
            Me.cmdMODIFICAR_INFOUSUA.Enabled = boCONTMODI
            Me.cmdELIMINAR_INFOUSUA.Enabled = boCONTELIM
            Me.cmdCONSULTAR_INFOUSUA.Enabled = boCONTCONS
            Me.cmdRECONSULTAR_INFOUSUA.Enabled = boCONTRECO

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try
    End Sub
    Private Sub pro_ListaDeValoresInformacionDeUsuario()

        Try
            If Me.BindingSource_INFOUSUA_1.Count > 0 Then

                Dim objdatos As New cla_MUTAINUS
                Dim tbl As New DataTable

                tbl = objdatos.fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_MUTAINUS(Me.dgvMUTACIONES.SelectedRows.Item(0).Cells("MUTASECU").Value.ToString)

                If tbl.Rows.Count > 0 Then

                    Me.txtINUSNUDO.Text = Trim(tbl.Rows(0).Item("MUIUNUDO"))
                    Me.txtINUSFERE.Text = Trim(tbl.Rows(0).Item("MUIUFERE"))
                    Me.txtINUSNOMB.Text = Trim(tbl.Rows(0).Item("MUIUNOMB"))
                    Me.txtINUSPRAP.Text = Trim(tbl.Rows(0).Item("MUIUPRAP"))
                    Me.txtINUSSEAP.Text = Trim(tbl.Rows(0).Item("MUIUSEAP"))
                    Me.txtINUSTEL1.Text = Trim(tbl.Rows(0).Item("MUIUTEL1"))
                    Me.txtINUSTEL2.Text = Trim(tbl.Rows(0).Item("MUIUTEL2"))
                    Me.txtINUSDIRE.Text = Trim(tbl.Rows(0).Item("MUIUDIRE"))
                    Me.txtINUSOBSE.Text = Trim(tbl.Rows(0).Item("MUIUOBSE"))

                End If

            Else
                pro_LimpiarInformacionUsuario()

            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub pro_LimpiarInformacionUsuario()

        Me.txtINUSNUDO.Text = ""
        Me.txtINUSFERE.Text = ""
        Me.txtINUSNOMB.Text = ""
        Me.txtINUSPRAP.Text = ""
        Me.txtINUSSEAP.Text = ""
        Me.txtINUSTEL1.Text = ""
        Me.txtINUSTEL2.Text = ""
        Me.txtINUSDIRE.Text = ""
        Me.txtINUSOBSE.Text = ""

    End Sub

#End Region

#Region "PROCEDIMIENTOS METERIAL DE USUARIO"

    Private Sub pro_ReconsultarMaterialDeUsuario()

        Try
            Dim objdatos As New cla_MUTAMAUS

            If boCONSULTA = False Then
                Me.BindingSource_MATEUSUA_1.DataSource = objdatos.fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_MUTAMAUS(Me.dgvMUTACIONES.SelectedRows.Item(0).Cells("MUTASECU").Value.ToString)
            Else
                Me.BindingSource_MATEUSUA_1.DataSource = objdatos.fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_MUTAMAUS(Me.dgvMUTACIONES.SelectedRows.Item(0).Cells("MUTASECU").Value.ToString)
            End If

            Me.dgvMATEUSUA.DataSource = Me.BindingSource_MATEUSUA_1
            Me.BindingNavigator_MUTAMAEN_1.BindingSource = Me.BindingSource_MATEUSUA_1

            '==================================================
            '*** CONFIGURA OBJETOS DEL FORMULARIO MAESTRO ***
            '==================================================

            Me.dgvMATEUSUA.Columns("MUMUIDRE").HeaderText = "idre"
            Me.dgvMATEUSUA.Columns("MUMUSECU").HeaderText = "Secuencia"

            Me.dgvMATEUSUA.Columns("MUMUMACA").HeaderText = "Código"
            Me.dgvMATEUSUA.Columns("MACADESC").HeaderText = "Descripción"
            Me.dgvMATEUSUA.Columns("MUMUFECH").HeaderText = "Fecha"
            Me.dgvMATEUSUA.Columns("MUMUOBSE").HeaderText = "Observación"

            Me.dgvMATEUSUA.Columns("MUMUIDRE").Visible = False
            Me.dgvMATEUSUA.Columns("MUMUSECU").Visible = False
            Me.dgvMATEUSUA.Columns("MUMUOBSE").Visible = False

            Me.dgvMATEUSUA.Columns("MUMUMACA").Width = 30
            Me.dgvMATEUSUA.Columns("MACADESC").Width = 100
            Me.dgvMATEUSUA.Columns("MUMUFECH").Width = 100

            '==================================================
            '*** ASIGNA LOS PRIVILEGIOS DE LA BARRA DE MENU ***
            '==================================================

            Dim ContarRegistros As Integer = Me.BindingSource_MATEUSUA_1.Count

            Dim boCONTAGRE As Boolean = False
            Dim boCONTMODI As Boolean = False
            Dim boCONTELIM As Boolean = False
            Dim boCONTCONS As Boolean = False
            Dim boCONTRECO As Boolean = False

            If Me.BindingSource_INFOUSUA_1.Count > 0 Then
                'pro_Permiso_Barra_De_Menu_Formulario_Formulario(ContarRegistros, Trim(Me.Name), boCONTAGRE, boCONTMODI, boCONTELIM, boCONTCONS, boCONTRECO)
                pro_Permiso_Barra_De_Menu_Formulario_SubFormulario(ContarRegistros, Trim(Me.BindingNavigator_MUTAMAEN_1.Name), boCONTAGRE, boCONTMODI, boCONTELIM, boCONTCONS, boCONTRECO)
            End If

            Me.cmdAGREGAR_MATEUSUA.Enabled = boCONTAGRE
            Me.cmdMODIFICAR_MATEUSUA.Enabled = boCONTMODI
            Me.cmdELIMINAR_MATEUSUA.Enabled = boCONTELIM
            Me.cmdCONSULTAR_MATEUSUA.Enabled = boCONTCONS
            Me.cmdRECONSULTAR_MATEUSUA.Enabled = boCONTRECO


        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try
    End Sub
    Private Sub pro_ListaDeValoresMaterialDeUsuario()

        Try
            If Me.dgvMATEUSUA.RowCount > 0 Then

                Dim objdatos As New cla_MUTAMAUS
                Dim tbl As New DataTable

                tbl = objdatos.fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_MUTAMAUS(Me.dgvMUTACIONES.SelectedRows.Item(0).Cells("MUTASECU").Value.ToString)

                If tbl.Rows.Count > 0 Then
                    Me.txtMAUSOBSE.Text = Trim(tbl.Rows(0).Item("MUMUOBSE"))
                Else
                    Me.txtMAUSOBSE.Text = ""
                End If

            Else
                pro_LimpiarMaterialUsuario()

            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub pro_LimpiarMaterialUsuario()

        Me.txtMAUSOBSE.Text = ""

        'Me.dgvMATEUSUA.DataSource = New DataTable

    End Sub

#End Region

#Region "PROCEDIMIENTOS METERIAL FALTANTE"

    Private Sub pro_ReconsultarMaterialDeFaltante()

        Try
            Dim objdatos As New cla_MUTAMAFA

            If boCONSULTA = False Then
                Me.BindingSource_MATEFALT_1.DataSource = objdatos.fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_MUTAMAFA(Me.dgvMUTACIONES.SelectedRows.Item(0).Cells("MUTASECU").Value.ToString)
            Else
                Me.BindingSource_MATEFALT_1.DataSource = objdatos.fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_MUTAMAFA(Me.dgvMUTACIONES.SelectedRows.Item(0).Cells("MUTASECU").Value.ToString)
            End If

            Me.dgvMATEFALT.DataSource = Me.BindingSource_MATEFALT_1
            Me.BindingNavigator_MUTAMAFA_1.BindingSource = Me.BindingSource_MATEFALT_1

            '==================================================
            '*** CONFIGURA OBJETOS DEL FORMULARIO MAESTRO ***
            '==================================================

            Me.dgvMATEFALT.Columns("MUMFIDRE").HeaderText = "idre"
            Me.dgvMATEFALT.Columns("MUMFSECU").HeaderText = "Secuencia"

            Me.dgvMATEFALT.Columns("MUMFMACA").HeaderText = "Código"
            Me.dgvMATEFALT.Columns("MACADESC").HeaderText = "Descripción"
            Me.dgvMATEFALT.Columns("MUMFFECH").HeaderText = "Fecha"
            Me.dgvMATEFALT.Columns("MUMFOBSE").HeaderText = "Observación"

            Me.dgvMATEFALT.Columns("MUMFIDRE").Visible = False
            Me.dgvMATEFALT.Columns("MUMFSECU").Visible = False
            Me.dgvMATEFALT.Columns("MUMFOBSE").Visible = False

            Me.dgvMATEFALT.Columns("MUMFMACA").Width = 30
            Me.dgvMATEFALT.Columns("MACADESC").Width = 100
            Me.dgvMATEFALT.Columns("MUMFFECH").Width = 100

            '==================================================
            '*** ASIGNA LOS PRIVILEGIOS DE LA BARRA DE MENU ***
            '==================================================

            Dim ContarRegistros As Integer = Me.BindingSource_MATEFALT_1.Count

            Dim boCONTAGRE As Boolean = False
            Dim boCONTMODI As Boolean = False
            Dim boCONTELIM As Boolean = False
            Dim boCONTCONS As Boolean = False
            Dim boCONTRECO As Boolean = False

            'pro_Permiso_Barra_De_Menu_Formulario_Formulario(ContarRegistros, Trim(Me.Name), boCONTAGRE, boCONTMODI, boCONTELIM, boCONTCONS, boCONTRECO)
            pro_Permiso_Barra_De_Menu_Formulario_SubFormulario(ContarRegistros, Trim(Me.BindingNavigator_MUTAMAFA_1.Name), boCONTAGRE, boCONTMODI, boCONTELIM, boCONTCONS, boCONTRECO)

            Me.cmdAGREGAR_MATEFALT.Enabled = boCONTAGRE
            Me.cmdMODIFICAR_MATEFALT.Enabled = boCONTMODI
            Me.cmdELIMINAR_MATEFALT.Enabled = boCONTELIM
            Me.cmdCONSULTAR_MATEFALT.Enabled = boCONTCONS
            Me.cmdRECONSULTAR_MATEFALT.Enabled = boCONTRECO

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try
    End Sub
    Private Sub pro_ListaDeValoresMaterialDeFaltante()

        Try
            If Me.dgvMATEFALT.RowCount > 0 Then

                Dim objdatos As New cla_MUTAMAFA
                Dim tbl As New DataTable

                tbl = objdatos.fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_MUTAMAFA(Me.dgvMUTACIONES.SelectedRows.Item(0).Cells("MUTASECU").Value.ToString)

                If tbl.Rows.Count > 0 Then
                    Me.txtMAFAOBSE.Text = Trim(tbl.Rows(0).Item("MUMFOBSE"))
                Else
                    Me.txtMAFAOBSE.Text = ""
                End If

                Me.chkMaterialFaltante.Checked = True

            Else
                pro_LimpiarMaterialFaltante()

                Me.chkMaterialFaltante.Checked = False
            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub pro_LimpiarMaterialFaltante()

        Me.txtMAFAOBSE.Text = ""

        'Me.dgvMATEFALT.DataSource = New DataTable

    End Sub

#End Region

#Region "PROCEDIMIENTOS MUTACION MUNICIPIO"

    Private Sub pro_ReconsultarLevantamiento()

        Try
            Dim objdatos As New cla_MUTAMUNI

            If boCONSULTA = False Then
                Me.BindingSource_MUNICIPIO_1.DataSource = objdatos.fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_MUTAMUNI(Me.dgvMUTACIONES.SelectedRows.Item(0).Cells("MUTASECU").Value.ToString)
            Else
                Me.BindingSource_MUNICIPIO_1.DataSource = objdatos.fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_MUTAMUNI(Me.dgvMUTACIONES.SelectedRows.Item(0).Cells("MUTASECU").Value.ToString)
            End If

            Me.dgvMUNICIPIO.DataSource = Me.BindingSource_MUNICIPIO_1
            Me.BindingNavigator_MUTAMUNI_1.BindingSource = Me.BindingSource_MUNICIPIO_1

            '==================================================
            '*** CONFIGURA OBJETOS DEL FORMULARIO MAESTRO ***
            '==================================================

            Me.dgvMUNICIPIO.Columns("MUMUIDRE").HeaderText = "idre"
            Me.dgvMUNICIPIO.Columns("MUMUSECU").HeaderText = "Secuencia"

            Me.dgvMUNICIPIO.Columns("MUMUNUDO").HeaderText = "Nro. Documento"
            Me.dgvMUNICIPIO.Columns("USUANOMB").HeaderText = "Nombre(s)"
            Me.dgvMUNICIPIO.Columns("USUAPRAP").HeaderText = "Primer apellido"
            Me.dgvMUNICIPIO.Columns("USUASEAP").HeaderText = "Segundo apellido"
            Me.dgvMUNICIPIO.Columns("MUMUFEEN").HeaderText = "Fecha de entrega"
            Me.dgvMUNICIPIO.Columns("MUMUOBSE").HeaderText = "Observación"

            Me.dgvMUNICIPIO.Columns("MUMUIDRE").Visible = False
            Me.dgvMUNICIPIO.Columns("MUMUSECU").Visible = False

            Me.dgvMUNICIPIO.Columns("MUMUNUDO").Width = 50
            Me.dgvMUNICIPIO.Columns("USUANOMB").Width = 50
            Me.dgvMUNICIPIO.Columns("USUAPRAP").Width = 50
            Me.dgvMUNICIPIO.Columns("USUASEAP").Width = 50
            Me.dgvMUNICIPIO.Columns("MUMUFEEN").Width = 50
            Me.dgvMUNICIPIO.Columns("MUMUOBSE").Width = 200

            '==================================================
            '*** ASIGNA LOS PRIVILEGIOS DE LA BARRA DE MENU ***
            '==================================================

            Dim ContarRegistros As Integer = Me.BindingSource_MUNICIPIO_1.Count

            Dim boCONTAGRE As Boolean = False
            Dim boCONTMODI As Boolean = False
            Dim boCONTELIM As Boolean = False
            Dim boCONTCONS As Boolean = False
            Dim boCONTRECO As Boolean = False

            'pro_Permiso_Barra_De_Menu_Formulario_Formulario(ContarRegistros, Trim(Me.Name), boCONTAGRE, boCONTMODI, boCONTELIM, boCONTCONS, boCONTRECO)
            pro_Permiso_Barra_De_Menu_Formulario_SubFormulario(ContarRegistros, Trim(Me.BindingNavigator_MUTAMUNI_1.Name), boCONTAGRE, boCONTMODI, boCONTELIM, boCONTCONS, boCONTRECO)

            Me.cmdAGREGAR_MUNICIPIO.Enabled = boCONTAGRE
            Me.cmdMODIFICAR_MUNICIPIO.Enabled = boCONTMODI
            Me.cmdELIMINAR_MUNICIPIO.Enabled = boCONTELIM
            Me.cmdCONSULTAR_MUNICIPIO.Enabled = boCONTCONS
            Me.cmdRECONSULTAR_MUNICIPIO.Enabled = boCONTRECO

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try
    End Sub
    Private Sub pro_ListaDeValoresLevantamiento()

        Try
            If Me.dgvMUNICIPIO.RowCount = 0 Then

                pro_LimpiarLevantamiento()

            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub pro_LimpiarLevantamiento()

        'Me.dgvMUNICIPIO.DataSource = New DataTable

    End Sub

#End Region

#Region "PROCEDIMIENTOS MUTACION DEPARTAMENTO"

    Private Sub pro_ReconsultarDigitacion()

        Try
            Dim objdatos As New cla_MUTADEPA

            If boCONSULTA = False Then
                Me.BindingSource_DEPARTAMENTO_1.DataSource = objdatos.fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_MUTADEPA(Me.dgvMUTACIONES.SelectedRows.Item(0).Cells("MUTASECU").Value.ToString)
            Else
                Me.BindingSource_DEPARTAMENTO_1.DataSource = objdatos.fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_MUTADEPA(Me.dgvMUTACIONES.SelectedRows.Item(0).Cells("MUTASECU").Value.ToString)
            End If

            Me.dgvDEPARTAMENTO.DataSource = Me.BindingSource_DEPARTAMENTO_1
            Me.BindingNavigator_MUTADEPA_1.BindingSource = Me.BindingSource_DEPARTAMENTO_1

            '==================================================
            '*** CONFIGURA OBJETOS DEL FORMULARIO MAESTRO ***
            '==================================================

            Me.dgvDEPARTAMENTO.Columns("MUDEIDRE").HeaderText = "idre"
            Me.dgvDEPARTAMENTO.Columns("MUDESECU").HeaderText = "Secuencia"

            Me.dgvDEPARTAMENTO.Columns("MUDENUDO").HeaderText = "Nro. Documento"
            Me.dgvDEPARTAMENTO.Columns("USUANOMB").HeaderText = "Nombre(s)"
            Me.dgvDEPARTAMENTO.Columns("USUAPRAP").HeaderText = "Primer apellido"
            Me.dgvDEPARTAMENTO.Columns("USUASEAP").HeaderText = "Segundo apellido"
            Me.dgvDEPARTAMENTO.Columns("MUDEFEEN").HeaderText = "Fecha de entrega"
            Me.dgvDEPARTAMENTO.Columns("MUDEOBSE").HeaderText = "Observación"

            Me.dgvDEPARTAMENTO.Columns("MUDEIDRE").Visible = False
            Me.dgvDEPARTAMENTO.Columns("MUDESECU").Visible = False

            Me.dgvDEPARTAMENTO.Columns("MUDENUDO").Width = 50
            Me.dgvDEPARTAMENTO.Columns("USUANOMB").Width = 50
            Me.dgvDEPARTAMENTO.Columns("USUAPRAP").Width = 50
            Me.dgvDEPARTAMENTO.Columns("USUASEAP").Width = 50
            Me.dgvDEPARTAMENTO.Columns("MUDEFEEN").Width = 50
            Me.dgvDEPARTAMENTO.Columns("MUDEOBSE").Width = 200

            '==================================================
            '*** ASIGNA LOS PRIVILEGIOS DE LA BARRA DE MENU ***
            '==================================================

            Dim ContarRegistros As Integer = Me.BindingSource_DEPARTAMENTO_1.Count

            Dim boCONTAGRE As Boolean = False
            Dim boCONTMODI As Boolean = False
            Dim boCONTELIM As Boolean = False
            Dim boCONTCONS As Boolean = False
            Dim boCONTRECO As Boolean = False

            'pro_Permiso_Barra_De_Menu_Formulario_Formulario(ContarRegistros, Trim(Me.Name), boCONTAGRE, boCONTMODI, boCONTELIM, boCONTCONS, boCONTRECO)
            pro_Permiso_Barra_De_Menu_Formulario_SubFormulario(ContarRegistros, Trim(Me.BindingNavigator_MUTADEPA_1.Name), boCONTAGRE, boCONTMODI, boCONTELIM, boCONTCONS, boCONTRECO)

            Me.cmdAGREGAR_DEPARTAMENTO.Enabled = boCONTAGRE
            Me.cmdMODIFICAR_DEPARTAMENTO.Enabled = boCONTMODI
            Me.cmdELIMINAR_DEPARTAMENTO.Enabled = boCONTELIM
            Me.cmdCONSULTAR_DEPARTAMENTO.Enabled = boCONTCONS
            Me.cmdRECONSULTAR_DEPARTAMENTO.Enabled = boCONTRECO

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try
    End Sub
    Private Sub pro_ListaDeValoresDigitacion()

        Try
            If Me.dgvDEPARTAMENTO.RowCount = 0 Then

                pro_LimpiarDigitacion()

            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub pro_LimpiarDigitacion()

        'Me.dgvDEPARTAMENTO.DataSource = New DataTable

    End Sub

#End Region

#Region "PROCEDIMIENTOS ARCHIVO"

    Private Sub pro_ReconsultarArchivo()

        Try
            Dim objdatos As New cla_MUTAARCH

            If boCONSULTA = False Then
                Me.BindingSource_ARCHIVO_1.DataSource = objdatos.fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_MUTAARCH(Me.dgvMUTACIONES.SelectedRows.Item(0).Cells("MUTASECU").Value.ToString)
            Else
                Me.BindingSource_ARCHIVO_1.DataSource = objdatos.fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_MUTAARCH(Me.dgvMUTACIONES.SelectedRows.Item(0).Cells("MUTASECU").Value.ToString)
            End If

            Me.dgvARCHIVO.DataSource = Me.BindingSource_ARCHIVO_1
            Me.BindingNavigator_MUTAARCH_1.BindingSource = Me.BindingSource_ARCHIVO_1

            '==================================================
            '*** CONFIGURA OBJETOS DEL FORMULARIO MAESTRO ***
            '==================================================

            Me.dgvARCHIVO.Columns("MUARIDRE").HeaderText = "idre"
            Me.dgvARCHIVO.Columns("MUARSECU").HeaderText = "Secuencia"

            Me.dgvARCHIVO.Columns("MUARNUDO").HeaderText = "Nro. Documento"
            Me.dgvARCHIVO.Columns("USUANOMB").HeaderText = "Nombre(s)"
            Me.dgvARCHIVO.Columns("USUAPRAP").HeaderText = "Primer apellido"
            Me.dgvARCHIVO.Columns("USUASEAP").HeaderText = "Segundo apellido"
            Me.dgvARCHIVO.Columns("MUARFEEN").HeaderText = "Fecha de entrega"
            Me.dgvARCHIVO.Columns("MUAROBSE").HeaderText = "Observación"

            Me.dgvARCHIVO.Columns("MUARIDRE").Visible = False
            Me.dgvARCHIVO.Columns("MUARSECU").Visible = False

            Me.dgvARCHIVO.Columns("MUARNUDO").Width = 50
            Me.dgvARCHIVO.Columns("USUANOMB").Width = 50
            Me.dgvARCHIVO.Columns("USUAPRAP").Width = 50
            Me.dgvARCHIVO.Columns("USUASEAP").Width = 50
            Me.dgvARCHIVO.Columns("MUARFEEN").Width = 50
            Me.dgvARCHIVO.Columns("MUAROBSE").Width = 200

            '==================================================
            '*** ASIGNA LOS PRIVILEGIOS DE LA BARRA DE MENU ***
            '==================================================

            Dim ContarRegistros As Integer = Me.BindingSource_ARCHIVO_1.Count

            Dim boCONTAGRE As Boolean = False
            Dim boCONTMODI As Boolean = False
            Dim boCONTELIM As Boolean = False
            Dim boCONTCONS As Boolean = False
            Dim boCONTRECO As Boolean = False

            'pro_Permiso_Barra_De_Menu_Formulario_Formulario(ContarRegistros, Trim(Me.Name), boCONTAGRE, boCONTMODI, boCONTELIM, boCONTCONS, boCONTRECO)
            pro_Permiso_Barra_De_Menu_Formulario_SubFormulario(ContarRegistros, Trim(Me.BindingNavigator_MUTAARCH_1.Name), boCONTAGRE, boCONTMODI, boCONTELIM, boCONTCONS, boCONTRECO)

            Me.cmdAGREGAR_ARCHIVO.Enabled = boCONTAGRE
            Me.cmdMODIFICAR_ARCHIVO.Enabled = boCONTMODI
            Me.cmdELIMINAR_ARCHIVO.Enabled = boCONTELIM
            Me.cmdCONSULTAR_ARCHIVO.Enabled = boCONTCONS
            Me.cmdRECONSULTAR_ARCHIVO.Enabled = boCONTRECO

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try
    End Sub
    Private Sub pro_ListaDeValoresArchivo()

        Try
            If Me.dgvARCHIVO.RowCount = 0 Then

                pro_LimpiarArchivo()

            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub pro_LimpiarArchivo()

        'Me.dgvARCHIVO.DataSource = New DataTable

    End Sub

#End Region

#Region "PROCEDIMIENTOS MATRICULAS ANEXAS"

    Private Sub pro_ReconsultarMatriculasAnexas()

        Try
            Dim objdatos As New cla_MUTAMATR

            If boCONSULTA = False Then
                Me.BindingSource_MUTAMATR_1.DataSource = objdatos.fun_Buscar_SECU_X_CONSULTA_PARAMETRIZADA_MUTAMATR(Me.dgvMUTACIONES.SelectedRows.Item(0).Cells("MUTASECU").Value.ToString)
            Else
                Me.BindingSource_MUTAMATR_1.DataSource = objdatos.fun_Buscar_SECU_X_CONSULTA_PARAMETRIZADA_MUTAMATR(Me.dgvMUTACIONES.SelectedRows.Item(0).Cells("MUTASECU").Value.ToString)
            End If

            Me.dgvMUTAMATR.DataSource = Me.BindingSource_MUTAMATR_1
            Me.BindingNavigator_MUTAMATR_1.BindingSource = Me.BindingSource_MUTAMATR_1

            '==================================================
            '*** CONFIGURA OBJETOS DEL FORMULARIO MAESTRO ***
            '==================================================

            Me.dgvMUTAMATR.Columns("MUMAIDRE").HeaderText = "idre"
            Me.dgvMUTAMATR.Columns("MUMASECU").HeaderText = "Secuencia"

            Me.dgvMUTAMATR.Columns("MUMANUFI").HeaderText = "Nro. Ficha Predial"
            Me.dgvMUTAMATR.Columns("MUMAMAIN").HeaderText = "Matricula Inmobiliaria"
            Me.dgvMUTAMATR.Columns("MUMAVACO").HeaderText = "Valor Compra Escritura"

            Me.dgvMUTAMATR.Columns("MUMAIDRE").Visible = False
            Me.dgvMUTAMATR.Columns("MUMASECU").Visible = False

            Me.dgvMUTAMATR.Columns("MUMAVACO").DefaultCellStyle.Format = "c"

            '==================================================
            '*** ASIGNA LOS PRIVILEGIOS DE LA BARRA DE MENU ***
            '==================================================

            Dim ContarRegistros As Integer = Me.BindingSource_MUTAMATR_1.Count

            Dim boCONTAGRE As Boolean = False
            Dim boCONTMODI As Boolean = False
            Dim boCONTELIM As Boolean = False
            Dim boCONTCONS As Boolean = False
            Dim boCONTRECO As Boolean = False

            pro_Permiso_Barra_De_Menu_Formulario_SubFormulario(ContarRegistros, Trim(Me.BindingNavigator_MUTAMATR_1.Name), boCONTAGRE, boCONTMODI, boCONTELIM, boCONTCONS, boCONTRECO)

            Me.cmdAGREGAR_MUTAMATR.Enabled = boCONTAGRE
            Me.cmdMODIFICAR_MUTAMATR.Enabled = boCONTMODI
            Me.cmdELIMINAR_MUTAMATR.Enabled = boCONTELIM
            Me.cmdCONSULTAR_MUTAMATR.Enabled = boCONTCONS
            Me.cmdRECONSULTAR_MUTAMATR.Enabled = boCONTRECO

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub pro_ListaDeValoresMatriculasAnexas()

        Try
            If Me.dgvMUNICIPIO.RowCount = 0 Then

                pro_LimpiarMatriculasAnexas()

            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub pro_LimpiarMatriculasAnexas()

        'Me.dgvMUTAMATR.DataSource = New DataTable

    End Sub

#End Region

#Region "MENU MUTACIONES"

    Private Sub cmdAGREGAR_MUTACIONES_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAGREGAR_MUTACIONES.Click

        Try
            If Me.dgvMUTACIONES.RowCount > 0 Then
                Dim frm_insertar As New frm_insertar_MUTACIONES(Integer.Parse(Me.dgvMUTACIONES.SelectedRows.Item(0).Cells(0).Value.ToString()))
                frm_insertar.ShowDialog()
            Else
                frm_insertar_MUTACIONES.ShowDialog()
            End If

            If vp_inConsulta <> 0 Then
                boCONSULTA = True

                pro_ReconsultarMutaciones()
                pro_ListaDeValoresMutaciones()

                If MessageBox.Show("¿ Desea agregar el material aportado ?", "Mensaje ...", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then
                    Me.tabINSCFICHPRED.SelectTab(TabMATEREGI)
                    Me.cmdAGREGAR_MATEREGI.PerformClick()
                End If
            Else
                Me.tabINSCFICHPRED.SelectTab(TabMATEREGI)
            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub cmdMODIFICAR_MUTACIONES_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdMODIFICAR_MUTACIONES.Click

        Try
            Dim frm_modificar As New frm_modificar_MUTACIONES(Integer.Parse(Me.dgvMUTACIONES.SelectedRows.Item(0).Cells(0).Value.ToString()))
            frm_modificar.ShowDialog()

            If vp_inConsulta <> 0 Then
                boCONSULTA = True

                pro_ReconsultarMutaciones()
                pro_ListaDeValoresMutaciones()

            End If

            Me.tabINSCFICHPRED.SelectTab(TabMATEREGI)

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub cmdELIMINAR_MUTACIONES_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdELIMINAR_MUTACIONES.Click

        Try
            If MessageBox.Show("¿ Desea eliminar el registro seleccionado ? ", "Mensaje...", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then
                Dim objdatos As New cla_MUTACIONES

                If objdatos.fun_Eliminar_IDRE_MUTACIONES(Integer.Parse(Me.dgvMUTACIONES.SelectedRows.Item(0).Cells(0).Value.ToString())) Then

                    boCONSULTA = False
                    pro_LimpiarCamposMutaciones()
                    pro_ReconsultarMutaciones()
                    pro_ListaDeValoresMutaciones()
                Else
                    frm_INCO_eliminar_registro_padre_con_relación_de_registros_hijos.ShowDialog()
                End If

            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub cmdCONSULTAR_MUTACIONES_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCONSULTAR_MUTACIONES.Click

        Try
            vp_inConsulta = 0

            If Me.dgvMUTACIONES.RowCount > 0 Then
                Dim frm_consultar As New frm_consultar_MUTACIONES(Integer.Parse(Me.dgvMUTACIONES.SelectedRows.Item(0).Cells(0).Value.ToString()))
                frm_consultar.ShowDialog()
            Else
                Dim frm_consultar As New frm_consultar_MUTACIONES()
                frm_consultar.ShowDialog()
            End If

            If vp_inConsulta > 0 Then
                boCONSULTA = True
            Else
                boCONSULTA = False
            End If

            pro_ReconsultarMutaciones()
            pro_ListaDeValoresMutaciones()

            Me.tabINSCFICHPRED.SelectTab(TabMATEREGI)

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub cmdRECONSULTAR_MUTACIONES_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdRECONSULTAR_MUTACIONES.Click

        Try
            If Me.dgvMUTACIONES.RowCount > 0 Then
                boCONSULTA = True
            Else
                boCONSULTA = False
            End If

            pro_ReconsultarMutaciones()
            pro_ListaDeValoresMutaciones()

            pro_ListaDeValoresMaterialDeRegistro()

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub cmdIMPORTAR_DOCUMENTOS_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdIMPORTAR_DOCUMENTOS.Click

        Try
            If Me.dgvMUTACIONES.RowCount > 0 Then

                Dim frm_inserta_archivo As New frm_insertar_archivo_MUTACIONES(Me.dgvMUTACIONES.SelectedRows.Item(0).Cells("MUTANUFI").Value.ToString(), _
                                                                               Me.dgvMUTACIONES.SelectedRows.Item(0).Cells("MUTAMUNI").Value.ToString(), _
                                                                               Me.dgvMUTACIONES.SelectedRows.Item(0).Cells("MUTACORR").Value.ToString(), _
                                                                               Me.dgvMUTACIONES.SelectedRows.Item(0).Cells("MUTABARR").Value.ToString(), _
                                                                               Me.dgvMUTACIONES.SelectedRows.Item(0).Cells("MUTAMANZ").Value.ToString(), _
                                                                               Me.dgvMUTACIONES.SelectedRows.Item(0).Cells("MUTAPRED").Value.ToString(), _
                                                                               Me.dgvMUTACIONES.SelectedRows.Item(0).Cells("MUTAEDIF").Value.ToString(), _
                                                                               Me.dgvMUTACIONES.SelectedRows.Item(0).Cells("MUTAUNPR").Value.ToString(), _
                                                                               Me.dgvMUTACIONES.SelectedRows.Item(0).Cells("MUTACLSE").Value.ToString(), _
                                                                               Me.dgvMUTACIONES.SelectedRows.Item(0).Cells("MUTAVIGE").Value.ToString(), _
                                                                               Me.dgvMUTACIONES.SelectedRows.Item(0).Cells("MUTAESCR").Value.ToString())
                frm_inserta_archivo.ShowDialog()

                pro_ListadoArchivosDocumentos()

                Me.tabMaestro_2.SelectTab(TabDocumentos)
            Else
                mod_MENSAJE.No_Existe_Un_Registro_Seleccionado()
            End If

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

    Private Sub cmdOBSERVACIONES_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOBSERVACIONES.Click
        pro_EjecutarBotonObservaciones()
    End Sub
    Private Sub cmdFINALIZAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdFinalizar.Click
        pro_EjecutarBotonFinalizar()
    End Sub

    Private Sub ToolStripButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton1.Click

        Try
            pro_ListaDeValoresMutaciones()

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub ToolStripButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton2.Click

        Try
            pro_ListaDeValoresMutaciones()

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub ToolStripButton3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton3.Click

        Try
            pro_ListaDeValoresMutaciones()

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub ToolStripButton4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton4.Click

        Try
            pro_ListaDeValoresMutaciones()

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub

#End Region

#Region "MENU MATERIAL REGISTRO"

    Private Sub cmdAGREGAR_MATEREGI_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAGREGAR_MATEREGI.Click

        Try
            Dim frm_modificar As New frm_insertar_MUTAMARE(Integer.Parse(Me.dgvMUTACIONES.SelectedRows.Item(0).Cells("MUTASECU").Value.ToString()), Me.Name)
            frm_modificar.ShowDialog()
            boCONSULTA = False

            pro_ReconsultarMaterialDeRegistro()
            pro_ListaDeValoresMaterialDeRegistro()

            pro_ReconsultarMaterialDeFaltante()
            pro_ListaDeValoresMaterialDeFaltante()

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub cmdMODIFICAR_MATEREGI_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdMODIFICAR_MATEREGI.Click

        Try
            Dim frm_modificar As New frm_insertar_MUTAMARE(Integer.Parse(Me.dgvMUTACIONES.SelectedRows.Item(0).Cells("MUTASECU").Value.ToString()), Me.Name)
            frm_modificar.ShowDialog()
            boCONSULTA = False

            pro_ReconsultarMaterialDeRegistro()
            pro_ListaDeValoresMaterialDeRegistro()

            pro_ReconsultarMaterialDeFaltante()
            pro_ListaDeValoresMaterialDeFaltante()

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub cmdELIMINAR_MATEREGI_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdELIMINAR_MATEREGI.Click

        Try
            If MessageBox.Show("¿ Desea eliminar el registro seleccionado ? ", "Mensaje...", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then
                Dim objdatos As New cla_MUTAMARE

                If objdatos.fun_Eliminar_SECU_X_MACA_MUTAMARE(Integer.Parse(Me.dgvMATEREGI.SelectedRows.Item(0).Cells("MUMRSECU").Value.ToString()), _
                                                              Integer.Parse(Me.dgvMATEREGI.SelectedRows.Item(0).Cells("MUMRMACA").Value.ToString())) Then
                    boCONSULTA = False

                    pro_LimpiarMaterialRegistro()
                    pro_ReconsultarMaterialDeRegistro()
                    pro_ListaDeValoresMaterialDeRegistro()
                Else
                    frm_INCO_eliminar_registro_padre_con_relación_de_registros_hijos.ShowDialog()
                End If

            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub cmdCONSULTAR_MATEREGI_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCONSULTAR_MATEREGI.Click

        Try
            vp_inConsulta = 0

            frm_consultar_MUTACIONES.ShowDialog()

            If vp_inConsulta > 0 Then
                boCONSULTA = True
            Else
                boCONSULTA = False
            End If

            pro_ReconsultarMutaciones()
            pro_ListaDeValoresMutaciones()

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub cmdRECONSULTAR_MATEREGI_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdRECONSULTAR_MATEREGI.Click

        Try
            boCONSULTA = False
            pro_ReconsultarMutaciones()
            pro_ListaDeValoresMutaciones()

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub

    Private Sub ToolStripButton10_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton10.Click

        Try
            pro_ListaDeValoresMutaciones()

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub ToolStripButton11_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton11.Click

        Try
            pro_ListaDeValoresMutaciones()

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub ToolStripButton12_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton12.Click

        Try
            pro_ListaDeValoresMutaciones()

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub ToolStripButton13_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton13.Click

        Try
            pro_ListaDeValoresMutaciones()

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub

#End Region

#Region "MENU INFORMACION DE USUARIO"

    Private Sub cmdAGREGAR_INFOUSUA_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAGREGAR_INFOUSUA.Click

        Try
            Dim frm_modificar As New frm_insertar_MUTAINUS(Integer.Parse(Me.dgvMUTACIONES.SelectedRows.Item(0).Cells("MUTASECU").Value.ToString()))
            frm_modificar.ShowDialog()
            boCONSULTA = False

            pro_ReconsultarInformacionDeUsuario()
            pro_ListaDeValoresInformacionDeUsuario()

            pro_ReconsultarMaterialDeUsuario()
            pro_ListaDeValoresMaterialDeUsuario()

            If MessageBox.Show("¿ Desea agregar el material aportado por el usuario ?", "Mensaje ...", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then
                Me.tabINSCFICHPRED.SelectTab(TabMATEUSUA)
                Me.cmdAGREGAR_MATEUSUA.PerformClick()
            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub cmdMODIFICAR_INFOUSUA_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdMODIFICAR_INFOUSUA.Click

        Try
            Dim frm_modificar As New frm_insertar_MUTAINUS(Integer.Parse(Me.dgvMUTACIONES.SelectedRows.Item(0).Cells("MUTASECU").Value.ToString()))
            frm_modificar.ShowDialog()
            boCONSULTA = False

            pro_ReconsultarInformacionDeUsuario()
            pro_ListaDeValoresInformacionDeUsuario()

            pro_ReconsultarMaterialDeUsuario()
            pro_ListaDeValoresMaterialDeUsuario()

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub cmdELIMINAR_INFOUSUA_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdELIMINAR_INFOUSUA.Click

        Try
            If MessageBox.Show("¿ Desea eliminar el registro seleccionado ? ", "Mensaje...", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then
                Dim objdatos As New cla_MUTAINUS

                If objdatos.fun_Eliminar_SECU_MUTAINUS(Integer.Parse(Me.dgvMUTACIONES.SelectedRows.Item(0).Cells("MUTASECU").Value.ToString())) Then
                    boCONSULTA = False

                    pro_LimpiarInformacionUsuario()
                    pro_ReconsultarInformacionDeUsuario()
                    pro_ListaDeValoresInformacionDeUsuario()

                    If Me.dgvMATEUSUA.RowCount > 0 Then

                        Dim objdatos1 As New cla_MUTAMAUS
                        objdatos1.fun_Eliminar_SECU_MUTAMAUS(Integer.Parse(Me.dgvMATEUSUA.SelectedRows.Item(0).Cells("MUMUSECU").Value.ToString()))

                    End If

                    pro_LimpiarMaterialUsuario()
                    pro_ReconsultarMaterialDeUsuario()
                    pro_ListaDeValoresMaterialDeUsuario()

                Else
                    frm_INCO_eliminar_registro_padre_con_relación_de_registros_hijos.ShowDialog()
                End If

            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub cmdCONSULTAR_INFOUSUA_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCONSULTAR_INFOUSUA.Click

        Try
            vp_inConsulta = 0

            frm_consultar_MUTACIONES.ShowDialog()

            If vp_inConsulta > 0 Then
                boCONSULTA = True
            Else
                boCONSULTA = False
            End If

            pro_ReconsultarMutaciones()
            pro_ListaDeValoresMutaciones()

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub cmdRECONSULTAR_INFOUSUA_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdRECONSULTAR_INFOUSUA.Click

        Try
            boCONSULTA = False
            pro_ReconsultarMutaciones()
            pro_ListaDeValoresMutaciones()

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub

    Private Sub ToolStripButton64_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton64.Click
        pro_ListaDeValoresInformacionDeUsuario()
    End Sub
    Private Sub ToolStripButton65_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton65.Click
        pro_ListaDeValoresInformacionDeUsuario()
    End Sub
    Private Sub ToolStripButton66_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton66.Click
        pro_ListaDeValoresInformacionDeUsuario()
    End Sub
    Private Sub ToolStripButton67_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton67.Click
        pro_ListaDeValoresInformacionDeUsuario()
    End Sub

#End Region

#Region "MENU MATERIAL USUARIO"

    Private Sub cmdAGREGAR_MATEUSUA_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAGREGAR_MATEUSUA.Click

        Try
            Dim frm_modificar As New frm_insertar_MUTAMAUS(Integer.Parse(Me.dgvMUTACIONES.SelectedRows.Item(0).Cells("MUTASECU").Value.ToString()), Me.Name)
            frm_modificar.ShowDialog()
            boCONSULTA = False

            pro_ReconsultarMaterialDeUsuario()
            pro_ListaDeValoresMaterialDeUsuario()

            pro_ReconsultarMaterialDeFaltante()
            pro_ListaDeValoresMaterialDeFaltante()

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub cmdMODIFICAR_MATEUSUA_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdMODIFICAR_MATEUSUA.Click

        Try
            Dim frm_modificar As New frm_insertar_MUTAMAUS(Integer.Parse(Me.dgvMUTACIONES.SelectedRows.Item(0).Cells("MUTASECU").Value.ToString()), Me.Name)
            frm_modificar.ShowDialog()
            boCONSULTA = False

            pro_ReconsultarMaterialDeUsuario()
            pro_ListaDeValoresMaterialDeUsuario()

            pro_ReconsultarMaterialDeFaltante()
            pro_ListaDeValoresMaterialDeFaltante()

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub cmdELIMINAR_MATEUSUA_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdELIMINAR_MATEUSUA.Click

        Try
            If MessageBox.Show("¿ Desea eliminar el registro seleccionado ? ", "Mensaje...", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then
                Dim objdatos As New cla_MUTAMAUS

                If objdatos.fun_Eliminar_SECU_X_MACA_MUTAMAUS(Integer.Parse(Me.dgvMATEUSUA.SelectedRows.Item(0).Cells("MUMUSECU").Value.ToString()), _
                                                              Integer.Parse(Me.dgvMATEUSUA.SelectedRows.Item(0).Cells("MUMUMACA").Value.ToString())) Then
                    boCONSULTA = False

                    pro_LimpiarMaterialUsuario()
                    pro_ReconsultarMaterialDeUsuario()
                    pro_ListaDeValoresMaterialDeUsuario()
                Else
                    frm_INCO_eliminar_registro_padre_con_relación_de_registros_hijos.ShowDialog()
                End If

            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub cmdCONSULTAR_MATEUSUA_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCONSULTAR_MATEUSUA.Click

        Try
            vp_inConsulta = 0

            frm_consultar_MUTACIONES.ShowDialog()

            If vp_inConsulta > 0 Then
                boCONSULTA = True
            Else
                boCONSULTA = False
            End If

            pro_ReconsultarMutaciones()
            pro_ListaDeValoresMutaciones()

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub cmdRECONSULTAR_MATEUSUA_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdRECONSULTAR_MATEUSUA.Click

        Try
            boCONSULTA = False
            pro_ReconsultarMutaciones()
            pro_ListaDeValoresMutaciones()

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub

    Private Sub ToolStripButton55_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton55.Click
        pro_ListaDeValoresMaterialDeUsuario()
    End Sub
    Private Sub ToolStripButton56_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton56.Click
        pro_ListaDeValoresMaterialDeUsuario()
    End Sub
    Private Sub ToolStripButton57_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton57.Click
        pro_ListaDeValoresMaterialDeUsuario()
    End Sub
    Private Sub ToolStripButton58_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton58.Click
        pro_ListaDeValoresMaterialDeUsuario()
    End Sub

#End Region

#Region "MENU MATERIAL FALTANTE"

    Private Sub cmdAGREGAR_MATEFALT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAGREGAR_MATEFALT.Click

        Try
            Dim frm_modificar As New frm_insertar_MUTAMAFA(Integer.Parse(Me.dgvMUTACIONES.SelectedRows.Item(0).Cells("MUTASECU").Value.ToString()), Me.Name)
            frm_modificar.ShowDialog()
            boCONSULTA = False

            pro_ReconsultarMaterialDeFaltante()
            pro_ListaDeValoresMaterialDeFaltante()

            pro_ReconsultarMaterialDeRegistro()
            pro_ListaDeValoresMaterialDeRegistro()

            pro_ReconsultarMaterialDeUsuario()
            pro_ListaDeValoresMaterialDeUsuario()


        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub cmdMODIFICAR_MATEFALT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdMODIFICAR_MATEFALT.Click

        Try
            Dim frm_modificar As New frm_insertar_MUTAMAFA(Integer.Parse(Me.dgvMUTACIONES.SelectedRows.Item(0).Cells("MUTASECU").Value.ToString()), Me.Name)
            frm_modificar.ShowDialog()
            boCONSULTA = False

            pro_ReconsultarMaterialDeFaltante()
            pro_ListaDeValoresMaterialDeFaltante()

            pro_ReconsultarMaterialDeRegistro()
            pro_ListaDeValoresMaterialDeRegistro()

            pro_ReconsultarMaterialDeUsuario()
            pro_ListaDeValoresMaterialDeUsuario()

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub cmdELIMINAR_MATEFALT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdELIMINAR_MATEFALT.Click

        Try
            If MessageBox.Show("¿ Desea eliminar el registro seleccionado ? ", "Mensaje...", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then
                Dim objdatos As New cla_MUTAMAFA

                If objdatos.fun_Eliminar_SECU_X_MACA_MUTAMAFA(Integer.Parse(Me.dgvMATEFALT.SelectedRows.Item(0).Cells("MUMFSECU").Value.ToString()), _
                                                              Integer.Parse(Me.dgvMATEFALT.SelectedRows.Item(0).Cells("MUMFMACA").Value.ToString())) Then
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
    Private Sub cmdCONSULTAR_MATEFALT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCONSULTAR_MATEFALT.Click

        Try
            vp_inConsulta = 0

            frm_consultar_MUTACIONES.ShowDialog()

            If vp_inConsulta > 0 Then
                boCONSULTA = True
            Else
                boCONSULTA = False
            End If

            pro_ReconsultarMutaciones()
            pro_ListaDeValoresMutaciones()

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub cmdRECONSULTAR_MATEFALT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdRECONSULTAR_MATEFALT.Click

        Try
            boCONSULTA = False
            pro_ReconsultarMutaciones()
            pro_ListaDeValoresMutaciones()

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

#Region "MENU MUTACION MUNICIPIO"

    Private Sub cmdAGREGAR_MUTAMUNI_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAGREGAR_MUNICIPIO.Click

        Try
            Dim frm_modificar As New frm_insertar_MUTAMUNI(Integer.Parse(Me.dgvMUTACIONES.SelectedRows.Item(0).Cells("MUTASECU").Value.ToString()))
            frm_modificar.ShowDialog()
            boCONSULTA = False

            pro_Mensaje01()

            pro_ReconsultarLevantamiento()
            pro_ListaDeValoresLevantamiento()
            pro_ListaDeValoresMutaciones()

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub cmdMODIFICAR_MUTAMUNI_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdMODIFICAR_MUNICIPIO.Click

        Try
            Dim frm_modificar As New frm_insertar_MUTAMUNI(Integer.Parse(Me.dgvMUNICIPIO.SelectedRows.Item(0).Cells("MUMUIDRE").Value.ToString()), _
                                                                Integer.Parse(Me.dgvMUNICIPIO.SelectedRows.Item(0).Cells("MUMUSECU").Value.ToString()), _
                                                                Me.dgvMUNICIPIO.SelectedRows.Item(0).Cells("MUMUNUDO").Value.ToString())
            frm_modificar.ShowDialog()
            boCONSULTA = False

            pro_Mensaje01()

            pro_ReconsultarLevantamiento()
            pro_ListaDeValoresLevantamiento()
            pro_ListaDeValoresMutaciones()

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub cmdELIMINAR_MUTAMUNI_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdELIMINAR_MUNICIPIO.Click

        Try
            If MessageBox.Show("¿ Desea eliminar el registro seleccionado ? ", "Mensaje...", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then
                Dim objdatos As New cla_MUTAMUNI

                If objdatos.fun_Eliminar_IDRE_MUTAMUNI(Integer.Parse(Me.dgvMUNICIPIO.SelectedRows.Item(0).Cells("MUMUIDRE").Value.ToString())) Then
                    boCONSULTA = False

                    pro_LimpiarLevantamiento()
                    pro_ReconsultarLevantamiento()
                    pro_ListaDeValoresLevantamiento()
                Else
                    frm_INCO_eliminar_registro_padre_con_relación_de_registros_hijos.ShowDialog()
                End If

            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub cmdCONSULTAR_MUTAMUNI_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCONSULTAR_MUNICIPIO.Click

        Try
            vp_inConsulta = 0

            frm_consultar_MUTACIONES.ShowDialog()

            If vp_inConsulta > 0 Then
                boCONSULTA = True
            Else
                boCONSULTA = False
            End If

            pro_ReconsultarMutaciones()
            pro_ListaDeValoresMutaciones()

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub cmdRECONSULTAR_MUTAMUNI_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdRECONSULTAR_MUNICIPIO.Click

        Try
            boCONSULTA = False
            pro_ReconsultarMutaciones()
            pro_ListaDeValoresMutaciones()

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub

    Private Sub ToolStripButton19_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton19.Click

        Try
            pro_ListaDeValoresLevantamiento()

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub ToolStripButton20_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton20.Click

        Try
            pro_ListaDeValoresLevantamiento()

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub ToolStripButton21_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton21.Click

        Try
            pro_ListaDeValoresLevantamiento()

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub ToolStripButton22_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton22.Click

        Try
            pro_ListaDeValoresLevantamiento()

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub

#End Region

#Region "MENU MUTACION DEPARTAMENTO"

    Private Sub cmdAGREGAR_MUTADEPA_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAGREGAR_DEPARTAMENTO.Click

        Try
            Dim frm_modificar As New frm_insertar_MUTADEPA(Integer.Parse(Me.dgvMUTACIONES.SelectedRows.Item(0).Cells("MUTASECU").Value.ToString()))
            frm_modificar.ShowDialog()
            boCONSULTA = False

            pro_Mensaje01()

            pro_ReconsultarDigitacion()
            pro_ListaDeValoresDigitacion()
            pro_ListaDeValoresMutaciones()

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub cmdMODIFICAR_MUTADEPA_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdMODIFICAR_DEPARTAMENTO.Click

        Try
            Dim frm_modificar As New frm_insertar_MUTADEPA(Integer.Parse(Me.dgvDEPARTAMENTO.SelectedRows.Item(0).Cells("MUDEIDRE").Value.ToString()), _
                                                                Integer.Parse(Me.dgvDEPARTAMENTO.SelectedRows.Item(0).Cells("MUDESECU").Value.ToString()), _
                                                                Me.dgvDEPARTAMENTO.SelectedRows.Item(0).Cells("MUDENUDO").Value.ToString())
            frm_modificar.ShowDialog()
            boCONSULTA = False

            pro_Mensaje01()

            pro_ReconsultarDigitacion()
            pro_ListaDeValoresDigitacion()
            pro_ListaDeValoresMutaciones()

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub cmdELIMINAR_MUTADEPA_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdELIMINAR_DEPARTAMENTO.Click

        Try
            If MessageBox.Show("¿ Desea eliminar el registro seleccionado ? ", "Mensaje...", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then
                Dim objdatos As New cla_MUTADEPA

                If objdatos.fun_Eliminar_IDRE_MUTADEPA(Integer.Parse(Me.dgvDEPARTAMENTO.SelectedRows.Item(0).Cells("MUDEIDRE").Value.ToString())) Then
                    boCONSULTA = False

                    pro_LimpiarDigitacion()
                    pro_ReconsultarDigitacion()
                    pro_ListaDeValoresDigitacion()
                Else
                    frm_INCO_eliminar_registro_padre_con_relación_de_registros_hijos.ShowDialog()
                End If

            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub cmdCONSULTAR_MUTADEPA_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCONSULTAR_DEPARTAMENTO.Click

        Try
            vp_inConsulta = 0

            frm_consultar_MUTACIONES.ShowDialog()

            If vp_inConsulta > 0 Then
                boCONSULTA = True
            Else
                boCONSULTA = False
            End If

            pro_ReconsultarMutaciones()
            pro_ListaDeValoresMutaciones()

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub cmdRECONSULTAR_MUTADEPA_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdRECONSULTAR_DEPARTAMENTO.Click

        Try
            boCONSULTA = False
            pro_ReconsultarMutaciones()
            pro_ListaDeValoresMutaciones()

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub

#End Region

#Region "MENU ARCHIVO"

    Private Sub cmdAGREGAR_MUTAARCH_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAGREGAR_ARCHIVO.Click

        Try
            Dim frm_modificar As New frm_insertar_MUTAARCH(Integer.Parse(Me.dgvMUTACIONES.SelectedRows.Item(0).Cells("MUTASECU").Value.ToString()))
            frm_modificar.ShowDialog()
            boCONSULTA = False

            pro_ReconsultarArchivo()
            pro_ListaDeValoresArchivo()
            pro_ListaDeValoresMutaciones()

            pro_Mensaje02()

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub cmdMODIFICAR_MUTAARCH_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdMODIFICAR_ARCHIVO.Click

        Try
            Dim frm_modificar As New frm_insertar_MUTAARCH(Integer.Parse(Me.dgvARCHIVO.SelectedRows.Item(0).Cells("MUARIDRE").Value.ToString()), _
                                                                Integer.Parse(Me.dgvARCHIVO.SelectedRows.Item(0).Cells("MUARSECU").Value.ToString()), _
                                                                Me.dgvARCHIVO.SelectedRows.Item(0).Cells("MUARNUDO").Value.ToString())
            frm_modificar.ShowDialog()
            boCONSULTA = False

            pro_ReconsultarArchivo()
            pro_ListaDeValoresArchivo()
            pro_ListaDeValoresMutaciones()

            pro_Mensaje02()

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub cmdELIMINAR_MUTAARCH_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdELIMINAR_ARCHIVO.Click

        Try
            If MessageBox.Show("¿ Desea eliminar el registro seleccionado ? ", "Mensaje...", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then
                Dim objdatos As New cla_MUTAARCH

                If objdatos.fun_Eliminar_IDRE_MUTAARCH(Integer.Parse(Me.dgvARCHIVO.SelectedRows.Item(0).Cells("MUARIDRE").Value.ToString())) Then
                    boCONSULTA = False

                    pro_LimpiarArchivo()
                    pro_ReconsultarArchivo()
                    pro_ListaDeValoresArchivo()
                Else
                    frm_INCO_eliminar_registro_padre_con_relación_de_registros_hijos.ShowDialog()
                End If

            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub cmdCONSULTAR_MUTAARCH_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCONSULTAR_ARCHIVO.Click

        Try
            vp_inConsulta = 0

            frm_consultar_MUTACIONES.ShowDialog()

            If vp_inConsulta > 0 Then
                boCONSULTA = True
            Else
                boCONSULTA = False
            End If

            pro_ReconsultarMutaciones()
            pro_ListaDeValoresMutaciones()

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub cmdRECONSULTAR_MUTAARCH_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdRECONSULTAR_ARCHIVO.Click

        Try
            boCONSULTA = False
            pro_ReconsultarMutaciones()
            pro_ListaDeValoresMutaciones()

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub

#End Region

#Region "MENU MATRICULAS ANEXAS"

    Private Sub cmdAGREGAR_MUTAMATR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAGREGAR_MUTAMATR.Click

        Try
            Dim frm_modificar As New frm_insertar_MUTAMATR(Integer.Parse(Me.dgvMUTACIONES.SelectedRows.Item(0).Cells("MUTASECU").Value.ToString()))
            frm_modificar.ShowDialog()
            boCONSULTA = False

            pro_ReconsultarMatriculasAnexas()
            pro_ListaDeValoresMatriculasAnexas()
            pro_ListaDeValoresMatriculasAnexas()

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub cmdMODIFICAR_MUTAMATR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdMODIFICAR_MUTAMATR.Click

        Try
            Dim frm_modificar As New frm_insertar_MUTAMATR(Integer.Parse(Me.dgvMUTAMATR.SelectedRows.Item(0).Cells("MUMAIDRE").Value.ToString()), _
                                                           Integer.Parse(Me.dgvMUTAMATR.SelectedRows.Item(0).Cells("MUMASECU").Value.ToString()), _
                                                           Integer.Parse(Me.dgvMUTAMATR.SelectedRows.Item(0).Cells("MUMANUFI").Value.ToString()), _
                                                           Integer.Parse(Me.dgvMUTAMATR.SelectedRows.Item(0).Cells("MUMAMAIN").Value.ToString()))

            frm_modificar.ShowDialog()
            boCONSULTA = False

            pro_ReconsultarMatriculasAnexas()
            pro_ListaDeValoresMatriculasAnexas()
            pro_ListaDeValoresMatriculasAnexas()

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub cmdELIMINAR_MUTAMATR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdELIMINAR_MUTAMATR.Click

        Try
            If MessageBox.Show("¿ Desea eliminar el registro seleccionado ? ", "Mensaje...", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then
                Dim objdatos As New cla_MUTAMATR

                If objdatos.fun_Eliminar_IDRE_MUTAMATR(Integer.Parse(Me.dgvMUTAMATR.SelectedRows.Item(0).Cells("MUMAIDRE").Value.ToString())) Then
                    boCONSULTA = False

                    pro_ReconsultarMatriculasAnexas()
                    pro_ListaDeValoresMatriculasAnexas()
                    pro_ListaDeValoresMatriculasAnexas()
                Else
                    frm_INCO_eliminar_registro_padre_con_relación_de_registros_hijos.ShowDialog()
                End If

            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub cmdCONSULTAR_MUTAMATR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCONSULTAR_MUTAMATR.Click

        Try
            vp_inConsulta = 0

            frm_consultar_MUTACIONES.ShowDialog()

            If vp_inConsulta > 0 Then
                boCONSULTA = True
            Else
                boCONSULTA = False
            End If

            pro_ReconsultarMutaciones()
            pro_ListaDeValoresMutaciones()

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub cmdRECONSULTAR_MUTAMATR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdRECONSULTAR_MUTAMATR.Click

        Try
            boCONSULTA = False
            pro_ReconsultarMutaciones()
            pro_ListaDeValoresMutaciones()

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub

#End Region

#Region "FORMULARIO"

#Region "Load"

    Private Sub frm_MUTACIONES_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        pro_ReconsultarMutaciones()
        Me.strBARRESTA.Items(0).Text = "Mutaciones"
    End Sub

#End Region

#Region "GotFocus"

    Private Sub frm_MUTACIONES_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.GotFocus
        pro_ListaDeValoresMutaciones()
        Me.tabMaestro_2.SelectTab(TabInformación)
    End Sub
    Private Sub dgvMUTACIONES_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvMUTACIONES.GotFocus
        Me.strBARRESTA.Items(0).Text = dgvMUTACIONES.AccessibleDescription
    End Sub

#End Region

#Region "KeyDown"

    Private Sub dgvMUTACIONES_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgvMUTACIONES.KeyDown
        '===============================================================================================
        '*** INSERTAR REGISTROS ***
        '===============================================================================================


        If e.KeyCode = Keys.F2 Then
            If Me.cmdAGREGAR_MUTACIONES.Enabled = True Then
                Me.cmdAGREGAR_MUTACIONES.PerformClick()
            Else
                mod_MENSAJE.Usuario_No_Tiene_Permiso_Para_Realizar_La_Operacion()
            End If
        End If

        '===============================================================================================
        'MODIFICAR REGISTROS
        '===============================================================================================

        If e.KeyCode = Keys.F3 Then
            If Me.cmdMODIFICAR_MUTACIONES.Enabled = True Then
                Me.cmdMODIFICAR_MUTACIONES.PerformClick()
            Else
                Dim ContarRegistros As Integer = Me.BindingSource_MUTACIONES_1.Count

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
            If Me.cmdELIMINAR_MUTACIONES.Enabled = True Then
                Me.cmdELIMINAR_MUTACIONES.PerformClick()
            Else
                Dim ContarRegistros As Integer = Me.BindingSource_MUTACIONES_1.Count

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
            If Me.cmdCONSULTAR_MUTACIONES.Enabled = True Then
                Me.cmdCONSULTAR_MUTACIONES.PerformClick()
            Else
                mod_MENSAJE.No_Existen_Registros_En_Base_De_Datos()
            End If
        End If

        '===============================================================================================
        '*** RECONSULTAR REGISTROS ***
        '===============================================================================================

        If e.KeyCode = Keys.F8 Then
            If Me.cmdCONSULTAR_MUTACIONES.Enabled = True Then
                Me.cmdRECONSULTAR_MUTACIONES.PerformClick()
            Else
                mod_MENSAJE.No_Existen_Registros_En_Base_De_Datos()
            End If
        End If

    End Sub

#End Region

#Region "KeyUp"

    Private Sub dgvALUMPUBL_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgvMUTACIONES.KeyUp
        If e.KeyCode = Keys.Down Or e.KeyCode = Keys.Up Or e.KeyCode = Keys.Enter Or e.KeyCode = Keys.PageUp Or e.KeyCode = Keys.PageDown Then
            pro_ListaDeValoresMutaciones()
        End If
    End Sub

#End Region

#Region "CellClick"

    Private Sub dgvALUMPUBL_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvMUTACIONES.CellClick
        pro_ListaDeValoresMutaciones()
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