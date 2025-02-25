Imports REGLAS_DEL_NEGOCIO

Public Class frm_modificar_RECOPRMO

    '===================================
    '*** MODIFICAR PREDIO MODIFICADO ***
    '===================================

#Region "VARIABLE"

    Dim vl_inRECOIDRE As Integer
    Dim vl_inRECOSECU As Integer
    Dim vl_inRECONURE As Integer
    Dim vl_stRECOFERE As String = ""

    Dim dt As DataTable

#End Region

#Region "CONSTRUCTOR"

    Public Sub New()

        InitializeComponent()

    End Sub
    Public Sub New(ByVal inIDRE As Integer, ByVal inSECU As Integer, ByVal inNURE As Integer, ByVal stFERE As String)
        vl_inRECOIDRE = inIDRE
        vl_inRECOSECU = inSECU
        vl_inRECONURE = inNURE
        vl_stRECOFERE = stFERE

        InitializeComponent()
        pro_LimpiarCampos()
        pro_inicializarComponentes()

    End Sub

#End Region

#Region "PROCEDIMIENTOS"

    Private Sub pro_inicializarComponentes()

        Try
            ' instancia la clase
            Dim obRECOPRMO As New cla_RECOPRMO
            Dim dtRECOPRMO As New DataTable

            dtRECOPRMO = obRECOPRMO.fun_Buscar_ID_RECOPRMO(vl_inRECOIDRE)

            If dtRECOPRMO.Rows.Count > 0 Then

                Me.txtRCPMMUNI.Text = Trim(dtRECOPRMO.Rows(0).Item("RCPMMUNI"))
                Me.txtRCPMCORR.Text = Trim(dtRECOPRMO.Rows(0).Item("RCPMCORR"))
                Me.txtRCPMBARR.Text = Trim(dtRECOPRMO.Rows(0).Item("RCPMBARR"))
                Me.txtRCPMMANZ.Text = Trim(dtRECOPRMO.Rows(0).Item("RCPMMANZ"))
                Me.txtRCPMPRED.Text = Trim(dtRECOPRMO.Rows(0).Item("RCPMPRED"))
                Me.txtRCPMEDIF.Text = Trim(dtRECOPRMO.Rows(0).Item("RCPMEDIF"))
                Me.txtRCPMUNPR.Text = Trim(dtRECOPRMO.Rows(0).Item("RCPMUNPR"))
                Me.txtRCPMDIRE.Text = Trim(dtRECOPRMO.Rows(0).Item("RCPMDIRE"))
                Me.txtRCPMNUFI.Text = Trim(dtRECOPRMO.Rows(0).Item("RCPMNUFI"))
                Me.txtRCPMMAIN.Text = Trim(dtRECOPRMO.Rows(0).Item("RCPMMAIN"))

                Dim objdatos6 As New cla_CLASSECT

                Me.cboRCPMCLSE.DataSource = objdatos6.fun_Consultar_CAMPOS_MANT_CLASSECT
                Me.cboRCPMCLSE.DisplayMember = "CLSEDESC"
                Me.cboRCPMCLSE.ValueMember = "CLSECODI"

                Me.cboRCPMCLSE.SelectedValue = dtRECOPRMO.Rows(0).Item("RCPMCLSE")

                Dim objdatos7 As New cla_ESTADO

                Me.cboRCPMESTA.DataSource = objdatos7.fun_Consultar_TODOS_LOS_ESTADOS
                Me.cboRCPMESTA.DisplayMember = "ESTADESC"
                Me.cboRCPMESTA.ValueMember = "ESTACODI"

                Me.cboRCPMESTA.SelectedValue = dtRECOPRMO.Rows(0).Item("RCPMESTA")

                Me.lblRCPMCLSE.Text = CType(fun_Buscar_Lista_Valores_CLASSECT_Codigo(Me.cboRCPMCLSE), String)

            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub pro_LimpiarCampos()

        Me.txtRCPMMUNI.Text = "266"
        Me.txtRCPMCORR.Text = "01"
        Me.txtRCPMBARR.Text = ""
        Me.txtRCPMMANZ.Text = ""
        Me.txtRCPMPRED.Text = ""
        Me.txtRCPMEDIF.Text = ""
        Me.txtRCPMUNPR.Text = ""
        Me.txtRCPMNUFI.Text = ""
        Me.txtRCPMMAIN.Text = ""

        Me.cboRCPMCLSE.DataSource = New DataTable
        Me.cboRCPMESTA.DataSource = New DataTable

        Me.strBARRESTA.Items(2).Text = "Registros : 0"

    End Sub

#End Region

