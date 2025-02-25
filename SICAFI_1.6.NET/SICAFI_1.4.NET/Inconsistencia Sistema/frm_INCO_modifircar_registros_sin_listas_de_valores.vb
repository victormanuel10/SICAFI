Imports System.Windows.Forms

Public Class frm_INCO_modifircar_registros_sin_listas_de_valores

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        'Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
        Exit Sub
    End Sub
    Private Sub frm_INCO_modifircar_registros_sin_listas_de_valores_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        txtSolucion.Text = My.Resources.INCO_modificar_registro
    End Sub
End Class
