Imports REGLAS_DEL_NEGOCIO

Public Class frm_insertar_PROPANTE

    '=====================================
    '*** INSERTAR PROPIETARIO ANTERIOR ***
    '=====================================

#Region "VARIABLE"

    Dim vl_inFIPRNUFI As Integer
    Dim vl_stFPPRNUDO As String

#End Region

#Region "CONSTRUCTOR"

    Public Sub New(ByVal inFIPRNUFI As Integer, ByVal stFPPRNUDO As String)
        vl_inFIPRNUFI = inFIPRNUFI
        vl_stFPPRNUDO = stFPPRNUDO

        InitializeComponent()
        pro_LimpiarCampos()
        pro_inicializarControles()

    End Sub

#End Region

#Region "PROCEDIMIENTOS"

    Private Sub pro_inicializarControles()

        Try
            Dim objdatos As New cla_ESTADO

            Me.cboPRANESTA.DataSource = objdatos.fun_Consultar_TODOS_LOS_ESTADOS
            Me.cboPRANESTA.DisplayMember = "ESTADESC"
            Me.cboPRANESTA.ValueMember = "ESTACODI"

            Dim objdatos123 As New cla_FIPRPROP
            Dim tbl123 As New DataTable

            tbl123 = objdatos123.fun_Buscar_CODIGO_FIPRPROP(vl_inFIPRNUFI, Trim(vl_stFPPRNUDO))

            ' verifica la existencia de registros
            If tbl123.Rows.Count > 0 Then

                Me.txtPRANNUFI.Text = vl_inFIPRNUFI
                Me.txtPRACNUDO.Text = Trim(tbl123.Rows(0).Item("FPPRNUDO").ToString)
                Me.txtPRACPRAP.Text = Trim(tbl123.Rows(0).Item("FPPRPRAP").ToString)
                Me.txtPRACSEAP.Text = Trim(tbl123.Rows(0).Item("FPPRSEAP").ToString)
                Me.txtPRACNOMB.Text = Trim(tbl123.Rows(0).Item("FPPRNOMB").ToString)

            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub pro_LimpiarCampos()

        Me.cboPRANCAAC.DataSource = New DataTable

        Me.txtPRANPRAP.Text = ""
        Me.txtPRANSEAP.Text = ""
        Me.txtPRANNOMB.Text = ""
        Me.txtPRANOBSE.Text = ""
        Me.txtPRACNUDO.Text = ""
        Me.txtPRACPRAP.Text = ""
        Me.txtPRACSEAP.Text = ""
        Me.txtPRACNOMB.Text = ""
        Me.txtPRANNUFI.Text = ""

        Me.lblPRANCAAC.Text = ""

    End Sub

#End Region

#Region "MENU"

    Private Sub cmdGUARDAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGUARDAR.Click

        Try
            Dim objVerifica As New cla_Verificar_Dato

            Dim boPRANPRAN As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.txtPRANPRAP)
            Dim boPRANNOMB As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.txtPRANNOMB)
            Dim boPRANCAAC As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboPRANCAAC)
            
            ' verifica los datos del formulario 
            If boPRANPRAN = True And _
               boPRANNOMB = True And _
               boPRANCAAC = True Then

                Dim objdatos22 As New cla_PROPANTE

                If Me.chkGuardarEnTodosLosPropietarios.Checked = False Then

                    If (objdatos22.fun_Insertar_PROPANTE(vl_inFIPRNUFI, _
                                                             vl_stFPPRNUDO, _
                                                             Trim(Me.txtPRANPRAP.Text), _
                                                             Trim(Me.txtPRANSEAP.Text), _
                                                             Trim(Me.txtPRANNOMB.Text), _
                                                             Me.cboPRANCAAC.SelectedValue, _
                                                             Trim(Me.txtPRANOBSE.Text), _
                                                             Me.cboPRANESTA.SelectedValue)) = True Then

                        mod_MENSAJE.Se_Guardaron_Los_Datos_Correctamente()
                        Me.Close()

                    Else
                        mod_MENSAJE.No_Se_Guardo_El_Registro_En_La_Base_De_Datos()
                    End If

                ElseIf Me.chkGuardarEnTodosLosPropietarios.Checked = True Then

                    Dim objdatos33 As New cla_FIPRPROP
                    Dim tbl33 As New DataTable

                    tbl33 = objdatos33.fun_Consultar_FIPRPROP_X_FICHA_PREDIAL(vl_inFIPRNUFI)

                    If tbl33.Rows.Count > 0 Then

                        Dim i As Integer = 0

                        For i = 0 To tbl33.Rows.Count - 1

                            Dim stFPPRNUDO As String = Trim(tbl33.Rows(i).Item("FPPRNUDO").ToString)

                            If (objdatos22.fun_Insertar_PROPANTE(vl_inFIPRNUFI, _
                                                                stFPPRNUDO, _
                                                                Trim(Me.txtPRANPRAP.Text), _
                                                                Trim(Me.txtPRANSEAP.Text), _
                                                                Trim(Me.txtPRANNOMB.Text), _
                                                                Me.cboPRANCAAC.SelectedValue, _
                                                                Trim(Me.txtPRANOBSE.Text), _
                                                                Me.cboPRANESTA.SelectedValue)) = True Then
                            Else
                                mod_MENSAJE.No_Se_Guardo_El_Registro_En_La_Base_De_Datos()
                            End If

                        Next

                        mod_MENSAJE.Se_Guardaron_Los_Datos_Correctamente()
                        Me.Close()

                    End If
                End If
            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub cmdCANCELAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSALIR.Click
        Me.cboPRANCAAC.Focus()
        Me.Close()
    End Sub

