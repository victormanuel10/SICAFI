Public Class frm_LLENAR_LISTAVALO

    Private Sub cmdCANCELAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCANCELAR.Click
        Me.Close()
    End Sub

    Private Sub cboLISTVALO_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboLISTVALO.SelectedIndexChanged
        Dim seleccion As Integer

        seleccion = cboLISTVALO.SelectedIndex

        Select Case seleccion

            Case 0
                frm_insertar_DEPARTAMENTO.Show()
            Case 1
                frm_insertar_MUNICIPIO.Show()
            Case 2
                frm_insertar_NOTARIA.Show()

        End Select

    End Sub
End Class