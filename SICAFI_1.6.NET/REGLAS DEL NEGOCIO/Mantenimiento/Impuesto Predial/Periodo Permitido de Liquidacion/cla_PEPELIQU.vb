Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration
Imports DATOS

Public Class cla_PEPELIQU

    '==============================================
    '*** CLASE PERIODO PERMITIDO DE LIQUIDACIÓN ***
    '==============================================

    ''' <summary>
    ''' procedimiento que verifica la llave primaria.
    ''' </summary>
    Public Function fun_Verifica_llave_Primaria_PEPELIQU(ByVal obPPLIDEPA As Object, _
                                                         ByVal obPPLIMUNI As Object, _
                                                         ByVal obPPLICLSE As Object, _
                                                         ByVal obPPLIVIGE As Object, _
                                                         ByVal obPPLITIIM As Object, _
                                                         ByVal obPPLICONC As Object) As Boolean

        Try
            Dim boRespuesta As Boolean = False

            Dim obVerifica As New cla_Verificar_Dato

            If obVerifica.fun_Verificar_Campo_Lleno(obPPLIDEPA.SelectedValue) = True And _
               obVerifica.fun_Verificar_Campo_Lleno(obPPLIMUNI.SelectedValue) = True And _
               obVerifica.fun_Verificar_Campo_Lleno(obPPLICLSE.SelectedValue) = True And _
               obVerifica.fun_Verificar_Campo_Lleno(obPPLIVIGE.SelectedValue) = True And _
               obVerifica.fun_Verificar_Campo_Lleno(obPPLITIIM.SelectedValue) = True And _
               obVerifica.fun_Verificar_Campo_Lleno(obPPLICONC.SelectedValue) = True Then

                If obVerifica.fun_Verificar_Dato_Numerico(obPPLIDEPA.SelectedValue) = True And _
                   obVerifica.fun_Verificar_Dato_Numerico(obPPLIMUNI.SelectedValue) = True And _
                   obVerifica.fun_Verificar_Dato_Numerico(obPPLICLSE.SelectedValue) = True And _
                   obVerifica.fun_Verificar_Dato_Numerico(obPPLIVIGE.SelectedValue) = True And _
                   obVerifica.fun_Verificar_Dato_Numerico(obPPLITIIM.SelectedValue) = True And _
                   obVerifica.fun_Verificar_Dato_Numerico(obPPLICONC.SelectedValue) = True Then

                    Dim objdatos1 As New cla_PEPELIQU
                    Dim tbl As New DataTable

                    tbl = objdatos1.fun_Buscar_CODIGO_DEPA_MUNI_CLSE_VIGE_TIIM_CONC_X_PEPELIQU(obPPLIDEPA.SelectedValue, _
                                                                                          obPPLIMUNI.SelectedValue, _
                                                                                          obPPLICLSE.SelectedValue, _
                                                                                          obPPLIVIGE.SelectedValue, _
                                                                                          obPPLITIIM.SelectedValue, _
                                                                                          obPPLICONC.SelectedValue)

                    If tbl.Rows.Count > 0 Then
                        MessageBox.Show("El dato " & Trim(obPPLIDEPA.Text) & " - " & _
                                                     Trim(obPPLIMUNI.Text) & " - " & _
                                                     Trim(obPPLICLSE.Text) & " - " & _
                                                     Trim(obPPLIVIGE.Text) & " - " & _
                                                     Trim(obPPLITIIM.Text) & " - " & _
                                                     Trim(obPPLICONC.Text) & " - " & " existe en la base de datos.", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                        obPPLIDEPA.Focus()
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
    Public Function fun_Insertar_PEPELIQU(ByVal stPPLIDEPA As String, _
                                          ByVal stPPLIMUNI As String, _
                                          ByVal inPPLICLSE As Integer, _
                                          ByVal inPPLIVIGE As Integer, _
                                          ByVal inPPLITIIM As Integer, _
                                          ByVal inPPLICONC As Integer, _
                                          ByVal stPPLIDESC As String, _
                                          ByVal boPPLIHIAV As Boolean, _
                                          ByVal boPPLIHILI As Boolean, _
                                          ByVal boPPLIAFSI As Boolean, _
                                          ByVal stPPLIESTA As String) As Boolean

        Try

            ' variables del sistema
            Dim stPPLIMAQU As String = fun_Nombre_de_maquina()
            Dim stPPLIUSIN As String = vp_usuario
            Dim stPPLIUSMO As String = ""

            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "INSERT INTO "
            stConsultaSQL += "PEPELIQU "

            stConsultaSQL += "( "
            stConsultaSQL += "PPLIDEPA, "
            stConsultaSQL += "PPLIMUNI, "
            stConsultaSQL += "PPLICLSE, "
            stConsultaSQL += "PPLIVIGE, "
            stConsultaSQL += "PPLITIIM, "
            stConsultaSQL += "PPLICONC, "
            stConsultaSQL += "PPLIDESC, "
            stConsultaSQL += "PPLIHIAV, "
            stConsultaSQL += "PPLIHILI, "
            stConsultaSQL += "PPLIAFSI, "
            stConsultaSQL += "PPLIESTA, "
            stConsultaSQL += "PPLIUSIN, "
            stConsultaSQL += "PPLIUSMO, "
            stConsultaSQL += "PPLIMAQU "
            stConsultaSQL += ") "

            stConsultaSQL += "VALUES "

            stConsultaSQL += "( "
            stConsultaSQL += "'" & CStr(Trim(stPPLIDEPA)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stPPLIMUNI)) & "', "
            stConsultaSQL += "'" & CInt(inPPLICLSE) & "', "
            stConsultaSQL += "'" & CInt(inPPLIVIGE) & "', "
            stConsultaSQL += "'" & CInt(inPPLITIIM) & "', "
            stConsultaSQL += "'" & CInt(inPPLICONC) & "', "
            stConsultaSQL += "'" & CStr(Trim(stPPLIDESC)) & "', "
            stConsultaSQL += "'" & CBool(boPPLIHIAV) & "', "
            stConsultaSQL += "'" & CBool(boPPLIHILI) & "', "
            stConsultaSQL += "'" & CBool(boPPLIAFSI) & "', "
            stConsultaSQL += "'" & CStr(Trim(stPPLIESTA)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stPPLIUSIN)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stPPLIUSMO)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stPPLIMAQU)) & "' "
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
            MessageBox.Show(Err.Description & " " & "fun_Insertar_PEPELIQU")
        End Try

    End Function

    ''' <summary>
    ''' Función que Elimina el registro.
    ''' </summary>
    Public Function fun_Eliminar_PEPELIQU(ByVal inPPLIIDRE As Integer) As Boolean

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "DELETE "
            stConsultaSQL += "PEPELIQU "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "PPLIIDRE = '" & CInt(inPPLIIDRE) & "' "

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
            MessageBox.Show(Err.Description & " " & "fun_Eliminar_PEPELIQU")
        End Try

    End Function

    ''' <summary>
    ''' Función que Modifica el registro.
    ''' </summary>
    Public Function fun_Actualizar_PEPELIQU(ByVal inPPLIIDRE As Integer, _
                                          ByVal stPPLIDEPA As String, _
                                          ByVal stPPLIMUNI As String, _
                                          ByVal inPPLICLSE As Integer, _
                                          ByVal inPPLIVIGE As Integer, _
                                          ByVal inPPLITIIM As Integer, _
                                          ByVal inPPLICONC As Integer, _
                                          ByVal stPPLIDESC As String, _
                                          ByVal boPPLIHIAV As Boolean, _
                                          ByVal boPPLIHILI As Boolean, _
                                          ByVal boPPLIAFSI As Boolean, _
                                          ByVal stPPLIESTA As String) As Boolean

        Try
            ' variables del sistema
            Dim stPPLIMAQU As String = fun_Nombre_de_maquina()
            Dim stPPLIUSIN As String = vp_usuario
            Dim stPPLIUSMO As String = vp_usuario

            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "UPDATE "
            stConsultaSQL += "PEPELIQU "

            stConsultaSQL += "SET "
            stConsultaSQL += "PPLIDEPA = '" & CStr(Trim(stPPLIDEPA)) & "', "
            stConsultaSQL += "PPLIMUNI = '" & CStr(Trim(stPPLIMUNI)) & "', "
            stConsultaSQL += "PPLICLSE = '" & CInt(inPPLICLSE) & "', "
            stConsultaSQL += "PPLIVIGE = '" & CInt(inPPLIVIGE) & "', "
            stConsultaSQL += "PPLITIIM = '" & CInt(inPPLITIIM) & "', "
            stConsultaSQL += "PPLICONC = '" & CInt(inPPLICONC) & "', "
            stConsultaSQL += "PPLIDESC = '" & CStr(Trim(stPPLIDESC)) & "', "
            stConsultaSQL += "PPLIHIAV = '" & CBool(boPPLIHIAV) & "', "
            stConsultaSQL += "PPLIHILI = '" & CBool(boPPLIHILI) & "', "
            stConsultaSQL += "PPLIAFSI = '" & CBool(boPPLIAFSI) & "', "
            stConsultaSQL += "PPLIESTA = '" & CStr(Trim(stPPLIESTA)) & "', "
            stConsultaSQL += "PPLIUSIN = '" & CStr(Trim(stPPLIUSIN)) & "', "
            stConsultaSQL += "PPLIUSMO = '" & CStr(Trim(stPPLIUSMO)) & "', "
            stConsultaSQL += "PPLIMAQU = '" & CStr(Trim(stPPLIMAQU)) & "' "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "PPLIIDRE = '" & CInt(inPPLIIDRE) & "'"

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
            MessageBox.Show(Err.Description & " " & "fun_Actualizar_PEPELIQU")
        End Try

    End Function

    ''' <summary>
    ''' Consulta para llenar el DataGridView y colocar el nombre del encabezado
    ''' de la columna. 
    ''' </summary>
    Public Function fun_Consultar_PEPELIQU() As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "PPLIIDRE, "
            stConsultaSQL += "PPLIDEPA, "
            stConsultaSQL += "PPLIMUNI, "
            stConsultaSQL += "PPLICLSE, "
            stConsultaSQL += "PPLIVIGE, "
            stConsultaSQL += "PPLITIIM, "
            stConsultaSQL += "PPLICONC, "
            stConsultaSQL += "PPLIDESC, "
            stConsultaSQL += "PPLIHIAV, "
            stConsultaSQL += "PPLIHILI, "
            stConsultaSQL += "PPLIAFSI, "
            stConsultaSQL += "PPLIESTA "

            stConsultaSQL += "FROM "
            stConsultaSQL += "PEPELIQU "

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "PPLIDEPA, PPLIMUNI, PPLICLSE, PPLITIIM, PPLICONC "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Consultar_PEPELIQU")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Llena el ComboBox con datos activos e inactivos formulario principal 
    ''' esta funcion se llama desde el procedimiento "pro_inicializarControles()".
    ''' </summary>
    Public Function fun_Consultar_CAMPOS_PEPELIQU() As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "PEPELIQU "

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "PPLIDEPA, PPLIMUNI, PPLICLSE, PPLITIIM, PPLICONC "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Consultar_CAMPOS_PEPELIQU")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Llena el ComboBox con datos activos formulario insertar y modificar 
    ''' esta funcion se llama desde el procedimiento "pro_inicializarControles()".
    ''' </summary>
    Public Function fun_Consultar_PEPELIQU_X_ESTADO() As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "PEPELIQU "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "PPLIESTA = 'ac' "

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "PPLIDEPA, PPLIMUNI, PPLICLSE, PPLITIIM, PPLICONC "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Consultar_PEPELIQU_X_ESTADO")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que busca el ID del registro a modificar o eliminar.
    ''' </summary>
    Public Function fun_Buscar_ID_PEPELIQU(ByVal inPPLIIDRE As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "PEPELIQU "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "PPLIIDRE = '" & CInt(inPPLIIDRE) & "'"

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Buscar_ID_PEPELIQU")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que busca el CÓDIGO para que no se 
    ''' guarden registros duplicados.
    ''' </summary>
    Public Function fun_Buscar_CODIGO_DEPA_MUNI_CLSE_VIGE_TIIM_CONC_X_PEPELIQU(ByVal stPPLIDEPA As String, _
                                                                          ByVal stPPLIMUNI As String, _
                                                                          ByVal inPPLICLSE As Integer, _
                                                                          ByVal inPPLIVIGE As Integer, _
                                                                          ByVal inPPLITIIM As Integer, _
                                                                          ByVal inPPLICONC As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "PEPELIQU "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "PPLIDEPA = '" & CStr(Trim(stPPLIDEPA)) & "' and "
            stConsultaSQL += "PPLIMUNI = '" & CStr(Trim(stPPLIMUNI)) & "' and "
            stConsultaSQL += "PPLICLSE = '" & CInt(inPPLICLSE) & "' and "
            stConsultaSQL += "PPLIVIGE = '" & CInt(inPPLIVIGE) & "' and "
            stConsultaSQL += "PPLITIIM = '" & CInt(inPPLITIIM) & "' and "
            stConsultaSQL += "PPLICONC = '" & CInt(inPPLICONC) & "' "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Buscar_CODIGO_PEPELIQU")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que busca el ID del codigo buscado para ejecutar la consulta
    ''' parametrizada.
    ''' </summary>
    Public Function fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_PEPELIQU(ByVal inPPLIIDRE As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "PPLIIDRE, "
            stConsultaSQL += "PPLIDEPA, "
            stConsultaSQL += "PPLIMUNI, "
            stConsultaSQL += "PPLICLSE, "
            stConsultaSQL += "PPLIVIGE, "
            stConsultaSQL += "PPLITIIM, "
            stConsultaSQL += "PPLICONC, "
            stConsultaSQL += "PPLIDESC, "
            stConsultaSQL += "PPLIHIAV, "
            stConsultaSQL += "PPLIHILI, "
            stConsultaSQL += "PPLIAFSI, "
            stConsultaSQL += "PPLIESTA "

            stConsultaSQL += "FROM "
            stConsultaSQL += "PEPELIQU "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "PPLIIDRE = '" & CInt(inPPLIIDRE) & "'"

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "PPLIDEPA, PPLIMUNI, PPLICLSE, PPLITIIM, PPLICONC "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception

            MessageBox.Show(Err.Description & " " & "fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_PEPELIQU")
            Return Nothing

        End Try

    End Function

    ''' <summary>
    ''' Función que busca el CÓDIGO para que no se 
    ''' guarden registros duplicados.
    ''' </summary>
    Public Function fun_Buscar_CODIGO_DEPA_MUNI_CLSE_VIGE_X_PEPELIQU(ByVal stPPLIDEPA As String, _
                                                                     ByVal stPPLIMUNI As String, _
                                                                     ByVal inPPLICLSE As Integer, _
                                                                     ByVal inPPLIVIGE As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "PEPELIQU "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "PPLIDEPA = '" & CStr(Trim(stPPLIDEPA)) & "' and "
            stConsultaSQL += "PPLIMUNI = '" & CStr(Trim(stPPLIMUNI)) & "' and "
            stConsultaSQL += "PPLICLSE = '" & CInt(inPPLICLSE) & "' and "
            stConsultaSQL += "PPLIVIGE = '" & CInt(inPPLIVIGE) & "' "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Buscar_CODIGO_PEPELIQU")
            Return Nothing
        End Try

    End Function

End Class
