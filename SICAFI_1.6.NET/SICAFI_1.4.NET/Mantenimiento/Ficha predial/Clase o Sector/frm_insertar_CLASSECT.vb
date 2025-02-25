Imports REGLAS_DEL_NEGOCIO

Public Class frm_insertar_CLASSECT

    '===============================
    '*** INSERTAR CLASE O SECTOR ***
    '===============================

#Region "PROCEDIMIENTOS"

    Public Sub pro_inicializarControles()
        Dim objdatos As New cla_ESTADO

        cboCLSEESTA.DataSource = objdatos.fun_Consultar_ESTADO_X_ESTADO
        cboCLSEESTA.DisplayMember = "ESTADESC"
        cboCLSEESTA.ValueMember = "ESTACODI"

    End Sub
    Private Sub pro_LimpiarCampos()

        txtCLSECODI.Text = ""
        txtCLSEDESC.Text = ""
        strBARRESTA.Items(1).Text = ""
        ErrorProvider1.SetError(Me.txtCLSECODI, "")

    End Sub

#End Region

#Region "MENU"

    Private Sub cmdGUARDAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGUARDAR.Click

        If fun_Verificar_Campos_Llenos_3_DATOS(txtCLSECODI.Text, txtCLSEDESC.Text, cboCLSEESTA.Text) = False Then
            mod_MENSAJE.Existen_Campos_Sin_Diligenciar()
            txtCLSECODI.Focus()
        Else
            Dim id As Integer = Val(txtCLSECODI.Text)

            Dim objdatos1 As New cla_CLASSECT
            Dim tbl As New DataTable
            tbl = objdatos1.fun_Buscar_CODIGO_MANT_CLASSECT(id)

            If tbl.Rows.Count > 0 Then
                mod_MENSAJE.Codigo_Existente_En_Base_De_Datos()
                txtCLSECODI.Focus()
            Else

                Dim objdatos As New cla_CLASSECT

                If (objdatos.fun_Insertar_MANT_CLASSECT(txtCLSECODI.Text, txtCLSEDESC.Text, cboCLSEESTA.SelectedValue)) Then
                    mod_MENSAJE.Se_Guardaron_Los_Datos_Correctamente()

                    If MessageBox.Show("¿ Desea agregar otro registro ?", "Mensaje...", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.No Then
                        pro_LimpiarCampos()
                        txtCLSECODI.Focus()
                        Me.Close()
                    Else
                        pro_LimpiarCampos()
                        txtCLSECODI.Focus()
                    End If

                Else
                    mod_MENSAJE.No_Se_Guardo_El_Registro_En_La_Base_De_Datos()
                End If
            End If
        End If

    End Sub
    Private Sub cmdCANCELAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSALIR.Click
        txtCLSECODI.Focus()
        Me.Close()
    End Sub

#End Region

#Region "FORMULARIO"

#Region "Load"

    Private Sub frm_insertar_CLASSECT_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        pro_inicializarControles()
        pro_LimpiarCampos()
        txtCLSECODI.Focus()
    End Sub

#End Region

#Region "TextChanged"

    Private Sub txtCLSECODI_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCLSECODI.TextChanged
        If Trim(txtCLSECODI.Text) = "" Then
            ErrorProvider1.SetError(Me.txtCLSECODI, "")
        End If
    End Sub

#End Region

#Region "KeyPress"

    Private Sub txtCLSECODI_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCLSECODI.KeyPress

        If Not Char.IsNumber(e.KeyChar) Then
            If e.KeyChar <> Convert.ToChar(Keys.Back) Then
                If e.KeyChar <> Convert.ToChar(Keys.Enter) Then
                    e.Handled = True
                    strBARRESTA.Items(1).Text = IncoValoNume
                    mod_MENSAJE.Inco_Valo_Nume()
                Else
                    txtCLSEDESC.Focus()
                End If
            End If
        End If

    End Sub
    Private Sub txtCLSEDESC_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCLSEDESC.KeyPress

        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            cboCLSEESTA.Focus()
        End If

    End Sub
    Private Sub cboCLSEESTA_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboCLSEESTA.KeyPress

        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            cmdGUARDAR.Focus()
        End If

    End Sub

#End Region

#Region "Validated"

    Private Sub txtCLSECODI_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCLSECODI.Validated
        Try

            If Trim(txtCLSECODI.Text) = "" Then
                txtCLSECODI.Focus()
                strBARRESTA.Items(1).Text = IncoValoNulo
                ErrorProvider1.SetError(Me.txtCLSECODI, "")
            Else
                strBARRESTA.Items(0).Text = ""
                strBARRESTA.Items(1).Text = ""

                Dim Codigo As Integer = Val(txtCLSECODI.Text)

                Dim objdatos1 As New cla_CLASSECT
                Dim tbl As New DataTable
                tbl = objdatos1.fun_Buscar_CODIGO_MANT_CLASSECT(Codigo)

                If tbl.Rows.Count > 0 Then
                    ErrorProvider1.SetError(Me.txtCLSECODI, "Código existente en la base de datos")
                    txtCLSECODI.Focus()
                Else
                    ErrorProvider1.SetError(Me.txtCLSECODI, "")
                End If
            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub txtCLSEDESC_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCLSEDESC.Validated
        If Trim(txtCLSEDESC.Text) = "" Then
            txtCLSEDESC.Focus()
            strBARRESTA.Items(1).Text = IncoValoNulo
        Else
            strBARRESTA.Items(0).Text = ""
            strBARRESTA.Items(1).Text = ""
        End If
    End Sub
    Private Sub cboCLSEESTA_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboCLSEESTA.Validated
        strBARRESTA.Items(0).Text = ""
        strBARRESTA.Items(1).Text = ""
    End Sub

#End Region

#Region "GotFocus"

    Private Sub txtCLSECODI_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCLSECODI.GotFocus
        txtCLSECODI.SelectionStart = 0
        txtCLSECODI.SelectionLength = Len(txtCLSECODI.Text)
        strBARRESTA.Items(0).Text = txtCLSECODI.AccessibleDescription
    End Sub
    Private Sub txtCLSEDESC_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCLSEDESC.GotFocus
        txtCLSEDESC.SelectionStart = 0
        txtCLSEDESC.SelectionLength = Len(txtCLSEDESC.Text)
        strBARRESTA.Items(0).Text = txtCLSEDESC.AccessibleDescription
    End Sub
    Private Sub cboCLSEESTA_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboCLSEESTA.GotFocus
        cboCLSEESTA.SelectionStart = 0
        cboCLSEESTA.SelectionLength = Len(cboCLSEESTA.Text)
        strBARRESTA.Items(0).Text = cboCLSEESTA.AccessibleDescription
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