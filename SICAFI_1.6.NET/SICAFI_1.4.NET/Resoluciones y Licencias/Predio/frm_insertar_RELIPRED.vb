Imports REGLAS_DEL_NEGOCIO

Public Class frm_insertar_RELIPRED

    '===============================
    '*** INSERTAR PREDIOS NUEVOS ***
    '===============================

#Region "VARIABLE"

    Dim inRLPRIDRE As Integer
    Dim inRLPRSECU As Integer
    Dim inRLPRNURA As Integer
    Dim stRLPRFERA As String

    Dim boINSERTAR As Boolean = False
    Dim boMODIFICAR As Boolean = False

#End Region

#Region "CONSTRUCTOR"

    Public Sub New(ByVal inIDRE As Integer, ByVal inSECU As Integer, ByVal inNURA As Integer, ByVal stFERA As String)
        inRLPRIDRE = inIDRE
        inRLPRSECU = inSECU
        inRLPRNURA = inNURA
        stRLPRFERA = stFERA

        boMODIFICAR = True

        InitializeComponent()
        pro_LimpiarCampos()
        pro_inicializarControles()

    End Sub
    Public Sub New(ByVal inSECU As Integer, ByVal inNURA As Integer, ByVal stFERA As String)
        inRLPRSECU = inSECU
        inRLPRNURA = inNURA
        stRLPRFERA = stFERA

        boINSERTAR = True

        InitializeComponent()
        pro_LimpiarCampos()
        pro_inicializarControles()
    End Sub

#End Region

