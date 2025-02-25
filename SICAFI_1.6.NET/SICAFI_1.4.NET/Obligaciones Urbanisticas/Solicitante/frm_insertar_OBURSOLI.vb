Imports REGLAS_DEL_NEGOCIO

Public Class frm_insertar_OBURSOLI

    '======================================================
    '*** INSERTAR SOLICITANTE OBLIGACIONES URBANISTICAS ***
    '======================================================

#Region "VARIABLE"

    Dim inOUSOIDRE As Integer
    Dim inOUSOSECU As Integer
    Dim stOUSOCLEN As String
    Dim inOUSONURE As Integer
    Dim stOUSOFERE As String

    Dim boINSERTAR As Boolean = False
    Dim boMODIFICAR As Boolean = False

#End Region

#Region "CONSTRUCTOR"

    Public Sub New(ByVal inIDRE As Integer, _
                   ByVal inSECU As Integer, _
                   ByVal stCLEN As String, _
                   ByVal inNURE As Integer, _
                   ByVal stFERE As String)

        inOUSOIDRE = inIDRE
        inOUSOSECU = inSECU
        stOUSOCLEN = stCLEN
        inOUSONURE = inNURE
        stOUSOFERE = stFERE

        boMODIFICAR = True

        InitializeComponent()
        pro_LimpiarCampos()
        pro_inicializarControles()

    End Sub
    Public Sub New(ByVal inSECU As Integer, _
                   ByVal stCLEN As String, _
                   ByVal inNURE As Integer, _
                   ByVal stFERE As String)

        inOUSOSECU = inSECU
        stOUSOCLEN = stCLEN
        inOUSONURE = inNURE
        stOUSOFERE = stFERE

        boINSERTAR = True

        InitializeComponent()
        pro_LimpiarCampos()
        pro_inicializarControles()
    End Sub

#End Region

