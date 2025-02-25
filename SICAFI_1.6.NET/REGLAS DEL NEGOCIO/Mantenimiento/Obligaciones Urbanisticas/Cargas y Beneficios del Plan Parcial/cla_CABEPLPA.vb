Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration
Imports DATOS

Public Class cla_CABEPLPA

    '============================================
    '*** CARGAS Y BENEFICIOS DEL PLAN PARCIAL ***
    '============================================

    ''' <summary>
    ''' procedimiento que verifica la llave primaria.
    ''' </summary>
    Public Function fun_Verifica_llave_Primaria_MANT_CABEPLPA(ByVal obCBPPCODI As Object) As Boolean

        Try
            Dim boRespuesta As Boolean = False

            Dim obVerifica As New cla_Verificar_Dato

            If obVerifica.fun_Verificar_Campo_Lleno(obCBPPCODI.Text) = True Then

                If obVerifica.fun_Verificar_Dato_Numerico(obCBPPCODI.Text) = True Then

                    Dim objdatos1 As New cla_CABEPLPA
                    Dim tbl As New DataTable

                    tbl = objdatos1.fun_Buscar_CODIGO_CABEPLPA(Trim(obCBPPCODI.Text))

                    If tbl.Rows.Count > 0 Then
                        MessageBox.Show("El dato " & obCBPPCODI.Text & " del campo " & obCBPPCODI.AccessibleDescription & " existe en la base de datos.", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                        obCBPPCODI.Focus()
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
    Public Function fun_Insertar_MANT_CABEPLPA(ByVal inCBPPCODI As Integer, _
                                               ByVal stCBPPDESC As String, _
                                               ByVal stCBPPESTA As String) As Boolean

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' CBPPatena la consulta
            stConsultaSQL += "INSERT INTO "
            stConsultaSQL += "MANT_CABEPLPA "

            stConsultaSQL += "( "
            stConsultaSQL += "CBPPCODI, "
            stConsultaSQL += "CBPPDESC, "
            stConsultaSQL += "CBPPESTA "
            stConsultaSQL += ") "

            stConsultaSQL += "VALUES "

            stConsultaSQL += "( "
            stConsultaSQL += "'" & CInt(inCBPPCODI) & "', "
            stConsultaSQL += "'" & CStr(Trim(stCBPPDESC)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stCBPPESTA)) & "' "
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
            MessageBox.Show(Err.Description & " " & "fun_Insertar_MANT_CABEPLPA")
        End Try

    End Function

    ''' <summary>
    ''' Función que Elimina el registro.
    ''' </summary>
    Public Function fun_Eliminar_MANT_CABEPLPA(ByVal inCBPPIDRE As Integer) As Boolean

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' CBPPatena la consulta
            stConsultaSQL += "DELETE "
            stConsultaSQL += "MANT_CABEPLPA "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "CBPPIDRE = '" & CInt(inCBPPIDRE) & "' "

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
            MessageBox.Show(Err.Description & " " & "fun_Eliminar_MANT_CABEPLPA")
        End Try

    End Function

    ''' <summary>
    ''' Función que Modifica el registro.
    ''' </summary>
    Public Function fun_Actualizar_MANT_CABEPLPA(ByVal inCBPPIDRE As Integer, _
                                                 ByVal inCBPPCODI As Integer, _
                                                 ByVal stCBPPDESC As String, _
                                                 ByVal stCBPPESTA As String) As Boolean

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' CBPPatena la consulta
            stConsultaSQL += "UPDATE "
            stConsultaSQL += "MANT_CABEPLPA "

            stConsultaSQL += "SET "
            stConsultaSQL += "CBPPCODI = '" & CInt(inCBPPCODI) & "', "
            stConsultaSQL += "CBPPDESC = '" & CStr(Trim(stCBPPDESC)) & "', "
            stConsultaSQL += "CBPPESTA = '" & CStr(Trim(stCBPPESTA)) & "' "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "CBPPIDRE = '" & CInt(inCBPPIDRE) & "'"

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
            MessageBox.Show(Err.Description & " " & "fun_Actualizar_CABEPLPA")
        End Try

    End Function

    ''' <summary>
    ''' Consulta para llenar el DataGridView y colocar el nombre del encabezado
    ''' de la columna. 
    ''' </summary>
    Public Function fun_Consultar_MANT_CABEPLPA() As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' CBPPatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "CBPPIDRE, "
            stConsultaSQL += "CBPPCODI, "
            stConsultaSQL += "CBPPDESC, "
            stConsultaSQL += "ESTADESC, "
            stConsultaSQL += "CBPPESTA  "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MANT_CABEPLPA, ESTADO "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "CBPPESTA = ESTACODI "

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "CBPPCODI "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Consultar_MANT_CABEPLPA")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Llena el ComboBox con datos activos e inactivos formulario principal 
    ''' esta funcion se llama desde el procedimiento "pro_inicializarControles()".
    ''' </summary>
    Public Function fun_Consultar_CAMPOS_MANT_CABEPLPA() As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' CBPPatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MANT_CABEPLPA "

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "CBPPCODI "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Consultar_CAMPOS_MANT_CABEPLPA")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Llena el ComboBox con datos activos formulario insertar y modificar 
    ''' esta funcion se llama desde el procedimiento "pro_inicializarControles()".
    ''' </summary>
    Public Function fun_Consultar_MANT_CABEPLPA_X_ESTADO() As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' CBPPatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MANT_CABEPLPA "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "CBPPESTA = 'ac' "

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "CBPPCODI "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Consultar_MANT_CABEPLPA_X_ESTADO")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que busca el ID del registro a modificar o eliminar.
    ''' </summary>
    Public Function fun_Buscar_ID_MANT_CABEPLPA(ByVal inCBPPIDRE As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' CBPPatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MANT_CABEPLPA "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "CBPPIDRE = '" & CInt(inCBPPIDRE) & "'"

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Buscar_ID_MANT_CABEPLPA")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que busca el CÓDIGO para que no se 
    ''' guarden registros duplicados.
    ''' </summary>
    Public Function fun_Buscar_CODIGO_CABEPLPA(ByVal inCBPPCODI As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' CBPPatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MANT_CABEPLPA "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "CBPPCODI = '" & CInt(inCBPPCODI) & "' "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Buscar_CODIGO_CABEPLPA")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que busca el CABEPLPA por el ID
    ''' </summary>
    Public Function fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_MANT_CABEPLPA(ByVal inCBPPIDRE As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' CBPPatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "CBPPIDRE, "
            stConsultaSQL += "CBPPCODI, "
            stConsultaSQL += "CBPPDESC, "
            stConsultaSQL += "ESTADESC, "
            stConsultaSQL += "CBPPESTA  "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MANT_CABEPLPA, ESTADO "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "CBPPESTA = ESTACODI AND "
            stConsultaSQL += "CBPPIDRE = '" & CInt(inCBPPIDRE) & "'"

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "CBPPCODI "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception

            MessageBox.Show(Err.Description & " " & "fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_MANT_CABEPLPA")
            Return Nothing

        End Try

    End Function

End Class
