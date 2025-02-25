Imports DATOS

Public Class cla_TOPOGRAFIA

    ' =========================
    ' *** TRATAMIENTOS VIAS ***
    ' =========================

    ''' <summary>
    ''' MANT_TOPOGRAFIA que verifica la llave primaria.
    ''' </summary>
    Public Function fun_Verifica_llave_Primaria_MANT_TOPOGRAFIA(ByVal obTOPOCODI As Object) As Boolean

        Try
            Dim boRespuesta As Boolean = False

            Dim obVerifica As New cla_Verificar_Dato

            If obVerifica.fun_Verificar_Campo_Lleno(obTOPOCODI.Text) = True Then

                Dim objdatos1 As New cla_TOPOGRAFIA
                Dim tbl As New DataTable

                tbl = objdatos1.fun_Buscar_CODIGO_MANT_TOPOGRAFIA(Trim(obTOPOCODI.Text))

                If tbl.Rows.Count > 0 Then
                    MessageBox.Show("El dato " & obTOPOCODI.Text & " del campo " & obTOPOCODI.AccessibleDescription & " existe en la base de datos.", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                    obTOPOCODI.Focus()
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
    Public Function fun_Insertar_MANT_TOPOGRAFIA(ByVal inTOPOCODI As Integer, _
                                                 ByVal stTOPODESC As String, _
                                                 ByVal stTOPOESTA As String) As Boolean

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' PROCatena la consulta
            stConsultaSQL += "INSERT INTO "
            stConsultaSQL += "MANT_TOPOGRAFIA "

            stConsultaSQL += "( "
            stConsultaSQL += "TOPOCODI, "
            stConsultaSQL += "TOPODESC, "
            stConsultaSQL += "TOPOESTA "
            stConsultaSQL += ") "

            stConsultaSQL += "VALUES "

            stConsultaSQL += "( "
            stConsultaSQL += "'" & CInt(inTOPOCODI) & "', "
            stConsultaSQL += "'" & CStr(Trim(stTOPODESC)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stTOPOESTA)) & "' "
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
            MessageBox.Show(Err.Description & " " & "fun_Insertar_MANT_TOPOGRAFIA")
        End Try

    End Function

    ''' <summary>
    ''' Función que Elimina el registro.
    ''' </summary>
    Public Function fun_Eliminar_MANT_TOPOGRAFIA(ByVal inTOPOIDRE As Integer) As Boolean

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' PROCatena la consulta
            stConsultaSQL += "DELETE "
            stConsultaSQL += "MANT_TOPOGRAFIA "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "TOPOIDRE = '" & CInt(inTOPOIDRE) & "' "

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
            MessageBox.Show(Err.Description & " " & "fun_Eliminar_MANT_TOPOGRAFIA")
        End Try

    End Function

    ''' <summary>
    ''' Función que Modifica el registro.
    ''' </summary>
    Public Function fun_Actualizar_MANT_TOPOGRAFIA(ByVal inTOPOIDRE As Integer, _
                                                   ByVal inTOPOCODI As Integer, _
                                                   ByVal stTOPODESC As String, _
                                                   ByVal stTOPOESTA As String) As Boolean

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' PROCatena la consulta
            stConsultaSQL += "UPDATE "
            stConsultaSQL += "MANT_TOPOGRAFIA "

            stConsultaSQL += "SET "
            stConsultaSQL += "TOPOCODI = '" & CInt(inTOPOCODI) & "', "
            stConsultaSQL += "TOPODESC = '" & CStr(Trim(stTOPODESC)) & "', "
            stConsultaSQL += "TOPOESTA = '" & CStr(Trim(stTOPOESTA)) & "' "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "TOPOIDRE = '" & CInt(inTOPOIDRE) & "'"

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
            MessageBox.Show(Err.Description & " " & "fun_Actualizar_MANT_TOPOGRAFIA")
        End Try

    End Function

    ''' <summary>
    ''' Consulta para llenar el DataGridView y colocar el nombre del encabezado
    ''' de la columna. 
    ''' </summary>
    Public Function fun_Consultar_MANT_TOPOGRAFIA() As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' PROCatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "TOPOIDRE, "
            stConsultaSQL += "TOPOCODI, "
            stConsultaSQL += "TOPODESC, "
            stConsultaSQL += "TOPOESTA  "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MANT_TOPOGRAFIA "

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "TOPOCODI "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Consultar_MANT_TOPOGRAFIA")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Llena el ComboBox con datos activos e inactivos formulario principal 
    ''' esta funcion se llama desde el MANT_TOPOGRAFIA "pro_inicializarControles()".
    ''' </summary>
    Public Function fun_Consultar_CAMPOS_MANT_TOPOGRAFIA() As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' PROCatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MANT_TOPOGRAFIA "

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "TOPOCODI "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Consultar_CAMPOS_MANT_TOPOGRAFIA")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Llena el ComboBox con datos activos formulario insertar y modificar 
    ''' esta funcion se llama desde el MANT_TOPOGRAFIA "pro_inicializarControles()".
    ''' </summary>
    Public Function fun_Consultar_MANT_TOPOGRAFIA_X_ESTADO() As DataTable

        Try
            Dim boInsertar As Boolean = True

            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' PROCatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MANT_TOPOGRAFIA "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "TOPOESTA = 'ac' "

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "TOPOCODI "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Consultar_MANT_TOPOGRAFIA_X_ESTADO")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que busca el ID del registro a modificar o eliminar.
    ''' </summary>
    Public Function fun_Buscar_ID_MANT_TOPOGRAFIA(ByVal inTOPOIDRE As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' PROCatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MANT_TOPOGRAFIA "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "TOPOIDRE = '" & CInt(inTOPOIDRE) & "'"

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Buscar_ID_MANT_TOPOGRAFIA")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que busca el CÓDIGO para que no se 
    ''' guarden registros duplicados.
    ''' </summary>
    Public Function fun_Buscar_CODIGO_MANT_TOPOGRAFIA(ByVal inTOPOCODI As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' PROCatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MANT_TOPOGRAFIA "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "TOPOCODI = '" & CInt(inTOPOCODI) & "'"

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Buscar_CODIGO_MANT_TOPOGRAFIA")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que busca el ID del codigo buscado para ejecutar la consulta
    ''' parametrizada.
    ''' </summary>
    Public Function fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_MANT_TOPOGRAFIA(ByVal inTOPOIDRE As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' PROCatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "TOPOIDRE, "
            stConsultaSQL += "TOPOCODI, "
            stConsultaSQL += "TOPODESC, "
            stConsultaSQL += "TOPOESTA  "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MANT_TOPOGRAFIA "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "TOPOIDRE = '" & CInt(inTOPOIDRE) & "'"

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "TOPOCODI "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception

            MessageBox.Show(Err.Description & " " & "fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_MANT_TOPOGRAFIA")
            Return Nothing

        End Try

    End Function

End Class
