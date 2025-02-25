Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration
Imports DATOS

Public Class cla_RECOZOEC

    '===========================================================
    '*** CLASE RESOLUCIONES DE CONSERVACION ZONAS ECONOMICAS ***
    '===========================================================

    ''' <summary>
    ''' procedimiento que verifica la llave primaria.
    ''' </summary>
    Public Function fun_Verifica_llave_Primaria_RECOZOEC(ByVal obRCZENURE As Object, _
                                                         ByVal obRCZEFERE As Object, _
                                                         ByVal obRCZENUFI As Object, _
                                                         ByVal obRCZEZOEC As Object) As Boolean

        Try
            Dim boRespuesta As Boolean = False

            Dim obVerifica As New cla_Verificar_Dato

            If obVerifica.fun_Verificar_Campo_Lleno(obRCZENURE.Text) = True And _
                obVerifica.fun_Verificar_Campo_Lleno(obRCZEFERE.Text) = True And _
                obVerifica.fun_Verificar_Campo_Lleno(obRCZENUFI.Text) = True And _
                obVerifica.fun_Verificar_Campo_Lleno(obRCZEZOEC.Text) = True Then

                Dim objdatos1 As New cla_RECOZOEC
                Dim tbl As New DataTable

                tbl = objdatos1.fun_Buscar_CODIGO_X_RECOZOEC(obRCZENURE.Text, obRCZEFERE.Text, obRCZENUFI.Text, obRCZEZOEC.Text)

                If tbl.Rows.Count > 0 Then
                    MessageBox.Show("El registro existe en la base de datos.", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1)
                    boRespuesta = False
                Else
                    boRespuesta = True
                End If

            End If

            Return boRespuesta

        Catch ex As Exception
            Return False
        End Try

    End Function

    ''' <summary>
    ''' Función que inserta el registro.
    ''' </summary>
    Public Function fun_Insertar_RECOZOEC(ByVal inRCZESECU As Integer, _
                                          ByVal inRCZENURE As Integer, _
                                          ByVal stRCZEFERE As String, _
                                          ByVal inRCZENUFI As Integer, _
                                          ByVal inRCZEZOEC As Integer, _
                                          ByVal inRCZEPORC As Integer, _
                                          ByVal stRCZEESTA As String) As Boolean


        Try

            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "INSERT INTO "
            stConsultaSQL += "RECOZOEC "

            stConsultaSQL += "( "
            stConsultaSQL += "RCZESECU, "
            stConsultaSQL += "RCZENURE, "
            stConsultaSQL += "RCZEFERE, "
            stConsultaSQL += "RCZENUFI, "
            stConsultaSQL += "RCZEZOEC, "
            stConsultaSQL += "RCZEPORC, "
            stConsultaSQL += "RCZEESTA "
            stConsultaSQL += ") "

            stConsultaSQL += "VALUES "

            stConsultaSQL += "( "
            stConsultaSQL += "'" & CInt(inRCZESECU) & "', "
            stConsultaSQL += "'" & CInt(inRCZENURE) & "', "
            stConsultaSQL += "'" & CStr(Trim(stRCZEFERE)) & "', "
            stConsultaSQL += "'" & CInt(inRCZENUFI) & "', "
            stConsultaSQL += "'" & CInt(inRCZEZOEC) & "', "
            stConsultaSQL += "'" & CInt(inRCZEPORC) & "', "
            stConsultaSQL += "'" & CStr(Trim(stRCZEESTA)) & "' "
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
            MessageBox.Show(Err.Description & " " & "fun_Insertar_RECOZOEC")
        End Try

    End Function

    ''' <summary>
    ''' Función que Elimina el registro.
    ''' </summary>
    Public Function fun_Eliminar_CODIGO_RECOZOEC(ByVal inRCZENURE As Integer, _
                                                 ByVal stRCZEFERE As String, _
                                                 ByVal inRCZENUFI As Integer, _
                                                 ByVal inRCZEZOEC As Integer) As Boolean

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "DELETE "
            stConsultaSQL += "RECOZOEC "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "RCZENURE = '" & CInt(inRCZENURE) & "' AND "
            stConsultaSQL += "RCZEFERE = '" & CStr(Trim(stRCZEFERE)) & "' AND "
            stConsultaSQL += "RCZENUFI = '" & CInt(inRCZENUFI) & "' AND "
            stConsultaSQL += "RCZEZOEC = '" & CInt(inRCZEZOEC) & "' "

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
            MessageBox.Show(Err.Description & " " & "fun_Eliminar_RECOZOEC")
        End Try

    End Function

    ''' <summary>
    ''' Función que Modifica el registro.
    ''' </summary>
    Public Function fun_Actualizar_RECOZOEC(ByVal inRCZEIDRE As Integer, _
                                            ByVal inRCZENURE As Integer, _
                                            ByVal stRCZEFERE As String, _
                                            ByVal inRCZENUFI As Integer, _
                                            ByVal inRCZEZOEC As Integer, _
                                            ByVal inRCZEPORC As Integer, _
                                            ByVal stRCZEESTA As String) As Boolean

        Try

            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "UPDATE "
            stConsultaSQL += "RECOZOEC "

            stConsultaSQL += "SET "
            stConsultaSQL += "RCZENURE = '" & CInt(inRCZENURE) & "', "
            stConsultaSQL += "RCZEFERE = '" & CStr(Trim(stRCZEFERE)) & "', "
            stConsultaSQL += "RCZENUFI = '" & CInt(inRCZENUFI) & "', "
            stConsultaSQL += "RCZEZOEC = '" & CInt(inRCZEZOEC) & "', "
            stConsultaSQL += "RCZEPORC = '" & CInt(inRCZEPORC) & "', "
            stConsultaSQL += "RCZEESTA = '" & CStr(Trim(stRCZEESTA)) & "' "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "RCZEIDRE = '" & CInt(inRCZEIDRE) & "' "

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
            MessageBox.Show(Err.Description & " " & "fun_Actualizar_RECOZOEC")
        End Try

    End Function

    ''' <summary>
    ''' Función que busca el ID del registro a modificar o eliminar.
    ''' </summary>
    Public Function fun_Buscar_CODIGO_X_RECOZOEC(ByVal inRCZENURE As Integer, _
                                                 ByVal stRCZEFERE As String, _
                                                 ByVal inRCZENUFI As Integer, _
                                                 ByVal inRCZEZOEC As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "RECOZOEC "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "RCZENURE = '" & CInt(inRCZENURE) & "' AND "
            stConsultaSQL += "RCZEFERE = '" & CStr(Trim(stRCZEFERE)) & "' AND "
            stConsultaSQL += "RCZENUFI = '" & CInt(inRCZENUFI) & "' "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Buscar_NURA_FERA_X_RECOZOEC")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que busca el SECU del codigo buscado para ejecutar la consulta
    ''' parametrizada.
    ''' </summary>
    Public Function fun_Buscar_SECU_X_CONSULTA_PARAMETRIZADA_RECOZOEC(ByVal inRCZESECU As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "RCZEIDRE, "
            stConsultaSQL += "RCZESECU, "
            stConsultaSQL += "RCZENURE, "
            stConsultaSQL += "RCZEFERE, "
            stConsultaSQL += "RCZENUFI, "
            stConsultaSQL += "RCZEZOEC, "
            stConsultaSQL += "RCZEPORC, "
            stConsultaSQL += "RCZEESTA "

            stConsultaSQL += "FROM "
            stConsultaSQL += "RECOZOEC "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "RCZESECU = '" & CInt(inRCZESECU) & "' "

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "RCZESECU "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception

            MessageBox.Show(Err.Description & " " & "fun_Buscar_SECU_X_CONSULTA_PARAMETRIZADA_RECOZOEC")
            Return Nothing

        End Try

    End Function

    ''' <summary>
    ''' Función que consulta los registros
    ''' parametrizada.
    ''' </summary>
    Public Function fun_Consultar_RECOZOEC(ByVal inRCZESECU As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "TOP 10 "
            stConsultaSQL += "RCZEIDRE, "
            stConsultaSQL += "RCZESECU, "
            stConsultaSQL += "RCZENURE, "
            stConsultaSQL += "RCZEFERE, "
            stConsultaSQL += "RCZENUFI, "
            stConsultaSQL += "RCZEZOEC, "
            stConsultaSQL += "RCZEPORC, "
            stConsultaSQL += "RCZEESTA "

            stConsultaSQL += "FROM "
            stConsultaSQL += "RECOZOEC "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "RCZESECU = '" & CInt(inRCZESECU) & "' "

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "RCZESECU "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception

            MessageBox.Show(Err.Description & " " & "fun_Buscar_SECU_X_CONSULTA_PARAMETRIZADA_RECOZOEC")
            Return Nothing

        End Try

    End Function

End Class
