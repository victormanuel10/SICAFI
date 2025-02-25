Imports REGLAS_DEL_NEGOCIO
Imports System
Imports System.IO
Imports System.Data
Imports System.Data.Sqlclient
Imports System.Configuration
Imports System.Text

Module mod_fun_CALCULAR_TOTAL_GENERALES

    '============================================================
    '*** CALCULA EL TOTAL GENERALES DE LA FICHA RESUMEN 1 Y 2 ***
    '============================================================

#Region "VARIABLES"

    ' variables ficha predial y resumen
    Private inFIPRNUFI As Integer = 0
    Private inFIPRCLSE As Integer = 0
    Private stFIPRMUNI As String = ""
    Private stFIPRCORR As String = ""
    Private stFIPRBARR As String = ""
    Private stFIPRMANZ As String = ""
    Private stFIPRPRED As String = ""
    Private stFIPREDIF As String = ""
    Private stFIPRCAPR As String = ""

    ' datatable global ficha resumen
    Private tblFR As New DataTable

    ' variables areas de ficha resumen
    Private inFIPRATLO As Integer = 0
    Private inFIPRACLO As Integer = 0
    Private inFIPRAPLO As Integer = 0
    Private inFIPRARTE As Integer = 0
    Private inSumAreaComunLote As Integer = 0
    Private inSumAreaPrivadaLote As Integer = 0

    ' variables de la conexion
    Private oEjecutar As New SqlCommand
    Private oConexion As New SqlConnection
    Private oAdapter As New SqlDataAdapter
    Private oReader As SqlDataReader
    Private ds As New DataSet
    Private dt As New DataTable
    Private dt_1 As New DataTable
    Private dt_2 As New DataTable
    Private dt_3 As New DataTable

#End Region

