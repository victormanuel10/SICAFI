Imports SYSTEM.Security.Principal
Imports SYSTEM.Security.Permissions

Module mod_fun_NOMBRE_DE_MAQUINA

    Public Function fun_Nombre_de_maquina() As String

        Try

            Dim MyIdentity As WindowsIdentity = WindowsIdentity.GetCurrent()
            Dim MyPrincipal As New WindowsPrincipal(MyIdentity)

            Dim stNameMaquina As String
            stNameMaquina = MyPrincipal.Identity.Name

            Return stNameMaquina

        Catch ex As Exception
            Return ""
            MessageBox.Show(Err.Description)
        End Try

    End Function

End Module
