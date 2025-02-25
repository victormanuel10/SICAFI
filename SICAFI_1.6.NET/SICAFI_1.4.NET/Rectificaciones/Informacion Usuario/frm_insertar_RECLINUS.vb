Imports REGLAS_DEL_NEGOCIO

Public Class frm_insertar_RECLINUS

    '========================================
    '*** INSERTAR INFORMACIÓN DEL USUARIO ***
    '========================================

#Region "VARIABLE"

    Dim inID_REGISTRO As Integer
    Dim inINUSSECU As Integer

    Dim boINSERTAR As Boolean = False
    Dim boMODIFICAR As Boolean = False

#End Region

#Region "CONSTRUCTOR"

    Public Sub New(ByVal inIDRE As Integer)
        inID_REGISTRO = inIDRE
        inINUSSECU = inIDRE

        InitializeComponent()
        pro_LimpiarCampos()
        pro_inicializarControles()
    End Sub
    Public Sub New(ByVal inIDRE As Integer, ByVal inSECU As Integer)
        inID_REGISTRO = inIDRE
        inINUSSECU = inSECU

        InitializeComponent()
        pro_LimpiarCampos()
        pro_inicializarControles()
    End Sub

#End Region

#Region "PROCEDIMIENTOS"

    Private Sub pro_LimpiarCampos()

        Me.txtREIUDIPR.Text = ""
        Me.txtREIUDINO.Text = ""
        Me.txtREIUTEL1.Text = ""
        Me.txtREIUTEL2.Text = ""
        Me.chkREIUACTA.Checked = False
        Me.chkREIUACFI.Checked = False
        Me.txtREIUNOMB.Text = ""
        Me.txtREIUPRAP.Text = ""
        Me.txtREIUSEAP.Text = ""
        Me.txtREIUTEL1.Text = ""
        Me.txtREIUTEL2.Text = ""
        Me.txtREIUFEEN.Text = ""
        Me.txtREIUFERE.Text = ""
        Me.nudREIUNUAC.Value = 0
        Me.txtREIUOBSE.Text = ""

    End Sub
    Private Sub pro_inicializarControles()

        Try
            With Me.nudREIUNUAC
                .Maximum = 100 ' valor máximo   
                .Minimum = 0 ' minimo  
                .Value = 0
                .Increment = 1
            End With

            ' instancia la clase
            Dim objdatos As New cla_RECLINUS
            Dim tbl As New DataTable

            tbl = objdatos.fun_Consultar_RECLINUS(inINUSSECU)

            If tbl.Rows.Count > 0 Then
                boMODIFICAR = True

                Me.Text = "Modificar registro"
                Me.fraINFOUSUA.Text = "MODIFICAR INFORMACIÓN DEL USUARIO"

                Me.txtREIUDIPR.Text = CStr(Trim(tbl.Rows(0).Item("REIUDIPR")))
                Me.txtREIUDINO.Text = CStr(Trim(tbl.Rows(0).Item("REIUDINO")))
                Me.txtREIUTEL1.Text = CStr(Trim(tbl.Rows(0).Item("REIUTEL1")))
                Me.txtREIUTEL2.Text = CStr(Trim(tbl.Rows(0).Item("REIUTEL2")))
                Me.chkREIUACTA.Checked = CBool(tbl.Rows(0).Item("REIUACTA"))
                Me.chkREIUACFI.Checked = CBool(tbl.Rows(0).Item("REIUACFI"))
                Me.nudREIUNUAC.Value = CInt(tbl.Rows(0).Item("REIUNUAC"))
                Me.txtREIUNOMB.Text = CStr(Trim(tbl.Rows(0).Item("REIUNOMB")))
                Me.txtREIUPRAP.Text = CStr(Trim(tbl.Rows(0).Item("REIUPRAP")))
                Me.txtREIUSEAP.Text = CStr(Trim(tbl.Rows(0).Item("REIUSEAP")))
                Me.txtREIUTEL1.Text = CStr(Trim(tbl.Rows(0).Item("REIUTEL1")))
                Me.txtREIUTEL2.Text = CStr(Trim(tbl.Rows(0).Item("REIUTEL2")))
                Me.txtREIUFEEN.Text = CStr(Trim(tbl.Rows(0).Item("REIUFEEN")))
                Me.txtREIUFERE.Text = CStr(Trim(tbl.Rows(0).Item("REIUFERE")))
                Me.txtREIUOBSE.Text = CStr(Trim(tbl.Rows(0).Item("REIUOBSE")))

                If fun_Verificar_Dato_Fecha_Evento_Validated(Me.txtREIUFEEN.Text) = True Then
                    Me.dtpREIUFEEN.Value = CDate(tbl.Rows(0).Item("REIUFEEN"))
                End If

                If fun_Verificar_Dato_Fecha_Evento_Validated(Me.txtREIUFERE.Text) = True Then
                    Me.dtpREIUFERE.Value = CDate(tbl.Rows(0).Item("REIUFERE"))
                End If

            Else
                boINSERTAR = True

                Me.Text = "Insertar registro"
                Me.fraINFOUSUA.Text = "INSERTAR INFORMACIÓN DEL USUARIO"

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

                Dim boINUSNOMB As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.txtREIUNOMB)

                ' verifica los datos del formulario 
                If boINUSNOMB = True Then

                    Dim objdatos22 As New cla_RECLINUS

                    If (objdatos22.fun_Insertar_RECLINUS(inINUSSECU, _
                                                         Me.txtREIUDIPR.Text, _
                                                         Me.txtREIUDINO.Text, _
                                                         Me.txtREIUNOMB.Text, _
                                                         Me.txtREIUPRAP.Text, _
                                                         Me.txtREIUSEAP.Text, _
                                                         Me.txtREIUTEL1.Text, _
                                                         Me.txtREIUTEL2.Text, _
                                                         Me.chkREIUACTA.Checked, _
                                                         Me.nudREIUNUAC.Value, _
                                                         Me.chkREIUACFI.Checked, _
                                                         Me.txtREIUFEEN.Text, _
                                                         Me.txtREIUFERE.Text, _
                                                         Me.txtREIUOBSE.Text)) = True Then

                        mod_MENSAJE.Se_Guardaron_Los_Datos_Correctamente()
                        Me.chkREIUACTA.Focus()
                        Me.Close()
                    Else
                        mod_MENSAJE.No_Se_Guardo_El_Registro_En_La_Base_De_Datos()
                    End If

                End If

                ' modifica el registro
            ElseIf boMODIFICAR = True Then

                ' instancia la clase
                Dim objVerifica As New cla_Verificar_Dato

                Dim boINUSNOMB As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.txtREIUNOMB)

                ' verifica los datos del formulario 
                If boINUSNOMB = True Then

                    Dim objdatos22 As New cla_RECLINUS

                    If (objdatos22.fun_Actualizar_SECU_X_RECLINUS(inINUSSECU, _
                                                                  Me.txtREIUDIPR.Text, _
                                                                  Me.txtREIUDINO.Text, _
                                                                  Me.txtREIUNOMB.Text, _
                                                                  Me.txtREIUPRAP.Text, _
                                                                  Me.txtREIUSEAP.Text, _
                                                                  Me.txtREIUTEL1.Text, _
                                                                  Me.txtREIUTEL2.Text, _
                                                                  Me.chkREIUACTA.Checked, _
                                                                  Me.nudREIUNUAC.Value, _
                                                                  Me.chkREIUACFI.Checked, _
                                                                  Me.txtREIUFEEN.Text, _
                                                                  Me.txtREIUFERE.Text, _
                                                                  Me.txtREIUOBSE.Text)) = True Then

                        mod_MENSAJE.Se_Guardaron_Los_Datos_Correctamente()
                        Me.chkREIUACTA.Focus()
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
        Me.chkREIUACTA.Focus()
        Me.Close()
    End Sub

