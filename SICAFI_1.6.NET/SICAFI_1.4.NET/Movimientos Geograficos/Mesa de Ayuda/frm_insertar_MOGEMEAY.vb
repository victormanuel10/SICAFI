Imports REGLAS_DEL_NEGOCIO

Public Class frm_insertar_MOGEMEAY

    '=============================================
    '*** MESA DE AYUDA MOVIMIENTOS GEOGRAFICOS ***
    '=============================================

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

        Me.txtMGMANURA.Text = "0"
        Me.txtMGMAFERA.Text = ""
        Me.txtMGMANUCA.Text = "0"
        Me.txtMGMAVERS.Text = ""
        Me.txtMGMAPEAS.Text = ""
        Me.txtMGMAOBSE.Text = ""

    End Sub
    Private Sub pro_inicializarControles()

        Try
            If boMODIFICAR = True Then

                ' instancia la clase
                Dim objdatos As New cla_MOGEMEAY
                Dim tbl As New DataTable

                tbl = objdatos.fun_Consultar_MOGEMEAY(inID_REGISTRO, inMGMASECU)

                If tbl.Rows.Count > 0 Then

                    Me.Text = "Modificar registro"
                    Me.fraINFOUSUA.Text = "MODIFICAR MESA DE AYUDA"

                    Me.txtMGMANURA.Text = Trim(tbl.Rows(0).Item("MGMANURA"))
                    Me.txtMGMAFERA.Text = Trim(tbl.Rows(0).Item("MGMAFERA"))
                    Me.txtMGMANUCA.Text = Trim(tbl.Rows(0).Item("MGMANUCA"))
                    Me.txtMGMAVERS.Text = Trim(tbl.Rows(0).Item("MGMAVERS"))
                    Me.txtMGMAPEAS.Text = Trim(tbl.Rows(0).Item("MGMAPEAS"))
                    Me.txtMGMAOBSE.Text = Trim(tbl.Rows(0).Item("MGMAOBSE"))

                End If

            ElseIf boINSERTAR = True Then

                Me.Text = "Insertar registro"
                Me.fraINFOUSUA.Text = "INSERTAR MESA DE AYUDA"

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

                Dim boMGMANURA As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Numerico(Me.txtMGMANURA)
                Dim boMGMAFERA As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Fecha(Me.txtMGMAFERA)

                ' verifica los datos del formulario 
                If boMGMANURA = True And _
                   boMGMAFERA = True Then

                    Dim objdatos22 As New cla_MOGEMEAY

                    If (objdatos22.fun_Insertar_MOGEMEAY(inMGMASECU, _
                                                         Me.txtMGMANURA.Text, _
                                                         Me.txtMGMAFERA.Text, _
                                                         Me.txtMGMANUCA.Text, _
                                                         Me.txtMGMAVERS.Text, _
                                                         Me.txtMGMAPEAS.Text, _
                                                         Me.txtMGMAOBSE.Text)) = True Then

                        mod_MENSAJE.Se_Guardaron_Los_Datos_Correctamente()
                        Me.txtMGMANURA.Focus()
                        Me.Close()
                    Else
                        mod_MENSAJE.No_Se_Guardo_El_Registro_En_La_Base_De_Datos()
                    End If

                End If

                ' modifica el registro
            ElseIf boMODIFICAR = True Then

                ' instancia la clase
                Dim objVerifica As New cla_Verificar_Dato

                Dim boMGMANURA As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Numerico(Me.txtMGMANURA)
                Dim boMGMAFERA As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Fecha(Me.txtMGMAFERA)

                ' verifica los datos del formulario 
                If boMGMANURA = True And _
                   boMGMAFERA = True Then

                    Dim objdatos22 As New cla_MOGEMEAY

                    If (objdatos22.fun_Actualizar_SECU_X_MOGEMEAY(inMGMASECU, _
                                                                  Me.txtMGMANURA.Text, _
                                                                  Me.txtMGMAFERA.Text, _
                                                                  Me.txtMGMANUCA.Text, _
                                                                  Me.txtMGMAVERS.Text, _
                                                                  Me.txtMGMAPEAS.Text, _
                                                                  Me.txtMGMAOBSE.Text)) = True Then

                        mod_MENSAJE.Se_Guardaron_Los_Datos_Correctamente()
                        Me.txtMGMANURA.Focus()
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
        Me.txtMGMANURA.Focus()
        Me.Close()
    End Sub

#End Region

#Region "FORMULARIO"

#Region "KeyPress"

    Private Sub txt_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtMGMANURA.KeyPress, txtMGMAFERA.KeyPress, txtMGMANUCA.KeyPress, txtMGMAVERS.KeyPress, txtMGMAPEAS.KeyPress, txtMGMAOBSE.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Or e.KeyChar = Convert.ToChar(Keys.Tab) Then
            pp_pro_SaltarCampo()
        End If
    End Sub

#End Region

#Region "GotFocus"

    Private Sub txt_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtMGMANURA.GotFocus, txtMGMAFERA.GotFocus, txtMGMANUCA.GotFocus, txtMGMAVERS.GotFocus, txtMGMAPEAS.GotFocus, txtMGMAOBSE.GotFocus
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