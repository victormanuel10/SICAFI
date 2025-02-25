Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration
Imports DATOS

Public Class cla_RELIPERM

    ''' <summary>
    ''' procedimiento que verifica la llave primaria.
    ''' </summary>
    Public Function fun_Verifica_llave_Primaria_RELIPERM(ByVal inRLPESECU As Integer, _
                                                         ByVal stRLPENUDO As String) As Boolean

        Try
            Dim boRespuesta As Boolean = False

            Dim obVerifica As New cla_Verificar_Dato

            If obVerifica.fun_Verificar_Campo_Lleno(inRLPESECU) = True And _
                obVerifica.fun_Verificar_Campo_Lleno(stRLPENUDO) = True Then

                If obVerifica.fun_Verificar_Dato_Numerico(inRLPESECU) = True Then

                    Dim objdatos1 As New cla_RELIPERM
                    Dim tbl As New DataTable

                    tbl = objdatos1.fun_Buscar_CODIGO_X_RELIPERM(inRLPESECU, stRLPENUDO)

                    If tbl.Rows.Count > 0 Then
                        MessageBox.Show("El dato " & Trim(inRLPESECU) & " - " & Trim(stRLPENUDO) & " existe en la base de datos.", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
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
    Public Function fun_Insertar_RELIPERM(ByVal inRLPESECU As Integer, _
                                          ByVal inRLPENURA As Integer, _
                                          ByVal stRLPEFERA As String, _
                                          ByVal stRLPENUDO As String, _
                                          ByVal stRLPEUSUA As String, _
                                          ByVal stRLPEOBSE As String) As Boolean

        Try
            ' almacena la fecha
            Dim daRELIFEIN As Date = fun_fecha()

            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "INSERT INTO "
            stConsultaSQL += "RELIPERM "

            stConsultaSQL += "( "
            stConsultaSQL += "RLPESECU, "
            stConsultaSQL += "RLPENURA, "
            stConsultaSQL += "RLPEFERA, "
            stConsultaSQL += "RLPENUDO, "
            stConsultaSQL += "RLPEUSUA, "
            stConsultaSQL += "RLPEFEIN, "
            stConsultaSQL += "RLPEOBSE "
            stConsultaSQL += ") "

            stConsultaSQL += "VALUES "

            stConsultaSQL += "( "
            stConsultaSQL += "'" & CInt(inRLPESECU) & "', "
            stConsultaSQL += "'" & CInt(inRLPENURA) & "', "
            stConsultaSQL += "'" & CStr(Trim(stRLPEFERA)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stRLPENUDO)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stRLPEUSUA)) & "', "
            stConsultaSQL += "'" & CDate(daRELIFEIN) & "', "
            stConsultaSQL += "'" & CStr(Trim(stRLPEOBSE)) & "' "
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
            MessageBox.Show(Err.Description & " " & "fun_Insertar_RELIPERM")
        End Try

    End Function

    ''' <summary>
    ''' Función que Elimina el registro.
    ''' </summary>
    Public Function fun_Eliminar_IDRE_RELIPERM(ByVal inRLPEIDRE As Integer) As Boolean

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "DELETE "
            stConsultaSQL += "RELIPERM "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "RLPEIDRE = '" & CInt(inRLPEIDRE) & "' "

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
            MessageBox.Show(Err.Description & " " & "fun_Eliminar_IDRE_RELIPERM")
        End Try

    End Function

    ''' <summary>
    ''' Función que Elimina el registro.
    ''' </summary>
    Public Function fun_Eliminar_SECU_X_NUDO_RELIPERM(ByVal inRLPESECU As Integer, ByVal stRLPENUDO As String) As Boolean

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "DELETE "
            stConsultaSQL += "RELIPERM "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "RLPESECU = '" & CInt(inRLPESECU) & "' and "
            stConsultaSQL += "RLPENUDO = '" & CStr(Trim(stRLPENUDO)) & "' "

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
            MessageBox.Show(Err.Description & " " & "fun_Eliminar_SECU_X_MACA_RELIPERM")
        End Try

    End Function

    ''' <summary>
    ''' Función que Elimina el registro.
    ''' </summary>
    Public Function fun_Eliminar_SECU_RELIPERM(ByVal inRLPESECU As Integer) As Boolean

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "DELETE "
            stConsultaSQL += "RELIPERM "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "RLPESECU = '" & CInt(inRLPESECU) & "' "

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
            MessageBox.Show(Err.Description & " " & "fun_Eliminar_IDRE_RELIPERM")
        End Try

    End Function

    ''' <summary>
    ''' Función que Modifica el registro.
    ''' </summary>
    Public Function fun_Actualizar_RELIPERM(ByVal inRLPEIDRE As Integer, _
                                            ByVal stRLPEOBSE As String) As Boolean

        Try

            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "UPDATE "
            stConsultaSQL += "RELIPERM "

            stConsultaSQL += "SET "
            stConsultaSQL += "RLPEOBSE = '" & CStr(Trim(stRLPEOBSE)) & "' "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "RLPEIDRE = '" & CInt(inRLPEIDRE) & "' "

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
            MessageBox.Show(Err.Description & " " & "fun_Actualizar_RELIPERM")
        End Try

    End Function

    ''' <summary>
    ''' Consulta para llenar el DataGridView y colocar el nombre del encabezado
    ''' de la columna. 
    ''' </summary>
    Public Function fun_Consultar_RELIPERM() As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "RLPEIDRE, "
            stConsultaSQL += "RLPESECU, "
            stConsultaSQL += "RLPENUDO, "
            stConsultaSQL += "USUANOMB, "
            stConsultaSQL += "USUAPRAP, "
            stConsultaSQL += "USUASEAP, "
            stConsultaSQL += "RLPEFEIN, "
            stConsultaSQL += "RLPEOBSE "

            stConsultaSQL += "FROM "
            stConsultaSQL += "RELIPERM, USUARIO "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "RLPENUDO = USUANUDO "

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "RLPEIDRE DESC "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Consultar_RELIPERM")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que busca el ID del codigo buscado para ejecutar la consulta
    ''' parametrizada.
    ''' </summary>
    Public Function fun_Buscar_SECU_X_CONSULTA_PARAMETRIZADA_RELIPERM(ByVal inRLPESECU As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "RLPEIDRE, "
            stConsultaSQL += "RLPESECU, "
            stConsultaSQL += "RLPEUSUA, "
            stConsultaSQL += "RLPENUDO, "
            stConsultaSQL += "USUANOMB, "
            stConsultaSQL += "USUAPRAP, "
            stConsultaSQL += "USUASEAP, "
            stConsultaSQL += "RLPEFEIN, "
            stConsultaSQL += "RLPEOBSE "

            stConsultaSQL += "FROM "
            stConsultaSQL += "RELIPERM, USUARIO "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "RLPENUDO = USUANUDO and "
            stConsultaSQL += "RLPESECU = '" & CInt(inRLPESECU) & "'"

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "RLPEIDRE DESC "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception

            MessageBox.Show(Err.Description & " " & "fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_RELIPERM")
            Return Nothing

        End Try

    End Function

    ''' <summary>
    ''' Función que busca el CÓDIGO para que no se 
    ''' guarden registros duplicados.
    ''' </summary>
    Public Function fun_Buscar_CODIGO_X_RELIPERM(ByVal inRLPESECU As Integer, ByVal stRLPENUDO As String) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "RELIPERM "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "RLPESECU = '" & CInt(inRLPESECU) & "' and "
            stConsultaSQL += "RLPENUDO = '" & CStr(Trim(stRLPENUDO)) & "' "

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
    Public Function fun_Buscar_ID_X_RELIPERM(ByVal inRLPEIDRE As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "RELIPERM "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "RLPEIDRE = '" & CInt(inRLPEIDRE) & "' "

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
