Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration
Imports DATOS

Public Class cla_MATEUSUA

    '=================================
    '*** CLASE MATERIAL DE USUARIO ***
    '=================================

    ''' <summary>
    ''' procedimiento que verifica la llave primaria.
    ''' </summary>
    Public Function fun_Verifica_llave_Primaria_MATEUSUA(ByVal obMAUSSECU As Object, ByVal obMAUSMACA As Object) As Boolean

        Try
            Dim boRespuesta As Boolean = False

            Dim obVerifica As New cla_Verificar_Dato

            If obVerifica.fun_Verificar_Campo_Lleno(obMAUSSECU.Text) = True And _
                obVerifica.fun_Verificar_Campo_Lleno(obMAUSMACA.Text) = True Then

                If obVerifica.fun_Verificar_Dato_Numerico(obMAUSSECU.Text) = True And _
                   obVerifica.fun_Verificar_Dato_Numerico(obMAUSMACA.Text) = True Then

                    Dim objdatos1 As New cla_MATEUSUA
                    Dim tbl As New DataTable

                    tbl = objdatos1.fun_Buscar_CODIGO_X_MATEUSUA(obMAUSSECU.Text, obMAUSMACA.Text)

                    If tbl.Rows.Count > 0 Then
                        MessageBox.Show("El dato " & Trim(obMAUSSECU.Text) & " - " & Trim(obMAUSMACA.Text) & " existe en la base de datos, se incrementara una secuencia, favor guardar.", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                        obMAUSSECU.Focus()
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
    Public Function fun_Insertar_MATEUSUA(ByVal inMAUSSECU As Integer, _
                                          ByVal inMAUSMACA As Integer, _
                                          ByVal stMAUSFECH As String, _
                                          ByVal stMAUSOBSE As String) As Boolean

        Try

            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "INSERT INTO "
            stConsultaSQL += "MATEUSUA "

            stConsultaSQL += "( "
            stConsultaSQL += "MAUSSECU, "
            stConsultaSQL += "MAUSMACA, "
            stConsultaSQL += "MAUSFECH, "
            stConsultaSQL += "MAUSOBSE "
            stConsultaSQL += ") "

            stConsultaSQL += "VALUES "

            stConsultaSQL += "( "
            stConsultaSQL += "'" & CInt(inMAUSSECU) & "', "
            stConsultaSQL += "'" & CInt(inMAUSMACA) & "', "
            stConsultaSQL += "'" & CStr(Trim(stMAUSFECH)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stMAUSOBSE)) & "' "
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
            MessageBox.Show(Err.Description & " " & "fun_Insertar_MATEUSUA")
        End Try

    End Function

    ''' <summary>
    ''' Función que Elimina el registro.
    ''' </summary>
    Public Function fun_Eliminar_IDRE_MATEUSUA(ByVal inMAUSIDRE As Integer) As Boolean

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "DELETE "
            stConsultaSQL += "MATEUSUA "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "MAUSIDRE = '" & CInt(inMAUSIDRE) & "' "

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
            MessageBox.Show(Err.Description & " " & "fun_Eliminar_IDRE_MATEUSUA")
        End Try

    End Function

    ''' <summary>
    ''' Función que Elimina el registro.
    ''' </summary>
    Public Function fun_Eliminar_SECU_X_MACA_MATEUSUA(ByVal inMAUSSECU As Integer, ByVal inMAUSMACA As Integer) As Boolean

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "DELETE "
            stConsultaSQL += "MATEUSUA "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "MAUSSECU = '" & CInt(inMAUSSECU) & "' and "
            stConsultaSQL += "MAUSMACA = '" & CInt(inMAUSMACA) & "' "

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
            MessageBox.Show(Err.Description & " " & "fun_Eliminar_SECU_X_MACA_MATEUSUA")
        End Try

    End Function

    ''' <summary>
    ''' Función que Elimina el registro.
    ''' </summary>
    Public Function fun_Eliminar_SECU_MATEUSUA(ByVal inMAUSSECU As Integer) As Boolean

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "DELETE "
            stConsultaSQL += "MATEUSUA "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "MAUSSECU = '" & CInt(inMAUSSECU) & "' "

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
            MessageBox.Show(Err.Description & " " & "fun_Eliminar_IDRE_MATEUSUA")
        End Try

    End Function

    ''' <summary>
    ''' Función que Modifica el registro.
    ''' </summary>
    Public Function fun_Actualizar_MATEUSUA(ByVal inMAUSIDRE As Integer, _
                                            ByVal inMAUSSECU As Integer, _
                                            ByVal inMAUSMACA As Integer, _
                                            ByVal stMAUSFECH As String, _
                                            ByVal stMAUSOBSE As String) As Boolean

        Try

            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "UPDATE "
            stConsultaSQL += "MATEUSUA "

            stConsultaSQL += "SET "
            stConsultaSQL += "MAUSSECU = '" & CInt(inMAUSSECU) & "', "
            stConsultaSQL += "MAUSMACA = '" & CInt(inMAUSMACA) & "', "
            stConsultaSQL += "MAUSFECH = '" & CStr(Trim(stMAUSFECH)) & "', "
            stConsultaSQL += "MAUSOBSE = '" & CStr(Trim(inMAUSIDRE)) & "' "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "MAUSIDRE = '" & CInt(inMAUSIDRE) & "' "

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
            MessageBox.Show(Err.Description & " " & "fun_Actualizar_MATEUSUA")
        End Try

    End Function

    ''' <summary>
    ''' Consulta para llenar el DataGridView y colocar el nombre del encabezado
    ''' de la columna. 
    ''' </summary>
    Public Function fun_Consultar_MATEUSUA() As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "MAUSIDRE, "
            stConsultaSQL += "MAUSSECU, "
            stConsultaSQL += "MAUSMACA, "
            stConsultaSQL += "MACADESC, "
            stConsultaSQL += "MAUSFECH, "
            stConsultaSQL += "MAUSOBSE "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MATEUSUA, MANT_MATECAMP "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "MACACODI = MAUSMACA "

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "MAUSMACA "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Consultar_MATEUSUA")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que busca el ID del codigo buscado para ejecutar la consulta
    ''' parametrizada.
    ''' </summary>
    Public Function fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_MATEUSUA(ByVal inMAUSSECU As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "MAUSIDRE, "
            stConsultaSQL += "MAUSSECU, "
            stConsultaSQL += "MAUSMACA, "
            stConsultaSQL += "MACADESC, "
            stConsultaSQL += "MAUSFECH, "
            stConsultaSQL += "MAUSOBSE "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MATEUSUA, MANT_MATECAMP "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "MACACODI = MAUSMACA and "
            stConsultaSQL += "MAUSSECU = '" & CInt(inMAUSSECU) & "'"

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "MAUSMACA "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception

            MessageBox.Show(Err.Description & " " & "fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_MATEUSUA")
            Return Nothing

        End Try

    End Function

    ''' <summary>
    ''' Función que busca el CÓDIGO para que no se 
    ''' guarden registros duplicados.
    ''' </summary>
    Public Function fun_Buscar_CODIGO_X_MATEUSUA(ByVal inMAUSSECU As Integer, ByVal inMAUSMACA As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MATEUSUA "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "MAUSSECU = '" & CInt(inMAUSSECU) & "' and "
            stConsultaSQL += "MAUSMACA = '" & CInt(inMAUSMACA) & "' "

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
