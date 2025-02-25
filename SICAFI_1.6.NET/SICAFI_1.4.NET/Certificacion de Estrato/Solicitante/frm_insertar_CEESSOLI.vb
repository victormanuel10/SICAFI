Imports REGLAS_DEL_NEGOCIO

Public Class frm_insertar_CEESSOLI

    '=========================================================
    '*** INSERTAR SOLICITANTE CERTIFICACION SOCIOECONOMICA ***
    '=========================================================

#Region "VARIABLE"

    Dim inCESOIDRE As Integer
    Dim inCESOSECU As Integer
    Dim inCESONURA As Integer
    Dim stCESOFERA As String

    Dim boINSERTAR As Boolean = False
    Dim boMODIFICAR As Boolean = False

#End Region

#Region "CONSTRUCTOR"

    Public Sub New(ByVal inIDRE As Integer, _
                   ByVal inSECU As Integer, _
                   ByVal inNURE As Integer, _
                   ByVal stFERE As String)

        inCESOIDRE = inIDRE
        inCESOSECU = inSECU
        inCESONURA = inNURE
        stCESOFERA = stFERE

        boMODIFICAR = True

        InitializeComponent()
        pro_LimpiarCampos()
        pro_inicializarControles()

    End Sub
    Public Sub New(ByVal inSECU As Integer, _
                   ByVal inNURE As Integer, _
                   ByVal stFERE As String)

        inCESOSECU = inSECU
        inCESONURA = inNURE
        stCESOFERA = stFERE

        boINSERTAR = True

        InitializeComponent()
        pro_LimpiarCampos()
        pro_inicializarControles()

    End Sub

#End Region

