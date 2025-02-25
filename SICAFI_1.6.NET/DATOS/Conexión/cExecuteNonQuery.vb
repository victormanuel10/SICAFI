Imports System.Data.SqlClient

Public Class cExecuteNonQuery

    Private oCommand As New SqlCommand
    Private oConexion As New cConexion
    Private oAdapter As New SqlDataAdapter
    Private oReader As SqlDataReader

    ''' <summary>
    ''' Función que recibe los parametros y el procedimiento StoredProcedure para actualizar, insertar y eliminar
    ''' </summary>
    Public Function ActualizarDb(ByVal pParametros As SqlParameter(), ByVal pProcedimiento As String) As Boolean

        Try
            oConexion = New cConexion
            oCommand = New SqlCommand(pProcedimiento, oConexion.conexion())

            oCommand.CommandTimeout = 0
            oCommand.CommandType = CommandType.StoredProcedure

            For Each Param As SqlParameter In pParametros
                oCommand.Parameters.Add(Param).Value = Param.Value
            Next

            'objcmd.ExecuteNonQuery()

            oAdapter.SelectCommand = oCommand
            oReader = oCommand.ExecuteReader

            oConexion.cerrar_base()
            oReader = Nothing

            Return True

        Catch ex As Exception
            MessageBox.Show(Err.Description)
            oReader = Nothing
            Return False
        End Try

    End Function

    ''' <summary>
    ''' Función que recibe el procedimiento StoredProcedure para actualizar, insertar y eliminar
    ''' </summary>
    Public Function ActualizarDb(ByVal pProcedimiento As String) As Boolean

        Try
            oConexion = New cConexion
            oCommand = New SqlCommand(pProcedimiento, oConexion.conexion())

            oCommand.CommandTimeout = 0
            oCommand.CommandType = CommandType.StoredProcedure

            'objcmd.ExecuteNonQuery()

            oAdapter.SelectCommand = oCommand
            oReader = oCommand.ExecuteReader

            oConexion.cerrar_base()
            oReader = Nothing

            Return True

        Catch ex As Exception
            MessageBox.Show(Err.Description)
            oReader = Nothing
            Return False
        End Try

    End Function

    ''' <summary>
    ''' Función que recibe el procedimiento SQL Text para actualizar, insertar y eliminar
    ''' </summary>
    Public Function ActualizarDb_Text_SQL(ByVal pProcedimiento As String) As Boolean

        Try
            oConexion = New cConexion
            oCommand = New SqlCommand(pProcedimiento, oConexion.conexion())

            oCommand.CommandTimeout = 0
            oCommand.CommandType = CommandType.Text

            'objcmd.ExecuteNonQuery()

            oAdapter.SelectCommand = oCommand
            oReader = oCommand.ExecuteReader

            oConexion.cerrar_base()
            oReader = Nothing

            Return True

        Catch ex As Exception
            MessageBox.Show(Err.Description)
            oReader = Nothing
            Return False
        End Try

    End Function

End Class
