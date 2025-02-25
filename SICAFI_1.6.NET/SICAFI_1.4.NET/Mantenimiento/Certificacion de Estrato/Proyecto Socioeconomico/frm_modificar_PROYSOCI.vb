Imports REGLAS_DEL_NEGOCIO

Public Class frm_modificar_PROYSOCI

    '=========================================
    '*** MODIFICAR PROYECTO SOCIOECONOMICO ***
    '=========================================

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

        Me.cboPRSOESTA.DataSource = objdatos.fun_Consultar_TODOS_LOS_ESTADOS
        Me.cboPRSOESTA.DisplayMember = "ESTADESC"
        Me.cboPRSOESTA.ValueMember = "ESTACODI"

        Dim objdatos1 As New cla_PROYSOCI
        Dim tbl As New DataTable

        tbl = objdatos1.fun_Buscar_ID_MANT_PROYSOCI(inID_REGISTRO)

        If tbl.Rows.Count > 0 Then

            Me.txtPRSOCODI.Text = Trim(tbl.Rows(0).Item("PRSOCODI"))
            Me.txtPRSODESC.Text = Trim(tbl.Rows(0).Item("PRSODESC"))
            Me.cboPRSOESTA.SelectedValue = tbl.Rows(0).Item("PRSOESTA")

        End If

    End Sub
    Private Sub pro_LimpiarCampos()

        pp_pro_LimpiarCampos(fraPROYSOCI)

    End Sub

#End Region

#Region "MENU"

    Private Sub cmdGUARDAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGUARDAR.Click
        Try

            Dim objVerifica As New cla_Verificar_Dato

            Dim boPRSOCODI As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Numerico(Me.txtPRSOCODI)
            Dim boPRSODESC As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.txtPRSODESC)
            Dim boPRSOESTA As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboPRSOESTA)

            ' verifica los datos del formulario 
            If boPRSOCODI = True And boPRSODESC = True And boPRSOESTA = True Then

                Dim objdatos As New cla_PROYSOCI

                If objdatos.fun_Actualizar_MANT_PROYSOCI(inID_REGISTRO, Me.txtPRSOCODI.Text, Me.txtPRSODESC.Text, Me.cboPRSOESTA.SelectedValue) = True Then

                    mod_MENSAJE.Se_Modificaron_Los_Datos_Correctamente()

                    Me.txtPRSODESC.Focus()
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
        Me.txtPRSODESC.Focus()
        Me.Close()
    End Sub

#End Region

#Region "FORMULARIO"

#Region "KeyPress"

    Private Sub txt_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtPRSOCODI.KeyPress, txtPRSODESC.KeyPress, cboPRSOESTA.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Or e.KeyChar = Convert.ToChar(Keys.Tab) Then
            pp_pro_SaltarCampo()
        End If
    End Sub

#End Region

#Region "KeyDown"

    Private Sub cboPRSOESTA_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboPRSOESTA.KeyDown
        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
            fun_Cargar_ComboBox_Con_Datos_Activos_ESTADO(Me.cboPRSOESTA, Me.cboPRSOESTA.SelectedIndex)
        End If
    End Sub

#End Region

#Region "GotFocus"

    Private Sub txt_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtPRSOCODI.GotFocus, txtPRSODESC.GotFocus
        pp_pro_SobrearCampo(sender)
        pp_pro_DescripcionCampo(Me.strBARRESTA.Items(0), sender)
    End Sub
    Private Sub cmd_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdGUARDAR.GotFocus, cmdSALIR.GotFocus
        pp_pro_DescripcionCampo(Me.strBARRESTA.Items(0), sender)
    End Sub
    Private Sub cbo_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboPRSOESTA.GotFocus
        pp_pro_DescripcionCampo(Me.strBARRESTA.Items(0), sender)
    End Sub

#End Region

#Region "Click"

    Private Sub cboMOLIESTA_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboPRSOESTA.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_ESTADO(cboPRSOESTA, cboPRSOESTA.SelectedIndex)
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