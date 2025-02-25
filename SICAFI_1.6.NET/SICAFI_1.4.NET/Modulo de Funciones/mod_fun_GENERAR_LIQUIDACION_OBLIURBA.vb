Imports REGLAS_DEL_NEGOCIO
Imports Microsoft.Office.Interop.Word
Imports Microsoft.Office.Interop
Imports System.IO

Module mod_fun_GENERAR_LIQUIDACION_OBLIURBA

    '==================================================================
    '*** GENERA REPORTE DE LIQUIDACION DE OBLIGACIONES URBANISTICAS ***
    '==================================================================

#Region "VARIABLES"

    ' variables tablas
    Dim vl_dtOBLIURBA As New DataTable

    ' variables constructor
    Dim vl_inOBURIDRE As Integer = 0
    Dim vl_inTIPOREPO As Integer = 0
    Dim VL_boOUIGADLI As Boolean = False

    ' variables obligaciones urbanisticas
    Dim vl_inOBURNULI As Integer = 0
    Dim vl_stOBURCLEN As String = ""
    Dim vl_inOBURNURE As Integer = 0
    Dim vl_stOBURFERE As String = ""
    Dim vl_inOBURVIRE As Integer = 0
    Dim vl_inOBURVIAC As Integer = 0

    ' variables solicitante
    Dim vl_stOUSOPROY As String = ""
    Dim vl_stOUSONOMB As String = ""
    Dim vl_stOUSODIPR As String = ""
    Dim vl_stOUSONUDO As String = ""

    ' variables de predio
    Dim vl_stOUPRDEPA As String = "05"
    Dim vl_stOUPRMUNI As String = ""
    Dim vl_stOUPRCORR As String = ""
    Dim vl_stOUPRBARR As String = ""
    Dim vl_stOUPRMANZ As String = ""
    Dim vl_stOUPRPRED As String = ""
    Dim vl_stOUPREDIF As String = ""
    Dim vl_stOUPRUNPR As String = ""
    Dim vl_stOUPRCLSE As String = ""
    Dim vl_stBARRDESC As String = ""
    Dim vl_stOUPRCECA_1 As String = ""
    Dim vl_stOUPRCECA_2 As String = ""
    Dim vl_stOUPRCECA_3 As String = ""
    Dim vl_stOUPRMAIN_1 As String = ""
    Dim vl_stOUPRMAIN_2 As String = ""
    Dim vl_stOUPRMAIN_3 As String = ""
    Dim vl_stOUPRARTE_1 As String = ""
    Dim vl_stOUPRARTE_2 As String = ""
    Dim vl_stOUPRARTE_3 As String = ""

    ' variables informacion general
    Dim vl_inINGETILI As Integer = 0
    Dim vl_inINGECLOU As Integer = 0
    Dim vl_stINGETILI_1 As String = ""
    Dim vl_stINGETILI_2 As String = ""
    Dim vl_stINGETILI_3 As String = ""
    Dim vl_inINGEATLO As Integer = 0
    Dim vl_inINGEATCO As Integer = 0
    Dim vl_inINGEDENS As Integer = 0
    Dim vl_inINGEUNID As Integer = 0
    Dim vl_loINGESMLV As Long = 0
    Dim vl_inINGEESSO As Integer = 0
    Dim vl_loINGEAVCA As Long = 0
    Dim vl_loINGEAVCO As Long = 0
    Dim vl_loLIQUEQUI_R As Long = 0
    Dim vl_loLIQUEQUI_O As Long = 0
    Dim vl_loLIQUESPU As Long = 0
    Dim vl_loLIQUDEAD As Long = 0
    Dim vl_loLIQUCOMP As Long = 0
    Dim vl_loLIQUTOTA_1 As Long = 0
    Dim vl_loLIQUTOTA_2 As Long = 0
    Dim vl_inINGECLSE As Integer = 0
    Dim vl_inINGEUNID_R As Integer = 0
    Dim vl_inINGEUNID_O As Integer = 0
    Dim vl_stINGEOBSE As String = ""

#End Region

#Region "FUNCIONES"

    Private Function fun_ConsultarRutaPlantilla() As String

        Try
            Dim stRuta As String = ""

            ' instancia la clase
            Dim objRutas As New cla_RUTAS
            Dim tblRutas As New DataTable

            tblRutas = objRutas.fun_Buscar_CODIGO_MANT_RUTAS(21)

            If tblRutas.Rows.Count > 0 Then

                ' directorio pricipal
                stRuta = Trim(tblRutas.Rows(0).Item("RUTARUTA"))

            End If

            Return stRuta

        Catch ex As Exception
            MessageBox.Show(Err.Description)
            Return ""
        End Try

    End Function
    Private Function fun_ConsultarRutaDestinoPDF(ByVal stOBURCLES As String, ByVal vl_inOBURNURE As Integer, ByVal inOBURVIRE As Integer) As String

        Try
            Dim stRuta As String = ""

            ' instancia la clase
            Dim objRutas As New cla_RUTAS
            Dim tblRutas As New DataTable

            tblRutas = objRutas.fun_Buscar_CODIGO_MANT_RUTAS(22)

            If tblRutas.Rows.Count > 0 Then

                ' directorio pricipal
                stRuta = Trim(tblRutas.Rows(0).Item("RUTARUTA")) & "\" & Trim(stOBURCLES) & "-" & vl_inOBURNURE & "-" & inOBURVIRE

            End If

            Return stRuta

        Catch ex As Exception
            MessageBox.Show(Err.Description)
            Return ""
        End Try

    End Function

#End Region

