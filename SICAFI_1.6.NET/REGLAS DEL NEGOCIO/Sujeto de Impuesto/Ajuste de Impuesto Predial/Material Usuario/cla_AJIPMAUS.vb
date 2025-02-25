Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration
Imports DATOS

Public Class cla_AJIPMAUS

    '================================================
    '*** CLASE MATERIAL DE USUARIO AJUSTE PREDIAL ***
    '================================================

    ''' <summary>
    ''' procedimiento que verifica la llave primaria.
    ''' </summary>
    Public Function fun_Verifica_llave_Primaria_AJIPMAUS(ByVal obAJMUSECU As Object, ByVal obAJMUMACA As Object) As Boolean

        Try
            Dim boRespuesta As Boolean = False

            Dim obVerifica As New cla_Verificar_Dato

            If obVerifica.fun_Verificar_Campo_Lleno(obAJMUSECU.Text) = True And _
                obVerifica.fun_Verificar_Campo_Lleno(obAJMUMACA.Text) = True Then

                If obVerifica.fun_Verificar_Dato_Numerico(obAJMUSECU.Text) = True And _
                   obVerifica.fun_Verificar_Dato_Numerico(obAJMUMACA.Text) = True Then

                    Dim objdatos1 As New cla_AJIPMAUS
                    Dim tbl As New DataTable

                    tbl = objdatos1.fun_Buscar_CODIGO_X_AJIPMAUS(obAJMUSECU.Text, obAJMUMACA.Text)

                    If tbl.Rows.Count > 0 Then
                        MessageBox.Show("El dato " & Trim(obAJMUSECU.Text) & " - " & Trim(obAJMUMACA.Text) & " existe en la base de datos, se incrementara una secuencia, favor guardar.", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                        obAJMUSECU.Focus()
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
    Public Function fun_Insertar_AJIPMAUS(ByVal inAJMUSECU As Integer, _
                                          ByVal inAJMUMACA As Integer, _
                                          ByVal stAJMUFECH As String, _
                                          ByVal stAJMUOBSE As String) As Boolean

        Try

            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "INSERT INTO "
            stConsultaSQL += "AJIPMAUS "

            stConsultaSQL += "( "
            stConsultaSQL += "AJMUSECU, "
            stConsultaSQL += "AJMUMACA, "
            stConsultaSQL += "AJMUFECH, "
            stConsultaSQL += "AJMUOBSE "
            stConsultaSQL += ") "

            stConsultaSQL += "VALUES "

            stConsultaSQL += "( "
            stConsultaSQL += "'" & CInt(inAJMUSECU) & "', "
            stConsultaSQL += "'" & CInt(inAJMUMACA) & "', "
            stConsultaSQL += "'" & CStr(Trim(stAJMUFECH)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stAJMUOBSE)) & "' "
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
            MessageBox.Show(Err.Description & " " & "fun_Insertar_AJIPMAUS")
        End Try

    End Function

    ''' <summary>
    ''' Función que Elimina el registro.
    ''' </summary>
    Public Function fun_Eliminar_IDRE_AJIPMAUS(ByVal inAJMUIDRE As Integer) As Boolean

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "DELETE "
            stConsultaSQL += "AJIPMAUS "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "AJMUIDRE = '" & CInt(inAJMUIDRE) & "' "

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
            MessageBox.Show(Err.Description & " " & "fun_Eliminar_IDRE_AJIPMAUS")
        End Try

    End Function

    ''' <summary>
    ''' Función que Elimina el registro.
    ''' </summary>
    Public Function fun_Eliminar_SECU_X_MACA_AJIPMAUS(ByVal inAJMUSECU As Integer, ByVal inAJMUMACA As Integer) As Boolean

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "DELETE "
            stConsultaSQL += "AJIPMAUS "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "AJMUSECU = '" & CInt(inAJMUSECU) & "' and "
            stConsultaSQL += "AJMUMACA = '" & CInt(inAJMUMACA) & "' "

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
            MessageBox.Show(Err.Description & " " & "fun_Eliminar_SECU_X_MACA_AJIPMAUS")
        End Try

    End Function

    ''' <summary>
    ''' Función que Elimina el registro.
    ''' </summary>
    Public Function fun_Eliminar_SECU_AJIPMAUS(ByVal inAJMUSECU As Integer) As Boolean

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "DELETE "
            stConsultaSQL += "AJIPMAUS "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "AJMUSECU = '" & CInt(inAJMUSECU) & "' "

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
            MessageBox.Show(Err.Description & " " & "fun_Eliminar_IDRE_AJIPMAUS")
        End Try

    End Function

    ''' <summary>
    ''' Función que Modifica el registro.
    ''' </summary>
    Public Function fun_Actualizar_AJIPMAUS(ByVal inAJMUIDRE As Integer, _
                                            ByVal inAJMUSECU As Integer, _
                                            ByVal inAJMUMACA As Integer, _
                                            ByVal stAJMUFECH As String, _
                                            ByVal stAJMUOBSE As String) As Boolean

        Try

            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "UPDATE "
            stConsultaSQL += "AJIPMAUS "

            stConsultaSQL += "SET "
            stConsultaSQL += "AJMUSECU = '" & CInt(inAJMUSECU) & "', "
            stConsultaSQL += "AJMUMACA = '" & CInt(inAJMUMACA) & "', "
            stConsultaSQL += "AJMUFECH = '" & CStr(Trim(stAJMUFECH)) & "', "
            stConsultaSQL += "AJMUOBSE = '" & CStr(Trim(inAJMUIDRE)) & "' "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "AJMUIDRE = '" & CInt(inAJMUIDRE) & "' "

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
            MessageBox.Show(Err.Description & " " & "fun_Actualizar_AJIPMAUS")
        End Try

    End Function

    ''' <summary>
    ''' Consulta para llenar el DataGridView y colocar el nombre del encabezado
    ''' de la columna. 
    ''' </summary>
    Public Function fun_Consultar_AJIPMAUS() As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "AJMUIDRE, "
            stConsultaSQL += "AJMUSECU, "
            stConsultaSQL += "AJMUMACA, "
            stConsultaSQL += "MACADESC, "
            stConsultaSQL += "AJMUFECH, "
            stConsultaSQL += "AJMUOBSE "

            stConsultaSQL += "FROM "
            stConsultaSQL += "AJIPMAUS, MANT_MATECAMP "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "MACACODI = AJMUMACA "

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "AJMUMACA "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Consultar_AJIPMAUS")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que busca el ID del codigo buscado para ejecutar la consulta
    ''' parametrizada.
    ''' </summary>
    Public Function fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_AJIPMAUS(ByVal inAJMUSECU As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "AJMUIDRE, "
            stConsultaSQL += "AJMUSECU, "
            stConsultaSQL += "AJMUMACA, "
            stConsultaSQL += "MACADESC, "
            stConsultaSQL += "AJMUFECH, "
            stConsultaSQL += "AJMUOBSE "

            stConsultaSQL += "FROM "
            stConsultaSQL += "AJIPMAUS, MANT_MATECAMP "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "MACACODI = AJMUMACA and "
            stConsultaSQL += "AJMUSECU = '" & CInt(inAJMUSECU) & "'"

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "AJMUMACA "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception

            MessageBox.Show(Err.Description & " " & "fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_AJIPMAUS")
            Return Nothing

        End Try

    End Function

    ''' <summary>
    ''' Función que busca el CÓDIGO para que no se 
    ''' guarden registros duplicados.
    ''' </summary>
    Public Function fun_Buscar_CODIGO_X_AJIPMAUS(ByVal inAJMUSECU As Integer, ByVal inAJMUMACA As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "AJIPMAUS "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "AJMUSECU = '" & CInt(inAJMUSECU) & "' and "
            stConsultaSQL += "AJMUMACA = '" & CInt(inAJMUMACA) & "' "

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
