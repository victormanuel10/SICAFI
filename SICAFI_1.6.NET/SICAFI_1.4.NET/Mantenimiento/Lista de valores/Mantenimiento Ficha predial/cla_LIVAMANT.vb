Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration

Public Class cla_LIVAMANT

    '======================================================
    '*** CLASE LISTA DE VALORES TABLAS DE MANTENIMIENTO ***
    '======================================================

    Private ejecutar As New SqlCommand
    Private conexion As New SqlConnection
    Private adapter As New SqlDataAdapter
    Private reader As SqlDataReader
    Private ds As New DataSet
    Private dt As New DataTable

    Public Function fun_Actualizar_ListaDeValores_MANT_TIPORESO() As Boolean

        Try
            conexion = New SqlConnection(Global.SICAFI.My.MySettings.Default.SICAFIConnectionString1)
            conexion.Open()
            ejecutar = New SqlCommand("Actualizar_ListaDeValores_MANT_TIPORESO", conexion)
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
    Public Function fun_Actualizar_ListaDeValores_MANT_CLASSECT() As Boolean

        Try
            conexion = New SqlConnection(Global.SICAFI.My.MySettings.Default.SICAFIConnectionString1)
            conexion.Open()
            ejecutar = New SqlCommand("Actualizar_ListaDeValores_MANT_CLASSECT", conexion)
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
    Public Function fun_Actualizar_ListaDeValores_MANT_CATESUEL() As Boolean

        Try
            conexion = New SqlConnection(Global.SICAFI.My.MySettings.Default.SICAFIConnectionString1)
            conexion.Open()
            ejecutar = New SqlCommand("Actualizar_ListaDeValores_MANT_CATESUEL", conexion)
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
    Public Function fun_Actualizar_ListaDeValores_MANT_CARAPRED() As Boolean

        Try
            conexion = New SqlConnection(Global.SICAFI.My.MySettings.Default.SICAFIConnectionString1)
            conexion.Open()
            ejecutar = New SqlCommand("Actualizar_ListaDeValores_MANT_CARAPRED", conexion)
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
    Public Function fun_Actualizar_ListaDeValores_MANT_MODOADQU() As Boolean

        Try
            conexion = New SqlConnection(Global.SICAFI.My.MySettings.Default.SICAFIConnectionString1)
            conexion.Open()
            ejecutar = New SqlCommand("Actualizar_ListaDeValores_MANT_MODOADQU", conexion)
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
    Public Function fun_Actualizar_ListaDeValores_MANT_DESTECON() As Boolean

        Try
            conexion = New SqlConnection(Global.SICAFI.My.MySettings.Default.SICAFIConnectionString1)
            conexion.Open()
            ejecutar = New SqlCommand("Actualizar_ListaDeValores_MANT_DESTECON", conexion)
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
    Public Function fun_Actualizar_ListaDeValores_MANT_CALIPROP() As Boolean

        Try
            conexion = New SqlConnection(Global.SICAFI.My.MySettings.Default.SICAFIConnectionString1)
            conexion.Open()
            ejecutar = New SqlCommand("Actualizar_ListaDeValores_MANT_CALIPROP", conexion)
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
    Public Function fun_Actualizar_ListaDeValores_MANT_TIPODOCU() As Boolean

        Try
            conexion = New SqlConnection(Global.SICAFI.My.MySettings.Default.SICAFIConnectionString1)
            conexion.Open()
            ejecutar = New SqlCommand("Actualizar_ListaDeValores_MANT_TIPODOCU", conexion)
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
    Public Function fun_Actualizar_ListaDeValores_MANT_SEXO() As Boolean

        Try
            conexion = New SqlConnection(Global.SICAFI.My.MySettings.Default.SICAFIConnectionString1)
            conexion.Open()
            ejecutar = New SqlCommand("Actualizar_ListaDeValores_MANT_SEXO", conexion)
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
    Public Function fun_Actualizar_ListaDeValores_MANT_DEPARTAMENTO() As Boolean

        Try
            conexion = New SqlConnection(Global.SICAFI.My.MySettings.Default.SICAFIConnectionString1)
            conexion.Open()
            ejecutar = New SqlCommand("Actualizar_ListaDeValores_MANT_DEPARTAMENTO", conexion)
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
    Public Function fun_Actualizar_ListaDeValores_MANT_MUNICIPIO() As Boolean

        Try
            conexion = New SqlConnection(Global.SICAFI.My.MySettings.Default.SICAFIConnectionString1)
            conexion.Open()
            ejecutar = New SqlCommand("Actualizar_ListaDeValores_MANT_MUNICIPIO", conexion)
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
    Public Function fun_Actualizar_ListaDeValores_MANT_TIPOCONS(ByVal srTICODEPA As String, _
                                                                ByVal stTICOMUNI As String) As Boolean

        Try
            conexion = New SqlConnection(Global.SICAFI.My.MySettings.Default.SICAFIConnectionString1)
            conexion.Open()
            ejecutar = New SqlCommand("Actualizar_ListaDeValores_MANT_TIPOCONS", conexion)
            ejecutar.CommandTimeout = 360
            ejecutar.CommandType = CommandType.StoredProcedure

            ejecutar.Parameters.Add("@TICODEPA", SqlDbType.NChar, 2).Value = srTICODEPA
            ejecutar.Parameters.Add("@TICOMUNI", SqlDbType.NChar, 3).Value = stTICOMUNI

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
    Public Function fun_Actualizar_ListaDeValores_MANT_CLASCONS() As Boolean

        Try
            conexion = New SqlConnection(Global.SICAFI.My.MySettings.Default.SICAFIConnectionString1)
            conexion.Open()
            ejecutar = New SqlCommand("Actualizar_ListaDeValores_MANT_CLASCONS", conexion)
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
    Public Function fun_Actualizar_ListaDeValores_MANT_CODICALI() As Boolean

        Try
            conexion = New SqlConnection(Global.SICAFI.My.MySettings.Default.SICAFIConnectionString1)
            conexion.Open()
            ejecutar = New SqlCommand("Actualizar_ListaDeValores_MANT_CODICALI", conexion)
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
    Public Function fun_Actualizar_ListaDeValores_MANT_TIPOCALI() As Boolean

        Try
            conexion = New SqlConnection(Global.SICAFI.My.MySettings.Default.SICAFIConnectionString1)
            conexion.Open()
            ejecutar = New SqlCommand("Actualizar_ListaDeValores_MANT_TIPOCALI", conexion)
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

    Public Function fun_Buscar_DEPARTAMENTO_Y_MUNICIPIO_MANT_TIPOCONS(ByVal IdDepartamento As String, _
                                                        ByVal IdMunicipio As String) As DataTable


        Try
            dt = New DataTable
            adapter = New SqlDataAdapter
            conexion = New SqlConnection(Global.SICAFI.My.MySettings.Default.SICAFIConnectionString1)
            conexion.Open()
            ejecutar = New SqlCommand("Buscar_DEPARTAMENTO_Y_MUNICIPIO_MANT_TIPOCONS", conexion)
            ejecutar.CommandTimeout = 360

            ejecutar.Parameters.Add("@TICODEPA", SqlDbType.NChar, 2).Value = IdDepartamento
            ejecutar.Parameters.Add("@TICOMUNI", SqlDbType.NChar, 3).Value = IdMunicipio

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
