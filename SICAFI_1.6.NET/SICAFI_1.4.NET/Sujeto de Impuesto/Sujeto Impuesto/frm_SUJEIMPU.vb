Imports REGLAS_DEL_NEGOCIO

Public Class frm_SUJEIMPU

    '==========================
    '*** SUJETO DE IMPUESTO ***
    '==========================

#Region "VARIABLES"

    Dim boCONSULTA As Boolean = False
    Dim dt_SUJEIMPU As New DataTable

#End Region

#Region "CONSTRUCTOR"

    Public Sub New(ByVal idCodigo As Integer)

        vp_inConsulta = idCodigo
        InitializeComponent()

    End Sub

#End Region

#Region "INSTANCIAR FORMULARIO"

    Private Shared frm_Instance = Nothing

    Public Shared Function instance() As frm_SUJEIMPU
        If frm_Instance Is Nothing OrElse frm_Instance.isdisposed = True Then
            frm_Instance = New frm_SUJEIMPU
        End If

        frm_Instance.bringtofront()

        Return frm_Instance

    End Function

    Private Sub New()
        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()
        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
    End Sub

#End Region

#Region "PROCEDIMIENTOS SUJETO DE IMPUESTO"

    Private Sub pro_ReconsultarSujetoDeImpuesto()

        Try
            Dim objdatos As New cla_SUJEIMPU

            If boCONSULTA = False Then
                Me.BindingSource_SUJEIMPU_1.DataSource = objdatos.fun_Buscar_NUFI_X_CONSULTA_PARAMETRIZADA_SUJEIMPU(vp_inConsulta)
            Else
                Me.BindingSource_SUJEIMPU_1.DataSource = objdatos.fun_Buscar_NUFI_X_CONSULTA_PARAMETRIZADA_SUJEIMPU(vp_inConsulta)
            End If

            Me.BindingNavigator_SUIMSUIM_1.BindingSource = BindingSource_SUJEIMPU_1

            dt_SUJEIMPU = New DataTable
            dt_SUJEIMPU = Me.BindingSource_SUJEIMPU_1.DataSource

            '==================================================
            '*** CONFIGURA OBJETOS DEL FORMULARIO MAESTRO ***
            '==================================================

            Me.strBARRESTA.Items(2).Text = "Registros : " & Me.BindingSource_SUJEIMPU_1.Count

            Me.txtFIPRNUFI.Text = CStr(Trim(dt_SUJEIMPU.Rows(0).Item("SUIMNUFI").ToString))
            Me.txtFIPRMUNI.Text = CStr(Trim(dt_SUJEIMPU.Rows(0).Item("SUIMMUNI").ToString))
            Me.txtFIPRCORR.Text = CStr(Trim(dt_SUJEIMPU.Rows(0).Item("SUIMCORR").ToString))
            Me.txtFIPRBARR.Text = CStr(Trim(dt_SUJEIMPU.Rows(0).Item("SUIMBARR").ToString))
            Me.txtFIPRMANZ.Text = CStr(Trim(dt_SUJEIMPU.Rows(0).Item("SUIMMANZ").ToString))
            Me.txtFIPRPRED.Text = CStr(Trim(dt_SUJEIMPU.Rows(0).Item("SUIMPRED").ToString))
            Me.txtFIPREDIF.Text = CStr(Trim(dt_SUJEIMPU.Rows(0).Item("SUIMEDIF").ToString))
            Me.txtFIPRUNPR.Text = CStr(Trim(dt_SUJEIMPU.Rows(0).Item("SUIMUNPR").ToString))
            Me.txtFIPRCLSE.Text = CStr(Trim(dt_SUJEIMPU.Rows(0).Item("SUIMCLSE").ToString))

            Me.txtSUIMNUFI.Text = CStr(Trim(dt_SUJEIMPU.Rows(0).Item("SUIMNUFI").ToString))

            Me.txtSUIMCOMU.Text = CStr(Trim(dt_SUJEIMPU.Rows(0).Item("SUIMCOMU").ToString))
            Me.txtSUIMDEPA.Text = CStr(Trim(dt_SUJEIMPU.Rows(0).Item("SUIMDEPA").ToString))
            Me.txtSUIMMUNI.Text = CStr(Trim(dt_SUJEIMPU.Rows(0).Item("SUIMMUNI").ToString))
            Me.txtSUIMCORR.Text = CStr(Trim(dt_SUJEIMPU.Rows(0).Item("SUIMCORR").ToString))
            Me.txtSUIMBARR.Text = CStr(Trim(dt_SUJEIMPU.Rows(0).Item("SUIMBARR").ToString))
            Me.txtSUIMMANZ.Text = CStr(Trim(dt_SUJEIMPU.Rows(0).Item("SUIMMANZ").ToString))
            Me.txtSUIMPRED.Text = CStr(Trim(dt_SUJEIMPU.Rows(0).Item("SUIMPRED").ToString))
            Me.txtSUIMEDIF.Text = CStr(Trim(dt_SUJEIMPU.Rows(0).Item("SUIMEDIF").ToString))
            Me.txtSUIMUNPR.Text = CStr(Trim(dt_SUJEIMPU.Rows(0).Item("SUIMUNPR").ToString))
            Me.txtSUIMCLSE.Text = CStr(Trim(dt_SUJEIMPU.Rows(0).Item("SUIMCLSE").ToString))

            Me.txtSUIMCOMA.Text = CStr(Trim(dt_SUJEIMPU.Rows(0).Item("SUIMCOMA").ToString))
            Me.txtSUIMDEAN.Text = CStr(Trim(dt_SUJEIMPU.Rows(0).Item("SUIMDEAN").ToString))
            Me.txtSUIMMUAN.Text = CStr(Trim(dt_SUJEIMPU.Rows(0).Item("SUIMMUAN").ToString))
            Me.txtSUIMCOAN.Text = CStr(Trim(dt_SUJEIMPU.Rows(0).Item("SUIMCOAN").ToString))
            Me.txtSUIMBAAN.Text = CStr(Trim(dt_SUJEIMPU.Rows(0).Item("SUIMBAAN").ToString))
            Me.txtSUIMMAAN.Text = CStr(Trim(dt_SUJEIMPU.Rows(0).Item("SUIMMAAN").ToString))
            Me.txtSUIMPRAN.Text = CStr(Trim(dt_SUJEIMPU.Rows(0).Item("SUIMPRAN").ToString))
            Me.txtSUIMEDAN.Text = CStr(Trim(dt_SUJEIMPU.Rows(0).Item("SUIMEDAN").ToString))
            Me.txtSUIMUPAN.Text = CStr(Trim(dt_SUJEIMPU.Rows(0).Item("SUIMUPAN").ToString))
            Me.txtSUIMCSAN.Text = CStr(Trim(dt_SUJEIMPU.Rows(0).Item("SUIMCSAN").ToString))

            Me.txtSUIMDESC.Text = CStr(Trim(dt_SUJEIMPU.Rows(0).Item("SUIMDESC").ToString))
            Me.txtSUIMDIRE.Text = CStr(Trim(dt_SUJEIMPU.Rows(0).Item("SUIMDIRE").ToString))
            Me.txtSUIMSUAC.Text = CStr(Trim(dt_SUJEIMPU.Rows(0).Item("SUIMSUAC").ToString))
            Me.txtSUIMSUAN.Text = CStr(Trim(dt_SUJEIMPU.Rows(0).Item("SUIMSUAN").ToString))
            Me.txtSUIMCAPR.Text = CStr(Trim(dt_SUJEIMPU.Rows(0).Item("SUIMCAPR").ToString))
            Me.txtSUIMMOAD.Text = CStr(Trim(dt_SUJEIMPU.Rows(0).Item("SUIMMOAD").ToString))
            Me.txtSUIMVIAC.Text = CStr(Trim(dt_SUJEIMPU.Rows(0).Item("SUIMVIAC").ToString))
            Me.txtSUIMVIAN.Text = CStr(Trim(dt_SUJEIMPU.Rows(0).Item("SUIMVIAN").ToString))
            Me.txtSUIMMAIN.Text = CStr(Trim(dt_SUJEIMPU.Rows(0).Item("SUIMMAIN").ToString))
            Me.txtSUIMESTA.Text = CStr(Trim(dt_SUJEIMPU.Rows(0).Item("SUIMESTA").ToString))

            Me.txtSUIMNI01.Text = CStr(Trim(dt_SUJEIMPU.Rows(0).Item("SUIMNI01").ToString))
            Me.txtSUIMNI02.Text = CStr(Trim(dt_SUJEIMPU.Rows(0).Item("SUIMNI02").ToString))
            Me.txtSUIMNI03.Text = CStr(Trim(dt_SUJEIMPU.Rows(0).Item("SUIMNI03").ToString))
            Me.txtSUIMNI04.Text = CStr(Trim(dt_SUJEIMPU.Rows(0).Item("SUIMNI04").ToString))
            Me.txtSUIMNI05.Text = CStr(Trim(dt_SUJEIMPU.Rows(0).Item("SUIMNI05").ToString))
            Me.txtSUIMNI06.Text = CStr(Trim(dt_SUJEIMPU.Rows(0).Item("SUIMNI06").ToString))
            Me.txtSUIMNI07.Text = CStr(Trim(dt_SUJEIMPU.Rows(0).Item("SUIMNI07").ToString))
            Me.txtSUIMNI08.Text = CStr(Trim(dt_SUJEIMPU.Rows(0).Item("SUIMNI08").ToString))
            Me.txtSUIMNI09.Text = CStr(Trim(dt_SUJEIMPU.Rows(0).Item("SUIMNI09").ToString))
            Me.txtSUIMNI10.Text = CStr(Trim(dt_SUJEIMPU.Rows(0).Item("SUIMNI10").ToString))
            Me.txtSUIMNI11.Text = CStr(Trim(dt_SUJEIMPU.Rows(0).Item("SUIMNI11").ToString))
            Me.txtSUIMNI12.Text = CStr(Trim(dt_SUJEIMPU.Rows(0).Item("SUIMNI12").ToString))
            Me.txtSUIMNI13.Text = CStr(Trim(dt_SUJEIMPU.Rows(0).Item("SUIMNI13").ToString))
            Me.txtSUIMNI14.Text = CStr(Trim(dt_SUJEIMPU.Rows(0).Item("SUIMNI14").ToString))
            Me.txtSUIMNI15.Text = CStr(Trim(dt_SUJEIMPU.Rows(0).Item("SUIMNI15").ToString))
            Me.txtSUIMNI16.Text = CStr(Trim(dt_SUJEIMPU.Rows(0).Item("SUIMNI16").ToString))
            Me.txtSUIMNI17.Text = CStr(Trim(dt_SUJEIMPU.Rows(0).Item("SUIMNI17").ToString))
            Me.txtSUIMNI18.Text = CStr(Trim(dt_SUJEIMPU.Rows(0).Item("SUIMNI18").ToString))
            Me.txtSUIMNI19.Text = CStr(Trim(dt_SUJEIMPU.Rows(0).Item("SUIMNI19").ToString))
            Me.txtSUIMNI20.Text = CStr(Trim(dt_SUJEIMPU.Rows(0).Item("SUIMNI20").ToString))
            Me.txtSUIMNI21.Text = CStr(Trim(dt_SUJEIMPU.Rows(0).Item("SUIMNI21").ToString))
            Me.txtSUIMNI22.Text = CStr(Trim(dt_SUJEIMPU.Rows(0).Item("SUIMNI22").ToString))
            Me.txtSUIMNI23.Text = CStr(Trim(dt_SUJEIMPU.Rows(0).Item("SUIMNI23").ToString))
            Me.txtSUIMNI24.Text = CStr(Trim(dt_SUJEIMPU.Rows(0).Item("SUIMNI24").ToString))
            Me.txtSUIMNI25.Text = CStr(Trim(dt_SUJEIMPU.Rows(0).Item("SUIMNI25").ToString))
            Me.txtSUIMNI26.Text = CStr(Trim(dt_SUJEIMPU.Rows(0).Item("SUIMNI26").ToString))
            Me.txtSUIMNI27.Text = CStr(Trim(dt_SUJEIMPU.Rows(0).Item("SUIMNI27").ToString))
            Me.txtSUIMNI28.Text = CStr(Trim(dt_SUJEIMPU.Rows(0).Item("SUIMNI28").ToString))
            Me.txtSUIMNI29.Text = CStr(Trim(dt_SUJEIMPU.Rows(0).Item("SUIMNI29").ToString))
            Me.txtSUIMNI30.Text = CStr(Trim(dt_SUJEIMPU.Rows(0).Item("SUIMNI30").ToString))

            Me.chkSUIMPRNU.Checked = CBool(dt_SUJEIMPU.Rows(0).Item("SUIMPRNU"))
            Me.chkSUIMPRCA.Checked = CBool(dt_SUJEIMPU.Rows(0).Item("SUIMPRCA"))
            Me.chkSUIMMANU.Checked = CBool(dt_SUJEIMPU.Rows(0).Item("SUIMMANU"))
            Me.chkSUIMMACA.Checked = CBool(dt_SUJEIMPU.Rows(0).Item("SUIMMACA"))
            Me.chkSUIMMEJO.Checked = CBool(dt_SUJEIMPU.Rows(0).Item("SUIMMEJO"))
            Me.chkSUIMPRRE.Checked = CBool(dt_SUJEIMPU.Rows(0).Item("SUIMPRRE"))

            '==================================================
            '*** ASIGNA LOS PRIVILEGIOS DE LA BARRA DE MENU ***
            '==================================================

            If Me.BindingSource_SUJEIMPU_1.Count > 0 Then
                Me.BindingNavigator_SUIMSUIM_1.Enabled = True
            End If

            Dim boCONTAGRE As Boolean = False
            Dim boCONTMODI As Boolean = False
            Dim boCONTELIM As Boolean = False
            Dim boCONTCONS As Boolean = False
            Dim boCONTRECO As Boolean = False

            pro_Permiso_Barra_De_Menu_Formulario_Formulario(Me.BindingSource_SUJEIMPU_1.Count, Trim(Me.Name), boCONTAGRE, boCONTMODI, boCONTELIM, boCONTCONS, boCONTRECO)

            Me.cmdAGREGAR_SUIMSUIM.Enabled = boCONTAGRE
            Me.cmdMODIFICAR_SUIMSUIM.Enabled = boCONTMODI
            Me.cmdELIMINAR_SUIMSUIM.Enabled = boCONTELIM
            Me.cmdCONSULTAR_SUIMSUIM.Enabled = boCONTCONS
            Me.cmdRECONSULTAR_SUIMSUIM.Enabled = boCONTRECO

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub pro_ListaDeValoresSujetoDeImpuesto()

        Try
            If Me.BindingSource_SUJEIMPU_1.Count > 0 Then

                Me.lblFIPRCLSE.Text = CType(fun_Buscar_Lista_Valores_CLASSECT(Trim(Me.txtFIPRCLSE.Text)), String)
                Me.lblSUIMCLSE.Text = CType(fun_Buscar_Lista_Valores_CLASSECT(Trim(Me.txtSUIMCLSE.Text)), String)
                Me.lblSUIMCSAN.Text = CType(fun_Buscar_Lista_Valores_CLASSECT(Trim(Me.txtSUIMCSAN.Text)), String)
                Me.lblSUIMCAPR.Text = CType(fun_Buscar_Lista_Valores_CARAPRED(Trim(Me.txtSUIMCAPR.Text)), String)
                Me.lblSUIMMOAD.Text = CType(fun_Buscar_Lista_Valores_MODOADQU(Trim(Me.txtSUIMMOAD.Text)), String)
                Me.lblSUIMVIAC.Text = CType(fun_Buscar_Lista_Valores_VIGENCIA(Trim(Me.txtSUIMVIAC.Text)), String)
                Me.lblSUIMVIAN.Text = CType(fun_Buscar_Lista_Valores_VIGENCIA(Trim(Me.txtSUIMVIAN.Text)), String)
                Me.lblSUIMESTA.Text = CType(fun_Buscar_Lista_Valores_ESTADO(Trim(Me.txtSUIMESTA.Text)), String)

                pro_ReconsultarHistoricoDeAvaluos()
                pro_ListaDeValoresHistoricoDeAvaluos()

                pro_ReconsultarHistoricoDeLiquidacion()
                pro_ListaDeValoresHistoricoDeLiquidacion()

                pro_ReconsultarAforoDeImpuesto()
                pro_ListaDeValoresAforoDeImpuesto()

                pro_ReconsultarPropietarioSujetoDeImpuesto()
                pro_ListaDeValoresPropietarioSujetoDeImpuesto()

                pro_ReconsultarEstadoDeCuenta()
                pro_ListaDeValoresEstadoDeCuenta()

                pro_ReconsultarSaldoPorConcepto()
                pro_ListaDeValoresSaldoPorConcepto()

                pro_ReconsultarMovimientoDetallado()
                pro_ListaDeValoresMovimientoDetallado()

            Else
                pro_LimpiarCamposSujetoDeImpueto()
                pro_LimpiarCamposHistoricoDeAvaluos()
                pro_LimpiarCamposHistoricoDeLiquidacion()
                pro_LimpiarCamposAforoDeImpuestos()
                pro_LimpiarCamposPropietarioSujetoDeImpuesto()
                pro_LimpiarCamposEstadoDeCuenta()
                pro_LimpiarCamposSaldoPorConcepto()
                pro_LimpiarCamposMovimientoDetallado()

                Me.BindingNavigator_HISTAVAL_1.Enabled = False
                Me.BindingNavigator_HISTLIQU_1.Enabled = False
                Me.BindingNavigator_AFORSUIM_1.Enabled = False
                Me.BindingNavigator_PROPSUIM_1.Enabled = False
                Me.BindingNavigator_ESTACUEN_1.Enabled = False
                Me.BindingNavigator_SALDCONC_1.Enabled = False
                Me.BindingNavigator_MOVIDETA_1.Enabled = False

                Me.tabSUIMSUIM.Focus()

            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub pro_LimpiarCamposSujetoDeImpueto()

        Me.txtSUIMNUFI.Text = ""
        Me.txtSUIMSUAC.Text = ""
        Me.txtSUIMSUAN.Text = ""
        Me.txtSUIMDEPA.Text = ""
        Me.txtSUIMMUNI.Text = ""
        Me.txtSUIMCORR.Text = ""
        Me.txtSUIMBARR.Text = ""
        Me.txtSUIMMANZ.Text = ""
        Me.txtSUIMPRED.Text = ""
        Me.txtSUIMEDIF.Text = ""
        Me.txtSUIMUNPR.Text = ""
        Me.txtSUIMCLSE.Text = ""

        Me.txtSUIMDEAN.Text = ""
        Me.txtSUIMMUAN.Text = ""
        Me.txtSUIMCOAN.Text = ""
        Me.txtSUIMBAAN.Text = ""
        Me.txtSUIMMAAN.Text = ""
        Me.txtSUIMPRAN.Text = ""
        Me.txtSUIMEDAN.Text = ""
        Me.txtSUIMUPAN.Text = ""
        Me.txtSUIMCSAN.Text = ""

        Me.txtSUIMMOAD.Text = ""
        Me.txtSUIMCOMU.Text = ""
        Me.txtSUIMCOMA.Text = ""

        Me.txtSUIMCAPR.Text = ""
        Me.txtSUIMDIRE.Text = ""
        Me.txtSUIMDESC.Text = ""
        Me.txtSUIMVIAC.Text = ""
        Me.txtSUIMVIAN.Text = ""
        Me.txtSUIMMAIN.Text = ""
        Me.txtSUIMESTA.Text = ""
        Me.chkSUIMPRNU.Checked = False
        Me.chkSUIMPRCA.Checked = False
        Me.chkSUIMMANU.Checked = False
        Me.chkSUIMMACA.Checked = False
        Me.txtSUIMNI01.Text = ""
        Me.txtSUIMNI02.Text = ""
        Me.txtSUIMNI03.Text = ""
        Me.txtSUIMNI04.Text = ""
        Me.txtSUIMNI05.Text = ""
        Me.txtSUIMNI06.Text = ""
        Me.txtSUIMNI07.Text = ""
        Me.txtSUIMNI08.Text = ""
        Me.txtSUIMNI09.Text = ""
        Me.txtSUIMNI10.Text = ""
        Me.txtSUIMNI11.Text = ""
        Me.txtSUIMNI12.Text = ""
        Me.txtSUIMNI13.Text = ""
        Me.txtSUIMNI14.Text = ""
        Me.txtSUIMNI15.Text = ""
        Me.txtSUIMNI16.Text = ""
        Me.txtSUIMNI17.Text = ""
        Me.txtSUIMNI18.Text = ""
        Me.txtSUIMNI19.Text = ""
        Me.txtSUIMNI20.Text = ""
        Me.txtSUIMNI21.Text = ""
        Me.txtSUIMNI22.Text = ""
        Me.txtSUIMNI23.Text = ""
        Me.txtSUIMNI24.Text = ""
        Me.txtSUIMNI25.Text = ""
        Me.txtSUIMNI26.Text = ""
        Me.txtSUIMNI27.Text = ""
        Me.txtSUIMNI28.Text = ""
        Me.txtSUIMNI29.Text = ""
        Me.txtSUIMNI30.Text = ""

        Me.lblSUIMCLSE.Text = ""
        Me.lblSUIMCSAN.Text = ""
        Me.lblSUIMVIAC.Text = ""
        Me.lblSUIMVIAN.Text = ""
        Me.lblSUIMCAPR.Text = ""
        Me.lblSUIMMOAD.Text = ""
        Me.lblSUIMESTA.Text = ""
        Me.chkSUIMMEJO.Checked = False
        Me.chkSUIMPRRE.Checked = False

        Me.txtFIPRNUFI.Text = ""
        Me.txtFIPRMUNI.Text = ""
        Me.txtFIPRCORR.Text = ""
        Me.txtFIPRBARR.Text = ""
        Me.txtFIPRMANZ.Text = ""
        Me.txtFIPRPRED.Text = ""
        Me.txtFIPREDIF.Text = ""
        Me.txtFIPRUNPR.Text = ""
        Me.lblFIPRCLSE.Text = ""

        Me.txtFIPRCLSE.Text = ""

        Me.txtHIAVUSIN.Text = ""
        Me.txtHIAVUSMO.Text = ""
        Me.txtHIAVFEIN.Text = ""
        Me.txtHIAVFEMO.Text = ""
        Me.txtHIAVMAQU.Text = ""
        Me.txtHIAVFECH.Text = ""

        Me.txtHILIUSIN.Text = ""
        Me.txtHILIUSMO.Text = ""
        Me.txtHILIFEIN.Text = ""
        Me.txtHILIFEMO.Text = ""
        Me.txtHILIMAQU.Text = ""
        Me.txtHILIFECH.Text = ""

        Me.txtAFSIUSIN.Text = ""
        Me.txtAFSIUSMO.Text = ""
        Me.txtAFSIFEIN.Text = ""
        Me.txtAFSIFEMO.Text = ""
        Me.txtAFSIMAQU.Text = ""
        Me.txtAFSIFECH.Text = ""

        Me.txtPRSIUSIN.Text = ""
        Me.txtPRSIUSMO.Text = ""
        Me.txtPRSIFEIN.Text = ""
        Me.txtPRSIFEMO.Text = ""
        Me.txtPRSIMAQU.Text = ""
        Me.txtPRSIFECH.Text = ""

        Me.txtHIAVINTO.Text = "0"
        Me.txtHIAVINTP.Text = "0"
        Me.txtHIAVINTC.Text = "0"
        Me.txtHIAVINCP.Text = "0"
        Me.txtHIAVINCC.Text = "0"

        Me.strBARRESTA.Items(2).Text = "Registros : 0"

    End Sub

