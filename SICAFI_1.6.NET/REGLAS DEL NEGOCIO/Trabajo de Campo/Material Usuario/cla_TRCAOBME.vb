Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration
Imports DATOS

Public Class cla_TRCAOBME

    '============================================
    '*** CLASE OBSERVACION MATERIAL ENTREGADO ***
    '============================================

    ''' <summary>
    ''' Función que inserta el registro.
    ''' </summary>
    Public Function fun_Insertar_TRCAOBME(ByVal inTCMESECU As Integer, _
                                          ByVal stTCMEOBSE As String) As Boolean

        Try

            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "INSERT INTO "
            stConsultaSQL += "TRCAOBME "

            stConsultaSQL += "( "
            stConsultaSQL += "TCMESECU, "
            stConsultaSQL += "TCMEOBSE "
            stConsultaSQL += ") "

            stConsultaSQL += "VALUES "

            stConsultaSQL += "( "
            stConsultaSQL += "'" & CInt(inTCMESECU) & "', "
            stConsultaSQL += "'" & CStr(Trim(stTCMEOBSE)) & "' "
            stConsultaSQL += ") "

            ' instancia la clase
            Dim objenq As New cExecuteNonQuery

            ' verifica la operación
            If objenq.ActualizarDb_Text_SQL(stConsultaSQL) = True Then
                Return True
            Else
                Return False
            End If

        Catch ex As Exception
            Return False
            MessageBox.Show(Err.Description & " " & "fun_Insertar_TRCAOBME")
        End Try

    End Function

    ''' <summary>
    ''' Función que Elimina el registro.
    ''' </summary>
    Public Function fun_Eliminar_IDRE_TRCAOBME(ByVal inTCMEIDRE As Integer) As Boolean

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "DELETE "
            stConsultaSQL += "TRCAOBME "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "TCMEIDRE = '" & CInt(inTCMEIDRE) & "' "

            ' instancia la clase
            Dim objenq As New cExecuteNonQuery

            ' verifica la operación
            If objenq.ActualizarDb_Text_SQL(stConsultaSQL) = True Then
                Return True
            Else
                Return False
            End If

        Catch ex As Exception
            Return False
            MessageBox.Show(Err.Description & " " & "fun_Eliminar_IDRE_TRCAOBME")
        End Try

    End Function

    ''' <summary>
    ''' Función que Elimina el registro.
    ''' </summary>
    Public Function fun_Eliminar_SECU_TRCAOBME(ByVal inTCMESECU As Integer) As Boolean

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "DELETE "
            stConsultaSQL += "TRCAOBME "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "TCMESECU = '" & CInt(inTCMESECU) & "' "

            ' instancia la clase
            Dim objenq As New cExecuteNonQuery

            ' verifica la operación
            If objenq.ActualizarDb_Text_SQL(stConsultaSQL) = True Then
                Return True
            Else
                Return False
            End If

        Catch ex As Exception
            Return False
            MessageBox.Show(Err.Description & " " & "fun_Eliminar_IDRE_TRCAOBME")
        End Try

    End Function

    ''' <summary>
    ''' Función que Modifica el registro.
    ''' </summary>
    Public Function fun_Actualizar_TRCAOBME(ByVal inTCMESECU As Integer, _
                                            ByVal stTCMEOBSE As String) As Boolean

        Try

            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "UPDATE "
            stConsultaSQL += "TRCAOBME "

            stConsultaSQL += "SET "
            stConsultaSQL += "TCMEOBSE = '" & CStr(Trim(stTCMEOBSE)) & "' "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "TCMESECU = '" & CInt(inTCMESECU) & "' "

            ' instancia la clase
            Dim objenq As New cExecuteNonQuery

            ' verifica la operación
            If objenq.ActualizarDb_Text_SQL(stConsultaSQL) = True Then
                Return True
            Else
                Return False
            End If

        Catch ex As Exception
            Return False
            MessageBox.Show(Err.Description & " " & "fun_Actualizar_TRCAOBME")
        End Try

    End Function

    ''' <summary>
    ''' Consulta para llenar el DataGridView y colocar el nombre del encabezado
    ''' de la columna. 
    ''' </summary>
    Public Function fun_Consultar_TRCAOBME() As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "TCMEIDRE, "
            stConsultaSQL += "TCMESECU, "
            stConsultaSQL += "TCMEOBSE "

            stConsultaSQL += "FROM "
            stConsultaSQL += "TRCAOBME "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Consultar_TRCAOBME")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que busca el ID del codigo buscado para ejecutar la consulta
    ''' parametrizada.
    ''' </summary>
    Public Function fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_TRCAOBME(ByVal inTCMESECU As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "TCMEIDRE, "
            stConsultaSQL += "TCMESECU, "
            stConsultaSQL += "TCMEOBSE "

            stConsultaSQL += "FROM "
            stConsultaSQL += "TRCAOBME "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "TCMESECU = '" & CInt(inTCMESECU) & "'"

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception

            MessageBox.Show(Err.Description & " " & "fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_TRCAOBME")
            Return Nothing

        End Try

    End Function

    ''' <summary>
    ''' Función que busca el CÓDIGO para que no se 
    ''' guarden registros duplicados.
    ''' </summary>
    Public Function fun_Buscar_CODIGO_X_TRCAOBME(ByVal inTCMESECU As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "TRCAOBME "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "TCMESECU = '" & CInt(inTCMESECU) & "' "


            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Buscar_CODIGO_TRABCAMP")
            Return Nothing
        End Try

    End Function

End Class
