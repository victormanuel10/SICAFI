Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration
Imports DATOS

Public Class cla_ARCHIVO

    '=====================
    '*** CLASE ARCHIVO ***
    '=====================

    ''' <summary>
    ''' procedimiento que verifica la llave primaria.
    ''' </summary>
    ''' <summary>
    ''' procedimiento que verifica la llave primaria.
    ''' </summary>
    Public Function fun_Verifica_llave_Primaria_ARCHIVO(ByVal inARCHSECU As Integer, ByVal obARCHNUDO As Object) As Boolean

        Try
            Dim boRespuesta As Boolean = False

            Dim obVerifica As New cla_Verificar_Dato

            If obVerifica.fun_Verificar_Campo_Lleno(inARCHSECU) = True And _
                obVerifica.fun_Verificar_Campo_Lleno(obARCHNUDO.Text) = True Then

                If obVerifica.fun_Verificar_Dato_Numerico(inARCHSECU) = True Then

                    Dim objdatos1 As New cla_ARCHIVO
                    Dim tbl As New DataTable

                    tbl = objdatos1.fun_Buscar_CODIGO_X_ARCHIVO(inARCHSECU, obARCHNUDO.Text)

                    If tbl.Rows.Count > 0 Then
                        MessageBox.Show("El dato " & Trim(inARCHSECU) & " - " & Trim(obARCHNUDO.Text) & " existe en la base de datos.", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                        obARCHNUDO.Focus()
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
    Public Function fun_Insertar_ARCHIVO(ByVal inARCHSECU As Integer, _
                                          ByVal stARCHNUDO As String, _
                                          ByVal stARCHFEEN As String, _
                                          ByVal stARCHFERE As String, _
                                          ByVal stARCHOBSE As String) As Boolean

        Try

            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "INSERT INTO "
            stConsultaSQL += "ARCHIVO "

            stConsultaSQL += "( "
            stConsultaSQL += "ARCHSECU, "
            stConsultaSQL += "ARCHNUDO, "
            stConsultaSQL += "ARCHFEEN, "
            stConsultaSQL += "ARCHFERE, "
            stConsultaSQL += "ARCHOBSE "
            stConsultaSQL += ") "

            stConsultaSQL += "VALUES "

            stConsultaSQL += "( "
            stConsultaSQL += "'" & CInt(inARCHSECU) & "', "
            stConsultaSQL += "'" & CStr(Trim(stARCHNUDO)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stARCHFEEN)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stARCHFERE)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stARCHOBSE)) & "' "
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
            MessageBox.Show(Err.Description & " " & "fun_Insertar_ARCHIVO")
        End Try

    End Function

    ''' <summary>
    ''' Función que Elimina el registro.
    ''' </summary>
    Public Function fun_Eliminar_IDRE_ARCHIVO(ByVal inARCHIDRE As Integer) As Boolean

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "DELETE "
            stConsultaSQL += "ARCHIVO "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "ARCHIDRE = '" & CInt(inARCHIDRE) & "' "

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
            MessageBox.Show(Err.Description & " " & "fun_Eliminar_IDRE_ARCHIVO")
        End Try

    End Function

    ''' <summary>
    ''' Función que Elimina el registro.
    ''' </summary>
    Public Function fun_Eliminar_SECU_X_NUDO_ARCHIVO(ByVal inARCHSECU As Integer, ByVal stARCHNUDO As String) As Boolean

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "DELETE "
            stConsultaSQL += "ARCHIVO "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "ARCHSECU = '" & CInt(inARCHSECU) & "' and "
            stConsultaSQL += "ARCHNUDO = '" & CStr(Trim(stARCHNUDO)) & "' "

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
            MessageBox.Show(Err.Description & " " & "fun_Eliminar_SECU_X_MACA_ARCHIVO")
        End Try

    End Function

    ''' <summary>
    ''' Función que Elimina el registro.
    ''' </summary>
    Public Function fun_Eliminar_SECU_ARCHIVO(ByVal inARCHSECU As Integer) As Boolean

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "DELETE "
            stConsultaSQL += "ARCHIVO "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "ARCHSECU = '" & CInt(inARCHSECU) & "' "

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
            MessageBox.Show(Err.Description & " " & "fun_Eliminar_IDRE_ARCHIVO")
        End Try

    End Function

    ''' <summary>
    ''' Función que Modifica el registro.
    ''' </summary>
    Public Function fun_Actualizar_ARCHIVO(ByVal inARCHIDRE As Integer, _
                                            ByVal inARCHSECU As Integer, _
                                            ByVal stARCHNUDO As String, _
                                            ByVal stARCHFEEN As String, _
                                            ByVal stARCHFERE As String, _
                                            ByVal stARCHOBSE As String) As Boolean

        Try

            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "UPDATE "
            stConsultaSQL += "ARCHIVO "

            stConsultaSQL += "SET "
            stConsultaSQL += "ARCHSECU = '" & CInt(inARCHSECU) & "', "
            stConsultaSQL += "ARCHNUDO = '" & CStr(Trim(stARCHNUDO)) & "', "
            stConsultaSQL += "ARCHFEEN = '" & CStr(Trim(stARCHFEEN)) & "', "
            stConsultaSQL += "ARCHFERE = '" & CStr(Trim(stARCHFERE)) & "', "
            stConsultaSQL += "ARCHOBSE = '" & CStr(Trim(stARCHOBSE)) & "' "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "ARCHIDRE = '" & CInt(inARCHIDRE) & "' "

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
            MessageBox.Show(Err.Description & " " & "fun_Actualizar_ARCHIVO")
        End Try

    End Function

    ''' <summary>
    ''' Consulta para llenar el DataGridView y colocar el nombre del encabezado
    ''' de la columna. 
    ''' </summary>
    Public Function fun_Consultar_ARCHIVO() As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "ARCHIDRE, "
            stConsultaSQL += "ARCHSECU, "
            stConsultaSQL += "ARCHNUDO, "
            stConsultaSQL += "USUANOMB, "
            stConsultaSQL += "USUAPRAP, "
            stConsultaSQL += "USUASEAP, "
            stConsultaSQL += "ARCHFEEN, "
            stConsultaSQL += "ARCHFERE, "
            stConsultaSQL += "ARCHOBSE "

            stConsultaSQL += "FROM "
            stConsultaSQL += "ARCHIVO, USUARIO "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "ARCHNUDO = USUANUDO "

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "ARCHFEEN "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Consultar_ARCHIVO")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que busca el ID del codigo buscado para ejecutar la consulta
    ''' parametrizada.
    ''' </summary>
    Public Function fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_ARCHIVO(ByVal inARCHSECU As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "ARCHIDRE, "
            stConsultaSQL += "ARCHSECU, "
            stConsultaSQL += "ARCHNUDO, "
            stConsultaSQL += "USUANOMB, "
            stConsultaSQL += "USUAPRAP, "
            stConsultaSQL += "USUASEAP, "
            stConsultaSQL += "ARCHFEEN, "
            stConsultaSQL += "ARCHFERE, "
            stConsultaSQL += "ARCHOBSE "

            stConsultaSQL += "FROM "
            stConsultaSQL += "ARCHIVO, USUARIO "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "ARCHNUDO = USUANUDO and "
            stConsultaSQL += "ARCHSECU = '" & CInt(inARCHSECU) & "'"

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "ARCHFEEN "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception

            MessageBox.Show(Err.Description & " " & "fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_ARCHIVO")
            Return Nothing

        End Try

    End Function

    ''' <summary>
    ''' Función que busca el CÓDIGO para que no se 
    ''' guarden registros duplicados.
    ''' </summary>
    Public Function fun_Buscar_CODIGO_X_ARCHIVO(ByVal inARCHSECU As Integer, ByVal stARCHNUDO As String) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "ARCHIVO "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "ARCHSECU = '" & CInt(inARCHSECU) & "' and "
            stConsultaSQL += "ARCHNUDO = '" & CStr(Trim(stARCHNUDO)) & "' "

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
    ''' <summary>
    ''' Función que busca el CÓDIGO para que no se 
    ''' guarden registros duplicados.
    ''' </summary>
    Public Function fun_Buscar_CODIGO_X_ARCHIVO(ByVal inARCHIDRE As Integer, ByVal inARCHSECU As Integer, ByVal stARCHNUDO As String) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "ARCHIVO "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "ARCHIDRE = '" & CInt(inARCHIDRE) & "' and "
            stConsultaSQL += "ARCHSECU = '" & CInt(inARCHSECU) & "' and "
            stConsultaSQL += "ARCHNUDO = '" & CStr(Trim(stARCHNUDO)) & "' "

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
