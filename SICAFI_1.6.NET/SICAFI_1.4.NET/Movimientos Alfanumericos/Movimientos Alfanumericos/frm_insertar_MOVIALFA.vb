Imports REGLAS_DEL_NEGOCIO
Imports System.IO

Public Class frm_insertar_MOVIALFA

    '========================================
    '*** INSERTAR MOVIMIENTO ALFANUMERICO ***
    '========================================

#Region "PROCEDIMIENTOS"

    Private Sub pro_LimpiarCampos()

        Me.cboMOALCLSE.DataSource = New DataTable
        Me.cboMOALVIGE.DataSource = New DataTable
        Me.cboMOALCAAC.DataSource = New DataTable
        Me.cboMOALVIGE.DataSource = New DataTable
        Me.cboMOALCLVE.DataSource = New DataTable
        Me.cboMOALESTA.DataSource = New DataTable
        Me.cboMOALNUDO.DataSource = New DataTable

        Me.txtMOALSECU.Text = ""
        Me.lblMOALCLSE.Text = ""
        Me.lblMOALVIGE.Text = ""
        Me.lblMOALCAAC.Text = ""
        Me.lblMOALCLVE.Text = ""
        Me.lblMOALNUDO.Text = ""
        Me.txtMOALMUNI.Text = "266"
        Me.txtMOALCORR.Text = "01"
        Me.txtMOALBARR.Text = ""
        Me.txtMOALMANZ.Text = ""
        Me.txtMOALPRED.Text = ""
        Me.txtMOALOBSE.Text = ""

    End Sub

#End Region

#Region "FUNCIONES"

    Private Function fun_NumeroDeSecuenciaDeRegistro() As Integer

        Try
            Dim inFPDESECU As Integer = 0

            Dim objdatos5 As New cla_MOVIALFA
            Dim tbl10 As New DataTable

            tbl10 = objdatos5.fun_Buscar_SECUENCIA_X_MOVIALFA

            If tbl10.Rows.Count = 0 Then
                inFPDESECU = 1
            Else
                Dim i As Integer
                Dim NroMayor As Integer
                Dim Posicion As Integer

                Posicion = Val(tbl10.Rows(0).Item("MOALSECU"))

                For i = 0 To tbl10.Rows.Count - 1
                    NroMayor = Val(tbl10.Rows(i).Item("MOALSECU"))

                    If NroMayor > Posicion Then
                        inFPDESECU = NroMayor
                        Posicion = NroMayor
                    Else
                        inFPDESECU = Posicion
                    End If
                Next

                inFPDESECU += 1
            End If

            Return inFPDESECU

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Function
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

#End Region

