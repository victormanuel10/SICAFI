Imports REGLAS_DEL_NEGOCIO
Imports System
Imports System.IO
Imports System.Data
Imports System.Data.Sqlclient
Imports System.Configuration
Imports System.Text

Module mod_fun_LIQUIDA_PREDIAL_FICHA_PREDIAL

    '=====================================
    '*** LIQUIDA PREDIAL FICHA PREDIAL ***
    '=====================================

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

    Private vl_inFIPRNUFI As Integer = 0
    Private vl_loPREDPRED As Long = 0
    Private vl_stFIPRDATR As String
    Private vl_stFIPRDAVI As String
    Private vl_stFIPRDAND As String

#End Region

#Region "Conexion"

    Private oEjecutar As New SqlCommand
    Private oConexion As New SqlConnection
    Private oAdapter As New SqlDataAdapter
    Private oReader As SqlDataReader
    Private ds As New DataSet
    Private dt As New DataTable

#End Region

#Region "Componentes Avaluo"

    Private vl_loFPAVPRED As Long = 0

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
        dt_FIPRDEEC = ds.Tables(1)
        ' Tabla 2
        dt_FIPRPROP = ds.Tables(2)
        ' Tabla 3
        dt_FIPRCONS = ds.Tables(3)
        ' Tabla 4
        dt_FIPRCACO = ds.Tables(4)
        ' Tabla 5
        dt_FIPRLIND = ds.Tables(5)
        ' Tabla 6
        dt_FIPRCART = ds.Tables(6)
        ' Tabla 7
        dt_FIPRZOEC = ds.Tables(7)
        ' Tabla 8
        dt_FIPRZOFI = ds.Tables(8)

    End Sub

#End Region

#Region "Liquida Avaluo Ficha Predial"

    Public Sub pro_LIQUIDA_PREDIAL_FICHA_PREDIAL(ByVal o_inFIPRNUFI As Integer, _
                                                 ByVal o_stTIPORESO As String, _
                                                 ByVal o_stVIGENCIA As String, _
                                                 ByVal o_stNUMEDOCU As String)

        Try
            ' declaro variables
            vl_inFIPRNUFI = o_inFIPRNUFI
            vl_stFIPRDATR = Trim(o_stTIPORESO)
            vl_stFIPRDAVI = Trim(o_stVIGENCIA)
            vl_stFIPRDAND = Trim(o_stNUMEDOCU)

            ' Elimina el avaluo catastral
            Dim objdatos As New cla_PREDIAL

            objdatos.fun_Eliminar_PREDIAL(Trim(o_inFIPRNUFI))

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

                        pro_LiquidaPredial()
                        pro_GuardarLiquidacionPredial()
                    End If

                End If
            End If


        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "Liquida Avaluo ficha predial")
        End Try

    End Sub

#End Region

#Region "Grabar Liquidacion Predial"

    Private Sub pro_GuardarLiquidacionPredial()

        Dim objdatos1 As New cla_PREDIAL

        Dim stESTADO As String = "ac"

        objdatos1.fun_Insertar_PREDIAL(vl_inFIPRNUFI, _
                                        vl_loPREDPRED, _
                                        vl_stFIPRDATR, _
                                        vl_stFIPRDAVI, _
                                        vl_stFIPRDAND, _
                                        stESTADO)
    End Sub

#End Region

#End Region

