Imports REGLAS_DEL_NEGOCIO

Public Class frm_insertar_ESTADO

    '=======================
    '*** INSERTAR ESTADO ***
    '=======================

#Region "VARIABLES LOCALES"

    '*** SW VERIFICAR CAMPOS LLENOS QUE VAN A LA DB ***
    Dim SWVerificarCamposLlenos As Boolean = False

#End Region

#Region "PROCEDIMIENTOS"

    Public Sub pro_inicializarControles()
        txtESTAESTA.Text = "ac"
    End Sub
    Private Sub pro_VerificarCamposLlenos()
        '*** CAMPOS OBLIGATORIOS ***

        Try
            If Trim(txtESTACODI.Text) = "" Or Trim(txtESTADESC.Text) = "" Then
                SWVerificarCamposLlenos = False
            Else
                SWVerificarCamposLlenos = True 'Los campos estan bien diligenciados
            End If

        Catch ex As Exception
            MessageBox.Show("" & Err.Description & "")
        End Try

    End Sub
    Private Sub pro_LimpiarCampos()

        txtESTACODI.Text = ""
        txtESTADESC.Text = ""
        strBARRESTA.Items(1).Text = ""

    End Sub

#End Region

#Region "MENU"

    Private Sub cmdGUARDAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGUARDAR.Click
        Try
            pro_VerificarCamposLlenos()

            If SWVerificarCamposLlenos = True Then

                Dim objdatos As New cla_ESTADO

                If (objdatos.fun_Insertar_ESTADO(txtESTACODI.Text, txtESTADESC.Text, txtESTAESTA.Text)) Then
                    mod_MENSAJE.Se_Guardaron_Los_Datos_Correctamente()

                    If MessageBox.Show("¿ Desea agregar otro registro ?", "Mensaje...", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.No Then
                        pro_LimpiarCampos()
                        Me.Close()
                    Else
                        pro_LimpiarCampos()
                        txtESTACODI.Focus()
                    End If
                Else
                    mod_MENSAJE.No_Se_Guardo_El_Registro_En_La_Base_De_Datos()
                End If

            Else
                mod_MENSAJE.Existen_Campos_Sin_Diligenciar()
                txtESTACODI.Focus()
            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description & "Guardar")
        End Try

    End Sub
    Private Sub cmdCANCELAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSALIR.Click
        Me.Close()
    End Sub

#End Region

#Region "FORMULARIO"

    Private Sub frm_insertar_ESTADO_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        pro_inicializarControles()
        pro_LimpiarCampos()
        txtESTACODI.Focus()
    End Sub

    Private Sub txtESTACODI_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtESTACODI.KeyPress

        If Not Char.IsLetter(e.KeyChar) Then
            If e.KeyChar <> Convert.ToChar(Keys.Back) Then
                If e.KeyChar <> Convert.ToChar(Keys.Enter) Then
                    e.Handled = True
                    strBARRESTA.Items(1).Text = IncoValoAlfa
                    MessageBox.Show(IncoValoAlfa, "Mensaje...", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                Else
                    txtESTADESC.Focus()
                End If
            End If
        End If

    End Sub
    Private Sub txtESTADESC_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtESTADESC.KeyPress

        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            txtESTAESTA.Focus()
        End If

    End Sub
    Private Sub txtESTAESTA_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtESTAESTA.KeyPress

        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            cmdGUARDAR.Focus()
        End If

    End Sub

    Private Sub txtESTACODI_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtESTACODI.Validated
        If Trim(txtESTACODI.Text) = "" Then
            txtESTACODI.Focus()
            strBARRESTA.Items(1).Text = IncoValoNulo
        Else
            strBARRESTA.Items(0).Text = ""
            strBARRESTA.Items(1).Text = ""
        End If
    End Sub
    Private Sub txtESTADESC_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtESTADESC.Validated
        If Trim(txtESTADESC.Text) = "" Then
            txtESTADESC.Focus()
            strBARRESTA.Items(1).Text = IncoValoNulo
        Else
            strBARRESTA.Items(0).Text = ""
            strBARRESTA.Items(1).Text = ""
        End If
    End Sub
    Private Sub txtESTAESTA_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtESTAESTA.Validated
        strBARRESTA.Items(0).Text = ""
        strBARRESTA.Items(1).Text = ""
    End Sub

    Private Sub txtESTACODI_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtESTACODI.GotFocus
        txtESTACODI.SelectionStart = 0
        txtESTACODI.SelectionLength = Len(txtESTACODI.Text)
        strBARRESTA.Items(0).Text = txtESTACODI.AccessibleDescription
    End Sub
    Private Sub txtESTADESC_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtESTADESC.GotFocus
        txtESTADESC.SelectionStart = 0
        txtESTADESC.SelectionLength = Len(txtESTADESC.Text)
        strBARRESTA.Items(0).Text = txtESTADESC.AccessibleDescription
    End Sub
    Private Sub txtESTAESTA_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs)
        txtESTAESTA.SelectionStart = 0
        txtESTAESTA.SelectionLength = Len(txtESTAESTA.Text)
        strBARRESTA.Items(0).Text = txtESTAESTA.AccessibleDescription
    End Sub
    Private Sub cmdGUARDAR_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdGUARDAR.GotFocus
        strBARRESTA.Items(0).Text = cmdGUARDAR.AccessibleDescription
    End Sub
    Private Sub cmdCANCELAR_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdSALIR.GotFocus
        strBARRESTA.Items(0).Text = cmdSALIR.AccessibleDescription
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