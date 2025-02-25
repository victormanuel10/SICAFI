Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration
Imports DATOS

Public Class cla_SUJEIMPU

    '================================
    '*** CLASE SUJETO DE IMPUESTO ***
    '================================

    ''' <summary>
    ''' procedimiento que verifica la llave primaria.
    ''' </summary>
    Public Function fun_Verifica_llave_Primaria_SUJEIMPU(ByVal obSUIMNUFI As Object) As Boolean

        Try
            Dim boRespuesta As Boolean = False

            Dim obVerifica As New cla_Verificar_Dato

            If obVerifica.fun_Verificar_Campo_Lleno(obSUIMNUFI.Text) = True Then

                If obVerifica.fun_Verificar_Dato_Numerico(obSUIMNUFI.Text) = True Then

                    Dim objdatos1 As New cla_SUJEIMPU
                    Dim tbl As New DataTable

                    tbl = objdatos1.fun_Buscar_CODIGO_NUFI_X_SUJEIMPU(obSUIMNUFI.Text)

                    If tbl.Rows.Count > 0 Then
                        MessageBox.Show("El dato " & Trim(obSUIMNUFI.Text) & " - " & " existe en la base de datos.", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                        obSUIMNUFI.Focus()
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
    Public Function fun_Insertar_SUJEIMPU(ByVal inSUIMNUFI As Integer, _
                                            ByVal stSUIMSUAC As String, _
                                            ByVal stSUIMSUAN As String, _
                                            ByVal stSUIMDEPA As String, _
                                            ByVal stSUIMMUNI As String, _
                                            ByVal stSUIMCORR As String, _
                                            ByVal stSUIMBARR As String, _
                                            ByVal stSUIMMANZ As String, _
                                            ByVal stSUIMPRED As String, _
                                            ByVal stSUIMEDIF As String, _
                                            ByVal stSUIMUNPR As String, _
                                            ByVal stSUIMCLSE As String, _
                                            ByVal inSUIMCAPR As Integer, _
                                            ByVal stSUIMDIRE As String, _
                                            ByVal stSUIMDESC As String, _
                                            ByVal stSUIMVIAC As String, _
                                            ByVal stSUIMVIAN As String, _
                                            ByVal stSUIMMAIN As String, _
                                            ByVal boSUIMPRNU As Boolean, _
                                            ByVal boSUIMPRCA As Boolean, _
                                            ByVal boSUIMMANU As Boolean, _
                                            ByVal boSUIMMACA As Boolean, _
                                            ByVal stSUIMNI01 As String, _
                                            ByVal stSUIMNI02 As String, _
                                            ByVal stSUIMNI03 As String, _
                                            ByVal stSUIMNI04 As String, _
                                            ByVal stSUIMNI05 As String, _
                                            ByVal stSUIMNI06 As String, _
                                            ByVal stSUIMNI07 As String, _
                                            ByVal stSUIMNI08 As String, _
                                            ByVal stSUIMNI09 As String, _
                                            ByVal stSUIMNI10 As String, _
                                            ByVal stSUIMNI11 As String, _
                                            ByVal stSUIMNI12 As String, _
                                            ByVal stSUIMNI13 As String, _
                                            ByVal stSUIMNI14 As String, _
                                            ByVal stSUIMNI15 As String, _
                                            ByVal stSUIMNI16 As String, _
                                            ByVal stSUIMNI17 As String, _
                                            ByVal stSUIMNI18 As String, _
                                            ByVal stSUIMNI19 As String, _
                                            ByVal stSUIMNI20 As String, _
                                            ByVal stSUIMNI21 As String, _
                                            ByVal stSUIMNI22 As String, _
                                            ByVal stSUIMNI23 As String, _
                                            ByVal stSUIMNI24 As String, _
                                            ByVal stSUIMNI25 As String, _
                                            ByVal stSUIMNI26 As String, _
                                            ByVal stSUIMNI27 As String, _
                                            ByVal stSUIMNI28 As String, _
                                            ByVal stSUIMNI29 As String, _
                                            ByVal stSUIMNI30 As String, _
                                            ByVal stSUIMESTA As String, _
                                            ByVal stSUIMCOMU As String, _
                                            ByVal stSUIMCOMA As String, _
                                            ByVal stSUIMDEAN As String, _
                                            ByVal stSUIMMUAN As String, _
                                            ByVal stSUIMCOAN As String, _
                                            ByVal stSUIMBAAN As String, _
                                            ByVal stSUIMMAAN As String, _
                                            ByVal stSUIMPRAN As String, _
                                            ByVal stSUIMEDAN As String, _
                                            ByVal stSUIMUPAN As String, _
                                            ByVal stSUIMCSAN As String, _
                                            ByVal inSUIMMOAD As Integer, _
                                            ByVal boSUIMMEJO As Boolean, _
                                            ByVal boSUIMPRRE As Boolean) As Boolean

        Try

            ' variables del sistema
            Dim stSUIMUSIN As String = vp_usuario
            Dim stSUIMUSMO As String = ""
            Dim daSUIMFEIN As Date = fun_fecha()
            Dim daSUIMFEMO As Date = fun_fecha()
            Dim stSUIMMAQU As String = fun_Nombre_de_maquina()

            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "INSERT INTO "
            stConsultaSQL += "SUJEIMPU "

            stConsultaSQL += "( "
            stConsultaSQL += "SUIMNUFI, "
            stConsultaSQL += "SUIMSUAC, "
            stConsultaSQL += "SUIMSUAN, "
            stConsultaSQL += "SUIMDEPA, "
            stConsultaSQL += "SUIMMUNI, "
            stConsultaSQL += "SUIMCORR, "
            stConsultaSQL += "SUIMBARR, "
            stConsultaSQL += "SUIMMANZ, "
            stConsultaSQL += "SUIMPRED, "
            stConsultaSQL += "SUIMEDIF, "
            stConsultaSQL += "SUIMUNPR, "
            stConsultaSQL += "SUIMCLSE, "
            stConsultaSQL += "SUIMCAPR, "
            stConsultaSQL += "SUIMDIRE, "
            stConsultaSQL += "SUIMDESC, "
            stConsultaSQL += "SUIMVIAC, "
            stConsultaSQL += "SUIMVIAN, "
            stConsultaSQL += "SUIMMAIN, "
            stConsultaSQL += "SUIMPRNU, "
            stConsultaSQL += "SUIMPRCA, "
            stConsultaSQL += "SUIMMANU, "
            stConsultaSQL += "SUIMMACA, "
            stConsultaSQL += "SUIMNI01, "
            stConsultaSQL += "SUIMNI02, "
            stConsultaSQL += "SUIMNI03, "
            stConsultaSQL += "SUIMNI04, "
            stConsultaSQL += "SUIMNI05, "
            stConsultaSQL += "SUIMNI06, "
            stConsultaSQL += "SUIMNI07, "
            stConsultaSQL += "SUIMNI08, "
            stConsultaSQL += "SUIMNI09, "
            stConsultaSQL += "SUIMNI10, "
            stConsultaSQL += "SUIMNI11, "
            stConsultaSQL += "SUIMNI12, "
            stConsultaSQL += "SUIMNI13, "
            stConsultaSQL += "SUIMNI14, "
            stConsultaSQL += "SUIMNI15, "
            stConsultaSQL += "SUIMNI16, "
            stConsultaSQL += "SUIMNI17, "
            stConsultaSQL += "SUIMNI18, "
            stConsultaSQL += "SUIMNI19, "
            stConsultaSQL += "SUIMNI20, "
            stConsultaSQL += "SUIMNI21, "
            stConsultaSQL += "SUIMNI22, "
            stConsultaSQL += "SUIMNI23, "
            stConsultaSQL += "SUIMNI24, "
            stConsultaSQL += "SUIMNI25, "
            stConsultaSQL += "SUIMNI26, "
            stConsultaSQL += "SUIMNI27, "
            stConsultaSQL += "SUIMNI28, "
            stConsultaSQL += "SUIMNI29, "
            stConsultaSQL += "SUIMNI30, "
            stConsultaSQL += "SUIMUSIN, "
            stConsultaSQL += "SUIMUSMO, "
            stConsultaSQL += "SUIMFEIN, "
            stConsultaSQL += "SUIMFEMO, "
            stConsultaSQL += "SUIMMAQU, "
            stConsultaSQL += "SUIMESTA, "
            stConsultaSQL += "SUIMCOMU, "
            stConsultaSQL += "SUIMCOMA, "
            stConsultaSQL += "SUIMDEAN, "
            stConsultaSQL += "SUIMMUAN, "
            stConsultaSQL += "SUIMCOAN, "
            stConsultaSQL += "SUIMBAAN, "
            stConsultaSQL += "SUIMMAAN, "
            stConsultaSQL += "SUIMPRAN, "
            stConsultaSQL += "SUIMEDAN, "
            stConsultaSQL += "SUIMUPAN, "
            stConsultaSQL += "SUIMCSAN, "
            stConsultaSQL += "SUIMMOAD, "
            stConsultaSQL += "SUIMMEJO, "
            stConsultaSQL += "SUIMPRRE  "
            stConsultaSQL += ") "

            stConsultaSQL += "VALUES "

            stConsultaSQL += "( "
            stConsultaSQL += "'" & CInt(inSUIMNUFI) & "', "
            stConsultaSQL += "'" & CStr(Trim(stSUIMSUAC)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stSUIMSUAN)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stSUIMDEPA)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stSUIMMUNI)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stSUIMCORR)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stSUIMBARR)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stSUIMMANZ)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stSUIMPRED)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stSUIMEDIF)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stSUIMUNPR)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stSUIMCLSE)) & "', "
            stConsultaSQL += "'" & CInt(inSUIMCAPR) & "', "
            stConsultaSQL += "'" & CStr(Trim(stSUIMDIRE)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stSUIMDESC)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stSUIMVIAC)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stSUIMVIAN)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stSUIMMAIN)) & "', "
            stConsultaSQL += "'" & CBool(boSUIMPRNU) & "', "
            stConsultaSQL += "'" & CBool(boSUIMPRCA) & "', "
            stConsultaSQL += "'" & CBool(boSUIMMANU) & "', "
            stConsultaSQL += "'" & CBool(boSUIMMACA) & "', "
            stConsultaSQL += "'" & CStr(Trim(stSUIMNI01)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stSUIMNI02)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stSUIMNI03)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stSUIMNI04)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stSUIMNI05)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stSUIMNI06)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stSUIMNI07)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stSUIMNI08)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stSUIMNI09)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stSUIMNI10)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stSUIMNI11)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stSUIMNI12)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stSUIMNI13)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stSUIMNI14)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stSUIMNI15)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stSUIMNI16)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stSUIMNI17)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stSUIMNI18)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stSUIMNI19)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stSUIMNI20)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stSUIMNI21)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stSUIMNI22)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stSUIMNI23)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stSUIMNI24)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stSUIMNI25)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stSUIMNI26)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stSUIMNI27)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stSUIMNI28)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stSUIMNI29)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stSUIMNI30)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stSUIMUSIN)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stSUIMUSMO)) & "', "
            stConsultaSQL += "'" & CDate(daSUIMFEIN) & "', "
            stConsultaSQL += "'" & CDate(daSUIMFEMO) & "', "
            stConsultaSQL += "'" & CStr(Trim(stSUIMMAQU)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stSUIMESTA)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stSUIMCOMU)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stSUIMCOMA)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stSUIMDEAN)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stSUIMMUAN)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stSUIMCOAN)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stSUIMBAAN)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stSUIMMAAN)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stSUIMPRAN)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stSUIMEDAN)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stSUIMUPAN)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stSUIMCSAN)) & "', "
            stConsultaSQL += "'" & CInt(inSUIMMOAD) & "', "
            stConsultaSQL += "'" & CBool(boSUIMMEJO) & "', "
            stConsultaSQL += "'" & CBool(boSUIMPRRE) & "'  "
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
            MessageBox.Show(Err.Description & " " & "fun_Insertar_SUJEIMPU")
        End Try

    End Function

    ''' <summary>
    ''' Función que Elimina el registro.
    ''' </summary>
    Public Function fun_Eliminar_ID_SUJEIMPU(ByVal inSUIMIDRE As Integer) As Boolean

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "DELETE "
            stConsultaSQL += "SUJEIMPU "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "SUIMIDRE = '" & CInt(inSUIMIDRE) & "' "

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
            MessageBox.Show(Err.Description & " " & "fun_Eliminar_SUJEIMPU")
        End Try

    End Function

    ''' <summary>
    ''' elimina por el numero de la ficha predial
    ''' </summary>
    Public Function fun_Eliminar_NUFI_X_SUJEIMPU(ByVal inSUIMNUFI As Integer) As Boolean

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "DELETE "
            stConsultaSQL += "SUJEIMPU "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "SUIMNUFI = '" & CInt(inSUIMNUFI) & "' "

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
            MessageBox.Show(Err.Description & " " & "fun_Eliminar_SUJEIMPU")
        End Try

    End Function

    ''' <summary>
    ''' elimina por el numero del sujeto de impuesto
    ''' </summary>
    Public Function fun_Eliminar_SUIM_X_SUJEIMPU(ByVal stSUIMSUIM As String) As Boolean

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "DELETE "
            stConsultaSQL += "SUJEIMPU "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "SUIMSUIM = '" & CStr(Trim(stSUIMSUIM)) & "' "

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
            MessageBox.Show(Err.Description & " " & "fun_Eliminar_SUIM_X_SUJEIMPU")
        End Try

    End Function

    ''' <summary>
    ''' elimina por el numero de matricula inmobiliaria
    ''' </summary>
    Public Function fun_Eliminar_MAIN_X_SUJEIMPU(ByVal stSUIMMAIN As String) As Boolean

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "DELETE "
            stConsultaSQL += "SUJEIMPU "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "SUIMMAIN = '" & CStr(Trim(stSUIMMAIN)) & "' "

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
            MessageBox.Show(Err.Description & " " & "fun_Eliminar_MAIN_X_SUJEIMPU")
        End Try

    End Function

    ''' <summary>
    ''' elimina por el NRO DE FICHA Y VIGENCIA ACTUAL
    ''' </summary>
    Public Function fun_Eliminar_NUFI_Y_VIAC_X_SUJEIMPU(ByVal inSUIMNUFI As Integer, ByVal stSUIMVIAC As String) As Boolean

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "DELETE "
            stConsultaSQL += "SUJEIMPU "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "SUIMNUFI = '" & CInt(inSUIMNUFI) & "' and "
            stConsultaSQL += "SUIMVIAC = '" & CStr(Trim(stSUIMVIAC)) & "'  "

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
            MessageBox.Show(Err.Description & " " & "fun_Eliminar_SUJEIMPU")
        End Try

    End Function

    ''' <summary>
    ''' elimina por NRO DE FICHA Y VIGENCIA ANTERIOR
    ''' </summary>
    Public Function fun_Eliminar_NUFI_Y_VIAN_X_SUJEIMPU(ByVal inSUIMNUFI As Integer, ByVal stSUIMVIAN As String) As Boolean

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "DELETE "
            stConsultaSQL += "SUJEIMPU "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "SUIMNUFI = '" & CInt(inSUIMNUFI) & "' and "
            stConsultaSQL += "SUIMVIAN = '" & CStr(Trim(stSUIMVIAN)) & "' "

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
            MessageBox.Show(Err.Description & " " & "fun_Eliminar_SUJEIMPU")
        End Try

    End Function

    ''' <summary>
    ''' Función que Modifica el registro.
    ''' </summary>
    Public Function fun_Actualizar_ID_SUJEIMPU(ByVal inSUIMIDRE As Integer, _
                                            ByVal inSUIMNUFI As Integer, _
                                            ByVal stSUIMSUAC As String, _
                                            ByVal stSUIMSUAN As String, _
                                            ByVal stSUIMDEPA As String, _
                                            ByVal stSUIMMUNI As String, _
                                            ByVal stSUIMCORR As String, _
                                            ByVal stSUIMBARR As String, _
                                            ByVal stSUIMMANZ As String, _
                                            ByVal stSUIMPRED As String, _
                                            ByVal stSUIMEDIF As String, _
                                            ByVal stSUIMUNPR As String, _
                                            ByVal stSUIMCLSE As String, _
                                            ByVal inSUIMCAPR As Integer, _
                                            ByVal stSUIMDIRE As String, _
                                            ByVal stSUIMDESC As String, _
                                            ByVal stSUIMVIAC As String, _
                                            ByVal stSUIMVIAN As String, _
                                            ByVal stSUIMMAIN As String, _
                                            ByVal boSUIMPRNU As Boolean, _
                                            ByVal boSUIMPRCA As Boolean, _
                                            ByVal boSUIMMANU As Boolean, _
                                            ByVal boSUIMMACA As Boolean, _
                                            ByVal stSUIMNI01 As String, _
                                            ByVal stSUIMNI02 As String, _
                                            ByVal stSUIMNI03 As String, _
                                            ByVal stSUIMNI04 As String, _
                                            ByVal stSUIMNI05 As String, _
                                            ByVal stSUIMNI06 As String, _
                                            ByVal stSUIMNI07 As String, _
                                            ByVal stSUIMNI08 As String, _
                                            ByVal stSUIMNI09 As String, _
                                            ByVal stSUIMNI10 As String, _
                                            ByVal stSUIMNI11 As String, _
                                            ByVal stSUIMNI12 As String, _
                                            ByVal stSUIMNI13 As String, _
                                            ByVal stSUIMNI14 As String, _
                                            ByVal stSUIMNI15 As String, _
                                            ByVal stSUIMNI16 As String, _
                                            ByVal stSUIMNI17 As String, _
                                            ByVal stSUIMNI18 As String, _
                                            ByVal stSUIMNI19 As String, _
                                            ByVal stSUIMNI20 As String, _
                                            ByVal stSUIMNI21 As String, _
                                            ByVal stSUIMNI22 As String, _
                                            ByVal stSUIMNI23 As String, _
                                            ByVal stSUIMNI24 As String, _
                                            ByVal stSUIMNI25 As String, _
                                            ByVal stSUIMNI26 As String, _
                                            ByVal stSUIMNI27 As String, _
                                            ByVal stSUIMNI28 As String, _
                                            ByVal stSUIMNI29 As String, _
                                            ByVal stSUIMNI30 As String, _
                                            ByVal stSUIMESTA As String, _
                                            ByVal stSUIMCOMU As String, _
                                            ByVal stSUIMCOMA As String, _
                                            ByVal stSUIMDEAN As String, _
                                            ByVal stSUIMMUAN As String, _
                                            ByVal stSUIMCOAN As String, _
                                            ByVal stSUIMBAAN As String, _
                                            ByVal stSUIMMAAN As String, _
                                            ByVal stSUIMPRAN As String, _
                                            ByVal stSUIMEDAN As String, _
                                            ByVal stSUIMUPAN As String, _
                                            ByVal stSUIMCSAN As String, _
                                            ByVal inSUIMMOAD As Integer, _
                                            ByVal boSUIMMEJO As Boolean, _
                                            ByVal boSUIMPRRE As Boolean) As Boolean

        Try
            ' variables del sistema
            Dim stSUIMUSMO As String = vp_usuario
            Dim daSUIMFEMO As Date = fun_Hora_y_fecha()
            Dim stSUIMMAQU As String = fun_Nombre_de_maquina()

            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "UPDATE "
            stConsultaSQL += "SUJEIMPU "

            stConsultaSQL += "SET "

            stConsultaSQL += "'" & CInt(inSUIMNUFI) & "', "
            stConsultaSQL += "'" & CStr(Trim(stSUIMSUAC)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stSUIMSUAN)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stSUIMDEPA)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stSUIMMUNI)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stSUIMCORR)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stSUIMBARR)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stSUIMMANZ)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stSUIMPRED)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stSUIMEDIF)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stSUIMUNPR)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stSUIMCLSE)) & "', "
            stConsultaSQL += "'" & CInt(inSUIMCAPR) & "', "
            stConsultaSQL += "'" & CStr(Trim(stSUIMDIRE)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stSUIMDESC)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stSUIMVIAC)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stSUIMVIAN)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stSUIMMAIN)) & "', "
            stConsultaSQL += "'" & CBool(boSUIMPRNU) & "', "
            stConsultaSQL += "'" & CBool(boSUIMPRCA) & "', "
            stConsultaSQL += "'" & CBool(boSUIMMANU) & "', "
            stConsultaSQL += "'" & CBool(boSUIMMACA) & "', "
            stConsultaSQL += "'" & CStr(Trim(stSUIMNI01)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stSUIMNI02)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stSUIMNI03)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stSUIMNI04)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stSUIMNI05)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stSUIMNI06)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stSUIMNI07)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stSUIMNI08)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stSUIMNI09)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stSUIMNI10)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stSUIMNI11)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stSUIMNI12)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stSUIMNI13)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stSUIMNI14)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stSUIMNI15)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stSUIMNI16)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stSUIMNI17)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stSUIMNI18)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stSUIMNI19)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stSUIMNI20)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stSUIMNI21)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stSUIMNI22)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stSUIMNI23)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stSUIMNI24)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stSUIMNI25)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stSUIMNI26)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stSUIMNI27)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stSUIMNI28)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stSUIMNI29)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stSUIMNI30)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stSUIMUSMO)) & "', "
            stConsultaSQL += "'" & CDate(daSUIMFEMO) & "', "
            stConsultaSQL += "'" & CStr(Trim(stSUIMMAQU)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stSUIMESTA)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stSUIMCOMU)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stSUIMCOMA)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stSUIMDEAN)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stSUIMMUAN)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stSUIMCOAN)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stSUIMBAAN)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stSUIMMAAN)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stSUIMPRAN)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stSUIMEDAN)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stSUIMUPAN)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stSUIMCSAN)) & "', "
            stConsultaSQL += "'" & CInt(inSUIMMOAD) & "', "
            stConsultaSQL += "'" & CBool(boSUIMMEJO) & "', "
            stConsultaSQL += "'" & CBool(boSUIMPRRE) & "'  "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "SUIMIDRE = '" & CInt(inSUIMIDRE) & "'"

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
            MessageBox.Show(Err.Description & " " & "fun_Actualizar_SUJEIMPU")
        End Try

    End Function

    ''' <summary>
    ''' Función que Modifica el registro.
    ''' </summary>
    Public Function fun_Actualizar_NUFI_SUJEIMPU(ByVal inSUIMNUFI As Integer, _
                                            ByVal stSUIMSUAC As String, _
                                            ByVal stSUIMSUAN As String, _
                                            ByVal stSUIMDEPA As String, _
                                            ByVal stSUIMMUNI As String, _
                                            ByVal stSUIMCORR As String, _
                                            ByVal stSUIMBARR As String, _
                                            ByVal stSUIMMANZ As String, _
                                            ByVal stSUIMPRED As String, _
                                            ByVal stSUIMEDIF As String, _
                                            ByVal stSUIMUNPR As String, _
                                            ByVal stSUIMCLSE As String, _
                                            ByVal inSUIMCAPR As Integer, _
                                            ByVal stSUIMDIRE As String, _
                                            ByVal stSUIMDESC As String, _
                                            ByVal stSUIMVIAC As String, _
                                            ByVal stSUIMVIAN As String, _
                                            ByVal stSUIMMAIN As String, _
                                            ByVal boSUIMPRNU As Boolean, _
                                            ByVal boSUIMPRCA As Boolean, _
                                            ByVal boSUIMMANU As Boolean, _
                                            ByVal boSUIMMACA As Boolean, _
                                            ByVal stSUIMNI01 As String, _
                                            ByVal stSUIMNI02 As String, _
                                            ByVal stSUIMNI03 As String, _
                                            ByVal stSUIMNI04 As String, _
                                            ByVal stSUIMNI05 As String, _
                                            ByVal stSUIMNI06 As String, _
                                            ByVal stSUIMNI07 As String, _
                                            ByVal stSUIMNI08 As String, _
                                            ByVal stSUIMNI09 As String, _
                                            ByVal stSUIMNI10 As String, _
                                            ByVal stSUIMNI11 As String, _
                                            ByVal stSUIMNI12 As String, _
                                            ByVal stSUIMNI13 As String, _
                                            ByVal stSUIMNI14 As String, _
                                            ByVal stSUIMNI15 As String, _
                                            ByVal stSUIMNI16 As String, _
                                            ByVal stSUIMNI17 As String, _
                                            ByVal stSUIMNI18 As String, _
                                            ByVal stSUIMNI19 As String, _
                                            ByVal stSUIMNI20 As String, _
                                            ByVal stSUIMNI21 As String, _
                                            ByVal stSUIMNI22 As String, _
                                            ByVal stSUIMNI23 As String, _
                                            ByVal stSUIMNI24 As String, _
                                            ByVal stSUIMNI25 As String, _
                                            ByVal stSUIMNI26 As String, _
                                            ByVal stSUIMNI27 As String, _
                                            ByVal stSUIMNI28 As String, _
                                            ByVal stSUIMNI29 As String, _
                                            ByVal stSUIMNI30 As String, _
                                            ByVal stSUIMESTA As String, _
                                            ByVal stSUIMCOMU As String, _
                                            ByVal stSUIMCOMA As String, _
                                            ByVal stSUIMDEAN As String, _
                                            ByVal stSUIMMUAN As String, _
                                            ByVal stSUIMCOAN As String, _
                                            ByVal stSUIMBAAN As String, _
                                            ByVal stSUIMMAAN As String, _
                                            ByVal stSUIMPRAN As String, _
                                            ByVal stSUIMEDAN As String, _
                                            ByVal stSUIMUPAN As String, _
                                            ByVal stSUIMCSAN As String, _
                                            ByVal inSUIMMOAD As Integer, _
                                            ByVal boSUIMMEJO As Boolean, _
                                            ByVal boSUIMPRRE As Boolean) As Boolean

        Try
            ' variables del sistema
            Dim stSUIMUSMO As String = vp_usuario
            Dim daSUIMFEMO As Date = fun_fecha()
            Dim stSUIMMAQU As String = fun_Nombre_de_maquina()

            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "UPDATE "
            stConsultaSQL += "SUJEIMPU "

            stConsultaSQL += "SET "
            stConsultaSQL += "SUIMNUFI = '" & CInt(inSUIMNUFI) & "', "
            stConsultaSQL += "SUIMSUAC = '" & CStr(Trim(stSUIMSUAC)) & "', "
            stConsultaSQL += "SUIMSUAN = '" & CStr(Trim(stSUIMSUAN)) & "', "
            stConsultaSQL += "SUIMDEPA = '" & CStr(Trim(stSUIMDEPA)) & "', "
            stConsultaSQL += "SUIMMUNI = '" & CStr(Trim(stSUIMMUNI)) & "', "
            stConsultaSQL += "SUIMCORR = '" & CStr(Trim(stSUIMCORR)) & "', "
            stConsultaSQL += "SUIMBARR = '" & CStr(Trim(stSUIMBARR)) & "', "
            stConsultaSQL += "SUIMMANZ = '" & CStr(Trim(stSUIMMANZ)) & "', "
            stConsultaSQL += "SUIMPRED = '" & CStr(Trim(stSUIMPRED)) & "', "
            stConsultaSQL += "SUIMEDIF = '" & CStr(Trim(stSUIMEDIF)) & "', "
            stConsultaSQL += "SUIMUNPR = '" & CStr(Trim(stSUIMUNPR)) & "', "
            stConsultaSQL += "SUIMCLSE = '" & CStr(Trim(stSUIMCLSE)) & "', "
            stConsultaSQL += "SUIMCAPR = '" & CInt(inSUIMCAPR) & "', "
            stConsultaSQL += "SUIMDIRE = '" & CStr(Trim(stSUIMDIRE)) & "', "
            stConsultaSQL += "SUIMDESC = '" & CStr(Trim(stSUIMDESC)) & "', "
            stConsultaSQL += "SUIMVIAC = '" & CStr(Trim(stSUIMVIAC)) & "', "
            stConsultaSQL += "SUIMVIAN = '" & CStr(Trim(stSUIMVIAN)) & "', "
            stConsultaSQL += "SUIMMAIN = '" & CStr(Trim(stSUIMMAIN)) & "', "
            stConsultaSQL += "SUIMPRNU = '" & CBool(boSUIMPRNU) & "', "
            stConsultaSQL += "SUIMPRCA = '" & CBool(boSUIMPRCA) & "', "
            stConsultaSQL += "SUIMMANU = '" & CBool(boSUIMMANU) & "', "
            stConsultaSQL += "SUIMMACA = '" & CBool(boSUIMMACA) & "', "
            stConsultaSQL += "SUIMNI01 = '" & CStr(Trim(stSUIMNI01)) & "', "
            stConsultaSQL += "SUIMNI02 = '" & CStr(Trim(stSUIMNI02)) & "', "
            stConsultaSQL += "SUIMNI03 = '" & CStr(Trim(stSUIMNI03)) & "', "
            stConsultaSQL += "SUIMNI04 = '" & CStr(Trim(stSUIMNI04)) & "', "
            stConsultaSQL += "SUIMNI05 = '" & CStr(Trim(stSUIMNI05)) & "', "
            stConsultaSQL += "SUIMNI06 = '" & CStr(Trim(stSUIMNI06)) & "', "
            stConsultaSQL += "SUIMNI07 = '" & CStr(Trim(stSUIMNI07)) & "', "
            stConsultaSQL += "SUIMNI08 = '" & CStr(Trim(stSUIMNI08)) & "', "
            stConsultaSQL += "SUIMNI09 = '" & CStr(Trim(stSUIMNI09)) & "', "
            stConsultaSQL += "SUIMNI10 = '" & CStr(Trim(stSUIMNI10)) & "', "
            stConsultaSQL += "SUIMNI11 = '" & CStr(Trim(stSUIMNI11)) & "', "
            stConsultaSQL += "SUIMNI12 = '" & CStr(Trim(stSUIMNI12)) & "', "
            stConsultaSQL += "SUIMNI13 = '" & CStr(Trim(stSUIMNI13)) & "', "
            stConsultaSQL += "SUIMNI14 = '" & CStr(Trim(stSUIMNI14)) & "', "
            stConsultaSQL += "SUIMNI15 = '" & CStr(Trim(stSUIMNI15)) & "', "
            stConsultaSQL += "SUIMNI16 = '" & CStr(Trim(stSUIMNI16)) & "', "
            stConsultaSQL += "SUIMNI17 = '" & CStr(Trim(stSUIMNI17)) & "', "
            stConsultaSQL += "SUIMNI18 = '" & CStr(Trim(stSUIMNI18)) & "', "
            stConsultaSQL += "SUIMNI19 = '" & CStr(Trim(stSUIMNI19)) & "', "
            stConsultaSQL += "SUIMNI20 = '" & CStr(Trim(stSUIMNI20)) & "', "
            stConsultaSQL += "SUIMNI21 = '" & CStr(Trim(stSUIMNI21)) & "', "
            stConsultaSQL += "SUIMNI22 = '" & CStr(Trim(stSUIMNI22)) & "', "
            stConsultaSQL += "SUIMNI23 = '" & CStr(Trim(stSUIMNI23)) & "', "
            stConsultaSQL += "SUIMNI24 = '" & CStr(Trim(stSUIMNI24)) & "', "
            stConsultaSQL += "SUIMNI25 = '" & CStr(Trim(stSUIMNI25)) & "', "
            stConsultaSQL += "SUIMNI26 = '" & CStr(Trim(stSUIMNI26)) & "', "
            stConsultaSQL += "SUIMNI27 = '" & CStr(Trim(stSUIMNI27)) & "', "
            stConsultaSQL += "SUIMNI28 = '" & CStr(Trim(stSUIMNI28)) & "', "
            stConsultaSQL += "SUIMNI29 = '" & CStr(Trim(stSUIMNI29)) & "', "
            stConsultaSQL += "SUIMNI30 = '" & CStr(Trim(stSUIMNI30)) & "', "
            stConsultaSQL += "SUIMUSMO = '" & CStr(Trim(stSUIMUSMO)) & "', "
            stConsultaSQL += "SUIMFEMO = '" & CDate(daSUIMFEMO) & "', "
            stConsultaSQL += "SUIMMAQU = '" & CStr(Trim(stSUIMMAQU)) & "', "
            stConsultaSQL += "SUIMESTA = '" & CStr(Trim(stSUIMESTA)) & "', "
            stConsultaSQL += "SUIMCOMU = '" & CStr(Trim(stSUIMCOMU)) & "', "
            stConsultaSQL += "SUIMCOMA = '" & CStr(Trim(stSUIMCOMA)) & "', "
            stConsultaSQL += "SUIMDEAN = '" & CStr(Trim(stSUIMDEAN)) & "', "
            stConsultaSQL += "SUIMMUAN = '" & CStr(Trim(stSUIMMUAN)) & "', "
            stConsultaSQL += "SUIMCOAN = '" & CStr(Trim(stSUIMCOAN)) & "', "
            stConsultaSQL += "SUIMBAAN = '" & CStr(Trim(stSUIMBAAN)) & "', "
            stConsultaSQL += "SUIMMAAN = '" & CStr(Trim(stSUIMMAAN)) & "', "
            stConsultaSQL += "SUIMPRAN = '" & CStr(Trim(stSUIMPRAN)) & "', "
            stConsultaSQL += "SUIMEDAN = '" & CStr(Trim(stSUIMEDAN)) & "', "
            stConsultaSQL += "SUIMUPAN = '" & CStr(Trim(stSUIMUPAN)) & "', "
            stConsultaSQL += "SUIMCSAN = '" & CStr(Trim(stSUIMCSAN)) & "', "
            stConsultaSQL += "SUIMMOAD = '" & CInt(inSUIMMOAD) & "', "
            stConsultaSQL += "SUIMMEJO = '" & CBool(boSUIMMEJO) & "', "
            stConsultaSQL += "SUIMPRRE = '" & CBool(boSUIMPRRE) & "'  "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "SUIMNUFI = '" & CInt(inSUIMNUFI) & "'"

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
            MessageBox.Show(Err.Description & " " & "fun_Actualizar_SUJEIMPU")
        End Try

    End Function

    ''' <summary>
    ''' Consulta para llenar el DataGridView y colocar el nombre del encabezado
    ''' de la columna. 
    ''' </summary>
    Public Function fun_Consultar_SUJEIMPU() As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "SUIMIDRE, "
            stConsultaSQL += "SUIMNUFI, "
            stConsultaSQL += "SUIMSUAC, "
            stConsultaSQL += "SUIMSUAN, "
            stConsultaSQL += "SUIMDEPA, "
            stConsultaSQL += "SUIMMUNI, "
            stConsultaSQL += "SUIMCORR, "
            stConsultaSQL += "SUIMBARR, "
            stConsultaSQL += "SUIMMANZ, "
            stConsultaSQL += "SUIMPRED, "
            stConsultaSQL += "SUIMEDIF, "
            stConsultaSQL += "SUIMUNPR, "
            stConsultaSQL += "SUIMCLSE, "
            stConsultaSQL += "SUIMCAPR, "
            stConsultaSQL += "SUIMDIRE, "
            stConsultaSQL += "SUIMDESC, "
            stConsultaSQL += "SUIMVIAC, "
            stConsultaSQL += "SUIMVIAN, "
            stConsultaSQL += "SUIMMAIN, "
            stConsultaSQL += "SUIMPRNU, "
            stConsultaSQL += "SUIMPRCA, "
            stConsultaSQL += "SUIMMANU, "
            stConsultaSQL += "SUIMMACA, "
            stConsultaSQL += "SUIMNI01, "
            stConsultaSQL += "SUIMNI02, "
            stConsultaSQL += "SUIMNI03, "
            stConsultaSQL += "SUIMNI04, "
            stConsultaSQL += "SUIMNI05, "
            stConsultaSQL += "SUIMNI06, "
            stConsultaSQL += "SUIMNI07, "
            stConsultaSQL += "SUIMNI08, "
            stConsultaSQL += "SUIMNI09, "
            stConsultaSQL += "SUIMNI10, "
            stConsultaSQL += "SUIMNI11, "
            stConsultaSQL += "SUIMNI12, "
            stConsultaSQL += "SUIMNI13, "
            stConsultaSQL += "SUIMNI14, "
            stConsultaSQL += "SUIMNI15, "
            stConsultaSQL += "SUIMNI16, "
            stConsultaSQL += "SUIMNI17, "
            stConsultaSQL += "SUIMNI18, "
            stConsultaSQL += "SUIMNI19, "
            stConsultaSQL += "SUIMNI20, "
            stConsultaSQL += "SUIMNI21, "
            stConsultaSQL += "SUIMNI22, "
            stConsultaSQL += "SUIMNI23, "
            stConsultaSQL += "SUIMNI24, "
            stConsultaSQL += "SUIMNI25, "
            stConsultaSQL += "SUIMNI26, "
            stConsultaSQL += "SUIMNI27, "
            stConsultaSQL += "SUIMNI28, "
            stConsultaSQL += "SUIMNI29, "
            stConsultaSQL += "SUIMNI30, "
            stConsultaSQL += "SUIMUSIN, "
            stConsultaSQL += "SUIMUSMO, "
            stConsultaSQL += "SUIMFEIN, "
            stConsultaSQL += "SUIMFEMO, "
            stConsultaSQL += "SUIMMAQU, "
            stConsultaSQL += "SUIMESTA  "

            stConsultaSQL += "FROM "
            stConsultaSQL += "SUJEIMPU "

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "SUIMMUNI, SUIMCORR, SUIMBARR, SUIMMANZ, SUIMPRED, SUIMEDIF, SUIMUNPR "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Consultar_SUJEIMPU")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Llena el ComboBox con datos activos e inactivos formulario principal 
    ''' esta funcion se llama desde el procedimiento "pro_inicializarControles()".
    ''' </summary>
    Public Function fun_Consultar_CAMPOS_SUJEIMPU() As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "SUJEIMPU "

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "SUIMVIGE "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Consultar_CAMPOS_SUJEIMPU")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Llena el ComboBox con datos activos formulario insertar y modificar 
    ''' esta funcion se llama desde el procedimiento "pro_inicializarControles()".
    ''' </summary>
    Public Function fun_Consultar_SUJEIMPU_X_ESTADO() As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "SUJEIMPU "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "SUIMESTA = 'ac' "

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "SUIMMUNI, SUIMCORR, SUIMBARR, SUIMMANZ, SUIMPRED, SUIMEDIF, SUIMUNPR "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Consultar_SUJEIMPU_X_ESTADO")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que busca el ID del registro a modificar o eliminar.
    ''' </summary>
    Public Function fun_Buscar_ID_SUJEIMPU(ByVal inSUIMIDRE As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "SUJEIMPU "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "SUIMIDRE = '" & CInt(inSUIMIDRE) & "'"

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Buscar_ID_SUJEIMPU")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que busca el CÓDIGO para que no se 
    ''' guarden registros duplicados.
    ''' </summary>
    Public Function fun_Buscar_CODIGO_NUFI_X_SUJEIMPU(ByVal stSUIMNUFI As String) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "SUJEIMPU "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "SUIMNUFI = '" & CInt(stSUIMNUFI) & "' "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Buscar_CODIGO_SUJEIMPU")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que busca el ID del codigo buscado para ejecutar la consulta
    ''' parametrizada.
    ''' </summary>
    Public Function fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_SUJEIMPU(ByVal inSUIMIDRE As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "SUIMIDRE, "
            stConsultaSQL += "SUIMNUFI, "
            stConsultaSQL += "SUIMSUAC, "
            stConsultaSQL += "SUIMSUAN, "
            stConsultaSQL += "SUIMCOMU, "
            stConsultaSQL += "SUIMCOMA, "
            stConsultaSQL += "SUIMDEPA, "
            stConsultaSQL += "SUIMMUNI, "
            stConsultaSQL += "SUIMCORR, "
            stConsultaSQL += "SUIMBARR, "
            stConsultaSQL += "SUIMMANZ, "
            stConsultaSQL += "SUIMPRED, "
            stConsultaSQL += "SUIMEDIF, "
            stConsultaSQL += "SUIMUNPR, "
            stConsultaSQL += "SUIMCLSE, "
            stConsultaSQL += "SUIMDEAN, "
            stConsultaSQL += "SUIMMUAN, "
            stConsultaSQL += "SUIMCOAN, "
            stConsultaSQL += "SUIMBAAN, "
            stConsultaSQL += "SUIMMAAN, "
            stConsultaSQL += "SUIMPRAN, "
            stConsultaSQL += "SUIMEDAN, "
            stConsultaSQL += "SUIMUPAN, "
            stConsultaSQL += "SUIMCSAN, "
            stConsultaSQL += "SUIMMOAD, "
            stConsultaSQL += "SUIMCAPR, "
            stConsultaSQL += "SUIMDIRE, "
            stConsultaSQL += "SUIMDESC, "
            stConsultaSQL += "SUIMVIAC, "
            stConsultaSQL += "SUIMVIAN, "
            stConsultaSQL += "SUIMMAIN, "
            stConsultaSQL += "SUIMPRNU, "
            stConsultaSQL += "SUIMPRCA, "
            stConsultaSQL += "SUIMMANU, "
            stConsultaSQL += "SUIMMACA, "
            stConsultaSQL += "SUIMNI01, "
            stConsultaSQL += "SUIMNI02, "
            stConsultaSQL += "SUIMNI03, "
            stConsultaSQL += "SUIMNI04, "
            stConsultaSQL += "SUIMNI05, "
            stConsultaSQL += "SUIMNI06, "
            stConsultaSQL += "SUIMNI07, "
            stConsultaSQL += "SUIMNI08, "
            stConsultaSQL += "SUIMNI09, "
            stConsultaSQL += "SUIMNI10, "
            stConsultaSQL += "SUIMNI11, "
            stConsultaSQL += "SUIMNI12, "
            stConsultaSQL += "SUIMNI13, "
            stConsultaSQL += "SUIMNI14, "
            stConsultaSQL += "SUIMNI15, "
            stConsultaSQL += "SUIMNI16, "
            stConsultaSQL += "SUIMNI17, "
            stConsultaSQL += "SUIMNI18, "
            stConsultaSQL += "SUIMNI19, "
            stConsultaSQL += "SUIMNI20, "
            stConsultaSQL += "SUIMNI21, "
            stConsultaSQL += "SUIMNI22, "
            stConsultaSQL += "SUIMNI23, "
            stConsultaSQL += "SUIMNI24, "
            stConsultaSQL += "SUIMNI25, "
            stConsultaSQL += "SUIMNI26, "
            stConsultaSQL += "SUIMNI27, "
            stConsultaSQL += "SUIMNI28, "
            stConsultaSQL += "SUIMNI29, "
            stConsultaSQL += "SUIMNI30, "
            stConsultaSQL += "SUIMUSIN, "
            stConsultaSQL += "SUIMUSMO, "
            stConsultaSQL += "SUIMFEIN, "
            stConsultaSQL += "SUIMFEMO, "
            stConsultaSQL += "SUIMMAQU, "
            stConsultaSQL += "SUIMESTA, "
            stConsultaSQL += "SUIMMEJO, "
            stConsultaSQL += "SUIMPRRE "

            stConsultaSQL += "FROM "
            stConsultaSQL += "SUJEIMPU "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "SUIMIDRE = '" & CInt(inSUIMIDRE) & "'"

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "SUIMMUNI, SUIMCORR, SUIMBARR, SUIMMANZ, SUIMPRED, SUIMEDIF, SUIMUNPR "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception

            MessageBox.Show(Err.Description & " " & "fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_SUJEIMPU")
            Return Nothing

        End Try

    End Function

    ''' <summary>
    ''' Función que busca el ID del codigo buscado para ejecutar la consulta
    ''' parametrizada.
    ''' </summary>
    Public Function fun_Buscar_NUFI_X_CONSULTA_PARAMETRIZADA_SUJEIMPU(ByVal inSUIMNUFI As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "SUIMIDRE, "
            stConsultaSQL += "SUIMNUFI, "
            stConsultaSQL += "SUIMSUAC, "
            stConsultaSQL += "SUIMSUAN, "
            stConsultaSQL += "SUIMCOMU, "
            stConsultaSQL += "SUIMCOMA, "
            stConsultaSQL += "SUIMDEPA, "
            stConsultaSQL += "SUIMMUNI, "
            stConsultaSQL += "SUIMCORR, "
            stConsultaSQL += "SUIMBARR, "
            stConsultaSQL += "SUIMMANZ, "
            stConsultaSQL += "SUIMPRED, "
            stConsultaSQL += "SUIMEDIF, "
            stConsultaSQL += "SUIMUNPR, "
            stConsultaSQL += "SUIMCLSE, "
            stConsultaSQL += "SUIMDEAN, "
            stConsultaSQL += "SUIMMUAN, "
            stConsultaSQL += "SUIMCOAN, "
            stConsultaSQL += "SUIMBAAN, "
            stConsultaSQL += "SUIMMAAN, "
            stConsultaSQL += "SUIMPRAN, "
            stConsultaSQL += "SUIMEDAN, "
            stConsultaSQL += "SUIMUPAN, "
            stConsultaSQL += "SUIMCSAN, "
            stConsultaSQL += "SUIMMOAD, "
            stConsultaSQL += "SUIMCAPR, "
            stConsultaSQL += "SUIMDIRE, "
            stConsultaSQL += "SUIMDESC, "
            stConsultaSQL += "SUIMVIAC, "
            stConsultaSQL += "SUIMVIAN, "
            stConsultaSQL += "SUIMMAIN, "
            stConsultaSQL += "SUIMPRNU, "
            stConsultaSQL += "SUIMPRCA, "
            stConsultaSQL += "SUIMMANU, "
            stConsultaSQL += "SUIMMACA, "
            stConsultaSQL += "SUIMNI01, "
            stConsultaSQL += "SUIMNI02, "
            stConsultaSQL += "SUIMNI03, "
            stConsultaSQL += "SUIMNI04, "
            stConsultaSQL += "SUIMNI05, "
            stConsultaSQL += "SUIMNI06, "
            stConsultaSQL += "SUIMNI07, "
            stConsultaSQL += "SUIMNI08, "
            stConsultaSQL += "SUIMNI09, "
            stConsultaSQL += "SUIMNI10, "
            stConsultaSQL += "SUIMNI11, "
            stConsultaSQL += "SUIMNI12, "
            stConsultaSQL += "SUIMNI13, "
            stConsultaSQL += "SUIMNI14, "
            stConsultaSQL += "SUIMNI15, "
            stConsultaSQL += "SUIMNI16, "
            stConsultaSQL += "SUIMNI17, "
            stConsultaSQL += "SUIMNI18, "
            stConsultaSQL += "SUIMNI19, "
            stConsultaSQL += "SUIMNI20, "
            stConsultaSQL += "SUIMNI21, "
            stConsultaSQL += "SUIMNI22, "
            stConsultaSQL += "SUIMNI23, "
            stConsultaSQL += "SUIMNI24, "
            stConsultaSQL += "SUIMNI25, "
            stConsultaSQL += "SUIMNI26, "
            stConsultaSQL += "SUIMNI27, "
            stConsultaSQL += "SUIMNI28, "
            stConsultaSQL += "SUIMNI29, "
            stConsultaSQL += "SUIMNI30, "
            stConsultaSQL += "SUIMUSIN, "
            stConsultaSQL += "SUIMUSMO, "
            stConsultaSQL += "SUIMFEIN, "
            stConsultaSQL += "SUIMFEMO, "
            stConsultaSQL += "SUIMMAQU, "
            stConsultaSQL += "SUIMESTA, "
            stConsultaSQL += "SUIMMEJO, "
            stConsultaSQL += "SUIMPRRE "

            stConsultaSQL += "FROM "
            stConsultaSQL += "SUJEIMPU "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "SUIMNUFI = '" & CInt(inSUIMNUFI) & "'"

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "SUIMMUNI, SUIMCORR, SUIMBARR, SUIMMANZ, SUIMPRED, SUIMEDIF, SUIMUNPR "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception

            MessageBox.Show(Err.Description & " " & "fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_SUJEIMPU")
            Return Nothing

        End Try

    End Function

    ''' <summary>
    ''' Función que busca el sujeto con el numero de la ficha
    ''' parametrizada.
    ''' </summary>
    Public Function fun_Consultar_SUJEIMPU_X_NRO_FICHA(ByVal inSUIMNUFI As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "
            stConsultaSQL += "FROM "
            stConsultaSQL += "SUJEIMPU "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "SUIMNUFI = '" & CInt(inSUIMNUFI) & "' "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception

            MessageBox.Show(Err.Description & " " & "fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_SUJEIMPU")
            Return Nothing

        End Try

    End Function

    ''' <summary>
    ''' Función que busca el sujeto con la cedula catastral actual
    ''' parametrizada.
    ''' </summary>
    Public Function fun_Consultar_SUJEIMPU_X_CEDULA_CATASTRAL_ANTERIOR(ByVal stSUIMMUAN As String, _
                                                                       ByVal stSUIMCOAN As String, _
                                                                       ByVal stSUIMBAAN As String, _
                                                                       ByVal stSUIMMAAN As String, _
                                                                       ByVal stSUIMPRAN As String, _
                                                                       ByVal stSUIMEDAN As String, _
                                                                       ByVal stSUIMUPAN As String, _
                                                                       ByVal stSUIMCSAN As String) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "
            stConsultaSQL += "FROM "
            stConsultaSQL += "SUJEIMPU "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "SUIMMUAN = '" & CStr(Trim(stSUIMMUAN)) & "'and "
            stConsultaSQL += "SUIMCOAN = '" & CStr(Trim(stSUIMCOAN)) & "'and "
            stConsultaSQL += "SUIMBAAN = '" & CStr(Trim(stSUIMBAAN)) & "'and "
            stConsultaSQL += "SUIMMAAN = '" & CStr(Trim(stSUIMMAAN)) & "'and "
            stConsultaSQL += "SUIMPRAN = '" & CStr(Trim(stSUIMPRAN)) & "'and "
            stConsultaSQL += "SUIMEDAN = '" & CStr(Trim(stSUIMEDAN)) & "'and "
            stConsultaSQL += "SUIMUPAN = '" & CStr(Trim(stSUIMUPAN)) & "'and "
            stConsultaSQL += "SUIMCSAN = '" & CStr(Trim(stSUIMCSAN)) & "' "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception

            MessageBox.Show(Err.Description & " " & "fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_SUJEIMPU")
            Return Nothing

        End Try

    End Function

    ''' <summary>
    ''' Función que busca el sujeto con la cedula catastral anterior
    ''' parametrizada.
    ''' </summary>
    Public Function fun_Consultar_SUJEIMPU_X_CEDULA_CATASTRAL_ACTUAL(ByVal stSUIMMUNI As String, _
                                                                     ByVal stSUIMCORR As String, _
                                                                     ByVal stSUIMBARR As String, _
                                                                     ByVal stSUIMMANZ As String, _
                                                                     ByVal stSUIMPRED As String, _
                                                                     ByVal stSUIMEDIF As String, _
                                                                     ByVal stSUIMUNPR As String, _
                                                                     ByVal stSUIMCLSE As String) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "
            stConsultaSQL += "FROM "
            stConsultaSQL += "SUJEIMPU "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "SUIMMUNI = '" & CStr(Trim(stSUIMMUNI)) & "'and "
            stConsultaSQL += "SUIMCORR = '" & CStr(Trim(stSUIMCORR)) & "'and "
            stConsultaSQL += "SUIMBARR = '" & CStr(Trim(stSUIMBARR)) & "'and "
            stConsultaSQL += "SUIMMANZ = '" & CStr(Trim(stSUIMMANZ)) & "'and "
            stConsultaSQL += "SUIMPRED = '" & CStr(Trim(stSUIMPRED)) & "'and "
            stConsultaSQL += "SUIMEDIF = '" & CStr(Trim(stSUIMEDIF)) & "'and "
            stConsultaSQL += "SUIMUNPR = '" & CStr(Trim(stSUIMUNPR)) & "'and "
            stConsultaSQL += "SUIMCLSE = '" & CStr(Trim(stSUIMCLSE)) & "' "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception

            MessageBox.Show(Err.Description & " " & "fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_SUJEIMPU")
            Return Nothing

        End Try

    End Function

    ''' <summary>
    ''' Función que consulta el sujeto con la matricula inmobiliaria
    ''' </summary>
    Public Function fun_Consultar_SUJEIMPU_X_MATRICULA(ByVal stSUIMMAIN As String) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "
            stConsultaSQL += "FROM "
            stConsultaSQL += "SUJEIMPU "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "SUIMMAIN = '" & CStr(Trim(stSUIMMAIN)) & "' "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception

            MessageBox.Show(Err.Description & " " & "fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_SUJEIMPU")
            Return Nothing

        End Try

    End Function

End Class
