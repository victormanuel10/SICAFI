Imports REGLAS_DEL_NEGOCIO

Public Class frm_insertar_RECLPRAF

    '==================================
    '*** PREDIOS AFECTADOS RECLAMOS ***
    '==================================

#Region "VARIABLE"

    Dim inID_REGISTRO As Integer
    Dim inLEVASECU As Integer

    Dim boINSERTAR As Boolean = False
    Dim boMODIFICAR As Boolean = False

#End Region

#Region "CONSTRUCTOR"

    Public Sub New(ByVal inSECU As Integer)
        inLEVASECU = inSECU

        boINSERTAR = True

        InitializeComponent()
        pro_LimpiarCampos()
        pro_inicializarControles()
    End Sub
    Public Sub New(ByVal inIDRE As Integer, ByVal inSECU As Integer)
        inID_REGISTRO = inIDRE
        inLEVASECU = inSECU

        boMODIFICAR = True

        InitializeComponent()
        pro_LimpiarCampos()
        pro_inicializarControles()
    End Sub

#End Region

#Region "PROCEDIMIENTOS"

    Private Sub pro_LimpiarCampos()

        Me.txtREPAMUNI.Text = "266"
        Me.txtREPACORR.Text = "01"
        Me.txtREPABARR.Text = ""
        Me.txtREPAMANZ.Text = ""
        Me.txtREPAPRED.Text = ""
        Me.txtREPAEDIF.Text = ""
        Me.txtREPAUNPR.Text = ""

    End Sub
    Private Sub pro_inicializarControles()

        Try
            If boMODIFICAR = True Then

                ' instancia la clase
                Dim objdatos As New cla_RECLPRAF
                Dim tbl As New DataTable

                tbl = objdatos.fun_Buscar_CODIGO_X_RECLPRAF(inLEVASECU, inID_REGISTRO)

                If tbl.Rows.Count > 0 Then

                    Me.Text = "Modificar registro"
                    Me.fraCEDUCATA.Text = "MODIFICAR CEDULA CATASTRAL "

                    Dim objdatos1 As New cla_USUARIO

                    Me.txtREPAMUNI.Text = Trim(tbl.Rows(0).Item("REPAMUNI"))
                    Me.txtREPACORR.Text = Trim(tbl.Rows(0).Item("REPACORR"))
                    Me.txtREPABARR.Text = Trim(tbl.Rows(0).Item("REPABARR"))
                    Me.txtREPAMANZ.Text = Trim(tbl.Rows(0).Item("REPAMANZ"))
                    Me.txtREPAPRED.Text = Trim(tbl.Rows(0).Item("REPAPRED"))
                    Me.txtREPAEDIF.Text = Trim(tbl.Rows(0).Item("REPAEDIF"))
                    Me.txtREPAUNPR.Text = Trim(tbl.Rows(0).Item("REPAUNPR"))

                Else
                    boINSERTAR = True

                    Me.Text = "Insertar registro"
                    Me.fraCEDUCATA.Text = "INSERTAR CEDULA CATASTRAL"

                End If

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
                Dim objVerifica As New cla_Verificar_Dato

                Dim boREPAMUNI As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.txtREPAMUNI)
                Dim boREPACORR As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.txtREPACORR)
                Dim boREPABARR As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.txtREPABARR)
                Dim boREPAMANZ As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.txtREPAMANZ)
                Dim boREPAPRED As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.txtREPAPRED)
                Dim boREPAEDIF As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.txtREPAEDIF)
                Dim boREPAUNPR As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.txtREPAUNPR)

                ' verifica los datos del formulario 
                If boREPAMUNI = True And _
                   boREPACORR = True And _
                   boREPABARR = True And _
                   boREPAMANZ = True And _
                   boREPAPRED = True And _
                   boREPAEDIF = True And _
                   boREPAUNPR = True Then

                    Dim objdatos22 As New cla_RECLPRAF

                    If (objdatos22.fun_Insertar_RECLPRAF(inLEVASECU, _
                                                         Me.txtREPAMUNI.Text, _
                                                         Me.txtREPACORR.Text, _
                                                         Me.txtREPABARR.Text, _
                                                         Me.txtREPAMANZ.Text, _
                                                         Me.txtREPAPRED.Text, _
                                                         Me.txtREPAEDIF.Text, _
                                                         Me.txtREPAUNPR.Text)) = True Then

                        mod_MENSAJE.Se_Guardaron_Los_Datos_Correctamente()

                        If MessageBox.Show("¿ Desea agregar otro registro ?", "Mensaje...", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.No Then
                            Me.txtREPAMUNI.Focus()
                            Me.Close()
                        Else
                            pro_LimpiarCampos()
                            Me.txtREPAMUNI.Focus()
                        End If
                    Else
                        mod_MENSAJE.No_Se_Guardo_El_Registro_En_La_Base_De_Datos()
                    End If

                End If

                ' modifica el registro
            ElseIf boMODIFICAR = True Then

                ' instancia la clase
                Dim objVerifica As New cla_Verificar_Dato

                Dim boREPAMUNI As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.txtREPAMUNI)
                Dim boREPACORR As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.txtREPACORR)
                Dim boREPABARR As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.txtREPABARR)
                Dim boREPAMANZ As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.txtREPAMANZ)
                Dim boREPAPRED As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.txtREPAPRED)
                Dim boREPAEDIF As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.txtREPAEDIF)
                Dim boREPAUNPR As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.txtREPAUNPR)

                ' verifica los datos del formulario 
                If boREPAMUNI = True And _
                   boREPACORR = True And _
                   boREPABARR = True And _
                   boREPAMANZ = True And _
                   boREPAPRED = True And _
                   boREPAEDIF = True And _
                   boREPAUNPR = True Then

                    Dim objdatos22 As New cla_RECLPRAF

                    If (objdatos22.fun_Actualizar_RECLPRAF(inID_REGISTRO, _
                                                                inLEVASECU, _
                                                                Me.txtREPAMUNI.Text, _
                                                                Me.txtREPACORR.Text, _
                                                                Me.txtREPABARR.Text, _
                                                                Me.txtREPAMANZ.Text, _
                                                                Me.txtREPAPRED.Text, _
                                                                Me.txtREPAEDIF.Text, _
                                                                Me.txtREPAUNPR.Text)) = True Then

                        mod_MENSAJE.Se_Guardaron_Los_Datos_Correctamente()
                        Me.txtREPAMUNI.Focus()
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
        Me.txtREPAMUNI.Focus()
        Me.Close()
    End Sub

