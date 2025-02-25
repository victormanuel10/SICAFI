Imports DATOS

Public Class cla_PLANCART

    '==========================
    '*** PLANO CARTOGRAFICO ***
    '==========================

    ''' <summary>
    ''' Verifica que verifica la llave primaria.
    ''' </summary>
    Public Function fun_Verifica_llave_Primaria_MANT_PLANCART(ByVal obPLCACODI As Object) As Boolean

        Try
            Dim boRespuesta As Boolean = False

            Dim obVerifica As New cla_Verificar_Dato

            If obVerifica.fun_Verificar_Campo_Lleno(obPLCACODI.Text) = True Then

                Dim objdatos1 As New cla_PLANCART
                Dim tbl As New DataTable

                tbl = objdatos1.fun_Buscar_CODIGO_MANT_PLANCART(Trim(obPLCACODI.Text))

                If tbl.Rows.Count > 0 Then
                    MessageBox.Show("El dato " & obPLCACODI.Text & " del campo " & obPLCACODI.AccessibleDescription & " existe en la base de datos.", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                    obPLCACODI.Focus()
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
    Public Function fun_Insertar_MANT_PLANCART(ByVal inPLCACODI As Integer, _
                                               ByVal stPLCADESC As String, _
                                               ByVal stPLCAESTA As String) As Boolean

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' PROCatena la consulta
            stConsultaSQL += "INSERT INTO "
            stConsultaSQL += "MANT_PLANCART "

            stConsultaSQL += "( "
            stConsultaSQL += "PLCACODI, "
            stConsultaSQL += "PLCADESC, "
            stConsultaSQL += "PLCAESTA "
            stConsultaSQL += ") "

            stConsultaSQL += "VALUES "

            stConsultaSQL += "( "
            stConsultaSQL += "'" & CInt(inPLCACODI) & "', "
            stConsultaSQL += "'" & CStr(Trim(stPLCADESC)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stPLCAESTA)) & "' "
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
            MessageBox.Show(Err.Description & " " & "fun_Insertar_MANT_PLANCART")
        End Try

    End Function

    ''' <summary>
    ''' Función que Elimina el registro.
    ''' </summary>
    Public Function fun_Eliminar_MANT_PLANCART(ByVal inPLCAIDRE As Integer) As Boolean

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' PROCatena la consulta
            stConsultaSQL += "DELETE "
            stConsultaSQL += "MANT_PLANCART "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "PLCAIDRE = '" & CInt(inPLCAIDRE) & "' "

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
            MessageBox.Show(Err.Description & " " & "fun_Eliminar_MANT_PLANCART")
        End Try

    End Function

    ''' <summary>
    ''' Función que Modifica el registro.
    ''' </summary>
    Public Function fun_Actualizar_MANT_PLANCART(ByVal inPLCAIDRE As Integer, _
                                            ByVal inPLCACODI As Integer, _
                                            ByVal stPLCADESC As String, _
                                            ByVal stPLCAESTA As String) As Boolean

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' PROCatena la consulta
            stConsultaSQL += "UPDATE "
            stConsultaSQL += "MANT_PLANCART "

            stConsultaSQL += "SET "
            stConsultaSQL += "PLCACODI = '" & CInt(inPLCACODI) & "', "
            stConsultaSQL += "PLCADESC = '" & CStr(Trim(stPLCADESC)) & "', "
            stConsultaSQL += "PLCAESTA = '" & CStr(Trim(stPLCAESTA)) & "' "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "PLCAIDRE = '" & CInt(inPLCAIDRE) & "'"

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
            MessageBox.Show(Err.Description & " " & "fun_Actualizar_MANT_PLANCART")
        End Try

    End Function

    ''' <summary>
    ''' Consulta para llenar el DataGridView y colocar el nombre del encabezado
    ''' de la columna. 
    ''' </summary>
    Public Function fun_Consultar_MANT_PLANCART() As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' PROCatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "PLCAIDRE, "
            stConsultaSQL += "PLCACODI, "
            stConsultaSQL += "PLCADESC, "
            stConsultaSQL += "PLCAESTA  "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MANT_PLANCART "

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "PLCACODI "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Consultar_MANT_PLANCART")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Llena el ComboBox con datos activos e inactivos formulario principal 
    ''' esta funcion se llama desde el MANT_PLANCART "pro_inicializarControles()".
    ''' </summary>
    Public Function fun_Consultar_CAMPOS_MANT_PLANCART() As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' PROCatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MANT_PLANCART "

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "PLCACODI "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Consultar_CAMPOS_MANT_PLANCART")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Llena el ComboBox con datos activos formulario insertar y modificar 
    ''' esta funcion se llama desde el MANT_PLANCART "pro_inicializarControles()".
    ''' </summary>
    Public Function fun_Consultar_MANT_PLANCART_X_ESTADO() As DataTable

        Try
            Dim boInsertar As Boolean = True

            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' PROCatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MANT_PLANCART "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "PLCAESTA = 'ac' "

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "PLCACODI "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Consultar_MANT_PLANCART_X_ESTADO")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que busca el ID del registro a modificar o eliminar.
    ''' </summary>
    Public Function fun_Buscar_ID_MANT_PLANCART(ByVal inPLCAIDRE As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' PROCatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MANT_PLANCART "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "PLCAIDRE = '" & CInt(inPLCAIDRE) & "'"

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Buscar_ID_MANT_PLANCART")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que busca el CÓDIGO para que no se 
    ''' guarden registros duplicados.
    ''' </summary>
    Public Function fun_Buscar_CODIGO_MANT_PLANCART(ByVal inPLCACODI As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' PROCatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MANT_PLANCART "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "PLCACODI = '" & CInt(inPLCACODI) & "'"

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Buscar_CODIGO_MANT_PLANCART")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que busca el ID del codigo buscado para ejecutar la consulta
    ''' parametrizada.
    ''' </summary>
    Public Function fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_MANT_PLANCART(ByVal inPLCAIDRE As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' PROCatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "PLCAIDRE, "
            stConsultaSQL += "PLCACODI, "
            stConsultaSQL += "PLCADESC, "
            stConsultaSQL += "PLCAESTA  "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MANT_PLANCART "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "PLCAIDRE = '" & CInt(inPLCAIDRE) & "'"

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "PLCACODI "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception

            MessageBox.Show(Err.Description & " " & "fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_MANT_PLANCART")
            Return Nothing

        End Try

    End Function

End Class
