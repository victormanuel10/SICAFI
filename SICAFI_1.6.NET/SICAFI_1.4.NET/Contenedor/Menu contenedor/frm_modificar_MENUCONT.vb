Public Class frm_modificar_MENUCONT

    '=================================
    '*** MODIFICAR MENU CONTENEDOR ***
    '=================================

    Dim id As Integer

    Public Sub New(ByVal idPersona As Integer)
        id = idPersona
        InitializeComponent()
        pro_inicializarControles()

    End Sub

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

        Dim objdatos1 As New cla_MENUCONT
        Dim tbl As New DataTable

        tbl = objdatos1.fun_Buscar_ID_MANT_MENUCONT(id)

        txtMECOCODI.Text = Trim(tbl.Rows(0).Item(1))
        txtMECODESC.Text = Trim(tbl.Rows(0).Item(2))
        cboMECOESTA.SelectedValue = tbl.Rows(0).Item(3)


    End Sub
    Private Sub pro_VerificarCamposLlenos()
        '*** CAMPOS OBLIGATORIOS ***

        Try
            If Trim(txtMECOCODI.Text) = "" Or _
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

        txtMECOCODI.Text = ""
        txtMECODESC.Text = ""
        strBARRESTA.Items(1).Text = ""

    End Sub
#End Region

#Region "MENU"

    Private Sub cmdGUARDAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGUARDAR.Click

        pro_VerificarCamposLlenos()

        If SWVerificarCamposLlenos = True Then

            Dim objdatos As New cla_MENUCONT

            If (objdatos.fun_Actualizar_MANT_MENUCONT(id, txtMECOCODI.Text, txtMECODESC.Text, cboMECOESTA.SelectedValue)) Then
                MessageBox.Show("Se modificaron los datos correctamente", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                Me.Close()
            Else
                MessageBox.Show("No se modificaron los datos", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1)
            End If

        Else
            MessageBox.Show("Existen campos sin diligenciar", "Mensaje error", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1)
            txtMECOCODI.Focus()
        End If

    End Sub
    Private Sub cmdCANCELAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCANCELAR.Click
        Me.Close()

    End Sub

#End Region

#Region "FORMULARIO"

    Private Sub txtMECOCODI_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtMECOCODI.KeyPress

        If Not Char.IsNumber(e.KeyChar) Then
            If e.KeyChar <> Convert.ToChar(Keys.Back) Then
                If e.KeyChar <> Convert.ToChar(Keys.Enter) Then
                    e.Handled = True
                    strBARRESTA.Items(1).Text = IncoValoNume
                    mod_Mensajes.Inco_Valo_Nume()
                Else
                    txtMECODESC.Focus()
                End If
            End If
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

    Private Sub txtMECOCODI_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtMECOCODI.LostFocus
        If Trim(txtMECOCODI.Text) = "" Then
            txtMECOCODI.Focus()
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
    Private Sub cmdCANCELAR_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdCANCELAR.LostFocus
        strBARRESTA.Items(0).Text = ""
        strBARRESTA.Items(1).Text = ""
    End Sub

    Private Sub txtMECOCODI_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtMECOCODI.GotFocus
        txtMECOCODI.SelectionStart = 0
        txtMECOCODI.SelectionLength = Len(txtMECOCODI.Text)
        strBARRESTA.Items(0).Text = txtMECOCODI.AccessibleDescription
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
    Private Sub cmdCANCELAR_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdCANCELAR.GotFocus
        strBARRESTA.Items(0).Text = cmdCANCELAR.AccessibleDescription
    End Sub



#End Region


    
End Class