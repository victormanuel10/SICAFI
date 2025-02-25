Imports DATOS

Public Class cla_AGUAS

    ' =============
    ' *** AGUAS ***
    ' =============

    ''' <summary>
    ''' AGUAS que verifica la llave primaria.
    ''' </summary>
    Public Function fun_Verifica_llave_Primaria_AGUAS(ByVal obAGUACODI As Object) As Boolean

        Try
            Dim boRespuesta As Boolean = False

            Dim obVerifica As New cla_Verificar_Dato

            If obVerifica.fun_Verificar_Campo_Lleno(obAGUACODI.Text) = True Then

                Dim objdatos1 As New cla_AGUAS
                Dim tbl As New DataTable

                tbl = objdatos1.fun_Buscar_CODIGO_AGUAS(Trim(obAGUACODI.Text))

                If tbl.Rows.Count > 0 Then
                    MessageBox.Show("El dato " & obAGUACODI.Text & " del campo " & obAGUACODI.AccessibleDescription & " existe en la base de datos.", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                    obAGUACODI.Focus()
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
    Public Function fun_Insertar_AGUAS(ByVal inAGUACODI As Integer, _
                                       ByVal stAGUADESC As String, _
                                       ByVal stAGUAESTA As String) As Boolean

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' PROCatena la consulta
            stConsultaSQL += "INSERT INTO "
            stConsultaSQL += "MANT_AGUAS "

            stConsultaSQL += "( "
            stConsultaSQL += "AGUACODI, "
            stConsultaSQL += "AGUADESC, "
            stConsultaSQL += "AGUAESTA "
            stConsultaSQL += ") "

            stConsultaSQL += "VALUES "

            stConsultaSQL += "( "
            stConsultaSQL += "'" & CInt(inAGUACODI) & "', "
            stConsultaSQL += "'" & CStr(Trim(stAGUADESC)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stAGUAESTA)) & "' "
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
            MessageBox.Show(Err.Description & " " & "fun_Insertar_AGUAS")
        End Try

    End Function

    ''' <summary>
    ''' Función que Elimina el registro.
    ''' </summary>
    Public Function fun_Eliminar_AGUAS(ByVal inAGUAIDRE As Integer) As Boolean

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' PROCatena la consulta
            stConsultaSQL += "DELETE "
            stConsultaSQL += "MANT_AGUAS "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "AGUAIDRE = '" & CInt(inAGUAIDRE) & "' "

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
            MessageBox.Show(Err.Description & " " & "fun_Eliminar_AGUAS")
        End Try

    End Function

    ''' <summary>
    ''' Función que Modifica el registro.
    ''' </summary>
    Public Function fun_Actualizar_AGUAS(ByVal inAGUAIDRE As Integer, _
                                         ByVal inAGUACODI As Integer, _
                                         ByVal stAGUADESC As String, _
                                         ByVal stAGUAESTA As String) As Boolean

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' PROCatena la consulta
            stConsultaSQL += "UPDATE "
            stConsultaSQL += "MANT_AGUAS "

            stConsultaSQL += "SET "
            stConsultaSQL += "AGUACODI = '" & CInt(inAGUACODI) & "', "
            stConsultaSQL += "AGUADESC = '" & CStr(Trim(stAGUADESC)) & "', "
            stConsultaSQL += "AGUAESTA = '" & CStr(Trim(stAGUAESTA)) & "' "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "AGUAIDRE = '" & CInt(inAGUAIDRE) & "'"

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
            MessageBox.Show(Err.Description & " " & "fun_Actualizar_AGUAS")
        End Try

    End Function

    ''' <summary>
    ''' Consulta para llenar el DataGridView y colocar el nombre del encabezado
    ''' de la columna. 
    ''' </summary>
    Public Function fun_Consultar_AGUAS() As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' PROCatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "AGUAIDRE, "
            stConsultaSQL += "AGUACODI, "
            stConsultaSQL += "AGUADESC, "
            stConsultaSQL += "AGUAESTA  "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MANT_AGUAS "

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "AGUACODI "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Consultar_AGUAS")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Llena el ComboBox con datos activos e inactivos formulario principal 
    ''' esta funcion se llama desde el AGUAS "pro_inicializarControles()".
    ''' </summary>
    Public Function fun_Consultar_CAMPOS_AGUAS() As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' PROCatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MANT_AGUAS "

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "AGUACODI "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Consultar_CAMPOS_AGUAS")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Llena el ComboBox con datos activos formulario insertar y modificar 
    ''' esta funcion se llama desde el AGUAS "pro_inicializarControles()".
    ''' </summary>
    Public Function fun_Consultar_AGUAS_X_ESTADO() As DataTable

        Try
            Dim boInsertar As Boolean = True

            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' PROCatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MANT_AGUAS "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "AGUAESTA = 'ac' "

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "AGUACODI "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Consultar_AGUAS_X_ESTADO")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que busca el ID del registro a modificar o eliminar.
    ''' </summary>
    Public Function fun_Buscar_ID_AGUAS(ByVal inAGUAIDRE As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' PROCatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MANT_AGUAS "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "AGUAIDRE = '" & CInt(inAGUAIDRE) & "'"

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Buscar_ID_AGUAS")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que busca el CÓDIGO para que no se 
    ''' guarden registros duplicados.
    ''' </summary>
    Public Function fun_Buscar_CODIGO_AGUAS(ByVal inAGUACODI As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' PROCatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MANT_AGUAS "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "AGUACODI = '" & CInt(inAGUACODI) & "'"

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Buscar_CODIGO_AGUAS")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que busca el ID del codigo buscado para ejecutar la consulta
    ''' parametrizada.
    ''' </summary>
    Public Function fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_AGUAS(ByVal inAGUAIDRE As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' PROCatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "AGUAIDRE, "
            stConsultaSQL += "AGUACODI, "
            stConsultaSQL += "AGUADESC, "
            stConsultaSQL += "AGUAESTA  "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MANT_AGUAS "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "AGUAIDRE = '" & CInt(inAGUAIDRE) & "'"

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "AGUACODI "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception

            MessageBox.Show(Err.Description & " " & "fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_AGUAS")
            Return Nothing

        End Try

    End Function

End Class
