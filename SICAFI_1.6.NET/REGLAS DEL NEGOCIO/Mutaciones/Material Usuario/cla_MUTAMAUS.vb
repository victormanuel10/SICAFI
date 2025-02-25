Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration
Imports DATOS

Public Class cla_MUTAMAUS

    '============================================
    '*** CLASE MATERIAL DE USUARIO MUTACIONES ***
    '============================================

    ''' <summary>
    ''' procedimiento que verifica la llave primaria.
    ''' </summary>
    Public Function fun_Verifica_llave_Primaria_MUTAMAUS(ByVal obMUMUSECU As Object, ByVal obMUMUMACA As Object) As Boolean

        Try
            Dim boRespuesta As Boolean = False

            Dim obVerifica As New cla_Verificar_Dato

            If obVerifica.fun_Verificar_Campo_Lleno(obMUMUSECU.Text) = True And _
                obVerifica.fun_Verificar_Campo_Lleno(obMUMUMACA.Text) = True Then

                If obVerifica.fun_Verificar_Dato_Numerico(obMUMUSECU.Text) = True And _
                   obVerifica.fun_Verificar_Dato_Numerico(obMUMUMACA.Text) = True Then

                    Dim objdatos1 As New cla_MUTAMAUS
                    Dim tbl As New DataTable

                    tbl = objdatos1.fun_Buscar_CODIGO_X_MUTAMAUS(obMUMUSECU.Text, obMUMUMACA.Text)

                    If tbl.Rows.Count > 0 Then
                        MessageBox.Show("El dato " & Trim(obMUMUSECU.Text) & " - " & Trim(obMUMUMACA.Text) & " existe en la base de datos, se incrementara una secuencia, favor guardar.", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                        obMUMUSECU.Focus()
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
    Public Function fun_Insertar_MUTAMAUS(ByVal inMUMUSECU As Integer, _
                                          ByVal inMUMUMACA As Integer, _
                                          ByVal stMUMUFECH As String, _
                                          ByVal stMUMUOBSE As String) As Boolean

        Try

            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "INSERT INTO "
            stConsultaSQL += "MUTAMAUS "

            stConsultaSQL += "( "
            stConsultaSQL += "MUMUSECU, "
            stConsultaSQL += "MUMUMACA, "
            stConsultaSQL += "MUMUFECH, "
            stConsultaSQL += "MUMUOBSE "
            stConsultaSQL += ") "

            stConsultaSQL += "VALUES "

            stConsultaSQL += "( "
            stConsultaSQL += "'" & CInt(inMUMUSECU) & "', "
            stConsultaSQL += "'" & CInt(inMUMUMACA) & "', "
            stConsultaSQL += "'" & CStr(Trim(stMUMUFECH)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stMUMUOBSE)) & "' "
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
            MessageBox.Show(Err.Description & " " & "fun_Insertar_MUTAMAUS")
        End Try

    End Function

    ''' <summary>
    ''' Función que Elimina el registro.
    ''' </summary>
    Public Function fun_Eliminar_IDRE_MUTAMAUS(ByVal inMUMUIDRE As Integer) As Boolean

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "DELETE "
            stConsultaSQL += "MUTAMAUS "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "MUMUIDRE = '" & CInt(inMUMUIDRE) & "' "

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
            MessageBox.Show(Err.Description & " " & "fun_Eliminar_IDRE_MUTAMAUS")
        End Try

    End Function

    ''' <summary>
    ''' Función que Elimina el registro.
    ''' </summary>
    Public Function fun_Eliminar_SECU_X_MACA_MUTAMAUS(ByVal inMUMUSECU As Integer, ByVal inMUMUMACA As Integer) As Boolean

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "DELETE "
            stConsultaSQL += "MUTAMAUS "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "MUMUSECU = '" & CInt(inMUMUSECU) & "' and "
            stConsultaSQL += "MUMUMACA = '" & CInt(inMUMUMACA) & "' "

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
            MessageBox.Show(Err.Description & " " & "fun_Eliminar_SECU_X_MACA_MUTAMAUS")
        End Try

    End Function

    ''' <summary>
    ''' Función que Elimina el registro.
    ''' </summary>
    Public Function fun_Eliminar_SECU_MUTAMAUS(ByVal inMUMUSECU As Integer) As Boolean

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "DELETE "
            stConsultaSQL += "MUTAMAUS "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "MUMUSECU = '" & CInt(inMUMUSECU) & "' "

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
            MessageBox.Show(Err.Description & " " & "fun_Eliminar_IDRE_MUTAMAUS")
        End Try

    End Function

    ''' <summary>
    ''' Función que Modifica el registro.
    ''' </summary>
    Public Function fun_Actualizar_MUTAMAUS(ByVal inMUMUIDRE As Integer, _
                                            ByVal inMUMUSECU As Integer, _
                                            ByVal inMUMUMACA As Integer, _
                                            ByVal stMUMUFECH As String, _
                                            ByVal stMUMUOBSE As String) As Boolean

        Try

            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "UPDATE "
            stConsultaSQL += "MUTAMAUS "

            stConsultaSQL += "SET "
            stConsultaSQL += "MUMUSECU = '" & CInt(inMUMUSECU) & "', "
            stConsultaSQL += "MUMUMACA = '" & CInt(inMUMUMACA) & "', "
            stConsultaSQL += "MUMUFECH = '" & CStr(Trim(stMUMUFECH)) & "', "
            stConsultaSQL += "MUMUOBSE = '" & CStr(Trim(inMUMUIDRE)) & "' "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "MUMUIDRE = '" & CInt(inMUMUIDRE) & "' "

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
            MessageBox.Show(Err.Description & " " & "fun_Actualizar_MUTAMAUS")
        End Try

    End Function

    ''' <summary>
    ''' Consulta para llenar el DataGridView y colocar el nombre del encabezado
    ''' de la columna. 
    ''' </summary>
    Public Function fun_Consultar_MUTAMAUS() As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "MUMUIDRE, "
            stConsultaSQL += "MUMUSECU, "
            stConsultaSQL += "MUMUMACA, "
            stConsultaSQL += "MACADESC, "
            stConsultaSQL += "MUMUFECH, "
            stConsultaSQL += "MUMUOBSE "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MUTAMAUS, MANT_MATECAMP "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "MACACODI = MUMUMACA "

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "MUMUMACA "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Consultar_MUTAMAUS")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que busca el ID del codigo buscado para ejecutar la consulta
    ''' parametrizada.
    ''' </summary>
    Public Function fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_MUTAMAUS(ByVal inMUMUSECU As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "MUMUIDRE, "
            stConsultaSQL += "MUMUSECU, "
            stConsultaSQL += "MUMUMACA, "
            stConsultaSQL += "MACADESC, "
            stConsultaSQL += "MUMUFECH, "
            stConsultaSQL += "MUMUOBSE "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MUTAMAUS, MANT_MATECAMP "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "MACACODI = MUMUMACA and "
            stConsultaSQL += "MUMUSECU = '" & CInt(inMUMUSECU) & "'"

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "MUMUMACA "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception

            MessageBox.Show(Err.Description & " " & "fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_MUTAMAUS")
            Return Nothing

        End Try

    End Function

    ''' <summary>
    ''' Función que busca el CÓDIGO para que no se 
    ''' guarden registros duplicados.
    ''' </summary>
    Public Function fun_Buscar_CODIGO_X_MUTAMAUS(ByVal inMUMUSECU As Integer, ByVal inMUMUMACA As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MUTAMAUS "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "MUMUSECU = '" & CInt(inMUMUSECU) & "' and "
            stConsultaSQL += "MUMUMACA = '" & CInt(inMUMUMACA) & "' "

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
