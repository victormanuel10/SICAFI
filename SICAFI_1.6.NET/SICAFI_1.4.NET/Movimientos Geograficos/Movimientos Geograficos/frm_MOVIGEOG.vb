Imports REGLAS_DEL_NEGOCIO
Imports System
Imports System.IO
Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration
Imports System.Text

Public Class frm_MOVIGEOG

    '===============================
    '*** MOVIMIENTOS GEOGRAFICOS ***
    '===============================

#Region "VARIABLES"

    Dim vl_boCONSULTA As Boolean = False

    Dim vl_stRutaDocumentosTrabajoDeCampo As String = ""
    Dim vl_stRutaDocumentosMovimientoGeografico As String = ""

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

    Public Shared Function instance() As frm_MOVIGEOG
        If frm_Instance Is Nothing OrElse frm_Instance.isdisposed = True Then
            frm_Instance = New frm_MOVIGEOG
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

    Private Function fun_VerificarCarpetaExistenteDocumentosMovimientosGeograficos(ByVal boPendientes As Boolean) As Boolean

        Try
            Dim stRuta As String = ""
            Dim stCarpetaABuscar As String = ""

            ' instancia la clase
            Dim objRutas As New cla_RUTAS
            Dim tblRutas As New DataTable

            tblRutas = objRutas.fun_Buscar_CODIGO_MANT_RUTAS(13)

            If tblRutas.Rows.Count > 0 Then

                ' directorio pricipal
                stRuta = Trim(tblRutas.Rows(0).Item("RUTARUTA")) & "\"

                ' consulta del grib movimientos generales
                If boPendientes = False Then

                    ' directorio expediente 
                    stCarpetaABuscar = Trim(Me.dgvMOVIGEOG.SelectedRows.Item(0).Cells("MOGEMUNI").Value.ToString) & "-" & _
                                       Trim(Me.dgvMOVIGEOG.SelectedRows.Item(0).Cells("MOGECLSE").Value.ToString) & "-" & _
                                       Trim(Me.dgvMOVIGEOG.SelectedRows.Item(0).Cells("MOGECORR").Value.ToString) & "-" & _
                                       Trim(Me.dgvMOVIGEOG.SelectedRows.Item(0).Cells("MOGEBARR").Value.ToString) & "-" & _
                                       Trim(Me.dgvMOVIGEOG.SelectedRows.Item(0).Cells("MOGEMANZ").Value.ToString) & "-" & _
                                       Trim(Me.dgvMOVIGEOG.SelectedRows.Item(0).Cells("MOGEPRED").Value.ToString) & "-" & _
                                       Trim(Me.dgvMOVIGEOG.SelectedRows.Item(0).Cells("MOGEVIGE").Value.ToString)

                    ' consulta del grib movimientos pendientes
                ElseIf boPendientes = True Then

                    ' directorio expediente 
                    stCarpetaABuscar = Trim(Me.dgvMOGEPEND.SelectedRows.Item(0).Cells("MOGEMUNI").Value.ToString) & "-" & _
                                       Trim(Me.dgvMOGEPEND.SelectedRows.Item(0).Cells("MOGECLSE").Value.ToString) & "-" & _
                                       Trim(Me.dgvMOGEPEND.SelectedRows.Item(0).Cells("MOGECORR").Value.ToString) & "-" & _
                                       Trim(Me.dgvMOGEPEND.SelectedRows.Item(0).Cells("MOGEBARR").Value.ToString) & "-" & _
                                       Trim(Me.dgvMOGEPEND.SelectedRows.Item(0).Cells("MOGEMANZ").Value.ToString) & "-" & _
                                       Trim(Me.dgvMOGEPEND.SelectedRows.Item(0).Cells("MOGEPRED").Value.ToString) & "-" & _
                                       Trim(Me.dgvMOGEPEND.SelectedRows.Item(0).Cells("MOGEVIGE").Value.ToString)

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
                    stCarpetaABuscar = Trim(Me.dgvMOVIGEOG.SelectedRows.Item(0).Cells("MOGEMUNI").Value.ToString) & "-" & _
                                       Trim(Me.dgvMOVIGEOG.SelectedRows.Item(0).Cells("MOGECLSE").Value.ToString) & "-" & _
                                       Trim(Me.dgvMOVIGEOG.SelectedRows.Item(0).Cells("MOGECORR").Value.ToString) & "-" & _
                                       Trim(Me.dgvMOVIGEOG.SelectedRows.Item(0).Cells("MOGEBARR").Value.ToString) & "-" & _
                                       Trim(Me.dgvMOVIGEOG.SelectedRows.Item(0).Cells("MOGEMANZ").Value.ToString) & "-" & _
                                       Trim(Me.dgvMOVIGEOG.SelectedRows.Item(0).Cells("MOGEPRED").Value.ToString) & "-" & _
                                       Trim(Me.dgvMOVIGEOG.SelectedRows.Item(0).Cells("MOGEVIGE").Value.ToString)

                    ' consulta del grib movimientos pendientes
                ElseIf boPendientes = True Then

                    ' directorio expediente 
                    stCarpetaABuscar = Trim(Me.dgvMOGEPEND.SelectedRows.Item(0).Cells("MOGEMUNI").Value.ToString) & "-" & _
                                       Trim(Me.dgvMOGEPEND.SelectedRows.Item(0).Cells("MOGECLSE").Value.ToString) & "-" & _
                                       Trim(Me.dgvMOGEPEND.SelectedRows.Item(0).Cells("MOGECORR").Value.ToString) & "-" & _
                                       Trim(Me.dgvMOGEPEND.SelectedRows.Item(0).Cells("MOGEBARR").Value.ToString) & "-" & _
                                       Trim(Me.dgvMOGEPEND.SelectedRows.Item(0).Cells("MOGEMANZ").Value.ToString) & "-" & _
                                       Trim(Me.dgvMOGEPEND.SelectedRows.Item(0).Cells("MOGEPRED").Value.ToString) & "-" & _
                                       Trim(Me.dgvMOGEPEND.SelectedRows.Item(0).Cells("MOGEVIGE").Value.ToString)

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

        Dim inRegistros As Integer = Me.dgvMOGEPEND.RowCount

        Return inRegistros

    End Function
    Private Function fun_ContarTramitesGenerales() As Integer

        Dim inRegistros As Integer = Me.dgvMOVIGEOG.RowCount

        Return inRegistros

    End Function

#End Region

