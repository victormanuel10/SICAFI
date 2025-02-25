Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration
Imports DATOS

Public Class cla_REAVMAFA

    '==================================================
    '*** CLASE MATERIAL FALTANTE REVISION DE AVALUO ***
    '==================================================

    ''' <summary>
    ''' procedimiento que verifica la llave primaria.
    ''' </summary>
    Public Function fun_Verifica_llave_Primaria_REAVMAFA(ByVal obRAMFSECU As Object, ByVal obRAMFMACA As Object) As Boolean

        Try
            Dim boRespuesta As Boolean = False

            Dim obVerifica As New cla_Verificar_Dato

            If obVerifica.fun_Verificar_Campo_Lleno(obRAMFSECU.Text) = True And _
                obVerifica.fun_Verificar_Campo_Lleno(obRAMFMACA.Text) = True Then

                If obVerifica.fun_Verificar_Dato_Numerico(obRAMFSECU.Text) = True And _
                   obVerifica.fun_Verificar_Dato_Numerico(obRAMFMACA.Text) = True Then

                    Dim objdatos1 As New cla_REAVMAFA
                    Dim tbl As New DataTable

                    tbl = objdatos1.fun_Buscar_CODIGO_X_REAVMAFA(obRAMFSECU.Text, obRAMFMACA.Text)

                    If tbl.Rows.Count > 0 Then
                        MessageBox.Show("El dato " & Trim(obRAMFSECU.Text) & " - " & Trim(obRAMFMACA.Text) & " existe en la base de datos, se incRAMFntara una secuencia, favor guardar.", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                        obRAMFSECU.Focus()
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
    Public Function fun_Insertar_REAVMAFA(ByVal inRAMFSECU As Integer, _
                                          ByVal inRAMFMACA As Integer, _
                                          ByVal stRAMFFECH As String, _
                                          ByVal stRAMFOBSE As String) As Boolean

        Try

            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "INSERT INTO "
            stConsultaSQL += "REAVMAFA "

            stConsultaSQL += "( "
            stConsultaSQL += "RAMFSECU, "
            stConsultaSQL += "RAMFMACA, "
            stConsultaSQL += "RAMFFECH, "
            stConsultaSQL += "RAMFOBSE "
            stConsultaSQL += ") "

            stConsultaSQL += "VALUES "

            stConsultaSQL += "( "
            stConsultaSQL += "'" & CInt(inRAMFSECU) & "', "
            stConsultaSQL += "'" & CInt(inRAMFMACA) & "', "
            stConsultaSQL += "'" & CStr(Trim(stRAMFFECH)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stRAMFOBSE)) & "' "
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
            MessageBox.Show(Err.Description & " " & "fun_Insertar_REAVMAFA")
        End Try

    End Function

    ''' <summary>
    ''' Función que Elimina el registro.
    ''' </summary>
    Public Function fun_Eliminar_IDRE_REAVMAFA(ByVal inRAMFIDRE As Integer) As Boolean

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "DELETE "
            stConsultaSQL += "REAVMAFA "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "RAMFIDRE = '" & CInt(inRAMFIDRE) & "' "

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
            MessageBox.Show(Err.Description & " " & "fun_Eliminar_IDRE_REAVMAFA")
        End Try

    End Function

    ''' <summary>
    ''' Función que Elimina el registro.
    ''' </summary>
    Public Function fun_Eliminar_SECU_X_MACA_REAVMAFA(ByVal inRAMFSECU As Integer, ByVal inRAMFMACA As Integer) As Boolean

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "DELETE "
            stConsultaSQL += "REAVMAFA "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "RAMFSECU = '" & CInt(inRAMFSECU) & "' and "
            stConsultaSQL += "RAMFMACA = '" & CInt(inRAMFMACA) & "' "

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
            MessageBox.Show(Err.Description & " " & "fun_Eliminar_SECU_X_MACA_REAVMAFA")
        End Try

    End Function

    ''' <summary>
    ''' Función que Elimina el registro.
    ''' </summary>
    Public Function fun_Eliminar_SECU_REAVMAFA(ByVal inRAMFSECU As Integer) As Boolean

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "DELETE "
            stConsultaSQL += "REAVMAFA "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "RAMFSECU = '" & CInt(inRAMFSECU) & "' "

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
            MessageBox.Show(Err.Description & " " & "fun_Eliminar_IDRE_REAVMAFA")
        End Try

    End Function

    ''' <summary>
    ''' Función que Modifica el registro.
    ''' </summary>
    Public Function fun_Actualizar_REAVMAFA(ByVal inRAMFIDRE As Integer, _
                                            ByVal inRAMFSECU As Integer, _
                                            ByVal inRAMFMACA As Integer, _
                                            ByVal stRAMFFECH As String, _
                                            ByVal stRAMFOBSE As String) As Boolean

        Try

            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "UPDATE "
            stConsultaSQL += "REAVMAFA "

            stConsultaSQL += "SET "
            stConsultaSQL += "RAMFSECU = '" & CInt(inRAMFSECU) & "', "
            stConsultaSQL += "RAMFMACA = '" & CInt(inRAMFMACA) & "', "
            stConsultaSQL += "RAMFFECH = '" & CStr(Trim(stRAMFFECH)) & "', "
            stConsultaSQL += "RAMFOBSE = '" & CStr(Trim(inRAMFIDRE)) & "' "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "RAMFIDRE = '" & CInt(inRAMFIDRE) & "' "

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
            MessageBox.Show(Err.Description & " " & "fun_Actualizar_REAVMAFA")
        End Try

    End Function

    ''' <summary>
    ''' Consulta para llenar el DataGridView y colocar el nombre del encabezado
    ''' de la columna. 
    ''' </summary>
    Public Function fun_Consultar_REAVMAFA() As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "RAMFIDRE, "
            stConsultaSQL += "RAMFSECU, "
            stConsultaSQL += "RAMFMACA, "
            stConsultaSQL += "MACADESC, "
            stConsultaSQL += "RAMFFECH, "
            stConsultaSQL += "RAMFOBSE "

            stConsultaSQL += "FROM "
            stConsultaSQL += "REAVMAFA, MANT_MATECAMP "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "MACACODI = RAMFMACA "

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "RAMFMACA "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Consultar_REAVMAFA")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que busca el ID del codigo buscado para ejecutar la consulta
    ''' parametrizada.
    ''' </summary>
    Public Function fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_REAVMAFA(ByVal inRAMFSECU As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "RAMFIDRE, "
            stConsultaSQL += "RAMFSECU, "
            stConsultaSQL += "RAMFMACA, "
            stConsultaSQL += "MACADESC, "
            stConsultaSQL += "RAMFFECH, "
            stConsultaSQL += "RAMFOBSE "

            stConsultaSQL += "FROM "
            stConsultaSQL += "REAVMAFA, MANT_MATECAMP "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "MACACODI = RAMFMACA and "
            stConsultaSQL += "RAMFSECU = '" & CInt(inRAMFSECU) & "'"

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "RAMFMACA "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception

            MessageBox.Show(Err.Description & " " & "fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_REAVMAFA")
            Return Nothing

        End Try

    End Function

    ''' <summary>
    ''' Función que busca el CÓDIGO para que no se 
    ''' guarden registros duplicados.
    ''' </summary>
    Public Function fun_Buscar_CODIGO_X_REAVMAFA(ByVal inRAMFSECU As Integer, ByVal inRAMFMACA As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "REAVMAFA "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "RAMFSECU = '" & CInt(inRAMFSECU) & "' and "
            stConsultaSQL += "RAMFMACA = '" & CInt(inRAMFMACA) & "' "

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
