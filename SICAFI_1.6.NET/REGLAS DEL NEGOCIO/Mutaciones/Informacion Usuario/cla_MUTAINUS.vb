Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration
Imports DATOS

Public Class cla_MUTAINUS

    '===============================================
    '*** CLASE INFORMACIÓN DE USUARIO MUTACIONES ***
    '===============================================

    ''' <summary>
    ''' procedimiento que verifica la llave primaria.
    ''' </summary>
    Public Function fun_Verifica_llave_Primaria_MUTAINUS(ByVal obMUIUSECU As Object, ByVal obMUIUNUDO As Object) As Boolean

        Try
            Dim boRespuesta As Boolean = False

            Dim obVerifica As New cla_Verificar_Dato

            If obVerifica.fun_Verificar_Campo_Lleno(obMUIUSECU.Text) = True And _
                obVerifica.fun_Verificar_Campo_Lleno(obMUIUNUDO.Text) = True Then

                If obVerifica.fun_Verificar_Dato_Numerico(obMUIUSECU.Text) = True Then

                    Dim objdatos1 As New cla_MUTAINUS
                    Dim tbl As New DataTable

                    tbl = objdatos1.fun_Buscar_CODIGO_X_MUTAINUS(obMUIUSECU.Text, obMUIUNUDO.Text)

                    If tbl.Rows.Count > 0 Then
                        MessageBox.Show("El dato " & Trim(obMUIUSECU.Text) & " - " & Trim(obMUIUNUDO.Text) & " existe en la base de datos, se incrementara una secuencia, favor guardar.", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                        obMUIUSECU.Focus()
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
    Public Function fun_Insertar_MUTAINUS(ByVal inMUIUSECU As Integer, _
                                          ByVal stMUIUNUDO As String, _
                                          ByVal stMUIUFERE As String, _
                                          ByVal stMUIUNOMB As String, _
                                          ByVal stMUIUPRAP As String, _
                                          ByVal stMUIUSEAP As String, _
                                          ByVal stMUIUTEL1 As String, _
                                          ByVal stMUIUTEL2 As String, _
                                          ByVal stMUIUDIRE As String, _
                                          ByVal stMUIUOBSE As String) As Boolean

        Try

            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "INSERT INTO "
            stConsultaSQL += "MUTAINUS "

            stConsultaSQL += "( "
            stConsultaSQL += "MUIUSECU, "
            stConsultaSQL += "MUIUNUDO, "
            stConsultaSQL += "MUIUFERE, "
            stConsultaSQL += "MUIUNOMB, "
            stConsultaSQL += "MUIUPRAP, "
            stConsultaSQL += "MUIUSEAP, "
            stConsultaSQL += "MUIUTEL1, "
            stConsultaSQL += "MUIUTEL2, "
            stConsultaSQL += "MUIUDIRE, "
            stConsultaSQL += "MUIUOBSE "
            stConsultaSQL += ") "

            stConsultaSQL += "VALUES "

            stConsultaSQL += "( "
            stConsultaSQL += "'" & CInt(inMUIUSECU) & "', "
            stConsultaSQL += "'" & CStr(Trim(stMUIUNUDO)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stMUIUFERE)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stMUIUNOMB)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stMUIUPRAP)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stMUIUSEAP)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stMUIUTEL1)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stMUIUTEL2)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stMUIUDIRE)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stMUIUOBSE)) & "' "
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
            MessageBox.Show(Err.Description & " " & "fun_Insertar_MUTAINUS")
        End Try

    End Function

    ''' <summary>
    ''' Función que Elimina el registro.
    ''' </summary>
    Public Function fun_Eliminar_IDRE_MUTAINUS(ByVal inMUIUIDRE As Integer) As Boolean

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "DELETE "
            stConsultaSQL += "MUTAINUS "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "MUIUIDRE = '" & CInt(inMUIUIDRE) & "' "

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
            MessageBox.Show(Err.Description & " " & "fun_Eliminar_IDRE_MUTAINUS")
        End Try

    End Function

    ''' <summary>
    ''' Función que Elimina el registro.
    ''' </summary>
    Public Function fun_Eliminar_SECU_X_NUDO_MUTAINUS(ByVal inMUIUSECU As Integer, ByVal stMUIUNUDO As String) As Boolean

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "DELETE "
            stConsultaSQL += "MUTAINUS "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "MUIUSECU = '" & CInt(inMUIUSECU) & "' and "
            stConsultaSQL += "MUIUNUDO = '" & CStr(Trim(stMUIUNUDO)) & "' "

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
            MessageBox.Show(Err.Description & " " & "fun_Eliminar_SECU_X_MACA_MUTAINUS")
        End Try

    End Function

    ''' <summary>
    ''' Función que Elimina el registro.
    ''' </summary>
    Public Function fun_Eliminar_SECU_MUTAINUS(ByVal inMUIUSECU As Integer) As Boolean

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "DELETE "
            stConsultaSQL += "MUTAINUS "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "MUIUSECU = '" & CInt(inMUIUSECU) & "' "

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
            MessageBox.Show(Err.Description & " " & "fun_Eliminar_IDRE_MUTAINUS")
        End Try

    End Function

    ''' <summary>
    ''' Función que Modifica el registro.
    ''' </summary>
    Public Function fun_Actualizar_IDRE_X_MUTAINUS(ByVal stMUIUIDRE As Integer, _
                                            ByVal inMUIUSECU As Integer, _
                                            ByVal stMUIUNUDO As String, _
                                            ByVal stMUIUFERE As String, _
                                            ByVal stMUIUNOMB As String, _
                                            ByVal stMUIUPRAP As String, _
                                            ByVal stMUIUSEAP As String, _
                                            ByVal stMUIUTEL1 As String, _
                                            ByVal stMUIUTEL2 As String, _
                                            ByVal stMUIUDIRE As String, _
                                            ByVal stMUIUOBSE As String) As Boolean

        Try

            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "UPDATE "
            stConsultaSQL += "MUTAINUS "

            stConsultaSQL += "SET "
            stConsultaSQL += "MUIUSECU = '" & CInt(inMUIUSECU) & "', "
            stConsultaSQL += "MUIUNUDO = '" & CStr(Trim(stMUIUNUDO)) & "', "
            stConsultaSQL += "MUIUFERE = '" & CStr(Trim(stMUIUFERE)) & "', "
            stConsultaSQL += "MUIUNOMB = '" & CStr(Trim(stMUIUNOMB)) & "', "
            stConsultaSQL += "MUIUPRAP = '" & CStr(Trim(stMUIUPRAP)) & "', "
            stConsultaSQL += "MUIUSEAP = '" & CStr(Trim(stMUIUSEAP)) & "', "
            stConsultaSQL += "MUIUFERE = '" & CStr(Trim(stMUIUFERE)) & "', "
            stConsultaSQL += "MUIUTEL1 = '" & CStr(Trim(stMUIUTEL1)) & "', "
            stConsultaSQL += "MUIUTEL2 = '" & CStr(Trim(stMUIUTEL2)) & "', "
            stConsultaSQL += "MUIUDIRE = '" & CStr(Trim(stMUIUDIRE)) & "', "
            stConsultaSQL += "MUIUOBSE = '" & CStr(Trim(stMUIUOBSE)) & "' "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "MUIUIDRE = '" & CInt(stMUIUIDRE) & "' "

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
            MessageBox.Show(Err.Description & " " & "fun_Actualizar_MUTAINUS")
        End Try

    End Function

    ''' <summary>
    ''' Función que Modifica el registro.
    ''' </summary>
    Public Function fun_Actualizar_SECU_X_MUTAINUS(ByVal inMUIUSECU As Integer, _
                                                   ByVal stMUIUNUDO As String, _
                                                   ByVal stMUIUFERE As String, _
                                                   ByVal stMUIUNOMB As String, _
                                                   ByVal stMUIUPRAP As String, _
                                                   ByVal stMUIUSEAP As String, _
                                                   ByVal stMUIUTEL1 As String, _
                                                   ByVal stMUIUTEL2 As String, _
                                                   ByVal stMUIUDIRE As String, _
                                                   ByVal stMUIUOBSE As String) As Boolean

        Try

            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "UPDATE "
            stConsultaSQL += "MUTAINUS "

            stConsultaSQL += "SET "
            stConsultaSQL += "MUIUSECU = '" & CInt(inMUIUSECU) & "', "
            stConsultaSQL += "MUIUNUDO = '" & CStr(Trim(stMUIUNUDO)) & "', "
            stConsultaSQL += "MUIUFERE = '" & CStr(Trim(stMUIUFERE)) & "', "
            stConsultaSQL += "MUIUNOMB = '" & CStr(Trim(stMUIUNOMB)) & "', "
            stConsultaSQL += "MUIUPRAP = '" & CStr(Trim(stMUIUPRAP)) & "', "
            stConsultaSQL += "MUIUSEAP = '" & CStr(Trim(stMUIUSEAP)) & "', "
            stConsultaSQL += "MUIUTEL1 = '" & CStr(Trim(stMUIUTEL1)) & "', "
            stConsultaSQL += "MUIUTEL2 = '" & CStr(Trim(stMUIUTEL2)) & "', "
            stConsultaSQL += "MUIUDIRE = '" & CStr(Trim(stMUIUDIRE)) & "', "
            stConsultaSQL += "MUIUOBSE = '" & CStr(Trim(stMUIUOBSE)) & "' "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "MUIUSECU = '" & CInt(inMUIUSECU) & "' "

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
            MessageBox.Show(Err.Description & " " & "fun_Actualizar_MUTAINUS")
        End Try

    End Function

    ''' <summary>
    ''' Consulta para llenar el DataGridView y colocar el nombre del encabezado
    ''' de la columna. 
    ''' </summary>
    Public Function fun_Consultar_MUTAINUS(ByVal inMUIUSECU As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "MUIUIDRE, "
            stConsultaSQL += "MUIUSECU, "
            stConsultaSQL += "MUIUNUDO, "
            stConsultaSQL += "MUIUFERE, "
            stConsultaSQL += "MUIUNOMB, "
            stConsultaSQL += "MUIUPRAP, "
            stConsultaSQL += "MUIUSEAP, "
            stConsultaSQL += "MUIUFERE, "
            stConsultaSQL += "MUIUTEL1, "
            stConsultaSQL += "MUIUTEL2, "
            stConsultaSQL += "MUIUDIRE, "
            stConsultaSQL += "MUIUOBSE "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MUTAINUS "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "MUIUSECU = '" & CInt(inMUIUSECU) & " '"

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "MUIUSECU "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl


        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Consultar_MUTAINUS")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que busca el ID del codigo buscado para ejecutar la consulta
    ''' parametrizada.
    ''' </summary>
    Public Function fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_MUTAINUS(ByVal inMUIUSECU As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "MUIUIDRE, "
            stConsultaSQL += "MUIUSECU, "
            stConsultaSQL += "MUIUNUDO, "
            stConsultaSQL += "MUIUFERE, "
            stConsultaSQL += "MUIUNOMB, "
            stConsultaSQL += "MUIUPRAP, "
            stConsultaSQL += "MUIUSEAP, "
            stConsultaSQL += "MUIUFERE, "
            stConsultaSQL += "MUIUTEL1, "
            stConsultaSQL += "MUIUTEL2, "
            stConsultaSQL += "MUIUDIRE, "
            stConsultaSQL += "MUIUOBSE "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MUTAINUS "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "MUIUSECU = '" & CInt(inMUIUSECU) & " '"

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "MUIUSECU "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception

            MessageBox.Show(Err.Description & " " & "fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_MUTAINUS")
            Return Nothing

        End Try

    End Function

    ''' <summary>
    ''' Función que busca el CÓDIGO para que no se 
    ''' guarden registros duplicados.
    ''' </summary>
    Public Function fun_Buscar_CODIGO_X_MUTAINUS(ByVal inMUIUSECU As Integer, ByVal stMUIUNUDO As String) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MUTAINUS "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "MUIUSECU = '" & CInt(inMUIUSECU) & "' and "
            stConsultaSQL += "MUIUNUDO = '" & CStr(Trim(stMUIUNUDO)) & "' "

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
