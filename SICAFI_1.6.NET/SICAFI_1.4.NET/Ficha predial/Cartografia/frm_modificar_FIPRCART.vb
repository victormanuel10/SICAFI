Imports REGLAS_DEL_NEGOCIO

Public Class frm_modificar_FIPRCART

    '=============================
    '*** MODIFICAR CARTOGRAFIA ***
    '=============================

#Region "CONSTRUCTORES"

    Public Sub New(ByVal inFPCAIDRE As Integer, _
                   ByVal inFIPRNUFI As Integer, _
                   ByVal inFIPRNURE As Integer, _
                   ByVal idRESODEPA As String, _
                   ByVal idRESOMUNI As String, _
                   ByVal idRESOTIRE As Integer, _
                   ByVal idRESOCLSE As Integer, _
                   ByVal idRESOVIGE As Integer, _
                   ByVal idRESORESO As Integer)

        vl_inFPCAIDRE = inFPCAIDRE
        vp_FichaPredial = inFIPRNUFI
        vl_inFIPRNURE = inFIPRNURE
        vl_stRESODEPA = idRESODEPA
        vl_stRESOMUNI = idRESOMUNI
        vl_inRESOTIRE = idRESOTIRE
        vl_inRESOCLSE = idRESOCLSE
        vl_inRESOVIGE = idRESOVIGE
        vl_inRESORESO = idRESORESO

        InitializeComponent()
        pro_inicializarControles()

    End Sub

#End Region

#Region "VARIABLES LOCALES"

    '*** VARIABLES QUE RECIBE DEL FORMULARIO DE FICHA PREDIAL ***
    Dim vl_inFIPRNURE As Integer
    Dim vl_stRESODEPA As String
    Dim vl_stRESOMUNI As String
    Dim vl_inRESOTIRE As Integer
    Dim vl_inRESOCLSE As Integer
    Dim vl_inRESOVIGE As Integer
    Dim vl_inRESORESO As Integer
    Dim vl_inFPCAIDRE As Integer
    Dim vl_inFPDEDEEC As Integer

#End Region

#Region "PROCEDIMIENTOS"

    Private Sub pro_inicializarControles()

        Try
            '=================================
            ' CARGA LOS COMBOBOX CON LOS DATOS 
            '=================================

            fun_Cargar_ComboBox_Con_Todos_Los_Datos_VIGENCIA(cboFPCAVIGR, cboFPCAVIGR.SelectedValue)
            fun_Cargar_ComboBox_Con_Todos_Los_Datos_VIGENCIA(cboFPCAVIAE, cboFPCAVIAE.SelectedValue)
            fun_Cargar_ComboBox_Con_Datos_Activos_ESTADO(cboFPCAESTA, cboFPCAESTA.SelectedValue)

            '==================================
            ' LLENA LOS CAMPOS DE ACUERDO AL ID
            '==================================

            Dim objdatos As New cla_FIPRCART
            Dim tbl As New DataTable

            tbl = objdatos.fun_Buscar_ID_FIPRCART(vl_inFPCAIDRE)

            txtFPCAPLAN.Text = Trim(tbl.Rows(0).Item(2))
            txtFPCAVENT.Text = Trim(tbl.Rows(0).Item(3))
            txtFPCAESGR.Text = Trim(tbl.Rows(0).Item(4))
            cboFPCAVIGR.SelectedValue = tbl.Rows(0).Item(5)
            txtFPCAVUEL.Text = Trim(tbl.Rows(0).Item(6))
            txtFPCAFAJA.Text = Trim(tbl.Rows(0).Item(7))
            txtFPCAFOTO.Text = Trim(tbl.Rows(0).Item(8))
            cboFPCAVIAE.SelectedValue = tbl.Rows(0).Item(9)
            txtFPCAAMPL.Text = Trim(tbl.Rows(0).Item(10))
            txtFPCAESAE.Text = Trim(tbl.Rows(0).Item(11))

            Me.txtFPCAPLAN.Focus()

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try



    End Sub

#End Region

