Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration
Imports DATOS

Public Class cla_LIQUIDACION

    '=========================
    '*** CLASE LIQUIDACIÓN ***
    '=========================

    ''' <summary>
    ''' procedimiento que verifica la llave primaria.
    ''' </summary>
    Public Function fun_Verifica_llave_Primaria_LIQUIDACION(ByVal inLIQUSECU As Integer, ByVal obLIQUNUDO As Object) As Boolean

        Try
            Dim boRespuesta As Boolean = False

            Dim obVerifica As New cla_Verificar_Dato

            If obVerifica.fun_Verificar_Campo_Lleno(inLIQUSECU) = True And _
                obVerifica.fun_Verificar_Campo_Lleno(obLIQUNUDO.Text) = True Then

                If obVerifica.fun_Verificar_Dato_Numerico(inLIQUSECU) = True Then

                    Dim objdatos1 As New cla_LIQUIDACION
                    Dim tbl As New DataTable

                    tbl = objdatos1.fun_Buscar_CODIGO_X_LIQUIDACION(inLIQUSECU, obLIQUNUDO.Text)

                    If tbl.Rows.Count > 0 Then
                        MessageBox.Show("El dato " & Trim(inLIQUSECU) & " - " & Trim(obLIQUNUDO.Text) & " existe en la base de datos.", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                        obLIQUNUDO.Focus()
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
    Public Function fun_Insertar_LIQUIDACION(ByVal inLIQUSECU As Integer, _
                                          ByVal stLIQUNUDO As String, _
                                          ByVal stLIQUFEEN As String, _
                                          ByVal stLIQUFERE As String, _
                                          ByVal stLIQUOBSE As String) As Boolean

        Try

            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "INSERT INTO "
            stConsultaSQL += "LIQUIDACION "

            stConsultaSQL += "( "
            stConsultaSQL += "LIQUSECU, "
            stConsultaSQL += "LIQUNUDO, "
            stConsultaSQL += "LIQUFEEN, "
            stConsultaSQL += "LIQUFERE, "
            stConsultaSQL += "LIQUOBSE "
            stConsultaSQL += ") "

            stConsultaSQL += "VALUES "

            stConsultaSQL += "( "
            stConsultaSQL += "'" & CInt(inLIQUSECU) & "', "
            stConsultaSQL += "'" & CStr(Trim(stLIQUNUDO)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stLIQUFEEN)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stLIQUFERE)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stLIQUOBSE)) & "' "
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
            MessageBox.Show(Err.Description & " " & "fun_Insertar_LIQUIDACION")
        End Try

    End Function

    ''' <summary>
    ''' Función que Elimina el registro.
    ''' </summary>
    Public Function fun_Eliminar_IDRE_LIQUIDACION(ByVal inLIQUIDRE As Integer) As Boolean

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "DELETE "
            stConsultaSQL += "LIQUIDACION "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "LIQUIDRE = '" & CInt(inLIQUIDRE) & "' "

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
            MessageBox.Show(Err.Description & " " & "fun_Eliminar_IDRE_LIQUIDACION")
        End Try

    End Function

    ''' <summary>
    ''' Función que Elimina el registro.
    ''' </summary>
    Public Function fun_Eliminar_SECU_X_NUDO_LIQUIDACION(ByVal inLIQUSECU As Integer, ByVal stLIQUNUDO As String) As Boolean

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "DELETE "
            stConsultaSQL += "LIQUIDACION "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "LIQUSECU = '" & CInt(inLIQUSECU) & "' and "
            stConsultaSQL += "LIQUNUDO = '" & CStr(Trim(stLIQUNUDO)) & "' "

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
            MessageBox.Show(Err.Description & " " & "fun_Eliminar_SECU_X_MACA_LIQUIDACION")
        End Try

    End Function

    ''' <summary>
    ''' Función que Elimina el registro.
    ''' </summary>
    Public Function fun_Eliminar_SECU_LIQUIDACION(ByVal inLIQUSECU As Integer) As Boolean

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "DELETE "
            stConsultaSQL += "LIQUIDACION "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "LIQUSECU = '" & CInt(inLIQUSECU) & "' "

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
            MessageBox.Show(Err.Description & " " & "fun_Eliminar_IDRE_LIQUIDACION")
        End Try

    End Function

    ''' <summary>
    ''' Función que Modifica el registro.
    ''' </summary>
    Public Function fun_Actualizar_LIQUIDACION(ByVal inLIQUIDRE As Integer, _
                                            ByVal inLIQUSECU As Integer, _
                                            ByVal stLIQUNUDO As String, _
                                            ByVal stLIQUFEEN As String, _
                                            ByVal stLIQUFERE As String, _
                                            ByVal stLIQUOBSE As String) As Boolean

        Try

            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "UPDATE "
            stConsultaSQL += "LIQUIDACION "

            stConsultaSQL += "SET "
            stConsultaSQL += "LIQUSECU = '" & CInt(inLIQUSECU) & "', "
            stConsultaSQL += "LIQUNUDO = '" & CStr(Trim(stLIQUNUDO)) & "', "
            stConsultaSQL += "LIQUFEEN = '" & CStr(Trim(stLIQUFEEN)) & "', "
            stConsultaSQL += "LIQUFERE = '" & CStr(Trim(stLIQUFERE)) & "', "
            stConsultaSQL += "LIQUOBSE = '" & CStr(Trim(stLIQUOBSE)) & "' "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "LIQUIDRE = '" & CInt(inLIQUIDRE) & "' "

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
            MessageBox.Show(Err.Description & " " & "fun_Actualizar_LIQUIDACION")
        End Try

    End Function

    ''' <summary>
    ''' Consulta para llenar el DataGridView y colocar el nombre del encabezado
    ''' de la columna. 
    ''' </summary>
    Public Function fun_Consultar_LIQUIDACION() As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "LIQUIDRE, "
            stConsultaSQL += "LIQUSECU, "
            stConsultaSQL += "LIQUNUDO, "
            stConsultaSQL += "USUANOMB, "
            stConsultaSQL += "USUAPRAP, "
            stConsultaSQL += "USUASEAP, "
            stConsultaSQL += "LIQUFEEN, "
            stConsultaSQL += "LIQUFERE, "
            stConsultaSQL += "LIQUOBSE "

            stConsultaSQL += "FROM "
            stConsultaSQL += "LIQUIDACION, USUARIO "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "LIQUNUDO = USUANUDO "

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "LIQUFEEN "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Consultar_LIQUIDACION")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que busca el ID del codigo buscado para ejecutar la consulta
    ''' parametrizada.
    ''' </summary>
    Public Function fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_LIQUIDACION(ByVal inLIQUSECU As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "LIQUIDRE, "
            stConsultaSQL += "LIQUSECU, "
            stConsultaSQL += "LIQUNUDO, "
            stConsultaSQL += "USUANOMB, "
            stConsultaSQL += "USUAPRAP, "
            stConsultaSQL += "USUASEAP, "
            stConsultaSQL += "LIQUFEEN, "
            stConsultaSQL += "LIQUFERE, "
            stConsultaSQL += "LIQUOBSE "

            stConsultaSQL += "FROM "
            stConsultaSQL += "LIQUIDACION, USUARIO "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "LIQUNUDO = USUANUDO and "
            stConsultaSQL += "LIQUSECU = '" & CInt(inLIQUSECU) & "'"

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "LIQUFEEN "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception

            MessageBox.Show(Err.Description & " " & "fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_LIQUIDACION")
            Return Nothing

        End Try

    End Function

    ''' <summary>
    ''' Función que busca el CÓDIGO para que no se 
    ''' guarden registros duplicados.
    ''' </summary>
    Public Function fun_Buscar_CODIGO_X_LIQUIDACION(ByVal inLIQUSECU As Integer, ByVal stLIQUNUDO As String) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "LIQUIDACION "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "LIQUSECU = '" & CInt(inLIQUSECU) & "' and "
            stConsultaSQL += "LIQUNUDO = '" & CStr(Trim(stLIQUNUDO)) & "' "

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
    ''' <summary>
    ''' Función que busca el CÓDIGO para que no se 
    ''' guarden registros duplicados.
    ''' </summary>
    Public Function fun_Buscar_CODIGO_X_LIQUIDACION(ByVal inLIQUIDRE As Integer, ByVal inLIQUSECU As Integer, ByVal stLIQUNUDO As String) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "LIQUIDACION "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "LIQUIDRE = '" & CInt(inLIQUIDRE) & "' and "
            stConsultaSQL += "LIQUSECU = '" & CInt(inLIQUSECU) & "' and "
            stConsultaSQL += "LIQUNUDO = '" & CStr(Trim(stLIQUNUDO)) & "' "

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
