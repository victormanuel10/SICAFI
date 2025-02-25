Imports DATOS

Public Class cla_MOBILIARIO

    ' ========================
    ' *** CLASE MOVILIARIO ***
    ' ========================

    ''' <summary>
    ''' MOBILIARIO que verifica la llave primaria.
    ''' </summary>
    Public Function fun_Verifica_llave_Primaria_MOBILIARIO(ByVal obMOBICODI As Object) As Boolean

        Try
            Dim boRespuesta As Boolean = False

            Dim obVerifica As New cla_Verificar_Dato

            If obVerifica.fun_Verificar_Campo_Lleno(obMOBICODI.Text) = True Then

                Dim objdatos1 As New cla_MOBILIARIO
                Dim tbl As New DataTable

                tbl = objdatos1.fun_Buscar_CODIGO_MOBILIARIO(Trim(obMOBICODI.Text))

                If tbl.Rows.Count > 0 Then
                    MessageBox.Show("El dato " & obMOBICODI.Text & " del campo " & obMOBICODI.AccessibleDescription & " existe en la base de datos.", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                    obMOBICODI.Focus()
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
    Public Function fun_Insertar_MOBILIARIO(ByVal inMOBICODI As Integer, _
                                            ByVal stMOBIDESC As String, _
                                            ByVal stMOBIESTA As String) As Boolean

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' PROCatena la consulta
            stConsultaSQL += "INSERT INTO "
            stConsultaSQL += "MOBILIARIO "

            stConsultaSQL += "( "
            stConsultaSQL += "MOBICODI, "
            stConsultaSQL += "MOBIDESC, "
            stConsultaSQL += "MOBIESTA "
            stConsultaSQL += ") "

            stConsultaSQL += "VALUES "

            stConsultaSQL += "( "
            stConsultaSQL += "'" & CInt(inMOBICODI) & "', "
            stConsultaSQL += "'" & CStr(Trim(stMOBIDESC)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stMOBIESTA)) & "' "
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
            MessageBox.Show(Err.Description & " " & "fun_Insertar_MOBILIARIO")
        End Try

    End Function

    ''' <summary>
    ''' Función que Elimina el registro.
    ''' </summary>
    Public Function fun_Eliminar_MOBILIARIO(ByVal inMOBIIDRE As Integer) As Boolean

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' PROCatena la consulta
            stConsultaSQL += "DELETE "
            stConsultaSQL += "MOBILIARIO "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "MOBIIDRE = '" & CInt(inMOBIIDRE) & "' "

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
            MessageBox.Show(Err.Description & " " & "fun_Eliminar_MOBILIARIO")
        End Try

    End Function

    ''' <summary>
    ''' Función que Modifica el registro.
    ''' </summary>
    Public Function fun_Actualizar_MOBILIARIO(ByVal inMOBIIDRE As Integer, _
                                              ByVal inMOBICODI As Integer, _
                                              ByVal stMOBIDESC As String, _
                                              ByVal stMOBIESTA As String) As Boolean

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' PROCatena la consulta
            stConsultaSQL += "UPDATE "
            stConsultaSQL += "MOBILIARIO "

            stConsultaSQL += "SET "
            stConsultaSQL += "MOBICODI = '" & CInt(inMOBICODI) & "', "
            stConsultaSQL += "MOBIDESC = '" & CStr(Trim(stMOBIDESC)) & "', "
            stConsultaSQL += "MOBIESTA = '" & CStr(Trim(stMOBIESTA)) & "' "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "MOBIIDRE = '" & CInt(inMOBIIDRE) & "'"

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
            MessageBox.Show(Err.Description & " " & "fun_Actualizar_MOBILIARIO")
        End Try

    End Function

    ''' <summary>
    ''' Consulta para llenar el DataGridView y colocar el nombre del encabezado
    ''' de la columna. 
    ''' </summary>
    Public Function fun_Consultar_MOBILIARIO() As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' PROCatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "MOBIIDRE, "
            stConsultaSQL += "MOBICODI, "
            stConsultaSQL += "MOBIDESC, "
            stConsultaSQL += "MOBIESTA  "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MOBILIARIO "

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "MOBICODI "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Consultar_MOBILIARIO")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Llena el ComboBox con datos activos e inactivos formulario principal 
    ''' esta funcion se llama desde el MOBILIARIO "pro_inicializarControles()".
    ''' </summary>
    Public Function fun_Consultar_CAMPOS_MOBILIARIO() As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' PROCatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MOBILIARIO "

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "MOBICODI "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Consultar_CAMPOS_MOBILIARIO")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Llena el ComboBox con datos activos formulario insertar y modificar 
    ''' esta funcion se llama desde el MOBILIARIO "pro_inicializarControles()".
    ''' </summary>
    Public Function fun_Consultar_MOBILIARIO_X_ESTADO() As DataTable

        Try
            Dim boInsertar As Boolean = True

            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' PROCatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MOBILIARIO "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "MOBIESTA = 'ac' "

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "MOBICODI "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Consultar_MOBILIARIO_X_ESTADO")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que busca el ID del registro a modificar o eliminar.
    ''' </summary>
    Public Function fun_Buscar_ID_MOBILIARIO(ByVal inMOBIIDRE As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' PROCatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MOBILIARIO "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "MOBIIDRE = '" & CInt(inMOBIIDRE) & "'"

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Buscar_ID_MOBILIARIO")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que busca el CÓDIGO para que no se 
    ''' guarden registros duplicados.
    ''' </summary>
    Public Function fun_Buscar_CODIGO_MOBILIARIO(ByVal inMOBICODI As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' PROCatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MOBILIARIO "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "MOBICODI = '" & CInt(inMOBICODI) & "'"

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Buscar_CODIGO_MOBILIARIO")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que busca el ID del codigo buscado para ejecutar la consulta
    ''' parametrizada.
    ''' </summary>
    Public Function fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_MOBILIARIO(ByVal inMOBIIDRE As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' PROCatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "MOBIIDRE, "
            stConsultaSQL += "MOBICODI, "
            stConsultaSQL += "MOBIDESC, "
            stConsultaSQL += "MOBIESTA  "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MOBILIARIO "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "MOBIIDRE = '" & CInt(inMOBIIDRE) & "'"

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "MOBICODI "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception

            MessageBox.Show(Err.Description & " " & "fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_MOBILIARIO")
            Return Nothing

        End Try

    End Function

End Class
