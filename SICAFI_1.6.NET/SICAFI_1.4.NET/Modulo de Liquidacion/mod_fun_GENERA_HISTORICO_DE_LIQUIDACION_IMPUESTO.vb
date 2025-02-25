Imports REGLAS_DEL_NEGOCIO
Imports System
Imports System.IO
Imports System.Data
Imports System.Data.Sqlclient
Imports System.Configuration
Imports System.Text
Imports System.Math

Module mod_fun_GENERA_HISTORICO_DE_LIQUIDACION_IMPUESTO

    '================================================
    '*** GENERA HISTORICO DE LIQUIDACIÓN IMPUESTO ***
    '================================================

#Region "VARIABLES"

#Region "Tablas"

    ' Tabla 0
    Private dt_FICHPRED As New DataTable
    ' Tabla 1
    Private dt_FIPRDEEC As New DataTable
    ' Tabla 2
    Private dt_FIPRPROP As New DataTable
    ' Tabla 3
    Private dt_FIPRCONS As New DataTable
    ' Tabla 4
    Private dt_FIPRCACO As New DataTable
    ' Tabla 5
    Private dt_FIPRLIND As New DataTable
    ' Tabla 6
    Private dt_FIPRCART As New DataTable
    ' Tabla 7
    Private dt_FIPRZOEC As New DataTable
    ' Tabla 8
    Private dt_FIPRZOFI As New DataTable

#End Region

#Region "Ficha Predial"

    Private vl_inHILINUFI As Integer = 0
    Private vl_stHILICECA As String = ""
    Private vl_inHILIVIGE As Integer = 0
    Private vl_loHILIAVPR As Long = 0
    Private vl_loHILIAVCA As Long = 0
    Private vl_stHILIDEEC As String = ""
    Private vl_stHILIESTR As String = ""
    Private vl_boHILILOTE As Boolean = False
    Private vl_boHILILOCE As Boolean = False
    Private vl_boHILILE44 As Boolean = False
    Private vl_boHILILE56 As Boolean = False
    Private vl_boHILIAUAV As Boolean = False
    Private vl_boHILIGRAV As Boolean = False
    Private vl_stHILITIPO As String = ""
    Private vl_stHILIARCO As String = ""
    Private vl_inHILIARTE As Integer = 0
    Private vl_inHILIPUNT As Integer = 0
    Private vl_stHILIESTA As String = "ac"
    Private vl_stHILITIRE As String = ""
    Private vl_stHILIVIRE As String = ""
    Private vl_stHILIRESO As String = ""
    Private vl_stHILIUSIN As String = vp_usuario
    Private vl_stHILIUSMO As String = ""
    Private vl_daHILIFEIN As Date = fun_fecha()
    Private vl_daHILIFEMO As Date = fun_fecha()
    Private vl_stHILIMAQU As String = fun_Nombre_de_maquina()

#End Region

#Region "Conexion"

    Private oEjecutar As New SqlCommand
    Private oConexion As New SqlConnection
    Private oAdapter As New SqlDataAdapter
    Private oReader As SqlDataReader
    Private ds As New DataSet
    Private dt As New DataTable
    Private dt_1 As New DataTable
    Private dt_2 As New DataTable
    Private dt_3 As New DataTable

#End Region

#End Region

