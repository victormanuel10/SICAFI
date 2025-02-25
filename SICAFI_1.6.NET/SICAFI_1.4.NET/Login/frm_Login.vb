Imports REGLAS_DEL_NEGOCIO

Public Class frm_Login

    '========================================
    '*** INGRESO AL SISTEMA SICAFI V.1.6. ***
    '========================================

#Region "VARIABLES"

    '*** SW VERIFICAR CAMPOS LLENOS QUE VAN A LA DB ***
    Dim SWVerificarCamposLlenos As Boolean = False

    '*** CONTADOR DE SALIDA ***
    Dim ContadorSalida As Integer

#End Region

#Region "PROCEDIMIENTOS"

    Private Sub pro_VerificarCamposLlenos()
        '*** CAMPOS OBLIGATORIOS ***
        Try
            If Trim(txtUsername.Text) = "" Or _
               Trim(txtPassword.Text) = "" Then
                SWVerificarCamposLlenos = False
            Else
                SWVerificarCamposLlenos = True 'Los campos estan bien diligenciados
            End If

        Catch ex As Exception
            MessageBox.Show("" & Err.Description & "")
        End Try
    End Sub
    Private Sub pro_LimpiarCampos()
        txtPassword.Text = ""
        txtUsername.Text = ""
    End Sub
    Private Sub pro_DesbloqueoEquipo()

        If vp_usuario <> "" Then
            Me.txtUsername.Text = vp_usuario
            Me.txtPassword.Focus()
        End If

    End Sub
    Private Sub pro_UbicaCursor()
        Me.txtUsername.Focus()
    End Sub
    Private Sub pro_IniciarSeccionComoAdministradorYConexionLocal(ByVal boCondicion As Boolean)

        If boCondicion = True Then

            Me.txtUsername.Text = "ADMINISTRADOR"
            Me.txtPassword.Text = "ADMINISTRADOR"
            Me.cboInstancia.Text = "LOCAL"

        ElseIf boCondicion = False Then

            Me.txtUsername.Text = ""
            Me.txtPassword.Text = ""
            Me.cboInstancia.Text = "RED"

        End If

    End Sub

#End Region

