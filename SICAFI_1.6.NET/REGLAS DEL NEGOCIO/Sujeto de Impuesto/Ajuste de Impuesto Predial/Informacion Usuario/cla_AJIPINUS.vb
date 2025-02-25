Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration
Imports DATOS

Public Class cla_AJIPINUS

    '===================================================
    '*** CLASE INFORMACIÓN DE USUARIO AJUSTE PREDIAL ***
    '===================================================

    ''' <summary>
    ''' procedimiento que verifica la llave primaria.
    ''' </summary>
    Public Function fun_Verifica_llave_Primaria_AJIPINUS(ByVal obAJIUSECU As Object, ByVal obAJIUNUDO As Object) As Boolean

        Try
            Dim boRespuesta As Boolean = False

            Dim obVerifica As New cla_Verificar_Dato

            If obVerifica.fun_Verificar_Campo_Lleno(obAJIUSECU.Text) = True And _
                obVerifica.fun_Verificar_Campo_Lleno(obAJIUNUDO.Text) = True Then

                If obVerifica.fun_Verificar_Dato_Numerico(obAJIUSECU.Text) = True Then

                    Dim objdatos1 As New cla_AJIPINUS
                    Dim tbl As New DataTable

                    tbl = objdatos1.fun_Buscar_CODIGO_X_AJIPINUS(obAJIUSECU.Text, obAJIUNUDO.Text)

                    If tbl.Rows.Count > 0 Then
                        MessageBox.Show("El dato " & Trim(obAJIUSECU.Text) & " - " & Trim(obAJIUNUDO.Text) & " existe en la base de datos, se incrementara una secuencia, favor guardar.", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                        obAJIUSECU.Focus()
                        boRespuesta = False
                    Else
                        boRespuesta = True
                    End If

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
    Public Function fun_Insertar_AJIPINUS(ByVal inAJIUSECU As Integer, _
                                          ByVal stAJIUNUDO As String, _
                                          ByVal stAJIUFERE As String, _
                                          ByVal stAJIUNOMB As String, _
                                          ByVal stAJIUPRAP As String, _
                                          ByVal stAJIUSEAP As String, _
                                          ByVal stAJIUTEL1 As String, _
                                          ByVal stAJIUTEL2 As String, _
                                          ByVal stAJIUCOEL As String, _
                                          ByVal stAJIUDIPR As String, _
                                          ByVal stAJIUDICO As String, _
                                          ByVal stAJIUOBSE As String) As Boolean

        Try

            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "INSERT INTO "
            stConsultaSQL += "AJIPINUS "

            stConsultaSQL += "( "
            stConsultaSQL += "AJIUSECU, "
            stConsultaSQL += "AJIUNUDO, "
            stConsultaSQL += "AJIUFERE, "
            stConsultaSQL += "AJIUNOMB, "
            stConsultaSQL += "AJIUPRAP, "
            stConsultaSQL += "AJIUSEAP, "
            stConsultaSQL += "AJIUTEL1, "
            stConsultaSQL += "AJIUTEL2, "
            stConsultaSQL += "AJIUCOEL, "
            stConsultaSQL += "AJIUDIPR, "
            stConsultaSQL += "AJIUDICO, "
            stConsultaSQL += "AJIUOBSE "
            stConsultaSQL += ") "

            stConsultaSQL += "VALUES "

            stConsultaSQL += "( "
            stConsultaSQL += "'" & CInt(inAJIUSECU) & "', "
            stConsultaSQL += "'" & CStr(Trim(stAJIUNUDO)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stAJIUFERE)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stAJIUNOMB)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stAJIUPRAP)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stAJIUSEAP)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stAJIUTEL1)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stAJIUTEL2)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stAJIUCOEL)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stAJIUDIPR)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stAJIUDICO)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stAJIUOBSE)) & "' "
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
            MessageBox.Show(Err.Description & " " & "fun_Insertar_AJIPINUS")
        End Try

    End Function

    ''' <summary>
    ''' Función que Elimina el registro.
    ''' </summary>
    Public Function fun_Eliminar_IDRE_AJIPINUS(ByVal inAJIUIDRE As Integer) As Boolean

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "DELETE "
            stConsultaSQL += "AJIPINUS "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "AJIUIDRE = '" & CInt(inAJIUIDRE) & "' "

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
            MessageBox.Show(Err.Description & " " & "fun_Eliminar_IDRE_AJIPINUS")
        End Try

    End Function

    ''' <summary>
    ''' Función que Elimina el registro.
    ''' </summary>
    Public Function fun_Eliminar_SECU_X_NUDO_AJIPINUS(ByVal inAJIUSECU As Integer, ByVal stAJIUNUDO As String) As Boolean

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "DELETE "
            stConsultaSQL += "AJIPINUS "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "AJIUSECU = '" & CInt(inAJIUSECU) & "' and "
            stConsultaSQL += "AJIUNUDO = '" & CStr(Trim(stAJIUNUDO)) & "' "

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
            MessageBox.Show(Err.Description & " " & "fun_Eliminar_SECU_X_MACA_AJIPINUS")
        End Try

    End Function

    ''' <summary>
    ''' Función que Elimina el registro.
    ''' </summary>
    Public Function fun_Eliminar_SECU_AJIPINUS(ByVal inAJIUSECU As Integer) As Boolean

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "DELETE "
            stConsultaSQL += "AJIPINUS "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "AJIUSECU = '" & CInt(inAJIUSECU) & "' "

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
            MessageBox.Show(Err.Description & " " & "fun_Eliminar_IDRE_AJIPINUS")
        End Try

    End Function

    ''' <summary>
    ''' Función que Modifica el registro.
    ''' </summary>
    Public Function fun_Actualizar_IDRE_X_AJIPINUS(ByVal stAJIUIDRE As Integer, _
                                                   ByVal inAJIUSECU As Integer, _
                                                   ByVal stAJIUNUDO As String, _
                                                   ByVal stAJIUFERE As String, _
                                                   ByVal stAJIUNOMB As String, _
                                                   ByVal stAJIUPRAP As String, _
                                                   ByVal stAJIUSEAP As String, _
                                                   ByVal stAJIUTEL1 As String, _
                                                   ByVal stAJIUTEL2 As String, _
                                                   ByVal stAJIUCOEL As String, _
                                                   ByVal stAJIUDIPR As String, _
                                                   ByVal stAJIUDICO As String, _
                                                   ByVal stAJIUOBSE As String) As Boolean

        Try

            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "UPDATE "
            stConsultaSQL += "AJIPINUS "

            stConsultaSQL += "SET "
            stConsultaSQL += "AJIUSECU = '" & CInt(inAJIUSECU) & "', "
            stConsultaSQL += "AJIUNUDO = '" & CStr(Trim(stAJIUNUDO)) & "', "
            stConsultaSQL += "AJIUFERE = '" & CStr(Trim(stAJIUFERE)) & "', "
            stConsultaSQL += "AJIUNOMB = '" & CStr(Trim(stAJIUNOMB)) & "', "
            stConsultaSQL += "AJIUPRAP = '" & CStr(Trim(stAJIUPRAP)) & "', "
            stConsultaSQL += "AJIUSEAP = '" & CStr(Trim(stAJIUSEAP)) & "', "
            stConsultaSQL += "AJIUFERE = '" & CStr(Trim(stAJIUFERE)) & "', "
            stConsultaSQL += "AJIUTEL1 = '" & CStr(Trim(stAJIUTEL1)) & "', "
            stConsultaSQL += "AJIUTEL2 = '" & CStr(Trim(stAJIUTEL2)) & "', "
            stConsultaSQL += "AJIUCOEL = '" & CStr(Trim(stAJIUCOEL)) & "', "
            stConsultaSQL += "AJIUDIPR = '" & CStr(Trim(stAJIUDIPR)) & "', "
            stConsultaSQL += "AJIUDICO = '" & CStr(Trim(stAJIUDICO)) & "', "
            stConsultaSQL += "AJIUOBSE = '" & CStr(Trim(stAJIUOBSE)) & "' "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "AJIUIDRE = '" & CInt(stAJIUIDRE) & "' "

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
            MessageBox.Show(Err.Description & " " & "fun_Actualizar_AJIPINUS")
        End Try

    End Function

    ''' <summary>
    ''' Función que Modifica el registro.
    ''' </summary>
    Public Function fun_Actualizar_SECU_X_AJIPINUS(ByVal inAJIUSECU As Integer, _
                                                   ByVal stAJIUNUDO As String, _
                                                   ByVal stAJIUFERE As String, _
                                                   ByVal stAJIUNOMB As String, _
                                                   ByVal stAJIUPRAP As String, _
                                                   ByVal stAJIUSEAP As String, _
                                                   ByVal stAJIUTEL1 As String, _
                                                   ByVal stAJIUTEL2 As String, _
                                                   ByVal stAJIUCOEL As String, _
                                                   ByVal stAJIUDIPR As String, _
                                                   ByVal stAJIUDICO As String, _
                                                   ByVal stAJIUOBSE As String) As Boolean

        Try

            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "UPDATE "
            stConsultaSQL += "AJIPINUS "

            stConsultaSQL += "SET "
            stConsultaSQL += "AJIUSECU = '" & CInt(inAJIUSECU) & "', "
            stConsultaSQL += "AJIUNUDO = '" & CStr(Trim(stAJIUNUDO)) & "', "
            stConsultaSQL += "AJIUFERE = '" & CStr(Trim(stAJIUFERE)) & "', "
            stConsultaSQL += "AJIUNOMB = '" & CStr(Trim(stAJIUNOMB)) & "', "
            stConsultaSQL += "AJIUPRAP = '" & CStr(Trim(stAJIUPRAP)) & "', "
            stConsultaSQL += "AJIUSEAP = '" & CStr(Trim(stAJIUSEAP)) & "', "
            stConsultaSQL += "AJIUTEL1 = '" & CStr(Trim(stAJIUTEL1)) & "', "
            stConsultaSQL += "AJIUTEL2 = '" & CStr(Trim(stAJIUTEL2)) & "', "
            stConsultaSQL += "AJIUCOEL = '" & CStr(Trim(stAJIUCOEL)) & "', "
            stConsultaSQL += "AJIUDIPR = '" & CStr(Trim(stAJIUDIPR)) & "', "
            stConsultaSQL += "AJIUDICO = '" & CStr(Trim(stAJIUDICO)) & "', "
            stConsultaSQL += "AJIUOBSE = '" & CStr(Trim(stAJIUOBSE)) & "' "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "AJIUSECU = '" & CInt(inAJIUSECU) & "' "

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
            MessageBox.Show(Err.Description & " " & "fun_Actualizar_AJIPINUS")
        End Try

    End Function

    ''' <summary>
    ''' Consulta para llenar el DataGridView y colocar el nombre del encabezado
    ''' de la columna. 
    ''' </summary>
    Public Function fun_Consultar_AJIPINUS(ByVal inAJIUSECU As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "AJIUIDRE, "
            stConsultaSQL += "AJIUSECU, "
            stConsultaSQL += "AJIUNUDO, "
            stConsultaSQL += "AJIUFERE, "
            stConsultaSQL += "AJIUNOMB, "
            stConsultaSQL += "AJIUPRAP, "
            stConsultaSQL += "AJIUSEAP, "
            stConsultaSQL += "AJIUFERE, "
            stConsultaSQL += "AJIUTEL1, "
            stConsultaSQL += "AJIUTEL2, "
            stConsultaSQL += "AJIUCOEL, "
            stConsultaSQL += "AJIUDIPR, "
            stConsultaSQL += "AJIUDICO, "
            stConsultaSQL += "AJIUOBSE "

            stConsultaSQL += "FROM "
            stConsultaSQL += "AJIPINUS "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "AJIUSECU = '" & CInt(inAJIUSECU) & " '"

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "AJIUSECU "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl


        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Consultar_AJIPINUS")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que busca el ID del codigo buscado para ejecutar la consulta
    ''' parametrizada.
    ''' </summary>
    Public Function fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_AJIPINUS(ByVal inAJIUSECU As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "AJIUIDRE, "
            stConsultaSQL += "AJIUSECU, "
            stConsultaSQL += "AJIUNUDO, "
            stConsultaSQL += "AJIUFERE, "
            stConsultaSQL += "AJIUNOMB, "
            stConsultaSQL += "AJIUPRAP, "
            stConsultaSQL += "AJIUSEAP, "
            stConsultaSQL += "AJIUFERE, "
            stConsultaSQL += "AJIUTEL1, "
            stConsultaSQL += "AJIUTEL2, "
            stConsultaSQL += "AJIUCOEL, "
            stConsultaSQL += "AJIUDIPR, "
            stConsultaSQL += "AJIUDICO, "
            stConsultaSQL += "AJIUOBSE "

            stConsultaSQL += "FROM "
            stConsultaSQL += "AJIPINUS "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "AJIUSECU = '" & CInt(inAJIUSECU) & " '"

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "AJIUSECU "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception

            MessageBox.Show(Err.Description & " " & "fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_AJIPINUS")
            Return Nothing

        End Try

    End Function

    ''' <summary>
    ''' Función que busca el CÓDIGO para que no se 
    ''' guarden registros duplicados.
    ''' </summary>
    Public Function fun_Buscar_CODIGO_X_AJIPINUS(ByVal inAJIUSECU As Integer, ByVal stAJIUNUDO As String) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "AJIPINUS "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "AJIUSECU = '" & CInt(inAJIUSECU) & "' and "
            stConsultaSQL += "AJIUNUDO = '" & CStr(Trim(stAJIUNUDO)) & "' "

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
