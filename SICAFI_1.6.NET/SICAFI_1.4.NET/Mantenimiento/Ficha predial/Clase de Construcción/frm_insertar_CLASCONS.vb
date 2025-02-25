Imports REGLAS_DEL_NEGOCIO

Public Class frm_insertar_CLASCONS

    '======================================
    '*** INSERTAR CLASE DE CONSTRUCCIÓN ***
    '======================================

#Region "PROCEDIMIENTOS"

    Public Sub pro_inicializarControles()
        Dim objdatos As New cla_ESTADO

        cboCLCOESTA.DataSource = objdatos.fun_Consultar_ESTADO_X_ESTADO
        cboCLCOESTA.DisplayMember = "ESTADESC"
        cboCLCOESTA.ValueMember = "ESTACODI"

    End Sub
    Private Sub pro_LimpiarCampos()

        txtCLCOCODI.Text = ""
        txtCLCODESC.Text = ""
        strBARRESTA.Items(1).Text = ""
        ErrorProvider1.SetError(Me.txtCLCOCODI, "")

    End Sub

#End Region

#Region "MENU"

    Private Sub cmdGUARDAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGUARDAR.Click
        Try
            If fun_Verificar_Campos_Llenos_3_DATOS(txtCLCOCODI.Text, txtCLCODESC.Text, cboCLCOESTA.Text) = False Then
                mod_MENSAJE.Existen_Campos_Sin_Diligenciar()
                txtCLCOCODI.Focus()
            Else
                Dim id As Integer = Val(txtCLCOCODI.Text)

                Dim objdatos1 As New cla_CLASCONS
                Dim tbl As New DataTable

                tbl = objdatos1.fun_Buscar_CODIGO_MANT_CLASCONS(id)

                If tbl.Rows.Count > 0 Then
                    mod_MENSAJE.Codigo_Existente_En_Base_De_Datos()
                    txtCLCOCODI.Focus()
                Else
                    Dim objdatos As New cla_CLASCONS

                    If (objdatos.fun_Insertar_MANT_CLASCONS(txtCLCOCODI.Text, txtCLCODESC.Text, cboCLCOESTA.SelectedValue)) Then
                        mod_MENSAJE.Se_Guardaron_Los_Datos_Correctamente()

                        If MessageBox.Show("¿ Desea agregar otro registro ?", "Mensaje...", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.No Then
                            pro_LimpiarCampos()
                            txtCLCOCODI.Focus()
                            Me.Close()
                        Else
                            pro_LimpiarCampos()
                            txtCLCOCODI.Focus()
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
        txtCLCOCODI.Focus()
        Me.Close()
    End Sub

#End Region

#Region "FORMULARIO"

#Region "Load"

    Private Sub frm_insertar_CLASCONS_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        pro_inicializarControles()
        pro_LimpiarCampos()
        txtCLCOCODI.Focus()
    End Sub

#End Region

#Region "TextChanged"

    Private Sub txtCLCOCODI_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCLCOCODI.TextChanged
        If Trim(txtCLCOCODI.Text) = "" Then
            ErrorProvider1.SetError(Me.txtCLCOCODI, "")
        End If
    End Sub

#End Region

#Region "KeyPress"

    Private Sub txtCLCOCODI_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCLCOCODI.KeyPress

        If Not Char.IsNumber(e.KeyChar) Then
            If e.KeyChar <> Convert.ToChar(Keys.Back) Then
                If e.KeyChar <> Convert.ToChar(Keys.Enter) Then
                    e.Handled = True
                    strBARRESTA.Items(1).Text = IncoValoNume
                    mod_MENSAJE.Inco_Valo_Nume()
                Else
                    txtCLCODESC.Focus()
                End If
            End If
        End If

    End Sub
    Private Sub txtCLCODESC_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCLCODESC.KeyPress

        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            cboCLCOESTA.Focus()
        End If

    End Sub
    Private Sub cboCLCOESTA_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboCLCOESTA.KeyPress

        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            cmdGUARDAR.Focus()
        End If

    End Sub

#End Region

#Region "Validated"

    Private Sub txtCLCOCODI_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCLCOCODI.Validated
        Try

            If Trim(txtCLCOCODI.Text) = "" Then
                txtCLCOCODI.Focus()
                strBARRESTA.Items(1).Text = IncoValoNulo
                ErrorProvider1.SetError(Me.txtCLCOCODI, "")
            Else
                strBARRESTA.Items(0).Text = ""
                strBARRESTA.Items(1).Text = ""

                Dim Codigo As Integer = Val(txtCLCOCODI.Text)

                Dim objdatos1 As New cla_CLASCONS
                Dim tbl As New DataTable
                tbl = objdatos1.fun_Buscar_CODIGO_MANT_CLASCONS(Codigo)

                If tbl.Rows.Count > 0 Then
                    ErrorProvider1.SetError(Me.txtCLCOCODI, "Código existente en la base de datos")
                    txtCLCOCODI.Focus()
                Else
                    ErrorProvider1.SetError(Me.txtCLCOCODI, "")
                End If
            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub txtCLCODESC_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCLCODESC.Validated
        If Trim(txtCLCODESC.Text) = "" Then
            txtCLCODESC.Focus()
            strBARRESTA.Items(1).Text = IncoValoNulo
        Else
            strBARRESTA.Items(0).Text = ""
            strBARRESTA.Items(1).Text = ""
        End If
    End Sub
    Private Sub cboCLCOESTA_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboCLCOESTA.Validated
        strBARRESTA.Items(0).Text = ""
        strBARRESTA.Items(1).Text = ""
    End Sub

#End Region

#Region "GotFocus"

    Private Sub txtCLCOCODI_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCLCOCODI.GotFocus
        txtCLCOCODI.SelectionStart = 0
        txtCLCOCODI.SelectionLength = Len(txtCLCOCODI.Text)
        strBARRESTA.Items(0).Text = txtCLCOCODI.AccessibleDescription
    End Sub
    Private Sub txtCLCODESC_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCLCODESC.GotFocus
        txtCLCODESC.SelectionStart = 0
        txtCLCODESC.SelectionLength = Len(txtCLCODESC.Text)
        strBARRESTA.Items(0).Text = txtCLCODESC.AccessibleDescription
    End Sub
    Private Sub cboCLCOESTA_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboCLCOESTA.GotFocus
        cboCLCOESTA.SelectionStart = 0
        cboCLCOESTA.SelectionLength = Len(cboCLCOESTA.Text)
        strBARRESTA.Items(0).Text = cboCLCOESTA.AccessibleDescription
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