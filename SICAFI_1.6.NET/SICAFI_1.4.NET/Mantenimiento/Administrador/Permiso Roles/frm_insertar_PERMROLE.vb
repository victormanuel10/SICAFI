Imports REGLAS_DEL_NEGOCIO

Public Class frm_insertar_PERMROLE

    '===============================
    ' *** INSERTER PERMISO ROLES ***
    '===============================

#Region "VARIABLES"

    Private inContador1 As Integer = 0
    Private inContador2 As Integer = 0
    Private stUsuario As String = ""
    Private stRoles As String = ""

#End Region

#Region "PROCEDIMIENTOS"

    Private Sub pro_inicializarControles()

        '=========================================
        ' CARGA LOS COMBOBOX CON LOS DATOS ACTIVOS
        '=========================================

        Try
            Dim objdatos As New cla_ESTADO

            cboPEROESTA.DataSource = objdatos.fun_Consultar_ESTADO_X_ESTADO
            cboPEROESTA.DisplayMember = "ESTADESC"
            cboPEROESTA.ValueMember = "ESTACODI"

            Dim objdatos1 As New cla_CONTRASENA

            cboPEROUSUA.DataSource = objdatos1.fun_Consultar_USUARIO_CONTRASENA_X_ESTADO
            cboPEROUSUA.DisplayMember = "CONTUSUA"
            cboPEROUSUA.ValueMember = "CONTUSUA"

            Dim objdatos2 As New cla_CONTRASENA

            cboPEROROLE.DataSource = objdatos2.fun_Consultar_USUARIO_CONTRASENA_X_ESTADO
            cboPEROROLE.DisplayMember = "CONTUSUA"
            cboPEROROLE.ValueMember = "CONTUSUA"

            cboPEROUSUA.Focus()

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try


    End Sub
    Private Sub pro_LimpiarCampos()

        strBARRESTA.Items(1).Text = ""

    End Sub
  
#End Region

#Region "MENU"

    Private Sub cmdGUARDAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGUARDAR.Click
        Try
            If fun_Verificar_Campos_Llenos_3_DATOS(Me.cboPEROUSUA.Text, Me.cboPEROROLE.Text, Me.cboPEROESTA.Text) = False Then
                mod_MENSAJE.Existen_Campos_Sin_Diligenciar()
                cboPEROUSUA.Focus()
            Else
                Dim stUsuario As String = Trim(cboPEROUSUA.Text)
                Dim stRoles As String = Trim(cboPEROROLE.Text)

                Dim objdatos1 As New cla_PERMROLE
                Dim tbl As New DataTable

                tbl = objdatos1.fun_Buscar_CODIGO_PERMROLE(stUsuario, stRoles)

                ' consulta el roles para el usuario
                If tbl.Rows.Count > 0 Then
                    MessageBox.Show("Roles ya existe para el usuario", "Mensaje...", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1)
                    cboPEROROLE.Focus()
                Else
                    ' verifica que el roles asignado no se asigne asi mismo
                    If Trim(Me.cboPEROUSUA.SelectedValue) = Trim(Me.cboPEROROLE.SelectedValue) Then
                        MessageBox.Show("Asignación de roles incorrecta", "Mensaje...", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1)
                        cboPEROROLE.Focus()
                    Else
                        Dim objdatos45 As New cla_PERMROLE
                        Dim obj45 As New DataTable

                        obj45 = objdatos45.fun_Buscar_USUARIO_PERMROLE(Trim(Me.cboPEROUSUA.SelectedValue))

                        ' consulta que el usuario ya no tenga un roles
                        If obj45.Rows.Count > 0 Then
                            MessageBox.Show("El usuario ya posee un roles", "Mensaje...", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1)
                            cboPEROROLE.Focus()
                        Else
                            Dim objdatos As New cla_PERMROLE

                            If (objdatos.fun_Insertar_PERMROLE(Me.cboPEROUSUA.SelectedValue, Me.cboPEROROLE.SelectedValue, Me.cboPEROESTA.SelectedValue)) Then
                                mod_MENSAJE.Se_Guardaron_Los_Datos_Correctamente()

                                If MessageBox.Show("¿ Desea agregar otro registro ?", "Mensaje...", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.No Then
                                    pro_LimpiarCampos()
                                    cboPEROUSUA.Focus()
                                    Me.Close()
                                Else
                                    pro_LimpiarCampos()
                                    cboPEROUSUA.Focus()
                                End If

                            Else
                                mod_MENSAJE.No_Se_Guardo_El_Registro_En_La_Base_De_Datos()
                            End If
                        End If
                    End If
                End If
            End If


        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub cmdCANCELAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSALIR.Click
        cboPEROUSUA.Focus()
        Me.Close()
    End Sub

#End Region

#Region "FORMULARIO"

#Region "Load"

    Private Sub frm_insertar_ZONAECON_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        pro_inicializarControles()
        pro_LimpiarCampos()
        cboPEROUSUA.Focus()
    End Sub

#End Region

#Region "KeyPress"

    Private Sub cboPEROUSUA_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboPEROUSUA.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            cboPEROROLE.Focus()
        End If
    End Sub
    Private Sub cboPEROROLE_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboPEROROLE.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            cboPEROESTA.Focus()
        End If
    End Sub
    Private Sub cboPEROESTA_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboPEROESTA.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            cmdGUARDAR.Focus()
        End If
    End Sub

#End Region

#Region "GotFocus"

    Private Sub cboPEROUSUA_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboPEROUSUA.GotFocus
        strBARRESTA.Items(0).Text = cboPEROUSUA.AccessibleDescription
    End Sub
    Private Sub cboPEROROLE_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboPEROROLE.GotFocus
        strBARRESTA.Items(0).Text = cboPEROROLE.AccessibleDescription
    End Sub
    Private Sub cboPEROESTA_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboPEROESTA.GotFocus
        strBARRESTA.Items(0).Text = cboPEROESTA.AccessibleDescription
    End Sub
    Private Sub cmdGUARDAR_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdGUARDAR.GotFocus
        strBARRESTA.Items(0).Text = cmdGUARDAR.AccessibleDescription
    End Sub
    Private Sub cmdCANCELAR_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdSALIR.GotFocus
        strBARRESTA.Items(0).Text = cmdSALIR.AccessibleDescription
    End Sub

#End Region

#Region "SelectedIndexChanged"

    Private Sub cboPEROUSUA_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboPEROUSUA.SelectedIndexChanged
        Me.lblPEROUSUA.Text = fun_BuscarNombrePorUsuario(Trim(Me.cboPEROUSUA.Text))
    End Sub
    Private Sub cboPEROROLE_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboPEROROLE.SelectedIndexChanged
        Me.lblPEROROLE.Text = fun_BuscarNombrePorUsuario(Trim(Me.cboPEROROLE.Text))

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