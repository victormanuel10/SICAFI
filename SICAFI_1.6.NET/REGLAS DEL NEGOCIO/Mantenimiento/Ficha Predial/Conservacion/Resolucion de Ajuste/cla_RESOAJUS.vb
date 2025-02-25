Imports DATOS

Public Class cla_RESOAJUS

    '============================
    '*** RESOLUCIÓN DE AJUSTE ***
    '============================

    ''' <summary>
    ''' procedimiento que verifica la llave primaria.
    ''' </summary>
    Public Function fun_Verifica_llave_Primaria_MANT_RESOAJUS(ByVal obREAJCODI As Object) As Boolean

        Try
            Dim boRespuesta As Boolean = False

            Dim obVerifica As New cla_Verificar_Dato

            If obVerifica.fun_Verificar_Campo_Lleno(obREAJCODI.Text) = True Then
                If obVerifica.fun_Verificar_Dato_Numerico(obREAJCODI.Text) = True Then

                    Dim objdatos1 As New cla_RESOAJUS
                    Dim tbl As New DataTable

                    tbl = objdatos1.fun_Buscar_CODIGO_MANT_RESOAJUS(Trim(obREAJCODI.Text))

                    If tbl.Rows.Count > 0 Then
                        MessageBox.Show("El dato " & obREAJCODI.Text & " del campo " & obREAJCODI.AccessibleDescription & " existe en la base de datos.", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                        obREAJCODI.Focus()
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
    Public Function fun_Insertar_MANT_RESOAJUS(ByVal inREAJCODI As Integer, _
                                               ByVal stREAJDESC As String, _
                                               ByVal stREAJESTA As String) As Boolean

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' REAJatena la consulta
            stConsultaSQL += "INSERT INTO "
            stConsultaSQL += "MANT_RESOAJUS "

            stConsultaSQL += "( "
            stConsultaSQL += "REAJCODI, "
            stConsultaSQL += "REAJDESC, "
            stConsultaSQL += "REAJESTA "
            stConsultaSQL += ") "

            stConsultaSQL += "VALUES "

            stConsultaSQL += "( "
            stConsultaSQL += "'" & CInt(inREAJCODI) & "', "
            stConsultaSQL += "'" & CStr(Trim(stREAJDESC)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stREAJESTA)) & "' "
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
            MessageBox.Show(Err.Description & " " & "fun_Insertar_MANT_RESOAJUS")
        End Try

    End Function

    ''' <summary>
    ''' Función que Elimina el registro.
    ''' </summary>
    Public Function fun_Eliminar_MANT_RESOAJUS(ByVal inREAJIDRE As Integer) As Boolean

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' REAJatena la consulta
            stConsultaSQL += "DELETE "
            stConsultaSQL += "MANT_RESOAJUS "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "REAJIDRE = '" & CInt(inREAJIDRE) & "' "

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
            MessageBox.Show(Err.Description & " " & "fun_Eliminar_MANT_RESOAJUS")
        End Try

    End Function

    ''' <summary>
    ''' Función que Modifica el registro.
    ''' </summary>
    Public Function fun_Actualizar_MANT_RESOAJUS(ByVal inREAJIDRE As Integer, _
                                                 ByVal inREAJCODI As Integer, _
                                                 ByVal stREAJDESC As String, _
                                                 ByVal stREAJESTA As String) As Boolean

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' REAJatena la consulta
            stConsultaSQL += "UPDATE "
            stConsultaSQL += "MANT_RESOAJUS "

            stConsultaSQL += "SET "
            stConsultaSQL += "REAJCODI = '" & CInt(inREAJCODI) & "', "
            stConsultaSQL += "REAJDESC = '" & CStr(Trim(stREAJDESC)) & "', "
            stConsultaSQL += "REAJESTA = '" & CStr(Trim(stREAJESTA)) & "' "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "REAJIDRE = '" & CInt(inREAJIDRE) & "'"

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
            MessageBox.Show(Err.Description & " " & "fun_Actualizar_MANT_RESOAJUS")
        End Try

    End Function

    ''' <summary>
    ''' Consulta para llenar el DataGridView y colocar el nombre del encabezado
    ''' de la columna. 
    ''' </summary>
    Public Function fun_Consultar_MANT_RESOAJUS() As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' REAJatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "REAJIDRE, "
            stConsultaSQL += "REAJCODI, "
            stConsultaSQL += "REAJDESC, "
            stConsultaSQL += "REAJESTA  "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MANT_RESOAJUS "

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "REAJCODI "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Consultar_MANT_RESOAJUS")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Llena el ComboBox con datos activos e inactivos formulario principal 
    ''' esta funcion se llama desde el procedimiento "pro_inicializarControles()".
    ''' </summary>
    Public Function fun_Consultar_CAMPOS_MANT_RESOAJUS() As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' REAJatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MANT_RESOAJUS "

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "REAJCODI "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Consultar_CAMPOS_MANT_RESOAJUS")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Llena el ComboBox con datos activos formulario insertar y modificar 
    ''' esta funcion se llama desde el procedimiento "pro_inicializarControles()".
    ''' </summary>
    Public Function fun_Consultar_MANT_RESOAJUS_X_ESTADO() As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' REAJatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MANT_RESOAJUS "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "REAJESTA = 'ac' "

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "REAJCODI "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Consultar_MANT_RESOAJUS_X_ESTADO")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que busca el ID del registro a modificar o eliminar.
    ''' </summary>
    Public Function fun_Buscar_ID_MANT_RESOAJUS(ByVal inREAJIDRE As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' REAJatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MANT_RESOAJUS "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "REAJIDRE = '" & CInt(inREAJIDRE) & "'"

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Buscar_ID_MANT_RESOAJUS")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que busca el CÓDIGO DE LA CALIDAD DE PROPIETARIO para que no se 
    ''' guarden registros duplicados.
    ''' </summary>
    Public Function fun_Buscar_CODIGO_MANT_RESOAJUS(ByVal inREAJCODI As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' REAJatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MANT_RESOAJUS "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "REAJCODI = '" & CInt(inREAJCODI) & "'"

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Buscar_CODIGO_MANT_RESOAJUS")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que busca el ID del codigo buscado para ejecutar la consulta
    ''' parametrizada.
    ''' </summary>
    Public Function fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_MANT_RESOAJUS(ByVal inREAJIDRE As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' REAJatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "REAJIDRE, "
            stConsultaSQL += "REAJCODI, "
            stConsultaSQL += "REAJDESC, "
            stConsultaSQL += "REAJESTA  "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MANT_RESOAJUS "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "REAJIDRE = '" & CInt(inREAJIDRE) & "'"

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "REAJCODI "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception

            MessageBox.Show(Err.Description & " " & "fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_MANT_RESOAJUS")
            Return Nothing

        End Try

    End Function

End Class
