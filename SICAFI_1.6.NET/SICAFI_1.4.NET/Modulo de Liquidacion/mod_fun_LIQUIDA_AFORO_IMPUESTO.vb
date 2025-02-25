Imports REGLAS_DEL_NEGOCIO
Imports System
Imports System.IO
Imports System.Data
Imports System.Data.Sqlclient
Imports System.Configuration
Imports System.Text

Module mod_fun_LIQUIDA_AFORO_IMPUESTO

    '=================================
    '*** LIQUIDA AFORO DE IMPUESTO ***
    '=================================

#Region "VARIABLES"

#Region "Tablas Impuesto Predial"

    Private dt_FICHPRED As New DataTable
    Private dt_HISTZONA As New DataTable
    Private dt_HISTLIQU As New DataTable

#End Region

#Region "Variables Impuesto Predial"

    Private vl_inAFSINUFI As Integer = 0
    Private vl_inAFSITIIM As Integer = 0
    Private vl_inAFSICONC As Integer = 0
    Private vl_inAFSIVIGE As Integer = 0
    Private vl_inAFSICLSE As Integer = 0
    Private vl_loAFSIVABA As Long = 0
    Private vl_loAFSIVALI As Long = 0
    Private vl_loAFSIVAIM As Long = 0
    Private vl_stAFSIZO01 As String = ""
    Private vl_stAFSIZO02 As String = ""
    Private vl_stAFSIZO03 As String = ""
    Private vl_stAFSIZO04 As String = ""
    Private vl_stAFSIZO05 As String = ""
    Private vl_stAFSIZO06 As String = ""
    Private vl_stAFSIZO07 As String = ""
    Private vl_stAFSITA01 As String = ""
    Private vl_stAFSITA02 As String = ""
    Private vl_stAFSITA03 As String = ""
    Private vl_stAFSITA04 As String = ""
    Private vl_stAFSITA05 As String = ""
    Private vl_stAFSITA06 As String = ""
    Private vl_stAFSITA07 As String = ""
    Private vl_inAFSIMOLI As Integer = 0
    Private vl_inAFSITIAF As Integer = 0
    Private vl_boAFSIEXEN As Boolean = False
    Private vl_boAFSILEY44 As Boolean = False
    Private vl_boPPLIPOAP As Boolean = False
    Private vl_boAFSIAUAV As Boolean = False
    Private vl_dePPLIPOAP As Decimal = 0.0
    Private vl_inPREXPOAP As Integer = 0
    Private vl_stAFSIESTA As String = "ac"

    Private vl_inAFSITIFI As Integer = 0
    Private vl_loAFSIVALO As Long = 0

    Private vl_boProcesarRegistro As Boolean = False
    Private vl_boPredioExentoPorNit As Boolean = False

    Private vl_boAplicarMaximoLiquidacion As Boolean = False
    Private vl_boAplicaTarifaUnicaAlLote As Boolean = False
    Private vl_boAplicaTarifaPorZonaAlLote As Boolean = False

#End Region

#Region "Conexion"

    Private oEjecutar As New SqlCommand
    Private oConexion As New SqlConnection
    Private oAdapter As New SqlDataAdapter
    Private oReader As SqlDataReader

#End Region

#End Region

