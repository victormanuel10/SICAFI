Imports DATOS

Public Class cla_ESTACIVI

    '====================
    '*** ESTADO CIVIL ***
    '====================

    ''' <summary>
    ''' procedimiento que verifica la llave primaria.
    ''' </summary>
    Public Function fun_Verifica_llave_Primaria_MANT_ESTACIVI(ByVal obESCICODI As Object) As Boolean

        Try
            Dim boRespuesta As Boolean = False

            Dim obVerifica As New cla_Verificar_Dato

            If obVerifica.fun_Verificar_Campo_Lleno(obESCICODI.Text) = True Then
                If obVerifica.fun_Verificar_Dato_Numerico(obESCICODI.Text) = True Then

                    Dim objdatos1 As New cla_ESTACIVI
                    Dim tbl As New DataTable

                    tbl = objdatos1.fun_Buscar_CODIGO_MANT_ESTACIVI(Trim(obESCICODI.Text))

                    If tbl.Rows.Count > 0 Then
                        MessageBox.Show("El dato " & obESCICODI.Text & " del campo " & obESCICODI.AccessibleDescription & " existe en la base de datos.", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                        obESCICODI.Focus()
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
    Public Function fun_Insertar_MANT_ESTACIVI(ByVal inESCICODI As Integer, _
                                               ByVal stESCIDESC As String, _
                                               ByVal stESCIESTA As String) As Boolean

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' TITRatena la consulta
            stConsultaSQL += "INSERT INTO "
            stConsultaSQL += "MANT_ESTACIVI "

            stConsultaSQL += "( "
            stConsultaSQL += "ESCICODI, "
            stConsultaSQL += "ESCIDESC, "
            stConsultaSQL += "ESCIESTA "
            stConsultaSQL += ") "

            stConsultaSQL += "VALUES "

            stConsultaSQL += "( "
            stConsultaSQL += "'" & CInt(inESCICODI) & "', "
            stConsultaSQL += "'" & CStr(Trim(stESCIDESC)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stESCIESTA)) & "' "
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
            MessageBox.Show(Err.Description & " " & "fun_Insertar_MANT_ESTACIVI")
        End Try

    End Function

    ''' <summary>
    ''' Función que Elimina el registro.
    ''' </summary>
    Public Function fun_Eliminar_MANT_ESTACIVI(ByVal inESCIIDRE As Integer) As Boolean

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' TITRatena la consulta
            stConsultaSQL += "DELETE "
            stConsultaSQL += "MANT_ESTACIVI "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "ESCIIDRE = '" & CInt(inESCIIDRE) & "' "

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
            MessageBox.Show(Err.Description & " " & "fun_Eliminar_MANT_ESTACIVI")
        End Try

    End Function

    ''' <summary>
    ''' Función que Modifica el registro.
    ''' </summary>
    Public Function fun_Actualizar_MANT_ESTACIVI(ByVal inESCIIDRE As Integer, _
                                                 ByVal inESCICODI As Integer, _
                                                 ByVal stESCIDESC As String, _
                                                 ByVal stESCIESTA As String) As Boolean

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' TITRatena la consulta
            stConsultaSQL += "UPDATE "
            stConsultaSQL += "MANT_ESTACIVI "

            stConsultaSQL += "SET "
            stConsultaSQL += "ESCICODI = '" & CInt(inESCICODI) & "', "
            stConsultaSQL += "ESCIDESC = '" & CStr(Trim(stESCIDESC)) & "', "
            stConsultaSQL += "ESCIESTA = '" & CStr(Trim(stESCIESTA)) & "' "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "ESCIIDRE = '" & CInt(inESCIIDRE) & "'"

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
            MessageBox.Show(Err.Description & " " & "fun_Actualizar_MANT_ESTACIVI")
        End Try

    End Function

    ''' <summary>
    ''' Consulta para llenar el DataGridView y colocar el nombre del encabezado
    ''' de la columna. 
    ''' </summary>
    Public Function fun_Consultar_MANT_ESTACIVI() As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' TITRatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "ESCIIDRE, "
            stConsultaSQL += "ESCICODI, "
            stConsultaSQL += "ESCIDESC, "
            stConsultaSQL += "ESCIESTA  "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MANT_ESTACIVI "

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "ESCICODI "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Consultar_MANT_ESTACIVI")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Llena el ComboBox con datos activos e inactivos formulario principal 
    ''' esta funcion se llama desde el procedimiento "pro_inicializarControles()".
    ''' </summary>
    Public Function fun_Consultar_CAMPOS_MANT_ESTACIVI() As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' TITRatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MANT_ESTACIVI "

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "ESCICODI "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Consultar_CAMPOS_MANT_ESTACIVI")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Llena el ComboBox con datos activos formulario insertar y modificar 
    ''' esta funcion se llama desde el procedimiento "pro_inicializarControles()".
    ''' </summary>
    Public Function fun_Consultar_MANT_ESTACIVI_X_ESTADO() As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' TITRatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MANT_ESTACIVI "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "ESCIESTA = 'ac' "

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "ESCICODI "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Consultar_MANT_ESTACIVI_X_ESTADO")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que busca el ID del registro a modificar o eliminar.
    ''' </summary>
    Public Function fun_Buscar_ID_MANT_ESTACIVI(ByVal inESCIIDRE As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' TITRatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MANT_ESTACIVI "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "ESCIIDRE = '" & CInt(inESCIIDRE) & "'"

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Buscar_ID_MANT_ESTACIVI")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que busca el CÓDIGO DE LA CALIDAD DE PROPIETARIO para que no se 
    ''' guarden registros duplicados.
    ''' </summary>
    Public Function fun_Buscar_CODIGO_MANT_ESTACIVI(ByVal inESCICODI As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' TITRatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MANT_ESTACIVI "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "ESCICODI = '" & CInt(inESCICODI) & "'"

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Buscar_CODIGO_MANT_ESTACIVI")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que busca el ID del codigo buscado para ejecutar la consulta
    ''' parametrizada.
    ''' </summary>
    Public Function fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_MANT_ESTACIVI(ByVal inESCIIDRE As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' TITRatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "ESCIIDRE, "
            stConsultaSQL += "ESCICODI, "
            stConsultaSQL += "ESCIDESC, "
            stConsultaSQL += "ESCIESTA  "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MANT_ESTACIVI "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "ESCIIDRE = '" & CInt(inESCIIDRE) & "'"

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "ESCICODI "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception

            MessageBox.Show(Err.Description & " " & "fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_MANT_ESTACIVI")
            Return Nothing

        End Try

    End Function

End Class
