Imports DATOS

Public Class cla_CLASVERS

    ' ========================
    ' *** CLASE DE VERSIÓN ***
    ' ========================

    ''' <summary>
    ''' MANT_CLASVERS que verifica la llave primaria.
    ''' </summary>
    Public Function fun_Verifica_llave_Primaria_MANT_CLASVERS(ByVal obCLVECODI As Object) As Boolean

        Try
            Dim boRespuesta As Boolean = False

            Dim obVerifica As New cla_Verificar_Dato

            If obVerifica.fun_Verificar_Campo_Lleno(obCLVECODI.Text) = True Then

                Dim objdatos1 As New cla_CLASVERS
                Dim tbl As New DataTable

                tbl = objdatos1.fun_Buscar_CODIGO_MANT_CLASVERS(Trim(obCLVECODI.Text))

                If tbl.Rows.Count > 0 Then
                    MessageBox.Show("El dato " & obCLVECODI.Text & " del campo " & obCLVECODI.AccessibleDescription & " existe en la base de datos.", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                    obCLVECODI.Focus()
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
    Public Function fun_Insertar_MANT_CLASVERS(ByVal inCLVECODI As Integer, _
                                               ByVal stCLVEDESC As String, _
                                               ByVal stCLVEESTA As String) As Boolean

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' PROCatena la consulta
            stConsultaSQL += "INSERT INTO "
            stConsultaSQL += "MANT_CLASVERS "

            stConsultaSQL += "( "
            stConsultaSQL += "CLVECODI, "
            stConsultaSQL += "CLVEDESC, "
            stConsultaSQL += "CLVEESTA "
            stConsultaSQL += ") "

            stConsultaSQL += "VALUES "

            stConsultaSQL += "( "
            stConsultaSQL += "'" & CInt(inCLVECODI) & "', "
            stConsultaSQL += "'" & CStr(Trim(stCLVEDESC)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stCLVEESTA)) & "' "
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
            MessageBox.Show(Err.Description & " " & "fun_Insertar_MANT_CLASVERS")
        End Try

    End Function

    ''' <summary>
    ''' Función que Elimina el registro.
    ''' </summary>
    Public Function fun_Eliminar_MANT_CLASVERS(ByVal inCLVEIDRE As Integer) As Boolean

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' PROCatena la consulta
            stConsultaSQL += "DELETE "
            stConsultaSQL += "MANT_CLASVERS "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "CLVEIDRE = '" & CInt(inCLVEIDRE) & "' "

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
            MessageBox.Show(Err.Description & " " & "fun_Eliminar_MANT_CLASVERS")
        End Try

    End Function

    ''' <summary>
    ''' Función que Modifica el registro.
    ''' </summary>
    Public Function fun_Actualizar_MANT_CLASVERS(ByVal inCLVEIDRE As Integer, _
                                                 ByVal inCLVECODI As Integer, _
                                                 ByVal stCLVEDESC As String, _
                                                 ByVal stCLVEESTA As String) As Boolean

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' PROCatena la consulta
            stConsultaSQL += "UPDATE "
            stConsultaSQL += "MANT_CLASVERS "

            stConsultaSQL += "SET "
            stConsultaSQL += "CLVECODI = '" & CInt(inCLVECODI) & "', "
            stConsultaSQL += "CLVEDESC = '" & CStr(Trim(stCLVEDESC)) & "', "
            stConsultaSQL += "CLVEESTA = '" & CStr(Trim(stCLVEESTA)) & "' "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "CLVEIDRE = '" & CInt(inCLVEIDRE) & "'"

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
            MessageBox.Show(Err.Description & " " & "fun_Actualizar_MANT_CLASVERS")
        End Try

    End Function

    ''' <summary>
    ''' Consulta para llenar el DataGridView y colocar el nombre del encabezado
    ''' de la columna. 
    ''' </summary>
    Public Function fun_Consultar_MANT_CLASVERS() As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' PROCatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "CLVEIDRE, "
            stConsultaSQL += "CLVECODI, "
            stConsultaSQL += "CLVEDESC, "
            stConsultaSQL += "CLVEESTA  "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MANT_CLASVERS "

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "CLVECODI "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Consultar_MANT_CLASVERS")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Llena el ComboBox con datos activos e inactivos formulario principal 
    ''' esta funcion se llama desde el MANT_CLASVERS "pro_inicializarControles()".
    ''' </summary>
    Public Function fun_Consultar_CAMPOS_MANT_CLASVERS() As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' PROCatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MANT_CLASVERS "

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "CLVECODI "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Consultar_CAMPOS_MANT_CLASVERS")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Llena el ComboBox con datos activos formulario insertar y modificar 
    ''' esta funcion se llama desde el MANT_CLASVERS "pro_inicializarControles()".
    ''' </summary>
    Public Function fun_Consultar_MANT_CLASVERS_X_ESTADO() As DataTable

        Try
            Dim boInsertar As Boolean = True

            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' PROCatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MANT_CLASVERS "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "CLVEESTA = 'ac' "

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "CLVECODI "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Consultar_MANT_CLASVERS_X_ESTADO")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que busca el ID del registro a modificar o eliminar.
    ''' </summary>
    Public Function fun_Buscar_ID_MANT_CLASVERS(ByVal inCLVEIDRE As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' PROCatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MANT_CLASVERS "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "CLVEIDRE = '" & CInt(inCLVEIDRE) & "'"

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Buscar_ID_MANT_CLASVERS")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que busca el CÓDIGO para que no se 
    ''' guarden registros duplicados.
    ''' </summary>
    Public Function fun_Buscar_CODIGO_MANT_CLASVERS(ByVal inCLVECODI As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' PROCatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MANT_CLASVERS "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "CLVECODI = '" & CInt(inCLVECODI) & "'"

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Buscar_CODIGO_MANT_CLASVERS")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que busca el ID del codigo buscado para ejecutar la consulta
    ''' parametrizada.
    ''' </summary>
    Public Function fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_MANT_CLASVERS(ByVal inCLVEIDRE As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' PROCatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "CLVEIDRE, "
            stConsultaSQL += "CLVECODI, "
            stConsultaSQL += "CLVEDESC, "
            stConsultaSQL += "CLVEESTA  "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MANT_CLASVERS "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "CLVEIDRE = '" & CInt(inCLVEIDRE) & "'"

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "CLVECODI "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception

            MessageBox.Show(Err.Description & " " & "fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_MANT_CLASVERS")
            Return Nothing

        End Try

    End Function

    ''' <summary>
    ''' Carga el codigo y la descripcion de los registros activos que carga el combobox
    ''' </summary>
    Public Function fun_Consultar_Campos_MANT_CLASVERS_X_ESTADO() As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "CLVECODI, "
            stConsultaSQL += "CLVEDESC  "


            stConsultaSQL += "FROM "
            stConsultaSQL += "MANT_CLASVERS "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "CLVEESTA = 'ac' "

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "CLVEDESC "

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
