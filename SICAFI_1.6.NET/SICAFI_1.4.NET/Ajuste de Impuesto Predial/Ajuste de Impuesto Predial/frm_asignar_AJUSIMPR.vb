Imports REGLAS_DEL_NEGOCIO

Public Class frm_asignar_AJUSIMPR

    '=====================================
    '*** ASIGNACIÓN AJUSTE DE IMPUESTO ***
    '=====================================

#Region "VARIABLE"

    Dim inID_REGISTRO As Integer = 0

    Dim vl_stAJIPNUDO As String = ""
    Dim vl_stAJIPREMI As String = ""
    Dim vl_stAJIPUSUR As String = ""
    Dim vl_stAJIPFECR As String = ""
    Dim vl_stAJIPDEST As String = ""
    Dim vl_stAJIPUSUD As String = ""
    Dim vl_stAJIPFECD As String = ""

#End Region

#Region "CONSTRUCTOR"

    Public Sub New(ByVal inIDRE As Integer, ByVal stNUDO As String)

        inID_REGISTRO = inIDRE
        vl_stAJIPNUDO = Trim(stNUDO)

        InitializeComponent()
        pro_LimpiarCampos()
        pro_inicializarControles()

    End Sub

#End Region

#Region "PROCEDIMIENTOS"

    Private Sub pro_LimpiarCampos()

        Me.cboAJIPNUDO.DataSource = New DataTable

        Me.lblAJIPNUDO.Text = ""
        Me.txtAJIPFEAS.Text = ""
        Me.txtAJIPOBSE.Text = ""

    End Sub
    Private Sub pro_inicializarControles()

        Try
            pro_LimpiarCampos()
            Me.txtAJIPFEAS.Text = fun_fecha()

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub

#End Region

#Region "MENU"

    Private Sub cmdGUARDAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGUARDAR.Click

        Try
            ' instancia la clase
            Dim objVerifica As New cla_Verificar_Dato

            Dim boAJIPNUDO As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.lblAJIPNUDO)
            Dim boAJIPFEAS As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Fecha(Me.txtAJIPFEAS)


            ' verifica los datos del formulario 
            If boAJIPNUDO = True And _
               boAJIPFEAS = True Then

                ' instancia la clase
                Dim obCONTRASENA1 As New cla_CONTRASENA
                Dim dtCONTRASENA1 As New DataTable

                dtCONTRASENA1 = obCONTRASENA1.fun_Buscar_CODIGO_CONTRASENA(Trim(vl_stAJIPNUDO))

                If dtCONTRASENA1.Rows.Count > 0 Then

                    vl_stAJIPREMI = Trim(dtCONTRASENA1.Rows(0).Item("CONTNUDO").ToString)
                    vl_stAJIPUSUR = Trim(dtCONTRASENA1.Rows(0).Item("CONTUSUA").ToString)
                    vl_stAJIPFECR = Me.txtAJIPFEAS.Text

                End If

                ' instancia la clase
                Dim obCONTRASENA2 As New cla_CONTRASENA
                Dim dtCONTRASENA2 As New DataTable

                dtCONTRASENA2 = obCONTRASENA2.fun_Buscar_CODIGO_CONTRASENA(Trim(Me.lblAJIPNUDO.Text))

                If dtCONTRASENA2.Rows.Count > 0 Then

                    vl_stAJIPDEST = Trim(dtCONTRASENA2.Rows(0).Item("CONTNUDO").ToString)
                    vl_stAJIPUSUD = Trim(dtCONTRASENA2.Rows(0).Item("CONTUSUA").ToString)
                    vl_stAJIPFECD = Me.txtAJIPFEAS.Text

                End If

                If dtCONTRASENA1.Rows.Count > 0 And dtCONTRASENA2.Rows.Count > 0 Then

                    Dim stESTADO As String = "as"
                    Dim stRECLOBSE_ACTUAL As String = ""
                    Dim stRECLOBSE_NUEVA As String = Trim(Me.txtAJIPOBSE.Text)

                    Dim obAJUSIMPR As New cla_AJUSIMPR
                    Dim dtAJUSIMPR As New DataTable

                    dtAJUSIMPR = obAJUSIMPR.fun_Buscar_ID_AJUSIMPR(inID_REGISTRO)

                    If dtAJUSIMPR.Rows.Count > 0 Then

                        stRECLOBSE_ACTUAL = Trim(dtAJUSIMPR.Rows(0).Item("AJIPOBSE").ToString)

                    End If

                    If Trim(stRECLOBSE_ACTUAL) <> "" And Trim(stRECLOBSE_NUEVA) <> "" Then
                        stRECLOBSE_ACTUAL += vbCrLf & " Nota ingresada por " & vp_usuario & " " & fun_fecha() & " : " & stRECLOBSE_NUEVA & ". "

                    ElseIf Trim(stRECLOBSE_ACTUAL) = "" And Trim(stRECLOBSE_NUEVA) <> "" Then
                        stRECLOBSE_ACTUAL += " Nota ingresada por " & vp_usuario & " " & fun_fecha() & " : " & stRECLOBSE_NUEVA & ". "

                    ElseIf Trim(stRECLOBSE_ACTUAL) <> "" And Trim(stRECLOBSE_NUEVA) = "" Then
                        stRECLOBSE_ACTUAL += " Nota ingresada por " & vp_usuario & " " & fun_fecha() & " : " & stRECLOBSE_ACTUAL & ". "

                    End If

                    Dim objdatos22 As New cla_AJUSIMPR

                    If (objdatos22.fun_Actualizar_Asignar_Tramite(inID_REGISTRO, _
                                                                   vl_stAJIPREMI, _
                                                                   vl_stAJIPUSUR, _
                                                                   vl_stAJIPFECR, _
                                                                   vl_stAJIPDEST, _
                                                                   vl_stAJIPUSUD, _
                                                                   vl_stAJIPFECD, _
                                                                   stRECLOBSE_ACTUAL, _
                                                                   stESTADO, _
                                                                   stESTADO)) = True Then

                        mod_MENSAJE.Se_Modificaron_Los_Datos_Correctamente()
                        Me.cboAJIPNUDO.Focus()
                        Me.Close()
                    Else
                        mod_MENSAJE.No_Se_Modifico_El_Registro_En_La_Base_De_Datos()
                    End If
                Else
                    mod_MENSAJE.No_Se_Modifico_El_Registro_En_La_Base_De_Datos()
                End If

            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub cmdCANCELAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSALIR.Click
        Me.cboAJIPNUDO.Focus()
        Me.Close()
    End Sub

