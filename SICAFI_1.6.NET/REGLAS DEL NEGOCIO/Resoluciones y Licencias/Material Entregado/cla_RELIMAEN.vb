Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration
Imports DATOS

Public Class cla_RELIMAEN

    '================================
    '*** CLASE MATERIAL ENTREGADO ***
    '================================

    ''' <summary>
    ''' procedimiento que verifica la llave primaria.
    ''' </summary>
    Public Function fun_Verifica_llave_Primaria_RELIMAEN(ByVal obRLMESECU As Object, ByVal obRLMEMACA As Object) As Boolean

        Try
            Dim boRespuesta As Boolean = False

            Dim obVerifica As New cla_Verificar_Dato

            If obVerifica.fun_Verificar_Campo_Lleno(obRLMESECU.Text) = True And _
                obVerifica.fun_Verificar_Campo_Lleno(obRLMEMACA.Text) = True Then

                If obVerifica.fun_Verificar_Dato_Numerico(obRLMESECU.Text) = True And _
                   obVerifica.fun_Verificar_Dato_Numerico(obRLMEMACA.Text) = True Then

                    Dim objdatos1 As New cla_RELIMAEN
                    Dim tbl As New DataTable

                    tbl = objdatos1.fun_Buscar_CODIGO_X_RELIMAEN(obRLMESECU.Text, obRLMEMACA.Text)

                    If tbl.Rows.Count > 0 Then
                        MessageBox.Show("El dato " & Trim(obRLMESECU.Text) & " - " & Trim(obRLMEMACA.Text) & " existe en la base de datos, se incRLMEntara una secuencia, favor guardar.", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                        obRLMESECU.Focus()
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
    Public Function fun_Insertar_RELIMAEN(ByVal inRLMESECU As Integer, _
                                          ByVal inRLMENURA As Integer, _
                                          ByVal stRLMEFERA As String, _
                                          ByVal inRLMEMACA As Integer, _
                                          ByVal stRLMEFECH As String, _
                                          ByVal stRLMEOBSE As String) As Boolean

        Try

            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "INSERT INTO "
            stConsultaSQL += "RELIMAEN "

            stConsultaSQL += "( "
            stConsultaSQL += "RLMESECU, "
            stConsultaSQL += "RLMENURA, "
            stConsultaSQL += "RLMEFERA, "
            stConsultaSQL += "RLMEMACA, "
            stConsultaSQL += "RLMEFECH, "
            stConsultaSQL += "RLMEOBSE "
            stConsultaSQL += ") "

            stConsultaSQL += "VALUES "

            stConsultaSQL += "( "
            stConsultaSQL += "'" & CInt(inRLMESECU) & "', "
            stConsultaSQL += "'" & CInt(inRLMENURA) & "', "
            stConsultaSQL += "'" & CStr(Trim(stRLMEFERA)) & "', "
            stConsultaSQL += "'" & CInt(inRLMEMACA) & "', "
            stConsultaSQL += "'" & CStr(Trim(stRLMEFECH)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stRLMEOBSE)) & "' "
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
            MessageBox.Show(Err.Description & " " & "fun_Insertar_RELIMAEN")
        End Try

    End Function

    ''' <summary>
    ''' Función que Elimina el registro.
    ''' </summary>
    Public Function fun_Eliminar_IDRE_RELIMAEN(ByVal inRLMEIDRE As Integer) As Boolean

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "DELETE "
            stConsultaSQL += "RELIMAEN "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "RLMEIDRE = '" & CInt(inRLMEIDRE) & "' "

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
            MessageBox.Show(Err.Description & " " & "fun_Eliminar_IDRE_RELIMAEN")
        End Try

    End Function

    ''' <summary>
    ''' Función que Elimina el registro.
    ''' </summary>
    Public Function fun_Eliminar_SECU_X_MACA_RELIMAEN(ByVal inRLMESECU As Integer, ByVal inRLMEMACA As Integer) As Boolean

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "DELETE "
            stConsultaSQL += "RELIMAEN "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "RLMESECU = '" & CInt(inRLMESECU) & "' and "
            stConsultaSQL += "RLMEMACA = '" & CInt(inRLMEMACA) & "' "

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
            MessageBox.Show(Err.Description & " " & "fun_Eliminar_SECU_X_MACA_RELIMAEN")
        End Try

    End Function

    ''' <summary>
    ''' Función que Elimina el registro.
    ''' </summary>
    Public Function fun_Eliminar_SECU_RELIMAEN(ByVal inRLMESECU As Integer) As Boolean

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "DELETE "
            stConsultaSQL += "RELIMAEN "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "RLMESECU = '" & CInt(inRLMESECU) & "' "

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
            MessageBox.Show(Err.Description & " " & "fun_Eliminar_IDRE_RELIMAEN")
        End Try

    End Function

    ''' <summary>
    ''' Función que Modifica el registro.
    ''' </summary>
    Public Function fun_Actualizar_RELIMAEN(ByVal inRLMEIDRE As Integer, _
                                            ByVal inRLMESECU As Integer, _
                                            ByVal inRLMEMACA As Integer, _
                                            ByVal stRLMEFECH As String, _
                                            ByVal stRLMEOBSE As String) As Boolean

        Try

            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "UPDATE "
            stConsultaSQL += "RELIMAEN "

            stConsultaSQL += "SET "
            stConsultaSQL += "RLMESECU = '" & CInt(inRLMESECU) & "', "
            stConsultaSQL += "RLMEMACA = '" & CInt(inRLMEMACA) & "', "
            stConsultaSQL += "RLMEFECH = '" & CStr(Trim(stRLMEFECH)) & "', "
            stConsultaSQL += "RLMEOBSE = '" & CStr(Trim(inRLMEIDRE)) & "' "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "RLMEIDRE = '" & CInt(inRLMEIDRE) & "' "

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
            MessageBox.Show(Err.Description & " " & "fun_Actualizar_RELIMAEN")
        End Try

    End Function

    ''' <summary>
    ''' Consulta para llenar el DataGridView y colocar el nombre del encabezado
    ''' de la columna. 
    ''' </summary>
    Public Function fun_Consultar_RELIMAEN() As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "RLMEIDRE, "
            stConsultaSQL += "RLMESECU, "
            stConsultaSQL += "RLMEMACA, "
            stConsultaSQL += "MACADESC, "
            stConsultaSQL += "RLMEFECH, "
            stConsultaSQL += "RLMEOBSE "

            stConsultaSQL += "FROM "
            stConsultaSQL += "RELIMAEN, MANT_MATECAMP "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "MACACODI = RLMEMACA "

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "RLMEMACA "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Consultar_RELIMAEN")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que busca el ID del codigo buscado para ejecutar la consulta
    ''' parametrizada.
    ''' </summary>
    Public Function fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_RELIMAEN(ByVal inRLMESECU As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "RLMEIDRE, "
            stConsultaSQL += "RLMESECU, "
            stConsultaSQL += "RLMEMACA, "
            stConsultaSQL += "MACADESC, "
            stConsultaSQL += "RLMEFECH, "
            stConsultaSQL += "RLMEOBSE "

            stConsultaSQL += "FROM "
            stConsultaSQL += "RELIMAEN, MANT_MATECAMP "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "MACACODI = RLMEMACA and "
            stConsultaSQL += "RLMESECU = '" & CInt(inRLMESECU) & "'"

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "RLMEMACA "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception

            MessageBox.Show(Err.Description & " " & "fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_RELIMAEN")
            Return Nothing

        End Try

    End Function

    ''' <summary>
    ''' Función que busca el CÓDIGO para que no se 
    ''' guarden registros duplicados.
    ''' </summary>
    Public Function fun_Buscar_CODIGO_X_RELIMAEN(ByVal inRLMESECU As Integer, ByVal inRLMEMACA As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "RELIMAEN "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "RLMESECU = '" & CInt(inRLMESECU) & "' and "
            stConsultaSQL += "RLMEMACA = '" & CInt(inRLMEMACA) & "' "

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