#End Region

#Region "PROCEDIMIENTOS HISTORICO DE AVALUOS"

    Private Sub pro_ReconsultarHistoricoDeAvaluos()

        Try
            Dim objdatos As New cla_HISTAVAL

            If boCONSULTA = False Then
                Me.BindingSource_HISTAVAL_1.DataSource = objdatos.fun_Buscar_NUFI_X_CONSULTA_PARAMETRIZADA_HISTAVAL(vp_inConsulta)
            Else
                Me.BindingSource_HISTAVAL_1.DataSource = objdatos.fun_Buscar_NUFI_X_CONSULTA_PARAMETRIZADA_HISTAVAL(vp_inConsulta)
            End If

            Me.dgvHISTAVAL_1.DataSource = BindingSource_HISTAVAL_1
            Me.dgvHISTAVAL_2.DataSource = BindingSource_HISTAVAL_1
            Me.BindingNavigator_HISTAVAL_1.BindingSource = BindingSource_HISTAVAL_1

            '================================================
            '*** CONFIGURA OBJETOS DEL FORMULARIO MAESTRO ***
            '================================================

            Me.strBARRESTA.Items(2).Text = "Registros : " & Me.BindingSource_HISTAVAL_1.Count

            Me.dgvHISTAVAL_1.Columns("HIAVIDRE").HeaderText = "idre"

            Me.dgvHISTAVAL_1.Columns("HIAVNUFI").HeaderText = "Nro. Ficha"
            Me.dgvHISTAVAL_1.Columns("HIAVVIGE").HeaderText = "Vigencia"
            Me.dgvHISTAVAL_1.Columns("HIAVATPR").HeaderText = "Area Terreno Privada mt2"
            Me.dgvHISTAVAL_1.Columns("HIAVATCO").HeaderText = "Area Terreno Común mt2"
            Me.dgvHISTAVAL_1.Columns("HIAVACPR").HeaderText = "Area Cons. Privada mt2"
            Me.dgvHISTAVAL_1.Columns("HIAVACCO").HeaderText = "Area Cons. Común mt2"
            Me.dgvHISTAVAL_2.Columns("HIAVVATP").HeaderText = "Valor Terreno Privado"
            Me.dgvHISTAVAL_2.Columns("HIAVVATC").HeaderText = "Valor Terreno Común"
            Me.dgvHISTAVAL_2.Columns("HIAVVACP").HeaderText = "Valor Cons. Privada"
            Me.dgvHISTAVAL_2.Columns("HIAVVACC").HeaderText = "Valor Cons. Común"
            Me.dgvHISTAVAL_2.Columns("HIAVAVAL").HeaderText = "Avalúo Catastral"
            Me.dgvHISTAVAL_1.Columns("HIAVOBSE").HeaderText = "Observación"
            Me.dgvHISTAVAL_1.Columns("HIAVTIRE").HeaderText = "Tipo Resolución"
            Me.dgvHISTAVAL_1.Columns("HIAVNURE").HeaderText = "Nro. Resolución"
            Me.dgvHISTAVAL_1.Columns("HIAVVIRE").HeaderText = "Vigencia Resolución"
            Me.dgvHISTAVAL_2.Columns("HIAVESTA").HeaderText = "Estado"

            Me.dgvHISTAVAL_1.Columns("HIAVIDRE").Visible = False
            Me.dgvHISTAVAL_1.Columns("HIAVNUFI").Visible = False
            Me.dgvHISTAVAL_1.Columns("HIAVVATP").Visible = False
            Me.dgvHISTAVAL_1.Columns("HIAVVATC").Visible = False
            Me.dgvHISTAVAL_1.Columns("HIAVVACP").Visible = False
            Me.dgvHISTAVAL_1.Columns("HIAVVACC").Visible = False
            Me.dgvHISTAVAL_1.Columns("HIAVAVAL").Visible = False
            Me.dgvHISTAVAL_1.Columns("HIAVOBSE").Visible = False
            Me.dgvHISTAVAL_1.Columns("HIAVTIRE").Visible = False
            Me.dgvHISTAVAL_1.Columns("HIAVNURE").Visible = False
            Me.dgvHISTAVAL_1.Columns("HIAVVIRE").Visible = False
            Me.dgvHISTAVAL_1.Columns("HIAVESTA").Visible = False

            Me.dgvHISTAVAL_1.Columns("HIAVUSIN").Visible = False
            Me.dgvHISTAVAL_1.Columns("HIAVUSMO").Visible = False
            Me.dgvHISTAVAL_1.Columns("HIAVFEIN").Visible = False
            Me.dgvHISTAVAL_1.Columns("HIAVFEMO").Visible = False
            Me.dgvHISTAVAL_1.Columns("HIAVMAQU").Visible = False

            Me.dgvHISTAVAL_2.Columns("HIAVIDRE").Visible = False
            Me.dgvHISTAVAL_2.Columns("HIAVVIGE").Visible = False
            Me.dgvHISTAVAL_2.Columns("HIAVNUFI").Visible = False
            Me.dgvHISTAVAL_2.Columns("HIAVATPR").Visible = False
            Me.dgvHISTAVAL_2.Columns("HIAVATCO").Visible = False
            Me.dgvHISTAVAL_2.Columns("HIAVACPR").Visible = False
            Me.dgvHISTAVAL_2.Columns("HIAVACCO").Visible = False
            Me.dgvHISTAVAL_2.Columns("HIAVOBSE").Visible = False
            Me.dgvHISTAVAL_2.Columns("HIAVTIRE").Visible = False
            Me.dgvHISTAVAL_2.Columns("HIAVNURE").Visible = False
            Me.dgvHISTAVAL_2.Columns("HIAVVIRE").Visible = False
            Me.dgvHISTAVAL_2.Columns("HIAVESTA").Visible = False

            Me.dgvHISTAVAL_2.Columns("HIAVUSIN").Visible = False
            Me.dgvHISTAVAL_2.Columns("HIAVUSMO").Visible = False
            Me.dgvHISTAVAL_2.Columns("HIAVFEIN").Visible = False
            Me.dgvHISTAVAL_2.Columns("HIAVFEMO").Visible = False
            Me.dgvHISTAVAL_2.Columns("HIAVMAQU").Visible = False

            Me.dgvHISTAVAL_2.Columns("HIAVVATP").DefaultCellStyle.Format = "c"
            Me.dgvHISTAVAL_2.Columns("HIAVVATC").DefaultCellStyle.Format = "c"
            Me.dgvHISTAVAL_2.Columns("HIAVVACP").DefaultCellStyle.Format = "c"
            Me.dgvHISTAVAL_2.Columns("HIAVVACC").DefaultCellStyle.Format = "c"
            Me.dgvHISTAVAL_2.Columns("HIAVAVAL").DefaultCellStyle.Format = "c"

            Me.dgvHISTAVAL_1.Columns("HIAVATPR").DefaultCellStyle.Format = "n"
            Me.dgvHISTAVAL_1.Columns("HIAVATCO").DefaultCellStyle.Format = "n"
            Me.dgvHISTAVAL_1.Columns("HIAVACPR").DefaultCellStyle.Format = "n"
            Me.dgvHISTAVAL_1.Columns("HIAVACCO").DefaultCellStyle.Format = "n"

            '==================================================
            '*** ASIGNA LOS PRIVILEGIOS DE LA BARRA DE MENU ***
            '==================================================

            If Me.BindingSource_HISTAVAL_1.Count > 0 Then
                Me.BindingNavigator_HISTAVAL_1.Enabled = True
            End If

            Dim boCONTAGRE As Boolean = False
            Dim boCONTMODI As Boolean = False
            Dim boCONTELIM As Boolean = False
            Dim boCONTCONS As Boolean = False
            Dim boCONTRECO As Boolean = False

            pro_Permiso_Barra_De_Menu_Formulario_Formulario(Me.BindingSource_HISTAVAL_1.Count, Trim(Me.Name), boCONTAGRE, boCONTMODI, boCONTELIM, boCONTCONS, boCONTRECO)

            Me.cmdAGREGAR_HISTAVAL.Enabled = boCONTAGRE
            Me.cmdMODIFICAR_HISTAVAL.Enabled = boCONTMODI
            Me.cmdELIMINAR_HISTAVAL.Enabled = boCONTELIM
            Me.cmdCONSULTAR_HISTAVAL.Enabled = boCONTCONS
            Me.cmdRECONSULTAR_HISTAVAL.Enabled = boCONTRECO

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub pro_ListaDeValoresHistoricoDeAvaluos()

        Try
            If Me.dgvHISTAVAL_1.RowCount > 0 And Me.dgvHISTAVAL_2.RowCount > 0 Then

                Me.txtHIAVTIRE.Text = Trim(Me.dgvHISTAVAL_1.SelectedRows.Item(0).Cells("HIAVTIRE").Value.ToString)
                Me.txtHIAVNURE.Text = Trim(Me.dgvHISTAVAL_1.SelectedRows.Item(0).Cells("HIAVNURE").Value.ToString)
                Me.txtHIAVVIGE.Text = Trim(Me.dgvHISTAVAL_1.SelectedRows.Item(0).Cells("HIAVVIGE").Value.ToString)
                Me.txtHIAVOBSE.Text = Trim(Me.dgvHISTAVAL_1.SelectedRows.Item(0).Cells("HIAVOBSE").Value.ToString)

                Me.txtHIAVUSIN.Text = Trim(Me.dgvHISTAVAL_1.SelectedRows.Item(0).Cells("HIAVUSIN").Value.ToString)
                Me.txtHIAVUSMO.Text = Trim(Me.dgvHISTAVAL_1.SelectedRows.Item(0).Cells("HIAVUSMO").Value.ToString)
                Me.txtHIAVFEIN.Text = Trim(Me.dgvHISTAVAL_1.SelectedRows.Item(0).Cells("HIAVFEIN").Value.ToString.Substring(0, 10))
                Me.txtHIAVFEMO.Text = Trim(Me.dgvHISTAVAL_1.SelectedRows.Item(0).Cells("HIAVFEMO").Value.ToString.Substring(0, 10))
                Me.txtHIAVMAQU.Text = Trim(Me.dgvHISTAVAL_1.SelectedRows.Item(0).Cells("HIAVMAQU").Value.ToString)

                Me.lblHIAVTIRE.Text = CType(fun_Buscar_Lista_Valores_TIPORESO(Me.dgvHISTAVAL_1.SelectedRows.Item(0).Cells("HIAVTIRE").Value.ToString), String)
                Me.lblHIAVVIGE.Text = CType(fun_Buscar_Lista_Valores_VIGENCIA(Me.dgvHISTAVAL_1.SelectedRows.Item(0).Cells("HIAVVIGE").Value.ToString), String)

                If Trim(Me.txtHIAVUSMO.Text) = "" Then
                    Me.txtHIAVFEMO.Text = ""
                End If

            Else
                pro_LimpiarCamposHistoricoDeAvaluos()
            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub pro_LimpiarCamposHistoricoDeAvaluos()

        Me.dgvHISTAVAL_1.DataSource = New DataTable
        Me.dgvHISTAVAL_2.DataSource = New DataTable

        Me.txtHIAVTIRE.Text = ""
        Me.txtHIAVVIGE.Text = ""
        Me.txtHIAVOBSE.Text = ""
        Me.txtHIAVNURE.Text = ""
        Me.lblHIAVTIRE.Text = ""
        Me.lblHIAVVIGE.Text = ""

        Me.txtHIAVUSIN.Text = ""
        Me.txtHIAVUSMO.Text = ""
        Me.txtHIAVFEIN.Text = ""
        Me.txtHIAVFEMO.Text = ""
        Me.txtHIAVMAQU.Text = ""
        Me.txtHIAVFECH.Text = ""

        Me.txtHIAVINTO.Text = ""
        Me.txtHIAVINTP.Text = ""
        Me.txtHIAVINCP.Text = ""
        Me.txtHIAVINTC.Text = ""
        Me.txtHIAVINCC.Text = ""

        Me.txtHIAVVMTE.Text = "0"
        Me.txtHIAVVMCO.Text = "0"

    End Sub
    Private Sub pro_IncrementoAvaluo()

        Try
            Dim I, SW As Byte

            While I < Me.dgvHISTAVAL_1.RowCount And SW = 0
                If Me.dgvHISTAVAL_1.CurrentRow.Cells(I).Selected Then

                    Dim inVigenciaActual As Integer = CInt(Me.dgvHISTAVAL_2.CurrentRow.Cells("HIAVVIGE").Value.ToString())
                    Dim loAvaluoTotalActual As Long = CLng(Me.dgvHISTAVAL_2.CurrentRow.Cells("HIAVAVAL").Value.ToString())
                    Dim loAvaluoTerrenoPrivadoActual As Long = CLng(Me.dgvHISTAVAL_2.CurrentRow.Cells("HIAVVATP").Value.ToString())
                    Dim loAvaluoConstruccionPrivadoActual As Long = CLng(Me.dgvHISTAVAL_2.CurrentRow.Cells("HIAVVACP").Value.ToString())
                    Dim loAvaluoTerrenoComunActual As Long = CLng(Me.dgvHISTAVAL_2.CurrentRow.Cells("HIAVVATC").Value.ToString())
                    Dim loAvaluoConstruccionComunActual As Long = CLng(Me.dgvHISTAVAL_2.CurrentRow.Cells("HIAVVACC").Value.ToString())

                    Dim inAreaTerrenoPrivado As Integer = CInt(Me.dgvHISTAVAL_2.CurrentRow.Cells("HIAVATPR").Value.ToString())
                    Dim inAreaConstruccionPrivado As Integer = CInt(Me.dgvHISTAVAL_2.CurrentRow.Cells("HIAVACPR").Value.ToString())
                    Dim inAreaTerrenoComun As Integer = CInt(Me.dgvHISTAVAL_2.CurrentRow.Cells("HIAVATCO").Value.ToString())
                    Dim inAreaConstruccionComun As Integer = CInt(Me.dgvHISTAVAL_2.CurrentRow.Cells("HIAVACCO").Value.ToString())

                    Dim inAreaTerreno As Integer = inAreaTerrenoPrivado + inAreaTerrenoComun
                    Dim inAreaConstruccion As Integer = inAreaConstruccionPrivado + inAreaConstruccionComun

                    Dim inNroFicha As Integer = CInt(Me.dgvHISTAVAL_1.CurrentRow.Cells("HIAVNUFI").Value.ToString())

                    ' instancia la clase
                    Dim obHISTAVAL As New cla_HISTAVAL
                    Dim dtHISTAVAL As New DataTable

                    dtHISTAVAL = obHISTAVAL.fun_Buscar_CODIGO_NUFI_VIGE_X_HISTAVAL(inNroFicha, inVigenciaActual - 1)

                    ' verifica los registros
                    If dtHISTAVAL.Rows.Count > 0 Then

                        Dim loAvaluoTotalAnterior As Long = CLng(dtHISTAVAL.Rows(0).Item("HIAVAVAL"))
                        Dim loAvaluoTerrenoPrivadoAnterior As Long = CLng(dtHISTAVAL.Rows(0).Item("HIAVVATP"))
                        Dim loAvaluoConstruccionPrivadoAnterior As Long = CLng(dtHISTAVAL.Rows(0).Item("HIAVVACP"))
                        Dim loAvaluoTerrenoComunAnterior As Integer = CLng(dtHISTAVAL.Rows(0).Item("HIAVVATC"))
                        Dim loAvaluoConstruccionComunAnterior As Long = CLng(dtHISTAVAL.Rows(0).Item("HIAVVACC"))

                        If loAvaluoTotalAnterior <> 0 Then
                            Me.txtHIAVINTO.Text = fun_Formato_Decimal_2_Decimales((((CLng(loAvaluoTotalActual) * 100) / loAvaluoTotalAnterior) - 100))
                        Else
                            Me.txtHIAVINTO.Text = "0"
                        End If

                        If loAvaluoTerrenoPrivadoAnterior <> 0 Then
                            Me.txtHIAVINTP.Text = fun_Formato_Decimal_2_Decimales((((CLng(loAvaluoTerrenoPrivadoActual) * 100) / loAvaluoTerrenoPrivadoAnterior) - 100))
                        Else
                            Me.txtHIAVINTP.Text = "0"
                        End If

                        If loAvaluoConstruccionPrivadoAnterior <> 0 Then
                            Me.txtHIAVINTC.Text = fun_Formato_Decimal_2_Decimales((((CLng(loAvaluoTerrenoComunActual) * 100) / loAvaluoTerrenoComunAnterior) - 100))
                        Else
                            Me.txtHIAVINCP.Text = "0"
                        End If

                        If loAvaluoTerrenoComunAnterior <> 0 Then
                            Me.txtHIAVINCP.Text = fun_Formato_Decimal_2_Decimales((((CLng(loAvaluoConstruccionPrivadoActual) * 100) / loAvaluoConstruccionPrivadoAnterior) - 100))
                        Else
                            Me.txtHIAVINTC.Text = "0"
                        End If

                        If loAvaluoConstruccionComunAnterior <> 0 Then
                            Me.txtHIAVINCC.Text = fun_Formato_Decimal_2_Decimales((((CLng(loAvaluoConstruccionComunActual) * 100) / loAvaluoConstruccionComunAnterior) - 100))
                        Else
                            Me.txtHIAVINCC.Text = "0"
                        End If

                        If inAreaTerreno <> 0 Then
                            Me.txtHIAVVMTE.Text = fun_Formato_Mascara_Pesos((loAvaluoTerrenoPrivadoActual + loAvaluoTerrenoComunActual) / inAreaTerreno)
                        Else
                            Me.txtHIAVVMTE.Text = "0"
                        End If

                        If inAreaConstruccion <> 0 Then
                            Me.txtHIAVVMCO.Text = fun_Formato_Mascara_Pesos((loAvaluoConstruccionPrivadoActual + loAvaluoConstruccionComunActual) / inAreaConstruccion)
                        Else
                            Me.txtHIAVVMCO.Text = "0"
                        End If

                    Else
                        Me.txtHIAVINTO.Text = "0"
                        Me.txtHIAVINTP.Text = "0"
                        Me.txtHIAVINTC.Text = "0"
                        Me.txtHIAVINCP.Text = "0"
                        Me.txtHIAVINCC.Text = "0"
                        Me.txtHIAVVMTE.Text = "0"
                        Me.txtHIAVVMCO.Text = "0"
                    End If

                    SW = 1
                Else
                    I = I + 1
                End If

            End While

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub

#End Region

#Region "PROCEDIMIENTOS HISTORICO DE LIQUIDACIÓN"

    Private Sub pro_ReconsultarHistoricoDeLiquidacion()

        Try
            Dim objdatos As New cla_HISTLIQU

            If boCONSULTA = False Then
                Me.BindingSource_HISTLIQU_1.DataSource = objdatos.fun_Buscar_NUFI_X_CONSULTA_PARAMETRIZADA_HISTLIQU(vp_inConsulta)
            Else
                Me.BindingSource_HISTLIQU_1.DataSource = objdatos.fun_Buscar_NUFI_X_CONSULTA_PARAMETRIZADA_HISTLIQU(vp_inConsulta)
            End If

            Me.dgvHISTLIQU_1.DataSource = BindingSource_HISTLIQU_1
            Me.dgvHISTLIQU_2.DataSource = BindingSource_HISTLIQU_1
            Me.BindingNavigator_HISTLIQU_1.BindingSource = BindingSource_HISTLIQU_1

            '================================================
            '*** CONFIGURA OBJETOS DEL FORMULARIO MAESTRO ***
            '================================================

            Me.strBARRESTA.Items(2).Text = "Registros : " & Me.BindingSource_HISTLIQU_1.Count

            Me.dgvHISTLIQU_1.Columns("HILIIDRE").HeaderText = "idre"
            Me.dgvHISTLIQU_1.Columns("HILINUFI").HeaderText = "Nro. Ficha"
            Me.dgvHISTLIQU_1.Columns("HILICECA").HeaderText = "Cedula Catastral"
            Me.dgvHISTLIQU_1.Columns("HILIVIGE").HeaderText = "Vigencia"
            Me.dgvHISTLIQU_1.Columns("HILIAVPR").HeaderText = "Avalúo Predial"
            Me.dgvHISTLIQU_1.Columns("HILIAVCA").HeaderText = "Avalúo Catastral"
            Me.dgvHISTLIQU_1.Columns("HILIDEEC").HeaderText = "Destinación Económica"
            Me.dgvHISTLIQU_1.Columns("HILIESTR").HeaderText = "Estrato"
            Me.dgvHISTLIQU_1.Columns("HILILOTE").HeaderText = "Lote"
            Me.dgvHISTLIQU_1.Columns("HILILOCE").HeaderText = "Lote Cercado"
            Me.dgvHISTLIQU_2.Columns("HILILE44").HeaderText = "Ley 44"
            Me.dgvHISTLIQU_2.Columns("HILILE56").HeaderText = "Ley 56"
            Me.dgvHISTLIQU_2.Columns("HILIAUAV").HeaderText = "Autoavalúo"
            Me.dgvHISTLIQU_2.Columns("HILITIPO").HeaderText = "Tipo"
            Me.dgvHISTLIQU_2.Columns("HILIARCO").HeaderText = "Area Construcción mt2"
            Me.dgvHISTLIQU_2.Columns("HILIARTE").HeaderText = "Area Terreno mt2"
            Me.dgvHISTLIQU_2.Columns("HILIPUNT").HeaderText = "Puntos"
            Me.dgvHISTLIQU_2.Columns("HILIESTA").HeaderText = "Estado"

            Me.dgvHISTLIQU_1.Columns("HILIIDRE").Visible = False
            Me.dgvHISTLIQU_1.Columns("HILICECA").Visible = False
            Me.dgvHISTLIQU_1.Columns("HILINUFI").Visible = False
            Me.dgvHISTLIQU_1.Columns("HILILE44").Visible = False
            Me.dgvHISTLIQU_1.Columns("HILILE56").Visible = False
            Me.dgvHISTLIQU_1.Columns("HILIAUAV").Visible = False
            Me.dgvHISTLIQU_1.Columns("HILITIPO").Visible = False
            Me.dgvHISTLIQU_1.Columns("HILIARCO").Visible = False
            Me.dgvHISTLIQU_1.Columns("HILIARTE").Visible = False
            Me.dgvHISTLIQU_1.Columns("HILIPUNT").Visible = False
            Me.dgvHISTLIQU_1.Columns("HILIESTA").Visible = False

            Me.dgvHISTLIQU_1.Columns("HILIUSIN").Visible = False
            Me.dgvHISTLIQU_1.Columns("HILIUSMO").Visible = False
            Me.dgvHISTLIQU_1.Columns("HILIFEIN").Visible = False
            Me.dgvHISTLIQU_1.Columns("HILIFEMO").Visible = False
            Me.dgvHISTLIQU_1.Columns("HILIMAQU").Visible = False

            Me.dgvHISTLIQU_2.Columns("HILIIDRE").Visible = False
            Me.dgvHISTLIQU_2.Columns("HILINUFI").Visible = False
            Me.dgvHISTLIQU_2.Columns("HILICECA").Visible = False
            Me.dgvHISTLIQU_2.Columns("HILIVIGE").Visible = False
            Me.dgvHISTLIQU_2.Columns("HILIAVPR").Visible = False
            Me.dgvHISTLIQU_2.Columns("HILIAVCA").Visible = False
            Me.dgvHISTLIQU_2.Columns("HILIDEEC").Visible = False
            Me.dgvHISTLIQU_2.Columns("HILIESTR").Visible = False
            Me.dgvHISTLIQU_2.Columns("HILILOTE").Visible = False
            Me.dgvHISTLIQU_2.Columns("HILILOCE").Visible = False
            Me.dgvHISTLIQU_2.Columns("HILIESTA").Visible = False

            Me.dgvHISTLIQU_2.Columns("HILIUSIN").Visible = False
            Me.dgvHISTLIQU_2.Columns("HILIUSMO").Visible = False
            Me.dgvHISTLIQU_2.Columns("HILIFEIN").Visible = False
            Me.dgvHISTLIQU_2.Columns("HILIFEMO").Visible = False
            Me.dgvHISTLIQU_2.Columns("HILIMAQU").Visible = False

            Me.dgvHISTLIQU_1.Columns("HILIAVPR").DefaultCellStyle.Format = "c"
            Me.dgvHISTLIQU_1.Columns("HILIAVCA").DefaultCellStyle.Format = "c"

            Me.dgvHISTLIQU_2.Columns("HILIARCO").DefaultCellStyle.Format = "n"
            Me.dgvHISTLIQU_2.Columns("HILIARTE").DefaultCellStyle.Format = "n"

            Me.dgvHISTLIQU_2.Columns("HILIARCO").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            Me.dgvHISTLIQU_2.Columns("HILIARTE").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft

            '==================================================
            '*** ASIGNA LOS PRIVILEGIOS DE LA BARRA DE MENU ***
            '==================================================

            If Me.BindingSource_HISTLIQU_1.Count > 0 Then
                Me.BindingNavigator_HISTLIQU_1.Enabled = True
            End If

            Dim boCONTAGRE As Boolean = False
            Dim boCONTMODI As Boolean = False
            Dim boCONTELIM As Boolean = False
            Dim boCONTCONS As Boolean = False
            Dim boCONTRECO As Boolean = False

            pro_Permiso_Barra_De_Menu_Formulario_Formulario(Me.BindingSource_HISTLIQU_1.Count, Trim(Me.Name), boCONTAGRE, boCONTMODI, boCONTELIM, boCONTCONS, boCONTRECO)

            Me.cmdAGREGAR_HISTLIQU.Enabled = boCONTAGRE
            Me.cmdMODIFICAR_HISTLIQU.Enabled = boCONTMODI
            Me.cmdELIMINAR_HISTLIQU.Enabled = boCONTELIM
            Me.cmdCONSULTAR_HISTLIQU.Enabled = boCONTCONS
            Me.cmdRECONSULTAR_HISTLIQU.Enabled = boCONTRECO

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub pro_ListaDeValoresHistoricoDeLiquidacion()

        Try
            If Me.dgvHISTLIQU_1.RowCount > 0 And Me.dgvHISTLIQU_2.RowCount > 0 Then

                Me.txtHILIDEEC.Text = Trim(Me.dgvHISTLIQU_1.SelectedRows.Item(0).Cells("HILIDEEC").Value.ToString)
                Me.txtHILIESTR.Text = Trim(Me.dgvHISTLIQU_1.SelectedRows.Item(0).Cells("HILIESTR").Value.ToString)
                Me.txtHILIVIGE.Text = Trim(Me.dgvHISTLIQU_1.SelectedRows.Item(0).Cells("HILIVIGE").Value.ToString)
                Me.txtHILITIPO.Text = Trim(Me.dgvHISTLIQU_2.SelectedRows.Item(0).Cells("HILITIPO").Value.ToString)
                Me.txtHILIUSIN.Text = Trim(Me.dgvHISTLIQU_1.SelectedRows.Item(0).Cells("HILIUSIN").Value.ToString)
                Me.txtHILIUSMO.Text = Trim(Me.dgvHISTLIQU_1.SelectedRows.Item(0).Cells("HILIUSMO").Value.ToString)
                Me.txtHILIFEIN.Text = Trim(Me.dgvHISTLIQU_1.SelectedRows.Item(0).Cells("HILIFEIN").Value.ToString.Substring(0, 10))
                Me.txtHILIFEMO.Text = Trim(Me.dgvHISTLIQU_1.SelectedRows.Item(0).Cells("HILIFEMO").Value.ToString.Substring(0, 10))
                Me.txtHILIMAQU.Text = Trim(Me.dgvHISTLIQU_1.SelectedRows.Item(0).Cells("HILIMAQU").Value.ToString)

                Me.lblHILIDEEC.Text = CType(fun_Buscar_Lista_Valores_DESTECON(Me.dgvHISTLIQU_1.SelectedRows.Item(0).Cells("HILIDEEC").Value.ToString), String)
                Me.lblHILIESTR.Text = CType(fun_Buscar_Lista_Valores_ESTRATO(Me.dgvHISTLIQU_1.SelectedRows.Item(0).Cells("HILIESTR").Value.ToString), String)
                Me.lblHILIVIGE.Text = CType(fun_Buscar_Lista_Valores_VIGENCIA(Me.dgvHISTLIQU_1.SelectedRows.Item(0).Cells("HILIVIGE").Value.ToString), String)
                Me.lblHILITIPO.Text = CType(fun_Buscar_Lista_Valores_TIPOCALI(Me.dgvHISTLIQU_2.SelectedRows.Item(0).Cells("HILITIPO").Value.ToString), String)

                If Trim(Me.txtHILIUSMO.Text) = "" Then
                    Me.txtHILIFEMO.Text = ""
                End If

            Else
                pro_LimpiarCamposHistoricoDeLiquidacion()
            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub pro_LimpiarCamposHistoricoDeLiquidacion()

        Me.dgvHISTLIQU_1.DataSource = New DataTable
        Me.dgvHISTLIQU_1.DataSource = New DataTable

        Me.lblHILIDEEC.Text = ""
        Me.lblHILIESTR.Text = ""
        Me.lblHILITIPO.Text = ""
        Me.lblHILIVIGE.Text = ""

        Me.txtHILIDEEC.Text = ""
        Me.txtHILIESTR.Text = ""
        Me.txtHILITIPO.Text = ""
        Me.txtHILIVIGE.Text = ""

        Me.txtHILIUSIN.Text = ""
        Me.txtHILIUSMO.Text = ""
        Me.txtHILIFEIN.Text = ""
        Me.txtHILIFEMO.Text = ""
        Me.txtHILIMAQU.Text = ""
        Me.txtHILIFECH.Text = ""

    End Sub

