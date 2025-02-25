Imports REGLAS_DEL_NEGOCIO
Imports System
Imports System.IO
Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration
Imports System.Text

Public Class frm_AJUSIMPR

    '==================================================
    '*** AJUSTE DE LIQUIDACIÓN DEL IMPUESTO PREDIAL ***
    '==================================================

#Region "VARIABLES"

    Dim boCONSULTA As Boolean = False

    Dim vl_stRutaDocumentosRectificaciones As String = ""
    Dim vl_stRutaDocumentosAjustesPredial As String = ""
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

    Public Shared Function instance() As frm_AJUSIMPR
        If frm_Instance Is Nothing OrElse frm_Instance.isdisposed = True Then
            frm_Instance = New frm_AJUSIMPR
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

    Private Function fun_VerificarCarpetaExistenteDocumentosRectificacion() As Boolean

        Try
            ' instancia la clase
            Dim obRECLAMOS As New cla_RECLAMOS
            Dim dtRECLAMOS As New DataTable

            dtRECLAMOS = obRECLAMOS.fun_Buscar_CEDULA_CATASTRAL_RECLAMOS(CStr(Trim(Me.dgvAJUSIMPR.SelectedRows.Item(0).Cells("AJIPMUNI").Value.ToString)), _
                                                                         CStr(Trim(Me.dgvAJUSIMPR.SelectedRows.Item(0).Cells("AJIPCORR").Value.ToString)), _
                                                                         CStr(Trim(Me.dgvAJUSIMPR.SelectedRows.Item(0).Cells("AJIPBARR").Value.ToString)), _
                                                                         CStr(Trim(Me.dgvAJUSIMPR.SelectedRows.Item(0).Cells("AJIPMANZ").Value.ToString)), _
                                                                         CStr(Trim(Me.dgvAJUSIMPR.SelectedRows.Item(0).Cells("AJIPPRED").Value.ToString)), _
                                                                         CStr(Trim(Me.dgvAJUSIMPR.SelectedRows.Item(0).Cells("AJIPEDIF").Value.ToString)), _
                                                                         CStr(Trim(Me.dgvAJUSIMPR.SelectedRows.Item(0).Cells("AJIPUNPR").Value.ToString)), _
                                                                         CInt(Me.dgvAJUSIMPR.SelectedRows.Item(0).Cells("AJIPCLSE").Value.ToString))


            If dtRECLAMOS.Rows.Count > 0 Then

                Dim stRECLSECU As String = Trim(dtRECLAMOS.Rows(0).Item("RECLSECU"))

                ' instancia la clase
                Dim obRECLACAD As New cla_RECLACAD
                Dim dtRECLACAD As New DataTable

                dtRECLACAD = obRECLACAD.fun_Buscar_CODIGO_X_RECLACAD(stRECLSECU)

                If dtRECLACAD.Rows.Count > 0 Then

                    Dim stREAANUEM As String = Trim(dtRECLACAD.Rows(0).Item("REAANUEM"))
                    Dim stREAAFEEM As String = Trim(dtRECLACAD.Rows(0).Item("REAAFEEM"))

                    Dim stRuta As String = ""
                    Dim stCarpetaABuscar As String = ""

                    ' instancia la clase
                    Dim objRutas As New cla_RUTAS
                    Dim tblRutas As New DataTable

                    tblRutas = objRutas.fun_Buscar_CODIGO_MANT_RUTAS(4)

                    If tblRutas.Rows.Count > 0 AndAlso Trim(stREAANUEM) <> "" AndAlso Trim(stREAAFEEM).ToString.Length = 10 Then

                        ' directorio pricipal
                        stRuta = Trim(tblRutas.Rows(0).Item("RUTARUTA")) & "\"

                        ' directorio expediente 
                        stCarpetaABuscar = fun_Formato_Mascara_3_String(Trim(stREAANUEM)) & "-" & fun_Formato_Mascara_4_String(Trim(stREAAFEEM.ToString.Substring(6, 4)))

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

                End If

            End If

        Catch ex As Exception
            Return False
        End Try

    End Function
    Private Function fun_VerificarCarpetaExistenteDocumentosAjustes() As Boolean

        Try
            Dim stRuta As String = ""
            Dim stCarpetaABuscar As String = ""

            ' instancia la clase
            Dim objRutas As New cla_RUTAS
            Dim tblRutas As New DataTable

            tblRutas = objRutas.fun_Buscar_CODIGO_MANT_RUTAS(11)

            If tblRutas.Rows.Count > 0 Then

                ' directorio pricipal
                stRuta = Trim(tblRutas.Rows(0).Item("RUTARUTA")) & "\"

                ' directorio expediente 
                stCarpetaABuscar = Trim(Me.dgvAJUSIMPR.SelectedRows.Item(0).Cells("AJIPMUNI").Value.ToString) & "-" & Trim(Me.dgvAJUSIMPR.SelectedRows.Item(0).Cells("AJIPCLSE").Value.ToString) & "-" & Trim(Me.dgvAJUSIMPR.SelectedRows.Item(0).Cells("AJIPCORR").Value.ToString) & "-" & Trim(Me.dgvAJUSIMPR.SelectedRows.Item(0).Cells("AJIPBARR").Value.ToString) & "-" & Trim(Me.dgvAJUSIMPR.SelectedRows.Item(0).Cells("AJIPMANZ").Value.ToString) & "-" & Trim(Me.dgvAJUSIMPR.SelectedRows.Item(0).Cells("AJIPPRED").Value.ToString) & "-" & Trim(Me.dgvAJUSIMPR.SelectedRows.Item(0).Cells("AJIPEDIF").Value.ToString) & "-" & Trim(Me.dgvAJUSIMPR.SelectedRows.Item(0).Cells("AJIPUNPR").Value.ToString) & "-" & Trim(Me.dgvAJUSIMPR.SelectedRows.Item(0).Cells("AJIPVIGE").Value.ToString)

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
    Private Function fun_VerificarCarpetaExistenteImagenes() As Boolean

        Try
            ' instancia la clase
            Dim obRECLAMOS As New cla_RECLAMOS
            Dim dtRECLAMOS As New DataTable

            dtRECLAMOS = obRECLAMOS.fun_Buscar_CEDULA_CATASTRAL_RECLAMOS(CStr(Trim(Me.dgvAJUSIMPR.SelectedRows.Item(0).Cells("AJIPMUNI").Value.ToString)), _
                                                                         CStr(Trim(Me.dgvAJUSIMPR.SelectedRows.Item(0).Cells("AJIPCORR").Value.ToString)), _
                                                                         CStr(Trim(Me.dgvAJUSIMPR.SelectedRows.Item(0).Cells("AJIPBARR").Value.ToString)), _
                                                                         CStr(Trim(Me.dgvAJUSIMPR.SelectedRows.Item(0).Cells("AJIPMANZ").Value.ToString)), _
                                                                         CStr(Trim(Me.dgvAJUSIMPR.SelectedRows.Item(0).Cells("AJIPPRED").Value.ToString)), _
                                                                         CStr(Trim(Me.dgvAJUSIMPR.SelectedRows.Item(0).Cells("AJIPEDIF").Value.ToString)), _
                                                                         CStr(Trim(Me.dgvAJUSIMPR.SelectedRows.Item(0).Cells("AJIPUNPR").Value.ToString)), _
                                                                         CInt(Me.dgvAJUSIMPR.SelectedRows.Item(0).Cells("AJIPCLSE").Value.ToString))


            If dtRECLAMOS.Rows.Count > 0 Then

                Dim stRECLSECU As String = Trim(dtRECLAMOS.Rows(0).Item("RECLSECU"))

                ' instancia la clase
                Dim obRECLACAD As New cla_RECLACAD
                Dim dtRECLACAD As New DataTable

                dtRECLACAD = obRECLACAD.fun_Buscar_CODIGO_X_RECLACAD(stRECLSECU)

                If dtRECLACAD.Rows.Count > 0 Then

                    Dim stREAANUEM As String = Trim(dtRECLACAD.Rows(0).Item("REAANUEM"))
                    Dim stREAAFEEM As String = Trim(dtRECLACAD.Rows(0).Item("REAAFEEM"))

                    Dim stRuta As String = ""
                    Dim stCarpetaABuscar As String = ""

                    ' instancia la clase
                    Dim objRutas As New cla_RUTAS
                    Dim tblRutas As New DataTable

                    tblRutas = objRutas.fun_Buscar_CODIGO_MANT_RUTAS(4)

                    If tblRutas.Rows.Count > 0 AndAlso Trim(stREAANUEM) <> "" AndAlso Trim(stREAAFEEM).ToString.Length = 10 Then

                        ' directorio pricipal
                        stRuta = Trim(tblRutas.Rows(0).Item("RUTARUTA")) & "\"

                        ' directorio expediente 
                        stCarpetaABuscar = fun_Formato_Mascara_3_String(Trim(stREAANUEM)) & "-" & fun_Formato_Mascara_4_String(Trim(stREAAFEEM.ToString.Substring(6, 4)))

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

                End If

            End If

        Catch ex As Exception
            Return False
        End Try

    End Function
    Private Function fun_VerificarCarpetaExistenteResolucion() As Boolean

        Try
            ' instancia la clase
            Dim obRECLAMOS As New cla_RECLAMOS
            Dim dtRECLAMOS As New DataTable

            dtRECLAMOS = obRECLAMOS.fun_Buscar_CEDULA_CATASTRAL_RECLAMOS(CStr(Trim(Me.dgvAJUSIMPR.SelectedRows.Item(0).Cells("AJIPMUNI").Value.ToString)), _
                                                                         CStr(Trim(Me.dgvAJUSIMPR.SelectedRows.Item(0).Cells("AJIPCORR").Value.ToString)), _
                                                                         CStr(Trim(Me.dgvAJUSIMPR.SelectedRows.Item(0).Cells("AJIPBARR").Value.ToString)), _
                                                                         CStr(Trim(Me.dgvAJUSIMPR.SelectedRows.Item(0).Cells("AJIPMANZ").Value.ToString)), _
                                                                         CStr(Trim(Me.dgvAJUSIMPR.SelectedRows.Item(0).Cells("AJIPPRED").Value.ToString)), _
                                                                         CStr(Trim(Me.dgvAJUSIMPR.SelectedRows.Item(0).Cells("AJIPEDIF").Value.ToString)), _
                                                                         CStr(Trim(Me.dgvAJUSIMPR.SelectedRows.Item(0).Cells("AJIPUNPR").Value.ToString)), _
                                                                         CInt(Me.dgvAJUSIMPR.SelectedRows.Item(0).Cells("AJIPCLSE").Value.ToString))


            If dtRECLAMOS.Rows.Count > 0 Then

                Dim stRECLSECU As String = Trim(dtRECLAMOS.Rows(0).Item("RECLSECU"))

                ' instancia la clase
                Dim obRECLACAD As New cla_RECLACAD
                Dim dtRECLACAD As New DataTable

                dtRECLACAD = obRECLACAD.fun_Buscar_CODIGO_X_RECLACAD(stRECLSECU)

                If dtRECLACAD.Rows.Count > 0 Then

                    Dim stREAANURA As String = Trim(dtRECLACAD.Rows(0).Item("REAANURA"))
                    Dim stREAAFERA As String = Trim(dtRECLACAD.Rows(0).Item("REAAFERA"))

                    Dim stRuta As String = ""
                    Dim stCarpetaABuscar As String = ""

                    ' instancia la clase
                    Dim objRutas As New cla_RUTAS
                    Dim tblRutas As New DataTable

                    tblRutas = objRutas.fun_Buscar_CODIGO_MANT_RUTAS(5)

                    If tblRutas.Rows.Count > 0 AndAlso Trim(stREAANURA) <> "" AndAlso Trim(stREAAFERA).ToString.Length = 10 Then

                        ' directorio pricipal
                        stRuta = Trim(tblRutas.Rows(0).Item("RUTARUTA")) & "\"

                        ' directorio expediente 
                        stCarpetaABuscar = Trim(stREAANURA) & "-" & fun_Formato_Mascara_4_String(Trim(stREAAFERA.ToString.Substring(6, 4)))

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

                End If

            End If

        Catch ex As Exception
            Return False
        End Try

    End Function

#End Region

