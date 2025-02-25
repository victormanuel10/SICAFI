Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration
Imports DATOS

Public Class cla_PLANPARC

    '==================================
    '*** PROYECTOS DEL PLAN PARCIAL ***
    '==================================

    ''' <summary>
    ''' procedimiento que verifica la llave primaria.
    ''' </summary>
    Public Function fun_Verifica_llave_Primaria_MANT_PLANPARC(ByVal obPLPANURE As Object, ByVal obPLPAFERE As Object) As Boolean

        Try
            Dim boRespuesta As Boolean = False

            Dim obVerifica As New cla_Verificar_Dato

            If obVerifica.fun_Verificar_Campo_Lleno(obPLPANURE.Text) = True And
                 obVerifica.fun_Verificar_Campo_Lleno(obPLPAFERE.Text) = True Then

                If obVerifica.fun_Verificar_Dato_Numerico(obPLPANURE.Text) = True And
                    obVerifica.fun_Verificar_Dato_Fecha(obPLPAFERE.Text) = True Then

                    Dim objdatos1 As New cla_PLANPARC
                    Dim tbl As New DataTable

                    tbl = objdatos1.fun_Buscar_CODIGO_PLANPARC(Trim(obPLPANURE.Text), Trim(obPLPAFERE.Text))

                    If tbl.Rows.Count > 0 Then
                        MessageBox.Show("El dato " & Trim(obPLPANURE.Text) & " - " & Trim(obPLPAFERE.Text) & " del campo " & obPLPANURE.AccessibleDescription & " existe en la base de datos.", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                        obPLPANURE.Focus()
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
    Public Function fun_Insertar_MANT_PLANPARC(ByVal inPLPANURE As Integer, _
                                               ByVal stPLPAFERE As String, _
                                               ByVal stPLPADESC As String, _
                                               ByVal stPLPAESTA As String) As Boolean

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' PLPAatena la consulta
            stConsultaSQL += "INSERT INTO "
            stConsultaSQL += "MANT_PLANPARC "

            stConsultaSQL += "( "
            stConsultaSQL += "PLPANURE, "
            stConsultaSQL += "PLPAFERE, "
            stConsultaSQL += "PLPADESC, "
            stConsultaSQL += "PLPAESTA "
            stConsultaSQL += ") "

            stConsultaSQL += "VALUES "

            stConsultaSQL += "( "
            stConsultaSQL += "'" & CInt(inPLPANURE) & "', "
            stConsultaSQL += "'" & CStr(Trim(stPLPAFERE)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stPLPADESC)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stPLPAESTA)) & "' "
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
            MessageBox.Show(Err.Description & " " & "fun_Insertar_MANT_PLANPARC")
        End Try

    End Function

    ''' <summary>
    ''' Función que Elimina el registro.
    ''' </summary>
    Public Function fun_Eliminar_MANT_PLANPARC(ByVal inPLPAIDRE As Integer) As Boolean

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' PLPAatena la consulta
            stConsultaSQL += "DELETE "
            stConsultaSQL += "MANT_PLANPARC "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "PLPAIDRE = '" & CInt(inPLPAIDRE) & "' "

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
            MessageBox.Show(Err.Description & " " & "fun_Eliminar_MANT_PLANPARC")
        End Try

    End Function

    ''' <summary>
    ''' Función que Modifica el registro.
    ''' </summary>
    Public Function fun_Actualizar_MANT_PLANPARC(ByVal inPLPAIDRE As Integer, _
                                                 ByVal inPLPANURE As Integer, _
                                                 ByVal stPLPAFERE As String, _
                                                 ByVal stPLPADESC As String, _
                                                 ByVal stPLPAESTA As String) As Boolean

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' PLPAatena la consulta
            stConsultaSQL += "UPDATE "
            stConsultaSQL += "MANT_PLANPARC "

            stConsultaSQL += "SET "
            stConsultaSQL += "PLPANURE = '" & CInt(inPLPANURE) & "', "
            stConsultaSQL += "PLPAFERE = '" & CStr(Trim(stPLPAFERE)) & "', "
            stConsultaSQL += "PLPADESC = '" & CStr(Trim(stPLPADESC)) & "', "
            stConsultaSQL += "PLPAESTA = '" & CStr(Trim(stPLPAESTA)) & "' "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "PLPAIDRE = '" & CInt(inPLPAIDRE) & "'"

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
            MessageBox.Show(Err.Description & " " & "fun_Actualizar_PLANPARC")
        End Try

    End Function

    ''' <summary>
    ''' Consulta para llenar el DataGridView y colocar el nombre del encabezado
    ''' de la columna. 
    ''' </summary>
    Public Function fun_Consultar_MANT_PLANPARC() As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' PLPAatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "PLPAIDRE, "
            stConsultaSQL += "PLPANURE, "
            stConsultaSQL += "PLPAFERE, "
            stConsultaSQL += "PLPADESC, "
            stConsultaSQL += "ESTADESC, "
            stConsultaSQL += "PLPAESTA  "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MANT_PLANPARC, ESTADO "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "PLPAESTA = ESTACODI "

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "PLPANURE "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Consultar_MANT_PLANPARC")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Llena el ComboBox con datos activos e inactivos formulario principal 
    ''' esta funcion se llama desde el procedimiento "pro_inicializarControles()".
    ''' </summary>
    Public Function fun_Consultar_CAMPOS_MANT_PLANPARC() As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' PLPAatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MANT_PLANPARC "

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "PLPANURE "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Consultar_CAMPOS_MANT_PLANPARC")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Llena el ComboBox con datos activos formulario insertar y modificar 
    ''' esta funcion se llama desde el procedimiento "pro_inicializarControles()".
    ''' </summary>
    Public Function fun_Consultar_MANT_PLANPARC_X_ESTADO() As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' PLPAatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MANT_PLANPARC "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "PLPAESTA = 'ac' "

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "PLPANURE "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Consultar_MANT_PLANPARC_X_ESTADO")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que busca el ID del registro a modificar o eliminar.
    ''' </summary>
    Public Function fun_Buscar_ID_MANT_PLANPARC(ByVal inPLPAIDRE As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' PLPAatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MANT_PLANPARC "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "PLPAIDRE = '" & CInt(inPLPAIDRE) & "'"

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Buscar_ID_MANT_PLANPARC")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que busca el CÓDIGO para que no se 
    ''' guarden registros duplicados.
    ''' </summary>
    Public Function fun_Buscar_CODIGO_PLANPARC(ByVal inPLPANURE As Integer, ByVal stPLPAFERE As String) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' PLPAatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MANT_PLANPARC "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "PLPANURE = '" & CInt(inPLPANURE) & "' AND "
            stConsultaSQL += "PLPAFERE = '" & CStr(Trim(stPLPAFERE)) & "' "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Buscar_CODIGO_PLANPARC")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que busca el PLANPARC por el ID
    ''' </summary>
    Public Function fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_MANT_PLANPARC(ByVal inPLPAIDRE As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' PLPAatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "PLPAIDRE, "
            stConsultaSQL += "PLPANURE, "
            stConsultaSQL += "PLPAFERE, "
            stConsultaSQL += "PLPADESC, "
            stConsultaSQL += "ESTADESC, "
            stConsultaSQL += "PLPAESTA  "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MANT_PLANPARC, ESTADO "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "PLPAESTA = ESTACODI AND "
            stConsultaSQL += "PLPAIDRE = '" & CInt(inPLPAIDRE) & "'"

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "PLPANURE "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception

            MessageBox.Show(Err.Description & " " & "fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_MANT_PLANPARC")
            Return Nothing

        End Try

    End Function

End Class