#Region "PROCEDIMIENTOS MOVIMIENTOS GEOGRAFICOS"

    Private Sub pro_ReconsultarMovimientosGeograficos()

        Try
            Dim objdatos As New cla_MOVIGEOG

            If vl_boCONSULTA = False Then

                Me.BindingSource_MOVIGEOG_1.DataSource = objdatos.fun_Consultar_MOVIGEOG(vl_boRECONSULTAR)

                Dim dt As New DataTable
                dt = objdatos.fun_Buscar_CONSULTA_MOVIGEOG_X_USUARIO(vp_cedula)

                If dt.Rows.Count > 0 Then
                    Me.dgvMOGEPEND.DataSource = objdatos.fun_Buscar_CONSULTA_MOVIGEOG_X_USUARIO(vp_cedula)
                    boExistenRegistrosPendientes = True
                Else
                    Me.dgvMOGEPEND.DataSource = objdatos.fun_Buscar_CONSULTA_MOVIGEOG_X_USUARIO(vp_cedula)
                    boExistenRegistrosPendientes = False
                End If

            ElseIf vl_boCONSULTA = True Then

                Me.BindingSource_MOVIGEOG_1.DataSource = objdatos.fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_MOVIGEOG(vp_inConsulta)

                Dim dt As New DataTable
                dt = objdatos.fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_MOVIGEOG(vp_inConsulta)

                If dt.Rows.Count > 0 Then

                    If Trim(vp_cedula) = Trim(dt.Rows(0).Item("MOGENUDO")) And Trim(dt.Rows(0).Item("MOGEESTA")) = "as" Then
                        Me.dgvMOGEPEND.DataSource = BindingSource_MOVIGEOG_1
                    Else
                        Me.dgvMOGEPEND.DataSource = New DataTable
                    End If

                End If
            End If

            Me.dgvMOVIGEOG.DataSource = BindingSource_MOVIGEOG_1
            Me.BindingNavigator_MOVIGEOG_1.BindingSource = BindingSource_MOVIGEOG_1

            '==================================================
            '*** CONFIGURA OBJETOS DEL FORMULARIO MAESTRO ***
            '==================================================

            Me.strBARRESTA.Items(2).Text = "Registros : " & Me.BindingSource_MOVIGEOG_1.Count

            Me.dgvMOVIGEOG.Columns("MOGEIDRE").HeaderText = "id"
            Me.dgvMOVIGEOG.Columns("MOGESECU").HeaderText = "Nro. Tramite"

            Me.dgvMOVIGEOG.Columns("MOGEDEPA").HeaderText = "Departamento"
            Me.dgvMOVIGEOG.Columns("MOGEMUNI").HeaderText = "Municipio"
            Me.dgvMOVIGEOG.Columns("MOGECORR").HeaderText = "Corregim."
            Me.dgvMOVIGEOG.Columns("MOGEBARR").HeaderText = "Barrio"
            Me.dgvMOVIGEOG.Columns("MOGEMANZ").HeaderText = "Manzana- Vereda"
            Me.dgvMOVIGEOG.Columns("MOGEPRED").HeaderText = "Predio"
            Me.dgvMOVIGEOG.Columns("CLSEDESC").HeaderText = "Sector"
            Me.dgvMOVIGEOG.Columns("MOGEVIGE").HeaderText = "Vigencia"
            Me.dgvMOVIGEOG.Columns("MOGEUSUA").HeaderText = "Usuario"
            Me.dgvMOVIGEOG.Columns("MOGEFEIN").HeaderText = "Fecha ingreso"
            Me.dgvMOVIGEOG.Columns("ESTADESC").HeaderText = "Estado"

            Me.dgvMOVIGEOG.Columns("MOGEIDRE").Visible = False
            Me.dgvMOVIGEOG.Columns("MOGEDEPA").Visible = False
            Me.dgvMOVIGEOG.Columns("MOGENUDO").Visible = False
            Me.dgvMOVIGEOG.Columns("MOGEFEAS").Visible = False
            Me.dgvMOVIGEOG.Columns("MOGECAAC").Visible = False
            Me.dgvMOVIGEOG.Columns("MOGECLVE").Visible = False
            Me.dgvMOVIGEOG.Columns("MOGEFFMU").Visible = False
            Me.dgvMOVIGEOG.Columns("MOGEOBSE").Visible = False
            Me.dgvMOVIGEOG.Columns("MOGEESTA").Visible = False
            Me.dgvMOVIGEOG.Columns("MOGECLSE").Visible = False

            Me.dgvMOVIGEOG.Columns("MOGESECU").Width = 60
            Me.dgvMOVIGEOG.Columns("MOGEUSUA").Width = 100

            If Me.dgvMOGEPEND.RowCount > 0 Then

                Me.dgvMOGEPEND.Columns("MOGEIDRE").HeaderText = "idre"
                Me.dgvMOGEPEND.Columns("MOGESECU").HeaderText = "Nro. Tramite"

                Me.dgvMOGEPEND.Columns("MOGEDEPA").HeaderText = "Departamento"
                Me.dgvMOGEPEND.Columns("MOGEMUNI").HeaderText = "Municipio"
                Me.dgvMOGEPEND.Columns("MOGECORR").HeaderText = "Corregim."
                Me.dgvMOGEPEND.Columns("MOGEBARR").HeaderText = "Barrio"
                Me.dgvMOGEPEND.Columns("MOGEMANZ").HeaderText = "Manzana- Vereda"
                Me.dgvMOGEPEND.Columns("MOGEPRED").HeaderText = "Predio"
                Me.dgvMOGEPEND.Columns("CLSEDESC").HeaderText = "Sector"
                Me.dgvMOGEPEND.Columns("MOGEVIGE").HeaderText = "Vigencia"
                Me.dgvMOGEPEND.Columns("MOGEUSUA").HeaderText = "Usuario"
                Me.dgvMOGEPEND.Columns("MOGEFEIN").HeaderText = "Fecha ingreso"
                Me.dgvMOGEPEND.Columns("ESTADESC").HeaderText = "Estado"

                Me.dgvMOGEPEND.Columns("MOGEIDRE").Visible = False
                Me.dgvMOGEPEND.Columns("MOGEDEPA").Visible = False
                Me.dgvMOGEPEND.Columns("MOGENUDO").Visible = False
                Me.dgvMOGEPEND.Columns("MOGEFEAS").Visible = False
                Me.dgvMOGEPEND.Columns("MOGECAAC").Visible = False
                Me.dgvMOGEPEND.Columns("MOGECLVE").Visible = False
                Me.dgvMOGEPEND.Columns("MOGEFFMU").Visible = False
                Me.dgvMOGEPEND.Columns("MOGEOBSE").Visible = False
                Me.dgvMOGEPEND.Columns("MOGEESTA").Visible = False
                Me.dgvMOGEPEND.Columns("MOGECLSE").Visible = False

                Me.dgvMOGEPEND.Columns("MOGESECU").Width = 60
                Me.dgvMOGEPEND.Columns("MOGEUSUA").Width = 100

            End If
            '==================================================
            '*** ASIGNA LOS PRIVILEGIOS DE LA BARRA DE MENU ***
            '==================================================

            Dim ContarRegistros As Integer = Me.BindingSource_MOVIGEOG_1.Count

            Dim boCONTAGRE As Boolean = False
            Dim boCONTMODI As Boolean = False
            Dim boCONTELIM As Boolean = False
            Dim boCONTCONS As Boolean = False
            Dim boCONTRECO As Boolean = False

            pro_Permiso_Barra_De_Menu_Formulario_SubFormulario(ContarRegistros, Trim(Me.BindingNavigator_MOVIGEOG_1.Name), boCONTAGRE, boCONTMODI, boCONTELIM, boCONTCONS, boCONTRECO)

            Me.cmdAGREGAR_MOVIGEOG.Enabled = boCONTAGRE
            Me.cmdMODIFICAR_MOVIGEOG.Enabled = boCONTMODI
            Me.cmdELIMINAR_MOVIGEOG.Enabled = boCONTELIM
            Me.cmdCONSULTAR_MOVIGEOG.Enabled = boCONTCONS
            Me.cmdRECONSULTAR_MOVIGEOG.Enabled = boCONTRECO

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub pro_ListaDeValoresMovimientosGeograficos()

        Try
            If Me.dgvMOVIGEOG.RowCount > 0 Then

                Me.txtMOGECAAC.Text = Trim(Me.dgvMOVIGEOG.SelectedRows.Item(0).Cells("MOGECAAC").Value.ToString)
                Me.txtMOGECLVE.Text = Trim(Me.dgvMOVIGEOG.SelectedRows.Item(0).Cells("MOGECLVE").Value.ToString)
                Me.txtMOGEFEAS.Text = Trim(Me.dgvMOVIGEOG.SelectedRows.Item(0).Cells("MOGEFEAS").Value.ToString)
                Me.txtMOGEFEFI.Text = Trim(Me.dgvMOVIGEOG.SelectedRows.Item(0).Cells("MOGEFFMU").Value.ToString)
                Me.txtMOGEOBSE.Text = Trim(Me.dgvMOVIGEOG.SelectedRows.Item(0).Cells("MOGEOBSE").Value.ToString)

                Me.lblMOGEUSUA.Text = CType(fun_Buscar_Lista_Valores_USUARIO(Me.dgvMOVIGEOG.SelectedRows.Item(0).Cells("MOGENUDO").Value.ToString), String)
                Me.lblMOGEMUNI.Text = CType(fun_Buscar_Lista_Valores_MUNICIPIO(Me.dgvMOVIGEOG.SelectedRows.Item(0).Cells("MOGEDEPA").Value.ToString, Me.dgvMOVIGEOG.SelectedRows.Item(0).Cells("MOGEMUNI").Value.ToString), String)
                Me.lblMOGEVIGE.Text = CType(fun_Buscar_Lista_Valores_VIGENCIA(Me.dgvMOVIGEOG.SelectedRows.Item(0).Cells("MOGEVIGE").Value.ToString), String)
                Me.lblMOGECLSE.Text = CType(fun_Buscar_Lista_Valores_CLASSECT(Me.dgvMOVIGEOG.SelectedRows.Item(0).Cells("MOGECLSE").Value.ToString), String)
                Me.lblMOGECAAC.Text = CType(fun_Buscar_Lista_Valores_CAUSACTO(Me.dgvMOVIGEOG.SelectedRows.Item(0).Cells("MOGECAAC").Value.ToString), String)
                Me.lblMOGECLVE.Text = CType(fun_Buscar_Lista_Valores_CLASVERS(Me.dgvMOVIGEOG.SelectedRows.Item(0).Cells("MOGECLVE").Value.ToString), String)

                Me.lblOBINCORR.Text = CType(fun_Buscar_Lista_Valores_CORREGIMIENTO(Me.dgvMOVIGEOG.SelectedRows.Item(0).Cells("MOGEDEPA").Value.ToString, Me.dgvMOVIGEOG.SelectedRows.Item(0).Cells("MOGEMUNI").Value.ToString, Me.dgvMOVIGEOG.SelectedRows.Item(0).Cells("MOGECLSE").Value.ToString, Me.dgvMOVIGEOG.SelectedRows.Item(0).Cells("MOGECORR").Value.ToString), String)

                If CInt(Me.dgvMOVIGEOG.SelectedRows.Item(0).Cells("MOGECLSE").Value.ToString) = 1 Then
                    Me.lblOBINBAVE.Text = CType(fun_Buscar_Lista_Valores_BARRIO(Me.dgvMOVIGEOG.SelectedRows.Item(0).Cells("MOGEDEPA").Value.ToString, Me.dgvMOVIGEOG.SelectedRows.Item(0).Cells("MOGEMUNI").Value.ToString, Me.dgvMOVIGEOG.SelectedRows.Item(0).Cells("MOGECLSE").Value.ToString, Me.dgvMOVIGEOG.SelectedRows.Item(0).Cells("MOGEBARR").Value.ToString, Me.dgvMOVIGEOG.SelectedRows.Item(0).Cells("MOGECORR").Value.ToString), String)
                ElseIf CInt(Me.dgvMOVIGEOG.SelectedRows.Item(0).Cells("MOGECLSE").Value.ToString) = 2 Then
                    Me.lblOBINBAVE.Text = CType(fun_Buscar_Lista_Valores_VEREDA(Me.dgvMOVIGEOG.SelectedRows.Item(0).Cells("MOGEDEPA").Value.ToString, Me.dgvMOVIGEOG.SelectedRows.Item(0).Cells("MOGEMUNI").Value.ToString, Me.dgvMOVIGEOG.SelectedRows.Item(0).Cells("MOGECLSE").Value.ToString, Me.dgvMOVIGEOG.SelectedRows.Item(0).Cells("MOGEMANZ").Value.ToString, Me.dgvMOVIGEOG.SelectedRows.Item(0).Cells("MOGECORR").Value.ToString), String)
                ElseIf CInt(Me.dgvMOVIGEOG.SelectedRows.Item(0).Cells("MOGECLSE").Value.ToString) = 3 Then
                    Me.lblOBINBAVE.Text = CType(fun_Buscar_Lista_Valores_BARRIO(Me.dgvMOVIGEOG.SelectedRows.Item(0).Cells("MOGEDEPA").Value.ToString, Me.dgvMOVIGEOG.SelectedRows.Item(0).Cells("MOGEMUNI").Value.ToString, Me.dgvMOVIGEOG.SelectedRows.Item(0).Cells("MOGECLSE").Value.ToString, Me.dgvMOVIGEOG.SelectedRows.Item(0).Cells("MOGEBARR").Value.ToString, Me.dgvMOVIGEOG.SelectedRows.Item(0).Cells("MOGECORR").Value.ToString), String)
                End If

                If Trim(Me.dgvMOVIGEOG.SelectedRows.Item(0).Cells("MOGEESTA").Value.ToString) = "fi" Then
                    Me.cmdFinalizar.Enabled = False
                Else
                    pro_PermisoControlDeComandos()
                End If

                Me.txtMOGENUTP.Text = fun_ContarTramitesPendientes()
                Me.txtMOGENUTG.Text = fun_ContarTramitesGenerales()

                vl_boPENDIENTES = False

                pro_ReconsultarTramitesOVC()
                pro_ListaDeValoresTramitesOVC()

                pro_ReconsultarMesaDeAyuda()
                pro_ListaDeValoresMesaDeAyuda()

                pro_ReconsultarPrediosNuevos()
                pro_ListaDeValoresPrediosNuevos()

                pro_ReconsultarDigitacionAlfanumerica()
                pro_ListaDeValoresDigitacionAlfanumerica()

                pro_ListadoArchivosDocumentosMovimientosGeograficos(False)
                pro_ListadoArchivosDocumentosTrabajoDeCampo(False)

            Else
                pro_LimpiarCamposMovimientoGeografico()
                pro_LimpiarTramitesOVC()
                pro_LimpiarMesaDeAyuda()
                pro_LimpiarPrediosNuevos()
                pro_LimpiarDigitacionOVC()

                Me.BindingNavigator_MOGETRAM_1.Enabled = False
                Me.BindingNavigator_MOGEMEAY_1.Enabled = False
                Me.BindingNavigator_MOGEPRNU_1.Enabled = False
                Me.BindingNavigator_MOGEDIGI_1.Enabled = False

            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub pro_ListaDeValoresMovimientosGeograficosPendientes()

        Try
            If Me.dgvMOGEPEND.RowCount > 0 Then

                Me.txtMOGECAAC.Text = Trim(Me.dgvMOGEPEND.SelectedRows.Item(0).Cells("MOGECAAC").Value.ToString)
                Me.txtMOGECLVE.Text = Trim(Me.dgvMOGEPEND.SelectedRows.Item(0).Cells("MOGECLVE").Value.ToString)
                Me.txtMOGEFEAS.Text = Trim(Me.dgvMOGEPEND.SelectedRows.Item(0).Cells("MOGEFEAS").Value.ToString)
                Me.txtMOGEFEFI.Text = Trim(Me.dgvMOGEPEND.SelectedRows.Item(0).Cells("MOGEFFMU").Value.ToString)
                Me.txtMOGEOBSE.Text = Trim(Me.dgvMOGEPEND.SelectedRows.Item(0).Cells("MOGEOBSE").Value.ToString)

                Me.lblMOGEUSUA.Text = CType(fun_Buscar_Lista_Valores_USUARIO(Me.dgvMOGEPEND.SelectedRows.Item(0).Cells("MOGENUDO").Value.ToString), String)
                Me.lblMOGEMUNI.Text = CType(fun_Buscar_Lista_Valores_MUNICIPIO(Me.dgvMOGEPEND.SelectedRows.Item(0).Cells("MOGEDEPA").Value.ToString, Me.dgvMOGEPEND.SelectedRows.Item(0).Cells("MOGEMUNI").Value.ToString), String)
                Me.lblMOGEVIGE.Text = CType(fun_Buscar_Lista_Valores_VIGENCIA(Me.dgvMOGEPEND.SelectedRows.Item(0).Cells("MOGEVIGE").Value.ToString), String)
                Me.lblMOGECLSE.Text = CType(fun_Buscar_Lista_Valores_CLASSECT(Me.dgvMOGEPEND.SelectedRows.Item(0).Cells("MOGECLSE").Value.ToString), String)
                Me.lblMOGECAAC.Text = CType(fun_Buscar_Lista_Valores_CAUSACTO(Me.dgvMOGEPEND.SelectedRows.Item(0).Cells("MOGECAAC").Value.ToString), String)
                Me.lblMOGECLVE.Text = CType(fun_Buscar_Lista_Valores_CLASVERS(Me.dgvMOGEPEND.SelectedRows.Item(0).Cells("MOGECLVE").Value.ToString), String)

                Me.lblOBINCORR.Text = CType(fun_Buscar_Lista_Valores_CORREGIMIENTO(Me.dgvMOGEPEND.SelectedRows.Item(0).Cells("MOGEDEPA").Value.ToString, Me.dgvMOGEPEND.SelectedRows.Item(0).Cells("MOGEMUNI").Value.ToString, Me.dgvMOGEPEND.SelectedRows.Item(0).Cells("MOGECLSE").Value.ToString, Me.dgvMOGEPEND.SelectedRows.Item(0).Cells("MOGECORR").Value.ToString), String)

                If CInt(Me.dgvMOVIGEOG.SelectedRows.Item(0).Cells("MOGECLSE").Value.ToString) = 1 Then
                    Me.lblOBINBAVE.Text = CType(fun_Buscar_Lista_Valores_BARRIO(Me.dgvMOGEPEND.SelectedRows.Item(0).Cells("MOGEDEPA").Value.ToString, Me.dgvMOGEPEND.SelectedRows.Item(0).Cells("MOGEMUNI").Value.ToString, Me.dgvMOGEPEND.SelectedRows.Item(0).Cells("MOGECLSE").Value.ToString, Me.dgvMOGEPEND.SelectedRows.Item(0).Cells("MOGEBARR").Value.ToString, Me.dgvMOGEPEND.SelectedRows.Item(0).Cells("MOGECORR").Value.ToString), String)
                ElseIf CInt(Me.dgvMOVIGEOG.SelectedRows.Item(0).Cells("MOGECLSE").Value.ToString) = 2 Then
                    Me.lblOBINBAVE.Text = CType(fun_Buscar_Lista_Valores_VEREDA(Me.dgvMOGEPEND.SelectedRows.Item(0).Cells("MOGEDEPA").Value.ToString, Me.dgvMOGEPEND.SelectedRows.Item(0).Cells("MOGEMUNI").Value.ToString, Me.dgvMOGEPEND.SelectedRows.Item(0).Cells("MOGECLSE").Value.ToString, Me.dgvMOGEPEND.SelectedRows.Item(0).Cells("MOGEMANZ").Value.ToString, Me.dgvMOGEPEND.SelectedRows.Item(0).Cells("MOGECORR").Value.ToString), String)
                ElseIf CInt(Me.dgvMOVIGEOG.SelectedRows.Item(0).Cells("MOGECLSE").Value.ToString) = 3 Then
                    Me.lblOBINBAVE.Text = CType(fun_Buscar_Lista_Valores_BARRIO(Me.dgvMOGEPEND.SelectedRows.Item(0).Cells("MOGEDEPA").Value.ToString, Me.dgvMOGEPEND.SelectedRows.Item(0).Cells("MOGEMUNI").Value.ToString, Me.dgvMOGEPEND.SelectedRows.Item(0).Cells("MOGECLSE").Value.ToString, Me.dgvMOGEPEND.SelectedRows.Item(0).Cells("MOGEBARR").Value.ToString, Me.dgvMOGEPEND.SelectedRows.Item(0).Cells("MOGECORR").Value.ToString), String)
                End If

                If Trim(Me.dgvMOVIGEOG.SelectedRows.Item(0).Cells("MOGEESTA").Value.ToString) = "fi" Then
                    Me.cmdFinalizar.Enabled = False
                Else
                    pro_PermisoControlDeComandos()
                End If

                Me.txtMOGENUTP.Text = fun_ContarTramitesPendientes()
                Me.txtMOGENUTG.Text = fun_ContarTramitesGenerales()

                vl_boPENDIENTES = True

                pro_ReconsultarTramitesOVC()
                pro_ListaDeValoresTramitesOVC()

                pro_ReconsultarMesaDeAyuda()
                pro_ListaDeValoresMesaDeAyuda()

                pro_ReconsultarPrediosNuevos()
                pro_ListaDeValoresPrediosNuevos()

                pro_ReconsultarDigitacionAlfanumerica()
                pro_ListaDeValoresDigitacionAlfanumerica()

                pro_ListadoArchivosDocumentosMovimientosGeograficos(True)

            Else
                pro_LimpiarCamposMovimientoGeografico()
                pro_LimpiarTramitesOVC()
                pro_LimpiarMesaDeAyuda()
                pro_LimpiarPrediosNuevos()
                pro_LimpiarDigitacionOVC()

                Me.BindingNavigator_MOGETRAM_1.Enabled = False
                Me.BindingNavigator_MOGEMEAY_1.Enabled = False
                Me.BindingNavigator_MOGEPRNU_1.Enabled = False
                Me.BindingNavigator_MOGEDIGI_1.Enabled = False

            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub pro_LimpiarCamposMovimientoGeografico()

        Me.lblMOGEUSUA.Text = ""
        Me.lblMOGEMUNI.Text = ""
        Me.lblMOGEVIGE.Text = ""
        Me.lblMOGECLSE.Text = ""
        Me.lblMOGECAAC.Text = ""
        Me.lblMOGECLVE.Text = ""
        Me.txtMOGECAAC.Text = ""
        Me.txtMOGECLVE.Text = ""
        Me.txtMOGEFEAS.Text = ""
        Me.txtMOGEFEFI.Text = ""
        Me.txtMOGEOBSE.Text = ""

        Me.lstLISTADO_DOCUMENTOS_MOVIGEOG.Items.Clear()
        Me.lstLISTADO_DOCUMENTOS_TRABCAMP.Items.Clear()

        Me.strBARRESTA.Items(2).Text = "Registros : 0"

    End Sub

    Private Sub pro_EjecutarBotonReasignar()

        Try
            If Me.dgvMOGEPEND.RowCount > 0 Then

                Me.TabMAESTRO1.SelectTab(TabPendientes)

                If MessageBox.Show("¿ Desea reasignar el tramite Nro. " & Me.dgvMOGEPEND.SelectedRows.Item(0).Cells("MOGESECU").Value.ToString() & " ? ", "Mensaje...", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then

                    Dim frm_Reasignar As New frm_reasignar_MOVIGEOG(Integer.Parse(Me.dgvMOGEPEND.SelectedRows.Item(0).Cells("MOGEIDRE").Value.ToString()), _
                                                                    Integer.Parse(Me.dgvMOGEPEND.SelectedRows.Item(0).Cells("MOGESECU").Value.ToString()))

                    frm_Reasignar.ShowDialog()

                    vl_boCONSULTA = True

                    pro_ReconsultarMovimientosGeograficos()
                    pro_ListaDeValoresMovimientosGeograficos()

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

                If Me.dgvMOGEPEND.RowCount > 0 Then

                    Me.TabMAESTRO1.SelectTab(TabPendientes)

                    If MessageBox.Show("¿ Desea ingresar una observación al tramite Nro. " & Me.dgvMOGEPEND.SelectedRows.Item(0).Cells("MOGESECU").Value.ToString() & " ? ", "Mensaje...", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then

                        Dim stObservacionNueva As String = InputBox("Ingrese la observación.", "Mensaje")

                        If Trim(stObservacionNueva) = "" Then
                            MessageBox.Show("Se requiere una observación.", "Mensaje...", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                            mod_MENSAJE.No_Se_Modifico_El_Registro_En_La_Base_De_Datos()
                        Else

                            Dim stRECLOBSE_ACTUAL As String = ""
                            Dim stRECLOBSE_NUEVA As String = Trim(stObservacionNueva.ToString.ToUpper)

                            Dim obMOGEGEOG As New cla_MOVIGEOG
                            Dim dtAJUSGEOG As New DataTable

                            dtAJUSGEOG = obMOGEGEOG.fun_Buscar_ID_MOVIGEOG(Me.dgvMOGEPEND.SelectedRows.Item(0).Cells("MOGEIDRE").Value.ToString())

                            If dtAJUSGEOG.Rows.Count > 0 Then
                                stRECLOBSE_ACTUAL = Trim(dtAJUSGEOG.Rows(0).Item("MOGEOBSE").ToString)
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
                            Dim inMOGEIDRE As Integer = Integer.Parse(Me.dgvMOGEPEND.SelectedRows.Item(0).Cells("MOGEIDRE").Value.ToString())

                            ' parametros de la consulta
                            Dim ParametrosConsulta As String = ""

                            ' Concatena la condicion de la consulta
                            ParametrosConsulta += "update MOVIGEOG "
                            ParametrosConsulta += "set MOGEOBSE = '" & stRECLOBSE_ACTUAL & "' "
                            ParametrosConsulta += "where MOGEIDRE = '" & inMOGEIDRE & "' "

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

                            vl_boCONSULTA = True

                            pro_ReconsultarMovimientosGeograficos()
                            pro_ListaDeValoresMovimientosGeograficosPendientes()

                            Me.TabMAESTRO3.SelectTab(TabObservaciones)

                        End If

                    End If
                Else
                    mod_MENSAJE.No_Existe_Un_Registro_Seleccionado()
                End If


            ElseIf MessageBox.Show("¿ Desea agregar una observación en Movimientos Generales ? ", "Mensaje...", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then

                If Me.dgvMOVIGEOG.RowCount > 0 Then

                    Me.TabMAESTRO1.SelectTab(TabGenerales)

                    If MessageBox.Show("¿ Desea ingresar una observación al tramite Nro. " & Me.dgvMOVIGEOG.SelectedRows.Item(0).Cells("MOGESECU").Value.ToString() & " ? ", "Mensaje...", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then

                        Dim stObservacionNueva As String = InputBox("Ingrese la observación.", "Mensaje")

                        If Trim(stObservacionNueva) = "" Then
                            MessageBox.Show("Se requiere una observación.", "Mensaje...", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                            mod_MENSAJE.No_Se_Modifico_El_Registro_En_La_Base_De_Datos()
                        Else

                            Dim stRECLOBSE_ACTUAL As String = ""
                            Dim stRECLOBSE_NUEVA As String = Trim(stObservacionNueva.ToString.ToUpper)

                            Dim obMOGEGEOG As New cla_MOVIGEOG
                            Dim dtAJUSGEOG As New DataTable

                            dtAJUSGEOG = obMOGEGEOG.fun_Buscar_ID_MOVIGEOG(Me.dgvMOVIGEOG.SelectedRows.Item(0).Cells("MOGEIDRE").Value.ToString())

                            If dtAJUSGEOG.Rows.Count > 0 Then
                                stRECLOBSE_ACTUAL = Trim(dtAJUSGEOG.Rows(0).Item("MOGEOBSE").ToString)
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
                            Dim inMOGEIDRE As Integer = Integer.Parse(Me.dgvMOVIGEOG.SelectedRows.Item(0).Cells("MOGEIDRE").Value.ToString())

                            ' parametros de la consulta
                            Dim ParametrosConsulta As String = ""

                            ' Concatena la condicion de la consulta
                            ParametrosConsulta += "update MOVIGEOG "
                            ParametrosConsulta += "set MOGEOBSE = '" & stRECLOBSE_ACTUAL & "' "
                            ParametrosConsulta += "where MOGEIDRE = '" & inMOGEIDRE & "' "

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

                            vl_boCONSULTA = True

                            pro_ReconsultarMovimientosGeograficos()
                            pro_ListaDeValoresMovimientosGeograficos()

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
            If Me.dgvMOGEPEND.RowCount > 0 Then

                Me.TabMAESTRO1.SelectTab(TabPendientes)

                If MessageBox.Show("¿ Desea finalizar el tramite Nro. " & Me.dgvMOGEPEND.SelectedRows.Item(0).Cells("MOGESECU").Value.ToString() & " ? ", "Mensaje...", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then

                    Dim stRECLOBSE_ACTUAL As String = ""
                    Dim stRECLOBSE_NUEVA As String = Trim(Me.txtMOGEOBSE.Text.ToString.ToUpper)

                    Dim obMOGEGEOG As New cla_MOVIGEOG
                    Dim dtAJUSGEOG As New DataTable

                    dtAJUSGEOG = obMOGEGEOG.fun_Buscar_ID_MOVIGEOG(Me.dgvMOGEPEND.SelectedRows.Item(0).Cells("MOGEIDRE").Value.ToString())

                    If dtAJUSGEOG.Rows.Count > 0 Then
                        stRECLOBSE_ACTUAL = Trim(dtAJUSGEOG.Rows(0).Item("MOGEOBSE").ToString)
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
                    Dim inMOGEIDRE As Integer = Integer.Parse(Me.dgvMOGEPEND.SelectedRows.Item(0).Cells("MOGEIDRE").Value.ToString())
                    Dim stMOGEESTA As String = "fi"
                    Dim stMOGEFFMU As String = fun_fecha()

                    'stMOGEFFMU = stMOGEFFMU.ToString.Replace("/", "-")

                    ' parametros de la consulta
                    Dim ParametrosConsulta As String = ""

                    ' Concatena la condicion de la consulta
                    ParametrosConsulta += "update MOVIGEOG "
                    ParametrosConsulta += "set MOGEESTA = '" & stMOGEESTA & "', "
                    ParametrosConsulta += "MOGEFFMU = '" & stMOGEFFMU & "', "
                    ParametrosConsulta += "MOGEOBSE = '" & stRECLOBSE_ACTUAL & "'  "
                    ParametrosConsulta += "where MOGEIDRE = '" & inMOGEIDRE & "'  "

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

                    vp_inConsulta = Me.dgvMOGEPEND.SelectedRows.Item(0).Cells("MOGEIDRE").Value.ToString()

                    pro_ReconsultarMovimientosGeograficos()
                    pro_ListaDeValoresMovimientosGeograficos()

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

            If tblRutas.Rows.Count > 0 AndAlso fun_VerificarCarpetaExistenteDocumentosMovimientosGeograficos(boPendientes) = True Then

                ' consulta del grib movimientos generales
                If boPendientes = False Then

                    stNewPath = Trim(tblRutas.Rows(0).Item("RUTARUTA")) & "\" & Trim(Me.dgvMOVIGEOG.SelectedRows.Item(0).Cells("MOGEMUNI").Value.ToString) & "-" & _
                                                                                Trim(Me.dgvMOVIGEOG.SelectedRows.Item(0).Cells("MOGECLSE").Value.ToString) & "-" & _
                                                                                Trim(Me.dgvMOVIGEOG.SelectedRows.Item(0).Cells("MOGECORR").Value.ToString) & "-" & _
                                                                                Trim(Me.dgvMOVIGEOG.SelectedRows.Item(0).Cells("MOGEBARR").Value.ToString) & "-" & _
                                                                                Trim(Me.dgvMOVIGEOG.SelectedRows.Item(0).Cells("MOGEMANZ").Value.ToString) & "-" & _
                                                                                Trim(Me.dgvMOVIGEOG.SelectedRows.Item(0).Cells("MOGEPRED").Value.ToString) & "-" & _
                                                                                Trim(Me.dgvMOVIGEOG.SelectedRows.Item(0).Cells("MOGEVIGE").Value.ToString)
                    ' consulta del grib movimientos pendientes
                ElseIf boPendientes = True Then

                    stNewPath = Trim(tblRutas.Rows(0).Item("RUTARUTA")) & "\" & Trim(Me.dgvMOGEPEND.SelectedRows.Item(0).Cells("MOGEMUNI").Value.ToString) & "-" & _
                                                                                Trim(Me.dgvMOGEPEND.SelectedRows.Item(0).Cells("MOGECLSE").Value.ToString) & "-" & _
                                                                                Trim(Me.dgvMOGEPEND.SelectedRows.Item(0).Cells("MOGECORR").Value.ToString) & "-" & _
                                                                                Trim(Me.dgvMOGEPEND.SelectedRows.Item(0).Cells("MOGEBARR").Value.ToString) & "-" & _
                                                                                Trim(Me.dgvMOGEPEND.SelectedRows.Item(0).Cells("MOGEMANZ").Value.ToString) & "-" & _
                                                                                Trim(Me.dgvMOGEPEND.SelectedRows.Item(0).Cells("MOGEPRED").Value.ToString) & "-" & _
                                                                                Trim(Me.dgvMOGEPEND.SelectedRows.Item(0).Cells("MOGEVIGE").Value.ToString)

                End If

                vl_stRutaDocumentosMovimientoGeografico = stNewPath

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

                    stNewPath = Trim(tblRutas.Rows(0).Item("RUTARUTA")) & "\" & Trim(Me.dgvMOVIGEOG.SelectedRows.Item(0).Cells("MOGEMUNI").Value.ToString) & "-" & _
                                                                                Trim(Me.dgvMOVIGEOG.SelectedRows.Item(0).Cells("MOGECLSE").Value.ToString) & "-" & _
                                                                                Trim(Me.dgvMOVIGEOG.SelectedRows.Item(0).Cells("MOGECORR").Value.ToString) & "-" & _
                                                                                Trim(Me.dgvMOVIGEOG.SelectedRows.Item(0).Cells("MOGEBARR").Value.ToString) & "-" & _
                                                                                Trim(Me.dgvMOVIGEOG.SelectedRows.Item(0).Cells("MOGEMANZ").Value.ToString) & "-" & _
                                                                                Trim(Me.dgvMOVIGEOG.SelectedRows.Item(0).Cells("MOGEPRED").Value.ToString) & "-" & _
                                                                                Trim(Me.dgvMOVIGEOG.SelectedRows.Item(0).Cells("MOGEVIGE").Value.ToString)
                    ' consulta del grib movimientos pendientes
                ElseIf boPendientes = True Then

                    stNewPath = Trim(tblRutas.Rows(0).Item("RUTARUTA")) & "\" & Trim(Me.dgvMOGEPEND.SelectedRows.Item(0).Cells("MOGEMUNI").Value.ToString) & "-" & _
                                                                                Trim(Me.dgvMOGEPEND.SelectedRows.Item(0).Cells("MOGECLSE").Value.ToString) & "-" & _
                                                                                Trim(Me.dgvMOGEPEND.SelectedRows.Item(0).Cells("MOGECORR").Value.ToString) & "-" & _
                                                                                Trim(Me.dgvMOGEPEND.SelectedRows.Item(0).Cells("MOGEBARR").Value.ToString) & "-" & _
                                                                                Trim(Me.dgvMOGEPEND.SelectedRows.Item(0).Cells("MOGEMANZ").Value.ToString) & "-" & _
                                                                                Trim(Me.dgvMOGEPEND.SelectedRows.Item(0).Cells("MOGEPRED").Value.ToString) & "-" & _
                                                                                Trim(Me.dgvMOGEPEND.SelectedRows.Item(0).Cells("MOGEVIGE").Value.ToString)

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
                    Me.BindingSource_MOGETRAM_1.DataSource = objdatos.fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_MOGETRAM(Me.dgvMOVIGEOG.SelectedRows.Item(0).Cells("MOGESECU").Value.ToString)
                Else
                    Me.BindingSource_MOGETRAM_1.DataSource = objdatos.fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_MOGETRAM(Me.dgvMOVIGEOG.SelectedRows.Item(0).Cells("MOGESECU").Value.ToString)
                End If
            Else
                If vl_boCONSULTA = False Then
                    Me.BindingSource_MOGETRAM_1.DataSource = objdatos.fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_MOGETRAM(Me.dgvMOGEPEND.SelectedRows.Item(0).Cells("MOGESECU").Value.ToString)
                Else
                    Me.BindingSource_MOGETRAM_1.DataSource = objdatos.fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_MOGETRAM(Me.dgvMOGEPEND.SelectedRows.Item(0).Cells("MOGESECU").Value.ToString)
                End If
            End If

            Me.dgvMOGETRAM.DataSource = Me.BindingSource_MOGETRAM_1
            Me.BindingNavigator_MOGETRAM_1.BindingSource = Me.BindingSource_MOGETRAM_1

            '==================================================
            '*** CONFIGURA OBJETOS DEL FORMULARIO MAESTRO ***
            '==================================================

            Me.dgvMOGETRAM.Columns("MGTRIDRE").HeaderText = "idre"
            Me.dgvMOGETRAM.Columns("MGTRSECU").HeaderText = "Secuencia"

            Me.dgvMOGETRAM.Columns("MGTRNUTR").HeaderText = "Nro. Tramite OVC"
            Me.dgvMOGETRAM.Columns("MGTRFETR").HeaderText = "Fecha Tramite OVC"
            Me.dgvMOGETRAM.Columns("MGTRNURE").HeaderText = "Nro. Resolución"
            Me.dgvMOGETRAM.Columns("MGTRFERE").HeaderText = "Fecha Resolución"
            Me.dgvMOGETRAM.Columns("MGTRFEFI").HeaderText = "Fecha Finalización"
            Me.dgvMOGETRAM.Columns("MGTROBSE").HeaderText = "Observación"

            Me.dgvMOGETRAM.Columns("MGTRIDRE").Visible = False
            Me.dgvMOGETRAM.Columns("MGTRSECU").Visible = False

            '==================================================
            '*** ASIGNA LOS PRIVILEGIOS DE LA BARRA DE MENU ***
            '==================================================

            Dim ContarRegistros As Integer = Me.BindingSource_MOGETRAM_1.Count

            Dim boCONTAGRE As Boolean = False
            Dim boCONTMODI As Boolean = False
            Dim boCONTELIM As Boolean = False
            Dim boCONTCONS As Boolean = False
            Dim boCONTRECO As Boolean = False

            pro_Permiso_Barra_De_Menu_Formulario_SubFormulario(ContarRegistros, Trim(Me.BindingNavigator_MOGETRAM_1.Name), boCONTAGRE, boCONTMODI, boCONTELIM, boCONTCONS, boCONTRECO)

            Me.cmdAGREGAR_MOGETRAM.Enabled = boCONTAGRE
            Me.cmdMODIFICAR_MOGETRAM.Enabled = boCONTMODI
            Me.cmdELIMINAR_MOGETRAM.Enabled = boCONTELIM
            Me.cmdCONSULTAR_MOGETRAM.Enabled = boCONTCONS
            Me.cmdRECONSULTAR_MOGETRAM.Enabled = boCONTRECO

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try
    End Sub
    Private Sub pro_ListaDeValoresTramitesOVC()

        Try
            If Me.dgvMOGETRAM.RowCount = 0 Then

                'pro_LimpiarTramitesOVC()

            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub pro_LimpiarTramitesOVC()

        'Me.dgvMOGETRAM.DataSource = New DataTable

    End Sub

#End Region

#Region "PROCEDIMIENTOS MESA DE AYUDA"

    Private Sub pro_ReconsultarMesaDeAyuda()

        Try
            Dim objdatos As New cla_MOGEMEAY

            If vl_boPENDIENTES = False Then
                If vl_boCONSULTA = False Then
                    Me.BindingSource_MOGEMEAY_1.DataSource = objdatos.fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_MOGEMEAY(Me.dgvMOVIGEOG.SelectedRows.Item(0).Cells("MOGESECU").Value.ToString)
                Else
                    Me.BindingSource_MOGEMEAY_1.DataSource = objdatos.fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_MOGEMEAY(Me.dgvMOVIGEOG.SelectedRows.Item(0).Cells("MOGESECU").Value.ToString)
                End If
            Else
                If vl_boCONSULTA = False Then
                    Me.BindingSource_MOGEMEAY_1.DataSource = objdatos.fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_MOGEMEAY(Me.dgvMOGEPEND.SelectedRows.Item(0).Cells("MOGESECU").Value.ToString)
                Else
                    Me.BindingSource_MOGEMEAY_1.DataSource = objdatos.fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_MOGEMEAY(Me.dgvMOGEPEND.SelectedRows.Item(0).Cells("MOGESECU").Value.ToString)
                End If
            End If

            Me.dgvMOGEMEAY.DataSource = Me.BindingSource_MOGEMEAY_1
            Me.BindingNavigator_MOGEMEAY_1.BindingSource = Me.BindingSource_MOGEMEAY_1

            '==================================================
            '*** CONFIGURA OBJETOS DEL FORMULARIO MAESTRO ***
            '==================================================

            Me.dgvMOGEMEAY.Columns("MGMAIDRE").HeaderText = "idre"
            Me.dgvMOGEMEAY.Columns("MGMASECU").HeaderText = "Secuencia"

            Me.dgvMOGEMEAY.Columns("MGMANURA").HeaderText = "Nro. Radicado"
            Me.dgvMOGEMEAY.Columns("MGMAFERA").HeaderText = "Fecha Radicado"
            Me.dgvMOGEMEAY.Columns("MGMANUCA").HeaderText = "Nro. Caso"
            Me.dgvMOGEMEAY.Columns("MGMAVERS").HeaderText = "Versión"
            Me.dgvMOGEMEAY.Columns("MGMAPEAS").HeaderText = "Personal Asignado"
            Me.dgvMOGEMEAY.Columns("MGMAOBSE").HeaderText = "Observación"

            Me.dgvMOGEMEAY.Columns("MGMAIDRE").Visible = False
            Me.dgvMOGEMEAY.Columns("MGMASECU").Visible = False

            '==================================================
            '*** ASIGNA LOS PRIVILEGIOS DE LA BARRA DE MENU ***
            '==================================================

            Dim ContarRegistros As Integer = Me.BindingSource_MOGEMEAY_1.Count

            Dim boCONTAGRE As Boolean = False
            Dim boCONTMODI As Boolean = False
            Dim boCONTELIM As Boolean = False
            Dim boCONTCONS As Boolean = False
            Dim boCONTRECO As Boolean = False

            pro_Permiso_Barra_De_Menu_Formulario_SubFormulario(ContarRegistros, Trim(Me.BindingNavigator_MOGEMEAY_1.Name), boCONTAGRE, boCONTMODI, boCONTELIM, boCONTCONS, boCONTRECO)

            Me.cmdAGREGAR_MOGEMEAY.Enabled = boCONTAGRE
            Me.cmdMODIFICAR_MOGEMEAY.Enabled = boCONTMODI
            Me.cmdELIMINAR_MOGEMEAY.Enabled = boCONTELIM
            Me.cmdCONSULTAR_MOGEMEAY.Enabled = boCONTCONS
            Me.cmdRECONSULTAR_MOGEMEAY.Enabled = boCONTRECO

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try
    End Sub
    Private Sub pro_ListaDeValoresMesaDeAyuda()

        Try
            If Me.dgvMOGEMEAY.RowCount = 0 Then

                pro_LimpiarMesaDeAyuda()

            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub pro_LimpiarMesaDeAyuda()

        'Me.dgvMOGEMEAY.DataSource = New DataTable

    End Sub

#End Region

#Region "PROCEDIMIENTOS PREDIOS NUEVOS"

    Private Sub pro_ReconsultarPrediosNuevos()

        Try
            Dim objdatos As New cla_MOGEPRNU

            If vl_boPENDIENTES = False Then
                If vl_boCONSULTA = False Then
                    Me.BindingSource_MOGEPRNU_1.DataSource = objdatos.fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_MOGEPRNU(Me.dgvMOVIGEOG.SelectedRows.Item(0).Cells("MOGESECU").Value.ToString)
                Else
                    Me.BindingSource_MOGEPRNU_1.DataSource = objdatos.fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_MOGEPRNU(Me.dgvMOVIGEOG.SelectedRows.Item(0).Cells("MOGESECU").Value.ToString)
                End If
            Else
                If vl_boCONSULTA = False Then
                    Me.BindingSource_MOGEPRNU_1.DataSource = objdatos.fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_MOGEPRNU(Me.dgvMOGEPEND.SelectedRows.Item(0).Cells("MOGESECU").Value.ToString)
                Else
                    Me.BindingSource_MOGEPRNU_1.DataSource = objdatos.fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_MOGEPRNU(Me.dgvMOGEPEND.SelectedRows.Item(0).Cells("MOGESECU").Value.ToString)
                End If
            End If

            Me.dgvMOGEPRNU.DataSource = Me.BindingSource_MOGEPRNU_1
            Me.BindingNavigator_MOGEPRNU_1.BindingSource = Me.BindingSource_MOGEPRNU_1

            '==================================================
            '*** CONFIGURA OBJETOS DEL FORMULARIO MAESTRO ***
            '==================================================

            Me.dgvMOGEPRNU.Columns("MGPNIDRE").HeaderText = "idre"
            Me.dgvMOGEPRNU.Columns("MGPNSECU").HeaderText = "Secuencia"

            Me.dgvMOGEPRNU.Columns("MGPNMUNI").HeaderText = "Municipio"
            Me.dgvMOGEPRNU.Columns("MGPNCORR").HeaderText = "Corregi."
            Me.dgvMOGEPRNU.Columns("MGPNBARR").HeaderText = "Barrio"
            Me.dgvMOGEPRNU.Columns("MGPNMANZ").HeaderText = "Manzana o Vereda"
            Me.dgvMOGEPRNU.Columns("MGPNPRED").HeaderText = "Predio"
            Me.dgvMOGEPRNU.Columns("MGPNCLSE").HeaderText = "Clase o Sector"
            Me.dgvMOGEPRNU.Columns("MGPNCAAC").HeaderText = "Causa de acto"
            Me.dgvMOGEPRNU.Columns("CAACDESC").HeaderText = "Descripción"
            Me.dgvMOGEPRNU.Columns("MGPNNUFI").HeaderText = "Nro. Ficha Municipio"
            Me.dgvMOGEPRNU.Columns("MGPNNUOV").HeaderText = "Nro. Ficha OVC"

            Me.dgvMOGEPRNU.Columns("CAACDESC").Width = 100

            Me.dgvMOGEPRNU.Columns("MGPNIDRE").Visible = False
            Me.dgvMOGEPRNU.Columns("MGPNSECU").Visible = False
            Me.dgvMOGEPRNU.Columns("MGPNEDIF").Visible = False
            Me.dgvMOGEPRNU.Columns("MGPNUNPR").Visible = False

            '==================================================
            '*** ASIGNA LOS PRIVILEGIOS DE LA BARRA DE MENU ***
            '==================================================

            Dim ContarRegistros As Integer = Me.BindingSource_MOGEPRNU_1.Count

            Dim boCONTAGRE As Boolean = False
            Dim boCONTMODI As Boolean = False
            Dim boCONTELIM As Boolean = False
            Dim boCONTCONS As Boolean = False
            Dim boCONTRECO As Boolean = False

            pro_Permiso_Barra_De_Menu_Formulario_SubFormulario(ContarRegistros, Trim(Me.BindingNavigator_MOGEPRNU_1.Name), boCONTAGRE, boCONTMODI, boCONTELIM, boCONTCONS, boCONTRECO)

            Me.cmdAGREGAR_MOGEPRNU.Enabled = boCONTAGRE
            Me.cmdMODIFICAR_MOGEPRNU.Enabled = boCONTMODI
            Me.cmdELIMINAR_MOGEPRNU.Enabled = boCONTELIM
            Me.cmdCONSULTAR_MOGEPRNU.Enabled = boCONTCONS
            Me.cmdRECONSULTAR_MOGEPRNU.Enabled = boCONTRECO

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try
    End Sub
    Private Sub pro_ListaDeValoresPrediosNuevos()

        Try
            If Me.dgvMOGEPRNU.RowCount = 0 Then

                'pro_LimpiarPrediosNuevos()

            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub pro_LimpiarPrediosNuevos()

        'Me.dgvMOGEPRNU.DataSource = New DataTable

    End Sub

#End Region

#Region "PROCEDIMIENTOS DIGITACION ALFANUMERICA"

    Private Sub pro_ReconsultarDigitacionAlfanumerica()

        Try
            Dim objdatos As New cla_MOGEDIGI

            If vl_boPENDIENTES = False Then
                If vl_boCONSULTA = False Then
                    Me.BindingSource_MOGEDIGI_1.DataSource = objdatos.fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_MOGEDIGI(Me.dgvMOVIGEOG.SelectedRows.Item(0).Cells("MOGESECU").Value.ToString)
                Else
                    Me.BindingSource_MOGEDIGI_1.DataSource = objdatos.fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_MOGEDIGI(Me.dgvMOVIGEOG.SelectedRows.Item(0).Cells("MOGESECU").Value.ToString)
                End If
            Else
                If vl_boCONSULTA = False Then
                    Me.BindingSource_MOGEDIGI_1.DataSource = objdatos.fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_MOGEDIGI(Me.dgvMOGEPEND.SelectedRows.Item(0).Cells("MOGESECU").Value.ToString)
                Else
                    Me.BindingSource_MOGEDIGI_1.DataSource = objdatos.fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_MOGEDIGI(Me.dgvMOGEPEND.SelectedRows.Item(0).Cells("MOGESECU").Value.ToString)
                End If
            End If

            Me.dgvMOGEDIGI.DataSource = Me.BindingSource_MOGEDIGI_1
            Me.BindingNavigator_MOGEDIGI_1.BindingSource = Me.BindingSource_MOGEDIGI_1

            '==================================================
            '*** CONFIGURA OBJETOS DEL FORMULARIO MAESTRO ***
            '==================================================

            Me.dgvMOGEDIGI.Columns("MGDIIDRE").HeaderText = "idre"
            Me.dgvMOGEDIGI.Columns("MGDISECU").HeaderText = "Secuencia"

            Me.dgvMOGEDIGI.Columns("MGDINUDO").HeaderText = "Nro. Documento"
            Me.dgvMOGEDIGI.Columns("USUANOMB").HeaderText = "Nombre(s)"
            Me.dgvMOGEDIGI.Columns("USUAPRAP").HeaderText = "Primer apellido"
            Me.dgvMOGEDIGI.Columns("USUASEAP").HeaderText = "Segundo apellido"
            Me.dgvMOGEDIGI.Columns("MGDIFEEN").HeaderText = "Fecha de asignación"
            Me.dgvMOGEDIGI.Columns("MGDIFEFI").HeaderText = "Fecha de finalización"
            Me.dgvMOGEDIGI.Columns("MGDIOBSE").HeaderText = "Observación"

            Me.dgvMOGEDIGI.Columns("MGDIIDRE").Visible = False
            Me.dgvMOGEDIGI.Columns("MGDISECU").Visible = False

            Me.dgvMOGEDIGI.Columns("MGDINUDO").Width = 50
            Me.dgvMOGEDIGI.Columns("USUANOMB").Width = 50
            Me.dgvMOGEDIGI.Columns("USUAPRAP").Width = 50
            Me.dgvMOGEDIGI.Columns("USUASEAP").Width = 50
            Me.dgvMOGEDIGI.Columns("MGDIFEEN").Width = 50
            Me.dgvMOGEDIGI.Columns("MGDIOBSE").Width = 200

            '==================================================
            '*** ASIGNA LOS PRIVILEGIOS DE LA BARRA DE MENU ***
            '==================================================

            Dim ContarRegistros As Integer = Me.BindingSource_MOGEDIGI_1.Count

            Dim boCONTAGRE As Boolean = False
            Dim boCONTMODI As Boolean = False
            Dim boCONTELIM As Boolean = False
            Dim boCONTCONS As Boolean = False
            Dim boCONTRECO As Boolean = False

            pro_Permiso_Barra_De_Menu_Formulario_SubFormulario(ContarRegistros, Trim(Me.BindingNavigator_MOGEDIGI_1.Name), boCONTAGRE, boCONTMODI, boCONTELIM, boCONTCONS, boCONTRECO)

            Me.cmdAGREGAR_MOGEDIGI.Enabled = boCONTAGRE
            Me.cmdMODIFICAR_MOGEDIGI.Enabled = boCONTMODI
            Me.cmdELIMINAR_MOGEDIGI.Enabled = boCONTELIM
            Me.cmdCONSULTAR_MOGEDIGI.Enabled = boCONTCONS
            Me.cmdRECONSULTAR_MOGEDIGI.Enabled = boCONTRECO

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try
    End Sub
    Private Sub pro_ListaDeValoresDigitacionAlfanumerica()

        Try
            If Me.dgvMOGEDIGI.RowCount = 0 Then

                pro_LimpiarDigitacionOVC()

            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub pro_LimpiarDigitacionOVC()

        'Me.dgvMOGEDIGI.DataSource = New DataTable

    End Sub

#End Region

#Region "MENU MOVIMIENTO GEOGRAFICO"

    Private Sub cmdAGREGAR_MOVIGEOG_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAGREGAR_MOVIGEOG.Click
        Try
            frm_insertar_MOVIGEOG.ShowDialog()

            If vp_inConsulta <> 0 Then
                vl_boCONSULTA = True

                pro_ReconsultarMovimientosGeograficos()
                pro_ListaDeValoresMovimientosGeograficos()

                If MessageBox.Show("¿ Desea agregar el tramite OVC ?", "Mensaje ...", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then
                    Me.TabMAESTRO1.SelectTab(TabGenerales)
                    Me.TabMAESTRO2.SelectTab(TabTramitesOVC)
                    Me.cmdAGREGAR_MOGETRAM.PerformClick()
                End If
            Else
                Me.TabMAESTRO1.SelectTab(TabGenerales)
                Me.TabMAESTRO2.SelectTab(TabTramitesOVC)

            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try
    End Sub
    Private Sub cmdMODIFICAR_MOVIGEOG_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdMODIFICAR_MOVIGEOG.Click
        Try
            Me.TabMAESTRO1.SelectTab(TabGenerales)

            If MessageBox.Show("¿ Desea modificar el tramite Nro. " & Me.dgvMOVIGEOG.SelectedRows.Item(0).Cells("MOGESECU").Value.ToString() & " ? ", "Mensaje...", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then

                Dim frm_modificar As New frm_modificar_MOVIGEOG(Integer.Parse(Me.dgvMOVIGEOG.SelectedRows.Item(0).Cells("MOGEIDRE").Value.ToString()), _
                                                                         Me.dgvMOVIGEOG.SelectedRows.Item(0).Cells("MOGENUDO").Value.ToString())
                frm_modificar.ShowDialog()

                If vp_inConsulta <> 0 Then
                    vl_boCONSULTA = True

                    pro_ReconsultarMovimientosGeograficos()
                    pro_ListaDeValoresMovimientosGeograficos()

                End If

            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try
    End Sub
    Private Sub cmdELIMINAR_MOVIGEOG_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdELIMINAR_MOVIGEOG.Click
        Try
            If MessageBox.Show("¿ Desea eliminar el registro seleccionado ? ", "Mensaje...", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then
                Dim objdatos As New cla_MOVIGEOG

                If objdatos.fun_Eliminar_IDRE_MOVIGEOG(Integer.Parse(Me.dgvMOVIGEOG.SelectedRows.Item(0).Cells(0).Value.ToString())) Then

                    vl_boCONSULTA = False
                    pro_LimpiarCamposMovimientoGeografico()
                    pro_ReconsultarMovimientosGeograficos()
                    pro_ListaDeValoresMovimientosGeograficos()
                Else
                    frm_INCO_eliminar_registro_padre_con_relación_de_registros_hijos.ShowDialog()
                End If

            End If
        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try
    End Sub
    Private Sub cmdCONSULTAR_MOVIGEOG_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCONSULTAR_MOVIGEOG.Click
        Try
            vp_inConsulta = 0

            frm_consultar_MOVIGEOG.ShowDialog()

            If vp_inConsulta > 0 Then
                vl_boCONSULTA = True
            Else
                vl_boCONSULTA = False
            End If

            pro_ReconsultarMovimientosGeograficos()
            pro_ListaDeValoresMovimientosGeograficos()

            Me.TabMAESTRO1.SelectTab(TabGenerales)
            Me.TabMAESTRO2.SelectTab(TabTramitesOVC)

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try
    End Sub
    Private Sub cmdRECONSULTAR_MOVIGEOG_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdRECONSULTAR_MOVIGEOG.Click
        Try
            vl_boRECONSULTAR = True
            vl_boCONSULTA = False
            pro_ReconsultarMovimientosGeograficos()
            pro_ListaDeValoresMovimientosGeograficos()

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try
    End Sub
    Private Sub cmdIMPORTAR_DOCUMENTOS_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdIMPORTAR_DOCUMENTOS.Click
        Try
            If MessageBox.Show("¿ Desea agregar archivos del tramite de Movimientos Pendientes ? ", "Mensaje...", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then

                If Me.dgvMOGEPEND.RowCount > 0 Then

                    Me.TabMAESTRO1.SelectTab(TabPendientes)

                    If MessageBox.Show("¿ Desea anexar archivos al tramite Nro. " & Me.dgvMOGEPEND.SelectedRows.Item(0).Cells("MOGESECU").Value.ToString() & " ? ", "Mensaje...", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then

                        Dim frm_inserta_archivo As New frm_insertar_archivo_MOVIGEOG(Me.dgvMOGEPEND.SelectedRows.Item(0).Cells("MOGEMUNI").Value.ToString(), _
                                                                                     Me.dgvMOGEPEND.SelectedRows.Item(0).Cells("MOGECORR").Value.ToString(), _
                                                                                     Me.dgvMOGEPEND.SelectedRows.Item(0).Cells("MOGEBARR").Value.ToString(), _
                                                                                     Me.dgvMOGEPEND.SelectedRows.Item(0).Cells("MOGEMANZ").Value.ToString(), _
                                                                                     Me.dgvMOGEPEND.SelectedRows.Item(0).Cells("MOGEPRED").Value.ToString(), _
                                                                                     Me.dgvMOGEPEND.SelectedRows.Item(0).Cells("MOGECLSE").Value.ToString(), _
                                                                                     Me.dgvMOGEPEND.SelectedRows.Item(0).Cells("MOGEVIGE").Value.ToString())
                        frm_inserta_archivo.ShowDialog()

                        pro_ListadoArchivosDocumentosMovimientosGeograficos(True)

                    End If

                Else
                    Me.TabMAESTRO1.SelectTab(TabPendientes)
                    mod_MENSAJE.No_Existe_Un_Registro_Seleccionado()
                End If

            ElseIf MessageBox.Show("¿ Desea agregar archivos del tramite de Movimientos Generales ? ", "Mensaje...", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then

                If Me.dgvMOVIGEOG.RowCount > 0 Then

                    Me.TabMAESTRO1.SelectTab(TabGenerales)

                    If MessageBox.Show("¿ Desea anexar archivos al tramite Nro. " & Me.dgvMOVIGEOG.SelectedRows.Item(0).Cells("MOGESECU").Value.ToString() & " ? ", "Mensaje...", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then

                        Dim frm_inserta_archivo As New frm_insertar_archivo_MOVIGEOG(Me.dgvMOVIGEOG.SelectedRows.Item(0).Cells("MOGEMUNI").Value.ToString(), _
                                                                                     Me.dgvMOVIGEOG.SelectedRows.Item(0).Cells("MOGECORR").Value.ToString(), _
                                                                                     Me.dgvMOVIGEOG.SelectedRows.Item(0).Cells("MOGEBARR").Value.ToString(), _
                                                                                     Me.dgvMOVIGEOG.SelectedRows.Item(0).Cells("MOGEMANZ").Value.ToString(), _
                                                                                     Me.dgvMOVIGEOG.SelectedRows.Item(0).Cells("MOGEPRED").Value.ToString(), _
                                                                                     Me.dgvMOVIGEOG.SelectedRows.Item(0).Cells("MOGECLSE").Value.ToString(), _
                                                                                     Me.dgvMOVIGEOG.SelectedRows.Item(0).Cells("MOGEVIGE").Value.ToString())
                        frm_inserta_archivo.ShowDialog()

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
        pro_ListaDeValoresMovimientosGeograficos()
    End Sub
    Private Sub ToolStripButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton2.Click
        pro_ListaDeValoresMovimientosGeograficos()
    End Sub
    Private Sub ToolStripButton3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton3.Click
        pro_ListaDeValoresMovimientosGeograficos()
    End Sub
    Private Sub ToolStripButton4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton4.Click
        pro_ListaDeValoresMovimientosGeograficos()
    End Sub

#End Region

#Region "MENU TRAMITE OVC"

    Private Sub cmdAGREGAR_MOGETRAM_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAGREGAR_MOGETRAM.Click

        Try
            If MessageBox.Show("¿ Desea agregar un registro del tramite de Movimientos Pendientes ? ", "Mensaje...", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then

                If Me.dgvMOGEPEND.RowCount > 0 Then

                    Me.TabMAESTRO1.SelectTab(TabPendientes)

                    If MessageBox.Show("¿ Desea agregar un tramite ovc, tramite Nro. " & Me.dgvMOGEPEND.SelectedRows.Item(0).Cells("MOGESECU").Value.ToString() & " ? ", "Mensaje...", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then

                        Dim frm_modificar As New frm_insertar_MOGETRAM(Integer.Parse(Me.dgvMOGEPEND.SelectedRows.Item(0).Cells("MOGESECU").Value.ToString()))
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

                If Me.dgvMOVIGEOG.RowCount > 0 Then

                    Me.TabMAESTRO1.SelectTab(TabGenerales)

                    If MessageBox.Show("¿ Desea agregar un tramite ovc, tramite Nro. " & Me.dgvMOVIGEOG.SelectedRows.Item(0).Cells("MOGESECU").Value.ToString() & " ? ", "Mensaje...", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then

                        Dim frm_modificar As New frm_insertar_MOGETRAM(Integer.Parse(Me.dgvMOVIGEOG.SelectedRows.Item(0).Cells("MOGESECU").Value.ToString()))
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
    Private Sub cmdMODIFICAR_MOGETRAM_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdMODIFICAR_MOGETRAM.Click

        Try
            If Me.dgvMOGETRAM.RowCount > 0 Then

                If MessageBox.Show("¿ Desea modificar el tramite ovc, tramite Nro. " & Me.dgvMOGETRAM.SelectedRows.Item(0).Cells("MGTRSECU").Value.ToString() & " ? ", "Mensaje...", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then

                    Dim frm_modificar As New frm_insertar_MOGETRAM(Integer.Parse(Me.dgvMOGETRAM.SelectedRows.Item(0).Cells("MGTRIDRE").Value.ToString()), _
                                                                   Integer.Parse(Me.dgvMOGETRAM.SelectedRows.Item(0).Cells("MGTRSECU").Value.ToString()))
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
    Private Sub cmdELIMINAR_MOGETRAM_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdELIMINAR_MOGETRAM.Click

        Try
            If MessageBox.Show("¿ Desea eliminar el registro seleccionado ? ", "Mensaje...", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then
                Dim objdatos As New cla_MOGETRAM

                If Me.dgvMOGETRAM.RowCount > 0 Then

                    If objdatos.fun_Eliminar_IDRE_MOGETRAM(Integer.Parse(Me.dgvMOGETRAM.SelectedRows.Item(0).Cells("MGTRIDRE").Value.ToString())) Then
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
    Private Sub cmdCONSULTAR_MOGETRAM_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCONSULTAR_MOGETRAM.Click

        Try
            vp_inConsulta = 0

            frm_consultar_MOVIGEOG.ShowDialog()

            If vp_inConsulta > 0 Then
                vl_boCONSULTA = True
            Else
                vl_boCONSULTA = False
            End If

            pro_ReconsultarMovimientosGeograficos()
            pro_ListaDeValoresMovimientosGeograficos()

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub cmdRECONSULTAR_MOGETRAM_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdRECONSULTAR_MOGETRAM.Click

        Try
            vl_boCONSULTA = False
            pro_ReconsultarMovimientosGeograficos()
            pro_ListaDeValoresMovimientosGeograficos()

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub

#End Region

#Region "MENU MESA DE AYUDA"

    Private Sub cmdAGREGAR_MOGEMEAY_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAGREGAR_MOGEMEAY.Click

        Try
            If MessageBox.Show("¿ Desea agregar un registro del tramite de Movimientos Pendientes ? ", "Mensaje...", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then

                If Me.dgvMOGEPEND.RowCount > 0 Then

                    Me.TabMAESTRO1.SelectTab(TabPendientes)

                    If MessageBox.Show("¿ Desea agregar la mesa de ayuda, tramite Nro. " & Me.dgvMOGEPEND.SelectedRows.Item(0).Cells("MOGESECU").Value.ToString() & " ? ", "Mensaje...", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then

                        Dim frm_modificar As New frm_insertar_MOGEMEAY(Integer.Parse(Me.dgvMOGEPEND.SelectedRows.Item(0).Cells("MOGESECU").Value.ToString()))
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

                If Me.dgvMOVIGEOG.RowCount > 0 Then

                    Me.TabMAESTRO1.SelectTab(TabGenerales)

                    If MessageBox.Show("¿ Desea agregar la mesa de ayuda, tramite Nro. " & Me.dgvMOVIGEOG.SelectedRows.Item(0).Cells("MOGESECU").Value.ToString() & " ? ", "Mensaje...", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then

                        Dim frm_modificar As New frm_insertar_MOGEMEAY(Integer.Parse(Me.dgvMOVIGEOG.SelectedRows.Item(0).Cells("MOGESECU").Value.ToString()))
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
    Private Sub cmdMODIFICAR_MOGEMEAY_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdMODIFICAR_MOGEMEAY.Click

        Try
            If Me.dgvMOGEMEAY.RowCount > 0 Then

                If MessageBox.Show("¿ Desea modificar la mesa de ayuda, tramite Nro. " & Me.dgvMOGEMEAY.SelectedRows.Item(0).Cells("MGMASECU").Value.ToString() & " ? ", "Mensaje...", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then

                    Dim frm_modificar As New frm_insertar_MOGEMEAY(Integer.Parse(Me.dgvMOGEMEAY.SelectedRows.Item(0).Cells("MGMAIDRE").Value.ToString()), _
                                                                   Integer.Parse(Me.dgvMOGEMEAY.SelectedRows.Item(0).Cells("MGMASECU").Value.ToString()))
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
    Private Sub cmdELIMINAR_MOGEMEAY_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdELIMINAR_MOGEMEAY.Click

        Try
            If MessageBox.Show("¿ Desea eliminar el registro seleccionado ? ", "Mensaje...", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then
                Dim objdatos As New cla_MOGEMEAY

                If Me.dgvMOGEMEAY.RowCount > 0 Then

                    If objdatos.fun_Eliminar_IDRE_MOGEMEAY(Integer.Parse(Me.dgvMOGEMEAY.SelectedRows.Item(0).Cells("MGMAIDRE").Value.ToString())) Then
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
    Private Sub cmdCONSULTAR_MOGEMEAY_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCONSULTAR_MOGEMEAY.Click

        Try
            vp_inConsulta = 0

            frm_consultar_MOVIGEOG.ShowDialog()

            If vp_inConsulta > 0 Then
                vl_boCONSULTA = True
            Else
                vl_boCONSULTA = False
            End If

            pro_ReconsultarMovimientosGeograficos()
            pro_ListaDeValoresMovimientosGeograficos()

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub cmdRECONSULTAR_MOGEMEAY_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdRECONSULTAR_MOGEMEAY.Click

        Try
            vl_boCONSULTA = False
            pro_ReconsultarMovimientosGeograficos()
            pro_ListaDeValoresMovimientosGeograficos()

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub

#End Region

#Region "MENU PREDIOS NUEVOS"

    Private Sub cmdAGREGAR_MOGEPRNU_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAGREGAR_MOGEPRNU.Click

        Try
            If MessageBox.Show("¿ Desea agregar un registro del tramite de Movimientos Pendientes ? ", "Mensaje...", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then

                If Me.dgvMOGEPEND.RowCount > 0 Then

                    Me.TabMAESTRO1.SelectTab(TabPendientes)

                    If MessageBox.Show("¿ Desea agregar predios nuevos, tramite Nro. " & Me.dgvMOGEPEND.SelectedRows.Item(0).Cells("MOGESECU").Value.ToString() & " ? ", "Mensaje...", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then

                        Dim frm_modificar As New frm_insertar_MOGEPRNU(Integer.Parse(Me.dgvMOGEPEND.SelectedRows.Item(0).Cells("MOGESECU").Value.ToString()))
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

                If Me.dgvMOVIGEOG.RowCount > 0 Then

                    Me.TabMAESTRO1.SelectTab(TabGenerales)

                    If MessageBox.Show("¿ Desea agregar predios nuevos, tramite Nro. " & Me.dgvMOVIGEOG.SelectedRows.Item(0).Cells("MOGESECU").Value.ToString() & " ? ", "Mensaje...", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then

                        Dim frm_modificar As New frm_insertar_MOGEPRNU(Integer.Parse(Me.dgvMOVIGEOG.SelectedRows.Item(0).Cells("MOGESECU").Value.ToString()))
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
    Private Sub cmdMODIFICAR_MOGEPRNU_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdMODIFICAR_MOGEPRNU.Click

        Try
            If Me.dgvMOGEPRNU.RowCount > 0 Then

                If MessageBox.Show("¿ Desea modificar predios nuevos, tramite Nro. " & Me.dgvMOGEPRNU.SelectedRows.Item(0).Cells("MGPNSECU").Value.ToString() & " ? ", "Mensaje...", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then

                    Dim frm_modificar As New frm_insertar_MOGEPRNU(Integer.Parse(Me.dgvMOGEPRNU.SelectedRows.Item(0).Cells("MGPNIDRE").Value.ToString()), _
                                                                   Integer.Parse(Me.dgvMOGEPRNU.SelectedRows.Item(0).Cells("MGPNSECU").Value.ToString()))
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
    Private Sub cmdELIMINAR_MOGEPRNU_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdELIMINAR_MOGEPRNU.Click

        Try
            If MessageBox.Show("¿ Desea eliminar el registro seleccionado ? ", "Mensaje...", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then
                Dim objdatos As New cla_MOGEPRNU

                If Me.dgvMOGEPRNU.RowCount > 0 Then

                    If objdatos.fun_Eliminar_IDRE_MOGEPRNU(Integer.Parse(Me.dgvMOGEPRNU.SelectedRows.Item(0).Cells("MGPNIDRE").Value.ToString())) Then
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
    Private Sub cmdCONSULTAR_MOGEPRNU_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCONSULTAR_MOGEPRNU.Click

        Try
            vp_inConsulta = 0

            frm_consultar_MOVIGEOG.ShowDialog()

            If vp_inConsulta > 0 Then
                vl_boCONSULTA = True
            Else
                vl_boCONSULTA = False
            End If

            pro_ReconsultarMovimientosGeograficos()
            pro_ListaDeValoresMovimientosGeograficos()

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub cmdRECONSULTAR_MOGEPRNU_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdRECONSULTAR_MOGEPRNU.Click

        Try
            vl_boCONSULTA = False
            pro_ReconsultarMovimientosGeograficos()
            pro_ListaDeValoresMovimientosGeograficos()

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub

#End Region

#Region "MENU DIGITACION ALFANUMERICA"

    Private Sub cmdAGREGAR_MOGEDIGI_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAGREGAR_MOGEDIGI.Click

        Try
            If MessageBox.Show("¿ Desea agregar un registro del tramite de Movimientos Pendientes ? ", "Mensaje...", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then

                If Me.dgvMOGEPEND.RowCount > 0 Then

                    Me.TabMAESTRO1.SelectTab(TabPendientes)

                    If MessageBox.Show("¿ Desea agregar digitación alfanumérica, tramite Nro. " & Me.dgvMOGEPEND.SelectedRows.Item(0).Cells("MOGESECU").Value.ToString() & " ? ", "Mensaje...", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then

                        Dim frm_modificar As New frm_insertar_MOGEDIGI(Integer.Parse(Me.dgvMOGEPEND.SelectedRows.Item(0).Cells("MOGESECU").Value.ToString()))
                        frm_modificar.ShowDialog()

                        vl_boPENDIENTES = True
                        vl_boCONSULTA = False

                        pro_ReconsultarDigitacionAlfanumerica()
                        pro_ListaDeValoresDigitacionAlfanumerica()

                        Me.TabMAESTRO2.SelectTab(TabDigitacion)

                    End If

                Else
                    Me.TabMAESTRO1.SelectTab(TabPendientes)
                    mod_MENSAJE.No_Existe_Un_Registro_Seleccionado()
                End If

            ElseIf MessageBox.Show("¿ Desea agregar un registro del tramite de Movimientos Generales ? ", "Mensaje...", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then

                If Me.dgvMOVIGEOG.RowCount > 0 Then

                    Me.TabMAESTRO1.SelectTab(TabGenerales)

                    If MessageBox.Show("¿ Desea agregar digitación alfanumérica, tramite Nro. " & Me.dgvMOVIGEOG.SelectedRows.Item(0).Cells("MOGESECU").Value.ToString() & " ? ", "Mensaje...", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then

                        Dim frm_modificar As New frm_insertar_MOGEDIGI(Integer.Parse(Me.dgvMOVIGEOG.SelectedRows.Item(0).Cells("MOGESECU").Value.ToString()))
                        frm_modificar.ShowDialog()

                        vl_boPENDIENTES = False
                        vl_boCONSULTA = False

                        pro_ReconsultarDigitacionAlfanumerica()
                        pro_ListaDeValoresDigitacionAlfanumerica()

                        Me.TabMAESTRO2.SelectTab(TabDigitacion)

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
    Private Sub cmdMODIFICAR_MOGEDIGI_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdMODIFICAR_MOGEDIGI.Click

        Try
            If Me.dgvMOGEDIGI.RowCount > 0 Then

                If MessageBox.Show("¿ Desea modificar digitacióon alfanumérica, tramite Nro. " & Me.dgvMOGEDIGI.SelectedRows.Item(0).Cells("MGDISECU").Value.ToString() & " ? ", "Mensaje...", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then

                    Dim frm_modificar As New frm_insertar_MOGEDIGI(Integer.Parse(Me.dgvMOGEDIGI.SelectedRows.Item(0).Cells("MGDIIDRE").Value.ToString()), _
                                                                   Integer.Parse(Me.dgvMOGEDIGI.SelectedRows.Item(0).Cells("MGDISECU").Value.ToString()), _
                                                                                 Me.dgvMOGEDIGI.SelectedRows.Item(0).Cells("MGDINUDO").Value.ToString())
                    frm_modificar.ShowDialog()
                    vl_boCONSULTA = False

                    pro_ReconsultarDigitacionAlfanumerica()
                    pro_ListaDeValoresDigitacionAlfanumerica()

                    Me.TabMAESTRO2.SelectTab(TabDigitacion)

                End If
            Else
                mod_MENSAJE.No_Existe_Un_Registro_Seleccionado()
            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub cmdELIMINAR_MOGEDIGI_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdELIMINAR_MOGEDIGI.Click

        Try
            If MessageBox.Show("¿ Desea eliminar el registro seleccionado ? ", "Mensaje...", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then
                Dim objdatos As New cla_MOGEDIGI

                If Me.dgvMOGEDIGI.RowCount > 0 Then

                    If objdatos.fun_Eliminar_IDRE_MOGEDIGI(Integer.Parse(Me.dgvMOGEDIGI.SelectedRows.Item(0).Cells("MGDIIDRE").Value.ToString())) Then
                        vl_boCONSULTA = False

                        pro_LimpiarDigitacionOVC()
                        pro_ReconsultarDigitacionAlfanumerica()
                        pro_ListaDeValoresDigitacionAlfanumerica()

                        Me.TabMAESTRO2.SelectTab(TabDigitacion)
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
    Private Sub cmdCONSULTAR_MOGEDIGI_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCONSULTAR_MOGEDIGI.Click

        Try
            vp_inConsulta = 0

            frm_consultar_MOVIGEOG.ShowDialog()

            If vp_inConsulta > 0 Then
                vl_boCONSULTA = True
            Else
                vl_boCONSULTA = False
            End If

            pro_ReconsultarMovimientosGeograficos()
            pro_ListaDeValoresMovimientosGeograficos()

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub cmdRECONSULTAR_MOGEDIGI_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdRECONSULTAR_MOGEDIGI.Click

        Try
            vl_boCONSULTA = False
            pro_ReconsultarMovimientosGeograficos()
            pro_ListaDeValoresMovimientosGeograficos()

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub

#End Region

#Region "FORMULARIO"

#Region "Load"

    Private Sub frm_MOVIGEOG_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        pro_ReconsultarMovimientosGeograficos()
        Me.strBARRESTA.Items(0).Text = "Movimiento geografico"

    End Sub

#End Region

#Region "GotFocus"

    Private Sub frm_MOVIGEOG_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.GotFocus

        If boExistenRegistrosPendientes = True Then
            pro_ListaDeValoresMovimientosGeograficosPendientes()
            Me.TabMAESTRO1.SelectTab(TabPendientes)

        ElseIf boExistenRegistrosPendientes = False Then
            pro_ListaDeValoresMovimientosGeograficos()
            Me.TabMAESTRO1.SelectTab(TabGenerales)

        End If

    End Sub
    Private Sub dgvMOVIGEOG_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvMOVIGEOG.GotFocus
        Me.strBARRESTA.Items(0).Text = Me.dgvMOVIGEOG.AccessibleDescription
    End Sub

#End Region

#Region "KeyDown"

    Private Sub dgvTRABCAMP_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgvMOVIGEOG.KeyDown
        '===============================================================================================
        '*** INSERTAR REGISTROS ***
        '===============================================================================================


        If e.KeyCode = Keys.F2 Then
            If Me.cmdAGREGAR_MOVIGEOG.Enabled = True Then
                Me.cmdAGREGAR_MOVIGEOG.PerformClick()
            Else
                mod_MENSAJE.Usuario_No_Tiene_Permiso_Para_Realizar_La_Operacion()
            End If
        End If

        '===============================================================================================
        'MODIFICAR REGISTROS
        '===============================================================================================

        If e.KeyCode = Keys.F3 Then
            If Me.cmdMODIFICAR_MOVIGEOG.Enabled = True Then
                Me.cmdMODIFICAR_MOVIGEOG.PerformClick()
            Else
                Dim ContarRegistros As Integer = Me.BindingSource_MOVIGEOG_1.Count

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
            If Me.cmdELIMINAR_MOVIGEOG.Enabled = True Then
                Me.cmdELIMINAR_MOVIGEOG.PerformClick()
            Else
                Dim ContarRegistros As Integer = Me.BindingSource_MOVIGEOG_1.Count

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
            If Me.cmdCONSULTAR_MOVIGEOG.Enabled = True Then
                Me.cmdCONSULTAR_MOVIGEOG.PerformClick()
            Else
                mod_MENSAJE.No_Existen_Registros_En_Base_De_Datos()
            End If
        End If

        '===============================================================================================
        '*** RECONSULTAR REGISTROS ***
        '===============================================================================================

        If e.KeyCode = Keys.F8 Then
            If Me.cmdCONSULTAR_MOVIGEOG.Enabled = True Then
                Me.cmdRECONSULTAR_MOVIGEOG.PerformClick()
            Else
                mod_MENSAJE.No_Existen_Registros_En_Base_De_Datos()
            End If
        End If

    End Sub

#End Region

#Region "KeyUp"

    Private Sub dgvMOVIGEOG_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgvMOVIGEOG.KeyUp
        If e.KeyCode = Keys.Down Or e.KeyCode = Keys.Up Or e.KeyCode = Keys.Enter Or e.KeyCode = Keys.PageUp Or e.KeyCode = Keys.PageDown Then
            pro_ListaDeValoresMovimientosGeograficos()
        End If
    End Sub
    Private Sub dgvMOGEPEND_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgvMOGEPEND.KeyUp
        If e.KeyCode = Keys.Down Or e.KeyCode = Keys.Up Or e.KeyCode = Keys.Enter Or e.KeyCode = Keys.PageUp Or e.KeyCode = Keys.PageDown Then
            pro_ListaDeValoresMovimientosGeograficosPendientes()
        End If
    End Sub

#End Region

#Region "CellClick"

    Private Sub dgvALUMPUBL_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvMOVIGEOG.CellClick
        pro_ListaDeValoresMovimientosGeograficos()
    End Sub
    Private Sub dgvMOGEPEND_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvMOGEPEND.CellClick
        pro_ListaDeValoresMovimientosGeograficosPendientes()
    End Sub

#End Region

#Region "DoubleClick"

    Private Sub lstLISTADO_DOCUMENTOS_MOVIGEOG_3_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles lstLISTADO_DOCUMENTOS_MOVIGEOG.DoubleClick

        Try
            If lstLISTADO_DOCUMENTOS_MOVIGEOG.SelectedIndex <> -1 Then

                Dim stArchivo As String = lstLISTADO_DOCUMENTOS_MOVIGEOG.SelectedItem
                Process.Start(vl_stRutaDocumentosMovimientoGeografico & "\" & stArchivo)
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