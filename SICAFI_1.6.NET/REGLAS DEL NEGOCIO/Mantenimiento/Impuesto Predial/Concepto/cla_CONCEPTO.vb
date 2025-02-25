Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration
Imports DATOS

Public Class cla_CONCEPTO

    '================
    '*** CONCEPTO ***
    '================

    ''' <summary>
    ''' procedimiento que verifica la llave primaria.
    ''' </summary>
    Public Function fun_Verifica_llave_Primaria_MANT_CONCEPTO(ByVal obCONCTIIM As Object, ByVal obCONCCODI As Object) As Boolean

        Try
            Dim boRespuesta As Boolean = False

            Dim obVerifica As New cla_Verificar_Dato

            If obVerifica.fun_Verificar_Campo_Lleno(obCONCCODI.Text) = True And _
               obVerifica.fun_Verificar_Campo_Lleno(obCONCTIIM.SelectedValue) = True Then

                If obVerifica.fun_Verificar_Dato_Numerico(obCONCCODI.Text) = True And _
                   obVerifica.fun_Verificar_Dato_Numerico(obCONCTIIM.SelectedValue) = True Then


                    Dim objdatos1 As New cla_CONCEPTO
                    Dim tbl As New DataTable

                    tbl = objdatos1.fun_Buscar_CODIGO_CONCEPTO(obCONCTIIM.SelectedValue, Trim(obCONCCODI.Text))

                    If tbl.Rows.Count > 0 Then
                        MessageBox.Show("El dato " & obCONCTIIM.Text & " - " & obCONCCODI.Text & " del campo " & obCONCCODI.AccessibleDescription & " existe en la base de datos.", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                        obCONCCODI.Focus()
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
    Public Function fun_Insertar_MANT_CONCEPTO(ByVal inCONCTIIM As Integer, _
                                               ByVal inCONCCODI As Integer, _
                                               ByVal stCONCDESC As String, _
                                               ByVal stCONCESTA As String) As Boolean

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "INSERT INTO "
            stConsultaSQL += "MANT_CONCEPTO "

            stConsultaSQL += "( "
            stConsultaSQL += "CONCTIIM, "
            stConsultaSQL += "CONCCODI, "
            stConsultaSQL += "CONCDESC, "
            stConsultaSQL += "CONCESTA "
            stConsultaSQL += ") "

            stConsultaSQL += "VALUES "

            stConsultaSQL += "( "
            stConsultaSQL += "'" & CInt(inCONCTIIM) & "', "
            stConsultaSQL += "'" & CInt(inCONCCODI) & "', "
            stConsultaSQL += "'" & CStr(Trim(stCONCDESC)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stCONCESTA)) & "' "
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
            MessageBox.Show(Err.Description & " " & "fun_Insertar_MANT_CONCEPTO")
        End Try

    End Function

    ''' <summary>
    ''' Función que Elimina el registro.
    ''' </summary>
    Public Function fun_Eliminar_MANT_CONCEPTO(ByVal inCONCIDRE As Integer) As Boolean

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "DELETE "
            stConsultaSQL += "MANT_CONCEPTO "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "CONCIDRE = '" & CInt(inCONCIDRE) & "' "

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
            MessageBox.Show(Err.Description & " " & "fun_Eliminar_MANT_CONCEPTO")
        End Try

    End Function

    ''' <summary>
    ''' Función que Modifica el registro.
    ''' </summary>
    Public Function fun_Actualizar_MANT_CONCEPTO(ByVal inCONCIDRE As Integer, _
                                                 ByVal inCONCTIIM As Integer, _
                                                 ByVal inCONCCODI As Integer, _
                                                 ByVal stCONCDESC As String, _
                                                 ByVal stCONCESTA As String) As Boolean

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "UPDATE "
            stConsultaSQL += "MANT_CONCEPTO "

            stConsultaSQL += "SET "
            stConsultaSQL += "CONCTIIM = '" & CInt(inCONCTIIM) & "', "
            stConsultaSQL += "CONCCODI = '" & CInt(inCONCCODI) & "', "
            stConsultaSQL += "CONCDESC = '" & CStr(Trim(stCONCDESC)) & "', "
            stConsultaSQL += "CONCESTA = '" & CStr(Trim(stCONCESTA)) & "' "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "CONCIDRE = '" & CInt(inCONCIDRE) & "'"

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
            MessageBox.Show(Err.Description & " " & "fun_Actualizar_CONCEPTO")
        End Try

    End Function

    ''' <summary>
    ''' Consulta para llenar el DataGridView y colocar el nombre del encabezado
    ''' de la columna. 
    ''' </summary>
    Public Function fun_Consultar_MANT_CONCEPTO() As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "CONCIDRE, "
            stConsultaSQL += "CONCTIIM, "
            stConsultaSQL += "CONCCODI, "
            stConsultaSQL += "CONCDESC, "
            stConsultaSQL += "CONCESTA  "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MANT_CONCEPTO "

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "CONCTIIM, CONCCODI "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Consultar_MANT_CONCEPTO")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Llena el ComboBox con datos activos e inactivos formulario principal 
    ''' esta funcion se llama desde el procedimiento "pro_inicializarControles()".
    ''' </summary>
    Public Function fun_Consultar_CAMPOS_MANT_CONCEPTO() As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MANT_CONCEPTO "

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "CONCTIIM, CONCCODI "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Consultar_CAMPOS_MANT_CONCEPTO")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Llena el ComboBox con datos activos formulario insertar y modificar 
    ''' esta funcion se llama desde el procedimiento "pro_inicializarControles()".
    ''' </summary>
    Public Function fun_Consultar_MANT_CONCEPTO_X_ESTADO() As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MANT_CONCEPTO "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "CONCESTA = 'ac' "

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "CONCTIIM, CONCCODI "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Consultar_MANT_CONCEPTO_X_ESTADO")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que busca el ID del registro a modificar o eliminar.
    ''' </summary>
    Public Function fun_Buscar_ID_MANT_CONCEPTO(ByVal inCONCIDRE As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MANT_CONCEPTO "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "CONCIDRE = '" & CInt(inCONCIDRE) & "'"

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Buscar_ID_MANT_CONCEPTO")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que busca el CÓDIGO para que no se 
    ''' guarden registros duplicados.
    ''' </summary>
    Public Function fun_Buscar_CODIGO_CONCEPTO(ByVal inCONCTIIM As Integer, ByVal inCONCCODI As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MANT_CONCEPTO "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "CONCTIIM = '" & CInt(inCONCTIIM) & "' and "
            stConsultaSQL += "CONCCODI = '" & CInt(inCONCCODI) & "' "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Buscar_CODIGO_CONCEPTO")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que busca el concepto por el ID
    ''' </summary>
    Public Function fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_MANT_CONCEPTO(ByVal inCONCIDRE As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "CONCIDRE, "
            stConsultaSQL += "CONCTIIM, "
            stConsultaSQL += "CONCCODI, "
            stConsultaSQL += "CONCDESC, "
            stConsultaSQL += "CONCESTA  "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MANT_CONCEPTO "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "CONCIDRE = '" & CInt(inCONCIDRE) & "'"

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "CONCTIIM, CONCCODI "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception

            MessageBox.Show(Err.Description & " " & "fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_MANT_CONCEPTO")
            Return Nothing

        End Try

    End Function

    ''' <summary>
  ''' Función que busca el concepto por tipo de impuesto
    ''' </summary>
    Public Function fun_Buscar_CODIGO_CONCEPTO_X_TIPOIMPU(ByVal inCONCTIIM As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MANT_CONCEPTO "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "CONCTIIM = '" & CInt(inCONCTIIM) & "' "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Buscar_CODIGO_CONCEPTO_X_TIPOIMPU")
            Return Nothing
        End Try

    End Function


End Class