#Region "PROCEDIMIENTOS"

    Private Sub pro_LimpiarCampos()

        Me.txtRLPRMUNI.Text = "266"
        Me.txtRLPRCORR.Text = "01"
        Me.txtRLPRBARR.Text = ""
        Me.txtRLPRMANZ.Text = ""
        Me.txtRLPRPRED.Text = ""
        Me.txtRLPREDIF.Text = ""
        Me.txtRLPRUNPR.Text = ""
        Me.txtRLPRMAIN.Text = "0"
        Me.txtRLPRNUFI.Text = "0"
        Me.lblRLPRCLSE.Text = ""

        Me.cboRLPRCLSE.DataSource = New DataTable

    End Sub
    Private Sub pro_inicializarControles()

        Try
            If boMODIFICAR = True Then

                ' instancia la clase
                Dim objdatos As New cla_RELIPRED
                Dim tbl As New DataTable

                tbl = objdatos.fun_Buscar_ID_RELIPRED(inRLPRIDRE)

                If tbl.Rows.Count > 0 Then

                    Me.Text = "Modificar registro"
                    Me.fraCEDUCATA.Text = "MODIFICAR PREDIOS"

                    Me.txtRLPRMUNI.Text = Trim(tbl.Rows(0).Item("RLPRMUNI"))
                    Me.txtRLPRCORR.Text = Trim(tbl.Rows(0).Item("RLPRCORR"))
                    Me.txtRLPRBARR.Text = Trim(tbl.Rows(0).Item("RLPRBARR"))
                    Me.txtRLPRMANZ.Text = Trim(tbl.Rows(0).Item("RLPRMANZ"))
                    Me.txtRLPRPRED.Text = Trim(tbl.Rows(0).Item("RLPRPRED"))
                    Me.txtRLPREDIF.Text = Trim(tbl.Rows(0).Item("RLPREDIF"))
                    Me.txtRLPRUNPR.Text = Trim(tbl.Rows(0).Item("RLPRUNPR"))

                    Dim objdatos1 As New cla_CLASSECT

                    Me.cboRLPRCLSE.DataSource = objdatos1.fun_Consultar_CAMPOS_MANT_CLASSECT
                    Me.cboRLPRCLSE.DisplayMember = "CLSEDESC"
                    Me.cboRLPRCLSE.ValueMember = "CLSECODI"

                    Me.cboRLPRCLSE.SelectedValue = tbl.Rows(0).Item("RLPRCLSE")

                    Me.txtRLPRMAIN.Text = Trim(tbl.Rows(0).Item("RLPRMAIN"))
                    Me.txtRLPRNUFI.Text = Trim(tbl.Rows(0).Item("RLPRNUFI"))

                    Me.lblRLPRCLSE.Text = CType(fun_Buscar_Lista_Valores_CLASSECT_Codigo(Me.cboRLPRCLSE), String)

                End If

            ElseIf boINSERTAR = True Then

                Me.Text = "Insertar registro"
                Me.fraCEDUCATA.Text = "INSERTAR PREDIOS"

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
                Dim objdatos As New cla_RELIPRED

                Dim boLLAVEPRIMARIA As Boolean = objdatos.fun_Verifica_llave_Primaria_RELIPRED(inRLPRNURA, stRLPRFERA, inRLPRSECU, Me.txtRLPRMAIN)

                ' instancia la clase
                Dim objVerifica As New cla_Verificar_Dato

                Dim boRLPRMUNI As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Numerico(Me.txtRLPRMUNI)
                Dim boRLPRCORR As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Numerico(Me.txtRLPRCORR)
                Dim boRLPRBARR As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Numerico(Me.txtRLPRBARR)
                Dim boRLPRMANZ As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Numerico(Me.txtRLPRMANZ)
                Dim boRLPRPRED As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Numerico(Me.txtRLPRPRED)
                Dim boRLPREDIF As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Numerico(Me.txtRLPREDIF)
                Dim boRLPRUNPR As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Numerico(Me.txtRLPRUNPR)
                Dim boRLPRCLSE As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboRLPRCLSE)
                Dim boRLPRMAIN As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Numerico(Me.txtRLPRMAIN)
                Dim boRLPRNUFI As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Numerico(Me.txtRLPRNUFI)

                ' verifica los datos del formulario 
                If boLLAVEPRIMARIA = True And _
                   boRLPRMUNI = True And _
                   boRLPRCORR = True And _
                   boRLPRBARR = True And _
                   boRLPRMANZ = True And _
                   boRLPRPRED = True And _
                   boRLPREDIF = True And _
                   boRLPRUNPR = True And _
                   boRLPRCLSE = True And _
                   boRLPRMAIN = True And _
                   boRLPRNUFI = True Then

                    Dim objdatos22 As New cla_RELIPRED

                    If (objdatos22.fun_Insertar_RELIPRED(inRLPRNURA, _
                                                         stRLPRFERA, _
                                                         inRLPRSECU, _
                                                         Me.txtRLPRMAIN.Text, _
                                                         Me.txtRLPRMUNI.Text, _
                                                         Me.txtRLPRCORR.Text, _
                                                         Me.txtRLPRBARR.Text, _
                                                         Me.txtRLPRMANZ.Text, _
                                                         Me.txtRLPRPRED.Text, _
                                                         Me.txtRLPREDIF.Text, _
                                                         Me.txtRLPRUNPR.Text, _
                                                         Me.cboRLPRCLSE.SelectedValue, _
                                                         Me.txtRLPRNUFI.Text)) = True Then

                        mod_MENSAJE.Se_Guardaron_Los_Datos_Correctamente()

                        If MessageBox.Show("¿ Desea agregar otro registro ?", "Mensaje...", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.No Then
                            Me.txtRLPRMUNI.Focus()
                            Me.Close()
                        Else
                            pro_LimpiarCampos()
                            Me.txtRLPRMUNI.Focus()
                        End If
                    Else
                        mod_MENSAJE.No_Se_Guardo_El_Registro_En_La_Base_De_Datos()
                    End If

                End If

                ' modifica el registro
            ElseIf boMODIFICAR = True Then

                ' instancia la clase
                Dim objVerifica As New cla_Verificar_Dato

                Dim boRLPRMUNI As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Numerico(Me.txtRLPRMUNI)
                Dim boRLPRCORR As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Numerico(Me.txtRLPRCORR)
                Dim boRLPRBARR As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Numerico(Me.txtRLPRBARR)
                Dim boRLPRMANZ As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Numerico(Me.txtRLPRMANZ)
                Dim boRLPRPRED As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Numerico(Me.txtRLPRPRED)
                Dim boRLPREDIF As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Numerico(Me.txtRLPREDIF)
                Dim boRLPRUNPR As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Numerico(Me.txtRLPRUNPR)
                Dim boRLPRCLSE As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboRLPRCLSE)
                Dim boRLPRMAIN As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Numerico(Me.txtRLPRMAIN)
                Dim boRLPRNUFI As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Numerico(Me.txtRLPRNUFI)

                ' verifica los datos del formulario 
                If boRLPRMUNI = True And _
                   boRLPRCORR = True And _
                   boRLPRBARR = True And _
                   boRLPRMANZ = True And _
                   boRLPRPRED = True And _
                   boRLPREDIF = True And _
                   boRLPRUNPR = True And _
                   boRLPRCLSE = True And _
                   boRLPRMAIN = True And _
                   boRLPRNUFI = True Then

                    Dim objdatos22 As New cla_RELIPRED

                    If (objdatos22.fun_Actualizar_RELIPRED(inRLPRIDRE, _
                                                           inRLPRNURA, _
                                                           stRLPRFERA, _
                                                           inRLPRSECU, _
                                                           Me.txtRLPRMAIN.Text, _
                                                           Me.txtRLPRMUNI.Text, _
                                                           Me.txtRLPRCORR.Text, _
                                                           Me.txtRLPRBARR.Text, _
                                                           Me.txtRLPRMANZ.Text, _
                                                           Me.txtRLPRPRED.Text, _
                                                           Me.txtRLPREDIF.Text, _
                                                           Me.txtRLPRUNPR.Text, _
                                                           Me.cboRLPRCLSE.SelectedValue, _
                                                           Me.txtRLPRNUFI.Text)) = True Then

                        mod_MENSAJE.Se_Guardaron_Los_Datos_Correctamente()
                        Me.txtRLPRMUNI.Focus()
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
        Me.txtRLPRMUNI.Focus()
        Me.Close()
    End Sub

