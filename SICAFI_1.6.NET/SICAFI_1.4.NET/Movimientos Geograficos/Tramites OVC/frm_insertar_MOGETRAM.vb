Imports REGLAS_DEL_NEGOCIO

Public Class frm_insertar_MOGETRAM

    '============================================
    '*** TRAMITES OVC MOVIMIENTOS GEOGRAFICOS ***
    '============================================

#Region "VARIABLE"

    Dim inID_REGISTRO As Integer
    Dim inMGMASECU As Integer

    Dim boINSERTAR As Boolean = False
    Dim boMODIFICAR As Boolean = False

#End Region

#Region "CONSTRUCTOR"

    Public Sub New(ByVal inIDRE As Integer)
        inID_REGISTRO = inIDRE
        inMGMASECU = inIDRE

        boINSERTAR = True

        InitializeComponent()
        pro_LimpiarCampos()
        pro_inicializarControles()
    End Sub
    Public Sub New(ByVal inIDRE As Integer, ByVal inSECU As Integer)
        inID_REGISTRO = inIDRE
        inMGMASECU = inSECU

        boMODIFICAR = True

        InitializeComponent()
        pro_LimpiarCampos()
        pro_inicializarControles()
    End Sub

#End Region

#Region "PROCEDIMIENTOS"

    Private Sub pro_LimpiarCampos()

        Me.txtMGTRNUTR.Text = "0"
        Me.txtMGTRFETR.Text = ""
        Me.txtMGTRNURE.Text = "0"
        Me.txtMGTRFERE.Text = ""
        Me.txtMGTRFEFI.Text = ""
        Me.txtMGTROBSE.Text = ""

    End Sub
    Private Sub pro_inicializarControles()

        Try
            If boMODIFICAR = True Then

                ' instancia la clase
                Dim objdatos As New cla_MOGETRAM
                Dim tbl As New DataTable

                tbl = objdatos.fun_Consultar_MOGETRAM(inID_REGISTRO, inMGMASECU)

                If tbl.Rows.Count > 0 Then

                    Me.Text = "Modificar registro"
                    Me.fraINFOUSUA.Text = "MODIFICAR TRAMITES OVC"

                    Me.txtMGTRNUTR.Text = Trim(tbl.Rows(0).Item("MGTRNUTR"))
                    Me.txtMGTRFETR.Text = Trim(tbl.Rows(0).Item("MGTRFETR"))
                    Me.txtMGTRNURE.Text = Trim(tbl.Rows(0).Item("MGTRNURE"))
                    Me.txtMGTRFERE.Text = Trim(tbl.Rows(0).Item("MGTRFERE"))
                    Me.txtMGTRFEFI.Text = Trim(tbl.Rows(0).Item("MGTRFEFI"))
                    Me.txtMGTROBSE.Text = Trim(tbl.Rows(0).Item("MGTROBSE"))

                End If

            ElseIf boINSERTAR = True Then

                Me.Text = "Insertar registro"
                Me.fraINFOUSUA.Text = "INSERTAR TRAMITES OVC"

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

                Dim boMGMANURA As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Numerico(Me.txtMGTRNUTR)
                Dim boMGMAFERA As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Fecha(Me.txtMGTRFETR)

                ' verifica los datos del formulario 
                If boMGMANURA = True And _
                   boMGMAFERA = True Then

                    Dim objdatos22 As New cla_MOGETRAM

                    If (objdatos22.fun_Insertar_MOGETRAM(inMGMASECU, _
                                                         Me.txtMGTRNUTR.Text, _
                                                         Me.txtMGTRFETR.Text, _
                                                         Me.txtMGTRNURE.Text, _
                                                         Me.txtMGTRFERE.Text, _
                                                         Me.txtMGTRFEFI.Text, _
                                                         Me.txtMGTROBSE.Text)) = True Then

                        mod_MENSAJE.Se_Guardaron_Los_Datos_Correctamente()
                        Me.txtMGTRNUTR.Focus()
                        Me.Close()
                    Else
                        mod_MENSAJE.No_Se_Guardo_El_Registro_En_La_Base_De_Datos()
                    End If

                End If

                ' modifica el registro
            ElseIf boMODIFICAR = True Then

                ' instancia la clase
                Dim objVerifica As New cla_Verificar_Dato

                Dim boMGMANURA As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Numerico(Me.txtMGTRNUTR)
                Dim boMGMAFERA As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Fecha(Me.txtMGTRFETR)

                ' verifica los datos del formulario 
                If boMGMANURA = True And _
                   boMGMAFERA = True Then

                    Dim objdatos22 As New cla_MOGETRAM

                    If (objdatos22.fun_Actualizar_SECU_X_MOGETRAM(inMGMASECU, _
                                                                  Me.txtMGTRNUTR.Text, _
                                                                  Me.txtMGTRFETR.Text, _
                                                                  Me.txtMGTRNURE.Text, _
                                                                  Me.txtMGTRFERE.Text, _
                                                                  Me.txtMGTRFEFI.Text, _
                                                                  Me.txtMGTROBSE.Text)) = True Then

                        mod_MENSAJE.Se_Guardaron_Los_Datos_Correctamente()
                        Me.txtMGTRNUTR.Focus()
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
        Me.txtMGTRNUTR.Focus()
        Me.Close()
    End Sub

#End Region

#Region "FORMULARIO"

#Region "KeyPress"

    Private Sub txt_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtMGTRNUTR.KeyPress, txtMGTRFETR.KeyPress, txtMGTRNURE.KeyPress, txtMGTRFERE.KeyPress, txtMGTRFEFI.KeyPress, txtMGTROBSE.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Or e.KeyChar = Convert.ToChar(Keys.Tab) Then
            pp_pro_SaltarCampo()
        End If
    End Sub

#End Region

#Region "GotFocus"

    Private Sub txt_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtMGTRNUTR.GotFocus, txtMGTRFETR.GotFocus, txtMGTRNURE.GotFocus, txtMGTRFERE.GotFocus, txtMGTRFEFI.GotFocus, txtMGTROBSE.GotFocus
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