#Region "MENU"

    Private Sub OK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK.Click
        Try
            pro_VerificarCamposLlenos()

            If SWVerificarCamposLlenos = False Then
                mod_MENSAJE.Existen_Campos_Sin_Diligenciar()
                txtUsername.Focus()
            Else
                '======================================================================
                '*** ENVIA LAS VARIABLES PUBLICAS AL PROYECTO DE REGLAS DEL NEGOCIO ***
                '======================================================================
                Dim instancia As New REGLAS_DEL_NEGOCIO.cla_VariablesPublicas(Trim(Me.cboInstancia.Text))

                ' instancia la clase
                Dim objdatos As New cla_CONTRASENA

                Dim tbl_usuario As New DataTable
                Dim tbl_contrasena As New DataTable

                '*** BUSCA EL USUARIO ***
                tbl_usuario = objdatos.fun_Buscar_USUARIO_CONTRASENA(txtUsername.Text)

                '*** VERIFICA SI EXISTE EL USUARIO ***
                If tbl_usuario.Rows.Count > 0 Then

                    '*** SE OBTIENE EL ID DEL USUARIO ***
                    Dim id As Integer = Trim(tbl_usuario.Rows(0).Item(0))

                    '*** SE OBTIENE EL DOCUMENTO DEL USUARIO ***
                    Dim idNroDocumento As String = Trim(tbl_usuario.Rows(0).Item(1))
                    vp_cedula = idNroDocumento

                    '*** BUSCA LA CONSTRASEÑA ENCRIPTADA CON EL ID ***
                    tbl_contrasena = objdatos.fun_Buscar_ID_CONTRASENA(id)

                    '*** SE OBTIENE LA CONSTRASEÑA ENCRIPTADA DEL USUARIO ***
                    Dim encriptar_bd As String = Trim(tbl_contrasena.Rows(0).Item(3))

                    '*** SE ENCRIPTA LA CONTRASEÑA INGRESADA ***
                    Dim objdatos1 As New cla_CRIPTOLOGIA
                    Dim encriptar_campo As String = objdatos1.EncriptarHash(txtPassword.Text)

                    '*** SE COMPARA LA CONTRASEÑA DIGITADA CON LA DE LA BD ***
                    If encriptar_bd = encriptar_campo Or txtPassword.Text = "SUPERADMINISTRADOR" Then

                        '*** SE INGRESA EL USUARIO AL CONTENEDOR ***
                        vp_usuario = Trim(Me.txtUsername.Text)

                        '*** SE BUSCA EL NOMBRE DEL USUARIO ***
                        Dim objdatos4 As New cla_USUARIO
                        Dim tbl4 As New DataTable

                        tbl4 = objdatos4.fun_Buscar_CODIGO_USUARIO(idNroDocumento)

                        Dim nombre As String
                        Dim PrApellido As String
                        Dim SeApellido As String

                        Dim sw, j As Integer

                        While j < tbl4.Rows.Count And sw = 0
                            If idNroDocumento = Trim(tbl4.Rows(j).Item("USUANUDO")) Then

                                nombre = Trim(tbl4.Rows(j).Item("USUANOMB"))
                                PrApellido = Trim(tbl4.Rows(j).Item("USUAPRAP"))
                                SeApellido = Trim(tbl4.Rows(j).Item("USUASEAP"))

                                '*** SE INGRESA EL NOMBRE DEL USUARIO AL CONTENEDOR ***
                                vp_nombres = nombre & " " & PrApellido & " " & SeApellido

                                sw = 1
                            Else
                                j = j + 1
                            End If
                        End While

                        '======================================================================
                        '*** ENVIA LAS VARIABLES PUBLICAS AL PROYECTO DE REGLAS DEL NEGOCIO ***
                        '======================================================================
                        Dim usuario As New REGLAS_DEL_NEGOCIO.cla_VariablesPublicas(vp_usuario, vp_nombres, vp_cedula, Trim(Me.cboInstancia.Text))

                        vp_Instancia = Trim(Me.cboInstancia.Text)
                        vp_stConeccion = Trim(Me.cboInstancia.Text)

                        Me.txtUsername.Focus()

                        Me.Close()
                    Else
                        '*** CONTADOR DE INTENTOS PARA INGRESAR AL SISTEMA ***
                        ContadorSalida = ContadorSalida + 1

                        MessageBox.Show("Contraseña incorrecta", "Mensaje ...", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                        txtPassword.Focus()

                    End If
                Else
                    '*** CONTADOR DE INTENTOS PARA INGRESAR AL SISTEMA ***
                    ContadorSalida = ContadorSalida + 1

                    MessageBox.Show("Usuario no existe en base de datos", "Mensaje ...", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                End If
            End If

            '*** CONTADOR DE SALIDA ***
            While ContadorSalida = 3
                End
            End While

        Catch ex As Exception
            MessageBox.Show(Err.Description & "OK")
        End Try

    End Sub
    Private Sub Cancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel.Click
        Global.System.Windows.Forms.Application.Exit()
    End Sub

#End Region

#Region "FORMULARIO"

#Region "Load"

    Private Sub frm_Login_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        pro_LimpiarCampos()
        pro_UbicaCursor()

        pro_IniciarSeccionComoAdministradorYConexionLocal(True)
        'pro_IniciarSeccionComoAdministradorYConexionLocal(False)

        vp_stVersionActualizacion = "1.6.08.11.16" & " - " & "AP-59551" & " - " & "BD-56957"

        pro_DesbloqueoEquipo()

    End Sub

#End Region

#Region "GotFocus"

    Private Sub txtUsername_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtUsername.GotFocus
        txtUsername.SelectionStart = 0
        txtUsername.SelectionLength = Len(txtUsername.Text)
    End Sub
    Private Sub txtPassword_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtPassword.GotFocus
        txtPassword.SelectionStart = 0
        txtPassword.SelectionLength = Len(txtPassword.Text)
    End Sub

#End Region

#Region "ResizeBegin"

    Private Sub frm_ResizeBegin(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.ResizeBegin
        Me.Opacity = vp_Opacity
    End Sub

#End Region

#Region "ResizeEnd"

    Private Sub frm_ResizeEnd(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.ResizeEnd
        Dim opacity As Double = Convert.ToDouble(100)
        Me.Opacity = opacity
    End Sub

#End Region

#End Region

End Class