#Region "PROCEDIMIENTOS"

    Private Sub pro_LimpiarCampos()

        Me.txtOUSONUDO.Text = ""
        Me.txtOUSONOMB.Text = ""
        Me.txtOUSOPRAP.Text = ""
        Me.txtOUSOSEAP.Text = ""
        Me.txtOUSOTELE.Text = ""
        Me.txtOUSOCELU.Text = ""
        Me.txtOUSOCOEL.Text = ""
        Me.txtOUSODIPR.Text = ""
        Me.txtOUSODINO.Text = ""
        Me.txtOUSOCOPO.Text = ""
        Me.txtOUSORESO.Text = ""
        Me.lblOUSOSOLI.Text = ""

        Me.cboOUSOSOLI.DataSource = New DataTable
        Me.cboOUSOESTA.DataSource = New DataTable

    End Sub
    Private Sub pro_inicializarControles()

        Try
            If boMODIFICAR = True Then

                ' instancia la clase
                Dim objdatos As New cla_OBURSOLI
                Dim tbl As New DataTable

                tbl = objdatos.fun_Buscar_ID_OBURSOLI(inOUSOIDRE)

                If tbl.Rows.Count > 0 Then

                    Me.Text = "Modificar registro"
                    Me.fraINFOUSUA.Text = "MODIFICAR SOLICITANTE"

                    Me.txtOUSONUDO.Text = Trim(tbl.Rows(0).Item("OUSONUDO"))
                    Me.txtOUSONOMB.Text = Trim(tbl.Rows(0).Item("OUSONOMB"))
                    Me.txtOUSOPRAP.Text = Trim(tbl.Rows(0).Item("OUSOPRAP"))
                    Me.txtOUSOSEAP.Text = Trim(tbl.Rows(0).Item("OUSOSEAP"))
                    Me.txtOUSOTELE.Text = Trim(tbl.Rows(0).Item("OUSOTELE"))
                    Me.txtOUSOCELU.Text = Trim(tbl.Rows(0).Item("OUSOCELU"))
                    Me.txtOUSOCOEL.Text = Trim(tbl.Rows(0).Item("OUSOCOEL"))
                    Me.txtOUSODIPR.Text = Trim(tbl.Rows(0).Item("OUSODIPR"))
                    Me.txtOUSODINO.Text = Trim(tbl.Rows(0).Item("OUSODINO"))
                    Me.txtOUSOCOPO.Text = Trim(tbl.Rows(0).Item("OUSOCOPO"))
                    Me.txtOUSORESO.Text = Trim(tbl.Rows(0).Item("OUSORESO"))

                    Dim objdatos9 As New cla_SOLICITANTE

                    Me.cboOUSOSOLI.DataSource = objdatos9.fun_Consultar_CAMPOS_MANT_SOLICITANTE
                    Me.cboOUSOSOLI.DisplayMember = "SOLIDESC"
                    Me.cboOUSOSOLI.ValueMember = "SOLICODI"

                    Me.cboOUSOSOLI.SelectedValue = tbl.Rows(0).Item("OUSOSOLI")

                    Dim objdatos3 As New cla_ESTADO

                    Me.cboOUSOESTA.DataSource = objdatos3.fun_Consultar_TODOS_LOS_ESTADOS
                    Me.cboOUSOESTA.DisplayMember = "ESTADESC"
                    Me.cboOUSOESTA.ValueMember = "ESTACODI"

                    Me.cboOUSOESTA.SelectedValue = tbl.Rows(0).Item("OUSOESTA")

                    Me.lblOUSOSOLI.Text = CType(fun_Buscar_Lista_Valores_SOLICITANTE_Codigo(Me.cboOUSOSOLI), String)

                    Me.txtOUSONUDO.ReadOnly = True

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
                Dim objdatos As New cla_OBURSOLI

                Dim boLLAVEPRIMARIA As Boolean = objdatos.fun_Verifica_llave_Primaria_OBURSOLI(stOUSOCLEN, inOUSONURE, stOUSOFERE, Me.txtOUSONUDO)

                ' instancia la clase
                Dim objVerifica As New cla_Verificar_Dato

                Dim boOUSONUDO As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.txtOUSONUDO)
                Dim boOUSONOMB As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.txtOUSONOMB)
                Dim boOUSOSOLI As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboOUSOSOLI)
                Dim boOUSOESTA As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboOUSOESTA)


                ' verifica los datos del formulario 
                If boLLAVEPRIMARIA = True And _
                   boOUSONUDO = True And _
                   boOUSONOMB = True And _
                   boOUSOESTA = True And _
                   boOUSOSOLI = True Then

                    Dim objdatos22 As New cla_OBURSOLI

                    If (objdatos22.fun_Insertar_OBURSOLI(inOUSOSECU, _
                                                         stOUSOCLEN, _
                                                         inOUSONURE, _
                                                         stOUSOFERE, _
                                                         Me.txtOUSONUDO.Text, _
                                                         Me.cboOUSOSOLI.SelectedValue, _
                                                         Me.txtOUSONOMB.Text, _
                                                         Me.txtOUSOPRAP.Text, _
                                                         Me.txtOUSOSEAP.Text, _
                                                         Me.txtOUSODIPR.Text, _
                                                         Me.txtOUSODINO.Text, _
                                                         Me.txtOUSOTELE.Text, _
                                                         Me.txtOUSOCELU.Text, _
                                                         Me.txtOUSOCOEL.Text, _
                                                         Me.txtOUSOCOPO.Text, _
                                                         Me.txtOUSORESO.Text, _
                                                         Me.cboOUSOESTA.SelectedValue)) = True Then

                        mod_MENSAJE.Se_Guardaron_Los_Datos_Correctamente()
                        Me.txtOUSONUDO.Focus()
                        Me.Close()
                    Else
                        mod_MENSAJE.No_Se_Guardo_El_Registro_En_La_Base_De_Datos()
                    End If

                End If

                ' modifica el registro
            ElseIf boMODIFICAR = True Then

                ' instancia la clase
                Dim objVerifica As New cla_Verificar_Dato

                Dim boOUSONUDO As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.txtOUSONUDO)
                Dim boOUSONOMB As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.txtOUSONOMB)

                ' verifica los datos del formulario 
                If boOUSONUDO = True And _
                   boOUSONOMB = True Then

                    Dim objdatos22 As New cla_OBURSOLI

                    If (objdatos22.fun_Actualizar_OBURSOLI(inOUSOIDRE, _
                                                           inOUSOSECU, _
                                                           stOUSOCLEN, _
                                                           inOUSONURE, _
                                                           stOUSOFERE, _
                                                           Me.txtOUSONUDO.Text, _
                                                           Me.cboOUSOSOLI.SelectedValue, _
                                                           Me.txtOUSONOMB.Text, _
                                                           Me.txtOUSOPRAP.Text, _
                                                           Me.txtOUSOSEAP.Text, _
                                                           Me.txtOUSODIPR.Text, _
                                                           Me.txtOUSODINO.Text, _
                                                           Me.txtOUSOTELE.Text, _
                                                           Me.txtOUSOCELU.Text, _
                                                           Me.txtOUSOCOEL.Text, _
                                                           Me.txtOUSOCOPO.Text, _
                                                           Me.txtOUSORESO.Text, _
                                                           Me.cboOUSOESTA.SelectedValue)) = True Then

                        mod_MENSAJE.Se_Guardaron_Los_Datos_Correctamente()
                        Me.txtOUSONUDO.Focus()
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
        Me.txtOUSONUDO.Focus()
        Me.Close()
    End Sub