#End Region

#Region "FORMULARIO"

#Region "Load"

    Private Sub frm_insertar_TARIALPU_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.cboPRANCAAC.Focus()
    End Sub

#End Region

#Region "KeyPress"

    Private Sub txt_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtPRANNUFI.KeyPress, txtPRACNUDO.KeyPress, txtPRANSEAP.KeyPress, txtPRANPRAP.KeyPress, txtPRANNOMB.KeyPress, cboPRANCAAC.KeyPress, cboPRANESTA.KeyPress, txtPRANOBSE.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Or e.KeyChar = Convert.ToChar(Keys.Tab) Then
            pp_pro_SaltarCampo()
        End If
    End Sub
    Private Sub chkGuardarEnTodosLosPropietarios_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles chkGuardarEnTodosLosPropietarios.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Or e.KeyChar = Convert.ToChar(Keys.Tab) Then
            Me.cmdGUARDAR.Focus()
        End If
    End Sub

#End Region

#Region "KeyDown"

    Private Sub cboPRANCAAC_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboPRANCAAC.KeyDown
        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
            fun_Cargar_ComboBox_Con_Datos_Activos_CAUSACTO(Me.cboPRANCAAC, Me.cboPRANCAAC.SelectedIndex)
        End If
    End Sub
    Private Sub cboPRANESTA_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboPRANESTA.KeyDown
        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
            fun_Cargar_ComboBox_Con_Datos_Activos_ESTADO(Me.cboPRANESTA, Me.cboPRANESTA.SelectedIndex)
        End If
    End Sub

#End Region

#Region "GotFocus"

    Private Sub txt_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtPRANNUFI.GotFocus, txtPRACNUDO.GotFocus, txtPRACSEAP.GotFocus, txtPRANPRAP.GotFocus, txtPRANNOMB.GotFocus, txtPRANOBSE.GotFocus
        pp_pro_SobrearCampo(sender)
        pp_pro_DescripcionCampo(Me.strBARRESTA.Items(0), sender)
    End Sub
    Private Sub cmd_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdGUARDAR.GotFocus, cmdSALIR.GotFocus
        pp_pro_DescripcionCampo(Me.strBARRESTA.Items(0), sender)
    End Sub
    Private Sub cbo_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboPRANCAAC.GotFocus, cboPRANESTA.GotFocus
        pp_pro_DescripcionCampo(Me.strBARRESTA.Items(0), sender)
    End Sub

#End Region

#Region "SelectedIndexChanged"

  
    Private Sub cboPRANCAAC_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboPRANCAAC.SelectedIndexChanged
        Me.lblPRANCAAC.Text = CType(fun_Buscar_Lista_Valores_CAUSACTO(Me.cboPRANCAAC.Text), String)
    End Sub

#End Region

#Region "Click"

    Private Sub cboPRANCAAC_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboPRANCAAC.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_CAUSACTO(Me.cboPRANCAAC, Me.cboPRANCAAC.SelectedIndex)
    End Sub
    Private Sub cboPRANESTA_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboPRANESTA.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_ESTADO(Me.cboPRANESTA, Me.cboPRANESTA.SelectedIndex)
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