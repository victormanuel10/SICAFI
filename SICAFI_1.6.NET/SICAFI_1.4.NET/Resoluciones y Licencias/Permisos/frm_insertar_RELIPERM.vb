Imports REGLAS_DEL_NEGOCIO

Public Class frm_insertar_RELIPERM

    '=========================
    '*** INSERTAR PERMISOS ***
    '=========================

#Region "VARIABLE"

    Dim inRLPRIDRE As Integer
    Dim inRLPRSECU As Integer
    Dim stRLPRNUDO As String
    Dim inRLPRNURA As Integer
    Dim stRLPRFERA As String

    Dim boINSERTAR As Boolean = False
    Dim boMODIFICAR As Boolean = False

#End Region

#Region "CONSTRUCTOR"

    Public Sub New(ByVal inIDRE As Integer)
        inRLPRIDRE = inIDRE

        boMODIFICAR = True

        InitializeComponent()
        pro_LimpiarCampos()
        pro_inicializarControles()
    End Sub
    Public Sub New(ByVal inSECU As Integer, ByVal inNURA As Integer, ByVal stFERA As String)
        inRLPRSECU = inSECU
        inRLPRNURA = inNURA
        stRLPRFERA = stFERA

        boINSERTAR = True

        InitializeComponent()
        pro_LimpiarCampos()
        pro_inicializarControles()
    End Sub

#End Region

#Region "FUNCIONES"

    Private Function fun_ConsultaNombreUsuario(ByVal stNUMEDOCU As String) As String

        Try
            ' declara la variable
            Dim stUSUARIO As String = ""

            ' declara la instancia
            Dim obCONTRASENA As New cla_CONTRASENA
            Dim dtCONTRASENA As New DataTable

            dtCONTRASENA = obCONTRASENA.fun_Buscar_CODIGO_CONTRASENA(Trim(stNUMEDOCU))

            If dtCONTRASENA.Rows.Count > 0 Then
                stUSUARIO = Trim(dtCONTRASENA.Rows(0).Item("CONTUSUA").ToString)
            End If

            Return stUSUARIO

        Catch ex As Exception
            Return Nothing
            MessageBox.Show(Err.Description)
        End Try

    End Function
    Private Function fun_ConsultaDocumentoUsuario(ByVal stUSUARIO As String) As String

        Try
            ' declara la variable
            Dim stNUMEDOCU As String = ""

            ' declara la instancia
            Dim obCONTRASENA As New cla_CONTRASENA
            Dim dtCONTRASENA As New DataTable

            dtCONTRASENA = obCONTRASENA.fun_Buscar_USUARIO_CONTRASENA(Trim(stUSUARIO))

            If dtCONTRASENA.Rows.Count > 0 Then
                stNUMEDOCU = Trim(dtCONTRASENA.Rows(0).Item("CONTNUDO").ToString)
            End If

            Return stNUMEDOCU

        Catch ex As Exception
            Return Nothing
            MessageBox.Show(Err.Description)
        End Try

    End Function

#End Region

