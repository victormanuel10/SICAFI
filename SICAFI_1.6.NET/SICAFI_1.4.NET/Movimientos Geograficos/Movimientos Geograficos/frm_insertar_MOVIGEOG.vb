Imports REGLAS_DEL_NEGOCIO
Imports System.IO

Public Class frm_insertar_MOVIGEOG

    '======================================
    '*** INSERTAR MOVIMIENTO GEOGRAFICO ***
    '======================================

#Region "PROCEDIMIENTOS"

    Private Sub pro_LimpiarCampos()

        Me.cboMOGECLSE.DataSource = New DataTable
        Me.cboMOGEVIGE.DataSource = New DataTable
        Me.cboMOGECAAC.DataSource = New DataTable
        Me.cboMOGEVIGE.DataSource = New DataTable
        Me.cboMOGECLVE.DataSource = New DataTable
        Me.cboMOGEESTA.DataSource = New DataTable
        Me.cboMOGENUDO.DataSource = New DataTable

        Me.txtMOGESECU.Text = ""
        Me.lblMOGECLSE.Text = ""
        Me.lblMOGEVIGE.Text = ""
        Me.lblMOGECAAC.Text = ""
        Me.lblMOGECLVE.Text = ""
        Me.lblMOGENUDO.Text = ""
        Me.txtMOGEMUNI.Text = "266"
        Me.txtMOGECORR.Text = "01"
        Me.txtMOGEBARR.Text = ""
        Me.txtMOGEMANZ.Text = ""
        Me.txtMOGEPRED.Text = ""
        Me.txtMOGEOBSE.Text = ""

    End Sub

#End Region

