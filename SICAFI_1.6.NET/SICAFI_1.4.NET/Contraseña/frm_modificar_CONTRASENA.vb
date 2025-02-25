Imports REGLAS_DEL_NEGOCIO

Public Class frm_modificar_CONTRASENA

    '============================
    '*** MODIFICAR CONTRASEÑA ***
    '============================

    Dim id As Integer

    Public Sub New(ByVal idPersona As Integer)
        id = idPersona
        InitializeComponent()
        pro_inicializarControles()

    End Sub

#Region "VARIABLES LOCALES"

    '*** SW VERIFICAR CAMPOS LLENOS QUE VAN A LA DB ***
    Dim SWVerificarCamposLlenos As Boolean = False

#End Region

#Region "PROCEDIMIENTOS"

    Public Sub pro_inicializarControles()
        Dim objdatos As New cla_ESTADO

        cboCONTESTA.DataSource = objdatos.fun_Consultar_ESTADO_X_ESTADO
        cboCONTESTA.DisplayMember = "ESTADESC"
        cboCONTESTA.ValueMember = "ESTACODI"

        Dim objdatos1 As New cla_USUARIO

        cboCONTNUDO.DataSource = objdatos1.fun_Consultar_USUARIO_X_ESTADO
        cboCONTNUDO.DisplayMember = "USUANUDO"
        cboCONTNUDO.ValueMember = "USUANUDO"

        Dim objdatos2 As New cla_CONTRASENA
        Dim tbl As New DataTable

        tbl = objdatos2.fun_Buscar_ID_CONTRASENA(id)

        cboCONTNUDO.SelectedValue = tbl.Rows(0).Item(1)
        txtCONTUSUA.Text = Trim(tbl.Rows(0).Item(2))
        cboCONTESTA.SelectedValue = tbl.Rows(0).Item(4)

        '=======================================================
        '*** CARGA EL lblCONTNUDO CON EL CODIGO SELECCIONADO ***
        '=======================================================
        Try

            Dim objdatos4 As New cla_USUARIO
            Dim tbl4 As New DataTable

            Dim idNroDocumento As String = Trim(cboCONTNUDO.SelectedValue)
            tbl4 = objdatos4.fun_Buscar_CODIGO_USUARIO(idNroDocumento)

            Dim nombre As String
            Dim PrApellido As String
            Dim SeApellido As String

            Dim sw, j As Integer

            While j < tbl4.Rows.Count And sw = 0
                If cboCONTNUDO.SelectedValue = tbl4.Rows(j).Item("USUANUDO") Then

                    nombre = Trim(tbl4.Rows(j).Item("USUANOMB"))
                    PrApellido = Trim(tbl4.Rows(j).Item("USUAPRAP"))
                    SeApellido = Trim(tbl4.Rows(j).Item("USUASEAP"))

                    lblCONTNOMB.Text = nombre & " " & PrApellido & " " & SeApellido

                    sw = 1
                Else
                    j = j + 1
                End If
            End While

        Catch ex As Exception
            frm_INCO_modifircar_registros_sin_listas_de_valores.ShowDialog()
        End Try

        txtCONTCONT.Focus()

    End Sub
    Private Sub pro_VerificarCamposLlenos()
        '*** CAMPOS OBLIGATORIOS ***

        Try
            If Trim(cboCONTNUDO.Text) = "" Or _
               Trim(txtCONTUSUA.Text) = "" Or _
               Trim(txtCONTCONT.Text) = "" Or _
               Trim(txtCONTCONU.Text) = "" Or _
               Trim(txtCONTVECO.Text) = "" Or _
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

        txtCONTCONT.Text = ""
        txtCONTCONU.Text = ""
        txtCONTVECO.Text = ""
        strBARRESTA.Items(1).Text = ""

    End Sub

#End Region

