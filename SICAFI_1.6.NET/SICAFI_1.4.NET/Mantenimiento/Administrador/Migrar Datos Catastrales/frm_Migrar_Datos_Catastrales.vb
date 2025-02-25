Imports REGLAS_DEL_NEGOCIO
Imports System
Imports System.IO
Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration
Imports System.Text

Public Class frm_Migrar_Datos_Catastrales

    '================================
    '*** MIGRAR DATOS CATASTRALES ***
    '================================

#Region "INSTANCIAR FORMULARIO"

    Private Shared frm_Instance = Nothing

    Public Shared Function instance() As frm_Migrar_Datos_Catastrales
        If frm_Instance Is Nothing OrElse frm_Instance.isdisposed = True Then
            frm_Instance = New frm_Migrar_Datos_Catastrales
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

    ' tablas de la ficha
    Dim dt_RESOLUCION As New DataTable
    Dim dt_FICHPRED As New DataTable
    Dim dt_FICHRESU As New DataTable
    Dim dt_FIPRDEEC As New DataTable
    Dim dt_FIPRPROP As New DataTable
    Dim dt_FIPRCONS As New DataTable
    Dim dt_FIPRCACO As New DataTable
    Dim dt_FIPRLIND As New DataTable
    Dim dt_FIPRCART As New DataTable
    Dim dt_FIPRZOEC As New DataTable
    Dim dt_FIPRZOFI As New DataTable
    Dim dt_PROPANTE As New DataTable

    ' tablas de mantenimiento
    Dim dt_ESTADO As New DataTable
    Dim dt_CLASSECT As New DataTable
    Dim dt_VIGENCIA As New DataTable
    Dim dt_CATESUEL As New DataTable
    Dim dt_DESTECON As New DataTable
    Dim dt_CARAPRED As New DataTable
    Dim dt_MODOADQU As New DataTable
    Dim dt_CALIPROP As New DataTable
    Dim dt_TIPODOCU As New DataTable
    Dim dt_DEPARTAMENTO As New DataTable
    Dim dt_MUNICIPIO As New DataTable
    Dim dt_NOTARIA As New DataTable
    Dim dt_CAUSACTO As New DataTable
    Dim dt_CLASCONS As New DataTable
    Dim dt_TIPOCONS As New DataTable
    Dim dt_PUNTCARD As New DataTable
    Dim dt_ZONAECON As New DataTable
    Dim dt_ZONAFISI As New DataTable
    Dim dt_TIPOCALI As New DataTable
    Dim dt_TERCERO As New DataTable

    ' variables de conexion
    Private oEjecutar As New SqlCommand
    Private oConexion As New SqlConnection
    Private oAdapter As New SqlDataAdapter
    Private oReader As SqlDataReader

    ' conexion original
    Dim vl_stConexionRed As String = ""
    Dim vl_stConexionLocal As String = ""

    ' conexiones alternas
    Dim vl_stInstanciaRed As String = "RED"
    Dim vl_stInstanciaLocal As String = "LOCAL"

    ' variables de la conexion
    Dim vl_stMaquina As String = ""
    Dim vl_stInstancia As String = ""

    ' variables de resolucion
    Dim vl_stRESODEPA As String = ""
    Dim vl_stRESOMUNI As String = ""
    Dim vl_inRESOTIRE As Integer = 0
    Dim vl_inRESOCLSE As Integer = 0
    Dim vl_inRESOVIGE As Integer = 0
    Dim vl_inRESOCODI As Integer = 0

    Dim vl_inContadorParcial As Integer = 0
    Dim vl_inContadorTotal As Integer = 0

#End Region

#Region "PROCEDIMIENTOS"

    Private Sub pro_LimpiarCampos()

        ' campos resolución
        Me.txtRESODEPA.Text = ""
        Me.txtRESOMUNI.Text = ""
        Me.txtRESOTIRE.Text = ""
        Me.txtRESOVIGE.Text = ""
        Me.txtRESOCLSE.Text = ""
        Me.txtRESOCODI.Text = ""
        Me.lblRESODEPA.Text = ""
        Me.lblRESOMUNI.Text = ""
        Me.lblRESOTIRE.Text = ""
        Me.lblRESOVIGE.Text = ""
        Me.lblRESOCLSE.Text = ""
        Me.lblRESODESC.Text = ""

        ' tablas de la ficha
        dt_RESOLUCION = New DataTable
        dt_FICHPRED = New DataTable
        dt_FICHRESU = New DataTable
        dt_FIPRDEEC = New DataTable
        dt_FIPRPROP = New DataTable
        dt_FIPRCONS = New DataTable
        dt_FIPRCACO = New DataTable
        dt_FIPRLIND = New DataTable
        dt_FIPRCART = New DataTable
        dt_FIPRZOEC = New DataTable
        dt_FIPRZOFI = New DataTable
        dt_PROPANTE = New DataTable

        ' tablas de mantenimiento
        dt_ESTADO = New DataTable
        dt_CLASSECT = New DataTable
        dt_VIGENCIA = New DataTable
        dt_CATESUEL = New DataTable
        dt_DESTECON = New DataTable
        dt_CARAPRED = New DataTable
        dt_MODOADQU = New DataTable
        dt_CALIPROP = New DataTable
        dt_TIPODOCU = New DataTable
        dt_DEPARTAMENTO = New DataTable
        dt_MUNICIPIO = New DataTable
        dt_NOTARIA = New DataTable
        dt_CAUSACTO = New DataTable
        dt_CLASCONS = New DataTable
        dt_TIPOCONS = New DataTable
        dt_PUNTCARD = New DataTable
        dt_ZONAECON = New DataTable
        dt_ZONAFISI = New DataTable
        dt_TIPOCALI = New DataTable
        dt_TERCERO = New DataTable

        Me.strBARRESTA.Items(2).Text = "Registros: 0"

    End Sub
    Private Sub pro_AlmacenarConexion()

        Try

            Dim oCadenaConexionRed As New REGLAS_DEL_NEGOCIO.cla_ConnectionString
            Dim stCadenaConexionRed As String = oCadenaConexionRed.fun_ConnectionString_RED

            vl_stConexionRed = stCadenaConexionRed

            Dim oCadenaConexionLocal As New REGLAS_DEL_NEGOCIO.cla_ConnectionString
            Dim stCadenaConexionLocal As String = oCadenaConexionLocal.fun_ConnectionString_LOCAL

            vl_stConexionLocal = stCadenaConexionLocal

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub

#End Region

