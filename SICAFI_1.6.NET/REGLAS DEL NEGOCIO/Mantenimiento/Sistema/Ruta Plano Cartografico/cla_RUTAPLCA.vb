Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration
Imports DATOS

Public Class cla_RUTAPLCA

    '=====================================
    '*** CLASE RUTA PLANO CARTOGRAFICO ***
    '=====================================

    ''' <summary>
    ''' procedimiento que verifica la llave primaria.
    ''' </summary>
    Public Function fun_Verifica_llave_Primaria_MANT_RUTAPLCA(ByVal obRUPCDEPA As Object, _
                                                              ByVal obRUPCMUNI As Object, _
                                                              ByVal obRUPCCLSE As Object, _
                                                              ByVal obRUPCPLCA As Object) As Boolean

        Try
            Dim boRespuesta As Boolean = False

            Dim obVerifica As New cla_Verificar_Dato

            If obVerifica.fun_Verificar_Campo_Lleno(obRUPCDEPA.SelectedValue) = True And _
               obVerifica.fun_Verificar_Campo_Lleno(obRUPCMUNI.SelectedValue) = True And _
               obVerifica.fun_Verificar_Campo_Lleno(obRUPCCLSE.SelectedValue) = True And _
               obVerifica.fun_Verificar_Campo_Lleno(obRUPCPLCA.SelectedValue) = True Then

                If obVerifica.fun_Verificar_Dato_Numerico(obRUPCDEPA.SelectedValue) = True And _
                   obVerifica.fun_Verificar_Dato_Numerico(obRUPCMUNI.SelectedValue) = True And _
                   obVerifica.fun_Verificar_Dato_Numerico(obRUPCCLSE.SelectedValue) = True And _
                   obVerifica.fun_Verificar_Dato_Numerico(obRUPCPLCA.SelectedValue) = True Then

                    Dim objdatos1 As New cla_RUTAPLCA
                    Dim tbl As New DataTable

                    tbl = objdatos1.fun_Buscar_CODIGO_DEPA_MUNI_CLSE_CORR_RUPC_X_MANT_RUTAPLCA(Trim(obRUPCDEPA.SelectedValue), _
                                                                                               Trim(obRUPCMUNI.SelectedValue), _
                                                                                               Trim(obRUPCCLSE.SelectedValue), _
                                                                                               Trim(obRUPCPLCA.SelectedValue))

                    If tbl.Rows.Count > 0 Then
                        MessageBox.Show("El dato " & Trim(obRUPCDEPA.Text) & " - " & Trim(obRUPCMUNI.Text) & " - " & Trim(obRUPCCLSE.Text) & " del campo " & obRUPCPLCA.AccessibleDescription & " existe en la base de datos.", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                        obRUPCDEPA.Focus()
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
    Public Function fun_Insertar_MANT_RUTAPLCA(ByVal stRUPCDEPA As String, _
                                               ByVal stRUPCMUNI As String, _
                                               ByVal inRUPCCLSE As Integer, _
                                               ByVal stRUPCPLCA As String, _
                                               ByVal stRUPCRUTA As String, _
                                               ByVal stRUPCESTA As String) As Boolean

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "INSERT INTO "
            stConsultaSQL += "MANT_RUTAPLCA "

            stConsultaSQL += "( "
            stConsultaSQL += "RUPCDEPA, "
            stConsultaSQL += "RUPCMUNI, "
            stConsultaSQL += "RUPCCLSE, "
            stConsultaSQL += "RUPCPLCA, "
            stConsultaSQL += "RUPCRUTA, "
            stConsultaSQL += "RUPCESTA "
            stConsultaSQL += ") "

            stConsultaSQL += "VALUES "

            stConsultaSQL += "( "
            stConsultaSQL += "'" & CStr(Trim(stRUPCDEPA)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stRUPCMUNI)) & "', "
            stConsultaSQL += "'" & CInt(inRUPCCLSE) & "', "
            stConsultaSQL += "'" & CStr(Trim(stRUPCPLCA)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stRUPCRUTA)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stRUPCESTA)) & "' "
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
            MessageBox.Show(Err.Description & " " & "fun_Insertar_MANT_RUTAPLCA")
        End Try

    End Function

    ''' <summary>
    ''' Función que Elimina el registro.
    ''' </summary>
    Public Function fun_Eliminar_MANT_RUTAPLCA(ByVal inRUPCIDRE As Integer) As Boolean

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "DELETE "
            stConsultaSQL += "MANT_RUTAPLCA "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "RUPCIDRE = '" & CInt(inRUPCIDRE) & "' "

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
            MessageBox.Show(Err.Description & " " & "fun_Eliminar_MANT_MANT_RUTAPLCA")
        End Try

    End Function

    ''' <summary>
    ''' Función que Modifica el registro.
    ''' </summary>
    Public Function fun_Actualizar_MANT_RUTAPLCA(ByVal inRUPCIDRE As Integer, _
                                                 ByVal stRUPCDEPA As String, _
                                                 ByVal stRUPCMUNI As String, _
                                                 ByVal inRUPCCLSE As Integer, _
                                                 ByVal stRUPCPLCA As String, _
                                                 ByVal stRUPCRUTA As String, _
                                                 ByVal stRUPCESTA As String) As Boolean

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "UPDATE "
            stConsultaSQL += "MANT_RUTAPLCA "

            stConsultaSQL += "SET "
            stConsultaSQL += "RUPCDEPA = '" & CStr(Trim(stRUPCDEPA)) & "', "
            stConsultaSQL += "RUPCMUNI = '" & CStr(Trim(stRUPCMUNI)) & "', "
            stConsultaSQL += "RUPCCLSE = '" & CInt(inRUPCCLSE) & "', "
            stConsultaSQL += "RUPCPLCA = '" & CStr(Trim(stRUPCPLCA)) & "', "
            stConsultaSQL += "RUPCRUTA = '" & CStr(Trim(stRUPCRUTA)) & "', "
            stConsultaSQL += "RUPCESTA = '" & CStr(Trim(stRUPCESTA)) & "' "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "RUPCIDRE = '" & CInt(inRUPCIDRE) & "'"

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
            MessageBox.Show(Err.Description & " " & "fun_Actualizar_MANT_RUTAPLCA")
        End Try

    End Function

    ''' <summary>
    ''' Consulta para llenar el DataGridView y colocar el nombre del encabezado
    ''' de la columna. 
    ''' </summary>
    Public Function fun_Consultar_MANT_RUTAPLCA() As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "RUPCIDRE, "
            stConsultaSQL += "RUPCDEPA, "
            stConsultaSQL += "RUPCMUNI, "
            stConsultaSQL += "RUPCCLSE, "
            stConsultaSQL += "RUPCPLCA, "
            stConsultaSQL += "RUPCRUTA, "
            stConsultaSQL += "RUPCESTA  "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MANT_RUTAPLCA "

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "RUPCDEPA, RUPCMUNI, RUPCCLSE, RUPCPLCA "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Consultar_MANT_RUTAPLCA")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Llena el ComboBox con datos activos e inactivos formulario principal 
    ''' esta funcion se llama desde el procedimiento "pro_inicializarControles()".
    ''' </summary>
    Public Function fun_Consultar_CAMPOS_MANT_RUTAPLCA() As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MANT_RUTAPLCA "

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "RUPCDEPA, RUPCMUNI, RUPCCLSE, RUPCPLCA "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Consultar_CAMPOS_MANT_RUTAPLCA")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Llena el ComboBox con datos activos formulario insertar y modificar 
    ''' esta funcion se llama desde el procedimiento "pro_inicializarControles()".
    ''' </summary>
    Public Function fun_Consultar_MANT_RUTAPLCA_X_ESTADO() As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MANT_RUTAPLCA "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "RUPCESTA = 'ac' "

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "RUPCDEPA, RUPCMUNI, RUPCCLSE, RUPCPLCA "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Consultar_MANT_RUTAPLCA_X_ESTADO")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que busca el ID del registro a modificar o eliminar.
    ''' </summary>
    Public Function fun_Buscar_ID_MANT_RUTAPLCA(ByVal inRUPCIDRE As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MANT_RUTAPLCA "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "RUPCIDRE = '" & CInt(inRUPCIDRE) & "'"

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Buscar_ID_MANT_RUTAPLCA")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que busca el ID del codigo buscado para ejecutar la consulta
    ''' parametrizada.
    ''' </summary>
    Public Function fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_MANT_RUTAPLCA(ByVal inRUPCIDRE As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "RUPCIDRE, "
            stConsultaSQL += "RUPCDEPA, "
            stConsultaSQL += "RUPCMUNI, "
            stConsultaSQL += "RUPCCLSE, "
            stConsultaSQL += "RUPCPLCA, "
            stConsultaSQL += "RUPCRUTA, "
            stConsultaSQL += "RUPCESTA  "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MANT_RUTAPLCA "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "RUPCIDRE = '" & CInt(inRUPCIDRE) & "'"

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "RUPCDEPA, RUPCMUNI, RUPCCLSE, RUPCPLCA "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception

            MessageBox.Show(Err.Description & " " & "fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_MANT_RUTAPLCA")
            Return Nothing

        End Try

    End Function

    ''' <summary>
    ''' Función que busca el para que no se 
    ''' guarden registros duplicados.
    ''' </summary>
    Public Function fun_Buscar_CODIGO_DEPA_MUNI_CLSE_RUPC_X_MANT_RUTAPLCA(ByVal stRUPCDEPA As String, _
                                                                          ByVal stRUPCMUNI As String, _
                                                                          ByVal inRUPCCLSE As Integer, _
                                                                          ByVal stRUPCPLCA As String) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MANT_RUTAPLCA "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "RUPCDEPA = '" & CStr(Trim(stRUPCDEPA)) & "' and "
            stConsultaSQL += "RUPCMUNI = '" & CStr(Trim(stRUPCMUNI)) & "' and "
            stConsultaSQL += "RUPCCLSE = '" & CInt(inRUPCCLSE) & "' and "
            stConsultaSQL += "RUPCPLCA = '" & CStr(Trim(stRUPCPLCA)) & "' "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Buscar_CODIGO_MANT_RUTAPLCA")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que busca el para que no se 
    ''' guarden registros duplicados.
    ''' </summary>
    Public Function fun_Buscar_CODIGO_DEPA_MUNI_CLSE_CORR_RUPC_X_MANT_RUTAPLCA(ByVal stRUPCDEPA As String, _
                                                                               ByVal stRUPCMUNI As String, _
                                                                               ByVal inRUPCCLSE As Integer, _
                                                                               ByVal stRUPCPLCA As String) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MANT_RUTAPLCA "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "RUPCDEPA = '" & CStr(Trim(stRUPCDEPA)) & "' and "
            stConsultaSQL += "RUPCMUNI = '" & CStr(Trim(stRUPCMUNI)) & "' and "
            stConsultaSQL += "RUPCCLSE = '" & CInt(inRUPCCLSE) & "' and "
            stConsultaSQL += "RUPCPLCA = '" & CStr(Trim(stRUPCPLCA)) & "' "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Buscar_CODIGO_MANT_RUTAPLCA")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que busca el para que no se 
    ''' guarden registros duplicados.
    ''' </summary>
    Public Function fun_Buscar_CODIGO_DEPA_MUNI_CLSE_X_MANT_RUTAPLCA(ByVal stRUPCDEPA As String, _
                                                                     ByVal stRUPCMUNI As String, _
                                                                     ByVal inRUPCCLSE As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MANT_RUTAPLCA "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "RUPCDEPA = '" & CStr(Trim(stRUPCDEPA)) & "' and "
            stConsultaSQL += "RUPCMUNI = '" & CStr(Trim(stRUPCMUNI)) & "' and "
            stConsultaSQL += "RUPCCLSE = '" & CInt(inRUPCCLSE) & "' "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Buscar_CODIGO_MANT_RUTAPLCA")
            Return Nothing
        End Try

    End Function


End Class