#Region "PROCEDIMIENTOS"

    Public Sub pro_GENERA_HISTORICO_DE_LIQUIDACION_IMPUESTO(ByVal o_inFIPRNUFI As Integer, _
                                                            ByVal o_inFIPRVIGE As Integer)

        Try
            ' declaro variables
            vl_inHILINUFI = o_inFIPRNUFI
            vl_inHILIVIGE = o_inFIPRVIGE

            ' Elimina el avaluo catastral
            Dim objdatos As New cla_HISTLIQU

            objdatos.fun_Eliminar_NUFI_Y_VIGE_X_HISTLIQU(vl_inHILINUFI, vl_inHILIVIGE)

            ' Carga las tablas
            pro_CargarTablasFichaPredial()

            ' Liquida avaluo por caracteritica de predio
            If dt_FICHPRED.Rows(0).Item("FIPRTIFI") = 0 Then
                If Trim(dt_FICHPRED.Rows(0).Item("FIPRESTA")) = "ac" Then

                    ' Liquida caracteristica (1) Normal, (2) RPH Edificio, (3) RPH Parcelación, (4) RPH Condominio, (5) Parque Cementerio, (6) Embalse, (7) Baldio
                    If dt_FICHPRED.Rows(0).Item("FIPRCAPR") = 1 Or _
                       dt_FICHPRED.Rows(0).Item("FIPRCAPR") = 2 Or _
                       dt_FICHPRED.Rows(0).Item("FIPRCAPR") = 3 Or _
                       dt_FICHPRED.Rows(0).Item("FIPRCAPR") = 4 Or _
                       dt_FICHPRED.Rows(0).Item("FIPRCAPR") = 5 Or _
                       dt_FICHPRED.Rows(0).Item("FIPRCAPR") = 6 Or _
                       dt_FICHPRED.Rows(0).Item("FIPRCAPR") = 7 Then

                        pro_CargarDatosHistoricosDeLiquidacion()

                        ' consulta el registro
                        Dim objdatos22 As New cla_HISTLIQU
                        Dim tbl22 As New DataTable

                        tbl22 = objdatos22.fun_Buscar_CODIGO_NUFI_VIGE_X_HISTLIQU(vl_inHILINUFI, vl_inHILIVIGE)

                        If tbl22.Rows.Count > 0 Then
                            pro_ActualizarHistoricoDeLiquidacion()
                        Else
                            pro_GuardarHistoricoDeLiquidacion()
                        End If

                    End If

                End If
            End If


        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "Liquida Historicos de Liquidacion Impuestos")
        End Try

    End Sub

    Private Sub pro_CargarTablasFichaPredial()

        Dim objdatos As New cla_FIPRAVAL
        Dim ds As New DataSet

        ds = objdatos.fun_Consultar_TABLAS_FICHA_PREDIAL(vl_inHILINUFI)

        ' instancia las tablas
        dt_FICHPRED = New DataTable
        dt_FIPRDEEC = New DataTable
        dt_FIPRPROP = New DataTable
        dt_FIPRCONS = New DataTable
        dt_FIPRCACO = New DataTable
        dt_FIPRLIND = New DataTable
        dt_FIPRCART = New DataTable
        dt_FIPRZOEC = New DataTable
        dt_FIPRZOFI = New DataTable

        ' Tabla 0
        dt_FICHPRED = ds.Tables(0)
        ' Tabla 1
        dt_FIPRDEEC = ds.Tables(1)
        ' Tabla 2
        dt_FIPRPROP = ds.Tables(2)
        ' Tabla 3
        dt_FIPRCONS = ds.Tables(3)
        ' Tabla 4
        'dt_FIPRCACO = ds.Tables(4)
        ' Tabla 5
        'dt_FIPRLIND = ds.Tables(5)
        ' Tabla 6
        'dt_FIPRCART = ds.Tables(6)
        ' Tabla 7
        dt_FIPRZOEC = ds.Tables(7)
        ' Tabla 8
        'dt_FIPRZOFI = ds.Tables(8)

    End Sub
    Private Sub pro_CargarDatosHistoricosDeLiquidacion()

        Try

            ' declara las variables de la cedula catastral
            Dim inFIPRCLSE As Integer = dt_FICHPRED.Rows(0).Item("FIPRCLSE")
            Dim stFIPRMUNI As String = fun_Formato_Mascara_3_String(Trim(dt_FICHPRED.Rows(0).Item("FIPRMUNI")))
            Dim stFIPRCORR As String = fun_Formato_Mascara_2_String(Trim(dt_FICHPRED.Rows(0).Item("FIPRCORR")))
            Dim stFIPRBARR As String = fun_Formato_Mascara_3_String(Trim(dt_FICHPRED.Rows(0).Item("FIPRBARR")))
            Dim stFIPRMANZ As String = fun_Formato_Mascara_3_String(Trim(dt_FICHPRED.Rows(0).Item("FIPRMANZ")))
            Dim stFIPRPRED As String = fun_Formato_Mascara_5_String(Trim(dt_FICHPRED.Rows(0).Item("FIPRPRED")))
            Dim stFIPREDIF As String = fun_Formato_Mascara_3_String(Trim(dt_FICHPRED.Rows(0).Item("FIPREDIF")))
            Dim stFIPRUNPR As String = fun_Formato_Mascara_5_String(Trim(dt_FICHPRED.Rows(0).Item("FIPRUNPR")))

            ' llena las variables locales
            vl_inHILINUFI = vl_inHILINUFI
            vl_stHILICECA = inFIPRCLSE & stFIPRMUNI & stFIPRCORR & stFIPRBARR & stFIPRMANZ & stFIPRPRED & stFIPREDIF & stFIPRUNPR
            vl_inHILIVIGE = vl_inHILIVIGE
            vl_loHILIAVPR = fun_RecuperaAvaluoCatastral()
            vl_loHILIAVCA = fun_RecuperaAvaluoCatastral()
            vl_stHILIDEEC = fun_RecuperaDestinoEconomico()
            vl_stHILIESTR = fun_RecuperaEstratoSocioeconomico()
            vl_boHILILOTE = fun_RecuperaPredioComolote()
            vl_boHILILOCE = False
            vl_boHILILE44 = False
            vl_boHILILE56 = False
            vl_boHILIAUAV = False
            vl_boHILIGRAV = fun_RecuperaPredioComoGravable()
            vl_stHILITIPO = fun_RecuperaTipoDeCalificacion()
            vl_stHILIARCO = fun_RecuperaSumatoriaAreaDeConstruccion()
            vl_inHILIARTE = fun_RecuperaSumatoriaAreaDeTerreno()
            vl_inHILIPUNT = fun_RecuperaPuntosDeCalificacion()
            vl_stHILIESTA = "ac"
            vl_stHILITIRE = Trim(dt_FICHPRED.Rows(0).Item("FIPRTIRE"))
            vl_stHILIVIRE = Trim(dt_FICHPRED.Rows(0).Item("FIPRVIGE"))
            vl_stHILIRESO = Trim(dt_FICHPRED.Rows(0).Item("FIPRRESO"))

        Catch ex As Exception
            MessageBox.Show(Err.Description & vl_inHILINUFI)
        End Try

    End Sub
    Private Sub pro_GuardarHistoricoDeLiquidacion()

        Try

            Dim objdatos As New cla_HISTLIQU

            objdatos.fun_Insertar_HISTLIQU(vl_inHILINUFI, _
                                           vl_stHILICECA, _
                                           vl_inHILIVIGE, _
                                           vl_loHILIAVPR, _
                                           vl_loHILIAVCA, _
                                           vl_stHILIDEEC, _
                                           vl_stHILIESTR, _
                                           vl_boHILILOTE, _
                                           vl_boHILILOCE, _
                                           vl_boHILILE44, _
                                           vl_boHILILE56, _
                                           vl_boHILIAUAV, _
                                           vl_boHILIGRAV, _
                                           vl_stHILITIPO, _
                                           vl_stHILIARCO, _
                                           vl_inHILIARTE, _
                                           vl_inHILIPUNT, _
                                           vl_stHILIESTA, _
                                           vl_stHILITIRE, _
                                           vl_stHILIVIRE, _
                                           vl_stHILIRESO)

        Catch ex As Exception
            MessageBox.Show(Err.Description & vl_inHILINUFI)
        End Try

    End Sub
    Private Sub pro_EliminarHistoricoDeLiquidacion()

        Try
            Dim objdatos As New cla_HISTLIQU

            objdatos.fun_Eliminar_NUFI_Y_VIGE_X_HISTLIQU(vl_inHILINUFI, vl_inHILIVIGE)

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub pro_ActualizarHistoricoDeLiquidacion()

        Try
            Dim objdatos As New cla_HISTLIQU

            objdatos.fun_Actualizar_NUFI_VIGE_X_HISTLIQU(vl_inHILINUFI, _
                                                       vl_stHILICECA, _
                                                       vl_inHILIVIGE, _
                                                       vl_loHILIAVPR, _
                                                       vl_loHILIAVCA, _
                                                       vl_stHILIDEEC, _
                                                       vl_stHILIESTR, _
                                                       vl_boHILILOTE, _
                                                       vl_boHILILOCE, _
                                                       vl_boHILILE44, _
                                                       vl_boHILILE56, _
                                                       vl_boHILIAUAV, _
                                                       vl_boHILIGRAV, _
                                                       vl_stHILITIPO, _
                                                       vl_stHILIARCO, _
                                                       vl_inHILIARTE, _
                                                       vl_inHILIPUNT, _
                                                       vl_stHILIESTA, _
                                                       vl_stHILITIRE, _
                                                       vl_stHILIVIRE, _
                                                       vl_stHILIRESO)


        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub



