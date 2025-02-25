Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration
Imports DATOS

Public Class cla_TARIZOEC

    '===================================
    '*** CLASE TARIFA ZONA ECONÓMICA ***
    '===================================

    ''' <summary>
    ''' procedimiento que verifica la llave primaria.
    ''' </summary>
    Public Function fun_Verifica_llave_Primaria_TARIZOEC(ByVal obTAZEDEPA As Object, _
                                                         ByVal obTAZEMUNI As Object, _
                                                         ByVal obTAZECLSE As Object, _
                                                         ByVal obTAZEVIGE As Object, _
                                                         ByVal obTAZEZOEC As Object) As Boolean

        Try
            Dim boRespuesta As Boolean = False

            Dim obVerifica As New cla_Verificar_Dato

            If obVerifica.fun_Verificar_Campo_Lleno(obTAZEDEPA.SelectedValue) = True And _
               obVerifica.fun_Verificar_Campo_Lleno(obTAZEMUNI.SelectedValue) = True And _
               obVerifica.fun_Verificar_Campo_Lleno(obTAZECLSE.SelectedValue) = True And _
               obVerifica.fun_Verificar_Campo_Lleno(obTAZEVIGE.SelectedValue) = True And _
               obVerifica.fun_Verificar_Campo_Lleno(obTAZEZOEC.SelectedValue) = True Then

                If obVerifica.fun_Verificar_Dato_Numerico(obTAZEDEPA.SelectedValue) = True And _
                   obVerifica.fun_Verificar_Dato_Numerico(obTAZEMUNI.SelectedValue) = True And _
                   obVerifica.fun_Verificar_Dato_Numerico(obTAZECLSE.SelectedValue) = True And _
                   obVerifica.fun_Verificar_Dato_Numerico(obTAZEVIGE.SelectedValue) = True And _
                   obVerifica.fun_Verificar_Dato_Numerico(obTAZEZOEC.SelectedValue) = True Then

                    Dim objdatos1 As New cla_TARIZOEC
                    Dim tbl As New DataTable

                    tbl = objdatos1.fun_Buscar_CODIGO_DEPA_MUNI_CLSE_VIGE_ZOEC_X_TARIZOEC(obTAZEDEPA.SelectedValue, _
                                                                                          obTAZEMUNI.SelectedValue, _
                                                                                          obTAZECLSE.SelectedValue, _
                                                                                          obTAZEVIGE.SelectedValue, _
                                                                                          obTAZEZOEC.SelectedValue)

                    If tbl.Rows.Count > 0 Then
                        MessageBox.Show("El dato " & Trim(obTAZEDEPA.Text) & " - " & _
                                                     Trim(obTAZEMUNI.Text) & " - " & _
                                                     Trim(obTAZECLSE.Text) & " - " & _
                                                     Trim(obTAZEVIGE.Text) & " - " & _
                                                     Trim(obTAZEZOEC.Text) & " - " & " existe en la base de datos.", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                        obTAZEDEPA.Focus()
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
    Public Function fun_Insertar_TARIZOEC(ByVal stTAZEDEPA As String, _
                                          ByVal stTAZEMUNI As String, _
                                          ByVal inTAZECLSE As Integer, _
                                          ByVal inTAZEZOEC As Integer, _
                                          ByVal stTAZETA01 As String, _
                                          ByVal stTAZETA02 As String, _
                                          ByVal stTAZETA03 As String, _
                                          ByVal stTAZETA04 As String, _
                                          ByVal stTAZETA05 As String, _
                                          ByVal stTAZETA06 As String, _
                                          ByVal inTAZEZOAP As Integer, _
                                          ByVal stTAZEESTA As String, _
                                          ByVal inTAZEVIGE As Integer, _
                                          ByVal stTAZESIGN As String, _
                                          ByVal stTAZEPORC As String, _
                                          ByVal stTAZETALO As String) As Boolean

        Try

            ' variables del sistema
            Dim stTAZEMAQU As String = fun_Nombre_de_maquina()
            Dim stTAZEUSIN As String = vp_usuario
            Dim stTAZEUSMO As String = ""

            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "INSERT INTO "
            stConsultaSQL += "TARIZOEC "

            stConsultaSQL += "( "
            stConsultaSQL += "TAZEDEPA, "
            stConsultaSQL += "TAZEMUNI, "
            stConsultaSQL += "TAZECLSE, "
            stConsultaSQL += "TAZEZOEC, "
            stConsultaSQL += "TAZETA01, "
            stConsultaSQL += "TAZETA02, "
            stConsultaSQL += "TAZETA03, "
            stConsultaSQL += "TAZETA04, "
            stConsultaSQL += "TAZETA05, "
            stConsultaSQL += "TAZETA06, "
            stConsultaSQL += "TAZEZOAP, "
            stConsultaSQL += "TAZEESTA, "
            stConsultaSQL += "TAZEVIGE, "
            stConsultaSQL += "TAZEUSIN, "
            stConsultaSQL += "TAZEUSMO, "
            stConsultaSQL += "TAZEMAQU, "
            stConsultaSQL += "TAZESIGN, "
            stConsultaSQL += "TAZEPORC, "
            stConsultaSQL += "TAZETALO  "
            stConsultaSQL += ") "

            stConsultaSQL += "VALUES "

            stConsultaSQL += "( "
            stConsultaSQL += "'" & CStr(Trim(stTAZEDEPA)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stTAZEMUNI)) & "', "
            stConsultaSQL += "'" & CInt(inTAZECLSE) & "', "
            stConsultaSQL += "'" & CInt(inTAZEZOEC) & "', "
            stConsultaSQL += "'" & CStr(Trim(stTAZETA01)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stTAZETA02)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stTAZETA03)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stTAZETA04)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stTAZETA05)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stTAZETA06)) & "', "
            stConsultaSQL += "'" & CInt(inTAZEZOAP) & "', "
            stConsultaSQL += "'" & CStr(Trim(stTAZEESTA)) & "', "
            stConsultaSQL += "'" & CInt(inTAZEVIGE) & "', "
            stConsultaSQL += "'" & CStr(Trim(stTAZEUSIN)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stTAZEUSMO)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stTAZEMAQU)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stTAZESIGN)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stTAZEPORC)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stTAZETALO)) & "' "
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
            MessageBox.Show(Err.Description & " " & "fun_Insertar_TARIZOEC")
        End Try

    End Function

    ''' <summary>
    ''' Función que Elimina el registro.
    ''' </summary>
    Public Function fun_Eliminar_TARIZOEC(ByVal inTAZEIDRE As Integer) As Boolean

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "DELETE "
            stConsultaSQL += "TARIZOEC "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "TAZEIDRE = '" & CInt(inTAZEIDRE) & "' "

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
            MessageBox.Show(Err.Description & " " & "fun_Eliminar_TARIZOEC")
        End Try

    End Function

    ''' <summary>
    ''' Función que Modifica el registro.
    ''' </summary>
    Public Function fun_Actualizar_TARIZOEC(ByVal inTAZEIDRE As Integer, _
                                          ByVal stTAZEDEPA As String, _
                                          ByVal stTAZEMUNI As String, _
                                          ByVal inTAZECLSE As Integer, _
                                          ByVal inTAZEZOEC As Integer, _
                                          ByVal stTAZETA01 As String, _
                                          ByVal stTAZETA02 As String, _
                                          ByVal stTAZETA03 As String, _
                                          ByVal stTAZETA04 As String, _
                                          ByVal stTAZETA05 As String, _
                                          ByVal stTAZETA06 As String, _
                                          ByVal inTAZEZOAP As Integer, _
                                          ByVal stTAZEESTA As String, _
                                          ByVal inTAZEVIGE As Integer, _
                                          ByVal stTAZESIGN As String, _
                                          ByVal stTAZEPORC As String, _
                                          ByVal stTAZETALO As String) As Boolean

        Try
            ' variables del sistema
            Dim stTAZEMAQU As String = fun_Nombre_de_maquina()
            Dim stTAZEUSIN As String = vp_usuario
            Dim stTAZEUSMO As String = vp_usuario

            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "UPDATE "
            stConsultaSQL += "TARIZOEC "

            stConsultaSQL += "SET "
            stConsultaSQL += "TAZEDEPA = '" & CStr(Trim(stTAZEDEPA)) & "', "
            stConsultaSQL += "TAZEMUNI = '" & CStr(Trim(stTAZEMUNI)) & "', "
            stConsultaSQL += "TAZECLSE = '" & CInt(inTAZECLSE) & "', "
            stConsultaSQL += "TAZEZOEC = '" & CInt(inTAZEZOEC) & "', "
            stConsultaSQL += "TAZETA01 = '" & CStr(Trim(stTAZETA01)) & "', "
            stConsultaSQL += "TAZETA02 = '" & CStr(Trim(stTAZETA02)) & "', "
            stConsultaSQL += "TAZETA03 = '" & CStr(Trim(stTAZETA03)) & "', "
            stConsultaSQL += "TAZETA04 = '" & CStr(Trim(stTAZETA04)) & "', "
            stConsultaSQL += "TAZETA05 = '" & CStr(Trim(stTAZETA05)) & "', "
            stConsultaSQL += "TAZETA06 = '" & CStr(Trim(stTAZETA06)) & "', "
            stConsultaSQL += "TAZEZOAP = '" & CInt(inTAZEZOAP) & "', "
            stConsultaSQL += "TAZEESTA = '" & CStr(Trim(stTAZEESTA)) & "', "
            stConsultaSQL += "TAZEVIGE = '" & CInt(inTAZEVIGE) & "', "
            stConsultaSQL += "TAZEUSIN = '" & CStr(Trim(stTAZEUSIN)) & "', "
            stConsultaSQL += "TAZEUSMO = '" & CStr(Trim(stTAZEUSMO)) & "', "
            stConsultaSQL += "TAZEMAQU = '" & CStr(Trim(stTAZEMAQU)) & "', "
            stConsultaSQL += "TAZESIGN = '" & CStr(Trim(stTAZESIGN)) & "', "
            stConsultaSQL += "TAZEPORC = '" & CStr(Trim(stTAZEPORC)) & "', "
            stConsultaSQL += "TAZETALO = '" & CStr(Trim(stTAZETALO)) & "' "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "TAZEIDRE = '" & CInt(inTAZEIDRE) & "'"

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
            MessageBox.Show(Err.Description & " " & "fun_Actualizar_TARIZOEC")
        End Try

    End Function

    ''' <summary>
    ''' Consulta para llenar el DataGridView y colocar el nombre del encabezado
    ''' de la columna. 
    ''' </summary>
    Public Function fun_Consultar_TARIZOEC() As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "TAZEIDRE, "
            stConsultaSQL += "TAZEDEPA, "
            stConsultaSQL += "TAZEMUNI, "
            stConsultaSQL += "TAZECLSE, "
            stConsultaSQL += "TAZEVIGE, "
            stConsultaSQL += "TAZEZOEC, "
            stConsultaSQL += "TAZETA01, "
            stConsultaSQL += "TAZETA02, "
            stConsultaSQL += "TAZETA03, "
            stConsultaSQL += "TAZETA04, "
            stConsultaSQL += "TAZETA05, "
            stConsultaSQL += "TAZETA06, "
            stConsultaSQL += "TAZEZOAP, "
            stConsultaSQL += "TAZEESTA, "
            stConsultaSQL += "TAZESIGN, "
            stConsultaSQL += "TAZEPORC, "
            stConsultaSQL += "TAZETALO  "

            stConsultaSQL += "FROM "
            stConsultaSQL += "TARIZOEC "

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "TAZEDEPA, TAZEMUNI, TAZEVIGE, TAZECLSE, TAZEZOEC  "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Consultar_TARIZOEC")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Llena el ComboBox con datos activos e inactivos formulario principal 
    ''' esta funcion se llama desde el procedimiento "pro_inicializarControles()".
    ''' </summary>
    Public Function fun_Consultar_CAMPOS_TARIZOEC() As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "TARIZOEC "

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "TAZEDEPA, TAZEMUNI, TAZEVIGE, TAZECLSE "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Consultar_CAMPOS_TARIZOEC")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Llena el ComboBox con datos activos formulario insertar y modificar 
    ''' esta funcion se llama desde el procedimiento "pro_inicializarControles()".
    ''' </summary>
    Public Function fun_Consultar_TARIZOEC_X_ESTADO() As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "TARIZOEC "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "TAZEESTA = 'ac' "

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "TAZEDEPA, TAZEMUNI, TAZEVIGE, TAZECLSE "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Consultar_TARIZOEC_X_ESTADO")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que busca el ID del registro a modificar o eliminar.
    ''' </summary>
    Public Function fun_Buscar_ID_TARIZOEC(ByVal inTAZEIDRE As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "TARIZOEC "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "TAZEIDRE = '" & CInt(inTAZEIDRE) & "'"

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Buscar_ID_TARIZOEC")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que busca el CÓDIGO para que no se 
    ''' guarden registros duplicados.
    ''' </summary>
    Public Function fun_Buscar_CODIGO_DEPA_MUNI_CLSE_VIGE_ZOEC_X_TARIZOEC(ByVal stTAZEDEPA As String, _
                                                                          ByVal stTAZEMUNI As String, _
                                                                          ByVal inTAZECLSE As Integer, _
                                                                          ByVal inTAZEVIGE As Integer, _
                                                                          ByVal inTAZEZOEC As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "TARIZOEC "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "TAZEDEPA = '" & CStr(Trim(stTAZEDEPA)) & "' and "
            stConsultaSQL += "TAZEMUNI = '" & CStr(Trim(stTAZEMUNI)) & "' and "
            stConsultaSQL += "TAZECLSE = '" & CInt(inTAZECLSE) & "' and "
            stConsultaSQL += "TAZEVIGE = '" & CInt(inTAZEVIGE) & "' and "
            stConsultaSQL += "TAZEZOEC = '" & CInt(inTAZEZOEC) & "' "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Buscar_CODIGO_TARIZOEC")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que busca el ID del codigo buscado para ejecutar la consulta
    ''' parametrizada.
    ''' </summary>
    Public Function fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_TARIZOEC(ByVal inTAZEIDRE As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "TAZEIDRE, "
            stConsultaSQL += "TAZEDEPA, "
            stConsultaSQL += "TAZEMUNI, "
            stConsultaSQL += "TAZECLSE, "
            stConsultaSQL += "TAZEVIGE, "
            stConsultaSQL += "TAZEZOEC, "
            stConsultaSQL += "TAZETA01, "
            stConsultaSQL += "TAZETA02, "
            stConsultaSQL += "TAZETA03, "
            stConsultaSQL += "TAZETA04, "
            stConsultaSQL += "TAZETA05, "
            stConsultaSQL += "TAZETA06, "
            stConsultaSQL += "TAZEZOAP, "
            stConsultaSQL += "TAZEESTA, "
            stConsultaSQL += "TAZESIGN, "
            stConsultaSQL += "TAZEPORC, "
            stConsultaSQL += "TAZETALO  "

            stConsultaSQL += "FROM "
            stConsultaSQL += "TARIZOEC "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "TAZEIDRE = '" & CInt(inTAZEIDRE) & "'"

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "TAZEDEPA, TAZEMUNI,TAZEVIGE, TAZECLSE "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception

            MessageBox.Show(Err.Description & " " & "fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_TARIZOEC")
            Return Nothing

        End Try

    End Function


End Class
