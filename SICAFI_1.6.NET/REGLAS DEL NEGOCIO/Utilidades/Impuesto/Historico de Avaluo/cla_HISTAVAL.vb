Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration
Imports DATOS

Public Class cla_HISTAVAL

    '=================================
    '*** CLASE HISTORICO DE AVALÚO ***
    '=================================

    ''' <summary>
    ''' procedimiento que verifica la llave primaria.
    ''' </summary>
    Public Function fun_Verifica_llave_Primaria_HISTAVAL(ByVal obHIAVNUFI As Object, _
                                                         ByVal obHIAVVIGE As Object) As Boolean

        Try
            Dim boRespuesta As Boolean = False

            Dim obVerifica As New cla_Verificar_Dato

            If obVerifica.fun_Verificar_Campo_Lleno(obHIAVNUFI.Text) = True And _
               obVerifica.fun_Verificar_Campo_Lleno(obHIAVVIGE.SelectedValue) = True Then

                If obVerifica.fun_Verificar_Dato_Numerico(obHIAVNUFI.Text) = True And _
                   obVerifica.fun_Verificar_Dato_Numerico(obHIAVVIGE.SelectedValue) = True Then

                    Dim objdatos1 As New cla_HISTAVAL
                    Dim tbl As New DataTable

                    tbl = objdatos1.fun_Buscar_CODIGO_NUFI_VIGE_X_HISTAVAL(obHIAVNUFI.Text, _
                                                                           obHIAVVIGE.SelectedValue)

                    If tbl.Rows.Count > 0 Then
                        MessageBox.Show("El dato " & Trim(obHIAVNUFI.Text) & " - " & _
                                                     Trim(obHIAVVIGE.Text) & " - " & " existe en la base de datos.", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                        obHIAVNUFI.Focus()
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
    Public Function fun_Insertar_HISTAVAL(ByVal inHIAVNUFI As Integer, _
                                            ByVal inHIAVVIGE As Integer, _
                                            ByVal loHIAVATPR As Long, _
                                            ByVal loHIAVATCO As Long, _
                                            ByVal loHIAVACPR As Long, _
                                            ByVal loHIAVACCO As Long, _
                                            ByVal loHIAVVATP As Long, _
                                            ByVal loHIAVVATC As Long, _
                                            ByVal loHIAVVACP As Long, _
                                            ByVal loHIAVVACC As Long, _
                                            ByVal loHIAVAVAL As Long, _
                                            ByVal stHIAVOBSE As String, _
                                            ByVal stHIAVTIRE As String, _
                                            ByVal stHIAVNURE As String, _
                                            ByVal stHIAVVIRE As String, _
                                            ByVal stHIAVESTA As String) As Boolean

        Try

            ' variables del sistema
            Dim stHIAVUSIN As String = vp_usuario
            Dim stHIAVUSMO As String = ""
            Dim daHIAVFEIN As Date = fun_fecha()
            Dim daHIAVFEMO As Date = fun_fecha()
            Dim stHIAVMAQU As String = fun_Nombre_de_maquina()

            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "INSERT INTO "
            stConsultaSQL += "HISTAVAL "

            stConsultaSQL += "( "
            stConsultaSQL += "HIAVNUFI, "
            stConsultaSQL += "HIAVVIGE, "
            stConsultaSQL += "HIAVATPR, "
            stConsultaSQL += "HIAVATCO, "
            stConsultaSQL += "HIAVACPR, "
            stConsultaSQL += "HIAVACCO, "
            stConsultaSQL += "HIAVVATP, "
            stConsultaSQL += "HIAVVATC, "
            stConsultaSQL += "HIAVVACP, "
            stConsultaSQL += "HIAVVACC, "
            stConsultaSQL += "HIAVAVAL, "
            stConsultaSQL += "HIAVOBSE, "
            stConsultaSQL += "HIAVTIRE, "
            stConsultaSQL += "HIAVNURE, "
            stConsultaSQL += "HIAVVIRE, "
            stConsultaSQL += "HIAVESTA, "
            stConsultaSQL += "HIAVUSIN, "
            stConsultaSQL += "HIAVUSMO, "
            stConsultaSQL += "HIAVFEIN, "
            stConsultaSQL += "HIAVFEMO, "
            stConsultaSQL += "HIAVMAQU  "
            stConsultaSQL += ") "

            stConsultaSQL += "VALUES "

            stConsultaSQL += "( "
            stConsultaSQL += "'" & CInt(inHIAVNUFI) & "', "
            stConsultaSQL += "'" & CInt(inHIAVVIGE) & "', "
            stConsultaSQL += "'" & CLng(loHIAVATPR) & "', "
            stConsultaSQL += "'" & CLng(loHIAVATCO) & "', "
            stConsultaSQL += "'" & CLng(loHIAVACPR) & "', "
            stConsultaSQL += "'" & CLng(loHIAVACCO) & "', "
            stConsultaSQL += "'" & CLng(loHIAVVATP) & "', "
            stConsultaSQL += "'" & CLng(loHIAVVATC) & "', "
            stConsultaSQL += "'" & CLng(loHIAVVACP) & "', "
            stConsultaSQL += "'" & CLng(loHIAVVACC) & "', "
            stConsultaSQL += "'" & CLng(loHIAVAVAL) & "', "
            stConsultaSQL += "'" & CStr(Trim(stHIAVOBSE)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stHIAVTIRE)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stHIAVNURE)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stHIAVVIRE)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stHIAVESTA)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stHIAVUSIN)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stHIAVUSMO)) & "', "
            stConsultaSQL += "'" & CDate(daHIAVFEIN) & "', "
            stConsultaSQL += "'" & CDate(daHIAVFEMO) & "', "
            stConsultaSQL += "'" & CStr(Trim(stHIAVMAQU)) & "' "
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
            MessageBox.Show(Err.Description & " " & "fun_Insertar_HISTAVAL")
        End Try

    End Function

    ''' <summary>
    ''' Función que Elimina el registro.
    ''' </summary>
    Public Function fun_Eliminar_HISTAVAL(ByVal inHIAVIDRE As Integer) As Boolean

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "DELETE "
            stConsultaSQL += "HISTAVAL "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "HIAVIDRE = '" & CInt(inHIAVIDRE) & "' "

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
            MessageBox.Show(Err.Description & " " & "fun_Eliminar_HISTAVAL")
        End Try

    End Function

    ''' <summary>
    ''' elimina por el numero de la ficha predial
    ''' </summary>
    Public Function fun_Eliminar_NUFI_X_HISTAVAL(ByVal inHIAVNUFI As Integer) As Boolean

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "DELETE "
            stConsultaSQL += "HISTAVAL "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "HIAVNUFI = '" & CInt(inHIAVNUFI) & "' "

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
            MessageBox.Show(Err.Description & " " & "fun_Eliminar_HISTAVAL")
        End Try

    End Function

    ''' <summary>
    ''' elimina por el numero de la ficha predial y vigencia
    ''' </summary>
    Public Function fun_Eliminar_NUFI_Y_VIGE_X_HISTAVAL(ByVal inHIAVNUFI As Integer, ByVal inHIAVVIGE As Integer) As Boolean

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "DELETE "
            stConsultaSQL += "HISTAVAL "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "HIAVNUFI = '" & CInt(inHIAVNUFI) & "' and "
            stConsultaSQL += "HIAVVIGE = '" & CInt(inHIAVVIGE) & "'  "

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
            MessageBox.Show(Err.Description & " " & "fun_Eliminar_HISTAVAL")
        End Try

    End Function

    ''' <summary>
    ''' Función que Modifica el registro.
    ''' </summary>
    Public Function fun_Actualizar_HISTAVAL(ByVal inHIAVIDRE As Integer, _
                                            ByVal inHIAVNUFI As Integer, _
                                            ByVal inHIAVVIGE As Integer, _
                                            ByVal loHIAVATPR As Long, _
                                            ByVal loHIAVATCO As Long, _
                                            ByVal loHIAVACPR As Long, _
                                            ByVal loHIAVACCO As Long, _
                                            ByVal loHIAVVATP As Long, _
                                            ByVal loHIAVVATC As Long, _
                                            ByVal loHIAVVACP As Long, _
                                            ByVal loHIAVVACC As Long, _
                                            ByVal loHIAVAVAL As Long, _
                                            ByVal stHIAVOBSE As String, _
                                            ByVal stHIAVTIRE As String, _
                                            ByVal stHIAVNURE As String, _
                                            ByVal stHIAVVIRE As String, _
                                            ByVal stHIAVESTA As String) As Boolean

        Try
            ' variables del sistema
            Dim stHIAVUSMO As String = vp_usuario
            Dim daHIAVFEMO As Date = fun_Hora_y_fecha()
            Dim stHIAVMAQU As String = fun_Nombre_de_maquina()

            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "UPDATE "
            stConsultaSQL += "HISTAVAL "

            stConsultaSQL += "SET "
            stConsultaSQL += "HIAVNUFI = '" & CInt(inHIAVNUFI) & "', "
            stConsultaSQL += "HIAVVIGE = '" & CInt(inHIAVVIGE) & "', "
            stConsultaSQL += "HIAVATPR = '" & CLng(loHIAVATPR) & "', "
            stConsultaSQL += "HIAVATCO = '" & CLng(loHIAVATCO) & "', "
            stConsultaSQL += "HIAVACPR = '" & CLng(loHIAVACPR) & "', "
            stConsultaSQL += "HIAVACCO = '" & CLng(loHIAVACCO) & "', "
            stConsultaSQL += "HIAVVATP = '" & CLng(loHIAVVATP) & "', "
            stConsultaSQL += "HIAVVATC = '" & CLng(loHIAVVATC) & "', "
            stConsultaSQL += "HIAVVACP = '" & CLng(loHIAVVACP) & "', "
            stConsultaSQL += "HIAVVACC = '" & CLng(loHIAVVACC) & "', "
            stConsultaSQL += "HIAVAVAL = '" & CLng(loHIAVAVAL) & "', "
            stConsultaSQL += "HIAVOBSE = '" & CStr(Trim(stHIAVOBSE)) & "', "
            stConsultaSQL += "HIAVTIRE = '" & CStr(Trim(stHIAVTIRE)) & "', "
            stConsultaSQL += "HIAVNURE = '" & CStr(Trim(stHIAVNURE)) & "', "
            stConsultaSQL += "HIAVVIRE = '" & CStr(Trim(stHIAVVIRE)) & "', "
            stConsultaSQL += "HIAVESTA = '" & CStr(Trim(stHIAVESTA)) & "', "
            stConsultaSQL += "HIAVUSMO = '" & CStr(Trim(stHIAVUSMO)) & "', "
            stConsultaSQL += "HIAVFEMO = '" & CDate(daHIAVFEMO) & "', "
            stConsultaSQL += "HIAVMAQU = '" & CStr(Trim(stHIAVMAQU)) & " "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "HIAVIDRE = '" & CInt(inHIAVIDRE) & "'"

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
            MessageBox.Show(Err.Description & " " & "fun_Actualizar_HISTAVAL")
        End Try

    End Function

    ''' <summary>
    ''' Función que Modifica el registro.
    ''' </summary>
    Public Function fun_Actualizar_NUFI_VIGE_X_HISTAVAL(ByVal inHIAVNUFI As Integer, _
                                            ByVal inHIAVVIGE As Integer, _
                                            ByVal loHIAVATPR As Long, _
                                            ByVal loHIAVATCO As Long, _
                                            ByVal loHIAVACPR As Long, _
                                            ByVal loHIAVACCO As Long, _
                                            ByVal loHIAVVATP As Long, _
                                            ByVal loHIAVVATC As Long, _
                                            ByVal loHIAVVACP As Long, _
                                            ByVal loHIAVVACC As Long, _
                                            ByVal loHIAVAVAL As Long, _
                                            ByVal stHIAVOBSE As String, _
                                            ByVal stHIAVTIRE As String, _
                                            ByVal stHIAVNURE As String, _
                                            ByVal stHIAVVIRE As String, _
                                            ByVal stHIAVESTA As String) As Boolean

        Try
            ' variables del sistema
            Dim stHIAVUSMO As String = vp_usuario
            Dim daHIAVFEMO As Date = fun_fecha()
            Dim stHIAVMAQU As String = fun_Nombre_de_maquina()

            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "UPDATE "
            stConsultaSQL += "HISTAVAL "

            stConsultaSQL += "SET "
            stConsultaSQL += "HIAVNUFI = '" & CInt(inHIAVNUFI) & "', "
            stConsultaSQL += "HIAVVIGE = '" & CInt(inHIAVVIGE) & "', "
            stConsultaSQL += "HIAVATPR = '" & CLng(loHIAVATPR) & "', "
            stConsultaSQL += "HIAVATCO = '" & CLng(loHIAVATCO) & "', "
            stConsultaSQL += "HIAVACPR = '" & CLng(loHIAVACPR) & "', "
            stConsultaSQL += "HIAVACCO = '" & CLng(loHIAVACCO) & "', "
            stConsultaSQL += "HIAVVATP = '" & CLng(loHIAVVATP) & "', "
            stConsultaSQL += "HIAVVATC = '" & CLng(loHIAVVATC) & "', "
            stConsultaSQL += "HIAVVACP = '" & CLng(loHIAVVACP) & "', "
            stConsultaSQL += "HIAVVACC = '" & CLng(loHIAVVACC) & "', "
            stConsultaSQL += "HIAVAVAL = '" & CLng(loHIAVAVAL) & "', "
            stConsultaSQL += "HIAVOBSE = '" & CStr(Trim(stHIAVOBSE)) & "', "
            stConsultaSQL += "HIAVTIRE = '" & CStr(Trim(stHIAVTIRE)) & "', "
            stConsultaSQL += "HIAVNURE = '" & CStr(Trim(stHIAVNURE)) & "', "
            stConsultaSQL += "HIAVVIRE = '" & CStr(Trim(stHIAVVIRE)) & "', "
            stConsultaSQL += "HIAVESTA = '" & CStr(Trim(stHIAVESTA)) & "', "
            stConsultaSQL += "HIAVUSMO = '" & CStr(Trim(stHIAVUSMO)) & "', "
            stConsultaSQL += "HIAVFEMO = '" & CDate(daHIAVFEMO) & "', "
            stConsultaSQL += "HIAVMAQU = '" & CStr(Trim(stHIAVMAQU)) & "' "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "HIAVNUFI = '" & CInt(inHIAVNUFI) & "' and "
            stConsultaSQL += "HIAVVIGE = '" & CInt(inHIAVVIGE) & "' "

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
            MessageBox.Show(Err.Description & " " & "fun_Actualizar_HISTAVAL")
        End Try

    End Function

    ''' <summary>
    ''' Consulta para llenar el DataGridView y colocar el nombre del encabezado
    ''' de la columna. 
    ''' </summary>
    Public Function fun_Consultar_HISTAVAL() As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "HIAVIDRE, "
            stConsultaSQL += "HIAVNUFI, "
            stConsultaSQL += "HIAVVIGE, "
            stConsultaSQL += "HIAVATPR, "
            stConsultaSQL += "HIAVATCO, "
            stConsultaSQL += "HIAVACPR, "
            stConsultaSQL += "HIAVACCO, "
            stConsultaSQL += "HIAVVATP, "
            stConsultaSQL += "HIAVVATC, "
            stConsultaSQL += "HIAVVACP, "
            stConsultaSQL += "HIAVVACC, "
            stConsultaSQL += "HIAVAVAL, "
            stConsultaSQL += "HIAVOBSE, "
            stConsultaSQL += "HIAVTIRE, "
            stConsultaSQL += "HIAVNURE, "
            stConsultaSQL += "HIAVVIRE, "
            stConsultaSQL += "HIAVESTA "

            stConsultaSQL += "FROM "
            stConsultaSQL += "HISTAVAL "

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "HIAVVIGE "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Consultar_HISTAVAL")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Llena el ComboBox con datos activos e inactivos formulario principal 
    ''' esta funcion se llama desde el procedimiento "pro_inicializarControles()".
    ''' </summary>
    Public Function fun_Consultar_CAMPOS_HISTAVAL() As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "HISTAVAL "

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "HIAVVIGE "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Consultar_CAMPOS_HISTAVAL")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Llena el ComboBox con datos activos formulario insertar y modificar 
    ''' esta funcion se llama desde el procedimiento "pro_inicializarControles()".
    ''' </summary>
    Public Function fun_Consultar_HISTAVAL_X_ESTADO() As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "HISTAVAL "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "HIAVESTA = 'ac' "

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "HIAVVIGE "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Consultar_HISTAVAL_X_ESTADO")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que busca el ID del registro a modificar o eliminar.
    ''' </summary>
    Public Function fun_Buscar_ID_HISTAVAL(ByVal inHIAVIDRE As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "HISTAVAL "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "HIAVIDRE = '" & CInt(inHIAVIDRE) & "'"

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Buscar_ID_HISTAVAL")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que busca el CÓDIGO para que no se 
    ''' guarden registros duplicados.
    ''' </summary>
    Public Function fun_Buscar_CODIGO_NUFI_VIGE_X_HISTAVAL(ByVal stHIAVNUFI As String, _
                                                           ByVal stHIAVVIGE As String) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "HISTAVAL "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "HIAVNUFI = '" & CInt(stHIAVNUFI) & "' and "
            stConsultaSQL += "HIAVVIGE = '" & CInt(stHIAVVIGE) & "' "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Buscar_CODIGO_HISTAVAL")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que busca el ID del codigo buscado para ejecutar la consulta
    ''' parametrizada.
    ''' </summary>
    Public Function fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_HISTAVAL(ByVal inHIAVIDRE As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "HIAVIDRE, "
            stConsultaSQL += "HIAVNUFI, "
            stConsultaSQL += "HIAVVIGE, "
            stConsultaSQL += "HIAVATPR, "
            stConsultaSQL += "HIAVATCO, "
            stConsultaSQL += "HIAVACPR, "
            stConsultaSQL += "HIAVACCO, "
            stConsultaSQL += "HIAVVATP, "
            stConsultaSQL += "HIAVVATC, "
            stConsultaSQL += "HIAVVACP, "
            stConsultaSQL += "HIAVVACC, "
            stConsultaSQL += "HIAVAVAL, "
            stConsultaSQL += "HIAVOBSE, "
            stConsultaSQL += "HIAVESTA "

            stConsultaSQL += "FROM "
            stConsultaSQL += "HISTAVAL "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "HIAVIDRE = '" & CInt(inHIAVIDRE) & "'"

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "HIAVVIGE "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception

            MessageBox.Show(Err.Description & " " & "fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_HISTAVAL")
            Return Nothing

        End Try

    End Function

    ''' <summary>
    ''' Función que busca el ID del codigo buscado para ejecutar la consulta
    ''' parametrizada.
    ''' </summary>
    Public Function fun_Buscar_NUFI_X_CONSULTA_PARAMETRIZADA_HISTAVAL(ByVal inHIAVNUFI As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "HIAVIDRE, "
            stConsultaSQL += "HIAVNUFI, "
            stConsultaSQL += "HIAVVIGE, "
            stConsultaSQL += "HIAVATPR, "
            stConsultaSQL += "HIAVATCO, "
            stConsultaSQL += "HIAVACPR, "
            stConsultaSQL += "HIAVACCO, "
            stConsultaSQL += "HIAVVATP, "
            stConsultaSQL += "HIAVVATC, "
            stConsultaSQL += "HIAVVACP, "
            stConsultaSQL += "HIAVVACC, "
            stConsultaSQL += "HIAVAVAL, "
            stConsultaSQL += "HIAVOBSE, "
            stConsultaSQL += "HIAVTIRE, "
            stConsultaSQL += "HIAVNURE, "
            stConsultaSQL += "HIAVVIRE, "
            stConsultaSQL += "HIAVESTA, "
            stConsultaSQL += "HIAVUSIN, "
            stConsultaSQL += "HIAVUSMO, "
            stConsultaSQL += "HIAVFEIN, "
            stConsultaSQL += "HIAVFEMO, "
            stConsultaSQL += "HIAVMAQU "

            stConsultaSQL += "FROM "
            stConsultaSQL += "HISTAVAL "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "HIAVNUFI = '" & CInt(inHIAVNUFI) & "'"

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "HIAVVIGE "
            stConsultaSQL += "DESC "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception

            MessageBox.Show(Err.Description & " " & "fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_HISTAVAL")
            Return Nothing

        End Try

    End Function

End Class
