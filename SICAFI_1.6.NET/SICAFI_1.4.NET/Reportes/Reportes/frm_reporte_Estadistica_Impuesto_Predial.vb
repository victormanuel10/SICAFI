Imports REGLAS_DEL_NEGOCIO
Imports System
Imports System.IO
Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration
Imports System.Text

Public Class frm_reporte_Estadistica_Impuesto_Predial

    '=======================================
    '*** ESTADISTICAS SUJETO DE IMPUESTO ***
    '=======================================

#Region "VARIABLES"

    Dim inFICHAPREDIAL As Integer = 0

    Private oEjecutar As New SqlCommand
    Private oConexion As New SqlConnection
    Private oAdapter As New SqlDataAdapter
    Private oReader As SqlDataReader
    Private ds As New DataSet
    Private dtConsulta1 As New DataTable
    Private dtConsulta2 As New DataTable

    Dim dt1 As New DataTable
    Dim dt2 As New DataTable
    Dim dr1 As DataRow
    Dim dr2 As DataRow

    Dim inNroConstruccionesTotales As Integer
    Dim stSeparador As String = ""

#End Region

#Region "INSTANCIAR FORMULARIO"

    Private Shared frm_Instance = Nothing

    Public Shared Function instance() As frm_reporte_Estadistica_Impuesto_Predial
        If frm_Instance Is Nothing OrElse frm_Instance.isdisposed = True Then
            frm_Instance = New frm_reporte_Estadistica_Impuesto_Predial
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

    Private Function fun_ConsultarFichaPredialPorZonaEconomica(ByVal inZonaEconomica As Integer, ByVal inVigencia As Integer) As DataTable

        Try

            ' buscar cadena de conexion
            Dim oCadenaConexion1 As New REGLAS_DEL_NEGOCIO.cla_ConnectionString
            Dim stCadenaConexion1 As String = oCadenaConexion1.fun_ConnectionString

            ' crea el datatable
            Dim dtConsulta As New DataTable

            ' crear conexión
            oAdapter = New SqlDataAdapter
            oConexion = New SqlConnection(stCadenaConexion1)

            ' abre la conexion
            oConexion.Open()

            ' parametros de la consulta
            Dim ParametrosConsulta1 As String = ""

            ' Concatena la condicion de la consulta
            ParametrosConsulta1 += "Select "
            ParametrosConsulta1 += "HizoNufi, "
            ParametrosConsulta1 += "HizoZoec, "
            ParametrosConsulta1 += "HizoVige, "
            ParametrosConsulta1 += "HizoPorc  "
            ParametrosConsulta1 += "From HistZona, SujeImpu where "
            ParametrosConsulta1 += "SuimNufi = HizoNufi and "
            ParametrosConsulta1 += "SuimClse = HizoClse and "
            ParametrosConsulta1 += "HizoVige = '" & CInt(inVigencia) & "' and "
            ParametrosConsulta1 += "HizoZoec = '" & CInt(inZonaEconomica) & "' and "
            ParametrosConsulta1 += "SuimMuni like '" & Trim(Me.txtFIPRMUNI.Text) & "' and "
            ParametrosConsulta1 += "SuimCorr like '" & Trim(Me.txtFIPRCORR.Text) & "' and "
            ParametrosConsulta1 += "SuimBarr like '" & Trim(Me.txtFIPRBARR.Text) & "' and "
            ParametrosConsulta1 += "SuimManz like '" & Trim(Me.txtFIPRMANZ.Text) & "' and "
            ParametrosConsulta1 += "SuimPred like '" & Trim(Me.txtFIPRPRED.Text) & "' and "
            ParametrosConsulta1 += "SuimEdif like '" & Trim(Me.txtFIPREDIF.Text) & "' and "
            ParametrosConsulta1 += "SuimUnpr like '" & Trim(Me.txtFIPRUNPR.Text) & "' and "
            ParametrosConsulta1 += "SuimClse like '" & Trim(Me.txtFIPRCLSE.Text) & "' and "
            ParametrosConsulta1 += "SuimNufi between '" & Trim(Me.txtFIPRFIIN.Text) & "' and '" & Trim(Me.txtFIPRFIFI.Text) & "' and "
            ParametrosConsulta1 += "HizoTifi = 0 and "
            ParametrosConsulta1 += "SuimEsta = 'ac' and "
            ParametrosConsulta1 += "HizoEsta = 'ac' "

            ' ejecuta la consulta
            oEjecutar = New SqlCommand(ParametrosConsulta1, oConexion)

            ' procesa la consulta 
            oEjecutar.CommandTimeout = 0
            oEjecutar.CommandType = CommandType.Text
            oAdapter.SelectCommand = oEjecutar

            ' llena el datatable 
            oAdapter.Fill(dtConsulta)

            ' cierra la conexion
            oConexion.Close()

            Return dtConsulta

        Catch ex As Exception
            MessageBox.Show(Err.Description)
            Return Nothing
        End Try

    End Function
    Private Function fun_ConsultarFichaPredialPorZonaEconomica(ByVal inVigencia As Integer) As DataTable

        Try
            ' buscar cadena de conexion
            Dim oCadenaConexion1 As New REGLAS_DEL_NEGOCIO.cla_ConnectionString
            Dim stCadenaConexion1 As String = oCadenaConexion1.fun_ConnectionString

            ' crea el datatable
            Dim dtConsulta As New DataTable

            ' crear conexión
            oAdapter = New SqlDataAdapter
            oConexion = New SqlConnection(stCadenaConexion1)

            ' abre la conexion
            oConexion.Open()

            ' parametros de la consulta
            Dim ParametrosConsulta1 As String = ""

            ' Concatena la condicion de la consulta
            ParametrosConsulta1 += "Select "
            ParametrosConsulta1 += "HizoZoec, "
            ParametrosConsulta1 += "ZoecDesc, "
            ParametrosConsulta1 += "count(HizoZoec) as HizoCant "
            ParametrosConsulta1 += "From HistZona, SujeImpu, Mant_ZonaEcon where "
            ParametrosConsulta1 += "SuimNufi = HizoNufi and "
            ParametrosConsulta1 += "SuimClse = HizoClse and "
            ParametrosConsulta1 += "HizoDepa = ZoecDepa and "
            ParametrosConsulta1 += "HizoMuni = ZoecMuni and "
            ParametrosConsulta1 += "HizoZoec = ZoecCodi and "
            ParametrosConsulta1 += "HizoClse = ZoecClse and "
            ParametrosConsulta1 += "HizoVige = '" & CInt(inVigencia) & "' and "
            ParametrosConsulta1 += "SuimMuni like '" & Trim(Me.txtFIPRMUNI.Text) & "' and "
            ParametrosConsulta1 += "SuimCorr like '" & Trim(Me.txtFIPRCORR.Text) & "' and "
            ParametrosConsulta1 += "SuimBarr like '" & Trim(Me.txtFIPRBARR.Text) & "' and "
            ParametrosConsulta1 += "SuimManz like '" & Trim(Me.txtFIPRMANZ.Text) & "' and "
            ParametrosConsulta1 += "SuimPred like '" & Trim(Me.txtFIPRPRED.Text) & "' and "
            ParametrosConsulta1 += "SuimEdif like '" & Trim(Me.txtFIPREDIF.Text) & "' and "
            ParametrosConsulta1 += "SuimUnpr like '" & Trim(Me.txtFIPRUNPR.Text) & "' and "
            ParametrosConsulta1 += "SuimClse like '" & Trim(Me.txtFIPRCLSE.Text) & "' and "
            ParametrosConsulta1 += "SuimNufi between '" & Trim(Me.txtFIPRFIIN.Text) & "' and '" & Trim(Me.txtFIPRFIFI.Text) & "' and "
            ParametrosConsulta1 += "SuimEsta = 'ac' and "
            ParametrosConsulta1 += "HizoEsta = 'ac' "
            ParametrosConsulta1 += "group by HizoZoec,ZoecDesc "
            ParametrosConsulta1 += "order by HizoZoec "

            ' ejecuta la consulta
            oEjecutar = New SqlCommand(ParametrosConsulta1, oConexion)

            ' procesa la consulta 
            oEjecutar.CommandTimeout = 0
            oEjecutar.CommandType = CommandType.Text
            oAdapter.SelectCommand = oEjecutar

            ' llena el datatable 
            oAdapter.Fill(dtConsulta)

            ' cierra la conexion
            oConexion.Close()

            Return dtConsulta

        Catch ex As Exception
            MessageBox.Show(Err.Description)
            Return Nothing
        End Try

    End Function

    Private Function fun_ConsultarFichaPredialPorCedulaCatastral(ByVal stBarrio_Vereda As String, ByVal inSector As Integer) As DataTable

        Try
            ' crea el datatable
            Dim dtConsulta As New DataTable

            If inSector = 1 Then

                ' buscar cadena de conexion
                Dim oCadenaConexion1 As New REGLAS_DEL_NEGOCIO.cla_ConnectionString
                Dim stCadenaConexion1 As String = oCadenaConexion1.fun_ConnectionString

                ' crear conexión
                oAdapter = New SqlDataAdapter
                oConexion = New SqlConnection(stCadenaConexion1)

                ' abre la conexion
                oConexion.Open()

                ' parametros de la consulta
                Dim ParametrosConsulta1 As String = ""

                ' Concatena la condicion de la consulta
                ParametrosConsulta1 += "Select "
                ParametrosConsulta1 += "SuimNufi "
                ParametrosConsulta1 += "From SujeImpu where "
                ParametrosConsulta1 += "SuimBarr = '" & CStr(Trim(stBarrio_Vereda)) & "' and "
                ParametrosConsulta1 += "SuimClse = '" & CInt(inSector) & "' and "
                ParametrosConsulta1 += "SuimEsta = 'ac' "

                ' ejecuta la consulta
                oEjecutar = New SqlCommand(ParametrosConsulta1, oConexion)

                ' procesa la consulta 
                oEjecutar.CommandTimeout = 0
                oEjecutar.CommandType = CommandType.Text
                oAdapter.SelectCommand = oEjecutar

                ' llena el datatable 
                oAdapter.Fill(dtConsulta)

                ' cierra la conexion
                oConexion.Close()

            ElseIf inSector = 2 Then

                ' buscar cadena de conexion
                Dim oCadenaConexion1 As New REGLAS_DEL_NEGOCIO.cla_ConnectionString
                Dim stCadenaConexion1 As String = oCadenaConexion1.fun_ConnectionString

                ' crear conexión
                oAdapter = New SqlDataAdapter
                oConexion = New SqlConnection(stCadenaConexion1)

                ' abre la conexion
                oConexion.Open()

                ' parametros de la consulta
                Dim ParametrosConsulta1 As String = ""

                ' Concatena la condicion de la consulta
                ParametrosConsulta1 += "Select "
                ParametrosConsulta1 += "SuimNufi "
                ParametrosConsulta1 += "From SujeImpu where "
                ParametrosConsulta1 += "SuimBarr = '" & CStr(Trim(stBarrio_Vereda)) & "' and "
                ParametrosConsulta1 += "SuimClse = '" & CInt(inSector) & "' and "
                ParametrosConsulta1 += "SuimEsta = 'ac' "

                ' ejecuta la consulta
                oEjecutar = New SqlCommand(ParametrosConsulta1, oConexion)

                ' procesa la consulta 
                oEjecutar.CommandTimeout = 0
                oEjecutar.CommandType = CommandType.Text
                oAdapter.SelectCommand = oEjecutar

                ' llena el datatable 
                oAdapter.Fill(dtConsulta)

                ' cierra la conexion
                oConexion.Close()

            End If

            Return dtConsulta

        Catch ex As Exception
            MessageBox.Show(Err.Description)
            Return Nothing
        End Try

    End Function
    Private Function fun_ConsultarFichaPredialPorCedulaCatastral(ByVal inSector As Integer) As DataTable

        Try
            ' crea el datatable
            Dim dtConsulta As New DataTable

            If inSector = 1 Then

                ' buscar cadena de conexion
                Dim oCadenaConexion1 As New REGLAS_DEL_NEGOCIO.cla_ConnectionString
                Dim stCadenaConexion1 As String = oCadenaConexion1.fun_ConnectionString

                ' crear conexión
                oAdapter = New SqlDataAdapter
                oConexion = New SqlConnection(stCadenaConexion1)

                ' abre la conexion
                oConexion.Open()

                ' parametros de la consulta
                Dim ParametrosConsulta1 As String = ""

                ' Concatena la condicion de la consulta
                ParametrosConsulta1 += "Select "
                ParametrosConsulta1 += "SuimBarr, "
                ParametrosConsulta1 += "BaveDesc, "
                ParametrosConsulta1 += "count(SuimPred) as SuimCant "
                ParametrosConsulta1 += "From SujeImpu, Mant_BarrVere where "
                ParametrosConsulta1 += "SuimBarr = BaveCodi and "
                ParametrosConsulta1 += "SuimClse = BaveClse and "
                ParametrosConsulta1 += "SuimMuni like '" & Trim(Me.txtFIPRMUNI.Text) & "' and "
                ParametrosConsulta1 += "SuimCorr like '" & Trim(Me.txtFIPRCORR.Text) & "' and "
                ParametrosConsulta1 += "SuimBarr like '" & Trim(Me.txtFIPRBARR.Text) & "' and "
                ParametrosConsulta1 += "SuimManz like '" & Trim(Me.txtFIPRMANZ.Text) & "' and "
                ParametrosConsulta1 += "SuimPred like '" & Trim(Me.txtFIPRPRED.Text) & "' and "
                ParametrosConsulta1 += "SuimEdif like '" & Trim(Me.txtFIPREDIF.Text) & "' and "
                ParametrosConsulta1 += "SuimUnpr like '" & Trim(Me.txtFIPRUNPR.Text) & "' and "
                ParametrosConsulta1 += "SuimClse like '" & Trim(Me.txtFIPRCLSE.Text) & "' and "
                ParametrosConsulta1 += "SuimNufi between '" & Trim(Me.txtFIPRFIIN.Text) & "' and '" & Trim(Me.txtFIPRFIFI.Text) & "' and "
                ParametrosConsulta1 += "SuimEsta = 'ac' "
                ParametrosConsulta1 += "group by SuimBarr,BaveDesc "
                ParametrosConsulta1 += "order by SuimBarr "

                ' ejecuta la consulta
                oEjecutar = New SqlCommand(ParametrosConsulta1, oConexion)

                ' procesa la consulta 
                oEjecutar.CommandTimeout = 0
                oEjecutar.CommandType = CommandType.Text
                oAdapter.SelectCommand = oEjecutar

                ' llena el datatable 
                oAdapter.Fill(dtConsulta)

                ' cierra la conexion
                oConexion.Close()

            ElseIf inSector = 2 Then

                ' buscar cadena de conexion
                Dim oCadenaConexion1 As New REGLAS_DEL_NEGOCIO.cla_ConnectionString
                Dim stCadenaConexion1 As String = oCadenaConexion1.fun_ConnectionString

                ' crear conexión
                oAdapter = New SqlDataAdapter
                oConexion = New SqlConnection(stCadenaConexion1)

                ' abre la conexion
                oConexion.Open()

                ' parametros de la consulta
                Dim ParametrosConsulta1 As String = ""

                ' Concatena la condicion de la consulta
                ParametrosConsulta1 += "Select "
                ParametrosConsulta1 += "SuimManz, "
                ParametrosConsulta1 += "BaveDesc, "
                ParametrosConsulta1 += "count(SuimPred) as SuimCant "
                ParametrosConsulta1 += "From SujeImpu, Mant_BarrVere where "
                ParametrosConsulta1 += "SuimManz = BaveCodi and "
                ParametrosConsulta1 += "SuimClse = BaveClse and "
                ParametrosConsulta1 += "SuimMuni like '" & Trim(Me.txtFIPRMUNI.Text) & "' and "
                ParametrosConsulta1 += "SuimCorr like '" & Trim(Me.txtFIPRCORR.Text) & "' and "
                ParametrosConsulta1 += "SuimBarr like '" & Trim(Me.txtFIPRBARR.Text) & "' and "
                ParametrosConsulta1 += "SuimManz like '" & Trim(Me.txtFIPRMANZ.Text) & "' and "
                ParametrosConsulta1 += "SuimPred like '" & Trim(Me.txtFIPRPRED.Text) & "' and "
                ParametrosConsulta1 += "SuimEdif like '" & Trim(Me.txtFIPREDIF.Text) & "' and "
                ParametrosConsulta1 += "SuimUnpr like '" & Trim(Me.txtFIPRUNPR.Text) & "' and "
                ParametrosConsulta1 += "SuimClse like '" & Trim(Me.txtFIPRCLSE.Text) & "' and "
                ParametrosConsulta1 += "SuimNufi between '" & Trim(Me.txtFIPRFIIN.Text) & "' and '" & Trim(Me.txtFIPRFIFI.Text) & "' and "
                ParametrosConsulta1 += "SuimEsta = 'ac' "
                ParametrosConsulta1 += "group by SuimManz,BaveDesc "
                ParametrosConsulta1 += "order by SuimManz "

                ' ejecuta la consulta
                oEjecutar = New SqlCommand(ParametrosConsulta1, oConexion)

                ' procesa la consulta 
                oEjecutar.CommandTimeout = 0
                oEjecutar.CommandType = CommandType.Text
                oAdapter.SelectCommand = oEjecutar

                ' llena el datatable 
                oAdapter.Fill(dtConsulta)

                ' cierra la conexion
                oConexion.Close()

            End If

            Return dtConsulta

        Catch ex As Exception
            MessageBox.Show(Err.Description)
            Return Nothing
        End Try

    End Function

    Private Function fun_ConsultarFichaPredialPorEstrato(ByVal inEstrato As Integer, ByVal inVigencia As Integer) As DataTable

        Try

            ' buscar cadena de conexion
            Dim oCadenaConexion1 As New REGLAS_DEL_NEGOCIO.cla_ConnectionString
            Dim stCadenaConexion1 As String = oCadenaConexion1.fun_ConnectionString

            ' crea el datatable
            Dim dtConsulta As New DataTable

            ' crear conexión
            oAdapter = New SqlDataAdapter
            oConexion = New SqlConnection(stCadenaConexion1)

            ' abre la conexion
            oConexion.Open()

            ' parametros de la consulta
            Dim ParametrosConsulta1 As String = ""

            ' Concatena la condicion de la consulta
            ParametrosConsulta1 += "Select "
            ParametrosConsulta1 += "HiliNufi, "
            ParametrosConsulta1 += "HiliEstr, "
            ParametrosConsulta1 += "HiliVige  "
            ParametrosConsulta1 += "From HistLiqu, SujeImpu where "
            ParametrosConsulta1 += "SuimNufi = HiliNufi and "
            ParametrosConsulta1 += "HiliVige = '" & CInt(inVigencia) & "' and "
            ParametrosConsulta1 += "HiliEstr = '" & CInt(inEstrato) & "' and "
            ParametrosConsulta1 += "SuimMuni like '" & Trim(Me.txtFIPRMUNI.Text) & "' and "
            ParametrosConsulta1 += "SuimCorr like '" & Trim(Me.txtFIPRCORR.Text) & "' and "
            ParametrosConsulta1 += "SuimBarr like '" & Trim(Me.txtFIPRBARR.Text) & "' and "
            ParametrosConsulta1 += "SuimManz like '" & Trim(Me.txtFIPRMANZ.Text) & "' and "
            ParametrosConsulta1 += "SuimPred like '" & Trim(Me.txtFIPRPRED.Text) & "' and "
            ParametrosConsulta1 += "SuimEdif like '" & Trim(Me.txtFIPREDIF.Text) & "' and "
            ParametrosConsulta1 += "SuimUnpr like '" & Trim(Me.txtFIPRUNPR.Text) & "' and "
            ParametrosConsulta1 += "SuimClse like '" & Trim(Me.txtFIPRCLSE.Text) & "' and "
            ParametrosConsulta1 += "SuimNufi between '" & Trim(Me.txtFIPRFIIN.Text) & "' and '" & Trim(Me.txtFIPRFIFI.Text) & "' and "
            ParametrosConsulta1 += "SuimEsta = 'ac' and "
            ParametrosConsulta1 += "HiliEsta = 'ac' "

            ' ejecuta la consulta
            oEjecutar = New SqlCommand(ParametrosConsulta1, oConexion)

            ' procesa la consulta 
            oEjecutar.CommandTimeout = 0
            oEjecutar.CommandType = CommandType.Text
            oAdapter.SelectCommand = oEjecutar

            ' llena el datatable 
            oAdapter.Fill(dtConsulta)

            ' cierra la conexion
            oConexion.Close()

            Return dtConsulta

        Catch ex As Exception
            MessageBox.Show(Err.Description)
            Return Nothing
        End Try

    End Function
    Private Function fun_ConsultarFichaPredialPorEstrato(ByVal inVigencia As Integer) As DataTable

        Try
            ' buscar cadena de conexion
            Dim oCadenaConexion1 As New REGLAS_DEL_NEGOCIO.cla_ConnectionString
            Dim stCadenaConexion1 As String = oCadenaConexion1.fun_ConnectionString

            ' crea el datatable
            Dim dtConsulta As New DataTable

            ' crear conexión
            oAdapter = New SqlDataAdapter
            oConexion = New SqlConnection(stCadenaConexion1)

            ' abre la conexion
            oConexion.Open()

            ' parametros de la consulta
            Dim ParametrosConsulta1 As String = ""

            ' Concatena la condicion de la consulta
            ParametrosConsulta1 += "Select "
            ParametrosConsulta1 += "HiliEstr, "
            ParametrosConsulta1 += "EstrDesc, "
            ParametrosConsulta1 += "count(HiliEstr) as HiliCant "
            ParametrosConsulta1 += "From HistLiqu, SujeImpu, Mant_Estrato where "
            ParametrosConsulta1 += "SuimNufi = HiliNufi and "
            ParametrosConsulta1 += "HiliEstr = EstrCodi and "
            ParametrosConsulta1 += "HiliVige = '" & CInt(inVigencia) & "' and "
            ParametrosConsulta1 += "SuimMuni like '" & Trim(Me.txtFIPRMUNI.Text) & "' and "
            ParametrosConsulta1 += "SuimCorr like '" & Trim(Me.txtFIPRCORR.Text) & "' and "
            ParametrosConsulta1 += "SuimBarr like '" & Trim(Me.txtFIPRBARR.Text) & "' and "
            ParametrosConsulta1 += "SuimManz like '" & Trim(Me.txtFIPRMANZ.Text) & "' and "
            ParametrosConsulta1 += "SuimPred like '" & Trim(Me.txtFIPRPRED.Text) & "' and "
            ParametrosConsulta1 += "SuimEdif like '" & Trim(Me.txtFIPREDIF.Text) & "' and "
            ParametrosConsulta1 += "SuimUnpr like '" & Trim(Me.txtFIPRUNPR.Text) & "' and "
            ParametrosConsulta1 += "SuimClse like '" & Trim(Me.txtFIPRCLSE.Text) & "' and "
            ParametrosConsulta1 += "SuimNufi between '" & Trim(Me.txtFIPRFIIN.Text) & "' and '" & Trim(Me.txtFIPRFIFI.Text) & "' and "
            ParametrosConsulta1 += "SuimEsta = 'ac' and "
            ParametrosConsulta1 += "HiliEsta = 'ac' "
            ParametrosConsulta1 += "group by HiliEstr,EstrDesc "
            ParametrosConsulta1 += "order by EstrDesc "

            ' ejecuta la consulta
            oEjecutar = New SqlCommand(ParametrosConsulta1, oConexion)

            ' procesa la consulta 
            oEjecutar.CommandTimeout = 0
            oEjecutar.CommandType = CommandType.Text
            oAdapter.SelectCommand = oEjecutar

            ' llena el datatable 
            oAdapter.Fill(dtConsulta)

            ' cierra la conexion
            oConexion.Close()

            Return dtConsulta

        Catch ex As Exception
            MessageBox.Show(Err.Description)
            Return Nothing
        End Try

    End Function

    Private Function fun_ConsultarFichaPredialPorTipoDeCalificacion(ByVal stTipoCalificacion As String, ByVal inVigencia As Integer) As DataTable

        Try

            ' buscar cadena de conexion
            Dim oCadenaConexion1 As New REGLAS_DEL_NEGOCIO.cla_ConnectionString
            Dim stCadenaConexion1 As String = oCadenaConexion1.fun_ConnectionString

            ' crea el datatable
            Dim dtConsulta As New DataTable

            ' crear conexión
            oAdapter = New SqlDataAdapter
            oConexion = New SqlConnection(stCadenaConexion1)

            ' abre la conexion
            oConexion.Open()

            ' parametros de la consulta
            Dim ParametrosConsulta1 As String = ""

            ' Concatena la condicion de la consulta
            ParametrosConsulta1 += "Select "
            ParametrosConsulta1 += "HiliNufi, "
            ParametrosConsulta1 += "HiliTipo, "
            ParametrosConsulta1 += "HiliVige  "
            ParametrosConsulta1 += "From HistLiqu, SujeImpu where "
            ParametrosConsulta1 += "SuimNufi = HiliNufi and "
            ParametrosConsulta1 += "HiliVige = '" & CInt(inVigencia) & "' and "
            ParametrosConsulta1 += "HiliTipo = '" & CStr(Trim(stTipoCalificacion)) & "' and "
            ParametrosConsulta1 += "SuimMuni like '" & Trim(Me.txtFIPRMUNI.Text) & "' and "
            ParametrosConsulta1 += "SuimCorr like '" & Trim(Me.txtFIPRCORR.Text) & "' and "
            ParametrosConsulta1 += "SuimBarr like '" & Trim(Me.txtFIPRBARR.Text) & "' and "
            ParametrosConsulta1 += "SuimManz like '" & Trim(Me.txtFIPRMANZ.Text) & "' and "
            ParametrosConsulta1 += "SuimPred like '" & Trim(Me.txtFIPRPRED.Text) & "' and "
            ParametrosConsulta1 += "SuimEdif like '" & Trim(Me.txtFIPREDIF.Text) & "' and "
            ParametrosConsulta1 += "SuimUnpr like '" & Trim(Me.txtFIPRUNPR.Text) & "' and "
            ParametrosConsulta1 += "SuimClse like '" & Trim(Me.txtFIPRCLSE.Text) & "' and "
            ParametrosConsulta1 += "SuimNufi between '" & Trim(Me.txtFIPRFIIN.Text) & "' and '" & Trim(Me.txtFIPRFIFI.Text) & "' and "
            ParametrosConsulta1 += "SuimEsta = 'ac' and "
            ParametrosConsulta1 += "HiliEsta = 'ac' "

            ' ejecuta la consulta
            oEjecutar = New SqlCommand(ParametrosConsulta1, oConexion)

            ' procesa la consulta 
            oEjecutar.CommandTimeout = 0
            oEjecutar.CommandType = CommandType.Text
            oAdapter.SelectCommand = oEjecutar

            ' llena el datatable 
            oAdapter.Fill(dtConsulta)

            ' cierra la conexion
            oConexion.Close()

            Return dtConsulta

        Catch ex As Exception
            MessageBox.Show(Err.Description)
            Return Nothing
        End Try

    End Function
    Private Function fun_ConsultarFichaPredialPorTipoDeCalificacion(ByVal inVigencia As Integer) As DataTable

        Try
            ' buscar cadena de conexion
            Dim oCadenaConexion1 As New REGLAS_DEL_NEGOCIO.cla_ConnectionString
            Dim stCadenaConexion1 As String = oCadenaConexion1.fun_ConnectionString

            ' crea el datatable
            Dim dtConsulta As New DataTable

            ' crear conexión
            oAdapter = New SqlDataAdapter
            oConexion = New SqlConnection(stCadenaConexion1)

            ' abre la conexion
            oConexion.Open()

            ' parametros de la consulta
            Dim ParametrosConsulta1 As String = ""

            ' Concatena la condicion de la consulta
            ParametrosConsulta1 += "Select "
            ParametrosConsulta1 += "HiliTipo, "
            ParametrosConsulta1 += "TicaDesc, "
            ParametrosConsulta1 += "count(HiliTipo) as HiliCant "
            ParametrosConsulta1 += "From HistLiqu, SujeImpu, Mant_TipoCali where "
            ParametrosConsulta1 += "SuimNufi = HiliNufi and "
            ParametrosConsulta1 += "HiliTipo = TicaCodi and "
            ParametrosConsulta1 += "HiliVige = '" & CInt(inVigencia) & "' and "
            ParametrosConsulta1 += "SuimMuni like '" & Trim(Me.txtFIPRMUNI.Text) & "' and "
            ParametrosConsulta1 += "SuimCorr like '" & Trim(Me.txtFIPRCORR.Text) & "' and "
            ParametrosConsulta1 += "SuimBarr like '" & Trim(Me.txtFIPRBARR.Text) & "' and "
            ParametrosConsulta1 += "SuimManz like '" & Trim(Me.txtFIPRMANZ.Text) & "' and "
            ParametrosConsulta1 += "SuimPred like '" & Trim(Me.txtFIPRPRED.Text) & "' and "
            ParametrosConsulta1 += "SuimEdif like '" & Trim(Me.txtFIPREDIF.Text) & "' and "
            ParametrosConsulta1 += "SuimUnpr like '" & Trim(Me.txtFIPRUNPR.Text) & "' and "
            ParametrosConsulta1 += "SuimClse like '" & Trim(Me.txtFIPRCLSE.Text) & "' and "
            ParametrosConsulta1 += "SuimNufi between '" & Trim(Me.txtFIPRFIIN.Text) & "' and '" & Trim(Me.txtFIPRFIFI.Text) & "' and "
            ParametrosConsulta1 += "SuimEsta = 'ac' and "
            ParametrosConsulta1 += "HiliEsta = 'ac' "
            ParametrosConsulta1 += "group by HiliTipo,TicaDesc "
            ParametrosConsulta1 += "order by TicaDesc "

            ' ejecuta la consulta
            oEjecutar = New SqlCommand(ParametrosConsulta1, oConexion)

            ' procesa la consulta 
            oEjecutar.CommandTimeout = 0
            oEjecutar.CommandType = CommandType.Text
            oAdapter.SelectCommand = oEjecutar

            ' llena el datatable 
            oAdapter.Fill(dtConsulta)

            ' cierra la conexion
            oConexion.Close()

            Return dtConsulta

        Catch ex As Exception
            MessageBox.Show(Err.Description)
            Return Nothing
        End Try

    End Function

    Private Function fun_ConsultarFichaPredialPorDestinoEconomico(ByVal inDestino As Integer, ByVal inVigencia As Integer) As DataTable

        Try

            ' buscar cadena de conexion
            Dim oCadenaConexion1 As New REGLAS_DEL_NEGOCIO.cla_ConnectionString
            Dim stCadenaConexion1 As String = oCadenaConexion1.fun_ConnectionString

            ' crea el datatable
            Dim dtConsulta As New DataTable

            ' crear conexión
            oAdapter = New SqlDataAdapter
            oConexion = New SqlConnection(stCadenaConexion1)

            ' abre la conexion
            oConexion.Open()

            ' parametros de la consulta
            Dim ParametrosConsulta1 As String = ""

            ' Concatena la condicion de la consulta
            ParametrosConsulta1 += "Select "
            ParametrosConsulta1 += "HiliNufi, "
            ParametrosConsulta1 += "HiliDeec, "
            ParametrosConsulta1 += "HiliVige  "
            ParametrosConsulta1 += "From HistLiqu, SujeImpu where "
            ParametrosConsulta1 += "SuimNufi = HiliNufi and "
            ParametrosConsulta1 += "HiliVige = '" & CInt(inVigencia) & "' and "
            ParametrosConsulta1 += "HiliDeec = '" & CInt(inDestino) & "' and "
            ParametrosConsulta1 += "SuimMuni like '" & Trim(Me.txtFIPRMUNI.Text) & "' and "
            ParametrosConsulta1 += "SuimCorr like '" & Trim(Me.txtFIPRCORR.Text) & "' and "
            ParametrosConsulta1 += "SuimBarr like '" & Trim(Me.txtFIPRBARR.Text) & "' and "
            ParametrosConsulta1 += "SuimManz like '" & Trim(Me.txtFIPRMANZ.Text) & "' and "
            ParametrosConsulta1 += "SuimPred like '" & Trim(Me.txtFIPRPRED.Text) & "' and "
            ParametrosConsulta1 += "SuimEdif like '" & Trim(Me.txtFIPREDIF.Text) & "' and "
            ParametrosConsulta1 += "SuimUnpr like '" & Trim(Me.txtFIPRUNPR.Text) & "' and "
            ParametrosConsulta1 += "SuimClse like '" & Trim(Me.txtFIPRCLSE.Text) & "' and "
            ParametrosConsulta1 += "SuimNufi between '" & Trim(Me.txtFIPRFIIN.Text) & "' and '" & Trim(Me.txtFIPRFIFI.Text) & "' and "
            ParametrosConsulta1 += "SuimEsta = 'ac' and "
            ParametrosConsulta1 += "HiliEsta = 'ac' "

            ' ejecuta la consulta
            oEjecutar = New SqlCommand(ParametrosConsulta1, oConexion)

            ' procesa la consulta 
            oEjecutar.CommandTimeout = 0
            oEjecutar.CommandType = CommandType.Text
            oAdapter.SelectCommand = oEjecutar

            ' llena el datatable 
            oAdapter.Fill(dtConsulta)

            ' cierra la conexion
            oConexion.Close()

            Return dtConsulta

        Catch ex As Exception
            MessageBox.Show(Err.Description)
            Return Nothing
        End Try

    End Function
    Private Function fun_ConsultarFichaPredialPorDestinoEconomico(ByVal inVigencia As Integer) As DataTable

        Try
            ' buscar cadena de conexion
            Dim oCadenaConexion1 As New REGLAS_DEL_NEGOCIO.cla_ConnectionString
            Dim stCadenaConexion1 As String = oCadenaConexion1.fun_ConnectionString

            ' crea el datatable
            Dim dtConsulta As New DataTable

            ' crear conexión
            oAdapter = New SqlDataAdapter
            oConexion = New SqlConnection(stCadenaConexion1)

            ' abre la conexion
            oConexion.Open()

            ' parametros de la consulta
            Dim ParametrosConsulta1 As String = ""

            ' Concatena la condicion de la consulta
            ParametrosConsulta1 += "Select "
            ParametrosConsulta1 += "HiliDeec, "
            ParametrosConsulta1 += "DeecDesc, "
            ParametrosConsulta1 += "count(HiliDeec) as HiliCant "
            ParametrosConsulta1 += "From HistLiqu, SujeImpu, Mant_Destecon where "
            ParametrosConsulta1 += "SuimNufi = HiliNufi and "
            ParametrosConsulta1 += "HiliDeec = DeecCodi and "
            ParametrosConsulta1 += "HiliVige = '" & CInt(inVigencia) & "' and "
            ParametrosConsulta1 += "SuimMuni like '" & Trim(Me.txtFIPRMUNI.Text) & "' and "
            ParametrosConsulta1 += "SuimCorr like '" & Trim(Me.txtFIPRCORR.Text) & "' and "
            ParametrosConsulta1 += "SuimBarr like '" & Trim(Me.txtFIPRBARR.Text) & "' and "
            ParametrosConsulta1 += "SuimManz like '" & Trim(Me.txtFIPRMANZ.Text) & "' and "
            ParametrosConsulta1 += "SuimPred like '" & Trim(Me.txtFIPRPRED.Text) & "' and "
            ParametrosConsulta1 += "SuimEdif like '" & Trim(Me.txtFIPREDIF.Text) & "' and "
            ParametrosConsulta1 += "SuimUnpr like '" & Trim(Me.txtFIPRUNPR.Text) & "' and "
            ParametrosConsulta1 += "SuimClse like '" & Trim(Me.txtFIPRCLSE.Text) & "' and "
            ParametrosConsulta1 += "SuimNufi between '" & Trim(Me.txtFIPRFIIN.Text) & "' and '" & Trim(Me.txtFIPRFIFI.Text) & "' and "
            ParametrosConsulta1 += "SuimEsta = 'ac' and "
            ParametrosConsulta1 += "HiliEsta = 'ac' "
            ParametrosConsulta1 += "group by HiliDeec,DeecDesc "
            ParametrosConsulta1 += "order by DeecDesc "

            ' ejecuta la consulta
            oEjecutar = New SqlCommand(ParametrosConsulta1, oConexion)

            ' procesa la consulta 
            oEjecutar.CommandTimeout = 0
            oEjecutar.CommandType = CommandType.Text
            oAdapter.SelectCommand = oEjecutar

            ' llena el datatable 
            oAdapter.Fill(dtConsulta)

            ' cierra la conexion
            oConexion.Close()

            Return dtConsulta

        Catch ex As Exception
            MessageBox.Show(Err.Description)
            Return Nothing
        End Try

    End Function

