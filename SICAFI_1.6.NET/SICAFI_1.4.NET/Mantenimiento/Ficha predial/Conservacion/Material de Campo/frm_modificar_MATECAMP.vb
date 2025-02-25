Imports REGLAS_DEL_NEGOCIO

Public Class frm_modificar_MATECAMP

    '===================================
    '*** MODIFICAR MATERIAL DE CAMPO ***
    '===================================

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

        Me.cboMACAESTA.DataSource = objdatos.fun_Consultar_TODOS_LOS_ESTADOS
        Me.cboMACAESTA.DisplayMember = "ESTADESC"
        Me.cboMACAESTA.ValueMember = "ESTACODI"

        Dim objdatos1 As New cla_MATECAMP
        Dim tbl As New DataTable

        tbl = objdatos1.fun_Buscar_ID_MANT_MATECAMP(inID_REGISTRO)

        Me.txtMACACODI.Text = Trim(tbl.Rows(0).Item("MACACODI"))
        Me.txtMACADESC.Text = Trim(tbl.Rows(0).Item("MACADESC"))
        Me.cboMACAESTA.SelectedValue = tbl.Rows(0).Item("MACAESTA")


    End Sub

#End Region

#Region "MENU"

    Private Sub cmdGUARDAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGUARDAR.Click

        Try
            Dim objVerifica As New cla_Verificar_Dato

            Dim boMACACODI As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Numerico(Me.txtMACACODI)
            Dim boMACADESC As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.txtMACADESC)
            Dim boMACAESTA As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboMACAESTA)

            ' verifica los datos del formulario 
            If boMACACODI = True And boMACADESC = True And boMACAESTA = True Then

                Dim objdatos22 As New cla_MATECAMP

                If (objdatos22.fun_Actualizar_MANT_MATECAMP(inID_REGISTRO, Me.txtMACACODI.Text, Me.txtMACADESC.Text, Me.cboMACAESTA.SelectedValue)) Then
                    mod_MENSAJE.Se_Guardaron_Los_Datos_Correctamente()
                    Me.txtMACACODI.Focus()
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
        Me.txtMACACODI.Focus()
        Me.Close()
    End Sub

#End Region

#Region "FORMULARIO"

#Region "KeyDown"

    Private Sub cboMACAESTA_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboMACAESTA.KeyDown
        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
            fun_Cargar_ComboBox_Con_Datos_Activos_ESTADO(Me.cboMACAESTA, Me.cboMACAESTA.SelectedIndex)
        End If
    End Sub

#End Region

#Region "KeyPress"

    Private Sub txt_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtMACACODI.KeyPress, txtMACADESC.KeyPress, cboMACAESTA.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Or e.KeyChar = Convert.ToChar(Keys.Tab) Then
            pp_pro_SaltarCampo()
        End If
    End Sub

#End Region

#Region "GotFocus"

    Private Sub txt_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtMACACODI.GotFocus, txtMACADESC.GotFocus
        pp_pro_SobrearCampo(sender)
        pp_pro_DescripcionCampo(Me.strBARRESTA.Items(0), sender)
    End Sub
    Private Sub cmd_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdGUARDAR.GotFocus, cmdSALIR.GotFocus
        pp_pro_DescripcionCampo(Me.strBARRESTA.Items(0), sender)
    End Sub
    Private Sub cbo_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboMACAESTA.GotFocus
        pp_pro_DescripcionCampo(Me.strBARRESTA.Items(0), sender)
    End Sub


#End Region

#Region "Click"

    Private Sub cboMOLIESTA_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboMACAESTA.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_ESTADO(cboMACAESTA, cboMACAESTA.SelectedIndex)
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