Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration
Imports DATOS

Public Class cla_REAVMAEN

    '===================================================
    '*** CLASE MATERIAL ENTREGADO REVISION DE AVALUO ***
    '===================================================

    ''' <summary>
    ''' procedimiento que verifica la llave primaria.
    ''' </summary>
    Public Function fun_Verifica_llave_Primaria_REAVMAEN(ByVal obRAMESECU As Object, ByVal obRAMEMACA As Object) As Boolean

        Try
            Dim boRespuesta As Boolean = False

            Dim obVerifica As New cla_Verificar_Dato

            If obVerifica.fun_Verificar_Campo_Lleno(obRAMESECU.Text) = True And _
                obVerifica.fun_Verificar_Campo_Lleno(obRAMEMACA.Text) = True Then

                If obVerifica.fun_Verificar_Dato_Numerico(obRAMESECU.Text) = True And _
                   obVerifica.fun_Verificar_Dato_Numerico(obRAMEMACA.Text) = True Then

                    Dim objdatos1 As New cla_REAVMAEN
                    Dim tbl As New DataTable

                    tbl = objdatos1.fun_Buscar_CODIGO_X_REAVMAEN(obRAMESECU.Text, obRAMEMACA.Text)

                    If tbl.Rows.Count > 0 Then
                        MessageBox.Show("El dato " & Trim(obRAMESECU.Text) & " - " & Trim(obRAMEMACA.Text) & " existe en la base de datos, se incRAMEntara una secuencia, favor guardar.", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                        obRAMESECU.Focus()
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
    Public Function fun_Insertar_REAVMAEN(ByVal inRAMESECU As Integer, _
                                          ByVal inRAMEMACA As Integer, _
                                          ByVal stRAMEFECH As String, _
                                          ByVal stRAMEOBSE As String) As Boolean

        Try

            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "INSERT INTO "
            stConsultaSQL += "REAVMAEN "

            stConsultaSQL += "( "
            stConsultaSQL += "RAMESECU, "
            stConsultaSQL += "RAMEMACA, "
            stConsultaSQL += "RAMEFECH, "
            stConsultaSQL += "RAMEOBSE "
            stConsultaSQL += ") "

            stConsultaSQL += "VALUES "

            stConsultaSQL += "( "
            stConsultaSQL += "'" & CInt(inRAMESECU) & "', "
            stConsultaSQL += "'" & CInt(inRAMEMACA) & "', "
            stConsultaSQL += "'" & CStr(Trim(stRAMEFECH)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stRAMEOBSE)) & "' "
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
            MessageBox.Show(Err.Description & " " & "fun_Insertar_REAVMAEN")
        End Try

    End Function

    ''' <summary>
    ''' Función que Elimina el registro.
    ''' </summary>
    Public Function fun_Eliminar_IDRE_REAVMAEN(ByVal inRAMEIDRE As Integer) As Boolean

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "DELETE "
            stConsultaSQL += "REAVMAEN "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "RAMEIDRE = '" & CInt(inRAMEIDRE) & "' "

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
            MessageBox.Show(Err.Description & " " & "fun_Eliminar_IDRE_REAVMAEN")
        End Try

    End Function

    ''' <summary>
    ''' Función que Elimina el registro.
    ''' </summary>
    Public Function fun_Eliminar_SECU_X_MACA_REAVMAEN(ByVal inRAMESECU As Integer, ByVal inRAMEMACA As Integer) As Boolean

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "DELETE "
            stConsultaSQL += "REAVMAEN "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "RAMESECU = '" & CInt(inRAMESECU) & "' and "
            stConsultaSQL += "RAMEMACA = '" & CInt(inRAMEMACA) & "' "

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
            MessageBox.Show(Err.Description & " " & "fun_Eliminar_SECU_X_MACA_REAVMAEN")
        End Try

    End Function

    ''' <summary>
    ''' Función que Elimina el registro.
    ''' </summary>
    Public Function fun_Eliminar_SECU_REAVMAEN(ByVal inRAMESECU As Integer) As Boolean

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "DELETE "
            stConsultaSQL += "REAVMAEN "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "RAMESECU = '" & CInt(inRAMESECU) & "' "

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
            MessageBox.Show(Err.Description & " " & "fun_Eliminar_IDRE_REAVMAEN")
        End Try

    End Function

    ''' <summary>
    ''' Función que Modifica el registro.
    ''' </summary>
    Public Function fun_Actualizar_REAVMAEN(ByVal inRAMEIDRE As Integer, _
                                            ByVal inRAMESECU As Integer, _
                                            ByVal inRAMEMACA As Integer, _
                                            ByVal stRAMEFECH As String, _
                                            ByVal stRAMEOBSE As String) As Boolean

        Try

            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "UPDATE "
            stConsultaSQL += "REAVMAEN "

            stConsultaSQL += "SET "
            stConsultaSQL += "RAMESECU = '" & CInt(inRAMESECU) & "', "
            stConsultaSQL += "RAMEMACA = '" & CInt(inRAMEMACA) & "', "
            stConsultaSQL += "RAMEFECH = '" & CStr(Trim(stRAMEFECH)) & "', "
            stConsultaSQL += "RAMEOBSE = '" & CStr(Trim(inRAMEIDRE)) & "' "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "RAMEIDRE = '" & CInt(inRAMEIDRE) & "' "

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
            MessageBox.Show(Err.Description & " " & "fun_Actualizar_REAVMAEN")
        End Try

    End Function

    ''' <summary>
    ''' Consulta para llenar el DataGridView y colocar el nombre del encabezado
    ''' de la columna. 
    ''' </summary>
    Public Function fun_Consultar_REAVMAEN() As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "RAMEIDRE, "
            stConsultaSQL += "RAMESECU, "
            stConsultaSQL += "RAMEMACA, "
            stConsultaSQL += "MACADESC, "
            stConsultaSQL += "RAMEFECH, "
            stConsultaSQL += "RAMEOBSE "

            stConsultaSQL += "FROM "
            stConsultaSQL += "REAVMAEN, MANT_MATECAMP "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "MACACODI = RAMEMACA "

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "RAMEMACA "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Consultar_REAVMAEN")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que busca el ID del codigo buscado para ejecutar la consulta
    ''' parametrizada.
    ''' </summary>
    Public Function fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_REAVMAEN(ByVal inRAMESECU As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "RAMEIDRE, "
            stConsultaSQL += "RAMESECU, "
            stConsultaSQL += "RAMEMACA, "
            stConsultaSQL += "MACADESC, "
            stConsultaSQL += "RAMEFECH, "
            stConsultaSQL += "RAMEOBSE "

            stConsultaSQL += "FROM "
            stConsultaSQL += "REAVMAEN, MANT_MATECAMP "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "MACACODI = RAMEMACA and "
            stConsultaSQL += "RAMESECU = '" & CInt(inRAMESECU) & "'"

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "RAMEMACA "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception

            MessageBox.Show(Err.Description & " " & "fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_REAVMAEN")
            Return Nothing

        End Try

    End Function

    ''' <summary>
    ''' Función que busca el CÓDIGO para que no se 
    ''' guarden registros duplicados.
    ''' </summary>
    Public Function fun_Buscar_CODIGO_X_REAVMAEN(ByVal inRAMESECU As Integer, ByVal inRAMEMACA As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "REAVMAEN "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "RAMESECU = '" & CInt(inRAMESECU) & "' and "
            stConsultaSQL += "RAMEMACA = '" & CInt(inRAMEMACA) & "' "

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
