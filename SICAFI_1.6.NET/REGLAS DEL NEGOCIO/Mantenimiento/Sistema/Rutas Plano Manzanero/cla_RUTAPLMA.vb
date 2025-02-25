Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration
Imports DATOS

Public Class cla_RUTAPLMA

    '==================================
    '*** CLASE RUTA PLANO MANZANERO ***
    '==================================

    ''' <summary>
    ''' procedimiento que verifica la llave primaria.
    ''' </summary>
    Public Function fun_Verifica_llave_Primaria_MANT_RUTAPLMA(ByVal obRUPMDEPA As Object, _
                                                              ByVal obRUPMMUNI As Object, _
                                                              ByVal obRUPMCLSE As Object, _
                                                              ByVal obRUPMCORR As Object, _
                                                              ByVal obRUPMBAVE As Object) As Boolean

        Try
            Dim boRespuesta As Boolean = False

            Dim obVerifica As New cla_Verificar_Dato

            If obVerifica.fun_Verificar_Campo_Lleno(obRUPMDEPA.SelectedValue) = True And _
               obVerifica.fun_Verificar_Campo_Lleno(obRUPMMUNI.SelectedValue) = True And _
               obVerifica.fun_Verificar_Campo_Lleno(obRUPMCLSE.SelectedValue) = True And _
               obVerifica.fun_Verificar_Campo_Lleno(obRUPMCORR.SelectedValue) = True And _
               obVerifica.fun_Verificar_Campo_Lleno(obRUPMBAVE.SelectedValue) = True Then

                If obVerifica.fun_Verificar_Dato_Numerico(obRUPMDEPA.SelectedValue) = True And _
                   obVerifica.fun_Verificar_Dato_Numerico(obRUPMMUNI.SelectedValue) = True And _
                   obVerifica.fun_Verificar_Dato_Numerico(obRUPMCLSE.SelectedValue) = True And _
                   obVerifica.fun_Verificar_Dato_Numerico(obRUPMCORR.SelectedValue) = True And _
                   obVerifica.fun_Verificar_Dato_Numerico(obRUPMBAVE.SelectedValue) = True Then

                    Dim objdatos1 As New cla_RUTAPLMA
                    Dim tbl As New DataTable

                    tbl = objdatos1.fun_Buscar_CODIGO_DEPA_MUNI_CLSE_CORR_RUPM_X_MANT_RUTAPLMA(Trim(obRUPMDEPA.SelectedValue), _
                                                                                               Trim(obRUPMMUNI.SelectedValue), _
                                                                                               Trim(obRUPMCLSE.SelectedValue), _
                                                                                               Trim(obRUPMCORR.SelectedValue), _
                                                                                               Trim(obRUPMBAVE.SelectedValue))

                    If tbl.Rows.Count > 0 Then
                        MessageBox.Show("El dato " & Trim(obRUPMDEPA.Text) & " - " & Trim(obRUPMMUNI.Text) & " - " & Trim(obRUPMCLSE.Text) & " del campo " & obRUPMBAVE.AccessibleDescription & " existe en la base de datos.", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                        obRUPMDEPA.Focus()
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
    Public Function fun_Insertar_MANT_RUTAPLMA(ByVal stRUPMDEPA As String, _
                                               ByVal stRUPMMUNI As String, _
                                               ByVal inRUPMCLSE As Integer, _
                                               ByVal stRUPMBAVE As String, _
                                               ByVal stRUPMRUTA As String, _
                                               ByVal stRUPMESTA As String, _
                                               ByVal stRUPMCORR As String) As Boolean

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "INSERT INTO "
            stConsultaSQL += "MANT_RUTAPLMA "

            stConsultaSQL += "( "
            stConsultaSQL += "RUPMDEPA, "
            stConsultaSQL += "RUPMMUNI, "
            stConsultaSQL += "RUPMCLSE, "
            stConsultaSQL += "RUPMBAVE, "
            stConsultaSQL += "RUPMRUTA, "
            stConsultaSQL += "RUPMESTA, "
            stConsultaSQL += "RUPMCORR "
            stConsultaSQL += ") "

            stConsultaSQL += "VALUES "

            stConsultaSQL += "( "
            stConsultaSQL += "'" & CStr(Trim(stRUPMDEPA)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stRUPMMUNI)) & "', "
            stConsultaSQL += "'" & CInt(inRUPMCLSE) & "', "
            stConsultaSQL += "'" & CStr(Trim(stRUPMBAVE)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stRUPMRUTA)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stRUPMESTA)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stRUPMCORR)) & "'  "
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
            MessageBox.Show(Err.Description & " " & "fun_Insertar_MANT_RUTAPLMA")
        End Try

    End Function

    ''' <summary>
    ''' Función que Elimina el registro.
    ''' </summary>
    Public Function fun_Eliminar_MANT_RUTAPLMA(ByVal inRUPMIDRE As Integer) As Boolean

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "DELETE "
            stConsultaSQL += "MANT_RUTAPLMA "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "RUPMIDRE = '" & CInt(inRUPMIDRE) & "' "

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
            MessageBox.Show(Err.Description & " " & "fun_Eliminar_MANT_MANT_RUTAPLMA")
        End Try

    End Function

    ''' <summary>
    ''' Función que Modifica el registro.
    ''' </summary>
    Public Function fun_Actualizar_MANT_RUTAPLMA(ByVal inRUPMIDRE As Integer, _
                                                 ByVal stRUPMDEPA As String, _
                                                 ByVal stRUPMMUNI As String, _
                                                 ByVal inRUPMCLSE As Integer, _
                                                 ByVal stRUPMBAVE As String, _
                                                 ByVal stRUPMRUTA As String, _
                                                 ByVal stRUPMESTA As String, _
                                                 ByVal stRUPMCORR As String) As Boolean

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "UPDATE "
            stConsultaSQL += "MANT_RUTAPLMA "

            stConsultaSQL += "SET "
            stConsultaSQL += "RUPMDEPA = '" & CStr(Trim(stRUPMDEPA)) & "', "
            stConsultaSQL += "RUPMMUNI = '" & CStr(Trim(stRUPMMUNI)) & "', "
            stConsultaSQL += "RUPMCLSE = '" & CInt(inRUPMCLSE) & "', "
            stConsultaSQL += "RUPMBAVE = '" & CStr(Trim(stRUPMBAVE)) & "', "
            stConsultaSQL += "RUPMRUTA = '" & CStr(Trim(stRUPMRUTA)) & "', "
            stConsultaSQL += "RUPMESTA = '" & CStr(Trim(stRUPMESTA)) & "', "
            stConsultaSQL += "RUPMCORR = '" & CStr(Trim(stRUPMCORR)) & "' "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "RUPMIDRE = '" & CInt(inRUPMIDRE) & "'"

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
            MessageBox.Show(Err.Description & " " & "fun_Actualizar_MANT_RUTAPLMA")
        End Try

    End Function

    ''' <summary>
    ''' Consulta para llenar el DataGridView y colocar el nombre del encabezado
    ''' de la columna. 
    ''' </summary>
    Public Function fun_Consultar_MANT_RUTAPLMA() As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "RUPMIDRE, "
            stConsultaSQL += "RUPMDEPA, "
            stConsultaSQL += "RUPMMUNI, "
            stConsultaSQL += "RUPMCLSE, "
            stConsultaSQL += "RUPMCORR, "
            stConsultaSQL += "RUPMBAVE, "
            stConsultaSQL += "RUPMRUTA, "
            stConsultaSQL += "RUPMESTA  "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MANT_RUTAPLMA "

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "RUPMDEPA, RUPMMUNI, RUPMCLSE, RUPMBAVE "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Consultar_MANT_RUTAPLMA")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Llena el ComboBox con datos activos e inactivos formulario principal 
    ''' esta funcion se llama desde el procedimiento "pro_inicializarControles()".
    ''' </summary>
    Public Function fun_Consultar_CAMPOS_MANT_RUTAPLMA() As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MANT_RUTAPLMA "

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "RUPMDEPA, RUPMMUNI, RUPMCLSE, RUPMBAVE "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Consultar_CAMPOS_MANT_RUTAPLMA")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Llena el ComboBox con datos activos formulario insertar y modificar 
    ''' esta funcion se llama desde el procedimiento "pro_inicializarControles()".
    ''' </summary>
    Public Function fun_Consultar_MANT_RUTAPLMA_X_ESTADO() As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MANT_RUTAPLMA "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "RUPMESTA = 'ac' "

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "RUPMDEPA, RUPMMUNI, RUPMCLSE, RUPMBAVE "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Consultar_MANT_RUTAPLMA_X_ESTADO")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que busca el ID del registro a modificar o eliminar.
    ''' </summary>
    Public Function fun_Buscar_ID_MANT_RUTAPLMA(ByVal inRUPMIDRE As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MANT_RUTAPLMA "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "RUPMIDRE = '" & CInt(inRUPMIDRE) & "'"

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Buscar_ID_MANT_RUTAPLMA")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que busca el ID del codigo buscado para ejecutar la consulta
    ''' parametrizada.
    ''' </summary>
    Public Function fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_MANT_RUTAPLMA(ByVal inRUPMIDRE As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "RUPMIDRE, "
            stConsultaSQL += "RUPMDEPA, "
            stConsultaSQL += "RUPMMUNI, "
            stConsultaSQL += "RUPMCLSE, "
            stConsultaSQL += "RUPMCORR, "
            stConsultaSQL += "RUPMBAVE, "
            stConsultaSQL += "RUPMRUTA, "
            stConsultaSQL += "RUPMESTA  "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MANT_RUTAPLMA "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "RUPMIDRE = '" & CInt(inRUPMIDRE) & "'"

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "RUPMDEPA, RUPMMUNI, RUPMCLSE, RUPMBAVE "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception

            MessageBox.Show(Err.Description & " " & "fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_MANT_RUTAPLMA")
            Return Nothing

        End Try

    End Function

    ''' <summary>
    ''' Función que busca el para que no se 
    ''' guarden registros duplicados.
    ''' </summary>
    Public Function fun_Buscar_CODIGO_DEPA_MUNI_CLSE_RUPM_X_MANT_RUTAPLMA(ByVal stRUPMDEPA As String, _
                                                                          ByVal stRUPMMUNI As String, _
                                                                          ByVal inRUPMCLSE As Integer, _
                                                                          ByVal stRUPMBAVE As String) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MANT_RUTAPLMA "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "RUPMDEPA = '" & CStr(Trim(stRUPMDEPA)) & "' and "
            stConsultaSQL += "RUPMMUNI = '" & CStr(Trim(stRUPMMUNI)) & "' and "
            stConsultaSQL += "RUPMCLSE = '" & CInt(inRUPMCLSE) & "' and "
            stConsultaSQL += "RUPMBAVE = '" & CStr(Trim(stRUPMBAVE)) & "' "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Buscar_CODIGO_MANT_RUTAPLMA")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que busca el para que no se 
    ''' guarden registros duplicados.
    ''' </summary>
    Public Function fun_Buscar_CODIGO_DEPA_MUNI_CLSE_CORR_RUPM_X_MANT_RUTAPLMA(ByVal stRUPMDEPA As String, _
                                                                               ByVal stRUPMMUNI As String, _
                                                                               ByVal inRUPMCLSE As Integer, _
                                                                               ByVal stRUPMCORR As String, _
                                                                               ByVal stRUPMBAVE As String) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MANT_RUTAPLMA "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "RUPMDEPA = '" & CStr(Trim(stRUPMDEPA)) & "' and "
            stConsultaSQL += "RUPMMUNI = '" & CStr(Trim(stRUPMMUNI)) & "' and "
            stConsultaSQL += "RUPMCLSE = '" & CInt(inRUPMCLSE) & "' and "
            stConsultaSQL += "RUPMCORR = '" & CStr(Trim(stRUPMCORR)) & "' and "
            stConsultaSQL += "RUPMBAVE = '" & CStr(Trim(stRUPMBAVE)) & "' "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Buscar_CODIGO_MANT_RUTAPLMA")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que busca el para que no se 
    ''' guarden registros duplicados.
    ''' </summary>
    Public Function fun_Buscar_CODIGO_DEPA_MUNI_CLSE_X_MANT_RUTAPLMA(ByVal stRUPMDEPA As String, _
                                                                     ByVal stRUPMMUNI As String, _
                                                                     ByVal inRUPMCLSE As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MANT_RUTAPLMA "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "RUPMDEPA = '" & CStr(Trim(stRUPMDEPA)) & "' and "
            stConsultaSQL += "RUPMMUNI = '" & CStr(Trim(stRUPMMUNI)) & "' and "
            stConsultaSQL += "RUPMCLSE = '" & CInt(inRUPMCLSE) & "' "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Buscar_CODIGO_MANT_RUTAPLMA")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que busca el para que no se 
    ''' guarden registros duplicados.
    ''' </summary>
    Public Function fun_Buscar_CODIGO_DEPA_MUNI_CLSE_CORR_X_MANT_RUTAPLMA(ByVal stRUPMDEPA As String, _
                                                                          ByVal stRUPMMUNI As String, _
                                                                          ByVal inRUPMCLSE As Integer, _
                                                                          ByVal stRUPMCORR As String) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MANT_RUTAPLMA "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "RUPMDEPA = '" & CStr(Trim(stRUPMDEPA)) & "' and "
            stConsultaSQL += "RUPMMUNI = '" & CStr(Trim(stRUPMMUNI)) & "' and "
            stConsultaSQL += "RUPMCLSE = '" & CInt(inRUPMCLSE) & "'and "
            stConsultaSQL += "RUPMCORR = '" & CStr(Trim(stRUPMCORR)) & "' "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Buscar_CODIGO_MANT_RUTAPLMA")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que busca el para que no se 
    ''' guarden registros duplicados.
    ''' </summary>
    Public Function fun_Buscar_CODIGO_DEPA_MUNI_CLSE_CORR_BAVE_X_MANT_RUTAPLMA(ByVal stRUPMDEPA As String, _
                                                                               ByVal stRUPMMUNI As String, _
                                                                               ByVal inRUPMCLSE As Integer, _
                                                                               ByVal stRUPMCORR As String, _
                                                                               ByVal stRUPMBAVE As String) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MANT_RUTAPLMA "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "RUPMDEPA = '" & CStr(Trim(stRUPMDEPA)) & "' and "
            stConsultaSQL += "RUPMMUNI = '" & CStr(Trim(stRUPMMUNI)) & "' and "
            stConsultaSQL += "RUPMCLSE = '" & CInt(inRUPMCLSE) & "'and "
            stConsultaSQL += "RUPMCORR = '" & CStr(Trim(stRUPMCORR)) & "' and "
            stConsultaSQL += "RUPMBAVE = '" & CStr(Trim(stRUPMBAVE)) & "' "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Buscar_CODIGO_MANT_RUTAPLMA")
            Return Nothing
        End Try

    End Function

End Class