#Region "PROCEDIMIENTOS AJUSTE PREDIAL"

    Private Sub pro_ReconsultarAjustes()

        Try
            Dim objdatos As New cla_AJUSIMPR

            If boCONSULTA = False Then
                Me.BindingSource_AJUSIMPR_1.DataSource = objdatos.fun_Consultar_AJUSIMPR

            ElseIf boCONSULTA = True And vp_inConsulta <> 0 Then
                Me.BindingSource_AJUSIMPR_1.DataSource = objdatos.fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_AJUSIMPR(vp_inConsulta)

            ElseIf boCONSULTA = True And vp_inConsulta = 0 Then

                Dim dtConsulta As New DataTable
                dtConsulta = objdatos.fun_Consultar_AJUSIMPR

                If dtConsulta.Rows.Count > 0 Then
                    vp_inConsulta = dtConsulta.Rows(0).Item("AJIPIDRE")
                    Me.BindingSource_AJUSIMPR_1.DataSource = objdatos.fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_AJUSIMPR(vp_inConsulta)

                End If

            End If

            Me.dgvAJUSIMPR.DataSource = BindingSource_AJUSIMPR_1

            Me.BindingNavigator_AJUSIMPR_1.BindingSource = BindingSource_AJUSIMPR_1

            '=================================================
            '*** CONFIGURA OBJETOS DEL FORMULARIO MAESTRO ***
            '=================================================

            Me.strBARRESTA.Items(2).Text = "Registros : " & Me.BindingSource_AJUSIMPR_1.Count

            Me.dgvAJUSIMPR.Columns("AJIPIDRE").HeaderText = "idre"

            Me.dgvAJUSIMPR.Columns("AJIPSECU").HeaderText = "Nro. Tramite"
            Me.dgvAJUSIMPR.Columns("AJIPDEPA").HeaderText = "Departamento"
            Me.dgvAJUSIMPR.Columns("AJIPMUNI").HeaderText = "Municipio"
            Me.dgvAJUSIMPR.Columns("AJIPCORR").HeaderText = "Correg."
            Me.dgvAJUSIMPR.Columns("AJIPBARR").HeaderText = "Barrio"
            Me.dgvAJUSIMPR.Columns("AJIPMANZ").HeaderText = "Manzana Vereda"
            Me.dgvAJUSIMPR.Columns("AJIPEDIF").HeaderText = "Edificio"
            Me.dgvAJUSIMPR.Columns("AJIPUNPR").HeaderText = "Unidad Predial"
            Me.dgvAJUSIMPR.Columns("AJIPPRED").HeaderText = "Predio"
            Me.dgvAJUSIMPR.Columns("AJIPCLSE").HeaderText = "Sector"
            Me.dgvAJUSIMPR.Columns("AJIPVIGE").HeaderText = "Vigencia"
            Me.dgvAJUSIMPR.Columns("ESTADESC").HeaderText = "Estado"

            Me.dgvAJUSIMPR.Columns("AJIPIDRE").Visible = False
            Me.dgvAJUSIMPR.Columns("AJIPNUFI").Visible = False

            Me.dgvAJUSIMPR.Columns("AJIPDEPA").Visible = False
            Me.dgvAJUSIMPR.Columns("AJIPMAIN").Visible = False
            Me.dgvAJUSIMPR.Columns("AJIPFECH").Visible = False
            Me.dgvAJUSIMPR.Columns("AJIPCLAS").Visible = False
            Me.dgvAJUSIMPR.Columns("AJIPTITR").Visible = False
            Me.dgvAJUSIMPR.Columns("AJIPMERE").Visible = False
            Me.dgvAJUSIMPR.Columns("AJIPREAJ").Visible = False
            Me.dgvAJUSIMPR.Columns("AJIPREMI").Visible = False
            Me.dgvAJUSIMPR.Columns("AJIPFECR").Visible = False
            Me.dgvAJUSIMPR.Columns("AJIPDEST").Visible = False
            Me.dgvAJUSIMPR.Columns("AJIPFECD").Visible = False
            Me.dgvAJUSIMPR.Columns("AJIPNUDO").Visible = False
            Me.dgvAJUSIMPR.Columns("AJIPUSUR").Visible = False
            Me.dgvAJUSIMPR.Columns("AJIPUSUD").Visible = False
            Me.dgvAJUSIMPR.Columns("AJIPNURA").Visible = False
            Me.dgvAJUSIMPR.Columns("AJIPFERA").Visible = False
            Me.dgvAJUSIMPR.Columns("AJIPNURE").Visible = False
            Me.dgvAJUSIMPR.Columns("AJIPFERE").Visible = False
            Me.dgvAJUSIMPR.Columns("AJIPNUOF").Visible = False
            Me.dgvAJUSIMPR.Columns("AJIPFEOF").Visible = False
            Me.dgvAJUSIMPR.Columns("AJIPOBSE").Visible = False
            Me.dgvAJUSIMPR.Columns("AJIPESTA").Visible = False
            Me.dgvAJUSIMPR.Columns("AJIPESTR").Visible = False

            '==================================================
            '*** ASIGNA LOS PRIVILEGIOS DE LA BARRA DE MENU ***
            '==================================================

            Dim ContarRegistros As Integer = Me.BindingSource_AJUSIMPR_1.Count

            Dim boCONTAGRE As Boolean = False
            Dim boCONTMODI As Boolean = False
            Dim boCONTELIM As Boolean = False
            Dim boCONTCONS As Boolean = False
            Dim boCONTRECO As Boolean = False

            pro_Permiso_Barra_De_Menu_Formulario_SubFormulario(ContarRegistros, Trim(Me.BindingNavigator_AJUSIMPR_1.Name), boCONTAGRE, boCONTMODI, boCONTELIM, boCONTCONS, boCONTRECO)

            Me.cmdAGREGAR_AJUSIMPR.Enabled = boCONTAGRE
            Me.cmdMODIFICAR_AJUSIMPR.Enabled = boCONTMODI
            Me.cmdELIMINAR_AJUSIMPR.Enabled = boCONTELIM
            Me.cmdCONSULTAR_AJUSIMPR.Enabled = boCONTCONS
            Me.cmdRECONSULTAR_AJUSIMPR.Enabled = boCONTRECO

            If boCONSULTA = False Then
                pro_ReconsultarAjustesRegistrados()
                pro_ReconsultarAjustesAsignados()
                pro_ReconsultarAjustesPendientes()
                pro_ReconsultarAjustesFinalizados()

            ElseIf boCONSULTA = True Then
                pro_ListaDeValoresAjustes()

                pro_ReconsultarAjustesRegistradosPorConsulta()
                pro_ReconsultarAjustesAsignadosPorConsulta()
                pro_ReconsultarAjustesPendientesPorConsulta()
                pro_ReconsultarAjustesFinalizadosPorConsulta()

                Me.tabINSCFICHPRED.SelectTab(TabAJIPINUS)

                If Me.dgvTRAMREGI.RowCount > 0 Then
                    Me.TabControl1.SelectTab(TabRegistrados)

                ElseIf Me.dgvTRAMASIG.RowCount > 0 Then
                    Me.TabControl1.SelectTab(TabAsignados)

                ElseIf Me.dgvTRAMPEND.RowCount > 0 Then
                    Me.TabControl1.SelectTab(TabPendientes)

                ElseIf Me.dgvTRAMFINA.RowCount > 0 Then
                    Me.TabControl1.SelectTab(TabFinalizados)
                End If
            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub

    Private Sub pro_ReconsultarAjustesRegistrados()

        Try
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
            ParametrosConsulta += "AJIPSECU, "
            ParametrosConsulta += "AJIPFECH, "
            ParametrosConsulta += "AJIPNUDO, "
            ParametrosConsulta += "AJIPFECR, "
            ParametrosConsulta += "AJIPREMI, "
            ParametrosConsulta += "AJIPUSUR, "

            ParametrosConsulta += "CONTUSUA, "
            ParametrosConsulta += "USUANOMB, "
            ParametrosConsulta += "USUAPRAP, "
            ParametrosConsulta += "USUASEAP, "
            ParametrosConsulta += "ESTADESC, "

            ParametrosConsulta += "AJIPIDRE, "
            ParametrosConsulta += "AJIPNUFI, "
            ParametrosConsulta += "AJIPDEPA, "
            ParametrosConsulta += "AJIPMUNI, "
            ParametrosConsulta += "AJIPCORR, "
            ParametrosConsulta += "AJIPBARR, "
            ParametrosConsulta += "AJIPMANZ, "
            ParametrosConsulta += "AJIPPRED, "
            ParametrosConsulta += "AJIPEDIF, "
            ParametrosConsulta += "AJIPUNPR, "
            ParametrosConsulta += "AJIPCLSE, "
            ParametrosConsulta += "AJIPVIGE, "
            ParametrosConsulta += "AJIPMAIN, "

            ParametrosConsulta += "AJIPCLAS, "
            ParametrosConsulta += "AJIPTITR, "
            ParametrosConsulta += "AJIPMERE, "
            ParametrosConsulta += "AJIPREAJ, "
            ParametrosConsulta += "AJIPDEST, "
            ParametrosConsulta += "AJIPFECD, "

            ParametrosConsulta += "AJIPNURA, "
            ParametrosConsulta += "AJIPFERA, "
            ParametrosConsulta += "AJIPNURE, "
            ParametrosConsulta += "AJIPFERE, "
            ParametrosConsulta += "AJIPNUOF, "
            ParametrosConsulta += "AJIPFEOF, "
            ParametrosConsulta += "AJIPOBSE, "
            ParametrosConsulta += "AJIPESTA, "
            ParametrosConsulta += "AJIPESTR "

            ParametrosConsulta += "FROM "
            ParametrosConsulta += "AJUSIMPR, USUARIO, ESTADO, CONTRASENA "

            ParametrosConsulta += "WHERE "
            ParametrosConsulta += "AJIPNUDO = CONTNUDO AND "
            ParametrosConsulta += "AJIPNUDO = USUANUDO AND "
            ParametrosConsulta += "AJIPESTR = ESTACODI AND "
            ParametrosConsulta += "AJIPNUDO = '" & CStr(Trim(vp_cedula)) & "' AND "
            ParametrosConsulta += "AJIPESTR = 'ac' "

            ParametrosConsulta += "ORDER BY "
            ParametrosConsulta += "AJIPSECU "

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

            If dt.Rows.Count > 0 Then

                Me.dgvTRAMREGI.DataSource = dt

                Me.dgvTRAMREGI.Columns("AJIPSECU").HeaderText = "Nro. Tramite"
                Me.dgvTRAMREGI.Columns("CONTUSUA").HeaderText = "Registrador"
                Me.dgvTRAMREGI.Columns("AJIPNUDO").HeaderText = "Nro. Documento"
                Me.dgvTRAMREGI.Columns("AJIPFECH").HeaderText = "Fecha de registro"
                Me.dgvTRAMREGI.Columns("USUANOMB").HeaderText = "Nombre"
                Me.dgvTRAMREGI.Columns("USUAPRAP").HeaderText = "Primer apellido"
                Me.dgvTRAMREGI.Columns("USUASEAP").HeaderText = "Segundo apellido"
                Me.dgvTRAMREGI.Columns("ESTADESC").HeaderText = "Estado"

                Me.dgvTRAMREGI.Columns("AJIPIDRE").Visible = False
                Me.dgvTRAMREGI.Columns("AJIPNUFI").Visible = False
                Me.dgvTRAMREGI.Columns("AJIPDEPA").Visible = False
                Me.dgvTRAMREGI.Columns("AJIPMUNI").Visible = False
                Me.dgvTRAMREGI.Columns("AJIPCORR").Visible = False
                Me.dgvTRAMREGI.Columns("AJIPBARR").Visible = False
                Me.dgvTRAMREGI.Columns("AJIPMANZ").Visible = False
                Me.dgvTRAMREGI.Columns("AJIPEDIF").Visible = False
                Me.dgvTRAMREGI.Columns("AJIPUNPR").Visible = False
                Me.dgvTRAMREGI.Columns("AJIPPRED").Visible = False
                Me.dgvTRAMREGI.Columns("AJIPCLSE").Visible = False
                Me.dgvTRAMREGI.Columns("AJIPVIGE").Visible = False
                Me.dgvTRAMREGI.Columns("AJIPDEPA").Visible = False
                Me.dgvTRAMREGI.Columns("AJIPMAIN").Visible = False
                Me.dgvTRAMREGI.Columns("AJIPCLAS").Visible = False
                Me.dgvTRAMREGI.Columns("AJIPTITR").Visible = False
                Me.dgvTRAMREGI.Columns("AJIPMERE").Visible = False
                Me.dgvTRAMREGI.Columns("AJIPREAJ").Visible = False
                Me.dgvTRAMREGI.Columns("AJIPDEST").Visible = False
                Me.dgvTRAMREGI.Columns("AJIPFECD").Visible = False
                Me.dgvTRAMREGI.Columns("AJIPFECR").Visible = False
                Me.dgvTRAMREGI.Columns("AJIPNURA").Visible = False
                Me.dgvTRAMREGI.Columns("AJIPFERA").Visible = False
                Me.dgvTRAMREGI.Columns("AJIPNURE").Visible = False
                Me.dgvTRAMREGI.Columns("AJIPFERE").Visible = False
                Me.dgvTRAMREGI.Columns("AJIPNUOF").Visible = False
                Me.dgvTRAMREGI.Columns("AJIPFEOF").Visible = False
                Me.dgvTRAMREGI.Columns("AJIPOBSE").Visible = False
                Me.dgvTRAMREGI.Columns("AJIPESTA").Visible = False
                Me.dgvTRAMREGI.Columns("AJIPESTR").Visible = False
                Me.dgvTRAMREGI.Columns("AJIPREMI").Visible = False
                Me.dgvTRAMREGI.Columns("AJIPUSUR").Visible = False

            Else
                Me.dgvTRAMREGI.DataSource = New DataTable
                Me.txtAJIPOBSE.Text = ""
                Me.lstLISTADO_DOCUMENTOS_RECLAMOS.Items.Clear()
                Me.lstLISTADO_IMAGENES.Items.Clear()
                Me.lstLISTADO_RESOLUCION.Items.Clear()
                Me.lstLISTADO_DOCUMENTOS_AJUSTES.Items.Clear()
            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub pro_ReconsultarAjustesAsignados()

        Try
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
            ParametrosConsulta += "AJIPSECU, "
            ParametrosConsulta += "AJIPFECD, "
            ParametrosConsulta += "AJIPDEST, "
            ParametrosConsulta += "AJIPUSUD, "

            ParametrosConsulta += "USUANOMB, "
            ParametrosConsulta += "USUAPRAP, "
            ParametrosConsulta += "USUASEAP, "
            ParametrosConsulta += "ESTADESC, "

            ParametrosConsulta += "AJIPIDRE, "
            ParametrosConsulta += "AJIPNUFI, "
            ParametrosConsulta += "AJIPNUDO, "
            ParametrosConsulta += "AJIPDEPA, "
            ParametrosConsulta += "AJIPMUNI, "
            ParametrosConsulta += "AJIPCORR, "
            ParametrosConsulta += "AJIPBARR, "
            ParametrosConsulta += "AJIPMANZ, "
            ParametrosConsulta += "AJIPPRED, "
            ParametrosConsulta += "AJIPEDIF, "
            ParametrosConsulta += "AJIPUNPR, "
            ParametrosConsulta += "AJIPCLSE, "
            ParametrosConsulta += "AJIPVIGE, "
            ParametrosConsulta += "AJIPMAIN, "
            ParametrosConsulta += "AJIPFECH, "
            ParametrosConsulta += "AJIPCLAS, "
            ParametrosConsulta += "AJIPTITR, "
            ParametrosConsulta += "AJIPMERE, "
            ParametrosConsulta += "AJIPREAJ, "

            ParametrosConsulta += "AJIPNURA, "
            ParametrosConsulta += "AJIPFERA, "
            ParametrosConsulta += "AJIPNURE, "
            ParametrosConsulta += "AJIPFERE, "
            ParametrosConsulta += "AJIPNUOF, "
            ParametrosConsulta += "AJIPFEOF, "
            ParametrosConsulta += "AJIPOBSE, "
            ParametrosConsulta += "AJIPESTA, "
            ParametrosConsulta += "AJIPESTR "

            ParametrosConsulta += "FROM "
            ParametrosConsulta += "AJUSIMPR, USUARIO, ESTADO "

            ParametrosConsulta += "WHERE "
            ParametrosConsulta += "AJIPDEST = USUANUDO AND "
            ParametrosConsulta += "AJIPESTR = ESTACODI AND "
            ParametrosConsulta += "AJIPREMI = '" & CStr(Trim(vp_cedula)) & "' AND "
            ParametrosConsulta += "AJIPESTR = 'as' "

            ParametrosConsulta += "ORDER BY "
            ParametrosConsulta += "AJIPSECU "

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

            If dt.Rows.Count > 0 Then

                Me.dgvTRAMASIG.DataSource = dt

                Me.dgvTRAMASIG.Columns("AJIPSECU").HeaderText = "Nro. Tramite"
                Me.dgvTRAMASIG.Columns("AJIPUSUD").HeaderText = "Destinatario"
                Me.dgvTRAMASIG.Columns("AJIPDEST").HeaderText = "Nro. Documento"
                Me.dgvTRAMASIG.Columns("AJIPFECD").HeaderText = "Fecha de asignación"
                Me.dgvTRAMASIG.Columns("USUANOMB").HeaderText = "Nombre"
                Me.dgvTRAMASIG.Columns("USUAPRAP").HeaderText = "Primer apellido"
                Me.dgvTRAMASIG.Columns("USUASEAP").HeaderText = "Segundo apellido"
                Me.dgvTRAMASIG.Columns("ESTADESC").HeaderText = "Estado"

                Me.dgvTRAMASIG.Columns("AJIPIDRE").Visible = False
                Me.dgvTRAMASIG.Columns("AJIPNUFI").Visible = False
                Me.dgvTRAMASIG.Columns("AJIPDEPA").Visible = False
                Me.dgvTRAMASIG.Columns("AJIPMUNI").Visible = False
                Me.dgvTRAMASIG.Columns("AJIPCORR").Visible = False
                Me.dgvTRAMASIG.Columns("AJIPBARR").Visible = False
                Me.dgvTRAMASIG.Columns("AJIPMANZ").Visible = False
                Me.dgvTRAMASIG.Columns("AJIPEDIF").Visible = False
                Me.dgvTRAMASIG.Columns("AJIPUNPR").Visible = False
                Me.dgvTRAMASIG.Columns("AJIPPRED").Visible = False
                Me.dgvTRAMASIG.Columns("AJIPCLSE").Visible = False
                Me.dgvTRAMASIG.Columns("AJIPVIGE").Visible = False
                Me.dgvTRAMASIG.Columns("AJIPDEPA").Visible = False
                Me.dgvTRAMASIG.Columns("AJIPMAIN").Visible = False
                Me.dgvTRAMASIG.Columns("AJIPFECH").Visible = False
                Me.dgvTRAMASIG.Columns("AJIPCLAS").Visible = False
                Me.dgvTRAMASIG.Columns("AJIPTITR").Visible = False
                Me.dgvTRAMASIG.Columns("AJIPMERE").Visible = False
                Me.dgvTRAMASIG.Columns("AJIPREAJ").Visible = False
                Me.dgvTRAMASIG.Columns("AJIPNUDO").Visible = False
                Me.dgvTRAMASIG.Columns("AJIPNURA").Visible = False
                Me.dgvTRAMASIG.Columns("AJIPFERA").Visible = False
                Me.dgvTRAMASIG.Columns("AJIPNURE").Visible = False
                Me.dgvTRAMASIG.Columns("AJIPFERE").Visible = False
                Me.dgvTRAMASIG.Columns("AJIPNUOF").Visible = False
                Me.dgvTRAMASIG.Columns("AJIPFEOF").Visible = False
                Me.dgvTRAMASIG.Columns("AJIPOBSE").Visible = False
                Me.dgvTRAMASIG.Columns("AJIPESTA").Visible = False
                Me.dgvTRAMASIG.Columns("AJIPESTR").Visible = False

            Else
                Me.dgvTRAMASIG.DataSource = New DataTable
                Me.txtAJIPOBSE.Text = ""
                Me.lstLISTADO_DOCUMENTOS_RECLAMOS.Items.Clear()
                Me.lstLISTADO_IMAGENES.Items.Clear()
                Me.lstLISTADO_RESOLUCION.Items.Clear()
                Me.lstLISTADO_DOCUMENTOS_AJUSTES.Items.Clear()
            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub pro_ReconsultarAjustesPendientes()

        Try
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
            ParametrosConsulta += "AJIPSECU, "
            ParametrosConsulta += "AJIPFECR, "
            ParametrosConsulta += "AJIPREMI, "
            ParametrosConsulta += "AJIPUSUR, "

            ParametrosConsulta += "USUANOMB, "
            ParametrosConsulta += "USUAPRAP, "
            ParametrosConsulta += "USUASEAP, "
            ParametrosConsulta += "ESTADESC, "

            ParametrosConsulta += "AJIPIDRE, "
            ParametrosConsulta += "AJIPNUFI, "
            ParametrosConsulta += "AJIPNUDO, "
            ParametrosConsulta += "AJIPDEPA, "
            ParametrosConsulta += "AJIPMUNI, "
            ParametrosConsulta += "AJIPCORR, "
            ParametrosConsulta += "AJIPBARR, "
            ParametrosConsulta += "AJIPMANZ, "
            ParametrosConsulta += "AJIPPRED, "
            ParametrosConsulta += "AJIPEDIF, "
            ParametrosConsulta += "AJIPUNPR, "
            ParametrosConsulta += "AJIPCLSE, "
            ParametrosConsulta += "AJIPVIGE, "
            ParametrosConsulta += "AJIPMAIN, "
            ParametrosConsulta += "AJIPFECH, "
            ParametrosConsulta += "AJIPCLAS, "
            ParametrosConsulta += "AJIPTITR, "
            ParametrosConsulta += "AJIPMERE, "
            ParametrosConsulta += "AJIPREAJ, "
            ParametrosConsulta += "AJIPDEST, "
            ParametrosConsulta += "AJIPFECD, "

            ParametrosConsulta += "AJIPNURA, "
            ParametrosConsulta += "AJIPFERA, "
            ParametrosConsulta += "AJIPNURE, "
            ParametrosConsulta += "AJIPFERE, "
            ParametrosConsulta += "AJIPNUOF, "
            ParametrosConsulta += "AJIPFEOF, "
            ParametrosConsulta += "AJIPOBSE, "
            ParametrosConsulta += "AJIPESTA, "
            ParametrosConsulta += "AJIPESTR "

            ParametrosConsulta += "FROM "
            ParametrosConsulta += "AJUSIMPR, USUARIO, ESTADO "

            ParametrosConsulta += "WHERE "
            ParametrosConsulta += "AJIPREMI = USUANUDO AND "
            ParametrosConsulta += "AJIPESTR = ESTACODI AND "
            ParametrosConsulta += "AJIPDEST = '" & CStr(Trim(vp_cedula)) & "' AND "
            ParametrosConsulta += "AJIPESTR = 'as' "

            ParametrosConsulta += "ORDER BY "
            ParametrosConsulta += "AJIPSECU "

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

            If dt.Rows.Count > 0 Then

                Me.dgvTRAMPEND.DataSource = dt

                Me.dgvTRAMPEND.Columns("AJIPSECU").HeaderText = "Nro. Tramite"
                Me.dgvTRAMPEND.Columns("AJIPUSUR").HeaderText = "Remitente"
                Me.dgvTRAMPEND.Columns("AJIPREMI").HeaderText = "Nro. Documento"
                Me.dgvTRAMPEND.Columns("AJIPFECR").HeaderText = "Fecha de asignación"
                Me.dgvTRAMPEND.Columns("USUANOMB").HeaderText = "Nombre"
                Me.dgvTRAMPEND.Columns("USUAPRAP").HeaderText = "Primer apellido"
                Me.dgvTRAMPEND.Columns("USUASEAP").HeaderText = "Segundo apellido"
                Me.dgvTRAMPEND.Columns("ESTADESC").HeaderText = "Estado"

                Me.dgvTRAMPEND.Columns("AJIPIDRE").Visible = False
                Me.dgvTRAMPEND.Columns("AJIPNUFI").Visible = False
                Me.dgvTRAMPEND.Columns("AJIPDEPA").Visible = False
                Me.dgvTRAMPEND.Columns("AJIPMUNI").Visible = False
                Me.dgvTRAMPEND.Columns("AJIPCORR").Visible = False
                Me.dgvTRAMPEND.Columns("AJIPBARR").Visible = False
                Me.dgvTRAMPEND.Columns("AJIPMANZ").Visible = False
                Me.dgvTRAMPEND.Columns("AJIPEDIF").Visible = False
                Me.dgvTRAMPEND.Columns("AJIPUNPR").Visible = False
                Me.dgvTRAMPEND.Columns("AJIPPRED").Visible = False
                Me.dgvTRAMPEND.Columns("AJIPCLSE").Visible = False
                Me.dgvTRAMPEND.Columns("AJIPVIGE").Visible = False
                Me.dgvTRAMPEND.Columns("AJIPDEPA").Visible = False
                Me.dgvTRAMPEND.Columns("AJIPMAIN").Visible = False
                Me.dgvTRAMPEND.Columns("AJIPFECH").Visible = False
                Me.dgvTRAMPEND.Columns("AJIPCLAS").Visible = False
                Me.dgvTRAMPEND.Columns("AJIPTITR").Visible = False
                Me.dgvTRAMPEND.Columns("AJIPMERE").Visible = False
                Me.dgvTRAMPEND.Columns("AJIPREAJ").Visible = False
                Me.dgvTRAMPEND.Columns("AJIPDEST").Visible = False
                Me.dgvTRAMPEND.Columns("AJIPFECD").Visible = False
                Me.dgvTRAMPEND.Columns("AJIPNUDO").Visible = False
                Me.dgvTRAMPEND.Columns("AJIPNURA").Visible = False
                Me.dgvTRAMPEND.Columns("AJIPFERA").Visible = False
                Me.dgvTRAMPEND.Columns("AJIPNURE").Visible = False
                Me.dgvTRAMPEND.Columns("AJIPFERE").Visible = False
                Me.dgvTRAMPEND.Columns("AJIPNUOF").Visible = False
                Me.dgvTRAMPEND.Columns("AJIPFEOF").Visible = False
                Me.dgvTRAMPEND.Columns("AJIPOBSE").Visible = False
                Me.dgvTRAMPEND.Columns("AJIPESTA").Visible = False
                Me.dgvTRAMPEND.Columns("AJIPESTR").Visible = False

            Else
                Me.dgvTRAMPEND.DataSource = New DataTable
                Me.txtAJIPOBSE.Text = ""
                Me.lstLISTADO_DOCUMENTOS_RECLAMOS.Items.Clear()
                Me.lstLISTADO_IMAGENES.Items.Clear()
                Me.lstLISTADO_RESOLUCION.Items.Clear()
                Me.lstLISTADO_DOCUMENTOS_AJUSTES.Items.Clear()
            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub pro_ReconsultarAjustesFinalizados()

        Try
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
            ParametrosConsulta += "AJIPSECU, "
            ParametrosConsulta += "AJIPFECD, "
            ParametrosConsulta += "AJIPDEST, "
            ParametrosConsulta += "AJIPUSUD, "

            ParametrosConsulta += "USUANOMB, "
            ParametrosConsulta += "USUAPRAP, "
            ParametrosConsulta += "USUASEAP, "
            ParametrosConsulta += "ESTADESC, "

            ParametrosConsulta += "AJIPIDRE, "
            ParametrosConsulta += "AJIPNUFI, "
            ParametrosConsulta += "AJIPNUDO, "
            ParametrosConsulta += "AJIPDEPA, "
            ParametrosConsulta += "AJIPMUNI, "
            ParametrosConsulta += "AJIPCORR, "
            ParametrosConsulta += "AJIPBARR, "
            ParametrosConsulta += "AJIPMANZ, "
            ParametrosConsulta += "AJIPPRED, "
            ParametrosConsulta += "AJIPEDIF, "
            ParametrosConsulta += "AJIPUNPR, "
            ParametrosConsulta += "AJIPCLSE, "
            ParametrosConsulta += "AJIPVIGE, "
            ParametrosConsulta += "AJIPMAIN, "
            ParametrosConsulta += "AJIPFECH, "
            ParametrosConsulta += "AJIPCLAS, "
            ParametrosConsulta += "AJIPTITR, "
            ParametrosConsulta += "AJIPMERE, "
            ParametrosConsulta += "AJIPREAJ, "

            ParametrosConsulta += "AJIPNURA, "
            ParametrosConsulta += "AJIPFERA, "
            ParametrosConsulta += "AJIPNURE, "
            ParametrosConsulta += "AJIPFERE, "
            ParametrosConsulta += "AJIPNUOF, "
            ParametrosConsulta += "AJIPFEOF, "
            ParametrosConsulta += "AJIPOBSE, "
            ParametrosConsulta += "AJIPESTA, "
            ParametrosConsulta += "AJIPESTR "

            ParametrosConsulta += "FROM "
            ParametrosConsulta += "AJUSIMPR, USUARIO, ESTADO "

            ParametrosConsulta += "WHERE "
            ParametrosConsulta += "AJIPDEST = USUANUDO AND "
            ParametrosConsulta += "AJIPESTR = ESTACODI AND "
            ParametrosConsulta += "AJIPESTR = 'fi' "

            ParametrosConsulta += "ORDER BY "
            ParametrosConsulta += "AJIPSECU "

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

            If dt.Rows.Count > 0 Then

                Me.dgvTRAMFINA.DataSource = dt

                Me.dgvTRAMFINA.Columns("AJIPSECU").HeaderText = "Nro. Tramite"
                Me.dgvTRAMFINA.Columns("AJIPUSUD").HeaderText = "Destinatario"
                Me.dgvTRAMFINA.Columns("AJIPDEST").HeaderText = "Nro. Documento"
                Me.dgvTRAMFINA.Columns("AJIPFECD").HeaderText = "Fecha de asignación"
                Me.dgvTRAMFINA.Columns("USUANOMB").HeaderText = "Nombre"
                Me.dgvTRAMFINA.Columns("USUAPRAP").HeaderText = "Primer apellido"
                Me.dgvTRAMFINA.Columns("USUASEAP").HeaderText = "Segundo apellido"
                Me.dgvTRAMFINA.Columns("ESTADESC").HeaderText = "Estado"

                Me.dgvTRAMFINA.Columns("AJIPIDRE").Visible = False
                Me.dgvTRAMFINA.Columns("AJIPNUFI").Visible = False
                Me.dgvTRAMFINA.Columns("AJIPDEPA").Visible = False
                Me.dgvTRAMFINA.Columns("AJIPMUNI").Visible = False
                Me.dgvTRAMFINA.Columns("AJIPCORR").Visible = False
                Me.dgvTRAMFINA.Columns("AJIPBARR").Visible = False
                Me.dgvTRAMFINA.Columns("AJIPMANZ").Visible = False
                Me.dgvTRAMFINA.Columns("AJIPEDIF").Visible = False
                Me.dgvTRAMFINA.Columns("AJIPUNPR").Visible = False
                Me.dgvTRAMFINA.Columns("AJIPPRED").Visible = False
                Me.dgvTRAMFINA.Columns("AJIPCLSE").Visible = False
                Me.dgvTRAMFINA.Columns("AJIPVIGE").Visible = False
                Me.dgvTRAMFINA.Columns("AJIPDEPA").Visible = False
                Me.dgvTRAMFINA.Columns("AJIPMAIN").Visible = False
                Me.dgvTRAMFINA.Columns("AJIPFECH").Visible = False
                Me.dgvTRAMFINA.Columns("AJIPCLAS").Visible = False
                Me.dgvTRAMFINA.Columns("AJIPTITR").Visible = False
                Me.dgvTRAMFINA.Columns("AJIPMERE").Visible = False
                Me.dgvTRAMFINA.Columns("AJIPREAJ").Visible = False
                Me.dgvTRAMFINA.Columns("AJIPNUDO").Visible = False
                Me.dgvTRAMFINA.Columns("AJIPNURA").Visible = False
                Me.dgvTRAMFINA.Columns("AJIPFERA").Visible = False
                Me.dgvTRAMFINA.Columns("AJIPNURE").Visible = False
                Me.dgvTRAMFINA.Columns("AJIPFERE").Visible = False
                Me.dgvTRAMFINA.Columns("AJIPNUOF").Visible = False
                Me.dgvTRAMFINA.Columns("AJIPFEOF").Visible = False
                Me.dgvTRAMFINA.Columns("AJIPOBSE").Visible = False
                Me.dgvTRAMFINA.Columns("AJIPESTA").Visible = False
                Me.dgvTRAMFINA.Columns("AJIPESTR").Visible = False
            Else
                Me.dgvTRAMFINA.DataSource = New DataTable
                Me.txtAJIPOBSE.Text = ""
                Me.lstLISTADO_DOCUMENTOS_RECLAMOS.Items.Clear()
                Me.lstLISTADO_IMAGENES.Items.Clear()
                Me.lstLISTADO_RESOLUCION.Items.Clear()
                Me.lstLISTADO_DOCUMENTOS_AJUSTES.Items.Clear()
            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub

    Private Sub pro_ReconsultarAjustesRegistradosPorConsulta()

        Try
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
            ParametrosConsulta += "AJIPSECU, "
            ParametrosConsulta += "AJIPFECH, "
            ParametrosConsulta += "AJIPNUDO, "
            ParametrosConsulta += "AJIPFECR, "
            ParametrosConsulta += "AJIPREMI, "
            ParametrosConsulta += "AJIPUSUR, "

            ParametrosConsulta += "CONTUSUA, "
            ParametrosConsulta += "USUANOMB, "
            ParametrosConsulta += "USUAPRAP, "
            ParametrosConsulta += "USUASEAP, "
            ParametrosConsulta += "ESTADESC, "

            ParametrosConsulta += "AJIPIDRE, "
            ParametrosConsulta += "AJIPNUFI, "
            ParametrosConsulta += "AJIPDEPA, "
            ParametrosConsulta += "AJIPMUNI, "
            ParametrosConsulta += "AJIPCORR, "
            ParametrosConsulta += "AJIPBARR, "
            ParametrosConsulta += "AJIPMANZ, "
            ParametrosConsulta += "AJIPPRED, "
            ParametrosConsulta += "AJIPEDIF, "
            ParametrosConsulta += "AJIPUNPR, "
            ParametrosConsulta += "AJIPCLSE, "
            ParametrosConsulta += "AJIPVIGE, "
            ParametrosConsulta += "AJIPMAIN, "

            ParametrosConsulta += "AJIPCLAS, "
            ParametrosConsulta += "AJIPTITR, "
            ParametrosConsulta += "AJIPMERE, "
            ParametrosConsulta += "AJIPREAJ, "
            ParametrosConsulta += "AJIPDEST, "
            ParametrosConsulta += "AJIPFECD, "

            ParametrosConsulta += "AJIPNURA, "
            ParametrosConsulta += "AJIPFERA, "
            ParametrosConsulta += "AJIPNURE, "
            ParametrosConsulta += "AJIPFERE, "
            ParametrosConsulta += "AJIPNUOF, "
            ParametrosConsulta += "AJIPFEOF, "
            ParametrosConsulta += "AJIPOBSE, "
            ParametrosConsulta += "AJIPESTA, "
            ParametrosConsulta += "AJIPESTR "

            ParametrosConsulta += "FROM "
            ParametrosConsulta += "AJUSIMPR, USUARIO, ESTADO, CONTRASENA "

            ParametrosConsulta += "WHERE "
            ParametrosConsulta += "AJIPNUDO = CONTNUDO AND "
            ParametrosConsulta += "AJIPNUDO = USUANUDO AND "
            ParametrosConsulta += "AJIPESTR = ESTACODI AND "
            ParametrosConsulta += "AJIPNUDO = '" & CStr(Trim(vp_cedula)) & "' AND "
            ParametrosConsulta += "AJIPSECU = '" & CStr(Trim(Me.dgvAJUSIMPR.SelectedRows.Item(0).Cells("AJIPSECU").Value.ToString)) & "' AND "
            ParametrosConsulta += "AJIPESTR = 'ac' "

            ParametrosConsulta += "ORDER BY "
            ParametrosConsulta += "AJIPSECU "

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

            If dt.Rows.Count > 0 Then

                Me.dgvTRAMREGI.DataSource = dt

                Me.dgvTRAMREGI.Columns("AJIPSECU").HeaderText = "Nro. Tramite"
                Me.dgvTRAMREGI.Columns("CONTUSUA").HeaderText = "Registrador"
                Me.dgvTRAMREGI.Columns("AJIPNUDO").HeaderText = "Nro. Documento"
                Me.dgvTRAMREGI.Columns("AJIPFECH").HeaderText = "Fecha de registro"
                Me.dgvTRAMREGI.Columns("USUANOMB").HeaderText = "Nombre"
                Me.dgvTRAMREGI.Columns("USUAPRAP").HeaderText = "Primer apellido"
                Me.dgvTRAMREGI.Columns("USUASEAP").HeaderText = "Segundo apellido"
                Me.dgvTRAMREGI.Columns("ESTADESC").HeaderText = "Estado"

                Me.dgvTRAMREGI.Columns("AJIPIDRE").Visible = False
                Me.dgvTRAMREGI.Columns("AJIPNUFI").Visible = False
                Me.dgvTRAMREGI.Columns("AJIPDEPA").Visible = False
                Me.dgvTRAMREGI.Columns("AJIPMUNI").Visible = False
                Me.dgvTRAMREGI.Columns("AJIPCORR").Visible = False
                Me.dgvTRAMREGI.Columns("AJIPBARR").Visible = False
                Me.dgvTRAMREGI.Columns("AJIPMANZ").Visible = False
                Me.dgvTRAMREGI.Columns("AJIPEDIF").Visible = False
                Me.dgvTRAMREGI.Columns("AJIPUNPR").Visible = False
                Me.dgvTRAMREGI.Columns("AJIPPRED").Visible = False
                Me.dgvTRAMREGI.Columns("AJIPCLSE").Visible = False
                Me.dgvTRAMREGI.Columns("AJIPVIGE").Visible = False
                Me.dgvTRAMREGI.Columns("AJIPDEPA").Visible = False
                Me.dgvTRAMREGI.Columns("AJIPMAIN").Visible = False
                Me.dgvTRAMREGI.Columns("AJIPCLAS").Visible = False
                Me.dgvTRAMREGI.Columns("AJIPTITR").Visible = False
                Me.dgvTRAMREGI.Columns("AJIPMERE").Visible = False
                Me.dgvTRAMREGI.Columns("AJIPREAJ").Visible = False
                Me.dgvTRAMREGI.Columns("AJIPDEST").Visible = False
                Me.dgvTRAMREGI.Columns("AJIPFECD").Visible = False
                Me.dgvTRAMREGI.Columns("AJIPFECR").Visible = False
                Me.dgvTRAMREGI.Columns("AJIPNURA").Visible = False
                Me.dgvTRAMREGI.Columns("AJIPFERA").Visible = False
                Me.dgvTRAMREGI.Columns("AJIPNURE").Visible = False
                Me.dgvTRAMREGI.Columns("AJIPFERE").Visible = False
                Me.dgvTRAMREGI.Columns("AJIPNUOF").Visible = False
                Me.dgvTRAMREGI.Columns("AJIPFEOF").Visible = False
                Me.dgvTRAMREGI.Columns("AJIPOBSE").Visible = False
                Me.dgvTRAMREGI.Columns("AJIPESTA").Visible = False
                Me.dgvTRAMREGI.Columns("AJIPESTR").Visible = False
                Me.dgvTRAMREGI.Columns("AJIPREMI").Visible = False
                Me.dgvTRAMREGI.Columns("AJIPUSUR").Visible = False

            Else
                Me.dgvTRAMREGI.DataSource = New DataTable
            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub pro_ReconsultarAjustesAsignadosPorConsulta()

        Try
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
            ParametrosConsulta += "AJIPSECU, "
            ParametrosConsulta += "AJIPFECD, "
            ParametrosConsulta += "AJIPDEST, "
            ParametrosConsulta += "AJIPUSUD, "

            ParametrosConsulta += "USUANOMB, "
            ParametrosConsulta += "USUAPRAP, "
            ParametrosConsulta += "USUASEAP, "
            ParametrosConsulta += "ESTADESC, "

            ParametrosConsulta += "AJIPIDRE, "
            ParametrosConsulta += "AJIPNUFI, "
            ParametrosConsulta += "AJIPNUDO, "
            ParametrosConsulta += "AJIPDEPA, "
            ParametrosConsulta += "AJIPMUNI, "
            ParametrosConsulta += "AJIPCORR, "
            ParametrosConsulta += "AJIPBARR, "
            ParametrosConsulta += "AJIPMANZ, "
            ParametrosConsulta += "AJIPPRED, "
            ParametrosConsulta += "AJIPEDIF, "
            ParametrosConsulta += "AJIPUNPR, "
            ParametrosConsulta += "AJIPCLSE, "
            ParametrosConsulta += "AJIPVIGE, "
            ParametrosConsulta += "AJIPMAIN, "
            ParametrosConsulta += "AJIPFECH, "
            ParametrosConsulta += "AJIPCLAS, "
            ParametrosConsulta += "AJIPTITR, "
            ParametrosConsulta += "AJIPMERE, "
            ParametrosConsulta += "AJIPREAJ, "

            ParametrosConsulta += "AJIPNURA, "
            ParametrosConsulta += "AJIPFERA, "
            ParametrosConsulta += "AJIPNURE, "
            ParametrosConsulta += "AJIPFERE, "
            ParametrosConsulta += "AJIPNUOF, "
            ParametrosConsulta += "AJIPFEOF, "
            ParametrosConsulta += "AJIPOBSE, "
            ParametrosConsulta += "AJIPESTA, "
            ParametrosConsulta += "AJIPESTR "

            ParametrosConsulta += "FROM "
            ParametrosConsulta += "AJUSIMPR, USUARIO, ESTADO "

            ParametrosConsulta += "WHERE "
            ParametrosConsulta += "AJIPDEST = USUANUDO AND "
            ParametrosConsulta += "AJIPESTR = ESTACODI AND "
            ParametrosConsulta += "AJIPREMI = '" & CStr(Trim(vp_cedula)) & "' AND "
            ParametrosConsulta += "AJIPSECU = '" & CStr(Trim(Me.dgvAJUSIMPR.SelectedRows.Item(0).Cells("AJIPSECU").Value.ToString)) & "' AND "
            ParametrosConsulta += "AJIPESTR = 'as' "

            ParametrosConsulta += "ORDER BY "
            ParametrosConsulta += "AJIPSECU "

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

            If dt.Rows.Count > 0 Then

                Me.dgvTRAMASIG.DataSource = dt

                Me.dgvTRAMASIG.Columns("AJIPSECU").HeaderText = "Nro. Tramite"
                Me.dgvTRAMASIG.Columns("AJIPUSUD").HeaderText = "Destinatario"
                Me.dgvTRAMASIG.Columns("AJIPDEST").HeaderText = "Nro. Documento"
                Me.dgvTRAMASIG.Columns("AJIPFECD").HeaderText = "Fecha de asignación"
                Me.dgvTRAMASIG.Columns("USUANOMB").HeaderText = "Nombre"
                Me.dgvTRAMASIG.Columns("USUAPRAP").HeaderText = "Primer apellido"
                Me.dgvTRAMASIG.Columns("USUASEAP").HeaderText = "Segundo apellido"
                Me.dgvTRAMASIG.Columns("ESTADESC").HeaderText = "Estado"

                Me.dgvTRAMASIG.Columns("AJIPIDRE").Visible = False
                Me.dgvTRAMASIG.Columns("AJIPNUFI").Visible = False
                Me.dgvTRAMASIG.Columns("AJIPDEPA").Visible = False
                Me.dgvTRAMASIG.Columns("AJIPMUNI").Visible = False
                Me.dgvTRAMASIG.Columns("AJIPCORR").Visible = False
                Me.dgvTRAMASIG.Columns("AJIPBARR").Visible = False
                Me.dgvTRAMASIG.Columns("AJIPMANZ").Visible = False
                Me.dgvTRAMASIG.Columns("AJIPEDIF").Visible = False
                Me.dgvTRAMASIG.Columns("AJIPUNPR").Visible = False
                Me.dgvTRAMASIG.Columns("AJIPPRED").Visible = False
                Me.dgvTRAMASIG.Columns("AJIPCLSE").Visible = False
                Me.dgvTRAMASIG.Columns("AJIPVIGE").Visible = False
                Me.dgvTRAMASIG.Columns("AJIPDEPA").Visible = False
                Me.dgvTRAMASIG.Columns("AJIPMAIN").Visible = False
                Me.dgvTRAMASIG.Columns("AJIPFECH").Visible = False
                Me.dgvTRAMASIG.Columns("AJIPCLAS").Visible = False
                Me.dgvTRAMASIG.Columns("AJIPTITR").Visible = False
                Me.dgvTRAMASIG.Columns("AJIPMERE").Visible = False
                Me.dgvTRAMASIG.Columns("AJIPREAJ").Visible = False
                Me.dgvTRAMASIG.Columns("AJIPNUDO").Visible = False
                Me.dgvTRAMASIG.Columns("AJIPNURA").Visible = False
                Me.dgvTRAMASIG.Columns("AJIPFERA").Visible = False
                Me.dgvTRAMASIG.Columns("AJIPNURE").Visible = False
                Me.dgvTRAMASIG.Columns("AJIPFERE").Visible = False
                Me.dgvTRAMASIG.Columns("AJIPNUOF").Visible = False
                Me.dgvTRAMASIG.Columns("AJIPFEOF").Visible = False
                Me.dgvTRAMASIG.Columns("AJIPOBSE").Visible = False
                Me.dgvTRAMASIG.Columns("AJIPESTA").Visible = False
                Me.dgvTRAMASIG.Columns("AJIPESTR").Visible = False
            Else
                Me.dgvTRAMASIG.DataSource = New DataTable
            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub pro_ReconsultarAjustesPendientesPorConsulta()

        Try
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
            ParametrosConsulta += "AJIPSECU, "
            ParametrosConsulta += "AJIPFECR, "
            ParametrosConsulta += "AJIPREMI, "
            ParametrosConsulta += "AJIPUSUR, "

            ParametrosConsulta += "USUANOMB, "
            ParametrosConsulta += "USUAPRAP, "
            ParametrosConsulta += "USUASEAP, "
            ParametrosConsulta += "ESTADESC, "

            ParametrosConsulta += "AJIPIDRE, "
            ParametrosConsulta += "AJIPNUFI, "
            ParametrosConsulta += "AJIPNUDO, "
            ParametrosConsulta += "AJIPDEPA, "
            ParametrosConsulta += "AJIPMUNI, "
            ParametrosConsulta += "AJIPCORR, "
            ParametrosConsulta += "AJIPBARR, "
            ParametrosConsulta += "AJIPMANZ, "
            ParametrosConsulta += "AJIPPRED, "
            ParametrosConsulta += "AJIPEDIF, "
            ParametrosConsulta += "AJIPUNPR, "
            ParametrosConsulta += "AJIPCLSE, "
            ParametrosConsulta += "AJIPVIGE, "
            ParametrosConsulta += "AJIPMAIN, "
            ParametrosConsulta += "AJIPFECH, "
            ParametrosConsulta += "AJIPCLAS, "
            ParametrosConsulta += "AJIPTITR, "
            ParametrosConsulta += "AJIPMERE, "
            ParametrosConsulta += "AJIPREAJ, "
            ParametrosConsulta += "AJIPDEST, "
            ParametrosConsulta += "AJIPFECD, "

            ParametrosConsulta += "AJIPNURA, "
            ParametrosConsulta += "AJIPFERA, "
            ParametrosConsulta += "AJIPNURE, "
            ParametrosConsulta += "AJIPFERE, "
            ParametrosConsulta += "AJIPNUOF, "
            ParametrosConsulta += "AJIPFEOF, "
            ParametrosConsulta += "AJIPOBSE, "
            ParametrosConsulta += "AJIPESTA, "
            ParametrosConsulta += "AJIPESTR "

            ParametrosConsulta += "FROM "
            ParametrosConsulta += "AJUSIMPR, USUARIO, ESTADO "

            ParametrosConsulta += "WHERE "
            ParametrosConsulta += "AJIPREMI = USUANUDO AND "
            ParametrosConsulta += "AJIPESTR = ESTACODI AND "
            ParametrosConsulta += "AJIPDEST = '" & CStr(Trim(vp_cedula)) & "' AND "
            ParametrosConsulta += "AJIPSECU = '" & CStr(Trim(Me.dgvAJUSIMPR.SelectedRows.Item(0).Cells("AJIPSECU").Value.ToString)) & "' AND "
            ParametrosConsulta += "AJIPESTR = 'as' "

            ParametrosConsulta += "ORDER BY "
            ParametrosConsulta += "AJIPSECU "

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

            If dt.Rows.Count > 0 Then

                Me.dgvTRAMPEND.DataSource = dt

                Me.dgvTRAMPEND.Columns("AJIPSECU").HeaderText = "Nro. Tramite"
                Me.dgvTRAMPEND.Columns("AJIPUSUR").HeaderText = "Remitente"
                Me.dgvTRAMPEND.Columns("AJIPREMI").HeaderText = "Nro. Documento"
                Me.dgvTRAMPEND.Columns("AJIPFECR").HeaderText = "Fecha de asignación"
                Me.dgvTRAMPEND.Columns("USUANOMB").HeaderText = "Nombre"
                Me.dgvTRAMPEND.Columns("USUAPRAP").HeaderText = "Primer apellido"
                Me.dgvTRAMPEND.Columns("USUASEAP").HeaderText = "Segundo apellido"
                Me.dgvTRAMPEND.Columns("ESTADESC").HeaderText = "Estado"

                Me.dgvTRAMPEND.Columns("AJIPIDRE").Visible = False
                Me.dgvTRAMPEND.Columns("AJIPNUFI").Visible = False
                Me.dgvTRAMPEND.Columns("AJIPDEPA").Visible = False
                Me.dgvTRAMPEND.Columns("AJIPMUNI").Visible = False
                Me.dgvTRAMPEND.Columns("AJIPCORR").Visible = False
                Me.dgvTRAMPEND.Columns("AJIPBARR").Visible = False
                Me.dgvTRAMPEND.Columns("AJIPMANZ").Visible = False
                Me.dgvTRAMPEND.Columns("AJIPEDIF").Visible = False
                Me.dgvTRAMPEND.Columns("AJIPUNPR").Visible = False
                Me.dgvTRAMPEND.Columns("AJIPPRED").Visible = False
                Me.dgvTRAMPEND.Columns("AJIPCLSE").Visible = False
                Me.dgvTRAMPEND.Columns("AJIPVIGE").Visible = False
                Me.dgvTRAMPEND.Columns("AJIPDEPA").Visible = False
                Me.dgvTRAMPEND.Columns("AJIPMAIN").Visible = False
                Me.dgvTRAMPEND.Columns("AJIPFECH").Visible = False
                Me.dgvTRAMPEND.Columns("AJIPCLAS").Visible = False
                Me.dgvTRAMPEND.Columns("AJIPTITR").Visible = False
                Me.dgvTRAMPEND.Columns("AJIPMERE").Visible = False
                Me.dgvTRAMPEND.Columns("AJIPREAJ").Visible = False
                Me.dgvTRAMPEND.Columns("AJIPDEST").Visible = False
                Me.dgvTRAMPEND.Columns("AJIPFECD").Visible = False
                Me.dgvTRAMPEND.Columns("AJIPNUDO").Visible = False
                Me.dgvTRAMPEND.Columns("AJIPNURA").Visible = False
                Me.dgvTRAMPEND.Columns("AJIPFERA").Visible = False
                Me.dgvTRAMPEND.Columns("AJIPNURE").Visible = False
                Me.dgvTRAMPEND.Columns("AJIPFERE").Visible = False
                Me.dgvTRAMPEND.Columns("AJIPNUOF").Visible = False
                Me.dgvTRAMPEND.Columns("AJIPFEOF").Visible = False
                Me.dgvTRAMPEND.Columns("AJIPOBSE").Visible = False
                Me.dgvTRAMPEND.Columns("AJIPESTA").Visible = False
                Me.dgvTRAMPEND.Columns("AJIPESTR").Visible = False
            Else
                Me.dgvTRAMPEND.DataSource = New DataTable
            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub pro_ReconsultarAjustesFinalizadosPorConsulta()

        Try
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
            ParametrosConsulta += "AJIPSECU, "
            ParametrosConsulta += "AJIPFECD, "
            ParametrosConsulta += "AJIPDEST, "
            ParametrosConsulta += "AJIPUSUD, "

            ParametrosConsulta += "USUANOMB, "
            ParametrosConsulta += "USUAPRAP, "
            ParametrosConsulta += "USUASEAP, "
            ParametrosConsulta += "ESTADESC, "

            ParametrosConsulta += "AJIPIDRE, "
            ParametrosConsulta += "AJIPNUFI, "
            ParametrosConsulta += "AJIPNUDO, "
            ParametrosConsulta += "AJIPDEPA, "
            ParametrosConsulta += "AJIPMUNI, "
            ParametrosConsulta += "AJIPCORR, "
            ParametrosConsulta += "AJIPBARR, "
            ParametrosConsulta += "AJIPMANZ, "
            ParametrosConsulta += "AJIPPRED, "
            ParametrosConsulta += "AJIPEDIF, "
            ParametrosConsulta += "AJIPUNPR, "
            ParametrosConsulta += "AJIPCLSE, "
            ParametrosConsulta += "AJIPVIGE, "
            ParametrosConsulta += "AJIPMAIN, "
            ParametrosConsulta += "AJIPFECH, "
            ParametrosConsulta += "AJIPCLAS, "
            ParametrosConsulta += "AJIPTITR, "
            ParametrosConsulta += "AJIPMERE, "
            ParametrosConsulta += "AJIPREAJ, "

            ParametrosConsulta += "AJIPNURA, "
            ParametrosConsulta += "AJIPFERA, "
            ParametrosConsulta += "AJIPNURE, "
            ParametrosConsulta += "AJIPFERE, "
            ParametrosConsulta += "AJIPNUOF, "
            ParametrosConsulta += "AJIPFEOF, "
            ParametrosConsulta += "AJIPOBSE, "
            ParametrosConsulta += "AJIPESTA, "
            ParametrosConsulta += "AJIPESTR "

            ParametrosConsulta += "FROM "
            ParametrosConsulta += "AJUSIMPR, USUARIO, ESTADO "

            ParametrosConsulta += "WHERE "
            ParametrosConsulta += "AJIPDEST = USUANUDO AND "
            ParametrosConsulta += "AJIPESTR = ESTACODI AND "
            ParametrosConsulta += "AJIPSECU = '" & CStr(Trim(Me.dgvAJUSIMPR.SelectedRows.Item(0).Cells("AJIPSECU").Value.ToString)) & "' AND "
            ParametrosConsulta += "AJIPESTR = 'fi' "

            ParametrosConsulta += "ORDER BY "
            ParametrosConsulta += "AJIPSECU "

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

            If dt.Rows.Count > 0 Then

                Me.dgvTRAMFINA.DataSource = dt

                Me.dgvTRAMFINA.Columns("AJIPSECU").HeaderText = "Nro. Tramite"
                Me.dgvTRAMFINA.Columns("AJIPUSUD").HeaderText = "Destinatario"
                Me.dgvTRAMFINA.Columns("AJIPDEST").HeaderText = "Nro. Documento"
                Me.dgvTRAMFINA.Columns("AJIPFECD").HeaderText = "Fecha de asignación"
                Me.dgvTRAMFINA.Columns("USUANOMB").HeaderText = "Nombre"
                Me.dgvTRAMFINA.Columns("USUAPRAP").HeaderText = "Primer apellido"
                Me.dgvTRAMFINA.Columns("USUASEAP").HeaderText = "Segundo apellido"
                Me.dgvTRAMFINA.Columns("ESTADESC").HeaderText = "Estado"

                Me.dgvTRAMFINA.Columns("AJIPIDRE").Visible = False
                Me.dgvTRAMFINA.Columns("AJIPNUFI").Visible = False
                Me.dgvTRAMFINA.Columns("AJIPDEPA").Visible = False
                Me.dgvTRAMFINA.Columns("AJIPMUNI").Visible = False
                Me.dgvTRAMFINA.Columns("AJIPCORR").Visible = False
                Me.dgvTRAMFINA.Columns("AJIPBARR").Visible = False
                Me.dgvTRAMFINA.Columns("AJIPMANZ").Visible = False
                Me.dgvTRAMFINA.Columns("AJIPEDIF").Visible = False
                Me.dgvTRAMFINA.Columns("AJIPUNPR").Visible = False
                Me.dgvTRAMFINA.Columns("AJIPPRED").Visible = False
                Me.dgvTRAMFINA.Columns("AJIPCLSE").Visible = False
                Me.dgvTRAMFINA.Columns("AJIPVIGE").Visible = False
                Me.dgvTRAMFINA.Columns("AJIPDEPA").Visible = False
                Me.dgvTRAMFINA.Columns("AJIPMAIN").Visible = False
                Me.dgvTRAMFINA.Columns("AJIPFECH").Visible = False
                Me.dgvTRAMFINA.Columns("AJIPCLAS").Visible = False
                Me.dgvTRAMFINA.Columns("AJIPTITR").Visible = False
                Me.dgvTRAMFINA.Columns("AJIPMERE").Visible = False
                Me.dgvTRAMFINA.Columns("AJIPREAJ").Visible = False
                Me.dgvTRAMFINA.Columns("AJIPNUDO").Visible = False
                Me.dgvTRAMFINA.Columns("AJIPNURA").Visible = False
                Me.dgvTRAMFINA.Columns("AJIPFERA").Visible = False
                Me.dgvTRAMFINA.Columns("AJIPNURE").Visible = False
                Me.dgvTRAMFINA.Columns("AJIPFERE").Visible = False
                Me.dgvTRAMFINA.Columns("AJIPNUOF").Visible = False
                Me.dgvTRAMFINA.Columns("AJIPFEOF").Visible = False
                Me.dgvTRAMFINA.Columns("AJIPOBSE").Visible = False
                Me.dgvTRAMFINA.Columns("AJIPESTA").Visible = False
                Me.dgvTRAMFINA.Columns("AJIPESTR").Visible = False
            Else
                Me.dgvTRAMFINA.DataSource = New DataTable
            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub

    Private Sub pro_ReconsultarAjustesRegistradosPorTramite()

        Try
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
            ParametrosConsulta += "AJIPIDRE, "
            ParametrosConsulta += "AJIPNUFI, "
            ParametrosConsulta += "AJIPSECU, "
            ParametrosConsulta += "AJIPDEPA, "
            ParametrosConsulta += "AJIPMUNI, "
            ParametrosConsulta += "AJIPCORR, "
            ParametrosConsulta += "AJIPBARR, "
            ParametrosConsulta += "AJIPMANZ, "
            ParametrosConsulta += "AJIPPRED, "
            ParametrosConsulta += "AJIPEDIF, "
            ParametrosConsulta += "AJIPUNPR, "
            ParametrosConsulta += "AJIPCLSE, "
            ParametrosConsulta += "AJIPVIGE, "
            ParametrosConsulta += "ESTADESC, "
            ParametrosConsulta += "AJIPMAIN, "
            ParametrosConsulta += "AJIPFECH, "
            ParametrosConsulta += "AJIPCLAS, "
            ParametrosConsulta += "AJIPTITR, "
            ParametrosConsulta += "AJIPMERE, "
            ParametrosConsulta += "AJIPREAJ, "
            ParametrosConsulta += "AJIPREMI, "
            ParametrosConsulta += "AJIPFECR, "
            ParametrosConsulta += "AJIPDEST, "
            ParametrosConsulta += "AJIPFECD, "
            ParametrosConsulta += "AJIPNUDO, "
            ParametrosConsulta += "AJIPUSUR, "
            ParametrosConsulta += "AJIPNURA, "
            ParametrosConsulta += "AJIPFERA, "
            ParametrosConsulta += "AJIPNURE, "
            ParametrosConsulta += "AJIPFERE, "
            ParametrosConsulta += "AJIPNUOF, "
            ParametrosConsulta += "AJIPFEOF, "
            ParametrosConsulta += "AJIPOBSE, "
            ParametrosConsulta += "AJIPESTA, "
            ParametrosConsulta += "AJIPESTR, "
            ParametrosConsulta += "AJIPUSUD "

            ParametrosConsulta += "FROM "
            ParametrosConsulta += "AJUSIMPR, ESTADO "

            ParametrosConsulta += "WHERE "
            ParametrosConsulta += "AJIPESTR = ESTACODI AND "
            ParametrosConsulta += "AJIPNUDO = '" & CStr(Trim(vp_cedula)) & "' AND "
            ParametrosConsulta += "AJIPSECU = '" & CStr(Trim(Me.dgvTRAMREGI.SelectedRows.Item(0).Cells("AJIPSECU").Value.ToString)) & "' AND "
            ParametrosConsulta += "AJIPESTR = 'ac' "

            ParametrosConsulta += "ORDER BY "
            ParametrosConsulta += "AJIPSECU "

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

            If dt.Rows.Count > 0 Then

                Me.dgvAJUSIMPR.DataSource = dt

                Me.dgvAJUSIMPR.Columns("AJIPIDRE").HeaderText = "idre"

                Me.dgvAJUSIMPR.Columns("AJIPSECU").HeaderText = "Nro. Tramite"
                Me.dgvAJUSIMPR.Columns("AJIPDEPA").HeaderText = "Departamento"
                Me.dgvAJUSIMPR.Columns("AJIPMUNI").HeaderText = "Municipio"
                Me.dgvAJUSIMPR.Columns("AJIPCORR").HeaderText = "Correg."
                Me.dgvAJUSIMPR.Columns("AJIPBARR").HeaderText = "Barrio"
                Me.dgvAJUSIMPR.Columns("AJIPMANZ").HeaderText = "Manzana Vereda"
                Me.dgvAJUSIMPR.Columns("AJIPEDIF").HeaderText = "Edificio"
                Me.dgvAJUSIMPR.Columns("AJIPUNPR").HeaderText = "Unidad Predial"
                Me.dgvAJUSIMPR.Columns("AJIPPRED").HeaderText = "Predio"
                Me.dgvAJUSIMPR.Columns("AJIPCLSE").HeaderText = "Sector"
                Me.dgvAJUSIMPR.Columns("AJIPVIGE").HeaderText = "Vigencia"
                Me.dgvAJUSIMPR.Columns("ESTADESC").HeaderText = "Estado"

                Me.dgvAJUSIMPR.Columns("AJIPIDRE").Visible = False
                Me.dgvAJUSIMPR.Columns("AJIPNUFI").Visible = False

                Me.dgvAJUSIMPR.Columns("AJIPDEPA").Visible = False
                Me.dgvAJUSIMPR.Columns("AJIPMAIN").Visible = False
                Me.dgvAJUSIMPR.Columns("AJIPFECH").Visible = False
                Me.dgvAJUSIMPR.Columns("AJIPCLAS").Visible = False
                Me.dgvAJUSIMPR.Columns("AJIPTITR").Visible = False
                Me.dgvAJUSIMPR.Columns("AJIPMERE").Visible = False
                Me.dgvAJUSIMPR.Columns("AJIPREAJ").Visible = False
                Me.dgvAJUSIMPR.Columns("AJIPREMI").Visible = False
                Me.dgvAJUSIMPR.Columns("AJIPFECR").Visible = False
                Me.dgvAJUSIMPR.Columns("AJIPDEST").Visible = False
                Me.dgvAJUSIMPR.Columns("AJIPFECD").Visible = False
                Me.dgvAJUSIMPR.Columns("AJIPNUDO").Visible = False
                Me.dgvAJUSIMPR.Columns("AJIPUSUR").Visible = False
                Me.dgvAJUSIMPR.Columns("AJIPUSUD").Visible = False
                Me.dgvAJUSIMPR.Columns("AJIPNURA").Visible = False
                Me.dgvAJUSIMPR.Columns("AJIPFERA").Visible = False
                Me.dgvAJUSIMPR.Columns("AJIPNURE").Visible = False
                Me.dgvAJUSIMPR.Columns("AJIPFERE").Visible = False
                Me.dgvAJUSIMPR.Columns("AJIPNUOF").Visible = False
                Me.dgvAJUSIMPR.Columns("AJIPFEOF").Visible = False
                Me.dgvAJUSIMPR.Columns("AJIPOBSE").Visible = False
                Me.dgvAJUSIMPR.Columns("AJIPESTA").Visible = False
                Me.dgvAJUSIMPR.Columns("AJIPESTR").Visible = False

            Else
                Me.dgvTRAMREGI.DataSource = New DataTable
            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub pro_ReconsultarAjustesAsignadosPorTramite()

        Try
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
            ParametrosConsulta += "AJIPIDRE, "
            ParametrosConsulta += "AJIPNUFI, "
            ParametrosConsulta += "AJIPSECU, "
            ParametrosConsulta += "AJIPDEPA, "
            ParametrosConsulta += "AJIPMUNI, "
            ParametrosConsulta += "AJIPCORR, "
            ParametrosConsulta += "AJIPBARR, "
            ParametrosConsulta += "AJIPMANZ, "
            ParametrosConsulta += "AJIPPRED, "
            ParametrosConsulta += "AJIPEDIF, "
            ParametrosConsulta += "AJIPUNPR, "
            ParametrosConsulta += "AJIPCLSE, "
            ParametrosConsulta += "AJIPVIGE, "
            ParametrosConsulta += "ESTADESC, "
            ParametrosConsulta += "AJIPMAIN, "
            ParametrosConsulta += "AJIPFECH, "
            ParametrosConsulta += "AJIPCLAS, "
            ParametrosConsulta += "AJIPTITR, "
            ParametrosConsulta += "AJIPMERE, "
            ParametrosConsulta += "AJIPREAJ, "
            ParametrosConsulta += "AJIPREMI, "
            ParametrosConsulta += "AJIPFECR, "
            ParametrosConsulta += "AJIPDEST, "
            ParametrosConsulta += "AJIPFECD, "
            ParametrosConsulta += "AJIPNUDO, "
            ParametrosConsulta += "AJIPUSUR, "
            ParametrosConsulta += "AJIPNURA, "
            ParametrosConsulta += "AJIPFERA, "
            ParametrosConsulta += "AJIPNURE, "
            ParametrosConsulta += "AJIPFERE, "
            ParametrosConsulta += "AJIPNUOF, "
            ParametrosConsulta += "AJIPFEOF, "
            ParametrosConsulta += "AJIPOBSE, "
            ParametrosConsulta += "AJIPESTA, "
            ParametrosConsulta += "AJIPESTR, "
            ParametrosConsulta += "AJIPUSUD "

            ParametrosConsulta += "FROM "
            ParametrosConsulta += "AJUSIMPR, ESTADO "

            ParametrosConsulta += "WHERE "
            ParametrosConsulta += "AJIPESTR = ESTACODI AND "
            ParametrosConsulta += "AJIPREMI = '" & CStr(Trim(vp_cedula)) & "' AND "
            ParametrosConsulta += "AJIPSECU = '" & CStr(Trim(Me.dgvTRAMASIG.SelectedRows.Item(0).Cells("AJIPSECU").Value.ToString)) & "' AND "
            ParametrosConsulta += "AJIPESTR = 'as' "

            ParametrosConsulta += "ORDER BY "
            ParametrosConsulta += "AJIPSECU "

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

            If dt.Rows.Count > 0 Then

                Me.dgvAJUSIMPR.DataSource = dt

                Me.dgvAJUSIMPR.Columns("AJIPIDRE").HeaderText = "idre"

                Me.dgvAJUSIMPR.Columns("AJIPSECU").HeaderText = "Nro. Tramite"
                Me.dgvAJUSIMPR.Columns("AJIPDEPA").HeaderText = "Departamento"
                Me.dgvAJUSIMPR.Columns("AJIPMUNI").HeaderText = "Municipio"
                Me.dgvAJUSIMPR.Columns("AJIPCORR").HeaderText = "Correg."
                Me.dgvAJUSIMPR.Columns("AJIPBARR").HeaderText = "Barrio"
                Me.dgvAJUSIMPR.Columns("AJIPMANZ").HeaderText = "Manzana Vereda"
                Me.dgvAJUSIMPR.Columns("AJIPEDIF").HeaderText = "Edificio"
                Me.dgvAJUSIMPR.Columns("AJIPUNPR").HeaderText = "Unidad Predial"
                Me.dgvAJUSIMPR.Columns("AJIPPRED").HeaderText = "Predio"
                Me.dgvAJUSIMPR.Columns("AJIPCLSE").HeaderText = "Sector"
                Me.dgvAJUSIMPR.Columns("AJIPVIGE").HeaderText = "Vigencia"
                Me.dgvAJUSIMPR.Columns("ESTADESC").HeaderText = "Estado"

                Me.dgvAJUSIMPR.Columns("AJIPIDRE").Visible = False
                Me.dgvAJUSIMPR.Columns("AJIPNUFI").Visible = False

                Me.dgvAJUSIMPR.Columns("AJIPDEPA").Visible = False
                Me.dgvAJUSIMPR.Columns("AJIPMAIN").Visible = False
                Me.dgvAJUSIMPR.Columns("AJIPFECH").Visible = False
                Me.dgvAJUSIMPR.Columns("AJIPCLAS").Visible = False
                Me.dgvAJUSIMPR.Columns("AJIPTITR").Visible = False
                Me.dgvAJUSIMPR.Columns("AJIPMERE").Visible = False
                Me.dgvAJUSIMPR.Columns("AJIPREAJ").Visible = False
                Me.dgvAJUSIMPR.Columns("AJIPREMI").Visible = False
                Me.dgvAJUSIMPR.Columns("AJIPFECR").Visible = False
                Me.dgvAJUSIMPR.Columns("AJIPDEST").Visible = False
                Me.dgvAJUSIMPR.Columns("AJIPFECD").Visible = False
                Me.dgvAJUSIMPR.Columns("AJIPNUDO").Visible = False
                Me.dgvAJUSIMPR.Columns("AJIPUSUR").Visible = False
                Me.dgvAJUSIMPR.Columns("AJIPUSUD").Visible = False
                Me.dgvAJUSIMPR.Columns("AJIPNURA").Visible = False
                Me.dgvAJUSIMPR.Columns("AJIPFERA").Visible = False
                Me.dgvAJUSIMPR.Columns("AJIPNURE").Visible = False
                Me.dgvAJUSIMPR.Columns("AJIPFERE").Visible = False
                Me.dgvAJUSIMPR.Columns("AJIPNUOF").Visible = False
                Me.dgvAJUSIMPR.Columns("AJIPFEOF").Visible = False
                Me.dgvAJUSIMPR.Columns("AJIPOBSE").Visible = False
                Me.dgvAJUSIMPR.Columns("AJIPESTA").Visible = False
                Me.dgvAJUSIMPR.Columns("AJIPESTR").Visible = False

            Else
                Me.dgvTRAMASIG.DataSource = New DataTable
            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub pro_ReconsultarAjustesPendientesPorTramite()

        Try
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
            ParametrosConsulta += "AJIPIDRE, "
            ParametrosConsulta += "AJIPNUFI, "
            ParametrosConsulta += "AJIPSECU, "
            ParametrosConsulta += "AJIPDEPA, "
            ParametrosConsulta += "AJIPMUNI, "
            ParametrosConsulta += "AJIPCORR, "
            ParametrosConsulta += "AJIPBARR, "
            ParametrosConsulta += "AJIPMANZ, "
            ParametrosConsulta += "AJIPPRED, "
            ParametrosConsulta += "AJIPEDIF, "
            ParametrosConsulta += "AJIPUNPR, "
            ParametrosConsulta += "AJIPCLSE, "
            ParametrosConsulta += "AJIPVIGE, "
            ParametrosConsulta += "ESTADESC, "
            ParametrosConsulta += "AJIPMAIN, "
            ParametrosConsulta += "AJIPFECH, "
            ParametrosConsulta += "AJIPCLAS, "
            ParametrosConsulta += "AJIPTITR, "
            ParametrosConsulta += "AJIPMERE, "
            ParametrosConsulta += "AJIPREAJ, "
            ParametrosConsulta += "AJIPREMI, "
            ParametrosConsulta += "AJIPFECR, "
            ParametrosConsulta += "AJIPDEST, "
            ParametrosConsulta += "AJIPFECD, "
            ParametrosConsulta += "AJIPNUDO, "
            ParametrosConsulta += "AJIPUSUR, "
            ParametrosConsulta += "AJIPNURA, "
            ParametrosConsulta += "AJIPFERA, "
            ParametrosConsulta += "AJIPNURE, "
            ParametrosConsulta += "AJIPFERE, "
            ParametrosConsulta += "AJIPNUOF, "
            ParametrosConsulta += "AJIPFEOF, "
            ParametrosConsulta += "AJIPOBSE, "
            ParametrosConsulta += "AJIPESTA, "
            ParametrosConsulta += "AJIPESTR, "
            ParametrosConsulta += "AJIPUSUD "

            ParametrosConsulta += "FROM "
            ParametrosConsulta += "AJUSIMPR, ESTADO "

            ParametrosConsulta += "WHERE "
            ParametrosConsulta += "AJIPESTR = ESTACODI AND "
            ParametrosConsulta += "AJIPDEST = '" & CStr(Trim(vp_cedula)) & "' AND "
            ParametrosConsulta += "AJIPSECU = '" & CStr(Trim(Me.dgvTRAMPEND.SelectedRows.Item(0).Cells("AJIPSECU").Value.ToString)) & "' AND "
            ParametrosConsulta += "AJIPESTR = 'as' "

            ParametrosConsulta += "ORDER BY "
            ParametrosConsulta += "AJIPSECU "

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

            If dt.Rows.Count > 0 Then

                Me.dgvAJUSIMPR.DataSource = dt

                Me.dgvAJUSIMPR.Columns("AJIPIDRE").HeaderText = "idre"

                Me.dgvAJUSIMPR.Columns("AJIPSECU").HeaderText = "Nro. Tramite"
                Me.dgvAJUSIMPR.Columns("AJIPDEPA").HeaderText = "Departamento"
                Me.dgvAJUSIMPR.Columns("AJIPMUNI").HeaderText = "Municipio"
                Me.dgvAJUSIMPR.Columns("AJIPCORR").HeaderText = "Correg."
                Me.dgvAJUSIMPR.Columns("AJIPBARR").HeaderText = "Barrio"
                Me.dgvAJUSIMPR.Columns("AJIPMANZ").HeaderText = "Manzana Vereda"
                Me.dgvAJUSIMPR.Columns("AJIPEDIF").HeaderText = "Edificio"
                Me.dgvAJUSIMPR.Columns("AJIPUNPR").HeaderText = "Unidad Predial"
                Me.dgvAJUSIMPR.Columns("AJIPPRED").HeaderText = "Predio"
                Me.dgvAJUSIMPR.Columns("AJIPCLSE").HeaderText = "Sector"
                Me.dgvAJUSIMPR.Columns("AJIPVIGE").HeaderText = "Vigencia"
                Me.dgvAJUSIMPR.Columns("ESTADESC").HeaderText = "Estado"

                Me.dgvAJUSIMPR.Columns("AJIPIDRE").Visible = False
                Me.dgvAJUSIMPR.Columns("AJIPNUFI").Visible = False

                Me.dgvAJUSIMPR.Columns("AJIPDEPA").Visible = False
                Me.dgvAJUSIMPR.Columns("AJIPMAIN").Visible = False
                Me.dgvAJUSIMPR.Columns("AJIPFECH").Visible = False
                Me.dgvAJUSIMPR.Columns("AJIPCLAS").Visible = False
                Me.dgvAJUSIMPR.Columns("AJIPTITR").Visible = False
                Me.dgvAJUSIMPR.Columns("AJIPMERE").Visible = False
                Me.dgvAJUSIMPR.Columns("AJIPREAJ").Visible = False
                Me.dgvAJUSIMPR.Columns("AJIPREMI").Visible = False
                Me.dgvAJUSIMPR.Columns("AJIPFECR").Visible = False
                Me.dgvAJUSIMPR.Columns("AJIPDEST").Visible = False
                Me.dgvAJUSIMPR.Columns("AJIPFECD").Visible = False
                Me.dgvAJUSIMPR.Columns("AJIPNUDO").Visible = False
                Me.dgvAJUSIMPR.Columns("AJIPUSUR").Visible = False
                Me.dgvAJUSIMPR.Columns("AJIPUSUD").Visible = False
                Me.dgvAJUSIMPR.Columns("AJIPNURA").Visible = False
                Me.dgvAJUSIMPR.Columns("AJIPFERA").Visible = False
                Me.dgvAJUSIMPR.Columns("AJIPNURE").Visible = False
                Me.dgvAJUSIMPR.Columns("AJIPFERE").Visible = False
                Me.dgvAJUSIMPR.Columns("AJIPNUOF").Visible = False
                Me.dgvAJUSIMPR.Columns("AJIPFEOF").Visible = False
                Me.dgvAJUSIMPR.Columns("AJIPOBSE").Visible = False
                Me.dgvAJUSIMPR.Columns("AJIPESTA").Visible = False
                Me.dgvAJUSIMPR.Columns("AJIPESTR").Visible = False

            Else
                Me.dgvTRAMPEND.DataSource = New DataTable
            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub pro_ReconsultarAjustesFinalizadosPorTramite()

        Try
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
            ParametrosConsulta += "AJIPIDRE, "
            ParametrosConsulta += "AJIPNUFI, "
            ParametrosConsulta += "AJIPSECU, "
            ParametrosConsulta += "AJIPDEPA, "
            ParametrosConsulta += "AJIPMUNI, "
            ParametrosConsulta += "AJIPCORR, "
            ParametrosConsulta += "AJIPBARR, "
            ParametrosConsulta += "AJIPMANZ, "
            ParametrosConsulta += "AJIPPRED, "
            ParametrosConsulta += "AJIPEDIF, "
            ParametrosConsulta += "AJIPUNPR, "
            ParametrosConsulta += "AJIPCLSE, "
            ParametrosConsulta += "AJIPVIGE, "
            ParametrosConsulta += "ESTADESC, "
            ParametrosConsulta += "AJIPMAIN, "
            ParametrosConsulta += "AJIPFECH, "
            ParametrosConsulta += "AJIPCLAS, "
            ParametrosConsulta += "AJIPTITR, "
            ParametrosConsulta += "AJIPMERE, "
            ParametrosConsulta += "AJIPREAJ, "
            ParametrosConsulta += "AJIPREMI, "
            ParametrosConsulta += "AJIPFECR, "
            ParametrosConsulta += "AJIPDEST, "
            ParametrosConsulta += "AJIPFECD, "
            ParametrosConsulta += "AJIPNUDO, "
            ParametrosConsulta += "AJIPUSUR, "
            ParametrosConsulta += "AJIPNURA, "
            ParametrosConsulta += "AJIPFERA, "
            ParametrosConsulta += "AJIPNURE, "
            ParametrosConsulta += "AJIPFERE, "
            ParametrosConsulta += "AJIPNUOF, "
            ParametrosConsulta += "AJIPFEOF, "
            ParametrosConsulta += "AJIPOBSE, "
            ParametrosConsulta += "AJIPESTA, "
            ParametrosConsulta += "AJIPESTR, "
            ParametrosConsulta += "AJIPUSUD "

            ParametrosConsulta += "FROM "
            ParametrosConsulta += "AJUSIMPR, ESTADO "

            ParametrosConsulta += "WHERE "
            ParametrosConsulta += "AJIPESTR = ESTACODI AND "
            ParametrosConsulta += "AJIPSECU = '" & CStr(Trim(Me.dgvTRAMFINA.SelectedRows.Item(0).Cells("AJIPSECU").Value.ToString)) & "' AND "
            ParametrosConsulta += "AJIPESTR = 'fi' "

            ParametrosConsulta += "ORDER BY "
            ParametrosConsulta += "AJIPSECU "

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

            If dt.Rows.Count > 0 Then

                Me.dgvAJUSIMPR.DataSource = dt

                Me.dgvAJUSIMPR.Columns("AJIPIDRE").HeaderText = "idre"

                Me.dgvAJUSIMPR.Columns("AJIPSECU").HeaderText = "Nro. Tramite"
                Me.dgvAJUSIMPR.Columns("AJIPDEPA").HeaderText = "Departamento"
                Me.dgvAJUSIMPR.Columns("AJIPMUNI").HeaderText = "Municipio"
                Me.dgvAJUSIMPR.Columns("AJIPCORR").HeaderText = "Correg."
                Me.dgvAJUSIMPR.Columns("AJIPBARR").HeaderText = "Barrio"
                Me.dgvAJUSIMPR.Columns("AJIPMANZ").HeaderText = "Manzana Vereda"
                Me.dgvAJUSIMPR.Columns("AJIPEDIF").HeaderText = "Edificio"
                Me.dgvAJUSIMPR.Columns("AJIPUNPR").HeaderText = "Unidad Predial"
                Me.dgvAJUSIMPR.Columns("AJIPPRED").HeaderText = "Predio"
                Me.dgvAJUSIMPR.Columns("AJIPCLSE").HeaderText = "Sector"
                Me.dgvAJUSIMPR.Columns("AJIPVIGE").HeaderText = "Vigencia"
                Me.dgvAJUSIMPR.Columns("ESTADESC").HeaderText = "Estado"

                Me.dgvAJUSIMPR.Columns("AJIPIDRE").Visible = False
                Me.dgvAJUSIMPR.Columns("AJIPNUFI").Visible = False

                Me.dgvAJUSIMPR.Columns("AJIPDEPA").Visible = False
                Me.dgvAJUSIMPR.Columns("AJIPMAIN").Visible = False
                Me.dgvAJUSIMPR.Columns("AJIPFECH").Visible = False
                Me.dgvAJUSIMPR.Columns("AJIPCLAS").Visible = False
                Me.dgvAJUSIMPR.Columns("AJIPTITR").Visible = False
                Me.dgvAJUSIMPR.Columns("AJIPMERE").Visible = False
                Me.dgvAJUSIMPR.Columns("AJIPREAJ").Visible = False
                Me.dgvAJUSIMPR.Columns("AJIPREMI").Visible = False
                Me.dgvAJUSIMPR.Columns("AJIPFECR").Visible = False
                Me.dgvAJUSIMPR.Columns("AJIPDEST").Visible = False
                Me.dgvAJUSIMPR.Columns("AJIPFECD").Visible = False
                Me.dgvAJUSIMPR.Columns("AJIPNUDO").Visible = False
                Me.dgvAJUSIMPR.Columns("AJIPUSUR").Visible = False
                Me.dgvAJUSIMPR.Columns("AJIPUSUD").Visible = False
                Me.dgvAJUSIMPR.Columns("AJIPNURA").Visible = False
                Me.dgvAJUSIMPR.Columns("AJIPFERA").Visible = False
                Me.dgvAJUSIMPR.Columns("AJIPNURE").Visible = False
                Me.dgvAJUSIMPR.Columns("AJIPFERE").Visible = False
                Me.dgvAJUSIMPR.Columns("AJIPNUOF").Visible = False
                Me.dgvAJUSIMPR.Columns("AJIPFEOF").Visible = False
                Me.dgvAJUSIMPR.Columns("AJIPOBSE").Visible = False
                Me.dgvAJUSIMPR.Columns("AJIPESTA").Visible = False
                Me.dgvAJUSIMPR.Columns("AJIPESTR").Visible = False

            Else
                Me.dgvTRAMFINA.DataSource = New DataTable
            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub

    Private Sub pro_ListaDeValoresAjustes()

        Try
            If Me.dgvAJUSIMPR.RowCount > 0 Then

                Dim objdatos As New cla_AJUSIMPR
                Dim tbl As New DataTable

                tbl = objdatos.fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_AJUSIMPR(Me.dgvAJUSIMPR.SelectedRows.Item(0).Cells("AJIPIDRE").Value.ToString)

                Dim obCONTRASENA As New cla_CONTRASENA
                Dim dtCONTRASENA As New DataTable

                dtCONTRASENA = obCONTRASENA.fun_Buscar_CODIGO_CONTRASENA(Trim(Me.dgvAJUSIMPR.SelectedRows.Item(0).Cells("AJIPNUDO").Value.ToString))

                If dtCONTRASENA.Rows.Count > 0 Then
                    Me.txtAJIPREMI.Text = Trim(dtCONTRASENA.Rows(0).Item("CONTUSUA").ToString)
                Else
                    Me.txtAJIPREMI.Text = ""
                End If

                Me.txtAJIPCLAS.Text = Trim(Me.dgvAJUSIMPR.SelectedRows.Item(0).Cells("AJIPCLAS").Value.ToString)
                Me.txtAJIPTITR.Text = Trim(Me.dgvAJUSIMPR.SelectedRows.Item(0).Cells("AJIPTITR").Value.ToString)
                Me.txtAJIPREAJ.Text = Trim(Me.dgvAJUSIMPR.SelectedRows.Item(0).Cells("AJIPREAJ").Value.ToString)
                Me.txtAJIPMERE.Text = Trim(Me.dgvAJUSIMPR.SelectedRows.Item(0).Cells("AJIPMERE").Value.ToString)
                Me.txtAJIPVIGE.Text = Trim(Me.dgvAJUSIMPR.SelectedRows.Item(0).Cells("AJIPVIGE").Value.ToString)
                Me.txtAJIPNURE.Text = Trim(Me.dgvAJUSIMPR.SelectedRows.Item(0).Cells("AJIPNURE").Value.ToString)
                Me.txtAJIPFERE.Text = Trim(Me.dgvAJUSIMPR.SelectedRows.Item(0).Cells("AJIPFERE").Value.ToString)
                Me.txtAJIPNURA.Text = Trim(Me.dgvAJUSIMPR.SelectedRows.Item(0).Cells("AJIPNURA").Value.ToString)
                Me.txtAJIPFERA.Text = Trim(Me.dgvAJUSIMPR.SelectedRows.Item(0).Cells("AJIPFERA").Value.ToString)
                Me.txtAJIPFECD.Text = Trim(Me.dgvAJUSIMPR.SelectedRows.Item(0).Cells("AJIPFECD").Value.ToString)
                Me.txtAJIPUSUD.Text = Trim(Me.dgvAJUSIMPR.SelectedRows.Item(0).Cells("AJIPUSUD").Value.ToString)

                Me.txtAJIPNUOF.Text = Trim(Me.dgvAJUSIMPR.SelectedRows.Item(0).Cells("AJIPNUOF").Value.ToString)
                Me.txtAJIPFEOF.Text = Trim(Me.dgvAJUSIMPR.SelectedRows.Item(0).Cells("AJIPFEOF").Value.ToString)
                Me.txtAJIPSECU.Text = Trim(Me.dgvAJUSIMPR.SelectedRows.Item(0).Cells("AJIPSECU").Value.ToString)
                Me.txtAJIPFECH.Text = Trim(Me.dgvAJUSIMPR.SelectedRows.Item(0).Cells("AJIPFECH").Value.ToString)
                Me.txtAJIPNUFI.Text = Trim(Me.dgvAJUSIMPR.SelectedRows.Item(0).Cells("AJIPNUFI").Value.ToString)
                Me.txtAJIPMAIN.Text = Trim(Me.dgvAJUSIMPR.SelectedRows.Item(0).Cells("AJIPMAIN").Value.ToString)
                Me.txtAJIPOBSE.Text = Trim(tbl.Rows(0).Item("AJIPOBSE").ToString)

                Me.lblAJIPMUNI.Text = CType(fun_Buscar_Lista_Valores_MUNICIPIO(Me.dgvAJUSIMPR.SelectedRows.Item(0).Cells("AJIPDEPA").Value.ToString, Me.dgvAJUSIMPR.SelectedRows.Item(0).Cells("AJIPMUNI").Value.ToString), String)
                Me.lblAJIPCORR.Text = CType(fun_Buscar_Lista_Valores_CORREGIMIENTO(Me.dgvAJUSIMPR.SelectedRows.Item(0).Cells("AJIPDEPA").Value.ToString, Me.dgvAJUSIMPR.SelectedRows.Item(0).Cells("AJIPMUNI").Value.ToString, Me.dgvAJUSIMPR.SelectedRows.Item(0).Cells("AJIPCLSE").Value.ToString, Me.dgvAJUSIMPR.SelectedRows.Item(0).Cells("AJIPCORR").Value.ToString), String)

                If CInt(Me.dgvAJUSIMPR.SelectedRows.Item(0).Cells("AJIPCLSE").Value.ToString) = 1 Then
                    Me.lblAJIPBAVE.Text = CType(fun_Buscar_Lista_Valores_BARRIO(Me.dgvAJUSIMPR.SelectedRows.Item(0).Cells("AJIPDEPA").Value.ToString, Me.dgvAJUSIMPR.SelectedRows.Item(0).Cells("AJIPMUNI").Value.ToString, Me.dgvAJUSIMPR.SelectedRows.Item(0).Cells("AJIPCLSE").Value.ToString, Me.dgvAJUSIMPR.SelectedRows.Item(0).Cells("AJIPBARR").Value.ToString, Me.dgvAJUSIMPR.SelectedRows.Item(0).Cells("AJIPCORR").Value.ToString), String)
                ElseIf CInt(Me.dgvAJUSIMPR.SelectedRows.Item(0).Cells("AJIPCLSE").Value.ToString) = 2 Then
                    Me.lblAJIPBAVE.Text = CType(fun_Buscar_Lista_Valores_VEREDA(Me.dgvAJUSIMPR.SelectedRows.Item(0).Cells("AJIPDEPA").Value.ToString, Me.dgvAJUSIMPR.SelectedRows.Item(0).Cells("AJIPMUNI").Value.ToString, Me.dgvAJUSIMPR.SelectedRows.Item(0).Cells("AJIPCLSE").Value.ToString, Me.dgvAJUSIMPR.SelectedRows.Item(0).Cells("AJIPMANZ").Value.ToString, Me.dgvAJUSIMPR.SelectedRows.Item(0).Cells("AJIPCORR").Value.ToString), String)
                ElseIf CInt(Me.dgvAJUSIMPR.SelectedRows.Item(0).Cells("AJIPCLSE").Value.ToString) = 3 Then
                    Me.lblAJIPBAVE.Text = CType(fun_Buscar_Lista_Valores_BARRIO(Me.dgvAJUSIMPR.SelectedRows.Item(0).Cells("AJIPDEPA").Value.ToString, Me.dgvAJUSIMPR.SelectedRows.Item(0).Cells("AJIPMUNI").Value.ToString, Me.dgvAJUSIMPR.SelectedRows.Item(0).Cells("AJIPCLSE").Value.ToString, Me.dgvAJUSIMPR.SelectedRows.Item(0).Cells("AJIPBARR").Value.ToString, Me.dgvAJUSIMPR.SelectedRows.Item(0).Cells("AJIPCORR").Value.ToString), String)
                End If

                Me.lblAJIPCLSE.Text = CType(fun_Buscar_Lista_Valores_CLASSECT(Me.dgvAJUSIMPR.SelectedRows.Item(0).Cells("AJIPCLSE").Value.ToString), String)
                Me.lblAJIPCLAS.Text = CType(fun_Buscar_Lista_Valores_CLASIFICACION(Me.dgvAJUSIMPR.SelectedRows.Item(0).Cells("AJIPCLAS").Value.ToString), String)
                Me.lblAJIPMERE.Text = CType(fun_Buscar_Lista_Valores_MEDIRESE(Me.dgvAJUSIMPR.SelectedRows.Item(0).Cells("AJIPMERE").Value.ToString), String)
                Me.lblAJIPREAJ.Text = CType(fun_Buscar_Lista_Valores_RESOAJUS(Me.dgvAJUSIMPR.SelectedRows.Item(0).Cells("AJIPREAJ").Value.ToString), String)
                Me.lblAJIPREMI.Text = CType(fun_Buscar_Lista_Valores_USUARIO(Me.dgvAJUSIMPR.SelectedRows.Item(0).Cells("AJIPNUDO").Value.ToString), String)
                Me.lblAJIPDEST.Text = CType(fun_Buscar_Lista_Valores_USUARIO(Me.dgvAJUSIMPR.SelectedRows.Item(0).Cells("AJIPDEST").Value.ToString), String)
                Me.lblAJIPTITR.Text = CType(fun_Buscar_Lista_Valores_TIPOTRAM(Me.dgvAJUSIMPR.SelectedRows.Item(0).Cells("AJIPTITR").Value.ToString), String)
                Me.lblAJIPVIGE.Text = CType(fun_Buscar_Lista_Valores_VIGENCIA(Me.dgvAJUSIMPR.SelectedRows.Item(0).Cells("AJIPVIGE").Value.ToString), String)

                pro_ReconsultarAjustesRegistrados()
                pro_ReconsultarAjustesAsignados()
                pro_ReconsultarAjustesPendientes()

                pro_ListadoArchivosDocumentosRectificacion()
                pro_ListadoArchivosDocumentosAjuste()
                pro_ListadoArchivosImagenes()
                pro_ListadoArchivosResolucion()

                pro_ReconsultarInformacionDeUsuario()
                pro_ListaDeValoresInformacionDeUsuario()

                pro_ReconsultarMaterialDeUsuario()
                pro_ListaDeValoresMaterialDeUsuario()

                pro_ReconsultarMaterialDeCatastro()
                pro_ListaDeValoresMaterialDeCatastro()

                pro_ContarTramites()

            Else
                pro_LimpiarCamposAjuste()
                pro_LimpiarDocumentos()

                pro_LimpiarInformacionUsuario()
                pro_LimpiarMaterialUsuario()
                pro_LimpiarMaterialCatastro()

                Me.BindingNavigator_AJIPINUS_1.Enabled = False
                Me.BindingNavigator_AJIPMAUS_1.Enabled = False
                Me.BindingNavigator_AJIPMACA_1.Enabled = False

            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub

    Private Sub pro_ListaDeValoresAjustesTramitesRegistrados()

        Try
            If Me.dgvTRAMREGI.RowCount > 0 Then

                Dim objdatos As New cla_AJUSIMPR
                Dim tbl As New DataTable

                tbl = objdatos.fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_AJUSIMPR(Me.dgvTRAMREGI.SelectedRows.Item(0).Cells("AJIPIDRE").Value.ToString)

                Dim obCONTRASENA As New cla_CONTRASENA
                Dim dtCONTRASENA As New DataTable

                dtCONTRASENA = obCONTRASENA.fun_Buscar_CODIGO_CONTRASENA(Trim(Me.dgvTRAMREGI.SelectedRows.Item(0).Cells("AJIPNUDO").Value.ToString))

                If dtCONTRASENA.Rows.Count > 0 Then
                    Me.txtAJIPREMI.Text = Trim(dtCONTRASENA.Rows(0).Item("CONTUSUA").ToString)
                Else
                    Me.txtAJIPREMI.Text = ""
                End If

                Me.txtAJIPCLAS.Text = Trim(Me.dgvTRAMREGI.SelectedRows.Item(0).Cells("AJIPCLAS").Value.ToString)
                Me.txtAJIPTITR.Text = Trim(Me.dgvTRAMREGI.SelectedRows.Item(0).Cells("AJIPTITR").Value.ToString)
                Me.txtAJIPREAJ.Text = Trim(Me.dgvTRAMREGI.SelectedRows.Item(0).Cells("AJIPREAJ").Value.ToString)
                Me.txtAJIPMERE.Text = Trim(Me.dgvTRAMREGI.SelectedRows.Item(0).Cells("AJIPMERE").Value.ToString)
                Me.txtAJIPVIGE.Text = Trim(Me.dgvTRAMREGI.SelectedRows.Item(0).Cells("AJIPVIGE").Value.ToString)
                Me.txtAJIPNURE.Text = Trim(Me.dgvTRAMREGI.SelectedRows.Item(0).Cells("AJIPNURE").Value.ToString)
                Me.txtAJIPFERE.Text = Trim(Me.dgvTRAMREGI.SelectedRows.Item(0).Cells("AJIPFERE").Value.ToString)
                Me.txtAJIPNURA.Text = Trim(Me.dgvTRAMREGI.SelectedRows.Item(0).Cells("AJIPNURA").Value.ToString)
                Me.txtAJIPFERA.Text = Trim(Me.dgvTRAMREGI.SelectedRows.Item(0).Cells("AJIPFERA").Value.ToString)

                Me.txtAJIPNUOF.Text = Trim(Me.dgvTRAMREGI.SelectedRows.Item(0).Cells("AJIPNUOF").Value.ToString)
                Me.txtAJIPFEOF.Text = Trim(Me.dgvTRAMREGI.SelectedRows.Item(0).Cells("AJIPFEOF").Value.ToString)
                Me.txtAJIPSECU.Text = Trim(Me.dgvTRAMREGI.SelectedRows.Item(0).Cells("AJIPSECU").Value.ToString)
                Me.txtAJIPFECH.Text = Trim(Me.dgvTRAMREGI.SelectedRows.Item(0).Cells("AJIPFECH").Value.ToString)
                Me.txtAJIPNUFI.Text = Trim(Me.dgvTRAMREGI.SelectedRows.Item(0).Cells("AJIPNUFI").Value.ToString)
                Me.txtAJIPMAIN.Text = Trim(Me.dgvTRAMREGI.SelectedRows.Item(0).Cells("AJIPMAIN").Value.ToString)
                Me.txtAJIPOBSE.Text = Trim(Me.dgvTRAMREGI.SelectedRows.Item(0).Cells("AJIPOBSE").Value.ToString)

                Me.lblAJIPMUNI.Text = CType(fun_Buscar_Lista_Valores_MUNICIPIO(Me.dgvTRAMREGI.SelectedRows.Item(0).Cells("AJIPDEPA").Value.ToString, Me.dgvTRAMREGI.SelectedRows.Item(0).Cells("AJIPMUNI").Value.ToString), String)
                Me.lblAJIPCORR.Text = CType(fun_Buscar_Lista_Valores_CORREGIMIENTO(Me.dgvTRAMREGI.SelectedRows.Item(0).Cells("AJIPDEPA").Value.ToString, Me.dgvTRAMREGI.SelectedRows.Item(0).Cells("AJIPMUNI").Value.ToString, Me.dgvTRAMREGI.SelectedRows.Item(0).Cells("AJIPCLSE").Value.ToString, Me.dgvTRAMREGI.SelectedRows.Item(0).Cells("AJIPCORR").Value.ToString), String)

                If CInt(Me.dgvTRAMREGI.SelectedRows.Item(0).Cells("AJIPCLSE").Value.ToString) = 1 Then
                    Me.lblAJIPBAVE.Text = CType(fun_Buscar_Lista_Valores_BARRIO(Me.dgvTRAMREGI.SelectedRows.Item(0).Cells("AJIPDEPA").Value.ToString, Me.dgvTRAMREGI.SelectedRows.Item(0).Cells("AJIPMUNI").Value.ToString, Me.dgvTRAMREGI.SelectedRows.Item(0).Cells("AJIPCLSE").Value.ToString, Me.dgvTRAMREGI.SelectedRows.Item(0).Cells("AJIPBARR").Value.ToString, Me.dgvTRAMREGI.SelectedRows.Item(0).Cells("AJIPCORR").Value.ToString), String)
                ElseIf CInt(Me.dgvTRAMREGI.SelectedRows.Item(0).Cells("AJIPCLSE").Value.ToString) = 2 Then
                    Me.lblAJIPBAVE.Text = CType(fun_Buscar_Lista_Valores_VEREDA(Me.dgvTRAMREGI.SelectedRows.Item(0).Cells("AJIPDEPA").Value.ToString, Me.dgvTRAMREGI.SelectedRows.Item(0).Cells("AJIPMUNI").Value.ToString, Me.dgvTRAMREGI.SelectedRows.Item(0).Cells("AJIPCLSE").Value.ToString, Me.dgvTRAMREGI.SelectedRows.Item(0).Cells("AJIPMANZ").Value.ToString, Me.dgvTRAMREGI.SelectedRows.Item(0).Cells("AJIPCORR").Value.ToString), String)
                ElseIf CInt(Me.dgvTRAMREGI.SelectedRows.Item(0).Cells("AJIPCLSE").Value.ToString) = 3 Then
                    Me.lblAJIPBAVE.Text = CType(fun_Buscar_Lista_Valores_BARRIO(Me.dgvTRAMREGI.SelectedRows.Item(0).Cells("AJIPDEPA").Value.ToString, Me.dgvTRAMREGI.SelectedRows.Item(0).Cells("AJIPMUNI").Value.ToString, Me.dgvTRAMREGI.SelectedRows.Item(0).Cells("AJIPCLSE").Value.ToString, Me.dgvTRAMREGI.SelectedRows.Item(0).Cells("AJIPBARR").Value.ToString, Me.dgvTRAMREGI.SelectedRows.Item(0).Cells("AJIPCORR").Value.ToString), String)
                End If

                Me.lblAJIPCLSE.Text = CType(fun_Buscar_Lista_Valores_CLASSECT(Me.dgvTRAMREGI.SelectedRows.Item(0).Cells("AJIPCLSE").Value.ToString), String)
                Me.lblAJIPCLAS.Text = CType(fun_Buscar_Lista_Valores_CLASIFICACION(Me.dgvTRAMREGI.SelectedRows.Item(0).Cells("AJIPCLAS").Value.ToString), String)
                Me.lblAJIPMERE.Text = CType(fun_Buscar_Lista_Valores_MEDIRESE(Me.dgvTRAMREGI.SelectedRows.Item(0).Cells("AJIPMERE").Value.ToString), String)
                Me.lblAJIPREAJ.Text = CType(fun_Buscar_Lista_Valores_RESOAJUS(Me.dgvTRAMREGI.SelectedRows.Item(0).Cells("AJIPREAJ").Value.ToString), String)
                Me.lblAJIPREMI.Text = CType(fun_Buscar_Lista_Valores_USUARIO(Me.dgvTRAMREGI.SelectedRows.Item(0).Cells("AJIPNUDO").Value.ToString), String)
                Me.lblAJIPTITR.Text = CType(fun_Buscar_Lista_Valores_TIPOTRAM(Me.dgvTRAMREGI.SelectedRows.Item(0).Cells("AJIPTITR").Value.ToString), String)
                Me.lblAJIPVIGE.Text = CType(fun_Buscar_Lista_Valores_VIGENCIA(Me.dgvTRAMREGI.SelectedRows.Item(0).Cells("AJIPVIGE").Value.ToString), String)

                pro_ContarTramites()
            Else
                pro_LimpiarCamposAjusteTramitesRegistrados()

            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub pro_ListaDeValoresAjustesTramitesAsignados()

        Try
            If Me.dgvTRAMASIG.RowCount > 0 Then

                Dim objdatos As New cla_AJUSIMPR
                Dim tbl As New DataTable

                tbl = objdatos.fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_AJUSIMPR(Me.dgvTRAMASIG.SelectedRows.Item(0).Cells("AJIPIDRE").Value.ToString)

                Dim obCONTRASENA As New cla_CONTRASENA
                Dim dtCONTRASENA As New DataTable

                dtCONTRASENA = obCONTRASENA.fun_Buscar_CODIGO_CONTRASENA(Trim(Me.dgvTRAMASIG.SelectedRows.Item(0).Cells("AJIPNUDO").Value.ToString))

                If dtCONTRASENA.Rows.Count > 0 Then
                    Me.txtAJIPREMI.Text = Trim(dtCONTRASENA.Rows(0).Item("CONTUSUA").ToString)
                Else
                    Me.txtAJIPREMI.Text = ""
                End If

                Me.txtAJIPCLAS.Text = Trim(Me.dgvTRAMASIG.SelectedRows.Item(0).Cells("AJIPCLAS").Value.ToString)
                Me.txtAJIPTITR.Text = Trim(Me.dgvTRAMASIG.SelectedRows.Item(0).Cells("AJIPTITR").Value.ToString)
                Me.txtAJIPREAJ.Text = Trim(Me.dgvTRAMASIG.SelectedRows.Item(0).Cells("AJIPREAJ").Value.ToString)
                Me.txtAJIPMERE.Text = Trim(Me.dgvTRAMASIG.SelectedRows.Item(0).Cells("AJIPMERE").Value.ToString)
                Me.txtAJIPVIGE.Text = Trim(Me.dgvTRAMASIG.SelectedRows.Item(0).Cells("AJIPVIGE").Value.ToString)
                Me.txtAJIPNURE.Text = Trim(Me.dgvTRAMASIG.SelectedRows.Item(0).Cells("AJIPNURE").Value.ToString)
                Me.txtAJIPFERE.Text = Trim(Me.dgvTRAMASIG.SelectedRows.Item(0).Cells("AJIPFERE").Value.ToString)
                Me.txtAJIPNURA.Text = Trim(Me.dgvTRAMASIG.SelectedRows.Item(0).Cells("AJIPNURA").Value.ToString)
                Me.txtAJIPFERA.Text = Trim(Me.dgvTRAMASIG.SelectedRows.Item(0).Cells("AJIPFERA").Value.ToString)

                Me.txtAJIPNUOF.Text = Trim(Me.dgvTRAMASIG.SelectedRows.Item(0).Cells("AJIPNUOF").Value.ToString)
                Me.txtAJIPFEOF.Text = Trim(Me.dgvTRAMASIG.SelectedRows.Item(0).Cells("AJIPFEOF").Value.ToString)
                Me.txtAJIPSECU.Text = Trim(Me.dgvTRAMASIG.SelectedRows.Item(0).Cells("AJIPSECU").Value.ToString)
                Me.txtAJIPFECH.Text = Trim(Me.dgvTRAMASIG.SelectedRows.Item(0).Cells("AJIPFECH").Value.ToString)
                Me.txtAJIPNUFI.Text = Trim(Me.dgvTRAMASIG.SelectedRows.Item(0).Cells("AJIPNUFI").Value.ToString)
                Me.txtAJIPMAIN.Text = Trim(Me.dgvTRAMASIG.SelectedRows.Item(0).Cells("AJIPMAIN").Value.ToString)
                Me.txtAJIPOBSE.Text = Trim(Me.dgvTRAMASIG.SelectedRows.Item(0).Cells("AJIPOBSE").Value.ToString)

                Me.lblAJIPMUNI.Text = CType(fun_Buscar_Lista_Valores_MUNICIPIO(Me.dgvTRAMASIG.SelectedRows.Item(0).Cells("AJIPDEPA").Value.ToString, Me.dgvTRAMASIG.SelectedRows.Item(0).Cells("AJIPMUNI").Value.ToString), String)
                Me.lblAJIPCORR.Text = CType(fun_Buscar_Lista_Valores_CORREGIMIENTO(Me.dgvTRAMASIG.SelectedRows.Item(0).Cells("AJIPDEPA").Value.ToString, Me.dgvTRAMASIG.SelectedRows.Item(0).Cells("AJIPMUNI").Value.ToString, Me.dgvTRAMASIG.SelectedRows.Item(0).Cells("AJIPCLSE").Value.ToString, Me.dgvTRAMASIG.SelectedRows.Item(0).Cells("AJIPCORR").Value.ToString), String)

                If CInt(Me.dgvTRAMASIG.SelectedRows.Item(0).Cells("AJIPCLSE").Value.ToString) = 1 Then
                    Me.lblAJIPBAVE.Text = CType(fun_Buscar_Lista_Valores_BARRIO(Me.dgvTRAMASIG.SelectedRows.Item(0).Cells("AJIPDEPA").Value.ToString, Me.dgvTRAMASIG.SelectedRows.Item(0).Cells("AJIPMUNI").Value.ToString, Me.dgvTRAMASIG.SelectedRows.Item(0).Cells("AJIPCLSE").Value.ToString, Me.dgvTRAMASIG.SelectedRows.Item(0).Cells("AJIPBARR").Value.ToString, Me.dgvTRAMASIG.SelectedRows.Item(0).Cells("AJIPCORR").Value.ToString), String)
                ElseIf CInt(Me.dgvTRAMASIG.SelectedRows.Item(0).Cells("AJIPCLSE").Value.ToString) = 2 Then
                    Me.lblAJIPBAVE.Text = CType(fun_Buscar_Lista_Valores_VEREDA(Me.dgvTRAMASIG.SelectedRows.Item(0).Cells("AJIPDEPA").Value.ToString, Me.dgvTRAMASIG.SelectedRows.Item(0).Cells("AJIPMUNI").Value.ToString, Me.dgvTRAMASIG.SelectedRows.Item(0).Cells("AJIPCLSE").Value.ToString, Me.dgvTRAMASIG.SelectedRows.Item(0).Cells("AJIPMANZ").Value.ToString, Me.dgvTRAMASIG.SelectedRows.Item(0).Cells("AJIPCORR").Value.ToString), String)
                ElseIf CInt(Me.dgvTRAMASIG.SelectedRows.Item(0).Cells("AJIPCLSE").Value.ToString) = 3 Then
                    Me.lblAJIPBAVE.Text = CType(fun_Buscar_Lista_Valores_BARRIO(Me.dgvTRAMASIG.SelectedRows.Item(0).Cells("AJIPDEPA").Value.ToString, Me.dgvTRAMASIG.SelectedRows.Item(0).Cells("AJIPMUNI").Value.ToString, Me.dgvTRAMASIG.SelectedRows.Item(0).Cells("AJIPCLSE").Value.ToString, Me.dgvTRAMASIG.SelectedRows.Item(0).Cells("AJIPBARR").Value.ToString, Me.dgvTRAMASIG.SelectedRows.Item(0).Cells("AJIPCORR").Value.ToString), String)
                End If

                Me.lblAJIPCLSE.Text = CType(fun_Buscar_Lista_Valores_CLASSECT(Me.dgvTRAMASIG.SelectedRows.Item(0).Cells("AJIPCLSE").Value.ToString), String)
                Me.lblAJIPCLAS.Text = CType(fun_Buscar_Lista_Valores_CLASIFICACION(Me.dgvTRAMASIG.SelectedRows.Item(0).Cells("AJIPCLAS").Value.ToString), String)
                Me.lblAJIPMERE.Text = CType(fun_Buscar_Lista_Valores_MEDIRESE(Me.dgvTRAMASIG.SelectedRows.Item(0).Cells("AJIPMERE").Value.ToString), String)
                Me.lblAJIPREAJ.Text = CType(fun_Buscar_Lista_Valores_RESOAJUS(Me.dgvTRAMASIG.SelectedRows.Item(0).Cells("AJIPREAJ").Value.ToString), String)
                Me.lblAJIPREMI.Text = CType(fun_Buscar_Lista_Valores_USUARIO(Me.dgvTRAMASIG.SelectedRows.Item(0).Cells("AJIPNUDO").Value.ToString), String)
                Me.lblAJIPTITR.Text = CType(fun_Buscar_Lista_Valores_TIPOTRAM(Me.dgvTRAMASIG.SelectedRows.Item(0).Cells("AJIPTITR").Value.ToString), String)
                Me.lblAJIPVIGE.Text = CType(fun_Buscar_Lista_Valores_VIGENCIA(Me.dgvTRAMASIG.SelectedRows.Item(0).Cells("AJIPVIGE").Value.ToString), String)

                pro_ContarTramites()
            Else
                pro_LimpiarCamposAjusteTramitesAsignados()

            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub pro_ListaDeValoresAjustesTramitesPendientes()

        Try
            If Me.dgvTRAMPEND.RowCount > 0 Then

                Dim objdatos As New cla_AJUSIMPR
                Dim tbl As New DataTable

                tbl = objdatos.fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_AJUSIMPR(Me.dgvTRAMPEND.SelectedRows.Item(0).Cells("AJIPIDRE").Value.ToString)

                Dim obCONTRASENA As New cla_CONTRASENA
                Dim dtCONTRASENA As New DataTable

                dtCONTRASENA = obCONTRASENA.fun_Buscar_CODIGO_CONTRASENA(Trim(Me.dgvTRAMPEND.SelectedRows.Item(0).Cells("AJIPNUDO").Value.ToString))

                If dtCONTRASENA.Rows.Count > 0 Then
                    Me.txtAJIPREMI.Text = Trim(dtCONTRASENA.Rows(0).Item("CONTUSUA").ToString)
                Else
                    Me.txtAJIPREMI.Text = ""
                End If

                Me.txtAJIPCLAS.Text = Trim(Me.dgvTRAMPEND.SelectedRows.Item(0).Cells("AJIPCLAS").Value.ToString)
                Me.txtAJIPTITR.Text = Trim(Me.dgvTRAMPEND.SelectedRows.Item(0).Cells("AJIPTITR").Value.ToString)
                Me.txtAJIPREAJ.Text = Trim(Me.dgvTRAMPEND.SelectedRows.Item(0).Cells("AJIPREAJ").Value.ToString)
                Me.txtAJIPMERE.Text = Trim(Me.dgvTRAMPEND.SelectedRows.Item(0).Cells("AJIPMERE").Value.ToString)
                Me.txtAJIPVIGE.Text = Trim(Me.dgvTRAMPEND.SelectedRows.Item(0).Cells("AJIPVIGE").Value.ToString)
                Me.txtAJIPNURE.Text = Trim(Me.dgvTRAMPEND.SelectedRows.Item(0).Cells("AJIPNURE").Value.ToString)
                Me.txtAJIPFERE.Text = Trim(Me.dgvTRAMPEND.SelectedRows.Item(0).Cells("AJIPFERE").Value.ToString)
                Me.txtAJIPNURA.Text = Trim(Me.dgvTRAMPEND.SelectedRows.Item(0).Cells("AJIPNURA").Value.ToString)
                Me.txtAJIPFERA.Text = Trim(Me.dgvTRAMPEND.SelectedRows.Item(0).Cells("AJIPFERA").Value.ToString)

                Me.txtAJIPNUOF.Text = Trim(Me.dgvTRAMPEND.SelectedRows.Item(0).Cells("AJIPNUOF").Value.ToString)
                Me.txtAJIPFEOF.Text = Trim(Me.dgvTRAMPEND.SelectedRows.Item(0).Cells("AJIPFEOF").Value.ToString)
                Me.txtAJIPSECU.Text = Trim(Me.dgvTRAMPEND.SelectedRows.Item(0).Cells("AJIPSECU").Value.ToString)
                Me.txtAJIPFECH.Text = Trim(Me.dgvTRAMPEND.SelectedRows.Item(0).Cells("AJIPFECH").Value.ToString)
                Me.txtAJIPNUFI.Text = Trim(Me.dgvTRAMPEND.SelectedRows.Item(0).Cells("AJIPNUFI").Value.ToString)
                Me.txtAJIPMAIN.Text = Trim(Me.dgvTRAMPEND.SelectedRows.Item(0).Cells("AJIPMAIN").Value.ToString)
                Me.txtAJIPOBSE.Text = Trim(Me.dgvTRAMPEND.SelectedRows.Item(0).Cells("AJIPOBSE").Value.ToString)

                Me.lblAJIPMUNI.Text = CType(fun_Buscar_Lista_Valores_MUNICIPIO(Me.dgvTRAMPEND.SelectedRows.Item(0).Cells("AJIPDEPA").Value.ToString, Me.dgvTRAMPEND.SelectedRows.Item(0).Cells("AJIPMUNI").Value.ToString), String)
                Me.lblAJIPCORR.Text = CType(fun_Buscar_Lista_Valores_CORREGIMIENTO(Me.dgvTRAMPEND.SelectedRows.Item(0).Cells("AJIPDEPA").Value.ToString, Me.dgvTRAMPEND.SelectedRows.Item(0).Cells("AJIPMUNI").Value.ToString, Me.dgvTRAMPEND.SelectedRows.Item(0).Cells("AJIPCLSE").Value.ToString, Me.dgvTRAMPEND.SelectedRows.Item(0).Cells("AJIPCORR").Value.ToString), String)

                If CInt(Me.dgvTRAMPEND.SelectedRows.Item(0).Cells("AJIPCLSE").Value.ToString) = 1 Then
                    Me.lblAJIPBAVE.Text = CType(fun_Buscar_Lista_Valores_BARRIO(Me.dgvTRAMPEND.SelectedRows.Item(0).Cells("AJIPDEPA").Value.ToString, Me.dgvTRAMPEND.SelectedRows.Item(0).Cells("AJIPMUNI").Value.ToString, Me.dgvTRAMPEND.SelectedRows.Item(0).Cells("AJIPCLSE").Value.ToString, Me.dgvTRAMPEND.SelectedRows.Item(0).Cells("AJIPBARR").Value.ToString, Me.dgvTRAMPEND.SelectedRows.Item(0).Cells("AJIPCORR").Value.ToString), String)
                ElseIf CInt(Me.dgvTRAMPEND.SelectedRows.Item(0).Cells("AJIPCLSE").Value.ToString) = 2 Then
                    Me.lblAJIPBAVE.Text = CType(fun_Buscar_Lista_Valores_VEREDA(Me.dgvTRAMPEND.SelectedRows.Item(0).Cells("AJIPDEPA").Value.ToString, Me.dgvTRAMPEND.SelectedRows.Item(0).Cells("AJIPMUNI").Value.ToString, Me.dgvTRAMPEND.SelectedRows.Item(0).Cells("AJIPCLSE").Value.ToString, Me.dgvTRAMPEND.SelectedRows.Item(0).Cells("AJIPMANZ").Value.ToString, Me.dgvTRAMPEND.SelectedRows.Item(0).Cells("AJIPCORR").Value.ToString), String)
                ElseIf CInt(Me.dgvTRAMPEND.SelectedRows.Item(0).Cells("AJIPCLSE").Value.ToString) = 3 Then
                    Me.lblAJIPBAVE.Text = CType(fun_Buscar_Lista_Valores_BARRIO(Me.dgvTRAMPEND.SelectedRows.Item(0).Cells("AJIPDEPA").Value.ToString, Me.dgvTRAMPEND.SelectedRows.Item(0).Cells("AJIPMUNI").Value.ToString, Me.dgvTRAMPEND.SelectedRows.Item(0).Cells("AJIPCLSE").Value.ToString, Me.dgvTRAMPEND.SelectedRows.Item(0).Cells("AJIPBARR").Value.ToString, Me.dgvTRAMPEND.SelectedRows.Item(0).Cells("AJIPCORR").Value.ToString), String)
                End If

                Me.lblAJIPCLSE.Text = CType(fun_Buscar_Lista_Valores_CLASSECT(Me.dgvTRAMPEND.SelectedRows.Item(0).Cells("AJIPCLSE").Value.ToString), String)
                Me.lblAJIPCLAS.Text = CType(fun_Buscar_Lista_Valores_CLASIFICACION(Me.dgvTRAMPEND.SelectedRows.Item(0).Cells("AJIPCLAS").Value.ToString), String)
                Me.lblAJIPMERE.Text = CType(fun_Buscar_Lista_Valores_MEDIRESE(Me.dgvTRAMPEND.SelectedRows.Item(0).Cells("AJIPMERE").Value.ToString), String)
                Me.lblAJIPREAJ.Text = CType(fun_Buscar_Lista_Valores_RESOAJUS(Me.dgvTRAMPEND.SelectedRows.Item(0).Cells("AJIPREAJ").Value.ToString), String)
                Me.lblAJIPREMI.Text = CType(fun_Buscar_Lista_Valores_USUARIO(Me.dgvTRAMPEND.SelectedRows.Item(0).Cells("AJIPNUDO").Value.ToString), String)
                Me.lblAJIPTITR.Text = CType(fun_Buscar_Lista_Valores_TIPOTRAM(Me.dgvTRAMPEND.SelectedRows.Item(0).Cells("AJIPTITR").Value.ToString), String)
                Me.lblAJIPVIGE.Text = CType(fun_Buscar_Lista_Valores_VIGENCIA(Me.dgvTRAMPEND.SelectedRows.Item(0).Cells("AJIPVIGE").Value.ToString), String)

                pro_ContarTramites()
            Else
                pro_LimpiarCamposAjusteTramitesPendientes()

            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub pro_ListaDeValoresAjustesTramitesFinalizados()

        Try
            If Me.dgvTRAMFINA.RowCount > 0 Then

                Dim objdatos As New cla_AJUSIMPR
                Dim tbl As New DataTable

                tbl = objdatos.fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_AJUSIMPR(Me.dgvTRAMFINA.SelectedRows.Item(0).Cells("AJIPIDRE").Value.ToString)

                Dim obCONTRASENA As New cla_CONTRASENA
                Dim dtCONTRASENA As New DataTable

                dtCONTRASENA = obCONTRASENA.fun_Buscar_CODIGO_CONTRASENA(Trim(Me.dgvTRAMFINA.SelectedRows.Item(0).Cells("AJIPNUDO").Value.ToString))

                If dtCONTRASENA.Rows.Count > 0 Then
                    Me.txtAJIPREMI.Text = Trim(dtCONTRASENA.Rows(0).Item("CONTUSUA").ToString)
                Else
                    Me.txtAJIPREMI.Text = ""
                End If

                Me.txtAJIPCLAS.Text = Trim(Me.dgvTRAMFINA.SelectedRows.Item(0).Cells("AJIPCLAS").Value.ToString)
                Me.txtAJIPTITR.Text = Trim(Me.dgvTRAMFINA.SelectedRows.Item(0).Cells("AJIPTITR").Value.ToString)
                Me.txtAJIPREAJ.Text = Trim(Me.dgvTRAMFINA.SelectedRows.Item(0).Cells("AJIPREAJ").Value.ToString)
                Me.txtAJIPMERE.Text = Trim(Me.dgvTRAMFINA.SelectedRows.Item(0).Cells("AJIPMERE").Value.ToString)
                Me.txtAJIPVIGE.Text = Trim(Me.dgvTRAMFINA.SelectedRows.Item(0).Cells("AJIPVIGE").Value.ToString)
                Me.txtAJIPNURE.Text = Trim(Me.dgvTRAMFINA.SelectedRows.Item(0).Cells("AJIPNURE").Value.ToString)
                Me.txtAJIPFERE.Text = Trim(Me.dgvTRAMFINA.SelectedRows.Item(0).Cells("AJIPFERE").Value.ToString)
                Me.txtAJIPNURA.Text = Trim(Me.dgvTRAMFINA.SelectedRows.Item(0).Cells("AJIPNURA").Value.ToString)
                Me.txtAJIPFERA.Text = Trim(Me.dgvTRAMFINA.SelectedRows.Item(0).Cells("AJIPFERA").Value.ToString)

                Me.txtAJIPNUOF.Text = Trim(Me.dgvTRAMFINA.SelectedRows.Item(0).Cells("AJIPNUOF").Value.ToString)
                Me.txtAJIPFEOF.Text = Trim(Me.dgvTRAMFINA.SelectedRows.Item(0).Cells("AJIPFEOF").Value.ToString)
                Me.txtAJIPSECU.Text = Trim(Me.dgvTRAMFINA.SelectedRows.Item(0).Cells("AJIPSECU").Value.ToString)
                Me.txtAJIPFECH.Text = Trim(Me.dgvTRAMFINA.SelectedRows.Item(0).Cells("AJIPFECH").Value.ToString)
                Me.txtAJIPNUFI.Text = Trim(Me.dgvTRAMFINA.SelectedRows.Item(0).Cells("AJIPNUFI").Value.ToString)
                Me.txtAJIPMAIN.Text = Trim(Me.dgvTRAMFINA.SelectedRows.Item(0).Cells("AJIPMAIN").Value.ToString)
                Me.txtAJIPOBSE.Text = Trim(Me.dgvTRAMFINA.SelectedRows.Item(0).Cells("AJIPOBSE").Value.ToString)

                Me.lblAJIPMUNI.Text = CType(fun_Buscar_Lista_Valores_MUNICIPIO(Me.dgvTRAMFINA.SelectedRows.Item(0).Cells("AJIPDEPA").Value.ToString, Me.dgvTRAMFINA.SelectedRows.Item(0).Cells("AJIPMUNI").Value.ToString), String)
                Me.lblAJIPCORR.Text = CType(fun_Buscar_Lista_Valores_CORREGIMIENTO(Me.dgvTRAMFINA.SelectedRows.Item(0).Cells("AJIPDEPA").Value.ToString, Me.dgvTRAMFINA.SelectedRows.Item(0).Cells("AJIPMUNI").Value.ToString, Me.dgvTRAMFINA.SelectedRows.Item(0).Cells("AJIPCLSE").Value.ToString, Me.dgvTRAMFINA.SelectedRows.Item(0).Cells("AJIPCORR").Value.ToString), String)

                If CInt(Me.dgvTRAMFINA.SelectedRows.Item(0).Cells("AJIPCLSE").Value.ToString) = 1 Then
                    Me.lblAJIPBAVE.Text = CType(fun_Buscar_Lista_Valores_BARRIO(Me.dgvTRAMFINA.SelectedRows.Item(0).Cells("AJIPDEPA").Value.ToString, Me.dgvTRAMFINA.SelectedRows.Item(0).Cells("AJIPMUNI").Value.ToString, Me.dgvTRAMFINA.SelectedRows.Item(0).Cells("AJIPCLSE").Value.ToString, Me.dgvTRAMFINA.SelectedRows.Item(0).Cells("AJIPBARR").Value.ToString, Me.dgvTRAMFINA.SelectedRows.Item(0).Cells("AJIPCORR").Value.ToString), String)
                ElseIf CInt(Me.dgvTRAMFINA.SelectedRows.Item(0).Cells("AJIPCLSE").Value.ToString) = 2 Then
                    Me.lblAJIPBAVE.Text = CType(fun_Buscar_Lista_Valores_VEREDA(Me.dgvTRAMFINA.SelectedRows.Item(0).Cells("AJIPDEPA").Value.ToString, Me.dgvTRAMFINA.SelectedRows.Item(0).Cells("AJIPMUNI").Value.ToString, Me.dgvTRAMFINA.SelectedRows.Item(0).Cells("AJIPCLSE").Value.ToString, Me.dgvTRAMFINA.SelectedRows.Item(0).Cells("AJIPMANZ").Value.ToString, Me.dgvTRAMFINA.SelectedRows.Item(0).Cells("AJIPCORR").Value.ToString), String)
                ElseIf CInt(Me.dgvTRAMFINA.SelectedRows.Item(0).Cells("AJIPCLSE").Value.ToString) = 3 Then
                    Me.lblAJIPBAVE.Text = CType(fun_Buscar_Lista_Valores_BARRIO(Me.dgvTRAMFINA.SelectedRows.Item(0).Cells("AJIPDEPA").Value.ToString, Me.dgvTRAMFINA.SelectedRows.Item(0).Cells("AJIPMUNI").Value.ToString, Me.dgvTRAMFINA.SelectedRows.Item(0).Cells("AJIPCLSE").Value.ToString, Me.dgvTRAMFINA.SelectedRows.Item(0).Cells("AJIPBARR").Value.ToString, Me.dgvTRAMFINA.SelectedRows.Item(0).Cells("AJIPCORR").Value.ToString), String)
                End If

                Me.lblAJIPCLSE.Text = CType(fun_Buscar_Lista_Valores_CLASSECT(Me.dgvTRAMFINA.SelectedRows.Item(0).Cells("AJIPCLSE").Value.ToString), String)
                Me.lblAJIPCLAS.Text = CType(fun_Buscar_Lista_Valores_CLASIFICACION(Me.dgvTRAMFINA.SelectedRows.Item(0).Cells("AJIPCLAS").Value.ToString), String)
                Me.lblAJIPMERE.Text = CType(fun_Buscar_Lista_Valores_MEDIRESE(Me.dgvTRAMFINA.SelectedRows.Item(0).Cells("AJIPMERE").Value.ToString), String)
                Me.lblAJIPREAJ.Text = CType(fun_Buscar_Lista_Valores_RESOAJUS(Me.dgvTRAMFINA.SelectedRows.Item(0).Cells("AJIPREAJ").Value.ToString), String)
                Me.lblAJIPREMI.Text = CType(fun_Buscar_Lista_Valores_USUARIO(Me.dgvTRAMFINA.SelectedRows.Item(0).Cells("AJIPNUDO").Value.ToString), String)
                Me.lblAJIPTITR.Text = CType(fun_Buscar_Lista_Valores_TIPOTRAM(Me.dgvTRAMFINA.SelectedRows.Item(0).Cells("AJIPTITR").Value.ToString), String)
                Me.lblAJIPVIGE.Text = CType(fun_Buscar_Lista_Valores_VIGENCIA(Me.dgvTRAMFINA.SelectedRows.Item(0).Cells("AJIPVIGE").Value.ToString), String)

                pro_ContarTramites()
            Else
                pro_LimpiarCamposAjusteTramitesFinalizados()

            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub

    Private Sub pro_LimpiarCamposAjuste()

        Me.dgvAJUSIMPR.DataSource = New DataTable

        Me.lblAJIPBAVE.Text = ""
        Me.lblAJIPMUNI.Text = ""
        Me.lblAJIPCLSE.Text = ""
        Me.lblAJIPCORR.Text = ""

        Me.txtAJIPREMI.Text = ""
        Me.txtAJIPCLAS.Text = ""
        Me.txtAJIPTITR.Text = ""
        Me.txtAJIPMERE.Text = ""
        Me.txtAJIPREAJ.Text = ""
        Me.txtAJIPVIGE.Text = ""
        Me.txtAJIPUSUD.Text = ""

        Me.lblAJIPREMI.Text = ""
        Me.lblAJIPCLAS.Text = ""
        Me.lblAJIPTITR.Text = ""
        Me.lblAJIPMERE.Text = ""
        Me.lblAJIPREAJ.Text = ""
        Me.lblAJIPVIGE.Text = ""
        Me.lblAJIPDEST.Text = ""

        Me.txtAJIPNURE.Text = ""
        Me.txtAJIPFERE.Text = ""
        Me.txtAJIPNURA.Text = ""
        Me.txtAJIPFERA.Text = ""
        Me.txtAJIPFECD.Text = ""
        Me.txtAJIPNUOF.Text = ""
        Me.txtAJIPFEOF.Text = ""

        Me.txtAJIPOBSE.Text = ""
        Me.txtAJIPNUFI.Text = ""
        Me.txtAJIPMAIN.Text = ""

        Me.txtAJIPOBSE.Text = ""
        Me.txtTRAMASIG.Text = ""
        Me.txtTRAMPEND.Text = ""
        Me.txtTRAMFINA.Text = ""

        Me.strBARRESTA.Items(2).Text = "Registros : 0"

    End Sub

    Private Sub pro_LimpiarCamposAjusteTramitesRegistrados()

        Me.dgvTRAMREGI.DataSource = New DataTable

    End Sub
    Private Sub pro_LimpiarCamposAjusteTramitesAsignados()

        Me.dgvTRAMASIG.DataSource = New DataTable

    End Sub
    Private Sub pro_LimpiarCamposAjusteTramitesPendientes()

        Me.dgvTRAMPEND.DataSource = New DataTable

    End Sub
    Private Sub pro_LimpiarCamposAjusteTramitesFinalizados()

        Me.dgvTRAMFINA.DataSource = New DataTable

    End Sub

    Private Sub pro_ControlDeBotones()

        If Me.dgvAJUSIMPR.RowCount > 0 Then
            Me.cmdOBSERVACIONES.Enabled = True
        Else
            Me.cmdOBSERVACIONES.Enabled = False
        End If

        If Me.dgvTRAMREGI.RowCount > 0 Then
            Me.cmdASIGNAR.Enabled = True
        Else
            Me.cmdASIGNAR.Enabled = False
        End If

        If Me.dgvTRAMPEND.RowCount > 0 Then
            Me.cmdRECHAZAR.Enabled = True
            Me.cmdFINALIZAR.Enabled = True
        Else
            Me.cmdRECHAZAR.Enabled = False
            Me.cmdFINALIZAR.Enabled = False
        End If

    End Sub
    Private Sub pro_ContarTramites()

        Me.txtTRAMASIG.Text = Me.dgvTRAMASIG.RowCount
        Me.txtTRAMPEND.Text = Me.dgvTRAMPEND.RowCount
        Me.txtTRAMFINA.Text = Me.dgvTRAMFINA.RowCount

    End Sub

    Private Sub pro_EjecutarBotonAsignar()

        Try
            If Me.dgvTRAMREGI.RowCount > 0 Then

                If MessageBox.Show("¿ Desea asignar el tramite Nro. " & Me.dgvTRAMREGI.SelectedRows.Item(0).Cells("AJIPSECU").Value.ToString() & " ? ", "Mensaje...", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then

                    Me.TabControl1.SelectTab(TabAsignados)

                    Dim frm_AsignarTramite As New frm_asignar_AJUSIMPR(Integer.Parse(Me.dgvTRAMREGI.SelectedRows.Item(0).Cells("AJIPIDRE").Value.ToString()), _
                                                                                     Me.dgvTRAMREGI.SelectedRows.Item(0).Cells("AJIPNUDO").Value.ToString())
                    frm_AsignarTramite.ShowDialog()
                    boCONSULTA = True

                    vp_inConsulta = Me.dgvTRAMREGI.SelectedRows.Item(0).Cells("AJIPIDRE").Value.ToString()

                    pro_ReconsultarAjustes()
                    pro_ListaDeValoresAjustes()

                    pro_ReconsultarAjustesRegistradosPorConsulta()
                    pro_ReconsultarAjustesAsignadosPorConsulta()
                    pro_ReconsultarAjustesPendientesPorConsulta()
                    pro_ReconsultarAjustesFinalizadosPorConsulta()

                    pro_ControlDeBotones()

                    Me.tabINSCFICHPRED.SelectTab(TabAJIPINUS)

                    If Me.dgvTRAMREGI.RowCount > 0 Then
                        Me.TabControl1.SelectTab(TabRegistrados)

                    ElseIf Me.dgvTRAMASIG.RowCount > 0 Then
                        Me.TabControl1.SelectTab(TabAsignados)

                    ElseIf Me.dgvTRAMPEND.RowCount > 0 Then
                        Me.TabControl1.SelectTab(TabPendientes)

                    ElseIf Me.dgvTRAMFINA.RowCount > 0 Then
                        Me.TabControl1.SelectTab(TabFinalizados)
                    End If

                End If

            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub pro_EjecutarBotonRechazar()

        Try
            If Me.dgvTRAMPEND.RowCount > 0 Then

                If MessageBox.Show("¿ Desea Rechazar el tramite Nro. " & Me.dgvTRAMPEND.SelectedRows.Item(0).Cells("AJIPSECU").Value.ToString() & " ? ", "Mensaje...", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then

                    Me.TabControl1.SelectTab(TabPendientes)

                    Dim stObservacionNueva As String = InputBox("Ingrese la observación de rechazo.", "Mensaje")

                    If Trim(stObservacionNueva) = "" Then
                        MessageBox.Show("Se requiere una observación.", "Mensaje...", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                        mod_MENSAJE.No_Se_Modifico_El_Registro_En_La_Base_De_Datos()
                    Else
                        Dim stRECLOBSE_ACTUAL As String = ""
                        Dim stRECLOBSE_NUEVA As String = Trim(stObservacionNueva.ToString.ToUpper)

                        Dim obAJUSIMPR As New cla_AJUSIMPR
                        Dim dtAJUSIMPR As New DataTable

                        dtAJUSIMPR = obAJUSIMPR.fun_Buscar_ID_AJUSIMPR(Me.dgvTRAMPEND.SelectedRows.Item(0).Cells("AJIPIDRE").Value.ToString())

                        If dtAJUSIMPR.Rows.Count > 0 Then
                            stRECLOBSE_ACTUAL = Trim(dtAJUSIMPR.Rows(0).Item("AJIPOBSE").ToString)
                        End If

                        If Trim(stRECLOBSE_ACTUAL) <> "" And Trim(stRECLOBSE_NUEVA) <> "" Then
                            stRECLOBSE_ACTUAL += vbCrLf & " Nota ingresada por " & vp_usuario & " " & fun_fecha() & " : " & stRECLOBSE_NUEVA & ". "

                        ElseIf Trim(stRECLOBSE_ACTUAL) = "" And Trim(stRECLOBSE_NUEVA) <> "" Then
                            stRECLOBSE_ACTUAL += " Nota ingresada por " & vp_usuario & " " & fun_fecha() & " : " & stRECLOBSE_NUEVA & ". "

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
                        Dim inAJIPIDRE As Integer = Integer.Parse(Me.dgvTRAMPEND.SelectedRows.Item(0).Cells("AJIPIDRE").Value.ToString())
                        Dim stAJIPESTA As String = "ac"
                        Dim stLIMPIAR As String = ""

                        ' parametros de la consulta
                        Dim ParametrosConsulta As String = ""

                        ' Concatena la condicion de la consulta
                        ParametrosConsulta += "update AJUSIMPR "
                        ParametrosConsulta += "set AJIPESTA = '" & stAJIPESTA & "', "
                        ParametrosConsulta += "AJIPESTR = '" & stAJIPESTA & "', "
                        ParametrosConsulta += "AJIPOBSE = '" & stRECLOBSE_ACTUAL & "', "
                        ParametrosConsulta += "AJIPREMI = '" & stLIMPIAR & "', "
                        ParametrosConsulta += "AJIPUSUR = '" & stLIMPIAR & "', "
                        ParametrosConsulta += "AJIPFECR = '" & stLIMPIAR & "', "
                        ParametrosConsulta += "AJIPDEST = '" & stLIMPIAR & "', "
                        ParametrosConsulta += "AJIPUSUD = '" & stLIMPIAR & "', "
                        ParametrosConsulta += "AJIPFECD = '" & stLIMPIAR & "' "
                        ParametrosConsulta += "where AJIPIDRE = '" & inAJIPIDRE & "' "

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

                        Me.txtAJIPOBSE.Text = stRECLOBSE_ACTUAL

                        boCONSULTA = True

                        vp_inConsulta = Me.dgvTRAMPEND.SelectedRows.Item(0).Cells("AJIPIDRE").Value.ToString()

                        pro_ReconsultarAjustes()
                        pro_ListaDeValoresAjustes()

                        pro_ReconsultarAjustesRegistradosPorConsulta()
                        pro_ReconsultarAjustesAsignadosPorConsulta()
                        pro_ReconsultarAjustesPendientesPorConsulta()
                        pro_ReconsultarAjustesFinalizadosPorConsulta()

                        pro_ControlDeBotones()

                        Me.tabINSCFICHPRED.SelectTab(TabAJIPINUS)

                        If Me.dgvTRAMREGI.RowCount > 0 Then
                            Me.TabControl1.SelectTab(TabRegistrados)

                        ElseIf Me.dgvTRAMASIG.RowCount > 0 Then
                            Me.TabControl1.SelectTab(TabAsignados)

                        ElseIf Me.dgvTRAMPEND.RowCount > 0 Then
                            Me.TabControl1.SelectTab(TabPendientes)

                        ElseIf Me.dgvTRAMFINA.RowCount > 0 Then
                            Me.TabControl1.SelectTab(TabFinalizados)
                        End If

                    End If

                End If

            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub pro_EjecutarBotonFinalizar()

        Try
            If Me.dgvTRAMPEND.RowCount > 0 Then

                If MessageBox.Show("¿ Desea finalizar el tramite Nro. " & Me.dgvTRAMPEND.SelectedRows.Item(0).Cells("AJIPSECU").Value.ToString() & " ? ", "Mensaje...", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then

                    Me.TabControl1.SelectTab(TabFinalizados)

                    ' buscar cadena de conexion
                    Dim oCadenaConexion As New REGLAS_DEL_NEGOCIO.cla_ConnectionString
                    Dim stCadenaConexion As String = oCadenaConexion.fun_ConnectionString

                    ' crear conexión
                    oAdapter = New SqlDataAdapter
                    oConexion = New SqlConnection(stCadenaConexion)

                    ' abre la conexion
                    oConexion.Open()

                    ' variables
                    Dim inAJIPIDRE As Integer = Integer.Parse(Me.dgvTRAMPEND.SelectedRows.Item(0).Cells("AJIPIDRE").Value.ToString())
                    Dim stAJIPESTA As String = "fi"

                    ' parametros de la consulta
                    Dim ParametrosConsulta As String = ""

                    ' Concatena la condicion de la consulta
                    ParametrosConsulta += "update AJUSIMPR "
                    ParametrosConsulta += "set AJIPESTA = '" & stAJIPESTA & "', "
                    ParametrosConsulta += "AJIPESTR = '" & stAJIPESTA & "' "
                    ParametrosConsulta += "where AJIPIDRE = '" & inAJIPIDRE & "' "

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

                    vp_inConsulta = Me.dgvTRAMPEND.SelectedRows.Item(0).Cells("AJIPIDRE").Value.ToString()

                    pro_ReconsultarAjustes()
                    pro_ListaDeValoresAjustes()

                    pro_ReconsultarAjustesRegistradosPorConsulta()
                    pro_ReconsultarAjustesAsignadosPorConsulta()
                    pro_ReconsultarAjustesPendientesPorConsulta()
                    pro_ReconsultarAjustesFinalizadosPorConsulta()

                    pro_ControlDeBotones()

                    Me.tabINSCFICHPRED.SelectTab(TabAJIPINUS)

                    If Me.dgvTRAMREGI.RowCount > 0 Then
                        Me.TabControl1.SelectTab(TabRegistrados)

                    ElseIf Me.dgvTRAMASIG.RowCount > 0 Then
                        Me.TabControl1.SelectTab(TabAsignados)

                    ElseIf Me.dgvTRAMPEND.RowCount > 0 Then
                        Me.TabControl1.SelectTab(TabPendientes)

                    ElseIf Me.dgvTRAMFINA.RowCount > 0 Then
                        Me.TabControl1.SelectTab(TabFinalizados)
                    End If

                End If

            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub pro_EjecutarBotonObservacion()

        Try
            If Me.dgvAJUSIMPR.RowCount > 0 Then

                If MessageBox.Show("¿ Desea ingresar una observación al tramite Nro. " & Me.dgvAJUSIMPR.SelectedRows.Item(0).Cells("AJIPSECU").Value.ToString() & " ? ", "Mensaje...", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then

                    Dim stObservacionNueva As String = InputBox("Ingrese la observación.", "Mensaje")

                    If Trim(stObservacionNueva) = "" Then
                        MessageBox.Show("Se requiere una observación.", "Mensaje...", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                        mod_MENSAJE.No_Se_Modifico_El_Registro_En_La_Base_De_Datos()
                    Else
                        Me.tabINSCFICHPRED.SelectTab(TabAJIPOBSE)

                        Dim stRECLOBSE_ACTUAL As String = ""
                        Dim stRECLOBSE_NUEVA As String = Trim(stObservacionNueva.ToString.ToUpper)

                        Dim obAJUSIMPR As New cla_AJUSIMPR
                        Dim dtAJUSIMPR As New DataTable

                        dtAJUSIMPR = obAJUSIMPR.fun_Buscar_ID_AJUSIMPR(Me.dgvAJUSIMPR.SelectedRows.Item(0).Cells("AJIPIDRE").Value.ToString())

                        If dtAJUSIMPR.Rows.Count > 0 Then
                            stRECLOBSE_ACTUAL = Trim(dtAJUSIMPR.Rows(0).Item("AJIPOBSE").ToString)
                        End If

                        If Trim(stRECLOBSE_ACTUAL) <> "" And Trim(stRECLOBSE_NUEVA) <> "" Then
                            stRECLOBSE_ACTUAL = stRECLOBSE_ACTUAL & vbCrLf & " Nota ingresada por " & vp_usuario & " " & fun_fecha() & " : " & stRECLOBSE_NUEVA & ". "

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
                        Dim inAJIPIDRE As Integer = Integer.Parse(Me.dgvAJUSIMPR.SelectedRows.Item(0).Cells("AJIPIDRE").Value.ToString())

                        ' parametros de la consulta
                        Dim ParametrosConsulta As String = ""

                        ' Concatena la condicion de la consulta
                        ParametrosConsulta += "update AJUSIMPR "
                        ParametrosConsulta += "set AJIPOBSE = '" & stRECLOBSE_ACTUAL & "' "
                        ParametrosConsulta += "where AJIPIDRE = '" & inAJIPIDRE & "' "

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

                        vp_inConsulta = inAJIPIDRE

                        boCONSULTA = True

                        pro_ListaDeValoresAjustes()

                        pro_ReconsultarAjustesRegistradosPorConsulta()
                        pro_ReconsultarAjustesAsignadosPorConsulta()
                        pro_ReconsultarAjustesPendientesPorConsulta()
                        pro_ReconsultarAjustesFinalizadosPorConsulta()

                        pro_ControlDeBotones()

                        Me.tabINSCFICHPRED.SelectTab(TabAJIPOBSE)

                        If Me.dgvTRAMREGI.RowCount > 0 Then
                            Me.TabControl1.SelectTab(TabRegistrados)

                        ElseIf Me.dgvTRAMASIG.RowCount > 0 Then
                            Me.TabControl1.SelectTab(TabAsignados)

                        ElseIf Me.dgvTRAMPEND.RowCount > 0 Then
                            Me.TabControl1.SelectTab(TabPendientes)

                        ElseIf Me.dgvTRAMFINA.RowCount > 0 Then
                            Me.TabControl1.SelectTab(TabFinalizados)
                        End If

                    End If

                End If

            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub

#End Region

#Region "PROCEDIMIENTOS DOCUMENTOS"

    Private Sub pro_ListadoArchivosDocumentosRectificacion()

        Try
            ' instancia la clase
            Dim obRECLAMOS As New cla_RECLAMOS
            Dim dtRECLAMOS As New DataTable

            dtRECLAMOS = obRECLAMOS.fun_Buscar_CEDULA_CATASTRAL_RECLAMOS(CStr(Trim(Me.dgvAJUSIMPR.SelectedRows.Item(0).Cells("AJIPMUNI").Value.ToString)), _
                                                                         CStr(Trim(Me.dgvAJUSIMPR.SelectedRows.Item(0).Cells("AJIPCORR").Value.ToString)), _
                                                                         CStr(Trim(Me.dgvAJUSIMPR.SelectedRows.Item(0).Cells("AJIPBARR").Value.ToString)), _
                                                                         CStr(Trim(Me.dgvAJUSIMPR.SelectedRows.Item(0).Cells("AJIPMANZ").Value.ToString)), _
                                                                         CStr(Trim(Me.dgvAJUSIMPR.SelectedRows.Item(0).Cells("AJIPPRED").Value.ToString)), _
                                                                         CStr(Trim(Me.dgvAJUSIMPR.SelectedRows.Item(0).Cells("AJIPEDIF").Value.ToString)), _
                                                                         CStr(Trim(Me.dgvAJUSIMPR.SelectedRows.Item(0).Cells("AJIPUNPR").Value.ToString)), _
                                                                         CInt(Me.dgvAJUSIMPR.SelectedRows.Item(0).Cells("AJIPCLSE").Value.ToString))


            If dtRECLAMOS.Rows.Count > 0 Then

                Dim stRECLSECU As String = Trim(dtRECLAMOS.Rows(0).Item("RECLSECU"))

                ' instancia la clase
                Dim obRECLACAD As New cla_RECLACAD
                Dim dtRECLACAD As New DataTable

                dtRECLACAD = obRECLACAD.fun_Buscar_CODIGO_X_RECLACAD(stRECLSECU)

                If dtRECLACAD.Rows.Count > 0 Then

                    Dim stREAANUEM As String = Trim(dtRECLACAD.Rows(0).Item("REAANUEM"))
                    Dim stREAAFEEM As String = Trim(dtRECLACAD.Rows(0).Item("REAAFEEM"))

                    Me.lstLISTADO_DOCUMENTOS_RECLAMOS.Items.Clear()

                    ' declara la variable
                    Dim stRuta As String = ""
                    Dim stNewPath As String = ""
                    Dim ContentItem As String

                    ' instancia la clase
                    Dim objRutas As New cla_RUTAS
                    Dim tblRutas As New DataTable

                    tblRutas = objRutas.fun_Buscar_CODIGO_MANT_RUTAS(4)

                    If tblRutas.Rows.Count > 0 AndAlso fun_VerificarCarpetaExistenteDocumentosRectificacion() = True Then

                        stNewPath = Trim(tblRutas.Rows(0).Item("RUTARUTA")) & "\" & fun_Formato_Mascara_3_String(Trim(stREAANUEM)) & "-" & fun_Formato_Mascara_4_String(Trim(stREAAFEEM.ToString.Substring(6, 4)))

                        vl_stRutaDocumentosRectificaciones = stNewPath

                        ChDir(stNewPath)

                        Me.lstLISTADO_DOCUMENTOS_RECLAMOS.Items.Clear()

                        ContentItem = Dir("*.pdf")

                        If ContentItem <> "" Then
                            Me.lstLISTADO_DOCUMENTOS_RECLAMOS.Focus()
                        End If

                        Do Until ContentItem = ""
                            ' agrega a la lista
                            Me.lstLISTADO_DOCUMENTOS_RECLAMOS.Items.Add(ContentItem)

                            'desplaza el registro
                            ContentItem = Dir()
                        Loop

                    Else
                        Me.lstLISTADO_DOCUMENTOS_RECLAMOS.Items.Clear()
                    End If
                Else
                    Me.lstLISTADO_DOCUMENTOS_RECLAMOS.Items.Clear()
                End If
            Else
                Me.lstLISTADO_DOCUMENTOS_RECLAMOS.Items.Clear()
            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub pro_ListadoArchivosDocumentosAjuste()

        Try
            Me.lstLISTADO_DOCUMENTOS_AJUSTES.Items.Clear()

            ' declara la variable
            Dim stRuta As String = ""
            Dim stNewPath As String = ""
            Dim ContentItem As String

            ' instancia la clase
            Dim objRutas As New cla_RUTAS
            Dim tblRutas As New DataTable

            tblRutas = objRutas.fun_Buscar_CODIGO_MANT_RUTAS(11)

            If tblRutas.Rows.Count > 0 AndAlso fun_VerificarCarpetaExistenteDocumentosAjustes() = True Then

                stNewPath = Trim(tblRutas.Rows(0).Item("RUTARUTA")) & "\" & Trim(Me.dgvAJUSIMPR.SelectedRows.Item(0).Cells("AJIPMUNI").Value.ToString) & "-" & Trim(Me.dgvAJUSIMPR.SelectedRows.Item(0).Cells("AJIPCLSE").Value.ToString) & "-" & Trim(Me.dgvAJUSIMPR.SelectedRows.Item(0).Cells("AJIPCORR").Value.ToString) & "-" & Trim(Me.dgvAJUSIMPR.SelectedRows.Item(0).Cells("AJIPBARR").Value.ToString) & "-" & Trim(Me.dgvAJUSIMPR.SelectedRows.Item(0).Cells("AJIPMANZ").Value.ToString) & "-" & Trim(Me.dgvAJUSIMPR.SelectedRows.Item(0).Cells("AJIPPRED").Value.ToString) & "-" & Trim(Me.dgvAJUSIMPR.SelectedRows.Item(0).Cells("AJIPEDIF").Value.ToString) & "-" & Trim(Me.dgvAJUSIMPR.SelectedRows.Item(0).Cells("AJIPUNPR").Value.ToString) & "-" & Trim(Me.dgvAJUSIMPR.SelectedRows.Item(0).Cells("AJIPVIGE").Value.ToString)

                vl_stRutaDocumentosAjustesPredial = stNewPath

                ChDir(stNewPath)

                Me.lstLISTADO_DOCUMENTOS_AJUSTES.Items.Clear()

                ContentItem = Dir("*.*")

                If ContentItem <> "" Then
                    Me.lstLISTADO_DOCUMENTOS_AJUSTES.Focus()
                End If

                Do Until ContentItem = ""
                    ' agrega a la lista
                    Me.lstLISTADO_DOCUMENTOS_AJUSTES.Items.Add(ContentItem)

                    'desplaza el registro
                    ContentItem = Dir()
                Loop

            Else
                Me.lstLISTADO_DOCUMENTOS_AJUSTES.Items.Clear()
            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub pro_ListadoArchivosImagenes()

        Try
            ' instancia la clase
            Dim obRECLAMOS As New cla_RECLAMOS
            Dim dtRECLAMOS As New DataTable

            dtRECLAMOS = obRECLAMOS.fun_Buscar_CEDULA_CATASTRAL_RECLAMOS(CStr(Trim(Me.dgvAJUSIMPR.SelectedRows.Item(0).Cells("AJIPMUNI").Value.ToString)), _
                                                                         CStr(Trim(Me.dgvAJUSIMPR.SelectedRows.Item(0).Cells("AJIPCORR").Value.ToString)), _
                                                                         CStr(Trim(Me.dgvAJUSIMPR.SelectedRows.Item(0).Cells("AJIPBARR").Value.ToString)), _
                                                                         CStr(Trim(Me.dgvAJUSIMPR.SelectedRows.Item(0).Cells("AJIPMANZ").Value.ToString)), _
                                                                         CStr(Trim(Me.dgvAJUSIMPR.SelectedRows.Item(0).Cells("AJIPPRED").Value.ToString)), _
                                                                         CStr(Trim(Me.dgvAJUSIMPR.SelectedRows.Item(0).Cells("AJIPEDIF").Value.ToString)), _
                                                                         CStr(Trim(Me.dgvAJUSIMPR.SelectedRows.Item(0).Cells("AJIPUNPR").Value.ToString)), _
                                                                         CInt(Me.dgvAJUSIMPR.SelectedRows.Item(0).Cells("AJIPCLSE").Value.ToString))


            If dtRECLAMOS.Rows.Count > 0 Then

                Dim stRECLSECU As String = Trim(dtRECLAMOS.Rows(0).Item("RECLSECU"))

                ' instancia la clase
                Dim obRECLACAD As New cla_RECLACAD
                Dim dtRECLACAD As New DataTable

                dtRECLACAD = obRECLACAD.fun_Buscar_CODIGO_X_RECLACAD(stRECLSECU)

                If dtRECLACAD.Rows.Count > 0 Then

                    Dim stREAANUEM As String = Trim(dtRECLACAD.Rows(0).Item("REAANUEM"))
                    Dim stREAAFEEM As String = Trim(dtRECLACAD.Rows(0).Item("REAAFEEM"))

                    Me.lstLISTADO_IMAGENES.Items.Clear()

                    ' declara la variable
                    Dim stRuta As String = ""
                    Dim stNewPath As String = ""
                    Dim ContentItem As String

                    ' instancia la clase
                    Dim objRutas As New cla_RUTAS
                    Dim tblRutas As New DataTable

                    tblRutas = objRutas.fun_Buscar_CODIGO_MANT_RUTAS(4)

                    If tblRutas.Rows.Count > 0 AndAlso fun_VerificarCarpetaExistenteImagenes() = True Then

                        stNewPath = Trim(tblRutas.Rows(0).Item("RUTARUTA")) & "\" & fun_Formato_Mascara_3_String(Trim(stREAANUEM)) & "-" & fun_Formato_Mascara_4_String(Trim(stREAAFEEM.ToString.Substring(6, 4)))

                        vl_stRutaImagenes = stNewPath

                        ChDir(stNewPath)

                        Me.lstLISTADO_IMAGENES.Items.Clear()

                        ContentItem = Dir("*.jpg")

                        If ContentItem <> "" Then
                            Me.lstLISTADO_IMAGENES.Focus()
                        End If

                        Do Until ContentItem = ""
                            ' agrega a la lista
                            Me.lstLISTADO_IMAGENES.Items.Add(ContentItem)

                            'desplaza el registro
                            ContentItem = Dir()
                        Loop

                    Else
                        Me.lstLISTADO_IMAGENES.Items.Clear()
                    End If
                Else
                    Me.lstLISTADO_IMAGENES.Items.Clear()
                End If
            Else
                Me.lstLISTADO_IMAGENES.Items.Clear()
            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub pro_ListadoArchivosResolucion()

        Try
            ' instancia la clase
            Dim obRECLAMOS As New cla_RECLAMOS
            Dim dtRECLAMOS As New DataTable

            dtRECLAMOS = obRECLAMOS.fun_Buscar_CEDULA_CATASTRAL_RECLAMOS(CStr(Trim(Me.dgvAJUSIMPR.SelectedRows.Item(0).Cells("AJIPMUNI").Value.ToString)), _
                                                                         CStr(Trim(Me.dgvAJUSIMPR.SelectedRows.Item(0).Cells("AJIPCORR").Value.ToString)), _
                                                                         CStr(Trim(Me.dgvAJUSIMPR.SelectedRows.Item(0).Cells("AJIPBARR").Value.ToString)), _
                                                                         CStr(Trim(Me.dgvAJUSIMPR.SelectedRows.Item(0).Cells("AJIPMANZ").Value.ToString)), _
                                                                         CStr(Trim(Me.dgvAJUSIMPR.SelectedRows.Item(0).Cells("AJIPPRED").Value.ToString)), _
                                                                         CStr(Trim(Me.dgvAJUSIMPR.SelectedRows.Item(0).Cells("AJIPEDIF").Value.ToString)), _
                                                                         CStr(Trim(Me.dgvAJUSIMPR.SelectedRows.Item(0).Cells("AJIPUNPR").Value.ToString)), _
                                                                         CInt(Me.dgvAJUSIMPR.SelectedRows.Item(0).Cells("AJIPCLSE").Value.ToString))


            If dtRECLAMOS.Rows.Count > 0 Then

                Dim stRECLSECU As String = Trim(dtRECLAMOS.Rows(0).Item("RECLSECU"))

                ' instancia la clase
                Dim obRECLACAD As New cla_RECLACAD
                Dim dtRECLACAD As New DataTable

                dtRECLACAD = obRECLACAD.fun_Buscar_CODIGO_X_RECLACAD(stRECLSECU)

                If dtRECLACAD.Rows.Count > 0 Then

                    Dim stREAANURA As String = Trim(dtRECLACAD.Rows(0).Item("REAANURA"))
                    Dim stREAAFERA As String = Trim(dtRECLACAD.Rows(0).Item("REAAFERA"))

                    Me.lstLISTADO_RESOLUCION.Items.Clear()

                    ' declara la variable
                    Dim stRuta As String = ""
                    Dim stNewPath As String = ""
                    Dim ContentItem As String

                    ' instancia la clase
                    Dim objRutas As New cla_RUTAS
                    Dim tblRutas As New DataTable

                    tblRutas = objRutas.fun_Buscar_CODIGO_MANT_RUTAS(5)

                    If tblRutas.Rows.Count > 0 AndAlso fun_VerificarCarpetaExistenteResolucion() = True Then

                        stNewPath = Trim(tblRutas.Rows(0).Item("RUTARUTA")) & "\" & Trim(stREAANURA) & "-" & fun_Formato_Mascara_4_String(Trim(stREAAFERA.ToString.Substring(6, 4)))

                        vl_stRutaResolucion = stNewPath

                        ChDir(stNewPath)

                        Me.lstLISTADO_RESOLUCION.Items.Clear()

                        ContentItem = Dir("*.pdf")

                        If ContentItem <> "" Then
                            Me.lstLISTADO_RESOLUCION.Focus()
                        End If

                        Do Until ContentItem = ""
                            ' agrega a la lista
                            Me.lstLISTADO_RESOLUCION.Items.Add(ContentItem)

                            'desplaza el registro
                            ContentItem = Dir()
                        Loop

                    Else
                        Me.lstLISTADO_RESOLUCION.Items.Clear()
                    End If
                Else
                    Me.lstLISTADO_RESOLUCION.Items.Clear()
                End If
            Else
                Me.lstLISTADO_RESOLUCION.Items.Clear()
            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub pro_LimpiarDocumentos()

        Me.lstLISTADO_DOCUMENTOS_RECLAMOS.Items.Clear()
        Me.lstLISTADO_IMAGENES.Items.Clear()
        Me.lstLISTADO_RESOLUCION.Items.Clear()

    End Sub

#End Region

#Region "PROCEDIMIENTOS INFORMACION DE USUARIO"

    Private Sub pro_ReconsultarInformacionDeUsuario()

        Try
            Dim objdatos As New cla_AJIPINUS

            If boCONSULTA = False Then
                Me.BindingSource_AJIPINUS_1.DataSource = objdatos.fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_AJIPINUS(Me.dgvAJUSIMPR.SelectedRows.Item(0).Cells("AJIPSECU").Value.ToString)
            Else
                Me.BindingSource_AJIPINUS_1.DataSource = objdatos.fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_AJIPINUS(Me.dgvAJUSIMPR.SelectedRows.Item(0).Cells("AJIPSECU").Value.ToString)
            End If

            Me.BindingNavigator_AJIPINUS_1.BindingSource = Me.BindingSource_AJIPINUS_1

            '==================================================
            '*** ASIGNA LOS PRIVILEGIOS DE LA BARRA DE MENU ***
            '==================================================

            Dim ContarRegistros As Integer = Me.BindingSource_AJIPINUS_1.Count

            Dim boCONTAGRE As Boolean = False
            Dim boCONTMODI As Boolean = False
            Dim boCONTELIM As Boolean = False
            Dim boCONTCONS As Boolean = False
            Dim boCONTRECO As Boolean = False

            pro_Permiso_Barra_De_Menu_Formulario_SubFormulario(ContarRegistros, Trim(Me.BindingNavigator_AJIPINUS_1.Name), boCONTAGRE, boCONTMODI, boCONTELIM, boCONTCONS, boCONTRECO)

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
            If Me.BindingSource_AJIPINUS_1.Count > 0 Then

                Dim objdatos As New cla_AJIPINUS
                Dim tbl As New DataTable

                tbl = objdatos.fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_AJIPINUS(Me.dgvAJUSIMPR.SelectedRows.Item(0).Cells("AJIPSECU").Value.ToString)

                If tbl.Rows.Count > 0 Then

                    Me.txtAJIUNUDO.Text = Trim(tbl.Rows(0).Item("AJIUNUDO"))
                    Me.txtAJIUFERE.Text = Trim(tbl.Rows(0).Item("AJIUFERE"))
                    Me.txtAJIUNOMB.Text = Trim(tbl.Rows(0).Item("AJIUNOMB"))
                    Me.txtAJIUPRAP.Text = Trim(tbl.Rows(0).Item("AJIUPRAP"))
                    Me.txtAJIUSEAP.Text = Trim(tbl.Rows(0).Item("AJIUSEAP"))
                    Me.txtAJIUTEL1.Text = Trim(tbl.Rows(0).Item("AJIUTEL1"))
                    Me.txtAJIUTEL2.Text = Trim(tbl.Rows(0).Item("AJIUTEL2"))
                    Me.txtAJIUCOEL.Text = Trim(tbl.Rows(0).Item("AJIUCOEL"))
                    Me.txtAJIUDIPR.Text = Trim(tbl.Rows(0).Item("AJIUDIPR"))
                    Me.txtAJIUDICO.Text = Trim(tbl.Rows(0).Item("AJIUDICO"))
                    Me.txtAJIUOBSE.Text = Trim(tbl.Rows(0).Item("AJIUOBSE"))

                End If

            Else
                pro_LimpiarInformacionUsuario()

            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub pro_LimpiarInformacionUsuario()

        Me.txtAJIUNUDO.Text = ""
        Me.txtAJIUFERE.Text = ""
        Me.txtAJIUNOMB.Text = ""
        Me.txtAJIUPRAP.Text = ""
        Me.txtAJIUSEAP.Text = ""
        Me.txtAJIUTEL1.Text = ""
        Me.txtAJIUTEL2.Text = ""
        Me.txtAJIUCOEL.Text = ""
        Me.txtAJIUDIPR.Text = ""
        Me.txtAJIUDICO.Text = ""
        Me.txtAJIUOBSE.Text = ""

    End Sub

#End Region

#Region "PROCEDIMIENTOS METERIAL DE USUARIO"

    Private Sub pro_ReconsultarMaterialDeUsuario()

        Try
            Dim objdatos As New cla_AJIPMAUS

            If boCONSULTA = False Then
                Me.BindingSource_AJIPMAUS_1.DataSource = objdatos.fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_AJIPMAUS(Me.dgvAJUSIMPR.SelectedRows.Item(0).Cells("AJIPSECU").Value.ToString)
            Else
                Me.BindingSource_AJIPMAUS_1.DataSource = objdatos.fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_AJIPMAUS(Me.dgvAJUSIMPR.SelectedRows.Item(0).Cells("AJIPSECU").Value.ToString)
            End If

            Me.dgvAJIPMAUS.DataSource = Me.BindingSource_AJIPMAUS_1
            Me.BindingNavigator_AJIPMAUS_1.BindingSource = Me.BindingSource_AJIPMAUS_1

            '==================================================
            '*** CONFIGURA OBJETOS DEL FORMULARIO MAESTRO ***
            '==================================================

            Me.dgvAJIPMAUS.Columns("AJMUIDRE").HeaderText = "idre"
            Me.dgvAJIPMAUS.Columns("AJMUSECU").HeaderText = "Secuencia"

            Me.dgvAJIPMAUS.Columns("AJMUMACA").HeaderText = "Código"
            Me.dgvAJIPMAUS.Columns("MACADESC").HeaderText = "Descripción"
            Me.dgvAJIPMAUS.Columns("AJMUFECH").HeaderText = "Fecha"
            Me.dgvAJIPMAUS.Columns("AJMUOBSE").HeaderText = "Observación"

            Me.dgvAJIPMAUS.Columns("AJMUIDRE").Visible = False
            Me.dgvAJIPMAUS.Columns("AJMUSECU").Visible = False
            Me.dgvAJIPMAUS.Columns("AJMUOBSE").Visible = False

            Me.dgvAJIPMAUS.Columns("AJMUMACA").Width = 30
            Me.dgvAJIPMAUS.Columns("MACADESC").Width = 100
            Me.dgvAJIPMAUS.Columns("AJMUFECH").Width = 100

            '==================================================
            '*** ASIGNA LOS PRIVILEGIOS DE LA BARRA DE MENU ***
            '==================================================

            Dim ContarRegistros As Integer = Me.BindingSource_AJIPMAUS_1.Count

            Dim boCONTAGRE As Boolean = False
            Dim boCONTMODI As Boolean = False
            Dim boCONTELIM As Boolean = False
            Dim boCONTCONS As Boolean = False
            Dim boCONTRECO As Boolean = False

            If Me.BindingSource_AJIPINUS_1.Count > 0 Then
                pro_Permiso_Barra_De_Menu_Formulario_SubFormulario(ContarRegistros, Trim(Me.BindingNavigator_AJIPMAUS_1.Name), boCONTAGRE, boCONTMODI, boCONTELIM, boCONTCONS, boCONTRECO)
            End If

            Me.cmdAGREGAR_AJIPMAUS.Enabled = boCONTAGRE
            Me.cmdMODIFICAR_AJIPMAUS.Enabled = boCONTMODI
            Me.cmdELIMINAR_AJIPMAUS.Enabled = boCONTELIM
            Me.cmdCONSULTAR_AJIPMAUS.Enabled = boCONTCONS
            Me.cmdRECONSULTAR_AJIPMAUS.Enabled = boCONTRECO

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try
    End Sub
    Private Sub pro_ListaDeValoresMaterialDeUsuario()

        Try
            If Me.dgvAJIPMAUS.RowCount > 0 Then

                Dim objdatos As New cla_AJIPMAUS
                Dim tbl As New DataTable

                tbl = objdatos.fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_AJIPMAUS(Me.dgvAJUSIMPR.SelectedRows.Item(0).Cells("AJIPSECU").Value.ToString)

                If tbl.Rows.Count > 0 Then
                    Me.txtAJMUOBSE.Text = Trim(tbl.Rows(0).Item("AJMUOBSE"))
                Else
                    Me.txtAJMUOBSE.Text = ""
                End If

            Else
                pro_LimpiarMaterialUsuario()

            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub pro_LimpiarMaterialUsuario()

        Me.txtAJMUOBSE.Text = ""

        Me.dgvAJIPMAUS.DataSource = New DataTable

    End Sub

#End Region

#Region "PROCEDIMIENTOS METERIAL DE CATASTRO"

    Private Sub pro_ReconsultarMaterialDeCatastro()

        Try
            Dim objdatos As New cla_AJIPMACA

            If boCONSULTA = False Then
                Me.BindingSource_AJIPMACA_1.DataSource = objdatos.fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_AJIPMACA(Me.dgvAJUSIMPR.SelectedRows.Item(0).Cells("AJIPSECU").Value.ToString)
            Else
                Me.BindingSource_AJIPMACA_1.DataSource = objdatos.fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_AJIPMACA(Me.dgvAJUSIMPR.SelectedRows.Item(0).Cells("AJIPSECU").Value.ToString)
            End If

            Me.dgvAJIPMACA.DataSource = Me.BindingSource_AJIPMACA_1
            Me.BindingNavigator_AJIPMACA_1.BindingSource = Me.BindingSource_AJIPMACA_1

            '==================================================
            '*** CONFIGURA OBJETOS DEL FORMULARIO MAESTRO ***
            '==================================================

            Me.dgvAJIPMACA.Columns("AJMCIDRE").HeaderText = "idre"
            Me.dgvAJIPMACA.Columns("AJMCSECU").HeaderText = "Secuencia"

            Me.dgvAJIPMACA.Columns("AJMCMACA").HeaderText = "Código"
            Me.dgvAJIPMACA.Columns("MACADESC").HeaderText = "Descripción"
            Me.dgvAJIPMACA.Columns("AJMCFECH").HeaderText = "Fecha"
            Me.dgvAJIPMACA.Columns("AJMCOBSE").HeaderText = "Observación"

            Me.dgvAJIPMACA.Columns("AJMCIDRE").Visible = False
            Me.dgvAJIPMACA.Columns("AJMCSECU").Visible = False
            Me.dgvAJIPMACA.Columns("AJMCOBSE").Visible = False

            Me.dgvAJIPMACA.Columns("AJMCMACA").Width = 30
            Me.dgvAJIPMACA.Columns("MACADESC").Width = 100
            Me.dgvAJIPMACA.Columns("AJMCFECH").Width = 100

            '==================================================
            '*** ASIGNA LOS PRIVILEGIOS DE LA BARRA DE MENU ***
            '==================================================

            Dim ContarRegistros As Integer = Me.BindingSource_AJIPMACA_1.Count

            Dim boCONTAGRE As Boolean = False
            Dim boCONTMODI As Boolean = False
            Dim boCONTELIM As Boolean = False
            Dim boCONTCONS As Boolean = False
            Dim boCONTRECO As Boolean = False

            If Me.BindingSource_AJIPMACA_1.Count > 0 Then
                pro_Permiso_Barra_De_Menu_Formulario_SubFormulario(ContarRegistros, Trim(Me.BindingNavigator_AJIPMACA_1.Name), boCONTAGRE, boCONTMODI, boCONTELIM, boCONTCONS, boCONTRECO)
            End If

            Me.cmdAGREGAR_AJIPMAUS.Enabled = boCONTAGRE
            Me.cmdMODIFICAR_AJIPMAUS.Enabled = boCONTMODI
            Me.cmdELIMINAR_AJIPMAUS.Enabled = boCONTELIM
            Me.cmdCONSULTAR_AJIPMAUS.Enabled = boCONTCONS
            Me.cmdRECONSULTAR_AJIPMAUS.Enabled = boCONTRECO

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try
    End Sub
    Private Sub pro_ListaDeValoresMaterialDeCatastro()

        Try
            If Me.dgvAJIPMACA.RowCount > 0 Then

                Dim objdatos As New cla_AJIPMACA
                Dim tbl As New DataTable

                tbl = objdatos.fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_AJIPMACA(Me.dgvAJUSIMPR.SelectedRows.Item(0).Cells("AJIPSECU").Value.ToString)

                If tbl.Rows.Count > 0 Then
                    Me.txtAJMCOBSE.Text = Trim(tbl.Rows(0).Item("AJMCOBSE"))
                Else
                    Me.txtAJMCOBSE.Text = ""
                End If

            Else
                pro_LimpiarMaterialCatastro()

            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub pro_LimpiarMaterialCatastro()

        Me.txtAJMCOBSE.Text = ""

        Me.dgvAJIPMACA.DataSource = New DataTable

    End Sub

#End Region

#Region "MENU AJUSTE PREDIAL"

    Private Sub cmdAGREGAR_AJUSIMPR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAGREGAR_AJUSIMPR.Click

        Try
            frm_insertar_AJUSIMPR.ShowDialog()

            If vp_inConsulta <> 0 Then
                boCONSULTA = True

                pro_ReconsultarAjustes()
                pro_ListaDeValoresAjustes()

                pro_ReconsultarAjustesRegistradosPorConsulta()
                pro_ReconsultarAjustesAsignadosPorConsulta()
                pro_ReconsultarAjustesPendientesPorConsulta()
                pro_ReconsultarAjustesFinalizadosPorConsulta()

                pro_ControlDeBotones()

                Me.tabINSCFICHPRED.SelectTab(TabAJIPINUS)

                If Me.dgvTRAMREGI.RowCount > 0 Then
                    Me.TabControl1.SelectTab(TabRegistrados)

                ElseIf Me.dgvTRAMASIG.RowCount > 0 Then
                    Me.TabControl1.SelectTab(TabAsignados)

                ElseIf Me.dgvTRAMPEND.RowCount > 0 Then
                    Me.TabControl1.SelectTab(TabPendientes)

                ElseIf Me.dgvTRAMFINA.RowCount > 0 Then
                    Me.TabControl1.SelectTab(TabFinalizados)
                End If

            Else
                Me.tabINSCFICHPRED.SelectTab(TabAJIPINUS)
            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub cmdMODIFICAR_AJUSIMPR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdMODIFICAR_AJUSIMPR.Click

        Try
            Dim frm_modificar As New frm_modificar_AJUSIMPR(Integer.Parse(Me.dgvAJUSIMPR.SelectedRows.Item(0).Cells(0).Value.ToString()))
            frm_modificar.ShowDialog()

            If vp_inConsulta <> 0 Then
                boCONSULTA = True

                pro_ReconsultarAjustes()
                pro_ListaDeValoresAjustes()

                pro_ReconsultarAjustesRegistradosPorConsulta()
                pro_ReconsultarAjustesAsignadosPorConsulta()
                pro_ReconsultarAjustesPendientesPorConsulta()
                pro_ReconsultarAjustesFinalizadosPorConsulta()

                pro_ControlDeBotones()

                Me.tabINSCFICHPRED.SelectTab(TabAJIPINUS)

                If Me.dgvTRAMREGI.RowCount > 0 Then
                    Me.TabControl1.SelectTab(TabRegistrados)

                ElseIf Me.dgvTRAMASIG.RowCount > 0 Then
                    Me.TabControl1.SelectTab(TabAsignados)

                ElseIf Me.dgvTRAMPEND.RowCount > 0 Then
                    Me.TabControl1.SelectTab(TabPendientes)

                ElseIf Me.dgvTRAMFINA.RowCount > 0 Then
                    Me.TabControl1.SelectTab(TabFinalizados)
                End If

            End If

            Me.tabINSCFICHPRED.SelectTab(TabAJIPINUS)

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub cmdELIMINAR_AJUSIMPR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdELIMINAR_AJUSIMPR.Click

        Try
            If MessageBox.Show("¿ Desea eliminar el registro seleccionado ? ", "Mensaje...", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then
                Dim objdatos As New cla_AJUSIMPR

                If objdatos.fun_Eliminar_IDRE_AJUSIMPR(Integer.Parse(Me.dgvAJUSIMPR.SelectedRows.Item(0).Cells(0).Value.ToString())) Then

                    boCONSULTA = False
                    pro_LimpiarCamposAjuste()
                    pro_ReconsultarAjustes()
                    pro_ListaDeValoresAjustes()
                Else
                    frm_INCO_eliminar_registro_padre_con_relación_de_registros_hijos.ShowDialog()
                End If

            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub cmdCONSULTAR_AJUSIMPR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCONSULTAR_AJUSIMPR.Click

        Try
            vp_inConsulta = 0

            frm_consultar_AJUSIMPR.ShowDialog()

            If vp_inConsulta > 0 Then
                boCONSULTA = True
            Else
                boCONSULTA = False
            End If

            pro_ReconsultarAjustes()
            pro_ListaDeValoresAjustes()

            pro_ReconsultarAjustesRegistradosPorConsulta()
            pro_ReconsultarAjustesAsignadosPorConsulta()
            pro_ReconsultarAjustesPendientesPorConsulta()
            pro_ReconsultarAjustesFinalizadosPorConsulta()

            Me.tabINSCFICHPRED.SelectTab(TabAJIPINUS)

            If Me.dgvTRAMREGI.RowCount > 0 Then
                Me.TabControl1.SelectTab(TabRegistrados)

            ElseIf Me.dgvTRAMASIG.RowCount > 0 Then
                Me.TabControl1.SelectTab(TabAsignados)

            ElseIf Me.dgvTRAMPEND.RowCount > 0 Then
                Me.TabControl1.SelectTab(TabPendientes)

            ElseIf Me.dgvTRAMFINA.RowCount > 0 Then
                Me.TabControl1.SelectTab(TabFinalizados)
            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub cmdRECONSULTAR_AJUSIMPR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdRECONSULTAR_AJUSIMPR.Click

        Try
            boCONSULTA = False
            pro_ReconsultarAjustes()
            pro_ListaDeValoresAjustes()

            pro_ReconsultarAjustesRegistrados()
            pro_ReconsultarAjustesAsignados()
            pro_ReconsultarAjustesPendientes()
            pro_ReconsultarAjustesFinalizados()

            pro_ControlDeBotones()

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
    Private Sub cmdIMPORTAR_DOCUMENTOS_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdIMPORTAR_AJUSIMPR.Click

        Try
            Try
                Dim frm_inserta_archivo As New frm_insertar_archivo_AJUSIMPR(Me.dgvAJUSIMPR.SelectedRows.Item(0).Cells("AJIPMUNI").Value.ToString(), _
                                                                             Me.dgvAJUSIMPR.SelectedRows.Item(0).Cells("AJIPCORR").Value.ToString(), _
                                                                             Me.dgvAJUSIMPR.SelectedRows.Item(0).Cells("AJIPBARR").Value.ToString(), _
                                                                             Me.dgvAJUSIMPR.SelectedRows.Item(0).Cells("AJIPMANZ").Value.ToString(), _
                                                                             Me.dgvAJUSIMPR.SelectedRows.Item(0).Cells("AJIPPRED").Value.ToString(), _
                                                                             Me.dgvAJUSIMPR.SelectedRows.Item(0).Cells("AJIPEDIF").Value.ToString(), _
                                                                             Me.dgvAJUSIMPR.SelectedRows.Item(0).Cells("AJIPUNPR").Value.ToString(), _
                                                                             Me.dgvAJUSIMPR.SelectedRows.Item(0).Cells("AJIPCLSE").Value.ToString(), _
                                                                             Me.dgvAJUSIMPR.SelectedRows.Item(0).Cells("AJIPVIGE").Value.ToString())
                frm_inserta_archivo.ShowDialog()

                pro_ListadoArchivosDocumentosRectificacion()
                pro_ListadoArchivosDocumentosAjuste()
                pro_ListadoArchivosImagenes()
                pro_ListadoArchivosResolucion()

            Catch ex As Exception
                MessageBox.Show(Err.Description)
            End Try



        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub

    Private Sub ToolStripButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton1.Click

        Try
            pro_ListaDeValoresAjustes()
            pro_ControlDeBotones()

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub ToolStripButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton2.Click

        Try
            pro_ListaDeValoresAjustes()
            pro_ControlDeBotones()

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub ToolStripButton3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton3.Click

        Try
            pro_ListaDeValoresAjustes()
            pro_ControlDeBotones()

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub ToolStripButton4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton4.Click

        Try
            pro_ListaDeValoresAjustes()
            pro_ControlDeBotones()

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub

    Private Sub cmdASIGNAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdASIGNAR.Click

        Try
            Me.TabControl1.SelectTab(TabRegistrados)

            pro_EjecutarBotonAsignar()
            pro_ControlDeBotones()

            pro_ListaDeValoresAjustesTramitesAsignados()

            pro_ListadoArchivosDocumentosRectificacion()
            pro_ListadoArchivosDocumentosAjuste()
            pro_ListadoArchivosImagenes()
            pro_ListadoArchivosResolucion()

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub cmdRECHAZAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdRECHAZAR.Click
        pro_EjecutarBotonRechazar()
    End Sub
    Private Sub cmdFINALIZAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdFINALIZAR.Click
        pro_EjecutarBotonFinalizar()
    End Sub
    Private Sub cmdOBSERVACIONES_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOBSERVACIONES.Click
        pro_EjecutarBotonObservacion()
    End Sub

#End Region

#Region "MENU INFORMACION DE USUARIO"

    Private Sub cmdAGREGAR_INFOUSUA_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAGREGAR_INFOUSUA.Click

        Try
            Dim frm_modificar As New frm_insertar_AJIPINUS(Integer.Parse(Me.dgvAJUSIMPR.SelectedRows.Item(0).Cells("AJIPSECU").Value.ToString()))
            frm_modificar.ShowDialog()
            boCONSULTA = False

            pro_ReconsultarInformacionDeUsuario()
            pro_ListaDeValoresInformacionDeUsuario()

            pro_ReconsultarMaterialDeUsuario()
            pro_ListaDeValoresMaterialDeUsuario()

            If Me.dgvAJIPMAUS.RowCount = 0 Then
                If MessageBox.Show("¿ Desea agregar el material aportado por el usuario ?", "Mensaje ...", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then
                    Me.tabINSCFICHPRED.SelectTab(TabAJIPINUS)
                    Me.cmdAGREGAR_AJIPMAUS.PerformClick()
                End If
            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub cmdMODIFICAR_INFOUSUA_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdMODIFICAR_INFOUSUA.Click

        Try
            Dim frm_modificar As New frm_insertar_AJIPINUS(Integer.Parse(Me.dgvAJUSIMPR.SelectedRows.Item(0).Cells("AJIPSECU").Value.ToString()))
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
                Dim objdatos As New cla_AJIPINUS

                If objdatos.fun_Eliminar_SECU_AJIPINUS(Integer.Parse(Me.dgvAJUSIMPR.SelectedRows.Item(0).Cells("AJIPSECU").Value.ToString())) Then
                    boCONSULTA = False

                    pro_LimpiarInformacionUsuario()
                    pro_ReconsultarInformacionDeUsuario()
                    pro_ListaDeValoresInformacionDeUsuario()

                    If Me.dgvAJIPMAUS.RowCount > 0 Then

                        Dim objdatos1 As New cla_AJIPMAUS
                        objdatos1.fun_Eliminar_SECU_AJIPMAUS(Integer.Parse(Me.dgvAJIPMAUS.SelectedRows.Item(0).Cells("AJMUSECU").Value.ToString()))

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

            pro_ReconsultarAjustes()
            pro_ListaDeValoresAjustes()

            pro_ReconsultarAjustesRegistradosPorConsulta()
            pro_ReconsultarAjustesAsignadosPorConsulta()
            pro_ReconsultarAjustesPendientesPorConsulta()
            pro_ReconsultarAjustesFinalizadosPorConsulta()

            Me.tabINSCFICHPRED.SelectTab(TabAJIPINUS)

            If Me.dgvTRAMREGI.RowCount > 0 Then
                Me.TabControl1.SelectTab(TabRegistrados)

            ElseIf Me.dgvTRAMASIG.RowCount > 0 Then
                Me.TabControl1.SelectTab(TabAsignados)

            ElseIf Me.dgvTRAMPEND.RowCount > 0 Then
                Me.TabControl1.SelectTab(TabPendientes)

            ElseIf Me.dgvTRAMFINA.RowCount > 0 Then
                Me.TabControl1.SelectTab(TabFinalizados)
            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub cmdRECONSULTAR_INFOUSUA_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdRECONSULTAR_INFOUSUA.Click

        Try
            boCONSULTA = False
            pro_ReconsultarAjustes()
            pro_ListaDeValoresAjustes()

            pro_ReconsultarAjustesRegistrados()
            pro_ReconsultarAjustesAsignados()
            pro_ReconsultarAjustesPendientes()
            pro_ReconsultarAjustesFinalizados()

            pro_ControlDeBotones()

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

    Private Sub cmdAGREGAR_MATEUSUA_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAGREGAR_AJIPMAUS.Click

        Try
            Dim frm_modificar As New frm_insertar_AJIPMAUS(Integer.Parse(Me.dgvAJUSIMPR.SelectedRows.Item(0).Cells("AJIPSECU").Value.ToString()), Me.Name)
            frm_modificar.ShowDialog()
            boCONSULTA = False

            pro_ReconsultarMaterialDeUsuario()
            pro_ListaDeValoresMaterialDeUsuario()

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub cmdMODIFICAR_MATEUSUA_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdMODIFICAR_AJIPMAUS.Click

        Try
            Dim frm_modificar As New frm_insertar_AJIPMAUS(Integer.Parse(Me.dgvAJUSIMPR.SelectedRows.Item(0).Cells("AJIPSECU").Value.ToString()), Me.Name)
            frm_modificar.ShowDialog()
            boCONSULTA = False

            pro_ReconsultarMaterialDeUsuario()
            pro_ListaDeValoresMaterialDeUsuario()

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub cmdELIMINAR_MATEUSUA_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdELIMINAR_AJIPMAUS.Click

        Try
            If MessageBox.Show("¿ Desea eliminar el registro seleccionado ? ", "Mensaje...", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then
                Dim objdatos As New cla_AJIPMAUS

                If objdatos.fun_Eliminar_SECU_X_MACA_AJIPMAUS(Integer.Parse(Me.dgvAJIPMAUS.SelectedRows.Item(0).Cells("AJMUSECU").Value.ToString()), _
                                                              Integer.Parse(Me.dgvAJIPMAUS.SelectedRows.Item(0).Cells("AJMUMACA").Value.ToString())) Then
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
    Private Sub cmdCONSULTAR_MATEUSUA_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCONSULTAR_AJIPMAUS.Click

        Try
            vp_inConsulta = 0

            frm_consultar_AJUSIMPR.ShowDialog()

            If vp_inConsulta > 0 Then
                boCONSULTA = True
            Else
                boCONSULTA = False
            End If

            pro_ReconsultarAjustes()
            pro_ListaDeValoresAjustes()

            pro_ReconsultarAjustesRegistradosPorConsulta()
            pro_ReconsultarAjustesAsignadosPorConsulta()
            pro_ReconsultarAjustesPendientesPorConsulta()
            pro_ReconsultarAjustesFinalizadosPorConsulta()

            Me.tabINSCFICHPRED.SelectTab(TabAJIPINUS)

            If Me.dgvTRAMREGI.RowCount > 0 Then
                Me.TabControl1.SelectTab(TabRegistrados)

            ElseIf Me.dgvTRAMASIG.RowCount > 0 Then
                Me.TabControl1.SelectTab(TabAsignados)

            ElseIf Me.dgvTRAMPEND.RowCount > 0 Then
                Me.TabControl1.SelectTab(TabPendientes)

            ElseIf Me.dgvTRAMFINA.RowCount > 0 Then
                Me.TabControl1.SelectTab(TabFinalizados)
            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub cmdRECONSULTAR_MATEUSUA_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdRECONSULTAR_AJIPMAUS.Click

        Try
            boCONSULTA = False
            pro_ReconsultarAjustes()
            pro_ListaDeValoresAjustes()

            pro_ReconsultarAjustesRegistradosPorConsulta()
            pro_ReconsultarAjustesAsignadosPorConsulta()
            pro_ReconsultarAjustesPendientesPorConsulta()
            pro_ReconsultarAjustesFinalizadosPorConsulta()

            Me.tabINSCFICHPRED.SelectTab(TabAJIPINUS)

            If Me.dgvTRAMREGI.RowCount > 0 Then
                Me.TabControl1.SelectTab(TabRegistrados)

            ElseIf Me.dgvTRAMASIG.RowCount > 0 Then
                Me.TabControl1.SelectTab(TabAsignados)

            ElseIf Me.dgvTRAMPEND.RowCount > 0 Then
                Me.TabControl1.SelectTab(TabPendientes)

            ElseIf Me.dgvTRAMFINA.RowCount > 0 Then
                Me.TabControl1.SelectTab(TabFinalizados)
            End If

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

#Region "MENU MATERIAL CATASTRO"

    Private Sub cmdAGREGAR_AJIPMACA_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAGREGAR_AJIPMACA.Click

        Try
            Dim frm_modificar As New frm_insertar_AJIPMACA(Integer.Parse(Me.dgvAJUSIMPR.SelectedRows.Item(0).Cells("AJIPSECU").Value.ToString()), Me.Name)
            frm_modificar.ShowDialog()
            boCONSULTA = False

            pro_ReconsultarMaterialDeCatastro()
            pro_ListaDeValoresMaterialDeCatastro()

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub cmdMODIFICAR_AJIPMACA_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdMODIFICAR_AJIPMACA.Click

        Try
            Dim frm_modificar As New frm_insertar_AJIPMACA(Integer.Parse(Me.dgvAJUSIMPR.SelectedRows.Item(0).Cells("AJIPSECU").Value.ToString()), Me.Name)
            frm_modificar.ShowDialog()
            boCONSULTA = False

            pro_ReconsultarMaterialDeCatastro()
            pro_ListaDeValoresMaterialDeCatastro()

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub cmdELIMINAR_AJIPMACA_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdELIMINAR_AJIPMACA.Click

        Try
            If MessageBox.Show("¿ Desea eliminar el registro seleccionado ? ", "Mensaje...", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then
                Dim objdatos As New cla_AJIPMACA

                If objdatos.fun_Eliminar_SECU_X_MACA_AJIPMACA(Integer.Parse(Me.dgvAJIPMACA.SelectedRows.Item(0).Cells("AJMCSECU").Value.ToString()), _
                                                              Integer.Parse(Me.dgvAJIPMACA.SelectedRows.Item(0).Cells("AJMCMACA").Value.ToString())) Then
                    boCONSULTA = False

                    pro_LimpiarMaterialCatastro()
                    pro_ReconsultarMaterialDeCatastro()
                    pro_ListaDeValoresMaterialDeCatastro()
                Else
                    frm_INCO_eliminar_registro_padre_con_relación_de_registros_hijos.ShowDialog()
                End If

            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub cmdCONSULTAR_AJIPMACA_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCONSULTAR_AJIPMACA.Click

        Try
            vp_inConsulta = 0

            frm_consultar_AJUSIMPR.ShowDialog()

            If vp_inConsulta > 0 Then
                boCONSULTA = True
            Else
                boCONSULTA = False
            End If

            pro_ReconsultarAjustes()
            pro_ListaDeValoresAjustes()

            pro_ReconsultarAjustesRegistradosPorConsulta()
            pro_ReconsultarAjustesAsignadosPorConsulta()
            pro_ReconsultarAjustesPendientesPorConsulta()
            pro_ReconsultarAjustesFinalizadosPorConsulta()

            Me.tabINSCFICHPRED.SelectTab(TabAJIPINUS)

            If Me.dgvTRAMREGI.RowCount > 0 Then
                Me.TabControl1.SelectTab(TabRegistrados)

            ElseIf Me.dgvTRAMASIG.RowCount > 0 Then
                Me.TabControl1.SelectTab(TabAsignados)

            ElseIf Me.dgvTRAMPEND.RowCount > 0 Then
                Me.TabControl1.SelectTab(TabPendientes)

            ElseIf Me.dgvTRAMFINA.RowCount > 0 Then
                Me.TabControl1.SelectTab(TabFinalizados)
            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub cmdRECONSULTAR_AJIPMACA_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdRECONSULTAR_AJIPMACA.Click

        Try
            boCONSULTA = False
            pro_ReconsultarAjustes()
            pro_ListaDeValoresAjustes()

            pro_ReconsultarAjustesRegistradosPorConsulta()
            pro_ReconsultarAjustesAsignadosPorConsulta()
            pro_ReconsultarAjustesPendientesPorConsulta()
            pro_ReconsultarAjustesFinalizadosPorConsulta()

            Me.tabINSCFICHPRED.SelectTab(TabAJIPINUS)

            If Me.dgvTRAMREGI.RowCount > 0 Then
                Me.TabControl1.SelectTab(TabRegistrados)

            ElseIf Me.dgvTRAMASIG.RowCount > 0 Then
                Me.TabControl1.SelectTab(TabAsignados)

            ElseIf Me.dgvTRAMPEND.RowCount > 0 Then
                Me.TabControl1.SelectTab(TabPendientes)

            ElseIf Me.dgvTRAMFINA.RowCount > 0 Then
                Me.TabControl1.SelectTab(TabFinalizados)
            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub

    Private Sub ToolStripButton82_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton82.Click
        pro_ListaDeValoresMaterialDeCatastro()
    End Sub
    Private Sub ToolStripButton83_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton83.Click
        pro_ListaDeValoresMaterialDeCatastro()
    End Sub
    Private Sub ToolStripButton84_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton84.Click
        pro_ListaDeValoresMaterialDeCatastro()
    End Sub
    Private Sub ToolStripButton85_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton85.Click
        pro_ListaDeValoresMaterialDeCatastro()
    End Sub

#End Region

#Region "FORMULARIO"

#Region "Load"

    Private Sub frm_TRABCAMP_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        vp_inConsulta = 0
        boCONSULTA = True

        pro_ReconsultarAjustes()
        pro_ControlDeBotones()

        pro_ListadoArchivosDocumentosRectificacion()
        pro_ListadoArchivosDocumentosAjuste()
        pro_ListadoArchivosImagenes()
        pro_ListadoArchivosResolucion()

        Me.strBARRESTA.Items(0).Text = "Ajuste Impuesto"

    End Sub

#End Region

#Region "GotFocus"

    Private Sub frm_AJUSIMPR_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.GotFocus
        pro_ListaDeValoresAjustes()
    End Sub
    Private Sub dgvAJUSIMPR_1_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvAJUSIMPR.GotFocus
        Me.strBARRESTA.Items(0).Text = dgvAJUSIMPR.AccessibleDescription
    End Sub

#End Region

#Region "KeyDown"

    Private Sub dgvAJUSIMPR_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgvAJUSIMPR.KeyDown
        '===============================================================================================
        '*** INSERTAR REGISTROS ***
        '===============================================================================================


        If e.KeyCode = Keys.F2 Then
            If Me.cmdAGREGAR_AJUSIMPR.Enabled = True Then
                Me.cmdAGREGAR_AJUSIMPR.PerformClick()
            Else
                mod_MENSAJE.Usuario_No_Tiene_Permiso_Para_Realizar_La_Operacion()
            End If
        End If

        '===============================================================================================
        'MODIFICAR REGISTROS
        '===============================================================================================

        If e.KeyCode = Keys.F3 Then
            If Me.cmdMODIFICAR_AJUSIMPR.Enabled = True Then
                Me.cmdMODIFICAR_AJUSIMPR.PerformClick()
            Else
                Dim ContarRegistros As Integer = Me.BindingSource_AJUSIMPR_1.Count

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
            If Me.cmdELIMINAR_AJUSIMPR.Enabled = True Then
                Me.cmdELIMINAR_AJUSIMPR.PerformClick()
            Else
                Dim ContarRegistros As Integer = Me.BindingSource_AJUSIMPR_1.Count

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
            If Me.cmdCONSULTAR_AJUSIMPR.Enabled = True Then
                Me.cmdCONSULTAR_AJUSIMPR.PerformClick()
            Else
                mod_MENSAJE.No_Existen_Registros_En_Base_De_Datos()
            End If
        End If

        '===============================================================================================
        '*** RECONSULTAR REGISTROS ***
        '===============================================================================================

        If e.KeyCode = Keys.F8 Then
            If Me.cmdCONSULTAR_AJUSIMPR.Enabled = True Then
                Me.cmdRECONSULTAR_AJUSIMPR.PerformClick()
            Else
                mod_MENSAJE.No_Existen_Registros_En_Base_De_Datos()
            End If
        End If

    End Sub

#End Region

#Region "KeyUp"

    Private Sub dgvAJUSIMPR_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgvAJUSIMPR.KeyUp
        If e.KeyCode = Keys.Down Or e.KeyCode = Keys.Up Or e.KeyCode = Keys.Enter Or e.KeyCode = Keys.PageUp Or e.KeyCode = Keys.PageDown Then
            pro_ListaDeValoresAjustes()
            pro_ControlDeBotones()
        End If
    End Sub
    Private Sub dgvTRAMREGI_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgvTRAMREGI.KeyUp
        If e.KeyCode = Keys.Down Or e.KeyCode = Keys.Up Or e.KeyCode = Keys.Enter Or e.KeyCode = Keys.PageUp Or e.KeyCode = Keys.PageDown Then
            pro_ListaDeValoresAjustesTramitesRegistrados()
            pro_ReconsultarAjustesRegistradosPorTramite()

            pro_ReconsultarInformacionDeUsuario()
            pro_ListaDeValoresInformacionDeUsuario()

            pro_ReconsultarMaterialDeUsuario()
            pro_ListaDeValoresMaterialDeUsuario()

            pro_ReconsultarMaterialDeCatastro()
            pro_ListaDeValoresMaterialDeCatastro()

            pro_ControlDeBotones()

            pro_ListadoArchivosDocumentosRectificacion()
            pro_ListadoArchivosDocumentosAjuste()
            pro_ListadoArchivosImagenes()
            pro_ListadoArchivosResolucion()
        End If
    End Sub
    Private Sub dgvTRAMASIG_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgvTRAMASIG.KeyUp
        If e.KeyCode = Keys.Down Or e.KeyCode = Keys.Up Or e.KeyCode = Keys.Enter Or e.KeyCode = Keys.PageUp Or e.KeyCode = Keys.PageDown Then
            pro_ListaDeValoresAjustesTramitesAsignados()
            pro_ReconsultarAjustesAsignadosPorTramite()

            pro_ReconsultarInformacionDeUsuario()
            pro_ListaDeValoresInformacionDeUsuario()

            pro_ReconsultarMaterialDeUsuario()
            pro_ListaDeValoresMaterialDeUsuario()

            pro_ReconsultarMaterialDeCatastro()
            pro_ListaDeValoresMaterialDeCatastro()

            pro_ControlDeBotones()

            pro_ListadoArchivosDocumentosRectificacion()
            pro_ListadoArchivosDocumentosAjuste()
            pro_ListadoArchivosImagenes()
            pro_ListadoArchivosResolucion()
        End If
    End Sub
    Private Sub dgvTRAMPEND_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgvTRAMPEND.KeyUp
        If e.KeyCode = Keys.Down Or e.KeyCode = Keys.Up Or e.KeyCode = Keys.Enter Or e.KeyCode = Keys.PageUp Or e.KeyCode = Keys.PageDown Then
            pro_ListaDeValoresAjustesTramitesPendientes()
            pro_ReconsultarAjustesPendientesPorTramite()

            pro_ReconsultarInformacionDeUsuario()
            pro_ListaDeValoresInformacionDeUsuario()

            pro_ReconsultarMaterialDeUsuario()
            pro_ListaDeValoresMaterialDeUsuario()

            pro_ReconsultarMaterialDeCatastro()
            pro_ListaDeValoresMaterialDeCatastro()

            pro_ControlDeBotones()

            pro_ListadoArchivosDocumentosRectificacion()
            pro_ListadoArchivosDocumentosAjuste()
            pro_ListadoArchivosImagenes()
            pro_ListadoArchivosResolucion()
        End If
    End Sub
    Private Sub dgvTRAMFINA_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgvTRAMFINA.KeyUp
        If e.KeyCode = Keys.Down Or e.KeyCode = Keys.Up Or e.KeyCode = Keys.Enter Or e.KeyCode = Keys.PageUp Or e.KeyCode = Keys.PageDown Then
            pro_ListaDeValoresAjustesTramitesFinalizados()
            pro_ReconsultarAjustesFinalizadosPorTramite()

            pro_ReconsultarInformacionDeUsuario()
            pro_ListaDeValoresInformacionDeUsuario()

            pro_ReconsultarMaterialDeUsuario()
            pro_ListaDeValoresMaterialDeUsuario()

            pro_ReconsultarMaterialDeCatastro()
            pro_ListaDeValoresMaterialDeCatastro()

            pro_ControlDeBotones()

            pro_ListadoArchivosDocumentosRectificacion()
            pro_ListadoArchivosDocumentosAjuste()
            pro_ListadoArchivosImagenes()
            pro_ListadoArchivosResolucion()
        End If
    End Sub

#End Region

#Region "CellClick"

    Private Sub dgvAJUSIMPR_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvAJUSIMPR.CellClick
        pro_ListaDeValoresAjustes()
        pro_ListaDeValoresInformacionDeUsuario()

        pro_ControlDeBotones()

    End Sub
    Private Sub dgvTRAMREGI_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvTRAMREGI.CellClick
        pro_ListaDeValoresAjustesTramitesRegistrados()
        pro_ReconsultarAjustesRegistradosPorTramite()

        pro_ReconsultarInformacionDeUsuario()
        pro_ListaDeValoresInformacionDeUsuario()

        pro_ReconsultarMaterialDeUsuario()
        pro_ListaDeValoresMaterialDeUsuario()

        pro_ReconsultarMaterialDeCatastro()
        pro_ListaDeValoresMaterialDeCatastro()

        pro_ControlDeBotones()

        pro_ListadoArchivosDocumentosRectificacion()
        pro_ListadoArchivosDocumentosAjuste()
        pro_ListadoArchivosImagenes()
        pro_ListadoArchivosResolucion()

    End Sub
    Private Sub dgvTRAMASIG_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvTRAMASIG.CellClick
        pro_ListaDeValoresAjustesTramitesAsignados()
        pro_ReconsultarAjustesAsignadosPorTramite()

        pro_ReconsultarInformacionDeUsuario()
        pro_ListaDeValoresInformacionDeUsuario()

        pro_ReconsultarMaterialDeUsuario()
        pro_ListaDeValoresMaterialDeUsuario()

        pro_ReconsultarMaterialDeCatastro()
        pro_ListaDeValoresMaterialDeCatastro()

        pro_ControlDeBotones()

        pro_ListadoArchivosDocumentosRectificacion()
        pro_ListadoArchivosDocumentosAjuste()
        pro_ListadoArchivosImagenes()
        pro_ListadoArchivosResolucion()
    End Sub
    Private Sub dgvTRAMPEND_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvTRAMPEND.CellClick
        pro_ListaDeValoresAjustesTramitesPendientes()
        pro_ReconsultarAjustesPendientesPorTramite()

        pro_ReconsultarInformacionDeUsuario()
        pro_ListaDeValoresInformacionDeUsuario()

        pro_ReconsultarMaterialDeUsuario()
        pro_ListaDeValoresMaterialDeUsuario()

        pro_ReconsultarMaterialDeCatastro()
        pro_ListaDeValoresMaterialDeCatastro()

        pro_ControlDeBotones()

        pro_ListadoArchivosDocumentosRectificacion()
        pro_ListadoArchivosDocumentosAjuste()
        pro_ListadoArchivosImagenes()
        pro_ListadoArchivosResolucion()
    End Sub
    Private Sub dgvTRAMFINA_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvTRAMFINA.CellClick
        pro_ListaDeValoresAjustesTramitesFinalizados()
        pro_ReconsultarAjustesFinalizadosPorTramite()

        pro_ReconsultarInformacionDeUsuario()
        pro_ListaDeValoresInformacionDeUsuario()

        pro_ReconsultarMaterialDeUsuario()
        pro_ListaDeValoresMaterialDeUsuario()

        pro_ReconsultarMaterialDeCatastro()
        pro_ListaDeValoresMaterialDeCatastro()

        pro_ControlDeBotones()

        pro_ListadoArchivosDocumentosRectificacion()
        pro_ListadoArchivosDocumentosAjuste()
        pro_ListadoArchivosImagenes()
        pro_ListadoArchivosResolucion()
    End Sub

#End Region

#Region "DoubleClick"

    Private Sub lstLISTADO_DOCUMENTOS_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles lstLISTADO_DOCUMENTOS_RECLAMOS.DoubleClick

        Try
            If lstLISTADO_DOCUMENTOS_RECLAMOS.SelectedIndex <> -1 Then

                Dim stArchivo As String = lstLISTADO_DOCUMENTOS_RECLAMOS.SelectedItem
                Process.Start(vl_stRutaDocumentosRectificaciones & "\" & stArchivo)
            Else

                If lstLISTADO_DOCUMENTOS_RECLAMOS.Items.Count > 0 Then
                    MessageBox.Show("Seleccione un archivo de la lista", "mensaje...", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                End If

            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub lstLISTADO_IMAGENES_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles lstLISTADO_IMAGENES.DoubleClick

        Try
            If lstLISTADO_IMAGENES.SelectedIndex <> -1 Then

                Dim stArchivo As String = lstLISTADO_IMAGENES.SelectedItem
                Process.Start(vl_stRutaImagenes & "\" & stArchivo)
            Else

                If lstLISTADO_IMAGENES.Items.Count > 0 Then
                    MessageBox.Show("Seleccione un archivo de la lista", "mensaje...", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                End If

            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub lstLISTADO_RESOLUCION_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles lstLISTADO_RESOLUCION.DoubleClick

        Try
            If lstLISTADO_RESOLUCION.SelectedIndex <> -1 Then

                Dim stArchivo As String = lstLISTADO_RESOLUCION.SelectedItem
                Process.Start(vl_stRutaResolucion & "\" & stArchivo)
            Else

                If lstLISTADO_RESOLUCION.Items.Count > 0 Then
                    MessageBox.Show("Seleccione un archivo de la lista", "mensaje...", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                End If

            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub lstLISTADO_DOCUMENTOS_AJUSTES_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles lstLISTADO_DOCUMENTOS_AJUSTES.DoubleClick

        Try
            If lstLISTADO_DOCUMENTOS_AJUSTES.SelectedIndex <> -1 Then

                Dim stArchivo As String = lstLISTADO_DOCUMENTOS_AJUSTES.SelectedItem
                Process.Start(vl_stRutaDocumentosAjustesPredial & "\" & stArchivo)
            Else

                If lstLISTADO_DOCUMENTOS_AJUSTES.Items.Count > 0 Then
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