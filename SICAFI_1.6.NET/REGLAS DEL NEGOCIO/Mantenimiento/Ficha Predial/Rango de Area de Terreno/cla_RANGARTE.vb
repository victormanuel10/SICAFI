Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration
Imports DATOS

Public Class cla_RANGARTE

    '======================================
    '*** CLASE RANGO DE AREA DE TERRENO ***
    '======================================

    ''' <summary>
    ''' procedimiento que verifica la llave primaria.
    ''' </summary>
    Public Function fun_Verifica_llave_Primaria_RANGARTE(ByVal obRAATDEPA As Object, _
                                                         ByVal obRAATMUNI As Object, _
                                                         ByVal obRAATCLSE As Object, _
                                                         ByVal obRAATATIN As Object, _
                                                         ByVal obRAATATFI As Object) As Boolean

        Try
            Dim boRespuesta As Boolean = False

            Dim obVerifica As New cla_Verificar_Dato

            If obVerifica.fun_Verificar_Campo_Lleno(obRAATDEPA.SelectedValue) = True And _
               obVerifica.fun_Verificar_Campo_Lleno(obRAATMUNI.SelectedValue) = True And _
               obVerifica.fun_Verificar_Campo_Lleno(obRAATCLSE.SelectedValue) = True And _
               obVerifica.fun_Verificar_Campo_Lleno(obRAATATIN.Text) = True And _
               obVerifica.fun_Verificar_Campo_Lleno(obRAATATFI.Text) = True Then

                If obVerifica.fun_Verificar_Dato_Numerico(obRAATDEPA.SelectedValue) = True And _
                   obVerifica.fun_Verificar_Dato_Numerico(obRAATMUNI.SelectedValue) = True And _
                   obVerifica.fun_Verificar_Dato_Numerico(obRAATCLSE.SelectedValue) = True And _
                   obVerifica.fun_Verificar_Dato_Numerico(obRAATATIN.Text) = True And _
                   obVerifica.fun_Verificar_Dato_Numerico(obRAATATFI.Text) = True Then

                    Dim objdatos1 As New cla_RANGARTE
                    Dim tbl As New DataTable

                    tbl = objdatos1.fun_Buscar_CODIGO_DEPA_MUNI_CLSE_X_RANGARTE(obRAATDEPA.SelectedValue, _
                                                                                obRAATMUNI.SelectedValue, _
                                                                                obRAATCLSE.SelectedValue, _
                                                                                obRAATATIN.Text, _
                                                                                obRAATATFI.Text)

                    If tbl.Rows.Count > 0 Then
                        MessageBox.Show("El dato " & Trim(obRAATDEPA.Text) & " - " & _
                                                     Trim(obRAATMUNI.Text) & " - " & _
                                                     Trim(obRAATCLSE.Text) & " - " & _
                                                     Trim(obRAATATIN.Text) & " - " & _
                                                     Trim(obRAATATFI.Text) & " - " & " existe en la base de datos.", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                        obRAATDEPA.Focus()
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
    Public Function fun_Insertar_RANGARTE(ByVal stRAATDEPA As String, _
                                          ByVal stRAATMUNI As String, _
                                          ByVal inRAATCLSE As Integer, _
                                          ByVal inRAATATIN As Integer, _
                                          ByVal inRAATATFI As Integer, _
                                          ByVal stRAATPORC As String, _
                                          ByVal stRAATESTA As String) As Boolean

        Try

            ' variables del sistema
            Dim stRAATMAQU As String = fun_Nombre_de_maquina()
            Dim stRAATUSIN As String = vp_usuario
            Dim stRAATUSMO As String = ""

            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "INSERT INTO "
            stConsultaSQL += "RANGARTE "

            stConsultaSQL += "( "
            stConsultaSQL += "RAATDEPA, "
            stConsultaSQL += "RAATMUNI, "
            stConsultaSQL += "RAATCLSE, "
            stConsultaSQL += "RAATATIN, "
            stConsultaSQL += "RAATATFI, "
            stConsultaSQL += "RAATPORC, "
            stConsultaSQL += "RAATESTA, "
            stConsultaSQL += "RAATUSIN, "
            stConsultaSQL += "RAATUSMO, "
            stConsultaSQL += "RAATMAQU "
            stConsultaSQL += ") "

            stConsultaSQL += "VALUES "

            stConsultaSQL += "( "
            stConsultaSQL += "'" & CStr(Trim(stRAATDEPA)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stRAATMUNI)) & "', "
            stConsultaSQL += "'" & CInt(inRAATCLSE) & "', "
            stConsultaSQL += "'" & CInt(inRAATATIN) & "', "
            stConsultaSQL += "'" & CInt(inRAATATFI) & "', "
            stConsultaSQL += "'" & CStr(Trim(stRAATPORC)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stRAATESTA)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stRAATUSIN)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stRAATUSMO)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stRAATMAQU)) & "' "
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
            MessageBox.Show(Err.Description & " " & "fun_Insertar_RANGARTE")
        End Try

    End Function

    ''' <summary>
    ''' Función que Elimina el registro.
    ''' </summary>
    Public Function fun_Eliminar_RANGARTE(ByVal inRAATIDRE As Integer) As Boolean

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "DELETE "
            stConsultaSQL += "RANGARTE "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "RAATIDRE = '" & CInt(inRAATIDRE) & "' "

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
            MessageBox.Show(Err.Description & " " & "fun_Eliminar_RANGARTE")
        End Try

    End Function

    ''' <summary>
    ''' Función que Modifica el registro.
    ''' </summary>
    Public Function fun_Actualizar_RANGARTE(ByVal inRAATIDRE As Integer, _
                                          ByVal stRAATDEPA As String, _
                                          ByVal stRAATMUNI As String, _
                                          ByVal inRAATCLSE As Integer, _
                                          ByVal inRAATATIN As Integer, _
                                          ByVal inRAATATFI As Integer, _
                                          ByVal stRAATPORC As String, _
                                          ByVal stRAATESTA As String) As Boolean

        Try
            ' variables del sistema
            Dim stRAATMAQU As String = fun_Nombre_de_maquina()
            Dim stRAATUSIN As String = vp_usuario
            Dim stRAATUSMO As String = vp_usuario

            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "UPDATE "
            stConsultaSQL += "RANGARTE "

            stConsultaSQL += "SET "
            stConsultaSQL += "RAATDEPA = '" & CStr(Trim(stRAATDEPA)) & "', "
            stConsultaSQL += "RAATMUNI = '" & CStr(Trim(stRAATMUNI)) & "', "
            stConsultaSQL += "RAATCLSE = '" & CInt(inRAATCLSE) & "', "
            stConsultaSQL += "RAATATIN = '" & CInt(inRAATATIN) & "', "
            stConsultaSQL += "RAATATFI = '" & CInt(inRAATATFI) & "', "
            stConsultaSQL += "RAATPORC = '" & CStr(Trim(stRAATPORC)) & "', "
            stConsultaSQL += "RAATESTA = '" & CStr(Trim(stRAATESTA)) & "', "
            stConsultaSQL += "RAATUSIN = '" & CStr(Trim(stRAATUSIN)) & "', "
            stConsultaSQL += "RAATUSMO = '" & CStr(Trim(stRAATUSMO)) & "', "
            stConsultaSQL += "RAATMAQU = '" & CStr(Trim(stRAATMAQU)) & "' "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "RAATIDRE = '" & CInt(inRAATIDRE) & "'"

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
            MessageBox.Show(Err.Description & " " & "fun_Actualizar_RANGARTE")
        End Try

    End Function

    ''' <summary>
    ''' Consulta para llenar el DataGridView y colocar el nombre del encabezado
    ''' de la columna. 
    ''' </summary>
    Public Function fun_Consultar_RANGARTE() As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "RAATIDRE, "
            stConsultaSQL += "RAATDEPA, "
            stConsultaSQL += "DEPADESC, "
            stConsultaSQL += "RAATMUNI, "
            stConsultaSQL += "MUNIDESC, "
            stConsultaSQL += "RAATCLSE, "
            stConsultaSQL += "CLSEDESC, "
            stConsultaSQL += "RAATATIN, "
            stConsultaSQL += "RAATATFI, "
            stConsultaSQL += "RAATPORC, "
            stConsultaSQL += "RAATESTA, "
            stConsultaSQL += "ESTADESC  "

            stConsultaSQL += "FROM "
            stConsultaSQL += "RANGARTE, "
            stConsultaSQL += "MANT_DEPARTAMENTO, "
            stConsultaSQL += "MANT_MUNICIPIO, "
            stConsultaSQL += "MANT_CLASSECT, "
            stConsultaSQL += "ESTADO "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "DEPACODI = RAATDEPA AND "
            stConsultaSQL += "MUNIDEPA = RAATDEPA AND "
            stConsultaSQL += "MUNICODI = RAATMUNI AND "
            stConsultaSQL += "CLSECODI = RAATCLSE AND "
            stConsultaSQL += "RAATESTA = ESTACODI "

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "RAATDEPA, RAATMUNI, RAATCLSE, RAATATIN "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Consultar_RANGARTE")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Llena el ComboBox con datos activos e inactivos formulario principal 
    ''' esta funcion se llama desde el procedimiento "pro_inicializarControles()".
    ''' </summary>
    Public Function fun_Consultar_CAMPOS_RANGARTE() As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "RANGARTE "

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "RAATDEPA, RAATMUNI, RAATCLSE, RAATATIN "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Consultar_CAMPOS_RANGARTE")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Llena el ComboBox con datos activos formulario insertar y modificar 
    ''' esta funcion se llama desde el procedimiento "pro_inicializarControles()".
    ''' </summary>
    Public Function fun_Consultar_RANGARTE_X_ESTADO() As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "RANGARTE "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "RAATESTA = 'ac' "

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "RAATDEPA, RAATMUNI, RAATCLSE, RAATATIN "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Consultar_RANGARTE_X_ESTADO")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que busca el ID del registro a modificar o eliminar.
    ''' </summary>
    Public Function fun_Buscar_ID_RANGARTE(ByVal inRAATIDRE As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "RANGARTE "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "RAATIDRE = '" & CInt(inRAATIDRE) & "'"

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Buscar_ID_RANGARTE")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que busca el CÓDIGO para que no se 
    ''' guarden registros duplicados.
    ''' </summary>
    Public Function fun_Buscar_CODIGO_DEPA_MUNI_CLSE_X_RANGARTE(ByVal stRAATDEPA As String, _
                                                                ByVal stRAATMUNI As String, _
                                                                ByVal inRAATCLSE As Integer, _
                                                                ByVal inRAATATIN As Integer, _
                                                                ByVal inRAATATFI As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "RANGARTE "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "RAATDEPA = '" & CStr(Trim(stRAATDEPA)) & "' and "
            stConsultaSQL += "RAATMUNI = '" & CStr(Trim(stRAATMUNI)) & "' and "
            stConsultaSQL += "RAATCLSE = '" & CInt(inRAATCLSE) & "' and "
            stConsultaSQL += "RAATATIN = '" & CInt(inRAATATIN) & "' and "
            stConsultaSQL += "RAATATFI = '" & CInt(inRAATATFI) & "' "


            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Buscar_CODIGO_RANGARTE")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que busca el ID del codigo buscado para ejecutar la consulta
    ''' parametrizada.
    ''' </summary>
    Public Function fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_RANGARTE(ByVal inRAATIDRE As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "RAATIDRE, "
            stConsultaSQL += "RAATDEPA, "
            stConsultaSQL += "DEPADESC, "
            stConsultaSQL += "RAATMUNI, "
            stConsultaSQL += "MUNIDESC, "
            stConsultaSQL += "RAATCLSE, "
            stConsultaSQL += "CLSEDESC, "
            stConsultaSQL += "RAATATIN, "
            stConsultaSQL += "RAATATFI, "
            stConsultaSQL += "RAATPORC, "
            stConsultaSQL += "RAATESTA, "
            stConsultaSQL += "ESTADESC  "

            stConsultaSQL += "FROM "
            stConsultaSQL += "RANGARTE, "
            stConsultaSQL += "MANT_DEPARTAMENTO, "
            stConsultaSQL += "MANT_MUNICIPIO, "
            stConsultaSQL += "MANT_CLASSECT, "
            stConsultaSQL += "ESTADO "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "DEPACODI = RAATDEPA AND "
            stConsultaSQL += "MUNIDEPA = RAATDEPA AND "
            stConsultaSQL += "MUNICODI = RAATMUNI AND "
            stConsultaSQL += "CLSECODI = RAATCLSE AND "
            stConsultaSQL += "RAATESTA = ESTACODI AND "

            stConsultaSQL += "RAATIDRE = '" & CInt(inRAATIDRE) & "'"

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "RAATDEPA, RAATMUNI, RAATCLSE, RAATATIN "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception

            MessageBox.Show(Err.Description & " " & "fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_RANGARTE")
            Return Nothing

        End Try

    End Function

    ''' <summary>
    ''' Función que busca el CÓDIGO para que no se 
    ''' guarden registros duplicados.
    ''' </summary>
    Public Function fun_Buscar_CODIGO_DEPA_MUNI_CLSE_X_RANGARTE(ByVal stRAATDEPA As String, _
                                                                ByVal stRAATMUNI As String, _
                                                                ByVal inRAATCLSE As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "RANGARTE "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "RAATDEPA = '" & CStr(Trim(stRAATDEPA)) & "' and "
            stConsultaSQL += "RAATMUNI = '" & CStr(Trim(stRAATMUNI)) & "' and "
            stConsultaSQL += "RAATCLSE = '" & CInt(inRAATCLSE) & "' "
         
            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Buscar_CODIGO_RANGARTE")
            Return Nothing
        End Try

    End Function

End Class
