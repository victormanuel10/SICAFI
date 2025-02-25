Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration
Imports DATOS

Public Class cla_MUTAMARE

    '==================================
    '*** CLASE MATERIAL DE REGISTRO ***
    '==================================

    ''' <summary>
    ''' procedimiento que verifica la llave primaria.
    ''' </summary>
    Public Function fun_Verifica_llave_Primaria_MUTAMARE(ByVal obMUMRSECU As Object, ByVal obMUMRMACA As Object) As Boolean

        Try
            Dim boRespuesta As Boolean = False

            Dim obVerifica As New cla_Verificar_Dato

            If obVerifica.fun_Verificar_Campo_Lleno(obMUMRSECU.Text) = True And _
                obVerifica.fun_Verificar_Campo_Lleno(obMUMRMACA.Text) = True Then

                If obVerifica.fun_Verificar_Dato_Numerico(obMUMRSECU.Text) = True And _
                   obVerifica.fun_Verificar_Dato_Numerico(obMUMRMACA.Text) = True Then

                    Dim objdatos1 As New cla_MUTAMARE
                    Dim tbl As New DataTable

                    tbl = objdatos1.fun_Buscar_CODIGO_X_MUTAMARE(obMUMRSECU.Text, obMUMRMACA.Text)

                    If tbl.Rows.Count > 0 Then
                        MessageBox.Show("El dato " & Trim(obMUMRSECU.Text) & " - " & Trim(obMUMRMACA.Text) & " existe en la base de datos, se incrementara una secuencia, favor guardar.", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                        obMUMRSECU.Focus()
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
    Public Function fun_Insertar_MUTAMARE(ByVal inMUMRSECU As Integer, _
                                          ByVal inMUMRMACA As Integer, _
                                          ByVal stMUMRFECH As String, _
                                          ByVal stMUMROBSE As String) As Boolean

        Try

            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "INSERT INTO "
            stConsultaSQL += "MUTAMARE "

            stConsultaSQL += "( "
            stConsultaSQL += "MUMRSECU, "
            stConsultaSQL += "MUMRMACA, "
            stConsultaSQL += "MUMRFECH, "
            stConsultaSQL += "MUMROBSE "
            stConsultaSQL += ") "

            stConsultaSQL += "VALUES "

            stConsultaSQL += "( "
            stConsultaSQL += "'" & CInt(inMUMRSECU) & "', "
            stConsultaSQL += "'" & CInt(inMUMRMACA) & "', "
            stConsultaSQL += "'" & CStr(Trim(stMUMRFECH)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stMUMROBSE)) & "' "
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
            MessageBox.Show(Err.Description & " " & "fun_Insertar_MUTAMARE")
        End Try

    End Function

    ''' <summary>
    ''' Función que Elimina el registro.
    ''' </summary>
    Public Function fun_Eliminar_IDRE_MUTAMARE(ByVal inMUMRIDRE As Integer) As Boolean

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "DELETE "
            stConsultaSQL += "MUTAMARE "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "MUMRIDRE = '" & CInt(inMUMRIDRE) & "' "

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
            MessageBox.Show(Err.Description & " " & "fun_Eliminar_IDRE_MUTAMARE")
        End Try

    End Function

    ''' <summary>
    ''' Función que Elimina el registro.
    ''' </summary>
    Public Function fun_Eliminar_SECU_X_MACA_MUTAMARE(ByVal inMUMRSECU As Integer, ByVal inMUMRMACA As Integer) As Boolean

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "DELETE "
            stConsultaSQL += "MUTAMARE "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "MUMRSECU = '" & CInt(inMUMRSECU) & "' and "
            stConsultaSQL += "MUMRMACA = '" & CInt(inMUMRMACA) & "' "

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
            MessageBox.Show(Err.Description & " " & "fun_Eliminar_SECU_X_MACA_MUTAMARE")
        End Try

    End Function

    ''' <summary>
    ''' Función que Elimina el registro.
    ''' </summary>
    Public Function fun_Eliminar_SECU_MUTAMARE(ByVal inMUMRSECU As Integer) As Boolean

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "DELETE "
            stConsultaSQL += "MUTAMARE "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "MUMRSECU = '" & CInt(inMUMRSECU) & "' "

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
            MessageBox.Show(Err.Description & " " & "fun_Eliminar_IDRE_MUTAMARE")
        End Try

    End Function

    ''' <summary>
    ''' Función que Modifica el registro.
    ''' </summary>
    Public Function fun_Actualizar_MUTAMARE(ByVal inMUMRIDRE As Integer, _
                                            ByVal inMUMRSECU As Integer, _
                                            ByVal inMUMRMACA As Integer, _
                                            ByVal stMUMRFECH As String, _
                                            ByVal stMUMROBSE As String) As Boolean

        Try

            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "UPDATE "
            stConsultaSQL += "MUTAMARE "

            stConsultaSQL += "SET "
            stConsultaSQL += "MUMRSECU = '" & CInt(inMUMRSECU) & "', "
            stConsultaSQL += "MUMRMACA = '" & CInt(inMUMRMACA) & "', "
            stConsultaSQL += "MUMRFECH = '" & CStr(Trim(stMUMRFECH)) & "', "
            stConsultaSQL += "MUMROBSE = '" & CStr(Trim(stMUMROBSE)) & "' "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "MUMRIDRE = '" & CInt(inMUMRIDRE) & "' "

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
            MessageBox.Show(Err.Description & " " & "fun_Actualizar_MUTAMARE")
        End Try

    End Function

    ''' <summary>
    ''' Consulta para llenar el DataGridView y colocar el nombre del encabezado
    ''' de la columna. 
    ''' </summary>
    Public Function fun_Consultar_MUTAMARE() As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "MUMRIDRE, "
            stConsultaSQL += "MUMRSECU, "
            stConsultaSQL += "MUMRMACA, "
            stConsultaSQL += "MACADESC, "
            stConsultaSQL += "MUMRFECH, "
            stConsultaSQL += "MUMROBSE "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MUTAMARE, MANT_MATECAMP "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "MACACODI = MUMRMACA "

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "MUMRMACA "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Consultar_MUTAMARE")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que busca el ID del codigo buscado para ejecutar la consulta
    ''' parametrizada.
    ''' </summary>
    Public Function fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_MUTAMARE(ByVal inMUMRSECU As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "MUMRIDRE, "
            stConsultaSQL += "MUMRSECU, "
            stConsultaSQL += "MUMRMACA, "
            stConsultaSQL += "MACADESC, "
            stConsultaSQL += "MUMRFECH, "
            stConsultaSQL += "MUMROBSE "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MUTAMARE, MANT_MATECAMP "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "MACACODI = MUMRMACA and "
            stConsultaSQL += "MUMRSECU = '" & CInt(inMUMRSECU) & "'"

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "MUMRMACA "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception

            MessageBox.Show(Err.Description & " " & "fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_MUTAMARE")
            Return Nothing

        End Try

    End Function

    ''' <summary>
    ''' Función que busca el CÓDIGO para que no se 
    ''' guarden registros duplicados.
    ''' </summary>
    Public Function fun_Buscar_CODIGO_X_MUTAMARE(ByVal inMUMRSECU As Integer, ByVal inMUMRMACA As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MUTAMARE "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "MUMRSECU = '" & CInt(inMUMRSECU) & "' and "
            stConsultaSQL += "MUMRMACA = '" & CInt(inMUMRMACA) & "' "

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
