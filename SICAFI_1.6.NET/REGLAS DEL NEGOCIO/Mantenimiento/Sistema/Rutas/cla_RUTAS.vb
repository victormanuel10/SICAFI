Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration
Imports DATOS

Public Class cla_RUTAS

    '===================
    '*** CLASE RUTAS ***
    '===================

    ''' <summary>
    ''' procedimiento que verifica la llave primaria.
    ''' </summary>
    Public Function fun_Verifica_llave_Primaria_RUTAS(ByVal obRUTACODI As Object) As Boolean

        Try
            Dim boRespuesta As Boolean = False

            Dim obVerifica As New cla_Verificar_Dato

            If obVerifica.fun_Verificar_Campo_Lleno(obRUTACODI.Text) = True Then
                If obVerifica.fun_Verificar_Dato_Numerico(obRUTACODI.Text) = True Then

                    Dim objdatos1 As New cla_RUTAS
                    Dim tbl As New DataTable

                    tbl = objdatos1.fun_Buscar_CODIGO_MANT_RUTAS(Trim(obRUTACODI.Text))

                    If tbl.Rows.Count > 0 Then
                        MessageBox.Show("El dato " & obRUTACODI.Text & " del campo " & obRUTACODI.AccessibleDescription & " existe en la base de datos.", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                        obRUTACODI.Focus()
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
    Public Function fun_Insertar_MANT_RUTAS(ByVal inRUTACODI As Integer, _
                                               ByVal stRUTADESC As String, _
                                               ByVal stRUTARUTA As String, _
                                               ByVal stRUTAESTA As String) As Boolean

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "INSERT INTO "
            stConsultaSQL += "MANT_RUTAS "

            stConsultaSQL += "( "
            stConsultaSQL += "RUTACODI, "
            stConsultaSQL += "RUTADESC, "
            stConsultaSQL += "RUTARUTA, "
            stConsultaSQL += "RUTAESTA "
            stConsultaSQL += ") "

            stConsultaSQL += "VALUES "

            stConsultaSQL += "( "
            stConsultaSQL += "'" & CInt(inRUTACODI) & "', "
            stConsultaSQL += "'" & CStr(Trim(stRUTADESC)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stRUTARUTA)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stRUTAESTA)) & "' "
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
            MessageBox.Show(Err.Description & " " & "fun_Insertar_MANT_RUTAS")
        End Try

    End Function

    ''' <summary>
    ''' Función que Elimina el registro.
    ''' </summary>
    Public Function fun_Eliminar_MANT_RUTAS(ByVal inRUTAIDRE As Integer) As Boolean

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "DELETE "
            stConsultaSQL += "MANT_RUTAS "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "RUTAIDRE = '" & CInt(inRUTAIDRE) & "' "

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
            MessageBox.Show(Err.Description & " " & "fun_Eliminar_MANT_RUTAS")
        End Try

    End Function

    ''' <summary>
    ''' Función que Modifica el registro.
    ''' </summary>
    Public Function fun_Actualizar_MANT_RUTAS(ByVal inRUTAIDRE As Integer, _
                                                 ByVal inRUTACODI As Integer, _
                                                 ByVal stRUTADESC As String, _
                                                 ByVal stRUTARUTA As String, _
                                                 ByVal stRUTAESTA As String) As Boolean

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "UPDATE "
            stConsultaSQL += "MANT_RUTAS "

            stConsultaSQL += "SET "
            stConsultaSQL += "RUTACODI = '" & CInt(inRUTACODI) & "', "
            stConsultaSQL += "RUTADESC = '" & CStr(Trim(stRUTADESC)) & "', "
            stConsultaSQL += "RUTARUTA = '" & CStr(Trim(stRUTARUTA)) & "', "
            stConsultaSQL += "RUTAESTA = '" & CStr(Trim(stRUTAESTA)) & "' "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "RUTAIDRE = '" & CInt(inRUTAIDRE) & "'"

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
            MessageBox.Show(Err.Description & " " & "fun_Actualizar_MANT_RUTAS")
        End Try

    End Function

    ''' <summary>
    ''' Consulta para llenar el DataGridView y colocar el nombre del encabezado
    ''' de la columna. 
    ''' </summary>
    Public Function fun_Consultar_MANT_RUTAS() As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "RUTAIDRE as 'Sec', "
            stConsultaSQL += "RUTACODI as 'Codigo', "
            stConsultaSQL += "RUTADESC as 'Descripción', "
            stConsultaSQL += "RUTARUTA as 'Ruta', "
            stConsultaSQL += "RUTAESTA as 'Estado' "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MANT_RUTAS "

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "RUTACODI "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Consultar_MANT_RUTAS")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Llena el ComboBox con datos activos e inactivos formulario principal 
    ''' esta funcion se llama desde el procedimiento "pro_inicializarControles()".
    ''' </summary>
    Public Function fun_Consultar_CAMPOS_MANT_RUTAS() As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MANT_RUTAS "

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "RUTACODI "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Consultar_CAMPOS_MANT_RUTAS")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Llena el ComboBox con datos activos formulario insertar y modificar 
    ''' esta funcion se llama desde el procedimiento "pro_inicializarControles()".
    ''' </summary>
    Public Function fun_Consultar_MANT_RUTAS_X_ESTADO() As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MANT_RUTAS "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "RUTAESTA = 'ac' "

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "RUTACODI "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Consultar_MANT_RUTAS_X_ESTADO")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que busca el ID del registro a modificar o eliminar.
    ''' </summary>
    Public Function fun_Buscar_ID_MANT_RUTAS(ByVal inRUTAIDRE As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MANT_RUTAS "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "RUTAIDRE = '" & CInt(inRUTAIDRE) & "'"

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Buscar_ID_MANT_RUTAS")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que busca el CÓDIGO DE LA CALIDAD DE PROPIETARIO para que no se 
    ''' guarden registros duplicados.
    ''' </summary>
    Public Function fun_Buscar_CODIGO_MANT_RUTAS(ByVal inRUTACODI As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MANT_RUTAS "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "RUTACODI = '" & CInt(inRUTACODI) & "'"

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Buscar_CODIGO_MANT_RUTAS")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que busca el ID del codigo buscado para ejecutar la consulta
    ''' parametrizada.
    ''' </summary>
    Public Function fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_MANT_RUTAS(ByVal inRUTAIDRE As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "RUTAIDRE as 'Sec', "
            stConsultaSQL += "RUTACODI as 'Codigo', "
            stConsultaSQL += "RUTADESC as 'Descripción', "
            stConsultaSQL += "RUTARUTA as 'Ruta', "
            stConsultaSQL += "RUTAESTA as 'Estado' "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MANT_RUTAS "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "RUTAIDRE = '" & CInt(inRUTAIDRE) & "'"

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "RUTACODI "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception

            MessageBox.Show(Err.Description & " " & "fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_MANT_RUTAS")
            Return Nothing

        End Try

    End Function

End Class
