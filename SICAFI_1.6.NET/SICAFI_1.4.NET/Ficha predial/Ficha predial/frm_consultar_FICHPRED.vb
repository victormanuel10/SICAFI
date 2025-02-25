Imports REGLAS_DEL_NEGOCIO

Public Class frm_consultar_FICHPRED

    '===============================
    '*** CONSULTAR FICHA PREDIAL ***
    '===============================

#Region "VARIABLES LOCALES"

    '*** SW VERIFICAR CAMPOS LLENOS QUE VAN A LA DB ***
    Dim SWVerificarCamposLlenos As Boolean = False

    '*** VARIABLES DE LA MASCARA DE LA CEDULA CATASTRAL ***
    Dim Mascara As Integer
    Dim Formato As String

#End Region

#Region "PROCEDIMIENTOS"

    Private Sub pro_InicializarComponentes()
        Dim objdatos2 As New cla_CLASSECT

        cboFIPRCLSE.DataSource = objdatos2.fun_Consultar_MANT_CLASSECT_X_ESTADO
        cboFIPRCLSE.DisplayMember = "CLSECODI"
        cboFIPRCLSE.ValueMember = "CLSECODI"

    End Sub
    Private Sub pro_LimpiarCampos()

        txtFIPRNUFI.Text = ""
        txtFIPRDIRE.Text = ""
        txtFIPRNUDO.Text = ""
        txtFIPRMAIN.Text = ""
        txtFIPRMUNI.Text = ""
        txtFIPRCORR.Text = ""
        txtFIPRBARR.Text = ""
        txtFIPRMANZ.Text = ""
        txtFIPRPRED.Text = ""

        Me.dgvFICHPRED.DataSource = New DataTable
       
    End Sub

#End Region