#End Region

#Region "PROCEDIMIENTOS AFORO DE IMPUESTO"

    Private Sub pro_ReconsultarAforoDeImpuesto()

        Try
            Dim objdatos As New cla_AFORSUIM

            If boCONSULTA = False Then
                Me.BindingSource_AFORSUIM_1.DataSource = objdatos.fun_Buscar_NUFI_X_CONSULTA_PARAMETRIZADA_AFORSUIM(vp_inConsulta)
            Else
                Me.BindingSource_AFORSUIM_1.DataSource = objdatos.fun_Buscar_NUFI_X_CONSULTA_PARAMETRIZADA_AFORSUIM(vp_inConsulta)
            End If

            Me.dgvAFORSUIM.DataSource = BindingSource_AFORSUIM_1
            Me.BindingNavigator_AFORSUIM_1.BindingSource = BindingSource_AFORSUIM_1

            '================================================
            '*** CONFIGURA OBJETOS DEL FORMULARIO MAESTRO ***
            '================================================

            Me.strBARRESTA.Items(2).Text = "Registros : " & Me.BindingSource_AFORSUIM_1.Count

            Me.dgvAFORSUIM.Columns("AFSIIDRE").HeaderText = "Idre"
            Me.dgvAFORSUIM.Columns("AFSINUFI").HeaderText = "Nro. Ficha"
            Me.dgvAFORSUIM.Columns("AFSITIIM").HeaderText = "Tipo de Impuesto"
            Me.dgvAFORSUIM.Columns("AFSICONC").HeaderText = "Concepto"
            Me.dgvAFORSUIM.Columns("AFSIVABA").HeaderText = "Avalúo Catastral"
            Me.dgvAFORSUIM.Columns("AFSIVIGE").HeaderText = "Vigencia"
            Me.dgvAFORSUIM.Columns("AFSICLSE").HeaderText = "Sector"
            Me.dgvAFORSUIM.Columns("AFSIVALI").HeaderText = "Valor Impuesto (Liquidado)"
            Me.dgvAFORSUIM.Columns("AFSIVAIM").HeaderText = "Valor Impuesto (Avaluo x Tarifa)"
            Me.dgvAFORSUIM.Columns("AFSIZO01").HeaderText = "Zona 1"
            Me.dgvAFORSUIM.Columns("AFSIZO02").HeaderText = "Zona 2"
            Me.dgvAFORSUIM.Columns("AFSIZO03").HeaderText = "Zona 3"
            Me.dgvAFORSUIM.Columns("AFSIZO04").HeaderText = "Zona 4"
            Me.dgvAFORSUIM.Columns("AFSIZO05").HeaderText = "Zona 5"
            Me.dgvAFORSUIM.Columns("AFSIZO06").HeaderText = "Zona 6"
            Me.dgvAFORSUIM.Columns("AFSIZO07").HeaderText = "Zona 7"
            Me.dgvAFORSUIM.Columns("AFSITA01").HeaderText = "Tarifa 1"
            Me.dgvAFORSUIM.Columns("AFSITA02").HeaderText = "Tarifa 2"
            Me.dgvAFORSUIM.Columns("AFSITA03").HeaderText = "Tarifa 3"
            Me.dgvAFORSUIM.Columns("AFSITA04").HeaderText = "Tarifa 4"
            Me.dgvAFORSUIM.Columns("AFSITA05").HeaderText = "Tarifa 5"
            Me.dgvAFORSUIM.Columns("AFSITA06").HeaderText = "Tarifa 6"
            Me.dgvAFORSUIM.Columns("AFSITA07").HeaderText = "Tarifa 7"
            Me.dgvAFORSUIM.Columns("AFSIMOLI").HeaderText = "Modo de Liquidacion"
            Me.dgvAFORSUIM.Columns("AFSITIAF").HeaderText = "Tipo de Aforo"
            Me.dgvAFORSUIM.Columns("AFSIEXEN").HeaderText = "Exento"
            Me.dgvAFORSUIM.Columns("AFSIFEAF").HeaderText = "Fecha de Aforo"
            Me.dgvAFORSUIM.Columns("AFSIESTA").HeaderText = "Estado"
            Me.dgvAFORSUIM.Columns("AFSIUSIN").HeaderText = "Usuario Ingresa"
            Me.dgvAFORSUIM.Columns("AFSIUSMO").HeaderText = "Usuario Modifica"
            Me.dgvAFORSUIM.Columns("AFSIFEIN").HeaderText = "Fecha Ingreso"
            Me.dgvAFORSUIM.Columns("AFSIFEMO").HeaderText = "Fecha Modifica"
            Me.dgvAFORSUIM.Columns("AFSIMAQU").HeaderText = "Maquina"

            Me.dgvAFORSUIM.Columns("AFSIIDRE").Visible = False
            Me.dgvAFORSUIM.Columns("AFSINUFI").Visible = False
            Me.dgvAFORSUIM.Columns("AFSITIIM").Visible = False
            Me.dgvAFORSUIM.Columns("AFSICLSE").Visible = False
            Me.dgvAFORSUIM.Columns("AFSIZO01").Visible = False
            Me.dgvAFORSUIM.Columns("AFSIZO02").Visible = False
            Me.dgvAFORSUIM.Columns("AFSIZO03").Visible = False
            Me.dgvAFORSUIM.Columns("AFSIZO04").Visible = False
            Me.dgvAFORSUIM.Columns("AFSIZO05").Visible = False
            Me.dgvAFORSUIM.Columns("AFSIZO06").Visible = False
            Me.dgvAFORSUIM.Columns("AFSIZO07").Visible = False
            Me.dgvAFORSUIM.Columns("AFSITA01").Visible = False
            Me.dgvAFORSUIM.Columns("AFSITA02").Visible = False
            Me.dgvAFORSUIM.Columns("AFSITA03").Visible = False
            Me.dgvAFORSUIM.Columns("AFSITA04").Visible = False
            Me.dgvAFORSUIM.Columns("AFSITA05").Visible = False
            Me.dgvAFORSUIM.Columns("AFSITA06").Visible = False
            Me.dgvAFORSUIM.Columns("AFSITA07").Visible = False
            Me.dgvAFORSUIM.Columns("AFSIMOLI").Visible = False
            Me.dgvAFORSUIM.Columns("AFSITIAF").Visible = False
            Me.dgvAFORSUIM.Columns("AFSIFEAF").Visible = False
            Me.dgvAFORSUIM.Columns("AFSIESTA").Visible = False

            Me.dgvAFORSUIM.Columns("AFSIUSIN").Visible = False
            Me.dgvAFORSUIM.Columns("AFSIUSMO").Visible = False
            Me.dgvAFORSUIM.Columns("AFSIFEIN").Visible = False
            Me.dgvAFORSUIM.Columns("AFSIFEMO").Visible = False
            Me.dgvAFORSUIM.Columns("AFSIMAQU").Visible = False

            Me.dgvAFORSUIM.Columns("AFSIVABA").DefaultCellStyle.Format = "c"
            Me.dgvAFORSUIM.Columns("AFSIVALI").DefaultCellStyle.Format = "c"
            Me.dgvAFORSUIM.Columns("AFSIVAIM").DefaultCellStyle.Format = "c"

            Me.dgvAFORSUIM.Columns("AFSIVALI").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            Me.dgvAFORSUIM.Columns("AFSIVAIM").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft

            '==================================================
            '*** ASIGNA LOS PRIVILEGIOS DE LA BARRA DE MENU ***
            '==================================================

            If Me.BindingSource_AFORSUIM_1.Count >= 0 Then
                Me.BindingNavigator_AFORSUIM_1.Enabled = True
            End If

            Dim boCONTAGRE As Boolean = False
            Dim boCONTMODI As Boolean = False
            Dim boCONTELIM As Boolean = False
            Dim boCONTCONS As Boolean = False
            Dim boCONTRECO As Boolean = False

            pro_Permiso_Barra_De_Menu_Formulario_Formulario(Me.BindingSource_AFORSUIM_1.Count, Trim(Me.Name), boCONTAGRE, boCONTMODI, boCONTELIM, boCONTCONS, boCONTRECO)

            Me.cmdAGREGAR_AFORSUIM.Enabled = boCONTAGRE
            Me.cmdMODIFICAR_AFORSUIM.Enabled = boCONTMODI
            Me.cmdELIMINAR_AFORSUIM.Enabled = boCONTELIM
            Me.cmdCONSULTAR_AFORSUIM.Enabled = boCONTCONS
            Me.cmdRECONSULTAR_AFORSUIM.Enabled = boCONTRECO

            pro_TotalAforadoDeImpuesto()

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub pro_ListaDeValoresAforoDeImpuesto()

        Try
            If Me.dgvAFORSUIM.RowCount > 0 Then

                Me.txtAFSITIIM.Text = Trim(Me.dgvAFORSUIM.SelectedRows.Item(0).Cells("AFSITIIM").Value.ToString)
                Me.txtAFSICONC.Text = Trim(Me.dgvAFORSUIM.SelectedRows.Item(0).Cells("AFSICONC").Value.ToString)
                Me.txtAFSIMOLI.Text = Trim(Me.dgvAFORSUIM.SelectedRows.Item(0).Cells("AFSIMOLI").Value.ToString)
                Me.txtAFSIFEAF.Text = Trim(Me.dgvAFORSUIM.SelectedRows.Item(0).Cells("AFSIFEAF").Value.ToString.Substring(0, 10))
                Me.txtAFSIZO01.Text = Trim(Me.dgvAFORSUIM.SelectedRows.Item(0).Cells("AFSIZO01").Value.ToString)
                Me.txtAFSIZO02.Text = Trim(Me.dgvAFORSUIM.SelectedRows.Item(0).Cells("AFSIZO02").Value.ToString)
                Me.txtAFSIZO03.Text = Trim(Me.dgvAFORSUIM.SelectedRows.Item(0).Cells("AFSIZO03").Value.ToString)
                Me.txtAFSIZO04.Text = Trim(Me.dgvAFORSUIM.SelectedRows.Item(0).Cells("AFSIZO04").Value.ToString)
                Me.txtAFSIZO05.Text = Trim(Me.dgvAFORSUIM.SelectedRows.Item(0).Cells("AFSIZO05").Value.ToString)
                Me.txtAFSIZO06.Text = Trim(Me.dgvAFORSUIM.SelectedRows.Item(0).Cells("AFSIZO06").Value.ToString)
                Me.txtAFSIZO07.Text = Trim(Me.dgvAFORSUIM.SelectedRows.Item(0).Cells("AFSIZO07").Value.ToString)
                Me.txtAFSITA01.Text = Trim(Me.dgvAFORSUIM.SelectedRows.Item(0).Cells("AFSITA01").Value.ToString)
                Me.txtAFSITA02.Text = Trim(Me.dgvAFORSUIM.SelectedRows.Item(0).Cells("AFSITA02").Value.ToString)
                Me.txtAFSITA03.Text = Trim(Me.dgvAFORSUIM.SelectedRows.Item(0).Cells("AFSITA03").Value.ToString)
                Me.txtAFSITA04.Text = Trim(Me.dgvAFORSUIM.SelectedRows.Item(0).Cells("AFSITA04").Value.ToString)
                Me.txtAFSITA05.Text = Trim(Me.dgvAFORSUIM.SelectedRows.Item(0).Cells("AFSITA05").Value.ToString)
                Me.txtAFSITA06.Text = Trim(Me.dgvAFORSUIM.SelectedRows.Item(0).Cells("AFSITA06").Value.ToString)
                Me.txtAFSITA07.Text = Trim(Me.dgvAFORSUIM.SelectedRows.Item(0).Cells("AFSITA07").Value.ToString)
                Me.txtAFSITIAF.Text = Trim(Me.dgvAFORSUIM.SelectedRows.Item(0).Cells("AFSITIAF").Value.ToString)
                Me.txtAFSIVIGE.Text = Trim(Me.dgvAFORSUIM.SelectedRows.Item(0).Cells("AFSIVIGE").Value.ToString)

                Me.txtAFSIUSIN.Text = Trim(Me.dgvAFORSUIM.SelectedRows.Item(0).Cells("AFSIUSIN").Value.ToString)
                Me.txtAFSIUSMO.Text = Trim(Me.dgvAFORSUIM.SelectedRows.Item(0).Cells("AFSIUSMO").Value.ToString)
                Me.txtAFSIFEIN.Text = Trim(Me.dgvAFORSUIM.SelectedRows.Item(0).Cells("AFSIFEIN").Value.ToString.Substring(0, 10))
                Me.txtAFSIFEMO.Text = Trim(Me.dgvAFORSUIM.SelectedRows.Item(0).Cells("AFSIFEMO").Value.ToString.Substring(0, 10))
                Me.txtAFSIMAQU.Text = Trim(Me.dgvAFORSUIM.SelectedRows.Item(0).Cells("AFSIMAQU").Value.ToString)

                Me.lblAFSITIIM.Text = CType(fun_Buscar_Lista_Valores_TIPOIMPU(Me.dgvAFORSUIM.SelectedRows.Item(0).Cells("AFSITIIM").Value.ToString), String)
                Me.lblAFSICONC.Text = CType(fun_Buscar_Lista_Valores_CONCEPTO(Me.dgvAFORSUIM.SelectedRows.Item(0).Cells("AFSITIIM").Value.ToString, Me.dgvAFORSUIM.SelectedRows.Item(0).Cells("AFSICONC").Value.ToString), String)
                Me.lblAFSIMOLI.Text = CType(fun_Buscar_Lista_Valores_MODOLIQU(Me.dgvAFORSUIM.SelectedRows.Item(0).Cells("AFSIMOLI").Value.ToString), String)
                Me.lblAFSITIAF.Text = CType(fun_Buscar_Lista_Valores_TIPOAFOR(Me.dgvAFORSUIM.SelectedRows.Item(0).Cells("AFSITIAF").Value.ToString), String)
                Me.lblAFSIVIGE.Text = CType(fun_Buscar_Lista_Valores_VIGENCIA(Me.dgvAFORSUIM.SelectedRows.Item(0).Cells("AFSIVIGE").Value.ToString), String)

                If Trim(Me.txtAFSIUSMO.Text) = "" Then
                    Me.txtAFSIFEMO.Text = ""
                End If

            Else
                pro_LimpiarCamposAforoDeImpuestos()
            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub pro_LimpiarCamposAforoDeImpuestos()

        Me.txtAFSITIIM.Text = ""
        Me.txtAFSITIIM.Text = ""
        Me.txtAFSICONC.Text = ""
        Me.lblAFSICONC.Text = ""
        Me.txtAFSIMOLI.Text = ""
        Me.lblAFSIMOLI.Text = ""
        Me.txtAFSIFEAF.Text = ""
        Me.txtAFSIZO01.Text = ""
        Me.txtAFSIZO02.Text = ""
        Me.txtAFSIZO03.Text = ""
        Me.txtAFSIZO04.Text = ""
        Me.txtAFSIZO05.Text = ""
        Me.txtAFSIZO06.Text = ""
        Me.txtAFSIZO07.Text = ""
        Me.txtAFSITA01.Text = ""
        Me.txtAFSITA02.Text = ""
        Me.txtAFSITA03.Text = ""
        Me.txtAFSITA04.Text = ""
        Me.txtAFSITA05.Text = ""
        Me.txtAFSITA06.Text = ""
        Me.txtAFSITA07.Text = ""
        Me.txtAFSITIAF.Text = ""
        Me.lblAFSITIAF.Text = ""
        Me.txtAFSIVIGE.Text = ""
        Me.lblAFSIVIGE.Text = ""

        Me.txtAFSIUSIN.Text = ""
        Me.txtAFSIUSMO.Text = ""
        Me.txtAFSIFEIN.Text = ""
        Me.txtAFSIFEMO.Text = ""
        Me.txtAFSIMAQU.Text = ""
        Me.txtAFSIFECH.Text = ""
        Me.txtAFSIINCR.Text = "0"

        Me.dgvAFORSUIM.DataSource = New DataTable

    End Sub
    Private Sub pro_TotalAforadoDeImpuesto()

        Try
            If Me.dgvAFORSUIM.RowCount > 0 Then

                Dim tbl_AFORSUIM As New DataTable

                tbl_AFORSUIM = Me.BindingSource_AFORSUIM_1.DataSource

                Dim loTotalAforado As Long = 0
                Dim i As Integer = 0

                For i = 0 To tbl_AFORSUIM.Rows.Count - 1
                    loTotalAforado += CLng(tbl_AFORSUIM.Rows(i).Item("AFSIVALI"))
                Next

                Me.txtAFIMTOTA.Text = "$ " & CStr(fun_Formato_Mascara_Pesos_Enteros(loTotalAforado))

            Else
                Me.txtAFIMTOTA.Text = CStr(fun_Formato_Mascara_Pesos_Enteros("0"))
            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub pro_IncrementoAforo()

        Try
            Dim I, SW As Byte

            While I < Me.dgvAFORSUIM.RowCount And SW = 0
                If Me.dgvAFORSUIM.CurrentRow.Cells(I).Selected Then

                    Dim inVigenciaActual As Integer = CInt(Me.dgvAFORSUIM.CurrentRow.Cells("AFSIVIGE").Value.ToString())
                    Dim loValorLiquidadoActual As Long = CLng(Me.dgvAFORSUIM.CurrentRow.Cells("AFSIVALI").Value.ToString())
                    Dim inNroFicha As Integer = CInt(Me.dgvAFORSUIM.CurrentRow.Cells("AFSINUFI").Value.ToString())
                    Dim inConcepto As Integer = CInt(Me.dgvAFORSUIM.CurrentRow.Cells("AFSICONC").Value.ToString())

                    ' instancia la clase
                    Dim obAFORSUIM As New cla_AFORSUIM
                    Dim dtAFORSUIM As New DataTable

                    dtAFORSUIM = obAFORSUIM.fun_Consultar_NUFI_VIGE_CONC_X_AFORSUIM(inNroFicha, inVigenciaActual - 1, inConcepto)

                    ' verifica los registros
                    If dtAFORSUIM.Rows.Count > 0 Then

                        Dim loValorLiquidadoAnterior As Long = CLng(dtAFORSUIM.Rows(0).Item("AFSIVALI"))

                        If loValorLiquidadoAnterior <> 0 Then
                            Me.txtAFSIINCR.Text = fun_Formato_Decimal_2_Decimales((((CLng(loValorLiquidadoActual) * 100) / loValorLiquidadoAnterior) - 100))
                        Else
                            Me.txtAFSIINCR.Text = "0"
                        End If

                    Else
                        Me.txtAFSIINCR.Text = "0"
                    End If

                    SW = 1
                Else
                    I = I + 1
                End If

            End While

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub

#End Region

#Region "PROCEDIMIENTOS PROPIETARIO SUJETO DE IMPUESTO"

    Private Sub pro_ReconsultarPropietarioSujetoDeImpuesto()

    End Sub
    Private Sub pro_ListaDeValoresPropietarioSujetoDeImpuesto()

    End Sub
    Private Sub pro_LimpiarCamposPropietarioSujetoDeImpuesto()

    End Sub

#End Region

#Region "PROCEDIMIENTOS ESTADO DE CUENTA"

    Private Sub pro_ReconsultarEstadoDeCuenta()

    End Sub
    Private Sub pro_ListaDeValoresEstadoDeCuenta()

    End Sub
    Private Sub pro_LimpiarCamposEstadoDeCuenta()

    End Sub

#End Region

#Region "PROCEDIMIENTOS SALDO POR CONCEPTO"

    Private Sub pro_ReconsultarSaldoPorConcepto()

    End Sub
    Private Sub pro_ListaDeValoresSaldoPorConcepto()

    End Sub
    Private Sub pro_LimpiarCamposSaldoPorConcepto()

    End Sub


#End Region

#Region "PROCEDIMIENTOS MOVIMIENTO DETALLADO"

    Private Sub pro_ReconsultarMovimientoDetallado()

    End Sub
    Private Sub pro_ListaDeValoresMovimientoDetallado()

    End Sub
    Private Sub pro_LimpiarCamposMovimientoDetallado()

    End Sub