#Region "PROCEDIMIENTOS"

    Public Sub pro_Genera_Reporte_Liquidacion_Obligaciones_Urbanisticas(ByVal inOBURIDRE As Integer, ByVal inTIPOREPO As Integer, ByVal boOUIGADLI As Boolean)

        Try
            ' declara la variable
            vl_inOBURIDRE = inOBURIDRE
            vl_inTIPOREPO = inTIPOREPO
            VL_boOUIGADLI = boOUIGADLI

            ' carga la tabla 
            pro_CargaTablaInformacionGenerar()

            ' verifica los registros
            If vl_dtOBLIURBA.Rows.Count > 0 Then

                ' declara las variables
                pro_DeclaraLasVariables()

                ' carga informacion obligacion urbanistica
                pro_CargaInformacionObligacionUrbanisitca()

                ' carga informacion el periodo actual
                pro_CargaPeriodoActual()

                ' carga informacion del solicitante
                pro_CargaInformacionSolicitante()

                ' carga informacion predio
                pro_CargaInformacionPredio()

                ' carga informacion general
                pro_CargaInformacionGeneral()

                ' genera archivo de word
                pro_GeneraArchivoDeWord()

                ' mensaje de proceso
                mod_MENSAJE.Proceso_Termino_Correctamente()

            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub

    Private Sub pro_CargaTablaInformacionGenerar()

        Try
            ' instancia la clase
            Dim obOBLIURBA As New cla_OBLIURBA
            vl_dtOBLIURBA = New DataTable

            vl_dtOBLIURBA = obOBLIURBA.fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_OBLIURBA(vl_inOBURIDRE)

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub pro_DeclaraLasVariables()

        Try

            ' variables obligaciones urbanisticas
            vl_inOBURNULI = 0
            vl_stOBURCLEN = ""
            vl_inOBURNURE = 0
            vl_stOBURFERE = ""
            vl_inOBURVIRE = 0
            vl_inOBURVIAC = 0

            ' variables solicitante
            vl_stOUSOPROY = ""
            vl_stOUSONOMB = ""
            vl_stOUSODIPR = ""
            vl_stOUSONUDO = ""

            ' variables de predio
            vl_stOUPRDEPA = "05"
            vl_stOUPRMUNI = ""
            vl_stOUPRCORR = ""
            vl_stOUPRBARR = ""
            vl_stOUPRMANZ = ""
            vl_stOUPRPRED = ""
            vl_stOUPREDIF = ""
            vl_stOUPRUNPR = ""
            vl_stOUPRCLSE = ""
            vl_stBARRDESC = ""
            vl_stOUPRCECA_1 = ""
            vl_stOUPRCECA_2 = ""
            vl_stOUPRCECA_3 = ""
            vl_stOUPRMAIN_1 = ""
            vl_stOUPRMAIN_2 = ""
            vl_stOUPRMAIN_3 = ""
            vl_stOUPRARTE_1 = ""
            vl_stOUPRARTE_2 = ""
            vl_stOUPRARTE_3 = ""

            ' variables informacion general
            vl_inINGETILI = 0
            vl_inINGECLOU = 0
            vl_stINGETILI_1 = ""
            vl_stINGETILI_2 = ""
            vl_stINGETILI_3 = ""
            vl_inINGEATLO = 0
            vl_inINGEATCO = 0
            vl_inINGEDENS = 0
            vl_inINGEUNID = 0
            vl_loINGESMLV = 0
            vl_inINGEESSO = 0
            vl_loINGEAVCA = 0
            vl_loINGEAVCO = 0
            vl_loLIQUEQUI_R = 0
            vl_loLIQUEQUI_O = 0
            vl_loLIQUESPU = 0
            vl_loLIQUDEAD = 0
            vl_loLIQUCOMP = 0
            vl_loLIQUTOTA_1 = 0
            vl_loLIQUTOTA_2 = 0
            vl_inINGECLSE = 0
            vl_inINGEUNID_R = 0
            vl_inINGEUNID_O = 0
            vl_stINGEOBSE = ""

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub pro_CargaPeriodoActual()

        Try
            ' instanca la clase
            Dim obPERIACTU As New cla_PERIACTU
            Dim dtPERIACTU As New DataTable

            dtPERIACTU = obPERIACTU.fun_Consultar_VIGENCIA_ACTUAL_X_MANT_PERIACTU

            If dtPERIACTU.Rows.Count > 0 Then
                vl_inOBURVIAC = CInt(dtPERIACTU.Rows(0).Item("PEACCODI"))
            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub pro_CargaInformacionObligacionUrbanisitca()

        Try
            ' variables obligacion urbanistica
            vl_inOBURNULI = CInt(vl_dtOBLIURBA.Rows(0).Item("OBURSECU"))
            vl_stOBURCLEN = CStr(Trim(vl_dtOBLIURBA.Rows(0).Item("OBURCLEN")))
            vl_inOBURNURE = CInt(vl_dtOBLIURBA.Rows(0).Item("OBURNURE"))
            vl_stOBURFERE = CStr(Trim(vl_dtOBLIURBA.Rows(0).Item("OBURFERE")))
            vl_inOBURVIRE = CStr(Trim(vl_dtOBLIURBA.Rows(0).Item("OBURVIRE")))
            vl_inOBURVIAC = 0

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub pro_CargaInformacionSolicitante()

        Try
            ' instancia la clase
            Dim obOBURSOLI As New cla_OBURSOLI
            Dim dtOBURSOLI As New DataTable

            dtOBURSOLI = obOBURSOLI.fun_Buscar_SECU_X_CONSULTA_PARAMETRIZADA_OBURSOLI(vl_inOBURNULI)

            If dtOBURSOLI.Rows.Count > 0 Then

                vl_stOUSOPROY = CStr(Trim(dtOBURSOLI.Rows(0).Item("OUSOCOPO")))
                vl_stOUSONOMB = CStr(Trim(dtOBURSOLI.Rows(0).Item("OUSONOMB"))) & " " & CStr(Trim(dtOBURSOLI.Rows(0).Item("OUSOPRAP"))) & " " & CStr(Trim(dtOBURSOLI.Rows(0).Item("OUSOSEAP")))
                vl_stOUSODIPR = CStr(Trim(dtOBURSOLI.Rows(0).Item("OUSODIPR")))
                vl_stOUSONUDO = fun_Formato_Mascara_Pesos_Enteros(CStr(Trim(dtOBURSOLI.Rows(0).Item("OUSONUDO"))))

            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub pro_CargaInformacionPredio()

        Try
            ' instancia la clase
            Dim obOBURPRED As New cla_OBURPRED
            Dim dtOBURPRED As New DataTable

            dtOBURPRED = obOBURPRED.fun_Buscar_SECU_X_CONSULTA_PARAMETRIZADA_OBURPRED(vl_inOBURNULI)

            If dtOBURPRED.Rows.Count > 0 Then

                vl_stOUPRMUNI = CStr(Trim(dtOBURPRED.Rows(0).Item("OUPRMUNI")))
                vl_stOUPRBARR = CStr(Trim(dtOBURPRED.Rows(0).Item("OUPRBARR")))
                vl_stOUPRMANZ = CStr(Trim(dtOBURPRED.Rows(0).Item("OUPRMANZ")))
                vl_stOUPRCLSE = CStr(Trim(dtOBURPRED.Rows(0).Item("OUPRCLSE")))

                ' sector urbano
                If Trim(vl_stOUPRCLSE) = 1 Then
                    vl_stBARRDESC = Trim(fun_Buscar_Lista_Valores_BARRVERE(Trim(vl_stOUPRDEPA), Trim(vl_stOUPRMUNI), Trim(vl_stOUPRCLSE), Trim(vl_stOUPRBARR)))

                    ' sector rural
                ElseIf Trim(vl_stOUPRCLSE) = 2 Then
                    vl_stBARRDESC = Trim(fun_Buscar_Lista_Valores_BARRVERE(Trim(vl_stOUPRDEPA), Trim(vl_stOUPRMUNI), Trim(vl_stOUPRCLSE), Trim(vl_stOUPRMANZ)))

                End If

                ' declara la variable
                Dim i As Integer = 0

                For i = 0 To dtOBURPRED.Rows.Count - 1

                    vl_stOUPRMUNI = CStr(Trim(dtOBURPRED.Rows(i).Item("OUPRMUNI")))
                    vl_stOUPRCORR = CStr(Trim(dtOBURPRED.Rows(i).Item("OUPRCORR")))
                    vl_stOUPRBARR = CStr(Trim(dtOBURPRED.Rows(i).Item("OUPRBARR")))
                    vl_stOUPRMANZ = CStr(Trim(dtOBURPRED.Rows(i).Item("OUPRMANZ")))
                    vl_stOUPRPRED = CStr(Trim(dtOBURPRED.Rows(i).Item("OUPRPRED")))
                    vl_stOUPREDIF = CStr(Trim(dtOBURPRED.Rows(i).Item("OUPREDIF")))
                    vl_stOUPRUNPR = CStr(Trim(dtOBURPRED.Rows(i).Item("OUPRUNPR")))
                    vl_stOUPRCLSE = CStr(Trim(dtOBURPRED.Rows(i).Item("OUPRCLSE")))

                    If i = 0 Then
                        vl_stOUPRCECA_1 = CStr(Trim(vl_stOUPRCLSE)) & CStr(Trim(vl_stOUPRBARR)) & fun_Formato_Mascara_4_String(CStr(Trim(vl_stOUPRMANZ))) & CStr(Trim(vl_stOUPRPRED)) & fun_Formato_Mascara_4_String(CStr(Trim(vl_stOUPREDIF))) & CStr(Trim(vl_stOUPRUNPR))
                        vl_stOUPRMAIN_1 = "001-" & CStr(Trim(dtOBURPRED.Rows(i).Item("OUPRMAIN")))
                        vl_stOUPRARTE_1 = fun_Formato_Mascara_Pesos_Enteros(CStr(Trim(dtOBURPRED.Rows(i).Item("OUPRARTE"))))

                    ElseIf i = 1 Then
                        vl_stOUPRCECA_2 = CStr(Trim(vl_stOUPRCLSE)) & CStr(Trim(vl_stOUPRBARR)) & fun_Formato_Mascara_4_String(CStr(Trim(vl_stOUPRMANZ))) & CStr(Trim(vl_stOUPRPRED)) & fun_Formato_Mascara_4_String(CStr(Trim(vl_stOUPREDIF))) & CStr(Trim(vl_stOUPRUNPR))
                        vl_stOUPRMAIN_2 = "001-" & CStr(Trim(dtOBURPRED.Rows(i).Item("OUPRMAIN")))
                        vl_stOUPRARTE_2 = fun_Formato_Mascara_Pesos_Enteros(CStr(Trim(dtOBURPRED.Rows(i).Item("OUPRARTE"))))

                    ElseIf i = 2 Then
                        vl_stOUPRCECA_3 = CStr(Trim(vl_stOUPRCLSE)) & CStr(Trim(vl_stOUPRBARR)) & fun_Formato_Mascara_4_String(CStr(Trim(vl_stOUPRMANZ))) & CStr(Trim(vl_stOUPRPRED)) & fun_Formato_Mascara_4_String(CStr(Trim(vl_stOUPREDIF))) & CStr(Trim(vl_stOUPRUNPR))
                        vl_stOUPRMAIN_3 = "001-" & CStr(Trim(dtOBURPRED.Rows(i).Item("OUPRMAIN")))
                        vl_stOUPRARTE_3 = fun_Formato_Mascara_Pesos_Enteros(CStr(Trim(dtOBURPRED.Rows(i).Item("OUPRARTE"))))

                    End If

                Next

            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub pro_CargaInformacionGeneral()

        Try
            ' instancia la clase
            Dim obOBURINGE As New cla_OBURINGE
            Dim dtOBURINGE As New DataTable

            dtOBURINGE = obOBURINGE.fun_Buscar_SECU_X_CONSULTA_PARAMETRIZADA_OBURINGE(vl_inOBURNULI)

            If dtOBURINGE.Rows.Count > 0 Then

                vl_inINGECLSE = CInt(dtOBURINGE.Rows(0).Item("OUIGCLSE"))

                ' declara la variable
                Dim dtLIQUEQUI_RESI As New DataTable
                Dim dtLIQUEQUI_OTRO As New DataTable
                Dim dtLIQUESPU As New DataTable
                Dim dtLIQUDEAD As New DataTable
                Dim dtLIQUCOMP As New DataTable
                Dim dtLIQUTOTA_1 As New DataTable
                Dim dtLIQUTOTA_2 As New DataTable

                ' totales de liquidacion
                dtLIQUEQUI_RESI = obOBURINGE.fun_Buscar_LIQUIDACION_X_CLASE_OBLIGACION_X_OBURINGE(1, vl_stOBURCLEN, vl_inOBURNURE, vl_stOBURFERE, "R", VL_boOUIGADLI)
                dtLIQUEQUI_OTRO = obOBURINGE.fun_Buscar_LIQUIDACION_X_CLASE_OBLIGACION_X_OBURINGE(1, vl_stOBURCLEN, vl_inOBURNURE, vl_stOBURFERE, "U", VL_boOUIGADLI)
                dtLIQUESPU = obOBURINGE.fun_Buscar_LIQUIDACION_X_CLASE_OBLIGACION_X_OBURINGE(2, vl_stOBURCLEN, vl_inOBURNURE, vl_stOBURFERE, VL_boOUIGADLI)
                dtLIQUDEAD = obOBURINGE.fun_Buscar_LIQUIDACION_X_CLASE_OBLIGACION_X_OBURINGE(5, vl_stOBURCLEN, vl_inOBURNURE, vl_stOBURFERE, VL_boOUIGADLI)
                dtLIQUCOMP = obOBURINGE.fun_Buscar_LIQUIDACION_X_CLASE_OBLIGACION_X_OBURINGE(6, vl_stOBURCLEN, vl_inOBURNURE, vl_stOBURFERE, VL_boOUIGADLI)

                dtLIQUTOTA_1 = obOBURINGE.fun_Buscar_LIQUIDACION_TOTAL_1_OBURINGE(vl_stOBURCLEN, vl_inOBURNURE, vl_stOBURFERE, VL_boOUIGADLI)
                dtLIQUTOTA_2 = obOBURINGE.fun_Buscar_LIQUIDACION_TOTAL_2_OBURINGE(vl_stOBURCLEN, vl_inOBURNURE, vl_stOBURFERE, VL_boOUIGADLI)

                ' almacena el resultado residencial
                If dtLIQUEQUI_RESI.Rows.Count > 0 Then
                    vl_loLIQUEQUI_R = CLng(dtLIQUEQUI_RESI.Rows(0).Item("CLOULIQU"))
                End If

                ' almacena el resultado otros usos
                If dtLIQUEQUI_OTRO.Rows.Count > 0 Then
                    vl_loLIQUEQUI_O = CLng(dtLIQUEQUI_OTRO.Rows(0).Item("CLOULIQU"))
                End If

                If dtLIQUESPU.Rows.Count > 0 Then
                    vl_loLIQUESPU = CLng(dtLIQUESPU.Rows(0).Item("CLOULIQU"))
                End If
                If dtLIQUDEAD.Rows.Count > 0 Then
                    vl_loLIQUDEAD = CLng(dtLIQUDEAD.Rows(0).Item("CLOULIQU"))
                End If
                If dtLIQUCOMP.Rows.Count > 0 Then
                    vl_loLIQUCOMP = CLng(dtLIQUCOMP.Rows(0).Item("CLOULIQU"))
                End If

                If vl_inTIPOREPO = 1 Then
                    If dtLIQUTOTA_1.Rows.Count > 0 Then

                        ' declara la variable
                        Dim i1 As Integer = 0

                        For i1 = 0 To dtLIQUTOTA_1.Rows.Count - 1

                            vl_loLIQUTOTA_1 += CLng(dtLIQUTOTA_1.Rows(i1).Item("OUIGLIQU"))

                        Next

                    End If
                End If

                If vl_inTIPOREPO = 2 Then
                    If dtLIQUTOTA_2.Rows.Count > 0 Then

                        ' declara la variable
                        Dim i2 As Integer = 0

                        For i2 = 0 To dtLIQUTOTA_2.Rows.Count - 1

                            vl_loLIQUTOTA_2 += CLng(dtLIQUTOTA_2.Rows(i2).Item("OUIGLIQU"))

                        Next

                    End If

                End If

                ' declara la variable
                Dim boAdicionDeLiquidacion = False
                Dim ii2 As Integer = 0

                For ii2 = 0 To dtOBURINGE.Rows.Count - 1

                    ' verifica si es densidad adicional y esta marcado como adicion de liquidacion
                    If CInt(dtOBURINGE.Rows(ii2).Item("OUIGCLOU")) = 5 And CBool(dtOBURINGE.Rows(ii2).Item("OUIGADLI")) = True Then
                        boAdicionDeLiquidacion = True

                        vl_inINGETILI = CInt(dtOBURINGE.Rows(ii2).Item("OUIGTILI"))
                        Exit For
                    Else
                        vl_inINGETILI = CInt(dtOBURINGE.Rows(0).Item("OUIGTILI"))

                    End If

                Next

                ' asigna el tipo de liquidacion
                If vl_inINGETILI = 1 Then
                    vl_stINGETILI_1 = "X"

                ElseIf vl_inINGETILI = 2 Then
                    vl_stINGETILI_2 = "X"

                ElseIf vl_inINGETILI = 3 Then
                    vl_stINGETILI_3 = "X"

                End If

                ' declara la variable
                Dim i As Integer = 0

                For i = 0 To dtOBURINGE.Rows.Count - 1

                    ' contatena las obseervaciones
                    vl_stINGEOBSE += " " & CStr(Trim(dtOBURINGE.Rows(i).Item("OUIGOBSE")))

                    If vl_inTIPOREPO = 1 Then

                        ' total unidades
                        If CInt(dtOBURINGE.Rows(i).Item("OUIGCLOU")) = 2 And CBool(dtOBURINGE.Rows(i).Item("OUIGADLI")) = VL_boOUIGADLI Then
                            vl_inINGEUNID = CInt(dtOBURINGE.Rows(i).Item("OUIGUNID"))
                        End If

                        ' total unidades residenciales
                        If CInt(dtOBURINGE.Rows(i).Item("OUIGCLOU")) = 1 Then
                            If CStr(Trim(dtOBURINGE.Rows(i).Item("OUIGTIPO"))) = "R" And CBool(dtOBURINGE.Rows(i).Item("OUIGADLI")) = VL_boOUIGADLI Then
                                vl_inINGEUNID_R = CInt(dtOBURINGE.Rows(i).Item("OUIGUNID"))
                            End If
                        End If

                        ' total unidades otros usos
                        If CInt(dtOBURINGE.Rows(i).Item("OUIGCLOU")) = 1 Then
                            If CStr(Trim(dtOBURINGE.Rows(i).Item("OUIGTIPO"))) = "U" And CBool(dtOBURINGE.Rows(i).Item("OUIGADLI")) = VL_boOUIGADLI Then
                                vl_inINGEUNID_O = CInt(dtOBURINGE.Rows(i).Item("OUIGUNID"))
                            End If
                        End If

                    End If

                    If vl_inTIPOREPO = 2 Then
                        If CInt(dtOBURINGE.Rows(i).Item("OUIGCLOU")) = 5 And CBool(dtOBURINGE.Rows(i).Item("OUIGADLI")) = VL_boOUIGADLI Then
                            vl_inINGEUNID = CInt(dtOBURINGE.Rows(i).Item("OUIGUNID"))
                        End If
                    End If

                    If CInt(dtOBURINGE.Rows(i).Item("OUIGATLO")) <> 0 Then
                        vl_inINGEATLO = CInt(dtOBURINGE.Rows(i).Item("OUIGATLO"))
                    End If
                    If CInt(dtOBURINGE.Rows(i).Item("OUIGATCO")) <> 0 Then
                        vl_inINGEATCO = CInt(dtOBURINGE.Rows(i).Item("OUIGATCO"))
                    End If
                    If CInt(dtOBURINGE.Rows(i).Item("OUIGDENS")) <> 0 Then
                        vl_inINGEDENS = CInt(dtOBURINGE.Rows(i).Item("OUIGDENS"))
                    End If
                    If CLng(dtOBURINGE.Rows(i).Item("OUIGSMLV")) <> 0 Then
                        vl_loINGESMLV = CLng(dtOBURINGE.Rows(i).Item("OUIGSMLV"))
                    End If
                    If CInt(dtOBURINGE.Rows(i).Item("OUIGESSO")) <> 0 Then
                        vl_inINGEESSO = CInt(dtOBURINGE.Rows(i).Item("OUIGESSO"))
                    End If
                    If CLng(dtOBURINGE.Rows(i).Item("OUIGAVCA")) <> 0 Then
                        vl_loINGEAVCA = CLng(dtOBURINGE.Rows(i).Item("OUIGAVCA"))
                    End If
                    If CLng(dtOBURINGE.Rows(i).Item("OUIGAVCO")) <> 0 Then
                        vl_loINGEAVCO = CLng(dtOBURINGE.Rows(i).Item("OUIGAVCO"))
                    End If

                Next

                ' si no existe espacio publico
                If vl_inTIPOREPO = 1 Then
                    If vl_inINGEUNID = 0 Then

                        Dim ii As Integer = 0

                        For ii = 0 To dtOBURINGE.Rows.Count - 1

                            If CInt(dtOBURINGE.Rows(ii).Item("OUIGCLOU")) = 1 Then
                                vl_inINGEUNID += CInt(dtOBURINGE.Rows(ii).Item("OUIGUNID"))
                            End If

                        Next

                    End If
                End If

            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub pro_GeneraArchivoDeWord()

        Try
            ' declara la variable
            Dim stExtensionArchivoWord As String = ".docx"
            Dim stExtensionArchivoPDF As String = ".pdf"
            Dim stNombreArchivoPlantilla_1 As String = "Plantilla_GT-F-055_1"
            Dim stNombreArchivoPlantilla_2 As String = "Plantilla_GT-F-055_2"
            Dim stNombreArchivoPlantilla_3 As String = "Plantilla_GT-F-055_3"
            Dim stNombreExtensionArchivoPlantilla_1 As String = Trim(stNombreArchivoPlantilla_1) & Trim(stExtensionArchivoWord)
            Dim stNombreExtensionArchivoPlantilla_2 As String = Trim(stNombreArchivoPlantilla_2) & Trim(stExtensionArchivoWord)
            Dim stNombreExtensionArchivoPlantilla_3 As String = Trim(stNombreArchivoPlantilla_3) & Trim(stExtensionArchivoWord)
            Dim stRutaArchivoPlantilla As String = CStr(Trim(fun_ConsultarRutaPlantilla()))
            Dim stRutaDestinoArchivoPDF As String = CStr(Trim(fun_ConsultarRutaDestinoPDF(Trim(vl_stOBURCLEN), vl_inOBURNURE, vl_inOBURVIRE)))

            ' declara la instancia
            Dim MSWord As New Word.Application
            Dim Documento As New Word.Document

            ' verifica el sector - urbano
            If CInt(vl_inINGECLSE) = 1 Then

                ' verifica clase de obligacion
                If vl_inTIPOREPO = 1 Then
                    If File.Exists(Trim(Trim(stRutaArchivoPlantilla) & "\" & Trim(stNombreArchivoPlantilla_1) & "-" & vl_inOBURNULI & "-" & Trim(vl_stOBURFERE) & Trim(stExtensionArchivoWord))) = True Then
                        File.Delete(Trim(Trim(stRutaArchivoPlantilla) & "\" & Trim(stNombreArchivoPlantilla_1) & "-" & vl_inOBURNULI & "-" & Trim(vl_stOBURFERE) & Trim(stExtensionArchivoWord)))
                    End If

                    ' copia archivo
                    FileCopy(Trim(stRutaArchivoPlantilla) & "\" & Trim(stNombreExtensionArchivoPlantilla_1), Trim(stRutaArchivoPlantilla) & "\" & Trim(stNombreArchivoPlantilla_1) & "-" & vl_inOBURNULI & "-" & Trim(vl_stOBURFERE) & Trim(stExtensionArchivoWord))

                    ' regista la plantilla
                    Documento = MSWord.Documents.Open(Trim(stRutaArchivoPlantilla) & "\" & Trim(stNombreArchivoPlantilla_1) & "-" & vl_inOBURNULI & "-" & Trim(vl_stOBURFERE) & Trim(stExtensionArchivoWord))
                End If

                If vl_inTIPOREPO = 2 Then
                    If File.Exists(Trim(Trim(stRutaArchivoPlantilla) & "\" & Trim(stNombreArchivoPlantilla_2) & "-" & vl_inOBURNULI & "-" & Trim(vl_stOBURFERE) & Trim(stExtensionArchivoWord))) = True Then
                        File.Delete(Trim(Trim(stRutaArchivoPlantilla) & "\" & Trim(stNombreArchivoPlantilla_2) & "-" & vl_inOBURNULI & "-" & Trim(vl_stOBURFERE) & Trim(stExtensionArchivoWord)))
                    End If

                    ' copia archivo
                    FileCopy(Trim(stRutaArchivoPlantilla) & "\" & Trim(stNombreExtensionArchivoPlantilla_2), Trim(stRutaArchivoPlantilla) & "\" & Trim(stNombreArchivoPlantilla_2) & "-" & vl_inOBURNULI & "-" & Trim(vl_stOBURFERE) & Trim(stExtensionArchivoWord))

                    ' regista la plantilla
                    Documento = MSWord.Documents.Open(Trim(stRutaArchivoPlantilla) & "\" & Trim(stNombreArchivoPlantilla_2) & "-" & vl_inOBURNULI & "-" & Trim(vl_stOBURFERE) & Trim(stExtensionArchivoWord))
                End If

            End If

            ' verifica el sector - rural
            If CInt(vl_inINGECLSE) = 2 Then

                ' verifica clase de obligacion
                If vl_inTIPOREPO = 1 Then
                    If File.Exists(Trim(Trim(stRutaArchivoPlantilla) & "\" & Trim(stNombreArchivoPlantilla_3) & "-" & vl_inOBURNULI & "-" & Trim(vl_stOBURFERE) & Trim(stExtensionArchivoWord))) = True Then
                        File.Delete(Trim(Trim(stRutaArchivoPlantilla) & "\" & Trim(stNombreArchivoPlantilla_3) & "-" & vl_inOBURNULI & "-" & Trim(vl_stOBURFERE) & Trim(stExtensionArchivoWord)))
                    End If

                    ' copia archivo
                    FileCopy(Trim(stRutaArchivoPlantilla) & "\" & Trim(stNombreExtensionArchivoPlantilla_3), Trim(stRutaArchivoPlantilla) & "\" & Trim(stNombreArchivoPlantilla_3) & "-" & vl_inOBURNULI & "-" & Trim(vl_stOBURFERE) & Trim(stExtensionArchivoWord))

                    ' regista la plantilla
                    Documento = MSWord.Documents.Open(Trim(stRutaArchivoPlantilla) & "\" & Trim(stNombreArchivoPlantilla_3) & "-" & vl_inOBURNULI & "-" & Trim(vl_stOBURFERE) & Trim(stExtensionArchivoWord))
                End If

            End If

            ' asigna la informacion a la plantilla
            Documento.Bookmarks.Item("ma_OBURNULI").Range.Text = "L" & "-" & fun_Formato_Mascara_3_String(CStr(vl_inOBURNULI)) & "-" & CStr(vl_inOBURVIAC)
            Documento.Bookmarks.Item("ma_INGETILI_1").Range.Text = Trim(vl_stINGETILI_1)
            Documento.Bookmarks.Item("ma_INGETILI_2").Range.Text = Trim(vl_stINGETILI_2)
            Documento.Bookmarks.Item("ma_INGETILI_3").Range.Text = Trim(vl_stINGETILI_3)
            Documento.Bookmarks.Item("ma_OBURCLEN").Range.Text = fun_Buscar_Lista_Valores_CLASENTI(Trim(vl_stOBURCLEN))
            Documento.Bookmarks.Item("ma_OUSOPROY").Range.Text = Trim(vl_stOUSOPROY)
            Documento.Bookmarks.Item("ma_OBURNURE").Range.Text = Trim(vl_stOBURCLEN) & "-" & Trim(vl_inOBURNURE) & "-" & Trim(vl_inOBURVIRE) & " / " & Trim(vl_stOBURFERE)
            Documento.Bookmarks.Item("ma_OUSONOMB").Range.Text = Trim(vl_stOUSONOMB)
            Documento.Bookmarks.Item("ma_OUSONUDO").Range.Text = Trim(vl_stOUSONUDO)
            Documento.Bookmarks.Item("ma_OUSODIRE").Range.Text = Trim(vl_stOUSODIPR)
            Documento.Bookmarks.Item("ma_OUSOBARR").Range.Text = Trim(vl_stBARRDESC)
            Documento.Bookmarks.Item("ma_OUPRCECA_1").Range.Text = Trim(vl_stOUPRCECA_1)
            Documento.Bookmarks.Item("ma_OUPRCECA_2").Range.Text = Trim(vl_stOUPRCECA_2)
            Documento.Bookmarks.Item("ma_OUPRCECA_3").Range.Text = Trim(vl_stOUPRCECA_3)
            Documento.Bookmarks.Item("ma_OUPRMAIN_1").Range.Text = Trim(vl_stOUPRMAIN_1)
            Documento.Bookmarks.Item("ma_OUPRMAIN_2").Range.Text = Trim(vl_stOUPRMAIN_2)
            Documento.Bookmarks.Item("ma_OUPRMAIN_3").Range.Text = Trim(vl_stOUPRMAIN_3)
            Documento.Bookmarks.Item("ma_OUPRARTE_1").Range.Text = fun_Formato_Mascara_Pesos_Enteros(Trim(vl_stOUPRARTE_1))
            Documento.Bookmarks.Item("ma_OUPRARTE_2").Range.Text = fun_Formato_Mascara_Pesos_Enteros(Trim(vl_stOUPRARTE_2))
            Documento.Bookmarks.Item("ma_OUPRARTE_3").Range.Text = fun_Formato_Mascara_Pesos_Enteros(Trim(vl_stOUPRARTE_3))
            Documento.Bookmarks.Item("ma_INGEATLO").Range.Text = fun_Formato_Mascara_Pesos_Enteros(Trim(vl_inINGEATLO))
            Documento.Bookmarks.Item("ma_INGEATCO").Range.Text = fun_Formato_Mascara_Pesos_Enteros(Trim(vl_inINGEATCO))
            Documento.Bookmarks.Item("ma_INGEDENS").Range.Text = Trim(vl_inINGEDENS)
            Documento.Bookmarks.Item("ma_INGESMLV").Range.Text = fun_Formato_Mascara_Pesos_Enteros(Trim(vl_loINGESMLV))
            Documento.Bookmarks.Item("ma_INGEESSO").Range.Text = Trim(vl_inINGEESSO)
            Documento.Bookmarks.Item("ma_INGEAVCA").Range.Text = fun_Formato_Mascara_Pesos_Enteros(Trim(vl_loINGEAVCA))
            Documento.Bookmarks.Item("ma_INGEAVCO").Range.Text = fun_Formato_Mascara_Pesos_Enteros(Trim(vl_loINGEAVCO))
            Documento.Bookmarks.Item("ma_OBURFELI_1").Range.Text = fun_fecha()
            Documento.Bookmarks.Item("ma_OBURFELI_2").Range.Text = fun_fecha()
            Documento.Bookmarks.Item("ma_INGEOBSE").Range.Text = Trim(vl_stINGEOBSE)

            ' verifica el sector - urbano
            If CInt(vl_inINGECLSE) = 1 Then

                If vl_inTIPOREPO = 1 Then
                    Documento.Bookmarks.Item("ma_INGEUNID").Range.Text = Trim(vl_inINGEUNID) & " = " & "R=" & vl_inINGEUNID_R & " / " & "C=" & vl_inINGEUNID_O
                    Documento.Bookmarks.Item("ma_OBURLETRAS").Range.Text = fun_ConvertirNumerosLetrasPorLetras(vl_loLIQUTOTA_1).ToString.ToUpper & " " & "PESOS M/L"
                    Documento.Bookmarks.Item("ma_LIQUTOTA").Range.Text = fun_Formato_Mascara_Pesos_Enteros(Trim(vl_loLIQUTOTA_1))
                    Documento.Bookmarks.Item("ma_LIQUEQUI_1").Range.Text = fun_Formato_Mascara_Pesos_Enteros(Trim(vl_loLIQUEQUI_R))
                    Documento.Bookmarks.Item("ma_LIQUEQUI_2").Range.Text = fun_Formato_Mascara_Pesos_Enteros(Trim(vl_loLIQUEQUI_O))
                    Documento.Bookmarks.Item("ma_LIQUESPU").Range.Text = fun_Formato_Mascara_Pesos_Enteros(Trim(vl_loLIQUESPU))
                    Documento.Bookmarks.Item("ma_LIQUCOMP").Range.Text = fun_Formato_Mascara_Pesos_Enteros(Trim(vl_loLIQUCOMP))
                End If

                If vl_inTIPOREPO = 2 Then
                    Documento.Bookmarks.Item("ma_INGEUNID").Range.Text = Trim(vl_inINGEUNID)
                    Documento.Bookmarks.Item("ma_OBURLETRAS").Range.Text = fun_ConvertirNumerosLetrasPorLetras(vl_loLIQUTOTA_2).ToString.ToUpper & " " & "PESOS M/L"
                    Documento.Bookmarks.Item("ma_LIQUTOTA").Range.Text = fun_Formato_Mascara_Pesos_Enteros(Trim(vl_loLIQUTOTA_2))
                    Documento.Bookmarks.Item("ma_LIQUDEAD").Range.Text = fun_Formato_Mascara_Pesos_Enteros(Trim(vl_loLIQUDEAD))
                End If

            End If

            ' verifica el sector - rural
            If CInt(vl_inINGECLSE) = 2 Then

                If vl_inTIPOREPO = 1 Then
                    Documento.Bookmarks.Item("ma_INGEUNID").Range.Text = Trim(vl_inINGEUNID) & " = " & "R=" & vl_inINGEUNID_R & " - " & "C=" & vl_inINGEUNID_O
                    Documento.Bookmarks.Item("ma_OBURLETRAS").Range.Text = fun_ConvertirNumerosLetrasPorLetras(vl_loLIQUTOTA_1).ToString.ToUpper & " " & "PESOS M/L"
                    Documento.Bookmarks.Item("ma_LIQUTOTA").Range.Text = fun_Formato_Mascara_Pesos_Enteros(Trim(vl_loLIQUTOTA_1))
                    Documento.Bookmarks.Item("ma_LIQUEQUI_1").Range.Text = fun_Formato_Mascara_Pesos_Enteros(Trim(vl_loLIQUEQUI_R))
                    Documento.Bookmarks.Item("ma_LIQUEQUI_2").Range.Text = fun_Formato_Mascara_Pesos_Enteros(Trim(vl_loLIQUEQUI_O))
                    Documento.Bookmarks.Item("ma_LIQUESPU").Range.Text = fun_Formato_Mascara_Pesos_Enteros(Trim(vl_loLIQUESPU))
                    Documento.Bookmarks.Item("ma_LIQUCOMP").Range.Text = fun_Formato_Mascara_Pesos_Enteros(Trim(vl_loLIQUCOMP))

                    Documento.Bookmarks.Item("ma_INGEATLO_ESPU").Range.Text = fun_Formato_Mascara_Pesos_Enteros(Trim(vl_inINGEATLO))
                    Documento.Bookmarks.Item("ma_INGEATLO_R_X_15_ESPU").Range.Text = fun_Formato_Mascara_Pesos_Enteros(Trim((vl_inINGEATLO) * 15) / 100)
                    Documento.Bookmarks.Item("ma_INGEUNID_R").Range.Text = Trim(vl_inINGEUNID)
                    Documento.Bookmarks.Item("ma_INGEUNID_R_X_15_EQUI").Range.Text = fun_Formato_Mascara_Pesos_Enteros(Trim(vl_inINGEUNID) * 15)
                    Documento.Bookmarks.Item("ma_INGESMLV_EQUI").Range.Text = fun_Formato_Mascara_Pesos_Enteros(Trim(vl_loINGESMLV))
                    Documento.Bookmarks.Item("ma_INGETOTA_R_X_15_EQUI").Range.Text = fun_Formato_Mascara_Pesos_Enteros(Trim(((vl_inINGEUNID) * 15) * 2) * vl_loINGESMLV)

                End If

            End If

            ' salva el documento word
            Documento.Save()
            Documento.Close()

            ' verifica el sector - urbano
            If CInt(vl_inINGECLSE) = 1 Then

                ' convierte documento word a PDF
                If vl_inTIPOREPO = 1 Then
                    pro_ConvertirDocumentoWordaPDF(Trim(stRutaArchivoPlantilla) & "\" & Trim(stNombreArchivoPlantilla_1) & "-" & vl_inOBURNULI & "-" & Trim(vl_stOBURFERE) & Trim(stExtensionArchivoWord), Trim(stRutaDestinoArchivoPDF) & "\" & Trim(stNombreArchivoPlantilla_1) & "-" & vl_inOBURNULI & "-" & Trim(vl_stOBURFERE) & Trim(stExtensionArchivoPDF))
                End If

                If vl_inTIPOREPO = 2 Then
                    pro_ConvertirDocumentoWordaPDF(Trim(stRutaArchivoPlantilla) & "\" & Trim(stNombreArchivoPlantilla_2) & "-" & vl_inOBURNULI & "-" & Trim(vl_stOBURFERE) & Trim(stExtensionArchivoWord), Trim(stRutaDestinoArchivoPDF) & "\" & Trim(stNombreArchivoPlantilla_2) & "-" & vl_inOBURNULI & "-" & Trim(vl_stOBURFERE) & Trim(stExtensionArchivoPDF))
                End If

            End If

            ' verifica el sector - rural
            If CInt(vl_inINGECLSE) = 2 Then

                ' convierte documento word a PDF
                If vl_inTIPOREPO = 1 Then
                    pro_ConvertirDocumentoWordaPDF(Trim(stRutaArchivoPlantilla) & "\" & Trim(stNombreArchivoPlantilla_3) & "-" & vl_inOBURNULI & "-" & Trim(vl_stOBURFERE) & Trim(stExtensionArchivoWord), Trim(stRutaDestinoArchivoPDF) & "\" & Trim(stNombreArchivoPlantilla_3) & "-" & vl_inOBURNULI & "-" & Trim(vl_stOBURFERE) & Trim(stExtensionArchivoPDF))
                End If

            End If

            ' abre el documeto word
            'MSWord.Visible = True

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub

    Private Sub pro_ConvertirDocumentoWordaPDF(ByVal stRutaInicial As String, ByVal stRutaFinal As String)

        Try
            'Creating the instance of Word Application
            Dim newApp As New Word.Application()

            ' Pon unos caminos que sean buenos
            Dim Source As Object = Trim(stRutaInicial)
            Dim Target As Object = Trim(stRutaFinal)

            ' Use for the parameter whose type are not known or say Missing
            Dim Unknown As Object = Type.Missing

            ' Source document open here
            ' Additional Parameters are not known so that are
            ' set as a missing type
            newApp.Documents.Open(Source, Unknown, Unknown, Unknown, Unknown, Unknown, Unknown, Unknown, Unknown, Unknown, Unknown, Unknown, Unknown, Unknown, Unknown)

            ' Specifying the format in which you want the output file
            Dim format As Object = Word.WdSaveFormat.wdFormatPDF

            'Changing the format of the document
            newApp.ActiveDocument.SaveAs(Target, format, Unknown, Unknown, Unknown, Unknown, Unknown, Unknown, Unknown, Unknown, Unknown, Unknown, Unknown, Unknown, Unknown, Unknown)

            ' for closing the application
            newApp.Quit(Unknown, Unknown, Unknown)

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub

#End Region

End Module
