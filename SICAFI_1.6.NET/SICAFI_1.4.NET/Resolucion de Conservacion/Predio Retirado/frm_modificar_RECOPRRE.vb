Imports REGLAS_DEL_NEGOCIO

Public Class frm_modificar_RECOPRRE

    '=================================
    '*** MODIFICAR PREDIO RETIRADO ***
    '=================================

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
            Dim obRECOPRRE As New cla_RECOPRRE
            Dim dtRECOPRRE As New DataTable

            dtRECOPRRE = obRECOPRRE.fun_Buscar_ID_RECOPRRE(vl_inRECOIDRE)

            If dtRECOPRRE.Rows.Count > 0 Then

                Me.txtRCPRMUNI.Text = Trim(dtRECOPRRE.Rows(0).Item("RCPRMUNI"))
                Me.txtRCPRCORR.Text = Trim(dtRECOPRRE.Rows(0).Item("RCPRCORR"))
                Me.txtRCPRBARR.Text = Trim(dtRECOPRRE.Rows(0).Item("RCPRBARR"))
                Me.txtRCPRMANZ.Text = Trim(dtRECOPRRE.Rows(0).Item("RCPRMANZ"))
                Me.txtRCPRPRED.Text = Trim(dtRECOPRRE.Rows(0).Item("RCPRPRED"))
                Me.txtRCPREDIF.Text = Trim(dtRECOPRRE.Rows(0).Item("RCPREDIF"))
                Me.txtRCPRUNPR.Text = Trim(dtRECOPRRE.Rows(0).Item("RCPRUNPR"))
                Me.txtRCPRDIRE.Text = Trim(dtRECOPRRE.Rows(0).Item("RCPRDIRE"))
                Me.txtRCPRNUFI.Text = Trim(dtRECOPRRE.Rows(0).Item("RCPRNUFI"))
                Me.txtRCPRMAIN.Text = Trim(dtRECOPRRE.Rows(0).Item("RCPRMAIN"))

                Dim objdatos6 As New cla_CLASSECT

                Me.cboRCPRCLSE.DataSource = objdatos6.fun_Consultar_CAMPOS_MANT_CLASSECT
                Me.cboRCPRCLSE.DisplayMember = "CLSEDESC"
                Me.cboRCPRCLSE.ValueMember = "CLSECODI"

                Me.cboRCPRCLSE.SelectedValue = dtRECOPRRE.Rows(0).Item("RCPRCLSE")

                Dim objdatos7 As New cla_ESTADO

                Me.cboRCPRESTA.DataSource = objdatos7.fun_Consultar_TODOS_LOS_ESTADOS
                Me.cboRCPRESTA.DisplayMember = "ESTADESC"
                Me.cboRCPRESTA.ValueMember = "ESTACODI"

                Me.cboRCPRESTA.SelectedValue = dtRECOPRRE.Rows(0).Item("RCPRESTA")

                Me.lblRCPRCLSE.Text = CType(fun_Buscar_Lista_Valores_CLASSECT_Codigo(Me.cboRCPRCLSE), String)

            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub pro_LimpiarCampos()

        Me.txtRCPRMUNI.Text = "266"
        Me.txtRCPRCORR.Text = "01"
        Me.txtRCPRBARR.Text = ""
        Me.txtRCPRMANZ.Text = ""
        Me.txtRCPRPRED.Text = ""
        Me.txtRCPREDIF.Text = ""
        Me.txtRCPRUNPR.Text = ""
        Me.txtRCPRNUFI.Text = ""
        Me.txtRCPRMAIN.Text = ""

        Me.cboRCPRCLSE.DataSource = New DataTable
        Me.cboRCPRESTA.DataSource = New DataTable

        Me.strBARRESTA.Items(2).Text = "Registros : 0"

    End Sub

#End Region

