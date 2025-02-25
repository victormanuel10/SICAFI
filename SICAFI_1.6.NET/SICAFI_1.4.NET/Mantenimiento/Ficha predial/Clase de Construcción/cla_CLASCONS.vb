Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration

Public Class cla_CLASCONS

    '===================================
    '*** CLASE CLASE DE CONSTRUCCIÓN ***
    '===================================

    Private ejecutar As New SqlCommand
    Private conexion As New SqlConnection
    Private adapter As New SqlDataAdapter
    Private reader As SqlDataReader
    Private ds As New DataSet
    Private dt As New DataTable

    ''' <summary>
    ''' Consulta para llenar el DataGridView y colocar el nombre del encabezado
    ''' de la columna. 
    ''' </summary>
    Public Function fun_Consultar_MANT_CLASCONS() As DataTable

        Try

            dt = New DataTable
            adapter = New SqlDataAdapter
            conexion = New SqlConnection(Global.SICAFI.My.Settings.SICAFIConnectionString1)
            conexion.Open()
            ejecutar = New SqlCommand("Consultar_MANT_CLASCONS", conexion)
            ejecutar.CommandTimeout = 360
            ejecutar.CommandType = CommandType.StoredProcedure
            adapter.SelectCommand = ejecutar
            adapter.Fill(dt)
            conexion.Close()

            Return dt

        Catch ex As Exception

            conexion.Close()
            dt = Nothing
            Return dt

        End Try

    End Function

    '''   <summary>
    ''' Llena el ComboBox con datos activos e inactivos formulario principal 
    ''' esta funcion se llama desde el procedimiento "pro_inicializarControles()".
    ''' </summary>
    Public Function fun_Consultar_CAMPOS_MANT_CLASCONS() As DataTable

        Try

            dt = New DataTable
            adapter = New SqlDataAdapter
            conexion = New SqlConnection(Global.SICAFI.My.Settings.SICAFIConnectionString1)
            conexion.Open()
            ejecutar = New SqlCommand("Consultar_CAMPOS_MANT_CLASCONS", conexion)
            ejecutar.CommandTimeout = 360
            ejecutar.CommandType = CommandType.StoredProcedure
            adapter.SelectCommand = ejecutar
            adapter.Fill(dt)
            conexion.Close()

            Return dt

        Catch ex As Exception

            conexion.Close()
            dt = Nothing
            Return dt

        End Try

    End Function

    ''' <summary>
    ''' Llena el ComboBox con datos activos formulario insertar y modificar 
    ''' esta funcion se llama desde el procedimiento "pro_inicializarControles()".
    ''' </summary>
    Public Function fun_Consultar_MANT_CLASCONS_X_ESTADO() As DataTable

        Try

            dt = New DataTable
            adapter = New SqlDataAdapter
            conexion = New SqlConnection(Global.SICAFI.My.Settings.SICAFIConnectionString1)
            conexion.Open()
            ejecutar = New SqlCommand("Consultar_MANT_CLASCONS_X_ESTADO", conexion)
            ejecutar.CommandTimeout = 360
            ejecutar.CommandType = CommandType.StoredProcedure
            adapter.SelectCommand = ejecutar
            adapter.Fill(dt)
            conexion.Close()

            Return dt

        Catch ex As Exception

            conexion.Close()
            dt = Nothing
            Return dt

        End Try

    End Function

    Public Function fun_Consulta_Parametrizada_MANT_CARAPRED(ByVal stCLCOCODI As String, _
                                                             ByVal stCLCODESC As String, _
                                                             ByVal stCLCOESTA As String) As DataTable
        Try
            dt = New DataTable
            adapter = New SqlDataAdapter
            conexion = New SqlConnection(Global.SICAFI.My.MySettings.Default.SICAFIConnectionString1)
            conexion.Open()

            'ejecutar = New SqlCommand("Consulta_Parametrizada_MANT_CALIPROP", conexion)

            If stCLCOCODI = "" Then
                ejecutar = New SqlCommand("select * from MANT_CLASCONS where CLCOCODI like '" & stCLCOCODI & "%'and CLCODESC like '" & stCLCODESC & "%' and CLCOESTA like '" & stCLCOESTA & "%'", conexion)
            Else
                ejecutar = New SqlCommand("select * from MANT_CLASCONS where CLCOCODI = '" & stCLCOCODI & "'and CLCODESC like '" & stCLCODESC & "%' and CLCOESTA like '" & stCLCOESTA & "%'", conexion)
            End If

            ejecutar.CommandTimeout = 360

            'ejecutar.Parameters.Add("@CAPRCODI", SqlDbType.NChar, 9).Value = stCAPRCODI
            'ejecutar.Parameters.Add("@CAPRDESC", SqlDbType.NChar, 50).Value = stCAPRDESC
            'ejecutar.Parameters.Add("@CAPRESTA", SqlDbType.NChar, 10).Value = stCAPRESTA

            ejecutar.CommandType = CommandType.Text
            'ejecutar.CommandType = CommandType.StoredProcedure

            adapter.SelectCommand = ejecutar
            adapter.Fill(dt)
            conexion.Close()
            Return dt

        Catch ex As Exception

            conexion.Close()
            dt = Nothing
            Return dt

        End Try

    End Function

    ''' <summary>
    ''' Función que inserta el registro.
    ''' </summary>
    Public Function fun_Insertar_MANT_CLASCONS(ByVal inCLCOCODI As Integer, _
                                               ByVal stCLCODESC As String, _
                                               ByVal stCLCOESTA As String) As Boolean

        Try
            conexion = New SqlConnection(Global.SICAFI.My.MySettings.Default.SICAFIConnectionString1)
            conexion.Open()
            ejecutar = New SqlCommand("insertar_MANT_CLASCONS", conexion)
            ejecutar.CommandTimeout = 360
            ejecutar.CommandType = CommandType.StoredProcedure

            ejecutar.Parameters.Add("@CLCOCODI", SqlDbType.Int, 4).Value = inCLCOCODI
            ejecutar.Parameters.Add("@CLCODESC", SqlDbType.NChar, 50).Value = stCLCODESC
            ejecutar.Parameters.Add("@CLCOESTA", SqlDbType.NChar, 10).Value = stCLCOESTA

            reader = ejecutar.ExecuteReader
            conexion.Close()

            reader = Nothing

        Catch ex As Exception

            conexion.Close()
            reader = Nothing
            Return False

        End Try

        Return True

    End Function

    ''' <summary>
    ''' Función que Elimina el registro.
    ''' </summary>
    Public Function fun_Eliminar_MANT_CLASCONS(ByVal inCLCOIDRE As Integer) As Boolean


        Try
            conexion = New SqlConnection(Global.SICAFI.My.MySettings.Default.SICAFIConnectionString1)
            conexion.Open()
            ejecutar = New SqlCommand("eliminar_MANT_CLASCONS", conexion)
            ejecutar.CommandTimeout = 360
            ejecutar.CommandType = CommandType.StoredProcedure

            ejecutar.Parameters.Add("@CLCOIDRE", SqlDbType.Int, 4).Value = inCLCOIDRE

            reader = ejecutar.ExecuteReader
            conexion.Close()
            reader = Nothing

        Catch ex As Exception

            conexion.Close()
            reader = Nothing
            Return False

        End Try

        Return True

    End Function

    ''' <summary>
    ''' Función que Modifica o actualiza el registro.
    ''' </summary>
    Public Function fun_Actualizar_MANT_CLASCONS(ByVal inCLCOIDRE As Integer, _
                                                 ByVal inCLCOCODI As Integer, _
                                                 ByVal stCLCODESC As String, _
                                                 ByVal stCLCOESTA As String) As Boolean

        Try
            conexion = New SqlConnection(Global.SICAFI.My.MySettings.Default.SICAFIConnectionString1)
            conexion.Open()
            ejecutar = New SqlCommand("actualizar_MANT_CLASCONS", conexion)
            ejecutar.CommandTimeout = 360
            ejecutar.CommandType = CommandType.StoredProcedure

            ejecutar.Parameters.Add("@CLCOIDRE", SqlDbType.Int, 4).Value = inCLCOIDRE
            ejecutar.Parameters.Add("@CLCOCODI", SqlDbType.Int, 4).Value = inCLCOCODI
            ejecutar.Parameters.Add("@CLCODESC", SqlDbType.NChar, 50).Value = stCLCODESC
            ejecutar.Parameters.Add("@CLCOESTA", SqlDbType.NChar, 10).Value = stCLCOESTA

            reader = ejecutar.ExecuteReader
            conexion.Close()

            reader = Nothing

        Catch ex As Exception

            conexion.Close()
            reader = Nothing
            Return False

        End Try

        Return True

    End Function

    ''' <summary>
    ''' Función que busca el ID del registro a modificar o eliminar.
    ''' </summary>
    Public Function fun_Buscar_ID_MANT_CLASCONS(ByVal Id As Integer) As DataTable

        Try
            dt = New DataTable
            adapter = New SqlDataAdapter
            conexion = New SqlConnection(Global.SICAFI.My.MySettings.Default.SICAFIConnectionString1)
            conexion.Open()
            ejecutar = New SqlCommand("buscar_ID_MANT_CLASCONS", conexion)
            ejecutar.CommandTimeout = 360
            ejecutar.Parameters.Add("@CLCOIDRE", SqlDbType.Int, 4).Value = Id
            ejecutar.CommandType = CommandType.StoredProcedure
            adapter.SelectCommand = ejecutar
            adapter.Fill(dt)
            conexion.Close()
            Return dt

        Catch ex As Exception

            conexion.Close()
            dt = Nothing
            Return dt

        End Try



    End Function

    ''' <summary>
    ''' Función que busca el CÓDIGO DE LA CLASE DE CONSTRUCCIÓN para que no se 
    ''' guarden registros duplicados.
    ''' </summary>
    Public Function fun_Buscar_CODIGO_MANT_CLASCONS(ByVal IdCodigo As Integer) As DataTable

        Try
            dt = New DataTable
            adapter = New SqlDataAdapter
            conexion = New SqlConnection(Global.SICAFI.My.MySettings.Default.SICAFIConnectionString1)
            conexion.Open()
            ejecutar = New SqlCommand("buscar_CODIGO_MANT_CLASCONS", conexion)
            ejecutar.CommandTimeout = 360

            ejecutar.Parameters.Add("@CLCOCODI", SqlDbType.Int, 4).Value = IdCodigo

            ejecutar.CommandType = CommandType.StoredProcedure
            adapter.SelectCommand = ejecutar
            adapter.Fill(dt)
            conexion.Close()
            Return dt

        Catch ex As Exception

            conexion.Close()
            dt = Nothing
            Return dt

        End Try

    End Function


End Class
