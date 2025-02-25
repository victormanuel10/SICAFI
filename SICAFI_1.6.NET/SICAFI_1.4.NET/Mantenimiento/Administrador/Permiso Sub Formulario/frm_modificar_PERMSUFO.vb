Imports REGLAS_DEL_NEGOCIO

Public Class frm_modificar_PERMSUFO

    '===============================
    '*** MODIFICAR SUFFORMULARIO ***
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

        Try

            Dim objdatos As New cla_ESTADO

            cboPESFESTA.DataSource = objdatos.fun_Consultar_ESTADO_X_ESTADO
            cboPESFESTA.DisplayMember = "ESTADESC"
            cboPESFESTA.ValueMember = "ESTACODI"

            Dim objdatos1 As New cla_CONTRASENA

            cboPESFUSUA.DataSource = objdatos1.fun_Consultar_CAMPOS_CONTRASENA
            cboPESFUSUA.DisplayMember = "CONTUSUA"
            cboPESFUSUA.ValueMember = "CONTUSUA"

            Dim objdatos2 As New cla_PERMSUFO

            cboPESFFORM.DataSource = objdatos2.fun_Consultar_CAMPOS_PERMSUFO
            cboPESFFORM.DisplayMember = "PESFFORM"
            cboPESFFORM.ValueMember = "PESFFORM"

            Dim objdatos3 As New cla_PERMSUFO
            Dim tbl As New DataTable

            tbl = objdatos3.fun_Buscar_ID_PERMSUFO(id)

            stUsuario = tbl.Rows(0).Item(1)
            Me.cboPESFUSUA.SelectedValue = stUsuario

            'Me.cboPESFUSUA.SelectedValue = tbl.Rows(0).Item(1)
            Me.cboPESFFORM.SelectedValue = tbl.Rows(0).Item(2)
            Me.txtPESFDESC.Text = Trim(tbl.Rows(0).Item(3))
            Me.chkPESFAGRE.Checked = tbl.Rows(0).Item(4)
            Me.chkPESFMODI.Checked = tbl.Rows(0).Item(5)
            Me.chkPESFELIM.Checked = tbl.Rows(0).Item(6)
            Me.cboPESFESTA.SelectedValue = tbl.Rows(0).Item(7)

            stUsuario = Trim(tbl.Rows(0).Item(1))

            '=====================
            ' CARGA LA DESCRIPCIÓN 
            '=====================

            Dim boPESFFORM As Boolean = fun_Buscar_Dato_SUBFORMULARIO(cboPESFFORM.SelectedValue)

            If boPESFFORM = True Then
                pro_ConsultarNombrePorUsuario()
                lblPESFFORM.Text = CType(fun_Buscar_Lista_Valores_SUBFORMULARIO(cboPESFFORM.SelectedValue), String)
            Else
                frm_INCO_modifircar_registros_sin_listas_de_valores.ShowDialog()

            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

        Me.txtPESFDESC.Focus()

    End Sub
    Private Sub pro_ConsultarNombrePorUsuario()

        Try

            ' consulta el Nro. de documento por el usuario
            Dim objdatos11 As New cla_CONTRASENA
            Dim tbl11 As New DataTable

            tbl11 = objdatos11.fun_Buscar_USUARIO_CONTRASENA(Trim(stUsuario))

            ' declara la variable
            Dim stNroDocumento As String = ""

            ' carga la variable
            stNroDocumento = tbl11.Rows(0).Item("CONTNUDO").ToString

            ' consulta el nombre por Nro. de documento
            Dim objdatos22 As New cla_USUARIO
            Dim tbl As New DataTable

            Dim idNroDocumento As String = Trim(stNroDocumento)

            tbl = objdatos22.fun_Buscar_CODIGO_USUARIO(idNroDocumento)

            Dim nombre As String = Trim(tbl.Rows(0).Item("USUANOMB"))
            Dim PrApellido As String = Trim(tbl.Rows(0).Item("USUAPRAP"))
            Dim SeApellido As String = Trim(tbl.Rows(0).Item("USUASEAP"))

            lblPESFUSUA.Text = nombre & " " & PrApellido & " " & SeApellido

        Catch ex As Exception
            MessageBox.Show(Err.Description & "lista de valores")
        End Try

    End Sub
    Private Sub pro_LimpiarCampos()

        Me.txtPESFDESC.Text = ""
        Me.chkPESFAGRE.Checked = False
        Me.chkPESFMODI.Checked = False
        Me.chkPESFELIM.Checked = False
        strBARRESTA.Items(1).Text = ""

    End Sub

#End Region

#Region "MENU"

    Private Sub cmdGUARDAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGUARDAR.Click
        Try
            If fun_Verificar_Campos_Llenos_4_DATOS(Me.cboPESFUSUA.Text, Me.cboPESFFORM.Text, Me.txtPESFDESC.Text, Me.cboPESFESTA.Text) = False Then
                mod_MENSAJE.Existen_Campos_Sin_Diligenciar()
                Me.txtPESFDESC.Focus()
            Else
                Dim objdatos As New cla_PERMSUFO

                If (objdatos.fun_Actualizar_PERMSUFO(id, Me.cboPESFUSUA.SelectedValue, Me.cboPESFFORM.SelectedValue, Me.txtPESFDESC.Text, Me.chkPESFAGRE.Checked, Me.chkPESFMODI.Checked, Me.chkPESFELIM.Checked, Me.cboPESFESTA.SelectedValue)) Then
                    mod_MENSAJE.Se_Modificaron_Los_Datos_Correctamente()
                    Me.txtPESFDESC.Focus()
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
        Me.txtPESFDESC.Focus()
        Me.Close()

    End Sub

#End Region

#Region "FORMULARIO"

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
    Private Sub txtPESFDESC_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtPESFDESC.KeyPress
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
    Private Sub txtPESFDESC_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtPESFDESC.GotFocus
        strBARRESTA.Items(0).Text = txtPESFDESC.AccessibleDescription
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
        Me.lblPESFUSUA.Text = CType(fun_BuscarNombrePorUsuario(Trim(Me.cboPESFUSUA.Text)), String)
    End Sub
    Private Sub cboPESFFORM_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboPESFFORM.SelectedIndexChanged
        Me.lblPESFFORM.Text = CType(fun_Buscar_Lista_Valores_FORMULARIO(Trim(Me.cboPESFFORM.Text)), String)
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