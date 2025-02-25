Imports REGLAS_DEL_NEGOCIO

Public Class frm_modificar_VIGENCIA

    '==========================
    '*** MODIFICAR VIGENCIA ***
    '==========================

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

        cboVIGEESTA.DataSource = objdatos.fun_Consultar_Estado_X_Estado
        cboVIGEESTA.DisplayMember = "ESTADESC"
        cboVIGEESTA.ValueMember = "ESTACODI"

        Dim objdatos1 As New cla_VIGENCIA
        Dim tbl As New DataTable

        tbl = objdatos1.fun_Buscar_ID_VIGENCIA(id)

        txtVIGECODI.Text = Trim(tbl.Rows(0).Item(1))
        txtVIGEDESC.Text = Trim(tbl.Rows(0).Item(2))
        cboVIGEESTA.SelectedValue = tbl.Rows(0).Item(3)


    End Sub
    Private Sub pro_VerificarCamposLlenos()
        '*** CAMPOS OBLIGATORIOS ***

        Try
            If Trim(txtVIGECODI.Text) = "" Or _
               Trim(txtVIGEDESC.Text) = "" Or _
               Trim(cboVIGEESTA.Text) = "" Then
                SWVerificarCamposLlenos = False
            Else
                SWVerificarCamposLlenos = True 'Los campos estan bien diligenciados
            End If

        Catch ex As Exception
            MessageBox.Show("" & Err.Description & "")
        End Try

    End Sub
    Private Sub pro_LimpiarCampos()

        txtVIGECODI.Text = ""
        txtVIGEDESC.Text = ""
        strBARRESTA.Items(1).Text = ""

    End Sub
#End Region

#Region "MENU"

    Private Sub cmdGUARDAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGUARDAR.Click

        pro_VerificarCamposLlenos()

        If SWVerificarCamposLlenos = True Then

            Dim objdatos As New cla_VIGENCIA

            If (objdatos.fun_Actualizar_VIGENCIA(id, txtVIGECODI.Text, txtVIGEDESC.Text, cboVIGEESTA.SelectedValue)) Then
                mod_MENSAJE.Se_Modificaron_Los_Datos_Correctamente()
                Me.Close()
            Else
                mod_MENSAJE.No_Se_Modifico_El_Registro_En_La_Base_De_Datos()
            End If

        Else
            mod_MENSAJE.Existen_Campos_Sin_Diligenciar()
            txtVIGECODI.Focus()
        End If

    End Sub
    Private Sub cmdCANCELAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSALIR.Click
        Me.Close()

    End Sub

#End Region

#Region "FORMULARIO"

    Private Sub txtVIGECODI_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtVIGECODI.KeyPress

        If Not Char.IsNumber(e.KeyChar) Then
            If e.KeyChar <> Convert.ToChar(Keys.Back) Then
                If e.KeyChar <> Convert.ToChar(Keys.Enter) Then
                    e.Handled = True
                    strBARRESTA.Items(1).Text = IncoValoNume
                    mod_MENSAJE.Inco_Valo_Nume()
                Else
                    txtVIGEDESC.Focus()
                End If
            End If
        End If

    End Sub
    Private Sub txtVIGEDESC_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtVIGEDESC.KeyPress

        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            cboVIGEESTA.Focus()
        End If

    End Sub
    Private Sub cboVIGEESTA_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboVIGEESTA.KeyPress

        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            cmdGUARDAR.Focus()
        End If

    End Sub

    Private Sub txtVIGEDESC_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtVIGEDESC.Validated
        If Trim(txtVIGEDESC.Text) = "" Then
            txtVIGEDESC.Focus()
            strBARRESTA.Items(1).Text = IncoValoNulo
        Else
            strBARRESTA.Items(0).Text = ""
            strBARRESTA.Items(1).Text = ""
        End If
    End Sub
    Private Sub cboVIGEESTA_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboVIGEESTA.Validated
        strBARRESTA.Items(0).Text = ""
        strBARRESTA.Items(1).Text = ""
    End Sub

    Private Sub txtVIGECODI_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtVIGECODI.GotFocus
        txtVIGECODI.SelectionStart = 0
        txtVIGECODI.SelectionLength = Len(txtVIGECODI.Text)
        strBARRESTA.Items(0).Text = txtVIGECODI.AccessibleDescription
    End Sub
    Private Sub txtVIGEDESC_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtVIGEDESC.GotFocus
        txtVIGEDESC.SelectionStart = 0
        txtVIGEDESC.SelectionLength = Len(txtVIGEDESC.Text)
        strBARRESTA.Items(0).Text = txtVIGEDESC.AccessibleDescription
    End Sub
    Private Sub cboVIGEESTA_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboVIGEESTA.GotFocus
        cboVIGEESTA.SelectionStart = 0
        cboVIGEESTA.SelectionLength = Len(cboVIGEESTA.Text)
        strBARRESTA.Items(0).Text = cboVIGEESTA.AccessibleDescription
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