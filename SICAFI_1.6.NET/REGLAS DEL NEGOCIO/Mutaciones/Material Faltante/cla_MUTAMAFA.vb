Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration
Imports DATOS

Public Class cla_MUTAMAFA

    '==========================================
    '*** CLASE MATERIAL FALTANTE MUTACIONES ***
    '==========================================

    ''' <summary>
    ''' procedimiento que verifica la llave primaria.
    ''' </summary>
    Public Function fun_Verifica_llave_Primaria_MUTAMAFA(ByVal obMUMFSECU As Object, ByVal obMUMFMACA As Object) As Boolean

        Try
            Dim boRespuesta As Boolean = False

            Dim obVerifica As New cla_Verificar_Dato

            If obVerifica.fun_Verificar_Campo_Lleno(obMUMFSECU.Text) = True And _
                obVerifica.fun_Verificar_Campo_Lleno(obMUMFMACA.Text) = True Then

                If obVerifica.fun_Verificar_Dato_Numerico(obMUMFSECU.Text) = True And _
                   obVerifica.fun_Verificar_Dato_Numerico(obMUMFMACA.Text) = True Then

                    Dim objdatos1 As New cla_MUTAMAFA
                    Dim tbl As New DataTable

                    tbl = objdatos1.fun_Buscar_CODIGO_X_MUTAMAFA(obMUMFSECU.Text, obMUMFMACA.Text)

                    If tbl.Rows.Count > 0 Then
                        MessageBox.Show("El dato " & Trim(obMUMFSECU.Text) & " - " & Trim(obMUMFMACA.Text) & " existe en la base de datos, se incrementara una secuencia, favor guardar.", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                        obMUMFSECU.Focus()
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
    Public Function fun_Insertar_MUTAMAFA(ByVal inMUMFSECU As Integer, _
                                          ByVal inMUMFMACA As Integer, _
                                          ByVal stMUMFFECH As String, _
                                          ByVal stMUMFOBSE As String) As Boolean

        Try

            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "INSERT INTO "
            stConsultaSQL += "MUTAMAFA "

            stConsultaSQL += "( "
            stConsultaSQL += "MUMFSECU, "
            stConsultaSQL += "MUMFMACA, "
            stConsultaSQL += "MUMFFECH, "
            stConsultaSQL += "MUMFOBSE "
            stConsultaSQL += ") "

            stConsultaSQL += "VALUES "

            stConsultaSQL += "( "
            stConsultaSQL += "'" & CInt(inMUMFSECU) & "', "
            stConsultaSQL += "'" & CInt(inMUMFMACA) & "', "
            stConsultaSQL += "'" & CStr(Trim(stMUMFFECH)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stMUMFOBSE)) & "' "
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
            MessageBox.Show(Err.Description & " " & "fun_Insertar_MUTAMAFA")
        End Try

    End Function

    ''' <summary>
    ''' Función que Elimina el registro.
    ''' </summary>
    Public Function fun_Eliminar_IDRE_MUTAMAFA(ByVal inMUMFIDRE As Integer) As Boolean

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "DELETE "
            stConsultaSQL += "MUTAMAFA "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "MUMFIDRE = '" & CInt(inMUMFIDRE) & "' "

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
            MessageBox.Show(Err.Description & " " & "fun_Eliminar_IDRE_MUTAMAFA")
        End Try

    End Function

    ''' <summary>
    ''' Función que Elimina el registro.
    ''' </summary>
    Public Function fun_Eliminar_SECU_X_MACA_MUTAMAFA(ByVal inMUMFSECU As Integer, ByVal inMUMFMACA As Integer) As Boolean

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "DELETE "
            stConsultaSQL += "MUTAMAFA "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "MUMFSECU = '" & CInt(inMUMFSECU) & "' and "
            stConsultaSQL += "MUMFMACA = '" & CInt(inMUMFMACA) & "' "

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
            MessageBox.Show(Err.Description & " " & "fun_Eliminar_SECU_X_MACA_MUTAMAFA")
        End Try

    End Function

    ''' <summary>
    ''' Función que Elimina el registro.
    ''' </summary>
    Public Function fun_Eliminar_SECU_MUTAMAFA(ByVal inMUMFSECU As Integer) As Boolean

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "DELETE "
            stConsultaSQL += "MUTAMAFA "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "MUMFSECU = '" & CInt(inMUMFSECU) & "' "

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
            MessageBox.Show(Err.Description & " " & "fun_Eliminar_IDRE_MUTAMAFA")
        End Try

    End Function

    ''' <summary>
    ''' Función que Modifica el registro.
    ''' </summary>
    Public Function fun_Actualizar_MUTAMAFA(ByVal inMUMFIDRE As Integer, _
                                            ByVal inMUMFSECU As Integer, _
                                            ByVal inMUMFMACA As Integer, _
                                            ByVal stMUMFFECH As String, _
                                            ByVal stMUMFOBSE As String) As Boolean

        Try

            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "UPDATE "
            stConsultaSQL += "MUTAMAFA "

            stConsultaSQL += "SET "
            stConsultaSQL += "MUMFSECU = '" & CInt(inMUMFSECU) & "', "
            stConsultaSQL += "MUMFMACA = '" & CInt(inMUMFMACA) & "', "
            stConsultaSQL += "MUMFFECH = '" & CStr(Trim(stMUMFFECH)) & "', "
            stConsultaSQL += "MUMFOBSE = '" & CStr(Trim(inMUMFIDRE)) & "' "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "MUMFIDRE = '" & CInt(inMUMFIDRE) & "' "

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
            MessageBox.Show(Err.Description & " " & "fun_Actualizar_MUTAMAFA")
        End Try

    End Function

    ''' <summary>
    ''' Consulta para llenar el DataGridView y colocar el nombre del encabezado
    ''' de la columna. 
    ''' </summary>
    Public Function fun_Consultar_MUTAMAFA() As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "MUMFIDRE, "
            stConsultaSQL += "MUMFSECU, "
            stConsultaSQL += "MUMFMACA, "
            stConsultaSQL += "MACADESC, "
            stConsultaSQL += "MUMFFECH, "
            stConsultaSQL += "MUMFOBSE "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MUTAMAFA, MANT_MATECAMP "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "MACACODI = MUMFMACA "

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "MUMFMACA "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Consultar_MUTAMAFA")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que busca el ID del codigo buscado para ejecutar la consulta
    ''' parametrizada.
    ''' </summary>
    Public Function fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_MUTAMAFA(ByVal inMUMFSECU As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "MUMFIDRE, "
            stConsultaSQL += "MUMFSECU, "
            stConsultaSQL += "MUMFMACA, "
            stConsultaSQL += "MACADESC, "
            stConsultaSQL += "MUMFFECH, "
            stConsultaSQL += "MUMFOBSE "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MUTAMAFA, MANT_MATECAMP "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "MACACODI = MUMFMACA and "
            stConsultaSQL += "MUMFSECU = '" & CInt(inMUMFSECU) & "'"

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "MUMFMACA "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception

            MessageBox.Show(Err.Description & " " & "fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_MUTAMAFA")
            Return Nothing

        End Try

    End Function

    ''' <summary>
    ''' Función que busca el CÓDIGO para que no se 
    ''' guarden registros duplicados.
    ''' </summary>
    Public Function fun_Buscar_CODIGO_X_MUTAMAFA(ByVal inMUMFSECU As Integer, ByVal inMUMFMACA As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MUTAMAFA "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "MUMFSECU = '" & CInt(inMUMFSECU) & "' and "
            stConsultaSQL += "MUMFMACA = '" & CInt(inMUMFMACA) & "' "

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
