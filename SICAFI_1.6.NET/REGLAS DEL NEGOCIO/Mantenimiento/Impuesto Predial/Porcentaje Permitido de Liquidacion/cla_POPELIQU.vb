Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration
Imports DATOS

Public Class cla_POPELIQU

    '=================================================
    '*** CLASE PORCENTAJE PERMITIDO DE LIQUIDACION ***
    '=================================================

    ''' <summary>
    ''' procedimiento que verifica la llave primaria.
    ''' </summary>
    Public Function fun_Verifica_llave_Primaria_POPELIQU(ByVal obPPLIDEPA As Object, _
                                                         ByVal obPPLIMUNI As Object, _
                                                         ByVal obPPLICLSE As Object) As Boolean

        Try
            Dim boRespuesta As Boolean = False

            Dim obVerifica As New cla_Verificar_Dato

            If obVerifica.fun_Verificar_Campo_Lleno(obPPLIDEPA.SelectedValue) = True And _
               obVerifica.fun_Verificar_Campo_Lleno(obPPLIMUNI.SelectedValue) = True And _
               obVerifica.fun_Verificar_Campo_Lleno(obPPLICLSE.SelectedValue) = True Then

                If obVerifica.fun_Verificar_Dato_Numerico(obPPLIDEPA.SelectedValue) = True And _
                   obVerifica.fun_Verificar_Dato_Numerico(obPPLIMUNI.SelectedValue) = True And _
                   obVerifica.fun_Verificar_Dato_Numerico(obPPLICLSE.SelectedValue) = True Then

                    Dim objdatos1 As New cla_POPELIQU
                    Dim tbl As New DataTable

                    tbl = objdatos1.fun_Buscar_CODIGO_DEPA_MUNI_CLSE_NUFI_X_POPELIQU(obPPLIDEPA.SelectedValue, _
                                                                                     obPPLIMUNI.SelectedValue, _
                                                                                     obPPLICLSE.SelectedValue)

                    If tbl.Rows.Count > 0 Then
                        MessageBox.Show("El dato " & Trim(obPPLIDEPA.Text) & " - " & _
                                                     Trim(obPPLIMUNI.Text) & " - " & _
                                                     Trim(obPPLICLSE.Text) & " - " & " existe en la base de datos.", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
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
    Public Function fun_Insertar_POPELIQU(ByVal stPPLIDEPA As String, _
                                          ByVal stPPLIMUNI As String, _
                                          ByVal inPPLICLSE As Integer, _
                                          ByVal inPPLIVIAP As Integer, _
                                          ByVal inPPLITIIM As Integer, _
                                          ByVal inPPLICONC As Integer, _
                                          ByVal inPPLIVIIN As Integer, _
                                          ByVal inPPLIVIFI As Integer, _
                                          ByVal stPPLIPOAP As String, _
                                          ByVal stPPLIRESO As String, _
                                          ByVal stPPLIFECH As String, _
                                          ByVal stPPLIOBSE As String, _
                                          ByVal stPPLIESTA As String) As Boolean

        Try

            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "INSERT INTO "
            stConsultaSQL += "POPELIQU "

            stConsultaSQL += "( "
            stConsultaSQL += "PPLIDEPA, "
            stConsultaSQL += "PPLIMUNI, "
            stConsultaSQL += "PPLICLSE, "
            stConsultaSQL += "PPLIVIAP, "
            stConsultaSQL += "PPLITIIM, "
            stConsultaSQL += "PPLICONC, "
            stConsultaSQL += "PPLIVIIN, "
            stConsultaSQL += "PPLIVIFI, "
            stConsultaSQL += "PPLIPOAP, "
            stConsultaSQL += "PPLIRESO, "
            stConsultaSQL += "PPLIFECH, "
            stConsultaSQL += "PPLIOBSE, "
            stConsultaSQL += "PPLIESTA "
            stConsultaSQL += ") "

            stConsultaSQL += "VALUES "

            stConsultaSQL += "( "
            stConsultaSQL += "'" & CStr(Trim(stPPLIDEPA)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stPPLIMUNI)) & "', "
            stConsultaSQL += "'" & CInt(inPPLICLSE) & "', "
            stConsultaSQL += "'" & CInt(inPPLIVIAP) & "', "
            stConsultaSQL += "'" & CInt(inPPLITIIM) & "', "
            stConsultaSQL += "'" & CInt(inPPLICONC) & "', "
            stConsultaSQL += "'" & CInt(inPPLIVIIN) & "', "
            stConsultaSQL += "'" & CInt(inPPLIVIFI) & "', "
            stConsultaSQL += "'" & CStr(Trim(stPPLIPOAP)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stPPLIRESO)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stPPLIFECH)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stPPLIOBSE)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stPPLIESTA)) & "' "
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
            MessageBox.Show(Err.Description & " " & "fun_Insertar_POPELIQU")
        End Try

    End Function

    ''' <summary>
    ''' Función que Elimina el registro.
    ''' </summary>
    Public Function fun_Eliminar_POPELIQU(ByVal inPPLIIDRE As Integer) As Boolean

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "DELETE "
            stConsultaSQL += "POPELIQU "

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
            MessageBox.Show(Err.Description & " " & "fun_Eliminar_POPELIQU")
        End Try

    End Function

    ''' <summary>
    ''' Función que Modifica el registro.
    ''' </summary>
    Public Function fun_Actualizar_POPELIQU(ByVal inPPLIIDRE As Integer, _
                                          ByVal stPPLIDEPA As String, _
                                          ByVal stPPLIMUNI As String, _
                                          ByVal inPPLICLSE As Integer, _
                                          ByVal inPPLIVIAP As Integer, _
                                          ByVal inPPLITIIM As Integer, _
                                          ByVal inPPLICONC As Integer, _
                                          ByVal inPPLIVIIN As Integer, _
                                          ByVal inPPLIVIFI As Integer, _
                                          ByVal stPPLIPOAP As String, _
                                          ByVal stPPLIRESO As String, _
                                          ByVal stPPLIFECH As String, _
                                          ByVal stPPLIOBSE As String, _
                                          ByVal stPPLIESTA As String) As Boolean

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "UPDATE "
            stConsultaSQL += "POPELIQU "

            stConsultaSQL += "SET "
            stConsultaSQL += "PPLIDEPA = '" & CStr(Trim(stPPLIDEPA)) & "', "
            stConsultaSQL += "PPLIMUNI = '" & CStr(Trim(stPPLIMUNI)) & "', "
            stConsultaSQL += "PPLICLSE = '" & CInt(inPPLICLSE) & "', "
            stConsultaSQL += "PPLIVIAP = '" & CInt(inPPLIVIAP) & "', "
            stConsultaSQL += "PPLITIIM = '" & CInt(inPPLITIIM) & "', "
            stConsultaSQL += "PPLICONC = '" & CInt(inPPLICONC) & "', "
            stConsultaSQL += "PPLIVIIN = '" & CInt(inPPLIVIIN) & "', "
            stConsultaSQL += "PPLIVIFI = '" & CInt(inPPLIVIFI) & "', "
            stConsultaSQL += "PPLIPOAP = '" & CStr(Trim(stPPLIPOAP)) & "', "
            stConsultaSQL += "PPLIRESO = '" & CStr(Trim(stPPLIRESO)) & "', "
            stConsultaSQL += "PPLIFECH = '" & CStr(Trim(stPPLIFECH)) & "', "
            stConsultaSQL += "PPLIOBSE = '" & CStr(Trim(stPPLIOBSE)) & "', "
            stConsultaSQL += "PPLIESTA = '" & CStr(Trim(stPPLIESTA)) & "' "


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
            MessageBox.Show(Err.Description & " " & "fun_Actualizar_POPELIQU")
        End Try

    End Function

    ''' <summary>
    ''' Consulta para llenar el DataGridView y colocar el nombre del encabezado
    ''' de la columna. 
    ''' </summary>
    Public Function fun_Consultar_POPELIQU() As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "PPLIIDRE, "
            stConsultaSQL += "PPLIDEPA, "
            stConsultaSQL += "PPLIMUNI, "
            stConsultaSQL += "PPLICLSE, "
            stConsultaSQL += "PPLIVIAP, "
            stConsultaSQL += "PPLITIIM, "
            stConsultaSQL += "PPLICONC, "
            stConsultaSQL += "PPLIVIIN, "
            stConsultaSQL += "PPLIVIFI, "
            stConsultaSQL += "PPLIPOAP, "
            stConsultaSQL += "PPLIRESO, "
            stConsultaSQL += "PPLIFECH, "
            stConsultaSQL += "PPLIOBSE, "
            stConsultaSQL += "PPLIESTA "

            stConsultaSQL += "FROM "
            stConsultaSQL += "POPELIQU "

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "PPLIDEPA, PPLIMUNI, PPLICLSE, PPLITIIM, PPLICONC "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Consultar_POPELIQU")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Llena el ComboBox con datos activos e inactivos formulario principal 
    ''' esta funcion se llama desde el procedimiento "pro_inicializarControles()".
    ''' </summary>
    Public Function fun_Consultar_CAMPOS_POPELIQU() As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "POPELIQU "

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "PPLIDEPA, PPLIMUNI, PPLICLSE, PPLITIIM, PPLICONC "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Consultar_CAMPOS_POPELIQU")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Llena el ComboBox con datos activos formulario insertar y modificar 
    ''' esta funcion se llama desde el procedimiento "pro_inicializarControles()".
    ''' </summary>
    Public Function fun_Consultar_POPELIQU_X_ESTADO() As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "POPELIQU "

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
            MessageBox.Show(Err.Description & " " & "fun_Consultar_POPELIQU_X_ESTADO")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que busca el ID del registro a modificar o eliminar.
    ''' </summary>
    Public Function fun_Buscar_ID_POPELIQU(ByVal inPPLIIDRE As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "POPELIQU "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "PPLIIDRE = '" & CInt(inPPLIIDRE) & "'"

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Buscar_ID_POPELIQU")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que busca el CÓDIGO para que no se 
    ''' guarden registros duplicados.
    ''' </summary>
    Public Function fun_Buscar_CODIGO_DEPA_MUNI_CLSE_NUFI_X_POPELIQU(ByVal stPPLIDEPA As String, _
                                                                     ByVal stPPLIMUNI As String, _
                                                                     ByVal inPPLICLSE As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "POPELIQU "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "PPLIDEPA = '" & CStr(Trim(stPPLIDEPA)) & "' and "
            stConsultaSQL += "PPLIMUNI = '" & CStr(Trim(stPPLIMUNI)) & "' and "
            stConsultaSQL += "PPLICLSE = '" & CInt(inPPLICLSE) & "'  "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Buscar_CODIGO_POPELIQU")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que busca el ID del codigo buscado para ejecutar la consulta
    ''' parametrizada.
    ''' </summary>
    Public Function fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_POPELIQU(ByVal inPPLIIDRE As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "PPLIIDRE, "
            stConsultaSQL += "PPLIDEPA, "
            stConsultaSQL += "PPLIMUNI, "
            stConsultaSQL += "PPLICLSE, "
            stConsultaSQL += "PPLIVIAP, "
            stConsultaSQL += "PPLITIIM, "
            stConsultaSQL += "PPLICONC, "
            stConsultaSQL += "PPLIVIIN, "
            stConsultaSQL += "PPLIVIFI, "
            stConsultaSQL += "PPLIPOAP, "
            stConsultaSQL += "PPLIRESO, "
            stConsultaSQL += "PPLIFECH, "
            stConsultaSQL += "PPLIOBSE, "
            stConsultaSQL += "PPLIESTA "
            stConsultaSQL += "FROM "
            stConsultaSQL += "POPELIQU "

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

            MessageBox.Show(Err.Description & " " & "fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_POPELIQU")
            Return Nothing

        End Try

    End Function

End Class
