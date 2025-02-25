Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration
Imports DATOS

Public Class cla_MOALDIGI

    '======================================================
    '*** CLASE DIGITALIZACION MOVIMIENTOS ALFANUMERICOS ***
    '======================================================

    ''' <summary>
    ''' procedimiento que verifica la llave primaria.
    ''' </summary>
    Public Function fun_Verifica_llave_Primaria_MOALDIGI(ByVal inMADISECU As Integer, ByVal obMADINUDO As Object, ByVal obMADIFEEN As Object) As Boolean

        Try
            Dim boRespuesta As Boolean = False

            Dim obVerifica As New cla_Verificar_Dato

            If obVerifica.fun_Verificar_Campo_Lleno(inMADISECU) = True And _
                obVerifica.fun_Verificar_Campo_Lleno(obMADINUDO.Text) = True And _
                obVerifica.fun_Verificar_Campo_Lleno(obMADIFEEN.Text) = True Then

                If obVerifica.fun_Verificar_Dato_Numerico(inMADISECU) = True Then

                    Dim objdatos1 As New cla_MOALDIGI
                    Dim tbl As New DataTable

                    tbl = objdatos1.fun_Buscar_CODIGO_X_MOALDIGI(inMADISECU, obMADINUDO.Text, obMADIFEEN.Text)

                    If tbl.Rows.Count > 0 Then
                        MessageBox.Show("El dato " & Trim(inMADISECU) & " - " & Trim(obMADINUDO.Text) & " - " & Trim(obMADIFEEN.Text) & " existe en la base de datos.", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                        obMADINUDO.Focus()
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
    Public Function fun_Insertar_MOALDIGI(ByVal inMADISECU As Integer, _
                                          ByVal stMADINUDO As String, _
                                          ByVal stMADIFEEN As String, _
                                          ByVal stMADIFEFI As String, _
                                          ByVal stMADIOBSE As String) As Boolean

        Try

            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "INSERT INTO "
            stConsultaSQL += "MOALDIGI "

            stConsultaSQL += "( "
            stConsultaSQL += "MADISECU, "
            stConsultaSQL += "MADINUDO, "
            stConsultaSQL += "MADIFEEN, "
            stConsultaSQL += "MADIFEFI, "
            stConsultaSQL += "MADIOBSE "
            stConsultaSQL += ") "

            stConsultaSQL += "VALUES "

            stConsultaSQL += "( "
            stConsultaSQL += "'" & CInt(inMADISECU) & "', "
            stConsultaSQL += "'" & CStr(Trim(stMADINUDO)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stMADIFEEN)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stMADIFEFI)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stMADIOBSE)) & "' "
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
            MessageBox.Show(Err.Description & " " & "fun_Insertar_MOALDIGI")
        End Try

    End Function

    ''' <summary>
    ''' Función que Elimina el registro.
    ''' </summary>
    Public Function fun_Eliminar_IDRE_MOALDIGI(ByVal inMADIIDRE As Integer) As Boolean

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "DELETE "
            stConsultaSQL += "MOALDIGI "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "MADIIDRE = '" & CInt(inMADIIDRE) & "' "

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
            MessageBox.Show(Err.Description & " " & "fun_Eliminar_IDRE_MOALDIGI")
        End Try

    End Function

    ''' <summary>
    ''' Función que Elimina el registro.
    ''' </summary>
    Public Function fun_Eliminar_SECU_X_NUDO_MOALDIGI(ByVal inMADISECU As Integer, ByVal stMADINUDO As String) As Boolean

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "DELETE "
            stConsultaSQL += "MOALDIGI "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "MADISECU = '" & CInt(inMADISECU) & "' and "
            stConsultaSQL += "MADINUDO = '" & CStr(Trim(stMADINUDO)) & "' "

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
            MessageBox.Show(Err.Description & " " & "fun_Eliminar_SECU_X_MACA_MOALDIGI")
        End Try

    End Function

    ''' <summary>
    ''' Función que Elimina el registro.
    ''' </summary>
    Public Function fun_Eliminar_SECU_MOALDIGI(ByVal inMADISECU As Integer) As Boolean

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "DELETE "
            stConsultaSQL += "MOALDIGI "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "MADISECU = '" & CInt(inMADISECU) & "' "

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
            MessageBox.Show(Err.Description & " " & "fun_Eliminar_IDRE_MOALDIGI")
        End Try

    End Function

    ''' <summary>
    ''' Función que Modifica el registro.
    ''' </summary>
    Public Function fun_Actualizar_MOALDIGI(ByVal inMADIIDRE As Integer, _
                                            ByVal inMADISECU As Integer, _
                                            ByVal stMADINUDO As String, _
                                            ByVal stMADIFEEN As String, _
                                            ByVal stMADIFEFI As String, _
                                            ByVal stMADIOBSE As String) As Boolean

        Try

            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "UPDATE "
            stConsultaSQL += "MOALDIGI "

            stConsultaSQL += "SET "
            stConsultaSQL += "MADISECU = '" & CInt(inMADISECU) & "', "
            stConsultaSQL += "MADINUDO = '" & CStr(Trim(stMADINUDO)) & "', "
            stConsultaSQL += "MADIFEEN = '" & CStr(Trim(stMADIFEEN)) & "', "
            stConsultaSQL += "MADIFEFI = '" & CStr(Trim(stMADIFEFI)) & "', "
            stConsultaSQL += "MADIOBSE = '" & CStr(Trim(stMADIOBSE)) & "' "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "MADIIDRE = '" & CInt(inMADIIDRE) & "' "

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
            MessageBox.Show(Err.Description & " " & "fun_Actualizar_MOALDIGI")
        End Try

    End Function

    ''' <summary>
    ''' Consulta para llenar el DataGridView y colocar el nombre del encabezado
    ''' de la columna. 
    ''' </summary>
    Public Function fun_Consultar_MOALDIGI() As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "MADIIDRE, "
            stConsultaSQL += "MADISECU, "
            stConsultaSQL += "MADINUDO, "
            stConsultaSQL += "USUANOMB, "
            stConsultaSQL += "USUAPRAP, "
            stConsultaSQL += "USUASEAP, "
            stConsultaSQL += "MADIFEEN, "
            stConsultaSQL += "MADIFEFI, "
            stConsultaSQL += "MADIOBSE "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MOALDIGI, USUARIO "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "MADINUDO = USUANUDO "

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "MADIFEEN "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Consultar_MOALDIGI")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que busca el ID del codigo buscado para ejecutar la consulta
    ''' parametrizada.
    ''' </summary>
    Public Function fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_MOALDIGI(ByVal inMADISECU As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "MADIIDRE, "
            stConsultaSQL += "MADISECU, "
            stConsultaSQL += "MADINUDO, "
            stConsultaSQL += "USUANOMB, "
            stConsultaSQL += "USUAPRAP, "
            stConsultaSQL += "USUASEAP, "
            stConsultaSQL += "MADIFEEN, "
            stConsultaSQL += "MADIFEFI, "
            stConsultaSQL += "MADIOBSE "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MOALDIGI, USUARIO "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "MADINUDO = USUANUDO and "
            stConsultaSQL += "MADISECU = '" & CInt(inMADISECU) & "'"

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "MADIFEEN "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception

            MessageBox.Show(Err.Description & " " & "fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_MOALDIGI")
            Return Nothing

        End Try

    End Function

    ''' <summary>
    ''' Función que busca el CÓDIGO para que no se 
    ''' guarden registros duplicados.
    ''' </summary>
    Public Function fun_Buscar_CODIGO_X_MOALDIGI(ByVal inMADISECU As Integer, ByVal stMADINUDO As String, ByVal stMADIFEEN As String) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MOALDIGI "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "MADISECU = '" & CInt(inMADISECU) & "' and "
            stConsultaSQL += "MADINUDO = '" & CStr(Trim(stMADINUDO)) & "' and "
            stConsultaSQL += "MADIFEEN = '" & CStr(Trim(stMADIFEEN)) & "' "

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
    Public Function fun_Buscar_CODIGO_X_MOALDIGI(ByVal inMADISECU As Integer, ByVal stMADINUDO As String) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MOALDIGI "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "MADISECU = '" & CInt(inMADISECU) & "' and "
            stConsultaSQL += "MADINUDO = '" & CStr(Trim(stMADINUDO)) & "' "

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
