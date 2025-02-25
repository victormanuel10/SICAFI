Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration
Imports DATOS

Public Class cla_MOGETRAM

    '==================================================
    '*** CLASE TRAMITES OVC MOVIMIENTOS GEOGRAFICOS ***
    '==================================================

    ''' <summary>
    ''' procedimiento que verifica la llave primaria.
    ''' </summary>
    Public Function fun_Verifica_llave_Primaria_MOGETRAM(ByVal obMGTRSECU As Object) As Boolean

        Try
            Dim boRespuesta As Boolean = False

            Dim obVerifica As New cla_Verificar_Dato

            If obVerifica.fun_Verificar_Campo_Lleno(obMGTRSECU.Text) = True Then

                If obVerifica.fun_Verificar_Dato_Numerico(obMGTRSECU.Text) = True Then

                    Dim objdatos1 As New cla_MOGETRAM
                    Dim tbl As New DataTable

                    tbl = objdatos1.fun_Buscar_CODIGO_X_MOGETRAM(obMGTRSECU.Text)

                    If tbl.Rows.Count > 0 Then
                        MessageBox.Show("El dato " & Trim(obMGTRSECU.Text) & " existe en la base de datos, se incrementara una secuencia, favor guardar.", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                        obMGTRSECU.Focus()
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
    Public Function fun_Insertar_MOGETRAM(ByVal inMGTRSECU As Integer, _
                                          ByVal inMGTRNUTR As Integer, _
                                          ByVal stMGTRFETR As String, _
                                          ByVal inMGTRNURE As Integer, _
                                          ByVal stMGTRFERE As String, _
                                          ByVal stMGTRFEFI As String, _
                                          ByVal stMGTROBSE As String) As Boolean

        Try

            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "INSERT INTO "
            stConsultaSQL += "MOGETRAM "

            stConsultaSQL += "( "
            stConsultaSQL += "MGTRSECU, "
            stConsultaSQL += "MGTRNUTR, "
            stConsultaSQL += "MGTRFETR, "
            stConsultaSQL += "MGTRNURE, "
            stConsultaSQL += "MGTRFERE, "
            stConsultaSQL += "MGTRFEFI, "
            stConsultaSQL += "MGTROBSE "
            stConsultaSQL += ") "

            stConsultaSQL += "VALUES "

            stConsultaSQL += "( "
            stConsultaSQL += "'" & CInt(inMGTRSECU) & "', "
            stConsultaSQL += "'" & CInt(inMGTRNUTR) & "', "
            stConsultaSQL += "'" & CStr(Trim(stMGTRFETR)) & "', "
            stConsultaSQL += "'" & CInt(inMGTRNURE) & "', "
            stConsultaSQL += "'" & CStr(Trim(stMGTRFERE)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stMGTRFEFI)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stMGTROBSE)) & "' "
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
            MessageBox.Show(Err.Description & " " & "fun_Insertar_MOGETRAM")
        End Try

    End Function

    ''' <summary>
    ''' Función que Elimina el registro.
    ''' </summary>
    Public Function fun_Eliminar_IDRE_MOGETRAM(ByVal inMGTRIDRE As Integer) As Boolean

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "DELETE "
            stConsultaSQL += "MOGETRAM "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "MGTRIDRE = '" & CInt(inMGTRIDRE) & "' "

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
            MessageBox.Show(Err.Description & " " & "fun_Eliminar_IDRE_MOGETRAM")
        End Try

    End Function

    ''' <summary>
    ''' Función que Elimina el registro.
    ''' </summary>
    Public Function fun_Eliminar_SECU_MOGETRAM(ByVal inMGTRSECU As Integer) As Boolean

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "DELETE "
            stConsultaSQL += "MOGETRAM "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "MGTRSECU = '" & CInt(inMGTRSECU) & "' "

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
            MessageBox.Show(Err.Description & " " & "fun_Eliminar_IDRE_MOGETRAM")
        End Try

    End Function

    ''' <summary>
    ''' Función que Modifica el registro.
    ''' </summary>
    Public Function fun_Actualizar_IDRE_X_MOGETRAM(ByVal inMGTRIDRE As Integer, _
                                                   ByVal inMGTRSECU As Integer, _
                                                   ByVal inMGTRNUTR As Integer, _
                                                   ByVal stMGTRFETR As String, _
                                                   ByVal inMGTRNURE As Integer, _
                                                   ByVal stMGTRFERE As String, _
                                                   ByVal stMGTRFEFI As String, _
                                                   ByVal stMGTROBSE As String) As Boolean

        Try

            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "UPDATE "
            stConsultaSQL += "MOGETRAM "

            stConsultaSQL += "SET "
            stConsultaSQL += "MGTRSECU = '" & CInt(inMGTRSECU) & "', "
            stConsultaSQL += "MGTRNUTR = '" & CInt(inMGTRNUTR) & "', "
            stConsultaSQL += "MGTRFETR = '" & CStr(Trim(stMGTRFETR)) & "', "
            stConsultaSQL += "MGTRNURE = '" & CInt(inMGTRNURE) & "', "
            stConsultaSQL += "MGTRFERE = '" & CStr(Trim(stMGTRFERE)) & "', "
            stConsultaSQL += "MGTRFEFI = '" & CStr(Trim(stMGTRFEFI)) & "', "
            stConsultaSQL += "MGTROBSE = '" & CStr(Trim(stMGTROBSE)) & "' "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "MGTRIDRE = '" & CInt(inMGTRIDRE) & "' "

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
            MessageBox.Show(Err.Description & " " & "fun_Actualizar_MOGETRAM")
        End Try

    End Function

    ''' <summary>
    ''' Función que Modifica el registro.
    ''' </summary>
    Public Function fun_Actualizar_SECU_X_MOGETRAM(ByVal inMGTRSECU As Integer, _
                                                   ByVal inMGTRNUTR As Integer, _
                                                   ByVal stMGTRFETR As String, _
                                                   ByVal inMGTRNURE As Integer, _
                                                   ByVal stMGTRFERE As String, _
                                                   ByVal stMGTRFEFI As String, _
                                                   ByVal stMGTROBSE As String) As Boolean

        Try

            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "UPDATE "
            stConsultaSQL += "MOGETRAM "

            stConsultaSQL += "SET "
            stConsultaSQL += "MGTRNUTR = '" & CInt(inMGTRNUTR) & "', "
            stConsultaSQL += "MGTRFETR = '" & CStr(Trim(stMGTRFETR)) & "', "
            stConsultaSQL += "MGTRNURE = '" & CInt(inMGTRNURE) & "', "
            stConsultaSQL += "MGTRFERE = '" & CStr(Trim(stMGTRFERE)) & "', "
            stConsultaSQL += "MGTRFEFI = '" & CStr(Trim(stMGTRFEFI)) & "', "
            stConsultaSQL += "MGTROBSE = '" & CStr(Trim(stMGTROBSE)) & "' "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "MGTRSECU = '" & CInt(inMGTRSECU) & "' "

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
            MessageBox.Show(Err.Description & " " & "fun_Actualizar_MOGETRAM")
        End Try

    End Function

    ''' <summary>
    ''' Consulta para llenar el DataGridView y colocar el nombre del encabezado
    ''' de la columna. 
    ''' </summary>
    Public Function fun_Consultar_MOGETRAM(ByVal inMGTRSECU As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "MGTRIDRE, "
            stConsultaSQL += "MGTRSECU, "
            stConsultaSQL += "MGTRNUTR, "
            stConsultaSQL += "MGTRFETR, "
            stConsultaSQL += "MGTRNURE, "
            stConsultaSQL += "MGTRFERE, "
            stConsultaSQL += "MGTRFEFI, "
            stConsultaSQL += "MGTROBSE "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MOGETRAM "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "MGTRSECU = '" & CInt(inMGTRSECU) & " '"

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "MGTRSECU "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl


        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Consultar_MOGETRAM")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Consulta para llenar el DataGridView y colocar el nombre del encabezado
    ''' de la columna. 
    ''' </summary>
    Public Function fun_Consultar_MOGETRAM(ByVal inMGTRIDRE As Integer, ByVal inMGTRSECU As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "MGTRIDRE, "
            stConsultaSQL += "MGTRSECU, "
            stConsultaSQL += "MGTRNUTR, "
            stConsultaSQL += "MGTRFETR, "
            stConsultaSQL += "MGTRNURE, "
            stConsultaSQL += "MGTRFERE, "
            stConsultaSQL += "MGTRFEFI, "
            stConsultaSQL += "MGTROBSE "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MOGETRAM "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "MGTRIDRE = '" & CInt(inMGTRIDRE) & "' AND "
            stConsultaSQL += "MGTRSECU = '" & CInt(inMGTRSECU) & "' "

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "MGTRSECU "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl


        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Consultar_MOGETRAM")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que busca el ID del codigo buscado para ejecutar la consulta
    ''' parametrizada.
    ''' </summary>
    Public Function fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_MOGETRAM(ByVal inMGTRSECU As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "MGTRIDRE, "
            stConsultaSQL += "MGTRSECU, "
            stConsultaSQL += "MGTRNUTR, "
            stConsultaSQL += "MGTRFETR, "
            stConsultaSQL += "MGTRNURE, "
            stConsultaSQL += "MGTRFERE, "
            stConsultaSQL += "MGTRFEFI, "
            stConsultaSQL += "MGTROBSE "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MOGETRAM "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "MGTRSECU = '" & CInt(inMGTRSECU) & " '"

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "MGTRSECU "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception

            MessageBox.Show(Err.Description & " " & "fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_MOGETRAM")
            Return Nothing

        End Try

    End Function

    ''' <summary>
    ''' Función que busca el CÓDIGO para que no se 
    ''' guarden registros duplicados.
    ''' </summary>
    Public Function fun_Buscar_CODIGO_X_MOGETRAM(ByVal inMGTRSECU As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MOGETRAM "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "MGTRSECU = '" & CInt(inMGTRSECU) & "' "

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
