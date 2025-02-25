Imports REGLAS_DEL_NEGOCIO

Public Class frm_modificar_AREAACTI

    '====================================
    '*** MODIFICAR AREAS DE ACTIVIDAD ***
    '====================================

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

            Me.cboARACESTA.DataSource = objdatos.fun_Consultar_TODOS_LOS_ESTADOS
            Me.cboARACESTA.DisplayMember = "ESTADESC"
            Me.cboARACESTA.ValueMember = "ESTACODI"

            Dim objdatos1 As New cla_AREAACTI
            Dim tbl As New DataTable

            tbl = objdatos1.fun_Buscar_ID_MANT_AREAACTI(inID_REGISTRO)

            Me.txtARACCODI.Text = Trim(tbl.Rows(0).Item("ARACCODI"))
            Me.txtARACDESC.Text = Trim(tbl.Rows(0).Item("ARACDESC"))
            Me.cboARACESTA.SelectedValue = tbl.Rows(0).Item("ARACESTA")

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub

#End Region

#Region "MENU"

    Private Sub cmdGUARDAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGUARDAR.Click
        Try

            Dim objVerifica As New cla_Verificar_Dato

            Dim boARACCODI As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Numerico(Me.txtARACCODI)
            Dim boARACDESC As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.txtARACDESC)
            Dim boARACESTA As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboARACESTA)

            ' verifica los datos del formulario 
            If boARACCODI = True And _
               boARACDESC = True And _
               boARACESTA = True Then

                Dim objdatos As New cla_AREAACTI

                If objdatos.fun_Actualizar_MANT_AREAACTI(inID_REGISTRO, _
                                                         Me.txtARACCODI.Text, _
                                                         Me.txtARACDESC.Text, _
                                                         Me.cboARACESTA.SelectedValue) = True Then
                    Me.txtARACDESC.Focus()
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
        Me.txtARACDESC.Focus()
        Me.Close()
    End Sub

#End Region

#Region "FORMULARIO"

#Region "KeyDown"

    Private Sub cboARACESTA_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboARACESTA.KeyDown
        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
            fun_Cargar_ComboBox_Con_Datos_Activos_ESTADO(Me.cboARACESTA, Me.cboARACESTA.SelectedIndex)
        End If
    End Sub

#End Region

#Region "KeyPress"

    Private Sub txt_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtARACCODI.KeyPress, txtARACDESC.KeyPress, cboARACESTA.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Or e.KeyChar = Convert.ToChar(Keys.Tab) Then
            pp_pro_SaltarCampo()
        End If
    End Sub

#End Region

#Region "GotFocus"

    Private Sub txt_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtARACCODI.GotFocus, txtARACDESC.GotFocus
        pp_pro_SobrearCampo(sender)
        pp_pro_DescripcionCampo(Me.strBARRESTA.Items(0), sender)
    End Sub
    Private Sub cmd_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdGUARDAR.GotFocus, cmdSALIR.GotFocus
        pp_pro_DescripcionCampo(Me.strBARRESTA.Items(0), sender)
    End Sub
    Private Sub cbo_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboARACESTA.GotFocus
        pp_pro_DescripcionCampo(Me.strBARRESTA.Items(0), sender)
    End Sub

#End Region

#Region "Click"

    Private Sub cboMOLIESTA_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboARACESTA.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_ESTADO(cboARACESTA, cboARACESTA.SelectedIndex)
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