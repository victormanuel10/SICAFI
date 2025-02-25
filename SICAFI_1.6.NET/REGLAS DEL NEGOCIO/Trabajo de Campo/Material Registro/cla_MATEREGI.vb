Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration
Imports DATOS

Public Class cla_MATEREGI

    '==================================
    '*** CLASE MATERIAL DE REGISTRO ***
    '==================================

    ''' <summary>
    ''' procedimiento que verifica la llave primaria.
    ''' </summary>
    Public Function fun_Verifica_llave_Primaria_MATEREGI(ByVal obMARESECU As Object, ByVal obMAREMACA As Object) As Boolean

        Try
            Dim boRespuesta As Boolean = False

            Dim obVerifica As New cla_Verificar_Dato

            If obVerifica.fun_Verificar_Campo_Lleno(obMARESECU.Text) = True And _
                obVerifica.fun_Verificar_Campo_Lleno(obMAREMACA.Text) = True Then

                If obVerifica.fun_Verificar_Dato_Numerico(obMARESECU.Text) = True And _
                   obVerifica.fun_Verificar_Dato_Numerico(obMAREMACA.Text) = True Then

                    Dim objdatos1 As New cla_MATEREGI
                    Dim tbl As New DataTable

                    tbl = objdatos1.fun_Buscar_CODIGO_X_MATEREGI(obMARESECU.Text, obMAREMACA.Text)

                    If tbl.Rows.Count > 0 Then
                        MessageBox.Show("El dato " & Trim(obMARESECU.Text) & " - " & Trim(obMAREMACA.Text) & " existe en la base de datos, se incrementara una secuencia, favor guardar.", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                        obMARESECU.Focus()
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
    Public Function fun_Insertar_MATEREGI(ByVal inMARESECU As Integer, _
                                          ByVal inMAREMACA As Integer, _
                                          ByVal stMAREFECH As String, _
                                          ByVal stMAREOBSE As String) As Boolean

        Try

            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "INSERT INTO "
            stConsultaSQL += "MATEREGI "

            stConsultaSQL += "( "
            stConsultaSQL += "MARESECU, "
            stConsultaSQL += "MAREMACA, "
            stConsultaSQL += "MAREFECH, "
            stConsultaSQL += "MAREOBSE "
            stConsultaSQL += ") "

            stConsultaSQL += "VALUES "

            stConsultaSQL += "( "
            stConsultaSQL += "'" & CInt(inMARESECU) & "', "
            stConsultaSQL += "'" & CInt(inMAREMACA) & "', "
            stConsultaSQL += "'" & CStr(Trim(stMAREFECH)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stMAREOBSE)) & "' "
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
            MessageBox.Show(Err.Description & " " & "fun_Insertar_MATEREGI")
        End Try

    End Function

    ''' <summary>
    ''' Función que Elimina el registro.
    ''' </summary>
    Public Function fun_Eliminar_IDRE_MATEREGI(ByVal inMAREIDRE As Integer) As Boolean

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "DELETE "
            stConsultaSQL += "MATEREGI "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "MAREIDRE = '" & CInt(inMAREIDRE) & "' "

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
            MessageBox.Show(Err.Description & " " & "fun_Eliminar_IDRE_MATEREGI")
        End Try

    End Function

    ''' <summary>
    ''' Función que Elimina el registro.
    ''' </summary>
    Public Function fun_Eliminar_SECU_X_MACA_MATEREGI(ByVal inMARESECU As Integer, ByVal inMAREMACA As Integer) As Boolean

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "DELETE "
            stConsultaSQL += "MATEREGI "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "MARESECU = '" & CInt(inMARESECU) & "' and "
            stConsultaSQL += "MAREMACA = '" & CInt(inMAREMACA) & "' "

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
            MessageBox.Show(Err.Description & " " & "fun_Eliminar_SECU_X_MACA_MATEREGI")
        End Try

    End Function

    ''' <summary>
    ''' Función que Elimina el registro.
    ''' </summary>
    Public Function fun_Eliminar_SECU_MATEREGI(ByVal inMARESECU As Integer) As Boolean

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "DELETE "
            stConsultaSQL += "MATEREGI "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "MARESECU = '" & CInt(inMARESECU) & "' "

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
            MessageBox.Show(Err.Description & " " & "fun_Eliminar_IDRE_MATEREGI")
        End Try

    End Function

    ''' <summary>
    ''' Función que Modifica el registro.
    ''' </summary>
    Public Function fun_Actualizar_MATEREGI(ByVal inMAREIDRE As Integer, _
                                            ByVal inMARESECU As Integer, _
                                            ByVal inMAREMACA As Integer, _
                                            ByVal stMAREFECH As String, _
                                            ByVal stMAREOBSE As String) As Boolean

        Try

            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "UPDATE "
            stConsultaSQL += "MATEREGI "

            stConsultaSQL += "SET "
            stConsultaSQL += "MARESECU = '" & CInt(inMARESECU) & "', "
            stConsultaSQL += "MAREMACA = '" & CInt(inMAREMACA) & "', "
            stConsultaSQL += "MAREFECH = '" & CStr(Trim(stMAREFECH)) & "', "
            stConsultaSQL += "MAREOBSE = '" & CStr(Trim(stMAREOBSE)) & "' "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "MAREIDRE = '" & CInt(inMAREIDRE) & "' "

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
            MessageBox.Show(Err.Description & " " & "fun_Actualizar_MATEREGI")
        End Try

    End Function

    ''' <summary>
    ''' Consulta para llenar el DataGridView y colocar el nombre del encabezado
    ''' de la columna. 
    ''' </summary>
    Public Function fun_Consultar_MATEREGI() As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "MAREIDRE, "
            stConsultaSQL += "MARESECU, "
            stConsultaSQL += "MAREMACA, "
            stConsultaSQL += "MACADESC, "
            stConsultaSQL += "MAREFECH, "
            stConsultaSQL += "MAREOBSE "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MATEREGI, MANT_MATECAMP "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "MACACODI = MAREMACA "

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "MAREMACA "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Consultar_MATEREGI")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que busca el ID del codigo buscado para ejecutar la consulta
    ''' parametrizada.
    ''' </summary>
    Public Function fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_MATEREGI(ByVal inMARESECU As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "MAREIDRE, "
            stConsultaSQL += "MARESECU, "
            stConsultaSQL += "MAREMACA, "
            stConsultaSQL += "MACADESC, "
            stConsultaSQL += "MAREFECH, "
            stConsultaSQL += "MAREOBSE "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MATEREGI, MANT_MATECAMP "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "MACACODI = MAREMACA and "
            stConsultaSQL += "MARESECU = '" & CInt(inMARESECU) & "'"

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "MAREMACA "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception

            MessageBox.Show(Err.Description & " " & "fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_MATEREGI")
            Return Nothing

        End Try

    End Function

    ''' <summary>
    ''' Función que busca el CÓDIGO para que no se 
    ''' guarden registros duplicados.
    ''' </summary>
    Public Function fun_Buscar_CODIGO_X_MATEREGI(ByVal inMARESECU As Integer, ByVal inMAREMACA As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MATEREGI "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "MARESECU = '" & CInt(inMARESECU) & "' and "
            stConsultaSQL += "MAREMACA = '" & CInt(inMAREMACA) & "' "

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
