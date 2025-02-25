Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration
Imports DATOS

Public Class cla_TRCAOBMR

    '============================================
    '*** CLASE OBSERVACION MATERIAL REGISTRO ***
    '============================================

    ''' <summary>
    ''' Función que inserta el registro.
    ''' </summary>
    Public Function fun_Insertar_TRCAOBMR(ByVal inTCMRSECU As Integer, _
                                          ByVal stTCMROBSE As String) As Boolean

        Try

            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "INSERT INTO "
            stConsultaSQL += "TRCAOBMR "

            stConsultaSQL += "( "
            stConsultaSQL += "TCMRSECU, "
            stConsultaSQL += "TCMROBSE "
            stConsultaSQL += ") "

            stConsultaSQL += "VALUES "

            stConsultaSQL += "( "
            stConsultaSQL += "'" & CInt(inTCMRSECU) & "', "
            stConsultaSQL += "'" & CStr(Trim(stTCMROBSE)) & "' "
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
            MessageBox.Show(Err.Description & " " & "fun_Insertar_TRCAOBMR")
        End Try

    End Function

    ''' <summary>
    ''' Función que Elimina el registro.
    ''' </summary>
    Public Function fun_Eliminar_IDRE_TRCAOBMR(ByVal inTCMRIDRE As Integer) As Boolean

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "DELETE "
            stConsultaSQL += "TRCAOBMR "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "TCMRIDRE = '" & CInt(inTCMRIDRE) & "' "

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
            MessageBox.Show(Err.Description & " " & "fun_Eliminar_IDRE_TRCAOBMR")
        End Try

    End Function

    ''' <summary>
    ''' Función que Elimina el registro.
    ''' </summary>
    Public Function fun_Eliminar_SECU_TRCAOBMR(ByVal inTCMRSECU As Integer) As Boolean

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "DELETE "
            stConsultaSQL += "TRCAOBMR "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "TCMRSECU = '" & CInt(inTCMRSECU) & "' "

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
            MessageBox.Show(Err.Description & " " & "fun_Eliminar_IDRE_TRCAOBMR")
        End Try

    End Function

    ''' <summary>
    ''' Función que Modifica el registro.
    ''' </summary>
    Public Function fun_Actualizar_TRCAOBMR(ByVal inTCMRSECU As Integer, _
                                            ByVal stTCMROBSE As String) As Boolean

        Try

            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "UPDATE "
            stConsultaSQL += "TRCAOBMR "

            stConsultaSQL += "SET "
            stConsultaSQL += "TCMROBSE = '" & CStr(Trim(stTCMROBSE)) & "' "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "TCMRSECU = '" & CInt(inTCMRSECU) & "' "

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
            MessageBox.Show(Err.Description & " " & "fun_Actualizar_TRCAOBMR")
        End Try

    End Function

    ''' <summary>
    ''' Consulta para llenar el DataGridView y colocar el nombre del encabezado
    ''' de la columna. 
    ''' </summary>
    Public Function fun_Consultar_TRCAOBMR() As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "TCMRIDRE, "
            stConsultaSQL += "TCMRSECU, "
            stConsultaSQL += "TCMROBSE "

            stConsultaSQL += "FROM "
            stConsultaSQL += "TRCAOBMR "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Consultar_TRCAOBMR")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que busca el ID del codigo buscado para ejecutar la consulta
    ''' parametrizada.
    ''' </summary>
    Public Function fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_TRCAOBMR(ByVal inTCMRSECU As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "TCMRIDRE, "
            stConsultaSQL += "TCMRSECU, "
            stConsultaSQL += "TCMROBSE "

            stConsultaSQL += "FROM "
            stConsultaSQL += "TRCAOBMR "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "TCMRSECU = '" & CInt(inTCMRSECU) & "'"

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception

            MessageBox.Show(Err.Description & " " & "fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_TRCAOBMR")
            Return Nothing

        End Try

    End Function

    ''' <summary>
    ''' Función que busca el CÓDIGO para que no se 
    ''' guarden registros duplicados.
    ''' </summary>
    Public Function fun_Buscar_CODIGO_X_TRCAOBMR(ByVal inTCMRSECU As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "TRCAOBMR "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "TCMRSECU = '" & CInt(inTCMRSECU) & "' "


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
