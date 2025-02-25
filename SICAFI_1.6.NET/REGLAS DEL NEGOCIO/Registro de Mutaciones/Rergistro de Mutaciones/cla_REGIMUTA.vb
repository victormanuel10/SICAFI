Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration
Imports DATOS

Public Class cla_REGIMUTA

    '====================================
    '*** CLASE REGISTRO DE MUTACIONES ***
    '====================================

    ''' <summary>
    ''' procedimiento que verifica la llave primaria.
    ''' </summary>
    Public Function fun_Verifica_llave_Primaria_REGIMUTA(ByVal obREMUVIGE As Object, _
                                                         ByVal obREMUMES As Object) As Boolean

        Try
            Dim boRespuesta As Boolean = False

            Dim obVerifica As New cla_Verificar_Dato

            If obVerifica.fun_Verificar_Campo_Lleno(obREMUVIGE.SelectedValue) = True And _
                obVerifica.fun_Verificar_Campo_Lleno(obREMUMES.SelectedValue) = True Then

                If obVerifica.fun_Verificar_Dato_Numerico(obREMUVIGE.SelectedValue) = True And _
                    obVerifica.fun_Verificar_Dato_Numerico(obREMUMES.SelectedValue) = True Then

                    Dim objdatos1 As New cla_REGIMUTA
                    Dim tbl As New DataTable

                    tbl = objdatos1.fun_Buscar_CODIGO_X_REGIMUTA(obREMUVIGE.SelectedValue, obREMUMES.SelectedValue)

                    If tbl.Rows.Count > 0 Then
                        MessageBox.Show("El registro existe en la base de datos.", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1)
                        obREMUVIGE.Focus()
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
    Public Function fun_Insertar_REGIMUTA(ByVal inREMUSECU As Integer, _
                                          ByVal inREMUVIGE As Integer, _
                                          ByVal inREMUMES As Integer, _
                                          ByVal stREMUFEAS As String, _
                                          ByVal stREMUFEFI As String, _
                                          ByVal stREMUNUDO As String, _
                                          ByVal stREMUUSUA As String, _
                                          ByVal stREMUESTA As String, _
                                          ByVal inREMUNUPR As Integer, _
                                          ByVal inREMUNUAR As Integer, _
                                          ByVal stREMUOBSE As String) As Boolean


        Try

            ' variables 
            Dim daREMUFEIN As Date = fun_fecha()

            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "INSERT INTO "
            stConsultaSQL += "REGIMUTA "

            stConsultaSQL += "( "
            stConsultaSQL += "REMUSECU, "
            stConsultaSQL += "REMUVIGE, "
            stConsultaSQL += "REMUMES, "
            stConsultaSQL += "REMUFEIN, "
            stConsultaSQL += "REMUFEAS, "
            stConsultaSQL += "REMUFEFI, "
            stConsultaSQL += "REMUNUDO, "
            stConsultaSQL += "REMUUSUA, "
            stConsultaSQL += "REMUESTA, "
            stConsultaSQL += "REMUNUPR, "
            stConsultaSQL += "REMUNUAR, "
            stConsultaSQL += "REMUOBSE "
            stConsultaSQL += ") "

            stConsultaSQL += "VALUES "

            stConsultaSQL += "( "
            stConsultaSQL += "'" & CInt(inREMUSECU) & "', "
            stConsultaSQL += "'" & CInt(inREMUVIGE) & "', "
            stConsultaSQL += "'" & CInt(inREMUMES) & "', "
            stConsultaSQL += "'" & CDate(daREMUFEIN) & "', "
            stConsultaSQL += "'" & CStr(Trim(stREMUFEAS)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stREMUFEFI)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stREMUNUDO)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stREMUUSUA)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stREMUESTA)) & "', "
            stConsultaSQL += "'" & CInt(inREMUNUPR) & "', "
            stConsultaSQL += "'" & CInt(inREMUNUAR) & "', "
            stConsultaSQL += "'" & CStr(Trim(stREMUOBSE)) & "' "
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
            MessageBox.Show(Err.Description & " " & "fun_Insertar_REGIMUTA")
        End Try

    End Function

    ''' <summary>
    ''' Función que Elimina el registro.
    ''' </summary>
    Public Function fun_Eliminar_IDRE_REGIMUTA(ByVal inREMUIDRE As Integer) As Boolean

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "DELETE "
            stConsultaSQL += "REGIMUTA "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "REMUIDRE = '" & CInt(inREMUIDRE) & "' "

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
            MessageBox.Show(Err.Description & " " & "fun_Eliminar_REGIMUTA")
        End Try

    End Function

    ''' <summary>
    ''' Función que Elimina el registro.
    ''' </summary>
    Public Function fun_Eliminar_SECU_REGIMUTA(ByVal inREMUSECU As Integer) As Boolean

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "DELETE "
            stConsultaSQL += "REGIMUTA "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "REMUSECU = '" & CInt(inREMUSECU) & "' "

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
            MessageBox.Show(Err.Description & " " & "fun_Eliminar_REGIMUTA")
        End Try

    End Function

    ''' <summary>
    ''' Función que Modifica el registro.
    ''' </summary>
    Public Function fun_Actualizar_REGIMUTA(ByVal inREMUIDRE As Integer, _
                                            ByVal inREMUSECU As Integer, _
                                            ByVal inREMUVIGE As Integer, _
                                            ByVal inREMUMES As Integer, _
                                            ByVal stREMUFEAS As String, _
                                            ByVal stREMUFEFI As String, _
                                            ByVal stREMUNUDO As String, _
                                            ByVal stREMUUSUA As String, _
                                            ByVal stREMUESTA As String, _
                                            ByVal inREMUNUPR As Integer, _
                                            ByVal inREMUNUAR As Integer, _
                                            ByVal stREMUOBSE As String) As Boolean

        Try

            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "UPDATE "
            stConsultaSQL += "REGIMUTA "

            stConsultaSQL += "SET "
            stConsultaSQL += "REMUSECU = '" & CInt(inREMUSECU) & "', "
            stConsultaSQL += "REMUVIGE = '" & CInt(inREMUVIGE) & "', "
            stConsultaSQL += "REMUMES = '" & CInt(inREMUMES) & "', "
            stConsultaSQL += "REMUFEAS = '" & CStr(Trim(stREMUFEAS)) & "', "
            stConsultaSQL += "REMUFEFI = '" & CStr(Trim(stREMUFEFI)) & "', "
            stConsultaSQL += "REMUNUDO = '" & CStr(Trim(stREMUNUDO)) & "', "
            stConsultaSQL += "REMUUSUA = '" & CStr(Trim(stREMUUSUA)) & "', "
            stConsultaSQL += "REMUESTA = '" & CStr(Trim(stREMUESTA)) & "', "
            stConsultaSQL += "REMUNUPR = '" & CInt(inREMUNUPR) & "', "
            stConsultaSQL += "REMUNUAR = '" & CInt(inREMUNUAR) & "', "
            stConsultaSQL += "REMUOBSE = '" & CStr(Trim(stREMUOBSE)) & "' "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "REMUIDRE = '" & CInt(inREMUIDRE) & "'"

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
            MessageBox.Show(Err.Description & " " & "fun_Actualizar_REGIMUTA")
        End Try

    End Function

    ''' <summary>
    ''' Función que Modifica el registro.
    ''' </summary>
    Public Function fun_Actualizar_NUPR_X_REGIMUTA(ByVal inREMUIDRE As Integer, _
                                                   ByVal inREMUNUPR As Integer) As Boolean

        Try

            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "UPDATE "
            stConsultaSQL += "REGIMUTA "

            stConsultaSQL += "SET "
            stConsultaSQL += "REMUNUPR = '" & CInt(inREMUNUPR) & "' "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "REMUIDRE = '" & CInt(inREMUIDRE) & "' "

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
            MessageBox.Show(Err.Description & " " & "fun_Actualizar_REGIMUTA")
        End Try

    End Function

    ''' <summary>
    ''' Función que Modifica el registro.
    ''' </summary>
    Public Function fun_Actualizar_NUAR_X_REGIMUTA(ByVal inREMUIDRE As Integer, _
                                                   ByVal inREMUNUAR As Integer) As Boolean

        Try

            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "UPDATE "
            stConsultaSQL += "REGIMUTA "

            stConsultaSQL += "SET "
            stConsultaSQL += "REMUNUAR = '" & CInt(inREMUNUAR) & "' "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "REMUIDRE = '" & CInt(inREMUIDRE) & "' "

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
            MessageBox.Show(Err.Description & " " & "fun_Actualizar_REGIMUTA")
        End Try

    End Function

    ''' <summary>
    ''' Consulta para llenar el DataGridView y colocar el nombre del encabezado
    ''' de la columna. 
    ''' </summary>
    Public Function fun_Consultar_REGIMUTA() As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "REMUIDRE, "
            stConsultaSQL += "REMUSECU, "
            stConsultaSQL += "REMUVIGE, "
            stConsultaSQL += "REMUMES, "
            stConsultaSQL += "PERIDESC, "
            stConsultaSQL += "REMUFEIN, "
            stConsultaSQL += "REMUFEAS, "
            stConsultaSQL += "REMUFEFI, "
            stConsultaSQL += "REMUNUDO, "
            stConsultaSQL += "REMUUSUA, "
            stConsultaSQL += "ESTADESC, "
            stConsultaSQL += "REMUNUPR, "
            stConsultaSQL += "REMUNUAR, "
            stConsultaSQL += "REMUOBSE "

            stConsultaSQL += "FROM "
            stConsultaSQL += "REGIMUTA, ESTADO, MANT_PERIODO "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "REMUESTA = ESTACODI AND "
            stConsultaSQL += "REMUVIGE = PERIVIGE AND "
            stConsultaSQL += "REMUMES  = PERIMES "

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "REMUVIGE, REMUMES "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Consultar_REGIMUTA")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Llena el ComboBox con datos activos e inactivos formulario principal 
    ''' esta funcion se llama desde el procedimiento "pro_inicializarControles()".
    ''' </summary>
    Public Function fun_Consultar_CAMPOS_REGIMUTA() As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "REGIMUTA "

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "REMUVIGE, REMUMES "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Consultar_CAMPOS_REGIMUTA")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Llena el ComboBox con datos activos formulario insertar y modificar 
    ''' esta funcion se llama desde el procedimiento "pro_inicializarControles()".
    ''' </summary>
    Public Function fun_Consultar_REGIMUTA_X_ESTADO() As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "REGIMUTA "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "REMUESTA = 'ac' "

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "REMUVIGE, REMUMES "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Consultar_REGIMUTA_X_ESTADO")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que busca el ID del registro a modificar o eliminar.
    ''' </summary>
    Public Function fun_Buscar_ID_REGIMUTA(ByVal inREMUIDRE As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "REGIMUTA "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "REMUIDRE = '" & CInt(inREMUIDRE) & "'"

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Buscar_ID_REGIMUTA")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que busca el ID del registro a modificar o eliminar.
    ''' </summary>
    Public Function fun_Buscar_CODIGO_X_REGIMUTA(ByVal inREMUVIGE As Integer, _
                                                 ByVal inREMUMES As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "REGIMUTA "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "REMUVIGE = '" & CInt(inREMUVIGE) & "'AND  "
            stConsultaSQL += "REMUMES = '" & CInt(inREMUMES) & "' "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Buscar_ID_REGIMUTA")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que busca el CÓDIGO para que no se 
    ''' guarden registros duplicados.
    ''' </summary>
    Public Function fun_Buscar_CODIGO_X_REGIMUTA(ByVal inREMUSECU As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "REGIMUTA "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "REMUSECU = '" & CInt(inREMUSECU) & "' "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Buscar_CODIGO_REGIMUTA")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que busca el ID del codigo buscado para ejecutar la consulta
    ''' parametrizada.
    ''' </summary>
    Public Function fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_REGIMUTA(ByVal inREMUIDRE As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "REMUIDRE, "
            stConsultaSQL += "REMUSECU, "
            stConsultaSQL += "REMUVIGE, "
            stConsultaSQL += "REMUMES, "
            stConsultaSQL += "PERIDESC, "
            stConsultaSQL += "REMUFEIN, "
            stConsultaSQL += "REMUFEAS, "
            stConsultaSQL += "REMUFEFI, "
            stConsultaSQL += "REMUNUDO, "
            stConsultaSQL += "REMUUSUA, "
            stConsultaSQL += "ESTADESC, "
            stConsultaSQL += "REMUNUPR, "
            stConsultaSQL += "REMUNUAR, "
            stConsultaSQL += "REMUOBSE "

            stConsultaSQL += "FROM "
            stConsultaSQL += "REGIMUTA, ESTADO, MANT_PERIODO "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "REMUESTA = ESTACODI AND "
            stConsultaSQL += "REMUVIGE = PERIVIGE AND "
            stConsultaSQL += "REMUMES  = PERIMES AND "
            stConsultaSQL += "REMUIDRE = '" & CInt(inREMUIDRE) & "'"

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "REMUVIGE, REMUMES "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception

            MessageBox.Show(Err.Description & " " & "fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_REGIMUTA")
            Return Nothing

        End Try

    End Function

    ''' <summary>
    ''' Función que busca la secuencia maxima
    ''' </summary>
    Public Function fun_Buscar_SECUENCIA_X_REGIMUTA() As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "REMUSECU "

            stConsultaSQL += "FROM "
            stConsultaSQL += "REGIMUTA "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Buscar_SECUENCIA_MAXINA_X_REGIMUTA")
            Return Nothing
        End Try

    End Function

End Class
