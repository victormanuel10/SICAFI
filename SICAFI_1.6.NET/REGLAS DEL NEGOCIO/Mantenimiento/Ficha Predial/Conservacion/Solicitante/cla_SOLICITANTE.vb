Imports DATOS

Public Class cla_SOLICITANTE

    '===================
    '*** SOLICITANTE ***
    '===================

    ''' <summary>
    ''' procedimiento que verifica la llave primaria.
    ''' </summary>
    Public Function fun_Verifica_llave_Primaria_MANT_SOLICITANTE(ByVal obSOLICODI As Object) As Boolean

        Try
            Dim boRespuesta As Boolean = False

            Dim obVerifica As New cla_Verificar_Dato

            If obVerifica.fun_Verificar_Campo_Lleno(obSOLICODI.Text) = True Then
                If obVerifica.fun_Verificar_Dato_Numerico(obSOLICODI.Text) = True Then

                    Dim objdatos1 As New cla_SOLICITANTE
                    Dim tbl As New DataTable

                    tbl = objdatos1.fun_Buscar_CODIGO_MANT_SOLICITANTE(Trim(obSOLICODI.Text))

                    If tbl.Rows.Count > 0 Then
                        MessageBox.Show("El dato " & obSOLICODI.Text & " del campo " & obSOLICODI.AccessibleDescription & " existe en la base de datos.", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                        obSOLICODI.Focus()
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
    Public Function fun_Insertar_MANT_SOLICITANTE(ByVal inSOLICODI As Integer, _
                                                  ByVal stSOLIDESC As String, _
                                                  ByVal stSOLIESTA As String) As Boolean

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' TITRatena la consulta
            stConsultaSQL += "INSERT INTO "
            stConsultaSQL += "MANT_SOLICITANTE "

            stConsultaSQL += "( "
            stConsultaSQL += "SOLICODI, "
            stConsultaSQL += "SOLIDESC, "
            stConsultaSQL += "SOLIESTA "
            stConsultaSQL += ") "

            stConsultaSQL += "VALUES "

            stConsultaSQL += "( "
            stConsultaSQL += "'" & CInt(inSOLICODI) & "', "
            stConsultaSQL += "'" & CStr(Trim(stSOLIDESC)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stSOLIESTA)) & "' "
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
            MessageBox.Show(Err.Description & " " & "fun_Insertar_MANT_SOLICITANTE")
        End Try

    End Function

    ''' <summary>
    ''' Función que Elimina el registro.
    ''' </summary>
    Public Function fun_Eliminar_MANT_SOLICITANTE(ByVal inSOLIIDRE As Integer) As Boolean

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' TITRatena la consulta
            stConsultaSQL += "DELETE "
            stConsultaSQL += "MANT_SOLICITANTE "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "SOLIIDRE = '" & CInt(inSOLIIDRE) & "' "

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
            MessageBox.Show(Err.Description & " " & "fun_Eliminar_MANT_SOLICITANTE")
        End Try

    End Function

    ''' <summary>
    ''' Función que Modifica el registro.
    ''' </summary>
    Public Function fun_Actualizar_MANT_SOLICITANTE(ByVal inSOLIIDRE As Integer, _
                                                    ByVal inSOLICODI As Integer, _
                                                    ByVal stSOLIDESC As String, _
                                                    ByVal stSOLIESTA As String) As Boolean

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' TITRatena la consulta
            stConsultaSQL += "UPDATE "
            stConsultaSQL += "MANT_SOLICITANTE "

            stConsultaSQL += "SET "
            stConsultaSQL += "SOLICODI = '" & CInt(inSOLICODI) & "', "
            stConsultaSQL += "SOLIDESC = '" & CStr(Trim(stSOLIDESC)) & "', "
            stConsultaSQL += "SOLIESTA = '" & CStr(Trim(stSOLIESTA)) & "' "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "SOLIIDRE = '" & CInt(inSOLIIDRE) & "'"

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
            MessageBox.Show(Err.Description & " " & "fun_Actualizar_MANT_SOLICITANTE")
        End Try

    End Function

    ''' <summary>
    ''' Consulta para llenar el DataGridView y colocar el nombre del encabezado
    ''' de la columna. 
    ''' </summary>
    Public Function fun_Consultar_MANT_SOLICITANTE() As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' TITRatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "SOLIIDRE, "
            stConsultaSQL += "SOLICODI, "
            stConsultaSQL += "SOLIDESC, "
            stConsultaSQL += "SOLIESTA  "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MANT_SOLICITANTE "

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "SOLICODI "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Consultar_MANT_SOLICITANTE")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Llena el ComboBox con datos activos e inactivos formulario principal 
    ''' esta funcion se llama desde el procedimiento "pro_inicializarControles()".
    ''' </summary>
    Public Function fun_Consultar_CAMPOS_MANT_SOLICITANTE() As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' TITRatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MANT_SOLICITANTE "

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "SOLICODI "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Consultar_CAMPOS_MANT_SOLICITANTE")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Llena el ComboBox con datos activos formulario insertar y modificar 
    ''' esta funcion se llama desde el procedimiento "pro_inicializarControles()".
    ''' </summary>
    Public Function fun_Consultar_MANT_SOLICITANTE_X_ESTADO() As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' TITRatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MANT_SOLICITANTE "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "SOLIESTA = 'ac' "

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "SOLICODI "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Consultar_MANT_SOLICITANTE_X_ESTADO")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que busca el ID del registro a modificar o eliminar.
    ''' </summary>
    Public Function fun_Buscar_ID_MANT_SOLICITANTE(ByVal inSOLIIDRE As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' TITRatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MANT_SOLICITANTE "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "SOLIIDRE = '" & CInt(inSOLIIDRE) & "'"

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Buscar_ID_MANT_SOLICITANTE")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que busca el CÓDIGO DE LA CALIDAD DE PROPIETARIO para que no se 
    ''' guarden registros duplicados.
    ''' </summary>
    Public Function fun_Buscar_CODIGO_MANT_SOLICITANTE(ByVal inSOLICODI As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' TITRatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MANT_SOLICITANTE "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "SOLICODI = '" & CInt(inSOLICODI) & "'"

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Buscar_CODIGO_MANT_SOLICITANTE")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que busca el ID del codigo buscado para ejecutar la consulta
    ''' parametrizada.
    ''' </summary>
    Public Function fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_MANT_SOLICITANTE(ByVal inSOLIIDRE As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' TITRatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "SOLIIDRE, "
            stConsultaSQL += "SOLICODI, "
            stConsultaSQL += "SOLIDESC, "
            stConsultaSQL += "SOLIESTA  "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MANT_SOLICITANTE "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "SOLIIDRE = '" & CInt(inSOLIIDRE) & "'"

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "SOLICODI "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception

            MessageBox.Show(Err.Description & " " & "fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_MANT_SOLICITANTE")
            Return Nothing

        End Try

    End Function

End Class
