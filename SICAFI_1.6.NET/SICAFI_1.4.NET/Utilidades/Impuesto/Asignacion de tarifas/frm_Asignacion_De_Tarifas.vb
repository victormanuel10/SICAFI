Imports REGLAS_DEL_NEGOCIO
Imports System
Imports System.IO
Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration
Imports System.Text

Public Class frm_Asignacion_De_Tarifas

    '=============================
    '*** ASIGNACION DE TARIFAS ***
    '=============================

#Region "VARIABLES"

#Region "Conexion"

    Private oEjecutar As New SqlCommand
    Private oConexion As New SqlConnection
    Private oAdapter As New SqlDataAdapter
    Private oReader As SqlDataReader
    Private ds As New DataSet
    Private dt As New DataTable

#End Region

    ' variables de procesos
    Private inProceso As Integer
    Private inTotalRegistros As Integer
    Private inNroInconsistencias As Integer
    Private stSeparador As String

    ' variables ficha predial
    Private stFIPRFIIN As String
    Private stFIPRFIFI As String
    Private stFIPRVIGE As String
    Private stFIPRMUNI As String
    Private stFIPRCORR As String
    Private stFIPRBARR As String
    Private stFIPRMANZ As String
    Private stFIPRPRED As String
    Private stFIPREDIF As String
    Private stFIPRUNPR As String
    Private stFIPRCLSE As String

    ' crea la tabla
    Dim dtZonasEconomicas As New DataTable
    Dim dtComparativoDeLiquidacion As New DataTable

    ' declara las variables
    Dim vl_doTarifa_0_a_10 As Double = 0.0
    Dim vl_doTarifa_11_a_28 As Double = 0.0
    Dim vl_doTarifa_29_a_46 As Double = 0.0
    Dim vl_doTarifa_47_a_64 As Double = 0.0
    Dim vl_doTarifa_65_a_84 As Double = 0.0
    Dim vl_doTarifa_85_a_100 As Double = 0.0

    Dim vl_doTarifa_Lote As Double = 0.0

    ' declara las variables
    Dim vl_inContador_Tarifa_0_a_10 As Integer = 1
    Dim vl_inContador_Tarifa_11_a_28 As Integer = 1
    Dim vl_inContador_Tarifa_29_a_46 As Integer = 1
    Dim vl_inContador_Tarifa_47_a_64 As Integer = 1
    Dim vl_inContador_Tarifa_65_a_84 As Integer = 1
    Dim vl_inContador_Tarifa_85_a_100 As Integer = 1

    Dim vl_inContador_Tarifa_Lote As Integer = 1

    ' declara las tarifas
    Dim vl_doTarifa1_1 As Double = 0.0
    Dim vl_doTarifa2_2 As Double = 0.0
    Dim vl_doTarifa3_3 As Double = 0.0
    Dim vl_doTarifa4_4 As Double = 0.0
    Dim vl_doTarifa5_5 As Double = 0.0
    Dim vl_doTarifa6_6 As Double = 0.0

#End Region

#Region "INSTANCIAR FORMULARIO"

    Private Shared frm_Instance = Nothing

    Public Shared Function instance() As frm_Asignacion_De_Tarifas
        If frm_Instance Is Nothing OrElse frm_Instance.isdisposed = True Then
            frm_Instance = New frm_Asignacion_De_Tarifas
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

