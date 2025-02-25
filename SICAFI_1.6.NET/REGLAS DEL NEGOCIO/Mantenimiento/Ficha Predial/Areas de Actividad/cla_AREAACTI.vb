Imports DATOS

Public Class cla_AREAACTI

    ' ==========================
    ' *** AREAS DE ACTIVIDAD ***
    ' ==========================

    ''' <summary>
    ''' MANT_AREAACTI que verifica la llave primaria.
    ''' </summary>
    Public Function fun_Verifica_llave_Primaria_MANT_AREAACTI(ByVal obARACCODI As Object) As Boolean

        Try
            Dim boRespuesta As Boolean = False

            Dim obVerifica As New cla_Verificar_Dato

            If obVerifica.fun_Verificar_Campo_Lleno(obARACCODI.Text) = True Then

                Dim objdatos1 As New cla_AREAACTI
                Dim tbl As New DataTable

                tbl = objdatos1.fun_Buscar_CODIGO_MANT_AREAACTI(Trim(obARACCODI.Text))

                If tbl.Rows.Count > 0 Then
                    MessageBox.Show("El dato " & obARACCODI.Text & " del campo " & obARACCODI.AccessibleDescription & " existe en la base de datos.", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                    obARACCODI.Focus()
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
    Public Function fun_Insertar_MANT_AREAACTI(ByVal inARACCODI As Integer, _
                                               ByVal stARACDESC As String, _
                                               ByVal stARACESTA As String) As Boolean

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' PROCatena la consulta
            stConsultaSQL += "INSERT INTO "
            stConsultaSQL += "MANT_AREAACTI "

            stConsultaSQL += "( "
            stConsultaSQL += "ARACCODI, "
            stConsultaSQL += "ARACDESC, "
            stConsultaSQL += "ARACESTA "
            stConsultaSQL += ") "

            stConsultaSQL += "VALUES "

            stConsultaSQL += "( "
            stConsultaSQL += "'" & CInt(inARACCODI) & "', "
            stConsultaSQL += "'" & CStr(Trim(stARACDESC)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stARACESTA)) & "' "
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
            MessageBox.Show(Err.Description & " " & "fun_Insertar_MANT_AREAACTI")
        End Try

    End Function

    ''' <summary>
    ''' Función que Elimina el registro.
    ''' </summary>
    Public Function fun_Eliminar_MANT_AREAACTI(ByVal inARACIDRE As Integer) As Boolean

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' PROCatena la consulta
            stConsultaSQL += "DELETE "
            stConsultaSQL += "MANT_AREAACTI "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "ARACIDRE = '" & CInt(inARACIDRE) & "' "

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
            MessageBox.Show(Err.Description & " " & "fun_Eliminar_MANT_AREAACTI")
        End Try

    End Function

    ''' <summary>
    ''' Función que Modifica el registro.
    ''' </summary>
    Public Function fun_Actualizar_MANT_AREAACTI(ByVal inARACIDRE As Integer, _
                                                 ByVal inARACCODI As Integer, _
                                                 ByVal stARACDESC As String, _
                                                 ByVal stARACESTA As String) As Boolean

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' PROCatena la consulta
            stConsultaSQL += "UPDATE "
            stConsultaSQL += "MANT_AREAACTI "

            stConsultaSQL += "SET "
            stConsultaSQL += "ARACCODI = '" & CInt(inARACCODI) & "', "
            stConsultaSQL += "ARACDESC = '" & CStr(Trim(stARACDESC)) & "', "
            stConsultaSQL += "ARACESTA = '" & CStr(Trim(stARACESTA)) & "' "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "ARACIDRE = '" & CInt(inARACIDRE) & "'"

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
            MessageBox.Show(Err.Description & " " & "fun_Actualizar_MANT_AREAACTI")
        End Try

    End Function

    ''' <summary>
    ''' Consulta para llenar el DataGridView y colocar el nombre del encabezado
    ''' de la columna. 
    ''' </summary>
    Public Function fun_Consultar_MANT_AREAACTI() As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' PROCatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "ARACIDRE, "
            stConsultaSQL += "ARACCODI, "
            stConsultaSQL += "ARACDESC, "
            stConsultaSQL += "ARACESTA  "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MANT_AREAACTI "

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "ARACCODI "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Consultar_MANT_AREAACTI")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Llena el ComboBox con datos activos e inactivos formulario principal 
    ''' esta funcion se llama desde el MANT_AREAACTI "pro_inicializarControles()".
    ''' </summary>
    Public Function fun_Consultar_CAMPOS_MANT_AREAACTI() As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' PROCatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MANT_AREAACTI "

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "ARACCODI "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Consultar_CAMPOS_MANT_AREAACTI")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Llena el ComboBox con datos activos formulario insertar y modificar 
    ''' esta funcion se llama desde el MANT_AREAACTI "pro_inicializarControles()".
    ''' </summary>
    Public Function fun_Consultar_MANT_AREAACTI_X_ESTADO() As DataTable

        Try
            Dim boInsertar As Boolean = True

            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' PROCatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MANT_AREAACTI "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "ARACESTA = 'ac' "

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "ARACCODI "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Consultar_MANT_AREAACTI_X_ESTADO")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que busca el ID del registro a modificar o eliminar.
    ''' </summary>
    Public Function fun_Buscar_ID_MANT_AREAACTI(ByVal inARACIDRE As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' PROCatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MANT_AREAACTI "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "ARACIDRE = '" & CInt(inARACIDRE) & "'"

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Buscar_ID_MANT_AREAACTI")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que busca el CÓDIGO para que no se 
    ''' guarden registros duplicados.
    ''' </summary>
    Public Function fun_Buscar_CODIGO_MANT_AREAACTI(ByVal inARACCODI As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' PROCatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MANT_AREAACTI "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "ARACCODI = '" & CInt(inARACCODI) & "'"

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Buscar_CODIGO_MANT_AREAACTI")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que busca el ID del codigo buscado para ejecutar la consulta
    ''' parametrizada.
    ''' </summary>
    Public Function fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_MANT_AREAACTI(ByVal inARACIDRE As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' PROCatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "ARACIDRE, "
            stConsultaSQL += "ARACCODI, "
            stConsultaSQL += "ARACDESC, "
            stConsultaSQL += "ARACESTA  "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MANT_AREAACTI "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "ARACIDRE = '" & CInt(inARACIDRE) & "'"

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "ARACCODI "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception

            MessageBox.Show(Err.Description & " " & "fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_MANT_AREAACTI")
            Return Nothing

        End Try

    End Function


End Class