#Region "MENU"

    Private Sub cmdCONSULTAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCONSULTAR.Click
        Try
            If rbdFIPRNUFI.Checked = True Then
                If Trim(txtFIPRNUFI.Text) = "" Then
                    MessageBox.Show("Ingrese el numero de ficha predial", "Mensaje ...", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                    txtFIPRNUFI.Focus()
                Else
                    Dim frm_FICHPRED As New frm_FICHPRED(Val(txtFIPRNUFI.Text))
                    pro_LimpiarCampos()
                    txtFIPRNUFI.Focus()
                    Me.Close()
                End If

            ElseIf rbdFIPRDIRE.Checked = True Then
                If Trim(txtFIPRDIRE.Text) = "" Then
                    MessageBox.Show("Ingrese la dirección", "Mensaje ...", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                    txtFIPRDIRE.Focus()
                Else
                    Dim objdatos As New cla_FICHPRED

                    BindingSource_FICHPRED_1.DataSource = objdatos.fun_Buscar_DIRECCION_FICHPRED(Trim(txtFIPRDIRE.Text))
                    dgvFICHPRED.DataSource = BindingSource_FICHPRED_1
                    BindingNavigator_FICHPRED_1.BindingSource = BindingSource_FICHPRED_1

                    strBARRESTA.Items(2).Text = "Registros : " & BindingSource_FICHPRED_1.Count

                    If BindingSource_FICHPRED_1.Count = 0 Then
                        MessageBox.Show("No se encontraron registros", "Mensaje ...", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                        txtFIPRDIRE.Focus()
                    End If

                End If

            ElseIf rbdFIPRNUDO.Checked = True Then
                If Trim(txtFIPRNUDO.Text) = "" Then
                    MessageBox.Show("Ingrese el numero de documento", "Mensaje ...", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                    txtFIPRNUDO.Focus()
                Else
                    Dim objdatos As New cla_FIPRPROP

                    BindingSource_FICHPRED_1.DataSource = objdatos.fun_Buscar_DOCUMENTO_FIPRPROP(Trim(txtFIPRNUDO.Text))
                    dgvFICHPRED.DataSource = BindingSource_FICHPRED_1
                    BindingNavigator_FICHPRED_1.BindingSource = BindingSource_FICHPRED_1

                    strBARRESTA.Items(2).Text = "Registros : " & BindingSource_FICHPRED_1.Count

                    If BindingSource_FICHPRED_1.Count = 0 Then
                        MessageBox.Show("No se encontraron registros", "Mensaje ...", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                        txtFIPRNUDO.Focus()
                    End If

                End If
            ElseIf rbdFIPRMAIN.Checked = True Then
                If Trim(txtFIPRMAIN.Text) = "" Then
                    MessageBox.Show("Ingrese la matricula inmobiliaria", "Mensaje ...", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                    txtFIPRMAIN.Focus()
                Else
                    Dim objdatos As New cla_FIPRPROP

                    BindingSource_FICHPRED_1.DataSource = objdatos.fun_Buscar_MATRICULA_FIPRPROP(Trim(txtFIPRMAIN.Text))
                    dgvFICHPRED.DataSource = BindingSource_FICHPRED_1
                    BindingNavigator_FICHPRED_1.BindingSource = BindingSource_FICHPRED_1

                    strBARRESTA.Items(2).Text = "Registros : " & BindingSource_FICHPRED_1.Count

                    If BindingSource_FICHPRED_1.Count = 0 Then
                        MessageBox.Show("No se encontraron registros", "Mensaje ...", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                        txtFIPRMAIN.Focus()
                    End If

                End If

            ElseIf rbdFIPRCECA.Checked = True Then
                If Trim(txtFIPRMUNI.Text) = "" Or _
                   Trim(txtFIPRCORR.Text) = "" Or _
                   Trim(txtFIPRBARR.Text) = "" Or _
                   Trim(txtFIPRMANZ.Text) = "" Or _
                   Trim(txtFIPRPRED.Text) = "" Or _
                   Trim(cboFIPRCLSE.Text) = "" Then
                    MessageBox.Show("Ingrese la cedula catastral completa", "Mensaje ...", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                    txtFIPRMUNI.Focus()
                Else
                    Dim objdatos As New cla_FICHPRED

                    BindingSource_FICHPRED_1.DataSource = objdatos.fun_Buscar_CEDULA_CATASTRAL_FICHPRED(txtFIPRMUNI.Text, txtFIPRCORR.Text, txtFIPRBARR.Text, txtFIPRMANZ.Text, txtFIPRPRED.Text, cboFIPRCLSE.SelectedValue)
                    dgvFICHPRED.DataSource = BindingSource_FICHPRED_1
                    BindingNavigator_FICHPRED_1.BindingSource = BindingSource_FICHPRED_1

                    strBARRESTA.Items(2).Text = "Registros : " & BindingSource_FICHPRED_1.Count

                    If BindingSource_FICHPRED_1.Count = 0 Then
                        MessageBox.Show("No se encontraron registros", "Mensaje ...", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                        txtFIPRMUNI.Focus()
                    End If

                End If

            End If


        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub cmdACEPTAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdACEPTAR.Click
        Try
            If rbdFIPRNUFI.Checked = True Then
                If Trim(txtFIPRNUFI.Text) = "" Then
                    MessageBox.Show("Ingrese el numero de ficha predial", "Mensaje ...", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                    txtFIPRNUFI.Focus()
                Else
                    Dim objdatos As New cla_FICHPRED
                    Dim tbl As New DataTable

                    tbl = objdatos.fun_Consultar_FICHA_PREDIAL_X_NRO_FICHA_PREDIAL(Val(txtFIPRNUFI.Text))

                    If tbl.Rows.Count > 0 Then
                        Dim frm_FICHPRED As New frm_FICHPRED(Val(txtFIPRNUFI.Text))
                        pro_LimpiarCampos()
                        rbdFIPRNUFI.Checked = True
                        txtFIPRNUFI.Focus()
                        Me.Close()
                    Else
                        MessageBox.Show("No se encontro ningún registros", "Mensaje ..", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                        txtFIPRNUFI.Focus()
                    End If

                End If

            ElseIf rbdFIPRDIRE.Checked = True Then
                If Trim(txtFIPRDIRE.Text) = "" Then
                    MessageBox.Show("Ingrese la dirección", "Mensaje ...", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                    txtFIPRDIRE.Focus()
                Else
                    If Me.dgvFICHPRED.RowCount > 0 Then
                        Dim frm_FICHPRED As New frm_FICHPRED(Integer.Parse(dgvFICHPRED.CurrentRow.Cells(0).Value.ToString()))
                        pro_LimpiarCampos()
                        rbdFIPRDIRE.Checked = True
                        txtFIPRDIRE.Focus()
                        Me.Close()
                    Else
                        mod_MENSAJE.No_Existe_Un_Registro_Seleccionado()
                    End If
                End If

            ElseIf rbdFIPRNUDO.Checked = True Then
                If Trim(txtFIPRNUDO.Text) = "" Then
                    MessageBox.Show("Ingrese el numero de documento", "Mensaje ...", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                    txtFIPRNUDO.Focus()
                Else
                    If Me.dgvFICHPRED.RowCount > 0 Then
                        Dim frm_FICHPRED As New frm_FICHPRED(Integer.Parse(dgvFICHPRED.CurrentRow.Cells(0).Value.ToString()))
                        pro_LimpiarCampos()
                        rbdFIPRNUDO.Checked = True
                        txtFIPRNUDO.Focus()
                        Me.Close()
                    Else
                        mod_MENSAJE.No_Existe_Un_Registro_Seleccionado()
                    End If
                End If

            ElseIf rbdFIPRMAIN.Checked = True Then
                If Trim(txtFIPRMAIN.Text) = "" Then
                    MessageBox.Show("Ingrese la matricula inmobiliaria", "Mensaje ...", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                    txtFIPRMAIN.Focus()
                Else
                    If Me.dgvFICHPRED.RowCount > 0 Then
                        Dim frm_FICHPRED As New frm_FICHPRED(Integer.Parse(dgvFICHPRED.CurrentRow.Cells(0).Value.ToString()))
                        pro_LimpiarCampos()
                        rbdFIPRMAIN.Checked = True
                        txtFIPRMAIN.Focus()
                        Me.Close()
                    Else
                        mod_MENSAJE.No_Existe_Un_Registro_Seleccionado()
                    End If
                End If

            ElseIf rbdFIPRCECA.Checked = True Then
                If Trim(txtFIPRMUNI.Text) = "" Or _
                   Trim(txtFIPRCORR.Text) = "" Or _
                   Trim(txtFIPRBARR.Text) = "" Or _
                   Trim(txtFIPRMANZ.Text) = "" Or _
                   Trim(txtFIPRPRED.Text) = "" Or _
                   Trim(cboFIPRCLSE.Text) = "" Then
                    MessageBox.Show("Ingrese la cedula catastral completa", "Mensaje ...", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                    txtFIPRMUNI.Focus()
                Else
                    If Me.dgvFICHPRED.RowCount > 0 Then
                        Dim frm_FICHPRED As New frm_FICHPRED(Integer.Parse(dgvFICHPRED.CurrentRow.Cells(0).Value.ToString()))
                        pro_LimpiarCampos()
                        rbdFIPRCECA.Checked = True
                        txtFIPRMUNI.Focus()
                        Me.Close()
                    Else
                        mod_MENSAJE.No_Existe_Un_Registro_Seleccionado()
                    End If
                End If
            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub cmdCANCELAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSALIR.Click
        Dim frm_FICHPRED As New frm_FICHPRED(0)
        txtFIPRNUFI.Focus()
        Me.Close()
    End Sub

#End Region

#Region "FORMULARIO"

    Private Sub frm_consultar_FICHPRED_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        pro_InicializarComponentes()
        pro_LimpiarCampos()
        txtFIPRNUFI.Focus()
    End Sub

    Private Sub rbdFIPRNUFI_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbdFIPRNUFI.CheckedChanged
        Try

            If rbdFIPRNUFI.Checked = True Then
                Dim objdatos As New cla_FICHPRED

                BindingSource_FICHPRED_1.DataSource = objdatos.fun_Buscar_DIRECCION_FICHPRED("")
                dgvFICHPRED.DataSource = BindingSource_FICHPRED_1
                BindingNavigator_FICHPRED_1.BindingSource = BindingSource_FICHPRED_1

                strBARRESTA.Items(2).Text = "Registros : " & BindingSource_FICHPRED_1.Count

                pro_LimpiarCampos()

                'fraFIPRNUFI.Visible = True
                'fraFIPRDIRE.Visible = False
                'fraFIPRNUDO.Visible = False
                'fraFIPRMAIN.Visible = False
                'fraFIPRCECA.Visible = False
                cmdCONSULTAR.Enabled = False
                cmdACEPTAR.Enabled = True

                txtFIPRNUFI.Focus()
            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub rbdFIPRDIRE_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbdFIPRDIRE.CheckedChanged
        Try
            If rbdFIPRDIRE.Checked = True Then
                Dim objdatos As New cla_FICHPRED

                BindingSource_FICHPRED_1.DataSource = objdatos.fun_Buscar_DIRECCION_FICHPRED("")
                dgvFICHPRED.DataSource = BindingSource_FICHPRED_1
                BindingNavigator_FICHPRED_1.BindingSource = BindingSource_FICHPRED_1

                strBARRESTA.Items(2).Text = "Registros : " & BindingSource_FICHPRED_1.Count

                pro_LimpiarCampos()

                'fraFIPRNUFI.Visible = False
                'fraFIPRDIRE.Visible = True
                'fraFIPRNUDO.Visible = False
                'fraFIPRMAIN.Visible = False
                'fraFIPRCECA.Visible = False
                cmdCONSULTAR.Enabled = True

                txtFIPRDIRE.Focus()
            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub rbdFIPRNUDO_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbdFIPRNUDO.CheckedChanged
        Try
            If rbdFIPRNUDO.Checked = True Then
                Dim objdatos As New cla_FICHPRED

                BindingSource_FICHPRED_1.DataSource = objdatos.fun_Buscar_DIRECCION_FICHPRED("")
                dgvFICHPRED.DataSource = BindingSource_FICHPRED_1
                BindingNavigator_FICHPRED_1.BindingSource = BindingSource_FICHPRED_1

                strBARRESTA.Items(2).Text = "Registros : " & BindingSource_FICHPRED_1.Count

                pro_LimpiarCampos()

                'fraFIPRNUFI.Visible = False
                'fraFIPRDIRE.Visible = False
                'fraFIPRNUDO.Visible = True
                'fraFIPRMAIN.Visible = False
                'fraFIPRCECA.Visible = False
                cmdCONSULTAR.Enabled = True

                txtFIPRNUDO.Focus()
            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub rbdFIPRMAIN_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbdFIPRMAIN.CheckedChanged
        Try
            If rbdFIPRMAIN.Checked = True Then
                Dim objdatos As New cla_FICHPRED

                BindingSource_FICHPRED_1.DataSource = objdatos.fun_Buscar_DIRECCION_FICHPRED("")
                dgvFICHPRED.DataSource = BindingSource_FICHPRED_1
                BindingNavigator_FICHPRED_1.BindingSource = BindingSource_FICHPRED_1

                strBARRESTA.Items(2).Text = "Registros : " & BindingSource_FICHPRED_1.Count

                pro_LimpiarCampos()

                'fraFIPRNUFI.Visible = False
                'fraFIPRDIRE.Visible = False
                'fraFIPRNUDO.Visible = False
                'fraFIPRMAIN.Visible = True
                'fraFIPRCECA.Visible = False
                cmdCONSULTAR.Enabled = True

                txtFIPRMAIN.Focus()
            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub rbdFIPRCECA_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbdFIPRCECA.CheckedChanged
        Try
            If rbdFIPRCECA.Checked = True Then
                Dim objdatos As New cla_FICHPRED

                BindingSource_FICHPRED_1.DataSource = objdatos.fun_Buscar_DIRECCION_FICHPRED("")
                dgvFICHPRED.DataSource = BindingSource_FICHPRED_1
                BindingNavigator_FICHPRED_1.BindingSource = BindingSource_FICHPRED_1

                strBARRESTA.Items(2).Text = "Registros : " & BindingSource_FICHPRED_1.Count

                pro_LimpiarCampos()

                'fraFIPRNUFI.Visible = False
                'fraFIPRDIRE.Visible = False
                'fraFIPRNUDO.Visible = False
                'fraFIPRMAIN.Visible = False
                fraFIPRCECA.Visible = True
                cmdCONSULTAR.Enabled = True

                If cboFIPRCLSE.Text <> "" Then
                    lblFIPRCLSE.Text = CType(fun_Buscar_Lista_Valores_CLASSECT(cboFIPRCLSE.Text), String)
                End If

                txtFIPRMUNI.Focus()
            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try
    End Sub

    Private Sub txtFIPRNUFI_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFIPRNUFI.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            cmdACEPTAR.Focus()
        End If

    End Sub
    Private Sub txtFIPRDIRE_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFIPRDIRE.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            cmdCONSULTAR.Focus()
        End If
    End Sub
    Private Sub txtFIPRNUDO_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFIPRNUDO.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            cmdCONSULTAR.Focus()
        End If
    End Sub
    Private Sub txtFIPRMAIN_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFIPRMAIN.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            cmdCONSULTAR.Focus()
        End If
    End Sub
    Private Sub txtFIPRMUNI_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFIPRMUNI.KeyPress
        If Not Char.IsNumber(e.KeyChar) Then
            If e.KeyChar <> Convert.ToChar(Keys.Back) Then
                If e.KeyChar <> Convert.ToChar(Keys.Enter) Then
                    e.Handled = True
                    strBARRESTA.Items(1).Text = IncoValoNume
                    mod_MENSAJE.Inco_Valo_Nume()
                Else
                    txtFIPRCORR.Focus()
                End If
            End If
        End If
    End Sub
    Private Sub txtFIPRCORR_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFIPRCORR.KeyPress
        If Not Char.IsNumber(e.KeyChar) Then
            If e.KeyChar <> Convert.ToChar(Keys.Back) Then
                If e.KeyChar <> Convert.ToChar(Keys.Enter) Then
                    e.Handled = True
                    strBARRESTA.Items(1).Text = IncoValoNume
                    mod_MENSAJE.Inco_Valo_Nume()
                Else
                    txtFIPRBARR.Focus()
                End If
            End If
        End If
    End Sub
    Private Sub txtFIPRBARR_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFIPRBARR.KeyPress
        If Not Char.IsNumber(e.KeyChar) Then
            If e.KeyChar <> Convert.ToChar(Keys.Back) Then
                If e.KeyChar <> Convert.ToChar(Keys.Enter) Then
                    e.Handled = True
                    strBARRESTA.Items(1).Text = IncoValoNume
                    mod_MENSAJE.Inco_Valo_Nume()
                Else
                    txtFIPRMANZ.Focus()
                End If
            End If
        End If
    End Sub
    Private Sub txtFIPRMANZ_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFIPRMANZ.KeyPress
        If Not Char.IsNumber(e.KeyChar) Then
            If e.KeyChar <> Convert.ToChar(Keys.Back) Then
                If e.KeyChar <> Convert.ToChar(Keys.Enter) Then
                    e.Handled = True
                    strBARRESTA.Items(1).Text = IncoValoNume
                    mod_MENSAJE.Inco_Valo_Nume()
                Else
                    txtFIPRPRED.Focus()
                End If
            End If
        End If
    End Sub
    Private Sub txtFIPRPRED_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFIPRPRED.KeyPress
        If Not Char.IsNumber(e.KeyChar) Then
            If e.KeyChar <> Convert.ToChar(Keys.Back) Then
                If e.KeyChar <> Convert.ToChar(Keys.Enter) Then
                    e.Handled = True
                    strBARRESTA.Items(1).Text = IncoValoNume
                    mod_MENSAJE.Inco_Valo_Nume()
                Else
                    cboFIPRCLSE.Focus()
                End If
            End If
        End If
    End Sub
    Private Sub cboFIPRCLSE_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboFIPRCLSE.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            cmdCONSULTAR.Focus()
        End If
    End Sub

    Private Sub txtFIPRNUFI_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFIPRNUFI.GotFocus
        txtFIPRNUFI.SelectionStart = 0
        txtFIPRNUFI.SelectionLength = Len(txtFIPRNUFI.Text)
        strBARRESTA.Items(0).Text = txtFIPRNUFI.AccessibleDescription

        rbdFIPRNUFI.Checked = True
    End Sub
    Private Sub txtFIPRDIRE_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFIPRDIRE.GotFocus
        txtFIPRDIRE.SelectionStart = 0
        txtFIPRDIRE.SelectionLength = Len(txtFIPRDIRE.Text)
        strBARRESTA.Items(0).Text = txtFIPRDIRE.AccessibleDescription

        rbdFIPRDIRE.Checked = True

    End Sub
    Private Sub txtFIPRNUDO_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFIPRNUDO.GotFocus
        txtFIPRNUDO.SelectionStart = 0
        txtFIPRNUDO.SelectionLength = Len(txtFIPRNUDO.Text)
        strBARRESTA.Items(0).Text = txtFIPRNUDO.AccessibleDescription

        rbdFIPRNUDO.Checked = True

    End Sub
    Private Sub txtFIPRMAIN_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFIPRMAIN.GotFocus
        txtFIPRMAIN.SelectionStart = 0
        txtFIPRMAIN.SelectionLength = Len(txtFIPRMAIN.Text)
        strBARRESTA.Items(0).Text = txtFIPRMAIN.AccessibleDescription

        rbdFIPRMAIN.Checked = True

    End Sub
    Private Sub txtFIPRMUNI_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFIPRMUNI.GotFocus
        txtFIPRMUNI.SelectionStart = 0
        txtFIPRMUNI.SelectionLength = Len(txtFIPRMUNI.Text)
        strBARRESTA.Items(0).Text = txtFIPRMUNI.AccessibleDescription

        rbdFIPRCECA.Checked = True

    End Sub
    Private Sub txtFIPRCORR_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFIPRCORR.GotFocus
        txtFIPRCORR.SelectionStart = 0
        txtFIPRCORR.SelectionLength = Len(txtFIPRCORR.Text)
        strBARRESTA.Items(0).Text = txtFIPRCORR.AccessibleDescription

        rbdFIPRCECA.Checked = True

    End Sub
    Private Sub txtFIPRBARR_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFIPRBARR.GotFocus
        txtFIPRBARR.SelectionStart = 0
        txtFIPRBARR.SelectionLength = Len(txtFIPRBARR.Text)
        strBARRESTA.Items(0).Text = txtFIPRBARR.AccessibleDescription

        rbdFIPRCECA.Checked = True

    End Sub
    Private Sub txtFIPRMANZ_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFIPRMANZ.GotFocus
        txtFIPRMANZ.SelectionStart = 0
        txtFIPRMANZ.SelectionLength = Len(txtFIPRMANZ.Text)
        strBARRESTA.Items(0).Text = txtFIPRMANZ.AccessibleDescription

        rbdFIPRCECA.Checked = True

    End Sub
    Private Sub txtFIPRPRED_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFIPRPRED.GotFocus
        txtFIPRPRED.SelectionStart = 0
        txtFIPRPRED.SelectionLength = Len(txtFIPRPRED.Text)
        strBARRESTA.Items(0).Text = txtFIPRPRED.AccessibleDescription

        rbdFIPRCECA.Checked = True


    End Sub
    Private Sub cmdCONSULTAR_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdCONSULTAR.GotFocus
        strBARRESTA.Items(0).Text = cmdCONSULTAR.AccessibleDescription
    End Sub
    Private Sub cmdACEPTAR_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdACEPTAR.GotFocus
        strBARRESTA.Items(0).Text = cmdACEPTAR.AccessibleDescription
    End Sub
    Private Sub cmdCANCELAR_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdSALIR.GotFocus
        strBARRESTA.Items(0).Text = cmdSALIR.AccessibleDescription
    End Sub

    Private Sub txtFIPRNUFI_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFIPRNUFI.Validated
        Try
            strBARRESTA.Items(0).Text = ""
            strBARRESTA.Items(1).Text = ""

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try
    End Sub
    Private Sub txtFIPRDIRE_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFIPRDIRE.Validated
        Try
            strBARRESTA.Items(0).Text = ""
            strBARRESTA.Items(1).Text = ""

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try
    End Sub
    Private Sub txtFIPRNUDO_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFIPRNUDO.Validated
        Try
            strBARRESTA.Items(0).Text = ""
            strBARRESTA.Items(1).Text = ""

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try
    End Sub
    Private Sub txtFIPRMAIN_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFIPRMAIN.Validated
        Try
            strBARRESTA.Items(0).Text = ""
            strBARRESTA.Items(1).Text = ""

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try
    End Sub
    Private Sub txtFIPRMUNI_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFIPRMUNI.Validated

        If Trim(txtFIPRMUNI.Text) <> "" Then
            Mascara = Val(txtFIPRMUNI.Text)
            Formato = Format(Mascara, "000")
            txtFIPRMUNI.Text = Formato
        End If

        strBARRESTA.Items(0).Text = ""
        strBARRESTA.Items(1).Text = ""

    End Sub
    Private Sub txtFIPRCORR_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFIPRCORR.Validated

        If Trim(txtFIPRCORR.Text) <> "" Then
            Mascara = Val(txtFIPRCORR.Text)
            Formato = Format(Mascara, "00")
            txtFIPRCORR.Text = Formato
        End If

        strBARRESTA.Items(0).Text = ""
        strBARRESTA.Items(1).Text = ""

    End Sub
    Private Sub txtFIPRBARR_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFIPRBARR.Validated

        If Trim(txtFIPRBARR.Text) <> "" Then
            Mascara = Val(txtFIPRBARR.Text)
            Formato = Format(Mascara, "000")
            txtFIPRBARR.Text = Formato
        End If

        strBARRESTA.Items(0).Text = ""
        strBARRESTA.Items(1).Text = ""

    End Sub
    Private Sub txtFIPRMANZ_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFIPRMANZ.Validated

        If Trim(txtFIPRMANZ.Text) <> "" Then
            Mascara = Val(txtFIPRMANZ.Text)
            Formato = Format(Mascara, "000")
            txtFIPRMANZ.Text = Formato
        End If

        strBARRESTA.Items(0).Text = ""
        strBARRESTA.Items(1).Text = ""

    End Sub
    Private Sub txtFIPRPRED_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFIPRPRED.Validated

        If Trim(txtFIPRPRED.Text) <> "" Then
            Mascara = Val(txtFIPRPRED.Text)
            Formato = Format(Mascara, "00000")
            txtFIPRPRED.Text = Formato
        End If

        strBARRESTA.Items(0).Text = ""
        strBARRESTA.Items(1).Text = ""

    End Sub

    Private Sub cboFIPRCLSE_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboFIPRCLSE.SelectedIndexChanged
        lblFIPRCLSE.Text = CType(fun_Buscar_Lista_Valores_CLASSECT(cboFIPRCLSE.Text), String)
    End Sub

    Private Sub dgvFICHPRED_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvFICHPRED.CellDoubleClick
        Call cmdACEPTAR_Click(cmdACEPTAR, New System.EventArgs)
    End Sub

#End Region

  
End Class