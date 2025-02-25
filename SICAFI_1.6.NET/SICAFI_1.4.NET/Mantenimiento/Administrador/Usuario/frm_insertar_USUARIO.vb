Imports REGLAS_DEL_NEGOCIO

Public Class frm_insertar_USUARIO

    '========================
    '*** INSERTAR USUARIO ***
    '========================

#Region "VARIABLES LOCALES"

    '*** SW VERIFICAR CAMPOS LLENOS QUE VAN A LA DB ***
    Dim SWVerificarCamposLlenos As Boolean = False

#End Region

#Region "PROCEDIMIENTOS"

    Public Sub pro_inicializarControles()

        '=========================================
        ' CARGA LOS COMBOBOX CON LOS DATOS ACTIVOS
        '=========================================

        Dim objdatos2 As New cla_TIPODOCU

        cboUSUATIDO.DataSource = objdatos2.fun_Consultar_MANT_TIPODOCU_X_ESTADO
        cboUSUATIDO.DisplayMember = "TIDOCODI"
        cboUSUATIDO.ValueMember = "TIDOCODI"

        Dim objdatos1 As New cla_CALIPROP

        cboUSUACAPR.DataSource = objdatos1.fun_Consultar_MANT_CALIPROP_X_ESTADO
        cboUSUACAPR.DisplayMember = "CAPRCODI"
        cboUSUACAPR.ValueMember = "CAPRCODI"

        Dim objdatos3 As New cla_SEXO

        cboUSUASEXO.DataSource = objdatos3.fun_Consultar_MANT_SEXO_X_ESTADO
        cboUSUASEXO.DisplayMember = "SEXOCODI"
        cboUSUASEXO.ValueMember = "SEXOCODI"


        Dim objdatos4 As New cla_ESTADO

        cboUSUAESTA.DataSource = objdatos4.fun_Consultar_ESTADO_X_ESTADO
        cboUSUAESTA.DisplayMember = "ESTADESC"
        cboUSUAESTA.ValueMember = "ESTACODI"


        '==========================================================
        ' CARGA LA DESCRIPCIÓN (Los reg. activos ya estan cargados)
        '==========================================================
        Try

            Dim objdatos5 As New cla_TIPODOCU
            Dim tbl_Documento As New DataTable
            Dim id_Documento As Integer = Val(cboUSUATIDO.SelectedValue)

            tbl_Documento = objdatos5.fun_Buscar_CODIGO_MANT_TIPODOCU(id_Documento)

            Dim objdatos6 As New cla_CALIPROP
            Dim tbl_Calidad As New DataTable
            Dim id_Calidad As Integer = Val(cboUSUACAPR.SelectedValue)

            tbl_Calidad = objdatos6.fun_Buscar_CODIGO_MANT_CALIPROP(id_Calidad)

            Dim objdatos7 As New cla_SEXO
            Dim tbl_Sexo As New DataTable
            Dim id_Sexo As Integer = Val(cboUSUASEXO.SelectedValue)

            tbl_Sexo = objdatos7.fun_Buscar_CODIGO_MANT_SEXO(id_Sexo)

            If tbl_Documento.Rows.Count <> 0 Or tbl_Calidad.Rows.Count <> 0 Or tbl_Sexo.Rows.Count <> 0 Then

                lblUSUATIDO.Text = tbl_Documento.Rows(0).Item(2)
                lblUSUACAPR.Text = tbl_Calidad.Rows(0).Item(2)
                lblUSUASEXO.Text = tbl_Sexo.Rows(0).Item(2)
            Else
                frm_INCO_insertar_registro_sin_listas_de_valores.ShowDialog()
            End If

        Catch ex As Exception
            frm_INCO_insertar_registro_sin_listas_de_valores.ShowDialog()
        End Try

        txtUSUANUDO.Focus()

    End Sub
    Private Sub pro_VerificarCamposLlenos()
        '*** CAMPOS OBLIGATORIOS ***

        Try
            If Trim(txtUSUANUDO.Text) = "" Or _
               Trim(cboUSUATIDO.Text) = "" Or _
               Trim(cboUSUACAPR.Text) = "" Or _
               Trim(cboUSUASEXO.Text) = "" Or _
               Trim(txtUSUANOMB.Text) = "" Or _
               Trim(txtUSUAPRAP.Text) = "" Then
                SWVerificarCamposLlenos = False
            Else
                SWVerificarCamposLlenos = True 'Los campos estan bien diligenciados
            End If

        Catch ex As Exception
            MessageBox.Show("" & Err.Description & "")
        End Try

    End Sub
    Private Sub pro_LimpiarCampos()

        txtUSUANUDO.Text = ""
        txtUSUANOMB.Text = ""
        txtUSUAPRAP.Text = ""
        txtUSUASEAP.Text = ""
        txtUSUASICO.Text = ""
        txtUSUATEL1.Text = ""
        txtUSUATEL2.Text = ""
        txtUSUAFAX1.Text = ""
        txtUSUADIRE.Text = ""
        txtUSUAOBSE.Text = ""
        strBARRESTA.Items(1).Text = ""
        ErrorProvider1.SetError(Me.txtUSUANUDO, "")

    End Sub


