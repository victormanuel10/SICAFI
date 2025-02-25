Imports REGLAS_DEL_NEGOCIO

Public Class frm_insertar_REAVPRAF

    '===========================================
    '*** INSERTAR PREDIOS AFECTADOS RECLAMOS ***
    '===========================================

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

        Me.txtRAPAMUNI.Text = "266"
        Me.txtRAPACORR.Text = "01"
        Me.txtRAPABARR.Text = ""
        Me.txtRAPAMANZ.Text = ""
        Me.txtRAPAPRED.Text = ""
        Me.txtRAPAEDIF.Text = ""
        Me.txtRAPAUNPR.Text = ""

    End Sub
    Private Sub pro_inicializarControles()

        Try
            If boMODIFICAR = True Then

                ' instancia la clase
                Dim objdatos As New cla_REAVPRAF
                Dim tbl As New DataTable

                tbl = objdatos.fun_Buscar_CODIGO_X_REAVPRAF(inLEVASECU, inID_REGISTRO)

                If tbl.Rows.Count > 0 Then

                    Me.Text = "Modificar registro"
                    Me.fraCEDUCATA.Text = "MODIFICAR CEDULA CATASTRAL "

                    Dim objdatos1 As New cla_USUARIO

                    Me.txtRAPAMUNI.Text = Trim(tbl.Rows(0).Item("RAPAMUNI"))
                    Me.txtRAPACORR.Text = Trim(tbl.Rows(0).Item("RAPACORR"))
                    Me.txtRAPABARR.Text = Trim(tbl.Rows(0).Item("RAPABARR"))
                    Me.txtRAPAMANZ.Text = Trim(tbl.Rows(0).Item("RAPAMANZ"))
                    Me.txtRAPAPRED.Text = Trim(tbl.Rows(0).Item("RAPAPRED"))
                    Me.txtRAPAEDIF.Text = Trim(tbl.Rows(0).Item("RAPAEDIF"))
                    Me.txtRAPAUNPR.Text = Trim(tbl.Rows(0).Item("RAPAUNPR"))

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

                Dim boRAPAMUNI As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.txtRAPAMUNI)
                Dim boRAPACORR As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.txtRAPACORR)
                Dim boRAPABARR As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.txtRAPABARR)
                Dim boRAPAMANZ As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.txtRAPAMANZ)
                Dim boRAPAPRED As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.txtRAPAPRED)
                Dim boRAPAEDIF As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.txtRAPAEDIF)
                Dim boRAPAUNPR As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.txtRAPAUNPR)

                ' verifica los datos del formulario 
                If boRAPAMUNI = True And _
                   boRAPACORR = True And _
                   boRAPABARR = True And _
                   boRAPAMANZ = True And _
                   boRAPAPRED = True And _
                   boRAPAEDIF = True And _
                   boRAPAUNPR = True Then

                    Dim objdatos22 As New cla_REAVPRAF

                    If (objdatos22.fun_Insertar_REAVPRAF(inLEVASECU, _
                                                         Me.txtRAPAMUNI.Text, _
                                                         Me.txtRAPACORR.Text, _
                                                         Me.txtRAPABARR.Text, _
                                                         Me.txtRAPAMANZ.Text, _
                                                         Me.txtRAPAPRED.Text, _
                                                         Me.txtRAPAEDIF.Text, _
                                                         Me.txtRAPAUNPR.Text)) = True Then

                        mod_MENSAJE.Se_Guardaron_Los_Datos_Correctamente()

                        If MessageBox.Show("¿ Desea agregar otro registro ?", "Mensaje...", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.No Then
                            Me.txtRAPAMUNI.Focus()
                            Me.Close()
                        Else
                            pro_LimpiarCampos()
                            Me.txtRAPAMUNI.Focus()
                        End If
                    Else
                        mod_MENSAJE.No_Se_Guardo_El_Registro_En_La_Base_De_Datos()
                    End If

                End If

                ' modifica el registro
            ElseIf boMODIFICAR = True Then

                ' instancia la clase
                Dim objVerifica As New cla_Verificar_Dato

                Dim boRAPAMUNI As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.txtRAPAMUNI)
                Dim boRAPACORR As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.txtRAPACORR)
                Dim boRAPABARR As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.txtRAPABARR)
                Dim boRAPAMANZ As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.txtRAPAMANZ)
                Dim boRAPAPRED As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.txtRAPAPRED)
                Dim boRAPAEDIF As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.txtRAPAEDIF)
                Dim boRAPAUNPR As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.txtRAPAUNPR)

                ' verifica los datos del formulario 
                If boRAPAMUNI = True And _
                   boRAPACORR = True And _
                   boRAPABARR = True And _
                   boRAPAMANZ = True And _
                   boRAPAPRED = True And _
                   boRAPAEDIF = True And _
                   boRAPAUNPR = True Then

                    Dim objdatos22 As New cla_REAVPRAF

                    If (objdatos22.fun_Actualizar_REAVPRAF(inID_REGISTRO, _
                                                                inLEVASECU, _
                                                                Me.txtRAPAMUNI.Text, _
                                                                Me.txtRAPACORR.Text, _
                                                                Me.txtRAPABARR.Text, _
                                                                Me.txtRAPAMANZ.Text, _
                                                                Me.txtRAPAPRED.Text, _
                                                                Me.txtRAPAEDIF.Text, _
                                                                Me.txtRAPAUNPR.Text)) = True Then

                        mod_MENSAJE.Se_Guardaron_Los_Datos_Correctamente()
                        Me.txtRAPAMUNI.Focus()
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
        Me.txtRAPAMUNI.Focus()
        Me.Close()
    End Sub