#End Region

#Region "PROCEDIMIENTOS"

    Private Sub pro_LimpiarCampos()

        Me.txtFIPRFIIN.Text = "0"
        Me.txtFIPRFIFI.Text = "999999999"
        Me.txtFIPRTIFI.Text = "0"
        Me.txtFIPRMUNI.Text = "%"
        Me.txtFIPRCORR.Text = "%"
        Me.txtFIPRBARR.Text = "%"
        Me.txtFIPRMANZ.Text = "%"
        Me.txtFIPRPRED.Text = "%"
        Me.txtFIPREDIF.Text = "%"
        Me.txtFIPRUNPR.Text = "%"
        Me.txtFIPRCLSE.Text = "%"
        Me.cboTIPOREPO.SelectedIndex = 0
        Me.strBARRESTA.Items(2).Text = "Registros : 0"
        Me.lblTotalPorcentaje1.Text = ""
        Me.lblTotalRegistros1.Text = ""
        Me.lblTotalCantidad1.Text = ""
        Me.lblTotalPorcentaje2.Text = ""
        Me.lblTotalRegistros2.Text = ""
        Me.lblTotalCantidad2.Text = ""
        Me.lblTIPOIMPU.Text = ""
        Me.lblCONCEPTO.Text = ""
        Me.lblVIGENCIA1.Text = ""
        Me.lblVIGENCIA2.Text = ""
        Me.cmdGRAFICO.Enabled = False
        Me.cmdGENERAR.Enabled = True

        Me.dgvESTADISTICO1.DataSource = New DataTable
        Me.dgvESTADISTICO2.DataSource = New DataTable
        Me.cboTIPOIMPU.DataSource = New DataTable
        Me.cboCONCEPTO.DataSource = New DataTable
        Me.cboVIGENCIA1.DataSource = New DataTable
        Me.cboVIGENCIA2.DataSource = New DataTable

    End Sub

    Private Sub pro_Reporte_de_total_de_avaluos_por_vigencias()

        Try
            Dim objVerifica As New cla_Verificar_Dato

            ' validad delo datos
            Dim boVIGENCIA1 As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboVIGENCIA1)
            Dim boVIGENCIA2 As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboVIGENCIA2)

            ' verifica los datos
            If boVIGENCIA1 = True And boVIGENCIA2 = True Then

                Me.cmdGENERAR.Enabled = False

                If Me.chkLiquidarUnaVigencia.Checked = True And Me.rbdVigencia1.Checked = True Then

                    ' buscar cadena de conexion
                    Dim oCadenaConexion1 As New REGLAS_DEL_NEGOCIO.cla_ConnectionString
                    Dim stCadenaConexion1 As String = oCadenaConexion1.fun_ConnectionString

                    ' crea el datatable
                    dtConsulta1 = New DataTable

                    ' crear conexión
                    oAdapter = New SqlDataAdapter
                    oConexion = New SqlConnection(stCadenaConexion1)

                    ' abre la conexion
                    oConexion.Open()

                    ' parametros de la consulta
                    Dim ParametrosConsulta1 As String = ""

                    ' Concatena la condicion de la consulta
                    ParametrosConsulta1 += "Select "
                    ParametrosConsulta1 += "sum(HiavAval) as Cantidad "
                    ParametrosConsulta1 += "From HistAval, SujeImpu where "
                    ParametrosConsulta1 += "SuimNufi = HiavNufi and "
                    ParametrosConsulta1 += "HiavVige = '" & Me.cboVIGENCIA1.SelectedValue & "' and "
                    ParametrosConsulta1 += "SuimMuni like '" & Trim(Me.txtFIPRMUNI.Text) & "' and "
                    ParametrosConsulta1 += "SuimCorr like '" & Trim(Me.txtFIPRCORR.Text) & "' and "
                    ParametrosConsulta1 += "SuimBarr like '" & Trim(Me.txtFIPRBARR.Text) & "' and "
                    ParametrosConsulta1 += "SuimManz like '" & Trim(Me.txtFIPRMANZ.Text) & "' and "
                    ParametrosConsulta1 += "SuimPred like '" & Trim(Me.txtFIPRPRED.Text) & "' and "
                    ParametrosConsulta1 += "SuimEdif like '" & Trim(Me.txtFIPREDIF.Text) & "' and "
                    ParametrosConsulta1 += "SuimUnpr like '" & Trim(Me.txtFIPRUNPR.Text) & "' and "
                    ParametrosConsulta1 += "SuimClse like '" & Trim(Me.txtFIPRCLSE.Text) & "' and "
                    ParametrosConsulta1 += "SuimNufi between '" & Trim(Me.txtFIPRFIIN.Text) & "' and '" & Trim(Me.txtFIPRFIFI.Text) & "' and "
                    ParametrosConsulta1 += "SuimEsta = 'ac' and "
                    ParametrosConsulta1 += "HiavEsta = 'ac' "

                    ' ejecuta la consulta
                    oEjecutar = New SqlCommand(ParametrosConsulta1, oConexion)

                    ' procesa la consulta 
                    oEjecutar.CommandTimeout = 0
                    oEjecutar.CommandType = CommandType.Text
                    oAdapter.SelectCommand = oEjecutar

                    ' llena el datatable 
                    oAdapter.Fill(dtConsulta1)

                    ' cierra la conexion
                    oConexion.Close()

                    ' realiza la insercion mediante la consulta
                    If dtConsulta1.Rows.Count > 0 Then

                        ' llena el el datagridview
                        Me.dgvESTADISTICO1.DataSource = dtConsulta1

                        ' formato de moneda
                        Me.dgvESTADISTICO1.Columns("Cantidad").DefaultCellStyle.Format = "c"

                        ' llena los totales
                        Me.lblTotalRegistros1.Text = CType(Me.dgvESTADISTICO1.RowCount, String)

                        ' inserta la totalidad de registros
                        strBARRESTA.Items(2).Text = "Registros : " & Me.dgvESTADISTICO1.RowCount + Me.dgvESTADISTICO2.RowCount

                    Else
                        mod_MENSAJE.Consulta_No_Encontro_Registros()
                        strBARRESTA.Items(2).Text = "Registros : 0"

                        ' limpia el reporte
                        Me.dgvESTADISTICO1.DataSource = New DataTable
                        Me.lblTotalRegistros1.Text = ""

                    End If

                End If

                If Me.chkLiquidarUnaVigencia.Checked = True And Me.rbdVigencia2.Checked = True Then

                    ' buscar cadena de conexion
                    Dim oCadenaConexion2 As New REGLAS_DEL_NEGOCIO.cla_ConnectionString
                    Dim stCadenaConexion2 As String = oCadenaConexion2.fun_ConnectionString

                    ' crea el datatable
                    dtConsulta2 = New DataTable

                    ' crear conexión
                    oAdapter = New SqlDataAdapter
                    oConexion = New SqlConnection(stCadenaConexion2)

                    ' abre la conexion
                    oConexion.Open()

                    ' parametros de la consulta
                    Dim ParametrosConsulta2 As String = ""

                    ' Concatena la condicion de la consulta
                    ParametrosConsulta2 += "Select "
                    ParametrosConsulta2 += "sum(HiavAval) as Cantidad "
                    ParametrosConsulta2 += "From HistAval, SujeImpu where "
                    ParametrosConsulta2 += "SuimNufi = HiavNufi and "
                    ParametrosConsulta2 += "HiavVige = '" & Me.cboVIGENCIA2.SelectedValue & "' and "
                    ParametrosConsulta2 += "SuimMuni like '" & Trim(Me.txtFIPRMUNI.Text) & "' and "
                    ParametrosConsulta2 += "SuimCorr like '" & Trim(Me.txtFIPRCORR.Text) & "' and "
                    ParametrosConsulta2 += "SuimBarr like '" & Trim(Me.txtFIPRBARR.Text) & "' and "
                    ParametrosConsulta2 += "SuimManz like '" & Trim(Me.txtFIPRMANZ.Text) & "' and "
                    ParametrosConsulta2 += "SuimPred like '" & Trim(Me.txtFIPRPRED.Text) & "' and "
                    ParametrosConsulta2 += "SuimEdif like '" & Trim(Me.txtFIPREDIF.Text) & "' and "
                    ParametrosConsulta2 += "SuimUnpr like '" & Trim(Me.txtFIPRUNPR.Text) & "' and "
                    ParametrosConsulta2 += "SuimClse like '" & Trim(Me.txtFIPRCLSE.Text) & "' and "
                    ParametrosConsulta2 += "SuimNufi between '" & Trim(Me.txtFIPRFIIN.Text) & "' and '" & Trim(Me.txtFIPRFIFI.Text) & "' and "
                    ParametrosConsulta2 += "SuimEsta = 'ac' and "
                    ParametrosConsulta2 += "HiavEsta = 'ac' "

                    ' ejecuta la consulta
                    oEjecutar = New SqlCommand(ParametrosConsulta2, oConexion)

                    ' procesa la consulta 
                    oEjecutar.CommandTimeout = 0
                    oEjecutar.CommandType = CommandType.Text
                    oAdapter.SelectCommand = oEjecutar

                    ' llena el datatable 
                    oAdapter.Fill(dtConsulta2)

                    ' cierra la conexion
                    oConexion.Close()

                    ' realiza la insercion mediante la consulta
                    If dtConsulta2.Rows.Count > 0 Then

                        ' llena el el datagridview
                        Me.dgvESTADISTICO2.DataSource = dtConsulta2

                        ' formato de moneda
                        Me.dgvESTADISTICO2.Columns("Cantidad").DefaultCellStyle.Format = "c"

                        ' llena los totales
                        Me.lblTotalRegistros2.Text = CType(Me.dgvESTADISTICO2.RowCount, String)

                        ' inserta la totalidad de registros
                        strBARRESTA.Items(2).Text = "Registros : " & Me.dgvESTADISTICO1.RowCount + Me.dgvESTADISTICO2.RowCount

                    Else
                        mod_MENSAJE.Consulta_No_Encontro_Registros()
                        strBARRESTA.Items(2).Text = "Registros : 0"

                        ' limpia el reporte
                        Me.dgvESTADISTICO2.DataSource = New DataTable
                        Me.lblTotalRegistros2.Text = ""

                    End If

                End If

            End If

            Me.cmdGENERAR.Enabled = True
            Me.cmdGENERAR.Focus()

            mod_MENSAJE.Proceso_Termino_Correctamente()

        Catch ex As Exception
            MessageBox.Show(Err.Description)
            Me.cmdGENERAR.Enabled = True
        End Try

    End Sub
    Private Sub pro_Reporte_de_total_de_impuestos_por_vigencias()
        Try
            Dim objVerifica As New cla_Verificar_Dato

            ' validad delo datos
            Dim boVIGENCIA1 As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboVIGENCIA1)
            Dim boVIGENCIA2 As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboVIGENCIA2)
            Dim boTIPOIMPU As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboTIPOIMPU)
            Dim boCONCEPTO As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboCONCEPTO)

            ' verifica los datos
            If boVIGENCIA1 = True And _
               boVIGENCIA2 = True And _
               boTIPOIMPU = True And _
               boCONCEPTO = True Then

                Me.cmdGENERAR.Enabled = False

                If Me.chkLiquidarUnaVigencia.Checked = True And Me.rbdVigencia1.Checked = True Then

                    ' buscar cadena de conexion
                    Dim oCadenaConexion1 As New REGLAS_DEL_NEGOCIO.cla_ConnectionString
                    Dim stCadenaConexion1 As String = oCadenaConexion1.fun_ConnectionString

                    ' crea el datatable
                    dtConsulta1 = New DataTable

                    ' crear conexión
                    oAdapter = New SqlDataAdapter
                    oConexion = New SqlConnection(stCadenaConexion1)

                    ' abre la conexion
                    oConexion.Open()

                    ' parametros de la consulta
                    Dim ParametrosConsulta1 As String = ""

                    ' Concatena la condicion de la consulta
                    ParametrosConsulta1 += "Select "
                    ParametrosConsulta1 += "sum(AfsiVali) as Cantidad "
                    ParametrosConsulta1 += "From AforSuim, SujeImpu where "
                    ParametrosConsulta1 += "AfsiNufi = SuimNufi and "
                    ParametrosConsulta1 += "AfsiClse = SuimClse and "
                    ParametrosConsulta1 += "AfsiVige = '" & Me.cboVIGENCIA1.SelectedValue & "' and "
                    ParametrosConsulta1 += "AfsiTiim = '" & Me.cboTIPOIMPU.SelectedValue & "' and "
                    ParametrosConsulta1 += "AfsiConc = '" & Me.cboCONCEPTO.SelectedValue & "' and "
                    ParametrosConsulta1 += "SuimMuni like '" & Trim(Me.txtFIPRMUNI.Text) & "' and "
                    ParametrosConsulta1 += "SuimCorr like '" & Trim(Me.txtFIPRCORR.Text) & "' and "
                    ParametrosConsulta1 += "SuimBarr like '" & Trim(Me.txtFIPRBARR.Text) & "' and "
                    ParametrosConsulta1 += "SuimManz like '" & Trim(Me.txtFIPRMANZ.Text) & "' and "
                    ParametrosConsulta1 += "SuimPred like '" & Trim(Me.txtFIPRPRED.Text) & "' and "
                    ParametrosConsulta1 += "SuimEdif like '" & Trim(Me.txtFIPREDIF.Text) & "' and "
                    ParametrosConsulta1 += "SuimUnpr like '" & Trim(Me.txtFIPRUNPR.Text) & "' and "
                    ParametrosConsulta1 += "SuimClse like '" & Trim(Me.txtFIPRCLSE.Text) & "' and "
                    ParametrosConsulta1 += "SuimNufi between '" & Trim(Me.txtFIPRFIIN.Text) & "' and '" & Trim(Me.txtFIPRFIFI.Text) & "' and "
                    ParametrosConsulta1 += "SuimEsta = 'ac' and "
                    ParametrosConsulta1 += "AfsiEsta = 'ac' "

                    ' ejecuta la consulta
                    oEjecutar = New SqlCommand(ParametrosConsulta1, oConexion)

                    ' procesa la consulta 
                    oEjecutar.CommandTimeout = 0
                    oEjecutar.CommandType = CommandType.Text
                    oAdapter.SelectCommand = oEjecutar

                    ' llena el datatable 
                    oAdapter.Fill(dtConsulta1)

                    ' cierra la conexion
                    oConexion.Close()

                    ' realiza la insercion mediante la consulta
                    If dtConsulta1.Rows.Count > 0 Then

                        ' llena el el datagridview
                        Me.dgvESTADISTICO1.DataSource = dtConsulta1

                        ' formato de moneda
                        Me.dgvESTADISTICO1.Columns("Cantidad").DefaultCellStyle.Format = "c"

                        ' llena los totales
                        Me.lblTotalRegistros1.Text = CType(Me.dgvESTADISTICO1.RowCount, String)

                        ' inserta la totalidad de registros
                        strBARRESTA.Items(2).Text = "Registros : " & Me.dgvESTADISTICO1.RowCount + Me.dgvESTADISTICO2.RowCount

                    Else
                        mod_MENSAJE.Consulta_No_Encontro_Registros()
                        strBARRESTA.Items(2).Text = "Registros : 0"

                        ' limpia el reporte
                        Me.dgvESTADISTICO1.DataSource = New DataTable
                        Me.lblTotalRegistros1.Text = ""

                    End If

                End If

                If Me.chkLiquidarUnaVigencia.Checked = True And Me.rbdVigencia2.Checked = True Then

                    ' buscar cadena de conexion
                    Dim oCadenaConexion2 As New REGLAS_DEL_NEGOCIO.cla_ConnectionString
                    Dim stCadenaConexion2 As String = oCadenaConexion2.fun_ConnectionString

                    ' crea el datatable
                    dtConsulta2 = New DataTable

                    ' crear conexión
                    oAdapter = New SqlDataAdapter
                    oConexion = New SqlConnection(stCadenaConexion2)

                    ' abre la conexion
                    oConexion.Open()

                    ' parametros de la consulta
                    Dim ParametrosConsulta2 As String = ""

                    ' Concatena la condicion de la consulta
                    ParametrosConsulta2 += "Select "
                    ParametrosConsulta2 += "sum(AfsiVali) as Cantidad "
                    ParametrosConsulta2 += "From AforSuim, SujeImpu where "
                    ParametrosConsulta2 += "AfsiNufi = SuimNufi and "
                    ParametrosConsulta2 += "AfsiClse = SuimClse and "
                    ParametrosConsulta2 += "AfsiVige = '" & Me.cboVIGENCIA2.SelectedValue & "' and "
                    ParametrosConsulta2 += "AfsiTiim = '" & Me.cboTIPOIMPU.SelectedValue & "' and "
                    ParametrosConsulta2 += "AfsiConc = '" & Me.cboCONCEPTO.SelectedValue & "' and "
                    ParametrosConsulta2 += "SuimMuni like '" & Trim(Me.txtFIPRMUNI.Text) & "' and "
                    ParametrosConsulta2 += "SuimCorr like '" & Trim(Me.txtFIPRCORR.Text) & "' and "
                    ParametrosConsulta2 += "SuimBarr like '" & Trim(Me.txtFIPRBARR.Text) & "' and "
                    ParametrosConsulta2 += "SuimManz like '" & Trim(Me.txtFIPRMANZ.Text) & "' and "
                    ParametrosConsulta2 += "SuimPred like '" & Trim(Me.txtFIPRPRED.Text) & "' and "
                    ParametrosConsulta2 += "SuimEdif like '" & Trim(Me.txtFIPREDIF.Text) & "' and "
                    ParametrosConsulta2 += "SuimUnpr like '" & Trim(Me.txtFIPRUNPR.Text) & "' and "
                    ParametrosConsulta2 += "SuimClse like '" & Trim(Me.txtFIPRCLSE.Text) & "' and "
                    ParametrosConsulta2 += "SuimNufi between '" & Trim(Me.txtFIPRFIIN.Text) & "' and '" & Trim(Me.txtFIPRFIFI.Text) & "' and "
                    ParametrosConsulta2 += "SuimEsta = 'ac' and "
                    ParametrosConsulta2 += "AfsiEsta = 'ac' "

                    ' ejecuta la consulta
                    oEjecutar = New SqlCommand(ParametrosConsulta2, oConexion)

                    ' procesa la consulta 
                    oEjecutar.CommandTimeout = 0
                    oEjecutar.CommandType = CommandType.Text
                    oAdapter.SelectCommand = oEjecutar

                    ' llena el datatable 
                    oAdapter.Fill(dtConsulta2)

                    ' cierra la conexion
                    oConexion.Close()

                    ' realiza la insercion mediante la consulta
                    If dtConsulta2.Rows.Count > 0 Then

                        ' llena el el datagridview
                        Me.dgvESTADISTICO2.DataSource = dtConsulta2

                        ' formato de moneda
                        Me.dgvESTADISTICO2.Columns("Cantidad").DefaultCellStyle.Format = "c"

                        ' llena los totales
                        Me.lblTotalRegistros2.Text = CType(Me.dgvESTADISTICO2.RowCount, String)

                        ' inserta la totalidad de registros
                        strBARRESTA.Items(2).Text = "Registros : " & Me.dgvESTADISTICO1.RowCount + Me.dgvESTADISTICO2.RowCount

                    Else
                        mod_MENSAJE.Consulta_No_Encontro_Registros()
                        strBARRESTA.Items(2).Text = "Registros : 0"

                        ' limpia el reporte
                        Me.dgvESTADISTICO2.DataSource = New DataTable
                        Me.lblTotalRegistros2.Text = ""

                    End If

                End If

            End If

            Me.cmdGENERAR.Enabled = True
            Me.cmdGENERAR.Focus()

            mod_MENSAJE.Proceso_Termino_Correctamente()

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try
    End Sub
    Private Sub pro_Reporte_de_avaluo_por_zonas()

        Try

            Dim objVerifica As New cla_Verificar_Dato

            ' validad delo datos
            Dim boVIGENCIA1 As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboVIGENCIA1)
            Dim boVIGENCIA2 As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboVIGENCIA2)

            ' verifica los datos
            If boVIGENCIA1 = True And boVIGENCIA2 = True Then

                Me.cmdGENERAR.Enabled = False

                ' declara la tabla
                dtConsulta1 = New DataTable
                dtConsulta2 = New DataTable

                ' llena la tabla
                dtConsulta1 = fun_ConsultarFichaPredialPorZonaEconomica(Me.cboVIGENCIA1.SelectedValue)
                dtConsulta2 = fun_ConsultarFichaPredialPorZonaEconomica(Me.cboVIGENCIA2.SelectedValue)

                ' realiza la insercion mediante la consulta
                If dtConsulta1.Rows.Count > 0 And dtConsulta2.Rows.Count > 0 Then

                    ' Crea objeto de columnas y registros
                    Dim dt1 As New DataTable
                    Dim dr1 As DataRow

                    Dim dt2 As New DataTable
                    Dim dr2 As DataRow

                    ' Crea las columnas
                    dt1.Columns.Add(New DataColumn("Zona", GetType(Integer)))
                    dt1.Columns.Add(New DataColumn("Descripcion", GetType(String)))
                    dt1.Columns.Add(New DataColumn("Cantidad", GetType(Integer)))
                    dt1.Columns.Add(New DataColumn("Avaluo", GetType(Long)))
                    dt1.Columns.Add(New DataColumn("Porcentaje(%)", GetType(Double)))

                    dt2.Columns.Add(New DataColumn("Zona", GetType(Integer)))
                    dt2.Columns.Add(New DataColumn("Descripcion", GetType(String)))
                    dt2.Columns.Add(New DataColumn("Cantidad", GetType(Integer)))
                    dt2.Columns.Add(New DataColumn("Avaluo", GetType(Long)))
                    dt2.Columns.Add(New DataColumn("Porcentaje(%)", GetType(Double)))

                    ' suma la totalidad de los registros encontrados
                    Dim inTotalRegistros1 As Integer = 0
                    Dim doTotalPorcentaje1 As Double = 0

                    Dim inTotalRegistros2 As Integer = 0
                    Dim doTotalPorcentaje2 As Double = 0

                    Dim i1 As Integer = 0
                    Dim i2 As Integer = 0

                    For i1 = 0 To dtConsulta1.Rows.Count - 1
                        inTotalRegistros1 += CType(dtConsulta1.Rows(i1).Item("HizoCant"), Integer)
                    Next

                    For i2 = 0 To dtConsulta2.Rows.Count - 1
                        inTotalRegistros2 += CType(dtConsulta1.Rows(i2).Item("HizoCant"), Integer)
                    Next

                    ' declara la variable
                    Dim dtFichaPredialxZonaEconomica As New DataTable

                    '*** RECORRE LA CONSULTA 1 ***

                    ' declara la variable y la recorre
                    Dim j1 As Integer = 0

                    For j1 = 0 To dtConsulta1.Rows.Count - 1

                        ' declara las variables
                        Dim inZONA As Integer = CInt(dtConsulta1.Rows(j1).Item("HizoZoec"))
                        Dim stDESCRIPCION As String = CStr(dtConsulta1.Rows(j1).Item("ZoecDesc"))
                        Dim inCANTIDAD As Integer = CInt(dtConsulta1.Rows(j1).Item("HizoCant"))

                        ' declara la variable
                        Dim loAvaluoCatastral As Long = 0

                        ' limpia la variable
                        dtFichaPredialxZonaEconomica = New DataTable

                        ' llena la variable
                        dtFichaPredialxZonaEconomica = fun_ConsultarFichaPredialPorZonaEconomica(inZONA, Me.cboVIGENCIA1.SelectedValue)

                        ' verica que la tabla esta llena
                        If dtFichaPredialxZonaEconomica.Rows.Count > 0 Then

                            ' declara la variable
                            Dim h As Integer = 0

                            For h = 0 To dtFichaPredialxZonaEconomica.Rows.Count - 1

                                If fun_Verificar_Dato_Numerico_Evento_Validated(dtFichaPredialxZonaEconomica.Rows(h).Item("HizoPorc")) = True AndAlso _
                                   CInt(dtFichaPredialxZonaEconomica.Rows(h).Item("HizoPorc")) > 0 Then

                                    ' declara la variable
                                    Dim inNroFicha As Integer = CInt(dtFichaPredialxZonaEconomica.Rows(h).Item("HizoNufi"))
                                    Dim inVigencia As Integer = CInt(dtFichaPredialxZonaEconomica.Rows(h).Item("HizoVige"))
                                    Dim inPorcentaje As Integer = CInt(dtFichaPredialxZonaEconomica.Rows(h).Item("HizoPorc"))

                                    ' almacena la ficha
                                    inFICHAPREDIAL = inNroFicha

                                    ' inicializa la instancia
                                    Dim obHISTAVAL As New cla_HISTAVAL
                                    Dim tbHISTAVAl As New DataTable

                                    tbHISTAVAl = obHISTAVAL.fun_Buscar_CODIGO_NUFI_VIGE_X_HISTAVAL(inNroFicha, inVigencia)

                                    If tbHISTAVAl.Rows.Count > 0 Then
                                        loAvaluoCatastral += ((CLng(tbHISTAVAl.Rows(0).Item("HIAVAVAL")) * inPorcentaje) / 100)
                                    End If

                                End If

                            Next

                        End If

                        doTotalPorcentaje1 += fun_Formato_Decimal_2_Decimales(((inCANTIDAD * 100) / inTotalRegistros1))

                        ' Inserta el registro en el DataTable
                        dr1 = dt1.NewRow()

                        dr1("Zona") = inZONA
                        dr1("Descripcion") = stDESCRIPCION
                        dr1("Cantidad") = inCANTIDAD
                        dr1("Avaluo") = loAvaluoCatastral
                        dr1("Porcentaje(%)") = fun_Formato_Decimal_2_Decimales(((inCANTIDAD * 100) / inTotalRegistros1))

                        dt1.Rows.Add(dr1)

                    Next

                    '*** RECORRE LA CONSULTA 2 ***

                    ' declara la variable y la recorre
                    Dim j2 As Integer = 0

                    For j2 = 0 To dtConsulta2.Rows.Count - 1

                        ' declara las variables
                        Dim inZONA As Integer = CInt(dtConsulta2.Rows(j2).Item("HizoZoec"))
                        Dim stDESCRIPCION As String = CStr(dtConsulta2.Rows(j2).Item("ZoecDesc"))
                        Dim inCANTIDAD As Integer = CInt(dtConsulta2.Rows(j2).Item("HizoCant"))

                        ' declara la variable
                        Dim loAvaluoCatastral As Long = 0

                        ' limpia la variable
                        dtFichaPredialxZonaEconomica = New DataTable

                        ' llena la variable
                        dtFichaPredialxZonaEconomica = fun_ConsultarFichaPredialPorZonaEconomica(inZONA, Me.cboVIGENCIA2.SelectedValue)

                        ' verica que la tabla esta llena
                        If dtFichaPredialxZonaEconomica.Rows.Count > 0 Then

                            ' declara la variable
                            Dim h As Integer = 0

                            For h = 0 To dtFichaPredialxZonaEconomica.Rows.Count - 1

                                If fun_Verificar_Dato_Numerico_Evento_Validated(dtFichaPredialxZonaEconomica.Rows(h).Item("HizoPorc")) = True AndAlso _
                                   CInt(dtFichaPredialxZonaEconomica.Rows(h).Item("HizoPorc")) > 0 Then

                                    ' declara la variable
                                    Dim inNroFicha As Integer = CInt(dtFichaPredialxZonaEconomica.Rows(h).Item("HizoNufi"))
                                    Dim inVigencia As Integer = CInt(dtFichaPredialxZonaEconomica.Rows(h).Item("HizoVige"))
                                    Dim inPorcentaje As Integer = CInt(dtFichaPredialxZonaEconomica.Rows(h).Item("HizoPorc"))

                                    ' almacena la ficha
                                    inFICHAPREDIAL = inNroFicha

                                    ' inicializa la instancia
                                    Dim obHISTAVAL As New cla_HISTAVAL
                                    Dim tbHISTAVAl As New DataTable

                                    tbHISTAVAl = obHISTAVAL.fun_Buscar_CODIGO_NUFI_VIGE_X_HISTAVAL(inNroFicha, inVigencia)

                                    If tbHISTAVAl.Rows.Count > 0 Then
                                        loAvaluoCatastral += ((CLng(tbHISTAVAl.Rows(0).Item("HIAVAVAL")) * inPorcentaje) / 100)
                                    End If

                                End If

                            Next

                        End If

                        doTotalPorcentaje2 += fun_Formato_Decimal_2_Decimales(((inCANTIDAD * 100) / inTotalRegistros1))

                        ' Inserta el registro en el DataTable
                        dr2 = dt2.NewRow()

                        dr2("Zona") = inZONA
                        dr2("Descripcion") = stDESCRIPCION
                        dr2("Cantidad") = inCANTIDAD
                        dr2("Avaluo") = loAvaluoCatastral
                        dr2("Porcentaje(%)") = fun_Formato_Decimal_2_Decimales(((inCANTIDAD * 100) / inTotalRegistros1))

                        dt2.Rows.Add(dr2)

                    Next

                    ' llena el el datagridview
                    Me.dgvESTADISTICO1.DataSource = dt1
                    Me.dgvESTADISTICO2.DataSource = dt2

                    ' formato de moneda
                    Me.dgvESTADISTICO1.Columns("Avaluo").DefaultCellStyle.Format = "c"
                    Me.dgvESTADISTICO2.Columns("Avaluo").DefaultCellStyle.Format = "c"

                    ' llena los totales
                    Me.lblTotalRegistros1.Text = CType(Me.dgvESTADISTICO1.RowCount, String)
                    Me.lblTotalCantidad1.Text = CType(inTotalRegistros1, String)
                    Me.lblTotalPorcentaje1.Text = CType(CInt(doTotalPorcentaje1), String)

                    Me.lblTotalRegistros2.Text = CType(Me.dgvESTADISTICO2.RowCount, String)
                    Me.lblTotalCantidad2.Text = CType(inTotalRegistros2, String)
                    Me.lblTotalPorcentaje2.Text = CType(CInt(doTotalPorcentaje2), String)

                    ' inserta la totalidad de registros
                    Me.strBARRESTA.Items(2).Text = "Registros : " & Me.dgvESTADISTICO1.RowCount + Me.dgvESTADISTICO2.RowCount

                Else
                    mod_MENSAJE.Consulta_No_Encontro_Registros()
                    Me.strBARRESTA.Items(2).Text = "Registros : 0"

                    ' limpia el reporte
                    Me.dgvESTADISTICO1.DataSource = New DataTable
                    Me.lblTotalRegistros1.Text = "0"

                    Me.dgvESTADISTICO2.DataSource = New DataTable
                    Me.lblTotalRegistros2.Text = "0"

                End If

            End If

            Me.cmdGENERAR.Enabled = True
            Me.cmdGENERAR.Focus()

            mod_MENSAJE.Proceso_Termino_Correctamente()


        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & inFICHAPREDIAL)
            Me.cmdGENERAR.Enabled = True
        End Try

    End Sub
    Private Sub pro_Reporte_de_avaluo_por_barrio_o_vereda()

        Try
            Dim objVerifica As New cla_Verificar_Dato

            ' validad delo datos
            Dim boVIGENCIA1 As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboVIGENCIA1)
            Dim boVIGENCIA2 As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboVIGENCIA2)
            Dim boSECTOR As Boolean = objVerifica.fun_Verificar_Dato_Numerico(Me.txtFIPRCLSE.Text)

            If boSECTOR = False Then
                mod_MENSAJE.Se_Requiere_Seleccionar_Un_Sector()
            End If

            ' verifica los datos
            If boVIGENCIA1 = True And boVIGENCIA2 = True And boSECTOR = True Then

                Me.cmdGENERAR.Enabled = False

                ' declara la tabla
                dtConsulta1 = New DataTable
                dtConsulta2 = New DataTable

                ' llena la tabla
                dtConsulta1 = fun_ConsultarFichaPredialPorCedulaCatastral(Me.txtFIPRCLSE.Text)
                dtConsulta2 = fun_ConsultarFichaPredialPorCedulaCatastral(Me.txtFIPRCLSE.Text)

                ' realiza la insercion mediante la consulta
                If dtConsulta1.Rows.Count > 0 And dtConsulta2.Rows.Count > 0 Then

                    ' Crea objeto de columnas y registros
                    Dim dt1 As New DataTable
                    Dim dr1 As DataRow

                    Dim dt2 As New DataTable
                    Dim dr2 As DataRow

                    ' Crea las columnas
                    dt1.Columns.Add(New DataColumn("Barrio_Vereda", GetType(Integer)))
                    dt1.Columns.Add(New DataColumn("Descripcion", GetType(String)))
                    dt1.Columns.Add(New DataColumn("Cantidad", GetType(Integer)))
                    dt1.Columns.Add(New DataColumn("Avaluo", GetType(Long)))
                    dt1.Columns.Add(New DataColumn("Porcentaje(%)", GetType(Double)))

                    dt2.Columns.Add(New DataColumn("Barrio_Vereda", GetType(Integer)))
                    dt2.Columns.Add(New DataColumn("Descripcion", GetType(String)))
                    dt2.Columns.Add(New DataColumn("Cantidad", GetType(Integer)))
                    dt2.Columns.Add(New DataColumn("Avaluo", GetType(Long)))
                    dt2.Columns.Add(New DataColumn("Porcentaje(%)", GetType(Double)))

                    ' suma la totalidad de los registros encontrados
                    Dim inTotalRegistros1 As Integer = 0
                    Dim doTotalPorcentaje1 As Double = 0

                    Dim inTotalRegistros2 As Integer = 0
                    Dim doTotalPorcentaje2 As Double = 0

                    Dim i1 As Integer = 0
                    Dim i2 As Integer = 0

                    For i1 = 0 To dtConsulta1.Rows.Count - 1
                        inTotalRegistros1 += CType(dtConsulta1.Rows(i1).Item("SuimCant"), Integer)
                    Next

                    For i2 = 0 To dtConsulta2.Rows.Count - 1
                        inTotalRegistros2 += CType(dtConsulta1.Rows(i2).Item("SuimCant"), Integer)
                    Next

                    ' declara la variable
                    Dim dtFichaPredialxCedulaCatastral As New DataTable

                    '*** RECORRE LA CONSULTA 1 ***

                    ' declara la variable y la recorre
                    Dim j1 As Integer = 0

                    For j1 = 0 To dtConsulta1.Rows.Count - 1

                        ' declara las variables
                        Dim stBARRIO_VEREDA As String = ""
                        Dim stDESCRIPCION As String = CStr(dtConsulta1.Rows(j1).Item("BaveDesc"))
                        Dim inCANTIDAD As Integer = CInt(dtConsulta1.Rows(j1).Item("SuimCant"))

                        If Me.txtFIPRCLSE.Text = 1 Then
                            stBARRIO_VEREDA = CStr(Trim(dtConsulta1.Rows(j1).Item("SuimBarr")))
                        ElseIf Me.txtFIPRCLSE.Text = 2 Then
                            stBARRIO_VEREDA = CStr(Trim(dtConsulta1.Rows(j1).Item("SuimManz")))
                        End If

                        ' declara la variable
                        Dim loAvaluoCatastral As Long = 0

                        ' limpia la variable
                        dtFichaPredialxCedulaCatastral = New DataTable

                        ' llena la variable
                        dtFichaPredialxCedulaCatastral = fun_ConsultarFichaPredialPorCedulaCatastral(stBARRIO_VEREDA, Me.txtFIPRCLSE.Text)

                        ' verica que la tabla esta llena
                        If dtFichaPredialxCedulaCatastral.Rows.Count > 0 Then

                            ' declara la variable
                            Dim h As Integer = 0

                            For h = 0 To dtFichaPredialxCedulaCatastral.Rows.Count - 1

                                ' declara la variable
                                Dim inNroFicha As Integer = CInt(dtFichaPredialxCedulaCatastral.Rows(h).Item("SuimNufi"))

                                ' inicializa la instancia
                                Dim obHISTAVAL As New cla_HISTAVAL
                                Dim tbHISTAVAl As New DataTable

                                tbHISTAVAl = obHISTAVAL.fun_Buscar_CODIGO_NUFI_VIGE_X_HISTAVAL(inNroFicha, Me.cboVIGENCIA1.SelectedValue)

                                If tbHISTAVAl.Rows.Count > 0 Then
                                    loAvaluoCatastral += CLng(tbHISTAVAl.Rows(0).Item("HIAVAVAL"))
                                End If

                            Next

                        End If

                        doTotalPorcentaje1 += fun_Formato_Decimal_2_Decimales(((inCANTIDAD * 100) / inTotalRegistros1))

                        ' Inserta el registro en el DataTable
                        dr1 = dt1.NewRow()

                        dr1("Barrio_Vereda") = stBARRIO_VEREDA
                        dr1("Descripcion") = stDESCRIPCION
                        dr1("Cantidad") = inCANTIDAD
                        dr1("Avaluo") = loAvaluoCatastral
                        dr1("Porcentaje(%)") = fun_Formato_Decimal_2_Decimales(((inCANTIDAD * 100) / inTotalRegistros1))

                        dt1.Rows.Add(dr1)

                    Next

                    '*** RECORRE LA CONSULTA 2 ***

                    ' declara la variable y la recorre
                    Dim j2 As Integer = 0

                    For j2 = 0 To dtConsulta2.Rows.Count - 1

                        ' declara las variables
                        Dim stBARRIO_VEREDA As String = ""
                        Dim stDESCRIPCION As String = CStr(dtConsulta1.Rows(j2).Item("BaveDesc"))
                        Dim inCANTIDAD As Integer = CInt(dtConsulta1.Rows(j2).Item("SuimCant"))

                        If Me.txtFIPRCLSE.Text = 1 Then
                            stBARRIO_VEREDA = CStr(Trim(dtConsulta1.Rows(j2).Item("SuimBarr")))
                        ElseIf Me.txtFIPRCLSE.Text = 2 Then
                            stBARRIO_VEREDA = CStr(Trim(dtConsulta1.Rows(j2).Item("SuimManz")))
                        End If

                        ' declara la variable
                        Dim loAvaluoCatastral As Long = 0

                        ' limpia la variable
                        dtFichaPredialxCedulaCatastral = New DataTable

                        ' llena la variable
                        dtFichaPredialxCedulaCatastral = fun_ConsultarFichaPredialPorCedulaCatastral(stBARRIO_VEREDA, Me.txtFIPRCLSE.Text)

                        ' verica que la tabla esta llena
                        If dtFichaPredialxCedulaCatastral.Rows.Count > 0 Then

                            ' declara la variable
                            Dim h As Integer = 0

                            For h = 0 To dtFichaPredialxCedulaCatastral.Rows.Count - 1

                                ' declara la variable
                                Dim inNroFicha As Integer = CInt(dtFichaPredialxCedulaCatastral.Rows(h).Item("SuimNufi"))

                                ' inicializa la instancia
                                Dim obHISTAVAL As New cla_HISTAVAL
                                Dim tbHISTAVAl As New DataTable

                                tbHISTAVAl = obHISTAVAL.fun_Buscar_CODIGO_NUFI_VIGE_X_HISTAVAL(inNroFicha, Me.cboVIGENCIA2.SelectedValue)

                                If tbHISTAVAl.Rows.Count > 0 Then
                                    loAvaluoCatastral += CLng(tbHISTAVAl.Rows(0).Item("HIAVAVAL"))
                                End If

                            Next

                        End If

                        doTotalPorcentaje2 += fun_Formato_Decimal_2_Decimales(((inCANTIDAD * 100) / inTotalRegistros1))

                        ' Inserta el registro en el DataTable
                        dr2 = dt2.NewRow()

                        dr2("Barrio_Vereda") = stBARRIO_VEREDA
                        dr2("Descripcion") = stDESCRIPCION
                        dr2("Cantidad") = inCANTIDAD
                        dr2("Avaluo") = loAvaluoCatastral
                        dr2("Porcentaje(%)") = fun_Formato_Decimal_2_Decimales(((inCANTIDAD * 100) / inTotalRegistros1))

                        dt2.Rows.Add(dr2)

                    Next

                    ' llena el el datagridview
                    Me.dgvESTADISTICO1.DataSource = dt1
                    Me.dgvESTADISTICO2.DataSource = dt2

                    ' formato de moneda
                    Me.dgvESTADISTICO1.Columns("Avaluo").DefaultCellStyle.Format = "c"
                    Me.dgvESTADISTICO2.Columns("Avaluo").DefaultCellStyle.Format = "c"

                    ' llena los totales
                    Me.lblTotalRegistros1.Text = CType(Me.dgvESTADISTICO1.RowCount, String)
                    Me.lblTotalCantidad1.Text = CType(inTotalRegistros1, String)
                    Me.lblTotalPorcentaje1.Text = CType(CInt(doTotalPorcentaje1), String)

                    Me.lblTotalRegistros2.Text = CType(Me.dgvESTADISTICO2.RowCount, String)
                    Me.lblTotalCantidad2.Text = CType(inTotalRegistros2, String)
                    Me.lblTotalPorcentaje2.Text = CType(CInt(doTotalPorcentaje2), String)

                    ' inserta la totalidad de registros
                    Me.strBARRESTA.Items(2).Text = "Registros : " & Me.dgvESTADISTICO1.RowCount + Me.dgvESTADISTICO2.RowCount

                Else
                    mod_MENSAJE.Consulta_No_Encontro_Registros()
                    Me.strBARRESTA.Items(2).Text = "Registros : 0"

                    ' limpia el reporte
                    Me.dgvESTADISTICO1.DataSource = New DataTable
                    Me.lblTotalRegistros1.Text = "0"

                    Me.dgvESTADISTICO2.DataSource = New DataTable
                    Me.lblTotalRegistros2.Text = "0"

                End If

            End If

            Me.cmdGENERAR.Enabled = True
            Me.cmdGENERAR.Focus()

            mod_MENSAJE.Proceso_Termino_Correctamente()


        Catch ex As Exception
            MessageBox.Show(Err.Description)
            Me.cmdGENERAR.Enabled = True
        End Try

    End Sub
    Private Sub pro_Reporte_de_avaluo_por_estrato()

        Try
            Dim objVerifica As New cla_Verificar_Dato

            ' validad delo datos
            Dim boVIGENCIA1 As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboVIGENCIA1)
            Dim boVIGENCIA2 As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboVIGENCIA2)

            ' verifica los datos
            If boVIGENCIA1 = True And boVIGENCIA2 = True Then

                Me.cmdGENERAR.Enabled = False

                ' declara la tabla
                dtConsulta1 = New DataTable
                dtConsulta2 = New DataTable

                ' llena la tabla
                dtConsulta1 = fun_ConsultarFichaPredialPorEstrato(Me.cboVIGENCIA1.SelectedValue)
                dtConsulta2 = fun_ConsultarFichaPredialPorEstrato(Me.cboVIGENCIA2.SelectedValue)

                ' realiza la insercion mediante la consulta
                If dtConsulta1.Rows.Count > 0 And dtConsulta2.Rows.Count > 0 Then

                    ' Crea objeto de columnas y registros
                    Dim dt1 As New DataTable
                    Dim dr1 As DataRow

                    Dim dt2 As New DataTable
                    Dim dr2 As DataRow

                    ' Crea las columnas
                    dt1.Columns.Add(New DataColumn("Estrato", GetType(Integer)))
                    dt1.Columns.Add(New DataColumn("Descripcion", GetType(String)))
                    dt1.Columns.Add(New DataColumn("Cantidad", GetType(Integer)))
                    dt1.Columns.Add(New DataColumn("Avaluo", GetType(Long)))
                    dt1.Columns.Add(New DataColumn("Porcentaje(%)", GetType(Double)))

                    dt2.Columns.Add(New DataColumn("Estrato", GetType(Integer)))
                    dt2.Columns.Add(New DataColumn("Descripcion", GetType(String)))
                    dt2.Columns.Add(New DataColumn("Cantidad", GetType(Integer)))
                    dt2.Columns.Add(New DataColumn("Avaluo", GetType(Long)))
                    dt2.Columns.Add(New DataColumn("Porcentaje(%)", GetType(Double)))

                    ' suma la totalidad de los registros encontrados
                    Dim inTotalRegistros1 As Integer = 0
                    Dim doTotalPorcentaje1 As Double = 0

                    Dim inTotalRegistros2 As Integer = 0
                    Dim doTotalPorcentaje2 As Double = 0

                    Dim i1 As Integer = 0
                    Dim i2 As Integer = 0

                    For i1 = 0 To dtConsulta1.Rows.Count - 1
                        inTotalRegistros1 += CType(dtConsulta1.Rows(i1).Item("HiliCant"), Integer)
                    Next

                    For i2 = 0 To dtConsulta2.Rows.Count - 1
                        inTotalRegistros2 += CType(dtConsulta1.Rows(i2).Item("HiliCant"), Integer)
                    Next

                    ' declara la variable
                    Dim dtFichaPredialxEstrato As New DataTable

                    '*** RECORRE LA CONSULTA 1 ***

                    ' declara la variable y la recorre
                    Dim j1 As Integer = 0

                    For j1 = 0 To dtConsulta1.Rows.Count - 1

                        ' declara las variables
                        Dim inESTRATO As Integer = CInt(dtConsulta1.Rows(j1).Item("HiliEstr"))
                        Dim stDESCRIPCION As String = CStr(dtConsulta1.Rows(j1).Item("EstrDesc"))
                        Dim inCANTIDAD As Integer = CInt(dtConsulta1.Rows(j1).Item("HiliCant"))

                        ' declara la variable
                        Dim loAvaluoCatastral As Long = 0

                        ' limpia la variable
                        dtFichaPredialxEstrato = New DataTable

                        ' llena la variable
                        dtFichaPredialxEstrato = fun_ConsultarFichaPredialPorEstrato(inESTRATO, Me.cboVIGENCIA1.SelectedValue)

                        ' verica que la tabla esta llena
                        If dtFichaPredialxEstrato.Rows.Count > 0 Then

                            ' declara la variable
                            Dim h As Integer = 0

                            For h = 0 To dtFichaPredialxEstrato.Rows.Count - 1

                                ' declara la variable
                                Dim inNroFicha As Integer = CInt(dtFichaPredialxEstrato.Rows(h).Item("HiliNufi"))
                                Dim inVigencia As Integer = CInt(dtFichaPredialxEstrato.Rows(h).Item("HiliVige"))

                                ' inicializa la instancia
                                Dim obHISTAVAL As New cla_HISTAVAL
                                Dim tbHISTAVAl As New DataTable

                                tbHISTAVAl = obHISTAVAL.fun_Buscar_CODIGO_NUFI_VIGE_X_HISTAVAL(inNroFicha, inVigencia)

                                If tbHISTAVAl.Rows.Count > 0 Then
                                    loAvaluoCatastral += CLng(tbHISTAVAl.Rows(0).Item("HIAVAVAL"))
                                End If

                            Next

                        End If

                        doTotalPorcentaje1 += fun_Formato_Decimal_2_Decimales(((inCANTIDAD * 100) / inTotalRegistros1))

                        ' Inserta el registro en el DataTable
                        dr1 = dt1.NewRow()

                        dr1("Estrato") = inESTRATO
                        dr1("Descripcion") = stDESCRIPCION
                        dr1("Cantidad") = inCANTIDAD
                        dr1("Avaluo") = loAvaluoCatastral
                        dr1("Porcentaje(%)") = fun_Formato_Decimal_2_Decimales(((inCANTIDAD * 100) / inTotalRegistros1))

                        dt1.Rows.Add(dr1)

                    Next

                    '*** RECORRE LA CONSULTA 2 ***

                    ' declara la variable y la recorre
                    Dim j2 As Integer = 0

                    For j2 = 0 To dtConsulta2.Rows.Count - 1

                        ' declara las variables
                        Dim inESTRATO As Integer = CInt(dtConsulta2.Rows(j2).Item("HiliEstr"))
                        Dim stDESCRIPCION As String = CStr(dtConsulta2.Rows(j2).Item("EstrDesc"))
                        Dim inCANTIDAD As Integer = CInt(dtConsulta2.Rows(j2).Item("HiliCant"))

                        ' declara la variable
                        Dim loAvaluoCatastral As Long = 0

                        ' limpia la variable
                        dtFichaPredialxEstrato = New DataTable

                        ' llena la variable
                        dtFichaPredialxEstrato = fun_ConsultarFichaPredialPorEstrato(inESTRATO, Me.cboVIGENCIA2.SelectedValue)

                        ' verica que la tabla esta llena
                        If dtFichaPredialxEstrato.Rows.Count > 0 Then

                            ' declara la variable
                            Dim h As Integer = 0

                            For h = 0 To dtFichaPredialxEstrato.Rows.Count - 1

                                ' declara la variable
                                Dim inNroFicha As Integer = CInt(dtFichaPredialxEstrato.Rows(h).Item("HiliNufi"))
                                Dim inVigencia As Integer = CInt(dtFichaPredialxEstrato.Rows(h).Item("HiliVige"))

                                ' inicializa la instancia
                                Dim obHISTAVAL As New cla_HISTAVAL
                                Dim tbHISTAVAl As New DataTable

                                tbHISTAVAl = obHISTAVAL.fun_Buscar_CODIGO_NUFI_VIGE_X_HISTAVAL(inNroFicha, inVigencia)

                                If tbHISTAVAl.Rows.Count > 0 Then
                                    loAvaluoCatastral += CLng(tbHISTAVAl.Rows(0).Item("HIAVAVAL"))
                                End If

                            Next

                        End If

                        doTotalPorcentaje2 += fun_Formato_Decimal_2_Decimales(((inCANTIDAD * 100) / inTotalRegistros1))

                        ' Inserta el registro en el DataTable
                        dr2 = dt2.NewRow()

                        dr2("Estrato") = inESTRATO
                        dr2("Descripcion") = stDESCRIPCION
                        dr2("Cantidad") = inCANTIDAD
                        dr2("Avaluo") = loAvaluoCatastral
                        dr2("Porcentaje(%)") = fun_Formato_Decimal_2_Decimales(((inCANTIDAD * 100) / inTotalRegistros1))

                        dt2.Rows.Add(dr2)

                    Next

                    ' llena el el datagridview
                    Me.dgvESTADISTICO1.DataSource = dt1
                    Me.dgvESTADISTICO2.DataSource = dt2

                    ' formato de moneda
                    Me.dgvESTADISTICO1.Columns("Avaluo").DefaultCellStyle.Format = "c"
                    Me.dgvESTADISTICO2.Columns("Avaluo").DefaultCellStyle.Format = "c"

                    ' llena los totales
                    Me.lblTotalRegistros1.Text = CType(Me.dgvESTADISTICO1.RowCount, String)
                    Me.lblTotalCantidad1.Text = CType(inTotalRegistros1, String)
                    Me.lblTotalPorcentaje1.Text = CType(CInt(doTotalPorcentaje1), String)

                    Me.lblTotalRegistros2.Text = CType(Me.dgvESTADISTICO2.RowCount, String)
                    Me.lblTotalCantidad2.Text = CType(inTotalRegistros2, String)
                    Me.lblTotalPorcentaje2.Text = CType(CInt(doTotalPorcentaje2), String)

                    ' inserta la totalidad de registros
                    Me.strBARRESTA.Items(2).Text = "Registros : " & Me.dgvESTADISTICO1.RowCount + Me.dgvESTADISTICO2.RowCount

                Else
                    mod_MENSAJE.Consulta_No_Encontro_Registros()
                    Me.strBARRESTA.Items(2).Text = "Registros : 0"

                    ' limpia el reporte
                    Me.dgvESTADISTICO1.DataSource = New DataTable
                    Me.lblTotalRegistros1.Text = "0"

                    Me.dgvESTADISTICO2.DataSource = New DataTable
                    Me.lblTotalRegistros2.Text = "0"

                End If

            End If

            Me.cmdGENERAR.Enabled = True
            Me.cmdGENERAR.Focus()

            mod_MENSAJE.Proceso_Termino_Correctamente()


        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub pro_Reporte_de_avaluo_por_tipo_de_calificacion()

        Try
            Dim objVerifica As New cla_Verificar_Dato

            ' validad delo datos
            Dim boVIGENCIA1 As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboVIGENCIA1)
            Dim boVIGENCIA2 As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboVIGENCIA2)

            ' verifica los datos
            If boVIGENCIA1 = True And boVIGENCIA2 = True Then

                Me.cmdGENERAR.Enabled = False

                ' declara la tabla
                dtConsulta1 = New DataTable
                dtConsulta2 = New DataTable

                ' llena la tabla
                dtConsulta1 = fun_ConsultarFichaPredialPorTipoDeCalificacion(Me.cboVIGENCIA1.SelectedValue)
                dtConsulta2 = fun_ConsultarFichaPredialPorTipoDeCalificacion(Me.cboVIGENCIA2.SelectedValue)

                ' realiza la insercion mediante la consulta
                If dtConsulta1.Rows.Count > 0 And dtConsulta2.Rows.Count > 0 Then

                    ' Crea objeto de columnas y registros
                    Dim dt1 As New DataTable
                    Dim dr1 As DataRow

                    Dim dt2 As New DataTable
                    Dim dr2 As DataRow

                    ' Crea las columnas
                    dt1.Columns.Add(New DataColumn("Tipo", GetType(String)))
                    dt1.Columns.Add(New DataColumn("Descripcion", GetType(String)))
                    dt1.Columns.Add(New DataColumn("Cantidad", GetType(Integer)))
                    dt1.Columns.Add(New DataColumn("Avaluo", GetType(Long)))
                    dt1.Columns.Add(New DataColumn("Porcentaje(%)", GetType(Double)))

                    dt2.Columns.Add(New DataColumn("Tipo", GetType(String)))
                    dt2.Columns.Add(New DataColumn("Descripcion", GetType(String)))
                    dt2.Columns.Add(New DataColumn("Cantidad", GetType(Integer)))
                    dt2.Columns.Add(New DataColumn("Avaluo", GetType(Long)))
                    dt2.Columns.Add(New DataColumn("Porcentaje(%)", GetType(Double)))

                    ' suma la totalidad de los registros encontrados
                    Dim inTotalRegistros1 As Integer = 0
                    Dim doTotalPorcentaje1 As Double = 0

                    Dim inTotalRegistros2 As Integer = 0
                    Dim doTotalPorcentaje2 As Double = 0

                    Dim i1 As Integer = 0
                    Dim i2 As Integer = 0

                    For i1 = 0 To dtConsulta1.Rows.Count - 1
                        inTotalRegistros1 += CType(dtConsulta1.Rows(i1).Item("HiliCant"), Integer)
                    Next

                    For i2 = 0 To dtConsulta2.Rows.Count - 1
                        inTotalRegistros2 += CType(dtConsulta1.Rows(i2).Item("HiliCant"), Integer)
                    Next

                    ' declara la variable
                    Dim dtFichaPredialxTipoCalificacion As New DataTable

                    '*** RECORRE LA CONSULTA 1 ***

                    ' declara la variable y la recorre
                    Dim j1 As Integer = 0

                    For j1 = 0 To dtConsulta1.Rows.Count - 1

                        ' declara las variables
                        Dim stTIPO As String = CStr(Trim(dtConsulta1.Rows(j1).Item("HiliTipo")))
                        Dim stDESCRIPCION As String = CStr(dtConsulta1.Rows(j1).Item("TicaDesc"))
                        Dim inCANTIDAD As Integer = CInt(dtConsulta1.Rows(j1).Item("HiliCant"))

                        ' declara la variable
                        Dim loAvaluoCatastral As Long = 0

                        ' limpia la variable
                        dtFichaPredialxTipoCalificacion = New DataTable

                        ' llena la variable
                        dtFichaPredialxTipoCalificacion = fun_ConsultarFichaPredialPorTipoDeCalificacion(stTIPO, Me.cboVIGENCIA1.SelectedValue)

                        ' verica que la tabla esta llena
                        If dtFichaPredialxTipoCalificacion.Rows.Count > 0 Then

                            ' declara la variable
                            Dim h As Integer = 0

                            For h = 0 To dtFichaPredialxTipoCalificacion.Rows.Count - 1

                                ' declara la variable
                                Dim inNroFicha As Integer = CInt(dtFichaPredialxTipoCalificacion.Rows(h).Item("HiliNufi"))
                                Dim inVigencia As Integer = CInt(dtFichaPredialxTipoCalificacion.Rows(h).Item("HiliVige"))

                                ' inicializa la instancia
                                Dim obHISTAVAL As New cla_HISTAVAL
                                Dim tbHISTAVAl As New DataTable

                                tbHISTAVAl = obHISTAVAL.fun_Buscar_CODIGO_NUFI_VIGE_X_HISTAVAL(inNroFicha, inVigencia)

                                If tbHISTAVAl.Rows.Count > 0 Then
                                    loAvaluoCatastral += CLng(tbHISTAVAl.Rows(0).Item("HIAVAVAL"))
                                End If

                            Next

                        End If

                        doTotalPorcentaje1 += fun_Formato_Decimal_2_Decimales(((inCANTIDAD * 100) / inTotalRegistros1))

                        ' Inserta el registro en el DataTable
                        dr1 = dt1.NewRow()

                        dr1("Tipo") = stTIPO
                        dr1("Descripcion") = stDESCRIPCION
                        dr1("Cantidad") = inCANTIDAD
                        dr1("Avaluo") = loAvaluoCatastral
                        dr1("Porcentaje(%)") = fun_Formato_Decimal_2_Decimales(((inCANTIDAD * 100) / inTotalRegistros1))

                        dt1.Rows.Add(dr1)

                    Next

                    '*** RECORRE LA CONSULTA 2 ***

                    ' declara la variable y la recorre
                    Dim j2 As Integer = 0

                    For j2 = 0 To dtConsulta2.Rows.Count - 1

                        ' declara las variables
                        Dim stTIPO As String = CStr(Trim(dtConsulta2.Rows(j2).Item("HiliTipo")))
                        Dim stDESCRIPCION As String = CStr(dtConsulta2.Rows(j2).Item("TicaDesc"))
                        Dim inCANTIDAD As Integer = CInt(dtConsulta2.Rows(j2).Item("HiliCant"))

                        ' declara la variable
                        Dim loAvaluoCatastral As Long = 0

                        ' limpia la variable
                        dtFichaPredialxTipoCalificacion = New DataTable

                        ' llena la variable
                        dtFichaPredialxTipoCalificacion = fun_ConsultarFichaPredialPorTipoDeCalificacion(stTIPO, Me.cboVIGENCIA2.SelectedValue)

                        ' verica que la tabla esta llena
                        If dtFichaPredialxTipoCalificacion.Rows.Count > 0 Then

                            ' declara la variable
                            Dim h As Integer = 0

                            For h = 0 To dtFichaPredialxTipoCalificacion.Rows.Count - 1

                                ' declara la variable
                                Dim inNroFicha As Integer = CInt(dtFichaPredialxTipoCalificacion.Rows(h).Item("HiliNufi"))
                                Dim inVigencia As Integer = CInt(dtFichaPredialxTipoCalificacion.Rows(h).Item("HiliVige"))

                                ' inicializa la instancia
                                Dim obHISTAVAL As New cla_HISTAVAL
                                Dim tbHISTAVAl As New DataTable

                                tbHISTAVAl = obHISTAVAL.fun_Buscar_CODIGO_NUFI_VIGE_X_HISTAVAL(inNroFicha, inVigencia)

                                If tbHISTAVAl.Rows.Count > 0 Then
                                    loAvaluoCatastral += CLng(tbHISTAVAl.Rows(0).Item("HIAVAVAL"))
                                End If

                            Next

                        End If

                        doTotalPorcentaje2 += fun_Formato_Decimal_2_Decimales(((inCANTIDAD * 100) / inTotalRegistros1))

                        ' Inserta el registro en el DataTable
                        dr2 = dt2.NewRow()

                        dr2("Tipo") = stTIPO
                        dr2("Descripcion") = stDESCRIPCION
                        dr2("Cantidad") = inCANTIDAD
                        dr2("Avaluo") = loAvaluoCatastral
                        dr2("Porcentaje(%)") = fun_Formato_Decimal_2_Decimales(((inCANTIDAD * 100) / inTotalRegistros1))

                        dt2.Rows.Add(dr2)

                    Next

                    ' llena el el datagridview
                    Me.dgvESTADISTICO1.DataSource = dt1
                    Me.dgvESTADISTICO2.DataSource = dt2

                    ' formato de moneda
                    Me.dgvESTADISTICO1.Columns("Avaluo").DefaultCellStyle.Format = "c"
                    Me.dgvESTADISTICO2.Columns("Avaluo").DefaultCellStyle.Format = "c"

                    ' llena los totales
                    Me.lblTotalRegistros1.Text = CType(Me.dgvESTADISTICO1.RowCount, String)
                    Me.lblTotalCantidad1.Text = CType(inTotalRegistros1, String)
                    Me.lblTotalPorcentaje1.Text = CType(CInt(doTotalPorcentaje1), String)

                    Me.lblTotalRegistros2.Text = CType(Me.dgvESTADISTICO2.RowCount, String)
                    Me.lblTotalCantidad2.Text = CType(inTotalRegistros2, String)
                    Me.lblTotalPorcentaje2.Text = CType(CInt(doTotalPorcentaje2), String)

                    ' inserta la totalidad de registros
                    Me.strBARRESTA.Items(2).Text = "Registros : " & Me.dgvESTADISTICO1.RowCount + Me.dgvESTADISTICO2.RowCount

                Else
                    mod_MENSAJE.Consulta_No_Encontro_Registros()
                    Me.strBARRESTA.Items(2).Text = "Registros : 0"

                    ' limpia el reporte
                    Me.dgvESTADISTICO1.DataSource = New DataTable
                    Me.lblTotalRegistros1.Text = "0"

                    Me.dgvESTADISTICO2.DataSource = New DataTable
                    Me.lblTotalRegistros2.Text = "0"

                End If

            End If

            Me.cmdGENERAR.Enabled = True
            Me.cmdGENERAR.Focus()

            mod_MENSAJE.Proceso_Termino_Correctamente()


        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub pro_Reporte_de_avaluo_por_destinacion_economica()

        Try
            Dim objVerifica As New cla_Verificar_Dato

            ' validad delo datos
            Dim boVIGENCIA1 As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboVIGENCIA1)
            Dim boVIGENCIA2 As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboVIGENCIA2)

            ' verifica los datos
            If boVIGENCIA1 = True And boVIGENCIA2 = True Then

                Me.cmdGENERAR.Enabled = False

                ' declara la tabla
                dtConsulta1 = New DataTable
                dtConsulta2 = New DataTable

                ' llena la tabla
                dtConsulta1 = fun_ConsultarFichaPredialPorDestinoEconomico(Me.cboVIGENCIA1.SelectedValue)
                dtConsulta2 = fun_ConsultarFichaPredialPorDestinoEconomico(Me.cboVIGENCIA2.SelectedValue)

                ' realiza la insercion mediante la consulta
                If dtConsulta1.Rows.Count > 0 And dtConsulta2.Rows.Count > 0 Then

                    ' Crea objeto de columnas y registros
                    Dim dt1 As New DataTable
                    Dim dr1 As DataRow

                    Dim dt2 As New DataTable
                    Dim dr2 As DataRow

                    ' Crea las columnas
                    dt1.Columns.Add(New DataColumn("Destino", GetType(Integer)))
                    dt1.Columns.Add(New DataColumn("Descripcion", GetType(String)))
                    dt1.Columns.Add(New DataColumn("Cantidad", GetType(Integer)))
                    dt1.Columns.Add(New DataColumn("Avaluo", GetType(Long)))
                    dt1.Columns.Add(New DataColumn("Porcentaje(%)", GetType(Double)))

                    dt2.Columns.Add(New DataColumn("Destino", GetType(Integer)))
                    dt2.Columns.Add(New DataColumn("Descripcion", GetType(String)))
                    dt2.Columns.Add(New DataColumn("Cantidad", GetType(Integer)))
                    dt2.Columns.Add(New DataColumn("Avaluo", GetType(Long)))
                    dt2.Columns.Add(New DataColumn("Porcentaje(%)", GetType(Double)))

                    ' suma la totalidad de los registros encontrados
                    Dim inTotalRegistros1 As Integer = 0
                    Dim doTotalPorcentaje1 As Double = 0

                    Dim inTotalRegistros2 As Integer = 0
                    Dim doTotalPorcentaje2 As Double = 0

                    Dim i1 As Integer = 0
                    Dim i2 As Integer = 0

                    For i1 = 0 To dtConsulta1.Rows.Count - 1
                        inTotalRegistros1 += CType(dtConsulta1.Rows(i1).Item("HiliCant"), Integer)
                    Next

                    For i2 = 0 To dtConsulta2.Rows.Count - 1
                        inTotalRegistros2 += CType(dtConsulta1.Rows(i2).Item("HiliCant"), Integer)
                    Next

                    ' declara la variable
                    Dim dtFichaPredialxDestinoEconomico As New DataTable

                    '*** RECORRE LA CONSULTA 1 ***

                    ' declara la variable y la recorre
                    Dim j1 As Integer = 0

                    For j1 = 0 To dtConsulta1.Rows.Count - 1

                        ' declara las variables
                        Dim inDESTINO As Integer = CInt(dtConsulta1.Rows(j1).Item("HiliDeec"))
                        Dim stDESCRIPCION As String = CStr(dtConsulta1.Rows(j1).Item("DeecDesc"))
                        Dim inCANTIDAD As Integer = CInt(dtConsulta1.Rows(j1).Item("HiliCant"))

                        ' declara la variable
                        Dim loAvaluoCatastral As Long = 0

                        ' limpia la variable
                        dtFichaPredialxDestinoEconomico = New DataTable

                        ' llena la variable
                        dtFichaPredialxDestinoEconomico = fun_ConsultarFichaPredialPorDestinoEconomico(inDESTINO, Me.cboVIGENCIA1.SelectedValue)

                        ' verica que la tabla esta llena
                        If dtFichaPredialxDestinoEconomico.Rows.Count > 0 Then

                            ' declara la variable
                            Dim h As Integer = 0

                            For h = 0 To dtFichaPredialxDestinoEconomico.Rows.Count - 1

                                ' declara la variable
                                Dim inNroFicha As Integer = CInt(dtFichaPredialxDestinoEconomico.Rows(h).Item("HiliNufi"))
                                Dim inVigencia As Integer = CInt(dtFichaPredialxDestinoEconomico.Rows(h).Item("HiliVige"))

                                ' inicializa la instancia
                                Dim obHISTAVAL As New cla_HISTAVAL
                                Dim tbHISTAVAl As New DataTable

                                tbHISTAVAl = obHISTAVAL.fun_Buscar_CODIGO_NUFI_VIGE_X_HISTAVAL(inNroFicha, inVigencia)

                                If tbHISTAVAl.Rows.Count > 0 Then
                                    loAvaluoCatastral += CLng(tbHISTAVAl.Rows(0).Item("HIAVAVAL"))
                                End If

                            Next

                        End If

                        doTotalPorcentaje1 += fun_Formato_Decimal_2_Decimales(((inCANTIDAD * 100) / inTotalRegistros1))

                        ' Inserta el registro en el DataTable
                        dr1 = dt1.NewRow()

                        dr1("Destino") = inDESTINO
                        dr1("Descripcion") = stDESCRIPCION
                        dr1("Cantidad") = inCANTIDAD
                        dr1("Avaluo") = loAvaluoCatastral
                        dr1("Porcentaje(%)") = fun_Formato_Decimal_2_Decimales(((inCANTIDAD * 100) / inTotalRegistros1))

                        dt1.Rows.Add(dr1)

                    Next

                    '*** RECORRE LA CONSULTA 2 ***

                    ' declara la variable y la recorre
                    Dim j2 As Integer = 0

                    For j2 = 0 To dtConsulta2.Rows.Count - 1

                        ' declara las variables
                        Dim inDESTINO As Integer = CInt(dtConsulta2.Rows(j2).Item("HiliDeec"))
                        Dim stDESCRIPCION As String = CStr(dtConsulta2.Rows(j2).Item("DeecDesc"))
                        Dim inCANTIDAD As Integer = CInt(dtConsulta2.Rows(j2).Item("HiliCant"))

                        ' declara la variable
                        Dim loAvaluoCatastral As Long = 0

                        ' limpia la variable
                        dtFichaPredialxDestinoEconomico = New DataTable

                        ' llena la variable
                        dtFichaPredialxDestinoEconomico = fun_ConsultarFichaPredialPorDestinoEconomico(inDESTINO, Me.cboVIGENCIA2.SelectedValue)

                        ' verica que la tabla esta llena
                        If dtFichaPredialxDestinoEconomico.Rows.Count > 0 Then

                            ' declara la variable
                            Dim h As Integer = 0

                            For h = 0 To dtFichaPredialxDestinoEconomico.Rows.Count - 1

                                ' declara la variable
                                Dim inNroFicha As Integer = CInt(dtFichaPredialxDestinoEconomico.Rows(h).Item("HiliNufi"))
                                Dim inVigencia As Integer = CInt(dtFichaPredialxDestinoEconomico.Rows(h).Item("HiliVige"))

                                ' inicializa la instancia
                                Dim obHISTAVAL As New cla_HISTAVAL
                                Dim tbHISTAVAl As New DataTable

                                tbHISTAVAl = obHISTAVAL.fun_Buscar_CODIGO_NUFI_VIGE_X_HISTAVAL(inNroFicha, inVigencia)

                                If tbHISTAVAl.Rows.Count > 0 Then
                                    loAvaluoCatastral += CLng(tbHISTAVAl.Rows(0).Item("HIAVAVAL"))
                                End If

                            Next

                        End If

                        doTotalPorcentaje2 += fun_Formato_Decimal_2_Decimales(((inCANTIDAD * 100) / inTotalRegistros1))

                        ' Inserta el registro en el DataTable
                        dr2 = dt2.NewRow()

                        dr2("Destino") = inDESTINO
                        dr2("Descripcion") = stDESCRIPCION
                        dr2("Cantidad") = inCANTIDAD
                        dr2("Avaluo") = loAvaluoCatastral
                        dr2("Porcentaje(%)") = fun_Formato_Decimal_2_Decimales(((inCANTIDAD * 100) / inTotalRegistros1))

                        dt2.Rows.Add(dr2)

                    Next

                    ' llena el el datagridview
                    Me.dgvESTADISTICO1.DataSource = dt1
                    Me.dgvESTADISTICO2.DataSource = dt2

                    ' formato de moneda
                    Me.dgvESTADISTICO1.Columns("Avaluo").DefaultCellStyle.Format = "c"
                    Me.dgvESTADISTICO2.Columns("Avaluo").DefaultCellStyle.Format = "c"

                    ' llena los totales
                    Me.lblTotalRegistros1.Text = CType(Me.dgvESTADISTICO1.RowCount, String)
                    Me.lblTotalCantidad1.Text = CType(inTotalRegistros1, String)
                    Me.lblTotalPorcentaje1.Text = CType(CInt(doTotalPorcentaje1), String)

                    Me.lblTotalRegistros2.Text = CType(Me.dgvESTADISTICO2.RowCount, String)
                    Me.lblTotalCantidad2.Text = CType(inTotalRegistros2, String)
                    Me.lblTotalPorcentaje2.Text = CType(CInt(doTotalPorcentaje2), String)

                    ' inserta la totalidad de registros
                    Me.strBARRESTA.Items(2).Text = "Registros : " & Me.dgvESTADISTICO1.RowCount + Me.dgvESTADISTICO2.RowCount

                Else
                    mod_MENSAJE.Consulta_No_Encontro_Registros()
                    Me.strBARRESTA.Items(2).Text = "Registros : 0"

                    ' limpia el reporte
                    Me.dgvESTADISTICO1.DataSource = New DataTable
                    Me.lblTotalRegistros1.Text = "0"

                    Me.dgvESTADISTICO2.DataSource = New DataTable
                    Me.lblTotalRegistros2.Text = "0"

                End If

            End If

            Me.cmdGENERAR.Enabled = True
            Me.cmdGENERAR.Focus()

            mod_MENSAJE.Proceso_Termino_Correctamente()

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub pro_Reporte_de_impuesto_por_zonas()
        Try
            Try
                Dim objVerifica As New cla_Verificar_Dato

                ' validad delo datos
                Dim boVIGENCIA1 As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboVIGENCIA1)
                Dim boVIGENCIA2 As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboVIGENCIA2)

                ' verifica los datos
                If boVIGENCIA1 = True And boVIGENCIA2 = True Then

                    Me.cmdGENERAR.Enabled = False

                    ' declara la tabla
                    dtConsulta1 = New DataTable
                    dtConsulta2 = New DataTable

                    ' llena la tabla
                    dtConsulta1 = fun_ConsultarFichaPredialPorZonaEconomica(Me.cboVIGENCIA1.SelectedValue)
                    dtConsulta2 = fun_ConsultarFichaPredialPorZonaEconomica(Me.cboVIGENCIA2.SelectedValue)

                    ' realiza la insercion mediante la consulta
                    If dtConsulta1.Rows.Count > 0 And dtConsulta2.Rows.Count > 0 Then

                        ' Crea objeto de columnas y registros
                        Dim dt1 As New DataTable
                        Dim dr1 As DataRow

                        Dim dt2 As New DataTable
                        Dim dr2 As DataRow

                        ' Crea las columnas
                        dt1.Columns.Add(New DataColumn("Zona", GetType(Integer)))
                        dt1.Columns.Add(New DataColumn("Descripcion", GetType(String)))
                        dt1.Columns.Add(New DataColumn("Cantidad", GetType(Integer)))
                        dt1.Columns.Add(New DataColumn("Predial", GetType(Long)))
                        dt1.Columns.Add(New DataColumn("Porcentaje(%)", GetType(Double)))

                        dt2.Columns.Add(New DataColumn("Zona", GetType(Integer)))
                        dt2.Columns.Add(New DataColumn("Descripcion", GetType(String)))
                        dt2.Columns.Add(New DataColumn("Cantidad", GetType(Integer)))
                        dt2.Columns.Add(New DataColumn("Predial", GetType(Long)))
                        dt2.Columns.Add(New DataColumn("Porcentaje(%)", GetType(Double)))

                        ' suma la totalidad de los registros encontrados
                        Dim inTotalRegistros1 As Integer = 0
                        Dim doTotalPorcentaje1 As Double = 0

                        Dim inTotalRegistros2 As Integer = 0
                        Dim doTotalPorcentaje2 As Double = 0

                        Dim i1 As Integer = 0
                        Dim i2 As Integer = 0

                        For i1 = 0 To dtConsulta1.Rows.Count - 1
                            inTotalRegistros1 += CType(dtConsulta1.Rows(i1).Item("HizoCant"), Integer)
                        Next

                        For i2 = 0 To dtConsulta2.Rows.Count - 1
                            inTotalRegistros2 += CType(dtConsulta1.Rows(i2).Item("HizoCant"), Integer)
                        Next

                        ' declara la variable
                        Dim dtFichaPredialxZonaEconomica As New DataTable

                        '*** RECORRE LA CONSULTA 1 ***

                        ' declara la variable y la recorre
                        Dim j1 As Integer = 0

                        For j1 = 0 To dtConsulta1.Rows.Count - 1

                            ' declara las variables
                            Dim inZONA As Integer = CInt(dtConsulta1.Rows(j1).Item("HizoZoec"))
                            Dim stDESCRIPCION As String = CStr(dtConsulta1.Rows(j1).Item("ZoecDesc"))
                            Dim inCANTIDAD As Integer = CInt(dtConsulta1.Rows(j1).Item("HizoCant"))

                            ' declara la variable
                            Dim loImpuestoPredial As Long = 0

                            ' limpia la variable
                            dtFichaPredialxZonaEconomica = New DataTable

                            ' llena la variable
                            dtFichaPredialxZonaEconomica = fun_ConsultarFichaPredialPorZonaEconomica(inZONA, Me.cboVIGENCIA1.SelectedValue)

                            ' verica que la tabla esta llena
                            If dtFichaPredialxZonaEconomica.Rows.Count > 0 Then

                                ' declara la variable
                                Dim h As Integer = 0

                                For h = 0 To dtFichaPredialxZonaEconomica.Rows.Count - 1

                                    ' declara la variable
                                    Dim inNroFicha As Integer = CInt(dtFichaPredialxZonaEconomica.Rows(h).Item("HizoNufi"))
                                    Dim inVigencia As Integer = CInt(dtFichaPredialxZonaEconomica.Rows(h).Item("HizoVige"))
                                    Dim inPorcentaje As Integer = CInt(dtFichaPredialxZonaEconomica.Rows(h).Item("HizoPorc"))

                                    ' inicializa la instancia
                                    Dim obAFORSUIM As New cla_AFORSUIM
                                    Dim tbAFORSUIM As New DataTable

                                    tbAFORSUIM = obAFORSUIM.fun_Buscar_CODIGO_NUFI_VIGE_X_AFORSUIM(inNroFicha, inVigencia)

                                    If tbAFORSUIM.Rows.Count > 0 Then
                                        loImpuestoPredial += ((CLng(tbAFORSUIM.Rows(0).Item("AFSIVALI")) * inPorcentaje) / 100)
                                    End If

                                Next

                            End If

                            doTotalPorcentaje1 += fun_Formato_Decimal_2_Decimales(((inCANTIDAD * 100) / inTotalRegistros1))

                            ' Inserta el registro en el DataTable
                            dr1 = dt1.NewRow()

                            dr1("Zona") = inZONA
                            dr1("Descripcion") = stDESCRIPCION
                            dr1("Cantidad") = inCANTIDAD
                            dr1("Predial") = loImpuestoPredial
                            dr1("Porcentaje(%)") = fun_Formato_Decimal_2_Decimales(((inCANTIDAD * 100) / inTotalRegistros1))

                            dt1.Rows.Add(dr1)

                        Next

                        '*** RECORRE LA CONSULTA 2 ***

                        ' declara la variable y la recorre
                        Dim j2 As Integer = 0

                        For j2 = 0 To dtConsulta2.Rows.Count - 1

                            ' declara las variables
                            Dim inZONA As Integer = CInt(dtConsulta2.Rows(j2).Item("HizoZoec"))
                            Dim stDESCRIPCION As String = CStr(dtConsulta2.Rows(j2).Item("ZoecDesc"))
                            Dim inCANTIDAD As Integer = CInt(dtConsulta2.Rows(j2).Item("HizoCant"))

                            ' declara la variable
                            Dim loImpuestoPredial As Long = 0

                            ' limpia la variable
                            dtFichaPredialxZonaEconomica = New DataTable

                            ' llena la variable
                            dtFichaPredialxZonaEconomica = fun_ConsultarFichaPredialPorZonaEconomica(inZONA, Me.cboVIGENCIA2.SelectedValue)

                            ' verica que la tabla esta llena
                            If dtFichaPredialxZonaEconomica.Rows.Count > 0 Then

                                ' declara la variable
                                Dim h As Integer = 0

                                For h = 0 To dtFichaPredialxZonaEconomica.Rows.Count - 1

                                    ' declara la variable
                                    Dim inNroFicha As Integer = CInt(dtFichaPredialxZonaEconomica.Rows(h).Item("HizoNufi"))
                                    Dim inVigencia As Integer = CInt(dtFichaPredialxZonaEconomica.Rows(h).Item("HizoVige"))
                                    Dim inPorcentaje As Integer = CInt(dtFichaPredialxZonaEconomica.Rows(h).Item("HizoPorc"))

                                    ' inicializa la instancia
                                    Dim obAFORSUIM As New cla_AFORSUIM
                                    Dim tbAFORSUIM As New DataTable

                                    tbAFORSUIM = obAFORSUIM.fun_Buscar_CODIGO_NUFI_VIGE_X_AFORSUIM(inNroFicha, inVigencia)

                                    If tbAFORSUIM.Rows.Count > 0 Then
                                        loImpuestoPredial += ((CLng(tbAFORSUIM.Rows(0).Item("AFSIVALI")) * inPorcentaje) / 100)
                                    End If

                                Next

                            End If

                            doTotalPorcentaje2 += fun_Formato_Decimal_2_Decimales(((inCANTIDAD * 100) / inTotalRegistros1))

                            ' Inserta el registro en el DataTable
                            dr2 = dt2.NewRow()

                            dr2("Zona") = inZONA
                            dr2("Descripcion") = stDESCRIPCION
                            dr2("Cantidad") = inCANTIDAD
                            dr2("Predial") = loImpuestoPredial
                            dr2("Porcentaje(%)") = fun_Formato_Decimal_2_Decimales(((inCANTIDAD * 100) / inTotalRegistros1))

                            dt2.Rows.Add(dr2)

                        Next

                        ' llena el el datagridview
                        Me.dgvESTADISTICO1.DataSource = dt1
                        Me.dgvESTADISTICO2.DataSource = dt2

                        ' formato de moneda
                        Me.dgvESTADISTICO1.Columns("Predial").DefaultCellStyle.Format = "c"
                        Me.dgvESTADISTICO2.Columns("Predial").DefaultCellStyle.Format = "c"

                        ' llena los totales
                        Me.lblTotalRegistros1.Text = CType(Me.dgvESTADISTICO1.RowCount, String)
                        Me.lblTotalCantidad1.Text = CType(inTotalRegistros1, String)
                        Me.lblTotalPorcentaje1.Text = CType(CInt(doTotalPorcentaje1), String)

                        Me.lblTotalRegistros2.Text = CType(Me.dgvESTADISTICO2.RowCount, String)
                        Me.lblTotalCantidad2.Text = CType(inTotalRegistros2, String)
                        Me.lblTotalPorcentaje2.Text = CType(CInt(doTotalPorcentaje2), String)

                        ' inserta la totalidad de registros
                        Me.strBARRESTA.Items(2).Text = "Registros : " & Me.dgvESTADISTICO1.RowCount + Me.dgvESTADISTICO2.RowCount

                    Else
                        mod_MENSAJE.Consulta_No_Encontro_Registros()
                        Me.strBARRESTA.Items(2).Text = "Registros : 0"

                        ' limpia el reporte
                        Me.dgvESTADISTICO1.DataSource = New DataTable
                        Me.lblTotalRegistros1.Text = "0"

                        Me.dgvESTADISTICO2.DataSource = New DataTable
                        Me.lblTotalRegistros2.Text = "0"

                    End If

                End If

                Me.cmdGENERAR.Enabled = True
                Me.cmdGENERAR.Focus()

                mod_MENSAJE.Proceso_Termino_Correctamente()


            Catch ex As Exception
                MessageBox.Show(Err.Description)
                Me.cmdGENERAR.Enabled = True
            End Try
        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try
    End Sub
    Private Sub pro_Reporte_de_impuestos_por_barrio_o_vereda()
        Try
            Dim objVerifica As New cla_Verificar_Dato

            ' validad delo datos
            Dim boVIGENCIA1 As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboVIGENCIA1)
            Dim boVIGENCIA2 As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboVIGENCIA2)
            Dim boSECTOR As Boolean = objVerifica.fun_Verificar_Dato_Numerico(Me.txtFIPRCLSE.Text)

            If boSECTOR = False Then
                mod_MENSAJE.Se_Requiere_Seleccionar_Un_Sector()
            End If

            ' verifica los datos
            If boVIGENCIA1 = True And boVIGENCIA2 = True And boSECTOR = True Then

                Me.cmdGENERAR.Enabled = False

                ' declara la tabla
                dtConsulta1 = New DataTable
                dtConsulta2 = New DataTable

                ' llena la tabla
                dtConsulta1 = fun_ConsultarFichaPredialPorCedulaCatastral(Me.txtFIPRCLSE.Text)
                dtConsulta2 = fun_ConsultarFichaPredialPorCedulaCatastral(Me.txtFIPRCLSE.Text)

                ' realiza la insercion mediante la consulta
                If dtConsulta1.Rows.Count > 0 And dtConsulta2.Rows.Count > 0 Then

                    ' Crea objeto de columnas y registros
                    Dim dt1 As New DataTable
                    Dim dr1 As DataRow

                    Dim dt2 As New DataTable
                    Dim dr2 As DataRow

                    ' Crea las columnas
                    dt1.Columns.Add(New DataColumn("Barrio_Vereda", GetType(Integer)))
                    dt1.Columns.Add(New DataColumn("Descripcion", GetType(String)))
                    dt1.Columns.Add(New DataColumn("Cantidad", GetType(Integer)))
                    dt1.Columns.Add(New DataColumn("Predial", GetType(Long)))
                    dt1.Columns.Add(New DataColumn("Porcentaje(%)", GetType(Double)))

                    dt2.Columns.Add(New DataColumn("Barrio_Vereda", GetType(Integer)))
                    dt2.Columns.Add(New DataColumn("Descripcion", GetType(String)))
                    dt2.Columns.Add(New DataColumn("Cantidad", GetType(Integer)))
                    dt2.Columns.Add(New DataColumn("Predial", GetType(Long)))
                    dt2.Columns.Add(New DataColumn("Porcentaje(%)", GetType(Double)))

                    ' suma la totalidad de los registros encontrados
                    Dim inTotalRegistros1 As Integer = 0
                    Dim doTotalPorcentaje1 As Double = 0

                    Dim inTotalRegistros2 As Integer = 0
                    Dim doTotalPorcentaje2 As Double = 0

                    Dim i1 As Integer = 0
                    Dim i2 As Integer = 0

                    For i1 = 0 To dtConsulta1.Rows.Count - 1
                        inTotalRegistros1 += CType(dtConsulta1.Rows(i1).Item("SuimCant"), Integer)
                    Next

                    For i2 = 0 To dtConsulta2.Rows.Count - 1
                        inTotalRegistros2 += CType(dtConsulta1.Rows(i2).Item("SuimCant"), Integer)
                    Next

                    ' declara la variable
                    Dim dtFichaPredialxCedulaCatastral As New DataTable

                    '*** RECORRE LA CONSULTA 1 ***

                    ' declara la variable y la recorre
                    Dim j1 As Integer = 0

                    For j1 = 0 To dtConsulta1.Rows.Count - 1

                        ' declara las variables
                        Dim stBARRIO_VEREDA As String = ""
                        Dim stDESCRIPCION As String = CStr(dtConsulta1.Rows(j1).Item("BaveDesc"))
                        Dim inCANTIDAD As Integer = CInt(dtConsulta1.Rows(j1).Item("SuimCant"))

                        If Me.txtFIPRCLSE.Text = 1 Then
                            stBARRIO_VEREDA = CStr(Trim(dtConsulta1.Rows(j1).Item("SuimBarr")))
                        ElseIf Me.txtFIPRCLSE.Text = 2 Then
                            stBARRIO_VEREDA = CStr(Trim(dtConsulta1.Rows(j1).Item("SuimManz")))
                        End If

                        ' declara la variable
                        Dim loImpuestoPredial As Long = 0

                        ' limpia la variable
                        dtFichaPredialxCedulaCatastral = New DataTable

                        ' llena la variable
                        dtFichaPredialxCedulaCatastral = fun_ConsultarFichaPredialPorCedulaCatastral(stBARRIO_VEREDA, Me.txtFIPRCLSE.Text)

                        ' verica que la tabla esta llena
                        If dtFichaPredialxCedulaCatastral.Rows.Count > 0 Then

                            ' declara la variable
                            Dim h As Integer = 0

                            For h = 0 To dtFichaPredialxCedulaCatastral.Rows.Count - 1

                                ' declara la variable
                                Dim inNroFicha As Integer = CInt(dtFichaPredialxCedulaCatastral.Rows(h).Item("SuimNufi"))

                                ' inicializa la instancia
                                Dim obAFORSUIM As New cla_AFORSUIM
                                Dim tbAFORSUIM As New DataTable

                                tbAFORSUIM = obAFORSUIM.fun_Buscar_CODIGO_NUFI_VIGE_X_AFORSUIM(inNroFicha, Me.cboVIGENCIA1.SelectedValue)

                                If tbAFORSUIM.Rows.Count > 0 Then
                                    loImpuestoPredial += CLng(tbAFORSUIM.Rows(0).Item("AFSIVALI"))
                                End If

                            Next

                        End If

                        doTotalPorcentaje1 += fun_Formato_Decimal_2_Decimales(((inCANTIDAD * 100) / inTotalRegistros1))

                        ' Inserta el registro en el DataTable
                        dr1 = dt1.NewRow()

                        dr1("Barrio_Vereda") = stBARRIO_VEREDA
                        dr1("Descripcion") = stDESCRIPCION
                        dr1("Cantidad") = inCANTIDAD
                        dr1("Predial") = loImpuestoPredial
                        dr1("Porcentaje(%)") = fun_Formato_Decimal_2_Decimales(((inCANTIDAD * 100) / inTotalRegistros1))

                        dt1.Rows.Add(dr1)

                    Next

                    '*** RECORRE LA CONSULTA 2 ***

                    ' declara la variable y la recorre
                    Dim j2 As Integer = 0

                    For j2 = 0 To dtConsulta2.Rows.Count - 1

                        ' declara las variables
                        Dim stBARRIO_VEREDA As String = ""
                        Dim stDESCRIPCION As String = CStr(dtConsulta1.Rows(j2).Item("BaveDesc"))
                        Dim inCANTIDAD As Integer = CInt(dtConsulta1.Rows(j2).Item("SuimCant"))

                        If Me.txtFIPRCLSE.Text = 1 Then
                            stBARRIO_VEREDA = CStr(Trim(dtConsulta1.Rows(j2).Item("SuimBarr")))
                        ElseIf Me.txtFIPRCLSE.Text = 2 Then
                            stBARRIO_VEREDA = CStr(Trim(dtConsulta1.Rows(j2).Item("SuimManz")))
                        End If

                        ' declara la variable
                        Dim loImpuestoPredial As Long = 0

                        ' limpia la variable
                        dtFichaPredialxCedulaCatastral = New DataTable

                        ' llena la variable
                        dtFichaPredialxCedulaCatastral = fun_ConsultarFichaPredialPorCedulaCatastral(stBARRIO_VEREDA, Me.txtFIPRCLSE.Text)

                        ' verica que la tabla esta llena
                        If dtFichaPredialxCedulaCatastral.Rows.Count > 0 Then

                            ' declara la variable
                            Dim h As Integer = 0

                            For h = 0 To dtFichaPredialxCedulaCatastral.Rows.Count - 1

                                ' declara la variable
                                Dim inNroFicha As Integer = CInt(dtFichaPredialxCedulaCatastral.Rows(h).Item("SuimNufi"))

                                ' inicializa la instancia
                                Dim obAFORSUIM As New cla_AFORSUIM
                                Dim tbAFORSUIM As New DataTable

                                tbAFORSUIM = obAFORSUIM.fun_Buscar_CODIGO_NUFI_VIGE_X_AFORSUIM(inNroFicha, Me.cboVIGENCIA2.SelectedValue)

                                If tbAFORSUIM.Rows.Count > 0 Then
                                    loImpuestoPredial += CLng(tbAFORSUIM.Rows(0).Item("AFSIVALI"))
                                End If

                            Next

                        End If

                        doTotalPorcentaje2 += fun_Formato_Decimal_2_Decimales(((inCANTIDAD * 100) / inTotalRegistros1))

                        ' Inserta el registro en el DataTable
                        dr2 = dt2.NewRow()

                        dr2("Barrio_Vereda") = stBARRIO_VEREDA
                        dr2("Descripcion") = stDESCRIPCION
                        dr2("Cantidad") = inCANTIDAD
                        dr2("Predial") = loImpuestoPredial
                        dr2("Porcentaje(%)") = fun_Formato_Decimal_2_Decimales(((inCANTIDAD * 100) / inTotalRegistros1))

                        dt2.Rows.Add(dr2)

                    Next

                    ' llena el el datagridview
                    Me.dgvESTADISTICO1.DataSource = dt1
                    Me.dgvESTADISTICO2.DataSource = dt2

                    ' formato de moneda
                    Me.dgvESTADISTICO1.Columns("Predial").DefaultCellStyle.Format = "c"
                    Me.dgvESTADISTICO2.Columns("Predial").DefaultCellStyle.Format = "c"

                    ' llena los totales
                    Me.lblTotalRegistros1.Text = CType(Me.dgvESTADISTICO1.RowCount, String)
                    Me.lblTotalCantidad1.Text = CType(inTotalRegistros1, String)
                    Me.lblTotalPorcentaje1.Text = CType(CInt(doTotalPorcentaje1), String)

                    Me.lblTotalRegistros2.Text = CType(Me.dgvESTADISTICO2.RowCount, String)
                    Me.lblTotalCantidad2.Text = CType(inTotalRegistros2, String)
                    Me.lblTotalPorcentaje2.Text = CType(CInt(doTotalPorcentaje2), String)

                    ' inserta la totalidad de registros
                    Me.strBARRESTA.Items(2).Text = "Registros : " & Me.dgvESTADISTICO1.RowCount + Me.dgvESTADISTICO2.RowCount

                Else
                    mod_MENSAJE.Consulta_No_Encontro_Registros()
                    Me.strBARRESTA.Items(2).Text = "Registros : 0"

                    ' limpia el reporte
                    Me.dgvESTADISTICO1.DataSource = New DataTable
                    Me.lblTotalRegistros1.Text = "0"

                    Me.dgvESTADISTICO2.DataSource = New DataTable
                    Me.lblTotalRegistros2.Text = "0"

                End If

            End If

            Me.cmdGENERAR.Enabled = True
            Me.cmdGENERAR.Focus()

            mod_MENSAJE.Proceso_Termino_Correctamente()


        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try
    End Sub
    Private Sub pro_Reporte_de_impuesto_por_estrato()

        Try
            Dim objVerifica As New cla_Verificar_Dato

            ' validad delo datos
            Dim boVIGENCIA1 As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboVIGENCIA1)
            Dim boVIGENCIA2 As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboVIGENCIA2)

            ' verifica los datos
            If boVIGENCIA1 = True And boVIGENCIA2 = True Then

                Me.cmdGENERAR.Enabled = False

                ' declara la tabla
                dtConsulta1 = New DataTable
                dtConsulta2 = New DataTable

                ' llena la tabla
                dtConsulta1 = fun_ConsultarFichaPredialPorEstrato(Me.cboVIGENCIA1.SelectedValue)
                dtConsulta2 = fun_ConsultarFichaPredialPorEstrato(Me.cboVIGENCIA2.SelectedValue)

                ' realiza la insercion mediante la consulta
                If dtConsulta1.Rows.Count > 0 And dtConsulta2.Rows.Count > 0 Then

                    ' Crea objeto de columnas y registros
                    Dim dt1 As New DataTable
                    Dim dr1 As DataRow

                    Dim dt2 As New DataTable
                    Dim dr2 As DataRow

                    ' Crea las columnas
                    dt1.Columns.Add(New DataColumn("Estrato", GetType(Integer)))
                    dt1.Columns.Add(New DataColumn("Descripcion", GetType(String)))
                    dt1.Columns.Add(New DataColumn("Cantidad", GetType(Integer)))
                    dt1.Columns.Add(New DataColumn("Predial", GetType(Long)))
                    dt1.Columns.Add(New DataColumn("Porcentaje(%)", GetType(Double)))

                    dt2.Columns.Add(New DataColumn("Estrato", GetType(Integer)))
                    dt2.Columns.Add(New DataColumn("Descripcion", GetType(String)))
                    dt2.Columns.Add(New DataColumn("Cantidad", GetType(Integer)))
                    dt2.Columns.Add(New DataColumn("Predial", GetType(Long)))
                    dt2.Columns.Add(New DataColumn("Porcentaje(%)", GetType(Double)))

                    ' suma la totalidad de los registros encontrados
                    Dim inTotalRegistros1 As Integer = 0
                    Dim doTotalPorcentaje1 As Double = 0

                    Dim inTotalRegistros2 As Integer = 0
                    Dim doTotalPorcentaje2 As Double = 0

                    Dim i1 As Integer = 0
                    Dim i2 As Integer = 0

                    For i1 = 0 To dtConsulta1.Rows.Count - 1
                        inTotalRegistros1 += CType(dtConsulta1.Rows(i1).Item("HiliCant"), Integer)
                    Next

                    For i2 = 0 To dtConsulta2.Rows.Count - 1
                        inTotalRegistros2 += CType(dtConsulta1.Rows(i2).Item("HiliCant"), Integer)
                    Next

                    ' declara la variable
                    Dim dtFichaPredialxEstrato As New DataTable

                    '*** RECORRE LA CONSULTA 1 ***

                    ' declara la variable y la recorre
                    Dim j1 As Integer = 0

                    For j1 = 0 To dtConsulta1.Rows.Count - 1

                        ' declara las variables
                        Dim inESTRATO As Integer = CInt(dtConsulta1.Rows(j1).Item("HiliEstr"))
                        Dim stDESCRIPCION As String = CStr(dtConsulta1.Rows(j1).Item("EstrDesc"))
                        Dim inCANTIDAD As Integer = CInt(dtConsulta1.Rows(j1).Item("HiliCant"))

                        ' declara la variable
                        Dim loImpuestoPredial As Long = 0

                        ' limpia la variable
                        dtFichaPredialxEstrato = New DataTable

                        ' llena la variable
                        dtFichaPredialxEstrato = fun_ConsultarFichaPredialPorEstrato(inESTRATO, Me.cboVIGENCIA1.SelectedValue)

                        ' verica que la tabla esta llena
                        If dtFichaPredialxEstrato.Rows.Count > 0 Then

                            ' declara la variable
                            Dim h As Integer = 0

                            For h = 0 To dtFichaPredialxEstrato.Rows.Count - 1

                                ' declara la variable
                                Dim inNroFicha As Integer = CInt(dtFichaPredialxEstrato.Rows(h).Item("HiliNufi"))
                                Dim inVigencia As Integer = CInt(dtFichaPredialxEstrato.Rows(h).Item("HiliVige"))

                                ' inicializa la instancia
                                Dim obAFORSUIM As New cla_AFORSUIM
                                Dim tbAFORSUIM As New DataTable

                                tbAFORSUIM = obAFORSUIM.fun_Buscar_CODIGO_NUFI_VIGE_X_AFORSUIM(inNroFicha, inVigencia)

                                If tbAFORSUIM.Rows.Count > 0 Then
                                    loImpuestoPredial += CLng(tbAFORSUIM.Rows(0).Item("AFSIVALI"))
                                End If

                            Next

                        End If

                        doTotalPorcentaje1 += fun_Formato_Decimal_2_Decimales(((inCANTIDAD * 100) / inTotalRegistros1))

                        ' Inserta el registro en el DataTable
                        dr1 = dt1.NewRow()

                        dr1("Estrato") = inESTRATO
                        dr1("Descripcion") = stDESCRIPCION
                        dr1("Cantidad") = inCANTIDAD
                        dr1("Predial") = loImpuestoPredial
                        dr1("Porcentaje(%)") = fun_Formato_Decimal_2_Decimales(((inCANTIDAD * 100) / inTotalRegistros1))

                        dt1.Rows.Add(dr1)

                    Next

                    '*** RECORRE LA CONSULTA 2 ***

                    ' declara la variable y la recorre
                    Dim j2 As Integer = 0

                    For j2 = 0 To dtConsulta2.Rows.Count - 1

                        ' declara las variables
                        Dim inESTRATO As Integer = CInt(dtConsulta2.Rows(j2).Item("HiliEstr"))
                        Dim stDESCRIPCION As String = CStr(dtConsulta2.Rows(j2).Item("EstrDesc"))
                        Dim inCANTIDAD As Integer = CInt(dtConsulta2.Rows(j2).Item("HiliCant"))

                        ' declara la variable
                        Dim loImpuestoPredial As Long = 0

                        ' limpia la variable
                        dtFichaPredialxEstrato = New DataTable

                        ' llena la variable
                        dtFichaPredialxEstrato = fun_ConsultarFichaPredialPorEstrato(inESTRATO, Me.cboVIGENCIA2.SelectedValue)

                        ' verica que la tabla esta llena
                        If dtFichaPredialxEstrato.Rows.Count > 0 Then

                            ' declara la variable
                            Dim h As Integer = 0

                            For h = 0 To dtFichaPredialxEstrato.Rows.Count - 1

                                ' declara la variable
                                Dim inNroFicha As Integer = CInt(dtFichaPredialxEstrato.Rows(h).Item("HiliNufi"))
                                Dim inVigencia As Integer = CInt(dtFichaPredialxEstrato.Rows(h).Item("HiliVige"))

                                ' inicializa la instancia
                                Dim obAFORSUIM As New cla_AFORSUIM
                                Dim tbAFORSUIM As New DataTable

                                tbAFORSUIM = obAFORSUIM.fun_Buscar_CODIGO_NUFI_VIGE_X_AFORSUIM(inNroFicha, inVigencia)

                                If tbAFORSUIM.Rows.Count > 0 Then
                                    loImpuestoPredial += CLng(tbAFORSUIM.Rows(0).Item("AFSIVALI"))
                                End If

                            Next

                        End If

                        doTotalPorcentaje2 += fun_Formato_Decimal_2_Decimales(((inCANTIDAD * 100) / inTotalRegistros1))

                        ' Inserta el registro en el DataTable
                        dr2 = dt2.NewRow()

                        dr2("Estrato") = inESTRATO
                        dr2("Descripcion") = stDESCRIPCION
                        dr2("Cantidad") = inCANTIDAD
                        dr2("Predial") = loImpuestoPredial
                        dr2("Porcentaje(%)") = fun_Formato_Decimal_2_Decimales(((inCANTIDAD * 100) / inTotalRegistros1))

                        dt2.Rows.Add(dr2)

                    Next

                    ' llena el el datagridview
                    Me.dgvESTADISTICO1.DataSource = dt1
                    Me.dgvESTADISTICO2.DataSource = dt2

                    ' formato de moneda
                    Me.dgvESTADISTICO1.Columns("Predial").DefaultCellStyle.Format = "c"
                    Me.dgvESTADISTICO2.Columns("Predial").DefaultCellStyle.Format = "c"

                    ' llena los totales
                    Me.lblTotalRegistros1.Text = CType(Me.dgvESTADISTICO1.RowCount, String)
                    Me.lblTotalCantidad1.Text = CType(inTotalRegistros1, String)
                    Me.lblTotalPorcentaje1.Text = CType(CInt(doTotalPorcentaje1), String)

                    Me.lblTotalRegistros2.Text = CType(Me.dgvESTADISTICO2.RowCount, String)
                    Me.lblTotalCantidad2.Text = CType(inTotalRegistros2, String)
                    Me.lblTotalPorcentaje2.Text = CType(CInt(doTotalPorcentaje2), String)

                    ' inserta la totalidad de registros
                    Me.strBARRESTA.Items(2).Text = "Registros : " & Me.dgvESTADISTICO1.RowCount + Me.dgvESTADISTICO2.RowCount

                Else
                    mod_MENSAJE.Consulta_No_Encontro_Registros()
                    Me.strBARRESTA.Items(2).Text = "Registros : 0"

                    ' limpia el reporte
                    Me.dgvESTADISTICO1.DataSource = New DataTable
                    Me.lblTotalRegistros1.Text = "0"

                    Me.dgvESTADISTICO2.DataSource = New DataTable
                    Me.lblTotalRegistros2.Text = "0"

                End If

            End If

            Me.cmdGENERAR.Enabled = True
            Me.cmdGENERAR.Focus()

            mod_MENSAJE.Proceso_Termino_Correctamente()


        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try
    End Sub
    Private Sub pro_Reporte_de_impuesto_por_tipo_de_calificacion()

        Try
            Dim objVerifica As New cla_Verificar_Dato

            ' validad delo datos
            Dim boVIGENCIA1 As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboVIGENCIA1)
            Dim boVIGENCIA2 As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboVIGENCIA2)

            ' verifica los datos
            If boVIGENCIA1 = True And boVIGENCIA2 = True Then

                Me.cmdGENERAR.Enabled = False

                ' declara la tabla
                dtConsulta1 = New DataTable
                dtConsulta2 = New DataTable

                ' llena la tabla
                dtConsulta1 = fun_ConsultarFichaPredialPorTipoDeCalificacion(Me.cboVIGENCIA1.SelectedValue)
                dtConsulta2 = fun_ConsultarFichaPredialPorTipoDeCalificacion(Me.cboVIGENCIA2.SelectedValue)

                ' realiza la insercion mediante la consulta
                If dtConsulta1.Rows.Count > 0 And dtConsulta2.Rows.Count > 0 Then

                    ' Crea objeto de columnas y registros
                    Dim dt1 As New DataTable
                    Dim dr1 As DataRow

                    Dim dt2 As New DataTable
                    Dim dr2 As DataRow

                    ' Crea las columnas
                    dt1.Columns.Add(New DataColumn("Tipo", GetType(String)))
                    dt1.Columns.Add(New DataColumn("Descripcion", GetType(String)))
                    dt1.Columns.Add(New DataColumn("Cantidad", GetType(Integer)))
                    dt1.Columns.Add(New DataColumn("Predial", GetType(Long)))
                    dt1.Columns.Add(New DataColumn("Porcentaje(%)", GetType(Double)))

                    dt2.Columns.Add(New DataColumn("Tipo", GetType(String)))
                    dt2.Columns.Add(New DataColumn("Descripcion", GetType(String)))
                    dt2.Columns.Add(New DataColumn("Cantidad", GetType(Integer)))
                    dt2.Columns.Add(New DataColumn("Predial", GetType(Long)))
                    dt2.Columns.Add(New DataColumn("Porcentaje(%)", GetType(Double)))

                    ' suma la totalidad de los registros encontrados
                    Dim inTotalRegistros1 As Integer = 0
                    Dim doTotalPorcentaje1 As Double = 0

                    Dim inTotalRegistros2 As Integer = 0
                    Dim doTotalPorcentaje2 As Double = 0

                    Dim i1 As Integer = 0
                    Dim i2 As Integer = 0

                    For i1 = 0 To dtConsulta1.Rows.Count - 1
                        inTotalRegistros1 += CType(dtConsulta1.Rows(i1).Item("HiliCant"), Integer)
                    Next

                    For i2 = 0 To dtConsulta2.Rows.Count - 1
                        inTotalRegistros2 += CType(dtConsulta1.Rows(i2).Item("HiliCant"), Integer)
                    Next

                    ' declara la variable
                    Dim dtFichaPredialxTipoCalificacion As New DataTable

                    '*** RECORRE LA CONSULTA 1 ***

                    ' declara la variable y la recorre
                    Dim j1 As Integer = 0

                    For j1 = 0 To dtConsulta1.Rows.Count - 1

                        ' declara las variables
                        Dim stTIPO As String = CStr(Trim(dtConsulta1.Rows(j1).Item("HiliTipo")))
                        Dim stDESCRIPCION As String = CStr(dtConsulta1.Rows(j1).Item("TicaDesc"))
                        Dim inCANTIDAD As Integer = CInt(dtConsulta1.Rows(j1).Item("HiliCant"))

                        ' declara la variable
                        Dim loImpuestoPredial As Long = 0

                        ' limpia la variable
                        dtFichaPredialxTipoCalificacion = New DataTable

                        ' llena la variable
                        dtFichaPredialxTipoCalificacion = fun_ConsultarFichaPredialPorTipoDeCalificacion(stTIPO, Me.cboVIGENCIA1.SelectedValue)

                        ' verica que la tabla esta llena
                        If dtFichaPredialxTipoCalificacion.Rows.Count > 0 Then

                            ' declara la variable
                            Dim h As Integer = 0

                            For h = 0 To dtFichaPredialxTipoCalificacion.Rows.Count - 1

                                ' declara la variable
                                Dim inNroFicha As Integer = CInt(dtFichaPredialxTipoCalificacion.Rows(h).Item("HiliNufi"))
                                Dim inVigencia As Integer = CInt(dtFichaPredialxTipoCalificacion.Rows(h).Item("HiliVige"))

                                ' inicializa la instancia
                                Dim obAFORSUIM As New cla_AFORSUIM
                                Dim tbAFORSUIM As New DataTable

                                tbAFORSUIM = obAFORSUIM.fun_Buscar_CODIGO_NUFI_VIGE_X_AFORSUIM(inNroFicha, inVigencia)

                                If tbAFORSUIM.Rows.Count > 0 Then
                                    loImpuestoPredial += CLng(tbAFORSUIM.Rows(0).Item("AFSIVALI"))
                                End If

                            Next

                        End If

                        doTotalPorcentaje1 += fun_Formato_Decimal_2_Decimales(((inCANTIDAD * 100) / inTotalRegistros1))

                        ' Inserta el registro en el DataTable
                        dr1 = dt1.NewRow()

                        dr1("Tipo") = stTIPO
                        dr1("Descripcion") = stDESCRIPCION
                        dr1("Cantidad") = inCANTIDAD
                        dr1("Predial") = loImpuestoPredial
                        dr1("Porcentaje(%)") = fun_Formato_Decimal_2_Decimales(((inCANTIDAD * 100) / inTotalRegistros1))

                        dt1.Rows.Add(dr1)

                    Next

                    '*** RECORRE LA CONSULTA 2 ***

                    ' declara la variable y la recorre
                    Dim j2 As Integer = 0

                    For j2 = 0 To dtConsulta2.Rows.Count - 1

                        ' declara las variables
                        Dim stTIPO As String = CStr(Trim(dtConsulta2.Rows(j2).Item("HiliTipo")))
                        Dim stDESCRIPCION As String = CStr(dtConsulta2.Rows(j2).Item("TicaDesc"))
                        Dim inCANTIDAD As Integer = CInt(dtConsulta2.Rows(j2).Item("HiliCant"))

                        ' declara la variable
                        Dim loImpuestoPredial As Long = 0

                        ' limpia la variable
                        dtFichaPredialxTipoCalificacion = New DataTable

                        ' llena la variable
                        dtFichaPredialxTipoCalificacion = fun_ConsultarFichaPredialPorTipoDeCalificacion(stTIPO, Me.cboVIGENCIA2.SelectedValue)

                        ' verica que la tabla esta llena
                        If dtFichaPredialxTipoCalificacion.Rows.Count > 0 Then

                            ' declara la variable
                            Dim h As Integer = 0

                            For h = 0 To dtFichaPredialxTipoCalificacion.Rows.Count - 1

                                ' declara la variable
                                Dim inNroFicha As Integer = CInt(dtFichaPredialxTipoCalificacion.Rows(h).Item("HiliNufi"))
                                Dim inVigencia As Integer = CInt(dtFichaPredialxTipoCalificacion.Rows(h).Item("HiliVige"))

                                ' inicializa la instancia
                                Dim obAFORSUIM As New cla_AFORSUIM
                                Dim tbAFORSUIM As New DataTable

                                tbAFORSUIM = obAFORSUIM.fun_Buscar_CODIGO_NUFI_VIGE_X_AFORSUIM(inNroFicha, inVigencia)

                                If tbAFORSUIM.Rows.Count > 0 Then
                                    loImpuestoPredial += CLng(tbAFORSUIM.Rows(0).Item("AFSIVALI"))
                                End If

                            Next

                        End If

                        doTotalPorcentaje2 += fun_Formato_Decimal_2_Decimales(((inCANTIDAD * 100) / inTotalRegistros1))

                        ' Inserta el registro en el DataTable
                        dr2 = dt2.NewRow()

                        dr2("Tipo") = stTIPO
                        dr2("Descripcion") = stDESCRIPCION
                        dr2("Cantidad") = inCANTIDAD
                        dr2("Predial") = loImpuestoPredial
                        dr2("Porcentaje(%)") = fun_Formato_Decimal_2_Decimales(((inCANTIDAD * 100) / inTotalRegistros1))

                        dt2.Rows.Add(dr2)

                    Next

                    ' llena el el datagridview
                    Me.dgvESTADISTICO1.DataSource = dt1
                    Me.dgvESTADISTICO2.DataSource = dt2

                    ' formato de moneda
                    Me.dgvESTADISTICO1.Columns("Predial").DefaultCellStyle.Format = "c"
                    Me.dgvESTADISTICO2.Columns("Predial").DefaultCellStyle.Format = "c"

                    ' llena los totales
                    Me.lblTotalRegistros1.Text = CType(Me.dgvESTADISTICO1.RowCount, String)
                    Me.lblTotalCantidad1.Text = CType(inTotalRegistros1, String)
                    Me.lblTotalPorcentaje1.Text = CType(CInt(doTotalPorcentaje1), String)

                    Me.lblTotalRegistros2.Text = CType(Me.dgvESTADISTICO2.RowCount, String)
                    Me.lblTotalCantidad2.Text = CType(inTotalRegistros2, String)
                    Me.lblTotalPorcentaje2.Text = CType(CInt(doTotalPorcentaje2), String)

                    ' inserta la totalidad de registros
                    Me.strBARRESTA.Items(2).Text = "Registros : " & Me.dgvESTADISTICO1.RowCount + Me.dgvESTADISTICO2.RowCount

                Else
                    mod_MENSAJE.Consulta_No_Encontro_Registros()
                    Me.strBARRESTA.Items(2).Text = "Registros : 0"

                    ' limpia el reporte
                    Me.dgvESTADISTICO1.DataSource = New DataTable
                    Me.lblTotalRegistros1.Text = "0"

                    Me.dgvESTADISTICO2.DataSource = New DataTable
                    Me.lblTotalRegistros2.Text = "0"

                End If

            End If

            Me.cmdGENERAR.Enabled = True
            Me.cmdGENERAR.Focus()

            mod_MENSAJE.Proceso_Termino_Correctamente()

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try
    End Sub
    Private Sub pro_Reporte_de_impuesto_por_destinacion_economica()
        Try
            Dim objVerifica As New cla_Verificar_Dato

            ' validad delo datos
            Dim boVIGENCIA1 As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboVIGENCIA1)
            Dim boVIGENCIA2 As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboVIGENCIA2)

            ' verifica los datos
            If boVIGENCIA1 = True And boVIGENCIA2 = True Then

                Me.cmdGENERAR.Enabled = False

                ' declara la tabla
                dtConsulta1 = New DataTable
                dtConsulta2 = New DataTable

                ' llena la tabla
                dtConsulta1 = fun_ConsultarFichaPredialPorDestinoEconomico(Me.cboVIGENCIA1.SelectedValue)
                dtConsulta2 = fun_ConsultarFichaPredialPorDestinoEconomico(Me.cboVIGENCIA2.SelectedValue)

                ' realiza la insercion mediante la consulta
                If dtConsulta1.Rows.Count > 0 And dtConsulta2.Rows.Count > 0 Then

                    ' Crea objeto de columnas y registros
                    Dim dt1 As New DataTable
                    Dim dr1 As DataRow

                    Dim dt2 As New DataTable
                    Dim dr2 As DataRow

                    ' Crea las columnas
                    dt1.Columns.Add(New DataColumn("Destino", GetType(Integer)))
                    dt1.Columns.Add(New DataColumn("Descripcion", GetType(String)))
                    dt1.Columns.Add(New DataColumn("Cantidad", GetType(Integer)))
                    dt1.Columns.Add(New DataColumn("Predial", GetType(Long)))
                    dt1.Columns.Add(New DataColumn("Porcentaje(%)", GetType(Double)))

                    dt2.Columns.Add(New DataColumn("Destino", GetType(Integer)))
                    dt2.Columns.Add(New DataColumn("Descripcion", GetType(String)))
                    dt2.Columns.Add(New DataColumn("Cantidad", GetType(Integer)))
                    dt2.Columns.Add(New DataColumn("Predial", GetType(Long)))
                    dt2.Columns.Add(New DataColumn("Porcentaje(%)", GetType(Double)))

                    ' suma la totalidad de los registros encontrados
                    Dim inTotalRegistros1 As Integer = 0
                    Dim doTotalPorcentaje1 As Double = 0

                    Dim inTotalRegistros2 As Integer = 0
                    Dim doTotalPorcentaje2 As Double = 0

                    Dim i1 As Integer = 0
                    Dim i2 As Integer = 0

                    For i1 = 0 To dtConsulta1.Rows.Count - 1
                        inTotalRegistros1 += CType(dtConsulta1.Rows(i1).Item("HiliCant"), Integer)
                    Next

                    For i2 = 0 To dtConsulta2.Rows.Count - 1
                        inTotalRegistros2 += CType(dtConsulta1.Rows(i2).Item("HiliCant"), Integer)
                    Next

                    ' declara la variable
                    Dim dtFichaPredialxDestinoEconomico As New DataTable

                    '*** RECORRE LA CONSULTA 1 ***

                    ' declara la variable y la recorre
                    Dim j1 As Integer = 0

                    For j1 = 0 To dtConsulta1.Rows.Count - 1

                        ' declara las variables
                        Dim inDESTINO As Integer = CInt(dtConsulta1.Rows(j1).Item("HiliDeec"))
                        Dim stDESCRIPCION As String = CStr(dtConsulta1.Rows(j1).Item("DeecDesc"))
                        Dim inCANTIDAD As Integer = CInt(dtConsulta1.Rows(j1).Item("HiliCant"))

                        ' declara la variable
                        Dim loImpuestoPredial As Long = 0

                        ' limpia la variable
                        dtFichaPredialxDestinoEconomico = New DataTable

                        ' llena la variable
                        dtFichaPredialxDestinoEconomico = fun_ConsultarFichaPredialPorDestinoEconomico(inDESTINO, Me.cboVIGENCIA1.SelectedValue)

                        ' verica que la tabla esta llena
                        If dtFichaPredialxDestinoEconomico.Rows.Count > 0 Then

                            ' declara la variable
                            Dim h As Integer = 0

                            For h = 0 To dtFichaPredialxDestinoEconomico.Rows.Count - 1

                                ' declara la variable
                                Dim inNroFicha As Integer = CInt(dtFichaPredialxDestinoEconomico.Rows(h).Item("HiliNufi"))
                                Dim inVigencia As Integer = CInt(dtFichaPredialxDestinoEconomico.Rows(h).Item("HiliVige"))

                                ' inicializa la instancia
                                Dim obAFORSUIM As New cla_AFORSUIM
                                Dim tbAFORSUIM As New DataTable

                                tbAFORSUIM = obAFORSUIM.fun_Buscar_CODIGO_NUFI_VIGE_X_AFORSUIM(inNroFicha, inVigencia)

                                If tbAFORSUIM.Rows.Count > 0 Then
                                    loImpuestoPredial += CLng(tbAFORSUIM.Rows(0).Item("AFSIVALI"))
                                End If

                            Next

                        End If

                        doTotalPorcentaje1 += fun_Formato_Decimal_2_Decimales(((inCANTIDAD * 100) / inTotalRegistros1))

                        ' Inserta el registro en el DataTable
                        dr1 = dt1.NewRow()

                        dr1("Destino") = inDESTINO
                        dr1("Descripcion") = stDESCRIPCION
                        dr1("Cantidad") = inCANTIDAD
                        dr1("Predial") = loImpuestoPredial
                        dr1("Porcentaje(%)") = fun_Formato_Decimal_2_Decimales(((inCANTIDAD * 100) / inTotalRegistros1))

                        dt1.Rows.Add(dr1)

                    Next

                    '*** RECORRE LA CONSULTA 2 ***

                    ' declara la variable y la recorre
                    Dim j2 As Integer = 0

                    For j2 = 0 To dtConsulta2.Rows.Count - 1

                        ' declara las variables
                        Dim inDESTINO As Integer = CInt(dtConsulta2.Rows(j2).Item("HiliDeec"))
                        Dim stDESCRIPCION As String = CStr(dtConsulta2.Rows(j2).Item("DeecDesc"))
                        Dim inCANTIDAD As Integer = CInt(dtConsulta2.Rows(j2).Item("HiliCant"))

                        ' declara la variable
                        Dim loImpuestoPredial As Long = 0

                        ' limpia la variable
                        dtFichaPredialxDestinoEconomico = New DataTable

                        ' llena la variable
                        dtFichaPredialxDestinoEconomico = fun_ConsultarFichaPredialPorDestinoEconomico(inDESTINO, Me.cboVIGENCIA2.SelectedValue)

                        ' verica que la tabla esta llena
                        If dtFichaPredialxDestinoEconomico.Rows.Count > 0 Then

                            ' declara la variable
                            Dim h As Integer = 0

                            For h = 0 To dtFichaPredialxDestinoEconomico.Rows.Count - 1

                                ' declara la variable
                                Dim inNroFicha As Integer = CInt(dtFichaPredialxDestinoEconomico.Rows(h).Item("HiliNufi"))
                                Dim inVigencia As Integer = CInt(dtFichaPredialxDestinoEconomico.Rows(h).Item("HiliVige"))

                                ' inicializa la instancia
                                Dim obAFORSUIM As New cla_AFORSUIM
                                Dim tbAFORSUIM As New DataTable

                                tbAFORSUIM = obAFORSUIM.fun_Buscar_CODIGO_NUFI_VIGE_X_AFORSUIM(inNroFicha, inVigencia)

                                If tbAFORSUIM.Rows.Count > 0 Then
                                    loImpuestoPredial += CLng(tbAFORSUIM.Rows(0).Item("AFSIVALI"))
                                End If

                            Next

                        End If

                        doTotalPorcentaje2 += fun_Formato_Decimal_2_Decimales(((inCANTIDAD * 100) / inTotalRegistros1))

                        ' Inserta el registro en el DataTable
                        dr2 = dt2.NewRow()

                        dr2("Destino") = inDESTINO
                        dr2("Descripcion") = stDESCRIPCION
                        dr2("Cantidad") = inCANTIDAD
                        dr2("Predial") = loImpuestoPredial
                        dr2("Porcentaje(%)") = fun_Formato_Decimal_2_Decimales(((inCANTIDAD * 100) / inTotalRegistros1))

                        dt2.Rows.Add(dr2)

                    Next

                    ' llena el el datagridview
                    Me.dgvESTADISTICO1.DataSource = dt1
                    Me.dgvESTADISTICO2.DataSource = dt2

                    ' formato de moneda
                    Me.dgvESTADISTICO1.Columns("Predial").DefaultCellStyle.Format = "c"
                    Me.dgvESTADISTICO2.Columns("Predial").DefaultCellStyle.Format = "c"

                    ' llena los totales
                    Me.lblTotalRegistros1.Text = CType(Me.dgvESTADISTICO1.RowCount, String)
                    Me.lblTotalCantidad1.Text = CType(inTotalRegistros1, String)
                    Me.lblTotalPorcentaje1.Text = CType(CInt(doTotalPorcentaje1), String)

                    Me.lblTotalRegistros2.Text = CType(Me.dgvESTADISTICO2.RowCount, String)
                    Me.lblTotalCantidad2.Text = CType(inTotalRegistros2, String)
                    Me.lblTotalPorcentaje2.Text = CType(CInt(doTotalPorcentaje2), String)

                    ' inserta la totalidad de registros
                    Me.strBARRESTA.Items(2).Text = "Registros : " & Me.dgvESTADISTICO1.RowCount + Me.dgvESTADISTICO2.RowCount

                Else
                    mod_MENSAJE.Consulta_No_Encontro_Registros()
                    Me.strBARRESTA.Items(2).Text = "Registros : 0"

                    ' limpia el reporte
                    Me.dgvESTADISTICO1.DataSource = New DataTable
                    Me.lblTotalRegistros1.Text = "0"

                    Me.dgvESTADISTICO2.DataSource = New DataTable
                    Me.lblTotalRegistros2.Text = "0"

                End If

            End If

            Me.cmdGENERAR.Enabled = True
            Me.cmdGENERAR.Focus()

            mod_MENSAJE.Proceso_Termino_Correctamente()

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try
    End Sub

