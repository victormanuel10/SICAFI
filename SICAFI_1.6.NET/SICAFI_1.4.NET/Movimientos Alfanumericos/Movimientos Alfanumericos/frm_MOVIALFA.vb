Imports REGLAS_DEL_NEGOCIO
Imports System
Imports System.IO
Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration
Imports System.Text

Public Class frm_MOVIALFA

    '===============================
    '*** MOVIMIENTOS ALNUMERICOS ***
    '===============================

#Region "VARIABLES"

    Dim vl_boCONSULTA As Boolean = False

    Dim vl_stRutaDocumentosMovimientosGeograficos As String = ""
    Dim vl_stRutaDocumentosMovimientosAlfanumericos As String = ""
    Dim vl_stRutaDocumentosTrabajoDeCampo As String = ""

    Private oEjecutar As New SqlCommand
    Private oConexion As New SqlConnection
    Private oAdapter As New SqlDataAdapter
    Private oReader As SqlDataReader
    Private ds As New DataSet
    Private dt As New DataTable

    Dim vl_boPENDIENTES As Boolean = False
    Dim vl_boRECONSULTAR As Boolean = False

    Dim boExistenRegistrosPendientes As Boolean = False

#End Region

#Region "INSTANCIAR FORMULARIO"

    Private Shared frm_Instance = Nothing

    Public Shared Function instance() As frm_MOVIALFA
        If frm_Instance Is Nothing OrElse frm_Instance.isdisposed = True Then
            frm_Instance = New frm_MOVIALFA
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

    Private Function fun_VerificarCarpetaExistenteDocumentosMovimientosAlfanumericos(ByVal boPendientes As Boolean) As Boolean

        Try
            Dim stRuta As String = ""
            Dim stCarpetaABuscar As String = ""

            ' instancia la clase
            Dim objRutas As New cla_RUTAS
            Dim tblRutas As New DataTable

            tblRutas = objRutas.fun_Buscar_CODIGO_MANT_RUTAS(16)

            If tblRutas.Rows.Count > 0 Then

                ' directorio pricipal
                stRuta = Trim(tblRutas.Rows(0).Item("RUTARUTA")) & "\"

                ' consulta del grib movimientos generales
                If boPendientes = False Then

                    ' directorio expediente 
                    stCarpetaABuscar = Trim(Me.dgvMOALGEOG.SelectedRows.Item(0).Cells("MOALMUNI").Value.ToString) & "-" & _
                                       Trim(Me.dgvMOALGEOG.SelectedRows.Item(0).Cells("MOALCLSE").Value.ToString) & "-" & _
                                       Trim(Me.dgvMOALGEOG.SelectedRows.Item(0).Cells("MOALCORR").Value.ToString) & "-" & _
                                       Trim(Me.dgvMOALGEOG.SelectedRows.Item(0).Cells("MOALBARR").Value.ToString) & "-" & _
                                       Trim(Me.dgvMOALGEOG.SelectedRows.Item(0).Cells("MOALMANZ").Value.ToString) & "-" & _
                                       Trim(Me.dgvMOALGEOG.SelectedRows.Item(0).Cells("MOALPRED").Value.ToString) & "-" & _
                                       Trim(Me.dgvMOALGEOG.SelectedRows.Item(0).Cells("MOALVIGE").Value.ToString)

                    ' consulta del grib movimientos pendientes
                ElseIf boPendientes = True Then

                    ' directorio expediente 
                    stCarpetaABuscar = Trim(Me.dgvMOALPEND.SelectedRows.Item(0).Cells("MOALMUNI").Value.ToString) & "-" & _
                                       Trim(Me.dgvMOALPEND.SelectedRows.Item(0).Cells("MOALCLSE").Value.ToString) & "-" & _
                                       Trim(Me.dgvMOALPEND.SelectedRows.Item(0).Cells("MOALCORR").Value.ToString) & "-" & _
                                       Trim(Me.dgvMOALPEND.SelectedRows.Item(0).Cells("MOALBARR").Value.ToString) & "-" & _
                                       Trim(Me.dgvMOALPEND.SelectedRows.Item(0).Cells("MOALMANZ").Value.ToString) & "-" & _
                                       Trim(Me.dgvMOALPEND.SelectedRows.Item(0).Cells("MOALPRED").Value.ToString) & "-" & _
                                       Trim(Me.dgvMOALPEND.SelectedRows.Item(0).Cells("MOALVIGE").Value.ToString)

                End If

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
    Private Function fun_VerificarCarpetaExistenteDocumentosTrabajoDeCampo(ByVal boPendientes As Boolean) As Boolean

        Try
            Dim stRuta As String = ""
            Dim stCarpetaABuscar As String = ""

            ' instancia la clase
            Dim objRutas As New cla_RUTAS
            Dim tblRutas As New DataTable

            tblRutas = objRutas.fun_Buscar_CODIGO_MANT_RUTAS(6)

            If tblRutas.Rows.Count > 0 Then

                ' directorio pricipal
                stRuta = Trim(tblRutas.Rows(0).Item("RUTARUTA")) & "\"

                ' consulta del grib movimientos generales
                If boPendientes = False Then

                    ' directorio expediente 
                    stCarpetaABuscar = Trim(Me.dgvMOALGEOG.SelectedRows.Item(0).Cells("MOALMUNI").Value.ToString) & "-" & _
                                       Trim(Me.dgvMOALGEOG.SelectedRows.Item(0).Cells("MOALCLSE").Value.ToString) & "-" & _
                                       Trim(Me.dgvMOALGEOG.SelectedRows.Item(0).Cells("MOALCORR").Value.ToString) & "-" & _
                                       Trim(Me.dgvMOALGEOG.SelectedRows.Item(0).Cells("MOALBARR").Value.ToString) & "-" & _
                                       Trim(Me.dgvMOALGEOG.SelectedRows.Item(0).Cells("MOALMANZ").Value.ToString) & "-" & _
                                       Trim(Me.dgvMOALGEOG.SelectedRows.Item(0).Cells("MOALPRED").Value.ToString) & "-" & _
                                       Trim(Me.dgvMOALGEOG.SelectedRows.Item(0).Cells("MOALVIGE").Value.ToString)

                    ' consulta del grib movimientos pendientes
                ElseIf boPendientes = True Then

                    ' directorio expediente 
                    stCarpetaABuscar = Trim(Me.dgvMOALPEND.SelectedRows.Item(0).Cells("MOALMUNI").Value.ToString) & "-" & _
                                       Trim(Me.dgvMOALPEND.SelectedRows.Item(0).Cells("MOALCLSE").Value.ToString) & "-" & _
                                       Trim(Me.dgvMOALPEND.SelectedRows.Item(0).Cells("MOALCORR").Value.ToString) & "-" & _
                                       Trim(Me.dgvMOALPEND.SelectedRows.Item(0).Cells("MOALBARR").Value.ToString) & "-" & _
                                       Trim(Me.dgvMOALPEND.SelectedRows.Item(0).Cells("MOALMANZ").Value.ToString) & "-" & _
                                       Trim(Me.dgvMOALPEND.SelectedRows.Item(0).Cells("MOALPRED").Value.ToString) & "-" & _
                                       Trim(Me.dgvMOALPEND.SelectedRows.Item(0).Cells("MOALVIGE").Value.ToString)

                End If

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

    Private Function fun_ContarTramitesPendientes() As Integer

        Dim inRegistros As Integer = Me.dgvMOALPEND.RowCount

        Return inRegistros

    End Function
    Private Function fun_ContarTramitesGenerales() As Integer

        Dim inRegistros As Integer = Me.dgvMOALGEOG.RowCount

        Return inRegistros

    End Function

#End Region

