Imports REGLAS_DEL_NEGOCIO

Public Class frm_insertar_PERMFORM

    '============================
    '*** INSERTAR FORMULARIOS ***
    '============================

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

            cboPEFOESTA.DataSource = objdatos.fun_Consultar_ESTADO_X_ESTADO
            cboPEFOESTA.DisplayMember = "ESTADESC"
            cboPEFOESTA.ValueMember = "ESTACODI"

            Dim objdatos1 As New cla_CONTRASENA

            cboPEFOUSUA.DataSource = objdatos1.fun_Consultar_USUARIO_CONTRASENA_X_ESTADO
            cboPEFOUSUA.DisplayMember = "CONTUSUA"
            cboPEFOUSUA.ValueMember = "CONTUSUA"

            Dim objdatos2 As New cla_PERMFORM

            cboPEFOFORM.DataSource = objdatos2.fun_Consultar_PERMFORM_X_ESTADO
            cboPEFOFORM.DisplayMember = "PEFODESC"
            cboPEFOFORM.ValueMember = "PEFOFORM"

            cboPEFOUSUA.Focus()

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try


    End Sub
    Private Sub pro_LimpiarCampos()

        Me.chkPEFOAGRE.Checked = False
        Me.chkPEFOMODI.Checked = False
        Me.chkPEFOELIM.Checked = False
        strBARRESTA.Items(1).Text = ""
        ErrorProvider1.SetError(Me.cboPEFOFORM, "")

    End Sub


#End Region

#Region "MENU"

    Private Sub cmdGUARDAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGUARDAR.Click
        Try
            If fun_Verificar_Campos_Llenos_3_DATOS(Me.cboPEFOUSUA.Text, Me.cboPEFOFORM.Text, Me.cboPEFOESTA.Text) = False Then
                mod_MENSAJE.Existen_Campos_Sin_Diligenciar()
                cboPEFOUSUA.Focus()
            Else
                Dim stUsuario As String = Trim(cboPEFOUSUA.Text)
                Dim stFormulario As String = Me.cboPEFOFORM.SelectedValue

                Dim objdatos1 As New cla_PERMFORM
                Dim tbl As New DataTable

                tbl = objdatos1.fun_Buscar_USUARIO_Y_FORMULARIO_PERMFORM(stUsuario, stFormulario)

                If tbl.Rows.Count > 0 Then
                    MessageBox.Show("Formulario ya existe para el usuario", "Mensaje...", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1)
                    cboPEFOFORM.Focus()
                Else
                    Dim objdatos As New cla_PERMFORM

                    If (objdatos.fun_Insertar_PERMFORM(Me.cboPEFOUSUA.SelectedValue, Me.cboPEFOFORM.SelectedValue, Me.cboPEFOFORM.Text, Me.chkPEFOAGRE.Checked, Me.chkPEFOMODI.Checked, Me.chkPEFOELIM.Checked, Me.cboPEFOESTA.SelectedValue)) Then
                        mod_MENSAJE.Se_Guardaron_Los_Datos_Correctamente()

                        If MessageBox.Show("¿ Desea agregar otro registro ?", "Mensaje...", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.No Then
                            pro_LimpiarCampos()
                            cboPEFOUSUA.Focus()
                            Me.Close()
                        Else
                            pro_LimpiarCampos()
                            cboPEFOUSUA.Focus()
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
        cboPEFOUSUA.Focus()
        Me.Close()
    End Sub


#End Region

#Region "FORMULARIO"

#Region "Load"

    Private Sub frm_insertar_ZONAECON_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        pro_inicializarControles()
        pro_LimpiarCampos()
        cboPEFOUSUA.Focus()
    End Sub

#End Region

#Region "KeyPress"

    Private Sub cboPEFOUSUA_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboPEFOUSUA.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            cboPEFOFORM.Focus()
        End If
    End Sub
    Private Sub cboPEFOFORM_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboPEFOFORM.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            chkPEFOAGRE.Focus()
        End If
    End Sub
    Private Sub chkPEFOAGRE_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles chkPEFOAGRE.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            chkPEFOMODI.Focus()
        End If
    End Sub
    Private Sub chkPEFOMODI_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles chkPEFOMODI.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            chkPEFOELIM.Focus()
        End If
    End Sub
    Private Sub chkPEFOELIM_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles chkPEFOELIM.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            cboPEFOESTA.Focus()
        End If
    End Sub
    Private Sub cboZOECESTA_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboPEFOESTA.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            cmdGUARDAR.Focus()
        End If
    End Sub

#End Region

#Region "GotFocus"

    Private Sub cboPEFOUSUA_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboPEFOUSUA.GotFocus
        strBARRESTA.Items(0).Text = cboPEFOUSUA.AccessibleDescription
    End Sub
    Private Sub cboPEFOFORM_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboPEFOFORM.GotFocus
        strBARRESTA.Items(0).Text = cboPEFOFORM.AccessibleDescription
    End Sub
    Private Sub chkPEFOAGRE_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkPEFOAGRE.GotFocus
        strBARRESTA.Items(0).Text = chkPEFOAGRE.AccessibleDescription
    End Sub
    Private Sub chkPEFOMODI_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkPEFOMODI.GotFocus
        strBARRESTA.Items(0).Text = chkPEFOAGRE.AccessibleDescription
    End Sub
    Private Sub chkPEFOELIM_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkPEFOELIM.GotFocus
        strBARRESTA.Items(0).Text = chkPEFOAGRE.AccessibleDescription
    End Sub
    Private Sub cboPEFOESTA_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboPEFOESTA.GotFocus
        strBARRESTA.Items(0).Text = cboPEFOESTA.AccessibleDescription
    End Sub
    Private Sub cmdGUARDAR_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdGUARDAR.GotFocus
        strBARRESTA.Items(0).Text = cmdGUARDAR.AccessibleDescription
    End Sub
    Private Sub cmdCANCELAR_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdSALIR.GotFocus
        strBARRESTA.Items(0).Text = cmdSALIR.AccessibleDescription
    End Sub

#End Region

#Region "SelectedIndexChanged"

    Private Sub cboPEFOUSUA_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboPEFOUSUA.SelectedIndexChanged
        Me.lblPEFOUSUA.Text = CType(fun_BuscarNombrePorUsuario(Trim(Me.cboPEFOUSUA.Text)), String)
    End Sub
    Private Sub cboPEFOFORM_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboPEFOFORM.SelectedIndexChanged
        Me.lblPEFOFORM.Text = CType(fun_Buscar_Lista_Valores_FORMULARIO(Trim(Me.cboPEFOFORM.Text)), String)
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