Imports REGLAS_DEL_NEGOCIO

Public Class frm_modificar_CLASSECT

    '================================
    '*** MODIFICAR CLASE O SECTOR ***
    '================================

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
   
#Region "VARIABLES LOCALES"

    '*** SW VERIFICAR CAMPOS LLENOS QUE VAN A LA DB ***
    Dim SWVerificarCamposLlenos As Boolean = False

#End Region

#Region "PROCEDIMIENTOS"

    Public Sub pro_inicializarControles()
        Dim objdatos As New cla_ESTADO

        cboCLSEESTA.DataSource = objdatos.fun_Consultar_ESTADO_X_ESTADO
        cboCLSEESTA.DisplayMember = "ESTADESC"
        cboCLSEESTA.ValueMember = "ESTACODI"

        Dim objdatos1 As New cla_CLASSECT
        Dim tbl As New DataTable

        tbl = objdatos1.fun_Buscar_ID_MANT_CLASSECT(id)

        txtCLSECODI.Text = Trim(tbl.Rows(0).Item(1))
        txtCLSEDESC.Text = Trim(tbl.Rows(0).Item(2))
        cboCLSEESTA.SelectedValue = tbl.Rows(0).Item(3)


    End Sub
    Private Sub pro_LimpiarCampos()

        txtCLSECODI.Text = ""
        txtCLSEDESC.Text = ""
        strBARRESTA.Items(1).Text = ""

    End Sub
#End Region

#Region "MENU"

    Private Sub cmdGUARDAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGUARDAR.Click
        Try
            If fun_Verificar_Campos_Llenos_3_DATOS(txtCLSECODI.Text, txtCLSEDESC.Text, cboCLSEESTA.Text) = False Then
                mod_MENSAJE.Existen_Campos_Sin_Diligenciar()
                txtCLSEDESC.Focus()
            Else

                Dim objdatos As New cla_CLASSECT

                If (objdatos.fun_Actualizar_MANT_CLASSECT(id, txtCLSECODI.Text, txtCLSEDESC.Text, cboCLSEESTA.SelectedValue)) Then
                    mod_MENSAJE.Se_Modificaron_Los_Datos_Correctamente()
                    txtCLSEDESC.Focus()
                    Me.Close()
                Else
                    mod_MENSAJE.No_Se_Modifico_El_Registro_En_La_Base_De_Datos()
                End If

            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub cmdCANCELAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSALIR.Click
        txtCLSEDESC.Focus()
        Me.Close()

    End Sub

#End Region

#Region "FORMULARIO"

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
        If Trim(txtCLSECODI.Text) = "" Then
            txtCLSECODI.Focus()
            strBARRESTA.Items(1).Text = IncoValoNulo
        Else
            strBARRESTA.Items(0).Text = ""
            strBARRESTA.Items(1).Text = ""
        End If
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