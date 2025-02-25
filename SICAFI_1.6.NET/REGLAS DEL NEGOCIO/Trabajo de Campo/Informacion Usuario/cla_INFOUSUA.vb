Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration
Imports DATOS

Public Class cla_INFOUSUA

    '=====================================================
    '*** CLASE INFORMACIÓN DE USUARIO TRABAJO DE CAMPO ***
    '=====================================================

    ''' <summary>
    ''' procedimiento que verifica la llave primaria.
    ''' </summary>
    Public Function fun_Verifica_llave_Primaria_INFOUSUA(ByVal obINUSSECU As Object, ByVal obINUSNUDO As Object) As Boolean

        Try
            Dim boRespuesta As Boolean = False

            Dim obVerifica As New cla_Verificar_Dato

            If obVerifica.fun_Verificar_Campo_Lleno(obINUSSECU.Text) = True And _
                obVerifica.fun_Verificar_Campo_Lleno(obINUSNUDO.Text) = True Then

                If obVerifica.fun_Verificar_Dato_Numerico(obINUSSECU.Text) = True Then

                    Dim objdatos1 As New cla_INFOUSUA
                    Dim tbl As New DataTable

                    tbl = objdatos1.fun_Buscar_CODIGO_X_INFOUSUA(obINUSSECU.Text, obINUSNUDO.Text)

                    If tbl.Rows.Count > 0 Then
                        MessageBox.Show("El dato " & Trim(obINUSSECU.Text) & " - " & Trim(obINUSNUDO.Text) & " existe en la base de datos, se incrementara una secuencia, favor guardar.", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                        obINUSSECU.Focus()
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
    Public Function fun_Insertar_INFOUSUA(ByVal inINUSSECU As Integer, _
                                          ByVal stINUSNUDO As String, _
                                          ByVal stINUSFERE As String, _
                                          ByVal stINUSNOMB As String, _
                                          ByVal stINUSPRAP As String, _
                                          ByVal stINUSSEAP As String, _
                                          ByVal stINUSTEL1 As String, _
                                          ByVal stINUSTEL2 As String, _
                                          ByVal stINUSDIRE As String, _
                                          ByVal stINUSOBSE As String) As Boolean

        Try

            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "INSERT INTO "
            stConsultaSQL += "INFOUSUA "

            stConsultaSQL += "( "
            stConsultaSQL += "INUSSECU, "
            stConsultaSQL += "INUSNUDO, "
            stConsultaSQL += "INUSFERE, "
            stConsultaSQL += "INUSNOMB, "
            stConsultaSQL += "INUSPRAP, "
            stConsultaSQL += "INUSSEAP, "
            stConsultaSQL += "INUSTEL1, "
            stConsultaSQL += "INUSTEL2, "
            stConsultaSQL += "INUSDIRE, "
            stConsultaSQL += "INUSOBSE "
            stConsultaSQL += ") "

            stConsultaSQL += "VALUES "

            stConsultaSQL += "( "
            stConsultaSQL += "'" & CInt(inINUSSECU) & "', "
            stConsultaSQL += "'" & CStr(Trim(stINUSNUDO)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stINUSFERE)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stINUSNOMB)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stINUSPRAP)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stINUSSEAP)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stINUSTEL1)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stINUSTEL2)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stINUSDIRE)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stINUSOBSE)) & "' "
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
            MessageBox.Show(Err.Description & " " & "fun_Insertar_INFOUSUA")
        End Try

    End Function

    ''' <summary>
    ''' Función que Elimina el registro.
    ''' </summary>
    Public Function fun_Eliminar_IDRE_INFOUSUA(ByVal inINUSIDRE As Integer) As Boolean

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "DELETE "
            stConsultaSQL += "INFOUSUA "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "INUSIDRE = '" & CInt(inINUSIDRE) & "' "

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
            MessageBox.Show(Err.Description & " " & "fun_Eliminar_IDRE_INFOUSUA")
        End Try

    End Function

    ''' <summary>
    ''' Función que Elimina el registro.
    ''' </summary>
    Public Function fun_Eliminar_SECU_X_NUDO_INFOUSUA(ByVal inINUSSECU As Integer, ByVal stINUSNUDO As String) As Boolean

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "DELETE "
            stConsultaSQL += "INFOUSUA "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "INUSSECU = '" & CInt(inINUSSECU) & "' and "
            stConsultaSQL += "INUSNUDO = '" & CStr(Trim(stINUSNUDO)) & "' "

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
            MessageBox.Show(Err.Description & " " & "fun_Eliminar_SECU_X_MACA_INFOUSUA")
        End Try

    End Function

    ''' <summary>
    ''' Función que Elimina el registro.
    ''' </summary>
    Public Function fun_Eliminar_SECU_INFOUSUA(ByVal inINUSSECU As Integer) As Boolean

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "DELETE "
            stConsultaSQL += "INFOUSUA "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "INUSSECU = '" & CInt(inINUSSECU) & "' "

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
            MessageBox.Show(Err.Description & " " & "fun_Eliminar_IDRE_INFOUSUA")
        End Try

    End Function

    ''' <summary>
    ''' Función que Modifica el registro.
    ''' </summary>
    Public Function fun_Actualizar_IDRE_X_INFOUSUA(ByVal stINUSIDRE As Integer, _
                                            ByVal inINUSSECU As Integer, _
                                            ByVal stINUSNUDO As String, _
                                            ByVal stINUSFERE As String, _
                                            ByVal stINUSNOMB As String, _
                                            ByVal stINUSPRAP As String, _
                                            ByVal stINUSSEAP As String, _
                                            ByVal stINUSTEL1 As String, _
                                            ByVal stINUSTEL2 As String, _
                                            ByVal stINUSDIRE As String, _
                                            ByVal stINUSOBSE As String) As Boolean

        Try

            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "UPDATE "
            stConsultaSQL += "INFOUSUA "

            stConsultaSQL += "SET "
            stConsultaSQL += "INUSSECU = '" & CInt(inINUSSECU) & "', "
            stConsultaSQL += "INUSNUDO = '" & CStr(Trim(stINUSNUDO)) & "', "
            stConsultaSQL += "INUSFERE = '" & CStr(Trim(stINUSFERE)) & "', "
            stConsultaSQL += "INUSNOMB = '" & CStr(Trim(stINUSNOMB)) & "', "
            stConsultaSQL += "INUSPRAP = '" & CStr(Trim(stINUSPRAP)) & "', "
            stConsultaSQL += "INUSSEAP = '" & CStr(Trim(stINUSSEAP)) & "', "
            stConsultaSQL += "INUSFERE = '" & CStr(Trim(stINUSFERE)) & "', "
            stConsultaSQL += "INUSTEL1 = '" & CStr(Trim(stINUSTEL1)) & "', "
            stConsultaSQL += "INUSTEL2 = '" & CStr(Trim(stINUSTEL2)) & "', "
            stConsultaSQL += "INUSDIRE = '" & CStr(Trim(stINUSDIRE)) & "', "
            stConsultaSQL += "INUSOBSE = '" & CStr(Trim(stINUSOBSE)) & "' "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "INUSIDRE = '" & CInt(stINUSIDRE) & "' "

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
            MessageBox.Show(Err.Description & " " & "fun_Actualizar_INFOUSUA")
        End Try

    End Function

    ''' <summary>
    ''' Función que Modifica el registro.
    ''' </summary>
    Public Function fun_Actualizar_SECU_X_INFOUSUA(ByVal inINUSSECU As Integer, _
                                                   ByVal stINUSNUDO As String, _
                                                   ByVal stINUSFERE As String, _
                                                   ByVal stINUSNOMB As String, _
                                                   ByVal stINUSPRAP As String, _
                                                   ByVal stINUSSEAP As String, _
                                                   ByVal stINUSTEL1 As String, _
                                                   ByVal stINUSTEL2 As String, _
                                                   ByVal stINUSDIRE As String, _
                                                   ByVal stINUSOBSE As String) As Boolean

        Try

            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "UPDATE "
            stConsultaSQL += "INFOUSUA "

            stConsultaSQL += "SET "
            stConsultaSQL += "INUSSECU = '" & CInt(inINUSSECU) & "', "
            stConsultaSQL += "INUSNUDO = '" & CStr(Trim(stINUSNUDO)) & "', "
            stConsultaSQL += "INUSFERE = '" & CStr(Trim(stINUSFERE)) & "', "
            stConsultaSQL += "INUSNOMB = '" & CStr(Trim(stINUSNOMB)) & "', "
            stConsultaSQL += "INUSPRAP = '" & CStr(Trim(stINUSPRAP)) & "', "
            stConsultaSQL += "INUSSEAP = '" & CStr(Trim(stINUSSEAP)) & "', "
            stConsultaSQL += "INUSTEL1 = '" & CStr(Trim(stINUSTEL1)) & "', "
            stConsultaSQL += "INUSTEL2 = '" & CStr(Trim(stINUSTEL2)) & "', "
            stConsultaSQL += "INUSDIRE = '" & CStr(Trim(stINUSDIRE)) & "', "
            stConsultaSQL += "INUSOBSE = '" & CStr(Trim(stINUSOBSE)) & "' "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "INUSSECU = '" & CInt(inINUSSECU) & "' "

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
            MessageBox.Show(Err.Description & " " & "fun_Actualizar_INFOUSUA")
        End Try

    End Function

    ''' <summary>
    ''' Consulta para llenar el DataGridView y colocar el nombre del encabezado
    ''' de la columna. 
    ''' </summary>
    Public Function fun_Consultar_INFOUSUA(ByVal inINUSSECU As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "INUSIDRE, "
            stConsultaSQL += "INUSSECU, "
            stConsultaSQL += "INUSNUDO, "
            stConsultaSQL += "INUSFERE, "
            stConsultaSQL += "INUSNOMB, "
            stConsultaSQL += "INUSPRAP, "
            stConsultaSQL += "INUSSEAP, "
            stConsultaSQL += "INUSFERE, "
            stConsultaSQL += "INUSTEL1, "
            stConsultaSQL += "INUSTEL2, "
            stConsultaSQL += "INUSDIRE, "
            stConsultaSQL += "INUSOBSE "

            stConsultaSQL += "FROM "
            stConsultaSQL += "INFOUSUA "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "INUSSECU = '" & CInt(inINUSSECU) & " '"

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "INUSSECU "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl


        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Consultar_INFOUSUA")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que busca el ID del codigo buscado para ejecutar la consulta
    ''' parametrizada.
    ''' </summary>
    Public Function fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_INFOUSUA(ByVal inINUSSECU As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "INUSIDRE, "
            stConsultaSQL += "INUSSECU, "
            stConsultaSQL += "INUSNUDO, "
            stConsultaSQL += "INUSFERE, "
            stConsultaSQL += "INUSNOMB, "
            stConsultaSQL += "INUSPRAP, "
            stConsultaSQL += "INUSSEAP, "
            stConsultaSQL += "INUSFERE, "
            stConsultaSQL += "INUSTEL1, "
            stConsultaSQL += "INUSTEL2, "
            stConsultaSQL += "INUSDIRE, "
            stConsultaSQL += "INUSOBSE "

            stConsultaSQL += "FROM "
            stConsultaSQL += "INFOUSUA "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "INUSSECU = '" & CInt(inINUSSECU) & " '"
           
            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "INUSSECU "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception

            MessageBox.Show(Err.Description & " " & "fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_INFOUSUA")
            Return Nothing

        End Try

    End Function

    ''' <summary>
    ''' Función que busca el CÓDIGO para que no se 
    ''' guarden registros duplicados.
    ''' </summary>
    Public Function fun_Buscar_CODIGO_X_INFOUSUA(ByVal inINUSSECU As Integer, ByVal stINUSNUDO As String) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "INFOUSUA "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "INUSSECU = '" & CInt(inINUSSECU) & "' and "
            stConsultaSQL += "INUSNUDO = '" & CStr(Trim(stINUSNUDO)) & "' "

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
