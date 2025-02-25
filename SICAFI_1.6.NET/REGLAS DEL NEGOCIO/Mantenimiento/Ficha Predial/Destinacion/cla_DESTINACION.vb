Imports DATOS

Public Class cla_DESTINACION

    ' ===================
    ' *** DESTINACION ***
    ' ===================

    ''' <summary>
    ''' MANT_DESTINACION que verifica la llave primaria.
    ''' </summary>
    Public Function fun_Verifica_llave_Primaria_MANT_DESTINACION(ByVal obDESTCODI As Object) As Boolean

        Try
            Dim boRespuesta As Boolean = False

            Dim obVerifica As New cla_Verificar_Dato

            If obVerifica.fun_Verificar_Campo_Lleno(obDESTCODI.Text) = True Then

                Dim objdatos1 As New cla_DESTINACION
                Dim tbl As New DataTable

                tbl = objdatos1.fun_Buscar_CODIGO_MANT_DESTINACION(Trim(obDESTCODI.Text))

                If tbl.Rows.Count > 0 Then
                    MessageBox.Show("El dato " & obDESTCODI.Text & " del campo " & obDESTCODI.AccessibleDescription & " existe en la base de datos.", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                    obDESTCODI.Focus()
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
    Public Function fun_Insertar_MANT_DESTINACION(ByVal inDESTCODI As Integer, _
                                                  ByVal stDESTDESC As String, _
                                                  ByVal stDESTESTA As String) As Boolean

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' PROCatena la consulta
            stConsultaSQL += "INSERT INTO "
            stConsultaSQL += "MANT_DESTINACION "

            stConsultaSQL += "( "
            stConsultaSQL += "DESTCODI, "
            stConsultaSQL += "DESTDESC, "
            stConsultaSQL += "DESTESTA "
            stConsultaSQL += ") "

            stConsultaSQL += "VALUES "

            stConsultaSQL += "( "
            stConsultaSQL += "'" & CInt(inDESTCODI) & "', "
            stConsultaSQL += "'" & CStr(Trim(stDESTDESC)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stDESTESTA)) & "' "
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
            MessageBox.Show(Err.Description & " " & "fun_Insertar_MANT_DESTINACION")
        End Try

    End Function

    ''' <summary>
    ''' Función que Elimina el registro.
    ''' </summary>
    Public Function fun_Eliminar_MANT_DESTINACION(ByVal inDESTIDRE As Integer) As Boolean

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' PROCatena la consulta
            stConsultaSQL += "DELETE "
            stConsultaSQL += "MANT_DESTINACION "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "DESTIDRE = '" & CInt(inDESTIDRE) & "' "

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
            MessageBox.Show(Err.Description & " " & "fun_Eliminar_MANT_DESTINACION")
        End Try

    End Function

    ''' <summary>
    ''' Función que Modifica el registro.
    ''' </summary>
    Public Function fun_Actualizar_MANT_DESTINACION(ByVal inDESTIDRE As Integer, _
                                                    ByVal inDESTCODI As Integer, _
                                                    ByVal stDESTDESC As String, _
                                                    ByVal stDESTESTA As String) As Boolean

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' PROCatena la consulta
            stConsultaSQL += "UPDATE "
            stConsultaSQL += "MANT_DESTINACION "

            stConsultaSQL += "SET "
            stConsultaSQL += "DESTCODI = '" & CInt(inDESTCODI) & "', "
            stConsultaSQL += "DESTDESC = '" & CStr(Trim(stDESTDESC)) & "', "
            stConsultaSQL += "DESTESTA = '" & CStr(Trim(stDESTESTA)) & "' "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "DESTIDRE = '" & CInt(inDESTIDRE) & "'"

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
            MessageBox.Show(Err.Description & " " & "fun_Actualizar_MANT_DESTINACION")
        End Try

    End Function

    ''' <summary>
    ''' Consulta para llenar el DataGridView y colocar el nombre del encabezado
    ''' de la columna. 
    ''' </summary>
    Public Function fun_Consultar_MANT_DESTINACION() As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' PROCatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "DESTIDRE, "
            stConsultaSQL += "DESTCODI, "
            stConsultaSQL += "DESTDESC, "
            stConsultaSQL += "DESTESTA  "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MANT_DESTINACION "

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "DESTCODI "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Consultar_MANT_DESTINACION")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Llena el ComboBox con datos activos e inactivos formulario principal 
    ''' esta funcion se llama desde el MANT_DESTINACION "pro_inicializarControles()".
    ''' </summary>
    Public Function fun_Consultar_CAMPOS_MANT_DESTINACION() As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' PROCatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MANT_DESTINACION "

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "DESTCODI "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Consultar_CAMPOS_MANT_DESTINACION")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Llena el ComboBox con datos activos formulario insertar y modificar 
    ''' esta funcion se llama desde el MANT_DESTINACION "pro_inicializarControles()".
    ''' </summary>
    Public Function fun_Consultar_MANT_DESTINACION_X_ESTADO() As DataTable

        Try
            Dim boInsertar As Boolean = True

            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' PROCatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MANT_DESTINACION "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "DESTESTA = 'ac' "

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "DESTCODI "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Consultar_MANT_DESTINACION_X_ESTADO")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que busca el ID del registro a modificar o eliminar.
    ''' </summary>
    Public Function fun_Buscar_ID_MANT_DESTINACION(ByVal inDESTIDRE As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' PROCatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MANT_DESTINACION "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "DESTIDRE = '" & CInt(inDESTIDRE) & "'"

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Buscar_ID_MANT_DESTINACION")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que busca el CÓDIGO para que no se 
    ''' guarden registros duplicados.
    ''' </summary>
    Public Function fun_Buscar_CODIGO_MANT_DESTINACION(ByVal inDESTCODI As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' PROCatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MANT_DESTINACION "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "DESTCODI = '" & CInt(inDESTCODI) & "'"

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Buscar_CODIGO_MANT_DESTINACION")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que busca el ID del codigo buscado para ejecutar la consulta
    ''' parametrizada.
    ''' </summary>
    Public Function fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_MANT_DESTINACION(ByVal inDESTIDRE As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' PROCatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "DESTIDRE, "
            stConsultaSQL += "DESTCODI, "
            stConsultaSQL += "DESTDESC, "
            stConsultaSQL += "DESTESTA  "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MANT_DESTINACION "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "DESTIDRE = '" & CInt(inDESTIDRE) & "'"

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "DESTCODI "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception

            MessageBox.Show(Err.Description & " " & "fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_MANT_DESTINACION")
            Return Nothing

        End Try

    End Function

End Class
