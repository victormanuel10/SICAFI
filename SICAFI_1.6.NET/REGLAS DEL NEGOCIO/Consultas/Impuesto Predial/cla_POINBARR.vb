Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration
Imports DATOS

Public Class cla_POINBARR

    '=================================================
    '*** CLASE PORCENTAJE DE INCREMENTO POR BARRIO ***
    '=================================================

    ''' <summary>
    ''' Función que inserta el registro.
    ''' </summary>
    Public Function fun_Insertar_POINBARR(ByVal stPIBADEPA As String, _
                                          ByVal stPIBAMUNI As String, _
                                          ByVal stPIBACORR As String, _
                                          ByVal stPIBABARR As String, _
                                          ByVal stPIBACLSE As String, _
                                          ByVal stPIBAINPR As String) As Boolean

        Try

            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "INSERT INTO "
            stConsultaSQL += "POINBARR "

            stConsultaSQL += "( "
            stConsultaSQL += "PIBADEPA, "
            stConsultaSQL += "PIBAMUNI, "
            stConsultaSQL += "PIBACORR, "
            stConsultaSQL += "PIBABARR, "
            stConsultaSQL += "PIBACLSE, "
            stConsultaSQL += "PIBAINPR "
            stConsultaSQL += ") "

            stConsultaSQL += "VALUES "

            stConsultaSQL += "( "
            stConsultaSQL += "'" & CStr(Trim(stPIBADEPA)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stPIBAMUNI)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stPIBACORR)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stPIBABARR)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stPIBACLSE)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stPIBAINPR)) & "' "
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
            MessageBox.Show(Err.Description & " " & "fun_Insertar_POINBARR")
        End Try

    End Function

    ''' <summary>
    ''' Función que Elimina el registro.
    ''' </summary>
    Public Function fun_Eliminar_X_ID_POINBARR(ByVal inPIBAIDRE As Integer) As Boolean

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "DELETE "
            stConsultaSQL += "POINBARR "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "PIBAIDRE = '" & CInt(inPIBAIDRE) & "' "

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
            MessageBox.Show(Err.Description & " " & "fun_Eliminar_POINBARR")
        End Try

    End Function

    ''' <summary>
    ''' Función que Elimina el registro.
    ''' </summary>
    Public Function fun_Eliminar_POINBARR() As Boolean

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "DELETE "
            stConsultaSQL += "POINBARR "

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
            MessageBox.Show(Err.Description & " " & "fun_Eliminar_POINBARR")
        End Try

    End Function

    ''' <summary>
    ''' Función que Modifica el registro.
    ''' </summary>
    Public Function fun_Actualizar_POINBARR(ByVal inPIBAIDRE As Integer, _
                                            ByVal stPIBADEPA As String, _
                                            ByVal stPIBAMUNI As String, _
                                            ByVal stPIBACORR As String, _
                                            ByVal stPIBABARR As String, _
                                            ByVal stPIBACLSE As String, _
                                            ByVal stPIBAINPR As String) As Boolean

        Try

            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "UPDATE "
            stConsultaSQL += "POINBARR "

            stConsultaSQL += "SET "
            stConsultaSQL += "PIBADEPA = '" & CStr(Trim(stPIBADEPA)) & "', "
            stConsultaSQL += "PIBAMUNI = '" & CStr(Trim(stPIBAMUNI)) & "', "
            stConsultaSQL += "PIBACORR = '" & CStr(Trim(stPIBACORR)) & "', "
            stConsultaSQL += "PIBABARR = '" & CStr(Trim(stPIBABARR)) & "', "
            stConsultaSQL += "PIBACLSE = '" & CStr(Trim(stPIBACLSE)) & "', "
            stConsultaSQL += "PIBAINPR = '" & CStr(Trim(stPIBAINPR)) & "' "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "PIBAIDRE = '" & CInt(inPIBAIDRE) & "'"

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
            MessageBox.Show(Err.Description & " " & "fun_Actualizar_POINBARR")
        End Try

    End Function

    ''' <summary>
    ''' Función que Modifica el registro.
    ''' </summary>
    Public Function fun_Actualizar_INPR_X_ID_POINBARR(ByVal inPIBAIDRE As Integer, _
                                                      ByVal stPIBAINPR As String) As Boolean

        Try

            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "UPDATE "
            stConsultaSQL += "POINBARR "

            stConsultaSQL += "SET "
            stConsultaSQL += "PIBAINPR = '" & CStr(Trim(stPIBAINPR)) & "' "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "PIBAIDRE = '" & CInt(inPIBAIDRE) & "'"

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
            MessageBox.Show(Err.Description & " " & "fun_Actualizar_POINBARR")
        End Try

    End Function

    ''' <summary>
    ''' Consulta para llenar el DataGridView y colocar el nombre del encabezado
    ''' de la columna. 
    ''' </summary>
    Public Function fun_Consultar_POINBARR() As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "PIBADEPA, "
            stConsultaSQL += "PIBAMUNI, "
            stConsultaSQL += "PIBACORR, "
            stConsultaSQL += "PIBABARR, "
            stConsultaSQL += "PIBACLSE, "
            stConsultaSQL += "PIBAINPR "

            stConsultaSQL += "FROM "
            stConsultaSQL += "POINBARR "

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "PIBADEPA, PIBAMUNI, PIBACORR, PIBABARR "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Consultar_POINBARR")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Consulta para llenar el DataGridView y colocar el nombre del encabezado
    ''' de la columna. 
    ''' </summary>
    Public Function fun_Consultar_X_ID_POINBARR(ByVal stPIBAIDRE As String) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "PIBADEPA, "
            stConsultaSQL += "PIBAMUNI, "
            stConsultaSQL += "PIBACORR, "
            stConsultaSQL += "PIBABARR, "
            stConsultaSQL += "PIBACLSE, "
            stConsultaSQL += "PIBAINPR "

            stConsultaSQL += "FROM "
            stConsultaSQL += "POINBARR "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "PIBAIDRE = '" & CInt(stPIBAIDRE) & "' "

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "PIBADEPA, PIBAMUNI, PIBACORR, PIBABARR "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Consultar_POINBARR")
            Return Nothing
        End Try

    End Function

End Class
