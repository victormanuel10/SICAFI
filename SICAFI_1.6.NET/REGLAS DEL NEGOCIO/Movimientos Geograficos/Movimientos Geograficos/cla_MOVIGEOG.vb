Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration
Imports DATOS

Public Class cla_MOVIGEOG

    '===================================
    '*** CLASE MOVIMIENTO GEOGRAFICO ***
    '===================================

    ''' <summary>
    ''' procedimiento que verifica la llave primaria.
    ''' </summary>
    Public Function fun_Verifica_llave_Primaria_MOVIGEOG(ByVal obMOGEMUNI As Object, _
                                                         ByVal obMOGECORR As Object, _
                                                         ByVal obMOGEBARR As Object, _
                                                         ByVal obMOGEMANZ As Object, _
                                                         ByVal obMOGEPRED As Object, _
                                                         ByVal obMOGECLSE As Object, _
                                                         ByVal obMOGEVIGE As Object) As Boolean

        Try
            Dim boRespuesta As Boolean = False

            Dim obVerifica As New cla_Verificar_Dato

            If obVerifica.fun_Verificar_Campo_Lleno(obMOGEMUNI.Text) = True And _
                obVerifica.fun_Verificar_Campo_Lleno(obMOGECORR.Text) = True And _
                obVerifica.fun_Verificar_Campo_Lleno(obMOGEBARR.Text) = True And _
                obVerifica.fun_Verificar_Campo_Lleno(obMOGEMANZ.Text) = True And _
                obVerifica.fun_Verificar_Campo_Lleno(obMOGEPRED.Text) = True And _
                obVerifica.fun_Verificar_Campo_Lleno(obMOGECLSE.SelectedValue) = True And _
                obVerifica.fun_Verificar_Campo_Lleno(obMOGEVIGE.SelectedValue) = True Then

                If obVerifica.fun_Verificar_Dato_Numerico(obMOGEMUNI.Text) = True And _
                    obVerifica.fun_Verificar_Dato_Numerico(obMOGECORR.Text) = True And _
                    obVerifica.fun_Verificar_Dato_Numerico(obMOGEBARR.Text) = True And _
                    obVerifica.fun_Verificar_Dato_Numerico(obMOGEMANZ.Text) = True And _
                    obVerifica.fun_Verificar_Dato_Numerico(obMOGEPRED.Text) = True And _
                    obVerifica.fun_Verificar_Dato_Numerico(obMOGECLSE.SelectedValue) = True And _
                    obVerifica.fun_Verificar_Dato_Numerico(obMOGEVIGE.SelectedValue) = True Then

                    Dim objdatos1 As New cla_MOVIGEOG
                    Dim tbl As New DataTable

                    tbl = objdatos1.fun_Buscar_CODIGO_X_MOVIGEOG(obMOGEMUNI.Text, _
                                                                 obMOGECORR.Text, _
                                                                 obMOGEBARR.Text, _
                                                                 obMOGEMANZ.Text, _
                                                                 obMOGEPRED.Text, _
                                                                 obMOGECLSE.SelectedValue, _
                                                                 obMOGEVIGE.SelectedValue)

                    If tbl.Rows.Count > 0 Then
                        MessageBox.Show("El registro existe en la base de datos.", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1)
                        obMOGEMUNI.Focus()
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
    Public Function fun_Insertar_MOVIGEOG(ByVal inMOGESECU As Integer, _
                                          ByVal stMOGEMUNI As String, _
                                          ByVal stMOGECORR As String, _
                                          ByVal stMOGEBARR As String, _
                                          ByVal stMOGEMANZ As String, _
                                          ByVal stMOGEPRED As String, _
                                          ByVal inMOGECLSE As Integer, _
                                          ByVal inMOGEVIGE As Integer, _
                                          ByVal stMOGENUDO As String, _
                                          ByVal stMOGEUSUA As String, _
                                          ByVal stMOGEFEAS As String, _
                                          ByVal stMOGECAAC As String, _
                                          ByVal inMOGECLVE As Integer, _
                                          ByVal stMOGEFFMU As String, _
                                          ByVal stMOGEOBSE As String, _
                                          ByVal stMOGEESTA As String) As Boolean
        Try

            ' variables 
            Dim stMOGEDEPA As String = "05"

            '' *** INSTANCIA LA FECHA Y HORA ***
            Dim daMOGEFEIN As Date = fun_fecha()

            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "INSERT INTO "
            stConsultaSQL += "MOVIGEOG "

            stConsultaSQL += "( "
            stConsultaSQL += "MOGESECU, "
            stConsultaSQL += "MOGEDEPA, "
            stConsultaSQL += "MOGEMUNI, "
            stConsultaSQL += "MOGECORR, "
            stConsultaSQL += "MOGEBARR, "
            stConsultaSQL += "MOGEMANZ, "
            stConsultaSQL += "MOGEPRED, "
            stConsultaSQL += "MOGECLSE, "
            stConsultaSQL += "MOGEVIGE, "
            stConsultaSQL += "MOGENUDO, "
            stConsultaSQL += "MOGEUSUA, "
            stConsultaSQL += "MOGEFEAS, "
            stConsultaSQL += "MOGECAAC, "
            stConsultaSQL += "MOGECLVE, "
            stConsultaSQL += "MOGEFFMU, "
            stConsultaSQL += "MOGEOBSE, "
            stConsultaSQL += "MOGEESTA, "
            stConsultaSQL += "MOGEFEIN  "

            stConsultaSQL += ") "

            stConsultaSQL += "VALUES "

            stConsultaSQL += "( "
            stConsultaSQL += "'" & CInt(inMOGESECU) & "', "
            stConsultaSQL += "'" & CStr(Trim(stMOGEDEPA)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stMOGEMUNI)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stMOGECORR)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stMOGEBARR)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stMOGEMANZ)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stMOGEPRED)) & "', "
            stConsultaSQL += "'" & CInt(inMOGECLSE) & "', "
            stConsultaSQL += "'" & CInt(inMOGEVIGE) & "', "
            stConsultaSQL += "'" & CStr(Trim(stMOGENUDO)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stMOGEUSUA)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stMOGEFEAS)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stMOGECAAC)) & "', "
            stConsultaSQL += "'" & CInt(inMOGECLVE) & "', "
            stConsultaSQL += "'" & CStr(Trim(stMOGEFFMU)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stMOGEOBSE)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stMOGEESTA)) & "', "
            stConsultaSQL += "'" & CDate(daMOGEFEIN) & "' "
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
            MessageBox.Show(Err.Description & " " & "fun_Insertar_MOVIGEOG")
        End Try

    End Function

    ''' <summary>
    ''' Función que Elimina el registro.
    ''' </summary>
    Public Function fun_Eliminar_IDRE_MOVIGEOG(ByVal inMOGEIDRE As Integer) As Boolean

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "DELETE "
            stConsultaSQL += "MOVIGEOG "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "MOGEIDRE = '" & CInt(inMOGEIDRE) & "' "

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
            MessageBox.Show(Err.Description & " " & "fun_Eliminar_MOVIGEOG")
        End Try

    End Function

    ''' <summary>
    ''' Función que Elimina el registro.
    ''' </summary>
    Public Function fun_Eliminar_SECU_MOVIGEOG(ByVal inMOGESECU As Integer) As Boolean

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "DELETE "
            stConsultaSQL += "MOVIGEOG "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "MOGESECU = '" & CInt(inMOGESECU) & "' "

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
            MessageBox.Show(Err.Description & " " & "fun_Eliminar_MOVIGEOG")
        End Try

    End Function

    ''' <summary>
    ''' Función que Modifica el registro.
    ''' </summary>
    Public Function fun_Actualizar_MOVIGEOG(ByVal inMOGEIDRE As Integer, _
                                            ByVal inMOGESECU As Integer, _
                                            ByVal stMOGEMUNI As String, _
                                            ByVal stMOGECORR As String, _
                                            ByVal stMOGEBARR As String, _
                                            ByVal stMOGEMANZ As String, _
                                            ByVal stMOGEPRED As String, _
                                            ByVal inMOGECLSE As Integer, _
                                            ByVal inMOGEVIGE As Integer, _
                                            ByVal stMOGENUDO As String, _
                                            ByVal stMOGEUSUA As String, _
                                            ByVal stMOGECAAC As String, _
                                            ByVal inMOGECLVE As Integer, _
                                            ByVal stMOGEOBSE As String, _
                                            ByVal stMOGEESTA As String) As Boolean

        Try
            ' variables
            Dim stMOGEDEPA As String = "05"

            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "UPDATE "
            stConsultaSQL += "MOVIGEOG "

            stConsultaSQL += "SET "
            stConsultaSQL += "MOGESECU = '" & CInt(inMOGESECU) & "', "
            stConsultaSQL += "MOGEDEPA = '" & CStr(Trim(stMOGEDEPA)) & "', "
            stConsultaSQL += "MOGEMUNI = '" & CStr(Trim(stMOGEMUNI)) & "', "
            stConsultaSQL += "MOGECORR = '" & CStr(Trim(stMOGECORR)) & "', "
            stConsultaSQL += "MOGEBARR = '" & CStr(Trim(stMOGEBARR)) & "', "
            stConsultaSQL += "MOGEMANZ = '" & CStr(Trim(stMOGEMANZ)) & "', "
            stConsultaSQL += "MOGEPRED = '" & CStr(Trim(stMOGEPRED)) & "', "
            stConsultaSQL += "MOGECLSE = '" & CInt(inMOGECLSE) & "', "
            stConsultaSQL += "MOGEVIGE = '" & CInt(inMOGEVIGE) & "', "
            stConsultaSQL += "MOGENUDO = '" & CStr(Trim(stMOGENUDO)) & "', "
            stConsultaSQL += "MOGEUSUA = '" & CStr(Trim(stMOGEUSUA)) & "', "
            stConsultaSQL += "MOGECAAC = '" & CStr(Trim(stMOGECAAC)) & "', "
            stConsultaSQL += "MOGECLVE = '" & CInt(inMOGECLVE) & "', "
            stConsultaSQL += "MOGEOBSE = '" & CStr(Trim(stMOGEOBSE)) & "', "
            stConsultaSQL += "MOGEESTA = '" & CStr(Trim(stMOGEESTA)) & "' "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "MOGEIDRE = '" & CInt(inMOGEIDRE) & "'"

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
            MessageBox.Show(Err.Description & " " & "fun_Actualizar_MOVIGEOG")
        End Try

    End Function

    ''' <summary>
    ''' Función que Modifica el registro.
    ''' </summary>
    Public Function fun_Actualizar_MOVIGEOG(ByVal inMOGEIDRE As Integer, _
                                            ByVal inMOGESECU As Integer, _
                                            ByVal stMOGEMUNI As String, _
                                            ByVal stMOGECORR As String, _
                                            ByVal stMOGEBARR As String, _
                                            ByVal stMOGEMANZ As String, _
                                            ByVal stMOGEPRED As String, _
                                            ByVal inMOGECLSE As Integer, _
                                            ByVal inMOGEVIGE As Integer, _
                                            ByVal stMOGENUDO As String, _
                                            ByVal stMOGEUSUA As String, _
                                            ByVal stMOGECAAC As String, _
                                            ByVal stMOGEFEEN As String, _
                                            ByVal inMOGECLVE As Integer, _
                                            ByVal stMOGEOBSE As String, _
                                            ByVal stMOGEESTA As String) As Boolean

        Try
            ' variables
            Dim stMOGEDEPA As String = "05"

            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "UPDATE "
            stConsultaSQL += "MOVIGEOG "

            stConsultaSQL += "SET "
            stConsultaSQL += "MOGESECU = '" & CInt(inMOGESECU) & "', "
            stConsultaSQL += "MOGEDEPA = '" & CStr(Trim(stMOGEDEPA)) & "', "
            stConsultaSQL += "MOGEMUNI = '" & CStr(Trim(stMOGEMUNI)) & "', "
            stConsultaSQL += "MOGECORR = '" & CStr(Trim(stMOGECORR)) & "', "
            stConsultaSQL += "MOGEBARR = '" & CStr(Trim(stMOGEBARR)) & "', "
            stConsultaSQL += "MOGEMANZ = '" & CStr(Trim(stMOGEMANZ)) & "', "
            stConsultaSQL += "MOGEPRED = '" & CStr(Trim(stMOGEPRED)) & "', "
            stConsultaSQL += "MOGECLSE = '" & CInt(inMOGECLSE) & "', "
            stConsultaSQL += "MOGEVIGE = '" & CInt(inMOGEVIGE) & "', "
            stConsultaSQL += "MOGENUDO = '" & CStr(Trim(stMOGENUDO)) & "', "
            stConsultaSQL += "MOGEUSUA = '" & CStr(Trim(stMOGEUSUA)) & "', "
            stConsultaSQL += "MOGECAAC = '" & CStr(Trim(stMOGECAAC)) & "', "
            stConsultaSQL += "MOGEFEAS = '" & CStr(Trim(stMOGEFEEN)) & "', "
            stConsultaSQL += "MOGEFFMU = '" & CStr(Trim("")) & "', "
            stConsultaSQL += "MOGECLVE = '" & CInt(inMOGECLVE) & "', "
            stConsultaSQL += "MOGEOBSE = '" & CStr(Trim(stMOGEOBSE)) & "', "
            stConsultaSQL += "MOGEESTA = '" & CStr(Trim(stMOGEESTA)) & "' "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "MOGEIDRE = '" & CInt(inMOGEIDRE) & "'"

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
            MessageBox.Show(Err.Description & " " & "fun_Actualizar_MOVIGEOG")
        End Try

    End Function

    ''' <summary>
    ''' Consulta para llenar el DataGridView y colocar el nombre del encabezado
    ''' de la columna. 
    ''' </summary>
    Public Function fun_Consultar_MOVIGEOG(ByVal boReconsultar As Boolean) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "

            If boReconsultar = False Then
                stConsultaSQL += "TOP 1 "
            End If

            stConsultaSQL += "MOGEIDRE, "
            stConsultaSQL += "MOGESECU, "
            stConsultaSQL += "MOGEDEPA, "
            stConsultaSQL += "MOGEMUNI, "
            stConsultaSQL += "MOGECORR, "
            stConsultaSQL += "MOGEBARR, "
            stConsultaSQL += "MOGEMANZ, "
            stConsultaSQL += "MOGEPRED, "
            stConsultaSQL += "MOGECLSE, "
            stConsultaSQL += "CLSEDESC, "
            stConsultaSQL += "MOGEVIGE, "
            stConsultaSQL += "MOGENUDO, "
            stConsultaSQL += "MOGEUSUA, "
            stConsultaSQL += "MOGEFEAS, "
            stConsultaSQL += "MOGECAAC, "
            stConsultaSQL += "MOGECLVE, "
            stConsultaSQL += "MOGEFFMU, "
            stConsultaSQL += "MOGEOBSE, "
            stConsultaSQL += "MOGEESTA, "
            stConsultaSQL += "MOGEFEIN, "
            stConsultaSQL += "ESTADESC "


            stConsultaSQL += "FROM "
            stConsultaSQL += "MOVIGEOG, ESTADO, MANT_CLASSECT "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "MOGEESTA = ESTACODI AND "
            stConsultaSQL += "MOGECLSE = CLSECODI "

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "MOGECLSE, MOGEDEPA, MOGECORR, MOGEBARR, MOGEMANZ, MOGEPRED "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Consultar_MOVIGEOG")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Llena el ComboBox con datos activos e inactivos formulario principal 
    ''' esta funcion se llama desde el procedimiento "pro_inicializarControles()".
    ''' </summary>
    Public Function fun_Consultar_CAMPOS_MOVIGEOG() As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MOVIGEOG "

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "MOGECLSE, MOGEDEPA, MOGECORR, MOGEBARR, MOGEMANZ, MOGEPRED "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Consultar_CAMPOS_MOVIGEOG")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Llena el ComboBox con datos activos formulario insertar y modificar 
    ''' esta funcion se llama desde el procedimiento "pro_inicializarControles()".
    ''' </summary>
    Public Function fun_Consultar_MOVIGEOG_X_ESTADO() As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MOVIGEOG "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "MOGEESTA = 'ac' "

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "MOGECLSE, MOGEDEPA, MOGECORR, MOGEBARR, MOGEMANZ, MOGEPRED "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Consultar_MOVIGEOG_X_ESTADO")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que busca el ID del registro a modificar o eliminar.
    ''' </summary>
    Public Function fun_Buscar_ID_MOVIGEOG(ByVal inMOGEIDRE As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MOVIGEOG "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "MOGEIDRE = '" & CInt(inMOGEIDRE) & "'"

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Buscar_ID_MOVIGEOG")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que busca el CÓDIGO para que no se 
    ''' guarden registros duplicados.
    ''' </summary>
    Public Function fun_Buscar_CODIGO_X_MOVIGEOG(ByVal inMOGESECU As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MOVIGEOG "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "MOGESECU = '" & CInt(inMOGESECU) & "' "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Buscar_CODIGO_MOVIGEOG")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que busca el CÓDIGO para que no se 
    ''' guarden registros duplicados.
    ''' </summary>
    Public Function fun_Buscar_CODIGO_X_MOVIGEOG(ByVal stMOGEMUNI As String, _
                                                 ByVal stMOGECORR As String, _
                                                 ByVal stMOGEBARR As String, _
                                                 ByVal stMOGEMANZ As String, _
                                                 ByVal stMOGEPRED As String, _
                                                 ByVal inMOGECLSE As Integer, _
                                                 ByVal inMOGEVIGE As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MOVIGEOG "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "MOGEMUNI = '" & CStr(Trim(stMOGEMUNI)) & "' and "
            stConsultaSQL += "MOGECORR = '" & CStr(Trim(stMOGECORR)) & "' and "
            stConsultaSQL += "MOGEBARR = '" & CStr(Trim(stMOGEBARR)) & "' and "
            stConsultaSQL += "MOGEMANZ = '" & CStr(Trim(stMOGEMANZ)) & "' and "
            stConsultaSQL += "MOGEPRED = '" & CStr(Trim(stMOGEPRED)) & "' and "
            stConsultaSQL += "MOGECLSE = '" & CStr(Trim(inMOGECLSE)) & "' and "
            stConsultaSQL += "MOGEVIGE = '" & CInt(inMOGEVIGE) & "' "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Buscar_CODIGO_MOVIGEOG")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que busca el ID del codigo buscado para ejecutar la consulta
    ''' parametrizada.
    ''' </summary>
    Public Function fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_MOVIGEOG(ByVal inMOGEIDRE As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "TOP 1 "
            stConsultaSQL += "MOGEIDRE, "
            stConsultaSQL += "MOGESECU, "
            stConsultaSQL += "MOGEDEPA, "
            stConsultaSQL += "MOGEMUNI, "
            stConsultaSQL += "MOGECORR, "
            stConsultaSQL += "MOGEBARR, "
            stConsultaSQL += "MOGEMANZ, "
            stConsultaSQL += "MOGEPRED, "
            stConsultaSQL += "MOGECLSE, "
            stConsultaSQL += "CLSEDESC, "
            stConsultaSQL += "MOGEVIGE, "
            stConsultaSQL += "MOGENUDO, "
            stConsultaSQL += "MOGEUSUA, "
            stConsultaSQL += "MOGEFEAS, "
            stConsultaSQL += "MOGECAAC, "
            stConsultaSQL += "MOGECLVE, "
            stConsultaSQL += "MOGEFFMU, "
            stConsultaSQL += "MOGEOBSE, "
            stConsultaSQL += "MOGEESTA, "
            stConsultaSQL += "MOGEFEIN, "
            stConsultaSQL += "ESTADESC "


            stConsultaSQL += "FROM "
            stConsultaSQL += "MOVIGEOG, ESTADO, MANT_CLASSECT "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "MOGEESTA = ESTACODI and "
            stConsultaSQL += "MOGECLSE = CLSECODI and "
            stConsultaSQL += "MOGEIDRE = '" & CInt(inMOGEIDRE) & "' "

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "MOGECLSE, MOGEDEPA, MOGECORR, MOGEBARR, MOGEMANZ, MOGEPRED "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception

            MessageBox.Show(Err.Description & " " & "fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_MOVIGEOG")
            Return Nothing

        End Try

    End Function

    Public Function fun_Buscar_CONSULTA_MOVIGEOG_X_USUARIO(ByVal stMOGENUDO As String) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "MOGEIDRE, "
            stConsultaSQL += "MOGESECU, "
            stConsultaSQL += "MOGEDEPA, "
            stConsultaSQL += "MOGEMUNI, "
            stConsultaSQL += "MOGECORR, "
            stConsultaSQL += "MOGEBARR, "
            stConsultaSQL += "MOGEMANZ, "
            stConsultaSQL += "MOGEPRED, "
            stConsultaSQL += "MOGECLSE, "
            stConsultaSQL += "CLSEDESC, "
            stConsultaSQL += "MOGEVIGE, "
            stConsultaSQL += "MOGENUDO, "
            stConsultaSQL += "MOGEUSUA, "
            stConsultaSQL += "MOGEFEAS, "
            stConsultaSQL += "MOGECAAC, "
            stConsultaSQL += "MOGECLVE, "
            stConsultaSQL += "MOGEFFMU, "
            stConsultaSQL += "MOGEOBSE, "
            stConsultaSQL += "MOGEESTA, "
            stConsultaSQL += "MOGEFEIN, "
            stConsultaSQL += "ESTADESC "


            stConsultaSQL += "FROM "
            stConsultaSQL += "MOVIGEOG, ESTADO, MANT_CLASSECT "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "MOGEESTA = ESTACODI and "
            stConsultaSQL += "MOGECLSE = CLSECODI and "
            stConsultaSQL += "MOGEESTA = 'as' and "
            stConsultaSQL += "MOGENUDO = '" & CStr(Trim(stMOGENUDO)) & "' "

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "MOGECLSE, MOGEDEPA, MOGECORR, MOGEBARR, MOGEMANZ, MOGEPRED "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception

            MessageBox.Show(Err.Description & " " & "fun_Buscar_CONSULTA_MOVIGEOG_X_USUARIO")
            Return Nothing

        End Try

    End Function

    ''' <summary>
    ''' Función que busca el registro y usuario
    ''' </summary>
    Public Function fun_Buscar_CONSULTA_CEDULA_CATASTRAL_Y_USUARIO(ByVal stMOGEMUNI As String, _
                                                                   ByVal stMOGECORR As String, _
                                                                   ByVal stMOGEBARR As String, _
                                                                   ByVal stMOGEMANZ As String, _
                                                                   ByVal stMOGEPRED As String, _
                                                                   ByVal inMOGECLSE As Integer, _
                                                                   ByVal inMOGEVIGE As Integer, _
                                                                   ByVal stMOGEUSUA As String) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MOVIGEOG "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "MOGEMUNI = '" & CStr(Trim(stMOGEMUNI)) & "' AND "
            stConsultaSQL += "MOGECORR = '" & CStr(Trim(stMOGECORR)) & "' AND "
            stConsultaSQL += "MOGEBARR = '" & CStr(Trim(stMOGEBARR)) & "' AND "
            stConsultaSQL += "MOGEMANZ = '" & CStr(Trim(stMOGEMANZ)) & "' AND "
            stConsultaSQL += "MOGEPRED = '" & CStr(Trim(stMOGEPRED)) & "' AND "
            stConsultaSQL += "MOGECLSE = '" & CInt(inMOGECLSE) & "' AND "
            stConsultaSQL += "MOGEVIGE = '" & CInt(inMOGEVIGE) & "' AND "
            stConsultaSQL += "MOGEUSUA = '" & CStr(Trim(stMOGEUSUA)) & "' "

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "MOGECLSE, MOGEDEPA, MOGECORR, MOGEBARR, MOGEMANZ, MOGEPRED "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception

            MessageBox.Show(Err.Description & " " & "fun_Buscar_CONSULTA_MOVIGEOG_X_USUARIO")
            Return Nothing

        End Try

    End Function

    ''' <summary>
    ''' Función que busca la secuencia maxima
    ''' </summary>
    Public Function fun_Buscar_SECUENCIA_X_MOVIGEOG() As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "MOGESECU "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MOVIGEOG "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Buscar_SECUENCIA_MAXINA_X_MOVIGEOG")
            Return Nothing
        End Try

    End Function

End Class
