Imports REGLAS_DEL_NEGOCIO

Public Class frm_insertar_CONTRASENA

    '===========================
    '*** INSERTAR CONTRASEÑA ***
    '===========================

#Region "VARIABLES LOCALES"

    '*** SW VERIFICAR CAMPOS LLENOS QUE VAN A LA DB ***
    Dim SWVerificarCamposLlenos As Boolean = False

#End Region

#Region "PROCEDIMIENTOS"

    Public Sub pro_inicializarControles()

        Dim objdatos1 As New cla_ESTADO

        cboCONTESTA.DataSource = objdatos1.fun_Consultar_ESTADO_X_ESTADO
        cboCONTESTA.DisplayMember = "ESTADESC"
        cboCONTESTA.ValueMember = "ESTACODI"

    End Sub
    Private Sub pro_VerificarCamposLlenos()
        '*** CAMPOS OBLIGATORIOS ***

        Try
            If Trim(cboCONTNUDO.Text) = "" Or _
               Trim(txtCONTUSUA.Text) = "" Or _
               Trim(cboCONTESTA.Text) = "" Then
                SWVerificarCamposLlenos = False
            Else
                SWVerificarCamposLlenos = True 'Los campos estan bien diligenciados
            End If

        Catch ex As Exception
            MessageBox.Show("" & Err.Description & "")
        End Try

    End Sub
    Private Sub pro_LimpiarCampos()

        txtCONTUSUA.Text = ""
        strBARRESTA.Items(1).Text = ""

    End Sub

#End Region

#Region "MENU"

    Private Sub cmdGUARDAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGUARDAR.Click
        Try
            pro_VerificarCamposLlenos()

            If SWVerificarCamposLlenos = False Then
                mod_MENSAJE.Existen_Campos_Sin_Diligenciar()
                cboCONTNUDO.Focus()
            Else
                Dim idNumeDocu As String = cboCONTNUDO.Text

                Dim objdatos1 As New cla_CONTRASENA
                Dim tbl As New DataTable

                tbl = objdatos1.fun_Buscar_CODIGO_CONTRASENA(idNumeDocu)

                If tbl.Rows.Count > 0 Then
                    MessageBox.Show("Nro. de documento existente en la base de datos", "Mensaje...", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1)
                Else
                    Dim idUsuario As String = txtCONTUSUA.Text

                    Dim objdatos2 As New cla_CONTRASENA
                    Dim tbl2 As New DataTable

                    tbl2 = objdatos2.fun_Buscar_USUARIO_CONTRASENA(idUsuario)

                    If tbl2.Rows.Count > 0 Then
                        MessageBox.Show("Usuario existente en la base de datos", "Mensaje...", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1)
                        cboCONTNUDO.Focus()
                    Else
                        Dim boCONTAGRE As Boolean = False
                        Dim boCONTMODI As Boolean = False
                        Dim boCONTELIM As Boolean = False

                        Dim objdatos5 As New cla_CRIPTOLOGIA
                        Dim encriptar As String = objdatos5.EncriptarHash(txtCONTUSUA.Text)

                        Dim objdatos As New cla_CONTRASENA

                        If (objdatos.fun_Insertar_CONTRASENA(cboCONTNUDO.SelectedValue, txtCONTUSUA.Text, encriptar, cboCONTESTA.SelectedValue, boCONTAGRE, boCONTMODI, boCONTELIM, False, False)) Then
                            mod_MENSAJE.Se_Guardaron_Los_Datos_Correctamente()

                            If MessageBox.Show("¿ Desea agregar otro registro ?", "Mensaje...", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.No Then
                                Me.Close()
                            End If

                            pro_LimpiarCampos()
                            cboCONTNUDO.Focus()
                        Else
                            mod_MENSAJE.No_Se_Guardo_El_Registro_En_La_Base_De_Datos()
                        End If
                    End If
                End If
            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description & "Guardar")
        End Try

    End Sub
    Private Sub cmdCANCELAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCANCELAR.Click
        Me.Close()
    End Sub

