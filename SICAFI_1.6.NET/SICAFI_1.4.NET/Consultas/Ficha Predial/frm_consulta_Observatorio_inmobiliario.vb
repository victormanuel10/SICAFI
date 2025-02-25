Imports REGLAS_DEL_NEGOCIO
Imports System
Imports System.IO
Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration
Imports System.Text
Imports System.Math

Public Class frm_consulta_Observatorio_inmobiliario

    '==========================================
    '*** CONSULTA OBSERVATORIO INMOBILIARIO ***
    '==========================================

#Region "CONSTRUCTORES"

    Private oEjecutar As New SqlCommand
    Private oConexion As New SqlConnection
    Private oAdapter As New SqlDataAdapter
    Private ds As New DataSet
    Private dt As New DataTable
    Private dt1 As New DataTable
    Private dt2 As New DataTable
    Private dt3 As New DataTable

    Dim tblCONSULTA As New DataTable

#End Region

#Region "INSTANCIAR FORMULARIO"

    Private Shared frm_Instance = Nothing

    Public Shared Function instance() As frm_consulta_Observatorio_inmobiliario
        If frm_Instance Is Nothing OrElse frm_Instance.isdisposed = True Then
            frm_Instance = New frm_consulta_Observatorio_inmobiliario
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

#Region "VARIABLES"

    ' Tabla 0
    Private dt_FICHPRED As New DataTable
    ' Tabla 3
    Private dt_FIPRCONS As New DataTable
    ' Tabla 4
    Private dt_FIPRCACO As New DataTable
    ' Tabla 7
    Private dt_FIPRZOEC As New DataTable

    ' variables verificar datos
    Dim stFIPRNUFI As String
    Dim stFIPRDIRE As String
    Dim stFIPRMUNI As String
    Dim stFIPRCORR As String
    Dim stFIPRBARR As String
    Dim stFIPRMANZ As String
    Dim stFIPRPRED As String
    Dim stFIPREDIF As String
    Dim stFIPRUNPR As String
    Dim stFIPRCLSE As String
    Dim stFIPRESTA As String
    Dim stFIPRCASU As String
    Dim stFIPRCAPR As String
    Dim stFIPRMOAD As String
    Dim Separador As String

    ' variables guardar consulta
    Dim Guardar_stFIPRNUFI As String
    Dim Guardar_stFIPRDIRE As String
    Dim Guardar_stFIPRMUNI As String
    Dim Guardar_stFIPRCORR As String
    Dim Guardar_stFIPRBARR As String
    Dim Guardar_stFIPRMANZ As String
    Dim Guardar_stFIPRPRED As String
    Dim Guardar_stFIPREDIF As String
    Dim Guardar_stFIPRUNPR As String
    Dim Guardar_stFIPRCLSE As String
    Dim Guardar_stFIPRESTA As String
    Dim Guardar_stFIPRCASU As String
    Dim Guardar_stFIPRCAPR As String
    Dim Guardar_stFIPRMOAD As String

    Dim dt_CONSULTA As New DataTable

    Dim inProceso As Integer = 0

    Dim inCantidadPrediosNivelPredio As Integer = 0
    Dim inCantidadPrediosNivelunidadPredial As Integer = 0
    Dim inCantidadZonas As Integer = 0
    Dim inCantidadTotalZonas As Integer = 0
    Dim inPuntosInvestigados As Integer = 0
    Dim inPuntosRequeridos As Integer = 0
    Dim inTotalPuntosRequeridos As Integer = 0

    Private vl_loFPAVATPR As Long = 0
    Private vl_loFPAVATCO As Long = 0
    Private vl_stFPAVACPR As String = "0.00"
    Private vl_stFPAVACCO As String = "0.00"
    Private vl_loFPAVVATP As Long = 0
    Private vl_loFPAVVATC As Long = 0
    Private vl_loFPAVVACP As Long = 0
    Private vl_loFPAVVACC As Long = 0
    Private vl_loFPAVAVAL As Long = 0

    Private vl_inFPCOPUNT As Integer = 0
    Private vl_stFPCOTICO As String = ""

    Private vl_loPROMTERR As Long = 0
    Private vl_loPROMCONS As Long = 0

#End Region