#Region "PROCEDIMIENTOS"

    Public Sub pro_LIQUIDA_AFORO_IMPUESTO(ByVal o_inAFSINUFI As Integer, _
                                          ByVal o_inAFSIVIGE As Integer, _
                                          ByVal o_inAFSICLSE As Integer, _
                                          ByVal o_inAFSITIIM As Integer, _
                                          ByVal o_inAFSICONC As Integer, _
                                          ByVal o_boAplicaMaximoLiquidacion As Boolean, _
                                          ByVal o_boAplicaTarifaUnicaLote As Boolean, _
                                          ByVal o_boAplicaTarifaZonaLote As Boolean)

        Try
            ' almaceno las variables
            vl_inAFSINUFI = o_inAFSINUFI
            vl_inAFSIVIGE = o_inAFSIVIGE
            vl_inAFSICLSE = o_inAFSICLSE
            vl_inAFSITIIM = o_inAFSITIIM
            vl_inAFSICONC = o_inAFSICONC

            vl_boAplicarMaximoLiquidacion = o_boAplicaMaximoLiquidacion
            vl_boAplicaTarifaUnicaAlLote = o_boAplicaTarifaUnicaLote
            vl_boAplicaTarifaPorZonaAlLote = o_boAplicaTarifaZonaLote

            ' limpia las variables
            pro_DeclaraVariablesImpuestoPredial()

            ' carga la tabla de ficha predial
            pro_CargarFichaPredial()

            ' declara la instacia
            Dim objFORMMUNI As New cla_FORMMUNI
            Dim tblFORMMUNI As DataTable

            ' almacena la tabla
            tblFORMMUNI = objFORMMUNI.fun_Consultar_CAMPOS_FORMMUNI

            ' verifica la existencia de registros
            If tblFORMMUNI.Rows.Count > 0 Then

                'declara la variable
                Dim sw1 As Byte = 0
                Dim j1 As Integer = 0

                While j1 < tblFORMMUNI.Rows.Count And sw1 = 0
                    If Trim(tblFORMMUNI.Rows(j1).Item("FOMUESTA")) = "ac" Then

                        If Trim(tblFORMMUNI.Rows(j1).Item("FOMUDEPA")) = Trim(dt_FICHPRED.Rows(0).Item("FIPRDEPA")) And _
                           Trim(tblFORMMUNI.Rows(j1).Item("FOMUMUNI")) = Trim(dt_FICHPRED.Rows(0).Item("FIPRMUNI")) And _
                           CInt(tblFORMMUNI.Rows(j1).Item("FOMUCLSE")) = vl_inAFSICLSE And _
                           CInt(tblFORMMUNI.Rows(j1).Item("FOMUVIGE")) = vl_inAFSIVIGE And _
                           CInt(tblFORMMUNI.Rows(j1).Item("FOMUTIIM")) = vl_inAFSITIIM And _
                           CInt(tblFORMMUNI.Rows(j1).Item("FOMUCONC")) = vl_inAFSICONC Then

                            ' llena las variables
                            Dim inFOMUTIIM As Integer = CInt(tblFORMMUNI.Rows(j1).Item("FOMUTIIM"))
                            Dim inFOMUCONC As Integer = CInt(tblFORMMUNI.Rows(j1).Item("FOMUCONC"))
                            Dim stFOMUFORM As String = CStr(Trim(tblFORMMUNI.Rows(j1).Item("FOMUFORM")))

                            ' busca la formula de liquidacion
                            If stFOMUFORM = "TARIPUNT" Then

                                ' verifica que la ficha predial y su estado
                                If dt_FICHPRED.Rows(0).Item("FIPRTIFI") = 0 Then
                                    If Trim(dt_FICHPRED.Rows(0).Item("FIPRESTA")) = "ac" Then

                                        ' carga las tablas 
                                        pro_CargarTablasImpuestoPredial()

                                        ' afora el predio
                                        pro_AforoConceptoImpuestoPredial()

                                        ' verifica que si existe un resultado 
                                        If vl_boProcesarRegistro = True Then

                                            ' actualiza el registro
                                            pro_EliminaAforoDeImpuestoPredial()
                                            pro_GuardarAforoDeImpuestoPredial()

                                        End If

                                    End If
                                End If

                                ' formula por destinación económica
                            ElseIf stFOMUFORM = "TARIRAAR" Then

                                ' verifica que la ficha predial y su estado
                                If dt_FICHPRED.Rows(0).Item("FIPRTIFI") = 0 Then
                                    If Trim(dt_FICHPRED.Rows(0).Item("FIPRESTA")) = "ac" Then

                                        ' carga las tablas
                                        pro_CargarTablasImpuestoPredial()

                                        ' afora el predio
                                        pro_AforoConceptoImpuestoPredialDestinoEconomico()

                                        ' actualiza el registro
                                        pro_EliminaAforoDeImpuestoPredial()
                                        pro_GuardarAforoDeImpuestoPredial()

                                    End If

                                End If

                                ' formula por rango de avaluo y estrato
                            ElseIf stFOMUFORM = "TARIRAAV" Then

                                ' verifica que la ficha predial y su estado
                                If dt_FICHPRED.Rows(0).Item("FIPRTIFI") = 0 Then
                                    If Trim(dt_FICHPRED.Rows(0).Item("FIPRESTA")) = "ac" Then

                                        ' carga las tablas
                                        pro_CargarTablasImpuestoPredial()

                                        ' afora el predio
                                        pro_AforoConceptoImpuestoPredialRangoAvaluoYEstrato()

                                        ' actualiza el registro
                                        pro_EliminaAforoDeImpuestoPredial()
                                        pro_GuardarAforoDeImpuestoPredial()

                                    End If

                                End If
                            End If

                            ' cierra el ciclo
                            sw1 = 1
                        Else
                            j1 = j1 + 1
                        End If
                    End If

                End While
            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub

    Private Sub pro_CargarFichaPredial()

        dt_FICHPRED = New DataTable

        ' carga las tablas
        Dim objFICHPRED As New cla_FICHPRED

        dt_FICHPRED = objFICHPRED.fun_Consultar_FICHA_PREDIAL_X_NRO_FICHA_PREDIAL(vl_inAFSINUFI)

        ' almacena el tipo de ficha
        vl_inAFSITIFI = dt_FICHPRED.Rows(0).Item("FIPRTIFI")

    End Sub

    Private Sub pro_AforoConceptoImpuestoPredial()

        Try
            ' instancia la clase
            Dim o_HISTLIQU As New cla_HISTLIQU

            ' crea la tabla
            dt_HISTLIQU = New DataTable

            ' almacena la consulta
            dt_HISTLIQU = o_HISTLIQU.fun_Buscar_CODIGO_NUFI_VIGE_X_HISTLIQU(vl_inAFSINUFI, vl_inAFSIVIGE)

            ' almacena el avaluo catastral
            If dt_HISTLIQU.Rows.Count > 0 Then

                ' almacena el avaluo
                vl_loAFSIVABA = CType(dt_HISTLIQU.Rows(0).Item("HILIAVCA"), Long)

                '=====================================
                ' LIQUIDA EL PREDIO SI ES LOTE URBANO
                '=====================================

                If dt_HISTLIQU.Rows(0).Item("HILILOTE") = True And _
                   dt_FICHPRED.Rows(0).Item("FIPRCLSE") = 1 And _
                   dt_FICHPRED.Rows(0).Item("FIPRTIFI") = 0 Then

                    Dim obj_TARIDEEC As New cla_TARIDEEC
                    Dim tbl_TARIDEEC As New DataTable

                    tbl_TARIDEEC = obj_TARIDEEC.fun_Buscar_CODIGO_DEPA_MUNI_CLSE_VIGE_X_TARIDEEC(Trim(dt_FICHPRED.Rows(0).Item("FIPRDEPA")), _
                                                                                                 Trim(dt_FICHPRED.Rows(0).Item("FIPRMUNI")), _
                                                                                                 vl_inAFSICLSE, _
                                                                                                 vl_inAFSIVIGE)

                    ' verifica que existan registros
                    If tbl_TARIDEEC.Rows.Count > 0 Then

                        Dim sw1 As Byte = 0
                        Dim j1 As Integer = 0
                        Dim boExiteDestino As Boolean = False

                        While j1 < tbl_TARIDEEC.Rows.Count And sw1 = 0
                            If Trim(tbl_TARIDEEC.Rows(j1).Item("TADEESTA")) = "ac" And Trim(dt_HISTLIQU.Rows(0).Item("HILIDEEC")) = "." Then
                                vl_stAFSITA01 = CType(33, Decimal)

                                boExiteDestino = True
                                sw1 = 1

                            ElseIf Trim(tbl_TARIDEEC.Rows(j1).Item("TADEESTA")) = "ac" And Trim(dt_HISTLIQU.Rows(0).Item("HILIDEEC")) <> "." Then
                                If tbl_TARIDEEC.Rows(j1).Item("TADEDEEC") = dt_HISTLIQU.Rows(0).Item("HILIDEEC") Then
                                    vl_stAFSITA01 = CType(tbl_TARIDEEC.Rows(j1).Item("TADETARI"), Decimal)

                                    boExiteDestino = True
                                    sw1 = 1
                                Else
                                    j1 = j1 + 1
                                End If
                            End If

                        End While

                        ' liquida el predial segun la destinacion
                        If boExiteDestino = True Then

                            ' declaro las variables
                            Dim inZonaEconomica As Integer = 0
                            Dim inPorcentajeZona As Integer = 0

                            ' declaro las variable
                            Dim k As Integer = 0

                            ' recorro las zonas
                            For k = 0 To dt_HISTZONA.Rows.Count - 1

                                If Trim(dt_HISTZONA.Rows(k).Item("HIZOESTA")) = "ac" Then

                                    ' declaro las variables
                                    inZonaEconomica = CType(dt_HISTZONA.Rows(k).Item("HIZOZOEC"), Integer)
                                    inPorcentajeZona = CType(dt_HISTZONA.Rows(k).Item("HIZOPORC"), Integer)

                                    ' almacena la zona
                                    If k = 0 Then
                                        vl_stAFSIZO01 = inZonaEconomica & " - " & inPorcentajeZona & " %"
                                    ElseIf k = 1 Then
                                        vl_stAFSIZO02 = inZonaEconomica & " - " & inPorcentajeZona & " %"
                                    ElseIf k = 2 Then
                                        vl_stAFSIZO03 = inZonaEconomica & " - " & inPorcentajeZona & " %"
                                    ElseIf k = 3 Then
                                        vl_stAFSIZO04 = inZonaEconomica & " - " & inPorcentajeZona & " %"
                                    ElseIf k = 4 Then
                                        vl_stAFSIZO05 = inZonaEconomica & " - " & inPorcentajeZona & " %"
                                    ElseIf k = 5 Then
                                        vl_stAFSIZO06 = inZonaEconomica & " - " & inPorcentajeZona & " %"
                                    ElseIf k = 6 Then
                                        vl_stAFSIZO07 = inZonaEconomica & " - " & inPorcentajeZona & " %"
                                    End If

                                End If

                            Next

                            vl_boProcesarRegistro = True

                            vl_inAFSINUFI = dt_FICHPRED.Rows(0).Item("FIPRNUFI")

                            ' aplica tarifa unica
                            If vl_boAplicaTarifaUnicaAlLote = True Then

                                vl_loAFSIVALI = (vl_loAFSIVABA * CDec(vl_stAFSITA01) / 1000)
                                vl_loAFSIVAIM = (vl_loAFSIVABA * CDec(vl_stAFSITA01) / 1000)

                                ' aplica tarifa por zona
                            ElseIf vl_boAplicaTarifaPorZonaAlLote = True Then

                                Dim deTarifa As Decimal = 0.0

                                Dim objdatos55 As New cla_TARIZOEC
                                Dim tbl55 As New DataTable

                                tbl55 = objdatos55.fun_Buscar_CODIGO_DEPA_MUNI_CLSE_VIGE_ZOEC_X_TARIZOEC(Trim(dt_FICHPRED.Rows(0).Item("FIPRDEPA")), Trim(dt_FICHPRED.Rows(0).Item("FIPRMUNI")), vl_inAFSICLSE, vl_inAFSIVIGE, inZonaEconomica)

                                ' verifica si existen registros
                                If tbl55.Rows.Count > 0 Then

                                    vl_stAFSITA01 = CType(tbl55.Rows(0).Item("TAZETALO"), Decimal)

                                    vl_stAFSIZO01 = CStr(Trim(inZonaEconomica)) & " - " & CStr(inPorcentajeZona) & " %"

                                    vl_loAFSIVALI = (vl_loAFSIVABA * CDec(vl_stAFSITA01) / 1000)
                                    vl_loAFSIVAIM = (vl_loAFSIVABA * CDec(vl_stAFSITA01) / 1000)

                                End If

                            End If

                            vl_boAFSIEXEN = fun_PredioExentoImpuestoPredial()
                            vl_inAFSITIAF = fun_TipoDeAforoImpuestoPredial()
                            vl_boAFSILEY44 = fun_Ley44de1990()
                            vl_inAFSIMOLI = fun_ModoDeLiquidacionImpuestoPredial()

                            If vl_boPredioExentoPorNit = True And vl_boAFSIEXEN = True Then
                                vl_boAFSILEY44 = False
                                vl_loAFSIVALI = 0
                                vl_loAFSIVAIM = 0
                                vl_inAFSIMOLI = 1
                            End If

                        End If

                    End If

                Else
                    '===============================
                    ' *** EXISTEN CONSTRUCCIONES ***
                    '===============================

                    ' declaro la variable
                    Dim boZonasActivas As Boolean = False
                    Dim deTarifa As Decimal = 0.0

                    ' verifica que existan zonas 
                    If dt_HISTZONA.Rows.Count = 0 Then
                        boZonasActivas = False
                    Else
                        If dt_HISTZONA.Rows.Count = 0 Then
                            boZonasActivas = False
                        Else
                            Dim i As Integer = 0

                            For i = 0 To dt_HISTZONA.Rows.Count - 1
                                If Trim(dt_HISTZONA.Rows(i).Item("HIZOESTA")) = "ac" Then
                                    boZonasActivas = True
                                End If
                            Next

                        End If
                    End If

                    ' buaca la tarifa segun zona 
                    If boZonasActivas = False Then
                        vl_boProcesarRegistro = False
                    Else

                        Dim k As Integer = 0

                        ' recorro las zonas
                        For k = 0 To dt_HISTZONA.Rows.Count - 1

                            If Trim(dt_HISTZONA.Rows(k).Item("HIZOESTA")) = "ac" Then

                                ' declaro las variables
                                Dim inZonaEconomica As Integer = CType(dt_HISTZONA.Rows(k).Item("HIZOZOEC"), Integer)
                                Dim inPorcentajeZona As Integer = CType(dt_HISTZONA.Rows(k).Item("HIZOPORC"), Integer)

                                ' almacena la zona
                                If k = 0 Then
                                    vl_stAFSIZO01 = inZonaEconomica & "-" & inPorcentajeZona & "%"
                                ElseIf k = 1 Then
                                    vl_stAFSIZO02 = inZonaEconomica & "-" & inPorcentajeZona & "%"
                                ElseIf k = 2 Then
                                    vl_stAFSIZO03 = inZonaEconomica & "-" & inPorcentajeZona & "%"
                                ElseIf k = 3 Then
                                    vl_stAFSIZO04 = inZonaEconomica & "-" & inPorcentajeZona & "%"
                                ElseIf k = 4 Then
                                    vl_stAFSIZO05 = inZonaEconomica & "-" & inPorcentajeZona & "%"
                                ElseIf k = 5 Then
                                    vl_stAFSIZO06 = inZonaEconomica & "-" & inPorcentajeZona & "%"
                                ElseIf k = 6 Then
                                    vl_stAFSIZO07 = inZonaEconomica & "-" & inPorcentajeZona & "%"
                                End If

                                ' instancia la clase
                                Dim objdatos55 As New cla_TARIZOEC
                                Dim tbl55 As New DataTable

                                tbl55 = objdatos55.fun_Buscar_CODIGO_DEPA_MUNI_CLSE_VIGE_ZOEC_X_TARIZOEC(Trim(dt_FICHPRED.Rows(0).Item("FIPRDEPA")), Trim(dt_FICHPRED.Rows(0).Item("FIPRMUNI")), vl_inAFSICLSE, vl_inAFSIVIGE, inZonaEconomica)

                                ' verifica si existen registros
                                If tbl55.Rows.Count > 0 Then

                                    ' declaro la variable con la zona aplicada
                                    Dim inZonaAplicada As Integer = 0

                                    ' almacena el tipo
                                    Dim stFPCOTIPO As String = Trim(dt_HISTLIQU.Rows(0).Item("HILITIPO"))

                                    ' busca la tipologia 
                                    If Trim(stFPCOTIPO) = "." Then
                                        inZonaAplicada = CType(tbl55.Rows(0).Item("TAZEZOEC"), Decimal)
                                    Else
                                        Dim boZonaAplicada As Boolean = False

                                        If Trim(stFPCOTIPO) = "R" Or Trim(stFPCOTIPO) = "O" Or Trim(stFPCOTIPO) = "N" Then
                                            inZonaAplicada = CType(tbl55.Rows(0).Item("TAZEZOAP"), Decimal)
                                            boZonaAplicada = True

                                        ElseIf Trim(stFPCOTIPO) = "C" Or Trim(stFPCOTIPO) = "I" Then
                                            inZonaAplicada = CType(tbl55.Rows(0).Item("TAZEZOEC"), Decimal)
                                            boZonaAplicada = True
                                        End If

                                        ' aplica porcentaje de incremento o decremento a la tarifa 
                                        If CType(tbl55.Rows(0).Item("TAZESIGN"), String) = "+" Then
                                            inZonaAplicada += CType(Trim(tbl55.Rows(0).Item("TAZEPORC")), Decimal)

                                        ElseIf CType(tbl55.Rows(0).Item("TAZESIGN"), String) = "-" Then
                                            inZonaAplicada -= CType(Trim(tbl55.Rows(0).Item("TAZEPORC")), Decimal)
                                        End If

                                        ' instancia la clase
                                        Dim objdatos56 As New cla_TARIZOEC
                                        Dim tbl56 As New DataTable

                                        tbl56 = objdatos56.fun_Buscar_CODIGO_DEPA_MUNI_CLSE_VIGE_ZOEC_X_TARIZOEC(Trim(dt_FICHPRED.Rows(0).Item("FIPRDEPA")), Trim(dt_FICHPRED.Rows(0).Item("FIPRMUNI")), vl_inAFSICLSE, vl_inAFSIVIGE, inZonaAplicada)

                                        ' verifica si existen registros
                                        If tbl56.Rows.Count = 0 Then
                                            deTarifa = 0.0
                                        Else
                                            If boZonaAplicada = True Then

                                                ' almacena la zona
                                                If k = 0 Then
                                                    vl_stAFSIZO01 = Trim(tbl56.Rows(0).Item("TAZEZOEC")) & "-" & inPorcentajeZona & "%"
                                                ElseIf k = 1 Then
                                                    vl_stAFSIZO02 = Trim(tbl56.Rows(0).Item("TAZEZOEC")) & "-" & inPorcentajeZona & "%"
                                                ElseIf k = 2 Then
                                                    vl_stAFSIZO03 = Trim(tbl56.Rows(0).Item("TAZEZOEC")) & "-" & inPorcentajeZona & "%"
                                                ElseIf k = 3 Then
                                                    vl_stAFSIZO04 = Trim(tbl56.Rows(0).Item("TAZEZOEC")) & "-" & inPorcentajeZona & "%"
                                                ElseIf k = 4 Then
                                                    vl_stAFSIZO05 = Trim(tbl56.Rows(0).Item("TAZEZOEC")) & "-" & inPorcentajeZona & "%"
                                                ElseIf k = 5 Then
                                                    vl_stAFSIZO06 = Trim(tbl56.Rows(0).Item("TAZEZOEC")) & "-" & inPorcentajeZona & "%"
                                                ElseIf k = 6 Then
                                                    vl_stAFSIZO07 = Trim(tbl56.Rows(0).Item("TAZEZOEC")) & "-" & inPorcentajeZona & "%"
                                                End If

                                            End If

                                            If CInt(dt_HISTLIQU.Rows(0).Item("HILIPUNT")) >= 0 And CInt(dt_HISTLIQU.Rows(0).Item("HILIPUNT")) <= 10 Then
                                                deTarifa = CType(tbl56.Rows(0).Item("TAZETA01"), Decimal)
                                            End If

                                            If CInt(dt_HISTLIQU.Rows(0).Item("HILIPUNT")) >= 11 And CInt(dt_HISTLIQU.Rows(0).Item("HILIPUNT")) <= 28 Then
                                                deTarifa = CType(tbl56.Rows(0).Item("TAZETA02"), Decimal)
                                            End If

                                            If CInt(dt_HISTLIQU.Rows(0).Item("HILIPUNT")) >= 29 And CInt(dt_HISTLIQU.Rows(0).Item("HILIPUNT")) <= 46 Then
                                                deTarifa = CType(tbl56.Rows(0).Item("TAZETA03"), Decimal)
                                            End If

                                            If CInt(dt_HISTLIQU.Rows(0).Item("HILIPUNT")) >= 47 And CInt(dt_HISTLIQU.Rows(0).Item("HILIPUNT")) <= 64 Then
                                                deTarifa = CType(tbl56.Rows(0).Item("TAZETA04"), Decimal)
                                            End If

                                            If CInt(dt_HISTLIQU.Rows(0).Item("HILIPUNT")) >= 65 And CInt(dt_HISTLIQU.Rows(0).Item("HILIPUNT")) <= 84 Then
                                                deTarifa = CType(tbl56.Rows(0).Item("TAZETA05"), Decimal)
                                            End If

                                            If CInt(dt_HISTLIQU.Rows(0).Item("HILIPUNT")) >= 85 Then
                                                deTarifa = CType(tbl56.Rows(0).Item("TAZETA06"), Decimal)
                                            End If

                                            ' aplica porcentaje de incremento o decremento a la tarifa 
                                            If CType(Trim(tbl56.Rows(0).Item("TAZESIGN")), String) = "+" Then
                                                deTarifa += CType(tbl56.Rows(0).Item("TAZEPORC"), Decimal)

                                            ElseIf CType(Trim(tbl56.Rows(0).Item("TAZESIGN")), String) = "-" Then
                                                deTarifa -= CType(tbl56.Rows(0).Item("TAZEPORC"), Decimal)
                                            End If

                                            ' almacena la tarifa
                                            If k = 0 Then
                                                vl_stAFSITA01 = deTarifa
                                            ElseIf k = 1 Then
                                                vl_stAFSITA02 = deTarifa
                                            ElseIf k = 2 Then
                                                vl_stAFSITA03 = deTarifa
                                            ElseIf k = 3 Then
                                                vl_stAFSITA04 = deTarifa
                                            ElseIf k = 4 Then
                                                vl_stAFSITA05 = deTarifa
                                            ElseIf k = 5 Then
                                                vl_stAFSITA06 = deTarifa
                                            ElseIf k = 6 Then
                                                vl_stAFSITA07 = deTarifa
                                            End If


                                            ' liquida predial segun la tarifa de la zona correspondiente con su porcentaje
                                            Dim loAvaluoParcial As Long = (vl_loAFSIVABA * inPorcentajeZona) / 100

                                            ' liquida avaluo por tarifa
                                            vl_loAFSIVALI += (((loAvaluoParcial * deTarifa) / 1000))

                                            ' liquida avaluo por tarifa
                                            vl_loAFSIVAIM += (loAvaluoParcial * deTarifa) / 1000

                                        End If
                                    End If
                                End If
                            End If

                        Next

                        vl_boProcesarRegistro = True

                        vl_inAFSINUFI = dt_FICHPRED.Rows(0).Item("FIPRNUFI")

                        vl_boAFSIEXEN = fun_PredioExentoImpuestoPredial()
                        vl_inAFSITIAF = fun_TipoDeAforoImpuestoPredial()

                        If vl_boAplicarMaximoLiquidacion = True Then
                            vl_boPPLIPOAP = fun_PocentajeMaximoPermitidoDeLiquidacionPredial(0, True)
                        Else
                            vl_boPPLIPOAP = False
                        End If

                        vl_boAFSILEY44 = fun_Ley44de1990()
                        vl_inAFSIMOLI = fun_ModoDeLiquidacionImpuestoPredial()

                        If vl_boPredioExentoPorNit = True Then
                            vl_boAFSILEY44 = False
                            vl_loAFSIVALI = 0
                            vl_loAFSIVAIM = 0
                            vl_inAFSIMOLI = 1
                        End If

                    End If

                End If
            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description & dt_FICHPRED.Rows(0).Item("FIPRNUFI"))
        End Try

    End Sub
    Private Sub pro_CargarTablasImpuestoPredial()

        dt_HISTZONA = New DataTable
        dt_HISTLIQU = New DataTable

        Dim objHISTZONA As New cla_HISTZONA
        dt_HISTZONA = objHISTZONA.fun_Consultar_NUFI_VIGE_CLSE_TIFI_X_HISTZONA(vl_inAFSINUFI, vl_inAFSIVIGE, vl_inAFSICLSE, vl_inAFSITIFI)

        Dim objHISTLIQU As New cla_HISTLIQU
        dt_HISTLIQU = objHISTLIQU.fun_Buscar_CODIGO_NUFI_VIGE_X_HISTLIQU(vl_inAFSINUFI, vl_inAFSIVIGE)

    End Sub
    Private Sub pro_GuardarAforoDeImpuestoPredial()

        Try

            Dim objInsertarAFORSUIM As New cla_AFORSUIM

            If objInsertarAFORSUIM.fun_Insertar_AFORSUIM(vl_inAFSINUFI, _
                                                        vl_inAFSITIIM, _
                                                        vl_inAFSICONC, _
                                                        vl_inAFSIVIGE, _
                                                        vl_inAFSICLSE, _
                                                        vl_loAFSIVABA, _
                                                        vl_loAFSIVALI, _
                                                        vl_loAFSIVAIM, _
                                                        vl_stAFSIZO01, _
                                                        vl_stAFSIZO02, _
                                                        vl_stAFSIZO03, _
                                                        vl_stAFSIZO04, _
                                                        vl_stAFSIZO05, _
                                                        vl_stAFSIZO06, _
                                                        vl_stAFSIZO07, _
                                                        vl_stAFSITA01, _
                                                        vl_stAFSITA02, _
                                                        vl_stAFSITA03, _
                                                        vl_stAFSITA04, _
                                                        vl_stAFSITA05, _
                                                        vl_stAFSITA06, _
                                                        vl_stAFSITA07, _
                                                        vl_inAFSIMOLI, _
                                                        vl_inAFSITIAF, _
                                                        vl_boAFSIEXEN, _
                                                        vl_stAFSIESTA) = True Then
            Else
                MessageBox.Show("No se guardo el registro de la ficha nro. " & vl_inAFSINUFI)
            End If


        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub pro_EliminaAforoDeImpuestoPredial()

        Try
            ' elimina el aforo de impuesto
            Dim objdatos As New cla_AFORSUIM

            objdatos.fun_Eliminar_NUFI_VIGE_CLSE_TIIM_CONC_X_AFORSUIM(vl_inAFSINUFI, _
                                                                      vl_inAFSIVIGE, _
                                                                      vl_inAFSICLSE, _
                                                                      vl_inAFSITIIM, _
                                                                      vl_inAFSICONC)

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub pro_DeclaraVariablesImpuestoPredial()

        vl_loAFSIVABA = 0
        vl_loAFSIVALI = 0
        vl_loAFSIVAIM = 0
        vl_stAFSIZO01 = ""
        vl_stAFSIZO02 = ""
        vl_stAFSIZO03 = ""
        vl_stAFSIZO04 = ""
        vl_stAFSIZO05 = ""
        vl_stAFSIZO06 = ""
        vl_stAFSIZO07 = ""
        vl_stAFSITA01 = ""
        vl_stAFSITA02 = ""
        vl_stAFSITA03 = ""
        vl_stAFSITA04 = ""
        vl_stAFSITA05 = ""
        vl_stAFSITA06 = ""
        vl_stAFSITA07 = ""
        vl_inAFSIMOLI = 0
        vl_inAFSITIAF = 0
        vl_boAFSIEXEN = False
        vl_stAFSIESTA = "ac"

        vl_inAFSITIFI = 0
        vl_loAFSIVALO = 0

        vl_boProcesarRegistro = False

    End Sub
    Private Sub pro_MarcarPredioConLey44de1990(ByVal inSUIMNUFI As Integer, ByVal inSUIMVIGE As Integer, ByVal boLey44 As Boolean)

        Try

            ' buscar cadena de conexion
            Dim oCadenaConexion As New REGLAS_DEL_NEGOCIO.cla_ConnectionString
            Dim stCadenaConexion As String = oCadenaConexion.fun_ConnectionString

            ' crear conexión
            oAdapter = New SqlDataAdapter
            oConexion = New SqlConnection(stCadenaConexion)

            ' abre la conexion
            oConexion.Open()

            ' parametros de la consulta
            Dim ParametrosConsulta As String = ""

            ' Concatena la condicion de la consulta
            ParametrosConsulta += "update HISTLIQU "
            ParametrosConsulta += "set HILILE44 = '" & boLey44 & "' "
            ParametrosConsulta += "where HILINUFI = '" & inSUIMNUFI & "' and HILIVIGE = '" & inSUIMVIGE & "' "

            ' ejecuta la consulta
            oEjecutar = New SqlCommand(ParametrosConsulta, oConexion)

            ' procesa la consulta 
            oEjecutar.CommandTimeout = 0
            oEjecutar.CommandType = CommandType.Text

            oReader = oEjecutar.ExecuteReader

            ' cierra la conexion
            oConexion.Close()
            oReader = Nothing

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub

    Private Sub pro_AforoConceptoImpuestoPredialDestinoEconomico()

        Try
            ' instancia la clase
            Dim o_HISTLIQU As New cla_HISTLIQU

            ' crea la tabla
            dt_HISTLIQU = New DataTable

            ' almacena la consulta
            dt_HISTLIQU = o_HISTLIQU.fun_Buscar_CODIGO_NUFI_VIGE_X_HISTLIQU(vl_inAFSINUFI, vl_inAFSIVIGE)

            ' almacena el avaluo catastral
            If dt_HISTLIQU.Rows.Count > 0 Then

                ' almacena el avaluo
                vl_loAFSIVABA = CType(dt_HISTLIQU.Rows(0).Item("HILIAVCA"), Long)

                '==============================================
                '*** LIQUIDA EL PREDIO SI ES URBANO o RURAL ***
                '==============================================

                If (dt_FICHPRED.Rows(0).Item("FIPRCLSE") = 1 Or dt_FICHPRED.Rows(0).Item("FIPRCLSE") = 2) AndAlso _
                   dt_FICHPRED.Rows(0).Item("FIPRTIFI") = 0 Then

                    ' declaro las variables
                    Dim inFIPRNUFI As Integer = vl_inAFSINUFI
                    Dim stFIPRDEPA As String = Trim(dt_FICHPRED.Rows(0).Item("FIPRDEPA"))
                    Dim stFIPRMUNI As String = Trim(dt_FICHPRED.Rows(0).Item("FIPRMUNI"))
                    Dim inFIPRCLSE As Integer = vl_inAFSICLSE
                    Dim inFIPRVIGE As Integer = vl_inAFSIVIGE
                    Dim stFIPRDEEC As String = ""
                    Dim inFIPRARTE As Integer = 0

                    ' declara la instancia
                    Dim obHISTLIQU As New cla_HISTLIQU
                    Dim dtHISTLIQU As New DataTable

                    dtHISTLIQU = obHISTLIQU.fun_Buscar_CODIGO_NUFI_VIGE_X_HISTLIQU(inFIPRNUFI, inFIPRVIGE)

                    If dtHISTLIQU.Rows.Count > 0 Then
                        stFIPRDEEC = CStr(Trim(dtHISTLIQU.Rows(0).Item("HILIDEEC")))
                        inFIPRARTE = CInt(dtHISTLIQU.Rows(0).Item("HILIARTE"))
                    End If

                    ' instancia la clase
                    Dim obj_TARIRAAR As New cla_TARIRAAR
                    Dim tbl_TARIRAAR As New DataTable

                    tbl_TARIRAAR = obj_TARIRAAR.fun_Buscar_CODIGO_DEPA_MUNI_CLSE_VIGE_DEEC_X_TARIRAAR(stFIPRDEPA, stFIPRMUNI, inFIPRCLSE, inFIPRVIGE, stFIPRDEEC)

                    ' verifica que existan registros
                    If tbl_TARIRAAR.Rows.Count > 0 Then

                        Dim sw1 As Byte = 0
                        Dim j1 As Integer = 0
                        Dim boExiteDestino As Boolean = False

                        While j1 < tbl_TARIRAAR.Rows.Count And sw1 = 0

                            If Trim(stFIPRDEEC) = "." Then
                                vl_stAFSITA01 = CType(0, Decimal)

                                boExiteDestino = True
                                sw1 = 1

                            ElseIf Trim(stFIPRDEEC) <> "." Then
                                If fun_Verificar_Dato_Numerico_Evento_Validated(Trim(stFIPRDEEC)) = True Then
                                    If tbl_TARIRAAR.Rows(j1).Item("TARADEEC") = Trim(stFIPRDEEC) Then

                                        Dim loAREAINIC As Long = tbl_TARIRAAR.Rows(j1).Item("TARAAVIN")
                                        Dim loAREAFINA As Long = tbl_TARIRAAR.Rows(j1).Item("TARAAVFI")

                                        If inFIPRARTE >= tbl_TARIRAAR.Rows(j1).Item("TARAAVIN") And inFIPRARTE <= tbl_TARIRAAR.Rows(j1).Item("TARAAVFI") Then
                                            vl_stAFSITA01 = CType(tbl_TARIRAAR.Rows(j1).Item("TARATARI"), Decimal)
                                            boExiteDestino = True
                                            sw1 = 1
                                        Else
                                            j1 = j1 + 1
                                        End If

                                    Else
                                        j1 = j1 + 1
                                    End If

                                Else
                                    j1 = j1 + 1
                                End If

                            End If

                        End While

                        ' liquida el predial segun la destinacion
                        If boExiteDestino = True Then

                            vl_loAFSIVALI = (vl_loAFSIVABA * CDec(vl_stAFSITA01) / 1000)
                            vl_loAFSIVAIM = (vl_loAFSIVABA * CDec(vl_stAFSITA01) / 1000)

                            ' verifica el modo de liquidación
                            vl_boAFSIEXEN = fun_PredioExentoImpuestoPredial()
                            vl_inAFSITIAF = fun_TipoDeAforoImpuestoPredial()
                            vl_boAFSILEY44 = fun_Ley44de1990()
                            vl_inAFSIMOLI = fun_ModoDeLiquidacionImpuestoPredial()

                            If vl_boPredioExentoPorNit = True And vl_boAFSIEXEN = True Then
                                vl_boAFSILEY44 = False
                                vl_loAFSIVALI = 0
                                vl_loAFSIVAIM = 0
                                vl_inAFSIMOLI = 1
                            End If

                        End If

                    End If

                End If

            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description & dt_FICHPRED.Rows(0).Item("FIPRNUFI"))
        End Try

    End Sub
    Private Sub pro_AforoConceptoImpuestoPredialRangoAvaluoYEstrato()

        Try
            ' instancia la clase
            Dim o_HISTLIQU As New cla_HISTLIQU

            ' crea la tabla
            dt_HISTLIQU = New DataTable

            ' almacena la consulta
            dt_HISTLIQU = o_HISTLIQU.fun_Buscar_CODIGO_NUFI_VIGE_X_HISTLIQU(vl_inAFSINUFI, vl_inAFSIVIGE)

            ' almacena el avaluo catastral
            If dt_HISTLIQU.Rows.Count > 0 Then

                ' almacena el avaluo
                vl_loAFSIVABA = CType(dt_HISTLIQU.Rows(0).Item("HILIAVCA"), Long)

                '==============================================
                '*** LIQUIDA EL PREDIO SI ES URBANO o RURAL ***
                '==============================================

                If (dt_FICHPRED.Rows(0).Item("FIPRCLSE") = 1 Or dt_FICHPRED.Rows(0).Item("FIPRCLSE") = 2) AndAlso _
                   dt_FICHPRED.Rows(0).Item("FIPRTIFI") = 0 Then

                    ' declaro las variables
                    Dim inFIPRNUFI As Integer = vl_inAFSINUFI
                    Dim stFIPRDEPA As String = Trim(dt_FICHPRED.Rows(0).Item("FIPRDEPA"))
                    Dim stFIPRMUNI As String = Trim(dt_FICHPRED.Rows(0).Item("FIPRMUNI"))
                    Dim inFIPRCLSE As Integer = vl_inAFSICLSE
                    Dim inFIPRVIGE As Integer = vl_inAFSIVIGE
                    Dim loFIPRAVCA As Long = 0
                    Dim stFIPRTIPO As String = ""
                    Dim stFIPRESSO As String = ""
                    Dim stFIPRDEEC As String = ""
                    Dim boFIPRLOTE As Boolean = False
                    Dim boExisteTarifa As Boolean = False

                    ' declara la instancia
                    Dim obHISTLIQU As New cla_HISTLIQU
                    Dim dtHISTLIQU As New DataTable

                    dtHISTLIQU = obHISTLIQU.fun_Buscar_CODIGO_NUFI_VIGE_X_HISTLIQU(inFIPRNUFI, inFIPRVIGE)

                    If dtHISTLIQU.Rows.Count > 0 Then

                        ' llenas las variables
                        stFIPRTIPO = CStr(Trim(dtHISTLIQU.Rows(0).Item("HILITIPO")))
                        stFIPRESSO = CStr(Trim(dtHISTLIQU.Rows(0).Item("HILIESTR")))
                        stFIPRDEEC = CStr(Trim(dtHISTLIQU.Rows(0).Item("HILIDEEC")))
                        boFIPRLOTE = CBool(dtHISTLIQU.Rows(0).Item("HILILOTE"))
                        loFIPRAVCA = CLng(dtHISTLIQU.Rows(0).Item("HILIAVCA"))

                        ' se liquida como lote
                        If boFIPRLOTE = True Then

                            Dim obj_TARIDEEC As New cla_TARIDEEC
                            Dim tbl_TARIDEEC As New DataTable

                            tbl_TARIDEEC = obj_TARIDEEC.fun_Buscar_CODIGO_DEPA_MUNI_CLSE_VIGE_DEEC_X_TARIDEEC(stFIPRDEPA, stFIPRMUNI, inFIPRCLSE, inFIPRVIGE, stFIPRDEEC)

                            ' verifica que existan registros
                            If tbl_TARIDEEC.Rows.Count > 0 Then
                                vl_stAFSITA01 = CStr(Trim(tbl_TARIDEEC.Rows(0).Item("TADETARI")))
                                boExisteTarifa = True
                            Else
                                vl_stAFSITA01 = 0
                            End If

                            ' si posee construccion
                        ElseIf boFIPRLOTE = False Then

                            ' predio residencial
                            If Trim(stFIPRTIPO) = "R" Then

                                ' instancia la clase
                                Dim obj_TARIRAAV_R As New cla_TARIRAAV
                                Dim tbl_TARIRAAV_R As New DataTable

                                tbl_TARIRAAV_R = obj_TARIRAAV_R.fun_Buscar_CODIGO_DEPA_MUNI_CLSE_VIGE_TIPO_ESTR_X_TARIRAAV(stFIPRDEPA, stFIPRMUNI, inFIPRCLSE, inFIPRVIGE, stFIPRTIPO, stFIPRESSO)

                                ' verifica que existan registros
                                If tbl_TARIRAAV_R.Rows.Count > 0 And Trim(stFIPRTIPO) = "R" Then

                                    Dim sw1 As Byte = 0
                                    Dim j1 As Integer = 0

                                    While j1 < tbl_TARIRAAV_R.Rows.Count And sw1 = 0

                                        If tbl_TARIRAAV_R.Rows(j1).Item("TARADEPA") = CStr(Trim(stFIPRDEPA)) And _
                                           tbl_TARIRAAV_R.Rows(j1).Item("TARAMUNI") = CStr(Trim(stFIPRMUNI)) And _
                                           tbl_TARIRAAV_R.Rows(j1).Item("TARACLSE") = CInt(inFIPRCLSE) And _
                                           tbl_TARIRAAV_R.Rows(j1).Item("TARAVIGE") = CInt(inFIPRVIGE) And _
                                           tbl_TARIRAAV_R.Rows(j1).Item("TARATIPO") = CStr(Trim(stFIPRTIPO)) And _
                                           tbl_TARIRAAV_R.Rows(j1).Item("TARAESTR") = CStr(Trim(stFIPRESSO)) Then

                                            Dim loFIPRAVIN_R As Long = CLng(tbl_TARIRAAV_R.Rows(j1).Item("TARAAVIN"))
                                            Dim loFIPRAVFI_R As Long = CLng(tbl_TARIRAAV_R.Rows(j1).Item("TARAAVFI"))

                                            If loFIPRAVCA >= loFIPRAVIN_R And loFIPRAVCA <= loFIPRAVFI_R Then
                                                vl_stAFSITA01 = CType(tbl_TARIRAAV_R.Rows(j1).Item("TARATARI"), Decimal)
                                                sw1 = 1
                                                boExisteTarifa = True
                                            Else
                                                j1 = j1 + 1
                                            End If

                                        Else
                                            j1 = j1 + 1
                                        End If

                                    End While

                                End If

                                ' predio comercial o industrial
                            ElseIf (Trim(stFIPRTIPO) = "C" Or Trim(stFIPRTIPO) = "I") Then

                                ' instancia la clase
                                Dim obj_TARIRAAV_C As New cla_TARIRAAV
                                Dim tbl_TARIRAAV_C As New DataTable

                                tbl_TARIRAAV_C = obj_TARIRAAV_C.fun_Buscar_CODIGO_DEPA_MUNI_CLSE_VIGE_TIPO_X_TARIRAAV(stFIPRDEPA, stFIPRMUNI, inFIPRCLSE, inFIPRVIGE, stFIPRTIPO)

                                ' verifica que existan registros
                                If tbl_TARIRAAV_C.Rows.Count > 0 And (Trim(stFIPRTIPO) = "C" Or Trim(stFIPRTIPO) = "I") Then

                                    Dim sw1 As Byte = 0
                                    Dim j1 As Integer = 0

                                    While j1 < tbl_TARIRAAV_C.Rows.Count And sw1 = 0

                                        If tbl_TARIRAAV_C.Rows(j1).Item("TARADEPA") = CStr(Trim(stFIPRDEPA)) And _
                                           tbl_TARIRAAV_C.Rows(j1).Item("TARAMUNI") = CStr(Trim(stFIPRMUNI)) And _
                                           tbl_TARIRAAV_C.Rows(j1).Item("TARACLSE") = CInt(inFIPRCLSE) And _
                                           tbl_TARIRAAV_C.Rows(j1).Item("TARAVIGE") = CInt(inFIPRVIGE) And _
                                           tbl_TARIRAAV_C.Rows(j1).Item("TARATIPO") = CStr(Trim(stFIPRTIPO)) Then

                                            Dim loFIPRAVIN_C As Long = CLng(tbl_TARIRAAV_C.Rows(j1).Item("TARAAVIN"))
                                            Dim loFIPRAVFI_C As Long = CLng(tbl_TARIRAAV_C.Rows(j1).Item("TARAAVFI"))

                                            If loFIPRAVCA >= loFIPRAVIN_C And loFIPRAVCA <= loFIPRAVFI_C Then
                                                vl_stAFSITA01 = CType(tbl_TARIRAAV_C.Rows(j1).Item("TARATARI"), Decimal)
                                                sw1 = 1
                                                boExisteTarifa = True
                                            Else
                                                j1 = j1 + 1
                                            End If

                                        Else
                                            j1 = j1 + 1
                                        End If

                                    End While

                                End If

                                ' predio no convencional
                            ElseIf (Trim(stFIPRTIPO) = "O") Then

                                ' instancia la clase
                                Dim objFICHPRED As New cla_FICHPRED
                                Dim tblFICHPRED As New DataTable

                                tblFICHPRED = objFICHPRED.fun_Consultar_FICHA_PREDIAL_X_NRO_FICHA_PREDIAL(inFIPRNUFI)

                                If tblFICHPRED.Rows.Count > 0 Then

                                    ' instancia la clase
                                    Dim objFIPRCONS As New cla_FIPRCONS
                                    Dim tblFIPRCONS As New DataTable

                                    tblFIPRCONS = objFIPRCONS.fun_Consultar_FIPRCONS_X_FICHA_PREDIAL(inFIPRNUFI)

                                    If tblFIPRCONS.Rows.Count > 0 Then

                                        ' declara la variable
                                        Dim stFPCOTICO As String = fun_RecuperaTipoDeConstruccion(inFIPRNUFI)

                                        ' identificador residencial
                                        If Trim(stFPCOTICO) = "075" Or _
                                           Trim(stFPCOTICO) = "077" Or _
                                           Trim(stFPCOTICO) = "019" Or _
                                           Trim(stFPCOTICO) = "020" Or _
                                           Trim(stFPCOTICO) = "075A" Or _
                                           Trim(stFPCOTICO) = "075B" Or _
                                           Trim(stFPCOTICO) = "075C" Then

                                            ' lleno la variable
                                            stFIPRTIPO = "R"

                                            ' instancia la clase
                                            Dim obj_TARIRAAV_R As New cla_TARIRAAV
                                            Dim tbl_TARIRAAV_R As New DataTable

                                            tbl_TARIRAAV_R = obj_TARIRAAV_R.fun_Buscar_CODIGO_DEPA_MUNI_CLSE_VIGE_TIPO_ESTR_X_TARIRAAV(stFIPRDEPA, stFIPRMUNI, inFIPRCLSE, inFIPRVIGE, stFIPRTIPO, stFIPRESSO)

                                            ' verifica que existan registros
                                            If tbl_TARIRAAV_R.Rows.Count > 0 And Trim(stFIPRTIPO) = "R" Then

                                                Dim sw1 As Byte = 0
                                                Dim j1 As Integer = 0

                                                While j1 < tbl_TARIRAAV_R.Rows.Count And sw1 = 0

                                                    If tbl_TARIRAAV_R.Rows(j1).Item("TARADEPA") = CStr(Trim(stFIPRDEPA)) And _
                                                       tbl_TARIRAAV_R.Rows(j1).Item("TARAMUNI") = CStr(Trim(stFIPRMUNI)) And _
                                                       tbl_TARIRAAV_R.Rows(j1).Item("TARACLSE") = CInt(inFIPRCLSE) And _
                                                       tbl_TARIRAAV_R.Rows(j1).Item("TARAVIGE") = CInt(inFIPRVIGE) And _
                                                       tbl_TARIRAAV_R.Rows(j1).Item("TARATIPO") = CStr(Trim(stFIPRTIPO)) And _
                                                       tbl_TARIRAAV_R.Rows(j1).Item("TARAESTR") = CStr(Trim(stFIPRESSO)) Then

                                                        Dim loFIPRAVIN_R As Long = CLng(tbl_TARIRAAV_R.Rows(j1).Item("TARAAVIN"))
                                                        Dim loFIPRAVFI_R As Long = CLng(tbl_TARIRAAV_R.Rows(j1).Item("TARAAVFI"))

                                                        If loFIPRAVCA >= loFIPRAVIN_R And loFIPRAVCA <= loFIPRAVFI_R Then
                                                            vl_stAFSITA01 = CType(tbl_TARIRAAV_R.Rows(j1).Item("TARATARI"), Decimal)
                                                            sw1 = 1
                                                            boExisteTarifa = True
                                                        Else
                                                            j1 = j1 + 1
                                                        End If

                                                    Else
                                                        j1 = j1 + 1
                                                    End If

                                                End While

                                            End If

                                            ' identificadores comerciales
                                        ElseIf Trim(stFPCOTICO) = "072" Or _
                                               Trim(stFPCOTICO) = "072A" Or _
                                               Trim(stFPCOTICO) = "072B" Or _
                                               Trim(stFPCOTICO) = "072C" Or _
                                               Trim(stFPCOTICO) = "076" Or _
                                               Trim(stFPCOTICO) = "076A" Or _
                                               Trim(stFPCOTICO) = "076B" Or _
                                               Trim(stFPCOTICO) = "076C" Then

                                            ' lleno la variable
                                            stFIPRTIPO = "C"

                                            ' instancia la clase
                                            Dim obj_TARIRAAV_C As New cla_TARIRAAV
                                            Dim tbl_TARIRAAV_C As New DataTable

                                            tbl_TARIRAAV_C = obj_TARIRAAV_C.fun_Buscar_CODIGO_DEPA_MUNI_CLSE_VIGE_TIPO_X_TARIRAAV(stFIPRDEPA, stFIPRMUNI, inFIPRCLSE, inFIPRVIGE, stFIPRTIPO)

                                            ' verifica que existan registros
                                            If tbl_TARIRAAV_C.Rows.Count > 0 And Trim(stFIPRTIPO) = "C" Then

                                                Dim sw1 As Byte = 0
                                                Dim j1 As Integer = 0

                                                While j1 < tbl_TARIRAAV_C.Rows.Count And sw1 = 0

                                                    If tbl_TARIRAAV_C.Rows(j1).Item("TARADEPA") = CStr(Trim(stFIPRDEPA)) And _
                                                       tbl_TARIRAAV_C.Rows(j1).Item("TARAMUNI") = CStr(Trim(stFIPRMUNI)) And _
                                                       tbl_TARIRAAV_C.Rows(j1).Item("TARACLSE") = CInt(inFIPRCLSE) And _
                                                       tbl_TARIRAAV_C.Rows(j1).Item("TARAVIGE") = CInt(inFIPRVIGE) And _
                                                       tbl_TARIRAAV_C.Rows(j1).Item("TARATIPO") = CStr(Trim(stFIPRTIPO)) Then

                                                        Dim loFIPRAVIN_C As Long = CLng(tbl_TARIRAAV_C.Rows(j1).Item("TARAAVIN"))
                                                        Dim loFIPRAVFI_C As Long = CLng(tbl_TARIRAAV_C.Rows(j1).Item("TARAAVFI"))

                                                        If loFIPRAVCA >= loFIPRAVIN_C And loFIPRAVCA <= loFIPRAVFI_C Then
                                                            vl_stAFSITA01 = CType(tbl_TARIRAAV_C.Rows(j1).Item("TARATARI"), Decimal)
                                                            sw1 = 1
                                                            boExisteTarifa = True
                                                        Else
                                                            j1 = j1 + 1
                                                        End If

                                                    Else
                                                        j1 = j1 + 1
                                                    End If

                                                End While

                                            End If

                                        End If

                                    End If

                                End If

                            End If

                        End If

                        ' liquida el predial segun la destinacion
                        If boExisteTarifa = True Then

                            vl_inAFSINUFI = dt_FICHPRED.Rows(0).Item("FIPRNUFI")

                            vl_boAFSIEXEN = fun_PredioExentoImpuestoPredial()
                            vl_inAFSITIAF = fun_TipoDeAforoImpuestoPredial()

                            vl_loAFSIVALI = (vl_loAFSIVABA * CDec(vl_stAFSITA01) / 1000)
                            vl_loAFSIVAIM = (vl_loAFSIVABA * CDec(vl_stAFSITA01) / 1000)

                            If vl_boAplicarMaximoLiquidacion = True Then
                                vl_boPPLIPOAP = fun_PocentajeMaximoPermitidoDeLiquidacionPredial(0, True)
                            Else
                                vl_boPPLIPOAP = False
                            End If

                            vl_boAFSILEY44 = fun_Ley44de1990()
                            vl_inAFSIMOLI = fun_ModoDeLiquidacionImpuestoPredial()

                            If vl_boPredioExentoPorNit = True Then
                                vl_boAFSILEY44 = False
                                vl_loAFSIVALI = 0
                                vl_loAFSIVAIM = 0
                                vl_inAFSIMOLI = 1
                            End If

                        End If

                    End If

                End If

            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description & dt_FICHPRED.Rows(0).Item("FIPRNUFI"))
        End Try

    End Sub

