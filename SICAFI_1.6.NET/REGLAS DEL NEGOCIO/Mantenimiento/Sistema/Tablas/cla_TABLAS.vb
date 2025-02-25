Imports DATOS

Public Class cla_TABLAS

    '============================
    '*** MANTENIMIENTO TABLAS ***
    '============================

    ''' <summary>
    ''' MANT_TABLAS que verifica la llave primaria.
    ''' </summary>
    Public Function fun_Verifica_llave_Primaria_MANT_TABLAS(ByVal obTABLCODI As Object) As Boolean

        Try
            Dim boRespuesta As Boolean = False

            Dim obVerifica As New cla_Verificar_Dato

            If obVerifica.fun_Verificar_Campo_Lleno(obTABLCODI.Text) = True Then

                Dim objdatos1 As New cla_TABLAS
                Dim tbl As New DataTable

                tbl = objdatos1.fun_Buscar_CODIGO_MANT_TABLAS(Trim(obTABLCODI.Text))

                If tbl.Rows.Count > 0 Then
                    MessageBox.Show("El dato " & obTABLCODI.Text & " del campo " & obTABLCODI.AccessibleDescription & " existe en la base de datos.", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                    obTABLCODI.Focus()
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
    Public Function fun_Insertar_MANT_TABLAS(ByVal stTABLCODI As String, _
                                               ByVal stTABLDESC As String, _
                                               ByVal boTABLPRIN As Boolean, _
                                               ByVal boTABLMANT As Boolean, _
                                               ByVal boTABLSIST As Boolean, _
                                               ByVal stTABLESTA As String) As Boolean

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' PROCatena la consulta
            stConsultaSQL += "INSERT INTO "
            stConsultaSQL += "MANT_TABLAS "

            stConsultaSQL += "( "
            stConsultaSQL += "TABLCODI, "
            stConsultaSQL += "TABLDESC, "
            stConsultaSQL += "TABLPRIN, "
            stConsultaSQL += "TABLMANT, "
            stConsultaSQL += "TABLSIST, "
            stConsultaSQL += "TABLESTA "
            stConsultaSQL += ") "

            stConsultaSQL += "VALUES "

            stConsultaSQL += "( "
            stConsultaSQL += "'" & CStr(Trim(stTABLCODI)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stTABLDESC)) & "', "
            stConsultaSQL += "'" & CBool(boTABLPRIN) & "', "
            stConsultaSQL += "'" & CBool(boTABLMANT) & "', "
            stConsultaSQL += "'" & CBool(boTABLSIST) & "', "
            stConsultaSQL += "'" & CStr(Trim(stTABLESTA)) & "' "
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
            MessageBox.Show(Err.Description & " " & "fun_Insertar_MANT_TABLAS")
        End Try

    End Function

    ''' <summary>
    ''' Función que Elimina el registro.
    ''' </summary>
    Public Function fun_Eliminar_MANT_TABLAS(ByVal inTABLIDRE As Integer) As Boolean

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' PROCatena la consulta
            stConsultaSQL += "DELETE "
            stConsultaSQL += "MANT_TABLAS "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "TABLIDRE = '" & CInt(inTABLIDRE) & "' "

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
            MessageBox.Show(Err.Description & " " & "fun_Eliminar_MANT_TABLAS")
        End Try

    End Function

    ''' <summary>
    ''' Función que Modifica el registro.
    ''' </summary>
    Public Function fun_Actualizar_MANT_TABLAS(ByVal inTABLIDRE As Integer, _
                                                 ByVal stTABLCODI As String, _
                                                 ByVal stTABLDESC As String, _
                                                 ByVal boTABLPRIN As Boolean, _
                                                 ByVal boTABLMANT As Boolean, _
                                                 ByVal boTABLSIST As Boolean, _
                                                 ByVal stTABLESTA As String) As Boolean

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' PROCatena la consulta
            stConsultaSQL += "UPDATE "
            stConsultaSQL += "MANT_TABLAS "

            stConsultaSQL += "SET "
            stConsultaSQL += "TABLCODI = '" & CStr(Trim(stTABLCODI)) & "', "
            stConsultaSQL += "TABLDESC = '" & CStr(Trim(stTABLDESC)) & "', "
            stConsultaSQL += "TABLPRIN = '" & CBool(boTABLPRIN) & "', "
            stConsultaSQL += "TABLMANT = '" & CBool(boTABLMANT) & "', "
            stConsultaSQL += "TABLSIST = '" & CBool(boTABLSIST) & "', "
            stConsultaSQL += "TABLESTA = '" & CStr(Trim(stTABLESTA)) & "' "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "TABLIDRE = '" & CInt(inTABLIDRE) & "'"

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
            MessageBox.Show(Err.Description & " " & "fun_Actualizar_MANT_TABLAS")
        End Try

    End Function

    ''' <summary>
    ''' Consulta para llenar el DataGridView y colocar el nombre del encabezado
    ''' de la columna. 
    ''' </summary>
    Public Function fun_Consultar_MANT_TABLAS() As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' PROCatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "TABLIDRE, "
            stConsultaSQL += "TABLCODI, "
            stConsultaSQL += "TABLDESC, "
            stConsultaSQL += "TABLPRIN, "
            stConsultaSQL += "TABLMANT, "
            stConsultaSQL += "TABLSIST, "
            stConsultaSQL += "TABLESTA  "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MANT_TABLAS "

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "TABLCODI "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Consultar_MANT_TABLAS")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Llena el ComboBox con datos activos e inactivos formulario principal 
    ''' esta funcion se llama desde el MANT_TABLAS "pro_inicializarControles()".
    ''' </summary>
    Public Function fun_Consultar_CAMPOS_MANT_TABLAS() As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' PROCatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MANT_TABLAS "

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "TABLCODI "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Consultar_CAMPOS_MANT_TABLAS")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Llena el ComboBox con datos activos formulario insertar y modificar 
    ''' esta funcion se llama desde el MANT_TABLAS "pro_inicializarControles()".
    ''' </summary>
    Public Function fun_Consultar_MANT_TABLAS_X_ESTADO() As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' PROCatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MANT_TABLAS "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "TABLESTA = 'ac' "

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "TABLCODI "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Consultar_MANT_TABLAS_X_ESTADO")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que busca el ID del registro a modificar o eliminar.
    ''' </summary>
    Public Function fun_Buscar_ID_MANT_TABLAS(ByVal inTABLIDRE As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' PROCatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MANT_TABLAS "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "TABLIDRE = '" & CInt(inTABLIDRE) & "'"

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Buscar_ID_MANT_TABLAS")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que busca el CÓDIGO DE LA CALIDAD DE PROPIETARIO para que no se 
    ''' guarden registros duplicados.
    ''' </summary>
    Public Function fun_Buscar_CODIGO_MANT_TABLAS(ByVal stTABLCODI As String) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' PROCatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MANT_TABLAS "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "TABLCODI = '" & CStr(Trim(stTABLCODI)) & "'"

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Buscar_CODIGO_MANT_TABLAS")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que busca el ID del codigo buscado para ejecutar la consulta
    ''' parametrizada.
    ''' </summary>
    Public Function fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_MANT_TABLAS(ByVal inTABLIDRE As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' PROCatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "TABLIDRE, "
            stConsultaSQL += "TABLCODI, "
            stConsultaSQL += "TABLDESC, "
            stConsultaSQL += "TABLPRIN, "
            stConsultaSQL += "TABLMANT, "
            stConsultaSQL += "TABLSIST, "
            stConsultaSQL += "TABLESTA  "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MANT_TABLAS "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "TABLIDRE = '" & CInt(inTABLIDRE) & "'"

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "TABLCODI "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception

            MessageBox.Show(Err.Description & " " & "fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_MANT_TABLAS")
            Return Nothing

        End Try

    End Function


End Class
