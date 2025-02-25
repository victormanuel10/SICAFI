Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration
Imports DATOS

Public Class cla_RECLMAEN

    '================================
    '*** CLASE MATERIAL ENTREGADO ***
    '================================

    ''' <summary>
    ''' procedimiento que verifica la llave primaria.
    ''' </summary>
    Public Function fun_Verifica_llave_Primaria_RECLMAEN(ByVal obREMESECU As Object, ByVal obREMEMACA As Object) As Boolean

        Try
            Dim boRespuesta As Boolean = False

            Dim obVerifica As New cla_Verificar_Dato

            If obVerifica.fun_Verificar_Campo_Lleno(obREMESECU.Text) = True And _
                obVerifica.fun_Verificar_Campo_Lleno(obREMEMACA.Text) = True Then

                If obVerifica.fun_Verificar_Dato_Numerico(obREMESECU.Text) = True And _
                   obVerifica.fun_Verificar_Dato_Numerico(obREMEMACA.Text) = True Then

                    Dim objdatos1 As New cla_RECLMAEN
                    Dim tbl As New DataTable

                    tbl = objdatos1.fun_Buscar_CODIGO_X_RECLMAEN(obREMESECU.Text, obREMEMACA.Text)

                    If tbl.Rows.Count > 0 Then
                        MessageBox.Show("El dato " & Trim(obREMESECU.Text) & " - " & Trim(obREMEMACA.Text) & " existe en la base de datos, se incrementara una secuencia, favor guardar.", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                        obREMESECU.Focus()
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
    Public Function fun_Insertar_RECLMAEN(ByVal inREMESECU As Integer, _
                                          ByVal inREMEMACA As Integer, _
                                          ByVal stREMEFECH As String, _
                                          ByVal stREMEOBSE As String) As Boolean

        Try

            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "INSERT INTO "
            stConsultaSQL += "RECLMAEN "

            stConsultaSQL += "( "
            stConsultaSQL += "REMESECU, "
            stConsultaSQL += "REMEMACA, "
            stConsultaSQL += "REMEFECH, "
            stConsultaSQL += "REMEOBSE "
            stConsultaSQL += ") "

            stConsultaSQL += "VALUES "

            stConsultaSQL += "( "
            stConsultaSQL += "'" & CInt(inREMESECU) & "', "
            stConsultaSQL += "'" & CInt(inREMEMACA) & "', "
            stConsultaSQL += "'" & CStr(Trim(stREMEFECH)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stREMEOBSE)) & "' "
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
            MessageBox.Show(Err.Description & " " & "fun_Insertar_RECLMAEN")
        End Try

    End Function

    ''' <summary>
    ''' Función que Elimina el registro.
    ''' </summary>
    Public Function fun_Eliminar_IDRE_RECLMAEN(ByVal inREMEIDRE As Integer) As Boolean

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "DELETE "
            stConsultaSQL += "RECLMAEN "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "REMEIDRE = '" & CInt(inREMEIDRE) & "' "

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
            MessageBox.Show(Err.Description & " " & "fun_Eliminar_IDRE_RECLMAEN")
        End Try

    End Function

    ''' <summary>
    ''' Función que Elimina el registro.
    ''' </summary>
    Public Function fun_Eliminar_SECU_X_MACA_RECLMAEN(ByVal inREMESECU As Integer, ByVal inREMEMACA As Integer) As Boolean

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "DELETE "
            stConsultaSQL += "RECLMAEN "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "REMESECU = '" & CInt(inREMESECU) & "' and "
            stConsultaSQL += "REMEMACA = '" & CInt(inREMEMACA) & "' "

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
            MessageBox.Show(Err.Description & " " & "fun_Eliminar_SECU_X_MACA_RECLMAEN")
        End Try

    End Function

    ''' <summary>
    ''' Función que Elimina el registro.
    ''' </summary>
    Public Function fun_Eliminar_SECU_RECLMAEN(ByVal inREMESECU As Integer) As Boolean

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "DELETE "
            stConsultaSQL += "RECLMAEN "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "REMESECU = '" & CInt(inREMESECU) & "' "

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
            MessageBox.Show(Err.Description & " " & "fun_Eliminar_IDRE_RECLMAEN")
        End Try

    End Function

    ''' <summary>
    ''' Función que Modifica el registro.
    ''' </summary>
    Public Function fun_Actualizar_RECLMAEN(ByVal inREMEIDRE As Integer, _
                                            ByVal inREMESECU As Integer, _
                                            ByVal inREMEMACA As Integer, _
                                            ByVal stREMEFECH As String, _
                                            ByVal stREMEOBSE As String) As Boolean

        Try

            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "UPDATE "
            stConsultaSQL += "RECLMAEN "

            stConsultaSQL += "SET "
            stConsultaSQL += "REMESECU = '" & CInt(inREMESECU) & "', "
            stConsultaSQL += "REMEMACA = '" & CInt(inREMEMACA) & "', "
            stConsultaSQL += "REMEFECH = '" & CStr(Trim(stREMEFECH)) & "', "
            stConsultaSQL += "REMEOBSE = '" & CStr(Trim(inREMEIDRE)) & "' "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "REMEIDRE = '" & CInt(inREMEIDRE) & "' "

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
            MessageBox.Show(Err.Description & " " & "fun_Actualizar_RECLMAEN")
        End Try

    End Function

    ''' <summary>
    ''' Consulta para llenar el DataGridView y colocar el nombre del encabezado
    ''' de la columna. 
    ''' </summary>
    Public Function fun_Consultar_RECLMAEN() As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "REMEIDRE, "
            stConsultaSQL += "REMESECU, "
            stConsultaSQL += "REMEMACA, "
            stConsultaSQL += "MACADESC, "
            stConsultaSQL += "REMEFECH, "
            stConsultaSQL += "REMEOBSE "

            stConsultaSQL += "FROM "
            stConsultaSQL += "RECLMAEN, MANT_MATECAMP "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "MACACODI = REMEMACA "

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "REMEMACA "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Consultar_RECLMAEN")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que busca el ID del codigo buscado para ejecutar la consulta
    ''' parametrizada.
    ''' </summary>
    Public Function fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_RECLMAEN(ByVal inREMESECU As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "REMEIDRE, "
            stConsultaSQL += "REMESECU, "
            stConsultaSQL += "REMEMACA, "
            stConsultaSQL += "MACADESC, "
            stConsultaSQL += "REMEFECH, "
            stConsultaSQL += "REMEOBSE "

            stConsultaSQL += "FROM "
            stConsultaSQL += "RECLMAEN, MANT_MATECAMP "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "MACACODI = REMEMACA and "
            stConsultaSQL += "REMESECU = '" & CInt(inREMESECU) & "'"

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "REMEMACA "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception

            MessageBox.Show(Err.Description & " " & "fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_RECLMAEN")
            Return Nothing

        End Try

    End Function

    ''' <summary>
    ''' Función que busca el CÓDIGO para que no se 
    ''' guarden registros duplicados.
    ''' </summary>
    Public Function fun_Buscar_CODIGO_X_RECLMAEN(ByVal inREMESECU As Integer, ByVal inREMEMACA As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "RECLMAEN "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "REMESECU = '" & CInt(inREMESECU) & "' and "
            stConsultaSQL += "REMEMACA = '" & CInt(inREMEMACA) & "' "

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
