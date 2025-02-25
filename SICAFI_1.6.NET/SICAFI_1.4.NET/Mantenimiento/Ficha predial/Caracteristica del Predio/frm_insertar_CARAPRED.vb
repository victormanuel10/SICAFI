Imports REGLAS_DEL_NEGOCIO

Public Class frm_insertar_CARAPRED

    '=========================================
    '*** INSERTAR CARACTERISTICA DE PREDIO ***
    '=========================================

#Region "PROCEDIMIENTOS"

    Public Sub pro_inicializarControles()
        Dim objdatos As New cla_ESTADO

        cboCAPRESTA.DataSource = objdatos.fun_Consultar_ESTADO_X_ESTADO
        cboCAPRESTA.DisplayMember = "ESTADESC"
        cboCAPRESTA.ValueMember = "ESTACODI"

    End Sub
    Private Sub pro_LimpiarCampos()

        txtCAPRCODI.Text = ""
        txtCAPRDESC.Text = ""
        strBARRESTA.Items(1).Text = ""
        ErrorProvider1.SetError(Me.txtCAPRCODI, "")

    End Sub

#End Region

#Region "MENU"

    Private Sub cmdGUARDAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGUARDAR.Click

        Try
            If fun_Verificar_Campos_Llenos_3_DATOS(txtCAPRCODI.Text, txtCAPRDESC.Text, cboCAPRESTA.Text) = False Then
                mod_MENSAJE.Existen_Campos_Sin_Diligenciar()
                txtCAPRCODI.Focus()
            Else
                Dim id As Integer = Val(txtCAPRCODI.Text)

                Dim objdatos1 As New cla_CARAPRED
                Dim tbl As New DataTable
                tbl = objdatos1.fun_Buscar_CODIGO_MANT_CARAPRED(id)

                If tbl.Rows.Count > 0 Then
                    mod_MENSAJE.Codigo_Existente_En_Base_De_Datos()
                    txtCAPRCODI.Focus()
                Else
                    Dim objdatos As New cla_CARAPRED

                    If (objdatos.fun_Insertar_MANT_CARAPRED(txtCAPRCODI.Text, txtCAPRDESC.Text, cboCAPRESTA.SelectedValue)) Then
                        mod_MENSAJE.Se_Guardaron_Los_Datos_Correctamente()

                        If MessageBox.Show("¿ Desea agregar otro registro ?", "Mensaje...", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.No Then
                            pro_LimpiarCampos()
                            txtCAPRCODI.Focus()
                            Me.Close()
                        Else
                            pro_LimpiarCampos()
                            txtCAPRCODI.Focus()
                        End If

                    Else
                        mod_MENSAJE.No_Se_Guardo_El_Registro_En_La_Base_De_Datos()
                    End If
                End If
            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub cmdCANCELAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSALIR.Click
        txtCAPRCODI.Focus()
        Me.Close()
    End Sub

#End Region

#Region "FORMULARIO"

#Region "Load"

    Private Sub frm_insertar_CARAPRED_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        pro_inicializarControles()
        pro_LimpiarCampos()
        txtCAPRCODI.Focus()
    End Sub

#End Region

#Region "TextChanged"

    Private Sub txtCAPRCODI_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCAPRCODI.TextChanged
        If Trim(txtCAPRCODI.Text) = "" Then
            ErrorProvider1.SetError(Me.txtCAPRCODI, "")
        End If
    End Sub

#End Region

#Region "KeyPress"

    Private Sub txtCAPRCODI_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCAPRCODI.KeyPress

        If Not Char.IsNumber(e.KeyChar) Then
            If e.KeyChar <> Convert.ToChar(Keys.Back) Then
                If e.KeyChar <> Convert.ToChar(Keys.Enter) Then
                    e.Handled = True
                    strBARRESTA.Items(1).Text = IncoValoNume
                    mod_MENSAJE.Inco_Valo_Nume()
                Else
                    txtCAPRDESC.Focus()
                End If
            End If
        End If

    End Sub
    Private Sub txtCAPRDESC_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCAPRDESC.KeyPress

        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            cboCAPRESTA.Focus()
        End If

    End Sub
    Private Sub cboCAPRESTA_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboCAPRESTA.KeyPress

        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            cmdGUARDAR.Focus()
        End If

    End Sub

#End Region

#Region "Validated"

    Private Sub txtCAPRCODI_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCAPRCODI.Validated
        Try
            If Trim(txtCAPRCODI.Text) = "" Then
                txtCAPRCODI.Focus()
                strBARRESTA.Items(1).Text = IncoValoNulo
                ErrorProvider1.SetError(Me.txtCAPRCODI, "")
            Else
                strBARRESTA.Items(0).Text = ""
                strBARRESTA.Items(1).Text = ""

                Dim Codigo As Integer = Val(txtCAPRCODI.Text)

                Dim objdatos1 As New cla_CARAPRED
                Dim tbl As New DataTable
                tbl = objdatos1.fun_Buscar_CODIGO_MANT_CARAPRED(Codigo)

                If tbl.Rows.Count > 0 Then
                    ErrorProvider1.SetError(Me.txtCAPRCODI, "Código existente en la base de datos")
                    txtCAPRCODI.Focus()
                Else
                    ErrorProvider1.SetError(Me.txtCAPRCODI, "")
                End If
            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub txtCAPRDESC_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCAPRDESC.Validated
        If Trim(txtCAPRDESC.Text) = "" Then
            txtCAPRDESC.Focus()
            strBARRESTA.Items(1).Text = IncoValoNulo
        Else
            strBARRESTA.Items(0).Text = ""
            strBARRESTA.Items(1).Text = ""
        End If
    End Sub
    Private Sub cboCAPRESTA_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboCAPRESTA.Validated
        strBARRESTA.Items(0).Text = ""
        strBARRESTA.Items(1).Text = ""
    End Sub

#End Region

#Region "GotFocus"

    Private Sub txtCAPRCODI_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCAPRCODI.GotFocus
        txtCAPRCODI.SelectionStart = 0
        txtCAPRCODI.SelectionLength = Len(txtCAPRCODI.Text)
        strBARRESTA.Items(0).Text = txtCAPRCODI.AccessibleDescription
    End Sub
    Private Sub txtCAPRDESC_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCAPRDESC.GotFocus
        txtCAPRDESC.SelectionStart = 0
        txtCAPRDESC.SelectionLength = Len(txtCAPRDESC.Text)
        strBARRESTA.Items(0).Text = txtCAPRDESC.AccessibleDescription
    End Sub
    Private Sub cboCAPRESTA_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboCAPRESTA.GotFocus
        cboCAPRESTA.SelectionStart = 0
        cboCAPRESTA.SelectionLength = Len(cboCAPRESTA.Text)
        strBARRESTA.Items(0).Text = cboCAPRESTA.AccessibleDescription
    End Sub
    Private Sub cmdGUARDAR_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdGUARDAR.GotFocus
        strBARRESTA.Items(0).Text = cmdGUARDAR.AccessibleDescription
    End Sub
    Private Sub cmdCANCELAR_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdSALIR.GotFocus
        strBARRESTA.Items(0).Text = cmdSALIR.AccessibleDescription
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