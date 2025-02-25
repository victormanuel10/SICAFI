Imports DATOS

Public Class cla_FORMULARIO

    '========================
    '*** CLASE FORMULARIO ***
    '========================

    ''' <summary>
    ''' procedimiento que verifica la llave primaria.
    ''' </summary>
    Public Function fun_Verifica_llave_Primaria_MANT_FORMULARIO(ByVal obFORMCODI As Object) As Boolean

        Try
            Dim boRespuesta As Boolean = False

            Dim obVerifica As New cla_Verificar_Dato

            If obVerifica.fun_Verificar_Campo_Lleno(obFORMCODI.Text) = True Then

                Dim objdatos1 As New cla_FORMULARIO
                Dim tbl As New DataTable

                tbl = objdatos1.fun_Buscar_CODIGO_MANT_FORMULARIO(Trim(obFORMCODI.Text))

                If tbl.Rows.Count > 0 Then
                    MessageBox.Show("El dato " & obFORMCODI.Text & " del campo " & obFORMCODI.AccessibleDescription & " existe en la base de datos.", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                    obFORMCODI.Focus()
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
    Public Function fun_Insertar_MANT_FORMULARIO(ByVal stFORMCODI As String, _
                                                 ByVal stFORMDESC As String, _
                                                 ByVal stFORMESTA As String) As Boolean

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' CLASatena la consulta
            stConsultaSQL += "INSERT INTO "
            stConsultaSQL += "MANT_FORMULARIO "

            stConsultaSQL += "( "
            stConsultaSQL += "FORMCODI, "
            stConsultaSQL += "FORMDESC, "
            stConsultaSQL += "FORMESTA "
            stConsultaSQL += ") "

            stConsultaSQL += "VALUES "

            stConsultaSQL += "( "
            stConsultaSQL += "'" & CStr(Trim(stFORMCODI)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stFORMDESC)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stFORMESTA)) & "' "
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
            MessageBox.Show(Err.Description & " " & "fun_Insertar_MANT_FORMULARIO")
        End Try

    End Function

    ''' <summary>
    ''' Función que Elimina el registro.
    ''' </summary>
    Public Function fun_Eliminar_MANT_FORMULARIO(ByVal inFORMIDRE As Integer) As Boolean

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' CLASatena la consulta
            stConsultaSQL += "DELETE "
            stConsultaSQL += "MANT_FORMULARIO "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "FORMIDRE = '" & CInt(inFORMIDRE) & "' "

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
            MessageBox.Show(Err.Description & " " & "fun_Eliminar_MANT_FORMULARIO")
        End Try

    End Function

    ''' <summary>
    ''' Función que Modifica el registro.
    ''' </summary>
    Public Function fun_Actualizar_MANT_FORMULARIO(ByVal inFORMIDRE As Integer, _
                                                   ByVal stFORMCODI As String, _
                                                   ByVal stFORMDESC As String, _
                                                   ByVal stFORMESTA As String) As Boolean

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' CLASatena la consulta
            stConsultaSQL += "UPDATE "
            stConsultaSQL += "MANT_FORMULARIO "

            stConsultaSQL += "SET "
            stConsultaSQL += "FORMCODI = '" & CStr(Trim(stFORMCODI)) & "', "
            stConsultaSQL += "FORMDESC = '" & CStr(Trim(stFORMDESC)) & "', "
            stConsultaSQL += "FORMESTA = '" & CStr(Trim(stFORMESTA)) & "' "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "FORMIDRE = '" & CInt(inFORMIDRE) & "'"

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
            MessageBox.Show(Err.Description & " " & "fun_Actualizar_MANT_FORMULARIO")
        End Try

    End Function

    ''' <summary>
    ''' Consulta para llenar el DataGridView y colocar el nombre del encabezado
    ''' de la columna. 
    ''' </summary>
    Public Function fun_Consultar_MANT_FORMULARIO() As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' CLASatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "FORMIDRE, "
            stConsultaSQL += "FORMCODI, "
            stConsultaSQL += "FORMDESC, "
            stConsultaSQL += "FORMESTA  "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MANT_FORMULARIO "

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "FORMCODI "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Consultar_MANT_FORMULARIO")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Llena el ComboBox con datos activos e inactivos formulario principal 
    ''' esta funcion se llama desde el procedimiento "pro_inicializarControles()".
    ''' </summary>
    Public Function fun_Consultar_CAMPOS_MANT_FORMULARIO() As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' CLASatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MANT_FORMULARIO "

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "FORMCODI "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Consultar_CAMPOS_MANT_FORMULARIO")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Llena el ComboBox con datos activos formulario insertar y modificar 
    ''' esta funcion se llama desde el procedimiento "pro_inicializarControles()".
    ''' </summary>
    Public Function fun_Consultar_MANT_FORMULARIO_X_ESTADO() As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' CLASatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MANT_FORMULARIO "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "FORMESTA = 'ac' "

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "FORMCODI "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Consultar_MANT_FORMULARIO_X_ESTADO")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que busca el ID del registro a modificar o eliminar.
    ''' </summary>
    Public Function fun_Buscar_ID_MANT_FORMULARIO(ByVal inFORMIDRE As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' CLASatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MANT_FORMULARIO "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "FORMIDRE = '" & CInt(inFORMIDRE) & "'"

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Buscar_ID_MANT_FORMULARIO")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que busca el CÓDIGO DE LA CALIDAD DE PROPIETARIO para que no se 
    ''' guarden registros duplicados.
    ''' </summary>
    Public Function fun_Buscar_CODIGO_MANT_FORMULARIO(ByVal stFORMCODI As String) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' CLASatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MANT_FORMULARIO "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "FORMCODI = '" & CStr(Trim(stFORMCODI)) & "'"

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Buscar_CODIGO_MANT_FORMULARIO")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que busca el ID del codigo buscado para ejecutar la consulta
    ''' parametrizada.
    ''' </summary>
    Public Function fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_MANT_FORMULARIO(ByVal inFORMIDRE As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' CLASatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "FORMIDRE, "
            stConsultaSQL += "FORMCODI, "
            stConsultaSQL += "FORMDESC, "
            stConsultaSQL += "FORMESTA  "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MANT_FORMULARIO "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "FORMIDRE = '" & CInt(inFORMIDRE) & "'"

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "FORMCODI "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception

            MessageBox.Show(Err.Description & " " & "fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_MANT_FORMULARIO")
            Return Nothing

        End Try

    End Function

End Class
