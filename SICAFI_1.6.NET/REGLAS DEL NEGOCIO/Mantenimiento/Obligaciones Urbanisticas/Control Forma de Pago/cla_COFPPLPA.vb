Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration
Imports DATOS

Public Class cla_COFPPLPA

    '==========================================
    '*** CONTROL FORMA DE PAGO PLAN PARCIAL ***
    '==========================================

    ''' <summary>
    ''' procedimiento que verifica la llave primaria.
    ''' </summary>
    Public Function fun_Verifica_llave_Primaria_MANT_COFPPLPA(ByVal obCOFPCODI As Object) As Boolean

        Try
            Dim boRespuesta As Boolean = False

            Dim obVerifica As New cla_Verificar_Dato

            If obVerifica.fun_Verificar_Campo_Lleno(obCOFPCODI.Text) = True Then

                If obVerifica.fun_Verificar_Dato_Numerico(obCOFPCODI.Text) = True Then

                    Dim objdatos1 As New cla_COFPPLPA
                    Dim tbl As New DataTable

                    tbl = objdatos1.fun_Buscar_CODIGO_COFPPLPA(Trim(obCOFPCODI.Text))

                    If tbl.Rows.Count > 0 Then
                        MessageBox.Show("El dato " & obCOFPCODI.Text & " del campo " & obCOFPCODI.AccessibleDescription & " existe en la base de datos.", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                        obCOFPCODI.Focus()
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
    Public Function fun_Insertar_MANT_COFPPLPA(ByVal inCOFPCODI As Integer, _
                                               ByVal stCOFPDESC As String, _
                                               ByVal stCOFPESTA As String) As Boolean

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' COFPatena la consulta
            stConsultaSQL += "INSERT INTO "
            stConsultaSQL += "MANT_COFPPLPA "

            stConsultaSQL += "( "
            stConsultaSQL += "COFPCODI, "
            stConsultaSQL += "COFPDESC, "
            stConsultaSQL += "COFPESTA "
            stConsultaSQL += ") "

            stConsultaSQL += "VALUES "

            stConsultaSQL += "( "
            stConsultaSQL += "'" & CInt(inCOFPCODI) & "', "
            stConsultaSQL += "'" & CStr(Trim(stCOFPDESC)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stCOFPESTA)) & "' "
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
            MessageBox.Show(Err.Description & " " & "fun_Insertar_MANT_COFPPLPA")
        End Try

    End Function

    ''' <summary>
    ''' Función que Elimina el registro.
    ''' </summary>
    Public Function fun_Eliminar_MANT_COFPPLPA(ByVal inCOFPIDRE As Integer) As Boolean

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' COFPatena la consulta
            stConsultaSQL += "DELETE "
            stConsultaSQL += "MANT_COFPPLPA "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "COFPIDRE = '" & CInt(inCOFPIDRE) & "' "

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
            MessageBox.Show(Err.Description & " " & "fun_Eliminar_MANT_COFPPLPA")
        End Try

    End Function

    ''' <summary>
    ''' Función que Modifica el registro.
    ''' </summary>
    Public Function fun_Actualizar_MANT_COFPPLPA(ByVal inCOFPIDRE As Integer, _
                                                 ByVal inCOFPCODI As Integer, _
                                                 ByVal stCOFPDESC As String, _
                                                 ByVal stCOFPESTA As String) As Boolean

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' COFPatena la consulta
            stConsultaSQL += "UPDATE "
            stConsultaSQL += "MANT_COFPPLPA "

            stConsultaSQL += "SET "
            stConsultaSQL += "COFPCODI = '" & CInt(inCOFPCODI) & "', "
            stConsultaSQL += "COFPDESC = '" & CStr(Trim(stCOFPDESC)) & "', "
            stConsultaSQL += "COFPESTA = '" & CStr(Trim(stCOFPESTA)) & "' "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "COFPIDRE = '" & CInt(inCOFPIDRE) & "'"

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
            MessageBox.Show(Err.Description & " " & "fun_Actualizar_COFPPLPA")
        End Try

    End Function

    ''' <summary>
    ''' Consulta para llenar el DataGridView y colocar el nombre del encabezado
    ''' de la columna. 
    ''' </summary>
    Public Function fun_Consultar_MANT_COFPPLPA() As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' COFPatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "COFPIDRE, "
            stConsultaSQL += "COFPCODI, "
            stConsultaSQL += "COFPDESC, "
            stConsultaSQL += "ESTADESC, "
            stConsultaSQL += "COFPESTA  "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MANT_COFPPLPA, ESTADO "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "COFPESTA = ESTACODI "

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "COFPCODI "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Consultar_MANT_COFPPLPA")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Llena el ComboBox con datos activos e inactivos formulario principal 
    ''' esta funcion se llama desde el procedimiento "pro_inicializarControles()".
    ''' </summary>
    Public Function fun_Consultar_CAMPOS_MANT_COFPPLPA() As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' COFPatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MANT_COFPPLPA "

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "COFPCODI "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Consultar_CAMPOS_MANT_COFPPLPA")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Llena el ComboBox con datos activos formulario insertar y modificar 
    ''' esta funcion se llama desde el procedimiento "pro_inicializarControles()".
    ''' </summary>
    Public Function fun_Consultar_MANT_COFPPLPA_X_ESTADO() As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' COFPatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MANT_COFPPLPA "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "COFPESTA = 'ac' "

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "COFPCODI "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Consultar_MANT_COFPPLPA_X_ESTADO")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que busca el ID del registro a modificar o eliminar.
    ''' </summary>
    Public Function fun_Buscar_ID_MANT_COFPPLPA(ByVal inCOFPIDRE As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' COFPatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MANT_COFPPLPA "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "COFPIDRE = '" & CInt(inCOFPIDRE) & "'"

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Buscar_ID_MANT_COFPPLPA")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que busca el CÓDIGO para que no se 
    ''' guarden registros duplicados.
    ''' </summary>
    Public Function fun_Buscar_CODIGO_COFPPLPA(ByVal inCOFPCODI As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' COFPatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MANT_COFPPLPA "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "COFPCODI = '" & CInt(inCOFPCODI) & "' "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Buscar_CODIGO_COFPPLPA")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que busca el COFPPLPA por el ID
    ''' </summary>
    Public Function fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_MANT_COFPPLPA(ByVal inCOFPIDRE As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' COFPatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "COFPIDRE, "
            stConsultaSQL += "COFPCODI, "
            stConsultaSQL += "COFPDESC, "
            stConsultaSQL += "ESTADESC, "
            stConsultaSQL += "COFPESTA  "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MANT_COFPPLPA, ESTADO "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "COFPESTA = ESTACODI AND "
            stConsultaSQL += "COFPIDRE = '" & CInt(inCOFPIDRE) & "'"

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "COFPCODI "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception

            MessageBox.Show(Err.Description & " " & "fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_MANT_COFPPLPA")
            Return Nothing

        End Try

    End Function


End Class
