Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration
Imports DATOS

Public Class cla_RECLMAFA

    '===============================
    '*** CLASE MATERIAL FALTANTE ***
    '===============================

    ''' <summary>
    ''' procedimiento que verifica la llave primaria.
    ''' </summary>
    Public Function fun_Verifica_llave_Primaria_RECLMAFA(ByVal obREMFSECU As Object, ByVal obREMFMACA As Object) As Boolean

        Try
            Dim boRespuesta As Boolean = False

            Dim obVerifica As New cla_Verificar_Dato

            If obVerifica.fun_Verificar_Campo_Lleno(obREMFSECU.Text) = True And _
                obVerifica.fun_Verificar_Campo_Lleno(obREMFMACA.Text) = True Then

                If obVerifica.fun_Verificar_Dato_Numerico(obREMFSECU.Text) = True And _
                   obVerifica.fun_Verificar_Dato_Numerico(obREMFMACA.Text) = True Then

                    Dim objdatos1 As New cla_RECLMAFA
                    Dim tbl As New DataTable

                    tbl = objdatos1.fun_Buscar_CODIGO_X_RECLMAFA(obREMFSECU.Text, obREMFMACA.Text)

                    If tbl.Rows.Count > 0 Then
                        MessageBox.Show("El dato " & Trim(obREMFSECU.Text) & " - " & Trim(obREMFMACA.Text) & " existe en la base de datos, se incREMFntara una secuencia, favor guardar.", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                        obREMFSECU.Focus()
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
    Public Function fun_Insertar_RECLMAFA(ByVal inREMFSECU As Integer, _
                                          ByVal inREMFMACA As Integer, _
                                          ByVal stREMFFECH As String, _
                                          ByVal stREMFOBSE As String) As Boolean

        Try

            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "INSERT INTO "
            stConsultaSQL += "RECLMAFA "

            stConsultaSQL += "( "
            stConsultaSQL += "REMFSECU, "
            stConsultaSQL += "REMFMACA, "
            stConsultaSQL += "REMFFECH, "
            stConsultaSQL += "REMFOBSE "
            stConsultaSQL += ") "

            stConsultaSQL += "VALUES "

            stConsultaSQL += "( "
            stConsultaSQL += "'" & CInt(inREMFSECU) & "', "
            stConsultaSQL += "'" & CInt(inREMFMACA) & "', "
            stConsultaSQL += "'" & CStr(Trim(stREMFFECH)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stREMFOBSE)) & "' "
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
            MessageBox.Show(Err.Description & " " & "fun_Insertar_RECLMAFA")
        End Try

    End Function

    ''' <summary>
    ''' Función que Elimina el registro.
    ''' </summary>
    Public Function fun_Eliminar_IDRE_RECLMAFA(ByVal inREMFIDRE As Integer) As Boolean

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "DELETE "
            stConsultaSQL += "RECLMAFA "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "REMFIDRE = '" & CInt(inREMFIDRE) & "' "

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
            MessageBox.Show(Err.Description & " " & "fun_Eliminar_IDRE_RECLMAFA")
        End Try

    End Function

    ''' <summary>
    ''' Función que Elimina el registro.
    ''' </summary>
    Public Function fun_Eliminar_SECU_X_MACA_RECLMAFA(ByVal inREMFSECU As Integer, ByVal inREMFMACA As Integer) As Boolean

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "DELETE "
            stConsultaSQL += "RECLMAFA "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "REMFSECU = '" & CInt(inREMFSECU) & "' and "
            stConsultaSQL += "REMFMACA = '" & CInt(inREMFMACA) & "' "

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
            MessageBox.Show(Err.Description & " " & "fun_Eliminar_SECU_X_MACA_RECLMAFA")
        End Try

    End Function

    ''' <summary>
    ''' Función que Elimina el registro.
    ''' </summary>
    Public Function fun_Eliminar_SECU_RECLMAFA(ByVal inREMFSECU As Integer) As Boolean

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "DELETE "
            stConsultaSQL += "RECLMAFA "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "REMFSECU = '" & CInt(inREMFSECU) & "' "

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
            MessageBox.Show(Err.Description & " " & "fun_Eliminar_IDRE_RECLMAFA")
        End Try

    End Function

    ''' <summary>
    ''' Función que Modifica el registro.
    ''' </summary>
    Public Function fun_Actualizar_RECLMAFA(ByVal inREMFIDRE As Integer, _
                                            ByVal inREMFSECU As Integer, _
                                            ByVal inREMFMACA As Integer, _
                                            ByVal stREMFFECH As String, _
                                            ByVal stREMFOBSE As String) As Boolean

        Try

            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "UPDATE "
            stConsultaSQL += "RECLMAFA "

            stConsultaSQL += "SET "
            stConsultaSQL += "REMFSECU = '" & CInt(inREMFSECU) & "', "
            stConsultaSQL += "REMFMACA = '" & CInt(inREMFMACA) & "', "
            stConsultaSQL += "REMFFECH = '" & CStr(Trim(stREMFFECH)) & "', "
            stConsultaSQL += "REMFOBSE = '" & CStr(Trim(inREMFIDRE)) & "' "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "REMFIDRE = '" & CInt(inREMFIDRE) & "' "

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
            MessageBox.Show(Err.Description & " " & "fun_Actualizar_RECLMAFA")
        End Try

    End Function

    ''' <summary>
    ''' Consulta para llenar el DataGridView y colocar el nombre del encabezado
    ''' de la columna. 
    ''' </summary>
    Public Function fun_Consultar_RECLMAFA() As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "REMFIDRE, "
            stConsultaSQL += "REMFSECU, "
            stConsultaSQL += "REMFMACA, "
            stConsultaSQL += "MACADESC, "
            stConsultaSQL += "REMFFECH, "
            stConsultaSQL += "REMFOBSE "

            stConsultaSQL += "FROM "
            stConsultaSQL += "RECLMAFA, MANT_MATECAMP "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "MACACODI = REMFMACA "

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "REMFMACA "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Consultar_RECLMAFA")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que busca el ID del codigo buscado para ejecutar la consulta
    ''' parametrizada.
    ''' </summary>
    Public Function fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_RECLMAFA(ByVal inREMFSECU As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "REMFIDRE, "
            stConsultaSQL += "REMFSECU, "
            stConsultaSQL += "REMFMACA, "
            stConsultaSQL += "MACADESC, "
            stConsultaSQL += "REMFFECH, "
            stConsultaSQL += "REMFOBSE "

            stConsultaSQL += "FROM "
            stConsultaSQL += "RECLMAFA, MANT_MATECAMP "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "MACACODI = REMFMACA and "
            stConsultaSQL += "REMFSECU = '" & CInt(inREMFSECU) & "'"

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "REMFMACA "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception

            MessageBox.Show(Err.Description & " " & "fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_RECLMAFA")
            Return Nothing

        End Try

    End Function

    ''' <summary>
    ''' Función que busca el CÓDIGO para que no se 
    ''' guarden registros duplicados.
    ''' </summary>
    Public Function fun_Buscar_CODIGO_X_RECLMAFA(ByVal inREMFSECU As Integer, ByVal inREMFMACA As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "RECLMAFA "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "REMFSECU = '" & CInt(inREMFSECU) & "' and "
            stConsultaSQL += "REMFMACA = '" & CInt(inREMFMACA) & "' "

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
