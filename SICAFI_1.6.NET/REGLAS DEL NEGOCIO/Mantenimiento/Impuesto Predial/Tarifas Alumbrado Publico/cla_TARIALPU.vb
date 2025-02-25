Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration
Imports DATOS

Public Class cla_TARIALPU

    '======================================
    '*** CLASE TARIFA ALUMBRADO PUBLICO ***
    '======================================

    ''' <summary>
    ''' procedimiento que verifica la llave primaria.
    ''' </summary>
    Public Function fun_Verifica_llave_Primaria_TARIALPU(ByVal obTAAPDEPA As Object, _
                                                         ByVal obTAAPMUNI As Object, _
                                                         ByVal obTAAPCLSE As Object, _
                                                         ByVal obTAAPVIGE As Object, _
                                                         ByVal obTAAPTIPO As Object, _
                                                         ByVal obTAAPTARE As Object, _
                                                         ByVal obTAAPTACO As Object, _
                                                         ByVal obTAAPTAIN As Object) As Boolean

        Try
            Dim boRespuesta As Boolean = False

            Dim obVerifica As New cla_Verificar_Dato

            If obVerifica.fun_Verificar_Campo_Lleno(obTAAPDEPA.SelectedValue) = True And _
               obVerifica.fun_Verificar_Campo_Lleno(obTAAPMUNI.SelectedValue) = True And _
               obVerifica.fun_Verificar_Campo_Lleno(obTAAPCLSE.SelectedValue) = True And _
               obVerifica.fun_Verificar_Campo_Lleno(obTAAPVIGE.SelectedValue) = True And _
               obVerifica.fun_Verificar_Campo_Lleno(obTAAPTIPO.SelectedValue) = True And _
               obVerifica.fun_Verificar_Campo_Lleno(obTAAPTARE.Text) = True And _
               obVerifica.fun_Verificar_Campo_Lleno(obTAAPTACO.Text) = True And _
               obVerifica.fun_Verificar_Campo_Lleno(obTAAPTAIN.Text) = True Then

                If obVerifica.fun_Verificar_Dato_Numerico(obTAAPDEPA.SelectedValue) = True And _
                   obVerifica.fun_Verificar_Dato_Numerico(obTAAPMUNI.SelectedValue) = True And _
                   obVerifica.fun_Verificar_Dato_Numerico(obTAAPCLSE.SelectedValue) = True And _
                   obVerifica.fun_Verificar_Dato_Numerico(obTAAPVIGE.SelectedValue) = True And _
                   obVerifica.fun_Verificar_Dato_Numerico(obTAAPTARE.Text) = True And _
                   obVerifica.fun_Verificar_Dato_Numerico(obTAAPTACO.Text) = True And _
                   obVerifica.fun_Verificar_Dato_Numerico(obTAAPTAIN.Text) = True Then

                    Dim objdatos1 As New cla_TARIALPU
                    Dim tbl As New DataTable

                    tbl = objdatos1.fun_Buscar_CODIGO_DEPA_MUNI_CLSE_VIGE_TIPO_TARE_TACO_TAIN_X_TARIALPU(obTAAPDEPA.SelectedValue, _
                                                                                                         obTAAPMUNI.SelectedValue, _
                                                                                                         obTAAPCLSE.SelectedValue, _
                                                                                                         obTAAPVIGE.SelectedValue, _
                                                                                                         obTAAPTIPO.SelectedValue, _
                                                                                                         Trim(obTAAPTARE.Text), _
                                                                                                         Trim(obTAAPTACO.Text), _
                                                                                                         Trim(obTAAPTAIN.Text))

                    If tbl.Rows.Count > 0 Then
                        MessageBox.Show("El dato " & Trim(obTAAPDEPA.Text) & " - " & _
                                                     Trim(obTAAPMUNI.Text) & " - " & _
                                                     Trim(obTAAPCLSE.Text) & " - " & _
                                                     Trim(obTAAPVIGE.Text) & " - " & _
                                                     Trim(obTAAPTIPO.Text) & " - " & _
                                                     Trim(obTAAPTARE.Text) & " - " & _
                                                     Trim(obTAAPTACO.Text) & " - " & _
                                                     Trim(obTAAPTAIN.Text) & " - " & " existe en la base de datos.", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                        obTAAPDEPA.Focus()
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
    Public Function fun_Insertar_TARIALPU(ByVal stTAAPDEPA As String, _
                                          ByVal stTAAPMUNI As String, _
                                          ByVal inTAAPCLSE As Integer, _
                                          ByVal inTAAPVIGE As Integer, _
                                          ByVal stTAAPTIPO As String, _
                                          ByVal inTAAPTARE As Integer, _
                                          ByVal inTAAPTACO As Integer, _
                                          ByVal inTAAPTAIN As Integer, _
                                          ByVal inTAAPESTR As Integer, _
                                          ByVal inTAAPTA01 As Integer, _
                                          ByVal inTAAPTA02 As Integer, _
                                          ByVal inTAAPTA03 As Integer, _
                                          ByVal inTAAPTA04 As Integer, _
                                          ByVal inTAAPTA05 As Integer, _
                                          ByVal loTAAPAVIN As Long, _
                                          ByVal loTAAPAVFI As Long, _
                                          ByVal stTAAPESTA As String) As Boolean

        Try

            ' variables del sistema
            Dim stTAAPMAQU As String = fun_Nombre_de_maquina()
            Dim stTAAPUSIN As String = vp_usuario
            Dim stTAAPUSMO As String = ""

            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "INSERT INTO "
            stConsultaSQL += "TARIALPU "

            stConsultaSQL += "( "
            stConsultaSQL += "TAAPDEPA, "
            stConsultaSQL += "TAAPMUNI, "
            stConsultaSQL += "TAAPCLSE, "
            stConsultaSQL += "TAAPVIGE, "
            stConsultaSQL += "TAAPTIPO, "
            stConsultaSQL += "TAAPTARE, "
            stConsultaSQL += "TAAPTACO, "
            stConsultaSQL += "TAAPTAIN, "
            stConsultaSQL += "TAAPESTR, "
            stConsultaSQL += "TAAPTA01, "
            stConsultaSQL += "TAAPTA02, "
            stConsultaSQL += "TAAPTA03, "
            stConsultaSQL += "TAAPTA04, "
            stConsultaSQL += "TAAPTA05, "
            stConsultaSQL += "TAAPAVIN, "
            stConsultaSQL += "TAAPAVFI, "
            stConsultaSQL += "TAAPESTA, "
            stConsultaSQL += "TAAPUSIN, "
            stConsultaSQL += "TAAPUSMO, "
            stConsultaSQL += "TAAPMAQU "
            stConsultaSQL += ") "

            stConsultaSQL += "VALUES "

            stConsultaSQL += "( "
            stConsultaSQL += "'" & CStr(Trim(stTAAPDEPA)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stTAAPMUNI)) & "', "
            stConsultaSQL += "'" & CInt(inTAAPCLSE) & "', "
            stConsultaSQL += "'" & CInt(inTAAPVIGE) & "', "
            stConsultaSQL += "'" & CStr(Trim(stTAAPTIPO)) & "', "
            stConsultaSQL += "'" & CInt(inTAAPTARE) & "', "
            stConsultaSQL += "'" & CInt(inTAAPTACO) & "', "
            stConsultaSQL += "'" & CInt(inTAAPTAIN) & "', "
            stConsultaSQL += "'" & CInt(inTAAPESTR) & "', "
            stConsultaSQL += "'" & CInt(inTAAPTA01) & "', "
            stConsultaSQL += "'" & CInt(inTAAPTA02) & "', "
            stConsultaSQL += "'" & CInt(inTAAPTA03) & "', "
            stConsultaSQL += "'" & CInt(inTAAPTA04) & "', "
            stConsultaSQL += "'" & CInt(inTAAPTA05) & "', "
            stConsultaSQL += "'" & CLng(loTAAPAVIN) & "', "
            stConsultaSQL += "'" & CLng(loTAAPAVFI) & "', "
            stConsultaSQL += "'" & CStr(Trim(stTAAPESTA)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stTAAPUSIN)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stTAAPUSMO)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stTAAPMAQU)) & "' "
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
            MessageBox.Show(Err.Description & " " & "fun_Insertar_TARIALPU")
        End Try

    End Function

    ''' <summary>
    ''' Función que Elimina el registro.
    ''' </summary>
    Public Function fun_Eliminar_TARIALPU(ByVal inTAAPIDRE As Integer) As Boolean

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "DELETE "
            stConsultaSQL += "TARIALPU "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "TAAPIDRE = '" & CInt(inTAAPIDRE) & "' "

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
            MessageBox.Show(Err.Description & " " & "fun_Eliminar_TARIALPU")
        End Try

    End Function

    ''' <summary>
    ''' Función que Modifica el registro.
    ''' </summary>
    Public Function fun_Actualizar_TARIALPU(ByVal inTAAPIDRE As Integer, _
                                          ByVal stTAAPDEPA As String, _
                                          ByVal stTAAPMUNI As String, _
                                          ByVal inTAAPCLSE As Integer, _
                                          ByVal inTAAPVIGE As Integer, _
                                          ByVal stTAAPTIPO As String, _
                                          ByVal inTAAPTARE As Integer, _
                                          ByVal inTAAPTACO As Integer, _
                                          ByVal inTAAPTAIN As Integer, _
                                          ByVal inTAAPESTR As Integer, _
                                          ByVal inTAAPTA01 As Integer, _
                                          ByVal inTAAPTA02 As Integer, _
                                          ByVal inTAAPTA03 As Integer, _
                                          ByVal inTAAPTA04 As Integer, _
                                          ByVal inTAAPTA05 As Integer, _
                                          ByVal loTAAPAVIN As Long, _
                                          ByVal loTAAPAVFI As Long, _
                                          ByVal stTAAPESTA As String) As Boolean

        Try
            ' variables del sistema
            Dim stTAAPMAQU As String = fun_Nombre_de_maquina()
            Dim stTAAPUSIN As String = vp_usuario
            Dim stTAAPUSMO As String = vp_usuario

            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "UPDATE "
            stConsultaSQL += "TARIALPU "

            stConsultaSQL += "SET "
            stConsultaSQL += "TAAPDEPA = '" & CStr(Trim(stTAAPDEPA)) & "', "
            stConsultaSQL += "TAAPMUNI = '" & CStr(Trim(stTAAPMUNI)) & "', "
            stConsultaSQL += "TAAPCLSE = '" & CInt(inTAAPCLSE) & "', "
            stConsultaSQL += "TAAPVIGE = '" & CInt(inTAAPVIGE) & "', "
            stConsultaSQL += "TAAPTIPO = '" & CStr(Trim(stTAAPTIPO)) & "', "
            stConsultaSQL += "TAAPTARE = '" & CInt(inTAAPTARE) & "', "
            stConsultaSQL += "TAAPTACO = '" & CInt(inTAAPTACO) & "', "
            stConsultaSQL += "TAAPTAIN = '" & CInt(inTAAPTAIN) & "', "
            stConsultaSQL += "TAAPESTR = '" & CInt(inTAAPESTR) & "', "
            stConsultaSQL += "TAAPTA01 = '" & CInt(inTAAPTA01) & "', "
            stConsultaSQL += "TAAPTA02 = '" & CInt(inTAAPTA02) & "', "
            stConsultaSQL += "TAAPTA03 = '" & CInt(inTAAPTA03) & "', "
            stConsultaSQL += "TAAPTA04 = '" & CInt(inTAAPTA04) & "', "
            stConsultaSQL += "TAAPTA05 = '" & CInt(inTAAPTA05) & "', "
            stConsultaSQL += "TAAPAVIN = '" & CLng(loTAAPAVIN) & "', "
            stConsultaSQL += "TAAPAVFI = '" & CLng(loTAAPAVFI) & "', "
            stConsultaSQL += "TAAPESTA = '" & CStr(Trim(stTAAPESTA)) & "', "
            stConsultaSQL += "TAAPUSIN = '" & CStr(Trim(stTAAPUSIN)) & "', "
            stConsultaSQL += "TAAPUSMO = '" & CStr(Trim(stTAAPUSMO)) & "', "
            stConsultaSQL += "TAAPMAQU = '" & CStr(Trim(stTAAPMAQU)) & "' "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "TAAPIDRE = '" & CInt(inTAAPIDRE) & "'"

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
            MessageBox.Show(Err.Description & " " & "fun_Actualizar_TARIALPU")
        End Try

    End Function

    ''' <summary>
    ''' Consulta para llenar el DataGridView y colocar el nombre del encabezado
    ''' de la columna. 
    ''' </summary>
    Public Function fun_Consultar_TARIALPU() As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "TAAPIDRE, "
            stConsultaSQL += "TAAPDEPA, "
            stConsultaSQL += "TAAPMUNI, "
            stConsultaSQL += "TAAPCLSE, "
            stConsultaSQL += "TAAPVIGE, "
            stConsultaSQL += "TAAPTIPO, "
            stConsultaSQL += "TAAPTARE, "
            stConsultaSQL += "TAAPTACO, "
            stConsultaSQL += "TAAPTAIN, "
            stConsultaSQL += "TAAPESTR, "
            stConsultaSQL += "TAAPTA01, "
            stConsultaSQL += "TAAPTA02, "
            stConsultaSQL += "TAAPTA03, "
            stConsultaSQL += "TAAPTA04, "
            stConsultaSQL += "TAAPTA05, "
            stConsultaSQL += "TAAPAVIN, "
            stConsultaSQL += "TAAPAVFI, "
            stConsultaSQL += "TAAPESTA  "

            stConsultaSQL += "FROM "
            stConsultaSQL += "TARIALPU "

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "TAAPDEPA, TAAPMUNI, TAAPCLSE "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Consultar_TARIALPU")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Llena el ComboBox con datos activos e inactivos formulario principal 
    ''' esta funcion se llama desde el procedimiento "pro_inicializarControles()".
    ''' </summary>
    Public Function fun_Consultar_CAMPOS_TARIALPU() As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "TARIALPU "

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "TAAPDEPA, TAAPMUNI, TAAPCLSE "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Consultar_CAMPOS_TARIALPU")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Llena el ComboBox con datos activos formulario insertar y modificar 
    ''' esta funcion se llama desde el procedimiento "pro_inicializarControles()".
    ''' </summary>
    Public Function fun_Consultar_TARIALPU_X_ESTADO() As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "TARIALPU "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "TAAPESTA = 'ac' "

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "TAAPDEPA, TAAPMUNI, TAAPCLSE "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Consultar_TARIALPU_X_ESTADO")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que busca el ID del registro a modificar o eliminar.
    ''' </summary>
    Public Function fun_Buscar_ID_TARIALPU(ByVal inTAAPIDRE As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "TARIALPU "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "TAAPIDRE = '" & CInt(inTAAPIDRE) & "'"

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Buscar_ID_TARIALPU")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que busca el CÓDIGO para que no se 
    ''' guarden registros duplicados.
    ''' </summary>
    Public Function fun_Buscar_CODIGO_DEPA_MUNI_CLSE_VIGE_TIPO_TARE_TACO_TAIN_X_TARIALPU(ByVal stTAAPDEPA As String, _
                                                                                         ByVal stTAAPMUNI As String, _
                                                                                         ByVal inTAAPCLSE As Integer, _
                                                                                         ByVal inTAAPVIGE As Integer, _
                                                                                         ByVal stTAAPTIPO As String, _
                                                                                         ByVal inTAAPTARE As Integer, _
                                                                                         ByVal inTAAPTACO As Integer, _
                                                                                         ByVal inTAAPTAIN As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "TARIALPU "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "TAAPDEPA = '" & CStr(Trim(stTAAPDEPA)) & "' and "
            stConsultaSQL += "TAAPMUNI = '" & CStr(Trim(stTAAPMUNI)) & "' and "
            stConsultaSQL += "TAAPCLSE = '" & CInt(inTAAPCLSE) & "' and "
            stConsultaSQL += "TAAPVIGE = '" & CInt(inTAAPVIGE) & "' and "
            stConsultaSQL += "TAAPTIPO = '" & CStr(Trim(stTAAPTIPO)) & "' and "
            stConsultaSQL += "TAAPTARE = '" & CInt(inTAAPTARE) & "' and "
            stConsultaSQL += "TAAPTACO = '" & CInt(inTAAPTACO) & "' and "
            stConsultaSQL += "TAAPTAIN = '" & CInt(inTAAPTAIN) & "' "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Buscar_CODIGO_TARIALPU")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que busca el ID del codigo buscado para ejecutar la consulta
    ''' parametrizada.
    ''' </summary>
    Public Function fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_TARIALPU(ByVal inTAAPIDRE As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "TAAPIDRE, "
            stConsultaSQL += "TAAPDEPA, "
            stConsultaSQL += "TAAPMUNI, "
            stConsultaSQL += "TAAPCLSE, "
            stConsultaSQL += "TAAPVIGE, "
            stConsultaSQL += "TAAPTIPO, "
            stConsultaSQL += "TAAPTARE, "
            stConsultaSQL += "TAAPTACO, "
            stConsultaSQL += "TAAPTAIN, "
            stConsultaSQL += "TAAPESTR, "
            stConsultaSQL += "TAAPTA01, "
            stConsultaSQL += "TAAPTA02, "
            stConsultaSQL += "TAAPTA03, "
            stConsultaSQL += "TAAPTA04, "
            stConsultaSQL += "TAAPTA05, "
            stConsultaSQL += "TAAPAVIN, "
            stConsultaSQL += "TAAPAVFI, "
            stConsultaSQL += "TAAPESTA  "


            stConsultaSQL += "FROM "
            stConsultaSQL += "TARIALPU "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "TAAPIDRE = '" & CInt(inTAAPIDRE) & "'"

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "TAAPDEPA, TAAPMUNI, TAAPCLSE "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception

            MessageBox.Show(Err.Description & " " & "fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_TARIALPU")
            Return Nothing

        End Try

    End Function

End Class