#Region "FUNCIONES"

    Private Function fun_NumeroDeSecuenciaDeRegistro() As Integer

        Try
            Dim inFPDESECU As Integer = 0

            Dim objdatos5 As New cla_MOVIGEOG
            Dim tbl10 As New DataTable

            tbl10 = objdatos5.fun_Buscar_SECUENCIA_X_MOVIGEOG

            If tbl10.Rows.Count = 0 Then
                inFPDESECU = 1
            Else
                Dim i As Integer
                Dim NroMayor As Integer
                Dim Posicion As Integer

                Posicion = Val(tbl10.Rows(0).Item("MOGESECU"))

                For i = 0 To tbl10.Rows.Count - 1
                    NroMayor = Val(tbl10.Rows(i).Item("MOGESECU"))

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
            Dim objdatos As New cla_MOVIGEOG

            Dim boLLAVEPRIMARIA As Boolean = objdatos.fun_Verifica_llave_Primaria_MOVIGEOG(Me.txtMOGEMUNI, Me.txtMOGECORR, Me.txtMOGEBARR, Me.txtMOGEMANZ, Me.txtMOGEPRED, Me.cboMOGECLSE, Me.cboMOGEVIGE)

            ' instancia la clase
            Dim objVerifica As New cla_Verificar_Dato

            Dim boMOGEMUNI As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Numerico(Me.txtMOGEMUNI)
            Dim boMOGECORR As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Numerico(Me.txtMOGECORR)
            Dim boMOGEBARR As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Numerico(Me.txtMOGEBARR)
            Dim boMOGEMANZ As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Numerico(Me.txtMOGEMANZ)
            Dim boMOGEPRED As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Numerico(Me.txtMOGEPRED)
            Dim boMOGECLSE As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboMOGECLSE)
            Dim boMOGEVIGE As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboMOGEVIGE)
            Dim boMOGECAAC As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboMOGECAAC)
            Dim boMOGECLVE As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboMOGECLVE)
            Dim boMOGEESTA As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboMOGEESTA)
            Dim boMOGEUSUA As Boolean = False

            Dim stMOGEUSUA As String = fun_ConsultaNombreUsuario(Me.cboMOGENUDO.SelectedValue)

            If Trim(stMOGEUSUA) = "" Then
                boMOGEUSUA = False
                MessageBox.Show("El funcionario seleccionado no registra un perfil de usuario", "Mensaje...", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1)
            Else
                boMOGEUSUA = True
            End If

            ' verifica los datos del formulario 
            If boLLAVEPRIMARIA = True And _
               boMOGEMUNI = True And _
               boMOGECORR = True And _
               boMOGEBARR = True And _
               boMOGEMANZ = True And _
               boMOGEPRED = True And _
               boMOGECLSE = True And _
               boMOGEVIGE = True And _
               boMOGECAAC = True And _
               boMOGECLVE = True And _
               boMOGEUSUA = True And _
               boMOGEESTA = True Then

                Dim stMOGEFFMU As String = ""
                Dim stMOGEFEAS As String = fun_fecha()

                stMOGEFEAS = stMOGEFEAS.ToString.Replace("/", "-")

                Dim stOBSE_NUEVA As String = Trim(Me.txtMOGEOBSE.Text)

                If Trim(stOBSE_NUEVA) <> "" Then
                    stOBSE_NUEVA = " Nota ingresada por: " & vp_usuario & " " & fun_fecha() & " : " & stOBSE_NUEVA & ". "
                End If

                Dim objdatos22 As New cla_MOVIGEOG

                If (objdatos22.fun_Insertar_MOVIGEOG(Me.txtMOGESECU.Text, _
                                                     Me.txtMOGEMUNI.Text, _
                                                     Me.txtMOGECORR.Text, _
                                                     Me.txtMOGEBARR.Text, _
                                                     Me.txtMOGEMANZ.Text, _
                                                     Me.txtMOGEPRED.Text, _
                                                     Me.cboMOGECLSE.SelectedValue, _
                                                     Me.cboMOGEVIGE.SelectedValue, _
                                                     Me.cboMOGENUDO.SelectedValue, _
                                                     stMOGEUSUA, _
                                                     stMOGEFEAS, _
                                                     Me.cboMOGECAAC.SelectedValue, _
                                                     Me.cboMOGECLVE.SelectedValue, _
                                                     stMOGEFFMU, _
                                                     stOBSE_NUEVA, _
                                                     Me.cboMOGEESTA.SelectedValue)) = True Then

                    ' instancia la clase
                    Dim objRutas As New cla_RUTAS
                    Dim tblRutas As New DataTable

                    tblRutas = objRutas.fun_Buscar_CODIGO_MANT_RUTAS(13)

                    If tblRutas.Rows.Count > 0 Then

                        Dim stRuta As String = Me.txtMOGEMUNI.Text & "-" & Me.cboMOGECLSE.SelectedValue & "-" & Me.txtMOGECORR.Text & "-" & Me.txtMOGEBARR.Text & "-" & Me.txtMOGEMANZ.Text & "-" & Me.txtMOGEPRED.Text & "-" & Me.cboMOGEVIGE.SelectedValue

                        If System.IO.Directory.Exists(Trim(tblRutas.Rows(0).Item("RUTARUTA")) & "\" & stRuta) = False Then

                            System.IO.Directory.CreateDirectory(Trim(tblRutas.Rows(0).Item("RUTARUTA")) & "\" & stRuta)

                        End If

                    End If

                    mod_MENSAJE.Se_Guardaron_Los_Datos_Correctamente()

                    Dim objdatos1 As New cla_MOVIGEOG
                    Dim tbl1 As New DataTable

                    tbl1 = objdatos1.fun_Buscar_CODIGO_X_MOVIGEOG(CInt(Me.txtMOGESECU.Text))

                    If tbl1.Rows.Count > 0 Then

                        Dim inNroIdRe As New frm_MOVIGEOG(tbl1.Rows(0).Item("MOGEIDRE"))

                    End If

                    Me.txtMOGEMUNI.Focus()
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
        Dim inNroIdRe As New frm_MOVIGEOG(0)
        Me.txtMOGEMUNI.Focus()
        Me.Close()
    End Sub

#End Region

#Region "FORMULARIO"

#Region "Load"

    Private Sub frm_insertar_TRABCAMP_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        pro_LimpiarCampos()
        Me.txtMOGESECU.Text = fun_NumeroDeSecuenciaDeRegistro()
        Me.txtMOGEMUNI.Focus()

    End Sub

#End Region

#Region "KeyPress"

    Private Sub txt_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtMOGEMUNI.KeyPress, txtMOGECORR.KeyPress, txtMOGEMANZ.KeyPress, txtMOGEBARR.KeyPress, txtMOGEPRED.KeyPress, cboMOGECLSE.KeyPress, cboMOGEVIGE.KeyPress, cboMOGECAAC.KeyPress, cboMOGEESTA.KeyPress, cboMOGENUDO.KeyPress, cboMOGECLVE.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Or e.KeyChar = Convert.ToChar(Keys.Tab) Then
            pp_pro_SaltarCampo()
        End If
    End Sub

#End Region

#Region "KeyDown"

    Private Sub cboTRCACLSE_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboMOGECLSE.KeyDown
        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
            fun_Cargar_ComboBox_Con_Datos_Activos_CLASSECT_Descripcion(Me.cboMOGECLSE, Me.cboMOGECLSE.SelectedIndex)
        End If
    End Sub
    Private Sub cboTRCAVIGE_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboMOGEVIGE.KeyDown
        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
            fun_Cargar_ComboBox_Con_Datos_Activos_VIGENCIA_Descripcion(Me.cboMOGEVIGE, Me.cboMOGEVIGE.SelectedIndex)
        End If
    End Sub
    Private Sub cboMOGENUDO_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboMOGENUDO.KeyDown
        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
            fun_Cargar_ComboBox_Con_Datos_Activos_USUARIO_Descripcion(Me.cboMOGENUDO, Me.cboMOGENUDO.SelectedIndex)
        End If
    End Sub
    Private Sub cboTRCACAAC_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboMOGECAAC.KeyDown
        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
            fun_Cargar_ComboBox_Con_Datos_Activos_CAUSACTO_Descripcion(Me.cboMOGECAAC, Me.cboMOGECAAC.SelectedIndex)
        End If
    End Sub
    Private Sub cboTRCACLVE_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboMOGECLVE.KeyDown
        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
            fun_Cargar_ComboBox_Con_Datos_Activos_CLASVERS_Descripcion(Me.cboMOGECLVE, Me.cboMOGECLVE.SelectedIndex)
        End If
    End Sub
    Private Sub cboTRCAESTA_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboMOGEESTA.KeyDown
        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
            fun_Cargar_ComboBox_Con_Datos_Activos_ESTADO(Me.cboMOGEESTA, Me.cboMOGEESTA.SelectedIndex)
        End If
    End Sub

#End Region

#Region "GotFocus"

    Private Sub txt_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtMOGEMUNI.GotFocus, txtMOGECORR.GotFocus, txtMOGEBARR.GotFocus, txtMOGEMANZ.GotFocus, txtMOGEPRED.GotFocus, txtMOGEOBSE.GotFocus
        pp_pro_SobrearCampo(sender)
        pp_pro_DescripcionCampo(Me.strBARRESTA.Items(0), sender)
    End Sub
    Private Sub cmd_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdGUARDAR.GotFocus, cmdSALIR.GotFocus
        pp_pro_DescripcionCampo(Me.strBARRESTA.Items(0), sender)
    End Sub
    Private Sub cbo_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboMOGECLSE.GotFocus, cboMOGEVIGE.GotFocus, cboMOGECAAC.GotFocus, cboMOGEESTA.GotFocus, cboMOGENUDO.GotFocus, cboMOGECLVE.GotFocus
        pp_pro_DescripcionCampo(Me.strBARRESTA.Items(0), sender)
    End Sub

#End Region

#Region "SelectedIndexChanged"

    Private Sub cboTRCACLSE_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboMOGECLSE.SelectedIndexChanged
        Me.lblMOGECLSE.Text = CType(fun_Buscar_Lista_Valores_CLASSECT_Codigo(Me.cboMOGECLSE), String)
    End Sub
    Private Sub cboTRCAVIGE_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboMOGEVIGE.SelectedIndexChanged
        Me.lblMOGEVIGE.Text = CType(fun_Buscar_Lista_Valores_VIGENCIA_Codigo(Me.cboMOGEVIGE), String)
    End Sub
    Private Sub cboTRCACAAC_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboMOGECAAC.SelectedIndexChanged
        Me.lblMOGECAAC.Text = CType(fun_Buscar_Lista_Valores_CAUSACTO_Codigo(Me.cboMOGECAAC), String)
    End Sub
    Private Sub cboTRCACLVE_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboMOGECLVE.SelectedIndexChanged
        Me.lblMOGECLVE.Text = CType(fun_Buscar_Lista_Valores_CLASVERS_Codigo(Me.cboMOGECLVE), String)
    End Sub
    Private Sub cboMOGENUDO_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboMOGENUDO.SelectedIndexChanged
        Me.lblMOGENUDO.Text = CType(fun_Buscar_Lista_Valores_USUARIO_Codigo(Me.cboMOGENUDO), String)
    End Sub

#End Region

#Region "Click"

    Private Sub cboTRCACLSE_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboMOGECLSE.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_CLASSECT_Descripcion(Me.cboMOGECLSE, Me.cboMOGECLSE.SelectedIndex)
    End Sub
    Private Sub cboTRCAVIGE_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboMOGEVIGE.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_VIGENCIA_Descripcion(Me.cboMOGEVIGE, Me.cboMOGEVIGE.SelectedIndex)
    End Sub
    Private Sub cboTRCACAAC_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboMOGECAAC.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_CAUSACTO_Descripcion(Me.cboMOGECAAC, Me.cboMOGECAAC.SelectedIndex)
    End Sub
    Private Sub cboTRCACLVA_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboMOGECLVE.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_CLASVERS_Descripcion(Me.cboMOGECLVE, Me.cboMOGECLVE.SelectedIndex)
    End Sub
    Private Sub cboTRCANUDO_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboMOGENUDO.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_USUARIO_Descripcion(Me.cboMOGENUDO, Me.cboMOGENUDO.SelectedIndex)
    End Sub
    Private Sub cboTRCAESTA_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboMOGEESTA.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_ESTADO(Me.cboMOGEESTA, Me.cboMOGEESTA.SelectedIndex)
    End Sub

#End Region

#Region "Validated"

    Private Sub txtTRCAMUNI_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtMOGEMUNI.Validated
        If Me.txtMOGEMUNI.Text <> "" And fun_Verificar_Dato_Numerico_Evento_Validated(Me.txtMOGEMUNI.Text) = True Then
            Me.txtMOGEMUNI.Text = fun_Formato_Mascara_3_String(Me.txtMOGEMUNI.Text)
        End If
    End Sub
    Private Sub txtTRCACORR_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtMOGECORR.Validated
        If Me.txtMOGECORR.Text <> "" And fun_Verificar_Dato_Numerico_Evento_Validated(Me.txtMOGECORR.Text) = True Then
            Me.txtMOGECORR.Text = fun_Formato_Mascara_2_String(Me.txtMOGECORR.Text)
        End If
    End Sub
    Private Sub txtTRCABARR_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtMOGEBARR.Validated
        If Me.txtMOGEBARR.Text <> "" And fun_Verificar_Dato_Numerico_Evento_Validated(Me.txtMOGEBARR.Text) = True Then
            Me.txtMOGEBARR.Text = fun_Formato_Mascara_3_String(Me.txtMOGEBARR.Text)
        End If
    End Sub
    Private Sub txtTRCAMANZ_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtMOGEMANZ.Validated
        If Me.txtMOGEMANZ.Text <> "" And fun_Verificar_Dato_Numerico_Evento_Validated(Me.txtMOGEMANZ.Text) = True Then
            Me.txtMOGEMANZ.Text = fun_Formato_Mascara_3_String(Me.txtMOGEMANZ.Text)
        End If
    End Sub
    Private Sub txtTRCAPRED_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtMOGEPRED.Validated
        If Me.txtMOGEPRED.Text <> "" And fun_Verificar_Dato_Numerico_Evento_Validated(Me.txtMOGEPRED.Text) = True Then
            Me.txtMOGEPRED.Text = fun_Formato_Mascara_5_String(Me.txtMOGEPRED.Text)
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