#Region "FUNCIONES"

    Function fun_ListarPrediosPorZonaFisica(ByVal inZonaFisica As Integer) As Integer

        Try
            Dim inCantidad As Integer = 0

            ' buscar cadena de conexion
            Dim oCadenaConexion As New REGLAS_DEL_NEGOCIO.cla_ConnectionString
            Dim stCadenaConexion As String = oCadenaConexion.fun_ConnectionString

            ' crea el datatable
            dt1 = New DataTable

            ' crear conexión
            oAdapter = New SqlDataAdapter
            oConexion = New SqlConnection(stCadenaConexion)

            ' abre la conexion
            oConexion.Open()

            ' parametros de la consulta
            Dim ParametrosConsulta As String = ""

            ' Concatena la condicion de la consulta
            ParametrosConsulta += "SELECT FIPRMUNI, FIPRCORR, FIPRBARR, FIPRMANZ, FIPRPRED, FIPREDIF, FIPRUNPR, FIPRCLSE, FIPRCAPR, FIPRESTA, FIPRTIFI "
            ParametrosConsulta += "FROM FICHPRED "
            ParametrosConsulta += "WHERE "
            ParametrosConsulta += "FIPRMUNI like '" & stFIPRMUNI & "' and "
            ParametrosConsulta += "FIPRCORR like '" & stFIPRCORR & "' and "
            ParametrosConsulta += "FIPRBARR like '" & stFIPRBARR & "' and "
            ParametrosConsulta += "FIPRMANZ like '" & stFIPRMANZ & "' and "
            ParametrosConsulta += "FIPRPRED like '" & stFIPRPRED & "' and "
            ParametrosConsulta += "FIPREDIF like '" & stFIPREDIF & "' and "
            ParametrosConsulta += "FIPRUNPR like '" & stFIPRUNPR & "' and "
            ParametrosConsulta += "FIPRCLSE like '" & stFIPRCLSE & "' and "
            ParametrosConsulta += "FIPRCAPR like '" & stFIPRCAPR & "' and "
            ParametrosConsulta += "FIPRESTA like '" & stFIPRESTA & "' and "
            ParametrosConsulta += "FIPRTIFI = 0 and "
            'ParametrosConsulta += "EXISTS(SELECT 1 FROM fiprzofi WHERE fiprnufi = fpzfnufi and fpzfporc >= 50 and fpzfzofi = '" & inZonaFisica & "') "
            ParametrosConsulta += "EXISTS(SELECT 1 FROM fiprzofi WHERE fiprnufi = fpzfnufi and fpzfzofi = '" & inZonaFisica & "') "
            ParametrosConsulta += "GROUP BY FIPRMUNI, FIPRCORR, FIPRBARR, FIPRMANZ, FIPRPRED, FIPREDIF, FIPRUNPR, FIPRCLSE, FIPRCAPR ,FIPRESTA, FIPRTIFI "

            ' ejecuta la consulta
            oEjecutar = New SqlCommand(ParametrosConsulta, oConexion)

            ' procesa la consulta 
            oEjecutar.CommandTimeout = 0
            oEjecutar.CommandType = CommandType.Text
            oAdapter.SelectCommand = oEjecutar

            ' llena el datatable 
            oAdapter.Fill(dt1)

            ' cierra la conexion
            oConexion.Close()

            If dt1.Rows.Count > 0 Then

                Dim i As Integer = 0

                For i = 0 To dt1.Rows.Count - 1

                    inCantidad += 1

                Next

            End If

            Return inCantidad

        Catch ex As Exception
            Return False
            MessageBox.Show(Err.Description)
        End Try

    End Function
    Function fun_ListarPrediosPorZonaFisicaObservatorio(ByVal inZonaFisica As Integer) As Integer

        Try
            Dim inCantidad As Integer = 0

            ' buscar cadena de conexion
            Dim oCadenaConexion As New REGLAS_DEL_NEGOCIO.cla_ConnectionString
            Dim stCadenaConexion As String = oCadenaConexion.fun_ConnectionString

            ' crea el datatable
            dt3 = New DataTable

            ' crear conexión
            oAdapter = New SqlDataAdapter
            oConexion = New SqlConnection(stCadenaConexion)

            ' abre la conexion
            oConexion.Open()

            ' parametros de la consulta
            Dim ParametrosConsulta As String = ""

            ' Concatena la condicion de la consulta
            ParametrosConsulta += "SELECT OBINMUNI, OBINCORR, OBINBARR, OBINMANZ, OBINPRED, OBINEDIF, OBINUNPR, OBINCLSE, OBINESTA "
            ParametrosConsulta += "FROM OBSEINMO "
            ParametrosConsulta += "WHERE "
            ParametrosConsulta += "OBINMUNI like '" & stFIPRMUNI & "' and "
            ParametrosConsulta += "OBINCORR like '" & stFIPRCORR & "' and "
            ParametrosConsulta += "OBINBARR like '" & stFIPRBARR & "' and "
            ParametrosConsulta += "OBINMANZ like '" & stFIPRMANZ & "' and "
            ParametrosConsulta += "OBINPRED like '" & stFIPRPRED & "' and "
            ParametrosConsulta += "OBINEDIF like '" & stFIPREDIF & "' and "
            ParametrosConsulta += "OBINUNPR like '" & stFIPRUNPR & "' and "
            ParametrosConsulta += "OBINCLSE like '" & stFIPRCLSE & "' and "
            ParametrosConsulta += "OBINESTA like '" & stFIPRESTA & "' and "
            ParametrosConsulta += "OBINZOFI like '" & inZonaFisica & "' "
            ParametrosConsulta += "GROUP BY OBINMUNI, OBINCORR, OBINBARR, OBINMANZ, OBINPRED, OBINEDIF, OBINUNPR, OBINCLSE, OBINESTA "

            ' ejecuta la consulta
            oEjecutar = New SqlCommand(ParametrosConsulta, oConexion)

            ' procesa la consulta 
            oEjecutar.CommandTimeout = 0
            oEjecutar.CommandType = CommandType.Text
            oAdapter.SelectCommand = oEjecutar

            ' llena el datatable 
            oAdapter.Fill(dt3)

            ' cierra la conexion
            oConexion.Close()

            If dt3.Rows.Count > 0 Then

                Dim i As Integer = 0

                For i = 0 To dt3.Rows.Count - 1

                    inCantidad += 1

                Next

            End If

            Return inCantidad

        Catch ex As Exception
            Return False
            MessageBox.Show(Err.Description)
        End Try

    End Function
    Function fun_ListarCantidadZonasFisicas(ByVal stMunicipio As String, ByVal stSector As String) As Integer

        Try
            Dim inCantidad As Integer = 0

            ' buscar cadena de conexion
            Dim oCadenaConexion As New REGLAS_DEL_NEGOCIO.cla_ConnectionString
            Dim stCadenaConexion As String = oCadenaConexion.fun_ConnectionString

            ' crea el datatable
            dt3 = New DataTable

            ' crear conexión
            oAdapter = New SqlDataAdapter
            oConexion = New SqlConnection(stCadenaConexion)

            ' abre la conexion
            oConexion.Open()

            ' parametros de la consulta
            Dim ParametrosConsulta As String = ""

            ' Concatena la condicion de la consulta
            ParametrosConsulta += "SELECT COUNT(1) "
            ParametrosConsulta += "FROM FIPRZOFI "
            ParametrosConsulta += "WHERE FPZFESTA = 'ac' AND "
            ParametrosConsulta += "EXISTS(SELECT 1 FROM FICHPRED WHERE FIPRESTA = 'ac' AND FIPRTIFI = 0 AND FIPRNUFI = FPZFNUFI AND FIPRMUNI like '" & Trim(stMunicipio) & "' AND FIPRCLSE like '" & Trim(stSector) & "')"

            ' ejecuta la consulta
            oEjecutar = New SqlCommand(ParametrosConsulta, oConexion)

            ' procesa la consulta 
            oEjecutar.CommandTimeout = 0
            oEjecutar.CommandType = CommandType.Text
            oAdapter.SelectCommand = oEjecutar

            ' llena el datatable 
            oAdapter.Fill(dt3)

            ' cierra la conexion
            oConexion.Close()

            inCantidad = dt3.Rows(0).Item(0)

            Return inCantidad

        Catch ex As Exception
            Return False
            MessageBox.Show(Err.Description)
        End Try

    End Function
    Function fun_ListarCantidadDePrediosNivelPredio() As Integer

        Try
            Dim inCantidad As Integer = 0

            ' buscar cadena de conexion
            Dim oCadenaConexion As New REGLAS_DEL_NEGOCIO.cla_ConnectionString
            Dim stCadenaConexion As String = oCadenaConexion.fun_ConnectionString

            ' crea el datatable
            dt2 = New DataTable

            ' crear conexión
            oAdapter = New SqlDataAdapter
            oConexion = New SqlConnection(stCadenaConexion)

            ' abre la conexion
            oConexion.Open()

            ' parametros de la consulta
            Dim ParametrosConsulta As String = ""

            ' Concatena la condicion de la consulta
            ParametrosConsulta += "SELECT FIPRMUNI, FIPRCORR, FIPRBARR, FIPRMANZ, FIPRPRED, FIPRCLSE, FIPRESTA "
            ParametrosConsulta += "FROM FICHPRED "
            ParametrosConsulta += "WHERE "
            ParametrosConsulta += "FIPRMUNI like '" & stFIPRMUNI & "' and "
            ParametrosConsulta += "FIPRCORR like '" & stFIPRCORR & "' and "
            ParametrosConsulta += "FIPRBARR like '" & stFIPRBARR & "' and "
            ParametrosConsulta += "FIPRMANZ like '" & stFIPRMANZ & "' and "
            ParametrosConsulta += "FIPRPRED like '" & stFIPRPRED & "' and "
            ParametrosConsulta += "FIPRCLSE like '" & stFIPRCLSE & "' and "
            ParametrosConsulta += "FIPRCAPR like '" & stFIPRCAPR & "' and "
            ParametrosConsulta += "FIPRESTA like '" & stFIPRESTA & "' and "
            ParametrosConsulta += "FIPRTIFI = 0 "
            ParametrosConsulta += "GROUP BY FIPRMUNI, FIPRCORR, FIPRBARR, FIPRMANZ, FIPRPRED, FIPRCLSE, FIPRESTA "

            ' ejecuta la consulta
            oEjecutar = New SqlCommand(ParametrosConsulta, oConexion)

            ' procesa la consulta 
            oEjecutar.CommandTimeout = 0
            oEjecutar.CommandType = CommandType.Text
            oAdapter.SelectCommand = oEjecutar

            ' llena el datatable 
            oAdapter.Fill(dt2)

            ' cierra la conexion
            oConexion.Close()

            If dt2.Rows.Count > 0 Then

                Dim i As Integer = 0

                For i = 0 To dt2.Rows.Count - 1

                    inCantidad += 1

                Next

            End If

            Return inCantidad

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Function
    Function fun_ListarCantidadDePrediosNivelUnidadPredial() As Integer

        Try
            Dim inCantidad As Integer = 0

            ' buscar cadena de conexion
            Dim oCadenaConexion As New REGLAS_DEL_NEGOCIO.cla_ConnectionString
            Dim stCadenaConexion As String = oCadenaConexion.fun_ConnectionString

            ' crea el datatable
            dt2 = New DataTable

            ' crear conexión
            oAdapter = New SqlDataAdapter
            oConexion = New SqlConnection(stCadenaConexion)

            ' abre la conexion
            oConexion.Open()

            ' parametros de la consulta
            Dim ParametrosConsulta As String = ""

            ' Concatena la condicion de la consulta
            ParametrosConsulta += "SELECT FIPRMUNI, FIPRCORR, FIPRBARR, FIPRMANZ, FIPRPRED, FIPREDIF, FIPRUNPR, FIPRCLSE, FIPRESTA "
            ParametrosConsulta += "FROM FICHPRED "
            ParametrosConsulta += "WHERE "
            ParametrosConsulta += "FIPRMUNI like '" & stFIPRMUNI & "' and "
            ParametrosConsulta += "FIPRCORR like '" & stFIPRCORR & "' and "
            ParametrosConsulta += "FIPRBARR like '" & stFIPRBARR & "' and "
            ParametrosConsulta += "FIPRMANZ like '" & stFIPRMANZ & "' and "
            ParametrosConsulta += "FIPRPRED like '" & stFIPRPRED & "' and "
            ParametrosConsulta += "FIPREDIF like '" & stFIPREDIF & "' and "
            ParametrosConsulta += "FIPRUNPR like '" & stFIPRUNPR & "' and "
            ParametrosConsulta += "FIPRCLSE like '" & stFIPRCLSE & "' and "
            ParametrosConsulta += "FIPRCAPR like '" & stFIPRCAPR & "' and "
            ParametrosConsulta += "FIPRESTA like '" & stFIPRESTA & "' and "
            ParametrosConsulta += "FIPRTIFI = 0 "
            ParametrosConsulta += "GROUP BY FIPRMUNI, FIPRCORR, FIPRBARR, FIPRMANZ, FIPRPRED, FIPREDIF, FIPRUNPR, FIPRCLSE, FIPRESTA "

            ' ejecuta la consulta
            oEjecutar = New SqlCommand(ParametrosConsulta, oConexion)

            ' procesa la consulta 
            oEjecutar.CommandTimeout = 0
            oEjecutar.CommandType = CommandType.Text
            oAdapter.SelectCommand = oEjecutar

            ' llena el datatable 
            oAdapter.Fill(dt2)

            ' cierra la conexion
            oConexion.Close()

            If dt2.Rows.Count > 0 Then

                Dim i As Integer = 0

                For i = 0 To dt2.Rows.Count - 1

                    inCantidad += 1

                Next

            End If

            Return inCantidad

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Function
    Function fun_HomologarZonaFisicaDefinitiva(ByVal stMunicipio As String, ByVal inSector As Integer, ByVal inZonaFisicaDefinitiva As Integer) As Integer

        Try
            Dim inVAZFZFAC As Integer = inZonaFisicaDefinitiva
            Dim stVAZFMUNI As String = Trim(stMunicipio)
            Dim inVAZFCLSE As Integer = inSector

            Dim inVAZFZOFI As Integer = 0

            ' declaro la instancia
            Dim obVARIZOFI As New cla_VARIZOFI
            Dim dtVARIZOFI As New DataTable

            dtVARIZOFI = obVARIZOFI.fun_Buscar_CODIGO_MUNI_CLSE_X_MANT_VARIZOFI(stVAZFMUNI, inVAZFCLSE, inVAZFZFAC)

            If dtVARIZOFI.Rows.Count > 0 Then

                inVAZFZOFI = CInt(dtVARIZOFI.Rows(0).Item("VAZFZOFI").ToString)

            End If

            Return inVAZFZOFI

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Function
    Function fun_ConsultaDePrediosPorZonaFisicaActual(ByVal stMunicipio As String, ByVal inSector As Integer, ByVal inZonaFisicaActual As Integer) As DataTable

        Try
            Dim inVAZFZOFI As Integer = inZonaFisicaActual
            Dim stVAZFMUNI As String = Trim(stMunicipio)
            Dim inVAZFCLSE As Integer = inSector

            Dim dtZONAFISI As New DataTable

            ' declaro la instancia
            Dim obFPZFZOFI As New cla_FIPRZOFI
            Dim dtFPZFZOFI As New DataTable

            dtFPZFZOFI = obFPZFZOFI.fun_buscar_ZOFIMUNI_X_ZOFICLSE_X_MANT_ZONAFISI(stVAZFMUNI, inVAZFCLSE, inVAZFZOFI)

            Return dtFPZFZOFI

        Catch ex As Exception
            Return Nothing
            MessageBox.Show(Err.Description)
        End Try

    End Function

    Private Function fun_ConsultarPorcentajeDeDescuentoAreaDeTerreno(ByVal loFIPRARTE As Long) As Integer

        Try
            ' Descuentos sector urbano
            If dt_FICHPRED.Rows(0).Item("FIPRCLSE") = 1 Then

                If loFIPRARTE >= 0 And loFIPRARTE <= 300 Then
                    Return 100
                End If

                If loFIPRARTE >= 301 And loFIPRARTE <= 350 Then
                    Return 100
                End If

                If loFIPRARTE >= 351 And loFIPRARTE <= 400 Then
                    Return 100
                End If

                If loFIPRARTE >= 401 And loFIPRARTE <= 450 Then
                    Return 100
                End If

                If loFIPRARTE >= 451 And loFIPRARTE <= 500 Then
                    Return 100
                End If

                If loFIPRARTE >= 501 And loFIPRARTE <= 600 Then
                    Return 100
                End If

                If loFIPRARTE >= 601 And loFIPRARTE <= 700 Then
                    Return 100
                End If

                If loFIPRARTE >= 701 And loFIPRARTE <= 900 Then
                    Return 100
                End If

                If loFIPRARTE >= 901 And loFIPRARTE <= 1200 Then
                    Return 100
                End If

                If loFIPRARTE >= 1201 And loFIPRARTE <= 1600 Then
                    Return 100
                End If

                If loFIPRARTE >= 1601 Then
                    Return 100
                End If

            End If

            ' Descuento sector rural
            If dt_FICHPRED.Rows(0).Item("FIPRCLSE") = 2 Then

                If loFIPRARTE >= 0 And loFIPRARTE <= 30000 Then
                    Return 100
                End If

                If loFIPRARTE >= 30001 And loFIPRARTE <= 100000 Then
                    Return 100
                End If

                If loFIPRARTE >= 100001 And loFIPRARTE <= 200000 Then
                    Return 100
                End If

                If loFIPRARTE >= 200001 And loFIPRARTE <= 500000 Then
                    Return 100
                End If

                If loFIPRARTE >= 500001 Then
                    Return 100
                End If

            End If

        Catch ex As Exception
            Return 0
            MessageBox.Show(Err.Description)
        End Try

    End Function

    Private Function fun_ConsultaAreaTerrenoPrivada() As Integer

        Try
            If dt_FICHPRED.Rows(0).Item("FIPRCAPR") = 1 Or _
               dt_FICHPRED.Rows(0).Item("FIPRCAPR") = 2 Or _
               dt_FICHPRED.Rows(0).Item("FIPRCAPR") = 3 Or _
               dt_FICHPRED.Rows(0).Item("FIPRCAPR") = 4 Or _
               dt_FICHPRED.Rows(0).Item("FIPRCAPR") = 5 Or _
               dt_FICHPRED.Rows(0).Item("FIPRCAPR") = 6 Or _
               dt_FICHPRED.Rows(0).Item("FIPRCAPR") = 7 Then

                Return dt_FICHPRED.Rows(0).Item("FIPRARTE")
            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try


    End Function
    Private Function fun_ConsultarAreaTerrenoComun() As Integer

        Try
            ' ========================================
            ' *** CARACTERISTICA DE PREDIO "1-6-7" ***
            ' ========================================
            If dt_FICHPRED.Rows(0).Item("FIPRCAPR") = 1 Or _
               dt_FICHPRED.Rows(0).Item("FIPRCAPR") = 6 Or _
               dt_FICHPRED.Rows(0).Item("FIPRCAPR") = 7 Then

                Return 0
            End If

            ' ======================================
            ' *** CARACTERISTICA DE PREDIO "2-3" ***
            ' ======================================
            If dt_FICHPRED.Rows(0).Item("FIPRCAPR") = 2 Or _
               dt_FICHPRED.Rows(0).Item("FIPRCAPR") = 3 Then

                ' declaro variables
                Dim inAreaTerrenoComun As Integer = 0
                Dim deFIPRCOED As Decimal = CType(dt_FICHPRED.Rows(0).Item("FIPRCOED"), Decimal)
                Dim inFIPRTIFI As Integer = 2
                Dim inFIPRACLO As Integer = 0
                Dim stFIPRUNPR As String = "00000"

                ' instancia la clase
                Dim objdatos As New cla_FICHRESU
                Dim tbl As New DataTable

                tbl = objdatos.fun_buscar_CEDULA_CATASTRAL_FICHRESU(Trim(dt_FICHPRED.Rows(0).Item("FIPRMUNI")), Trim(dt_FICHPRED.Rows(0).Item("FIPRCORR")), Trim(dt_FICHPRED.Rows(0).Item("FIPRBARR")), Trim(dt_FICHPRED.Rows(0).Item("FIPRMANZ")), Trim(dt_FICHPRED.Rows(0).Item("FIPRPRED")), Trim(dt_FICHPRED.Rows(0).Item("FIPREDIF")), Trim(stFIPRUNPR), Trim(dt_FICHPRED.Rows(0).Item("FIPRCLSE")), inFIPRTIFI)

                ' declara area comun 
                If tbl.Rows.Count > 0 Then
                    inFIPRACLO = CType(tbl.Rows(0).Item("FIPRACLO"), Integer)
                Else
                    inFIPRACLO = 0
                End If

                ' calculo area comun 
                inAreaTerrenoComun = (inFIPRACLO * deFIPRCOED) / 100

                ' retorna area comun 
                Return inAreaTerrenoComun

            End If

            ' ===================================
            ' *** CARACTERITICA DE PREDIO "4" ***
            ' ===================================
            If dt_FICHPRED.Rows(0).Item("FIPRCAPR") = 4 Then

                ' declaro variables
                Dim inAreaTerrenoComun As Integer = 0
                Dim inAreaTerrenoComunFR1 As Integer = 0
                Dim inAreaTerrenoComunFR2 As Integer = 0
                Dim deFIPRCOED As Decimal = CType(dt_FICHPRED.Rows(0).Item("FIPRCOED"), Decimal)
                Dim deFIPRCOPR As Decimal = CType(dt_FICHPRED.Rows(0).Item("FIPRCOPR"), Decimal)
                Dim inFIPRTIFI_1 As Integer = 1
                Dim inFIPRTIFI_2 As Integer = 2
                Dim inFIPRACLO_1 As Integer = 0
                Dim inFIPRACLO_2 As Integer = 0
                Dim stFIPREDIF As String = "000"
                Dim stFIPRUNPR As String = "00000"

                '============================================
                ' *** CONSULTA AREA COMUN FICHA RESUMEN 1 ***
                '============================================

                ' instancia la clase
                Dim objdatos As New cla_FICHRESU
                Dim tbl As New DataTable

                ' consulta area comun ficha resumen 1
                tbl = objdatos.fun_buscar_CEDULA_CATASTRAL_FICHRESU(Trim(dt_FICHPRED.Rows(0).Item("FIPRMUNI")), Trim(dt_FICHPRED.Rows(0).Item("FIPRCORR")), Trim(dt_FICHPRED.Rows(0).Item("FIPRBARR")), Trim(dt_FICHPRED.Rows(0).Item("FIPRMANZ")), Trim(dt_FICHPRED.Rows(0).Item("FIPRPRED")), Trim(stFIPREDIF), Trim(stFIPRUNPR), Trim(dt_FICHPRED.Rows(0).Item("FIPRCLSE")), inFIPRTIFI_1)

                ' declara area comun 
                If tbl.Rows.Count > 0 Then
                    inFIPRACLO_1 = CType(tbl.Rows(0).Item("FIPRACLO"), Integer)
                Else
                    inFIPRACLO_1 = 0
                End If

                ' calculo area comun 
                inAreaTerrenoComunFR1 = (inFIPRACLO_1 * deFIPRCOPR) / 100

                '============================================
                ' *** CONSULTA AREA COMUN FICHA RESUMEN 2 ***
                '============================================

                ' instancia la clase
                Dim objdatos1 As New cla_FICHRESU
                Dim tbl1 As New DataTable

                ' consulta area comun ficha resumen 1
                tbl1 = objdatos1.fun_buscar_CEDULA_CATASTRAL_FICHRESU(Trim(dt_FICHPRED.Rows(0).Item("FIPRMUNI")), Trim(dt_FICHPRED.Rows(0).Item("FIPRCORR")), Trim(dt_FICHPRED.Rows(0).Item("FIPRBARR")), Trim(dt_FICHPRED.Rows(0).Item("FIPRMANZ")), Trim(dt_FICHPRED.Rows(0).Item("FIPRPRED")), Trim(dt_FICHPRED.Rows(0).Item("FIPREDIF")), Trim(stFIPRUNPR), Trim(dt_FICHPRED.Rows(0).Item("FIPRCLSE")), inFIPRTIFI_2)

                ' declara area comun 
                If tbl1.Rows.Count > 0 Then
                    inFIPRACLO_2 = CType(tbl1.Rows(0).Item("FIPRACLO"), Integer)
                Else
                    inFIPRACLO_2 = 0
                End If

                ' calculo area comun 
                inAreaTerrenoComunFR2 = (inFIPRACLO_2 * deFIPRCOED) / 100

                ' suma area comun FR1 y FR2
                inAreaTerrenoComun = inAreaTerrenoComunFR1 + inAreaTerrenoComunFR2

                ' retorna area comun 
                Return inAreaTerrenoComun

            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Function
    Private Function fun_ConsultarAreaConstruccionPrivada() As String

        Try
            ' declara la variable
            Dim deAreaConstruccion As Decimal = 0.0

            If dt_FICHPRED.Rows(0).Item("FIPRCAPR") = 1 Or _
             dt_FICHPRED.Rows(0).Item("FIPRCAPR") = 2 Or _
             dt_FICHPRED.Rows(0).Item("FIPRCAPR") = 3 Or _
             dt_FICHPRED.Rows(0).Item("FIPRCAPR") = 4 Or _
             dt_FICHPRED.Rows(0).Item("FIPRCAPR") = 5 Or _
             dt_FICHPRED.Rows(0).Item("FIPRCAPR") = 6 Or _
             dt_FICHPRED.Rows(0).Item("FIPRCAPR") = 7 Then

                If dt_FIPRCONS.Rows.Count > 0 Then

                    Dim i As Integer = 0

                    For i = 0 To 1 - 1

                        If Trim(dt_FIPRCONS.Rows(i).Item("FPCOESTA")) = "ac" Then
                            If dt_FIPRCONS.Rows(i).Item("FPCOCLCO") = 1 Or dt_FIPRCONS.Rows(i).Item("FPCOCLCO") = 2 Then

                                deAreaConstruccion = CType(dt_FIPRCONS.Rows(i).Item("FPCOARCO"), Decimal)
                                vl_inFPCOPUNT = CType(dt_FIPRCONS.Rows(i).Item("FPCOPUNT"), Integer)
                                vl_stFPCOTICO = CType(dt_FIPRCONS.Rows(i).Item("FPCOTICO"), String)

                            End If
                        End If

                    Next

                End If

            End If

            Return fun_Formato_Decimal_2_Decimales(deAreaConstruccion)

        Catch ex As Exception
            Return "0.00"
            MessageBox.Show(Err.Description)
        End Try

    End Function

    Private Function fun_ConsultarValorAreaTerrenoPrivada() As Long

        Try
            Dim loValorTerrenoPrivado As Long = 0

            Dim inValor01 As Integer = 0
            Dim inValor02 As Integer = 0
            Dim inValor03 As Integer = 0
            Dim inValor04 As Integer = 0
            Dim inValor05 As Integer = 0

            ' declara la instancia


            Return loValorTerrenoPrivado

        Catch ex As Exception
            Return 0
            MessageBox.Show(Err.Description)
        End Try

    End Function
    Private Function fun_ConsultarValorAreaConstruccionPrivada() As Long

        Try
            ' ================================================
            ' *** CARACTERISTICA DE PREDIO "1-2-3-4-5-6-7" ***
            ' ================================================
            If dt_FICHPRED.Rows(0).Item("FIPRCAPR") = 1 Or _
               dt_FICHPRED.Rows(0).Item("FIPRCAPR") = 2 Or _
               dt_FICHPRED.Rows(0).Item("FIPRCAPR") = 3 Or _
               dt_FICHPRED.Rows(0).Item("FIPRCAPR") = 4 Or _
               dt_FICHPRED.Rows(0).Item("FIPRCAPR") = 5 Or _
               dt_FICHPRED.Rows(0).Item("FIPRCAPR") = 6 Or _
               dt_FICHPRED.Rows(0).Item("FIPRCAPR") = 7 Then

                ' declaro las variables
                Dim deAreaDeConstruccionPrivado As Decimal = 0.0
                Dim loValorConstruccionPrivado As Long = 0

                ' verifica si existe construcciones
                If dt_FIPRCONS.Rows.Count > 0 Then

                    Dim i As Integer = 0

                    For i = 0 To 1 - 1

                        If Trim(dt_FIPRCONS.Rows(i).Item("FPCOESTA")) = "ac" Then
                            If dt_FIPRCONS.Rows(i).Item("FPCOCLCO") = 1 Or dt_FIPRCONS.Rows(i).Item("FPCOCLCO") = 2 Then

                                ' declaro la variable 
                                Dim stDepartamento As String = Trim(dt_FICHPRED.Rows(0).Item("FIPRDEPA"))
                                Dim stMunicipio As String = Trim(dt_FICHPRED.Rows(0).Item("FIPRMUNI"))
                                Dim inClaseSector As Integer = CType(dt_FICHPRED.Rows(0).Item("FIPRCLSE"), Integer)

                                Dim stIdentificador As String = Trim(dt_FIPRCONS.Rows(i).Item("FPCOTICO"))
                                Dim inClaseConstruccion As Integer = CType(dt_FIPRCONS.Rows(i).Item("FPCOCLCO"), Integer)
                                Dim inPuntoConstruccion As Integer = CType(dt_FIPRCONS.Rows(i).Item("FPCOPUNT"), Integer)
                                Dim deAreaDeConstruccion As Decimal = CType(dt_FIPRCONS.Rows(i).Item("FPCOARCO"), Decimal)

                                Dim deValorFactorA As Decimal = 0.0
                                Dim deValorFactorB As Decimal = 0.0
                                Dim dePorcentajeDeIncremento As Decimal = 0.0

                                Dim loValorPuntos As Long = 0

                                ' instancia las clase
                                Dim objdatos As New cla_TIPOCONS
                                Dim tbl As New DataTable

                                tbl = objdatos.fun_buscar_TICODEPA_X_TICOMUNI_X_TICOCLCO_X_TICOCLSE_X_TIPOCONS_X_CLASCONS_MANT_TIPOCONS(stDepartamento, stMunicipio, inClaseConstruccion, inClaseSector, stIdentificador)

                                If tbl.Rows.Count > 0 Then

                                    ' almacena valor de los factores
                                    deValorFactorA = CType(tbl.Rows(0).Item("TICOFAC1"), Decimal)
                                    deValorFactorB = CType(tbl.Rows(0).Item("TICOFAC2"), Decimal)
                                    dePorcentajeDeIncremento = CType(tbl.Rows(0).Item("TICOPOIN"), Decimal)

                                    ' declara la variable
                                    Dim stModoDeLiquidacion As String = Trim(tbl.Rows(0).Item("TICOMOLI"))

                                    ' liquidacion 'NINGUNO'
                                    If Trim(stModoDeLiquidacion) = "Ninguno" Then
                                        loValorConstruccionPrivado = 0
                                    End If

                                    ' Liquidacion 'POTENCIAL'
                                    If Trim(stModoDeLiquidacion) = "Potencial" Then
                                        deValorFactorA = (deValorFactorA * dePorcentajeDeIncremento)

                                        loValorPuntos = deValorFactorA * Pow(inPuntoConstruccion, deValorFactorB)
                                        loValorConstruccionPrivado += (deAreaDeConstruccion * loValorPuntos)

                                        ' valor m2 de constru
                                        vl_loPROMCONS = (loValorPuntos / CDec("0." & Me.nudPorcentajeComercial.Value))
                                    End If

                                    ' liquidacion 'EXPONENCIAL'
                                    If Trim(stModoDeLiquidacion) = "Exponencial" Then
                                        deValorFactorA = (deValorFactorA * dePorcentajeDeIncremento)

                                        loValorPuntos = deValorFactorA * Exp(deValorFactorB * inPuntoConstruccion)
                                        loValorConstruccionPrivado += (deAreaDeConstruccion * loValorPuntos)

                                        vl_loPROMCONS = (loValorPuntos / CDec("0." & Me.nudPorcentajeComercial.Value))
                                    End If

                                    ' liquidacion 'LINEAL'
                                    If Trim(stModoDeLiquidacion) = "Lineal" Then
                                        deValorFactorA = (deValorFactorA * dePorcentajeDeIncremento)
                                        deValorFactorB = (deValorFactorB * dePorcentajeDeIncremento)

                                        loValorPuntos = (deValorFactorA + inPuntoConstruccion) * deValorFactorB
                                        loValorConstruccionPrivado += (deAreaDeConstruccion * loValorPuntos)

                                        vl_loPROMCONS = (loValorPuntos / CDec("0." & Me.nudPorcentajeComercial.Value))
                                    End If

                                End If

                            End If
                        End If

                    Next

                End If

                ' retorna el valor de la construccion
                Return loValorConstruccionPrivado

            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Function

    Private Function fun_ConsultarAvaluoTotal() As Long

        Try
            Dim loTotalAvaluo As Long = 0

            loTotalAvaluo = CType(vl_loFPAVVATP, Long) + CType(vl_loFPAVVATC, Long) + CType(vl_loFPAVVACP, Long) + CType(vl_loFPAVVACC, Long)

            Return loTotalAvaluo

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Function

