Imports REGLAS_DEL_NEGOCIO

Public Class frm_insertar_LIRAPRED

    '===============================
    '*** INSERTAR PREDIOS NUEVOS ***
    '===============================

#Region "VARIABLE"

    Dim inLRPRIDRE As Integer
    Dim inLRPRSECU As Integer
    Dim inLRPRNURA As Integer
    Dim stLRPRFERA As String

    Dim boINSERTAR As Boolean = False
    Dim boMODIFICAR As Boolean = False

#End Region

#Region "CONSTRUCTOR"

    Public Sub New(ByVal inIDRE As Integer, ByVal inSECU As Integer, ByVal inNURA As Integer, ByVal stFERA As String)
        inLRPRIDRE = inIDRE
        inLRPRSECU = inSECU
        inLRPRNURA = inNURA
        stLRPRFERA = stFERA

        boMODIFICAR = True

        InitializeComponent()
        pro_LimpiarCampos()
        pro_inicializarControles()

    End Sub
    Public Sub New(ByVal inSECU As Integer, ByVal inNURA As Integer, ByVal stFERA As String)
        inLRPRSECU = inSECU
        inLRPRNURA = inNURA
        stLRPRFERA = stFERA

        boINSERTAR = True

        InitializeComponent()
        pro_LimpiarCampos()
        pro_inicializarControles()
    End Sub

#End Region

