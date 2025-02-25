Imports REGLAS_DEL_NEGOCIO

Public Class frm_insertar_RELISOLI

    '========================================
    '*** INSERTAR INFORMACIÓN SOLICITANTE ***
    '========================================

#Region "VARIABLE"

    Dim inRLSOIDRE As Integer
    Dim inRLSOSECU As Integer
    Dim inRLSONURA As Integer
    Dim stRLSOFERA As String

    Dim boINSERTAR As Boolean = False
    Dim boMODIFICAR As Boolean = False

#End Region

#Region "CONSTRUCTOR"

    Public Sub New(ByVal inIDRE As Integer, ByVal inSECU As Integer, ByVal inNURA As Integer, ByVal stFERA As String)
        inRLSOIDRE = inIDRE
        inRLSOSECU = inSECU
        inRLSONURA = inNURA
        stRLSOFERA = stFERA

        boMODIFICAR = True

        InitializeComponent()
        pro_LimpiarCampos()
        pro_inicializarControles()

    End Sub
    Public Sub New(ByVal inSECU As Integer, ByVal inNURA As Integer, ByVal stFERA As String)
        inRLSOSECU = inSECU
        inRLSONURA = inNURA
        stRLSOFERA = stFERA

        boINSERTAR = True

        InitializeComponent()
        pro_LimpiarCampos()
        pro_inicializarControles()
    End Sub

#End Region

#Region "PROCEDIMIENTOS"

    Private Sub pro_LimpiarCampos()

        Me.txtRLSONUDO.Text = ""
        Me.txtRLSONOMB.Text = ""
        Me.txtRLSOPRAP.Text = ""
        Me.txtRLSOSEAP.Text = ""
        Me.txtRLSOTELE.Text = ""
        Me.txtRLSOCELU.Text = ""
        Me.txtRLSOCOEL.Text = ""
        Me.txtRLSODIPR.Text = ""
        Me.txtRLSODINO.Text = ""
        Me.txtRLSOCOPO.Text = ""
        Me.txtRLSORESO.Text = ""
        Me.lblRLSOSOLI.Text = ""

        Me.cboRLSOSOLI.DataSource = New DataTable

    End Sub
    Private Sub pro_inicializarControles()

        Try
            If boMODIFICAR = True Then

                ' instancia la clase
                Dim objdatos As New cla_RELISOLI
                Dim tbl As New DataTable

                tbl = objdatos.fun_Buscar_ID_RELISOLI(inRLSOIDRE)

                If tbl.Rows.Count > 0 Then

                    Me.Text = "Modificar registro"
                    Me.fraINFOUSUA.Text = "MODIFICAR SOLICITANTE"

                    Me.txtRLSONUDO.Text = Trim(tbl.Rows(0).Item("RLSONUDO"))
                    Me.txtRLSONOMB.Text = Trim(tbl.Rows(0).Item("RLSONOMB"))
                    Me.txtRLSOPRAP.Text = Trim(tbl.Rows(0).Item("RLSOPRAP"))
                    Me.txtRLSOSEAP.Text = Trim(tbl.Rows(0).Item("RLSOSEAP"))
                    Me.txtRLSOTELE.Text = Trim(tbl.Rows(0).Item("RLSOTELE"))
                    Me.txtRLSOCELU.Text = Trim(tbl.Rows(0).Item("RLSOCELU"))
                    Me.txtRLSOCOEL.Text = Trim(tbl.Rows(0).Item("RLSOCOEL"))
                    Me.txtRLSODIPR.Text = Trim(tbl.Rows(0).Item("RLSODIPR"))
                    Me.txtRLSODINO.Text = Trim(tbl.Rows(0).Item("RLSODINO"))
                    Me.txtRLSOCOPO.Text = Trim(tbl.Rows(0).Item("RLSOCOPO"))
                    Me.txtRLSORESO.Text = Trim(tbl.Rows(0).Item("RLSORESO"))

                    Dim objdatos9 As New cla_SOLICITANTE

                    Me.cboRLSOSOLI.DataSource = objdatos9.fun_Consultar_CAMPOS_MANT_SOLICITANTE
                    Me.cboRLSOSOLI.DisplayMember = "SOLIDESC"
                    Me.cboRLSOSOLI.ValueMember = "SOLICODI"

                    Me.cboRLSOSOLI.SelectedValue = tbl.Rows(0).Item("RLSOSOLI")

                    Me.lblRLSOSOLI.Text = CType(fun_Buscar_Lista_Valores_SOLICITANTE_Codigo(Me.cboRLSOSOLI), String)

                    Me.txtRLSONUDO.ReadOnly = True

                End If

            ElseIf boINSERTAR = True Then

                Me.Text = "Insertar registro"
                Me.fraINFOUSUA.Text = "INSERTAR SOLICITANTE"

            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub

