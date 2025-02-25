Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration
Imports DATOS

Public Class cla_FOTOTICO

    '==========================================================
    '*** CLASE FOTOGRAFIA POR IDENTIFICADOR DE CONSTRUCCIÓN ***
    '==========================================================

    ''' <summary>
    ''' procedimiento que verifica la llave primaria.
    ''' </summary>
    Public Function fun_Verifica_llave_Primaria_MANT_FOTOTICO(ByVal obFOTCDEPA As Object, _
                                                              ByVal obFOTCMUNI As Object, _
                                                              ByVal obFOTCCLSE As Object, _
                                                              ByVal obFOTCTIPO As Object, _
                                                              ByVal obFOTCCLCO As Object, _
                                                              ByVal obFOTCTICO As Object, _
                                                              ByVal obFOTCCAFO As Object) As Boolean

        Try
            Dim boRespuesta As Boolean = False

            Dim obVerifica As New cla_Verificar_Dato

            If obVerifica.fun_Verificar_Campo_Lleno(obFOTCDEPA.SelectedValue) = True And _
               obVerifica.fun_Verificar_Campo_Lleno(obFOTCMUNI.SelectedValue) = True And _
               obVerifica.fun_Verificar_Campo_Lleno(obFOTCCLSE.SelectedValue) = True And _
               obVerifica.fun_Verificar_Campo_Lleno(obFOTCTIPO.SelectedValue) = True And _
               obVerifica.fun_Verificar_Campo_Lleno(obFOTCCLCO.SelectedValue) = True And _
               obVerifica.fun_Verificar_Campo_Lleno(obFOTCTICO.SelectedValue) = True And _
               obVerifica.fun_Verificar_Campo_Lleno(obFOTCCAFO.SelectedValue) = True Then

                If obVerifica.fun_Verificar_Dato_Numerico(obFOTCDEPA.SelectedValue) = True And _
                   obVerifica.fun_Verificar_Dato_Numerico(obFOTCMUNI.SelectedValue) = True And _
                   obVerifica.fun_Verificar_Dato_Numerico(obFOTCCLSE.SelectedValue) = True And _
                   obVerifica.fun_Verificar_Dato_Numerico(obFOTCCLCO.SelectedValue) = True And _
                   obVerifica.fun_Verificar_Dato_Numerico(obFOTCCAFO.SelectedValue) = True Then

                    Dim objdatos1 As New cla_FOTOTICO
                    Dim tbl As New DataTable

                    tbl = objdatos1.fun_Buscar_CODIGO_X_MANT_FOTOTICO(Trim(obFOTCDEPA.SelectedValue), _
                                                                      Trim(obFOTCMUNI.SelectedValue), _
                                                                          (obFOTCCLSE.SelectedValue), _
                                                                      Trim(obFOTCTIPO.SelectedValue), _
                                                                          (obFOTCCLCO.SelectedValue), _
                                                                      Trim(obFOTCTICO.SelectedValue), _
                                                                          (obFOTCCAFO.SelectedValue))

                    If tbl.Rows.Count > 0 Then
                        MessageBox.Show("El dato existe en la base de datos.", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                        obFOTCDEPA.Focus()
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
    Public Function fun_Insertar_MANT_FOTOTICO(ByVal stFOTCDEPA As String, _
                                               ByVal stFOTCMUNI As String, _
                                               ByVal inFOTCCLSE As Integer, _
                                               ByVal stFOTCTIPO As String, _
                                               ByVal inFOTCCLCO As Integer, _
                                               ByVal stFOTCTICO As String, _
                                               ByVal inFOTCCAFO As Integer, _
                                               ByVal stFOTCESTA As String) As Boolean

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "INSERT INTO "
            stConsultaSQL += "MANT_FOTOTICO "

            stConsultaSQL += "( "
            stConsultaSQL += "FOTCDEPA, "
            stConsultaSQL += "FOTCMUNI, "
            stConsultaSQL += "FOTCCLSE, "
            stConsultaSQL += "FOTCTIPO, "
            stConsultaSQL += "FOTCCLCO, "
            stConsultaSQL += "FOTCTICO, "
            stConsultaSQL += "FOTCCAFO, "
            stConsultaSQL += "FOTCESTA "
            stConsultaSQL += ") "

            stConsultaSQL += "VALUES "

            stConsultaSQL += "( "
            stConsultaSQL += "'" & CStr(Trim(stFOTCDEPA)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stFOTCMUNI)) & "', "
            stConsultaSQL += "'" & CInt(inFOTCCLSE) & "', "
            stConsultaSQL += "'" & CStr(Trim(stFOTCTIPO)) & "', "
            stConsultaSQL += "'" & CInt(inFOTCCLCO) & "', "
            stConsultaSQL += "'" & CStr(Trim(stFOTCTICO)) & "', "
            stConsultaSQL += "'" & CInt(inFOTCCAFO) & "', "
            stConsultaSQL += "'" & CStr(Trim(stFOTCESTA)) & "' "
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
            MessageBox.Show(Err.Description & " " & "fun_Insertar_MANT_FOTOTICO")
        End Try

    End Function

    ''' <summary>
    ''' Función que Elimina el registro.
    ''' </summary>
    Public Function fun_Eliminar_MANT_FOTOTICO(ByVal inFOTCIDRE As Integer) As Boolean

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "DELETE "
            stConsultaSQL += "MANT_FOTOTICO "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "FOTCIDRE = '" & CInt(inFOTCIDRE) & "' "

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
            MessageBox.Show(Err.Description & " " & "fun_Eliminar_MANT_FOTOTICO")
        End Try

    End Function

    ''' <summary>
    ''' Función que Modifica el registro.
    ''' </summary>
    Public Function fun_Actualizar_MANT_FOTOTICO(ByVal inFOTCIDRE As Integer, _
                                                 ByVal stFOTCDEPA As String, _
                                                 ByVal stFOTCMUNI As String, _
                                                 ByVal inFOTCCLSE As Integer, _
                                                 ByVal stFOTCTIPO As String, _
                                                 ByVal inFOTCCLCO As Integer, _
                                                 ByVal stFOTCTICO As String, _
                                                 ByVal inFOTCCAFO As Integer, _
                                                 ByVal stFOTCESTA As String) As Boolean

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "UPDATE "
            stConsultaSQL += "MANT_FOTOTICO "

            stConsultaSQL += "SET "
            stConsultaSQL += "FOTCDEPA = '" & CStr(Trim(stFOTCDEPA)) & "', "
            stConsultaSQL += "FOTCMUNI = '" & CStr(Trim(stFOTCMUNI)) & "', "
            stConsultaSQL += "FOTCCLSE = '" & CInt(inFOTCCLSE) & "', "
            stConsultaSQL += "FOTCTIPO = '" & CStr(Trim(stFOTCTIPO)) & "', "
            stConsultaSQL += "FOTCCLCO = '" & CInt(inFOTCCLCO) & "', "
            stConsultaSQL += "FOTCTICO = '" & CStr(Trim(stFOTCTICO)) & "', "
            stConsultaSQL += "FOTCCAFO = '" & CInt(inFOTCCAFO) & "', "
            stConsultaSQL += "FOTCESTA = '" & CStr(Trim(stFOTCESTA)) & "' "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "FOTCIDRE = '" & CInt(inFOTCIDRE) & "'"

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
            MessageBox.Show(Err.Description & " " & "fun_Actualizar_MANT_FOTOTICO")
        End Try

    End Function

    ''' <summary>
    ''' Consulta para llenar el DataGridView y colocar el nombre del encabezado
    ''' de la columna. 
    ''' </summary>
    Public Function fun_Consultar_MANT_FOTOTICO() As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "FOTCIDRE, "
            stConsultaSQL += "FOTCDEPA, "
            stConsultaSQL += "FOTCMUNI, "
            stConsultaSQL += "FOTCCLSE, "
            stConsultaSQL += "FOTCTIPO, "
            stConsultaSQL += "FOTCCLCO, "
            stConsultaSQL += "FOTCTICO, "
            stConsultaSQL += "FOTCCAFO, "
            stConsultaSQL += "FOTCESTA  "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MANT_FOTOTICO "

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "FOTCDEPA, FOTCMUNI, FOTCCLSE, FOTCTIPO, FOTCCLCO, FOTCTICO, FOTCCAFO "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Consultar_MANT_FOTOTICO")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Llena el ComboBox con datos activos e inactivos formulario principal 
    ''' esta funcion se llama desde el procedimiento "pro_inicializarControles()".
    ''' </summary>
    Public Function fun_Consultar_CAMPOS_MANT_FOTOTICO() As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MANT_FOTOTICO "

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "FOTCDEPA, FOTCMUNI, FOTCCLSE, FOTCTIPO, FOTCCLCO, FOTCTICO, FOTCCAFO "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Consultar_CAMPOS_MANT_FOTOTICO")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Llena el ComboBox con datos activos formulario insertar y modificar 
    ''' esta funcion se llama desde el procedimiento "pro_inicializarControles()".
    ''' </summary>
    Public Function fun_Consultar_MANT_FOTOTICO_X_ESTADO() As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MANT_FOTOTICO "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "FOTCESTA = 'ac' "

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "FOTCDEPA, FOTCMUNI, FOTCCLSE, FOTCTIPO, FOTCCLCO, FOTCTICO, FOTCCAFO "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Consultar_MANT_FOTOTICO_X_ESTADO")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que busca el ID del registro a modificar o eliminar.
    ''' </summary>
    Public Function fun_Buscar_ID_MANT_FOTOTICO(ByVal inFOTCIDRE As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MANT_FOTOTICO "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "FOTCIDRE = '" & CInt(inFOTCIDRE) & "'"

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Buscar_ID_MANT_FOTOTICO")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que busca el para que no se 
    ''' guarden registros duplicados.
    ''' </summary>
    Public Function fun_Buscar_CODIGO_X_MANT_FOTOTICO(ByVal stFOTCDEPA As String, _
                                                      ByVal stFOTCMUNI As String, _
                                                      ByVal inFOTCCLSE As Integer, _
                                                      ByVal stFOTCTIPO As String, _
                                                      ByVal inFOTCCLCO As Integer, _
                                                      ByVal stFOTCTICO As String, _
                                                      ByVal inFOTCCAFO As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MANT_FOTOTICO "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "FOTCDEPA = '" & CStr(Trim(stFOTCDEPA)) & "' and "
            stConsultaSQL += "FOTCMUNI = '" & CStr(Trim(stFOTCMUNI)) & "' and "
            stConsultaSQL += "FOTCCLSE = '" & CInt(inFOTCCLSE) & "' and "
            stConsultaSQL += "FOTCTIPO = '" & CStr(Trim(stFOTCTIPO)) & "' and "
            stConsultaSQL += "FOTCCLCO = '" & CInt(inFOTCCLCO) & "' and "
            stConsultaSQL += "FOTCTICO = '" & CStr(Trim(stFOTCTICO)) & "' and "
            stConsultaSQL += "FOTCCAFO = '" & CInt(inFOTCCAFO) & "' "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Buscar_CODIGO_MANT_FOTOTICO")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que busca el para que no se 
    ''' guarden registros duplicados.
    ''' </summary>
    Public Function fun_Buscar_CODIGO_X_MANT_FOTOTICO(ByVal stFOTCDEPA As String, _
                                                      ByVal stFOTCMUNI As String, _
                                                      ByVal inFOTCCLSE As Integer, _
                                                      ByVal inFOTCCLCO As Integer, _
                                                      ByVal stFOTCTICO As String) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MANT_FOTOTICO "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "FOTCDEPA = '" & CStr(Trim(stFOTCDEPA)) & "' and "
            stConsultaSQL += "FOTCMUNI = '" & CStr(Trim(stFOTCMUNI)) & "' and "
            stConsultaSQL += "FOTCCLSE = '" & CInt(inFOTCCLSE) & "' and "
            stConsultaSQL += "FOTCCLCO = '" & CInt(inFOTCCLCO) & "' and "
            stConsultaSQL += "FOTCTICO = '" & CStr(Trim(stFOTCTICO)) & "' "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Buscar_CODIGO_MANT_FOTOTICO")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que busca el para que no se 
    ''' guarden registros duplicados.
    ''' </summary>
    Public Function fun_Buscar_CODIGO_X_MANT_FOTOTICO(ByVal stFOTCDEPA As String, _
                                                      ByVal stFOTCMUNI As String, _
                                                      ByVal inFOTCCLSE As Integer, _
                                                      ByVal inFOTCCLCO As Integer, _
                                                      ByVal stFOTCTICO As String, _
                                                      ByVal inFOTCCAFO As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MANT_FOTOTICO "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "FOTCDEPA = '" & CStr(Trim(stFOTCDEPA)) & "' and "
            stConsultaSQL += "FOTCMUNI = '" & CStr(Trim(stFOTCMUNI)) & "' and "
            stConsultaSQL += "FOTCCLSE = '" & CInt(inFOTCCLSE) & "' and "
            stConsultaSQL += "FOTCCLCO = '" & CInt(inFOTCCLCO) & "' and "
            stConsultaSQL += "FOTCTICO = '" & CStr(Trim(stFOTCTICO)) & "' and "
            stConsultaSQL += "FOTCCAFO = '" & CInt(inFOTCCAFO) & "' "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Buscar_CODIGO_MANT_FOTOTICO")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que busca el ID del codigo buscado para ejecutar la consulta
    ''' parametrizada.
    ''' </summary>
    Public Function fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_MANT_FOTOTICO(ByVal inFOTCIDRE As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "FOTCIDRE, "
            stConsultaSQL += "FOTCDEPA, "
            stConsultaSQL += "FOTCMUNI, "
            stConsultaSQL += "FOTCCLSE, "
            stConsultaSQL += "FOTCTIPO, "
            stConsultaSQL += "FOTCCLCO, "
            stConsultaSQL += "FOTCTICO, "
            stConsultaSQL += "FOTCCAFO, "
            stConsultaSQL += "FOTCESTA  "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MANT_FOTOTICO "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "FOTCIDRE = '" & CInt(inFOTCIDRE) & "'"

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "FOTCDEPA, FOTCMUNI, FOTCCLSE, FOTCTIPO, FOTCCLCO, FOTCTICO, FOTCCAFO "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception

            MessageBox.Show(Err.Description & " " & "fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_MANT_FOTOTICO")
            Return Nothing

        End Try

    End Function


End Class
