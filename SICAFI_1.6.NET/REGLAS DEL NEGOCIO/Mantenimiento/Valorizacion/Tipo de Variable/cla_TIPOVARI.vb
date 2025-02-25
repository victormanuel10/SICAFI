Imports DATOS

Public Class cla_TIPOVARI

    '========================
    '*** TIPO DE VARIABLE ***
    '========================

    ''' <summary>
    ''' procedimiento que verifica la llave primaria.
    ''' </summary>
    Public Function fun_Verifica_llave_Primaria_MANT_TIPOVARI(ByVal obTIVACODI As Object) As Boolean

        Try
            Dim boRespuesta As Boolean = False

            Dim obVerifica As New cla_Verificar_Dato

            If obVerifica.fun_Verificar_Campo_Lleno(obTIVACODI.Text) = True Then
                If obVerifica.fun_Verificar_Dato_Numerico(obTIVACODI.Text) = True Then

                    Dim objdatos1 As New cla_TIPOVARI
                    Dim tbl As New DataTable

                    tbl = objdatos1.fun_Buscar_CODIGO_MANT_TIPOVARI(Trim(obTIVACODI.Text))

                    If tbl.Rows.Count > 0 Then
                        MessageBox.Show("El dato " & obTIVACODI.Text & " del campo " & obTIVACODI.AccessibleDescription & " existe en la base de datos.", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                        obTIVACODI.Focus()
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
    Public Function fun_Insertar_MANT_TIPOVARI(ByVal inTIVACODI As Integer, _
                                               ByVal stTIVADESC As String, _
                                               ByVal stTIVAESTA As String) As Boolean

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' TITRatena la consulta
            stConsultaSQL += "INSERT INTO "
            stConsultaSQL += "MANT_TIPOVARI "

            stConsultaSQL += "( "
            stConsultaSQL += "TIVACODI, "
            stConsultaSQL += "TIVADESC, "
            stConsultaSQL += "TIVAESTA "
            stConsultaSQL += ") "

            stConsultaSQL += "VALUES "

            stConsultaSQL += "( "
            stConsultaSQL += "'" & CInt(inTIVACODI) & "', "
            stConsultaSQL += "'" & CStr(Trim(stTIVADESC)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stTIVAESTA)) & "' "
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
            MessageBox.Show(Err.Description & " " & "fun_Insertar_MANT_TIPOVARI")
        End Try

    End Function

    ''' <summary>
    ''' Función que Elimina el registro.
    ''' </summary>
    Public Function fun_Eliminar_MANT_TIPOVARI(ByVal inTIVAIDRE As Integer) As Boolean

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' TITRatena la consulta
            stConsultaSQL += "DELETE "
            stConsultaSQL += "MANT_TIPOVARI "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "TIVAIDRE = '" & CInt(inTIVAIDRE) & "' "

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
            MessageBox.Show(Err.Description & " " & "fun_Eliminar_MANT_TIPOVARI")
        End Try

    End Function

    ''' <summary>
    ''' Función que Modifica el registro.
    ''' </summary>
    Public Function fun_Actualizar_MANT_TIPOVARI(ByVal inTIVAIDRE As Integer, _
                                                 ByVal inTIVACODI As Integer, _
                                                 ByVal stTIVADESC As String, _
                                                 ByVal stTIVAESTA As String) As Boolean

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' TITRatena la consulta
            stConsultaSQL += "UPDATE "
            stConsultaSQL += "MANT_TIPOVARI "

            stConsultaSQL += "SET "
            stConsultaSQL += "TIVACODI = '" & CInt(inTIVACODI) & "', "
            stConsultaSQL += "TIVADESC = '" & CStr(Trim(stTIVADESC)) & "', "
            stConsultaSQL += "TIVAESTA = '" & CStr(Trim(stTIVAESTA)) & "' "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "TIVAIDRE = '" & CInt(inTIVAIDRE) & "'"

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
            MessageBox.Show(Err.Description & " " & "fun_Actualizar_MANT_TIPOVARI")
        End Try

    End Function

    ''' <summary>
    ''' Consulta para llenar el DataGridView y colocar el nombre del encabezado
    ''' de la columna. 
    ''' </summary>
    Public Function fun_Consultar_MANT_TIPOVARI() As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' TITRatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "TIVAIDRE, "
            stConsultaSQL += "TIVACODI, "
            stConsultaSQL += "TIVADESC, "
            stConsultaSQL += "TIVAESTA  "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MANT_TIPOVARI "

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "TIVACODI "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Consultar_MANT_TIPOVARI")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Llena el ComboBox con datos activos e inactivos formulario principal 
    ''' esta funcion se llama desde el procedimiento "pro_inicializarControles()".
    ''' </summary>
    Public Function fun_Consultar_CAMPOS_MANT_TIPOVARI() As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' TITRatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MANT_TIPOVARI "

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "TIVACODI "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Consultar_CAMPOS_MANT_TIPOVARI")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Llena el ComboBox con datos activos formulario insertar y modificar 
    ''' esta funcion se llama desde el procedimiento "pro_inicializarControles()".
    ''' </summary>
    Public Function fun_Consultar_MANT_TIPOVARI_X_ESTADO() As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' TITRatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MANT_TIPOVARI "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "TIVAESTA = 'ac' "

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "TIVACODI "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Consultar_MANT_TIPOVARI_X_ESTADO")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que busca el ID del registro a modificar o eliminar.
    ''' </summary>
    Public Function fun_Buscar_ID_MANT_TIPOVARI(ByVal inTIVAIDRE As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' TITRatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MANT_TIPOVARI "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "TIVAIDRE = '" & CInt(inTIVAIDRE) & "'"

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Buscar_ID_MANT_TIPOVARI")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que busca el CÓDIGO DE LA CALIDAD DE PROPIETARIO para que no se 
    ''' guarden registros duplicados.
    ''' </summary>
    Public Function fun_Buscar_CODIGO_MANT_TIPOVARI(ByVal inTIVACODI As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' TITRatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MANT_TIPOVARI "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "TIVACODI = '" & CInt(inTIVACODI) & "'"

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Buscar_CODIGO_MANT_TIPOVARI")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que busca el ID del codigo buscado para ejecutar la consulta
    ''' parametrizada.
    ''' </summary>
    Public Function fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_MANT_TIPOVARI(ByVal inTIVAIDRE As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' TITRatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "TIVAIDRE, "
            stConsultaSQL += "TIVACODI, "
            stConsultaSQL += "TIVADESC, "
            stConsultaSQL += "TIVAESTA  "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MANT_TIPOVARI "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "TIVAIDRE = '" & CInt(inTIVAIDRE) & "'"

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "TIVACODI "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception

            MessageBox.Show(Err.Description & " " & "fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_MANT_TIPOVARI")
            Return Nothing

        End Try

    End Function

End Class
