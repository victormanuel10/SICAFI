Imports DATOS

Public Class cla_PROYECTO

    '================
    '*** PROYECTO ***
    '================

    ''' <summary>
    ''' procedimiento que verifica la llave primaria.
    ''' </summary>
    Public Function fun_Verifica_llave_Primaria_PROYECTO(ByVal obPROYDEPA As Object, _
                                                         ByVal obPROYMUNI As Object, _
                                                         ByVal obPROYCLSE As Object, _
                                                         ByVal obPROYCODI As Object) As Boolean

        Try
            Dim boRespuesta As Boolean = False

            Dim obVerifica As New cla_Verificar_Dato

            If obVerifica.fun_Verificar_Campo_Lleno(obPROYCODI.Text) = True And _
               obVerifica.fun_Verificar_Campo_Lleno(obPROYDEPA.SelectedValue) = True And _
               obVerifica.fun_Verificar_Campo_Lleno(obPROYMUNI.SelectedValue) = True And _
               obVerifica.fun_Verificar_Campo_Lleno(obPROYCLSE.SelectedValue) = True Then

                If obVerifica.fun_Verificar_Dato_Numerico(obPROYCODI.Text) = True And _
                   obVerifica.fun_Verificar_Dato_Numerico(obPROYDEPA.SelectedValue) = True And _
                   obVerifica.fun_Verificar_Dato_Numerico(obPROYMUNI.SelectedValue) = True And _
                   obVerifica.fun_Verificar_Dato_Numerico(obPROYCLSE.SelectedValue) = True Then


                    Dim objdatos1 As New cla_PROYECTO
                    Dim tbl As New DataTable

                    tbl = objdatos1.fun_Buscar_CODIGO_PROYECTO(obPROYDEPA.SelectedValue, _
                                                               obPROYMUNI.SelectedValue, _
                                                               obPROYCLSE.SelectedValue, _
                                                               Trim(obPROYCODI.Text))

                    If tbl.Rows.Count > 0 Then
                        MessageBox.Show("El dato " & obPROYCODI.Text & " del campo " & obPROYCODI.AccessibleDescription & " existe en la base de datos.", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                        obPROYCODI.Focus()
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
    Public Function fun_Insertar_PROYECTO(ByVal stPROYDEPA As String, _
                                          ByVal stPROYMUNI As String, _
                                          ByVal inPROYCLSE As Integer, _
                                          ByVal inPROYCODI As Integer, _
                                          ByVal stPROYDESC As String, _
                                          ByVal stPROYESTA As String, _
                                          ByVal stPROYALCA As String, _
                                          ByVal stPROYRECU As String, _
                                          ByVal stPROYJUST As String, _
                                          ByVal stPROYOBJE As String, _
                                          ByVal stPROYFINA As String, _
                                          ByVal stPROYOBSE As String, _
                                          ByVal stPROYCONV As String, _
                                          ByVal stPROYCOMP As String, _
                                          ByVal stPROYNORM As String) As Boolean

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' PROYatena la consulta
            stConsultaSQL += "INSERT INTO "
            stConsultaSQL += "PROYECTO "

            stConsultaSQL += "( "
            stConsultaSQL += "PROYDEPA, "
            stConsultaSQL += "PROYMUNI, "
            stConsultaSQL += "PROYCLSE, "
            stConsultaSQL += "PROYCODI, "
            stConsultaSQL += "PROYDESC, "
            stConsultaSQL += "PROYESTA, "
            stConsultaSQL += "PROYALCA, "
            stConsultaSQL += "PROYRECU, "
            stConsultaSQL += "PROYJUST, "
            stConsultaSQL += "PROYOBJE, "
            stConsultaSQL += "PROYFINA, "
            stConsultaSQL += "PROYOBSE, "
            stConsultaSQL += "PROYCONV, "
            stConsultaSQL += "PROYCOMP, "
            stConsultaSQL += "PROYNORM "
            stConsultaSQL += ") "

            stConsultaSQL += "VALUES "

            stConsultaSQL += "( "
            stConsultaSQL += "'" & CStr(Trim(stPROYDEPA)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stPROYMUNI)) & "', "
            stConsultaSQL += "'" & CInt(inPROYCLSE) & "', "
            stConsultaSQL += "'" & CInt(inPROYCODI) & "', "
            stConsultaSQL += "'" & CStr(Trim(stPROYDESC)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stPROYESTA)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stPROYALCA)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stPROYRECU)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stPROYJUST)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stPROYOBJE)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stPROYFINA)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stPROYOBSE)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stPROYCONV)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stPROYCOMP)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stPROYNORM)) & "' "
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
            MessageBox.Show(Err.Description & " " & "fun_Insertar_PROYECTO")
        End Try

    End Function

    ''' <summary>
    ''' Función que Elimina el registro.
    ''' </summary>
    Public Function fun_Eliminar_PROYECTO(ByVal inPROYIDRE As Integer) As Boolean

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' PROYatena la consulta
            stConsultaSQL += "DELETE "
            stConsultaSQL += "PROYECTO "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "PROYIDRE = '" & CInt(inPROYIDRE) & "' "

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
            MessageBox.Show(Err.Description & " " & "fun_Eliminar_PROYECTO")
        End Try

    End Function

    ''' <summary>
    ''' Función que Modifica el registro.
    ''' </summary>
    Public Function fun_Actualizar_PROYECTO(ByVal inPROYIDRE As Integer, _
                                            ByVal stPROYDEPA As String, _
                                            ByVal stPROYMUNI As String, _
                                            ByVal inPROYCLSE As Integer, _
                                            ByVal inPROYCODI As Integer, _
                                            ByVal stPROYDESC As String, _
                                            ByVal stPROYESTA As String, _
                                            ByVal stPROYALCA As String, _
                                            ByVal stPROYRECU As String, _
                                            ByVal stPROYJUST As String, _
                                            ByVal stPROYOBJE As String, _
                                            ByVal stPROYFINA As String, _
                                            ByVal stPROYOBSE As String, _
                                            ByVal stPROYCONV As String, _
                                            ByVal stPROYCOMP As String, _
                                            ByVal stPROYNORM As String) As Boolean

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' PROYatena la consulta
            stConsultaSQL += "UPDATE "
            stConsultaSQL += "PROYECTO "

            stConsultaSQL += "SET "
            stConsultaSQL += "PROYDEPA = '" & CStr(Trim(stPROYDEPA)) & "', "
            stConsultaSQL += "PROYMUNI = '" & CStr(Trim(stPROYMUNI)) & "', "
            stConsultaSQL += "PROYCLSE = '" & CInt(inPROYCLSE) & "', "
            stConsultaSQL += "PROYCODI = '" & CInt(inPROYCODI) & "', "
            stConsultaSQL += "PROYDESC = '" & CStr(Trim(stPROYDESC)) & "', "
            stConsultaSQL += "PROYESTA = '" & CStr(Trim(stPROYESTA)) & "', "
            stConsultaSQL += "PROYALCA = '" & CStr(Trim(stPROYALCA)) & "', "
            stConsultaSQL += "PROYRECU = '" & CStr(Trim(stPROYRECU)) & "', "
            stConsultaSQL += "PROYJUST = '" & CStr(Trim(stPROYJUST)) & "', "
            stConsultaSQL += "PROYOBJE = '" & CStr(Trim(stPROYOBJE)) & "', "
            stConsultaSQL += "PROYFINA = '" & CStr(Trim(stPROYFINA)) & "', "
            stConsultaSQL += "PROYOBSE = '" & CStr(Trim(stPROYOBSE)) & "', "
            stConsultaSQL += "PROYCONV = '" & CStr(Trim(stPROYCONV)) & "', "
            stConsultaSQL += "PROYCOMP = '" & CStr(Trim(stPROYCOMP)) & "', "
            stConsultaSQL += "PROYNORM = '" & CStr(Trim(stPROYNORM)) & "' "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "PROYIDRE = '" & CInt(inPROYIDRE) & "'"

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
            MessageBox.Show(Err.Description & " " & "fun_Actualizar_PROYECTO")
        End Try

    End Function

    ''' <summary>
    ''' Consulta para llenar el DataGridView y colocar el nombre del encabezado
    ''' de la columna. 
    ''' </summary>
    Public Function fun_Consultar_PROYECTO() As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' PROYatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "PROYIDRE, "
            stConsultaSQL += "PROYDEPA, "
            stConsultaSQL += "DEPADESC, "
            stConsultaSQL += "PROYMUNI, "
            stConsultaSQL += "MUNIDESC, "
            stConsultaSQL += "PROYCLSE, "
            stConsultaSQL += "CLSEDESC, "
            stConsultaSQL += "PROYCODI, "
            stConsultaSQL += "PROYDESC, "
            stConsultaSQL += "PROYESTA, "
            stConsultaSQL += "ESTADESC, "
            stConsultaSQL += "PROYALCA, "
            stConsultaSQL += "PROYRECU, "
            stConsultaSQL += "PROYJUST, "
            stConsultaSQL += "PROYOBJE, "
            stConsultaSQL += "PROYFINA, "
            stConsultaSQL += "PROYOBSE, "
            stConsultaSQL += "PROYCONV, "
            stConsultaSQL += "PROYCOMP, "
            stConsultaSQL += "PROYNORM "


            stConsultaSQL += "FROM "
            stConsultaSQL += "PROYECTO, "
            stConsultaSQL += "MANT_DEPARTAMENTO, "
            stConsultaSQL += "MANT_MUNICIPIO, "
            stConsultaSQL += "MANT_CLASSECT, "
            stConsultaSQL += "ESTADO "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "DEPACODI = PROYDEPA AND "
            stConsultaSQL += "MUNIDEPA = PROYDEPA AND "
            stConsultaSQL += "MUNICODI = PROYMUNI AND "
            stConsultaSQL += "CLSECODI = PROYCLSE AND "
            stConsultaSQL += "ESTACODI = PROYESTA "

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "PROYDEPA, PROYMUNI, PROYCLSE, PROYCODI "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Consultar_PROYECTO")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Llena el ComboBox con datos activos e inactivos formulario principal 
    ''' esta funcion se llama desde el procedimiento "pro_inicializarControles()".
    ''' </summary>
    Public Function fun_Consultar_CAMPOS_PROYECTO() As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' PROYatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "PROYECTO "

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "PROYDEPA, PROYMUNI, PROYCLSE, PROYCODI "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Consultar_CAMPOS_PROYECTO")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Llena el ComboBox con datos activos formulario insertar y modificar 
    ''' esta funcion se llama desde el procedimiento "pro_inicializarControles()".
    ''' </summary>
    Public Function fun_Consultar_PROYECTO_X_ESTADO() As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' PROYatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "PROYECTO "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "PROYESTA = 'ac' "

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "PROYDEPA, PROYMUNI, PROYCLSE, PROYCODI "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Consultar_PROYECTO_X_ESTADO")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que busca el ID del registro a modificar o eliminar.
    ''' </summary>
    Public Function fun_Buscar_ID_PROYECTO(ByVal inPROYIDRE As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' PROYatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "PROYECTO "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "PROYIDRE = '" & CInt(inPROYIDRE) & "'"

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Buscar_ID_PROYECTO")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que busca el CÓDIGO DE LA CALIDAD DE PROPIETARIO para que no se 
    ''' guarden registros duplicados.
    ''' </summary>
    Public Function fun_Buscar_CODIGO_PROYECTO(ByVal stPROYDEPA As String, _
                                               ByVal stPROYMUNI As String, _
                                               ByVal inPROYCLSE As Integer, _
                                               ByVal inPROYCODI As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' PROYatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "PROYECTO "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "PROYDEPA = '" & CStr(Trim(stPROYDEPA)) & "' and "
            stConsultaSQL += "PROYMUNI = '" & CStr(Trim(stPROYMUNI)) & "' and "
            stConsultaSQL += "PROYCLSE = '" & CInt(inPROYCLSE) & "' and "
            stConsultaSQL += "PROYCODI = '" & CInt(inPROYCODI) & "' "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Buscar_CODIGO_PROYECTO")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que busca el CÓDIGO DE LA CALIDAD DE PROPIETARIO para que no se 
    ''' guarden registros duplicados.
    ''' </summary>
    Public Function fun_Buscar_CODIGO_PROYECTO_X_DEPA_MUNI_CLSE(ByVal stPROYDEPA As String, _
                                                                ByVal stPROYMUNI As String, _
                                                                ByVal inPROYCLSE As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' PROYatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "PROYECTO "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "PROYDEPA = '" & CStr(Trim(stPROYDEPA)) & "' and "
            stConsultaSQL += "PROYMUNI = '" & CStr(Trim(stPROYMUNI)) & "' and "
            stConsultaSQL += "PROYCLSE = '" & CInt(inPROYCLSE) & "' "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Buscar_CODIGO_PROYECTO")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que busca el CÓDIGO DE LA CALIDAD DE PROPIETARIO para que no se 
    ''' guarden registros duplicados.
    ''' </summary>
    Public Function fun_Buscar_CODIGO_PROYECTO_X_DEPA_MUNI_CLSE_CODI(ByVal stPROYDEPA As String, _
                                                                     ByVal stPROYMUNI As String, _
                                                                     ByVal inPROYCLSE As Integer, _
                                                                     ByVal inPROYCODI As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' PROYatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "PROYECTO "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "PROYDEPA = '" & CStr(Trim(stPROYDEPA)) & "' and "
            stConsultaSQL += "PROYMUNI = '" & CStr(Trim(stPROYMUNI)) & "' and "
            stConsultaSQL += "PROYCLSE = '" & CInt(inPROYCLSE) & "' and "
            stConsultaSQL += "PROYCODI = '" & CInt(inPROYCODI) & "' "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Buscar_CODIGO_PROYECTO")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que busca el ID del codigo buscado para ejecutar la consulta
    ''' parametrizada.
    ''' </summary>
    Public Function fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_PROYECTO(ByVal inPROYIDRE As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' PROYatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "PROYIDRE, "
            stConsultaSQL += "PROYDEPA, "
            stConsultaSQL += "DEPADESC, "
            stConsultaSQL += "PROYMUNI, "
            stConsultaSQL += "MUNIDESC, "
            stConsultaSQL += "PROYCLSE, "
            stConsultaSQL += "CLSEDESC, "
            stConsultaSQL += "PROYCODI, "
            stConsultaSQL += "PROYDESC, "
            stConsultaSQL += "PROYESTA, "
            stConsultaSQL += "ESTADESC, "
            stConsultaSQL += "PROYALCA, "
            stConsultaSQL += "PROYRECU, "
            stConsultaSQL += "PROYJUST, "
            stConsultaSQL += "PROYOBJE, "
            stConsultaSQL += "PROYFINA, "
            stConsultaSQL += "PROYOBSE, "
            stConsultaSQL += "PROYCONV, "
            stConsultaSQL += "PROYCOMP, "
            stConsultaSQL += "PROYNORM "

            stConsultaSQL += "FROM "
            stConsultaSQL += "PROYECTO, "
            stConsultaSQL += "MANT_DEPARTAMENTO, "
            stConsultaSQL += "MANT_MUNICIPIO, "
            stConsultaSQL += "MANT_CLASSECT, "
            stConsultaSQL += "ESTADO "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "DEPACODI = PROYDEPA AND "
            stConsultaSQL += "MUNIDEPA = PROYDEPA AND "
            stConsultaSQL += "MUNICODI = PROYMUNI AND "
            stConsultaSQL += "CLSECODI = PROYCLSE AND "
            stConsultaSQL += "ESTACODI = PROYESTA AND "
            stConsultaSQL += "PROYIDRE = '" & CInt(inPROYIDRE) & "'"

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "PROYDEPA, PROYMUNI, PROYCLSE, PROYCODI "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception

            MessageBox.Show(Err.Description & " " & "fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_PROYECTO")
            Return Nothing

        End Try

    End Function

End Class
