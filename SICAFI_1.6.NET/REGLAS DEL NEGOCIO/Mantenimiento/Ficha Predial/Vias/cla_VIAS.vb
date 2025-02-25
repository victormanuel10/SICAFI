Imports DATOS

Public Class cla_VIAS

    ' ============
    ' *** VIAS ***
    ' ============

    ''' <summary>
    ''' MANT_VIAS que verifica la llave primaria.
    ''' </summary>
    Public Function fun_Verifica_llave_Primaria_MANT_VIAS(ByVal obVIASCODI As Object) As Boolean

        Try
            Dim boRespuesta As Boolean = False

            Dim obVerifica As New cla_Verificar_Dato

            If obVerifica.fun_Verificar_Campo_Lleno(obVIASCODI.Text) = True Then

                Dim objdatos1 As New cla_VIAS
                Dim tbl As New DataTable

                tbl = objdatos1.fun_Buscar_CODIGO_MANT_VIAS(Trim(obVIASCODI.Text))

                If tbl.Rows.Count > 0 Then
                    MessageBox.Show("El dato " & obVIASCODI.Text & " del campo " & obVIASCODI.AccessibleDescription & " existe en la base de datos.", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                    obVIASCODI.Focus()
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
    Public Function fun_Insertar_MANT_VIAS(ByVal inVIASCODI As Integer, _
                                           ByVal stVIASDESC As String, _
                                           ByVal stVIASESTA As String) As Boolean

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' PROCatena la consulta
            stConsultaSQL += "INSERT INTO "
            stConsultaSQL += "MANT_VIAS "

            stConsultaSQL += "( "
            stConsultaSQL += "VIASCODI, "
            stConsultaSQL += "VIASDESC, "
            stConsultaSQL += "VIASESTA "
            stConsultaSQL += ") "

            stConsultaSQL += "VALUES "

            stConsultaSQL += "( "
            stConsultaSQL += "'" & CInt(inVIASCODI) & "', "
            stConsultaSQL += "'" & CStr(Trim(stVIASDESC)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stVIASESTA)) & "' "
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
            MessageBox.Show(Err.Description & " " & "fun_Insertar_MANT_VIAS")
        End Try

    End Function

    ''' <summary>
    ''' Función que Elimina el registro.
    ''' </summary>
    Public Function fun_Eliminar_MANT_VIAS(ByVal inVIASIDRE As Integer) As Boolean

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' PROCatena la consulta
            stConsultaSQL += "DELETE "
            stConsultaSQL += "MANT_VIAS "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "VIASIDRE = '" & CInt(inVIASIDRE) & "' "

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
            MessageBox.Show(Err.Description & " " & "fun_Eliminar_MANT_VIAS")
        End Try

    End Function

    ''' <summary>
    ''' Función que Modifica el registro.
    ''' </summary>
    Public Function fun_Actualizar_MANT_VIAS(ByVal inVIASIDRE As Integer, _
                                             ByVal inVIASCODI As Integer, _
                                             ByVal stVIASDESC As String, _
                                             ByVal stVIASESTA As String) As Boolean

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' PROCatena la consulta
            stConsultaSQL += "UPDATE "
            stConsultaSQL += "MANT_VIAS "

            stConsultaSQL += "SET "
            stConsultaSQL += "VIASCODI = '" & CInt(inVIASCODI) & "', "
            stConsultaSQL += "VIASDESC = '" & CStr(Trim(stVIASDESC)) & "', "
            stConsultaSQL += "VIASESTA = '" & CStr(Trim(stVIASESTA)) & "' "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "VIASIDRE = '" & CInt(inVIASIDRE) & "'"

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
            MessageBox.Show(Err.Description & " " & "fun_Actualizar_MANT_VIAS")
        End Try

    End Function

    ''' <summary>
    ''' Consulta para llenar el DataGridView y colocar el nombre del encabezado
    ''' de la columna. 
    ''' </summary>
    Public Function fun_Consultar_MANT_VIAS() As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' PROCatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "VIASIDRE, "
            stConsultaSQL += "VIASCODI, "
            stConsultaSQL += "VIASDESC, "
            stConsultaSQL += "VIASESTA  "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MANT_VIAS "

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "VIASCODI "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Consultar_MANT_VIAS")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Llena el ComboBox con datos activos e inactivos formulario principal 
    ''' esta funcion se llama desde el MANT_VIAS "pro_inicializarControles()".
    ''' </summary>
    Public Function fun_Consultar_CAMPOS_MANT_VIAS() As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' PROCatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MANT_VIAS "

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "VIASCODI "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Consultar_CAMPOS_MANT_VIAS")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Llena el ComboBox con datos activos formulario insertar y modificar 
    ''' esta funcion se llama desde el MANT_VIAS "pro_inicializarControles()".
    ''' </summary>
    Public Function fun_Consultar_MANT_VIAS_X_ESTADO() As DataTable

        Try
            Dim boInsertar As Boolean = True

            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' PROCatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MANT_VIAS "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "VIASESTA = 'ac' "

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "VIASCODI "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Consultar_MANT_VIAS_X_ESTADO")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que busca el ID del registro a modificar o eliminar.
    ''' </summary>
    Public Function fun_Buscar_ID_MANT_VIAS(ByVal inVIASIDRE As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' PROCatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MANT_VIAS "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "VIASIDRE = '" & CInt(inVIASIDRE) & "'"

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Buscar_ID_MANT_VIAS")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que busca el CÓDIGO para que no se 
    ''' guarden registros duplicados.
    ''' </summary>
    Public Function fun_Buscar_CODIGO_MANT_VIAS(ByVal inVIASCODI As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' PROCatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MANT_VIAS "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "VIASCODI = '" & CInt(inVIASCODI) & "'"

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Buscar_CODIGO_MANT_VIAS")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que busca el ID del codigo buscado para ejecutar la consulta
    ''' parametrizada.
    ''' </summary>
    Public Function fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_MANT_VIAS(ByVal inVIASIDRE As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' PROCatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "VIASIDRE, "
            stConsultaSQL += "VIASCODI, "
            stConsultaSQL += "VIASDESC, "
            stConsultaSQL += "VIASESTA  "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MANT_VIAS "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "VIASIDRE = '" & CInt(inVIASIDRE) & "'"

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "VIASCODI "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception

            MessageBox.Show(Err.Description & " " & "fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_MANT_VIAS")
            Return Nothing

        End Try

    End Function

End Class
