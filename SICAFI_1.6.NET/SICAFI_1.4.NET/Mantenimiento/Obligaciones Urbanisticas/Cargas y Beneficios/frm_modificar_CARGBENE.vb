Imports REGLAS_DEL_NEGOCIO

Public Class frm_modificar_CARGBENE

    '======================================================
    '*** MODIFICAR CARGAS Y BENEFICIOS DEL PLAN PARCIAL ***
    '======================================================

#Region "VARIABLES"

    Dim vl_inCABEIDRE As Integer = 0
    Dim vl_inCABENURE As Integer = 0
    Dim vl_stCABEFERE As String = ""
    Dim vl_inCABEUAU As Integer = 0

#End Region

#Region "CONSTRUCTOR"

    Public Sub New(ByVal inCABEIDRE As Integer, ByVal inCABENURE As Integer, ByVal stCABEFERE As String, ByVal inCABEAUA As Integer)
        vl_inCABEIDRE = inCABEIDRE
        vl_inCABENURE = inCABENURE
        vl_stCABEFERE = stCABEFERE
        vl_inCABEUAU = inCABEAUA

        InitializeComponent()
        pro_inicializarControles()
    End Sub

#End Region

#Region "PROCEDIMIENTOS"

    Private Sub pro_inicializarControles()

        Try
            Dim objdatos1 As New cla_PLANPARC

            Me.cboCABEPLPA.DataSource = objdatos1.fun_Consultar_CAMPOS_MANT_PLANPARC
            Me.cboCABEPLPA.DisplayMember = "PLPADESC"
            Me.cboCABEPLPA.ValueMember = "PLPAIDRE"

            Dim objdatos2 As New cla_ESTADO

            Me.cboCABEESTA.DataSource = objdatos2.fun_Consultar_TODOS_LOS_ESTADOS
            Me.cboCABEESTA.DisplayMember = "ESTADESC"
            Me.cboCABEESTA.ValueMember = "ESTACODI"

            Dim objdatos3 As New cla_CARGBENE
            Dim tbl As New DataTable

            tbl = objdatos3.fun_Buscar_ID_MANT_CARGBENE(vl_inCABEIDRE)

            If tbl.Rows.Count > 0 Then

                ' instancia la clase
                Dim objdatos4 As New cla_PLANPARC
                Dim tbl4 As New DataTable

                tbl4 = objdatos4.fun_Buscar_CODIGO_PLANPARC(vl_inCABENURE, vl_stCABEFERE)

                If tbl4.Rows.Count > 0 Then
                    Me.cboCABEPLPA.SelectedValue = tbl4.Rows(0).Item("PLPAIDRE")
                End If

                Me.txtCABEUAU.Text = Trim(tbl.Rows(0).Item("CABEUAU"))
                Me.txtCABEDESC.Text = Trim(tbl.Rows(0).Item("CABEDESC"))
                Me.txtCABECEEP.Text = Trim(tbl.Rows(0).Item("CABECEEP"))
                Me.txtCABECOEP.Text = Trim(tbl.Rows(0).Item("CABECOEP"))
                Me.txtCABECEVI.Text = Trim(tbl.Rows(0).Item("CABECEVI"))
                Me.txtCABECOVI.Text = Trim(tbl.Rows(0).Item("CABECOVI"))
                Me.txtCABECOEQ.Text = Trim(tbl.Rows(0).Item("CABECOEQ"))
                Me.txtCABECVAI.Text = Trim(tbl.Rows(0).Item("CABECVAI"))
                Me.txtCABECEDI.Text = Trim(tbl.Rows(0).Item("CABECEDI"))
                Me.cboCABEESTA.SelectedValue = tbl.Rows(0).Item("CABEESTA")

            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub pro_LimpiarCampos()

        pp_pro_LimpiarCampos(fraCARGBENE)

    End Sub

#End Region