#Region "PROCEDIMIENTOS"

    Private Sub pro_CalcularTotalGeneralesFichaResumen1()

        Try
            ' declaro la variable
            Dim inTotalTotalEdificio As Integer = 0
            Dim inTotalUnidadesCondominio As Integer = 0
            Dim inTotalApartamentoCasas As Integer = 0
            Dim inTotalLocales As Integer = 0
            Dim inTotalCuartosUtiles As Integer = 0
            Dim inTotalGarajesCubiertos As Integer = 0
            Dim inTotalGarajesDescubiertos As Integer = 0

            ' buscar cadena de conexion
            Dim oCadenaConexion2 As New REGLAS_DEL_NEGOCIO.cla_ConnectionString
            Dim stCadenaConexion2 As String = oCadenaConexion2.fun_ConnectionString

            ' crea el datatable
            dt_2 = New DataTable

            ' crear conexión
            oAdapter = New SqlDataAdapter
            oConexion = New SqlConnection(stCadenaConexion2)

            ' abre la conexion
            oConexion.Open()

            ' variable de la consulta
            Dim ParametrosConsulta2 As String = ""

            ' Concatena la condicion de la consulta
            ParametrosConsulta2 += "Select "
            ParametrosConsulta2 += "Sum(FiprToed), "
            ParametrosConsulta2 += "Sum(FiprUrph), "
            ParametrosConsulta2 += "Sum(FiprApca), "
            ParametrosConsulta2 += "Sum(FiprLoca), "
            ParametrosConsulta2 += "Sum(FiprCuut), "
            ParametrosConsulta2 += "Sum(FiprGacu), "
            ParametrosConsulta2 += "Sum(FiprGade), Count(1) as NroRegistros "
            ParametrosConsulta2 += "From FichPred where "
            ParametrosConsulta2 += "FiprMuni = '" & Trim(stFIPRMUNI) & "' and "
            ParametrosConsulta2 += "FiprCorr = '" & Trim(stFIPRCORR) & "' and "
            ParametrosConsulta2 += "FiprBarr = '" & Trim(stFIPRBARR) & "' and "
            ParametrosConsulta2 += "FiprManz = '" & Trim(stFIPRMANZ) & "' and "
            ParametrosConsulta2 += "FiprPred = '" & Trim(stFIPRPRED) & "' and "
            ParametrosConsulta2 += "FiprCapr = '" & Trim(stFIPRCAPR) & "' and "
            ParametrosConsulta2 += "FiprClse = '" & Trim(inFIPRCLSE) & "' and "
            ParametrosConsulta2 += "FiprTifi = '" & 2 & "' and "
            ParametrosConsulta2 += "FiprEsta = 'ac' "

            ' ejecuta la consulta
            oEjecutar = New SqlCommand(ParametrosConsulta2, oConexion)

            ' procesa la consulta 
            oEjecutar.CommandTimeout = 360
            oEjecutar.CommandType = CommandType.Text
            oAdapter.SelectCommand = oEjecutar

            ' llena el datatable 
            oAdapter.Fill(dt_2)

            ' cierra la conexion
            oConexion.Close()

            ' Calcula el área común de lote de la ficha resumen 1 
            pro_CalcularAreaComunLoteFichaResumen1()

            ' verifica la variable
            If dt_2.Rows(0).Item(7) > 0 Then

                ' carga las variables
                inTotalTotalEdificio = dt_2.Rows(0).Item(0)
                inTotalUnidadesCondominio = dt_2.Rows(0).Item(1)
                inTotalApartamentoCasas = dt_2.Rows(0).Item(2)
                inTotalLocales = dt_2.Rows(0).Item(3)
                inTotalCuartosUtiles = dt_2.Rows(0).Item(4)
                inTotalGarajesCubiertos = dt_2.Rows(0).Item(5)
                inTotalGarajesDescubiertos = dt_2.Rows(0).Item(6)

                ' declara las variales
                Dim inTotalAreaComunLoteFichaResumen1 As Integer = 0
                Dim inTotalAreaTotalLoteFichaResumen1 As Integer = 0

                ' carga las variables
                inTotalAreaTotalLoteFichaResumen1 = tblFR.Rows(0).Item("FIPRATLO")
                inTotalAreaComunLoteFichaResumen1 = (inTotalAreaTotalLoteFichaResumen1 - (inSumAreaComunLote + inSumAreaPrivadaLote))

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
                ParametrosConsulta += "update FICHPRED "
                ParametrosConsulta += "set FIPRTOED = '" & inTotalTotalEdificio & "', "
                ParametrosConsulta += "FIPRUNCO = '" & inTotalUnidadesCondominio & "', "
                ParametrosConsulta += "FIPRAPCA = '" & inTotalApartamentoCasas & "', "
                ParametrosConsulta += "FIPRLOCA = '" & inTotalLocales & "', "
                ParametrosConsulta += "FIPRCUUT = '" & inTotalCuartosUtiles & "', "
                ParametrosConsulta += "FIPRGACU = '" & inTotalGarajesCubiertos & "', "
                ParametrosConsulta += "FIPRGADE = '" & inTotalGarajesDescubiertos & "', "
                ParametrosConsulta += "FIPRACLO = '" & inTotalAreaComunLoteFichaResumen1 & "', "
                ParametrosConsulta += "FIPRAPLO = '" & 0 & "', "
                ParametrosConsulta += "FIPRURPH = '" & 0 & "', "
                ParametrosConsulta += "FIPRPISO = '" & 0 & "' "
                ParametrosConsulta += "where FIPRNUFI = '" & inFIPRNUFI & "'"

                ' ejecuta la consulta
                oEjecutar = New SqlCommand(ParametrosConsulta, oConexion)

                ' procesa la consulta 
                oEjecutar.CommandTimeout = 360
                oEjecutar.CommandType = CommandType.Text
                oReader = oEjecutar.ExecuteReader

                ' cierra la conexion
                oConexion.Close()
                oReader = Nothing

            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub pro_CalcularTotalGeneralesFichaResumen2()

        Try
            ' declaro la variable
            Dim inTotalTotalEdificio As Integer = 1
            Dim inTotalUnidadesRPH As Integer = 0

            ' buscar cadena de conexion
            Dim oCadenaConexion2 As New REGLAS_DEL_NEGOCIO.cla_ConnectionString
            Dim stCadenaConexion2 As String = oCadenaConexion2.fun_ConnectionString

            ' crea el datatable
            dt_2 = New DataTable

            ' crear conexión
            oAdapter = New SqlDataAdapter
            oConexion = New SqlConnection(stCadenaConexion2)

            ' abre la conexion
            oConexion.Open()

            ' variable de la consulta
            Dim ParametrosConsulta2 As String = ""

            ' Concatena la condicion de la consulta
            ParametrosConsulta2 += "Select "
            ParametrosConsulta2 += "Sum(FiprArte), "
            ParametrosConsulta2 += "Count(1) as NroRegistros "
            ParametrosConsulta2 += "From FichPred where "
            ParametrosConsulta2 += "FiprMuni = '" & Trim(stFIPRMUNI) & "' and "
            ParametrosConsulta2 += "FiprCorr = '" & Trim(stFIPRCORR) & "' and "
            ParametrosConsulta2 += "FiprBarr = '" & Trim(stFIPRBARR) & "' and "
            ParametrosConsulta2 += "FiprManz = '" & Trim(stFIPRMANZ) & "' and "
            ParametrosConsulta2 += "FiprPred = '" & Trim(stFIPRPRED) & "' and "
            ParametrosConsulta2 += "FiprEdif = '" & Trim(stFIPREDIF) & "' and "
            ParametrosConsulta2 += "FiprCapr = '" & Trim(stFIPRCAPR) & "' and "
            ParametrosConsulta2 += "FiprClse = '" & Trim(inFIPRCLSE) & "' and "
            ParametrosConsulta2 += "FiprTifi = '" & 0 & "' and "
            ParametrosConsulta2 += "FiprEsta = 'ac' "

            ' ejecuta la consulta
            oEjecutar = New SqlCommand(ParametrosConsulta2, oConexion)

            ' procesa la consulta 
            oEjecutar.CommandTimeout = 360
            oEjecutar.CommandType = CommandType.Text
            oAdapter.SelectCommand = oEjecutar

            ' llena el datatable 
            oAdapter.Fill(dt_2)

            ' cierra la conexion
            oConexion.Close()

            If dt_2.Rows(0).Item(1) > 0 Then

                ' carga las variables
                inFIPRARTE = dt_2.Rows(0).Item(0)
                inTotalUnidadesRPH = dt_2.Rows(0).Item(1)

                ' carga el area total de lote 
                inFIPRATLO = tblFR.Rows(0).Item("FIPRATLO")

                ' carga el area comun de lote
                inFIPRACLO = (inFIPRATLO - inFIPRARTE)

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
                ParametrosConsulta += "update FICHPRED "
                ParametrosConsulta += "set FIPRTOED = '" & inTotalTotalEdificio & "', "
                ParametrosConsulta += "FIPRURPH = '" & inTotalUnidadesRPH & "', "
                ParametrosConsulta += "FIPRAPLO = '" & inFIPRARTE & "', "
                ParametrosConsulta += "FIPRACLO = '" & inFIPRACLO & "', "
                ParametrosConsulta += "FIPRUNCO = '" & 0 & "' "
                ParametrosConsulta += "where FIPRNUFI = '" & inFIPRNUFI & "'"

                ' ejecuta la consulta
                oEjecutar = New SqlCommand(ParametrosConsulta, oConexion)

                ' procesa la consulta 
                oEjecutar.CommandTimeout = 360
                oEjecutar.CommandType = CommandType.Text
                oReader = oEjecutar.ExecuteReader

                ' cierra la conexion
                oConexion.Close()
                oReader = Nothing

            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub pro_CalcularAreaComunLoteFichaResumen1()


        Try
            '===========================================================================
            ' *** CONSULTA LA SUMA DE LA AREAS COMUNES DE LOTE DE LA FICHA RESUMEN 2 ***
            '===========================================================================

            ' buscar cadena de conexion
            Dim oCadenaConexion As New REGLAS_DEL_NEGOCIO.cla_ConnectionString
            Dim stCadenaConexion As String = oCadenaConexion.fun_ConnectionString

            ' crea el datatable
            dt_1 = New DataTable

            ' crear conexión
            oAdapter = New SqlDataAdapter
            oConexion = New SqlConnection(stCadenaConexion)

            ' abre la conexion
            oConexion.Open()

            ' variable de la consulta
            Dim ParametrosConsulta As String = ""

            ' Concatena la condicion de la consulta
            ParametrosConsulta += "Select "
            ParametrosConsulta += "Sum(FiprAclo), Count(1) as NroRegistro "
            ParametrosConsulta += "From FichPred where "
            ParametrosConsulta += "FiprMuni = '" & Trim(stFIPRMUNI) & "' and "
            ParametrosConsulta += "FiprCorr = '" & Trim(stFIPRCORR) & "' and "
            ParametrosConsulta += "FiprBarr = '" & Trim(stFIPRBARR) & "' and "
            ParametrosConsulta += "FiprManz = '" & Trim(stFIPRMANZ) & "' and "
            ParametrosConsulta += "FiprPred = '" & Trim(stFIPRPRED) & "' and "
            ParametrosConsulta += "FiprCapr = '" & Trim(stFIPRCAPR) & "' and "
            ParametrosConsulta += "FiprClse = '" & Trim(inFIPRCLSE) & "' and "
            ParametrosConsulta += "FiprTifi = '" & 2 & "' and "
            ParametrosConsulta += "FiprEsta = 'ac' "

            ' ejecuta la consulta
            oEjecutar = New SqlCommand(ParametrosConsulta, oConexion)

            ' procesa la consulta 
            oEjecutar.CommandTimeout = 360
            oEjecutar.CommandType = CommandType.Text
            oAdapter.SelectCommand = oEjecutar

            ' llena el datatable 
            oAdapter.Fill(dt_1)

            ' cierra la conexion
            oConexion.Close()

            ' verifica la variable
            If dt_1.Rows(0).Item(1) = 0 Then
                inSumAreaComunLote = 0
            Else
                ' total area comun de lote
                inSumAreaComunLote = dt_1.Rows(0).Item(0)
            End If

            '============================================================================
            ' *** CONSULTA LA SUMA DE LA AREAS PRIVADAS DE LOTE DE LA FICHA RESUMEN 2 ***
            '============================================================================

            ' buscar cadena de conexion
            Dim oCadenaConexion3 As New REGLAS_DEL_NEGOCIO.cla_ConnectionString
            Dim stCadenaConexion3 As String = oCadenaConexion3.fun_ConnectionString

            ' crea el datatable
            dt_3 = New DataTable

            ' crear conexión
            oAdapter = New SqlDataAdapter
            oConexion = New SqlConnection(stCadenaConexion3)

            ' abre la conexion
            oConexion.Open()

            ' variable de la consulta
            Dim ParametrosConsulta3 As String = ""

            ' Concatena la condicion de la consulta
            ParametrosConsulta3 += "Select "
            ParametrosConsulta3 += "Sum(FiprAplo), Count(1) as NroRegistro "
            ParametrosConsulta3 += "From FichPred where "
            ParametrosConsulta3 += "FiprMuni = '" & Trim(stFIPRMUNI) & "' and "
            ParametrosConsulta3 += "FiprCorr = '" & Trim(stFIPRCORR) & "' and "
            ParametrosConsulta3 += "FiprBarr = '" & Trim(stFIPRBARR) & "' and "
            ParametrosConsulta3 += "FiprManz = '" & Trim(stFIPRMANZ) & "' and "
            ParametrosConsulta3 += "FiprPred = '" & Trim(stFIPRPRED) & "' and "
            ParametrosConsulta3 += "FiprCapr = '" & Trim(stFIPRCAPR) & "' and "
            ParametrosConsulta3 += "FiprClse = '" & Trim(inFIPRCLSE) & "' and "
            ParametrosConsulta3 += "FiprTifi = '" & 2 & "' and "
            ParametrosConsulta3 += "FiprEsta = 'ac' "

            ' ejecuta la consulta
            oEjecutar = New SqlCommand(ParametrosConsulta3, oConexion)

            ' procesa la consulta 
            oEjecutar.CommandTimeout = 360
            oEjecutar.CommandType = CommandType.Text
            oAdapter.SelectCommand = oEjecutar

            ' llena el datatable 
            oAdapter.Fill(dt_3)

            ' cierra la conexion
            oConexion.Close()

            ' verifica la variable
            If dt_3.Rows(0).Item(1) = 0 Then
                inSumAreaPrivadaLote = 0
            Else
                ' total area comun de lote
                inSumAreaPrivadaLote = dt_3.Rows(0).Item(0)
            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub


