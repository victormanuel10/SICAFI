Imports REGLAS_DEL_NEGOCIO

Public Class frm_insertar_PERMSUFO

    '===============================
    '*** INSERTAR SUBFORMULARIOS ***
    '===============================

#Region "VARIABLES"

    Private inContador As Integer = 0

#End Region

#Region "PROCEDIMIENTOS"

    Private Sub pro_inicializarControles()

        '=========================================
        ' CARGA LOS COMBOBOX CON LOS DATOS ACTIVOS
        '=========================================

        Try
            Dim objdatos As New cla_ESTADO

            cboPESFESTA.DataSource = objdatos.fun_Consultar_ESTADO_X_ESTADO
            cboPESFESTA.DisplayMember = "ESTADESC"
            cboPESFESTA.ValueMember = "ESTACODI"

            Dim objdatos1 As New cla_CONTRASENA

            cboPESFUSUA.DataSource = objdatos1.fun_Consultar_USUARIO_CONTRASENA_X_ESTADO
            cboPESFUSUA.DisplayMember = "CONTUSUA"
            cboPESFUSUA.ValueMember = "CONTUSUA"

            Dim objdatos2 As New cla_PERMSUFO

            cboPESFFORM.DataSource = objdatos2.fun_Consultar_PERMSUFO_X_ESTADO
            cboPESFFORM.DisplayMember = "PESFDESC"
            cboPESFFORM.ValueMember = "PESFFORM"

            cboPESFUSUA.Focus()

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try


    End Sub
    Private Sub pro_LimpiarCampos()

        Me.chkPESFAGRE.Checked = False
        Me.chkPESFMODI.Checked = False
        Me.chkPESFELIM.Checked = False
        strBARRESTA.Items(1).Text = ""
        ErrorProvider1.SetError(Me.cboPESFFORM, "")

    End Sub


#End Region

#Region "MENU"

    Private Sub cmdGUARDAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGUARDAR.Click
        Try
            If fun_Verificar_Campos_Llenos_3_DATOS(Me.cboPESFUSUA.Text, Me.cboPESFFORM.Text, Me.cboPESFESTA.Text) = False Then
                mod_MENSAJE.Existen_Campos_Sin_Diligenciar()
                cboPESFUSUA.Focus()
            Else
                Dim stUsuario As String = Trim(cboPESFUSUA.Text)
                Dim stFormulario As String = Me.cboPESFFORM.SelectedValue

                Dim objdatos1 As New cla_PERMSUFO
                Dim tbl As New DataTable

                tbl = objdatos1.fun_Buscar_USUARIO_Y_FORMULARIO_PERMSUFO(stUsuario, stFormulario)

                If tbl.Rows.Count > 0 Then
                    MessageBox.Show("Formulario ya existe para el usuario", "Mensaje...", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1)
                    cboPESFFORM.Focus()
                Else
                    Dim objdatos As New cla_PERMSUFO

                    If (objdatos.fun_Insertar_PERMSUFO(Me.cboPESFUSUA.SelectedValue, Me.cboPESFFORM.SelectedValue, Me.cboPESFFORM.Text, Me.chkPESFAGRE.Checked, Me.chkPESFMODI.Checked, Me.chkPESFELIM.Checked, Me.cboPESFESTA.SelectedValue)) Then
                        mod_MENSAJE.Se_Guardaron_Los_Datos_Correctamente()

                        If MessageBox.Show("¿ Desea agregar otro registro ?", "Mensaje...", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.No Then
                            pro_LimpiarCampos()
                            cboPESFUSUA.Focus()
                            Me.Close()
                        Else
                            pro_LimpiarCampos()
                            cboPESFUSUA.Focus()
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
        cboPESFUSUA.Focus()
        Me.Close()
    End Sub


#End Region

#Region "FORMULARIO"

#Region "Load"

    Private Sub frm_insertar_ZONAECON_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        pro_inicializarControles()
        pro_LimpiarCampos()
        cboPESFUSUA.Focus()
    End Sub

#End Region

#Region "KeyPress"

    Private Sub cboPESFUSUA_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboPESFUSUA.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            cboPESFFORM.Focus()
        End If
    End Sub
    Private Sub cboPESFFORM_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboPESFFORM.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            chkPESFAGRE.Focus()
        End If
    End Sub
    Private Sub chkPESFAGRE_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles chkPESFAGRE.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            chkPESFMODI.Focus()
        End If
    End Sub
    Private Sub chkPESFMODI_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles chkPESFMODI.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            chkPESFELIM.Focus()
        End If
    End Sub
    Private Sub chkPESFELIM_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles chkPESFELIM.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            cboPESFESTA.Focus()
        End If
    End Sub
    Private Sub cboZOECESTA_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboPESFESTA.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            cmdGUARDAR.Focus()
        End If
    End Sub

#End Region

#Region "GotFocus"

    Private Sub cboPESFUSUA_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboPESFUSUA.GotFocus
        strBARRESTA.Items(0).Text = cboPESFUSUA.AccessibleDescription
    End Sub
    Private Sub cboPESFFORM_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboPESFFORM.GotFocus
        strBARRESTA.Items(0).Text = cboPESFFORM.AccessibleDescription
    End Sub
    Private Sub chkPESFAGRE_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkPESFAGRE.GotFocus
        strBARRESTA.Items(0).Text = chkPESFAGRE.AccessibleDescription
    End Sub
    Private Sub chkPESFMODI_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkPESFMODI.GotFocus
        strBARRESTA.Items(0).Text = chkPESFAGRE.AccessibleDescription
    End Sub
    Private Sub chkPESFELIM_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkPESFELIM.GotFocus
        strBARRESTA.Items(0).Text = chkPESFAGRE.AccessibleDescription
    End Sub
    Private Sub cboPESFESTA_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboPESFESTA.GotFocus
        strBARRESTA.Items(0).Text = cboPESFESTA.AccessibleDescription
    End Sub
    Private Sub cmdGUARDAR_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdGUARDAR.GotFocus
        strBARRESTA.Items(0).Text = cmdGUARDAR.AccessibleDescription
    End Sub
    Private Sub cmdCANCELAR_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdSALIR.GotFocus
        strBARRESTA.Items(0).Text = cmdSALIR.AccessibleDescription
    End Sub

#End Region

#Region "SelectedIndexChanged"

    Private Sub cboPESFUSUA_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboPESFUSUA.SelectedIndexChanged
        Me.lblPESFUSUA.Text = fun_BuscarNombrePorUsuario(Me.cboPESFUSUA.Text)
    End Sub
    Private Sub cboPESFFORM_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboPESFFORM.SelectedIndexChanged
        Me.lblPESFFORM.Text = fun_Buscar_Lista_Valores_SUBFORMULARIO(Me.cboPESFFORM.Text)
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