#Region "FUNCIONES"

    ' funcion tabla resolucion
    Private Function fun_Verificar_RESOLUCION(ByVal stRESODEPA As String, _
                                              ByVal stRESOMUNI As String, _
                                              ByVal inRESOTIRE As Integer, _
                                              ByVal inRESOCLSE As Integer, _
                                              ByVal inRESOVIGE As Integer, _
                                              ByVal inRESOCODI As Integer) As Boolean

        Try
            Dim boResolucionExistente As Boolean = False
            ' crea el datatable
            dt_RESOLUCION = New DataTable

            ' crear conexión
            oAdapter = New SqlDataAdapter
            oConexion = New SqlConnection(vl_stConexionRed)

            ' abre la conexion
            oConexion.Open()

            ' parametros de la consulta
            Dim ParametrosConsulta As String = ""

            ' Concatena la condicion de la consulta
            ParametrosConsulta += "SELECT * "
            ParametrosConsulta += "FROM RESOLUCION "
            ParametrosConsulta += "WHERE "
            ParametrosConsulta += "RESODEPA = '" & CStr(Trim(stRESODEPA)) & "' AND "
            ParametrosConsulta += "RESOMUNI = '" & CStr(Trim(stRESOMUNI)) & "' AND "
            ParametrosConsulta += "RESOTIRE = '" & CInt(inRESOTIRE) & "' AND "
            ParametrosConsulta += "RESOCLSE = '" & CInt(inRESOCLSE) & "' AND "
            ParametrosConsulta += "RESOVIGE = '" & CInt(inRESOVIGE) & "' AND "
            ParametrosConsulta += "RESOCODI = '" & CInt(inRESOCODI) & "' "

            ' ejecuta la consulta
            oEjecutar = New SqlCommand(ParametrosConsulta, oConexion)

            ' procesa la consulta 
            oEjecutar.CommandTimeout = 0
            oEjecutar.CommandType = CommandType.Text
            oAdapter.SelectCommand = oEjecutar

            ' llena el datatable 
            oAdapter.Fill(dt_RESOLUCION)

            ' cierra la conexion
            oConexion.Close()

            If dt_RESOLUCION.Rows.Count > 0 Then
                boResolucionExistente = True
            Else
                boResolucionExistente = False
            End If

            Return boResolucionExistente

        Catch ex As Exception
            Return False
        End Try

    End Function

    ' funciones tablas de la ficha 
    Private Function fun_ListadoDeDatos_FICHRESU(ByVal stRESOMUNI As String, ByVal inRESOCLSE As Integer) As DataTable

        Try
            ' crea el datatable
            dt_FICHRESU = New DataTable

            ' crear conexión
            oAdapter = New SqlDataAdapter
            oConexion = New SqlConnection(vl_stConexionRed)

            ' abre la conexion
            oConexion.Open()

            ' parametros de la consulta
            Dim ParametrosConsulta As String = ""

            ' Concatena la condicion de la consulta
            ParametrosConsulta += "SELECT * "
            ParametrosConsulta += "FROM FICHPRED "
            ParametrosConsulta += "WHERE "
            ParametrosConsulta += "FIPRMUNI = '" & CStr(Trim(stRESOMUNI)) & "' AND "
            ParametrosConsulta += "FIPRCLSE = '" & CInt(inRESOCLSE) & "' AND "
            ParametrosConsulta += "FIPRTIFI IN('" & CInt(1) & "','" & CInt(2) & "') "

            ' ejecuta la consulta
            oEjecutar = New SqlCommand(ParametrosConsulta, oConexion)

            ' procesa la consulta 
            oEjecutar.CommandTimeout = 0
            oEjecutar.CommandType = CommandType.Text
            oAdapter.SelectCommand = oEjecutar

            ' llena el datatable 
            oAdapter.Fill(dt_FICHRESU)

            ' cierra la conexion
            oConexion.Close()

            ' retorna la tabla
            Return dt_FICHRESU

        Catch ex As Exception
            Return Nothing
        End Try

    End Function
    Private Function fun_ListadoDeDatos_FICHPRED(ByVal stRESOMUNI As String, ByVal inRESOCLSE As Integer) As DataTable

        Try
            ' crea el datatable
            dt_FICHPRED = New DataTable

            ' crear conexión
            oAdapter = New SqlDataAdapter
            oConexion = New SqlConnection(vl_stConexionRed)

            ' abre la conexion
            oConexion.Open()

            ' parametros de la consulta
            Dim ParametrosConsulta As String = ""

            ' Concatena la condicion de la consulta
            ParametrosConsulta += "SELECT * "
            ParametrosConsulta += "FROM FICHPRED "
            ParametrosConsulta += "WHERE "
            ParametrosConsulta += "FIPRMUNI = '" & CStr(Trim(stRESOMUNI)) & "' AND "
            ParametrosConsulta += "FIPRCLSE = '" & CInt(inRESOCLSE) & "' AND "
            ParametrosConsulta += "FIPRTIFI = '" & CInt(0) & "' "

            ' ejecuta la consulta
            oEjecutar = New SqlCommand(ParametrosConsulta, oConexion)

            ' procesa la consulta 
            oEjecutar.CommandTimeout = 0
            oEjecutar.CommandType = CommandType.Text
            oAdapter.SelectCommand = oEjecutar

            ' llena el datatable 
            oAdapter.Fill(dt_FICHPRED)

            ' cierra la conexion
            oConexion.Close()

            ' retorna la tabla
            Return dt_FICHPRED

        Catch ex As Exception
            Return Nothing
        End Try

    End Function
    Private Function fun_ListadoDeDatos_FIPRDEEC(ByVal stRESOMUNI As String, ByVal inRESOCLSE As Integer) As DataTable

        Try
            ' crea el datatable
            dt_FIPRDEEC = New DataTable

            ' crear conexión
            oAdapter = New SqlDataAdapter
            oConexion = New SqlConnection(vl_stConexionRed)

            ' abre la conexion
            oConexion.Open()

            ' parametros de la consulta
            Dim ParametrosConsulta As String = ""

            ' Concatena la condicion de la consulta
            ParametrosConsulta += "SELECT * "
            ParametrosConsulta += "FROM FIPRDEEC "
            ParametrosConsulta += "WHERE "
            ParametrosConsulta += "EXISTS(SELECT 1 FROM FICHPRED WHERE  "
            ParametrosConsulta += "FIPRNUFI = FPDENUFI AND "
            ParametrosConsulta += "FIPRTIFI = 0 AND "
            ParametrosConsulta += "FIPRMUNI = '" & CStr(Trim(stRESOMUNI)) & "' and "
            ParametrosConsulta += "FIPRCLSE = '" & CInt(inRESOCLSE) & "' ) "

            ' ejecuta la consulta
            oEjecutar = New SqlCommand(ParametrosConsulta, oConexion)

            ' procesa la consulta 
            oEjecutar.CommandTimeout = 0
            oEjecutar.CommandType = CommandType.Text
            oAdapter.SelectCommand = oEjecutar

            ' llena el datatable 
            oAdapter.Fill(dt_FIPRDEEC)

            ' cierra la conexion
            oConexion.Close()

            ' retorna la tabla
            Return dt_FIPRDEEC

        Catch ex As Exception
            Return Nothing
        End Try

    End Function
    Private Function fun_ListadoDeDatos_FIPRPROP(ByVal stRESOMUNI As String, ByVal inRESOCLSE As Integer) As DataTable

        Try
            ' crea el datatable
            dt_FIPRPROP = New DataTable

            ' crear conexión
            oAdapter = New SqlDataAdapter
            oConexion = New SqlConnection(vl_stConexionRed)

            ' abre la conexion
            oConexion.Open()

            ' parametros de la consulta
            Dim ParametrosConsulta As String = ""

            ' Concatena la condicion de la consulta
            ParametrosConsulta += "SELECT * "
            ParametrosConsulta += "FROM FIPRPROP "
            ParametrosConsulta += "WHERE "
            ParametrosConsulta += "EXISTS(SELECT 1 FROM FICHPRED WHERE  "
            ParametrosConsulta += "FIPRNUFI = FPPRNUFI AND "
            ParametrosConsulta += "FIPRTIFI = 0 AND "
            ParametrosConsulta += "FIPRMUNI = '" & CStr(Trim(stRESOMUNI)) & "' and "
            ParametrosConsulta += "FIPRCLSE = '" & CInt(inRESOCLSE) & "' ) "

            ' ejecuta la consulta
            oEjecutar = New SqlCommand(ParametrosConsulta, oConexion)

            ' procesa la consulta 
            oEjecutar.CommandTimeout = 0
            oEjecutar.CommandType = CommandType.Text
            oAdapter.SelectCommand = oEjecutar

            ' llena el datatable 
            oAdapter.Fill(dt_FIPRPROP)

            ' cierra la conexion
            oConexion.Close()

            ' retorna la tabla
            Return dt_FIPRPROP

        Catch ex As Exception
            Return Nothing
        End Try

    End Function
    Private Function fun_ListadoDeDatos_FIPRCONS(ByVal stRESOMUNI As String, ByVal inRESOCLSE As Integer) As DataTable

        Try
            ' crea el datatable
            dt_FIPRCONS = New DataTable

            ' crear conexión
            oAdapter = New SqlDataAdapter
            oConexion = New SqlConnection(vl_stConexionRed)

            ' abre la conexion
            oConexion.Open()

            ' parametros de la consulta
            Dim ParametrosConsulta As String = ""

            ' Concatena la condicion de la consulta
            ParametrosConsulta += "SELECT * "
            ParametrosConsulta += "FROM FIPRCONS "
            ParametrosConsulta += "WHERE "
            ParametrosConsulta += "EXISTS(SELECT 1 FROM FICHPRED WHERE  "
            ParametrosConsulta += "FIPRNUFI = FPCONUFI AND "
            ParametrosConsulta += "FIPRMUNI = '" & CStr(Trim(stRESOMUNI)) & "' and "
            ParametrosConsulta += "FIPRCLSE = '" & CInt(inRESOCLSE) & "' ) "

            ' ejecuta la consulta
            oEjecutar = New SqlCommand(ParametrosConsulta, oConexion)

            ' procesa la consulta 
            oEjecutar.CommandTimeout = 0
            oEjecutar.CommandType = CommandType.Text
            oAdapter.SelectCommand = oEjecutar

            ' llena el datatable 
            oAdapter.Fill(dt_FIPRCONS)

            ' cierra la conexion
            oConexion.Close()

            ' retorna la tabla
            Return dt_FIPRCONS

        Catch ex As Exception
            Return Nothing
        End Try

    End Function
    Private Function fun_ListadoDeDatos_FIPRCACO(ByVal stRESOMUNI As String, ByVal inRESOCLSE As Integer) As DataTable

        Try
            ' crea el datatable
            dt_FIPRCACO = New DataTable

            ' crear conexión
            oAdapter = New SqlDataAdapter
            oConexion = New SqlConnection(vl_stConexionRed)

            ' abre la conexion
            oConexion.Open()

            ' parametros de la consulta
            Dim ParametrosConsulta As String = ""

            ' Concatena la condicion de la consulta
            ParametrosConsulta += "SELECT * "
            ParametrosConsulta += "FROM FIPRCACO "
            ParametrosConsulta += "WHERE "
            ParametrosConsulta += "EXISTS(SELECT 1 FROM FICHPRED WHERE  "
            ParametrosConsulta += "FIPRNUFI = FPCCNUFI AND "
            ParametrosConsulta += "FIPRMUNI = '" & CStr(Trim(stRESOMUNI)) & "' AND "
            ParametrosConsulta += "FIPRCLSE = '" & CInt(inRESOCLSE) & "' ) "

            ' ejecuta la consulta
            oEjecutar = New SqlCommand(ParametrosConsulta, oConexion)

            ' procesa la consulta 
            oEjecutar.CommandTimeout = 0
            oEjecutar.CommandType = CommandType.Text
            oAdapter.SelectCommand = oEjecutar

            ' llena el datatable 
            oAdapter.Fill(dt_FIPRCACO)

            ' cierra la conexion
            oConexion.Close()

            ' retorna la tabla
            Return dt_FIPRCACO

        Catch ex As Exception
            Return Nothing
        End Try

    End Function
    Private Function fun_ListadoDeDatos_FIPRLIND(ByVal stRESOMUNI As String, ByVal inRESOCLSE As Integer) As DataTable

        Try
            ' crea el datatable
            dt_FIPRLIND = New DataTable

            ' crear conexión
            oAdapter = New SqlDataAdapter
            oConexion = New SqlConnection(vl_stConexionRed)

            ' abre la conexion
            oConexion.Open()

            ' parametros de la consulta
            Dim ParametrosConsulta As String = ""

            ' Concatena la condicion de la consulta
            ParametrosConsulta += "SELECT * "
            ParametrosConsulta += "FROM FIPRLIND "
            ParametrosConsulta += "WHERE "
            ParametrosConsulta += "EXISTS(SELECT 1 FROM FICHPRED WHERE  "
            ParametrosConsulta += "FIPRNUFI = FPLINUFI AND "
            ParametrosConsulta += "FIPRMUNI = '" & CStr(Trim(stRESOMUNI)) & "' AND "
            ParametrosConsulta += "FIPRCLSE = '" & CInt(inRESOCLSE) & "' ) "

            ' ejecuta la consulta
            oEjecutar = New SqlCommand(ParametrosConsulta, oConexion)

            ' procesa la consulta 
            oEjecutar.CommandTimeout = 0
            oEjecutar.CommandType = CommandType.Text
            oAdapter.SelectCommand = oEjecutar

            ' llena el datatable 
            oAdapter.Fill(dt_FIPRLIND)

            ' cierra la conexion
            oConexion.Close()

            ' retorna la tabla
            Return dt_FIPRLIND

        Catch ex As Exception
            Return Nothing
        End Try

    End Function
    Private Function fun_ListadoDeDatos_FIPRCART(ByVal stRESOMUNI As String, ByVal inRESOCLSE As Integer) As DataTable

        Try
            ' crea el datatable
            dt_FIPRCART = New DataTable

            ' crear conexión
            oAdapter = New SqlDataAdapter
            oConexion = New SqlConnection(vl_stConexionRed)

            ' abre la conexion
            oConexion.Open()

            ' parametros de la consulta
            Dim ParametrosConsulta As String = ""

            ' Concatena la condicion de la consulta
            ParametrosConsulta += "SELECT * "
            ParametrosConsulta += "FROM FIPRCART "
            ParametrosConsulta += "WHERE "
            ParametrosConsulta += "EXISTS(SELECT 1 FROM FICHPRED WHERE  "
            ParametrosConsulta += "FIPRNUFI = FPCANUFI AND "
            ParametrosConsulta += "FIPRMUNI = '" & CStr(Trim(stRESOMUNI)) & "' AND "
            ParametrosConsulta += "FIPRCLSE = '" & CInt(inRESOCLSE) & "' ) "

            ' ejecuta la consulta
            oEjecutar = New SqlCommand(ParametrosConsulta, oConexion)

            ' procesa la consulta 
            oEjecutar.CommandTimeout = 0
            oEjecutar.CommandType = CommandType.Text
            oAdapter.SelectCommand = oEjecutar

            ' llena el datatable 
            oAdapter.Fill(dt_FIPRCART)

            ' cierra la conexion
            oConexion.Close()

            ' retorna la tabla
            Return dt_FIPRCART

        Catch ex As Exception
            Return Nothing
        End Try

    End Function
    Private Function fun_ListadoDeDatos_FIPRZOEC(ByVal stRESOMUNI As String, ByVal inRESOCLSE As Integer) As DataTable

        Try
            ' crea el datatable
            dt_FIPRZOEC = New DataTable

            ' crear conexión
            oAdapter = New SqlDataAdapter
            oConexion = New SqlConnection(vl_stConexionRed)

            ' abre la conexion
            oConexion.Open()

            ' parametros de la consulta
            Dim ParametrosConsulta As String = ""

            ' Concatena la condicion de la consulta
            ParametrosConsulta += "SELECT * "
            ParametrosConsulta += "FROM FIPRZOEC "
            ParametrosConsulta += "WHERE "
            ParametrosConsulta += "EXISTS(SELECT 1 FROM FICHPRED WHERE  "
            ParametrosConsulta += "FIPRNUFI = FPZENUFI AND "
            ParametrosConsulta += "FIPRMUNI = '" & CStr(Trim(stRESOMUNI)) & "' AND "
            ParametrosConsulta += "FIPRCLSE = '" & CInt(inRESOCLSE) & "' ) "

            ' ejecuta la consulta
            oEjecutar = New SqlCommand(ParametrosConsulta, oConexion)

            ' procesa la consulta 
            oEjecutar.CommandTimeout = 0
            oEjecutar.CommandType = CommandType.Text
            oAdapter.SelectCommand = oEjecutar

            ' llena el datatable 
            oAdapter.Fill(dt_FIPRZOEC)

            ' cierra la conexion
            oConexion.Close()

            ' retorna la tabla
            Return dt_FIPRZOEC

        Catch ex As Exception
            Return Nothing
        End Try

    End Function
    Private Function fun_ListadoDeDatos_FIPRZOFI(ByVal stRESOMUNI As String, ByVal inRESOCLSE As Integer) As DataTable

        Try
            ' crea el datatable
            dt_FIPRZOFI = New DataTable

            ' crear conexión
            oAdapter = New SqlDataAdapter
            oConexion = New SqlConnection(vl_stConexionRed)

            ' abre la conexion
            oConexion.Open()

            ' parametros de la consulta
            Dim ParametrosConsulta As String = ""

            ' Concatena la condicion de la consulta
            ParametrosConsulta += "SELECT * "
            ParametrosConsulta += "FROM FIPRZOFI "
            ParametrosConsulta += "WHERE "
            ParametrosConsulta += "EXISTS(SELECT 1 FROM FICHPRED WHERE  "
            ParametrosConsulta += "FIPRNUFI = FPZFNUFI AND "
            ParametrosConsulta += "FIPRMUNI = '" & CStr(Trim(stRESOMUNI)) & "' AND "
            ParametrosConsulta += "FIPRCLSE = '" & CInt(inRESOCLSE) & "' ) "

            ' ejecuta la consulta
            oEjecutar = New SqlCommand(ParametrosConsulta, oConexion)

            ' procesa la consulta 
            oEjecutar.CommandTimeout = 0
            oEjecutar.CommandType = CommandType.Text
            oAdapter.SelectCommand = oEjecutar

            ' llena el datatable 
            oAdapter.Fill(dt_FIPRZOFI)

            ' cierra la conexion
            oConexion.Close()

            ' retorna la tabla
            Return dt_FIPRZOFI

        Catch ex As Exception
            Return Nothing
        End Try

    End Function
    Private Function fun_ListadoDeDatos_PROPANTE(ByVal stRESOMUNI As String, ByVal inRESOCLSE As Integer) As DataTable

        Try
            ' crea el datatable
            dt_PROPANTE = New DataTable

            ' crear conexión
            oAdapter = New SqlDataAdapter
            oConexion = New SqlConnection(vl_stConexionRed)

            ' abre la conexion
            oConexion.Open()

            ' parametros de la consulta
            Dim ParametrosConsulta As String = ""

            ' Concatena la condicion de la consulta
            ParametrosConsulta += "SELECT * "
            ParametrosConsulta += "FROM PROPANTE "
            ParametrosConsulta += "WHERE "
            ParametrosConsulta += "EXISTS(SELECT 1 FROM FICHPRED WHERE  "
            ParametrosConsulta += "FIPRNUFI = PRANNUFI AND "
            ParametrosConsulta += "FIPRMUNI = '" & CStr(Trim(stRESOMUNI)) & "' AND "
            ParametrosConsulta += "FIPRCLSE = '" & CInt(inRESOCLSE) & "' ) "

            ' ejecuta la consulta
            oEjecutar = New SqlCommand(ParametrosConsulta, oConexion)

            ' procesa la consulta 
            oEjecutar.CommandTimeout = 0
            oEjecutar.CommandType = CommandType.Text
            oAdapter.SelectCommand = oEjecutar

            ' llena el datatable 
            oAdapter.Fill(dt_PROPANTE)

            ' cierra la conexion
            oConexion.Close()

            ' retorna la tabla
            Return dt_PROPANTE

        Catch ex As Exception
            Return Nothing
        End Try

    End Function

    ' funciones tablas de mantenimiento
    Private Function fun_ListadoDeDatos_ZONAECON(ByVal stRESOMUNI As String, ByVal inRESOCLSE As Integer) As DataTable

        Try
            ' crea el datatable
            dt_ZONAECON = New DataTable

            ' crear conexión
            oAdapter = New SqlDataAdapter
            oConexion = New SqlConnection(vl_stConexionRed)

            ' abre la conexion
            oConexion.Open()

            ' parametros de la consulta
            Dim ParametrosConsulta As String = ""

            ' Concatena la condicion de la consulta
            ParametrosConsulta += "SELECT * "
            ParametrosConsulta += "FROM MANT_ZONAECON "
            ParametrosConsulta += "WHERE "
            ParametrosConsulta += "ZOECMUNI = '" & CStr(Trim(stRESOMUNI)) & "' AND "
            ParametrosConsulta += "ZOECCLSE = '" & CInt(inRESOCLSE) & "' "

            ' ejecuta la consulta
            oEjecutar = New SqlCommand(ParametrosConsulta, oConexion)

            ' procesa la consulta 
            oEjecutar.CommandTimeout = 0
            oEjecutar.CommandType = CommandType.Text
            oAdapter.SelectCommand = oEjecutar

            ' llena el datatable 
            oAdapter.Fill(dt_ZONAECON)

            ' cierra la conexion
            oConexion.Close()

            ' retorna la tabla
            Return dt_ZONAECON

        Catch ex As Exception
            Return Nothing
        End Try

    End Function
    Private Function fun_ListadoDeDatos_ZONAFISI(ByVal stRESOMUNI As String, ByVal inRESOCLSE As Integer) As DataTable

        Try
            ' crea el datatable
            dt_ZONAFISI = New DataTable

            ' crear conexión
            oAdapter = New SqlDataAdapter
            oConexion = New SqlConnection(vl_stConexionRed)

            ' abre la conexion
            oConexion.Open()

            ' parametros de la consulta
            Dim ParametrosConsulta As String = ""

            ' Concatena la condicion de la consulta
            ParametrosConsulta += "SELECT * "
            ParametrosConsulta += "FROM MANT_ZONAFISI "
            ParametrosConsulta += "WHERE "
            ParametrosConsulta += "ZOFIMUNI = '" & CStr(Trim(stRESOMUNI)) & "' AND "
            ParametrosConsulta += "ZOFICLSE = '" & CInt(inRESOCLSE) & "' "

            ' ejecuta la consulta
            oEjecutar = New SqlCommand(ParametrosConsulta, oConexion)

            ' procesa la consulta 
            oEjecutar.CommandTimeout = 0
            oEjecutar.CommandType = CommandType.Text
            oAdapter.SelectCommand = oEjecutar

            ' llena el datatable 
            oAdapter.Fill(dt_ZONAFISI)

            ' cierra la conexion
            oConexion.Close()

            ' retorna la tabla
            Return dt_ZONAFISI

        Catch ex As Exception
            Return Nothing
        End Try

    End Function
    Private Function fun_ListadoDeDatos_TIPOCONS(ByVal stRESOMUNI As String, ByVal inRESOCLSE As Integer) As DataTable

        Try
            ' crea el datatable
            dt_TIPOCONS = New DataTable

            ' crear conexión
            oAdapter = New SqlDataAdapter
            oConexion = New SqlConnection(vl_stConexionRed)

            ' abre la conexion
            oConexion.Open()

            ' parametros de la consulta
            Dim ParametrosConsulta As String = ""

            ' Concatena la condicion de la consulta
            ParametrosConsulta += "SELECT * "
            ParametrosConsulta += "FROM MANT_TIPOCONS "
            ParametrosConsulta += "WHERE "
            ParametrosConsulta += "TICOMUNI = '" & CStr(Trim(stRESOMUNI)) & "' AND "
            ParametrosConsulta += "TICOCLSE = '" & CInt(inRESOCLSE) & "' "

            ' ejecuta la consulta
            oEjecutar = New SqlCommand(ParametrosConsulta, oConexion)

            ' procesa la consulta 
            oEjecutar.CommandTimeout = 0
            oEjecutar.CommandType = CommandType.Text
            oAdapter.SelectCommand = oEjecutar

            ' llena el datatable 
            oAdapter.Fill(dt_TIPOCONS)

            ' cierra la conexion
            oConexion.Close()

            ' retorna la tabla
            Return dt_TIPOCONS

        Catch ex As Exception
            Return Nothing
        End Try

    End Function
    Private Function fun_ListadoDeDatos_DEPARTAMENTO() As DataTable

        Try
            ' crea el datatable
            dt_DEPARTAMENTO = New DataTable

            ' crear conexión
            oAdapter = New SqlDataAdapter
            oConexion = New SqlConnection(vl_stConexionRed)

            ' abre la conexion
            oConexion.Open()

            ' parametros de la consulta
            Dim ParametrosConsulta As String = ""

            ' Concatena la condicion de la consulta
            ParametrosConsulta += "SELECT * "
            ParametrosConsulta += "FROM MANT_DEPARTAMENTO "

            ' ejecuta la consulta
            oEjecutar = New SqlCommand(ParametrosConsulta, oConexion)

            ' procesa la consulta 
            oEjecutar.CommandTimeout = 0
            oEjecutar.CommandType = CommandType.Text
            oAdapter.SelectCommand = oEjecutar

            ' llena el datatable 
            oAdapter.Fill(dt_DEPARTAMENTO)

            ' cierra la conexion
            oConexion.Close()

            ' retorna la tabla
            Return dt_DEPARTAMENTO

        Catch ex As Exception
            Return Nothing
        End Try

    End Function
    Private Function fun_ListadoDeDatos_MUNICIPIO() As DataTable

        Try
            ' crea el datatable
            dt_MUNICIPIO = New DataTable

            ' crear conexión
            oAdapter = New SqlDataAdapter
            oConexion = New SqlConnection(vl_stConexionRed)

            ' abre la conexion
            oConexion.Open()

            ' parametros de la consulta
            Dim ParametrosConsulta As String = ""

            ' Concatena la condicion de la consulta
            ParametrosConsulta += "SELECT * "
            ParametrosConsulta += "FROM MANT_MUNICIPIO "

            ' ejecuta la consulta
            oEjecutar = New SqlCommand(ParametrosConsulta, oConexion)

            ' procesa la consulta 
            oEjecutar.CommandTimeout = 0
            oEjecutar.CommandType = CommandType.Text
            oAdapter.SelectCommand = oEjecutar

            ' llena el datatable 
            oAdapter.Fill(dt_MUNICIPIO)

            ' cierra la conexion
            oConexion.Close()

            ' retorna la tabla
            Return dt_MUNICIPIO

        Catch ex As Exception
            Return Nothing
        End Try

    End Function
    Private Function fun_ListadoDeDatos_NOTARIA() As DataTable

        Try
            ' crea el datatable
            dt_NOTARIA = New DataTable

            ' crear conexión
            oAdapter = New SqlDataAdapter
            oConexion = New SqlConnection(vl_stConexionRed)

            ' abre la conexion
            oConexion.Open()

            ' parametros de la consulta
            Dim ParametrosConsulta As String = ""

            ' Concatena la condicion de la consulta
            ParametrosConsulta += "SELECT * "
            ParametrosConsulta += "FROM MANT_NOTARIA "

            ' ejecuta la consulta
            oEjecutar = New SqlCommand(ParametrosConsulta, oConexion)

            ' procesa la consulta 
            oEjecutar.CommandTimeout = 0
            oEjecutar.CommandType = CommandType.Text
            oAdapter.SelectCommand = oEjecutar

            ' llena el datatable 
            oAdapter.Fill(dt_NOTARIA)

            ' cierra la conexion
            oConexion.Close()

            ' retorna la tabla
            Return dt_NOTARIA

        Catch ex As Exception
            Return Nothing
        End Try

    End Function
    Private Function fun_ListadoDeDatos_ESTADO() As DataTable

        Try
            ' crea el datatable
            dt_ESTADO = New DataTable

            ' crear conexión
            oAdapter = New SqlDataAdapter
            oConexion = New SqlConnection(vl_stConexionRed)

            ' abre la conexion
            oConexion.Open()

            ' parametros de la consulta
            Dim ParametrosConsulta As String = ""

            ' Concatena la condicion de la consulta
            ParametrosConsulta += "SELECT * "
            ParametrosConsulta += "FROM ESTADO "

            ' ejecuta la consulta
            oEjecutar = New SqlCommand(ParametrosConsulta, oConexion)

            ' procesa la consulta 
            oEjecutar.CommandTimeout = 0
            oEjecutar.CommandType = CommandType.Text
            oAdapter.SelectCommand = oEjecutar

            ' llena el datatable 
            oAdapter.Fill(dt_ESTADO)

            ' cierra la conexion
            oConexion.Close()

            ' retorna la tabla
            Return dt_ESTADO

        Catch ex As Exception
            Return Nothing
        End Try

    End Function
    Private Function fun_ListadoDeDatos_CAUSACTO() As DataTable

        Try
            ' crea el datatable
            dt_CAUSACTO = New DataTable

            ' crear conexión
            oAdapter = New SqlDataAdapter
            oConexion = New SqlConnection(vl_stConexionRed)

            ' abre la conexion
            oConexion.Open()

            ' parametros de la consulta
            Dim ParametrosConsulta As String = ""

            ' Concatena la condicion de la consulta
            ParametrosConsulta += "SELECT * "
            ParametrosConsulta += "FROM MANT_CAUSACTO "

            ' ejecuta la consulta
            oEjecutar = New SqlCommand(ParametrosConsulta, oConexion)

            ' procesa la consulta 
            oEjecutar.CommandTimeout = 0
            oEjecutar.CommandType = CommandType.Text
            oAdapter.SelectCommand = oEjecutar

            ' llena el datatable 
            oAdapter.Fill(dt_CAUSACTO)

            ' cierra la conexion
            oConexion.Close()

            ' retorna la tabla
            Return dt_CAUSACTO

        Catch ex As Exception
            Return Nothing
        End Try

    End Function
    Private Function fun_ListadoDeDatos_CLASSECT() As DataTable

        Try
            ' crea el datatable
            dt_CLASSECT = New DataTable

            ' crear conexión
            oAdapter = New SqlDataAdapter
            oConexion = New SqlConnection(vl_stConexionRed)

            ' abre la conexion
            oConexion.Open()

            ' parametros de la consulta
            Dim ParametrosConsulta As String = ""

            ' Concatena la condicion de la consulta
            ParametrosConsulta += "SELECT * "
            ParametrosConsulta += "FROM MANT_CLASSECT "

            ' ejecuta la consulta
            oEjecutar = New SqlCommand(ParametrosConsulta, oConexion)

            ' procesa la consulta 
            oEjecutar.CommandTimeout = 0
            oEjecutar.CommandType = CommandType.Text
            oAdapter.SelectCommand = oEjecutar

            ' llena el datatable 
            oAdapter.Fill(dt_CLASSECT)

            ' cierra la conexion
            oConexion.Close()

            ' retorna la tabla
            Return dt_CLASSECT

        Catch ex As Exception
            Return Nothing
        End Try

    End Function
    Private Function fun_ListadoDeDatos_VIGENCIA() As DataTable

        Try
            ' crea el datatable
            dt_VIGENCIA = New DataTable

            ' crear conexión
            oAdapter = New SqlDataAdapter
            oConexion = New SqlConnection(vl_stConexionRed)

            ' abre la conexion
            oConexion.Open()

            ' parametros de la consulta
            Dim ParametrosConsulta As String = ""

            ' Concatena la condicion de la consulta
            ParametrosConsulta += "SELECT * "
            ParametrosConsulta += "FROM VIGENCIA "

            ' ejecuta la consulta
            oEjecutar = New SqlCommand(ParametrosConsulta, oConexion)

            ' procesa la consulta 
            oEjecutar.CommandTimeout = 0
            oEjecutar.CommandType = CommandType.Text
            oAdapter.SelectCommand = oEjecutar

            ' llena el datatable 
            oAdapter.Fill(dt_VIGENCIA)

            ' cierra la conexion
            oConexion.Close()

            ' retorna la tabla
            Return dt_VIGENCIA

        Catch ex As Exception
            Return Nothing
        End Try

    End Function
    Private Function fun_ListadoDeDatos_CATESUEL() As DataTable

        Try
            ' crea el datatable
            dt_CATESUEL = New DataTable

            ' crear conexión
            oAdapter = New SqlDataAdapter
            oConexion = New SqlConnection(vl_stConexionRed)

            ' abre la conexion
            oConexion.Open()

            ' parametros de la consulta
            Dim ParametrosConsulta As String = ""

            ' Concatena la condicion de la consulta
            ParametrosConsulta += "SELECT * "
            ParametrosConsulta += "FROM MANT_CATESUEL "

            ' ejecuta la consulta
            oEjecutar = New SqlCommand(ParametrosConsulta, oConexion)

            ' procesa la consulta 
            oEjecutar.CommandTimeout = 0
            oEjecutar.CommandType = CommandType.Text
            oAdapter.SelectCommand = oEjecutar

            ' llena el datatable 
            oAdapter.Fill(dt_CATESUEL)

            ' cierra la conexion
            oConexion.Close()

            ' retorna la tabla
            Return dt_CATESUEL

        Catch ex As Exception
            Return Nothing
        End Try

    End Function
    Private Function fun_ListadoDeDatos_DESTECON() As DataTable

        Try
            ' crea el datatable
            dt_DESTECON = New DataTable

            ' crear conexión
            oAdapter = New SqlDataAdapter
            oConexion = New SqlConnection(vl_stConexionRed)

            ' abre la conexion
            oConexion.Open()

            ' parametros de la consulta
            Dim ParametrosConsulta As String = ""

            ' Concatena la condicion de la consulta
            ParametrosConsulta += "SELECT * "
            ParametrosConsulta += "FROM MANT_DESTECON "

            ' ejecuta la consulta
            oEjecutar = New SqlCommand(ParametrosConsulta, oConexion)

            ' procesa la consulta 
            oEjecutar.CommandTimeout = 0
            oEjecutar.CommandType = CommandType.Text
            oAdapter.SelectCommand = oEjecutar

            ' llena el datatable 
            oAdapter.Fill(dt_DESTECON)

            ' cierra la conexion
            oConexion.Close()

            ' retorna la tabla
            Return dt_DESTECON

        Catch ex As Exception
            Return Nothing
        End Try

    End Function
    Private Function fun_ListadoDeDatos_CARAPRED() As DataTable

        Try
            ' crea el datatable
            dt_CARAPRED = New DataTable

            ' crear conexión
            oAdapter = New SqlDataAdapter
            oConexion = New SqlConnection(vl_stConexionRed)

            ' abre la conexion
            oConexion.Open()

            ' parametros de la consulta
            Dim ParametrosConsulta As String = ""

            ' Concatena la condicion de la consulta
            ParametrosConsulta += "SELECT * "
            ParametrosConsulta += "FROM MANT_CARAPRED "

            ' ejecuta la consulta
            oEjecutar = New SqlCommand(ParametrosConsulta, oConexion)

            ' procesa la consulta 
            oEjecutar.CommandTimeout = 0
            oEjecutar.CommandType = CommandType.Text
            oAdapter.SelectCommand = oEjecutar

            ' llena el datatable 
            oAdapter.Fill(dt_CARAPRED)

            ' cierra la conexion
            oConexion.Close()

            ' retorna la tabla
            Return dt_CARAPRED

        Catch ex As Exception
            Return Nothing
        End Try

    End Function
    Private Function fun_ListadoDeDatos_MODOADQU() As DataTable

        Try
            ' crea el datatable
            dt_MODOADQU = New DataTable

            ' crear conexión
            oAdapter = New SqlDataAdapter
            oConexion = New SqlConnection(vl_stConexionRed)

            ' abre la conexion
            oConexion.Open()

            ' parametros de la consulta
            Dim ParametrosConsulta As String = ""

            ' Concatena la condicion de la consulta
            ParametrosConsulta += "SELECT * "
            ParametrosConsulta += "FROM MANT_MODOADQU "

            ' ejecuta la consulta
            oEjecutar = New SqlCommand(ParametrosConsulta, oConexion)

            ' procesa la consulta 
            oEjecutar.CommandTimeout = 0
            oEjecutar.CommandType = CommandType.Text
            oAdapter.SelectCommand = oEjecutar

            ' llena el datatable 
            oAdapter.Fill(dt_MODOADQU)

            ' cierra la conexion
            oConexion.Close()

            ' retorna la tabla
            Return dt_MODOADQU

        Catch ex As Exception
            Return Nothing
        End Try

    End Function
    Private Function fun_ListadoDeDatos_CALIPROP() As DataTable

        Try
            ' crea el datatable
            dt_CALIPROP = New DataTable

            ' crear conexión
            oAdapter = New SqlDataAdapter
            oConexion = New SqlConnection(vl_stConexionRed)

            ' abre la conexion
            oConexion.Open()

            ' parametros de la consulta
            Dim ParametrosConsulta As String = ""

            ' Concatena la condicion de la consulta
            ParametrosConsulta += "SELECT * "
            ParametrosConsulta += "FROM MANT_CALIPROP "

            ' ejecuta la consulta
            oEjecutar = New SqlCommand(ParametrosConsulta, oConexion)

            ' procesa la consulta 
            oEjecutar.CommandTimeout = 0
            oEjecutar.CommandType = CommandType.Text
            oAdapter.SelectCommand = oEjecutar

            ' llena el datatable 
            oAdapter.Fill(dt_CALIPROP)

            ' cierra la conexion
            oConexion.Close()

            ' retorna la tabla
            Return dt_CALIPROP

        Catch ex As Exception
            Return Nothing
        End Try

    End Function
    Private Function fun_ListadoDeDatos_TIPODOCU() As DataTable

        Try
            ' crea el datatable
            dt_TIPODOCU = New DataTable

            ' crear conexión
            oAdapter = New SqlDataAdapter
            oConexion = New SqlConnection(vl_stConexionRed)

            ' abre la conexion
            oConexion.Open()

            ' parametros de la consulta
            Dim ParametrosConsulta As String = ""

            ' Concatena la condicion de la consulta
            ParametrosConsulta += "SELECT * "
            ParametrosConsulta += "FROM MANT_TIPODOCU "

            ' ejecuta la consulta
            oEjecutar = New SqlCommand(ParametrosConsulta, oConexion)

            ' procesa la consulta 
            oEjecutar.CommandTimeout = 0
            oEjecutar.CommandType = CommandType.Text
            oAdapter.SelectCommand = oEjecutar

            ' llena el datatable 
            oAdapter.Fill(dt_TIPODOCU)

            ' cierra la conexion
            oConexion.Close()

            ' retorna la tabla
            Return dt_TIPODOCU

        Catch ex As Exception
            Return Nothing
        End Try

    End Function
    Private Function fun_ListadoDeDatos_CLASCONS() As DataTable

        Try
            ' crea el datatable
            dt_CLASCONS = New DataTable

            ' crear conexión
            oAdapter = New SqlDataAdapter
            oConexion = New SqlConnection(vl_stConexionRed)

            ' abre la conexion
            oConexion.Open()

            ' parametros de la consulta
            Dim ParametrosConsulta As String = ""

            ' Concatena la condicion de la consulta
            ParametrosConsulta += "SELECT * "
            ParametrosConsulta += "FROM MANT_CLASCONS "

            ' ejecuta la consulta
            oEjecutar = New SqlCommand(ParametrosConsulta, oConexion)

            ' procesa la consulta 
            oEjecutar.CommandTimeout = 0
            oEjecutar.CommandType = CommandType.Text
            oAdapter.SelectCommand = oEjecutar

            ' llena el datatable 
            oAdapter.Fill(dt_CLASCONS)

            ' cierra la conexion
            oConexion.Close()

            ' retorna la tabla
            Return dt_CLASCONS

        Catch ex As Exception
            Return Nothing
        End Try

    End Function
    Private Function fun_ListadoDeDatos_TIPOCALI() As DataTable

        Try
            ' crea el datatable
            dt_TIPOCALI = New DataTable

            ' crear conexión
            oAdapter = New SqlDataAdapter
            oConexion = New SqlConnection(vl_stConexionRed)

            ' abre la conexion
            oConexion.Open()

            ' parametros de la consulta
            Dim ParametrosConsulta As String = ""

            ' Concatena la condicion de la consulta
            ParametrosConsulta += "SELECT * "
            ParametrosConsulta += "FROM MANT_TIPOCALI "

            ' ejecuta la consulta
            oEjecutar = New SqlCommand(ParametrosConsulta, oConexion)

            ' procesa la consulta 
            oEjecutar.CommandTimeout = 0
            oEjecutar.CommandType = CommandType.Text
            oAdapter.SelectCommand = oEjecutar

            ' llena el datatable 
            oAdapter.Fill(dt_TIPOCALI)

            ' cierra la conexion
            oConexion.Close()

            ' retorna la tabla
            Return dt_TIPOCALI

        Catch ex As Exception
            Return Nothing
        End Try

    End Function
    Private Function fun_ListadoDeDatos_PUNTCARD() As DataTable

        Try
            ' crea el datatable
            dt_PUNTCARD = New DataTable

            ' crear conexión
            oAdapter = New SqlDataAdapter
            oConexion = New SqlConnection(vl_stConexionRed)

            ' abre la conexion
            oConexion.Open()

            ' parametros de la consulta
            Dim ParametrosConsulta As String = ""

            ' Concatena la condicion de la consulta
            ParametrosConsulta += "SELECT * "
            ParametrosConsulta += "FROM MANT_PUNTCARD "

            ' ejecuta la consulta
            oEjecutar = New SqlCommand(ParametrosConsulta, oConexion)

            ' procesa la consulta 
            oEjecutar.CommandTimeout = 0
            oEjecutar.CommandType = CommandType.Text
            oAdapter.SelectCommand = oEjecutar

            ' llena el datatable 
            oAdapter.Fill(dt_PUNTCARD)

            ' cierra la conexion
            oConexion.Close()

            ' retorna la tabla
            Return dt_PUNTCARD

        Catch ex As Exception
            Return Nothing
        End Try

    End Function
    Private Function fun_ListadoDeDatos_TERCERO() As DataTable

        Try
            ' crea el datatable
            dt_TERCERO = New DataTable

            ' crear conexión
            oAdapter = New SqlDataAdapter
            oConexion = New SqlConnection(vl_stConexionRed)

            ' abre la conexion
            oConexion.Open()

            ' parametros de la consulta
            Dim ParametrosConsulta As String = ""

            ' Concatena la condicion de la consulta
            ParametrosConsulta += "SELECT * "
            ParametrosConsulta += "FROM TERCERO "

            ' ejecuta la consulta
            oEjecutar = New SqlCommand(ParametrosConsulta, oConexion)

            ' procesa la consulta 
            oEjecutar.CommandTimeout = 0
            oEjecutar.CommandType = CommandType.Text
            oAdapter.SelectCommand = oEjecutar

            ' llena el datatable 
            oAdapter.Fill(dt_TERCERO)

            ' cierra la conexion
            oConexion.Close()

            ' retorna la tabla
            Return dt_TERCERO

        Catch ex As Exception
            Return Nothing
        End Try

    End Function