#End Region

#Region "FORMULARIO"

    Private Sub frm_insertar_CLASSECT_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        pro_inicializarControles()
        pro_LimpiarCampos()
        cboCONTNUDO.Focus()
    End Sub

    Private Sub cboCONTNUDO_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboCONTNUDO.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            txtCONTUSUA.Focus()
        End If
    End Sub
    Private Sub txtCONTUSUA_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCONTUSUA.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            cboCONTESTA.Focus()
        End If
    End Sub
    Private Sub cboCONTESTA_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboCONTESTA.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            cmdGUARDAR.Focus()
        End If
    End Sub

    Private Sub cboCONTNUDO_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboCONTNUDO.Validated
        If Trim(cboCONTNUDO.Text) = "" Then
            cboCONTNUDO.Focus()
            strBARRESTA.Items(1).Text = IncoValoNulo
        Else
            strBARRESTA.Items(0).Text = ""
            strBARRESTA.Items(1).Text = ""
        End If
    End Sub
    Private Sub txtCONTUSUA_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCONTUSUA.Validated
        If Trim(txtCONTUSUA.Text) = "" Then
            txtCONTUSUA.Focus()
            strBARRESTA.Items(1).Text = IncoValoNulo
        Else
            strBARRESTA.Items(0).Text = ""
            strBARRESTA.Items(1).Text = ""
        End If
    End Sub

    Private Sub cboCONTNUDO_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboCONTNUDO.GotFocus
        strBARRESTA.Items(0).Text = cboCONTNUDO.AccessibleDescription
    End Sub
    Private Sub txtCONTUSUA_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCONTUSUA.GotFocus
        txtCONTUSUA.SelectionStart = 0
        txtCONTUSUA.SelectionLength = Len(txtCONTUSUA.Text)
        strBARRESTA.Items(0).Text = txtCONTUSUA.AccessibleDescription
    End Sub
    Private Sub cboCONTESTA_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboCONTESTA.GotFocus
        strBARRESTA.Items(0).Text = cboCONTESTA.AccessibleDescription
    End Sub
    Private Sub cmdGUARDAR_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdGUARDAR.GotFocus
        strBARRESTA.Items(0).Text = cmdGUARDAR.AccessibleDescription
    End Sub
    Private Sub cmdCANCELAR_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdCANCELAR.GotFocus
        strBARRESTA.Items(0).Text = cmdCANCELAR.AccessibleDescription
    End Sub

    Private Sub cboCONTNUDO_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboCONTNUDO.Click
        Dim objdatos As New cla_USUARIO

        cboCONTNUDO.DataSource = objdatos.fun_Consultar_USUARIO_X_ESTADO
        cboCONTNUDO.DisplayMember = "USUANUDO"
        cboCONTNUDO.ValueMember = "USUANUDO"

    End Sub

    Private Sub cboCONTNUDO_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCONTNUDO.SelectedIndexChanged
        Dim objdatos As New cla_USUARIO
        Dim tbl As New DataTable

        Dim idNroDocumento As String = Trim(cboCONTNUDO.Text)
        tbl = objdatos.fun_Buscar_CODIGO_USUARIO(idNroDocumento)

        Dim nombre As String
        Dim PrApellido As String
        Dim SeApellido As String

        Dim sw, j As Integer

        While j < tbl.Rows.Count And sw = 0
            If cboCONTNUDO.Text = tbl.Rows(j).Item("USUANUDO") Then

                nombre = Trim(tbl.Rows(j).Item("USUANOMB"))
                PrApellido = Trim(tbl.Rows(j).Item("USUAPRAP"))
                SeApellido = Trim(tbl.Rows(j).Item("USUASEAP"))

                lblCONTNOMB.Text = nombre & " " & PrApellido & " " & SeApellido

                sw = 1
            Else
                j = j + 1
            End If
        End While

    End Sub

#End Region


End Class