#Region "PROCEDIMIENTOS"

    Private Sub pro_LimpiarCampos()

        Me.txtLRPRMUNI.Text = "266"
        Me.txtLRPRCORR.Text = "01"
        Me.txtLRPRBARR.Text = ""
        Me.txtLRPRMANZ.Text = ""
        Me.txtLRPRPRED.Text = ""
        Me.txtLRPREDIF.Text = ""
        Me.txtLRPRUNPR.Text = ""
        Me.txtLRPRMAIN.Text = "0"
        Me.txtLRPRNUFI.Text = "0"
        Me.lblLRPRCLSE.Text = ""

        Me.cboLRPRCLSE.DataSource = New DataTable

    End Sub
    Private Sub pro_inicializarControles()

        Try
            If boMODIFICAR = True Then

                ' instancia la clase
                Dim objdatos As New cla_LIRAPRED
                Dim tbl As New DataTable

                tbl = objdatos.fun_Buscar_ID_LIRAPRED(inLRPRIDRE)

                If tbl.Rows.Count > 0 Then

                    Me.Text = "Modificar registro"
                    Me.fraCEDUCATA.Text = "MODIFICAR PREDIOS"

                    Me.txtLRPRMUNI.Text = Trim(tbl.Rows(0).Item("LRPRMUNI"))
                    Me.txtLRPRCORR.Text = Trim(tbl.Rows(0).Item("LRPRCORR"))
                    Me.txtLRPRBARR.Text = Trim(tbl.Rows(0).Item("LRPRBARR"))
                    Me.txtLRPRMANZ.Text = Trim(tbl.Rows(0).Item("LRPRMANZ"))
                    Me.txtLRPRPRED.Text = Trim(tbl.Rows(0).Item("LRPRPRED"))
                    Me.txtLRPREDIF.Text = Trim(tbl.Rows(0).Item("LRPREDIF"))
                    Me.txtLRPRUNPR.Text = Trim(tbl.Rows(0).Item("LRPRUNPR"))

                    Dim objdatos1 As New cla_CLASSECT

                    Me.cboLRPRCLSE.DataSource = objdatos1.fun_Consultar_CAMPOS_MANT_CLASSECT
                    Me.cboLRPRCLSE.DisplayMember = "CLSEDESC"
                    Me.cboLRPRCLSE.ValueMember = "CLSECODI"

                    Me.cboLRPRCLSE.SelectedValue = tbl.Rows(0).Item("LRPRCLSE")

                    Me.txtLRPRMAIN.Text = Trim(tbl.Rows(0).Item("LRPRMAIN"))
                    Me.txtLRPRNUFI.Text = Trim(tbl.Rows(0).Item("LRPRNUFI"))

                    Me.lblLRPRCLSE.Text = CType(fun_Buscar_Lista_Valores_CLASSECT_Codigo(Me.cboLRPRCLSE), String)

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
                Dim objdatos As New cla_LIRAPRED

                Dim boLLAVEPRIMARIA As Boolean = objdatos.fun_Verifica_llave_Primaria_LIRAPRED(inLRPRNURA, stLRPRFERA, inLRPRSECU, Me.txtLRPRMAIN)

                ' instancia la clase
                Dim objVerifica As New cla_Verificar_Dato

                Dim boLRPRMUNI As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Numerico(Me.txtLRPRMUNI)
                Dim boLRPRCORR As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Numerico(Me.txtLRPRCORR)
                Dim boLRPRBARR As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Numerico(Me.txtLRPRBARR)
                Dim boLRPRMANZ As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Numerico(Me.txtLRPRMANZ)
                Dim boLRPRPRED As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Numerico(Me.txtLRPRPRED)
                Dim boLRPREDIF As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Numerico(Me.txtLRPREDIF)
                Dim boLRPRUNPR As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Numerico(Me.txtLRPRUNPR)
                Dim boLRPRCLSE As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboLRPRCLSE)
                Dim boLRPRMAIN As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Numerico(Me.txtLRPRMAIN)
                Dim boLRPRNUFI As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Numerico(Me.txtLRPRNUFI)

                ' verifica los datos del formulario 
                If boLLAVEPRIMARIA = True And _
                   boLRPRMUNI = True And _
                   boLRPRCORR = True And _
                   boLRPRBARR = True And _
                   boLRPRMANZ = True And _
                   boLRPRPRED = True And _
                   boLRPREDIF = True And _
                   boLRPRUNPR = True And _
                   boLRPRCLSE = True And _
                   boLRPRMAIN = True And _
                   boLRPRNUFI = True Then

                    Dim objdatos22 As New cla_LIRAPRED

                    If (objdatos22.fun_Insertar_LIRAPRED(inLRPRNURA, _
                                                         stLRPRFERA, _
                                                         inLRPRSECU, _
                                                         Me.txtLRPRMAIN.Text, _
                                                         Me.txtLRPRMUNI.Text, _
                                                         Me.txtLRPRCORR.Text, _
                                                         Me.txtLRPRBARR.Text, _
                                                         Me.txtLRPRMANZ.Text, _
                                                         Me.txtLRPRPRED.Text, _
                                                         Me.txtLRPREDIF.Text, _
                                                         Me.txtLRPRUNPR.Text, _
                                                         Me.cboLRPRCLSE.SelectedValue, _
                                                         Me.txtLRPRNUFI.Text)) = True Then

                        mod_MENSAJE.Se_Guardaron_Los_Datos_Correctamente()

                        If MessageBox.Show("¿ Desea agregar otro registro ?", "Mensaje...", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.No Then
                            Me.txtLRPRMUNI.Focus()
                            Me.Close()
                        Else
                            pro_LimpiarCampos()
                            Me.txtLRPRMUNI.Focus()
                        End If
                    Else
                        mod_MENSAJE.No_Se_Guardo_El_Registro_En_La_Base_De_Datos()
                    End If

                End If

                ' modifica el registro
            ElseIf boMODIFICAR = True Then

                ' instancia la clase
                Dim objVerifica As New cla_Verificar_Dato

                Dim boLRPRMUNI As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Numerico(Me.txtLRPRMUNI)
                Dim boLRPRCORR As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Numerico(Me.txtLRPRCORR)
                Dim boLRPRBARR As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Numerico(Me.txtLRPRBARR)
                Dim boLRPRMANZ As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Numerico(Me.txtLRPRMANZ)
                Dim boLRPRPRED As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Numerico(Me.txtLRPRPRED)
                Dim boLRPREDIF As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Numerico(Me.txtLRPREDIF)
                Dim boLRPRUNPR As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Numerico(Me.txtLRPRUNPR)
                Dim boLRPRCLSE As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboLRPRCLSE)
                Dim boLRPRMAIN As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Numerico(Me.txtLRPRMAIN)
                Dim boLRPRNUFI As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Numerico(Me.txtLRPRNUFI)

                ' verifica los datos del formulario 
                If boLRPRMUNI = True And _
                   boLRPRCORR = True And _
                   boLRPRBARR = True And _
                   boLRPRMANZ = True And _
                   boLRPRPRED = True And _
                   boLRPREDIF = True And _
                   boLRPRUNPR = True And _
                   boLRPRCLSE = True And _
                   boLRPRMAIN = True And _
                   boLRPRNUFI = True Then

                    Dim objdatos22 As New cla_LIRAPRED

                    If (objdatos22.fun_Actualizar_LIRAPRED(inLRPRIDRE, _
                                                           inLRPRNURA, _
                                                           stLRPRFERA, _
                                                           inLRPRSECU, _
                                                           Me.txtLRPRMAIN.Text, _
                                                           Me.txtLRPRMUNI.Text, _
                                                           Me.txtLRPRCORR.Text, _
                                                           Me.txtLRPRBARR.Text, _
                                                           Me.txtLRPRMANZ.Text, _
                                                           Me.txtLRPRPRED.Text, _
                                                           Me.txtLRPREDIF.Text, _
                                                           Me.txtLRPRUNPR.Text, _
                                                           Me.cboLRPRCLSE.SelectedValue, _
                                                           Me.txtLRPRNUFI.Text)) = True Then

                        mod_MENSAJE.Se_Guardaron_Los_Datos_Correctamente()
                        Me.txtLRPRMUNI.Focus()
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
        Me.txtLRPRMUNI.Focus()
        Me.Close()
    End Sub

#End Region

#Region "FORMULARIO"

