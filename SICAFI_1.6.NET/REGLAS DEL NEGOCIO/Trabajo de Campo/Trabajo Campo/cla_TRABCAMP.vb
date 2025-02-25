Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration
Imports DATOS

Public Class cla_TRABCAMP

    '==============================
    '*** CLASE TRABAJO DE CAMPO ***
    '==============================

    ''' <summary>
    ''' procedimiento que verifica la llave primaria.
    ''' </summary>
    Public Function fun_Verifica_llave_Primaria_TRABCAMP(ByVal obTRCAMUNI As Object, _
                                                         ByVal obTRCACORR As Object, _
                                                         ByVal obTRCABARR As Object, _
                                                         ByVal obTRCAMANZ As Object, _
                                                         ByVal obTRCAPRED As Object, _
                                                         ByVal obTRCAFEES As Object, _
                                                         ByVal obTRCAESCR As Object) As Boolean

        Try
            Dim boRespuesta As Boolean = False

            Dim obVerifica As New cla_Verificar_Dato

            If obVerifica.fun_Verificar_Campo_Lleno(obTRCAMUNI.Text) = True And _
                obVerifica.fun_Verificar_Campo_Lleno(obTRCACORR.Text) = True And _
                obVerifica.fun_Verificar_Campo_Lleno(obTRCABARR.Text) = True And _
                obVerifica.fun_Verificar_Campo_Lleno(obTRCAMANZ.Text) = True And _
                obVerifica.fun_Verificar_Campo_Lleno(obTRCAPRED.Text) = True And _
                obVerifica.fun_Verificar_Campo_Lleno(obTRCAFEES.Text) = True And _
                obVerifica.fun_Verificar_Campo_Lleno(obTRCAESCR.Text) = True Then

                If obVerifica.fun_Verificar_Dato_Numerico(obTRCAMUNI.Text) = True And _
                    obVerifica.fun_Verificar_Dato_Numerico(obTRCACORR.Text) = True And _
                    obVerifica.fun_Verificar_Dato_Numerico(obTRCABARR.Text) = True And _
                    obVerifica.fun_Verificar_Dato_Numerico(obTRCAMANZ.Text) = True And _
                    obVerifica.fun_Verificar_Dato_Numerico(obTRCAPRED.Text) = True And _
                    obVerifica.fun_Verificar_Dato_Numerico(obTRCAESCR.Text) = True Then

                    Dim objdatos1 As New cla_TRABCAMP
                    Dim tbl As New DataTable

                    tbl = objdatos1.fun_Buscar_CODIGO_X_TRABCAMP(obTRCAMUNI.Text, obTRCACORR.Text, obTRCABARR.Text, obTRCAMANZ.Text, obTRCAPRED.Text, obTRCAFEES.Text, obTRCAESCR.Text)

                    If tbl.Rows.Count > 0 Then
                        MessageBox.Show("El registro existe en la base de datos.", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1)
                        obTRCAMUNI.Focus()
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
    Public Function fun_Insertar_TRABCAMP(ByVal inTRCASECU As Integer, _
                                            ByVal stTRCAMUNI As String, _
                                            ByVal stTRCACORR As String, _
                                            ByVal stTRCABARR As String, _
                                            ByVal stTRCAMANZ As String, _
                                            ByVal stTRCAPRED As String, _
                                            ByVal inTRCACLSE As String, _
                                            ByVal inTRCAVIGE As Integer, _
                                            ByVal stTRCAFEES As String, _
                                            ByVal inTRCAESCR As Integer, _
                                            ByVal inTRCAPRNU As Integer, _
                                            ByVal stTRCACAAC As String, _
                                            ByVal stTRCANODE As String, _
                                            ByVal stTRCANOMU As String, _
                                            ByVal stTRCANOTA As String, _
                                            ByVal stTRCAOBSE As String, _
                                            ByVal stTRCAESTA As String, _
                                            ByVal inTRCAPRMO As Integer, _
                                            ByVal inTRCAPREL As Integer, _
                                            ByVal stTRCADESC As String, _
                                            ByVal stTRCAMAIN As String) As Boolean

        Try

            ' variables 
            Dim stTRCADEPA As String = "05"

            '' *** INSTANCIA LA FECHA Y HORA ***
            Dim daTRCAFEIN As Date = fun_fecha()

            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "INSERT INTO "
            stConsultaSQL += "TRABCAMP "

            stConsultaSQL += "( "
            stConsultaSQL += "TRCASECU, "
            stConsultaSQL += "TRCADEPA, "
            stConsultaSQL += "TRCAMUNI, "
            stConsultaSQL += "TRCACORR, "
            stConsultaSQL += "TRCABARR, "
            stConsultaSQL += "TRCAMANZ, "
            stConsultaSQL += "TRCAPRED, "
            stConsultaSQL += "TRCACLSE, "
            stConsultaSQL += "TRCAVIGE, "
            stConsultaSQL += "TRCAFEES, "
            stConsultaSQL += "TRCAESCR, "
            stConsultaSQL += "TRCAPRNU, "
            stConsultaSQL += "TRCACAAC, "
            stConsultaSQL += "TRCANODE, "
            stConsultaSQL += "TRCANOMU, "
            stConsultaSQL += "TRCANOTA, "
            stConsultaSQL += "TRCAOBSE, "
            stConsultaSQL += "TRCAESTA, "
            stConsultaSQL += "TRCAFEIN, "
            stConsultaSQL += "TRCAPRMO, "
            stConsultaSQL += "TRCAPREL, "
            stConsultaSQL += "TRCADESC, "
            stConsultaSQL += "TRCAMAIN "
            stConsultaSQL += ") "

            stConsultaSQL += "VALUES "

            stConsultaSQL += "( "
            stConsultaSQL += "'" & CInt(inTRCASECU) & "', "
            stConsultaSQL += "'" & CStr(Trim(stTRCADEPA)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stTRCAMUNI)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stTRCACORR)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stTRCABARR)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stTRCAMANZ)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stTRCAPRED)) & "', "
            stConsultaSQL += "'" & CInt(inTRCACLSE) & "', "
            stConsultaSQL += "'" & CInt(inTRCAVIGE) & "', "
            stConsultaSQL += "'" & CStr(Trim(stTRCAFEES)) & "', "
            stConsultaSQL += "'" & CInt(inTRCAESCR) & "', "
            stConsultaSQL += "'" & CInt(inTRCAPRNU) & "', "
            stConsultaSQL += "'" & CStr(Trim(stTRCACAAC)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stTRCANODE)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stTRCANOMU)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stTRCANOTA)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stTRCAOBSE)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stTRCAESTA)) & "', "
            stConsultaSQL += "'" & CDate(daTRCAFEIN) & "', "
            stConsultaSQL += "'" & CInt(inTRCAPRMO) & "', "
            stConsultaSQL += "'" & CInt(inTRCAPREL) & "', "
            stConsultaSQL += "'" & CStr(Trim(stTRCADESC)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stTRCAMAIN)) & "' "
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
            MessageBox.Show(Err.Description & " " & "fun_Insertar_TRABCAMP")
        End Try

    End Function

    ''' <summary>
    ''' Función que Elimina el registro.
    ''' </summary>
    Public Function fun_Eliminar_IDRE_TRABCAMP(ByVal inTRCAIDRE As Integer) As Boolean

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "DELETE "
            stConsultaSQL += "TRABCAMP "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "TRCAIDRE = '" & CInt(inTRCAIDRE) & "' "

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
            MessageBox.Show(Err.Description & " " & "fun_Eliminar_TRABCAMP")
        End Try

    End Function

    ''' <summary>
    ''' Función que Elimina el registro.
    ''' </summary>
    Public Function fun_Eliminar_SECU_TRABCAMP(ByVal inTRCASECU As Integer) As Boolean

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "DELETE "
            stConsultaSQL += "TRABCAMP "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "TRCASECU = '" & CInt(inTRCASECU) & "' "

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
            MessageBox.Show(Err.Description & " " & "fun_Eliminar_TRABCAMP")
        End Try

    End Function

    ''' <summary>
    ''' Función que Modifica el registro.
    ''' </summary>
    Public Function fun_Actualizar_TRABCAMP(ByVal inTRCAIDRE As Integer, _
                                            ByVal inTRCASECU As Integer, _
                                            ByVal stTRCAMUNI As String, _
                                            ByVal stTRCACORR As String, _
                                            ByVal stTRCABARR As String, _
                                            ByVal stTRCAMANZ As String, _
                                            ByVal stTRCAPRED As String, _
                                            ByVal inTRCACLSE As String, _
                                            ByVal inTRCAVIGE As Integer, _
                                            ByVal stTRCAFEES As String, _
                                            ByVal inTRCAESCR As Integer, _
                                            ByVal inTRCAPRNU As Integer, _
                                            ByVal stTRCACAAC As String, _
                                            ByVal stTRCANODE As String, _
                                            ByVal stTRCANOMU As String, _
                                            ByVal stTRCANOTA As String, _
                                            ByVal stTRCAOBSE As String, _
                                            ByVal stTRCAESTA As String, _
                                            ByVal inTRCAPRMO As Integer, _
                                            ByVal inTRCAPREL As Integer, _
                                            ByVal stTRCADESC As String, _
                                            ByVal stTRCAMAIN As String) As Boolean

        Try
            ' variables
            Dim stTRCADEPA As String = "05"

            If stTRCANODE Is Nothing Then
                stTRCANODE = ""
            End If

            If stTRCANOMU Is Nothing Then
                stTRCANOMU = ""
            End If

            If stTRCANOTA Is Nothing Then
                stTRCANOTA = ""
            End If

            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "UPDATE "
            stConsultaSQL += "TRABCAMP "

            stConsultaSQL += "SET "
            stConsultaSQL += "TRCASECU = '" & CInt(inTRCASECU) & "', "
            stConsultaSQL += "TRCADEPA = '" & CStr(Trim(stTRCADEPA)) & "', "
            stConsultaSQL += "TRCAMUNI = '" & CStr(Trim(stTRCAMUNI)) & "', "
            stConsultaSQL += "TRCACORR = '" & CStr(Trim(stTRCACORR)) & "', "
            stConsultaSQL += "TRCABARR = '" & CStr(Trim(stTRCABARR)) & "', "
            stConsultaSQL += "TRCAMANZ = '" & CStr(Trim(stTRCAMANZ)) & "', "
            stConsultaSQL += "TRCAPRED = '" & CStr(Trim(stTRCAPRED)) & "', "
            stConsultaSQL += "TRCACLSE = '" & CInt(inTRCACLSE) & "', "
            stConsultaSQL += "TRCAVIGE = '" & CInt(inTRCAVIGE) & "', "
            stConsultaSQL += "TRCAFEES = '" & CStr(Trim(stTRCAFEES)) & "', "
            stConsultaSQL += "TRCAESCR = '" & CInt(inTRCAESCR) & "', "
            stConsultaSQL += "TRCAPRNU = '" & CInt(inTRCAPRNU) & "', "
            stConsultaSQL += "TRCACAAC = '" & CStr(Trim(stTRCACAAC)) & "', "
            stConsultaSQL += "TRCANODE = '" & CStr(Trim(stTRCANODE)) & "', "
            stConsultaSQL += "TRCANOMU = '" & CStr(Trim(stTRCANOMU)) & "', "
            stConsultaSQL += "TRCANOTA = '" & CStr(Trim(stTRCANOTA)) & "', "
            stConsultaSQL += "TRCAOBSE = '" & CStr(Trim(stTRCAOBSE)) & "', "
            stConsultaSQL += "TRCAESTA = '" & CStr(Trim(stTRCAESTA)) & "', "
            stConsultaSQL += "TRCAPRMO = '" & CInt(inTRCAPRMO) & "', "
            stConsultaSQL += "TRCAPREL = '" & CInt(inTRCAPREL) & "', "
            stConsultaSQL += "TRCADESC = '" & CStr(Trim(stTRCADESC)) & "', "
            stConsultaSQL += "TRCAMAIN = '" & CStr(Trim(stTRCAMAIN)) & "'  "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "TRCAIDRE = '" & CInt(inTRCAIDRE) & "'"

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
            MessageBox.Show(Err.Description & " " & "fun_Actualizar_TRABCAMP")
        End Try

    End Function

    ''' <summary>
    ''' Función que Modifica el registro.
    ''' </summary>
    Public Function fun_Actualizar_MATECARG_X_TRABCAMP(ByVal inTRCASECU As Integer, _
                                                       ByVal stTRCAMACA As String) As Boolean

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "UPDATE "
            stConsultaSQL += "TRABCAMP "

            stConsultaSQL += "SET "
            stConsultaSQL += "TRCAMACA = '" & CStr(Trim(stTRCAMACA)) & "' "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "TRCASECU = '" & CInt(inTRCASECU) & "' "

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
            MessageBox.Show(Err.Description & " " & "fun_Actualizar_TRABCAMP")
        End Try

    End Function

    ''' <summary>
    ''' Consulta para llenar el DataGridView y colocar el nombre del encabezado
    ''' de la columna. 
    ''' </summary>
    Public Function fun_Consultar_TRABCAMP() As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "TOP 0 "
            stConsultaSQL += "TRCAIDRE, "
            stConsultaSQL += "TRCASECU, "
            stConsultaSQL += "TRCADEPA, "
            stConsultaSQL += "TRCAMUNI, "
            stConsultaSQL += "TRCACORR, "
            stConsultaSQL += "TRCABARR, "
            stConsultaSQL += "TRCAMANZ, "
            stConsultaSQL += "TRCAPRED, "
            stConsultaSQL += "TRCACLSE, "
            stConsultaSQL += "CLSEDESC, "
            stConsultaSQL += "TRCAVIGE, "
            stConsultaSQL += "TRCAFEES, "
            stConsultaSQL += "TRCAESCR, "
            stConsultaSQL += "TRCAPRNU, "
            stConsultaSQL += "TRCACAAC, "
            stConsultaSQL += "TRCANODE, "
            stConsultaSQL += "TRCANOMU, "
            stConsultaSQL += "TRCANOTA, "
            stConsultaSQL += "TRCAOBSE, "
            stConsultaSQL += "TRCAFEIN, "
            stConsultaSQL += "ESTADESC, "
            stConsultaSQL += "TRCAPRMO, "
            stConsultaSQL += "TRCAPREL, "
            stConsultaSQL += "TRCAMACA, "
            stConsultaSQL += "TRCADESC, "
            stConsultaSQL += "TRCAESTA, "
            stConsultaSQL += "TRCAMAIN "

            stConsultaSQL += "FROM "
            stConsultaSQL += "TRABCAMP, ESTADO, MANT_CLASSECT "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "TRCAESTA = ESTACODI AND "
            stConsultaSQL += "TRCACLSE = CLSECODI "

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "TRCAVIGE, TRCACLSE, TRCADEPA, TRCACORR, TRCABARR, TRCAMANZ, TRCAPRED "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Consultar_TRABCAMP")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Llena el ComboBox con datos activos e inactivos formulario principal 
    ''' esta funcion se llama desde el procedimiento "pro_inicializarControles()".
    ''' </summary>
    Public Function fun_Consultar_CAMPOS_TRABCAMP() As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "TRABCAMP "

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "TRCAVIGE, TRCACLSE, TRCADEPA, TRCACORR, TRCABARR, TRCAMANZ, TRCAPRED "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Consultar_CAMPOS_TRABCAMP")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Llena el ComboBox con datos activos formulario insertar y modificar 
    ''' esta funcion se llama desde el procedimiento "pro_inicializarControles()".
    ''' </summary>
    Public Function fun_Consultar_TRABCAMP_X_ESTADO() As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "TRABCAMP "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "TRCAESTA = 'ac' "

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "TRCAVIGE, TRCACLSE, TRCADEPA, TRCACORR, TRCABARR, TRCAMANZ, TRCAPRED "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Consultar_TRABCAMP_X_ESTADO")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que busca el ID del registro a modificar o eliminar.
    ''' </summary>
    Public Function fun_Buscar_ID_TRABCAMP(ByVal inTRCAIDRE As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "TRABCAMP "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "TRCAIDRE = '" & CInt(inTRCAIDRE) & "'"

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Buscar_ID_TRABCAMP")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que busca el CÓDIGO para que no se 
    ''' guarden registros duplicados.
    ''' </summary>
    Public Function fun_Buscar_CODIGO_X_TRABCAMP(ByVal inTRCASECU As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "TRABCAMP "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "TRCASECU = '" & CInt(inTRCASECU) & "' "

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
    Public Function fun_Buscar_CODIGO_X_TRABCAMP(ByVal stTRCAMUNI As String, _
                                                 ByVal stTRCACORR As String, _
                                                 ByVal stTRCABARR As String, _
                                                 ByVal stTRCAMANZ As String, _
                                                 ByVal stTRCAPRED As String, _
                                                 ByVal stTRCAFEES As String, _
                                                 ByVal inTRCAESCR As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "TRABCAMP "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "TRCAMUNI = '" & CStr(Trim(stTRCAMUNI)) & "' and "
            stConsultaSQL += "TRCACORR = '" & CStr(Trim(stTRCACORR)) & "' and "
            stConsultaSQL += "TRCABARR = '" & CStr(Trim(stTRCABARR)) & "' and "
            stConsultaSQL += "TRCAMANZ = '" & CStr(Trim(stTRCAMANZ)) & "' and "
            stConsultaSQL += "TRCAPRED = '" & CStr(Trim(stTRCAPRED)) & "' and "
            stConsultaSQL += "TRCAFEES = '" & CStr(Trim(stTRCAFEES)) & "' and "
            stConsultaSQL += "TRCAESCR = '" & CInt(inTRCAESCR) & "' "

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
    ''' Función que busca el ID del codigo buscado para ejecutar la consulta
    ''' parametrizada.
    ''' </summary>
    Public Function fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_TRABCAMP(ByVal inTRCAIDRE As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "TRCAIDRE, "
            stConsultaSQL += "TRCASECU, "
            stConsultaSQL += "TRCADEPA, "
            stConsultaSQL += "TRCAMUNI, "
            stConsultaSQL += "TRCACORR, "
            stConsultaSQL += "TRCABARR, "
            stConsultaSQL += "TRCAMANZ, "
            stConsultaSQL += "TRCAPRED, "
            stConsultaSQL += "TRCACLSE, "
            stConsultaSQL += "CLSEDESC, "
            stConsultaSQL += "TRCAVIGE, "
            stConsultaSQL += "TRCAFEES, "
            stConsultaSQL += "TRCAESCR, "
            stConsultaSQL += "TRCAPRNU, "
            stConsultaSQL += "TRCACAAC, "
            stConsultaSQL += "TRCANODE, "
            stConsultaSQL += "TRCANOMU, "
            stConsultaSQL += "TRCANOTA, "
            stConsultaSQL += "TRCAOBSE, "
            stConsultaSQL += "TRCAFEIN, "
            stConsultaSQL += "ESTADESC, "
            stConsultaSQL += "TRCAPRMO, "
            stConsultaSQL += "TRCAPREL, "
            stConsultaSQL += "TRCAMACA, "
            stConsultaSQL += "TRCADESC, "
            stConsultaSQL += "TRCAESTA, "
            stConsultaSQL += "TRCAMAIN "

            stConsultaSQL += "FROM "
            stConsultaSQL += "TRABCAMP, ESTADO, MANT_CLASSECT "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "TRCAESTA = ESTACODI AND "
            stConsultaSQL += "TRCACLSE = CLSECODI AND "
            stConsultaSQL += "TRCAIDRE = '" & CInt(inTRCAIDRE) & "'"

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "TRCAVIGE, TRCACLSE, TRCADEPA, TRCACORR, TRCABARR, TRCAMANZ, TRCAPRED "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception

            MessageBox.Show(Err.Description & " " & "fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_TRABCAMP")
            Return Nothing

        End Try

    End Function

    ''' <summary>
    ''' Función que busca el ID del codigo buscado para ejecutar la consulta
    ''' parametrizada.
    ''' </summary>
    Public Function fun_Buscar_SECU_X_CONSULTA_PARAMETRIZADA_TRABCAMP(ByVal inTRCASECU As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "TRABCAMP "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "TRCASECU = '" & CInt(inTRCASECU) & "' "

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "TRCAVIGE, TRCACLSE, TRCADEPA, TRCACORR, TRCABARR, TRCAMANZ, TRCAPRED "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception

            MessageBox.Show(Err.Description & " " & "fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_TRABCAMP")
            Return Nothing

        End Try

    End Function

    ''' <summary>
    ''' Función que busca la secuencia maxima
    ''' </summary>
    Public Function fun_Buscar_SECUENCIA_X_TRABCAMP() As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "TRCASECU "

            stConsultaSQL += "FROM "
            stConsultaSQL += "TRABCAMP "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Buscar_SECUENCIA_MAXINA_X_TRABCAMP")
            Return Nothing
        End Try

    End Function

End Class
