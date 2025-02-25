Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration
Imports DATOS

Public Class cla_INAVDEEC

    '============================================================
    '*** CLASE INCREMENTO DE AVALUO POR DESTINACIÓN ECONÓMICA ***
    '============================================================

    ''' <summary>
    ''' procedimiento que verifica la llave primaria.
    ''' </summary>
    Public Function fun_Verifica_llave_Primaria_INAVDEEC(ByVal obIADEDEPA As Object, _
                                                         ByVal obIADEMUNI As Object, _
                                                         ByVal obIADECLSE As Object, _
                                                         ByVal obIADEVIGE As Object, _
                                                         ByVal obIADEDEEC As Object) As Boolean

        Try
            Dim boRespuesta As Boolean = False

            Dim obVerifica As New cla_Verificar_Dato

            If obVerifica.fun_Verificar_Campo_Lleno(obIADEDEPA.SelectedValue) = True And _
               obVerifica.fun_Verificar_Campo_Lleno(obIADEMUNI.SelectedValue) = True And _
               obVerifica.fun_Verificar_Campo_Lleno(obIADECLSE.SelectedValue) = True And _
               obVerifica.fun_Verificar_Campo_Lleno(obIADEVIGE.SelectedValue) = True And _
               obVerifica.fun_Verificar_Campo_Lleno(obIADEDEEC.SelectedValue) = True Then

                If obVerifica.fun_Verificar_Dato_Numerico(obIADEDEPA.SelectedValue) = True And _
                   obVerifica.fun_Verificar_Dato_Numerico(obIADEMUNI.SelectedValue) = True And _
                   obVerifica.fun_Verificar_Dato_Numerico(obIADECLSE.SelectedValue) = True And _
                   obVerifica.fun_Verificar_Dato_Numerico(obIADEVIGE.SelectedValue) = True And _
                   obVerifica.fun_Verificar_Dato_Numerico(obIADEDEEC.SelectedValue) = True Then

                    Dim objdatos1 As New cla_INAVDEEC
                    Dim tbl As New DataTable

                    tbl = objdatos1.fun_Buscar_CODIGO_DEPA_MUNI_CLSE_VIGE_DEEC_X_INAVDEEC(obIADEDEPA.SelectedValue, _
                                                                                          obIADEMUNI.SelectedValue, _
                                                                                          obIADECLSE.SelectedValue, _
                                                                                          obIADEVIGE.SelectedValue, _
                                                                                          obIADEDEEC.SelectedValue)

                    If tbl.Rows.Count > 0 Then
                        MessageBox.Show("El dato " & Trim(obIADEDEPA.Text) & " - " & _
                                                     Trim(obIADEMUNI.Text) & " - " & _
                                                     Trim(obIADECLSE.Text) & " - " & _
                                                     Trim(obIADEVIGE.Text) & " - " & _
                                                     Trim(obIADEDEEC.Text) & " - " & " existe en la base de datos.", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                        obIADEDEPA.Focus()
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
    Public Function fun_Insertar_INAVDEEC(ByVal stIADEDEPA As String, _
                                          ByVal stIADEMUNI As String, _
                                          ByVal inIADECLSE As Integer, _
                                          ByVal inIADEVIGE As Integer, _
                                          ByVal inIADEDEEC As Integer, _
                                          ByVal stIADETARI As String, _
                                          ByVal stIADEESTA As String) As Boolean

        Try

            ' variables del sistema
            Dim stIADEMAQU As String = fun_Nombre_de_maquina()
            Dim stIADEUSIN As String = vp_usuario
            Dim stIADEUSMO As String = ""

            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "INSERT INTO "
            stConsultaSQL += "INAVDEEC "

            stConsultaSQL += "( "
            stConsultaSQL += "IADEDEPA, "
            stConsultaSQL += "IADEMUNI, "
            stConsultaSQL += "IADECLSE, "
            stConsultaSQL += "IADEDEEC, "
            stConsultaSQL += "IADETARI, "
            stConsultaSQL += "IADEESTA, "
            stConsultaSQL += "IADEVIGE, "
            stConsultaSQL += "IADEUSIN, "
            stConsultaSQL += "IADEUSMO, "
            stConsultaSQL += "IADEMAQU "
            stConsultaSQL += ") "

            stConsultaSQL += "VALUES "

            stConsultaSQL += "( "
            stConsultaSQL += "'" & CStr(Trim(stIADEDEPA)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stIADEMUNI)) & "', "
            stConsultaSQL += "'" & CInt(inIADECLSE) & "', "
            stConsultaSQL += "'" & CInt(inIADEDEEC) & "', "
            stConsultaSQL += "'" & CStr(Trim(stIADETARI)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stIADEESTA)) & "', "
            stConsultaSQL += "'" & CInt(inIADEVIGE) & "', "
            stConsultaSQL += "'" & CStr(Trim(stIADEUSIN)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stIADEUSMO)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stIADEMAQU)) & "' "
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
            MessageBox.Show(Err.Description & " " & "fun_Insertar_INAVDEEC")
        End Try

    End Function

    ''' <summary>
    ''' Función que Elimina el registro.
    ''' </summary>
    Public Function fun_Eliminar_INAVDEEC(ByVal inIADEIDRE As Integer) As Boolean

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "DELETE "
            stConsultaSQL += "INAVDEEC "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "IADEIDRE = '" & CInt(inIADEIDRE) & "' "

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
            MessageBox.Show(Err.Description & " " & "fun_Eliminar_INAVDEEC")
        End Try

    End Function

    ''' <summary>
    ''' Función que Modifica el registro.
    ''' </summary>
    Public Function fun_Actualizar_INAVDEEC(ByVal inIADEIDRE As Integer, _
                                          ByVal stIADEDEPA As String, _
                                          ByVal stIADEMUNI As String, _
                                          ByVal inIADECLSE As Integer, _
                                          ByVal inIADEDEEC As Integer, _
                                          ByVal stIADETARI As String, _
                                          ByVal stIADEESTA As String, _
                                          ByVal inIADEVIGE As Integer) As Boolean

        Try
            ' variables del sistema
            Dim stIADEMAQU As String = fun_Nombre_de_maquina()
            Dim stIADEUSMO As String = vp_usuario

            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "UPDATE "
            stConsultaSQL += "INAVDEEC "

            stConsultaSQL += "SET "
            stConsultaSQL += "IADEDEPA = '" & CStr(Trim(stIADEDEPA)) & "', "
            stConsultaSQL += "IADEMUNI = '" & CStr(Trim(stIADEMUNI)) & "', "
            stConsultaSQL += "IADECLSE = '" & CInt(inIADECLSE) & "', "
            stConsultaSQL += "IADEDEEC = '" & CInt(inIADEDEEC) & "', "
            stConsultaSQL += "IADETARI = '" & CStr(Trim(stIADETARI)) & "', "
            stConsultaSQL += "IADEESTA = '" & CStr(Trim(stIADEESTA)) & "', "
            stConsultaSQL += "IADEVIGE = '" & CInt(inIADEVIGE) & "', "
            stConsultaSQL += "IADEUSMO = '" & CStr(Trim(stIADEUSMO)) & "', "
            stConsultaSQL += "IADEMAQU = '" & CStr(Trim(stIADEMAQU)) & "' "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "IADEIDRE = '" & CInt(inIADEIDRE) & "'"

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
            MessageBox.Show(Err.Description & " " & "fun_Actualizar_INAVDEEC")
        End Try

    End Function

    ''' <summary>
    ''' Consulta para llenar el DataGridView y colocar el nombre del encabezado
    ''' de la columna. 
    ''' </summary>
    Public Function fun_Consultar_INAVDEEC() As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "IADEIDRE, "
            stConsultaSQL += "IADEDEPA, "
            stConsultaSQL += "IADEMUNI, "
            stConsultaSQL += "IADECLSE, "
            stConsultaSQL += "IADEVIGE, "
            stConsultaSQL += "IADEDEEC, "
            stConsultaSQL += "IADETARI, "
            stConsultaSQL += "IADEESTA  "

            stConsultaSQL += "FROM "
            stConsultaSQL += "INAVDEEC "

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "IADEDEPA, IADEMUNI, IADEVIGE, IADECLSE, IADEDEEC "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Consultar_INAVDEEC")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Llena el ComboBox con datos activos e inactivos formulario principal 
    ''' esta funcion se llama desde el procedimiento "pro_inicializarControles()".
    ''' </summary>
    Public Function fun_Consultar_CAMPOS_INAVDEEC() As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "INAVDEEC "

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "IADEDEPA, IADEMUNI, IADEVIGE, IADECLSE, IADEDEEC "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Consultar_CAMPOS_INAVDEEC")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Llena el ComboBox con datos activos formulario insertar y modificar 
    ''' esta funcion se llama desde el procedimiento "pro_inicializarControles()".
    ''' </summary>
    Public Function fun_Consultar_INAVDEEC_X_ESTADO() As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "INAVDEEC "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "IADEESTA = 'ac' "

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "IADEDEPA, IADEMUNI, IADEVIGE, IADECLSE, IADEDEEC "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Consultar_INAVDEEC_X_ESTADO")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que busca el ID del registro a modificar o eliminar.
    ''' </summary>
    Public Function fun_Buscar_ID_INAVDEEC(ByVal inIADEIDRE As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "INAVDEEC "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "IADEIDRE = '" & CInt(inIADEIDRE) & "'"

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Buscar_ID_INAVDEEC")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que busca el CÓDIGO para que no se 
    ''' guarden registros duplicados.
    ''' </summary>
    Public Function fun_Buscar_CODIGO_DEPA_MUNI_CLSE_VIGE_DEEC_X_INAVDEEC(ByVal stIADEDEPA As String, _
                                                                          ByVal stIADEMUNI As String, _
                                                                          ByVal inIADECLSE As Integer, _
                                                                          ByVal inIADEVIGE As Integer, _
                                                                          ByVal inIADEDEEC As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "INAVDEEC "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "IADEDEPA = '" & CStr(Trim(stIADEDEPA)) & "' and "
            stConsultaSQL += "IADEMUNI = '" & CStr(Trim(stIADEMUNI)) & "' and "
            stConsultaSQL += "IADECLSE = '" & CInt(inIADECLSE) & "' and "
            stConsultaSQL += "IADEVIGE = '" & CInt(inIADEVIGE) & "' and "
            stConsultaSQL += "IADEDEEC = '" & CInt(inIADEDEEC) & "' "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Buscar_CODIGO_INAVDEEC")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que busca el ID del codigo buscado para ejecutar la consulta
    ''' parametrizada.
    ''' </summary>
    Public Function fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_INAVDEEC(ByVal inIADEIDRE As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "IADEIDRE, "
            stConsultaSQL += "IADEDEPA, "
            stConsultaSQL += "IADEMUNI, "
            stConsultaSQL += "IADECLSE, "
            stConsultaSQL += "IADEVIGE, "
            stConsultaSQL += "IADEDEEC, "
            stConsultaSQL += "IADETARI, "
            stConsultaSQL += "IADEESTA  "

            stConsultaSQL += "FROM "
            stConsultaSQL += "INAVDEEC "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "IADEIDRE = '" & CInt(inIADEIDRE) & "'"

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "IADEDEPA, IADEMUNI, IADEVIGE, IADECLSE, IADEDEEC "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception

            MessageBox.Show(Err.Description & " " & "fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_INAVDEEC")
            Return Nothing

        End Try

    End Function

    ''' <summary>
    ''' Función que busca por depa, muni, sector, vigencia
    ''' </summary>
    Public Function fun_Buscar_CODIGO_DEPA_MUNI_CLSE_VIGE_X_INAVDEEC(ByVal stIADEDEPA As String, _
                                                                          ByVal stIADEMUNI As String, _
                                                                          ByVal inIADECLSE As Integer, _
                                                                          ByVal inIADEVIGE As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "INAVDEEC "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "IADEDEPA = '" & CStr(Trim(stIADEDEPA)) & "' and "
            stConsultaSQL += "IADEMUNI = '" & CStr(Trim(stIADEMUNI)) & "' and "
            stConsultaSQL += "IADECLSE = '" & CInt(inIADECLSE) & "' and "
            stConsultaSQL += "IADEVIGE = '" & CInt(inIADEVIGE) & "' "


            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Buscar_CODIGO_DEPA_MUNI_CLSE_VIGE_X_INAVDEEC")
            Return Nothing
        End Try

    End Function


End Class
