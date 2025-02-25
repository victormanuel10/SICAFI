Imports REGLAS_DEL_NEGOCIO

Public Class frm_insertar_SEXO

    '=====================
    '*** INSERTAR SEXO ***
    '=====================

#Region "PROCEDIMIENTOS"

    Public Sub pro_inicializarControles()
        Dim objdatos As New cla_ESTADO

        cboSEXOESTA.DataSource = objdatos.fun_Consultar_ESTADO_X_ESTADO
        cboSEXOESTA.DisplayMember = "ESTADESC"
        cboSEXOESTA.ValueMember = "ESTACODI"

    End Sub
    Private Sub pro_LimpiarCampos()

        txtSEXOCODI.Text = ""
        txtSEXODESC.Text = ""
        strBARRESTA.Items(1).Text = ""
        ErrorProvider1.SetError(Me.txtSEXOCODI, "")

    End Sub

#End Region

#Region "MENU"

    Private Sub cmdGUARDAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGUARDAR.Click
        Try
            If fun_Verificar_Campos_Llenos_3_DATOS(txtSEXOCODI.Text, txtSEXODESC.Text, cboSEXOESTA.Text) = False Then
                mod_MENSAJE.Existen_Campos_Sin_Diligenciar()
                txtSEXOCODI.Focus()
            Else
                Dim id As Integer = Val(txtSEXOCODI.Text)

                Dim objdatos1 As New cla_SEXO
                Dim tbl As New DataTable

                tbl = objdatos1.fun_Buscar_CODIGO_MANT_SEXO(id)

                If tbl.Rows.Count > 0 Then
                    mod_MENSAJE.Codigo_Existente_En_Base_De_Datos()
                    txtSEXOCODI.Focus()
                Else
                    Dim objdatos As New cla_SEXO

                    If (objdatos.fun_Insertar_MANT_SEXO(txtSEXOCODI.Text, txtSEXODESC.Text, cboSEXOESTA.SelectedValue)) Then
                        mod_MENSAJE.Se_Guardaron_Los_Datos_Correctamente()

                        If MessageBox.Show("¿ Desea agregar otro registro ?", "Mensaje...", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.No Then
                            pro_LimpiarCampos()
                            txtSEXOCODI.Focus()
                            Me.Close()
                        Else
                            pro_LimpiarCampos()
                            txtSEXOCODI.Focus()
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
        txtSEXOCODI.Focus()
        Me.Close()
    End Sub

#End Region

#Region "FORMULARIO"

#Region "Load"

    Private Sub frm_insertar_SEXO_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        pro_inicializarControles()
        pro_LimpiarCampos()
        txtSEXOCODI.Focus()
    End Sub

#End Region

#Region "TextChanged"

    Private Sub txtSEXOCODI_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtSEXOCODI.TextChanged
        If Trim(txtSEXOCODI.Text) = "" Then
            ErrorProvider1.SetError(Me.txtSEXOCODI, "")
        End If
    End Sub

#End Region

#Region "KeyPress"

    Private Sub txtSEXOCODI_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtSEXOCODI.KeyPress
        If Not Char.IsNumber(e.KeyChar) Then
            If e.KeyChar <> Convert.ToChar(Keys.Back) Then
                If e.KeyChar <> Convert.ToChar(Keys.Enter) Then
                    e.Handled = True
                    strBARRESTA.Items(1).Text = IncoValoNume
                    mod_MENSAJE.Inco_Valo_Nume()
                Else
                    txtSEXODESC.Focus()
                End If
            End If
        End If
    End Sub
    Private Sub txtSEXODESC_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtSEXODESC.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            cboSEXOESTA.Focus()
        End If
    End Sub
    Private Sub cboSEXOESTA_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboSEXOESTA.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            cmdGUARDAR.Focus()
        End If
    End Sub

#End Region

#Region "Validated"

    Private Sub txtSEXOCODI_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtSEXOCODI.Validated
        Try
            If Trim(txtSEXOCODI.Text) = "" Then
                txtSEXOCODI.Focus()
                strBARRESTA.Items(1).Text = IncoValoNulo
                ErrorProvider1.SetError(Me.txtSEXOCODI, "")
            Else
                strBARRESTA.Items(0).Text = ""
                strBARRESTA.Items(1).Text = ""

                Dim Codigo As Integer = Val(txtSEXOCODI.Text)

                Dim objdatos1 As New cla_SEXO
                Dim tbl As New DataTable
                tbl = objdatos1.fun_Buscar_CODIGO_MANT_SEXO(Codigo)

                If tbl.Rows.Count > 0 Then
                    ErrorProvider1.SetError(Me.txtSEXOCODI, "Código existente en la base de datos")
                    txtSEXOCODI.Focus()
                Else
                    ErrorProvider1.SetError(Me.txtSEXOCODI, "")
                End If
            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub txtSEXODESC_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtSEXODESC.Validated
        If Trim(txtSEXODESC.Text) = "" Then
            txtSEXODESC.Focus()
            strBARRESTA.Items(1).Text = IncoValoNulo
        Else
            strBARRESTA.Items(0).Text = ""
            strBARRESTA.Items(1).Text = ""
        End If
    End Sub
    Private Sub cboSEXOESTA_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboSEXOESTA.Validated
        strBARRESTA.Items(0).Text = ""
        strBARRESTA.Items(1).Text = ""
    End Sub

#End Region

#Region "GotFocus"

    Private Sub txtSEXOCODI_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtSEXOCODI.GotFocus
        txtSEXOCODI.SelectionStart = 0
        txtSEXOCODI.SelectionLength = Len(txtSEXOCODI.Text)
        strBARRESTA.Items(0).Text = txtSEXOCODI.AccessibleDescription
    End Sub
    Private Sub txtSEXODESC_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtSEXODESC.GotFocus
        txtSEXODESC.SelectionStart = 0
        txtSEXODESC.SelectionLength = Len(txtSEXODESC.Text)
        strBARRESTA.Items(0).Text = txtSEXODESC.AccessibleDescription
    End Sub
    Private Sub cboSEXOESTA_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboSEXOESTA.GotFocus
        cboSEXOESTA.SelectionStart = 0
        cboSEXOESTA.SelectionLength = Len(cboSEXOESTA.Text)
        strBARRESTA.Items(0).Text = cboSEXOESTA.AccessibleDescription
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