#End Region

#Region "FORMULARIO"

#Region "KeyPress"

    Private Sub txt_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles chkREIUACTA.KeyPress, chkREIUACFI.KeyPress, nudREIUNUAC.KeyPress, txtREIUNOMB.KeyPress, txtREIUPRAP.KeyPress, txtREIUSEAP.KeyPress, txtREIUDIPR.KeyPress, txtREIUDINO.KeyPress, txtREIUTEL1.KeyPress, txtREIUTEL2.KeyPress, txtREIUFEEN.KeyPress, txtREIUFERE.KeyPress, txtREIUOBSE.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Or e.KeyChar = Convert.ToChar(Keys.Tab) Then
            pp_pro_SaltarCampo()
        End If
    End Sub

#End Region

#Region "GotFocus"

    Private Sub txt_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtREIUNOMB.GotFocus, txtREIUPRAP.GotFocus, txtREIUSEAP.GotFocus, txtREIUDIPR.GotFocus, txtREIUDINO.GotFocus, txtREIUTEL1.GotFocus, txtREIUTEL2.GotFocus, txtREIUFEEN.GotFocus, txtREIUFERE.GotFocus, txtREIUOBSE.GotFocus
        pp_pro_SobrearCampo(sender)
        pp_pro_DescripcionCampo(Me.strBARRESTA.Items(0), sender)
    End Sub
    Private Sub cmd_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdGUARDAR.GotFocus, cmdSALIR.GotFocus
        pp_pro_DescripcionCampo(Me.strBARRESTA.Items(0), sender)
    End Sub
    Private Sub chk_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkREIUACTA.GotFocus, chkREIUACFI.GotFocus
        pp_pro_DescripcionCampo(Me.strBARRESTA.Items(0), sender)
    End Sub
    Private Sub nud_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles nudREIUNUAC.GotFocus
        pp_pro_DescripcionCampo(Me.strBARRESTA.Items(0), sender)
    End Sub

#End Region

#Region "ValueChanged"

    Private Sub dtpINUSFEEN_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpREIUFEEN.ValueChanged
        Me.txtREIUFEEN.Text = Me.dtpREIUFEEN.Value
    End Sub
    Private Sub dtpINUSFERE_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpREIUFERE.ValueChanged
        Me.txtREIUFERE.Text = Me.dtpREIUFERE.Value
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