#Region "MENU"

    Private Sub cmdGUARDAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGUARDAR.Click

        Try
            ' instancia la clase
            Dim objdatos As New cla_MOVIALFA

            Dim boLLAVEPRIMARIA As Boolean = objdatos.fun_Verifica_llave_Primaria_MOVIALFA(Me.txtMOALMUNI, Me.txtMOALCORR, Me.txtMOALBARR, Me.txtMOALMANZ, Me.txtMOALPRED, Me.cboMOALCLSE, Me.cboMOALVIGE)

            ' instancia la clase
            Dim objVerifica As New cla_Verificar_Dato

            Dim boMOALMUNI As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Numerico(Me.txtMOALMUNI)
            Dim boMOALCORR As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Numerico(Me.txtMOALCORR)
            Dim boMOALBARR As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Numerico(Me.txtMOALBARR)
            Dim boMOALMANZ As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Numerico(Me.txtMOALMANZ)
            Dim boMOALPRED As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Numerico(Me.txtMOALPRED)
            Dim boMOALCLSE As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboMOALCLSE)
            Dim boMOALVIGE As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboMOALVIGE)
            Dim boMOALCAAC As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboMOALCAAC)
            Dim boMOALCLVE As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboMOALCLVE)
            Dim boMOALESTA As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboMOALESTA)
            Dim boMOALUSUA As Boolean = False

            Dim stMOALUSUA As String = fun_ConsultaNombreUsuario(Me.cboMOALNUDO.SelectedValue)

            If Trim(stMOALUSUA) = "" Then
                boMOALUSUA = False
                MessageBox.Show("El funcionario seleccionado no registra un perfil de usuario", "Mensaje...", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1)
            Else
                boMOALUSUA = True
            End If

            ' verifica los datos del formulario 
            If boLLAVEPRIMARIA = True And _
               boMOALMUNI = True And _
               boMOALCORR = True And _
               boMOALBARR = True And _
               boMOALMANZ = True And _
               boMOALPRED = True And _
               boMOALCLSE = True And _
               boMOALVIGE = True And _
               boMOALCAAC = True And _
               boMOALCLVE = True And _
               boMOALUSUA = True And _
               boMOALESTA = True Then

                Dim stMOALFFMU As String = ""
                Dim stMOALFEAS As String = fun_fecha()

                stMOALFEAS = stMOALFEAS.ToString.Replace("/", "-")

                Dim stOBSE_NUEVA As String = Trim(Me.txtMOALOBSE.Text)

                If Trim(stOBSE_NUEVA) <> "" Then
                    stOBSE_NUEVA = " Nota ingresada por: " & vp_usuario & " " & fun_fecha() & " : " & stOBSE_NUEVA & ". "
                End If

                Dim objdatos22 As New cla_MOVIALFA

                If (objdatos22.fun_Insertar_MOVIALFA(Me.txtMOALSECU.Text, _
                                                     Me.txtMOALMUNI.Text, _
                                                     Me.txtMOALCORR.Text, _
                                                     Me.txtMOALBARR.Text, _
                                                     Me.txtMOALMANZ.Text, _
                                                     Me.txtMOALPRED.Text, _
                                                     Me.cboMOALCLSE.SelectedValue, _
                                                     Me.cboMOALVIGE.SelectedValue, _
                                                     Me.cboMOALNUDO.SelectedValue, _
                                                     stMOALUSUA, _
                                                     stMOALFEAS, _
                                                     Me.cboMOALCAAC.SelectedValue, _
                                                     Me.cboMOALCLVE.SelectedValue, _
                                                     stMOALFFMU, _
                                                     stOBSE_NUEVA, _
                                                     Me.cboMOALESTA.SelectedValue)) = True Then

                    ' instancia la clase
                    Dim objRutas As New cla_RUTAS
                    Dim tblRutas As New DataTable

                    tblRutas = objRutas.fun_Buscar_CODIGO_MANT_RUTAS(16)

                    If tblRutas.Rows.Count > 0 Then

                        Dim stRuta As String = Me.txtMOALMUNI.Text & "-" & Me.cboMOALCLSE.SelectedValue & "-" & Me.txtMOALCORR.Text & "-" & Me.txtMOALBARR.Text & "-" & Me.txtMOALMANZ.Text & "-" & Me.txtMOALPRED.Text & "-" & Me.cboMOALVIGE.SelectedValue

                        If System.IO.Directory.Exists(Trim(tblRutas.Rows(0).Item("RUTARUTA")) & "\" & stRuta) = False Then

                            System.IO.Directory.CreateDirectory(Trim(tblRutas.Rows(0).Item("RUTARUTA")) & "\" & stRuta)

                        End If

                    End If

                    mod_MENSAJE.Se_Guardaron_Los_Datos_Correctamente()

                    Dim objdatos1 As New cla_MOVIALFA
                    Dim tbl1 As New DataTable

                    tbl1 = objdatos1.fun_Buscar_CODIGO_X_MOVIALFA(CInt(Me.txtMOALSECU.Text))

                    If tbl1.Rows.Count > 0 Then

                        Dim inNroIdRe As New frm_MOVIALFA(tbl1.Rows(0).Item("MOALIDRE"))

                    End If

                    Me.txtMOALMUNI.Focus()
                    Me.Close()

                Else
                    mod_MENSAJE.No_Se_Guardo_El_Registro_En_La_Base_De_Datos()

                End If
            End If


        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub cmdCANCELAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSALIR.Click
        Dim inNroIdRe As New frm_MOVIALFA(0)
        Me.txtMOALMUNI.Focus()
        Me.Close()
    End Sub

#End Region

#Region "FORMULARIO"

#Region "Load"

    Private Sub frm_insertar_TRABCAMP_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        pro_LimpiarCampos()
        Me.txtMOALSECU.Text = fun_NumeroDeSecuenciaDeRegistro()
        Me.txtMOALMUNI.Focus()

    End Sub

#End Region

#Region "KeyPress"

    Private Sub txt_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtMOALMUNI.KeyPress, txtMOALCORR.KeyPress, txtMOALMANZ.KeyPress, txtMOALBARR.KeyPress, txtMOALPRED.KeyPress, cboMOALCLSE.KeyPress, cboMOALVIGE.KeyPress, cboMOALCAAC.KeyPress, cboMOALESTA.KeyPress, cboMOALNUDO.KeyPress, cboMOALCLVE.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Or e.KeyChar = Convert.ToChar(Keys.Tab) Then
            pp_pro_SaltarCampo()
        End If
    End Sub

#End Region

#Region "KeyDown"

    Private Sub cboTRCACLSE_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboMOALCLSE.KeyDown
        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
            fun_Cargar_ComboBox_Con_Datos_Activos_CLASSECT_Descripcion(Me.cboMOALCLSE, Me.cboMOALCLSE.SelectedIndex)
        End If
    End Sub
    Private Sub cboTRCAVIGE_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboMOALVIGE.KeyDown
        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
            fun_Cargar_ComboBox_Con_Datos_Activos_VIGENCIA_Descripcion(Me.cboMOALVIGE, Me.cboMOALVIGE.SelectedIndex)
        End If
    End Sub
    Private Sub cboMOALNUDO_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboMOALNUDO.KeyDown
        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
            fun_Cargar_ComboBox_Con_Datos_Activos_USUARIO_Descripcion(Me.cboMOALNUDO, Me.cboMOALNUDO.SelectedIndex)
        End If
    End Sub
    Private Sub cboTRCACAAC_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboMOALCAAC.KeyDown
        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
            fun_Cargar_ComboBox_Con_Datos_Activos_CAUSACTO_Descripcion(Me.cboMOALCAAC, Me.cboMOALCAAC.SelectedIndex)
        End If
    End Sub
    Private Sub cboTRCACLVE_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboMOALCLVE.KeyDown
        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
            fun_Cargar_ComboBox_Con_Datos_Activos_CLASVERS_Descripcion(Me.cboMOALCLVE, Me.cboMOALCLVE.SelectedIndex)
        End If
    End Sub
    Private Sub cboTRCAESTA_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboMOALESTA.KeyDown
        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
            fun_Cargar_ComboBox_Con_Datos_Activos_ESTADO(Me.cboMOALESTA, Me.cboMOALESTA.SelectedIndex)
        End If
    End Sub

#End Region

#Region "GotFocus"

    Private Sub txt_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtMOALMUNI.GotFocus, txtMOALCORR.GotFocus, txtMOALBARR.GotFocus, txtMOALMANZ.GotFocus, txtMOALPRED.GotFocus, txtMOALOBSE.GotFocus
        pp_pro_SobrearCampo(sender)
        pp_pro_DescripcionCampo(Me.strBARRESTA.Items(0), sender)
    End Sub
    Private Sub cmd_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdGUARDAR.GotFocus, cmdSALIR.GotFocus
        pp_pro_DescripcionCampo(Me.strBARRESTA.Items(0), sender)
    End Sub
    Private Sub cbo_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboMOALCLSE.GotFocus, cboMOALVIGE.GotFocus, cboMOALCAAC.GotFocus, cboMOALESTA.GotFocus, cboMOALNUDO.GotFocus, cboMOALCLVE.GotFocus
        pp_pro_DescripcionCampo(Me.strBARRESTA.Items(0), sender)
    End Sub

#End Region

#Region "SelectedIndexChanged"

    Private Sub cboTRCACLSE_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboMOALCLSE.SelectedIndexChanged
        Me.lblMOALCLSE.Text = CType(fun_Buscar_Lista_Valores_CLASSECT_Codigo(Me.cboMOALCLSE), String)
    End Sub
    Private Sub cboTRCAVIGE_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboMOALVIGE.SelectedIndexChanged
        Me.lblMOALVIGE.Text = CType(fun_Buscar_Lista_Valores_VIGENCIA_Codigo(Me.cboMOALVIGE), String)
    End Sub
    Private Sub cboTRCACAAC_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboMOALCAAC.SelectedIndexChanged
        Me.lblMOALCAAC.Text = CType(fun_Buscar_Lista_Valores_CAUSACTO_Codigo(Me.cboMOALCAAC), String)
    End Sub
    Private Sub cboTRCACLVE_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboMOALCLVE.SelectedIndexChanged
        Me.lblMOALCLVE.Text = CType(fun_Buscar_Lista_Valores_CLASVERS_Codigo(Me.cboMOALCLVE), String)
    End Sub
    Private Sub cboMOALNUDO_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboMOALNUDO.SelectedIndexChanged
        Me.lblMOALNUDO.Text = CType(fun_Buscar_Lista_Valores_USUARIO_Codigo(Me.cboMOALNUDO), String)
    End Sub

#End Region

#Region "Click"

    Private Sub cboTRCACLSE_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboMOALCLSE.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_CLASSECT_Descripcion(Me.cboMOALCLSE, Me.cboMOALCLSE.SelectedIndex)
    End Sub
    Private Sub cboTRCAVIGE_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboMOALVIGE.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_VIGENCIA_Descripcion(Me.cboMOALVIGE, Me.cboMOALVIGE.SelectedIndex)
    End Sub
    Private Sub cboTRCACAAC_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboMOALCAAC.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_CAUSACTO_Descripcion(Me.cboMOALCAAC, Me.cboMOALCAAC.SelectedIndex)
    End Sub
    Private Sub cboTRCACLVA_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboMOALCLVE.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_CLASVERS_Descripcion(Me.cboMOALCLVE, Me.cboMOALCLVE.SelectedIndex)
    End Sub
    Private Sub cboTRCANUDO_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboMOALNUDO.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_USUARIO_Descripcion(Me.cboMOALNUDO, Me.cboMOALNUDO.SelectedIndex)
    End Sub
    Private Sub cboTRCAESTA_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboMOALESTA.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_ESTADO(Me.cboMOALESTA, Me.cboMOALESTA.SelectedIndex)
    End Sub

#End Region

#Region "Validated"

    Private Sub txtTRCAMUNI_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtMOALMUNI.Validated
        If Me.txtMOALMUNI.Text <> "" And fun_Verificar_Dato_Numerico_Evento_Validated(Me.txtMOALMUNI.Text) = True Then
            Me.txtMOALMUNI.Text = fun_Formato_Mascara_3_String(Me.txtMOALMUNI.Text)
        End If
    End Sub
    Private Sub txtTRCACORR_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtMOALCORR.Validated
        If Me.txtMOALCORR.Text <> "" And fun_Verificar_Dato_Numerico_Evento_Validated(Me.txtMOALCORR.Text) = True Then
            Me.txtMOALCORR.Text = fun_Formato_Mascara_2_String(Me.txtMOALCORR.Text)
        End If
    End Sub
    Private Sub txtTRCABARR_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtMOALBARR.Validated
        If Me.txtMOALBARR.Text <> "" And fun_Verificar_Dato_Numerico_Evento_Validated(Me.txtMOALBARR.Text) = True Then
            Me.txtMOALBARR.Text = fun_Formato_Mascara_3_String(Me.txtMOALBARR.Text)
        End If
    End Sub
    Private Sub txtTRCAMANZ_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtMOALMANZ.Validated
        If Me.txtMOALMANZ.Text <> "" And fun_Verificar_Dato_Numerico_Evento_Validated(Me.txtMOALMANZ.Text) = True Then
            Me.txtMOALMANZ.Text = fun_Formato_Mascara_3_String(Me.txtMOALMANZ.Text)
        End If
    End Sub
    Private Sub txtTRCAPRED_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtMOALPRED.Validated
        If Me.txtMOALPRED.Text <> "" And fun_Verificar_Dato_Numerico_Evento_Validated(Me.txtMOALPRED.Text) = True Then
            Me.txtMOALPRED.Text = fun_Formato_Mascara_5_String(Me.txtMOALPRED.Text)
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