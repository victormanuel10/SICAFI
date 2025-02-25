Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration
Imports DATOS

Public Class cla_AJIPMACA

    '=================================================
    '*** CLASE MATERIAL DE CATASTRO AJUSTE PREDIAL ***
    '=================================================

    ''' <summary>
    ''' procedimiento que verifica la llave primaria.
    ''' </summary>
    Public Function fun_Verifica_llave_Primaria_AJIPMACA(ByVal obAJMCSECU As Object, ByVal obAJMCMACA As Object) As Boolean

        Try
            Dim boRespuesta As Boolean = False

            Dim obVerifica As New cla_Verificar_Dato

            If obVerifica.fun_Verificar_Campo_Lleno(obAJMCSECU.Text) = True And _
                obVerifica.fun_Verificar_Campo_Lleno(obAJMCMACA.Text) = True Then

                If obVerifica.fun_Verificar_Dato_Numerico(obAJMCSECU.Text) = True And _
                   obVerifica.fun_Verificar_Dato_Numerico(obAJMCMACA.Text) = True Then

                    Dim objdatos1 As New cla_AJIPMACA
                    Dim tbl As New DataTable

                    tbl = objdatos1.fun_Buscar_CODIGO_X_AJIPMACA(obAJMCSECU.Text, obAJMCMACA.Text)

                    If tbl.Rows.Count > 0 Then
                        MessageBox.Show("El dato " & Trim(obAJMCSECU.Text) & " - " & Trim(obAJMCMACA.Text) & " existe en la base de datos, se incrementara una secuencia, favor guardar.", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                        obAJMCSECU.Focus()
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
    Public Function fun_Insertar_AJIPMACA(ByVal inAJMCSECU As Integer, _
                                          ByVal inAJMCMACA As Integer, _
                                          ByVal stAJMCFECH As String, _
                                          ByVal stAJMCOBSE As String) As Boolean

        Try

            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "INSERT INTO "
            stConsultaSQL += "AJIPMACA "

            stConsultaSQL += "( "
            stConsultaSQL += "AJMCSECU, "
            stConsultaSQL += "AJMCMACA, "
            stConsultaSQL += "AJMCFECH, "
            stConsultaSQL += "AJMCOBSE "
            stConsultaSQL += ") "

            stConsultaSQL += "VALUES "

            stConsultaSQL += "( "
            stConsultaSQL += "'" & CInt(inAJMCSECU) & "', "
            stConsultaSQL += "'" & CInt(inAJMCMACA) & "', "
            stConsultaSQL += "'" & CStr(Trim(stAJMCFECH)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stAJMCOBSE)) & "' "
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
            MessageBox.Show(Err.Description & " " & "fun_Insertar_AJIPMACA")
        End Try

    End Function

    ''' <summary>
    ''' Función que Elimina el registro.
    ''' </summary>
    Public Function fun_Eliminar_IDRE_AJIPMACA(ByVal inAJMCIDRE As Integer) As Boolean

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "DELETE "
            stConsultaSQL += "AJIPMACA "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "AJMCIDRE = '" & CInt(inAJMCIDRE) & "' "

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
            MessageBox.Show(Err.Description & " " & "fun_Eliminar_IDRE_AJIPMACA")
        End Try

    End Function

    ''' <summary>
    ''' Función que Elimina el registro.
    ''' </summary>
    Public Function fun_Eliminar_SECU_X_MACA_AJIPMACA(ByVal inAJMCSECU As Integer, ByVal inAJMCMACA As Integer) As Boolean

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "DELETE "
            stConsultaSQL += "AJIPMACA "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "AJMCSECU = '" & CInt(inAJMCSECU) & "' and "
            stConsultaSQL += "AJMCMACA = '" & CInt(inAJMCMACA) & "' "

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
            MessageBox.Show(Err.Description & " " & "fun_Eliminar_SECU_X_MACA_AJIPMACA")
        End Try

    End Function

    ''' <summary>
    ''' Función que Elimina el registro.
    ''' </summary>
    Public Function fun_Eliminar_SECU_AJIPMACA(ByVal inAJMCSECU As Integer) As Boolean

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "DELETE "
            stConsultaSQL += "AJIPMACA "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "AJMCSECU = '" & CInt(inAJMCSECU) & "' "

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
            MessageBox.Show(Err.Description & " " & "fun_Eliminar_IDRE_AJIPMACA")
        End Try

    End Function

    ''' <summary>
    ''' Función que Modifica el registro.
    ''' </summary>
    Public Function fun_Actualizar_AJIPMACA(ByVal inAJMCIDRE As Integer, _
                                            ByVal inAJMCSECU As Integer, _
                                            ByVal inAJMCMACA As Integer, _
                                            ByVal stAJMCFECH As String, _
                                            ByVal stAJMCOBSE As String) As Boolean

        Try

            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "UPDATE "
            stConsultaSQL += "AJIPMACA "

            stConsultaSQL += "SET "
            stConsultaSQL += "AJMCSECU = '" & CInt(inAJMCSECU) & "', "
            stConsultaSQL += "AJMCMACA = '" & CInt(inAJMCMACA) & "', "
            stConsultaSQL += "AJMCFECH = '" & CStr(Trim(stAJMCFECH)) & "', "
            stConsultaSQL += "AJMCOBSE = '" & CStr(Trim(inAJMCIDRE)) & "' "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "AJMCIDRE = '" & CInt(inAJMCIDRE) & "' "

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
            MessageBox.Show(Err.Description & " " & "fun_Actualizar_AJIPMACA")
        End Try

    End Function

    ''' <summary>
    ''' Consulta para llenar el DataGridView y colocar el nombre del encabezado
    ''' de la columna. 
    ''' </summary>
    Public Function fun_Consultar_AJIPMACA() As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "AJMCIDRE, "
            stConsultaSQL += "AJMCSECU, "
            stConsultaSQL += "AJMCMACA, "
            stConsultaSQL += "MACADESC, "
            stConsultaSQL += "AJMCFECH, "
            stConsultaSQL += "AJMCOBSE "

            stConsultaSQL += "FROM "
            stConsultaSQL += "AJIPMACA, MANT_MATECAMP "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "MACACODI = AJMCMACA "

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "AJMCMACA "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Consultar_AJIPMACA")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que busca el ID del codigo buscado para ejecutar la consulta
    ''' parametrizada.
    ''' </summary>
    Public Function fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_AJIPMACA(ByVal inAJMCSECU As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "AJMCIDRE, "
            stConsultaSQL += "AJMCSECU, "
            stConsultaSQL += "AJMCMACA, "
            stConsultaSQL += "MACADESC, "
            stConsultaSQL += "AJMCFECH, "
            stConsultaSQL += "AJMCOBSE "

            stConsultaSQL += "FROM "
            stConsultaSQL += "AJIPMACA, MANT_MATECAMP "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "MACACODI = AJMCMACA and "
            stConsultaSQL += "AJMCSECU = '" & CInt(inAJMCSECU) & "'"

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "AJMCMACA "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception

            MessageBox.Show(Err.Description & " " & "fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_AJIPMACA")
            Return Nothing

        End Try

    End Function

    ''' <summary>
    ''' Función que busca el CÓDIGO para que no se 
    ''' guarden registros duplicados.
    ''' </summary>
    Public Function fun_Buscar_CODIGO_X_AJIPMACA(ByVal inAJMCSECU As Integer, ByVal inAJMCMACA As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "AJIPMACA "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "AJMCSECU = '" & CInt(inAJMCSECU) & "' and "
            stConsultaSQL += "AJMCMACA = '" & CInt(inAJMCMACA) & "' "

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
