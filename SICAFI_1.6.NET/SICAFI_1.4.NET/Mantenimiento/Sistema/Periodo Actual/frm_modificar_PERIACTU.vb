Imports REGLAS_DEL_NEGOCIO

Public Class frm_modificar_PERIACTU

    '================================
    '*** MODIFICAR PERIODO ACTUAL ***
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

        Me.cboPEACESTA.DataSource = objdatos.fun_Consultar_TODOS_LOS_ESTADOS
        Me.cboPEACESTA.DisplayMember = "ESTADESC"
        Me.cboPEACESTA.ValueMember = "ESTACODI"

        Dim objdatos1 As New cla_PERIACTU
        Dim tbl As New DataTable

        tbl = objdatos1.fun_Buscar_ID_MANT_PERIACTU(inID_REGISTRO)

        Me.txtPEACCODI.Text = Trim(tbl.Rows(0).Item(1))
        Me.txtPEACDESC.Text = Trim(tbl.Rows(0).Item(2))
        Me.chkPEACPEAC.Checked = tbl.Rows(0).Item(3)
        Me.cboPEACESTA.SelectedValue = tbl.Rows(0).Item(4)

    End Sub

#End Region

#Region "MENU"

    Private Sub cmdGUARDAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGUARDAR.Click

        Try
            ' instancia la clase
            Dim objVerifica As New cla_Verificar_Dato

            Dim boPEACCODI As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Numerico(Me.txtPEACCODI)
            Dim boPEACDESC As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.txtPEACDESC)
            Dim boPEACESTA As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboPEACESTA)

            ' verifica los datos del formulario 
            If boPEACCODI = True And boPEACDESC = True And boPEACESTA = True Then

                Dim objdatos22 As New cla_PERIACTU

                If (objdatos22.fun_Actualizar_MANT_PERIACTU(inID_REGISTRO, Me.txtPEACCODI.Text, Me.txtPEACDESC.Text, Me.chkPEACPEAC.Checked, Me.cboPEACESTA.SelectedValue)) Then
                    mod_MENSAJE.Se_Guardaron_Los_Datos_Correctamente()
                    Me.txtPEACCODI.Focus()
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
        Me.txtPEACCODI.Focus()
        Me.Close()
    End Sub

#End Region

#Region "FORMULARIO"

#Region "KeyPress"

    Private Sub txt_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtPEACCODI.KeyPress, txtPEACDESC.KeyPress, cboPEACESTA.KeyPress, chkPEACPEAC.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Or e.KeyChar = Convert.ToChar(Keys.Tab) Then
            pp_pro_SaltarCampo()
        End If
    End Sub

#End Region

#Region "KeyDown"

    Private Sub cboTIAFESTA_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboPEACESTA.KeyDown
        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
            fun_Cargar_ComboBox_Con_Datos_Activos_ESTADO(Me.cboPEACESTA, Me.cboPEACESTA.SelectedIndex)
        End If
    End Sub

#End Region

#Region "GotFocus"

    Private Sub txt_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtPEACCODI.GotFocus, txtPEACDESC.GotFocus
        pp_pro_SobrearCampo(sender)
        pp_pro_DescripcionCampo(Me.strBARRESTA.Items(0), sender)
    End Sub
    Private Sub cmd_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdGUARDAR.GotFocus, cmdSALIR.GotFocus
        pp_pro_DescripcionCampo(Me.strBARRESTA.Items(0), sender)
    End Sub
    Private Sub cbo_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboPEACESTA.GotFocus
        pp_pro_DescripcionCampo(Me.strBARRESTA.Items(0), sender)
    End Sub
    Private Sub chk_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkPEACPEAC.GotFocus
        pp_pro_DescripcionCampo(Me.strBARRESTA.Items(0), sender)
    End Sub


#End Region

#Region "Click"

    Private Sub cboMOLIESTA_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboPEACESTA.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_ESTADO(cboPEACESTA, cboPEACESTA.SelectedIndex)
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