Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration
Imports DATOS

Public Class cla_RELIMAFA

    '===============================
    '*** CLASE MATERIAL FALTANTE ***
    '===============================

    ''' <summary>
    ''' procedimiento que verifica la llave primaria.
    ''' </summary>
    Public Function fun_Verifica_llave_Primaria_RELIMAFA(ByVal obRLMFSECU As Object, ByVal obRLMFMACA As Object) As Boolean

        Try
            Dim boRespuesta As Boolean = False

            Dim obVerifica As New cla_Verificar_Dato

            If obVerifica.fun_Verificar_Campo_Lleno(obRLMFSECU.Text) = True And _
                obVerifica.fun_Verificar_Campo_Lleno(obRLMFMACA.Text) = True Then

                If obVerifica.fun_Verificar_Dato_Numerico(obRLMFSECU.Text) = True And _
                   obVerifica.fun_Verificar_Dato_Numerico(obRLMFMACA.Text) = True Then

                    Dim objdatos1 As New cla_RELIMAFA
                    Dim tbl As New DataTable

                    tbl = objdatos1.fun_Buscar_CODIGO_X_RELIMAFA(obRLMFSECU.Text, obRLMFMACA.Text)

                    If tbl.Rows.Count > 0 Then
                        MessageBox.Show("El dato " & Trim(obRLMFSECU.Text) & " - " & Trim(obRLMFMACA.Text) & " existe en la base de datos, se incRLMFntara una secuencia, favor guardar.", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                        obRLMFSECU.Focus()
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
    Public Function fun_Insertar_RELIMAFA(ByVal inRLMFSECU As Integer, _
                                          ByVal inRLMFNURA As Integer, _
                                          ByVal stRLMFFERA As String, _
                                          ByVal inRLMFMACA As Integer, _
                                          ByVal stRLMFFECH As String, _
                                          ByVal stRLMFOBSE As String) As Boolean

        Try

            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "INSERT INTO "
            stConsultaSQL += "RELIMAFA "

            stConsultaSQL += "( "
            stConsultaSQL += "RLMFSECU, "
            stConsultaSQL += "RLMFNURA, "
            stConsultaSQL += "RLMFFERA, "
            stConsultaSQL += "RLMFMACA, "
            stConsultaSQL += "RLMFFECH, "
            stConsultaSQL += "RLMFOBSE "
            stConsultaSQL += ") "

            stConsultaSQL += "VALUES "

            stConsultaSQL += "( "
            stConsultaSQL += "'" & CInt(inRLMFSECU) & "', "
            stConsultaSQL += "'" & CInt(inRLMFNURA) & "', "
            stConsultaSQL += "'" & CStr(Trim(stRLMFFERA)) & "', "
            stConsultaSQL += "'" & CInt(inRLMFMACA) & "', "
            stConsultaSQL += "'" & CStr(Trim(stRLMFFECH)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stRLMFOBSE)) & "' "
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
            MessageBox.Show(Err.Description & " " & "fun_Insertar_RELIMAFA")
        End Try

    End Function

    ''' <summary>
    ''' Función que Elimina el registro.
    ''' </summary>
    Public Function fun_Eliminar_IDRE_RELIMAFA(ByVal inRLMFIDRE As Integer) As Boolean

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "DELETE "
            stConsultaSQL += "RELIMAFA "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "RLMFIDRE = '" & CInt(inRLMFIDRE) & "' "

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
            MessageBox.Show(Err.Description & " " & "fun_Eliminar_IDRE_RELIMAFA")
        End Try

    End Function

    ''' <summary>
    ''' Función que Elimina el registro.
    ''' </summary>
    Public Function fun_Eliminar_SECU_X_MACA_RELIMAFA(ByVal inRLMFSECU As Integer, ByVal inRLMFMACA As Integer) As Boolean

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "DELETE "
            stConsultaSQL += "RELIMAFA "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "RLMFSECU = '" & CInt(inRLMFSECU) & "' and "
            stConsultaSQL += "RLMFMACA = '" & CInt(inRLMFMACA) & "' "

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
            MessageBox.Show(Err.Description & " " & "fun_Eliminar_SECU_X_MACA_RELIMAFA")
        End Try

    End Function

    ''' <summary>
    ''' Función que Elimina el registro.
    ''' </summary>
    Public Function fun_Eliminar_SECU_RELIMAFA(ByVal inRLMFSECU As Integer) As Boolean

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "DELETE "
            stConsultaSQL += "RELIMAFA "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "RLMFSECU = '" & CInt(inRLMFSECU) & "' "

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
            MessageBox.Show(Err.Description & " " & "fun_Eliminar_IDRE_RELIMAFA")
        End Try

    End Function

    ''' <summary>
    ''' Función que Modifica el registro.
    ''' </summary>
    Public Function fun_Actualizar_RELIMAFA(ByVal inRLMFIDRE As Integer, _
                                            ByVal inRLMFSECU As Integer, _
                                            ByVal inRLMFMACA As Integer, _
                                            ByVal stRLMFFECH As String, _
                                            ByVal stRLMFOBSE As String) As Boolean

        Try

            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "UPDATE "
            stConsultaSQL += "RELIMAFA "

            stConsultaSQL += "SET "
            stConsultaSQL += "RLMFSECU = '" & CInt(inRLMFSECU) & "', "
            stConsultaSQL += "RLMFMACA = '" & CInt(inRLMFMACA) & "', "
            stConsultaSQL += "RLMFFECH = '" & CStr(Trim(stRLMFFECH)) & "', "
            stConsultaSQL += "RLMFOBSE = '" & CStr(Trim(inRLMFIDRE)) & "' "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "RLMFIDRE = '" & CInt(inRLMFIDRE) & "' "

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
            MessageBox.Show(Err.Description & " " & "fun_Actualizar_RELIMAFA")
        End Try

    End Function

    ''' <summary>
    ''' Consulta para llenar el DataGridView y colocar el nombre del encabezado
    ''' de la columna. 
    ''' </summary>
    Public Function fun_Consultar_RELIMAFA() As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "RLMFIDRE, "
            stConsultaSQL += "RLMFSECU, "
            stConsultaSQL += "RLMFMACA, "
            stConsultaSQL += "MACADESC, "
            stConsultaSQL += "RLMFFECH, "
            stConsultaSQL += "RLMFOBSE "

            stConsultaSQL += "FROM "
            stConsultaSQL += "RELIMAFA, MANT_MATECAMP "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "MACACODI = RLMFMACA "

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "RLMFMACA "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Consultar_RELIMAFA")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que busca el ID del codigo buscado para ejecutar la consulta
    ''' parametrizada.
    ''' </summary>
    Public Function fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_RELIMAFA(ByVal inRLMFSECU As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "RLMFIDRE, "
            stConsultaSQL += "RLMFSECU, "
            stConsultaSQL += "RLMFMACA, "
            stConsultaSQL += "MACADESC, "
            stConsultaSQL += "RLMFFECH, "
            stConsultaSQL += "RLMFOBSE "

            stConsultaSQL += "FROM "
            stConsultaSQL += "RELIMAFA, MANT_MATECAMP "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "MACACODI = RLMFMACA and "
            stConsultaSQL += "RLMFSECU = '" & CInt(inRLMFSECU) & "'"

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "RLMFMACA "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception

            MessageBox.Show(Err.Description & " " & "fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_RELIMAFA")
            Return Nothing

        End Try

    End Function

    ''' <summary>
    ''' Función que busca el CÓDIGO para que no se 
    ''' guarden registros duplicados.
    ''' </summary>
    Public Function fun_Buscar_CODIGO_X_RELIMAFA(ByVal inRLMFSECU As Integer, ByVal inRLMFMACA As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "RELIMAFA "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "RLMFSECU = '" & CInt(inRLMFSECU) & "' and "
            stConsultaSQL += "RLMFMACA = '" & CInt(inRLMFMACA) & "' "

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