#Region "MENU"

    Private Sub cmdGUARDAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGUARDAR.Click

        Try
            ' instancia la clase
            Dim objVerifica As New cla_Verificar_Dato

            ' verifica los campos
            Dim boRECOMUNI As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Numerico(Me.txtRCPRMUNI)
            Dim boRECOCORR As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Numerico(Me.txtRCPRCORR)
            Dim boRECOBARR As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Numerico(Me.txtRCPRBARR)
            Dim boRECOMANZ As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Numerico(Me.txtRCPRMANZ)
            Dim boRECOPRED As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Numerico(Me.txtRCPRPRED)
            Dim boRECOEDIF As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Numerico(Me.txtRCPREDIF)
            Dim boRECOUNPR As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Numerico(Me.txtRCPRUNPR)
            Dim boRECOCLSE As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboRCPRCLSE)
            Dim boRECOESTA As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboRCPRESTA)
            Dim boRECONUFI As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Numerico(Me.txtRCPRNUFI)
            Dim boRECOMAIN As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.txtRCPRMAIN)

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
                Dim inFIPRNUFI As Integer = CInt(Trim(Me.txtRCPRNUFI.Text))
                Dim stFIPRMUNI As String = CStr(Trim(Me.txtRCPRMUNI.Text))
                Dim stFIPRCORR As String = CStr(Trim(Me.txtRCPRCORR.Text))
                Dim stFIPRBARR As String = CStr(Trim(Me.txtRCPRBARR.Text))
                Dim stFIPRMANZ As String = CStr(Trim(Me.txtRCPRMANZ.Text))
                Dim stFIPRPRED As String = CStr(Trim(Me.txtRCPRPRED.Text))
                Dim stFIPREDIF As String = CStr(Trim(Me.txtRCPREDIF.Text))
                Dim stFIPRUNPR As String = CStr(Trim(Me.txtRCPRUNPR.Text))
                Dim inFIPRCLSE As Integer = CInt(Trim(Me.cboRCPRCLSE.SelectedValue))
                Dim stFIPRDIRE As String = CStr(Trim(Me.txtRCPRDIRE.Text))
                Dim stFIPRMAIN As String = CStr(Trim(Me.txtRCPRMAIN.Text))
                Dim stFIPRESTA As String = CStr(Trim(Me.cboRCPRESTA.SelectedValue))

                ' instancia la clase
                Dim obRECOPRRE As New cla_RECOPRRE

                ' inserta registro
                If obRECOPRRE.fun_Actualizar_RECOPRRE(vl_inRECOIDRE, _
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

                    Me.txtRCPRMUNI.Focus()
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
        Me.txtRCPRMUNI.Focus()
        Me.Close()
    End Sub

#End Region

#Region "FORMULARIO"

#Region "KeyPress"

    Private Sub txt_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtRCPRMUNI.KeyPress, txtRCPRCORR.KeyPress, txtRCPRBARR.KeyPress, txtRCPRMANZ.KeyPress, txtRCPRPRED.KeyPress, txtRCPRNUFI.KeyPress, txtRCPRMAIN.KeyPress, cboRCPRCLSE.KeyPress, cboRCPRESTA.KeyPress, txtRCPRDIRE.KeyPress, txtRCPREDIF.KeyPress, txtRCPRUNPR.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Or e.KeyChar = Convert.ToChar(Keys.Tab) Then
            pp_pro_SaltarCampo()
        End If
    End Sub

#End Region

#Region "KeyDown"

    Private Sub cboRCPRCLSE_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboRCPRCLSE.KeyDown
        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
            fun_Cargar_ComboBox_Con_Datos_Activos_CLASSECT_Descripcion(Me.cboRCPRCLSE, Me.cboRCPRCLSE.SelectedIndex)
        End If
    End Sub
    Private Sub cboRCPRESTA_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboRCPRESTA.KeyDown
        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
            fun_Cargar_ComboBox_Con_Datos_Activos_ESTADO_Descripcion(Me.cboRCPRESTA, Me.cboRCPRESTA.SelectedIndex)
        End If
    End Sub

#End Region

#Region "SelectedIndexChanged"

    Private Sub cboRCPRCLSE_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboRCPRCLSE.SelectedIndexChanged
        Me.lblRCPRCLSE.Text = CType(fun_Buscar_Lista_Valores_CLASSECT_Codigo(Me.cboRCPRCLSE), String)
    End Sub

#End Region

#Region "Click"

    Private Sub cboRCPRCLSE_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboRCPRCLSE.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_CLASSECT_Descripcion(Me.cboRCPRCLSE, Me.cboRCPRCLSE.SelectedIndex)
    End Sub
    Private Sub cboRCPRESTA_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboRCPRESTA.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_ESTADO_Descripcion(Me.cboRCPRESTA, Me.cboRCPRESTA.SelectedIndex)
    End Sub

#End Region

#Region "GotFocus"

    Private Sub txt_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtRCPRMUNI.GotFocus, txtRCPRCORR.GotFocus, txtRCPRBARR.GotFocus, txtRCPRMANZ.GotFocus, txtRCPRPRED.GotFocus, txtRCPRNUFI.GotFocus, txtRCPRMAIN.GotFocus, txtRCPRDIRE.GotFocus, txtRCPREDIF.GotFocus, txtRCPRUNPR.GotFocus
        pp_pro_SobrearCampo(sender)
        pp_pro_DescripcionCampo(Me.strBARRESTA.Items(0), sender)
    End Sub
    Private Sub cmd_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdGUARDAR.GotFocus, cmdSALIR.GotFocus, cboRCPRCLSE.GotFocus, cboRCPRESTA.GotFocus
        pp_pro_DescripcionCampo(Me.strBARRESTA.Items(0), sender)
    End Sub

#End Region

#Region "Validated"

    Private Sub txtTRCAMUNI_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtRCPRMUNI.Validated
        If Me.txtRCPRMUNI.Text <> "" And fun_Verificar_Dato_Numerico_Evento_Validated(Me.txtRCPRMUNI.Text) = True Then
            Me.txtRCPRMUNI.Text = fun_Formato_Mascara_3_String(Me.txtRCPRMUNI.Text)
        End If
    End Sub
    Private Sub txtTRCACORR_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtRCPRCORR.Validated
        If Me.txtRCPRCORR.Text <> "" And fun_Verificar_Dato_Numerico_Evento_Validated(Me.txtRCPRCORR.Text) = True Then
            Me.txtRCPRCORR.Text = fun_Formato_Mascara_2_String(Me.txtRCPRCORR.Text)
        End If
    End Sub
    Private Sub txtTRCABARR_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtRCPRBARR.Validated
        If Me.txtRCPRBARR.Text <> "" And fun_Verificar_Dato_Numerico_Evento_Validated(Me.txtRCPRBARR.Text) = True Then
            Me.txtRCPRBARR.Text = fun_Formato_Mascara_3_String(Me.txtRCPRBARR.Text)
        End If
    End Sub
    Private Sub txtTRCAMANZ_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtRCPRMANZ.Validated
        If Me.txtRCPRMANZ.Text <> "" And fun_Verificar_Dato_Numerico_Evento_Validated(Me.txtRCPRMANZ.Text) = True Then
            Me.txtRCPRMANZ.Text = fun_Formato_Mascara_3_String(Me.txtRCPRMANZ.Text)
        End If
    End Sub
    Private Sub txtTRCAPRED_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtRCPRPRED.Validated
        If Me.txtRCPRPRED.Text <> "" And fun_Verificar_Dato_Numerico_Evento_Validated(Me.txtRCPRPRED.Text) = True Then
            Me.txtRCPRPRED.Text = fun_Formato_Mascara_5_String(Me.txtRCPRPRED.Text)
        End If
    End Sub
    Private Sub txtRCPREDIF_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtRCPREDIF.Validated
        If Me.txtRCPREDIF.Text <> "" And fun_Verificar_Dato_Numerico_Evento_Validated(Me.txtRCPREDIF.Text) = True Then
            Me.txtRCPREDIF.Text = fun_Formato_Mascara_3_String(Me.txtRCPREDIF.Text)
        End If
    End Sub
    Private Sub txtRCPRUNPR_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtRCPRUNPR.Validated
        If Me.txtRCPRUNPR.Text <> "" And fun_Verificar_Dato_Numerico_Evento_Validated(Me.txtRCPRUNPR.Text) = True Then
            Me.txtRCPRUNPR.Text = fun_Formato_Mascara_5_String(Me.txtRCPRUNPR.Text)
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