#End Region

#Region "FORMULARIO"

#Region "KeyPress"

    Private Sub txt_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboAJIPNUDO.KeyPress, txtAJIPFEAS.KeyPress, txtAJIPOBSE.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Or e.KeyChar = Convert.ToChar(Keys.Tab) Then
            pp_pro_SaltarCampo()
        End If
    End Sub

#End Region

#Region "GotFocus"

    Private Sub txt_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtAJIPFEAS.GotFocus, txtAJIPOBSE.GotFocus
        pp_pro_SobrearCampo(sender)
        pp_pro_DescripcionCampo(Me.strBARRESTA.Items(0), sender)
    End Sub
    Private Sub cbo_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboAJIPNUDO.GotFocus
        pp_pro_DescripcionCampo(Me.strBARRESTA.Items(0), sender)
    End Sub
    Private Sub cmd_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdGUARDAR.GotFocus, cmdSALIR.GotFocus
        pp_pro_DescripcionCampo(Me.strBARRESTA.Items(0), sender)
    End Sub

#End Region

#Region "KeyDown"

    Private Sub cboLEVANUDO_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboAJIPNUDO.KeyDown
        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
            fun_Cargar_ComboBox_Con_Datos_Activos_USUARIO_Descripcion(Me.cboAJIPNUDO, Me.cboAJIPNUDO.SelectedIndex)
        End If
    End Sub

#End Region

#Region "SelectedIndexChanged"

    Private Sub cboLEVANUDO_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboAJIPNUDO.SelectedIndexChanged
        Me.lblAJIPNUDO.Text = CType(fun_Buscar_Lista_Valores_USUARIO_Codigo(Me.cboAJIPNUDO), String)
    End Sub

#End Region

#Region "Click"

    Private Sub cboLEVANUDO_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboAJIPNUDO.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_USUARIO_Descripcion(Me.cboAJIPNUDO, Me.cboAJIPNUDO.SelectedIndex)
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