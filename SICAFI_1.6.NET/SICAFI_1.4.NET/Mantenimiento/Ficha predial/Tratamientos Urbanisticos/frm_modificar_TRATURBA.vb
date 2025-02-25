Imports REGLAS_DEL_NEGOCIO

Public Class frm_modificar_TRATURBA

    '===========================================
    '*** MODIFICAR TRATAMIENTOS URBANISTICOS ***
    '===========================================

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
            Dim objdatos As New cla_ESTADO

            Me.cboTRURESTA.DataSource = objdatos.fun_Consultar_TODOS_LOS_ESTADOS
            Me.cboTRURESTA.DisplayMember = "ESTADESC"
            Me.cboTRURESTA.ValueMember = "ESTACODI"

            Dim objdatos1 As New cla_TRATURBA
            Dim tbl As New DataTable

            tbl = objdatos1.fun_Buscar_ID_MANT_TRATURBA(inID_REGISTRO)

            Me.txtTRURCODI.Text = Trim(tbl.Rows(0).Item("TRURCODI"))
            Me.txtTRURDESC.Text = Trim(tbl.Rows(0).Item("TRURDESC"))
            Me.cboTRURESTA.SelectedValue = tbl.Rows(0).Item("TRURESTA")

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub

#End Region

#Region "MENU"

    Private Sub cmdGUARDAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGUARDAR.Click
        Try

            Dim objVerifica As New cla_Verificar_Dato

            Dim boTRURCODI As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Numerico(Me.txtTRURCODI)
            Dim boTRURDESC As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.txtTRURDESC)
            Dim boTRURESTA As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboTRURESTA)

            ' verifica los datos del formulario 
            If boTRURCODI = True And _
               boTRURDESC = True And _
               boTRURESTA = True Then

                Dim objdatos As New cla_TRATURBA

                If objdatos.fun_Actualizar_MANT_TRATURBA(inID_REGISTRO, _
                                                         Me.txtTRURCODI.Text, _
                                                         Me.txtTRURDESC.Text, _
                                                         Me.cboTRURESTA.SelectedValue) = True Then
                    Me.txtTRURDESC.Focus()
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
        Me.txtTRURDESC.Focus()
        Me.Close()
    End Sub

#End Region

#Region "FORMULARIO"

#Region "KeyDown"

    Private Sub cboTRURESTA_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboTRURESTA.KeyDown
        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
            fun_Cargar_ComboBox_Con_Datos_Activos_ESTADO(Me.cboTRURESTA, Me.cboTRURESTA.SelectedIndex)
        End If
    End Sub

#End Region

#Region "KeyPress"

    Private Sub txt_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtTRURCODI.KeyPress, txtTRURDESC.KeyPress, cboTRURESTA.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Or e.KeyChar = Convert.ToChar(Keys.Tab) Then
            pp_pro_SaltarCampo()
        End If
    End Sub

#End Region

#Region "GotFocus"

    Private Sub txt_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtTRURCODI.GotFocus, txtTRURDESC.GotFocus
        pp_pro_SobrearCampo(sender)
        pp_pro_DescripcionCampo(Me.strBARRESTA.Items(0), sender)
    End Sub
    Private Sub cmd_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdGUARDAR.GotFocus, cmdSALIR.GotFocus
        pp_pro_DescripcionCampo(Me.strBARRESTA.Items(0), sender)
    End Sub
    Private Sub cbo_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboTRURESTA.GotFocus
        pp_pro_DescripcionCampo(Me.strBARRESTA.Items(0), sender)
    End Sub

#End Region

#Region "Click"

    Private Sub cboMOLIESTA_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboTRURESTA.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_ESTADO(cboTRURESTA, cboTRURESTA.SelectedIndex)
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