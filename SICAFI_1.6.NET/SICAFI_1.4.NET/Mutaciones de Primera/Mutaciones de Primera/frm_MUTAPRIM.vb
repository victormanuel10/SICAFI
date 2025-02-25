Imports REGLAS_DEL_NEGOCIO
Imports System
Imports System.IO
Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration
Imports System.Text

Public Class frm_MUTAPRIM

    '===================================
    '*** MUTACIONES DE PRIMERA CLASE ***
    '===================================

#Region "VARIABLES"

    Dim oLeer As New OpenFileDialog

    Dim boCONSULTA As Boolean = False
    Dim vl_stRutaDocumentosPDF As String = ""

    Dim vl_stRutaDocumentos As String = ""
    Dim vl_stRutaImagenes As String = ""
    Dim vl_stRutaResolucion As String = ""

    Private oEjecutar As New SqlCommand
    Private oConexion As New SqlConnection
    Private oAdapter As New SqlDataAdapter
    Private oReader As SqlDataReader
    Private ds As New DataSet
    Private dt As New DataTable

    Dim vl_inTotalRegistros As Integer
    Dim inProceso As Integer

    Dim vl_inResolucion As Integer = 0
    Dim vl_inVigencia As Integer = 0

    Dim vl_stRutaDestino As String = ""
    Dim vl_stRutaInicial As String = ""

#End Region

#Region "INSTANCIAR FORMULARIO"

    Private Shared frm_Instance = Nothing

    Public Shared Function instance() As frm_MUTAPRIM
        If frm_Instance Is Nothing OrElse frm_Instance.isdisposed = True Then
            frm_Instance = New frm_MUTAPRIM
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

            tblRutas = objRutas.fun_Buscar_CODIGO_MANT_RUTAS(24)

            If tblRutas.Rows.Count > 0 Then

                ' directorio pricipal
                stRuta = Trim(tblRutas.Rows(0).Item("RUTARUTA")) & "\"

                ' directorio expediente 
                stCarpetaABuscar = Trim(Me.dgvMUTAPRIM.SelectedRows.Item(0).Cells("MUPRVIGE").Value.ToString) & "-" & _
                                   Trim(Me.dgvMUTAPRIM.SelectedRows.Item(0).Cells("MUPRRESO").Value.ToString)

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
    Private Function fun_EstructurarFechasConGuion(ByVal stFechaSinGuion As String) As String

        Try
            Dim stFECHA As String = CStr(Trim(stFechaSinGuion))

            If Trim(stFECHA) <> "" Then

                Dim stDIA As String = CStr(Trim(stFechaSinGuion.ToString.Substring(0, 2).ToString))
                Dim stMES As String = CStr(Trim(stFechaSinGuion.ToString.Substring(2, 2).ToString))
                Dim stANO As String = CStr(Trim(stFechaSinGuion.ToString.Substring(4, 4).ToString))

                stFECHA = CDate(stDIA & "/" & stMES & "/" & stANO)

            ElseIf Trim(stFECHA) = "" Then

                stFECHA = CDate("01/01/2017")

            End If

            Return stFECHA

        Catch ex As Exception
            MessageBox.Show(Err.Description)
            Return Nothing
        End Try

    End Function
    Private Function fun_ObtineValorCompra(ByVal inFichaPredial As Integer, ByVal inVigencia As Integer) As Integer

        Try
            Dim inValorCompra As Integer = 0

            ' declara la clase
            Dim obMUTACIONES As New cla_MUTACIONES
            Dim dtMUTACIONES As New DataTable

            dtMUTACIONES = obMUTACIONES.fun_Buscar_MUTACIONES_X_NRO_FICHA_Y_VIGENCIA(inFichaPredial, inVigencia)

            If dtMUTACIONES.Rows.Count > 0 Then

                inValorCompra = CInt(dtMUTACIONES.Rows(0).Item("MUTAVACO").ToString)

            End If

            Return inValorCompra

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Function
    Private Function fun_ObtieneEntidadNotarial(ByVal stFalloEntidad As String) As String

        Try
            Dim stEntidadNotarial As String = ""

            If fun_Verificar_Dato_Numerico_Evento_Validated(Trim(stFalloEntidad)) = True Then
                stEntidadNotarial = "NOTARIA"
            Else
                stEntidadNotarial = "JUZGADO CIVIL MUNICIPAL"
            End If


            Return stEntidadNotarial

        Catch ex As Exception
            MessageBox.Show(Err.Description)
            Return Nothing
        End Try

    End Function
    Private Function fun_EstructurarDerechoDePropiedad(ByVal stDerechoPropiedad As String) As String

        Try
            Dim stDerecho As String = ""

            Dim stParte01 As String = Trim(stDerechoPropiedad.ToString.Substring(0, 3))
            Dim stParte02 As String = Trim(stDerechoPropiedad.ToString.Substring(3, 6))

            stDerecho = Trim(stParte01) & "." & Trim(stParte02)

            Return stDerecho

        Catch ex As Exception
            MessageBox.Show(Err.Description)
            Return Nothing
        End Try

    End Function
    Private Function fun_EstablecePredioGravable(ByVal inGravable As Integer) As Boolean

        Try
            Dim boGravable As Boolean = True

            If inGravable = 1 Then
                boGravable = True
            ElseIf inGravable = 2 Then
                boGravable = False
            End If

            Return boGravable

        Catch ex As Exception
            MessageBox.Show(Err.Description)
            Return Nothing
        End Try

    End Function
    Private Function fun_ObtieneCodigoFideicomiso(ByVal stNumeroDocumento As String, ByVal inTipoDocumento As Integer, ByVal stNombreFideicomiso As String) As String

        Try
            Dim stNumeroFideicomiso As String = ""

            If fun_Verificar_Dato_Numerico_Evento_Validated(Trim(stNumeroDocumento)) = True And inTipoDocumento = 3 Then
                If Trim(stNumeroDocumento).ToString.Length > 9 Then

                    ' declara la variable
                    Dim inLongitud As Integer = Trim(stNumeroDocumento).ToString.Length

                    ' almacena el fideicomiso
                    stNumeroFideicomiso = Trim(stNumeroDocumento).ToString.Substring(9, (inLongitud - 9))

                    ' instancia la clase
                    Dim obFIDEICOMISO As New cla_FIDEICOMISO
                    Dim dtFIDEICOMISO As New DataTable

                    ' consulta el registro
                    dtFIDEICOMISO = obFIDEICOMISO.fun_Buscar_CODIGO_MANT_FIDEICOMISO(Trim(stNumeroFideicomiso))

                    If dtFIDEICOMISO.Rows.Count = 0 Then

                        ' inserta el registro
                        obFIDEICOMISO.fun_Insertar_MANT_FIDEICOMISO(Trim(stNumeroFideicomiso), Trim(stNombreFideicomiso), "ac")

                    End If

                End If
            End If

            Return stNumeroFideicomiso

        Catch ex As Exception
            MessageBox.Show(Err.Description)
            Return Nothing
        End Try

    End Function
    Private Function fun_ObtieneNombreFideicomiso(ByVal stNumeroDocumento As String, ByVal inTipoDocumento As Integer, ByVal stNombreFide As String) As String

        Try
            Dim stNombreFideicomiso As String = ""

            If fun_Verificar_Dato_Numerico_Evento_Validated(Trim(stNumeroDocumento)) = True And inTipoDocumento = 3 Then
                If Trim(stNumeroDocumento).ToString.Length > 9 Then

                    stNombreFideicomiso = Trim(stNombreFide)

                End If
            End If

            Return stNombreFideicomiso

        Catch ex As Exception
            MessageBox.Show(Err.Description)
            Return Nothing
        End Try

    End Function
    Private Function fun_ObtieneDireccionPredio(ByVal inNumeroFicha) As String

        Try
            Dim stDireccionPredio As String = ""

            ' instancia la clase
            Dim obFICHPRED As New cla_FICHPRED
            Dim dtFICHPRED As New DataTable

            dtFICHPRED = obFICHPRED.fun_Consultar_FICHA_PREDIAL_X_NRO_FICHA_PREDIAL(inNumeroFicha)

            If dtFICHPRED.Rows.Count > 0 Then

                stDireccionPredio = Trim(dtFICHPRED.Rows(0).Item("FIPRDIRE").ToString)

            End If

            Return stDireccionPredio

        Catch ex As Exception
            MessageBox.Show(Err.Description)
            Return Nothing
        End Try

    End Function
    Private Function fun_ObtieneTipoDocumentoTercero(ByVal stNumeroDocumento As String) As Integer

        Try
            Dim inCodigo As Integer = 0

            ' instancia la clase
            Dim obTERCERO As New cla_TERCERO
            Dim dtTERCERO As New DataTable

            dtTERCERO = obTERCERO.fun_Buscar_CODIGO_TERCERO(Trim(stNumeroDocumento))

            If dtTERCERO.Rows.Count > 0 Then
                inCodigo = CInt(dtTERCERO.Rows(0).Item("TERCTIDO").ToString)
            Else
                inCodigo = 1
            End If

            Return inCodigo

        Catch ex As Exception
            MessageBox.Show(Err.Description)
            Return Nothing
        End Try

    End Function
    Private Function fun_ObtieneCalidadPropietarioTercero(ByVal stNumeroDocumento As String) As Integer

        Try
            Dim inCodigo As Integer = 0

            ' instancia la clase
            Dim obTERCERO As New cla_TERCERO
            Dim dtTERCERO As New DataTable

            dtTERCERO = obTERCERO.fun_Buscar_CODIGO_TERCERO(Trim(stNumeroDocumento))

            If dtTERCERO.Rows.Count > 0 Then
                inCodigo = CInt(dtTERCERO.Rows(0).Item("TERCCAPR").ToString)
            Else
                inCodigo = 1
            End If

            Return inCodigo

        Catch ex As Exception
            MessageBox.Show(Err.Description)
            Return Nothing
        End Try

    End Function
    Private Function fun_ObtieneSexoTercero(ByVal stNumeroDocumento As String) As Integer

        Try
            Dim inCodigo As Integer = 0

            ' instancia la clase
            Dim obTERCERO As New cla_TERCERO
            Dim dtTERCERO As New DataTable

            dtTERCERO = obTERCERO.fun_Buscar_CODIGO_TERCERO(Trim(stNumeroDocumento))

            If dtTERCERO.Rows.Count > 0 Then
                inCodigo = CInt(dtTERCERO.Rows(0).Item("TERCSEXO").ToString)
            Else
                inCodigo = 1
            End If

            Return inCodigo

        Catch ex As Exception
            MessageBox.Show(Err.Description)
            Return Nothing
        End Try

    End Function
    Private Function fun_ObtienePredioGravable(ByVal boGravable As Boolean) As String

        Try
            Dim stGravable As String = ""

            If CBool(boGravable) = True Then
                stGravable = "GRAVABLE"
            ElseIf CBool(boGravable) = False Then
                stGravable = "NO GRAVABLE"
            End If

            Return stGravable

        Catch ex As Exception
            MessageBox.Show(Err.Description)
            Return Nothing
        End Try

    End Function
    Private Function fun_ObtieneMatriculaDelPredio(ByVal stNroFichaPredial As String, ByVal stMatricula As String) As String

        Try
            Dim stMatriculaPredio As String = ""

            If Trim(stMatricula) = "" Then

                ' instancia la clase
                Dim obFIPRPROP As New cla_FIPRPROP
                Dim dtFIPRPROP As New DataTable

                dtFIPRPROP = obFIPRPROP.fun_Consultar_FIPRPROP_X_FICHA_PREDIAL(stNroFichaPredial)

                If dtFIPRPROP.Rows.Count > 0 Then

                    stMatricula = CStr(Trim(dtFIPRPROP.Rows(0).Item("FPPRMAIN").ToString))

                End If

            End If

            Return stMatricula

        Catch ex As Exception
            MessageBox.Show(Err.Description)
            Return Nothing
        End Try

    End Function
    Private Function fun_ObtieneCirculoRegistralDelPredio(ByVal stNroFichaPredial As String, ByVal stMatricula As String) As String

        Try
            Dim stCirculoRegistralPredio As String = ""

            If CInt(Trim(stMatricula).ToString.Length) >= 3 Then

                stCirculoRegistralPredio = stMatricula.ToString.Substring(0, 3)

            ElseIf Trim(stMatricula) = "" Then

                ' instancia la clase
                Dim obFIPRPROP As New cla_FIPRPROP
                Dim dtFIPRPROP As New DataTable

                dtFIPRPROP = obFIPRPROP.fun_Consultar_FIPRPROP_X_FICHA_PREDIAL(stNroFichaPredial)

                If dtFIPRPROP.Rows.Count > 0 Then

                    stCirculoRegistralPredio = CStr(Trim(dtFIPRPROP.Rows(0).Item("FPPRMAIN").ToString)).ToString.Substring(0, 3)

                End If

            End If

            Return stCirculoRegistralPredio

        Catch ex As Exception
            MessageBox.Show(Err.Description)
            Return Nothing
        End Try

    End Function
    Private Function fun_VerificarCarpetaExistenteDocumentos(ByVal stMUTAMUNI As String, _
                                                             ByVal inMUTACLSE As Integer, _
                                                             ByVal stMUTACORR As String, _
                                                             ByVal stMUTABARR As String, _
                                                             ByVal stMUTAMANZ As String, _
                                                             ByVal stMUTAPRED As String, _
                                                             ByVal stMUTAEDIF As String, _
                                                             ByVal stMUTAUNPR As String, _
                                                             ByVal inMUTAVIGE As Integer) As Boolean

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
                stCarpetaABuscar = Trim(stMUTAMUNI) & "-" & Trim(inMUTACLSE) & "-" & Trim(stMUTACORR) & "-" & Trim(stMUTABARR) & "-" & Trim(stMUTAMANZ) & "-" & Trim(stMUTAPRED) & "-" & Trim(stMUTAEDIF) & "-" & Trim(stMUTAUNPR) & "-" & Trim(inMUTAVIGE)

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
    Private Function fun_consultarRutaDestino(ByVal inMPMUNUFI As Integer, ByVal inMPMUESCR As Integer) As String

        Try
            Dim stRutaDestino As String = ""

            stRutaDestino = vl_stRutaDestino & "\" & inMPMUNUFI & "-" & inMPMUESCR & ".pdf"

            Return stRutaDestino

        Catch ex As Exception
            MessageBox.Show(Err.Description)
            Return ""
        End Try

    End Function

