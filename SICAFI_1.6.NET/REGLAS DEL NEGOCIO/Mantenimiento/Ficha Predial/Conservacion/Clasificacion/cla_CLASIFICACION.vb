Imports DATOS

Public Class cla_CLASIFICACION

    '===========================
    '*** CLASE CLASIFICACION ***
    '===========================

    ''' <summary>
    ''' procedimiento que verifica la llave primaria.
    ''' </summary>
    Public Function fun_Verifica_llave_Primaria_MANT_CLASIFICACION(ByVal obCLASCODI As Object) As Boolean

        Try
            Dim boRespuesta As Boolean = False

            Dim obVerifica As New cla_Verificar_Dato

            If obVerifica.fun_Verificar_Campo_Lleno(obCLASCODI.Text) = True Then
                If obVerifica.fun_Verificar_Dato_Numerico(obCLASCODI.Text) = True Then

                    Dim objdatos1 As New cla_CLASIFICACION
                    Dim tbl As New DataTable

                    tbl = objdatos1.fun_Buscar_CODIGO_MANT_CLASIFICACION(Trim(obCLASCODI.Text))

                    If tbl.Rows.Count > 0 Then
                        MessageBox.Show("El dato " & obCLASCODI.Text & " del campo " & obCLASCODI.AccessibleDescription & " existe en la base de datos.", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                        obCLASCODI.Focus()
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
    Public Function fun_Insertar_MANT_CLASIFICACION(ByVal inCLASCODI As Integer, _
                                                    ByVal stCLASDESC As String, _
                                                    ByVal stCLASESTA As String) As Boolean

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' CLASatena la consulta
            stConsultaSQL += "INSERT INTO "
            stConsultaSQL += "MANT_CLASIFICACION "

            stConsultaSQL += "( "
            stConsultaSQL += "CLASCODI, "
            stConsultaSQL += "CLASDESC, "
            stConsultaSQL += "CLASESTA "
            stConsultaSQL += ") "

            stConsultaSQL += "VALUES "

            stConsultaSQL += "( "
            stConsultaSQL += "'" & CInt(inCLASCODI) & "', "
            stConsultaSQL += "'" & CStr(Trim(stCLASDESC)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stCLASESTA)) & "' "
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
            MessageBox.Show(Err.Description & " " & "fun_Insertar_MANT_CLASIFICACION")
        End Try

    End Function

    ''' <summary>
    ''' Función que Elimina el registro.
    ''' </summary>
    Public Function fun_Eliminar_MANT_CLASIFICACION(ByVal inCLASIDRE As Integer) As Boolean

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' CLASatena la consulta
            stConsultaSQL += "DELETE "
            stConsultaSQL += "MANT_CLASIFICACION "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "CLASIDRE = '" & CInt(inCLASIDRE) & "' "

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
            MessageBox.Show(Err.Description & " " & "fun_Eliminar_MANT_CLASIFICACION")
        End Try

    End Function

    ''' <summary>
    ''' Función que Modifica el registro.
    ''' </summary>
    Public Function fun_Actualizar_MANT_CLASIFICACION(ByVal inCLASIDRE As Integer, _
                                                      ByVal inCLASCODI As Integer, _
                                                      ByVal stCLASDESC As String, _
                                                      ByVal stCLASESTA As String) As Boolean

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' CLASatena la consulta
            stConsultaSQL += "UPDATE "
            stConsultaSQL += "MANT_CLASIFICACION "

            stConsultaSQL += "SET "
            stConsultaSQL += "CLASCODI = '" & CInt(inCLASCODI) & "', "
            stConsultaSQL += "CLASDESC = '" & CStr(Trim(stCLASDESC)) & "', "
            stConsultaSQL += "CLASESTA = '" & CStr(Trim(stCLASESTA)) & "' "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "CLASIDRE = '" & CInt(inCLASIDRE) & "'"

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
            MessageBox.Show(Err.Description & " " & "fun_Actualizar_MANT_CLASIFICACION")
        End Try

    End Function

    ''' <summary>
    ''' Consulta para llenar el DataGridView y colocar el nombre del encabezado
    ''' de la columna. 
    ''' </summary>
    Public Function fun_Consultar_MANT_CLASIFICACION() As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' CLASatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "CLASIDRE, "
            stConsultaSQL += "CLASCODI, "
            stConsultaSQL += "CLASDESC, "
            stConsultaSQL += "CLASESTA  "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MANT_CLASIFICACION "

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "CLASCODI "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Consultar_MANT_CLASIFICACION")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Llena el ComboBox con datos activos e inactivos formulario principal 
    ''' esta funcion se llama desde el procedimiento "pro_inicializarControles()".
    ''' </summary>
    Public Function fun_Consultar_CAMPOS_MANT_CLASIFICACION() As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' CLASatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MANT_CLASIFICACION "

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "CLASCODI "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Consultar_CAMPOS_MANT_CLASIFICACION")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Llena el ComboBox con datos activos formulario insertar y modificar 
    ''' esta funcion se llama desde el procedimiento "pro_inicializarControles()".
    ''' </summary>
    Public Function fun_Consultar_MANT_CLASIFICACION_X_ESTADO() As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' CLASatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MANT_CLASIFICACION "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "CLASESTA = 'ac' "

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "CLASCODI "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Consultar_MANT_CLASIFICACION_X_ESTADO")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que busca el ID del registro a modificar o eliminar.
    ''' </summary>
    Public Function fun_Buscar_ID_MANT_CLASIFICACION(ByVal inCLASIDRE As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' CLASatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MANT_CLASIFICACION "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "CLASIDRE = '" & CInt(inCLASIDRE) & "'"

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Buscar_ID_MANT_CLASIFICACION")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que busca el CÓDIGO DE LA CALIDAD DE PROPIETARIO para que no se 
    ''' guarden registros duplicados.
    ''' </summary>
    Public Function fun_Buscar_CODIGO_MANT_CLASIFICACION(ByVal inCLASCODI As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' CLASatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MANT_CLASIFICACION "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "CLASCODI = '" & CInt(inCLASCODI) & "'"

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Buscar_CODIGO_MANT_CLASIFICACION")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que busca el ID del codigo buscado para ejecutar la consulta
    ''' parametrizada.
    ''' </summary>
    Public Function fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_MANT_CLASIFICACION(ByVal inCLASIDRE As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' CLASatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "CLASIDRE, "
            stConsultaSQL += "CLASCODI, "
            stConsultaSQL += "CLASDESC, "
            stConsultaSQL += "CLASESTA  "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MANT_CLASIFICACION "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "CLASIDRE = '" & CInt(inCLASIDRE) & "'"

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "CLASCODI "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception

            MessageBox.Show(Err.Description & " " & "fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_MANT_CLASIFICACION")
            Return Nothing

        End Try

    End Function


End Class
