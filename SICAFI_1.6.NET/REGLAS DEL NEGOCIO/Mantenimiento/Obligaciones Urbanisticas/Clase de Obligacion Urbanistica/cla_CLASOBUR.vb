Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration
Imports DATOS

Public Class cla_CLASOBUR

    '==========================================
    '*** CLASE DE OBLIGACIONES URBANISTICAS ***
    '==========================================

    ''' <summary>
    ''' procedimiento que verifica la llave primaria.
    ''' </summary>
    Public Function fun_Verifica_llave_Primaria_MANT_CLASOBUR(ByVal obCLOUCODI As Object) As Boolean

        Try
            Dim boRespuesta As Boolean = False

            Dim obVerifica As New cla_Verificar_Dato

            If obVerifica.fun_Verificar_Campo_Lleno(obCLOUCODI.Text) = True Then

                If obVerifica.fun_Verificar_Dato_Numerico(obCLOUCODI.Text) = True Then

                    Dim objdatos1 As New cla_CLASOBUR
                    Dim tbl As New DataTable

                    tbl = objdatos1.fun_Buscar_CODIGO_CLASOBUR(Trim(obCLOUCODI.Text))

                    If tbl.Rows.Count > 0 Then
                        MessageBox.Show("El dato " & obCLOUCODI.Text & " del campo " & obCLOUCODI.AccessibleDescription & " existe en la base de datos.", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                        obCLOUCODI.Focus()
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
    Public Function fun_Insertar_MANT_CLASOBUR(ByVal inCLOUCODI As Integer, _
                                               ByVal stCLOUDESC As String, _
                                               ByVal stCLOUESTA As String) As Boolean

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' CLOUatena la consulta
            stConsultaSQL += "INSERT INTO "
            stConsultaSQL += "MANT_CLASOBUR "

            stConsultaSQL += "( "
            stConsultaSQL += "CLOUCODI, "
            stConsultaSQL += "CLOUDESC, "
            stConsultaSQL += "CLOUESTA "
            stConsultaSQL += ") "

            stConsultaSQL += "VALUES "

            stConsultaSQL += "( "
            stConsultaSQL += "'" & CInt(inCLOUCODI) & "', "
            stConsultaSQL += "'" & CStr(Trim(stCLOUDESC)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stCLOUESTA)) & "' "
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
            MessageBox.Show(Err.Description & " " & "fun_Insertar_MANT_CLASOBUR")
        End Try

    End Function

    ''' <summary>
    ''' Función que Elimina el registro.
    ''' </summary>
    Public Function fun_Eliminar_MANT_CLASOBUR(ByVal inCLOUIDRE As Integer) As Boolean

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' CLOUatena la consulta
            stConsultaSQL += "DELETE "
            stConsultaSQL += "MANT_CLASOBUR "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "CLOUIDRE = '" & CInt(inCLOUIDRE) & "' "

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
            MessageBox.Show(Err.Description & " " & "fun_Eliminar_MANT_CLASOBUR")
        End Try

    End Function

    ''' <summary>
    ''' Función que Modifica el registro.
    ''' </summary>
    Public Function fun_Actualizar_MANT_CLASOBUR(ByVal inCLOUIDRE As Integer, _
                                                 ByVal inCLOUCODI As Integer, _
                                                 ByVal stCLOUDESC As String, _
                                                 ByVal stCLOUESTA As String) As Boolean

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' CLOUatena la consulta
            stConsultaSQL += "UPDATE "
            stConsultaSQL += "MANT_CLASOBUR "

            stConsultaSQL += "SET "
            stConsultaSQL += "CLOUCODI = '" & CInt(inCLOUCODI) & "', "
            stConsultaSQL += "CLOUDESC = '" & CStr(Trim(stCLOUDESC)) & "', "
            stConsultaSQL += "CLOUESTA = '" & CStr(Trim(stCLOUESTA)) & "' "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "CLOUIDRE = '" & CInt(inCLOUIDRE) & "'"

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
            MessageBox.Show(Err.Description & " " & "fun_Actualizar_CLASOBUR")
        End Try

    End Function

    ''' <summary>
    ''' Consulta para llenar el DataGridView y colocar el nombre del encabezado
    ''' de la columna. 
    ''' </summary>
    Public Function fun_Consultar_MANT_CLASOBUR() As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' CLOUatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "CLOUIDRE, "
            stConsultaSQL += "CLOUCODI, "
            stConsultaSQL += "CLOUDESC, "
            stConsultaSQL += "CLOUESTA  "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MANT_CLASOBUR "

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "CLOUCODI "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Consultar_MANT_CLASOBUR")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Llena el ComboBox con datos activos e inactivos formulario principal 
    ''' esta funcion se llama desde el procedimiento "pro_inicializarControles()".
    ''' </summary>
    Public Function fun_Consultar_CAMPOS_MANT_CLASOBUR() As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' CLOUatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MANT_CLASOBUR "

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "CLOUCODI "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Consultar_CAMPOS_MANT_CLASOBUR")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Llena el ComboBox con datos activos formulario insertar y modificar 
    ''' esta funcion se llama desde el procedimiento "pro_inicializarControles()".
    ''' </summary>
    Public Function fun_Consultar_MANT_CLASOBUR_X_ESTADO() As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' CLOUatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MANT_CLASOBUR "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "CLOUESTA = 'ac' "

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "CLOUCODI "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Consultar_MANT_CLASOBUR_X_ESTADO")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que busca el ID del registro a modificar o eliminar.
    ''' </summary>
    Public Function fun_Buscar_ID_MANT_CLASOBUR(ByVal inCLOUIDRE As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' CLOUatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MANT_CLASOBUR "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "CLOUIDRE = '" & CInt(inCLOUIDRE) & "'"

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Buscar_ID_MANT_CLASOBUR")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que busca el CÓDIGO para que no se 
    ''' guarden registros duplicados.
    ''' </summary>
    Public Function fun_Buscar_CODIGO_CLASOBUR(ByVal inCLOUCODI As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' CLOUatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MANT_CLASOBUR "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "CLOUCODI = '" & CInt(inCLOUCODI) & "' "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Buscar_CODIGO_CLASOBUR")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que busca el CLASOBUR por el ID
    ''' </summary>
    Public Function fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_MANT_CLASOBUR(ByVal inCLOUIDRE As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' CLOUatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "CLOUIDRE, "
            stConsultaSQL += "CLOUCODI, "
            stConsultaSQL += "CLOUDESC, "
            stConsultaSQL += "CLOUESTA  "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MANT_CLASOBUR "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "CLOUIDRE = '" & CInt(inCLOUIDRE) & "'"

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "CLOUCODI "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception

            MessageBox.Show(Err.Description & " " & "fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_MANT_CLASOBUR")
            Return Nothing

        End Try

    End Function

End Class
