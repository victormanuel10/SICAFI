Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration
Imports DATOS

Public Class cla_MUTAARCH

    '================================
    '*** CLASE ARCHIVO MUTACIONES ***
    '================================

    ''' <summary>
    ''' procedimiento que verifica la llave primaria.
    ''' </summary>
    Public Function fun_Verifica_llave_Primaria_MUTAARCH(ByVal inMUARSECU As Integer, ByVal obMUARNUDO As Object, ByVal obMUARFEEN As Object) As Boolean

        Try
            Dim boRespuesta As Boolean = False

            Dim obVerifica As New cla_Verificar_Dato

            If obVerifica.fun_Verificar_Campo_Lleno(inMUARSECU) = True And _
                obVerifica.fun_Verificar_Campo_Lleno(obMUARNUDO.Text) = True And _
                obVerifica.fun_Verificar_Campo_Lleno(obMUARFEEN.Text) = True Then

                If obVerifica.fun_Verificar_Dato_Numerico(inMUARSECU) = True Then

                    Dim objdatos1 As New cla_MUTAARCH
                    Dim tbl As New DataTable

                    tbl = objdatos1.fun_Buscar_CODIGO_X_MUTAARCH(inMUARSECU, obMUARNUDO.Text, obMUARFEEN.Text)

                    If tbl.Rows.Count > 0 Then
                        MessageBox.Show("El dato " & Trim(inMUARSECU) & " - " & Trim(obMUARNUDO.Text) & " - " & Trim(obMUARFEEN.Text) & " existe en la base de datos.", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                        obMUARNUDO.Focus()
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
    Public Function fun_Insertar_MUTAARCH(ByVal inMUARSECU As Integer, _
                                          ByVal stMUARNUDO As String, _
                                          ByVal stMUARFEEN As String, _
                                          ByVal stMUAROBSE As String) As Boolean

        Try

            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "INSERT INTO "
            stConsultaSQL += "MUTAARCH "

            stConsultaSQL += "( "
            stConsultaSQL += "MUARSECU, "
            stConsultaSQL += "MUARNUDO, "
            stConsultaSQL += "MUARFEEN, "
            stConsultaSQL += "MUAROBSE "
            stConsultaSQL += ") "

            stConsultaSQL += "VALUES "

            stConsultaSQL += "( "
            stConsultaSQL += "'" & CInt(inMUARSECU) & "', "
            stConsultaSQL += "'" & CStr(Trim(stMUARNUDO)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stMUARFEEN)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stMUAROBSE)) & "' "
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
            MessageBox.Show(Err.Description & " " & "fun_Insertar_MUTAARCH")
        End Try

    End Function

    ''' <summary>
    ''' Función que Elimina el registro.
    ''' </summary>
    Public Function fun_Eliminar_IDRE_MUTAARCH(ByVal inMUARIDRE As Integer) As Boolean

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "DELETE "
            stConsultaSQL += "MUTAARCH "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "MUARIDRE = '" & CInt(inMUARIDRE) & "' "

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
            MessageBox.Show(Err.Description & " " & "fun_Eliminar_IDRE_MUTAARCH")
        End Try

    End Function

    ''' <summary>
    ''' Función que Elimina el registro.
    ''' </summary>
    Public Function fun_Eliminar_SECU_X_NUDO_MUTAARCH(ByVal inMUARSECU As Integer, ByVal stMUARNUDO As String) As Boolean

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "DELETE "
            stConsultaSQL += "MUTAARCH "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "MUARSECU = '" & CInt(inMUARSECU) & "' and "
            stConsultaSQL += "MUARNUDO = '" & CStr(Trim(stMUARNUDO)) & "' "

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
            MessageBox.Show(Err.Description & " " & "fun_Eliminar_SECU_X_MACA_MUTAARCH")
        End Try

    End Function

    ''' <summary>
    ''' Función que Elimina el registro.
    ''' </summary>
    Public Function fun_Eliminar_SECU_MUTAARCH(ByVal inMUARSECU As Integer) As Boolean

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "DELETE "
            stConsultaSQL += "MUTAARCH "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "MUARSECU = '" & CInt(inMUARSECU) & "' "

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
            MessageBox.Show(Err.Description & " " & "fun_Eliminar_IDRE_MUTAARCH")
        End Try

    End Function

    ''' <summary>
    ''' Función que Modifica el registro.
    ''' </summary>
    Public Function fun_Actualizar_MUTAARCH(ByVal inMUARIDRE As Integer, _
                                            ByVal inMUARSECU As Integer, _
                                            ByVal stMUARNUDO As String, _
                                            ByVal stMUARFEEN As String, _
                                            ByVal stMUAROBSE As String) As Boolean

        Try

            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "UPDATE "
            stConsultaSQL += "MUTAARCH "

            stConsultaSQL += "SET "
            stConsultaSQL += "MUARSECU = '" & CInt(inMUARSECU) & "', "
            stConsultaSQL += "MUARNUDO = '" & CStr(Trim(stMUARNUDO)) & "', "
            stConsultaSQL += "MUARFEEN = '" & CStr(Trim(stMUARFEEN)) & "', "
            stConsultaSQL += "MUAROBSE = '" & CStr(Trim(stMUAROBSE)) & "' "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "MUARIDRE = '" & CInt(inMUARIDRE) & "' "

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
            MessageBox.Show(Err.Description & " " & "fun_Actualizar_MUTAARCH")
        End Try

    End Function


    ''' <summary>
    ''' Consulta para llenar el DataGridView y colocar el nombre del encabezado
    ''' de la columna. 
    ''' </summary>
    Public Function fun_Consultar_MUTAARCH() As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "MUARIDRE, "
            stConsultaSQL += "MUARSECU, "
            stConsultaSQL += "MUARNUDO, "
            stConsultaSQL += "USUANOMB, "
            stConsultaSQL += "USUAPRAP, "
            stConsultaSQL += "USUASEAP, "
            stConsultaSQL += "MUARFEEN, "
            stConsultaSQL += "MUAROBSE "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MUTAARCH, USUARIO "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "MUARNUDO = USUANUDO "

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "MUARFEEN "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Consultar_MUTAARCH")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que busca el ID del codigo buscado para ejecutar la consulta
    ''' parametrizada.
    ''' </summary>
    Public Function fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_MUTAARCH(ByVal inMUARSECU As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "MUARIDRE, "
            stConsultaSQL += "MUARSECU, "
            stConsultaSQL += "MUARNUDO, "
            stConsultaSQL += "USUANOMB, "
            stConsultaSQL += "USUAPRAP, "
            stConsultaSQL += "USUASEAP, "
            stConsultaSQL += "MUARFEEN, "
            stConsultaSQL += "MUAROBSE "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MUTAARCH, USUARIO "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "MUARNUDO = USUANUDO and "
            stConsultaSQL += "MUARSECU = '" & CInt(inMUARSECU) & "'"

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "MUARFEEN "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception

            MessageBox.Show(Err.Description & " " & "fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_MUTAARCH")
            Return Nothing

        End Try

    End Function

    ''' <summary>
    ''' Función que busca el CÓDIGO para que no se 
    ''' guarden registros duplicados.
    ''' </summary>
    Public Function fun_Buscar_CODIGO_X_MUTAARCH(ByVal inMUARSECU As Integer, ByVal stMUARNUDO As String, ByVal stMUARFEEN As String) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MUTAARCH "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "MUARSECU = '" & CInt(inMUARSECU) & "' and "
            stConsultaSQL += "MUARNUDO = '" & CStr(Trim(stMUARNUDO)) & "' and "
            stConsultaSQL += "MUARFEEN = '" & CStr(Trim(stMUARFEEN)) & "' "

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
    ''' <summary>
    ''' Función que busca el CÓDIGO para que no se 
    ''' guarden registros duplicados.
    ''' </summary>
    Public Function fun_Buscar_CODIGO_X_MUTAARCH(ByVal inMUARSECU As Integer, ByVal stMUARNUDO As String) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MUTAARCH "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "MUARSECU = '" & CInt(inMUARSECU) & "' and "
            stConsultaSQL += "MUARNUDO = '" & CStr(Trim(stMUARNUDO)) & "' "

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
