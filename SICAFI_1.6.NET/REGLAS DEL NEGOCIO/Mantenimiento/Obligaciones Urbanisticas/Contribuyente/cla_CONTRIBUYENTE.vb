Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration
Imports DATOS

Public Class cla_CONTRIBUYENTE

    '===========================
    '*** CLASE CONTRIBUYENTE ***
    '===========================

    ''' <summary>
    ''' procedimiento que verifica la llave primaria.
    ''' </summary>
    Public Function fun_Verifica_llave_Primaria_MANT_CONTRIBUYENTE(ByVal obCONTCODI As Object) As Boolean

        Try
            Dim boRespuesta As Boolean = False

            Dim obVerifica As New cla_Verificar_Dato

            If obVerifica.fun_Verificar_Campo_Lleno(obCONTCODI.Text) = True Then

                If obVerifica.fun_Verificar_Dato_Numerico(obCONTCODI.Text) = True Then

                    Dim objdatos1 As New cla_CONTRIBUYENTE
                    Dim tbl As New DataTable

                    tbl = objdatos1.fun_Buscar_CODIGO_CONTRIBUYENTE(Trim(obCONTCODI.Text))

                    If tbl.Rows.Count > 0 Then
                        MessageBox.Show("El dato " & obCONTCODI.Text & " del campo " & obCONTCODI.AccessibleDescription & " existe en la base de datos.", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                        obCONTCODI.Focus()
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
    Public Function fun_Insertar_MANT_CONTRIBUYENTE(ByVal inCONTCODI As Integer, _
                                                    ByVal stCONTDESC As String, _
                                                    ByVal stCONTESTA As String) As Boolean

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' CONTatena la consulta
            stConsultaSQL += "INSERT INTO "
            stConsultaSQL += "MANT_CONTRIBUYENTE "

            stConsultaSQL += "( "
            stConsultaSQL += "CONTCODI, "
            stConsultaSQL += "CONTDESC, "
            stConsultaSQL += "CONTESTA "
            stConsultaSQL += ") "

            stConsultaSQL += "VALUES "

            stConsultaSQL += "( "
            stConsultaSQL += "'" & CInt(inCONTCODI) & "', "
            stConsultaSQL += "'" & CStr(Trim(stCONTDESC)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stCONTESTA)) & "' "
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
            MessageBox.Show(Err.Description & " " & "fun_Insertar_MANT_CONTRIBUYENTE")
        End Try

    End Function

    ''' <summary>
    ''' Función que Elimina el registro.
    ''' </summary>
    Public Function fun_Eliminar_MANT_CONTRIBUYENTE(ByVal inCONTIDRE As Integer) As Boolean

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' CONTatena la consulta
            stConsultaSQL += "DELETE "
            stConsultaSQL += "MANT_CONTRIBUYENTE "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "CONTIDRE = '" & CInt(inCONTIDRE) & "' "

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
            MessageBox.Show(Err.Description & " " & "fun_Eliminar_MANT_CONTRIBUYENTE")
        End Try

    End Function

    ''' <summary>
    ''' Función que Modifica el registro.
    ''' </summary>
    Public Function fun_Actualizar_MANT_CONTRIBUYENTE(ByVal inCONTIDRE As Integer, _
                                                      ByVal inCONTCODI As Integer, _
                                                      ByVal stCONTDESC As String, _
                                                      ByVal stCONTESTA As String) As Boolean

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' CONTatena la consulta
            stConsultaSQL += "UPDATE "
            stConsultaSQL += "MANT_CONTRIBUYENTE "

            stConsultaSQL += "SET "
            stConsultaSQL += "CONTCODI = '" & CInt(inCONTCODI) & "', "
            stConsultaSQL += "CONTDESC = '" & CStr(Trim(stCONTDESC)) & "', "
            stConsultaSQL += "CONTESTA = '" & CStr(Trim(stCONTESTA)) & "' "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "CONTIDRE = '" & CInt(inCONTIDRE) & "'"

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
            MessageBox.Show(Err.Description & " " & "fun_Actualizar_CONTRIBUYENTE")
        End Try

    End Function

    ''' <summary>
    ''' Consulta para llenar el DataGridView y colocar el nombre del encabezado
    ''' de la columna. 
    ''' </summary>
    Public Function fun_Consultar_MANT_CONTRIBUYENTE() As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' CONTatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "CONTIDRE, "
            stConsultaSQL += "CONTCODI, "
            stConsultaSQL += "CONTDESC, "
            stConsultaSQL += "ESTADESC, "
            stConsultaSQL += "CONTESTA  "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MANT_CONTRIBUYENTE, ESTADO "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "CONTESTA = ESTACODI "

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "CONTCODI "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Consultar_MANT_CONTRIBUYENTE")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Llena el ComboBox con datos activos e inactivos formulario principal 
    ''' esta funcion se llama desde el procedimiento "pro_inicializarControles()".
    ''' </summary>
    Public Function fun_Consultar_CAMPOS_MANT_CONTRIBUYENTE() As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' CONTatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MANT_CONTRIBUYENTE "

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "CONTCODI "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Consultar_CAMPOS_MANT_CONTRIBUYENTE")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Llena el ComboBox con datos activos formulario insertar y modificar 
    ''' esta funcion se llama desde el procedimiento "pro_inicializarControles()".
    ''' </summary>
    Public Function fun_Consultar_MANT_CONTRIBUYENTE_X_ESTADO() As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' CONTatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MANT_CONTRIBUYENTE "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "CONTESTA = 'ac' "

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "CONTCODI "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Consultar_MANT_CONTRIBUYENTE_X_ESTADO")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que busca el ID del registro a modificar o eliminar.
    ''' </summary>
    Public Function fun_Buscar_ID_MANT_CONTRIBUYENTE(ByVal inCONTIDRE As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' CONTatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MANT_CONTRIBUYENTE "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "CONTIDRE = '" & CInt(inCONTIDRE) & "'"

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Buscar_ID_MANT_CONTRIBUYENTE")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que busca el CÓDIGO para que no se 
    ''' guarden registros duplicados.
    ''' </summary>
    Public Function fun_Buscar_CODIGO_CONTRIBUYENTE(ByVal inCONTCODI As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' CONTatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MANT_CONTRIBUYENTE "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "CONTCODI = '" & CInt(inCONTCODI) & "' "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Buscar_CODIGO_CONTRIBUYENTE")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que busca el CONTRIBUYENTE por el ID
    ''' </summary>
    Public Function fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_MANT_CONTRIBUYENTE(ByVal inCONTIDRE As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' CONTatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "CONTIDRE, "
            stConsultaSQL += "CONTCODI, "
            stConsultaSQL += "CONTDESC, "
            stConsultaSQL += "ESTADESC, "
            stConsultaSQL += "CONTESTA  "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MANT_CONTRIBUYENTE, ESTADO "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "CONTESTA = ESTACODI AND "
            stConsultaSQL += "CONTIDRE = '" & CInt(inCONTIDRE) & "'"

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "CONTCODI "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception

            MessageBox.Show(Err.Description & " " & "fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_MANT_CONTRIBUYENTE")
            Return Nothing

        End Try

    End Function


End Class
