Imports REGLAS_DEL_NEGOCIO

Public Class frm_modificar_RECOPRSE

    '====================================
    '*** MODIFICAR PREDIOS SEGREGADOS ***
    '====================================

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
            Dim obRECOPRSE As New cla_RECOPRSE
            Dim dtRECOPRSE As New DataTable

            dtRECOPRSE = obRECOPRSE.fun_Buscar_ID_RECOPRSE(vl_inRECOIDRE)

            If dtRECOPRSE.Rows.Count > 0 Then

                Me.txtRCPSMUNI.Text = Trim(dtRECOPRSE.Rows(0).Item("RCPSMUNI"))
                Me.txtRCPSCORR.Text = Trim(dtRECOPRSE.Rows(0).Item("RCPSCORR"))
                Me.txtRCPSBARR.Text = Trim(dtRECOPRSE.Rows(0).Item("RCPSBARR"))
                Me.txtRCPSMANZ.Text = Trim(dtRECOPRSE.Rows(0).Item("RCPSMANZ"))
                Me.txtRCPSPRED.Text = Trim(dtRECOPRSE.Rows(0).Item("RCPSPRED"))
                Me.txtRCPSEDIF.Text = Trim(dtRECOPRSE.Rows(0).Item("RCPSEDIF"))
                Me.txtRCPSUNPR.Text = Trim(dtRECOPRSE.Rows(0).Item("RCPSUNPR"))
                Me.txtRCPSDIRE.Text = Trim(dtRECOPRSE.Rows(0).Item("RCPSDIRE"))
                Me.txtRCPSNUFI.Text = Trim(dtRECOPRSE.Rows(0).Item("RCPSNUFI"))
                Me.txtRCPSMAIN.Text = Trim(dtRECOPRSE.Rows(0).Item("RCPSMAIN"))

                Dim objdatos6 As New cla_CLASSECT

                Me.cboRCPSCLSE.DataSource = objdatos6.fun_Consultar_CAMPOS_MANT_CLASSECT
                Me.cboRCPSCLSE.DisplayMember = "CLSEDESC"
                Me.cboRCPSCLSE.ValueMember = "CLSECODI"

                Me.cboRCPSCLSE.SelectedValue = dtRECOPRSE.Rows(0).Item("RCPSCLSE")

                Dim objdatos7 As New cla_ESTADO

                Me.cboRCPSESTA.DataSource = objdatos7.fun_Consultar_TODOS_LOS_ESTADOS
                Me.cboRCPSESTA.DisplayMember = "ESTADESC"
                Me.cboRCPSESTA.ValueMember = "ESTACODI"

                Me.cboRCPSESTA.SelectedValue = dtRECOPRSE.Rows(0).Item("RCPSESTA")

                Me.lblRCPSCLSE.Text = CType(fun_Buscar_Lista_Valores_CLASSECT_Codigo(Me.cboRCPSCLSE), String)

            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub pro_LimpiarCampos()

        Me.txtRCPSMUNI.Text = "266"
        Me.txtRCPSCORR.Text = "01"
        Me.txtRCPSBARR.Text = ""
        Me.txtRCPSMANZ.Text = ""
        Me.txtRCPSPRED.Text = ""
        Me.txtRCPSEDIF.Text = ""
        Me.txtRCPSUNPR.Text = ""
        Me.txtRCPSNUFI.Text = ""
        Me.txtRCPSMAIN.Text = ""

        Me.cboRCPSCLSE.DataSource = New DataTable
        Me.cboRCPSESTA.DataSource = New DataTable

        Me.strBARRESTA.Items(2).Text = "Registros : 0"

    End Sub

#End Region

