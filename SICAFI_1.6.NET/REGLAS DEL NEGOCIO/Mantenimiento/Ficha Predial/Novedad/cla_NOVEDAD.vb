Imports DATOS

Public Class cla_NOVEDAD

    ' ==========================
    ' *** CLASE MANT_NOVEDAD ***
    ' ==========================

    ''' <summary>
    ''' MANT_NOVEDAD que verifica la llave primaria.
    ''' </summary>
    Public Function fun_Verifica_llave_Primaria_MANT_NOVEDAD(ByVal obNOVECODI As Object) As Boolean

        Try
            Dim boRespuesta As Boolean = False

            Dim obVerifica As New cla_Verificar_Dato

            If obVerifica.fun_Verificar_Campo_Lleno(obNOVECODI.Text) = True Then

                Dim objdatos1 As New cla_NOVEDAD
                Dim tbl As New DataTable

                tbl = objdatos1.fun_Buscar_CODIGO_MANT_NOVEDAD(Trim(obNOVECODI.Text))

                If tbl.Rows.Count > 0 Then
                    MessageBox.Show("El dato " & obNOVECODI.Text & " del campo " & obNOVECODI.AccessibleDescription & " existe en la base de datos.", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                    obNOVECODI.Focus()
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
    Public Function fun_Insertar_MANT_NOVEDAD(ByVal inNOVECODI As Integer, _
                                              ByVal stNOVEDESC As String, _
                                              ByVal stNOVEESTA As String) As Boolean

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' PROCatena la consulta
            stConsultaSQL += "INSERT INTO "
            stConsultaSQL += "MANT_NOVEDAD "

            stConsultaSQL += "( "
            stConsultaSQL += "NOVECODI, "
            stConsultaSQL += "NOVEDESC, "
            stConsultaSQL += "NOVEESTA "
            stConsultaSQL += ") "

            stConsultaSQL += "VALUES "

            stConsultaSQL += "( "
            stConsultaSQL += "'" & CInt(inNOVECODI) & "', "
            stConsultaSQL += "'" & CStr(Trim(stNOVEDESC)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stNOVEESTA)) & "' "
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
            MessageBox.Show(Err.Description & " " & "fun_Insertar_MANT_NOVEDAD")
        End Try

    End Function

    ''' <summary>
    ''' Función que Elimina el registro.
    ''' </summary>
    Public Function fun_Eliminar_MANT_NOVEDAD(ByVal inNOVEIDRE As Integer) As Boolean

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' PROCatena la consulta
            stConsultaSQL += "DELETE "
            stConsultaSQL += "MANT_NOVEDAD "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "NOVEIDRE = '" & CInt(inNOVEIDRE) & "' "

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
            MessageBox.Show(Err.Description & " " & "fun_Eliminar_MANT_NOVEDAD")
        End Try

    End Function

    ''' <summary>
    ''' Función que Modifica el registro.
    ''' </summary>
    Public Function fun_Actualizar_MANT_NOVEDAD(ByVal inNOVEIDRE As Integer, _
                                                ByVal inNOVECODI As Integer, _
                                                ByVal stNOVEDESC As String, _
                                                ByVal stNOVEESTA As String) As Boolean

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' PROCatena la consulta
            stConsultaSQL += "UPDATE "
            stConsultaSQL += "MANT_NOVEDAD "

            stConsultaSQL += "SET "
            stConsultaSQL += "NOVECODI = '" & CInt(inNOVECODI) & "', "
            stConsultaSQL += "NOVEDESC = '" & CStr(Trim(stNOVEDESC)) & "', "
            stConsultaSQL += "NOVEESTA = '" & CStr(Trim(stNOVEESTA)) & "' "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "NOVEIDRE = '" & CInt(inNOVEIDRE) & "'"

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
            MessageBox.Show(Err.Description & " " & "fun_Actualizar_MANT_NOVEDAD")
        End Try

    End Function

    ''' <summary>
    ''' Consulta para llenar el DataGridView y colocar el nombre del encabezado
    ''' de la columna. 
    ''' </summary>
    Public Function fun_Consultar_MANT_NOVEDAD() As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' PROCatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "NOVEIDRE, "
            stConsultaSQL += "NOVECODI, "
            stConsultaSQL += "NOVEDESC, "
            stConsultaSQL += "NOVEESTA  "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MANT_NOVEDAD "

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "NOVECODI "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Consultar_MANT_NOVEDAD")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Llena el ComboBox con datos activos e inactivos formulario principal 
    ''' esta funcion se llama desde el MANT_NOVEDAD "pro_inicializarControles()".
    ''' </summary>
    Public Function fun_Consultar_CAMPOS_MANT_NOVEDAD() As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' PROCatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MANT_NOVEDAD "

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "NOVECODI "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Consultar_CAMPOS_MANT_NOVEDAD")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Llena el ComboBox con datos activos formulario insertar y modificar 
    ''' esta funcion se llama desde el MANT_NOVEDAD "pro_inicializarControles()".
    ''' </summary>
    Public Function fun_Consultar_MANT_NOVEDAD_X_ESTADO() As DataTable

        Try
            Dim boInsertar As Boolean = True

            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' PROCatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MANT_NOVEDAD "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "NOVEESTA = 'ac' "

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "NOVECODI "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Consultar_MANT_NOVEDAD_X_ESTADO")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que busca el ID del registro a modificar o eliminar.
    ''' </summary>
    Public Function fun_Buscar_ID_MANT_NOVEDAD(ByVal inNOVEIDRE As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' PROCatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MANT_NOVEDAD "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "NOVEIDRE = '" & CInt(inNOVEIDRE) & "'"

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Buscar_ID_MANT_NOVEDAD")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que busca el CÓDIGO para que no se 
    ''' guarden registros duplicados.
    ''' </summary>
    Public Function fun_Buscar_CODIGO_MANT_NOVEDAD(ByVal inNOVECODI As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' PROCatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MANT_NOVEDAD "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "NOVECODI = '" & CInt(inNOVECODI) & "'"

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Buscar_CODIGO_MANT_NOVEDAD")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que busca el ID del codigo buscado para ejecutar la consulta
    ''' parametrizada.
    ''' </summary>
    Public Function fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_MANT_NOVEDAD(ByVal inNOVEIDRE As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' PROCatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "NOVEIDRE, "
            stConsultaSQL += "NOVECODI, "
            stConsultaSQL += "NOVEDESC, "
            stConsultaSQL += "NOVEESTA  "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MANT_NOVEDAD "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "NOVEIDRE = '" & CInt(inNOVEIDRE) & "'"

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "NOVECODI "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception

            MessageBox.Show(Err.Description & " " & "fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_MANT_NOVEDAD")
            Return Nothing

        End Try

    End Function

End Class
