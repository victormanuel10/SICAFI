Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration
Imports DATOS

Public Class cla_BARRVERE

    '=============================
    '*** CLASE BARRIO - VEREDA ***
    '=============================

    ''' <summary>
    ''' procedimiento que verifica la llave primaria.
    ''' </summary>
    Public Function fun_Verifica_llave_Primaria_BARRVERE(ByVal obBAVEDEPA As Object, _
                                                         ByVal obBAVEMUNI As Object, _
                                                         ByVal obBAVECLSE As Object, _
                                                         ByVal obBAVECORR As Object, _
                                                         ByVal obBAVECODI As Object) As Boolean

        Try
            Dim boRespuesta As Boolean = False

            Dim obVerifica As New cla_Verificar_Dato

            If obVerifica.fun_Verificar_Campo_Lleno(obBAVEDEPA.SelectedValue) = True And _
               obVerifica.fun_Verificar_Campo_Lleno(obBAVEMUNI.SelectedValue) = True And _
               obVerifica.fun_Verificar_Campo_Lleno(obBAVECLSE.SelectedValue) = True And _
               obVerifica.fun_Verificar_Campo_Lleno(obBAVECORR.SelectedValue) = True And _
               obVerifica.fun_Verificar_Campo_Lleno(obBAVECODI.Text) = True Then

                If obVerifica.fun_Verificar_Dato_Numerico(obBAVEDEPA.SelectedValue) = True And _
                   obVerifica.fun_Verificar_Dato_Numerico(obBAVEMUNI.SelectedValue) = True And _
                   obVerifica.fun_Verificar_Dato_Numerico(obBAVECLSE.SelectedValue) = True And _
                   obVerifica.fun_Verificar_Dato_Numerico(obBAVECORR.SelectedValue) = True And _
                   obVerifica.fun_Verificar_Dato_Numerico(obBAVECODI.Text) = True Then

                    Dim objdatos1 As New cla_BARRVERE
                    Dim tbl As New DataTable

                    tbl = objdatos1.fun_Buscar_CODIGO_DEPA_MUNI_CLSE_CORR_BAVE_X_BARRVERE(Trim(obBAVEDEPA.SelectedValue), _
                                                                                          Trim(obBAVEMUNI.SelectedValue), _
                                                                                          Trim(obBAVECLSE.SelectedValue), _
                                                                                          Trim(obBAVECORR.SelectedValue), _
                                                                                          Trim(obBAVECODI.Text))

                    If tbl.Rows.Count > 0 Then
                        MessageBox.Show("El dato " & Trim(obBAVEDEPA.Text) & " - " & Trim(obBAVEMUNI.Text) & " - " & Trim(obBAVECLSE.Text) & " del campo " & obBAVECODI.AccessibleDescription & " existe en la base de datos.", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                        obBAVEDEPA.Focus()
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
    Public Function fun_Insertar_BARRVERE(ByVal stBAVEDEPA As String, _
                                          ByVal stBAVEMUNI As String, _
                                          ByVal inBAVECLSE As Integer, _
                                          ByVal stBAVECODI As String, _
                                          ByVal stBAVEDESC As String, _
                                          ByVal stBAVEESTA As String, _
                                          ByVal stBAVECORR As String) As Boolean

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "INSERT INTO "
            stConsultaSQL += "MANT_BARRVERE "

            stConsultaSQL += "( "
            stConsultaSQL += "BAVEDEPA, "
            stConsultaSQL += "BAVEMUNI, "
            stConsultaSQL += "BAVECLSE, "
            stConsultaSQL += "BAVECODI, "
            stConsultaSQL += "BAVEDESC, "
            stConsultaSQL += "BAVEESTA, "
            stConsultaSQL += "BAVECORR "
            stConsultaSQL += ") "

            stConsultaSQL += "VALUES "

            stConsultaSQL += "( "
            stConsultaSQL += "'" & CStr(Trim(stBAVEDEPA)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stBAVEMUNI)) & "', "
            stConsultaSQL += "'" & CInt(inBAVECLSE) & "', "
            stConsultaSQL += "'" & CStr(Trim(stBAVECODI)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stBAVEDESC)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stBAVEESTA)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stBAVECORR)) & "'  "
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
            MessageBox.Show(Err.Description & " " & "fun_Insertar_BARRVERE")
        End Try

    End Function

    ''' <summary>
    ''' Función que Elimina el registro.
    ''' </summary>
    Public Function fun_Eliminar_MANT_BARRVERE(ByVal inBAVEIDRE As Integer) As Boolean

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "DELETE "
            stConsultaSQL += "MANT_BARRVERE "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "BAVEIDRE = '" & CInt(inBAVEIDRE) & "' "

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
            MessageBox.Show(Err.Description & " " & "fun_Eliminar_MANT_BARRVERE")
        End Try

    End Function

    ''' <summary>
    ''' Función que Modifica el registro.
    ''' </summary>
    Public Function fun_Actualizar_BARRVERE(ByVal inBAVEIDRE As Integer, _
                                                 ByVal stBAVEDEPA As String, _
                                                 ByVal stBAVEMUNI As String, _
                                                 ByVal inBAVECLSE As Integer, _
                                                 ByVal stBAVECODI As String, _
                                                 ByVal stBAVEDESC As String, _
                                                 ByVal stBAVEESTA As String, _
                                                 ByVal stBAVECORR As String) As Boolean

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "UPDATE "
            stConsultaSQL += "MANT_BARRVERE "

            stConsultaSQL += "SET "
            stConsultaSQL += "BAVEDEPA = '" & CStr(Trim(stBAVEDEPA)) & "', "
            stConsultaSQL += "BAVEMUNI = '" & CStr(Trim(stBAVEMUNI)) & "', "
            stConsultaSQL += "BAVECLSE = '" & CInt(inBAVECLSE) & "', "
            stConsultaSQL += "BAVECODI = '" & CStr(Trim(stBAVECODI)) & "', "
            stConsultaSQL += "BAVEDESC = '" & CStr(Trim(stBAVEDESC)) & "', "
            stConsultaSQL += "BAVEESTA = '" & CStr(Trim(stBAVEESTA)) & "', "
            stConsultaSQL += "BAVECORR = '" & CStr(Trim(stBAVECORR)) & "' "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "BAVEIDRE = '" & CInt(inBAVEIDRE) & "'"

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
            MessageBox.Show(Err.Description & " " & "fun_Actualizar_BARRVERE")
        End Try

    End Function

    ''' <summary>
    ''' Consulta para llenar el DataGridView y colocar el nombre del encabezado
    ''' de la columna. 
    ''' </summary>
    Public Function fun_Consultar_BARRVERE() As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "BAVEIDRE, "
            stConsultaSQL += "BAVEDEPA, "
            stConsultaSQL += "BAVEMUNI, "
            stConsultaSQL += "BAVECLSE, "
            stConsultaSQL += "BAVECORR, "
            stConsultaSQL += "BAVECODI, "
            stConsultaSQL += "BAVEDESC, "
            stConsultaSQL += "BAVEESTA  "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MANT_BARRVERE "

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "BAVEDEPA, BAVEMUNI, BAVECLSE, BAVECODI "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Consultar_BARRVERE")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Llena el ComboBox con datos activos e inactivos formulario principal 
    ''' esta funcion se llama desde el procedimiento "pro_inicializarControles()".
    ''' </summary>
    Public Function fun_Consultar_CAMPOS_BARRVERE() As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MANT_BARRVERE "

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "BAVEDEPA, BAVEMUNI, BAVECLSE, BAVECODI "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Consultar_CAMPOS_BARRVERE")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Llena el ComboBox con datos activos formulario insertar y modificar 
    ''' esta funcion se llama desde el procedimiento "pro_inicializarControles()".
    ''' </summary>
    Public Function fun_Consultar_BARRVERE_X_ESTADO() As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MANT_BARRVERE "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "BAVEESTA = 'ac' "

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "BAVEDEPA, BAVEMUNI, BAVECLSE, BAVECODI "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Consultar_BARRVERE_X_ESTADO")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que busca el ID del registro a modificar o eliminar.
    ''' </summary>
    Public Function fun_Buscar_ID_BARRVERE(ByVal inBAVEIDRE As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MANT_BARRVERE "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "BAVEIDRE = '" & CInt(inBAVEIDRE) & "'"

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Buscar_ID_BARRVERE")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que busca el ID del codigo buscado para ejecutar la consulta
    ''' parametrizada.
    ''' </summary>
    Public Function fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_BARRVERE(ByVal inBAVEIDRE As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "BAVEIDRE, "
            stConsultaSQL += "BAVEDEPA, "
            stConsultaSQL += "BAVEMUNI, "
            stConsultaSQL += "BAVECLSE, "
            stConsultaSQL += "BAVECORR, "
            stConsultaSQL += "BAVECODI, "
            stConsultaSQL += "BAVEDESC, "
            stConsultaSQL += "BAVEESTA  "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MANT_BARRVERE "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "BAVEIDRE = '" & CInt(inBAVEIDRE) & "'"

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "BAVEDEPA, BAVEMUNI, BAVECLSE, BAVECODI "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception

            MessageBox.Show(Err.Description & " " & "fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_BARRVERE")
            Return Nothing

        End Try

    End Function

    ''' <summary>
    ''' Función que busca el para que no se 
    ''' guarden registros duplicados.
    ''' </summary>
    Public Function fun_Buscar_CODIGO_DEPA_MUNI_CLSE_BAVE_X_BARRVERE(ByVal stBAVEDEPA As String, _
                                                                     ByVal stBAVEMUNI As String, _
                                                                     ByVal inBAVECLSE As Integer, _
                                                                     ByVal stBAVECODI As String) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MANT_BARRVERE "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "BAVEDEPA = '" & CStr(Trim(stBAVEDEPA)) & "' and "
            stConsultaSQL += "BAVEMUNI = '" & CStr(Trim(stBAVEMUNI)) & "' and "
            stConsultaSQL += "BAVECLSE = '" & CInt(inBAVECLSE) & "' and "
            stConsultaSQL += "BAVECODI = '" & CStr(Trim(stBAVECODI)) & "' "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Buscar_CODIGO_BARRVERE")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que busca el para que no se 
    ''' guarden registros duplicados.
    ''' </summary>
    Public Function fun_Buscar_CODIGO_DEPA_MUNI_CLSE_CORR_BAVE_X_BARRVERE(ByVal stBAVEDEPA As String, _
                                                                          ByVal stBAVEMUNI As String, _
                                                                          ByVal inBAVECLSE As Integer, _
                                                                          ByVal stBAVECORR As String, _
                                                                          ByVal stBAVECODI As String) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MANT_BARRVERE "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "BAVEDEPA = '" & CStr(Trim(stBAVEDEPA)) & "' and "
            stConsultaSQL += "BAVEMUNI = '" & CStr(Trim(stBAVEMUNI)) & "' and "
            stConsultaSQL += "BAVECLSE = '" & CInt(inBAVECLSE) & "' and "
            stConsultaSQL += "BAVECORR = '" & CStr(Trim(stBAVECORR)) & "' and "
            stConsultaSQL += "BAVECODI = '" & CStr(Trim(stBAVECODI)) & "' "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Buscar_CODIGO_BARRVERE")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que busca el para que no se 
    ''' guarden registros duplicados.
    ''' </summary>
    Public Function fun_Buscar_CODIGO_DEPA_MUNI_CLSE_X_BARRVERE(ByVal stBAVEDEPA As String, _
                                                                ByVal stBAVEMUNI As String, _
                                                                ByVal inBAVECLSE As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MANT_BARRVERE "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "BAVEDEPA = '" & CStr(Trim(stBAVEDEPA)) & "' and "
            stConsultaSQL += "BAVEMUNI = '" & CStr(Trim(stBAVEMUNI)) & "' and "
            stConsultaSQL += "BAVECLSE = '" & CInt(inBAVECLSE) & "' "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Buscar_CODIGO_BARRVERE")
            Return Nothing
        End Try

    End Function
    ''' <summary>
    ''' Función que busca el para que no se 
    ''' guarden registros duplicados.
    ''' </summary>
    Public Function fun_Buscar_CODIGO_DEPA_MUNI_CLSE_CORR_X_BARRVERE(ByVal stBAVEDEPA As String, _
                                                                     ByVal stBAVEMUNI As String, _
                                                                     ByVal inBAVECLSE As Integer, _
                                                                     ByVal stBAVECORR As String) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MANT_BARRVERE "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "BAVEDEPA = '" & CStr(Trim(stBAVEDEPA)) & "' and "
            stConsultaSQL += "BAVEMUNI = '" & CStr(Trim(stBAVEMUNI)) & "' and "
            stConsultaSQL += "BAVECLSE = '" & CInt(inBAVECLSE) & "'and "
            stConsultaSQL += "BAVECORR = '" & CStr(Trim(stBAVECORR)) & "' "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Buscar_CODIGO_BARRVERE")
            Return Nothing
        End Try

    End Function


End Class