#Region "PROCEDIMIENTOS"

    Private Sub pro_LimpiarCampos()

        Me.txtCESONUDO.Text = ""
        Me.txtCESONOMB.Text = ""
        Me.txtCESOPRAP.Text = ""
        Me.txtCESOSEAP.Text = ""
        Me.txtCESOTELE.Text = ""
        Me.txtCESOCELU.Text = ""
        Me.txtCESOCOEL.Text = ""
        Me.txtCESODIPR.Text = ""
        Me.txtCESODINO.Text = ""
        Me.txtCESOCOPO.Text = ""
        Me.txtCESOPROY.Text = ""
        Me.txtCESORESO.Text = ""
        Me.lblCESOSOLI.Text = ""

        Me.cboCESOSOLI.DataSource = New DataTable
        Me.cboCESOESTA.DataSource = New DataTable

    End Sub
    Private Sub pro_inicializarControles()

        Try
            If boMODIFICAR = True Then

                ' instancia la clase
                Dim objdatos As New cla_CEESSOLI
                Dim tbl As New DataTable

                tbl = objdatos.fun_Buscar_ID_CEESSOLI(inCESOIDRE)

                If tbl.Rows.Count > 0 Then

                    Me.Text = "Modificar registro"
                    Me.fraINFOUSUA.Text = "MODIFICAR SOLICITANTE"

                    Me.txtCESONUDO.Text = Trim(tbl.Rows(0).Item("CESONUDO"))
                    Me.txtCESONOMB.Text = Trim(tbl.Rows(0).Item("CESONOMB"))
                    Me.txtCESOPRAP.Text = Trim(tbl.Rows(0).Item("CESOPRAP"))
                    Me.txtCESOSEAP.Text = Trim(tbl.Rows(0).Item("CESOSEAP"))
                    Me.txtCESOTELE.Text = Trim(tbl.Rows(0).Item("CESOTELE"))
                    Me.txtCESOCELU.Text = Trim(tbl.Rows(0).Item("CESOCELU"))
                    Me.txtCESOCOEL.Text = Trim(tbl.Rows(0).Item("CESOCOEL"))
                    Me.txtCESODIPR.Text = Trim(tbl.Rows(0).Item("CESODIPR"))
                    Me.txtCESODINO.Text = Trim(tbl.Rows(0).Item("CESODINO"))
                    Me.txtCESOCOPO.Text = Trim(tbl.Rows(0).Item("CESOCOPO"))
                    Me.txtCESOCOPO.Text = Trim(tbl.Rows(0).Item("CESOPROY"))
                    Me.txtCESORESO.Text = Trim(tbl.Rows(0).Item("CESORESO"))

                    Dim objdatos9 As New cla_SOLICITANTE

                    Me.cboCESOSOLI.DataSource = objdatos9.fun_Consultar_CAMPOS_MANT_SOLICITANTE
                    Me.cboCESOSOLI.DisplayMember = "SOLIDESC"
                    Me.cboCESOSOLI.ValueMember = "SOLICODI"

                    Me.cboCESOSOLI.SelectedValue = tbl.Rows(0).Item("CESOSOLI")

                    Dim objdatos3 As New cla_ESTADO

                    Me.cboCESOESTA.DataSource = objdatos3.fun_Consultar_TODOS_LOS_ESTADOS
                    Me.cboCESOESTA.DisplayMember = "ESTADESC"
                    Me.cboCESOESTA.ValueMember = "ESTACODI"

                    Me.cboCESOESTA.SelectedValue = tbl.Rows(0).Item("CESOESTA")

                    Me.lblCESOSOLI.Text = CType(fun_Buscar_Lista_Valores_SOLICITANTE_Codigo(Me.cboCESOSOLI), String)

                    Me.txtCESONUDO.ReadOnly = True

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
                Dim objdatos As New cla_CEESSOLI

                Dim boLLAVEPRIMARIA As Boolean = objdatos.fun_Verifica_llave_Primaria_CEESSOLI(inCESONURA, stCESOFERA, Me.txtCESONUDO)

                ' instancia la clase
                Dim objVerifica As New cla_Verificar_Dato

                Dim boCESONUDO As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.txtCESONUDO)
                Dim boCESONOMB As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.txtCESONOMB)
                Dim boCESOSOLI As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboCESOSOLI)
                Dim boCESOESTA As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboCESOESTA)


                ' verifica los datos del formulario 
                If boLLAVEPRIMARIA = True And _
                   boCESONUDO = True And _
                   boCESONOMB = True And _
                   boCESOESTA = True And _
                   boCESOSOLI = True Then

                    Dim objdatos22 As New cla_CEESSOLI

                    If (objdatos22.fun_Insertar_CEESSOLI(inCESOSECU, _
                                                         inCESONURA, _
                                                         stCESOFERA, _
                                                         Me.txtCESONUDO.Text, _
                                                         Me.cboCESOSOLI.SelectedValue, _
                                                         Me.txtCESONOMB.Text, _
                                                         Me.txtCESOPRAP.Text, _
                                                         Me.txtCESOSEAP.Text, _
                                                         Me.txtCESODIPR.Text, _
                                                         Me.txtCESODINO.Text, _
                                                         Me.txtCESOTELE.Text, _
                                                         Me.txtCESOCELU.Text, _
                                                         Me.txtCESOCOEL.Text, _
                                                         Me.txtCESOCOPO.Text, _
                                                         Me.txtCESOPROY.Text, _
                                                         Me.txtCESORESO.Text, _
                                                         Me.cboCESOESTA.SelectedValue)) = True Then

                        mod_MENSAJE.Se_Guardaron_Los_Datos_Correctamente()
                        Me.txtCESONUDO.Focus()
                        Me.Close()
                    Else
                        mod_MENSAJE.No_Se_Guardo_El_Registro_En_La_Base_De_Datos()
                    End If

                End If

                ' modifica el registro
            ElseIf boMODIFICAR = True Then

                ' instancia la clase
                Dim objVerifica As New cla_Verificar_Dato

                Dim boCESONUDO As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.txtCESONUDO)
                Dim boCESONOMB As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.txtCESONOMB)

                ' verifica los datos del formulario 
                If boCESONUDO = True And _
                   boCESONOMB = True Then

                    Dim objdatos22 As New cla_CEESSOLI

                    If (objdatos22.fun_Actualizar_CEESSOLI(inCESOIDRE, _
                                                           inCESOSECU, _
                                                           inCESONURA, _
                                                           stCESOFERA, _
                                                           Me.txtCESONUDO.Text, _
                                                           Me.cboCESOSOLI.SelectedValue, _
                                                           Me.txtCESONOMB.Text, _
                                                           Me.txtCESOPRAP.Text, _
                                                           Me.txtCESOSEAP.Text, _
                                                           Me.txtCESODIPR.Text, _
                                                           Me.txtCESODINO.Text, _
                                                           Me.txtCESOTELE.Text, _
                                                           Me.txtCESOCELU.Text, _
                                                           Me.txtCESOCOEL.Text, _
                                                           Me.txtCESOCOPO.Text, _
                                                           Me.txtCESOPROY.Text, _
                                                           Me.txtCESORESO.Text, _
                                                           Me.cboCESOESTA.SelectedValue)) = True Then

                        mod_MENSAJE.Se_Guardaron_Los_Datos_Correctamente()
                        Me.txtCESONUDO.Focus()
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
        Me.txtCESONUDO.Focus()
        Me.Close()
    End Sub

