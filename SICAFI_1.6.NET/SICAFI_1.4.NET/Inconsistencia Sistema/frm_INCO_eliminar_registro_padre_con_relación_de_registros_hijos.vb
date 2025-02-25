Public Class frm_INCO_eliminar_registro_padre_con_relación_de_registros_hijos

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        'Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
        Exit Sub
    End Sub

    Private Sub frm_INCO_eliminar_registro_padre_con_relación_de_registros_hijos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        txtSolucion.Text = My.Resources.INCO_eliminar_registro
    End Sub
End Class