#End Region

#Region "FUNCIONES"

    Private Function fun_ModoDeLiquidacionImpuestoPredial() As Integer

        Try
            Dim inMODOLIQUI As Integer = 1

            ' verifica el modo de liquidacion
            If vl_boAFSILEY44 = True Then

                ' asigna ley 44
                inMODOLIQUI = 2

            ElseIf vl_boAFSIAUAV = True Then

                ' asigna avaluo por tarifa
                inMODOLIQUI = 1


            ElseIf vl_boPPLIPOAP = True Then

                ' Liquida maximo permitido
                inMODOLIQUI = 4

            Else
                ' asigna ley 56
                inMODOLIQUI = 1

            End If

            Return inMODOLIQUI

        Catch ex As Exception
            Return 0
            MessageBox.Show(Err.Description)
        End Try

    End Function
    Private Function fun_TipoDeAforoImpuestoPredial() As Integer

        Try
            ' aforado
            Dim inTIPOAFOR As Integer = 1

            Return inTIPOAFOR

        Catch ex As Exception
            Return 2
            MessageBox.Show(Err.Description)
        End Try

    End Function
    Private Function fun_PredioExentoImpuestoPredial() As Boolean

        Try
            Dim boPredioExento As Boolean = False
            vl_boPredioExentoPorNit = False

            '==============================
            ' PREDIOS EXENTOS POR CONCEPTO
            '==============================

            Dim obj_PREDEXEN As New cla_PREDEXEN
            Dim tbl_PREDEXEN As New DataTable

            tbl_PREDEXEN = obj_PREDEXEN.fun_Consultar_CAMPOS_PREDEXEN

            If tbl_PREDEXEN.Rows.Count > 0 Then

                Dim sw1 As Byte = 0
                Dim j1 As Integer = 0

                While j1 < tbl_PREDEXEN.Rows.Count And sw1 = 0
                    If Trim(tbl_PREDEXEN.Rows(j1).Item("PREXESTA")) = "ac" Then

                        If Trim(tbl_PREDEXEN.Rows(j1).Item("PREXDEPA")) = Trim(dt_FICHPRED.Rows(0).Item("FIPRDEPA")) And _
                           Trim(tbl_PREDEXEN.Rows(j1).Item("PREXMUNI")) = Trim(dt_FICHPRED.Rows(0).Item("FIPRMUNI")) And _
                           tbl_PREDEXEN.Rows(j1).Item("PREXCLSE") = vl_inAFSICLSE And _
                           tbl_PREDEXEN.Rows(j1).Item("PREXNUFI") = vl_inAFSINUFI And _
                           tbl_PREDEXEN.Rows(j1).Item("PREXTIIM") = vl_inAFSITIIM And _
                           tbl_PREDEXEN.Rows(j1).Item("PREXCONC") = vl_inAFSICONC Then

                            If (vl_inAFSIVIGE >= tbl_PREDEXEN.Rows(j1).Item("PREXVIIN") And vl_inAFSIVIGE <= tbl_PREDEXEN.Rows(j1).Item("PREXVIFI")) Then
                                boPredioExento = True

                                vl_inPREXPOAP = tbl_PREDEXEN.Rows(j1).Item("PREXPOAP")

                                sw1 = 1
                            Else
                                j1 = j1 + 1
                            End If

                        Else
                            j1 = j1 + 1
                        End If
                    Else
                        j1 = j1 + 1
                    End If

                End While

            Else
                boPredioExento = False
            End If

            '=========================
            ' PREDIOS EXENTOS POR NIT
            '=========================

            If boPredioExento = False Then

                Dim obj_PREDEXNI As New cla_PREDEXNI
                Dim tbl_PREDEXNI As New DataTable

                tbl_PREDEXNI = obj_PREDEXNI.fun_Consultar_CAMPOS_PREDEXNI

                If tbl_PREDEXNI.Rows.Count > 0 Then

                    Dim objdatos33 As New cla_FIPRPROP
                    Dim tbl33 As New DataTable

                    tbl33 = objdatos33.fun_Consultar_FIPRPROP_X_FICHA_PREDIAL(vl_inAFSINUFI)

                    If tbl33.Rows.Count = 1 Then

                        Dim k As Integer = 0

                        For k = 0 To tbl33.Rows.Count - 1

                            If Trim(tbl33.Rows(k).Item("FPPRESTA")) = "ac" Then

                                Dim stFIPRNUDO As String = Trim(tbl33.Rows(k).Item("FPPRNUDO"))

                                Dim sw1 As Byte = 0
                                Dim j1 As Integer = 0

                                While j1 < tbl_PREDEXNI.Rows.Count And sw1 = 0
                                    If Trim(tbl_PREDEXNI.Rows(j1).Item("PRENESTA")) = "ac" Then

                                        If Trim(tbl_PREDEXNI.Rows(j1).Item("PRENDEPA")) = Trim(dt_FICHPRED.Rows(0).Item("FIPRDEPA")) And _
                                           Trim(tbl_PREDEXNI.Rows(j1).Item("PRENMUNI")) = Trim(dt_FICHPRED.Rows(0).Item("FIPRMUNI")) And _
                                           tbl_PREDEXNI.Rows(j1).Item("PRENCLSE") = vl_inAFSICLSE And _
                                           Trim(tbl_PREDEXNI.Rows(j1).Item("PRENNUDO")) = Trim(stFIPRNUDO) And _
                                           tbl_PREDEXNI.Rows(j1).Item("PRENTIIM") = vl_inAFSITIIM And _
                                           tbl_PREDEXNI.Rows(j1).Item("PRENCONC") = vl_inAFSICONC Then

                                            vl_boPredioExentoPorNit = True
                                            sw1 = 1
                                        Else
                                            j1 = j1 + 1
                                        End If
                                    Else
                                        j1 = j1 + 1
                                    End If

                                End While

                            End If

                        Next

                    End If
                Else
                    vl_boPredioExentoPorNit = False
                End If

            End If

            boPredioExento = vl_boPredioExentoPorNit

            Return boPredioExento

        Catch ex As Exception
            Return False
        End Try

    End Function
    Private Function fun_Ley44de1990() As Boolean

        Try
            Dim boResultado As Boolean = False

            Dim inVigenciaActual As Integer = vl_inAFSIVIGE
            Dim inVigenciaAnterior As Integer = (vl_inAFSIVIGE - 1)

            Dim objdatos As New cla_HISTLIQU
            Dim dt_VigenciaActual As New DataTable
            Dim dt_VigenciaAnterior As New DataTable

            dt_VigenciaActual = objdatos.fun_Buscar_CODIGO_NUFI_VIGE_X_HISTLIQU(vl_inAFSINUFI, inVigenciaActual)
            dt_VigenciaAnterior = objdatos.fun_Buscar_CODIGO_NUFI_VIGE_X_HISTLIQU(vl_inAFSINUFI, inVigenciaAnterior)

            Dim dt_ValorLiquidadoImpuestoActual As New DataTable
            Dim dt_ValorLiquidadoImpuestoAnterior As New DataTable

            ' verifica la vigencia
            If dt_VigenciaAnterior.Rows.Count = 0 Then
                boResultado = False
            Else
                Dim stDestinoEconomicoFicha As String = ""
                Dim stDestinoEconomicoSujeto As String = ""

                Dim boLoteVigenciaAnterior As Boolean = False
                Dim boLoteVigenciaActual As Boolean = False
                Dim boAreaConstruidaVigenciaActual As Boolean = False

                Dim objdatos1 As New cla_DESTECON
                Dim tblDestino As New DataTable

                tblDestino = objdatos1.fun_Consultar_MANT_DESTECON

                If tblDestino.Rows.Count = 0 Then
                    boResultado = False
                Else

                    ' recorre el destino de la ficha
                    Dim sw1 As Byte = 0
                    Dim j1 As Integer = 0

                    While j1 < tblDestino.Rows.Count And sw1 = 0

                        If CBool(tblDestino.Rows(j1).Item("DEECLOTE")) = True Then

                            stDestinoEconomicoFicha = Trim(tblDestino.Rows(j1).Item("DEECCODI"))
                            stDestinoEconomicoSujeto = Trim(dt_VigenciaAnterior.Rows(0).Item("HILIDEEC"))

                            If Trim(stDestinoEconomicoSujeto) = Trim(stDestinoEconomicoFicha) Then
                                sw1 = 1
                                boLoteVigenciaAnterior = True
                            Else
                                j1 = j1 + 1
                            End If
                        Else
                            j1 = j1 + 1
                        End If

                    End While

                    ' recorre el destino del historico
                    Dim sw2 As Byte = 0
                    Dim j2 As Integer = 0

                    While j2 < tblDestino.Rows.Count And sw2 = 0

                        If CBool(tblDestino.Rows(j2).Item("DEECLOTE")) = True Then

                            stDestinoEconomicoFicha = Trim(tblDestino.Rows(j2).Item("DEECCODI"))
                            stDestinoEconomicoSujeto = Trim(dt_VigenciaActual.Rows(0).Item("HILIDEEC"))

                            If Trim(stDestinoEconomicoSujeto) = Trim(stDestinoEconomicoFicha) Then
                                sw2 = 1
                                boLoteVigenciaActual = True
                            Else
                                j2 = j2 + 1
                            End If
                        Else
                            j2 = j2 + 1
                        End If

                    End While

                    ' verifica si aplica la ley 44
                    If boLoteVigenciaAnterior = True And boLoteVigenciaActual = True Then
                        boResultado = False
                    ElseIf boLoteVigenciaAnterior = False And boLoteVigenciaActual = True Then
                        boResultado = False
                    ElseIf boLoteVigenciaAnterior = True And boLoteVigenciaActual = False Then
                        boResultado = True
                    ElseIf boLoteVigenciaAnterior = False And boLoteVigenciaActual = False Then
                        boResultado = True
                    End If

                End If

            End If

            ' actualiza el valor liquidado y de impuesto
            If boResultado = True And vl_boPPLIPOAP = False Then

                Dim loValorLiquidadoVigenciaAnterior As Long = 0

                Dim objAforo As New cla_AFORSUIM
                Dim tblAforo As New DataTable

                tblAforo = objAforo.fun_Buscar_CODIGO_NUFI_VIGE_X_AFORSUIM(vl_inAFSINUFI, inVigenciaAnterior)

                If tblAforo.Rows.Count > 0 AndAlso CLng(tblAforo.Rows(0).Item("AFSIVALI")) <> 0 Then

                    loValorLiquidadoVigenciaAnterior = CLng(tblAforo.Rows(0).Item("AFSIVALI"))

                    If vl_loAFSIVALI > (loValorLiquidadoVigenciaAnterior * 2) Then
                        vl_loAFSIVALI = (loValorLiquidadoVigenciaAnterior * 2)

                        pro_MarcarPredioConLey44de1990(vl_inAFSINUFI, vl_inAFSIVIGE, True)
                        vl_boAFSILEY44 = True
                    Else
                        pro_MarcarPredioConLey44de1990(vl_inAFSINUFI, vl_inAFSIVIGE, False)
                        vl_boAFSILEY44 = False
                    End If

                Else
                    pro_MarcarPredioConLey44de1990(vl_inAFSINUFI, vl_inAFSIVIGE, False)
                    vl_boAFSILEY44 = False

                End If
            Else
                pro_MarcarPredioConLey44de1990(vl_inAFSINUFI, vl_inAFSIVIGE, False)
                vl_boAFSILEY44 = False

            End If

            ' aplica el porcentaje de exoneracion al predio con ley 44
            If vl_boAFSILEY44 = True And vl_boAFSIEXEN = True And vl_boPredioExentoPorNit = False Then

                If vl_inPREXPOAP <> 0 Then

                    Dim loDescuentoPredial As Long = ((vl_loAFSIVALI * vl_inPREXPOAP) / 100)

                    vl_loAFSIVALI = (vl_loAFSIVALI - loDescuentoPredial)

                End If

            End If

            Return vl_boAFSILEY44

        Catch ex As Exception
            Return False
            MessageBox.Show(Err.Description)
        End Try

    End Function
    Private Function fun_PocentajeMaximoPermitidoDeLiquidacionPredial(ByVal inPORCPERM As Integer, ByVal boBUSQUEDA As Boolean) As Boolean

        Try
            Dim boPorcentajeMaximoPermitido As Boolean = False

            Dim inVigenciaActual As Integer = vl_inAFSIVIGE
            Dim inVigenciaAnterior As Integer = (vl_inAFSIVIGE - 1)

            Dim objdatos As New cla_HISTLIQU

            Dim dt_VigenciaActual As New DataTable
            Dim dt_VigenciaAnterior As New DataTable

            dt_VigenciaActual = objdatos.fun_Buscar_CODIGO_NUFI_VIGE_X_HISTLIQU(vl_inAFSINUFI, inVigenciaActual)
            dt_VigenciaAnterior = objdatos.fun_Buscar_CODIGO_NUFI_VIGE_X_HISTLIQU(vl_inAFSINUFI, inVigenciaAnterior)

            Dim dt_ValorLiquidadoImpuestoActual As New DataTable
            Dim dt_ValorLiquidadoImpuestoAnterior As New DataTable

            ' declara la variable
            Dim boAplicaDescuentoPermitido As Boolean = False

            ' predio que son lotes
            If (dt_VigenciaActual.Rows(0).Item("HILIDEEC") = 12 Or dt_VigenciaActual.Rows(0).Item("HILIDEEC") = 13) Then
                boAplicaDescuentoPermitido = False
                vl_boPPLIPOAP = False
            Else
                ' declaro la variable
                Dim loValorLiquidadoVigenciaAnterior As Long = 0
                Dim loValorLiquidadoVigenciaActual As Long = 0

                ' declaro la variable
                Dim stTarifaVigenciaAnterior As String = ""
                Dim stTarifaVigenciaActual As String = ""

                ' instancia la clase
                Dim objAforoAnterior As New cla_AFORSUIM
                Dim tblAforoAnterior As New DataTable

                ' instancia la clase
                Dim objAforoActual As New cla_AFORSUIM
                Dim tblAforoActual As New DataTable

                ' llena las tablas
                tblAforoAnterior = objAforoAnterior.fun_Buscar_CODIGO_NUFI_VIGE_X_AFORSUIM(vl_inAFSINUFI, inVigenciaAnterior)
                tblAforoActual = objAforoActual.fun_Buscar_CODIGO_NUFI_VIGE_X_AFORSUIM(vl_inAFSINUFI, inVigenciaActual)

                ' almacena el aforo de la vigencia anterior
                loValorLiquidadoVigenciaAnterior = CLng(tblAforoAnterior.Rows(0).Item("AFSIVALI"))

                Dim obj_POPELIQU As New cla_POPELIQU
                Dim tbl_POPELIQU As New DataTable

                tbl_POPELIQU = obj_POPELIQU.fun_Consultar_CAMPOS_POPELIQU

                If tbl_POPELIQU.Rows.Count > 0 Then

                    ' limpia la variable
                    vl_dePPLIPOAP = 0

                    Dim sw1 As Byte = 0
                    Dim j1 As Integer = 0

                    While j1 < tbl_POPELIQU.Rows.Count And sw1 = 0
                        If Trim(tbl_POPELIQU.Rows(j1).Item("PPLIESTA")) = "ac" Then

                            If Trim(tbl_POPELIQU.Rows(j1).Item("PPLIDEPA")) = Trim(dt_FICHPRED.Rows(0).Item("FIPRDEPA")) And _
                               Trim(tbl_POPELIQU.Rows(j1).Item("PPLIMUNI")) = Trim(dt_FICHPRED.Rows(0).Item("FIPRMUNI")) And _
                               tbl_POPELIQU.Rows(j1).Item("PPLICLSE") = vl_inAFSICLSE And _
                               tbl_POPELIQU.Rows(j1).Item("PPLITIIM") = vl_inAFSITIIM And _
                               tbl_POPELIQU.Rows(j1).Item("PPLICONC") = vl_inAFSICONC Then

                                If (vl_inAFSIVIGE >= tbl_POPELIQU.Rows(j1).Item("PPLIVIIN") And vl_inAFSIVIGE <= tbl_POPELIQU.Rows(j1).Item("PPLIVIFI")) Then

                                    If boBUSQUEDA = False Then
                                        vl_dePPLIPOAP = inPORCPERM

                                    ElseIf boBUSQUEDA = True Then
                                        vl_dePPLIPOAP = tbl_POPELIQU.Rows(j1).Item("PPLIPOAP")
                                    End If

                                    sw1 = 1
                                Else
                                    j1 = j1 + 1
                                End If

                            Else
                                j1 = j1 + 1
                            End If
                        Else
                            j1 = j1 + 1
                        End If

                    End While

                Else
                    boPorcentajeMaximoPermitido = False
                End If


                ' limitante predios rurales
                If dt_FICHPRED.Rows.Count > 0 Then
                    If dt_FICHPRED.Rows(0).Item("FIPRCLSE") = 2 Then

                        If dt_HISTLIQU.Rows.Count > 0 Then

                            ' declara la variable
                            Dim boParcela As Boolean = False

                            ' si cumple por destinación económica
                            If Trim(dt_HISTLIQU.Rows(0).Item("HILIDEEC")) = "4" Or _
                                Trim(dt_HISTLIQU.Rows(0).Item("HILIDEEC")) = "24" Or _
                                Trim(dt_HISTLIQU.Rows(0).Item("HILIDEEC")) = "25" Then

                                ' si el predios es de caracteristica parcelacion
                            ElseIf dt_FICHPRED.Rows(0).Item("FIPRCAPR") = 3 Then
                                boParcela = True

                                ' asigna la variable
                                If boParcela = True Then
                                    vl_dePPLIPOAP = 25
                                End If

                            Else
                                ' si contiene zonas económicas de parcelación
                                Dim inFIPRNUFI As Integer = CInt(dt_FICHPRED.Rows(0).Item("FIPRNUFI").ToString)

                                ' instancia la clase
                                Dim obFIPRZOEC As New cla_FIPRZOEC
                                Dim dtFIPRZOEC As New DataTable

                                dtFIPRZOEC = obFIPRZOEC.fun_Consultar_FIPRZOEC_X_FICHA_PREDIAL(inFIPRNUFI)

                                If dtFIPRZOEC.Rows.Count > 0 Then

                                    ' declara la variable
                                    Dim i As Integer = 0

                                    For i = 0 To dtFIPRZOEC.Rows.Count - 1

                                        If Trim(dtFIPRZOEC.Rows(i).Item("FPZEZOEC").ToString) = "301" Or _
                                           Trim(dtFIPRZOEC.Rows(i).Item("FPZEZOEC").ToString) = "302" Or _
                                           Trim(dtFIPRZOEC.Rows(i).Item("FPZEZOEC").ToString) = "303" Or _
                                           Trim(dtFIPRZOEC.Rows(i).Item("FPZEZOEC").ToString) = "304" Or _
                                           Trim(dtFIPRZOEC.Rows(i).Item("FPZEZOEC").ToString) = "306" Then
                                            boParcela = True
                                        End If

                                    Next

                                    ' asigna la variable
                                    If boParcela = True Then
                                        vl_dePPLIPOAP = 25
                                    End If

                                End If
                            End If
                        End If
                    End If
                End If

                ' limitante predios urbanos
                If dt_FICHPRED.Rows.Count > 0 Then
                    If dt_FICHPRED.Rows(0).Item("FIPRCLSE") = 1 Then

                        Dim inFIPRNUFI As Integer = CInt(dt_FICHPRED.Rows(0).Item("FIPRNUFI").ToString)

                        ' instancia la clase
                        Dim obFIPRCONS As New cla_FIPRCONS
                        Dim dtFIPRCONS As New DataTable

                        dtFIPRCONS = obFIPRCONS.fun_Consultar_FIPRCONS_X_FICHA_PREDIAL(inFIPRNUFI)

                        If dtFIPRCONS.Rows.Count = 1 Then

                            Dim boGaraje As Boolean = False
                            Dim i As Integer = 0

                            For i = 0 To dtFIPRCONS.Rows.Count - 1

                                If Trim(dtFIPRCONS.Rows(i).Item("FPCOTICO").ToString) = "050" Or Trim(dtFIPRCONS.Rows(i).Item("FPCOTICO").ToString) = "075" Then
                                    boGaraje = True
                                End If

                            Next

                            If boGaraje = True Then
                                vl_dePPLIPOAP = 25
                            End If

                        End If

                    End If
                End If

                ' declara la variable
                Dim loValorAnteriorIncrementado As Long = 0

                loValorAnteriorIncrementado = loValorLiquidadoVigenciaAnterior + (loValorLiquidadoVigenciaAnterior * vl_dePPLIPOAP) / 100

                ' aplica porcentaje maximo de liquidacion
                If vl_loAFSIVALI > (loValorAnteriorIncrementado) And loValorAnteriorIncrementado <> 0 Then
                    vl_loAFSIVALI = (loValorAnteriorIncrementado)

                    pro_MarcarPredioConLey44de1990(vl_inAFSINUFI, vl_inAFSIVIGE, False)
                    vl_boAFSILEY44 = False
                    vl_boPPLIPOAP = True

                    ' asigna el valor del impuesto como definitivo
                ElseIf loValorAnteriorIncrementado = 0 And vl_loAFSIVALI > 0 Then
                    vl_loAFSIVALI = vl_loAFSIVAIM

                    pro_MarcarPredioConLey44de1990(vl_inAFSINUFI, vl_inAFSIVIGE, False)
                    vl_boAFSILEY44 = False
                    vl_boPPLIPOAP = True
                Else
                    pro_MarcarPredioConLey44de1990(vl_inAFSINUFI, vl_inAFSIVIGE, False)
                    vl_boAFSILEY44 = False
                    vl_boPPLIPOAP = False
                End If

            End If

            Return vl_boPPLIPOAP

        Catch ex As Exception
            Return False
        End Try

    End Function
    Private Function fun_RecuperaTipoDeConstruccion(ByVal inFIPRNUFI As Integer) As String

        Try
            Dim stTipoDeConstruccion As String = ""
            Dim bySW As Byte = 0

            Dim objdatos33 As New cla_FIPRCONS
            Dim tbl33 As New DataTable

            tbl33 = objdatos33.fun_Consultar_FIPRCONS_X_FICHA_PREDIAL(inFIPRNUFI)

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
                    stTipoDeConstruccion = ""
                Else
                    stTipoDeConstruccion = stIdentificador
                End If

            Else
                stTipoDeConstruccion = ""
            End If

            Return stTipoDeConstruccion

        Catch ex As Exception
            Return ""
            MessageBox.Show(Err.Description & "fun_RecuperaTipoDeConstruccion")
        End Try

    End Function

#End Region

End Module