#End Region

#Region "FORMULARIO"

#Region "KeyPress"

    Private Sub txt_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCESONUDO.KeyPress, txtCESONOMB.KeyPress, txtCESOPRAP.KeyPress, txtCESOSEAP.KeyPress, txtCESOTELE.KeyPress, txtCESOCELU.KeyPress, txtCESODIPR.KeyPress, txtCESOCOEL.KeyPress, txtCESODINO.KeyPress, txtCESORESO.KeyPress, cboCESOSOLI.KeyPress, txtCESOCOPO.KeyPress, cboCESOESTA.KeyPress, txtCESOPROY.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Or e.KeyChar = Convert.ToChar(Keys.Tab) Then
            pp_pro_SaltarCampo()
        End If
    End Sub

#End Region

#Region "SelectedIndexChanged"

    Private Sub cboRECLSOLI_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCESOSOLI.SelectedIndexChanged
        Me.lblCESOSOLI.Text = CType(fun_Buscar_Lista_Valores_SOLICITANTE_Codigo(Me.cboCESOSOLI), String)
    End Sub

#End Region

#Region "Click"

    Private Sub cboRECLSOLI_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboCESOSOLI.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_SOLICITANTE_Descripcion(Me.cboCESOSOLI, Me.cboCESOSOLI.SelectedIndex)
    End Sub

#End Region

#Region "KeyDown"

    Private Sub cboRECLSOLI_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboCESOSOLI.KeyDown
        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
            fun_Cargar_ComboBox_Con_Datos_Activos_SOLICITANTE_Descripcion(Me.cboCESOSOLI, Me.cboCESOSOLI.SelectedIndex)
        End If
    End Sub
    Private Sub cboLIRAESTA_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboCESOESTA.KeyDown
        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
            fun_Cargar_ComboBox_Con_Datos_Activos_ESTADO(Me.cboCESOESTA, Me.cboCESOESTA.SelectedIndex)
        End If
    End Sub

#End Region

#Region "GotFocus"

    Private Sub txt_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCESONUDO.GotFocus, txtCESONOMB.GotFocus, txtCESOPRAP.GotFocus, txtCESOSEAP.GotFocus, txtCESOTELE.GotFocus, txtCESOCELU.GotFocus, txtCESODIPR.GotFocus, txtCESOCOEL.GotFocus, txtCESODINO.GotFocus, txtCESORESO.GotFocus, txtCESOPROY.GotFocus
        pp_pro_SobrearCampo(sender)
        pp_pro_DescripcionCampo(Me.strBARRESTA.Items(0), sender)
    End Sub
    Private Sub cbo_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboCESOSOLI.GotFocus, cboCESOESTA.GotFocus
        pp_pro_DescripcionCampo(Me.strBARRESTA.Items(0), sender)
    End Sub
    Private Sub cmd_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdGUARDAR.GotFocus, cmdSALIR.GotFocus
        pp_pro_DescripcionCampo(Me.strBARRESTA.Items(0), sender)
    End Sub

#End Region

#Region "Click"

    Private Sub cboCESOESTA_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboCESOESTA.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_ESTADO(Me.cboCESOESTA, Me.cboCESOESTA.SelectedIndex)
    End Sub

#End Region

#Region "Validated"

    Private Sub txtAJIUNUDO_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCESONUDO.Validated

        Try
            ' extrae el tercero si ya existe en base de datos
            Dim objdatos1 As New cla_TERCERO
            Dim tbl1 As New DataTable

            tbl1 = objdatos1.fun_Buscar_CODIGO_TERCERO(Trim(Me.txtCESONUDO.Text))

            If tbl1.Rows.Count > 0 Then

                Me.txtCESONOMB.Text = Trim(tbl1.Rows(0).Item(5))
                Me.txtCESOPRAP.Text = Trim(tbl1.Rows(0).Item(6))
                Me.txtCESOSEAP.Text = Trim(tbl1.Rows(0).Item(7))

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