#End Region

#Region "PROCEDIMIENTOS"

    Private Sub pro_LimpiarCampos()

        Me.txtFIPRNUFI.Text = ""
        Me.txtFIPRDIRE.Text = ""
        Me.txtFIPRMUNI.Text = ""
        Me.txtFIPRCORR.Text = ""
        Me.txtFIPRBARR.Text = ""
        Me.txtFIPRMANZ.Text = ""
        Me.txtFIPRPRED.Text = ""
        Me.txtFIPREDIF.Text = ""
        Me.txtFIPRUNPR.Text = ""
        Me.txtFIPRCLSE.Text = ""
        Me.txtFIPRESTA.Text = ""
        Me.txtFIPRCAPR.Text = ""
        Me.lblCantidadPredios.Text = "0"
        Me.lblCantidadZonas.Text = "0"
        Me.lblPuntosInvestigados.Text = "0"
        Me.lblPuntosRequeridos.Text = "0"

        Me.cmdCONSULTAR.Enabled = True

        Me.strBARRESTA.Items(2).Text = "Registros : 0"

        Me.dgvCONSULTA.DataSource = New DataTable

    End Sub
    Private Sub pro_VerificarDatos()

        '*** VERIFICA DATOS DE FICHA PREDIAL ***

        If Trim(Me.txtFIPRNUFI.Text) = "" Then
            stFIPRNUFI = "%"
        Else
            stFIPRNUFI = Trim(Me.txtFIPRNUFI.Text)
        End If

        If Trim(Me.txtFIPRDIRE.Text) = "" Then
            stFIPRDIRE = "%"
        Else
            stFIPRDIRE = Trim(Me.txtFIPRDIRE.Text)
        End If

        If Trim(Me.txtFIPRMUNI.Text) = "" Then
            stFIPRMUNI = "%"
        Else
            stFIPRMUNI = Trim(Me.txtFIPRMUNI.Text)
        End If

        If Trim(Me.txtFIPRCORR.Text) = "" Then
            stFIPRCORR = "%"
        Else
            stFIPRCORR = Trim(Me.txtFIPRCORR.Text)
        End If

        If Trim(Me.txtFIPRBARR.Text) = "" Then
            stFIPRBARR = "%"
        Else
            stFIPRBARR = Trim(Me.txtFIPRBARR.Text)
        End If

        If Trim(Me.txtFIPRMANZ.Text) = "" Then
            stFIPRMANZ = "%"
        Else
            stFIPRMANZ = Trim(Me.txtFIPRMANZ.Text)
        End If

        If Trim(Me.txtFIPRPRED.Text) = "" Then
            stFIPRPRED = "%"
        Else
            stFIPRPRED = Trim(Me.txtFIPRPRED.Text)
        End If

        If Trim(Me.txtFIPREDIF.Text) = "" Then
            stFIPREDIF = "%"
        Else
            stFIPREDIF = Trim(Me.txtFIPREDIF.Text)
        End If

        If Trim(Me.txtFIPRUNPR.Text) = "" Then
            stFIPRUNPR = "%"
        Else
            stFIPRUNPR = Trim(Me.txtFIPRUNPR.Text)
        End If

        If Trim(Me.txtFIPRCLSE.Text) = "" Then
            stFIPRCLSE = "%"
        Else
            stFIPRCLSE = Trim(Me.txtFIPRCLSE.Text)
        End If

        If Trim(Me.txtFIPRESTA.Text) = "" Then
            stFIPRESTA = "%"
        Else
            stFIPRESTA = Trim(Me.txtFIPRESTA.Text)
        End If

        If Trim(Me.txtFIPRCAPR.Text) = "" Then
            stFIPRCAPR = "%"
        Else
            stFIPRCAPR = Trim(Me.txtFIPRCAPR.Text)
        End If

    End Sub
    Private Sub pro_GuardarConsulta()

        Guardar_stFIPRNUFI = Trim(Me.txtFIPRNUFI.Text)
        Guardar_stFIPRDIRE = Trim(Me.txtFIPRDIRE.Text)
        Guardar_stFIPRMUNI = Trim(Me.txtFIPRMUNI.Text)
        Guardar_stFIPRCORR = Trim(Me.txtFIPRCORR.Text)
        Guardar_stFIPRBARR = Trim(Me.txtFIPRBARR.Text)
        Guardar_stFIPRMANZ = Trim(Me.txtFIPRMANZ.Text)
        Guardar_stFIPRPRED = Trim(Me.txtFIPRPRED.Text)
        Guardar_stFIPREDIF = Trim(Me.txtFIPREDIF.Text)
        Guardar_stFIPRUNPR = Trim(Me.txtFIPRUNPR.Text)
        Guardar_stFIPRCLSE = Trim(Me.txtFIPRCLSE.Text)
        Guardar_stFIPRESTA = Trim(Me.txtFIPRESTA.Text)
        Guardar_stFIPRCAPR = Trim(Me.txtFIPRCAPR.Text)

    End Sub
    Private Sub pro_ObtenerConsulta()

        Me.txtFIPRNUFI.Text = Guardar_stFIPRNUFI
        Me.txtFIPRDIRE.Text = Guardar_stFIPRDIRE
        Me.txtFIPRMUNI.Text = Guardar_stFIPRMUNI
        Me.txtFIPRCORR.Text = Guardar_stFIPRCORR
        Me.txtFIPRBARR.Text = Guardar_stFIPRBARR
        Me.txtFIPRMANZ.Text = Guardar_stFIPRMANZ
        Me.txtFIPRPRED.Text = Guardar_stFIPRPRED
        Me.txtFIPREDIF.Text = Guardar_stFIPREDIF
        Me.txtFIPRUNPR.Text = Guardar_stFIPRUNPR
        Me.txtFIPRCLSE.Text = Guardar_stFIPRCLSE
        Me.txtFIPRESTA.Text = Guardar_stFIPRESTA
        Me.txtFIPRCAPR.Text = Guardar_stFIPRCAPR

    End Sub
    Private Sub pro_PermisoControlDeComandos()

        Try

            Me.cmdExportarExcel.Enabled = fun_PermisoControlDeComandos(vp_usuario, Me.Name, Me.cmdExportarExcel.Name)
            Me.cmdExportarPlano.Enabled = fun_PermisoControlDeComandos(vp_usuario, Me.Name, Me.cmdExportarPlano.Name)

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub pro_FormatoAvaluosComercialesObservatorio()

        Try
            Me.cmdCONSULTAR.Enabled = False

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

            ' guarda la consulta
            pro_GuardarConsulta()

            ' verifica los datos de los campos
            pro_VerificarDatos()

            ' Concatena la condicion de la consulta
            ParametrosConsulta += "Select * from OBSEINMO "

            ParametrosConsulta += "where "
            ParametrosConsulta += "ObinNufi like '" & stFIPRNUFI & "' and "
            ParametrosConsulta += "ObinDire like '" & stFIPRDIRE & "' and "
            ParametrosConsulta += "ObinMuni like '" & stFIPRMUNI & "' and "
            ParametrosConsulta += "ObinCorr like '" & stFIPRCORR & "' and "
            ParametrosConsulta += "ObinBarr like '" & stFIPRBARR & "' and "
            ParametrosConsulta += "ObinManz like '" & stFIPRMANZ & "' and "
            ParametrosConsulta += "ObinPred like '" & stFIPRPRED & "' and "
            ParametrosConsulta += "ObinEdif like '" & stFIPREDIF & "' and "
            ParametrosConsulta += "ObinUnpr like '" & stFIPRUNPR & "' and "
            ParametrosConsulta += "ObinClse like '" & stFIPRCLSE & "' and "
            ParametrosConsulta += "ObinCapr like '" & stFIPRCAPR & "' and "
            ParametrosConsulta += "ObinEsta like '" & stFIPRESTA & "' "
            ParametrosConsulta += "order by ObinNufi,ObinClse,ObinMuni,ObinCorr,ObinBarr,ObinManz,ObinPred,ObinEdif,ObinUnpr"

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

            ' cuenta los registros
            If dt.Rows.Count > 0 Then

                If MessageBox.Show("¿ Desea continuar ? " & "Nro de registros: " & dt.Rows.Count, "Mensaje ...", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then

                    Dim dr_CONSULTA As DataRow

                    dt_CONSULTA = New DataTable

                    ' crea las columnas
                    dt_CONSULTA.Columns.Add(New DataColumn("Zona_Fisica", GetType(String)))
                    dt_CONSULTA.Columns.Add(New DataColumn("Cedula_catastral", GetType(String)))
                    dt_CONSULTA.Columns.Add(New DataColumn("Municipio", GetType(String)))
                    dt_CONSULTA.Columns.Add(New DataColumn("Corregi", GetType(String)))
                    dt_CONSULTA.Columns.Add(New DataColumn("Barrio", GetType(String)))
                    dt_CONSULTA.Columns.Add(New DataColumn("Manzana", GetType(String)))
                    dt_CONSULTA.Columns.Add(New DataColumn("Predio", GetType(String)))
                    dt_CONSULTA.Columns.Add(New DataColumn("Edificio", GetType(String)))
                    dt_CONSULTA.Columns.Add(New DataColumn("Unidad", GetType(String)))
                    dt_CONSULTA.Columns.Add(New DataColumn("Sector", GetType(String)))
                    dt_CONSULTA.Columns.Add(New DataColumn("Nro_Ficha", GetType(String)))
                    dt_CONSULTA.Columns.Add(New DataColumn("Area_Terreno", GetType(String)))
                    dt_CONSULTA.Columns.Add(New DataColumn("Area_Construccion", GetType(String)))
                    dt_CONSULTA.Columns.Add(New DataColumn("Avaluo_Terreno", GetType(String)))
                    dt_CONSULTA.Columns.Add(New DataColumn("Avaluo_Construccion", GetType(String)))
                    dt_CONSULTA.Columns.Add(New DataColumn("Avaluo_Comercial", GetType(String)))
                    dt_CONSULTA.Columns.Add(New DataColumn("Avaluo_Catastral", GetType(String)))
                    dt_CONSULTA.Columns.Add(New DataColumn("Prom_Terreno", GetType(String)))
                    dt_CONSULTA.Columns.Add(New DataColumn("Prom_Construccion", GetType(String)))
                    dt_CONSULTA.Columns.Add(New DataColumn("Identificador", GetType(String)))
                    dt_CONSULTA.Columns.Add(New DataColumn("Puntos", GetType(String)))
                    dt_CONSULTA.Columns.Add(New DataColumn("Datos_Suministrados", GetType(String)))
                    dt_CONSULTA.Columns.Add(New DataColumn("Observaciones", GetType(String)))

                    ' declara la variable
                    Dim stZonaFisica As String = ""
                    Dim stCedulaCatastral As String = ""
                    Dim stMunicipio As String = ""
                    Dim stCorregi As String = ""
                    Dim stBarrio As String = ""
                    Dim stManzana As String = ""
                    Dim stPredio As String = ""
                    Dim stEdificio As String = ""
                    Dim stUnidad As String = ""
                    Dim stSector As String = ""
                    Dim stNro_Ficha As String = ""
                    Dim stArea_Terreno As String = ""
                    Dim stArea_Construccion As String = ""
                    Dim stAvaluo_Terreno As String = ""
                    Dim stAvaluo_Construccion As String = ""
                    Dim stAvaluo_Comercial As String = ""
                    Dim stAvaluo_Catastral As String = ""
                    Dim stProm_Terreno As String = ""
                    Dim stProm_Construccion As String = ""
                    Dim stIdentificador As String = ""
                    Dim stPuntos As String = ""
                    Dim stDatos_Suministrados As String = ""
                    Dim stObservaciones As String = ""

                    ' Valores predeterminados ProgressBar
                    inProceso = 0
                    pbPROCESO.Value = 0
                    pbPROCESO.Maximum = dt.Rows.Count
                    Timer1.Enabled = True

                    Dim i As Integer = 0

                    For i = 0 To dt.Rows.Count - 1

                        ' llena las variables de la ficha predial
                        stZonaFisica = Trim(dt.Rows(i).Item("OBINZOFI"))
                        stMunicipio = fun_Formato_Mascara_3_Reales(Trim(dt.Rows(i).Item("OBINMUNI")))
                        stCorregi = fun_Formato_Mascara_3_Reales(Trim(dt.Rows(i).Item("OBINCORR")))

                        If CInt(dt.Rows(i).Item("OBINCLSE")) = 2 Then
                            stBarrio = "000"
                        Else
                            stBarrio = fun_Formato_Mascara_3_Reales(Trim(dt.Rows(i).Item("OBINBARR")))
                        End If

                        stManzana = fun_Formato_Mascara_4_Reales(Trim(dt.Rows(i).Item("OBINMANZ")))
                        stPredio = fun_Formato_Mascara_5_Reales(Trim(dt.Rows(i).Item("OBINPRED")))
                        stEdificio = fun_Formato_Mascara_4_Reales(Trim(dt.Rows(i).Item("OBINEDIF")))
                        stUnidad = fun_Formato_Mascara_5_Reales(Trim(dt.Rows(i).Item("OBINUNPR")))
                        stSector = Trim(dt.Rows(i).Item("OBINCLSE"))
                        stCedulaCatastral = stMunicipio & "-" & stSector & "-" & stCorregi & "-" & stBarrio & "-" & stManzana & "-" & stPredio & "-" & stEdificio & "-" & stUnidad
                        stNro_Ficha = Trim(dt.Rows(i).Item("OBINNUFI"))
                        stArea_Terreno = Trim(dt.Rows(i).Item("OBINARTE"))
                        stArea_Construccion = Trim(dt.Rows(i).Item("OBINARCO"))
                        stAvaluo_Terreno = (CLng(dt.Rows(i).Item("OBINAVCO")) * Me.nudVALOTERR.Value) / 100
                        stAvaluo_Construccion = (CLng(dt.Rows(i).Item("OBINAVCO")) * Me.nudVALOCONS.Value) / 100
                        stAvaluo_Comercial = Trim(dt.Rows(i).Item("OBINAVCO"))
                        stAvaluo_Catastral = Trim(dt.Rows(i).Item("OBINAVCA"))
                        stProm_Terreno = ""
                        stProm_Construccion = ""
                        stIdentificador = Trim(dt.Rows(i).Item("OBINTICO"))
                        stPuntos = Trim(dt.Rows(i).Item("OBINPUCA"))
                        stDatos_Suministrados = ""
                        stObservaciones = Trim(dt.Rows(i).Item("OBINOBSE"))

                        ' inserta un nuevo registro
                        dr_CONSULTA = dt_CONSULTA.NewRow()

                        dr_CONSULTA("Zona_Fisica") = Trim(stZonaFisica)
                        dr_CONSULTA("Cedula_catastral") = Trim(stCedulaCatastral)
                        dr_CONSULTA("Municipio") = Trim(stMunicipio)
                        dr_CONSULTA("Corregi") = Trim(stCorregi)
                        dr_CONSULTA("Barrio") = Trim(stBarrio)
                        dr_CONSULTA("Manzana") = Trim(stManzana)
                        dr_CONSULTA("Predio") = Trim(stPredio)
                        dr_CONSULTA("Edificio") = Trim(stEdificio)
                        dr_CONSULTA("Unidad") = Trim(stUnidad)
                        dr_CONSULTA("Sector") = Trim(stSector)
                        dr_CONSULTA("Nro_Ficha") = Trim(stNro_Ficha)
                        dr_CONSULTA("Area_Terreno") = Trim(stArea_Terreno)
                        dr_CONSULTA("Area_Construccion") = Trim(stArea_Construccion)
                        dr_CONSULTA("Avaluo_Terreno") = Trim(stAvaluo_Terreno)
                        dr_CONSULTA("Avaluo_Construccion") = Trim(stAvaluo_Construccion)
                        dr_CONSULTA("Avaluo_Comercial") = Trim(stAvaluo_Comercial)
                        dr_CONSULTA("Avaluo_Catastral") = Trim(stAvaluo_Catastral)
                        dr_CONSULTA("Prom_Terreno") = Trim(stProm_Terreno)
                        dr_CONSULTA("Prom_Construccion") = Trim(stProm_Construccion)
                        dr_CONSULTA("Identificador") = Trim(stIdentificador)
                        dr_CONSULTA("Puntos") = Trim(stPuntos)
                        dr_CONSULTA("Datos_Suministrados") = Trim(stDatos_Suministrados)
                        dr_CONSULTA("Observaciones") = Trim(stObservaciones)

                        dt_CONSULTA.Rows.Add(dr_CONSULTA)

                        ' Incrementa la barra
                        inProceso = inProceso + 1
                        pbPROCESO.Value = inProceso

                    Next

                    ' llena el datagridview
                    Me.dgvCONSULTA.DataSource = dt_CONSULTA

                    Me.dgvCONSULTA.Columns("Avaluo_Terreno").DefaultCellStyle.Format = "c"
                    Me.dgvCONSULTA.Columns("Avaluo_Construccion").DefaultCellStyle.Format = "c"
                    Me.dgvCONSULTA.Columns("Avaluo_Comercial").DefaultCellStyle.Format = "c"
                    Me.dgvCONSULTA.Columns("Avaluo_Catastral").DefaultCellStyle.Format = "c"

                End If

            Else
                Me.dgvCONSULTA.DataSource = New DataTable
                mod_MENSAJE.Consulta_No_Encontro_Registros()

            End If

            ' Numero de registros recuperados
            Me.strBARRESTA.Items(2).Text = "Registros : " & dgvCONSULTA.RowCount.ToString

            Me.pbPROCESO.Value = 0

            Me.cmdCONSULTAR.Enabled = True
            Me.dgvCONSULTA.Focus()

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub pro_EstadisticaPuntosDeInvestigacion()

        Try
            Me.cmdCONSULTAR.Enabled = False

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

            ' guarda la consulta
            pro_GuardarConsulta()

            ' verifica los datos de los campos
            pro_VerificarDatos()

            ' Concatena la condicion de la consulta
            ParametrosConsulta += "Select * from MANT_ZONAFISI "

            ParametrosConsulta += "where "
            ParametrosConsulta += "ZofiMuni like '" & stFIPRMUNI & "' and "
            ParametrosConsulta += "ZofiClse like '" & stFIPRCLSE & "' and "
            ParametrosConsulta += "ZofiEsta like '" & stFIPRESTA & "' "

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

            ' cuenta los registros
            If dt.Rows.Count > 0 Then

                If MessageBox.Show("¿ Desea continuar ? " & "Nro de registros: " & dt.Rows.Count, "Mensaje ...", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then

                    Dim dr_CONSULTA As DataRow

                    dt_CONSULTA = New DataTable

                    ' crea las columnas
                    dt_CONSULTA.Columns.Add(New DataColumn("Zona_Fisica", GetType(String)))
                    dt_CONSULTA.Columns.Add(New DataColumn("Descripcion", GetType(String)))
                    dt_CONSULTA.Columns.Add(New DataColumn("Nro_Predios", GetType(Integer)))
                    dt_CONSULTA.Columns.Add(New DataColumn("%", GetType(String)))
                    dt_CONSULTA.Columns.Add(New DataColumn("Nro_Puntos_Requeridos", GetType(Integer)))
                    dt_CONSULTA.Columns.Add(New DataColumn("Nro_Puntos_Investigados", GetType(Integer)))

                    ' declara la variable
                    Dim stDepartamento As String = ""
                    Dim stMunicipio As String = ""
                    Dim stSector As Integer = 0
                    Dim stPuntosRequeridos As Integer = 0
                    Dim stZona_Fisica As String = ""
                    Dim stDescripcion As String = ""
                    Dim stPorcentaje As String = ""
                    Dim stNro_Predios As String = "0"
                    Dim stNro_Puntos_Requeridos As String = "0"
                    Dim stNro_Puntos_Investigados As String = "0"

                    ' lista la cantidad de predios
                    inCantidadPrediosNivelPredio = fun_ListarCantidadDePrediosNivelPredio()
                    inCantidadPrediosNivelunidadPredial = fun_ListarCantidadDePrediosNivelUnidadPredial()
                    inCantidadTotalZonas = fun_ListarCantidadZonasFisicas(Trim(stFIPRMUNI), Trim(stFIPRCLSE))

                    inCantidadZonas = 0
                    inPuntosInvestigados = 0
                    inPuntosRequeridos = 0
                    inTotalPuntosRequeridos = 0

                    ' Valores predeterminados ProgressBar
                    inProceso = 0
                    pbPROCESO.Value = 0
                    pbPROCESO.Maximum = dt.Rows.Count
                    Timer1.Enabled = True

                    Dim i As Integer = 0

                    For i = 0 To dt.Rows.Count - 1

                        ' llena las variables de la ficha predial
                        stDepartamento = Trim(dt.Rows(i).Item("ZOFIDEPA"))
                        stMunicipio = Trim(dt.Rows(i).Item("ZOFIMUNI"))
                        stSector = dt.Rows(i).Item("ZOFICLSE")

                        stZona_Fisica = Trim(dt.Rows(i).Item("ZOFICODI"))
                        stDescripcion = Trim(dt.Rows(i).Item("ZOFIDESC"))
                        stNro_Predios = fun_ListarPrediosPorZonaFisica(stZona_Fisica)

                        If inCantidadTotalZonas > 0 Then
                            stPorcentaje = fun_Formato_Decimal_9_Decimales(CInt(fun_ListarPrediosPorZonaFisica(stZona_Fisica)) / CInt(inCantidadTotalZonas))
                        Else
                            stPorcentaje = "0"
                        End If

                        If stPorcentaje = "" Then
                            stPorcentaje = "0"
                        End If

                        Dim obPUNTREQU As New cla_PUNTREQU
                        Dim dtPUNTREQU As New DataTable

                        dtPUNTREQU = obPUNTREQU.fun_Buscar_CODIGO_DEPA_MUNI_CLSE_X_PUNTREQU(stDepartamento, stMunicipio, stSector)

                        If dtPUNTREQU.Rows.Count > 0 Then
                            stPuntosRequeridos = dtPUNTREQU.Rows(0).Item("PUREPURE")
                        Else
                            stPuntosRequeridos = "1"
                        End If

                        stNro_Puntos_Requeridos = CInt((CDec(stPorcentaje) * CInt(stPuntosRequeridos)))
                        stNro_Puntos_Investigados = fun_ListarPrediosPorZonaFisicaObservatorio(stZona_Fisica)

                        ' inserta un nuevo registro
                        dr_CONSULTA = dt_CONSULTA.NewRow()

                        dr_CONSULTA("Zona_Fisica") = Trim(stZona_Fisica)
                        dr_CONSULTA("Descripcion") = Trim(stDescripcion)
                        dr_CONSULTA("%") = Trim(stPorcentaje)
                        dr_CONSULTA("Nro_Predios") = Trim(stNro_Predios)
                        dr_CONSULTA("Nro_Puntos_Requeridos") = CInt(stNro_Puntos_Requeridos)
                        dr_CONSULTA("Nro_Puntos_Investigados") = CInt(stNro_Puntos_Investigados)

                        dt_CONSULTA.Rows.Add(dr_CONSULTA)

                        ' Incrementa la barra
                        inProceso = inProceso + 1
                        pbPROCESO.Value = inProceso

                    Next

                    ' llena el datagridview
                    Me.dgvCONSULTA.DataSource = dt_CONSULTA

                    Dim j As Integer = 0

                    For j = 0 To dt_CONSULTA.Rows.Count - 1

                        inCantidadZonas += CInt(dt_CONSULTA.Rows(j).Item("Nro_Predios"))
                        inPuntosInvestigados += CInt(dt_CONSULTA.Rows(j).Item("Nro_Puntos_Investigados"))
                        inPuntosRequeridos += CInt(dt_CONSULTA.Rows(j).Item("Nro_Puntos_Requeridos"))

                    Next

                    Me.lblCantidadZonas.Text = inCantidadZonas
                    Me.lblPuntosInvestigados.Text = inPuntosInvestigados
                    Me.lblPuntosRequeridos.Text = inPuntosRequeridos

                End If

            Else
                Me.lblCantidadPredios.Text = 0
                Me.lblCantidadZonas.Text = 0
                Me.lblPuntosInvestigados.Text = 0
                Me.lblPuntosRequeridos.Text = 0

                Me.dgvCONSULTA.DataSource = New DataTable
                mod_MENSAJE.Consulta_No_Encontro_Registros()

            End If

            ' Numero de registros recuperados
            Me.strBARRESTA.Items(2).Text = "Registros : " & dgvCONSULTA.RowCount.ToString
            Me.lblCantidadPredios.Text = inCantidadPrediosNivelunidadPredial

            Me.pbPROCESO.Value = 0

            Me.cmdCONSULTAR.Enabled = True
            Me.dgvCONSULTA.Focus()

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub pro_ListadoZonasFisicasUrbanas()

        Try
            Me.cmdCONSULTAR.Enabled = False

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

            ' guarda la consulta
            pro_GuardarConsulta()

            ' verifica los datos de los campos
            pro_VerificarDatos()

            ' Concatena la condicion de la consulta
            ParametrosConsulta += "Select "
            ParametrosConsulta += "vazfzfac as ZonaFisicaDefinitiva, "
            ParametrosConsulta += "VAZFCLSU as ClaseDeSuelo, "
            ParametrosConsulta += "VAZFARAC as AreasDeActividad, "
            ParametrosConsulta += "VAZFTRUR as TratamientoUrbanistico, "
            ParametrosConsulta += "VAZFDEST as Destinacion, "
            ParametrosConsulta += "VAZFSEDE as TipoSegunDestino, "
            ParametrosConsulta += "VAZFSERV as Servicios, "
            ParametrosConsulta += "VAZFVIAS as Vias, "
            ParametrosConsulta += "VAZFTOPO as Topografia "
            ParametrosConsulta += "from MANT_VARIZOFI "
            ParametrosConsulta += "where "
            ParametrosConsulta += "VazfMuni like '" & stFIPRMUNI & "' and "
            ParametrosConsulta += "VazfClse like '" & stFIPRCLSE & "' and "
            ParametrosConsulta += "VazfEsta like '" & stFIPRESTA & "' "
            ParametrosConsulta += "order by vazfzofi"

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

            ' cuenta los registros
            If dt.Rows.Count > 0 Then

                If MessageBox.Show("¿ Desea continuar ? " & "Nro de registros: " & dt.Rows.Count, "Mensaje ...", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then

                    ' llena el datagridview
                    Me.dgvCONSULTA.DataSource = dt

                End If

            Else
                Me.dgvCONSULTA.DataSource = New DataTable
                mod_MENSAJE.Consulta_No_Encontro_Registros()

            End If

            ' Numero de registros recuperados
            Me.strBARRESTA.Items(2).Text = "Registros : " & dgvCONSULTA.RowCount.ToString

            Me.pbPROCESO.Value = 0

            Me.cmdCONSULTAR.Enabled = True
            Me.dgvCONSULTA.Focus()

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub pro_CargarTablasFichaPredial(ByVal inFichaPredial As Integer)

        Dim objdatos As New cla_FIPRAVAL
        Dim ds As New DataSet

        ds = objdatos.fun_Consultar_TABLAS_FICHA_PREDIAL(inFichaPredial)

        ' instancia las tablas
        dt_FICHPRED = New DataTable
        dt_FIPRCONS = New DataTable
        dt_FIPRCACO = New DataTable
        dt_FIPRZOEC = New DataTable

        ' Tabla 0
        dt_FICHPRED = ds.Tables(0)
        ' Tabla 1
        'dt_FIPRDEEC = ds.Tables(1)
        ' Tabla 2
        'dt_FIPRPROP = ds.Tables(2)
        ' Tabla 3
        dt_FIPRCONS = ds.Tables(3)
        ' Tabla 4
        'dt_FIPRCACO = ds.Tables(4)
        ' Tabla 5
        'dt_FIPRLIND = ds.Tables(5)
        ' Tabla 6
        'dt_FIPRCART = ds.Tables(6)
        ' Tabla 7
        dt_FIPRZOEC = ds.Tables(7)
        ' Tabla 8
        'dt_FIPRZOFI = ds.Tables(8)

    End Sub
    Private Sub pro_FormatoAvaluosComercialesOVC()

        Try
            Me.cmdCONSULTAR.Enabled = False

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

            ' guarda la consulta
            pro_GuardarConsulta()

            ' verifica los datos de los campos
            pro_VerificarDatos()

            ' Concatena la condicion de la consulta
            ParametrosConsulta += "Select * from MANT_VARIZOFI "

            ParametrosConsulta += "where "
            ParametrosConsulta += "VazfMuni like '" & stFIPRMUNI & "' and "
            ParametrosConsulta += "VazfClse like '" & stFIPRCLSE & "' and "
            ParametrosConsulta += "VazfEsta like '" & stFIPRESTA & "' "
            ParametrosConsulta += "order by VazfZfac "

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

            ' cuenta los registros
            If dt.Rows.Count > 0 Then

                If MessageBox.Show("¿ Desea continuar ? " & "Nro de registros: " & dt.Rows.Count, "Mensaje ...", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then

                    Dim dr_CONSULTA As DataRow

                    dt_CONSULTA = New DataTable

                    ' crea las columnas
                    dt_CONSULTA.Columns.Add(New DataColumn("Zona_Fisica", GetType(String)))
                    dt_CONSULTA.Columns.Add(New DataColumn("Cedula_catastral", GetType(String)))
                    dt_CONSULTA.Columns.Add(New DataColumn("Nro_Ficha", GetType(String)))
                    dt_CONSULTA.Columns.Add(New DataColumn("Municipio", GetType(String)))
                    dt_CONSULTA.Columns.Add(New DataColumn("Sector", GetType(String)))
                    dt_CONSULTA.Columns.Add(New DataColumn("Corregi", GetType(String)))
                    dt_CONSULTA.Columns.Add(New DataColumn("Barrio", GetType(String)))
                    dt_CONSULTA.Columns.Add(New DataColumn("Manzana", GetType(String)))
                    dt_CONSULTA.Columns.Add(New DataColumn("Predio", GetType(String)))
                    dt_CONSULTA.Columns.Add(New DataColumn("Edificio", GetType(String)))
                    dt_CONSULTA.Columns.Add(New DataColumn("Unidad", GetType(String)))
                    dt_CONSULTA.Columns.Add(New DataColumn("Area_Terreno", GetType(String)))
                    dt_CONSULTA.Columns.Add(New DataColumn("Area_Construccion", GetType(String)))
                    dt_CONSULTA.Columns.Add(New DataColumn("Avaluo_Terreno", GetType(String)))
                    dt_CONSULTA.Columns.Add(New DataColumn("Avaluo_Construccion", GetType(String)))
                    dt_CONSULTA.Columns.Add(New DataColumn("Avaluo_Comercial", GetType(String)))
                    dt_CONSULTA.Columns.Add(New DataColumn("Avaluo_Catastral", GetType(String)))
                    dt_CONSULTA.Columns.Add(New DataColumn("Prom_Terreno", GetType(String)))
                    dt_CONSULTA.Columns.Add(New DataColumn("Prom_Construccion", GetType(String)))
                    dt_CONSULTA.Columns.Add(New DataColumn("Identificador", GetType(String)))
                    dt_CONSULTA.Columns.Add(New DataColumn("Puntos", GetType(String)))

                    ' declara la variable
                    Dim stZonaFisicaDefinitiva As String = ""
                    Dim stZonaFisicaActual As String = ""
                    Dim stCedulaCatastral As String = ""
                    Dim stMunicipio As String = ""
                    Dim stCorregi As String = ""
                    Dim stBarrio As String = ""
                    Dim stManzana As String = ""
                    Dim stPredio As String = ""
                    Dim stEdificio As String = ""
                    Dim stUnidad As String = ""
                    Dim stSector As String = ""
                    Dim stNro_Ficha As String = ""
                    Dim stArea_Terreno As String = ""
                    Dim stArea_Construccion As String = ""
                    Dim stAvaluo_Terreno As String = ""
                    Dim stAvaluo_Construccion As String = ""
                    Dim stAvaluo_Comercial As String = ""
                    Dim stAvaluo_Catastral As String = ""
                    Dim stProm_Terreno As String = ""
                    Dim stProm_Construccion As String = ""
                    Dim stIdentificador As String = ""
                    Dim stPuntos As String = ""

                    ' Valores predeterminados ProgressBar
                    inProceso = 0
                    pbPROCESO.Value = 0
                    pbPROCESO.Maximum = dt.Rows.Count
                    Timer1.Enabled = True

                    Dim i As Integer = 0

                    For i = 0 To dt.Rows.Count - 1

                        ' llena las variables de la ficha predial
                        stZonaFisicaDefinitiva = Trim(dt.Rows(i).Item("VAZFZFAC"))
                        stMunicipio = fun_Formato_Mascara_3_Reales(Trim(dt.Rows(i).Item("VAZFMUNI")))
                        stSector = Trim(dt.Rows(i).Item("VAZFCLSE"))

                        ' homologa la zona fisica definitiva
                        stZonaFisicaActual = fun_HomologarZonaFisicaDefinitiva(stMunicipio, stSector, stZonaFisicaDefinitiva)

                        ' declara la variable
                        Dim dtFIPRZOFI As New DataTable

                        ' realiza la consulta de predios segun zona fisica actual
                        dtFIPRZOFI = fun_ConsultaDePrediosPorZonaFisicaActual(stMunicipio, stSector, stZonaFisicaActual)

                        If dtFIPRZOFI.Rows.Count > 0 Then

                            ' declara la variable
                            Dim i1 As Integer = 0
                            Dim i2 As Integer = ((dtFIPRZOFI.Rows.Count * Me.nudZonaFisica.Value) / 100)
                            Dim inContador As Integer = 0

                            ' establece el maximo valor que es 100
                            If i2 > Me.nudMuestraMaxima.Value Then
                                i2 = Me.nudMuestraMaxima.Value
                            End If

                            ' establece el minimo valor que es 5
                            If i2 >= Me.nudMuestraMinima.Value Then

                                ' recorre la tabla
                                For i1 = 0 To i2 - 1

                                    ' incrementa la variable
                                    inContador += 1

                                    ' declara la variable
                                    Dim inFIPRNUFI As Integer = CInt(dtFIPRZOFI.Rows(i1).Item("FPZFNUFI"))

                                    ' declara la instancia
                                    Dim obFICHPRED As New cla_FICHPRED
                                    Dim dtFICHPRED As New DataTable

                                    dtFICHPRED = obFICHPRED.fun_Consultar_FICHA_PREDIAL_X_NRO_FICHA_PREDIAL(inFIPRNUFI)

                                    If dtFICHPRED.Rows.Count > 0 Then

                                        stCorregi = fun_Formato_Mascara_3_Reales(Trim(dtFICHPRED.Rows(0).Item("FIPRCORR")))
                                        stBarrio = fun_Formato_Mascara_3_Reales(Trim(dtFICHPRED.Rows(0).Item("FIPRBARR")))
                                        stManzana = fun_Formato_Mascara_4_Reales(Trim(dtFICHPRED.Rows(0).Item("FIPRMANZ")))
                                        stPredio = fun_Formato_Mascara_5_Reales(Trim(dtFICHPRED.Rows(0).Item("FIPRPRED")))
                                        stEdificio = fun_Formato_Mascara_4_Reales(Trim(dtFICHPRED.Rows(0).Item("FIPREDIF")))
                                        stUnidad = fun_Formato_Mascara_5_Reales(Trim(dtFICHPRED.Rows(0).Item("FIPRUNPR")))
                                        stCedulaCatastral = stMunicipio & "-" & stSector & "-" & stCorregi & "-" & stBarrio & "-" & stManzana & "-" & stPredio & "-" & stEdificio & "-" & stUnidad
                                        stNro_Ficha = Trim(dtFICHPRED.Rows(0).Item("FIPRNUFI"))

                                        ' limpia la tabla
                                        dt_FICHPRED = New DataTable
                                        dt_FICHPRED = dtFICHPRED

                                        ' limpia las variables
                                        vl_inFPCOPUNT = 0
                                        vl_stFPCOTICO = ""
                                        vl_loPROMTERR = 0
                                        vl_loPROMCONS = 0

                                        pro_CargarTablasFichaPredial(stNro_Ficha)

                                        ' consulta el avalúo catastral
                                        vl_loFPAVATPR = fun_ConsultaAreaTerrenoPrivada()
                                        vl_loFPAVATCO = fun_ConsultarAreaTerrenoComun()
                                        vl_stFPAVACPR = fun_ConsultarAreaConstruccionPrivada()

                                        ' suma el area de terreno privado y comun
                                        stArea_Terreno = vl_loFPAVATPR + vl_loFPAVATCO

                                        ' declaro la instancia
                                        Dim ob_VARIZOFI As New cla_VARIZOFI
                                        Dim dt_VARIZOFI As New DataTable

                                        dt_VARIZOFI = ob_VARIZOFI.fun_Buscar_CODIGO_MUNI_CLSE_X_MANT_VARIZOFI(stMunicipio, stSector, stZonaFisicaDefinitiva)

                                        If dt_VARIZOFI.Rows.Count > 0 Then

                                            ' almaceno los valores de las variables
                                            Dim inValor01 As Integer = dt_VARIZOFI.Rows(0).Item("VAZFVA01")
                                            Dim inValor02 As Integer = dt_VARIZOFI.Rows(0).Item("VAZFVA02")
                                            Dim inValor03 As Integer = dt_VARIZOFI.Rows(0).Item("VAZFVA03")
                                            Dim inValor04 As Integer = dt_VARIZOFI.Rows(0).Item("VAZFVA04")
                                            Dim inValor05 As Integer = dt_VARIZOFI.Rows(0).Item("VAZFVA05")
                                            Dim inValor06 As Integer = dt_VARIZOFI.Rows(0).Item("VAZFVA06")
                                            Dim inValor07 As Integer = dt_VARIZOFI.Rows(0).Item("VAZFVA07")
                                            Dim inValor08 As Integer = dt_VARIZOFI.Rows(0).Item("VAZFVA08")
                                            Dim inValor09 As Integer = dt_VARIZOFI.Rows(0).Item("VAZFVA09")
                                            Dim inValor10 As Integer = dt_VARIZOFI.Rows(0).Item("VAZFVA10")
                                            Dim inMuestra As Integer = CInt(dt_VARIZOFI.Rows(0).Item("VAZFPOBL"))

                                            Dim inPoblacion As Integer = (i2 / inMuestra)

                                            ' limpia la variable
                                            vl_loFPAVVATP = 0

                                            ' 1 a 10
                                            If inContador <= inPoblacion And inValor01 <> 0 Then
                                                vl_loFPAVVATP = CLng(stArea_Terreno) * inValor01
                                                vl_loPROMTERR = inValor01

                                                ' 11 a 20
                                            ElseIf inContador >= ((inPoblacion * 1) + 1) And inContador <= (inPoblacion * 2) And inValor02 <> 0 Then
                                                vl_loFPAVVATP = CLng(stArea_Terreno) * inValor02
                                                vl_loPROMTERR = inValor02

                                                ' 21 a 30
                                            ElseIf inContador >= ((inPoblacion * 2) + 1) And inContador <= (inPoblacion * 3) And inValor03 <> 0 Then
                                                vl_loFPAVVATP = CLng(stArea_Terreno) * inValor03
                                                vl_loPROMTERR = inValor03

                                                ' 31 a 40
                                            ElseIf inContador >= ((inPoblacion * 3) + 1) And inContador <= (inPoblacion * 4) And inValor04 <> 0 Then
                                                vl_loFPAVVATP = CLng(stArea_Terreno) * inValor04
                                                vl_loPROMTERR = inValor04

                                                ' 41 a 50
                                            ElseIf inContador >= ((inPoblacion * 4) + 1) And inContador <= (inPoblacion * 5) And inValor05 <> 0 Then
                                                vl_loFPAVVATP = CLng(stArea_Terreno) * inValor05
                                                vl_loPROMTERR = inValor05

                                                ' 51 a 60
                                            ElseIf inContador >= ((inPoblacion * 5) + 1) And inContador <= (inPoblacion * 6) And inValor06 <> 0 Then
                                                vl_loFPAVVATP = CLng(stArea_Terreno) * inValor06
                                                vl_loPROMTERR = inValor06

                                                ' 61 a 70
                                            ElseIf inContador >= ((inPoblacion * 6) + 1) And inContador <= (inPoblacion * 7) And inValor07 <> 0 Then
                                                vl_loFPAVVATP = CLng(stArea_Terreno) * inValor07
                                                vl_loPROMTERR = inValor07

                                                ' 71 a 80
                                            ElseIf inContador >= ((inPoblacion * 7) + 1) And inContador < (inPoblacion * 8) And inValor08 <> 0 Then
                                                vl_loFPAVVATP = CLng(stArea_Terreno) * inValor08
                                                vl_loPROMTERR = inValor08

                                                ' 81 a 90
                                            ElseIf inContador >= ((inPoblacion * 8) + 1) And inContador <= (inPoblacion * 9) And inValor09 <> 0 Then
                                                vl_loFPAVVATP = CLng(stArea_Terreno) * inValor09
                                                vl_loPROMTERR = inValor09

                                                ' 91 a 100
                                            ElseIf inContador >= ((inPoblacion * 9) + 1) And inContador <= (inPoblacion * 10) And inValor10 <> 0 Then
                                                vl_loFPAVVATP = CLng(stArea_Terreno) * inValor10
                                                vl_loPROMTERR = inValor10

                                            End If

                                            vl_loPROMCONS = 0
                                            vl_loFPAVVACP = fun_ConsultarValorAreaConstruccionPrivada()
                                            vl_loFPAVAVAL = fun_ConsultarAvaluoTotal()

                                            ' almacena el avalúo catastral
                                            stArea_Construccion = CDec(vl_stFPAVACPR) + CDec(vl_stFPAVACCO)
                                            stAvaluo_Terreno = vl_loFPAVVATP
                                            stAvaluo_Construccion = vl_loFPAVVACP
                                            stAvaluo_Comercial = vl_loFPAVAVAL
                                            stAvaluo_Catastral = vl_loFPAVAVAL * 0.6

                                            ' almacena los datos de terreno y consltruccion
                                            stProm_Terreno = vl_loPROMTERR
                                            stProm_Construccion = vl_loPROMCONS
                                            stIdentificador = vl_stFPCOTICO
                                            stPuntos = vl_inFPCOPUNT

                                        End If
                                    End If

                                    ' inserta un nuevo registro
                                    dr_CONSULTA = dt_CONSULTA.NewRow()

                                    dr_CONSULTA("Zona_Fisica") = Trim(stZonaFisicaDefinitiva)
                                    dr_CONSULTA("Cedula_catastral") = Trim(stCedulaCatastral)
                                    dr_CONSULTA("Municipio") = Trim(stMunicipio)
                                    dr_CONSULTA("Corregi") = Trim(stCorregi)
                                    dr_CONSULTA("Barrio") = Trim(stBarrio)
                                    dr_CONSULTA("Manzana") = Trim(stManzana)
                                    dr_CONSULTA("Predio") = Trim(stPredio)
                                    dr_CONSULTA("Edificio") = Trim(stEdificio)
                                    dr_CONSULTA("Unidad") = Trim(stUnidad)
                                    dr_CONSULTA("Sector") = Trim(stSector)
                                    dr_CONSULTA("Nro_Ficha") = Trim(stNro_Ficha)
                                    dr_CONSULTA("Area_Terreno") = Trim(stArea_Terreno)
                                    dr_CONSULTA("Area_Construccion") = Trim(stArea_Construccion)
                                    dr_CONSULTA("Avaluo_Terreno") = Trim(stAvaluo_Terreno)
                                    dr_CONSULTA("Avaluo_Construccion") = Trim(stAvaluo_Construccion)
                                    dr_CONSULTA("Avaluo_Comercial") = Trim(stAvaluo_Comercial)
                                    dr_CONSULTA("Avaluo_Catastral") = Trim(stAvaluo_Catastral)
                                    dr_CONSULTA("Prom_Terreno") = Trim(stProm_Terreno)
                                    dr_CONSULTA("Prom_Construccion") = Trim(stProm_Construccion)
                                    dr_CONSULTA("Identificador") = Trim(stIdentificador)
                                    dr_CONSULTA("Puntos") = Trim(stPuntos)

                                    dt_CONSULTA.Rows.Add(dr_CONSULTA)

                                Next

                            End If
                        End If

                        ' Incrementa la barra
                        inProceso = inProceso + 1
                        pbPROCESO.Value = inProceso

                    Next

                    ' llena el datagridview
                    Me.dgvCONSULTA.DataSource = dt_CONSULTA

                    Me.dgvCONSULTA.Columns("Avaluo_Terreno").DefaultCellStyle.Format = "c"
                    Me.dgvCONSULTA.Columns("Avaluo_Construccion").DefaultCellStyle.Format = "c"
                    Me.dgvCONSULTA.Columns("Avaluo_Comercial").DefaultCellStyle.Format = "c"
                    Me.dgvCONSULTA.Columns("Avaluo_Catastral").DefaultCellStyle.Format = "c"
                    Me.dgvCONSULTA.Columns("Prom_Terreno").DefaultCellStyle.Format = "c"
                    Me.dgvCONSULTA.Columns("Prom_Construccion").DefaultCellStyle.Format = "c"

                End If

            Else
                Me.dgvCONSULTA.DataSource = New DataTable
                mod_MENSAJE.Consulta_No_Encontro_Registros()

            End If

            ' Numero de registros recuperados
            Me.strBARRESTA.Items(2).Text = "Registros : " & dgvCONSULTA.RowCount.ToString

            Me.pbPROCESO.Value = 0

            Me.cmdCONSULTAR.Enabled = True
            Me.dgvCONSULTA.Focus()

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub

#End Region

#Region "MENU"

    Private Sub cmdCONSULTAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCONSULTAR.Click

        Try
            If Me.cboSELECCION.Text = "" Then
                MessageBox.Show("Seleccione una opción de la lista desplegable", "Mensaje...", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            Else
                Dim seleccion As String

                seleccion = Me.cboSELECCION.SelectedIndex

                Select Case seleccion

                    Case 0
                        pro_FormatoAvaluosComercialesObservatorio()
                    Case 1
                        pro_EstadisticaPuntosDeInvestigacion()
                    Case 2
                        pro_ListadoZonasFisicasUrbanas()
                    Case 3
                        pro_FormatoAvaluosComercialesOVC()

                End Select
            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub cmdULTIMACONSULTA_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdULTIMACONSULTA.Click
        pro_LimpiarCampos()
        pro_ObtenerConsulta()
        cmdCONSULTAR.Focus()
    End Sub
    Private Sub cmdPLANO_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExportarPlano.Click
        Try

            If dgvCONSULTA.RowCount > 0 Then

                ' crea la instancia para crear y salvar
                Dim oCrear As New SaveFileDialog

                oCrear.InitialDirectory = My.Computer.FileSystem.SpecialDirectories.MyDocuments
                oCrear.Filter = "Archivo de texto (*.txt)|*.txt|Todos los archivos (*.*)|*.*" 'Colocar varias extensiones
                oCrear.FilterIndex = 1 'coloca por defecto el *.txt
                oCrear.ShowDialog() 'abre la caja de dialogo para guardar


                ' si existe una ruta seleccionada
                If Trim(oCrear.FileName) <> "" Then

                    ' lleba la ruta al label
                    'txtRUTA.Text = oCrear.FileName

                    ' se carga el separador
                    Separador = Trim(txtSEPARADOR.Text)

                    'Nuevo objeto StreamWriter, para acceder al fichero y poder guardar las líneas
                    Using archivo As StreamWriter = New StreamWriter(oCrear.FileName)

                        ' variable para almacenar la línea actual del dataview
                        Dim linea As String = String.Empty

                        With dgvCONSULTA
                            ' Recorrer las filas del dataGridView
                            For fila As Integer = 0 To .RowCount - 1
                                ' vaciar la línea
                                linea = String.Empty

                                ' Recorrer la cantidad de columnas que contiene el dataGridView
                                For col As Integer = 0 To .Columns.Count - 1
                                    ' Almacenar el valor de toda la fila , y cada campo separado por el delimitador
                                    linea = linea & Trim(.Item(col, fila).Value.ToString) & Separador
                                Next

                                ' Escribir una línea con el método WriteLine
                                With archivo
                                    ' eliminar el último caracter ";" de la cadena
                                    linea = linea.Remove(linea.Length - 1).ToString
                                    ' escribir la fila
                                    .WriteLine(linea.ToString)
                                End With
                            Next
                        End With
                    End Using

                    MessageBox.Show("Plano generado correctamente", "Mensaje ...", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)

                    If MessageBox.Show("¿ Desea abrir el archivo plano ?", "Mensaje ...", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then
                        ' Abrir con Process.Start el archivo de texto
                        Process.Start(oCrear.FileName)
                    End If

                Else
                    'txtRUTA.Text = ""
                    txtFIPRNUFI.Focus()
                End If
            Else
                MessageBox.Show("Ejecute la consulta antes de exportar el plano", "Mensaje ...", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            End If
        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try
    End Sub
    Private Sub cmdLIMPIAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdLIMPIAR.Click
        pro_LimpiarCampos()
        Me.txtFIPRNUFI.Focus()
    End Sub
    Private Sub cmdExportarExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExportarExcel.Click
        Try
            If Me.dgvCONSULTA.RowCount = 0 Then
                MessageBox.Show("No existe datos para exportar", "Mensaje ...", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1)
            Else
                Dim oExp As New cla_ExportarTablaExcel
                oExp.DataTableToExcel(CType(Me.dgvCONSULTA.DataSource, DataTable))
            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try
    End Sub
    Private Sub cmdSALIR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSALIR.Click
        Me.txtFIPRNUFI.Focus()
        Me.Close()
    End Sub

#End Region

#Region "FORMULARIO"

#Region "Load"

    Private Sub frm_consulta_propietario_FIPRPROP_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        pro_LimpiarCampos()
        Me.txtFIPRNUFI.Focus()

        pro_PermisoControlDeComandos()
    End Sub

#End Region

#Region "GotFocus"

    Private Sub txtFIPRNUFI_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFIPRNUFI.GotFocus
        txtFIPRNUFI.SelectionStart = 0
        txtFIPRNUFI.SelectionLength = Len(txtFIPRNUFI.Text)
        strBARRESTA.Items(0).Text = txtFIPRNUFI.AccessibleDescription
    End Sub
    Private Sub txtFIPRDIRE_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFIPRDIRE.GotFocus
        txtFIPRDIRE.SelectionStart = 0
        txtFIPRDIRE.SelectionLength = Len(txtFIPRDIRE.Text)
        strBARRESTA.Items(0).Text = txtFIPRDIRE.AccessibleDescription
    End Sub
    Private Sub txtFIPRMUNI_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFIPRMUNI.GotFocus
        txtFIPRMUNI.SelectionStart = 0
        txtFIPRMUNI.SelectionLength = Len(txtFIPRMUNI.Text)
        strBARRESTA.Items(0).Text = txtFIPRMUNI.AccessibleDescription
    End Sub
    Private Sub txtFIPRCORR_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFIPRCORR.GotFocus
        txtFIPRCORR.SelectionStart = 0
        txtFIPRCORR.SelectionLength = Len(txtFIPRCORR.Text)
        strBARRESTA.Items(0).Text = txtFIPRCORR.AccessibleDescription
    End Sub
    Private Sub txtFIPRBARR_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFIPRBARR.GotFocus
        txtFIPRBARR.SelectionStart = 0
        txtFIPRBARR.SelectionLength = Len(txtFIPRBARR.Text)
        strBARRESTA.Items(0).Text = txtFIPRBARR.AccessibleDescription
    End Sub
    Private Sub txtFIPRMANZ_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFIPRMANZ.GotFocus
        txtFIPRMANZ.SelectionStart = 0
        txtFIPRMANZ.SelectionLength = Len(txtFIPRMANZ.Text)
        strBARRESTA.Items(0).Text = txtFIPRMANZ.AccessibleDescription
    End Sub
    Private Sub txtFIPRPRED_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFIPRPRED.GotFocus
        txtFIPRPRED.SelectionStart = 0
        txtFIPRPRED.SelectionLength = Len(txtFIPRPRED.Text)
        strBARRESTA.Items(0).Text = txtFIPRPRED.AccessibleDescription
    End Sub
    Private Sub txtFIPREDIF_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFIPREDIF.GotFocus
        txtFIPREDIF.SelectionStart = 0
        txtFIPREDIF.SelectionLength = Len(txtFIPREDIF.Text)
        strBARRESTA.Items(0).Text = txtFIPREDIF.AccessibleDescription
    End Sub
    Private Sub txtFIPRUNPR_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFIPRUNPR.GotFocus
        txtFIPRUNPR.SelectionStart = 0
        txtFIPRUNPR.SelectionLength = Len(txtFIPRUNPR.Text)
        strBARRESTA.Items(0).Text = txtFIPRUNPR.AccessibleDescription
    End Sub
    Private Sub txtFIPRCLSE_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFIPRCLSE.GotFocus
        txtFIPRCLSE.SelectionStart = 0
        txtFIPRCLSE.SelectionLength = Len(txtFIPRCLSE.Text)
        strBARRESTA.Items(0).Text = txtFIPRCLSE.AccessibleDescription
    End Sub
    Private Sub txtFIPRESTA_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFIPRESTA.GotFocus
        txtFIPRESTA.SelectionStart = 0
        txtFIPRESTA.SelectionLength = Len(txtFIPRESTA.Text)
        strBARRESTA.Items(0).Text = txtFIPRESTA.AccessibleDescription
    End Sub
    Private Sub cboFPPRSEXO_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFIPRCAPR.GotFocus
        txtFIPRCAPR.SelectionStart = 0
        txtFIPRCAPR.SelectionLength = Len(txtFIPRCAPR.Text)
        strBARRESTA.Items(0).Text = txtFIPRCAPR.AccessibleDescription
    End Sub
    Private Sub txtGotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFIPRCLSE.GotFocus, txtFIPRCAPR.GotFocus
        pp_pro_SobrearCampo(sender)
        pp_pro_DescripcionCampo(Me.strBARRESTA.Items(0), sender)
    End Sub


    Private Sub cmdCONSULTAR_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdCONSULTAR.GotFocus
        strBARRESTA.Items(0).Text = cmdCONSULTAR.AccessibleDescription
    End Sub
    Private Sub cmdPLANO_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdExportarPlano.GotFocus
        strBARRESTA.Items(0).Text = cmdExportarPlano.AccessibleDescription
    End Sub
    Private Sub cmdSALIR_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdSALIR.GotFocus
        strBARRESTA.Items(0).Text = cmdSALIR.AccessibleDescription
    End Sub
    Private Sub cmdLIMPIAR_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdLIMPIAR.GotFocus
        strBARRESTA.Items(0).Text = cmdLIMPIAR.AccessibleDescription
    End Sub
    Private Sub dgvCONSULTA_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvCONSULTA.GotFocus
        strBARRESTA.Items(0).Text = dgvCONSULTA.AccessibleDescription
    End Sub
    Private Sub cmdExportarExcel_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdExportarExcel.GotFocus
        strBARRESTA.Items(0).Text = cmdExportarExcel.AccessibleDescription
    End Sub

#End Region

#Region "KeyPress"

    Private Sub txtFIPRNUFI_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFIPRNUFI.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            txtFIPRDIRE.Focus()
        End If

    End Sub
    Private Sub txtFIPRDIRE_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFIPRDIRE.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            txtFIPRMUNI.Focus()
        End If
    End Sub
    Private Sub txtFIPRMUNI_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFIPRMUNI.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            txtFIPRCORR.Focus()
        End If

    End Sub
    Private Sub txtFIPRCORR_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFIPRCORR.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            txtFIPRBARR.Focus()
        End If

    End Sub
    Private Sub txtFIPRBARR_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFIPRBARR.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            txtFIPRMANZ.Focus()
        End If

    End Sub
    Private Sub txtFIPRMANZ_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFIPRMANZ.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            txtFIPRPRED.Focus()
        End If

    End Sub
    Private Sub txtFIPRPRED_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFIPRPRED.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            txtFIPREDIF.Focus()
        End If

    End Sub
    Private Sub txtFIPREDIF_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFIPREDIF.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            txtFIPRUNPR.Focus()
        End If

    End Sub
    Private Sub txtFIPRUNPR_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFIPRUNPR.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            txtFIPRESTA.Focus()
        End If

    End Sub
    Private Sub txtFIPRCLSE_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFIPRCLSE.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            cmdCONSULTAR.Focus()
        End If
    End Sub
    Private Sub txtFIPRESTA_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFIPRESTA.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            txtFIPRCLSE.Focus()
        End If
    End Sub
    Private Sub txtFIPRCASU_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            txtFIPRCAPR.Focus()
        End If
    End Sub
    Private Sub txtFIPRCAPR_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFIPRCAPR.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            txtFIPRCLSE.Focus()
        End If
    End Sub
    Private Sub txtKeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFIPRCLSE.KeyPress, txtFIPRCAPR.KeyPress

        If e.KeyChar = Convert.ToChar(Keys.Enter) Or e.KeyChar = Convert.ToChar(Keys.Tab) Then
            pp_pro_SaltarCampo()
        End If

    End Sub

#End Region

#Region "KeyDown"

    Private Sub cmdCONSULTAR_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cmdCONSULTAR.KeyDown, txtFIPRNUFI.KeyDown, txtFIPRDIRE.KeyDown, txtFIPRMUNI.KeyDown, txtFIPRCORR.KeyDown, txtFIPRBARR.KeyDown, txtFIPRMANZ.KeyDown, txtFIPRPRED.KeyDown, txtFIPREDIF.KeyDown, txtFIPRUNPR.KeyDown, txtFIPRCLSE.KeyDown, txtFIPRESTA.KeyDown, dgvCONSULTA.KeyDown, txtFIPRCAPR.KeyDown
        If e.KeyCode = Keys.F8 Then
            cmdCONSULTAR.PerformClick()
        End If

        If e.KeyCode = Keys.F7 Then
            cmdULTIMACONSULTA.PerformClick()
        End If

    End Sub

#End Region

#Region "Validated"

    Private Sub txtFIPRMUNI_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFIPRMUNI.Validated
        If Me.txtFIPRMUNI.Text <> "" And fun_Verificar_Dato_Numerico_Evento_Validated(Me.txtFIPRMUNI.Text) = True Then
            Me.txtFIPRMUNI.Text = fun_Formato_Mascara_3_String(Me.txtFIPRMUNI.Text)
        End If
    End Sub
    Private Sub txtFIPRCORR_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFIPRCORR.Validated
        If Me.txtFIPRCORR.Text <> "" And fun_Verificar_Dato_Numerico_Evento_Validated(Me.txtFIPRCORR.Text) = True Then
            Me.txtFIPRCORR.Text = fun_Formato_Mascara_2_String(Me.txtFIPRCORR.Text)
        End If
    End Sub
    Private Sub txtFIPRBARR_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFIPRBARR.Validated
        If Me.txtFIPRBARR.Text <> "" And fun_Verificar_Dato_Numerico_Evento_Validated(Me.txtFIPRBARR.Text) = True Then
            Me.txtFIPRBARR.Text = fun_Formato_Mascara_3_String(Me.txtFIPRBARR.Text)
        End If
    End Sub
    Private Sub txtFIPRMANZ_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFIPRMANZ.Validated
        If Me.txtFIPRMANZ.Text <> "" And fun_Verificar_Dato_Numerico_Evento_Validated(Me.txtFIPRMANZ.Text) = True Then
            Me.txtFIPRMANZ.Text = fun_Formato_Mascara_3_String(Me.txtFIPRMANZ.Text)
        End If
    End Sub
    Private Sub txtFIPRPRED_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFIPRPRED.Validated
        If Me.txtFIPRPRED.Text <> "" And fun_Verificar_Dato_Numerico_Evento_Validated(Me.txtFIPRPRED.Text) = True Then
            Me.txtFIPRPRED.Text = fun_Formato_Mascara_5_String(Me.txtFIPRPRED.Text)
        End If
    End Sub
    Private Sub txtFIPREDIF_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFIPREDIF.Validated
        If Me.txtFIPREDIF.Text <> "" And fun_Verificar_Dato_Numerico_Evento_Validated(Me.txtFIPREDIF.Text) = True Then
            Me.txtFIPREDIF.Text = fun_Formato_Mascara_3_String(Me.txtFIPREDIF.Text)
        End If
    End Sub
    Private Sub txtFIPRUNPR_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFIPRUNPR.Validated
        If Me.txtFIPRUNPR.Text <> "" And fun_Verificar_Dato_Numerico_Evento_Validated(Me.txtFIPRUNPR.Text) = True Then
            Me.txtFIPRUNPR.Text = fun_Formato_Mascara_5_String(Me.txtFIPRUNPR.Text)
        End If
    End Sub
    Private Sub txtFIPRCLSE_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFIPRCLSE.Validated
        If Trim(txtFIPRCLSE.Text) = "" Then
            lblFIPRCLSE.Text = ""
        Else
            lblFIPRCLSE.Text = CType(fun_Buscar_Lista_Valores_CLASSECT(Trim(txtFIPRCLSE.Text)), String)
        End If
    End Sub
    Private Sub txtFIPRCAPR_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFIPRCAPR.Validated
        If Trim(txtFIPRCAPR.Text) = "" Then
            lblFIPRCAPR.Text = ""
        Else
            lblFIPRCAPR.Text = CType(fun_Buscar_Lista_Valores_CALIPROP(Trim(txtFIPRCAPR.Text)), String)
        End If
    End Sub

#End Region

#Region "TextChanged"

    Private Sub tstBAESDESC_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tstBAESDESC.TextChanged
        If tstBAESDESC.Text <> "" Then
            MessageBox.Show(Trim(tstBAESDESC.Text), "Mensaje ...", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1)
        End If
    End Sub

#End Region

#End Region


End Class