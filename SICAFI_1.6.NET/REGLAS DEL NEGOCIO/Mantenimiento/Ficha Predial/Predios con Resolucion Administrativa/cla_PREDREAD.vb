Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration
Imports DATOS

Public Class cla_PREDREAD

    '=============================================
    '*** PREDIOS CON RESOLUCION ADMINISTRATIVA ***
    '=============================================

    ''' <summary>
    ''' procedimiento que verifica la llave primaria.
    ''' </summary>
    Public Function fun_Verifica_llave_Primaria_MANT_PREDREAD(ByVal obPRRATITR As Object, ByVal obPRRANUFI As Object) As Boolean

        Try
            Dim boRespuesta As Boolean = False

            Dim obVerifica As New cla_Verificar_Dato

            If obVerifica.fun_Verificar_Campo_Lleno(obPRRANUFI.Text) = True And _
               obVerifica.fun_Verificar_Campo_Lleno(obPRRATITR.SelectedValue) = True Then

                If obVerifica.fun_Verificar_Dato_Numerico(obPRRANUFI.Text) = True And _
                   obVerifica.fun_Verificar_Dato_Numerico(obPRRATITR.SelectedValue) = True Then


                    Dim objdatos1 As New cla_PREDREAD
                    Dim tbl As New DataTable

                    tbl = objdatos1.fun_Buscar_CODIGO_MANT_PREDREAD(obPRRATITR.SelectedValue, Trim(obPRRANUFI.Text))

                    If tbl.Rows.Count > 0 Then
                        MessageBox.Show("El dato " & obPRRATITR.Text & " - " & obPRRANUFI.Text & " del campo " & obPRRANUFI.AccessibleDescription & " existe en la base de datos.", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                        obPRRANUFI.Focus()
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
    Public Function fun_Insertar_MANT_PREDREAD(ByVal inPRRATITR As Integer, _
                                               ByVal inPRRANUFI As Integer, _
                                               ByVal inPRRARESO As Integer, _
                                               ByVal inPRRACLSE As Integer, _
                                               ByVal inPRRAVIGE As Integer, _
                                               ByVal inPRRAARTE As Integer, _
                                               ByVal stPRRAOBSE As String, _
                                               ByVal stPRRAESTA As String) As Boolean

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' concatena la consulta
            stConsultaSQL += "INSERT INTO "
            stConsultaSQL += "MANT_PREDREAD "

            stConsultaSQL += "( "
            stConsultaSQL += "PRRATITR, "
            stConsultaSQL += "PRRANUFI, "
            stConsultaSQL += "PRRARESO, "
            stConsultaSQL += "PRRACLSE, "
            stConsultaSQL += "PRRAVIGE, "
            stConsultaSQL += "PRRAARTE, "
            stConsultaSQL += "PRRAOBSE, "
            stConsultaSQL += "PRRAESTA "
            stConsultaSQL += ") "

            stConsultaSQL += "VALUES "

            stConsultaSQL += "( "
            stConsultaSQL += "'" & CInt(inPRRATITR) & "', "
            stConsultaSQL += "'" & CInt(inPRRANUFI) & "', "
            stConsultaSQL += "'" & CInt(inPRRARESO) & "', "
            stConsultaSQL += "'" & CInt(inPRRACLSE) & "', "
            stConsultaSQL += "'" & CInt(inPRRAVIGE) & "', "
            stConsultaSQL += "'" & CInt(inPRRAARTE) & "', "
            stConsultaSQL += "'" & CStr(Trim(stPRRAOBSE)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stPRRAESTA)) & "' "
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
            MessageBox.Show(Err.Description & " " & "fun_Insertar_MANT_PREDREAD")
        End Try

    End Function

    ''' <summary>
    ''' Función que Elimina el registro.
    ''' </summary>
    Public Function fun_Eliminar_MANT_PREDREAD(ByVal inPRRAIDRE As Integer) As Boolean

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' concatena la consulta
            stConsultaSQL += "DELETE "
            stConsultaSQL += "MANT_PREDREAD "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "PRRAIDRE = '" & CInt(inPRRAIDRE) & "' "

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
            MessageBox.Show(Err.Description & " " & "fun_Eliminar_MANT_PREDREAD")
        End Try

    End Function

    ''' <summary>
    ''' Función que Elimina el registro.
    ''' </summary>
    Public Function fun_Eliminar_TRAMITE_FICHA_MANT_PREDREAD(ByVal inPRRATITR As Integer, ByVal inPRRANUFI As Integer) As Boolean

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' concatena la consulta
            stConsultaSQL += "DELETE "
            stConsultaSQL += "MANT_PREDREAD "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "PRRATITR = '" & CInt(inPRRATITR) & "' AND "
            stConsultaSQL += "PRRANUFI = '" & CInt(inPRRANUFI) & "' "

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
            MessageBox.Show(Err.Description & " " & "fun_Eliminar_MANT_PREDREAD")
        End Try

    End Function

    ''' <summary>
    ''' Función que Modifica el registro.
    ''' </summary>
    Public Function fun_Actualizar_MANT_PREDREAD(ByVal inPRRAIDRE As Integer, _
                                                 ByVal inPRRATITR As Integer, _
                                                 ByVal inPRRANUFI As Integer, _
                                                 ByVal inPRRARESO As Integer, _
                                                 ByVal inPRRACLSE As Integer, _
                                                 ByVal inPRRAVIGE As Integer, _
                                                 ByVal inPRRAARTE As Integer, _
                                                 ByVal stPRRAOBSE As String, _
                                                 ByVal stPRRAESTA As String) As Boolean

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' concatena la consulta
            stConsultaSQL += "UPDATE "
            stConsultaSQL += "MANT_PREDREAD "

            stConsultaSQL += "SET "
            stConsultaSQL += "PRRATITR = '" & CInt(inPRRATITR) & "', "
            stConsultaSQL += "PRRANUFI = '" & CInt(inPRRANUFI) & "', "
            stConsultaSQL += "PRRARESO = '" & CInt(inPRRARESO) & "', "
            stConsultaSQL += "PRRACLSE = '" & CInt(inPRRACLSE) & "', "
            stConsultaSQL += "PRRAVIGE = '" & CInt(inPRRAVIGE) & "', "
            stConsultaSQL += "PRRAARTE = '" & CInt(inPRRAARTE) & "', "
            stConsultaSQL += "PRRAOBSE = '" & CStr(Trim(stPRRAOBSE)) & "', "
            stConsultaSQL += "PRRAESTA = '" & CStr(Trim(stPRRAESTA)) & "' "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "PRRAIDRE = '" & CInt(inPRRAIDRE) & "'"

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
            MessageBox.Show(Err.Description & " " & "fun_Actualizar_MANT_PREDREAD")
        End Try

    End Function

    ''' <summary>
    ''' Consulta para llenar el DataGridView y colocar el nombre del encabezado
    ''' de la columna. 
    ''' </summary>
    Public Function fun_Consultar_MANT_PREDREAD() As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "PRRAIDRE, "
            stConsultaSQL += "PRRATITR, "
            stConsultaSQL += "PRRANUFI, "
            stConsultaSQL += "PRRARESO, "
            stConsultaSQL += "PRRACLSE, "
            stConsultaSQL += "PRRAVIGE, "
            stConsultaSQL += "PRRAARTE, "
            stConsultaSQL += "PRRAOBSE, "
            stConsultaSQL += "PRRAESTA  "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MANT_PREDREAD "

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "PRRATITR, PRRACLSE, PRRAVIGE "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Consultar_MANT_PREDREAD")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Llena el ComboBox con datos activos e inactivos formulario principal 
    ''' esta funcion se llama desde el procedimiento "pro_inicializarControles()".
    ''' </summary>
    Public Function fun_Consultar_CAMPOS_MANT_PREDREAD() As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MANT_PREDREAD "

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "PRRATITR, PRRACLSE, PRRAVIGE "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Consultar_CAMPOS_MANT_PREDREAD")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Llena el ComboBox con datos activos formulario insertar y modificar 
    ''' esta funcion se llama desde el procedimiento "pro_inicializarControles()".
    ''' </summary>
    Public Function fun_Consultar_MANT_PREDREAD_X_ESTADO() As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MANT_PREDREAD "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "PRRAESTA = 'ac' "

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "PRRATITR, PRRACLSE, PRRAVIGE "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Consultar_MANT_PREDREAD_X_ESTADO")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que busca el ID del registro a modificar o eliminar.
    ''' </summary>
    Public Function fun_Buscar_ID_MANT_PREDREAD(ByVal inPRRAIDRE As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MANT_PREDREAD "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "PRRAIDRE = '" & CInt(inPRRAIDRE) & "'"

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Buscar_ID_MANT_PREDREAD")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que busca el ID del registro a modificar o eliminar.
    ''' </summary>
    Public Function fun_Buscar_NRO_FICHA_MANT_PREDREAD(ByVal inPRRANUFI As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MANT_PREDREAD "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "PRRANUFI = '" & CInt(inPRRANUFI) & "'"

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Buscar_NRO_FICHA_MANT_PREDREAD")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que busca el CÓDIGO para que no se 
    ''' guarden registros duplicados.
    ''' </summary>
    Public Function fun_Buscar_CODIGO_MANT_PREDREAD(ByVal inPRRATITR As Integer, ByVal inPRRANUFI As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MANT_PREDREAD "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "PRRATITR = '" & CInt(inPRRATITR) & "' and "
            stConsultaSQL += "PRRANUFI = '" & CInt(inPRRANUFI) & "' "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Buscar_CODIGO_MANT_PREDREAD")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que busca el MANT_PREDREAD por el ID
    ''' </summary>
    Public Function fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_MANT_PREDREAD(ByVal inPRRAIDRE As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "PRRAIDRE, "
            stConsultaSQL += "PRRATITR, "
            stConsultaSQL += "PRRANUFI, "
            stConsultaSQL += "PRRARESO, "
            stConsultaSQL += "PRRACLSE, "
            stConsultaSQL += "PRRAVIGE, "
            stConsultaSQL += "PRRAARTE, "
            stConsultaSQL += "PRRAOBSE, "
            stConsultaSQL += "PRRAESTA  "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MANT_PREDREAD "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "PRRAIDRE = '" & CInt(inPRRAIDRE) & "'"

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "PRRATITR, PRRACLSE, PRRAVIGE "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception

            MessageBox.Show(Err.Description & " " & "fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_MANT_PREDREAD")
            Return Nothing

        End Try

    End Function

    ''' <summary>
    ''' Función que busca el MANT_PREDREAD por tipo de tramite
    ''' </summary>
    Public Function fun_Buscar_CODIGO_MANT_PREDREAD_X_TIPOIMPU(ByVal inPRRATITR As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MANT_PREDREAD "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "PRRATITR = '" & CInt(inPRRATITR) & "' "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Buscar_CODIGO_MANT_PREDREAD_X_TIPOIMPU")
            Return Nothing
        End Try

    End Function

End Class
