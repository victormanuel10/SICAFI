Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration
Imports DATOS

Public Class cla_MUPRPROP

    '========================================================
    '*** CLASE MUTACIONES DE PRIMERA CLASE - PROPIETARIOS ***
    '========================================================

    ''' <summary>
    ''' procedimiento que verifica la llave primaria.
    ''' </summary>
    Public Function fun_Verifica_llave_Primaria_MUPRPROP(ByVal inMPPRVIGE As Integer, _
                                                         ByVal inMPPRTIRE As Integer, _
                                                         ByVal inMPPRRESO As Integer, _
                                                         ByVal obMPPRNUFI As Object, _
                                                         ByVal inMPPRNURE As Integer, _
                                                         ByVal obMPPRNUDO As Object) As Boolean

        Try
            Dim boRespuesta As Boolean = False

            Dim obVerifica As New cla_Verificar_Dato

            If obVerifica.fun_Verificar_Campo_Lleno(inMPPRVIGE) = True And _
                obVerifica.fun_Verificar_Campo_Lleno(inMPPRTIRE) = True And _
                obVerifica.fun_Verificar_Campo_Lleno(inMPPRRESO) = True And _
                obVerifica.fun_Verificar_Campo_Lleno(obMPPRNUFI.Text) = True And _
                obVerifica.fun_Verificar_Campo_Lleno(inMPPRNURE) = True And _
                obVerifica.fun_Verificar_Campo_Lleno(obMPPRNUDO.Text) = True Then

                If obVerifica.fun_Verificar_Dato_Numerico(inMPPRVIGE) = True And _
                    obVerifica.fun_Verificar_Dato_Numerico(inMPPRTIRE) = True And _
                    obVerifica.fun_Verificar_Dato_Numerico(inMPPRRESO) = True And _
                    obVerifica.fun_Verificar_Dato_Numerico(obMPPRNUFI.Text) = True And _
                    obVerifica.fun_Verificar_Dato_Numerico(inMPPRNURE) = True Then

                    Dim objdatos1 As New cla_MUPRPROP
                    Dim tbl As New DataTable

                    tbl = objdatos1.fun_Buscar_CODIGO_X_MUPRPROP(inMPPRVIGE, _
                                                                 inMPPRTIRE, _
                                                                 inMPPRRESO, _
                                                                 obMPPRNUFI.Text, _
                                                                 inMPPRNURE, _
                                                                 obMPPRNUDO.Text)

                    If tbl.Rows.Count > 0 Then
                        MessageBox.Show("El registro existe en la base de datos.", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1)
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
    Public Function fun_Insertar_MUPRPROP(ByVal inMPPRSECU As Integer, _
                                          ByVal inMPPRVIGE As Integer, _
                                          ByVal inMPPRTIRE As Integer, _
                                          ByVal inMPPRRESO As Integer, _
                                          ByVal inMPPRNUFI As Integer, _
                                          ByVal inMPPRNURE As Integer, _
                                          ByVal stMPPRNUDO As String, _
                                          ByVal inMPPRNOVC As Integer, _
                                          ByVal inMPPRTIDO As Integer, _
                                          ByVal stMPPRMAIN As String, _
                                          ByVal stMPPRCIRE As String, _
                                          ByVal stMPPRESCR As String, _
                                          ByVal stMPPRFEES As String, _
                                          ByVal stMPPRVACO As String, _
                                          ByVal stMPPRENTI As String, _
                                          ByVal stMPPRDENO As String, _
                                          ByVal stMPPRMUNO As String, _
                                          ByVal stMPPRFAEN As String, _
                                          ByVal stMPPRDERE As String, _
                                          ByVal stMPPRGRAV As String, _
                                          ByVal stMPPRFERE As String, _
                                          ByVal stMPPRLIRE As String, _
                                          ByVal stMPPRTORE As String, _
                                          ByVal stMPPRPARE As String, _
                                          ByVal stMPPRCOFI As String, _
                                          ByVal stMPPRNOFI As String, _
                                          ByVal stMPPRPRNO As String, _
                                          ByVal stMPPRSENO As String, _
                                          ByVal stMPPRPRAP As String, _
                                          ByVal stMPPRSEAP As String, _
                                          ByVal stMPPRRASO As String, _
                                          ByVal stMPPRTELE As String, _
                                          ByVal stMPPRCOEL As String, _
                                          ByVal stMPPRCELU As String, _
                                          ByVal stMPPRDIRE As String, _
                                          ByVal stMPPRSICO As String, _
                                          ByVal inMPPRCAPR As Integer, _
                                          ByVal inMPPRSEXO As Integer, _
                                          ByVal stMPPRESTA As String) As Boolean


        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "INSERT INTO "
            stConsultaSQL += "MUPRPROP "

            stConsultaSQL += "( "
            stConsultaSQL += "MPPRSECU, "
            stConsultaSQL += "MPPRVIGE, "
            stConsultaSQL += "MPPRTIRE, "
            stConsultaSQL += "MPPRRESO, "
            stConsultaSQL += "MPPRNUFI, "
            stConsultaSQL += "MPPRNURE, "
            stConsultaSQL += "MPPRNUDO, "
            stConsultaSQL += "MPPRNOVC, "
            stConsultaSQL += "MPPRTIDO, "
            stConsultaSQL += "MPPRMAIN, "
            stConsultaSQL += "MPPRCIRE, "
            stConsultaSQL += "MPPRESCR, "
            stConsultaSQL += "MPPRFEES, "
            stConsultaSQL += "MPPRVACO, "
            stConsultaSQL += "MPPRENTI, "
            stConsultaSQL += "MPPRDENO, "
            stConsultaSQL += "MPPRMUNO, "
            stConsultaSQL += "MPPRFAEN, "
            stConsultaSQL += "MPPRDERE, "
            stConsultaSQL += "MPPRGRAV, "
            stConsultaSQL += "MPPRFERE, "
            stConsultaSQL += "MPPRLIRE, "
            stConsultaSQL += "MPPRTORE, "
            stConsultaSQL += "MPPRPARE, "
            stConsultaSQL += "MPPRCOFI, "
            stConsultaSQL += "MPPRNOFI, "
            stConsultaSQL += "MPPRPRNO, "
            stConsultaSQL += "MPPRSENO, "
            stConsultaSQL += "MPPRPRAP, "
            stConsultaSQL += "MPPRSEAP, "
            stConsultaSQL += "MPPRRASO, "
            stConsultaSQL += "MPPRTELE, "
            stConsultaSQL += "MPPRCOEL, "
            stConsultaSQL += "MPPRCELU, "
            stConsultaSQL += "MPPRDIRE, "
            stConsultaSQL += "MPPRSICO, "
            stConsultaSQL += "MPPRCAPR, "
            stConsultaSQL += "MPPRSEXO, "
            stConsultaSQL += "MPPRESTA "
            stConsultaSQL += ") "

            stConsultaSQL += "VALUES "

            stConsultaSQL += "( "
            stConsultaSQL += "'" & CInt(inMPPRSECU) & "', "
            stConsultaSQL += "'" & CInt(inMPPRVIGE) & "', "
            stConsultaSQL += "'" & CInt(inMPPRTIRE) & "', "
            stConsultaSQL += "'" & CInt(inMPPRRESO) & "', "
            stConsultaSQL += "'" & CInt(inMPPRNUFI) & "', "
            stConsultaSQL += "'" & CInt(inMPPRNURE) & "', "
            stConsultaSQL += "'" & CStr(Trim(stMPPRNUDO)) & "', "
            stConsultaSQL += "'" & CInt(inMPPRNOVC) & "', "
            stConsultaSQL += "'" & CInt(inMPPRTIDO) & "', "
            stConsultaSQL += "'" & CStr(Trim(stMPPRMAIN)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stMPPRCIRE)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stMPPRESCR)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stMPPRFEES)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stMPPRVACO)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stMPPRENTI)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stMPPRDENO)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stMPPRMUNO)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stMPPRFAEN)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stMPPRDERE)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stMPPRGRAV)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stMPPRFERE)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stMPPRLIRE)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stMPPRTORE)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stMPPRPARE)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stMPPRCOFI)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stMPPRNOFI)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stMPPRPRNO)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stMPPRSENO)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stMPPRPRAP)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stMPPRSEAP)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stMPPRRASO)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stMPPRTELE)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stMPPRCOEL)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stMPPRCELU)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stMPPRDIRE)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stMPPRSICO)) & "', "
            stConsultaSQL += "'" & CInt(inMPPRCAPR) & "', "
            stConsultaSQL += "'" & CInt(inMPPRSEXO) & "', "
            stConsultaSQL += "'" & CStr(Trim(stMPPRESTA)) & "' "
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
            MessageBox.Show(Err.Description & " " & "fun_Insertar_MUPRPROP")
        End Try

    End Function

    ''' <summary>
    ''' Función que Elimina el registro.
    ''' </summary>
    Public Function fun_Eliminar_IDRE_MUPRPROP(ByVal inMPPRIDRE As Integer) As Boolean

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "DELETE "
            stConsultaSQL += "MUPRPROP "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "MPPRIDRE = '" & CInt(inMPPRIDRE) & "' "

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
            MessageBox.Show(Err.Description & " " & "fun_Eliminar_MUPRPROP")
        End Try

    End Function

    ''' <summary>
    ''' Función que Elimina el registro.
    ''' </summary>
    Public Function fun_Eliminar_SECU_MUPRPROP(ByVal inMPPRSECU As Integer) As Boolean

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "DELETE "
            stConsultaSQL += "MUPRPROP "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "MPPRSECU = '" & CInt(inMPPRSECU) & "' "

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
            MessageBox.Show(Err.Description & " " & "fun_Eliminar_MUPRPROP")
        End Try

    End Function

    ''' <summary>
    ''' Función que Elimina el registro.
    ''' </summary>
    Public Function fun_Eliminar_CODIGO_MUPRPROP(ByVal inMPPRVIGE As Integer, _
                                                 ByVal inMPPRTIRE As Integer, _
                                                 ByVal inMPPRRESO As Integer, _
                                                 ByVal inMPPRNUFI As Integer, _
                                                 ByVal inMPPRNURE As Integer, _
                                                 ByVal inMPPRNUDO As String) As Boolean

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "DELETE "
            stConsultaSQL += "MUPRPROP "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "MPPRVIGE = '" & CInt(inMPPRVIGE) & "' AND "
            stConsultaSQL += "MPPRTIRE = '" & CInt(inMPPRTIRE) & "' AND "
            stConsultaSQL += "MPPRRESO = '" & CInt(inMPPRRESO) & "' AND "
            stConsultaSQL += "MPPRNUFI = '" & CInt(inMPPRNUFI) & "' AND "
            stConsultaSQL += "MPPRNURE = '" & CInt(inMPPRNURE) & "' AND "
            stConsultaSQL += "MPPRNUDO = '" & CInt(inMPPRNUDO) & "' "

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
            MessageBox.Show(Err.Description & " " & "fun_Eliminar_MUPRPROP")
        End Try

    End Function

    ''' <summary>
    ''' Función que Modifica el registro.
    ''' </summary>
    Public Function fun_Actualizar_MUPRPROP(ByVal inMPPRIDRE As Integer, _
                                            ByVal inMPPRSECU As Integer, _
                                            ByVal inMPPRVIGE As Integer, _
                                            ByVal inMPPRTIRE As Integer, _
                                            ByVal inMPPRRESO As Integer, _
                                            ByVal inMPPRNUFI As Integer, _
                                            ByVal inMPPRNURE As Integer, _
                                            ByVal stMPPRNUDO As String, _
                                            ByVal inMPPRNOVC As Integer, _
                                            ByVal inMPPRTIDO As Integer, _
                                            ByVal stMPPRMAIN As String, _
                                            ByVal stMPPRCIRE As String, _
                                            ByVal stMPPRESCR As String, _
                                            ByVal stMPPRFEES As String, _
                                            ByVal stMPPRVACO As String, _
                                            ByVal stMPPRENTI As String, _
                                            ByVal stMPPRDENO As String, _
                                            ByVal stMPPRMUNO As String, _
                                            ByVal stMPPRFAEN As String, _
                                            ByVal stMPPRDERE As String, _
                                            ByVal stMPPRGRAV As String, _
                                            ByVal stMPPRFERE As String, _
                                            ByVal stMPPRLIRE As String, _
                                            ByVal stMPPRTORE As String, _
                                            ByVal stMPPRPARE As String, _
                                            ByVal stMPPRCOFI As String, _
                                            ByVal stMPPRNOFI As String, _
                                            ByVal stMPPRPRNO As String, _
                                            ByVal stMPPRSENO As String, _
                                            ByVal stMPPRPRAP As String, _
                                            ByVal stMPPRSEAP As String, _
                                            ByVal stMPPRRASO As String, _
                                            ByVal stMPPRTELE As String, _
                                            ByVal stMPPRCOEL As String, _
                                            ByVal stMPPRCELU As String, _
                                            ByVal stMPPRDIRE As String, _
                                            ByVal stMPPRSICO As String, _
                                            ByVal inMPPRCAPR As Integer, _
                                            ByVal inMPPRSEXO As Integer, _
                                            ByVal stMPPRESTA As String) As Boolean

        Try

            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "UPDATE "
            stConsultaSQL += "MUPRPROP "

            stConsultaSQL += "SET "
            stConsultaSQL += "MPPRSECU = '" & CInt(inMPPRSECU) & "', "
            stConsultaSQL += "MPPRVIGE = '" & CInt(inMPPRVIGE) & "', "
            stConsultaSQL += "MPPRTIRE = '" & CInt(inMPPRTIRE) & "', "
            stConsultaSQL += "MPPRRESO = '" & CInt(inMPPRRESO) & "', "
            stConsultaSQL += "MPPRNUFI = '" & CInt(inMPPRNUFI) & "', "
            stConsultaSQL += "MPPRNURE = '" & CInt(inMPPRNURE) & "', "
            stConsultaSQL += "MPPRNUDO = '" & CStr(Trim(stMPPRNUDO)) & "', "
            stConsultaSQL += "MPPRNOVC = '" & CInt(inMPPRNOVC) & "', "
            stConsultaSQL += "MPPRTIDO = '" & CInt(inMPPRTIDO) & "', "
            stConsultaSQL += "MPPRMAIN = '" & CStr(Trim(stMPPRMAIN)) & "', "
            stConsultaSQL += "MPPRCIRE = '" & CStr(Trim(stMPPRCIRE)) & "', "
            stConsultaSQL += "MPPRESCR = '" & CStr(Trim(stMPPRESCR)) & "', "
            stConsultaSQL += "MPPRFEES = '" & CStr(Trim(stMPPRFEES)) & "', "
            stConsultaSQL += "MPPRVACO = '" & CStr(Trim(stMPPRVACO)) & "', "
            stConsultaSQL += "MPPRENTI = '" & CStr(Trim(stMPPRENTI)) & "', "
            stConsultaSQL += "MPPRDENO = '" & CStr(Trim(stMPPRDENO)) & "', "
            stConsultaSQL += "MPPRMUNO = '" & CStr(Trim(stMPPRMUNO)) & "', "
            stConsultaSQL += "MPPRFAEN = '" & CStr(Trim(stMPPRFAEN)) & "', "
            stConsultaSQL += "MPPRDERE = '" & CStr(Trim(stMPPRDERE)) & "', "
            stConsultaSQL += "MPPRGRAV = '" & CStr(Trim(stMPPRGRAV)) & "', "
            stConsultaSQL += "MPPRFERE = '" & CStr(Trim(stMPPRFERE)) & "', "
            stConsultaSQL += "MPPRLIRE = '" & CStr(Trim(stMPPRLIRE)) & "', "
            stConsultaSQL += "MPPRTORE = '" & CStr(Trim(stMPPRTORE)) & "', "
            stConsultaSQL += "MPPRPARE = '" & CStr(Trim(stMPPRPARE)) & "', "
            stConsultaSQL += "MPPRCOFI = '" & CStr(Trim(stMPPRCOFI)) & "', "
            stConsultaSQL += "MPPRNOFI = '" & CStr(Trim(stMPPRNOFI)) & "', "
            stConsultaSQL += "MPPRPRNO = '" & CStr(Trim(stMPPRPRNO)) & "', "
            stConsultaSQL += "MPPRSENO = '" & CStr(Trim(stMPPRSENO)) & "', "
            stConsultaSQL += "MPPRPRAP = '" & CStr(Trim(stMPPRPRAP)) & "', "
            stConsultaSQL += "MPPRSEAP = '" & CStr(Trim(stMPPRSEAP)) & "', "
            stConsultaSQL += "MPPRRASO = '" & CStr(Trim(stMPPRRASO)) & "', "
            stConsultaSQL += "MPPRTELE = '" & CStr(Trim(stMPPRTELE)) & "', "
            stConsultaSQL += "MPPRCOEL = '" & CStr(Trim(stMPPRCOEL)) & "', "
            stConsultaSQL += "MPPRCELU = '" & CStr(Trim(stMPPRCELU)) & "', "
            stConsultaSQL += "MPPRDIRE = '" & CStr(Trim(stMPPRDIRE)) & "', "
            stConsultaSQL += "MPPRSICO = '" & CStr(Trim(stMPPRSICO)) & "', "
            stConsultaSQL += "MPPRCAPR = '" & CInt(inMPPRCAPR) & "', "
            stConsultaSQL += "MPPRSEXO = '" & CInt(inMPPRSEXO) & "', "
            stConsultaSQL += "MPPRESTA = '" & CStr(Trim(stMPPRESTA)) & "' "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "MPPRIDRE = '" & CInt(inMPPRIDRE) & "'"

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
            MessageBox.Show(Err.Description & " " & "fun_Actualizar_MUPRPROP")
        End Try

    End Function

    ''' <summary>
    ''' Consulta para llenar el DataGridView y colocar el nombre del encabezado
    ''' de la columna. 
    ''' </summary>
    Public Function fun_Consultar_MUPRPROP() As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "MPPRIDRE, "
            stConsultaSQL += "MPPRSECU, "
            stConsultaSQL += "MPPRVIGE, "
            stConsultaSQL += "MPPRTIRE, "
            stConsultaSQL += "MPPRRESO, "
            stConsultaSQL += "MPPRNUFI, "
            stConsultaSQL += "MPPRNURE, "
            stConsultaSQL += "MPPRNUDO, "
            stConsultaSQL += "MPPRNOVC, "
            stConsultaSQL += "MPPRTIDO, "
            stConsultaSQL += "TIDODESC, "
            stConsultaSQL += "MPPRMAIN, "
            stConsultaSQL += "MPPRCIRE, "
            stConsultaSQL += "MPPRESCR, "
            stConsultaSQL += "MPPRFEES, "
            stConsultaSQL += "MPPRVACO, "
            stConsultaSQL += "MPPRENTI, "
            stConsultaSQL += "MPPRDENO, "
            stConsultaSQL += "MPPRMUNO, "
            stConsultaSQL += "MPPRFAEN, "
            stConsultaSQL += "MPPRDERE, "
            stConsultaSQL += "MPPRGRAV, "
            stConsultaSQL += "MPPRFERE, "
            stConsultaSQL += "MPPRLIRE, "
            stConsultaSQL += "MPPRTORE, "
            stConsultaSQL += "MPPRPARE, "
            stConsultaSQL += "MPPRCOFI, "
            stConsultaSQL += "MPPRNOFI, "
            stConsultaSQL += "MPPRPRNO, "
            stConsultaSQL += "MPPRSENO, "
            stConsultaSQL += "MPPRPRAP, "
            stConsultaSQL += "MPPRSEAP, "
            stConsultaSQL += "MPPRRASO, "
            stConsultaSQL += "MPPRTELE, "
            stConsultaSQL += "MPPRCOEL, "
            stConsultaSQL += "MPPRCELU, "
            stConsultaSQL += "MPPRDIRE, "
            stConsultaSQL += "MPPRSICO, "
            stConsultaSQL += "MPPRCAPR, "
            stConsultaSQL += "MPPRSEXO, "
            stConsultaSQL += "SEXODESC, "
            stConsultaSQL += "MPPRESTA, "
            stConsultaSQL += "ESTADESC "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MUPRPROP, ESTADO, MANT_TIPODOCU, MANT_SEXO "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "MPPRESTA = ESTACODI AND "
            stConsultaSQL += "MPPRTIDO = TIDOCODI AND "
            stConsultaSQL += "MPPRSEXO = SEXOCODI "

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "MPPRVIGE, MPPRTIRE, MPPRRESO "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Consultar_MUPRPROP")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Llena el ComboBox con datos activos e inactivos formulario principal 
    ''' esta funcion se llama desde el procedimiento "pro_inicializarControles()".
    ''' </summary>
    Public Function fun_Consultar_CAMPOS_MUPRPROP() As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MUPRPROP "

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "MPPRVIGE, MPPRTIRE, MPPRRESO "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Consultar_CAMPOS_MUPRPROP")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Llena el ComboBox con datos activos formulario insertar y modificar 
    ''' esta funcion se llama desde el procedimiento "pro_inicializarControles()".
    ''' </summary>
    Public Function fun_Consultar_MUPRPROP_X_ESTADO() As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MUPRPROP "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "MPPRESTA = 'ac' "

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "MPPRVIGE, MPPRTIRE, MPPRRESO "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Consultar_MUPRPROP_X_ESTADO")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que busca el ID del registro a modificar o eliminar.
    ''' </summary>
    Public Function fun_Buscar_ID_MUPRPROP(ByVal inMPPRIDRE As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MUPRPROP "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "MPPRIDRE = '" & CInt(inMPPRIDRE) & "'"

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Buscar_ID_MUPRPROP")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que busca el nro registro del registro a modificar o eliminar.
    ''' </summary>
    Public Function fun_Buscar_NURE_X_MUPRPROP(ByVal inMPPRNURE As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MUPRPROP "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "MPPRNURE = '" & CInt(inMPPRNURE) & "'"

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Buscar_ID_MUPRPROP")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que busca el ID del registro a modificar o eliminar.
    ''' </summary>
    Public Function fun_Buscar_CODIGO_X_MUPRPROP(ByVal inMPPRVIGE As Integer, _
                                                 ByVal inMPPRTIRE As Integer, _
                                                 ByVal inMPPRRESO As Integer, _
                                                 ByVal inMPPRNUFI As Integer, _
                                                 ByVal inMPPRNURE As Integer, _
                                                 ByVal inMPPRNUDO As String) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MUPRPROP "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "MPPRVIGE = '" & CInt(inMPPRVIGE) & "' AND "
            stConsultaSQL += "MPPRTIRE = '" & CInt(inMPPRTIRE) & "' AND "
            stConsultaSQL += "MPPRRESO = '" & CInt(inMPPRRESO) & "' AND "
            stConsultaSQL += "MPPRNUFI = '" & CInt(inMPPRNUFI) & "' AND "
            stConsultaSQL += "MPPRNURE = '" & CInt(inMPPRNURE) & "' AND "
            stConsultaSQL += "MPPRNUDO = '" & CStr(Trim(inMPPRNUDO)) & "' "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Buscar_ID_MUPRPROP")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que busca el CÓDIGO para que no se 
    ''' guarden registros duplicados.
    ''' </summary>
    Public Function fun_Buscar_CODIGO_X_MUPRPROP(ByVal inMPPRSECU As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MUPRPROP "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "MPPRSECU = '" & CInt(inMPPRSECU) & "' "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Buscar_CODIGO_MUPRPROP")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que busca el ID del codigo buscado para ejecutar la consulta
    ''' parametrizada.
    ''' </summary>
    Public Function fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_MUPRPROP(ByVal inMPPRIDRE As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "MPPRIDRE, "
            stConsultaSQL += "MPPRSECU, "
            stConsultaSQL += "MPPRVIGE, "
            stConsultaSQL += "MPPRTIRE, "
            stConsultaSQL += "MPPRRESO, "
            stConsultaSQL += "MPPRNUFI, "
            stConsultaSQL += "MPPRNURE, "
            stConsultaSQL += "MPPRNUDO, "
            stConsultaSQL += "MPPRNOVC, "
            stConsultaSQL += "MPPRTIDO, "
            stConsultaSQL += "TIDODESC, "
            stConsultaSQL += "MPPRMAIN, "
            stConsultaSQL += "MPPRCIRE, "
            stConsultaSQL += "MPPRESCR, "
            stConsultaSQL += "MPPRFEES, "
            stConsultaSQL += "MPPRVACO, "
            stConsultaSQL += "MPPRENTI, "
            stConsultaSQL += "MPPRDENO, "
            stConsultaSQL += "MPPRMUNO, "
            stConsultaSQL += "MPPRFAEN, "
            stConsultaSQL += "MPPRDERE, "
            stConsultaSQL += "MPPRGRAV, "
            stConsultaSQL += "MPPRFERE, "
            stConsultaSQL += "MPPRLIRE, "
            stConsultaSQL += "MPPRTORE, "
            stConsultaSQL += "MPPRPARE, "
            stConsultaSQL += "MPPRCOFI, "
            stConsultaSQL += "MPPRNOFI, "
            stConsultaSQL += "MPPRPRNO, "
            stConsultaSQL += "MPPRSENO, "
            stConsultaSQL += "MPPRPRAP, "
            stConsultaSQL += "MPPRSEAP, "
            stConsultaSQL += "MPPRRASO, "
            stConsultaSQL += "MPPRTELE, "
            stConsultaSQL += "MPPRCOEL, "
            stConsultaSQL += "MPPRCELU, "
            stConsultaSQL += "MPPRDIRE, "
            stConsultaSQL += "MPPRSICO, "
            stConsultaSQL += "MPPRCAPR, "
            stConsultaSQL += "MPPRSEXO, "
            stConsultaSQL += "CAPRDESC, "
            stConsultaSQL += "SEXODESC, "
            stConsultaSQL += "MPPRESTA, "
            stConsultaSQL += "ESTADESC "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MUPRPROP, ESTADO, MANT_TIPODOCU, MANT_SEXO, MANT_CALIPROP "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "MPPRESTA = ESTACODI AND "
            stConsultaSQL += "MPPRTIDO = TIDOCODI AND "
            stConsultaSQL += "MPPRSEXO = SEXOCODI AND "
            stConsultaSQL += "MPPRCAPR = CAPRCODI AND "
            stConsultaSQL += "MPPRIDRE = '" & CInt(inMPPRIDRE) & "'"

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "MPPRNURE "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception

            MessageBox.Show(Err.Description & " " & "fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_MUPRPROP")
            Return Nothing

        End Try

    End Function

    ''' <summary>
    ''' Función que busca el SECU del codigo buscado para ejecutar la consulta
    ''' parametrizada.
    ''' </summary>
    Public Function fun_Buscar_SECU_X_CONSULTA_PARAMETRIZADA_MUPRPROP(ByVal inMPPRSECU As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "MPPRIDRE, "
            stConsultaSQL += "MPPRSECU, "
            stConsultaSQL += "MPPRVIGE, "
            stConsultaSQL += "MPPRTIRE, "
            stConsultaSQL += "MPPRRESO, "
            stConsultaSQL += "MPPRNUFI, "
            stConsultaSQL += "MPPRNURE, "
            stConsultaSQL += "MPPRNUDO, "
            stConsultaSQL += "MPPRNOVC, "
            stConsultaSQL += "MPPRTIDO, "
            stConsultaSQL += "TIDODESC, "
            stConsultaSQL += "MPPRMAIN, "
            stConsultaSQL += "MPPRCIRE, "
            stConsultaSQL += "MPPRESCR, "
            stConsultaSQL += "MPPRFEES, "
            stConsultaSQL += "MPPRVACO, "
            stConsultaSQL += "MPPRENTI, "
            stConsultaSQL += "MPPRDENO, "
            stConsultaSQL += "MPPRMUNO, "
            stConsultaSQL += "MPPRFAEN, "
            stConsultaSQL += "MPPRDERE, "
            stConsultaSQL += "MPPRGRAV, "
            stConsultaSQL += "MPPRFERE, "
            stConsultaSQL += "MPPRLIRE, "
            stConsultaSQL += "MPPRTORE, "
            stConsultaSQL += "MPPRPARE, "
            stConsultaSQL += "MPPRCOFI, "
            stConsultaSQL += "MPPRNOFI, "
            stConsultaSQL += "MPPRPRNO, "
            stConsultaSQL += "MPPRSENO, "
            stConsultaSQL += "MPPRPRAP, "
            stConsultaSQL += "MPPRSEAP, "
            stConsultaSQL += "MPPRRASO, "
            stConsultaSQL += "MPPRTELE, "
            stConsultaSQL += "MPPRCOEL, "
            stConsultaSQL += "MPPRCELU, "
            stConsultaSQL += "MPPRDIRE, "
            stConsultaSQL += "MPPRSICO, "
            stConsultaSQL += "MPPRCAPR, "
            stConsultaSQL += "MPPRSEXO, "
            stConsultaSQL += "CAPRDESC, "
            stConsultaSQL += "SEXODESC, "
            stConsultaSQL += "MPPRESTA, "
            stConsultaSQL += "ESTADESC "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MUPRPROP, ESTADO, MANT_TIPODOCU, MANT_SEXO, MANT_CALIPROP "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "MPPRESTA = ESTACODI AND "
            stConsultaSQL += "MPPRTIDO = TIDOCODI AND "
            stConsultaSQL += "MPPRSEXO = SEXOCODI AND "
            stConsultaSQL += "MPPRCAPR = CAPRCODI AND "
            stConsultaSQL += "MPPRSECU = '" & CInt(inMPPRSECU) & "'"

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "MPPRNURE "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception

            MessageBox.Show(Err.Description & " " & "fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_MUPRPROP")
            Return Nothing

        End Try

    End Function

    ''' <summary>
    ''' Función que busca la secuencia maxima
    ''' </summary>
    Public Function fun_Buscar_SECUENCIA_X_MUPRPROP(ByVal inMPPRVIGE As Integer, _
                                                    ByVal inMPPRTIRE As Integer, _
                                                    ByVal inMPPRRESO As Integer, _
                                                    ByVal inMPPRNUFI As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "MPPRNURE "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MUPRPROP "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "MPPRVIGE = '" & CInt(inMPPRVIGE) & "' AND "
            stConsultaSQL += "MPPRTIRE = '" & CInt(inMPPRTIRE) & "' AND "
            stConsultaSQL += "MPPRRESO = '" & CInt(inMPPRRESO) & "' AND "
            stConsultaSQL += "MPPRNUFI = '" & CInt(inMPPRNUFI) & "' "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Buscar_SECUENCIA_MAXINA_X_MUPRPROP")
            Return Nothing
        End Try

    End Function

End Class
