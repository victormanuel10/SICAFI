Imports REGLAS_DEL_NEGOCIO

Public Class frm_insertar_REAVINUS

    '===========================================================
    '*** INSERTAR INFORMACIÓN DEL USUARIO REVISION DE AVALUO ***
    '===========================================================

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

        Me.txtRAIUDIPR.Text = ""
        Me.txtRAIUDINO.Text = ""
        Me.txtRAIUTEL1.Text = ""
        Me.txtRAIUTEL2.Text = ""
        Me.chkRAIUACTA.Checked = False
        Me.chkRAIUACFI.Checked = False
        Me.txtRAIUNOMB.Text = ""
        Me.txtRAIUPRAP.Text = ""
        Me.txtRAIUSEAP.Text = ""
        Me.txtRAIUTEL1.Text = ""
        Me.txtRAIUTEL2.Text = ""
        Me.txtRAIUFEEN.Text = ""
        Me.txtRAIUFERE.Text = ""
        Me.nudRAIUNUAC.Value = 0
        Me.txtRAIUOBSE.Text = ""

    End Sub
    Private Sub pro_inicializarControles()

        Try
            With Me.nudRAIUNUAC
                .Maximum = 100 ' valor máximo   
                .Minimum = 0 ' minimo  
                .Value = 0
                .Increment = 1
            End With

            ' instancia la clase
            Dim objdatos As New cla_REAVINUS
            Dim tbl As New DataTable

            tbl = objdatos.fun_Consultar_REAVINUS(inINUSSECU)

            If tbl.Rows.Count > 0 Then
                boMODIFICAR = True

                Me.Text = "Modificar registro"
                Me.fraINFOUSUA.Text = "MODIFICAR INFORMACIÓN DEL USUARIO"

                Me.txtRAIUDIPR.Text = CStr(Trim(tbl.Rows(0).Item("RAIUDIPR")))
                Me.txtRAIUDINO.Text = CStr(Trim(tbl.Rows(0).Item("RAIUDINO")))
                Me.txtRAIUTEL1.Text = CStr(Trim(tbl.Rows(0).Item("RAIUTEL1")))
                Me.txtRAIUTEL2.Text = CStr(Trim(tbl.Rows(0).Item("RAIUTEL2")))
                Me.chkRAIUACTA.Checked = CBool(tbl.Rows(0).Item("RAIUACTA"))
                Me.chkRAIUACFI.Checked = CBool(tbl.Rows(0).Item("RAIUACFI"))
                Me.nudRAIUNUAC.Value = CInt(tbl.Rows(0).Item("RAIUNUAC"))
                Me.txtRAIUNOMB.Text = CStr(Trim(tbl.Rows(0).Item("RAIUNOMB")))
                Me.txtRAIUPRAP.Text = CStr(Trim(tbl.Rows(0).Item("RAIUPRAP")))
                Me.txtRAIUSEAP.Text = CStr(Trim(tbl.Rows(0).Item("RAIUSEAP")))
                Me.txtRAIUTEL1.Text = CStr(Trim(tbl.Rows(0).Item("RAIUTEL1")))
                Me.txtRAIUTEL2.Text = CStr(Trim(tbl.Rows(0).Item("RAIUTEL2")))
                Me.txtRAIUFEEN.Text = CStr(Trim(tbl.Rows(0).Item("RAIUFEEN")))
                Me.txtRAIUFERE.Text = CStr(Trim(tbl.Rows(0).Item("RAIUFERE")))
                Me.txtRAIUOBSE.Text = CStr(Trim(tbl.Rows(0).Item("RAIUOBSE")))

                If fun_Verificar_Dato_Fecha_Evento_Validated(Me.txtRAIUFEEN.Text) = True Then
                    Me.dtpRAIUFEEN.Value = CDate(tbl.Rows(0).Item("RAIUFEEN"))
                End If

                If fun_Verificar_Dato_Fecha_Evento_Validated(Me.txtRAIUFERE.Text) = True Then
                    Me.dtpRAIUFERE.Value = CDate(tbl.Rows(0).Item("RAIUFERE"))
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

                Dim boINUSNOMB As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.txtRAIUNOMB)

                ' verifica los datos del formulario 
                If boINUSNOMB = True Then

                    Dim objdatos22 As New cla_REAVINUS

                    If (objdatos22.fun_Insertar_REAVINUS(inINUSSECU, _
                                                         Me.txtRAIUDIPR.Text, _
                                                         Me.txtRAIUDINO.Text, _
                                                         Me.txtRAIUNOMB.Text, _
                                                         Me.txtRAIUPRAP.Text, _
                                                         Me.txtRAIUSEAP.Text, _
                                                         Me.txtRAIUTEL1.Text, _
                                                         Me.txtRAIUTEL2.Text, _
                                                         Me.chkRAIUACTA.Checked, _
                                                         Me.nudRAIUNUAC.Value, _
                                                         Me.chkRAIUACFI.Checked, _
                                                         Me.txtRAIUFEEN.Text, _
                                                         Me.txtRAIUFERE.Text, _
                                                         Me.txtRAIUOBSE.Text)) = True Then

                        mod_MENSAJE.Se_Guardaron_Los_Datos_Correctamente()
                        Me.chkRAIUACTA.Focus()
                        Me.Close()
                    Else
                        mod_MENSAJE.No_Se_Guardo_El_Registro_En_La_Base_De_Datos()
                    End If

                End If

                ' modifica el registro
            ElseIf boMODIFICAR = True Then

                ' instancia la clase
                Dim objVerifica As New cla_Verificar_Dato

                Dim boINUSNOMB As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.txtRAIUNOMB)

                ' verifica los datos del formulario 
                If boINUSNOMB = True Then

                    Dim objdatos22 As New cla_REAVINUS

                    If (objdatos22.fun_Actualizar_SECU_X_REAVINUS(inINUSSECU, _
                                                                  Me.txtRAIUDIPR.Text, _
                                                                  Me.txtRAIUDINO.Text, _
                                                                  Me.txtRAIUNOMB.Text, _
                                                                  Me.txtRAIUPRAP.Text, _
                                                                  Me.txtRAIUSEAP.Text, _
                                                                  Me.txtRAIUTEL1.Text, _
                                                                  Me.txtRAIUTEL2.Text, _
                                                                  Me.chkRAIUACTA.Checked, _
                                                                  Me.nudRAIUNUAC.Value, _
                                                                  Me.chkRAIUACFI.Checked, _
                                                                  Me.txtRAIUFEEN.Text, _
                                                                  Me.txtRAIUFERE.Text, _
                                                                  Me.txtRAIUOBSE.Text)) = True Then

                        mod_MENSAJE.Se_Guardaron_Los_Datos_Correctamente()
                        Me.chkRAIUACTA.Focus()
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
        Me.chkRAIUACTA.Focus()
        Me.Close()
    End Sub

