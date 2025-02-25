Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration

Public Class cla_ESTADO

    '====================
    '*** CLASE ESTADO ***
    '====================

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
    Public Function fun_Consultar_ESTADO() As DataTable

        Try

            dt = New DataTable
            adapter = New SqlDataAdapter
            conexion = New SqlConnection(Global.SICAFI.My.Settings.SICAFIConnectionString1)
            conexion.Open()
            'Linea nueva procedimiento almacenado
            ejecutar = New SqlCommand("Consultar_ESTADO", conexion)
            ejecutar.CommandTimeout = 360
            'Linea nueva procedimiento almacenado
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
    ''' Llena el ComboBox con datos activos e inactivos formulario modificar estado 
    ''' esta funcion se llama desde el procedimiento "pro_inicializarControles()".
    ''' </summary>
    Public Function fun_Consultar_TODOS_LOS_ESTADOS() As DataTable

        Try

            dt = New DataTable
            adapter = New SqlDataAdapter
            conexion = New SqlConnection(Global.SICAFI.My.Settings.SICAFIConnectionString1)
            conexion.Open()
            'Linea nueva procedimiento almacenado
            ejecutar = New SqlCommand("Consultar_TODOS_LOS_ESTADOS", conexion)
            ejecutar.CommandTimeout = 360
            'Linea nueva procedimiento almacenado
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
    Public Function fun_Consultar_ESTADO_X_ESTADO() As DataTable

        Try

            dt = New DataTable
            adapter = New SqlDataAdapter
            conexion = New SqlConnection(Global.SICAFI.My.Settings.SICAFIConnectionString1)
            conexion.Open()
            'Linea nueva procedimiento almacenado
            ejecutar = New SqlCommand("Consultar_ESTADO_X_ESTADO", conexion)
            ejecutar.CommandTimeout = 360
            'Linea nueva procedimiento almacenado
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
    ''' Función que inserta el registro.
    ''' </summary>
    Public Function fun_Insertar_ESTADO(ByVal stESTACODI As String, ByVal stESTADESC As String, ByVal stESTAESTA As String) As Boolean

        Try
            conexion = New SqlConnection(Global.SICAFI.My.MySettings.Default.SICAFIConnectionString1)
            conexion.Open()
            ejecutar = New SqlCommand("insertar_ESTADO", conexion)
            ejecutar.CommandTimeout = 360
            ejecutar.CommandType = CommandType.StoredProcedure

            ejecutar.Parameters.Add("@ESTACODI", SqlDbType.NChar, 2).Value = stESTACODI
            ejecutar.Parameters.Add("@ESTADESC", SqlDbType.NChar, 50).Value = stESTADESC
            ejecutar.Parameters.Add("@ESTAESTA", SqlDbType.NChar, 10).Value = stESTAESTA

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
    Public Function fun_Eliminar_ESTADO(ByVal inESTAIDRE As Integer) As Boolean


        Try
            conexion = New SqlConnection(Global.SICAFI.My.MySettings.Default.SICAFIConnectionString1)
            conexion.Open()
            ejecutar = New SqlCommand("eliminar_ESTADO", conexion)
            ejecutar.CommandTimeout = 360
            ejecutar.CommandType = CommandType.StoredProcedure

            ejecutar.Parameters.Add("@ESTAIDRE", SqlDbType.Int, 4).Value = inESTAIDRE

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
    Public Function fun_Actualizar_ESTADO(ByVal inESTAIDRE As Integer, ByVal stESTACODI As String, ByVal stESTADESC As String, ByVal stESTAESTA As String) As Boolean

        Try
            conexion = New SqlConnection(Global.SICAFI.My.MySettings.Default.SICAFIConnectionString1)
            conexion.Open()
            ejecutar = New SqlCommand("actualizar_ESTADO", conexion)
            ejecutar.CommandTimeout = 360
            ejecutar.CommandType = CommandType.StoredProcedure

            ejecutar.Parameters.Add("@ESTAIDRE", SqlDbType.Int, 4).Value = inESTAIDRE
            ejecutar.Parameters.Add("@ESTACODI", SqlDbType.NChar, 2).Value = stESTACODI
            ejecutar.Parameters.Add("@ESTADESC", SqlDbType.NChar, 50).Value = stESTADESC
            ejecutar.Parameters.Add("@ESTAESTA", SqlDbType.NChar, 10).Value = stESTAESTA

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
    Public Function fun_Buscar_ESTADO(ByVal IdPersona As Integer) As DataTable

        Try
            dt = New DataTable
            adapter = New SqlDataAdapter
            conexion = New SqlConnection(Global.SICAFI.My.MySettings.Default.SICAFIConnectionString1)
            conexion.Open()
            ejecutar = New SqlCommand("buscar_ESTADO", conexion)
            ejecutar.CommandTimeout = 360
            ejecutar.Parameters.Add("@ESTAIDRE", SqlDbType.Int, 4).Value = IdPersona
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
