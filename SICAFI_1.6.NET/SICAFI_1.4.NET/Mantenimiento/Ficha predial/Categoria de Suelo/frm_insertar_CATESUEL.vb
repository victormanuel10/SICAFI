Imports REGLAS_DEL_NEGOCIO

Public Class frm_insertar_CATESUEL

    '===================================
    '*** INSERTAR CATEGORIA DE SUELO ***
    '===================================

#Region "PROCEDIMIENTOS"

    Public Sub pro_inicializarControles()
        Dim objdatos As New cla_ESTADO

        cboCASUESTA.DataSource = objdatos.fun_Consultar_ESTADO_X_ESTADO
        cboCASUESTA.DisplayMember = "ESTADESC"
        cboCASUESTA.ValueMember = "ESTACODI"

    End Sub
    Private Sub pro_LimpiarCampos()

        txtCASUCODI.Text = ""
        txtCASUDESC.Text = ""
        strBARRESTA.Items(1).Text = ""
        ErrorProvider1.SetError(Me.txtCASUCODI, "")

    End Sub

#End Region

#Region "MENU"

    Private Sub cmdGUARDAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGUARDAR.Click
        Try
            If fun_Verificar_Campos_Llenos_3_DATOS(txtCASUCODI.Text, txtCASUDESC.Text, cboCASUESTA.Text) = False Then
                mod_MENSAJE.Existen_Campos_Sin_Diligenciar()
                txtCASUCODI.Focus()
            Else
                Dim id As Integer = Val(txtCASUCODI.Text)

                Dim objdatos1 As New cla_CATESUEL
                Dim tbl As New DataTable
                tbl = objdatos1.fun_Buscar_CODIGO_MANT_CATESUEL(id)

                If tbl.Rows.Count > 0 Then
                    mod_MENSAJE.Codigo_Existente_En_Base_De_Datos()
                    txtCASUCODI.Focus()
                Else
                    Dim objdatos As New cla_CATESUEL

                    If (objdatos.fun_Insertar_MANT_CATESUEL(txtCASUCODI.Text, txtCASUDESC.Text, cboCASUESTA.SelectedValue)) Then
                        mod_MENSAJE.Se_Guardaron_Los_Datos_Correctamente()

                        If MessageBox.Show("¿ Desea agregar otro registro ?", "Mensaje...", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.No Then
                            pro_LimpiarCampos()
                            txtCASUCODI.Focus()
                            Me.Close()
                        Else
                            pro_LimpiarCampos()
                            txtCASUCODI.Focus()
                        End If
                       
                    Else
                        mod_MENSAJE.No_Se_Guardo_El_Registro_En_La_Base_De_Datos()
                    End If
                End If
            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description & "Guardar")
        End Try

    End Sub
    Private Sub cmdCANCELAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSALIR.Click
        txtCASUCODI.Focus()
        Me.Close()
    End Sub

#End Region

#Region "FORMULARIO"

#Region "Load"

    Private Sub frm_insertar_CATESUEL_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        pro_inicializarControles()
        pro_LimpiarCampos()
        txtCASUCODI.Focus()
    End Sub

#End Region

#Region "TextChanged"

    Private Sub txtCASUCODI_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCASUCODI.TextChanged
        If Trim(txtCASUCODI.Text) = "" Then
            ErrorProvider1.SetError(Me.txtCASUCODI, "")
        End If
    End Sub

#End Region

#Region "KeyPress"

    Private Sub txtCASUCODI_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCASUCODI.KeyPress
        If Not Char.IsNumber(e.KeyChar) Then
            If e.KeyChar <> Convert.ToChar(Keys.Back) Then
                If e.KeyChar <> Convert.ToChar(Keys.Enter) Then
                    e.Handled = True
                    strBARRESTA.Items(1).Text = IncoValoNume
                    mod_MENSAJE.Inco_Valo_Nume()
                Else
                    txtCASUDESC.Focus()
                End If
            End If
        End If
    End Sub
    Private Sub txtCASUDESC_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCASUDESC.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            cboCASUESTA.Focus()
        End If
    End Sub
    Private Sub cboCASUESTA_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboCASUESTA.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            cmdGUARDAR.Focus()
        End If
    End Sub
#End Region

#Region "Validated"

    Private Sub txtCASUCODI_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCASUCODI.Validated
        Try
            If Trim(txtCASUCODI.Text) = "" Then
                txtCASUCODI.Focus()
                strBARRESTA.Items(1).Text = IncoValoNulo
                ErrorProvider1.SetError(Me.txtCASUCODI, "")
            Else
                strBARRESTA.Items(0).Text = ""
                strBARRESTA.Items(1).Text = ""

                Dim Codigo As Integer = Val(txtCASUCODI.Text)

                Dim objdatos1 As New cla_CATESUEL
                Dim tbl As New DataTable
                tbl = objdatos1.fun_Buscar_CODIGO_MANT_CATESUEL(Codigo)

                If tbl.Rows.Count > 0 Then
                    ErrorProvider1.SetError(Me.txtCASUCODI, "Código existente en la base de datos")
                    txtCASUCODI.Focus()
                Else
                    ErrorProvider1.SetError(Me.txtCASUCODI, "")
                End If
            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub txtCASUDESC_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCASUDESC.Validated
        If Trim(txtCASUDESC.Text) = "" Then
            txtCASUDESC.Focus()
            strBARRESTA.Items(1).Text = IncoValoNulo
        Else
            strBARRESTA.Items(0).Text = ""
            strBARRESTA.Items(1).Text = ""
        End If
    End Sub
    Private Sub cboCASUESTA_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboCASUESTA.Validated
        strBARRESTA.Items(0).Text = ""
        strBARRESTA.Items(1).Text = ""
    End Sub

#End Region

#Region "GotFocus"

    Private Sub txtCASUCODI_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCASUCODI.GotFocus
        txtCASUCODI.SelectionStart = 0
        txtCASUCODI.SelectionLength = Len(txtCASUCODI.Text)
        strBARRESTA.Items(0).Text = txtCASUCODI.AccessibleDescription
    End Sub
    Private Sub txtCASUDESC_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCASUDESC.GotFocus
        txtCASUDESC.SelectionStart = 0
        txtCASUDESC.SelectionLength = Len(txtCASUDESC.Text)
        strBARRESTA.Items(0).Text = txtCASUDESC.AccessibleDescription
    End Sub
    Private Sub cboCASUESTA_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboCASUESTA.GotFocus
        cboCASUESTA.SelectionStart = 0
        cboCASUESTA.SelectionLength = Len(cboCASUESTA.Text)
        strBARRESTA.Items(0).Text = cboCASUESTA.AccessibleDescription
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