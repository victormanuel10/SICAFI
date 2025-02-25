Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration
Imports DATOS

Public Class cla_TARIDEEC

    '==========================================
    '*** CLASE TARIFA DESTINACIÓN ECONÓMICA ***
    '==========================================

    ''' <summary>
    ''' procedimiento que verifica la llave primaria.
    ''' </summary>
    Public Function fun_Verifica_llave_Primaria_TARIDEEC(ByVal obTADEDEPA As Object, _
                                                         ByVal obTADEMUNI As Object, _
                                                         ByVal obTADECLSE As Object, _
                                                         ByVal obTADEVIGE As Object, _
                                                         ByVal obTADEDEEC As Object) As Boolean

        Try
            Dim boRespuesta As Boolean = False

            Dim obVerifica As New cla_Verificar_Dato

            If obVerifica.fun_Verificar_Campo_Lleno(obTADEDEPA.SelectedValue) = True And _
               obVerifica.fun_Verificar_Campo_Lleno(obTADEMUNI.SelectedValue) = True And _
               obVerifica.fun_Verificar_Campo_Lleno(obTADECLSE.SelectedValue) = True And _
               obVerifica.fun_Verificar_Campo_Lleno(obTADEVIGE.SelectedValue) = True And _
               obVerifica.fun_Verificar_Campo_Lleno(obTADEDEEC.SelectedValue) = True Then

                If obVerifica.fun_Verificar_Dato_Numerico(obTADEDEPA.SelectedValue) = True And _
                   obVerifica.fun_Verificar_Dato_Numerico(obTADEMUNI.SelectedValue) = True And _
                   obVerifica.fun_Verificar_Dato_Numerico(obTADECLSE.SelectedValue) = True And _
                   obVerifica.fun_Verificar_Dato_Numerico(obTADEVIGE.SelectedValue) = True And _
                   obVerifica.fun_Verificar_Dato_Numerico(obTADEDEEC.SelectedValue) = True Then

                    Dim objdatos1 As New cla_TARIDEEC
                    Dim tbl As New DataTable

                    tbl = objdatos1.fun_Buscar_CODIGO_DEPA_MUNI_CLSE_VIGE_DEEC_X_TARIDEEC(obTADEDEPA.SelectedValue, _
                                                                                          obTADEMUNI.SelectedValue, _
                                                                                          obTADECLSE.SelectedValue, _
                                                                                          obTADEVIGE.SelectedValue, _
                                                                                          obTADEDEEC.SelectedValue)

                    If tbl.Rows.Count > 0 Then
                        MessageBox.Show("El dato " & Trim(obTADEDEPA.Text) & " - " & _
                                                     Trim(obTADEMUNI.Text) & " - " & _
                                                     Trim(obTADECLSE.Text) & " - " & _
                                                     Trim(obTADEVIGE.Text) & " - " & _
                                                     Trim(obTADEDEEC.Text) & " - " & " existe en la base de datos.", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                        obTADEDEPA.Focus()
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
    Public Function fun_Insertar_TARIDEEC(ByVal stTADEDEPA As String, _
                                          ByVal stTADEMUNI As String, _
                                          ByVal inTADECLSE As Integer, _
                                          ByVal inTADEVIGE As Integer, _
                                          ByVal inTADEDEEC As Integer, _
                                          ByVal stTADETARI As String, _
                                          ByVal stTADEESTA As String) As Boolean

        Try

            ' variables del sistema
            Dim stTADEMAQU As String = fun_Nombre_de_maquina()
            Dim stTADEUSIN As String = vp_usuario
            Dim stTADEUSMO As String = ""

            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "INSERT INTO "
            stConsultaSQL += "TARIDEEC "

            stConsultaSQL += "( "
            stConsultaSQL += "TADEDEPA, "
            stConsultaSQL += "TADEMUNI, "
            stConsultaSQL += "TADECLSE, "
            stConsultaSQL += "TADEDEEC, "
            stConsultaSQL += "TADETARI, "
            stConsultaSQL += "TADEESTA, "
            stConsultaSQL += "TADEVIGE, "
            stConsultaSQL += "TADEUSIN, "
            stConsultaSQL += "TADEUSMO, "
            stConsultaSQL += "TADEMAQU "
            stConsultaSQL += ") "

            stConsultaSQL += "VALUES "

            stConsultaSQL += "( "
            stConsultaSQL += "'" & CStr(Trim(stTADEDEPA)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stTADEMUNI)) & "', "
            stConsultaSQL += "'" & CInt(inTADECLSE) & "', "
            stConsultaSQL += "'" & CInt(inTADEDEEC) & "', "
            stConsultaSQL += "'" & CStr(Trim(stTADETARI)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stTADEESTA)) & "', "
            stConsultaSQL += "'" & CInt(inTADEVIGE) & "', "
            stConsultaSQL += "'" & CStr(Trim(stTADEUSIN)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stTADEUSMO)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stTADEMAQU)) & "' "
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
            MessageBox.Show(Err.Description & " " & "fun_Insertar_TARIDEEC")
        End Try

    End Function

    ''' <summary>
    ''' Función que Elimina el registro.
    ''' </summary>
    Public Function fun_Eliminar_TARIDEEC(ByVal inTADEIDRE As Integer) As Boolean

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "DELETE "
            stConsultaSQL += "TARIDEEC "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "TADEIDRE = '" & CInt(inTADEIDRE) & "' "

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
            MessageBox.Show(Err.Description & " " & "fun_Eliminar_TARIDEEC")
        End Try

    End Function

    ''' <summary>
    ''' Función que Modifica el registro.
    ''' </summary>
    Public Function fun_Actualizar_TARIDEEC(ByVal inTADEIDRE As Integer, _
                                          ByVal stTADEDEPA As String, _
                                          ByVal stTADEMUNI As String, _
                                          ByVal inTADECLSE As Integer, _
                                          ByVal inTADEDEEC As Integer, _
                                          ByVal stTADETARI As String, _
                                          ByVal stTADEESTA As String, _
                                          ByVal inTADEVIGE As Integer) As Boolean

        Try
            ' variables del sistema
            Dim stTADEMAQU As String = fun_Nombre_de_maquina()
            Dim stTADEUSIN As String = vp_usuario
            Dim stTADEUSMO As String = vp_usuario

            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "UPDATE "
            stConsultaSQL += "TARIDEEC "

            stConsultaSQL += "SET "
            stConsultaSQL += "TADEDEPA = '" & CStr(Trim(stTADEDEPA)) & "', "
            stConsultaSQL += "TADEMUNI = '" & CStr(Trim(stTADEMUNI)) & "', "
            stConsultaSQL += "TADECLSE = '" & CInt(inTADECLSE) & "', "
            stConsultaSQL += "TADEDEEC = '" & CInt(inTADEDEEC) & "', "
            stConsultaSQL += "TADETARI = '" & CStr(Trim(stTADETARI)) & "', "
            stConsultaSQL += "TADEESTA = '" & CStr(Trim(stTADEESTA)) & "', "
            stConsultaSQL += "TADEVIGE = '" & CInt(inTADEVIGE) & "', "
            stConsultaSQL += "TADEUSIN = '" & CStr(Trim(stTADEUSIN)) & "', "
            stConsultaSQL += "TADEUSMO = '" & CStr(Trim(stTADEUSMO)) & "', "
            stConsultaSQL += "TADEMAQU = '" & CStr(Trim(stTADEMAQU)) & "' "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "TADEIDRE = '" & CInt(inTADEIDRE) & "'"

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
            MessageBox.Show(Err.Description & " " & "fun_Actualizar_TARIDEEC")
        End Try

    End Function

    ''' <summary>
    ''' Consulta para llenar el DataGridView y colocar el nombre del encabezado
    ''' de la columna. 
    ''' </summary>
    Public Function fun_Consultar_TARIDEEC() As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "TARIDEEC "

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "TADEDEPA, TADEMUNI, TADEVIGE, TADECLSE, TADEDEEC "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Consultar_TARIDEEC")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Llena el ComboBox con datos activos e inactivos formulario principal 
    ''' esta funcion se llama desde el procedimiento "pro_inicializarControles()".
    ''' </summary>
    Public Function fun_Consultar_CAMPOS_TARIDEEC() As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "TARIDEEC "

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "TADEDEPA, TADEMUNI, TADEVIGE, TADECLSE, TADEDEEC "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Consultar_CAMPOS_TARIDEEC")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Llena el ComboBox con datos activos formulario insertar y modificar 
    ''' esta funcion se llama desde el procedimiento "pro_inicializarControles()".
    ''' </summary>
    Public Function fun_Consultar_TARIDEEC_X_ESTADO() As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "TARIDEEC "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "TADEESTA = 'ac' "

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "TADEDEPA, TADEMUNI, TADEVIGE, TADECLSE, TADEDEEC "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Consultar_TARIDEEC_X_ESTADO")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que busca el ID del registro a modificar o eliminar.
    ''' </summary>
    Public Function fun_Buscar_ID_TARIDEEC(ByVal inTADEIDRE As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "TARIDEEC "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "TADEIDRE = '" & CInt(inTADEIDRE) & "'"

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Buscar_ID_TARIDEEC")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que busca el ID del codigo buscado para ejecutar la consulta
    ''' parametrizada.
    ''' </summary>
    Public Function fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_TARIDEEC(ByVal inTADEIDRE As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "TADEIDRE, "
            stConsultaSQL += "TADEDEPA, "
            stConsultaSQL += "TADEMUNI, "
            stConsultaSQL += "TADECLSE, "
            stConsultaSQL += "TADEVIGE, "
            stConsultaSQL += "TADEDEEC, "
            stConsultaSQL += "TADETARI, "
            stConsultaSQL += "TADEESTA  "

            stConsultaSQL += "FROM "
            stConsultaSQL += "TARIDEEC "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "TADEIDRE = '" & CInt(inTADEIDRE) & "'"

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "TADEDEPA, TADEMUNI, TADEVIGE, TADECLSE, TADEDEEC "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception

            MessageBox.Show(Err.Description & " " & "fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_TARIDEEC")
            Return Nothing

        End Try

    End Function

    ''' <summary>
    ''' Función que busca por depa, muni, sector, vigencia
    ''' </summary>
    Public Function fun_Buscar_CODIGO_DEPA_MUNI_CLSE_VIGE_X_TARIDEEC(ByVal stTADEDEPA As String, _
                                                                          ByVal stTADEMUNI As String, _
                                                                          ByVal inTADECLSE As Integer, _
                                                                          ByVal inTADEVIGE As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "TARIDEEC "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "TADEDEPA = '" & CStr(Trim(stTADEDEPA)) & "' and "
            stConsultaSQL += "TADEMUNI = '" & CStr(Trim(stTADEMUNI)) & "' and "
            stConsultaSQL += "TADECLSE = '" & CInt(inTADECLSE) & "' and "
            stConsultaSQL += "TADEVIGE = '" & CInt(inTADEVIGE) & "' "


            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Buscar_CODIGO_DEPA_MUNI_CLSE_VIGE_X_TARIDEEC")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que busca por depa, muni, sector, vigencia
    ''' </summary>
    Public Function fun_Buscar_CODIGO_DEPA_MUNI_CLSE_VIGE_DEEC_X_TARIDEEC(ByVal stTADEDEPA As String, _
                                                                          ByVal stTADEMUNI As String, _
                                                                          ByVal inTADECLSE As Integer, _
                                                                          ByVal inTADEVIGE As Integer, _
                                                                          ByVal stTADEDEEC As String) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "TARIDEEC "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "TADEDEPA = '" & CStr(Trim(stTADEDEPA)) & "' and "
            stConsultaSQL += "TADEMUNI = '" & CStr(Trim(stTADEMUNI)) & "' and "
            stConsultaSQL += "TADECLSE = '" & CInt(inTADECLSE) & "' and "
            stConsultaSQL += "TADEVIGE = '" & CInt(inTADEVIGE) & "' and "
            stConsultaSQL += "TADEDEEC = '" & CStr(Trim(stTADEDEEC)) & "' "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Buscar_CODIGO_DEPA_MUNI_CLSE_VIGE_X_TARIDEEC")
            Return Nothing
        End Try

    End Function

End Class
