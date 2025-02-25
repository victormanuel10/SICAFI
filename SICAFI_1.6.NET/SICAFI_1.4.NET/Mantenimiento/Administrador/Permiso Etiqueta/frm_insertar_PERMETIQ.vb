Imports REGLAS_DEL_NEGOCIO

Public Class frm_insertar_PERMETIQ

    '==========================
    '*** INSERTAR ETIQUETAS ***
    '==========================

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

            cboPEETESTA.DataSource = objdatos.fun_Consultar_ESTADO_X_ESTADO
            cboPEETESTA.DisplayMember = "ESTADESC"
            cboPEETESTA.ValueMember = "ESTACODI"

           

          

            cboPEETUSUA.Focus()

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try


    End Sub
    Private Sub pro_LimpiarCampos()

        Me.strBARRESTA.Items(1).Text = ""
        Me.ErrorProvider1.SetError(Me.cboPEETETIQ, "")

        Me.cboPEETETIQ.DataSource = New DataTable
        Me.cboPEETUSUA.DataSource = New DataTable

        Me.lblPEETETIQ.Text = ""
        Me.lblPEETUSUA.Text = ""

    End Sub


#End Region

#Region "MENU"

    Private Sub cmdGUARDAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGUARDAR.Click
        Try
            If fun_Verificar_Campos_Llenos_3_DATOS(Me.cboPEETUSUA.Text, Me.cboPEETETIQ.Text, Me.cboPEETESTA.Text) = False Then
                mod_MENSAJE.Existen_Campos_Sin_Diligenciar()
                cboPEETUSUA.Focus()
            Else
                Dim stUsuario As String = Trim(cboPEETUSUA.Text)
                Dim stFormulario As String = Me.cboPEETETIQ.SelectedValue

                Dim objdatos1 As New cla_PERMETIQ
                Dim tbl As New DataTable

                tbl = objdatos1.fun_Buscar_USUARIO_Y_ETIQUETA_PERMETIQ(stUsuario, stFormulario)

                If tbl.Rows.Count > 0 Then
                    MessageBox.Show("Etiqueta ya existe para el usuario", "Mensaje...", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1)
                    cboPEETETIQ.Focus()
                Else
                    Dim objdatos As New cla_PERMETIQ

                    If (objdatos.fun_Insertar_PERMETIQ(Me.cboPEETUSUA.SelectedValue, Me.cboPEETETIQ.SelectedValue, Me.cboPEETETIQ.Text, Me.cboPEETESTA.SelectedValue)) Then
                        mod_MENSAJE.Se_Guardaron_Los_Datos_Correctamente()

                        If MessageBox.Show("¿ Desea agregar otro registro ?", "Mensaje...", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.No Then
                            pro_LimpiarCampos()
                            cboPEETUSUA.Focus()
                            Me.Close()
                        Else
                            pro_LimpiarCampos()
                            cboPEETUSUA.Focus()
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
        cboPEETUSUA.Focus()
        Me.Close()
    End Sub

#End Region

#Region "FORMULARIO"

#Region "Load"

    Private Sub frm_insertar_PERMETIQ_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        pro_inicializarControles()
        pro_LimpiarCampos()
        cboPEETUSUA.Focus()
    End Sub

#End Region

#Region "KeyPress"

   

    Private Sub cboPEFOUSUA_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboPEETUSUA.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            cboPEETETIQ.Focus()
        End If
    End Sub
    Private Sub cboPEFOFORM_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboPEETETIQ.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            cboPEETESTA.Focus()
        End If
    End Sub
    Private Sub cboZOECESTA_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboPEETESTA.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            cmdGUARDAR.Focus()
        End If
    End Sub

#End Region

#Region "GotFocus"

    Private Sub cboPEFOUSUA_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboPEETUSUA.GotFocus
        strBARRESTA.Items(0).Text = cboPEETUSUA.AccessibleDescription
    End Sub
    Private Sub cboPEFOFORM_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboPEETETIQ.GotFocus
        strBARRESTA.Items(0).Text = cboPEETETIQ.AccessibleDescription
    End Sub
    Private Sub cboPEFOESTA_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboPEETESTA.GotFocus
        strBARRESTA.Items(0).Text = cboPEETESTA.AccessibleDescription
    End Sub
    Private Sub cmdGUARDAR_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdGUARDAR.GotFocus
        strBARRESTA.Items(0).Text = cmdGUARDAR.AccessibleDescription
    End Sub
    Private Sub cmdCANCELAR_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdSALIR.GotFocus
        strBARRESTA.Items(0).Text = cmdSALIR.AccessibleDescription
    End Sub

#End Region

#Region "Click"

    Private Sub cboPEETUSUA_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboPEETUSUA.Click

        Dim objdatos1 As New cla_CONTRASENA

        cboPEETUSUA.DataSource = objdatos1.fun_Consultar_CAMPOS_CONTRASENA
        cboPEETUSUA.DisplayMember = "CONTUSUA"
        cboPEETUSUA.ValueMember = "CONTUSUA"

    End Sub
    Private Sub cboPEETETIQ_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboPEETETIQ.Click

        Dim objdatos2 As New cla_PERMETIQ

        cboPEETETIQ.DataSource = objdatos2.fun_Consultar_PERMETIQ_X_ESTADO
        cboPEETETIQ.DisplayMember = "PEETDESC"
        cboPEETETIQ.ValueMember = "PEETETIQ"

    End Sub

#End Region

#Region "SelectedIndexChanged"

    Private Sub cboPEFOUSUA_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboPEETUSUA.SelectedIndexChanged
        Me.lblPEETUSUA.Text = fun_BuscarNombrePorUsuario(Me.cboPEETUSUA.Text)
    End Sub
    Private Sub cboPEFOFORM_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboPEETETIQ.SelectedIndexChanged
        Me.lblPEETETIQ.Text = fun_Buscar_Lista_Valores_ETIQUETAS(Me.cboPEETETIQ.SelectedValue)
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