#End Region

#Region "FORMULARIO"

#Region "KeyPress"

    Private Sub txt_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtRAPAMUNI.KeyPress, txtRAPACORR.KeyPress, txtRAPABARR.KeyPress, txtRAPAMANZ.KeyPress, txtRAPAPRED.KeyPress, txtRAPAEDIF.KeyPress, txtRAPAUNPR.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Or e.KeyChar = Convert.ToChar(Keys.Tab) Then
            pp_pro_SaltarCampo()
        End If
    End Sub

#End Region

#Region "GotFocus"

    Private Sub txt_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtRAPAMUNI.GotFocus, txtRAPACORR.GotFocus, txtRAPABARR.GotFocus, txtRAPAMANZ.GotFocus, txtRAPAPRED.GotFocus, txtRAPAEDIF.GotFocus, txtRAPAUNPR.GotFocus
        pp_pro_SobrearCampo(sender)
        pp_pro_DescripcionCampo(Me.strBARRESTA.Items(0), sender)
    End Sub
    Private Sub cmd_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdGUARDAR.GotFocus, cmdSALIR.GotFocus
        pp_pro_DescripcionCampo(Me.strBARRESTA.Items(0), sender)
    End Sub

#End Region

#Region "Validated"

    Private Sub txtTRCAMUNI_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtRAPAMUNI.Validated
        If Me.txtRAPAMUNI.Text <> "" And fun_Verificar_Dato_Numerico_Evento_Validated(Me.txtRAPAMUNI.Text) = True Then
            Me.txtRAPAMUNI.Text = fun_Formato_Mascara_3_String(Me.txtRAPAMUNI.Text)
        End If
    End Sub
    Private Sub txtTRCACORR_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtRAPACORR.Validated
        If Me.txtRAPACORR.Text <> "" And fun_Verificar_Dato_Numerico_Evento_Validated(Me.txtRAPACORR.Text) = True Then
            Me.txtRAPACORR.Text = fun_Formato_Mascara_2_String(Me.txtRAPACORR.Text)
        End If
    End Sub
    Private Sub txtTRCABARR_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtRAPABARR.Validated
        If Me.txtRAPABARR.Text <> "" And fun_Verificar_Dato_Numerico_Evento_Validated(Me.txtRAPABARR.Text) = True Then
            Me.txtRAPABARR.Text = fun_Formato_Mascara_3_String(Me.txtRAPABARR.Text)
        End If
    End Sub
    Private Sub txtTRCAMANZ_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtRAPAMANZ.Validated
        If Me.txtRAPAMANZ.Text <> "" And fun_Verificar_Dato_Numerico_Evento_Validated(Me.txtRAPAMANZ.Text) = True Then
            Me.txtRAPAMANZ.Text = fun_Formato_Mascara_3_String(Me.txtRAPAMANZ.Text)
        End If
    End Sub
    Private Sub txtTRCAPRED_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtRAPAPRED.Validated
        If Me.txtRAPAPRED.Text <> "" And fun_Verificar_Dato_Numerico_Evento_Validated(Me.txtRAPAPRED.Text) = True Then
            Me.txtRAPAPRED.Text = fun_Formato_Mascara_5_String(Me.txtRAPAPRED.Text)
        End If
    End Sub
    Private Sub txtRECLEDIF_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtRAPAEDIF.Validated
        If Me.txtRAPAEDIF.Text <> "" And fun_Verificar_Dato_Numerico_Evento_Validated(Me.txtRAPAEDIF.Text) = True Then
            Me.txtRAPAEDIF.Text = fun_Formato_Mascara_3_String(Me.txtRAPAEDIF.Text)
        End If
    End Sub
    Private Sub txtRECLUNPR_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtRAPAUNPR.Validated
        If Me.txtRAPAUNPR.Text <> "" And fun_Verificar_Dato_Numerico_Evento_Validated(Me.txtRAPAUNPR.Text) = True Then
            Me.txtRAPAUNPR.Text = fun_Formato_Mascara_5_String(Me.txtRAPAUNPR.Text)
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