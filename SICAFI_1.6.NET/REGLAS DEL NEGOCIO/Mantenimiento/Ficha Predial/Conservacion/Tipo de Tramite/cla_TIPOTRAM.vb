Imports DATOS

Public Class cla_TIPOTRAM

    '=======================
    '*** TIPO DE TRAMITE ***
    '=======================

    ''' <summary>
    ''' procedimiento que verifica la llave primaria.
    ''' </summary>
    Public Function fun_Verifica_llave_Primaria_MANT_TIPOTRAM(ByVal obTITRCODI As Object) As Boolean

        Try
            Dim boRespuesta As Boolean = False

            Dim obVerifica As New cla_Verificar_Dato

            If obVerifica.fun_Verificar_Campo_Lleno(obTITRCODI.Text) = True Then
                If obVerifica.fun_Verificar_Dato_Numerico(obTITRCODI.Text) = True Then

                    Dim objdatos1 As New cla_TIPOTRAM
                    Dim tbl As New DataTable

                    tbl = objdatos1.fun_Buscar_CODIGO_MANT_TIPOTRAM(Trim(obTITRCODI.Text))

                    If tbl.Rows.Count > 0 Then
                        MessageBox.Show("El dato " & obTITRCODI.Text & " del campo " & obTITRCODI.AccessibleDescription & " existe en la base de datos.", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                        obTITRCODI.Focus()
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
    Public Function fun_Insertar_MANT_TIPOTRAM(ByVal inTITRCODI As Integer, _
                                               ByVal stTITRDESC As String, _
                                               ByVal stTITRESTA As String) As Boolean

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' TITRatena la consulta
            stConsultaSQL += "INSERT INTO "
            stConsultaSQL += "MANT_TIPOTRAM "

            stConsultaSQL += "( "
            stConsultaSQL += "TITRCODI, "
            stConsultaSQL += "TITRDESC, "
            stConsultaSQL += "TITRESTA "
            stConsultaSQL += ") "

            stConsultaSQL += "VALUES "

            stConsultaSQL += "( "
            stConsultaSQL += "'" & CInt(inTITRCODI) & "', "
            stConsultaSQL += "'" & CStr(Trim(stTITRDESC)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stTITRESTA)) & "' "
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
            MessageBox.Show(Err.Description & " " & "fun_Insertar_MANT_TIPOTRAM")
        End Try

    End Function

    ''' <summary>
    ''' Función que Elimina el registro.
    ''' </summary>
    Public Function fun_Eliminar_MANT_TIPOTRAM(ByVal inTITRIDRE As Integer) As Boolean

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' TITRatena la consulta
            stConsultaSQL += "DELETE "
            stConsultaSQL += "MANT_TIPOTRAM "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "TITRIDRE = '" & CInt(inTITRIDRE) & "' "

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
            MessageBox.Show(Err.Description & " " & "fun_Eliminar_MANT_TIPOTRAM")
        End Try

    End Function

    ''' <summary>
    ''' Función que Modifica el registro.
    ''' </summary>
    Public Function fun_Actualizar_MANT_TIPOTRAM(ByVal inTITRIDRE As Integer, _
                                                 ByVal inTITRCODI As Integer, _
                                                 ByVal stTITRDESC As String, _
                                                 ByVal stTITRESTA As String) As Boolean

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' TITRatena la consulta
            stConsultaSQL += "UPDATE "
            stConsultaSQL += "MANT_TIPOTRAM "

            stConsultaSQL += "SET "
            stConsultaSQL += "TITRCODI = '" & CInt(inTITRCODI) & "', "
            stConsultaSQL += "TITRDESC = '" & CStr(Trim(stTITRDESC)) & "', "
            stConsultaSQL += "TITRESTA = '" & CStr(Trim(stTITRESTA)) & "' "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "TITRIDRE = '" & CInt(inTITRIDRE) & "'"

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
            MessageBox.Show(Err.Description & " " & "fun_Actualizar_MANT_TIPOTRAM")
        End Try

    End Function

    ''' <summary>
    ''' Consulta para llenar el DataGridView y colocar el nombre del encabezado
    ''' de la columna. 
    ''' </summary>
    Public Function fun_Consultar_MANT_TIPOTRAM() As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' TITRatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "TITRIDRE, "
            stConsultaSQL += "TITRCODI, "
            stConsultaSQL += "TITRDESC, "
            stConsultaSQL += "TITRESTA  "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MANT_TIPOTRAM "

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "TITRCODI "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Consultar_MANT_TIPOTRAM")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Llena el ComboBox con datos activos e inactivos formulario principal 
    ''' esta funcion se llama desde el procedimiento "pro_inicializarControles()".
    ''' </summary>
    Public Function fun_Consultar_CAMPOS_MANT_TIPOTRAM() As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' TITRatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MANT_TIPOTRAM "

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "TITRCODI "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Consultar_CAMPOS_MANT_TIPOTRAM")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Llena el ComboBox con datos activos formulario insertar y modificar 
    ''' esta funcion se llama desde el procedimiento "pro_inicializarControles()".
    ''' </summary>
    Public Function fun_Consultar_MANT_TIPOTRAM_X_ESTADO() As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' TITRatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MANT_TIPOTRAM "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "TITRESTA = 'ac' "

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "TITRCODI "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Consultar_MANT_TIPOTRAM_X_ESTADO")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que busca el ID del registro a modificar o eliminar.
    ''' </summary>
    Public Function fun_Buscar_ID_MANT_TIPOTRAM(ByVal inTITRIDRE As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' TITRatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MANT_TIPOTRAM "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "TITRIDRE = '" & CInt(inTITRIDRE) & "'"

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Buscar_ID_MANT_TIPOTRAM")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que busca el CÓDIGO DE LA CALIDAD DE PROPIETARIO para que no se 
    ''' guarden registros duplicados.
    ''' </summary>
    Public Function fun_Buscar_CODIGO_MANT_TIPOTRAM(ByVal inTITRCODI As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' TITRatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MANT_TIPOTRAM "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "TITRCODI = '" & CInt(inTITRCODI) & "'"

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Buscar_CODIGO_MANT_TIPOTRAM")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que busca el ID del codigo buscado para ejecutar la consulta
    ''' parametrizada.
    ''' </summary>
    Public Function fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_MANT_TIPOTRAM(ByVal inTITRIDRE As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' TITRatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "TITRIDRE, "
            stConsultaSQL += "TITRCODI, "
            stConsultaSQL += "TITRDESC, "
            stConsultaSQL += "TITRESTA  "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MANT_TIPOTRAM "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "TITRIDRE = '" & CInt(inTITRIDRE) & "'"

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "TITRCODI "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception

            MessageBox.Show(Err.Description & " " & "fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_MANT_TIPOTRAM")
            Return Nothing

        End Try

    End Function

End Class
