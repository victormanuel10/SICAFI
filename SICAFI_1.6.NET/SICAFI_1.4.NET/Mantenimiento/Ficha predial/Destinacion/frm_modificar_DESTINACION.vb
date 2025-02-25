Imports REGLAS_DEL_NEGOCIO

Public Class frm_modificar_DESTINACION

    '=============================
    '*** MODIFICAR DESTINACION ***
    '=============================

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

            Me.cboDESTESTA.DataSource = objdatos.fun_Consultar_TODOS_LOS_ESTADOS
            Me.cboDESTESTA.DisplayMember = "ESTADESC"
            Me.cboDESTESTA.ValueMember = "ESTACODI"

            Dim objdatos1 As New cla_DESTINACION
            Dim tbl As New DataTable

            tbl = objdatos1.fun_Buscar_ID_MANT_DESTINACION(inID_REGISTRO)

            Me.txtDESTCODI.Text = Trim(tbl.Rows(0).Item("DESTCODI"))
            Me.txtDESTDESC.Text = Trim(tbl.Rows(0).Item("DESTDESC"))
            Me.cboDESTESTA.SelectedValue = tbl.Rows(0).Item("DESTESTA")

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub

#End Region

#Region "MENU"

    Private Sub cmdGUARDAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGUARDAR.Click
        Try

            Dim objVerifica As New cla_Verificar_Dato

            Dim boDESTCODI As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Numerico(Me.txtDESTCODI)
            Dim boDESTDESC As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.txtDESTDESC)
            Dim boDESTESTA As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboDESTESTA)

            ' verifica los datos del formulario 
            If boDESTCODI = True And _
               boDESTDESC = True And _
               boDESTESTA = True Then

                Dim objdatos As New cla_DESTINACION

                If objdatos.fun_Actualizar_MANT_DESTINACION(inID_REGISTRO, _
                                                            Me.txtDESTCODI.Text, _
                                                            Me.txtDESTDESC.Text, _
                                                            Me.cboDESTESTA.SelectedValue) = True Then
                    Me.txtDESTDESC.Focus()
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
        Me.txtDESTDESC.Focus()
        Me.Close()
    End Sub

#End Region

#Region "FORMULARIO"

#Region "KeyDown"

    Private Sub cboDESTESTA_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboDESTESTA.KeyDown
        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
            fun_Cargar_ComboBox_Con_Datos_Activos_ESTADO(Me.cboDESTESTA, Me.cboDESTESTA.SelectedIndex)
        End If
    End Sub

#End Region

#Region "KeyPress"

    Private Sub txt_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtDESTCODI.KeyPress, txtDESTDESC.KeyPress, cboDESTESTA.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Or e.KeyChar = Convert.ToChar(Keys.Tab) Then
            pp_pro_SaltarCampo()
        End If
    End Sub

#End Region

#Region "GotFocus"

    Private Sub txt_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtDESTCODI.GotFocus, txtDESTDESC.GotFocus
        pp_pro_SobrearCampo(sender)
        pp_pro_DescripcionCampo(Me.strBARRESTA.Items(0), sender)
    End Sub
    Private Sub cmd_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdGUARDAR.GotFocus, cmdSALIR.GotFocus
        pp_pro_DescripcionCampo(Me.strBARRESTA.Items(0), sender)
    End Sub
    Private Sub cbo_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboDESTESTA.GotFocus
        pp_pro_DescripcionCampo(Me.strBARRESTA.Items(0), sender)
    End Sub

#End Region

#Region "Click"

    Private Sub cboMOLIESTA_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboDESTESTA.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_ESTADO(cboDESTESTA, cboDESTESTA.SelectedIndex)
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