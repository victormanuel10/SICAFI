Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration
Imports DATOS

Public Class cla_PREDEXEN

    '=============================
    '*** CLASE PREDIOS EXENTOS ***
    '=============================

    ''' <summary>
    ''' procedimiento que verifica la llave primaria.
    ''' </summary>
    Public Function fun_Verifica_llave_Primaria_PREDEXEN(ByVal obPREXDEPA As Object, _
                                                         ByVal obPREXMUNI As Object, _
                                                         ByVal obPREXCLSE As Object, _
                                                         ByVal obPREXNUFI As Object) As Boolean

        Try
            Dim boRespuesta As Boolean = False

            Dim obVerifica As New cla_Verificar_Dato

            If obVerifica.fun_Verificar_Campo_Lleno(obPREXDEPA.SelectedValue) = True And _
               obVerifica.fun_Verificar_Campo_Lleno(obPREXMUNI.SelectedValue) = True And _
               obVerifica.fun_Verificar_Campo_Lleno(obPREXCLSE.SelectedValue) = True And _
               obVerifica.fun_Verificar_Campo_Lleno(obPREXNUFI.Text) = True Then

                If obVerifica.fun_Verificar_Dato_Numerico(obPREXDEPA.SelectedValue) = True And _
                   obVerifica.fun_Verificar_Dato_Numerico(obPREXMUNI.SelectedValue) = True And _
                   obVerifica.fun_Verificar_Dato_Numerico(obPREXCLSE.SelectedValue) = True And _
                   obVerifica.fun_Verificar_Dato_Numerico(obPREXNUFI.Text) = True Then

                    Dim objdatos1 As New cla_PREDEXEN
                    Dim tbl As New DataTable

                    tbl = objdatos1.fun_Buscar_CODIGO_DEPA_MUNI_CLSE_NUFI_X_PREDEXEN(obPREXDEPA.SelectedValue, _
                                                                                     obPREXMUNI.SelectedValue, _
                                                                                     obPREXCLSE.SelectedValue, _
                                                                                     obPREXNUFI.Text)

                    If tbl.Rows.Count > 0 Then
                        MessageBox.Show("El dato " & Trim(obPREXDEPA.Text) & " - " & _
                                                     Trim(obPREXMUNI.Text) & " - " & _
                                                     Trim(obPREXCLSE.Text) & " - " & _
                                                     Trim(obPREXNUFI.Text) & " - " & " existe en la base de datos.", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                        obPREXDEPA.Focus()
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
    Public Function fun_Insertar_PREDEXEN(ByVal stPREXDEPA As String, _
                                          ByVal stPREXMUNI As String, _
                                          ByVal inPREXCLSE As Integer, _
                                          ByVal inPREXNUFI As Integer, _
                                          ByVal inPREXTIIM As Integer, _
                                          ByVal inPREXCONC As Integer, _
                                          ByVal inPREXVIIN As Integer, _
                                          ByVal inPREXVIFI As Integer, _
                                          ByVal stPREXPOAP As String, _
                                          ByVal stPREXRESO As String, _
                                          ByVal stPREXFECH As String, _
                                          ByVal stPREXOBSE As String, _
                                          ByVal stPREXESTA As String) As Boolean

        Try

            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "INSERT INTO "
            stConsultaSQL += "PREDEXEN "

            stConsultaSQL += "( "
            stConsultaSQL += "PREXDEPA, "
            stConsultaSQL += "PREXMUNI, "
            stConsultaSQL += "PREXCLSE, "
            stConsultaSQL += "PREXNUFI, "
            stConsultaSQL += "PREXTIIM, "
            stConsultaSQL += "PREXCONC, "
            stConsultaSQL += "PREXVIIN, "
            stConsultaSQL += "PREXVIFI, "
            stConsultaSQL += "PREXPOAP, "
            stConsultaSQL += "PREXRESO, "
            stConsultaSQL += "PREXFECH, "
            stConsultaSQL += "PREXOBSE, "
            stConsultaSQL += "PREXESTA "
            stConsultaSQL += ") "

            stConsultaSQL += "VALUES "

            stConsultaSQL += "( "
            stConsultaSQL += "'" & CStr(Trim(stPREXDEPA)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stPREXMUNI)) & "', "
            stConsultaSQL += "'" & CInt(inPREXCLSE) & "', "
            stConsultaSQL += "'" & CInt(inPREXNUFI) & "', "
            stConsultaSQL += "'" & CInt(inPREXTIIM) & "', "
            stConsultaSQL += "'" & CInt(inPREXCONC) & "', "
            stConsultaSQL += "'" & CInt(inPREXVIIN) & "', "
            stConsultaSQL += "'" & CInt(inPREXVIFI) & "', "
            stConsultaSQL += "'" & CStr(Trim(stPREXPOAP)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stPREXRESO)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stPREXFECH)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stPREXOBSE)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stPREXESTA)) & "' "
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
            MessageBox.Show(Err.Description & " " & "fun_Insertar_PREDEXEN")
        End Try

    End Function

    ''' <summary>
    ''' Función que Elimina el registro.
    ''' </summary>
    Public Function fun_Eliminar_PREDEXEN(ByVal inPREXIDRE As Integer) As Boolean

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "DELETE "
            stConsultaSQL += "PREDEXEN "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "PREXIDRE = '" & CInt(inPREXIDRE) & "' "

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
            MessageBox.Show(Err.Description & " " & "fun_Eliminar_PREDEXEN")
        End Try

    End Function

    ''' <summary>
    ''' Función que Modifica el registro.
    ''' </summary>
    Public Function fun_Actualizar_PREDEXEN(ByVal inPREXIDRE As Integer, _
                                          ByVal stPREXDEPA As String, _
                                          ByVal stPREXMUNI As String, _
                                          ByVal inPREXCLSE As Integer, _
                                          ByVal inPREXNUFI As Integer, _
                                          ByVal inPREXTIIM As Integer, _
                                          ByVal inPREXCONC As Integer, _
                                          ByVal inPREXVIIN As Integer, _
                                          ByVal inPREXVIFI As Integer, _
                                          ByVal stPREXPOAP As String, _
                                          ByVal stPREXRESO As String, _
                                          ByVal stPREXFECH As String, _
                                          ByVal stPREXOBSE As String, _
                                          ByVal stPREXESTA As String) As Boolean

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "UPDATE "
            stConsultaSQL += "PREDEXEN "

            stConsultaSQL += "SET "
            stConsultaSQL += "PREXDEPA = '" & CStr(Trim(stPREXDEPA)) & "', "
            stConsultaSQL += "PREXMUNI = '" & CStr(Trim(stPREXMUNI)) & "', "
            stConsultaSQL += "PREXCLSE = '" & CInt(inPREXCLSE) & "', "
            stConsultaSQL += "PREXNUFI = '" & CInt(inPREXNUFI) & "', "
            stConsultaSQL += "PREXTIIM = '" & CInt(inPREXTIIM) & "', "
            stConsultaSQL += "PREXCONC = '" & CInt(inPREXCONC) & "', "
            stConsultaSQL += "PREXVIIN = '" & CInt(inPREXVIIN) & "', "
            stConsultaSQL += "PREXVIFI = '" & CInt(inPREXVIFI) & "', "
            stConsultaSQL += "PREXPOAP = '" & CStr(Trim(stPREXPOAP)) & "', "
            stConsultaSQL += "PREXRESO = '" & CStr(Trim(stPREXRESO)) & "', "
            stConsultaSQL += "PREXFECH = '" & CStr(Trim(stPREXFECH)) & "', "
            stConsultaSQL += "PREXOBSE = '" & CStr(Trim(stPREXOBSE)) & "', "
            stConsultaSQL += "PREXESTA = '" & CStr(Trim(stPREXESTA)) & "' "


            stConsultaSQL += "WHERE "
            stConsultaSQL += "PREXIDRE = '" & CInt(inPREXIDRE) & "'"

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
            MessageBox.Show(Err.Description & " " & "fun_Actualizar_PREDEXEN")
        End Try

    End Function

    ''' <summary>
    ''' Consulta para llenar el DataGridView y colocar el nombre del encabezado
    ''' de la columna. 
    ''' </summary>
    Public Function fun_Consultar_PREDEXEN() As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "PREXIDRE, "
            stConsultaSQL += "PREXDEPA, "
            stConsultaSQL += "PREXMUNI, "
            stConsultaSQL += "PREXCLSE, "
            stConsultaSQL += "PREXNUFI, "
            stConsultaSQL += "PREXTIIM, "
            stConsultaSQL += "PREXCONC, "
            stConsultaSQL += "PREXVIIN, "
            stConsultaSQL += "PREXVIFI, "
            stConsultaSQL += "PREXPOAP, "
            stConsultaSQL += "PREXRESO, "
            stConsultaSQL += "PREXFECH, "
            stConsultaSQL += "PREXOBSE, "
            stConsultaSQL += "PREXESTA "

            stConsultaSQL += "FROM "
            stConsultaSQL += "PREDEXEN "

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "PREXDEPA, PREXMUNI, PREXCLSE, PREXTIIM, PREXCONC "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Consultar_PREDEXEN")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Llena el ComboBox con datos activos e inactivos formulario principal 
    ''' esta funcion se llama desde el procedimiento "pro_inicializarControles()".
    ''' </summary>
    Public Function fun_Consultar_CAMPOS_PREDEXEN() As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "PREDEXEN "

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "PREXDEPA, PREXMUNI, PREXCLSE, PREXTIIM, PREXCONC "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Consultar_CAMPOS_PREDEXEN")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Llena el ComboBox con datos activos formulario insertar y modificar 
    ''' esta funcion se llama desde el procedimiento "pro_inicializarControles()".
    ''' </summary>
    Public Function fun_Consultar_PREDEXEN_X_ESTADO() As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "PREDEXEN "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "PREXESTA = 'ac' "

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "PREXDEPA, PREXMUNI, PREXCLSE, PREXTIIM, PREXCONC "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Consultar_PREDEXEN_X_ESTADO")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que busca el ID del registro a modificar o eliminar.
    ''' </summary>
    Public Function fun_Buscar_ID_PREDEXEN(ByVal inPREXIDRE As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "PREDEXEN "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "PREXIDRE = '" & CInt(inPREXIDRE) & "'"

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Buscar_ID_PREDEXEN")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que busca el CÓDIGO para que no se 
    ''' guarden registros duplicados.
    ''' </summary>
    Public Function fun_Buscar_CODIGO_DEPA_MUNI_CLSE_NUFI_X_PREDEXEN(ByVal stPREXDEPA As String, _
                                                                          ByVal stPREXMUNI As String, _
                                                                          ByVal inPREXCLSE As Integer, _
                                                                          ByVal inPREXNUFI As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "PREDEXEN "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "PREXDEPA = '" & CStr(Trim(stPREXDEPA)) & "' and "
            stConsultaSQL += "PREXMUNI = '" & CStr(Trim(stPREXMUNI)) & "' and "
            stConsultaSQL += "PREXCLSE = '" & CInt(inPREXCLSE) & "' and "
            stConsultaSQL += "PREXNUFI = '" & CInt(inPREXNUFI) & "' "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Buscar_CODIGO_PREDEXEN")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que busca el ID del codigo buscado para ejecutar la consulta
    ''' parametrizada.
    ''' </summary>
    Public Function fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_PREDEXEN(ByVal inPREXIDRE As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "PREXIDRE, "
            stConsultaSQL += "PREXDEPA, "
            stConsultaSQL += "PREXMUNI, "
            stConsultaSQL += "PREXCLSE, "
            stConsultaSQL += "PREXNUFI, "
            stConsultaSQL += "PREXTIIM, "
            stConsultaSQL += "PREXCONC, "
            stConsultaSQL += "PREXVIIN, "
            stConsultaSQL += "PREXVIFI, "
            stConsultaSQL += "PREXPOAP, "
            stConsultaSQL += "PREXRESO, "
            stConsultaSQL += "PREXFECH, "
            stConsultaSQL += "PREXOBSE, "
            stConsultaSQL += "PREXESTA "
            stConsultaSQL += "FROM "
            stConsultaSQL += "PREDEXEN "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "PREXIDRE = '" & CInt(inPREXIDRE) & "'"

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "PREXDEPA, PREXMUNI, PREXCLSE, PREXTIIM, PREXCONC "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception

            MessageBox.Show(Err.Description & " " & "fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_PREDEXEN")
            Return Nothing

        End Try

    End Function

End Class
