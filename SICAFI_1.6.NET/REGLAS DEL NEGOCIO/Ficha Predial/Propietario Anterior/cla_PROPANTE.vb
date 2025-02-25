Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration
Imports DATOS

Public Class cla_PROPANTE

    '==================================
    '*** CLASE PROPIETARIO ANTERIOR ***
    '==================================

    ''' <summary>
    ''' procedimiento que verifica la llave primaria.
    ''' </summary>
    Public Function fun_Verifica_llave_Primaria_PROPANTE(ByVal obPRANNUFI As Object, ByVal obPRANNUDO As Object) As Boolean

        Try
            Dim boRespuesta As Boolean = False

            Dim obVerifica As New cla_Verificar_Dato

            If obVerifica.fun_Verificar_Campo_Lleno(obPRANNUFI.Text) = True And obVerifica.fun_Verificar_Campo_Lleno(obPRANNUDO.Text) = True Then
                If obVerifica.fun_Verificar_Dato_Numerico(obPRANNUFI.Text) = True Then

                    Dim objdatos1 As New cla_PROPANTE
                    Dim tbl As New DataTable

                    tbl = objdatos1.fun_Buscar_CODIGO_PROPANTE(Trim(obPRANNUFI.Text), Trim(obPRANNUDO.Text))

                    If tbl.Rows.Count > 0 Then
                        MessageBox.Show("El dato " & obPRANNUFI.Text & " - " & obPRANNUDO.Text & " del campo " & obPRANNUDO.AccessibleDescription & " existe en la base de datos.", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                        obPRANNUFI.Focus()
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
    Public Function fun_Insertar_PROPANTE(ByVal inPRANNUFI As Integer, _
                                          ByVal stPRANNUDO As String, _
                                          ByVal stPRANPRAP As String, _
                                          ByVal stPRANSEAP As String, _
                                          ByVal stPRANNOMB As String, _
                                          ByVal stPRANCAAC As String, _
                                          ByVal stPRANOBSE As String, _
                                          ByVal stPRANESTA As String) As Boolean

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "INSERT INTO "
            stConsultaSQL += "PROPANTE "

            stConsultaSQL += "( "
            stConsultaSQL += "PRANNUFI, "
            stConsultaSQL += "PRANNUDO, "
            stConsultaSQL += "PRANPRAP, "
            stConsultaSQL += "PRANSEAP, "
            stConsultaSQL += "PRANNOMB, "
            stConsultaSQL += "PRANCAAC, "
            stConsultaSQL += "PRANOBSE, "
            stConsultaSQL += "PRANESTA "
            stConsultaSQL += ") "

            stConsultaSQL += "VALUES "

            stConsultaSQL += "( "
            stConsultaSQL += "'" & CInt(inPRANNUFI) & "', "
            stConsultaSQL += "'" & CStr(Trim(stPRANNUDO)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stPRANPRAP)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stPRANSEAP)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stPRANNOMB)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stPRANCAAC)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stPRANOBSE)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stPRANESTA)) & "' "
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
            MessageBox.Show(Err.Description & " " & "fun_Insertar_PROPANTE")
        End Try

    End Function

    ''' <summary>
    ''' Función que Elimina el registro.
    ''' </summary>
    Public Function fun_Eliminar_PROPANTE(ByVal inPRANIDRE As Integer) As Boolean

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "DELETE "
            stConsultaSQL += "PROPANTE "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "PRANIDRE = '" & CInt(inPRANIDRE) & "' "

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
            MessageBox.Show(Err.Description & " " & "fun_Eliminar_PROPANTE")
        End Try

    End Function

    ''' <summary>
    ''' Función que Elimina el registro.
    ''' </summary>
    Public Function fun_Eliminar_PROPANTE_X_NRO_FICHA_Y_NRO_DOCUMENTO(ByVal stPRANNUFI As String, ByVal stPRANNUDO As String) As Boolean

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "DELETE "
            stConsultaSQL += "PROPANTE "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "PRANNUFI = '" & CStr(Trim(stPRANNUFI)) & "' and "
            stConsultaSQL += "PRANNUDO = '" & CStr(Trim(stPRANNUDO)) & "' "

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
            MessageBox.Show(Err.Description & " " & "fun_Eliminar_PROPANTE")
        End Try

    End Function

    ''' <summary>
    ''' Función que Elimina el registro.
    ''' </summary>
    Public Function fun_Eliminar_PROPANTE_X_NRO_FICHA(ByVal stPRANNUFI As String) As Boolean

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "DELETE "
            stConsultaSQL += "PROPANTE "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "PRANNUFI = '" & CStr(Trim(stPRANNUFI)) & "' "

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
            MessageBox.Show(Err.Description & " " & "fun_Eliminar_PROPANTE")
        End Try

    End Function

    ''' <summary>
    ''' Función que Modifica el registro.
    ''' </summary>
    Public Function fun_Actualizar_PROPANTE(ByVal inPRANNUFI As Integer, _
                                          ByVal stPRANNUDO As String, _
                                          ByVal stPRANPRAP As String, _
                                          ByVal stPRANSEAP As String, _
                                          ByVal stPRANNOMB As String, _
                                          ByVal stPRANCAAC As String, _
                                          ByVal stPRANOBSE As String, _
                                          ByVal stPRANESTA As String) As Boolean

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "UPDATE "
            stConsultaSQL += "PROPANTE "

            stConsultaSQL += "SET "
            stConsultaSQL += "PRANNUDO = '" & CStr(Trim(stPRANNUDO)) & "', "
            stConsultaSQL += "PRANPRAP = '" & CStr(Trim(stPRANPRAP)) & "', "
            stConsultaSQL += "PRANSEAP = '" & CStr(Trim(stPRANSEAP)) & "', "
            stConsultaSQL += "PRANNOMB = '" & CStr(Trim(stPRANNOMB)) & "', "
            stConsultaSQL += "PRANCAAC = '" & CStr(Trim(stPRANCAAC)) & "', "
            stConsultaSQL += "PRANOBSE = '" & CStr(Trim(stPRANOBSE)) & "', "
            stConsultaSQL += "PRANESTA = '" & CStr(Trim(stPRANESTA)) & "' "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "PRANNUFI = '" & CInt(inPRANNUFI) & "' and "
            stConsultaSQL += "PRANNUDO = '" & CStr(Trim(stPRANNUDO)) & "' "

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
            MessageBox.Show(Err.Description & " " & "fun_Actualizar_PROPANTE")
        End Try

    End Function

    ''' <summary>
    ''' Consulta para llenar el DataGridView y colocar el nombre del encabezado
    ''' de la columna. 
    ''' </summary>
    Public Function fun_Consultar_PROPANTE() As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "PRANIDRE, "
            stConsultaSQL += "PRANNUFI, "
            stConsultaSQL += "PRANNUDO, "
            stConsultaSQL += "PRANPRAP, "
            stConsultaSQL += "PRANSEAP, "
            stConsultaSQL += "PRANNOMB, "
            stConsultaSQL += "PRANCAAC, "
            stConsultaSQL += "PRANOBSE, "
            stConsultaSQL += "PRANESTA "

            stConsultaSQL += "FROM "
            stConsultaSQL += "PROPANTE "

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "PRANNUFI, PRANNUDO "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Consultar_PROPANTE")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Llena el ComboBox con datos activos e inactivos formulario principal 
    ''' esta funcion se llama desde el procedimiento "pro_inicializarControles()".
    ''' </summary>
    Public Function fun_Consultar_CAMPOS_PROPANTE() As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "PROPANTE "

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "PRANNUFI, PRANNUDO "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Consultar_CAMPOS_PROPANTE")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Llena el ComboBox con datos activos formulario insertar y modificar 
    ''' esta funcion se llama desde el procedimiento "pro_inicializarControles()".
    ''' </summary>
    Public Function fun_Consultar_PROPANTE_X_ESTADO() As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "PROPANTE "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "PRANESTA = 'ac' "

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "PRANNUFI, PRANNUDO "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Consultar_PROPANTE_X_ESTADO")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que busca el ID del registro a modificar o eliminar.
    ''' </summary>
    Public Function fun_Buscar_ID_PROPANTE(ByVal inPRANIDRE As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "PROPANTE "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "PRANIDRE = '" & CInt(inPRANIDRE) & "'"

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Buscar_ID_PROPANTE")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que busca los propietarios anteriores por numero de ficha 
    ''' </summary>
    Public Function fun_Buscar_PROPIETARIOS_X_NRO_DE_FICHA(ByVal inPRANNUFI As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "PROPANTE "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "PRANNUFI = '" & CInt(inPRANNUFI) & "' "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Buscar_CODIGO_PROPANTE")
            Return Nothing
        End Try

    End Function
    ''' <summary>
    ''' Función que busca los propietarios anteriores por numero de ficha 
    ''' </summary>
    Public Function fun_Buscar_PROPIETARIOS_X_NRO_DE_FICHA_Y_NRO_DE_DOCUMENTO(ByVal inPRANNUFI As Integer, ByVal stPRANNUDO As String) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "PROPANTE "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "PRANNUFI = '" & CInt(inPRANNUFI) & "' and "
            stConsultaSQL += "PRANNUDO = '" & Trim(CStr(stPRANNUDO)) & "' "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Buscar_CODIGO_PROPANTE")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que busca el CÓDIGO DE LA CALIDAD DE PROPIETARIO para que no se 
    ''' guarden registros duplicados.
    ''' </summary>
    Public Function fun_Buscar_CODIGO_PROPANTE(ByVal inPRANNUFI As Integer, ByVal stPRANNUDO As String) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "PROPANTE "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "PRANNUFI = '" & CInt(inPRANNUFI) & "' and "
            stConsultaSQL += "PRANNUDO = '" & CStr(Trim(stPRANNUDO)) & "' "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Buscar_CODIGO_PROPANTE")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que busca el ID del codigo buscado para ejecutar la consulta
    ''' parametrizada.
    ''' </summary>
    Public Function fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_PROPANTE(ByVal inPRANIDRE As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "PRANIDRE, "
            stConsultaSQL += "PRANNUFI, "
            stConsultaSQL += "PRANNUDO, "
            stConsultaSQL += "PRANPRAP, "
            stConsultaSQL += "PRANSEAP, "
            stConsultaSQL += "PRANNOMB, "
            stConsultaSQL += "PRANCAAC, "
            stConsultaSQL += "PRANOBSE, "
            stConsultaSQL += "PRANESTA "

            stConsultaSQL += "FROM "
            stConsultaSQL += "PROPANTE "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "PRANIDRE = '" & CInt(inPRANIDRE) & "'"

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "PRANNUFI, PRANNUDO "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception

            MessageBox.Show(Err.Description & " " & "fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_PROPANTE")
            Return Nothing

        End Try

    End Function



End Class
