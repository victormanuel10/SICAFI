Imports REGLAS_DEL_NEGOCIO

Public Class frm_insertar_AJIPINUS

    '==============================================
    '*** INSERTAR INFORMACIÓN DE USUARIO AJUSTE ***
    '==============================================

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

        Me.txtAJIUNUDO.Text = ""
        Me.txtAJIUFERE.Text = ""
        Me.txtAJIUNOMB.Text = ""
        Me.txtAJIUPRAP.Text = ""
        Me.txtAJIUSEAP.Text = ""
        Me.txtAJIUTEL1.Text = ""
        Me.txtAJIUTEL2.Text = ""
        Me.txtAJIUCOEL.Text = ""
        Me.txtAJIUDIPR.Text = ""
        Me.txtAJIUDICO.Text = ""
        Me.txtAJIUOBSE.Text = ""

    End Sub
    Private Sub pro_inicializarControles()

        Try

            ' instancia la clase
            Dim objdatos As New cla_AJIPINUS
            Dim tbl As New DataTable

            tbl = objdatos.fun_Consultar_AJIPINUS(inINUSSECU)

            If tbl.Rows.Count > 0 Then
                boMODIFICAR = True

                Me.Text = "Modificar registro"
                Me.fraINFOUSUA.Text = "MODIFICAR INFORMACIÓN DEL USUARIO"

                Me.txtAJIUNUDO.Text = Trim(tbl.Rows(0).Item("AJIUNUDO"))
                Me.txtAJIUFERE.Text = Trim(tbl.Rows(0).Item("AJIUFERE"))
                Me.txtAJIUNOMB.Text = Trim(tbl.Rows(0).Item("AJIUNOMB"))
                Me.txtAJIUPRAP.Text = Trim(tbl.Rows(0).Item("AJIUPRAP"))
                Me.txtAJIUSEAP.Text = Trim(tbl.Rows(0).Item("AJIUSEAP"))
                Me.txtAJIUTEL1.Text = Trim(tbl.Rows(0).Item("AJIUTEL1"))
                Me.txtAJIUTEL2.Text = Trim(tbl.Rows(0).Item("AJIUTEL2"))
                Me.txtAJIUCOEL.Text = Trim(tbl.Rows(0).Item("AJIUCOEL"))
                Me.txtAJIUDIPR.Text = Trim(tbl.Rows(0).Item("AJIUDIPR"))
                Me.txtAJIUDICO.Text = Trim(tbl.Rows(0).Item("AJIUDICO"))
                Me.txtAJIUOBSE.Text = Trim(tbl.Rows(0).Item("AJIUOBSE"))

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

                Dim boINUSNUDO As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.txtAJIUNUDO)
                Dim boINUSFERE As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Fecha(Me.txtAJIUFERE)
                Dim boINUSNOMB As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.txtAJIUNOMB)
                Dim boINUSPRAP As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.txtAJIUPRAP)

                ' verifica los datos del formulario 
                If boINUSNUDO = True And _
                   boINUSFERE = True And _
                   boINUSNOMB = True And _
                   boINUSPRAP = True Then

                    Dim objdatos22 As New cla_AJIPINUS

                    If (objdatos22.fun_Insertar_AJIPINUS(inINUSSECU, _
                                                         Me.txtAJIUNUDO.Text, _
                                                         Me.txtAJIUFERE.Text, _
                                                         Me.txtAJIUNOMB.Text, _
                                                         Me.txtAJIUPRAP.Text, _
                                                         Me.txtAJIUSEAP.Text, _
                                                         Me.txtAJIUTEL1.Text, _
                                                         Me.txtAJIUTEL2.Text, _
                                                         Me.txtAJIUCOEL.Text, _
                                                         Me.txtAJIUDIPR.Text, _
                                                         Me.txtAJIUDICO.Text, _
                                                         Me.txtAJIUOBSE.Text)) = True Then

                        mod_MENSAJE.Se_Guardaron_Los_Datos_Correctamente()
                        Me.txtAJIUNUDO.Focus()
                        Me.Close()
                    Else
                        mod_MENSAJE.No_Se_Guardo_El_Registro_En_La_Base_De_Datos()
                    End If

                End If

                ' modifica el registro
            ElseIf boMODIFICAR = True Then

                ' instancia la clase
                Dim objVerifica As New cla_Verificar_Dato

                Dim boINUSNUDO As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.txtAJIUNUDO)
                Dim boINUSFERE As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Fecha(Me.txtAJIUFERE)
                Dim boINUSNOMB As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.txtAJIUNOMB)
                Dim boINUSPRAP As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.txtAJIUPRAP)

                ' verifica los datos del formulario 
                If boINUSNUDO = True And _
                   boINUSFERE = True And _
                   boINUSNOMB = True And _
                   boINUSPRAP = True Then

                    Dim objdatos22 As New cla_AJIPINUS

                    If (objdatos22.fun_Actualizar_SECU_X_AJIPINUS(inINUSSECU, _
                                                                  Me.txtAJIUNUDO.Text, _
                                                                  Me.txtAJIUFERE.Text, _
                                                                  Me.txtAJIUNOMB.Text, _
                                                                  Me.txtAJIUPRAP.Text, _
                                                                  Me.txtAJIUSEAP.Text, _
                                                                  Me.txtAJIUTEL1.Text, _
                                                                  Me.txtAJIUTEL2.Text, _
                                                                  Me.txtAJIUCOEL.Text, _
                                                                  Me.txtAJIUDIPR.Text, _
                                                                  Me.txtAJIUDICO.Text, _
                                                                  Me.txtAJIUOBSE.Text)) = True Then

                        mod_MENSAJE.Se_Guardaron_Los_Datos_Correctamente()
                        Me.txtAJIUNUDO.Focus()
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
        Me.txtAJIUNUDO.Focus()
        Me.Close()
    End Sub

