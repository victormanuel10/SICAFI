Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration
Imports DATOS

Public Class cla_MUTACIONES

    '========================
    '*** CLASE MUTACIONES ***
    '========================

    ''' <summary>
    ''' procedimiento que verifica la llave primaria.
    ''' </summary>
    Public Function fun_Verifica_llave_Primaria_MUTACIONES(ByVal obMUTANUFI As Object, _
                                                           ByVal obMUTAFEES As Object, _
                                                           ByVal obMUTAESCR As Object) As Boolean

        Try
            Dim boRespuesta As Boolean = False

            Dim obVerifica As New cla_Verificar_Dato

            If obVerifica.fun_Verificar_Campo_Lleno(obMUTANUFI.Text) = True And _
                obVerifica.fun_Verificar_Campo_Lleno(obMUTAFEES.Text) = True And _
                obVerifica.fun_Verificar_Campo_Lleno(obMUTAESCR.Text) = True Then

                If obVerifica.fun_Verificar_Dato_Numerico(obMUTANUFI.Text) = True And _
                    obVerifica.fun_Verificar_Dato_Numerico(obMUTAESCR.Text) = True Then

                    Dim objdatos1 As New cla_MUTACIONES
                    Dim tbl As New DataTable

                    tbl = objdatos1.fun_Buscar_CODIGO_X_MUTACIONES(obMUTANUFI.Text, obMUTAFEES.Text, obMUTAESCR.Text)

                    If tbl.Rows.Count > 0 Then
                        MessageBox.Show("El registro existe en la base de datos.", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1)
                        obMUTANUFI.Focus()
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
    Public Function fun_Insertar_MUTACIONES(ByVal inMUTASECU As Integer, _
                                            ByVal inMUTANUFI As Integer, _
                                            ByVal stMUTAMUNI As String, _
                                            ByVal stMUTACORR As String, _
                                            ByVal stMUTABARR As String, _
                                            ByVal stMUTAMANZ As String, _
                                            ByVal stMUTAPRED As String, _
                                            ByVal stMUTAEDIF As String, _
                                            ByVal stMUTAUNPR As String, _
                                            ByVal inMUTACLSE As Integer, _
                                            ByVal inMUTAVIGE As Integer, _
                                            ByVal stMUTAFEES As String, _
                                            ByVal inMUTAESCR As Integer, _
                                            ByVal inMUTANURA As Integer, _
                                            ByVal stMUTAFERA As String, _
                                            ByVal stMUTAOBSE As String, _
                                            ByVal stMUTAESTA As String, _
                                            ByVal stMUTADESC As String, _
                                            ByVal stMUTAMAIN As String, _
                                            ByVal loMUTAVACO As Long, _
                                            ByVal inMUTANURE As Integer, _
                                            ByVal stMUTAFERE As String) As Boolean

        Try

            ' variables 
            Dim stMUTADEPA As String = "05"

            '' *** INSTANCIA LA FECHA Y HORA ***
            Dim daMUTAFEIN As Date = fun_fecha()

            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "INSERT INTO "
            stConsultaSQL += "MUTACIONES "

            stConsultaSQL += "( "
            stConsultaSQL += "MUTASECU, "
            stConsultaSQL += "MUTANUFI, "
            stConsultaSQL += "MUTADEPA, "
            stConsultaSQL += "MUTAMUNI, "
            stConsultaSQL += "MUTACORR, "
            stConsultaSQL += "MUTABARR, "
            stConsultaSQL += "MUTAMANZ, "
            stConsultaSQL += "MUTAPRED, "
            stConsultaSQL += "MUTAEDIF, "
            stConsultaSQL += "MUTAUNPR, "
            stConsultaSQL += "MUTACLSE, "
            stConsultaSQL += "MUTAVIGE, "
            stConsultaSQL += "MUTAFEES, "
            stConsultaSQL += "MUTAESCR, "
            stConsultaSQL += "MUTANURA, "
            stConsultaSQL += "MUTAFERA, "
            stConsultaSQL += "MUTAOBSE, "
            stConsultaSQL += "MUTAESTA, "
            stConsultaSQL += "MUTAFEIN, "
            stConsultaSQL += "MUTADESC, "
            stConsultaSQL += "MUTAMAIN, "
            stConsultaSQL += "MUTAVACO, "
            stConsultaSQL += "MUTANURE, "
            stConsultaSQL += "MUTAFERE "
            stConsultaSQL += ") "

            stConsultaSQL += "VALUES "

            stConsultaSQL += "( "
            stConsultaSQL += "'" & CInt(inMUTASECU) & "', "
            stConsultaSQL += "'" & CInt(inMUTANUFI) & "', "
            stConsultaSQL += "'" & CStr(Trim(stMUTADEPA)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stMUTAMUNI)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stMUTACORR)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stMUTABARR)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stMUTAMANZ)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stMUTAPRED)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stMUTAEDIF)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stMUTAUNPR)) & "', "
            stConsultaSQL += "'" & CInt(inMUTACLSE) & "', "
            stConsultaSQL += "'" & CInt(inMUTAVIGE) & "', "
            stConsultaSQL += "'" & CStr(Trim(stMUTAFEES)) & "', "
            stConsultaSQL += "'" & CInt(inMUTAESCR) & "', "
            stConsultaSQL += "'" & CInt(inMUTANURA) & "', "
            stConsultaSQL += "'" & CStr(Trim(stMUTAFERA)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stMUTAOBSE)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stMUTAESTA)) & "', "
            stConsultaSQL += "'" & CDate(daMUTAFEIN) & "', "
            stConsultaSQL += "'" & CStr(Trim(stMUTADESC)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stMUTAMAIN)) & "', "
            stConsultaSQL += "'" & CLng(loMUTAVACO) & "', "
            stConsultaSQL += "'" & CInt(inMUTANURE) & "', "
            stConsultaSQL += "'" & CStr(Trim(stMUTAFERE)) & "' "
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
            MessageBox.Show(Err.Description & " " & "fun_Insertar_MUTACIONES")
        End Try

    End Function

    ''' <summary>
    ''' Función que Elimina el registro.
    ''' </summary>
    Public Function fun_Eliminar_IDRE_MUTACIONES(ByVal inMUTAIDRE As Integer) As Boolean

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "DELETE "
            stConsultaSQL += "MUTACIONES "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "MUTAIDRE = '" & CInt(inMUTAIDRE) & "' "

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
            MessageBox.Show(Err.Description & " " & "fun_Eliminar_MUTACIONES")
        End Try

    End Function

    ''' <summary>
    ''' Función que Elimina el registro.
    ''' </summary>
    Public Function fun_Eliminar_SECU_MUTACIONES(ByVal inMUTASECU As Integer) As Boolean

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "DELETE "
            stConsultaSQL += "MUTACIONES "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "MUTASECU = '" & CInt(inMUTASECU) & "' "

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
            MessageBox.Show(Err.Description & " " & "fun_Eliminar_MUTACIONES")
        End Try

    End Function

    ''' <summary>
    ''' Función que Modifica el registro.
    ''' </summary>
    Public Function fun_Actualizar_MUTACIONES(ByVal inMUTAIDRE As Integer, _
                                              ByVal inMUTASECU As Integer, _
                                              ByVal inMUTANUFI As Integer, _
                                              ByVal stMUTAMUNI As String, _
                                              ByVal stMUTACORR As String, _
                                              ByVal stMUTABARR As String, _
                                              ByVal stMUTAMANZ As String, _
                                              ByVal stMUTAPRED As String, _
                                              ByVal stMUTAEDIF As String, _
                                              ByVal stMUTAUNPR As String, _
                                              ByVal inMUTACLSE As String, _
                                              ByVal inMUTAVIGE As Integer, _
                                              ByVal stMUTAFEES As String, _
                                              ByVal inMUTAESCR As Integer, _
                                              ByVal inMUTANURA As Integer, _
                                              ByVal stMUTAFERA As String, _
                                              ByVal stMUTAOBSE As String, _
                                              ByVal stMUTAESTA As String, _
                                              ByVal stMUTADESC As String, _
                                              ByVal stMUTAMAIN As String, _
                                              ByVal loMUTAVACO As Long, _
                                              ByVal inMUTANURE As Integer, _
                                              ByVal stMUTAFERE As String) As Boolean

        Try
            ' variables
            Dim stMUTADEPA As String = "05"

            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "UPDATE "
            stConsultaSQL += "MUTACIONES "

            stConsultaSQL += "SET "
            stConsultaSQL += "MUTASECU = '" & CInt(inMUTASECU) & "', "
            stConsultaSQL += "MUTANUFI = '" & CInt(inMUTANUFI) & "', "
            stConsultaSQL += "MUTADEPA = '" & CStr(Trim(stMUTADEPA)) & "', "
            stConsultaSQL += "MUTAMUNI = '" & CStr(Trim(stMUTAMUNI)) & "', "
            stConsultaSQL += "MUTACORR = '" & CStr(Trim(stMUTACORR)) & "', "
            stConsultaSQL += "MUTABARR = '" & CStr(Trim(stMUTABARR)) & "', "
            stConsultaSQL += "MUTAMANZ = '" & CStr(Trim(stMUTAMANZ)) & "', "
            stConsultaSQL += "MUTAPRED = '" & CStr(Trim(stMUTAPRED)) & "', "
            stConsultaSQL += "MUTAEDIF = '" & CStr(Trim(stMUTAEDIF)) & "', "
            stConsultaSQL += "MUTAUNPR = '" & CStr(Trim(stMUTAUNPR)) & "', "
            stConsultaSQL += "MUTACLSE = '" & CInt(inMUTACLSE) & "', "
            stConsultaSQL += "MUTAVIGE = '" & CInt(inMUTAVIGE) & "', "
            stConsultaSQL += "MUTAFEES = '" & CStr(Trim(stMUTAFEES)) & "', "
            stConsultaSQL += "MUTAESCR = '" & CInt(inMUTAESCR) & "', "
            stConsultaSQL += "MUTANURA = '" & CInt(inMUTANURA) & "', "
            stConsultaSQL += "MUTAFERA = '" & CStr(Trim(stMUTAFERA)) & "', "
            stConsultaSQL += "MUTAOBSE = '" & CStr(Trim(stMUTAOBSE)) & "', "
            stConsultaSQL += "MUTAESTA = '" & CStr(Trim(stMUTAESTA)) & "', "
            stConsultaSQL += "MUTADESC = '" & CStr(Trim(stMUTADESC)) & "', "
            stConsultaSQL += "MUTAMAIN = '" & CStr(Trim(stMUTAMAIN)) & "', "
            stConsultaSQL += "MUTAVACO = '" & CLng(loMUTAVACO) & "', "
            stConsultaSQL += "MUTANURE = '" & CInt(inMUTANURE) & "', "
            stConsultaSQL += "MUTAFERE = '" & CStr(Trim(stMUTAFERE)) & "' "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "MUTAIDRE = '" & CInt(inMUTAIDRE) & "'"

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
            MessageBox.Show(Err.Description & " " & "fun_Actualizar_MUTACIONES")
        End Try

    End Function

    ''' <summary>
    ''' Función que Modifica el registro.
    ''' </summary>
    Public Function fun_Actualizar_MATECARG_X_MUTACIONES(ByVal inMUTASECU As Integer, _
                                                         ByVal stMUTAMACA As String) As Boolean

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "UPDATE "
            stConsultaSQL += "MUTACIONES "

            stConsultaSQL += "SET "
            stConsultaSQL += "MUTAMACA = '" & CStr(Trim(stMUTAMACA)) & "' "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "MUTASECU = '" & CInt(inMUTASECU) & "' "

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
            MessageBox.Show(Err.Description & " " & "fun_Actualizar_MUTACIONES")
        End Try

    End Function

    ''' <summary>
    ''' Consulta para llenar el DataGridView y colocar el nombre del encabezado
    ''' de la columna. 
    ''' </summary>
    Public Function fun_Consultar_MUTACIONES() As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "TOP 0 "
            stConsultaSQL += "MUTAIDRE, "
            stConsultaSQL += "MUTASECU, "
            stConsultaSQL += "MUTANUFI, "
            stConsultaSQL += "MUTADEPA, "
            stConsultaSQL += "MUTAMUNI, "
            stConsultaSQL += "MUTACORR, "
            stConsultaSQL += "MUTABARR, "
            stConsultaSQL += "MUTAMANZ, "
            stConsultaSQL += "MUTAPRED, "
            stConsultaSQL += "MUTAEDIF, "
            stConsultaSQL += "MUTAUNPR, "
            stConsultaSQL += "MUTACLSE, "
            stConsultaSQL += "CLSEDESC, "
            stConsultaSQL += "MUTAVIGE, "
            stConsultaSQL += "MUTAFEES, "
            stConsultaSQL += "MUTAESCR, "
            stConsultaSQL += "MUTANURA, "
            stConsultaSQL += "MUTAFERA, "
            stConsultaSQL += "MUTAOBSE, "
            stConsultaSQL += "MUTAFEIN, "
            stConsultaSQL += "MUTAMAIN, "
            stConsultaSQL += "ESTADESC, "
            stConsultaSQL += "MUTAMACA, "
            stConsultaSQL += "MUTADESC, "
            stConsultaSQL += "MUTAVACO, "
            stConsultaSQL += "MUTAESTA, "
            stConsultaSQL += "MUTANURE, "
            stConsultaSQL += "MUTAFERE "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MUTACIONES, ESTADO, MANT_CLASSECT "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "MUTAESTA = ESTACODI AND "
            stConsultaSQL += "MUTACLSE = CLSECODI "

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "MUTAVIGE, MUTACLSE, MUTADEPA, MUTACORR, MUTABARR, MUTAMANZ, MUTAPRED, MUTAEDIF, MUTAUNPR "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Consultar_MUTACIONES")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Llena el ComboBox con datos activos e inactivos formulario principal 
    ''' esta funcion se llama desde el procedimiento "pro_inicializarControles()".
    ''' </summary>
    Public Function fun_Consultar_CAMPOS_MUTACIONES() As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MUTACIONES "

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "MUTAVIGE, MUTACLSE, MUTADEPA, MUTACORR, MUTABARR, MUTAMANZ, MUTAPRED, MUTAEDIF, MUTAUNPR "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Consultar_CAMPOS_MUTACIONES")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que busca el ID del registro a modificar o eliminar.
    ''' </summary>
    Public Function fun_Consultar_Parametros_X_MUTACIONES(ByVal stREMUVIGE As String, _
                                                          ByVal stREMUMES As String, _
                                                          ByVal stNRODIAS As String) As DataTable

        Try

            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MUTACIONES "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "MUTAFEIN BETWEEN '" & "01-" & CStr(stREMUMES) & "-" & CInt(stREMUVIGE) & "' AND '" & CStr(stNRODIAS) & "-" & CStr(stREMUMES) & "-" & CInt(stREMUVIGE) & "' "

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
    ''' Llena el ComboBox con datos activos formulario insertar y modificar 
    ''' esta funcion se llama desde el procedimiento "pro_inicializarControles()".
    ''' </summary>
    Public Function fun_Consultar_MUTACIONES_X_ESTADO() As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MUTACIONES "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "MUTAESTA = 'ac' "

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "MUTAVIGE, MUTACLSE, MUTADEPA, MUTACORR, MUTABARR, MUTAMANZ, MUTAPRED, MUTAEDIF, MUTAUNPR "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Consultar_MUTACIONES_X_ESTADO")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que busca el ID del registro a modificar o eliminar.
    ''' </summary>
    Public Function fun_Buscar_ID_MUTACIONES(ByVal inMUTAIDRE As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MUTACIONES "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "MUTAIDRE = '" & CInt(inMUTAIDRE) & "'"

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Buscar_ID_MUTACIONES")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que busca el CÓDIGO para que no se 
    ''' guarden registros duplicados.
    ''' </summary>
    Public Function fun_Buscar_CODIGO_X_MUTACIONES(ByVal inMUTASECU As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MUTACIONES "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "MUTASECU = '" & CInt(inMUTASECU) & "' "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Buscar_CODIGO_MUTACIONES")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que busca el CÓDIGO para que no se 
    ''' guarden registros duplicados.
    ''' </summary>
    Public Function fun_Buscar_MUTACIONES_X_NRO_FICHA(ByVal inMUTANUFI As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MUTACIONES "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "MUTANUFI = '" & CInt(inMUTANUFI) & "' "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Buscar_CODIGO_MUTACIONES")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que busca el CÓDIGO para que no se 
    ''' guarden registros duplicados.
    ''' </summary>
    Public Function fun_Buscar_MUTACIONES_X_NRO_FICHA_Y_VIGENCIA(ByVal inMUTANUFI As Integer, ByVal inMUTAVIGE As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MUTACIONES "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "MUTANUFI = '" & CInt(inMUTANUFI) & "' AND "
            stConsultaSQL += "MUTAVIGE = '" & CInt(inMUTAVIGE) & "' "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Buscar_CODIGO_MUTACIONES")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que busca el CÓDIGO para que no se 
    ''' guarden registros duplicados.
    ''' </summary>
    Public Function fun_Buscar_MUTACIONES_X_MATRICULA(ByVal stMUTAMAIN As String) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MUTACIONES "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "MUTAMAIN = '" & CStr(Trim(stMUTAMAIN)) & "' "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Buscar_CODIGO_MUTACIONES")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que busca el CÓDIGO para que no se 
    ''' guarden registros duplicados.
    ''' </summary>
    Public Function fun_Buscar_CODIGO_X_MUTACIONES(ByVal inMUTANUFI As Integer, _
                                                   ByVal stMUTAFEES As String, _
                                                   ByVal inMUTAESCR As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MUTACIONES "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "MUTANUFI = '" & CInt(inMUTANUFI) & "' and "
            stConsultaSQL += "MUTAFEES = '" & CStr(Trim(stMUTAFEES)) & "' and "
            stConsultaSQL += "MUTAESCR = '" & CInt(inMUTAESCR) & "' "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Buscar_CODIGO_MUTACIONES")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que busca el CÓDIGO para que no se 
    ''' guarden registros duplicados.
    ''' </summary>
    Public Function fun_Buscar_CODIGO_X_MUTACIONES_MATRICULAS(ByVal inMUTASECU As Integer, _
                                                              ByVal inMUTANUFI As Integer, _
                                                              ByVal inMUTAMAIN As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MUTACIONES "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "MUTASECU = '" & CInt(inMUTASECU) & "' and "
            stConsultaSQL += "MUTANUFI = '" & CInt(inMUTANUFI) & "' and "
            stConsultaSQL += "MUTAMAIN = '" & CInt(inMUTAMAIN) & "' "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Buscar_CODIGO_MUTACIONES")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que busca el ID del codigo buscado para ejecutar la consulta
    ''' parametrizada.
    ''' </summary>
    Public Function fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_MUTACIONES(ByVal inMUTAIDRE As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "MUTAIDRE, "
            stConsultaSQL += "MUTASECU, "
            stConsultaSQL += "MUTANUFI, "
            stConsultaSQL += "MUTADEPA, "
            stConsultaSQL += "MUTAMUNI, "
            stConsultaSQL += "MUTACORR, "
            stConsultaSQL += "MUTABARR, "
            stConsultaSQL += "MUTAMANZ, "
            stConsultaSQL += "MUTAPRED, "
            stConsultaSQL += "MUTAEDIF, "
            stConsultaSQL += "MUTAUNPR, "
            stConsultaSQL += "MUTACLSE, "
            stConsultaSQL += "CLSEDESC, "
            stConsultaSQL += "MUTAVIGE, "
            stConsultaSQL += "MUTAFEES, "
            stConsultaSQL += "MUTAESCR, "
            stConsultaSQL += "MUTANURA, "
            stConsultaSQL += "MUTAFERA, "
            stConsultaSQL += "MUTAOBSE, "
            stConsultaSQL += "MUTAFEIN, "
            stConsultaSQL += "MUTAMAIN, "
            stConsultaSQL += "ESTADESC, "
            stConsultaSQL += "MUTAMACA, "
            stConsultaSQL += "MUTADESC, "
            stConsultaSQL += "MUTAVACO, "
            stConsultaSQL += "MUTAESTA, "
            stConsultaSQL += "MUTANURE, "
            stConsultaSQL += "MUTAFERE "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MUTACIONES, ESTADO, MANT_CLASSECT "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "MUTAESTA = ESTACODI AND "
            stConsultaSQL += "MUTACLSE = CLSECODI AND "
            stConsultaSQL += "MUTAIDRE = '" & CInt(inMUTAIDRE) & "'"

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "MUTAVIGE, MUTACLSE, MUTADEPA, MUTACORR, MUTABARR, MUTAMANZ, MUTAPRED, MUTAEDIF, MUTAUNPR "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception

            MessageBox.Show(Err.Description & " " & "fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_MUTACIONES")
            Return Nothing

        End Try

    End Function

    ''' <summary>
    ''' Función que busca la secuencia maxima
    ''' </summary>
    Public Function fun_Buscar_SECUENCIA_X_MUTACIONES() As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "MUTASECU "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MUTACIONES "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Buscar_SECUENCIA_MAXINA_X_MUTACIONES")
            Return Nothing
        End Try

    End Function

End Class
