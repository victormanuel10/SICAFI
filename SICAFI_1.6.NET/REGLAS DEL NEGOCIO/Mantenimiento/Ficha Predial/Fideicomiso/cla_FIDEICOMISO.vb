Imports DATOS

Public Class cla_FIDEICOMISO

    ' ==============================
    ' *** CLASE MANT_FIDEICOMISO ***
    ' ==============================

    ''' <summary>
    ''' MANT_FIDEICOMISO que verifica la llave primaria.
    ''' </summary>
    Public Function fun_Verifica_llave_Primaria_MANT_FIDEICOMISO(ByVal obFIDECODI As Object) As Boolean

        Try
            Dim boRespuesta As Boolean = False

            Dim obVerifica As New cla_Verificar_Dato

            If obVerifica.fun_Verificar_Campo_Lleno(obFIDECODI.Text) = True Then

                Dim objdatos1 As New cla_FIDEICOMISO
                Dim tbl As New DataTable

                tbl = objdatos1.fun_Buscar_CODIGO_MANT_FIDEICOMISO(Trim(obFIDECODI.Text))

                If tbl.Rows.Count > 0 Then
                    MessageBox.Show("El dato " & obFIDECODI.Text & " del campo " & obFIDECODI.AccessibleDescription & " existe en la base de datos.", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                    obFIDECODI.Focus()
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
    Public Function fun_Insertar_MANT_FIDEICOMISO(ByVal inFIDECODI As Integer, _
                                                  ByVal stFIDEDESC As String, _
                                                  ByVal stFIDEESTA As String) As Boolean

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' PROCatena la consulta
            stConsultaSQL += "INSERT INTO "
            stConsultaSQL += "MANT_FIDEICOMISO "

            stConsultaSQL += "( "
            stConsultaSQL += "FIDECODI, "
            stConsultaSQL += "FIDEDESC, "
            stConsultaSQL += "FIDEESTA "
            stConsultaSQL += ") "

            stConsultaSQL += "VALUES "

            stConsultaSQL += "( "
            stConsultaSQL += "'" & CInt(inFIDECODI) & "', "
            stConsultaSQL += "'" & CStr(Trim(stFIDEDESC)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stFIDEESTA)) & "' "
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
            MessageBox.Show(Err.Description & " " & "fun_Insertar_MANT_FIDEICOMISO")
        End Try

    End Function

    ''' <summary>
    ''' Función que Elimina el registro.
    ''' </summary>
    Public Function fun_Eliminar_MANT_FIDEICOMISO(ByVal inFIDEIDRE As Integer) As Boolean

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' PROCatena la consulta
            stConsultaSQL += "DELETE "
            stConsultaSQL += "MANT_FIDEICOMISO "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "FIDEIDRE = '" & CInt(inFIDEIDRE) & "' "

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
            MessageBox.Show(Err.Description & " " & "fun_Eliminar_MANT_FIDEICOMISO")
        End Try

    End Function

    ''' <summary>
    ''' Función que Modifica el registro.
    ''' </summary>
    Public Function fun_Actualizar_MANT_FIDEICOMISO(ByVal inFIDEIDRE As Integer, _
                                                    ByVal inFIDECODI As Integer, _
                                                    ByVal stFIDEDESC As String, _
                                                    ByVal stFIDEESTA As String) As Boolean

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' PROCatena la consulta
            stConsultaSQL += "UPDATE "
            stConsultaSQL += "MANT_FIDEICOMISO "

            stConsultaSQL += "SET "
            stConsultaSQL += "FIDECODI = '" & CInt(inFIDECODI) & "', "
            stConsultaSQL += "FIDEDESC = '" & CStr(Trim(stFIDEDESC)) & "', "
            stConsultaSQL += "FIDEESTA = '" & CStr(Trim(stFIDEESTA)) & "' "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "FIDEIDRE = '" & CInt(inFIDEIDRE) & "'"

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
            MessageBox.Show(Err.Description & " " & "fun_Actualizar_MANT_FIDEICOMISO")
        End Try

    End Function

    ''' <summary>
    ''' Consulta para llenar el DataGridView y colocar el nombre del encabezado
    ''' de la columna. 
    ''' </summary>
    Public Function fun_Consultar_MANT_FIDEICOMISO() As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' PROCatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "FIDEIDRE, "
            stConsultaSQL += "FIDECODI, "
            stConsultaSQL += "FIDEDESC, "
            stConsultaSQL += "FIDEESTA  "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MANT_FIDEICOMISO "

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "FIDECODI "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Consultar_MANT_FIDEICOMISO")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Llena el ComboBox con datos activos e inactivos formulario principal 
    ''' esta funcion se llama desde el MANT_FIDEICOMISO "pro_inicializarControles()".
    ''' </summary>
    Public Function fun_Consultar_CAMPOS_MANT_FIDEICOMISO() As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' PROCatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MANT_FIDEICOMISO "

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "FIDECODI "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Consultar_CAMPOS_MANT_FIDEICOMISO")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Llena el ComboBox con datos activos formulario insertar y modificar 
    ''' esta funcion se llama desde el MANT_FIDEICOMISO "pro_inicializarControles()".
    ''' </summary>
    Public Function fun_Consultar_MANT_FIDEICOMISO_X_ESTADO() As DataTable

        Try
            Dim boInsertar As Boolean = True

            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' PROCatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MANT_FIDEICOMISO "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "FIDEESTA = 'ac' "

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "FIDECODI "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Consultar_MANT_FIDEICOMISO_X_ESTADO")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que busca el ID del registro a modificar o eliminar.
    ''' </summary>
    Public Function fun_Buscar_ID_MANT_FIDEICOMISO(ByVal inFIDEIDRE As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' PROCatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MANT_FIDEICOMISO "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "FIDEIDRE = '" & CInt(inFIDEIDRE) & "'"

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Buscar_ID_MANT_FIDEICOMISO")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que busca el CÓDIGO para que no se 
    ''' guarden registros duplicados.
    ''' </summary>
    Public Function fun_Buscar_CODIGO_MANT_FIDEICOMISO(ByVal inFIDECODI As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' PROCatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MANT_FIDEICOMISO "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "FIDECODI = '" & CInt(inFIDECODI) & "'"

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Buscar_CODIGO_MANT_FIDEICOMISO")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que busca el ID del codigo buscado para ejecutar la consulta
    ''' parametrizada.
    ''' </summary>
    Public Function fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_MANT_FIDEICOMISO(ByVal inFIDEIDRE As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' PROCatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "FIDEIDRE, "
            stConsultaSQL += "FIDECODI, "
            stConsultaSQL += "FIDEDESC, "
            stConsultaSQL += "FIDEESTA  "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MANT_FIDEICOMISO "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "FIDEIDRE = '" & CInt(inFIDEIDRE) & "'"

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "FIDECODI "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception

            MessageBox.Show(Err.Description & " " & "fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_MANT_FIDEICOMISO")
            Return Nothing

        End Try

    End Function


End Class