#Region "MENU"

    Private Sub cmdGUARDAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGUARDAR.Click

        Try
            ' instancia la clase
            Dim objVerifica As New cla_Verificar_Dato

            ' verifica los campos
            Dim boRECOMUNI As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Numerico(Me.txtRCPMMUNI)
            Dim boRECOCORR As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Numerico(Me.txtRCPMCORR)
            Dim boRECOBARR As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Numerico(Me.txtRCPMBARR)
            Dim boRECOMANZ As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Numerico(Me.txtRCPMMANZ)
            Dim boRECOPRED As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Numerico(Me.txtRCPMPRED)
            Dim boRECOEDIF As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Numerico(Me.txtRCPMEDIF)
            Dim boRECOUNPR As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Numerico(Me.txtRCPMUNPR)
            Dim boRECOCLSE As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboRCPMCLSE)
            Dim boRECOESTA As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboRCPMESTA)
            Dim boRECONUFI As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Numerico(Me.txtRCPMNUFI)
            Dim boRECOMAIN As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.txtRCPMMAIN)

            ' valida los campos
            If boRECOMUNI = True And _
               boRECOCORR = True And _
               boRECOBARR = True And _
               boRECOMANZ = True And _
               boRECOPRED = True And _
               boRECOEDIF = True And _
               boRECOUNPR = True And _
               boRECOCLSE = True And _
               boRECOESTA = True And _
               boRECONUFI = True And _
               boRECOMAIN = True Then

                ' declara la variable
                Dim inRECOIDRE As Integer = vl_inRECOIDRE
                Dim inRECONURE As Integer = vl_inRECONURE
                Dim stRECOFERE As String = vl_stRECOFERE
                Dim inFIPRNUFI As Integer = CInt(Trim(Me.txtRCPMNUFI.Text))
                Dim stFIPRMUNI As String = CStr(Trim(Me.txtRCPMMUNI.Text))
                Dim stFIPRCORR As String = CStr(Trim(Me.txtRCPMCORR.Text))
                Dim stFIPRBARR As String = CStr(Trim(Me.txtRCPMBARR.Text))
                Dim stFIPRMANZ As String = CStr(Trim(Me.txtRCPMMANZ.Text))
                Dim stFIPRPRED As String = CStr(Trim(Me.txtRCPMPRED.Text))
                Dim stFIPREDIF As String = CStr(Trim(Me.txtRCPMEDIF.Text))
                Dim stFIPRUNPR As String = CStr(Trim(Me.txtRCPMUNPR.Text))
                Dim inFIPRCLSE As Integer = CInt(Trim(Me.cboRCPMCLSE.SelectedValue))
                Dim stFIPRDIRE As String = CStr(Trim(Me.txtRCPMDIRE.Text))
                Dim stFIPRMAIN As String = CStr(Trim(Me.txtRCPMMAIN.Text))
                Dim stFIPRESTA As String = CStr(Trim(Me.cboRCPMESTA.SelectedValue))

                ' instancia la clase
                Dim obRECOPRMO As New cla_RECOPRMO

                ' inserta registro
                If obRECOPRMO.fun_Actualizar_RECOPRMO(vl_inRECOIDRE, _
                                                      vl_inRECOSECU, _
                                                      inRECONURE, _
                                                      stRECOFERE, _
                                                      inFIPRNUFI, _
                                                      stFIPRMUNI, _
                                                      stFIPRCORR, _
                                                      stFIPRBARR, _
                                                      stFIPRMANZ, _
                                                      stFIPRPRED, _
                                                      stFIPREDIF, _
                                                      stFIPRUNPR, _
                                                      inFIPRCLSE, _
                                                      stFIPRDIRE, _
                                                      stFIPRMAIN, _
                                                      stFIPRESTA) = True Then

                    mod_MENSAJE.Se_Guardaron_Los_Datos_Correctamente()

                    Me.txtRCPMMUNI.Focus()
                    Me.Close()
                Else
                    mod_MENSAJE.No_Se_Guardo_El_Registro_En_La_Base_De_Datos()
                End If

            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub cmdCANCELAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSALIR.Click
        Me.txtRCPMMUNI.Focus()
        Me.Close()
    End Sub

#End Region

#Region "FORMULARIO"

#Region "KeyPress"

    Private Sub txt_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtRCPMMUNI.KeyPress, txtRCPMCORR.KeyPress, txtRCPMBARR.KeyPress, txtRCPMMANZ.KeyPress, txtRCPMPRED.KeyPress, txtRCPMNUFI.KeyPress, txtRCPMMAIN.KeyPress, cboRCPMCLSE.KeyPress, cboRCPMESTA.KeyPress, txtRCPMDIRE.KeyPress, txtRCPMEDIF.KeyPress, txtRCPMUNPR.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Or e.KeyChar = Convert.ToChar(Keys.Tab) Then
            pp_pro_SaltarCampo()
        End If
    End Sub

#End Region

#Region "KeyDown"

    Private Sub cboRCPMCLSE_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboRCPMCLSE.KeyDown
        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
            fun_Cargar_ComboBox_Con_Datos_Activos_CLASSECT_Descripcion(Me.cboRCPMCLSE, Me.cboRCPMCLSE.SelectedIndex)
        End If
    End Sub
    Private Sub cboRCPMESTA_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboRCPMESTA.KeyDown
        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
            fun_Cargar_ComboBox_Con_Datos_Activos_ESTADO_Descripcion(Me.cboRCPMESTA, Me.cboRCPMESTA.SelectedIndex)
        End If
    End Sub

