Imports REGLAS_DEL_NEGOCIO

Public Class frm_modificar_TIPOCALI

    '======================================
    '*** MODIFICAR TIPO DE CALIFICACIÓN ***
    '======================================

#Region "VARIABLES"

    Dim id As Integer

#End Region

#Region "CONSTRUCTOR"

    Public Sub New(ByVal idRegistro As Integer)
        id = idRegistro
        InitializeComponent()
        pro_inicializarControles()

    End Sub

#End Region

#Region "PROCEDIMIENTOS"

    Public Sub pro_inicializarControles()
        Dim objdatos As New cla_ESTADO

        cboTICAESTA.DataSource = objdatos.fun_Consultar_ESTADO_X_ESTADO
        cboTICAESTA.DisplayMember = "ESTADESC"
        cboTICAESTA.ValueMember = "ESTACODI"

        Dim objdatos1 As New cla_TIPOCALI
        Dim tbl As New DataTable

        tbl = objdatos1.fun_Buscar_ID_MANT_TIPOCALI(id)

        txtTICACODI.Text = Trim(tbl.Rows(0).Item(1))
        txtTICADESC.Text = Trim(tbl.Rows(0).Item(2))
        cboTICAESTA.SelectedValue = tbl.Rows(0).Item(3)


    End Sub
    Private Sub pro_LimpiarCampos()

        txtTICACODI.Text = ""
        txtTICADESC.Text = ""
        strBARRESTA.Items(1).Text = ""

    End Sub

#End Region

#Region "MENU"

    Private Sub cmdGUARDAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGUARDAR.Click
        Try
            If fun_Verificar_Campos_Llenos_3_DATOS(txtTICACODI.Text, txtTICADESC.Text, cboTICAESTA.Text) = False Then
                mod_MENSAJE.Existen_Campos_Sin_Diligenciar()
                txtTICADESC.Focus()
            Else

                Dim objdatos As New cla_TIPOCALI

                If (objdatos.fun_Actualizar_MANT_TIPOCALI(id, txtTICACODI.Text, txtTICADESC.Text, cboTICAESTA.SelectedValue)) Then
                    mod_MENSAJE.Se_Modificaron_Los_Datos_Correctamente()
                    txtTICADESC.Focus()
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
        txtTICADESC.Focus()
        Me.Close()
    End Sub

#End Region

#Region "FORMULARIO"

#Region "KeyPress"

    Private Sub txtTICACODI_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtTICACODI.KeyPress
        If Not Char.IsNumber(e.KeyChar) Then
            If e.KeyChar <> Convert.ToChar(Keys.Back) Then
                If e.KeyChar <> Convert.ToChar(Keys.Enter) Then
                    e.Handled = True
                    strBARRESTA.Items(1).Text = IncoValoNume
                    mod_MENSAJE.Inco_Valo_Nume()
                Else
                    txtTICADESC.Focus()
                End If
            End If
        End If
    End Sub
    Private Sub txtTICADESC_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtTICADESC.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            cboTICAESTA.Focus()
        End If
    End Sub
    Private Sub cboTICAESTA_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboTICAESTA.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            cmdGUARDAR.Focus()
        End If
    End Sub

#End Region

#Region "Validated"

    Private Sub txtTICADESC_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtTICADESC.Validated
        If Trim(txtTICADESC.Text) = "" Then
            txtTICADESC.Focus()
            strBARRESTA.Items(1).Text = IncoValoNulo
        Else
            strBARRESTA.Items(0).Text = ""
            strBARRESTA.Items(1).Text = ""
        End If
    End Sub
    Private Sub cboTICAESTA_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboTICAESTA.Validated
        strBARRESTA.Items(0).Text = ""
        strBARRESTA.Items(1).Text = ""
    End Sub

#End Region

#Region "GotFocus"

    Private Sub txtTICACODI_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtTICACODI.GotFocus
        txtTICACODI.SelectionStart = 0
        txtTICACODI.SelectionLength = Len(txtTICACODI.Text)
        strBARRESTA.Items(0).Text = txtTICACODI.AccessibleDescription
    End Sub
    Private Sub txtTICADESC_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtTICADESC.GotFocus
        txtTICADESC.SelectionStart = 0
        txtTICADESC.SelectionLength = Len(txtTICADESC.Text)
        strBARRESTA.Items(0).Text = txtTICADESC.AccessibleDescription
    End Sub
    Private Sub cboTICAESTA_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboTICAESTA.GotFocus
        cboTICAESTA.SelectionStart = 0
        cboTICAESTA.SelectionLength = Len(cboTICAESTA.Text)
        strBARRESTA.Items(0).Text = cboTICAESTA.AccessibleDescription
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