#End Region

#Region "PROCEDIMIENTOS MUTACIONES DE PRIMERA CLASE"

    Private Sub pro_ReconsultarMutacionesPrimeraClase()

        Try
            Dim objdatos As New cla_MUTAPRIM

            If boCONSULTA = False Then
                Me.BindingSource_MUTAPRIM_1.DataSource = objdatos.fun_Consultar_MUTAPRIM
            Else
                Me.BindingSource_MUTAPRIM_1.DataSource = objdatos.fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_MUTAPRIM(vp_inConsulta)
            End If

            Me.dgvMUTAPRIM.DataSource = BindingSource_MUTAPRIM_1
            Me.BindingNavigator_MUTAPRIM_1.BindingSource = BindingSource_MUTAPRIM_1

            '=================================================
            '*** CONFIGURA OBJETOS DEL FORMULARIO MAESTRO ***
            '=================================================

            Me.strBARRESTA.Items(2).Text = "Registros : " & Me.BindingSource_MUTAPRIM_1.Count

            Me.dgvMUTAPRIM.Columns("MUPRIDRE").HeaderText = "Id"
            Me.dgvMUTAPRIM.Columns("MUPRSECU").HeaderText = "Nro. Secuencia"

            Me.dgvMUTAPRIM.Columns("MUPRVIGE").HeaderText = "Vigencia"
            Me.dgvMUTAPRIM.Columns("TIREDESC").HeaderText = "Tipo de Resolución"
            Me.dgvMUTAPRIM.Columns("MUPRRESO").HeaderText = "Nro. Resolución"
            Me.dgvMUTAPRIM.Columns("MUPRSEMA").HeaderText = "Nro. Semana"
            Me.dgvMUTAPRIM.Columns("MUPRFEIN").HeaderText = "Fecha Ingreso"
            Me.dgvMUTAPRIM.Columns("MUPRUSUA").HeaderText = "Usuario"
            Me.dgvMUTAPRIM.Columns("ESTADESC").HeaderText = "Estado"

            Me.dgvMUTAPRIM.Columns("MUPRIDRE").Visible = False
            Me.dgvMUTAPRIM.Columns("MUPRTIRE").Visible = False
            Me.dgvMUTAPRIM.Columns("MUPRNUDO").Visible = False
            Me.dgvMUTAPRIM.Columns("MUPROBSE").Visible = False

            Me.dgvMUTAPRIM.Columns("TIREDESC").Width = 200

            '==================================================
            '*** ASIGNA LOS PRIVILEGIOS DE LA BARRA DE MENU ***
            '==================================================

            Dim ContarRegistros As Integer = Me.BindingSource_MUTAPRIM_1.Count

            Dim boCONTAGRE As Boolean = False
            Dim boCONTMODI As Boolean = False
            Dim boCONTELIM As Boolean = False
            Dim boCONTCONS As Boolean = False
            Dim boCONTRECO As Boolean = False

            pro_Permiso_Barra_De_Menu_Formulario_SubFormulario(ContarRegistros, Trim(Me.BindingNavigator_MUTAPRIM_1.Name), boCONTAGRE, boCONTMODI, boCONTELIM, boCONTCONS, boCONTRECO)

            Me.cmdAGREGAR_MUTAPRIM.Enabled = boCONTAGRE
            Me.cmdMODIFICAR_MUTAPRIM.Enabled = boCONTMODI
            Me.cmdELIMINAR_MUTAPRIM.Enabled = boCONTELIM
            Me.cmdCONSULTAR_MUTAPRIM.Enabled = True
            Me.cmdRECONSULTAR_MUTAPRIM.Enabled = boCONTRECO


        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub pro_ListaDeValoresMutacionesPrimeraClase()

        Try
            If Me.dgvMUTAPRIM.RowCount > 0 Then

                Dim objdatos As New cla_MUTAPRIM
                Dim tbldatos As New DataTable

                tbldatos = objdatos.fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_MUTAPRIM(CInt(Me.dgvMUTAPRIM.SelectedRows.Item(0).Cells("MUPRIDRE").Value.ToString()))

                If tbldatos.Rows.Count > 0 Then

                    Me.txtMUPROBSE.Text = Trim(Me.dgvMUTAPRIM.SelectedRows.Item(0).Cells("MUPROBSE").Value.ToString)

                End If

                pro_ReconsultarMutacion()
                pro_ListaDeValoresMutacion()

                pro_ReconsultarPropietarios()
                pro_ListaDeValoresPropietarios()

                pro_ControldeBindingNavigator()
                pro_LimpiarDocumentos()

                pro_ListadoArchivosDocumentos()

            Else
                pro_LimpiarCamposMutacionesPrimeraClase()
                pro_LimpiarCamposMutacion()
                pro_LimpiarCamposPropietarios()

                Me.BindingNavigator_MUPRMUTA_1.Enabled = False
                Me.BindingNavigator_MUPRPROP_1.Enabled = False

            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub pro_LimpiarCamposMutacionesPrimeraClase()

        Me.lstLISTADO_DOCUMENTOS_PDF.Items.Clear()

        Me.txtMUPROBSE.Text = ""

        Me.strBARRESTA.Items(2).Text = "Registros : 0"

    End Sub
    Private Sub pro_EjecutarBotonObservaciones()

        Try
            If Me.dgvMUTAPRIM.RowCount > 0 Then

                If MessageBox.Show("¿ Desea ingresar una observación a la secuencia Nro. " & Me.dgvMUTAPRIM.SelectedRows.Item(0).Cells("MUPRSECU").Value.ToString() & " ? ", "Mensaje...", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then

                    Dim stObservacionNueva As String = InputBox("Ingrese la observación.", "Mensaje")

                    If Trim(stObservacionNueva) = "" Then
                        MessageBox.Show("Se requiere una observación.", "Mensaje...", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                        mod_MENSAJE.No_Se_Modifico_El_Registro_En_La_Base_De_Datos()
                    Else

                        Dim stREMUOBSE_ACTUAL As String = ""
                        Dim stREMUOBSE_NUEVA As String = Trim(stObservacionNueva.ToString.ToUpper)

                        Dim obMOGEGEOG As New cla_MUTAPRIM
                        Dim dtAJUSGEOG As New DataTable

                        dtAJUSGEOG = obMOGEGEOG.fun_Buscar_ID_MUTAPRIM(Me.dgvMUTAPRIM.SelectedRows.Item(0).Cells("MUPRIDRE").Value.ToString())

                        If dtAJUSGEOG.Rows.Count > 0 Then
                            stREMUOBSE_ACTUAL = Trim(dtAJUSGEOG.Rows(0).Item("MUPROBSE").ToString)
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
                        Dim inMOGEIDRE As Integer = Integer.Parse(Me.dgvMUTAPRIM.SelectedRows.Item(0).Cells("MUPRIDRE").Value.ToString())

                        ' parametros de la consulta
                        Dim ParametrosConsulta As String = ""

                        ' Concatena la condicion de la consulta
                        ParametrosConsulta += "update MUTAPRIM "
                        ParametrosConsulta += "set MUPROBSE = '" & stREMUOBSE_ACTUAL & "' "
                        ParametrosConsulta += "where MUPRIDRE = '" & inMOGEIDRE & "' "

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

                        pro_ReconsultarMutacionesPrimeraClase()
                        pro_ListaDeValoresMutacionesPrimeraClase()

                        Me.TabMAESTRO_1.SelectTab(TabObservaciones)

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

            tblRutas = objRutas.fun_Buscar_CODIGO_MANT_RUTAS(24)

            If tblRutas.Rows.Count > 0 AndAlso fun_VerificarCarpetaExistenteDocumentos() = True Then

                stNewPath = Trim(tblRutas.Rows(0).Item("RUTARUTA")) & "\" & Trim(Me.dgvMUTAPRIM.SelectedRows.Item(0).Cells("MUPRVIGE").Value.ToString) & "-" & _
                                                                            Trim(Me.dgvMUTAPRIM.SelectedRows.Item(0).Cells("MUPRRESO").Value.ToString)

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
    Private Sub pro_ControldeBindingNavigator()

        If Me.dgvMUTAPRIM.RowCount > 0 Then

            Me.BindingNavigator_MUPRMUTA_1.Enabled = True
            Me.BindingNavigator_MUPRPROP_1.Enabled = True

        Else
            Me.BindingNavigator_MUPRMUTA_1.Enabled = False
            Me.BindingNavigator_MUPRPROP_1.Enabled = False

        End If

    End Sub
    Private Sub pro_LimpiarDocumentos()

        Me.lstLISTADO_DOCUMENTOS_PDF.Items.Clear()

    End Sub

#End Region

#Region "PROCEDIMIENTOS MUTACION"

    Private Sub pro_ReconsultarMutacion()

        Try
            Dim objdatos As New cla_MUPRMUTA

            If boCONSULTA = False Then
                Me.BindingSource_MUPRMUTA_1.DataSource = objdatos.fun_Buscar_SECU_X_CONSULTA_PARAMETRIZADA_MUPRMUTA(Me.dgvMUTAPRIM.SelectedRows.Item(0).Cells("MUPRSECU").Value.ToString())
            Else
                Me.BindingSource_MUPRMUTA_1.DataSource = objdatos.fun_Buscar_SECU_X_CONSULTA_PARAMETRIZADA_MUPRMUTA(Me.dgvMUTAPRIM.SelectedRows.Item(0).Cells("MUPRSECU").Value.ToString())
            End If

            Me.dgvMUPRMUTA.DataSource = BindingSource_MUPRMUTA_1
            Me.BindingNavigator_MUPRMUTA_1.BindingSource = BindingSource_MUPRMUTA_1

            '=================================================
            '*** CONFIGURA OBJETOS DEL FORMULARIO MAESTRO ***
            '=================================================

            Me.dgvMUPRMUTA.Columns("MPMUNUFI").HeaderText = "Nro. Ficha Municipio"
            Me.dgvMUPRMUTA.Columns("MPMUNURE").HeaderText = "Nro. Registro"
            Me.dgvMUPRMUTA.Columns("NOVEDESC").HeaderText = "Novedad"
            Me.dgvMUPRMUTA.Columns("MPMUANDO").HeaderText = "Anexo Documento"
            Me.dgvMUPRMUTA.Columns("MPMUNOVC").HeaderText = "Nro. Ficha OVC"
            Me.dgvMUPRMUTA.Columns("MPMUMUNI").HeaderText = "Municipio"
            Me.dgvMUPRMUTA.Columns("MPMUCORR").HeaderText = "Correg."
            Me.dgvMUPRMUTA.Columns("MPMUBARR").HeaderText = "Barrio"
            Me.dgvMUPRMUTA.Columns("MPMUMANZ").HeaderText = "Manzana / Vereda"
            Me.dgvMUPRMUTA.Columns("MPMUPRED").HeaderText = "Predio"
            Me.dgvMUPRMUTA.Columns("MPMUEDIF").HeaderText = "Edificio"
            Me.dgvMUPRMUTA.Columns("MPMUUNPR").HeaderText = "Unidad Predial"
            Me.dgvMUPRMUTA.Columns("CLSEDESC").HeaderText = "Clase o Sector"
            Me.dgvMUPRMUTA.Columns("MPMUCAAC").HeaderText = "Causa del Acto"
            Me.dgvMUPRMUTA.Columns("ESTADESC").HeaderText = "Estado"

            Me.dgvMUPRMUTA.Columns("MPMUIDRE").Visible = False
            Me.dgvMUPRMUTA.Columns("MPMUSECU").Visible = False
            Me.dgvMUPRMUTA.Columns("MPMUVIGE").Visible = False
            Me.dgvMUPRMUTA.Columns("MPMUTIRE").Visible = False
            Me.dgvMUPRMUTA.Columns("MPMURESO").Visible = False
            Me.dgvMUPRMUTA.Columns("MPMUNOVE").Visible = False
            Me.dgvMUPRMUTA.Columns("MPMUCLSE").Visible = False

            Me.dgvMUPRMUTA.Columns("MPMUNUFI").DefaultCellStyle.Format = "n"
            Me.dgvMUPRMUTA.Columns("MPMUNOVC").DefaultCellStyle.Format = "n"

            '==================================================
            '*** ASIGNA LOS PRIVILEGIOS DE LA BARRA DE MENU ***
            '==================================================

            Dim ContarRegistros As Integer = Me.BindingSource_MUPRMUTA_1.Count

            Dim boCONTAGRE As Boolean = False
            Dim boCONTMODI As Boolean = False
            Dim boCONTELIM As Boolean = False
            Dim boCONTCONS As Boolean = False
            Dim boCONTRECO As Boolean = False

            pro_Permiso_Barra_De_Menu_Formulario_SubFormulario(ContarRegistros, Trim(Me.BindingNavigator_MUPRMUTA_1.Name), boCONTAGRE, boCONTMODI, boCONTELIM, boCONTCONS, boCONTRECO)

            Me.cmdAGREGAR_MUPRMUTA.Enabled = boCONTAGRE
            Me.cmdMODIFICAR_MUPRMUTA.Enabled = boCONTMODI
            Me.cmdELIMINAR_MUPRMUTA.Enabled = boCONTELIM
            Me.cmdCONSULTAR_MUPRMUTA.Enabled = boCONTCONS
            Me.cmdRECONSULTAR_MUPRMUTA.Enabled = boCONTRECO

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub pro_ListaDeValoresMutacion()

        Try

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub pro_LimpiarCamposMutacion()

        Try
            Me.dgvMUPRMUTA.DataSource = New DataTable

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub

#End Region

#Region "PROCEDIMIENTOS PROPIETARIOS"

    Private Sub pro_ReconsultarPropietarios()

        Try
            Dim objdatos As New cla_MUPRPROP

            If boCONSULTA = False Then
                Me.BindingSource_MUPRPROP_1.DataSource = objdatos.fun_Buscar_SECU_X_CONSULTA_PARAMETRIZADA_MUPRPROP(Me.dgvMUTAPRIM.SelectedRows.Item(0).Cells("MUPRSECU").Value.ToString())
            Else
                Me.BindingSource_MUPRPROP_1.DataSource = objdatos.fun_Buscar_SECU_X_CONSULTA_PARAMETRIZADA_MUPRPROP(Me.dgvMUTAPRIM.SelectedRows.Item(0).Cells("MUPRSECU").Value.ToString())
            End If

            Me.dgvMUPRPROP.DataSource = BindingSource_MUPRPROP_1
            Me.BindingNavigator_MUPRPROP_1.BindingSource = BindingSource_MUPRPROP_1

            '=================================================
            '*** CONFIGURA OBJETOS DEL FORMULARIO MAESTRO ***
            '=================================================

            Me.dgvMUPRPROP.Columns("MPPRNUFI").HeaderText = "Nro. Ficha Municipio"
            Me.dgvMUPRPROP.Columns("MPPRNURE").HeaderText = "Nro. Registro"
            Me.dgvMUPRPROP.Columns("MPPRNUDO").HeaderText = "Nro. Documento"
            Me.dgvMUPRPROP.Columns("MPPRNOVC").HeaderText = "Nro. Ficha OVC"
            Me.dgvMUPRPROP.Columns("TIDODESC").HeaderText = "Tipo Documento"
            Me.dgvMUPRPROP.Columns("MPPRMAIN").HeaderText = "Matricula Inmobiliaria"
            Me.dgvMUPRPROP.Columns("MPPRCIRE").HeaderText = "Circulo Registral"
            Me.dgvMUPRPROP.Columns("MPPRESCR").HeaderText = "Escritura"
            Me.dgvMUPRPROP.Columns("MPPRFEES").HeaderText = "Fecha Escritura"
            Me.dgvMUPRPROP.Columns("MPPRVACO").HeaderText = "Valor Compra "
            Me.dgvMUPRPROP.Columns("MPPRENTI").HeaderText = "Entidad Notarial"
            Me.dgvMUPRPROP.Columns("MPPRDENO").HeaderText = "Departamento"
            Me.dgvMUPRPROP.Columns("MPPRMUNO").HeaderText = "Municipio"
            Me.dgvMUPRPROP.Columns("MPPRFAEN").HeaderText = "Fallo Entidad"
            Me.dgvMUPRPROP.Columns("MPPRDERE").HeaderText = "Derecho"
            Me.dgvMUPRPROP.Columns("MPPRGRAV").HeaderText = "Gravable"
            Me.dgvMUPRPROP.Columns("MPPRFERE").HeaderText = "Fecha Registro"
            Me.dgvMUPRPROP.Columns("MPPRLIRE").HeaderText = "Libro Registro"
            Me.dgvMUPRPROP.Columns("MPPRTORE").HeaderText = "Tomo Registro"
            Me.dgvMUPRPROP.Columns("MPPRPARE").HeaderText = "Pagina Registro "
            Me.dgvMUPRPROP.Columns("MPPRCOFI").HeaderText = "Código Fideicomiso"
            Me.dgvMUPRPROP.Columns("MPPRNOFI").HeaderText = "Nombre Fideicomiso"
            Me.dgvMUPRPROP.Columns("MPPRPRNO").HeaderText = "Primer Nombre"
            Me.dgvMUPRPROP.Columns("MPPRSENO").HeaderText = "Segundo Nombre"
            Me.dgvMUPRPROP.Columns("MPPRPRAP").HeaderText = "Primer Apellido"
            Me.dgvMUPRPROP.Columns("MPPRSEAP").HeaderText = "Segundo Apellido"
            Me.dgvMUPRPROP.Columns("MPPRRASO").HeaderText = "Razón Social"
            Me.dgvMUPRPROP.Columns("MPPRTELE").HeaderText = "Teléfono"
            Me.dgvMUPRPROP.Columns("MPPRCOEL").HeaderText = "Correo Electrónico"
            Me.dgvMUPRPROP.Columns("MPPRCELU").HeaderText = "Celular"
            Me.dgvMUPRPROP.Columns("MPPRDIRE").HeaderText = "Dirección"
            Me.dgvMUPRPROP.Columns("MPPRSICO").HeaderText = "Sigla Comercial"
            Me.dgvMUPRPROP.Columns("CAPRDESC").HeaderText = "Calidad Propietario"
            Me.dgvMUPRPROP.Columns("SEXODESC").HeaderText = "Sexo"
            Me.dgvMUPRPROP.Columns("ESTADESC").HeaderText = "Estado"

            Me.dgvMUPRPROP.Columns("MPPRIDRE").Visible = False
            Me.dgvMUPRPROP.Columns("MPPRSECU").Visible = False
            Me.dgvMUPRPROP.Columns("MPPRVIGE").Visible = False
            Me.dgvMUPRPROP.Columns("MPPRTIRE").Visible = False
            Me.dgvMUPRPROP.Columns("MPPRRESO").Visible = False
            Me.dgvMUPRPROP.Columns("MPPRTIDO").Visible = False
            Me.dgvMUPRPROP.Columns("MPPRCAPR").Visible = False
            Me.dgvMUPRPROP.Columns("MPPRSEXO").Visible = False
            Me.dgvMUPRPROP.Columns("MPPRESTA").Visible = False

            Me.dgvMUPRPROP.Columns("MPPRNUFI").DefaultCellStyle.Format = "n"
            Me.dgvMUPRPROP.Columns("MPPRNOVC").DefaultCellStyle.Format = "n"
            Me.dgvMUPRPROP.Columns("MPPRVACO").DefaultCellStyle.Format = "n"

            '==================================================
            '*** ASIGNA LOS PRIVILEGIOS DE LA BARRA DE MENU ***
            '==================================================

            Dim ContarRegistros As Integer = Me.BindingSource_MUPRPROP_1.Count

            Dim boCONTAGRE As Boolean = False
            Dim boCONTMODI As Boolean = False
            Dim boCONTELIM As Boolean = False
            Dim boCONTCONS As Boolean = False
            Dim boCONTRECO As Boolean = False

            pro_Permiso_Barra_De_Menu_Formulario_SubFormulario(ContarRegistros, Trim(Me.BindingNavigator_MUPRPROP_1.Name), boCONTAGRE, boCONTMODI, boCONTELIM, boCONTCONS, boCONTRECO)

            Me.cmdAGREGAR_MUPRPROP.Enabled = boCONTAGRE
            Me.cmdMODIFICAR_MUPRPROP.Enabled = boCONTMODI
            Me.cmdELIMINAR_MUPRPROP.Enabled = boCONTELIM
            Me.cmdCONSULTAR_MUPRPROP.Enabled = boCONTCONS
            Me.cmdRECONSULTAR_MUPRPROP.Enabled = boCONTRECO

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub pro_ListaDeValoresPropietarios()

        Try

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub pro_LimpiarCamposPropietarios()

        Try
            Me.dgvMUPRPROP.DataSource = New DataTable

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub

#End Region

#Region "PROCEDIMIENTOS CARGAR INFORMACION"

    Private Sub pro_AbrirArchivo()

        Try
            ' apaga los comandos
            Me.cmdGrabarDatos.Enabled = False

            ' enruta el archivo
            oLeer.InitialDirectory = "C:\"
            oLeer.Filter = "Archivo de texto (*.txt)|*.txt" 'Colocar varias extensiones
            oLeer.FilterIndex = 1 'coloca por defecto el *.txt
            oLeer.FileName = ""
            oLeer.ShowDialog()

            Dim stRutaArchivo As String = Trim(oLeer.FileName)

            If Trim(stRutaArchivo) <> "" Then

                ' almacena la linea
                Dim stContenidoLinea As String = ""
                Dim stContenidoRegistro As String = ""

                ' abre el archivo
                FileOpen(1, oLeer.FileName, OpenMode.Input) 'leer

                stContenidoLinea = LineInput(1)

                ' declara la variable
                vl_inVigencia = CType(stContenidoLinea.Substring(3, 4).ToString, String)
                vl_inResolucion = CType(CInt(stContenidoLinea.Substring(12, 7).ToString), String)

                Me.lblRECOVIGE.Text = CType(vl_inVigencia, String)
                Me.lblRECORESO.Text = CType(vl_inResolucion, String)

                ' limpia la variable
                vl_inTotalRegistros = 0

                ' Total de registros
                Do Until EOF(1)
                    stContenidoLinea = LineInput(1)
                    vl_inTotalRegistros += 1
                Loop

                Me.strBARRESTA.Items(2).Text = "Registro : " & vl_inTotalRegistros

                ' verifica la resolucion y vigencia
                If CInt(vl_inVigencia) = CInt(Me.dgvMUTAPRIM.SelectedRows.Item(0).Cells("MUPRVIGE").Value.ToString()) And _
                   CInt(vl_inResolucion) = CInt(Me.dgvMUTAPRIM.SelectedRows.Item(0).Cells("MUPRRESO").Value.ToString()) Then

                    Me.cmdGrabarDatos.Enabled = True
                    Me.cmdGrabarDatos.Focus()
                Else
                    MessageBox.Show("La resolución y/o vigencia del archivo texto no corresponde.", "Mensaje ...", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                End If

            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        Finally
            FileClose(1)
        End Try

    End Sub
    Private Sub pro_GuardarArchivo()

        Try
            ' apaga el boton grabar datos
            Me.cmdGrabarDatos.Enabled = False

            ' abre el archivo
            FileOpen(1, oLeer.FileName, OpenMode.Input) 'leer

            ' almacena la linea
            Dim stContenidoLinea As String = ""
            Dim stContenidoRegistro As String = ""

            ' Valores predeterminados 
            inProceso = 0
            Me.pbPROCESO.Value = 0
            Me.pbPROCESO.Maximum = vl_inTotalRegistros + 1
            Me.Timer1.Enabled = True

            ' recorre el archivo plano 
            Do Until EOF(1)

                ' extrae la linea
                stContenidoLinea = LineInput(1)

                ' extrae el dato
                stContenidoRegistro = CStr(stContenidoLinea.Substring(0, 2).ToString)

                ' linea de predios
                If stContenidoRegistro = "02" Then

                    ' declara las variables
                    Dim inMPMUSECU As Integer = CInt(Me.dgvMUTAPRIM.SelectedRows.Item(0).Cells("MUPRSECU").Value.ToString())
                    Dim inMPMUVIGE As Integer = CInt(stContenidoLinea.Substring(3, 4).ToString)
                    Dim inMPMUTIRE As Integer = CInt(stContenidoLinea.Substring(8, 3).ToString)
                    Dim inMPMURESO As Integer = CInt(stContenidoLinea.Substring(12, 7).ToString)
                    Dim inMPMUNUFI As Integer = CInt(stContenidoLinea.Substring(20, 9).ToString)
                    Dim inMPMUNURE As Integer = CInt(stContenidoLinea.Substring(30, 5).ToString)
                    Dim inMPMUNOVE As Integer = CInt(stContenidoLinea.Substring(72, 1).ToString)
                    Dim inMPMUNOVC As Integer = CInt(stContenidoLinea.Substring(243, 9).ToString)
                    Dim stMPMUMUNI As String = CStr(stContenidoLinea.Substring(36, 3).ToString)
                    Dim stMPMUCORR As String = CStr(stContenidoLinea.Substring(43, 2).ToString)
                    Dim stMPMUBARR As String = CStr(stContenidoLinea.Substring(46, 3).ToString)
                    Dim stMPMUMANZ As String = CStr(stContenidoLinea.Substring(50, 3).ToString)
                    Dim stMPMUPRED As String = CStr(stContenidoLinea.Substring(54, 5).ToString)
                    Dim stMPMUEDIF As String = CStr(stContenidoLinea.Substring(62, 3).ToString)
                    Dim stMPMUUNPR As String = CStr(stContenidoLinea.Substring(66, 5).ToString)
                    Dim inMPMUCLSE As Integer = CInt(stContenidoLinea.Substring(40, 1).ToString)
                    Dim stMPMUCAAC As String = CStr(stContenidoLinea.Substring(202, 3).ToString)
                    Dim stMPMUESTA As String = "ac"


                    ' instancla la calse
                    Dim obMUPRMUTA As New cla_MUPRMUTA
                    Dim dtMUPRMUTA As New DataTable

                    dtMUPRMUTA = obMUPRMUTA.fun_Buscar_CODIGO_X_MUPRMUTA(inMPMUVIGE, inMPMUTIRE, inMPMURESO, inMPMUNUFI, inMPMUNURE)

                    If dtMUPRMUTA.Rows.Count = 0 Then

                        ' inserta el registro
                        obMUPRMUTA.fun_Insertar_MUPRMUTA(inMPMUSECU, _
                                                         inMPMUVIGE, _
                                                         inMPMUTIRE, _
                                                         inMPMURESO, _
                                                         inMPMUNUFI, _
                                                         inMPMUNURE, _
                                                         inMPMUNOVE, _
                                                         inMPMUNOVC, _
                                                         stMPMUMUNI, _
                                                         stMPMUCORR, _
                                                         stMPMUBARR, _
                                                         stMPMUMANZ, _
                                                         stMPMUPRED, _
                                                         stMPMUEDIF, _
                                                         stMPMUUNPR, _
                                                         inMPMUCLSE, _
                                                         stMPMUCAAC, _
                                                         stMPMUESTA)

                    Else
                        ' elimina el registro
                        obMUPRMUTA.fun_Eliminar_CODIGO_X_MUPRMUTA(inMPMUVIGE, inMPMUTIRE, inMPMURESO, inMPMUNUFI, inMPMUNURE)

                        ' inserta el registro
                        obMUPRMUTA.fun_Insertar_MUPRMUTA(inMPMUSECU, _
                                                         inMPMUVIGE, _
                                                         inMPMUTIRE, _
                                                         inMPMURESO, _
                                                         inMPMUNUFI, _
                                                         inMPMUNURE, _
                                                         inMPMUNOVE, _
                                                         inMPMUNOVC, _
                                                         stMPMUMUNI, _
                                                         stMPMUCORR, _
                                                         stMPMUBARR, _
                                                         stMPMUMANZ, _
                                                         stMPMUPRED, _
                                                         stMPMUEDIF, _
                                                         stMPMUUNPR, _
                                                         inMPMUCLSE, _
                                                         stMPMUCAAC, _
                                                         stMPMUESTA)
                    End If

                End If

                ' linea de avaluos
                If stContenidoRegistro = "04" Then


                    ' declara las variables
                    Dim inMPPRSECU As Integer = CInt(Me.dgvMUTAPRIM.SelectedRows.Item(0).Cells("MUPRSECU").Value.ToString())
                    Dim inMPPRVIGE As Integer = CInt(stContenidoLinea.Substring(3, 4).ToString)
                    Dim inMPPRTIRE As Integer = CInt(stContenidoLinea.Substring(8, 3).ToString)
                    Dim inMPPRRESO As Integer = CInt(stContenidoLinea.Substring(12, 7).ToString)
                    Dim inMPPRNUFI As Integer = CInt(stContenidoLinea.Substring(20, 9).ToString)
                    Dim inMPPRNURE As Integer = CInt(stContenidoLinea.Substring(30, 5).ToString)
                    Dim stMPPRNUDO As String = CStr(stContenidoLinea.Substring(39, 14).ToString)
                    Dim inMPMUNOVC As Integer = CInt(stContenidoLinea.Substring(233, 9).ToString)
                    Dim inMPPRTIDO As Integer = CInt(fun_ObtieneTipoDocumentoTercero(stContenidoLinea.Substring(39, 14).ToString))
                    Dim stMPPRMAIN As String = CStr(fun_ObtieneMatriculaDelPredio(stContenidoLinea.Substring(20, 9).ToString, stContenidoLinea.Substring(147, 15).ToString)).ToString.Replace("001-", "")
                    Dim stMPPRCIRE As String = CStr(fun_ObtieneCirculoRegistralDelPredio(stContenidoLinea.Substring(20, 9).ToString, stContenidoLinea.Substring(147, 15).ToString))
                    Dim stMPPRESCR As String = CStr(stContenidoLinea.Substring(117, 7).ToString)
                    Dim stMPPRFEES As String = CStr(fun_EstructurarFechasConGuion(stContenidoLinea.Substring(125, 8).ToString))
                    Dim stMPPRVACO As String = CStr(fun_ObtineValorCompra(stContenidoLinea.Substring(20, 9).ToString, stContenidoLinea.Substring(3, 4).ToString))
                    Dim stMPPRENTI As String = CStr(fun_ObtieneEntidadNotarial(stContenidoLinea.Substring(106, 10).ToString))
                    Dim stMPPRDENO As String = CStr(stContenidoLinea.Substring(101, 2).ToString)
                    Dim stMPPRMUNO As String = CStr(stContenidoLinea.Substring(103, 3).ToString)
                    Dim stMPPRFAEN As String = CStr(stContenidoLinea.Substring(106, 10).ToString)
                    Dim stMPPRDERE As String = CStr(fun_EstructurarDerechoDePropiedad(stContenidoLinea.Substring(91, 9).ToString))
                    Dim boMPMUGRAV As Boolean = CBool(fun_EstablecePredioGravable(stContenidoLinea.Substring(166, 1)))
                    Dim stMPPRFERE As String = CStr(fun_EstructurarFechasConGuion(stContenidoLinea.Substring(134, 8).ToString))
                    Dim stMPPRLIRE As String = ""
                    Dim stMPPRTORE As String = ""
                    Dim stMPPRRARE As String = ""
                    Dim stMPPRCOFI As String = CStr(fun_ObtieneCodigoFideicomiso(stContenidoLinea.Substring(39, 14).ToString, stContenidoLinea.Substring(36, 2).ToString, (stContenidoLinea.Substring(70, 20).ToString & " " & stContenidoLinea.Substring(54, 15).ToString)))
                    Dim stMPPRNOFI As String = CStr(fun_ObtieneNombreFideicomiso(stContenidoLinea.Substring(39, 14).ToString, stContenidoLinea.Substring(36, 2).ToString, (stContenidoLinea.Substring(70, 20).ToString & " " & stContenidoLinea.Substring(54, 15).ToString)))
                    Dim stMPPRPRNO As String = CStr(stContenidoLinea.Substring(70, 20).ToString)
                    Dim stMPPRSENO As String = ""
                    Dim stMPPRPRAP As String = CStr(stContenidoLinea.Substring(54, 15).ToString)
                    Dim stMPPRSEAP As String = CStr(stContenidoLinea.Substring(178, 15).ToString)
                    Dim stMPPRRAZO As String = ""
                    Dim stMPPRTELE As String = ""
                    Dim stMPPRCOEL As String = ""
                    Dim stMPPRCELU As String = ""
                    Dim stMPPRDIRE As String = CStr(fun_ObtieneDireccionPredio(stContenidoLinea.Substring(20, 9).ToString))
                    Dim stMPPRSICO As String = CStr(stContenidoLinea.Substring(194, 20).ToString)
                    Dim stMPPRCAPR As String = CInt(fun_ObtieneCalidadPropietarioTercero(stContenidoLinea.Substring(39, 14).ToString))
                    Dim stMPPRSEXO As String = CInt(fun_ObtieneSexoTercero(stContenidoLinea.Substring(39, 14).ToString))
                    Dim stMPPRESTA As String = "ac"

                    ' instancla la calse
                    Dim obMUPRPROP As New cla_MUPRPROP
                    Dim dtMUPRPROP As New DataTable

                    dtMUPRPROP = obMUPRPROP.fun_Buscar_CODIGO_X_MUPRPROP(inMPPRVIGE, inMPPRTIRE, inMPPRRESO, inMPPRNUFI, inMPPRNURE, stMPPRNUDO)

                    If dtMUPRPROP.Rows.Count = 0 Then

                        ' inserta el registro
                        obMUPRPROP.fun_Insertar_MUPRPROP(inMPPRSECU, _
                                                         inMPPRVIGE, _
                                                         inMPPRTIRE, _
                                                         inMPPRRESO, _
                                                         inMPPRNUFI, _
                                                         inMPPRNURE, _
                                                         stMPPRNUDO, _
                                                         inMPMUNOVC, _
                                                         inMPPRTIDO, _
                                                         stMPPRMAIN, _
                                                         stMPPRCIRE, _
                                                         stMPPRESCR, _
                                                         stMPPRFEES, _
                                                         stMPPRVACO, _
                                                         stMPPRENTI, _
                                                         stMPPRDENO, _
                                                         stMPPRMUNO, _
                                                         stMPPRFAEN, _
                                                         stMPPRDERE, _
                                                         boMPMUGRAV, _
                                                         stMPPRFERE, _
                                                         stMPPRLIRE, _
                                                         stMPPRTORE, _
                                                         stMPPRRARE, _
                                                         stMPPRCOFI, _
                                                         stMPPRNOFI, _
                                                         stMPPRPRNO, _
                                                         stMPPRSENO, _
                                                         stMPPRPRAP, _
                                                         stMPPRSEAP, _
                                                         stMPPRRAZO, _
                                                         stMPPRTELE, _
                                                         stMPPRCOEL, _
                                                         stMPPRCELU, _
                                                         stMPPRDIRE, _
                                                         stMPPRSICO, _
                                                         stMPPRCAPR, _
                                                         stMPPRSEXO, _
                                                         stMPPRESTA)

                    Else
                        ' elimina el registro
                        obMUPRPROP.fun_Eliminar_CODIGO_MUPRPROP(inMPPRVIGE, inMPPRTIRE, inMPPRRESO, inMPPRNUFI, inMPPRNURE, stMPPRNUDO)

                        ' inserta el registro
                        obMUPRPROP.fun_Insertar_MUPRPROP(inMPPRSECU, _
                                                         inMPPRVIGE, _
                                                         inMPPRTIRE, _
                                                         inMPPRRESO, _
                                                         inMPPRNUFI, _
                                                         inMPPRNURE, _
                                                         stMPPRNUDO, _
                                                         inMPMUNOVC, _
                                                         inMPPRTIDO, _
                                                         stMPPRMAIN, _
                                                         stMPPRCIRE, _
                                                         stMPPRESCR, _
                                                         stMPPRFEES, _
                                                         stMPPRVACO, _
                                                         stMPPRENTI, _
                                                         stMPPRDENO, _
                                                         stMPPRMUNO, _
                                                         stMPPRFAEN, _
                                                         stMPPRDERE, _
                                                         boMPMUGRAV, _
                                                         stMPPRFERE, _
                                                         stMPPRLIRE, _
                                                         stMPPRTORE, _
                                                         stMPPRRARE, _
                                                         stMPPRCOFI, _
                                                         stMPPRNOFI, _
                                                         stMPPRPRNO, _
                                                         stMPPRSENO, _
                                                         stMPPRPRAP, _
                                                         stMPPRSEAP, _
                                                         stMPPRRAZO, _
                                                         stMPPRTELE, _
                                                         stMPPRCOEL, _
                                                         stMPPRCELU, _
                                                         stMPPRDIRE, _
                                                         stMPPRSICO, _
                                                         stMPPRCAPR, _
                                                         stMPPRSEXO, _
                                                         stMPPRESTA)

                    End If


                End If


                ' Incrementa la barra
                inProceso = inProceso + 1
                pbPROCESO.Value = inProceso

            Loop

            ' limpia la barra
            Me.pbPROCESO.Value = 0

            pro_ReconsultarMutacion()
            pro_ReconsultarPropietarios()

            ' mensaje de finalizacion
            mod_MENSAJE.Proceso_Termino_Correctamente()

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        Finally
            FileClose(1)
        End Try

    End Sub

#End Region

#Region "PROCEDIMIENTOS EXPORTAR INFORMACION"

    Private Sub pro_GenerarArchivosMutaciones()

        Try
            ' habilita el comando
            Me.cmdGenerarArchivos.Enabled = False
            Me.cmdGenerarListado.Enabled = False
            Me.cmdExportarExcel.Enabled = False

            ' declara la variable
            Dim boExportaArchivo As Boolean = False

            ' limpia la variable
            vl_stRutaDestino = ""

            ' selecciona la carpeta destino
            Dim oCarpetas As New FolderBrowserDialog
            'vl_stRutaDestino = "C:\JUEGOS\"

            oCarpetas.ShowDialog()
            vl_stRutaDestino = oCarpetas.SelectedPath

            ' verifica la ruta destino
            If Trim(vl_stRutaDestino) = "" Then
                mod_MENSAJE.Se_Requiere_Realizar_Una_Seleccion()
            Else
                ' instancia la clase
                Dim obMPMUMUTA As New cla_MUPRMUTA
                Dim dtMPMUMUTA As New DataTable

                dtMPMUMUTA = obMPMUMUTA.fun_Buscar_SECU_X_MUPRMUTA(CInt(Me.dgvMUTAPRIM.SelectedRows.Item(0).Cells("MUPRSECU").Value.ToString()))

                If dtMPMUMUTA.Rows.Count > 0 Then

                    ' Valores predeterminados ProgressBar
                    inProceso = 0
                    Me.pbPROCESO_2.Value = 0
                    Me.pbPROCESO_2.Maximum = dtMPMUMUTA.Rows.Count + 1
                    Me.Timer1.Enabled = True

                    ' declara la variable
                    Dim i As Integer = 0

                    For i = 0 To dtMPMUMUTA.Rows.Count - 1

                        ' declara la variable
                        Dim inMPMUNUFI As Integer = CInt(dtMPMUMUTA.Rows(i).Item("MPMUNUFI").ToString)
                        Dim inMPMUVIGE As Integer = CInt(dtMPMUMUTA.Rows(i).Item("MPMUVIGE").ToString)
                        Dim inMPMUSECU As Integer = CInt(dtMPMUMUTA.Rows(i).Item("MPMUSECU").ToString)
                        Dim inMPMUNURE As Integer = CInt(dtMPMUMUTA.Rows(i).Item("MPMUNURE").ToString)

                        ' instancia la clase
                        Dim obMUTACIONES As New cla_MUTACIONES
                        Dim dtMUTACIONES As New DataTable

                        dtMUTACIONES = obMUTACIONES.fun_Buscar_MUTACIONES_X_NRO_FICHA_Y_VIGENCIA(inMPMUNUFI, inMPMUVIGE)

                        If dtMUTACIONES.Rows.Count = 0 Then

                            ' actualiza el registro
                            pro_MarcaPredioSinAnexoDocumentos(inMPMUSECU, inMPMUNURE, False)

                        Else
                            ' delcara la variable
                            Dim stMUTAMUNI As String = CStr(Trim(dtMUTACIONES.Rows(0).Item("MUTAMUNI").ToString))
                            Dim inMUTACLSE As Integer = CInt(dtMUTACIONES.Rows(0).Item("MUTACLSE").ToString)
                            Dim stMUTACORR As String = CStr(Trim(dtMUTACIONES.Rows(0).Item("MUTACORR").ToString))
                            Dim stMUTABARR As String = CStr(Trim(dtMUTACIONES.Rows(0).Item("MUTABARR").ToString))
                            Dim stMUTAMANZ As String = CStr(Trim(dtMUTACIONES.Rows(0).Item("MUTAMANZ").ToString))
                            Dim stMUTAPRED As String = CStr(Trim(dtMUTACIONES.Rows(0).Item("MUTAPRED").ToString))
                            Dim stMUTAEDIF As String = CStr(Trim(dtMUTACIONES.Rows(0).Item("MUTAEDIF").ToString))
                            Dim stMUTAUNPR As String = CStr(Trim(dtMUTACIONES.Rows(0).Item("MUTAUNPR").ToString))

                            Dim inMUTAVIGE As Integer = CInt(dtMUTACIONES.Rows(0).Item("MUTAVIGE").ToString)
                            Dim inMUTAESCR As Integer = CInt(dtMUTACIONES.Rows(0).Item("MUTAESCR").ToString)

                            ' declara la variable
                            Dim stRuta As String = ""
                            Dim stNewPath As String = ""
                            Dim ContentItem As String

                            ' instancia la clase
                            Dim objRutas As New cla_RUTAS
                            Dim tblRutas As New DataTable

                            tblRutas = objRutas.fun_Buscar_CODIGO_MANT_RUTAS(7)

                            If tblRutas.Rows.Count = 0 AndAlso fun_VerificarCarpetaExistenteDocumentos(stMUTAMUNI, inMUTACLSE, stMUTACORR, stMUTABARR, stMUTAMANZ, stMUTAPRED, stMUTAEDIF, stMUTAUNPR, inMUTAVIGE) = False Then

                                ' actualiza el registro
                                pro_MarcaPredioSinAnexoDocumentos(inMPMUSECU, inMPMUNURE, False)

                            Else
                                ' establece la ruta de la carpeta
                                stNewPath = Trim(tblRutas.Rows(0).Item("RUTARUTA")) & "\" & Trim(stMUTAMUNI) & "-" & Trim(inMUTACLSE) & "-" & Trim(stMUTACORR) & "-" & Trim(stMUTABARR) & "-" & Trim(stMUTAMANZ) & "-" & Trim(stMUTAPRED) & "-" & Trim(stMUTAEDIF) & "-" & Trim(stMUTAUNPR) & "-" & Trim(inMUTAVIGE)

                                ' establace la ruta inicial
                                vl_stRutaDocumentos = stNewPath

                                ' recorre el directorio
                                ChDir(stNewPath)

                                ' limpia el listado
                                Me.lstLISTADO_DOCUMENTOS.Items.Clear()

                                ' busca el archivo
                                ContentItem = Dir("*ormu*.pdf")

                                If ContentItem <> "" Then

                                    ' agrega a la lista
                                    Me.lstLISTADO_DOCUMENTOS.Items.Add(ContentItem)

                                    'desplaza el registro
                                    ContentItem = Dir()

                                    ' cuenta los registros
                                    If Me.lstLISTADO_DOCUMENTOS.Items.Count = 0 Then

                                        ' actualiza el registro
                                        pro_MarcaPredioSinAnexoDocumentos(inMPMUSECU, inMPMUNURE, False)

                                    Else
                                        ' posiciona el puntero
                                        Me.lstLISTADO_DOCUMENTOS.Focus()

                                        ' verifica que exista registros
                                        If Me.lstLISTADO_DOCUMENTOS.Items.Count > 0 Then

                                            ' selecciona el registro
                                            Me.lstLISTADO_DOCUMENTOS.SelectedIndex = Me.lstLISTADO_DOCUMENTOS.Items.Count - 1

                                            ' declara las variables
                                            Dim stRutaInicial As String = fun_ConsultarRutaInicial()
                                            Dim stRutaDestino As String = fun_consultarRutaDestino(inMPMUNUFI, inMUTAESCR)

                                            ' copia el archivo
                                            pro_CopiarDocumento(stRutaInicial, stRutaDestino)

                                            ' retira el archivo del listado
                                            Me.lstLISTADO_DOCUMENTOS.Items.RemoveAt(lstLISTADO_DOCUMENTOS.SelectedIndex)

                                            ' actualiza el registro
                                            pro_MarcaPredioSinAnexoDocumentos(inMPMUSECU, inMPMUNURE, True)

                                            ' asigna la variable
                                            boExportaArchivo = True

                                        End If

                                    End If

                                End If

                            End If

                        End If

                        ' Incrementa la barra
                        inProceso = inProceso + 1
                        pbPROCESO_2.Value = inProceso

                    Next

                    ' inicia la barra de progreso
                    Me.pbPROCESO_2.Value = 0

                End If

            End If

            ' reconsulta informacion
            pro_ReconsultarMutacion()

            ' ubica el puntero
            Me.TabMAESTRO_2.SelectTab(TabListadoArchivos)

            ' propiedades el comando
            Me.cmdGenerarArchivos.Enabled = True

            If boExportaArchivo = True Then
                Me.cmdGenerarListado.Enabled = True
            End If
          
            ' mensaje de proceso
            mod_MENSAJE.Proceso_Termino_Correctamente()

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub pro_GenerarListadoMutaciones()

        Try
            ' Crea objeto registros
            Dim dr1 As DataRow

            ' crea la tabla
            Dim dt_CargaDatos As New DataTable

            dt_CargaDatos.Columns.Add(New DataColumn("Novedad", GetType(String)))
            dt_CargaDatos.Columns.Add(New DataColumn("Nro_Ficha_OVC", GetType(String)))
            dt_CargaDatos.Columns.Add(New DataColumn("Tipo_Documento", GetType(String)))
            dt_CargaDatos.Columns.Add(New DataColumn("Nro_Documento", GetType(String)))
            dt_CargaDatos.Columns.Add(New DataColumn("Matricula", GetType(String)))
            dt_CargaDatos.Columns.Add(New DataColumn("Circulo_Notarial", GetType(String)))
            dt_CargaDatos.Columns.Add(New DataColumn("Escritura", GetType(String)))
            dt_CargaDatos.Columns.Add(New DataColumn("Fecha_Escritura", GetType(String)))
            dt_CargaDatos.Columns.Add(New DataColumn("Valor_Compra", GetType(String)))
            dt_CargaDatos.Columns.Add(New DataColumn("Entidad", GetType(String)))
            dt_CargaDatos.Columns.Add(New DataColumn("Dpto_Notaria", GetType(String)))
            dt_CargaDatos.Columns.Add(New DataColumn("Mpio_Notaria", GetType(String)))
            dt_CargaDatos.Columns.Add(New DataColumn("Fallo_Entidad", GetType(String)))
            dt_CargaDatos.Columns.Add(New DataColumn("Derecho", GetType(String)))
            dt_CargaDatos.Columns.Add(New DataColumn("Gravable", GetType(String)))
            dt_CargaDatos.Columns.Add(New DataColumn("Fecha_Registro", GetType(String)))
            dt_CargaDatos.Columns.Add(New DataColumn("Libro_Registro", GetType(String)))
            dt_CargaDatos.Columns.Add(New DataColumn("Tomo_Registro", GetType(String)))
            dt_CargaDatos.Columns.Add(New DataColumn("Pagina_Registro", GetType(String)))
            dt_CargaDatos.Columns.Add(New DataColumn("Codigo_Fideicomiso", GetType(String)))
            dt_CargaDatos.Columns.Add(New DataColumn("Nombre_Fideicomiso", GetType(String)))
            dt_CargaDatos.Columns.Add(New DataColumn("Primer_Nombre", GetType(String)))
            dt_CargaDatos.Columns.Add(New DataColumn("Segundo_Nombre", GetType(String)))
            dt_CargaDatos.Columns.Add(New DataColumn("Primer_Apellido", GetType(String)))
            dt_CargaDatos.Columns.Add(New DataColumn("Segundo_Apellido", GetType(String)))
            dt_CargaDatos.Columns.Add(New DataColumn("Razon_Social", GetType(String)))
            dt_CargaDatos.Columns.Add(New DataColumn("Telefono", GetType(String)))
            dt_CargaDatos.Columns.Add(New DataColumn("Correo_Electronico", GetType(String)))
            dt_CargaDatos.Columns.Add(New DataColumn("Celular", GetType(String)))
            dt_CargaDatos.Columns.Add(New DataColumn("Direccion", GetType(String)))
            dt_CargaDatos.Columns.Add(New DataColumn("Sigla_Comercial", GetType(String)))
            dt_CargaDatos.Columns.Add(New DataColumn("Calidad_Propietario", GetType(String)))
            dt_CargaDatos.Columns.Add(New DataColumn("Genero", GetType(String)))

            ' instancia la clase
            Dim obMUPRMUTA As New cla_MUPRMUTA
            Dim dtMUPRMUTA As New DataTable

            ' carga la informacion
            dtMUPRMUTA = obMUPRMUTA.fun_Buscar_CODIGO_X_MUPRMUTA(CInt(Me.dgvMUTAPRIM.SelectedRows.Item(0).Cells("MUPRSECU").Value.ToString()))

            ' verifica la informacion
            If dtMUPRMUTA.Rows.Count > 0 Then

                ' declara la variable
                Dim i As Integer = 0

                For i = 0 To dtMUPRMUTA.Rows.Count - 1

                    ' Valores predeterminados ProgressBar
                    inProceso = 0
                    Me.pbPROCESO_2.Value = 0
                    Me.pbPROCESO_2.Maximum = dtMUPRMUTA.Rows.Count + 1
                    Me.Timer1.Enabled = True

                    ' verifica el registro *** cambiar a true ***
                    If CBool(dtMUPRMUTA.Rows(i).Item("MPMUANDO")) = True Then 'Or CBool(dtMUPRMUTA.Rows(i).Item("MPMUANDO")) = False Then

                        ' declara la variable
                        Dim inMPMUNURE As Integer = CInt(dtMUPRMUTA.Rows(i).Item("MPMUNURE").ToString)

                        ' instancia la clase
                        Dim obMUPRMUTA_1 As New cla_MUPRMUTA
                        Dim dtMUPRMUTA_1 As New DataTable

                        ' carga la informacion
                        dtMUPRMUTA_1 = obMUPRMUTA_1.fun_Buscar_NURE_X_MUPRMUTA(inMPMUNURE)

                        ' instancia la clase
                        Dim obMUPRPROP_1 As New cla_MUPRPROP
                        Dim dtMUPRPROP_1 As New DataTable

                        ' carga la informacion
                        dtMUPRPROP_1 = obMUPRPROP_1.fun_Buscar_NURE_X_MUPRPROP(inMPMUNURE)

                        ' verifica la informacion
                        If dtMUPRMUTA_1.Rows.Count > 0 And dtMUPRPROP_1.Rows.Count > 0 Then

                            dr1 = dt_CargaDatos.NewRow()

                            dr1("Novedad") = CStr(fun_Buscar_Lista_Valores_NOVEDAD(dtMUPRMUTA_1.Rows(0).Item("MPMUNOVE").ToString))
                            dr1("Nro_Ficha_OVC") = CStr(dtMUPRMUTA_1.Rows(0).Item("MPMUNOVC").ToString)
                            dr1("Tipo_Documento") = CStr(fun_Buscar_Lista_Valores_TIPODOCU(dtMUPRPROP_1.Rows(0).Item("MPPRTIDO").ToString).ToString.ToUpper)
                            dr1("Nro_Documento") = CStr(dtMUPRPROP_1.Rows(0).Item("MPPRNUDO").ToString)
                            dr1("Matricula") = CStr(dtMUPRPROP_1.Rows(0).Item("MPPRMAIN").ToString)
                            dr1("Circulo_Notarial") = CStr(dtMUPRPROP_1.Rows(0).Item("MPPRCIRE").ToString)
                            dr1("Escritura") = CStr(dtMUPRPROP_1.Rows(0).Item("MPPRESCR").ToString)
                            dr1("Fecha_Escritura") = CStr(dtMUPRPROP_1.Rows(0).Item("MPPRFEES").ToString) & " _"
                            dr1("Valor_Compra") = CStr(dtMUPRPROP_1.Rows(0).Item("MPPRVACO").ToString)
                            dr1("Entidad") = CStr(dtMUPRPROP_1.Rows(0).Item("MPPRENTI").ToString)
                            dr1("Dpto_Notaria") = CStr(dtMUPRPROP_1.Rows(0).Item("MPPRDENO").ToString)
                            dr1("Mpio_Notaria") = CStr(dtMUPRPROP_1.Rows(0).Item("MPPRMUNO").ToString)
                            dr1("Fallo_Entidad") = CStr(dtMUPRPROP_1.Rows(0).Item("MPPRFAEN").ToString)
                            dr1("Derecho") = CStr(dtMUPRPROP_1.Rows(0).Item("MPPRDERE").ToString)
                            dr1("Gravable") = CStr(fun_ObtienePredioGravable(CBool(dtMUPRPROP_1.Rows(0).Item("MPPRGRAV"))))
                            dr1("Fecha_Registro") = CStr(dtMUPRPROP_1.Rows(0).Item("MPPRFERE").ToString) & " _"
                            dr1("Libro_Registro") = CStr(dtMUPRPROP_1.Rows(0).Item("MPPRLIRE").ToString)
                            dr1("Tomo_Registro") = CStr(dtMUPRPROP_1.Rows(0).Item("MPPRTORE").ToString)
                            dr1("Pagina_Registro") = CStr(dtMUPRPROP_1.Rows(0).Item("MPPRPARE").ToString)
                            dr1("Codigo_Fideicomiso") = CStr(dtMUPRPROP_1.Rows(0).Item("MPPRCOFI").ToString)
                            dr1("Nombre_Fideicomiso") = CStr(dtMUPRPROP_1.Rows(0).Item("MPPRNOFI").ToString)
                            dr1("Primer_Nombre") = CStr(dtMUPRPROP_1.Rows(0).Item("MPPRPRNO").ToString)
                            dr1("Segundo_Nombre") = CStr(dtMUPRPROP_1.Rows(0).Item("MPPRSENO").ToString)
                            dr1("Primer_Apellido") = CStr(dtMUPRPROP_1.Rows(0).Item("MPPRPRAP").ToString)
                            dr1("Segundo_Apellido") = CStr(dtMUPRPROP_1.Rows(0).Item("MPPRSEAP").ToString)
                            dr1("Razon_Social") = CStr(dtMUPRPROP_1.Rows(0).Item("MPPRRASO").ToString)
                            dr1("Telefono") = CStr(dtMUPRPROP_1.Rows(0).Item("MPPRTELE").ToString)
                            dr1("Correo_Electronico") = CStr(dtMUPRPROP_1.Rows(0).Item("MPPRCOEL").ToString)
                            dr1("Celular") = CStr(dtMUPRPROP_1.Rows(0).Item("MPPRCELU").ToString)
                            dr1("Direccion") = CStr(dtMUPRPROP_1.Rows(0).Item("MPPRDIRE").ToString)
                            dr1("Sigla_Comercial") = CStr(dtMUPRPROP_1.Rows(0).Item("MPPRSICO").ToString)
                            dr1("Calidad_Propietario") = CStr(fun_Buscar_Lista_Valores_CALIPROP(dtMUPRPROP_1.Rows(0).Item("MPPRCAPR").ToString).ToString.ToUpper)
                            dr1("Genero") = CStr(fun_Buscar_Lista_Valores_SEXO(dtMUPRPROP_1.Rows(0).Item("MPPRSEXO").ToString).ToString.ToUpper)

                            dt_CargaDatos.Rows.Add(dr1)

                        End If

                    End If

                    ' Incrementa la barra
                    inProceso = inProceso + 1
                    pbPROCESO_2.Value = inProceso

                Next

                ' inicia la barra de progreso
                Me.pbPROCESO_2.Value = 0

                ' llena el datagrivg
                Me.dgvListadoMutaciones.DataSource = dt_CargaDatos

                ' control de comandos
                If Me.dgvListadoMutaciones.RowCount > 0 Then
                    Me.cmdExportarExcel.Enabled = True
                Else
                    Me.cmdExportarExcel.Enabled = False
                End If

            End If

            ' ubica el puntero
            Me.TabMAESTRO_2.SelectTab(TabListadoMutaciones)

            ' mensaje de proceso
            mod_MENSAJE.Proceso_Termino_Correctamente()

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub pro_ExportarInformacionExcel()

        Try
            Dim oExp As New cla_ExportarTablaExcel
            oExp.DataTableToExcel(CType(Me.dgvListadoMutaciones.DataSource, DataTable))

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub pro_CopiarDocumento(ByVal stRutaInicial As String, ByVal stRutaDestino As String)

        Try
            If File.Exists(Trim(stRutaDestino)) = False Then
                File.Copy(Trim(stRutaInicial), Trim(stRutaDestino))

            ElseIf File.Exists(Trim(stRutaDestino)) = True Then
                pro_EliminarDocumento(Trim(stRutaDestino))

                File.Copy(Trim(stRutaInicial), Trim(stRutaDestino))
            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub pro_EliminarDocumento(ByVal stRutaDestino As String)

        Try
            If File.Exists(Trim(stRutaDestino)) = True Then
                File.Delete(Trim(stRutaDestino))

            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub pro_MarcaPredioSinAnexoDocumentos(ByVal inMPMUSECU As Integer, ByVal inMPMUNURE As Integer, ByVal boMPMUANDO As Boolean)

        Try
            ' instancia la clase
            Dim obMPMUMUTA_1 As New cla_MUPRMUTA

            ' actualiza el registro
            obMPMUMUTA_1.fun_Actualizar_MUPRMUTA(CInt(inMPMUSECU), CInt(inMPMUNURE), CBool(boMPMUANDO))

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    

#End Region

#Region "MENU MUTACIONES DE PRIMERA CLASE"

    Private Sub cmdAGREGAR_MUTAPRIM_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAGREGAR_MUTAPRIM.Click

        Try
            If Me.dgvMUTAPRIM.RowCount > 0 Then
                Dim frm_insertar As New frm_insertar_MUTAPRIM(Integer.Parse(Me.dgvMUTAPRIM.SelectedRows.Item(0).Cells(0).Value.ToString()))
                frm_insertar.ShowDialog()
            Else
                frm_insertar_MUTAPRIM.ShowDialog()
            End If

            If vp_inConsulta > 0 Then
                boCONSULTA = True
            Else
                boCONSULTA = False
            End If

            pro_ReconsultarMutacionesPrimeraClase()
            pro_ListaDeValoresMutacionesPrimeraClase()

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub cmdMODIFICAR_MUTAPRIM_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdMODIFICAR_MUTAPRIM.Click

        Try
            Dim frm_modificar As New frm_modificar_MUTAPRIM(Integer.Parse(Me.dgvMUTAPRIM.SelectedRows.Item(0).Cells("MUPRIDRE").Value.ToString()),
                                                                          Me.dgvMUTAPRIM.SelectedRows.Item(0).Cells("MUPRNUDO").Value.ToString())
            frm_modificar.ShowDialog()

            If vp_inConsulta <> 0 Then
                boCONSULTA = True
            End If

            pro_ReconsultarMutacionesPrimeraClase()
            pro_ListaDeValoresMutacionesPrimeraClase()

            Me.TabMAESTRO_1.SelectTab(TabMutacion)

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub cmdELIMINAR_MUTAPRIM_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdELIMINAR_MUTAPRIM.Click

        Try
            If MessageBox.Show("¿ Desea eliminar el registro seleccionado ? ", "Mensaje...", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then
                Dim objdatos As New cla_MUTAPRIM

                If objdatos.fun_Eliminar_IDRE_MUTAPRIM(Integer.Parse(Me.dgvMUTAPRIM.SelectedRows.Item(0).Cells(0).Value.ToString())) Then

                    boCONSULTA = False
                    pro_LimpiarCamposMutacionesPrimeraClase()
                    pro_ReconsultarMutacionesPrimeraClase()
                    pro_ListaDeValoresMutacionesPrimeraClase()
                Else
                    frm_INCO_eliminar_registro_padre_con_relación_de_registros_hijos.ShowDialog()
                End If

            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub cmdCONSULTAR_MUTAPRIM_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCONSULTAR_MUTAPRIM.Click

        Try
            vp_inConsulta = 0

            If Me.dgvMUTAPRIM.RowCount > 0 Then
                Dim frm_consultar As New frm_consultar_MUTAPRIM(Integer.Parse(Me.dgvMUTAPRIM.SelectedRows.Item(0).Cells("MUPRIDRE").Value.ToString()))
                frm_consultar.ShowDialog()
            Else
                Dim frm_consultar As New frm_consultar_MUTAPRIM()
                frm_consultar.ShowDialog()
            End If

            If vp_inConsulta > 0 Then
                boCONSULTA = True
            Else
                boCONSULTA = False
            End If

            pro_ReconsultarMutacionesPrimeraClase()
            pro_ListaDeValoresMutacionesPrimeraClase()

            Me.TabMAESTRO_1.SelectTab(TabMutacion)

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub cmdRECONSULTAR_MUTAPRIM_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdRECONSULTAR_MUTAPRIM.Click

        Try
            If Me.dgvMUTAPRIM.RowCount > 0 Then
                boCONSULTA = True
            Else
                boCONSULTA = False
            End If

            pro_ReconsultarMutacionesPrimeraClase()
            pro_ListaDeValoresMutacionesPrimeraClase()

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
            If Me.dgvMUTAPRIM.RowCount > 0 Then

                Dim frm_inserta_archivo As New frm_insertar_archivo_MUTAPRIM(Me.dgvMUTAPRIM.SelectedRows.Item(0).Cells("MUPRVIGE").Value.ToString(), _
                                                                             Me.dgvMUTAPRIM.SelectedRows.Item(0).Cells("MUPRRESO").Value.ToString())
                frm_inserta_archivo.ShowDialog()

                pro_ListadoArchivosDocumentos()

                vp_inConsulta = Me.dgvMUTAPRIM.SelectedRows.Item(0).Cells("MUPRIDRE").Value.ToString()

                If vp_inConsulta <> 0 Then
                    boCONSULTA = True
                End If

                pro_ReconsultarMutacionesPrimeraClase()
                pro_ListaDeValoresMutacionesPrimeraClase()

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

#End Region

#Region "MENU MUTACION"

    Private Sub cmdAGREGAR_MUPRMUTA_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAGREGAR_MUPRMUTA.Click

        Try
            If Me.dgvMUTAPRIM.RowCount > 0 Then
                Dim frm_insertar As New frm_insertar_MUPRMUTA(Me.dgvMUTAPRIM.SelectedRows.Item(0).Cells("MUPRSECU").Value.ToString(), _
                                                              Me.dgvMUTAPRIM.SelectedRows.Item(0).Cells("MUPRVIGE").Value.ToString(), _
                                                              Me.dgvMUTAPRIM.SelectedRows.Item(0).Cells("MUPRTIRE").Value.ToString(), _
                                                              Me.dgvMUTAPRIM.SelectedRows.Item(0).Cells("MUPRRESO").Value.ToString())
                frm_insertar.ShowDialog()
            End If

            boCONSULTA = False

            pro_ReconsultarMutacion()
            pro_ListaDeValoresMutacion()

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub cmdMODIFICAR_MUPRMUTA_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdMODIFICAR_MUPRMUTA.Click

        Try
            Dim frm_modificar As New frm_insertar_MUPRMUTA(Me.dgvMUPRMUTA.SelectedRows.Item(0).Cells("MPMUIDRE").Value.ToString(), _
                                                           Me.dgvMUTAPRIM.SelectedRows.Item(0).Cells("MUPRSECU").Value.ToString(), _
                                                           Me.dgvMUTAPRIM.SelectedRows.Item(0).Cells("MUPRVIGE").Value.ToString(), _
                                                           Me.dgvMUTAPRIM.SelectedRows.Item(0).Cells("MUPRTIRE").Value.ToString(), _
                                                           Me.dgvMUTAPRIM.SelectedRows.Item(0).Cells("MUPRRESO").Value.ToString(), _
                                                           Me.dgvMUPRMUTA.SelectedRows.Item(0).Cells("MPMUNUFI").Value.ToString(), _
                                                           Me.dgvMUPRMUTA.SelectedRows.Item(0).Cells("MPMUNURE").Value.ToString())
            frm_modificar.ShowDialog()

            If vp_inConsulta <> 0 Then
                boCONSULTA = True
            End If

            pro_ReconsultarMutacion()
            pro_ListaDeValoresMutacion()

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub cmdELIMINAR_MUPRMUTA_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdELIMINAR_MUPRMUTA.Click

        Try
            If MessageBox.Show("¿ Desea eliminar el registro seleccionado ? ", "Mensaje...", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then
                Dim objdatos As New cla_MUPRMUTA

                If objdatos.fun_Eliminar_IDRE_MUPRMUTA(Integer.Parse(Me.dgvMUPRMUTA.SelectedRows.Item(0).Cells("MPMUIDRE").Value.ToString())) Then

                    boCONSULTA = False

                    pro_LimpiarCamposMutacion()
                    pro_ReconsultarMutacion()
                    pro_ListaDeValoresMutacion()
                    pro_ReconsultarPropietarios()
                    pro_ListaDeValoresPropietarios()

                Else
                    frm_INCO_eliminar_registro_padre_con_relación_de_registros_hijos.ShowDialog()
                End If

            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub cmdCONSULTAR_MUPRMUTA_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCONSULTAR_MUPRMUTA.Click

        Try
            vp_inConsulta = 0

            If Me.dgvMUTAPRIM.RowCount > 0 Then
                Dim frm_consultar As New frm_consultar_MUTAPRIM(Integer.Parse(Me.dgvMUTAPRIM.SelectedRows.Item(0).Cells("MUPRIDRE").Value.ToString()))
                frm_consultar.ShowDialog()
            Else
                Dim frm_consultar As New frm_consultar_MUTAPRIM()
                frm_consultar.ShowDialog()
            End If

            If vp_inConsulta > 0 Then
                boCONSULTA = True
            Else
                boCONSULTA = False
            End If

            pro_ReconsultarMutacionesPrimeraClase()
            pro_ListaDeValoresMutacionesPrimeraClase()

            Me.TabMAESTRO_1.SelectTab(TabMutacion)

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub cmdRECONSULTAR_MUPRMUTA_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdRECONSULTAR_MUPRMUTA.Click

        Try
            If Me.dgvMUTAPRIM.RowCount > 0 Then
                boCONSULTA = True
            Else
                boCONSULTA = False
            End If

            pro_ReconsultarMutacionesPrimeraClase()
            pro_ListaDeValoresMutacionesPrimeraClase()

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub

#End Region

#Region "MENU PROPIETARIOS"

    Private Sub cmdAGREGAR_MUPRPROP_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAGREGAR_MUPRPROP.Click

        Try
            If Me.dgvMUTAPRIM.RowCount > 0 Then
                Dim frm_insertar As New frm_insertar_MUPRPROP(Me.dgvMUTAPRIM.SelectedRows.Item(0).Cells("MUPRSECU").Value.ToString(), _
                                                              Me.dgvMUTAPRIM.SelectedRows.Item(0).Cells("MUPRVIGE").Value.ToString(), _
                                                              Me.dgvMUTAPRIM.SelectedRows.Item(0).Cells("MUPRTIRE").Value.ToString(), _
                                                              Me.dgvMUTAPRIM.SelectedRows.Item(0).Cells("MUPRRESO").Value.ToString())
                frm_insertar.ShowDialog()
            End If

            boCONSULTA = False

            pro_ReconsultarPropietarios()
            pro_ListaDeValoresPropietarios()

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub cmdMODIFICAR_MUPRPROP_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdMODIFICAR_MUPRPROP.Click

        Try
            Dim frm_modificar As New frm_insertar_MUPRPROP(Me.dgvMUPRPROP.SelectedRows.Item(0).Cells("MPPRIDRE").Value.ToString(), _
                                                           Me.dgvMUTAPRIM.SelectedRows.Item(0).Cells("MUPRSECU").Value.ToString(), _
                                                           Me.dgvMUTAPRIM.SelectedRows.Item(0).Cells("MUPRVIGE").Value.ToString(), _
                                                           Me.dgvMUTAPRIM.SelectedRows.Item(0).Cells("MUPRTIRE").Value.ToString(), _
                                                           Me.dgvMUTAPRIM.SelectedRows.Item(0).Cells("MUPRRESO").Value.ToString(), _
                                                           Me.dgvMUPRPROP.SelectedRows.Item(0).Cells("MPPRNUFI").Value.ToString(), _
                                                           Me.dgvMUPRPROP.SelectedRows.Item(0).Cells("MPPRNURE").Value.ToString(), _
                                                           Me.dgvMUPRPROP.SelectedRows.Item(0).Cells("MPPRNUDO").Value.ToString())
            frm_modificar.ShowDialog()

            If vp_inConsulta <> 0 Then
                boCONSULTA = True
            End If

            pro_ReconsultarPropietarios()
            pro_ListaDeValoresPropietarios()

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub cmdELIMINAR_MUPRPROP_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdELIMINAR_MUPRPROP.Click

        Try
            If MessageBox.Show("¿ Desea eliminar el registro seleccionado ? ", "Mensaje...", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then
                Dim objdatos As New cla_MUPRPROP

                If objdatos.fun_Eliminar_IDRE_MUPRPROP(Integer.Parse(Me.dgvMUPRPROP.SelectedRows.Item(0).Cells("MPPRIDRE").Value.ToString())) Then

                    boCONSULTA = False

                    pro_LimpiarCamposPropietarios()
                    pro_ReconsultarPropietarios()
                    pro_ListaDeValoresPropietarios()
                Else
                    frm_INCO_eliminar_registro_padre_con_relación_de_registros_hijos.ShowDialog()
                End If

            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub cmdCONSULTAR_MUPRPROP_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCONSULTAR_MUPRPROP.Click

        Try
            vp_inConsulta = 0

            If Me.dgvMUTAPRIM.RowCount > 0 Then
                Dim frm_consultar As New frm_consultar_MUTAPRIM(Integer.Parse(Me.dgvMUTAPRIM.SelectedRows.Item(0).Cells("MUPRIDRE").Value.ToString()))
                frm_consultar.ShowDialog()
            Else
                Dim frm_consultar As New frm_consultar_MUTAPRIM()
                frm_consultar.ShowDialog()
            End If

            If vp_inConsulta > 0 Then
                boCONSULTA = True
            Else
                boCONSULTA = False
            End If

            pro_ReconsultarMutacionesPrimeraClase()
            pro_ListaDeValoresMutacionesPrimeraClase()

            Me.TabMAESTRO_1.SelectTab(TabMutacion)

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub cmdRECONSULTAR_MUPRPROP_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdRECONSULTAR_MUPRPROP.Click

        Try
            If Me.dgvMUTAPRIM.RowCount > 0 Then
                boCONSULTA = True
            Else
                boCONSULTA = False
            End If

            pro_ReconsultarMutacionesPrimeraClase()
            pro_ListaDeValoresMutacionesPrimeraClase()

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub

#End Region

#Region "MENU CARGAR INFORMACION"

    Private Sub cmdAbrirArchivo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAbrirArchivo.Click
        pro_AbrirArchivo()
    End Sub
    Private Sub cmdGrabarDatos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGrabarDatos.Click
        pro_GuardarArchivo()
    End Sub

#End Region

#Region "MENU EXPORTAR INFORMACION"

    Private Sub cmdGenerarArchivos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGenerarListado.Click
        pro_GenerarListadoMutaciones()
    End Sub
    Private Sub cmdExportarExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExportarExcel.Click
        pro_ExportarInformacionExcel()
    End Sub
    Private Sub cmdGenerarArchivos_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGenerarArchivos.Click
        pro_GenerarArchivosMutaciones()
    End Sub

#End Region

#Region "FORMULARIO"

#Region "Load"

    Private Sub frm_MUTAPRIM_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Me.Load
        pro_ReconsultarMutacionesPrimeraClase()
        pro_ListadoArchivosDocumentos()
        Me.strBARRESTA.Items(0).Text = "Mutaciones"
    End Sub

#End Region

#Region "GotFocus"

    Private Sub frm_REGIMUTA_GotFocus1(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.GotFocus
        pro_ListaDeValoresMutacionesPrimeraClase()
    End Sub
    Private Sub dgvREGIMUTA_1_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.GotFocus
        Me.strBARRESTA.Items(0).Text = dgvMUTAPRIM.AccessibleDescription
    End Sub

#End Region

#Region "KeyDown"

    Private Sub dgvREGIMUTA_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgvMUTAPRIM.KeyDown
        '===============================================================================================
        '*** INSERTAR REGISTROS ***
        '===============================================================================================


        If e.KeyCode = Keys.F2 Then
            If Me.cmdAGREGAR_MUTAPRIM.Enabled = True Then
                Me.cmdAGREGAR_MUTAPRIM.PerformClick()
            Else
                mod_MENSAJE.Usuario_No_Tiene_Permiso_Para_Realizar_La_Operacion()
            End If
        End If

        '===============================================================================================
        'MODIFICAR REGISTROS
        '===============================================================================================

        If e.KeyCode = Keys.F3 Then
            If Me.cmdMODIFICAR_MUTAPRIM.Enabled = True Then
                Me.cmdMODIFICAR_MUTAPRIM.PerformClick()
            Else
                Dim ContarRegistros As Integer = Me.BindingSource_MUTAPRIM_1.Count

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
            If Me.cmdELIMINAR_MUTAPRIM.Enabled = True Then
                Me.cmdELIMINAR_MUTAPRIM.PerformClick()
            Else
                Dim ContarRegistros As Integer = Me.BindingSource_MUTAPRIM_1.Count

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
            If Me.cmdCONSULTAR_MUTAPRIM.Enabled = True Then
                Me.cmdCONSULTAR_MUTAPRIM.PerformClick()
            Else
                mod_MENSAJE.No_Existen_Registros_En_Base_De_Datos()
            End If
        End If

        '===============================================================================================
        '*** RECONSULTAR REGISTROS ***
        '===============================================================================================

        If e.KeyCode = Keys.F8 Then
            If Me.cmdCONSULTAR_MUTAPRIM.Enabled = True Then
                Me.cmdRECONSULTAR_MUTAPRIM.PerformClick()
            Else
                mod_MENSAJE.No_Existen_Registros_En_Base_De_Datos()
            End If
        End If

    End Sub

#End Region

#Region "KeyUp"

    Private Sub dgvREGIMUTA_1_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgvMUTAPRIM.KeyUp
        If e.KeyCode = Keys.Down Or e.KeyCode = Keys.Up Or e.KeyCode = Keys.Enter Or e.KeyCode = Keys.PageUp Or e.KeyCode = Keys.PageDown Then
            pro_ListaDeValoresMutacionesPrimeraClase()
        End If
    End Sub

#End Region

#Region "CellClick"

    Private Sub dgvREGIMUTA_1_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvMUTAPRIM.CellClick
        pro_ListaDeValoresMutacionesPrimeraClase()
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