#Region "FUNCIONES"

    Private Function fun_CargarZonasEconomicas(ByVal stMunicipio As String, ByVal inSector As Integer, ByVal inVigencia As Integer) As DataTable

        Try
            ' buscar cadena de conexion
            Dim oCadenaConexion As New REGLAS_DEL_NEGOCIO.cla_ConnectionString
            Dim stCadenaConexion As String = oCadenaConexion.fun_ConnectionString

            ' crea el datatable
            dtZonasEconomicas = New DataTable

            ' crear conexión
            oAdapter = New SqlDataAdapter
            oConexion = New SqlConnection(stCadenaConexion)

            ' abre la conexion
            oConexion.Open()

            ' declara la variable
            Dim inTarifaZonaComun As Integer = 0

            If Me.chkCalcularTarifasZonasComunes.Checked = True Then
                inTarifaZonaComun = 1

            ElseIf Me.chkCalcularTarifasZonasComunes.Checked = False Then
                inTarifaZonaComun = 0
            End If

            ' parametros de la consulta
            Dim ParametrosConsulta As String = ""

            ' Concatena la condicion de la consulta
            ParametrosConsulta += "Select * "
            ParametrosConsulta += "From TariZoec where "
            ParametrosConsulta += "TazeMuni like '" & CStr(Trim(stMunicipio)) & "' and "
            ParametrosConsulta += "TazeClse like '" & CInt(inSector) & "' and "
            ParametrosConsulta += "TazeVige like '" & CInt(inVigencia) & "' and "
            ParametrosConsulta += "exists(select 1 from mant_zonaecon where TazeMuni = ZoecMuni and TazeClse = ZoecClse and TazeZoec = ZoecCodi and ZoecZoco = " & inTarifaZonaComun & " and ZoecEsta = 'ac' ) and "
            ParametrosConsulta += "TazeEsta = 'ac' "

            ' ejecuta la consulta
            oEjecutar = New SqlCommand(ParametrosConsulta, oConexion)

            ' procesa la consulta 
            oEjecutar.CommandTimeout = 0
            oEjecutar.CommandType = CommandType.Text
            oAdapter.SelectCommand = oEjecutar

            ' llena el datatable 
            oAdapter.Fill(dtZonasEconomicas)

            ' cierra la conexion
            oConexion.Close()

            Return dtZonasEconomicas

        Catch ex As Exception
            Return Nothing
            MessageBox.Show(Err.Description)
        End Try

    End Function
    Private Function fun_ComparativoDeLiquidacionRCI(ByVal stDepartamento As String, _
                                                     ByVal stMunicipio As String, _
                                                     ByVal inSector As Integer, _
                                                     ByVal inZonaEconomica As Integer, _
                                                     ByVal inVigencia As Integer) As DataTable

        Try

            ' buscar cadena de conexion
            Dim oCadenaConexion As New REGLAS_DEL_NEGOCIO.cla_ConnectionString
            Dim stCadenaConexion As String = oCadenaConexion.fun_ConnectionString

            ' crea el datatable
            dtComparativoDeLiquidacion = New DataTable

            ' crear conexión
            oAdapter = New SqlDataAdapter
            oConexion = New SqlConnection(stCadenaConexion)

            ' abre la conexion
            oConexion.Open()

            ' parametros de la consulta
            Dim ParametrosConsulta As String = ""

            ' Concatena la condicion de la consulta
            ParametrosConsulta += "Select "
            ParametrosConsulta += "a.afsinufi as Nro_ficha, "
            ParametrosConsulta += "suimmuni as Municipio, "
            ParametrosConsulta += "suimcorr as Corregi, "
            ParametrosConsulta += "suimbarr as Barrio, "
            ParametrosConsulta += "suimmanz as Manzana, "
            ParametrosConsulta += "suimpred as Predio, "
            ParametrosConsulta += "suimedif as Edificio, "
            ParametrosConsulta += "suimunpr as Unidad, "
            ParametrosConsulta += "suimclse as Sector, "
            ParametrosConsulta += "a.afsivaba as Avaluo_" & (inVigencia - 1) & ", "
            ParametrosConsulta += "a.afsivali as Predial_" & (inVigencia - 1) & ", "
            ParametrosConsulta += "b.afsivaba as Avaluo_" & (inVigencia) & ", "
            ParametrosConsulta += "b.afsivali as Predial_" & (inVigencia) & ", "
            ParametrosConsulta += "a.afsizo01 as Zona_" & (inVigencia - 1) & ", "
            ParametrosConsulta += "a.afsita01 as Tarifa_" & (inVigencia - 1) & ", "
            ParametrosConsulta += "b.afsizo01 as Zona_" & (inVigencia) & ", "
            ParametrosConsulta += "b.afsita01 as Tarifa_" & (inVigencia) & ", "
            ParametrosConsulta += "hilideec as Destino, "
            ParametrosConsulta += "hilipunt as Puntos, "
            ParametrosConsulta += "hilitipo as Tipo, "
            ParametrosConsulta += "hililote as Lote, "
            ParametrosConsulta += "hiliestr as Estrato, "
            ParametrosConsulta += "hilile44 as Ley44, "
            ParametrosConsulta += "((b.afsivaba * 100 / a.afsivaba) -100 ) as Inc_Avaluo, "
            ParametrosConsulta += "((b.afsivali * 100 / a.afsivali) -100 ) as Inc_Predial "

            ParametrosConsulta += "From aforsuim a, aforsuim b, sujeimpu, histliqu where "

            ParametrosConsulta += "a.afsiclse = '" & CInt(inSector) & "' and "
            ParametrosConsulta += "a.afsivige = '" & CInt(inVigencia - 1) & "' and "
            ParametrosConsulta += "b.afsivige = '" & CInt(inVigencia) & "' and "
            ParametrosConsulta += "suimmuni = '" & CStr(Trim(stMunicipio)) & "' and "
            ParametrosConsulta += "suimdepa = '" & CStr(Trim(stDepartamento)) & "' and "
            ParametrosConsulta += "a.afsinufi = b.afsinufi and "
            ParametrosConsulta += "a.afsiclse = b.afsiclse and "
            ParametrosConsulta += "suimnufi = a.afsinufi and "
            ParametrosConsulta += "suimnufi = b.afsinufi and "
            ParametrosConsulta += "a.afsivaba <> 0 and "
            ParametrosConsulta += "a.afsivali <> 0 and "
            ParametrosConsulta += "hilinufi = a.afsinufi and "
            ParametrosConsulta += "hilinufi = b.afsinufi and "
            ParametrosConsulta += "hilinufi = suimnufi and "
            ParametrosConsulta += "b.afsivige = hilivige and "
            ParametrosConsulta += "hilitipo in ('R','C','I','O') and "
            ParametrosConsulta += "exists(select 1 from fiprzoec where a.afsinufi = fpzenufi and fpzezoec = " & inZonaEconomica & " ) and "
            ParametrosConsulta += "exists(select 1 from fiprcons where a.afsinufi = fpconufi and fpcotico not in ('050','014','75A','75B','75C','075') and fpcounid = 1 ) "
            ParametrosConsulta += "order by Inc_predial desc "

            ' ejecuta la consulta
            oEjecutar = New SqlCommand(ParametrosConsulta, oConexion)

            ' procesa la consulta 
            oEjecutar.CommandTimeout = 0
            oEjecutar.CommandType = CommandType.Text
            oAdapter.SelectCommand = oEjecutar

            ' llena el datatable 
            oAdapter.Fill(dtComparativoDeLiquidacion)

            ' cierra la conexion
            oConexion.Close()

            Return dtComparativoDeLiquidacion

        Catch ex As Exception
            Return Nothing
            MessageBox.Show(Err.Description)
        End Try

    End Function
    Private Function fun_ComparativoDeLiquidacionLOTE(ByVal stDepartamento As String, _
                                                      ByVal stMunicipio As String, _
                                                      ByVal inSector As Integer, _
                                                      ByVal inZonaEconomica As Integer, _
                                                      ByVal inVigencia As Integer) As DataTable

        Try

            ' buscar cadena de conexion
            Dim oCadenaConexion As New REGLAS_DEL_NEGOCIO.cla_ConnectionString
            Dim stCadenaConexion As String = oCadenaConexion.fun_ConnectionString

            ' crea el datatable
            dtComparativoDeLiquidacion = New DataTable

            ' crear conexión
            oAdapter = New SqlDataAdapter
            oConexion = New SqlConnection(stCadenaConexion)

            ' abre la conexion
            oConexion.Open()

            ' parametros de la consulta
            Dim ParametrosConsulta As String = ""

            ' Concatena la condicion de la consulta
            ParametrosConsulta += "Select "
            ParametrosConsulta += "a.afsinufi as Nro_ficha, "
            ParametrosConsulta += "suimmuni as Municipio, "
            ParametrosConsulta += "suimcorr as Corregi, "
            ParametrosConsulta += "suimbarr as Barrio, "
            ParametrosConsulta += "suimmanz as Manzana, "
            ParametrosConsulta += "suimpred as Predio, "
            ParametrosConsulta += "suimedif as Edificio, "
            ParametrosConsulta += "suimunpr as Unidad, "
            ParametrosConsulta += "suimclse as Sector, "
            ParametrosConsulta += "a.afsivaba as Avaluo_" & (inVigencia - 1) & ", "
            ParametrosConsulta += "a.afsivali as Predial_" & (inVigencia - 1) & ", "
            ParametrosConsulta += "b.afsivaba as Avaluo_" & (inVigencia) & ", "
            ParametrosConsulta += "b.afsivali as Predial_" & (inVigencia) & ", "
            ParametrosConsulta += "a.afsizo01 as Zona_" & (inVigencia - 1) & ", "
            ParametrosConsulta += "a.afsita01 as Tarifa_" & (inVigencia - 1) & ", "
            ParametrosConsulta += "b.afsizo01 as Zona_" & (inVigencia) & ", "
            ParametrosConsulta += "b.afsita01 as Tarifa_" & (inVigencia) & ", "
            ParametrosConsulta += "hilideec as Destino, "
            ParametrosConsulta += "hilipunt as Puntos, "
            ParametrosConsulta += "hilitipo as Tipo, "
            ParametrosConsulta += "hililote as Lote, "
            ParametrosConsulta += "hiliestr as Estrato, "
            ParametrosConsulta += "hilile44 as Ley44, "
            ParametrosConsulta += "((b.afsivaba * 100 / a.afsivaba) -100 ) as Inc_Avaluo, "
            ParametrosConsulta += "((b.afsivali * 100 / a.afsivali) -100 ) as Inc_Predial "

            ParametrosConsulta += "From aforsuim a, aforsuim b, sujeimpu, histliqu where "

            ParametrosConsulta += "a.afsiclse = '" & CInt(inSector) & "' and "
            ParametrosConsulta += "a.afsivige = '" & CInt(inVigencia - 1) & "' and "
            ParametrosConsulta += "b.afsivige = '" & CInt(inVigencia) & "' and "
            ParametrosConsulta += "suimmuni = '" & CStr(Trim(stMunicipio)) & "' and "
            ParametrosConsulta += "suimdepa = '" & CStr(Trim(stDepartamento)) & "' and "
            ParametrosConsulta += "a.afsinufi = b.afsinufi and "
            ParametrosConsulta += "a.afsiclse = b.afsiclse and "
            ParametrosConsulta += "suimnufi = a.afsinufi and "
            ParametrosConsulta += "suimnufi = b.afsinufi and "
            ParametrosConsulta += "a.afsivaba <> 0 and "
            ParametrosConsulta += "a.afsivali <> 0 and "
            ParametrosConsulta += "hilinufi = a.afsinufi and "
            ParametrosConsulta += "hilinufi = b.afsinufi and "
            ParametrosConsulta += "hilinufi = suimnufi and "
            ParametrosConsulta += "b.afsivige = hilivige and "
            ParametrosConsulta += "hilitipo in ('N') and "
            ParametrosConsulta += "exists(select 1 from fiprzoec where a.afsinufi = fpzenufi and fpzezoec = " & inZonaEconomica & " ) and "
            ParametrosConsulta += "exists(select 1 from mant_destecon where hilideec = deeccodi and deeclote = 1 ) "
            ParametrosConsulta += "order by Inc_predial desc "

            ' ejecuta la consulta
            oEjecutar = New SqlCommand(ParametrosConsulta, oConexion)

            ' procesa la consulta 
            oEjecutar.CommandTimeout = 0
            oEjecutar.CommandType = CommandType.Text
            oAdapter.SelectCommand = oEjecutar

            ' llena el datatable 
            oAdapter.Fill(dtComparativoDeLiquidacion)

            ' cierra la conexion
            oConexion.Close()

            Return dtComparativoDeLiquidacion

        Catch ex As Exception
            Return Nothing
            MessageBox.Show(Err.Description)
        End Try

    End Function
    Private Function fun_ActualizaMatrizRCI(ByVal stDepartamento As String, _
                                            ByVal stMunicipio As String, _
                                            ByVal inSector As Integer, _
                                            ByVal inZonaEconomica As Integer, _
                                            ByVal inVigencia As Integer, _
                                            ByVal doTarifa1 As Double, _
                                            ByVal doTarifa2 As Double, _
                                            ByVal doTarifa3 As Double, _
                                            ByVal doTarifa4 As Double, _
                                            ByVal doTarifa5 As Double, _
                                            ByVal doTarifa6 As Double, _
                                            ByVal doIncremento As Double) As Boolean

        Try
            Dim boResultado As Boolean = False

            ' declara las tarifas
            vl_doTarifa1_1 = 0.0
            vl_doTarifa2_2 = 0.0
            vl_doTarifa3_3 = 0.0
            vl_doTarifa4_4 = 0.0
            vl_doTarifa5_5 = 0.0
            vl_doTarifa6_6 = 0.0

            ' formato a las tarifas
            vl_doTarifa1_1 = CDbl(fun_Formato_Decimal_2_Decimales(doTarifa1 / vl_inContador_Tarifa_0_a_10))
            vl_doTarifa2_2 = CDbl(fun_Formato_Decimal_2_Decimales(doTarifa2 / vl_inContador_Tarifa_11_a_28))
            vl_doTarifa3_3 = CDbl(fun_Formato_Decimal_2_Decimales(doTarifa3 / vl_inContador_Tarifa_29_a_46))
            vl_doTarifa4_4 = CDbl(fun_Formato_Decimal_2_Decimales(doTarifa4 / vl_inContador_Tarifa_47_a_64))
            vl_doTarifa5_5 = CDbl(fun_Formato_Decimal_2_Decimales(doTarifa5 / vl_inContador_Tarifa_65_a_84))
            vl_doTarifa6_6 = CDbl(fun_Formato_Decimal_2_Decimales(doTarifa6 / vl_inContador_Tarifa_85_a_100))

            ' determina la tarifa minima
            pro_AsignarTarifaMinima(stDepartamento, stMunicipio, inSector, inZonaEconomica, inVigencia, vl_doTarifa1_1, vl_doTarifa2_2, vl_doTarifa3_3, vl_doTarifa4_4, vl_doTarifa5_5, vl_doTarifa6_6, doIncremento)

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
            ParametrosConsulta += "update TARIZOEC "
            ParametrosConsulta += "set TAZETA01 = '" & CStr(fun_Formato_Decimal_2_Decimales(vl_doTarifa1_1 + doIncremento)) & "', "
            ParametrosConsulta += "TAZETA02 = '" & CStr(fun_Formato_Decimal_2_Decimales(vl_doTarifa2_2 + doIncremento)) & "', "
            ParametrosConsulta += "TAZETA03 = '" & CStr(fun_Formato_Decimal_2_Decimales(vl_doTarifa3_3 + doIncremento)) & "', "
            ParametrosConsulta += "TAZETA04 = '" & CStr(fun_Formato_Decimal_2_Decimales(vl_doTarifa4_4 + doIncremento)) & "', "
            ParametrosConsulta += "TAZETA05 = '" & CStr(fun_Formato_Decimal_2_Decimales(vl_doTarifa5_5 + doIncremento)) & "', "
            ParametrosConsulta += "TAZETA06 = '" & CStr(fun_Formato_Decimal_2_Decimales(vl_doTarifa6_6 + doIncremento)) & "'  "
            ParametrosConsulta += "where "
            ParametrosConsulta += "TAZEDEPA = '" & CStr(Trim(stDepartamento)) & "' and "
            ParametrosConsulta += "TAZEMUNI = '" & CStr(Trim(stMunicipio)) & "' and "
            ParametrosConsulta += "TAZECLSE = '" & CInt(inSector) & "' and "
            ParametrosConsulta += "TAZEZOEC = '" & CInt(inZonaEconomica) & "' and "
            ParametrosConsulta += "TAZEVIGE = '" & CInt(inVigencia) & "' "

            ' ejecuta la consulta
            oEjecutar = New SqlCommand(ParametrosConsulta, oConexion)

            ' procesa la consulta 
            oEjecutar.CommandTimeout = 0
            oEjecutar.CommandType = CommandType.Text

            oReader = oEjecutar.ExecuteReader

            Dim i As Integer = oReader.RecordsAffected

            If i > 0 Then
                boResultado = True
            Else
                boResultado = False
            End If

            ' cierra la conexion
            oConexion.Close()
            oReader = Nothing

            Return boResultado

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Function
    Private Function fun_ActualizaMatrizLote(ByVal stDepartamento As String, _
                                             ByVal stMunicipio As String, _
                                             ByVal inSector As Integer, _
                                             ByVal inZonaEconomica As Integer, _
                                             ByVal inVigencia As Integer, _
                                             ByVal doTarifaLote As Double) As Boolean

        Try
            Dim boResultado As Boolean = False

            ' buscar cadena de conexion
            Dim oCadenaConexion As New REGLAS_DEL_NEGOCIO.cla_ConnectionString
            Dim stCadenaConexion As String = oCadenaConexion.fun_ConnectionString

            ' crear conexión
            oAdapter = New SqlDataAdapter
            oConexion = New SqlConnection(stCadenaConexion)

            ' abre la conexion
            oConexion.Open()

            ' declara las tarifas
            Dim doTarifaLote1_1 As Double = 0.0

            ' formato a las tarifas
            doTarifaLote1_1 = CDbl(fun_Formato_Decimal_2_Decimales(doTarifaLote / vl_inContador_Tarifa_Lote))

            ' parametros de la consulta
            Dim ParametrosConsulta As String = ""

            ' Concatena la condicion de la consulta
            ParametrosConsulta += "update TARIZOEC "
            ParametrosConsulta += "set TAZETALO = '" & CStr(fun_Formato_Decimal_2_Decimales(doTarifaLote1_1)) & "' "
            ParametrosConsulta += "where "
            ParametrosConsulta += "TAZEDEPA = '" & CStr(Trim(stDepartamento)) & "' and "
            ParametrosConsulta += "TAZEMUNI = '" & CStr(Trim(stMunicipio)) & "' and "
            ParametrosConsulta += "TAZECLSE = '" & CInt(inSector) & "' and "
            ParametrosConsulta += "TAZEZOEC = '" & CInt(inZonaEconomica) & "' and "
            ParametrosConsulta += "TAZEVIGE = '" & CInt(inVigencia) & "' "

            ' ejecuta la consulta
            oEjecutar = New SqlCommand(ParametrosConsulta, oConexion)

            ' procesa la consulta 
            oEjecutar.CommandTimeout = 0
            oEjecutar.CommandType = CommandType.Text

            oReader = oEjecutar.ExecuteReader

            Dim i As Integer = oReader.RecordsAffected

            If i > 0 Then
                boResultado = True
            Else
                boResultado = False
            End If

            ' cierra la conexion
            oConexion.Close()
            oReader = Nothing

            Return boResultado

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Function
    Private Function fun_ActualizaMatrizIncremento(ByVal stDepartamento As String, _
                                                   ByVal stMunicipio As String, _
                                                   ByVal inSector As Integer, _
                                                   ByVal inZonaEconomica As Integer, _
                                                   ByVal inVigencia As Integer, _
                                                   ByVal doTarifa1 As Double, _
                                                   ByVal doTarifa2 As Double, _
                                                   ByVal doTarifa3 As Double, _
                                                   ByVal doTarifa4 As Double, _
                                                   ByVal doTarifa5 As Double, _
                                                   ByVal doTarifa6 As Double, _
                                                   ByVal stSigno As String, _
                                                   ByVal doIncremento As Double) As Boolean

        Try
            Dim boResultado As Boolean = False

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

            ' suma
            If Trim(stSigno) = "+" Then

                ' Concatena la condicion de la consulta
                ParametrosConsulta += "update TARIZOEC "
                ParametrosConsulta += "set TAZETA01 = '" & CStr(fun_Formato_Decimal_2_Decimales(doTarifa1 + doIncremento)) & "', "
                ParametrosConsulta += "TAZETA02 = '" & CStr(fun_Formato_Decimal_2_Decimales(doTarifa2 + doIncremento)) & "', "
                ParametrosConsulta += "TAZETA03 = '" & CStr(fun_Formato_Decimal_2_Decimales(doTarifa3 + doIncremento)) & "', "
                ParametrosConsulta += "TAZETA04 = '" & CStr(fun_Formato_Decimal_2_Decimales(doTarifa4 + doIncremento)) & "', "
                ParametrosConsulta += "TAZETA05 = '" & CStr(fun_Formato_Decimal_2_Decimales(doTarifa5 + doIncremento)) & "', "
                ParametrosConsulta += "TAZETA06 = '" & CStr(fun_Formato_Decimal_2_Decimales(doTarifa6 + doIncremento)) & "'  "
                ParametrosConsulta += "where "
                ParametrosConsulta += "TAZEDEPA = '" & CStr(Trim(stDepartamento)) & "' and "
                ParametrosConsulta += "TAZEMUNI = '" & CStr(Trim(stMunicipio)) & "' and "
                ParametrosConsulta += "TAZECLSE = '" & CInt(inSector) & "' and "
                ParametrosConsulta += "TAZEZOEC = '" & CInt(inZonaEconomica) & "' and "
                ParametrosConsulta += "TAZEVIGE = '" & CInt(inVigencia) & "' "

            End If

            ' resta
            If Trim(stSigno) = "-" Then

                ' Concatena la condicion de la consulta
                ParametrosConsulta += "update TARIZOEC "
                ParametrosConsulta += "set TAZETA01 = '" & CStr(fun_Formato_Decimal_2_Decimales(doTarifa1 - doIncremento)) & "', "
                ParametrosConsulta += "TAZETA02 = '" & CStr(fun_Formato_Decimal_2_Decimales(doTarifa2 - doIncremento)) & "', "
                ParametrosConsulta += "TAZETA03 = '" & CStr(fun_Formato_Decimal_2_Decimales(doTarifa3 - doIncremento)) & "', "
                ParametrosConsulta += "TAZETA04 = '" & CStr(fun_Formato_Decimal_2_Decimales(doTarifa4 - doIncremento)) & "', "
                ParametrosConsulta += "TAZETA05 = '" & CStr(fun_Formato_Decimal_2_Decimales(doTarifa5 - doIncremento)) & "', "
                ParametrosConsulta += "TAZETA06 = '" & CStr(fun_Formato_Decimal_2_Decimales(doTarifa6 - doIncremento)) & "'  "
                ParametrosConsulta += "where "
                ParametrosConsulta += "TAZEDEPA = '" & CStr(Trim(stDepartamento)) & "' and "
                ParametrosConsulta += "TAZEMUNI = '" & CStr(Trim(stMunicipio)) & "' and "
                ParametrosConsulta += "TAZECLSE = '" & CInt(inSector) & "' and "
                ParametrosConsulta += "TAZEZOEC = '" & CInt(inZonaEconomica) & "' and "
                ParametrosConsulta += "TAZEVIGE = '" & CInt(inVigencia) & "' "

            End If

            ' multiplica
            If Trim(stSigno) = "*" Then

                ' Concatena la condicion de la consulta
                ParametrosConsulta += "update TARIZOEC "
                ParametrosConsulta += "set TAZETA01 = '" & CStr(fun_Formato_Decimal_2_Decimales(doTarifa1 * doIncremento)) & "', "
                ParametrosConsulta += "TAZETA02 = '" & CStr(fun_Formato_Decimal_2_Decimales(doTarifa2 * doIncremento)) & "', "
                ParametrosConsulta += "TAZETA03 = '" & CStr(fun_Formato_Decimal_2_Decimales(doTarifa3 * doIncremento)) & "', "
                ParametrosConsulta += "TAZETA04 = '" & CStr(fun_Formato_Decimal_2_Decimales(doTarifa4 * doIncremento)) & "', "
                ParametrosConsulta += "TAZETA05 = '" & CStr(fun_Formato_Decimal_2_Decimales(doTarifa5 * doIncremento)) & "', "
                ParametrosConsulta += "TAZETA06 = '" & CStr(fun_Formato_Decimal_2_Decimales(doTarifa6 * doIncremento)) & "'  "
                ParametrosConsulta += "where "
                ParametrosConsulta += "TAZEDEPA = '" & CStr(Trim(stDepartamento)) & "' and "
                ParametrosConsulta += "TAZEMUNI = '" & CStr(Trim(stMunicipio)) & "' and "
                ParametrosConsulta += "TAZECLSE = '" & CInt(inSector) & "' and "
                ParametrosConsulta += "TAZEZOEC = '" & CInt(inZonaEconomica) & "' and "
                ParametrosConsulta += "TAZEVIGE = '" & CInt(inVigencia) & "' "

            End If

            ' ejecuta la consulta
            oEjecutar = New SqlCommand(ParametrosConsulta, oConexion)

            ' procesa la consulta 
            oEjecutar.CommandTimeout = 0
            oEjecutar.CommandType = CommandType.Text

            oReader = oEjecutar.ExecuteReader

            Dim i As Integer = oReader.RecordsAffected

            If i > 0 Then
                boResultado = True
            Else
                boResultado = False
            End If

            ' cierra la conexion
            oConexion.Close()
            oReader = Nothing

            Return boResultado

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Function
    Private Function fun_extraerZonas(ByVal stZona As String) As String

        Try
            Dim stZonaEconomica As String = Trim(stZona)
            Dim inCantdadLetras As Integer = stZonaEconomica.ToString.Length
            Dim stZonaFinal As String = ""

            Dim sw1 As Byte = 0
            Dim j1 As Integer = 0

            While j1 < inCantdadLetras And sw1 = 0

                Dim stLetras As String = stZonaEconomica.ToString.Substring(j1, 1)

                If fun_Verificar_Dato_Numerico_Evento_Validated(stLetras) = True Then
                    stZonaFinal += stLetras
                    j1 = j1 + 1
                Else
                    sw1 = 1
                End If

            End While

            Return stZonaFinal

        Catch ex As Exception
            MessageBox.Show(Err.Description)
            Return ""
        End Try

    End Function