#End Region

#Region "FUNCIONES"

    Private Function fun_RecuperaAvaluoCatastral() As Long

        Try
            Dim loAvaluoCatastral As Long = 0

            Dim objdatos11 As New cla_HISTAVAL
            Dim tbl11 As New DataTable

            tbl11 = objdatos11.fun_Buscar_CODIGO_NUFI_VIGE_X_HISTAVAL(vl_inHILINUFI, vl_inHILIVIGE)

            If tbl11.Rows.Count > 0 Then
                loAvaluoCatastral = CType(tbl11.Rows(0).Item("HIAVAVAL"), Long)
            Else
                loAvaluoCatastral = 0
            End If

            Return loAvaluoCatastral

        Catch ex As Exception
            Return 0
            MessageBox.Show(Err.Description & "fun_RecuperaAvaluoCatastral")
        End Try

    End Function
    Private Function fun_RecuperaDestinoEconomico() As String

        Try
            Dim stDestino As String = "0"
            Dim bySW As Byte = 0

            Dim objdatos22 As New cla_FIPRDEEC
            Dim tbl22 As New DataTable

            tbl22 = objdatos22.fun_Consultar_FIPRDEEC_X_FICHA_PREDIAL(vl_inHILINUFI)

            If tbl22.Rows.Count > 0 Then

                Dim inPorcentaje1 As Integer = 0
                Dim inPorcentaje2 As Integer = 0

                Dim i As Integer = 0

                For i = 0 To tbl22.Rows.Count - 1

                    If Trim(tbl22.Rows(i).Item("FPDEESTA")) = "ac" Then

                        bySW = 1
                        inPorcentaje1 = tbl22.Rows(i).Item("FPDEPORC")

                        If inPorcentaje1 > inPorcentaje2 Then
                            inPorcentaje2 = inPorcentaje1

                            stDestino = Trim(CStr(tbl22.Rows(i).Item("FPDEDEEC")))
                        End If

                    End If

                Next

                If bySW = 0 Then
                    stDestino = "0"
                End If

            Else
                stDestino = "0"
            End If

            Return stDestino

        Catch ex As Exception
            Return ""
            MessageBox.Show(Err.Description & "fun_RecuperaDestinoEconomico")
        End Try

    End Function
    Private Function fun_RecuperaEstratoSocioeconomico() As String

        Try
            Dim stEstrato As String = "0"
            Dim bySW As Byte = 0

            Dim objdatos22 As New cla_ESTRFIPR
            Dim tbl22 As New DataTable

            tbl22 = objdatos22.fun_Buscar_ESTRATO_X_NRO_DE_FICHA(vl_inHILINUFI)

            If tbl22.Rows.Count > 0 Then
                stEstrato = Trim(tbl22.Rows(0).Item("ESFPESTR"))
            Else
                stEstrato = "0"
            End If

            Return stEstrato

        Catch ex As Exception
            Return ""
            MessageBox.Show(Err.Description & "fun_RecuperaEstratoSocioeconomico")
        End Try

    End Function
    Private Function fun_RecuperaPredioComolote() As Boolean

        Try
            Dim boPredioLote As Boolean = False

            Dim bySW1 As Byte = 0
            Dim bySW2 As Byte = 0

            Dim objdatos33 As New cla_FIPRCONS
            Dim tbl33 As New DataTable

            tbl33 = objdatos33.fun_Consultar_FIPRCONS_X_FICHA_PREDIAL(vl_inHILINUFI)

            If tbl33.Rows.Count > 0 Then

                Dim i As Integer = 0

                For i = 0 To tbl33.Rows.Count - 1

                    If CStr(Trim(tbl33.Rows(i).Item("FPCOESTA"))) = "ac" Then
                        If CInt(tbl33.Rows(i).Item("FPCOCLCO")) = 1 Or CInt(tbl33.Rows(i).Item("FPCOCLCO")) = 2 Then
                            If CLng(tbl33.Rows(i).Item("FPCOARCO")) <> 0 And CInt(tbl33.Rows(i).Item("FPCOPUNT")) <> 0 Then

                                bySW1 = 1
                                boPredioLote = False

                            End If
                        End If
                    End If

                Next

                Dim objdatos34 As New cla_FIPRDEEC
                Dim tbl34 As New DataTable

                tbl34 = objdatos34.fun_Consultar_FIPRDEEC_X_FICHA_PREDIAL(vl_inHILINUFI)

                If tbl34.Rows.Count > 0 Then

                    Dim k As Integer = 0

                    For k = 0 To tbl34.Rows.Count - 1

                        If Trim(tbl34.Rows(i).Item("FPDEESTA")) = "ac" Then
                            If tbl34.Rows(i).Item("FPDEDEEC") = 12 Or tbl34.Rows(i).Item("FPDEDEEC") = 13 Or tbl34.Rows(i).Item("FPDEDEEC") = 14 Then

                                bySW2 = 1
                                boPredioLote = False

                            End If
                        End If

                    Next

                Else
                    bySW2 = 0
                End If

                If bySW1 = 0 Or bySW2 = 0 Then
                    boPredioLote = True
                End If

            Else
                boPredioLote = True
            End If

            Return boPredioLote

        Catch ex As Exception
            Return False
            MessageBox.Show(Err.Description & "fun_RecuperaPredioComolote")
        End Try

    End Function
    Private Function fun_RecuperaPredioComoGravable() As Boolean

        Try
            Dim boPredioGravable As Boolean = True
            Dim bySW As Byte = 0

            Dim objdatos33 As New cla_FIPRPROP
            Dim tbl33 As New DataTable

            tbl33 = objdatos33.fun_Consultar_FIPRPROP_X_FICHA_PREDIAL(vl_inHILINUFI)

            If tbl33.Rows.Count > 0 Then

                Dim i As Integer = 0

                For i = 0 To tbl33.Rows.Count - 1

                    If Trim(tbl33.Rows(i).Item("FPPRESTA")) = "ac" Then
                        If Trim(tbl33.Rows(i).Item("FPPRNUDO")) = vp_stNIT_MUNICIPIO Then

                            bySW = 1
                            boPredioGravable = False

                        End If
                    End If

                Next

                If bySW = 0 Then
                    boPredioGravable = True
                End If

            Else
                boPredioGravable = True
            End If

            Return boPredioGravable

        Catch ex As Exception
            Return True
            MessageBox.Show(Err.Description & "fun_RecuperaPredioComoGravable")
        End Try

    End Function
    Private Function fun_RecuperaTipoDeCalificacion() As String

        Try
            Dim stTipoCalificacion As String = "N"
            Dim bySW As Byte = 0

            Dim objdatos33 As New cla_FIPRCONS
            Dim tbl33 As New DataTable

            tbl33 = objdatos33.fun_Consultar_FIPRCONS_X_FICHA_PREDIAL(vl_inHILINUFI)

            If tbl33.Rows.Count > 0 Then

                Dim deArea1 As Decimal = 0.0
                Dim deArea2 As Decimal = 0.0

                Dim stDepartamento As String = ""
                Dim stMunicipio As String = ""
                Dim stIdentificador As String = ""
                Dim inClaseSector As Integer = 0
                Dim inClaseConstruccion As Integer = 0

                Dim i As Integer = 0

                For i = 0 To tbl33.Rows.Count - 1

                    If Trim(tbl33.Rows(i).Item("FPCOESTA")) = "ac" Then
                        If tbl33.Rows(i).Item("FPCOCLCO") = 1 Or tbl33.Rows(i).Item("FPCOCLCO") = 2 Then

                            bySW = 1
                            deArea1 = CDec(tbl33.Rows(i).Item("FPCOARCO"))

                            If deArea1 > deArea2 Then

                                deArea2 = deArea1

                                stDepartamento = CStr(Trim(tbl33.Rows(i).Item("FPCODEPA")))
                                stMunicipio = CStr(Trim(tbl33.Rows(i).Item("FPCOMUNI")))
                                inClaseSector = CInt(tbl33.Rows(i).Item("FPCOCLSE"))
                                stIdentificador = CStr(Trim(tbl33.Rows(i).Item("FPCOTICO")))
                                inClaseConstruccion = CInt(tbl33.Rows(i).Item("FPCOCLCO"))

                            End If

                        End If
                    End If

                Next

                If bySW = 0 Then
                    stTipoCalificacion = "N"
                Else

                    Dim objdatos55 As New cla_TIPOCONS
                    Dim tbl55 As New DataTable

                    tbl55 = objdatos55.fun_buscar_TICODEPA_X_TICOMUNI_X_TICOCLCO_X_TICOCLSE_X_TIPOCONS_X_CLASCONS_MANT_TIPOCONS(stDepartamento, stMunicipio, inClaseConstruccion, inClaseSector, stIdentificador)

                    If tbl55.Rows.Count > 0 Then
                        stTipoCalificacion = Trim(tbl55.Rows(0).Item("TICOTIPO"))
                    Else
                        stTipoCalificacion = "N"
                    End If

                End If

            Else
                stTipoCalificacion = "N"
            End If

            Return stTipoCalificacion

        Catch ex As Exception
            Return ""
            MessageBox.Show(Err.Description & "fun_RecuperaTipoDeCalificacion")
        End Try

    End Function
    Private Function fun_RecuperaPuntosDeCalificacion() As Integer

        Try
            Dim inPuntosCalificacion As Integer = 0
            Dim bySW As Byte = 0

            Dim objdatos33 As New cla_FIPRCONS
            Dim tbl33 As New DataTable

            tbl33 = objdatos33.fun_Consultar_FIPRCONS_X_FICHA_PREDIAL(vl_inHILINUFI)

            If tbl33.Rows.Count > 0 Then

                Dim deArea1 As Decimal = 0.0
                Dim deArea2 As Decimal = 0.0

                Dim i As Integer = 0

                For i = 0 To tbl33.Rows.Count - 1

                    If Trim(tbl33.Rows(i).Item("FPCOESTA")) = "ac" Then
                        If tbl33.Rows(i).Item("FPCOCLCO") = 1 Or tbl33.Rows(i).Item("FPCOCLCO") = 2 Then

                            bySW = 1
                            deArea1 = CDec(tbl33.Rows(i).Item("FPCOARCO"))

                            If deArea1 > deArea2 Then

                                deArea2 = deArea1

                                inPuntosCalificacion = CInt(tbl33.Rows(i).Item("FPCOPUNT"))

                            End If

                        End If
                    End If

                Next

                If bySW = 0 Then
                    inPuntosCalificacion = 0
                End If

            Else
                inPuntosCalificacion = 0
            End If

            Return inPuntosCalificacion

        Catch ex As Exception
            Return 0
            MessageBox.Show(Err.Description & "fun_RecuperaPuntosDeCalificacion")
        End Try

    End Function
    Private Function fun_RecuperaSumatoriaAreaDeTerreno() As Integer

        Try
            Dim inAreaTerreno As Integer = 0

            Dim objdatos11 As New cla_HISTAVAL
            Dim tbl11 As New DataTable

            tbl11 = objdatos11.fun_Buscar_CODIGO_NUFI_VIGE_X_HISTAVAL(vl_inHILINUFI, vl_inHILIVIGE)

            If tbl11.Rows.Count > 0 Then
                inAreaTerreno = CInt(tbl11.Rows(0).Item("HIAVATPR")) + CInt(tbl11.Rows(0).Item("HIAVATCO"))
            Else
                inAreaTerreno = 0
            End If

            Return inAreaTerreno

        Catch ex As Exception
            Return 0
            MessageBox.Show(Err.Description & "fun_RecuperaSumatoriaAreaDeTerreno")
        End Try

    End Function
    Private Function fun_RecuperaSumatoriaAreaDeConstruccion() As Integer

        Try
            Dim inAreaConstruccion As Integer = 0

            Dim objdatos11 As New cla_HISTAVAL
            Dim tbl11 As New DataTable

            tbl11 = objdatos11.fun_Buscar_CODIGO_NUFI_VIGE_X_HISTAVAL(vl_inHILINUFI, vl_inHILIVIGE)

            If tbl11.Rows.Count > 0 Then
                inAreaConstruccion = CInt(tbl11.Rows(0).Item("HIAVACPR")) + CInt(tbl11.Rows(0).Item("HIAVACCO"))
            Else
                inAreaConstruccion = 0
            End If

            Return inAreaConstruccion

        Catch ex As Exception
            Return ""
            MessageBox.Show(Err.Description & "fun_RecuperaSumatoriaAreaDeConstruccion")
        End Try

    End Function

#End Region

End Module
