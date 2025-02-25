Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration
Imports DATOS

Public Class cla_RUTACAFO

    '======================================
    '*** CLASE RUTA CARPETA FOTOGRAFICA ***
    '======================================

    ''' <summary>
    ''' procedimiento que verifica la llave primaria.
    ''' </summary>
    Public Function fun_Verifica_llave_Primaria_MANT_RUTACAFO(ByVal obRUCFDEPA As Object, _
                                                              ByVal obRUCFMUNI As Object, _
                                                              ByVal obRUCFCLSE As Object, _
                                                              ByVal obRUCFCAFO As Object) As Boolean

        Try
            Dim boRespuesta As Boolean = False

            Dim obVerifica As New cla_Verificar_Dato

            If obVerifica.fun_Verificar_Campo_Lleno(obRUCFDEPA.SelectedValue) = True And _
               obVerifica.fun_Verificar_Campo_Lleno(obRUCFMUNI.SelectedValue) = True And _
               obVerifica.fun_Verificar_Campo_Lleno(obRUCFCLSE.SelectedValue) = True And _
               obVerifica.fun_Verificar_Campo_Lleno(obRUCFCAFO.SelectedValue) = True Then

                If obVerifica.fun_Verificar_Dato_Numerico(obRUCFDEPA.SelectedValue) = True And _
                   obVerifica.fun_Verificar_Dato_Numerico(obRUCFMUNI.SelectedValue) = True And _
                   obVerifica.fun_Verificar_Dato_Numerico(obRUCFCLSE.SelectedValue) = True And _
                   obVerifica.fun_Verificar_Dato_Numerico(obRUCFCAFO.SelectedValue) = True Then

                    Dim objdatos1 As New cla_RUTACAFO
                    Dim tbl As New DataTable

                    tbl = objdatos1.fun_Buscar_CODIGO_DEPA_MUNI_CLSE_CORR_RUCF_X_MANT_RUTACAFO(Trim(obRUCFDEPA.SelectedValue), _
                                                                                               Trim(obRUCFMUNI.SelectedValue), _
                                                                                               Trim(obRUCFCLSE.SelectedValue), _
                                                                                               Trim(obRUCFCAFO.SelectedValue))

                    If tbl.Rows.Count > 0 Then
                        MessageBox.Show("El dato " & Trim(obRUCFDEPA.Text) & " - " & Trim(obRUCFMUNI.Text) & " - " & Trim(obRUCFCLSE.Text) & " del campo " & obRUCFCAFO.AccessibleDescription & " existe en la base de datos.", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                        obRUCFDEPA.Focus()
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
    Public Function fun_Insertar_MANT_RUTACAFO(ByVal stRUCFDEPA As String, _
                                               ByVal stRUCFMUNI As String, _
                                               ByVal inRUCFCLSE As Integer, _
                                               ByVal stRUCFCAFO As String, _
                                               ByVal stRUCFRUTA As String, _
                                               ByVal stRUCFESTA As String) As Boolean

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "INSERT INTO "
            stConsultaSQL += "MANT_RUTACAFO "

            stConsultaSQL += "( "
            stConsultaSQL += "RUCFDEPA, "
            stConsultaSQL += "RUCFMUNI, "
            stConsultaSQL += "RUCFCLSE, "
            stConsultaSQL += "RUCFCAFO, "
            stConsultaSQL += "RUCFRUTA, "
            stConsultaSQL += "RUCFESTA "
            stConsultaSQL += ") "

            stConsultaSQL += "VALUES "

            stConsultaSQL += "( "
            stConsultaSQL += "'" & CStr(Trim(stRUCFDEPA)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stRUCFMUNI)) & "', "
            stConsultaSQL += "'" & CInt(inRUCFCLSE) & "', "
            stConsultaSQL += "'" & CStr(Trim(stRUCFCAFO)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stRUCFRUTA)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stRUCFESTA)) & "' "
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
            MessageBox.Show(Err.Description & " " & "fun_Insertar_MANT_RUTACAFO")
        End Try

    End Function

    ''' <summary>
    ''' Función que Elimina el registro.
    ''' </summary>
    Public Function fun_Eliminar_MANT_RUTACAFO(ByVal inRUCFIDRE As Integer) As Boolean

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "DELETE "
            stConsultaSQL += "MANT_RUTACAFO "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "RUCFIDRE = '" & CInt(inRUCFIDRE) & "' "

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
            MessageBox.Show(Err.Description & " " & "fun_Eliminar_MANT_MANT_RUTACAFO")
        End Try

    End Function

    ''' <summary>
    ''' Función que Modifica el registro.
    ''' </summary>
    Public Function fun_Actualizar_MANT_RUTACAFO(ByVal inRUCFIDRE As Integer, _
                                                 ByVal stRUCFDEPA As String, _
                                                 ByVal stRUCFMUNI As String, _
                                                 ByVal inRUCFCLSE As Integer, _
                                                 ByVal stRUCFCAFO As String, _
                                                 ByVal stRUCFRUTA As String, _
                                                 ByVal stRUCFESTA As String) As Boolean

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "UPDATE "
            stConsultaSQL += "MANT_RUTACAFO "

            stConsultaSQL += "SET "
            stConsultaSQL += "RUCFDEPA = '" & CStr(Trim(stRUCFDEPA)) & "', "
            stConsultaSQL += "RUCFMUNI = '" & CStr(Trim(stRUCFMUNI)) & "', "
            stConsultaSQL += "RUCFCLSE = '" & CInt(inRUCFCLSE) & "', "
            stConsultaSQL += "RUCFCAFO = '" & CStr(Trim(stRUCFCAFO)) & "', "
            stConsultaSQL += "RUCFRUTA = '" & CStr(Trim(stRUCFRUTA)) & "', "
            stConsultaSQL += "RUCFESTA = '" & CStr(Trim(stRUCFESTA)) & "' "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "RUCFIDRE = '" & CInt(inRUCFIDRE) & "'"

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
            MessageBox.Show(Err.Description & " " & "fun_Actualizar_MANT_RUTACAFO")
        End Try

    End Function

    ''' <summary>
    ''' Consulta para llenar el DataGridView y colocar el nombre del encabezado
    ''' de la columna. 
    ''' </summary>
    Public Function fun_Consultar_MANT_RUTACAFO() As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "RUCFIDRE, "
            stConsultaSQL += "RUCFDEPA, "
            stConsultaSQL += "RUCFMUNI, "
            stConsultaSQL += "RUCFCLSE, "
            stConsultaSQL += "RUCFCAFO, "
            stConsultaSQL += "RUCFRUTA, "
            stConsultaSQL += "RUCFESTA  "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MANT_RUTACAFO "

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "RUCFDEPA, RUCFMUNI, RUCFCLSE, RUCFCAFO "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Consultar_MANT_RUTACAFO")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Llena el ComboBox con datos activos e inactivos formulario principal 
    ''' esta funcion se llama desde el procedimiento "pro_inicializarControles()".
    ''' </summary>
    Public Function fun_Consultar_CAMPOS_MANT_RUTACAFO() As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MANT_RUTACAFO "

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "RUCFDEPA, RUCFMUNI, RUCFCLSE, RUCFCAFO "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Consultar_CAMPOS_MANT_RUTACAFO")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Llena el ComboBox con datos activos formulario insertar y modificar 
    ''' esta funcion se llama desde el procedimiento "pro_inicializarControles()".
    ''' </summary>
    Public Function fun_Consultar_MANT_RUTACAFO_X_ESTADO() As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MANT_RUTACAFO "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "RUCFESTA = 'ac' "

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "RUCFDEPA, RUCFMUNI, RUCFCLSE, RUCFCAFO "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Consultar_MANT_RUTACAFO_X_ESTADO")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que busca el ID del registro a modificar o eliminar.
    ''' </summary>
    Public Function fun_Buscar_ID_MANT_RUTACAFO(ByVal inRUCFIDRE As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MANT_RUTACAFO "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "RUCFIDRE = '" & CInt(inRUCFIDRE) & "'"

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Buscar_ID_MANT_RUTACAFO")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que busca el ID del codigo buscado para ejecutar la consulta
    ''' parametrizada.
    ''' </summary>
    Public Function fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_MANT_RUTACAFO(ByVal inRUCFIDRE As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "RUCFIDRE, "
            stConsultaSQL += "RUCFDEPA, "
            stConsultaSQL += "RUCFMUNI, "
            stConsultaSQL += "RUCFCLSE, "
            stConsultaSQL += "RUCFCAFO, "
            stConsultaSQL += "RUCFRUTA, "
            stConsultaSQL += "RUCFESTA  "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MANT_RUTACAFO "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "RUCFIDRE = '" & CInt(inRUCFIDRE) & "'"

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "RUCFDEPA, RUCFMUNI, RUCFCLSE, RUCFCAFO "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception

            MessageBox.Show(Err.Description & " " & "fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_MANT_RUTACAFO")
            Return Nothing

        End Try

    End Function

    ''' <summary>
    ''' Función que busca el para que no se 
    ''' guarden registros duplicados.
    ''' </summary>
    Public Function fun_Buscar_CODIGO_DEPA_MUNI_CLSE_RUCF_X_MANT_RUTACAFO(ByVal stRUCFDEPA As String, _
                                                                          ByVal stRUCFMUNI As String, _
                                                                          ByVal inRUCFCLSE As Integer, _
                                                                          ByVal stRUCFCAFO As String) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MANT_RUTACAFO "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "RUCFDEPA = '" & CStr(Trim(stRUCFDEPA)) & "' and "
            stConsultaSQL += "RUCFMUNI = '" & CStr(Trim(stRUCFMUNI)) & "' and "
            stConsultaSQL += "RUCFCLSE = '" & CInt(inRUCFCLSE) & "' and "
            stConsultaSQL += "RUCFCAFO = '" & CStr(Trim(stRUCFCAFO)) & "' "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Buscar_CODIGO_MANT_RUTACAFO")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que busca el para que no se 
    ''' guarden registros duplicados.
    ''' </summary>
    Public Function fun_Buscar_CODIGO_DEPA_MUNI_CLSE_CORR_RUCF_X_MANT_RUTACAFO(ByVal stRUCFDEPA As String, _
                                                                               ByVal stRUCFMUNI As String, _
                                                                               ByVal inRUCFCLSE As Integer, _
                                                                               ByVal stRUCFCAFO As String) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MANT_RUTACAFO "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "RUCFDEPA = '" & CStr(Trim(stRUCFDEPA)) & "' and "
            stConsultaSQL += "RUCFMUNI = '" & CStr(Trim(stRUCFMUNI)) & "' and "
            stConsultaSQL += "RUCFCLSE = '" & CInt(inRUCFCLSE) & "' and "
            stConsultaSQL += "RUCFCAFO = '" & CStr(Trim(stRUCFCAFO)) & "' "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Buscar_CODIGO_MANT_RUTACAFO")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que busca el para que no se 
    ''' guarden registros duplicados.
    ''' </summary>
    Public Function fun_Buscar_CODIGO_DEPA_MUNI_CLSE_X_MANT_RUTACAFO(ByVal stRUCFDEPA As String, _
                                                                     ByVal stRUCFMUNI As String, _
                                                                     ByVal inRUCFCLSE As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MANT_RUTACAFO "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "RUCFDEPA = '" & CStr(Trim(stRUCFDEPA)) & "' and "
            stConsultaSQL += "RUCFMUNI = '" & CStr(Trim(stRUCFMUNI)) & "' and "
            stConsultaSQL += "RUCFCLSE = '" & CInt(inRUCFCLSE) & "' "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Buscar_CODIGO_MANT_RUTACAFO")
            Return Nothing
        End Try

    End Function

End Class
