Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration

Public Class cla_CONTRASENA

    '========================
    '*** CLASE CONTRASENA ***
    '========================

    Private ejecutar As New SqlCommand
    Private conexion As New SqlConnection
    Private adapter As New SqlDataAdapter
    Private reader As SqlDataReader
    Private ds As New DataSet
    Private dt As New DataTable

    Public Function fun_Consultar_CONTRASENA() As DataTable

        Try

            dt = New DataTable
            adapter = New SqlDataAdapter
            conexion = New SqlConnection(Global.SICAFI.My.Settings.SICAFIConnectionString1)
            conexion.Open()
            ejecutar = New SqlCommand("Consultar_CONTRASENA", conexion)
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
    Public Function fun_Consultar_CAMPOS_CONTRASENA() As DataTable

        Try

            dt = New DataTable
            adapter = New SqlDataAdapter
            conexion = New SqlConnection(Global.SICAFI.My.Settings.SICAFIConnectionString1)
            conexion.Open()
            ejecutar = New SqlCommand("Consultar_CAMPOS_CONTRASENA", conexion)
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
    Public Function fun_Consultar_USUARIO_CONTRASENA_X_ESTADO() As DataTable
        '=========================================================
        'Verifica si el usuario esta activo para entrar al sistema
        '=========================================================
        Try

            dt = New DataTable
            adapter = New SqlDataAdapter
            conexion = New SqlConnection(Global.SICAFI.My.Settings.SICAFIConnectionString1)
            conexion.Open()
            ejecutar = New SqlCommand("fun_Consultar_USUARIO_CONTRASENA_X_ESTADO", conexion)
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

    Public Function fun_Insertar_CONTRASENA(ByVal stCONTNUDO As String, _
                                            ByVal stCONTUSUA As String, _
                                            ByVal stCONTCONT As String, _
                                            ByVal stCONTESTA As String, _
                                            ByVal boCONTAGRE As Boolean, _
                                            ByVal boCONTMODI As Boolean, _
                                            ByVal boCONTELIM As Boolean) As Boolean

        Try
            Dim stCONTCONU As String = ""
            Dim stCONTVECO As String = ""

            conexion = New SqlConnection(Global.SICAFI.My.MySettings.Default.SICAFIConnectionString1)
            conexion.Open()
            ejecutar = New SqlCommand("insertar_CONTRASENA", conexion)
            ejecutar.CommandTimeout = 360
            ejecutar.CommandType = CommandType.StoredProcedure

            ejecutar.Parameters.Add("@CONTNUDO", SqlDbType.NChar, 14).Value = stCONTNUDO
            ejecutar.Parameters.Add("@CONTUSUA", SqlDbType.NChar, 20).Value = stCONTUSUA
            ejecutar.Parameters.Add("@CONTCONT", SqlDbType.NChar, 1000).Value = stCONTCONT
            ejecutar.Parameters.Add("@CONTESTA", SqlDbType.NChar, 10).Value = stCONTESTA
            ejecutar.Parameters.Add("@CONTAGRE", SqlDbType.Bit, 1).Value = boCONTAGRE
            ejecutar.Parameters.Add("@CONTMODI", SqlDbType.Bit, 1).Value = boCONTMODI
            ejecutar.Parameters.Add("@CONTELIM", SqlDbType.Bit, 1).Value = boCONTELIM

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
    Public Function fun_Eliminar_CONTRASENA(ByVal inCONTIDRE As Integer) As Boolean


        Try
            conexion = New SqlConnection(Global.SICAFI.My.MySettings.Default.SICAFIConnectionString1)
            conexion.Open()
            ejecutar = New SqlCommand("eliminar_CONTRASENA", conexion)
            ejecutar.CommandTimeout = 360
            ejecutar.CommandType = CommandType.StoredProcedure

            ejecutar.Parameters.Add("@CONTIDRE", SqlDbType.Int, 4).Value = inCONTIDRE

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
    Public Function fun_Actualizar_CONTRASENA(ByVal inCONTIDRE As Integer, _
                                            ByVal stCONTNUDO As String, _
                                            ByVal stCONTUSUA As String, _
                                            ByVal stCONTCONU As String, _
                                            ByVal stCONTESTA As String, _
                                            ByVal boCONTAGRE As Boolean, _
                                            ByVal boCONTMODI As Boolean, _
                                            ByVal boCONTELIM As Boolean) As Boolean

        Try
            conexion = New SqlConnection(Global.SICAFI.My.MySettings.Default.SICAFIConnectionString1)
            conexion.Open()
            ejecutar = New SqlCommand("actualizar_CONTRASENA", conexion)
            ejecutar.CommandTimeout = 360
            ejecutar.CommandType = CommandType.StoredProcedure

            ejecutar.Parameters.Add("@CONTIDRE", SqlDbType.Int, 4).Value = inCONTIDRE
            ejecutar.Parameters.Add("@CONTNUDO", SqlDbType.NChar, 14).Value = stCONTNUDO
            ejecutar.Parameters.Add("@CONTUSUA", SqlDbType.NChar, 20).Value = stCONTUSUA
            ejecutar.Parameters.Add("@CONTCONT", SqlDbType.NChar, 1000).Value = stCONTCONU 'CONTRASEÑA NUEVA
            ejecutar.Parameters.Add("@CONTESTA", SqlDbType.NChar, 10).Value = stCONTESTA
            ejecutar.Parameters.Add("@CONTAGRE", SqlDbType.Bit, 1).Value = boCONTAGRE
            ejecutar.Parameters.Add("@CONTMODI", SqlDbType.Bit, 1).Value = boCONTMODI
            ejecutar.Parameters.Add("@CONTELIM", SqlDbType.Bit, 1).Value = boCONTELIM

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

    Public Function fun_Buscar_ID_CONTRASENA(ByVal Id As Integer) As DataTable

        Try
            dt = New DataTable
            adapter = New SqlDataAdapter
            conexion = New SqlConnection(Global.SICAFI.My.MySettings.Default.SICAFIConnectionString1)
            conexion.Open()
            ejecutar = New SqlCommand("buscar_ID_CONTRASENA", conexion)
            ejecutar.CommandTimeout = 360

            ejecutar.Parameters.Add("@CONTIDRE", SqlDbType.Int, 4).Value = Id

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
    Public Function fun_Buscar_CODIGO_CONTRASENA(ByVal IdCodigo As String) As DataTable

        Try
            dt = New DataTable
            adapter = New SqlDataAdapter
            conexion = New SqlConnection(Global.SICAFI.My.MySettings.Default.SICAFIConnectionString1)
            conexion.Open()
            ejecutar = New SqlCommand("buscar_CODIGO_CONTRASENA", conexion)
            ejecutar.CommandTimeout = 360

            ejecutar.Parameters.Add("@CONTNUDO", SqlDbType.NChar, 20).Value = IdCodigo

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
    Public Function fun_Buscar_USUARIO_CONTRASENA(ByVal IdUsuario As String) As DataTable

        Try
            dt = New DataTable
            adapter = New SqlDataAdapter
            conexion = New SqlConnection(Global.SICAFI.My.MySettings.Default.SICAFIConnectionString1)
            conexion.Open()
            ejecutar = New SqlCommand("buscar_USUARIO_CONTRASENA", conexion)
            ejecutar.CommandTimeout = 360

            ejecutar.Parameters.Add("@CONTUSUA", SqlDbType.Char, 14).Value = IdUsuario

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
