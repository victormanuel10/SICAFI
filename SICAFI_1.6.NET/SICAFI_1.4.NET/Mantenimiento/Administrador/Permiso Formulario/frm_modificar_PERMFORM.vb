Imports REGLAS_DEL_NEGOCIO

Public Class frm_modificar_PERMFORM

    '============================
    '*** MODIFICAR FORMULARIO ***
    '============================

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

            cboPEFOESTA.DataSource = objdatos.fun_Consultar_ESTADO_X_ESTADO
            cboPEFOESTA.DisplayMember = "ESTADESC"
            cboPEFOESTA.ValueMember = "ESTACODI"

            Dim objdatos1 As New cla_CONTRASENA

            cboPEFOUSUA.DataSource = objdatos1.fun_Consultar_CAMPOS_CONTRASENA
            cboPEFOUSUA.DisplayMember = "CONTUSUA"
            cboPEFOUSUA.ValueMember = "CONTUSUA"

            Dim objdatos2 As New cla_PERMFORM

            cboPEFOFORM.DataSource = objdatos2.fun_Consultar_CAMPOS_PERMFORM
            cboPEFOFORM.DisplayMember = "PEFOFORM"
            cboPEFOFORM.ValueMember = "PEFOFORM"

            Dim objdatos3 As New cla_PERMFORM
            Dim tbl As New DataTable

            tbl = objdatos3.fun_Buscar_ID_PERMFORM(id)

            stUsuario = tbl.Rows(0).Item(1)
            Me.cboPEFOUSUA.SelectedValue = stUsuario

            'Me.cboPEFOUSUA.SelectedValue = tbl.Rows(0).Item(1)
            Me.cboPEFOFORM.SelectedValue = tbl.Rows(0).Item(2)
            Me.txtPEFODESC.Text = Trim(tbl.Rows(0).Item(3))
            Me.chkPEFOAGRE.Checked = tbl.Rows(0).Item(4)
            Me.chkPEFOMODI.Checked = tbl.Rows(0).Item(5)
            Me.chkPEFOELIM.Checked = tbl.Rows(0).Item(6)
            Me.cboPEFOESTA.SelectedValue = tbl.Rows(0).Item(7)

            stUsuario = Trim(tbl.Rows(0).Item(1))

            '=====================
            ' CARGA LA DESCRIPCIÓN 
            '=====================

            Dim boPEFOFORM As Boolean = fun_Buscar_Dato_PERMFORM(cboPEFOFORM.SelectedValue)

            If boPEFOFORM = True Then
                pro_ConsultarNombrePorUsuario()
                lblPEFOFORM.Text = CType(fun_Buscar_Lista_Valores_FORMULARIO(cboPEFOFORM.SelectedValue), String)
            Else
                frm_INCO_modifircar_registros_sin_listas_de_valores.ShowDialog()

            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

        Me.txtPEFODESC.Focus()

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

            lblPEFOUSUA.Text = nombre & " " & PrApellido & " " & SeApellido

        Catch ex As Exception
            MessageBox.Show(Err.Description & "lista de valores")
        End Try

    End Sub
    Private Sub pro_LimpiarCampos()

        Me.txtPEFODESC.Text = ""
        Me.chkPEFOAGRE.Checked = False
        Me.chkPEFOMODI.Checked = False
        Me.chkPEFOELIM.Checked = False
        strBARRESTA.Items(1).Text = ""

    End Sub

#End Region

#Region "MENU"

    Private Sub cmdGUARDAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGUARDAR.Click
        Try
            If fun_Verificar_Campos_Llenos_4_DATOS(Me.cboPEFOUSUA.Text, Me.cboPEFOFORM.Text, Me.txtPEFODESC.Text, Me.cboPEFOESTA.Text) = False Then
                mod_MENSAJE.Existen_Campos_Sin_Diligenciar()
                Me.txtPEFODESC.Focus()
            Else
                Dim objdatos As New cla_PERMFORM

                If (objdatos.fun_Actualizar_PERMFORM(id, Me.cboPEFOUSUA.SelectedValue, Me.cboPEFOFORM.SelectedValue, Me.txtPEFODESC.Text, Me.chkPEFOAGRE.Checked, Me.chkPEFOMODI.Checked, Me.chkPEFOELIM.Checked, Me.cboPEFOESTA.SelectedValue)) Then
                    mod_MENSAJE.Se_Modificaron_Los_Datos_Correctamente()
                    Me.txtPEFODESC.Focus()
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
        Me.txtPEFODESC.Focus()
        Me.Close()

    End Sub

#End Region

#Region "FORMULARIO"

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
    Private Sub txtPEFODESC_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtPEFODESC.KeyPress
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
    Private Sub txtPEFODESC_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtPEFODESC.GotFocus
        strBARRESTA.Items(0).Text = txtPEFODESC.AccessibleDescription
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