#End Region

#Region "FORMULARIO"

#Region "KeyPress"

    Private Sub txt_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtRLPRMUNI.KeyPress, txtRLPRCORR.KeyPress, txtRLPRBARR.KeyPress, txtRLPRMANZ.KeyPress, txtRLPRPRED.KeyPress, txtRLPRMAIN.KeyPress, txtRLPRNUFI.KeyPress, cboRLPRCLSE.KeyPress, txtRLPREDIF.KeyPress, txtRLPRUNPR.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Or e.KeyChar = Convert.ToChar(Keys.Tab) Then
            pp_pro_SaltarCampo()
        End If
    End Sub

#End Region

#Region "KeyDown"

    Private Sub cboOBINCLSE_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboRLPRCLSE.KeyDown
        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
            fun_Cargar_ComboBox_Con_Datos_Activos_CLASSECT_Descripcion(Me.cboRLPRCLSE, Me.cboRLPRCLSE.SelectedIndex)
        End If
    End Sub

#End Region

#Region "SelectedIndexChanged"

    Private Sub cboOBINCLSE_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboRLPRCLSE.SelectedIndexChanged
        Me.lblRLPRCLSE.Text = CType(fun_Buscar_Lista_Valores_CLASSECT_Codigo(Me.cboRLPRCLSE), String)
    End Sub

#End Region

#Region "Click"

    Private Sub cboOBINCLSE_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboRLPRCLSE.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_CLASSECT_Descripcion(Me.cboRLPRCLSE, Me.cboRLPRCLSE.SelectedIndex)
    End Sub

