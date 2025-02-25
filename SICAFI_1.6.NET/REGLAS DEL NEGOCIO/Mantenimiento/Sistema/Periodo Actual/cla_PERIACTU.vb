Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration
Imports DATOS

Public Class cla_PERIACTU

    '============================
    '*** CLASE PERIODO ACTUAL ***
    '============================

    ''' <summary>
    ''' procedimiento que verifica la llave primaria.
    ''' </summary>
    Public Function fun_Verifica_llave_Primaria_MANT_PERIACTU(ByVal obPEACCODI As Object) As Boolean

        Try
            Dim boRespuesta As Boolean = False

            Dim obVerifica As New cla_Verificar_Dato

            If obVerifica.fun_Verificar_Campo_Lleno(obPEACCODI.Text) = True Then
                If obVerifica.fun_Verificar_Dato_Numerico(obPEACCODI.Text) = True Then

                    Dim objdatos1 As New cla_PERIACTU
                    Dim tbl As New DataTable

                    tbl = objdatos1.fun_Buscar_CODIGO_MANT_PERIACTU(Trim(obPEACCODI.Text))

                    If tbl.Rows.Count > 0 Then
                        MessageBox.Show("El dato " & obPEACCODI.Text & " del campo " & obPEACCODI.AccessibleDescription & " existe en la base de datos.", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                        obPEACCODI.Focus()
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
    Public Function fun_Insertar_MANT_PERIACTU(ByVal inPEACCODI As Integer, _
                                               ByVal stPEACDESC As String, _
                                               ByVal boPEACPEAC As Boolean, _
                                               ByVal stPEACESTA As String) As Boolean

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "INSERT INTO "
            stConsultaSQL += "MANT_PERIACTU "

            stConsultaSQL += "( "
            stConsultaSQL += "PEACCODI, "
            stConsultaSQL += "PEACDESC, "
            stConsultaSQL += "PEACPEAC, "
            stConsultaSQL += "PEACESTA "
            stConsultaSQL += ") "

            stConsultaSQL += "VALUES "

            stConsultaSQL += "( "
            stConsultaSQL += "'" & CInt(inPEACCODI) & "', "
            stConsultaSQL += "'" & CStr(Trim(stPEACDESC)) & "', "
            stConsultaSQL += "'" & CBool(boPEACPEAC) & "', "
            stConsultaSQL += "'" & CStr(Trim(stPEACESTA)) & "' "
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
            MessageBox.Show(Err.Description & " " & "fun_Insertar_MANT_PERIACTU")
        End Try

    End Function

    ''' <summary>
    ''' Función que Elimina el registro.
    ''' </summary>
    Public Function fun_Eliminar_MANT_PERIACTU(ByVal inPEACIDRE As Integer) As Boolean

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "DELETE "
            stConsultaSQL += "MANT_PERIACTU "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "PEACIDRE = '" & CInt(inPEACIDRE) & "' "

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
            MessageBox.Show(Err.Description & " " & "fun_Eliminar_MANT_PERIACTU")
        End Try

    End Function

    ''' <summary>
    ''' Función que Modifica el registro.
    ''' </summary>
    Public Function fun_Actualizar_MANT_PERIACTU(ByVal inPEACIDRE As Integer, _
                                                 ByVal inPEACCODI As Integer, _
                                                 ByVal stPEACDESC As String, _
                                                 ByVal boPEACPEAC As Boolean, _
                                                 ByVal stPEACESTA As String) As Boolean

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "UPDATE "
            stConsultaSQL += "MANT_PERIACTU "

            stConsultaSQL += "SET "
            stConsultaSQL += "PEACCODI = '" & CInt(inPEACCODI) & "', "
            stConsultaSQL += "PEACDESC = '" & CStr(Trim(stPEACDESC)) & "', "
            stConsultaSQL += "PEACPEAC = '" & CBool(boPEACPEAC) & "', "
            stConsultaSQL += "PEACESTA = '" & CStr(Trim(stPEACESTA)) & "' "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "PEACIDRE = '" & CInt(inPEACIDRE) & "'"

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
            MessageBox.Show(Err.Description & " " & "fun_Actualizar_MANT_PERIACTU")
        End Try

    End Function

    ''' <summary>
    ''' Consulta para llenar el DataGridView y colocar el nombre del encabezado
    ''' de la columna. 
    ''' </summary>
    Public Function fun_Consultar_MANT_PERIACTU() As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "PEACIDRE as 'Sec', "
            stConsultaSQL += "PEACCODI as 'Vigencia', "
            stConsultaSQL += "PEACDESC as 'Descripción', "
            stConsultaSQL += "PEACPEAC as 'Periodo actual', "
            stConsultaSQL += "PEACESTA as 'Estado' "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MANT_PERIACTU "

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "PEACCODI "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Consultar_MANT_PERIACTU")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Llena el ComboBox con datos activos e inactivos formulario principal 
    ''' esta funcion se llama desde el procedimiento "pro_inicializarControles()".
    ''' </summary>
    Public Function fun_Consultar_CAMPOS_MANT_PERIACTU() As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MANT_PERIACTU "

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "PEACCODI "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Consultar_CAMPOS_MANT_PERIACTU")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Llena el ComboBox con datos activos formulario insertar y modificar 
    ''' esta funcion se llama desde el procedimiento "pro_inicializarControles()".
    ''' </summary>
    Public Function fun_Consultar_MANT_PERIACTU_X_ESTADO() As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MANT_PERIACTU "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "PEACESTA = 'ac' "

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "PEACCODI "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Consultar_MANT_PERIACTU_X_ESTADO")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que busca el ID del registro a modificar o eliminar.
    ''' </summary>
    Public Function fun_Buscar_ID_MANT_PERIACTU(ByVal inPEACIDRE As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MANT_PERIACTU "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "PEACIDRE = '" & CInt(inPEACIDRE) & "'"

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Buscar_ID_MANT_PERIACTU")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que busca el CÓDIGO DE LA CALIDAD DE PROPIETARIO para que no se 
    ''' guarden registros duplicados.
    ''' </summary>
    Public Function fun_Buscar_CODIGO_MANT_PERIACTU(ByVal inPEACCODI As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MANT_PERIACTU "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "PEACCODI = '" & CInt(inPEACCODI) & "'"

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Buscar_CODIGO_MANT_PERIACTU")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que busca el ID del codigo buscado para ejecutar la consulta
    ''' parametrizada.
    ''' </summary>
    Public Function fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_MANT_PERIACTU(ByVal inPEACIDRE As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "PEACIDRE as 'Sec', "
            stConsultaSQL += "PEACCODI as 'Vigencia', "
            stConsultaSQL += "PEACDESC as 'Descripción', "
            stConsultaSQL += "PEACPEAC as 'Periodo actual', "
            stConsultaSQL += "PEACESTA as 'Estado' "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MANT_PERIACTU "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "PEACIDRE = '" & CInt(inPEACIDRE) & "'"

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "PEACCODI "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception

            MessageBox.Show(Err.Description & " " & "fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_MANT_PERIACTU")
            Return Nothing

        End Try

    End Function

    ''' <summary>
    ''' devuelve la vigencia actual
    ''' </summary>
    Public Function fun_Consultar_VIGENCIA_ACTUAL_X_MANT_PERIACTU() As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "PEACCODI, "
            stConsultaSQL += "PEACDESC "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MANT_PERIACTU "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "PEACPEAC = '1' "

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "PEACCODI "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Consultar_MANT_PERIACTU_X_ESTADO")
            Return Nothing
        End Try

    End Function

End Class
