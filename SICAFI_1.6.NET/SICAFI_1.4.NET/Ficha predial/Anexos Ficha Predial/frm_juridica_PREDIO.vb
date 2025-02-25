Imports REGLAS_DEL_NEGOCIO

Public Class frm_juridica_PREDIO

    '=======================
    '*** JURIDICA PREDIO ***
    '=======================

#Region "CONSTRUCTOR"

    Public Sub New(ByVal id As Integer)
        NroFicha = id
        InitializeComponent()
        pro_InicializarControles()

    End Sub

#End Region

#Region "VARIALES LOCALES"

    Dim NroFicha As Integer
    Dim boInsertar As Boolean = False
    Dim boActualizar As Boolean = False

#End Region

#Region "PROCEDIMIENTOS"

    Private Sub pro_LimpiarCampos()

        Me.txtJUDIFOLI.Text = ""
        Me.txtJURIMASE.Text = ""
        Me.txtJURIMAAB.Text = ""
        Me.txtJURITOAB.Text = ""
        Me.txtJURIFOAB.Text = ""
        Me.chkJURIFATR.Checked = False
        Me.txtJURIADEO.Text = ""
        Me.chkJURIPLPR.Checked = False
        Me.txtJURIOBSE.Text = ""

    End Sub

    Private Sub pro_InicializarControles()

        Dim objdatos As New cla_juridica_PREDIO
        Dim tbl As New DataTable

        tbl = objdatos.fun_Buscar_NRO_FICHA_JURIDICA(NroFicha)

        If tbl.Rows.Count > 0 Then

            boActualizar = True

            Me.txtJUDIFOLI.Text = Trim(tbl.Rows(0).Item("JURIFOLI"))
            Me.txtJURIMASE.Text = Trim(tbl.Rows(0).Item("JURIMASE"))
            Me.txtJURIMAAB.Text = Trim(tbl.Rows(0).Item("JURIMAAB"))
            Me.txtJURITOAB.Text = Trim(tbl.Rows(0).Item("JURITOAB"))
            Me.txtJURIFOAB.Text = Trim(tbl.Rows(0).Item("JURIFOAB"))
            Me.txtJURIARTE.Text = Trim(tbl.Rows(0).Item("JURIARTE"))
            Me.chkJURIFATR.Checked = Trim(tbl.Rows(0).Item("JURIFATR"))
            Me.txtJURIADEO.Text = Trim(tbl.Rows(0).Item("JURIADEO"))
            Me.chkJURIPLPR.Checked = Trim(tbl.Rows(0).Item("JURIPLPR"))
            Me.txtJURIOBSE.Text = Trim(tbl.Rows(0).Item("JURIOBSE"))

        Else
            boInsertar = True

            pro_LimpiarCampos()
        End If

    End Sub

#End Region

#Region "MENU"

    Private Sub cmdGUARDAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGUARDAR.Click
        Try

            If boInsertar = True Then
                Dim objdatos As New cla_juridica_PREDIO

                If objdatos.fun_Insertar_JURIDICA(NroFicha, txtJUDIFOLI.Text, txtJURIMASE.Text, txtJURIMAAB.Text, txtJURITOAB.Text, txtJURIFOAB.Text, txtJURIARTE.Text, chkJURIFATR.Checked, txtJURIADEO.Text, chkJURIPLPR.Checked, txtJURIOBSE.Text) Then
                    MessageBox.Show("Se guardaron los datos correctamente", "Mensaje ...", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                    Me.Close()
                Else
                    MessageBox.Show("No se guardaron los datos", "Mensaje ...", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1)
                    Me.Close()
                End If

            ElseIf boActualizar = True Then

                Dim objdatos As New cla_juridica_PREDIO

                If objdatos.fun_Actualizar_NRO_FICHA_JURIDICA(NroFicha, txtJUDIFOLI.Text, txtJURIMASE.Text, txtJURIMAAB.Text, txtJURITOAB.Text, txtJURIFOAB.Text, txtJURIARTE.Text, chkJURIFATR.Checked, txtJURIADEO.Text, chkJURIPLPR.Checked, txtJURIOBSE.Text) Then
                    MessageBox.Show("Se guardaron los datos correctamente", "Mensaje ...", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                    Me.Close()
                Else
                    MessageBox.Show("No se guardaron los datos", "Mensaje ...", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1)
                    Me.Close()
                End If

            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try
    End Sub
    Private Sub cmdCANCELAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSALIR.Click
        Me.Close()
    End Sub

#End Region

#Region "FORMULARIO"

#Region "GotFocus"

    Private Sub txt_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtJUDIFOLI.GotFocus, txtJURIMASE.GotFocus, txtJURIMAAB.GotFocus, txtJURITOAB.GotFocus, txtJURIFOAB.GotFocus, txtJURIARTE.GotFocus, chkJURIFATR.GotFocus, chkJURIPLPR.GotFocus, txtJURIADEO.GotFocus, txtJURIOBSE.GotFocus
        pp_pro_SobrearCampo(sender)
        pp_pro_DescripcionCampo(Me.strBARRESTA.Items(0), sender)
    End Sub
    Private Sub chk_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkJURIFATR.GotFocus, chkJURIPLPR.GotFocus
        pp_pro_SobrearCampo(sender)
        pp_pro_DescripcionCampo(Me.strBARRESTA.Items(0), sender)
    End Sub
    Private Sub cmdGUARDAR_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdGUARDAR.GotFocus
        strBARRESTA.Items(0).Text = cmdGUARDAR.AccessibleDescription
    End Sub
    Private Sub cmdCANCELAR_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdSALIR.GotFocus
        strBARRESTA.Items(0).Text = cmdSALIR.AccessibleDescription
    End Sub

#End Region

#Region "KeyPress"

    Private Sub txt_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtJUDIFOLI.KeyPress, txtJURIMASE.KeyPress, txtJURIMAAB.KeyPress, txtJURITOAB.KeyPress, txtJURIFOAB.KeyPress, txtJURIARTE.KeyPress, txtJURIADEO.KeyPress, chkJURIFATR.KeyPress, chkJURIPLPR.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Or e.KeyChar = Convert.ToChar(Keys.Tab) Then
            pp_pro_SaltarCampo()
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