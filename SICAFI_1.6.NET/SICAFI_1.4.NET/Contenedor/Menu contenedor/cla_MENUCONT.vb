Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration

Public Class cla_MENUCONT

    '=============================
    '*** CLASE MENU CONTENEDOR ***
    '=============================

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
    Public Function fun_Consultar_MANT_MENUCONT() As DataTable

        Try

            dt = New DataTable
            adapter = New SqlDataAdapter
            conexion = New SqlConnection(Global.SICAFI.My.Settings.SICAFIConnectionString1)
            conexion.Open()
            ejecutar = New SqlCommand("Consultar_MANT_MENUCONT", conexion)
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
    Public Function fun_Consultar_MENUCONT_X_ESTADO() As DataTable

        Try

            dt = New DataTable
            adapter = New SqlDataAdapter
            conexion = New SqlConnection(Global.SICAFI.My.Settings.SICAFIConnectionString1)
            conexion.Open()
            ejecutar = New SqlCommand("Consultar_MENUCONT_X_ESTADO", conexion)
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
    ''' Función que inserta el registro.
    ''' </summary>
    Public Function fun_Insertar_MANT_MENUCONT(ByVal stMECOCODI As String, _
                                                   ByVal stMECODESC As String, _
                                                   ByVal stMECOESTA As String) As Boolean

        Try
            conexion = New SqlConnection(Global.SICAFI.My.MySettings.Default.SICAFIConnectionString1)
            conexion.Open()
            ejecutar = New SqlCommand("insertar_MANT_MENUCONT", conexion)
            ejecutar.CommandTimeout = 360
            ejecutar.CommandType = CommandType.StoredProcedure

            ejecutar.Parameters.Add("@MECOCODI", SqlDbType.NChar, 50).Value = stMECOCODI
            ejecutar.Parameters.Add("@MECODESC", SqlDbType.NChar, 50).Value = stMECODESC
            ejecutar.Parameters.Add("@MECOESTA", SqlDbType.NChar, 10).Value = stMECOESTA

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
    Public Function fun_Eliminar_MANT_MENUCONT(ByVal inMECOIDRE As Integer) As Boolean


        Try
            conexion = New SqlConnection(Global.SICAFI.My.MySettings.Default.SICAFIConnectionString1)
            conexion.Open()
            ejecutar = New SqlCommand("eliminar_MANT_MENUCONT", conexion)
            ejecutar.CommandTimeout = 360
            ejecutar.CommandType = CommandType.StoredProcedure

            ejecutar.Parameters.Add("@MECOIDRE", SqlDbType.Int, 4).Value = inMECOIDRE

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
    Public Function fun_Actualizar_MANT_MENUCONT(ByVal inMECOIDRE As Integer, _
                                                     ByVal stMECOCODI As String, _
                                                     ByVal stMECODESC As String, _
                                                     ByVal stMECOESTA As String) As Boolean

        Try
            conexion = New SqlConnection(Global.SICAFI.My.MySettings.Default.SICAFIConnectionString1)
            conexion.Open()
            ejecutar = New SqlCommand("actualizar_MANT_MENUCONT", conexion)
            ejecutar.CommandTimeout = 360
            ejecutar.CommandType = CommandType.StoredProcedure

            ejecutar.Parameters.Add("@MECOIDRE", SqlDbType.Int, 4).Value = inMECOIDRE
            ejecutar.Parameters.Add("@MECOCODI", SqlDbType.NChar, 50).Value = stMECOCODI
            ejecutar.Parameters.Add("@MECODESC", SqlDbType.NChar, 50).Value = stMECODESC
            ejecutar.Parameters.Add("@MECOESTA", SqlDbType.NChar, 10).Value = stMECOESTA

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
    Public Function fun_Buscar_ID_MANT_MENUCONT(ByVal Id As Integer) As DataTable

        Try
            dt = New DataTable
            adapter = New SqlDataAdapter
            conexion = New SqlConnection(Global.SICAFI.My.MySettings.Default.SICAFIConnectionString1)
            conexion.Open()
            ejecutar = New SqlCommand("buscar_ID_MANT_MENUCONT", conexion)
            ejecutar.CommandTimeout = 360

            ejecutar.Parameters.Add("@MECOIDRE", SqlDbType.Int, 4).Value = Id

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
    ''' Función que busca el CÓDIGO DEL MENU CONTENEDOR (Etiqueta menu)
    ''' para que no se guarden registros duplicados.
    ''' </summary>
    Public Function fun_Buscar_CODIGO_MANT_MENUCONT(ByVal IdCodigo As String) As DataTable

        Try
            dt = New DataTable
            adapter = New SqlDataAdapter
            conexion = New SqlConnection(Global.SICAFI.My.MySettings.Default.SICAFIConnectionString1)
            conexion.Open()
            ejecutar = New SqlCommand("buscar_CODIGO_MANT_MENUCONT", conexion)
            ejecutar.CommandTimeout = 360

            ejecutar.Parameters.Add("@MECOCODI", SqlDbType.Char, 50).Value = IdCodigo

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
