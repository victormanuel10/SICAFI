Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration
Imports DATOS

Public Class cla_MOVIALFA

    '======================================
    '*** CLASE MOVIMIENTO ALFANUMERICOS ***
    '======================================

    ''' <summary>
    ''' procedimiento que verifica la llave primaria.
    ''' </summary>
    Public Function fun_Verifica_llave_Primaria_MOVIALFA(ByVal obMOALMUNI As Object, _
                                                         ByVal obMOALCORR As Object, _
                                                         ByVal obMOALBARR As Object, _
                                                         ByVal obMOALMANZ As Object, _
                                                         ByVal obMOALPRED As Object, _
                                                         ByVal obMOALCLSE As Object, _
                                                         ByVal obMOALVIGE As Object) As Boolean

        Try
            Dim boRespuesta As Boolean = False

            Dim obVerifica As New cla_Verificar_Dato

            If obVerifica.fun_Verificar_Campo_Lleno(obMOALMUNI.Text) = True And _
                obVerifica.fun_Verificar_Campo_Lleno(obMOALCORR.Text) = True And _
                obVerifica.fun_Verificar_Campo_Lleno(obMOALBARR.Text) = True And _
                obVerifica.fun_Verificar_Campo_Lleno(obMOALMANZ.Text) = True And _
                obVerifica.fun_Verificar_Campo_Lleno(obMOALPRED.Text) = True And _
                obVerifica.fun_Verificar_Campo_Lleno(obMOALCLSE.SelectedValue) = True And _
                obVerifica.fun_Verificar_Campo_Lleno(obMOALVIGE.SelectedValue) = True Then

                If obVerifica.fun_Verificar_Dato_Numerico(obMOALMUNI.Text) = True And _
                    obVerifica.fun_Verificar_Dato_Numerico(obMOALCORR.Text) = True And _
                    obVerifica.fun_Verificar_Dato_Numerico(obMOALBARR.Text) = True And _
                    obVerifica.fun_Verificar_Dato_Numerico(obMOALMANZ.Text) = True And _
                    obVerifica.fun_Verificar_Dato_Numerico(obMOALPRED.Text) = True And _
                    obVerifica.fun_Verificar_Dato_Numerico(obMOALCLSE.SelectedValue) = True And _
                    obVerifica.fun_Verificar_Dato_Numerico(obMOALVIGE.SelectedValue) = True Then

                    Dim objdatos1 As New cla_MOVIALFA
                    Dim tbl As New DataTable

                    tbl = objdatos1.fun_Buscar_CODIGO_X_MOVIALFA(obMOALMUNI.Text, _
                                                                 obMOALCORR.Text, _
                                                                 obMOALBARR.Text, _
                                                                 obMOALMANZ.Text, _
                                                                 obMOALPRED.Text, _
                                                                 obMOALCLSE.SelectedValue, _
                                                                 obMOALVIGE.SelectedValue)

                    If tbl.Rows.Count > 0 Then
                        MessageBox.Show("El registro existe en la base de datos.", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1)
                        obMOALMUNI.Focus()
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
    Public Function fun_Insertar_MOVIALFA(ByVal inMOALSECU As Integer, _
                                          ByVal stMOALMUNI As String, _
                                          ByVal stMOALCORR As String, _
                                          ByVal stMOALBARR As String, _
                                          ByVal stMOALMANZ As String, _
                                          ByVal stMOALPRED As String, _
                                          ByVal inMOALCLSE As Integer, _
                                          ByVal inMOALVIGE As Integer, _
                                          ByVal stMOALNUDO As String, _
                                          ByVal stMOALUSUA As String, _
                                          ByVal stMOALFEAS As String, _
                                          ByVal stMOALCAAC As String, _
                                          ByVal inMOALCLVE As Integer, _
                                          ByVal stMOALFFMU As String, _
                                          ByVal stMOALOBSE As String, _
                                          ByVal stMOALESTA As String) As Boolean
        Try

            ' variables 
            Dim stMOALDEPA As String = "05"

            '' *** INSTANCIA LA FECHA Y HORA ***
            Dim daMOALFEIN As Date = fun_fecha()

            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "INSERT INTO "
            stConsultaSQL += "MOVIALFA "

            stConsultaSQL += "( "
            stConsultaSQL += "MOALSECU, "
            stConsultaSQL += "MOALDEPA, "
            stConsultaSQL += "MOALMUNI, "
            stConsultaSQL += "MOALCORR, "
            stConsultaSQL += "MOALBARR, "
            stConsultaSQL += "MOALMANZ, "
            stConsultaSQL += "MOALPRED, "
            stConsultaSQL += "MOALCLSE, "
            stConsultaSQL += "MOALVIGE, "
            stConsultaSQL += "MOALNUDO, "
            stConsultaSQL += "MOALUSUA, "
            stConsultaSQL += "MOALFEAS, "
            stConsultaSQL += "MOALCAAC, "
            stConsultaSQL += "MOALCLVE, "
            stConsultaSQL += "MOALFFMU, "
            stConsultaSQL += "MOALOBSE, "
            stConsultaSQL += "MOALESTA, "
            stConsultaSQL += "MOALFEIN  "

            stConsultaSQL += ") "

            stConsultaSQL += "VALUES "

            stConsultaSQL += "( "
            stConsultaSQL += "'" & CInt(inMOALSECU) & "', "
            stConsultaSQL += "'" & CStr(Trim(stMOALDEPA)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stMOALMUNI)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stMOALCORR)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stMOALBARR)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stMOALMANZ)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stMOALPRED)) & "', "
            stConsultaSQL += "'" & CInt(inMOALCLSE) & "', "
            stConsultaSQL += "'" & CInt(inMOALVIGE) & "', "
            stConsultaSQL += "'" & CStr(Trim(stMOALNUDO)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stMOALUSUA)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stMOALFEAS)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stMOALCAAC)) & "', "
            stConsultaSQL += "'" & CInt(inMOALCLVE) & "', "
            stConsultaSQL += "'" & CStr(Trim(stMOALFFMU)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stMOALOBSE)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stMOALESTA)) & "', "
            stConsultaSQL += "'" & CDate(daMOALFEIN) & "' "
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
            MessageBox.Show(Err.Description & " " & "fun_Insertar_MOVIALFA")
        End Try

    End Function

    ''' <summary>
    ''' Función que Elimina el registro.
    ''' </summary>
    Public Function fun_Eliminar_IDRE_MOVIALFA(ByVal inMOALIDRE As Integer) As Boolean

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "DELETE "
            stConsultaSQL += "MOVIALFA "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "MOALIDRE = '" & CInt(inMOALIDRE) & "' "

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
            MessageBox.Show(Err.Description & " " & "fun_Eliminar_MOVIALFA")
        End Try

    End Function

    ''' <summary>
    ''' Función que Elimina el registro.
    ''' </summary>
    Public Function fun_Eliminar_SECU_MOVIALFA(ByVal inMOALSECU As Integer) As Boolean

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "DELETE "
            stConsultaSQL += "MOVIALFA "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "MOALSECU = '" & CInt(inMOALSECU) & "' "

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
            MessageBox.Show(Err.Description & " " & "fun_Eliminar_MOVIALFA")
        End Try

    End Function

    ''' <summary>
    ''' Función que Modifica el registro.
    ''' </summary>
    Public Function fun_Actualizar_MOVIALFA(ByVal inMOALIDRE As Integer, _
                                            ByVal inMOALSECU As Integer, _
                                            ByVal stMOALMUNI As String, _
                                            ByVal stMOALCORR As String, _
                                            ByVal stMOALBARR As String, _
                                            ByVal stMOALMANZ As String, _
                                            ByVal stMOALPRED As String, _
                                            ByVal inMOALCLSE As Integer, _
                                            ByVal inMOALVIGE As Integer, _
                                            ByVal stMOALNUDO As String, _
                                            ByVal stMOALUSUA As String, _
                                            ByVal stMOALCAAC As String, _
                                            ByVal inMOALCLVE As Integer, _
                                            ByVal stMOALOBSE As String, _
                                            ByVal stMOALESTA As String) As Boolean

        Try
            ' variables
            Dim stMOALDEPA As String = "05"

            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "UPDATE "
            stConsultaSQL += "MOVIALFA "

            stConsultaSQL += "SET "
            stConsultaSQL += "MOALSECU = '" & CInt(inMOALSECU) & "', "
            stConsultaSQL += "MOALDEPA = '" & CStr(Trim(stMOALDEPA)) & "', "
            stConsultaSQL += "MOALMUNI = '" & CStr(Trim(stMOALMUNI)) & "', "
            stConsultaSQL += "MOALCORR = '" & CStr(Trim(stMOALCORR)) & "', "
            stConsultaSQL += "MOALBARR = '" & CStr(Trim(stMOALBARR)) & "', "
            stConsultaSQL += "MOALMANZ = '" & CStr(Trim(stMOALMANZ)) & "', "
            stConsultaSQL += "MOALPRED = '" & CStr(Trim(stMOALPRED)) & "', "
            stConsultaSQL += "MOALCLSE = '" & CInt(inMOALCLSE) & "', "
            stConsultaSQL += "MOALVIGE = '" & CInt(inMOALVIGE) & "', "
            stConsultaSQL += "MOALNUDO = '" & CStr(Trim(stMOALNUDO)) & "', "
            stConsultaSQL += "MOALUSUA = '" & CStr(Trim(stMOALUSUA)) & "', "
            stConsultaSQL += "MOALCAAC = '" & CStr(Trim(stMOALCAAC)) & "', "
            stConsultaSQL += "MOALCLVE = '" & CInt(inMOALCLVE) & "', "
            stConsultaSQL += "MOALOBSE = '" & CStr(Trim(stMOALOBSE)) & "', "
            stConsultaSQL += "MOALESTA = '" & CStr(Trim(stMOALESTA)) & "' "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "MOALIDRE = '" & CInt(inMOALIDRE) & "'"

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
            MessageBox.Show(Err.Description & " " & "fun_Actualizar_MOVIALFA")
        End Try

    End Function

    ''' <summary>
    ''' Función que Modifica el registro.
    ''' </summary>
    Public Function fun_Actualizar_MOVIALFA(ByVal inMOALIDRE As Integer, _
                                            ByVal inMOALSECU As Integer, _
                                            ByVal stMOALMUNI As String, _
                                            ByVal stMOALCORR As String, _
                                            ByVal stMOALBARR As String, _
                                            ByVal stMOALMANZ As String, _
                                            ByVal stMOALPRED As String, _
                                            ByVal inMOALCLSE As Integer, _
                                            ByVal inMOALVIGE As Integer, _
                                            ByVal stMOALNUDO As String, _
                                            ByVal stMOALUSUA As String, _
                                            ByVal stMOALCAAC As String, _
                                            ByVal stMOALFEEN As String, _
                                            ByVal inMOALCLVE As Integer, _
                                            ByVal stMOALOBSE As String, _
                                            ByVal stMOALESTA As String) As Boolean

        Try
            ' variables
            Dim stMOALDEPA As String = "05"

            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "UPDATE "
            stConsultaSQL += "MOVIALFA "

            stConsultaSQL += "SET "
            stConsultaSQL += "MOALSECU = '" & CInt(inMOALSECU) & "', "
            stConsultaSQL += "MOALDEPA = '" & CStr(Trim(stMOALDEPA)) & "', "
            stConsultaSQL += "MOALMUNI = '" & CStr(Trim(stMOALMUNI)) & "', "
            stConsultaSQL += "MOALCORR = '" & CStr(Trim(stMOALCORR)) & "', "
            stConsultaSQL += "MOALBARR = '" & CStr(Trim(stMOALBARR)) & "', "
            stConsultaSQL += "MOALMANZ = '" & CStr(Trim(stMOALMANZ)) & "', "
            stConsultaSQL += "MOALPRED = '" & CStr(Trim(stMOALPRED)) & "', "
            stConsultaSQL += "MOALCLSE = '" & CInt(inMOALCLSE) & "', "
            stConsultaSQL += "MOALVIGE = '" & CInt(inMOALVIGE) & "', "
            stConsultaSQL += "MOALNUDO = '" & CStr(Trim(stMOALNUDO)) & "', "
            stConsultaSQL += "MOALUSUA = '" & CStr(Trim(stMOALUSUA)) & "', "
            stConsultaSQL += "MOALCAAC = '" & CStr(Trim(stMOALCAAC)) & "', "
            stConsultaSQL += "MOALFEAS = '" & CStr(Trim(stMOALFEEN)) & "', "
            stConsultaSQL += "MOALFFMU = '" & CStr(Trim("")) & "', "
            stConsultaSQL += "MOALCLVE = '" & CInt(inMOALCLVE) & "', "
            stConsultaSQL += "MOALOBSE = '" & CStr(Trim(stMOALOBSE)) & "', "
            stConsultaSQL += "MOALESTA = '" & CStr(Trim(stMOALESTA)) & "' "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "MOALIDRE = '" & CInt(inMOALIDRE) & "'"

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
            MessageBox.Show(Err.Description & " " & "fun_Actualizar_MOVIALFA")
        End Try

    End Function

    ''' <summary>
    ''' Consulta para llenar el DataGridView y colocar el nombre del encabezado
    ''' de la columna. 
    ''' </summary>
    Public Function fun_Consultar_MOVIALFA(ByVal boReconsultar As Boolean) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "

            If boReconsultar = False Then
                stConsultaSQL += "TOP 1 "
            End If

            stConsultaSQL += "MOALIDRE, "
            stConsultaSQL += "MOALSECU, "
            stConsultaSQL += "MOALDEPA, "
            stConsultaSQL += "MOALMUNI, "
            stConsultaSQL += "MOALCORR, "
            stConsultaSQL += "MOALBARR, "
            stConsultaSQL += "MOALMANZ, "
            stConsultaSQL += "MOALPRED, "
            stConsultaSQL += "MOALCLSE, "
            stConsultaSQL += "CLSEDESC, "
            stConsultaSQL += "MOALVIGE, "
            stConsultaSQL += "MOALNUDO, "
            stConsultaSQL += "MOALUSUA, "
            stConsultaSQL += "MOALFEAS, "
            stConsultaSQL += "MOALCAAC, "
            stConsultaSQL += "MOALCLVE, "
            stConsultaSQL += "MOALFFMU, "
            stConsultaSQL += "MOALOBSE, "
            stConsultaSQL += "MOALESTA, "
            stConsultaSQL += "MOALFEIN, "
            stConsultaSQL += "ESTADESC "


            stConsultaSQL += "FROM "
            stConsultaSQL += "MOVIALFA, ESTADO, MANT_CLASSECT "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "MOALESTA = ESTACODI AND "
            stConsultaSQL += "MOALCLSE = CLSECODI "

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "MOALCLSE, MOALDEPA, MOALCORR, MOALBARR, MOALMANZ, MOALPRED "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Consultar_MOVIALFA")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Llena el ComboBox con datos activos e inactivos formulario principal 
    ''' esta funcion se llama desde el procedimiento "pro_inicializarControles()".
    ''' </summary>
    Public Function fun_Consultar_CAMPOS_MOVIALFA() As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MOVIALFA "

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "MOALCLSE, MOALDEPA, MOALCORR, MOALBARR, MOALMANZ, MOALPRED "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Consultar_CAMPOS_MOVIALFA")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Llena el ComboBox con datos activos formulario insertar y modificar 
    ''' esta funcion se llama desde el procedimiento "pro_inicializarControles()".
    ''' </summary>
    Public Function fun_Consultar_MOVIALFA_X_ESTADO() As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MOVIALFA "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "MOALESTA = 'ac' "

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "MOALCLSE, MOALDEPA, MOALCORR, MOALBARR, MOALMANZ, MOALPRED "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Consultar_MOVIALFA_X_ESTADO")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que busca el ID del registro a modificar o eliminar.
    ''' </summary>
    Public Function fun_Buscar_ID_MOVIALFA(ByVal inMOALIDRE As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MOVIALFA "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "MOALIDRE = '" & CInt(inMOALIDRE) & "'"

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Buscar_ID_MOVIALFA")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que busca el CÓDIGO para que no se 
    ''' guarden registros duplicados.
    ''' </summary>
    Public Function fun_Buscar_CODIGO_X_MOVIALFA(ByVal inMOALSECU As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MOVIALFA "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "MOALSECU = '" & CInt(inMOALSECU) & "' "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Buscar_CODIGO_MOVIALFA")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que busca el CÓDIGO para que no se 
    ''' guarden registros duplicados.
    ''' </summary>
    Public Function fun_Buscar_CODIGO_X_MOVIALFA(ByVal stMOALMUNI As String, _
                                                 ByVal stMOALCORR As String, _
                                                 ByVal stMOALBARR As String, _
                                                 ByVal stMOALMANZ As String, _
                                                 ByVal stMOALPRED As String, _
                                                 ByVal inMOALCLSE As Integer, _
                                                 ByVal inMOALVIGE As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MOVIALFA "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "MOALMUNI = '" & CStr(Trim(stMOALMUNI)) & "' and "
            stConsultaSQL += "MOALCORR = '" & CStr(Trim(stMOALCORR)) & "' and "
            stConsultaSQL += "MOALBARR = '" & CStr(Trim(stMOALBARR)) & "' and "
            stConsultaSQL += "MOALMANZ = '" & CStr(Trim(stMOALMANZ)) & "' and "
            stConsultaSQL += "MOALPRED = '" & CStr(Trim(stMOALPRED)) & "' and "
            stConsultaSQL += "MOALCLSE = '" & CStr(Trim(inMOALCLSE)) & "' and "
            stConsultaSQL += "MOALVIGE = '" & CInt(inMOALVIGE) & "' "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Buscar_CODIGO_MOVIALFA")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que busca el ID del codigo buscado para ejecutar la consulta
    ''' parametrizada.
    ''' </summary>
    Public Function fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_MOVIALFA(ByVal inMOALIDRE As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "TOP 1 "
            stConsultaSQL += "MOALIDRE, "
            stConsultaSQL += "MOALSECU, "
            stConsultaSQL += "MOALDEPA, "
            stConsultaSQL += "MOALMUNI, "
            stConsultaSQL += "MOALCORR, "
            stConsultaSQL += "MOALBARR, "
            stConsultaSQL += "MOALMANZ, "
            stConsultaSQL += "MOALPRED, "
            stConsultaSQL += "MOALCLSE, "
            stConsultaSQL += "CLSEDESC, "
            stConsultaSQL += "MOALVIGE, "
            stConsultaSQL += "MOALNUDO, "
            stConsultaSQL += "MOALUSUA, "
            stConsultaSQL += "MOALFEAS, "
            stConsultaSQL += "MOALCAAC, "
            stConsultaSQL += "MOALCLVE, "
            stConsultaSQL += "MOALFFMU, "
            stConsultaSQL += "MOALOBSE, "
            stConsultaSQL += "MOALESTA, "
            stConsultaSQL += "MOALFEIN, "
            stConsultaSQL += "ESTADESC "


            stConsultaSQL += "FROM "
            stConsultaSQL += "MOVIALFA, ESTADO, MANT_CLASSECT "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "MOALESTA = ESTACODI and "
            stConsultaSQL += "MOALCLSE = CLSECODI and "
            stConsultaSQL += "MOALIDRE = '" & CInt(inMOALIDRE) & "' "

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "MOALCLSE, MOALDEPA, MOALCORR, MOALBARR, MOALMANZ, MOALPRED "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception

            MessageBox.Show(Err.Description & " " & "fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_MOVIALFA")
            Return Nothing

        End Try

    End Function

    Public Function fun_Buscar_CONSULTA_MOVIALFA_X_USUARIO(ByVal stMOALNUDO As String) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "MOALIDRE, "
            stConsultaSQL += "MOALSECU, "
            stConsultaSQL += "MOALDEPA, "
            stConsultaSQL += "MOALMUNI, "
            stConsultaSQL += "MOALCORR, "
            stConsultaSQL += "MOALBARR, "
            stConsultaSQL += "MOALMANZ, "
            stConsultaSQL += "MOALPRED, "
            stConsultaSQL += "MOALCLSE, "
            stConsultaSQL += "CLSEDESC, "
            stConsultaSQL += "MOALVIGE, "
            stConsultaSQL += "MOALNUDO, "
            stConsultaSQL += "MOALUSUA, "
            stConsultaSQL += "MOALFEAS, "
            stConsultaSQL += "MOALCAAC, "
            stConsultaSQL += "MOALCLVE, "
            stConsultaSQL += "MOALFFMU, "
            stConsultaSQL += "MOALOBSE, "
            stConsultaSQL += "MOALESTA, "
            stConsultaSQL += "MOALFEIN, "
            stConsultaSQL += "ESTADESC "


            stConsultaSQL += "FROM "
            stConsultaSQL += "MOVIALFA, ESTADO, MANT_CLASSECT "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "MOALESTA = ESTACODI and "
            stConsultaSQL += "MOALCLSE = CLSECODI and "
            stConsultaSQL += "MOALESTA = 'as' and "
            stConsultaSQL += "MOALNUDO = '" & CStr(Trim(stMOALNUDO)) & "' "

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "MOALCLSE, MOALDEPA, MOALCORR, MOALBARR, MOALMANZ, MOALPRED "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception

            MessageBox.Show(Err.Description & " " & "fun_Buscar_CONSULTA_MOVIALFA_X_USUARIO")
            Return Nothing

        End Try

    End Function

    ''' <summary>
    ''' Función que busca el registro y usuario
    ''' </summary>
    Public Function fun_Buscar_CONSULTA_CEDULA_CATASTRAL_Y_USUARIO(ByVal stMOALMUNI As String, _
                                                                   ByVal stMOALCORR As String, _
                                                                   ByVal stMOALBARR As String, _
                                                                   ByVal stMOALMANZ As String, _
                                                                   ByVal stMOALPRED As String, _
                                                                   ByVal inMOALCLSE As Integer, _
                                                                   ByVal inMOALVIGE As Integer, _
                                                                   ByVal stMOALUSUA As String) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MOVIALFA "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "MOALMUNI = '" & CStr(Trim(stMOALMUNI)) & "' AND "
            stConsultaSQL += "MOALCORR = '" & CStr(Trim(stMOALCORR)) & "' AND "
            stConsultaSQL += "MOALBARR = '" & CStr(Trim(stMOALBARR)) & "' AND "
            stConsultaSQL += "MOALMANZ = '" & CStr(Trim(stMOALMANZ)) & "' AND "
            stConsultaSQL += "MOALPRED = '" & CStr(Trim(stMOALPRED)) & "' AND "
            stConsultaSQL += "MOALCLSE = '" & CInt(inMOALCLSE) & "' AND "
            stConsultaSQL += "MOALVIGE = '" & CInt(inMOALVIGE) & "' AND "
            stConsultaSQL += "MOALUSUA = '" & CStr(Trim(stMOALUSUA)) & "' "

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "MOALCLSE, MOALDEPA, MOALCORR, MOALBARR, MOALMANZ, MOALPRED "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception

            MessageBox.Show(Err.Description & " " & "fun_Buscar_CONSULTA_MOVIALFA_X_USUARIO")
            Return Nothing

        End Try

    End Function

    ''' <summary>
    ''' Función que busca la secuencia maxima
    ''' </summary>
    Public Function fun_Buscar_SECUENCIA_X_MOVIALFA() As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "MOALSECU "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MOVIALFA "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Buscar_SECUENCIA_MAXINA_X_MOVIALFA")
            Return Nothing
        End Try

    End Function

End Class