#Region "FUNCIONES"

    Private Sub pro_LiquidaPredial()

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
                Dim deTarifa As Decimal = 0.0
                Dim loAvaluoTotal As Long = 0
                Dim loLiquidacionPredial As Long = 0
                Dim boConstruccionesActivas As Boolean = False

                ' instancia la clase
                Dim objdatos23 As New cla_FIPRAVAL
                Dim tbl23 As New DataTable

                tbl23 = objdatos23.fun_Consultar_AVALUO_X_FICHA_PREDIAL(dt_FICHPRED.Rows(0).Item("FIPRNUFI"))

                ' almacena el avaluo catastral
                If tbl23.Rows.Count = 0 Then
                    loAvaluoTotal = 0
                Else
                    loAvaluoTotal = CType(tbl23.Rows(0).Item("FPAVAVAL"), Long)
                End If

                ' verifica construcciones activas
                If dt_FIPRCONS.Rows.Count = 0 Then
                    boConstruccionesActivas = False
                Else
                    Dim i As Integer = 0

                    For i = 0 To dt_FIPRCONS.Rows.Count - 1
                        If Trim(dt_FIPRCONS.Rows(i).Item("FPCOESTA")) = "ac" Then
                            If dt_FIPRCONS.Rows(i).Item("FPCOCLCO") = 1 Or dt_FIPRCONS.Rows(i).Item("FPCOCLCO") = 2 Or dt_FIPRCONS.Rows(i).Item("FPCOCLCO") = 3 Then
                                boConstruccionesActivas = True
                            End If
                        End If
                    Next

                End If

                '==================================
                ' *** NO EXISTEN CONSTRUCCIONES ***
                '==================================
                If dt_FIPRCONS.Rows.Count = 0 Or boConstruccionesActivas = False Then

                    ' verifica si tiene destinación económica
                    If dt_FIPRDEEC.Rows.Count = 0 Then
                        deTarifa = 0
                    Else
                        ' declaro la variable
                        Dim inDestinoEconomico As Integer = 0
                        Dim inPorcentajeEconomico As Integer = 0

                        Dim i As Integer = 0

                        For i = 0 To dt_FIPRDEEC.Rows.Count - 1

                            If Trim(dt_FIPRDEEC.Rows(i).Item("FPDEESTA")) = "ac" Then

                                If CType(dt_FIPRDEEC.Rows(i).Item("FPDEPORC"), Integer) > inPorcentajeEconomico Then
                                    inPorcentajeEconomico = CType(dt_FIPRDEEC.Rows(i).Item("FPDEPORC"), Integer)
                                    inDestinoEconomico = CType(dt_FIPRDEEC.Rows(i).Item("FPDEDEEC"), Integer)
                                End If

                            End If

                        Next

                        ' instancia la clase y busca la tarifa segun destino economico
                        Dim objdatos33 As New cla_TARIDEEC
                        Dim tbl33 As New DataTable

                        tbl33 = objdatos33.fun_Buscar_CODIGO_DEPA_MUNI_CLSE_VIGE_X_TARIDEEC(Trim(dt_FICHPRED.Rows(0).Item("FIPRDEPA")), Trim(dt_FICHPRED.Rows(0).Item("FIPRMUNI")), Trim(dt_FICHPRED.Rows(0).Item("FIPRCLSE")), Trim(dt_FICHPRED.Rows(0).Item("FIPRVIGE")))

                        Dim sw1 As Byte = 0
                        Dim j1 As Integer = 0
                        Dim boExiteDestino As Boolean = False

                        While j1 < tbl33.Rows.Count And sw1 = 0
                            If Trim(tbl33.Rows(j1).Item("TADEESTA")) = "ac" Then

                                If tbl33.Rows(j1).Item("TADEDEEC") = inDestinoEconomico Then
                                    deTarifa = CType(tbl33.Rows(j1).Item("TADETARI"), Decimal)
                                    boExiteDestino = True
                                    sw1 = 1
                                Else
                                    j1 = j1 + 1
                                End If
                            End If

                        End While

                        '=======================================================================
                        ' *** liquida predial si existe el destino establecido en el maestro *** 
                        '=======================================================================
                        If boExiteDestino = True Then
                            ' aplica liquidación segun tarifa
                            loLiquidacionPredial = (loAvaluoTotal * deTarifa) / 1000

                            ' almacena el valor liquidado
                            vl_loPREDPRED = loLiquidacionPredial

                        Else
                            '================================================================
                            ' *** liquida con la tarifa de la zona sin tener construcción ***
                            '================================================================

                            ' declaro la variable
                            Dim boZonasActivas As Boolean = False

                            ' verifica que existan zonas 
                            If dt_FIPRZOEC.Rows.Count = 0 Then
                                boZonasActivas = False
                            Else
                                Dim e As Integer = 0

                                For e = 0 To dt_FIPRZOEC.Rows.Count - 1
                                    If Trim(dt_FIPRZOEC.Rows(e).Item("FPZEESTA")) = "ac" Then
                                        boZonasActivas = True
                                    End If
                                Next

                            End If

                        End If

                    End If

            Else
                '===============================
                ' *** EXISTEN CONSTRUCCIONES ***
                '===============================
                ' declaro las variables
                Dim deAreaDeConstruccionPrivado As Decimal = 0.0
                Dim inPutosConstruccion As Integer = 0
                Dim inUnidadConstruccion As Integer = 0
                Dim stTipologiaConstruccion As String = ""
                Dim stIdentificador As String = ""
                Dim inClaseConstruccion As Integer = 0

                ' verifica que existan construcciones
                If dt_FIPRCONS.Rows.Count > 0 Then

                    Dim i As Integer = 0

                    ' recorro las construcciones
                    For i = 0 To dt_FIPRCONS.Rows.Count - 1

                        If Trim(dt_FIPRCONS.Rows(i).Item("FPCOESTA")) = "ac" Then
                            If dt_FIPRCONS.Rows(i).Item("FPCOCLCO") = 1 Or dt_FIPRCONS.Rows(i).Item("FPCOCLCO") = 2 Or dt_FIPRCONS.Rows(i).Item("FPCOCLCO") = 3 Then

                                If CType(dt_FIPRCONS.Rows(i).Item("FPCOARCO"), Decimal) > deAreaDeConstruccionPrivado Then
                                    deAreaDeConstruccionPrivado = CType(dt_FIPRCONS.Rows(i).Item("FPCOARCO"), Decimal)
                                    inPutosConstruccion = CType(dt_FIPRCONS.Rows(i).Item("FPCOPUNT"), Decimal)
                                    inUnidadConstruccion = CType(dt_FIPRCONS.Rows(i).Item("FPCOUNID"), Integer)
                                    stIdentificador = Trim(CType(dt_FIPRCONS.Rows(i).Item("FPCOTICO"), String))
                                    inClaseConstruccion = CType(dt_FIPRCONS.Rows(i).Item("FPCOCLCO"), Integer)
                                End If

                            End If
                        End If

                    Next
                End If

                ' declaro la variable
                Dim boZonasActivas As Boolean = False

                ' verifica que existan zonas 
                If dt_FIPRZOEC.Rows.Count = 0 Then
                    boZonasActivas = False
                Else
                    If dt_FIPRZOEC.Rows.Count = 0 Then
                        boZonasActivas = False
                    Else
                        Dim i As Integer = 0

                        For i = 0 To dt_FIPRZOEC.Rows.Count - 1
                            If Trim(dt_FIPRZOEC.Rows(i).Item("FPZEESTA")) = "ac" Then
                                boZonasActivas = True
                            End If
                        Next

                    End If
                End If

                ' buaca la tarifa segun zona 
                If boConstruccionesActivas = True And boZonasActivas = True Then

                    Dim k As Integer = 0

                    ' recorro las zonas
                    For k = 0 To dt_FIPRZOEC.Rows.Count - 1

                        If Trim(dt_FIPRZOEC.Rows(k).Item("FPZEESTA")) = "ac" Then

                            ' declaro las variables
                            Dim inZonaEconomica As Integer = CType(dt_FIPRZOEC.Rows(k).Item("FPZEZOEC"), Integer)
                            Dim inPorcentajeZona As Integer = CType(dt_FIPRZOEC.Rows(k).Item("FPZEPORC"), Integer)

                            ' instancia la clase
                            Dim objdatos55 As New cla_TARIZOEC
                            Dim tbl55 As New DataTable

                                tbl55 = objdatos55.fun_Buscar_CODIGO_DEPA_MUNI_CLSE_VIGE_ZOEC_X_TARIZOEC(Trim(dt_FICHPRED.Rows(0).Item("FIPRDEPA")), Trim(dt_FICHPRED.Rows(0).Item("FIPRMUNI")), Trim(dt_FICHPRED.Rows(0).Item("FIPRCLSE")), Trim(dt_FICHPRED.Rows(0).Item("FIPRVIGE")), inZonaEconomica)

                            ' verifica si existen registros
                            If tbl55.Rows.Count = 0 Then
                                deTarifa = 0
                            Else
                                ' declaro la variable con la zona aplicada
                                Dim inZonaAplicada As Integer = 0

                                ' busca la tipologia del identificador
                                Dim objdatos15 As New cla_TIPOCONS
                                Dim tbl15 As New DataTable

                                tbl15 = objdatos15.fun_buscar_TICODEPA_X_TICOMUNI_X_TICOCLCO_X_TICOCLSE_X_TIPOCONS_X_CLASCONS_MANT_TIPOCONS(Trim(dt_FICHPRED.Rows(0).Item("FIPRDEPA")), Trim(dt_FICHPRED.Rows(0).Item("FIPRMUNI")), inClaseConstruccion, Trim(dt_FICHPRED.Rows(0).Item("FIPRCLSE")), stIdentificador)

                                If tbl15.Rows.Count = 0 Then
                                    inZonaAplicada = CType(tbl55.Rows(0).Item("TAZEZOAP"), Integer)
                                Else
                                    Dim stFPCOTIPO As String = Trim(tbl15.Rows(0).Item("TICOTIPO"))

                                    If Trim(stFPCOTIPO) = "R" Then
                                        inZonaAplicada = CType(tbl55.Rows(0).Item("TAZEZOAP"), Integer)
                                    Else
                                        inZonaAplicada = CType(tbl55.Rows(0).Item("TAZEZOEC"), Integer)
                                    End If

                                    ' instancia la clase
                                    Dim objdatos56 As New cla_TARIZOEC
                                    Dim tbl56 As New DataTable

                                        tbl56 = objdatos56.fun_Buscar_CODIGO_DEPA_MUNI_CLSE_VIGE_ZOEC_X_TARIZOEC(Trim(dt_FICHPRED.Rows(0).Item("FIPRDEPA")), Trim(dt_FICHPRED.Rows(0).Item("FIPRMUNI")), Trim(dt_FICHPRED.Rows(0).Item("FIPRCLSE")), Trim(dt_FICHPRED.Rows(0).Item("FIPRVIGE")), inZonaAplicada)

                                    ' verifica si existen registros
                                    If tbl56.Rows.Count = 0 Then
                                        deTarifa = 0
                                    Else
                                        If inPutosConstruccion >= 0 And inPutosConstruccion <= 10 Then
                                            deTarifa = CType(tbl56.Rows(0).Item("TAZETA01"), Decimal)
                                        End If

                                        If inPutosConstruccion >= 11 And inPutosConstruccion <= 28 Then
                                            deTarifa = CType(tbl56.Rows(0).Item("TAZETA02"), Decimal)
                                        End If

                                        If inPutosConstruccion >= 29 And inPutosConstruccion <= 46 Then
                                            deTarifa = CType(tbl56.Rows(0).Item("TAZETA03"), Decimal)
                                        End If

                                        If inPutosConstruccion >= 47 And inPutosConstruccion <= 64 Then
                                            deTarifa = CType(tbl56.Rows(0).Item("TAZETA04"), Decimal)
                                        End If

                                        If inPutosConstruccion >= 65 And inPutosConstruccion <= 84 Then
                                            deTarifa = CType(tbl56.Rows(0).Item("TAZETA05"), Decimal)
                                        End If

                                        If inPutosConstruccion >= 85 And inPutosConstruccion <= 110 Then
                                            deTarifa = CType(tbl56.Rows(0).Item("TAZETA06"), Decimal)
                                        End If

                                        ' liquida predial segun la tarifa de la zona correspondiente con su porcentaje
                                        Dim loAvaluoParcial As Long = (loAvaluoTotal * inPorcentajeZona) / 100
                                        loLiquidacionPredial += (loAvaluoParcial * deTarifa) / 1000

                                    End If
                                End If
                            End If
                        End If

                    Next

                End If

                ' liquidación total del predial
                vl_loPREDPRED = loLiquidacionPredial

            End If
            Else
                ' valor en cero no aplica en ninguna caracteristica de predio
                vl_loPREDPRED = 0
            End If


        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub

#End Region


End Module
