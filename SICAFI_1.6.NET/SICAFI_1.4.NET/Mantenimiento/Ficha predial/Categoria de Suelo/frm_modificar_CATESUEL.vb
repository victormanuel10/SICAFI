Imports REGLAS_DEL_NEGOCIO

Public Class frm_modificar_CATESUEL

    '====================================
    '*** MODIFICAR CATEGORIA DE SUELO ***
    '====================================

#Region "VARIABLES"

    Dim id As Integer

#End Region

#Region "CONSTRUCTOR"

    Public Sub New(ByVal idPersona As Integer)
        id = idPersona
        InitializeComponent()
        pro_inicializarControles()

    End Sub

#End Region

#Region "PROCEDIMIENTOS"

    Public Sub pro_inicializarControles()
        Dim objdatos As New cla_ESTADO

        cboCASUESTA.DataSource = objdatos.fun_Consultar_ESTADO_X_ESTADO
        cboCASUESTA.DisplayMember = "ESTADESC"
        cboCASUESTA.ValueMember = "ESTACODI"

        Dim objdatos1 As New cla_CATESUEL
        Dim tbl As New DataTable

        tbl = objdatos1.fun_Buscar_ID_MANT_CATESUEL(id)

        txtCASUCODI.Text = Trim(tbl.Rows(0).Item(1))
        txtCASUDESC.Text = Trim(tbl.Rows(0).Item(2))
        cboCASUESTA.SelectedValue = tbl.Rows(0).Item(3)

    End Sub
    Private Sub pro_LimpiarCampos()

        txtCASUCODI.Text = ""
        txtCASUDESC.Text = ""
        strBARRESTA.Items(1).Text = ""

    End Sub

#End Region

#Region "MENU"

    Private Sub cmdGUARDAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGUARDAR.Click
        Try
            If fun_Verificar_Campos_Llenos_3_DATOS(txtCASUCODI.Text, txtCASUDESC.Text, cboCASUESTA.Text) = False Then
                mod_MENSAJE.Existen_Campos_Sin_Diligenciar()
                txtCASUDESC.Focus()
            Else
                Dim objdatos As New cla_CATESUEL

                If (objdatos.fun_Actualizar_MANT_CATESUEL(id, txtCASUCODI.Text, txtCASUDESC.Text, cboCASUESTA.SelectedValue)) Then
                    mod_MENSAJE.Se_Modificaron_Los_Datos_Correctamente()
                    txtCASUDESC.Focus()
                    Me.Close()
                Else
                    mod_MENSAJE.No_Se_Modifico_El_Registro_En_La_Base_De_Datos()
                End If

            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description & "Modificar")
        End Try

    End Sub
    Private Sub cmdCANCELAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSALIR.Click
        txtCASUDESC.Focus()
        Me.Close()

    End Sub

#End Region

#Region "FORMULARIO"

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