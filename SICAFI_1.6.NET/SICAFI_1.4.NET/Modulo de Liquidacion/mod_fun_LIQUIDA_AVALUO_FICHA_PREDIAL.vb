Imports REGLAS_DEL_NEGOCIO
Imports System
Imports System.IO
Imports System.Data
Imports System.Data.Sqlclient
Imports System.Configuration
Imports System.Text
Imports System.Math

Module mod_fun_LIQUIDA_AVALUO_FICHA_PREDIAL

    '====================================
    '*** LIQUIDA AVALUO FICHA PREDIAL ***
    '====================================

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

    Private vl_inFIPRNUFI As Integer
    Private vl_stFIPRDATR As String
    Private vl_stFIPRDAVI As String
    Private vl_stFIPRDAND As String
    Private vl_stFIPROBSE As String

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

#Region "Componentes Avaluo"

    Private vl_loFPAVATPR As Long = 0
    Private vl_loFPAVATCO As Long = 0
    Private vl_stFPAVACPR As String = "0.00"
    Private vl_stFPAVACCO As String = "0.00"
    Private vl_loFPAVVATP As Long = 0
    Private vl_loFPAVVATC As Long = 0
    Private vl_loFPAVVACP As Long = 0
    Private vl_loFPAVVACC As Long = 0
    Private vl_loFPAVAVAL As Long = 0

#End Region

#End Region

#Region "PROCEDIMIENTOS"

#Region "Cargar Tablas Ficha Predial"

    Private Sub pro_CargarTablasFichaPredial()

        Dim objdatos As New cla_FIPRAVAL
        Dim ds As New DataSet

        ds = objdatos.fun_Consultar_TABLAS_FICHA_PREDIAL(vl_inFIPRNUFI)

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
        'dt_FIPRDEEC = ds.Tables(1)
        ' Tabla 2
        'dt_FIPRPROP = ds.Tables(2)
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

#End Region

#Region "Liquida Avaluo Ficha Predial"

    Public Sub pro_LIQUIDA_AVALUO_FICHA_PREDIAL(ByVal o_inFIPRNUFI As Integer, _
                                                ByVal o_stTIPORESO As String, _
                                                ByVal o_stVIGENCIA As String, _
                                                ByVal o_stNUMEDOCU As String, _
                                                ByVal o_stOBSERVAC As String)

        Try
            ' declaro variables
            vl_inFIPRNUFI = o_inFIPRNUFI
            vl_stFIPRDATR = Trim(o_stTIPORESO)
            vl_stFIPRDAVI = Trim(o_stVIGENCIA)
            vl_stFIPRDAND = Trim(o_stNUMEDOCU)
            vl_stFIPROBSE = Trim(o_stOBSERVAC)

            ' Elimina el avaluo catastral
            Dim objdatos As New cla_FIPRAVAL

            objdatos.fun_Eliminar_FIPRAVAL(Trim(o_inFIPRNUFI))

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

                        pro_LiquidaAvaluoPorCaracteritica()
                        pro_GuardarAvaluoCatastral()
                    End If

                End If
            End If


        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "Liquida Avaluo ficha predial")
        End Try

    End Sub

#End Region

#Region "Liquida Avaluo por Caracteristica"

    Private Sub pro_LiquidaAvaluoPorCaracteritica()

        Try
            vl_loFPAVATPR = fun_ConsultaAreaTerrenoPrivada()
            vl_loFPAVATCO = fun_ConsultarAreaTerrenoComun()
            vl_stFPAVACPR = fun_ConsultarAreaConstruccionPrivada()
            vl_stFPAVACCO = fun_ConsultarAreaConstruccionComun()

            vl_loFPAVVATP = fun_ConsultarValorAreaTerrenoPrivada()
            vl_loFPAVVATC = fun_ConsultarValorAreaTerrenoComun()
            vl_loFPAVVACP = fun_ConsultarValorAreaConstruccionPrivada()
            vl_loFPAVVACC = fun_ConsultarValorAreaConstruccionComun()

            vl_loFPAVAVAL = fun_ConsultarAvaluoTotal()

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub

#End Region

#Region "Grabar Avaluo Catastral"

    Private Sub pro_GuardarAvaluoCatastral()

        Dim objdatos1 As New cla_FIPRAVAL

        Dim stESTADO As String = "ac"

        objdatos1.fun_Insertar_FIPRAVAL(vl_inFIPRNUFI, _
                                        vl_loFPAVATPR, _
                                        vl_loFPAVATCO, _
                                        vl_stFPAVACPR, _
                                        vl_stFPAVACCO, _
                                        vl_loFPAVVATP, _
                                        vl_loFPAVVATC, _
                                        vl_loFPAVVACP, _
                                        vl_loFPAVVACC, _
                                        vl_loFPAVAVAL, _
                                        vl_stFIPROBSE, _
                                        vl_stFIPRDATR, _
                                        vl_stFIPRDAVI, _
                                        vl_stFIPRDAND, _
                                        stESTADO)
    End Sub

#End Region

#End Region