#Region "MENU"

    Private Sub cmdGUARDAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGUARDAR.Click

        Try
            If fun_Verificar_Campos_Llenos_8_DATOS(Trim(Me.txtFPCAPLAN.Text), _
                                                   Trim(Me.txtFPCAESGR.Text), _
                                                   Trim(Me.cboFPCAVIGR.Text), _
                                                   Trim(Me.txtFPCAVUEL.Text), _
                                                   Trim(Me.txtFPCAFAJA.Text), _
                                                   Trim(Me.txtFPCAFOTO.Text), _
                                                   Trim(Me.cboFPCAVIAE.Text), _
                                                   Trim(Me.txtFPCAESAE.Text)) = False Then
                mod_MENSAJE.Existen_Campos_Sin_Diligenciar()
                Me.txtFPCAPLAN.Focus()
            Else
                '==========================================================
                ' ESTRAE LA INFORMACIÓN DEL REGISTRO A MODIFICAR ANTES DE..
                '==========================================================

                Dim objdatos As New cla_FIPRCART
                Dim tbl As New DataTable

                tbl = objdatos.fun_Buscar_ID_FIPRCART(vl_inFPCAIDRE)

                Dim inFPCASECU As Integer = tbl.Rows(0).Item("FPCASECU")
                Dim inFPCANURE As Integer = tbl.Rows(0).Item("FPCANURE")
                Dim stFPCAUSIN As String = tbl.Rows(0).Item("FPCAUSIN")
                Dim daFPCAFEIN As Date = tbl.Rows(0).Item("FPCAFEIN")

                If objdatos.fun_Actualizar_FIPRCART(vl_inFPCAIDRE, _
                                                    vp_FichaPredial, _
                                                    Trim(Me.txtFPCAPLAN.Text), _
                                                    Trim(Me.txtFPCAVENT.Text), _
                                                    Trim(Me.txtFPCAESGR.Text), _
                                                    Me.cboFPCAVIGR.SelectedValue, _
                                                    Trim(Me.txtFPCAVUEL.Text), _
                                                    Trim(Me.txtFPCAFAJA.Text), _
                                                    Trim(Me.txtFPCAFOTO.Text), _
                                                    Me.cboFPCAVIAE.SelectedValue, _
                                                    Trim(Me.txtFPCAAMPL.Text), _
                                                    Trim(Me.txtFPCAESAE.Text), _
                                                    vl_stRESODEPA, _
                                                    vl_stRESOMUNI, _
                                                    vl_inRESOTIRE, _
                                                    vl_inRESOCLSE, _
                                                    vl_inRESOVIGE, _
                                                    vl_inRESORESO, _
                                                    inFPCASECU, _
                                                    inFPCANURE, _
                                                    cboFPCAESTA.SelectedValue, _
                                                    stFPCAUSIN, _
                                                    daFPCAFEIN) = True Then

                    mod_MENSAJE.Se_Guardaron_Los_Datos_Correctamente()
                    Me.txtFPCAPLAN.Focus()
                    Me.Close()
                Else
                    mod_MENSAJE.No_Se_Guardo_El_Registro_En_La_Base_De_Datos()
                    Me.txtFPCAPLAN.Focus()
                End If
            End If


        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub cmdCANCELAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSALIR.Click
        Me.txtFPCAPLAN.Focus()
        Me.Close()
    End Sub

#End Region

#Region "FORMULARIO"

#Region "Load"

    Private Sub frm_insertar_FIPRLIND_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        strBARRESTA.Items(0).Text = "Cartografia"
    End Sub

#End Region

#Region "Click"

    Private Sub cboFPCAVIGR_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboFPCAVIGR.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_VIGENCIA(cboFPCAVIGR, cboFPCAVIGR.SelectedIndex)
    End Sub
    Private Sub cboFPCAVIAE_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboFPCAVIAE.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_VIGENCIA(cboFPCAVIAE, cboFPCAVIAE.SelectedIndex)
    End Sub

#End Region

