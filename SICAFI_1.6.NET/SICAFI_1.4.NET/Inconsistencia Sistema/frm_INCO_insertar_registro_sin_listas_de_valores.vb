Imports System.Windows.Forms

Public Class frm_INCO_insertar_registro_sin_listas_de_valores

    Private Sub Cancel_Button_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        'Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
        Exit Sub
    End Sub

    Private Sub frm_INCO_insertar_registro_sin_listas_de_valores_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        txtSolucion.Text = My.Resources.INCO_insertar_registro
    End Sub

    
End Class
