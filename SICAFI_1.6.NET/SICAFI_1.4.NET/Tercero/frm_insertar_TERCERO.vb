Imports REGLAS_DEL_NEGOCIO

Public Class frm_insertar_TERCERO

    '========================
    '*** INSERTAR TERCERO ***
    '========================

#Region "PROCEDIMIENTOS"

    Public Sub pro_inicializarControles()

        '=========================================
        ' CARGA LOS COMBOBOX CON LOS DATOS ACTIVOS
        '=========================================

        Dim objdatos2 As New cla_TIPODOCU

        cboTERCTIDO.DataSource = objdatos2.fun_Consultar_MANT_TIPODOCU_X_ESTADO
        cboTERCTIDO.DisplayMember = "TIDOCODI"
        cboTERCTIDO.ValueMember = "TIDOCODI"

        Dim objdatos1 As New cla_CALIPROP

        cboTERCCAPR.DataSource = objdatos1.fun_Consultar_MANT_CALIPROP_X_ESTADO
        cboTERCCAPR.DisplayMember = "CAPRCODI"
        cboTERCCAPR.ValueMember = "CAPRCODI"

        Dim objdatos3 As New cla_SEXO

        cboTERCSEXO.DataSource = objdatos3.fun_Consultar_MANT_SEXO_X_ESTADO
        cboTERCSEXO.DisplayMember = "SEXOCODI"
        cboTERCSEXO.ValueMember = "SEXOCODI"

        Dim objdatos4 As New cla_ESTADO

        cboTERCESTA.DataSource = objdatos4.fun_Consultar_ESTADO_X_ESTADO
        cboTERCESTA.DisplayMember = "ESTADESC"
        cboTERCESTA.ValueMember = "ESTACODI"


        '==========================================================
        ' CARGA LA DESCRIPCIÓN (Los reg. activos ya estan cargados)
        '==========================================================
        Try
            Dim boTERCTIDO As Boolean = fun_Buscar_Dato_TIPODOCU(cboTERCTIDO.SelectedValue)
            Dim boTERCCAPR As Boolean = fun_Buscar_Dato_CALIPROP(cboTERCCAPR.SelectedValue)
            Dim boTERCSEXO As Boolean = fun_Buscar_Dato_SEXO(cboTERCSEXO.SelectedValue)

            If boTERCTIDO = True OrElse boTERCCAPR = True OrElse boTERCSEXO = True Then

                lblTERCTIDO.Text = CType(fun_Buscar_Lista_Valores_TIPODOCU(cboTERCTIDO.SelectedValue), String)
                lblTERCCAPR.Text = CType(fun_Buscar_Lista_Valores_CALIPROP(cboTERCCAPR.SelectedValue), String)
                lblTERCSEXO.Text = CType(fun_Buscar_Lista_Valores_SEXO(cboTERCSEXO.SelectedValue), String)
            Else
                frm_INCO_insertar_registro_sin_listas_de_valores.ShowDialog()
            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

        txtTERCNUDO.Focus()

    End Sub
    Private Sub pro_LimpiarCampos()

        txtTERCNUDO.Text = ""
        txtTERCNOMB.Text = ""
        txtTERCPRAP.Text = ""
        txtTERCSEAP.Text = ""
        txtTERCSICO.Text = ""
        txtTERCTEL1.Text = ""
        txtTERCTEL2.Text = ""
        txtTERCFAX1.Text = ""
        txtTERCDIRE.Text = ""
        txtTERCOBSE.Text = ""
        strBARRESTA.Items(1).Text = ""
        ErrorProvider1.SetError(Me.txtTERCNUDO, "")

    End Sub


#End Region