#Region "MENU"

    Private Sub cmdGUARDAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGUARDAR.Click
        Try
            pro_VerificarCamposLlenos()

            If SWVerificarCamposLlenos = True Then
                '====================================================
                '*** COMPARA LA CONTRASEÑA ACTUAL CON LA DIGITADA ***
                '====================================================

                Dim objdatos1 As New cla_CRIPTOLOGIA
                Dim encriptar_campo As String = objdatos1.EncriptarHash(txtCONTCONT.Text)

                Dim objdatos As New cla_CONTRASENA
                Dim tbl As New DataTable

                tbl = objdatos.fun_Buscar_ID_CONTRASENA(id)
                Dim encriptar_bd As String = Trim(tbl.Rows(0).Item(3))

                If encriptar_campo = encriptar_bd Then
                    If Trim(txtCONTCONU.Text) = Trim(txtCONTVECO.Text) Then

                        Dim boCONTAGRE As Boolean = tbl.Rows(0).Item(5)
                        Dim boCONTMODI As Boolean = tbl.Rows(0).Item(6)
                        Dim boCONTELIM As Boolean = tbl.Rows(0).Item(7)
                        Dim boCONTCOFP As Boolean = tbl.Rows(0).Item(8)
                        Dim boCONTCOSI As Boolean = tbl.Rows(0).Item(9)

                        Dim objdatos3 As New cla_CRIPTOLOGIA
                        Dim encriptar As String = objdatos3.EncriptarHash(txtCONTCONU.Text)

                        If (objdatos.fun_Actualizar_CONTRASENA(id, cboCONTNUDO.SelectedValue, txtCONTUSUA.Text, encriptar, cboCONTESTA.SelectedValue, boCONTAGRE, boCONTMODI, boCONTELIM, boCONTCOFP, boCONTCOSI)) Then
                            mod_MENSAJE.Se_Modificaron_Los_Datos_Correctamente()
                            Me.Close()
                        Else
                            mod_MENSAJE.No_Se_Modifico_El_Registro_En_La_Base_De_Datos()
                        End If
                    Else
                        MessageBox.Show("La contraseña nueva es diferente a la verificación de constraseña", "Mensaje error", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1)
                        txtCONTCONU.Focus()
                    End If
                Else
                    MessageBox.Show("La contraseña actual es diferente a la existente en la base de datos", "Mensaje error", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1)
                    txtCONTCONT.Focus()
                End If
            Else
                mod_MENSAJE.Existen_Campos_Sin_Diligenciar()
                txtCONTCONT.Focus()
            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description & "Modificar")
        End Try


    End Sub
    Private Sub cmdCANCELAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCANCELAR.Click
        Me.Close()
    End Sub

#End Region

#Region "FORMULARIO"

    Private Sub txtCONTCONT_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCONTCONT.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            txtCONTCONU.Focus()
        End If
    End Sub
    Private Sub txtCONTCONU_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCONTCONU.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            txtCONTVECO.Focus()
        End If
    End Sub
    Private Sub txtCONTVECO_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCONTVECO.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            'cboCONTESTA.Focus()
            cmdGUARDAR.Focus()
        End If
    End Sub
    Private Sub cboCONTESTA_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboCONTESTA.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            cmdGUARDAR.Focus()
        End If
    End Sub

    Private Sub txtCONTCONT_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCONTCONT.Validated
        If Trim(txtCONTCONT.Text) = "" Then
            txtCONTCONT.Focus()
            strBARRESTA.Items(1).Text = IncoValoNulo
        Else
            strBARRESTA.Items(0).Text = ""
            strBARRESTA.Items(1).Text = ""
        End If
    End Sub
    Private Sub txtCONTCONU_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCONTCONU.Validated
        If Trim(txtCONTCONU.Text) = "" Then
            txtCONTCONU.Focus()
            strBARRESTA.Items(1).Text = IncoValoNulo
        Else
            strBARRESTA.Items(0).Text = ""
            strBARRESTA.Items(1).Text = ""
        End If
    End Sub
    Private Sub txtCONTVECO_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCONTVECO.Validated
        If Trim(txtCONTVECO.Text) = "" Then
            txtCONTVECO.Focus()
            strBARRESTA.Items(1).Text = IncoValoNulo
        Else
            strBARRESTA.Items(0).Text = ""
            strBARRESTA.Items(1).Text = ""
        End If
    End Sub
    Private Sub cboCONTESTA_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboCONTESTA.Validated
        strBARRESTA.Items(0).Text = ""
        strBARRESTA.Items(1).Text = ""
    End Sub

    Private Sub txtCONTCONT_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCONTCONT.GotFocus
        txtCONTCONT.SelectionStart = 0
        txtCONTCONT.SelectionLength = Len(txtCONTCONT.Text)
        strBARRESTA.Items(0).Text = txtCONTCONT.AccessibleDescription
    End Sub
    Private Sub txtCONTCONU_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCONTCONU.GotFocus
        txtCONTCONU.SelectionStart = 0
        txtCONTCONU.SelectionLength = Len(txtCONTCONU.Text)
        strBARRESTA.Items(0).Text = txtCONTCONU.AccessibleDescription
    End Sub
    Private Sub txtCONTVECO_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCONTVECO.GotFocus
        txtCONTVECO.SelectionStart = 0
        txtCONTVECO.SelectionLength = Len(txtCONTVECO.Text)
        strBARRESTA.Items(0).Text = txtCONTVECO.AccessibleDescription
    End Sub
    Private Sub cboCONTESTA_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboCONTESTA.GotFocus
        cboCONTESTA.SelectionStart = 0
        cboCONTESTA.SelectionLength = Len(cboCONTESTA.Text)
        strBARRESTA.Items(0).Text = cboCONTESTA.AccessibleDescription
    End Sub
    Private Sub cmdGUARDAR_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdGUARDAR.GotFocus
        strBARRESTA.Items(0).Text = cmdGUARDAR.AccessibleDescription
    End Sub
    Private Sub cmdCANCELAR_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdCANCELAR.GotFocus
        strBARRESTA.Items(0).Text = cmdCANCELAR.AccessibleDescription
    End Sub

#End Region

End Class