#End Region

#Region "FORMULARIO"

#Region "KeyPress"

    Private Sub txt_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtAJIUNUDO.KeyPress, txtAJIUFERE.KeyPress, txtAJIUNOMB.KeyPress, txtAJIUPRAP.KeyPress, txtAJIUSEAP.KeyPress, txtAJIUTEL1.KeyPress, txtAJIUTEL2.KeyPress, txtAJIUDIPR.KeyPress, txtAJIUOBSE.KeyPress, txtAJIUCOEL.KeyPress, txtAJIUDICO.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Or e.KeyChar = Convert.ToChar(Keys.Tab) Then
            pp_pro_SaltarCampo()
        End If
    End Sub

#End Region

#Region "GotFocus"

    Private Sub txt_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtAJIUNUDO.GotFocus, txtAJIUFERE.GotFocus, txtAJIUNOMB.GotFocus, txtAJIUPRAP.GotFocus, txtAJIUSEAP.GotFocus, txtAJIUTEL1.GotFocus, txtAJIUTEL2.GotFocus, txtAJIUDIPR.GotFocus, txtAJIUOBSE.GotFocus, txtAJIUCOEL.GotFocus, txtAJIUDICO.GotFocus
        pp_pro_SobrearCampo(sender)
        pp_pro_DescripcionCampo(Me.strBARRESTA.Items(0), sender)
    End Sub
    Private Sub cmd_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdGUARDAR.GotFocus, cmdSALIR.GotFocus
        pp_pro_DescripcionCampo(Me.strBARRESTA.Items(0), sender)
    End Sub

#End Region

#Region "Validated"

    Private Sub txtAJIUNUDO_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtAJIUNUDO.Validated

        Try
            ' extrae el tercero si ya existe en base de datos
            Dim objdatos1 As New cla_TERCERO
            Dim tbl1 As New DataTable

            tbl1 = objdatos1.fun_Buscar_CODIGO_TERCERO(Trim(Me.txtAJIUNUDO.Text))

            If tbl1.Rows.Count > 0 Then

                Me.txtAJIUNOMB.Text = Trim(tbl1.Rows(0).Item(5))
                Me.txtAJIUPRAP.Text = Trim(tbl1.Rows(0).Item(6))
                Me.txtAJIUSEAP.Text = Trim(tbl1.Rows(0).Item(7))

            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

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