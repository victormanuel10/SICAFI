Public Class frm_Procesando_ingreso_listas_de_valores

    '=============================================================================================
    Dim Proceso As Byte

    'Determina el tiempo que procesa la barra progresiva de insertar registros 
    '(carpeta inconsistencias)
    '=============================================================================================


    Private Sub timPROCESO_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles timPROCESO.Tick
        
        If Proceso = 100 Then
            Proceso = 0
            Me.Close()
        Else
            Proceso = Proceso + 1
        End If

        pbPROCESO.Value = Proceso

    End Sub

End Class