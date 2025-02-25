Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration
Imports DATOS

Public Class cla_DIGITACION

    '========================
    '*** CLASE DIGITACION ***
    '========================

    ''' <summary>
    ''' procedimiento que verifica la llave primaria.
    ''' </summary>
    Public Function fun_Verifica_llave_Primaria_DIGITACION(ByVal inDIGISECU As Integer, ByVal obDIGINUDO As Object) As Boolean

        Try
            Dim boRespuesta As Boolean = False

            Dim obVerifica As New cla_Verificar_Dato

            If obVerifica.fun_Verificar_Campo_Lleno(inDIGISECU) = True And _
                obVerifica.fun_Verificar_Campo_Lleno(obDIGINUDO.Text) = True Then

                If obVerifica.fun_Verificar_Dato_Numerico(inDIGISECU) = True Then

                    Dim objdatos1 As New cla_DIGITACION
                    Dim tbl As New DataTable

                    tbl = objdatos1.fun_Buscar_CODIGO_X_DIGITACION(inDIGISECU, obDIGINUDO.Text)

                    If tbl.Rows.Count > 0 Then
                        MessageBox.Show("El dato " & Trim(inDIGISECU) & " - " & Trim(obDIGINUDO.Text) & " existe en la base de datos.", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                        obDIGINUDO.Focus()
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
    Public Function fun_Insertar_DIGITACION(ByVal inDIGISECU As Integer, _
                                          ByVal stDIGINUDO As String, _
                                          ByVal stDIGIFEEN As String, _
                                          ByVal stDIGIFERE As String, _
                                          ByVal stDIGIOBSE As String) As Boolean

        Try

            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "INSERT INTO "
            stConsultaSQL += "DIGITACION "

            stConsultaSQL += "( "
            stConsultaSQL += "DIGISECU, "
            stConsultaSQL += "DIGINUDO, "
            stConsultaSQL += "DIGIFEEN, "
            stConsultaSQL += "DIGIFERE, "
            stConsultaSQL += "DIGIOBSE "
            stConsultaSQL += ") "

            stConsultaSQL += "VALUES "

            stConsultaSQL += "( "
            stConsultaSQL += "'" & CInt(inDIGISECU) & "', "
            stConsultaSQL += "'" & CStr(Trim(stDIGINUDO)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stDIGIFEEN)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stDIGIFERE)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stDIGIOBSE)) & "' "
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
            MessageBox.Show(Err.Description & " " & "fun_Insertar_DIGITACION")
        End Try

    End Function

    ''' <summary>
    ''' Función que Elimina el registro.
    ''' </summary>
    Public Function fun_Eliminar_IDRE_DIGITACION(ByVal inDIGIIDRE As Integer) As Boolean

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "DELETE "
            stConsultaSQL += "DIGITACION "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "DIGIIDRE = '" & CInt(inDIGIIDRE) & "' "

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
            MessageBox.Show(Err.Description & " " & "fun_Eliminar_IDRE_DIGITACION")
        End Try

    End Function

    ''' <summary>
    ''' Función que Elimina el registro.
    ''' </summary>
    Public Function fun_Eliminar_SECU_X_NUDO_DIGITACION(ByVal inDIGISECU As Integer, ByVal stDIGINUDO As String) As Boolean

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "DELETE "
            stConsultaSQL += "DIGITACION "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "DIGISECU = '" & CInt(inDIGISECU) & "' and "
            stConsultaSQL += "DIGINUDO = '" & CStr(Trim(stDIGINUDO)) & "' "

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
            MessageBox.Show(Err.Description & " " & "fun_Eliminar_SECU_X_MACA_DIGITACION")
        End Try

    End Function

    ''' <summary>
    ''' Función que Elimina el registro.
    ''' </summary>
    Public Function fun_Eliminar_SECU_DIGITACION(ByVal inDIGISECU As Integer) As Boolean

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "DELETE "
            stConsultaSQL += "DIGITACION "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "DIGISECU = '" & CInt(inDIGISECU) & "' "

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
            MessageBox.Show(Err.Description & " " & "fun_Eliminar_IDRE_DIGITACION")
        End Try

    End Function

    ''' <summary>
    ''' Función que Modifica el registro.
    ''' </summary>
    Public Function fun_Actualizar_DIGITACION(ByVal inDIGIIDRE As Integer, _
                                            ByVal inDIGISECU As Integer, _
                                            ByVal stDIGINUDO As String, _
                                            ByVal stDIGIFEEN As String, _
                                            ByVal stDIGIFERE As String, _
                                            ByVal stDIGIOBSE As String) As Boolean

        Try

            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "UPDATE "
            stConsultaSQL += "DIGITACION "

            stConsultaSQL += "SET "
            stConsultaSQL += "DIGISECU = '" & CInt(inDIGISECU) & "', "
            stConsultaSQL += "DIGINUDO = '" & CStr(Trim(stDIGINUDO)) & "', "
            stConsultaSQL += "DIGIFEEN = '" & CStr(Trim(stDIGIFEEN)) & "', "
            stConsultaSQL += "DIGIFERE = '" & CStr(Trim(stDIGIFERE)) & "', "
            stConsultaSQL += "DIGIOBSE = '" & CStr(Trim(stDIGIOBSE)) & "' "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "DIGIIDRE = '" & CInt(inDIGIIDRE) & "' "

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
            MessageBox.Show(Err.Description & " " & "fun_Actualizar_DIGITACION")
        End Try

    End Function

    ''' <summary>
    ''' Consulta para llenar el DataGridView y colocar el nombre del encabezado
    ''' de la columna. 
    ''' </summary>
    Public Function fun_Consultar_DIGITACION() As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "DIGIIDRE, "
            stConsultaSQL += "DIGISECU, "
            stConsultaSQL += "DIGINUDO, "
            stConsultaSQL += "USUANOMB, "
            stConsultaSQL += "USUAPRAP, "
            stConsultaSQL += "USUASEAP, "
            stConsultaSQL += "DIGIFEEN, "
            stConsultaSQL += "DIGIFERE, "
            stConsultaSQL += "DIGIOBSE "

            stConsultaSQL += "FROM "
            stConsultaSQL += "DIGITACION, USUARIO "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "DIGINUDO = USUANUDO "

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "DIGIFEEN "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Consultar_DIGITACION")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que busca el ID del codigo buscado para ejecutar la consulta
    ''' parametrizada.
    ''' </summary>
    Public Function fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_DIGITACION(ByVal inDIGISECU As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "DIGIIDRE, "
            stConsultaSQL += "DIGISECU, "
            stConsultaSQL += "DIGINUDO, "
            stConsultaSQL += "USUANOMB, "
            stConsultaSQL += "USUAPRAP, "
            stConsultaSQL += "USUASEAP, "
            stConsultaSQL += "DIGIFEEN, "
            stConsultaSQL += "DIGIFERE, "
            stConsultaSQL += "DIGIOBSE "

            stConsultaSQL += "FROM "
            stConsultaSQL += "DIGITACION, USUARIO "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "DIGINUDO = USUANUDO and "
            stConsultaSQL += "DIGISECU = '" & CInt(inDIGISECU) & "'"

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "DIGIFEEN "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception

            MessageBox.Show(Err.Description & " " & "fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_DIGITACION")
            Return Nothing

        End Try

    End Function

    ''' <summary>
    ''' Función que busca el CÓDIGO para que no se 
    ''' guarden registros duplicados.
    ''' </summary>
    Public Function fun_Buscar_CODIGO_X_DIGITACION(ByVal inDIGISECU As Integer, ByVal stDIGINUDO As String) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "DIGITACION "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "DIGISECU = '" & CInt(inDIGISECU) & "' and "
            stConsultaSQL += "DIGINUDO = '" & CStr(Trim(stDIGINUDO)) & "' "

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
    Public Function fun_Buscar_CODIGO_X_DIGITACION(ByVal inDIGIIDRE As Integer, ByVal inDIGISECU As Integer, ByVal stDIGINUDO As String) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "DIGITACION "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "DIGIIDRE = '" & CInt(inDIGIIDRE) & "' and "
            stConsultaSQL += "DIGISECU = '" & CInt(inDIGISECU) & "' and "
            stConsultaSQL += "DIGINUDO = '" & CStr(Trim(stDIGINUDO)) & "' "

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
