Imports REGLAS_DEL_NEGOCIO

Public Class frm_insertar_LIRASOLI

    '========================================
    '*** INSERTAR INFORMACIÓN SOLICITANTE ***
    '========================================

#Region "VARIABLE"

    Dim inLRSOIDRE As Integer
    Dim inLRSOSECU As Integer
    Dim inLRSONURA As Integer
    Dim stLRSOFERA As String

    Dim boINSERTAR As Boolean = False
    Dim boMODIFICAR As Boolean = False

#End Region

#Region "CONSTRUCTOR"

    Public Sub New(ByVal inIDRE As Integer, ByVal inSECU As Integer, ByVal inNURA As Integer, ByVal stFERA As String)
        inLRSOIDRE = inIDRE
        inLRSOSECU = inSECU
        inLRSONURA = inNURA
        stLRSOFERA = stFERA

        boMODIFICAR = True

        InitializeComponent()
        pro_LimpiarCampos()
        pro_inicializarControles()

    End Sub
    Public Sub New(ByVal inSECU As Integer, ByVal inNURA As Integer, ByVal stFERA As String)
        inLRSOSECU = inSECU
        inLRSONURA = inNURA
        stLRSOFERA = stFERA

        boINSERTAR = True

        InitializeComponent()
        pro_LimpiarCampos()
        pro_inicializarControles()
    End Sub

#End Region

