Imports REGLAS_DEL_NEGOCIO

Public Class frm_registro_control_FICHPRED

    '============================================
    '*** REGISTRO Y CONSTROL DE FICHA PREDIAL ***
    '============================================

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

        Me.txtRECOINGE.Text = ""
        Me.txtRECOPRED.Text = ""
        Me.txtRECOEMPR.Text = ""
        Me.txtRECOPROP.Text = ""
        Me.txtRECOREPR.Text = ""
        Me.txtRECOFECH.Text = ""

    End Sub

    Private Sub pro_InicializarControles()

        Dim objdatos As New cla_registro_y_control_FICHPRED
        Dim tbl As New DataTable

        tbl = objdatos.fun_Buscar_NRO_FICHA_REGICONT(NroFicha)

        If tbl.Rows.Count > 0 Then

            boActualizar = True

            Me.txtRECOINGE.Text = Trim(tbl.Rows(0).Item("RECOINGE"))
            Me.txtRECOPRED.Text = Trim(tbl.Rows(0).Item("RECOPRED"))
            Me.txtRECOEMPR.Text = Trim(tbl.Rows(0).Item("RECOEMPR"))
            Me.txtRECOPROP.Text = Trim(tbl.Rows(0).Item("RECOPROP"))
            Me.txtRECOREPR.Text = Trim(tbl.Rows(0).Item("RECOREPR"))
            Me.txtRECOFECH.Text = Trim(tbl.Rows(0).Item("RECOFECH"))

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
                Dim objdatos As New cla_registro_y_control_FICHPRED

                If objdatos.fun_Insertar_REGICONT(NroFicha, txtRECOINGE.Text, txtRECOPRED.Text, txtRECOEMPR.Text, txtRECOPROP.Text, txtRECOREPR.Text, txtRECOFECH.Text) = True Then
                    MessageBox.Show("Se guardaron los datos correctamente", "Mensaje ...", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                    Me.Close()
                Else
                    MessageBox.Show("No se guardaron los datos", "Mensaje ...", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1)
                    Me.Close()
                End If

            ElseIf boActualizar = True Then

                Dim objdatos As New cla_registro_y_control_FICHPRED

                If objdatos.fun_Actualizar_NRO_FICHA_REGICONT(NroFicha, txtRECOINGE.Text, txtRECOPRED.Text, txtRECOEMPR.Text, txtRECOPROP.Text, txtRECOREPR.Text, txtRECOFECH.Text) = True Then
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

    Private Sub txt_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtRECOINGE.GotFocus, txtRECOPRED.GotFocus, txtRECOEMPR.GotFocus, txtRECOPROP.GotFocus, txtRECOREPR.GotFocus, txtRECOFECH.GotFocus
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

    Private Sub txt_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtRECOINGE.KeyPress, txtRECOPRED.KeyPress, txtRECOEMPR.KeyPress, txtRECOPROP.KeyPress, txtRECOREPR.KeyPress, txtRECOFECH.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Or e.KeyChar = Convert.ToChar(Keys.Tab) Then
            pp_pro_SaltarCampo()
        End If
    End Sub

#End Region

#Region "ValueChanged"

    Private Sub dtpRECLFEDE_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpRECOFECH.ValueChanged
        Me.txtRECOFECH.Text = Me.dtpRECOFECH.Value
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