#Region "MENU"

    Private Sub cmdGUARDAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGUARDAR.Click

        Try
            ' consulta la resolucion y fecha
            Dim obPLANPARC As New cla_PLANPARC
            Dim dtPLANPARC As New DataTable

            dtPLANPARC = obPLANPARC.fun_Buscar_ID_MANT_PLANPARC(Me.cboCABEPLPA.SelectedValue)

            If dtPLANPARC.Rows.Count > 0 Then

                vl_inCABENURE = dtPLANPARC.Rows(0).Item("PLPANURE")
                vl_stCABEFERE = dtPLANPARC.Rows(0).Item("PLPAFERE")

            End If

            Dim objVerifica As New cla_Verificar_Dato

            Dim boCABEPLPA As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboCABEPLPA)
            Dim boCABEUAU As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Numerico(Me.txtCABEUAU)
            Dim boPLPADESC As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.txtCABEDESC)
            Dim boCABECEEP As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Numerico(Me.txtCABECEEP)
            Dim boCABECOEP As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Numerico(Me.txtCABECOEP)
            Dim boCABECEVI As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Numerico(Me.txtCABECEVI)
            Dim boCABECOVI As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Numerico(Me.txtCABECOVI)
            Dim boCABECOEQ As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Numerico(Me.txtCABECOEQ)
            Dim boCABECVAI As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Numerico(Me.txtCABECVAI)
            Dim boCABECEDI As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Numerico(Me.txtCABECEDI)
            Dim boPLPAESTA As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboCABEESTA)

            ' verifica los datos del formulario 
            If boCABEPLPA = True And _
                boPLPADESC = True And _
                boCABECEEP = True And _
                boCABECOEP = True And _
                boCABECEVI = True And _
                boCABECOVI = True And _
                boCABECOEQ = True And _
                boCABECVAI = True And _
                boCABECEDI = True And _
                boPLPAESTA = True Then

                Dim objdatos22 As New cla_CARGBENE

                If (objdatos22.fun_Actualizar_MANT_CARGBENE(vl_inCABEIDRE, _
                                                            vl_inCABENURE, _
                                                            Trim(vl_stCABEFERE), _
                                                            Me.txtCABEUAU.Text, _
                                                            Me.txtCABEDESC.Text, _
                                                            Me.txtCABECEEP.Text, _
                                                            Me.txtCABECOEP.Text, _
                                                            Me.txtCABECEVI.Text, _
                                                            Me.txtCABECOVI.Text, _
                                                            Me.txtCABECOEQ.Text, _
                                                            Me.txtCABECVAI.Text, _
                                                            Me.txtCABECEDI.Text, _
                                                            Me.cboCABEESTA.SelectedValue)) = True Then

                    mod_MENSAJE.Se_Modificaron_Los_Datos_Correctamente()

                    Me.cboCABEPLPA.Focus()
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
        Me.txtCABEUAU.Focus()
        Me.Close()
    End Sub

#End Region

#Region "FORMULARIO"

#Region "KeyDown"

    Private Sub cboCABEPLPA_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboCABEPLPA.KeyDown
        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
            fun_Cargar_ComboBox_Con_Datos_Activos_PLAN_PARCIAL(Me.cboCABEPLPA, Me.cboCABEPLPA.SelectedIndex)
        End If
    End Sub
    Private Sub cboCABEESTA_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboCABEESTA.KeyDown
        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
            fun_Cargar_ComboBox_Con_Datos_Activos_ESTADO(Me.cboCABEESTA, Me.cboCABEESTA.SelectedIndex)
        End If
    End Sub

#End Region

#Region "KeyPress"

    Private Sub txt_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboCABEPLPA.KeyPress, txtCABEUAU.KeyPress, txtCABEDESC.KeyPress, txtCABECEEP.KeyPress, txtCABECEVI.KeyPress, txtCABECOEP.KeyPress, txtCABECOEQ.KeyPress, txtCABECOVI.KeyPress, cboCABEESTA.KeyPress, txtCABECVAI.KeyPress, txtCABECEDI.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Or e.KeyChar = Convert.ToChar(Keys.Tab) Then
            pp_pro_SaltarCampo()
        End If
    End Sub

#End Region

#Region "GotFocus"

    Private Sub txt_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCABEUAU.GotFocus, txtCABEDESC.GotFocus, txtCABECEEP.GotFocus, txtCABECEVI.GotFocus, txtCABECOEP.GotFocus, txtCABECOEQ.GotFocus, txtCABECOVI.GotFocus, txtCABECVAI.GotFocus, txtCABECEDI.GotFocus
        pp_pro_SobrearCampo(sender)
        pp_pro_DescripcionCampo(Me.strBARRESTA.Items(0), sender)
    End Sub
    Private Sub cmd_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdGUARDAR.GotFocus, cmdSALIR.GotFocus
        pp_pro_DescripcionCampo(Me.strBARRESTA.Items(0), sender)
    End Sub
    Private Sub cbo_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboCABEESTA.GotFocus, cboCABEPLPA.GotFocus
        pp_pro_DescripcionCampo(Me.strBARRESTA.Items(0), sender)
    End Sub


#End Region

#Region "Click"

    Private Sub cboCABEPLPA_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboCABEPLPA.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_PLAN_PARCIAL(Me.cboCABEPLPA, Me.cboCABEPLPA.SelectedIndex)
    End Sub
    Private Sub cboMOLIESTA_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboCABEESTA.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_ESTADO(cboCABEESTA, cboCABEESTA.SelectedIndex)
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