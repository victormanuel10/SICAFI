Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration
Imports DATOS

Public Class cla_ZONAPLAN

    '=============================
    '*** ZONA DE PLANIFICACION ***
    '=============================

    ''' <summary>
    ''' procedimiento que verifica la llave primaria.
    ''' </summary>
    Public Function fun_Verifica_llave_Primaria_MANT_ZONAPLAN(ByVal obZOPLCODI As Object) As Boolean

        Try
            Dim boRespuesta As Boolean = False

            Dim obVerifica As New cla_Verificar_Dato

            If obVerifica.fun_Verificar_Campo_Lleno(obZOPLCODI.Text) = True Then

                If obVerifica.fun_Verificar_Dato_Numerico(obZOPLCODI.Text) = True Then

                    Dim objdatos1 As New cla_ZONAPLAN
                    Dim tbl As New DataTable

                    tbl = objdatos1.fun_Buscar_CODIGO_ZONAPLAN(Trim(obZOPLCODI.Text))

                    If tbl.Rows.Count > 0 Then
                        MessageBox.Show("El dato " & obZOPLCODI.Text & " del campo " & obZOPLCODI.AccessibleDescription & " existe en la base de datos.", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                        obZOPLCODI.Focus()
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
    Public Function fun_Insertar_MANT_ZONAPLAN(ByVal inZOPLCODI As Integer, _
                                               ByVal stZOPLDESC As String, _
                                               ByVal stZOPLESTA As String) As Boolean

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' ZOPLatena la consulta
            stConsultaSQL += "INSERT INTO "
            stConsultaSQL += "MANT_ZONAPLAN "

            stConsultaSQL += "( "
            stConsultaSQL += "ZOPLCODI, "
            stConsultaSQL += "ZOPLDESC, "
            stConsultaSQL += "ZOPLESTA "
            stConsultaSQL += ") "

            stConsultaSQL += "VALUES "

            stConsultaSQL += "( "
            stConsultaSQL += "'" & CInt(inZOPLCODI) & "', "
            stConsultaSQL += "'" & CStr(Trim(stZOPLDESC)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stZOPLESTA)) & "' "
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
            MessageBox.Show(Err.Description & " " & "fun_Insertar_MANT_ZONAPLAN")
        End Try

    End Function

    ''' <summary>
    ''' Función que Elimina el registro.
    ''' </summary>
    Public Function fun_Eliminar_MANT_ZONAPLAN(ByVal inZOPLIDRE As Integer) As Boolean

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' ZOPLatena la consulta
            stConsultaSQL += "DELETE "
            stConsultaSQL += "MANT_ZONAPLAN "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "ZOPLIDRE = '" & CInt(inZOPLIDRE) & "' "

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
            MessageBox.Show(Err.Description & " " & "fun_Eliminar_MANT_ZONAPLAN")
        End Try

    End Function

    ''' <summary>
    ''' Función que Modifica el registro.
    ''' </summary>
    Public Function fun_Actualizar_MANT_ZONAPLAN(ByVal inZOPLIDRE As Integer, _
                                                 ByVal inZOPLCODI As Integer, _
                                                 ByVal stZOPLDESC As String, _
                                                 ByVal stZOPLESTA As String) As Boolean

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' ZOPLatena la consulta
            stConsultaSQL += "UPDATE "
            stConsultaSQL += "MANT_ZONAPLAN "

            stConsultaSQL += "SET "
            stConsultaSQL += "ZOPLCODI = '" & CInt(inZOPLCODI) & "', "
            stConsultaSQL += "ZOPLDESC = '" & CStr(Trim(stZOPLDESC)) & "', "
            stConsultaSQL += "ZOPLESTA = '" & CStr(Trim(stZOPLESTA)) & "' "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "ZOPLIDRE = '" & CInt(inZOPLIDRE) & "'"

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
            MessageBox.Show(Err.Description & " " & "fun_Actualizar_ZONAPLAN")
        End Try

    End Function

    ''' <summary>
    ''' Consulta para llenar el DataGridView y colocar el nombre del encabezado
    ''' de la columna. 
    ''' </summary>
    Public Function fun_Consultar_MANT_ZONAPLAN() As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' ZOPLatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "ZOPLIDRE, "
            stConsultaSQL += "ZOPLCODI, "
            stConsultaSQL += "ZOPLDESC, "
            stConsultaSQL += "ESTADESC, "
            stConsultaSQL += "ZOPLESTA  "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MANT_ZONAPLAN, ESTADO "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "ZOPLESTA = ESTACODI "

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "ZOPLCODI "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Consultar_MANT_ZONAPLAN")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Llena el ComboBox con datos activos e inactivos formulario principal 
    ''' esta funcion se llama desde el procedimiento "pro_inicializarControles()".
    ''' </summary>
    Public Function fun_Consultar_CAMPOS_MANT_ZONAPLAN() As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' ZOPLatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MANT_ZONAPLAN "

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "ZOPLCODI "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Consultar_CAMPOS_MANT_ZONAPLAN")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Llena el ComboBox con datos activos formulario insertar y modificar 
    ''' esta funcion se llama desde el procedimiento "pro_inicializarControles()".
    ''' </summary>
    Public Function fun_Consultar_MANT_ZONAPLAN_X_ESTADO() As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' ZOPLatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MANT_ZONAPLAN "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "ZOPLESTA = 'ac' "

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "ZOPLCODI "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Consultar_MANT_ZONAPLAN_X_ESTADO")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que busca el ID del registro a modificar o eliminar.
    ''' </summary>
    Public Function fun_Buscar_ID_MANT_ZONAPLAN(ByVal inZOPLIDRE As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' ZOPLatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MANT_ZONAPLAN "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "ZOPLIDRE = '" & CInt(inZOPLIDRE) & "'"

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Buscar_ID_MANT_ZONAPLAN")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que busca el CÓDIGO para que no se 
    ''' guarden registros duplicados.
    ''' </summary>
    Public Function fun_Buscar_CODIGO_ZONAPLAN(ByVal inZOPLCODI As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' ZOPLatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MANT_ZONAPLAN "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "ZOPLCODI = '" & CInt(inZOPLCODI) & "' "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Buscar_CODIGO_ZONAPLAN")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que busca el ZONAPLAN por el ID
    ''' </summary>
    Public Function fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_MANT_ZONAPLAN(ByVal inZOPLIDRE As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' ZOPLatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "ZOPLIDRE, "
            stConsultaSQL += "ZOPLCODI, "
            stConsultaSQL += "ZOPLDESC, "
            stConsultaSQL += "ESTADESC, "
            stConsultaSQL += "ZOPLESTA  "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MANT_ZONAPLAN, ESTADO "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "ZOPLESTA = ESTACODI AND "
            stConsultaSQL += "ZOPLIDRE = '" & CInt(inZOPLIDRE) & "'"

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "ZOPLCODI "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception

            MessageBox.Show(Err.Description & " " & "fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_MANT_ZONAPLAN")
            Return Nothing

        End Try

    End Function


End Class
