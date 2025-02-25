Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration
Imports DATOS

Public Class cla_REAVINUS

    '=======================================================
    '*** CLASE INFORMACIÓN DE USUARIO REVISION DE AVALUO ***
    '=======================================================

    ''' <summary>
    ''' procedimiento que verifica la llave primaria.
    ''' </summary>
    Public Function fun_Verifica_llave_Primaria_REAVINUS(ByVal obRAIUSECU As Object, ByVal obRAIUNUDO As Object) As Boolean

        Try
            Dim boRespuesta As Boolean = False

            Dim obVerifica As New cla_Verificar_Dato

            If obVerifica.fun_Verificar_Campo_Lleno(obRAIUSECU.Text) = True And _
                obVerifica.fun_Verificar_Campo_Lleno(obRAIUNUDO.Text) = True Then

                If obVerifica.fun_Verificar_Dato_Numerico(obRAIUSECU.Text) = True Then

                    Dim objdatos1 As New cla_REAVINUS
                    Dim tbl As New DataTable

                    tbl = objdatos1.fun_Buscar_CODIGO_X_REAVINUS(obRAIUSECU.Text, obRAIUNUDO.Text)

                    If tbl.Rows.Count > 0 Then
                        MessageBox.Show("El dato " & Trim(obRAIUSECU.Text) & " - " & Trim(obRAIUNUDO.Text) & " existe en la base de datos, se incrementara una secuencia, favor guardar.", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                        obRAIUSECU.Focus()
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
    Public Function fun_Insertar_REAVINUS(ByVal inRAIUSECU As Integer, _
                                          ByVal stRAIUDIPR As String, _
                                          ByVal stRAIUDINO As String, _
                                          ByVal stRAIUNOMB As String, _
                                          ByVal stRAIUPRAP As String, _
                                          ByVal stRAIUSEAP As String, _
                                          ByVal stRAIUTEL1 As String, _
                                          ByVal stRAIUTEL2 As String, _
                                          ByVal boRAIUACTA As Boolean, _
                                          ByVal inRAIUNUAC As Integer, _
                                          ByVal boRAIUACFI As Boolean, _
                                          ByVal stRAIUFEEN As String, _
                                          ByVal stRAIUFERE As String, _
                                          ByVal stRAIUOBSE As String) As Boolean

        Try

            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "INSERT INTO "
            stConsultaSQL += "REAVINUS "

            stConsultaSQL += "( "
            stConsultaSQL += "RAIUSECU, "
            stConsultaSQL += "RAIUDIPR, "
            stConsultaSQL += "RAIUDINO, "
            stConsultaSQL += "RAIUNOMB, "
            stConsultaSQL += "RAIUPRAP, "
            stConsultaSQL += "RAIUSEAP, "
            stConsultaSQL += "RAIUTEL1, "
            stConsultaSQL += "RAIUTEL2, "
            stConsultaSQL += "RAIUACTA, "
            stConsultaSQL += "RAIUNUAC, "
            stConsultaSQL += "RAIUACFI, "
            stConsultaSQL += "RAIUFEEN, "
            stConsultaSQL += "RAIUFERE, "
            stConsultaSQL += "RAIUOBSE "
            stConsultaSQL += ") "

            stConsultaSQL += "VALUES "

            stConsultaSQL += "( "
            stConsultaSQL += "'" & CInt(inRAIUSECU) & "', "
            stConsultaSQL += "'" & CStr(Trim(stRAIUDIPR)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stRAIUDINO)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stRAIUNOMB)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stRAIUPRAP)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stRAIUSEAP)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stRAIUTEL1)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stRAIUTEL2)) & "', "
            stConsultaSQL += "'" & CBool(boRAIUACTA) & "', "
            stConsultaSQL += "'" & CInt(inRAIUNUAC) & "', "
            stConsultaSQL += "'" & CBool(boRAIUACFI) & "', "
            stConsultaSQL += "'" & CStr(Trim(stRAIUFEEN)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stRAIUFERE)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stRAIUOBSE)) & "' "
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
            MessageBox.Show(Err.Description & " " & "fun_Insertar_REAVINUS")
        End Try

    End Function

    ''' <summary>
    ''' Función que Elimina el registro.
    ''' </summary>
    Public Function fun_Eliminar_IDRE_REAVINUS(ByVal inRAIUIDRE As Integer) As Boolean

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "DELETE "
            stConsultaSQL += "REAVINUS "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "RAIUIDRE = '" & CInt(inRAIUIDRE) & "' "

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
            MessageBox.Show(Err.Description & " " & "fun_Eliminar_IDRE_REAVINUS")
        End Try

    End Function

    ''' <summary>
    ''' Función que Elimina el registro.
    ''' </summary>
    Public Function fun_Eliminar_SECU_X_NUDO_REAVINUS(ByVal inRAIUSECU As Integer, ByVal stRAIUNUDO As String) As Boolean

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "DELETE "
            stConsultaSQL += "REAVINUS "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "RAIUSECU = '" & CInt(inRAIUSECU) & "' and "
            stConsultaSQL += "RAIUNUDO = '" & CStr(Trim(stRAIUNUDO)) & "' "

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
            MessageBox.Show(Err.Description & " " & "fun_Eliminar_SECU_X_MACA_REAVINUS")
        End Try

    End Function

    ''' <summary>
    ''' Función que Elimina el registro.
    ''' </summary>
    Public Function fun_Eliminar_SECU_REAVINUS(ByVal inRAIUSECU As Integer) As Boolean

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "DELETE "
            stConsultaSQL += "REAVINUS "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "RAIUSECU = '" & CInt(inRAIUSECU) & "' "

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
            MessageBox.Show(Err.Description & " " & "fun_Eliminar_IDRE_REAVINUS")
        End Try

    End Function

    ''' <summary>
    ''' Función que Modifica el registro.
    ''' </summary>
    Public Function fun_Actualizar_IDRE_X_REAVINUS(ByVal inRAIUIDRE As Integer, _
                                                  ByVal inRAIUSECU As Integer, _
                                                  ByVal stRAIUDIPR As String, _
                                                  ByVal stRAIUDINO As String, _
                                                  ByVal stRAIUNOMB As String, _
                                                  ByVal stRAIUPRAP As String, _
                                                  ByVal stRAIUSEAP As String, _
                                                  ByVal stRAIUTEL1 As String, _
                                                  ByVal stRAIUTEL2 As String, _
                                                  ByVal boRAIUACTA As Boolean, _
                                                  ByVal inRAIUNUAC As Integer, _
                                                  ByVal boRAIUACFI As Boolean, _
                                                  ByVal stRAIUFEEN As String, _
                                                  ByVal stRAIUFERE As String, _
                                                  ByVal stRAIUOBSE As String) As Boolean

        Try

            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "UPDATE "
            stConsultaSQL += "REAVINUS "

            stConsultaSQL += "SET "
            stConsultaSQL += "RAIUSECU = '" & CInt(inRAIUSECU) & "', "
            stConsultaSQL += "RAIUDIPR = '" & CStr(Trim(stRAIUDIPR)) & "', "
            stConsultaSQL += "RAIUDINO = '" & CStr(Trim(stRAIUDINO)) & "', "
            stConsultaSQL += "RAIUNOMB = '" & CStr(Trim(stRAIUNOMB)) & "', "
            stConsultaSQL += "RAIUPRAP = '" & CStr(Trim(stRAIUPRAP)) & "', "
            stConsultaSQL += "RAIUSEAP = '" & CStr(Trim(stRAIUSEAP)) & "', "
            stConsultaSQL += "RAIUTEL1 = '" & CStr(Trim(stRAIUTEL1)) & "', "
            stConsultaSQL += "RAIUTEL2 = '" & CStr(Trim(stRAIUTEL2)) & "', "
            stConsultaSQL += "RAIUACTA = '" & CBool(boRAIUACTA) & "', "
            stConsultaSQL += "RAIUNUAC = '" & CInt(inRAIUNUAC) & "', "
            stConsultaSQL += "RAIUACFI = '" & CBool(boRAIUACFI) & "', "
            stConsultaSQL += "RAIUFEEN = '" & CStr(Trim(stRAIUFEEN)) & "', "
            stConsultaSQL += "RAIUFERE = '" & CStr(Trim(stRAIUFERE)) & "', "
            stConsultaSQL += "RAIUOBSE = '" & CStr(Trim(stRAIUOBSE)) & "' "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "RAIUIDRE = '" & CInt(inRAIUIDRE) & "' "

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
            MessageBox.Show(Err.Description & " " & "fun_Actualizar_REAVINUS")
        End Try

    End Function

    ''' <summary>
    ''' Función que Modifica el registro.
    ''' </summary>
    Public Function fun_Actualizar_SECU_X_REAVINUS(ByVal inRAIUSECU As Integer, _
                                                  ByVal stRAIUDIPR As String, _
                                                  ByVal stRAIUDINO As String, _
                                                  ByVal stRAIUNOMB As String, _
                                                  ByVal stRAIUPRAP As String, _
                                                  ByVal stRAIUSEAP As String, _
                                                  ByVal stRAIUTEL1 As String, _
                                                  ByVal stRAIUTEL2 As String, _
                                                  ByVal boRAIUACTA As Boolean, _
                                                  ByVal inRAIUNUAC As Integer, _
                                                  ByVal boRAIUACFI As Boolean, _
                                                  ByVal stRAIUFEEN As String, _
                                                  ByVal stRAIUFERE As String, _
                                                  ByVal stRAIUOBSE As String) As Boolean

        Try

            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "UPDATE "
            stConsultaSQL += "REAVINUS "

            stConsultaSQL += "SET "
            stConsultaSQL += "RAIUSECU = '" & CInt(inRAIUSECU) & "', "
            stConsultaSQL += "RAIUDIPR = '" & CStr(Trim(stRAIUDIPR)) & "', "
            stConsultaSQL += "RAIUDINO = '" & CStr(Trim(stRAIUDINO)) & "', "
            stConsultaSQL += "RAIUNOMB = '" & CStr(Trim(stRAIUNOMB)) & "', "
            stConsultaSQL += "RAIUPRAP = '" & CStr(Trim(stRAIUPRAP)) & "', "
            stConsultaSQL += "RAIUSEAP = '" & CStr(Trim(stRAIUSEAP)) & "', "
            stConsultaSQL += "RAIUTEL1 = '" & CStr(Trim(stRAIUTEL1)) & "', "
            stConsultaSQL += "RAIUTEL2 = '" & CStr(Trim(stRAIUTEL2)) & "', "
            stConsultaSQL += "RAIUACTA = '" & CBool(boRAIUACTA) & "', "
            stConsultaSQL += "RAIUNUAC = '" & CInt(inRAIUNUAC) & "', "
            stConsultaSQL += "RAIUACFI = '" & CBool(boRAIUACFI) & "', "
            stConsultaSQL += "RAIUFEEN = '" & CStr(Trim(stRAIUFEEN)) & "', "
            stConsultaSQL += "RAIUFERE = '" & CStr(Trim(stRAIUFERE)) & "', "
            stConsultaSQL += "RAIUOBSE = '" & CStr(Trim(stRAIUOBSE)) & "' "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "RAIUSECU = '" & CInt(inRAIUSECU) & "' "

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
            MessageBox.Show(Err.Description & " " & "fun_Actualizar_REAVINUS")
        End Try

    End Function

    ''' <summary>
    ''' Consulta para llenar el DataGridView y colocar el nombre del encabezado
    ''' de la columna. 
    ''' </summary>
    Public Function fun_Consultar_REAVINUS(ByVal inRAIUSECU As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "RAIUIDRE, "
            stConsultaSQL += "RAIUSECU, "
            stConsultaSQL += "RAIUDIPR, "
            stConsultaSQL += "RAIUDINO, "
            stConsultaSQL += "RAIUNOMB, "
            stConsultaSQL += "RAIUPRAP, "
            stConsultaSQL += "RAIUSEAP, "
            stConsultaSQL += "RAIUTEL1, "
            stConsultaSQL += "RAIUTEL2, "
            stConsultaSQL += "RAIUACTA, "
            stConsultaSQL += "RAIUNUAC, "
            stConsultaSQL += "RAIUACFI, "
            stConsultaSQL += "RAIUFEEN, "
            stConsultaSQL += "RAIUFERE, "
            stConsultaSQL += "RAIUOBSE "

            stConsultaSQL += "FROM "
            stConsultaSQL += "REAVINUS "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "RAIUSECU = '" & CInt(inRAIUSECU) & " '"

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "RAIUSECU "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl


        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Consultar_REAVINUS")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que busca el ID del codigo buscado para ejecutar la consulta
    ''' parametrizada.
    ''' </summary>
    Public Function fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_REAVINUS(ByVal inRAIUSECU As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "RAIUIDRE, "
            stConsultaSQL += "RAIUSECU, "
            stConsultaSQL += "RAIUDIPR, "
            stConsultaSQL += "RAIUDINO, "
            stConsultaSQL += "RAIUNOMB, "
            stConsultaSQL += "RAIUPRAP, "
            stConsultaSQL += "RAIUSEAP, "
            stConsultaSQL += "RAIUTEL1, "
            stConsultaSQL += "RAIUTEL2, "
            stConsultaSQL += "RAIUACTA, "
            stConsultaSQL += "RAIUNUAC, "
            stConsultaSQL += "RAIUACFI, "
            stConsultaSQL += "RAIUFEEN, "
            stConsultaSQL += "RAIUFERE, "
            stConsultaSQL += "RAIUOBSE "

            stConsultaSQL += "FROM "
            stConsultaSQL += "REAVINUS "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "RAIUSECU = '" & CInt(inRAIUSECU) & " '"

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "RAIUSECU "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception

            MessageBox.Show(Err.Description & " " & "fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_REAVINUS")
            Return Nothing

        End Try

    End Function

    ''' <summary>
    ''' Función que busca el CÓDIGO para que no se 
    ''' guarden registros duplicados.
    ''' </summary>
    Public Function fun_Buscar_CODIGO_X_REAVINUS(ByVal inRAIUSECU As Integer, ByVal stRAIUNUDO As String) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "REAVINUS "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "RAIUSECU = '" & CInt(inRAIUSECU) & "' and "
            stConsultaSQL += "RAIUNUDO = '" & CStr(Trim(stRAIUNUDO)) & "' "

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
