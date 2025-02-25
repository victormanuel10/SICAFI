Imports REGLAS_DEL_NEGOCIO

Public Class frm_modificar_CONCEPTO

    '==========================
    '*** MODIFICAR CONCEPTO ***
    '==========================

#Region "VARIABLE"

    Dim inID_REGISTRO As Integer

#End Region

#Region "CONSTRUCTOR"

    Public Sub New(ByVal inInRegistro As Integer)
        inID_REGISTRO = inInRegistro

        InitializeComponent()
        pro_inicializarControles()
    End Sub

#End Region

#Region "PROCEDIMIENTOS"

    Private Sub pro_inicializarControles()

        Try
            Dim objdatos28 As New cla_TIPOIMPU

            Me.cboCONCTIIM.DataSource = objdatos28.fun_Consultar_CAMPOS_MANT_TIPOIMPU
            Me.cboCONCTIIM.DisplayMember = "TIIMDESC"
            Me.cboCONCTIIM.ValueMember = "TIIMCODI"

            Dim objdatos As New cla_ESTADO

            Me.cboCONCESTA.DataSource = objdatos.fun_Consultar_TODOS_LOS_ESTADOS
            Me.cboCONCESTA.DisplayMember = "ESTADESC"
            Me.cboCONCESTA.ValueMember = "ESTACODI"

            Dim objdatos1 As New cla_CONCEPTO
            Dim tbl As New DataTable

            tbl = objdatos1.fun_Buscar_ID_MANT_CONCEPTO(inID_REGISTRO)

            Me.cboCONCTIIM.SelectedValue = Trim(tbl.Rows(0).Item("CONCTIIM"))
            Me.txtCONCCODI.Text = Trim(tbl.Rows(0).Item("CONCCODI"))
            Me.txtCONCDESC.Text = Trim(tbl.Rows(0).Item("CONCDESC"))
            Me.cboCONCESTA.SelectedValue = tbl.Rows(0).Item("CONCESTA")

            Dim boCONCTIIM As Boolean = fun_Buscar_Dato_TIPOIMPU(Trim(Me.cboCONCTIIM.SelectedValue))

            If boCONCTIIM = True Then

                Me.lblCONCTIIM.Text = fun_Buscar_Lista_Valores_TIPOIMPU_Codigo(Me.cboCONCTIIM)
            Else
                frm_INCO_modifircar_registros_sin_listas_de_valores.ShowDialog()
            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub

#End Region

#Region "MENU"

    Private Sub cmdGUARDAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGUARDAR.Click
        Try

            Dim objVerifica As New cla_Verificar_Dato

            Dim boCONCTIIM As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboCONCTIIM)
            Dim boCONCCODI As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Numerico(Me.txtCONCCODI)
            Dim boCONCDESC As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.txtCONCDESC)
            Dim boCONCESTA As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboCONCESTA)

            ' verifica los datos del formulario 
            If boCONCTIIM = True And boCONCCODI = True And boCONCDESC = True And boCONCESTA = True Then

                Dim objdatos As New cla_CONCEPTO

                If objdatos.fun_Actualizar_MANT_CONCEPTO(inID_REGISTRO, _
                                                         Me.cboCONCTIIM.SelectedValue, _
                                                         Me.txtCONCCODI.Text, _
                                                         Me.txtCONCDESC.Text, _
                                                         Me.cboCONCESTA.SelectedValue) = True Then
                    Me.txtCONCDESC.Focus()
                    Me.Close()

                    mod_MENSAJE.Se_Modificaron_Los_Datos_Correctamente()
                Else
                    mod_MENSAJE.No_Se_Modifico_El_Registro_En_La_Base_De_Datos()
                End If
            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub cmdCANCELAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSALIR.Click
        Me.txtCONCDESC.Focus()
        Me.Close()
    End Sub

#End Region

#Region "FORMULARIO"

#Region "KeyDown"

    Private Sub cboCONCTIIM_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboCONCTIIM.KeyDown
        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
            fun_Cargar_ComboBox_Con_Datos_Activos_TIPOIMPU_Descripcion(Me.cboCONCTIIM, Me.cboCONCTIIM.SelectedIndex)
        End If
    End Sub
    Private Sub cboCONCESTA_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboCONCESTA.KeyDown
        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
            fun_Cargar_ComboBox_Con_Datos_Activos_ESTADO(Me.cboCONCESTA, Me.cboCONCESTA.SelectedIndex)
        End If
    End Sub

#End Region

#Region "KeyPress"

    Private Sub txt_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCONCCODI.KeyPress, txtCONCDESC.KeyPress, cboCONCESTA.KeyPress, cboCONCTIIM.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Or e.KeyChar = Convert.ToChar(Keys.Tab) Then
            pp_pro_SaltarCampo()
        End If
    End Sub

#End Region

#Region "GotFocus"

    Private Sub txt_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCONCCODI.GotFocus, txtCONCDESC.GotFocus
        pp_pro_SobrearCampo(sender)
        pp_pro_DescripcionCampo(Me.strBARRESTA.Items(0), sender)
    End Sub
    Private Sub cmd_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdGUARDAR.GotFocus, cmdSALIR.GotFocus
        pp_pro_DescripcionCampo(Me.strBARRESTA.Items(0), sender)
    End Sub
    Private Sub cbo_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboCONCESTA.GotFocus, cboCONCTIIM.GotFocus
        pp_pro_DescripcionCampo(Me.strBARRESTA.Items(0), sender)
    End Sub

#End Region

#Region "Click"

    Private Sub cboCONCTIIM_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboCONCTIIM.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_TIPOIMPU_Descripcion(Me.cboCONCTIIM, Me.cboCONCTIIM.SelectedIndex)
    End Sub
    Private Sub cboMOLIESTA_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboCONCESTA.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_ESTADO(cboCONCESTA, cboCONCESTA.SelectedIndex)
    End Sub

#End Region

#Region "SelectedIndexChanged"

    Private Sub cboCONCTIIM_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCONCTIIM.SelectedIndexChanged
        Me.lblCONCTIIM.Text = CType(fun_Buscar_Lista_Valores_TIPOIMPU_Codigo(Me.cboCONCTIIM), String)
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