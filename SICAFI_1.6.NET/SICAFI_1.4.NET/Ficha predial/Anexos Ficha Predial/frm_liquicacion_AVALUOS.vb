Imports REGLAS_DEL_NEGOCIO

Public Class frm_liquicacion_AVALUOS

    '========================================
    ' *** LIQUIDACIÓN AVALUOS CATASTRALES ***
    '========================================

#Region "VARIABLES LOCALES"

    Dim vl_inFIPRNUFI As Integer

#End Region

#Region "CONSTRUCTOR"

    Public Sub New(ByVal inFIPRNUFI As Integer)

        vl_inFIPRNUFI = inFIPRNUFI

        InitializeComponent()
        pro_LimpiarCampos()
        pro_InicializarComponentes()

    End Sub

#End Region

#Region "PROCEDIMIENTOS"

    Private Sub pro_InicializarComponentes()

        Try
            Dim objdatos As New cla_FIPRAVAL
            Dim dt As New DataTable

            dt = objdatos.fun_Consultar_AVALUO_X_FICHA_PREDIAL(vl_inFIPRNUFI)

            Me.txtFPAVATPR.Text = Trim(dt.Rows(0).Item("FPAVATPR").ToString)
            Me.txtFPAVATCO.Text = Trim(dt.Rows(0).Item("FPAVATCO").ToString)
            Me.txtFPAVACPR.Text = Trim(dt.Rows(0).Item("FPAVACPR").ToString)
            Me.txtFPAVACCO.Text = Trim(dt.Rows(0).Item("FPAVACCO").ToString)
            Me.txtFPAVVATP.Text = fun_Formato_Mascara_Pesos(Trim(dt.Rows(0).Item("FPAVVATP").ToString))
            Me.txtFPAVVATC.Text = fun_Formato_Mascara_Pesos(Trim(dt.Rows(0).Item("FPAVVATC").ToString))
            Me.txtFPAVVACP.Text = fun_Formato_Mascara_Pesos(Trim(dt.Rows(0).Item("FPAVVACP").ToString))
            Me.txtFPAVVACC.Text = fun_Formato_Mascara_Pesos(Trim(dt.Rows(0).Item("FPAVVACC").ToString))
            Me.txtFPAVAVAL.Text = fun_Formato_Mascara_Pesos(Trim(dt.Rows(0).Item("FPAVAVAL").ToString))
            Me.txtFPAVTIRE.Text = Trim(dt.Rows(0).Item("FPAVDATR").ToString)
            Me.txtFPAVVIGE.Text = Trim(dt.Rows(0).Item("FPAVDAVI").ToString)
            Me.txtFPAVNUDO.Text = Trim(dt.Rows(0).Item("FPAVDAND").ToString)

            strBARRESTA.Items(2).Text = "Avalúo catastral"
            strBARRESTA.Items(2).Text = "Registros : " & dt.Rows.Count

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

       


    End Sub
    Private Sub pro_LimpiarCampos()

        Me.txtFPAVATPR.Text = ""
        Me.txtFPAVATCO.Text = ""
        Me.txtFPAVACPR.Text = ""
        Me.txtFPAVACCO.Text = ""
        Me.txtFPAVVATP.Text = ""
        Me.txtFPAVVATC.Text = ""
        Me.txtFPAVVACP.Text = ""
        Me.txtFPAVVACC.Text = ""
        Me.txtFPAVAVAL.Text = ""
        Me.txtFPAVTIRE.Text = ""
        Me.txtFPAVVIGE.Text = ""
        Me.txtFPAVNUDO.Text = ""

    End Sub

#End Region

#Region "MENU"

    Private Sub cmdSALIR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSALIR.Click
        Me.txtFPAVATPR.Focus()
        Me.Close()
    End Sub

#End Region

#Region "FORMULARIO"

#Region "KeyPress"

    Private Sub txtFPAVATPR_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFPAVATPR.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            Me.txtFPAVATCO.Focus()
        End If
    End Sub
    Private Sub txtFPAVATCO_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFPAVATCO.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            Me.txtFPAVACPR.Focus()
        End If
    End Sub
    Private Sub txtFPAVACPR_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFPAVACPR.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            Me.txtFPAVACCO.Focus()
        End If
    End Sub
    Private Sub txtFPAVACCO_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFPAVACCO.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            Me.txtFPAVVATP.Focus()
        End If
    End Sub
    Private Sub txtFPAVVATP_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFPAVVATP.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            Me.txtFPAVVATC.Focus()
        End If
    End Sub
    Private Sub txtFPAVVATC_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFPAVVATC.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            Me.txtFPAVVACP.Focus()
        End If
    End Sub
    Private Sub txtFPAVVACP_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFPAVVACP.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            Me.txtFPAVVACC.Focus()
        End If
    End Sub
    Private Sub txtFPAVVACC_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFPAVVACC.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            Me.txtFPAVAVAL.Focus()
        End If
    End Sub
    Private Sub txtFPAVAVAL_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFPAVAVAL.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            Me.txtFPAVTIRE.Focus()
        End If
    End Sub
    Private Sub txtFPAVTIRE_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFPAVTIRE.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            Me.txtFPAVVIGE.Focus()
        End If
    End Sub
    Private Sub txtFPAVVIGE_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFPAVVIGE.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            Me.txtFPAVNUDO.Focus()
        End If
    End Sub
    Private Sub txtFPAVNUDO_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFPAVNUDO.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            Me.cmdSALIR.Focus()
        End If
    End Sub

