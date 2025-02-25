Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration
Imports DATOS

Public Class cla_RECOAVAL

    '==================================================
    '*** CLASE RESOLUCIONES DE CONSERVACION AVALUOS ***
    '==================================================

    ''' <summary>
    ''' procedimiento que verifica la llave primaria.
    ''' </summary>
    Public Function fun_Verifica_llave_Primaria_RECOAVAL(ByVal obRCAVNURE As Object, _
                                                         ByVal obRCAVFERE As Object, _
                                                         ByVal obRCAVNUFI As Object, _
                                                         ByVal obRCAVVIGE As Object) As Boolean

        Try
            Dim boRespuesta As Boolean = False

            Dim obVerifica As New cla_Verificar_Dato

            If obVerifica.fun_Verificar_Campo_Lleno(obRCAVNURE.Text) = True And _
                obVerifica.fun_Verificar_Campo_Lleno(obRCAVFERE.Text) = True And _
                obVerifica.fun_Verificar_Campo_Lleno(obRCAVNUFI.Text) = True And _
                obVerifica.fun_Verificar_Campo_Lleno(obRCAVVIGE.Text) = True Then

                Dim objdatos1 As New cla_RECOAVAL
                Dim tbl As New DataTable

                tbl = objdatos1.fun_Buscar_CODIGO_X_RECOAVAL(obRCAVNURE.Text, obRCAVFERE.Text, obRCAVNUFI.Text, obRCAVVIGE.Text)

                If tbl.Rows.Count > 0 Then
                    MessageBox.Show("El registro existe en la base de datos.", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1)
                    boRespuesta = False
                Else
                    boRespuesta = True
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
    Public Function fun_Insertar_RECOAVAL(ByVal inRCAVSECU As Integer, _
                                          ByVal inRCAVNURE As Integer, _
                                          ByVal stRCAVFERE As String, _
                                          ByVal inRCAVNUFI As Integer, _
                                          ByVal inRCAVVIGE As Integer, _
                                          ByVal loRCAVATPR As Long, _
                                          ByVal loRCAVATCO As Long, _
                                          ByVal stRCAVACPR As String, _
                                          ByVal stRCAVACCO As String, _
                                          ByVal loRCAVVTPR As Long, _
                                          ByVal loRCAVVTCO As Long, _
                                          ByVal loRCAVVCPR As Long, _
                                          ByVal loRCAVVCCO As Long, _
                                          ByVal loRCAVAVAL As Long, _
                                          ByVal boRCAVAUTO As Boolean, _
                                          ByVal stRCAVESTA As String) As Boolean


        Try

            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "INSERT INTO "
            stConsultaSQL += "RECOAVAL "

            stConsultaSQL += "( "
            stConsultaSQL += "RCAVSECU, "
            stConsultaSQL += "RCAVNURE, "
            stConsultaSQL += "RCAVFERE, "
            stConsultaSQL += "RCAVNUFI, "
            stConsultaSQL += "RCAVVIGE, "
            stConsultaSQL += "RCAVATPR, "
            stConsultaSQL += "RCAVATCO, "
            stConsultaSQL += "RCAVACPR, "
            stConsultaSQL += "RCAVACCO, "
            stConsultaSQL += "RCAVVTPR, "
            stConsultaSQL += "RCAVVTCO, "
            stConsultaSQL += "RCAVVCPR, "
            stConsultaSQL += "RCAVVCCO, "
            stConsultaSQL += "RCAVAVAL, "
            stConsultaSQL += "RCAVAUTO, "
            stConsultaSQL += "RCAVESTA "
            stConsultaSQL += ") "

            stConsultaSQL += "VALUES "

            stConsultaSQL += "( "
            stConsultaSQL += "'" & CInt(inRCAVSECU) & "', "
            stConsultaSQL += "'" & CInt(inRCAVNURE) & "', "
            stConsultaSQL += "'" & CStr(Trim(stRCAVFERE)) & "', "
            stConsultaSQL += "'" & CInt(inRCAVNUFI) & "', "
            stConsultaSQL += "'" & CInt(inRCAVVIGE) & "', "
            stConsultaSQL += "'" & CLng(loRCAVATPR) & "', "
            stConsultaSQL += "'" & CLng(loRCAVATCO) & "', "
            stConsultaSQL += "'" & CStr(Trim(stRCAVACPR)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stRCAVACCO)) & "', "
            stConsultaSQL += "'" & CLng(loRCAVVTPR) & "', "
            stConsultaSQL += "'" & CLng(loRCAVVTCO) & "', "
            stConsultaSQL += "'" & CLng(loRCAVVCPR) & "', "
            stConsultaSQL += "'" & CLng(loRCAVVCCO) & "', "
            stConsultaSQL += "'" & CLng(loRCAVAVAL) & "', "
            stConsultaSQL += "'" & CBool(boRCAVAUTO) & "', "
            stConsultaSQL += "'" & CStr(Trim(stRCAVESTA)) & "' "
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
            MessageBox.Show(Err.Description & " " & "fun_Insertar_RECOAVAL")
        End Try

    End Function

    ''' <summary>
    ''' Función que Elimina el registro.
    ''' </summary>
    Public Function fun_Eliminar_CODIGO_RECOAVAL(ByVal inRCAVNURE As Integer, _
                                                 ByVal stRCAVFERE As String, _
                                                 ByVal inRCAVNUFI As Integer, _
                                                 ByVal inRCAVVIGE As Integer) As Boolean

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "DELETE "
            stConsultaSQL += "RECOAVAL "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "RCAVNURE = '" & CInt(inRCAVNURE) & "' AND "
            stConsultaSQL += "RCAVFERE = '" & CStr(Trim(stRCAVFERE)) & "' AND "
            stConsultaSQL += "RCAVNUFI = '" & CInt(inRCAVNUFI) & "' AND "
            stConsultaSQL += "RCAVVIGE = '" & CInt(inRCAVVIGE) & "' "

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
            MessageBox.Show(Err.Description & " " & "fun_Eliminar_RECOAVAL")
        End Try

    End Function

    ''' <summary>
    ''' Función que Modifica el registro.
    ''' </summary>
    Public Function fun_Actualizar_RECOAVAL(ByVal inRCAVIDRE As Integer, _
                                            ByVal inRCAVSECU As Integer, _
                                            ByVal inRCAVNURE As Integer, _
                                            ByVal stRCAVFERE As String, _
                                            ByVal inRCAVNUFI As Integer, _
                                            ByVal inRCAVVIGE As Integer, _
                                            ByVal loRCAVATPR As Long, _
                                            ByVal loRCAVATCO As Long, _
                                            ByVal stRCAVACPR As String, _
                                            ByVal stRCAVACCO As String, _
                                            ByVal loRCAVVTPR As Long, _
                                            ByVal loRCAVVTCO As Long, _
                                            ByVal loRCAVVCPR As Long, _
                                            ByVal loRCAVVCCO As Long, _
                                            ByVal loRCAVAVAL As Long, _
                                            ByVal boRCAVAUTO As Boolean, _
                                            ByVal stRCAVESTA As String) As Boolean

        Try

            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "UPDATE "
            stConsultaSQL += "RECOAVAL "

            stConsultaSQL += "SET "
            stConsultaSQL += "RCAVNURE = '" & CInt(inRCAVNURE) & "', "
            stConsultaSQL += "RCAVFERE = '" & CStr(Trim(stRCAVFERE)) & "', "
            stConsultaSQL += "RCAVNUFI = '" & CInt(inRCAVNUFI) & "', "
            stConsultaSQL += "RCAVVIGE = '" & CInt(inRCAVVIGE) & "', "

            stConsultaSQL += "RCAVATPR = '" & CLng(loRCAVATPR) & "', "
            stConsultaSQL += "RCAVATCO = '" & CLng(loRCAVATCO) & "', "
            stConsultaSQL += "RCAVACPR = '" & CStr(Trim(stRCAVACPR)) & "', "
            stConsultaSQL += "RCAVACCO = '" & CStr(Trim(stRCAVACCO)) & "', "
            stConsultaSQL += "RCAVVTPR = '" & CLng(loRCAVVTPR) & "', "
            stConsultaSQL += "RCAVVTCO = '" & CLng(loRCAVVTCO) & "', "
            stConsultaSQL += "RCAVVCPR = '" & CLng(loRCAVVCPR) & "', "
            stConsultaSQL += "RCAVVCCO = '" & CLng(loRCAVVCCO) & "', "
            stConsultaSQL += "RCAVAVAL = '" & CLng(loRCAVAVAL) & "', "
            stConsultaSQL += "RCAVAUTO = '" & CBool(boRCAVAUTO) & "', "
            stConsultaSQL += "RCAVESTA = '" & CStr(Trim(stRCAVESTA)) & "' "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "RCAVIDRE = '" & CInt(inRCAVIDRE) & "' "

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
            MessageBox.Show(Err.Description & " " & "fun_Actualizar_RECOAVAL")
        End Try

    End Function

    ''' <summary>
    ''' Función que busca el ID del registro a modificar o eliminar.
    ''' </summary>
    Public Function fun_Buscar_CODIGO_X_RECOAVAL(ByVal inRCAVNURE As Integer, _
                                                 ByVal stRCAVFERE As String, _
                                                 ByVal inRCAVNUFI As Integer, _
                                                 ByVal inRCAVVIGE As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "RECOAVAL "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "RCAVNURE = '" & CInt(inRCAVNURE) & "' AND "
            stConsultaSQL += "RCAVFERE = '" & CStr(Trim(stRCAVFERE)) & "' AND "
            stConsultaSQL += "RCAVNUFI = '" & CInt(inRCAVNUFI) & "' AND "
            stConsultaSQL += "RCAVVIGE = '" & CInt(inRCAVVIGE) & "' "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Buscar_NURA_FERA_X_RECOAVAL")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que consulta los registros
    ''' parametrizada.
    ''' </summary>
    Public Function fun_Consultar_RECOAVAL(ByVal inRCAVSECU As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "TOP 10 "
            stConsultaSQL += "RCAVIDRE, "
            stConsultaSQL += "RCAVSECU, "
            stConsultaSQL += "RCAVNURE, "
            stConsultaSQL += "RCAVFERE, "
            stConsultaSQL += "RCAVNUFI, "
            stConsultaSQL += "RCAVVIGE, "
            stConsultaSQL += "RCAVATPR, "
            stConsultaSQL += "RCAVATCO, "
            stConsultaSQL += "RCAVACPR, "
            stConsultaSQL += "RCAVACCO, "
            stConsultaSQL += "RCAVVTPR, "
            stConsultaSQL += "RCAVVTCO, "
            stConsultaSQL += "RCAVVCPR, "
            stConsultaSQL += "RCAVVCCO, "
            stConsultaSQL += "RCAVAVAL, "
            stConsultaSQL += "RCAVAUTO, "
            stConsultaSQL += "RCAVESTA "

            stConsultaSQL += "FROM "
            stConsultaSQL += "RECOAVAL "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "RCAVSECU = '" & CInt(inRCAVSECU) & "' "

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "RCAVSECU "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception

            MessageBox.Show(Err.Description & " " & "fun_Buscar_SECU_X_CONSULTA_PARAMETRIZADA_RECOAVAL")
            Return Nothing

        End Try

    End Function


    ''' <summary>
    ''' Función que busca el SECU del codigo buscado para ejecutar la consulta
    ''' parametrizada.
    ''' </summary>
    Public Function fun_Buscar_SECU_X_CONSULTA_PARAMETRIZADA_RECOAVAL(ByVal inRCAVSECU As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "RCAVIDRE, "
            stConsultaSQL += "RCAVSECU, "
            stConsultaSQL += "RCAVNURE, "
            stConsultaSQL += "RCAVFERE, "
            stConsultaSQL += "RCAVNUFI, "
            stConsultaSQL += "RCAVVIGE, "
            stConsultaSQL += "RCAVATPR, "
            stConsultaSQL += "RCAVATCO, "
            stConsultaSQL += "RCAVACPR, "
            stConsultaSQL += "RCAVACCO, "
            stConsultaSQL += "RCAVVTPR, "
            stConsultaSQL += "RCAVVTCO, "
            stConsultaSQL += "RCAVVCPR, "
            stConsultaSQL += "RCAVVCCO, "
            stConsultaSQL += "RCAVAVAL, "
            stConsultaSQL += "RCAVAUTO, "
            stConsultaSQL += "RCAVESTA "

            stConsultaSQL += "FROM "
            stConsultaSQL += "RECOAVAL "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "RCAVSECU = '" & CInt(inRCAVSECU) & "' "

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "RCAVSECU "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception

            MessageBox.Show(Err.Description & " " & "fun_Buscar_SECU_X_CONSULTA_PARAMETRIZADA_RECOAVAL")
            Return Nothing

        End Try

    End Function


End Class
