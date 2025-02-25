Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration
Imports DATOS

Public Class cla_MATEFALT

    '===============================
    '*** CLASE MATERIAL FALTANTE ***
    '===============================

    ''' <summary>
    ''' procedimiento que verifica la llave primaria.
    ''' </summary>
    Public Function fun_Verifica_llave_Primaria_MATEFALT(ByVal obMAFASECU As Object, ByVal obMAFAMACA As Object) As Boolean

        Try
            Dim boRespuesta As Boolean = False

            Dim obVerifica As New cla_Verificar_Dato

            If obVerifica.fun_Verificar_Campo_Lleno(obMAFASECU.Text) = True And _
                obVerifica.fun_Verificar_Campo_Lleno(obMAFAMACA.Text) = True Then

                If obVerifica.fun_Verificar_Dato_Numerico(obMAFASECU.Text) = True And _
                   obVerifica.fun_Verificar_Dato_Numerico(obMAFAMACA.Text) = True Then

                    Dim objdatos1 As New cla_MATEFALT
                    Dim tbl As New DataTable

                    tbl = objdatos1.fun_Buscar_CODIGO_X_MATEFALT(obMAFASECU.Text, obMAFAMACA.Text)

                    If tbl.Rows.Count > 0 Then
                        MessageBox.Show("El dato " & Trim(obMAFASECU.Text) & " - " & Trim(obMAFAMACA.Text) & " existe en la base de datos, se incrementara una secuencia, favor guardar.", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                        obMAFASECU.Focus()
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
    Public Function fun_Insertar_MATEFALT(ByVal inMAFASECU As Integer, _
                                          ByVal inMAFAMACA As Integer, _
                                          ByVal stMAFAFECH As String, _
                                          ByVal stMAFAOBSE As String) As Boolean

        Try

            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "INSERT INTO "
            stConsultaSQL += "MATEFALT "

            stConsultaSQL += "( "
            stConsultaSQL += "MAFASECU, "
            stConsultaSQL += "MAFAMACA, "
            stConsultaSQL += "MAFAFECH, "
            stConsultaSQL += "MAFAOBSE "
            stConsultaSQL += ") "

            stConsultaSQL += "VALUES "

            stConsultaSQL += "( "
            stConsultaSQL += "'" & CInt(inMAFASECU) & "', "
            stConsultaSQL += "'" & CInt(inMAFAMACA) & "', "
            stConsultaSQL += "'" & CStr(Trim(stMAFAFECH)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stMAFAOBSE)) & "' "
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
            MessageBox.Show(Err.Description & " " & "fun_Insertar_MATEFALT")
        End Try

    End Function

    ''' <summary>
    ''' Función que Elimina el registro.
    ''' </summary>
    Public Function fun_Eliminar_IDRE_MATEFALT(ByVal inMAFAIDRE As Integer) As Boolean

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "DELETE "
            stConsultaSQL += "MATEFALT "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "MAFAIDRE = '" & CInt(inMAFAIDRE) & "' "

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
            MessageBox.Show(Err.Description & " " & "fun_Eliminar_IDRE_MATEFALT")
        End Try

    End Function

    ''' <summary>
    ''' Función que Elimina el registro.
    ''' </summary>
    Public Function fun_Eliminar_SECU_X_MACA_MATEFALT(ByVal inMAFASECU As Integer, ByVal inMAFAMACA As Integer) As Boolean

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "DELETE "
            stConsultaSQL += "MATEFALT "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "MAFASECU = '" & CInt(inMAFASECU) & "' and "
            stConsultaSQL += "MAFAMACA = '" & CInt(inMAFAMACA) & "' "

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
            MessageBox.Show(Err.Description & " " & "fun_Eliminar_SECU_X_MACA_MATEFALT")
        End Try

    End Function

    ''' <summary>
    ''' Función que Elimina el registro.
    ''' </summary>
    Public Function fun_Eliminar_SECU_MATEFALT(ByVal inMAFASECU As Integer) As Boolean

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "DELETE "
            stConsultaSQL += "MATEFALT "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "MAFASECU = '" & CInt(inMAFASECU) & "' "

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
            MessageBox.Show(Err.Description & " " & "fun_Eliminar_IDRE_MATEFALT")
        End Try

    End Function

    ''' <summary>
    ''' Función que Modifica el registro.
    ''' </summary>
    Public Function fun_Actualizar_MATEFALT(ByVal inMAFAIDRE As Integer, _
                                            ByVal inMAFASECU As Integer, _
                                            ByVal inMAFAMACA As Integer, _
                                            ByVal stMAFAFECH As String, _
                                            ByVal stMAFAOBSE As String) As Boolean

        Try

            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "UPDATE "
            stConsultaSQL += "MATEFALT "

            stConsultaSQL += "SET "
            stConsultaSQL += "MAFASECU = '" & CInt(inMAFASECU) & "', "
            stConsultaSQL += "MAFAMACA = '" & CInt(inMAFAMACA) & "', "
            stConsultaSQL += "MAFAFECH = '" & CStr(Trim(stMAFAFECH)) & "', "
            stConsultaSQL += "MAFAOBSE = '" & CStr(Trim(inMAFAIDRE)) & "' "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "MAFAIDRE = '" & CInt(inMAFAIDRE) & "' "

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
            MessageBox.Show(Err.Description & " " & "fun_Actualizar_MATEFALT")
        End Try

    End Function

    ''' <summary>
    ''' Consulta para llenar el DataGridView y colocar el nombre del encabezado
    ''' de la columna. 
    ''' </summary>
    Public Function fun_Consultar_MATEFALT() As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "MAFAIDRE, "
            stConsultaSQL += "MAFASECU, "
            stConsultaSQL += "MAFAMACA, "
            stConsultaSQL += "MACADESC, "
            stConsultaSQL += "MAFAFECH, "
            stConsultaSQL += "MAFAOBSE "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MATEFALT, MANT_MATECAMP "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "MACACODI = MAFAMACA "

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "MAFAMACA "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Consultar_MATEFALT")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que busca el ID del codigo buscado para ejecutar la consulta
    ''' parametrizada.
    ''' </summary>
    Public Function fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_MATEFALT(ByVal inMAFASECU As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "MAFAIDRE, "
            stConsultaSQL += "MAFASECU, "
            stConsultaSQL += "MAFAMACA, "
            stConsultaSQL += "MACADESC, "
            stConsultaSQL += "MAFAFECH, "
            stConsultaSQL += "MAFAOBSE "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MATEFALT, MANT_MATECAMP "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "MACACODI = MAFAMACA and "
            stConsultaSQL += "MAFASECU = '" & CInt(inMAFASECU) & "'"

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "MAFAMACA "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception

            MessageBox.Show(Err.Description & " " & "fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_MATEFALT")
            Return Nothing

        End Try

    End Function

    ''' <summary>
    ''' Función que busca el CÓDIGO para que no se 
    ''' guarden registros duplicados.
    ''' </summary>
    Public Function fun_Buscar_CODIGO_X_MATEFALT(ByVal inMAFASECU As Integer, ByVal inMAFAMACA As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MATEFALT "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "MAFASECU = '" & CInt(inMAFASECU) & "' and "
            stConsultaSQL += "MAFAMACA = '" & CInt(inMAFAMACA) & "' "

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
