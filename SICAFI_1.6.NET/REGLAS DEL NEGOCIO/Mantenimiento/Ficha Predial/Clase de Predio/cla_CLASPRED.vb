Imports DATOS

Public Class cla_CLASPRED

    ' =======================
    ' *** CLASE DE PREDIO ***
    ' =======================

    ''' <summary>
    ''' CLASPRED que verifica la llave primaria.
    ''' </summary>
    Public Function fun_Verifica_llave_Primaria_CLASPRED(ByVal obCLPRCODI As Object) As Boolean

        Try
            Dim boRespuesta As Boolean = False

            Dim obVerifica As New cla_Verificar_Dato

            If obVerifica.fun_Verificar_Campo_Lleno(obCLPRCODI.Text) = True Then

                Dim objdatos1 As New cla_CLASPRED
                Dim tbl As New DataTable

                tbl = objdatos1.fun_Buscar_CODIGO_CLASPRED(Trim(obCLPRCODI.Text))

                If tbl.Rows.Count > 0 Then
                    MessageBox.Show("El dato " & obCLPRCODI.Text & " del campo " & obCLPRCODI.AccessibleDescription & " existe en la base de datos.", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                    obCLPRCODI.Focus()
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
    Public Function fun_Insertar_CLASPRED(ByVal inCLPRCODI As Integer, _
                                          ByVal stCLPRDESC As String, _
                                          ByVal stCLPRESTA As String) As Boolean

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' PROCatena la consulta
            stConsultaSQL += "INSERT INTO "
            stConsultaSQL += "CLASPRED "

            stConsultaSQL += "( "
            stConsultaSQL += "CLPRCODI, "
            stConsultaSQL += "CLPRDESC, "
            stConsultaSQL += "CLPRESTA "
            stConsultaSQL += ") "

            stConsultaSQL += "VALUES "

            stConsultaSQL += "( "
            stConsultaSQL += "'" & CInt(inCLPRCODI) & "', "
            stConsultaSQL += "'" & CStr(Trim(stCLPRDESC)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stCLPRESTA)) & "' "
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
            MessageBox.Show(Err.Description & " " & "fun_Insertar_CLASPRED")
        End Try

    End Function

    ''' <summary>
    ''' Función que Elimina el registro.
    ''' </summary>
    Public Function fun_Eliminar_CLASPRED(ByVal inCLPRIDRE As Integer) As Boolean

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' PROCatena la consulta
            stConsultaSQL += "DELETE "
            stConsultaSQL += "CLASPRED "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "CLPRIDRE = '" & CInt(inCLPRIDRE) & "' "

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
            MessageBox.Show(Err.Description & " " & "fun_Eliminar_CLASPRED")
        End Try

    End Function

    ''' <summary>
    ''' Función que Modifica el registro.
    ''' </summary>
    Public Function fun_Actualizar_CLASPRED(ByVal inCLPRIDRE As Integer, _
                                            ByVal inCLPRCODI As Integer, _
                                            ByVal stCLPRDESC As String, _
                                            ByVal stCLPRESTA As String) As Boolean

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' PROCatena la consulta
            stConsultaSQL += "UPDATE "
            stConsultaSQL += "CLASPRED "

            stConsultaSQL += "SET "
            stConsultaSQL += "CLPRCODI = '" & CInt(inCLPRCODI) & "', "
            stConsultaSQL += "CLPRDESC = '" & CStr(Trim(stCLPRDESC)) & "', "
            stConsultaSQL += "CLPRESTA = '" & CStr(Trim(stCLPRESTA)) & "' "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "CLPRIDRE = '" & CInt(inCLPRIDRE) & "'"

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
            MessageBox.Show(Err.Description & " " & "fun_Actualizar_CLASPRED")
        End Try

    End Function

    ''' <summary>
    ''' Consulta para llenar el DataGridView y colocar el nombre del encabezado
    ''' de la columna. 
    ''' </summary>
    Public Function fun_Consultar_CLASPRED() As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' PROCatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "CLPRIDRE, "
            stConsultaSQL += "CLPRCODI, "
            stConsultaSQL += "CLPRDESC, "
            stConsultaSQL += "CLPRESTA  "

            stConsultaSQL += "FROM "
            stConsultaSQL += "CLASPRED "

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "CLPRCODI "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Consultar_CLASPRED")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Llena el ComboBox con datos activos e inactivos formulario principal 
    ''' esta funcion se llama desde el CLASPRED "pro_inicializarControles()".
    ''' </summary>
    Public Function fun_Consultar_CAMPOS_CLASPRED() As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' PROCatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "CLASPRED "

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "CLPRCODI "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Consultar_CAMPOS_CLASPRED")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Llena el ComboBox con datos activos formulario insertar y modificar 
    ''' esta funcion se llama desde el CLASPRED "pro_inicializarControles()".
    ''' </summary>
    Public Function fun_Consultar_CLASPRED_X_ESTADO() As DataTable

        Try
            Dim boInsertar As Boolean = True

            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' PROCatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "CLASPRED "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "CLPRESTA = 'ac' "

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "CLPRCODI "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Consultar_CLASPRED_X_ESTADO")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que busca el ID del registro a modificar o eliminar.
    ''' </summary>
    Public Function fun_Buscar_ID_CLASPRED(ByVal inCLPRIDRE As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' PROCatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "CLASPRED "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "CLPRIDRE = '" & CInt(inCLPRIDRE) & "'"

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Buscar_ID_CLASPRED")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que busca el CÓDIGO para que no se 
    ''' guarden registros duplicados.
    ''' </summary>
    Public Function fun_Buscar_CODIGO_CLASPRED(ByVal inCLPRCODI As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' PROCatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "CLASPRED "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "CLPRCODI = '" & CInt(inCLPRCODI) & "'"

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Buscar_CODIGO_CLASPRED")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que busca el ID del codigo buscado para ejecutar la consulta
    ''' parametrizada.
    ''' </summary>
    Public Function fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_CLASPRED(ByVal inCLPRIDRE As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' PROCatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "CLPRIDRE, "
            stConsultaSQL += "CLPRCODI, "
            stConsultaSQL += "CLPRDESC, "
            stConsultaSQL += "CLPRESTA  "

            stConsultaSQL += "FROM "
            stConsultaSQL += "CLASPRED "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "CLPRIDRE = '" & CInt(inCLPRIDRE) & "'"

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "CLPRCODI "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception

            MessageBox.Show(Err.Description & " " & "fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_CLASPRED")
            Return Nothing

        End Try

    End Function


End Class
