Imports REGLAS_DEL_NEGOCIO

Public Class frm_liquidacion_PREDIAL

    '=====================================
    ' *** LIQUIDACIÓN IMPUESTO PREDIAL ***
    '=====================================

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
            Dim objdatos As New cla_PREDIAL
            Dim dt As New DataTable

            dt = objdatos.fun_Consultar_PREDIAL_X_FICHA_PREDIAL(vl_inFIPRNUFI)

            Me.txtPREDPRED.Text = fun_Formato_Mascara_Pesos(Trim(dt.Rows(0).Item("PREDPRED").ToString))
            Me.txtPREDTIRE.Text = Trim(dt.Rows(0).Item("PREDDATR").ToString)
            Me.txtPREDVIGE.Text = Trim(dt.Rows(0).Item("PREDDAVI").ToString)
            Me.txtPREDNUDO.Text = Trim(dt.Rows(0).Item("PREDDAND").ToString)

            strBARRESTA.Items(2).Text = "Valor Predial"
            strBARRESTA.Items(2).Text = "Registros : " & dt.Rows.Count

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try




    End Sub
    Private Sub pro_LimpiarCampos()

        Me.txtPREDPRED.Text = ""
        Me.txtPREDTIRE.Text = ""
        Me.txtPREDVIGE.Text = ""
        Me.txtPREDNUDO.Text = ""

    End Sub

#End Region

#Region "MENU"

    Private Sub cmdSALIR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSALIR.Click
        Me.txtPREDPRED.Focus()
        Me.Close()
    End Sub

#End Region

#Region "FORMULARIO"

#Region "KeyPress"

    Private Sub txtPREDPRED_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtPREDPRED.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            Me.txtPREDTIRE.Focus()
        End If
    End Sub
    Private Sub txtPREDTIRE_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtPREDTIRE.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            Me.txtPREDVIGE.Focus()
        End If
    End Sub
    Private Sub txtPREDVIGE_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtPREDVIGE.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            Me.txtPREDNUDO.Focus()
        End If
    End Sub
    Private Sub txtPREDNUDO_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtPREDNUDO.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            Me.cmdSALIR.Focus()
        End If
    End Sub

#End Region

#Region "GotFocus"

    Private Sub txtPREDPRED_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtPREDPRED.GotFocus
        Me.txtPREDPRED.SelectionStart = 0
        Me.txtPREDPRED.SelectionLength = Len(Me.txtPREDPRED.Text)
        strBARRESTA.Items(0).Text = Me.txtPREDPRED.AccessibleDescription
    End Sub
    Private Sub txtPREDTIRE_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtPREDTIRE.GotFocus
        Me.txtPREDTIRE.SelectionStart = 0
        Me.txtPREDTIRE.SelectionLength = Len(Me.txtPREDTIRE.Text)
        strBARRESTA.Items(0).Text = Me.txtPREDTIRE.AccessibleDescription
    End Sub
    Private Sub txtPREDVIGE_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtPREDVIGE.GotFocus
        Me.txtPREDVIGE.SelectionStart = 0
        Me.txtPREDVIGE.SelectionLength = Len(Me.txtPREDVIGE.Text)
        strBARRESTA.Items(0).Text = Me.txtPREDVIGE.AccessibleDescription
    End Sub
    Private Sub txtPREDNUDO_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtPREDNUDO.GotFocus
        Me.txtPREDNUDO.SelectionStart = 0
        Me.txtPREDNUDO.SelectionLength = Len(Me.txtPREDNUDO.Text)
        strBARRESTA.Items(0).Text = Me.txtPREDNUDO.AccessibleDescription
    End Sub
    Private Sub cmdSALIR_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdSALIR.GotFocus
        strBARRESTA.Items(0).Text = Me.cmdSALIR.AccessibleDescription
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