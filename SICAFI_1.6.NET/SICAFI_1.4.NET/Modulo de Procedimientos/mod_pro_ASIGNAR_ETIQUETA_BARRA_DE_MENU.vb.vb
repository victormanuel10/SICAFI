Imports REGLAS_DEL_NEGOCIO

Module mod_pro_ASIGNAR_ETIQUETA_BARRA_DE_MENU

    Public Function fun_Asignar_Etiqueta_Barra_De_Menu(ByVal stNombreEtiqueta As String) As Boolean


        Try
            '*** PERMISOS PARA ADMINISTRADOR ***

            If vp_usuario = "ADMINISTRADOR" Then

                ' consulto las etiquetas por usuario
                Dim objdatos1 As New cla_PERMETIQ
                Dim tbl1 As New DataTable

                tbl1 = objdatos1.fun_Buscar_USUARIO_Y_ETIQUETA_PERMETIQ(Trim(vp_usuario), Trim(stNombreEtiqueta))

                ' verifica si existe la etiqueta para el roles
                If tbl1.Rows.Count = 0 Then
                    Return False
                Else
                    Return True
                End If

            Else
                '*** PERMISOS PARA USUARIOS ***

                ' consulta el roles del usuario
                Dim objdatos23 As New cla_PERMROLE
                Dim tbl23 As New DataTable

                tbl23 = objdatos23.fun_Buscar_USUARIO_PERMROLE(vp_usuario)

                ' verifica que el usuario tenga un roles
                If tbl23.Rows.Count = 0 Then
                    Return False
                Else
                    ' declara la variable 
                    Dim stRoles As String = ""

                    ' almacena el roles
                    stRoles = Trim(tbl23.Rows(0).Item("PEROROLE").ToString)

                    ' consulto el formulario por usuario
                    Dim objdatos1 As New cla_PERMETIQ
                    Dim tbl1 As New DataTable

                    tbl1 = objdatos1.fun_Buscar_USUARIO_Y_ETIQUETA_PERMETIQ(Trim(stRoles), Trim(stNombreEtiqueta))

                    ' verifica si existe el formulario para el roles
                    If tbl1.Rows.Count = 0 Then
                        Return False
                    Else
                        Return True
                    End If
                End If
            End If

        Catch ex As Exception
            Return False
            MessageBox.Show(Err.Description)
        End Try

    End Function


End Module
