Imports REGLAS_DEL_NEGOCIO

Public Class frm_modificar_UBICVIVI

    '=======================================
    '*** MODIFICAR UBICACION DE VIVIENDA ***
    '=======================================

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

        Me.cboUBVIESTA.DataSource = objdatos.fun_Consultar_TODOS_LOS_ESTADOS
        Me.cboUBVIESTA.DisplayMember = "ESTADESC"
        Me.cboUBVIESTA.ValueMember = "ESTACODI"

        Dim objdatos1 As New cla_UBICVIVI
        Dim tbl As New DataTable

        tbl = objdatos1.fun_Buscar_ID_MANT_UBICVIVI(inID_REGISTRO)

        If tbl.Rows.Count > 0 Then

            Me.txtUBVICODI.Text = Trim(tbl.Rows(0).Item("UBVICODI"))
            Me.txtUBVIDESC.Text = Trim(tbl.Rows(0).Item("UBVIDESC"))
            Me.cboUBVIESTA.SelectedValue = tbl.Rows(0).Item("UBVIESTA")

        End If

    End Sub
    Private Sub pro_LimpiarCampos()

        pp_pro_LimpiarCampos(fraUBICVIVI)

    End Sub

#End Region

#Region "MENU"

    Private Sub cmdGUARDAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGUARDAR.Click
        Try

            Dim objVerifica As New cla_Verificar_Dato

            Dim boUBVICODI As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Numerico(Me.txtUBVICODI)
            Dim boUBVIDESC As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.txtUBVIDESC)
            Dim boUBVIESTA As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboUBVIESTA)

            ' verifica los datos del formulario 
            If boUBVICODI = True And boUBVIDESC = True And boUBVIESTA = True Then

                Dim objdatos As New cla_UBICVIVI

                If objdatos.fun_Actualizar_MANT_UBICVIVI(inID_REGISTRO, Me.txtUBVICODI.Text, Me.txtUBVIDESC.Text, Me.cboUBVIESTA.SelectedValue) = True Then

                    mod_MENSAJE.Se_Modificaron_Los_Datos_Correctamente()

                    Me.txtUBVIDESC.Focus()
                    Me.Close()
                Else
                    mod_MENSAJE.No_Se_Modifico_El_Registro_En_La_Base_De_Datos()
                End If
            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub cmdCANCELAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSALIR.Click
        Me.txtUBVIDESC.Focus()
        Me.Close()
    End Sub

#End Region

#Region "FORMULARIO"

#Region "KeyPress"

    Private Sub txt_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtUBVICODI.KeyPress, txtUBVIDESC.KeyPress, cboUBVIESTA.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Or e.KeyChar = Convert.ToChar(Keys.Tab) Then
            pp_pro_SaltarCampo()
        End If
    End Sub

#End Region

#Region "KeyDown"

    Private Sub cboUBVIESTA_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboUBVIESTA.KeyDown
        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
            fun_Cargar_ComboBox_Con_Datos_Activos_ESTADO(Me.cboUBVIESTA, Me.cboUBVIESTA.SelectedIndex)
        End If
    End Sub

#End Region

#Region "GotFocus"

    Private Sub txt_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtUBVICODI.GotFocus, txtUBVIDESC.GotFocus
        pp_pro_SobrearCampo(sender)
        pp_pro_DescripcionCampo(Me.strBARRESTA.Items(0), sender)
    End Sub
    Private Sub cmd_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdGUARDAR.GotFocus, cmdSALIR.GotFocus
        pp_pro_DescripcionCampo(Me.strBARRESTA.Items(0), sender)
    End Sub
    Private Sub cbo_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboUBVIESTA.GotFocus
        pp_pro_DescripcionCampo(Me.strBARRESTA.Items(0), sender)
    End Sub

#End Region

#Region "Click"

    Private Sub cboMOLIESTA_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboUBVIESTA.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_ESTADO(cboUBVIESTA, cboUBVIESTA.SelectedIndex)
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