#End Region

#Region "MENU SUJETO DE IMPUESTO"

    Private Sub cmdBUSCAR_SUIMSUIM_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCONSULTAR_SUIMSUIM.Click

        Try
            vp_inConsulta = 0

            frm_consulta_SUJEIMPU.ShowDialog()

            If vp_inConsulta > 0 Then
                boCONSULTA = True

                pro_LimpiarCamposSujetoDeImpueto()
                pro_ReconsultarSujetoDeImpuesto()
                pro_ListaDeValoresSujetoDeImpuesto()

            Else
                boCONSULTA = False
            End If

            Me.tabHIAVSUIM.Focus()

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub cmdRECONSULTAR_SUJEIMPU_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdRECONSULTAR_SUIMSUIM.Click

        Try
            boCONSULTA = False
            pro_ReconsultarSujetoDeImpuesto()
            pro_ListaDeValoresSujetoDeImpuesto()

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub cmdSALIR_SUJEIMPU_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSALIR_SUIMSUIM.Click

        Try
            Me.Close()
        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub

#End Region

#Region "MENU HISTORICO DE AVALUO"

    Private Sub cmdAGREGAR_HISTAVAL_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAGREGAR_HISTAVAL.Click

    End Sub
    Private Sub cmdMODIFICAR_HISTAVAL_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdMODIFICAR_HISTAVAL.Click

    End Sub
    Private Sub cmdELIMINAR_HISTAVAL_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdELIMINAR_HISTAVAL.Click

    End Sub
    Private Sub cmdCONSULTAR_HISTAVAL_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCONSULTAR_HISTAVAL.Click

        Try
            vp_inConsulta = 0

            frm_consulta_SUJEIMPU.ShowDialog()

            If vp_inConsulta > 0 Then
                boCONSULTA = True

                pro_LimpiarCamposSujetoDeImpueto()
                pro_ReconsultarSujetoDeImpuesto()
                pro_ListaDeValoresSujetoDeImpuesto()

            Else
                boCONSULTA = False
            End If

            Me.tabHIAVSUIM.Focus()

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub cmdRECONSULTAR_HISTAVAL_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdRECONSULTAR_HISTAVAL.Click
        pro_ReconsultarHistoricoDeAvaluos()
        pro_ListaDeValoresHistoricoDeAvaluos()
        pro_IncrementoAvaluo()
    End Sub
    Private Sub cmdSALIR_HISTAVAL_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSALIR_HISTAVAL.Click
        Me.Close()
    End Sub

    Private Sub BindingNavigatorMoveFirstItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BindingNavigatorMoveFirstItem.Click
        pro_ListaDeValoresHistoricoDeAvaluos()
        pro_IncrementoAvaluo()
    End Sub
    Private Sub BindingNavigatorMovePreviousItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BindingNavigatorMovePreviousItem.Click
        pro_ListaDeValoresHistoricoDeAvaluos()
        pro_IncrementoAvaluo()
    End Sub
    Private Sub BindingNavigatorMoveNextItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BindingNavigatorMoveNextItem.Click
        pro_ListaDeValoresHistoricoDeAvaluos()
        pro_IncrementoAvaluo()
    End Sub
    Private Sub BindingNavigatorMoveLastItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BindingNavigatorMoveLastItem.Click
        pro_ListaDeValoresHistoricoDeAvaluos()
        pro_IncrementoAvaluo()
    End Sub