#End Region

#Region "FORMULARIO"

#Region "KeyPress"

    Private Sub txt_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtOUSONUDO.KeyPress, txtOUSONOMB.KeyPress, txtOUSOPRAP.KeyPress, txtOUSOSEAP.KeyPress, txtOUSOTELE.KeyPress, txtOUSOCELU.KeyPress, txtOUSODIPR.KeyPress, txtOUSOCOEL.KeyPress, txtOUSODINO.KeyPress, txtOUSORESO.KeyPress, cboOUSOSOLI.KeyPress, txtOUSOCOPO.KeyPress, cboOUSOESTA.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Or e.KeyChar = Convert.ToChar(Keys.Tab) Then
            pp_pro_SaltarCampo()
        End If
    End Sub

#End Region

#Region "SelectedIndexChanged"

    Private Sub cboRECLSOLI_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboOUSOSOLI.SelectedIndexChanged
        Me.lblOUSOSOLI.Text = CType(fun_Buscar_Lista_Valores_SOLICITANTE_Codigo(Me.cboOUSOSOLI), String)
    End Sub

#End Region

#Region "Click"

    Private Sub cboRECLSOLI_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboOUSOSOLI.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_SOLICITANTE_Descripcion(Me.cboOUSOSOLI, Me.cboOUSOSOLI.SelectedIndex)
    End Sub

#End Region

#Region "KeyDown"

    Private Sub cboRECLSOLI_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboOUSOSOLI.KeyDown
        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
            fun_Cargar_ComboBox_Con_Datos_Activos_SOLICITANTE_Descripcion(Me.cboOUSOSOLI, Me.cboOUSOSOLI.SelectedIndex)
        End If
    End Sub
    Private Sub cboLIRAESTA_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboOUSOESTA.KeyDown
        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
            fun_Cargar_ComboBox_Con_Datos_Activos_ESTADO(Me.cboOUSOESTA, Me.cboOUSOESTA.SelectedIndex)
        End If
    End Sub

#End Region

#Region "GotFocus"

    Private Sub txt_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtOUSONUDO.GotFocus, txtOUSONOMB.GotFocus, txtOUSOPRAP.GotFocus, txtOUSOSEAP.GotFocus, txtOUSOTELE.GotFocus, txtOUSOCELU.GotFocus, txtOUSODIPR.GotFocus, txtOUSOCOEL.GotFocus, txtOUSODINO.GotFocus, txtOUSORESO.GotFocus
        pp_pro_SobrearCampo(sender)
        pp_pro_DescripcionCampo(Me.strBARRESTA.Items(0), sender)
    End Sub
    Private Sub cbo_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboOUSOSOLI.GotFocus, cboOUSOESTA.GotFocus
        pp_pro_DescripcionCampo(Me.strBARRESTA.Items(0), sender)
    End Sub
    Private Sub cmd_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdGUARDAR.GotFocus, cmdSALIR.GotFocus
        pp_pro_DescripcionCampo(Me.strBARRESTA.Items(0), sender)
    End Sub

#End Region

#Region "Click"

    Private Sub cboOUSOESTA_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboOUSOESTA.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_ESTADO(Me.cboOUSOESTA, Me.cboOUSOESTA.SelectedIndex)
    End Sub

#End Region

#Region "Validated"

    Private Sub txtAJIUNUDO_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtOUSONUDO.Validated

        Try
            ' extrae el tercero si ya existe en base de datos
            Dim objdatos1 As New cla_TERCERO
            Dim tbl1 As New DataTable

            tbl1 = objdatos1.fun_Buscar_CODIGO_TERCERO(Trim(Me.txtOUSONUDO.Text))

            If tbl1.Rows.Count > 0 Then

                Me.txtOUSONOMB.Text = Trim(tbl1.Rows(0).Item(5))
                Me.txtOUSOPRAP.Text = Trim(tbl1.Rows(0).Item(6))
                Me.txtOUSOSEAP.Text = Trim(tbl1.Rows(0).Item(7))

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