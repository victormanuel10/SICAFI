Imports REGLAS_DEL_NEGOCIO

Public Class frm_insertar_OBURPLPA

    '=======================================================
    '*** INSERTAR PLAN PARCIAL OBLIGACIONES URBANISTICAS ***
    '=======================================================

#Region "VARIABLE"

    Dim vl_inOUIGIDRE As Integer = 0
    Dim vl_inOUIGSECU As Integer = 0
    Dim vl_stOUIGCLEN As String = ""
    Dim vl_inOUIGNURE As Integer = 0
    Dim vl_stOUIGFERE As String = ""
    Dim vl_inOUIGCLOU As Integer = 0
    Dim vl_inOUIGNULI As Integer = 0

    Dim boINSERTAR As Boolean = False
    Dim boMODIFICAR As Boolean = False

    Dim vl_inCABENURE As Integer = 0
    Dim vl_stCABEFERE As String = ""

#End Region

#Region "CONSTRUCTOR"

    Public Sub New(ByVal inOUIGIDRE As Integer, _
                   ByVal inOUIGSECU As Integer, _
                   ByVal stOUIGCLEN As String, _
                   ByVal inOUIGNURE As Integer, _
                   ByVal stOUIGFERE As String, _
                   ByVal inOUIGCLOU As Integer, _
                   ByVal inOUIGNULI As Integer)

        boMODIFICAR = True

        vl_inOUIGIDRE = inOUIGIDRE
        vl_inOUIGSECU = inOUIGSECU
        vl_stOUIGCLEN = stOUIGCLEN
        vl_inOUIGNURE = inOUIGNURE
        vl_stOUIGFERE = stOUIGFERE
        vl_inOUIGCLOU = inOUIGCLOU
        vl_inOUIGNULI = inOUIGNULI

        InitializeComponent()
        pro_LimpiarCampos()
        pro_inicializarControles()

    End Sub
    Public Sub New(ByVal inOUIGSECU As Integer, _
                   ByVal stOUIGCLEN As String, _
                   ByVal inOUIGNURE As Integer, _
                   ByVal stOUIGFERE As String, _
                   ByVal inOUIGCLOU As Integer, _
                   ByVal inOUIGNULI As Integer)

        boINSERTAR = True

        vl_inOUIGSECU = inOUIGSECU
        vl_stOUIGCLEN = stOUIGCLEN
        vl_inOUIGNURE = inOUIGNURE
        vl_stOUIGFERE = stOUIGFERE
        vl_inOUIGCLOU = inOUIGCLOU
        vl_inOUIGNULI = inOUIGNULI

        InitializeComponent()
        pro_LimpiarCampos()
        pro_inicializarControles()

    End Sub
    Public Sub New()

        InitializeComponent()

    End Sub

#End Region