#End Region

#Region "MENU HISTORICO DE LIQUIDACION"

    Private Sub cmdAGREGAR_HISTLIQU_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAGREGAR_HISTLIQU.Click

    End Sub
    Private Sub cmdMODIFICAR_HISTLIQU_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdMODIFICAR_HISTLIQU.Click

    End Sub
    Private Sub cmdELIMINAR_HISTLIQU_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdELIMINAR_HISTLIQU.Click

    End Sub
    Private Sub cmdCONSULTAR_HISTLIQU_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCONSULTAR_HISTLIQU.Click

        Try
            vp_inConsulta = 0

            frm_consulta_SUJEIMPU.ShowDialog()

            If vp_inConsulta > 0 Then
                boCONSULTA = True

                pro_LimpiarCamposSujetoDeImpueto()
                pro_ReconsultarSujetoDeImpuesto()
                pro_ListaDeValoresSujetoDeImpuesto()

            Else
                boCONSULTA = False
            End If

            Me.tabHIAVSUIM.Focus()

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub cmdRECONSULTAR_HISTLIQU_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdRECONSULTAR_HISTLIQU.Click
        pro_ReconsultarHistoricoDeLiquidacion()
        pro_ListaDeValoresHistoricoDeLiquidacion()
    End Sub
    Private Sub cmdHILIZONA_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdHILIZONA.Click

        Try
            Dim frm_Historico_De_Zonas As New frm_Historico_De_Zonas(CInt(dt_SUJEIMPU.Rows(0).Item("SUIMNUFI")))

            frm_Historico_De_Zonas.ShowDialog()

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub cmdSALIR_HISTLIQU_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSALIR_HISTLIQU.Click
        Me.Close()
    End Sub

    Private Sub BindingNavigatorMoveFirstItem2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BindingNavigatorMoveFirstItem2.Click
        pro_ListaDeValoresHistoricoDeLiquidacion()
    End Sub
    Private Sub BindingNavigatorMovePreviousItem2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BindingNavigatorMovePreviousItem2.Click
        pro_ListaDeValoresHistoricoDeLiquidacion()
    End Sub
    Private Sub BindingNavigatorMoveNextItem2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BindingNavigatorMoveNextItem2.Click
        pro_ListaDeValoresHistoricoDeLiquidacion()
    End Sub
    Private Sub BindingNavigatorMoveLastItem2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BindingNavigatorMoveLastItem2.Click
        pro_ListaDeValoresHistoricoDeLiquidacion()
    End Sub

