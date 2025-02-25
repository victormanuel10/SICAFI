Imports DATOS

Public Class cla_MEDINOTI

    '=============================
    '*** MEDIO DE NOTIFICACION ***
    '=============================

    ''' <summary>
    ''' procedimiento que verifica la llave primaria.
    ''' </summary>
    Public Function fun_Verifica_llave_Primaria_MANT_MEDINOTI(ByVal obMENOCODI As Object) As Boolean

        Try
            Dim boRespuesta As Boolean = False

            Dim obVerifica As New cla_Verificar_Dato

            If obVerifica.fun_Verificar_Campo_Lleno(obMENOCODI.Text) = True Then
                If obVerifica.fun_Verificar_Dato_Numerico(obMENOCODI.Text) = True Then

                    Dim objdatos1 As New cla_MEDINOTI
                    Dim tbl As New DataTable

                    tbl = objdatos1.fun_Buscar_CODIGO_MANT_MEDINOTI(Trim(obMENOCODI.Text))

                    If tbl.Rows.Count > 0 Then
                        MessageBox.Show("El dato " & obMENOCODI.Text & " del campo " & obMENOCODI.AccessibleDescription & " existe en la base de datos.", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                        obMENOCODI.Focus()
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
    Public Function fun_Insertar_MANT_MEDINOTI(ByVal inMENOCODI As Integer, _
                                               ByVal stMENODESC As String, _
                                               ByVal stMENOESTA As String) As Boolean

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' MENOatena la consulta
            stConsultaSQL += "INSERT INTO "
            stConsultaSQL += "MANT_MEDINOTI "

            stConsultaSQL += "( "
            stConsultaSQL += "MENOCODI, "
            stConsultaSQL += "MENODESC, "
            stConsultaSQL += "MENOESTA "
            stConsultaSQL += ") "

            stConsultaSQL += "VALUES "

            stConsultaSQL += "( "
            stConsultaSQL += "'" & CInt(inMENOCODI) & "', "
            stConsultaSQL += "'" & CStr(Trim(stMENODESC)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stMENOESTA)) & "' "
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
            MessageBox.Show(Err.Description & " " & "fun_Insertar_MANT_MEDINOTI")
        End Try

    End Function

    ''' <summary>
    ''' Función que Elimina el registro.
    ''' </summary>
    Public Function fun_Eliminar_MANT_MEDINOTI(ByVal inMENOIDRE As Integer) As Boolean

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' MENOatena la consulta
            stConsultaSQL += "DELETE "
            stConsultaSQL += "MANT_MEDINOTI "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "MENOIDRE = '" & CInt(inMENOIDRE) & "' "

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
            MessageBox.Show(Err.Description & " " & "fun_Eliminar_MANT_MEDINOTI")
        End Try

    End Function

    ''' <summary>
    ''' Función que Modifica el registro.
    ''' </summary>
    Public Function fun_Actualizar_MANT_MEDINOTI(ByVal inMENOIDRE As Integer, _
                                                 ByVal inMENOCODI As Integer, _
                                                 ByVal stMENODESC As String, _
                                                 ByVal stMENOESTA As String) As Boolean

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' MENOatena la consulta
            stConsultaSQL += "UPDATE "
            stConsultaSQL += "MANT_MEDINOTI "

            stConsultaSQL += "SET "
            stConsultaSQL += "MENOCODI = '" & CInt(inMENOCODI) & "', "
            stConsultaSQL += "MENODESC = '" & CStr(Trim(stMENODESC)) & "', "
            stConsultaSQL += "MENOESTA = '" & CStr(Trim(stMENOESTA)) & "' "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "MENOIDRE = '" & CInt(inMENOIDRE) & "'"

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
            MessageBox.Show(Err.Description & " " & "fun_Actualizar_MANT_MEDINOTI")
        End Try

    End Function

    ''' <summary>
    ''' Consulta para llenar el DataGridView y colocar el nombre del encabezado
    ''' de la columna. 
    ''' </summary>
    Public Function fun_Consultar_MANT_MEDINOTI() As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' MENOatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "MENOIDRE, "
            stConsultaSQL += "MENOCODI, "
            stConsultaSQL += "MENODESC, "
            stConsultaSQL += "MENOESTA  "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MANT_MEDINOTI "

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "MENOCODI "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Consultar_MANT_MEDINOTI")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Llena el ComboBox con datos activos e inactivos formulario principal 
    ''' esta funcion se llama desde el procedimiento "pro_inicializarControles()".
    ''' </summary>
    Public Function fun_Consultar_CAMPOS_MANT_MEDINOTI() As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' MENOatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MANT_MEDINOTI "

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "MENOCODI "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Consultar_CAMPOS_MANT_MEDINOTI")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Llena el ComboBox con datos activos formulario insertar y modificar 
    ''' esta funcion se llama desde el procedimiento "pro_inicializarControles()".
    ''' </summary>
    Public Function fun_Consultar_MANT_MEDINOTI_X_ESTADO() As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' MENOatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MANT_MEDINOTI "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "MENOESTA = 'ac' "

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "MENOCODI "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Consultar_MANT_MEDINOTI_X_ESTADO")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que busca el ID del registro a modificar o eliminar.
    ''' </summary>
    Public Function fun_Buscar_ID_MANT_MEDINOTI(ByVal inMENOIDRE As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' MENOatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MANT_MEDINOTI "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "MENOIDRE = '" & CInt(inMENOIDRE) & "'"

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Buscar_ID_MANT_MEDINOTI")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que busca el CÓDIGO DE LA CALIDAD DE PROPIETARIO para que no se 
    ''' guarden registros duplicados.
    ''' </summary>
    Public Function fun_Buscar_CODIGO_MANT_MEDINOTI(ByVal inMENOCODI As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' MENOatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MANT_MEDINOTI "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "MENOCODI = '" & CInt(inMENOCODI) & "'"

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Buscar_CODIGO_MANT_MEDINOTI")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que busca el ID del codigo buscado para ejecutar la consulta
    ''' parametrizada.
    ''' </summary>
    Public Function fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_MANT_MEDINOTI(ByVal inMENOIDRE As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' MENOatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "MENOIDRE, "
            stConsultaSQL += "MENOCODI, "
            stConsultaSQL += "MENODESC, "
            stConsultaSQL += "MENOESTA  "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MANT_MEDINOTI "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "MENOIDRE = '" & CInt(inMENOIDRE) & "'"

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "MENOCODI "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception

            MessageBox.Show(Err.Description & " " & "fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_MANT_MEDINOTI")
            Return Nothing

        End Try

    End Function

End Class
