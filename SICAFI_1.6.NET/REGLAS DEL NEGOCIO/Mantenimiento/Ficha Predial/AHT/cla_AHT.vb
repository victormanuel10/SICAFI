Imports DATOS

Public Class cla_AHT

    ' ===========
    ' *** AHT ***
    ' ===========

    ''' <summary>
    ''' AHTS que verifica la llave primaria.
    ''' </summary>
    Public Function fun_Verifica_llave_Primaria_AHT(ByVal obAHTCODI As Object) As Boolean

        Try
            Dim boRespuesta As Boolean = False

            Dim obVerifica As New cla_Verificar_Dato

            If obVerifica.fun_Verificar_Campo_Lleno(obAHTCODI.Text) = True Then

                Dim objdatos1 As New cla_AHT
                Dim tbl As New DataTable

                tbl = objdatos1.fun_Buscar_CODIGO_AHT(Trim(obAHTCODI.Text))

                If tbl.Rows.Count > 0 Then
                    MessageBox.Show("El dato " & obAHTCODI.Text & " del campo " & obAHTCODI.AccessibleDescription & " existe en la base de datos.", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                    obAHTCODI.Focus()
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
    Public Function fun_Insertar_AHT(ByVal inAHTCODI As Integer, _
                                     ByVal stAHTDESC As String, _
                                     ByVal stAHTESTA As String) As Boolean

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' PROCatena la consulta
            stConsultaSQL += "INSERT INTO "
            stConsultaSQL += "MANT_AHT "

            stConsultaSQL += "( "
            stConsultaSQL += "AHTCODI, "
            stConsultaSQL += "AHTDESC, "
            stConsultaSQL += "AHTESTA "
            stConsultaSQL += ") "

            stConsultaSQL += "VALUES "

            stConsultaSQL += "( "
            stConsultaSQL += "'" & CInt(inAHTCODI) & "', "
            stConsultaSQL += "'" & CStr(Trim(stAHTDESC)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stAHTESTA)) & "' "
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
            MessageBox.Show(Err.Description & " " & "fun_Insertar_AHT")
        End Try

    End Function

    ''' <summary>
    ''' Función que Elimina el registro.
    ''' </summary>
    Public Function fun_Eliminar_AHT(ByVal inAHTIDRE As Integer) As Boolean

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' PROCatena la consulta
            stConsultaSQL += "DELETE "
            stConsultaSQL += "MANT_AHT "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "AHTIDRE = '" & CInt(inAHTIDRE) & "' "

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
            MessageBox.Show(Err.Description & " " & "fun_Eliminar_AHT")
        End Try

    End Function

    ''' <summary>
    ''' Función que Modifica el registro.
    ''' </summary>
    Public Function fun_Actualizar_AHT(ByVal inAHTIDRE As Integer, _
                                       ByVal inAHTCODI As Integer, _
                                       ByVal stAHTDESC As String, _
                                       ByVal stAHTESTA As String) As Boolean

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' PROCatena la consulta
            stConsultaSQL += "UPDATE "
            stConsultaSQL += "MANT_AHT "

            stConsultaSQL += "SET "
            stConsultaSQL += "AHTCODI = '" & CInt(inAHTCODI) & "', "
            stConsultaSQL += "AHTDESC = '" & CStr(Trim(stAHTDESC)) & "', "
            stConsultaSQL += "AHTESTA = '" & CStr(Trim(stAHTESTA)) & "' "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "AHTIDRE = '" & CInt(inAHTIDRE) & "'"

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
            MessageBox.Show(Err.Description & " " & "fun_Actualizar_AHT")
        End Try

    End Function

    ''' <summary>
    ''' Consulta para llenar el DataGridView y colocar el nombre del encabezado
    ''' de la columna. 
    ''' </summary>
    Public Function fun_Consultar_AHT() As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' PROCatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "AHTIDRE, "
            stConsultaSQL += "AHTCODI, "
            stConsultaSQL += "AHTDESC, "
            stConsultaSQL += "AHTESTA  "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MANT_AHT "

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "AHTCODI "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Consultar_AHT")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Llena el ComboBox con datos activos e inactivos formulario principal 
    ''' esta funcion se llama desde el AHTS "pro_inicializarControles()".
    ''' </summary>
    Public Function fun_Consultar_CAMPOS_AHT() As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' PROCatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MANT_AHT "

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "AHTCODI "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Consultar_CAMPOS_AHT")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Llena el ComboBox con datos activos formulario insertar y modificar 
    ''' esta funcion se llama desde el AHTS "pro_inicializarControles()".
    ''' </summary>
    Public Function fun_Consultar_AHT_X_ESTADO() As DataTable

        Try
            Dim boInsertar As Boolean = True

            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' PROCatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MANT_AHT "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "AHTESTA = 'ac' "

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "AHTCODI "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Consultar_AHT_X_ESTADO")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que busca el ID del registro a modificar o eliminar.
    ''' </summary>
    Public Function fun_Buscar_ID_AHT(ByVal inAHTIDRE As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' PROCatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MANT_AHT "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "AHTIDRE = '" & CInt(inAHTIDRE) & "'"

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Buscar_ID_AHT")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que busca el CÓDIGO para que no se 
    ''' guarden registros duplicados.
    ''' </summary>
    Public Function fun_Buscar_CODIGO_AHT(ByVal inAHTCODI As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' PROCatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MANT_AHT "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "AHTCODI = '" & CInt(inAHTCODI) & "'"

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Buscar_CODIGO_AHT")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que busca el ID del codigo buscado para ejecutar la consulta
    ''' parametrizada.
    ''' </summary>
    Public Function fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_AHT(ByVal inAHTIDRE As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' PROCatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "AHTIDRE, "
            stConsultaSQL += "AHTCODI, "
            stConsultaSQL += "AHTDESC, "
            stConsultaSQL += "AHTESTA  "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MANT_AHT "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "AHTIDRE = '" & CInt(inAHTIDRE) & "'"

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "AHTCODI "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception

            MessageBox.Show(Err.Description & " " & "fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_AHT")
            Return Nothing

        End Try

    End Function

End Class
