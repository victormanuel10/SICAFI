Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration
Imports DATOS

Public Class cla_MUTADEPA

    '==============================================
    '*** CLASE MUTACION DEPARTAMENTO MUTACIONES ***
    '==============================================

    ''' <summary>
    ''' procedimiento que verifica la llave primaria.
    ''' </summary>
    Public Function fun_Verifica_llave_Primaria_MUTADEPA(ByVal inMUDESECU As Integer, ByVal obMUDENUDO As Object, ByVal obMUDEFEEN As Object) As Boolean

        Try
            Dim boRespuesta As Boolean = False

            Dim obVerifica As New cla_Verificar_Dato

            If obVerifica.fun_Verificar_Campo_Lleno(inMUDESECU) = True And _
                obVerifica.fun_Verificar_Campo_Lleno(obMUDENUDO.Text) = True And _
                obVerifica.fun_Verificar_Campo_Lleno(obMUDEFEEN.Text) = True Then

                If obVerifica.fun_Verificar_Dato_Numerico(inMUDESECU) = True Then

                    Dim objdatos1 As New cla_MUTADEPA
                    Dim tbl As New DataTable

                    tbl = objdatos1.fun_Buscar_CODIGO_X_MUTADEPA(inMUDESECU, obMUDENUDO.Text, obMUDEFEEN.Text)

                    If tbl.Rows.Count > 0 Then
                        MessageBox.Show("El dato " & Trim(inMUDESECU) & " - " & Trim(obMUDENUDO.Text) & " - " & Trim(obMUDEFEEN.Text) & " existe en la base de datos.", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                        obMUDENUDO.Focus()
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
    Public Function fun_Insertar_MUTADEPA(ByVal inMUDESECU As Integer, _
                                          ByVal stMUDENUDO As String, _
                                          ByVal stMUDEFEEN As String, _
                                          ByVal stMUDEOBSE As String) As Boolean

        Try

            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "INSERT INTO "
            stConsultaSQL += "MUTADEPA "

            stConsultaSQL += "( "
            stConsultaSQL += "MUDESECU, "
            stConsultaSQL += "MUDENUDO, "
            stConsultaSQL += "MUDEFEEN, "
            stConsultaSQL += "MUDEOBSE "
            stConsultaSQL += ") "

            stConsultaSQL += "VALUES "

            stConsultaSQL += "( "
            stConsultaSQL += "'" & CInt(inMUDESECU) & "', "
            stConsultaSQL += "'" & CStr(Trim(stMUDENUDO)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stMUDEFEEN)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stMUDEOBSE)) & "' "
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
            MessageBox.Show(Err.Description & " " & "fun_Insertar_MUTADEPA")
        End Try

    End Function

    ''' <summary>
    ''' Función que Elimina el registro.
    ''' </summary>
    Public Function fun_Eliminar_IDRE_MUTADEPA(ByVal inMUDEIDRE As Integer) As Boolean

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "DELETE "
            stConsultaSQL += "MUTADEPA "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "MUDEIDRE = '" & CInt(inMUDEIDRE) & "' "

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
            MessageBox.Show(Err.Description & " " & "fun_Eliminar_IDRE_MUTADEPA")
        End Try

    End Function

    ''' <summary>
    ''' Función que Elimina el registro.
    ''' </summary>
    Public Function fun_Eliminar_SECU_X_NUDO_MUTADEPA(ByVal inMUDESECU As Integer, ByVal stMUDENUDO As String) As Boolean

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "DELETE "
            stConsultaSQL += "MUTADEPA "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "MUDESECU = '" & CInt(inMUDESECU) & "' and "
            stConsultaSQL += "MUDENUDO = '" & CStr(Trim(stMUDENUDO)) & "' "

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
            MessageBox.Show(Err.Description & " " & "fun_Eliminar_SECU_X_MACA_MUTADEPA")
        End Try

    End Function

    ''' <summary>
    ''' Función que Elimina el registro.
    ''' </summary>
    Public Function fun_Eliminar_SECU_MUTADEPA(ByVal inMUDESECU As Integer) As Boolean

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "DELETE "
            stConsultaSQL += "MUTADEPA "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "MUDESECU = '" & CInt(inMUDESECU) & "' "

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
            MessageBox.Show(Err.Description & " " & "fun_Eliminar_IDRE_MUTADEPA")
        End Try

    End Function

    ''' <summary>
    ''' Función que Modifica el registro.
    ''' </summary>
    Public Function fun_Actualizar_MUTADEPA(ByVal inMUDEIDRE As Integer, _
                                            ByVal inMUDESECU As Integer, _
                                            ByVal stMUDENUDO As String, _
                                            ByVal stMUDEFEEN As String, _
                                            ByVal stMUDEOBSE As String) As Boolean

        Try

            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "UPDATE "
            stConsultaSQL += "MUTADEPA "

            stConsultaSQL += "SET "
            stConsultaSQL += "MUDESECU = '" & CInt(inMUDESECU) & "', "
            stConsultaSQL += "MUDENUDO = '" & CStr(Trim(stMUDENUDO)) & "', "
            stConsultaSQL += "MUDEFEEN = '" & CStr(Trim(stMUDEFEEN)) & "', "
            stConsultaSQL += "MUDEOBSE = '" & CStr(Trim(stMUDEOBSE)) & "' "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "MUDEIDRE = '" & CInt(inMUDEIDRE) & "' "

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
            MessageBox.Show(Err.Description & " " & "fun_Actualizar_MUTADEPA")
        End Try

    End Function


    ''' <summary>
    ''' Consulta para llenar el DataGridView y colocar el nombre del encabezado
    ''' de la columna. 
    ''' </summary>
    Public Function fun_Consultar_MUTADEPA() As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "MUDEIDRE, "
            stConsultaSQL += "MUDESECU, "
            stConsultaSQL += "MUDENUDO, "
            stConsultaSQL += "USUANOMB, "
            stConsultaSQL += "USUAPRAP, "
            stConsultaSQL += "USUASEAP, "
            stConsultaSQL += "MUDEFEEN, "
            stConsultaSQL += "MUDEOBSE "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MUTADEPA, USUARIO "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "MUDENUDO = USUANUDO "

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "MUDEFEEN "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Consultar_MUTADEPA")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que busca el ID del codigo buscado para ejecutar la consulta
    ''' parametrizada.
    ''' </summary>
    Public Function fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_MUTADEPA(ByVal inMUDESECU As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "MUDEIDRE, "
            stConsultaSQL += "MUDESECU, "
            stConsultaSQL += "MUDENUDO, "
            stConsultaSQL += "USUANOMB, "
            stConsultaSQL += "USUAPRAP, "
            stConsultaSQL += "USUASEAP, "
            stConsultaSQL += "MUDEFEEN, "
            stConsultaSQL += "MUDEOBSE "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MUTADEPA, USUARIO "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "MUDENUDO = USUANUDO and "
            stConsultaSQL += "MUDESECU = '" & CInt(inMUDESECU) & "'"

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "MUDEFEEN "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception

            MessageBox.Show(Err.Description & " " & "fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_MUTADEPA")
            Return Nothing

        End Try

    End Function

    ''' <summary>
    ''' Función que busca el CÓDIGO para que no se 
    ''' guarden registros duplicados.
    ''' </summary>
    Public Function fun_Buscar_CODIGO_X_MUTADEPA(ByVal inMUDESECU As Integer, ByVal stMUDENUDO As String, ByVal stMUDEFEEN As String) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MUTADEPA "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "MUDESECU = '" & CInt(inMUDESECU) & "' and "
            stConsultaSQL += "MUDENUDO = '" & CStr(Trim(stMUDENUDO)) & "' and "
            stConsultaSQL += "MUDEFEEN = '" & CStr(Trim(stMUDEFEEN)) & "' "

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
    Public Function fun_Buscar_CODIGO_X_MUTADEPA(ByVal inMUDESECU As Integer, ByVal stMUDENUDO As String) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MUTADEPA "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "MUDESECU = '" & CInt(inMUDESECU) & "' and "
            stConsultaSQL += "MUDENUDO = '" & CStr(Trim(stMUDENUDO)) & "' "

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
