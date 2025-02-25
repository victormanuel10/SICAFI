Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration
Imports DATOS

Public Class cla_TARIPRES

    '=======================================
    '*** CLASE TARIFA PREDIOS ESPECIALES ***
    '=======================================

    ''' <summary>
    ''' procedimiento que verifica la llave primaria.
    ''' </summary>
    Public Function fun_Verifica_llave_Primaria_TARIPRES(ByVal obTAPEDEPA As Object, _
                                                         ByVal obTAPEMUNI As Object, _
                                                         ByVal obTAPECLSE As Object, _
                                                         ByVal obTAPEVIGE As Object, _
                                                         ByVal obTAPEDEEC As Object) As Boolean

        Try
            Dim boRespuesta As Boolean = False

            Dim obVerifica As New cla_Verificar_Dato

            If obVerifica.fun_Verificar_Campo_Lleno(obTAPEDEPA.SelectedValue) = True And _
               obVerifica.fun_Verificar_Campo_Lleno(obTAPEMUNI.SelectedValue) = True And _
               obVerifica.fun_Verificar_Campo_Lleno(obTAPECLSE.SelectedValue) = True And _
               obVerifica.fun_Verificar_Campo_Lleno(obTAPEVIGE.SelectedValue) = True And _
               obVerifica.fun_Verificar_Campo_Lleno(obTAPEDEEC.SelectedValue) = True Then

                If obVerifica.fun_Verificar_Dato_Numerico(obTAPEDEPA.SelectedValue) = True And _
                   obVerifica.fun_Verificar_Dato_Numerico(obTAPEMUNI.SelectedValue) = True And _
                   obVerifica.fun_Verificar_Dato_Numerico(obTAPECLSE.SelectedValue) = True And _
                   obVerifica.fun_Verificar_Dato_Numerico(obTAPEVIGE.SelectedValue) = True And _
                   obVerifica.fun_Verificar_Dato_Numerico(obTAPEDEEC.SelectedValue) = True Then

                    Dim objdatos1 As New cla_TARIPRES
                    Dim tbl As New DataTable

                    tbl = objdatos1.fun_Buscar_CODIGO_DEPA_MUNI_CLSE_VIGE_DEEC_X_TARIPRES(obTAPEDEPA.SelectedValue, _
                                                                                          obTAPEMUNI.SelectedValue, _
                                                                                          obTAPECLSE.SelectedValue, _
                                                                                          obTAPEVIGE.SelectedValue, _
                                                                                          obTAPEDEEC.SelectedValue)

                    If tbl.Rows.Count > 0 Then
                        MessageBox.Show("El dato " & Trim(obTAPEDEPA.Text) & " - " & _
                                                     Trim(obTAPEMUNI.Text) & " - " & _
                                                     Trim(obTAPECLSE.Text) & " - " & _
                                                     Trim(obTAPEVIGE.Text) & " - " & _
                                                     Trim(obTAPEDEEC.Text) & " - " & " existe en la base de datos.", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                        obTAPEDEPA.Focus()
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
    Public Function fun_Insertar_TARIPRES(ByVal stTAPEDEPA As String, _
                                          ByVal stTAPEMUNI As String, _
                                          ByVal inTAPECLSE As Integer, _
                                          ByVal inTAPEVIGE As Integer, _
                                          ByVal inTAPEDEEC As Integer, _
                                          ByVal inTAPETARI As Integer, _
                                          ByVal loTAPEAVIN As Long, _
                                          ByVal loTAPEAVFI As Long, _
                                          ByVal stTAPEESTA As String) As Boolean

        Try

            ' variables del sistema
            Dim stTAPEMAQU As String = fun_Nombre_de_maquina()
            Dim stTAPEUSIN As String = vp_usuario
            Dim stTAPEUSMO As String = ""

            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "INSERT INTO "
            stConsultaSQL += "TARIPRES "

            stConsultaSQL += "( "
            stConsultaSQL += "TAPEDEPA, "
            stConsultaSQL += "TAPEMUNI, "
            stConsultaSQL += "TAPECLSE, "
            stConsultaSQL += "TAPEVIGE, "
            stConsultaSQL += "TAPEDEEC, "
            stConsultaSQL += "TAPETARI, "
            stConsultaSQL += "TAPEAVIN, "
            stConsultaSQL += "TAPEAVFI, "
            stConsultaSQL += "TAPEESTA, "
            stConsultaSQL += "TAPEUSIN, "
            stConsultaSQL += "TAPEUSMO, "
            stConsultaSQL += "TAPEMAQU "
            stConsultaSQL += ") "

            stConsultaSQL += "VALUES "

            stConsultaSQL += "( "
            stConsultaSQL += "'" & CStr(Trim(stTAPEDEPA)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stTAPEMUNI)) & "', "
            stConsultaSQL += "'" & CInt(inTAPECLSE) & "', "
            stConsultaSQL += "'" & CInt(inTAPEVIGE) & "', "
            stConsultaSQL += "'" & CInt(inTAPEDEEC) & "', "
            stConsultaSQL += "'" & CInt(inTAPETARI) & "', "
            stConsultaSQL += "'" & CLng(loTAPEAVIN) & "', "
            stConsultaSQL += "'" & CLng(loTAPEAVFI) & "', "
            stConsultaSQL += "'" & CStr(Trim(stTAPEESTA)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stTAPEUSIN)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stTAPEUSMO)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stTAPEMAQU)) & "' "
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
            MessageBox.Show(Err.Description & " " & "fun_Insertar_TARIPRES")
        End Try

    End Function

    ''' <summary>
    ''' Función que Elimina el registro.
    ''' </summary>
    Public Function fun_Eliminar_TARIPRES(ByVal inTAPEIDRE As Integer) As Boolean

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "DELETE "
            stConsultaSQL += "TARIPRES "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "TAPEIDRE = '" & CInt(inTAPEIDRE) & "' "

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
            MessageBox.Show(Err.Description & " " & "fun_Eliminar_TARIPRES")
        End Try

    End Function

    ''' <summary>
    ''' Función que Modifica el registro.
    ''' </summary>
    Public Function fun_Actualizar_TARIPRES(ByVal inTAPEIDRE As Integer, _
                                          ByVal stTAPEDEPA As String, _
                                          ByVal stTAPEMUNI As String, _
                                          ByVal inTAPECLSE As Integer, _
                                          ByVal inTAPEVIGE As Integer, _
                                          ByVal inTAPEDEEC As Integer, _
                                          ByVal inTAPETARI As Integer, _
                                          ByVal loTAPEAVIN As Long, _
                                          ByVal loTAPEAVFI As Long, _
                                          ByVal stTAPEESTA As String) As Boolean

        Try
            ' variables del sistema
            Dim stTAPEMAQU As String = fun_Nombre_de_maquina()
            Dim stTAPEUSIN As String = vp_usuario
            Dim stTAPEUSMO As String = vp_usuario

            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "UPDATE "
            stConsultaSQL += "TARIPRES "

            stConsultaSQL += "SET "
            stConsultaSQL += "TAPEDEPA = '" & CStr(Trim(stTAPEDEPA)) & "', "
            stConsultaSQL += "TAPEMUNI = '" & CStr(Trim(stTAPEMUNI)) & "', "
            stConsultaSQL += "TAPECLSE = '" & CInt(inTAPECLSE) & "', "
            stConsultaSQL += "TAPEVIGE = '" & CInt(inTAPEVIGE) & "', "
            stConsultaSQL += "TAPEDEEC = '" & CInt(inTAPEDEEC) & "', "
            stConsultaSQL += "TAPETARI = '" & CInt(inTAPETARI) & "', "
            stConsultaSQL += "TAPEAVIN = '" & CLng(loTAPEAVIN) & "', "
            stConsultaSQL += "TAPEAVFI = '" & CLng(loTAPEAVFI) & "', "
            stConsultaSQL += "TAPEESTA = '" & CStr(Trim(stTAPEESTA)) & "', "
            stConsultaSQL += "TAPEUSIN = '" & CStr(Trim(stTAPEUSIN)) & "', "
            stConsultaSQL += "TAPEUSMO = '" & CStr(Trim(stTAPEUSMO)) & "', "
            stConsultaSQL += "TAPEMAQU = '" & CStr(Trim(stTAPEMAQU)) & "' "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "TAPEIDRE = '" & CInt(inTAPEIDRE) & "'"

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
            MessageBox.Show(Err.Description & " " & "fun_Actualizar_TARIPRES")
        End Try

    End Function

    ''' <summary>
    ''' Consulta para llenar el DataGridView y colocar el nombre del encabezado
    ''' de la columna. 
    ''' </summary>
    Public Function fun_Consultar_TARIPRES() As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "TAPEIDRE, "
            stConsultaSQL += "TAPEDEPA, "
            stConsultaSQL += "TAPEMUNI, "
            stConsultaSQL += "TAPECLSE, "
            stConsultaSQL += "TAPEVIGE, "
            stConsultaSQL += "TAPEDEEC, "
            stConsultaSQL += "TAPETARI, "
            stConsultaSQL += "TAPEAVIN, "
            stConsultaSQL += "TAPEAVFI, "
            stConsultaSQL += "TAPEESTA  "

            stConsultaSQL += "FROM "
            stConsultaSQL += "TARIPRES "

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "TAPEDEPA, TAPEMUNI, TAPECLSE "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Consultar_TARIPRES")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Llena el ComboBox con datos activos e inactivos formulario principal 
    ''' esta funcion se llama desde el procedimiento "pro_inicializarControles()".
    ''' </summary>
    Public Function fun_Consultar_CAMPOS_TARIPRES() As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "TARIPRES "

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "TAPEDEPA, TAPEMUNI, TAPECLSE, TAPEDEEC "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Consultar_CAMPOS_TARIPRES")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Llena el ComboBox con datos activos formulario insertar y modificar 
    ''' esta funcion se llama desde el procedimiento "pro_inicializarControles()".
    ''' </summary>
    Public Function fun_Consultar_TARIPRES_X_ESTADO() As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "TARIPRES "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "TAPEESTA = 'ac' "

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "TAPEDEPA, TAPEMUNI, TAPECLSE, TAPEDEEC "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Consultar_TARIPRES_X_ESTADO")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que busca el ID del registro a modificar o eliminar.
    ''' </summary>
    Public Function fun_Buscar_ID_TARIPRES(ByVal inTAPEIDRE As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "TARIPRES "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "TAPEIDRE = '" & CInt(inTAPEIDRE) & "'"

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Buscar_ID_TARIPRES")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que busca el CÓDIGO para que no se 
    ''' guarden registros duplicados.
    ''' </summary>
    Public Function fun_Buscar_CODIGO_DEPA_MUNI_CLSE_VIGE_DEEC_X_TARIPRES(ByVal stTAPEDEPA As String, _
                                                                          ByVal stTAPEMUNI As String, _
                                                                          ByVal inTAPECLSE As Integer, _
                                                                          ByVal inTAPEVIGE As Integer, _
                                                                          ByVal inTAPEDEEC As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "TARIPRES "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "TAPEDEPA = '" & CStr(Trim(stTAPEDEPA)) & "' and "
            stConsultaSQL += "TAPEMUNI = '" & CStr(Trim(stTAPEMUNI)) & "' and "
            stConsultaSQL += "TAPECLSE = '" & CInt(inTAPECLSE) & "' and "
            stConsultaSQL += "TAPEVIGE = '" & CInt(inTAPEVIGE) & "' and "
            stConsultaSQL += "TAPEDEEC = '" & CInt(inTAPEDEEC) & "' "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Buscar_CODIGO_TARIPRES")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que busca el ID del codigo buscado para ejecutar la consulta
    ''' parametrizada.
    ''' </summary>
    Public Function fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_TARIPRES(ByVal inTAPEIDRE As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "TAPEIDRE, "
            stConsultaSQL += "TAPEDEPA, "
            stConsultaSQL += "TAPEMUNI, "
            stConsultaSQL += "TAPECLSE, "
            stConsultaSQL += "TAPEVIGE, "
            stConsultaSQL += "TAPEDEEC, "
            stConsultaSQL += "TAPETARI, "
            stConsultaSQL += "TAPEAVIN, "
            stConsultaSQL += "TAPEAVFI, "
            stConsultaSQL += "TAPEESTA  "

            stConsultaSQL += "FROM "
            stConsultaSQL += "TARIPRES "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "TAPEIDRE = '" & CInt(inTAPEIDRE) & "'"

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "TAPEDEPA, TAPEMUNI, TAPECLSE "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception

            MessageBox.Show(Err.Description & " " & "fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_TARIPRES")
            Return Nothing

        End Try

    End Function

End Class
