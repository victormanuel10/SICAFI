Imports REGLAS_DEL_NEGOCIO

Public Class frm_modificar_PERMETIQ

    '===========================
    '*** MODIFICAR ETIQUETAS ***
    '===========================

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

            cboPEETUSUA.DataSource = objdatos1.fun_Consultar_CAMPOS_CONTRASENA
            cboPEETUSUA.DisplayMember = "CONTUSUA"
            cboPEETUSUA.ValueMember = "CONTUSUA"

            Dim objdatos2 As New cla_PERMETIQ

            cboPEETETIQ.DataSource = objdatos2.fun_Consultar_CAMPOS_PERMETIQ
            cboPEETETIQ.DisplayMember = "PEETETIQ"
            cboPEETETIQ.ValueMember = "PEETETIQ"

            Dim objdatos3 As New cla_PERMETIQ
            Dim tbl As New DataTable

            tbl = objdatos3.fun_Buscar_ID_PERMETIQ(id)

            stUsuario = tbl.Rows(0).Item(1)
            Me.cboPEETUSUA.SelectedValue = stUsuario

            'Me.cboPEFOUSUA.SelectedValue = tbl.Rows(0).Item(1)
            Me.cboPEETETIQ.SelectedValue = tbl.Rows(0).Item(2)
            Me.txtPEETDESC.Text = Trim(tbl.Rows(0).Item(3))
            Me.cboPEFOESTA.SelectedValue = tbl.Rows(0).Item(4)

            stUsuario = Trim(tbl.Rows(0).Item(1))

            '=====================
            ' CARGA LA DESCRIPCIÓN 
            '=====================

            Dim boPEFOFORM As Boolean = fun_Buscar_Dato_ETIQUETA(cboPEETETIQ.SelectedValue)

            If boPEFOFORM = True Then
                pro_ConsultarNombrePorUsuario()
                lblPEETETIQ.Text = CType(fun_Buscar_Lista_Valores_ETIQUETAS(cboPEETETIQ.SelectedValue), String)
            Else
                frm_INCO_modifircar_registros_sin_listas_de_valores.ShowDialog()

            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

        Me.txtPEETDESC.Focus()

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

            lblPEETUSUA.Text = nombre & " " & PrApellido & " " & SeApellido

        Catch ex As Exception
            MessageBox.Show(Err.Description & "lista de valores")
        End Try

    End Sub
    Private Sub pro_LimpiarCampos()

        Me.txtPEETDESC.Text = ""
        strBARRESTA.Items(1).Text = ""

    End Sub

#End Region

#Region "MENU"

    Private Sub cmdGUARDAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGUARDAR.Click
        Try
            If fun_Verificar_Campos_Llenos_4_DATOS(Me.cboPEETUSUA.Text, Me.cboPEETETIQ.Text, Me.txtPEETDESC.Text, Me.cboPEFOESTA.Text) = False Then
                mod_MENSAJE.Existen_Campos_Sin_Diligenciar()
                Me.txtPEETDESC.Focus()
            Else
                Dim objdatos As New cla_PERMETIQ

                If (objdatos.fun_Actualizar_PERMETIQ(id, Me.cboPEETUSUA.SelectedValue, Me.cboPEETETIQ.SelectedValue, Me.txtPEETDESC.Text, Me.cboPEFOESTA.SelectedValue)) Then
                    mod_MENSAJE.Se_Modificaron_Los_Datos_Correctamente()
                    Me.txtPEETDESC.Focus()
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
        Me.txtPEETDESC.Focus()
        Me.Close()

    End Sub

#End Region

#Region "FORMULARIO"

#Region "KeyPress"

    Private Sub cboPEFOUSUA_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboPEETUSUA.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            cboPEETETIQ.Focus()
        End If
    End Sub
    Private Sub cboPEETETIQ_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboPEETETIQ.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            txtPEETDESC.Focus()
        End If
    End Sub
    Private Sub txtPEETDESC_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtPEETDESC.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            cboPEFOESTA.Focus()
        End If
    End Sub
    Private Sub cboPEFOESTA_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboPEFOESTA.KeyPress
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
    Private Sub txtPEFODESC_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtPEETDESC.GotFocus
        strBARRESTA.Items(0).Text = txtPEETDESC.AccessibleDescription
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

    Private Sub cboPEFOUSUA_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboPEETUSUA.SelectedIndexChanged
        Me.lblPEETUSUA.Text = CType(fun_BuscarNombrePorUsuario(Trim(Me.cboPEETUSUA.Text)), String)
    End Sub
    Private Sub cboPEFOFORM_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboPEETETIQ.SelectedIndexChanged
        Me.lblPEETETIQ.Text = CType(fun_Buscar_Lista_Valores_ETIQUETAS(Trim(Me.cboPEETETIQ.Text)), String)
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