#Region "MENU"

    Private Sub cmdGUARDAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGUARDAR.Click

        If fun_Verificar_Campos_Llenos_6_DATOS(txtTERCNUDO.Text, cboTERCTIDO.Text, cboTERCCAPR.Text, cboTERCSEXO.Text, txtTERCNOMB.Text, txtTERCPRAP.Text) = False Then
            mod_MENSAJE.Existen_Campos_Sin_Diligenciar()
            txtTERCNUDO.Focus()
        Else
            Dim idNumeroDocumento As String = txtTERCNUDO.Text

            Dim objdatos1 As New cla_TERCERO
            Dim tbl As New DataTable
            tbl = objdatos1.fun_Buscar_CODIGO_TERCERO(idNumeroDocumento)

            If tbl.Rows.Count > 0 Then
                MessageBox.Show("Tercero existente en la base de datos " & Chr(13) & "Nro: " & idNumeroDocumento, "Mensaje...", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1)
                txtTERCNUDO.Focus()
            Else
                Dim objdatos As New cla_TERCERO

                If (objdatos.fun_Insertar_TERCERO(txtTERCNUDO.Text, cboTERCTIDO.SelectedValue, cboTERCCAPR.SelectedValue, cboTERCSEXO.SelectedValue, txtTERCNOMB.Text, txtTERCPRAP.Text, txtTERCSEAP.Text, txtTERCSICO.Text, txtTERCTEL1.Text, txtTERCTEL2.Text, txtTERCFAX1.Text, txtTERCDIRE.Text, cboTERCESTA.SelectedValue, txtTERCOBSE.Text)) Then
                    mod_MENSAJE.Se_Guardaron_Los_Datos_Correctamente()

                    If MessageBox.Show("¿ Desea agregar otro registro ?", "Mensaje...", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.No Then

                        Dim objdatos11 As New cla_TERCERO
                        Dim tbl11 As New DataTable

                        tbl11 = objdatos11.fun_Buscar_CODIGO_TERCERO(Trim(txtTERCNUDO.Text))

                        If tbl11.Rows.Count > 0 Then

                            ' envia el id al formulario tercero
                            Dim idTercero As New frm_TERCERO(tbl11.Rows(0).Item(0).ToString)

                        End If
                       
                        Me.Close()
                    End If

                    pro_LimpiarCampos()
                    txtTERCNUDO.Focus()
                Else
                    mod_MENSAJE.No_Se_Guardo_El_Registro_En_La_Base_De_Datos()
                End If
            End If
        End If

    End Sub
    Private Sub cmdCANCELAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSALIR.Click
        pro_LimpiarCampos()
        txtTERCNUDO.Focus()
        Me.Close()
    End Sub

#End Region

#Region "FORMULARIO"

#Region "Load"

    Private Sub frm_insertar_TERCERO_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        pro_inicializarControles()
        pro_LimpiarCampos()
        txtTERCNUDO.Focus()
    End Sub

#End Region

#Region "TextChanged"

    Private Sub txtTERCNUDO_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtTERCNUDO.TextChanged
        If Trim(txtTERCNUDO.Text) = "" Then
            ErrorProvider1.SetError(Me.txtTERCNUDO, "")
        End If
    End Sub

#End Region

#Region "KeyPress"

    Private Sub txtTERCNUDO_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtTERCNUDO.KeyPress
        If Not Char.IsNumber(e.KeyChar) Then
            If e.KeyChar <> Convert.ToChar(Keys.Back) Then
                If e.KeyChar <> Convert.ToChar(Chr(45)) Then 'guion
                    If e.KeyChar <> Convert.ToChar(Keys.Space) Then
                        If e.KeyChar <> Convert.ToChar(Keys.Enter) Then
                            e.Handled = True
                            strBARRESTA.Items(1).Text = IncoValoNume
                            'mod_MENSAJE.Inco_Valo_Nume()
                            mod_MENSAJE.Inco_Valo_Nume()
                        Else
                            cboTERCTIDO.Focus()
                        End If
                    End If
                End If
            End If
        End If
    End Sub
    Private Sub cboTERCTIDO_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboTERCTIDO.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            cboTERCCAPR.Focus()
        End If
    End Sub
    Private Sub cboTERCCAPR_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboTERCCAPR.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            cboTERCSEXO.Focus()
        End If
    End Sub
    Private Sub cboTERCSEXO_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboTERCSEXO.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            txtTERCNOMB.Focus()
        End If
    End Sub
    Private Sub txtTERCNOMB_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtTERCNOMB.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            txtTERCPRAP.Focus()
        End If
    End Sub
    Private Sub txtTERCPRAP_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtTERCPRAP.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            txtTERCSEAP.Focus()
        End If
    End Sub
    Private Sub txtTERCSEAP_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtTERCSEAP.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            txtTERCSICO.Focus()
        End If
    End Sub
    Private Sub txtTERCSICO_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtTERCSICO.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            txtTERCTEL1.Focus()
        End If
    End Sub
    Private Sub txtTERCTEL1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtTERCTEL1.KeyPress
        If Not Char.IsNumber(e.KeyChar) Then
            If e.KeyChar <> Convert.ToChar(Keys.Back) Then
                If e.KeyChar <> Convert.ToChar(Keys.Enter) Then
                    e.Handled = True
                    strBARRESTA.Items(1).Text = IncoValoNume
                    mod_MENSAJE.Inco_Valo_Nume()
                Else
                    txtTERCTEL2.Focus()
                End If
            End If
        End If
    End Sub
    Private Sub txtTERCTEL2_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtTERCTEL2.KeyPress
        If Not Char.IsNumber(e.KeyChar) Then
            If e.KeyChar <> Convert.ToChar(Keys.Back) Then
                If e.KeyChar <> Convert.ToChar(Keys.Enter) Then
                    e.Handled = True
                    strBARRESTA.Items(1).Text = IncoValoNume
                    mod_MENSAJE.Inco_Valo_Nume()
                Else
                    txtTERCFAX1.Focus()
                End If
            End If
        End If
    End Sub
    Private Sub txtTERCFAX1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtTERCFAX1.KeyPress
        If Not Char.IsNumber(e.KeyChar) Then
            If e.KeyChar <> Convert.ToChar(Keys.Back) Then
                If e.KeyChar <> Convert.ToChar(Keys.Enter) Then
                    e.Handled = True
                    strBARRESTA.Items(1).Text = IncoValoNume
                    mod_MENSAJE.Inco_Valo_Nume()
                Else
                    txtTERCDIRE.Focus()
                End If
            End If
        End If
    End Sub
    Private Sub txtTERCDIRE_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtTERCDIRE.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            cboTERCESTA.Focus()
        End If
    End Sub
    Private Sub cboTERCESTA_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboTERCESTA.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            cmdGUARDAR.Focus()
        End If
    End Sub

#End Region

#Region "Validated"

    Private Sub txtTERCNUDO_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtTERCNUDO.Validated
        If Trim(txtTERCNUDO.Text) = "" Then
            txtTERCNUDO.Focus()
            strBARRESTA.Items(1).Text = IncoValoNulo
            ErrorProvider1.SetError(Me.txtTERCNUDO, "")
        Else
            strBARRESTA.Items(0).Text = ""
            strBARRESTA.Items(1).Text = ""

            Dim idNumeroDocumento As String = txtTERCNUDO.Text

            Dim objdatos1 As New cla_TERCERO
            Dim tbl As New DataTable
            tbl = objdatos1.fun_Buscar_CODIGO_TERCERO(idNumeroDocumento)

            If tbl.Rows.Count > 0 Then
                ErrorProvider1.SetError(Me.txtTERCNUDO, "Tercero existente en la base de datos")
                txtTERCNUDO.Focus()
            Else
                ErrorProvider1.SetError(Me.txtTERCNUDO, "")
            End If
        End If

    End Sub
    Private Sub cboTERCTIDO_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboTERCTIDO.Validated
        strBARRESTA.Items(0).Text = ""
        strBARRESTA.Items(1).Text = ""
    End Sub
    Private Sub cboTERCCAPR_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboTERCCAPR.Validated
        strBARRESTA.Items(0).Text = ""
        strBARRESTA.Items(1).Text = ""
    End Sub
    Private Sub cboTERCSEXO_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboTERCSEXO.Validated
        strBARRESTA.Items(0).Text = ""
        strBARRESTA.Items(1).Text = ""
    End Sub
    Private Sub txtTERCNOMB_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtTERCNOMB.Validated
        If Trim(txtTERCNOMB.Text) = "" Then
            txtTERCNOMB.Focus()
            strBARRESTA.Items(1).Text = IncoValoNulo
        Else
            strBARRESTA.Items(0).Text = ""
            strBARRESTA.Items(1).Text = ""
        End If
    End Sub
    Private Sub txtTERCPRAP_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtTERCPRAP.Validated
        If Trim(txtTERCPRAP.Text) = "" Then
            txtTERCPRAP.Focus()
            strBARRESTA.Items(1).Text = IncoValoNulo
        Else
            strBARRESTA.Items(0).Text = ""
            strBARRESTA.Items(1).Text = ""
        End If
    End Sub
    Private Sub txtTERCSEAP_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtTERCSEAP.Validated
        strBARRESTA.Items(0).Text = ""
        strBARRESTA.Items(1).Text = ""
    End Sub
    Private Sub txtTERCSICO_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtTERCSICO.Validated
        strBARRESTA.Items(0).Text = ""
        strBARRESTA.Items(1).Text = ""
    End Sub
    Private Sub txtTERCTEL1_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtTERCTEL1.Validated
        strBARRESTA.Items(0).Text = ""
        strBARRESTA.Items(1).Text = ""
    End Sub
    Private Sub txtTERCTEL2_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtTERCTEL2.Validated
        strBARRESTA.Items(0).Text = ""
        strBARRESTA.Items(1).Text = ""
    End Sub
    Private Sub txtTERCFAX1_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtTERCFAX1.Validated
        strBARRESTA.Items(0).Text = ""
        strBARRESTA.Items(1).Text = ""
    End Sub
    Private Sub txtTERCDIRE_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtTERCDIRE.Validated
        strBARRESTA.Items(0).Text = ""
        strBARRESTA.Items(1).Text = ""
    End Sub
    Private Sub cboTERCESTA_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboTERCESTA.Validated
        strBARRESTA.Items(0).Text = ""
        strBARRESTA.Items(1).Text = ""
    End Sub
    Private Sub txtTERCOBSE_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtTERCOBSE.Validated
        strBARRESTA.Items(0).Text = ""
        strBARRESTA.Items(1).Text = ""
    End Sub

#End Region

#Region "GotFocus"

    Private Sub txtTERCNUDO_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtTERCNUDO.GotFocus
        txtTERCNUDO.SelectionStart = 0
        txtTERCNUDO.SelectionLength = Len(txtTERCNUDO.Text)
        strBARRESTA.Items(0).Text = txtTERCNUDO.AccessibleDescription
    End Sub
    Private Sub cboTERCTIDO_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboTERCTIDO.GotFocus
        strBARRESTA.Items(0).Text = cboTERCTIDO.AccessibleDescription
    End Sub
    Private Sub cboTERCCAPR_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboTERCCAPR.GotFocus
        strBARRESTA.Items(0).Text = cboTERCCAPR.AccessibleDescription
    End Sub
    Private Sub cboTERCSEXO_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboTERCSEXO.GotFocus
        strBARRESTA.Items(0).Text = cboTERCSEXO.AccessibleDescription
    End Sub
    Private Sub txtTERCNOMB_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtTERCNOMB.GotFocus
        txtTERCNOMB.SelectionStart = 0
        txtTERCNOMB.SelectionLength = Len(txtTERCNOMB.Text)
        strBARRESTA.Items(0).Text = txtTERCNOMB.AccessibleDescription
    End Sub
    Private Sub txtTERCPRAP_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtTERCPRAP.GotFocus
        txtTERCPRAP.SelectionStart = 0
        txtTERCPRAP.SelectionLength = Len(txtTERCPRAP.Text)
        strBARRESTA.Items(0).Text = txtTERCPRAP.AccessibleDescription
    End Sub
    Private Sub txtTERCSEAP_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtTERCSEAP.GotFocus
        txtTERCSEAP.SelectionStart = 0
        txtTERCSEAP.SelectionLength = Len(txtTERCSEAP.Text)
        strBARRESTA.Items(0).Text = txtTERCSEAP.AccessibleDescription
    End Sub
    Private Sub txtTERCSICO_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtTERCSICO.GotFocus
        txtTERCSICO.SelectionStart = 0
        txtTERCSICO.SelectionLength = Len(txtTERCSICO.Text)
        strBARRESTA.Items(0).Text = txtTERCSICO.AccessibleDescription
    End Sub
    Private Sub txtTERCTEL1_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtTERCTEL1.GotFocus
        txtTERCTEL1.SelectionStart = 0
        txtTERCTEL1.SelectionLength = Len(txtTERCTEL1.Text)
        strBARRESTA.Items(0).Text = txtTERCTEL1.AccessibleDescription
    End Sub
    Private Sub txtTERCTEL2_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtTERCTEL2.GotFocus
        txtTERCTEL2.SelectionStart = 0
        txtTERCTEL2.SelectionLength = Len(txtTERCTEL2.Text)
        strBARRESTA.Items(0).Text = txtTERCTEL2.AccessibleDescription
    End Sub
    Private Sub txtTERCFAX1_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtTERCFAX1.GotFocus
        txtTERCFAX1.SelectionStart = 0
        txtTERCFAX1.SelectionLength = Len(txtTERCFAX1.Text)
        strBARRESTA.Items(0).Text = txtTERCFAX1.AccessibleDescription
    End Sub
    Private Sub txtTERCDIRE_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtTERCDIRE.GotFocus
        txtTERCDIRE.SelectionStart = 0
        txtTERCDIRE.SelectionLength = Len(txtTERCDIRE.Text)
        strBARRESTA.Items(0).Text = txtTERCDIRE.AccessibleDescription
    End Sub
    Private Sub cboTERCESTA_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboTERCESTA.GotFocus
        strBARRESTA.Items(0).Text = cboTERCESTA.AccessibleDescription
    End Sub
    Private Sub txtTERCOBSE_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtTERCOBSE.GotFocus
        strBARRESTA.Items(0).Text = txtTERCOBSE.AccessibleDescription
    End Sub
    Private Sub cmdGUARDAR_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdGUARDAR.GotFocus
        strBARRESTA.Items(0).Text = cmdGUARDAR.AccessibleDescription
    End Sub
    Private Sub cmdCANCELAR_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdSALIR.GotFocus
        strBARRESTA.Items(0).Text = cmdSALIR.AccessibleDescription
    End Sub

#End Region

#Region "SelectedIndexChanged"

    Private Sub cboTERCTIDO_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboTERCTIDO.SelectedIndexChanged
        lblTERCTIDO.Text = CType(fun_Buscar_Lista_Valores_TIPODOCU(Val(cboTERCTIDO.Text)), String)
    End Sub
    Private Sub cboTERCCAPR_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboTERCCAPR.SelectedIndexChanged
        lblTERCCAPR.Text = CType(fun_Buscar_Lista_Valores_CALIPROP(Val(cboTERCCAPR.Text)), String)
    End Sub
    Private Sub cboTERCSEXO_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboTERCSEXO.SelectedIndexChanged
        lblTERCSEXO.Text = CType(fun_Buscar_Lista_Valores_SEXO(Val(cboTERCSEXO.Text)), String)
    End Sub

#End Region

#Region "Click"

    Private Sub cmdVALIDAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdVALIDAR.Click
        Dim idNumeroDocumento As String = txtTERCNUDO.Text
        Dim idTipoDocu As Integer = Val(cboTERCTIDO.Text)

        Dim objdatos As New cla_TIPODOCU

        If (objdatos.fun_Validar_Rangos_Nro_Documento(idNumeroDocumento, idTipoDocu)) = False Then
            MessageBox.Show("Rango de no valido para el tipo de documento", "Mensaje...", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1)
            cboTERCTIDO.Focus()
        Else
            MessageBox.Show("Numero de documento diligenciado correctamente", "Mensaje...", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
        End If
    End Sub

#End Region

#End Region


End Class