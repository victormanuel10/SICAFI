Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration
Imports DATOS

Public Class cla_HISTLIQU

    '======================================
    '*** CLASE HISTORICO DE LIQUIDACIÓN ***
    '======================================

    ''' <summary>
    ''' procedimiento que verifica la llave primaria.
    ''' </summary>
    Public Function fun_Verifica_llave_Primaria_HISTLIQU(ByVal obHILINUFI As Object, _
                                                         ByVal obHILIVIGE As Object) As Boolean

        Try
            Dim boRespuesta As Boolean = False

            Dim obVerifica As New cla_Verificar_Dato

            If obVerifica.fun_Verificar_Campo_Lleno(obHILINUFI.Text) = True And _
               obVerifica.fun_Verificar_Campo_Lleno(obHILIVIGE.SelectedValue) = True Then

                If obVerifica.fun_Verificar_Dato_Numerico(obHILINUFI.Text) = True And _
                   obVerifica.fun_Verificar_Dato_Numerico(obHILIVIGE.SelectedValue) = True Then

                    Dim objdatos1 As New cla_HISTLIQU
                    Dim tbl As New DataTable

                    tbl = objdatos1.fun_Buscar_CODIGO_NUFI_VIGE_X_HISTLIQU(obHILINUFI.Text, _
                                                                           obHILIVIGE.SelectedValue)

                    If tbl.Rows.Count > 0 Then
                        MessageBox.Show("El dato " & Trim(obHILINUFI.Text) & " - " & _
                                                     Trim(obHILIVIGE.Text) & " - " & " existe en la base de datos.", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                        obHILINUFI.Focus()
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
    Public Function fun_Insertar_HISTLIQU(ByVal inHILINUFI As Integer, _
                                          ByVal stHILICECA As String, _
                                          ByVal inHILIVIGE As Integer, _
                                          ByVal loHILIAVPR As Long, _
                                          ByVal loHILIAVCA As Long, _
                                          ByVal stHILIDEEC As String, _
                                          ByVal stHILIESTR As String, _
                                          ByVal boHILILOTE As Boolean, _
                                          ByVal boHILILOCE As Boolean, _
                                          ByVal boHILILE44 As Boolean, _
                                          ByVal boHILILE56 As Boolean, _
                                          ByVal boHILIAUAV As Boolean, _
                                          ByVal boHILIGRAV As Boolean, _
                                          ByVal stHILITIPO As String, _
                                          ByVal inHILIARCO As Integer, _
                                          ByVal inHILIARTE As Integer, _
                                          ByVal inHILIPUNT As Integer, _
                                          ByVal stHILIESTA As String, _
                                          ByVal stHILITIRE As String, _
                                          ByVal stHILIVIRE As String, _
                                          ByVal stHILIRESO As String) As Boolean

        Try

            ' variables del sistema
            Dim stHILIUSIN As String = vp_usuario
            Dim stHILIUSMO As String = ""
            Dim daHILIFEIN As Date = fun_fecha()
            Dim daHILIFEMO As Date = fun_fecha()
            Dim stHILIMAQU As String = fun_Nombre_de_maquina()

            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "INSERT INTO "
            stConsultaSQL += "HISTLIQU "

            stConsultaSQL += "( "
            stConsultaSQL += "HILINUFI, "
            stConsultaSQL += "HILICECA, "
            stConsultaSQL += "HILIVIGE, "
            stConsultaSQL += "HILIAVPR, "
            stConsultaSQL += "HILIAVCA, "
            stConsultaSQL += "HILIDEEC, "
            stConsultaSQL += "HILIESTR, "
            stConsultaSQL += "HILILOTE, "
            stConsultaSQL += "HILILOCE, "
            stConsultaSQL += "HILILE44, "
            stConsultaSQL += "HILILE56, "
            stConsultaSQL += "HILIAUAV, "
            stConsultaSQL += "HILIGRAV, "
            stConsultaSQL += "HILITIPO, "
            stConsultaSQL += "HILIARCO, "
            stConsultaSQL += "HILIARTE, "
            stConsultaSQL += "HILIPUNT, "
            stConsultaSQL += "HILIESTA, "
            stConsultaSQL += "HILITIRE, "
            stConsultaSQL += "HILIVIRE, "
            stConsultaSQL += "HILIRESO, "
            stConsultaSQL += "HILIUSIN, "
            stConsultaSQL += "HILIUSMO, "
            stConsultaSQL += "HILIFEIN, "
            stConsultaSQL += "HILIFEMO, "
            stConsultaSQL += "HILIMAQU  "
            stConsultaSQL += ") "

            stConsultaSQL += "VALUES "

            stConsultaSQL += "( "
            stConsultaSQL += "'" & CInt(inHILINUFI) & "', "
            stConsultaSQL += "'" & CStr(Trim(stHILICECA)) & "', "
            stConsultaSQL += "'" & CInt(inHILIVIGE) & "', "
            stConsultaSQL += "'" & CLng(loHILIAVPR) & "', "
            stConsultaSQL += "'" & CLng(loHILIAVCA) & "', "
            stConsultaSQL += "'" & CStr(Trim(stHILIDEEC)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stHILIESTR)) & "', "
            stConsultaSQL += "'" & CBool(boHILILOTE) & "', "
            stConsultaSQL += "'" & CBool(boHILILOCE) & "', "
            stConsultaSQL += "'" & CBool(boHILILE44) & "', "
            stConsultaSQL += "'" & CBool(boHILILE56) & "', "
            stConsultaSQL += "'" & CBool(boHILIAUAV) & "', "
            stConsultaSQL += "'" & CBool(boHILIGRAV) & "', "
            stConsultaSQL += "'" & CStr(Trim(stHILITIPO)) & "', "
            stConsultaSQL += "'" & CInt(inHILIARCO) & "', "
            stConsultaSQL += "'" & CInt(inHILIARTE) & "', "
            stConsultaSQL += "'" & CInt(inHILIPUNT) & "', "
            stConsultaSQL += "'" & CStr(Trim(stHILIESTA)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stHILITIRE)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stHILIVIRE)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stHILIRESO)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stHILIUSIN)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stHILIUSMO)) & "', "
            stConsultaSQL += "'" & CDate(daHILIFEIN) & "', "
            stConsultaSQL += "'" & CDate(daHILIFEMO) & "', "
            stConsultaSQL += "'" & CStr(Trim(stHILIMAQU)) & "'  "
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
            MessageBox.Show(Err.Description & " " & "fun_Insertar_HISTLIQU")
        End Try

    End Function


    ''' <summary>
    ''' Función que Elimina el registro.
    ''' </summary>
    Public Function fun_Eliminar_HISTLIQU(ByVal inHILIIDRE As Integer) As Boolean

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "DELETE "
            stConsultaSQL += "HISTLIQU "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "HILIIDRE = '" & CInt(inHILIIDRE) & "' "

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
            MessageBox.Show(Err.Description & " " & "fun_Eliminar_HISTLIQU")
        End Try

    End Function

    ''' <summary>
    ''' elimina por el numero de la ficha predial
    ''' </summary>
    Public Function fun_Eliminar_NUFI_X_HISTLIQU(ByVal inHILINUFI As Integer) As Boolean

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "DELETE "
            stConsultaSQL += "HISTLIQU "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "HILINUFI = '" & CInt(inHILINUFI) & "' "

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
            MessageBox.Show(Err.Description & " " & "fun_Eliminar_HISTLIQU")
        End Try

    End Function

    ''' <summary>
    ''' elimina por el numero de la ficha predial y vigencia
    ''' </summary>
    Public Function fun_Eliminar_NUFI_Y_VIGE_X_HISTLIQU(ByVal inHILINUFI As Integer, ByVal inHILIVIGE As Integer) As Boolean

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "DELETE "
            stConsultaSQL += "HISTLIQU "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "HILINUFI = '" & CInt(inHILINUFI) & "' and "
            stConsultaSQL += "HILIVIGE = '" & CInt(inHILIVIGE) & "'  "

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
            MessageBox.Show(Err.Description & " " & "fun_Eliminar_HISTLIQU")
        End Try

    End Function

    ''' <summary>
    ''' Función que Modifica el registro.
    ''' </summary>
    Public Function fun_Actualizar_HISTLIQU(ByVal inHILIIDRE As Integer, _
                                          ByVal inHILINUFI As Integer, _
                                          ByVal stHILICECA As String, _
                                          ByVal inHILIVIGE As Integer, _
                                          ByVal inHILIAVPR As Integer, _
                                          ByVal inHILIAVCA As Integer, _
                                          ByVal stHILIDEEC As String, _
                                          ByVal stHILIESTR As String, _
                                          ByVal boHILILOTE As Boolean, _
                                          ByVal boHILILOCE As Boolean, _
                                          ByVal boHILILE44 As Boolean, _
                                          ByVal boHILILE56 As Boolean, _
                                          ByVal boHILIAUAV As Boolean, _
                                          ByVal stHILITIPO As String, _
                                          ByVal inHILIARCO As Integer, _
                                          ByVal inHILIARTE As Integer, _
                                          ByVal inHILIPUNT As Integer, _
                                          ByVal stHILIESTA As String, _
                                          ByVal stHILITIRE As String, _
                                          ByVal stHILINURE As String, _
                                          ByVal stHILIVIRE As String, _
                                          ByVal stHILIRESO As String) As Boolean

        Try
            ' variables del sistema
            Dim stHILIUSMO As String = vp_usuario
            Dim daHILIFEMO As Date = fun_Hora_y_fecha()
            Dim stHILIMAQU As String = fun_Nombre_de_maquina()

            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "UPDATE "
            stConsultaSQL += "HISTLIQU "

            stConsultaSQL += "SET "
            stConsultaSQL += "HILINUFI = '" & CInt(inHILINUFI) & "', "
            stConsultaSQL += "HILICECA = '" & CStr(Trim(stHILICECA)) & "', "
            stConsultaSQL += "HILIVIGE = '" & CInt(inHILIVIGE) & "', "
            stConsultaSQL += "HILIAVPR = '" & CInt(inHILIAVPR) & "', "
            stConsultaSQL += "HILIAVCA = '" & CInt(inHILIAVCA) & "', "
            stConsultaSQL += "HILIDEEC = '" & CStr(Trim(stHILIDEEC)) & "', "
            stConsultaSQL += "HILIESTR = '" & CStr(Trim(stHILIESTR)) & "', "
            stConsultaSQL += "HILILOTE = '" & CBool(boHILILOTE) & "', "
            stConsultaSQL += "HILILOCE = '" & CBool(boHILILOCE) & "', "
            stConsultaSQL += "HILILE44 = '" & CBool(boHILILE44) & "', "
            stConsultaSQL += "HILILE56 = '" & CBool(boHILILE56) & "', "
            stConsultaSQL += "HILIAUAV = '" & CBool(boHILIAUAV) & "', "
            stConsultaSQL += "HILITIPO = '" & CStr(Trim(stHILITIPO)) & "', "
            stConsultaSQL += "HILIARCO = '" & CInt(inHILIARCO) & "', "
            stConsultaSQL += "HILIARTE = '" & CInt(inHILIARTE) & "', "
            stConsultaSQL += "HILIPUNT = '" & CInt(inHILIPUNT) & "', "
            stConsultaSQL += "HILIESTA = '" & CStr(Trim(stHILIESTA)) & "', "
            stConsultaSQL += "HILITIRE = '" & CStr(Trim(stHILITIRE)) & "', "
            stConsultaSQL += "HILINURE = '" & CStr(Trim(stHILINURE)) & "', "
            stConsultaSQL += "HILIVIRE = '" & CStr(Trim(stHILIVIRE)) & "', "
            stConsultaSQL += "HILIRESO = '" & CStr(Trim(stHILIRESO)) & "', "
            stConsultaSQL += "HILIUSMO = '" & CStr(Trim(stHILIUSMO)) & "', "
            stConsultaSQL += "HILIFEMO = '" & CDate(daHILIFEMO) & "', "
            stConsultaSQL += "HILIMAQU = '" & CStr(Trim(stHILIMAQU)) & "  "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "HILIIDRE = '" & CInt(inHILIIDRE) & "'"

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
            MessageBox.Show(Err.Description & " " & "fun_Actualizar_HISTLIQU")
        End Try

    End Function

    ''' <summary>
    ''' Función que Modifica el registro.
    ''' </summary>
    Public Function fun_Actualizar_NUFI_VIGE_X_HISTLIQU(ByVal inHILINUFI As Integer, _
                                          ByVal stHILICECA As String, _
                                          ByVal inHILIVIGE As Integer, _
                                          ByVal loHILIAVPR As Long, _
                                          ByVal loHILIAVCA As Long, _
                                          ByVal stHILIDEEC As String, _
                                          ByVal stHILIESTR As String, _
                                          ByVal boHILILOTE As Boolean, _
                                          ByVal boHILILOCE As Boolean, _
                                          ByVal boHILILE44 As Boolean, _
                                          ByVal boHILILE56 As Boolean, _
                                          ByVal boHILIAUAV As Boolean, _
                                          ByVal boHILIGRAV As Boolean, _
                                          ByVal stHILITIPO As String, _
                                          ByVal inHILIARCO As Integer, _
                                          ByVal inHILIARTE As Integer, _
                                          ByVal inHILIPUNT As Integer, _
                                          ByVal stHILIESTA As String, _
                                          ByVal stHILITIRE As String, _
                                          ByVal stHILIVIRE As String, _
                                          ByVal stHILIRESO As String) As Boolean

        Try
            ' variables del sistema
            Dim stHILIUSMO As String = vp_usuario
            Dim daHILIFEMO As Date = fun_fecha()
            Dim stHILIMAQU As String = fun_Nombre_de_maquina()

            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "UPDATE "
            stConsultaSQL += "HISTLIQU "

            stConsultaSQL += "SET "
            stConsultaSQL += "HILINUFI = '" & CInt(inHILINUFI) & "', "
            stConsultaSQL += "HILICECA = '" & CStr(Trim(stHILICECA)) & "', "
            stConsultaSQL += "HILIVIGE = '" & CInt(inHILIVIGE) & "', "
            stConsultaSQL += "HILIAVPR = '" & CLng(loHILIAVPR) & "', "
            stConsultaSQL += "HILIAVCA = '" & CLng(loHILIAVCA) & "', "
            stConsultaSQL += "HILIDEEC = '" & CStr(Trim(stHILIDEEC)) & "', "
            stConsultaSQL += "HILIESTR = '" & CStr(Trim(stHILIESTR)) & "', "
            stConsultaSQL += "HILILOTE = '" & CBool(boHILILOTE) & "', "
            stConsultaSQL += "HILILOCE = '" & CBool(boHILILOCE) & "', "
            stConsultaSQL += "HILILE44 = '" & CBool(boHILILE44) & "', "
            stConsultaSQL += "HILILE56 = '" & CBool(boHILILE56) & "', "
            stConsultaSQL += "HILIAUAV = '" & CBool(boHILIAUAV) & "', "
            stConsultaSQL += "HILITIPO = '" & CStr(Trim(stHILITIPO)) & "', "
            stConsultaSQL += "HILIARCO = '" & CInt(inHILIARCO) & "', "
            stConsultaSQL += "HILIARTE = '" & CInt(inHILIARTE) & "', "
            stConsultaSQL += "HILIPUNT = '" & CInt(inHILIPUNT) & "', "
            stConsultaSQL += "HILIESTA = '" & CStr(Trim(stHILIESTA)) & "', "
            stConsultaSQL += "HILITIRE = '" & CStr(Trim(stHILITIRE)) & "', "
            stConsultaSQL += "HILIVIRE = '" & CStr(Trim(stHILIVIRE)) & "', "
            stConsultaSQL += "HILIRESO = '" & CStr(Trim(stHILIRESO)) & "', "
            stConsultaSQL += "HILIUSMO = '" & CStr(Trim(stHILIUSMO)) & "', "
            stConsultaSQL += "HILIFEMO = '" & CDate(daHILIFEMO) & "', "
            stConsultaSQL += "HILIMAQU = '" & CStr(Trim(stHILIMAQU)) & "'  "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "HILINUFI = '" & CInt(inHILINUFI) & "' and "
            stConsultaSQL += "HILIVIGE = '" & CInt(inHILIVIGE) & "' "

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
            MessageBox.Show(Err.Description & " " & "fun_Actualizar_HISTLIQU")
        End Try

    End Function

    ''' <summary>
    ''' Consulta para llenar el DataGridView y colocar el nombre del encabezado
    ''' de la columna. 
    ''' </summary>
    Public Function fun_Consultar_HISTLIQU() As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "HILIIDRE, "
            stConsultaSQL += "HILINUFI, "
            stConsultaSQL += "HILICECA, "
            stConsultaSQL += "HILIVIGE, "
            stConsultaSQL += "HILIAVPR, "
            stConsultaSQL += "HILIAVCA, "
            stConsultaSQL += "HILIDEEC, "
            stConsultaSQL += "HILIESTR, "
            stConsultaSQL += "HILILOTE, "
            stConsultaSQL += "HILILOCE, "
            stConsultaSQL += "HILILE44, "
            stConsultaSQL += "HILILE56, "
            stConsultaSQL += "HILIAUAV, "
            stConsultaSQL += "HILITIPO, "
            stConsultaSQL += "HILIARCO, "
            stConsultaSQL += "HILIARTE, "
            stConsultaSQL += "HILIPUNT, "
            stConsultaSQL += "HILIESTA "

            stConsultaSQL += "FROM "
            stConsultaSQL += "HISTLIQU "

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "HILIVIGE "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Consultar_HISTLIQU")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Llena el ComboBox con datos activos e inactivos formulario principal 
    ''' esta funcion se llama desde el procedimiento "pro_inicializarControles()".
    ''' </summary>
    Public Function fun_Consultar_CAMPOS_HISTLIQU() As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "HISTLIQU "

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "HILIVIGE "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Consultar_CAMPOS_HISTLIQU")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Llena el ComboBox con datos activos formulario insertar y modificar 
    ''' esta funcion se llama desde el procedimiento "pro_inicializarControles()".
    ''' </summary>
    Public Function fun_Consultar_HISTLIQU_X_ESTADO() As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "HISTLIQU "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "HILIESTA = 'ac' "

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "HILIVIGE "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Consultar_HISTLIQU_X_ESTADO")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que busca el ID del registro a modificar o eliminar.
    ''' </summary>
    Public Function fun_Buscar_ID_HISTLIQU(ByVal inHILIIDRE As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "HISTLIQU "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "HILIIDRE = '" & CInt(inHILIIDRE) & "'"

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Buscar_ID_HISTLIQU")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que busca el CÓDIGO para que no se 
    ''' guarden registros duplicados.
    ''' </summary>
    Public Function fun_Buscar_CODIGO_NUFI_VIGE_X_HISTLIQU(ByVal stHILINUFI As String, _
                                                           ByVal stHILIVIGE As String) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "HISTLIQU "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "HILINUFI = '" & CInt(stHILINUFI) & "' and "
            stConsultaSQL += "HILIVIGE = '" & CInt(stHILIVIGE) & "' "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Buscar_CODIGO_HISTLIQU")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que busca el ID del codigo buscado para ejecutar la consulta
    ''' parametrizada.
    ''' </summary>
    Public Function fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_HISTLIQU(ByVal inHILIIDRE As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "HILIIDRE, "
            stConsultaSQL += "HILINUFI, "
            stConsultaSQL += "HILICECA, "
            stConsultaSQL += "HILIVIGE, "
            stConsultaSQL += "HILIAVPR, "
            stConsultaSQL += "HILIAVCA, "
            stConsultaSQL += "HILIDEEC, "
            stConsultaSQL += "HILIESTR, "
            stConsultaSQL += "HILILOTE, "
            stConsultaSQL += "HILILOCE, "
            stConsultaSQL += "HILILE44, "
            stConsultaSQL += "HILILE56, "
            stConsultaSQL += "HILIAUAV, "
            stConsultaSQL += "HILITIPO, "
            stConsultaSQL += "HILIARCO, "
            stConsultaSQL += "HILIARTE, "
            stConsultaSQL += "HILIPUNT, "
            stConsultaSQL += "HILIESTA "

            stConsultaSQL += "FROM "
            stConsultaSQL += "HISTLIQU "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "HILIIDRE = '" & CInt(inHILIIDRE) & "'"

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "HILIVIGE "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception

            MessageBox.Show(Err.Description & " " & "fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_HISTLIQU")
            Return Nothing

        End Try

    End Function

    ''' <summary>
    ''' Función que busca el ID del codigo buscado para ejecutar la consulta
    ''' parametrizada.
    ''' </summary>
    Public Function fun_Buscar_NUFI_X_CONSULTA_PARAMETRIZADA_HISTLIQU(ByVal inHILINUFI As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "HILIIDRE, "
            stConsultaSQL += "HILINUFI, "
            stConsultaSQL += "HILICECA, "
            stConsultaSQL += "HILIVIGE, "
            stConsultaSQL += "HILIAVPR, "
            stConsultaSQL += "HILIAVCA, "
            stConsultaSQL += "HILIDEEC, "
            stConsultaSQL += "HILIESTR, "
            stConsultaSQL += "HILILOTE, "
            stConsultaSQL += "HILILOCE, "
            stConsultaSQL += "HILILE44, "
            stConsultaSQL += "HILILE56, "
            stConsultaSQL += "HILIAUAV, "
            stConsultaSQL += "HILITIPO, "
            stConsultaSQL += "HILIARCO, "
            stConsultaSQL += "HILIARTE, "
            stConsultaSQL += "HILIPUNT, "
            stConsultaSQL += "HILIESTA, "
            stConsultaSQL += "HILIUSIN, "
            stConsultaSQL += "HILIUSMO, "
            stConsultaSQL += "HILIFEIN, "
            stConsultaSQL += "HILIFEMO, "
            stConsultaSQL += "HILIMAQU "

            stConsultaSQL += "FROM "
            stConsultaSQL += "HISTLIQU "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "HILINUFI = '" & CInt(inHILINUFI) & "'"

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "HILIVIGE "
            stConsultaSQL += "DESC "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception

            MessageBox.Show(Err.Description & " " & "fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_HISTLIQU")
            Return Nothing

        End Try

    End Function

End Class
