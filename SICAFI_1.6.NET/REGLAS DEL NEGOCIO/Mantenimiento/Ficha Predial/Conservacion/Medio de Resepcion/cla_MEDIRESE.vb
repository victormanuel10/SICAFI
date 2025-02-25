Imports DATOS

Public Class cla_MEDIRESE

    '==========================
    '*** MEDIO DE RESEPCION ***
    '==========================

    ''' <summary>
    ''' procedimiento que verifica la llave primaria.
    ''' </summary>
    Public Function fun_Verifica_llave_Primaria_MANT_MEDIRESE(ByVal obMERECODI As Object) As Boolean

        Try
            Dim boRespuesta As Boolean = False

            Dim obVerifica As New cla_Verificar_Dato

            If obVerifica.fun_Verificar_Campo_Lleno(obMERECODI.Text) = True Then
                If obVerifica.fun_Verificar_Dato_Numerico(obMERECODI.Text) = True Then

                    Dim objdatos1 As New cla_MEDIRESE
                    Dim tbl As New DataTable

                    tbl = objdatos1.fun_Buscar_CODIGO_MANT_MEDIRESE(Trim(obMERECODI.Text))

                    If tbl.Rows.Count > 0 Then
                        MessageBox.Show("El dato " & obMERECODI.Text & " del campo " & obMERECODI.AccessibleDescription & " existe en la base de datos.", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                        obMERECODI.Focus()
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
    Public Function fun_Insertar_MANT_MEDIRESE(ByVal inMERECODI As Integer, _
                                               ByVal stMEREDESC As String, _
                                               ByVal stMEREESTA As String) As Boolean

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' MEREatena la consulta
            stConsultaSQL += "INSERT INTO "
            stConsultaSQL += "MANT_MEDIRESE "

            stConsultaSQL += "( "
            stConsultaSQL += "MERECODI, "
            stConsultaSQL += "MEREDESC, "
            stConsultaSQL += "MEREESTA "
            stConsultaSQL += ") "

            stConsultaSQL += "VALUES "

            stConsultaSQL += "( "
            stConsultaSQL += "'" & CInt(inMERECODI) & "', "
            stConsultaSQL += "'" & CStr(Trim(stMEREDESC)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stMEREESTA)) & "' "
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
            MessageBox.Show(Err.Description & " " & "fun_Insertar_MANT_MEDIRESE")
        End Try

    End Function

    ''' <summary>
    ''' Función que Elimina el registro.
    ''' </summary>
    Public Function fun_Eliminar_MANT_MEDIRESE(ByVal inMEREIDRE As Integer) As Boolean

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' MEREatena la consulta
            stConsultaSQL += "DELETE "
            stConsultaSQL += "MANT_MEDIRESE "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "MEREIDRE = '" & CInt(inMEREIDRE) & "' "

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
            MessageBox.Show(Err.Description & " " & "fun_Eliminar_MANT_MEDIRESE")
        End Try

    End Function

    ''' <summary>
    ''' Función que Modifica el registro.
    ''' </summary>
    Public Function fun_Actualizar_MANT_MEDIRESE(ByVal inMEREIDRE As Integer, _
                                                 ByVal inMERECODI As Integer, _
                                                 ByVal stMEREDESC As String, _
                                                 ByVal stMEREESTA As String) As Boolean

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' MEREatena la consulta
            stConsultaSQL += "UPDATE "
            stConsultaSQL += "MANT_MEDIRESE "

            stConsultaSQL += "SET "
            stConsultaSQL += "MERECODI = '" & CInt(inMERECODI) & "', "
            stConsultaSQL += "MEREDESC = '" & CStr(Trim(stMEREDESC)) & "', "
            stConsultaSQL += "MEREESTA = '" & CStr(Trim(stMEREESTA)) & "' "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "MEREIDRE = '" & CInt(inMEREIDRE) & "'"

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
            MessageBox.Show(Err.Description & " " & "fun_Actualizar_MANT_MEDIRESE")
        End Try

    End Function

    ''' <summary>
    ''' Consulta para llenar el DataGridView y colocar el nombre del encabezado
    ''' de la columna. 
    ''' </summary>
    Public Function fun_Consultar_MANT_MEDIRESE() As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' MEREatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "MEREIDRE, "
            stConsultaSQL += "MERECODI, "
            stConsultaSQL += "MEREDESC, "
            stConsultaSQL += "MEREESTA  "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MANT_MEDIRESE "

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "MEREDESC "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Consultar_MANT_MEDIRESE")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Llena el ComboBox con datos activos e inactivos formulario principal 
    ''' esta funcion se llama desde el procedimiento "pro_inicializarControles()".
    ''' </summary>
    Public Function fun_Consultar_CAMPOS_MANT_MEDIRESE() As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' MEREatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MANT_MEDIRESE "

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "MEREDESC "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Consultar_CAMPOS_MANT_MEDIRESE")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Llena el ComboBox con datos activos formulario insertar y modificar 
    ''' esta funcion se llama desde el procedimiento "pro_inicializarControles()".
    ''' </summary>
    Public Function fun_Consultar_MANT_MEDIRESE_X_ESTADO() As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' MEREatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MANT_MEDIRESE "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "MEREESTA = 'ac' "

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "MEREDESC "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Consultar_MANT_MEDIRESE_X_ESTADO")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que busca el ID del registro a modificar o eliminar.
    ''' </summary>
    Public Function fun_Buscar_ID_MANT_MEDIRESE(ByVal inMEREIDRE As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' MEREatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MANT_MEDIRESE "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "MEREIDRE = '" & CInt(inMEREIDRE) & "'"

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Buscar_ID_MANT_MEDIRESE")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que busca el CÓDIGO DE LA CALIDAD DE PROPIETARIO para que no se 
    ''' guarden registros duplicados.
    ''' </summary>
    Public Function fun_Buscar_CODIGO_MANT_MEDIRESE(ByVal inMERECODI As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' MEREatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MANT_MEDIRESE "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "MERECODI = '" & CInt(inMERECODI) & "'"

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Buscar_CODIGO_MANT_MEDIRESE")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que busca el ID del codigo buscado para ejecutar la consulta
    ''' parametrizada.
    ''' </summary>
    Public Function fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_MANT_MEDIRESE(ByVal inMEREIDRE As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' MEREatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "MEREIDRE, "
            stConsultaSQL += "MERECODI, "
            stConsultaSQL += "MEREDESC, "
            stConsultaSQL += "MEREESTA  "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MANT_MEDIRESE "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "MEREIDRE = '" & CInt(inMEREIDRE) & "'"

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "MEREDESC "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception

            MessageBox.Show(Err.Description & " " & "fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_MANT_MEDIRESE")
            Return Nothing

        End Try

    End Function

End Class
