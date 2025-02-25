Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration
Imports DATOS

Public Class cla_TIPOLIQU

    '===========================
    '*** TIPO DE LIQUIDACION ***
    '===========================

    ''' <summary>
    ''' procedimiento que verifica la llave primaria.
    ''' </summary>
    Public Function fun_Verifica_llave_Primaria_MANT_TIPOLIQU(ByVal obTILICODI As Object) As Boolean

        Try
            Dim boRespuesta As Boolean = False

            Dim obVerifica As New cla_Verificar_Dato

            If obVerifica.fun_Verificar_Campo_Lleno(obTILICODI.Text) = True Then

                If obVerifica.fun_Verificar_Dato_Numerico(obTILICODI.Text) = True Then

                    Dim objdatos1 As New cla_TIPOLIQU
                    Dim tbl As New DataTable

                    tbl = objdatos1.fun_Buscar_CODIGO_TIPOLIQU(Trim(obTILICODI.Text))

                    If tbl.Rows.Count > 0 Then
                        MessageBox.Show("El dato " & obTILICODI.Text & " del campo " & obTILICODI.AccessibleDescription & " existe en la base de datos.", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                        obTILICODI.Focus()
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
    Public Function fun_Insertar_MANT_TIPOLIQU(ByVal inTILICODI As Integer, _
                                               ByVal stTILIDESC As String, _
                                               ByVal stTILIESTA As String) As Boolean

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' TILIatena la consulta
            stConsultaSQL += "INSERT INTO "
            stConsultaSQL += "MANT_TIPOLIQU "

            stConsultaSQL += "( "
            stConsultaSQL += "TILICODI, "
            stConsultaSQL += "TILIDESC, "
            stConsultaSQL += "TILIESTA "
            stConsultaSQL += ") "

            stConsultaSQL += "VALUES "

            stConsultaSQL += "( "
            stConsultaSQL += "'" & CInt(inTILICODI) & "', "
            stConsultaSQL += "'" & CStr(Trim(stTILIDESC)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stTILIESTA)) & "' "
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
            MessageBox.Show(Err.Description & " " & "fun_Insertar_MANT_TIPOLIQU")
        End Try

    End Function

    ''' <summary>
    ''' Función que Elimina el registro.
    ''' </summary>
    Public Function fun_Eliminar_MANT_TIPOLIQU(ByVal inTILIIDRE As Integer) As Boolean

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' TILIatena la consulta
            stConsultaSQL += "DELETE "
            stConsultaSQL += "MANT_TIPOLIQU "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "TILIIDRE = '" & CInt(inTILIIDRE) & "' "

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
            MessageBox.Show(Err.Description & " " & "fun_Eliminar_MANT_TIPOLIQU")
        End Try

    End Function

    ''' <summary>
    ''' Función que Modifica el registro.
    ''' </summary>
    Public Function fun_Actualizar_MANT_TIPOLIQU(ByVal inTILIIDRE As Integer, _
                                                 ByVal inTILICODI As Integer, _
                                                 ByVal stTILIDESC As String, _
                                                 ByVal stTILIESTA As String) As Boolean

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' TILIatena la consulta
            stConsultaSQL += "UPDATE "
            stConsultaSQL += "MANT_TIPOLIQU "

            stConsultaSQL += "SET "
            stConsultaSQL += "TILICODI = '" & CInt(inTILICODI) & "', "
            stConsultaSQL += "TILIDESC = '" & CStr(Trim(stTILIDESC)) & "', "
            stConsultaSQL += "TILIESTA = '" & CStr(Trim(stTILIESTA)) & "' "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "TILIIDRE = '" & CInt(inTILIIDRE) & "'"

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
            MessageBox.Show(Err.Description & " " & "fun_Actualizar_TIPOLIQU")
        End Try

    End Function

    ''' <summary>
    ''' Consulta para llenar el DataGridView y colocar el nombre del encabezado
    ''' de la columna. 
    ''' </summary>
    Public Function fun_Consultar_MANT_TIPOLIQU() As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' TILIatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "TILIIDRE, "
            stConsultaSQL += "TILICODI, "
            stConsultaSQL += "TILIDESC, "
            stConsultaSQL += "ESTADESC, "
            stConsultaSQL += "TILIESTA  "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MANT_TIPOLIQU, ESTADO "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "TILIESTA = ESTACODI "

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "TILICODI "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Consultar_MANT_TIPOLIQU")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Llena el ComboBox con datos activos e inactivos formulario principal 
    ''' esta funcion se llama desde el procedimiento "pro_inicializarControles()".
    ''' </summary>
    Public Function fun_Consultar_CAMPOS_MANT_TIPOLIQU() As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' TILIatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MANT_TIPOLIQU "

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "TILICODI "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Consultar_CAMPOS_MANT_TIPOLIQU")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Llena el ComboBox con datos activos formulario insertar y modificar 
    ''' esta funcion se llama desde el procedimiento "pro_inicializarControles()".
    ''' </summary>
    Public Function fun_Consultar_MANT_TIPOLIQU_X_ESTADO() As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' TILIatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MANT_TIPOLIQU "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "TILIESTA = 'ac' "

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "TILICODI "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Consultar_MANT_TIPOLIQU_X_ESTADO")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que busca el ID del registro a modificar o eliminar.
    ''' </summary>
    Public Function fun_Buscar_ID_MANT_TIPOLIQU(ByVal inTILIIDRE As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' TILIatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MANT_TIPOLIQU "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "TILIIDRE = '" & CInt(inTILIIDRE) & "'"

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Buscar_ID_MANT_TIPOLIQU")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que busca el CÓDIGO para que no se 
    ''' guarden registros duplicados.
    ''' </summary>
    Public Function fun_Buscar_CODIGO_TIPOLIQU(ByVal inTILICODI As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' TILIatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MANT_TIPOLIQU "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "TILICODI = '" & CInt(inTILICODI) & "' "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Buscar_CODIGO_TIPOLIQU")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que busca el TIPOLIQU por el ID
    ''' </summary>
    Public Function fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_MANT_TIPOLIQU(ByVal inTILIIDRE As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' TILIatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "TILIIDRE, "
            stConsultaSQL += "TILICODI, "
            stConsultaSQL += "TILIDESC, "
            stConsultaSQL += "ESTADESC, "
            stConsultaSQL += "TILIESTA  "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MANT_TIPOLIQU, ESTADO "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "TILIESTA = ESTACODI AND "
            stConsultaSQL += "TILIIDRE = '" & CInt(inTILIIDRE) & "'"

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "TILICODI "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception

            MessageBox.Show(Err.Description & " " & "fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_MANT_TIPOLIQU")
            Return Nothing

        End Try

    End Function


End Class
