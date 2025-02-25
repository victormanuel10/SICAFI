Imports DATOS

Public Class cla_CONTCOMA

    ' ===========================
    ' *** CONTROL DE COMANDOS ***
    ' ===========================

    ''' <summary>
    ''' MANT_CONTCOMA que verifica la llave primaria.
    ''' </summary>
    Public Function fun_Verifica_llave_Primaria_MANT_CONTCOMA(ByVal obCOCOCODI As Object) As Boolean

        Try
            Dim boRespuesta As Boolean = False

            Dim obVerifica As New cla_Verificar_Dato

            If obVerifica.fun_Verificar_Campo_Lleno(obCOCOCODI.Text) = True Then

                Dim objdatos1 As New cla_CONTCOMA
                Dim tbl As New DataTable

                tbl = objdatos1.fun_Buscar_CODIGO_MANT_CONTCOMA(Trim(obCOCOCODI.Text))

                If tbl.Rows.Count > 0 Then
                    MessageBox.Show("El dato " & obCOCOCODI.Text & " del campo " & obCOCOCODI.AccessibleDescription & " existe en la base de datos.", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                    obCOCOCODI.Focus()
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
    Public Function fun_Insertar_MANT_CONTCOMA(ByVal stCOCOCODI As String, _
                                               ByVal stCOCODESC As String, _
                                               ByVal stCOCOESTA As String) As Boolean

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' PROCatena la consulta
            stConsultaSQL += "INSERT INTO "
            stConsultaSQL += "MANT_CONTCOMA "

            stConsultaSQL += "( "
            stConsultaSQL += "COCOCODI, "
            stConsultaSQL += "COCODESC, "
            stConsultaSQL += "COCOESTA "
            stConsultaSQL += ") "

            stConsultaSQL += "VALUES "

            stConsultaSQL += "( "
            stConsultaSQL += "'" & CStr(Trim(stCOCOCODI)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stCOCODESC)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stCOCOESTA)) & "' "
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
            MessageBox.Show(Err.Description & " " & "fun_Insertar_MANT_CONTCOMA")
        End Try

    End Function

    ''' <summary>
    ''' Función que Elimina el registro.
    ''' </summary>
    Public Function fun_Eliminar_MANT_CONTCOMA(ByVal inCOCOIDRE As Integer) As Boolean

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' PROCatena la consulta
            stConsultaSQL += "DELETE "
            stConsultaSQL += "MANT_CONTCOMA "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "COCOIDRE = '" & CInt(inCOCOIDRE) & "' "

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
            MessageBox.Show(Err.Description & " " & "fun_Eliminar_MANT_CONTCOMA")
        End Try

    End Function

    ''' <summary>
    ''' Función que Modifica el registro.
    ''' </summary>
    Public Function fun_Actualizar_MANT_CONTCOMA(ByVal inCOCOIDRE As Integer, _
                                                 ByVal stCOCOCODI As String, _
                                                 ByVal stCOCODESC As String, _
                                                 ByVal stCOCOESTA As String) As Boolean

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' PROCatena la consulta
            stConsultaSQL += "UPDATE "
            stConsultaSQL += "MANT_CONTCOMA "

            stConsultaSQL += "SET "
            stConsultaSQL += "COCOCODI = '" & CStr(Trim(stCOCOCODI)) & "', "
            stConsultaSQL += "COCODESC = '" & CStr(Trim(stCOCODESC)) & "', "
            stConsultaSQL += "COCOESTA = '" & CStr(Trim(stCOCOESTA)) & "' "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "COCOIDRE = '" & CInt(inCOCOIDRE) & "'"

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
            MessageBox.Show(Err.Description & " " & "fun_Actualizar_MANT_CONTCOMA")
        End Try

    End Function

    ''' <summary>
    ''' Consulta para llenar el DataGridView y colocar el nombre del encabezado
    ''' de la columna. 
    ''' </summary>
    Public Function fun_Consultar_MANT_CONTCOMA() As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' PROCatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "COCOIDRE, "
            stConsultaSQL += "COCOCODI, "
            stConsultaSQL += "COCODESC, "
            stConsultaSQL += "COCOESTA  "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MANT_CONTCOMA "

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "COCOCODI "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Consultar_MANT_CONTCOMA")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Llena el ComboBox con datos activos e inactivos formulario principal 
    ''' esta funcion se llama desde el MANT_CONTCOMA "pro_inicializarControles()".
    ''' </summary>
    Public Function fun_Consultar_CAMPOS_MANT_CONTCOMA() As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' PROCatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MANT_CONTCOMA "

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "COCOCODI "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Consultar_CAMPOS_MANT_CONTCOMA")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Llena el ComboBox con datos activos formulario insertar y modificar 
    ''' esta funcion se llama desde el MANT_CONTCOMA "pro_inicializarControles()".
    ''' </summary>
    Public Function fun_Consultar_MANT_CONTCOMA_X_ESTADO() As DataTable

        Try
            Dim boInsertar As Boolean = True

            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' PROCatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MANT_CONTCOMA "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "COCOESTA = 'ac' "

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "COCOCODI "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Consultar_MANT_CONTCOMA_X_ESTADO")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que busca el ID del registro a modificar o eliminar.
    ''' </summary>
    Public Function fun_Buscar_ID_MANT_CONTCOMA(ByVal inCOCOIDRE As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' PROCatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MANT_CONTCOMA "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "COCOIDRE = '" & CInt(inCOCOIDRE) & "'"

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Buscar_ID_MANT_CONTCOMA")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que busca el CÓDIGO para que no se 
    ''' guarden registros duplicados.
    ''' </summary>
    Public Function fun_Buscar_CODIGO_MANT_CONTCOMA(ByVal stCOCOCODI As String) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' PROCatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MANT_CONTCOMA "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "COCOCODI = '" & CStr(Trim(stCOCOCODI)) & "'"

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Buscar_CODIGO_MANT_CONTCOMA")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que busca el ID del codigo buscado para ejecutar la consulta
    ''' parametrizada.
    ''' </summary>
    Public Function fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_MANT_CONTCOMA(ByVal inCOCOIDRE As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' PROCatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "COCOIDRE, "
            stConsultaSQL += "COCOCODI, "
            stConsultaSQL += "COCODESC, "
            stConsultaSQL += "COCOESTA  "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MANT_CONTCOMA "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "COCOIDRE = '" & CInt(inCOCOIDRE) & "'"

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "COCOCODI "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception

            MessageBox.Show(Err.Description & " " & "fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_MANT_CONTCOMA")
            Return Nothing

        End Try

    End Function

    ''' <summary>
    ''' Carga el codigo y la descripcion de los registros activos que carga el combobox
    ''' </summary>
    Public Function fun_Consultar_Campos_MANT_CONTCOMA_X_ESTADO() As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "COCOCODI, "
            stConsultaSQL += "COCODESC  "


            stConsultaSQL += "FROM "
            stConsultaSQL += "MANT_CONTCOMA "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "COCOESTA = 'ac' "

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "COCODESC "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Consultar_Campos_MANT_CLASSECT_X_ESTADO")
            Return Nothing
        End Try
    End Function

End Class