#End Region

#Region "FUNCIONES"

    Public Sub fun_Calcular_Total_Generales_Ficha_Resumen(ByVal o_inFIPRNUFI As Integer)

        Try

            ' carga el Nro. de ficha predial
            inFIPRNUFI = o_inFIPRNUFI

            ' busca y carga las variables
            Dim objdatosFR As New cla_FICHPRED
            tblFR = New DataTable

            tblFR = objdatosFR.fun_Consultar_FICHA_PREDIAL_X_NRO_FICHA_PREDIAL(inFIPRNUFI)

            If tblFR.Rows.Count > 0 Then

                inFIPRCLSE = tblFR.Rows(0).Item("FIPRCLSE")
                stFIPRMUNI = tblFR.Rows(0).Item("FIPRMUNI")
                stFIPRCORR = tblFR.Rows(0).Item("FIPRCORR")
                stFIPRBARR = tblFR.Rows(0).Item("FIPRBARR")
                stFIPRMANZ = tblFR.Rows(0).Item("FIPRMANZ")
                stFIPRPRED = tblFR.Rows(0).Item("FIPRPRED")
                stFIPREDIF = tblFR.Rows(0).Item("FIPREDIF")
                stFIPRCAPR = tblFR.Rows(0).Item("FIPRCAPR")

            End If

            '===============================================
            '*** CALCULA TOTAL GENERALES FICHA RESUMEN 1 ***
            '===============================================

            If tblFR.Rows(0).Item("FIPRTIFI") = 1 Then

                pro_CalcularTotalGeneralesFichaResumen1()

            End If

            '===============================================
            '*** CALCULA TOTAL GENERALES FICHA RESUMEN 2 ***
            '===============================================

            If tblFR.Rows(0).Item("FIPRTIFI") = 2 Then

                pro_CalcularTotalGeneralesFichaResumen2()

            End If


        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub

#End Region



End Module