#End Region

#Region "MENU"

    Private Sub cmdSeleccionResolucion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSeleccionResolucion.Click

        Try
            ' seleccina ninguna resolución
            vp_inConsulta = 0

            ' llama el formulario de consulta
            frm_consultar_RESOLUCION_EXPORTAR_FICHPRED.ShowDialog()

            ' verifica si hay alguna seleccionada
            If vp_inConsulta <> 0 Then

                Dim objdatos As New cla_RESOLUCION
                Dim tbl As New DataTable

                tbl = objdatos.fun_Buscar_ID_RESOLUCION(vp_inConsulta)

                ' coloca los valores en los campos
                Me.txtRESODEPA.Text = CType(fun_Formato_Mascara_2_Reales(tbl.Rows(0).Item("RESODEPA")), String)
                Me.txtRESOMUNI.Text = CType(fun_Formato_Mascara_3_Reales(tbl.Rows(0).Item("RESOMUNI")), String)
                Me.txtRESOTIRE.Text = CType(fun_Formato_Mascara_3_Reales(tbl.Rows(0).Item("RESOTIRE")), String)
                Me.txtRESOCLSE.Text = Trim(tbl.Rows(0).Item("RESOCLSE"))
                Me.txtRESOVIGE.Text = CType(fun_Formato_Mascara_4_Reales(tbl.Rows(0).Item("RESOVIGE")), String)
                Me.txtRESOCODI.Text = CType(fun_Formato_Mascara_7_Reales(tbl.Rows(0).Item("RESOCODI")), String)
                Me.lblRESODESC.Text = Trim(tbl.Rows(0).Item("RESODESC"))

                ' coloca la lista de valores
                Me.lblRESODEPA.Text = CType(fun_Buscar_Lista_Valores_DEPARTAMENTO(Trim(Me.txtRESODEPA.Text)), String)
                Me.lblRESOMUNI.Text = CType(fun_Buscar_Lista_Valores_MUNICIPIO(Trim(Me.txtRESODEPA.Text), Trim(Me.txtRESOMUNI.Text)), String)
                Me.lblRESOTIRE.Text = CType(fun_Buscar_Lista_Valores_TIPORESO(Trim(Me.txtRESOTIRE.Text)), String)
                Me.lblRESOCLSE.Text = CType(fun_Buscar_Lista_Valores_CLASSECT(Trim(Me.txtRESOCLSE.Text)), String)
                Me.lblRESOVIGE.Text = CType(fun_Buscar_Lista_Valores_VIGENCIA(Trim(Me.txtRESOVIGE.Text)), String)

            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub cmdGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGuardar.Click

        Try
            If vp_Instancia = "RED" Then
                MessageBox.Show("No se puede ejecutar el proceso desde una conexión en RED", "Mensaje ...", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1)
            Else
                Me.cmdGuardar.Enabled = False

                ' lista de conexiones
                pro_AlmacenarConexion()

                ' verifica que exista la resolución
                Dim boResolucionExistente As Boolean = False

                vl_stRESODEPA = CStr(Trim(Me.txtRESODEPA.Text))
                vl_stRESOMUNI = CStr(Trim(Me.txtRESOMUNI.Text))
                vl_inRESOTIRE = CStr(Trim(Me.txtRESOTIRE.Text))
                vl_inRESOCLSE = CStr(Trim(Me.txtRESOCLSE.Text))
                vl_inRESOVIGE = CStr(Trim(Me.txtRESOVIGE.Text))
                vl_inRESOCODI = CStr(Trim(Me.txtRESOCODI.Text))

                If fun_Verificar_RESOLUCION(vl_stRESODEPA, vl_stRESOMUNI, vl_inRESOTIRE, vl_inRESOCLSE, vl_inRESOVIGE, vl_inRESOCODI) = False Then
                    MessageBox.Show("Resolución no existe en el servidor", "Mensaje ...", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1)
                Else

                    ' se limpian las tablas
                    dt_RESOLUCION = New DataTable
                    dt_FICHPRED = New DataTable
                    dt_FICHRESU = New DataTable
                    dt_FIPRDEEC = New DataTable
                    dt_FIPRPROP = New DataTable
                    dt_FIPRCONS = New DataTable
                    dt_FIPRCACO = New DataTable
                    dt_FIPRLIND = New DataTable
                    dt_FIPRCART = New DataTable
                    dt_FIPRZOEC = New DataTable
                    dt_FIPRZOFI = New DataTable
                    dt_PROPANTE = New DataTable

                    ' tablas de mantenimiento
                    dt_ESTADO = New DataTable
                    dt_CLASSECT = New DataTable
                    dt_VIGENCIA = New DataTable
                    dt_CATESUEL = New DataTable
                    dt_DESTECON = New DataTable
                    dt_CARAPRED = New DataTable
                    dt_MODOADQU = New DataTable
                    dt_CALIPROP = New DataTable
                    dt_TIPODOCU = New DataTable
                    dt_DEPARTAMENTO = New DataTable
                    dt_MUNICIPIO = New DataTable
                    dt_NOTARIA = New DataTable
                    dt_CAUSACTO = New DataTable
                    dt_CLASCONS = New DataTable
                    dt_TIPOCONS = New DataTable
                    dt_PUNTCARD = New DataTable
                    dt_ZONAECON = New DataTable
                    dt_ZONAFISI = New DataTable
                    dt_TIPOCALI = New DataTable
                    dt_TERCERO = New DataTable

                    ' tablas de mantenimiento
                    dt_ESTADO = fun_ListadoDeDatos_ESTADO()
                    dt_CLASSECT = fun_ListadoDeDatos_CLASSECT()
                    dt_VIGENCIA = fun_ListadoDeDatos_VIGENCIA()
                    dt_CATESUEL = fun_ListadoDeDatos_CATESUEL()
                    dt_DESTECON = fun_ListadoDeDatos_DESTECON()
                    dt_CARAPRED = fun_ListadoDeDatos_CARAPRED()
                    dt_MODOADQU = fun_ListadoDeDatos_MODOADQU()
                    dt_CALIPROP = fun_ListadoDeDatos_CALIPROP()
                    dt_TIPODOCU = fun_ListadoDeDatos_TIPODOCU()
                    dt_DEPARTAMENTO = fun_ListadoDeDatos_DEPARTAMENTO()
                    dt_MUNICIPIO = fun_ListadoDeDatos_MUNICIPIO()
                    dt_NOTARIA = fun_ListadoDeDatos_NOTARIA()
                    dt_CAUSACTO = fun_ListadoDeDatos_CAUSACTO()
                    dt_CLASCONS = fun_ListadoDeDatos_CLASCONS()
                    dt_TIPOCONS = fun_ListadoDeDatos_TIPOCONS(vl_stRESOMUNI, vl_inRESOCLSE)
                    dt_PUNTCARD = fun_ListadoDeDatos_PUNTCARD()
                    dt_ZONAECON = fun_ListadoDeDatos_ZONAECON(vl_stRESOMUNI, vl_inRESOCLSE)
                    dt_ZONAFISI = fun_ListadoDeDatos_ZONAFISI(vl_stRESOMUNI, vl_inRESOCLSE)
                    dt_TIPOCALI = fun_ListadoDeDatos_TIPOCALI()
                    dt_TERCERO = fun_ListadoDeDatos_TERCERO()

                    ' se ejecuta las consultas
                    dt_FICHPRED = fun_ListadoDeDatos_FICHPRED(vl_stRESOMUNI, vl_inRESOCLSE)
                    dt_FICHRESU = fun_ListadoDeDatos_FICHRESU(vl_stRESOMUNI, vl_inRESOCLSE)
                    dt_FIPRDEEC = fun_ListadoDeDatos_FIPRDEEC(vl_stRESOMUNI, vl_inRESOCLSE)
                    dt_FIPRPROP = fun_ListadoDeDatos_FIPRPROP(vl_stRESOMUNI, vl_inRESOCLSE)
                    dt_FIPRCONS = fun_ListadoDeDatos_FIPRCONS(vl_stRESOMUNI, vl_inRESOCLSE)
                    dt_FIPRCACO = fun_ListadoDeDatos_FIPRCACO(vl_stRESOMUNI, vl_inRESOCLSE)
                    dt_FIPRLIND = fun_ListadoDeDatos_FIPRLIND(vl_stRESOMUNI, vl_inRESOCLSE)
                    dt_FIPRCART = fun_ListadoDeDatos_FIPRCART(vl_stRESOMUNI, vl_inRESOCLSE)
                    dt_FIPRZOEC = fun_ListadoDeDatos_FIPRZOEC(vl_stRESOMUNI, vl_inRESOCLSE)
                    dt_FIPRZOFI = fun_ListadoDeDatos_FIPRZOFI(vl_stRESOMUNI, vl_inRESOCLSE)
                    dt_PROPANTE = fun_ListadoDeDatos_PROPANTE(vl_stRESOMUNI, vl_inRESOCLSE)

                    ' contador de registro
                    vl_inContadorTotal = dt_FICHPRED.Rows.Count + _
                                         dt_FICHRESU.Rows.Count + _
                                         dt_FIPRDEEC.Rows.Count + _
                                         dt_FIPRPROP.Rows.Count + _
                                         dt_FIPRCONS.Rows.Count + _
                                         dt_FIPRCACO.Rows.Count + _
                                         dt_FIPRLIND.Rows.Count + _
                                         dt_FIPRCART.Rows.Count + _
                                         dt_FIPRZOEC.Rows.Count + _
                                         dt_FIPRZOFI.Rows.Count + _
                                         dt_PROPANTE.Rows.Count + _
                                         dt_ESTADO.Rows.Count + _
                                         dt_CLASSECT.Rows.Count + _
                                         dt_VIGENCIA.Rows.Count + _
                                         dt_CATESUEL.Rows.Count + _
                                         dt_DESTECON.Rows.Count + _
                                         dt_CARAPRED.Rows.Count + _
                                         dt_MODOADQU.Rows.Count + _
                                         dt_CALIPROP.Rows.Count + _
                                         dt_TIPODOCU.Rows.Count + _
                                         dt_DEPARTAMENTO.Rows.Count + _
                                         dt_MUNICIPIO.Rows.Count + _
                                         dt_NOTARIA.Rows.Count + _
                                         dt_CAUSACTO.Rows.Count + _
                                         dt_CLASCONS.Rows.Count + _
                                         dt_TIPOCONS.Rows.Count + _
                                         dt_PUNTCARD.Rows.Count + _
                                         dt_ZONAECON.Rows.Count + _
                                         dt_ZONAFISI.Rows.Count + _
                                         dt_TIPOCALI.Rows.Count + _
                                         dt_TERCERO.Rows.Count


                    If MessageBox.Show("Desea realizar la copia de N° " & vl_inContadorTotal & " registros catastrales.", "Mensaje ...", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then

                        ' elimina los tados de ficha predial y resumen
                        If Me.chkSobrescribirDatos.Checked = True Then

                            ' elimina ficha predial
                            If Trim(Me.txtRESOMUNI.Text) <> "" And _
                               Trim(Me.txtRESOCLSE.Text) <> "" Then

                                If fun_Verificar_Dato_Numerico_Evento_Validated(Trim(Me.txtRESOMUNI.Text)) = True And _
                                   fun_Verificar_Dato_Numerico_Evento_Validated(Trim(Me.txtRESOCLSE.Text)) = True Then

                                    Dim objFichaPredial11 As New cla_FICHPRED
                                    objFichaPredial11.fun_Eliminar_DB_FICHA_PREDIAL(Trim(Me.txtRESOMUNI.Text), Trim(Me.txtRESOCLSE.Text))

                                    Dim objFichaPredial12 As New cla_FICHPRED
                                    objFichaPredial12.fun_Eliminar_DB_FICHA_RESUMEN(Trim(Me.txtRESOMUNI.Text), Trim(Me.txtRESOCLSE.Text))

                                End If

                            End If

                        End If

                        ' Valores predeterminados ProgressBar
                        Me.pbPROCESO1.Value = 0
                        Me.pbPROCESO2.Value = 0

                        Me.pbPROCESO2.Maximum = vl_inContadorTotal

                        vl_inContadorParcial = 0
                        vl_inContadorTotal = 0

                        Timer2.Enabled = True
                        Timer1.Enabled = True

                        '========================================================
                        ' inserta los registros ESTADO
                        '========================================================
                        Me.pbPROCESO1.Maximum = dt_ESTADO.Rows.Count

                        Dim i_30 As Integer = 0

                        For i_30 = 0 To dt_ESTADO.Rows.Count - 1

                            Dim ob_ESTADO As New cla_ESTADO
                            Dim dt_ESTADO_LOCAL As New DataTable

                            dt_ESTADO_LOCAL = ob_ESTADO.fun_Buscar_CODIGO_ESTADO(dt_ESTADO.Rows(i_30).Item("ESTACODI"))

                            If dt_ESTADO_LOCAL.Rows.Count = 0 Then

                                ob_ESTADO.fun_Insertar_ESTADO(dt_ESTADO.Rows(i_30).Item("ESTACODI"), _
                                                              dt_ESTADO.Rows(i_30).Item("ESTADESC"), _
                                                              dt_ESTADO.Rows(i_30).Item("ESTAESTA"))

                            End If

                            ' Incrementa la barra
                            vl_inContadorParcial = vl_inContadorParcial + 1
                            vl_inContadorTotal = vl_inContadorTotal + 1

                            Me.pbPROCESO1.Value = vl_inContadorParcial
                            Me.pbPROCESO2.Value = vl_inContadorTotal

                        Next

                        Me.pbPROCESO1.Value = 0
                        vl_inContadorParcial = 0

                        '========================================================
                        ' inserta los registros CLASE O SECTOR
                        '========================================================
                        Me.pbPROCESO1.Maximum = dt_CLASSECT.Rows.Count

                        Dim i_12 As Integer = 0

                        For i_12 = 0 To dt_CLASSECT.Rows.Count - 1

                            Dim ob_CLASSECT As New cla_CLASSECT
                            Dim dt_CLASSECT_LOCAL As New DataTable

                            dt_CLASSECT_LOCAL = ob_CLASSECT.fun_Buscar_CODIGO_MANT_CLASSECT(dt_CLASSECT.Rows(i_12).Item("CLSECODI"))

                            If dt_CLASSECT_LOCAL.Rows.Count = 0 Then

                                ob_CLASSECT.fun_Insertar_MANT_CLASSECT(dt_CLASSECT.Rows(i_12).Item("CLSECODI"), _
                                                                       dt_CLASSECT.Rows(i_12).Item("CLSEDESC"), _
                                                                       dt_CLASSECT.Rows(i_12).Item("CLSEESTA"))

                            End If

                            ' Incrementa la barra
                            vl_inContadorParcial = vl_inContadorParcial + 1
                            vl_inContadorTotal = vl_inContadorTotal + 1

                            Me.pbPROCESO1.Value = vl_inContadorParcial
                            Me.pbPROCESO2.Value = vl_inContadorTotal

                        Next

                        Me.pbPROCESO1.Value = 0
                        vl_inContadorParcial = 0

                        '========================================================
                        ' inserta los registros VIGENCIA
                        '========================================================
                        Me.pbPROCESO1.Maximum = dt_VIGENCIA.Rows.Count

                        Dim i_29 As Integer = 0

                        For i_29 = 0 To dt_VIGENCIA.Rows.Count - 1

                            Dim ob_VIGENCIA As New cla_VIGENCIA
                            Dim dt_VIGENCIA_LOCAL As New DataTable

                            dt_VIGENCIA_LOCAL = ob_VIGENCIA.fun_Buscar_CODIGO_VIGENCIA(dt_VIGENCIA.Rows(i_29).Item("VIGECODI"))

                            If dt_VIGENCIA_LOCAL.Rows.Count = 0 Then

                                ob_VIGENCIA.fun_Insertar_VIGENCIA(dt_VIGENCIA.Rows(i_29).Item("VIGECODI"), _
                                                                  dt_VIGENCIA.Rows(i_29).Item("VIGEDESC"), _
                                                                  dt_VIGENCIA.Rows(i_29).Item("VIGEESTA"))

                            End If

                            ' Incrementa la barra
                            vl_inContadorParcial = vl_inContadorParcial + 1
                            vl_inContadorTotal = vl_inContadorTotal + 1

                            Me.pbPROCESO1.Value = vl_inContadorParcial
                            Me.pbPROCESO2.Value = vl_inContadorTotal

                        Next

                        Me.pbPROCESO1.Value = 0
                        vl_inContadorParcial = 0

                        '========================================================
                        ' inserta los registros CATEGORIA DE SUELO
                        '========================================================
                        Me.pbPROCESO1.Maximum = dt_CATESUEL.Rows.Count

                        Dim i_13 As Integer = 0

                        For i_13 = 0 To dt_CATESUEL.Rows.Count - 1

                            Dim ob_CATESUEL As New cla_CATESUEL
                            Dim dt_CATESUEL_LOCAL As New DataTable

                            dt_CATESUEL_LOCAL = ob_CATESUEL.fun_Buscar_CODIGO_MANT_CATESUEL(dt_CATESUEL.Rows(i_13).Item("CASUCODI"))

                            If dt_CATESUEL_LOCAL.Rows.Count = 0 Then

                                ob_CATESUEL.fun_Insertar_MANT_CATESUEL(dt_CATESUEL.Rows(i_13).Item("CASUCODI"), _
                                                                       dt_CATESUEL.Rows(i_13).Item("CASUDESC"), _
                                                                       dt_CATESUEL.Rows(i_13).Item("CASUESTA"))

                            End If

                            ' Incrementa la barra
                            vl_inContadorParcial = vl_inContadorParcial + 1
                            vl_inContadorTotal = vl_inContadorTotal + 1

                            Me.pbPROCESO1.Value = vl_inContadorParcial
                            Me.pbPROCESO2.Value = vl_inContadorTotal

                        Next

                        Me.pbPROCESO1.Value = 0
                        vl_inContadorParcial = 0

                        '========================================================
                        ' inserta los registros DESTINACIÓN ECONÓMICA
                        '========================================================
                        Me.pbPROCESO1.Maximum = dt_DESTECON.Rows.Count

                        Dim i_14 As Integer = 0

                        For i_14 = 0 To dt_DESTECON.Rows.Count - 1

                            Dim ob_DESTECON As New cla_DESTECON
                            Dim dt_DESTECON_LOCAL As New DataTable

                            dt_DESTECON_LOCAL = ob_DESTECON.fun_Buscar_CODIGO_MANT_DESTECON(dt_DESTECON.Rows(i_14).Item("DEECCODI"))

                            If dt_DESTECON_LOCAL.Rows.Count = 0 Then

                                ob_DESTECON.fun_Insertar_MANT_DESTECON(dt_DESTECON.Rows(i_14).Item("DEECCODI"), _
                                                                       dt_DESTECON.Rows(i_14).Item("DEECDESC"), _
                                                                       dt_DESTECON.Rows(i_14).Item("DEECESTA"), _
                                                                       dt_DESTECON.Rows(i_14).Item("DEECLOTE"))

                            End If

                            ' Incrementa la barra
                            vl_inContadorParcial = vl_inContadorParcial + 1
                            vl_inContadorTotal = vl_inContadorTotal + 1

                            Me.pbPROCESO1.Value = vl_inContadorParcial
                            Me.pbPROCESO2.Value = vl_inContadorTotal

                        Next

                        Me.pbPROCESO1.Value = 0
                        vl_inContadorParcial = 0

                        '========================================================
                        ' inserta los registros CARACTERISTICA DE PREDIO
                        '========================================================
                        Me.pbPROCESO1.Maximum = dt_CARAPRED.Rows.Count

                        Dim i_15 As Integer = 0

                        For i_15 = 0 To dt_CARAPRED.Rows.Count - 1

                            Dim ob_CARAPRED As New cla_CARAPRED
                            Dim dt_CARAPRED_LOCAL As New DataTable

                            dt_CARAPRED_LOCAL = ob_CARAPRED.fun_Buscar_CODIGO_MANT_CARAPRED(dt_CARAPRED.Rows(i_15).Item("CAPRCODI"))

                            If dt_CARAPRED_LOCAL.Rows.Count = 0 Then

                                ob_CARAPRED.fun_Insertar_MANT_CARAPRED(dt_CARAPRED.Rows(i_15).Item("CAPRCODI"), _
                                                                       dt_CARAPRED.Rows(i_15).Item("CAPRDESC"), _
                                                                       dt_CARAPRED.Rows(i_15).Item("CAPRESTA"))

                            End If

                            ' Incrementa la barra
                            vl_inContadorParcial = vl_inContadorParcial + 1
                            vl_inContadorTotal = vl_inContadorTotal + 1

                            Me.pbPROCESO1.Value = vl_inContadorParcial
                            Me.pbPROCESO2.Value = vl_inContadorTotal

                        Next

                        Me.pbPROCESO1.Value = 0
                        vl_inContadorParcial = 0

                        '========================================================
                        ' inserta los registros MODO DE ADQUISICIÓN
                        '========================================================
                        Me.pbPROCESO1.Maximum = dt_MODOADQU.Rows.Count

                        Dim i_16 As Integer = 0

                        For i_16 = 0 To dt_MODOADQU.Rows.Count - 1

                            Dim ob_MODOADQU As New cla_MODOADQU
                            Dim dt_MODOADQU_LOCAL As New DataTable

                            dt_MODOADQU_LOCAL = ob_MODOADQU.fun_Buscar_CODIGO_MANT_MODOADQU(dt_MODOADQU.Rows(i_16).Item("MOADCODI"))

                            If dt_MODOADQU_LOCAL.Rows.Count = 0 Then

                                ob_MODOADQU.fun_Insertar_MANT_MODOADQU(dt_MODOADQU.Rows(i_16).Item("MOADCODI"), _
                                                                       dt_MODOADQU.Rows(i_16).Item("MOADDESC"), _
                                                                       dt_MODOADQU.Rows(i_16).Item("MOADESTA"))

                            End If

                            ' Incrementa la barra
                            vl_inContadorParcial = vl_inContadorParcial + 1
                            vl_inContadorTotal = vl_inContadorTotal + 1

                            Me.pbPROCESO1.Value = vl_inContadorParcial
                            Me.pbPROCESO2.Value = vl_inContadorTotal

                        Next

                        Me.pbPROCESO1.Value = 0
                        vl_inContadorParcial = 0

                        '========================================================
                        ' inserta los registros CALIDAD DE PROPIETARIO
                        '========================================================
                        Me.pbPROCESO1.Maximum = dt_CALIPROP.Rows.Count

                        Dim i_17 As Integer = 0

                        For i_17 = 0 To dt_CALIPROP.Rows.Count - 1

                            Dim ob_CALIPROP As New cla_CALIPROP
                            Dim dt_CALIPROP_LOCAL As New DataTable

                            dt_CALIPROP_LOCAL = ob_CALIPROP.fun_Buscar_CODIGO_MANT_CALIPROP(dt_CALIPROP.Rows(i_17).Item("CAPRCODI"))

                            If dt_CALIPROP_LOCAL.Rows.Count = 0 Then

                                ob_CALIPROP.fun_Insertar_MANT_CALIPROP(dt_CALIPROP.Rows(i_17).Item("CAPRCODI"), _
                                                                       dt_CALIPROP.Rows(i_17).Item("CAPRDESC"), _
                                                                       dt_CALIPROP.Rows(i_17).Item("CAPRESTA"))

                            End If

                            ' Incrementa la barra
                            vl_inContadorParcial = vl_inContadorParcial + 1
                            vl_inContadorTotal = vl_inContadorTotal + 1

                            Me.pbPROCESO1.Value = vl_inContadorParcial
                            Me.pbPROCESO2.Value = vl_inContadorTotal

                        Next

                        Me.pbPROCESO1.Value = 0
                        vl_inContadorParcial = 0

                        '========================================================
                        ' inserta los registros TIPO DE DOCUMENTO
                        '========================================================
                        Me.pbPROCESO1.Maximum = dt_TIPODOCU.Rows.Count

                        Dim i_18 As Integer = 0

                        For i_18 = 0 To dt_TIPODOCU.Rows.Count - 1

                            Dim ob_TIPODOCU As New cla_TIPODOCU
                            Dim dt_TIPODOCU_LOCAL As New DataTable

                            dt_TIPODOCU_LOCAL = ob_TIPODOCU.fun_Buscar_CODIGO_MANT_TIPODOCU(dt_TIPODOCU.Rows(i_18).Item("TIDOCODI"))

                            If dt_TIPODOCU_LOCAL.Rows.Count = 0 Then

                                ob_TIPODOCU.fun_Insertar_MANT_TIPODOCU(dt_TIPODOCU.Rows(i_18).Item("TIDOCODI"), _
                                                                       dt_TIPODOCU.Rows(i_18).Item("TIDODESC"), _
                                                                       dt_TIPODOCU.Rows(i_18).Item("TIDOESTA"))

                            End If

                            ' Incrementa la barra
                            vl_inContadorParcial = vl_inContadorParcial + 1
                            vl_inContadorTotal = vl_inContadorTotal + 1

                            Me.pbPROCESO1.Value = vl_inContadorParcial
                            Me.pbPROCESO2.Value = vl_inContadorTotal

                        Next

                        Me.pbPROCESO1.Value = 0
                        vl_inContadorParcial = 0

                        '========================================================
                        ' inserta los registros DEPARTAMENTO
                        '========================================================
                        Me.pbPROCESO1.Maximum = dt_DEPARTAMENTO.Rows.Count

                        Dim i_19 As Integer = 0

                        For i_19 = 0 To dt_DEPARTAMENTO.Rows.Count - 1

                            Dim ob_DEPARTAMENTO As New cla_DEPARTAMENTO
                            Dim dt_DEPARTAMENTO_LOCAL As New DataTable

                            dt_DEPARTAMENTO_LOCAL = ob_DEPARTAMENTO.fun_Buscar_CODIGO_MANT_DEPARTAMENTO(dt_DEPARTAMENTO.Rows(i_19).Item("DEPACODI"))

                            If dt_DEPARTAMENTO_LOCAL.Rows.Count = 0 Then

                                ob_DEPARTAMENTO.fun_Insertar_MANT_DEPARTAMENTO(dt_DEPARTAMENTO.Rows(i_19).Item("DEPACODI"), _
                                                                               dt_DEPARTAMENTO.Rows(i_19).Item("DEPADESC"), _
                                                                               dt_DEPARTAMENTO.Rows(i_19).Item("DEPAESTA"))

                            End If

                            ' Incrementa la barra
                            vl_inContadorParcial = vl_inContadorParcial + 1
                            vl_inContadorTotal = vl_inContadorTotal + 1

                            Me.pbPROCESO1.Value = vl_inContadorParcial
                            Me.pbPROCESO2.Value = vl_inContadorTotal

                        Next

                        Me.pbPROCESO1.Value = 0
                        vl_inContadorParcial = 0

                        '========================================================
                        ' inserta los registros MUNICIPIO
                        '========================================================
                        Me.pbPROCESO1.Maximum = dt_MUNICIPIO.Rows.Count

                        Dim i_20 As Integer = 0

                        For i_20 = 0 To dt_MUNICIPIO.Rows.Count - 1

                            Dim ob_MUNICIPIO As New cla_MUNICIPIO
                            Dim dt_MUNICIPIO_LOCAL As New DataTable

                            dt_MUNICIPIO_LOCAL = ob_MUNICIPIO.fun_Buscar_DEPARTAMENTO_Y_CODIGO_MANT_MUNICIPIO(dt_MUNICIPIO.Rows(i_20).Item("MUNIDEPA"), _
                                                                                                              dt_MUNICIPIO.Rows(i_20).Item("MUNICODI"))

                            If dt_MUNICIPIO_LOCAL.Rows.Count = 0 Then

                                ob_MUNICIPIO.fun_Insertar_MANT_MUNICIPIO(dt_MUNICIPIO.Rows(i_20).Item("MUNIDEPA"), _
                                                                         dt_MUNICIPIO.Rows(i_20).Item("MUNICODI"), _
                                                                         dt_MUNICIPIO.Rows(i_20).Item("MUNIDESC"), _
                                                                         dt_MUNICIPIO.Rows(i_20).Item("MUNIRAIN"), _
                                                                         dt_MUNICIPIO.Rows(i_20).Item("MUNIRAFI"), _
                                                                         dt_MUNICIPIO.Rows(i_20).Item("MUNIESTA"))

                            End If

                            ' Incrementa la barra
                            vl_inContadorParcial = vl_inContadorParcial + 1
                            vl_inContadorTotal = vl_inContadorTotal + 1

                            Me.pbPROCESO1.Value = vl_inContadorParcial
                            Me.pbPROCESO2.Value = vl_inContadorTotal

                        Next

                        Me.pbPROCESO1.Value = 0
                        vl_inContadorParcial = 0

                        '========================================================
                        ' inserta los registros NOTARIA
                        '========================================================
                        Me.pbPROCESO1.Maximum = dt_NOTARIA.Rows.Count

                        Dim i_21 As Integer = 0

                        For i_21 = 0 To dt_NOTARIA.Rows.Count - 1

                            Dim ob_NOTARIA As New cla_NOTARIA
                            Dim dt_NOTARIA_LOCAL As New DataTable

                            dt_NOTARIA_LOCAL = ob_NOTARIA.fun_Buscar_DEPARTAMENTO_Y_MUNICIPIO_Y_CODIGO_MANT_NOTARIA(dt_NOTARIA.Rows(i_21).Item("NOTADEPA"), _
                                                                                                                    dt_NOTARIA.Rows(i_21).Item("NOTAMUNI"), _
                                                                                                                    dt_NOTARIA.Rows(i_21).Item("NOTACODI"))

                            If dt_NOTARIA_LOCAL.Rows.Count = 0 Then

                                ob_NOTARIA.fun_Insertar_MANT_NOTARIA(dt_NOTARIA.Rows(i_21).Item("NOTADEPA"), _
                                                                     dt_NOTARIA.Rows(i_21).Item("NOTAMUNI"), _
                                                                     dt_NOTARIA.Rows(i_21).Item("NOTACODI"), _
                                                                     dt_NOTARIA.Rows(i_21).Item("NOTADESC"), _
                                                                     dt_NOTARIA.Rows(i_21).Item("NOTAESTA"))

                            End If

                            ' Incrementa la barra
                            vl_inContadorParcial = vl_inContadorParcial + 1
                            vl_inContadorTotal = vl_inContadorTotal + 1

                            Me.pbPROCESO1.Value = vl_inContadorParcial
                            Me.pbPROCESO2.Value = vl_inContadorTotal

                        Next

                        Me.pbPROCESO1.Value = 0
                        vl_inContadorParcial = 0

                        '========================================================
                        ' inserta los registros CAUSA DEL ACTO
                        '========================================================
                        Me.pbPROCESO1.Maximum = dt_CAUSACTO.Rows.Count

                        Dim i_22 As Integer = 0

                        For i_22 = 0 To dt_CAUSACTO.Rows.Count - 1

                            Dim ob_CAUSACTO As New cla_CAUSACTO
                            Dim dt_CAUSACTO_LOCAL As New DataTable

                            dt_CAUSACTO_LOCAL = ob_CAUSACTO.fun_Buscar_CODIGO_MANT_CAUSACTO(dt_CAUSACTO.Rows(i_22).Item("CAACCODI"))

                            If dt_CAUSACTO_LOCAL.Rows.Count = 0 Then

                                ob_CAUSACTO.fun_Insertar_MANT_CAUSACTO(dt_CAUSACTO.Rows(i_22).Item("CAACCODI"), _
                                                                       dt_CAUSACTO.Rows(i_22).Item("CAACDESC"), _
                                                                       dt_CAUSACTO.Rows(i_22).Item("CAACINPR"), _
                                                                       dt_CAUSACTO.Rows(i_22).Item("CAACREPR"), _
                                                                       dt_CAUSACTO.Rows(i_22).Item("CAACINCO"), _
                                                                       dt_CAUSACTO.Rows(i_22).Item("CAACRECO"), _
                                                                       dt_CAUSACTO.Rows(i_22).Item("CAACESTA"))

                            End If

                            ' Incrementa la barra
                            vl_inContadorParcial = vl_inContadorParcial + 1
                            vl_inContadorTotal = vl_inContadorTotal + 1

                            Me.pbPROCESO1.Value = vl_inContadorParcial
                            Me.pbPROCESO2.Value = vl_inContadorTotal

                        Next

                        Me.pbPROCESO1.Value = 0
                        vl_inContadorParcial = 0

                        '========================================================
                        ' inserta los registros CLASE DE CONSTRUCCIÓN
                        '========================================================
                        Me.pbPROCESO1.Maximum = dt_CLASCONS.Rows.Count

                        Dim i_23 As Integer = 0

                        For i_23 = 0 To dt_CLASCONS.Rows.Count - 1

                            Dim ob_CLASCONS As New cla_CLASCONS
                            Dim dt_CLASCONS_LOCAL As New DataTable

                            dt_CLASCONS_LOCAL = ob_CLASCONS.fun_Buscar_CODIGO_MANT_CLASCONS(dt_CLASCONS.Rows(i_23).Item("CLCOCODI"))

                            If dt_CLASCONS_LOCAL.Rows.Count = 0 Then

                                ob_CLASCONS.fun_Insertar_MANT_CLASCONS(dt_CLASCONS.Rows(i_23).Item("CLCOCODI"), _
                                                                       dt_CLASCONS.Rows(i_23).Item("CLCODESC"), _
                                                                       dt_CLASCONS.Rows(i_23).Item("CLCOESTA"))

                            End If

                            ' Incrementa la barra
                            vl_inContadorParcial = vl_inContadorParcial + 1
                            vl_inContadorTotal = vl_inContadorTotal + 1

                            Me.pbPROCESO1.Value = vl_inContadorParcial
                            Me.pbPROCESO2.Value = vl_inContadorTotal

                        Next

                        Me.pbPROCESO1.Value = 0
                        vl_inContadorParcial = 0

                        '========================================================
                        ' inserta los registros TIPO DE CALIFICACIÓN
                        '========================================================
                        Me.pbPROCESO1.Maximum = dt_TIPOCALI.Rows.Count

                        Dim i_28 As Integer = 0

                        For i_28 = 0 To dt_TIPOCALI.Rows.Count - 1

                            Dim ob_TIPOCALI As New cla_TIPOCALI
                            Dim dt_TIPOCALI_LOCAL As New DataTable

                            dt_TIPOCALI_LOCAL = ob_TIPOCALI.fun_Buscar_CODIGO_MANT_TIPOCALI(dt_TIPOCALI.Rows(i_28).Item("TICACODI"))

                            If dt_TIPOCALI_LOCAL.Rows.Count = 0 Then

                                ob_TIPOCALI.fun_Insertar_MANT_TIPOCALI(dt_TIPOCALI.Rows(i_28).Item("TICACODI"), _
                                                                       dt_TIPOCALI.Rows(i_28).Item("TICADESC"), _
                                                                       dt_TIPOCALI.Rows(i_28).Item("TICAESTA"))

                            End If

                            ' Incrementa la barra
                            vl_inContadorParcial = vl_inContadorParcial + 1
                            vl_inContadorTotal = vl_inContadorTotal + 1

                            Me.pbPROCESO1.Value = vl_inContadorParcial
                            Me.pbPROCESO2.Value = vl_inContadorTotal

                        Next

                        Me.pbPROCESO1.Value = 0
                        vl_inContadorParcial = 0

                        '========================================================
                        ' inserta los registros TIPO DE CONSTRUCCIÓN
                        '========================================================
                        Me.pbPROCESO1.Maximum = dt_TIPOCONS.Rows.Count

                        Dim i_24 As Integer = 0

                        For i_24 = 0 To dt_TIPOCONS.Rows.Count - 1

                            Dim ob_TIPOCONS As New cla_TIPOCONS
                            Dim dt_TIPOCONS_LOCAL As New DataTable

                            dt_TIPOCONS_LOCAL = ob_TIPOCONS.fun_Buscar_DEPARTAMENTO_Y_MUNICIPIO_Y_CLASE_Y_TIPO_Y_SECTOR_Y_CODIGO_MANT_TIPOCONS(dt_TIPOCONS.Rows(i_24).Item("TICODEPA"), _
                                                                                                                                               dt_TIPOCONS.Rows(i_24).Item("TICOMUNI"), _
                                                                                                                                               dt_TIPOCONS.Rows(i_24).Item("TICOCLCO"), _
                                                                                                                                               dt_TIPOCONS.Rows(i_24).Item("TICOTIPO"), _
                                                                                                                                               dt_TIPOCONS.Rows(i_24).Item("TICOCLSE"), _
                                                                                                                                               dt_TIPOCONS.Rows(i_24).Item("TICOCODI"))

                            If dt_TIPOCONS_LOCAL.Rows.Count = 0 Then

                                ob_TIPOCONS.fun_Insertar_MANT_TIPOCONS(dt_TIPOCONS.Rows(i_24).Item("TICODEPA"), _
                                                                       dt_TIPOCONS.Rows(i_24).Item("TICOMUNI"), _
                                                                       dt_TIPOCONS.Rows(i_24).Item("TICOCLCO"), _
                                                                       dt_TIPOCONS.Rows(i_24).Item("TICOTIPO"), _
                                                                       dt_TIPOCONS.Rows(i_24).Item("TICOCODI"), _
                                                                       dt_TIPOCONS.Rows(i_24).Item("TICODESC"), _
                                                                       dt_TIPOCONS.Rows(i_24).Item("TICOPUNT"), _
                                                                       dt_TIPOCONS.Rows(i_24).Item("TICOPUMA"), _
                                                                       dt_TIPOCONS.Rows(i_24).Item("TICOFAC1"), _
                                                                       dt_TIPOCONS.Rows(i_24).Item("TICOFAC2"), _
                                                                       dt_TIPOCONS.Rows(i_24).Item("TICOMOLI"), _
                                                                       dt_TIPOCONS.Rows(i_24).Item("TICOARCO"), _
                                                                       dt_TIPOCONS.Rows(i_24).Item("TICOESTA"), _
                                                                       dt_TIPOCONS.Rows(i_24).Item("TICOCLSE"), _
                                                                       dt_TIPOCONS.Rows(i_24).Item("TICOPOIN"))

                            End If

                            ' Incrementa la barra
                            vl_inContadorParcial = vl_inContadorParcial + 1
                            vl_inContadorTotal = vl_inContadorTotal + 1

                            Me.pbPROCESO1.Value = vl_inContadorParcial
                            Me.pbPROCESO2.Value = vl_inContadorTotal

                        Next

                        Me.pbPROCESO1.Value = 0
                        vl_inContadorParcial = 0

                        '========================================================
                        ' inserta los registros PUNTO CARDINAL
                        '========================================================
                        Me.pbPROCESO1.Maximum = dt_PUNTCARD.Rows.Count

                        Dim i_25 As Integer = 0

                        For i_25 = 0 To dt_PUNTCARD.Rows.Count - 1

                            Dim ob_PUNTCARD As New cla_PUNTCARD
                            Dim dt_PUNTCARD_LOCAL As New DataTable

                            dt_PUNTCARD_LOCAL = ob_PUNTCARD.fun_Buscar_CODIGO_MANT_PUNTCARD(dt_PUNTCARD.Rows(i_25).Item("PUCACODI"))

                            If dt_PUNTCARD_LOCAL.Rows.Count = 0 Then

                                ob_PUNTCARD.fun_Insertar_MANT_PUNTCARD(dt_PUNTCARD.Rows(i_25).Item("PUCACODI"), _
                                                                       dt_PUNTCARD.Rows(i_25).Item("PUCADESC"), _
                                                                       dt_PUNTCARD.Rows(i_25).Item("PUCAESTA"))

                            End If

                            ' Incrementa la barra
                            vl_inContadorParcial = vl_inContadorParcial + 1
                            vl_inContadorTotal = vl_inContadorTotal + 1

                            Me.pbPROCESO1.Value = vl_inContadorParcial
                            Me.pbPROCESO2.Value = vl_inContadorTotal

                        Next

                        Me.pbPROCESO1.Value = 0
                        vl_inContadorParcial = 0

                        '========================================================
                        ' inserta los registros ZONA ECONÓMICA
                        '========================================================
                        Me.pbPROCESO1.Maximum = dt_ZONAECON.Rows.Count

                        Dim i_26 As Integer = 0

                        For i_26 = 0 To dt_ZONAECON.Rows.Count - 1

                            Dim ob_ZONAECON As New cla_ZONAECON
                            Dim dt_ZONAECON_LOCAL As New DataTable

                            dt_ZONAECON_LOCAL = ob_ZONAECON.fun_Buscar_DEPARTAMENTO_Y_MUNICIPIO_Y_SECTOR_Y_CODIGO_MANT_ZONAECON(dt_ZONAECON.Rows(i_26).Item("ZOECDEPA"), _
                                                                                                                                dt_ZONAECON.Rows(i_26).Item("ZOECMUNI"), _
                                                                                                                                dt_ZONAECON.Rows(i_26).Item("ZOECCLSE"), _
                                                                                                                                dt_ZONAECON.Rows(i_26).Item("ZOECCODI"))

                            If dt_ZONAECON_LOCAL.Rows.Count = 0 Then

                                ob_ZONAECON.fun_Insertar_MANT_ZONAECON(dt_ZONAECON.Rows(i_26).Item("ZOECDEPA"), _
                                                                       dt_ZONAECON.Rows(i_26).Item("ZOECMUNI"), _
                                                                       dt_ZONAECON.Rows(i_26).Item("ZOECCLSE"), _
                                                                       dt_ZONAECON.Rows(i_26).Item("ZOECCODI"), _
                                                                       dt_ZONAECON.Rows(i_26).Item("ZOECDESC"), _
                                                                       dt_ZONAECON.Rows(i_26).Item("ZOECVALO"), _
                                                                       dt_ZONAECON.Rows(i_26).Item("ZOECESTA"), _
                                                                       dt_ZONAECON.Rows(i_26).Item("ZOECZOCO"), _
                                                                       dt_ZONAECON.Rows(i_26).Item("ZOECPOIN"))

                            End If

                            ' Incrementa la barra
                            vl_inContadorParcial = vl_inContadorParcial + 1
                            vl_inContadorTotal = vl_inContadorTotal + 1

                            Me.pbPROCESO1.Value = vl_inContadorParcial
                            Me.pbPROCESO2.Value = vl_inContadorTotal

                        Next

                        Me.pbPROCESO1.Value = 0
                        vl_inContadorParcial = 0

                        '========================================================
                        ' inserta los registros ZONA FÍSICA
                        '========================================================
                        Me.pbPROCESO1.Maximum = dt_ZONAFISI.Rows.Count

                        Dim i_27 As Integer = 0

                        For i_27 = 0 To dt_ZONAFISI.Rows.Count - 1

                            Dim ob_ZONAFISI As New cla_ZONAFISI
                            Dim dt_ZONAFISI_LOCAL As New DataTable

                            dt_ZONAFISI_LOCAL = ob_ZONAFISI.fun_Buscar_DEPARTAMENTO_Y_MUNICIPIO_Y_SECTOR_Y_CODIGO_MANT_ZONAFISI(dt_ZONAFISI.Rows(i_27).Item("ZOFIDEPA"), _
                                                                                                                                dt_ZONAFISI.Rows(i_27).Item("ZOFIMUNI"), _
                                                                                                                                dt_ZONAFISI.Rows(i_27).Item("ZOFICLSE"), _
                                                                                                                                dt_ZONAFISI.Rows(i_27).Item("ZOFICODI"))

                            If dt_ZONAFISI_LOCAL.Rows.Count = 0 Then

                                ob_ZONAFISI.fun_Insertar_MANT_ZONAFISI(dt_ZONAFISI.Rows(i_27).Item("ZOFIDEPA"), _
                                                                       dt_ZONAFISI.Rows(i_27).Item("ZOFIMUNI"), _
                                                                       dt_ZONAFISI.Rows(i_27).Item("ZOFICLSE"), _
                                                                       dt_ZONAFISI.Rows(i_27).Item("ZOFICODI"), _
                                                                       dt_ZONAFISI.Rows(i_27).Item("ZOFIDESC"), _
                                                                       dt_ZONAFISI.Rows(i_27).Item("ZOECESTA"), _
                                                                       dt_ZONAFISI.Rows(i_27).Item("ZOECZOCO"))

                            End If

                            ' Incrementa la barra
                            vl_inContadorParcial = vl_inContadorParcial + 1
                            vl_inContadorTotal = vl_inContadorTotal + 1

                            Me.pbPROCESO1.Value = vl_inContadorParcial
                            Me.pbPROCESO2.Value = vl_inContadorTotal

                        Next

                        Me.pbPROCESO1.Value = 0
                        vl_inContadorParcial = 0

                        '========================================================
                        ' inserta los registros TERCERO
                        '========================================================
                        Me.pbPROCESO1.Maximum = dt_TERCERO.Rows.Count

                        Dim i_31 As Integer = 0

                        For i_31 = 0 To dt_TERCERO.Rows.Count - 1

                            Dim ob_TERCERO As New cla_TERCERO
                            Dim dt_TERCERO_LOCAL As New DataTable

                            dt_TERCERO_LOCAL = ob_TERCERO.fun_Buscar_CODIGO_TERCERO(Trim(dt_TERCERO.Rows(i_31).Item("TERCNUDO")))

                            If dt_TERCERO_LOCAL.Rows.Count = 0 Then

                                ob_TERCERO.fun_Insertar_TERCERO(dt_TERCERO.Rows(i_31).Item("TERCNUDO"), _
                                                                dt_TERCERO.Rows(i_31).Item("TERCTIDO"), _
                                                                dt_TERCERO.Rows(i_31).Item("TERCCAPR"), _
                                                                dt_TERCERO.Rows(i_31).Item("TERCSEXO"), _
                                                                dt_TERCERO.Rows(i_31).Item("TERCNOMB"), _
                                                                dt_TERCERO.Rows(i_31).Item("TERCPRAP"), _
                                                                dt_TERCERO.Rows(i_31).Item("TERCSEAP"), _
                                                                dt_TERCERO.Rows(i_31).Item("TERCSICO"), _
                                                                dt_TERCERO.Rows(i_31).Item("TERCTEL1"), _
                                                                dt_TERCERO.Rows(i_31).Item("TERCTEL2"), _
                                                                dt_TERCERO.Rows(i_31).Item("TERCFAX1"), _
                                                                dt_TERCERO.Rows(i_31).Item("TERCDIRE"), _
                                                                dt_TERCERO.Rows(i_31).Item("TERCESTA"), _
                                                                dt_TERCERO.Rows(i_31).Item("TERCOBSE"))
                            Else

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
                                ParametrosConsulta += "update TERCERO "
                                ParametrosConsulta += "set TERCTIDO = '" & CInt(dt_TERCERO.Rows(i_31).Item("TERCTIDO")) & "', "
                                ParametrosConsulta += "TERCSEXO = '" & CInt(dt_TERCERO.Rows(i_31).Item("TERCSEXO")) & "', "
                                ParametrosConsulta += "TERCCAPR = '" & CInt(dt_TERCERO.Rows(i_31).Item("TERCCAPR")) & "', "
                                ParametrosConsulta += "TERCNOMB = '" & CStr(Trim(dt_TERCERO.Rows(i_31).Item("TERCNOMB"))) & "', "
                                ParametrosConsulta += "TERCPRAP = '" & CStr(Trim(dt_TERCERO.Rows(i_31).Item("TERCPRAP"))) & "', "
                                ParametrosConsulta += "TERCSEAP = '" & CStr(Trim(dt_TERCERO.Rows(i_31).Item("TERCSEAP"))) & "', "
                                ParametrosConsulta += "TERCSICO = '" & CStr(Trim(dt_TERCERO.Rows(i_31).Item("TERCSICO"))) & "' "
                                ParametrosConsulta += "where TERCNUDO = '" & CStr(Trim(dt_TERCERO.Rows(i_31).Item("TERCNUDO"))) & "'"

                                ' ejecuta la consulta
                                oEjecutar = New SqlCommand(ParametrosConsulta, oConexion)

                                ' procesa la consulta 
                                oEjecutar.CommandTimeout = 0
                                oEjecutar.CommandType = CommandType.Text

                                oReader = oEjecutar.ExecuteReader

                                ' cierra la conexion
                                oConexion.Close()
                                oReader = Nothing

                            End If

                            ' Incrementa la barra
                            vl_inContadorParcial = vl_inContadorParcial + 1
                            vl_inContadorTotal = vl_inContadorTotal + 1

                            Me.pbPROCESO1.Value = vl_inContadorParcial
                            Me.pbPROCESO2.Value = vl_inContadorTotal

                        Next

                        Me.pbPROCESO1.Value = 0
                        vl_inContadorParcial = 0

                        '========================================================
                        ' inserta los registros de FICHA PREDIAL
                        '========================================================
                        Me.pbPROCESO1.Maximum = dt_FICHPRED.Rows.Count

                        Dim i_01 As Integer = 0

                        For i_01 = 0 To dt_FICHPRED.Rows.Count - 1

                            Dim ob_FICHPRED As New cla_FICHPRED
                            'Dim dt_FICHPRED_LOCAL As New DataTable

                            'dt_FICHPRED_LOCAL = ob_FICHPRED.fun_Consultar_FICHA_PREDIAL_X_NRO_FICHA_PREDIAL(dt_FICHPRED.Rows(i_01).Item("FIPRNUFI"))

                            'If dt_FICHPRED_LOCAL.Rows.Count = 0 Then

                            ob_FICHPRED.fun_Insertar_FICHPRED(dt_FICHPRED.Rows(i_01).Item("FIPRNUFI"), _
                                                              dt_FICHPRED.Rows(i_01).Item("FIPRVIGE"), _
                                                              dt_FICHPRED.Rows(i_01).Item("FIPRTIRE"), _
                                                              dt_FICHPRED.Rows(i_01).Item("FIPRRESO"), _
                                                              dt_FICHPRED.Rows(i_01).Item("FIPRDIRE"), _
                                                              dt_FICHPRED.Rows(i_01).Item("FIPRDESC"), _
                                                              dt_FICHPRED.Rows(i_01).Item("FIPRCONJ"), _
                                                              dt_FICHPRED.Rows(i_01).Item("FIPRFECH"), _
                                                              dt_FICHPRED.Rows(i_01).Item("FIPRNURE"), _
                                                              dt_FICHPRED.Rows(i_01).Item("FIPRDEPA"), _
                                                              dt_FICHPRED.Rows(i_01).Item("FIPRMUNI"), _
                                                              dt_FICHPRED.Rows(i_01).Item("FIPRCORR"), _
                                                              dt_FICHPRED.Rows(i_01).Item("FIPRBARR"), _
                                                              dt_FICHPRED.Rows(i_01).Item("FIPRMANZ"), _
                                                              dt_FICHPRED.Rows(i_01).Item("FIPRPRED"), _
                                                              dt_FICHPRED.Rows(i_01).Item("FIPREDIF"), _
                                                              dt_FICHPRED.Rows(i_01).Item("FIPRUNPR"), _
                                                              dt_FICHPRED.Rows(i_01).Item("FIPRCLSE"), _
                                                              dt_FICHPRED.Rows(i_01).Item("FIPRCASU"), _
                                                              dt_FICHPRED.Rows(i_01).Item("FIPRMUAN"), _
                                                              dt_FICHPRED.Rows(i_01).Item("FIPRCOAN"), _
                                                              dt_FICHPRED.Rows(i_01).Item("FIPRBAAN"), _
                                                              dt_FICHPRED.Rows(i_01).Item("FIPRMAAN"), _
                                                              dt_FICHPRED.Rows(i_01).Item("FIPRPRAN"), _
                                                              dt_FICHPRED.Rows(i_01).Item("FIPREDAN"), _
                                                              dt_FICHPRED.Rows(i_01).Item("FIPRUPAN"), _
                                                              dt_FICHPRED.Rows(i_01).Item("FIPRCSAN"), _
                                                              dt_FICHPRED.Rows(i_01).Item("FIPRCASA"), _
                                                              dt_FICHPRED.Rows(i_01).Item("FIPRCAPR"), _
                                                              dt_FICHPRED.Rows(i_01).Item("FIPRMOAD"), _
                                                              dt_FICHPRED.Rows(i_01).Item("FIPRESTA"), _
                                                              dt_FICHPRED.Rows(i_01).Item("FIPRLITI"), _
                                                              dt_FICHPRED.Rows(i_01).Item("FIPRPOLI"), _
                                                              dt_FICHPRED.Rows(i_01).Item("FIPRCORE"), _
                                                              dt_FICHPRED.Rows(i_01).Item("FIPRARTE"), _
                                                              dt_FICHPRED.Rows(i_01).Item("FIPRCOPR"), _
                                                              dt_FICHPRED.Rows(i_01).Item("FIPRCOED"), _
                                                              dt_FICHPRED.Rows(i_01).Item("FIPRTIFI"), _
                                                              dt_FICHPRED.Rows(i_01).Item("FIPRINCO"))

                            'End If

                            ' Incrementa la barra
                            vl_inContadorParcial = vl_inContadorParcial + 1
                            vl_inContadorTotal = vl_inContadorTotal + 1

                            Me.pbPROCESO1.Value = vl_inContadorParcial
                            Me.pbPROCESO2.Value = vl_inContadorTotal

                        Next

                        Me.pbPROCESO1.Value = 0
                        vl_inContadorParcial = 0

                        '========================================================
                        ' inserta los registros de FICHA RESUMEN
                        '========================================================
                        Me.pbPROCESO1.Maximum = dt_FICHRESU.Rows.Count

                        Dim i_02 As Integer = 0

                        For i_02 = 0 To dt_FICHRESU.Rows.Count - 1

                            Dim ob_FICHRESU As New cla_FICHRESU
                            'Dim dt_FIPRRESU_LOCAL As New DataTable

                            'dt_FIPRRESU_LOCAL = ob_FICHRESU.fun_buscar_CEDULA_CATASTRAL_FICHRESU(dt_FICHRESU.Rows(i_02).Item("FIPRMUNI"), _
                            '                                                                     dt_FICHRESU.Rows(i_02).Item("FIPRCORR"), _
                            '                                                                     dt_FICHRESU.Rows(i_02).Item("FIPRBARR"), _
                            '                                                                     dt_FICHRESU.Rows(i_02).Item("FIPRMANZ"), _
                            '                                                                     dt_FICHRESU.Rows(i_02).Item("FIPRPRED"), _
                            '                                                                     dt_FICHRESU.Rows(i_02).Item("FIPREDIF"), _
                            '                                                                     dt_FICHRESU.Rows(i_02).Item("FIPRUNPR"), _
                            '                                                                     dt_FICHRESU.Rows(i_02).Item("FIPRCLSE"), _
                            '                                                                     dt_FICHRESU.Rows(i_02).Item("FIPRTIFI"))

                            'If dt_FIPRRESU_LOCAL.Rows.Count = 0 Then

                            ob_FICHRESU.fun_Insertar_FICHRESU(dt_FICHRESU.Rows(i_02).Item("FIPRNUFI"), _
                                                              dt_FICHRESU.Rows(i_02).Item("FIPRVIGE"), _
                                                              dt_FICHRESU.Rows(i_02).Item("FIPRTIRE"), _
                                                              dt_FICHRESU.Rows(i_02).Item("FIPRRESO"), _
                                                              dt_FICHRESU.Rows(i_02).Item("FIPRDIRE"), _
                                                              dt_FICHRESU.Rows(i_02).Item("FIPRDESC"), _
                                                              dt_FICHRESU.Rows(i_02).Item("FIPRCONJ"), _
                                                              dt_FICHRESU.Rows(i_02).Item("FIPRFECH"), _
                                                              dt_FICHRESU.Rows(i_02).Item("FIPRNURE"), _
                                                              dt_FICHRESU.Rows(i_02).Item("FIPRDEPA"), _
                                                              dt_FICHRESU.Rows(i_02).Item("FIPRMUNI"), _
                                                              dt_FICHRESU.Rows(i_02).Item("FIPRCORR"), _
                                                              dt_FICHRESU.Rows(i_02).Item("FIPRBARR"), _
                                                              dt_FICHRESU.Rows(i_02).Item("FIPRMANZ"), _
                                                              dt_FICHRESU.Rows(i_02).Item("FIPRPRED"), _
                                                              dt_FICHRESU.Rows(i_02).Item("FIPREDIF"), _
                                                              dt_FICHRESU.Rows(i_02).Item("FIPRUNPR"), _
                                                              dt_FICHRESU.Rows(i_02).Item("FIPRCLSE"), _
                                                              dt_FICHRESU.Rows(i_02).Item("FIPRCASU"), _
                                                              dt_FICHRESU.Rows(i_02).Item("FIPRMUAN"), _
                                                              dt_FICHRESU.Rows(i_02).Item("FIPRCOAN"), _
                                                              dt_FICHRESU.Rows(i_02).Item("FIPRBAAN"), _
                                                              dt_FICHRESU.Rows(i_02).Item("FIPRMAAN"), _
                                                              dt_FICHRESU.Rows(i_02).Item("FIPRPRAN"), _
                                                              dt_FICHRESU.Rows(i_02).Item("FIPREDAN"), _
                                                              dt_FICHRESU.Rows(i_02).Item("FIPRUPAN"), _
                                                              dt_FICHRESU.Rows(i_02).Item("FIPRCSAN"), _
                                                              dt_FICHRESU.Rows(i_02).Item("FIPRCASA"), _
                                                              dt_FICHRESU.Rows(i_02).Item("FIPRCAPR"), _
                                                              dt_FICHRESU.Rows(i_02).Item("FIPRMOAD"), _
                                                              dt_FICHRESU.Rows(i_02).Item("FIPRESTA"), _
                                                              dt_FICHRESU.Rows(i_02).Item("FIPRLITI"), _
                                                              dt_FICHRESU.Rows(i_02).Item("FIPRPOLI"), _
                                                              dt_FICHRESU.Rows(i_02).Item("FIPRCORE"), _
                                                              dt_FICHRESU.Rows(i_02).Item("FIPRARTE"), _
                                                              dt_FICHRESU.Rows(i_02).Item("FIPRCOPR"), _
                                                              dt_FICHRESU.Rows(i_02).Item("FIPRCOED"), _
                                                              dt_FICHRESU.Rows(i_02).Item("FIPRTIFI"), _
                                                              dt_FICHRESU.Rows(i_02).Item("FIPRINCO"), _
                                                              dt_FICHRESU.Rows(i_02).Item("FIPRRUIM"), _
                                                              dt_FICHRESU.Rows(i_02).Item("FIPRATLO"), _
                                                              dt_FICHRESU.Rows(i_02).Item("FIPRACLO"), _
                                                              dt_FICHRESU.Rows(i_02).Item("FIPRAPLO"), _
                                                              dt_FICHRESU.Rows(i_02).Item("FIPRTOED"), _
                                                              dt_FICHRESU.Rows(i_02).Item("FIPRUNCO"), _
                                                              dt_FICHRESU.Rows(i_02).Item("FIPRURPH"), _
                                                              dt_FICHRESU.Rows(i_02).Item("FIPRAPCA"), _
                                                              dt_FICHRESU.Rows(i_02).Item("FIPRLOCA"), _
                                                              dt_FICHRESU.Rows(i_02).Item("FIPRCUUT"), _
                                                              dt_FICHRESU.Rows(i_02).Item("FIPRGACU"), _
                                                              dt_FICHRESU.Rows(i_02).Item("FIPRGADE"), _
                                                              dt_FICHRESU.Rows(i_02).Item("FIPRPISO"))

                            'End If

                            ' Incrementa la barra
                            vl_inContadorParcial = vl_inContadorParcial + 1
                            vl_inContadorTotal = vl_inContadorTotal + 1

                            Me.pbPROCESO1.Value = vl_inContadorParcial
                            Me.pbPROCESO2.Value = vl_inContadorTotal

                        Next

                        Me.pbPROCESO1.Value = 0
                        vl_inContadorParcial = 0

                        '========================================================
                        ' inserta los registros DESTINACIÓN ECONÓMICA
                        '========================================================
                        Me.pbPROCESO1.Maximum = dt_FIPRDEEC.Rows.Count

                        Dim i_03 As Integer = 0

                        For i_03 = 0 To dt_FIPRDEEC.Rows.Count - 1

                            Dim ob_FIPRDEEC As New cla_FIPRDEEC
                            'Dim dt_FIPRDEEC_LOCAL As New DataTable

                            'dt_FIPRDEEC_LOCAL = ob_FIPRDEEC.fun_Buscar_CODIGO_FIPRDEEC(dt_FIPRDEEC.Rows(i_03).Item("FPDENUFI"), _
                            '                                                           dt_FIPRDEEC.Rows(i_03).Item("FPDEDEEC"))

                            'If dt_FIPRDEEC_LOCAL.Rows.Count = 0 Then

                            ob_FIPRDEEC.fun_Insertar_FIPRDEEC(dt_FIPRDEEC.Rows(i_03).Item("FPDENUFI"), _
                                                              dt_FIPRDEEC.Rows(i_03).Item("FPDEDEEC"), _
                                                              dt_FIPRDEEC.Rows(i_03).Item("FPDEPORC"), _
                                                              dt_FIPRDEEC.Rows(i_03).Item("FPDEDEPA"), _
                                                              dt_FIPRDEEC.Rows(i_03).Item("FPDEMUNI"), _
                                                              dt_FIPRDEEC.Rows(i_03).Item("FPDETIRE"), _
                                                              dt_FIPRDEEC.Rows(i_03).Item("FPDECLSE"), _
                                                              dt_FIPRDEEC.Rows(i_03).Item("FPDEVIGE"), _
                                                              dt_FIPRDEEC.Rows(i_03).Item("FPDERESO"), _
                                                              dt_FIPRDEEC.Rows(i_03).Item("FPDESECU"), _
                                                              dt_FIPRDEEC.Rows(i_03).Item("FPDENURE"), _
                                                              dt_FIPRDEEC.Rows(i_03).Item("FPDEESTA"))

                            'End If

                            ' Incrementa la barra
                            vl_inContadorParcial = vl_inContadorParcial + 1
                            vl_inContadorTotal = vl_inContadorTotal + 1

                            Me.pbPROCESO1.Value = vl_inContadorParcial
                            Me.pbPROCESO2.Value = vl_inContadorTotal

                        Next

                        Me.pbPROCESO1.Value = 0
                        vl_inContadorParcial = 0

                        '========================================================
                        ' inserta los registros de PROPIETARIOS
                        '========================================================
                        Me.pbPROCESO1.Maximum = dt_FIPRPROP.Rows.Count

                        Dim i_04 As Integer = 0

                        For i_04 = 0 To dt_FIPRPROP.Rows.Count - 1

                            Dim ob_FIPRPROP As New cla_FIPRPROP
                            'Dim dt_FIPRPROP_LOCAL As New DataTable

                            'dt_FIPRPROP_LOCAL = ob_FIPRPROP.fun_Buscar_CODIGO_FIPRPROP(dt_FIPRPROP.Rows(i_04).Item("FPPRNUFI"), _
                            '                                                           dt_FIPRPROP.Rows(i_04).Item("FPPRNUDO"))

                            'If dt_FIPRPROP_LOCAL.Rows.Count = 0 Then

                            ob_FIPRPROP.fun_Insertar_FIPRPROP(dt_FIPRPROP.Rows(i_04).Item("FPPRNUFI"), _
                                                              dt_FIPRPROP.Rows(i_04).Item("FPPRCAPR"), _
                                                              dt_FIPRPROP.Rows(i_04).Item("FPPRSEXO"), _
                                                              dt_FIPRPROP.Rows(i_04).Item("FPPRTIDO"), _
                                                              dt_FIPRPROP.Rows(i_04).Item("FPPRNUDO"), _
                                                              dt_FIPRPROP.Rows(i_04).Item("FPPRPRAP"), _
                                                              dt_FIPRPROP.Rows(i_04).Item("FPPRSEAP"), _
                                                              dt_FIPRPROP.Rows(i_04).Item("FPPRNOMB"), _
                                                              dt_FIPRPROP.Rows(i_04).Item("FPPRDERE"), _
                                                              dt_FIPRPROP.Rows(i_04).Item("FPPRSICO"), _
                                                              dt_FIPRPROP.Rows(i_04).Item("FPPRESCR"), _
                                                              dt_FIPRPROP.Rows(i_04).Item("FPPRDENO"), _
                                                              dt_FIPRPROP.Rows(i_04).Item("FPPRMUNO"), _
                                                              dt_FIPRPROP.Rows(i_04).Item("FPPRNOTA"), _
                                                              dt_FIPRPROP.Rows(i_04).Item("FPPRFEES"), _
                                                              dt_FIPRPROP.Rows(i_04).Item("FPPRFERE"), _
                                                              dt_FIPRPROP.Rows(i_04).Item("FPPRTOMO"), _
                                                              dt_FIPRPROP.Rows(i_04).Item("FPPRMAIN"), _
                                                              dt_FIPRPROP.Rows(i_04).Item("FPPRGRAV"), _
                                                              dt_FIPRPROP.Rows(i_04).Item("FPPRMOAD"), _
                                                              dt_FIPRPROP.Rows(i_04).Item("FPPRLITI"), _
                                                              dt_FIPRPROP.Rows(i_04).Item("FPPRPOLI"), _
                                                              dt_FIPRPROP.Rows(i_04).Item("FPPRDEPA"), _
                                                              dt_FIPRPROP.Rows(i_04).Item("FPPRMUNI"), _
                                                              dt_FIPRPROP.Rows(i_04).Item("FPPRTIRE"), _
                                                              dt_FIPRPROP.Rows(i_04).Item("FPPRCLSE"), _
                                                              dt_FIPRPROP.Rows(i_04).Item("FPPRVIGE"), _
                                                              dt_FIPRPROP.Rows(i_04).Item("FPPRRESO"), _
                                                              dt_FIPRPROP.Rows(i_04).Item("FPPRSECU"), _
                                                              dt_FIPRPROP.Rows(i_04).Item("FPPRNURE"), _
                                                              dt_FIPRPROP.Rows(i_04).Item("FPPRESTA"))

                            'End If

                            ' Incrementa la barra
                            vl_inContadorParcial = vl_inContadorParcial + 1
                            vl_inContadorTotal = vl_inContadorTotal + 1

                            Me.pbPROCESO1.Value = vl_inContadorParcial
                            Me.pbPROCESO2.Value = vl_inContadorTotal

                        Next

                        Me.pbPROCESO1.Value = 0
                        vl_inContadorParcial = 0

                        '========================================================
                        ' inserta los registros de CONSTRUCCIÓN
                        '========================================================
                        Me.pbPROCESO1.Maximum = dt_FIPRCONS.Rows.Count

                        Dim i_05 As Integer = 0

                        For i_05 = 0 To dt_FIPRCONS.Rows.Count - 1

                            Dim ob_FIPRCONS As New cla_FIPRCONS
                            'Dim dt_FIPRCONS_LOCAL As New DataTable

                            'dt_FIPRCONS_LOCAL = ob_FIPRCONS.fun_Buscar_CODIGO_FIPRCONS(dt_FIPRCONS.Rows(i_05).Item("FPCONUFI"), _
                            '                                                           dt_FIPRCONS.Rows(i_05).Item("FPCOUNID"))

                            'If dt_FIPRCONS_LOCAL.Rows.Count = 0 Then

                            ob_FIPRCONS.fun_Insertar_FIPRCONS(dt_FIPRCONS.Rows(i_05).Item("FPCONUFI"), _
                                                              dt_FIPRCONS.Rows(i_05).Item("FPCOUNID"), _
                                                              dt_FIPRCONS.Rows(i_05).Item("FPCOCLCO"), _
                                                              dt_FIPRCONS.Rows(i_05).Item("FPCOTICO"), _
                                                              dt_FIPRCONS.Rows(i_05).Item("FPCOPUNT"), _
                                                              dt_FIPRCONS.Rows(i_05).Item("FPCOARCO"), _
                                                              dt_FIPRCONS.Rows(i_05).Item("FPCOACUE"), _
                                                              dt_FIPRCONS.Rows(i_05).Item("FPCOALCA"), _
                                                              dt_FIPRCONS.Rows(i_05).Item("FPCOENER"), _
                                                              dt_FIPRCONS.Rows(i_05).Item("FPCOTELE"), _
                                                              dt_FIPRCONS.Rows(i_05).Item("FPCOGAS"), _
                                                              dt_FIPRCONS.Rows(i_05).Item("FPCOPISO"), _
                                                              dt_FIPRCONS.Rows(i_05).Item("FPCOEDCO"), _
                                                              dt_FIPRCONS.Rows(i_05).Item("FPCOPOCO"), _
                                                              dt_FIPRCONS.Rows(i_05).Item("FPCOMEJO"), _
                                                              dt_FIPRCONS.Rows(i_05).Item("FPCOLEY"), _
                                                              dt_FIPRCONS.Rows(i_05).Item("FPCOAVCO"), _
                                                              dt_FIPRCONS.Rows(i_05).Item("FPCODEPA"), _
                                                              dt_FIPRCONS.Rows(i_05).Item("FPCOMUNI"), _
                                                              dt_FIPRCONS.Rows(i_05).Item("FPCOTIRE"), _
                                                              dt_FIPRCONS.Rows(i_05).Item("FPCOCLSE"), _
                                                              dt_FIPRCONS.Rows(i_05).Item("FPCOVIGE"), _
                                                              dt_FIPRCONS.Rows(i_05).Item("FPCORESO"), _
                                                              dt_FIPRCONS.Rows(i_05).Item("FPCOSECU"), _
                                                              dt_FIPRCONS.Rows(i_05).Item("FPCONURE"), _
                                                              dt_FIPRCONS.Rows(i_05).Item("FPCOESTA"))


                            'End If

                            ' Incrementa la barra
                            vl_inContadorParcial = vl_inContadorParcial + 1
                            vl_inContadorTotal = vl_inContadorTotal + 1

                            Me.pbPROCESO1.Value = vl_inContadorParcial
                            Me.pbPROCESO2.Value = vl_inContadorTotal

                        Next

                        Me.pbPROCESO1.Value = 0
                        vl_inContadorParcial = 0

                        '========================================================
                        ' inserta los registros de CALIFICACIÓN DE CONSTRUCCIÓN
                        '========================================================
                        Me.pbPROCESO1.Maximum = dt_FIPRCACO.Rows.Count

                        Dim i_06 As Integer = 0

                        For i_06 = 0 To dt_FIPRCACO.Rows.Count - 1

                            Dim ob_FIPRCACO As New cla_FIPRCACO
                            'Dim dt_FIPRCACO_LOCAL As New DataTable

                            'dt_FIPRCACO_LOCAL = ob_FIPRCACO.fun_Consultar_FIPRCACO_X_FICHA_PREDIAL(dt_FIPRCACO.Rows(i_06).Item("FPCCNUFI"), _
                            '                                                                       dt_FIPRCACO.Rows(i_06).Item("FPCCUNID"))

                            'If dt_FIPRCACO_LOCAL.Rows.Count = 0 Then

                            ob_FIPRCACO.fun_Insertar_FIPRCACO(dt_FIPRCACO.Rows(i_06).Item("FPCCNUFI"), _
                                                              dt_FIPRCACO.Rows(i_06).Item("FPCCCODI"), _
                                                              dt_FIPRCACO.Rows(i_06).Item("FPCCTIPO"), _
                                                              dt_FIPRCACO.Rows(i_06).Item("FPCCPUNT"), _
                                                              dt_FIPRCACO.Rows(i_06).Item("FPCCUNID"), _
                                                              dt_FIPRCACO.Rows(i_06).Item("FPCCCLCO"), _
                                                              dt_FIPRCACO.Rows(i_06).Item("FPCCTICO"), _
                                                              dt_FIPRCACO.Rows(i_06).Item("FPCCDEPA"), _
                                                              dt_FIPRCACO.Rows(i_06).Item("FPCCMUNI"), _
                                                              dt_FIPRCACO.Rows(i_06).Item("FPCCTIRE"), _
                                                              dt_FIPRCACO.Rows(i_06).Item("FPCCCLSE"), _
                                                              dt_FIPRCACO.Rows(i_06).Item("FPCCVIGE"), _
                                                              dt_FIPRCACO.Rows(i_06).Item("FPCCRESO"), _
                                                              dt_FIPRCACO.Rows(i_06).Item("FPCCSECU"), _
                                                              dt_FIPRCACO.Rows(i_06).Item("FPCCNURE"), _
                                                              dt_FIPRCACO.Rows(i_06).Item("FPCCESTA"))
                            'End If


                            ' Incrementa la barra
                            vl_inContadorParcial = vl_inContadorParcial + 1
                            vl_inContadorTotal = vl_inContadorTotal + 1

                            Me.pbPROCESO1.Value = vl_inContadorParcial
                            Me.pbPROCESO2.Value = vl_inContadorTotal

                        Next

                        Me.pbPROCESO1.Value = 0
                        vl_inContadorParcial = 0

                        '========================================================
                        ' inserta los registros de LINDEROS
                        '========================================================
                        Me.pbPROCESO1.Maximum = dt_FIPRLIND.Rows.Count

                        Dim i_07 As Integer = 0

                        For i_07 = 0 To dt_FIPRLIND.Rows.Count - 1

                            Dim ob_FIPRLIND As New cla_FIPRLIND
                            'Dim dt_FIPRLIND_LOCAL As New DataTable

                            'dt_FIPRLIND_LOCAL = ob_FIPRLIND.fun_Consultar_FIPRLIND_X_FICHA_PREDIAL(dt_FIPRLIND.Rows(i_07).Item("FPLINUFI"))

                            'If dt_FIPRLIND_LOCAL.Rows.Count = 0 Then

                            ob_FIPRLIND.fun_Insertar_FIPRLIND(dt_FIPRLIND.Rows(i_07).Item("FPLINUFI"), _
                                                              dt_FIPRLIND.Rows(i_07).Item("FPLIPUCA"), _
                                                              dt_FIPRLIND.Rows(i_07).Item("FPLICOLI"), _
                                                              dt_FIPRLIND.Rows(i_07).Item("FPLIDEPA"), _
                                                              dt_FIPRLIND.Rows(i_07).Item("FPLIMUNI"), _
                                                              dt_FIPRLIND.Rows(i_07).Item("FPLITIRE"), _
                                                              dt_FIPRLIND.Rows(i_07).Item("FPLICLSE"), _
                                                              dt_FIPRLIND.Rows(i_07).Item("FPLIVIGE"), _
                                                              dt_FIPRLIND.Rows(i_07).Item("FPLIRESO"), _
                                                              dt_FIPRLIND.Rows(i_07).Item("FPLISECU"), _
                                                              dt_FIPRLIND.Rows(i_07).Item("FPLINURE"), _
                                                              dt_FIPRLIND.Rows(i_07).Item("FPLIESTA"))

                            'End If

                            ' Incrementa la barra
                            vl_inContadorParcial = vl_inContadorParcial + 1
                            vl_inContadorTotal = vl_inContadorTotal + 1

                            Me.pbPROCESO1.Value = vl_inContadorParcial
                            Me.pbPROCESO2.Value = vl_inContadorTotal

                        Next

                        Me.pbPROCESO1.Value = 0
                        vl_inContadorParcial = 0

                        '========================================================
                        ' inserta los registros de CARTOGRAFIA
                        '========================================================
                        Me.pbPROCESO1.Maximum = dt_FIPRCART.Rows.Count

                        Dim i_08 As Integer = 0

                        For i_08 = 0 To dt_FIPRCART.Rows.Count - 1

                            Dim ob_FIPRCART As New cla_FIPRCART
                            'Dim dt_FIPRCART_LOCAL As New DataTable

                            'dt_FIPRCART_LOCAL = ob_FIPRCART.fun_Consultar_FIPRCART_X_FICHA_PREDIAL(dt_FIPRCART.Rows(i_08).Item("FPCANUFI"))

                            'If dt_FIPRCART_LOCAL.Rows.Count = 0 Then

                            ob_FIPRCART.fun_Insertar_FIPRCART(dt_FIPRCART.Rows(i_08).Item("FPCANUFI"), _
                                                              dt_FIPRCART.Rows(i_08).Item("FPCAPLAN"), _
                                                              dt_FIPRCART.Rows(i_08).Item("FPCAVENT"), _
                                                              dt_FIPRCART.Rows(i_08).Item("FPCAESGR"), _
                                                              dt_FIPRCART.Rows(i_08).Item("FPCAVIGR"), _
                                                              dt_FIPRCART.Rows(i_08).Item("FPCAVUEL"), _
                                                              dt_FIPRCART.Rows(i_08).Item("FPCAFAJA"), _
                                                              dt_FIPRCART.Rows(i_08).Item("FPCAFOTO"), _
                                                              dt_FIPRCART.Rows(i_08).Item("FPCAVIAE"), _
                                                              dt_FIPRCART.Rows(i_08).Item("FPCAAMPL"), _
                                                              dt_FIPRCART.Rows(i_08).Item("FPCAESAE"), _
                                                              dt_FIPRCART.Rows(i_08).Item("FPCADEPA"), _
                                                              dt_FIPRCART.Rows(i_08).Item("FPCAMUNI"), _
                                                              dt_FIPRCART.Rows(i_08).Item("FPCATIRE"), _
                                                              dt_FIPRCART.Rows(i_08).Item("FPCACLSE"), _
                                                              dt_FIPRCART.Rows(i_08).Item("FPCAVIGE"), _
                                                              dt_FIPRCART.Rows(i_08).Item("FPCARESO"), _
                                                              dt_FIPRCART.Rows(i_08).Item("FPCASECU"), _
                                                              dt_FIPRCART.Rows(i_08).Item("FPCANURE"), _
                                                              dt_FIPRCART.Rows(i_08).Item("FPCAESTA"))

                            'End If

                            ' Incrementa la barra
                            vl_inContadorParcial = vl_inContadorParcial + 1
                            vl_inContadorTotal = vl_inContadorTotal + 1

                            Me.pbPROCESO1.Value = vl_inContadorParcial
                            Me.pbPROCESO2.Value = vl_inContadorTotal

                        Next

                        Me.pbPROCESO1.Value = 0
                        vl_inContadorParcial = 0

                        '========================================================
                        ' inserta los registros de ZONA ECONÓMICA
                        '========================================================
                        Me.pbPROCESO1.Maximum = dt_FIPRZOEC.Rows.Count

                        Dim i_09 As Integer = 0

                        For i_09 = 0 To dt_FIPRZOEC.Rows.Count - 1

                            Dim ob_FIPRZOEC As New cla_FIPRZOEC
                            'Dim dt_FIPRZOEC_LOCAL As New DataTable

                            'dt_FIPRZOEC_LOCAL = ob_FIPRZOEC.fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_FIPRZOEC(dt_FIPRZOEC.Rows(i_09).Item("FPZENUFI"), _
                            '                                                                                dt_FIPRZOEC.Rows(i_09).Item("FPZEZOEC"))

                            'If dt_FIPRZOEC_LOCAL.Rows.Count = 0 Then

                            ob_FIPRZOEC.fun_Insertar_FIPRZOEC(dt_FIPRZOEC.Rows(i_09).Item("FPZENUFI"), _
                                                              dt_FIPRZOEC.Rows(i_09).Item("FPZEZOEC"), _
                                                              dt_FIPRZOEC.Rows(i_09).Item("FPZEPORC"), _
                                                              dt_FIPRZOEC.Rows(i_09).Item("FPZEDEPA"), _
                                                              dt_FIPRZOEC.Rows(i_09).Item("FPZEMUNI"), _
                                                              dt_FIPRZOEC.Rows(i_09).Item("FPZETIRE"), _
                                                              dt_FIPRZOEC.Rows(i_09).Item("FPZECLSE"), _
                                                              dt_FIPRZOEC.Rows(i_09).Item("FPZEVIGE"), _
                                                              dt_FIPRZOEC.Rows(i_09).Item("FPZERESO"), _
                                                              dt_FIPRZOEC.Rows(i_09).Item("FPZESECU"), _
                                                              dt_FIPRZOEC.Rows(i_09).Item("FPZENURE"), _
                                                              dt_FIPRZOEC.Rows(i_09).Item("FPZEESTA"))

                            'End If

                            ' Incrementa la barra
                            vl_inContadorParcial = vl_inContadorParcial + 1
                            vl_inContadorTotal = vl_inContadorTotal + 1

                            Me.pbPROCESO1.Value = vl_inContadorParcial
                            Me.pbPROCESO2.Value = vl_inContadorTotal

                        Next

                        Me.pbPROCESO1.Value = 0
                        vl_inContadorParcial = 0

                        '========================================================
                        ' inserta los registros de ZONA FÍSICA
                        '========================================================
                        Me.pbPROCESO1.Maximum = dt_FIPRZOFI.Rows.Count

                        Dim i_10 As Integer = 0

                        For i_10 = 0 To dt_FIPRZOFI.Rows.Count - 1

                            Dim ob_FIPRZOFI As New cla_FIPRZOFI
                            'Dim dt_FIPRZOFI_LOCAL As New DataTable

                            'dt_FIPRZOFI_LOCAL = ob_FIPRZOFI.fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_FIPRZOFI(dt_FIPRZOFI.Rows(i_10).Item("FPZFNUFI"), _
                            '                                                                                dt_FIPRZOFI.Rows(i_10).Item("FPZFZOFI"))

                            'If dt_FIPRZOFI_LOCAL.Rows.Count = 0 Then

                            ob_FIPRZOFI.fun_Insertar_FIPRZOFI(dt_FIPRZOFI.Rows(i_10).Item("FPZFNUFI"), _
                                                              dt_FIPRZOFI.Rows(i_10).Item("FPZFZOFI"), _
                                                              dt_FIPRZOFI.Rows(i_10).Item("FPZFPORC"), _
                                                              dt_FIPRZOFI.Rows(i_10).Item("FPZFDEPA"), _
                                                              dt_FIPRZOFI.Rows(i_10).Item("FPZFMUNI"), _
                                                              dt_FIPRZOFI.Rows(i_10).Item("FPZFTIRE"), _
                                                              dt_FIPRZOFI.Rows(i_10).Item("FPZFCLSE"), _
                                                              dt_FIPRZOFI.Rows(i_10).Item("FPZFVIGE"), _
                                                              dt_FIPRZOFI.Rows(i_10).Item("FPZFRESO"), _
                                                              dt_FIPRZOFI.Rows(i_10).Item("FPZFSECU"), _
                                                              dt_FIPRZOFI.Rows(i_10).Item("FPZFNURE"), _
                                                              dt_FIPRZOFI.Rows(i_10).Item("FPZFESTA"))

                            'End If

                            ' Incrementa la barra
                            vl_inContadorParcial = vl_inContadorParcial + 1
                            vl_inContadorTotal = vl_inContadorTotal + 1

                            Me.pbPROCESO1.Value = vl_inContadorParcial
                            Me.pbPROCESO2.Value = vl_inContadorTotal

                        Next

                        Me.pbPROCESO1.Value = 0
                        vl_inContadorParcial = 0

                        '========================================================
                        ' inserta los registros PROPIETARIO ANTERIOR
                        '========================================================
                        Me.pbPROCESO1.Maximum = dt_PROPANTE.Rows.Count

                        Dim i_11 As Integer = 0

                        For i_11 = 0 To dt_PROPANTE.Rows.Count - 1

                            Dim ob_PROPANTE As New cla_PROPANTE
                            Dim tb_PROPANTE_LOCAL As New DataTable

                            tb_PROPANTE_LOCAL = ob_PROPANTE.fun_Buscar_CODIGO_PROPANTE(dt_PROPANTE.Rows(i_11).Item("PRANNUFI"), _
                                                                                       dt_PROPANTE.Rows(i_11).Item("PRANNUDO"))

                            If tb_PROPANTE_LOCAL.Rows.Count = 0 Then

                                ob_PROPANTE.fun_Insertar_PROPANTE(dt_PROPANTE.Rows(i_11).Item("PRANNUFI"), _
                                                                  dt_PROPANTE.Rows(i_11).Item("PRANNUDO"), _
                                                                  dt_PROPANTE.Rows(i_11).Item("PRANPRAP"), _
                                                                  dt_PROPANTE.Rows(i_11).Item("PRANSEAP"), _
                                                                  dt_PROPANTE.Rows(i_11).Item("PRANNOMB"), _
                                                                  dt_PROPANTE.Rows(i_11).Item("PRANCAAC"), _
                                                                  dt_PROPANTE.Rows(i_11).Item("PRANOBSE"), _
                                                                  dt_PROPANTE.Rows(i_11).Item("PRANESTA"))

                            End If


                            ' Incrementa la barra
                            vl_inContadorParcial = vl_inContadorParcial + 1
                            vl_inContadorTotal = vl_inContadorTotal + 1

                            Me.pbPROCESO1.Value = vl_inContadorParcial
                            Me.pbPROCESO2.Value = vl_inContadorTotal

                        Next

                        Me.pbPROCESO1.Value = 0
                        Me.pbPROCESO2.Value = 0

                        Me.cmdGuardar.Enabled = True

                        MessageBox.Show("El proceso termino correctamente", "Mensaje ...", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)

                    Else
                        Me.cmdGuardar.Enabled = True
                    End If

                End If

            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub cmdLimpiar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdLimpiar.Click
        pro_LimpiarCampos()
    End Sub
    Private Sub cmdSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSalir.Click
        Me.Close()
    End Sub

#End Region

#Region "FORMULARIO"

#Region "Load"

    Private Sub frm_Migrar_Datos_Catastrales_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.strBARRESTA.Items(0).Text = "Migrar datos"
        Me.strBARRESTA.Items(2).Text = "Registros: 0"
    End Sub

#End Region

#Region "TextChanged"

    Private Sub cmdGuardar_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtRESOCODI.TextChanged

        If Trim(Me.txtRESOCODI.Text) <> "" Then
            Me.cmdGuardar.Enabled = True
        Else
            Me.cmdGuardar.Enabled = False
        End If

    End Sub

#End Region

#End Region

End Class