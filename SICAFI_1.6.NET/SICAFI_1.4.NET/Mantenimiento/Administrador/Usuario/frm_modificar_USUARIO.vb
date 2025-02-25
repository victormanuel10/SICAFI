Imports REGLAS_DEL_NEGOCIO

Public Class frm_modificar_USUARIO

    '=========================
    '*** MODIFICAR USUARIO ***
    '=========================

    Dim id As Integer


    Public Sub New(ByVal idDataGrid As Integer)
        id = idDataGrid
        InitializeComponent()
        pro_inicializarControles()

    End Sub

#Region "VARIABLES LOCALES"

    '*** SW VERIFICAR CAMPOS LLENOS QUE VAN A LA DB ***
    Dim SWVerificarCamposLlenos As Boolean = False

#End Region

#Region "PROCEDIMIENTOS"

    Public Sub pro_inicializarControles()
        '=================================
        ' CARGA LOS COMBOBOX CON LOS DATOS 
        '=================================

        fun_Cargar_ComboBox_Con_Todos_Los_Datos_TIPODOCU(cboUSUATIDO, cboUSUATIDO.SelectedIndex)
        fun_Cargar_ComboBox_Con_Todos_Los_Datos_CALIPROP(cboUSUACAPR, cboUSUACAPR.SelectedIndex)
        fun_Cargar_ComboBox_Con_Todos_Los_Datos_SEXO(cboUSUASEXO, cboUSUASEXO.SelectedIndex)
        fun_Cargar_ComboBox_Con_Todos_Los_Datos_ESTADO(cboUSUAESTA, cboUSUAESTA.SelectedIndex)

        Dim objdatos As New cla_USUARIO
        Dim tbl As New DataTable

        tbl = objdatos.fun_Buscar_ID_USUARIO(id)

        txtUSUANUDO.Text = Trim(tbl.Rows(0).Item(1))
        cboUSUATIDO.SelectedValue = tbl.Rows(0).Item(2)
        cboUSUACAPR.SelectedValue = tbl.Rows(0).Item(3)
        cboUSUASEXO.SelectedValue = tbl.Rows(0).Item(4)
        txtUSUANOMB.Text = Trim(tbl.Rows(0).Item(5))
        txtUSUAPRAP.Text = Trim(tbl.Rows(0).Item(6))
        txtUSUASEAP.Text = Trim(tbl.Rows(0).Item(7))
        txtUSUASICO.Text = Trim(tbl.Rows(0).Item(8))
        txtUSUATEL1.Text = Trim(tbl.Rows(0).Item(9))
        txtUSUATEL2.Text = Trim(tbl.Rows(0).Item(10))
        txtUSUAFAX1.Text = Trim(tbl.Rows(0).Item(11))
        txtUSUADIRE.Text = Trim(tbl.Rows(0).Item(12))
        cboUSUAESTA.SelectedValue = tbl.Rows(0).Item(13)
        txtUSUAOBSE.Text = Trim(tbl.Rows(0).Item(18))

        '==========================================================
        ' CARGA LA DESCRIPCIÓN (Los reg. activos ya estan cargados)
        '==========================================================
        Try
            Dim boTIPODOCU As Boolean = fun_Buscar_Dato_TIPODOCU(cboUSUATIDO.SelectedValue)
            Dim boCALIPROP As Boolean = fun_Buscar_Dato_CALIPROP(cboUSUACAPR.SelectedValue)
            Dim boSEXO As Boolean = fun_Buscar_Dato_SEXO(cboUSUASEXO.SelectedValue)

            If boTIPODOCU = True AndAlso boCALIPROP = True AndAlso boSEXO = True Then

                lblUSUATIDO.Text = CType(fun_Buscar_Lista_Valores_TIPODOCU(cboUSUATIDO.SelectedValue), String)
                lblUSUACAPR.Text = CType(fun_Buscar_Lista_Valores_CALIPROP(cboUSUACAPR.SelectedValue), String)
                lblUSUASEXO.Text = CType(fun_Buscar_Lista_Valores_SEXO(cboUSUASEXO.SelectedValue), String)
            Else
                frm_INCO_insertar_registro_sin_listas_de_valores.ShowDialog()
            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

        cboUSUATIDO.Focus()

    End Sub
    Private Sub pro_VerificarCamposLlenos()
        '*** CAMPOS OBLIGATORIOS ***

        Try
            If Trim(txtUSUANUDO.Text) = "" Or _
               Trim(cboUSUATIDO.Text) = "" Or _
               Trim(cboUSUACAPR.Text) = "" Or _
               Trim(cboUSUASEXO.Text) = "" Or _
               Trim(txtUSUANOMB.Text) = "" Or _
               Trim(txtUSUAPRAP.Text) = "" Then
                SWVerificarCamposLlenos = False
            Else
                SWVerificarCamposLlenos = True 'Los campos estan bien diligenciados
            End If

        Catch ex As Exception
            MessageBox.Show("" & Err.Description & "")
        End Try

    End Sub
    Private Sub pro_LimpiarCampos()

        txtUSUANUDO.Text = ""
        txtUSUANOMB.Text = ""
        txtUSUAPRAP.Text = ""
        txtUSUASEAP.Text = ""
        txtUSUASICO.Text = ""
        txtUSUATEL1.Text = ""
        txtUSUATEL2.Text = ""
        txtUSUAFAX1.Text = ""
        txtUSUADIRE.Text = ""
        txtUSUAOBSE.Text = ""

    End Sub

