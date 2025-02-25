Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration
Imports DATOS

Public Class cla_OBLIURBA

    '=======================================
    '*** CLASE OBLIGACIONES URBANISTICAS ***
    '=======================================

    ''' <summary>
    ''' procedimiento que verifica la llave primaria.
    ''' </summary>
    Public Function fun_Verifica_llave_Primaria_OBLIURBA(ByVal obOBURCLEN As Object, _
                                                         ByVal obOBURNURE As Object, _
                                                         ByVal obOBURFERE As Object) As Boolean

        Try
            Dim boRespuesta As Boolean = False

            Dim obVerifica As New cla_Verificar_Dato

            If obVerifica.fun_Verificar_Campo_Lleno(obOBURCLEN.SelectedValue) = True And _
                obVerifica.fun_Verificar_Campo_Lleno(obOBURNURE.Text) = True And _
                obVerifica.fun_Verificar_Campo_Lleno(obOBURFERE.Text) = True Then

                Dim objdatos1 As New cla_OBLIURBA
                Dim tbl As New DataTable

                tbl = objdatos1.fun_Buscar_CODIGO_X_OBLIURBA(obOBURCLEN.SelectedValue, obOBURNURE.Text, obOBURFERE.Text)

                If tbl.Rows.Count > 0 Then
                    MessageBox.Show("El registro existe en la base de datos.", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1)
                    boRespuesta = False
                Else
                    boRespuesta = True
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
    Public Function fun_Insertar_OBLIURBA(ByVal inOBURSECU As Integer, _
                                          ByVal stOBURCLEN As String, _
                                          ByVal inOBURNURE As Integer, _
                                          ByVal stOBURFERE As String, _
                                          ByVal inOBURVIRE As Integer, _
                                          ByVal inOBURVILI As Integer, _
                                          ByVal stOBUROBSE As String, _
                                          ByVal stOBURESTA As String) As Boolean


        Try

            ' variables 
            Dim daOBURFEIN As Date = fun_fecha()
            Dim stOBURUSIN As String = fun_usuario()
            Dim stOBURNDIN As String = fun_cedula()
            Dim stOBURMAQU As String = fun_Nombre_de_maquina()

            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "INSERT INTO "
            stConsultaSQL += "OBLIURBA "

            stConsultaSQL += "( "
            stConsultaSQL += "OBURSECU, "
            stConsultaSQL += "OBURCLEN, "
            stConsultaSQL += "OBURNURE, "
            stConsultaSQL += "OBURFERE, "
            stConsultaSQL += "OBURVIRE, "
            stConsultaSQL += "OBURVILI, "
            stConsultaSQL += "OBURFEIN, "
            stConsultaSQL += "OBUROBSE, "
            stConsultaSQL += "OBURESTA, "
            stConsultaSQL += "OBURUSIN, "
            stConsultaSQL += "OBURNDIN, "
            stConsultaSQL += "OBURUSFI, "
            stConsultaSQL += "OBURNDFI, "
            stConsultaSQL += "OBURFEFI, "
            stConsultaSQL += "OBURMAQU "
            stConsultaSQL += ") "

            stConsultaSQL += "VALUES "

            stConsultaSQL += "( "
            stConsultaSQL += "'" & CInt(inOBURSECU) & "', "
            stConsultaSQL += "'" & CStr(Trim(stOBURCLEN)) & "', "
            stConsultaSQL += "'" & CInt(inOBURNURE) & "', "
            stConsultaSQL += "'" & CStr(Trim(stOBURFERE)) & "', "
            stConsultaSQL += "'" & CInt(inOBURVIRE) & "', "
            stConsultaSQL += "'" & CInt(inOBURVILI) & "', "
            stConsultaSQL += "'" & CDate(daOBURFEIN) & "', "
            stConsultaSQL += "'" & CStr(Trim(stOBUROBSE)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stOBURESTA)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stOBURUSIN)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stOBURNDIN)) & "', "
            stConsultaSQL += "'" & CStr(Trim("")) & "', "
            stConsultaSQL += "'" & CStr(Trim("")) & "', "
            stConsultaSQL += "'" & CStr(Trim("")) & "', "
            stConsultaSQL += "'" & CStr(Trim(stOBURMAQU)) & "' "
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
            MessageBox.Show(Err.Description & " " & "fun_Insertar_OBLIURBA")
        End Try

    End Function

    ''' <summary>
    ''' Función que Elimina el registro.
    ''' </summary>
    Public Function fun_Eliminar_IDRE_OBLIURBA(ByVal inOBURIDRE As Integer) As Boolean

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "DELETE "
            stConsultaSQL += "OBLIURBA "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "OBURIDRE = '" & CInt(inOBURIDRE) & "' "

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
            MessageBox.Show(Err.Description & " " & "fun_Eliminar_OBLIURBA")
        End Try

    End Function

    ''' <summary>
    ''' Función que Elimina el registro.
    ''' </summary>
    Public Function fun_Eliminar_SECU_OBLIURBA(ByVal inOBURSECU As Integer) As Boolean

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "DELETE "
            stConsultaSQL += "OBLIURBA "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "OBURSECU = '" & CInt(inOBURSECU) & "' "

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
            MessageBox.Show(Err.Description & " " & "fun_Eliminar_OBLIURBA")
        End Try

    End Function

    ''' <summary>
    ''' Función que Modifica el registro.
    ''' </summary>
    Public Function fun_Actualizar_OBLIURBA(ByVal inOBURIDRE As Integer, _
                                            ByVal inOBURSECU As Integer, _
                                            ByVal stOBURCLEN As String, _
                                            ByVal inOBURNURE As Integer, _
                                            ByVal stOBURFERE As String, _
                                            ByVal inOBURVIRE As Integer, _
                                            ByVal stOBURESTA As String) As Boolean

        Try

            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "UPDATE "
            stConsultaSQL += "OBLIURBA "

            stConsultaSQL += "SET "
            stConsultaSQL += "OBURSECU = '" & CInt(inOBURSECU) & "', "
            stConsultaSQL += "OBURCLEN = '" & CStr(Trim(stOBURCLEN)) & "', "
            stConsultaSQL += "OBURNURE = '" & CInt(inOBURNURE) & "', "
            stConsultaSQL += "OBURFERE = '" & CStr(Trim(stOBURFERE)) & "', "
            stConsultaSQL += "OBURVIRE = '" & CInt(inOBURVIRE) & "', "
            stConsultaSQL += "OBURESTA = '" & CStr(Trim(stOBURESTA)) & "' "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "OBURIDRE = '" & CInt(inOBURIDRE) & "' "

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
            MessageBox.Show(Err.Description & " " & "fun_Actualizar_OBLIURBA")
        End Try

    End Function

    ''' <summary>
    ''' Consulta para llenar el DataGridView y colocar el nombre del encabezado
    ''' de la columna. 
    ''' </summary>
    Public Function fun_Consultar_OBLIURBA() As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "TOP 0 "
            stConsultaSQL += "OBURIDRE, "
            stConsultaSQL += "OBURSECU, "
            stConsultaSQL += "OBURCLEN, "
            stConsultaSQL += "CLENDESC, "
            stConsultaSQL += "OBURNURE, "
            stConsultaSQL += "OBURFERE, "
            stConsultaSQL += "OBURVIRE, "
            stConsultaSQL += "OBURVILI, "
            stConsultaSQL += "OBURFELI, "
            stConsultaSQL += "OBURGRCO, "
            stConsultaSQL += "OBURFEIN, "
            stConsultaSQL += "OBUROBSE, "
            stConsultaSQL += "OBURUSIN, "
            stConsultaSQL += "OBURNDIN, "
            stConsultaSQL += "OBURUSFI, "
            stConsultaSQL += "OBURNDFI, "
            stConsultaSQL += "OBURFEFI, "
            stConsultaSQL += "OBURESTA, "
            stConsultaSQL += "OBURAJLI, "
            stConsultaSQL += "ESTADESC, "
            stConsultaSQL += "OBURMAQU "


            stConsultaSQL += "FROM "
            stConsultaSQL += "OBLIURBA, MANT_CLASENTI, ESTADO "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "OBURCLEN = CLENCODI AND "
            stConsultaSQL += "OBURESTA = ESTACODI "

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "OBURSECU "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Consultar_OBLIURBA")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Llena el ComboBox con datos activos e inactivos formulario principal 
    ''' esta funcion se llama desde el procedimiento "pro_inicializarControles()".
    ''' </summary>
    Public Function fun_Consultar_CAMPOS_OBLIURBA() As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "OBLIURBA "

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "OBURSECU "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Consultar_CAMPOS_OBLIURBA")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Llena el ComboBox con datos activos formulario insertar y modificar 
    ''' esta funcion se llama desde el procedimiento "pro_inicializarControles()".
    ''' </summary>
    Public Function fun_Consultar_OBLIURBA_X_ESTADO() As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "OBLIURBA "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "OBURESTA = 'ac' "

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "OBURSECU "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Consultar_OBLIURBA_X_ESTADO")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que busca el ID del registro a modificar o eliminar.
    ''' </summary>
    Public Function fun_Buscar_ID_OBLIURBA(ByVal inOBURIDRE As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "OBLIURBA "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "OBURIDRE = '" & CInt(inOBURIDRE) & "'"

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Buscar_ID_OBLIURBA")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que busca el ID del registro a modificar o eliminar.
    ''' </summary>
    Public Function fun_Buscar_CODIGO_X_OBLIURBA(ByVal stOBURCLEN As String, _
                                                 ByVal inOBURNURE As Integer, _
                                                 ByVal stOBURFERE As String) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "OBLIURBA "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "OBURCLEN = '" & CStr(Trim(stOBURCLEN)) & "' AND  "
            stConsultaSQL += "OBURNURE = '" & CInt(inOBURNURE) & "'AND  "
            stConsultaSQL += "OBURFERE = '" & CStr(Trim(stOBURFERE)) & "' "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Buscar_NURA_FERA_X_OBLIURBA")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que busca el CÓDIGO para que no se 
    ''' guarden registros duplicados.
    ''' </summary>
    Public Function fun_Buscar_CODIGO_X_OBLIURBA(ByVal inOBURSECU As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "OBLIURBA "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "OBURSECU = '" & CInt(inOBURSECU) & "' "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Buscar_CODIGO_OBLIURBA")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que busca el ID del codigo buscado para ejecutar la consulta
    ''' parametrizada.
    ''' </summary>
    Public Function fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_OBLIURBA(ByVal inOBURIDRE As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "TOP 1 "
            stConsultaSQL += "OBURIDRE, "
            stConsultaSQL += "OBURSECU, "
            stConsultaSQL += "OBURCLEN, "
            stConsultaSQL += "CLENDESC, "
            stConsultaSQL += "OBURNURE, "
            stConsultaSQL += "OBURFERE, "
            stConsultaSQL += "OBURVIRE, "
            stConsultaSQL += "OBURVILI, "
            stConsultaSQL += "OBURFELI, "
            stConsultaSQL += "OBURGRCO, "
            stConsultaSQL += "OBURFEIN, "
            stConsultaSQL += "OBUROBSE, "
            stConsultaSQL += "OBURUSIN, "
            stConsultaSQL += "OBURNDIN, "
            stConsultaSQL += "OBURUSFI, "
            stConsultaSQL += "OBURNDFI, "
            stConsultaSQL += "OBURFEFI, "
            stConsultaSQL += "OBURESTA, "
            stConsultaSQL += "OBURAJLI, "
            stConsultaSQL += "ESTADESC, "
            stConsultaSQL += "OBURMAQU "

            stConsultaSQL += "FROM "
            stConsultaSQL += "OBLIURBA, MANT_CLASENTI, ESTADO "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "OBURCLEN = CLENCODI AND "
            stConsultaSQL += "OBURESTA = ESTACODI AND "
            stConsultaSQL += "OBURIDRE = '" & CInt(inOBURIDRE) & "'"

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "OBURSECU "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception

            MessageBox.Show(Err.Description & " " & "fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_OBLIURBA")
            Return Nothing

        End Try

    End Function

    ''' <summary>
    ''' Función que busca la secuencia
    ''' </summary>
    Public Function fun_Buscar_SECUENCIA_X_OBLIURBA() As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "OBURSECU "

            stConsultaSQL += "FROM "
            stConsultaSQL += "OBLIURBA "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Buscar_SECUENCIA_X_OBLIURBA")
            Return Nothing
        End Try

    End Function

End Class