#Region "PROCEDIMIENTOS"

    Private Sub pro_LimpiarCampos()

        Me.txtRLPEOBSE.Text = ""
        Me.txtRLPEOBSE_ANTERIOR.Text = ""

    End Sub
    Private Sub pro_inicializarControles()

        Try
            If boMODIFICAR = True Then

                ' instancia la clase
                Dim objdatos As New cla_RELIPERM
                Dim tbl As New DataTable

                tbl = objdatos.fun_Buscar_ID_X_RELIPERM(inRLPRIDRE)

                If tbl.Rows.Count > 0 Then

                    Me.Text = "Modificar registro"
                    Me.fraRECLTRCA.Text = "MODIFICAR OBSERVACIÓN"

                    Me.txtRLPEOBSE_ANTERIOR.Text = Trim(tbl.Rows(0).Item("RLPEOBSE"))

                    Me.txtRLPEOBSE.Focus()

                End If

            ElseIf boINSERTAR = True Then

                Me.Text = "Insertar registro"
                Me.fraRECLTRCA.Text = "INSERTAR OBSERVACIÓN"

                Me.txtRLPEOBSE.Focus()

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
                Dim objdatos1 As New cla_RELIPERM

                Dim boLLAVEPRIMARIA As Boolean = objdatos1.fun_Verifica_llave_Primaria_RELIPERM(inRLPRSECU, Trim(vp_cedula))

                ' instancia la clase
                Dim objVerifica As New cla_Verificar_Dato

                Dim boLEVAOBSE As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.txtRLPEOBSE)
                Dim boLEVAUSUA As Boolean = False
                Dim boLEVACANT As Boolean = False

                Dim stMOGEUSUA As String = fun_ConsultaDocumentoUsuario(Trim(vp_usuario))

                If Trim(stMOGEUSUA) = "" Then
                    boLEVAUSUA = False
                    MessageBox.Show("El funcionario seleccionado no registra un perfil de usuario", "Mensaje...", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1)
                Else
                    boLEVAUSUA = True
                End If

                Dim inCANTIDAD_CARACTERES As Integer = Trim(Me.txtRLPEOBSE.Text).ToString.Length

                If inCANTIDAD_CARACTERES > 40 Then
                    boLEVACANT = True
                    Me.txtRLPEOBSE.Text = " Nota ingresada por " & vp_usuario & " " & fun_fecha() & " : " & Trim(Me.txtRLPEOBSE.Text) & ". "
                Else
                    MessageBox.Show("Se debe diligenciar una observación de como mínimo 40 caracteres", "Mensaje...", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1)
                End If

                ' verifica los datos del formulario 
                If boLLAVEPRIMARIA = True And _
                   boLEVAOBSE = True And _
                   boLEVACANT = True And _
                   boLEVAUSUA = True Then

                    Dim objdatos22 As New cla_RELIPERM

                    If (objdatos22.fun_Insertar_RELIPERM(inRLPRSECU, _
                                                         inRLPRNURA, _
                                                         stRLPRFERA, _
                                                         vp_cedula, _
                                                         vp_usuario, _
                                                         Me.txtRLPEOBSE.Text)) = True Then

                        mod_MENSAJE.Se_Guardaron_Los_Datos_Correctamente()
                        Me.txtRLPEOBSE.Focus()
                        Me.Close()
                    Else
                        mod_MENSAJE.No_Se_Guardo_El_Registro_En_La_Base_De_Datos()
                    End If

                End If

                ' modifica el registro
            ElseIf boMODIFICAR = True Then

                ' instancia la clase
                Dim objVerifica As New cla_Verificar_Dato

                Dim boLEVAOBSE As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.txtRLPEOBSE)
                Dim boLEVACANT As Boolean = False

                Dim inCANTIDAD_CARACTERES As Integer = Trim(Me.txtRLPEOBSE.Text).ToString.Length

                Dim stREMUOBSE_ACTUAL As String = ""
                Dim stREMUOBSE_NUEVA As String = ""

                If inCANTIDAD_CARACTERES > 40 Then
                    boLEVACANT = True

                    stREMUOBSE_ACTUAL = Trim(Me.txtRLPEOBSE_ANTERIOR.Text)
                    stREMUOBSE_NUEVA = Trim(Me.txtRLPEOBSE.Text)

                    If Trim(stREMUOBSE_ACTUAL) <> "" And Trim(stREMUOBSE_NUEVA) <> "" Then
                        stREMUOBSE_ACTUAL += vbCrLf & " Nota ingresada por " & vp_usuario & " " & fun_fecha() & " : " & stREMUOBSE_NUEVA & ". "

                    End If

                Else
                    MessageBox.Show("Se debe diligenciar una observación de como mínimo 40 caracteres", "Mensaje...", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1)
                End If

                ' verifica los datos del formulario 
                If boLEVAOBSE = True And _
                   boLEVACANT = True Then

                    Dim objdatos22 As New cla_RELIPERM

                    If (objdatos22.fun_Actualizar_RELIPERM(inRLPRIDRE, _
                                                           stREMUOBSE_ACTUAL)) = True Then

                        mod_MENSAJE.Se_Guardaron_Los_Datos_Correctamente()
                        Me.txtRLPEOBSE.Focus()
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
        Me.txtRLPEOBSE.Focus()
        Me.Close()
    End Sub

#End Region

#Region "FORMULARIO"

#Region "KeyPress"

    Private Sub txt_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtRLPEOBSE.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Or e.KeyChar = Convert.ToChar(Keys.Tab) Then
            pp_pro_SaltarCampo()
        End If
    End Sub

#End Region

#Region "GotFocus"

    Private Sub txt_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtRLPEOBSE.GotFocus
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