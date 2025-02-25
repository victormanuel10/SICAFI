Imports REGLAS_DEL_NEGOCIO

Module mod_fun_NOMBRE_POR_USUARIO

    Public Function fun_BuscarNombrePorUsuario(ByVal stUSUARIO As String) As String

        Try

            ' consulta el Nro. de documento por el usuario
            Dim objdatos11 As New cla_CONTRASENA
            Dim tbl11 As New DataTable

            tbl11 = objdatos11.fun_Buscar_USUARIO_CONTRASENA(Trim(stUSUARIO))

            ' declara la variabl'
            Dim stNroDocumento As String = ""

            ' carga la variable
            stNroDocumento = tbl11.Rows(0).Item("CONTNUDO").ToString

            ' consulta el nombre por Nro. de documento
            Dim objdatos22 As New cla_USUARIO
            Dim tbl As New DataTable

            Dim idNroDocumento As String = Trim(stNroDocumento)

            tbl = objdatos22.fun_Buscar_CODIGO_USUARIO(idNroDocumento)

            Dim nombre As String = Trim(tbl.Rows(0).Item("USUANOMB"))
            Dim PrApellido As String = Trim(tbl.Rows(0).Item("USUAPRAP"))
            Dim SeApellido As String = Trim(tbl.Rows(0).Item("USUASEAP"))

            Return nombre & " " & PrApellido & " " & SeApellido

        Catch ex As Exception
            Return ""
            MessageBox.Show(Err.Description)
        End Try

    End Function

End Module
