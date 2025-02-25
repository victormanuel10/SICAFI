Imports System.Data.SqlClient

Public Class cExecuteQuery

    Private oConexion As New cConexion
    Private oCommand As New SqlCommand
    Private oAdapter As New SqlDataAdapter

    Private Dt As New DataTable
    Private Ds As New DataSet

    ''' <summary>
    ''' Función que recibe el parametro y el procedimiento StoredProcedure para consultar
    ''' </summary>
    Public Function ConsultarDb(ByVal pParametros As SqlParameter(), ByVal pProcedimiento As String) As DataTable

        Try
            oCommand = New SqlCommand(pProcedimiento, oConexion.conexion())

            oCommand.CommandTimeout = 0
            oCommand.CommandType = CommandType.StoredProcedure
            '
            For Each param As SqlParameter In pParametros
                oCommand.Parameters.Add(param).Value = param.Value
            Next

            'Da = New SqlDataAdapter(objcmd)

            oAdapter = New SqlDataAdapter
            oAdapter.SelectCommand = oCommand

            Dt = New DataTable
            oAdapter.Fill(Dt)

            oConexion.cerrar_base()

            Return Dt

        Catch merror As Exception
            MsgBox(merror.Message)
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que recibe el procedimiento StoredProcedure para consultar
    ''' </summary>
    Public Function ConsultarDb(ByVal pProcedimiento As String) As DataTable

        Try
            oCommand = New SqlCommand(pProcedimiento, oConexion.conexion())

            oCommand.CommandTimeout = 0
            oCommand.CommandType = CommandType.StoredProcedure

            'Da = New SqlDataAdapter(objcmd)

            oAdapter = New SqlDataAdapter
            oAdapter.SelectCommand = oCommand

            Dt = New DataTable
            oAdapter.Fill(Dt)

            oConexion.cerrar_base()

            Return Dt

        Catch merror As Exception
            MsgBox(merror.Message)
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que recibe el parametro y el procedimiento StoredProcedure para consultar
    ''' </summary>
    Public Function Consultarset(ByVal pParametros As SqlParameter(), ByVal pProcedimiento As String) As DataSet

        Try
            oCommand = New SqlCommand(pProcedimiento, oConexion.conexion())

            oCommand.CommandTimeout = 0
            oCommand.CommandType = CommandType.StoredProcedure
            '
            For Each param As SqlParameter In pParametros
                oCommand.Parameters.Add(param).Value = param.Value
            Next

            'Da = New SqlDataAdapter(objcmd)

            oAdapter = New SqlDataAdapter
            oAdapter.SelectCommand = oCommand

            Ds = New DataSet
            oAdapter.Fill(Ds)

            oConexion.cerrar_base()

            Return Ds

        Catch merror As Exception
            MsgBox(merror.Message)
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que recibe el procedimiento StoredProcedure para consultar
    ''' </summary>
    Public Function Consultarset(ByVal pProcedimiento As String) As DataSet

        Try
            oCommand = New SqlCommand(pProcedimiento, oConexion.conexion())

            oCommand.CommandTimeout = 0
            oCommand.CommandType = CommandType.StoredProcedure
            '
            'Da = New SqlDataAdapter(objcmd)

            oAdapter = New SqlDataAdapter
            oAdapter.SelectCommand = oCommand

            Ds = New DataSet
            oAdapter.Fill(Ds)

            oConexion.cerrar_base()

            Return Ds

        Catch merror As Exception
            MsgBox(merror.Message)
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que recibe el procedimiento SQL Text para consultar
    ''' </summary>
    Public Function ConsultarDb_Text_SQL(ByVal pProcedimiento As String) As DataTable

        Try
            oCommand = New SqlCommand(pProcedimiento, oConexion.conexion())

            oCommand.CommandTimeout = 0
            oCommand.CommandType = CommandType.Text

            'oAdapter = New SqlDataAdapter(oCommand)

            oAdapter = New SqlDataAdapter
            oAdapter.SelectCommand = oCommand

            Dt = New DataTable
            oAdapter.Fill(Dt)

            oConexion.cerrar_base()

            Return Dt

        Catch merror As Exception
            MsgBox(merror.Message)
            Return Nothing
        End Try

    End Function

End Class
