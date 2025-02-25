Imports DATOS

Public Class cla_CAMPOS

    '============================
    '*** MANTENIMIENTO CAMPOS ***
    '============================

    ''' <summary>
    ''' MANT_CAMPOS que verifica la llave primaria.
    ''' </summary>
    Public Function fun_Verifica_llave_Primaria_MANT_CAMPOS(ByVal obCAMPPROC As Object, _
                                                            ByVal obCAMPTABL As Object, _
                                                            ByVal obCAMPCODI As Object) As Boolean

        Try
            Dim boRespuesta As Boolean = False

            Dim obVerifica As New cla_Verificar_Dato

            If obVerifica.fun_Verificar_Campo_Lleno(obCAMPPROC.SelectedValue) = True And _
               obVerifica.fun_Verificar_Campo_Lleno(obCAMPTABL.SelectedValue) = True And _
               obVerifica.fun_Verificar_Campo_Lleno(obCAMPCODI.Text) = True Then

                Dim objdatos1 As New cla_CAMPOS
                Dim tbl As New DataTable

                tbl = objdatos1.fun_Buscar_CODIGO_MANT_CAMPOS(obCAMPPROC.SelectedValue, obCAMPTABL.SelectedValue, obCAMPCODI.Text)

                If tbl.Rows.Count > 0 Then
                    MessageBox.Show("El dato " & obCAMPPROC.AccessibleDescription & "-" & obCAMPTABL.AccessibleDescription & "-" & obCAMPCODI.AccessibleDescription & _
                                    " existe en la base de datos.", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                    obCAMPCODI.Focus()
                    boRespuesta = False
                Else
                    boRespuesta = True
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
    Public Function fun_Insertar_MANT_CAMPOS(ByVal stCAMPPROC As String, _
                                             ByVal stCAMPTABL As String, _
                                             ByVal stCAMPCODI As String, _
                                             ByVal stCAMPDESC As String, _
                                             ByVal boCAMPLLPR As Boolean, _
                                             ByVal boCAMPREQU As Boolean, _
                                             ByVal stCAMPTIDA As String, _
                                             ByVal inCAMPLONG As Integer, _
                                             ByVal boCAMPCOND As Boolean, _
                                             ByVal boCAMPMANT As Boolean, _
                                             ByVal stCAMPTAMA As String, _
                                             ByVal boCAMPSIST As Boolean, _
                                             ByVal stCAMPTASI As String, _
                                             ByVal stCAMPESTA As String, _
                                             ByVal stCAMPLLMA As String, _
                                             ByVal stCAMPLLSI As String) As Boolean

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' PROCatena la consulta
            stConsultaSQL += "INSERT INTO "
            stConsultaSQL += "MANT_CAMPOS "

            stConsultaSQL += "( "
            stConsultaSQL += "CAMPPROC, "
            stConsultaSQL += "CAMPTABL, "
            stConsultaSQL += "CAMPCODI, "
            stConsultaSQL += "CAMPDESC, "
            stConsultaSQL += "CAMPLLPR, "
            stConsultaSQL += "CAMPREQU, "
            stConsultaSQL += "CAMPTIDA, "
            stConsultaSQL += "CAMPLONG, "
            stConsultaSQL += "CAMPCOND, "
            stConsultaSQL += "CAMPMANT, "
            stConsultaSQL += "CAMPTAMA, "
            stConsultaSQL += "CAMPSIST, "
            stConsultaSQL += "CAMPTASI, "
            stConsultaSQL += "CAMPESTA, "
            stConsultaSQL += "CAMPLLMA, "
            stConsultaSQL += "CAMPLLSI  "
            stConsultaSQL += ") "

            stConsultaSQL += "VALUES "

            stConsultaSQL += "( "
            stConsultaSQL += "'" & CStr(Trim(stCAMPPROC)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stCAMPTABL)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stCAMPCODI)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stCAMPDESC)) & "', "
            stConsultaSQL += "'" & CBool(boCAMPLLPR) & "', "
            stConsultaSQL += "'" & CBool(boCAMPREQU) & "', "
            stConsultaSQL += "'" & CStr(Trim(stCAMPTIDA)) & "', "
            stConsultaSQL += "'" & CInt(inCAMPLONG) & "', "
            stConsultaSQL += "'" & CBool(boCAMPCOND) & "', "
            stConsultaSQL += "'" & CBool(boCAMPMANT) & "', "
            stConsultaSQL += "'" & CStr(Trim(stCAMPTAMA)) & "', "
            stConsultaSQL += "'" & CBool(boCAMPSIST) & "', "
            stConsultaSQL += "'" & CStr(Trim(stCAMPTASI)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stCAMPESTA)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stCAMPLLMA)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stCAMPLLSI)) & "' "
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
            MessageBox.Show(Err.Description & " " & "fun_Insertar_MANT_CAMPOS")
        End Try

    End Function

    ''' <summary>
    ''' Función que Elimina el registro.
    ''' </summary>
    Public Function fun_Eliminar_MANT_CAMPOS(ByVal inCAMPIDRE As Integer) As Boolean

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' PROCatena la consulta
            stConsultaSQL += "DELETE "
            stConsultaSQL += "MANT_CAMPOS "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "CAMPIDRE = '" & CInt(inCAMPIDRE) & "' "

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
            MessageBox.Show(Err.Description & " " & "fun_Eliminar_MANT_CAMPOS")
        End Try

    End Function

    ''' <summary>
    ''' Función que Modifica el registro.
    ''' </summary>
    Public Function fun_Actualizar_MANT_CAMPOS(ByVal inCAMPIDRE As Integer, _
                                               ByVal stCAMPPROC As String, _
                                               ByVal stCAMPTABL As String, _
                                               ByVal stCAMPCODI As String, _
                                               ByVal stCAMPDESC As String, _
                                               ByVal boCAMPLLPR As Boolean, _
                                               ByVal boCAMPREQU As Boolean, _
                                               ByVal stCAMPTIDA As String, _
                                               ByVal inCAMPLONG As Integer, _
                                               ByVal boCAMPCOND As Boolean, _
                                               ByVal boCAMPMANT As Boolean, _
                                               ByVal stCAMPTAMA As String, _
                                               ByVal boCAMPSIST As Boolean, _
                                               ByVal stCAMPTASI As String, _
                                               ByVal stCAMPESTA As String, _
                                               ByVal stCAMPLLMA As String, _
                                               ByVal stCAMPLLSI As String) As Boolean

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' PROCatena la consulta
            stConsultaSQL += "UPDATE "
            stConsultaSQL += "MANT_CAMPOS "

            stConsultaSQL += "SET "
            stConsultaSQL += "CAMPPROC = '" & CStr(Trim(stCAMPPROC)) & "', "
            stConsultaSQL += "CAMPTABL = '" & CStr(Trim(stCAMPTABL)) & "', "
            stConsultaSQL += "CAMPCODI = '" & CStr(Trim(stCAMPCODI)) & "', "
            stConsultaSQL += "CAMPDESC = '" & CStr(Trim(stCAMPDESC)) & "', "
            stConsultaSQL += "CAMPLLPR = '" & CBool(boCAMPLLPR) & "', "
            stConsultaSQL += "CAMPREQU = '" & CBool(boCAMPREQU) & "', "
            stConsultaSQL += "CAMPTIDA = '" & CStr(Trim(stCAMPTIDA)) & "', "
            stConsultaSQL += "CAMPLONG = '" & CInt(inCAMPLONG) & "', "
            stConsultaSQL += "CAMPCOND = '" & CBool(boCAMPCOND) & "', "
            stConsultaSQL += "CAMPMANT = '" & CBool(boCAMPMANT) & "', "
            stConsultaSQL += "CAMPTAMA = '" & CStr(Trim(stCAMPTAMA)) & "', "
            stConsultaSQL += "CAMPSIST = '" & CBool(boCAMPSIST) & "', "
            stConsultaSQL += "CAMPTASI = '" & CStr(Trim(stCAMPTASI)) & "', "
            stConsultaSQL += "CAMPESTA = '" & CStr(Trim(stCAMPESTA)) & "', "
            stConsultaSQL += "CAMPLLMA = '" & CStr(Trim(stCAMPLLMA)) & "', "
            stConsultaSQL += "CAMPLLSI = '" & CStr(Trim(stCAMPLLSI)) & "' "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "CAMPIDRE = '" & CInt(inCAMPIDRE) & "'"

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
            MessageBox.Show(Err.Description & " " & "fun_Actualizar_MANT_CAMPOS")
        End Try

    End Function

    ''' <summary>
    ''' Consulta para llenar el DataGridView y colocar el nombre del encabezado
    ''' de la columna. 
    ''' </summary>
    Public Function fun_Consultar_MANT_CAMPOS() As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' PROCatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "CAMPIDRE, "
            stConsultaSQL += "CAMPPROC, "
            stConsultaSQL += "CAMPTABL, "
            stConsultaSQL += "CAMPCODI, "
            stConsultaSQL += "CAMPDESC, "
            stConsultaSQL += "CAMPLLPR, "
            stConsultaSQL += "CAMPREQU, "
            stConsultaSQL += "CAMPTIDA, "
            stConsultaSQL += "CAMPLONG, "
            stConsultaSQL += "CAMPCOND, "
            stConsultaSQL += "CAMPMANT, "
            stConsultaSQL += "CAMPTAMA, "
            stConsultaSQL += "CAMPSIST, "
            stConsultaSQL += "CAMPTASI, "
            stConsultaSQL += "CAMPESTA, "
            stConsultaSQL += "CAMPLLMA, "
            stConsultaSQL += "CAMPLLSI  "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MANT_CAMPOS "

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "CAMPIDRE "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Consultar_MANT_CAMPOS")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Llena el ComboBox con datos activos e inactivos formulario principal 
    ''' esta funcion se llama desde el MANT_CAMPOS "pro_inicializarControles()".
    ''' </summary>
    Public Function fun_Consultar_CAMPOS_MANT_CAMPOS() As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' PROCatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MANT_CAMPOS "

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "CAMPIDRE "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Consultar_CAMPOS_MANT_CAMPOS")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Llena el ComboBox con datos activos formulario insertar y modificar 
    ''' esta funcion se llama desde el MANT_CAMPOS "pro_inicializarControles()".
    ''' </summary>
    Public Function fun_Consultar_MANT_CAMPOS_X_ESTADO() As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' PROCatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MANT_CAMPOS "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "CAMPESTA = 'ac' "

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "CAMPIDRE "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Consultar_MANT_CAMPOS_X_ESTADO")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que busca el ID del registro a modificar o eliminar.
    ''' </summary>
    Public Function fun_Buscar_ID_MANT_CAMPOS(ByVal inCAMPIDRE As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' PROCatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MANT_CAMPOS "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "CAMPIDRE = '" & CInt(inCAMPIDRE) & "'"

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Buscar_ID_MANT_CAMPOS")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que busca el CÓDIGO para que no se 
    ''' guarden registros duplicados.
    ''' </summary>
    Public Function fun_Buscar_CODIGO_MANT_CAMPOS(ByVal stCAMPPROC As String, _
                                                  ByVal stCAMPTABL As String, _
                                                  ByVal stCAMPCODI As String) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' PROCatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MANT_CAMPOS "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "CAMPPROC = '" & CStr(Trim(stCAMPPROC)) & "' AND "
            stConsultaSQL += "CAMPTABL = '" & CStr(Trim(stCAMPTABL)) & "' AND "
            stConsultaSQL += "CAMPCODI = '" & CStr(Trim(stCAMPCODI)) & "' "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Buscar_CODIGO_MANT_CAMPOS")
            Return Nothing
        End Try

    End Function
    ''' <summary>
    ''' Función que busca el CÓDIGO para que no se 
    ''' guarden registros duplicados.
    ''' </summary>
    Public Function fun_Buscar_CODIGO_MANT_CAMPOS(ByVal stCAMPCODI As String) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' PROCatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MANT_CAMPOS "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "CAMPCODI = '" & CStr(Trim(stCAMPCODI)) & "' "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Buscar_CODIGO_MANT_CAMPOS")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que busca el ID del codigo buscado para ejecutar la consulta
    ''' parametrizada.
    ''' </summary>
    Public Function fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_MANT_CAMPOS(ByVal inCAMPIDRE As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' PROCatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "CAMPIDRE, "
            stConsultaSQL += "CAMPPROC, "
            stConsultaSQL += "CAMPTABL, "
            stConsultaSQL += "CAMPCODI, "
            stConsultaSQL += "CAMPDESC, "
            stConsultaSQL += "CAMPLLPR, "
            stConsultaSQL += "CAMPREQU, "
            stConsultaSQL += "CAMPTIDA, "
            stConsultaSQL += "CAMPLONG, "
            stConsultaSQL += "CAMPCOND, "
            stConsultaSQL += "CAMPMANT, "
            stConsultaSQL += "CAMPTAMA, "
            stConsultaSQL += "CAMPSIST, "
            stConsultaSQL += "CAMPTASI, "
            stConsultaSQL += "CAMPESTA, "
            stConsultaSQL += "CAMPLLMA, "
            stConsultaSQL += "CAMPLLSI "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MANT_CAMPOS "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "CAMPIDRE = '" & CInt(inCAMPIDRE) & "'"

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "CAMPIDRE "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception

            MessageBox.Show(Err.Description & " " & "fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_MANT_CAMPOS")
            Return Nothing

        End Try

    End Function

    ''' <summary>
    ''' Función que busca el la tabla por procedimiento
    ''' </summary>
    Public Function fun_Buscar_TABLAS_X_PROCEDIMIENTO_MANT_CAMPOS(ByVal stCAMPPROC As String) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' PROCatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "CAMPTABL, "
            stConsultaSQL += "TABLDESC  "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MANT_CAMPOS, MANT_TABLAS "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "TABLCODI = CAMPTABL AND "
            stConsultaSQL += "CAMPPROC = '" & CStr(Trim(stCAMPPROC)) & "' "

            stConsultaSQL += "GROUP BY CAMPTABL, TABLDESC "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Buscar_CODIGO_MANT_CAMPOS")
            Return Nothing
        End Try

    End Function
    ''' <summary>
    ''' Función que busca el CÓDIGO para que no se 
    ''' guarden registros duplicados.
    ''' </summary>
    Public Function fun_Buscar_CAMPOS_Y_TABLAS_X_PROCEDIMIENTO_MANT_CAMPOS(ByVal stCAMPPROC As String, _
                                                                           ByVal stCAMPTABL As String) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' PROCatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "CAMPCODI, "
            stConsultaSQL += "CAMPDESC "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MANT_CAMPOS "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "CAMPPROC = '" & CStr(Trim(stCAMPPROC)) & "' AND "
            stConsultaSQL += "CAMPTABL = '" & CStr(Trim(stCAMPTABL)) & "' "
            stConsultaSQL += "ORDER BY CAMPIDRE "


            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Buscar_CODIGO_MANT_CAMPOS")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que busca el CÓDIGO para que no se 
    ''' guarden registros duplicados.
    ''' </summary>
    Public Function fun_Consultar_CAMPOS_Y_TABLAS_X_PROCEDIMIENTO_MANT_CAMPOS(ByVal stCAMPPROC As String, _
                                                                              ByVal stCAMPTABL As String) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' PROCatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MANT_CAMPOS "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "CAMPPROC = '" & CStr(Trim(stCAMPPROC)) & "' AND "
            stConsultaSQL += "CAMPTABL = '" & CStr(Trim(stCAMPTABL)) & "' "
            stConsultaSQL += "ORDER BY CAMPIDRE "


            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Buscar_CODIGO_MANT_CAMPOS")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que busca el CÓDIGO para que no se 
    ''' guarden registros duplicados.
    ''' </summary>
    Public Function fun_Buscar_CAMPOS_Y_TABLAS_Y_PROCEDIMIENTO_MANT_CAMPOS(ByVal stCAMPPROC As String, _
                                                                           ByVal stCAMPTABL As String, _
                                                                           ByVal stCAMPCODI As String) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' PROCatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MANT_CAMPOS "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "CAMPPROC = '" & CStr(Trim(stCAMPPROC)) & "' AND "
            stConsultaSQL += "CAMPTABL = '" & CStr(Trim(stCAMPTABL)) & "' AND "
            stConsultaSQL += "CAMPCODI = '" & CStr(Trim(stCAMPCODI)) & "' "
            stConsultaSQL += "ORDER BY CAMPIDRE "


            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Buscar_CODIGO_MANT_CAMPOS")
            Return Nothing
        End Try

    End Function

End Class