#Region "PROCEDIMIENTOS"

    Private Sub pro_LimpiarCampos()

        Me.txtLRSONUDO.Text = ""
        Me.txtLRSONOMB.Text = ""
        Me.txtLRSOPRAP.Text = ""
        Me.txtLRSOSEAP.Text = ""
        Me.txtLRSOTELE.Text = ""
        Me.txtLRSOCELU.Text = ""
        Me.txtLRSOCOEL.Text = ""
        Me.txtLRSODIPR.Text = ""
        Me.txtLRSODINO.Text = ""
        Me.txtLRSOCOPO.Text = ""
        Me.txtLRSORESO.Text = ""
        Me.lblLRSOSOLI.Text = ""

        Me.cboLRSOSOLI.DataSource = New DataTable

    End Sub
    Private Sub pro_inicializarControles()

        Try
            If boMODIFICAR = True Then

                ' instancia la clase
                Dim objdatos As New cla_LIRASOLI
                Dim tbl As New DataTable

                tbl = objdatos.fun_Buscar_ID_LIRASOLI(inLRSOIDRE)

                If tbl.Rows.Count > 0 Then

                    Me.Text = "Modificar registro"
                    Me.fraINFOUSUA.Text = "MODIFICAR SOLICITANTE"

                    Me.txtLRSONUDO.Text = Trim(tbl.Rows(0).Item("LRSONUDO"))
                    Me.txtLRSONOMB.Text = Trim(tbl.Rows(0).Item("LRSONOMB"))
                    Me.txtLRSOPRAP.Text = Trim(tbl.Rows(0).Item("LRSOPRAP"))
                    Me.txtLRSOSEAP.Text = Trim(tbl.Rows(0).Item("LRSOSEAP"))
                    Me.txtLRSOTELE.Text = Trim(tbl.Rows(0).Item("LRSOTELE"))
                    Me.txtLRSOCELU.Text = Trim(tbl.Rows(0).Item("LRSOCELU"))
                    Me.txtLRSOCOEL.Text = Trim(tbl.Rows(0).Item("LRSOCOEL"))
                    Me.txtLRSODIPR.Text = Trim(tbl.Rows(0).Item("LRSODIPR"))
                    Me.txtLRSODINO.Text = Trim(tbl.Rows(0).Item("LRSODINO"))
                    Me.txtLRSOCOPO.Text = Trim(tbl.Rows(0).Item("LRSOCOPO"))
                    Me.txtLRSORESO.Text = Trim(tbl.Rows(0).Item("LRSORESO"))

                    Dim objdatos9 As New cla_SOLICITANTE

                    Me.cboLRSOSOLI.DataSource = objdatos9.fun_Consultar_CAMPOS_MANT_SOLICITANTE
                    Me.cboLRSOSOLI.DisplayMember = "SOLIDESC"
                    Me.cboLRSOSOLI.ValueMember = "SOLICODI"

                    Me.cboLRSOSOLI.SelectedValue = tbl.Rows(0).Item("LRSOSOLI")

                    Me.lblLRSOSOLI.Text = CType(fun_Buscar_Lista_Valores_SOLICITANTE_Codigo(Me.cboLRSOSOLI), String)

                    Me.txtLRSONUDO.ReadOnly = True

                End If

            ElseIf boINSERTAR = True Then

                Me.Text = "Insertar registro"
                Me.fraINFOUSUA.Text = "INSERTAR SOLICITANTE"

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
                Dim objdatos As New cla_LIRASOLI

                Dim boLLAVEPRIMARIA As Boolean = objdatos.fun_Verifica_llave_Primaria_LIRASOLI(inLRSONURA, stLRSOFERA, inLRSOSECU, Me.txtLRSONUDO)

                ' instancia la clase
                Dim objVerifica As New cla_Verificar_Dato

                Dim boLRSONUDO As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.txtLRSONUDO)
                Dim boLRSONOMB As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.txtLRSONOMB)
                Dim boLRSOSOLI As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboLRSOSOLI)

                ' verifica los datos del formulario 
                If boLLAVEPRIMARIA = True And _
                   boLRSONUDO = True And _
                   boLRSONOMB = True And _
                   boLRSOSOLI = True Then

                    Dim objdatos22 As New cla_LIRASOLI

                    If (objdatos22.fun_Insertar_LIRASOLI(inLRSONURA, _
                                                         stLRSOFERA, _
                                                         inLRSOSECU, _
                                                         Me.txtLRSONUDO.Text, _
                                                         Me.txtLRSONOMB.Text, _
                                                         Me.txtLRSOPRAP.Text, _
                                                         Me.txtLRSOSEAP.Text, _
                                                         Me.txtLRSODIPR.Text, _
                                                         Me.txtLRSODINO.Text, _
                                                         Me.txtLRSOTELE.Text, _
                                                         Me.txtLRSOCELU.Text, _
                                                         Me.txtLRSOCOEL.Text, _
                                                         Me.txtLRSOCOPO.Text, _
                                                         Me.txtLRSORESO.Text, _
                                                         Me.cboLRSOSOLI.SelectedValue)) = True Then

                        mod_MENSAJE.Se_Guardaron_Los_Datos_Correctamente()
                        Me.txtLRSONUDO.Focus()
                        Me.Close()
                    Else
                        mod_MENSAJE.No_Se_Guardo_El_Registro_En_La_Base_De_Datos()
                    End If

                End If

                ' modifica el registro
            ElseIf boMODIFICAR = True Then

                ' instancia la clase
                Dim objVerifica As New cla_Verificar_Dato

                Dim boLRSONUDO As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.txtLRSONUDO)
                Dim boLRSONOMB As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.txtLRSONOMB)

                ' verifica los datos del formulario 
                If boLRSONUDO = True And _
                   boLRSONOMB = True Then

                    Dim objdatos22 As New cla_LIRASOLI

                    If (objdatos22.fun_Actualizar_LIRASOLI(inLRSOIDRE, _
                                                           inLRSONURA, _
                                                           stLRSOFERA, _
                                                           inLRSOSECU, _
                                                           Me.txtLRSONUDO.Text, _
                                                           Me.txtLRSONOMB.Text, _
                                                           Me.txtLRSOPRAP.Text, _
                                                           Me.txtLRSOSEAP.Text, _
                                                           Me.txtLRSODIPR.Text, _
                                                           Me.txtLRSODINO.Text, _
                                                           Me.txtLRSOTELE.Text, _
                                                           Me.txtLRSOCELU.Text, _
                                                           Me.txtLRSOCOEL.Text, _
                                                           Me.txtLRSOCOPO.Text, _
                                                           Me.txtLRSORESO.Text, _
                                                           Me.cboLRSOSOLI.SelectedValue)) = True Then

                        mod_MENSAJE.Se_Guardaron_Los_Datos_Correctamente()
                        Me.txtLRSONUDO.Focus()
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
        Me.txtLRSONUDO.Focus()
        Me.Close()
    End Sub

