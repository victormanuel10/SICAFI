Imports DATOS

Public Class cla_FIPRDIGI

    '=============================
    '*** FICHA PREDIAL DIGITAL ***
    '=============================

    ''' <summary>
    ''' Verifica que verifica la llave primaria.
    ''' </summary>
    Public Function fun_Verifica_llave_Primaria_MANT_FIPRDIGI(ByVal obFPDICODI As Object) As Boolean

        Try
            Dim boRespuesta As Boolean = False

            Dim obVerifica As New cla_Verificar_Dato

            If obVerifica.fun_Verificar_Campo_Lleno(obFPDICODI.Text) = True Then

                Dim objdatos1 As New cla_FIPRDIGI
                Dim tbl As New DataTable

                tbl = objdatos1.fun_Buscar_CODIGO_MANT_FIPRDIGI(Trim(obFPDICODI.Text))

                If tbl.Rows.Count > 0 Then
                    MessageBox.Show("El dato " & obFPDICODI.Text & " del campo " & obFPDICODI.AccessibleDescription & " existe en la base de datos.", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                    obFPDICODI.Focus()
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
    Public Function fun_Insertar_MANT_FIPRDIGI(ByVal inFPDICODI As Integer, _
                                               ByVal stFPDIDESC As String, _
                                               ByVal stFPDIESTA As String) As Boolean

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' PROCatena la consulta
            stConsultaSQL += "INSERT INTO "
            stConsultaSQL += "MANT_FIPRDIGI "

            stConsultaSQL += "( "
            stConsultaSQL += "FPDICODI, "
            stConsultaSQL += "FPDIDESC, "
            stConsultaSQL += "FPDIESTA "
            stConsultaSQL += ") "

            stConsultaSQL += "VALUES "

            stConsultaSQL += "( "
            stConsultaSQL += "'" & CInt(inFPDICODI) & "', "
            stConsultaSQL += "'" & CStr(Trim(stFPDIDESC)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stFPDIESTA)) & "' "
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
            MessageBox.Show(Err.Description & " " & "fun_Insertar_MANT_FIPRDIGI")
        End Try

    End Function

    ''' <summary>
    ''' Función que Elimina el registro.
    ''' </summary>
    Public Function fun_Eliminar_MANT_FIPRDIGI(ByVal inFPDIIDRE As Integer) As Boolean

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' PROCatena la consulta
            stConsultaSQL += "DELETE "
            stConsultaSQL += "MANT_FIPRDIGI "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "FPDIIDRE = '" & CInt(inFPDIIDRE) & "' "

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
            MessageBox.Show(Err.Description & " " & "fun_Eliminar_MANT_FIPRDIGI")
        End Try

    End Function

    ''' <summary>
    ''' Función que Modifica el registro.
    ''' </summary>
    Public Function fun_Actualizar_MANT_FIPRDIGI(ByVal inFPDIIDRE As Integer, _
                                                 ByVal inFPDICODI As Integer, _
                                                 ByVal stFPDIDESC As String, _
                                                 ByVal stFPDIESTA As String) As Boolean

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' PROCatena la consulta
            stConsultaSQL += "UPDATE "
            stConsultaSQL += "MANT_FIPRDIGI "

            stConsultaSQL += "SET "
            stConsultaSQL += "FPDICODI = '" & CInt(inFPDICODI) & "', "
            stConsultaSQL += "FPDIDESC = '" & CStr(Trim(stFPDIDESC)) & "', "
            stConsultaSQL += "FPDIESTA = '" & CStr(Trim(stFPDIESTA)) & "' "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "FPDIIDRE = '" & CInt(inFPDIIDRE) & "'"

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
            MessageBox.Show(Err.Description & " " & "fun_Actualizar_MANT_FIPRDIGI")
        End Try

    End Function

    ''' <summary>
    ''' Consulta para llenar el DataGridView y colocar el nombre del encabezado
    ''' de la columna. 
    ''' </summary>
    Public Function fun_Consultar_MANT_FIPRDIGI() As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' PROCatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "FPDIIDRE, "
            stConsultaSQL += "FPDICODI, "
            stConsultaSQL += "FPDIDESC, "
            stConsultaSQL += "FPDIESTA  "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MANT_FIPRDIGI "

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "FPDICODI "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Consultar_MANT_FIPRDIGI")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Llena el ComboBox con datos activos e inactivos formulario principal 
    ''' esta funcion se llama desde el MANT_FIPRDIGI "pro_inicializarControles()".
    ''' </summary>
    Public Function fun_Consultar_CAMPOS_MANT_FIPRDIGI() As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' PROCatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MANT_FIPRDIGI "

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "FPDICODI "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Consultar_CAMPOS_MANT_FIPRDIGI")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Llena el ComboBox con datos activos formulario insertar y modificar 
    ''' esta funcion se llama desde el MANT_FIPRDIGI "pro_inicializarControles()".
    ''' </summary>
    Public Function fun_Consultar_MANT_FIPRDIGI_X_ESTADO() As DataTable

        Try
            Dim boInsertar As Boolean = True

            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' PROCatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MANT_FIPRDIGI "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "FPDIESTA = 'ac' "

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "FPDICODI "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Consultar_MANT_FIPRDIGI_X_ESTADO")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que busca el ID del registro a modificar o eliminar.
    ''' </summary>
    Public Function fun_Buscar_ID_MANT_FIPRDIGI(ByVal inFPDIIDRE As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' PROCatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MANT_FIPRDIGI "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "FPDIIDRE = '" & CInt(inFPDIIDRE) & "'"

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Buscar_ID_MANT_FIPRDIGI")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que busca el CÓDIGO para que no se 
    ''' guarden registros duplicados.
    ''' </summary>
    Public Function fun_Buscar_CODIGO_MANT_FIPRDIGI(ByVal inFPDICODI As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' PROCatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MANT_FIPRDIGI "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "FPDICODI = '" & CInt(inFPDICODI) & "'"

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Buscar_CODIGO_MANT_FIPRDIGI")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que busca el ID del codigo buscado para ejecutar la consulta
    ''' parametrizada.
    ''' </summary>
    Public Function fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_MANT_FIPRDIGI(ByVal inFPDIIDRE As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' PROCatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "FPDIIDRE, "
            stConsultaSQL += "FPDICODI, "
            stConsultaSQL += "FPDIDESC, "
            stConsultaSQL += "FPDIESTA  "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MANT_FIPRDIGI "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "FPDIIDRE = '" & CInt(inFPDIIDRE) & "'"

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "FPDICODI "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception

            MessageBox.Show(Err.Description & " " & "fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_MANT_FIPRDIGI")
            Return Nothing

        End Try

    End Function


End Class