#Region "MENU"

    Private Sub cmdGUARDAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGUARDAR.Click

        Try
            ' instancia la clase
            Dim objVerifica As New cla_Verificar_Dato

            ' verifica los campos
            Dim boRECOMUNI As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Numerico(Me.txtRCPSMUNI)
            Dim boRECOCORR As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Numerico(Me.txtRCPSCORR)
            Dim boRECOBARR As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Numerico(Me.txtRCPSBARR)
            Dim boRECOMANZ As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Numerico(Me.txtRCPSMANZ)
            Dim boRECOPRED As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Numerico(Me.txtRCPSPRED)
            Dim boRECOEDIF As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Numerico(Me.txtRCPSEDIF)
            Dim boRECOUNPR As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Numerico(Me.txtRCPSUNPR)
            Dim boRECOCLSE As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboRCPSCLSE)
            Dim boRECOESTA As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboRCPSESTA)
            Dim boRECONUFI As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Numerico(Me.txtRCPSNUFI)
            Dim boRECOMAIN As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.txtRCPSMAIN)

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
                Dim inFIPRNUFI As Integer = CInt(Trim(Me.txtRCPSNUFI.Text))
                Dim stFIPRMUNI As String = CStr(Trim(Me.txtRCPSMUNI.Text))
                Dim stFIPRCORR As String = CStr(Trim(Me.txtRCPSCORR.Text))
                Dim stFIPRBARR As String = CStr(Trim(Me.txtRCPSBARR.Text))
                Dim stFIPRMANZ As String = CStr(Trim(Me.txtRCPSMANZ.Text))
                Dim stFIPRPRED As String = CStr(Trim(Me.txtRCPSPRED.Text))
                Dim stFIPREDIF As String = CStr(Trim(Me.txtRCPSEDIF.Text))
                Dim stFIPRUNPR As String = CStr(Trim(Me.txtRCPSUNPR.Text))
                Dim inFIPRCLSE As Integer = CInt(Trim(Me.cboRCPSCLSE.SelectedValue))
                Dim stFIPRDIRE As String = CStr(Trim(Me.txtRCPSDIRE.Text))
                Dim stFIPRMAIN As String = CStr(Trim(Me.txtRCPSMAIN.Text))
                Dim stFIPRESTA As String = CStr(Trim(Me.cboRCPSESTA.SelectedValue))

                ' instancia la clase
                Dim obRECOPRSE As New cla_RECOPRSE

                ' inserta registro
                If obRECOPRSE.fun_Actualizar_RECOPRSE(vl_inRECOIDRE, _
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

                    Me.txtRCPSMUNI.Focus()
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
        Me.txtRCPSMUNI.Focus()
        Me.Close()
    End Sub

#End Region

#Region "FORMULARIO"

#Region "KeyPress"

    Private Sub txt_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtRCPSMUNI.KeyPress, txtRCPSCORR.KeyPress, txtRCPSBARR.KeyPress, txtRCPSMANZ.KeyPress, txtRCPSPRED.KeyPress, txtRCPSNUFI.KeyPress, txtRCPSMAIN.KeyPress, cboRCPSCLSE.KeyPress, cboRCPSESTA.KeyPress, txtRCPSDIRE.KeyPress, txtRCPSEDIF.KeyPress, txtRCPSUNPR.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Or e.KeyChar = Convert.ToChar(Keys.Tab) Then
            pp_pro_SaltarCampo()
        End If
    End Sub

#End Region

#Region "KeyDown"

    Private Sub cboRCPSCLSE_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboRCPSCLSE.KeyDown
        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
            fun_Cargar_ComboBox_Con_Datos_Activos_CLASSECT_Descripcion(Me.cboRCPSCLSE, Me.cboRCPSCLSE.SelectedIndex)
        End If
    End Sub
    Private Sub cboRCPSESTA_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboRCPSESTA.KeyDown
        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
            fun_Cargar_ComboBox_Con_Datos_Activos_ESTADO_Descripcion(Me.cboRCPSESTA, Me.cboRCPSESTA.SelectedIndex)
        End If
    End Sub

#End Region

#Region "SelectedIndexChanged"

    Private Sub cboRCPSCLSE_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboRCPSCLSE.SelectedIndexChanged
        Me.lblRCPSCLSE.Text = CType(fun_Buscar_Lista_Valores_CLASSECT_Codigo(Me.cboRCPSCLSE), String)
    End Sub

#End Region

#Region "Click"

    Private Sub cboRCPSCLSE_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboRCPSCLSE.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_CLASSECT_Descripcion(Me.cboRCPSCLSE, Me.cboRCPSCLSE.SelectedIndex)
    End Sub
    Private Sub cboRCPSESTA_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboRCPSESTA.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_ESTADO_Descripcion(Me.cboRCPSESTA, Me.cboRCPSESTA.SelectedIndex)
    End Sub

#End Region

#Region "GotFocus"

    Private Sub txt_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtRCPSMUNI.GotFocus, txtRCPSCORR.GotFocus, txtRCPSBARR.GotFocus, txtRCPSMANZ.GotFocus, txtRCPSPRED.GotFocus, txtRCPSNUFI.GotFocus, txtRCPSMAIN.GotFocus, txtRCPSDIRE.GotFocus, txtRCPSEDIF.GotFocus, txtRCPSUNPR.GotFocus
        pp_pro_SobrearCampo(sender)
        pp_pro_DescripcionCampo(Me.strBARRESTA.Items(0), sender)
    End Sub
    Private Sub cmd_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdGUARDAR.GotFocus, cmdSALIR.GotFocus, cboRCPSCLSE.GotFocus, cboRCPSESTA.GotFocus
        pp_pro_DescripcionCampo(Me.strBARRESTA.Items(0), sender)
    End Sub

#End Region

#Region "Validated"

    Private Sub txtTRCAMUNI_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtRCPSMUNI.Validated
        If Me.txtRCPSMUNI.Text <> "" And fun_Verificar_Dato_Numerico_Evento_Validated(Me.txtRCPSMUNI.Text) = True Then
            Me.txtRCPSMUNI.Text = fun_Formato_Mascara_3_String(Me.txtRCPSMUNI.Text)
        End If
    End Sub
    Private Sub txtTRCACORR_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtRCPSCORR.Validated
        If Me.txtRCPSCORR.Text <> "" And fun_Verificar_Dato_Numerico_Evento_Validated(Me.txtRCPSCORR.Text) = True Then
            Me.txtRCPSCORR.Text = fun_Formato_Mascara_2_String(Me.txtRCPSCORR.Text)
        End If
    End Sub
    Private Sub txtTRCABARR_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtRCPSBARR.Validated
        If Me.txtRCPSBARR.Text <> "" And fun_Verificar_Dato_Numerico_Evento_Validated(Me.txtRCPSBARR.Text) = True Then
            Me.txtRCPSBARR.Text = fun_Formato_Mascara_3_String(Me.txtRCPSBARR.Text)
        End If
    End Sub
    Private Sub txtTRCAMANZ_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtRCPSMANZ.Validated
        If Me.txtRCPSMANZ.Text <> "" And fun_Verificar_Dato_Numerico_Evento_Validated(Me.txtRCPSMANZ.Text) = True Then
            Me.txtRCPSMANZ.Text = fun_Formato_Mascara_3_String(Me.txtRCPSMANZ.Text)
        End If
    End Sub
    Private Sub txtTRCAPRED_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtRCPSPRED.Validated
        If Me.txtRCPSPRED.Text <> "" And fun_Verificar_Dato_Numerico_Evento_Validated(Me.txtRCPSPRED.Text) = True Then
            Me.txtRCPSPRED.Text = fun_Formato_Mascara_5_String(Me.txtRCPSPRED.Text)
        End If
    End Sub
    Private Sub txtRCPSEDIF_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtRCPSEDIF.Validated
        If Me.txtRCPSEDIF.Text <> "" And fun_Verificar_Dato_Numerico_Evento_Validated(Me.txtRCPSEDIF.Text) = True Then
            Me.txtRCPSEDIF.Text = fun_Formato_Mascara_3_String(Me.txtRCPSEDIF.Text)
        End If
    End Sub
    Private Sub txtRCPSUNPR_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtRCPSUNPR.Validated
        If Me.txtRCPSUNPR.Text <> "" And fun_Verificar_Dato_Numerico_Evento_Validated(Me.txtRCPSUNPR.Text) = True Then
            Me.txtRCPSUNPR.Text = fun_Formato_Mascara_5_String(Me.txtRCPSUNPR.Text)
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