#End Region

#Region "MENU AFORO DE IMPUESTO"

    Private Sub cmdAGREGAR_AFORIMPU_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAGREGAR_AFORSUIM.Click

    End Sub
    Private Sub cmdMODIFICAR_AFORIMPU_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdMODIFICAR_AFORSUIM.Click

    End Sub
    Private Sub cmdELIMINAR_AFORIMPU_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdELIMINAR_AFORSUIM.Click

    End Sub
    Private Sub cmdCONSULTAR_AFORIMPU_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCONSULTAR_AFORSUIM.Click

        Try
            vp_inConsulta = 0

            frm_consulta_SUJEIMPU.ShowDialog()

            If vp_inConsulta > 0 Then
                boCONSULTA = True

                pro_LimpiarCamposSujetoDeImpueto()
                pro_ReconsultarSujetoDeImpuesto()
                pro_ListaDeValoresSujetoDeImpuesto()

            Else
                boCONSULTA = False
            End If

            Me.tabHIAVSUIM.Focus()

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub cmdRECONSULTAR_AFORIMPU_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdRECONSULTAR_AFORSUIM.Click
        pro_ReconsultarAforoDeImpuesto()
        pro_ListaDeValoresAforoDeImpuesto()
        pro_IncrementoAforo()
    End Sub
    Private Sub cmdSALIR_AFORIMPU_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSALIR_AFORSUIM.Click
        Me.Close()
    End Sub

    Private Sub BindingNavigatorMoveFirstItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BindingNavigatorMoveFirstItem1.Click
        pro_ListaDeValoresAforoDeImpuesto()
        pro_IncrementoAforo()
    End Sub
    Private Sub BindingNavigatorMovePreviousItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BindingNavigatorMovePreviousItem1.Click
        pro_ListaDeValoresAforoDeImpuesto()
        pro_IncrementoAforo()
    End Sub
    Private Sub BindingNavigatorMoveNextItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BindingNavigatorMoveNextItem1.Click
        pro_ListaDeValoresAforoDeImpuesto()
        pro_IncrementoAforo()
    End Sub
    Private Sub BindingNavigatorMoveLastItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BindingNavigatorMoveLastItem1.Click
        pro_ListaDeValoresAforoDeImpuesto()
        pro_IncrementoAforo()
    End Sub

#End Region

#Region "MENU PROPIETARIO SUJETO DE IMPUESTO"

    Private Sub cmdINSERTAR_PROPSUIM_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdINSERTAR_PROPSUIM.Click

    End Sub
    Private Sub cmdMODIFICAR_PROPSUIM_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdMODIFICAR_PROPSUIM.Click

    End Sub
    Private Sub cmdELIMINAR_PROPSUIM_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdELIMINAR_PROPSUIM.Click

    End Sub
    Private Sub cmdCONSULTAR_PROPSUIM_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCONSULTAR_PROPSUIM.Click

    End Sub
    Private Sub cmdRECONSULTAR_PROPSUIM_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdRECONSULTAR_PROPSUIM.Click

    End Sub
    Private Sub cmdSALIR_PROPSUIM_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSALIR_PROPSUIM.Click
        Me.Close()
    End Sub

#End Region

#Region "MENU ESTADO DE CUENTA"

    Private Sub cmdINSERTAR_ESTACUEN_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdINSERTAR_ESTACUEN.Click

    End Sub
    Private Sub cmdMODIFICAR_ESTACUEN_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdMODIFICAR_ESTACUEN.Click

    End Sub
    Private Sub cmdELIMINAR_ESTACUEN_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdELIMINAR_ESTACUEN.Click

    End Sub
    Private Sub cmdCONSULTAR_ESTACUEN_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCONSULTAR_ESTACUEN.Click

    End Sub
    Private Sub cmdRECONSULTAR_ESTACUEN_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdRECONSULTAR_ESTACUEN.Click

    End Sub
    Private Sub cmdSALIR_ESTACUEN_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSALIR_ESTACUEN.Click
        Me.Close()
    End Sub

#End Region

#Region "MENU SALDO POR CONCEPTO"

    Private Sub cmdINSERTAR_SALDCONC_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdINSERTAR_SALDCONC.Click

    End Sub
    Private Sub cmdMODIFICAR_SALDCONC_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdMODIFICAR_SALDCONC.Click

    End Sub
    Private Sub cmdELIMINAR_SALDCONC_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdELIMINAR_SALDCONC.Click

    End Sub
    Private Sub cmdCONSULTAR_SALDCONC_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCONSULTAR_SALDCONC.Click

    End Sub
    Private Sub cmdRECONSULTAR_SALDCONC_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdRECONSULTAR_SALDCONC.Click

    End Sub
    Private Sub cmdSALIR_SALDCONC_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSALIR_SALDCONC.Click
        Me.Close()
    End Sub

#End Region

#Region "MENU MOVIMIENTO DETALLADO"

    Private Sub cmdINSERTAR_MOVIDETA_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdINSERTAR_MOVIDETA.Click

    End Sub
    Private Sub cmdMODIFICAR_MOVIDETA_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdMODIFICAR_MOVIDETA.Click

    End Sub
    Private Sub cmdELIMINAR_MOVIDETA_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdELIMINAR_MOVIDETA.Click

    End Sub
    Private Sub cmdCONSULTAR_MOVIDETA_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCONSULTAR_MOVIDETA.Click

    End Sub
    Private Sub cmdRECONSULTAR_MOVIDETA_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdRECONSULTAR_MOVIDETA.Click

    End Sub
    Private Sub cmdSALIR_MOVIDETA_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSALIR_MOVIDETA.Click
        Me.Close()
    End Sub

#End Region

#Region "FORMULARIO"

#Region "Load"

    Private Sub frm_SUJEIMPU_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Me.ToolTip1.SetToolTip(Me.cmdHILIZONA, "Historico de zonas")
        Me.ToolTip1.SetToolTip(Me.cmdSUIMIMPR, "Imagen del predio")

    End Sub

#End Region

#Region "Click"

    Private Sub cmdSUIMIMPR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSUIMIMPR.Click
        Try
            If Trim(txtFIPRNUFI.Text) <> "" Then

                Dim frm_imagen_PREDIO As New frm_imagen_PREDIO(Trim(Val(Me.txtFIPRNUFI.Text)))
                frm_imagen_PREDIO.ShowDialog()

                vp_FichaPredial = Val(Me.txtFIPRNUFI.Text)

            Else
                MessageBox.Show("Selecione una ficha predial", "Mensaje...", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1)
            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try
    End Sub

#End Region

#Region "GotFocus"

    Private Sub frm_SUJEIMPU_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.GotFocus
        pro_ListaDeValoresSujetoDeImpuesto()
    End Sub

#End Region

#Region "KeyUp"

    Private Sub dgvHISTAVAL_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgvHISTAVAL_1.KeyUp, dgvHISTAVAL_2.KeyUp
        If e.KeyCode = Keys.Down Or e.KeyCode = Keys.Up Or e.KeyCode = Keys.Enter Or e.KeyCode = Keys.PageUp Or e.KeyCode = Keys.PageDown Then
            pro_ListaDeValoresHistoricoDeAvaluos()
            pro_IncrementoAvaluo()
        End If
    End Sub
    Private Sub dgvHISTLIQU_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgvHISTLIQU_1.KeyUp, dgvHISTLIQU_2.KeyUp
        If e.KeyCode = Keys.Down Or e.KeyCode = Keys.Up Or e.KeyCode = Keys.Enter Or e.KeyCode = Keys.PageUp Or e.KeyCode = Keys.PageDown Then
            pro_ListaDeValoresHistoricoDeLiquidacion()
        End If
    End Sub
    Private Sub dgvAFORSUIM_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgvAFORSUIM.KeyUp
        If e.KeyCode = Keys.Down Or e.KeyCode = Keys.Up Or e.KeyCode = Keys.Enter Or e.KeyCode = Keys.PageUp Or e.KeyCode = Keys.PageDown Then
            pro_ListaDeValoresAforoDeImpuesto()
            pro_IncrementoAforo()
        End If
    End Sub

#End Region

#Region "CellClick"

    Private Sub dgvHISTAVAL_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvHISTAVAL_1.CellClick, dgvHISTAVAL_2.CellClick
        pro_ListaDeValoresHistoricoDeAvaluos()
        pro_IncrementoAvaluo()
    End Sub
    Private Sub dgvHISTLIQU_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvHISTLIQU_1.CellClick, dgvHISTLIQU_2.CellClick
        pro_ListaDeValoresHistoricoDeLiquidacion()
    End Sub
    Private Sub dgvAFORSUIM_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvAFORSUIM.CellClick
        pro_ListaDeValoresAforoDeImpuesto()
        pro_IncrementoAforo()
    End Sub

#End Region

#End Region

   
End Class