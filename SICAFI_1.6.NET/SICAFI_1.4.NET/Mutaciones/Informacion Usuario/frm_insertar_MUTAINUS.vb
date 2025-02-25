Imports REGLAS_DEL_NEGOCIO

Public Class frm_insertar_MUTAINUS

    '==================================================
    '*** INSERTAR INFORMACIÓN DE USUARIO MUTACIONES ***
    '==================================================

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

        Me.txtMUIUNUDO.Text = ""
        Me.txtMUIUFERE.Text = ""
        Me.txtMUIUNOMB.Text = ""
        Me.txtMUIUPRAP.Text = ""
        Me.txtMUIUSEAP.Text = ""
        Me.txtMUIUTEL1.Text = ""
        Me.txtMUIUTEL2.Text = ""
        Me.txtMUIUDIRE.Text = ""
        Me.txtMUIUOBSE.Text = ""

    End Sub
    Private Sub pro_inicializarControles()

        Try

            ' instancia la clase
            Dim objdatos As New cla_MUTAINUS
            Dim tbl As New DataTable

            tbl = objdatos.fun_Consultar_MUTAINUS(inINUSSECU)

            If tbl.Rows.Count > 0 Then
                boMODIFICAR = True

                Me.Text = "Modificar registro"
                Me.fraINFOUSUA.Text = "MODIFICAR INFORMACIÓN DEL USUARIO"

                Me.txtMUIUNUDO.Text = Trim(tbl.Rows(0).Item("MUIUNUDO"))
                Me.txtMUIUFERE.Text = Trim(tbl.Rows(0).Item("MUIUFERE"))
                Me.txtMUIUNOMB.Text = Trim(tbl.Rows(0).Item("MUIUNOMB"))
                Me.txtMUIUPRAP.Text = Trim(tbl.Rows(0).Item("MUIUPRAP"))
                Me.txtMUIUSEAP.Text = Trim(tbl.Rows(0).Item("MUIUSEAP"))
                Me.txtMUIUTEL1.Text = Trim(tbl.Rows(0).Item("MUIUTEL1"))
                Me.txtMUIUTEL2.Text = Trim(tbl.Rows(0).Item("MUIUTEL2"))
                Me.txtMUIUDIRE.Text = Trim(tbl.Rows(0).Item("MUIUDIRE"))
                Me.txtMUIUOBSE.Text = Trim(tbl.Rows(0).Item("MUIUOBSE"))

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

                Dim boINUSNUDO As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.txtMUIUNUDO)
                Dim boINUSFERE As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Fecha(Me.txtMUIUFERE)
                Dim boINUSNOMB As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.txtMUIUNOMB)
                Dim boINUSPRAP As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.txtMUIUPRAP)

                ' verifica los datos del formulario 
                If boINUSNUDO = True And _
                   boINUSFERE = True And _
                   boINUSNOMB = True And _
                   boINUSPRAP = True Then

                    Dim objdatos22 As New cla_MUTAINUS

                    If (objdatos22.fun_Insertar_MUTAINUS(inINUSSECU, _
                                                         Me.txtMUIUNUDO.Text, _
                                                         Me.txtMUIUFERE.Text, _
                                                         Me.txtMUIUNOMB.Text, _
                                                         Me.txtMUIUPRAP.Text, _
                                                         Me.txtMUIUSEAP.Text, _
                                                         Me.txtMUIUTEL1.Text, _
                                                         Me.txtMUIUTEL2.Text, _
                                                         Me.txtMUIUDIRE.Text, _
                                                         Me.txtMUIUOBSE.Text)) = True Then

                        mod_MENSAJE.Se_Guardaron_Los_Datos_Correctamente()
                        Me.txtMUIUNUDO.Focus()
                        Me.Close()
                    Else
                        mod_MENSAJE.No_Se_Guardo_El_Registro_En_La_Base_De_Datos()
                    End If

                End If

                ' modifica el registro
            ElseIf boMODIFICAR = True Then

                ' instancia la clase
                Dim objVerifica As New cla_Verificar_Dato

                Dim boINUSNUDO As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.txtMUIUNUDO)
                Dim boINUSFERE As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Fecha(Me.txtMUIUFERE)
                Dim boINUSNOMB As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.txtMUIUNOMB)
                Dim boINUSPRAP As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.txtMUIUPRAP)

                ' verifica los datos del formulario 
                If boINUSNUDO = True And _
                   boINUSFERE = True And _
                   boINUSNOMB = True And _
                   boINUSPRAP = True Then

                    Dim objdatos22 As New cla_MUTAINUS

                    If (objdatos22.fun_Actualizar_SECU_X_MUTAINUS(inINUSSECU, _
                                                         Me.txtMUIUNUDO.Text, _
                                                         Me.txtMUIUFERE.Text, _
                                                         Me.txtMUIUNOMB.Text, _
                                                         Me.txtMUIUPRAP.Text, _
                                                         Me.txtMUIUSEAP.Text, _
                                                         Me.txtMUIUTEL1.Text, _
                                                         Me.txtMUIUTEL2.Text, _
                                                         Me.txtMUIUDIRE.Text, _
                                                         Me.txtMUIUOBSE.Text)) = True Then

                        mod_MENSAJE.Se_Guardaron_Los_Datos_Correctamente()
                        Me.txtMUIUNUDO.Focus()
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
        Me.txtMUIUNUDO.Focus()
        Me.Close()
    End Sub

#End Region

#Region "FORMULARIO"

#Region "KeyPress"

    Private Sub txt_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtMUIUNUDO.KeyPress, txtMUIUFERE.KeyPress, txtMUIUNOMB.KeyPress, txtMUIUPRAP.KeyPress, txtMUIUSEAP.KeyPress, txtMUIUTEL1.KeyPress, txtMUIUTEL2.KeyPress, txtMUIUDIRE.KeyPress, txtMUIUOBSE.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Or e.KeyChar = Convert.ToChar(Keys.Tab) Then
            pp_pro_SaltarCampo()
        End If
    End Sub

#End Region

#Region "GotFocus"

    Private Sub txt_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtMUIUNUDO.GotFocus, txtMUIUFERE.GotFocus, txtMUIUNOMB.GotFocus, txtMUIUPRAP.GotFocus, txtMUIUSEAP.GotFocus, txtMUIUTEL1.GotFocus, txtMUIUTEL2.GotFocus, txtMUIUDIRE.GotFocus, txtMUIUOBSE.GotFocus
        pp_pro_SobrearCampo(sender)
        pp_pro_DescripcionCampo(Me.strBARRESTA.Items(0), sender)
    End Sub
    Private Sub cmd_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdGUARDAR.GotFocus, cmdSALIR.GotFocus
        pp_pro_DescripcionCampo(Me.strBARRESTA.Items(0), sender)
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