Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration
Imports DATOS

Public Class cla_MOGEDIGI

    '================================================
    '*** CLASE DIGITACION MOVIMIENTOS GEOGRAFICOS ***
    '================================================

    ''' <summary>
    ''' procedimiento que verifica la llave primaria.
    ''' </summary>
    Public Function fun_Verifica_llave_Primaria_MOGEDIGI(ByVal inMGDISECU As Integer, ByVal obMGDINUDO As Object, ByVal obMGDIFEEN As Object) As Boolean

        Try
            Dim boRespuesta As Boolean = False

            Dim obVerifica As New cla_Verificar_Dato

            If obVerifica.fun_Verificar_Campo_Lleno(inMGDISECU) = True And _
                obVerifica.fun_Verificar_Campo_Lleno(obMGDINUDO.Text) = True And _
                obVerifica.fun_Verificar_Campo_Lleno(obMGDIFEEN.Text) = True Then

                If obVerifica.fun_Verificar_Dato_Numerico(inMGDISECU) = True Then

                    Dim objdatos1 As New cla_MOGEDIGI
                    Dim tbl As New DataTable

                    tbl = objdatos1.fun_Buscar_CODIGO_X_MOGEDIGI(inMGDISECU, obMGDINUDO.Text, obMGDIFEEN.Text)

                    If tbl.Rows.Count > 0 Then
                        MessageBox.Show("El dato " & Trim(inMGDISECU) & " - " & Trim(obMGDINUDO.Text) & " - " & Trim(obMGDIFEEN.Text) & " existe en la base de datos.", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                        obMGDINUDO.Focus()
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
    Public Function fun_Insertar_MOGEDIGI(ByVal inMGDISECU As Integer, _
                                          ByVal stMGDINUDO As String, _
                                          ByVal stMGDIFEEN As String, _
                                          ByVal stMGDIFEFI As String, _
                                          ByVal stMGDIOBSE As String) As Boolean

        Try

            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "INSERT INTO "
            stConsultaSQL += "MOGEDIGI "

            stConsultaSQL += "( "
            stConsultaSQL += "MGDISECU, "
            stConsultaSQL += "MGDINUDO, "
            stConsultaSQL += "MGDIFEEN, "
            stConsultaSQL += "MGDIFEFI, "
            stConsultaSQL += "MGDIOBSE "
            stConsultaSQL += ") "

            stConsultaSQL += "VALUES "

            stConsultaSQL += "( "
            stConsultaSQL += "'" & CInt(inMGDISECU) & "', "
            stConsultaSQL += "'" & CStr(Trim(stMGDINUDO)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stMGDIFEEN)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stMGDIFEFI)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stMGDIOBSE)) & "' "
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
            MessageBox.Show(Err.Description & " " & "fun_Insertar_MOGEDIGI")
        End Try

    End Function

    ''' <summary>
    ''' Función que Elimina el registro.
    ''' </summary>
    Public Function fun_Eliminar_IDRE_MOGEDIGI(ByVal inMGDIIDRE As Integer) As Boolean

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "DELETE "
            stConsultaSQL += "MOGEDIGI "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "MGDIIDRE = '" & CInt(inMGDIIDRE) & "' "

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
            MessageBox.Show(Err.Description & " " & "fun_Eliminar_IDRE_MOGEDIGI")
        End Try

    End Function

    ''' <summary>
    ''' Función que Elimina el registro.
    ''' </summary>
    Public Function fun_Eliminar_SECU_X_NUDO_MOGEDIGI(ByVal inMGDISECU As Integer, ByVal stMGDINUDO As String) As Boolean

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "DELETE "
            stConsultaSQL += "MOGEDIGI "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "MGDISECU = '" & CInt(inMGDISECU) & "' and "
            stConsultaSQL += "MGDINUDO = '" & CStr(Trim(stMGDINUDO)) & "' "

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
            MessageBox.Show(Err.Description & " " & "fun_Eliminar_SECU_X_MACA_MOGEDIGI")
        End Try

    End Function

    ''' <summary>
    ''' Función que Elimina el registro.
    ''' </summary>
    Public Function fun_Eliminar_SECU_MOGEDIGI(ByVal inMGDISECU As Integer) As Boolean

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "DELETE "
            stConsultaSQL += "MOGEDIGI "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "MGDISECU = '" & CInt(inMGDISECU) & "' "

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
            MessageBox.Show(Err.Description & " " & "fun_Eliminar_IDRE_MOGEDIGI")
        End Try

    End Function

    ''' <summary>
    ''' Función que Modifica el registro.
    ''' </summary>
    Public Function fun_Actualizar_MOGEDIGI(ByVal inMGDIIDRE As Integer, _
                                            ByVal inMGDISECU As Integer, _
                                            ByVal stMGDINUDO As String, _
                                            ByVal stMGDIFEEN As String, _
                                            ByVal stMGDIFEFI As String, _
                                            ByVal stMGDIOBSE As String) As Boolean

        Try

            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "UPDATE "
            stConsultaSQL += "MOGEDIGI "

            stConsultaSQL += "SET "
            stConsultaSQL += "MGDISECU = '" & CInt(inMGDISECU) & "', "
            stConsultaSQL += "MGDINUDO = '" & CStr(Trim(stMGDINUDO)) & "', "
            stConsultaSQL += "MGDIFEEN = '" & CStr(Trim(stMGDIFEEN)) & "', "
            stConsultaSQL += "MGDIFEFI = '" & CStr(Trim(stMGDIFEFI)) & "', "
            stConsultaSQL += "MGDIOBSE = '" & CStr(Trim(stMGDIOBSE)) & "' "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "MGDIIDRE = '" & CInt(inMGDIIDRE) & "' "

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
            MessageBox.Show(Err.Description & " " & "fun_Actualizar_MOGEDIGI")
        End Try

    End Function

    ''' <summary>
    ''' Consulta para llenar el DataGridView y colocar el nombre del encabezado
    ''' de la columna. 
    ''' </summary>
    Public Function fun_Consultar_MOGEDIGI() As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "MGDIIDRE, "
            stConsultaSQL += "MGDISECU, "
            stConsultaSQL += "MGDINUDO, "
            stConsultaSQL += "USUANOMB, "
            stConsultaSQL += "USUAPRAP, "
            stConsultaSQL += "USUASEAP, "
            stConsultaSQL += "MGDIFEEN, "
            stConsultaSQL += "MGDIFEFI, "
            stConsultaSQL += "MGDIOBSE "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MOGEDIGI, USUARIO "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "MGDINUDO = USUANUDO "

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "MGDIFEEN "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Consultar_MOGEDIGI")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que busca el ID del codigo buscado para ejecutar la consulta
    ''' parametrizada.
    ''' </summary>
    Public Function fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_MOGEDIGI(ByVal inMGDISECU As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "MGDIIDRE, "
            stConsultaSQL += "MGDISECU, "
            stConsultaSQL += "MGDINUDO, "
            stConsultaSQL += "USUANOMB, "
            stConsultaSQL += "USUAPRAP, "
            stConsultaSQL += "USUASEAP, "
            stConsultaSQL += "MGDIFEEN, "
            stConsultaSQL += "MGDIFEFI, "
            stConsultaSQL += "MGDIOBSE "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MOGEDIGI, USUARIO "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "MGDINUDO = USUANUDO and "
            stConsultaSQL += "MGDISECU = '" & CInt(inMGDISECU) & "'"

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "MGDIFEEN "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception

            MessageBox.Show(Err.Description & " " & "fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_MOGEDIGI")
            Return Nothing

        End Try

    End Function

    ''' <summary>
    ''' Función que busca el CÓDIGO para que no se 
    ''' guarden registros duplicados.
    ''' </summary>
    Public Function fun_Buscar_CODIGO_X_MOGEDIGI(ByVal inMGDISECU As Integer, ByVal stMGDINUDO As String, ByVal stMGDIFEEN As String) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MOGEDIGI "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "MGDISECU = '" & CInt(inMGDISECU) & "' and "
            stConsultaSQL += "MGDINUDO = '" & CStr(Trim(stMGDINUDO)) & "' and "
            stConsultaSQL += "MGDIFEEN = '" & CStr(Trim(stMGDIFEEN)) & "' "

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
    Public Function fun_Buscar_CODIGO_X_MOGEDIGI(ByVal inMGDISECU As Integer, ByVal stMGDINUDO As String) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MOGEDIGI "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "MGDISECU = '" & CInt(inMGDISECU) & "' and "
            stConsultaSQL += "MGDINUDO = '" & CStr(Trim(stMGDINUDO)) & "' "

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