#Region "PROCEDIMIENTOS MOVIMIENTOS ALFANUMERICOS"

    Private Sub pro_ReconsultarMovimientosAlfanumericos()

        Try
            Dim objdatos As New cla_MOVIALFA

            If vl_boCONSULTA = False Then

                Me.BindingSource_MOVIALFA_1.DataSource = objdatos.fun_Consultar_MOVIALFA(vl_boRECONSULTAR)

                Dim dt As New DataTable
                dt = objdatos.fun_Buscar_CONSULTA_MOVIALFA_X_USUARIO(vp_cedula)

                If dt.Rows.Count > 0 Then
                    Me.dgvMOALPEND.DataSource = objdatos.fun_Buscar_CONSULTA_MOVIALFA_X_USUARIO(vp_cedula)
                    boExistenRegistrosPendientes = True
                Else
                    Me.dgvMOALPEND.DataSource = objdatos.fun_Buscar_CONSULTA_MOVIALFA_X_USUARIO(vp_cedula)
                    boExistenRegistrosPendientes = False
                End If

            ElseIf vl_boCONSULTA = True Then

                Me.BindingSource_MOVIALFA_1.DataSource = objdatos.fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_MOVIALFA(vp_inConsulta)

                Dim dt As New DataTable
                dt = objdatos.fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_MOVIALFA(vp_inConsulta)

                If dt.Rows.Count > 0 Then

                    If Trim(vp_cedula) = Trim(dt.Rows(0).Item("MOALNUDO")) And Trim(dt.Rows(0).Item("MOALESTA")) = "as" Then
                        Me.dgvMOALPEND.DataSource = BindingSource_MOVIALFA_1
                    Else
                        Me.dgvMOALPEND.DataSource = BindingSource_MOVIALFA_1
                    End If

                End If
            End If

            Me.dgvMOALGEOG.DataSource = BindingSource_MOVIALFA_1
            Me.BindingNavigator_MOVIALFA_1.BindingSource = BindingSource_MOVIALFA_1

            '==================================================
            '*** CONFIGURA OBJETOS DEL FORMULARIO MAESTRO ***
            '==================================================

            Me.strBARRESTA.Items(2).Text = "Registros : " & Me.BindingSource_MOVIALFA_1.Count

            Me.dgvMOALGEOG.Columns("MOALIDRE").HeaderText = "id"
            Me.dgvMOALGEOG.Columns("MOALSECU").HeaderText = "Nro. Tramite"

            Me.dgvMOALGEOG.Columns("MOALDEPA").HeaderText = "Departamento"
            Me.dgvMOALGEOG.Columns("MOALMUNI").HeaderText = "Municipio"
            Me.dgvMOALGEOG.Columns("MOALCORR").HeaderText = "Corregim."
            Me.dgvMOALGEOG.Columns("MOALBARR").HeaderText = "Barrio"
            Me.dgvMOALGEOG.Columns("MOALMANZ").HeaderText = "Manzana- Vereda"
            Me.dgvMOALGEOG.Columns("MOALPRED").HeaderText = "Predio"
            Me.dgvMOALGEOG.Columns("CLSEDESC").HeaderText = "Sector"
            Me.dgvMOALGEOG.Columns("MOALVIGE").HeaderText = "Vigencia"
            Me.dgvMOALGEOG.Columns("MOALUSUA").HeaderText = "Usuario"
            Me.dgvMOALGEOG.Columns("MOALFEIN").HeaderText = "Fecha ingreso"
            Me.dgvMOALGEOG.Columns("ESTADESC").HeaderText = "Estado"

            Me.dgvMOALGEOG.Columns("MOALIDRE").Visible = False
            Me.dgvMOALGEOG.Columns("MOALDEPA").Visible = False
            Me.dgvMOALGEOG.Columns("MOALNUDO").Visible = False
            Me.dgvMOALGEOG.Columns("MOALFEAS").Visible = False
            Me.dgvMOALGEOG.Columns("MOALCAAC").Visible = False
            Me.dgvMOALGEOG.Columns("MOALCLVE").Visible = False
            Me.dgvMOALGEOG.Columns("MOALFFMU").Visible = False
            Me.dgvMOALGEOG.Columns("MOALOBSE").Visible = False
            Me.dgvMOALGEOG.Columns("MOALESTA").Visible = False
            Me.dgvMOALGEOG.Columns("MOALCLSE").Visible = False

            Me.dgvMOALGEOG.Columns("MOALSECU").Width = 60
            Me.dgvMOALGEOG.Columns("MOALUSUA").Width = 100

            If Me.dgvMOALPEND.RowCount > 0 Then

                Me.dgvMOALPEND.Columns("MOALIDRE").HeaderText = "idre"
                Me.dgvMOALPEND.Columns("MOALSECU").HeaderText = "Nro. Tramite"

                Me.dgvMOALPEND.Columns("MOALDEPA").HeaderText = "Departamento"
                Me.dgvMOALPEND.Columns("MOALMUNI").HeaderText = "Municipio"
                Me.dgvMOALPEND.Columns("MOALCORR").HeaderText = "Corregim."
                Me.dgvMOALPEND.Columns("MOALBARR").HeaderText = "Barrio"
                Me.dgvMOALPEND.Columns("MOALMANZ").HeaderText = "Manzana- Vereda"
                Me.dgvMOALPEND.Columns("MOALPRED").HeaderText = "Predio"
                Me.dgvMOALPEND.Columns("CLSEDESC").HeaderText = "Sector"
                Me.dgvMOALPEND.Columns("MOALVIGE").HeaderText = "Vigencia"
                Me.dgvMOALPEND.Columns("MOALUSUA").HeaderText = "Usuario"
                Me.dgvMOALPEND.Columns("MOALFEIN").HeaderText = "Fecha ingreso"
                Me.dgvMOALPEND.Columns("ESTADESC").HeaderText = "Estado"

                Me.dgvMOALPEND.Columns("MOALIDRE").Visible = False
                Me.dgvMOALPEND.Columns("MOALDEPA").Visible = False
                Me.dgvMOALPEND.Columns("MOALNUDO").Visible = False
                Me.dgvMOALPEND.Columns("MOALFEAS").Visible = False
                Me.dgvMOALPEND.Columns("MOALCAAC").Visible = False
                Me.dgvMOALPEND.Columns("MOALCLVE").Visible = False
                Me.dgvMOALPEND.Columns("MOALFFMU").Visible = False
                Me.dgvMOALPEND.Columns("MOALOBSE").Visible = False
                Me.dgvMOALPEND.Columns("MOALESTA").Visible = False
                Me.dgvMOALPEND.Columns("MOALCLSE").Visible = False

                Me.dgvMOALPEND.Columns("MOALSECU").Width = 60
                Me.dgvMOALPEND.Columns("MOALUSUA").Width = 100

            End If

            '==================================================
            '*** ASIGNA LOS PRIVILEGIOS DE LA BARRA DE MENU ***
            '==================================================

            Dim ContarRegistros As Integer = Me.BindingSource_MOVIALFA_1.Count

            Dim boCONTAGRE As Boolean = False
            Dim boCONTMODI As Boolean = False
            Dim boCONTELIM As Boolean = False
            Dim boCONTCONS As Boolean = False
            Dim boCONTRECO As Boolean = False

            pro_Permiso_Barra_De_Menu_Formulario_SubFormulario(ContarRegistros, Trim(Me.BindingNavigator_MOVIALFA_1.Name), boCONTAGRE, boCONTMODI, boCONTELIM, boCONTCONS, boCONTRECO)

            Me.cmdAGREGAR_MOVIALFA.Enabled = boCONTAGRE
            Me.cmdMODIFICAR_MOVIALFA.Enabled = boCONTMODI
            Me.cmdELIMINAR_MOVIALFA.Enabled = boCONTELIM
            Me.cmdCONSULTAR_MOVIALFA.Enabled = boCONTCONS
            Me.cmdRECONSULTAR_MOVIALFA.Enabled = boCONTRECO

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub pro_ListaDeValoresMovimientosAlfanumericos()

        Try
            If Me.dgvMOALGEOG.RowCount > 0 Then

                Me.txtMOALCAAC.Text = Trim(Me.dgvMOALGEOG.SelectedRows.Item(0).Cells("MOALCAAC").Value.ToString)
                Me.txtMOALCLVE.Text = Trim(Me.dgvMOALGEOG.SelectedRows.Item(0).Cells("MOALCLVE").Value.ToString)
                Me.txtMOALFEAS.Text = Trim(Me.dgvMOALGEOG.SelectedRows.Item(0).Cells("MOALFEAS").Value.ToString)
                Me.txtMOALFEFI.Text = Trim(Me.dgvMOALGEOG.SelectedRows.Item(0).Cells("MOALFFMU").Value.ToString)
                Me.txtMOALOBSE.Text = Trim(Me.dgvMOALGEOG.SelectedRows.Item(0).Cells("MOALOBSE").Value.ToString)

                Me.lblMOALUSUA.Text = CType(fun_Buscar_Lista_Valores_USUARIO(Me.dgvMOALGEOG.SelectedRows.Item(0).Cells("MOALNUDO").Value.ToString), String)
                Me.lblMOALMUNI.Text = CType(fun_Buscar_Lista_Valores_MUNICIPIO(Me.dgvMOALGEOG.SelectedRows.Item(0).Cells("MOALDEPA").Value.ToString, Me.dgvMOALGEOG.SelectedRows.Item(0).Cells("MOALMUNI").Value.ToString), String)
                Me.lblMOALVIGE.Text = CType(fun_Buscar_Lista_Valores_VIGENCIA(Me.dgvMOALGEOG.SelectedRows.Item(0).Cells("MOALVIGE").Value.ToString), String)
                Me.lblMOALCLSE.Text = CType(fun_Buscar_Lista_Valores_CLASSECT(Me.dgvMOALGEOG.SelectedRows.Item(0).Cells("MOALCLSE").Value.ToString), String)
                Me.lblMOALCAAC.Text = CType(fun_Buscar_Lista_Valores_CAUSACTO(Me.dgvMOALGEOG.SelectedRows.Item(0).Cells("MOALCAAC").Value.ToString), String)
                Me.lblMOALCLVE.Text = CType(fun_Buscar_Lista_Valores_CLASVERS(Me.dgvMOALGEOG.SelectedRows.Item(0).Cells("MOALCLVE").Value.ToString), String)

                Me.lblMOALCORR.Text = CType(fun_Buscar_Lista_Valores_CORREGIMIENTO(Me.dgvMOALGEOG.SelectedRows.Item(0).Cells("MOALDEPA").Value.ToString, Me.dgvMOALGEOG.SelectedRows.Item(0).Cells("MOALMUNI").Value.ToString, Me.dgvMOALGEOG.SelectedRows.Item(0).Cells("MOALCLSE").Value.ToString, Me.dgvMOALGEOG.SelectedRows.Item(0).Cells("MOALCORR").Value.ToString), String)

                If CInt(Me.dgvMOALGEOG.SelectedRows.Item(0).Cells("MOALCLSE").Value.ToString) = 1 Then
                    Me.lblMOALBAVE.Text = CType(fun_Buscar_Lista_Valores_BARRIO(Me.dgvMOALGEOG.SelectedRows.Item(0).Cells("MOALDEPA").Value.ToString, Me.dgvMOALGEOG.SelectedRows.Item(0).Cells("MOALMUNI").Value.ToString, Me.dgvMOALGEOG.SelectedRows.Item(0).Cells("MOALCLSE").Value.ToString, Me.dgvMOALGEOG.SelectedRows.Item(0).Cells("MOALBARR").Value.ToString, Me.dgvMOALGEOG.SelectedRows.Item(0).Cells("MOALCORR").Value.ToString), String)
                ElseIf CInt(Me.dgvMOALGEOG.SelectedRows.Item(0).Cells("MOALCLSE").Value.ToString) = 2 Then
                    Me.lblMOALBAVE.Text = CType(fun_Buscar_Lista_Valores_VEREDA(Me.dgvMOALGEOG.SelectedRows.Item(0).Cells("MOALDEPA").Value.ToString, Me.dgvMOALGEOG.SelectedRows.Item(0).Cells("MOALMUNI").Value.ToString, Me.dgvMOALGEOG.SelectedRows.Item(0).Cells("MOALCLSE").Value.ToString, Me.dgvMOALGEOG.SelectedRows.Item(0).Cells("MOALMANZ").Value.ToString, Me.dgvMOALGEOG.SelectedRows.Item(0).Cells("MOALCORR").Value.ToString), String)
                ElseIf CInt(Me.dgvMOALGEOG.SelectedRows.Item(0).Cells("MOALCLSE").Value.ToString) = 3 Then
                    Me.lblMOALBAVE.Text = CType(fun_Buscar_Lista_Valores_BARRIO(Me.dgvMOALGEOG.SelectedRows.Item(0).Cells("MOALDEPA").Value.ToString, Me.dgvMOALGEOG.SelectedRows.Item(0).Cells("MOALMUNI").Value.ToString, Me.dgvMOALGEOG.SelectedRows.Item(0).Cells("MOALCLSE").Value.ToString, Me.dgvMOALGEOG.SelectedRows.Item(0).Cells("MOALBARR").Value.ToString, Me.dgvMOALGEOG.SelectedRows.Item(0).Cells("MOALCORR").Value.ToString), String)
                End If

                If Trim(Me.dgvMOALGEOG.SelectedRows.Item(0).Cells("MOALESTA").Value.ToString) = "fi" Then
                    Me.cmdFinalizar.Enabled = False
                Else
                    pro_PermisoControlDeComandos()
                End If

                ' instancia la clase
                Dim obTRABCAMP As New cla_TRABCAMP
                Dim dtTRABCAMP As New DataTable

                dtTRABCAMP = obTRABCAMP.fun_Buscar_SECU_X_CONSULTA_PARAMETRIZADA_TRABCAMP(Me.dgvMOALGEOG.SelectedRows.Item(0).Cells("MOALSECU").Value.ToString)

                If dtTRABCAMP.Rows.Count > 0 Then

                    Me.txtMOALPRNU.Text = Trim(dtTRABCAMP.Rows(0).Item("TRCAPRNU").ToString)
                    Me.txtMOALPRMO.Text = Trim(dtTRABCAMP.Rows(0).Item("TRCAPRMO").ToString)
                    Me.txtMOALPREL.Text = Trim(dtTRABCAMP.Rows(0).Item("TRCAPREL").ToString)

                End If

                Me.txtMOALNUTP.Text = fun_ContarTramitesPendientes()
                Me.txtMOALNUTG.Text = fun_ContarTramitesGenerales()

                vl_boPENDIENTES = False

                pro_ReconsultarTramitesOVC()
                pro_ListaDeValoresTramitesOVC()

                pro_ReconsultarMesaDeAyuda()
                pro_ListaDeValoresMesaDeAyuda()

                pro_ReconsultarPrediosNuevos()
                pro_ListaDeValoresPrediosNuevos()

                pro_ReconsultarDigitalizacionGrafica()
                pro_ListaDeValoresDigitalizacionGrafica()

                pro_ListadoArchivosDocumentosMovimientosAlfanumericos(False)
                pro_ListadoArchivosDocumentosMovimientosGeograficos(False)
                pro_ListadoArchivosDocumentosTrabajoDeCampo(False)

            Else
                pro_LimpiarCamposMovimientoGeografico()
                pro_LimpiarTramitesOVC()
                pro_LimpiarMesaDeAyuda()
                pro_LimpiarPrediosNuevos()
                pro_LimpiarDigitalizacion()

                Me.BindingNavigator_MOALTRAM_1.Enabled = False
                Me.BindingNavigator_MOALMEAY_1.Enabled = False
                Me.BindingNavigator_MOALPRNU_1.Enabled = False
                Me.BindingNavigator_MOALDIGI_1.Enabled = False

            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub pro_ListaDeValoresMovimientosAlfanumericosPendientes()

        Try
            If Me.dgvMOALPEND.RowCount > 0 Then

                Me.txtMOALCAAC.Text = Trim(Me.dgvMOALPEND.SelectedRows.Item(0).Cells("MOALCAAC").Value.ToString)
                Me.txtMOALCLVE.Text = Trim(Me.dgvMOALPEND.SelectedRows.Item(0).Cells("MOALCLVE").Value.ToString)
                Me.txtMOALFEAS.Text = Trim(Me.dgvMOALPEND.SelectedRows.Item(0).Cells("MOALFEAS").Value.ToString)
                Me.txtMOALFEFI.Text = Trim(Me.dgvMOALPEND.SelectedRows.Item(0).Cells("MOALFFMU").Value.ToString)
                Me.txtMOALOBSE.Text = Trim(Me.dgvMOALPEND.SelectedRows.Item(0).Cells("MOALOBSE").Value.ToString)

                Me.lblMOALUSUA.Text = CType(fun_Buscar_Lista_Valores_USUARIO(Me.dgvMOALPEND.SelectedRows.Item(0).Cells("MOALNUDO").Value.ToString), String)
                Me.lblMOALMUNI.Text = CType(fun_Buscar_Lista_Valores_MUNICIPIO(Me.dgvMOALPEND.SelectedRows.Item(0).Cells("MOALDEPA").Value.ToString, Me.dgvMOALPEND.SelectedRows.Item(0).Cells("MOALMUNI").Value.ToString), String)
                Me.lblMOALVIGE.Text = CType(fun_Buscar_Lista_Valores_VIGENCIA(Me.dgvMOALPEND.SelectedRows.Item(0).Cells("MOALVIGE").Value.ToString), String)
                Me.lblMOALCLSE.Text = CType(fun_Buscar_Lista_Valores_CLASSECT(Me.dgvMOALPEND.SelectedRows.Item(0).Cells("MOALCLSE").Value.ToString), String)
                Me.lblMOALCAAC.Text = CType(fun_Buscar_Lista_Valores_CAUSACTO(Me.dgvMOALPEND.SelectedRows.Item(0).Cells("MOALCAAC").Value.ToString), String)
                Me.lblMOALCLVE.Text = CType(fun_Buscar_Lista_Valores_CLASVERS(Me.dgvMOALPEND.SelectedRows.Item(0).Cells("MOALCLVE").Value.ToString), String)

                Me.lblMOALCORR.Text = CType(fun_Buscar_Lista_Valores_CORREGIMIENTO(Me.dgvMOALPEND.SelectedRows.Item(0).Cells("MOALDEPA").Value.ToString, Me.dgvMOALPEND.SelectedRows.Item(0).Cells("MOALMUNI").Value.ToString, Me.dgvMOALPEND.SelectedRows.Item(0).Cells("MOALCLSE").Value.ToString, Me.dgvMOALPEND.SelectedRows.Item(0).Cells("MOALCORR").Value.ToString), String)

                If CInt(Me.dgvMOALGEOG.SelectedRows.Item(0).Cells("MOALCLSE").Value.ToString) = 1 Then
                    Me.lblMOALBAVE.Text = CType(fun_Buscar_Lista_Valores_BARRIO(Me.dgvMOALPEND.SelectedRows.Item(0).Cells("MOALDEPA").Value.ToString, Me.dgvMOALPEND.SelectedRows.Item(0).Cells("MOALMUNI").Value.ToString, Me.dgvMOALPEND.SelectedRows.Item(0).Cells("MOALCLSE").Value.ToString, Me.dgvMOALPEND.SelectedRows.Item(0).Cells("MOALBARR").Value.ToString, Me.dgvMOALPEND.SelectedRows.Item(0).Cells("MOALCORR").Value.ToString), String)
                ElseIf CInt(Me.dgvMOALGEOG.SelectedRows.Item(0).Cells("MOALCLSE").Value.ToString) = 2 Then
                    Me.lblMOALBAVE.Text = CType(fun_Buscar_Lista_Valores_VEREDA(Me.dgvMOALPEND.SelectedRows.Item(0).Cells("MOALDEPA").Value.ToString, Me.dgvMOALPEND.SelectedRows.Item(0).Cells("MOALMUNI").Value.ToString, Me.dgvMOALPEND.SelectedRows.Item(0).Cells("MOALCLSE").Value.ToString, Me.dgvMOALPEND.SelectedRows.Item(0).Cells("MOALMANZ").Value.ToString, Me.dgvMOALPEND.SelectedRows.Item(0).Cells("MOALCORR").Value.ToString), String)
                ElseIf CInt(Me.dgvMOALGEOG.SelectedRows.Item(0).Cells("MOALCLSE").Value.ToString) = 3 Then
                    Me.lblMOALBAVE.Text = CType(fun_Buscar_Lista_Valores_BARRIO(Me.dgvMOALPEND.SelectedRows.Item(0).Cells("MOALDEPA").Value.ToString, Me.dgvMOALPEND.SelectedRows.Item(0).Cells("MOALMUNI").Value.ToString, Me.dgvMOALPEND.SelectedRows.Item(0).Cells("MOALCLSE").Value.ToString, Me.dgvMOALPEND.SelectedRows.Item(0).Cells("MOALBARR").Value.ToString, Me.dgvMOALPEND.SelectedRows.Item(0).Cells("MOALCORR").Value.ToString), String)
                End If

                If Trim(Me.dgvMOALGEOG.SelectedRows.Item(0).Cells("MOALESTA").Value.ToString) = "fi" Then
                    Me.cmdFinalizar.Enabled = False
                Else
                    pro_PermisoControlDeComandos()
                End If

                ' instancia la clase
                Dim obTRABCAMP As New cla_TRABCAMP
                Dim dtTRABCAMP As New DataTable

                dtTRABCAMP = obTRABCAMP.fun_Buscar_SECU_X_CONSULTA_PARAMETRIZADA_TRABCAMP(Me.dgvMOALPEND.SelectedRows.Item(0).Cells("MOALSECU").Value.ToString)

                If dtTRABCAMP.Rows.Count > 0 Then

                    Me.txtMOALPRNU.Text = Trim(dtTRABCAMP.Rows(0).Item("TRCAPRNU").ToString)
                    Me.txtMOALPRMO.Text = Trim(dtTRABCAMP.Rows(0).Item("TRCAPRMO").ToString)
                    Me.txtMOALPREL.Text = Trim(dtTRABCAMP.Rows(0).Item("TRCAPREL").ToString)

                End If

                Me.txtMOALNUTP.Text = fun_ContarTramitesPendientes()
                Me.txtMOALNUTG.Text = fun_ContarTramitesGenerales()

                vl_boPENDIENTES = True

                pro_ReconsultarTramitesOVC()
                pro_ListaDeValoresTramitesOVC()

                pro_ReconsultarMesaDeAyuda()
                pro_ListaDeValoresMesaDeAyuda()

                pro_ReconsultarPrediosNuevos()
                pro_ListaDeValoresPrediosNuevos()

                pro_ReconsultarDigitalizacionGrafica()
                pro_ListaDeValoresDigitalizacionGrafica()

                pro_ListadoArchivosDocumentosMovimientosAlfanumericos(True)
                pro_ListadoArchivosDocumentosMovimientosGeograficos(True)

            Else
                pro_LimpiarCamposMovimientoGeografico()
                pro_LimpiarTramitesOVC()
                pro_LimpiarMesaDeAyuda()
                pro_LimpiarPrediosNuevos()
                pro_LimpiarDigitalizacion()

                Me.BindingNavigator_MOALTRAM_1.Enabled = False
                Me.BindingNavigator_MOALMEAY_1.Enabled = False
                Me.BindingNavigator_MOALPRNU_1.Enabled = False
                Me.BindingNavigator_MOALDIGI_1.Enabled = False

            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub pro_LimpiarCamposMovimientoGeografico()

        Me.lblMOALUSUA.Text = ""
        Me.lblMOALMUNI.Text = ""
        Me.lblMOALVIGE.Text = ""
        Me.lblMOALCLSE.Text = ""
        Me.lblMOALCAAC.Text = ""
        Me.lblMOALCLVE.Text = ""
        Me.txtMOALCAAC.Text = ""
        Me.txtMOALCLVE.Text = ""
        Me.txtMOALFEAS.Text = ""
        Me.txtMOALFEFI.Text = ""
        Me.txtMOALOBSE.Text = ""

        Me.txtMOALPRNU.Text = ""
        Me.txtMOALPRMO.Text = ""
        Me.txtMOALPREL.Text = ""

        Me.lstLISTADO_DOCUMENTOS_MOVIALFA.Items.Clear()
        Me.lstLISTADO_DOCUMENTOS_MOVIGEOG.Items.Clear()
        Me.lstLISTADO_DOCUMENTOS_TRABCAMP.Items.Clear()

        Me.strBARRESTA.Items(2).Text = "Registros : 0"

    End Sub

    Private Sub pro_EjecutarBotonReasignar()

        Try
            If Me.dgvMOALPEND.RowCount > 0 Then

                Me.TabMAESTRO1.SelectTab(TabPendientes)

                If MessageBox.Show("¿ Desea reasignar el tramite Nro. " & Me.dgvMOALPEND.SelectedRows.Item(0).Cells("MOALSECU").Value.ToString() & " ? ", "Mensaje...", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then

                    Dim frm_Reasignar As New frm_reasignar_MOVIALFA(Integer.Parse(Me.dgvMOALPEND.SelectedRows.Item(0).Cells("MOALIDRE").Value.ToString()), _
                                                                    Integer.Parse(Me.dgvMOALPEND.SelectedRows.Item(0).Cells("MOALSECU").Value.ToString()))

                    frm_Reasignar.ShowDialog()

                    vl_boCONSULTA = True

                    pro_ReconsultarMovimientosAlfanumericos()
                    pro_ListaDeValoresMovimientosAlfanumericos()

                    Me.TabMAESTRO1.SelectTab(TabGenerales)
                    Me.TabMAESTRO3.SelectTab(TabObservaciones)

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
            Me.TabMAESTRO3.SelectTab(TabObservaciones)

            If MessageBox.Show("¿ Desea agregar una observación en Movimientos Pendientes ? ", "Mensaje...", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then

                If Me.dgvMOALPEND.RowCount > 0 Then

                    Me.TabMAESTRO1.SelectTab(TabPendientes)

                    If MessageBox.Show("¿ Desea ingresar una observación al tramite Nro. " & Me.dgvMOALPEND.SelectedRows.Item(0).Cells("MOALSECU").Value.ToString() & " ? ", "Mensaje...", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then

                        Dim stObservacionNueva As String = InputBox("Ingrese la observación.", "Mensaje")

                        If Trim(stObservacionNueva) = "" Then
                            MessageBox.Show("Se requiere una observación.", "Mensaje...", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                            mod_MENSAJE.No_Se_Modifico_El_Registro_En_La_Base_De_Datos()
                        Else

                            Dim stRECLOBSE_ACTUAL As String = ""
                            Dim stRECLOBSE_NUEVA As String = Trim(stObservacionNueva.ToString.ToUpper)

                            Dim obMOALGEOG As New cla_MOVIALFA
                            Dim dtAJUSGEOG As New DataTable

                            dtAJUSGEOG = obMOALGEOG.fun_Buscar_ID_MOVIALFA(Me.dgvMOALPEND.SelectedRows.Item(0).Cells("MOALIDRE").Value.ToString())

                            If dtAJUSGEOG.Rows.Count > 0 Then
                                stRECLOBSE_ACTUAL = Trim(dtAJUSGEOG.Rows(0).Item("MOALOBSE").ToString)
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
                            Dim inMOALIDRE As Integer = Integer.Parse(Me.dgvMOALPEND.SelectedRows.Item(0).Cells("MOALIDRE").Value.ToString())

                            ' parametros de la consulta
                            Dim ParametrosConsulta As String = ""

                            ' Concatena la condicion de la consulta
                            ParametrosConsulta += "update MOVIALFA "
                            ParametrosConsulta += "set MOALOBSE = '" & stRECLOBSE_ACTUAL & "' "
                            ParametrosConsulta += "where MOALIDRE = '" & inMOALIDRE & "' "

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

                            vp_inConsulta = inMOALIDRE

                            vl_boCONSULTA = True

                            pro_ReconsultarMovimientosAlfanumericos()
                            pro_ListaDeValoresMovimientosAlfanumericosPendientes()

                            Me.TabMAESTRO3.SelectTab(TabObservaciones)

                        End If

                    End If
                Else
                    mod_MENSAJE.No_Existe_Un_Registro_Seleccionado()
                End If


            ElseIf MessageBox.Show("¿ Desea agregar una observación en Movimientos Generales ? ", "Mensaje...", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then

                If Me.dgvMOALGEOG.RowCount > 0 Then

                    Me.TabMAESTRO1.SelectTab(TabGenerales)

                    If MessageBox.Show("¿ Desea ingresar una observación al tramite Nro. " & Me.dgvMOALGEOG.SelectedRows.Item(0).Cells("MOALSECU").Value.ToString() & " ? ", "Mensaje...", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then

                        Dim stObservacionNueva As String = InputBox("Ingrese la observación.", "Mensaje")

                        If Trim(stObservacionNueva) = "" Then
                            MessageBox.Show("Se requiere una observación.", "Mensaje...", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                            mod_MENSAJE.No_Se_Modifico_El_Registro_En_La_Base_De_Datos()
                        Else

                            Dim stRECLOBSE_ACTUAL As String = ""
                            Dim stRECLOBSE_NUEVA As String = Trim(stObservacionNueva.ToString.ToUpper)

                            Dim obMOALGEOG As New cla_MOVIALFA
                            Dim dtAJUSGEOG As New DataTable

                            dtAJUSGEOG = obMOALGEOG.fun_Buscar_ID_MOVIALFA(Me.dgvMOALGEOG.SelectedRows.Item(0).Cells("MOALIDRE").Value.ToString())

                            If dtAJUSGEOG.Rows.Count > 0 Then
                                stRECLOBSE_ACTUAL = Trim(dtAJUSGEOG.Rows(0).Item("MOALOBSE").ToString)
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
                            Dim inMOALIDRE As Integer = Integer.Parse(Me.dgvMOALGEOG.SelectedRows.Item(0).Cells("MOALIDRE").Value.ToString())

                            ' parametros de la consulta
                            Dim ParametrosConsulta As String = ""

                            ' Concatena la condicion de la consulta
                            ParametrosConsulta += "update MOVIALFA "
                            ParametrosConsulta += "set MOALOBSE = '" & stRECLOBSE_ACTUAL & "' "
                            ParametrosConsulta += "where MOALIDRE = '" & inMOALIDRE & "' "

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

                            vp_inConsulta = inMOALIDRE

                            vl_boCONSULTA = True

                            pro_ReconsultarMovimientosAlfanumericos()
                            pro_ListaDeValoresMovimientosAlfanumericos()

                            Me.TabMAESTRO3.SelectTab(TabObservaciones)

                        End If

                    End If
                Else
                    mod_MENSAJE.No_Existe_Un_Registro_Seleccionado()
                End If

            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub pro_EjecutarBotonFinalizar()

        Try
            If Me.dgvMOALPEND.RowCount > 0 Then

                Me.TabMAESTRO1.SelectTab(TabPendientes)

                If MessageBox.Show("¿ Desea finalizar el tramite Nro. " & Me.dgvMOALPEND.SelectedRows.Item(0).Cells("MOALSECU").Value.ToString() & " ? ", "Mensaje...", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then

                    Dim stRECLOBSE_ACTUAL As String = ""
                    Dim stRECLOBSE_NUEVA As String = Trim(Me.txtMOALOBSE.Text.ToString.ToUpper)

                    Dim obMOALGEOG As New cla_MOVIALFA
                    Dim dtAJUSGEOG As New DataTable

                    dtAJUSGEOG = obMOALGEOG.fun_Buscar_ID_MOVIALFA(Me.dgvMOALPEND.SelectedRows.Item(0).Cells("MOALIDRE").Value.ToString())

                    If dtAJUSGEOG.Rows.Count > 0 Then
                        stRECLOBSE_ACTUAL = Trim(dtAJUSGEOG.Rows(0).Item("MOALOBSE").ToString)
                    End If

                    Dim stNotaFinalizacion As String = " Nota de registro: " & " El usuario: " & vp_usuario & " finalizo el tramite. " & fun_fecha()

                    If Trim(stRECLOBSE_ACTUAL) <> "" And Trim(stRECLOBSE_NUEVA) <> "" Then
                        stRECLOBSE_ACTUAL += vbCrLf & " Nota ingresada por " & vp_usuario & " " & fun_fecha() & " : " & stRECLOBSE_NUEVA & ". " & vbCrLf & stNotaFinalizacion

                    ElseIf Trim(stRECLOBSE_ACTUAL) = "" And Trim(stRECLOBSE_NUEVA) <> "" Then
                        stRECLOBSE_ACTUAL = " Nota ingresada por " & vp_usuario & " " & fun_fecha() & " : " & stRECLOBSE_NUEVA & ". " & vbCrLf & stNotaFinalizacion

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
                    Dim inMOALIDRE As Integer = Integer.Parse(Me.dgvMOALPEND.SelectedRows.Item(0).Cells("MOALIDRE").Value.ToString())
                    Dim stMOALESTA As String = "fi"
                    Dim stMOALFFMU As String = fun_fecha()

                    'stMOALFFMU = stMOALFFMU.ToString.Replace("/", "-")

                    ' parametros de la consulta
                    Dim ParametrosConsulta As String = ""

                    ' Concatena la condicion de la consulta
                    ParametrosConsulta += "update MOVIALFA "
                    ParametrosConsulta += "set MOALESTA = '" & stMOALESTA & "', "
                    ParametrosConsulta += "MOALFFMU = '" & stMOALFFMU & "', "
                    ParametrosConsulta += "MOALOBSE = '" & stRECLOBSE_ACTUAL & "'  "
                    ParametrosConsulta += "where MOALIDRE = '" & inMOALIDRE & "'  "

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

                    vl_boCONSULTA = True

                    vp_inConsulta = Me.dgvMOALPEND.SelectedRows.Item(0).Cells("MOALIDRE").Value.ToString()

                    pro_ReconsultarMovimientosAlfanumericos()
                    pro_ListaDeValoresMovimientosAlfanumericos()

                    Me.TabMAESTRO1.SelectTab(TabGenerales)

                End If

            Else
                mod_MENSAJE.No_Existe_Un_Registro_Seleccionado()
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

    Private Sub pro_ListadoArchivosDocumentosMovimientosAlfanumericos(ByVal boPendientes As Boolean)

        Try
            Me.lstLISTADO_DOCUMENTOS_MOVIALFA.Items.Clear()

            ' declara la variable
            Dim stRuta As String = ""
            Dim stNewPath As String = ""
            Dim ContentItem As String

            ' instancia la clase
            Dim objRutas As New cla_RUTAS
            Dim tblRutas As New DataTable

            tblRutas = objRutas.fun_Buscar_CODIGO_MANT_RUTAS(16)

            If tblRutas.Rows.Count > 0 AndAlso fun_VerificarCarpetaExistenteDocumentosMovimientosAlfanumericos(boPendientes) = True Then

                ' consulta del grib movimientos generales
                If boPendientes = False Then

                    stNewPath = Trim(tblRutas.Rows(0).Item("RUTARUTA")) & "\" & Trim(Me.dgvMOALGEOG.SelectedRows.Item(0).Cells("MOALMUNI").Value.ToString) & "-" & _
                                                                                Trim(Me.dgvMOALGEOG.SelectedRows.Item(0).Cells("MOALCLSE").Value.ToString) & "-" & _
                                                                                Trim(Me.dgvMOALGEOG.SelectedRows.Item(0).Cells("MOALCORR").Value.ToString) & "-" & _
                                                                                Trim(Me.dgvMOALGEOG.SelectedRows.Item(0).Cells("MOALBARR").Value.ToString) & "-" & _
                                                                                Trim(Me.dgvMOALGEOG.SelectedRows.Item(0).Cells("MOALMANZ").Value.ToString) & "-" & _
                                                                                Trim(Me.dgvMOALGEOG.SelectedRows.Item(0).Cells("MOALPRED").Value.ToString) & "-" & _
                                                                                Trim(Me.dgvMOALGEOG.SelectedRows.Item(0).Cells("MOALVIGE").Value.ToString)
                    ' consulta del grib movimientos pendientes
                ElseIf boPendientes = True Then

                    stNewPath = Trim(tblRutas.Rows(0).Item("RUTARUTA")) & "\" & Trim(Me.dgvMOALPEND.SelectedRows.Item(0).Cells("MOALMUNI").Value.ToString) & "-" & _
                                                                                Trim(Me.dgvMOALPEND.SelectedRows.Item(0).Cells("MOALCLSE").Value.ToString) & "-" & _
                                                                                Trim(Me.dgvMOALPEND.SelectedRows.Item(0).Cells("MOALCORR").Value.ToString) & "-" & _
                                                                                Trim(Me.dgvMOALPEND.SelectedRows.Item(0).Cells("MOALBARR").Value.ToString) & "-" & _
                                                                                Trim(Me.dgvMOALPEND.SelectedRows.Item(0).Cells("MOALMANZ").Value.ToString) & "-" & _
                                                                                Trim(Me.dgvMOALPEND.SelectedRows.Item(0).Cells("MOALPRED").Value.ToString) & "-" & _
                                                                                Trim(Me.dgvMOALPEND.SelectedRows.Item(0).Cells("MOALVIGE").Value.ToString)

                End If

                vl_stRutaDocumentosMovimientosAlfanumericos = stNewPath

                ChDir(stNewPath)

                Me.lstLISTADO_DOCUMENTOS_MOVIALFA.Items.Clear()

                ContentItem = Dir("*.*")

                If ContentItem <> "" Then
                    Me.lstLISTADO_DOCUMENTOS_MOVIALFA.Focus()
                End If

                Do Until ContentItem = ""
                    ' agrega a la lista
                    Me.lstLISTADO_DOCUMENTOS_MOVIALFA.Items.Add(ContentItem)

                    'desplaza el registro
                    ContentItem = Dir()
                Loop

            Else
                Me.lstLISTADO_DOCUMENTOS_MOVIALFA.Items.Clear()
            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub pro_ListadoArchivosDocumentosMovimientosGeograficos(ByVal boPendientes As Boolean)

        Try
            Me.lstLISTADO_DOCUMENTOS_MOVIGEOG.Items.Clear()

            ' declara la variable
            Dim stRuta As String = ""
            Dim stNewPath As String = ""
            Dim ContentItem As String

            ' instancia la clase
            Dim objRutas As New cla_RUTAS
            Dim tblRutas As New DataTable

            tblRutas = objRutas.fun_Buscar_CODIGO_MANT_RUTAS(13)

            If tblRutas.Rows.Count > 0 AndAlso fun_VerificarCarpetaExistenteDocumentosMovimientosAlfanumericos(boPendientes) = True Then

                ' consulta del grib movimientos generales
                If boPendientes = False Then

                    stNewPath = Trim(tblRutas.Rows(0).Item("RUTARUTA")) & "\" & Trim(Me.dgvMOALGEOG.SelectedRows.Item(0).Cells("MOALMUNI").Value.ToString) & "-" & _
                                                                                Trim(Me.dgvMOALGEOG.SelectedRows.Item(0).Cells("MOALCLSE").Value.ToString) & "-" & _
                                                                                Trim(Me.dgvMOALGEOG.SelectedRows.Item(0).Cells("MOALCORR").Value.ToString) & "-" & _
                                                                                Trim(Me.dgvMOALGEOG.SelectedRows.Item(0).Cells("MOALBARR").Value.ToString) & "-" & _
                                                                                Trim(Me.dgvMOALGEOG.SelectedRows.Item(0).Cells("MOALMANZ").Value.ToString) & "-" & _
                                                                                Trim(Me.dgvMOALGEOG.SelectedRows.Item(0).Cells("MOALPRED").Value.ToString) & "-" & _
                                                                                Trim(Me.dgvMOALGEOG.SelectedRows.Item(0).Cells("MOALVIGE").Value.ToString)
                    ' consulta del grib movimientos pendientes
                ElseIf boPendientes = True Then

                    stNewPath = Trim(tblRutas.Rows(0).Item("RUTARUTA")) & "\" & Trim(Me.dgvMOALPEND.SelectedRows.Item(0).Cells("MOALMUNI").Value.ToString) & "-" & _
                                                                                Trim(Me.dgvMOALPEND.SelectedRows.Item(0).Cells("MOALCLSE").Value.ToString) & "-" & _
                                                                                Trim(Me.dgvMOALPEND.SelectedRows.Item(0).Cells("MOALCORR").Value.ToString) & "-" & _
                                                                                Trim(Me.dgvMOALPEND.SelectedRows.Item(0).Cells("MOALBARR").Value.ToString) & "-" & _
                                                                                Trim(Me.dgvMOALPEND.SelectedRows.Item(0).Cells("MOALMANZ").Value.ToString) & "-" & _
                                                                                Trim(Me.dgvMOALPEND.SelectedRows.Item(0).Cells("MOALPRED").Value.ToString) & "-" & _
                                                                                Trim(Me.dgvMOALPEND.SelectedRows.Item(0).Cells("MOALVIGE").Value.ToString)

                End If

                vl_stRutaDocumentosMovimientosGeograficos = stNewPath

                ChDir(stNewPath)

                Me.lstLISTADO_DOCUMENTOS_MOVIGEOG.Items.Clear()

                ContentItem = Dir("*.*")

                If ContentItem <> "" Then
                    Me.lstLISTADO_DOCUMENTOS_MOVIGEOG.Focus()
                End If

                Do Until ContentItem = ""
                    ' agrega a la lista
                    Me.lstLISTADO_DOCUMENTOS_MOVIGEOG.Items.Add(ContentItem)

                    'desplaza el registro
                    ContentItem = Dir()
                Loop

            Else
                Me.lstLISTADO_DOCUMENTOS_MOVIGEOG.Items.Clear()
            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub pro_ListadoArchivosDocumentosTrabajoDeCampo(ByVal boPendientes As Boolean)

        Try
            Me.lstLISTADO_DOCUMENTOS_TRABCAMP.Items.Clear()

            ' declara la variable
            Dim stRuta As String = ""
            Dim stNewPath As String = ""
            Dim ContentItem As String

            ' instancia la clase
            Dim objRutas As New cla_RUTAS
            Dim tblRutas As New DataTable

            tblRutas = objRutas.fun_Buscar_CODIGO_MANT_RUTAS(6)

            If tblRutas.Rows.Count > 0 AndAlso fun_VerificarCarpetaExistenteDocumentosTrabajoDeCampo(boPendientes) = True Then

                ' consulta del grib movimientos generales
                If boPendientes = False Then

                    stNewPath = Trim(tblRutas.Rows(0).Item("RUTARUTA")) & "\" & Trim(Me.dgvMOALGEOG.SelectedRows.Item(0).Cells("MOALMUNI").Value.ToString) & "-" & _
                                                                                Trim(Me.dgvMOALGEOG.SelectedRows.Item(0).Cells("MOALCLSE").Value.ToString) & "-" & _
                                                                                Trim(Me.dgvMOALGEOG.SelectedRows.Item(0).Cells("MOALCORR").Value.ToString) & "-" & _
                                                                                Trim(Me.dgvMOALGEOG.SelectedRows.Item(0).Cells("MOALBARR").Value.ToString) & "-" & _
                                                                                Trim(Me.dgvMOALGEOG.SelectedRows.Item(0).Cells("MOALMANZ").Value.ToString) & "-" & _
                                                                                Trim(Me.dgvMOALGEOG.SelectedRows.Item(0).Cells("MOALPRED").Value.ToString) & "-" & _
                                                                                Trim(Me.dgvMOALGEOG.SelectedRows.Item(0).Cells("MOALVIGE").Value.ToString)
                    ' consulta del grib movimientos pendientes
                ElseIf boPendientes = True Then

                    stNewPath = Trim(tblRutas.Rows(0).Item("RUTARUTA")) & "\" & Trim(Me.dgvMOALPEND.SelectedRows.Item(0).Cells("MOALMUNI").Value.ToString) & "-" & _
                                                                                Trim(Me.dgvMOALPEND.SelectedRows.Item(0).Cells("MOALCLSE").Value.ToString) & "-" & _
                                                                                Trim(Me.dgvMOALPEND.SelectedRows.Item(0).Cells("MOALCORR").Value.ToString) & "-" & _
                                                                                Trim(Me.dgvMOALPEND.SelectedRows.Item(0).Cells("MOALBARR").Value.ToString) & "-" & _
                                                                                Trim(Me.dgvMOALPEND.SelectedRows.Item(0).Cells("MOALMANZ").Value.ToString) & "-" & _
                                                                                Trim(Me.dgvMOALPEND.SelectedRows.Item(0).Cells("MOALPRED").Value.ToString) & "-" & _
                                                                                Trim(Me.dgvMOALPEND.SelectedRows.Item(0).Cells("MOALVIGE").Value.ToString)

                End If

                vl_stRutaDocumentosTrabajoDeCampo = stNewPath

                ChDir(stNewPath)

                Me.lstLISTADO_DOCUMENTOS_TRABCAMP.Items.Clear()

                ContentItem = Dir("*.*")

                If ContentItem <> "" Then
                    Me.lstLISTADO_DOCUMENTOS_TRABCAMP.Focus()
                End If

                Do Until ContentItem = ""
                    ' agrega a la lista
                    Me.lstLISTADO_DOCUMENTOS_TRABCAMP.Items.Add(ContentItem)

                    'desplaza el registro
                    ContentItem = Dir()
                Loop

            Else
                Me.lstLISTADO_DOCUMENTOS_TRABCAMP.Items.Clear()
            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub

#End Region

#Region "PROCEDIMIENTOS TRAMITE OVC"

    Private Sub pro_ReconsultarTramitesOVC()

        Try
            Dim objdatos As New cla_MOGETRAM

            If vl_boPENDIENTES = False Then
                If vl_boCONSULTA = False Then
                    Me.BindingSource_MOALTRAM_1.DataSource = objdatos.fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_MOGETRAM(Me.dgvMOALGEOG.SelectedRows.Item(0).Cells("MOALSECU").Value.ToString)
                Else
                    Me.BindingSource_MOALTRAM_1.DataSource = objdatos.fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_MOGETRAM(Me.dgvMOALGEOG.SelectedRows.Item(0).Cells("MOALSECU").Value.ToString)
                End If
            Else
                If vl_boCONSULTA = False Then
                    Me.BindingSource_MOALTRAM_1.DataSource = objdatos.fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_MOGETRAM(Me.dgvMOALPEND.SelectedRows.Item(0).Cells("MOALSECU").Value.ToString)
                Else
                    Me.BindingSource_MOALTRAM_1.DataSource = objdatos.fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_MOGETRAM(Me.dgvMOALPEND.SelectedRows.Item(0).Cells("MOALSECU").Value.ToString)
                End If
            End If

            Me.dgvMOALTRAM.DataSource = Me.BindingSource_MOALTRAM_1
            Me.BindingNavigator_MOALTRAM_1.BindingSource = Me.BindingSource_MOALTRAM_1

            '==================================================
            '*** CONFIGURA OBJETOS DEL FORMULARIO MAESTRO ***
            '==================================================

            Me.dgvMOALTRAM.Columns("MGTRIDRE").HeaderText = "idre"
            Me.dgvMOALTRAM.Columns("MGTRSECU").HeaderText = "Secuencia"

            Me.dgvMOALTRAM.Columns("MGTRNUTR").HeaderText = "Nro. Tramite OVC"
            Me.dgvMOALTRAM.Columns("MGTRFETR").HeaderText = "Fecha Tramite OVC"
            Me.dgvMOALTRAM.Columns("MGTRNURE").HeaderText = "Nro. Resolución"
            Me.dgvMOALTRAM.Columns("MGTRFERE").HeaderText = "Fecha Resolución"
            Me.dgvMOALTRAM.Columns("MGTRFEFI").HeaderText = "Fecha Finalización"
            Me.dgvMOALTRAM.Columns("MGTROBSE").HeaderText = "Observación"

            Me.dgvMOALTRAM.Columns("MGTRIDRE").Visible = False
            Me.dgvMOALTRAM.Columns("MGTRSECU").Visible = False

            '==================================================
            '*** ASIGNA LOS PRIVILEGIOS DE LA BARRA DE MENU ***
            '==================================================

            Dim ContarRegistros As Integer = Me.BindingSource_MOALTRAM_1.Count

            Dim boCONTAGRE As Boolean = False
            Dim boCONTMODI As Boolean = False
            Dim boCONTELIM As Boolean = False
            Dim boCONTCONS As Boolean = False
            Dim boCONTRECO As Boolean = False

            pro_Permiso_Barra_De_Menu_Formulario_SubFormulario(ContarRegistros, Trim(Me.BindingNavigator_MOALTRAM_1.Name), boCONTAGRE, boCONTMODI, boCONTELIM, boCONTCONS, boCONTRECO)

            Me.cmdAGREGAR_MOALTRAM.Enabled = boCONTAGRE
            Me.cmdMODIFICAR_MOALTRAM.Enabled = boCONTMODI
            Me.cmdELIMINAR_MOALTRAM.Enabled = boCONTELIM
            Me.cmdCONSULTAR_MOALTRAM.Enabled = boCONTCONS
            Me.cmdRECONSULTAR_MOALTRAM.Enabled = boCONTRECO

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try
    End Sub
    Private Sub pro_ListaDeValoresTramitesOVC()

        Try
            If Me.dgvMOALTRAM.RowCount = 0 Then

                'pro_LimpiarTramitesOVC()

            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub pro_LimpiarTramitesOVC()

        'Me.dgvMOALTRAM.DataSource = New DataTable

    End Sub

#End Region

#Region "PROCEDIMIENTOS MESA DE AYUDA"

    Private Sub pro_ReconsultarMesaDeAyuda()

        Try
            Dim objdatos As New cla_MOGEMEAY

            If vl_boPENDIENTES = False Then
                If vl_boCONSULTA = False Then
                    Me.BindingSource_MOALMEAY_1.DataSource = objdatos.fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_MOGEMEAY(Me.dgvMOALGEOG.SelectedRows.Item(0).Cells("MOALSECU").Value.ToString)
                Else
                    Me.BindingSource_MOALMEAY_1.DataSource = objdatos.fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_MOGEMEAY(Me.dgvMOALGEOG.SelectedRows.Item(0).Cells("MOALSECU").Value.ToString)
                End If
            Else
                If vl_boCONSULTA = False Then
                    Me.BindingSource_MOALMEAY_1.DataSource = objdatos.fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_MOGEMEAY(Me.dgvMOALPEND.SelectedRows.Item(0).Cells("MOALSECU").Value.ToString)
                Else
                    Me.BindingSource_MOALMEAY_1.DataSource = objdatos.fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_MOGEMEAY(Me.dgvMOALPEND.SelectedRows.Item(0).Cells("MOALSECU").Value.ToString)
                End If
            End If

            Me.dgvMOALMEAY.DataSource = Me.BindingSource_MOALMEAY_1
            Me.BindingNavigator_MOALMEAY_1.BindingSource = Me.BindingSource_MOALMEAY_1

            '==================================================
            '*** CONFIGURA OBJETOS DEL FORMULARIO MAESTRO ***
            '==================================================

            Me.dgvMOALMEAY.Columns("MGMAIDRE").HeaderText = "idre"
            Me.dgvMOALMEAY.Columns("MGMASECU").HeaderText = "Secuencia"

            Me.dgvMOALMEAY.Columns("MGMANURA").HeaderText = "Nro. Radicado"
            Me.dgvMOALMEAY.Columns("MGMAFERA").HeaderText = "Fecha Radicado"
            Me.dgvMOALMEAY.Columns("MGMANUCA").HeaderText = "Nro. Caso"
            Me.dgvMOALMEAY.Columns("MGMAVERS").HeaderText = "Versión"
            Me.dgvMOALMEAY.Columns("MGMAPEAS").HeaderText = "Personal Asignado"
            Me.dgvMOALMEAY.Columns("MGMAOBSE").HeaderText = "Observación"

            Me.dgvMOALMEAY.Columns("MGMAIDRE").Visible = False
            Me.dgvMOALMEAY.Columns("MGMASECU").Visible = False

            '==================================================
            '*** ASIGNA LOS PRIVILEGIOS DE LA BARRA DE MENU ***
            '==================================================

            Dim ContarRegistros As Integer = Me.BindingSource_MOALMEAY_1.Count

            Dim boCONTAGRE As Boolean = False
            Dim boCONTMODI As Boolean = False
            Dim boCONTELIM As Boolean = False
            Dim boCONTCONS As Boolean = False
            Dim boCONTRECO As Boolean = False

            pro_Permiso_Barra_De_Menu_Formulario_SubFormulario(ContarRegistros, Trim(Me.BindingNavigator_MOALMEAY_1.Name), boCONTAGRE, boCONTMODI, boCONTELIM, boCONTCONS, boCONTRECO)

            Me.cmdAGREGAR_MOALMEAY.Enabled = boCONTAGRE
            Me.cmdMODIFICAR_MOALMEAY.Enabled = boCONTMODI
            Me.cmdELIMINAR_MOALMEAY.Enabled = boCONTELIM
            Me.cmdCONSULTAR_MOALMEAY.Enabled = boCONTCONS
            Me.cmdRECONSULTAR_MOALMEAY.Enabled = boCONTRECO

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try
    End Sub
    Private Sub pro_ListaDeValoresMesaDeAyuda()

        Try
            If Me.dgvMOALMEAY.RowCount = 0 Then

                pro_LimpiarMesaDeAyuda()

            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub pro_LimpiarMesaDeAyuda()

        'Me.dgvMOALMEAY.DataSource = New DataTable

    End Sub

#End Region

#Region "PROCEDIMIENTOS PREDIOS NUEVOS"

    Private Sub pro_ReconsultarPrediosNuevos()

        Try
            Dim objdatos As New cla_MOGEPRNU

            If vl_boPENDIENTES = False Then
                If vl_boCONSULTA = False Then
                    Me.BindingSource_MOALPRNU_1.DataSource = objdatos.fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_MOGEPRNU(Me.dgvMOALGEOG.SelectedRows.Item(0).Cells("MOALSECU").Value.ToString)
                Else
                    Me.BindingSource_MOALPRNU_1.DataSource = objdatos.fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_MOGEPRNU(Me.dgvMOALGEOG.SelectedRows.Item(0).Cells("MOALSECU").Value.ToString)
                End If
            Else
                If vl_boCONSULTA = False Then
                    Me.BindingSource_MOALPRNU_1.DataSource = objdatos.fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_MOGEPRNU(Me.dgvMOALPEND.SelectedRows.Item(0).Cells("MOALSECU").Value.ToString)
                Else
                    Me.BindingSource_MOALPRNU_1.DataSource = objdatos.fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_MOGEPRNU(Me.dgvMOALPEND.SelectedRows.Item(0).Cells("MOALSECU").Value.ToString)
                End If
            End If

            Me.dgvMOALPRNU.DataSource = Me.BindingSource_MOALPRNU_1
            Me.BindingNavigator_MOALPRNU_1.BindingSource = Me.BindingSource_MOALPRNU_1

            '==================================================
            '*** CONFIGURA OBJETOS DEL FORMULARIO MAESTRO ***
            '==================================================

            Me.dgvMOALPRNU.Columns("MGPNIDRE").HeaderText = "idre"
            Me.dgvMOALPRNU.Columns("MGPNSECU").HeaderText = "Secuencia"

            Me.dgvMOALPRNU.Columns("MGPNMUNI").HeaderText = "Municipio"
            Me.dgvMOALPRNU.Columns("MGPNCORR").HeaderText = "Corregi."
            Me.dgvMOALPRNU.Columns("MGPNBARR").HeaderText = "Barrio"
            Me.dgvMOALPRNU.Columns("MGPNMANZ").HeaderText = "Manzana o Vereda"
            Me.dgvMOALPRNU.Columns("MGPNPRED").HeaderText = "Predio"
            Me.dgvMOALPRNU.Columns("MGPNCLSE").HeaderText = "Clase o Sector"
            Me.dgvMOALPRNU.Columns("MGPNCAAC").HeaderText = "Causa de acto"
            Me.dgvMOALPRNU.Columns("CAACDESC").HeaderText = "Descripción"
            Me.dgvMOALPRNU.Columns("MGPNNUFI").HeaderText = "Nro. Ficha Municipio"
            Me.dgvMOALPRNU.Columns("MGPNNUOV").HeaderText = "Nro. Ficha OVC"

            Me.dgvMOALPRNU.Columns("CAACDESC").Width = 100

            Me.dgvMOALPRNU.Columns("MGPNIDRE").Visible = False
            Me.dgvMOALPRNU.Columns("MGPNSECU").Visible = False
            Me.dgvMOALPRNU.Columns("MGPNEDIF").Visible = False
            Me.dgvMOALPRNU.Columns("MGPNUNPR").Visible = False

            '==================================================
            '*** ASIGNA LOS PRIVILEGIOS DE LA BARRA DE MENU ***
            '==================================================

            Dim ContarRegistros As Integer = Me.BindingSource_MOALPRNU_1.Count

            Dim boCONTAGRE As Boolean = False
            Dim boCONTMODI As Boolean = False
            Dim boCONTELIM As Boolean = False
            Dim boCONTCONS As Boolean = False
            Dim boCONTRECO As Boolean = False

            pro_Permiso_Barra_De_Menu_Formulario_SubFormulario(ContarRegistros, Trim(Me.BindingNavigator_MOALPRNU_1.Name), boCONTAGRE, boCONTMODI, boCONTELIM, boCONTCONS, boCONTRECO)

            Me.cmdAGREGAR_MOALPRNU.Enabled = boCONTAGRE
            Me.cmdMODIFICAR_MOALPRNU.Enabled = boCONTMODI
            Me.cmdELIMINAR_MOALPRNU.Enabled = boCONTELIM
            Me.cmdCONSULTAR_MOALPRNU.Enabled = boCONTCONS
            Me.cmdRECONSULTAR_MOALPRNU.Enabled = boCONTRECO

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try
    End Sub
    Private Sub pro_ListaDeValoresPrediosNuevos()

        Try
            If Me.dgvMOALPRNU.RowCount = 0 Then

                'pro_LimpiarPrediosNuevos()

            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub pro_LimpiarPrediosNuevos()

        'Me.dgvMOALPRNU.DataSource = New DataTable

    End Sub

#End Region

#Region "PROCEDIMIENTOS DIGITALIZACION GRAFICA"

    Private Sub pro_ReconsultarDigitalizacionGrafica()

        Try
            Dim objdatos As New cla_MOALDIGI

            If vl_boPENDIENTES = False Then
                If vl_boCONSULTA = False Then
                    Me.BindingSource_MOALDIGI_1.DataSource = objdatos.fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_MOALDIGI(Me.dgvMOALGEOG.SelectedRows.Item(0).Cells("MOALSECU").Value.ToString)
                Else
                    Me.BindingSource_MOALDIGI_1.DataSource = objdatos.fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_MOALDIGI(Me.dgvMOALGEOG.SelectedRows.Item(0).Cells("MOALSECU").Value.ToString)
                End If
            Else
                If vl_boCONSULTA = False Then
                    Me.BindingSource_MOALDIGI_1.DataSource = objdatos.fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_MOALDIGI(Me.dgvMOALPEND.SelectedRows.Item(0).Cells("MOALSECU").Value.ToString)
                Else
                    Me.BindingSource_MOALDIGI_1.DataSource = objdatos.fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_MOALDIGI(Me.dgvMOALPEND.SelectedRows.Item(0).Cells("MOALSECU").Value.ToString)
                End If
            End If

            Me.dgvMOALDIGI.DataSource = Me.BindingSource_MOALDIGI_1
            Me.BindingNavigator_MOALDIGI_1.BindingSource = Me.BindingSource_MOALDIGI_1

            '==================================================
            '*** CONFIGURA OBJETOS DEL FORMULARIO MAESTRO ***
            '==================================================

            Me.dgvMOALDIGI.Columns("MADIIDRE").HeaderText = "idre"
            Me.dgvMOALDIGI.Columns("MADISECU").HeaderText = "Secuencia"

            Me.dgvMOALDIGI.Columns("MADINUDO").HeaderText = "Nro. Documento"
            Me.dgvMOALDIGI.Columns("USUANOMB").HeaderText = "Nombre(s)"
            Me.dgvMOALDIGI.Columns("USUAPRAP").HeaderText = "Primer apellido"
            Me.dgvMOALDIGI.Columns("USUASEAP").HeaderText = "Segundo apellido"
            Me.dgvMOALDIGI.Columns("MADIFEEN").HeaderText = "Fecha de asignación"
            Me.dgvMOALDIGI.Columns("MADIFEFI").HeaderText = "Fecha de finalización"
            Me.dgvMOALDIGI.Columns("MADIOBSE").HeaderText = "Observación"

            Me.dgvMOALDIGI.Columns("MADIIDRE").Visible = False
            Me.dgvMOALDIGI.Columns("MADISECU").Visible = False

            Me.dgvMOALDIGI.Columns("MADINUDO").Width = 50
            Me.dgvMOALDIGI.Columns("USUANOMB").Width = 50
            Me.dgvMOALDIGI.Columns("USUAPRAP").Width = 50
            Me.dgvMOALDIGI.Columns("USUASEAP").Width = 50
            Me.dgvMOALDIGI.Columns("MADIFEEN").Width = 50
            Me.dgvMOALDIGI.Columns("MADIOBSE").Width = 200

            '==================================================
            '*** ASIGNA LOS PRIVILEGIOS DE LA BARRA DE MENU ***
            '==================================================

            Dim ContarRegistros As Integer = Me.BindingSource_MOALDIGI_1.Count

            Dim boCONTAGRE As Boolean = False
            Dim boCONTMODI As Boolean = False
            Dim boCONTELIM As Boolean = False
            Dim boCONTCONS As Boolean = False
            Dim boCONTRECO As Boolean = False

            pro_Permiso_Barra_De_Menu_Formulario_SubFormulario(ContarRegistros, Trim(Me.BindingNavigator_MOALDIGI_1.Name), boCONTAGRE, boCONTMODI, boCONTELIM, boCONTCONS, boCONTRECO)

            Me.cmdAGREGAR_MOALDIGI.Enabled = boCONTAGRE
            Me.cmdMODIFICAR_MOALDIGI.Enabled = boCONTMODI
            Me.cmdELIMINAR_MOALDIGI.Enabled = boCONTELIM
            Me.cmdCONSULTAR_MOALDIGI.Enabled = boCONTCONS
            Me.cmdRECONSULTAR_MOALDIGI.Enabled = boCONTRECO

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try
    End Sub
    Private Sub pro_ListaDeValoresDigitalizacionGrafica()

        Try
            If Me.dgvMOALDIGI.RowCount = 0 Then

                pro_LimpiarDigitalizacion()

            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub pro_LimpiarDigitalizacion()

        'Me.dgvMOALDIGI.DataSource = New DataTable

    End Sub

#End Region

#Region "MENU MOVIMIENTO GEOGRAFICO"

    Private Sub cmdAGREGAR_MOVIALFA_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAGREGAR_MOVIALFA.Click
        Try
            frm_insertar_MOVIALFA.ShowDialog()

            If vp_inConsulta <> 0 Then
                vl_boCONSULTA = True

                pro_ReconsultarMovimientosAlfanumericos()
                pro_ListaDeValoresMovimientosAlfanumericos()

                If MessageBox.Show("¿ Desea agregar el tramite OVC ?", "Mensaje ...", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then
                    Me.TabMAESTRO1.SelectTab(TabGenerales)
                    Me.TabMAESTRO2.SelectTab(TabTramitesOVC)
                    Me.cmdAGREGAR_MOALTRAM.PerformClick()
                End If
            Else
                Me.TabMAESTRO1.SelectTab(TabGenerales)
                Me.TabMAESTRO2.SelectTab(TabTramitesOVC)

            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try
    End Sub
    Private Sub cmdMODIFICAR_MOVIALFA_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdMODIFICAR_MOVIALFA.Click
        Try
            Me.TabMAESTRO1.SelectTab(TabGenerales)

            If MessageBox.Show("¿ Desea modificar el tramite Nro. " & Me.dgvMOALGEOG.SelectedRows.Item(0).Cells("MOALSECU").Value.ToString() & " ? ", "Mensaje...", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then

                Dim frm_modificar As New frm_modificar_MOVIALFA(Integer.Parse(Me.dgvMOALGEOG.SelectedRows.Item(0).Cells("MOALIDRE").Value.ToString()), _
                                                                         Me.dgvMOALGEOG.SelectedRows.Item(0).Cells("MOALNUDO").Value.ToString())
                frm_modificar.ShowDialog()

                If vp_inConsulta <> 0 Then
                    vl_boCONSULTA = True

                    pro_ReconsultarMovimientosAlfanumericos()
                    pro_ListaDeValoresMovimientosAlfanumericos()

                End If

            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try
    End Sub
    Private Sub cmdELIMINAR_MOVIALFA_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdELIMINAR_MOVIALFA.Click
        Try
            If MessageBox.Show("¿ Desea eliminar el registro seleccionado ? ", "Mensaje...", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then
                Dim objdatos As New cla_MOVIALFA

                If objdatos.fun_Eliminar_IDRE_MOVIALFA(Integer.Parse(Me.dgvMOALGEOG.SelectedRows.Item(0).Cells(0).Value.ToString())) Then

                    vl_boCONSULTA = False
                    pro_LimpiarCamposMovimientoGeografico()
                    pro_ReconsultarMovimientosAlfanumericos()
                    pro_ListaDeValoresMovimientosAlfanumericos()
                Else
                    frm_INCO_eliminar_registro_padre_con_relación_de_registros_hijos.ShowDialog()
                End If

            End If
        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try
    End Sub
    Private Sub cmdCONSULTAR_MOVIALFA_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCONSULTAR_MOVIALFA.Click
        Try
            vp_inConsulta = 0

            frm_consultar_MOVIALFA.ShowDialog()

            If vp_inConsulta > 0 Then
                vl_boCONSULTA = True
            Else
                vl_boCONSULTA = False
            End If

            pro_ReconsultarMovimientosAlfanumericos()
            pro_ListaDeValoresMovimientosAlfanumericos()

            Me.TabMAESTRO1.SelectTab(TabGenerales)
            Me.TabMAESTRO2.SelectTab(TabTramitesOVC)

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try
    End Sub
    Private Sub cmdRECONSULTAR_MOVIALFA_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdRECONSULTAR_MOVIALFA.Click
        Try
            vl_boRECONSULTAR = True
            vl_boCONSULTA = False
            pro_ReconsultarMovimientosAlfanumericos()
            pro_ListaDeValoresMovimientosAlfanumericos()

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try
    End Sub
    Private Sub cmdIMPORTAR_DOCUMENTOS_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdIMPORTAR_DOCUMENTOS.Click
        Try
            If MessageBox.Show("¿ Desea agregar archivos del tramite de Movimientos Pendientes ? ", "Mensaje...", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then

                If Me.dgvMOALPEND.RowCount > 0 Then

                    Me.TabMAESTRO1.SelectTab(TabPendientes)

                    If MessageBox.Show("¿ Desea anexar archivos al tramite Nro. " & Me.dgvMOALPEND.SelectedRows.Item(0).Cells("MOALSECU").Value.ToString() & " ? ", "Mensaje...", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then

                        Dim frm_inserta_archivo As New frm_insertar_archivo_MOVIALFA(Me.dgvMOALPEND.SelectedRows.Item(0).Cells("MOALMUNI").Value.ToString(), _
                                                                                     Me.dgvMOALPEND.SelectedRows.Item(0).Cells("MOALCORR").Value.ToString(), _
                                                                                     Me.dgvMOALPEND.SelectedRows.Item(0).Cells("MOALBARR").Value.ToString(), _
                                                                                     Me.dgvMOALPEND.SelectedRows.Item(0).Cells("MOALMANZ").Value.ToString(), _
                                                                                     Me.dgvMOALPEND.SelectedRows.Item(0).Cells("MOALPRED").Value.ToString(), _
                                                                                     Me.dgvMOALPEND.SelectedRows.Item(0).Cells("MOALCLSE").Value.ToString(), _
                                                                                     Me.dgvMOALPEND.SelectedRows.Item(0).Cells("MOALVIGE").Value.ToString())
                        frm_inserta_archivo.ShowDialog()

                        pro_ListadoArchivosDocumentosMovimientosAlfanumericos(True)
                        pro_ListadoArchivosDocumentosMovimientosGeograficos(True)

                    End If

                Else
                    Me.TabMAESTRO1.SelectTab(TabPendientes)
                    mod_MENSAJE.No_Existe_Un_Registro_Seleccionado()
                End If

            ElseIf MessageBox.Show("¿ Desea agregar archivos del tramite de Movimientos Generales ? ", "Mensaje...", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then

                If Me.dgvMOALGEOG.RowCount > 0 Then

                    Me.TabMAESTRO1.SelectTab(TabGenerales)

                    If MessageBox.Show("¿ Desea anexar archivos al tramite Nro. " & Me.dgvMOALGEOG.SelectedRows.Item(0).Cells("MOALSECU").Value.ToString() & " ? ", "Mensaje...", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then

                        Dim frm_inserta_archivo As New frm_insertar_archivo_MOVIALFA(Me.dgvMOALGEOG.SelectedRows.Item(0).Cells("MOALMUNI").Value.ToString(), _
                                                                                     Me.dgvMOALGEOG.SelectedRows.Item(0).Cells("MOALCORR").Value.ToString(), _
                                                                                     Me.dgvMOALGEOG.SelectedRows.Item(0).Cells("MOALBARR").Value.ToString(), _
                                                                                     Me.dgvMOALGEOG.SelectedRows.Item(0).Cells("MOALMANZ").Value.ToString(), _
                                                                                     Me.dgvMOALGEOG.SelectedRows.Item(0).Cells("MOALPRED").Value.ToString(), _
                                                                                     Me.dgvMOALGEOG.SelectedRows.Item(0).Cells("MOALCLSE").Value.ToString(), _
                                                                                     Me.dgvMOALGEOG.SelectedRows.Item(0).Cells("MOALVIGE").Value.ToString())
                        frm_inserta_archivo.ShowDialog()

                        pro_ListadoArchivosDocumentosMovimientosAlfanumericos(False)
                        pro_ListadoArchivosDocumentosMovimientosGeograficos(False)

                    End If

                Else
                    Me.TabMAESTRO1.SelectTab(TabGenerales)
                    mod_MENSAJE.No_Existe_Un_Registro_Seleccionado()
                End If

            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try
    End Sub
    Private Sub cmdSALIR_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSALIR.Click
        Me.Close()
    End Sub

    Private Sub cmdOBSERVACIONES_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOBSERVACIONES.Click
        pro_EjecutarBotonObservaciones()
    End Sub
    Private Sub cmdFINALIZAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdFinalizar.Click
        pro_EjecutarBotonFinalizar()
    End Sub
    Private Sub cmdREASIGNAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdREASIGNAR.Click
        pro_EjecutarBotonReasignar()
    End Sub

    Private Sub ToolStripButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton1.Click
        pro_ListaDeValoresMovimientosAlfanumericos()
    End Sub
    Private Sub ToolStripButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton2.Click
        pro_ListaDeValoresMovimientosAlfanumericos()
    End Sub
    Private Sub ToolStripButton3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton3.Click
        pro_ListaDeValoresMovimientosAlfanumericos()
    End Sub
    Private Sub ToolStripButton4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton4.Click
        pro_ListaDeValoresMovimientosAlfanumericos()
    End Sub

#End Region

#Region "MENU TRAMITE OVC"

    Private Sub cmdAGREGAR_MOALTRAM_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAGREGAR_MOALTRAM.Click

        Try
            If MessageBox.Show("¿ Desea agregar un registro del tramite de Movimientos Pendientes ? ", "Mensaje...", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then

                If Me.dgvMOALPEND.RowCount > 0 Then

                    Me.TabMAESTRO1.SelectTab(TabPendientes)

                    If MessageBox.Show("¿ Desea agregar un tramite ovc, tramite Nro. " & Me.dgvMOALPEND.SelectedRows.Item(0).Cells("MOALSECU").Value.ToString() & " ? ", "Mensaje...", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then

                        Dim frm_modificar As New frm_insertar_MOGETRAM(Integer.Parse(Me.dgvMOALPEND.SelectedRows.Item(0).Cells("MOALSECU").Value.ToString()))
                        frm_modificar.ShowDialog()

                        vl_boPENDIENTES = True
                        vl_boCONSULTA = False

                        pro_ReconsultarTramitesOVC()
                        pro_ListaDeValoresTramitesOVC()

                        Me.TabMAESTRO2.SelectTab(TabTramitesOVC)

                    End If

                Else
                    Me.TabMAESTRO1.SelectTab(TabPendientes)
                    mod_MENSAJE.No_Existe_Un_Registro_Seleccionado()
                End If

            ElseIf MessageBox.Show("¿ Desea agregar un registro del tramite de Movimientos Generales ? ", "Mensaje...", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then

                If Me.dgvMOALGEOG.RowCount > 0 Then

                    Me.TabMAESTRO1.SelectTab(TabGenerales)

                    If MessageBox.Show("¿ Desea agregar un tramite ovc, tramite Nro. " & Me.dgvMOALGEOG.SelectedRows.Item(0).Cells("MOALSECU").Value.ToString() & " ? ", "Mensaje...", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then

                        Dim frm_modificar As New frm_insertar_MOGETRAM(Integer.Parse(Me.dgvMOALGEOG.SelectedRows.Item(0).Cells("MOALSECU").Value.ToString()))
                        frm_modificar.ShowDialog()

                        vl_boPENDIENTES = False
                        vl_boCONSULTA = False

                        pro_ReconsultarTramitesOVC()
                        pro_ListaDeValoresTramitesOVC()

                        Me.TabMAESTRO2.SelectTab(TabTramitesOVC)

                    End If

                Else
                    Me.TabMAESTRO1.SelectTab(TabGenerales)
                    mod_MENSAJE.No_Existe_Un_Registro_Seleccionado()
                End If

            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub cmdMODIFICAR_MOALTRAM_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdMODIFICAR_MOALTRAM.Click

        Try
            If Me.dgvMOALTRAM.RowCount > 0 Then

                If MessageBox.Show("¿ Desea modificar el tramite ovc, tramite Nro. " & Me.dgvMOALTRAM.SelectedRows.Item(0).Cells("MGTRSECU").Value.ToString() & " ? ", "Mensaje...", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then

                    Dim frm_modificar As New frm_insertar_MOGETRAM(Integer.Parse(Me.dgvMOALTRAM.SelectedRows.Item(0).Cells("MGTRIDRE").Value.ToString()), _
                                                                   Integer.Parse(Me.dgvMOALTRAM.SelectedRows.Item(0).Cells("MGTRSECU").Value.ToString()))
                    frm_modificar.ShowDialog()
                    vl_boCONSULTA = False

                    pro_ReconsultarTramitesOVC()
                    pro_ListaDeValoresTramitesOVC()

                    Me.TabMAESTRO2.SelectTab(TabTramitesOVC)

                End If
            Else
                mod_MENSAJE.No_Existe_Un_Registro_Seleccionado()
            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub cmdELIMINAR_MOALTRAM_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdELIMINAR_MOALTRAM.Click

        Try
            If MessageBox.Show("¿ Desea eliminar el registro seleccionado ? ", "Mensaje...", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then
                Dim objdatos As New cla_MOGETRAM

                If Me.dgvMOALTRAM.RowCount > 0 Then

                    If objdatos.fun_Eliminar_IDRE_MOGETRAM(Integer.Parse(Me.dgvMOALTRAM.SelectedRows.Item(0).Cells("MGTRIDRE").Value.ToString())) Then
                        vl_boCONSULTA = False

                        pro_LimpiarTramitesOVC()
                        pro_ReconsultarTramitesOVC()
                        pro_ListaDeValoresTramitesOVC()

                        Me.TabMAESTRO2.SelectTab(TabTramitesOVC)
                    Else
                        frm_INCO_eliminar_registro_padre_con_relación_de_registros_hijos.ShowDialog()
                    End If
                Else
                    mod_MENSAJE.No_Existe_Un_Registro_Seleccionado()
                End If

            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub cmdCONSULTAR_MOALTRAM_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCONSULTAR_MOALTRAM.Click

        Try
            vp_inConsulta = 0

            frm_consultar_MOVIALFA.ShowDialog()

            If vp_inConsulta > 0 Then
                vl_boCONSULTA = True
            Else
                vl_boCONSULTA = False
            End If

            pro_ReconsultarMovimientosAlfanumericos()
            pro_ListaDeValoresMovimientosALFANUMERICOS()

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub cmdRECONSULTAR_MOALTRAM_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdRECONSULTAR_MOALTRAM.Click

        Try
            vl_boCONSULTA = False
            pro_ReconsultarMovimientosAlfanumericos()
            pro_ListaDeValoresMovimientosALFANUMERICOS()

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub

#End Region

#Region "MENU MESA DE AYUDA"

    Private Sub cmdAGREGAR_MOALMEAY_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAGREGAR_MOALMEAY.Click

        Try
            If MessageBox.Show("¿ Desea agregar un registro del tramite de Movimientos Pendientes ? ", "Mensaje...", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then

                If Me.dgvMOALPEND.RowCount > 0 Then

                    Me.TabMAESTRO1.SelectTab(TabPendientes)

                    If MessageBox.Show("¿ Desea agregar la mesa de ayuda, tramite Nro. " & Me.dgvMOALPEND.SelectedRows.Item(0).Cells("MOALSECU").Value.ToString() & " ? ", "Mensaje...", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then

                        Dim frm_modificar As New frm_insertar_MOGEMEAY(Integer.Parse(Me.dgvMOALPEND.SelectedRows.Item(0).Cells("MOALSECU").Value.ToString()))
                        frm_modificar.ShowDialog()

                        vl_boPENDIENTES = True
                        vl_boCONSULTA = False

                        pro_ReconsultarMesaDeAyuda()
                        pro_ListaDeValoresMesaDeAyuda()

                        Me.TabMAESTRO2.SelectTab(TabMesaDeAyuda)

                    End If

                Else
                    Me.TabMAESTRO1.SelectTab(TabPendientes)
                    mod_MENSAJE.No_Existe_Un_Registro_Seleccionado()
                End If

            ElseIf MessageBox.Show("¿ Desea agregar un registro del tramite de Movimientos Generales ? ", "Mensaje...", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then

                If Me.dgvMOALGEOG.RowCount > 0 Then

                    Me.TabMAESTRO1.SelectTab(TabGenerales)

                    If MessageBox.Show("¿ Desea agregar la mesa de ayuda, tramite Nro. " & Me.dgvMOALGEOG.SelectedRows.Item(0).Cells("MOALSECU").Value.ToString() & " ? ", "Mensaje...", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then

                        Dim frm_modificar As New frm_insertar_MOGEMEAY(Integer.Parse(Me.dgvMOALGEOG.SelectedRows.Item(0).Cells("MOALSECU").Value.ToString()))
                        frm_modificar.ShowDialog()

                        vl_boPENDIENTES = False
                        vl_boCONSULTA = False

                        pro_ReconsultarMesaDeAyuda()
                        pro_ListaDeValoresMesaDeAyuda()

                        Me.TabMAESTRO2.SelectTab(TabMesaDeAyuda)

                    End If

                Else
                    Me.TabMAESTRO1.SelectTab(TabPendientes)
                    mod_MENSAJE.No_Existe_Un_Registro_Seleccionado()
                End If

            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub cmdMODIFICAR_MOALMEAY_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdMODIFICAR_MOALMEAY.Click

        Try
            If Me.dgvMOALMEAY.RowCount > 0 Then

                If MessageBox.Show("¿ Desea modificar la mesa de ayuda, tramite Nro. " & Me.dgvMOALMEAY.SelectedRows.Item(0).Cells("MGMASECU").Value.ToString() & " ? ", "Mensaje...", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then

                    Dim frm_modificar As New frm_insertar_MOGEMEAY(Integer.Parse(Me.dgvMOALMEAY.SelectedRows.Item(0).Cells("MGMAIDRE").Value.ToString()), _
                                                                   Integer.Parse(Me.dgvMOALMEAY.SelectedRows.Item(0).Cells("MGMASECU").Value.ToString()))
                    frm_modificar.ShowDialog()
                    vl_boCONSULTA = False

                    pro_ReconsultarMesaDeAyuda()
                    pro_ListaDeValoresMesaDeAyuda()

                    Me.TabMAESTRO2.SelectTab(TabMesaDeAyuda)

                End If
            Else
                mod_MENSAJE.No_Existe_Un_Registro_Seleccionado()
            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub cmdELIMINAR_MOALMEAY_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdELIMINAR_MOALMEAY.Click

        Try
            If MessageBox.Show("¿ Desea eliminar el registro seleccionado ? ", "Mensaje...", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then
                Dim objdatos As New cla_MOGEMEAY

                If Me.dgvMOALMEAY.RowCount > 0 Then

                    If objdatos.fun_Eliminar_IDRE_MOGEMEAY(Integer.Parse(Me.dgvMOALMEAY.SelectedRows.Item(0).Cells("MGMAIDRE").Value.ToString())) Then
                        vl_boCONSULTA = False

                        pro_LimpiarMesaDeAyuda()
                        pro_ReconsultarMesaDeAyuda()
                        pro_ListaDeValoresMesaDeAyuda()

                        Me.TabMAESTRO2.SelectTab(TabMesaDeAyuda)
                    Else
                        frm_INCO_eliminar_registro_padre_con_relación_de_registros_hijos.ShowDialog()
                    End If
                Else
                    mod_MENSAJE.No_Existe_Un_Registro_Seleccionado()
                End If

            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub cmdCONSULTAR_MOALMEAY_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCONSULTAR_MOALMEAY.Click

        Try
            vp_inConsulta = 0

            frm_consultar_MOVIALFA.ShowDialog()

            If vp_inConsulta > 0 Then
                vl_boCONSULTA = True
            Else
                vl_boCONSULTA = False
            End If

            pro_ReconsultarMovimientosAlfanumericos()
            pro_ListaDeValoresMovimientosALFANUMERICOS()

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub cmdRECONSULTAR_MOALMEAY_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdRECONSULTAR_MOALMEAY.Click

        Try
            vl_boCONSULTA = False
            pro_ReconsultarMovimientosAlfanumericos()
            pro_ListaDeValoresMovimientosALFANUMERICOS()

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub

#End Region

#Region "MENU PREDIOS NUEVOS"

    Private Sub cmdAGREGAR_MOALPRNU_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAGREGAR_MOALPRNU.Click

        Try
            If MessageBox.Show("¿ Desea agregar un registro del tramite de Movimientos Pendientes ? ", "Mensaje...", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then

                If Me.dgvMOALPEND.RowCount > 0 Then

                    Me.TabMAESTRO1.SelectTab(TabPendientes)

                    If MessageBox.Show("¿ Desea agregar predios nuevos, tramite Nro. " & Me.dgvMOALPEND.SelectedRows.Item(0).Cells("MOALSECU").Value.ToString() & " ? ", "Mensaje...", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then

                        Dim frm_modificar As New frm_insertar_MOGEPRNU(Integer.Parse(Me.dgvMOALPEND.SelectedRows.Item(0).Cells("MOALSECU").Value.ToString()))
                        frm_modificar.ShowDialog()

                        vl_boPENDIENTES = True
                        vl_boCONSULTA = False

                        pro_ReconsultarPrediosNuevos()
                        pro_ListaDeValoresPrediosNuevos()

                        Me.TabMAESTRO2.SelectTab(TabPrediosNuevos)

                    End If

                Else
                    Me.TabMAESTRO1.SelectTab(TabPendientes)
                    mod_MENSAJE.No_Existe_Un_Registro_Seleccionado()
                End If

            ElseIf MessageBox.Show("¿ Desea agregar un registro del tramite de Movimientos Generales ? ", "Mensaje...", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then

                If Me.dgvMOALGEOG.RowCount > 0 Then

                    Me.TabMAESTRO1.SelectTab(TabGenerales)

                    If MessageBox.Show("¿ Desea agregar predios nuevos, tramite Nro. " & Me.dgvMOALGEOG.SelectedRows.Item(0).Cells("MOALSECU").Value.ToString() & " ? ", "Mensaje...", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then

                        Dim frm_modificar As New frm_insertar_MOGEPRNU(Integer.Parse(Me.dgvMOALGEOG.SelectedRows.Item(0).Cells("MOALSECU").Value.ToString()))
                        frm_modificar.ShowDialog()

                        vl_boPENDIENTES = False
                        vl_boCONSULTA = False

                        pro_ReconsultarPrediosNuevos()
                        pro_ListaDeValoresPrediosNuevos()

                        Me.TabMAESTRO2.SelectTab(TabPrediosNuevos)

                    End If

                Else
                    Me.TabMAESTRO1.SelectTab(TabPendientes)
                    mod_MENSAJE.No_Existe_Un_Registro_Seleccionado()
                End If

            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub cmdMODIFICAR_MOALPRNU_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdMODIFICAR_MOALPRNU.Click

        Try
            If Me.dgvMOALPRNU.RowCount > 0 Then

                If MessageBox.Show("¿ Desea modificar predios nuevos, tramite Nro. " & Me.dgvMOALPRNU.SelectedRows.Item(0).Cells("MGPNSECU").Value.ToString() & " ? ", "Mensaje...", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then

                    Dim frm_modificar As New frm_insertar_MOGEPRNU(Integer.Parse(Me.dgvMOALPRNU.SelectedRows.Item(0).Cells("MGPNIDRE").Value.ToString()), _
                                                                   Integer.Parse(Me.dgvMOALPRNU.SelectedRows.Item(0).Cells("MGPNSECU").Value.ToString()))
                    frm_modificar.ShowDialog()
                    vl_boCONSULTA = False

                    pro_ReconsultarPrediosNuevos()
                    pro_ListaDeValoresPrediosNuevos()

                    Me.TabMAESTRO2.SelectTab(TabPrediosNuevos)

                End If
            Else
                mod_MENSAJE.No_Existe_Un_Registro_Seleccionado()
            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub cmdELIMINAR_MOALPRNU_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdELIMINAR_MOALPRNU.Click

        Try
            If MessageBox.Show("¿ Desea eliminar el registro seleccionado ? ", "Mensaje...", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then
                Dim objdatos As New cla_MOGEPRNU

                If Me.dgvMOALPRNU.RowCount > 0 Then

                    If objdatos.fun_Eliminar_IDRE_MOGEPRNU(Integer.Parse(Me.dgvMOALPRNU.SelectedRows.Item(0).Cells("MGPNIDRE").Value.ToString())) Then
                        vl_boCONSULTA = False

                        pro_LimpiarPrediosNuevos()
                        pro_ReconsultarPrediosNuevos()
                        pro_ListaDeValoresPrediosNuevos()

                        Me.TabMAESTRO2.SelectTab(TabPrediosNuevos)
                    Else
                        frm_INCO_eliminar_registro_padre_con_relación_de_registros_hijos.ShowDialog()
                    End If
                Else
                    mod_MENSAJE.No_Existe_Un_Registro_Seleccionado()
                End If

            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub cmdCONSULTAR_MOALPRNU_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCONSULTAR_MOALPRNU.Click

        Try
            vp_inConsulta = 0

            frm_consultar_MOVIALFA.ShowDialog()

            If vp_inConsulta > 0 Then
                vl_boCONSULTA = True
            Else
                vl_boCONSULTA = False
            End If

            pro_ReconsultarMovimientosAlfanumericos()
            pro_ListaDeValoresMovimientosALFANUMERICOS()

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub cmdRECONSULTAR_MOALPRNU_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdRECONSULTAR_MOALPRNU.Click

        Try
            vl_boCONSULTA = False
            pro_ReconsultarMovimientosAlfanumericos()
            pro_ListaDeValoresMovimientosALFANUMERICOS()

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub

#End Region

#Region "MENU DIGITALIZACION GRAFICA"

    Private Sub cmdAGREGAR_MOALDIGI_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAGREGAR_MOALDIGI.Click

        Try
            If MessageBox.Show("¿ Desea agregar un registro del tramite de Movimientos Pendientes ? ", "Mensaje...", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then

                If Me.dgvMOALPEND.RowCount > 0 Then

                    Me.TabMAESTRO1.SelectTab(TabPendientes)

                    If MessageBox.Show("¿ Desea agregar digitalización gráfica, tramite Nro. " & Me.dgvMOALPEND.SelectedRows.Item(0).Cells("MOALSECU").Value.ToString() & " ? ", "Mensaje...", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then

                        Dim frm_modificar As New frm_insertar_MOALDIGI(Integer.Parse(Me.dgvMOALPEND.SelectedRows.Item(0).Cells("MOALSECU").Value.ToString()))
                        frm_modificar.ShowDialog()

                        vl_boPENDIENTES = True
                        vl_boCONSULTA = False

                        pro_ReconsultarDigitalizacionGrafica()
                        pro_ListaDeValoresDigitalizacionGrafica()

                        Me.TabMAESTRO2.SelectTab(TabDigitalizacion)

                    End If

                Else
                    Me.TabMAESTRO1.SelectTab(TabPendientes)
                    mod_MENSAJE.No_Existe_Un_Registro_Seleccionado()
                End If

            ElseIf MessageBox.Show("¿ Desea agregar un registro del tramite de Movimientos Generales ? ", "Mensaje...", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then

                If Me.dgvMOALGEOG.RowCount > 0 Then

                    Me.TabMAESTRO1.SelectTab(TabGenerales)

                    If MessageBox.Show("¿ Desea agregar digitalización gráfica, tramite Nro. " & Me.dgvMOALGEOG.SelectedRows.Item(0).Cells("MOALSECU").Value.ToString() & " ? ", "Mensaje...", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then

                        Dim frm_modificar As New frm_insertar_MOALDIGI(Integer.Parse(Me.dgvMOALGEOG.SelectedRows.Item(0).Cells("MOALSECU").Value.ToString()))
                        frm_modificar.ShowDialog()

                        vl_boPENDIENTES = False
                        vl_boCONSULTA = False

                        pro_ReconsultarDigitalizacionGrafica()
                        pro_ListaDeValoresDigitalizacionGrafica()

                        Me.TabMAESTRO2.SelectTab(TabDigitalizacion)

                    End If

                Else
                    Me.TabMAESTRO1.SelectTab(TabPendientes)
                    mod_MENSAJE.No_Existe_Un_Registro_Seleccionado()
                End If

            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub cmdMODIFICAR_MOALDIGI_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdMODIFICAR_MOALDIGI.Click

        Try
            If Me.dgvMOALDIGI.RowCount > 0 Then

                If MessageBox.Show("¿ Desea modificar digitalización gráfica, tramite Nro. " & Me.dgvMOALDIGI.SelectedRows.Item(0).Cells("MADISECU").Value.ToString() & " ? ", "Mensaje...", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then

                    Dim frm_modificar As New frm_insertar_MOALDIGI(Integer.Parse(Me.dgvMOALDIGI.SelectedRows.Item(0).Cells("MADIIDRE").Value.ToString()), _
                                                                   Integer.Parse(Me.dgvMOALDIGI.SelectedRows.Item(0).Cells("MADISECU").Value.ToString()), _
                                                                                 Me.dgvMOALDIGI.SelectedRows.Item(0).Cells("MADINUDO").Value.ToString())
                    frm_modificar.ShowDialog()
                    vl_boCONSULTA = False

                    pro_ReconsultarDigitalizacionGrafica()
                    pro_ListaDeValoresDigitalizacionGrafica()

                    Me.TabMAESTRO2.SelectTab(TabDigitalizacion)

                End If
            Else
                mod_MENSAJE.No_Existe_Un_Registro_Seleccionado()
            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub cmdELIMINAR_MOALDIGI_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdELIMINAR_MOALDIGI.Click

        Try
            If MessageBox.Show("¿ Desea eliminar el registro seleccionado ? ", "Mensaje...", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then
                Dim objdatos As New cla_MOALDIGI

                If Me.dgvMOALDIGI.RowCount > 0 Then

                    If objdatos.fun_Eliminar_IDRE_MOALDIGI(Integer.Parse(Me.dgvMOALDIGI.SelectedRows.Item(0).Cells("MADIIDRE").Value.ToString())) Then
                        vl_boCONSULTA = False

                        pro_LimpiarDigitalizacion()
                        pro_ReconsultarDigitalizacionGrafica()
                        pro_ListaDeValoresDigitalizacionGrafica()

                        Me.TabMAESTRO2.SelectTab(TabDigitalizacion)
                    Else
                        frm_INCO_eliminar_registro_padre_con_relación_de_registros_hijos.ShowDialog()
                    End If
                Else
                    mod_MENSAJE.No_Existe_Un_Registro_Seleccionado()
                End If

            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub cmdCONSULTAR_MOALDIGI_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCONSULTAR_MOALDIGI.Click

        Try
            vp_inConsulta = 0

            frm_consultar_MOVIALFA.ShowDialog()

            If vp_inConsulta > 0 Then
                vl_boCONSULTA = True
            Else
                vl_boCONSULTA = False
            End If

            pro_ReconsultarMovimientosAlfanumericos()
            pro_ListaDeValoresMovimientosAlfanumericos()

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub cmdRECONSULTAR_MOALDIGI_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdRECONSULTAR_MOALDIGI.Click

        Try
            vl_boCONSULTA = False
            pro_ReconsultarMovimientosAlfanumericos()
            pro_ListaDeValoresMovimientosAlfanumericos()

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub

#End Region

#Region "FORMULARIO"

#Region "Load"

    Private Sub frm_MOVIALFA_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        pro_ReconsultarMovimientosAlfanumericos()
        Me.strBARRESTA.Items(0).Text = "Movimiento Alfanuméfico"

    End Sub

#End Region

#Region "GotFocus"

    Private Sub frm_MOVIALFA_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.GotFocus

        If boExistenRegistrosPendientes = True Then
            pro_ListaDeValoresMovimientosALFANUMERICOSPendientes()
            Me.TabMAESTRO1.SelectTab(TabPendientes)

        ElseIf boExistenRegistrosPendientes = False Then
            pro_ListaDeValoresMovimientosALFANUMERICOS()
            Me.TabMAESTRO1.SelectTab(TabGenerales)

        End If

    End Sub
    Private Sub dgvMOVIALFA_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvMOALGEOG.GotFocus
        Me.strBARRESTA.Items(0).Text = Me.dgvMOALGEOG.AccessibleDescription
    End Sub

#End Region

#Region "KeyDown"

    Private Sub dgvTRABCAMP_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgvMOALGEOG.KeyDown
        '===============================================================================================
        '*** INSERTAR REGISTROS ***
        '===============================================================================================


        If e.KeyCode = Keys.F2 Then
            If Me.cmdAGREGAR_MOVIALFA.Enabled = True Then
                Me.cmdAGREGAR_MOVIALFA.PerformClick()
            Else
                mod_MENSAJE.Usuario_No_Tiene_Permiso_Para_Realizar_La_Operacion()
            End If
        End If

        '===============================================================================================
        'MODIFICAR REGISTROS
        '===============================================================================================

        If e.KeyCode = Keys.F3 Then
            If Me.cmdMODIFICAR_MOVIALFA.Enabled = True Then
                Me.cmdMODIFICAR_MOVIALFA.PerformClick()
            Else
                Dim ContarRegistros As Integer = Me.BindingSource_MOVIALFA_1.Count

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
            If Me.cmdELIMINAR_MOVIALFA.Enabled = True Then
                Me.cmdELIMINAR_MOVIALFA.PerformClick()
            Else
                Dim ContarRegistros As Integer = Me.BindingSource_MOVIALFA_1.Count

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
            If Me.cmdCONSULTAR_MOVIALFA.Enabled = True Then
                Me.cmdCONSULTAR_MOVIALFA.PerformClick()
            Else
                mod_MENSAJE.No_Existen_Registros_En_Base_De_Datos()
            End If
        End If

        '===============================================================================================
        '*** RECONSULTAR REGISTROS ***
        '===============================================================================================

        If e.KeyCode = Keys.F8 Then
            If Me.cmdCONSULTAR_MOVIALFA.Enabled = True Then
                Me.cmdRECONSULTAR_MOVIALFA.PerformClick()
            Else
                mod_MENSAJE.No_Existen_Registros_En_Base_De_Datos()
            End If
        End If

    End Sub

#End Region

#Region "KeyUp"

    Private Sub dgvMOVIALFA_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgvMOALGEOG.KeyUp
        If e.KeyCode = Keys.Down Or e.KeyCode = Keys.Up Or e.KeyCode = Keys.Enter Or e.KeyCode = Keys.PageUp Or e.KeyCode = Keys.PageDown Then
            pro_ListaDeValoresMovimientosALFANUMERICOS()
        End If
    End Sub
    Private Sub dgvMOALPEND_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgvMOALPEND.KeyUp
        If e.KeyCode = Keys.Down Or e.KeyCode = Keys.Up Or e.KeyCode = Keys.Enter Or e.KeyCode = Keys.PageUp Or e.KeyCode = Keys.PageDown Then
            pro_ListaDeValoresMovimientosALFANUMERICOSPendientes()
        End If
    End Sub

#End Region

#Region "CellClick"

    Private Sub dgvALUMPUBL_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvMOALGEOG.CellClick
        pro_ListaDeValoresMovimientosALFANUMERICOS()
    End Sub
    Private Sub dgvMOALPEND_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvMOALPEND.CellClick
        pro_ListaDeValoresMovimientosALFANUMERICOSPendientes()
    End Sub

#End Region

#Region "DoubleClick"

    Private Sub lstLISTADO_DOCUMENTOS_MOVIALFA_3_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles lstLISTADO_DOCUMENTOS_MOVIALFA.DoubleClick

        Try
            If lstLISTADO_DOCUMENTOS_MOVIALFA.SelectedIndex <> -1 Then

                Dim stArchivo As String = lstLISTADO_DOCUMENTOS_MOVIALFA.SelectedItem
                Process.Start(vl_stRutaDocumentosMovimientosAlfanumericos & "\" & stArchivo)
            Else

                If lstLISTADO_DOCUMENTOS_MOVIALFA.Items.Count > 0 Then
                    MessageBox.Show("Seleccione un archivo de la lista", "mensaje...", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                End If

            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub lstLISTADO_DOCUMENTOS_MOVIGEOG_3_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles lstLISTADO_DOCUMENTOS_MOVIGEOG.DoubleClick

        Try
            If lstLISTADO_DOCUMENTOS_MOVIGEOG.SelectedIndex <> -1 Then

                Dim stArchivo As String = lstLISTADO_DOCUMENTOS_MOVIGEOG.SelectedItem
                Process.Start(vl_stRutaDocumentosMovimientosGeograficos & "\" & stArchivo)
            Else

                If lstLISTADO_DOCUMENTOS_MOVIGEOG.Items.Count > 0 Then
                    MessageBox.Show("Seleccione un archivo de la lista", "mensaje...", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                End If

            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub lstLISTADO_DOCUMENTOS_TRABCAMP_3_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles lstLISTADO_DOCUMENTOS_TRABCAMP.DoubleClick

        Try
            If lstLISTADO_DOCUMENTOS_TRABCAMP.SelectedIndex <> -1 Then

                Dim stArchivo As String = lstLISTADO_DOCUMENTOS_TRABCAMP.SelectedItem
                Process.Start(vl_stRutaDocumentosTrabajoDeCampo & "\" & stArchivo)
            Else

                If lstLISTADO_DOCUMENTOS_TRABCAMP.Items.Count > 0 Then
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