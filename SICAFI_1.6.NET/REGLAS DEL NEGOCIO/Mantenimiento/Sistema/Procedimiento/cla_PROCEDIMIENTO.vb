Imports DATOS

Public Class cla_PROCEDIMIENTO

    '=====================
    '*** PROCEDIMIENTO ***
    '=====================

    ''' <summary>
    ''' procedimiento que verifica la llave primaria.
    ''' </summary>
    Public Function fun_Verifica_llave_Primaria_PROCEDIMIENTO(ByVal obPROCCODI As Object) As Boolean

        Try
            Dim boRespuesta As Boolean = False

            Dim obVerifica As New cla_Verificar_Dato

            If obVerifica.fun_Verificar_Campo_Lleno(obPROCCODI.Text) = True Then

                Dim objdatos1 As New cla_PROCEDIMIENTO
                Dim tbl As New DataTable

                tbl = objdatos1.fun_Buscar_CODIGO_PROCEDIMIENTO(Trim(obPROCCODI.Text))

                If tbl.Rows.Count > 0 Then
                    MessageBox.Show("El dato " & obPROCCODI.Text & " del campo " & obPROCCODI.AccessibleDescription & " existe en la base de datos.", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                    obPROCCODI.Focus()
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
    Public Function fun_Insertar_PROCEDIMIENTO(ByVal stPROCCODI As String, _
                                               ByVal stPROCDESC As String, _
                                               ByVal boPROCINSE As Boolean, _
                                               ByVal boPROCMODI As Boolean, _
                                               ByVal boPROCELIM As Boolean, _
                                               ByVal boPROCCONS As Boolean, _
                                               ByVal stPROCESTA As String) As Boolean

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' PROCatena la consulta
            stConsultaSQL += "INSERT INTO "
            stConsultaSQL += "PROCEDIMIENTO "

            stConsultaSQL += "( "
            stConsultaSQL += "PROCCODI, "
            stConsultaSQL += "PROCDESC, "
            stConsultaSQL += "PROCINSE, "
            stConsultaSQL += "PROCMODI, "
            stConsultaSQL += "PROCELIM, "
            stConsultaSQL += "PROCCONS, "
            stConsultaSQL += "PROCESTA "
            stConsultaSQL += ") "

            stConsultaSQL += "VALUES "

            stConsultaSQL += "( "
            stConsultaSQL += "'" & CStr(Trim(stPROCCODI)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stPROCDESC)) & "', "
            stConsultaSQL += "'" & CBool(boPROCINSE) & "', "
            stConsultaSQL += "'" & CBool(boPROCMODI) & "', "
            stConsultaSQL += "'" & CBool(boPROCELIM) & "', "
            stConsultaSQL += "'" & CBool(boPROCCONS) & "', "
            stConsultaSQL += "'" & CStr(Trim(stPROCESTA)) & "' "
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
            MessageBox.Show(Err.Description & " " & "fun_Insertar_PROCEDIMIENTO")
        End Try

    End Function

    ''' <summary>
    ''' Función que Elimina el registro.
    ''' </summary>
    Public Function fun_Eliminar_PROCEDIMIENTO(ByVal inPROCIDRE As Integer) As Boolean

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' PROCatena la consulta
            stConsultaSQL += "DELETE "
            stConsultaSQL += "PROCEDIMIENTO "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "PROCIDRE = '" & CInt(inPROCIDRE) & "' "

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
            MessageBox.Show(Err.Description & " " & "fun_Eliminar_PROCEDIMIENTO")
        End Try

    End Function

    ''' <summary>
    ''' Función que Modifica el registro.
    ''' </summary>
    Public Function fun_Actualizar_PROCEDIMIENTO(ByVal inPROCIDRE As Integer, _
                                                 ByVal stPROCCODI As String, _
                                                 ByVal stPROCDESC As String, _
                                                 ByVal boPROCINSE As Boolean, _
                                                 ByVal boPROCMODI As Boolean, _
                                                 ByVal boPROCELIM As Boolean, _
                                                 ByVal boPROCCONS As Boolean, _
                                                 ByVal stPROCESTA As String) As Boolean

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' PROCatena la consulta
            stConsultaSQL += "UPDATE "
            stConsultaSQL += "PROCEDIMIENTO "

            stConsultaSQL += "SET "
            stConsultaSQL += "PROCCODI = '" & CStr(Trim(stPROCCODI)) & "', "
            stConsultaSQL += "PROCDESC = '" & CStr(Trim(stPROCDESC)) & "', "
            stConsultaSQL += "PROCINSE = '" & CBool(boPROCINSE) & "', "
            stConsultaSQL += "PROCMODI = '" & CBool(boPROCMODI) & "', "
            stConsultaSQL += "PROCELIM = '" & CBool(boPROCELIM) & "', "
            stConsultaSQL += "PROCCONS = '" & CBool(boPROCCONS) & "', "
            stConsultaSQL += "PROCESTA = '" & CStr(Trim(stPROCESTA)) & "' "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "PROCIDRE = '" & CInt(inPROCIDRE) & "'"

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
            MessageBox.Show(Err.Description & " " & "fun_Actualizar_PROCEDIMIENTO")
        End Try

    End Function

    ''' <summary>
    ''' Consulta para llenar el DataGridView y colocar el nombre del encabezado
    ''' de la columna. 
    ''' </summary>
    Public Function fun_Consultar_PROCEDIMIENTO() As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' PROCatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "PROCIDRE, "
            stConsultaSQL += "PROCCODI, "
            stConsultaSQL += "PROCDESC, "
            stConsultaSQL += "PROCINSE, "
            stConsultaSQL += "PROCMODI, "
            stConsultaSQL += "PROCELIM, "
            stConsultaSQL += "PROCCONS, "
            stConsultaSQL += "PROCESTA  "

            stConsultaSQL += "FROM "
            stConsultaSQL += "PROCEDIMIENTO "

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "PROCCODI "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Consultar_PROCEDIMIENTO")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Llena el ComboBox con datos activos e inactivos formulario principal 
    ''' esta funcion se llama desde el procedimiento "pro_inicializarControles()".
    ''' </summary>
    Public Function fun_Consultar_CAMPOS_PROCEDIMIENTO() As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' PROCatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "PROCEDIMIENTO "

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "PROCCODI "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Consultar_CAMPOS_PROCEDIMIENTO")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Llena el ComboBox con datos activos formulario insertar y modificar 
    ''' esta funcion se llama desde el procedimiento "pro_inicializarControles()".
    ''' </summary>
    Public Function fun_Consultar_PROCEDIMIENTO_X_ESTADO() As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' PROCatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "PROCEDIMIENTO "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "PROCESTA = 'ac' "

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "PROCCODI "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Consultar_PROCEDIMIENTO_X_ESTADO")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Llena el ComboBox con datos activos formulario insertar y modificar 
    ''' esta funcion se llama desde el procedimiento "pro_inicializarControles()".
    ''' </summary>
    Public Function fun_Consultar_PROCEDIMIENTO_INSERTAR_X_ESTADO() As DataTable

        Try
            Dim boInsertar As Boolean = True

            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' PROCatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "PROCEDIMIENTO "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "PROCESTA = 'ac' and "
            stConsultaSQL += "PROCINSE =  '" & boInsertar & "' "

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "PROCCODI "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Consultar_PROCEDIMIENTO_X_ESTADO")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Llena el ComboBox con datos activos formulario insertar y modificar 
    ''' esta funcion se llama desde el procedimiento "pro_inicializarControles()".
    ''' </summary>
    Public Function fun_Consultar_PROCEDIMIENTO_ELIMINAR_X_ESTADO() As DataTable

        Try
            Dim boEliminar As Boolean = True

            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' PROCatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "PROCEDIMIENTO "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "PROCESTA = 'ac' and "
            stConsultaSQL += "PROCELIM =  '" & boEliminar & "' "

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "PROCCODI "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Consultar_PROCEDIMIENTO_X_ESTADO")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Llena el ComboBox con datos activos formulario insertar y modificar 
    ''' esta funcion se llama desde el procedimiento "pro_inicializarControles()".
    ''' </summary>
    Public Function fun_Consultar_PROCEDIMIENTO_CONSULTAR_X_ESTADO() As DataTable

        Try
            Dim boConsultar As Boolean = True

            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' PROCatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "PROCEDIMIENTO "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "PROCESTA = 'ac' and "
            stConsultaSQL += "PROCCONS =  '" & boConsultar & "' "

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "PROCCODI "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Consultar_PROCEDIMIENTO_X_ESTADO")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que busca el ID del registro a modificar o eliminar.
    ''' </summary>
    Public Function fun_Buscar_ID_PROCEDIMIENTO(ByVal inPROCIDRE As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' PROCatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "PROCEDIMIENTO "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "PROCIDRE = '" & CInt(inPROCIDRE) & "'"

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Buscar_ID_PROCEDIMIENTO")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que busca el CÓDIGO para que no se 
    ''' guarden registros duplicados.
    ''' </summary>
    Public Function fun_Buscar_CODIGO_PROCEDIMIENTO(ByVal stPROCCODI As String) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' PROCatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "PROCEDIMIENTO "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "PROCCODI = '" & CStr(Trim(stPROCCODI)) & "'"

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Buscar_CODIGO_PROCEDIMIENTO")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que busca el ID del codigo buscado para ejecutar la consulta
    ''' parametrizada.
    ''' </summary>
    Public Function fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_PROCEDIMIENTO(ByVal inPROCIDRE As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' PROCatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "PROCIDRE, "
            stConsultaSQL += "PROCCODI, "
            stConsultaSQL += "PROCDESC, "
            stConsultaSQL += "PROCINSE, "
            stConsultaSQL += "PROCMODI, "
            stConsultaSQL += "PROCELIM, "
            stConsultaSQL += "PROCCONS, "
            stConsultaSQL += "PROCESTA  "

            stConsultaSQL += "FROM "
            stConsultaSQL += "PROCEDIMIENTO "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "PROCIDRE = '" & CInt(inPROCIDRE) & "'"

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "PROCCODI "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception

            MessageBox.Show(Err.Description & " " & "fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_PROCEDIMIENTO")
            Return Nothing

        End Try

    End Function

End Class
