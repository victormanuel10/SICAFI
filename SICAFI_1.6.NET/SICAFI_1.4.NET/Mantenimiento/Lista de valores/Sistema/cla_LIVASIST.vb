Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration

Public Class cla_LIVASIST

    Private ejecutar As New SqlCommand
    Private conexion As New SqlConnection
    Private adapter As New SqlDataAdapter
    Private reader As SqlDataReader
    Private ds As New DataSet
    Private dt As New DataTable

    Public Function fun_Consultar_MANT_LIVASIST() As DataTable

        Try

            dt = New DataTable
            adapter = New SqlDataAdapter
            conexion = New SqlConnection(Global.SICAFI.My.Settings.SICAFIConnectionString1)
            conexion.Open()
            ejecutar = New SqlCommand("Consultar_MANT_LIVASIST", conexion)
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
    Public Function fun_Insertar_MANT_LIVASIST(ByVal stLVSITABL As String, _
                                               ByVal stLVSIDESC As String) As Boolean

        Try
            conexion = New SqlConnection(Global.SICAFI.My.MySettings.Default.SICAFIConnectionString1)
            conexion.Open()
            ejecutar = New SqlCommand("insertar_MANT_LIVASIST", conexion)
            ejecutar.CommandTimeout = 360
            ejecutar.CommandType = CommandType.StoredProcedure


            ejecutar.Parameters.Add("@LVSITABL", SqlDbType.NChar, 30).Value = stLVSITABL
            ejecutar.Parameters.Add("@LVSIDESC", SqlDbType.NChar, 50).Value = stLVSIDESC

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
    Public Function fun_Eliminar_MANT_LIVASIST(ByVal inLVSIIDRE As Integer) As Boolean


        Try
            conexion = New SqlConnection(Global.SICAFI.My.MySettings.Default.SICAFIConnectionString1)
            conexion.Open()
            ejecutar = New SqlCommand("eliminar_MANT_LIVASIST", conexion)
            ejecutar.CommandTimeout = 360
            ejecutar.CommandType = CommandType.StoredProcedure

            ejecutar.Parameters.Add("@LVSIIDRE", SqlDbType.Int, 4).Value = inLVSIIDRE

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
    Public Function fun_Actualizar_MANT_LIVASIST(ByVal inLVSIIDRE As Integer, _
                                                 ByVal stLVSITABL As String, _
                                                 ByVal stLVSIDESC As String) As Boolean

        Try
            conexion = New SqlConnection(Global.SICAFI.My.MySettings.Default.SICAFIConnectionString1)
            conexion.Open()
            ejecutar = New SqlCommand("actualizar_MANT_LIVASIST", conexion)
            ejecutar.CommandTimeout = 360
            ejecutar.CommandType = CommandType.StoredProcedure

            ejecutar.Parameters.Add("@LVSIIDRE", SqlDbType.Int, 4).Value = inLVSIIDRE
            ejecutar.Parameters.Add("@LVSITABL", SqlDbType.NChar, 30).Value = stLVSITABL
            ejecutar.Parameters.Add("@LVSIDESC", SqlDbType.NChar, 50).Value = stLVSIDESC

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

    Public Function fun_Buscar_ID_MANT_LIVASIST(ByVal Id As Integer) As DataTable

        Try
            dt = New DataTable
            adapter = New SqlDataAdapter
            conexion = New SqlConnection(Global.SICAFI.My.MySettings.Default.SICAFIConnectionString1)
            conexion.Open()
            ejecutar = New SqlCommand("buscar_ID_MANT_LIVASIST", conexion)
            ejecutar.CommandTimeout = 360

            ejecutar.Parameters.Add("@LVSIIDRE", SqlDbType.Int, 4).Value = Id

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
    Public Function fun_Buscar_TABLA_MANT_LIVASIST(ByVal IdCodigo As Integer) As DataTable

        Try
            dt = New DataTable
            adapter = New SqlDataAdapter
            conexion = New SqlConnection(Global.SICAFI.My.MySettings.Default.SICAFIConnectionString1)
            conexion.Open()
            ejecutar = New SqlCommand("buscar_TABLA_MANT_LIVASIST", conexion)
            ejecutar.CommandTimeout = 360

            ejecutar.Parameters.Add("@LVSITABL", SqlDbType.Int, 4).Value = IdCodigo

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

    Public Function fun_Actualizar_ListaDeValores_ESTADO() As Boolean

        Try
            conexion = New SqlConnection(Global.SICAFI.My.MySettings.Default.SICAFIConnectionString1)
            conexion.Open()
            ejecutar = New SqlCommand("Actualizar_ListaDeValores_ESTADO", conexion)
            ejecutar.CommandTimeout = 360
            ejecutar.CommandType = CommandType.StoredProcedure
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
    Public Function fun_Insertar_Administrador() As Boolean

        Try
            conexion = New SqlConnection(Global.SICAFI.My.MySettings.Default.SICAFIConnectionString1)
            conexion.Open()
            ejecutar = New SqlCommand("Insertar_Administrador", conexion)
            ejecutar.CommandTimeout = 360
            ejecutar.CommandType = CommandType.StoredProcedure
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
    Public Function fun_Actualizar_ListaDeValores_ETIQUETAS_MENU_CONTENEDOR() As Boolean

        Try
            conexion = New SqlConnection(Global.SICAFI.My.MySettings.Default.SICAFIConnectionString1)
            conexion.Open()
            ejecutar = New SqlCommand("Actualizar_ListaDeValores_ETIQUETAS_MENU_CONTENEDOR", conexion)
            ejecutar.CommandTimeout = 360
            ejecutar.CommandType = CommandType.StoredProcedure
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





End Class