#Region "Validated"

    Private Sub txtFPCAPLAN_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFPCAPLAN.Validated
        If Trim(txtFPCAPLAN.Text) = "" Then
            txtFPCAPLAN.Focus()
            strBARRESTA.Items(1).Text = IncoValoNulo
        Else
            strBARRESTA.Items(1).Text = ""
        End If
    End Sub
    Private Sub txtFPCAESGR_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFPCAESGR.Validated
        If Trim(txtFPCAESGR.Text) = "" Then
            txtFPCAESGR.Focus()
            strBARRESTA.Items(1).Text = IncoValoNulo
        Else
            strBARRESTA.Items(1).Text = ""
        End If
    End Sub
    Private Sub cboFPCAVIGR_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboFPCAVIGR.Validated
        If Trim(cboFPCAVIGR.Text) = "" Then
            cboFPCAVIGR.Focus()
            strBARRESTA.Items(1).Text = IncoValoNulo
        Else
            strBARRESTA.Items(1).Text = ""
        End If
    End Sub
    Private Sub txtFPCAVUEL_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFPCAVUEL.Validated
        If Trim(txtFPCAVUEL.Text) = "" Then
            txtFPCAVUEL.Focus()
            strBARRESTA.Items(1).Text = IncoValoNulo
        Else
            strBARRESTA.Items(1).Text = ""
        End If
    End Sub
    Private Sub txtFPCAFAJA_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFPCAFAJA.Validated
        If Trim(txtFPCAFAJA.Text) = "" Then
            txtFPCAFAJA.Focus()
            strBARRESTA.Items(1).Text = IncoValoNulo
        Else
            strBARRESTA.Items(1).Text = ""
        End If
    End Sub
    Private Sub txtFPCAFOTO_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFPCAFOTO.Validated
        If Trim(txtFPCAFOTO.Text) = "" Then
            txtFPCAFOTO.Focus()
            strBARRESTA.Items(1).Text = IncoValoNulo
        Else
            strBARRESTA.Items(1).Text = ""
        End If
    End Sub
    Private Sub cboFPCAVIAE_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboFPCAVIAE.Validated
        If Trim(cboFPCAVIAE.Text) = "" Then
            cboFPCAVIAE.Focus()
            strBARRESTA.Items(1).Text = IncoValoNulo
        Else
            strBARRESTA.Items(1).Text = ""
        End If
    End Sub
    Private Sub txtFPCAESAE_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFPCAESAE.Validated
        If Trim(txtFPCAESAE.Text) = "" Then
            txtFPCAESAE.Focus()
            strBARRESTA.Items(1).Text = IncoValoNulo
        Else
            strBARRESTA.Items(1).Text = ""
        End If
    End Sub

#End Region

#Region "KeyPress"

    Private Sub txtFPCAPLAN_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFPCAPLAN.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            Me.txtFPCAVENT.Focus()
        End If
    End Sub
    Private Sub txtFPCAVENT_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFPCAVENT.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            Me.txtFPCAESGR.Focus()
        End If
    End Sub
    Private Sub txtFPCAESGR_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFPCAESGR.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            Me.cboFPCAVIGR.Focus()
        End If
    End Sub
    Private Sub cboFPCAVIGR_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboFPCAVIGR.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            Me.txtFPCAVUEL.Focus()
        End If
        If Char.IsNumber(e.KeyChar) Then
            fun_Cargar_ComboBox_Con_Datos_Activos_VIGENCIA(cboFPCAVIGR, cboFPCAVIGR.SelectedIndex)
        End If
    End Sub
    Private Sub txtFPCAVUEL_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFPCAVUEL.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            Me.txtFPCAFAJA.Focus()
        End If
    End Sub
    Private Sub txtFPCAFAJA_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFPCAFAJA.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            Me.txtFPCAFOTO.Focus()
        End If
    End Sub
    Private Sub txtFPCAFOTO_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFPCAFOTO.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            Me.cboFPCAVIAE.Focus()
        End If
    End Sub
    Private Sub cboFPCAVIAE_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboFPCAVIAE.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            Me.txtFPCAAMPL.Focus()
        End If
        If Char.IsNumber(e.KeyChar) Then
            fun_Cargar_ComboBox_Con_Datos_Activos_VIGENCIA(cboFPCAVIAE, cboFPCAVIAE.SelectedIndex)
        End If
    End Sub
    Private Sub txtFPCAAMPL_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFPCAAMPL.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            Me.txtFPCAESAE.Focus()
        End If
    End Sub
    Private Sub txtFPCAESAE_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFPCAESAE.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            Me.cboFPCAESTA.Focus()
        End If
    End Sub
    Private Sub cboFPCAESTA_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboFPCAESTA.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            Me.cmdGUARDAR.Focus()
        End If
    End Sub

