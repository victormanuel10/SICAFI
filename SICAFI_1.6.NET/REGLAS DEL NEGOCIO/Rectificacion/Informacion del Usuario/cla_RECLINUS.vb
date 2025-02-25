Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration
Imports DATOS

Public Class cla_RECLINUS

    '=============================================
    '*** CLASE INFORMACIÓN DE USUARIO RECLAMOS ***
    '=============================================

    ''' <summary>
    ''' procedimiento que verifica la llave primaria.
    ''' </summary>
    Public Function fun_Verifica_llave_Primaria_RECLINUS(ByVal obREIUSECU As Object, ByVal obREIUNUDO As Object) As Boolean

        Try
            Dim boRespuesta As Boolean = False

            Dim obVerifica As New cla_Verificar_Dato

            If obVerifica.fun_Verificar_Campo_Lleno(obREIUSECU.Text) = True And _
                obVerifica.fun_Verificar_Campo_Lleno(obREIUNUDO.Text) = True Then

                If obVerifica.fun_Verificar_Dato_Numerico(obREIUSECU.Text) = True Then

                    Dim objdatos1 As New cla_RECLINUS
                    Dim tbl As New DataTable

                    tbl = objdatos1.fun_Buscar_CODIGO_X_RECLINUS(obREIUSECU.Text, obREIUNUDO.Text)

                    If tbl.Rows.Count > 0 Then
                        MessageBox.Show("El dato " & Trim(obREIUSECU.Text) & " - " & Trim(obREIUNUDO.Text) & " existe en la base de datos, se incrementara una secuencia, favor guardar.", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                        obREIUSECU.Focus()
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
    Public Function fun_Insertar_RECLINUS(ByVal inREIUSECU As Integer, _
                                          ByVal stREIUDIPR As String, _
                                          ByVal stREIUDINO As String, _
                                          ByVal stREIUNOMB As String, _
                                          ByVal stREIUPRAP As String, _
                                          ByVal stREIUSEAP As String, _
                                          ByVal stREIUTEL1 As String, _
                                          ByVal stREIUTEL2 As String, _
                                          ByVal boREIUACTA As Boolean, _
                                          ByVal inREIUNUAC As Integer, _
                                          ByVal boREIUACFI As Boolean, _
                                          ByVal stREIUFEEN As String, _
                                          ByVal stREIUFERE As String, _
                                          ByVal stREIUOBSE As String) As Boolean

        Try

            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "INSERT INTO "
            stConsultaSQL += "RECLINUS "

            stConsultaSQL += "( "
            stConsultaSQL += "REIUSECU, "
            stConsultaSQL += "REIUDIPR, "
            stConsultaSQL += "REIUDINO, "
            stConsultaSQL += "REIUNOMB, "
            stConsultaSQL += "REIUPRAP, "
            stConsultaSQL += "REIUSEAP, "
            stConsultaSQL += "REIUTEL1, "
            stConsultaSQL += "REIUTEL2, "
            stConsultaSQL += "REIUACTA, "
            stConsultaSQL += "REIUNUAC, "
            stConsultaSQL += "REIUACFI, "
            stConsultaSQL += "REIUFEEN, "
            stConsultaSQL += "REIUFERE, "
            stConsultaSQL += "REIUOBSE "
            stConsultaSQL += ") "

            stConsultaSQL += "VALUES "

            stConsultaSQL += "( "
            stConsultaSQL += "'" & CInt(inREIUSECU) & "', "
            stConsultaSQL += "'" & CStr(Trim(stREIUDIPR)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stREIUDINO)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stREIUNOMB)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stREIUPRAP)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stREIUSEAP)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stREIUTEL1)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stREIUTEL2)) & "', "
            stConsultaSQL += "'" & CBool(boREIUACTA) & "', "
            stConsultaSQL += "'" & CInt(inREIUNUAC) & "', "
            stConsultaSQL += "'" & CBool(boREIUACFI) & "', "
            stConsultaSQL += "'" & CStr(Trim(stREIUFEEN)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stREIUFERE)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stREIUOBSE)) & "' "
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
            MessageBox.Show(Err.Description & " " & "fun_Insertar_RECLINUS")
        End Try

    End Function

    ''' <summary>
    ''' Función que Elimina el registro.
    ''' </summary>
    Public Function fun_Eliminar_IDRE_RECLINUS(ByVal inREIUIDRE As Integer) As Boolean

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "DELETE "
            stConsultaSQL += "RECLINUS "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "REIUIDRE = '" & CInt(inREIUIDRE) & "' "

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
            MessageBox.Show(Err.Description & " " & "fun_Eliminar_IDRE_RECLINUS")
        End Try

    End Function

    ''' <summary>
    ''' Función que Elimina el registro.
    ''' </summary>
    Public Function fun_Eliminar_SECU_X_NUDO_RECLINUS(ByVal inREIUSECU As Integer, ByVal stREIUNUDO As String) As Boolean

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "DELETE "
            stConsultaSQL += "RECLINUS "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "REIUSECU = '" & CInt(inREIUSECU) & "' and "
            stConsultaSQL += "REIUNUDO = '" & CStr(Trim(stREIUNUDO)) & "' "

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
            MessageBox.Show(Err.Description & " " & "fun_Eliminar_SECU_X_MACA_RECLINUS")
        End Try

    End Function

    ''' <summary>
    ''' Función que Elimina el registro.
    ''' </summary>
    Public Function fun_Eliminar_SECU_RECLINUS(ByVal inREIUSECU As Integer) As Boolean

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "DELETE "
            stConsultaSQL += "RECLINUS "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "REIUSECU = '" & CInt(inREIUSECU) & "' "

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
            MessageBox.Show(Err.Description & " " & "fun_Eliminar_IDRE_RECLINUS")
        End Try

    End Function

    ''' <summary>
    ''' Función que Modifica el registro.
    ''' </summary>
    Public Function fun_Actualizar_IDRE_X_RECLINUS(ByVal inREIUIDRE As Integer, _
                                                  ByVal inREIUSECU As Integer, _
                                                  ByVal stREIUDIPR As String, _
                                                  ByVal stREIUDINO As String, _
                                                  ByVal stREIUNOMB As String, _
                                                  ByVal stREIUPRAP As String, _
                                                  ByVal stREIUSEAP As String, _
                                                  ByVal stREIUTEL1 As String, _
                                                  ByVal stREIUTEL2 As String, _
                                                  ByVal boREIUACTA As Boolean, _
                                                  ByVal inREIUNUAC As Integer, _
                                                  ByVal boREIUACFI As Boolean, _
                                                  ByVal stREIUFEEN As String, _
                                                  ByVal stREIUFERE As String, _
                                                  ByVal stREIUOBSE As String) As Boolean

        Try

            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "UPDATE "
            stConsultaSQL += "RECLINUS "

            stConsultaSQL += "SET "
            stConsultaSQL += "REIUSECU = '" & CInt(inREIUSECU) & "', "
            stConsultaSQL += "REIUDIPR = '" & CStr(Trim(stREIUDIPR)) & "', "
            stConsultaSQL += "REIUDINO = '" & CStr(Trim(stREIUDINO)) & "', "
            stConsultaSQL += "REIUNOMB = '" & CStr(Trim(stREIUNOMB)) & "', "
            stConsultaSQL += "REIUPRAP = '" & CStr(Trim(stREIUPRAP)) & "', "
            stConsultaSQL += "REIUSEAP = '" & CStr(Trim(stREIUSEAP)) & "', "
            stConsultaSQL += "REIUTEL1 = '" & CStr(Trim(stREIUTEL1)) & "', "
            stConsultaSQL += "REIUTEL2 = '" & CStr(Trim(stREIUTEL2)) & "', "
            stConsultaSQL += "REIUACTA = '" & CBool(boREIUACTA) & "', "
            stConsultaSQL += "REIUNUAC = '" & CInt(inREIUNUAC) & "', "
            stConsultaSQL += "REIUACFI = '" & CBool(boREIUACFI) & "', "
            stConsultaSQL += "REIUFEEN = '" & CStr(Trim(stREIUFEEN)) & "', "
            stConsultaSQL += "REIUFERE = '" & CStr(Trim(stREIUFERE)) & "', "
            stConsultaSQL += "REIUOBSE = '" & CStr(Trim(stREIUOBSE)) & "' "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "REIUIDRE = '" & CInt(inREIUIDRE) & "' "

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
            MessageBox.Show(Err.Description & " " & "fun_Actualizar_RECLINUS")
        End Try

    End Function

    ''' <summary>
    ''' Función que Modifica el registro.
    ''' </summary>
    Public Function fun_Actualizar_SECU_X_RECLINUS(ByVal inREIUSECU As Integer, _
                                                  ByVal stREIUDIPR As String, _
                                                  ByVal stREIUDINO As String, _
                                                  ByVal stREIUNOMB As String, _
                                                  ByVal stREIUPRAP As String, _
                                                  ByVal stREIUSEAP As String, _
                                                  ByVal stREIUTEL1 As String, _
                                                  ByVal stREIUTEL2 As String, _
                                                  ByVal boREIUACTA As Boolean, _
                                                  ByVal inREIUNUAC As Integer, _
                                                  ByVal boREIUACFI As Boolean, _
                                                  ByVal stREIUFEEN As String, _
                                                  ByVal stREIUFERE As String, _
                                                  ByVal stREIUOBSE As String) As Boolean

        Try

            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "UPDATE "
            stConsultaSQL += "RECLINUS "

            stConsultaSQL += "SET "
            stConsultaSQL += "REIUSECU = '" & CInt(inREIUSECU) & "', "
            stConsultaSQL += "REIUDIPR = '" & CStr(Trim(stREIUDIPR)) & "', "
            stConsultaSQL += "REIUDINO = '" & CStr(Trim(stREIUDINO)) & "', "
            stConsultaSQL += "REIUNOMB = '" & CStr(Trim(stREIUNOMB)) & "', "
            stConsultaSQL += "REIUPRAP = '" & CStr(Trim(stREIUPRAP)) & "', "
            stConsultaSQL += "REIUSEAP = '" & CStr(Trim(stREIUSEAP)) & "', "
            stConsultaSQL += "REIUTEL1 = '" & CStr(Trim(stREIUTEL1)) & "', "
            stConsultaSQL += "REIUTEL2 = '" & CStr(Trim(stREIUTEL2)) & "', "
            stConsultaSQL += "REIUACTA = '" & CBool(boREIUACTA) & "', "
            stConsultaSQL += "REIUNUAC = '" & CInt(inREIUNUAC) & "', "
            stConsultaSQL += "REIUACFI = '" & CBool(boREIUACFI) & "', "
            stConsultaSQL += "REIUFEEN = '" & CStr(Trim(stREIUFEEN)) & "', "
            stConsultaSQL += "REIUFERE = '" & CStr(Trim(stREIUFERE)) & "', "
            stConsultaSQL += "REIUOBSE = '" & CStr(Trim(stREIUOBSE)) & "' "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "REIUSECU = '" & CInt(inREIUSECU) & "' "

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
            MessageBox.Show(Err.Description & " " & "fun_Actualizar_RECLINUS")
        End Try

    End Function

    ''' <summary>
    ''' Consulta para llenar el DataGridView y colocar el nombre del encabezado
    ''' de la columna. 
    ''' </summary>
    Public Function fun_Consultar_RECLINUS(ByVal inREIUSECU As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "REIUIDRE, "
            stConsultaSQL += "REIUSECU, "
            stConsultaSQL += "REIUDIPR, "
            stConsultaSQL += "REIUDINO, "
            stConsultaSQL += "REIUNOMB, "
            stConsultaSQL += "REIUPRAP, "
            stConsultaSQL += "REIUSEAP, "
            stConsultaSQL += "REIUTEL1, "
            stConsultaSQL += "REIUTEL2, "
            stConsultaSQL += "REIUACTA, "
            stConsultaSQL += "REIUNUAC, "
            stConsultaSQL += "REIUACFI, "
            stConsultaSQL += "REIUFEEN, "
            stConsultaSQL += "REIUFERE, "
            stConsultaSQL += "REIUOBSE "

            stConsultaSQL += "FROM "
            stConsultaSQL += "RECLINUS "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "REIUSECU = '" & CInt(inREIUSECU) & " '"

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "REIUSECU "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl


        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Consultar_RECLINUS")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que busca el ID del codigo buscado para ejecutar la consulta
    ''' parametrizada.
    ''' </summary>
    Public Function fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_RECLINUS(ByVal inREIUSECU As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "REIUIDRE, "
            stConsultaSQL += "REIUSECU, "
            stConsultaSQL += "REIUDIPR, "
            stConsultaSQL += "REIUDINO, "
            stConsultaSQL += "REIUNOMB, "
            stConsultaSQL += "REIUPRAP, "
            stConsultaSQL += "REIUSEAP, "
            stConsultaSQL += "REIUTEL1, "
            stConsultaSQL += "REIUTEL2, "
            stConsultaSQL += "REIUACTA, "
            stConsultaSQL += "REIUNUAC, "
            stConsultaSQL += "REIUACFI, "
            stConsultaSQL += "REIUFEEN, "
            stConsultaSQL += "REIUFERE, "
            stConsultaSQL += "REIUOBSE "

            stConsultaSQL += "FROM "
            stConsultaSQL += "RECLINUS "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "REIUSECU = '" & CInt(inREIUSECU) & " '"

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "REIUSECU "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception

            MessageBox.Show(Err.Description & " " & "fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_RECLINUS")
            Return Nothing

        End Try

    End Function

    ''' <summary>
    ''' Función que busca el CÓDIGO para que no se 
    ''' guarden registros duplicados.
    ''' </summary>
    Public Function fun_Buscar_CODIGO_X_RECLINUS(ByVal inREIUSECU As Integer, ByVal stREIUNUDO As String) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "RECLINUS "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "REIUSECU = '" & CInt(inREIUSECU) & "' and "
            stConsultaSQL += "REIUNUDO = '" & CStr(Trim(stREIUNUDO)) & "' "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Buscar_CODIGO_TRABCAMP")
            Return Nothing
        End Try

    End Function

End Class