#Region "PROCEDIMIENTOS"

    Private Sub pro_Reconsultar()

        Try


        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub pro_LimpiarCampos()

        Me.cboOUPPPLPA.DataSource = New DataTable
        Me.cboOUPPFOPA.DataSource = New DataTable
        Me.cboOUPPCOFP.DataSource = New DataTable
        Me.cboOUPPESTA.DataSource = New DataTable

    End Sub
    Private Sub pro_inicializarControles()

        Try
            If boMODIFICAR = True Then

                ' instancia la clase
                Dim objdatos As New cla_OBURPLPA
                Dim tbl As New DataTable

                tbl = objdatos.fun_Buscar_ID_OBURPLPA(vl_inOUIGIDRE)

                If tbl.Rows.Count > 0 Then

                    Me.Text = "Modificar registro"
                    Me.fraOBURPLPA.Text = "MODIFICAR PLAN PARCIAL"

                    Me.cboOUPPPLPA.Enabled = True

                    ' incorporar maestros forma de pago

                    Dim objdatos3 As New cla_ESTADO

                    Me.cboOUPPESTA.DataSource = objdatos3.fun_Consultar_TODOS_LOS_ESTADOS
                    Me.cboOUPPESTA.DisplayMember = "ESTADESC"
                    Me.cboOUPPESTA.ValueMember = "ESTACODI"

                    Me.cboOUPPESTA.SelectedValue = tbl.Rows(0).Item("OUPPESTA")

                End If

            ElseIf boINSERTAR = True Then

                Me.Text = "Insertar registro"
                Me.fraOBURPLPA.Text = "INSERTAR PLAN PARCIAL"

            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub pro_ObtenerNroResolucionyFecha()

        Try
            If Trim(Me.cboOUPPPLPA.Text) <> "" Then

                ' consulta la resolucion y fecha
                Dim obPLANPARC As New cla_PLANPARC
                Dim dtPLANPARC As New DataTable

                dtPLANPARC = obPLANPARC.fun_Buscar_ID_MANT_PLANPARC(Me.cboOUPPPLPA.SelectedValue)

                If dtPLANPARC.Rows.Count > 0 Then

                    vl_inCABENURE = dtPLANPARC.Rows(0).Item("PLPANURE")
                    vl_stCABEFERE = dtPLANPARC.Rows(0).Item("PLPAFERE")

                End If

            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub pro_InsertarRegistro()

        Try
            ' consulta la resolucion y fecha
            Dim obPLANPARC As New cla_PLANPARC
            Dim dtPLANPARC As New DataTable

            dtPLANPARC = obPLANPARC.fun_Buscar_ID_MANT_PLANPARC(Me.cboOUPPPLPA.SelectedValue)

            If dtPLANPARC.Rows.Count > 0 Then

                vl_inCABENURE = dtPLANPARC.Rows(0).Item("PLPANURE")
                vl_stCABEFERE = dtPLANPARC.Rows(0).Item("PLPAFERE")

            End If

            ' instancia la clase
            Dim objdatos As New cla_OBURPLPA

            Dim boLLAVEPRIMARIA As Boolean = False

            Dim objVerifica As New cla_Verificar_Dato

            Dim boOUPPUAU As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboOUPPUAU)
            Dim boOUPPCABE As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboOUPPCABE)

            If boOUPPUAU = True And boOUPPCABE = True Then
                boLLAVEPRIMARIA = objdatos.fun_Verifica_llave_Primaria_OBURPLPA(vl_stOUIGCLEN, _
                                                                                vl_inOUIGNURE, _
                                                                                vl_stOUIGFERE, _
                                                                                vl_inCABENURE, _
                                                                                vl_stCABEFERE, _
                                                                                cboOUPPUAU.SelectedValue, _
                                                                                cboOUPPCABE.SelectedValue, _
                                                                                vl_inOUIGCLOU, _
                                                                                vl_inOUIGNULI)
            End If

            Dim boOUPPPLPA As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboOUPPPLPA)
            Dim boOUPPFOPA As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboOUPPFOPA)
            Dim boOUPPCOFP As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboOUPPCOFP)
            Dim boOUPPESTA As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboOUPPESTA)

            ' verifica los datos del formulario 
            If boLLAVEPRIMARIA = True And _
                boOUPPPLPA = True And _
                boOUPPFOPA = True And _
                boOUPPCOFP = True And _
                boOUPPESTA = True And _
                boOUPPUAU = True And _
                boOUPPCABE = True Then

                Dim objdatos22 As New cla_OBURPLPA

                If (objdatos22.fun_Insertar_OBURPLPA(vl_inOUIGSECU, vl_stOUIGCLEN, vl_inOUIGNURE, vl_stOUIGFERE, vl_inCABENURE, vl_stCABEFERE, Me.cboOUPPUAU.SelectedValue, Me.cboOUPPCABE.SelectedValue, vl_inOUIGCLOU, vl_inOUIGNULI, Me.cboOUPPFOPA.SelectedValue, Me.cboOUPPCOFP.SelectedValue, Me.cboOUPPESTA.SelectedValue)) = True Then

                    mod_MENSAJE.Se_Guardaron_Los_Datos_Correctamente()
                    Me.cboOUPPPLPA.Focus()
                    Me.Close()
                Else
                    mod_MENSAJE.No_Se_Guardo_El_Registro_En_La_Base_De_Datos()
                End If

            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub pro_ModificarRegistro()

        Try

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
                pro_InsertarRegistro()

                ' modifica el registro
            ElseIf boMODIFICAR = True Then
                pro_ModificarRegistro()

            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description & "Guardar")
        End Try

    End Sub
    Private Sub cmdCANCELARR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Close()
    End Sub

#End Region

#Region "FORMULARIO"

#Region "Load"

    Private Sub frm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs)
        pro_Reconsultar()
    End Sub

#End Region

