Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration
Imports DATOS

Public Class cla_FOPAPLPA

    '==================================
    '*** FORMA DE PAGO PLAN PARCIAL ***
    '==================================

    ''' <summary>
    ''' procedimiento que verifica la llave primaria.
    ''' </summary>
    Public Function fun_Verifica_llave_Primaria_MANT_FOPAPLPA(ByVal obFPPPCODI As Object) As Boolean

        Try
            Dim boRespuesta As Boolean = False

            Dim obVerifica As New cla_Verificar_Dato

            If obVerifica.fun_Verificar_Campo_Lleno(obFPPPCODI.Text) = True Then

                If obVerifica.fun_Verificar_Dato_Numerico(obFPPPCODI.Text) = True Then

                    Dim objdatos1 As New cla_FOPAPLPA
                    Dim tbl As New DataTable

                    tbl = objdatos1.fun_Buscar_CODIGO_FOPAPLPA(Trim(obFPPPCODI.Text))

                    If tbl.Rows.Count > 0 Then
                        MessageBox.Show("El dato " & obFPPPCODI.Text & " del campo " & obFPPPCODI.AccessibleDescription & " existe en la base de datos.", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                        obFPPPCODI.Focus()
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
    Public Function fun_Insertar_MANT_FOPAPLPA(ByVal inFPPPCODI As Integer, _
                                               ByVal stFPPPDESC As String, _
                                               ByVal stFPPPESTA As String) As Boolean

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' FPPPatena la consulta
            stConsultaSQL += "INSERT INTO "
            stConsultaSQL += "MANT_FOPAPLPA "

            stConsultaSQL += "( "
            stConsultaSQL += "FPPPCODI, "
            stConsultaSQL += "FPPPDESC, "
            stConsultaSQL += "FPPPESTA "
            stConsultaSQL += ") "

            stConsultaSQL += "VALUES "

            stConsultaSQL += "( "
            stConsultaSQL += "'" & CInt(inFPPPCODI) & "', "
            stConsultaSQL += "'" & CStr(Trim(stFPPPDESC)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stFPPPESTA)) & "' "
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
            MessageBox.Show(Err.Description & " " & "fun_Insertar_MANT_FOPAPLPA")
        End Try

    End Function

    ''' <summary>
    ''' Función que Elimina el registro.
    ''' </summary>
    Public Function fun_Eliminar_MANT_FOPAPLPA(ByVal inFPPPIDRE As Integer) As Boolean

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' FPPPatena la consulta
            stConsultaSQL += "DELETE "
            stConsultaSQL += "MANT_FOPAPLPA "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "FPPPIDRE = '" & CInt(inFPPPIDRE) & "' "

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
            MessageBox.Show(Err.Description & " " & "fun_Eliminar_MANT_FOPAPLPA")
        End Try

    End Function

    ''' <summary>
    ''' Función que Modifica el registro.
    ''' </summary>
    Public Function fun_Actualizar_MANT_FOPAPLPA(ByVal inFPPPIDRE As Integer, _
                                                 ByVal inFPPPCODI As Integer, _
                                                 ByVal stFPPPDESC As String, _
                                                 ByVal stFPPPESTA As String) As Boolean

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' FPPPatena la consulta
            stConsultaSQL += "UPDATE "
            stConsultaSQL += "MANT_FOPAPLPA "

            stConsultaSQL += "SET "
            stConsultaSQL += "FPPPCODI = '" & CInt(inFPPPCODI) & "', "
            stConsultaSQL += "FPPPDESC = '" & CStr(Trim(stFPPPDESC)) & "', "
            stConsultaSQL += "FPPPESTA = '" & CStr(Trim(stFPPPESTA)) & "' "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "FPPPIDRE = '" & CInt(inFPPPIDRE) & "'"

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
            MessageBox.Show(Err.Description & " " & "fun_Actualizar_FOPAPLPA")
        End Try

    End Function

    ''' <summary>
    ''' Consulta para llenar el DataGridView y colocar el nombre del encabezado
    ''' de la columna. 
    ''' </summary>
    Public Function fun_Consultar_MANT_FOPAPLPA() As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' FPPPatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "FPPPIDRE, "
            stConsultaSQL += "FPPPCODI, "
            stConsultaSQL += "FPPPDESC, "
            stConsultaSQL += "ESTADESC, "
            stConsultaSQL += "FPPPESTA  "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MANT_FOPAPLPA, ESTADO "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "FPPPESTA = ESTACODI "

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "FPPPCODI "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Consultar_MANT_FOPAPLPA")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Llena el ComboBox con datos activos e inactivos formulario principal 
    ''' esta funcion se llama desde el procedimiento "pro_inicializarControles()".
    ''' </summary>
    Public Function fun_Consultar_CAMPOS_MANT_FOPAPLPA() As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' FPPPatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MANT_FOPAPLPA "

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "FPPPCODI "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Consultar_CAMPOS_MANT_FOPAPLPA")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Llena el ComboBox con datos activos formulario insertar y modificar 
    ''' esta funcion se llama desde el procedimiento "pro_inicializarControles()".
    ''' </summary>
    Public Function fun_Consultar_MANT_FOPAPLPA_X_ESTADO() As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' FPPPatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MANT_FOPAPLPA "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "FPPPESTA = 'ac' "

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "FPPPCODI "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Consultar_MANT_FOPAPLPA_X_ESTADO")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que busca el ID del registro a modificar o eliminar.
    ''' </summary>
    Public Function fun_Buscar_ID_MANT_FOPAPLPA(ByVal inFPPPIDRE As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' FPPPatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MANT_FOPAPLPA "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "FPPPIDRE = '" & CInt(inFPPPIDRE) & "'"

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Buscar_ID_MANT_FOPAPLPA")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que busca el CÓDIGO para que no se 
    ''' guarden registros duplicados.
    ''' </summary>
    Public Function fun_Buscar_CODIGO_FOPAPLPA(ByVal inFPPPCODI As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' FPPPatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MANT_FOPAPLPA "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "FPPPCODI = '" & CInt(inFPPPCODI) & "' "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Buscar_CODIGO_FOPAPLPA")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que busca el FOPAPLPA por el ID
    ''' </summary>
    Public Function fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_MANT_FOPAPLPA(ByVal inFPPPIDRE As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' FPPPatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "FPPPIDRE, "
            stConsultaSQL += "FPPPCODI, "
            stConsultaSQL += "FPPPDESC, "
            stConsultaSQL += "ESTADESC, "
            stConsultaSQL += "FPPPESTA  "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MANT_FOPAPLPA, ESTADO "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "FPPPESTA = ESTACODI AND "
            stConsultaSQL += "FPPPIDRE = '" & CInt(inFPPPIDRE) & "'"

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "FPPPCODI "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception

            MessageBox.Show(Err.Description & " " & "fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_MANT_FOPAPLPA")
            Return Nothing

        End Try

    End Function


End Class
