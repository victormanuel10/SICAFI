Imports REGLAS_DEL_NEGOCIO

Public Class frm_modificar_FIPROBSE

    '===========================================
    '*** MODIFICAR OBSERBACIÓN FICHA PREDIAL ***
    '===========================================
   
#Region "CONSTRUCTOR"

    Public Sub New(ByVal id As Integer)
        NroFicha = id
        InitializeComponent()
        pro_InicializarControles()

    End Sub

#End Region

#Region "VARIALES LOCALES"

    Dim NroFicha As Integer

#End Region

#Region "PROCEDIMIENTOS"

    Private Sub pro_InicializarControles()
        Dim objdatos As New cla_FICHPRED
        Dim tbl As New DataTable

        tbl = objdatos.fun_Consultar_FICHA_PREDIAL_X_NRO_FICHA_PREDIAL(NroFicha)

        txtFIPROBSE.Text = Trim(tbl.Rows(0).Item(45))

    End Sub

#End Region

#Region "MENU"

    Private Sub cmdGUARDAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGUARDAR.Click
        Try
            Dim objdatos As New cla_FICHPRED

            If objdatos.fun_actualizar_OBSERVACION_FICHPRED(NroFicha, txtFIPROBSE.Text) Then
                MessageBox.Show("Se guardaron los datos correctamente", "Mensaje ...", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                Me.Close()
            Else
                MessageBox.Show("No se guardaron los datos", "Mensaje ...", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1)
                Me.Close()
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

    Private Sub txtFIPROBSE_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFIPROBSE.GotFocus
        strBARRESTA.Items(0).Text = txtFIPROBSE.AccessibleDescription
    End Sub
    Private Sub cmdGUARDAR_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdGUARDAR.GotFocus
        strBARRESTA.Items(0).Text = cmdGUARDAR.AccessibleDescription
    End Sub
    Private Sub cmdCANCELAR_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdSALIR.GotFocus
        strBARRESTA.Items(0).Text = cmdSALIR.AccessibleDescription
    End Sub

#End Region

#Region "KeyPress"

    Private Sub txtFIPROBSE_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFIPROBSE.KeyPress

        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            e.Handled = True
            mod_MENSAJE.Inco_Tecla_Invalida()
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