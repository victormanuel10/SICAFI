Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration
Imports DATOS

Public Class cla_PROYSOCI

    '=====================================
    '*** CLASE PROYECTO SOCIOECONOMICO ***
    '=====================================

    ''' <summary>
    ''' procedimiento que verifica la llave primaria.
    ''' </summary>
    Public Function fun_Verifica_llave_Primaria_MANT_PROYSOCI(ByVal obPRSOCODI As Object) As Boolean

        Try
            Dim boRespuesta As Boolean = False

            Dim obVerifica As New cla_Verificar_Dato

            If obVerifica.fun_Verificar_Campo_Lleno(obPRSOCODI.Text) = True Then

                If obVerifica.fun_Verificar_Dato_Numerico(obPRSOCODI.Text) = True Then

                    Dim objdatos1 As New cla_PROYSOCI
                    Dim tbl As New DataTable

                    tbl = objdatos1.fun_Buscar_CODIGO_PROYSOCI(Trim(obPRSOCODI.Text))

                    If tbl.Rows.Count > 0 Then
                        MessageBox.Show("El dato " & obPRSOCODI.Text & " del campo " & obPRSOCODI.AccessibleDescription & " existe en la base de datos.", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                        obPRSOCODI.Focus()
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
    Public Function fun_Insertar_MANT_PROYSOCI(ByVal inPRSOCODI As Integer, _
                                               ByVal stPRSODESC As String, _
                                               ByVal stPRSOESTA As String) As Boolean

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' PRSOatena la consulta
            stConsultaSQL += "INSERT INTO "
            stConsultaSQL += "MANT_PROYSOCI "

            stConsultaSQL += "( "
            stConsultaSQL += "PRSOCODI, "
            stConsultaSQL += "PRSODESC, "
            stConsultaSQL += "PRSOESTA "
            stConsultaSQL += ") "

            stConsultaSQL += "VALUES "

            stConsultaSQL += "( "
            stConsultaSQL += "'" & CInt(inPRSOCODI) & "', "
            stConsultaSQL += "'" & CStr(Trim(stPRSODESC)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stPRSOESTA)) & "' "
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
            MessageBox.Show(Err.Description & " " & "fun_Insertar_MANT_PROYSOCI")
        End Try

    End Function

    ''' <summary>
    ''' Función que Elimina el registro.
    ''' </summary>
    Public Function fun_Eliminar_MANT_PROYSOCI(ByVal inPRSOIDRE As Integer) As Boolean

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' PRSOatena la consulta
            stConsultaSQL += "DELETE "
            stConsultaSQL += "MANT_PROYSOCI "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "PRSOIDRE = '" & CInt(inPRSOIDRE) & "' "

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
            MessageBox.Show(Err.Description & " " & "fun_Eliminar_MANT_PROYSOCI")
        End Try

    End Function

    ''' <summary>
    ''' Función que Modifica el registro.
    ''' </summary>
    Public Function fun_Actualizar_MANT_PROYSOCI(ByVal inPRSOIDRE As Integer, _
                                                 ByVal inPRSOCODI As Integer, _
                                                 ByVal stPRSODESC As String, _
                                                 ByVal stPRSOESTA As String) As Boolean

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' PRSOatena la consulta
            stConsultaSQL += "UPDATE "
            stConsultaSQL += "MANT_PROYSOCI "

            stConsultaSQL += "SET "
            stConsultaSQL += "PRSOCODI = '" & CInt(inPRSOCODI) & "', "
            stConsultaSQL += "PRSODESC = '" & CStr(Trim(stPRSODESC)) & "', "
            stConsultaSQL += "PRSOESTA = '" & CStr(Trim(stPRSOESTA)) & "' "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "PRSOIDRE = '" & CInt(inPRSOIDRE) & "'"

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
            MessageBox.Show(Err.Description & " " & "fun_Actualizar_PROYSOCI")
        End Try

    End Function

    ''' <summary>
    ''' Consulta para llenar el DataGridView y colocar el nombre del encabezado
    ''' de la columna. 
    ''' </summary>
    Public Function fun_Consultar_MANT_PROYSOCI() As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' PRSOatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "PRSOIDRE, "
            stConsultaSQL += "PRSOCODI, "
            stConsultaSQL += "PRSODESC, "
            stConsultaSQL += "ESTADESC, "
            stConsultaSQL += "PRSOESTA  "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MANT_PROYSOCI, ESTADO "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "PRSOESTA = ESTACODI "

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "PRSOCODI "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Consultar_MANT_PROYSOCI")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Llena el ComboBox con datos activos e inactivos formulario principal 
    ''' esta funcion se llama desde el procedimiento "pro_inicializarControles()".
    ''' </summary>
    Public Function fun_Consultar_CAMPOS_MANT_PROYSOCI() As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' PRSOatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MANT_PROYSOCI "

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "PRSOCODI "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Consultar_CAMPOS_MANT_PROYSOCI")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Llena el ComboBox con datos activos formulario insertar y modificar 
    ''' esta funcion se llama desde el procedimiento "pro_inicializarControles()".
    ''' </summary>
    Public Function fun_Consultar_MANT_PROYSOCI_X_ESTADO() As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' PRSOatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MANT_PROYSOCI "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "PRSOESTA = 'ac' "

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "PRSOCODI "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Consultar_MANT_PROYSOCI_X_ESTADO")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que busca el ID del registro a modificar o eliminar.
    ''' </summary>
    Public Function fun_Buscar_ID_MANT_PROYSOCI(ByVal inPRSOIDRE As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' PRSOatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MANT_PROYSOCI "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "PRSOIDRE = '" & CInt(inPRSOIDRE) & "'"

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Buscar_ID_MANT_PROYSOCI")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que busca el CÓDIGO para que no se 
    ''' guarden registros duplicados.
    ''' </summary>
    Public Function fun_Buscar_CODIGO_PROYSOCI(ByVal inPRSOCODI As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' PRSOatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MANT_PROYSOCI "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "PRSOCODI = '" & CInt(inPRSOCODI) & "' "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Buscar_CODIGO_PROYSOCI")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que busca el PROYSOCI por el ID
    ''' </summary>
    Public Function fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_MANT_PROYSOCI(ByVal inPRSOIDRE As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' PRSOatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "PRSOIDRE, "
            stConsultaSQL += "PRSOCODI, "
            stConsultaSQL += "PRSODESC, "
            stConsultaSQL += "ESTADESC, "
            stConsultaSQL += "PRSOESTA  "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MANT_PROYSOCI, ESTADO "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "PRSOESTA = ESTACODI AND "
            stConsultaSQL += "PRSOIDRE = '" & CInt(inPRSOIDRE) & "'"

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "PRSOCODI "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception

            MessageBox.Show(Err.Description & " " & "fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_MANT_PROYSOCI")
            Return Nothing

        End Try

    End Function

End Class
