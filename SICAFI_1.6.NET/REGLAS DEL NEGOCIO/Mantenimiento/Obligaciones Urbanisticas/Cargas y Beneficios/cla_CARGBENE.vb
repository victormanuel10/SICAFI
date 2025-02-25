Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration
Imports DATOS

Public Class cla_CARGBENE

    '============================================
    '*** CARGAS Y BENEFICIOS DEL PLAN PARCIAL ***
    '============================================

    ''' <summary>
    ''' procedimiento que verifica la llave primaria.
    ''' </summary>
    Public Function fun_Verifica_llave_Primaria_MANT_CARGBENE(ByVal inCABENURE As Integer, ByVal stCABEFERE As String, ByVal obCABEUAU As Object) As Boolean

        Try
            Dim boRespuesta As Boolean = False

            Dim obVerifica As New cla_Verificar_Dato

            If obVerifica.fun_Verificar_Campo_Lleno(inCABENURE) = True And
                 obVerifica.fun_Verificar_Campo_Lleno(stCABEFERE) = True And
                 obVerifica.fun_Verificar_Campo_Lleno(obCABEUAU.Text) = True Then

                If obVerifica.fun_Verificar_Dato_Numerico(inCABENURE) = True And
                    obVerifica.fun_Verificar_Dato_Fecha(stCABEFERE) = True And
                    obVerifica.fun_Verificar_Dato_Numerico(obCABEUAU.Text) = True Then

                    Dim objdatos1 As New cla_CARGBENE
                    Dim tbl As New DataTable

                    tbl = objdatos1.fun_Buscar_CODIGO_CARGBENE(inCABENURE, Trim(stCABEFERE), Trim(obCABEUAU.Text))

                    If tbl.Rows.Count > 0 Then
                        MessageBox.Show("El dato " & Trim(inCABENURE) & " - " & Trim(stCABEFERE) & " existe en la base de datos.", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                        obCABEUAU.Focus()
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
    Public Function fun_Insertar_MANT_CARGBENE(ByVal inCABENURE As Integer, _
                                               ByVal stCABEFERE As String, _
                                               ByVal inCABEUAU As Integer, _
                                               ByVal stCABEDESC As String, _
                                               ByVal inCABECEEP As String, _
                                               ByVal inCABECOEP As String, _
                                               ByVal inCABECEVI As String, _
                                               ByVal inCABECOVI As String, _
                                               ByVal inCABECOEQ As String, _
                                               ByVal inCABECVAI As String, _
                                               ByVal inCABECEDI As String, _
                                               ByVal stCABEESTA As String) As Boolean

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' CABEatena la consulta
            stConsultaSQL += "INSERT INTO "
            stConsultaSQL += "MANT_CARGBENE "

            stConsultaSQL += "( "
            stConsultaSQL += "CABENURE, "
            stConsultaSQL += "CABEFERE, "
            stConsultaSQL += "CABEUAU, "
            stConsultaSQL += "CABEDESC, "
            stConsultaSQL += "CABECEEP, "
            stConsultaSQL += "CABECOEP, "
            stConsultaSQL += "CABECEVI, "
            stConsultaSQL += "CABECOVI, "
            stConsultaSQL += "CABECOEQ, "
            stConsultaSQL += "CABECVAI, "
            stConsultaSQL += "CABECEDI, "
            stConsultaSQL += "CABEESTA "
            stConsultaSQL += ") "

            stConsultaSQL += "VALUES "

            stConsultaSQL += "( "
            stConsultaSQL += "'" & CInt(inCABENURE) & "', "
            stConsultaSQL += "'" & CStr(Trim(stCABEFERE)) & "', "
            stConsultaSQL += "'" & CInt(inCABEUAU) & "', "
            stConsultaSQL += "'" & CStr(Trim(stCABEDESC)) & "', "
            stConsultaSQL += "'" & CInt(inCABECEEP) & "', "
            stConsultaSQL += "'" & CInt(inCABECOEP) & "', "
            stConsultaSQL += "'" & CInt(inCABECEVI) & "', "
            stConsultaSQL += "'" & CInt(inCABECOVI) & "', "
            stConsultaSQL += "'" & CInt(inCABECOEQ) & "', "
            stConsultaSQL += "'" & CInt(inCABECVAI) & "', "
            stConsultaSQL += "'" & CInt(inCABECEDI) & "', "
            stConsultaSQL += "'" & CStr(Trim(stCABEESTA)) & "' "
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
            MessageBox.Show(Err.Description & " " & "fun_Insertar_MANT_CARGBENE")
        End Try

    End Function

    ''' <summary>
    ''' Función que Elimina el registro.
    ''' </summary>
    Public Function fun_Eliminar_MANT_CARGBENE(ByVal inCABEIDRE As Integer) As Boolean

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' CABEatena la consulta
            stConsultaSQL += "DELETE "
            stConsultaSQL += "MANT_CARGBENE "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "CABEIDRE = '" & CInt(inCABEIDRE) & "' "

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
            MessageBox.Show(Err.Description & " " & "fun_Eliminar_MANT_CARGBENE")
        End Try

    End Function

    ''' <summary>
    ''' Función que Modifica el registro.
    ''' </summary>
    Public Function fun_Actualizar_MANT_CARGBENE(ByVal inCABEIDRE As Integer, _
                                                 ByVal inCABENURE As Integer, _
                                                 ByVal stCABEFERE As String, _
                                                 ByVal inCABEUAU As Integer, _
                                                 ByVal stCABEDESC As String, _
                                                 ByVal inCABECEEP As Integer, _
                                                 ByVal inCABECOEP As Integer, _
                                                 ByVal inCABECEVI As Integer, _
                                                 ByVal inCABECOVI As Integer, _
                                                 ByVal inCABECOEQ As Integer, _
                                                 ByVal inCABECVAI As Integer, _
                                                 ByVal inCABECEDI As Integer, _
                                                 ByVal stCABEESTA As String) As Boolean

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' CABEatena la consulta
            stConsultaSQL += "UPDATE "
            stConsultaSQL += "MANT_CARGBENE "

            stConsultaSQL += "SET "
            stConsultaSQL += "CABENURE = '" & CInt(inCABENURE) & "', "
            stConsultaSQL += "CABEFERE = '" & CStr(Trim(stCABEFERE)) & "', "
            stConsultaSQL += "CABEUAU = '" & CInt(inCABEUAU) & "', "
            stConsultaSQL += "CABEDESC = '" & CStr(Trim(stCABEDESC)) & "', "
            stConsultaSQL += "CABECEEP = '" & CInt(inCABECEEP) & "', "
            stConsultaSQL += "CABECOEP = '" & CInt(inCABECOEP) & "', "
            stConsultaSQL += "CABECEVI = '" & CInt(inCABECEVI) & "', "
            stConsultaSQL += "CABECOVI = '" & CInt(inCABECOVI) & "', "
            stConsultaSQL += "CABECOEQ = '" & CInt(inCABECOEQ) & "', "
            stConsultaSQL += "CABECVAI = '" & CInt(inCABECVAI) & "', "
            stConsultaSQL += "CABECEDI = '" & CInt(inCABECEDI) & "', "
            stConsultaSQL += "CABEESTA = '" & CStr(Trim(stCABEESTA)) & "' "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "CABEIDRE = '" & CInt(inCABEIDRE) & "'"

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
            MessageBox.Show(Err.Description & " " & "fun_Actualizar_CARGBENE")
        End Try

    End Function

    ''' <summary>
    ''' Consulta para llenar el DataGridView y colocar el nombre del encabezado
    ''' de la columna. 
    ''' </summary>
    Public Function fun_Consultar_MANT_CARGBENE() As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "CABEIDRE, "
            stConsultaSQL += "CABENURE, "
            stConsultaSQL += "CABEFERE, "
            stConsultaSQL += "CABEUAU, "
            stConsultaSQL += "CABEDESC, "
            stConsultaSQL += "CABECEEP, "
            stConsultaSQL += "CABECOEP, "
            stConsultaSQL += "CABECEVI, "
            stConsultaSQL += "CABECOVI, "
            stConsultaSQL += "CABECOEQ, "
            stConsultaSQL += "CABECVAI, "
            stConsultaSQL += "CABECEDI, "
            stConsultaSQL += "ESTADESC, "
            stConsultaSQL += "CABEESTA  "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MANT_CARGBENE, ESTADO "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "CABEESTA = ESTACODI "

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "CABENURE "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Consultar_MANT_CARGBENE")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Llena el ComboBox con datos activos e inactivos formulario principal 
    ''' esta funcion se llama desde el procedimiento "pro_inicializarControles()".
    ''' </summary>
    Public Function fun_Consultar_CAMPOS_MANT_CARGBENE() As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' CABEatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MANT_CARGBENE "

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "CABENURE "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Consultar_CAMPOS_MANT_CARGBENE")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Llena el ComboBox con datos activos formulario insertar y modificar 
    ''' esta funcion se llama desde el procedimiento "pro_inicializarControles()".
    ''' </summary>
    Public Function fun_Consultar_MANT_CARGBENE_X_ESTADO() As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' CABEatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MANT_CARGBENE "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "CABEESTA = 'ac' "

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "CABENURE "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Consultar_MANT_CARGBENE_X_ESTADO")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que busca el ID del registro a modificar o eliminar.
    ''' </summary>
    Public Function fun_Buscar_ID_MANT_CARGBENE(ByVal inCABEIDRE As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' CABEatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MANT_CARGBENE "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "CABEIDRE = '" & CInt(inCABEIDRE) & "'"

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Buscar_ID_MANT_CARGBENE")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que busca el CÓDIGO para que no se 
    ''' guarden registros duplicados.
    ''' </summary>
    Public Function fun_Buscar_CODIGO_CARGBENE(ByVal inCABENURE As Integer, ByVal stCABEFERE As String, ByVal inCABEUAU As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' CABEatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MANT_CARGBENE "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "CABENURE = '" & CInt(inCABENURE) & "' AND "
            stConsultaSQL += "CABEFERE = '" & CStr(Trim(stCABEFERE)) & "' AND "
            stConsultaSQL += "CABEUAU = '" & CInt(inCABEUAU) & "' "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Buscar_CODIGO_CARGBENE")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que busca el CARGBENE por el ID
    ''' </summary>
    Public Function fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_MANT_CARGBENE(ByVal inCABEIDRE As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' CABEatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "CABEIDRE, "
            stConsultaSQL += "CABENURE, "
            stConsultaSQL += "CABEFERE, "
            stConsultaSQL += "CABEUAU, "
            stConsultaSQL += "CABEDESC, "
            stConsultaSQL += "CABECEEP, "
            stConsultaSQL += "CABECOEP, "
            stConsultaSQL += "CABECEVI, "
            stConsultaSQL += "CABECOVI, "
            stConsultaSQL += "CABECOEQ, "
            stConsultaSQL += "CABECVAI, "
            stConsultaSQL += "CABECEDI, "
            stConsultaSQL += "ESTADESC, "
            stConsultaSQL += "CABEESTA  "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MANT_CARGBENE, ESTADO "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "CABEESTA = ESTACODI AND "
            stConsultaSQL += "CABEIDRE = '" & CInt(inCABEIDRE) & "'"

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "CABENURE "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception

            MessageBox.Show(Err.Description & " " & "fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_MANT_CARGBENE")
            Return Nothing

        End Try

    End Function

End Class
