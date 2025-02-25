Imports REGLAS_DEL_NEGOCIO

Public Class frm_modificar_DESTECON

    '=======================================
    '*** MODIFICAR DESTINACIÓN ECONÓMICA ***
    '=======================================

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

        Try

            Dim objdatos As New cla_ESTADO

            cboDEECESTA.DataSource = objdatos.fun_Consultar_ESTADO_X_ESTADO
            cboDEECESTA.DisplayMember = "ESTADESC"
            cboDEECESTA.ValueMember = "ESTACODI"

            Dim objdatos1 As New cla_DESTECON
            Dim tbl As New DataTable

            tbl = objdatos1.fun_Buscar_ID_MANT_DESTECON(id)

            Me.txtDEECCODI.Text = Trim(tbl.Rows(0).Item(1))
            Me.txtDEECDESC.Text = Trim(tbl.Rows(0).Item(2))
            Me.cboDEECESTA.SelectedValue = tbl.Rows(0).Item(3)
            Me.chkDEECLOTE.Checked = tbl.Rows(0).Item(4)

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub pro_LimpiarCampos()

        txtDEECCODI.Text = ""
        txtDEECDESC.Text = ""
        strBARRESTA.Items(1).Text = ""

    End Sub

#End Region

#Region "MENU"

    Private Sub cmdGUARDAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGUARDAR.Click
        Try
            If fun_Verificar_Campos_Llenos_3_DATOS(txtDEECCODI.Text, txtDEECDESC.Text, cboDEECESTA.Text) = False Then
                mod_MENSAJE.Existen_Campos_Sin_Diligenciar()
                txtDEECDESC.Focus()
            Else

                Dim objdatos As New cla_DESTECON

                If (objdatos.fun_Actualizar_MANT_DESTECON(id, txtDEECCODI.Text, txtDEECDESC.Text, cboDEECESTA.SelectedValue, Me.chkDEECLOTE.Checked)) Then
                    mod_MENSAJE.Se_Modificaron_Los_Datos_Correctamente()
                    txtDEECDESC.Focus()
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
        txtDEECDESC.Focus()
        Me.Close()

    End Sub

#End Region

#Region "FORMULARIO"

#Region "KeyPress"

    Private Sub txtDEECCODI_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtDEECCODI.KeyPress
        If Not Char.IsNumber(e.KeyChar) Then
            If e.KeyChar <> Convert.ToChar(Keys.Back) Then
                If e.KeyChar <> Convert.ToChar(Keys.Enter) Then
                    e.Handled = True
                    strBARRESTA.Items(1).Text = IncoValoNume
                    mod_MENSAJE.Inco_Valo_Nume()
                Else
                    txtDEECDESC.Focus()
                End If
            End If
        End If
    End Sub
    Private Sub txtDEECDESC_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtDEECDESC.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            cboDEECESTA.Focus()
        End If
    End Sub
    Private Sub cboDEECESTA_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboDEECESTA.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            cmdGUARDAR.Focus()
        End If
    End Sub

#End Region

#Region "Validated"

    Private Sub txtDEECDESC_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtDEECDESC.Validated
        If Trim(txtDEECDESC.Text) = "" Then
            txtDEECDESC.Focus()
            strBARRESTA.Items(1).Text = IncoValoNulo
        Else
            strBARRESTA.Items(0).Text = ""
            strBARRESTA.Items(1).Text = ""
        End If
    End Sub
    Private Sub cboDEECESTA_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboDEECESTA.Validated
        strBARRESTA.Items(0).Text = ""
        strBARRESTA.Items(1).Text = ""
    End Sub

#End Region

#Region "GotFocus"

    Private Sub txtDEECCODI_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtDEECCODI.GotFocus
        txtDEECCODI.SelectionStart = 0
        txtDEECCODI.SelectionLength = Len(txtDEECCODI.Text)
        strBARRESTA.Items(0).Text = txtDEECCODI.AccessibleDescription
    End Sub
    Private Sub txtDEECDESC_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtDEECDESC.GotFocus
        txtDEECDESC.SelectionStart = 0
        txtDEECDESC.SelectionLength = Len(txtDEECDESC.Text)
        strBARRESTA.Items(0).Text = txtDEECDESC.AccessibleDescription
    End Sub
    Private Sub cboDEECESTA_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboDEECESTA.GotFocus
        cboDEECESTA.SelectionStart = 0
        cboDEECESTA.SelectionLength = Len(cboDEECESTA.Text)
        strBARRESTA.Items(0).Text = cboDEECESTA.AccessibleDescription
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