#End Region

#Region "MENU"

    Private Sub cmdGUARDAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGUARDAR.Click

        pro_VerificarCamposLlenos()

        If SWVerificarCamposLlenos = True Then

            '==========================================================
            '*** BUSCA EL USUARIO QUE INGRESA Y LA FECHA DE INGRESO ***
            '==========================================================
            Dim objdatos1 As New cla_USUARIO
            Dim tbl1 As New DataTable

            tbl1 = objdatos1.fun_Buscar_ID_USUARIO(id)

            Dim stUSUAUSIN As String = Trim(tbl1.Rows(0).Item(14))
            Dim daUSUAFEIN As Date = Trim(tbl1.Rows(0).Item(16))

            '=============================
            '*** ACTUALIZA EL REGISTRO ***
            '=============================

            Dim objdatos As New cla_USUARIO

            If (objdatos.fun_Actualizar_USUARIO(id, txtUSUANUDO.Text, cboUSUATIDO.SelectedValue, cboUSUACAPR.SelectedValue, cboUSUASEXO.SelectedValue, txtUSUANOMB.Text, txtUSUAPRAP.Text, txtUSUASEAP.Text, txtUSUASICO.Text, txtUSUATEL1.Text, txtUSUATEL2.Text, txtUSUAFAX1.Text, txtUSUADIRE.Text, cboUSUAESTA.SelectedValue, stUSUAUSIN, daUSUAFEIN, txtUSUAOBSE.Text)) Then
                mod_MENSAJE.Se_Modificaron_Los_Datos_Correctamente()
                Me.Close()
            Else
                mod_MENSAJE.No_Se_Modifico_El_Registro_En_La_Base_De_Datos()
            End If

        Else
            mod_MENSAJE.Existen_Campos_Sin_Diligenciar()
            cboUSUATIDO.Focus()
        End If

    End Sub
    Private Sub cmdCANCELAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Close()

    End Sub

#End Region

