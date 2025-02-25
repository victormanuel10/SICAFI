Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration
Imports DATOS

Public Class cla_MUTAMUNI

    '===========================================
    '*** CLASE MUTACION MUNICIPIO MUTACIONES ***
    '===========================================

    ''' <summary>
    ''' procedimiento que verifica la llave primaria.
    ''' </summary>
    Public Function fun_Verifica_llave_Primaria_MUTAMUNI(ByVal inMUMUSECU As Integer, ByVal obMUMUNUDO As Object, ByVal obMUMUFEEN As Object) As Boolean

        Try
            Dim boRespuesta As Boolean = False

            Dim obVerifica As New cla_Verificar_Dato

            If obVerifica.fun_Verificar_Campo_Lleno(inMUMUSECU) = True And _
                obVerifica.fun_Verificar_Campo_Lleno(obMUMUNUDO.Text) = True And _
                obVerifica.fun_Verificar_Campo_Lleno(obMUMUFEEN.Text) = True Then

                If obVerifica.fun_Verificar_Dato_Numerico(inMUMUSECU) = True Then

                    Dim objdatos1 As New cla_MUTAMUNI
                    Dim tbl As New DataTable

                    tbl = objdatos1.fun_Buscar_CODIGO_X_MUTAMUNI(inMUMUSECU, obMUMUNUDO.Text, obMUMUFEEN.Text)

                    If tbl.Rows.Count > 0 Then
                        MessageBox.Show("El dato " & Trim(inMUMUSECU) & " - " & Trim(obMUMUNUDO.Text) & " - " & Trim(obMUMUFEEN.Text) & " existe en la base de datos.", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                        obMUMUNUDO.Focus()
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
    Public Function fun_Insertar_MUTAMUNI(ByVal inMUMUSECU As Integer, _
                                          ByVal stMUMUNUDO As String, _
                                          ByVal stMUMUFEEN As String, _
                                          ByVal stMUMUOBSE As String) As Boolean

        Try

            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "INSERT INTO "
            stConsultaSQL += "MUTAMUNI "

            stConsultaSQL += "( "
            stConsultaSQL += "MUMUSECU, "
            stConsultaSQL += "MUMUNUDO, "
            stConsultaSQL += "MUMUFEEN, "
            stConsultaSQL += "MUMUOBSE "
            stConsultaSQL += ") "

            stConsultaSQL += "VALUES "

            stConsultaSQL += "( "
            stConsultaSQL += "'" & CInt(inMUMUSECU) & "', "
            stConsultaSQL += "'" & CStr(Trim(stMUMUNUDO)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stMUMUFEEN)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stMUMUOBSE)) & "' "
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
            MessageBox.Show(Err.Description & " " & "fun_Insertar_MUTAMUNI")
        End Try

    End Function

    ''' <summary>
    ''' Función que Elimina el registro.
    ''' </summary>
    Public Function fun_Eliminar_IDRE_MUTAMUNI(ByVal inMUMUIDRE As Integer) As Boolean

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "DELETE "
            stConsultaSQL += "MUTAMUNI "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "MUMUIDRE = '" & CInt(inMUMUIDRE) & "' "

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
            MessageBox.Show(Err.Description & " " & "fun_Eliminar_IDRE_MUTAMUNI")
        End Try

    End Function

    ''' <summary>
    ''' Función que Elimina el registro.
    ''' </summary>
    Public Function fun_Eliminar_SECU_X_NUDO_MUTAMUNI(ByVal inMUMUSECU As Integer, ByVal stMUMUNUDO As String) As Boolean

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "DELETE "
            stConsultaSQL += "MUTAMUNI "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "MUMUSECU = '" & CInt(inMUMUSECU) & "' and "
            stConsultaSQL += "MUMUNUDO = '" & CStr(Trim(stMUMUNUDO)) & "' "

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
            MessageBox.Show(Err.Description & " " & "fun_Eliminar_SECU_X_MACA_MUTAMUNI")
        End Try

    End Function

    ''' <summary>
    ''' Función que Elimina el registro.
    ''' </summary>
    Public Function fun_Eliminar_SECU_MUTAMUNI(ByVal inMUMUSECU As Integer) As Boolean

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "DELETE "
            stConsultaSQL += "MUTAMUNI "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "MUMUSECU = '" & CInt(inMUMUSECU) & "' "

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
            MessageBox.Show(Err.Description & " " & "fun_Eliminar_IDRE_MUTAMUNI")
        End Try

    End Function

    ''' <summary>
    ''' Función que Modifica el registro.
    ''' </summary>
    Public Function fun_Actualizar_MUTAMUNI(ByVal inMUMUIDRE As Integer, _
                                            ByVal inMUMUSECU As Integer, _
                                            ByVal stMUMUNUDO As String, _
                                            ByVal stMUMUFEEN As String, _
                                            ByVal stMUMUOBSE As String) As Boolean

        Try

            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "UPDATE "
            stConsultaSQL += "MUTAMUNI "

            stConsultaSQL += "SET "
            stConsultaSQL += "MUMUSECU = '" & CInt(inMUMUSECU) & "', "
            stConsultaSQL += "MUMUNUDO = '" & CStr(Trim(stMUMUNUDO)) & "', "
            stConsultaSQL += "MUMUFEEN = '" & CStr(Trim(stMUMUFEEN)) & "', "
            stConsultaSQL += "MUMUOBSE = '" & CStr(Trim(stMUMUOBSE)) & "' "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "MUMUIDRE = '" & CInt(inMUMUIDRE) & "' "

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
            MessageBox.Show(Err.Description & " " & "fun_Actualizar_MUTAMUNI")
        End Try

    End Function

    ''' <summary>
    ''' Consulta para llenar el DataGridView y colocar el nombre del encabezado
    ''' de la columna. 
    ''' </summary>
    Public Function fun_Consultar_MUTAMUNI() As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "MUMUIDRE, "
            stConsultaSQL += "MUMUSECU, "
            stConsultaSQL += "MUMUNUDO, "
            stConsultaSQL += "USUANOMB, "
            stConsultaSQL += "USUAPRAP, "
            stConsultaSQL += "USUASEAP, "
            stConsultaSQL += "MUMUFEEN, "
            stConsultaSQL += "MUMUOBSE "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MUTAMUNI, USUARIO "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "MUMUNUDO = USUANUDO "

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "MUMUFEEN "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Consultar_MUTAMUNI")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que busca el ID del codigo buscado para ejecutar la consulta
    ''' parametrizada.
    ''' </summary>
    Public Function fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_MUTAMUNI(ByVal inMUMUSECU As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "MUMUIDRE, "
            stConsultaSQL += "MUMUSECU, "
            stConsultaSQL += "MUMUNUDO, "
            stConsultaSQL += "USUANOMB, "
            stConsultaSQL += "USUAPRAP, "
            stConsultaSQL += "USUASEAP, "
            stConsultaSQL += "MUMUFEEN, "
            stConsultaSQL += "MUMUOBSE "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MUTAMUNI, USUARIO "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "MUMUNUDO = USUANUDO and "
            stConsultaSQL += "MUMUSECU = '" & CInt(inMUMUSECU) & "'"

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "MUMUFEEN "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception

            MessageBox.Show(Err.Description & " " & "fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_MUTAMUNI")
            Return Nothing

        End Try

    End Function

    ''' <summary>
    ''' Función que busca el CÓDIGO para que no se 
    ''' guarden registros duplicados.
    ''' </summary>
    Public Function fun_Buscar_CODIGO_X_MUTAMUNI(ByVal inMUMUSECU As Integer, ByVal stMUMUNUDO As String, ByVal stMUMUFEEN As String) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MUTAMUNI "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "MUMUSECU = '" & CInt(inMUMUSECU) & "' and "
            stConsultaSQL += "MUMUNUDO = '" & CStr(Trim(stMUMUNUDO)) & "' and "
            stConsultaSQL += "MUMUFEEN = '" & CStr(Trim(stMUMUFEEN)) & "' "

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
    Public Function fun_Buscar_CODIGO_X_MUTAMUNI(ByVal inMUMUSECU As Integer, ByVal stMUMUNUDO As String) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MUTAMUNI "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "MUMUSECU = '" & CInt(inMUMUSECU) & "' and "
            stConsultaSQL += "MUMUNUDO = '" & CStr(Trim(stMUMUNUDO)) & "' "

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