#End Region

#Region "MENU"

    Private Sub cmdGUARDAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGUARDAR.Click

        Try
            ' inserta el registro
            If boINSERTAR = True Then

                ' instancia la clase
                Dim objdatos As New cla_RELISOLI

                Dim boLLAVEPRIMARIA As Boolean = objdatos.fun_Verifica_llave_Primaria_RELISOLI(inRLSONURA, stRLSOFERA, inRLSOSECU, Me.txtRLSONUDO)

                ' instancia la clase
                Dim objVerifica As New cla_Verificar_Dato

                Dim boRLSONUDO As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.txtRLSONUDO)
                Dim boRLSONOMB As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.txtRLSONOMB)
                Dim boRLSOSOLI As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboRLSOSOLI)

                ' verifica los datos del formulario 
                If boLLAVEPRIMARIA = True And _
                   boRLSONUDO = True And _
                   boRLSONOMB = True And _
                   boRLSOSOLI = True Then

                    Dim objdatos22 As New cla_RELISOLI

                    If (objdatos22.fun_Insertar_RELISOLI(inRLSONURA, _
                                                         stRLSOFERA, _
                                                         inRLSOSECU, _
                                                         Me.txtRLSONUDO.Text, _
                                                         Me.txtRLSONOMB.Text, _
                                                         Me.txtRLSOPRAP.Text, _
                                                         Me.txtRLSOSEAP.Text, _
                                                         Me.txtRLSODIPR.Text, _
                                                         Me.txtRLSODINO.Text, _
                                                         Me.txtRLSOTELE.Text, _
                                                         Me.txtRLSOCELU.Text, _
                                                         Me.txtRLSOCOEL.Text, _
                                                         Me.txtRLSOCOPO.Text, _
                                                         Me.txtRLSORESO.Text, _
                                                         Me.cboRLSOSOLI.SelectedValue)) = True Then

                        mod_MENSAJE.Se_Guardaron_Los_Datos_Correctamente()
                        Me.txtRLSONUDO.Focus()
                        Me.Close()
                    Else
                        mod_MENSAJE.No_Se_Guardo_El_Registro_En_La_Base_De_Datos()
                    End If

                End If

                ' modifica el registro
            ElseIf boMODIFICAR = True Then

                ' instancia la clase
                Dim objVerifica As New cla_Verificar_Dato

                Dim boRLSONUDO As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.txtRLSONUDO)
                Dim boRLSONOMB As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.txtRLSONOMB)

                ' verifica los datos del formulario 
                If boRLSONUDO = True And _
                   boRLSONOMB = True Then

                    Dim objdatos22 As New cla_RELISOLI

                    If (objdatos22.fun_Actualizar_RELISOLI(inRLSOIDRE, _
                                                           inRLSONURA, _
                                                           stRLSOFERA, _
                                                           inRLSOSECU, _
                                                           Me.txtRLSONUDO.Text, _
                                                           Me.txtRLSONOMB.Text, _
                                                           Me.txtRLSOPRAP.Text, _
                                                           Me.txtRLSOSEAP.Text, _
                                                           Me.txtRLSODIPR.Text, _
                                                           Me.txtRLSODINO.Text, _
                                                           Me.txtRLSOTELE.Text, _
                                                           Me.txtRLSOCELU.Text, _
                                                           Me.txtRLSOCOEL.Text, _
                                                           Me.txtRLSOCOPO.Text, _
                                                           Me.txtRLSORESO.Text, _
                                                           Me.cboRLSOSOLI.SelectedValue)) = True Then

                        mod_MENSAJE.Se_Guardaron_Los_Datos_Correctamente()
                        Me.txtRLSONUDO.Focus()
                        Me.Close()
                    Else
                        mod_MENSAJE.No_Se_Guardo_El_Registro_En_La_Base_De_Datos()
                    End If

                End If

            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub cmdCANCELAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSALIR.Click
        Me.txtRLSONUDO.Focus()
        Me.Close()
    End Sub