#Region "KeyPress"

    Private Sub txt_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtLRPRMUNI.KeyPress, txtLRPRCORR.KeyPress, txtLRPRBARR.KeyPress, txtLRPRMANZ.KeyPress, txtLRPRPRED.KeyPress, txtLRPRMAIN.KeyPress, txtLRPRNUFI.KeyPress, cboLRPRCLSE.KeyPress, txtLRPREDIF.KeyPress, txtLRPRUNPR.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Or e.KeyChar = Convert.ToChar(Keys.Tab) Then
            pp_pro_SaltarCampo()
        End If
    End Sub

#End Region

#Region "KeyDown"

    Private Sub cboOBINCLSE_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboLRPRCLSE.KeyDown
        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
            fun_Cargar_ComboBox_Con_Datos_Activos_CLASSECT_Descripcion(Me.cboLRPRCLSE, Me.cboLRPRCLSE.SelectedIndex)
        End If
    End Sub

#End Region

#Region "SelectedIndexChanged"

    Private Sub cboOBINCLSE_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboLRPRCLSE.SelectedIndexChanged
        Me.lblLRPRCLSE.Text = CType(fun_Buscar_Lista_Valores_CLASSECT_Codigo(Me.cboLRPRCLSE), String)
    End Sub

#End Region

#Region "Click"

    Private Sub cboOBINCLSE_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboLRPRCLSE.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_CLASSECT_Descripcion(Me.cboLRPRCLSE, Me.cboLRPRCLSE.SelectedIndex)
    End Sub

#End Region

#Region "GotFocus"

    Private Sub txt_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtLRPRMUNI.GotFocus, txtLRPRCORR.GotFocus, txtLRPRBARR.GotFocus, txtLRPRMANZ.GotFocus, txtLRPRPRED.GotFocus, txtLRPRMAIN.GotFocus, txtLRPRNUFI.GotFocus, txtLRPREDIF.GotFocus, txtLRPRUNPR.GotFocus
        pp_pro_SobrearCampo(sender)
        pp_pro_DescripcionCampo(Me.strBARRESTA.Items(0), sender)
    End Sub
    Private Sub cmd_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdGUARDAR.GotFocus, cmdSALIR.GotFocus
        pp_pro_DescripcionCampo(Me.strBARRESTA.Items(0), sender)
    End Sub

#End Region

#Region "Validated"

    Private Sub txtLRPRMAIN_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtLRPRMAIN.Validated, txtLRPRNUFI.Validated

        If Trim(sender.text) = "" Then
            sender.text = 0
        End If

    End Sub
    Private Sub txtTRCAMUNI_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtLRPRMUNI.Validated
        If Me.txtLRPRMUNI.Text <> "" And fun_Verificar_Dato_Numerico_Evento_Validated(Me.txtLRPRMUNI.Text) = True Then
            Me.txtLRPRMUNI.Text = fun_Formato_Mascara_3_String(Me.txtLRPRMUNI.Text)
        End If
    End Sub
    Private Sub txtTRCACORR_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtLRPRCORR.Validated
        If Me.txtLRPRCORR.Text <> "" And fun_Verificar_Dato_Numerico_Evento_Validated(Me.txtLRPRCORR.Text) = True Then
            Me.txtLRPRCORR.Text = fun_Formato_Mascara_2_String(Me.txtLRPRCORR.Text)
        End If
    End Sub
    Private Sub txtTRCABARR_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtLRPRBARR.Validated
        If Me.txtLRPRBARR.Text <> "" And fun_Verificar_Dato_Numerico_Evento_Validated(Me.txtLRPRBARR.Text) = True Then
            Me.txtLRPRBARR.Text = fun_Formato_Mascara_3_String(Me.txtLRPRBARR.Text)
        End If
    End Sub
    Private Sub txtTRCAMANZ_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtLRPRMANZ.Validated
        If Me.txtLRPRMANZ.Text <> "" And fun_Verificar_Dato_Numerico_Evento_Validated(Me.txtLRPRMANZ.Text) = True Then
            Me.txtLRPRMANZ.Text = fun_Formato_Mascara_3_String(Me.txtLRPRMANZ.Text)
        End If
    End Sub
    Private Sub txtTRCAPRED_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtLRPRPRED.Validated
        If Me.txtLRPRPRED.Text <> "" And fun_Verificar_Dato_Numerico_Evento_Validated(Me.txtLRPRPRED.Text) = True Then
            Me.txtLRPRPRED.Text = fun_Formato_Mascara_5_String(Me.txtLRPRPRED.Text)
        End If
    End Sub
    Private Sub txtLRPREDIF_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtLRPREDIF.Validated
        If Me.txtLRPREDIF.Text <> "" And fun_Verificar_Dato_Numerico_Evento_Validated(Me.txtLRPREDIF.Text) = True Then
            Me.txtLRPREDIF.Text = fun_Formato_Mascara_3_String(Me.txtLRPREDIF.Text)
        End If
    End Sub
    Private Sub txtLRPRUNPR_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtLRPRUNPR.Validated
        If Me.txtLRPRUNPR.Text <> "" And fun_Verificar_Dato_Numerico_Evento_Validated(Me.txtLRPRUNPR.Text) = True Then
            Me.txtLRPRUNPR.Text = fun_Formato_Mascara_5_String(Me.txtLRPRUNPR.Text)
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