#End Region

#Region "MENU"

    Private Sub cmdGENERAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGENERAR.Click

        Try
            If cboTIPOREPO.SelectedIndex = 0 Then
                pro_Reporte_de_total_de_avaluos_por_vigencias()
            End If

            If cboTIPOREPO.SelectedIndex = 1 Then
                pro_Reporte_de_total_de_impuestos_por_vigencias()
            End If

            If cboTIPOREPO.SelectedIndex = 2 Then
                pro_Reporte_de_avaluo_por_zonas()
            End If

            If cboTIPOREPO.SelectedIndex = 3 Then
                pro_Reporte_de_avaluo_por_barrio_o_vereda()
            End If

            If cboTIPOREPO.SelectedIndex = 4 Then
                pro_Reporte_de_avaluo_por_estrato()
            End If

            If cboTIPOREPO.SelectedIndex = 5 Then
                pro_Reporte_de_avaluo_por_tipo_de_calificacion()
            End If

            If cboTIPOREPO.SelectedIndex = 6 Then
                pro_Reporte_de_avaluo_por_destinacion_economica()
            End If

            If cboTIPOREPO.SelectedIndex = 7 Then
                pro_Reporte_de_impuesto_por_zonas()
            End If

            If cboTIPOREPO.SelectedIndex = 8 Then
                pro_Reporte_de_impuestos_por_barrio_o_vereda()
            End If

            If cboTIPOREPO.SelectedIndex = 9 Then
                pro_Reporte_de_impuesto_por_estrato()
            End If

            If cboTIPOREPO.SelectedIndex = 10 Then
                pro_Reporte_de_impuesto_por_tipo_de_calificacion()
            End If

            If cboTIPOREPO.SelectedIndex = 11 Then
                pro_Reporte_de_impuesto_por_destinacion_economica()
            End If

            If Me.dgvESTADISTICO1.RowCount > 0 Or Me.dgvESTADISTICO2.RowCount > 0 Then
                Me.cmdGRAFICO.Enabled = True
            Else
                Me.cmdGRAFICO.Enabled = False
            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub cmdGrafico_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGRAFICO.Click

        Dim frm_Grafica As New frm_grafica_Estadistica_Ficha_Predial(CType(Me.dgvESTADISTICO1.DataSource, DataTable), Trim(Me.cboTIPOREPO.Text))
        frm_Grafica.ShowDialog()

    End Sub
    Private Sub cmdLIMPIAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdLIMPIAR.Click
        pro_LimpiarCampos()
        txtFIPRFIIN.Focus()

    End Sub
    Private Sub cmdIMPRIMIR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdIMPRIMIR.Click
        ' PrintDialog permite al usuario seleccionar la impresora en la que desea imprimir, 
        ' además de otras opciones de impresión.

        PrintDialog1.Document = PrintDocument1
        If PrintDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
            PrintDocument1.Print()
        End If

    End Sub
    Private Sub cmdSALIR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSALIR.Click
        pro_LimpiarCampos()
        txtFIPRFIIN.Focus()
        Me.Close()
    End Sub
    Private Sub btnPrintPreview_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrintPreview.Click
        ' PrintPreviewDialog está asociado a PrintDocument; cuando se procesa la 
        ' vista previa, se desencadena el evento PrintPage. A este evento se pasa un contexto 
        ' gráfico en el que se "dibuja" la página.

        Try
            PrintPreviewDialog1.Document = PrintDocument1
            PrintPreviewDialog1.ShowDialog()
        Catch exp As Exception
            MsgBox("An error occurred while trying to load the " & _
                "document for Print Preview. Make sure you currently have " & _
                "access to a printer. A printer must be connected and " & _
                "accessible for Print Preview to work.", MsgBoxStyle.OkOnly, _
                 Me.Text)
        End Try

    End Sub
    Private Sub btnPageSetup_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        ' La configuración de página permite especificar aspectos tales como el tamaño del papel, la orientación vertical, 
        ' horizontal, etc.

        With PageSetupDialog1
            .Document = PrintDocument1
            .PageSettings = PrintDocument1.DefaultPageSettings
        End With

        If PageSetupDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
            PrintDocument1.DefaultPageSettings = PageSetupDialog1.PageSettings
        End If

    End Sub
    Private Sub pdoc_PrintPage(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles PrintDocument1.PrintPage

    End Sub
    Private Sub cmdExportarExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExportarExcel.Click

        Try
            If Me.rbdESTADISTICO1.Checked = True Then
                If Me.dgvESTADISTICO1.RowCount = 0 Then
                    MessageBox.Show("No existe datos para exportar", "Mensaje ...", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1)
                Else
                    Dim oExp As New cla_ExportarTablaExcel
                    oExp.DataTableToExcel(CType(Me.dgvESTADISTICO1.DataSource, DataTable))
                End If
            ElseIf Me.rbdESTADISTICO2.Checked = True Then
                If Me.dgvESTADISTICO2.RowCount = 0 Then
                    MessageBox.Show("No existe datos para exportar", "Mensaje ...", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1)
                Else
                    Dim oExp As New cla_ExportarTablaExcel
                    oExp.DataTableToExcel(CType(Me.dgvESTADISTICO2.DataSource, DataTable))
                End If
            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub cmdExportarPlano_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExportarPlano.Click
        Try

            If dgvESTADISTICO1.RowCount > 0 Then

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

                    ' se carga el stSeparador
                    stSeparador = Trim(txtSEPARADOR.Text)

                    'Nuevo objeto StreamWriter, para acceder al fichero y poder guardar las líneas
                    Using archivo As StreamWriter = New StreamWriter(oCrear.FileName)

                        ' variable para almacenar la línea actual del dataview
                        Dim linea As String = String.Empty

                        With dgvESTADISTICO1
                            ' Recorrer las filas del dataGridView
                            For fila As Integer = 0 To .RowCount - 1
                                ' vaciar la línea
                                linea = String.Empty

                                ' Recorrer la cantidad de columnas que contiene el dataGridView
                                For col As Integer = 0 To .Columns.Count - 1
                                    ' Almacenar el valor de toda la fila , y cada campo separado por el delimitador
                                    linea = linea & Trim(.Item(col, fila).Value.ToString) & stSeparador
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
                    txtFIPRFIIN.Focus()
                End If
            Else
                MessageBox.Show("Ejecute la consulta antes de exportar el plano", "Mensaje ...", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            End If
        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try
    End Sub

#End Region

#Region "FORMULARIO"

#Region "Load"

    Private Sub frm_REPO_FIPRESTA_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cboTIPOREPO.SelectedIndex = 0
    End Sub

#End Region

#Region "KeyPress"

    Private Sub txtFIPRFIIN_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFIPRFIIN.KeyPress
        If Not Char.IsNumber(e.KeyChar) Then
            If e.KeyChar <> Convert.ToChar(Keys.Back) Then
                If e.KeyChar <> Convert.ToChar(37) Then
                    If e.KeyChar <> Convert.ToChar(Keys.Enter) Then
                        e.Handled = True
                        strBARRESTA.Items(1).Text = IncoValoNume
                        mod_MENSAJE.Inco_Valo_Nume()
                    Else
                        txtFIPRFIFI.Focus()
                    End If
                End If
            End If
        End If
    End Sub
    Private Sub txtFIPRFIFI_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFIPRFIFI.KeyPress
        If Not Char.IsNumber(e.KeyChar) Then
            If e.KeyChar <> Convert.ToChar(Keys.Back) Then
                If e.KeyChar <> Convert.ToChar(37) Then
                    If e.KeyChar <> Convert.ToChar(Keys.Enter) Then
                        e.Handled = True
                        strBARRESTA.Items(1).Text = IncoValoNume
                        mod_MENSAJE.Inco_Valo_Nume()
                    Else
                        strBARRESTA.Items(1).Text = ""
                        txtFIPRTIFI.Focus()
                    End If
                End If
            End If
        End If
    End Sub
    Private Sub txtFIPRTIFI_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFIPRTIFI.KeyPress
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
    Private Sub txtFIPRMUNI_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFIPRMUNI.KeyPress
        If Not Char.IsNumber(e.KeyChar) Then
            If e.KeyChar <> Convert.ToChar(Keys.Back) Then
                If e.KeyChar <> Convert.ToChar(37) Then
                    If e.KeyChar <> Convert.ToChar(Keys.Enter) Then
                        e.Handled = True
                        strBARRESTA.Items(1).Text = IncoValoNume
                        mod_MENSAJE.Inco_Valo_Nume()
                    Else
                        strBARRESTA.Items(1).Text = ""
                        txtFIPRCORR.Focus()
                    End If
                End If
            End If
        End If
    End Sub
    Private Sub txtFIPRCORR_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFIPRCORR.KeyPress
        If Not Char.IsNumber(e.KeyChar) Then
            If e.KeyChar <> Convert.ToChar(Keys.Back) Then
                If e.KeyChar <> Convert.ToChar(37) Then
                    If e.KeyChar <> Convert.ToChar(Keys.Enter) Then
                        e.Handled = True
                        strBARRESTA.Items(1).Text = IncoValoNume
                        mod_MENSAJE.Inco_Valo_Nume()
                    Else
                        strBARRESTA.Items(1).Text = ""
                        txtFIPRBARR.Focus()
                    End If
                End If
            End If
        End If

    End Sub
    Private Sub txtFIPRBARR_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFIPRBARR.KeyPress
        If Not Char.IsNumber(e.KeyChar) Then
            If e.KeyChar <> Convert.ToChar(Keys.Back) Then
                If e.KeyChar <> Convert.ToChar(37) Then
                    If e.KeyChar <> Convert.ToChar(Keys.Enter) Then
                        e.Handled = True
                        strBARRESTA.Items(1).Text = IncoValoNume
                        mod_MENSAJE.Inco_Valo_Nume()
                    Else
                        strBARRESTA.Items(1).Text = ""
                        txtFIPRMANZ.Focus()
                    End If
                End If
            End If
        End If

    End Sub
    Private Sub txtFIPRMANZ_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFIPRMANZ.KeyPress
        If Not Char.IsNumber(e.KeyChar) Then
            If e.KeyChar <> Convert.ToChar(Keys.Back) Then
                If e.KeyChar <> Convert.ToChar(37) Then
                    If e.KeyChar <> Convert.ToChar(Keys.Enter) Then
                        e.Handled = True
                        strBARRESTA.Items(1).Text = IncoValoNume
                        mod_MENSAJE.Inco_Valo_Nume()
                    Else
                        strBARRESTA.Items(1).Text = ""
                        txtFIPRPRED.Focus()
                    End If
                End If
            End If
        End If

    End Sub
    Private Sub txtFIPRPRED_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFIPRPRED.KeyPress
        If Not Char.IsNumber(e.KeyChar) Then
            If e.KeyChar <> Convert.ToChar(Keys.Back) Then
                If e.KeyChar <> Convert.ToChar(37) Then
                    If e.KeyChar <> Convert.ToChar(Keys.Enter) Then
                        e.Handled = True
                        strBARRESTA.Items(1).Text = IncoValoNume
                        mod_MENSAJE.Inco_Valo_Nume()
                    Else
                        strBARRESTA.Items(1).Text = ""
                        txtFIPREDIF.Focus()
                    End If
                End If
            End If
        End If

    End Sub
    Private Sub txtFIPREDIF_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFIPREDIF.KeyPress
        If Not Char.IsNumber(e.KeyChar) Then
            If e.KeyChar <> Convert.ToChar(Keys.Back) Then
                If e.KeyChar <> Convert.ToChar(37) Then
                    If e.KeyChar <> Convert.ToChar(Keys.Enter) Then
                        e.Handled = True
                        strBARRESTA.Items(1).Text = IncoValoNume
                        mod_MENSAJE.Inco_Valo_Nume()
                    Else
                        strBARRESTA.Items(1).Text = ""
                        txtFIPRUNPR.Focus()
                    End If
                End If
            End If
        End If

    End Sub
    Private Sub txtFIPRUNPR_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFIPRUNPR.KeyPress
        If Not Char.IsNumber(e.KeyChar) Then
            If e.KeyChar <> Convert.ToChar(Keys.Back) Then
                If e.KeyChar <> Convert.ToChar(37) Then
                    If e.KeyChar <> Convert.ToChar(Keys.Enter) Then
                        e.Handled = True
                        strBARRESTA.Items(1).Text = IncoValoNume
                        mod_MENSAJE.Inco_Valo_Nume()
                    Else
                        strBARRESTA.Items(1).Text = ""
                        txtFIPRCLSE.Focus()
                    End If
                End If
            End If
        End If

    End Sub
    Private Sub txtFIPRCLSE_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFIPRCLSE.KeyPress
        If Not Char.IsNumber(e.KeyChar) Then
            If e.KeyChar <> Convert.ToChar(Keys.Back) Then
                If e.KeyChar <> Convert.ToChar(37) Then
                    If e.KeyChar <> Convert.ToChar(Keys.Enter) Then
                        e.Handled = True
                        strBARRESTA.Items(1).Text = IncoValoNume
                        mod_MENSAJE.Inco_Valo_Nume()
                    Else
                        strBARRESTA.Items(1).Text = ""
                        cmdGENERAR.Focus()
                    End If
                End If
            End If
        End If
    End Sub

#End Region

#Region "GotFocus"

    Private Sub txtFIPRFIIN_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFIPRFIIN.GotFocus
        txtFIPRFIIN.SelectionStart = 0
        txtFIPRFIIN.SelectionLength = Len(txtFIPRFIIN.Text)
        strBARRESTA.Items(0).Text = txtFIPRFIIN.AccessibleDescription
    End Sub
    Private Sub txtFIPRFIFI_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFIPRFIFI.GotFocus
        txtFIPRFIFI.SelectionStart = 0
        txtFIPRFIFI.SelectionLength = Len(txtFIPRFIFI.Text)
        strBARRESTA.Items(0).Text = txtFIPRFIFI.AccessibleDescription
    End Sub
    Private Sub txtFIPRTIFI_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFIPRTIFI.GotFocus
        txtFIPRTIFI.SelectionStart = 0
        txtFIPRTIFI.SelectionLength = Len(txtFIPRTIFI.Text)
        strBARRESTA.Items(0).Text = txtFIPRTIFI.AccessibleDescription
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
    Private Sub cboTIPOIMPU_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboTIPOIMPU.GotFocus
        strBARRESTA.Items(0).Text = cboTIPOIMPU.AccessibleDescription
    End Sub
    Private Sub cboCONCEPTO_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboCONCEPTO.GotFocus
        strBARRESTA.Items(0).Text = cboCONCEPTO.AccessibleDescription
    End Sub
    Private Sub cboVIGENCIA1_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboVIGENCIA1.GotFocus
        strBARRESTA.Items(0).Text = cboVIGENCIA1.AccessibleDescription
    End Sub
    Private Sub cboVIGENCIA2_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboVIGENCIA2.GotFocus
        strBARRESTA.Items(0).Text = cboVIGENCIA2.AccessibleDescription
    End Sub
    Private Sub cmdGENERAR_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdGENERAR.GotFocus
        strBARRESTA.Items(0).Text = cmdGENERAR.AccessibleDescription
    End Sub
    Private Sub cmdLIMPIAR_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdLIMPIAR.GotFocus
        strBARRESTA.Items(0).Text = cmdLIMPIAR.AccessibleDescription
    End Sub
    Private Sub cmdIMPRIMIR_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdIMPRIMIR.GotFocus
        strBARRESTA.Items(0).Text = cmdIMPRIMIR.AccessibleDescription
    End Sub
    Private Sub btnPrintPreview_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnPrintPreview.GotFocus
        strBARRESTA.Items(0).Text = btnPrintPreview.AccessibleDescription
    End Sub
    Private Sub btnPageSetup_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnPageSetup.GotFocus
        strBARRESTA.Items(0).Text = btnPageSetup.AccessibleDescription
    End Sub
    Private Sub cmdSALIR_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdSALIR.GotFocus
        strBARRESTA.Items(0).Text = cmdSALIR.AccessibleDescription
    End Sub
    Private Sub cmdExportarExcel_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdExportarExcel.GotFocus
        strBARRESTA.Items(0).Text = cmdExportarExcel.AccessibleDescription
    End Sub
    Private Sub cmdExportarPlano_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdExportarPlano.GotFocus
        strBARRESTA.Items(0).Text = cmdExportarPlano.AccessibleDescription
    End Sub

#End Region

#Region "Validated"

    Private Sub txtFIPRFIIN_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFIPRFIIN.Validated
        strBARRESTA.Items(1).Text = ""
    End Sub
    Private Sub txtFIPRFIFI_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFIPRFIFI.Validated
        strBARRESTA.Items(1).Text = ""
    End Sub
    Private Sub txtFIPRTIFI_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFIPRTIFI.Validated
        strBARRESTA.Items(1).Text = ""
    End Sub
    Private Sub txtFIPRMUNI_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFIPRMUNI.Validated
        txtFIPRMUNI.Text = fun_Formato_Mascara_3_String(txtFIPRMUNI.Text)
        strBARRESTA.Items(1).Text = ""
    End Sub
    Private Sub txtFIPRCORR_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFIPRCORR.Validated
        txtFIPRCORR.Text = fun_Formato_Mascara_2_String(txtFIPRCORR.Text)
        strBARRESTA.Items(1).Text = ""
    End Sub
    Private Sub txtFIPRBARR_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFIPRBARR.Validated
        txtFIPRBARR.Text = fun_Formato_Mascara_3_String(txtFIPRBARR.Text)
        strBARRESTA.Items(1).Text = ""
    End Sub
    Private Sub txtFIPRMANZ_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFIPRMANZ.Validated
        txtFIPRMANZ.Text = fun_Formato_Mascara_3_String(txtFIPRMANZ.Text)
        strBARRESTA.Items(1).Text = ""
    End Sub
    Private Sub txtFIPRPRED_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFIPRPRED.Validated
        txtFIPRPRED.Text = fun_Formato_Mascara_5_String(txtFIPRPRED.Text)
        strBARRESTA.Items(1).Text = ""
    End Sub
    Private Sub txtFIPREDIF_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFIPREDIF.Validated
        txtFIPREDIF.Text = fun_Formato_Mascara_3_String(txtFIPREDIF.Text)
        strBARRESTA.Items(1).Text = ""
    End Sub
    Private Sub txtFIPRUNPR_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFIPRUNPR.Validated
        txtFIPRUNPR.Text = fun_Formato_Mascara_5_String(txtFIPRUNPR.Text)
        strBARRESTA.Items(1).Text = ""
    End Sub

#End Region

#Region "Click"

    Private Sub cboVIGENCIA1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboVIGENCIA1.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_VIGENCIA_Descripcion(Me.cboVIGENCIA1, Me.cboVIGENCIA1.SelectedIndex)
    End Sub
    Private Sub cboVIGENCIA2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboVIGENCIA2.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_VIGENCIA_Descripcion(Me.cboVIGENCIA2, Me.cboVIGENCIA2.SelectedIndex)
    End Sub
    Private Sub cboTIPOIMPU_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboTIPOIMPU.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_TIPOIMPU_Descripcion(Me.cboTIPOIMPU, Me.cboTIPOIMPU.SelectedIndex)
    End Sub
    Private Sub cboCONCEPTO_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboCONCEPTO.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_CONCEPTO_Descripcion(Me.cboCONCEPTO, Me.cboCONCEPTO.SelectedIndex, Me.cboTIPOIMPU)
    End Sub

#End Region

#Region "SelectedIndexChanged"

    Private Sub cboVIGENCIA1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboVIGENCIA1.SelectedIndexChanged
        Me.lblVIGENCIA1.Text = CType(fun_Buscar_Lista_Valores_VIGENCIA_Codigo(Me.cboVIGENCIA1), String)
    End Sub
    Private Sub cboVIGENCIA2_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboVIGENCIA2.SelectedIndexChanged
        Me.lblVIGENCIA2.Text = CType(fun_Buscar_Lista_Valores_VIGENCIA_Codigo(Me.cboVIGENCIA2), String)
    End Sub
    Private Sub cboTIPOIMPU_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboTIPOIMPU.SelectedIndexChanged
        Me.lblTIPOIMPU.Text = CType(fun_Buscar_Lista_Valores_TIPOIMPU_Codigo(Me.cboTIPOIMPU), String)

        Me.cboCONCEPTO.DataSource = New DataTable
        Me.lblCONCEPTO.Text = ""
    End Sub
    Private Sub cboCONCEPTO_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCONCEPTO.SelectedIndexChanged
        Me.lblCONCEPTO.Text = CType(fun_Buscar_Lista_Valores_CONCEPTO_Codigo(Me.cboTIPOIMPU, Me.cboCONCEPTO), String)
    End Sub
    Private Sub chkLiquidarUnaVigencia_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkLiquidarUnaVigencia.CheckedChanged

        If Me.chkLiquidarUnaVigencia.Checked = True Then
            Me.rbdVigencia1.Visible = True
            Me.rbdVigencia2.Visible = True
        Else
            Me.rbdVigencia1.Visible = False
            Me.rbdVigencia2.Visible = False
        End If

    End Sub
    Private Sub cboTIPOREPO_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboTIPOREPO.SelectedIndexChanged

        If Me.cboTIPOREPO.SelectedIndex = 0 Or Me.cboTIPOREPO.SelectedIndex = 1 Then
            Me.chkLiquidarUnaVigencia.Visible = True
            Me.rbdVigencia1.Visible = True
            Me.rbdVigencia2.Visible = True
        Else
            Me.chkLiquidarUnaVigencia.Visible = False
            Me.rbdVigencia1.Visible = False
            Me.rbdVigencia2.Visible = False
        End If

    End Sub

#End Region

#End Region

End Class