#Region "KeyDown"

    Private Sub cboOUPPPLPA_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboOUPPPLPA.KeyDown
        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
            fun_Cargar_ComboBox_Con_Datos_Activos_PLAN_PARCIAL(Me.cboOUPPPLPA, Me.cboOUPPPLPA.SelectedIndex)

            Me.cboOUPPUAU.DataSource = New DataTable
        End If
    End Sub
    Private Sub cboOUPPUAU_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboOUPPUAU.KeyDown
        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
            pro_ObtenerNroResolucionyFecha()
            fun_Cargar_ComboBox_Con_Datos_Activos_UAU_X_PLANPARC_Descripcion(Me.cboOUPPUAU, Me.cboOUPPUAU.SelectedIndex, Me.cboOUPPPLPA, vl_inCABENURE, vl_stCABEFERE)
        End If
    End Sub
    Private Sub cboCBUACBPP_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboOUPPCABE.KeyDown
        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
            fun_Cargar_ComboBox_Con_Datos_Activos_CABEPLPA_Descripcion(Me.cboOUPPCABE, Me.cboOUPPCABE.SelectedIndex)
        End If
    End Sub
    Private Sub cboOUPPFOPA_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboOUPPFOPA.KeyDown
        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
            fun_Cargar_ComboBox_Con_Datos_Activos_FOPAPLPA_Descripcion(Me.cboOUPPFOPA, Me.cboOUPPFOPA.SelectedIndex)
        End If
    End Sub
    Private Sub cboOUPPCOFP_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboOUPPCOFP.KeyDown
        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
            fun_Cargar_ComboBox_Con_Datos_Activos_FOPAPLPA_Descripcion(Me.cboOUPPCOFP, Me.cboOUPPCOFP.SelectedIndex)
        End If
    End Sub
    Private Sub cboCABEESTA_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboOUPPESTA.KeyDown
        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
            fun_Cargar_ComboBox_Con_Datos_Activos_ESTADO(Me.cboOUPPESTA, Me.cboOUPPESTA.SelectedIndex)
        End If
    End Sub

#End Region

#Region "KeyPress"

    Private Sub txt_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboOUPPPLPA.KeyPress, cboOUPPESTA.KeyPress, cboOUPPUAU.KeyPress, cboOUPPCABE.KeyPress, cboOUPPFOPA.KeyPress, cboOUPPCOFP.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Or e.KeyChar = Convert.ToChar(Keys.Tab) Then
            pp_pro_SaltarCampo()
        End If
    End Sub

#End Region

#Region "GotFocus"

    Private Sub cmd_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdGUARDAR.GotFocus, cmdSALIR.GotFocus
        pp_pro_DescripcionCampo(Me.strBARRESTA.Items(0), sender)
    End Sub
    Private Sub cbo_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboOUPPESTA.GotFocus, cboOUPPPLPA.GotFocus, cboOUPPCABE.GotFocus, cboOUPPUAU.GotFocus, cboOUPPFOPA.GotFocus, cboOUPPCOFP.GotFocus
        pp_pro_DescripcionCampo(Me.strBARRESTA.Items(0), sender)
    End Sub

#End Region

#Region "Click"

    Private Sub cboOUPPPLPA_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboOUPPPLPA.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_PLAN_PARCIAL(Me.cboOUPPPLPA, Me.cboOUPPPLPA.SelectedIndex)
        Me.cboOUPPUAU.DataSource = New DataTable
    End Sub
    Private Sub cboOUPPUAU_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboOUPPUAU.Click
        pro_ObtenerNroResolucionyFecha()
        fun_Cargar_ComboBox_Con_Datos_Activos_UAU_X_PLANPARC_Descripcion(Me.cboOUPPUAU, Me.cboOUPPUAU.SelectedIndex, Me.cboOUPPPLPA, vl_inCABENURE, vl_stCABEFERE)
    End Sub
    Private Sub cboOUPPCABE_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboOUPPCABE.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_CABEPLPA_Descripcion(Me.cboOUPPCABE, Me.cboOUPPCABE.SelectedIndex)
    End Sub
    Private Sub cboOUPPFOPA_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboOUPPFOPA.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_FOPAPLPA_Descripcion(Me.cboOUPPFOPA, Me.cboOUPPFOPA.SelectedIndex)
    End Sub
    Private Sub cboOUPPCOFP_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboOUPPCOFP.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_COFPPLPA_Descripcion(Me.cboOUPPCOFP, Me.cboOUPPCOFP.SelectedIndex)
    End Sub
    Private Sub cboOUPPESTA_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboOUPPESTA.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_ESTADO(cboOUPPESTA, cboOUPPESTA.SelectedIndex)
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