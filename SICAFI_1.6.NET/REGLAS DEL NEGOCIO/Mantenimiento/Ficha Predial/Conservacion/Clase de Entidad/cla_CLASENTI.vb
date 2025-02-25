Imports DATOS

Public Class cla_CLASENTI

    '========================
    '*** CLASE DE ENTIDAD ***
    '========================

    ''' <summary>
    ''' procedimiento que verifica la llave primaria.
    ''' </summary>
    Public Function fun_Verifica_llave_Primaria_MANT_CLASENTI(ByVal obCLENCODI As Object) As Boolean

        Try
            Dim boRespuesta As Boolean = False

            Dim obVerifica As New cla_Verificar_Dato

            If obVerifica.fun_Verificar_Campo_Lleno(obCLENCODI.Text) = True Then

                Dim objdatos1 As New cla_CLASENTI
                Dim tbl As New DataTable

                tbl = objdatos1.fun_Buscar_CODIGO_MANT_CLASENTI(Trim(obCLENCODI.Text))

                If tbl.Rows.Count > 0 Then
                    MessageBox.Show("El dato " & obCLENCODI.Text & " del campo " & obCLENCODI.AccessibleDescription & " existe en la base de datos.", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                    obCLENCODI.Focus()
                    boRespuesta = False
                Else
                    boRespuesta = True
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
    Public Function fun_Insertar_MANT_CLASENTI(ByVal stCLENCODI As String, _
                                               ByVal stCLENDESC As String, _
                                               ByVal stCLENESTA As String) As Boolean

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' CLENatena la consulta
            stConsultaSQL += "INSERT INTO "
            stConsultaSQL += "MANT_CLASENTI "

            stConsultaSQL += "( "
            stConsultaSQL += "CLENCODI, "
            stConsultaSQL += "CLENDESC, "
            stConsultaSQL += "CLENESTA "
            stConsultaSQL += ") "

            stConsultaSQL += "VALUES "

            stConsultaSQL += "( "
            stConsultaSQL += "'" & CStr(Trim(stCLENCODI)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stCLENDESC)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stCLENESTA)) & "' "
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
            MessageBox.Show(Err.Description & " " & "fun_Insertar_MANT_CLASENTI")
        End Try

    End Function

    ''' <summary>
    ''' Función que Elimina el registro.
    ''' </summary>
    Public Function fun_Eliminar_MANT_CLASENTI(ByVal inCLENIDRE As Integer) As Boolean

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' CLENatena la consulta
            stConsultaSQL += "DELETE "
            stConsultaSQL += "MANT_CLASENTI "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "CLENIDRE = '" & CInt(inCLENIDRE) & "' "

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
            MessageBox.Show(Err.Description & " " & "fun_Eliminar_MANT_CLASENTI")
        End Try

    End Function

    ''' <summary>
    ''' Función que Modifica el registro.
    ''' </summary>
    Public Function fun_Actualizar_MANT_CLASENTI(ByVal inCLENIDRE As Integer, _
                                                 ByVal stCLENCODI As String, _
                                                 ByVal stCLENDESC As String, _
                                                 ByVal stCLENESTA As String) As Boolean

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' CLENatena la consulta
            stConsultaSQL += "UPDATE "
            stConsultaSQL += "MANT_CLASENTI "

            stConsultaSQL += "SET "
            stConsultaSQL += "CLENCODI = '" & CStr(Trim(stCLENCODI)) & "', "
            stConsultaSQL += "CLENDESC = '" & CStr(Trim(stCLENDESC)) & "', "
            stConsultaSQL += "CLENESTA = '" & CStr(Trim(stCLENESTA)) & "' "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "CLENIDRE = '" & CInt(inCLENIDRE) & "'"

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
            MessageBox.Show(Err.Description & " " & "fun_Actualizar_MANT_CLASENTI")
        End Try

    End Function

    ''' <summary>
    ''' Consulta para llenar el DataGridView y colocar el nombre del encabezado
    ''' de la columna. 
    ''' </summary>
    Public Function fun_Consultar_MANT_CLASENTI() As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' CLENatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "CLENIDRE, "
            stConsultaSQL += "CLENCODI, "
            stConsultaSQL += "CLENDESC, "
            stConsultaSQL += "CLENESTA, "
            stConsultaSQL += "ESTADESC "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MANT_CLASENTI, ESTADO "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "CLENESTA = ESTACODI "

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "CLENCODI "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Consultar_MANT_CLASENTI")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Llena el ComboBox con datos activos e inactivos formulario principal 
    ''' esta funcion se llama desde el procedimiento "pro_inicializarControles()".
    ''' </summary>
    Public Function fun_Consultar_CAMPOS_MANT_CLASENTI() As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' CLENatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MANT_CLASENTI "

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "CLENCODI "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Consultar_CAMPOS_MANT_CLASENTI")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Llena el ComboBox con datos activos formulario insertar y modificar 
    ''' esta funcion se llama desde el procedimiento "pro_inicializarControles()".
    ''' </summary>
    Public Function fun_Consultar_MANT_CLASENTI_X_ESTADO() As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' CLENatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MANT_CLASENTI "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "CLENESTA = 'ac' "

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "CLENCODI "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Consultar_MANT_CLASENTI_X_ESTADO")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que busca el ID del registro a modificar o eliminar.
    ''' </summary>
    Public Function fun_Buscar_ID_MANT_CLASENTI(ByVal inCLENIDRE As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' CLENatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MANT_CLASENTI "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "CLENIDRE = '" & CInt(inCLENIDRE) & "'"

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Buscar_ID_MANT_CLASENTI")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que busca el CÓDIGO DE LA CALIDAD DE PROPIETARIO para que no se 
    ''' guarden registros duplicados.
    ''' </summary>
    Public Function fun_Buscar_CODIGO_MANT_CLASENTI(ByVal stCLENCODI As String) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' CLENatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MANT_CLASENTI "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "CLENCODI = '" & CStr(Trim(stCLENCODI)) & "'"

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Buscar_CODIGO_MANT_CLASENTI")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que busca el ID del codigo buscado para ejecutar la consulta
    ''' parametrizada.
    ''' </summary>
    Public Function fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_MANT_CLASENTI(ByVal inCLENIDRE As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' CLENatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "CLENIDRE, "
            stConsultaSQL += "CLENCODI, "
            stConsultaSQL += "CLENDESC, "
            stConsultaSQL += "CLENESTA, "
            stConsultaSQL += "ESTADESC "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MANT_CLASENTI "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "CLENESTA = ESTACODI AND "
            stConsultaSQL += "CLENIDRE = '" & CInt(inCLENIDRE) & "'"

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "CLENCODI "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception

            MessageBox.Show(Err.Description & " " & "fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_MANT_CLASENTI")
            Return Nothing

        End Try

    End Function

End Class
