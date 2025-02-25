Module mod_pro_SombrearCampo

    Public Sub pp_pro_SobrearCampo(ByVal oCampo As Object)
        'oCampo.SelectionStart = 0
        'oCampo.SelectionLength = Len(oCampo.Text)

        System.Windows.Forms.SendKeys.Send("{Home}+{End}")
    End Sub

End Module
