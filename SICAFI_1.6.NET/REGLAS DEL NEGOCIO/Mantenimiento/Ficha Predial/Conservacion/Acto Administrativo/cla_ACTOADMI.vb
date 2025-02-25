Imports DATOS

Public Class cla_ACTOADMI

    '===========================
    '*** ACTO ADMINISTRATIVO ***
    '===========================

    ''' <summary>
    ''' procedimiento que verifica la llave primaria.
    ''' </summary>
    Public Function fun_Verifica_llave_Primaria_MANT_ACTOADMI(ByVal obACADCODI As Object) As Boolean

        Try
            Dim boRespuesta As Boolean = False

            Dim obVerifica As New cla_Verificar_Dato

            If obVerifica.fun_Verificar_Campo_Lleno(obACADCODI.Text) = True Then
                If obVerifica.fun_Verificar_Dato_Numerico(obACADCODI.Text) = True Then

                    Dim objdatos1 As New cla_ACTOADMI
                    Dim tbl As New DataTable

                    tbl = objdatos1.fun_Buscar_CODIGO_MANT_ACTOADMI(Trim(obACADCODI.Text))

                    If tbl.Rows.Count > 0 Then
                        MessageBox.Show("El dato " & obACADCODI.Text & " del campo " & obACADCODI.AccessibleDescription & " existe en la base de datos.", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                        obACADCODI.Focus()
                        boRespuesta = False
                    Else
                        boRespuesta = True
                    End If

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
    Public Function fun_Insertar_MANT_ACTOADMI(ByVal inACADCODI As Integer, _
                                               ByVal stACADDESC As String, _
                                               ByVal stACADESTA As String) As Boolean

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' ACADatena la consulta
            stConsultaSQL += "INSERT INTO "
            stConsultaSQL += "MANT_ACTOADMI "

            stConsultaSQL += "( "
            stConsultaSQL += "ACADCODI, "
            stConsultaSQL += "ACADDESC, "
            stConsultaSQL += "ACADESTA "
            stConsultaSQL += ") "

            stConsultaSQL += "VALUES "

            stConsultaSQL += "( "
            stConsultaSQL += "'" & CInt(inACADCODI) & "', "
            stConsultaSQL += "'" & CStr(Trim(stACADDESC)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stACADESTA)) & "' "
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
            MessageBox.Show(Err.Description & " " & "fun_Insertar_MANT_ACTOADMI")
        End Try

    End Function

    ''' <summary>
    ''' Función que Elimina el registro.
    ''' </summary>
    Public Function fun_Eliminar_MANT_ACTOADMI(ByVal inACADIDRE As Integer) As Boolean

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' ACADatena la consulta
            stConsultaSQL += "DELETE "
            stConsultaSQL += "MANT_ACTOADMI "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "ACADIDRE = '" & CInt(inACADIDRE) & "' "

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
            MessageBox.Show(Err.Description & " " & "fun_Eliminar_MANT_ACTOADMI")
        End Try

    End Function

    ''' <summary>
    ''' Función que Modifica el registro.
    ''' </summary>
    Public Function fun_Actualizar_MANT_ACTOADMI(ByVal inACADIDRE As Integer, _
                                                 ByVal inACADCODI As Integer, _
                                                 ByVal stACADDESC As String, _
                                                 ByVal stACADESTA As String) As Boolean

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' ACADatena la consulta
            stConsultaSQL += "UPDATE "
            stConsultaSQL += "MANT_ACTOADMI "

            stConsultaSQL += "SET "
            stConsultaSQL += "ACADCODI = '" & CInt(inACADCODI) & "', "
            stConsultaSQL += "ACADDESC = '" & CStr(Trim(stACADDESC)) & "', "
            stConsultaSQL += "ACADESTA = '" & CStr(Trim(stACADESTA)) & "' "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "ACADIDRE = '" & CInt(inACADIDRE) & "'"

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
            MessageBox.Show(Err.Description & " " & "fun_Actualizar_MANT_ACTOADMI")
        End Try

    End Function

    ''' <summary>
    ''' Consulta para llenar el DataGridView y colocar el nombre del encabezado
    ''' de la columna. 
    ''' </summary>
    Public Function fun_Consultar_MANT_ACTOADMI() As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' ACADatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "ACADIDRE, "
            stConsultaSQL += "ACADCODI, "
            stConsultaSQL += "ACADDESC, "
            stConsultaSQL += "ACADESTA  "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MANT_ACTOADMI "

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "ACADCODI "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Consultar_MANT_ACTOADMI")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Llena el ComboBox con datos activos e inactivos formulario principal 
    ''' esta funcion se llama desde el procedimiento "pro_inicializarControles()".
    ''' </summary>
    Public Function fun_Consultar_CAMPOS_MANT_ACTOADMI() As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' ACADatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MANT_ACTOADMI "

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "ACADCODI "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Consultar_CAMPOS_MANT_ACTOADMI")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Llena el ComboBox con datos activos formulario insertar y modificar 
    ''' esta funcion se llama desde el procedimiento "pro_inicializarControles()".
    ''' </summary>
    Public Function fun_Consultar_MANT_ACTOADMI_X_ESTADO() As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' ACADatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MANT_ACTOADMI "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "ACADESTA = 'ac' "

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "ACADCODI "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Consultar_MANT_ACTOADMI_X_ESTADO")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que busca el ID del registro a modificar o eliminar.
    ''' </summary>
    Public Function fun_Buscar_ID_MANT_ACTOADMI(ByVal inACADIDRE As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' ACADatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MANT_ACTOADMI "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "ACADIDRE = '" & CInt(inACADIDRE) & "'"

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Buscar_ID_MANT_ACTOADMI")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que busca el CÓDIGO DE LA CALIDAD DE PROPIETARIO para que no se 
    ''' guarden registros duplicados.
    ''' </summary>
    Public Function fun_Buscar_CODIGO_MANT_ACTOADMI(ByVal inACADCODI As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' ACADatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MANT_ACTOADMI "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "ACADCODI = '" & CInt(inACADCODI) & "'"

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Buscar_CODIGO_MANT_ACTOADMI")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que busca el ID del codigo buscado para ejecutar la consulta
    ''' parametrizada.
    ''' </summary>
    Public Function fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_MANT_ACTOADMI(ByVal inACADIDRE As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' ACADatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "ACADIDRE, "
            stConsultaSQL += "ACADCODI, "
            stConsultaSQL += "ACADDESC, "
            stConsultaSQL += "ACADESTA  "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MANT_ACTOADMI "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "ACADIDRE = '" & CInt(inACADIDRE) & "'"

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "ACADCODI "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception

            MessageBox.Show(Err.Description & " " & "fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_MANT_ACTOADMI")
            Return Nothing

        End Try

    End Function

End Class