#End Region

#Region "FORMULARIO"

#Region "KeyPress"

    Private Sub txt_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles chkRAIUACTA.KeyPress, chkRAIUACFI.KeyPress, nudRAIUNUAC.KeyPress, txtRAIUNOMB.KeyPress, txtRAIUPRAP.KeyPress, txtRAIUSEAP.KeyPress, txtRAIUDIPR.KeyPress, txtRAIUDINO.KeyPress, txtRAIUTEL1.KeyPress, txtRAIUTEL2.KeyPress, txtRAIUFEEN.KeyPress, txtRAIUFERE.KeyPress, txtRAIUOBSE.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Or e.KeyChar = Convert.ToChar(Keys.Tab) Then
            pp_pro_SaltarCampo()
        End If
    End Sub

#End Region

#Region "GotFocus"

    Private Sub txt_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtRAIUNOMB.GotFocus, txtRAIUPRAP.GotFocus, txtRAIUSEAP.GotFocus, txtRAIUDIPR.GotFocus, txtRAIUDINO.GotFocus, txtRAIUTEL1.GotFocus, txtRAIUTEL2.GotFocus, txtRAIUFEEN.GotFocus, txtRAIUFERE.GotFocus, txtRAIUOBSE.GotFocus
        pp_pro_SobrearCampo(sender)
        pp_pro_DescripcionCampo(Me.strBARRESTA.Items(0), sender)
    End Sub
    Private Sub cmd_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdGUARDAR.GotFocus, cmdSALIR.GotFocus
        pp_pro_DescripcionCampo(Me.strBARRESTA.Items(0), sender)
    End Sub
    Private Sub chk_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkRAIUACTA.GotFocus, chkRAIUACFI.GotFocus
        pp_pro_DescripcionCampo(Me.strBARRESTA.Items(0), sender)
    End Sub
    Private Sub nud_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles nudRAIUNUAC.GotFocus
        pp_pro_DescripcionCampo(Me.strBARRESTA.Items(0), sender)
    End Sub

#End Region

#Region "ValueChanged"

    Private Sub dtpINUSFEEN_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpRAIUFEEN.ValueChanged
        Me.txtRAIUFEEN.Text = Me.dtpRAIUFEEN.Value
    End Sub
    Private Sub dtpINUSFERE_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpRAIUFERE.ValueChanged
        Me.txtRAIUFERE.Text = Me.dtpRAIUFERE.Value
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