#Region "FORMULARIO"

    Private Sub cboUSUATIDO_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboUSUATIDO.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            cboUSUACAPR.Focus()
        End If

        If Char.IsNumber(e.KeyChar) Then
            fun_Cargar_ComboBox_Con_Datos_Activos_TIPODOCU(cboUSUATIDO, cboUSUATIDO.SelectedIndex)
        End If

    End Sub
    Private Sub cboUSUACAPR_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboUSUACAPR.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            cboUSUASEXO.Focus()
        End If

        If Char.IsNumber(e.KeyChar) Then
            fun_Cargar_ComboBox_Con_Datos_Activos_CALIPROP(cboUSUACAPR, cboUSUACAPR.SelectedIndex)
        End If
    End Sub
    Private Sub cboUSUASEXO_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboUSUASEXO.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            txtUSUANOMB.Focus()
        End If

        If Char.IsNumber(e.KeyChar) Then
            fun_Cargar_ComboBox_Con_Datos_Activos_SEXO(cboUSUASEXO, cboUSUASEXO.SelectedIndex)
        End If
    End Sub
    Private Sub txtUSUANOMB_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtUSUANOMB.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            txtUSUAPRAP.Focus()
        End If
    End Sub
    Private Sub txtUSUAPRAP_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtUSUAPRAP.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            txtUSUASEAP.Focus()
        End If
    End Sub
    Private Sub txtUSUASEAP_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtUSUASEAP.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            txtUSUASICO.Focus()
        End If
    End Sub
    Private Sub txtUSUASICO_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtUSUASICO.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            txtUSUATEL1.Focus()
        End If
    End Sub
    Private Sub txtUSUATEL1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtUSUATEL1.KeyPress
        If Not Char.IsNumber(e.KeyChar) Then
            If e.KeyChar <> Convert.ToChar(Keys.Back) Then
                If e.KeyChar <> Convert.ToChar(Keys.Enter) Then
                    e.Handled = True
                    strBARRESTA.Items(1).Text = IncoValoNume
                    mod_MENSAJE.Inco_Valo_Nume()
                Else
                    txtUSUATEL2.Focus()
                End If
            End If
        End If
    End Sub
    Private Sub txtUSUATEL2_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtUSUATEL2.KeyPress
        If Not Char.IsNumber(e.KeyChar) Then
            If e.KeyChar <> Convert.ToChar(Keys.Back) Then
                If e.KeyChar <> Convert.ToChar(Keys.Enter) Then
                    e.Handled = True
                    strBARRESTA.Items(1).Text = IncoValoNume
                    mod_MENSAJE.Inco_Valo_Nume()
                Else
                    txtUSUAFAX1.Focus()
                End If
            End If
        End If
    End Sub
    Private Sub txtUSUAFAX1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtUSUAFAX1.KeyPress
        If Not Char.IsNumber(e.KeyChar) Then
            If e.KeyChar <> Convert.ToChar(Keys.Back) Then
                If e.KeyChar <> Convert.ToChar(Keys.Enter) Then
                    e.Handled = True
                    strBARRESTA.Items(1).Text = IncoValoNume
                    mod_MENSAJE.Inco_Valo_Nume()
                Else
                    txtUSUADIRE.Focus()
                End If
            End If
        End If
    End Sub
    Private Sub txtUSUADIRE_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtUSUADIRE.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            cboUSUAESTA.Focus()
        End If
    End Sub
    Private Sub cboUSUAESTA_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboUSUAESTA.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            cmdGUARDAR.Focus()
        End If
    End Sub

    Private Sub cboUSUATIDO_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboUSUATIDO.Validated
        strBARRESTA.Items(0).Text = ""
        strBARRESTA.Items(1).Text = ""
    End Sub
    Private Sub cboUSUACAPR_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboUSUACAPR.Validated
        strBARRESTA.Items(0).Text = ""
        strBARRESTA.Items(1).Text = ""
    End Sub
    Private Sub cboUSUASEXO_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboUSUASEXO.Validated
        strBARRESTA.Items(0).Text = ""
        strBARRESTA.Items(1).Text = ""
    End Sub
    Private Sub txtUSUANOMB_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtUSUANOMB.Validated
        If Trim(txtUSUANOMB.Text) = "" Then
            txtUSUANOMB.Focus()
            strBARRESTA.Items(1).Text = IncoValoNulo
        Else
            strBARRESTA.Items(0).Text = ""
            strBARRESTA.Items(1).Text = ""
        End If
    End Sub
    Private Sub txtUSUAPRAP_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtUSUAPRAP.Validated
        If Trim(txtUSUAPRAP.Text) = "" Then
            txtUSUAPRAP.Focus()
            strBARRESTA.Items(1).Text = IncoValoNulo
        Else
            strBARRESTA.Items(0).Text = ""
            strBARRESTA.Items(1).Text = ""
        End If
    End Sub
    Private Sub txtUSUASEAP_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtUSUASEAP.Validated
        strBARRESTA.Items(0).Text = ""
        strBARRESTA.Items(1).Text = ""
    End Sub
    Private Sub txtUSUASICO_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtUSUASICO.Validated
        strBARRESTA.Items(0).Text = ""
        strBARRESTA.Items(1).Text = ""
    End Sub
    Private Sub txtUSUATEL1_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtUSUATEL1.Validated
        strBARRESTA.Items(0).Text = ""
        strBARRESTA.Items(1).Text = ""
    End Sub
    Private Sub txtUSUATEL2_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtUSUATEL2.Validated
        strBARRESTA.Items(0).Text = ""
        strBARRESTA.Items(1).Text = ""
    End Sub
    Private Sub txtUSUAFAX1_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtUSUAFAX1.Validated
        strBARRESTA.Items(0).Text = ""
        strBARRESTA.Items(1).Text = ""
    End Sub
    Private Sub txtUSUADIRE_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtUSUADIRE.Validated
        strBARRESTA.Items(0).Text = ""
        strBARRESTA.Items(1).Text = ""
    End Sub
    Private Sub cboUSUAESTA_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboUSUAESTA.Validated
        strBARRESTA.Items(0).Text = ""
        strBARRESTA.Items(1).Text = ""
    End Sub
    Private Sub txtUSUAOBSE_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtUSUAOBSE.Validated
        strBARRESTA.Items(0).Text = ""
        strBARRESTA.Items(1).Text = ""
    End Sub

    Private Sub cboUSUATIDO_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboUSUATIDO.GotFocus
        strBARRESTA.Items(0).Text = cboUSUATIDO.AccessibleDescription
    End Sub
    Private Sub cboUSUACAPR_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboUSUACAPR.GotFocus
        strBARRESTA.Items(0).Text = cboUSUACAPR.AccessibleDescription
    End Sub
    Private Sub cboUSUASEXO_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboUSUASEXO.GotFocus
        strBARRESTA.Items(0).Text = cboUSUASEXO.AccessibleDescription
    End Sub
    Private Sub txtUSUANOMB_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtUSUANOMB.GotFocus
        txtUSUANOMB.SelectionStart = 0
        txtUSUANOMB.SelectionLength = Len(txtUSUANOMB.Text)
        strBARRESTA.Items(0).Text = txtUSUANOMB.AccessibleDescription
    End Sub
    Private Sub txtUSUAPRAP_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtUSUAPRAP.GotFocus
        txtUSUAPRAP.SelectionStart = 0
        txtUSUAPRAP.SelectionLength = Len(txtUSUAPRAP.Text)
        strBARRESTA.Items(0).Text = txtUSUAPRAP.AccessibleDescription
    End Sub
    Private Sub txtUSUASEAP_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtUSUASEAP.GotFocus
        txtUSUASEAP.SelectionStart = 0
        txtUSUASEAP.SelectionLength = Len(txtUSUASEAP.Text)
        strBARRESTA.Items(0).Text = txtUSUASEAP.AccessibleDescription
    End Sub
    Private Sub txtUSUASICO_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtUSUASICO.GotFocus
        txtUSUASICO.SelectionStart = 0
        txtUSUASICO.SelectionLength = Len(txtUSUASICO.Text)
        strBARRESTA.Items(0).Text = txtUSUASICO.AccessibleDescription
    End Sub
    Private Sub txtUSUATEL1_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtUSUATEL1.GotFocus
        txtUSUATEL1.SelectionStart = 0
        txtUSUATEL1.SelectionLength = Len(txtUSUATEL1.Text)
        strBARRESTA.Items(0).Text = txtUSUATEL1.AccessibleDescription
    End Sub
    Private Sub txtUSUATEL2_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtUSUATEL2.GotFocus
        txtUSUATEL2.SelectionStart = 0
        txtUSUATEL2.SelectionLength = Len(txtUSUATEL2.Text)
        strBARRESTA.Items(0).Text = txtUSUATEL2.AccessibleDescription
    End Sub
    Private Sub txtUSUAFAX1_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtUSUAFAX1.GotFocus
        txtUSUAFAX1.SelectionStart = 0
        txtUSUAFAX1.SelectionLength = Len(txtUSUAFAX1.Text)
        strBARRESTA.Items(0).Text = txtUSUAFAX1.AccessibleDescription
    End Sub
    Private Sub txtUSUADIRE_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtUSUADIRE.GotFocus
        txtUSUADIRE.SelectionStart = 0
        txtUSUADIRE.SelectionLength = Len(txtUSUADIRE.Text)
        strBARRESTA.Items(0).Text = txtUSUADIRE.AccessibleDescription
    End Sub
    Private Sub cboUSUAESTA_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboUSUAESTA.GotFocus
        strBARRESTA.Items(0).Text = cboUSUAESTA.AccessibleDescription
    End Sub
    Private Sub txtUSUAOBSE_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtUSUAOBSE.GotFocus
        strBARRESTA.Items(0).Text = txtUSUAOBSE.AccessibleDescription
    End Sub
    Private Sub cmdGUARDAR_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdGUARDAR.GotFocus
        strBARRESTA.Items(0).Text = cmdGUARDAR.AccessibleDescription
    End Sub
    Private Sub cmdCANCELAR_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdSALIR.GotFocus
        strBARRESTA.Items(0).Text = cmdSALIR.AccessibleDescription
    End Sub

    Private Sub cboUSUATIDO_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboUSUATIDO.SelectedIndexChanged
        lblUSUATIDO.Text = CType(fun_Buscar_Lista_Valores_TIPODOCU(Val(cboUSUATIDO.Text)), String)

    End Sub
    Private Sub cboUSUACAPR_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboUSUACAPR.SelectedIndexChanged
        lblUSUACAPR.Text = CType(fun_Buscar_Lista_Valores_CALIPROP(Val(cboUSUACAPR.Text)), String)

    End Sub
    Private Sub cboUSUASEXO_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboUSUASEXO.SelectedIndexChanged
        lblUSUASEXO.Text = CType(fun_Buscar_Lista_Valores_SEXO(Val(cboUSUASEXO.Text)), String)
      
    End Sub

    Private Sub cboUSUATIDO_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboUSUATIDO.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_TIPODOCU(cboUSUATIDO, cboUSUATIDO.SelectedIndex)

    End Sub
    Private Sub cboUSUACAPR_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboUSUACAPR.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_CALIPROP(cboUSUACAPR, cboUSUACAPR.SelectedIndex)

    End Sub
    Private Sub cboUSUASEXO_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboUSUASEXO.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_SEXO(cboUSUASEXO, cboUSUASEXO.SelectedIndex)

    End Sub

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