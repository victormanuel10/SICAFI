Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration
Imports DATOS

Public Class cla_POINPUNT

    '=================================================
    '*** CLASE PORCENTAJE DE INCREMENTO POR PUNTOS ***
    '=================================================

    ''' <summary>
    ''' Función que inserta el registro.
    ''' </summary>
    Public Function fun_Insertar_POINPUNT(ByVal stPIPUDEPA As String, _
                                          ByVal stPIPUMUNI As String, _
                                          ByVal stPIPUCORR As String, _
                                          ByVal stPIPUBARR As String, _
                                          ByVal stPIPUCLSE As String, _
                                          ByVal stPIPUPUNT As String, _
                                          ByVal stPIPUINPR As String) As Boolean

        Try

            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "INSERT INTO "
            stConsultaSQL += "POINPUNT "

            stConsultaSQL += "( "
            stConsultaSQL += "PIPUDEPA, "
            stConsultaSQL += "PIPUMUNI, "
            stConsultaSQL += "PIPUCORR, "
            stConsultaSQL += "PIPUBARR, "
            stConsultaSQL += "PIPUCLSE, "
            stConsultaSQL += "PIPUPUNT, "
            stConsultaSQL += "PIPUINPR "
            stConsultaSQL += ") "

            stConsultaSQL += "VALUES "

            stConsultaSQL += "( "
            stConsultaSQL += "'" & CStr(Trim(stPIPUDEPA)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stPIPUMUNI)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stPIPUCORR)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stPIPUBARR)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stPIPUCLSE)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stPIPUPUNT)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stPIPUINPR)) & "' "
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
            MessageBox.Show(Err.Description & " " & "fun_Insertar_POINPUNT")
        End Try

    End Function

    ''' <summary>
    ''' Función que Elimina el registro.
    ''' </summary>
    Public Function fun_Eliminar_X_ID_POINPUNT(ByVal inPIPUIDRE As Integer) As Boolean

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "DELETE "
            stConsultaSQL += "POINPUNT "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "PIPUIDRE = '" & CInt(inPIPUIDRE) & "' "

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
            MessageBox.Show(Err.Description & " " & "fun_Eliminar_POINPUNT")
        End Try

    End Function

    ''' <summary>
    ''' Función que Elimina el registro.
    ''' </summary>
    Public Function fun_Eliminar_POINPUNT() As Boolean

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "DELETE "
            stConsultaSQL += "POINPUNT "

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
            MessageBox.Show(Err.Description & " " & "fun_Eliminar_POINPUNT")
        End Try

    End Function

    ''' <summary>
    ''' Función que Modifica el registro.
    ''' </summary>
    Public Function fun_Actualizar_POINPUNT(ByVal inPIPUIDRE As Integer, _
                                            ByVal stPIPUDEPA As String, _
                                            ByVal stPIPUMUNI As String, _
                                            ByVal stPIPUCORR As String, _
                                            ByVal stPIPUBARR As String, _
                                            ByVal stPIPUCLSE As String, _
                                            ByVal stPIPUPUNT As String, _
                                            ByVal stPIPUINPR As String) As Boolean

        Try

            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "UPDATE "
            stConsultaSQL += "POINPUNT "

            stConsultaSQL += "SET "
            stConsultaSQL += "PIPUDEPA = '" & CStr(Trim(stPIPUDEPA)) & "', "
            stConsultaSQL += "PIPUMUNI = '" & CStr(Trim(stPIPUMUNI)) & "', "
            stConsultaSQL += "PIPUCORR = '" & CStr(Trim(stPIPUCORR)) & "', "
            stConsultaSQL += "PIPUBARR = '" & CStr(Trim(stPIPUBARR)) & "', "
            stConsultaSQL += "PIPUCLSE = '" & CStr(Trim(stPIPUCLSE)) & "', "
            stConsultaSQL += "PIPUPUNT = '" & CStr(Trim(stPIPUPUNT)) & "', "
            stConsultaSQL += "PIPUINPR = '" & CStr(Trim(stPIPUINPR)) & "' "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "PIPUIDRE = '" & CInt(inPIPUIDRE) & "'"

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
            MessageBox.Show(Err.Description & " " & "fun_Actualizar_POINPUNT")
        End Try

    End Function

    ''' <summary>
    ''' Función que Modifica el registro.
    ''' </summary>
    Public Function fun_Actualizar_INPR_X_ID_POINPUNT(ByVal inPIPUIDRE As Integer, _
                                                      ByVal stPIPUINPR As String) As Boolean

        Try

            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "UPDATE "
            stConsultaSQL += "POINPUNT "

            stConsultaSQL += "SET "
            stConsultaSQL += "PIPUINPR = '" & CStr(Trim(stPIPUINPR)) & "' "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "PIPUIDRE = '" & CInt(inPIPUIDRE) & "'"

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
            MessageBox.Show(Err.Description & " " & "fun_Actualizar_POINPUNT")
        End Try

    End Function

    ''' <summary>
    ''' Consulta para llenar el DataGridView y colocar el nombre del encabezado
    ''' de la columna. 
    ''' </summary>
    Public Function fun_Consultar_POINPUNT() As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "PIPUDEPA, "
            stConsultaSQL += "PIPUMUNI, "
            stConsultaSQL += "PIPUCORR, "
            stConsultaSQL += "PIPUBARR, "
            stConsultaSQL += "PIPUCLSE, "
            stConsultaSQL += "PIPUPUNT, "
            stConsultaSQL += "PIPUINPR "

            stConsultaSQL += "FROM "
            stConsultaSQL += "POINPUNT "

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "PIPUDEPA, PIPUMUNI, PIPUCORR, PIPUBARR "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Consultar_POINPUNT")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Consulta para llenar el DataGridView y colocar el nombre del encabezado
    ''' de la columna. 
    ''' </summary>
    Public Function fun_Consultar_X_ID_POINPUNT(ByVal stPIPUIDRE As String) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "PIPUDEPA, "
            stConsultaSQL += "PIPUMUNI, "
            stConsultaSQL += "PIPUCORR, "
            stConsultaSQL += "PIPUBARR, "
            stConsultaSQL += "PIPUCLSE, "
            stConsultaSQL += "PIPUPUNT, "
            stConsultaSQL += "PIPUINPR "

            stConsultaSQL += "FROM "
            stConsultaSQL += "POINPUNT "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "PIPUIDRE = '" & CInt(stPIPUIDRE) & "' "

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "PIPUDEPA, PIPUMUNI, PIPUCORR, PIPUBARR "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Consultar_POINPUNT")
            Return Nothing
        End Try

    End Function

End Class
