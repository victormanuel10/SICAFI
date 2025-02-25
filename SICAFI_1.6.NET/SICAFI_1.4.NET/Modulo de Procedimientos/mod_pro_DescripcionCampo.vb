Module mod_pro_DescripcionCampo

    Public Sub pp_pro_DescripcionCampo(ByVal oCampoDescripcion As Object, ByVal oCampoObjeto As Object)
        oCampoDescripcion.text = oCampoObjeto.AccessibleDescription
    End Sub

End Module
