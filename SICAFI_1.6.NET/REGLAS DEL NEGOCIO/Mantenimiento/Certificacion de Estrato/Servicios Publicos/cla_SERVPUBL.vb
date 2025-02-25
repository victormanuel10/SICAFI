Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration
Imports DATOS

Public Class cla_SERVPUBL

    '================================
    '*** CLASE SERVICIOS PUBLICOS ***
    '================================

    ''' <summary>
    ''' procedimiento que verifica la llave primaria.
    ''' </summary>
    Public Function fun_Verifica_llave_Primaria_MANT_SERVPUBL(ByVal obSEPUCODI As Object) As Boolean

        Try
            Dim boRespuesta As Boolean = False

            Dim obVerifica As New cla_Verificar_Dato

            If obVerifica.fun_Verificar_Campo_Lleno(obSEPUCODI.Text) = True Then

                If obVerifica.fun_Verificar_Dato_Numerico(obSEPUCODI.Text) = True Then

                    Dim objdatos1 As New cla_SERVPUBL
                    Dim tbl As New DataTable

                    tbl = objdatos1.fun_Buscar_CODIGO_SERVPUBL(Trim(obSEPUCODI.Text))

                    If tbl.Rows.Count > 0 Then
                        MessageBox.Show("El dato " & obSEPUCODI.Text & " del campo " & obSEPUCODI.AccessibleDescription & " existe en la base de datos.", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                        obSEPUCODI.Focus()
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
    Public Function fun_Insertar_MANT_SERVPUBL(ByVal inSEPUCODI As Integer, _
                                               ByVal stSEPUDESC As String, _
                                               ByVal stSEPUESTA As String) As Boolean

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' SEPUatena la consulta
            stConsultaSQL += "INSERT INTO "
            stConsultaSQL += "MANT_SERVPUBL "

            stConsultaSQL += "( "
            stConsultaSQL += "SEPUCODI, "
            stConsultaSQL += "SEPUDESC, "
            stConsultaSQL += "SEPUESTA "
            stConsultaSQL += ") "

            stConsultaSQL += "VALUES "

            stConsultaSQL += "( "
            stConsultaSQL += "'" & CInt(inSEPUCODI) & "', "
            stConsultaSQL += "'" & CStr(Trim(stSEPUDESC)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stSEPUESTA)) & "' "
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
            MessageBox.Show(Err.Description & " " & "fun_Insertar_MANT_SERVPUBL")
        End Try

    End Function

    ''' <summary>
    ''' Función que Elimina el registro.
    ''' </summary>
    Public Function fun_Eliminar_MANT_SERVPUBL(ByVal inSEPUIDRE As Integer) As Boolean

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' SEPUatena la consulta
            stConsultaSQL += "DELETE "
            stConsultaSQL += "MANT_SERVPUBL "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "SEPUIDRE = '" & CInt(inSEPUIDRE) & "' "

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
            MessageBox.Show(Err.Description & " " & "fun_Eliminar_MANT_SERVPUBL")
        End Try

    End Function

    ''' <summary>
    ''' Función que Modifica el registro.
    ''' </summary>
    Public Function fun_Actualizar_MANT_SERVPUBL(ByVal inSEPUIDRE As Integer, _
                                                 ByVal inSEPUCODI As Integer, _
                                                 ByVal stSEPUDESC As String, _
                                                 ByVal stSEPUESTA As String) As Boolean

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' SEPUatena la consulta
            stConsultaSQL += "UPDATE "
            stConsultaSQL += "MANT_SERVPUBL "

            stConsultaSQL += "SET "
            stConsultaSQL += "SEPUCODI = '" & CInt(inSEPUCODI) & "', "
            stConsultaSQL += "SEPUDESC = '" & CStr(Trim(stSEPUDESC)) & "', "
            stConsultaSQL += "SEPUESTA = '" & CStr(Trim(stSEPUESTA)) & "' "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "SEPUIDRE = '" & CInt(inSEPUIDRE) & "'"

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
            MessageBox.Show(Err.Description & " " & "fun_Actualizar_SERVPUBL")
        End Try

    End Function

    ''' <summary>
    ''' Consulta para llenar el DataGridView y colocar el nombre del encabezado
    ''' de la columna. 
    ''' </summary>
    Public Function fun_Consultar_MANT_SERVPUBL() As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' SEPUatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "SEPUIDRE, "
            stConsultaSQL += "SEPUCODI, "
            stConsultaSQL += "SEPUDESC, "
            stConsultaSQL += "ESTADESC, "
            stConsultaSQL += "SEPUESTA  "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MANT_SERVPUBL, ESTADO "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "SEPUESTA = ESTACODI "

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "SEPUCODI "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Consultar_MANT_SERVPUBL")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Llena el ComboBox con datos activos e inactivos formulario principal 
    ''' esta funcion se llama desde el procedimiento "pro_inicializarControles()".
    ''' </summary>
    Public Function fun_Consultar_CAMPOS_MANT_SERVPUBL() As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' SEPUatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MANT_SERVPUBL "

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "SEPUCODI "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Consultar_CAMPOS_MANT_SERVPUBL")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Llena el ComboBox con datos activos formulario insertar y modificar 
    ''' esta funcion se llama desde el procedimiento "pro_inicializarControles()".
    ''' </summary>
    Public Function fun_Consultar_MANT_SERVPUBL_X_ESTADO() As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' SEPUatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MANT_SERVPUBL "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "SEPUESTA = 'ac' "

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "SEPUCODI "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Consultar_MANT_SERVPUBL_X_ESTADO")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que busca el ID del registro a modificar o eliminar.
    ''' </summary>
    Public Function fun_Buscar_ID_MANT_SERVPUBL(ByVal inSEPUIDRE As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' SEPUatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MANT_SERVPUBL "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "SEPUIDRE = '" & CInt(inSEPUIDRE) & "'"

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Buscar_ID_MANT_SERVPUBL")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que busca el CÓDIGO para que no se 
    ''' guarden registros duplicados.
    ''' </summary>
    Public Function fun_Buscar_CODIGO_SERVPUBL(ByVal inSEPUCODI As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' SEPUatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MANT_SERVPUBL "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "SEPUCODI = '" & CInt(inSEPUCODI) & "' "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Buscar_CODIGO_SERVPUBL")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que busca el SERVPUBL por el ID
    ''' </summary>
    Public Function fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_MANT_SERVPUBL(ByVal inSEPUIDRE As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' SEPUatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "SEPUIDRE, "
            stConsultaSQL += "SEPUCODI, "
            stConsultaSQL += "SEPUDESC, "
            stConsultaSQL += "ESTADESC, "
            stConsultaSQL += "SEPUESTA  "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MANT_SERVPUBL, ESTADO "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "SEPUESTA = ESTACODI AND "
            stConsultaSQL += "SEPUIDRE = '" & CInt(inSEPUIDRE) & "'"

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "SEPUCODI "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception

            MessageBox.Show(Err.Description & " " & "fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_MANT_SERVPUBL")
            Return Nothing

        End Try

    End Function

End Class