#End Region

#Region "GotFocus"

    Private Sub txtFPCAPLAN_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFPCAPLAN.GotFocus
        txtFPCAPLAN.SelectionStart = 0
        txtFPCAPLAN.SelectionLength = Len(txtFPCAPLAN.Text)
        strBARRESTA.Items(0).Text = txtFPCAPLAN.AccessibleDescription
    End Sub
    Private Sub txtFPCAVENT_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFPCAVENT.GotFocus
        txtFPCAVENT.SelectionStart = 0
        txtFPCAVENT.SelectionLength = Len(txtFPCAVENT.Text)
        strBARRESTA.Items(0).Text = txtFPCAVENT.AccessibleDescription
    End Sub
    Private Sub txtFPCAESGR_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFPCAESGR.GotFocus
        txtFPCAESGR.SelectionStart = 0
        txtFPCAESGR.SelectionLength = Len(txtFPCAESGR.Text)
        strBARRESTA.Items(0).Text = txtFPCAESGR.AccessibleDescription
    End Sub
    Private Sub cboFPCAVIGR_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboFPCAVIGR.GotFocus
        strBARRESTA.Items(0).Text = cboFPCAVIGR.AccessibleDescription
    End Sub
    Private Sub txtFPCAVUEL_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFPCAVUEL.GotFocus
        txtFPCAVUEL.SelectionStart = 0
        txtFPCAVUEL.SelectionLength = Len(txtFPCAVUEL.Text)
        strBARRESTA.Items(0).Text = txtFPCAVUEL.AccessibleDescription
    End Sub
    Private Sub txtFPCAFAJA_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFPCAFAJA.GotFocus
        txtFPCAFAJA.SelectionStart = 0
        txtFPCAFAJA.SelectionLength = Len(txtFPCAFAJA.Text)
        strBARRESTA.Items(0).Text = txtFPCAFAJA.AccessibleDescription
    End Sub
    Private Sub txtFPCAFOTO_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFPCAFOTO.GotFocus
        txtFPCAFOTO.SelectionStart = 0
        txtFPCAFOTO.SelectionLength = Len(txtFPCAFOTO.Text)
        strBARRESTA.Items(0).Text = txtFPCAFOTO.AccessibleDescription
    End Sub
    Private Sub cboFPCAVIAE_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboFPCAVIAE.GotFocus
        strBARRESTA.Items(0).Text = cboFPCAVIAE.AccessibleDescription
    End Sub
    Private Sub txtFPCAAMPL_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFPCAAMPL.GotFocus
        txtFPCAAMPL.SelectionStart = 0
        txtFPCAAMPL.SelectionLength = Len(txtFPCAAMPL.Text)
        strBARRESTA.Items(0).Text = txtFPCAAMPL.AccessibleDescription
    End Sub
    Private Sub txtFPCAESAE_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFPCAESAE.GotFocus
        txtFPCAESAE.SelectionStart = 0
        txtFPCAESAE.SelectionLength = Len(txtFPCAESAE.Text)
        strBARRESTA.Items(0).Text = txtFPCAESAE.AccessibleDescription
    End Sub
    Private Sub cboFPCAESTA_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboFPCAESTA.GotFocus
        strBARRESTA.Items(0).Text = cboFPCAESTA.AccessibleDescription
    End Sub
    Private Sub cmdGUARDAR_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdGUARDAR.GotFocus
        strBARRESTA.Items(0).Text = cmdGUARDAR.AccessibleDescription
    End Sub
    Private Sub cmdCANCELAR_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdSALIR.GotFocus
        strBARRESTA.Items(0).Text = cmdSALIR.AccessibleDescription
    End Sub
#End Region

#Region "ResizeBegin"

    Private Sub frm_insertar_FICHPRED_ResizeBegin(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.ResizeBegin
        Me.Opacity = vp_Opacity
    End Sub

#End Region

#Region "ResizeEnd"

    Private Sub frm_insertar_FICHPRED_ResizeEnd(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.ResizeEnd
        Dim opacity As Double = Convert.ToDouble(100)
        Me.Opacity = opacity
    End Sub

#End Region

#End Region

End Class