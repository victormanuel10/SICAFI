Imports DATOS

Public Class cla_SALAMINI

    '============================================
    '*** SALARIO MINIMO MENSUAL LEGAL VIGENTE ***
    '============================================

    ''' <summary>
    ''' SALAMINI que verifica la llave primaria.
    ''' </summary>
    Public Function fun_Verifica_llave_Primaria_SALAMINI(ByVal obSAMIVIGE As Object) As Boolean

        Try
            Dim boRespuesta As Boolean = False

            Dim obVerifica As New cla_Verificar_Dato

            If obVerifica.fun_Verificar_Campo_Lleno(obSAMIVIGE.SelectedValue) = True Then

                Dim objdatos1 As New cla_SALAMINI
                Dim tbl As New DataTable

                tbl = objdatos1.fun_Buscar_CODIGO_SALAMINI(Trim(obSAMIVIGE.SelectedValue))

                If tbl.Rows.Count > 0 Then
                    MessageBox.Show("El dato " & obSAMIVIGE.Text & " del campo " & obSAMIVIGE.AccessibleDescription & " existe en la base de datos.", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                    obSAMIVIGE.Focus()
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
    Public Function fun_Insertar_SALAMINI(ByVal inSAMISAMI As Integer, _
                                               ByVal inSAMIVIGE As Integer, _
                                               ByVal stSAMIDESC As String, _
                                               ByVal stSAMIESTA As String) As Boolean

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' PROCatena la consulta
            stConsultaSQL += "INSERT INTO "
            stConsultaSQL += "SALAMINI "

            stConsultaSQL += "( "
            stConsultaSQL += "SAMISAMI, "
            stConsultaSQL += "SAMIVIGE, "
            stConsultaSQL += "SAMIDESC, "
            stConsultaSQL += "SAMIESTA "
            stConsultaSQL += ") "

            stConsultaSQL += "VALUES "

            stConsultaSQL += "( "
            stConsultaSQL += "'" & CInt(inSAMISAMI) & "', "
            stConsultaSQL += "'" & CInt(inSAMIVIGE) & "', "
            stConsultaSQL += "'" & CStr(Trim(stSAMIDESC)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stSAMIESTA)) & "' "
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
            MessageBox.Show(Err.Description & " " & "fun_Insertar_SALAMINI")
        End Try

    End Function

    ''' <summary>
    ''' Función que Elimina el registro.
    ''' </summary>
    Public Function fun_Eliminar_SALAMINI(ByVal inSAMIIDRE As Integer) As Boolean

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' PROCatena la consulta
            stConsultaSQL += "DELETE "
            stConsultaSQL += "SALAMINI "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "SAMIIDRE = '" & CInt(inSAMIIDRE) & "' "

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
            MessageBox.Show(Err.Description & " " & "fun_Eliminar_SALAMINI")
        End Try

    End Function

    ''' <summary>
    ''' Función que Modifica el registro.
    ''' </summary>
    Public Function fun_Actualizar_SALAMINI(ByVal inSAMIIDRE As Integer, _
                                            ByVal inSAMISAMI As Integer, _
                                            ByVal inSAMIVIGE As Integer, _
                                            ByVal stSAMIDESC As String, _
                                            ByVal stSAMIESTA As String) As Boolean

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' PROCatena la consulta
            stConsultaSQL += "UPDATE "
            stConsultaSQL += "SALAMINI "

            stConsultaSQL += "SET "
            stConsultaSQL += "SAMISAMI = '" & CInt(inSAMISAMI) & "', "
            stConsultaSQL += "SAMIVIGE = '" & CInt(inSAMIVIGE) & "', "
            stConsultaSQL += "SAMIDESC = '" & CStr(Trim(stSAMIDESC)) & "', "
            stConsultaSQL += "SAMIESTA = '" & CStr(Trim(stSAMIESTA)) & "' "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "SAMIIDRE = '" & CInt(inSAMIIDRE) & "'"

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
            MessageBox.Show(Err.Description & " " & "fun_Actualizar_SALAMINI")
        End Try

    End Function

    ''' <summary>
    ''' Consulta para llenar el DataGridView y colocar el nombre del encabezado
    ''' de la columna. 
    ''' </summary>
    Public Function fun_Consultar_SALAMINI() As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' PROCatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "SAMIIDRE, "
            stConsultaSQL += "SAMISAMI, "
            stConsultaSQL += "SAMIVIGE, "
            stConsultaSQL += "VIGEDESC, "
            stConsultaSQL += "SAMIDESC, "
            stConsultaSQL += "SAMIESTA, "
            stConsultaSQL += "ESTADESC "

            stConsultaSQL += "FROM "
            stConsultaSQL += "SALAMINI, VIGENCIA, ESTADO "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "SAMIVIGE = VIGECODI AND "
            stConsultaSQL += "SAMIESTA = ESTACODI "

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "SAMIVIGE "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Consultar_SALAMINI")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Llena el ComboBox con datos activos e inactivos formulario principal 
    ''' esta funcion se llama desde el SALAMINI "pro_inicializarControles()".
    ''' </summary>
    Public Function fun_Consultar_CAMPOS_SALAMINI() As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' PROCatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "SALAMINI "

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "SAMIVIGE "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Consultar_CAMPOS_SALAMINI")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Llena el ComboBox con datos activos formulario insertar y modificar 
    ''' esta funcion se llama desde el SALAMINI "pro_inicializarControles()".
    ''' </summary>
    Public Function fun_Consultar_SALAMINI_X_ESTADO() As DataTable

        Try
            Dim boInsertar As Boolean = True

            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' PROCatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "SALAMINI "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "SAMIESTA = 'ac' "

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "SAMIVIGE "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Consultar_SALAMINI_X_ESTADO")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que busca el ID del registro a modificar o eliminar.
    ''' </summary>
    Public Function fun_Buscar_ID_SALAMINI(ByVal inSAMIIDRE As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' PROCatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "SALAMINI "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "SAMIIDRE = '" & CInt(inSAMIIDRE) & "'"

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Buscar_ID_SALAMINI")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que busca el CÓDIGO para que no se 
    ''' guarden registros duplicados.
    ''' </summary>
    Public Function fun_Buscar_CODIGO_SALAMINI(ByVal inSAMIVIGE As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' PROCatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "SALAMINI "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "SAMIVIGE = '" & CInt(inSAMIVIGE) & "'"

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Buscar_CODIGO_SALAMINI")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que busca el ID del codigo buscado para ejecutar la consulta
    ''' parametrizada.
    ''' </summary>
    Public Function fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_SALAMINI(ByVal inSAMIIDRE As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' PROCatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "SAMIIDRE, "
            stConsultaSQL += "SAMISAMI, "
            stConsultaSQL += "SAMIVIGE, "
            stConsultaSQL += "VIGEDESC, "
            stConsultaSQL += "SAMIDESC, "
            stConsultaSQL += "SAMIESTA, "
            stConsultaSQL += "ESTADESC  "

            stConsultaSQL += "FROM "
            stConsultaSQL += "SALAMINI, VIGENCIA, ESTADO "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "SAMIVIGE = VIGECODI AND "
            stConsultaSQL += "SAMIESTA = ESTACODI AND "
            stConsultaSQL += "SAMIIDRE = '" & CInt(inSAMIIDRE) & "'"

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "SAMIVIGE "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception

            MessageBox.Show(Err.Description & " " & "fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_SALAMINI")
            Return Nothing

        End Try

    End Function


End Class
