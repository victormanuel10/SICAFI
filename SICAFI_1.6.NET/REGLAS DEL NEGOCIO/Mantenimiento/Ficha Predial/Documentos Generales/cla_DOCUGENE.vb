Imports DATOS

Public Class cla_DOCUGENE

    '=============================
    '*** DOCUMENETOS GENERALES ***
    '=============================

    ''' <summary>
    ''' Verifica que verifica la llave primaria.
    ''' </summary>
    Public Function fun_Verifica_llave_Primaria_MANT_DOCUGENE(ByVal obDOGEDEPA As Object, _
                                                              ByVal obDOGEMUNI As Object, _
                                                              ByVal obDOGECODI As Object) As Boolean

        Try
            Dim boRespuesta As Boolean = False

            Dim obVerifica As New cla_Verificar_Dato

            If obVerifica.fun_Verificar_Campo_Lleno(obDOGEDEPA.SelectedValue) = True And _
               obVerifica.fun_Verificar_Campo_Lleno(obDOGEMUNI.SelectedValue) = True And _
               obVerifica.fun_Verificar_Campo_Lleno(obDOGECODI.Text) = True Then

                Dim objdatos1 As New cla_DOCUGENE
                Dim tbl As New DataTable

                tbl = objdatos1.fun_Buscar_CODIGO_MANT_DOCUGENE(Trim(obDOGEDEPA.SelectedValue), Trim(obDOGEMUNI.SelectedValue), Trim(obDOGECODI.Text))

                If tbl.Rows.Count > 0 Then
                    MessageBox.Show("El dato " & obDOGECODI.Text & " del campo " & obDOGECODI.AccessibleDescription & " existe en la base de datos.", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                    obDOGECODI.Focus()
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
    Public Function fun_Insertar_MANT_DOCUGENE(ByVal stDOGEDEPA As String, _
                                               ByVal stDOGEMUNI As String, _
                                               ByVal inDOGECODI As Integer, _
                                               ByVal stDOGEDESC As String, _
                                               ByVal stDOGEESTA As String) As Boolean

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' PROCatena la consulta
            stConsultaSQL += "INSERT INTO "
            stConsultaSQL += "MANT_DOCUGENE "

            stConsultaSQL += "( "
            stConsultaSQL += "DOGEDEPA, "
            stConsultaSQL += "DOGEMUNI, "
            stConsultaSQL += "DOGECODI, "
            stConsultaSQL += "DOGEDESC, "
            stConsultaSQL += "DOGEESTA "
            stConsultaSQL += ") "

            stConsultaSQL += "VALUES "

            stConsultaSQL += "( "
            stConsultaSQL += "'" & CStr(Trim(stDOGEDEPA)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stDOGEMUNI)) & "', "
            stConsultaSQL += "'" & CInt(inDOGECODI) & "', "
            stConsultaSQL += "'" & CStr(Trim(stDOGEDESC)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stDOGEESTA)) & "' "
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
            MessageBox.Show(Err.Description & " " & "fun_Insertar_MANT_DOCUGENE")
        End Try

    End Function

    ''' <summary>
    ''' Función que Elimina el registro.
    ''' </summary>
    Public Function fun_Eliminar_MANT_DOCUGENE(ByVal inDOGEIDRE As Integer) As Boolean

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' PROCatena la consulta
            stConsultaSQL += "DELETE "
            stConsultaSQL += "MANT_DOCUGENE "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "DOGEIDRE = '" & CInt(inDOGEIDRE) & "' "

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
            MessageBox.Show(Err.Description & " " & "fun_Eliminar_MANT_DOCUGENE")
        End Try

    End Function

    ''' <summary>
    ''' Función que Modifica el registro.
    ''' </summary>
    Public Function fun_Actualizar_MANT_DOCUGENE(ByVal inDOGEIDRE As Integer, _
                                                 ByVal stDOGEDEPA As String, _
                                                 ByVal stDOGEMUNI As String, _
                                                 ByVal inDOGECODI As Integer, _
                                                 ByVal stDOGEDESC As String, _
                                                 ByVal stDOGEESTA As String) As Boolean

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' PROCatena la consulta
            stConsultaSQL += "UPDATE "
            stConsultaSQL += "MANT_DOCUGENE "

            stConsultaSQL += "SET "
            stConsultaSQL += "DOGEDEPA = '" & CStr(Trim(stDOGEDEPA)) & "', "
            stConsultaSQL += "DOGEMUNI = '" & CStr(Trim(stDOGEMUNI)) & "', "
            stConsultaSQL += "DOGECODI = '" & CInt(inDOGECODI) & "', "
            stConsultaSQL += "DOGEDESC = '" & CStr(Trim(stDOGEDESC)) & "', "
            stConsultaSQL += "DOGEESTA = '" & CStr(Trim(stDOGEESTA)) & "' "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "DOGEIDRE = '" & CInt(inDOGEIDRE) & "'"

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
            MessageBox.Show(Err.Description & " " & "fun_Actualizar_MANT_DOCUGENE")
        End Try

    End Function

    ''' <summary>
    ''' Consulta para llenar el DataGridView y colocar el nombre del encabezado
    ''' de la columna. 
    ''' </summary>
    Public Function fun_Consultar_MANT_DOCUGENE() As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' PROCatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "DOGEDEPA, "
            stConsultaSQL += "DOGEMUNI, "
            stConsultaSQL += "DOGEIDRE, "
            stConsultaSQL += "DOGECODI, "
            stConsultaSQL += "DOGEDESC, "
            stConsultaSQL += "DOGEESTA  "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MANT_DOCUGENE "

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "DOGECODI "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Consultar_MANT_DOCUGENE")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Llena el ComboBox con datos activos e inactivos formulario principal 
    ''' esta funcion se llama desde el MANT_DOCUGENE "pro_inicializarControles()".
    ''' </summary>
    Public Function fun_Consultar_CAMPOS_MANT_DOCUGENE() As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' PROCatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MANT_DOCUGENE "

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "DOGECODI "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Consultar_CAMPOS_MANT_DOCUGENE")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Llena el ComboBox con datos activos formulario insertar y modificar 
    ''' esta funcion se llama desde el MANT_DOCUGENE "pro_inicializarControles()".
    ''' </summary>
    Public Function fun_Consultar_MANT_DOCUGENE_X_ESTADO() As DataTable

        Try
            Dim boInsertar As Boolean = True

            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' PROCatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MANT_DOCUGENE "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "DOGEESTA = 'ac' "

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "DOGECODI "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Consultar_MANT_DOCUGENE_X_ESTADO")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que busca el ID del registro a modificar o eliminar.
    ''' </summary>
    Public Function fun_Buscar_ID_MANT_DOCUGENE(ByVal inDOGEIDRE As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' PROCatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MANT_DOCUGENE "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "DOGEIDRE = '" & CInt(inDOGEIDRE) & "'"

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Buscar_ID_MANT_DOCUGENE")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que busca el CÓDIGO para que no se 
    ''' guarden registros duplicados.
    ''' </summary>
    Public Function fun_Buscar_CODIGO_MANT_DOCUGENE(ByVal stDOGEDEPA As String, _
                                                    ByVal stDOGEMUNI As String, _
                                                    ByVal inDOGECODI As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' PROCatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MANT_DOCUGENE "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "DOGEDEPA = '" & CStr(Trim(stDOGEDEPA)) & "' AND "
            stConsultaSQL += "DOGEMUNI = '" & CStr(Trim(stDOGEMUNI)) & "' AND "
            stConsultaSQL += "DOGECODI = '" & CInt(inDOGECODI) & "' "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Buscar_CODIGO_MANT_DOCUGENE")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que busca el CÓDIGO para que no se 
    ''' guarden registros duplicados.
    ''' </summary>
    Public Function fun_Buscar_CODIGO_MANT_DOCUGENE(ByVal stDOGEDEPA As String, _
                                                    ByVal stDOGEMUNI As String) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' PROCatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MANT_DOCUGENE "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "DOGEDEPA = '" & CStr(Trim(stDOGEDEPA)) & "' AND "
            stConsultaSQL += "DOGEMUNI = '" & CStr(Trim(stDOGEMUNI)) & "' "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Buscar_CODIGO_MANT_DOCUGENE")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que busca el ID del codigo buscado para ejecutar la consulta
    ''' parametrizada.
    ''' </summary>
    Public Function fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_MANT_DOCUGENE(ByVal inDOGEIDRE As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' PROCatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "DOGEIDRE, "
            stConsultaSQL += "DOGEDEPA, "
            stConsultaSQL += "DOGEMUNI, "
            stConsultaSQL += "DOGECODI, "
            stConsultaSQL += "DOGEDESC, "
            stConsultaSQL += "DOGEESTA  "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MANT_DOCUGENE "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "DOGEIDRE = '" & CInt(inDOGEIDRE) & "'"

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "DOGECODI "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception

            MessageBox.Show(Err.Description & " " & "fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_MANT_DOCUGENE")
            Return Nothing

        End Try

    End Function


End Class
