Imports REGLAS_DEL_NEGOCIO

Public Class frm_insertar_INFOUSUA

    '=======================================
    '*** INSERTAR INFORMACIÓN DE USUARIO ***
    '=======================================

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

        Me.txtINUSNUDO.Text = ""
        Me.txtINUSFERE.Text = ""
        Me.txtINUSNOMB.Text = ""
        Me.txtINUSPRAP.Text = ""
        Me.txtINUSSEAP.Text = ""
        Me.txtINUSTEL1.Text = ""
        Me.txtINUSTEL2.Text = ""
        Me.txtINUSDIRE.Text = ""
        Me.txtINUSOBSE.Text = ""

    End Sub
    Private Sub pro_inicializarControles()

        Try

            ' instancia la clase
            Dim objdatos As New cla_INFOUSUA
            Dim tbl As New DataTable

            tbl = objdatos.fun_Consultar_INFOUSUA(inINUSSECU)

            If tbl.Rows.Count > 0 Then
                boMODIFICAR = True

                Me.Text = "Modificar registro"
                Me.fraINFOUSUA.Text = "MODIFICAR INFORMACIÓN DEL USUARIO"

                Me.txtINUSNUDO.Text = Trim(tbl.Rows(0).Item("INUSNUDO"))
                Me.txtINUSFERE.Text = Trim(tbl.Rows(0).Item("INUSFERE"))
                Me.txtINUSNOMB.Text = Trim(tbl.Rows(0).Item("INUSNOMB"))
                Me.txtINUSPRAP.Text = Trim(tbl.Rows(0).Item("INUSPRAP"))
                Me.txtINUSSEAP.Text = Trim(tbl.Rows(0).Item("INUSSEAP"))
                Me.txtINUSTEL1.Text = Trim(tbl.Rows(0).Item("INUSTEL1"))
                Me.txtINUSTEL2.Text = Trim(tbl.Rows(0).Item("INUSTEL2"))
                Me.txtINUSDIRE.Text = Trim(tbl.Rows(0).Item("INUSDIRE"))
                Me.txtINUSOBSE.Text = Trim(tbl.Rows(0).Item("INUSOBSE"))

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

                Dim boINUSNUDO As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.txtINUSNUDO)
                Dim boINUSFERE As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Fecha(Me.txtINUSFERE)
                Dim boINUSNOMB As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.txtINUSNOMB)
                Dim boINUSPRAP As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.txtINUSPRAP)
               
                ' verifica los datos del formulario 
                If boINUSNUDO = True And _
                   boINUSFERE = True And _
                   boINUSNOMB = True And _
                   boINUSPRAP = True Then

                    Dim objdatos22 As New cla_INFOUSUA

                    If (objdatos22.fun_Insertar_INFOUSUA(inINUSSECU, _
                                                         Me.txtINUSNUDO.Text, _
                                                         Me.txtINUSFERE.Text, _
                                                         Me.txtINUSNOMB.Text, _
                                                         Me.txtINUSPRAP.Text, _
                                                         Me.txtINUSSEAP.Text, _
                                                         Me.txtINUSTEL1.Text, _
                                                         Me.txtINUSTEL2.Text, _
                                                         Me.txtINUSDIRE.Text, _
                                                         Me.txtINUSOBSE.Text)) = True Then

                        mod_MENSAJE.Se_Guardaron_Los_Datos_Correctamente()
                        Me.txtINUSNUDO.Focus()
                        Me.Close()
                    Else
                        mod_MENSAJE.No_Se_Guardo_El_Registro_En_La_Base_De_Datos()
                    End If

                End If

                ' modifica el registro
            ElseIf boMODIFICAR = True Then

                ' instancia la clase
                Dim objVerifica As New cla_Verificar_Dato

                Dim boINUSNUDO As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.txtINUSNUDO)
                Dim boINUSFERE As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Fecha(Me.txtINUSFERE)
                Dim boINUSNOMB As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.txtINUSNOMB)
                Dim boINUSPRAP As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.txtINUSPRAP)

                ' verifica los datos del formulario 
                If boINUSNUDO = True And _
                   boINUSFERE = True And _
                   boINUSNOMB = True And _
                   boINUSPRAP = True Then

                    Dim objdatos22 As New cla_INFOUSUA

                    If (objdatos22.fun_Actualizar_SECU_X_INFOUSUA(inINUSSECU, _
                                                         Me.txtINUSNUDO.Text, _
                                                         Me.txtINUSFERE.Text, _
                                                         Me.txtINUSNOMB.Text, _
                                                         Me.txtINUSPRAP.Text, _
                                                         Me.txtINUSSEAP.Text, _
                                                         Me.txtINUSTEL1.Text, _
                                                         Me.txtINUSTEL2.Text, _
                                                         Me.txtINUSDIRE.Text, _
                                                         Me.txtINUSOBSE.Text)) = True Then

                        mod_MENSAJE.Se_Guardaron_Los_Datos_Correctamente()
                        Me.txtINUSNUDO.Focus()
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
        Me.txtINUSNUDO.Focus()
        Me.Close()
    End Sub

#End Region

#Region "FORMULARIO"

#Region "KeyPress"

    Private Sub txt_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtINUSNUDO.KeyPress, txtINUSFERE.KeyPress, txtINUSNOMB.KeyPress, txtINUSPRAP.KeyPress, txtINUSSEAP.KeyPress, txtINUSTEL1.KeyPress, txtINUSTEL2.KeyPress, txtINUSDIRE.KeyPress, txtINUSOBSE.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Or e.KeyChar = Convert.ToChar(Keys.Tab) Then
            pp_pro_SaltarCampo()
        End If
    End Sub

#End Region

#Region "GotFocus"

    Private Sub txt_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtINUSNUDO.GotFocus, txtINUSFERE.GotFocus, txtINUSNOMB.GotFocus, txtINUSPRAP.GotFocus, txtINUSSEAP.GotFocus, txtINUSTEL1.GotFocus, txtINUSTEL2.GotFocus, txtINUSDIRE.GotFocus, txtINUSOBSE.GotFocus
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