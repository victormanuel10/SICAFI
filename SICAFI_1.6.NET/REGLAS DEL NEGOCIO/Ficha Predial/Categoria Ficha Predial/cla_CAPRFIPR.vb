Imports DATOS

Public Class cla_CAPRFIPR

    '=========================================
    '*** CATEGORIA DE PREDIO FICHA PREDIAL ***
    '=========================================

    ''' <summary>
    ''' procedimiento que verifica la llave primaria.
    ''' </summary>
    Public Function fun_Verifica_llave_Primaria_CAPRFIPR(ByVal obCPFPNUFI As Object, ByVal obCPFPCAPR As Object) As Boolean

        Try
            Dim boRespuesta As Boolean = False

            Dim obVerifica As New cla_Verificar_Dato

            If obVerifica.fun_Verificar_Campo_Lleno(obCPFPNUFI.Text) = True And obVerifica.fun_Verificar_Campo_Lleno(obCPFPCAPR.Text) = True Then
                If obVerifica.fun_Verificar_Dato_Numerico(obCPFPNUFI.Text) = True And obVerifica.fun_Verificar_Dato_Numerico(obCPFPCAPR.Text) = True Then

                    Dim objdatos1 As New cla_CAPRFIPR
                    Dim tbl As New DataTable

                    tbl = objdatos1.fun_Buscar_CODIGO_CAPRFIPR(Trim(obCPFPNUFI.Text), Trim(obCPFPCAPR.Text))

                    If tbl.Rows.Count > 0 Then
                        MessageBox.Show("El dato " & obCPFPNUFI.Text & " - " & obCPFPCAPR.Text & " del campo " & obCPFPCAPR.AccessibleDescription & " existe en la base de datos.", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                        obCPFPNUFI.Focus()
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
    Public Function fun_Insertar_CAPRFIPR(ByVal inCPFPNUFI As Integer, _
                                          ByVal inCPFPCAPR As Integer, _
                                          ByVal stCPFPESTA As String) As Boolean

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "INSERT INTO "
            stConsultaSQL += "CAPRFIPR "

            stConsultaSQL += "( "
            stConsultaSQL += "CPFPNUFI, "
            stConsultaSQL += "CPFPCAPR, "
            stConsultaSQL += "CPFPESTA "
            stConsultaSQL += ") "

            stConsultaSQL += "VALUES "

            stConsultaSQL += "( "
            stConsultaSQL += "'" & CInt(inCPFPNUFI) & "', "
            stConsultaSQL += "'" & CInt(inCPFPCAPR) & "', "
            stConsultaSQL += "'" & CStr(Trim(stCPFPESTA)) & "' "
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
            MessageBox.Show(Err.Description & " " & "fun_Insertar_CAPRFIPR")
        End Try

    End Function

    ''' <summary>
    ''' Función que Elimina el registro.
    ''' </summary>
    Public Function fun_Eliminar_CAPRFIPR(ByVal inCPFPIDRE As Integer) As Boolean

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "DELETE "
            stConsultaSQL += "CAPRFIPR "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "CPFPIDRE = '" & CInt(inCPFPIDRE) & "' "

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
            MessageBox.Show(Err.Description & " " & "fun_Eliminar_CAPRFIPR")
        End Try

    End Function

    ''' <summary>
    ''' Función que Elimina el registro.
    ''' </summary>
    Public Function fun_Eliminar_CAPRFIPR_X_NRO_FICHA_Y_CATEGORIA(ByVal inCPFPNUFI As Integer, ByVal inCPFPCAPR As Integer) As Boolean

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "DELETE "
            stConsultaSQL += "CAPRFIPR "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "CPFPNUFI = '" & CInt(inCPFPNUFI) & "' and "
            stConsultaSQL += "CPFPCAPR = '" & CInt(inCPFPCAPR) & "' "

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
            MessageBox.Show(Err.Description & " " & "fun_Eliminar_CAPRFIPR")
        End Try

    End Function

    ''' <summary>
    ''' Función que Modifica el registro.
    ''' </summary>
    Public Function fun_Actualizar_CAPRFIPR(ByVal inCPFPNUFI As Integer, _
                                            ByVal inCPFPCAPR As Integer, _
                                            ByVal stCPFPESTA As String) As Boolean

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "UPDATE "
            stConsultaSQL += "CAPRFIPR "

            stConsultaSQL += "SET "
            stConsultaSQL += "CPFPNUFI = '" & CInt(inCPFPNUFI) & "', "
            stConsultaSQL += "CPFPCAPR = '" & CInt(inCPFPCAPR) & "', "
            stConsultaSQL += "CPFPESTA = '" & CStr(Trim(stCPFPESTA)) & "' "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "CPFPNUFI = '" & CInt(inCPFPNUFI) & "' and "
            stConsultaSQL += "CPFPCAPR = '" & CInt(inCPFPCAPR) & "' "

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
            MessageBox.Show(Err.Description & " " & "fun_Actualizar_CAPRFIPR")
        End Try

    End Function

    ''' <summary>
    ''' Consulta para llenar el DataGridView y colocar el nombre del encabezado
    ''' de la columna. 
    ''' </summary>
    Public Function fun_Consultar_CAPRFIPR() As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "CPFPIDRE, "
            stConsultaSQL += "CPFPNUFI, "
            stConsultaSQL += "CPFPCAPR, "
            stConsultaSQL += "CPFPESTA "

            stConsultaSQL += "FROM "
            stConsultaSQL += "CAPRFIPR "

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "CPFPNUFI, CPFPCAPR "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Consultar_CAPRFIPR")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Llena el ComboBox con datos activos e inactivos formulario principal 
    ''' esta funcion se llama desde el procedimiento "pro_inicializarControles()".
    ''' </summary>
    Public Function fun_Consultar_CAMPOS_CAPRFIPR() As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "CAPRFIPR "

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "CPFPNUFI, CPFPCAPR "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Consultar_CAMPOS_CAPRFIPR")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Llena el ComboBox con datos activos formulario insertar y modificar 
    ''' esta funcion se llama desde el procedimiento "pro_inicializarControles()".
    ''' </summary>
    Public Function fun_Consultar_CAPRFIPR_X_ESTADO() As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "CAPRFIPR "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "CPFPESTA = 'ac' "

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "CPFPNUFI, CPFPCAPR "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Consultar_CAPRFIPR_X_ESTADO")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que busca el ID del registro a modificar o eliminar.
    ''' </summary>
    Public Function fun_Buscar_ID_CAPRFIPR(ByVal inCPFPIDRE As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "CAPRFIPR "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "CPFPIDRE = '" & CInt(inCPFPIDRE) & "'"

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Buscar_ID_CAPRFIPR")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que busca los propietarios anteriores por numero de ficha 
    ''' </summary>
    Public Function fun_Buscar_CATEGORIA_X_NRO_DE_FICHA(ByVal inCPFPNUFI As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "CAPRFIPR "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "CPFPNUFI = '" & CInt(inCPFPNUFI) & "' "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Buscar_CODIGO_CAPRFIPR")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que busca los propietarios anteriores por numero de ficha 
    ''' </summary>
    Public Function fun_Buscar_CATEGORIA_X_NRO_DE_FICHA_Y_CATEGORIA(ByVal inCPFPNUFI As Integer, ByVal inCPFPCAPR As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "CAPRFIPR "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "CPFPNUFI = '" & CInt(inCPFPNUFI) & "' and "
            stConsultaSQL += "CPFPCAPR = '" & CInt(inCPFPCAPR) & "' "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Buscar_CODIGO_CAPRFIPR")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que busca el CÓDIGO DE LA CALIDAD DE PROPIETARIO para que no se 
    ''' guarden registros duplicados.
    ''' </summary>
    Public Function fun_Buscar_CODIGO_CAPRFIPR(ByVal inCPFPNUFI As Integer, ByVal inCPFPCAPR As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "CAPRFIPR "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "CPFPNUFI = '" & CInt(inCPFPNUFI) & "' and "
            stConsultaSQL += "CPFPCAPR = '" & CInt(inCPFPCAPR) & "' "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Buscar_CODIGO_CAPRFIPR")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que busca el ID del codigo buscado para ejecutar la consulta
    ''' parametrizada.
    ''' </summary>
    Public Function fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_CAPRFIPR(ByVal inCPFPIDRE As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "CPFPIDRE, "
            stConsultaSQL += "CPFPNUFI, "
            stConsultaSQL += "CPFPCAPR, "
            stConsultaSQL += "CPFPESTA "

            stConsultaSQL += "FROM "
            stConsultaSQL += "CAPRFIPR "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "CPFPIDRE = '" & CInt(inCPFPIDRE) & "'"

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "CPFPNUFI, CPFPCAPR "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception

            MessageBox.Show(Err.Description & " " & "fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_CAPRFIPR")
            Return Nothing

        End Try

    End Function

End Class
