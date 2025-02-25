Imports REGLAS_DEL_NEGOCIO

Public Class frm_modificar_PERMROLE

    '===============================
    '*** MODIFICAR PERMISO ROLES ***
    '===============================

#Region "VARIABLES"

    Dim id As Integer = 0
    Dim inContador As Integer = 0
    Dim stUsuario As String = ""

#End Region

#Region "CONSTRUCTOR"

    Public Sub New(ByVal idPersona As Integer)
        id = idPersona
        InitializeComponent()
        pro_inicializarControles()

    End Sub

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

            Dim objdatos2 As New cla_PERMROLE

            cboPEROROLE.DataSource = objdatos2.fun_Consultar_CAMPOS_PERMROLE
            cboPEROROLE.DisplayMember = "PEROROLE"
            cboPEROROLE.ValueMember = "PEROROLE"

            Dim objdatos3 As New cla_PERMROLE
            Dim tbl As New DataTable

            tbl = objdatos3.fun_Buscar_ID_PERMROLE(id)

            stUsuario = tbl.Rows(0).Item(1)
            Me.cboPEROUSUA.SelectedValue = stUsuario

            'Me.cboPEROUSUA.SelectedValue = tbl.Rows(0).Item(1)
            Me.cboPEROROLE.SelectedValue = tbl.Rows(0).Item(2)
            Me.cboPEROESTA.SelectedValue = tbl.Rows(0).Item(3)

            stUsuario = Trim(tbl.Rows(0).Item(1))

            '=====================
            ' CARGA LA DESCRIPCIÓN 
            '=====================

            Me.lblPEROUSUA.Text = CType(fun_BuscarNombrePorUsuario(Trim(Me.cboPEROUSUA.SelectedValue)), String)
            Me.lblPEROROLE.Text = CType(fun_BuscarNombrePorUsuario(Trim(Me.cboPEROROLE.SelectedValue)), String)


        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

        Me.cboPEROROLE.Focus()

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
                Me.cboPEROROLE.Focus()
            Else
                ' verifica si ya existe el permiso para el usuario
                Dim objdatos22 As New cla_PERMROLE
                Dim tbl22 As New DataTable

                tbl22 = objdatos22.fun_Buscar_CODIGO_PERMROLE(Trim(Me.cboPEROUSUA.Text), Trim(Me.cboPEROROLE.Text))

                If tbl22.Rows.Count > 0 Then
                    MessageBox.Show("Roles ya existe registrado para este usuario", "Mensaje ...", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1)
                Else
                    ' verifica que el roles asignado no se asigne asi mismo
                    If Trim(Me.cboPEROUSUA.SelectedValue) = Trim(Me.cboPEROROLE.SelectedValue) Then
                        MessageBox.Show("Asignación de roles incorrecta", "Mensaje...", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1)
                        cboPEROROLE.Focus()
                    Else
                        Dim objdatos As New cla_PERMROLE

                        If (objdatos.fun_Actualizar_PERMROLE(id, Me.cboPEROUSUA.SelectedValue, Me.cboPEROROLE.SelectedValue, Me.cboPEROESTA.SelectedValue)) Then
                            mod_MENSAJE.Se_Modificaron_Los_Datos_Correctamente()
                            Me.cboPEROROLE.Focus()
                            Me.Close()
                        Else
                            mod_MENSAJE.No_Se_Modifico_El_Registro_En_La_Base_De_Datos()
                        End If

                    End If

                End If
            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description & "Modificar")
        End Try

    End Sub
    Private Sub cmdCANCELAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSALIR.Click
        Me.cboPEROROLE.Focus()
        Me.Close()

    End Sub

#End Region

#Region "FORMULARIO"

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
    Private Sub cboZOECESTA_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboPEROESTA.KeyPress
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