#End Region

#Region "SelectedIndexChanged"

    Private Sub cboRCPMCLSE_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboRCPMCLSE.SelectedIndexChanged
        Me.lblRCPMCLSE.Text = CType(fun_Buscar_Lista_Valores_CLASSECT_Codigo(Me.cboRCPMCLSE), String)
    End Sub

#End Region

#Region "Click"

    Private Sub cboRCPMCLSE_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboRCPMCLSE.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_CLASSECT_Descripcion(Me.cboRCPMCLSE, Me.cboRCPMCLSE.SelectedIndex)
    End Sub
    Private Sub cboRCPMESTA_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboRCPMESTA.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_ESTADO_Descripcion(Me.cboRCPMESTA, Me.cboRCPMESTA.SelectedIndex)
    End Sub

#End Region

#Region "GotFocus"

    Private Sub txt_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtRCPMMUNI.GotFocus, txtRCPMCORR.GotFocus, txtRCPMBARR.GotFocus, txtRCPMMANZ.GotFocus, txtRCPMPRED.GotFocus, txtRCPMNUFI.GotFocus, txtRCPMMAIN.GotFocus, txtRCPMDIRE.GotFocus, txtRCPMEDIF.GotFocus, txtRCPMUNPR.GotFocus
        pp_pro_SobrearCampo(sender)
        pp_pro_DescripcionCampo(Me.strBARRESTA.Items(0), sender)
    End Sub
    Private Sub cmd_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdGUARDAR.GotFocus, cmdSALIR.GotFocus, cboRCPMCLSE.GotFocus, cboRCPMESTA.GotFocus
        pp_pro_DescripcionCampo(Me.strBARRESTA.Items(0), sender)
    End Sub

#End Region

#Region "Validated"

    Private Sub txtTRCAMUNI_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtRCPMMUNI.Validated
        If Me.txtRCPMMUNI.Text <> "" And fun_Verificar_Dato_Numerico_Evento_Validated(Me.txtRCPMMUNI.Text) = True Then
            Me.txtRCPMMUNI.Text = fun_Formato_Mascara_3_String(Me.txtRCPMMUNI.Text)
        End If
    End Sub
    Private Sub txtTRCACORR_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtRCPMCORR.Validated
        If Me.txtRCPMCORR.Text <> "" And fun_Verificar_Dato_Numerico_Evento_Validated(Me.txtRCPMCORR.Text) = True Then
            Me.txtRCPMCORR.Text = fun_Formato_Mascara_2_String(Me.txtRCPMCORR.Text)
        End If
    End Sub
    Private Sub txtTRCABARR_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtRCPMBARR.Validated
        If Me.txtRCPMBARR.Text <> "" And fun_Verificar_Dato_Numerico_Evento_Validated(Me.txtRCPMBARR.Text) = True Then
            Me.txtRCPMBARR.Text = fun_Formato_Mascara_3_String(Me.txtRCPMBARR.Text)
        End If
    End Sub
    Private Sub txtTRCAMANZ_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtRCPMMANZ.Validated
        If Me.txtRCPMMANZ.Text <> "" And fun_Verificar_Dato_Numerico_Evento_Validated(Me.txtRCPMMANZ.Text) = True Then
            Me.txtRCPMMANZ.Text = fun_Formato_Mascara_3_String(Me.txtRCPMMANZ.Text)
        End If
    End Sub
    Private Sub txtTRCAPRED_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtRCPMPRED.Validated
        If Me.txtRCPMPRED.Text <> "" And fun_Verificar_Dato_Numerico_Evento_Validated(Me.txtRCPMPRED.Text) = True Then
            Me.txtRCPMPRED.Text = fun_Formato_Mascara_5_String(Me.txtRCPMPRED.Text)
        End If
    End Sub
    Private Sub txtRCPMEDIF_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtRCPMEDIF.Validated
        If Me.txtRCPMEDIF.Text <> "" And fun_Verificar_Dato_Numerico_Evento_Validated(Me.txtRCPMEDIF.Text) = True Then
            Me.txtRCPMEDIF.Text = fun_Formato_Mascara_3_String(Me.txtRCPMEDIF.Text)
        End If
    End Sub
    Private Sub txtRCPMUNPR_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtRCPMUNPR.Validated
        If Me.txtRCPMUNPR.Text <> "" And fun_Verificar_Dato_Numerico_Evento_Validated(Me.txtRCPMUNPR.Text) = True Then
            Me.txtRCPMUNPR.Text = fun_Formato_Mascara_5_String(Me.txtRCPMUNPR.Text)
        End If
    End Sub

#End Region

#Region "ResizeBegin"

    Private Sub frm_ResizeBegin(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.ResizeBegin
        Me.Opacity = vp_Opacity
    End Sub

#End Region

#Region "ResizeEnd"

    Private Sub frm_ResizeEnd(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.ResizeEnd
        Dim opacity As Double = Convert.ToDouble(100)
        Me.Opacity = opacity
    End Sub

#End Region

#End Region

End Class