#End Region

#Region "PROCEDIMIENTOS"

    Private Sub pro_LimpiarCampos()

        Me.txtFIPRMUNI.Text = ""
        Me.lblASTAVIGE.Text = ""
        Me.lblASTACLSE.Text = ""

        Me.pbPROCESO.Value = 0

        Me.cboASTACLSE.DataSource = New DataTable
        Me.cboASTAVIGE.DataSource = New DataTable

        Me.strBARRESTA.Items(2).Text = "Registros : 0"

    End Sub
    Private Sub pro_VerificarCampos()

        Try

            If Trim(Me.txtFIPRMUNI.Text) = "" Then
                stFIPRMUNI = "%"
            Else
                stFIPRMUNI = Trim(Me.txtFIPRMUNI.Text)
            End If

            If Trim(Me.cboASTACLSE.Text) = "" Then
                stFIPRCLSE = "%"
            Else
                stFIPRCLSE = Trim(Me.cboASTACLSE.SelectedValue)
            End If

            If Trim(Me.cboASTAVIGE.Text) = "" Then
                stFIPRVIGE = "%"
            Else
                stFIPRVIGE = Trim(Me.cboASTAVIGE.SelectedValue)
            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub pro_CacularTarifaRCI(ByVal inZonaEconomica As Integer, ByVal inVigencia As Integer)

        Try
            If dtComparativoDeLiquidacion.Rows.Count > 0 Then

                ' limpia las tarifas
                vl_doTarifa_0_a_10 = 0.0
                vl_doTarifa_11_a_28 = 0.0
                vl_doTarifa_29_a_46 = 0.0
                vl_doTarifa_47_a_64 = 0.0
                vl_doTarifa_65_a_84 = 0.0
                vl_doTarifa_85_a_100 = 0.0

                ' limpia contadores
                vl_inContador_Tarifa_0_a_10 = 1
                vl_inContador_Tarifa_11_a_28 = 1
                vl_inContador_Tarifa_29_a_46 = 1
                vl_inContador_Tarifa_47_a_64 = 1
                vl_inContador_Tarifa_65_a_84 = 1
                vl_inContador_Tarifa_85_a_100 = 1

                ' declara la variable
                Dim i As Integer = 0

                For i = 0 To dtComparativoDeLiquidacion.Rows.Count - 1

                    ' ficha predial
                    Dim inFichaPredial As Integer = CInt(dtComparativoDeLiquidacion.Rows(i).Item("Nro_ficha"))

                    ' declara la variable
                    Dim loValorAvaluoCatastralActual As Long = CLng(dtComparativoDeLiquidacion.Rows(i).Item("Avaluo_" & (inVigencia)))
                    Dim loValorImpuestoPredialAnterior As Long = CLng(dtComparativoDeLiquidacion.Rows(i).Item("Predial_" & (inVigencia - 1)))
                    Dim inPuntosCalificacion As Integer = CInt(dtComparativoDeLiquidacion.Rows(i).Item("Puntos"))

                    Dim stZonaEco As String = fun_extraerZonas(CStr(Trim(dtComparativoDeLiquidacion.Rows(i).Item("Zona_" & (inVigencia)).ToString)))
                    Dim inZonaEco As Integer = 0

                    ' verifica si el campo es numerico
                    If fun_Verificar_Dato_Numerico_Evento_Validated(Trim(stZonaEco)) = True Then
                        inZonaEco = CInt(stZonaEco)
                    End If

                    ' verifica que la zona del predio sea la zona aplicada
                    If CInt(inZonaEconomica) = CInt(inZonaEco) Then

                        ' declara la tarifa
                        Dim doTarifaAsignada As Double = 1.0
                        Dim loValorImpuestoPredialNuevo As Long = 0
                        Dim inPorIncremento As Integer = 0

                        ' declara la variable
                        Dim sw1 As Byte = 0
                        Dim j1 As Double = 1.0

                        While j1 < 16.0 And sw1 = 0

                            ' almaceno la liquidacion nuevo
                            loValorImpuestoPredialNuevo = CLng(loValorAvaluoCatastralActual * doTarifaAsignada) / 1000

                            ' almaceno el porcentaje de incremento
                            inPorIncremento = (((loValorImpuestoPredialNuevo * 100) / loValorImpuestoPredialAnterior) - 100)

                            If CInt(inPorIncremento) >= CInt(Me.nudPorcentajePromedioRCI.Value) Then
                                sw1 = 1

                            Else
                                ' incrementa la tarifa
                                doTarifaAsignada += (0.01)
                                j1 += (0.01)

                            End If

                        End While

                        ' almacena la tarifa y cuenta los registros
                        If CInt(inPuntosCalificacion) >= 0 And CInt(inPuntosCalificacion) <= 10 Then
                            vl_doTarifa_0_a_10 += doTarifaAsignada
                            vl_inContador_Tarifa_0_a_10 += 1
                        End If

                        If CInt(inPuntosCalificacion) >= 11 And CInt(inPuntosCalificacion) <= 28 Then
                            vl_doTarifa_11_a_28 += doTarifaAsignada
                            vl_inContador_Tarifa_11_a_28 += 1
                        End If

                        If CInt(inPuntosCalificacion) >= 29 And CInt(inPuntosCalificacion) <= 46 Then
                            vl_doTarifa_29_a_46 += doTarifaAsignada
                            vl_inContador_Tarifa_29_a_46 += 1
                        End If

                        If CInt(inPuntosCalificacion) >= 47 And CInt(inPuntosCalificacion) <= 64 Then
                            vl_doTarifa_47_a_64 += doTarifaAsignada
                            vl_inContador_Tarifa_47_a_64 += 1
                        End If

                        If CInt(inPuntosCalificacion) >= 65 And CInt(inPuntosCalificacion) <= 84 Then
                            vl_doTarifa_65_a_84 += doTarifaAsignada
                            vl_inContador_Tarifa_65_a_84 += 1
                        End If

                        If CInt(inPuntosCalificacion) >= 85 Then
                            vl_doTarifa_85_a_100 += doTarifaAsignada
                            vl_inContador_Tarifa_85_a_100 += 1
                        End If

                    End If

                Next

            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub pro_CacularTarifaLote(ByVal inZonaEconomica As Integer, ByVal inVigencia As Integer)

        Try
            If dtComparativoDeLiquidacion.Rows.Count > 0 Then

                ' limpia las tarifas
                vl_doTarifa_Lote = 0.0

                ' limpia contadores
                vl_inContador_Tarifa_Lote = 1

                ' declara la variable
                Dim i As Integer = 0

                For i = 0 To dtComparativoDeLiquidacion.Rows.Count - 1

                    ' ficha predial
                    Dim inFichaPredial As Integer = CInt(dtComparativoDeLiquidacion.Rows(i).Item("Nro_ficha"))

                    ' declara la variable
                    Dim loValorAvaluoCatastralActual As Long = CLng(dtComparativoDeLiquidacion.Rows(i).Item("Avaluo_" & (inVigencia)))
                    Dim loValorImpuestoPredialAnterior As Long = CLng(dtComparativoDeLiquidacion.Rows(i).Item("Predial_" & (inVigencia - 1)))

                    Dim stZonaEco As String = CStr(Trim(dtComparativoDeLiquidacion.Rows(i).Item("Zona_" & (inVigencia)).ToString.Substring(0, 2)))
                    Dim inZonaEco As Integer = 0

                    ' verifica si el campo es numerico
                    If fun_Verificar_Dato_Numerico_Evento_Validated(Trim(stZonaEco)) = True Then
                        inZonaEco = CInt(stZonaEco)
                    End If

                    ' verifica que la zona del predio sea la zona aplicada
                    If CInt(inZonaEconomica) = CInt(inZonaEco) Then

                        ' declara la tarifa
                        Dim doTarifaAsignada As Double = 1.0
                        Dim loValorImpuestoPredialNuevo As Long = 0
                        Dim inPorIncremento As Integer = 0

                        ' declara la variable
                        Dim sw1 As Byte = 0
                        Dim j1 As Double = 1.0

                        While j1 < 33.0 And sw1 = 0

                            ' almaceno la liquidacion nuevo
                            loValorImpuestoPredialNuevo = CLng(loValorAvaluoCatastralActual * doTarifaAsignada) / 1000

                            ' almaceno el porcentaje de incremento
                            inPorIncremento = (((loValorImpuestoPredialNuevo * 100) / loValorImpuestoPredialAnterior) - 100)

                            If CInt(inPorIncremento) >= CInt(Me.nudPorcentajePromedioLote.Value) Then
                                sw1 = 1

                            Else
                                ' incrementa la tarifa
                                doTarifaAsignada += (0.01)
                                j1 += (0.01)

                            End If

                        End While

                        ' almacena la tarifa y cuenta los registros
                        vl_doTarifa_Lote += doTarifaAsignada
                        vl_inContador_Tarifa_Lote += 1

                    End If

                Next

            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub pro_AsignarTarifaMinima(ByVal stDepartamento As String, _
                                        ByVal stMunicipio As String, _
                                        ByVal inSector As Integer, _
                                        ByVal inZonaEconomica As Integer, _
                                        ByVal inVigencia As Integer, _
                                        ByVal doTarifa1 As Double, _
                                        ByVal doTarifa2 As Double, _
                                        ByVal doTarifa3 As Double, _
                                        ByVal doTarifa4 As Double, _
                                        ByVal doTarifa5 As Double, _
                                        ByVal doTarifa6 As Double, _
                                        ByVal doIncremento As Double)

        ' declara las tarifas
        Dim doTarifa1_1 As Double = doTarifa1
        Dim doTarifa2_2 As Double = doTarifa2
        Dim doTarifa3_3 As Double = doTarifa3
        Dim doTarifa4_4 As Double = doTarifa4
        Dim doTarifa5_5 As Double = doTarifa5
        Dim doTarifa6_6 As Double = doTarifa6

        ' aplica tarifas minimas
        If Me.chkAplicarTarifaMinima.Checked = True Then

            If inVigencia = 2012 Then

                If CDbl((doTarifa1_1)) <= CDbl(3.0) Then
                    doTarifa1_1 = 3.0
                End If
                If CDbl((doTarifa2_2)) <= CDbl(3.0) Then
                    doTarifa2_2 = 3.0
                End If
                If CDbl((doTarifa3_3)) <= CDbl(3.0) Then
                    doTarifa3_3 = 3.0
                End If
                If CDbl((doTarifa4_4)) <= CDbl(3.0) Then
                    doTarifa4_4 = 3.0
                End If
                If CDbl((doTarifa5_5)) <= CDbl(3.0) Then
                    doTarifa5_5 = 3.0
                End If
                If CDbl((doTarifa6_6)) <= CDbl(3.0) Then
                    doTarifa6_6 = 3.0
                End If

            ElseIf inVigencia = 2013 Then

                If CDbl((doTarifa1_1)) <= CDbl(4.0) Then
                    doTarifa1_1 = 4.0
                End If
                If CDbl((doTarifa2_2)) <= CDbl(4.0) Then
                    doTarifa2_2 = 4.0
                End If
                If CDbl((doTarifa3_3)) <= CDbl(4.0) Then
                    doTarifa3_3 = 4.0
                End If
                If CDbl((doTarifa4_4)) <= CDbl(4.0) Then
                    doTarifa4_4 = 4.0
                End If
                If CDbl((doTarifa5_5)) <= CDbl(4.0) Then
                    doTarifa5_5 = 4.0
                End If
                If CDbl((doTarifa6_6)) <= CDbl(4.0) Then
                    doTarifa6_6 = 4.0
                End If

            ElseIf inVigencia = 2014 Then

                If CDbl((doTarifa1_1)) <= CDbl(5.0) Then
                    doTarifa1_1 = 5.0
                End If
                If CDbl((doTarifa2_2)) <= CDbl(5.0) Then
                    doTarifa2_2 = 5.0
                End If
                If CDbl((doTarifa3_3)) <= CDbl(5.0) Then
                    doTarifa3_3 = 5.0
                End If
                If CDbl((doTarifa4_4)) <= CDbl(5.0) Then
                    doTarifa4_4 = 5.0
                End If
                If CDbl((doTarifa5_5)) <= CDbl(5.0) Then
                    doTarifa5_5 = 5.0
                End If
                If CDbl((doTarifa6_6)) <= CDbl(5.0) Then
                    doTarifa6_6 = 5.0
                End If

            End If

            ' tarifas minimas para el Municipio de Enviado
            If CStr(Trim(stMunicipio)) = "266" Then

                If CDbl((doTarifa1_1)) <= CDbl(5.0) Then
                    doTarifa1_1 = 5.0
                End If
                If CDbl((doTarifa2_2)) <= CDbl(5.0) Then
                    doTarifa2_2 = 5.0
                End If
                If CDbl((doTarifa3_3)) <= CDbl(5.0) Then
                    doTarifa3_3 = 5.0
                End If
                If CDbl((doTarifa4_4)) <= CDbl(5.0) Then
                    doTarifa4_4 = 5.0
                End If
                If CDbl((doTarifa5_5)) <= CDbl(5.0) Then
                    doTarifa5_5 = 5.0
                End If
                If CDbl((doTarifa6_6)) <= CDbl(5.0) Then
                    doTarifa6_6 = 5.0
                End If

            End If

        End If

        ' aplica incremento a la tarifa
        If Me.chkAplicarIncrementoMilaje.Checked = True Then

            If CDbl(doTarifa1_1) >= CDbl(doTarifa2_2) Then
                doTarifa2_2 = CDbl(doTarifa1_1) + CDbl(Me.nudAplicarIncrementoMilaje.Value)
            End If

            If CDbl(doTarifa2_2) >= CDbl(doTarifa3_3) Then
                doTarifa3_3 = CDbl(doTarifa2_2) + CDbl(Me.nudAplicarIncrementoMilaje.Value)
            End If

            If CDbl(doTarifa3_3) >= CDbl(doTarifa4_4) Then
                doTarifa4_4 = CDbl(doTarifa3_3) + CDbl(Me.nudAplicarIncrementoMilaje.Value)
            End If

            If CDbl(doTarifa4_4) >= CDbl(doTarifa5_5) Then
                doTarifa5_5 = CDbl(doTarifa4_4) + CDbl(Me.nudAplicarIncrementoMilaje.Value)
            End If

            If CDbl(doTarifa5_5) >= CDbl(doTarifa6_6) Then
                doTarifa6_6 = CDbl(doTarifa5_5) + CDbl(Me.nudAplicarIncrementoMilaje.Value)
            End If

        End If

        ' llena las tarifas globales
        vl_doTarifa1_1 = doTarifa1_1
        vl_doTarifa2_2 = doTarifa2_2
        vl_doTarifa3_3 = doTarifa3_3
        vl_doTarifa4_4 = doTarifa4_4
        vl_doTarifa5_5 = doTarifa5_5
        vl_doTarifa6_6 = doTarifa6_6

    End Sub

