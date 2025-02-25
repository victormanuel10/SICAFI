Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration
Imports DATOS

Public Class cla_TARIRAAV

    '=====================================
    '*** CLASE TARIFA RANGO DE AVALUOS ***
    '=====================================

    ''' <summary>
    ''' procedimiento que verifica la llave primaria.
    ''' </summary>
    Public Function fun_Verifica_llave_Primaria_TARIRAAV(ByVal obTARADEPA As Object, _
                                                         ByVal obTARAMUNI As Object, _
                                                         ByVal obTARACLSE As Object, _
                                                         ByVal obTARAVIGE As Object, _
                                                         ByVal obTARADEEC As Object, _
                                                         ByVal obTARAESTR As Object, _
                                                         ByVal obTARATIPO As Object, _
                                                         ByVal obTARAAVIN As Object, _
                                                         ByVal obTARAAVFI As Object) As Boolean

        Try
            Dim boRespuesta As Boolean = False

            Dim obVerifica As New cla_Verificar_Dato

            If obVerifica.fun_Verificar_Campo_Lleno(obTARADEPA.SelectedValue) = True And _
               obVerifica.fun_Verificar_Campo_Lleno(obTARAMUNI.SelectedValue) = True And _
               obVerifica.fun_Verificar_Campo_Lleno(obTARACLSE.SelectedValue) = True And _
               obVerifica.fun_Verificar_Campo_Lleno(obTARAVIGE.SelectedValue) = True And _
               obVerifica.fun_Verificar_Campo_Lleno(obTARADEEC.SelectedValue) = True And _
               obVerifica.fun_Verificar_Campo_Lleno(obTARAESTR.SelectedValue) = True And _
               obVerifica.fun_Verificar_Campo_Lleno(obTARATIPO.SelectedValue) = True And _
               obVerifica.fun_Verificar_Campo_Lleno(obTARAAVIN.Text) = True And _
               obVerifica.fun_Verificar_Campo_Lleno(obTARAAVFI.Text) = True Then

                If obVerifica.fun_Verificar_Dato_Numerico(obTARADEPA.SelectedValue) = True And _
                   obVerifica.fun_Verificar_Dato_Numerico(obTARAMUNI.SelectedValue) = True And _
                   obVerifica.fun_Verificar_Dato_Numerico(obTARACLSE.SelectedValue) = True And _
                   obVerifica.fun_Verificar_Dato_Numerico(obTARAVIGE.SelectedValue) = True And _
                   obVerifica.fun_Verificar_Dato_Numerico(obTARADEEC.SelectedValue) = True And _
                   obVerifica.fun_Verificar_Dato_Numerico(obTARAESTR.SelectedValue) = True And _
                   obVerifica.fun_Verificar_Dato_Numerico(obTARAAVIN.Text) = True And _
                   obVerifica.fun_Verificar_Dato_Numerico(obTARAAVFI.Text) = True Then

                    Dim objdatos1 As New cla_TARIRAAV
                    Dim tbl As New DataTable

                    tbl = objdatos1.fun_Buscar_CODIGO_DEPA_MUNI_CLSE_VIGE_DEEC_ESTR_TIPO_AVIN_AVFI_X_TARIRAAV(obTARADEPA.SelectedValue, _
                                                                                          obTARAMUNI.SelectedValue, _
                                                                                          obTARACLSE.SelectedValue, _
                                                                                          obTARAVIGE.SelectedValue, _
                                                                                          obTARADEEC.SelectedValue, _
                                                                                          obTARAESTR.SelectedValue, _
                                                                                          obTARATIPO.SelectedValue, _
                                                                                          obTARAAVIN.Text, _
                                                                                          obTARAAVFI.Text)

                    If tbl.Rows.Count > 0 Then
                        MessageBox.Show("El dato " & Trim(obTARADEPA.Text) & " - " & _
                                                     Trim(obTARAMUNI.Text) & " - " & _
                                                     Trim(obTARACLSE.Text) & " - " & _
                                                     Trim(obTARAVIGE.Text) & " - " & _
                                                     Trim(obTARADEEC.Text) & " - " & _
                                                     Trim(obTARAESTR.Text) & " - " & _
                                                     Trim(obTARAAVIN.Text) & " - " & _
                                                     Trim(obTARAAVFI.Text) & " - " & " existe en la base de datos.", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                        obTARADEPA.Focus()
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
    Public Function fun_Insertar_TARIRAAV(ByVal stTARADEPA As String, _
                                          ByVal stTARAMUNI As String, _
                                          ByVal inTARACLSE As Integer, _
                                          ByVal inTARAVIGE As Integer, _
                                          ByVal inTARADEEC As Integer, _
                                          ByVal inTARAESTR As Integer, _
                                          ByVal stTARATIPO As String, _
                                          ByVal stTARATARI As String, _
                                          ByVal loTARAAVIN As Long, _
                                          ByVal loTARAAVFI As Long, _
                                          ByVal stTARAESTA As String) As Boolean

        Try

            ' variables del sistema
            Dim stTARAMAQU As String = fun_Nombre_de_maquina()
            Dim stTARAUSIN As String = vp_usuario
            Dim stTARAUSMO As String = ""

            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "INSERT INTO "
            stConsultaSQL += "TARIRAAV "

            stConsultaSQL += "( "
            stConsultaSQL += "TARADEPA, "
            stConsultaSQL += "TARAMUNI, "
            stConsultaSQL += "TARACLSE, "
            stConsultaSQL += "TARAVIGE, "
            stConsultaSQL += "TARADEEC, "
            stConsultaSQL += "TARAESTR, "
            stConsultaSQL += "TARATIPO, "
            stConsultaSQL += "TARATARI, "
            stConsultaSQL += "TARAAVIN, "
            stConsultaSQL += "TARAAVFI, "
            stConsultaSQL += "TARAESTA, "
            stConsultaSQL += "TARAUSIN, "
            stConsultaSQL += "TARAUSMO, "
            stConsultaSQL += "TARAMAQU "
            stConsultaSQL += ") "

            stConsultaSQL += "VALUES "

            stConsultaSQL += "( "
            stConsultaSQL += "'" & CStr(Trim(stTARADEPA)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stTARAMUNI)) & "', "
            stConsultaSQL += "'" & CInt(inTARACLSE) & "', "
            stConsultaSQL += "'" & CInt(inTARAVIGE) & "', "
            stConsultaSQL += "'" & CInt(inTARADEEC) & "', "
            stConsultaSQL += "'" & CInt(inTARAESTR) & "', "
            stConsultaSQL += "'" & CStr(Trim(stTARATIPO)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stTARATARI)) & "', "
            stConsultaSQL += "'" & CLng(loTARAAVIN) & "', "
            stConsultaSQL += "'" & CLng(loTARAAVFI) & "', "
            stConsultaSQL += "'" & CStr(Trim(stTARAESTA)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stTARAUSIN)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stTARAUSMO)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stTARAMAQU)) & "' "
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
            MessageBox.Show(Err.Description & " " & "fun_Insertar_TARIRAAV")
        End Try

    End Function

    ''' <summary>
    ''' Función que Elimina el registro.
    ''' </summary>
    Public Function fun_Eliminar_TARIRAAV(ByVal inTARAIDRE As Integer) As Boolean

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "DELETE "
            stConsultaSQL += "TARIRAAV "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "TARAIDRE = '" & CInt(inTARAIDRE) & "' "

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
            MessageBox.Show(Err.Description & " " & "fun_Eliminar_TARIRAAV")
        End Try

    End Function

    ''' <summary>
    ''' Función que Modifica el registro.
    ''' </summary>
    Public Function fun_Actualizar_TARIRAAV(ByVal inTARAIDRE As Integer, _
                                          ByVal stTARADEPA As String, _
                                          ByVal stTARAMUNI As String, _
                                          ByVal inTARACLSE As Integer, _
                                          ByVal inTARAVIGE As Integer, _
                                          ByVal inTARADEEC As Integer, _
                                          ByVal inTARAESTR As Integer, _
                                          ByVal stTARATIPO As String, _
                                          ByVal stTARATARI As String, _
                                          ByVal loTARAAVIN As Long, _
                                          ByVal loTARAAVFI As Long, _
                                          ByVal stTARAESTA As String) As Boolean

        Try
            ' variables del sistema
            Dim stTARAMAQU As String = fun_Nombre_de_maquina()
            Dim stTARAUSIN As String = vp_usuario
            Dim stTARAUSMO As String = vp_usuario

            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "UPDATE "
            stConsultaSQL += "TARIRAAV "

            stConsultaSQL += "SET "
            stConsultaSQL += "TARADEPA = '" & CStr(Trim(stTARADEPA)) & "', "
            stConsultaSQL += "TARAMUNI = '" & CStr(Trim(stTARAMUNI)) & "', "
            stConsultaSQL += "TARACLSE = '" & CInt(inTARACLSE) & "', "
            stConsultaSQL += "TARAVIGE = '" & CInt(inTARAVIGE) & "', "
            stConsultaSQL += "TARADEEC = '" & CInt(inTARADEEC) & "', "
            stConsultaSQL += "TARAESTR = '" & CInt(inTARAESTR) & "', "
            stConsultaSQL += "TARATIPO = '" & CStr(Trim(stTARATIPO)) & "', "
            stConsultaSQL += "TARATARI = '" & CStr(Trim(stTARATARI)) & "', "
            stConsultaSQL += "TARAAVIN = '" & CLng(loTARAAVIN) & "', "
            stConsultaSQL += "TARAAVFI = '" & CLng(loTARAAVFI) & "', "
            stConsultaSQL += "TARAESTA = '" & CStr(Trim(stTARAESTA)) & "', "
            stConsultaSQL += "TARAUSIN = '" & CStr(Trim(stTARAUSIN)) & "', "
            stConsultaSQL += "TARAUSMO = '" & CStr(Trim(stTARAUSMO)) & "', "
            stConsultaSQL += "TARAMAQU = '" & CStr(Trim(stTARAMAQU)) & "' "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "TARAIDRE = '" & CInt(inTARAIDRE) & "'"

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
            MessageBox.Show(Err.Description & " " & "fun_Actualizar_TARIRAAV")
        End Try

    End Function

    ''' <summary>
    ''' Consulta para llenar el DataGridView y colocar el nombre del encabezado
    ''' de la columna. 
    ''' </summary>
    Public Function fun_Consultar_TARIRAAV() As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "TARAIDRE, "
            stConsultaSQL += "TARADEPA, "
            stConsultaSQL += "TARAMUNI, "
            stConsultaSQL += "TARACLSE, "
            stConsultaSQL += "TARAVIGE, "
            stConsultaSQL += "TARADEEC, "
            stConsultaSQL += "TARAESTR, "
            stConsultaSQL += "TARATIPO, "
            stConsultaSQL += "TARATARI, "
            stConsultaSQL += "TARAAVIN, "
            stConsultaSQL += "TARAAVFI, "
            stConsultaSQL += "TARAESTA  "

            stConsultaSQL += "FROM "
            stConsultaSQL += "TARIRAAV "

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "TARADEPA, TARAMUNI, TARAVIGE, TARACLSE, TARAAVIN, TARAESTR  "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Consultar_TARIRAAV")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Llena el ComboBox con datos activos e inactivos formulario principal 
    ''' esta funcion se llama desde el procedimiento "pro_inicializarControles()".
    ''' </summary>
    Public Function fun_Consultar_CAMPOS_TARIRAAV() As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "TARIRAAV "

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "TARADEPA, TARAMUNI, TARAVIGE, TARACLSE "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Consultar_CAMPOS_TARIRAAV")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Llena el ComboBox con datos activos formulario insertar y modificar 
    ''' esta funcion se llama desde el procedimiento "pro_inicializarControles()".
    ''' </summary>
    Public Function fun_Consultar_TARIRAAV_X_ESTADO() As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "TARIRAAV "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "TARAESTA = 'ac' "

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "TARADEPA, TARAMUNI, TARAVIGE, TARACLSE "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Consultar_TARIRAAV_X_ESTADO")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que busca el ID del registro a modificar o eliminar.
    ''' </summary>
    Public Function fun_Buscar_ID_TARIRAAV(ByVal inTARAIDRE As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "TARIRAAV "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "TARAIDRE = '" & CInt(inTARAIDRE) & "'"

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Buscar_ID_TARIRAAV")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que busca el CÓDIGO para que no se 
    ''' guarden registros duplicados.
    ''' </summary>
    Public Function fun_Buscar_CODIGO_DEPA_MUNI_CLSE_VIGE_DEEC_ESTR_AVIN_AVFI_X_TARIRAAV(ByVal stTARADEPA As String, _
                                                                          ByVal stTARAMUNI As String, _
                                                                          ByVal inTARACLSE As Integer, _
                                                                          ByVal inTARAVIGE As Integer, _
                                                                          ByVal inTARADEEC As Integer, _
                                                                          ByVal inTARAESTR As Integer, _
                                                                          ByVal loTARAAVIN As Long, _
                                                                          ByVal loTARAAVFI As Long) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "TARIRAAV "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "TARADEPA = '" & CStr(Trim(stTARADEPA)) & "' and "
            stConsultaSQL += "TARAMUNI = '" & CStr(Trim(stTARAMUNI)) & "' and "
            stConsultaSQL += "TARACLSE = '" & CInt(inTARACLSE) & "' and "
            stConsultaSQL += "TARAVIGE = '" & CInt(inTARAVIGE) & "' and "
            stConsultaSQL += "TARADEEC = '" & CInt(inTARADEEC) & "' and "
            stConsultaSQL += "TARAESTR = '" & CInt(inTARAESTR) & "' and "
            stConsultaSQL += "TARAAVIN = '" & CLng(loTARAAVIN) & "' and "
            stConsultaSQL += "TARAAVFI = '" & CLng(loTARAAVFI) & "' "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Buscar_CODIGO_TARIRAAV")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que busca el CÓDIGO para que no se 
    ''' guarden registros duplicados.
    ''' </summary>
    Public Function fun_Buscar_CODIGO_DEPA_MUNI_CLSE_VIGE_DEEC_ESTR_TIPO_AVIN_AVFI_X_TARIRAAV(ByVal stTARADEPA As String, _
                                                                          ByVal stTARAMUNI As String, _
                                                                          ByVal inTARACLSE As Integer, _
                                                                          ByVal inTARAVIGE As Integer, _
                                                                          ByVal inTARADEEC As Integer, _
                                                                          ByVal inTARAESTR As Integer, _
                                                                          ByVal stTARATIPO As String, _
                                                                          ByVal loTARAAVIN As Long, _
                                                                          ByVal loTARAAVFI As Long) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "TARIRAAV "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "TARADEPA = '" & CStr(Trim(stTARADEPA)) & "' and "
            stConsultaSQL += "TARAMUNI = '" & CStr(Trim(stTARAMUNI)) & "' and "
            stConsultaSQL += "TARACLSE = '" & CInt(inTARACLSE) & "' and "
            stConsultaSQL += "TARAVIGE = '" & CInt(inTARAVIGE) & "' and "
            stConsultaSQL += "TARADEEC = '" & CInt(inTARADEEC) & "' and "
            stConsultaSQL += "TARAESTR = '" & CInt(inTARAESTR) & "' and "
            stConsultaSQL += "TARATIPO = '" & CStr(Trim(stTARATIPO)) & "' and "
            stConsultaSQL += "TARAAVIN = '" & CLng(loTARAAVIN) & "' and "
            stConsultaSQL += "TARAAVFI = '" & CLng(loTARAAVFI) & "' "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Buscar_CODIGO_TARIRAAV")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que busca el CÓDIGO para que no se 
    ''' guarden registros duplicados.
    ''' </summary>
    Public Function fun_Buscar_CODIGO_DEPA_MUNI_CLSE_VIGE_TIPO_ESTR_X_TARIRAAV(ByVal stTARADEPA As String, _
                                                                               ByVal stTARAMUNI As String, _
                                                                               ByVal inTARACLSE As Integer, _
                                                                               ByVal inTARAVIGE As Integer, _
                                                                               ByVal stTARATIPO As String, _
                                                                               ByVal inTARAESTR As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "TARIRAAV "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "TARADEPA = '" & CStr(Trim(stTARADEPA)) & "' and "
            stConsultaSQL += "TARAMUNI = '" & CStr(Trim(stTARAMUNI)) & "' and "
            stConsultaSQL += "TARACLSE = '" & CInt(inTARACLSE) & "' and "
            stConsultaSQL += "TARAVIGE = '" & CInt(inTARAVIGE) & "' and "
            stConsultaSQL += "TARATIPO = '" & CStr(Trim(stTARATIPO)) & "' and "
            stConsultaSQL += "TARAESTR = '" & CInt(inTARAESTR) & "' "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Buscar_CODIGO_TARIRAAV")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que busca el ID del codigo buscado para ejecutar la consulta
    ''' parametrizada.
    ''' </summary>
    Public Function fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_TARIRAAV(ByVal inTARAIDRE As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "TARAIDRE, "
            stConsultaSQL += "TARADEPA, "
            stConsultaSQL += "TARAMUNI, "
            stConsultaSQL += "TARACLSE, "
            stConsultaSQL += "TARAVIGE, "
            stConsultaSQL += "TARADEEC, "
            stConsultaSQL += "TARAESTR, "
            stConsultaSQL += "TARATIPO, "
            stConsultaSQL += "TARATARI, "
            stConsultaSQL += "TARAAVIN, "
            stConsultaSQL += "TARAAVFI, "
            stConsultaSQL += "TARAESTA  "

            stConsultaSQL += "FROM "
            stConsultaSQL += "TARIRAAV "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "TARAIDRE = '" & CInt(inTARAIDRE) & "' "

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "TARADEPA, TARAMUNI, TARAVIGE, TARACLSE "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception

            MessageBox.Show(Err.Description & " " & "fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_TARIRAAV")
            Return Nothing

        End Try

    End Function

    ''' <summary>
    ''' Función que busca el CÓDIGO para que no se 
    ''' guarden registros duplicados.
    ''' </summary>
    Public Function fun_Buscar_CODIGO_DEPA_MUNI_CLSE_VIGE_TIPO_X_TARIRAAV(ByVal stTARADEPA As String, _
                                                                          ByVal stTARAMUNI As String, _
                                                                          ByVal inTARACLSE As Integer, _
                                                                          ByVal inTARAVIGE As Integer, _
                                                                          ByVal stTARATIPO As String) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "TARIRAAV "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "TARADEPA = '" & CStr(Trim(stTARADEPA)) & "' and "
            stConsultaSQL += "TARAMUNI = '" & CStr(Trim(stTARAMUNI)) & "' and "
            stConsultaSQL += "TARACLSE = '" & CInt(inTARACLSE) & "' and "
            stConsultaSQL += "TARAVIGE = '" & CInt(inTARAVIGE) & "' and "
            stConsultaSQL += "TARATIPO = '" & CStr(Trim(stTARATIPO)) & "' "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Buscar_CODIGO_TARIRAAV")
            Return Nothing
        End Try

    End Function

End Class
