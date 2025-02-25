Imports DATOS

Public Class cla_SERVICIOS

    ' =================
    ' *** SERVICIOS ***
    ' =================

    ''' <summary>
    ''' MANT_SERVICIOS que verifica la llave primaria.
    ''' </summary>
    Public Function fun_Verifica_llave_Primaria_MANT_SERVICIOS(ByVal obSERVCODI As Object) As Boolean

        Try
            Dim boRespuesta As Boolean = False

            Dim obVerifica As New cla_Verificar_Dato

            If obVerifica.fun_Verificar_Campo_Lleno(obSERVCODI.Text) = True Then

                Dim objdatos1 As New cla_SERVICIOS
                Dim tbl As New DataTable

                tbl = objdatos1.fun_Buscar_CODIGO_MANT_SERVICIOS(Trim(obSERVCODI.Text))

                If tbl.Rows.Count > 0 Then
                    MessageBox.Show("El dato " & obSERVCODI.Text & " del campo " & obSERVCODI.AccessibleDescription & " existe en la base de datos.", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                    obSERVCODI.Focus()
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
    Public Function fun_Insertar_MANT_SERVICIOS(ByVal inSERVCODI As Integer, _
                                                ByVal stSERVDESC As String, _
                                                ByVal stSERVESTA As String) As Boolean

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' PROCatena la consulta
            stConsultaSQL += "INSERT INTO "
            stConsultaSQL += "MANT_SERVICIOS "

            stConsultaSQL += "( "
            stConsultaSQL += "SERVCODI, "
            stConsultaSQL += "SERVDESC, "
            stConsultaSQL += "SERVESTA "
            stConsultaSQL += ") "

            stConsultaSQL += "VALUES "

            stConsultaSQL += "( "
            stConsultaSQL += "'" & CInt(inSERVCODI) & "', "
            stConsultaSQL += "'" & CStr(Trim(stSERVDESC)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stSERVESTA)) & "' "
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
            MessageBox.Show(Err.Description & " " & "fun_Insertar_MANT_SERVICIOS")
        End Try

    End Function

    ''' <summary>
    ''' Función que Elimina el registro.
    ''' </summary>
    Public Function fun_Eliminar_MANT_SERVICIOS(ByVal inSERVIDRE As Integer) As Boolean

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' PROCatena la consulta
            stConsultaSQL += "DELETE "
            stConsultaSQL += "MANT_SERVICIOS "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "SERVIDRE = '" & CInt(inSERVIDRE) & "' "

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
            MessageBox.Show(Err.Description & " " & "fun_Eliminar_MANT_SERVICIOS")
        End Try

    End Function

    ''' <summary>
    ''' Función que Modifica el registro.
    ''' </summary>
    Public Function fun_Actualizar_MANT_SERVICIOS(ByVal inSERVIDRE As Integer, _
                                                  ByVal inSERVCODI As Integer, _
                                                  ByVal stSERVDESC As String, _
                                                  ByVal stSERVESTA As String) As Boolean

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' PROCatena la consulta
            stConsultaSQL += "UPDATE "
            stConsultaSQL += "MANT_SERVICIOS "

            stConsultaSQL += "SET "
            stConsultaSQL += "SERVCODI = '" & CInt(inSERVCODI) & "', "
            stConsultaSQL += "SERVDESC = '" & CStr(Trim(stSERVDESC)) & "', "
            stConsultaSQL += "SERVESTA = '" & CStr(Trim(stSERVESTA)) & "' "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "SERVIDRE = '" & CInt(inSERVIDRE) & "'"

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
            MessageBox.Show(Err.Description & " " & "fun_Actualizar_MANT_SERVICIOS")
        End Try

    End Function

    ''' <summary>
    ''' Consulta para llenar el DataGridView y colocar el nombre del encabezado
    ''' de la columna. 
    ''' </summary>
    Public Function fun_Consultar_MANT_SERVICIOS() As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' PROCatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "SERVIDRE, "
            stConsultaSQL += "SERVCODI, "
            stConsultaSQL += "SERVDESC, "
            stConsultaSQL += "SERVESTA  "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MANT_SERVICIOS "

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "SERVCODI "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Consultar_MANT_SERVICIOS")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Llena el ComboBox con datos activos e inactivos formulario principal 
    ''' esta funcion se llama desde el MANT_SERVICIOS "pro_inicializarControles()".
    ''' </summary>
    Public Function fun_Consultar_CAMPOS_MANT_SERVICIOS() As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' PROCatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MANT_SERVICIOS "

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "SERVCODI "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Consultar_CAMPOS_MANT_SERVICIOS")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Llena el ComboBox con datos activos formulario insertar y modificar 
    ''' esta funcion se llama desde el MANT_SERVICIOS "pro_inicializarControles()".
    ''' </summary>
    Public Function fun_Consultar_MANT_SERVICIOS_X_ESTADO() As DataTable

        Try
            Dim boInsertar As Boolean = True

            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' PROCatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MANT_SERVICIOS "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "SERVESTA = 'ac' "

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "SERVCODI "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Consultar_MANT_SERVICIOS_X_ESTADO")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que busca el ID del registro a modificar o eliminar.
    ''' </summary>
    Public Function fun_Buscar_ID_MANT_SERVICIOS(ByVal inSERVIDRE As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' PROCatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MANT_SERVICIOS "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "SERVIDRE = '" & CInt(inSERVIDRE) & "'"

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Buscar_ID_MANT_SERVICIOS")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que busca el CÓDIGO para que no se 
    ''' guarden registros duplicados.
    ''' </summary>
    Public Function fun_Buscar_CODIGO_MANT_SERVICIOS(ByVal inSERVCODI As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' PROCatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MANT_SERVICIOS "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "SERVCODI = '" & CInt(inSERVCODI) & "'"

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Buscar_CODIGO_MANT_SERVICIOS")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que busca el ID del codigo buscado para ejecutar la consulta
    ''' parametrizada.
    ''' </summary>
    Public Function fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_MANT_SERVICIOS(ByVal inSERVIDRE As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' PROCatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "SERVIDRE, "
            stConsultaSQL += "SERVCODI, "
            stConsultaSQL += "SERVDESC, "
            stConsultaSQL += "SERVESTA  "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MANT_SERVICIOS "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "SERVIDRE = '" & CInt(inSERVIDRE) & "'"

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "SERVCODI "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception

            MessageBox.Show(Err.Description & " " & "fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_MANT_SERVICIOS")
            Return Nothing

        End Try

    End Function

End Class