#End Region

#Region "MENU"

    Private Sub cmdLIQUIDAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdLIQUIDAR.Click

        Try
            ' verifica la vigencia
            If Me.cboASTAVIGE.Text = "" Then
                MessageBox.Show("Ingrese la vigencia", "Mensaje ...", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1)
                Me.cboASTAVIGE.Focus()
            Else
                If Me.cboASTACLSE.Text = "" Then
                    MessageBox.Show("Ingrese el sector", "Mensaje ...", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1)
                    Me.cboASTACLSE.Focus()
                Else
                    ' valores predeterminados
                    Me.cmdLIQUIDAR.Enabled = False

                    ' limpia la tabla
                    dtZonasEconomicas = New DataTable

                    ' carga las zonas economicas
                    dtZonasEconomicas = fun_CargarZonasEconomicas(Trim(Me.txtFIPRMUNI.Text), Me.cboASTACLSE.SelectedValue, Me.cboASTAVIGE.SelectedValue)

                    ' valida las zonas que existan registros
                    If dtZonasEconomicas.Rows.Count > 0 Then

                        If MessageBox.Show("Se registraron: " & dtZonasEconomicas.Rows.Count & " zonas económicas. " & " ¿ Desea continuar ? ", "Mensaje ...", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then

                            ' Valores predeterminados ProgressBar
                            inProceso = 0
                            Me.pbPROCESO.Value = 0
                            Me.pbPROCESO.Maximum = dtZonasEconomicas.Rows.Count
                            Me.Timer1.Enabled = True

                            ' declara la variable
                            Dim inRegistrosModificados As Integer = 0

                            'Recorre el rango asignado
                            Dim i As Integer

                            ' recorre la fichas consultadas
                            For i = 0 To dtZonasEconomicas.Rows.Count - 1

                                ' carga las variables
                                Dim stTAZEDEPA As String = CStr(Trim(dtZonasEconomicas.Rows(i).Item("TAZEDEPA").ToString))
                                Dim stTAZEMUNI As String = CStr(Trim(dtZonasEconomicas.Rows(i).Item("TAZEMUNI").ToString))
                                Dim inTAZEZOEC As Integer = CInt(dtZonasEconomicas.Rows(i).Item("TAZEZOEC"))
                                Dim inTAZECLSE As Integer = CInt(dtZonasEconomicas.Rows(i).Item("TAZECLSE"))
                                Dim inTAZEVIGE As Integer = CInt(dtZonasEconomicas.Rows(i).Item("TAZEVIGE"))

                                Dim doTAZEPORC As Double = CDbl(dtZonasEconomicas.Rows(i).Item("TAZEPORC"))

                                ' limpia la tabla
                                dtComparativoDeLiquidacion = New DataTable

                                ' selecciona zona residencial, comercial e industrial
                                If Me.rbdAsignarTarifasRCI.Checked = True Then

                                    ' carga la tabla
                                    dtComparativoDeLiquidacion = fun_ComparativoDeLiquidacionRCI(stTAZEDEPA, stTAZEMUNI, inTAZECLSE, inTAZEZOEC, inTAZEVIGE)

                                    ' verifica si existen registros
                                    If dtComparativoDeLiquidacion.Rows.Count > 0 Then

                                        ' calcula la tarifa de la zona por puntos
                                        pro_CacularTarifaRCI(inTAZEZOEC, inTAZEVIGE)

                                        ' actualiza la matriz tarifaria
                                        If fun_ActualizaMatrizRCI(stTAZEDEPA, _
                                                                  stTAZEMUNI, _
                                                                  inTAZECLSE, _
                                                                  inTAZEZOEC, _
                                                                  inTAZEVIGE, _
                                                                  vl_doTarifa_0_a_10, _
                                                                  vl_doTarifa_11_a_28, _
                                                                  vl_doTarifa_29_a_46, _
                                                                  vl_doTarifa_47_a_64, _
                                                                  vl_doTarifa_65_a_84, _
                                                                  vl_doTarifa_85_a_100, _
                                                                  doTAZEPORC) = True Then

                                            inRegistrosModificados += 1
                                        End If

                                    End If

                                    ' selecciona zona de lotes
                                ElseIf Me.rbdAsignarTarifasLote.Checked = True Then

                                    ' carga la tabla
                                    dtComparativoDeLiquidacion = fun_ComparativoDeLiquidacionLOTE(stTAZEDEPA, stTAZEMUNI, inTAZECLSE, inTAZEZOEC, inTAZEVIGE)

                                    ' verifica si existen registros
                                    If dtComparativoDeLiquidacion.Rows.Count > 0 Then

                                        ' calcula la tarifa de la zona por puntos
                                        pro_CacularTarifaLote(inTAZEZOEC, inTAZEVIGE)

                                        ' actualiza la matriz tarifaria
                                        If fun_ActualizaMatrizLote(stTAZEDEPA, _
                                                                   stTAZEMUNI, _
                                                                   inTAZECLSE, _
                                                                   inTAZEZOEC, _
                                                                   inTAZEVIGE, _
                                                                   vl_doTarifa_Lote) = True Then

                                            inRegistrosModificados += 1
                                        End If

                                    Else
                                        ' se cargar la variable
                                        vl_doTarifa_Lote = 33.0

                                        ' actualiza la matriz tarifaria
                                        If fun_ActualizaMatrizLote(stTAZEDEPA, _
                                                                   stTAZEMUNI, _
                                                                   inTAZECLSE, _
                                                                   inTAZEZOEC, _
                                                                   inTAZEVIGE, _
                                                                   vl_doTarifa_Lote) = True Then

                                            inRegistrosModificados += 1
                                        End If

                                    End If

                                End If

                                ' incrementa la barra
                                inProceso = inProceso + 1
                                Me.pbPROCESO.Value = inProceso

                            Next

                            ' Llena el datagrigview
                            Me.pbPROCESO.Value = 0

                            MessageBox.Show("Proceso terminado correctamente se actualizaron " & inRegistrosModificados & " registros.", "Mensaje ...", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)

                        End If

                    Else
                        ' Mensaje terminacion
                        MessageBox.Show("NO existen registros con los parametros asignados", "Mensaje ...", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                        Me.strBARRESTA.Items(2).Text = "Registros : 0"
                    End If

                    Me.cmdLIQUIDAR.Enabled = True
                    Me.cmdLIQUIDAR.Focus()

                End If
            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
            cmdLIQUIDAR.Enabled = True
        End Try

    End Sub
    Private Sub cmdLIMPIAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdLIMPIAR.Click
        pro_LimpiarCampos()
    End Sub
    Private Sub cmdSALIR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSALIR.Click
        pro_LimpiarCampos()
        Me.Close()
    End Sub
    Private Sub cmdAplicarIncrementoTarifario_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAplicarIncrementoTarifario.Click

        Try
            ' verifica la vigencia
            If Me.cboASTAVIGE.Text = "" Then
                MessageBox.Show("Ingrese la vigencia", "Mensaje ...", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1)
                Me.cboASTAVIGE.Focus()
            Else
                If Me.cboASTACLSE.Text = "" Then
                    MessageBox.Show("Ingrese el sector", "Mensaje ...", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1)
                    Me.cboASTACLSE.Focus()
                Else
                    ' valores predeterminados
                    Me.cmdAplicarIncrementoTarifario.Enabled = False

                    ' limpia la tabla
                    dtZonasEconomicas = New DataTable

                    ' carga las zonas economicas
                    dtZonasEconomicas = fun_CargarZonasEconomicas(Trim(Me.txtFIPRMUNI.Text), Me.cboASTACLSE.SelectedValue, Me.cboASTAVIGE.SelectedValue)

                    ' valida las zonas que existan registros
                    If dtZonasEconomicas.Rows.Count > 0 Then

                        If MessageBox.Show("Se registraron: " & dtZonasEconomicas.Rows.Count & " zonas económicas. " & " ¿ Desea continuar ? ", "Mensaje ...", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then

                            ' Valores predeterminados ProgressBar
                            inProceso = 0
                            Me.pbPROCESO.Value = 0
                            Me.pbPROCESO.Maximum = dtZonasEconomicas.Rows.Count
                            Me.Timer1.Enabled = True

                            ' declara la variable
                            Dim inRegistrosModificados As Integer = 0

                            'Recorre el rango asignado
                            Dim i As Integer

                            ' recorre la fichas consultadas
                            For i = 0 To dtZonasEconomicas.Rows.Count - 1

                                ' carga las variables
                                Dim stTAZEDEPA As String = CStr(Trim(dtZonasEconomicas.Rows(i).Item("TAZEDEPA").ToString))
                                Dim stTAZEMUNI As String = CStr(Trim(dtZonasEconomicas.Rows(i).Item("TAZEMUNI").ToString))
                                Dim inTAZEZOEC As Integer = CInt(dtZonasEconomicas.Rows(i).Item("TAZEZOEC"))
                                Dim inTAZECLSE As Integer = CInt(dtZonasEconomicas.Rows(i).Item("TAZECLSE"))
                                Dim inTAZEVIGE As Integer = CInt(dtZonasEconomicas.Rows(i).Item("TAZEVIGE"))

                                Dim doTAZETA01 As Double = CDbl(dtZonasEconomicas.Rows(i).Item("TAZETA01"))
                                Dim doTAZETA02 As Double = CDbl(dtZonasEconomicas.Rows(i).Item("TAZETA02"))
                                Dim doTAZETA03 As Double = CDbl(dtZonasEconomicas.Rows(i).Item("TAZETA03"))
                                Dim doTAZETA04 As Double = CDbl(dtZonasEconomicas.Rows(i).Item("TAZETA04"))
                                Dim doTAZETA05 As Double = CDbl(dtZonasEconomicas.Rows(i).Item("TAZETA05"))
                                Dim doTAZETA06 As Double = CDbl(dtZonasEconomicas.Rows(i).Item("TAZETA06"))

                                Dim doTAZEPORC As Double = CDbl(dtZonasEconomicas.Rows(i).Item("TAZEPORC"))
                                Dim stTAZESIGN As Double = CStr(dtZonasEconomicas.Rows(i).Item("TAZESIGN"))

                                ' actualiza la matriz tarifaria
                                If fun_ActualizaMatrizIncremento(stTAZEDEPA, _
                                                                 stTAZEMUNI, _
                                                                 inTAZECLSE, _
                                                                 inTAZEZOEC, _
                                                                 inTAZEVIGE, _
                                                                 doTAZETA01, _
                                                                 doTAZETA02, _
                                                                 doTAZETA03, _
                                                                 doTAZETA04, _
                                                                 doTAZETA05, _
                                                                 doTAZETA06, _
                                                                 stTAZESIGN, _
                                                                 doTAZEPORC) = True Then

                                    inRegistrosModificados += 1

                                End If

                                ' incrementa la barra
                                inProceso = inProceso + 1
                                Me.pbPROCESO.Value = inProceso

                            Next

                            ' Llena el datagrigview
                            Me.pbPROCESO.Value = 0

                            MessageBox.Show("Proceso terminado correctamente se actualizaron " & inRegistrosModificados & " registros.", "Mensaje ...", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)

                        End If

                    Else
                        ' Mensaje terminacion
                        MessageBox.Show("NO existen registros con los parametros asignados", "Mensaje ...", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                        Me.strBARRESTA.Items(2).Text = "Registros : 0"
                    End If

                    Me.cmdAplicarIncrementoTarifario.Enabled = True
                    Me.cmdAplicarIncrementoTarifario.Focus()

                End If
            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
            cmdLIQUIDAR.Enabled = True
        End Try

    End Sub

#End Region

#Region "FORMULARIO"

#Region "Load"

    Private Sub frm_REPO_FIPRINCO_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        pro_LimpiarCampos()
    End Sub

#End Region

#Region "KeyPress"

    Private Sub cboTAAPVIGE_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboASTAVIGE.KeyPress
        If Not Char.IsNumber(e.KeyChar) Then
            If e.KeyChar <> Convert.ToChar(Keys.Back) Then
                If e.KeyChar <> Convert.ToChar(37) Then
                    If e.KeyChar <> Convert.ToChar(Keys.Enter) Then
                        e.Handled = True
                        strBARRESTA.Items(1).Text = IncoValoNume
                        mod_MENSAJE.Inco_Valo_Nume()
                    Else
                        strBARRESTA.Items(1).Text = ""
                        txtFIPRMUNI.Focus()
                    End If
                End If
            End If
        End If
    End Sub
    Private Sub cboAFSICONC_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            Me.cboASTAVIGE.Focus()
        End If
    End Sub
    Private Sub cboFIPRVIGE_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboASTAVIGE.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            Me.cboASTACLSE.Focus()
        End If
    End Sub
    Private Sub cboFIPRCLSE_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboASTACLSE.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            Me.cmdLIQUIDAR.Focus()
        End If
    End Sub

#End Region

#Region "GotFocus"

    Private Sub cboTAAPVIGE_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboASTAVIGE.GotFocus
        strBARRESTA.Items(0).Text = cboASTAVIGE.AccessibleDescription
    End Sub
    Private Sub cboTAAPCLSE_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboASTACLSE.GotFocus
        strBARRESTA.Items(0).Text = cboASTACLSE.AccessibleDescription
    End Sub
    Private Sub txtFIPRMUNI_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFIPRMUNI.GotFocus
        txtFIPRMUNI.SelectionStart = 0
        txtFIPRMUNI.SelectionLength = Len(txtFIPRMUNI.Text)
        strBARRESTA.Items(0).Text = txtFIPRMUNI.AccessibleDescription
    End Sub
    Private Sub cboFIPRCLSE_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboASTACLSE.GotFocus
        strBARRESTA.Items(0).Text = cboASTACLSE.AccessibleDescription
    End Sub
    Private Sub cmdVALIDAR_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdLIQUIDAR.GotFocus
        strBARRESTA.Items(0).Text = cmdLIQUIDAR.AccessibleDescription
    End Sub
    Private Sub cmdLIMPIAR_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdLIMPIAR.GotFocus
        strBARRESTA.Items(0).Text = cmdLIMPIAR.AccessibleDescription
    End Sub
    Private Sub cmdSALIR_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdSALIR.GotFocus
        strBARRESTA.Items(0).Text = cmdSALIR.AccessibleDescription
    End Sub

#End Region

#Region "Validated"

    Private Sub txtFIPRMUNI_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFIPRMUNI.Validated
        If Trim(Me.txtFIPRMUNI.Text) <> "" Then
            txtFIPRMUNI.Text = fun_Formato_Mascara_3_String(Me.txtFIPRMUNI.Text)
        End If
    End Sub

#End Region

#Region "Click"

    Private Sub cboFIPRCLSE_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboASTACLSE.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_CLASSECT_Descripcion(Me.cboASTACLSE, Me.cboASTACLSE.SelectedIndex)
    End Sub
    Private Sub cboFIPRVIGE_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboASTAVIGE.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_VIGENCIA_Descripcion(Me.cboASTAVIGE, Me.cboASTAVIGE.SelectedIndex)
    End Sub

#End Region

#Region "KeyDown"

    Private Sub cboFIPRCLSE_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboASTACLSE.KeyDown
        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
            fun_Cargar_ComboBox_Con_Datos_Activos_CLASSECT_Descripcion(Me.cboASTACLSE, Me.cboASTACLSE.SelectedIndex)
        End If
    End Sub
    Private Sub cboFIPRVIGE_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboASTAVIGE.KeyDown
        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
            fun_Cargar_ComboBox_Con_Datos_Activos_VIGENCIA_Descripcion(Me.cboASTAVIGE, Me.cboASTAVIGE.SelectedIndex)
        End If
    End Sub

#End Region

#Region "SelectedIndexChanged"

    Private Sub cboFIPRCLSE_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboASTACLSE.SelectedIndexChanged
        Me.lblASTACLSE.Text = CType(fun_Buscar_Lista_Valores_CLASSECT_Codigo(Me.cboASTACLSE), String)
    End Sub
    Private Sub cboFIPRVIGE_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboASTAVIGE.SelectedIndexChanged
        Me.lblASTAVIGE.Text = CType(fun_Buscar_Lista_Valores_VIGENCIA_Codigo(Me.cboASTAVIGE), String)
    End Sub

#End Region

#Region "CheckedChanged"

    Private Sub chkAplicarIncrementoMilaje_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkAplicarIncrementoMilaje.CheckedChanged

        If Me.chkAplicarIncrementoMilaje.Checked = True Then
            Me.nudAplicarIncrementoMilaje.Visible = True
        Else
            Me.nudAplicarIncrementoMilaje.Visible = False
        End If

    End Sub
    Private Sub chkAplicarPorcentajePromedioRCI_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkAplicarPorcentajePromedioRCI.CheckedChanged

        If Me.chkAplicarPorcentajePromedioRCI.Checked = True Then
            Me.nudPorcentajePromedioRCI.Visible = True
        Else
            Me.nudPorcentajePromedioRCI.Visible = False
        End If

    End Sub
    Private Sub chkAplicarPorcentajePromedioLotes_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkAplicarPorcentajePromedioLotes.CheckedChanged

        If Me.chkAplicarPorcentajePromedioLotes.Checked = True Then
            Me.nudPorcentajePromedioLote.Visible = True
        Else
            Me.nudPorcentajePromedioLote.Visible = False
        End If

    End Sub
    Private Sub rbdAsignarTarifasRCI_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbdAsignarTarifasRCI.CheckedChanged, rbdAsignarTarifasLote.CheckedChanged

        If Me.rbdAsignarTarifasRCI.Checked = True Then
            Me.nudPorcentajePromedioRCI.Visible = True
            Me.nudPorcentajePromedioLote.Visible = False

            Me.chkAplicarPorcentajePromedioRCI.Checked = True
            Me.chkAplicarPorcentajePromedioLotes.Checked = False

            Me.chkAplicarPorcentajePromedioRCI.Visible = True
            Me.chkAplicarPorcentajePromedioLotes.Visible = False

        ElseIf Me.rbdAsignarTarifasLote.Checked = True Then
            Me.nudPorcentajePromedioLote.Visible = True
            Me.nudPorcentajePromedioRCI.Visible = False

            Me.chkAplicarPorcentajePromedioLotes.Checked = True
            Me.chkAplicarPorcentajePromedioRCI.Checked = False

            Me.chkAplicarPorcentajePromedioRCI.Visible = False
            Me.chkAplicarPorcentajePromedioLotes.Visible = True
        End If

    End Sub
    Private Sub chkSumaIncrementoTarifario_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkSumaIncrementoTarifario.CheckedChanged

        If Me.chkSumaIncrementoTarifario.Checked = True Then
            Me.cmdAplicarIncrementoTarifario.Visible = True
        Else
            Me.cmdAplicarIncrementoTarifario.Visible = False
        End If

    End Sub

#End Region

#End Region

End Class