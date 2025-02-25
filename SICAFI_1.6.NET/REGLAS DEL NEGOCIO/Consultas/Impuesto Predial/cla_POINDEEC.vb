Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration
Imports DATOS

Public Class cla_POINDEEC

    '============================================================
    '*** CLASE PORCENTAJE DE INCREMENTO POR DESTINO ECONOMICO ***
    '============================================================

    ''' <summary>
    ''' Función que inserta el registro.
    ''' </summary>
    Public Function fun_Insertar_POINDEEC(ByVal stPIDEDEPA As String, _
                                          ByVal stPIDEMUNI As String, _
                                          ByVal stPIDECORR As String, _
                                          ByVal stPIDEBARR As String, _
                                          ByVal stPIDECLSE As String, _
                                          ByVal stPIDEARTE As String, _
                                          ByVal stPIDEDEEC As String, _
                                          ByVal stPIDEINPR As String, _
                                          ByVal stPIDEINAV As String) As Boolean

        Try

            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "INSERT INTO "
            stConsultaSQL += "POINDEEC "

            stConsultaSQL += "( "
            stConsultaSQL += "PIDEDEPA, "
            stConsultaSQL += "PIDEMUNI, "
            stConsultaSQL += "PIDECORR, "
            stConsultaSQL += "PIDEBARR, "
            stConsultaSQL += "PIDECLSE, "
            stConsultaSQL += "PIDEARTE, "
            stConsultaSQL += "PIDEDEEC, "
            stConsultaSQL += "PIDEINPR, "
            stConsultaSQL += "PIDEINAV "
            stConsultaSQL += ") "

            stConsultaSQL += "VALUES "

            stConsultaSQL += "( "
            stConsultaSQL += "'" & CStr(Trim(stPIDEDEPA)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stPIDEMUNI)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stPIDECORR)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stPIDEBARR)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stPIDECLSE)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stPIDEARTE)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stPIDEDEEC)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stPIDEINPR)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stPIDEINAV)) & "' "
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
            MessageBox.Show(Err.Description & " " & "fun_Insertar_POINDEEC")
        End Try

    End Function

    ''' <summary>
    ''' Función que Elimina el registro.
    ''' </summary>
    Public Function fun_Eliminar_X_ID_POINDEEC(ByVal inPIDEIDRE As Integer) As Boolean

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "DELETE "
            stConsultaSQL += "POINDEEC "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "PIDEIDRE = '" & CInt(inPIDEIDRE) & "' "

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
            MessageBox.Show(Err.Description & " " & "fun_Eliminar_POINDEEC")
        End Try

    End Function

    ''' <summary>
    ''' Función que Elimina el registro.
    ''' </summary>
    Public Function fun_Eliminar_POINDEEC() As Boolean

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "DELETE "
            stConsultaSQL += "POINDEEC "

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
            MessageBox.Show(Err.Description & " " & "fun_Eliminar_POINDEEC")
        End Try

    End Function

    ''' <summary>
    ''' Función que Modifica el registro.
    ''' </summary>
    Public Function fun_Actualizar_POINDEEC(ByVal inPIDEIDRE As Integer, _
                                            ByVal stPIDEDEPA As String, _
                                            ByVal stPIDEMUNI As String, _
                                            ByVal stPIDECORR As String, _
                                            ByVal stPIDEBARR As String, _
                                            ByVal stPIDECLSE As String, _
                                            ByVal stPIDEARTE As String, _
                                            ByVal stPIDEDEEC As String, _
                                            ByVal stPIDEINPR As String, _
                                            ByVal stPIDEINAV As String) As Boolean

        Try

            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "UPDATE "
            stConsultaSQL += "POINDEEC "

            stConsultaSQL += "SET "
            stConsultaSQL += "PIDEDEPA = '" & CStr(Trim(stPIDEDEPA)) & "', "
            stConsultaSQL += "PIDEMUNI = '" & CStr(Trim(stPIDEMUNI)) & "', "
            stConsultaSQL += "PIDECORR = '" & CStr(Trim(stPIDECORR)) & "', "
            stConsultaSQL += "PIDEBARR = '" & CStr(Trim(stPIDEBARR)) & "', "
            stConsultaSQL += "PIDECLSE = '" & CStr(Trim(stPIDECLSE)) & "', "
            stConsultaSQL += "PIDEARTE = '" & CStr(Trim(stPIDEARTE)) & "', "
            stConsultaSQL += "PIDEDEEC = '" & CStr(Trim(stPIDEDEEC)) & "', "
            stConsultaSQL += "PIDEINPR = '" & CStr(Trim(stPIDEINPR)) & "', "
            stConsultaSQL += "PIDEINAV = '" & CStr(Trim(stPIDEINAV)) & "' "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "PIDEIDRE = '" & CInt(inPIDEIDRE) & "'"

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
            MessageBox.Show(Err.Description & " " & "fun_Actualizar_POINDEEC")
        End Try

    End Function

    ''' <summary>
    ''' Función que Modifica el registro.
    ''' </summary>
    Public Function fun_Actualizar_INPR_X_ID_POINDEEC(ByVal inPIDEIDRE As Integer, _
                                                      ByVal stPIDEINPR As String) As Boolean

        Try

            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "UPDATE "
            stConsultaSQL += "POINDEEC "

            stConsultaSQL += "SET "
            stConsultaSQL += "PIDEINPR = '" & CStr(Trim(stPIDEINPR)) & "' "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "PIDEIDRE = '" & CInt(inPIDEIDRE) & "'"

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
            MessageBox.Show(Err.Description & " " & "fun_Actualizar_POINDEEC")
        End Try

    End Function

    ''' <summary>
    ''' Consulta para llenar el DataGridView y colocar el nombre del encabezado
    ''' de la columna. 
    ''' </summary>
    Public Function fun_Consultar_POINDEEC() As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "PIDEDEPA, "
            stConsultaSQL += "PIDEMUNI, "
            stConsultaSQL += "PIDECORR, "
            stConsultaSQL += "PIDEBARR, "
            stConsultaSQL += "PIDECLSE, "
            stConsultaSQL += "PIDEARTE, "
            stConsultaSQL += "PIDEDEEC, "
            stConsultaSQL += "PIDEINPR, "
            stConsultaSQL += "PIDEINAV "

            stConsultaSQL += "FROM "
            stConsultaSQL += "POINDEEC "

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "PIDEDEPA, PIDEMUNI, PIDECORR, PIDEBARR "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Consultar_POINDEEC")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Consulta para llenar el DataGridView y colocar el nombre del encabezado
    ''' de la columna. 
    ''' </summary>
    Public Function fun_Consultar_X_ID_POINDEEC(ByVal stPIDEIDRE As String) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "PIDEDEPA, "
            stConsultaSQL += "PIDEMUNI, "
            stConsultaSQL += "PIDECORR, "
            stConsultaSQL += "PIDEBARR, "
            stConsultaSQL += "PIDECLSE, "
            stConsultaSQL += "PIDEARTE, "
            stConsultaSQL += "PIDEDEEC, "
            stConsultaSQL += "PIDEINPR, "
            stConsultaSQL += "PIDEINAV "

            stConsultaSQL += "FROM "
            stConsultaSQL += "POINDEEC "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "PIDEIDRE = '" & CInt(stPIDEIDRE) & "' "

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "PIDEDEPA, PIDEMUNI, PIDECORR, PIDEBARR "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Consultar_POINDEEC")
            Return Nothing
        End Try

    End Function

End Class