#End Region

#Region "MENU"

    Private Sub cmdGUARDAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGUARDAR.Click
        pro_VerificarCamposLlenos()

        If SWVerificarCamposLlenos = False Then
            mod_MENSAJE.Existen_Campos_Sin_Diligenciar()
            txtUSUANUDO.Focus()
        Else
            Dim idNumeroDocumento As String = txtUSUANUDO.Text

            Dim objdatos1 As New cla_USUARIO
            Dim tbl As New DataTable
            tbl = objdatos1.fun_Buscar_CODIGO_USUARIO(idNumeroDocumento)

            If tbl.Rows.Count > 0 Then
                MessageBox.Show("Usuario existente en la base de datos " & Chr(13) & "Nro: " & idNumeroDocumento, "Mensaje...", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1)
                txtUSUANUDO.Focus()
            Else
                Dim objdatos As New cla_USUARIO

                If (objdatos.fun_Insertar_USUARIO(txtUSUANUDO.Text, cboUSUATIDO.SelectedValue, cboUSUACAPR.SelectedValue, cboUSUASEXO.SelectedValue, txtUSUANOMB.Text, txtUSUAPRAP.Text, txtUSUASEAP.Text, txtUSUASICO.Text, txtUSUATEL1.Text, txtUSUATEL2.Text, txtUSUAFAX1.Text, txtUSUADIRE.Text, cboUSUAESTA.SelectedValue, txtUSUAOBSE.Text)) Then
                    mod_MENSAJE.Se_Guardaron_Los_Datos_Correctamente()

                    If MessageBox.Show("¿ Desea agregar otro registro ?", "Mensaje...", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.No Then
                        txtUSUANUDO.Focus()
                        pro_LimpiarCampos()
                    Else
                        pro_LimpiarCampos()
                        Me.Close()
                    End If

                Else
                    mod_MENSAJE.No_Se_Guardo_El_Registro_En_La_Base_De_Datos()
                End If
            End If
        End If

    End Sub
    Private Sub cmdCANCELAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSALIR.Click
        pro_LimpiarCampos()
        Me.Close()
    End Sub

#End Region

#Region "FORMULARIO"

    Private Sub frm_insertar_TERCERO_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        pro_inicializarControles()
        pro_LimpiarCampos()
        txtUSUANUDO.Focus()
    End Sub

    Private Sub txtUSUANUDO_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtUSUANUDO.TextChanged
        If Trim(txtUSUANUDO.Text) = "" Then
            ErrorProvider1.SetError(Me.txtUSUANUDO, "")
        End If
    End Sub

    Private Sub txtUSUANUDO_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtUSUANUDO.KeyPress
        If Not Char.IsNumber(e.KeyChar) Then
            If e.KeyChar <> Convert.ToChar(Keys.Back) Then
                If e.KeyChar <> Convert.ToChar(Chr(45)) Then 'guion
                    If e.KeyChar <> Convert.ToChar(Keys.Space) Then
                        If e.KeyChar <> Convert.ToChar(Keys.Enter) Then
                            e.Handled = True
                            strBARRESTA.Items(1).Text = IncoValoNume
                            mod_MENSAJE.Inco_Valo_Nume()
                        Else
                            cboUSUATIDO.Focus()
                        End If
                    End If
                End If
            End If
        End If
    End Sub
    Private Sub cboUSUATIDO_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboUSUATIDO.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            cboUSUACAPR.Focus()
        End If
    End Sub
    Private Sub cboUSUACAPR_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboUSUACAPR.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            cboUSUASEXO.Focus()
        End If
    End Sub
    Private Sub cboUSUASEXO_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboUSUASEXO.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            txtUSUANOMB.Focus()
        End If
    End Sub
    Private Sub txtUSUANOMB_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtUSUANOMB.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            txtUSUAPRAP.Focus()
        End If
    End Sub
    Private Sub txtUSUAPRAP_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtUSUAPRAP.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            txtUSUASEAP.Focus()
        End If
    End Sub
    Private Sub txtUSUASEAP_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtUSUASEAP.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            txtUSUASICO.Focus()
        End If
    End Sub
    Private Sub txtUSUASICO_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtUSUASICO.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            txtUSUATEL1.Focus()
        End If
    End Sub
    Private Sub txtUSUATEL1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtUSUATEL1.KeyPress
        If Not Char.IsNumber(e.KeyChar) Then
            If e.KeyChar <> Convert.ToChar(Keys.Back) Then
                If e.KeyChar <> Convert.ToChar(Keys.Enter) Then
                    e.Handled = True
                    strBARRESTA.Items(1).Text = IncoValoNume
                    mod_MENSAJE.Inco_Valo_Nume()
                Else
                    txtUSUATEL2.Focus()
                End If
            End If
        End If
    End Sub
    Private Sub txtUSUATEL2_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtUSUATEL2.KeyPress
        If Not Char.IsNumber(e.KeyChar) Then
            If e.KeyChar <> Convert.ToChar(Keys.Back) Then
                If e.KeyChar <> Convert.ToChar(Keys.Enter) Then
                    e.Handled = True
                    strBARRESTA.Items(1).Text = IncoValoNume
                    mod_MENSAJE.Inco_Valo_Nume()
                Else
                    txtUSUAFAX1.Focus()
                End If
            End If
        End If
    End Sub
    Private Sub txtUSUAFAX1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtUSUAFAX1.KeyPress
        If Not Char.IsNumber(e.KeyChar) Then
            If e.KeyChar <> Convert.ToChar(Keys.Back) Then
                If e.KeyChar <> Convert.ToChar(Keys.Enter) Then
                    e.Handled = True
                    strBARRESTA.Items(1).Text = IncoValoNume
                    mod_MENSAJE.Inco_Valo_Nume()
                Else
                    txtUSUADIRE.Focus()
                End If
            End If
        End If
    End Sub
    Private Sub txtUSUADIRE_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtUSUADIRE.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            cboUSUAESTA.Focus()
        End If
    End Sub
    Private Sub cboUSUAESTA_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboUSUAESTA.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            cmdGUARDAR.Focus()
        End If
    End Sub

    Private Sub txtUSUANUDO_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtUSUANUDO.Validated
        If Trim(txtUSUANUDO.Text) = "" Then
            txtUSUANUDO.Focus()
            strBARRESTA.Items(1).Text = IncoValoNulo
            ErrorProvider1.SetError(Me.txtUSUANUDO, "")
        Else
            strBARRESTA.Items(0).Text = ""
            strBARRESTA.Items(1).Text = ""

            Dim idNumeroDocumento As String = txtUSUANUDO.Text

            Dim objdatos1 As New cla_USUARIO
            Dim tbl As New DataTable
            tbl = objdatos1.fun_Buscar_CODIGO_USUARIO(idNumeroDocumento)

            If tbl.Rows.Count > 0 Then
                ErrorProvider1.SetError(Me.txtUSUANUDO, "Usuario existente en la base de datos")
                txtUSUANUDO.Focus()
            Else
                ErrorProvider1.SetError(Me.txtUSUANUDO, "")
            End If
        End If

    End Sub
    Private Sub cboUSUATIDO_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboUSUATIDO.Validated

        strBARRESTA.Items(0).Text = ""
        strBARRESTA.Items(1).Text = ""
    End Sub
    Private Sub cboUSUACAPR_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboUSUACAPR.Validated

        strBARRESTA.Items(0).Text = ""
        strBARRESTA.Items(1).Text = ""
    End Sub
    Private Sub cboUSUASEXO_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboUSUASEXO.Validated
        strBARRESTA.Items(0).Text = ""
        strBARRESTA.Items(1).Text = ""
    End Sub
    Private Sub txtUSUANOMB_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtUSUANOMB.Validated
        If Trim(txtUSUANOMB.Text) = "" Then
            txtUSUANOMB.Focus()
            strBARRESTA.Items(1).Text = IncoValoNulo
        Else
            strBARRESTA.Items(0).Text = ""
            strBARRESTA.Items(1).Text = ""
        End If
    End Sub
    Private Sub txtUSUAPRAP_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtUSUAPRAP.Validated
        If Trim(txtUSUAPRAP.Text) = "" Then
            txtUSUAPRAP.Focus()
            strBARRESTA.Items(1).Text = IncoValoNulo
        Else
            strBARRESTA.Items(0).Text = ""
            strBARRESTA.Items(1).Text = ""
        End If
    End Sub
    Private Sub txtUSUASEAP_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtUSUASEAP.Validated
        strBARRESTA.Items(0).Text = ""
        strBARRESTA.Items(1).Text = ""
    End Sub
    Private Sub txtUSUASICO_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtUSUASICO.Validated
        strBARRESTA.Items(0).Text = ""
        strBARRESTA.Items(1).Text = ""
    End Sub
    Private Sub txtUSUATEL1_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtUSUATEL1.Validated
        strBARRESTA.Items(0).Text = ""
        strBARRESTA.Items(1).Text = ""
    End Sub
    Private Sub txtUSUATEL2_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtUSUATEL2.Validated
        strBARRESTA.Items(0).Text = ""
        strBARRESTA.Items(1).Text = ""
    End Sub
    Private Sub txtUSUAFAX1_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtUSUAFAX1.Validated
        strBARRESTA.Items(0).Text = ""
        strBARRESTA.Items(1).Text = ""
    End Sub
    Private Sub txtUSUADIRE_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtUSUADIRE.Validated
        strBARRESTA.Items(0).Text = ""
        strBARRESTA.Items(1).Text = ""
    End Sub
    Private Sub cboUSUAESTA_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboUSUAESTA.Validated
        strBARRESTA.Items(0).Text = ""
        strBARRESTA.Items(1).Text = ""
    End Sub
    Private Sub txtUSUAOBSE_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtUSUAOBSE.Validated
        strBARRESTA.Items(0).Text = ""
        strBARRESTA.Items(1).Text = ""
    End Sub

    Private Sub txtUSUANUDO_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtUSUANUDO.GotFocus
        txtUSUANUDO.SelectionStart = 0
        txtUSUANUDO.SelectionLength = Len(txtUSUANUDO.Text)
        strBARRESTA.Items(0).Text = txtUSUANUDO.AccessibleDescription
    End Sub
    Private Sub cboUSUATIDO_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboUSUATIDO.GotFocus
        strBARRESTA.Items(0).Text = cboUSUATIDO.AccessibleDescription
    End Sub
    Private Sub cboUSUACAPR_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboUSUACAPR.GotFocus
        strBARRESTA.Items(0).Text = cboUSUACAPR.AccessibleDescription
    End Sub
    Private Sub cboUSUASEXO_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboUSUASEXO.GotFocus
        strBARRESTA.Items(0).Text = cboUSUASEXO.AccessibleDescription
    End Sub
    Private Sub txtUSUANOMB_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtUSUANOMB.GotFocus
        txtUSUANOMB.SelectionStart = 0
        txtUSUANOMB.SelectionLength = Len(txtUSUANOMB.Text)
        strBARRESTA.Items(0).Text = txtUSUANOMB.AccessibleDescription
    End Sub
    Private Sub txtUSUAPRAP_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtUSUAPRAP.GotFocus
        txtUSUAPRAP.SelectionStart = 0
        txtUSUAPRAP.SelectionLength = Len(txtUSUAPRAP.Text)
        strBARRESTA.Items(0).Text = txtUSUAPRAP.AccessibleDescription
    End Sub
    Private Sub txtUSUASEAP_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtUSUASEAP.GotFocus
        txtUSUASEAP.SelectionStart = 0
        txtUSUASEAP.SelectionLength = Len(txtUSUASEAP.Text)
        strBARRESTA.Items(0).Text = txtUSUASEAP.AccessibleDescription
    End Sub
    Private Sub txtUSUASICO_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtUSUASICO.GotFocus
        txtUSUASICO.SelectionStart = 0
        txtUSUASICO.SelectionLength = Len(txtUSUASICO.Text)
        strBARRESTA.Items(0).Text = txtUSUASICO.AccessibleDescription
    End Sub
    Private Sub txtUSUATEL1_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtUSUATEL1.GotFocus
        txtUSUATEL1.SelectionStart = 0
        txtUSUATEL1.SelectionLength = Len(txtUSUATEL1.Text)
        strBARRESTA.Items(0).Text = txtUSUATEL1.AccessibleDescription
    End Sub
    Private Sub txtUSUATEL2_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtUSUATEL2.GotFocus
        txtUSUATEL2.SelectionStart = 0
        txtUSUATEL2.SelectionLength = Len(txtUSUATEL2.Text)
        strBARRESTA.Items(0).Text = txtUSUATEL2.AccessibleDescription
    End Sub
    Private Sub txtUSUAFAX1_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtUSUAFAX1.GotFocus
        txtUSUAFAX1.SelectionStart = 0
        txtUSUAFAX1.SelectionLength = Len(txtUSUAFAX1.Text)
        strBARRESTA.Items(0).Text = txtUSUAFAX1.AccessibleDescription
    End Sub
    Private Sub txtUSUADIRE_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtUSUADIRE.GotFocus
        txtUSUADIRE.SelectionStart = 0
        txtUSUADIRE.SelectionLength = Len(txtUSUADIRE.Text)
        strBARRESTA.Items(0).Text = txtUSUADIRE.AccessibleDescription
    End Sub
    Private Sub cboUSUAESTA_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboUSUAESTA.GotFocus
        strBARRESTA.Items(0).Text = cboUSUAESTA.AccessibleDescription
    End Sub
    Private Sub txtUSUAOBSE_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtUSUAOBSE.GotFocus
        strBARRESTA.Items(0).Text = txtUSUAOBSE.AccessibleDescription
    End Sub
    Private Sub cmdGUARDAR_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdGUARDAR.GotFocus
        strBARRESTA.Items(0).Text = cmdGUARDAR.AccessibleDescription
    End Sub
    Private Sub cmdCANCELAR_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdSALIR.GotFocus
        strBARRESTA.Items(0).Text = cmdSALIR.AccessibleDescription
    End Sub

    Private Sub cboUSUATIDO_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboUSUATIDO.SelectedIndexChanged

        Try
            Dim objdatos2 As New cla_TIPODOCU
            Dim tbl As New DataTable
            Dim idTipoDocu As Integer = Val(cboUSUATIDO.Text)

            tbl = objdatos2.fun_Buscar_CODIGO_MANT_TIPODOCU(idTipoDocu)

            Dim sw, j As Integer

            While j < tbl.Rows.Count And sw = 0
                If cboUSUATIDO.Text = tbl.Rows(j).Item("TIDOCODI") Then
                    lblUSUATIDO.Text = tbl.Rows(j).Item("TIDODESC")
                    sw = 1
                Else
                    j = j + 1
                End If
            End While

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try
     
    End Sub
    Private Sub cboUSUACAPR_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboUSUACAPR.SelectedIndexChanged

        Try
            Dim objdatos2 As New cla_CALIPROP
            Dim tbl As New DataTable
            Dim idCaliProp As Integer = Val(cboUSUACAPR.Text)

            tbl = objdatos2.fun_Buscar_CODIGO_MANT_CALIPROP(idCaliProp)

            Dim sw, j As Integer

            While j < tbl.Rows.Count And sw = 0
                If cboUSUACAPR.Text = tbl.Rows(j).Item("CAPRCODI") Then
                    lblUSUACAPR.Text = tbl.Rows(j).Item("CAPRDESC")
                    sw = 1
                Else
                    j = j + 1
                End If
            End While

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try
       

    End Sub
    Private Sub cboUSUASEXO_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboUSUASEXO.SelectedIndexChanged

        Try
            Dim objdatos2 As New cla_SEXO
            Dim tbl As New DataTable
            Dim idSexo As Integer = Val(cboUSUASEXO.Text)

            tbl = objdatos2.fun_Buscar_CODIGO_MANT_SEXO(idSexo)

            Dim sw, j As Integer

            While j < tbl.Rows.Count And sw = 0
                If cboUSUASEXO.Text = tbl.Rows(j).Item("SEXOCODI") Then
                    lblUSUASEXO.Text = tbl.Rows(j).Item("SEXODESC")
                    sw = 1
                Else
                    j = j + 1
                End If
            End While

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub

    Private Sub cmdVALIDAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdVALIDAR.Click
        Dim idNumeroDocumento As String = txtUSUANUDO.Text
        Dim idTipoDocu As Integer = Val(cboUSUATIDO.Text)

        Dim ibjdatos4 As New cla_TIPODOCU

        If Not (ibjdatos4.fun_Validar_Rangos_Nro_Documento(idNumeroDocumento, idTipoDocu)) Then
            MessageBox.Show("Tipo de documento no valido para rango de hombre", "Mensaje...", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1)
            cboUSUATIDO.Focus()
        Else
            MessageBox.Show("Tipo de documento diligenciado correctamente", "Mensaje...", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
        End If
    End Sub

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