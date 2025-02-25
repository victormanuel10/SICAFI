Imports DATOS

Public Class cla_TRATURBA

    ' =================================
    ' *** TRATAMIENTOS URBANISTICOS ***
    ' =================================

    ''' <summary>
    ''' MANT_TRATURBA que verifica la llave primaria.
    ''' </summary>
    Public Function fun_Verifica_llave_Primaria_MANT_TRATURBA(ByVal obTRURCODI As Object) As Boolean

        Try
            Dim boRespuesta As Boolean = False

            Dim obVerifica As New cla_Verificar_Dato

            If obVerifica.fun_Verificar_Campo_Lleno(obTRURCODI.Text) = True Then

                Dim objdatos1 As New cla_TRATURBA
                Dim tbl As New DataTable

                tbl = objdatos1.fun_Buscar_CODIGO_MANT_TRATURBA(Trim(obTRURCODI.Text))

                If tbl.Rows.Count > 0 Then
                    MessageBox.Show("El dato " & obTRURCODI.Text & " del campo " & obTRURCODI.AccessibleDescription & " existe en la base de datos.", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                    obTRURCODI.Focus()
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
    Public Function fun_Insertar_MANT_TRATURBA(ByVal inTRURCODI As Integer, _
                                               ByVal stTRURDESC As String, _
                                               ByVal stTRURESTA As String) As Boolean

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' PROCatena la consulta
            stConsultaSQL += "INSERT INTO "
            stConsultaSQL += "MANT_TRATURBA "

            stConsultaSQL += "( "
            stConsultaSQL += "TRURCODI, "
            stConsultaSQL += "TRURDESC, "
            stConsultaSQL += "TRURESTA "
            stConsultaSQL += ") "

            stConsultaSQL += "VALUES "

            stConsultaSQL += "( "
            stConsultaSQL += "'" & CInt(inTRURCODI) & "', "
            stConsultaSQL += "'" & CStr(Trim(stTRURDESC)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stTRURESTA)) & "' "
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
            MessageBox.Show(Err.Description & " " & "fun_Insertar_MANT_TRATURBA")
        End Try

    End Function

    ''' <summary>
    ''' Función que Elimina el registro.
    ''' </summary>
    Public Function fun_Eliminar_MANT_TRATURBA(ByVal inTRURIDRE As Integer) As Boolean

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' PROCatena la consulta
            stConsultaSQL += "DELETE "
            stConsultaSQL += "MANT_TRATURBA "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "TRURIDRE = '" & CInt(inTRURIDRE) & "' "

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
            MessageBox.Show(Err.Description & " " & "fun_Eliminar_MANT_TRATURBA")
        End Try

    End Function

    ''' <summary>
    ''' Función que Modifica el registro.
    ''' </summary>
    Public Function fun_Actualizar_MANT_TRATURBA(ByVal inTRURIDRE As Integer, _
                                                 ByVal inTRURCODI As Integer, _
                                                 ByVal stTRURDESC As String, _
                                                 ByVal stTRURESTA As String) As Boolean

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' PROCatena la consulta
            stConsultaSQL += "UPDATE "
            stConsultaSQL += "MANT_TRATURBA "

            stConsultaSQL += "SET "
            stConsultaSQL += "TRURCODI = '" & CInt(inTRURCODI) & "', "
            stConsultaSQL += "TRURDESC = '" & CStr(Trim(stTRURDESC)) & "', "
            stConsultaSQL += "TRURESTA = '" & CStr(Trim(stTRURESTA)) & "' "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "TRURIDRE = '" & CInt(inTRURIDRE) & "'"

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
            MessageBox.Show(Err.Description & " " & "fun_Actualizar_MANT_TRATURBA")
        End Try

    End Function

    ''' <summary>
    ''' Consulta para llenar el DataGridView y colocar el nombre del encabezado
    ''' de la columna. 
    ''' </summary>
    Public Function fun_Consultar_MANT_TRATURBA() As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' PROCatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "TRURIDRE, "
            stConsultaSQL += "TRURCODI, "
            stConsultaSQL += "TRURDESC, "
            stConsultaSQL += "TRURESTA  "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MANT_TRATURBA "

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "TRURCODI "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Consultar_MANT_TRATURBA")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Llena el ComboBox con datos activos e inactivos formulario principal 
    ''' esta funcion se llama desde el MANT_TRATURBA "pro_inicializarControles()".
    ''' </summary>
    Public Function fun_Consultar_CAMPOS_MANT_TRATURBA() As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' PROCatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MANT_TRATURBA "

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "TRURCODI "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Consultar_CAMPOS_MANT_TRATURBA")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Llena el ComboBox con datos activos formulario insertar y modificar 
    ''' esta funcion se llama desde el MANT_TRATURBA "pro_inicializarControles()".
    ''' </summary>
    Public Function fun_Consultar_MANT_TRATURBA_X_ESTADO() As DataTable

        Try
            Dim boInsertar As Boolean = True

            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' PROCatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MANT_TRATURBA "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "TRURESTA = 'ac' "

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "TRURCODI "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Consultar_MANT_TRATURBA_X_ESTADO")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que busca el ID del registro a modificar o eliminar.
    ''' </summary>
    Public Function fun_Buscar_ID_MANT_TRATURBA(ByVal inTRURIDRE As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' PROCatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MANT_TRATURBA "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "TRURIDRE = '" & CInt(inTRURIDRE) & "'"

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Buscar_ID_MANT_TRATURBA")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que busca el CÓDIGO para que no se 
    ''' guarden registros duplicados.
    ''' </summary>
    Public Function fun_Buscar_CODIGO_MANT_TRATURBA(ByVal inTRURCODI As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' PROCatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MANT_TRATURBA "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "TRURCODI = '" & CInt(inTRURCODI) & "'"

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Buscar_CODIGO_MANT_TRATURBA")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que busca el ID del codigo buscado para ejecutar la consulta
    ''' parametrizada.
    ''' </summary>
    Public Function fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_MANT_TRATURBA(ByVal inTRURIDRE As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' PROCatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "TRURIDRE, "
            stConsultaSQL += "TRURCODI, "
            stConsultaSQL += "TRURDESC, "
            stConsultaSQL += "TRURESTA  "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MANT_TRATURBA "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "TRURIDRE = '" & CInt(inTRURIDRE) & "'"

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "TRURCODI "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception

            MessageBox.Show(Err.Description & " " & "fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_MANT_TRATURBA")
            Return Nothing

        End Try

    End Function

End Class
