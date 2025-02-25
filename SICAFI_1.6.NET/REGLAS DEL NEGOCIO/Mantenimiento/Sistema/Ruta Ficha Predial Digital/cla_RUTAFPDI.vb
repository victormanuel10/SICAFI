Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration
Imports DATOS

Public Class cla_RUTAFPDI

    '========================================
    '*** CLASE RUTA FICHA PREDIAL DIGITAL ***
    '========================================

    ''' <summary>
    ''' procedimiento que verifica la llave primaria.
    ''' </summary>
    Public Function fun_Verifica_llave_Primaria_MANT_RUTAFPDI(ByVal obRUFDDEPA As Object, _
                                                              ByVal obRUFDMUNI As Object, _
                                                              ByVal obRUFDCLSE As Object, _
                                                              ByVal obRUFDFPDI As Object) As Boolean

        Try
            Dim boRespuesta As Boolean = False

            Dim obVerifica As New cla_Verificar_Dato

            If obVerifica.fun_Verificar_Campo_Lleno(obRUFDDEPA.SelectedValue) = True And _
               obVerifica.fun_Verificar_Campo_Lleno(obRUFDMUNI.SelectedValue) = True And _
               obVerifica.fun_Verificar_Campo_Lleno(obRUFDCLSE.SelectedValue) = True And _
               obVerifica.fun_Verificar_Campo_Lleno(obRUFDFPDI.SelectedValue) = True Then

                If obVerifica.fun_Verificar_Dato_Numerico(obRUFDDEPA.SelectedValue) = True And _
                   obVerifica.fun_Verificar_Dato_Numerico(obRUFDMUNI.SelectedValue) = True And _
                   obVerifica.fun_Verificar_Dato_Numerico(obRUFDCLSE.SelectedValue) = True And _
                   obVerifica.fun_Verificar_Dato_Numerico(obRUFDFPDI.SelectedValue) = True Then

                    Dim objdatos1 As New cla_RUTAFPDI
                    Dim tbl As New DataTable

                    tbl = objdatos1.fun_Buscar_CODIGO_DEPA_MUNI_CLSE_CORR_RUFD_X_MANT_RUTAFPDI(Trim(obRUFDDEPA.SelectedValue), _
                                                                                               Trim(obRUFDMUNI.SelectedValue), _
                                                                                               Trim(obRUFDCLSE.SelectedValue), _
                                                                                               Trim(obRUFDFPDI.SelectedValue))

                    If tbl.Rows.Count > 0 Then
                        MessageBox.Show("El dato " & Trim(obRUFDDEPA.Text) & " - " & Trim(obRUFDMUNI.Text) & " - " & Trim(obRUFDCLSE.Text) & " del campo " & obRUFDFPDI.AccessibleDescription & " existe en la base de datos.", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                        obRUFDDEPA.Focus()
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
    Public Function fun_Insertar_MANT_RUTAFPDI(ByVal stRUFDDEPA As String, _
                                               ByVal stRUFDMUNI As String, _
                                               ByVal inRUFDCLSE As Integer, _
                                               ByVal stRUFDFPDI As String, _
                                               ByVal stRUFDRUTA As String, _
                                               ByVal stRUFDESTA As String) As Boolean

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "INSERT INTO "
            stConsultaSQL += "MANT_RUTAFPDI "

            stConsultaSQL += "( "
            stConsultaSQL += "RUFDDEPA, "
            stConsultaSQL += "RUFDMUNI, "
            stConsultaSQL += "RUFDCLSE, "
            stConsultaSQL += "RUFDFPDI, "
            stConsultaSQL += "RUFDRUTA, "
            stConsultaSQL += "RUFDESTA "
            stConsultaSQL += ") "

            stConsultaSQL += "VALUES "

            stConsultaSQL += "( "
            stConsultaSQL += "'" & CStr(Trim(stRUFDDEPA)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stRUFDMUNI)) & "', "
            stConsultaSQL += "'" & CInt(inRUFDCLSE) & "', "
            stConsultaSQL += "'" & CStr(Trim(stRUFDFPDI)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stRUFDRUTA)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stRUFDESTA)) & "' "
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
            MessageBox.Show(Err.Description & " " & "fun_Insertar_MANT_RUTAFPDI")
        End Try

    End Function

    ''' <summary>
    ''' Función que Elimina el registro.
    ''' </summary>
    Public Function fun_Eliminar_MANT_RUTAFPDI(ByVal inRUFDIDRE As Integer) As Boolean

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "DELETE "
            stConsultaSQL += "MANT_RUTAFPDI "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "RUFDIDRE = '" & CInt(inRUFDIDRE) & "' "

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
            MessageBox.Show(Err.Description & " " & "fun_Eliminar_MANT_MANT_RUTAFPDI")
        End Try

    End Function

    ''' <summary>
    ''' Función que Modifica el registro.
    ''' </summary>
    Public Function fun_Actualizar_MANT_RUTAFPDI(ByVal inRUFDIDRE As Integer, _
                                                 ByVal stRUFDDEPA As String, _
                                                 ByVal stRUFDMUNI As String, _
                                                 ByVal inRUFDCLSE As Integer, _
                                                 ByVal stRUFDFPDI As String, _
                                                 ByVal stRUFDRUTA As String, _
                                                 ByVal stRUFDESTA As String) As Boolean

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "UPDATE "
            stConsultaSQL += "MANT_RUTAFPDI "

            stConsultaSQL += "SET "
            stConsultaSQL += "RUFDDEPA = '" & CStr(Trim(stRUFDDEPA)) & "', "
            stConsultaSQL += "RUFDMUNI = '" & CStr(Trim(stRUFDMUNI)) & "', "
            stConsultaSQL += "RUFDCLSE = '" & CInt(inRUFDCLSE) & "', "
            stConsultaSQL += "RUFDFPDI = '" & CStr(Trim(stRUFDFPDI)) & "', "
            stConsultaSQL += "RUFDRUTA = '" & CStr(Trim(stRUFDRUTA)) & "', "
            stConsultaSQL += "RUFDESTA = '" & CStr(Trim(stRUFDESTA)) & "' "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "RUFDIDRE = '" & CInt(inRUFDIDRE) & "'"

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
            MessageBox.Show(Err.Description & " " & "fun_Actualizar_MANT_RUTAFPDI")
        End Try

    End Function

    ''' <summary>
    ''' Consulta para llenar el DataGridView y colocar el nombre del encabezado
    ''' de la columna. 
    ''' </summary>
    Public Function fun_Consultar_MANT_RUTAFPDI() As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "RUFDIDRE, "
            stConsultaSQL += "RUFDDEPA, "
            stConsultaSQL += "RUFDMUNI, "
            stConsultaSQL += "RUFDCLSE, "
            stConsultaSQL += "RUFDFPDI, "
            stConsultaSQL += "RUFDRUTA, "
            stConsultaSQL += "RUFDESTA  "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MANT_RUTAFPDI "

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "RUFDDEPA, RUFDMUNI, RUFDCLSE, RUFDFPDI "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Consultar_MANT_RUTAFPDI")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Llena el ComboBox con datos activos e inactivos formulario principal 
    ''' esta funcion se llama desde el procedimiento "pro_inicializarControles()".
    ''' </summary>
    Public Function fun_Consultar_CAMPOS_MANT_RUTAFPDI() As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MANT_RUTAFPDI "

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "RUFDDEPA, RUFDMUNI, RUFDCLSE, RUFDFPDI "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Consultar_CAMPOS_MANT_RUTAFPDI")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Llena el ComboBox con datos activos formulario insertar y modificar 
    ''' esta funcion se llama desde el procedimiento "pro_inicializarControles()".
    ''' </summary>
    Public Function fun_Consultar_MANT_RUTAFPDI_X_ESTADO() As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MANT_RUTAFPDI "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "RUFDESTA = 'ac' "

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "RUFDDEPA, RUFDMUNI, RUFDCLSE, RUFDFPDI "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Consultar_MANT_RUTAFPDI_X_ESTADO")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que busca el ID del registro a modificar o eliminar.
    ''' </summary>
    Public Function fun_Buscar_ID_MANT_RUTAFPDI(ByVal inRUFDIDRE As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MANT_RUTAFPDI "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "RUFDIDRE = '" & CInt(inRUFDIDRE) & "'"

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Buscar_ID_MANT_RUTAFPDI")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que busca el ID del codigo buscado para ejecutar la consulta
    ''' parametrizada.
    ''' </summary>
    Public Function fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_MANT_RUTAFPDI(ByVal inRUFDIDRE As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "RUFDIDRE, "
            stConsultaSQL += "RUFDDEPA, "
            stConsultaSQL += "RUFDMUNI, "
            stConsultaSQL += "RUFDCLSE, "
            stConsultaSQL += "RUFDFPDI, "
            stConsultaSQL += "RUFDRUTA, "
            stConsultaSQL += "RUFDESTA  "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MANT_RUTAFPDI "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "RUFDIDRE = '" & CInt(inRUFDIDRE) & "'"

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "RUFDDEPA, RUFDMUNI, RUFDCLSE, RUFDFPDI "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception

            MessageBox.Show(Err.Description & " " & "fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_MANT_RUTAFPDI")
            Return Nothing

        End Try

    End Function

    ''' <summary>
    ''' Función que busca el para que no se 
    ''' guarden registros duplicados.
    ''' </summary>
    Public Function fun_Buscar_CODIGO_DEPA_MUNI_CLSE_RUFD_X_MANT_RUTAFPDI(ByVal stRUFDDEPA As String, _
                                                                          ByVal stRUFDMUNI As String, _
                                                                          ByVal inRUFDCLSE As Integer, _
                                                                          ByVal stRUFDFPDI As String) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MANT_RUTAFPDI "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "RUFDDEPA = '" & CStr(Trim(stRUFDDEPA)) & "' and "
            stConsultaSQL += "RUFDMUNI = '" & CStr(Trim(stRUFDMUNI)) & "' and "
            stConsultaSQL += "RUFDCLSE = '" & CInt(inRUFDCLSE) & "' and "
            stConsultaSQL += "RUFDFPDI = '" & CStr(Trim(stRUFDFPDI)) & "' "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Buscar_CODIGO_MANT_RUTAFPDI")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que busca el para que no se 
    ''' guarden registros duplicados.
    ''' </summary>
    Public Function fun_Buscar_CODIGO_DEPA_MUNI_CLSE_CORR_RUFD_X_MANT_RUTAFPDI(ByVal stRUFDDEPA As String, _
                                                                               ByVal stRUFDMUNI As String, _
                                                                               ByVal inRUFDCLSE As Integer, _
                                                                               ByVal stRUFDFPDI As String) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MANT_RUTAFPDI "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "RUFDDEPA = '" & CStr(Trim(stRUFDDEPA)) & "' and "
            stConsultaSQL += "RUFDMUNI = '" & CStr(Trim(stRUFDMUNI)) & "' and "
            stConsultaSQL += "RUFDCLSE = '" & CInt(inRUFDCLSE) & "' and "
            stConsultaSQL += "RUFDFPDI = '" & CStr(Trim(stRUFDFPDI)) & "' "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Buscar_CODIGO_MANT_RUTAFPDI")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que busca el para que no se 
    ''' guarden registros duplicados.
    ''' </summary>
    Public Function fun_Buscar_CODIGO_DEPA_MUNI_CLSE_X_MANT_RUTAFPDI(ByVal stRUFDDEPA As String, _
                                                                     ByVal stRUFDMUNI As String, _
                                                                     ByVal inRUFDCLSE As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MANT_RUTAFPDI "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "RUFDDEPA = '" & CStr(Trim(stRUFDDEPA)) & "' and "
            stConsultaSQL += "RUFDMUNI = '" & CStr(Trim(stRUFDMUNI)) & "' and "
            stConsultaSQL += "RUFDCLSE = '" & CInt(inRUFDCLSE) & "' "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Buscar_CODIGO_MANT_RUTAFPDI")
            Return Nothing
        End Try

    End Function

End Class