#End Region

#Region "GotFocus"

    Private Sub txtFPAVATPR_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFPAVATPR.GotFocus
        Me.txtFPAVATPR.SelectionStart = 0
        Me.txtFPAVATPR.SelectionLength = Len(Me.txtFPAVATPR.Text)
        strBARRESTA.Items(0).Text = Me.txtFPAVATPR.AccessibleDescription
    End Sub
    Private Sub txtFPAVATCO_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFPAVATCO.GotFocus
        Me.txtFPAVATCO.SelectionStart = 0
        Me.txtFPAVATCO.SelectionLength = Len(Me.txtFPAVATCO.Text)
        strBARRESTA.Items(0).Text = Me.txtFPAVATCO.AccessibleDescription
    End Sub
    Private Sub txtFPAVACPR_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFPAVACPR.GotFocus
        Me.txtFPAVACPR.SelectionStart = 0
        Me.txtFPAVACPR.SelectionLength = Len(Me.txtFPAVACPR.Text)
        strBARRESTA.Items(0).Text = Me.txtFPAVACPR.AccessibleDescription
    End Sub
    Private Sub txtFPAVACCO_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFPAVACCO.GotFocus
        Me.txtFPAVACCO.SelectionStart = 0
        Me.txtFPAVACCO.SelectionLength = Len(Me.txtFPAVACCO.Text)
        strBARRESTA.Items(0).Text = Me.txtFPAVACCO.AccessibleDescription
    End Sub
    Private Sub txtFPAVVATP_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFPAVVATP.GotFocus
        Me.txtFPAVVATP.SelectionStart = 0
        Me.txtFPAVVATP.SelectionLength = Len(Me.txtFPAVVATP.Text)
        strBARRESTA.Items(0).Text = Me.txtFPAVVATP.AccessibleDescription
    End Sub
    Private Sub txtFPAVVATC_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFPAVVATC.GotFocus
        Me.txtFPAVVATC.SelectionStart = 0
        Me.txtFPAVVATC.SelectionLength = Len(Me.txtFPAVVATC.Text)
        strBARRESTA.Items(0).Text = Me.txtFPAVVATC.AccessibleDescription
    End Sub
    Private Sub txtFPAVVACP_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFPAVVACP.GotFocus
        Me.txtFPAVVACP.SelectionStart = 0
        Me.txtFPAVVACP.SelectionLength = Len(Me.txtFPAVVACP.Text)
        strBARRESTA.Items(0).Text = Me.txtFPAVVACP.AccessibleDescription
    End Sub
    Private Sub txtFPAVVACC_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFPAVVACC.GotFocus
        Me.txtFPAVVACC.SelectionStart = 0
        Me.txtFPAVVACC.SelectionLength = Len(Me.txtFPAVVACC.Text)
        strBARRESTA.Items(0).Text = Me.txtFPAVVACC.AccessibleDescription
    End Sub
    Private Sub txtFPAVAVAL_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFPAVAVAL.GotFocus
        Me.txtFPAVAVAL.SelectionStart = 0
        Me.txtFPAVAVAL.SelectionLength = Len(Me.txtFPAVAVAL.Text)
        strBARRESTA.Items(0).Text = Me.txtFPAVAVAL.AccessibleDescription
    End Sub
    Private Sub txtFPAVTIRE_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFPAVTIRE.GotFocus
        Me.txtFPAVTIRE.SelectionStart = 0
        Me.txtFPAVTIRE.SelectionLength = Len(Me.txtFPAVTIRE.Text)
        strBARRESTA.Items(0).Text = Me.txtFPAVTIRE.AccessibleDescription
    End Sub
    Private Sub txtFPAVVIGE_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFPAVVIGE.GotFocus
        Me.txtFPAVVIGE.SelectionStart = 0
        Me.txtFPAVVIGE.SelectionLength = Len(Me.txtFPAVVIGE.Text)
        strBARRESTA.Items(0).Text = Me.txtFPAVVIGE.AccessibleDescription
    End Sub
    Private Sub txtFPAVNUDO_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFPAVNUDO.GotFocus
        Me.txtFPAVNUDO.SelectionStart = 0
        Me.txtFPAVNUDO.SelectionLength = Len(Me.txtFPAVNUDO.Text)
        strBARRESTA.Items(0).Text = Me.txtFPAVNUDO.AccessibleDescription
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