#End Region

#Region "FORMULARIO"

#Region "KeyPress"

    Private Sub txt_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtLRSONUDO.KeyPress, txtLRSONOMB.KeyPress, txtLRSOPRAP.KeyPress, txtLRSOSEAP.KeyPress, txtLRSOTELE.KeyPress, txtLRSOCELU.KeyPress, txtLRSODIPR.KeyPress, txtLRSOCOEL.KeyPress, txtLRSODINO.KeyPress, txtLRSORESO.KeyPress, cboLRSOSOLI.KeyPress, txtLRSOCOPO.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Or e.KeyChar = Convert.ToChar(Keys.Tab) Then
            pp_pro_SaltarCampo()
        End If
    End Sub

#End Region

#Region "SelectedIndexChanged"

    Private Sub cboRECLSOLI_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboLRSOSOLI.SelectedIndexChanged
        Me.lblLRSOSOLI.Text = CType(fun_Buscar_Lista_Valores_SOLICITANTE_Codigo(Me.cboLRSOSOLI), String)
    End Sub

#End Region

#Region "Click"

    Private Sub cboRECLSOLI_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboLRSOSOLI.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_SOLICITANTE_Descripcion(Me.cboLRSOSOLI, Me.cboLRSOSOLI.SelectedIndex)
    End Sub

#End Region

#Region "KeyDown"

    Private Sub cboRECLSOLI_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboLRSOSOLI.KeyDown
        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
            fun_Cargar_ComboBox_Con_Datos_Activos_SOLICITANTE_Descripcion(Me.cboLRSOSOLI, Me.cboLRSOSOLI.SelectedIndex)
        End If
    End Sub

#End Region

#Region "GotFocus"

    Private Sub txt_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtLRSONUDO.GotFocus, txtLRSONOMB.GotFocus, txtLRSOPRAP.GotFocus, txtLRSOSEAP.GotFocus, txtLRSOTELE.GotFocus, txtLRSOCELU.GotFocus, txtLRSODIPR.GotFocus, txtLRSOCOEL.GotFocus, txtLRSODINO.GotFocus, txtLRSORESO.GotFocus
        pp_pro_SobrearCampo(sender)
        pp_pro_DescripcionCampo(Me.strBARRESTA.Items(0), sender)
    End Sub
    Private Sub cbo_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboLRSOSOLI.GotFocus
        pp_pro_DescripcionCampo(Me.strBARRESTA.Items(0), sender)
    End Sub
    Private Sub cmd_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdGUARDAR.GotFocus, cmdSALIR.GotFocus
        pp_pro_DescripcionCampo(Me.strBARRESTA.Items(0), sender)
    End Sub

#End Region

#Region "Validated"

    Private Sub txtAJIUNUDO_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtLRSONUDO.Validated

        Try
            ' extrae el tercero si ya existe en base de datos
            Dim objdatos1 As New cla_TERCERO
            Dim tbl1 As New DataTable

            tbl1 = objdatos1.fun_Buscar_CODIGO_TERCERO(Trim(Me.txtLRSONUDO.Text))

            If tbl1.Rows.Count > 0 Then

                Me.txtLRSONOMB.Text = Trim(tbl1.Rows(0).Item(5))
                Me.txtLRSOPRAP.Text = Trim(tbl1.Rows(0).Item(6))
                Me.txtLRSOSEAP.Text = Trim(tbl1.Rows(0).Item(7))

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