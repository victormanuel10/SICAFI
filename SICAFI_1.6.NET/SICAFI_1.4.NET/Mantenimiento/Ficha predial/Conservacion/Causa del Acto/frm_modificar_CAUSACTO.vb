Imports REGLAS_DEL_NEGOCIO

Public Class frm_modificar_CAUSACTO

    '================================
    '*** MODIFICAR CAUSA DEL ACTO ***
    '================================

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

        Dim objdatos As New cla_ESTADO

        Me.cboCAACESTA.DataSource = objdatos.fun_Consultar_TODOS_LOS_ESTADOS
        Me.cboCAACESTA.DisplayMember = "ESTADESC"
        Me.cboCAACESTA.ValueMember = "ESTACODI"

        Dim objdatos1 As New cla_CAUSACTO
        Dim tbl As New DataTable

        tbl = objdatos1.fun_Buscar_ID_MANT_CAUSACTO(inID_REGISTRO)

        Me.txtCAACCODI.Text = Trim(tbl.Rows(0).Item("CAACCODI"))
        Me.txtCAACDESC.Text = Trim(tbl.Rows(0).Item("CAACDESC"))
        Me.cboCAACESTA.SelectedValue = tbl.Rows(0).Item("CAACESTA")
        Me.chkCAACINPR.Checked = tbl.Rows(0).Item("CAACINPR")
        Me.chkCAACREPR.Checked = tbl.Rows(0).Item("CAACREPR")
        Me.chkCAACINCO.Checked = tbl.Rows(0).Item("CAACINCO")
        Me.chkCAACRECO.Checked = tbl.Rows(0).Item("CAACRECO")

    End Sub

#End Region

#Region "MENU"

    Private Sub cmdGUARDAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGUARDAR.Click

        Try
            Dim objVerifica As New cla_Verificar_Dato

            Dim boCAACCODI As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.txtCAACCODI)
            Dim boCAACDESC As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.txtCAACDESC)
            Dim boCAACESTA As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboCAACESTA)

            ' verifica los datos del formulario 
            If boCAACCODI = True And boCAACDESC = True And boCAACESTA = True Then

                Dim objdatos22 As New cla_CAUSACTO

                If (objdatos22.fun_Actualizar_MANT_CAUSACTO(inID_REGISTRO, _
                                                            Me.txtCAACCODI.Text, _
                                                            Me.txtCAACDESC.Text, _
                                                            Me.chkCAACINPR.Checked, _
                                                            Me.chkCAACREPR.Checked, _
                                                            Me.chkCAACINCO.Checked, _
                                                            Me.chkCAACRECO.Checked, _
                                                            Me.cboCAACESTA.SelectedValue)) = True Then

                    mod_MENSAJE.Se_Guardaron_Los_Datos_Correctamente()
                    Me.txtCAACCODI.Focus()
                    Me.Close()
                Else
                    mod_MENSAJE.No_Se_Guardo_El_Registro_En_La_Base_De_Datos()
                End If
            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description & "Guardar")
        End Try

    End Sub
    Private Sub cmdCANCELAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSALIR.Click
        Me.txtCAACCODI.Focus()
        Me.Close()
    End Sub

#End Region

#Region "FORMULARIO"

#Region "KeyDown"

    Private Sub cboCAACESTA_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboCAACESTA.KeyDown
        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
            fun_Cargar_ComboBox_Con_Datos_Activos_ESTADO(Me.cboCAACESTA, Me.cboCAACESTA.SelectedIndex)
        End If
    End Sub

#End Region

#Region "KeyPress"

    Private Sub txt_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCAACCODI.KeyPress, txtCAACDESC.KeyPress, cboCAACESTA.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Or e.KeyChar = Convert.ToChar(Keys.Tab) Then
            pp_pro_SaltarCampo()
        End If
    End Sub

#End Region

#Region "GotFocus"

    Private Sub txt_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCAACCODI.GotFocus, txtCAACDESC.GotFocus
        pp_pro_SobrearCampo(sender)
        pp_pro_DescripcionCampo(Me.strBARRESTA.Items(0), sender)
    End Sub
    Private Sub cmd_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdGUARDAR.GotFocus, cmdSALIR.GotFocus
        pp_pro_DescripcionCampo(Me.strBARRESTA.Items(0), sender)
    End Sub
    Private Sub cbo_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboCAACESTA.GotFocus
        pp_pro_DescripcionCampo(Me.strBARRESTA.Items(0), sender)
    End Sub


#End Region

#Region "Click"

    Private Sub cboMOLIESTA_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboCAACESTA.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_ESTADO(cboCAACESTA, cboCAACESTA.SelectedIndex)
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