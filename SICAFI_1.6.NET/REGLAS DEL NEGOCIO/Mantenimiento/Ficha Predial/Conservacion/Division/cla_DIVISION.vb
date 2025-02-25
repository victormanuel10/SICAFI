Imports DATOS

Public Class cla_DIVISION

    '================
    '*** DIVISION ***
    '================

    ''' <summary>
    ''' procedimiento que verifica la llave primaria.
    ''' </summary>
    Public Function fun_Verifica_llave_Primaria_MANT_DIVISION(ByVal obDIVICODI As Object) As Boolean

        Try
            Dim boRespuesta As Boolean = False

            Dim obVerifica As New cla_Verificar_Dato

            If obVerifica.fun_Verificar_Campo_Lleno(obDIVICODI.Text) = True Then
                If obVerifica.fun_Verificar_Dato_Numerico(obDIVICODI.Text) = True Then

                    Dim objdatos1 As New cla_DIVISION
                    Dim tbl As New DataTable

                    tbl = objdatos1.fun_Buscar_CODIGO_MANT_DIVISION(Trim(obDIVICODI.Text))

                    If tbl.Rows.Count > 0 Then
                        MessageBox.Show("El dato " & obDIVICODI.Text & " del campo " & obDIVICODI.AccessibleDescription & " existe en la base de datos.", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                        obDIVICODI.Focus()
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
    Public Function fun_Insertar_MANT_DIVISION(ByVal inDIVICODI As Integer, _
                                               ByVal stDIVIDESC As String, _
                                               ByVal stDIVIESTA As String) As Boolean

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' DIVIatena la consulta
            stConsultaSQL += "INSERT INTO "
            stConsultaSQL += "MANT_DIVISION "

            stConsultaSQL += "( "
            stConsultaSQL += "DIVICODI, "
            stConsultaSQL += "DIVIDESC, "
            stConsultaSQL += "DIVIESTA "
            stConsultaSQL += ") "

            stConsultaSQL += "VALUES "

            stConsultaSQL += "( "
            stConsultaSQL += "'" & CInt(inDIVICODI) & "', "
            stConsultaSQL += "'" & CStr(Trim(stDIVIDESC)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stDIVIESTA)) & "' "
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
            MessageBox.Show(Err.Description & " " & "fun_Insertar_MANT_DIVISION")
        End Try

    End Function

    ''' <summary>
    ''' Función que Elimina el registro.
    ''' </summary>
    Public Function fun_Eliminar_MANT_DIVISION(ByVal inDIVIIDRE As Integer) As Boolean

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' DIVIatena la consulta
            stConsultaSQL += "DELETE "
            stConsultaSQL += "MANT_DIVISION "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "DIVIIDRE = '" & CInt(inDIVIIDRE) & "' "

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
            MessageBox.Show(Err.Description & " " & "fun_Eliminar_MANT_DIVISION")
        End Try

    End Function

    ''' <summary>
    ''' Función que Modifica el registro.
    ''' </summary>
    Public Function fun_Actualizar_MANT_DIVISION(ByVal inDIVIIDRE As Integer, _
                                                 ByVal inDIVICODI As Integer, _
                                                 ByVal stDIVIDESC As String, _
                                                 ByVal stDIVIESTA As String) As Boolean

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' DIVIatena la consulta
            stConsultaSQL += "UPDATE "
            stConsultaSQL += "MANT_DIVISION "

            stConsultaSQL += "SET "
            stConsultaSQL += "DIVICODI = '" & CInt(inDIVICODI) & "', "
            stConsultaSQL += "DIVIDESC = '" & CStr(Trim(stDIVIDESC)) & "', "
            stConsultaSQL += "DIVIESTA = '" & CStr(Trim(stDIVIESTA)) & "' "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "DIVIIDRE = '" & CInt(inDIVIIDRE) & "'"

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
            MessageBox.Show(Err.Description & " " & "fun_Actualizar_MANT_DIVISION")
        End Try

    End Function

    ''' <summary>
    ''' Consulta para llenar el DataGridView y colocar el nombre del encabezado
    ''' de la columna. 
    ''' </summary>
    Public Function fun_Consultar_MANT_DIVISION() As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' DIVIatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "DIVIIDRE, "
            stConsultaSQL += "DIVICODI, "
            stConsultaSQL += "DIVIDESC, "
            stConsultaSQL += "DIVIESTA  "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MANT_DIVISION "

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "DIVIDESC "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Consultar_MANT_DIVISION")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Llena el ComboBox con datos activos e inactivos formulario principal 
    ''' esta funcion se llama desde el procedimiento "pro_inicializarControles()".
    ''' </summary>
    Public Function fun_Consultar_CAMPOS_MANT_DIVISION() As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' DIVIatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MANT_DIVISION "

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "DIVIDESC "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Consultar_CAMPOS_MANT_DIVISION")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Llena el ComboBox con datos activos formulario insertar y modificar 
    ''' esta funcion se llama desde el procedimiento "pro_inicializarControles()".
    ''' </summary>
    Public Function fun_Consultar_MANT_DIVISION_X_ESTADO() As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' DIVIatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MANT_DIVISION "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "DIVIESTA = 'ac' "

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "DIVIDESC "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Consultar_MANT_DIVISION_X_ESTADO")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que busca el ID del registro a modificar o eliminar.
    ''' </summary>
    Public Function fun_Buscar_ID_MANT_DIVISION(ByVal inDIVIIDRE As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' DIVIatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MANT_DIVISION "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "DIVIIDRE = '" & CInt(inDIVIIDRE) & "'"

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Buscar_ID_MANT_DIVISION")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que busca el CÓDIGO DE LA CALIDAD DE PROPIETARIO para que no se 
    ''' guarden registros duplicados.
    ''' </summary>
    Public Function fun_Buscar_CODIGO_MANT_DIVISION(ByVal inDIVICODI As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' DIVIatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MANT_DIVISION "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "DIVICODI = '" & CInt(inDIVICODI) & "'"

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Buscar_CODIGO_MANT_DIVISION")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que busca el ID del codigo buscado para ejecutar la consulta
    ''' parametrizada.
    ''' </summary>
    Public Function fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_MANT_DIVISION(ByVal inDIVIIDRE As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' DIVIatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "DIVIIDRE, "
            stConsultaSQL += "DIVICODI, "
            stConsultaSQL += "DIVIDESC, "
            stConsultaSQL += "DIVIESTA  "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MANT_DIVISION "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "DIVIIDRE = '" & CInt(inDIVIIDRE) & "'"

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "DIVIDESC "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception

            MessageBox.Show(Err.Description & " " & "fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_MANT_DIVISION")
            Return Nothing

        End Try

    End Function

End Class
