Imports REGLAS_DEL_NEGOCIO

Public Class frm_modificar_CESIEQUI

    '========================================
    '*** MODIFICAR CESION ESPACIO PUBLICO ***
    '========================================

#Region "VARIABLE"

    Dim inID_REGISTRO As Integer

#End Region

#Region "CONSTRUCTOR"

    Public Sub New(ByVal inInRegistro As Integer)
        inID_REGISTRO = inInRegistro

        InitializeComponent()
        pro_LimpiarCampos()
        pro_inicializarControles()
    End Sub

#End Region

#Region "PROCEDIMIENTOS"

    Private Sub pro_inicializarControles()

        Dim objdatos As New cla_ESTADO

        Me.cboCEEQESTA.DataSource = objdatos.fun_Consultar_TODOS_LOS_ESTADOS
        Me.cboCEEQESTA.DisplayMember = "ESTADESC"
        Me.cboCEEQESTA.ValueMember = "ESTACODI"

        Dim obCESIESPU As New cla_CESIEQUI
        Dim tbCESIESPU As New DataTable

        tbCESIESPU = obCESIESPU.fun_Buscar_ID_MANT_CESIEQUI(inID_REGISTRO)

        If tbCESIESPU.Rows.Count > 0 Then

            Me.txtCEEQESSO.Text = Trim(tbCESIESPU.Rows(0).Item("CEEQESSO"))
            Me.txtCEEQDESC.Text = Trim(tbCESIESPU.Rows(0).Item("CEEQDESC"))
            Me.txtCEEQUNDE.Text = Trim(tbCESIESPU.Rows(0).Item("CEEQUNDE"))
            Me.txtCEEQEQSA.Text = Trim(tbCESIESPU.Rows(0).Item("CEEQEQSA"))
            Me.cboCEEQESTA.SelectedValue = tbCESIESPU.Rows(0).Item("CEEQESTA")

        End If

    End Sub
    Private Sub pro_LimpiarCampos()

        Me.txtCEEQESSO.Text = ""
        Me.txtCEEQDESC.Text = ""
        Me.txtCEEQUNDE.Text = ""
        Me.txtCEEQEQSA.Text = ""
        Me.cboCEEQESTA.DataSource = New DataTable

    End Sub

#End Region

#Region "MENU"

    Private Sub cmdGUARDAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGUARDAR.Click

        Try
            ' instancia la clase
            Dim objVerifica As New cla_Verificar_Dato

            Dim boCEEQESSO As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Numerico(Me.txtCEEQESSO)
            Dim boCEEQDESC As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.txtCEEQDESC)
            Dim boCEEQUNDE As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Decimal(Me.txtCEEQUNDE)
            Dim boCEEQEQSA As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Decimal(Me.txtCEEQEQSA)
            Dim boCEEQESTA As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboCEEQESTA)

            ' verifica los datos del formulario 
            If boCEEQESSO = True And _
                boCEEQDESC = True And _
                boCEEQUNDE = True And _
                boCEEQEQSA = True And _
                boCEEQESTA = True Then

                Dim objdatos22 As New cla_CESIEQUI

                If (objdatos22.fun_Actualizar_MANT_CESIEQUI(inID_REGISTRO, _
                                                            Me.txtCEEQESSO.Text, _
                                                            Me.txtCEEQDESC.Text, _
                                                            Me.txtCEEQUNDE.Text, _
                                                            Me.txtCEEQEQSA.Text, _
                                                            Me.cboCEEQESTA.SelectedValue)) Then
                    Me.txtCEEQESSO.Focus()
                    Me.Close()

                    mod_MENSAJE.Se_Guardaron_Los_Datos_Correctamente()
                Else
                    mod_MENSAJE.No_Se_Guardo_El_Registro_En_La_Base_De_Datos()
                End If
            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description & "Guardar")
        End Try

    End Sub
    Private Sub cmdCANCELAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSALIR.Click
        Me.txtCEEQESSO.Focus()
        Me.Close()
    End Sub

#End Region

#Region "FORMULARIO"

#Region "KeyDown"

    Private Sub cboCEEQESTA_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
            fun_Cargar_ComboBox_Con_Datos_Activos_ESTADO(Me.cboCEEQESTA, Me.cboCEEQESTA.SelectedIndex)
        End If
    End Sub

#End Region

#Region "KeyPress"

    Private Sub txt_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCEEQESSO.KeyPress, txtCEEQDESC.KeyPress, cboCEEQESTA.KeyPress, txtCEEQUNDE.KeyPress, txtCEEQEQSA.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Or e.KeyChar = Convert.ToChar(Keys.Tab) Then
            pp_pro_SaltarCampo()
        End If
    End Sub

#End Region

#Region "GotFocus"

    Private Sub txt_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCEEQESSO.GotFocus, txtCEEQDESC.GotFocus, txtCEEQUNDE.GotFocus, txtCEEQEQSA.GotFocus
        pp_pro_SobrearCampo(sender)
        pp_pro_DescripcionCampo(Me.strBARRESTA.Items(0), sender)
    End Sub
    Private Sub cmd_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdGUARDAR.GotFocus, cmdSALIR.GotFocus
        pp_pro_DescripcionCampo(Me.strBARRESTA.Items(0), sender)
    End Sub
    Private Sub cbo_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboCEEQESTA.GotFocus
        pp_pro_DescripcionCampo(Me.strBARRESTA.Items(0), sender)
    End Sub


#End Region

#Region "Click"

    Private Sub cboMOLIESTA_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboCEEQESTA.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_ESTADO(cboCEEQESTA, cboCEEQESTA.SelectedIndex)
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