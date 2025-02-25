Imports DATOS

Public Class cla_RESOVALO

    '==================================
    '*** RESOLUCION DE VALORIZACION ***
    '==================================

    ''' <summary>
    ''' procedimiento que verifica la llave primaria.
    ''' </summary>
    Public Function fun_Verifica_llave_Primaria_RESOVALO(ByVal obREVADEPA As Object, _
                                                         ByVal obREVAMUNI As Object, _
                                                         ByVal obREVACLSE As Object, _
                                                         ByVal obREVAPROY As Object, _
                                                         ByVal obREVADECR As Object, _
                                                         ByVal obREVATIRE As Object, _
                                                         ByVal obREVAVIGE As Object) As Boolean

        Try
            Dim boRespuesta As Boolean = False

            Dim obVerifica As New cla_Verificar_Dato

            If obVerifica.fun_Verificar_Campo_Lleno(obREVADEPA.SelectedValue) = True And _
                obVerifica.fun_Verificar_Campo_Lleno(obREVAMUNI.SelectedValue) = True And _
                obVerifica.fun_Verificar_Campo_Lleno(obREVACLSE.SelectedValue) = True And _
                obVerifica.fun_Verificar_Campo_Lleno(obREVAPROY.SelectedValue) = True And _
                obVerifica.fun_Verificar_Campo_Lleno(obREVATIRE.SelectedValue) = True And _
                obVerifica.fun_Verificar_Campo_Lleno(obREVAVIGE.SelectedValue) = True And _
                obVerifica.fun_Verificar_Campo_Lleno(obREVADECR.Text) = True Then

                If obVerifica.fun_Verificar_Dato_Numerico(obREVADEPA.SelectedValue) = True And _
                    obVerifica.fun_Verificar_Dato_Numerico(obREVAMUNI.SelectedValue) = True And _
                    obVerifica.fun_Verificar_Dato_Numerico(obREVACLSE.SelectedValue) = True And _
                    obVerifica.fun_Verificar_Dato_Numerico(obREVAPROY.SelectedValue) = True And _
                    obVerifica.fun_Verificar_Dato_Numerico(obREVATIRE.SelectedValue) = True And _
                    obVerifica.fun_Verificar_Dato_Numerico(obREVAVIGE.SelectedValue) = True And _
                    obVerifica.fun_Verificar_Dato_Numerico(obREVADECR.Text) = True Then

                    Dim objdatos1 As New cla_RESOVALO
                    Dim tbl As New DataTable

                    tbl = objdatos1.fun_Buscar_CODIGO_RESOVALO(obREVADEPA.SelectedValue, _
                                                               obREVAMUNI.SelectedValue, _
                                                               obREVACLSE.SelectedValue, _
                                                               obREVAPROY.SelectedValue, _
                                                               Trim(obREVADECR.Text), _
                                                               obREVATIRE.SelectedValue, _
                                                               obREVAVIGE.SelectedValue)

                    If tbl.Rows.Count > 0 Then
                        MessageBox.Show("El dato " & obREVADECR.Text & " del campo " & obREVADECR.AccessibleDescription & " existe en la base de datos.", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                        obREVADEPA.Focus()
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
    Public Function fun_Insertar_RESOVALO(ByVal stREVADEPA As String, _
                                          ByVal stREVAMUNI As String, _
                                          ByVal inREVACLSE As Integer, _
                                          ByVal inREVAPROY As Integer, _
                                          ByVal inREVADECR As Integer, _
                                          ByVal inREVATIRE As Integer, _
                                          ByVal inREVAVIGE As Integer, _
                                          ByVal stREVADESC As String, _
                                          ByVal stREVAESTA As String, _
                                          ByVal stREVACONT As String, _
                                          ByVal boREVARETO As Boolean, _
                                          ByVal boREVAREPA As Boolean, _
                                          ByVal stREVAFECH As String) As Boolean

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' TITRatena la consulta
            stConsultaSQL += "INSERT INTO "
            stConsultaSQL += "RESOVALO "

            stConsultaSQL += "( "
            stConsultaSQL += "REVADEPA, "
            stConsultaSQL += "REVAMUNI, "
            stConsultaSQL += "REVACLSE, "
            stConsultaSQL += "REVAPROY, "
            stConsultaSQL += "REVADECR, "
            stConsultaSQL += "REVATIRE, "
            stConsultaSQL += "REVAVIGE, "
            stConsultaSQL += "REVADESC, "
            stConsultaSQL += "REVAESTA, "
            stConsultaSQL += "REVACONT, "
            stConsultaSQL += "REVARETO, "
            stConsultaSQL += "REVAREPA, "
            stConsultaSQL += "REVAFECH "
            stConsultaSQL += ") "

            stConsultaSQL += "VALUES "

            stConsultaSQL += "( "
            stConsultaSQL += "'" & CStr(Trim(stREVADEPA)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stREVAMUNI)) & "', "
            stConsultaSQL += "'" & CInt(inREVACLSE) & "', "
            stConsultaSQL += "'" & CInt(inREVAPROY) & "', "
            stConsultaSQL += "'" & CInt(inREVADECR) & "', "
            stConsultaSQL += "'" & CInt(inREVATIRE) & "', "
            stConsultaSQL += "'" & CInt(inREVAVIGE) & "', "
            stConsultaSQL += "'" & CStr(Trim(stREVADESC)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stREVAESTA)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stREVACONT)) & "', "
            stConsultaSQL += "'" & CBool(boREVARETO) & "', "
            stConsultaSQL += "'" & CBool(boREVAREPA) & "', "
            stConsultaSQL += "'" & CStr(Trim(stREVAFECH)) & "' "
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
            MessageBox.Show(Err.Description & " " & "fun_Insertar_RESOVALO")
        End Try

    End Function

    ''' <summary>
    ''' Función que Elimina el registro.
    ''' </summary>
    Public Function fun_Eliminar_RESOVALO(ByVal inREVAIDRE As Integer) As Boolean

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' TITRatena la consulta
            stConsultaSQL += "DELETE "
            stConsultaSQL += "RESOVALO "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "REVAIDRE = '" & CInt(inREVAIDRE) & "' "

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
            MessageBox.Show(Err.Description & " " & "fun_Eliminar_RESOVALO")
        End Try

    End Function

    ''' <summary>
    ''' Función que Modifica el registro.
    ''' </summary>
    Public Function fun_Actualizar_RESOVALO(ByVal inREVAIDRE As Integer, _
                                            ByVal stREVADEPA As String, _
                                            ByVal stREVAMUNI As String, _
                                            ByVal inREVACLSE As Integer, _
                                            ByVal inREVAPROY As Integer, _
                                            ByVal inREVADECR As Integer, _
                                            ByVal inREVATIRE As Integer, _
                                            ByVal inREVAVIGE As Integer, _
                                            ByVal stREVADESC As String, _
                                            ByVal stREVAESTA As String, _
                                            ByVal boREVARETO As Boolean, _
                                            ByVal boREVAREPA As Boolean, _
                                            ByVal stREVAFECH As String) As Boolean

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' TITRatena la consulta
            stConsultaSQL += "UPDATE "
            stConsultaSQL += "RESOVALO "

            stConsultaSQL += "SET "
            stConsultaSQL += "REVADEPA = '" & CStr(Trim(stREVADEPA)) & "', "
            stConsultaSQL += "REVAMUNI = '" & CStr(Trim(stREVAMUNI)) & "', "
            stConsultaSQL += "REVACLSE = '" & CInt(inREVACLSE) & "', "
            stConsultaSQL += "REVAPROY = '" & CInt(inREVAPROY) & "', "
            stConsultaSQL += "REVADECR = '" & CInt(inREVADECR) & "', "
            stConsultaSQL += "REVATIRE = '" & CInt(inREVATIRE) & "', "
            stConsultaSQL += "REVAVIGE = '" & CInt(inREVAVIGE) & "', "
            stConsultaSQL += "REVADESC = '" & CStr(Trim(stREVADESC)) & "', "
            stConsultaSQL += "REVAESTA = '" & CStr(Trim(stREVAESTA)) & "', "
            stConsultaSQL += "REVARETO = '" & CBool(boREVARETO) & "', "
            stConsultaSQL += "REVAREPA = '" & CBool(boREVAREPA) & "', "
            stConsultaSQL += "REVAFECH = '" & CStr(Trim(stREVAFECH)) & "' "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "REVAIDRE = '" & CInt(inREVAIDRE) & "'"

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
            MessageBox.Show(Err.Description & " " & "fun_Actualizar_RESOVALO")
        End Try

    End Function

    ''' <summary>
    ''' Consulta para llenar el DataGridView y colocar el nombre del encabezado
    ''' de la columna. 
    ''' </summary>
    Public Function fun_Consultar_RESOVALO() As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' TITRatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "REVAIDRE, "
            stConsultaSQL += "REVADEPA, "
            stConsultaSQL += "DEPADESC, "
            stConsultaSQL += "REVAMUNI, "
            stConsultaSQL += "MUNIDESC, "
            stConsultaSQL += "REVACLSE, "
            stConsultaSQL += "CLSEDESC, "
            stConsultaSQL += "REVAPROY, "
            stConsultaSQL += "PROYDESC, "
            stConsultaSQL += "REVADECR, "
            stConsultaSQL += "REVATIRE, "
            stConsultaSQL += "TIREDESC, "
            stConsultaSQL += "REVAVIGE, "
            stConsultaSQL += "VIGEDESC, "
            stConsultaSQL += "REVADESC, "
            stConsultaSQL += "REVAESTA, "
            stConsultaSQL += "ESTADESC, "
            stConsultaSQL += "REVACONT, "
            stConsultaSQL += "REVARETO, "
            stConsultaSQL += "REVAREPA, "
            stConsultaSQL += "REVAFECH "

            stConsultaSQL += "FROM "
            stConsultaSQL += "RESOVALO, "
            stConsultaSQL += "MANT_DEPARTAMENTO, "
            stConsultaSQL += "MANT_MUNICIPIO, "
            stConsultaSQL += "MANT_CLASSECT, "
            stConsultaSQL += "PROYECTO, "
            stConsultaSQL += "MANT_TIPORESO, "
            stConsultaSQL += "VIGENCIA, "
            stConsultaSQL += "ESTADO "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "DEPACODI = REVADEPA AND "
            stConsultaSQL += "MUNIDEPA = REVADEPA AND "
            stConsultaSQL += "MUNICODI = REVAMUNI AND "
            stConsultaSQL += "CLSECODI = REVACLSE AND "
            stConsultaSQL += "PROYDEPA = REVADEPA AND "
            stConsultaSQL += "PROYMUNI = REVAMUNI AND "
            stConsultaSQL += "PROYCLSE = REVACLSE AND "
            stConsultaSQL += "PROYCODI = REVAPROY AND "
            stConsultaSQL += "TIRECODI = REVATIRE AND "
            stConsultaSQL += "VIGECODI = REVAVIGE AND "
            stConsultaSQL += "ESTACODI = PROYESTA "

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "REVADEPA, REVAMUNI, REVACLSE, REVAPROY "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Consultar_RESOVALO")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Llena el ComboBox con datos activos e inactivos formulario principal 
    ''' esta funcion se llama desde el procedimiento "pro_inicializarControles()".
    ''' </summary>
    Public Function fun_Consultar_CAMPOS_RESOVALO() As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' TITRatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "RESOVALO "

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "REVADEPA, REVAMUNI, REVACLSE, REVAPROY "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Consultar_CAMPOS_RESOVALO")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Llena el ComboBox con datos activos formulario insertar y modificar 
    ''' esta funcion se llama desde el procedimiento "pro_inicializarControles()".
    ''' </summary>
    Public Function fun_Consultar_RESOVALO_X_ESTADO() As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' TITRatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "RESOVALO "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "REVAESTA = 'ac' "

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "REVADEPA, REVAMUNI, REVACLSE, REVAPROY "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Consultar_RESOVALO_X_ESTADO")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que busca el ID del registro a modificar o eliminar.
    ''' </summary>
    Public Function fun_Buscar_ID_RESOVALO(ByVal inREVAIDRE As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' TITRatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "RESOVALO "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "REVAIDRE = '" & CInt(inREVAIDRE) & "'"

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Buscar_ID_RESOVALO")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que busca el CÓDIGO DE LA CALIDAD DE PROPIETARIO para que no se 
    ''' guarden registros duplicados.
    ''' </summary>
    Public Function fun_Buscar_CODIGO_RESOVALO(ByVal stREVADEPA As String, _
                                               ByVal stREVAMUNI As String, _
                                               ByVal inREVACLSE As Integer, _
                                               ByVal inREVAPROY As Integer, _
                                               ByVal inREVADECR As Integer, _
                                               ByVal inREVATIRE As Integer, _
                                               ByVal inREVAVIGE As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' TITRatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "RESOVALO "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "REVADEPA = '" & CStr(Trim(stREVADEPA)) & "' and "
            stConsultaSQL += "REVAMUNI = '" & CStr(Trim(stREVAMUNI)) & "' and "
            stConsultaSQL += "REVACLSE = '" & CInt(inREVACLSE) & "' and "
            stConsultaSQL += "REVAPROY = '" & CInt(inREVAPROY) & "' and "
            stConsultaSQL += "REVADECR = '" & CInt(inREVADECR) & "' and "
            stConsultaSQL += "REVATIRE = '" & CInt(inREVATIRE) & "' and "
            stConsultaSQL += "REVAVIGE = '" & CInt(inREVAVIGE) & "' "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Buscar_CODIGO_RESOVALO")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que busca el ID del codigo buscado para ejecutar la consulta
    ''' parametrizada.
    ''' </summary>
    Public Function fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_RESOVALO(ByVal inREVAIDRE As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' TITRatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "REVAIDRE, "
            stConsultaSQL += "REVADEPA, "
            stConsultaSQL += "DEPADESC, "
            stConsultaSQL += "REVAMUNI, "
            stConsultaSQL += "MUNIDESC, "
            stConsultaSQL += "REVACLSE, "
            stConsultaSQL += "CLSEDESC, "
            stConsultaSQL += "REVAPROY, "
            stConsultaSQL += "PROYDESC, "
            stConsultaSQL += "REVADECR, "
            stConsultaSQL += "REVATIRE, "
            stConsultaSQL += "TIREDESC, "
            stConsultaSQL += "REVAVIGE, "
            stConsultaSQL += "VIGEDESC, "
            stConsultaSQL += "REVADESC, "
            stConsultaSQL += "REVAESTA, "
            stConsultaSQL += "ESTADESC, "
            stConsultaSQL += "REVACONT, "
            stConsultaSQL += "REVARETO, "
            stConsultaSQL += "REVAREPA, "
            stConsultaSQL += "REVAFECH "

            stConsultaSQL += "FROM "
            stConsultaSQL += "RESOVALO, "
            stConsultaSQL += "MANT_DEPARTAMENTO, "
            stConsultaSQL += "MANT_MUNICIPIO, "
            stConsultaSQL += "MANT_CLASSECT, "
            stConsultaSQL += "PROYECTO, "
            stConsultaSQL += "MANT_TIPORESO, "
            stConsultaSQL += "VIGENCIA, "
            stConsultaSQL += "ESTADO "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "DEPACODI = REVADEPA AND "
            stConsultaSQL += "MUNIDEPA = REVADEPA AND "
            stConsultaSQL += "MUNICODI = REVAMUNI AND "
            stConsultaSQL += "CLSECODI = REVACLSE AND "
            stConsultaSQL += "PROYDEPA = REVADEPA AND "
            stConsultaSQL += "PROYMUNI = REVAMUNI AND "
            stConsultaSQL += "PROYCLSE = REVACLSE AND "
            stConsultaSQL += "PROYCODI = REVAPROY AND "
            stConsultaSQL += "TIRECODI = REVATIRE AND "
            stConsultaSQL += "VIGECODI = REVAVIGE AND "
            stConsultaSQL += "ESTACODI = PROYESTA AND "
            stConsultaSQL += "REVAIDRE = '" & CInt(inREVAIDRE) & "'"

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "REVADEPA, REVAMUNI, REVACLSE, REVAPROY "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception

            MessageBox.Show(Err.Description & " " & "fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_RESOVALO")
            Return Nothing

        End Try

    End Function

End Class
