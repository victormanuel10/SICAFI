Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration
Imports DATOS

Public Class cla_TARIZOFI

    '================================
    '*** CLASE TARIFA ZONA FISICA ***
    '================================

    ''' <summary>
    ''' procedimiento que verifica la llave primaria.
    ''' </summary>
    Public Function fun_Verifica_llave_Primaria_TARIZOFI(ByVal obTAZFDEPA As Object, _
                                                         ByVal obTAZFMUNI As Object, _
                                                         ByVal obTAZFCLSE As Object, _
                                                         ByVal obTAZFVIGE As Object, _
                                                         ByVal obTAZFZOFI As Object) As Boolean

        Try
            Dim boRespuesta As Boolean = False

            Dim obVerifica As New cla_Verificar_Dato

            If obVerifica.fun_Verificar_Campo_Lleno(obTAZFDEPA.SelectedValue) = True And _
               obVerifica.fun_Verificar_Campo_Lleno(obTAZFMUNI.SelectedValue) = True And _
               obVerifica.fun_Verificar_Campo_Lleno(obTAZFCLSE.SelectedValue) = True And _
               obVerifica.fun_Verificar_Campo_Lleno(obTAZFVIGE.SelectedValue) = True And _
               obVerifica.fun_Verificar_Campo_Lleno(obTAZFZOFI.SelectedValue) = True Then

                If obVerifica.fun_Verificar_Dato_Numerico(obTAZFDEPA.SelectedValue) = True And _
                   obVerifica.fun_Verificar_Dato_Numerico(obTAZFMUNI.SelectedValue) = True And _
                   obVerifica.fun_Verificar_Dato_Numerico(obTAZFCLSE.SelectedValue) = True And _
                   obVerifica.fun_Verificar_Dato_Numerico(obTAZFVIGE.SelectedValue) = True And _
                   obVerifica.fun_Verificar_Dato_Numerico(obTAZFZOFI.SelectedValue) = True Then

                    Dim objdatos1 As New cla_TARIZOFI
                    Dim tbl As New DataTable

                    tbl = objdatos1.fun_Buscar_CODIGO_DEPA_MUNI_CLSE_VIGE_ZOEC_X_TARIZOFI(obTAZFDEPA.SelectedValue, _
                                                                                          obTAZFMUNI.SelectedValue, _
                                                                                          obTAZFCLSE.SelectedValue, _
                                                                                          obTAZFVIGE.SelectedValue, _
                                                                                          obTAZFZOFI.SelectedValue)

                    If tbl.Rows.Count > 0 Then
                        MessageBox.Show("El dato " & Trim(obTAZFDEPA.Text) & " - " & _
                                                     Trim(obTAZFMUNI.Text) & " - " & _
                                                     Trim(obTAZFCLSE.Text) & " - " & _
                                                     Trim(obTAZFVIGE.Text) & " - " & _
                                                     Trim(obTAZFZOFI.Text) & " - " & " existe en la base de datos.", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                        obTAZFDEPA.Focus()
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
    Public Function fun_Insertar_TARIZOFI(ByVal stTAZFDEPA As String, _
                                          ByVal stTAZFMUNI As String, _
                                          ByVal inTAZFCLSE As Integer, _
                                          ByVal inTAZFZOFI As Integer, _
                                          ByVal stTAZFTA01 As String, _
                                          ByVal stTAZFTA02 As String, _
                                          ByVal stTAZFTA03 As String, _
                                          ByVal stTAZFTA04 As String, _
                                          ByVal stTAZFTA05 As String, _
                                          ByVal stTAZFTA06 As String, _
                                          ByVal inTAZFZOAP As Integer, _
                                          ByVal stTAZFESTA As String, _
                                          ByVal inTAZFVIGE As Integer, _
                                          ByVal stTAZFSIGN As String, _
                                          ByVal stTAZFPORC As String, _
                                          ByVal stTAZFTALO As String) As Boolean

        Try

            ' variables del sistema
            Dim stTAZFMAQU As String = fun_Nombre_de_maquina()
            Dim stTAZFUSIN As String = vp_usuario
            Dim stTAZFUSMO As String = ""

            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "INSERT INTO "
            stConsultaSQL += "TARIZOFI "

            stConsultaSQL += "( "
            stConsultaSQL += "TAZFDEPA, "
            stConsultaSQL += "TAZFMUNI, "
            stConsultaSQL += "TAZFCLSE, "
            stConsultaSQL += "TAZFZOFI, "
            stConsultaSQL += "TAZFTA01, "
            stConsultaSQL += "TAZFTA02, "
            stConsultaSQL += "TAZFTA03, "
            stConsultaSQL += "TAZFTA04, "
            stConsultaSQL += "TAZFTA05, "
            stConsultaSQL += "TAZFTA06, "
            stConsultaSQL += "TAZFZOAP, "
            stConsultaSQL += "TAZFESTA, "
            stConsultaSQL += "TAZFVIGE, "
            stConsultaSQL += "TAZFUSIN, "
            stConsultaSQL += "TAZFUSMO, "
            stConsultaSQL += "TAZFMAQU, "
            stConsultaSQL += "TAZFSIGN, "
            stConsultaSQL += "TAZFPORC, "
            stConsultaSQL += "TAZFTALO  "
            stConsultaSQL += ") "

            stConsultaSQL += "VALUES "

            stConsultaSQL += "( "
            stConsultaSQL += "'" & CStr(Trim(stTAZFDEPA)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stTAZFMUNI)) & "', "
            stConsultaSQL += "'" & CInt(inTAZFCLSE) & "', "
            stConsultaSQL += "'" & CInt(inTAZFZOFI) & "', "
            stConsultaSQL += "'" & CStr(Trim(stTAZFTA01)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stTAZFTA02)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stTAZFTA03)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stTAZFTA04)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stTAZFTA05)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stTAZFTA06)) & "', "
            stConsultaSQL += "'" & CInt(inTAZFZOAP) & "', "
            stConsultaSQL += "'" & CStr(Trim(stTAZFESTA)) & "', "
            stConsultaSQL += "'" & CInt(inTAZFVIGE) & "', "
            stConsultaSQL += "'" & CStr(Trim(stTAZFUSIN)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stTAZFUSMO)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stTAZFMAQU)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stTAZFSIGN)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stTAZFPORC)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stTAZFTALO)) & "' "
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
            MessageBox.Show(Err.Description & " " & "fun_Insertar_TARIZOFI")
        End Try

    End Function

    ''' <summary>
    ''' Función que Elimina el registro.
    ''' </summary>
    Public Function fun_Eliminar_TARIZOFI(ByVal inTAZFIDRE As Integer) As Boolean

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "DELETE "
            stConsultaSQL += "TARIZOFI "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "TAZFIDRE = '" & CInt(inTAZFIDRE) & "' "

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
            MessageBox.Show(Err.Description & " " & "fun_Eliminar_TARIZOFI")
        End Try

    End Function

    ''' <summary>
    ''' Función que Modifica el registro.
    ''' </summary>
    Public Function fun_Actualizar_TARIZOFI(ByVal inTAZFIDRE As Integer, _
                                            ByVal stTAZFDEPA As String, _
                                            ByVal stTAZFMUNI As String, _
                                            ByVal inTAZFCLSE As Integer, _
                                            ByVal inTAZFZOFI As Integer, _
                                            ByVal stTAZFTA01 As String, _
                                            ByVal stTAZFTA02 As String, _
                                            ByVal stTAZFTA03 As String, _
                                            ByVal stTAZFTA04 As String, _
                                            ByVal stTAZFTA05 As String, _
                                            ByVal stTAZFTA06 As String, _
                                            ByVal inTAZFZOAP As Integer, _
                                            ByVal stTAZFESTA As String, _
                                            ByVal inTAZFVIGE As Integer, _
                                            ByVal stTAZFSIGN As String, _
                                            ByVal stTAZFPORC As String, _
                                            ByVal stTAZFTALO As String) As Boolean

        Try
            ' variables del sistema
            Dim stTAZFMAQU As String = fun_Nombre_de_maquina()
            Dim stTAZFUSIN As String = vp_usuario
            Dim stTAZFUSMO As String = vp_usuario

            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "UPDATE "
            stConsultaSQL += "TARIZOFI "

            stConsultaSQL += "SET "
            stConsultaSQL += "TAZFDEPA = '" & CStr(Trim(stTAZFDEPA)) & "', "
            stConsultaSQL += "TAZFMUNI = '" & CStr(Trim(stTAZFMUNI)) & "', "
            stConsultaSQL += "TAZFCLSE = '" & CInt(inTAZFCLSE) & "', "
            stConsultaSQL += "TAZFZOFI = '" & CInt(inTAZFZOFI) & "', "
            stConsultaSQL += "TAZFTA01 = '" & CStr(Trim(stTAZFTA01)) & "', "
            stConsultaSQL += "TAZFTA02 = '" & CStr(Trim(stTAZFTA02)) & "', "
            stConsultaSQL += "TAZFTA03 = '" & CStr(Trim(stTAZFTA03)) & "', "
            stConsultaSQL += "TAZFTA04 = '" & CStr(Trim(stTAZFTA04)) & "', "
            stConsultaSQL += "TAZFTA05 = '" & CStr(Trim(stTAZFTA05)) & "', "
            stConsultaSQL += "TAZFTA06 = '" & CStr(Trim(stTAZFTA06)) & "', "
            stConsultaSQL += "TAZFZOAP = '" & CInt(inTAZFZOAP) & "', "
            stConsultaSQL += "TAZFESTA = '" & CStr(Trim(stTAZFESTA)) & "', "
            stConsultaSQL += "TAZFVIGE = '" & CInt(inTAZFVIGE) & "', "
            stConsultaSQL += "TAZFUSIN = '" & CStr(Trim(stTAZFUSIN)) & "', "
            stConsultaSQL += "TAZFUSMO = '" & CStr(Trim(stTAZFUSMO)) & "', "
            stConsultaSQL += "TAZFMAQU = '" & CStr(Trim(stTAZFMAQU)) & "', "
            stConsultaSQL += "TAZFSIGN = '" & CStr(Trim(stTAZFSIGN)) & "', "
            stConsultaSQL += "TAZFPORC = '" & CStr(Trim(stTAZFPORC)) & "', "
            stConsultaSQL += "TAZFTALO = '" & CStr(Trim(stTAZFTALO)) & "' "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "TAZFIDRE = '" & CInt(inTAZFIDRE) & "'"

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
            MessageBox.Show(Err.Description & " " & "fun_Actualizar_TARIZOFI")
        End Try

    End Function

    ''' <summary>
    ''' Consulta para llenar el DataGridView y colocar el nombre del encabezado
    ''' de la columna. 
    ''' </summary>
    Public Function fun_Consultar_TARIZOFI() As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "TAZFIDRE, "
            stConsultaSQL += "TAZFDEPA, "
            stConsultaSQL += "TAZFMUNI, "
            stConsultaSQL += "TAZFCLSE, "
            stConsultaSQL += "TAZFVIGE, "
            stConsultaSQL += "TAZFZOFI, "
            stConsultaSQL += "TAZFTA01, "
            stConsultaSQL += "TAZFTA02, "
            stConsultaSQL += "TAZFTA03, "
            stConsultaSQL += "TAZFTA04, "
            stConsultaSQL += "TAZFTA05, "
            stConsultaSQL += "TAZFTA06, "
            stConsultaSQL += "TAZFZOAP, "
            stConsultaSQL += "TAZFESTA, "
            stConsultaSQL += "TAZFSIGN, "
            stConsultaSQL += "TAZFPORC, "
            stConsultaSQL += "TAZFTALO  "

            stConsultaSQL += "FROM "
            stConsultaSQL += "TARIZOFI "

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "TAZFDEPA, TAZFMUNI, TAZFVIGE, TAZFCLSE, TAZFZOFI  "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Consultar_TARIZOFI")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Llena el ComboBox con datos activos e inactivos formulario principal 
    ''' esta funcion se llama desde el procedimiento "pro_inicializarControles()".
    ''' </summary>
    Public Function fun_Consultar_CAMPOS_TARIZOFI() As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "TARIZOFI "

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "TAZFDEPA, TAZFMUNI, TAZFVIGE, TAZFCLSE "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Consultar_CAMPOS_TARIZOFI")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Llena el ComboBox con datos activos formulario insertar y modificar 
    ''' esta funcion se llama desde el procedimiento "pro_inicializarControles()".
    ''' </summary>
    Public Function fun_Consultar_TARIZOFI_X_ESTADO() As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "TARIZOFI "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "TAZFESTA = 'ac' "

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "TAZFDEPA, TAZFMUNI, TAZFVIGE, TAZFCLSE "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Consultar_TARIZOFI_X_ESTADO")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que busca el ID del registro a modificar o eliminar.
    ''' </summary>
    Public Function fun_Buscar_ID_TARIZOFI(ByVal inTAZFIDRE As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "TARIZOFI "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "TAZFIDRE = '" & CInt(inTAZFIDRE) & "'"

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Buscar_ID_TARIZOFI")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que busca el CÓDIGO para que no se 
    ''' guarden registros duplicados.
    ''' </summary>
    Public Function fun_Buscar_CODIGO_DEPA_MUNI_CLSE_VIGE_ZOEC_X_TARIZOFI(ByVal stTAZFDEPA As String, _
                                                                          ByVal stTAZFMUNI As String, _
                                                                          ByVal inTAZFCLSE As Integer, _
                                                                          ByVal inTAZFVIGE As Integer, _
                                                                          ByVal inTAZFZOFI As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "TARIZOFI "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "TAZFDEPA = '" & CStr(Trim(stTAZFDEPA)) & "' and "
            stConsultaSQL += "TAZFMUNI = '" & CStr(Trim(stTAZFMUNI)) & "' and "
            stConsultaSQL += "TAZFCLSE = '" & CInt(inTAZFCLSE) & "' and "
            stConsultaSQL += "TAZFVIGE = '" & CInt(inTAZFVIGE) & "' and "
            stConsultaSQL += "TAZFZOFI = '" & CInt(inTAZFZOFI) & "' "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Buscar_CODIGO_TARIZOFI")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que busca el ID del codigo buscado para ejecutar la consulta
    ''' parametrizada.
    ''' </summary>
    Public Function fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_TARIZOFI(ByVal inTAZFIDRE As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "TAZFIDRE, "
            stConsultaSQL += "TAZFDEPA, "
            stConsultaSQL += "TAZFMUNI, "
            stConsultaSQL += "TAZFCLSE, "
            stConsultaSQL += "TAZFVIGE, "
            stConsultaSQL += "TAZFZOFI, "
            stConsultaSQL += "TAZFTA01, "
            stConsultaSQL += "TAZFTA02, "
            stConsultaSQL += "TAZFTA03, "
            stConsultaSQL += "TAZFTA04, "
            stConsultaSQL += "TAZFTA05, "
            stConsultaSQL += "TAZFTA06, "
            stConsultaSQL += "TAZFZOAP, "
            stConsultaSQL += "TAZFESTA, "
            stConsultaSQL += "TAZFSIGN, "
            stConsultaSQL += "TAZFPORC, "
            stConsultaSQL += "TAZFTALO  "

            stConsultaSQL += "FROM "
            stConsultaSQL += "TARIZOFI "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "TAZFIDRE = '" & CInt(inTAZFIDRE) & "'"

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "TAZFDEPA, TAZFMUNI,TAZFVIGE, TAZFCLSE "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception

            MessageBox.Show(Err.Description & " " & "fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_TARIZOFI")
            Return Nothing

        End Try

    End Function


End Class
