Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration
Imports DATOS

Public Class cla_HISTZONA

    '==========================================
    '*** CLASE HISTORICO DE ZONAS ECONOMICA ***
    '==========================================

    ''' <summary>
    ''' procedimiento que verifica la llave primaria.
    ''' </summary>
    Public Function fun_Verifica_llave_Primaria_HISTZONA(ByVal obHIZONUFI As Object, _
                                                         ByVal obHIZODEPA As Object, _
                                                         ByVal obHIZOMUNI As Object, _
                                                         ByVal obHIZOCLSE As Object, _
                                                         ByVal obHIZOVIGE As Object, _
                                                         ByVal obHIZOZOEC As Object) As Boolean

        Try
            Dim boRespuesta As Boolean = False

            Dim obVerifica As New cla_Verificar_Dato

            If obVerifica.fun_Verificar_Campo_Lleno(obHIZONUFI.Text) = True And _
               obVerifica.fun_Verificar_Campo_Lleno(obHIZODEPA.SelectedValue) = True And _
               obVerifica.fun_Verificar_Campo_Lleno(obHIZOMUNI.SelectedValue) = True And _
               obVerifica.fun_Verificar_Campo_Lleno(obHIZOCLSE.SelectedValue) = True And _
               obVerifica.fun_Verificar_Campo_Lleno(obHIZOVIGE.SelectedValue) = True And _
               obVerifica.fun_Verificar_Campo_Lleno(obHIZOZOEC.SelectedValue) = True Then

                If obVerifica.fun_Verificar_Dato_Numerico(obHIZONUFI.Text) = True And _
                   obVerifica.fun_Verificar_Dato_Numerico(obHIZODEPA.SelectedValue) = True And _
                   obVerifica.fun_Verificar_Dato_Numerico(obHIZOMUNI.SelectedValue) = True And _
                   obVerifica.fun_Verificar_Dato_Numerico(obHIZOCLSE.SelectedValue) = True And _
                   obVerifica.fun_Verificar_Dato_Numerico(obHIZOVIGE.SelectedValue) = True And _
                   obVerifica.fun_Verificar_Dato_Numerico(obHIZOZOEC.SelectedValue) = True Then

                    Dim objdatos1 As New cla_HISTZONA
                    Dim tbl As New DataTable

                    tbl = objdatos1.fun_Buscar_CODIGO_NUFI_DEPA_MUNI_CLSE_VIGE_ZONA_X_HISTZONA(obHIZONUFI.Text, _
                                                                                          obHIZODEPA.SelectedValue, _
                                                                                          obHIZOMUNI.SelectedValue, _
                                                                                          obHIZOCLSE.SelectedValue, _
                                                                                          obHIZOVIGE.SelectedValue, _
                                                                                          obHIZOZOEC.SelectedValue)

                    If tbl.Rows.Count > 0 Then
                        MessageBox.Show("El dato " & Trim(obHIZODEPA.Text) & " - " & _
                                                     Trim(obHIZOMUNI.Text) & " - " & _
                                                     Trim(obHIZOCLSE.Text) & " - " & _
                                                     Trim(obHIZOVIGE.Text) & " - " & _
                                                     Trim(obHIZOZOEC.Text) & " - " & " existe en la base de datos.", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                        obHIZODEPA.Focus()
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
    Public Function fun_Insertar_HISTZONA(ByVal inHIZONUFI As Integer, _
                                            ByVal stHIZODEPA As String, _
                                            ByVal stHIZOMUNI As String, _
                                            ByVal stHIZOCORR As String, _
                                            ByVal stHIZOBARR As String, _
                                            ByVal stHIZOMANZ As String, _
                                            ByVal stHIZOPRED As String, _
                                            ByVal stHIZOEDIF As String, _
                                            ByVal stHIZOUNPR As String, _
                                            ByVal inHIZOTIFI As Integer, _
                                            ByVal inHIZOCLSE As Integer, _
                                            ByVal inHIZOVIGE As Integer, _
                                            ByVal inHIZOZOEC As Integer, _
                                            ByVal inHIZOPORC As Integer, _
                                            ByVal stHIZOESTA As String) As Boolean

        Try

            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "INSERT INTO "
            stConsultaSQL += "HISTZONA "

            stConsultaSQL += "( "
            stConsultaSQL += "HIZONUFI, "
            stConsultaSQL += "HIZODEPA, "
            stConsultaSQL += "HIZOMUNI, "
            stConsultaSQL += "HIZOCORR, "
            stConsultaSQL += "HIZOBARR, "
            stConsultaSQL += "HIZOMANZ, "
            stConsultaSQL += "HIZOPRED, "
            stConsultaSQL += "HIZOEDIF, "
            stConsultaSQL += "HIZOUNPR, "
            stConsultaSQL += "HIZOTIFI, "
            stConsultaSQL += "HIZOCLSE, "
            stConsultaSQL += "HIZOVIGE, "
            stConsultaSQL += "HIZOZOEC, "
            stConsultaSQL += "HIZOPORC, "
            stConsultaSQL += "HIZOESTA "
            stConsultaSQL += ") "

            stConsultaSQL += "VALUES "

            stConsultaSQL += "( "
            stConsultaSQL += "'" & CInt(inHIZONUFI) & "', "
            stConsultaSQL += "'" & CStr(Trim(stHIZODEPA)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stHIZOMUNI)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stHIZOCORR)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stHIZOBARR)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stHIZOMANZ)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stHIZOPRED)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stHIZOEDIF)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stHIZOUNPR)) & "', "
            stConsultaSQL += "'" & CInt(inHIZOTIFI) & "', "
            stConsultaSQL += "'" & CInt(inHIZOCLSE) & "', "
            stConsultaSQL += "'" & CInt(inHIZOVIGE) & "', "
            stConsultaSQL += "'" & CInt(inHIZOZOEC) & "', "
            stConsultaSQL += "'" & CInt(inHIZOPORC) & "', "
            stConsultaSQL += "'" & CStr(Trim(stHIZOESTA)) & "' "
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
            MessageBox.Show(Err.Description & " " & "fun_Insertar_HISTZONA")
        End Try

    End Function

    ''' <summary>
    ''' Función que Elimina el registro.
    ''' </summary>
    Public Function fun_Eliminar_HISTZONA(ByVal inHIZOIDRE As Integer) As Boolean

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "DELETE "
            stConsultaSQL += "HISTZONA "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "HIZOIDRE = '" & CInt(inHIZOIDRE) & "' "

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
            MessageBox.Show(Err.Description & " " & "fun_Eliminar_HISTZONA")
        End Try

    End Function

    ''' <summary>
    ''' Función que Elimina el registro con el numero de ficha.
    ''' </summary>
    Public Function fun_Eliminar_NUFI_X_HISTZONA(ByVal inHIZONUFI As Integer) As Boolean

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "DELETE "
            stConsultaSQL += "HISTZONA "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "HIZONUFI = '" & CInt(inHIZONUFI) & "' "

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
            MessageBox.Show(Err.Description & " " & "fun_Eliminar_HISTZONA")
        End Try

    End Function

    ''' <summary>
    ''' Función que Elimina el registro con el numero de ficha.
    ''' </summary>
    Public Function fun_Eliminar_NUFI_CLSE_VIGE_X_HISTZONA(ByVal inHIZONUFI As Integer, ByVal inHIZOCLSE As Integer, ByVal inHIZOVIGE As Integer) As Boolean

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "DELETE "
            stConsultaSQL += "HISTZONA "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "HIZONUFI = '" & CInt(inHIZONUFI) & "' and "
            stConsultaSQL += "HIZOCLSE = '" & CInt(inHIZOCLSE) & "' and "
            stConsultaSQL += "HIZOVIGE = '" & CInt(inHIZOVIGE) & "' "

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
            MessageBox.Show(Err.Description & " " & "fun_Eliminar_HISTZONA")
        End Try

    End Function

    ''' <summary>
    ''' Función que Elimina el registro con el numero de ficha.
    ''' </summary>
    Public Function fun_Eliminar_CEDULA_CATASTRAL_VIGE_CLSE_TIFI_X_HISTZONA(ByVal stHIZOMUNI As String, _
                                                                            ByVal stHIZOCORR As String, _
                                                                            ByVal stHIZOBARR As String, _
                                                                            ByVal stHIZOMANZ As String, _
                                                                            ByVal stHIZOPRED As String, _
                                                                            ByVal stHIZOEDIF As String, _
                                                                            ByVal stHIZOUNPR As String, _
                                                                            ByVal inHIZOTIFI As Integer, _
                                                                            ByVal inHIZOCLSE As Integer, _
                                                                            ByVal inHIZOVIGE As Integer) As Boolean

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "DELETE "
            stConsultaSQL += "HISTZONA "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "HIZOMUNI = '" & CStr(Trim(stHIZOMUNI)) & "' and "
            stConsultaSQL += "HIZOCORR = '" & CStr(Trim(stHIZOCORR)) & "' and "
            stConsultaSQL += "HIZOBARR = '" & CStr(Trim(stHIZOBARR)) & "' and "
            stConsultaSQL += "HIZOMANZ = '" & CStr(Trim(stHIZOMANZ)) & "' and "
            stConsultaSQL += "HIZOPRED = '" & CStr(Trim(stHIZOPRED)) & "' and "
            stConsultaSQL += "HIZOEDIF = '" & CStr(Trim(stHIZOEDIF)) & "' and "
            stConsultaSQL += "HIZOUNPR = '" & CStr(Trim(stHIZOUNPR)) & "' and "
            stConsultaSQL += "HIZOTIFI = '" & CInt(inHIZOTIFI) & "' and "
            stConsultaSQL += "HIZOCLSE = '" & CInt(inHIZOCLSE) & "' and "
            stConsultaSQL += "HIZOVIGE = '" & CInt(inHIZOVIGE) & "' "

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
            MessageBox.Show(Err.Description & " " & "fun_Eliminar_HISTZONA")
        End Try

    End Function

    ''' <summary>
    ''' elimina por el numero de la ficha predial
    ''' </summary>
    Public Function fun_Eliminar_NUFI_DEPA_MUNI_CLSE_VIGE_ZONA_X_HISTZONA(ByVal inHIZONUFI As Integer, _
                                                                          ByVal stHIZODEPA As String, _
                                                                          ByVal stHIZOMUNI As String, _
                                                                          ByVal inHIZOCLSE As Integer, _
                                                                          ByVal inHIZOVIGE As Integer, _
                                                                          ByVal inHIZOZOEC As Integer) As Boolean

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "DELETE "
            stConsultaSQL += "HISTZONA "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "HIZONUFI = '" & CInt(inHIZONUFI) & "' and "
            stConsultaSQL += "HIZODEPA = '" & CStr(Trim(stHIZODEPA)) & "' and "
            stConsultaSQL += "HIZOMUNI = '" & CStr(Trim(stHIZOMUNI)) & "' and "
            stConsultaSQL += "HIZOCLSE = '" & CInt(inHIZOCLSE) & "' and "
            stConsultaSQL += "HIZOVIGE = '" & CInt(inHIZOVIGE) & "' and "
            stConsultaSQL += "HIZOZOEC = '" & CInt(inHIZOZOEC) & "' "

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
            MessageBox.Show(Err.Description & " " & "fun_Eliminar_HISTZONA")
        End Try

    End Function

    ''' <summary>
    ''' Función que Modifica el registro.
    ''' </summary>
    Public Function fun_Actualizar_HISTZONA(ByVal inHIZOIDRE As Integer, _
                                            ByVal inHIZONUFI As Integer, _
                                            ByVal stHIZODEPA As String, _
                                            ByVal stHIZOMUNI As String, _
                                            ByVal stHIZOCORR As String, _
                                            ByVal stHIZOBARR As String, _
                                            ByVal stHIZOMANZ As String, _
                                            ByVal stHIZOPRED As String, _
                                            ByVal stHIZOEDIF As String, _
                                            ByVal stHIZOUNPR As String, _
                                            ByVal inHIZOTIFI As Integer, _
                                            ByVal inHIZOCLSE As Integer, _
                                            ByVal inHIZOVIGE As Integer, _
                                            ByVal inHIZOZOEC As Integer, _
                                            ByVal inHIZOPORC As Integer, _
                                            ByVal stHIZOESTA As String) As Boolean

        Try

            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "UPDATE "
            stConsultaSQL += "HISTZONA "

            stConsultaSQL += "SET "
            stConsultaSQL += "HIZONUFI = '" & CInt(inHIZONUFI) & "', "
            stConsultaSQL += "HIZODEPA = '" & CStr(Trim(stHIZODEPA)) & "', "
            stConsultaSQL += "HIZOMUNI = '" & CStr(Trim(stHIZOMUNI)) & "', "
            stConsultaSQL += "HIZOCORR = '" & CStr(Trim(stHIZOCORR)) & "', "
            stConsultaSQL += "HIZOBARR = '" & CStr(Trim(stHIZOBARR)) & "', "
            stConsultaSQL += "HIZOMANZ = '" & CStr(Trim(stHIZOMANZ)) & "', "
            stConsultaSQL += "HIZOPRED = '" & CStr(Trim(stHIZOPRED)) & "', "
            stConsultaSQL += "HIZOEDIF = '" & CStr(Trim(stHIZOEDIF)) & "', "
            stConsultaSQL += "HIZOUNPR = '" & CStr(Trim(stHIZOUNPR)) & "', "
            stConsultaSQL += "HIZOTIFI = '" & CInt(inHIZOTIFI) & "', "
            stConsultaSQL += "HIZOCLSE = '" & CInt(inHIZOCLSE) & "', "
            stConsultaSQL += "HIZOVIGE = '" & CInt(inHIZOVIGE) & "', "
            stConsultaSQL += "HIZOZOEC = '" & CInt(inHIZOZOEC) & "', "
            stConsultaSQL += "HIZOPORC = '" & CInt(inHIZOPORC) & "', "
            stConsultaSQL += "HIZOESTA = '" & CStr(Trim(stHIZOESTA)) & "' "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "HIZOIDRE = '" & CInt(inHIZOIDRE) & "'"

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
            MessageBox.Show(Err.Description & " " & "fun_Actualizar_HISTZONA")
        End Try

    End Function

    ''' <summary>
    ''' Función que Modifica el registro.
    ''' </summary>
    Public Function fun_Actualizar_NUFI_DEPA_MUNI_CLSE_VIGE_ZONA_X_HISTZONA(ByVal inHIZONUFI As Integer, _
                                                        ByVal stHIZODEPA As String, _
                                                        ByVal stHIZOMUNI As String, _
                                                        ByVal inHIZOCLSE As Integer, _
                                                        ByVal inHIZOVIGE As Integer, _
                                                        ByVal inHIZOZOEC As Integer, _
                                                        ByVal inHIZOPORC As Integer, _
                                                        ByVal stHIZOESTA As String) As Boolean

        Try

            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "UPDATE "
            stConsultaSQL += "HISTZONA "

            stConsultaSQL += "SET "
            stConsultaSQL += "HIZONUFI = '" & CInt(inHIZONUFI) & "', "
            stConsultaSQL += "HIZODEPA = '" & CStr(Trim(stHIZODEPA)) & "', "
            stConsultaSQL += "HIZOMUNI = '" & CStr(Trim(stHIZOMUNI)) & "', "
            stConsultaSQL += "HIZOCLSE = '" & CInt(inHIZOCLSE) & "', "
            stConsultaSQL += "HIZOVIGE = '" & CInt(inHIZOVIGE) & "', "
            stConsultaSQL += "HIZOZOEC = '" & CInt(inHIZOZOEC) & "', "
            stConsultaSQL += "HIZOPORC = '" & CInt(inHIZOPORC) & "', "
            stConsultaSQL += "HIZOESTA = '" & CStr(Trim(stHIZOESTA)) & "' "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "HIZONUFI = '" & CInt(inHIZONUFI) & "' and "
            stConsultaSQL += "HIZODEPA = '" & CStr(Trim(stHIZODEPA)) & "' and "
            stConsultaSQL += "HIZOMUNI = '" & CStr(Trim(stHIZOMUNI)) & "' and "
            stConsultaSQL += "HIZOCLSE = '" & CInt(inHIZOCLSE) & "' and "
            stConsultaSQL += "HIZOVIGE = '" & CInt(inHIZOVIGE) & "' and "
            stConsultaSQL += "HIZOZOEC = '" & CInt(inHIZOZOEC) & "' "

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
            MessageBox.Show(Err.Description & " " & "fun_Actualizar_HISTZONA")
        End Try

    End Function

    ''' <summary>
    ''' Consulta para llenar el DataGridView y colocar el nombre del encabezado
    ''' de la columna. 
    ''' </summary>
    Public Function fun_Consultar_HISTZONA() As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "HIZOIDRE, "
            stConsultaSQL += "HIZONUFI, "
            stConsultaSQL += "HIZODEPA, "
            stConsultaSQL += "HIZOMUNI, "
            stConsultaSQL += "HIZOCORR, "
            stConsultaSQL += "HIZOBARR, "
            stConsultaSQL += "HIZOMANZ, "
            stConsultaSQL += "HIZOPRED, "
            stConsultaSQL += "HIZOEDIF, "
            stConsultaSQL += "HIZOUNPR, "
            stConsultaSQL += "HIZOTIFI, "
            stConsultaSQL += "HIZOCLSE, "
            stConsultaSQL += "HIZOVIGE, "
            stConsultaSQL += "HIZOZOEC, "
            stConsultaSQL += "HIZOPORC, "
            stConsultaSQL += "HIZOESTA "

            stConsultaSQL += "FROM "
            stConsultaSQL += "HISTZONA "

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "HIZODEPA, HIZOMUNI, HIZOCLSE, HIZOVIGE, HIZOZOEC "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Consultar_HISTZONA")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Llena el ComboBox con datos activos e inactivos formulario principal 
    ''' esta funcion se llama desde el procedimiento "pro_inicializarControles()".
    ''' </summary>
    Public Function fun_Consultar_CAMPOS_HISTZONA() As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "HISTZONA "

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "HIZODEPA, HIZOMUNI, HIZOCLSE, HIZOVIGE, HIZOZOEC "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Consultar_CAMPOS_HISTZONA")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Llena el ComboBox con datos activos formulario insertar y modificar 
    ''' esta funcion se llama desde el procedimiento "pro_inicializarControles()".
    ''' </summary>
    Public Function fun_Consultar_HISTZONA_X_ESTADO() As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "HISTZONA "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "HIZOESTA = 'ac' "

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "HIZODEPA, HIZOMUNI, HIZOCLSE, HIZOVIGE, HIZOZOEC "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Consultar_HISTZONA_X_ESTADO")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que busca el ID del registro a modificar o eliminar.
    ''' </summary>
    Public Function fun_Buscar_ID_HISTZONA(ByVal inHIZOIDRE As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "HISTZONA "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "HIZOIDRE = '" & CInt(inHIZOIDRE) & "'"

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Buscar_ID_HISTZONA")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que busca el CÓDIGO para que no se 
    ''' guarden registros duplicados.
    ''' </summary>
    Public Function fun_Buscar_CODIGO_NUFI_DEPA_MUNI_CLSE_VIGE_ZONA_X_HISTZONA(ByVal inHIZONUFI As Integer, _
                                                                               ByVal stHIZODEPA As String, _
                                                                               ByVal stHIZOMUNI As String, _
                                                                               ByVal inHIZOCLSE As Integer, _
                                                                               ByVal inHIZOVIGE As Integer, _
                                                                               ByVal inHIZOZOEC As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "HISTZONA "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "HIZONUFI = '" & CInt(inHIZONUFI) & "' and "
            stConsultaSQL += "HIZODEPA = '" & CStr(Trim(stHIZODEPA)) & "' and "
            stConsultaSQL += "HIZOMUNI = '" & CStr(Trim(stHIZOMUNI)) & "' and "
            stConsultaSQL += "HIZOCLSE = '" & CInt(inHIZOCLSE) & "' and "
            stConsultaSQL += "HIZOVIGE = '" & CInt(inHIZOVIGE) & "' and "
            stConsultaSQL += "HIZOZOEC = '" & CInt(inHIZOZOEC) & "' "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Buscar_CODIGO_HISTZONA")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que busca el ID del codigo buscado para ejecutar la consulta
    ''' parametrizada.
    ''' </summary>
    Public Function fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_HISTZONA(ByVal inHIZOIDRE As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "HIZOIDRE, "
            stConsultaSQL += "HIZONUFI, "
            stConsultaSQL += "HIZODEPA, "
            stConsultaSQL += "HIZOMUNI, "
            stConsultaSQL += "HIZOCORR, "
            stConsultaSQL += "HIZOBARR, "
            stConsultaSQL += "HIZOMANZ, "
            stConsultaSQL += "HIZOPRED, "
            stConsultaSQL += "HIZOEDIF, "
            stConsultaSQL += "HIZOUNPR, "
            stConsultaSQL += "HIZOTIFI, "
            stConsultaSQL += "HIZOCLSE, "
            stConsultaSQL += "HIZOVIGE, "
            stConsultaSQL += "HIZOZOEC, "
            stConsultaSQL += "HIZOPORC, "
            stConsultaSQL += "HIZOESTA "


            stConsultaSQL += "FROM "
            stConsultaSQL += "HISTZONA "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "HIZOIDRE = '" & CInt(inHIZOIDRE) & "'"

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "HIZODEPA, HIZOMUNI, HIZOCLSE, HIZOVIGE, HIZOZOEC "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception

            MessageBox.Show(Err.Description & " " & "fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_HISTZONA")
            Return Nothing

        End Try

    End Function

    ''' <summary>
    ''' Función que busca el Nro ficha y vigencia del codigo buscado para ejecutar la consulta
    ''' parametrizada.
    ''' </summary>
    Public Function fun_Consultar_NUFI_VIGE_X_HISTZONA(ByVal inHIZONUFI As Integer, ByVal inHIZOVIGE As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "HISTZONA "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "HIZONUFI = '" & CInt(inHIZONUFI) & "' and "
            stConsultaSQL += "HIZOVIGE = '" & CInt(inHIZOVIGE) & "' "

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "HIZODEPA, HIZOMUNI, HIZOCLSE, HIZOVIGE, HIZOZOEC "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception

            MessageBox.Show(Err.Description & " " & "fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_HISTZONA")
            Return Nothing

        End Try

    End Function

    ''' <summary>
    ''' Función que busca el Nro ficha y vigencia del codigo buscado para ejecutar la consulta
    ''' parametrizada.
    ''' </summary>
    Public Function fun_Consultar_NUFI_VIGE_CLSE_TIFI_X_HISTZONA(ByVal inHIZONUFI As Integer, _
                                                                 ByVal inHIZOVIGE As Integer, _
                                                                 ByVal inHIZOCLSE As Integer, _
                                                                 ByVal inHIZOTIFI As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "HISTZONA "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "HIZONUFI = '" & CInt(inHIZONUFI) & "' and "
            stConsultaSQL += "HIZOVIGE = '" & CInt(inHIZOVIGE) & "' and "
            stConsultaSQL += "HIZOCLSE = '" & CInt(inHIZOCLSE) & "' and "
            stConsultaSQL += "HIZOTIFI = '" & CInt(inHIZOTIFI) & "' "

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "HIZODEPA, HIZOMUNI, HIZOCLSE, HIZOVIGE, HIZOZOEC "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception

            MessageBox.Show(Err.Description & " " & "fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_HISTZONA")
            Return Nothing

        End Try

    End Function

    ''' <summary>
    ''' Función que Elimina el registro de ficha resumen con la cedula catastral 
    ''' </summary>
    Public Function fun_Eliminar_ZONAS_FICHA_X_HISTZONA(ByVal stHIZODEPA As String, _
                                                                ByVal stHIZOMUNI As String, _
                                                                ByVal stHIZOCORR As String, _
                                                                ByVal stHIZOBARR As String, _
                                                                ByVal stHIZOMANZ As String, _
                                                                ByVal stHIZOPRED As String, _
                                                                ByVal stHIZOEDIF As String, _
                                                                ByVal stHIZOUNPR As String, _
                                                                ByVal inHIZOCLSE As Integer, _
                                                                ByVal inHIZOVIGE As Integer, _
                                                                ByVal inHIZOTIFI As Integer) As Boolean

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "DELETE "
            stConsultaSQL += "HISTZONA "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "HIZODEPA = '" & CStr(Trim(stHIZODEPA)) & "' and "
            stConsultaSQL += "HIZOMUNI = '" & CStr(Trim(stHIZOMUNI)) & "' and "
            stConsultaSQL += "HIZOCORR = '" & CStr(Trim(stHIZOCORR)) & "' and "
            stConsultaSQL += "HIZOBARR = '" & CStr(Trim(stHIZOBARR)) & "' and "
            stConsultaSQL += "HIZOMANZ = '" & CStr(Trim(stHIZOMANZ)) & "' and "
            stConsultaSQL += "HIZOPRED = '" & CStr(Trim(stHIZOPRED)) & "' and "
            stConsultaSQL += "HIZOEDIF = '" & CStr(Trim(stHIZOEDIF)) & "' and "
            stConsultaSQL += "HIZOUNPR = '" & CStr(Trim(stHIZOUNPR)) & "' and "
            stConsultaSQL += "HIZOCLSE = '" & CInt(inHIZOCLSE) & "' and "
            stConsultaSQL += "HIZOVIGE = '" & CInt(inHIZOVIGE) & "' and "
            stConsultaSQL += "HIZOTIFI = '" & CInt(inHIZOTIFI) & "' "

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
            MessageBox.Show(Err.Description & " " & "fun_Eliminar_HISTZONA")
        End Try

    End Function

    ''' <summary>
    ''' Función que consulta por cedula catastral 
    ''' </summary>
    Public Function fun_Consultar_CEDULA_CATASTRAL_X_HISTZONA(ByVal stHIZODEPA As String, _
                                                                ByVal stHIZOMUNI As String, _
                                                                ByVal stHIZOCORR As String, _
                                                                ByVal stHIZOBARR As String, _
                                                                ByVal stHIZOMANZ As String, _
                                                                ByVal stHIZOPRED As String, _
                                                                ByVal stHIZOEDIF As String, _
                                                                ByVal stHIZOUNPR As String, _
                                                                ByVal inHIZOCLSE As Integer, _
                                                                ByVal inHIZOVIGE As Integer, _
                                                                ByVal inHIZOTIFI As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "HISTZONA "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "HIZODEPA = '" & CStr(Trim(stHIZODEPA)) & "' and "
            stConsultaSQL += "HIZOMUNI = '" & CStr(Trim(stHIZOMUNI)) & "' and "
            stConsultaSQL += "HIZOCORR = '" & CStr(Trim(stHIZOCORR)) & "' and "
            stConsultaSQL += "HIZOBARR = '" & CStr(Trim(stHIZOBARR)) & "' and "
            stConsultaSQL += "HIZOMANZ = '" & CStr(Trim(stHIZOMANZ)) & "' and "
            stConsultaSQL += "HIZOPRED = '" & CStr(Trim(stHIZOPRED)) & "' and "
            stConsultaSQL += "HIZOEDIF = '" & CStr(Trim(stHIZOEDIF)) & "' and "
            stConsultaSQL += "HIZOUNPR = '" & CStr(Trim(stHIZOUNPR)) & "' and "
            stConsultaSQL += "HIZOCLSE = '" & CInt(inHIZOCLSE) & "' and "
            stConsultaSQL += "HIZOVIGE = '" & CInt(inHIZOVIGE) & "' and "
            stConsultaSQL += "HIZOTIFI = '" & CInt(inHIZOTIFI) & "' "

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "HIZODEPA, HIZOMUNI, HIZOCLSE, HIZOVIGE, HIZOZOEC "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception

            MessageBox.Show(Err.Description & " " & "fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_HISTZONA")
            Return Nothing

        End Try

    End Function

    ''' <summary>
    ''' Función que consulta por cedula catastral 
    ''' </summary>
    Public Function fun_Consultar_CEDULA_CATASTRAL_X_HISTZONA(ByVal stHIZODEPA As String, _
                                                                ByVal stHIZOMUNI As String, _
                                                                ByVal stHIZOCORR As String, _
                                                                ByVal stHIZOBARR As String, _
                                                                ByVal stHIZOMANZ As String, _
                                                                ByVal stHIZOPRED As String, _
                                                                ByVal stHIZOEDIF As String, _
                                                                ByVal stHIZOUNPR As String, _
                                                                ByVal inHIZOCLSE As Integer, _
                                                                ByVal inHIZOTIFI As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "HISTZONA "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "HIZODEPA = '" & CStr(Trim(stHIZODEPA)) & "' and "
            stConsultaSQL += "HIZOMUNI = '" & CStr(Trim(stHIZOMUNI)) & "' and "
            stConsultaSQL += "HIZOCORR = '" & CStr(Trim(stHIZOCORR)) & "' and "
            stConsultaSQL += "HIZOBARR = '" & CStr(Trim(stHIZOBARR)) & "' and "
            stConsultaSQL += "HIZOMANZ = '" & CStr(Trim(stHIZOMANZ)) & "' and "
            stConsultaSQL += "HIZOPRED = '" & CStr(Trim(stHIZOPRED)) & "' and "
            stConsultaSQL += "HIZOEDIF = '" & CStr(Trim(stHIZOEDIF)) & "' and "
            stConsultaSQL += "HIZOUNPR = '" & CStr(Trim(stHIZOUNPR)) & "' and "
            stConsultaSQL += "HIZOCLSE = '" & CInt(inHIZOCLSE) & "' and "
            stConsultaSQL += "HIZOTIFI = '" & CInt(inHIZOTIFI) & "' "

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "HIZOVIGE DESC, HIZODEPA, HIZOMUNI, HIZOCLSE, HIZOZOEC "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception

            MessageBox.Show(Err.Description & " " & "fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_HISTZONA")
            Return Nothing

        End Try

    End Function

End Class