#Region "FUNCIONES"

    Private Function fun_ConsultarPorcentajeDeDescuentoAreaDeTerreno(ByVal loFIPRARTE As Long) As Integer

        Try
            ' Descuentos sector urbano
            If dt_FICHPRED.Rows(0).Item("FIPRCLSE") = 1 Then

                If loFIPRARTE >= 0 And loFIPRARTE <= 300 Then
                    Return 100
                End If

                If loFIPRARTE >= 301 And loFIPRARTE <= 350 Then
                    Return 95
                End If

                If loFIPRARTE >= 351 And loFIPRARTE <= 400 Then
                    Return 90
                End If

                If loFIPRARTE >= 401 And loFIPRARTE <= 450 Then
                    Return 85
                End If

                If loFIPRARTE >= 451 And loFIPRARTE <= 500 Then
                    Return 80
                End If

                If loFIPRARTE >= 501 And loFIPRARTE <= 600 Then
                    Return 75
                End If

                If loFIPRARTE >= 601 And loFIPRARTE <= 700 Then
                    Return 70
                End If

                If loFIPRARTE >= 701 And loFIPRARTE <= 900 Then
                    Return 65
                End If

                If loFIPRARTE >= 901 And loFIPRARTE <= 1200 Then
                    Return 60
                End If

                If loFIPRARTE >= 1201 And loFIPRARTE <= 1600 Then
                    Return 55
                End If

                If loFIPRARTE >= 1601 Then
                    Return 50
                End If

            End If

            ' Descuento sector rural
            If dt_FICHPRED.Rows(0).Item("FIPRCLSE") = 2 Then

                If loFIPRARTE >= 0 And loFIPRARTE <= 30000 Then
                    Return 100
                End If

                If loFIPRARTE >= 30001 And loFIPRARTE <= 100000 Then
                    Return 90
                End If

                If loFIPRARTE >= 100001 And loFIPRARTE <= 200000 Then
                    Return 80
                End If

                If loFIPRARTE >= 200001 And loFIPRARTE <= 500000 Then
                    Return 70
                End If

                If loFIPRARTE >= 500001 Then
                    Return 60
                End If

            End If

        Catch ex As Exception
            Return 0
            MessageBox.Show(Err.Description)
        End Try

    End Function

    Private Function fun_ConsultaAreaTerrenoPrivada() As Integer

        Try
            If dt_FICHPRED.Rows(0).Item("FIPRCAPR") = 1 Or _
               dt_FICHPRED.Rows(0).Item("FIPRCAPR") = 2 Or _
               dt_FICHPRED.Rows(0).Item("FIPRCAPR") = 3 Or _
               dt_FICHPRED.Rows(0).Item("FIPRCAPR") = 4 Or _
               dt_FICHPRED.Rows(0).Item("FIPRCAPR") = 5 Or _
               dt_FICHPRED.Rows(0).Item("FIPRCAPR") = 6 Or _
               dt_FICHPRED.Rows(0).Item("FIPRCAPR") = 7 Then

                Return dt_FICHPRED.Rows(0).Item("FIPRARTE")
            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try


    End Function
    Private Function fun_ConsultarAreaTerrenoComun() As Integer

        Try
            ' ========================================
            ' *** CARACTERISTICA DE PREDIO "1-6-7" ***
            ' ========================================
            If dt_FICHPRED.Rows(0).Item("FIPRCAPR") = 1 Or _
               dt_FICHPRED.Rows(0).Item("FIPRCAPR") = 6 Or _
               dt_FICHPRED.Rows(0).Item("FIPRCAPR") = 7 Then

                Return 0
            End If

            ' ======================================
            ' *** CARACTERISTICA DE PREDIO "2-3" ***
            ' ======================================
            If dt_FICHPRED.Rows(0).Item("FIPRCAPR") = 2 Or _
               dt_FICHPRED.Rows(0).Item("FIPRCAPR") = 3 Then

                ' declaro variables
                Dim inAreaTerrenoComun As Integer = 0
                Dim deFIPRCOED As Decimal = CType(dt_FICHPRED.Rows(0).Item("FIPRCOED"), Decimal)
                Dim inFIPRTIFI As Integer = 2
                Dim inFIPRACLO As Integer = 0
                Dim stFIPRUNPR As String = "00000"

                ' instancia la clase
                Dim objdatos As New cla_FICHRESU
                Dim tbl As New DataTable

                tbl = objdatos.fun_buscar_CEDULA_CATASTRAL_FICHRESU(Trim(dt_FICHPRED.Rows(0).Item("FIPRMUNI")), Trim(dt_FICHPRED.Rows(0).Item("FIPRCORR")), Trim(dt_FICHPRED.Rows(0).Item("FIPRBARR")), Trim(dt_FICHPRED.Rows(0).Item("FIPRMANZ")), Trim(dt_FICHPRED.Rows(0).Item("FIPRPRED")), Trim(dt_FICHPRED.Rows(0).Item("FIPREDIF")), Trim(stFIPRUNPR), Trim(dt_FICHPRED.Rows(0).Item("FIPRCLSE")), inFIPRTIFI)

                ' declara area comun 
                If tbl.Rows.Count > 0 Then
                    inFIPRACLO = CType(tbl.Rows(0).Item("FIPRACLO"), Integer)
                Else
                    inFIPRACLO = 0
                End If

                ' calculo area comun 
                inAreaTerrenoComun = (inFIPRACLO * deFIPRCOED) / 100

                ' retorna area comun 
                Return inAreaTerrenoComun

            End If

            ' ===================================
            ' *** CARACTERITICA DE PREDIO "4" ***
            ' ===================================
            If dt_FICHPRED.Rows(0).Item("FIPRCAPR") = 4 Then

                ' declaro variables
                Dim inAreaTerrenoComun As Integer = 0
                Dim inAreaTerrenoComunFR1 As Integer = 0
                Dim inAreaTerrenoComunFR2 As Integer = 0
                Dim deFIPRCOED As Decimal = CType(dt_FICHPRED.Rows(0).Item("FIPRCOED"), Decimal)
                Dim deFIPRCOPR As Decimal = CType(dt_FICHPRED.Rows(0).Item("FIPRCOPR"), Decimal)
                Dim inFIPRTIFI_1 As Integer = 1
                Dim inFIPRTIFI_2 As Integer = 2
                Dim inFIPRACLO_1 As Integer = 0
                Dim inFIPRACLO_2 As Integer = 0
                Dim stFIPREDIF As String = "000"
                Dim stFIPRUNPR As String = "00000"

                '============================================
                ' *** CONSULTA AREA COMUN FICHA RESUMEN 1 ***
                '============================================

                ' instancia la clase
                Dim objdatos As New cla_FICHRESU
                Dim tbl As New DataTable

                ' consulta area comun ficha resumen 1
                tbl = objdatos.fun_buscar_CEDULA_CATASTRAL_FICHRESU(Trim(dt_FICHPRED.Rows(0).Item("FIPRMUNI")), Trim(dt_FICHPRED.Rows(0).Item("FIPRCORR")), Trim(dt_FICHPRED.Rows(0).Item("FIPRBARR")), Trim(dt_FICHPRED.Rows(0).Item("FIPRMANZ")), Trim(dt_FICHPRED.Rows(0).Item("FIPRPRED")), Trim(stFIPREDIF), Trim(stFIPRUNPR), Trim(dt_FICHPRED.Rows(0).Item("FIPRCLSE")), inFIPRTIFI_1)

                ' declara area comun 
                If tbl.Rows.Count > 0 Then
                    inFIPRACLO_1 = CType(tbl.Rows(0).Item("FIPRACLO"), Integer)
                Else
                    inFIPRACLO_1 = 0
                End If

                ' calculo area comun 
                inAreaTerrenoComunFR1 = (inFIPRACLO_1 * deFIPRCOPR) / 100

                '============================================
                ' *** CONSULTA AREA COMUN FICHA RESUMEN 2 ***
                '============================================

                ' instancia la clase
                Dim objdatos1 As New cla_FICHRESU
                Dim tbl1 As New DataTable

                ' consulta area comun ficha resumen 1
                tbl1 = objdatos1.fun_buscar_CEDULA_CATASTRAL_FICHRESU(Trim(dt_FICHPRED.Rows(0).Item("FIPRMUNI")), Trim(dt_FICHPRED.Rows(0).Item("FIPRCORR")), Trim(dt_FICHPRED.Rows(0).Item("FIPRBARR")), Trim(dt_FICHPRED.Rows(0).Item("FIPRMANZ")), Trim(dt_FICHPRED.Rows(0).Item("FIPRPRED")), Trim(dt_FICHPRED.Rows(0).Item("FIPREDIF")), Trim(stFIPRUNPR), Trim(dt_FICHPRED.Rows(0).Item("FIPRCLSE")), inFIPRTIFI_2)

                ' declara area comun 
                If tbl1.Rows.Count > 0 Then
                    inFIPRACLO_2 = CType(tbl1.Rows(0).Item("FIPRACLO"), Integer)
                Else
                    inFIPRACLO_2 = 0
                End If

                ' calculo area comun 
                inAreaTerrenoComunFR2 = (inFIPRACLO_2 * deFIPRCOED) / 100

                ' suma area comun FR1 y FR2
                inAreaTerrenoComun = inAreaTerrenoComunFR1 + inAreaTerrenoComunFR2

                ' retorna area comun 
                Return inAreaTerrenoComun

            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Function
    Private Function fun_ConsultarAreaConstruccionPrivada() As String

        Try
            ' declara la variable
            Dim deAreaConstruccion As Decimal = 0.0

            If dt_FICHPRED.Rows(0).Item("FIPRCAPR") = 1 Or _
             dt_FICHPRED.Rows(0).Item("FIPRCAPR") = 2 Or _
             dt_FICHPRED.Rows(0).Item("FIPRCAPR") = 3 Or _
             dt_FICHPRED.Rows(0).Item("FIPRCAPR") = 4 Or _
             dt_FICHPRED.Rows(0).Item("FIPRCAPR") = 5 Or _
             dt_FICHPRED.Rows(0).Item("FIPRCAPR") = 6 Or _
             dt_FICHPRED.Rows(0).Item("FIPRCAPR") = 7 Then

                If dt_FIPRCONS.Rows.Count > 0 Then

                    Dim i As Integer = 0

                    For i = 0 To dt_FIPRCONS.Rows.Count - 1

                        If Trim(dt_FIPRCONS.Rows(i).Item("FPCOESTA")) = "ac" Then
                            If dt_FIPRCONS.Rows(i).Item("FPCOCLCO") = 1 Or dt_FIPRCONS.Rows(i).Item("FPCOCLCO") = 2 Then

                                deAreaConstruccion += CType(dt_FIPRCONS.Rows(i).Item("FPCOARCO"), Decimal)

                            End If
                        End If

                    Next

                End If

            End If

            Return fun_Formato_Decimal_2_Decimales(deAreaConstruccion)

        Catch ex As Exception
            Return "0.00"
            MessageBox.Show(Err.Description)
        End Try

    End Function
    Private Function fun_ConsultarAreaConstruccionComun() As String

        Try
            ' declaro la variable
            Dim deAreaConstruccionComunTotal As Decimal = 0.0

            ' ========================================
            ' *** CARACTERISTICA DE PREDIO "1-6-7" ***
            ' ========================================
            If dt_FICHPRED.Rows(0).Item("FIPRCAPR") = 1 Or _
               dt_FICHPRED.Rows(0).Item("FIPRCAPR") = 6 Or _
               dt_FICHPRED.Rows(0).Item("FIPRCAPR") = 7 Then

                ' carga la variable local
                deAreaConstruccionComunTotal = fun_Formato_Decimal_2_Decimales("0.00")

            End If

            ' ======================================
            ' *** CARACTERISTICA DE PREDIO "2-3" ***
            ' ======================================
            If dt_FICHPRED.Rows(0).Item("FIPRCAPR") = 2 Or _
               dt_FICHPRED.Rows(0).Item("FIPRCAPR") = 3 Then

                ' declaro variables
                Dim deAreaConstruccionComun As Decimal = 0.0
                Dim deFIPRCOED As Decimal = CType(dt_FICHPRED.Rows(0).Item("FIPRCOED"), Decimal)
                Dim inFIPRTIFI As Integer = 2
                Dim stFIPRUNPR As String = "00000"

                ' instancia la clase
                Dim objdatos As New cla_FICHRESU
                Dim tbl As New DataTable

                tbl = objdatos.fun_buscar_CEDULA_CATASTRAL_FICHRESU(Trim(dt_FICHPRED.Rows(0).Item("FIPRMUNI")), Trim(dt_FICHPRED.Rows(0).Item("FIPRCORR")), Trim(dt_FICHPRED.Rows(0).Item("FIPRBARR")), Trim(dt_FICHPRED.Rows(0).Item("FIPRMANZ")), Trim(dt_FICHPRED.Rows(0).Item("FIPRPRED")), Trim(dt_FICHPRED.Rows(0).Item("FIPREDIF")), Trim(stFIPRUNPR), Trim(dt_FICHPRED.Rows(0).Item("FIPRCLSE")), inFIPRTIFI)

                ' verifica si existen registros 
                If tbl.Rows.Count > 0 Then

                    ' instancia la clase
                    Dim objdatos1 As New cla_FIPRCONS
                    Dim tbl1 As New DataTable

                    tbl1 = objdatos1.fun_Consultar_FIPRCONS_X_FICHA_PREDIAL(tbl.Rows(0).Item("FIPRNUFI"))

                    ' verifica si existen construcciones
                    If tbl1.Rows.Count > 0 Then

                        Dim i As Integer = 0

                        For i = 0 To tbl1.Rows.Count - 1

                            If Trim(tbl1.Rows(i).Item("FPCOESTA")) = "ac" Then
                                If tbl1.Rows(i).Item("FPCOCLCO") = 1 Or tbl1.Rows(i).Item("FPCOCLCO") = 2 Then

                                    deAreaConstruccionComun += CType(tbl1.Rows(i).Item("FPCOARCO"), Decimal)

                                End If
                            End If

                        Next

                        ' calculo area comun 
                        deAreaConstruccionComun = (deAreaConstruccionComun * deFIPRCOED) / 100

                    Else
                        deAreaConstruccionComun = 0.0
                    End If
                Else
                    deAreaConstruccionComun = 0.0
                End If

                ' carga la variable local
                deAreaConstruccionComunTotal = fun_Formato_Decimal_2_Decimales(deAreaConstruccionComun)

            End If

            ' ===================================
            ' *** CARACTERITICA DE PREDIO "4" ***
            ' ===================================
            If dt_FICHPRED.Rows(0).Item("FIPRCAPR") = 4 Then

                ' declaro variables
                Dim deAreaConstruccionComun As Decimal = 0.0
                Dim deAreaConstruccionComunFR1 As Decimal = 0.0
                Dim deAreaConstruccionComunFR2 As Decimal = 0.0
                Dim deFIPRCOED As Decimal = CType(dt_FICHPRED.Rows(0).Item("FIPRCOED"), Decimal)
                Dim deFIPRCOPR As Decimal = CType(dt_FICHPRED.Rows(0).Item("FIPRCOPR"), Decimal)
                Dim inFIPRTIFI_1 As Integer = 1
                Dim inFIPRTIFI_2 As Integer = 2
                Dim deFPPRACCO_1 As Decimal = 0.0
                Dim deFIPRACCO_2 As Decimal = 0.0
                Dim stFIPREDIF As String = "000"
                Dim stFIPRUNPR As String = "00000"

                '============================================
                ' *** CONSULTA AREA COMUN FICHA RESUMEN 1 ***
                '============================================

                ' instancia la clase
                Dim objdatos As New cla_FICHRESU
                Dim tbl As New DataTable

                ' consulta area comun ficha resumen 1
                tbl = objdatos.fun_buscar_CEDULA_CATASTRAL_FICHRESU(Trim(dt_FICHPRED.Rows(0).Item("FIPRMUNI")), Trim(dt_FICHPRED.Rows(0).Item("FIPRCORR")), Trim(dt_FICHPRED.Rows(0).Item("FIPRBARR")), Trim(dt_FICHPRED.Rows(0).Item("FIPRMANZ")), Trim(dt_FICHPRED.Rows(0).Item("FIPRPRED")), Trim(stFIPREDIF), Trim(stFIPRUNPR), Trim(dt_FICHPRED.Rows(0).Item("FIPRCLSE")), inFIPRTIFI_1)

                ' verifica si existen registros 
                If tbl.Rows.Count > 0 Then

                    ' instancia la clase
                    Dim objdatos1 As New cla_FIPRCONS
                    Dim tbl1 As New DataTable

                    tbl1 = objdatos1.fun_Consultar_FIPRCONS_X_FICHA_PREDIAL(tbl.Rows(0).Item("FIPRNUFI"))

                    ' verifica si existen construcciones
                    If tbl1.Rows.Count > 0 Then

                        Dim i As Integer = 0

                        For i = 0 To tbl1.Rows.Count - 1

                            If Trim(tbl1.Rows(i).Item("FPCOESTA")) = "ac" Then
                                If tbl1.Rows(i).Item("FPCOCLCO") = 1 Or tbl1.Rows(i).Item("FPCOCLCO") = 2 Then

                                    deAreaConstruccionComunFR1 += CType(tbl1.Rows(i).Item("FPCOARCO"), Decimal)

                                End If
                            End If

                        Next

                        ' calculo area comun 
                        deAreaConstruccionComunFR1 = (deAreaConstruccionComunFR1 * deFIPRCOPR) / 100

                    Else
                        deAreaConstruccionComunFR1 = 0.0
                    End If
                Else
                    deAreaConstruccionComunFR1 = 0.0
                End If

                '============================================
                ' *** CONSULTA AREA COMUN FICHA RESUMEN 2 ***
                '============================================

                ' instancia la clase
                Dim objdatos3 As New cla_FICHRESU
                Dim tbl3 As New DataTable

                ' consulta area comun ficha resumen 2
                tbl3 = objdatos3.fun_buscar_CEDULA_CATASTRAL_FICHRESU(Trim(dt_FICHPRED.Rows(0).Item("FIPRMUNI")), Trim(dt_FICHPRED.Rows(0).Item("FIPRCORR")), Trim(dt_FICHPRED.Rows(0).Item("FIPRBARR")), Trim(dt_FICHPRED.Rows(0).Item("FIPRMANZ")), Trim(dt_FICHPRED.Rows(0).Item("FIPRPRED")), Trim(dt_FICHPRED.Rows(0).Item("FIPREDIF")), Trim(stFIPRUNPR), Trim(dt_FICHPRED.Rows(0).Item("FIPRCLSE")), inFIPRTIFI_2)

                ' verifica si existen registros 
                If tbl3.Rows.Count > 0 Then

                    ' instancia la clase
                    Dim objdatos1 As New cla_FIPRCONS
                    Dim tbl1 As New DataTable

                    tbl1 = objdatos1.fun_Consultar_FIPRCONS_X_FICHA_PREDIAL(tbl3.Rows(0).Item("FIPRNUFI"))

                    ' verifica si existen construcciones
                    If tbl1.Rows.Count > 0 Then

                        Dim i As Integer = 0

                        For i = 0 To tbl1.Rows.Count - 1

                            If Trim(tbl1.Rows(i).Item("FPCOESTA")) = "ac" Then
                                If tbl1.Rows(i).Item("FPCOCLCO") = 1 Or tbl1.Rows(i).Item("FPCOCLCO") = 2 Then

                                    deAreaConstruccionComunFR2 += CType(tbl1.Rows(i).Item("FPCOARCO"), Decimal)

                                End If
                            End If

                        Next

                        ' calculo area comun 
                        deAreaConstruccionComunFR2 = (deAreaConstruccionComunFR2 * deFIPRCOED) / 100

                    Else
                        deAreaConstruccionComunFR2 = 0.0
                    End If
                Else
                    deAreaConstruccionComunFR2 = 0.0
                End If

                ' suma area comun FR1 y FR2
                deAreaConstruccionComun = deAreaConstruccionComunFR1 + deAreaConstruccionComunFR2

                ' carga la variable local
                deAreaConstruccionComunTotal = fun_Formato_Decimal_2_Decimales(deAreaConstruccionComun)

            End If

            ' retorna resultado
            Return fun_Formato_Decimal_2_Decimales(deAreaConstruccionComunTotal)

        Catch ex As Exception
            Return "0.00"
            MessageBox.Show(Err.Description)
        End Try

    End Function

    Private Function fun_ConsultarValorAreaTerrenoPrivada() As Long

        Try
            ' ========================================
            ' *** CARACTERISTICA DE PREDIO "1-6-7" ***
            ' ========================================
            If dt_FICHPRED.Rows(0).Item("FIPRCAPR") = 1 Or _
               dt_FICHPRED.Rows(0).Item("FIPRCAPR") = 6 Or _
               dt_FICHPRED.Rows(0).Item("FIPRCAPR") = 7 Then

                ' declaro las variables
                Dim loAreaDeTerrenoPrivado As Long = CType(dt_FICHPRED.Rows(0).Item("FIPRARTE"), Long)
                Dim loPorcentajeDescuento As Long = fun_ConsultarPorcentajeDeDescuentoAreaDeTerreno(loAreaDeTerrenoPrivado)
                Dim loValorTerrenoPrivado As Long = 0

                ' verifica si existen zonas
                If dt_FIPRZOEC.Rows.Count > 0 Then

                    Dim i As Integer = 0

                    ' recorre las zonas
                    For i = 0 To dt_FIPRZOEC.Rows.Count - 1

                        If Trim(dt_FIPRZOEC.Rows(i).Item("FPZEESTA")) = "ac" Then

                            ' declaro la variable 
                            Dim stDepartamento As String = Trim(dt_FICHPRED.Rows(0).Item("FIPRDEPA"))
                            Dim stMunicipio As String = Trim(dt_FICHPRED.Rows(0).Item("FIPRMUNI"))
                            Dim inClaseSector As Integer = CType(dt_FICHPRED.Rows(0).Item("FIPRCLSE"), Integer)

                            Dim inZonaEconomica As Integer = CType(dt_FIPRZOEC.Rows(i).Item("FPZEZOEC"), Integer)
                            Dim inPorcentajeZona As Integer = CType(dt_FIPRZOEC.Rows(i).Item("FPZEPORC"), Integer)

                            Dim inValorZona As Integer = 0
                            Dim deIncrementoZona As Decimal = 0.0

                            ' instancia la clase
                            Dim objdatos As New cla_ZONAECON
                            Dim tbl As New DataTable

                            tbl = objdatos.fun_Buscar_DEPARTAMENTO_Y_MUNICIPIO_Y_SECTOR_Y_CODIGO_MANT_ZONAECON(stDepartamento, stMunicipio, inClaseSector, inZonaEconomica)

                            If tbl.Rows.Count > 0 Then
                                ' almacena valor zona
                                inValorZona = CType(tbl.Rows(0).Item("ZOECVALO"), Integer)
                                deIncrementoZona = CType(tbl.Rows(0).Item("ZOECPOIN"), Decimal)

                                ' liquida individual el terreno
                                Dim loValorNeto As Long = loAreaDeTerrenoPrivado * (inValorZona * deIncrementoZona)
                                Dim loValorNetoConDesc As Long = (loValorNeto * loPorcentajeDescuento) / 100
                                Dim loValorNetoConDescZona As Long = (loValorNetoConDesc * inPorcentajeZona) / 100

                                ' valor total del terreno
                                loValorTerrenoPrivado += loValorNetoConDescZona

                            End If

                        End If

                    Next

                End If

                ' retorna el valor terreno
                Return loValorTerrenoPrivado

            End If

            ' ======================================
            ' *** CARACTERISTICA DE PREDIO "2-3" ***
            ' ======================================
            If dt_FICHPRED.Rows(0).Item("FIPRCAPR") = 2 Or _
               dt_FICHPRED.Rows(0).Item("FIPRCAPR") = 3 Then

                ' declaro variables
                Dim loValorTerrenoPrivado As Long = 0
                Dim loAreaDeTerrenoPrivado As Long = CType(dt_FICHPRED.Rows(0).Item("FIPRARTE"), Long)
                Dim deAreaDeTerrenoComun As Decimal = 0.0

                Dim deFIPRCOED As Decimal = CType(dt_FICHPRED.Rows(0).Item("FIPRCOED"), Decimal)
                Dim inFIPRTIFI As Integer = 2
                Dim stFIPRUNPR As String = "00000"

                ' instancia la clase
                Dim objdatos As New cla_FICHRESU
                Dim tbl As New DataTable

                tbl = objdatos.fun_buscar_CEDULA_CATASTRAL_FICHRESU(Trim(dt_FICHPRED.Rows(0).Item("FIPRMUNI")), Trim(dt_FICHPRED.Rows(0).Item("FIPRCORR")), Trim(dt_FICHPRED.Rows(0).Item("FIPRBARR")), Trim(dt_FICHPRED.Rows(0).Item("FIPRMANZ")), Trim(dt_FICHPRED.Rows(0).Item("FIPRPRED")), Trim(dt_FICHPRED.Rows(0).Item("FIPREDIF")), Trim(stFIPRUNPR), Trim(dt_FICHPRED.Rows(0).Item("FIPRCLSE")), inFIPRTIFI)

                ' verifica si existen registros 
                If tbl.Rows.Count > 0 Then

                    ' area de terreno comun
                    Dim loAreaComunDeLoteFR2 As Long = CType(tbl.Rows(0).Item("FIPRACLO"), Long)

                    deAreaDeTerrenoComun = (loAreaComunDeLoteFR2 * deFIPRCOED) / 100

                    ' halla el porcentaje de descuento
                    Dim inPorcentajeDescuento As Integer = 0

                    inPorcentajeDescuento = fun_ConsultarPorcentajeDeDescuentoAreaDeTerreno(loAreaDeTerrenoPrivado + deAreaDeTerrenoComun)

                    ' verifica si existen zonas
                    If dt_FIPRZOEC.Rows.Count > 0 Then

                        Dim i As Integer = 0

                        ' recorre las zonas
                        For i = 0 To dt_FIPRZOEC.Rows.Count - 1

                            If Trim(dt_FIPRZOEC.Rows(i).Item("FPZEESTA")) = "ac" Then

                                ' declaro la variable 
                                Dim stDepartamento As String = Trim(dt_FICHPRED.Rows(0).Item("FIPRDEPA"))
                                Dim stMunicipio As String = Trim(dt_FICHPRED.Rows(0).Item("FIPRMUNI"))
                                Dim inClaseSector As Integer = CType(dt_FICHPRED.Rows(0).Item("FIPRCLSE"), Integer)

                                Dim inZonaEconomica As Integer = CType(dt_FIPRZOEC.Rows(i).Item("FPZEZOEC"), Integer)
                                Dim inPorcentajeZona As Integer = CType(dt_FIPRZOEC.Rows(i).Item("FPZEPORC"), Integer)

                                Dim inValorZona As Integer = 0
                                Dim deIncrementoZona As Decimal = 0.0

                                ' instancia la clase
                                Dim objdatos1 As New cla_ZONAECON
                                Dim tbl1 As New DataTable

                                tbl1 = objdatos1.fun_Buscar_DEPARTAMENTO_Y_MUNICIPIO_Y_SECTOR_Y_CODIGO_MANT_ZONAECON(stDepartamento, stMunicipio, inClaseSector, inZonaEconomica)

                                If tbl1.Rows.Count > 0 Then
                                    ' almacena valor zona
                                    inValorZona = CType(tbl1.Rows(0).Item("ZOECVALO"), Integer)
                                    deIncrementoZona = CType(tbl1.Rows(0).Item("ZOECPOIN"), Decimal)

                                    ' liquida individual el terreno
                                    Dim loValorNeto As Long = loAreaDeTerrenoPrivado * (inValorZona * deIncrementoZona)
                                    Dim loValorNetoConDesc As Long = (loValorNeto * inPorcentajeDescuento) / 100
                                    Dim loValorNetoConDescZona As Long = (loValorNetoConDesc * inPorcentajeZona) / 100

                                    ' valor total del terreno
                                    loValorTerrenoPrivado += loValorNetoConDescZona

                                End If

                            End If

                        Next

                    End If

                End If

                ' retorna el valor terreno
                Return loValorTerrenoPrivado

            End If

            ' ====================================
            ' *** CARACTERISTICA DE PREDIO "4" ***
            ' ====================================
            If dt_FICHPRED.Rows(0).Item("FIPRCAPR") = 4 Then

                ' declaro variables
                Dim loValorTerrenoPrivado As Long = 0

                Dim loAreaDeTerrenoPrivado As Long = CType(dt_FICHPRED.Rows(0).Item("FIPRARTE"), Long)
                Dim loAreaComunDeLoteFR1 As Long = 0
                Dim loAreaComunDeLoteFR2 As Long = 0
                Dim deAreaDeTerrenoComunFR1 As Decimal = 0
                Dim deAreaDeTerrenoComunFR2 As Decimal = 0

                Dim deFIPRCOED As Decimal = CType(dt_FICHPRED.Rows(0).Item("FIPRCOED"), Decimal)
                Dim deFIPRCOPR As Decimal = CType(dt_FICHPRED.Rows(0).Item("FIPRCOPR"), Decimal)
                Dim inFIPRTIFI_1 As Integer = 1
                Dim inFIPRTIFI_2 As Integer = 2
                Dim stFIPREDIF As String = "000"
                Dim stFIPRUNPR As String = "00000"

                '============================================
                ' *** CONSULTA AREA COMUN FICHA RESUMEN 1 ***
                '============================================

                ' instancia la clase
                Dim objdatosFR1 As New cla_FICHRESU
                Dim tblFR1 As New DataTable

                tblFR1 = objdatosFR1.fun_buscar_CEDULA_CATASTRAL_FICHRESU(Trim(dt_FICHPRED.Rows(0).Item("FIPRMUNI")), Trim(dt_FICHPRED.Rows(0).Item("FIPRCORR")), Trim(dt_FICHPRED.Rows(0).Item("FIPRBARR")), Trim(dt_FICHPRED.Rows(0).Item("FIPRMANZ")), Trim(dt_FICHPRED.Rows(0).Item("FIPRPRED")), Trim(stFIPREDIF), Trim(stFIPRUNPR), Trim(dt_FICHPRED.Rows(0).Item("FIPRCLSE")), inFIPRTIFI_1)

                ' verifica si existen registros 
                If tblFR1.Rows.Count > 0 Then

                    ' area comun lote FR1
                    loAreaComunDeLoteFR1 = CType(tblFR1.Rows(0).Item("FIPRACLO"), Long)

                    ' area de terreno comun FR1
                    deAreaDeTerrenoComunFR1 = (loAreaComunDeLoteFR1 * deFIPRCOPR) / 100

                End If

                '============================================
                ' *** CONSULTA AREA COMUN FICHA RESUMEN 2 ***
                '============================================

                ' instancia la clase
                Dim objdatosFR2 As New cla_FICHRESU
                Dim tblFR2 As New DataTable

                tblFR2 = objdatosFR2.fun_buscar_CEDULA_CATASTRAL_FICHRESU(Trim(dt_FICHPRED.Rows(0).Item("FIPRMUNI")), Trim(dt_FICHPRED.Rows(0).Item("FIPRCORR")), Trim(dt_FICHPRED.Rows(0).Item("FIPRBARR")), Trim(dt_FICHPRED.Rows(0).Item("FIPRMANZ")), Trim(dt_FICHPRED.Rows(0).Item("FIPRPRED")), Trim(dt_FICHPRED.Rows(0).Item("FIPREDIF")), Trim(stFIPRUNPR), Trim(dt_FICHPRED.Rows(0).Item("FIPRCLSE")), inFIPRTIFI_2)

                ' verifica si existen registros 
                If tblFR2.Rows.Count > 0 Then

                    ' area comun lote FR2
                    loAreaComunDeLoteFR2 = CType(tblFR2.Rows(0).Item("FIPRACLO"), Long)

                    ' area de terreno comun FR2
                    deAreaDeTerrenoComunFR2 = (loAreaComunDeLoteFR2 * deFIPRCOED) / 100

                End If

                '==========================================
                ' *** ESTABLECE PORCENTAJE DE DESCUENTO ***
                '==========================================

                ' verifica si existen registros 
                If tblFR1.Rows.Count > 0 Then
                    If tblFR2.Rows.Count > 0 Then

                        ' halla el porcentaje de descuento
                        Dim inPorcentajeDescuento As Long = 0

                        ' halla el area privada con descuento
                        inPorcentajeDescuento = fun_ConsultarPorcentajeDeDescuentoAreaDeTerreno(loAreaDeTerrenoPrivado + deAreaDeTerrenoComunFR1 + deAreaDeTerrenoComunFR2)

                        ' verifica si existen zonas
                        If dt_FIPRZOEC.Rows.Count > 0 Then

                            Dim i As Integer = 0

                            ' recorre las zonas
                            For i = 0 To dt_FIPRZOEC.Rows.Count - 1

                                If Trim(dt_FIPRZOEC.Rows(i).Item("FPZEESTA")) = "ac" Then

                                    ' declaro la variable 
                                    Dim stDepartamento As String = Trim(dt_FICHPRED.Rows(0).Item("FIPRDEPA"))
                                    Dim stMunicipio As String = Trim(dt_FICHPRED.Rows(0).Item("FIPRMUNI"))
                                    Dim inClaseSector As Integer = CType(dt_FICHPRED.Rows(0).Item("FIPRCLSE"), Integer)

                                    Dim inZonaEconomica As Integer = CType(dt_FIPRZOEC.Rows(i).Item("FPZEZOEC"), Integer)
                                    Dim inPorcentajeZona As Integer = CType(dt_FIPRZOEC.Rows(i).Item("FPZEPORC"), Integer)

                                    Dim inValorZona As Integer = 0
                                    Dim deIncrementoZona As Decimal = 0.0

                                    ' instancia la clase
                                    Dim objdatos1 As New cla_ZONAECON
                                    Dim tbl1 As New DataTable

                                    tbl1 = objdatos1.fun_Buscar_DEPARTAMENTO_Y_MUNICIPIO_Y_SECTOR_Y_CODIGO_MANT_ZONAECON(stDepartamento, stMunicipio, inClaseSector, inZonaEconomica)

                                    If tbl1.Rows.Count > 0 Then
                                        ' almacena valor zona
                                        inValorZona = CType(tbl1.Rows(0).Item("ZOECVALO"), Integer)
                                        deIncrementoZona = CType(tbl1.Rows(0).Item("ZOECPOIN"), Decimal)

                                        ' liquida individual el terreno
                                        Dim loValorNeto As Long = loAreaDeTerrenoPrivado * (inValorZona * deIncrementoZona)
                                        Dim loValorNetoConDesc As Long = (loValorNeto * inPorcentajeDescuento) / 100
                                        Dim loValorNetoConDescZona As Long = (loValorNetoConDesc * inPorcentajeZona) / 100

                                        ' valor total del terreno
                                        loValorTerrenoPrivado += loValorNetoConDescZona

                                    End If

                                End If

                            Next

                        End If

                    End If

                End If

                ' retorna el valor terreno
                Return loValorTerrenoPrivado

            End If

        Catch ex As Exception
            Return 0
            MessageBox.Show(Err.Description)
        End Try

    End Function
    Private Function fun_ConsultarValorAreaTerrenoComun() As Long

        Try
            ' ========================================
            ' *** CARACTERISTICA DE PREDIO "1-6-7" ***
            ' ========================================
            If dt_FICHPRED.Rows(0).Item("FIPRCAPR") = 1 Or _
               dt_FICHPRED.Rows(0).Item("FIPRCAPR") = 6 Or _
               dt_FICHPRED.Rows(0).Item("FIPRCAPR") = 7 Then

                Return 0

            End If

            ' ======================================
            ' *** CARACTERISTICA DE PREDIO "2-3" ***
            ' ======================================
            If dt_FICHPRED.Rows(0).Item("FIPRCAPR") = 2 Or _
               dt_FICHPRED.Rows(0).Item("FIPRCAPR") = 3 Then

                ' declaro variables
                Dim loValorTerrenoComun As Long = 0
                Dim loAreaDeTerrenoPrivado As Long = CType(dt_FICHPRED.Rows(0).Item("FIPRARTE"), Long)
                Dim deAreaDeTerrenoComun As Decimal = 0.0

                Dim deFIPRCOED As Decimal = CType(dt_FICHPRED.Rows(0).Item("FIPRCOED"), Decimal)
                Dim inFIPRTIFI As Integer = 2
                Dim stFIPRUNPR As String = "00000"

                ' instancia la clase
                Dim objdatos As New cla_FICHRESU
                Dim tbl As New DataTable

                tbl = objdatos.fun_buscar_CEDULA_CATASTRAL_FICHRESU(Trim(dt_FICHPRED.Rows(0).Item("FIPRMUNI")), Trim(dt_FICHPRED.Rows(0).Item("FIPRCORR")), Trim(dt_FICHPRED.Rows(0).Item("FIPRBARR")), Trim(dt_FICHPRED.Rows(0).Item("FIPRMANZ")), Trim(dt_FICHPRED.Rows(0).Item("FIPRPRED")), Trim(dt_FICHPRED.Rows(0).Item("FIPREDIF")), Trim(stFIPRUNPR), Trim(dt_FICHPRED.Rows(0).Item("FIPRCLSE")), inFIPRTIFI)

                ' verifica si existen registros 
                If tbl.Rows.Count > 0 Then

                    ' area de terreno comun
                    Dim loAreaComunDeLoteFR2 As Long = CType(tbl.Rows(0).Item("FIPRACLO"), Long)

                    deAreaDeTerrenoComun = (loAreaComunDeLoteFR2 * deFIPRCOED) / 100

                    ' halla el porcentaje de descuento
                    Dim inPorcentajeDescuento As Integer = 0

                    inPorcentajeDescuento = fun_ConsultarPorcentajeDeDescuentoAreaDeTerreno(loAreaDeTerrenoPrivado + deAreaDeTerrenoComun)

                    ' declara el numero de ficha
                    Dim inFIRENUFI As Integer = CType(tbl.Rows(0).Item("FIPRNUFI"), Integer)

                    ' instancia la clase
                    Dim objdatos11 As New cla_FIPRZOEC
                    Dim tbl1_Zonas_FR As New DataTable

                    ' almacena las zonas
                    tbl1_Zonas_FR = objdatos11.fun_Consultar_FIPRZOEC_X_FICHA_PREDIAL(inFIRENUFI)

                    ' verifica si existen zonas
                    If tbl1_Zonas_FR.Rows.Count > 0 Then

                        Dim i As Integer = 0

                        ' recorre las zonas
                        For i = 0 To tbl1_Zonas_FR.Rows.Count - 1

                            If Trim(tbl1_Zonas_FR.Rows(i).Item("FPZEESTA")) = "ac" Then

                                ' declaro la variable 
                                Dim stDepartamento As String = Trim(dt_FICHPRED.Rows(0).Item("FIPRDEPA"))
                                Dim stMunicipio As String = Trim(dt_FICHPRED.Rows(0).Item("FIPRMUNI"))
                                Dim inClaseSector As Integer = CType(dt_FICHPRED.Rows(0).Item("FIPRCLSE"), Integer)

                                Dim inZonaEconomica As Integer = CType(tbl1_Zonas_FR.Rows(i).Item("FPZEZOEC"), Integer)
                                Dim inPorcentajeZona As Integer = CType(tbl1_Zonas_FR.Rows(i).Item("FPZEPORC"), Integer)

                                Dim inValorZona As Integer = 0
                                Dim deIncrementoZona As Decimal = 0.0

                                ' instancia la clase
                                Dim objdatos1 As New cla_ZONAECON
                                Dim tbl1 As New DataTable

                                tbl1 = objdatos1.fun_Buscar_DEPARTAMENTO_Y_MUNICIPIO_Y_SECTOR_Y_CODIGO_MANT_ZONAECON(stDepartamento, stMunicipio, inClaseSector, inZonaEconomica)

                                If tbl1.Rows.Count > 0 Then
                                    ' almacena valor zona
                                    inValorZona = CType(tbl1.Rows(0).Item("ZOECVALO"), Integer)
                                    deIncrementoZona = CType(tbl1.Rows(0).Item("ZOECPOIN"), Decimal)

                                    ' liquida individual el terreno
                                    Dim loValorNeto As Long = deAreaDeTerrenoComun * (inValorZona * deIncrementoZona)
                                    Dim loValorNetoConDesc As Long = (loValorNeto * inPorcentajeDescuento) / 100
                                    Dim loValorNetoConDescZona As Long = (loValorNetoConDesc * inPorcentajeZona) / 100

                                    ' valor total del terreno
                                    loValorTerrenoComun += loValorNetoConDescZona

                                End If

                            End If

                        Next

                    End If

                End If

                ' retorna el valor terreno
                Return loValorTerrenoComun

            End If

            ' ====================================
            ' *** CARACTERISTICA DE PREDIO "4" ***
            ' ====================================
            If dt_FICHPRED.Rows(0).Item("FIPRCAPR") = 4 Then

                ' declaro variables
                Dim loValorTerrenoComun As Long = 0
                Dim loValorTerrenoComunFR1 As Long = 0
                Dim loValorTerrenoComunFR2 As Long = 0

                Dim loAreaDeTerrenoPrivado As Long = CType(dt_FICHPRED.Rows(0).Item("FIPRARTE"), Long)
                Dim loAreaComunDeLoteFR1 As Long = 0
                Dim loAreaComunDeLoteFR2 As Long = 0
                Dim deAreaDeTerrenoComunFR1 As Decimal = 0.0
                Dim deAreaDeTerrenoComunFR2 As Decimal = 0.0

                Dim deFIPRCOED As Decimal = CType(dt_FICHPRED.Rows(0).Item("FIPRCOED"), Decimal)
                Dim deFIPRCOPR As Decimal = CType(dt_FICHPRED.Rows(0).Item("FIPRCOPR"), Decimal)
                Dim inFIPRTIFI_1 As Integer = 1
                Dim inFIPRTIFI_2 As Integer = 2
                Dim stFIPREDIF As String = "000"
                Dim stFIPRUNPR As String = "00000"

                '============================================
                ' *** CONSULTA AREA COMUN FICHA RESUMEN 1 ***
                '============================================

                ' instancia la clase
                Dim objdatosFR1 As New cla_FICHRESU
                Dim tblFR1 As New DataTable

                tblFR1 = objdatosFR1.fun_buscar_CEDULA_CATASTRAL_FICHRESU(Trim(dt_FICHPRED.Rows(0).Item("FIPRMUNI")), Trim(dt_FICHPRED.Rows(0).Item("FIPRCORR")), Trim(dt_FICHPRED.Rows(0).Item("FIPRBARR")), Trim(dt_FICHPRED.Rows(0).Item("FIPRMANZ")), Trim(dt_FICHPRED.Rows(0).Item("FIPRPRED")), Trim(stFIPREDIF), Trim(stFIPRUNPR), Trim(dt_FICHPRED.Rows(0).Item("FIPRCLSE")), inFIPRTIFI_1)

                ' verifica si existen registros 
                If tblFR1.Rows.Count > 0 Then

                    ' area comun lote FR1
                    loAreaComunDeLoteFR1 = CType(tblFR1.Rows(0).Item("FIPRACLO"), Long)

                    ' area de terreno comun FR1
                    deAreaDeTerrenoComunFR1 = (loAreaComunDeLoteFR1 * deFIPRCOPR) / 100

                End If

                '============================================
                ' *** CONSULTA AREA COMUN FICHA RESUMEN 2 ***
                '============================================

                ' instancia la clase
                Dim objdatosFR2 As New cla_FICHRESU
                Dim tblFR2 As New DataTable

                tblFR2 = objdatosFR2.fun_buscar_CEDULA_CATASTRAL_FICHRESU(Trim(dt_FICHPRED.Rows(0).Item("FIPRMUNI")), Trim(dt_FICHPRED.Rows(0).Item("FIPRCORR")), Trim(dt_FICHPRED.Rows(0).Item("FIPRBARR")), Trim(dt_FICHPRED.Rows(0).Item("FIPRMANZ")), Trim(dt_FICHPRED.Rows(0).Item("FIPRPRED")), Trim(dt_FICHPRED.Rows(0).Item("FIPREDIF")), Trim(stFIPRUNPR), Trim(dt_FICHPRED.Rows(0).Item("FIPRCLSE")), inFIPRTIFI_2)

                ' verifica si existen registros 
                If tblFR2.Rows.Count > 0 Then

                    ' area comun lote FR2
                    loAreaComunDeLoteFR2 = CType(tblFR2.Rows(0).Item("FIPRACLO"), Long)

                    ' area de terreno comun FR2
                    deAreaDeTerrenoComunFR2 = (loAreaComunDeLoteFR2 * deFIPRCOED) / 100

                End If

                '==========================================
                ' *** ESTABLECE PORCENTAJE DE DESCUENTO ***
                '==========================================

                ' verifica si existen registros 
                If tblFR1.Rows.Count > 0 Then
                    If tblFR2.Rows.Count > 0 Then

                        ' halla el porcentaje de descuento
                        Dim inPorcentajeDescuento As Long = 0

                        ' halla el area privada con descuento
                        inPorcentajeDescuento = fun_ConsultarPorcentajeDeDescuentoAreaDeTerreno(loAreaDeTerrenoPrivado + deAreaDeTerrenoComunFR1 + deAreaDeTerrenoComunFR2)

                        '=============================================
                        ' *** VALOR DEL ÁREA COMUN FICHA RESUMEN 1 ***
                        '=============================================

                        ' declara el numero de ficha
                        Dim inFIRENUFI_FR1 As Integer = CType(tblFR1.Rows(0).Item("FIPRNUFI"), Integer)

                        ' instancia la clase
                        Dim objdatos11_FR1 As New cla_FIPRZOEC
                        Dim tbl1_Zonas_FR1 As New DataTable

                        ' almacena las zonas
                        tbl1_Zonas_FR1 = objdatos11_FR1.fun_Consultar_FIPRZOEC_X_FICHA_PREDIAL(inFIRENUFI_FR1)

                        ' verifica si existen zonas
                        If tbl1_Zonas_FR1.Rows.Count > 0 Then

                            Dim i As Integer = 0

                            ' recorre las zonas
                            For i = 0 To tbl1_Zonas_FR1.Rows.Count - 1

                                If Trim(tbl1_Zonas_FR1.Rows(i).Item("FPZEESTA")) = "ac" Then

                                    ' declaro la variable 
                                    Dim stDepartamento As String = Trim(dt_FICHPRED.Rows(0).Item("FIPRDEPA"))
                                    Dim stMunicipio As String = Trim(dt_FICHPRED.Rows(0).Item("FIPRMUNI"))
                                    Dim inClaseSector As Integer = CType(dt_FICHPRED.Rows(0).Item("FIPRCLSE"), Integer)

                                    Dim inZonaEconomica As Integer = CType(tbl1_Zonas_FR1.Rows(i).Item("FPZEZOEC"), Integer)
                                    Dim inPorcentajeZona As Integer = CType(tbl1_Zonas_FR1.Rows(i).Item("FPZEPORC"), Integer)

                                    Dim inValorZona As Integer = 0
                                    Dim deIncrementoZona As Decimal = 0.0

                                    ' instancia la clase
                                    Dim objdatos1 As New cla_ZONAECON
                                    Dim tbl1 As New DataTable

                                    tbl1 = objdatos1.fun_Buscar_DEPARTAMENTO_Y_MUNICIPIO_Y_SECTOR_Y_CODIGO_MANT_ZONAECON(stDepartamento, stMunicipio, inClaseSector, inZonaEconomica)

                                    If tbl1.Rows.Count > 0 Then
                                        ' almacena valor zona
                                        inValorZona = CType(tbl1.Rows(0).Item("ZOECVALO"), Integer)
                                        deIncrementoZona = CType(tbl1.Rows(0).Item("ZOECPOIN"), Decimal)

                                        ' liquida individual el terreno
                                        Dim loValorNeto As Long = deAreaDeTerrenoComunFR1 * (inValorZona * deIncrementoZona)
                                        Dim loValorNetoConDesc As Long = (loValorNeto * inPorcentajeDescuento) / 100
                                        Dim loValorNetoConDescZona As Long = (loValorNetoConDesc * inPorcentajeZona) / 100

                                        ' valor total del terreno
                                        loValorTerrenoComunFR1 += loValorNetoConDescZona

                                    End If

                                End If

                            Next

                        End If

                        '=============================================
                        ' *** VALOR DEL ÁREA COMUN FICHA RESUMEN 2 ***
                        '=============================================

                        ' declara el numero de ficha
                        Dim inFIRENUFI_FR2 As Integer = CType(tblFR2.Rows(0).Item("FIPRNUFI"), Integer)

                        ' instancia la clase
                        Dim objdatos11_FR2 As New cla_FIPRZOEC
                        Dim tbl1_Zonas_FR2 As New DataTable

                        ' almacena las zonas
                        tbl1_Zonas_FR2 = objdatos11_FR2.fun_Consultar_FIPRZOEC_X_FICHA_PREDIAL(inFIRENUFI_FR2)

                        ' verifica si existen zonas
                        If tbl1_Zonas_FR2.Rows.Count > 0 Then

                            Dim i As Integer = 0

                            ' recorre las zonas
                            For i = 0 To tbl1_Zonas_FR2.Rows.Count - 1

                                If Trim(tbl1_Zonas_FR2.Rows(i).Item("FPZEESTA")) = "ac" Then

                                    ' declaro la variable 
                                    Dim stDepartamento As String = Trim(dt_FICHPRED.Rows(0).Item("FIPRDEPA"))
                                    Dim stMunicipio As String = Trim(dt_FICHPRED.Rows(0).Item("FIPRMUNI"))
                                    Dim inClaseSector As Integer = CType(dt_FICHPRED.Rows(0).Item("FIPRCLSE"), Integer)

                                    Dim inZonaEconomica As Integer = CType(tbl1_Zonas_FR2.Rows(i).Item("FPZEZOEC"), Integer)
                                    Dim inPorcentajeZona As Integer = CType(tbl1_Zonas_FR2.Rows(i).Item("FPZEPORC"), Integer)

                                    Dim inValorZona As Integer = 0
                                    Dim deIncrementoZona As Decimal = 0.0

                                    ' instancia la clase
                                    Dim objdatos1 As New cla_ZONAECON
                                    Dim tbl1 As New DataTable

                                    tbl1 = objdatos1.fun_Buscar_DEPARTAMENTO_Y_MUNICIPIO_Y_SECTOR_Y_CODIGO_MANT_ZONAECON(stDepartamento, stMunicipio, inClaseSector, inZonaEconomica)

                                    If tbl1.Rows.Count > 0 Then
                                        ' almacena valor zona
                                        inValorZona = CType(tbl1.Rows(0).Item("ZOECVALO"), Integer)
                                        deIncrementoZona = CType(tbl1.Rows(0).Item("ZOECPOIN"), Decimal)

                                        ' liquida individual el terreno
                                        Dim loValorNeto As Long = deAreaDeTerrenoComunFR2 * (inValorZona * deIncrementoZona)
                                        Dim loValorNetoConDesc As Long = (loValorNeto * inPorcentajeDescuento) / 100
                                        Dim loValorNetoConDescZona As Long = (loValorNetoConDesc * inPorcentajeZona) / 100

                                        ' valor total del terreno
                                        loValorTerrenoComunFR2 += loValorNetoConDescZona

                                    End If

                                End If

                            Next

                        End If

                        loValorTerrenoComun = loValorTerrenoComunFR1 + loValorTerrenoComunFR2

                    End If
                End If

                ' retorna el valor terreno
                Return loValorTerrenoComun

            End If
        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Function
    Private Function fun_ConsultarValorAreaConstruccionPrivada() As Long

        Try
            ' ================================================
            ' *** CARACTERISTICA DE PREDIO "1-2-3-4-5-6-7" ***
            ' ================================================
            If dt_FICHPRED.Rows(0).Item("FIPRCAPR") = 1 Or _
               dt_FICHPRED.Rows(0).Item("FIPRCAPR") = 2 Or _
               dt_FICHPRED.Rows(0).Item("FIPRCAPR") = 3 Or _
               dt_FICHPRED.Rows(0).Item("FIPRCAPR") = 4 Or _
               dt_FICHPRED.Rows(0).Item("FIPRCAPR") = 5 Or _
               dt_FICHPRED.Rows(0).Item("FIPRCAPR") = 6 Or _
               dt_FICHPRED.Rows(0).Item("FIPRCAPR") = 7 Then

                ' declaro las variables
                Dim deAreaDeConstruccionPrivado As Decimal = 0.0
                Dim loValorConstruccionPrivado As Long = 0

                ' verifica si existe construcciones
                If dt_FIPRCONS.Rows.Count > 0 Then

                    Dim i As Integer = 0

                    For i = 0 To dt_FIPRCONS.Rows.Count - 1

                        If Trim(dt_FIPRCONS.Rows(i).Item("FPCOESTA")) = "ac" Then
                            If dt_FIPRCONS.Rows(i).Item("FPCOCLCO") = 1 Or dt_FIPRCONS.Rows(i).Item("FPCOCLCO") = 2 Then

                                ' declaro la variable 
                                Dim stDepartamento As String = Trim(dt_FICHPRED.Rows(0).Item("FIPRDEPA"))
                                Dim stMunicipio As String = Trim(dt_FICHPRED.Rows(0).Item("FIPRMUNI"))
                                Dim inClaseSector As Integer = CType(dt_FICHPRED.Rows(0).Item("FIPRCLSE"), Integer)

                                Dim stIdentificador As String = Trim(dt_FIPRCONS.Rows(i).Item("FPCOTICO"))
                                Dim inClaseConstruccion As Integer = CType(dt_FIPRCONS.Rows(i).Item("FPCOCLCO"), Integer)
                                Dim inPuntoConstruccion As Integer = CType(dt_FIPRCONS.Rows(i).Item("FPCOPUNT"), Integer)
                                Dim deAreaDeConstruccion As Decimal = CType(dt_FIPRCONS.Rows(i).Item("FPCOARCO"), Decimal)

                                Dim deValorFactorA As Decimal = 0.0
                                Dim deValorFactorB As Decimal = 0.0
                                Dim dePorcentajeDeIncremento As Decimal = 0.0

                                Dim loValorPuntos As Long = 0

                                ' instancia las clase
                                Dim objdatos As New cla_TIPOCONS
                                Dim tbl As New DataTable

                                tbl = objdatos.fun_buscar_TICODEPA_X_TICOMUNI_X_TICOCLCO_X_TICOCLSE_X_TIPOCONS_X_CLASCONS_MANT_TIPOCONS(stDepartamento, stMunicipio, inClaseConstruccion, inClaseSector, stIdentificador)

                                If tbl.Rows.Count > 0 Then

                                    ' almacena valor de los factores
                                    deValorFactorA = CType(tbl.Rows(0).Item("TICOFAC1"), Decimal)
                                    deValorFactorB = CType(tbl.Rows(0).Item("TICOFAC2"), Decimal)
                                    dePorcentajeDeIncremento = CType(tbl.Rows(0).Item("TICOPOIN"), Decimal)

                                    ' declara la variable
                                    Dim stModoDeLiquidacion As String = Trim(tbl.Rows(0).Item("TICOMOLI"))

                                    ' liquidacion 'NINGUNO'
                                    If Trim(stModoDeLiquidacion) = "Ninguno" Then
                                        loValorConstruccionPrivado = 0
                                    End If

                                    ' Liquidacion 'POTENCIAL'
                                    If Trim(stModoDeLiquidacion) = "Potencial" Then
                                        deValorFactorA = (deValorFactorA * dePorcentajeDeIncremento)

                                        loValorPuntos = deValorFactorA * Pow(inPuntoConstruccion, deValorFactorB)
                                        loValorConstruccionPrivado += (deAreaDeConstruccion * loValorPuntos)
                                    End If

                                    ' liquidacion 'EXPONENCIAL'
                                    If Trim(stModoDeLiquidacion) = "Exponencial" Then
                                        deValorFactorA = (deValorFactorA * dePorcentajeDeIncremento)

                                        loValorPuntos = deValorFactorA * Exp(deValorFactorB * inPuntoConstruccion)
                                        loValorConstruccionPrivado += (deAreaDeConstruccion * loValorPuntos)
                                    End If

                                    ' liquidacion 'LINEAL'
                                    If Trim(stModoDeLiquidacion) = "Lineal" Then
                                        deValorFactorA = (deValorFactorA * dePorcentajeDeIncremento)
                                        deValorFactorB = (deValorFactorB * dePorcentajeDeIncremento)

                                        loValorPuntos = (deValorFactorA + inPuntoConstruccion) * deValorFactorB
                                        loValorConstruccionPrivado += (deAreaDeConstruccion * loValorPuntos)
                                    End If

                                End If

                            End If
                        End If

                    Next

                End If

                ' retorna el valor de la construccion
                Return loValorConstruccionPrivado

            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Function
    Private Function fun_ConsultarValorAreaConstruccionComun() As Long

        Try
            ' ================================================
            ' *** CARACTERISTICA DE PREDIO "1-2-3-4-5-6-7" ***
            ' ================================================
            If dt_FICHPRED.Rows(0).Item("FIPRCAPR") = 1 Or _
               dt_FICHPRED.Rows(0).Item("FIPRCAPR") = 6 Or _
               dt_FICHPRED.Rows(0).Item("FIPRCAPR") = 7 Then

                Return 0

            End If

            ' ======================================
            ' *** CARACTERISTICA DE PREDIO "2-3" ***
            ' ======================================
            If dt_FICHPRED.Rows(0).Item("FIPRCAPR") = 2 Or _
               dt_FICHPRED.Rows(0).Item("FIPRCAPR") = 3 Then

                ' declaro variables
                Dim deAreaDeConstruccionComun As Decimal = 0.0
                Dim loValorConstruccionComun As Long = 0

                Dim deFIPRCOED As Decimal = CType(dt_FICHPRED.Rows(0).Item("FIPRCOED"), Decimal)
                Dim inFIPRTIFI As Integer = 2
                Dim stFIPRUNPR As String = "00000"

                ' instancia la clase
                Dim objdatos_FR2 As New cla_FICHRESU
                Dim tbl_FR2 As New DataTable

                tbl_FR2 = objdatos_FR2.fun_buscar_CEDULA_CATASTRAL_FICHRESU(Trim(dt_FICHPRED.Rows(0).Item("FIPRMUNI")), Trim(dt_FICHPRED.Rows(0).Item("FIPRCORR")), Trim(dt_FICHPRED.Rows(0).Item("FIPRBARR")), Trim(dt_FICHPRED.Rows(0).Item("FIPRMANZ")), Trim(dt_FICHPRED.Rows(0).Item("FIPRPRED")), Trim(dt_FICHPRED.Rows(0).Item("FIPREDIF")), Trim(stFIPRUNPR), Trim(dt_FICHPRED.Rows(0).Item("FIPRCLSE")), inFIPRTIFI)

                If tbl_FR2.Rows.Count > 0 Then

                    ' declaro la variable
                    Dim inFIRENUFI As Integer = CType(tbl_FR2.Rows(0).Item("FIPRNUFI"), Integer)

                    ' instancia la clase
                    Dim objdatos_CONS_FR2 As New cla_FIPRCONS
                    Dim tbl_CONS_FR2 As New DataTable

                    tbl_CONS_FR2 = objdatos_CONS_FR2.fun_Consultar_FIPRCONS_X_FICHA_PREDIAL(inFIRENUFI)

                    ' verifica si existe construcciones
                    If tbl_CONS_FR2.Rows.Count > 0 Then

                        Dim i As Integer = 0

                        For i = 0 To tbl_CONS_FR2.Rows.Count - 1

                            If Trim(tbl_CONS_FR2.Rows(i).Item("FPCOESTA")) = "ac" Then
                                If tbl_CONS_FR2.Rows(i).Item("FPCOCLCO") = 1 Or tbl_CONS_FR2.Rows(i).Item("FPCOCLCO") = 2 Then

                                    ' declaro la variable 
                                    Dim stDepartamento As String = Trim(dt_FICHPRED.Rows(0).Item("FIPRDEPA"))
                                    Dim stMunicipio As String = Trim(dt_FICHPRED.Rows(0).Item("FIPRMUNI"))
                                    Dim inClaseSector As Integer = CType(dt_FICHPRED.Rows(0).Item("FIPRCLSE"), Integer)

                                    Dim stIdentificador As String = Trim(tbl_CONS_FR2.Rows(i).Item("FPCOTICO"))
                                    Dim inClaseConstruccion As Integer = CType(tbl_CONS_FR2.Rows(i).Item("FPCOCLCO"), Integer)
                                    Dim inPuntoConstruccion As Integer = CType(tbl_CONS_FR2.Rows(i).Item("FPCOPUNT"), Integer)
                                    Dim deAreaDeConstruccion As Decimal = CType(tbl_CONS_FR2.Rows(i).Item("FPCOARCO"), Decimal)

                                    Dim deValorFactorA As Decimal = 0.0
                                    Dim deValorFactorB As Decimal = 0.0
                                    Dim dePorcentajeDeIncremento As Decimal = 0.0

                                    Dim loValorPuntos As Long = 0

                                    ' instancia las clase
                                    Dim objdatos As New cla_TIPOCONS
                                    Dim tbl As New DataTable

                                    tbl = objdatos.fun_buscar_TICODEPA_X_TICOMUNI_X_TICOCLCO_X_TICOCLSE_X_TIPOCONS_X_CLASCONS_MANT_TIPOCONS(stDepartamento, stMunicipio, inClaseConstruccion, inClaseSector, stIdentificador)

                                    If tbl.Rows.Count > 0 Then

                                        ' almacena valor de los factores
                                        deValorFactorA = CType(tbl.Rows(0).Item("TICOFAC1"), Decimal)
                                        deValorFactorB = CType(tbl.Rows(0).Item("TICOFAC2"), Decimal)
                                        dePorcentajeDeIncremento = CType(tbl.Rows(0).Item("TICOPOIN"), Decimal)

                                        ' declara la variable
                                        Dim stModoDeLiquidacion As String = Trim(tbl.Rows(0).Item("TICOMOLI"))

                                        ' liquidacion 'NINGUNO'
                                        If Trim(stModoDeLiquidacion) = "Ninguno" Then
                                            loValorConstruccionComun = 0
                                        End If

                                        ' Liquidacion 'POTENCIAL'
                                        If Trim(stModoDeLiquidacion) = "Potencial" Then
                                            deValorFactorA = (deValorFactorA * dePorcentajeDeIncremento)

                                            loValorPuntos = deValorFactorA * Pow(inPuntoConstruccion, deValorFactorB)

                                            Dim loValorConstruccionComunTotal As Long = (deAreaDeConstruccion * loValorPuntos)
                                            loValorConstruccionComun += (loValorConstruccionComunTotal * deFIPRCOED) / 100
                                        End If

                                        ' liquidacion 'EXPONENCIAL'
                                        If Trim(stModoDeLiquidacion) = "Exponencial" Then
                                            deValorFactorA = (deValorFactorA * dePorcentajeDeIncremento)

                                            loValorPuntos = deValorFactorA * Exp(deValorFactorB * inPuntoConstruccion)

                                            Dim loValorConstruccionComunTotal As Long = (deAreaDeConstruccion * loValorPuntos)
                                            loValorConstruccionComun += (loValorConstruccionComunTotal * deFIPRCOED) / 100
                                        End If

                                        ' liquidacion 'LINEAL'
                                        If Trim(stModoDeLiquidacion) = "Lineal" Then
                                            deValorFactorA = (deValorFactorA * dePorcentajeDeIncremento)
                                            deValorFactorB = (deValorFactorB * dePorcentajeDeIncremento)

                                            loValorPuntos = (deValorFactorA + inPuntoConstruccion) * deValorFactorB

                                            Dim loValorConstruccionComunTotal As Long = (deAreaDeConstruccion * loValorPuntos)
                                            loValorConstruccionComun += (loValorConstruccionComunTotal * deFIPRCOED) / 100
                                        End If

                                    End If

                                End If
                            End If

                        Next

                    End If
                End If

                ' retorna el valor de la construccion
                Return loValorConstruccionComun

            End If

            ' ====================================
            ' *** CARACTERISTICA DE PREDIO "4" ***
            ' ====================================
            If dt_FICHPRED.Rows(0).Item("FIPRCAPR") = 4 Then

                ' declaro variables
                Dim deAreaDeConstruccionComun As Decimal = 0.0
                Dim loValorConstruccionComun As Long = 0
                Dim loValorConstruccionComunFR1 As Long = 0
                Dim loValorConstruccionComunFR2 As Long = 0

                Dim deFIPRCOED As Decimal = CType(dt_FICHPRED.Rows(0).Item("FIPRCOED"), Decimal)
                Dim deFIPRCOPR As Decimal = CType(dt_FICHPRED.Rows(0).Item("FIPRCOPR"), Decimal)
                Dim inFIPRTIFI_1 As Integer = 1
                Dim inFIPRTIFI_2 As Integer = 2
                Dim stFIPREDIF As String = "000"
                Dim stFIPRUNPR As String = "00000"

                '===============================================================
                ' *** LIQUIDA EL VALOR DE LAS CONSTRUCCIONES FICHA RESUMEN 1 ***
                '===============================================================
                ' instancia la clase
                Dim objdatos_FR1 As New cla_FICHRESU
                Dim tbl_FR1 As New DataTable

                tbl_FR1 = objdatos_FR1.fun_buscar_CEDULA_CATASTRAL_FICHRESU(Trim(dt_FICHPRED.Rows(0).Item("FIPRMUNI")), Trim(dt_FICHPRED.Rows(0).Item("FIPRCORR")), Trim(dt_FICHPRED.Rows(0).Item("FIPRBARR")), Trim(dt_FICHPRED.Rows(0).Item("FIPRMANZ")), Trim(dt_FICHPRED.Rows(0).Item("FIPRPRED")), Trim(stFIPREDIF), Trim(stFIPRUNPR), Trim(dt_FICHPRED.Rows(0).Item("FIPRCLSE")), inFIPRTIFI_1)

                If tbl_FR1.Rows.Count > 0 Then

                    ' declaro la variable
                    Dim inFIRENUFI As Integer = CType(tbl_FR1.Rows(0).Item("FIPRNUFI"), Integer)

                    ' instancia la clase
                    Dim objdatos_CONS_FR1 As New cla_FIPRCONS
                    Dim tbl_CONS_FR1 As New DataTable

                    tbl_CONS_FR1 = objdatos_CONS_FR1.fun_Consultar_FIPRCONS_X_FICHA_PREDIAL(inFIRENUFI)

                    ' verifica si existe construcciones
                    If tbl_CONS_FR1.Rows.Count > 0 Then

                        Dim i As Integer = 0

                        For i = 0 To tbl_CONS_FR1.Rows.Count - 1

                            If Trim(tbl_CONS_FR1.Rows(i).Item("FPCOESTA")) = "ac" Then
                                If tbl_CONS_FR1.Rows(i).Item("FPCOCLCO") = 1 Or tbl_CONS_FR1.Rows(i).Item("FPCOCLCO") = 2 Then

                                    ' declaro la variable 
                                    Dim stDepartamento As String = Trim(dt_FICHPRED.Rows(0).Item("FIPRDEPA"))
                                    Dim stMunicipio As String = Trim(dt_FICHPRED.Rows(0).Item("FIPRMUNI"))
                                    Dim inClaseSector As Integer = CType(dt_FICHPRED.Rows(0).Item("FIPRCLSE"), Integer)

                                    Dim stIdentificador As String = Trim(tbl_CONS_FR1.Rows(i).Item("FPCOTICO"))
                                    Dim inClaseConstruccion As Integer = CType(tbl_CONS_FR1.Rows(i).Item("FPCOCLCO"), Integer)
                                    Dim inPuntoConstruccion As Integer = CType(tbl_CONS_FR1.Rows(i).Item("FPCOPUNT"), Integer)
                                    Dim deAreaDeConstruccion As Decimal = CType(tbl_CONS_FR1.Rows(i).Item("FPCOARCO"), Decimal)

                                    Dim deValorFactorA As Decimal = 0.0
                                    Dim deValorFactorB As Decimal = 0.0
                                    Dim dePorcentajeDeIncremento As Decimal = 0.0

                                    Dim loValorPuntos As Long = 0

                                    ' instancia las clase
                                    Dim objdatos As New cla_TIPOCONS
                                    Dim tbl As New DataTable

                                    tbl = objdatos.fun_buscar_TICODEPA_X_TICOMUNI_X_TICOCLCO_X_TICOCLSE_X_TIPOCONS_X_CLASCONS_MANT_TIPOCONS(stDepartamento, stMunicipio, inClaseConstruccion, inClaseSector, stIdentificador)

                                    If tbl.Rows.Count > 0 Then

                                        ' almacena valor de los factores
                                        deValorFactorA = CType(tbl.Rows(0).Item("TICOFAC1"), Decimal)
                                        deValorFactorB = CType(tbl.Rows(0).Item("TICOFAC2"), Decimal)
                                        dePorcentajeDeIncremento = CType(tbl.Rows(0).Item("TICOPOIN"), Decimal)

                                        ' declara la variable
                                        Dim stModoDeLiquidacion As String = Trim(tbl.Rows(0).Item("TICOMOLI"))

                                        ' liquidacion 'NINGUNO'
                                        If Trim(stModoDeLiquidacion) = "Ninguno" Then
                                            loValorConstruccionComunFR1 = 0
                                        End If

                                        ' Liquidacion 'POTENCIAL'
                                        If Trim(stModoDeLiquidacion) = "Potencial" Then
                                            deValorFactorA = (deValorFactorA * dePorcentajeDeIncremento)

                                            loValorPuntos = deValorFactorA * Pow(inPuntoConstruccion, deValorFactorB)

                                            Dim loValorConstruccionComunTotal As Long = (deAreaDeConstruccion * loValorPuntos)
                                            loValorConstruccionComunFR1 += (loValorConstruccionComunTotal * deFIPRCOPR) / 100
                                        End If

                                        ' liquidacion 'EXPONENCIAL'
                                        If Trim(stModoDeLiquidacion) = "Exponencial" Then
                                            deValorFactorA = (deValorFactorA * dePorcentajeDeIncremento)

                                            loValorPuntos = deValorFactorA * Exp(deValorFactorB * inPuntoConstruccion)

                                            Dim loValorConstruccionComunTotal As Long = (deAreaDeConstruccion * loValorPuntos)
                                            loValorConstruccionComunFR1 += (loValorConstruccionComunTotal * deFIPRCOPR) / 100
                                        End If

                                        ' liquidacion 'LINEAL'
                                        If Trim(stModoDeLiquidacion) = "Lineal" Then
                                            deValorFactorA = (deValorFactorA * dePorcentajeDeIncremento)
                                            deValorFactorB = (deValorFactorB * dePorcentajeDeIncremento)

                                            loValorPuntos = (deValorFactorA + inPuntoConstruccion) * deValorFactorB

                                            Dim loValorConstruccionComunTotal As Long = (deAreaDeConstruccion * loValorPuntos)
                                            loValorConstruccionComunFR1 += (loValorConstruccionComunTotal * deFIPRCOPR) / 100
                                        End If

                                    End If

                                End If
                            End If

                        Next

                    End If
                End If

                '===============================================================
                ' *** LIQUIDA EL VALOR DE LAS CONSTRUCCIONES FICHA RESUMEN 2 ***
                '===============================================================
                ' instancia la clase
                Dim objdatos_FR2 As New cla_FICHRESU
                Dim tbl_FR2 As New DataTable

                tbl_FR2 = objdatos_FR2.fun_buscar_CEDULA_CATASTRAL_FICHRESU(Trim(dt_FICHPRED.Rows(0).Item("FIPRMUNI")), Trim(dt_FICHPRED.Rows(0).Item("FIPRCORR")), Trim(dt_FICHPRED.Rows(0).Item("FIPRBARR")), Trim(dt_FICHPRED.Rows(0).Item("FIPRMANZ")), Trim(dt_FICHPRED.Rows(0).Item("FIPRPRED")), Trim(dt_FICHPRED.Rows(0).Item("FIPREDIF")), Trim(stFIPRUNPR), Trim(dt_FICHPRED.Rows(0).Item("FIPRCLSE")), inFIPRTIFI_2)

                If tbl_FR2.Rows.Count > 0 Then

                    ' declaro la variable
                    Dim inFIRENUFI As Integer = CType(tbl_FR2.Rows(0).Item("FIPRNUFI"), Integer)

                    ' instancia la clase
                    Dim objdatos_CONS_FR2 As New cla_FIPRCONS
                    Dim tbl_CONS_FR2 As New DataTable

                    tbl_CONS_FR2 = objdatos_CONS_FR2.fun_Consultar_FIPRCONS_X_FICHA_PREDIAL(inFIRENUFI)

                    ' verifica si existe construcciones
                    If tbl_CONS_FR2.Rows.Count > 0 Then

                        Dim i As Integer = 0

                        For i = 0 To tbl_CONS_FR2.Rows.Count - 1

                            If Trim(tbl_CONS_FR2.Rows(i).Item("FPCOESTA")) = "ac" Then
                                If tbl_CONS_FR2.Rows(i).Item("FPCOCLCO") = 1 Or tbl_CONS_FR2.Rows(i).Item("FPCOCLCO") = 2 Then

                                    ' declaro la variable 
                                    Dim stDepartamento As String = Trim(dt_FICHPRED.Rows(0).Item("FIPRDEPA"))
                                    Dim stMunicipio As String = Trim(dt_FICHPRED.Rows(0).Item("FIPRMUNI"))
                                    Dim inClaseSector As Integer = CType(dt_FICHPRED.Rows(0).Item("FIPRCLSE"), Integer)

                                    Dim stIdentificador As String = Trim(tbl_CONS_FR2.Rows(i).Item("FPCOTICO"))
                                    Dim inClaseConstruccion As Integer = CType(tbl_CONS_FR2.Rows(i).Item("FPCOCLCO"), Integer)
                                    Dim inPuntoConstruccion As Integer = CType(tbl_CONS_FR2.Rows(i).Item("FPCOPUNT"), Integer)
                                    Dim deAreaDeConstruccion As Decimal = CType(tbl_CONS_FR2.Rows(i).Item("FPCOARCO"), Decimal)

                                    Dim deValorFactorA As Decimal = 0.0
                                    Dim deValorFactorB As Decimal = 0.0
                                    Dim dePorcentajeDeIncremento As Decimal = 0.0

                                    Dim loValorPuntos As Long = 0

                                    ' instancia las clase
                                    Dim objdatos As New cla_TIPOCONS
                                    Dim tbl As New DataTable

                                    tbl = objdatos.fun_buscar_TICODEPA_X_TICOMUNI_X_TICOCLCO_X_TICOCLSE_X_TIPOCONS_X_CLASCONS_MANT_TIPOCONS(stDepartamento, stMunicipio, inClaseConstruccion, inClaseSector, stIdentificador)

                                    If tbl.Rows.Count > 0 Then

                                        ' almacena valor de los factores
                                        deValorFactorA = CType(tbl.Rows(0).Item("TICOFAC1"), Decimal)
                                        deValorFactorB = CType(tbl.Rows(0).Item("TICOFAC2"), Decimal)
                                        dePorcentajeDeIncremento = CType(tbl.Rows(0).Item("TICOPOIN"), Decimal)

                                        ' declara la variable
                                        Dim stModoDeLiquidacion As String = Trim(tbl.Rows(0).Item("TICOMOLI"))

                                        ' liquidacion 'NINGUNO'
                                        If Trim(stModoDeLiquidacion) = "Ninguno" Then
                                            loValorConstruccionComunFR2 = 0
                                        End If

                                        ' Liquidacion 'POTENCIAL'
                                        If Trim(stModoDeLiquidacion) = "Potencial" Then
                                            deValorFactorA = (deValorFactorA * dePorcentajeDeIncremento)

                                            loValorPuntos = deValorFactorA * Pow(inPuntoConstruccion, deValorFactorB)

                                            Dim loValorConstruccionComunTotal As Long = (deAreaDeConstruccion * loValorPuntos)
                                            loValorConstruccionComunFR2 += (loValorConstruccionComunTotal * deFIPRCOED) / 100
                                        End If

                                        ' liquidacion 'EXPONENCIAL'
                                        If Trim(stModoDeLiquidacion) = "Exponencial" Then
                                            deValorFactorA = (deValorFactorA * dePorcentajeDeIncremento)

                                            loValorPuntos = deValorFactorA * Exp(deValorFactorB * inPuntoConstruccion)

                                            Dim loValorConstruccionComunTotal As Long = (deAreaDeConstruccion * loValorPuntos)
                                            loValorConstruccionComunFR2 += (loValorConstruccionComunTotal * deFIPRCOED) / 100
                                        End If

                                        ' liquidacion 'LINEAL'
                                        If Trim(stModoDeLiquidacion) = "Lineal" Then
                                            deValorFactorA = (deValorFactorA * dePorcentajeDeIncremento)
                                            deValorFactorB = (deValorFactorB * dePorcentajeDeIncremento)

                                            loValorPuntos = (deValorFactorA + inPuntoConstruccion) * deValorFactorB

                                            Dim loValorConstruccionComunTotal As Long = (deAreaDeConstruccion * loValorPuntos)
                                            loValorConstruccionComunFR2 += (loValorConstruccionComunTotal * deFIPRCOED) / 100
                                        End If

                                    End If

                                End If
                            End If

                        Next

                    End If
                End If

                loValorConstruccionComun = (loValorConstruccionComunFR1 + loValorConstruccionComunFR2)

                ' retorna el valor de la construccion comun
                Return loValorConstruccionComun

            End If


        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Function

    Private Function fun_ConsultarAvaluoTotal() As Long

        Try
            Dim loTotalAvaluo As Long = 0

            loTotalAvaluo = CType(vl_loFPAVVATP, Long) + CType(vl_loFPAVVATC, Long) + CType(vl_loFPAVVACP, Long) + CType(vl_loFPAVVACC, Long)

            Return loTotalAvaluo

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Function

#End Region

End Module
