Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration
Imports DATOS

Public Class cla_TARIACBO

    '=======================================
    '*** CLASE TARIFA ACTIVIDAD BOMBERIL ***
    '=======================================

    ''' <summary>
    ''' procedimiento que verifica la llave primaria.
    ''' </summary>
    Public Function fun_Verifica_llave_Primaria_TARIACBO(ByVal obTAABDEPA As Object, _
                                                         ByVal obTAABMUNI As Object, _
                                                         ByVal obTAABCLSE As Object, _
                                                         ByVal obTAABVIGE As Object, _
                                                         ByVal obTAABTIPO As Object, _
                                                         ByVal obTAABTARE As Object, _
                                                         ByVal obTAABTACO As Object, _
                                                         ByVal obTAABTAIN As Object) As Boolean

        Try
            Dim boRespuesta As Boolean = False

            Dim obVerifica As New cla_Verificar_Dato

            If obVerifica.fun_Verificar_Campo_Lleno(obTAABDEPA.SelectedValue) = True And _
               obVerifica.fun_Verificar_Campo_Lleno(obTAABMUNI.SelectedValue) = True And _
               obVerifica.fun_Verificar_Campo_Lleno(obTAABCLSE.SelectedValue) = True And _
               obVerifica.fun_Verificar_Campo_Lleno(obTAABVIGE.SelectedValue) = True And _
               obVerifica.fun_Verificar_Campo_Lleno(obTAABTIPO.SelectedValue) = True And _
               obVerifica.fun_Verificar_Campo_Lleno(obTAABTARE.Text) = True And _
               obVerifica.fun_Verificar_Campo_Lleno(obTAABTACO.Text) = True And _
               obVerifica.fun_Verificar_Campo_Lleno(obTAABTAIN.Text) = True Then

                If obVerifica.fun_Verificar_Dato_Numerico(obTAABDEPA.SelectedValue) = True And _
                   obVerifica.fun_Verificar_Dato_Numerico(obTAABMUNI.SelectedValue) = True And _
                   obVerifica.fun_Verificar_Dato_Numerico(obTAABCLSE.SelectedValue) = True And _
                   obVerifica.fun_Verificar_Dato_Numerico(obTAABVIGE.SelectedValue) = True And _
                   obVerifica.fun_Verificar_Dato_Numerico(obTAABTARE.Text) = True And _
                   obVerifica.fun_Verificar_Dato_Numerico(obTAABTACO.Text) = True And _
                   obVerifica.fun_Verificar_Dato_Numerico(obTAABTAIN.Text) = True Then

                    Dim objdatos1 As New cla_TARIACBO
                    Dim tbl As New DataTable

                    tbl = objdatos1.fun_Buscar_CODIGO_DEPA_MUNI_CLSE_VIGE_TIPO_TARE_TACO_TAIN_X_TARIACBO(obTAABDEPA.SelectedValue, _
                                                                                                         obTAABMUNI.SelectedValue, _
                                                                                                         obTAABCLSE.SelectedValue, _
                                                                                                         obTAABVIGE.SelectedValue, _
                                                                                                         obTAABTIPO.SelectedValue, _
                                                                                                         Trim(obTAABTARE.Text), _
                                                                                                         Trim(obTAABTACO.Text), _
                                                                                                         Trim(obTAABTAIN.Text))

                    If tbl.Rows.Count > 0 Then
                        MessageBox.Show("El dato " & Trim(obTAABDEPA.Text) & " - " & _
                                                     Trim(obTAABMUNI.Text) & " - " & _
                                                     Trim(obTAABCLSE.Text) & " - " & _
                                                     Trim(obTAABVIGE.Text) & " - " & _
                                                     Trim(obTAABTIPO.Text) & " - " & _
                                                     Trim(obTAABTARE.Text) & " - " & _
                                                     Trim(obTAABTACO.Text) & " - " & _
                                                     Trim(obTAABTAIN.Text) & " - " & " existe en la base de datos.", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                        obTAABDEPA.Focus()
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
    Public Function fun_Insertar_TARIACBO(ByVal stTAABDEPA As String, _
                                          ByVal stTAABMUNI As String, _
                                          ByVal inTAABCLSE As Integer, _
                                          ByVal inTAABVIGE As Integer, _
                                          ByVal stTAABTIPO As String, _
                                          ByVal inTAABTARE As Integer, _
                                          ByVal inTAABTACO As Integer, _
                                          ByVal inTAABTAIN As Integer, _
                                          ByVal inTAABESTR As Integer, _
                                          ByVal inTAABTA01 As Integer, _
                                          ByVal inTAABTA02 As Integer, _
                                          ByVal inTAABTA03 As Integer, _
                                          ByVal inTAABTA04 As Integer, _
                                          ByVal inTAABTA05 As Integer, _
                                          ByVal loTAABAVIN As Long, _
                                          ByVal loTAABAVFI As Long, _
                                          ByVal stTAABESTA As String) As Boolean

        Try

            ' variables del sistema
            Dim stTAABMAQU As String = fun_Nombre_de_maquina()
            Dim stTAABUSIN As String = vp_usuario
            Dim stTAABUSMO As String = ""

            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "INSERT INTO "
            stConsultaSQL += "TARIACBO "

            stConsultaSQL += "( "
            stConsultaSQL += "TAABDEPA, "
            stConsultaSQL += "TAABMUNI, "
            stConsultaSQL += "TAABCLSE, "
            stConsultaSQL += "TAABVIGE, "
            stConsultaSQL += "TAABTIPO, "
            stConsultaSQL += "TAABTARE, "
            stConsultaSQL += "TAABTACO, "
            stConsultaSQL += "TAABTAIN, "
            stConsultaSQL += "TAABESTR, "
            stConsultaSQL += "TAABTA01, "
            stConsultaSQL += "TAABTA02, "
            stConsultaSQL += "TAABTA03, "
            stConsultaSQL += "TAABTA04, "
            stConsultaSQL += "TAABTA05, "
            stConsultaSQL += "TAABAVIN, "
            stConsultaSQL += "TAABAVFI, "
            stConsultaSQL += "TAABESTA, "
            stConsultaSQL += "TAABUSIN, "
            stConsultaSQL += "TAABUSMO, "
            stConsultaSQL += "TAABMAQU "
            stConsultaSQL += ") "

            stConsultaSQL += "VALUES "

            stConsultaSQL += "( "
            stConsultaSQL += "'" & CStr(Trim(stTAABDEPA)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stTAABMUNI)) & "', "
            stConsultaSQL += "'" & CInt(inTAABCLSE) & "', "
            stConsultaSQL += "'" & CInt(inTAABVIGE) & "', "
            stConsultaSQL += "'" & CStr(Trim(stTAABTIPO)) & "', "
            stConsultaSQL += "'" & CInt(inTAABTARE) & "', "
            stConsultaSQL += "'" & CInt(inTAABTACO) & "', "
            stConsultaSQL += "'" & CInt(inTAABTAIN) & "', "
            stConsultaSQL += "'" & CInt(inTAABESTR) & "', "
            stConsultaSQL += "'" & CInt(inTAABTA01) & "', "
            stConsultaSQL += "'" & CInt(inTAABTA02) & "', "
            stConsultaSQL += "'" & CInt(inTAABTA03) & "', "
            stConsultaSQL += "'" & CInt(inTAABTA04) & "', "
            stConsultaSQL += "'" & CInt(inTAABTA05) & "', "
            stConsultaSQL += "'" & CLng(loTAABAVIN) & "', "
            stConsultaSQL += "'" & CLng(loTAABAVFI) & "', "
            stConsultaSQL += "'" & CStr(Trim(stTAABESTA)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stTAABUSIN)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stTAABUSMO)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stTAABMAQU)) & "' "
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
            MessageBox.Show(Err.Description & " " & "fun_Insertar_TARIACBO")
        End Try

    End Function

    ''' <summary>
    ''' Función que Elimina el registro.
    ''' </summary>
    Public Function fun_Eliminar_TARIACBO(ByVal inTAABIDRE As Integer) As Boolean

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "DELETE "
            stConsultaSQL += "TARIACBO "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "TAABIDRE = '" & CInt(inTAABIDRE) & "' "

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
            MessageBox.Show(Err.Description & " " & "fun_Eliminar_TARIACBO")
        End Try

    End Function

    ''' <summary>
    ''' Función que Modifica el registro.
    ''' </summary>
    Public Function fun_Actualizar_TARIACBO(ByVal inTAABIDRE As Integer, _
                                          ByVal stTAABDEPA As String, _
                                          ByVal stTAABMUNI As String, _
                                          ByVal inTAABCLSE As Integer, _
                                          ByVal inTAABVIGE As Integer, _
                                          ByVal stTAABTIPO As String, _
                                          ByVal inTAABTARE As Integer, _
                                          ByVal inTAABTACO As Integer, _
                                          ByVal inTAABTAIN As Integer, _
                                          ByVal inTAABESTR As Integer, _
                                          ByVal inTAABTA01 As Integer, _
                                          ByVal inTAABTA02 As Integer, _
                                          ByVal inTAABTA03 As Integer, _
                                          ByVal inTAABTA04 As Integer, _
                                          ByVal inTAABTA05 As Integer, _
                                          ByVal loTAABAVIN As Long, _
                                          ByVal loTAABAVFI As Long, _
                                          ByVal stTAABESTA As String) As Boolean

        Try
            ' variables del sistema
            Dim stTAABMAQU As String = fun_Nombre_de_maquina()
            Dim stTAABUSIN As String = vp_usuario
            Dim stTAABUSMO As String = vp_usuario

            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "UPDATE "
            stConsultaSQL += "TARIACBO "

            stConsultaSQL += "SET "
            stConsultaSQL += "TAABDEPA = '" & CStr(Trim(stTAABDEPA)) & "', "
            stConsultaSQL += "TAABMUNI = '" & CStr(Trim(stTAABMUNI)) & "', "
            stConsultaSQL += "TAABCLSE = '" & CInt(inTAABCLSE) & "', "
            stConsultaSQL += "TAABVIGE = '" & CInt(inTAABVIGE) & "', "
            stConsultaSQL += "TAABTIPO = '" & CStr(Trim(stTAABTIPO)) & "', "
            stConsultaSQL += "TAABTARE = '" & CInt(inTAABTARE) & "', "
            stConsultaSQL += "TAABTACO = '" & CInt(inTAABTACO) & "', "
            stConsultaSQL += "TAABTAIN = '" & CInt(inTAABTAIN) & "', "
            stConsultaSQL += "TAABESTR = '" & CInt(inTAABESTR) & "', "
            stConsultaSQL += "TAABTA01 = '" & CInt(inTAABTA01) & "', "
            stConsultaSQL += "TAABTA02 = '" & CInt(inTAABTA02) & "', "
            stConsultaSQL += "TAABTA03 = '" & CInt(inTAABTA03) & "', "
            stConsultaSQL += "TAABTA04 = '" & CInt(inTAABTA04) & "', "
            stConsultaSQL += "TAABTA05 = '" & CInt(inTAABTA05) & "', "
            stConsultaSQL += "TAABAVIN = '" & CLng(loTAABAVIN) & "', "
            stConsultaSQL += "TAABAVFI = '" & CLng(loTAABAVFI) & "', "
            stConsultaSQL += "TAABESTA = '" & CStr(Trim(stTAABESTA)) & "', "
            stConsultaSQL += "TAABUSIN = '" & CStr(Trim(stTAABUSIN)) & "', "
            stConsultaSQL += "TAABUSMO = '" & CStr(Trim(stTAABUSMO)) & "', "
            stConsultaSQL += "TAABMAQU = '" & CStr(Trim(stTAABMAQU)) & "' "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "TAABIDRE = '" & CInt(inTAABIDRE) & "'"

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
            MessageBox.Show(Err.Description & " " & "fun_Actualizar_TARIACBO")
        End Try

    End Function

    ''' <summary>
    ''' Consulta para llenar el DataGridView y colocar el nombre del encabezado
    ''' de la columna. 
    ''' </summary>
    Public Function fun_Consultar_TARIACBO() As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "TAABIDRE, "
            stConsultaSQL += "TAABDEPA, "
            stConsultaSQL += "TAABMUNI, "
            stConsultaSQL += "TAABCLSE, "
            stConsultaSQL += "TAABVIGE, "
            stConsultaSQL += "TAABTIPO, "
            stConsultaSQL += "TAABTARE, "
            stConsultaSQL += "TAABTACO, "
            stConsultaSQL += "TAABTAIN, "
            stConsultaSQL += "TAABESTR, "
            stConsultaSQL += "TAABTA01, "
            stConsultaSQL += "TAABTA02, "
            stConsultaSQL += "TAABTA03, "
            stConsultaSQL += "TAABTA04, "
            stConsultaSQL += "TAABTA05, "
            stConsultaSQL += "TAABAVIN, "
            stConsultaSQL += "TAABAVFI, "
            stConsultaSQL += "TAABESTA  "

            stConsultaSQL += "FROM "
            stConsultaSQL += "TARIACBO "

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "TAABDEPA, TAABMUNI, TAABCLSE "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Consultar_TARIACBO")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Llena el ComboBox con datos activos e inactivos formulario principal 
    ''' esta funcion se llama desde el procedimiento "pro_inicializarControles()".
    ''' </summary>
    Public Function fun_Consultar_CAMPOS_TARIACBO() As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "TARIACBO "

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "TAABDEPA, TAABMUNI, TAABCLSE "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Consultar_CAMPOS_TARIACBO")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Llena el ComboBox con datos activos formulario insertar y modificar 
    ''' esta funcion se llama desde el procedimiento "pro_inicializarControles()".
    ''' </summary>
    Public Function fun_Consultar_TARIACBO_X_ESTADO() As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "TARIACBO "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "TAABESTA = 'ac' "

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "TAABDEPA, TAABMUNI, TAABCLSE "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Consultar_TARIACBO_X_ESTADO")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que busca el ID del registro a modificar o eliminar.
    ''' </summary>
    Public Function fun_Buscar_ID_TARIACBO(ByVal inTAABIDRE As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "TARIACBO "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "TAABIDRE = '" & CInt(inTAABIDRE) & "'"

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Buscar_ID_TARIACBO")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que busca el CÓDIGO para que no se 
    ''' guarden registros duplicados.
    ''' </summary>
    Public Function fun_Buscar_CODIGO_DEPA_MUNI_CLSE_VIGE_TIPO_TARE_TACO_TAIN_X_TARIACBO(ByVal stTAABDEPA As String, _
                                                                                         ByVal stTAABMUNI As String, _
                                                                                         ByVal inTAABCLSE As Integer, _
                                                                                         ByVal inTAABVIGE As Integer, _
                                                                                         ByVal stTAABTIPO As String, _
                                                                                         ByVal inTAABTARE As Integer, _
                                                                                         ByVal inTAABTACO As Integer, _
                                                                                         ByVal inTAABTAIN As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "TARIACBO "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "TAABDEPA = '" & CStr(Trim(stTAABDEPA)) & "' and "
            stConsultaSQL += "TAABMUNI = '" & CStr(Trim(stTAABMUNI)) & "' and "
            stConsultaSQL += "TAABCLSE = '" & CInt(inTAABCLSE) & "' and "
            stConsultaSQL += "TAABVIGE = '" & CInt(inTAABVIGE) & "' and "
            stConsultaSQL += "TAABTIPO = '" & CStr(Trim(stTAABTIPO)) & "' and "
            stConsultaSQL += "TAABTARE = '" & CInt(inTAABTARE) & "' and "
            stConsultaSQL += "TAABTACO = '" & CInt(inTAABTACO) & "' and "
            stConsultaSQL += "TAABTAIN = '" & CInt(inTAABTAIN) & "' "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Buscar_CODIGO_TARIACBO")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que busca el ID del codigo buscado para ejecutar la consulta
    ''' parametrizada.
    ''' </summary>
    Public Function fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_TARIACBO(ByVal inTAABIDRE As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "TAABIDRE, "
            stConsultaSQL += "TAABDEPA, "
            stConsultaSQL += "TAABMUNI, "
            stConsultaSQL += "TAABCLSE, "
            stConsultaSQL += "TAABVIGE, "
            stConsultaSQL += "TAABTIPO, "
            stConsultaSQL += "TAABTARE, "
            stConsultaSQL += "TAABTACO, "
            stConsultaSQL += "TAABTAIN, "
            stConsultaSQL += "TAABESTR, "
            stConsultaSQL += "TAABTA01, "
            stConsultaSQL += "TAABTA02, "
            stConsultaSQL += "TAABTA03, "
            stConsultaSQL += "TAABTA04, "
            stConsultaSQL += "TAABTA05, "
            stConsultaSQL += "TAABAVIN, "
            stConsultaSQL += "TAABAVFI, "
            stConsultaSQL += "TAABESTA  "

            stConsultaSQL += "FROM "
            stConsultaSQL += "TARIACBO "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "TAABIDRE = '" & CInt(inTAABIDRE) & "'"

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "TAABDEPA, TAABMUNI, TAABCLSE "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception

            MessageBox.Show(Err.Description & " " & "fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_TARIACBO")
            Return Nothing

        End Try

    End Function

End Class
