Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration
Imports DATOS

Public Class cla_COMUNA

    '====================
    '*** CLASE COMUNA ***
    '====================

    ''' <summary>
    ''' procedimiento que verifica la llave primaria.
    ''' </summary>
    Public Function fun_Verifica_llave_Primaria_COMUNA(ByVal obCOMUDEPA As Object, _
                                                              ByVal obCOMUMUNI As Object, _
                                                              ByVal obCOMUCLSE As Object, _
                                                              ByVal obCOMUCODI As Object) As Boolean

        Try
            Dim boRespuesta As Boolean = False

            Dim obVerifica As New cla_Verificar_Dato

            If obVerifica.fun_Verificar_Campo_Lleno(obCOMUDEPA.SelectedValue) = True And _
               obVerifica.fun_Verificar_Campo_Lleno(obCOMUMUNI.SelectedValue) = True And _
               obVerifica.fun_Verificar_Campo_Lleno(obCOMUCLSE.SelectedValue) = True And _
               obVerifica.fun_Verificar_Campo_Lleno(obCOMUCODI.Text) = True Then

                If obVerifica.fun_Verificar_Dato_Numerico(obCOMUDEPA.SelectedValue) = True And _
                   obVerifica.fun_Verificar_Dato_Numerico(obCOMUMUNI.SelectedValue) = True And _
                   obVerifica.fun_Verificar_Dato_Numerico(obCOMUCLSE.SelectedValue) = True And _
                   obVerifica.fun_Verificar_Dato_Numerico(obCOMUCODI.Text) = True Then

                    Dim objdatos1 As New cla_COMUNA
                    Dim tbl As New DataTable

                    tbl = objdatos1.fun_Buscar_CODIGO_DEPA_MUNI_CLSE_COMU_X_COMUNA(Trim(obCOMUDEPA.SelectedValue), _
                                                                                          Trim(obCOMUMUNI.SelectedValue), _
                                                                                          Trim(obCOMUCLSE.SelectedValue), _
                                                                                          Trim(obCOMUCODI.Text))

                    If tbl.Rows.Count > 0 Then
                        MessageBox.Show("El dato " & obCOMUDEPA.Text & " - " & obCOMUMUNI.Text & " - " & obCOMUCLSE.Text & " del campo " & obCOMUCODI.AccessibleDescription & " existe en la base de datos.", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                        obCOMUDEPA.Focus()
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
    Public Function fun_Insertar_COMUNA(ByVal stCOMUDEPA As String, _
                                               ByVal stCOMUMUNI As String, _
                                               ByVal inCOMUCLSE As Integer, _
                                               ByVal inCOMUCODI As Integer, _
                                               ByVal stCOMUDESC As String, _
                                               ByVal stCOMUESTA As String) As Boolean

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "INSERT INTO "
            stConsultaSQL += "MANT_COMUNA "

            stConsultaSQL += "( "
            stConsultaSQL += "COMUDEPA, "
            stConsultaSQL += "COMUMUNI, "
            stConsultaSQL += "COMUCLSE, "
            stConsultaSQL += "COMUCODI, "
            stConsultaSQL += "COMUDESC, "
            stConsultaSQL += "COMUESTA "
            stConsultaSQL += ") "

            stConsultaSQL += "VALUES "

            stConsultaSQL += "( "
            stConsultaSQL += "'" & CStr(Trim(stCOMUDEPA)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stCOMUMUNI)) & "', "
            stConsultaSQL += "'" & CInt(inCOMUCLSE) & "', "
            stConsultaSQL += "'" & CInt(inCOMUCODI) & "', "
            stConsultaSQL += "'" & CStr(Trim(stCOMUDESC)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stCOMUESTA)) & "' "
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
            MessageBox.Show(Err.Description & " " & "fun_Insertar_COMUNA")
        End Try

    End Function

    ''' <summary>
    ''' Función que Elimina el registro.
    ''' </summary>
    Public Function fun_Eliminar_MANT_COMUNA(ByVal inCOMUIDRE As Integer) As Boolean

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "DELETE "
            stConsultaSQL += "MANT_COMUNA "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "COMUIDRE = '" & CInt(inCOMUIDRE) & "' "

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
            MessageBox.Show(Err.Description & " " & "fun_Eliminar_MANT_COMUNA")
        End Try

    End Function

    ''' <summary>
    ''' Función que Modifica el registro.
    ''' </summary>
    Public Function fun_Actualizar_COMUNA(ByVal inCOMUIDRE As Integer, _
                                                 ByVal stCOMUDEPA As String, _
                                                 ByVal stCOMUMUNI As String, _
                                                 ByVal inCOMUCLSE As Integer, _
                                                 ByVal inCOMUCODI As Integer, _
                                                 ByVal stCOMUDESC As String, _
                                                 ByVal stCOMUESTA As String) As Boolean

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "UPDATE "
            stConsultaSQL += "MANT_COMUNA "

            stConsultaSQL += "SET "
            stConsultaSQL += "COMUDEPA = '" & CStr(Trim(stCOMUDEPA)) & "', "
            stConsultaSQL += "COMUMUNI = '" & CStr(Trim(stCOMUMUNI)) & "', "
            stConsultaSQL += "COMUCLSE = '" & CInt(inCOMUCLSE) & "', "
            stConsultaSQL += "COMUCODI = '" & CInt(inCOMUCODI) & "', "
            stConsultaSQL += "COMUDESC = '" & CStr(Trim(stCOMUDESC)) & "', "
            stConsultaSQL += "COMUESTA = '" & CStr(Trim(stCOMUESTA)) & "' "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "COMUIDRE = '" & CInt(inCOMUIDRE) & "'"

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
            MessageBox.Show(Err.Description & " " & "fun_Actualizar_COMUNA")
        End Try

    End Function

    ''' <summary>
    ''' Consulta para llenar el DataGridView y colocar el nombre del encabezado
    ''' de la columna. 
    ''' </summary>
    Public Function fun_Consultar_COMUNA() As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "COMUIDRE, "
            stConsultaSQL += "COMUDEPA, "
            stConsultaSQL += "COMUMUNI, "
            stConsultaSQL += "COMUCLSE, "
            stConsultaSQL += "COMUCODI, "
            stConsultaSQL += "COMUDESC, "
            stConsultaSQL += "COMUESTA  "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MANT_COMUNA "

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "COMUDEPA, COMUMUNI, COMUCLSE, COMUCODI "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Consultar_COMUNA")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Llena el ComboBox con datos activos e inactivos formulario principal 
    ''' esta funcion se llama desde el procedimiento "pro_inicializarControles()".
    ''' </summary>
    Public Function fun_Consultar_CAMPOS_COMUNA() As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MANT_COMUNA "

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "COMUDEPA, COMUMUNI, COMUCLSE, COMUCODI "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Consultar_CAMPOS_COMUNA")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Llena el ComboBox con datos activos formulario insertar y modificar 
    ''' esta funcion se llama desde el procedimiento "pro_inicializarControles()".
    ''' </summary>
    Public Function fun_Consultar_COMUNA_X_ESTADO() As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MANT_COMUNA "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "COMUESTA = 'ac' "

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "COMUDEPA, COMUMUNI, COMUCLSE, COMUCODI "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Consultar_COMUNA_X_ESTADO")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que busca el ID del registro a modificar o eliminar.
    ''' </summary>
    Public Function fun_Buscar_ID_COMUNA(ByVal inCOMUIDRE As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MANT_COMUNA "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "COMUIDRE = '" & CInt(inCOMUIDRE) & "'"

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Buscar_ID_COMUNA")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que busca el ID del codigo buscado para ejecutar la consulta
    ''' parametrizada.
    ''' </summary>
    Public Function fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_COMUNA(ByVal inCOMUIDRE As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "COMUIDRE, "
            stConsultaSQL += "COMUDEPA, "
            stConsultaSQL += "COMUMUNI, "
            stConsultaSQL += "COMUCLSE, "
            stConsultaSQL += "COMUCODI, "
            stConsultaSQL += "COMUDESC, "
            stConsultaSQL += "COMUESTA  "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MANT_COMUNA "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "COMUIDRE = '" & CInt(inCOMUIDRE) & "'"

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "COMUDEPA, COMUMUNI, COMUCLSE, COMUCODI "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception

            MessageBox.Show(Err.Description & " " & "fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_COMUNA")
            Return Nothing

        End Try

    End Function

    ''' <summary>
    ''' Función que busca el para que no se 
    ''' guarden registros duplicados.
    ''' </summary>
    Public Function fun_Buscar_CODIGO_DEPA_MUNI_CLSE_COMU_X_COMUNA(ByVal stCOMUDEPA As String, _
                                                                          ByVal stCOMUMUNI As String, _
                                                                          ByVal inCOMUCLSE As Integer, _
                                                                          ByVal inCOMUCODI As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MANT_COMUNA "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "COMUDEPA = '" & CStr(Trim(stCOMUDEPA)) & "' and "
            stConsultaSQL += "COMUMUNI = '" & CStr(Trim(stCOMUMUNI)) & "' and "
            stConsultaSQL += "COMUCLSE = '" & CInt(inCOMUCLSE) & "' and "
            stConsultaSQL += "COMUCODI = '" & CInt(inCOMUCODI) & "' "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Buscar_CODIGO_COMUNA")
            Return Nothing
        End Try

    End Function
    ''' <summary>
    ''' Función que busca el para que no se 
    ''' guarden registros duplicados.
    ''' </summary>
    Public Function fun_Buscar_CODIGO_DEPA_MUNI_CLSE_X_COMUNA(ByVal stCOMUDEPA As String, _
                                                              ByVal stCOMUMUNI As String, _
                                                              ByVal inCOMUCLSE As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MANT_COMUNA "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "COMUDEPA = '" & CStr(Trim(stCOMUDEPA)) & "' and "
            stConsultaSQL += "COMUMUNI = '" & CStr(Trim(stCOMUMUNI)) & "' and "
            stConsultaSQL += "COMUCLSE = '" & CInt(inCOMUCLSE) & "' "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Buscar_CODIGO_COMUNA")
            Return Nothing
        End Try

    End Function

End Class
