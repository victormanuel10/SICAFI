Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration
Imports DATOS

Public Class cla_PREDEXNI

    '=====================================
    '*** CLASE PREDIOS EXENTOS POR NIT ***
    '=====================================

    ''' <summary>
    ''' procedimiento que verifica la llave primaria.
    ''' </summary>
    Public Function fun_Verifica_llave_Primaria_PREDEXNI(ByVal obPRENDEPA As Object, _
                                                         ByVal obPRENMUNI As Object, _
                                                         ByVal obPRENCLSE As Object, _
                                                         ByVal obPRENTIIM As Object, _
                                                         ByVal obPRENCONC As Object, _
                                                         ByVal obPRENNUDO As Object) As Boolean

        Try
            Dim boRespuesta As Boolean = False

            Dim obVerifica As New cla_Verificar_Dato

            If obVerifica.fun_Verificar_Campo_Lleno(obPRENDEPA.SelectedValue) = True And _
               obVerifica.fun_Verificar_Campo_Lleno(obPRENMUNI.SelectedValue) = True And _
               obVerifica.fun_Verificar_Campo_Lleno(obPRENCLSE.SelectedValue) = True And _
               obVerifica.fun_Verificar_Campo_Lleno(obPRENTIIM.SelectedValue) = True And _
               obVerifica.fun_Verificar_Campo_Lleno(obPRENCONC.SelectedValue) = True And _
               obVerifica.fun_Verificar_Campo_Lleno(obPRENNUDO.Text) = True Then

                If obVerifica.fun_Verificar_Dato_Numerico(obPRENDEPA.SelectedValue) = True And _
                   obVerifica.fun_Verificar_Dato_Numerico(obPRENMUNI.SelectedValue) = True And _
                   obVerifica.fun_Verificar_Dato_Numerico(obPRENCLSE.SelectedValue) = True And _
                   obVerifica.fun_Verificar_Dato_Numerico(obPRENTIIM.SelectedValue) = True And _
                   obVerifica.fun_Verificar_Dato_Numerico(obPRENCONC.SelectedValue) = True Then

                    Dim objdatos1 As New cla_PREDEXNI
                    Dim tbl As New DataTable

                    tbl = objdatos1.fun_Buscar_CODIGO_DEPA_MUNI_CLSE_TIIM_CONC_NUDO_X_PREDEXNI(obPRENDEPA.SelectedValue, _
                                                                                               obPRENMUNI.SelectedValue, _
                                                                                               obPRENCLSE.SelectedValue, _
                                                                                               obPRENTIIM.SelectedValue, _
                                                                                               obPRENCONC.SelectedValue, _
                                                                                               obPRENNUDO.Text)

                    If tbl.Rows.Count > 0 Then
                        MessageBox.Show("El dato " & Trim(obPRENDEPA.Text) & " - " & _
                                                     Trim(obPRENMUNI.Text) & " - " & _
                                                     Trim(obPRENCLSE.Text) & " - " & _
                                                     Trim(obPRENTIIM.Text) & " - " & _
                                                     Trim(obPRENCONC.Text) & " - " & _
                                                     Trim(obPRENNUDO.Text) & " - " & " existe en la base de datos.", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                        obPRENDEPA.Focus()
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
    Public Function fun_Insertar_PREDEXNI(ByVal stPRENDEPA As String, _
                                          ByVal stPRENMUNI As String, _
                                          ByVal inPRENCLSE As Integer, _
                                          ByVal inPRENTIIM As Integer, _
                                          ByVal inPRENCONC As Integer, _
                                          ByVal inPRENTIDO As Integer, _
                                          ByVal inPRENCAPR As Integer, _
                                          ByVal inPRENSEXO As Integer, _
                                          ByVal stPRENNUDO As String, _
                                          ByVal stPRENDESC As String, _
                                          ByVal stPRENESTA As String) As Boolean

        Try

            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "INSERT INTO "
            stConsultaSQL += "PREDEXNI "

            stConsultaSQL += "( "
            stConsultaSQL += "PRENDEPA, "
            stConsultaSQL += "PRENMUNI, "
            stConsultaSQL += "PRENCLSE, "
            stConsultaSQL += "PRENTIIM, "
            stConsultaSQL += "PRENCONC, "
            stConsultaSQL += "PRENTIDO, "
            stConsultaSQL += "PRENCAPR, "
            stConsultaSQL += "PRENSEXO, "
            stConsultaSQL += "PRENNUDO, "
            stConsultaSQL += "PRENDESC, "
            stConsultaSQL += "PRENESTA "
            stConsultaSQL += ") "

            stConsultaSQL += "VALUES "

            stConsultaSQL += "( "
            stConsultaSQL += "'" & CStr(Trim(stPRENDEPA)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stPRENMUNI)) & "', "
            stConsultaSQL += "'" & CInt(inPRENCLSE) & "', "
            stConsultaSQL += "'" & CInt(inPRENTIIM) & "', "
            stConsultaSQL += "'" & CInt(inPRENCONC) & "', "
            stConsultaSQL += "'" & CInt(inPRENTIDO) & "', "
            stConsultaSQL += "'" & CInt(inPRENCAPR) & "', "
            stConsultaSQL += "'" & CInt(inPRENSEXO) & "', "
            stConsultaSQL += "'" & CStr(Trim(stPRENNUDO)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stPRENDESC)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stPRENESTA)) & "' "
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
            MessageBox.Show(Err.Description & " " & "fun_Insertar_PREDEXNI")
        End Try

    End Function

    ''' <summary>
    ''' Función que Elimina el registro.
    ''' </summary>
    Public Function fun_Eliminar_PREDEXNI(ByVal inPRENIDRE As Integer) As Boolean

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "DELETE "
            stConsultaSQL += "PREDEXNI "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "PRENIDRE = '" & CInt(inPRENIDRE) & "' "

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
            MessageBox.Show(Err.Description & " " & "fun_Eliminar_PREDEXNI")
        End Try

    End Function

    ''' <summary>
    ''' Función que Modifica el registro.
    ''' </summary>
    Public Function fun_Actualizar_PREDEXNI(ByVal inPRENIDRE As Integer, _
                                           ByVal stPRENDEPA As String, _
                                           ByVal stPRENMUNI As String, _
                                           ByVal inPRENCLSE As Integer, _
                                           ByVal inPRENTIIM As Integer, _
                                           ByVal inPRENCONC As Integer, _
                                           ByVal inPRENTIDO As Integer, _
                                           ByVal inPRENCAPR As Integer, _
                                           ByVal inPRENSEXO As Integer, _
                                           ByVal stPRENNUDO As String, _
                                           ByVal stPRENDESC As String, _
                                           ByVal stPRENESTA As String) As Boolean

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "UPDATE "
            stConsultaSQL += "PREDEXNI "

            stConsultaSQL += "SET "
            stConsultaSQL += "PRENDEPA = '" & CStr(Trim(stPRENDEPA)) & "', "
            stConsultaSQL += "PRENMUNI = '" & CStr(Trim(stPRENMUNI)) & "', "
            stConsultaSQL += "PRENCLSE = '" & CInt(inPRENCLSE) & "', "
            stConsultaSQL += "PRENTIIM = '" & CInt(inPRENTIIM) & "', "
            stConsultaSQL += "PRENCONC = '" & CInt(inPRENCONC) & "', "
            stConsultaSQL += "PRENTIDO = '" & CInt(inPRENTIDO) & "', "
            stConsultaSQL += "PRENCAPR = '" & CInt(inPRENCAPR) & "', "
            stConsultaSQL += "PRENSEXO = '" & CInt(inPRENSEXO) & "', "
            stConsultaSQL += "PRENNUDO = '" & CStr(Trim(stPRENNUDO)) & "', "
            stConsultaSQL += "PRENDESC = '" & CStr(Trim(stPRENDESC)) & "', "
            stConsultaSQL += "PRENESTA = '" & CStr(Trim(stPRENESTA)) & "' "


            stConsultaSQL += "WHERE "
            stConsultaSQL += "PRENIDRE = '" & CInt(inPRENIDRE) & "'"

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
            MessageBox.Show(Err.Description & " " & "fun_Actualizar_PREDEXNI")
        End Try

    End Function

    ''' <summary>
    ''' Consulta para llenar el DataGridView y colocar el nombre del encabezado
    ''' de la columna. 
    ''' </summary>
    Public Function fun_Consultar_PREDEXNI() As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "PRENIDRE, "
            stConsultaSQL += "PRENDEPA, "
            stConsultaSQL += "PRENMUNI, "
            stConsultaSQL += "PRENCLSE, "
            stConsultaSQL += "PRENTIIM, "
            stConsultaSQL += "PRENCONC, "
            stConsultaSQL += "PRENTIDO, "
            stConsultaSQL += "PRENCAPR, "
            stConsultaSQL += "PRENSEXO, "
            stConsultaSQL += "PRENNUDO, "
            stConsultaSQL += "PRENDESC, "
            stConsultaSQL += "PRENESTA "

            stConsultaSQL += "FROM "
            stConsultaSQL += "PREDEXNI "

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "PRENDEPA, PRENMUNI, PRENCLSE, PRENTIIM, PRENCONC "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Consultar_PREDEXNI")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Llena el ComboBox con datos activos e inactivos formulario principal 
    ''' esta funcion se llama desde el procedimiento "pro_inicializarControles()".
    ''' </summary>
    Public Function fun_Consultar_CAMPOS_PREDEXNI() As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "PREDEXNI "

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "PRENDEPA, PRENMUNI, PRENCLSE, PRENTIIM, PRENCONC "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Consultar_CAMPOS_PREDEXNI")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Llena el ComboBox con datos activos formulario insertar y modificar 
    ''' esta funcion se llama desde el procedimiento "pro_inicializarControles()".
    ''' </summary>
    Public Function fun_Consultar_PREDEXNI_X_ESTADO() As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "PREDEXNI "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "PRENESTA = 'ac' "

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "PRENDEPA, PRENMUNI, PRENCLSE, PRENTIIM, PRENCONC "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Consultar_PREDEXNI_X_ESTADO")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que busca el ID del registro a modificar o eliminar.
    ''' </summary>
    Public Function fun_Buscar_ID_PREDEXNI(ByVal inPRENIDRE As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "PREDEXNI "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "PRENIDRE = '" & CInt(inPRENIDRE) & "'"

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Buscar_ID_PREDEXNI")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que busca el CÓDIGO para que no se 
    ''' guarden registros duplicados.
    ''' </summary>
    Public Function fun_Buscar_CODIGO_DEPA_MUNI_CLSE_TIIM_CONC_NUDO_X_PREDEXNI(ByVal stPRENDEPA As String, _
                                                                               ByVal stPRENMUNI As String, _
                                                                               ByVal inPRENCLSE As Integer, _
                                                                               ByVal inPRENTIIM As Integer, _
                                                                               ByVal inPRENCONC As Integer, _
                                                                               ByVal stPRENNUDO As String) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "PREDEXNI "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "PRENDEPA = '" & CStr(Trim(stPRENDEPA)) & "' and "
            stConsultaSQL += "PRENMUNI = '" & CStr(Trim(stPRENMUNI)) & "' and "
            stConsultaSQL += "PRENCLSE = '" & CInt(inPRENCLSE) & "' and "
            stConsultaSQL += "PRENTIIM = '" & CInt(inPRENTIIM) & "' and "
            stConsultaSQL += "PRENCONC = '" & CInt(inPRENCONC) & "' and "
            stConsultaSQL += "PRENNUDO = '" & CStr(Trim(stPRENNUDO)) & "' "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Buscar_CODIGO_PREDEXNI")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que busca el ID del codigo buscado para ejecutar la consulta
    ''' parametrizada.
    ''' </summary>
    Public Function fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_PREDEXNI(ByVal inPRENIDRE As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "PRENIDRE, "
            stConsultaSQL += "PRENDEPA, "
            stConsultaSQL += "PRENMUNI, "
            stConsultaSQL += "PRENCLSE, "
            stConsultaSQL += "PRENTIIM, "
            stConsultaSQL += "PRENCONC, "
            stConsultaSQL += "PRENTIDO, "
            stConsultaSQL += "PRENCAPR, "
            stConsultaSQL += "PRENSEXO, "
            stConsultaSQL += "PRENNUDO, "
            stConsultaSQL += "PRENDESC, "
            stConsultaSQL += "PRENESTA "

            stConsultaSQL += "FROM "
            stConsultaSQL += "PREDEXNI "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "PRENIDRE = '" & CInt(inPRENIDRE) & "'"

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "PRENDEPA, PRENMUNI, PRENCLSE, PRENTIIM, PRENCONC "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception

            MessageBox.Show(Err.Description & " " & "fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_PREDEXNI")
            Return Nothing

        End Try

    End Function

End Class