#End Region

#Region "FORMULARIO"

#Region "KeyPress"

    Private Sub txt_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtRLSONUDO.KeyPress, txtRLSONOMB.KeyPress, txtRLSOPRAP.KeyPress, txtRLSOSEAP.KeyPress, txtRLSOTELE.KeyPress, txtRLSOCELU.KeyPress, txtRLSODIPR.KeyPress, txtRLSOCOEL.KeyPress, txtRLSODINO.KeyPress, txtRLSORESO.KeyPress, cboRLSOSOLI.KeyPress, txtRLSOCOPO.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Or e.KeyChar = Convert.ToChar(Keys.Tab) Then
            pp_pro_SaltarCampo()
        End If
    End Sub

#End Region

#Region "SelectedIndexChanged"

    Private Sub cboRECLSOLI_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboRLSOSOLI.SelectedIndexChanged
        Me.lblRLSOSOLI.Text = CType(fun_Buscar_Lista_Valores_SOLICITANTE_Codigo(Me.cboRLSOSOLI), String)
    End Sub

#End Region

#Region "Click"

    Private Sub cboRECLSOLI_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboRLSOSOLI.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_SOLICITANTE_Descripcion(Me.cboRLSOSOLI, Me.cboRLSOSOLI.SelectedIndex)
    End Sub

#End Region

#Region "KeyDown"

    Private Sub cboRECLSOLI_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboRLSOSOLI.KeyDown
        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
            fun_Cargar_ComboBox_Con_Datos_Activos_SOLICITANTE_Descripcion(Me.cboRLSOSOLI, Me.cboRLSOSOLI.SelectedIndex)
        End If
    End Sub

#End Region

#Region "GotFocus"

    Private Sub txt_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtRLSONUDO.GotFocus, txtRLSONOMB.GotFocus, txtRLSOPRAP.GotFocus, txtRLSOSEAP.GotFocus, txtRLSOTELE.GotFocus, txtRLSOCELU.GotFocus, txtRLSODIPR.GotFocus, txtRLSOCOEL.GotFocus, txtRLSODINO.GotFocus, txtRLSORESO.GotFocus
        pp_pro_SobrearCampo(sender)
        pp_pro_DescripcionCampo(Me.strBARRESTA.Items(0), sender)
    End Sub
    Private Sub cbo_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboRLSOSOLI.GotFocus
        pp_pro_DescripcionCampo(Me.strBARRESTA.Items(0), sender)
    End Sub
    Private Sub cmd_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdGUARDAR.GotFocus, cmdSALIR.GotFocus
        pp_pro_DescripcionCampo(Me.strBARRESTA.Items(0), sender)
    End Sub

#End Region

#Region "Validated"

    Private Sub txtAJIUNUDO_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtRLSONUDO.Validated

        Try
            ' extrae el tercero si ya existe en base de datos
            Dim objdatos1 As New cla_TERCERO
            Dim tbl1 As New DataTable

            tbl1 = objdatos1.fun_Buscar_CODIGO_TERCERO(Trim(Me.txtRLSONUDO.Text))

            If tbl1.Rows.Count > 0 Then

                Me.txtRLSONOMB.Text = Trim(tbl1.Rows(0).Item(5))
                Me.txtRLSOPRAP.Text = Trim(tbl1.Rows(0).Item(6))
                Me.txtRLSOSEAP.Text = Trim(tbl1.Rows(0).Item(7))

            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

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