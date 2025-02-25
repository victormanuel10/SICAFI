Imports REGLAS_DEL_NEGOCIO

Public Class frm_insertar_MENUCONT

    '================================
    '*** INSERTAR MENU CONTENEDOR ***
    '================================

#Region "VARIABLES LOCALES"

    '*** SW VERIFICAR CAMPOS LLENOS QUE VAN A LA DB ***
    Dim SWVerificarCamposLlenos As Boolean = False

#End Region

#Region "PROCEDIMIENTOS"

    Public Sub pro_inicializarControles()
        Dim objdatos As New cla_ESTADO

        cboMECOESTA.DataSource = objdatos.fun_Consultar_Estado_X_Estado
        cboMECOESTA.DisplayMember = "ESTADESC"
        cboMECOESTA.ValueMember = "ESTACODI"

    End Sub
    Private Sub pro_VerificarCamposLlenos()
        '*** CAMPOS OBLIGATORIOS ***

        Try
            If Trim(cboMECOCODI.Text) = "" Or _
               Trim(txtMECODESC.Text) = "" Or _
               Trim(cboMECOESTA.Text) = "" Then
                SWVerificarCamposLlenos = False
            Else
                SWVerificarCamposLlenos = True 'Los campos estan bien diligenciados
            End If

        Catch ex As Exception
            MessageBox.Show("" & Err.Description & "")
        End Try

    End Sub
    Private Sub pro_LimpiarCampos()

        cboMECOCODI.Text = ""
        txtMECODESC.Text = ""
        strBARRESTA.Items(1).Text = ""

    End Sub

#End Region

#Region "MENU"

    Private Sub cmdGUARDAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGUARDAR.Click
        Dim id As String = cboMECOCODI.Text

        pro_VerificarCamposLlenos()

        If SWVerificarCamposLlenos = False Then
            mod_MENSAJE.Existen_Campos_Sin_Diligenciar()
            cboMECOCODI.Focus()
        Else
            Dim objdatos1 As New cla_MENUCONT
            Dim tbl As New DataTable
            tbl = objdatos1.fun_Buscar_CODIGO_MANT_MENUCONT(id)

            If tbl.Rows.Count > 0 Then
                mod_MENSAJE.Codigo_Existente_En_Base_De_Datos()
                cboMECOCODI.Focus()
            Else
                Dim objdatos As New cla_MENUCONT

                If (objdatos.fun_Insertar_MANT_MENUCONT(cboMECOCODI.Text, txtMECODESC.Text, cboMECOESTA.SelectedValue)) Then
                    mod_MENSAJE.Se_Guardaron_Los_Datos_Correctamente()

                    If MessageBox.Show("¿ Desea agregar otro registro ?", "Mensaje...", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.No Then
                        pro_LimpiarCampos()
                        Me.Close()
                    Else
                        cboMECOCODI.Focus()
                        pro_LimpiarCampos()
                    End If
                Else
                    mod_MENSAJE.No_Se_Guardo_El_Registro_En_La_Base_De_Datos()
                End If
            End If
        End If

    End Sub
    Private Sub cmdCANCELAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSALIR.Click
        Me.Close()
    End Sub

#End Region

#Region "FORMULARIO"

    Private Sub frm_insertar_CLASSECT_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        pro_inicializarControles()
        pro_LimpiarCampos()

        cboMECOCODI.Focus()
    End Sub

    Private Sub cboMECOCODI_KeyPress1(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboMECOCODI.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            txtMECODESC.Focus()
        End If
    End Sub
    Private Sub txtMECODESC_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtMECODESC.KeyPress

        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            cboMECOESTA.Focus()
        End If

    End Sub
    Private Sub cboMECOESTA_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboMECOESTA.KeyPress

        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            cmdGUARDAR.Focus()
        End If

    End Sub

    Private Sub cboMECOCODI_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs)
        If Trim(cboMECOCODI.Text) = "" Then
            cboMECOCODI.Focus()
            strBARRESTA.Items(1).Text = IncoValoNulo
        Else
            strBARRESTA.Items(0).Text = ""
            strBARRESTA.Items(1).Text = ""
        End If
    End Sub
    Private Sub txtMECODESC_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtMECODESC.LostFocus
        If Trim(txtMECODESC.Text) = "" Then
            txtMECODESC.Focus()
            strBARRESTA.Items(1).Text = IncoValoNulo
        Else
            strBARRESTA.Items(0).Text = ""
            strBARRESTA.Items(1).Text = ""
        End If
    End Sub
    Private Sub cboMECOESTA_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboMECOESTA.LostFocus
        strBARRESTA.Items(0).Text = ""
        strBARRESTA.Items(1).Text = ""
    End Sub
    Private Sub cmdGUARDAR_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdGUARDAR.LostFocus
        strBARRESTA.Items(0).Text = ""
        strBARRESTA.Items(1).Text = ""
    End Sub
    Private Sub cmdCANCELAR_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdSALIR.LostFocus
        strBARRESTA.Items(0).Text = ""
        strBARRESTA.Items(1).Text = ""
    End Sub

    Private Sub cboMECOCODI_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs)
        cboMECOCODI.SelectionStart = 0
        cboMECOCODI.SelectionLength = Len(cboMECOCODI.Text)
        strBARRESTA.Items(0).Text = cboMECOCODI.AccessibleDescription
    End Sub
    Private Sub txtMECODESC_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtMECODESC.GotFocus
        txtMECODESC.SelectionStart = 0
        txtMECODESC.SelectionLength = Len(txtMECODESC.Text)
        strBARRESTA.Items(0).Text = txtMECODESC.AccessibleDescription
    End Sub
    Private Sub cboMECOESTA_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboMECOESTA.GotFocus
        cboMECOESTA.SelectionStart = 0
        cboMECOESTA.SelectionLength = Len(cboMECOESTA.Text)
        strBARRESTA.Items(0).Text = cboMECOESTA.AccessibleDescription
    End Sub
    Private Sub cmdGUARDAR_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdGUARDAR.GotFocus
        strBARRESTA.Items(0).Text = cmdGUARDAR.AccessibleDescription
    End Sub
    Private Sub cmdCANCELAR_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdSALIR.GotFocus
        strBARRESTA.Items(0).Text = cmdSALIR.AccessibleDescription
    End Sub

    Private Sub cboLISTAMENU_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboMECOCODI.SelectedIndexChanged
        Dim seleccion As String

        seleccion = cboMECOCODI.SelectedIndex()

        Select Case seleccion
            Case 0
                cboMECOCODI.Text = cboMECOCODI.SelectedItem
            Case 1
                cboMECOCODI.Text = cboMECOCODI.SelectedItem
            Case 2
                cboMECOCODI.Text = cboMECOCODI.SelectedItem
            Case 3
                cboMECOCODI.Text = cboMECOCODI.SelectedItem
            Case 4
                cboMECOCODI.Text = cboMECOCODI.SelectedItem
            Case 5
                cboMECOCODI.Text = cboMECOCODI.SelectedItem
        End Select

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