#End Region

#Region "FORMULARIO"

#Region "KeyPress"

    Private Sub txt_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtREPAMUNI.KeyPress, txtREPACORR.KeyPress, txtREPABARR.KeyPress, txtREPAMANZ.KeyPress, txtREPAPRED.KeyPress, txtREPAEDIF.KeyPress, txtREPAUNPR.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Or e.KeyChar = Convert.ToChar(Keys.Tab) Then
            pp_pro_SaltarCampo()
        End If
    End Sub

#End Region

#Region "GotFocus"

    Private Sub txt_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtREPAMUNI.GotFocus, txtREPACORR.GotFocus, txtREPABARR.GotFocus, txtREPAMANZ.GotFocus, txtREPAPRED.GotFocus, txtREPAEDIF.GotFocus, txtREPAUNPR.GotFocus
        pp_pro_SobrearCampo(sender)
        pp_pro_DescripcionCampo(Me.strBARRESTA.Items(0), sender)
    End Sub
    Private Sub cmd_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdGUARDAR.GotFocus, cmdSALIR.GotFocus
        pp_pro_DescripcionCampo(Me.strBARRESTA.Items(0), sender)
    End Sub

#End Region

#Region "Validated"

    Private Sub txtTRCAMUNI_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtREPAMUNI.Validated
        If Me.txtREPAMUNI.Text <> "" And fun_Verificar_Dato_Numerico_Evento_Validated(Me.txtREPAMUNI.Text) = True Then
            Me.txtREPAMUNI.Text = fun_Formato_Mascara_3_String(Me.txtREPAMUNI.Text)
        End If
    End Sub
    Private Sub txtTRCACORR_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtREPACORR.Validated
        If Me.txtREPACORR.Text <> "" And fun_Verificar_Dato_Numerico_Evento_Validated(Me.txtREPACORR.Text) = True Then
            Me.txtREPACORR.Text = fun_Formato_Mascara_2_String(Me.txtREPACORR.Text)
        End If
    End Sub
    Private Sub txtTRCABARR_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtREPABARR.Validated
        If Me.txtREPABARR.Text <> "" And fun_Verificar_Dato_Numerico_Evento_Validated(Me.txtREPABARR.Text) = True Then
            Me.txtREPABARR.Text = fun_Formato_Mascara_3_String(Me.txtREPABARR.Text)
        End If
    End Sub
    Private Sub txtTRCAMANZ_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtREPAMANZ.Validated
        If Me.txtREPAMANZ.Text <> "" And fun_Verificar_Dato_Numerico_Evento_Validated(Me.txtREPAMANZ.Text) = True Then
            Me.txtREPAMANZ.Text = fun_Formato_Mascara_3_String(Me.txtREPAMANZ.Text)
        End If
    End Sub
    Private Sub txtTRCAPRED_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtREPAPRED.Validated
        If Me.txtREPAPRED.Text <> "" And fun_Verificar_Dato_Numerico_Evento_Validated(Me.txtREPAPRED.Text) = True Then
            Me.txtREPAPRED.Text = fun_Formato_Mascara_5_String(Me.txtREPAPRED.Text)
        End If
    End Sub
    Private Sub txtRECLEDIF_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtREPAEDIF.Validated
        If Me.txtREPAEDIF.Text <> "" And fun_Verificar_Dato_Numerico_Evento_Validated(Me.txtREPAEDIF.Text) = True Then
            Me.txtREPAEDIF.Text = fun_Formato_Mascara_3_String(Me.txtREPAEDIF.Text)
        End If
    End Sub
    Private Sub txtRECLUNPR_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtREPAUNPR.Validated
        If Me.txtREPAUNPR.Text <> "" And fun_Verificar_Dato_Numerico_Evento_Validated(Me.txtREPAUNPR.Text) = True Then
            Me.txtREPAUNPR.Text = fun_Formato_Mascara_5_String(Me.txtREPAUNPR.Text)
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