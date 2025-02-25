Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration
Imports DATOS

Public Class cla_POINESTR

    '===========================================================
    '*** CLASE PORCENTAJE DE INCREMENTO POR ESTRATO Y AVALUO ***
    '===========================================================

    ''' <summary>
    ''' Función que inserta el registro.
    ''' </summary>
    Public Function fun_Insertar_POINESTR(ByVal stPIESDEPA As String, _
                                          ByVal stPIESMUNI As String, _
                                          ByVal stPIESCLSE As String, _
                                          ByVal stPIESAVPR As String, _
                                          ByVal stPIESPRPR As String, _
                                          ByVal stPIESESTR As String, _
                                          ByVal stPIESPUNT As String) As Boolean

        Try

            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "INSERT INTO "
            stConsultaSQL += "POINESTR "

            stConsultaSQL += "( "
            stConsultaSQL += "PIESDEPA, "
            stConsultaSQL += "PIESMUNI, "
            stConsultaSQL += "PIESCLSE, "
            stConsultaSQL += "PIESAVPR, "
            stConsultaSQL += "PIESPRPR, "
            stConsultaSQL += "PIESESTR, "
            stConsultaSQL += "PIESPUNT  "
            stConsultaSQL += ") "

            stConsultaSQL += "VALUES "

            stConsultaSQL += "( "
            stConsultaSQL += "'" & CStr(Trim(stPIESDEPA)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stPIESMUNI)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stPIESCLSE)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stPIESAVPR)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stPIESPRPR)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stPIESESTR)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stPIESPUNT)) & "' "
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
            MessageBox.Show(Err.Description & " " & "fun_Insertar_POINESTR")
        End Try

    End Function

    ''' <summary>
    ''' Función que Elimina el registro.
    ''' </summary>
    Public Function fun_Eliminar_X_ID_POINESTR(ByVal inPIESIDRE As Integer) As Boolean

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "DELETE "
            stConsultaSQL += "POINESTR "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "PIESIDRE = '" & CInt(inPIESIDRE) & "' "

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
            MessageBox.Show(Err.Description & " " & "fun_Eliminar_POINESTR")
        End Try

    End Function

    ''' <summary>
    ''' Función que Elimina el registro.
    ''' </summary>
    Public Function fun_Eliminar_POINESTR() As Boolean

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "DELETE "
            stConsultaSQL += "POINESTR "

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
            MessageBox.Show(Err.Description & " " & "fun_Eliminar_POINESTR")
        End Try

    End Function

    ''' <summary>
    ''' Función que Modifica el registro.
    ''' </summary>
    Public Function fun_Actualizar_POINESTR(ByVal inPIESIDRE As Integer, _
                                            ByVal stPIESDEPA As String, _
                                            ByVal stPIESMUNI As String, _
                                            ByVal stPIESCLSE As String, _
                                            ByVal stPIESAVPR As String, _
                                            ByVal stPIESPRPR As String, _
                                            ByVal stPIESESTR As String, _
                                            ByVal stPIESPUNT As String) As Boolean

        Try

            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "UPDATE "
            stConsultaSQL += "POINESTR "

            stConsultaSQL += "SET "
            stConsultaSQL += "PIESDEPA = '" & CStr(Trim(stPIESDEPA)) & "', "
            stConsultaSQL += "PIESMUNI = '" & CStr(Trim(stPIESMUNI)) & "', "
            stConsultaSQL += "PIESCLSE = '" & CStr(Trim(stPIESCLSE)) & "', "
            stConsultaSQL += "PIESAVPR = '" & CStr(Trim(stPIESAVPR)) & "', "
            stConsultaSQL += "PIESPRPR = '" & CStr(Trim(stPIESPRPR)) & "', "
            stConsultaSQL += "PIESESTR = '" & CStr(Trim(stPIESESTR)) & "', "
            stConsultaSQL += "PIESPUNT = '" & CStr(Trim(stPIESPUNT)) & "' "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "PIESIDRE = '" & CInt(inPIESIDRE) & "'"

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
            MessageBox.Show(Err.Description & " " & "fun_Actualizar_POINESTR")
        End Try

    End Function

    ''' <summary>
    ''' Consulta para llenar el DataGridView y colocar el nombre del encabezado
    ''' de la columna. 
    ''' </summary>
    Public Function fun_Consultar_POINESTR() As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "PIESDEPA, "
            stConsultaSQL += "PIESMUNI, "
            stConsultaSQL += "PIESCLSE, "
            stConsultaSQL += "PIESAVPR, "
            stConsultaSQL += "PIESPRPR, "
            stConsultaSQL += "PIESESTR, "
            stConsultaSQL += "PIESPUNT "

            stConsultaSQL += "FROM "
            stConsultaSQL += "POINESTR "

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "PIESDEPA, PIESMUNI, PIESCLSE "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Consultar_POINESTR")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Consulta para llenar el DataGridView y colocar el nombre del encabezado
    ''' de la columna. 
    ''' </summary>
    Public Function fun_Consultar_X_ID_POINESTR(ByVal stPIESIDRE As String) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "PIESDEPA, "
            stConsultaSQL += "PIESMUNI, "
            stConsultaSQL += "PIESCLSE, "
            stConsultaSQL += "PIESAVPR, "
            stConsultaSQL += "PIESPRPR, "
            stConsultaSQL += "PIESESTR, "
            stConsultaSQL += "PIESPUNT "

            stConsultaSQL += "FROM "
            stConsultaSQL += "POINESTR "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "PIESIDRE = '" & CInt(stPIESIDRE) & "' "

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "PIESDEPA, PIESMUNI, PIESCLSE "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Consultar_POINESTR")
            Return Nothing
        End Try

    End Function

End Class
