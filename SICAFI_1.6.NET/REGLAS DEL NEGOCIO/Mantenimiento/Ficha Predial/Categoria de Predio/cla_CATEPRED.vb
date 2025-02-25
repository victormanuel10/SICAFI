Imports DATOS

Public Class cla_CATEPRED

    ' ===========================
    ' *** CATEGORIA DE PREDIO ***
    ' ===========================

    ''' <summary>
    ''' MANT_CATEPRED que verifica la llave primaria.
    ''' </summary>
    Public Function fun_Verifica_llave_Primaria_MANT_CATEPRED(ByVal obCAPRCODI As Object) As Boolean

        Try
            Dim boRespuesta As Boolean = False

            Dim obVerifica As New cla_Verificar_Dato

            If obVerifica.fun_Verificar_Campo_Lleno(obCAPRCODI.Text) = True Then

                Dim objdatos1 As New cla_CATEPRED
                Dim tbl As New DataTable

                tbl = objdatos1.fun_Buscar_CODIGO_MANT_CATEPRED(Trim(obCAPRCODI.Text))

                If tbl.Rows.Count > 0 Then
                    MessageBox.Show("El dato " & obCAPRCODI.Text & " del campo " & obCAPRCODI.AccessibleDescription & " existe en la base de datos.", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                    obCAPRCODI.Focus()
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
    Public Function fun_Insertar_MANT_CATEPRED(ByVal inCAPRCODI As Integer, _
                                               ByVal stCAPRDESC As String, _
                                               ByVal stCAPRESTA As String) As Boolean

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' PROCatena la consulta
            stConsultaSQL += "INSERT INTO "
            stConsultaSQL += "MANT_CATEPRED "

            stConsultaSQL += "( "
            stConsultaSQL += "CAPRCODI, "
            stConsultaSQL += "CAPRDESC, "
            stConsultaSQL += "CAPRESTA "
            stConsultaSQL += ") "

            stConsultaSQL += "VALUES "

            stConsultaSQL += "( "
            stConsultaSQL += "'" & CInt(inCAPRCODI) & "', "
            stConsultaSQL += "'" & CStr(Trim(stCAPRDESC)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stCAPRESTA)) & "' "
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
            MessageBox.Show(Err.Description & " " & "fun_Insertar_MANT_CATEPRED")
        End Try

    End Function

    ''' <summary>
    ''' Función que Elimina el registro.
    ''' </summary>
    Public Function fun_Eliminar_MANT_CATEPRED(ByVal inCAPRIDRE As Integer) As Boolean

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' PROCatena la consulta
            stConsultaSQL += "DELETE "
            stConsultaSQL += "MANT_CATEPRED "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "CAPRIDRE = '" & CInt(inCAPRIDRE) & "' "

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
            MessageBox.Show(Err.Description & " " & "fun_Eliminar_MANT_CATEPRED")
        End Try

    End Function

    ''' <summary>
    ''' Función que Modifica el registro.
    ''' </summary>
    Public Function fun_Actualizar_MANT_CATEPRED(ByVal inCAPRIDRE As Integer, _
                                                 ByVal inCAPRCODI As Integer, _
                                                 ByVal stCAPRDESC As String, _
                                                 ByVal stCAPRESTA As String) As Boolean

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' PROCatena la consulta
            stConsultaSQL += "UPDATE "
            stConsultaSQL += "MANT_CATEPRED "

            stConsultaSQL += "SET "
            stConsultaSQL += "CAPRCODI = '" & CInt(inCAPRCODI) & "', "
            stConsultaSQL += "CAPRDESC = '" & CStr(Trim(stCAPRDESC)) & "', "
            stConsultaSQL += "CAPRESTA = '" & CStr(Trim(stCAPRESTA)) & "' "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "CAPRIDRE = '" & CInt(inCAPRIDRE) & "'"

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
            MessageBox.Show(Err.Description & " " & "fun_Actualizar_MANT_CATEPRED")
        End Try

    End Function

    ''' <summary>
    ''' Consulta para llenar el DataGridView y colocar el nombre del encabezado
    ''' de la columna. 
    ''' </summary>
    Public Function fun_Consultar_MANT_CATEPRED() As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' PROCatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "CAPRIDRE, "
            stConsultaSQL += "CAPRCODI, "
            stConsultaSQL += "CAPRDESC, "
            stConsultaSQL += "CAPRESTA  "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MANT_CATEPRED "

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "CAPRCODI "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Consultar_MANT_CATEPRED")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Llena el ComboBox con datos activos e inactivos formulario principal 
    ''' esta funcion se llama desde el MANT_CATEPRED "pro_inicializarControles()".
    ''' </summary>
    Public Function fun_Consultar_CAMPOS_MANT_CATEPRED() As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' PROCatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MANT_CATEPRED "

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "CAPRCODI "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Consultar_CAMPOS_MANT_CATEPRED")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Llena el ComboBox con datos activos formulario insertar y modificar 
    ''' esta funcion se llama desde el MANT_CATEPRED "pro_inicializarControles()".
    ''' </summary>
    Public Function fun_Consultar_MANT_CATEPRED_X_ESTADO() As DataTable

        Try
            Dim boInsertar As Boolean = True

            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' PROCatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MANT_CATEPRED "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "CAPRESTA = 'ac' "

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "CAPRCODI "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Consultar_MANT_CATEPRED_X_ESTADO")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que busca el ID del registro a modificar o eliminar.
    ''' </summary>
    Public Function fun_Buscar_ID_MANT_CATEPRED(ByVal inCAPRIDRE As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' PROCatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MANT_CATEPRED "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "CAPRIDRE = '" & CInt(inCAPRIDRE) & "'"

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Buscar_ID_MANT_CATEPRED")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que busca el CÓDIGO para que no se 
    ''' guarden registros duplicados.
    ''' </summary>
    Public Function fun_Buscar_CODIGO_MANT_CATEPRED(ByVal inCAPRCODI As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' PROCatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MANT_CATEPRED "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "CAPRCODI = '" & CInt(inCAPRCODI) & "'"

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Buscar_CODIGO_MANT_CATEPRED")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que busca el ID del codigo buscado para ejecutar la consulta
    ''' parametrizada.
    ''' </summary>
    Public Function fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_MANT_CATEPRED(ByVal inCAPRIDRE As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' PROCatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "CAPRIDRE, "
            stConsultaSQL += "CAPRCODI, "
            stConsultaSQL += "CAPRDESC, "
            stConsultaSQL += "CAPRESTA  "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MANT_CATEPRED "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "CAPRIDRE = '" & CInt(inCAPRIDRE) & "'"

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "CAPRCODI "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception

            MessageBox.Show(Err.Description & " " & "fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_MANT_CATEPRED")
            Return Nothing

        End Try

    End Function


End Class
