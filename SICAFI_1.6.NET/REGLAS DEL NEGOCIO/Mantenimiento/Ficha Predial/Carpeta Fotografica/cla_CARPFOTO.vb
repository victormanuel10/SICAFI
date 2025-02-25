Imports DATOS

Public Class cla_CARPFOTO

    '===========================
    '*** CARPETA FOTOGRAFICA ***
    '===========================

    ''' <summary>
    ''' Verifica que verifica la llave primaria.
    ''' </summary>
    Public Function fun_Verifica_llave_Primaria_MANT_CARPFOTO(ByVal obCAFOCODI As Object) As Boolean

        Try
            Dim boRespuesta As Boolean = False

            Dim obVerifica As New cla_Verificar_Dato

            If obVerifica.fun_Verificar_Campo_Lleno(obCAFOCODI.Text) = True Then

                Dim objdatos1 As New cla_CARPFOTO
                Dim tbl As New DataTable

                tbl = objdatos1.fun_Buscar_CODIGO_MANT_CARPFOTO(Trim(obCAFOCODI.Text))

                If tbl.Rows.Count > 0 Then
                    MessageBox.Show("El dato " & obCAFOCODI.Text & " del campo " & obCAFOCODI.AccessibleDescription & " existe en la base de datos.", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                    obCAFOCODI.Focus()
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
    Public Function fun_Insertar_MANT_CARPFOTO(ByVal inCAFOCODI As Integer, _
                                               ByVal stCAFODESC As String, _
                                               ByVal stCAFOESTA As String) As Boolean

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' PROCatena la consulta
            stConsultaSQL += "INSERT INTO "
            stConsultaSQL += "MANT_CARPFOTO "

            stConsultaSQL += "( "
            stConsultaSQL += "CAFOCODI, "
            stConsultaSQL += "CAFODESC, "
            stConsultaSQL += "CAFOESTA "
            stConsultaSQL += ") "

            stConsultaSQL += "VALUES "

            stConsultaSQL += "( "
            stConsultaSQL += "'" & CInt(inCAFOCODI) & "', "
            stConsultaSQL += "'" & CStr(Trim(stCAFODESC)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stCAFOESTA)) & "' "
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
            MessageBox.Show(Err.Description & " " & "fun_Insertar_MANT_CARPFOTO")
        End Try

    End Function

    ''' <summary>
    ''' Función que Elimina el registro.
    ''' </summary>
    Public Function fun_Eliminar_MANT_CARPFOTO(ByVal inCAFOIDRE As Integer) As Boolean

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' PROCatena la consulta
            stConsultaSQL += "DELETE "
            stConsultaSQL += "MANT_CARPFOTO "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "CAFOIDRE = '" & CInt(inCAFOIDRE) & "' "

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
            MessageBox.Show(Err.Description & " " & "fun_Eliminar_MANT_CARPFOTO")
        End Try

    End Function

    ''' <summary>
    ''' Función que Modifica el registro.
    ''' </summary>
    Public Function fun_Actualizar_MANT_CARPFOTO(ByVal inCAFOIDRE As Integer, _
                                            ByVal inCAFOCODI As Integer, _
                                            ByVal stCAFODESC As String, _
                                            ByVal stCAFOESTA As String) As Boolean

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' PROCatena la consulta
            stConsultaSQL += "UPDATE "
            stConsultaSQL += "MANT_CARPFOTO "

            stConsultaSQL += "SET "
            stConsultaSQL += "CAFOCODI = '" & CInt(inCAFOCODI) & "', "
            stConsultaSQL += "CAFODESC = '" & CStr(Trim(stCAFODESC)) & "', "
            stConsultaSQL += "CAFOESTA = '" & CStr(Trim(stCAFOESTA)) & "' "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "CAFOIDRE = '" & CInt(inCAFOIDRE) & "'"

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
            MessageBox.Show(Err.Description & " " & "fun_Actualizar_MANT_CARPFOTO")
        End Try

    End Function

    ''' <summary>
    ''' Consulta para llenar el DataGridView y colocar el nombre del encabezado
    ''' de la columna. 
    ''' </summary>
    Public Function fun_Consultar_MANT_CARPFOTO() As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' PROCatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "CAFOIDRE, "
            stConsultaSQL += "CAFOCODI, "
            stConsultaSQL += "CAFODESC, "
            stConsultaSQL += "CAFOESTA  "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MANT_CARPFOTO "

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "CAFOCODI "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Consultar_MANT_CARPFOTO")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Llena el ComboBox con datos activos e inactivos formulario principal 
    ''' esta funcion se llama desde el MANT_CARPFOTO "pro_inicializarControles()".
    ''' </summary>
    Public Function fun_Consultar_CAMPOS_MANT_CARPFOTO() As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' PROCatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MANT_CARPFOTO "

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "CAFOCODI "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Consultar_CAMPOS_MANT_CARPFOTO")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Llena el ComboBox con datos activos formulario insertar y modificar 
    ''' esta funcion se llama desde el MANT_CARPFOTO "pro_inicializarControles()".
    ''' </summary>
    Public Function fun_Consultar_MANT_CARPFOTO_X_ESTADO() As DataTable

        Try
            Dim boInsertar As Boolean = True

            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' PROCatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MANT_CARPFOTO "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "CAFOESTA = 'ac' "

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "CAFOCODI "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Consultar_MANT_CARPFOTO_X_ESTADO")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que busca el ID del registro a modificar o eliminar.
    ''' </summary>
    Public Function fun_Buscar_ID_MANT_CARPFOTO(ByVal inCAFOIDRE As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' PROCatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MANT_CARPFOTO "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "CAFOIDRE = '" & CInt(inCAFOIDRE) & "'"

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Buscar_ID_MANT_CARPFOTO")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que busca el CÓDIGO para que no se 
    ''' guarden registros duplicados.
    ''' </summary>
    Public Function fun_Buscar_CODIGO_MANT_CARPFOTO(ByVal inCAFOCODI As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' PROCatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MANT_CARPFOTO "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "CAFOCODI = '" & CInt(inCAFOCODI) & "'"

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Buscar_CODIGO_MANT_CARPFOTO")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que busca el ID del codigo buscado para ejecutar la consulta
    ''' parametrizada.
    ''' </summary>
    Public Function fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_MANT_CARPFOTO(ByVal inCAFOIDRE As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' PROCatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "CAFOIDRE, "
            stConsultaSQL += "CAFOCODI, "
            stConsultaSQL += "CAFODESC, "
            stConsultaSQL += "CAFOESTA  "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MANT_CARPFOTO "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "CAFOIDRE = '" & CInt(inCAFOIDRE) & "'"

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "CAFOCODI "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception

            MessageBox.Show(Err.Description & " " & "fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_MANT_CARPFOTO")
            Return Nothing

        End Try

    End Function


End Class