#End Region

#Region "GotFocus"

    Private Sub txt_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtRLPRMUNI.GotFocus, txtRLPRCORR.GotFocus, txtRLPRBARR.GotFocus, txtRLPRMANZ.GotFocus, txtRLPRPRED.GotFocus, txtRLPRMAIN.GotFocus, txtRLPRNUFI.GotFocus, txtRLPREDIF.GotFocus, txtRLPRUNPR.GotFocus
        pp_pro_SobrearCampo(sender)
        pp_pro_DescripcionCampo(Me.strBARRESTA.Items(0), sender)
    End Sub
    Private Sub cmd_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdGUARDAR.GotFocus, cmdSALIR.GotFocus
        pp_pro_DescripcionCampo(Me.strBARRESTA.Items(0), sender)
    End Sub

#End Region

#Region "Validated"

    Private Sub txtRLPRMAIN_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtRLPRMAIN.Validated, txtRLPRNUFI.Validated

        If Trim(sender.text) = "" Then
            sender.text = 0
        End If

    End Sub
    Private Sub txtTRCAMUNI_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtRLPRMUNI.Validated
        If Me.txtRLPRMUNI.Text <> "" And fun_Verificar_Dato_Numerico_Evento_Validated(Me.txtRLPRMUNI.Text) = True Then
            Me.txtRLPRMUNI.Text = fun_Formato_Mascara_3_String(Me.txtRLPRMUNI.Text)
        End If
    End Sub
    Private Sub txtTRCACORR_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtRLPRCORR.Validated
        If Me.txtRLPRCORR.Text <> "" And fun_Verificar_Dato_Numerico_Evento_Validated(Me.txtRLPRCORR.Text) = True Then
            Me.txtRLPRCORR.Text = fun_Formato_Mascara_2_String(Me.txtRLPRCORR.Text)
        End If
    End Sub
    Private Sub txtTRCABARR_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtRLPRBARR.Validated
        If Me.txtRLPRBARR.Text <> "" And fun_Verificar_Dato_Numerico_Evento_Validated(Me.txtRLPRBARR.Text) = True Then
            Me.txtRLPRBARR.Text = fun_Formato_Mascara_3_String(Me.txtRLPRBARR.Text)
        End If
    End Sub
    Private Sub txtTRCAMANZ_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtRLPRMANZ.Validated
        If Me.txtRLPRMANZ.Text <> "" And fun_Verificar_Dato_Numerico_Evento_Validated(Me.txtRLPRMANZ.Text) = True Then
            Me.txtRLPRMANZ.Text = fun_Formato_Mascara_3_String(Me.txtRLPRMANZ.Text)
        End If
    End Sub
    Private Sub txtTRCAPRED_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtRLPRPRED.Validated
        If Me.txtRLPRPRED.Text <> "" And fun_Verificar_Dato_Numerico_Evento_Validated(Me.txtRLPRPRED.Text) = True Then
            Me.txtRLPRPRED.Text = fun_Formato_Mascara_5_String(Me.txtRLPRPRED.Text)
        End If
    End Sub
    Private Sub txtRLPREDIF_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtRLPREDIF.Validated
        If Me.txtRLPREDIF.Text <> "" And fun_Verificar_Dato_Numerico_Evento_Validated(Me.txtRLPREDIF.Text) = True Then
            Me.txtRLPREDIF.Text = fun_Formato_Mascara_3_String(Me.txtRLPREDIF.Text)
        End If
    End Sub
    Private Sub txtRLPRUNPR_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtRLPRUNPR.Validated
        If Me.txtRLPRUNPR.Text <> "" And fun_Verificar_Dato_Numerico_Evento_Validated(Me.txtRLPRUNPR.Text) = True Then
            Me.txtRLPRUNPR.Text = fun_Formato_Mascara_5_String(Me.txtRLPRUNPR.Text)
        End If
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