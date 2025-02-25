Imports DATOS

Public Class cla_ESTRFIPR

    '=============================
    '*** ESTRATO FICHA PREDIAL ***
    '=============================

    ''' <summary>
    ''' procedimiento que verifica la llave primaria.
    ''' </summary>
    Public Function fun_Verifica_llave_Primaria_ESTRFIPR(ByVal obESFPNUFI As Object, ByVal obESFPESTR As Object) As Boolean

        Try
            Dim boRespuesta As Boolean = False

            Dim obVerifica As New cla_Verificar_Dato

            If obVerifica.fun_Verificar_Campo_Lleno(obESFPNUFI.Text) = True And obVerifica.fun_Verificar_Campo_Lleno(obESFPESTR.Text) = True Then
                If obVerifica.fun_Verificar_Dato_Numerico(obESFPNUFI.Text) = True And obVerifica.fun_Verificar_Dato_Numerico(obESFPESTR.Text) = True Then

                    Dim objdatos1 As New cla_ESTRFIPR
                    Dim tbl As New DataTable

                    tbl = objdatos1.fun_Buscar_CODIGO_ESTRFIPR(Trim(obESFPNUFI.Text), Trim(obESFPESTR.Text))

                    If tbl.Rows.Count > 0 Then
                        MessageBox.Show("El dato " & obESFPNUFI.Text & " - " & obESFPESTR.Text & " del campo " & obESFPESTR.AccessibleDescription & " existe en la base de datos.", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                        obESFPNUFI.Focus()
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
    Public Function fun_Insertar_ESTRFIPR(ByVal inESFPNUFI As Integer, _
                                          ByVal inESFPESTR As Integer, _
                                          ByVal stESFPESTA As String) As Boolean

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "INSERT INTO "
            stConsultaSQL += "ESTRFIPR "

            stConsultaSQL += "( "
            stConsultaSQL += "ESFPNUFI, "
            stConsultaSQL += "ESFPESTR, "
            stConsultaSQL += "ESFPESTA "
            stConsultaSQL += ") "

            stConsultaSQL += "VALUES "

            stConsultaSQL += "( "
            stConsultaSQL += "'" & CInt(inESFPNUFI) & "', "
            stConsultaSQL += "'" & CInt(inESFPESTR) & "', "
            stConsultaSQL += "'" & CStr(Trim(stESFPESTA)) & "' "
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
            MessageBox.Show(Err.Description & " " & "fun_Insertar_ESTRFIPR")
        End Try

    End Function

    ''' <summary>
    ''' Función que Elimina el registro.
    ''' </summary>
    Public Function fun_Eliminar_ESTRFIPR(ByVal inESFPIDRE As Integer) As Boolean

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "DELETE "
            stConsultaSQL += "ESTRFIPR "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "ESFPIDRE = '" & CInt(inESFPIDRE) & "' "

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
            MessageBox.Show(Err.Description & " " & "fun_Eliminar_ESTRFIPR")
        End Try

    End Function

    ''' <summary>
    ''' Función que Elimina el registro.
    ''' </summary>
    Public Function fun_Eliminar_ESTRFIPR_X_NRO_FICHA_Y_ESTRATO(ByVal inESFPNUFI As Integer, ByVal inESFPESTR As Integer) As Boolean

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "DELETE "
            stConsultaSQL += "ESTRFIPR "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "ESFPNUFI = '" & CInt(inESFPNUFI) & "' and "
            stConsultaSQL += "ESFPESTR = '" & CInt(inESFPESTR) & "' "

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
            MessageBox.Show(Err.Description & " " & "fun_Eliminar_ESTRFIPR")
        End Try

    End Function

    ''' <summary>
    ''' Función que Modifica el registro.
    ''' </summary>
    Public Function fun_Actualizar_ESTRFIPR(ByVal inESFPNUFI As Integer, _
                                            ByVal inESFPESTR As Integer, _
                                            ByVal stESFPESTA As String) As Boolean

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "UPDATE "
            stConsultaSQL += "ESTRFIPR "

            stConsultaSQL += "SET "
            stConsultaSQL += "ESFPNUFI = '" & CInt(inESFPNUFI) & "', "
            stConsultaSQL += "ESFPESTR = '" & CInt(inESFPESTR) & "', "
            stConsultaSQL += "ESFPESTA = '" & CStr(Trim(stESFPESTA)) & "' "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "ESFPNUFI = '" & CInt(inESFPNUFI) & "' and "
            stConsultaSQL += "ESFPESTR = '" & CInt(inESFPESTR) & "' "

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
            MessageBox.Show(Err.Description & " " & "fun_Actualizar_ESTRFIPR")
        End Try

    End Function

    ''' <summary>
    ''' Consulta para llenar el DataGridView y colocar el nombre del encabezado
    ''' de la columna. 
    ''' </summary>
    Public Function fun_Consultar_ESTRFIPR() As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "ESFPIDRE, "
            stConsultaSQL += "ESFPNUFI, "
            stConsultaSQL += "ESFPESTR, "
            stConsultaSQL += "ESFPESTA "

            stConsultaSQL += "FROM "
            stConsultaSQL += "ESTRFIPR "

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "ESFPNUFI, ESFPESTR "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Consultar_ESTRFIPR")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Llena el ComboBox con datos activos e inactivos formulario principal 
    ''' esta funcion se llama desde el procedimiento "pro_inicializarControles()".
    ''' </summary>
    Public Function fun_Consultar_CAMPOS_ESTRFIPR() As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "ESTRFIPR "

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "ESFPNUFI, ESFPESTR "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Consultar_CAMPOS_ESTRFIPR")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Llena el ComboBox con datos activos formulario insertar y modificar 
    ''' esta funcion se llama desde el procedimiento "pro_inicializarControles()".
    ''' </summary>
    Public Function fun_Consultar_ESTRFIPR_X_ESTADO() As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "ESTRFIPR "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "ESFPESTA = 'ac' "

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "ESFPNUFI, ESFPESTR "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Consultar_ESTRFIPR_X_ESTADO")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que busca el ID del registro a modificar o eliminar.
    ''' </summary>
    Public Function fun_Buscar_ID_ESTRFIPR(ByVal inESFPIDRE As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "ESTRFIPR "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "ESFPIDRE = '" & CInt(inESFPIDRE) & "'"

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Buscar_ID_ESTRFIPR")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que busca los propietarios anteriores por numero de ficha 
    ''' </summary>
    Public Function fun_Buscar_ESTRATO_X_NRO_DE_FICHA(ByVal inESFPNUFI As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "ESTRFIPR "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "ESFPNUFI = '" & CInt(inESFPNUFI) & "' "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Buscar_CODIGO_ESTRFIPR")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que busca los propietarios anteriores por numero de ficha 
    ''' </summary>
    Public Function fun_Buscar_ESTRATO_X_NRO_DE_FICHA_Y_ESTRATO(ByVal inESFPNUFI As Integer, ByVal inESFPESTR As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "ESTRFIPR "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "ESFPNUFI = '" & CInt(inESFPNUFI) & "' and "
            stConsultaSQL += "ESFPESTR = '" & CInt(inESFPESTR) & "' "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Buscar_CODIGO_ESTRFIPR")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que busca el CÓDIGO DE LA CALIDAD DE PROPIETARIO para que no se 
    ''' guarden registros duplicados.
    ''' </summary>
    Public Function fun_Buscar_CODIGO_ESTRFIPR(ByVal inESFPNUFI As Integer, ByVal inESFPESTR As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "ESTRFIPR "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "ESFPNUFI = '" & CInt(inESFPNUFI) & "' and "
            stConsultaSQL += "ESFPESTR = '" & CInt(inESFPESTR) & "' "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Buscar_CODIGO_ESTRFIPR")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que busca el ID del codigo buscado para ejecutar la consulta
    ''' parametrizada.
    ''' </summary>
    Public Function fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_ESTRFIPR(ByVal inESFPIDRE As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "ESFPIDRE, "
            stConsultaSQL += "ESFPNUFI, "
            stConsultaSQL += "ESFPESTR, "
            stConsultaSQL += "ESFPESTA "

            stConsultaSQL += "FROM "
            stConsultaSQL += "ESTRFIPR "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "ESFPIDRE = '" & CInt(inESFPIDRE) & "'"

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "ESFPNUFI, ESFPESTR "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception

            MessageBox.Show(Err.Description & " " & "fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_ESTRFIPR")
            Return Nothing

        End Try

    End Function




End Class
