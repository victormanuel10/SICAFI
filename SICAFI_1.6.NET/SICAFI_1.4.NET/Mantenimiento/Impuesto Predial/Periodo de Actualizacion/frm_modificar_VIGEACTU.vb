Imports REGLAS_DEL_NEGOCIO

Public Class frm_modificar_VIGEACTU

    '========================================
    '*** MODIFICAR VIGENCIA ACTUALIZACIÓN ***
    '========================================

#Region "VARIABLE"

    Dim inID_REGISTRO As Integer

#End Region

#Region "CONSTRUCTOR"

    Public Sub New(ByVal inInRegistro As Integer)
        inID_REGISTRO = inInRegistro

        InitializeComponent()
        pro_LimpiarCampos()
        pro_inicializarControles()
    End Sub

#End Region

#Region "PROCEDIMIENTOS"

    Private Sub pro_inicializarControles()

        Try
            Dim objdatos1 As New cla_DEPARTAMENTO

            Me.cboVIACDEPA.DataSource = objdatos1.fun_Consultar_CAMPOS_MANT_DEPARTAMENTO
            Me.cboVIACDEPA.DisplayMember = "DEPADESC"
            Me.cboVIACDEPA.ValueMember = "DEPACODI"

            Dim objdatos2 As New cla_CLASSECT

            Me.cboVIACCLSE.DataSource = objdatos2.fun_Consultar_CAMPOS_MANT_CLASSECT
            Me.cboVIACCLSE.DisplayMember = "CLSEDESC"
            Me.cboVIACCLSE.ValueMember = "CLSECODI"

            Dim objdatos23 As New cla_VIGENCIA

            Me.cboVIACVIAC.DataSource = objdatos23.fun_Consultar_CAMPOS_VIGENCIA
            Me.cboVIACVIAC.DisplayMember = "VIGEDESC"
            Me.cboVIACVIAC.ValueMember = "VIGECODI"

            Dim objdatos As New cla_ESTADO

            Me.cboVIACESTA.DataSource = objdatos.fun_Consultar_ESTADO_X_ESTADO
            Me.cboVIACESTA.DisplayMember = "ESTADESC"
            Me.cboVIACESTA.ValueMember = "ESTACODI"

            Dim objdatos3 As New cla_VIGEACTU
            Dim tbl As New DataTable

            tbl = objdatos3.fun_Buscar_ID_VIGEACTU(inID_REGISTRO)

            Me.cboVIACDEPA.SelectedValue = tbl.Rows(0).Item("VIACDEPA")

            Dim objdatos7 As New cla_MUNICIPIO

            Me.cboVIACMUNI.DataSource = objdatos7.fun_Consultar_CAMPOS_MANT_MUNICIPIO
            Me.cboVIACMUNI.DisplayMember = "MUNIDESC"
            Me.cboVIACMUNI.ValueMember = "MUNICODI"

            Me.cboVIACMUNI.SelectedValue = tbl.Rows(0).Item("VIACMUNI")
            Me.cboVIACCLSE.SelectedValue = tbl.Rows(0).Item("VIACCLSE")
            Me.txtVIACRESO.Text = Trim(tbl.Rows(0).Item("VIACRESO"))
            Me.txtVIACDESC.Text = Trim(tbl.Rows(0).Item("VIACDESC"))
            Me.cboVIACVIAC.SelectedValue = tbl.Rows(0).Item("VIACVIAC")
            Me.txtVIACPOIN.Text = Trim(tbl.Rows(0).Item("VIACPOIN"))
            Me.rbdVIACACTU.Checked = tbl.Rows(0).Item("VIACACTU")
            Me.rbdVIACCONS.Checked = tbl.Rows(0).Item("VIACCONS")
            Me.cboVIACESTA.SelectedValue = tbl.Rows(0).Item("VIACESTA")
         
            Dim boVIACDEPA As Boolean = fun_Buscar_Dato_DEPARTAMENTO(Me.cboVIACDEPA.SelectedValue)
            Dim boVIACMUNI As Boolean = fun_Buscar_Dato_MUNICIPIO(Me.cboVIACDEPA.SelectedValue, Me.cboVIACMUNI.SelectedValue)
            Dim boVIACCLSE As Boolean = fun_Buscar_Dato_CLASSECT(Me.cboVIACCLSE.SelectedValue)
            Dim boVIACVIAC As Boolean = fun_Buscar_Dato_VIGENCIA(Me.cboVIACVIAC.SelectedValue)

            If boVIACDEPA = True OrElse boVIACMUNI = True OrElse boVIACCLSE = True OrElse boVIACVIAC = True Then

                Me.lblVIACDEPA.Text = CType(fun_Buscar_Lista_Valores_DEPARTAMENTO_Codigo(Me.cboVIACDEPA), String)
                Me.lblVIACMUNI.Text = CType(fun_Buscar_Lista_Valores_MUNICIPIO_Codigo(Me.cboVIACDEPA, Me.cboVIACMUNI), String)
                Me.lblVIACCLSE.Text = CType(fun_Buscar_Lista_Valores_CLASSECT_Codigo(Me.cboVIACCLSE), String)
                Me.lblVIACVIAC.Text = CType(fun_Buscar_Lista_Valores_VIGENCIA_Codigo(Me.cboVIACVIAC), String)

            Else
                frm_INCO_modifircar_registros_sin_listas_de_valores.ShowDialog()
            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub pro_LimpiarCampos()

        pp_pro_LimpiarCampos(fraVIGEACTU)

    End Sub

#End Region

#Region "MENU"

    Private Sub cmdGUARDAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGUARDAR.Click

        Try

            ' instancia la clase
            Dim objVerifica As New cla_Verificar_Dato

            Dim boVIACDEPA As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboVIACDEPA)
            Dim boVIACMUNI As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboVIACMUNI)
            Dim boVIACCLSE As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboVIACCLSE)
            Dim boVIACRESO As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Numerico(Me.txtVIACRESO)
            Dim boVIACDESC As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.txtVIACDESC)
            Dim boVIACVIAC As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboVIACVIAC)
            Dim boVIACPOIN As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Decimal(Me.txtVIACPOIN)
            Dim boVIACESTA As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboVIACESTA)

            ' verifica los datos del formulario 
            If boVIACDEPA = True And _
               boVIACMUNI = True And _
               boVIACCLSE = True And _
               boVIACRESO = True And _
               boVIACDESC = True And _
               boVIACVIAC = True And _
               boVIACPOIN = True And _
               boVIACESTA = True Then

                Dim objdatos22 As New cla_VIGEACTU

                If (objdatos22.fun_Actualizar_VIGEACTU(inID_REGISTRO, _
                                                         Me.cboVIACDEPA.SelectedValue, _
                                                         Me.cboVIACMUNI.SelectedValue, _
                                                         Me.cboVIACCLSE.SelectedValue, _
                                                         Me.txtVIACRESO.Text, _
                                                         Me.txtVIACDESC.Text, _
                                                         Me.cboVIACVIAC.SelectedValue, _
                                                         Me.txtVIACPOIN.Text, _
                                                         Me.rbdVIACACTU.Checked, _
                                                         Me.rbdVIACCONS.Checked, _
                                                         Me.cboVIACESTA.SelectedValue)) Then

                    mod_MENSAJE.Se_Guardaron_Los_Datos_Correctamente()

                    Me.cboVIACDEPA.Focus()
                    Me.Close()
                Else
                    mod_MENSAJE.No_Se_Guardo_El_Registro_En_La_Base_De_Datos()
                End If
            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description & "Guardar")
        End Try


    End Sub
    Private Sub cmdCANCELAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSALIR.Click
        Me.cboVIACDEPA.Focus()
        Me.Close()
    End Sub

#End Region

#Region "FORMULARIO"

#Region "KeyDown"

    Private Sub cboVIACDEPA_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboVIACDEPA.KeyDown
        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
            fun_Cargar_ComboBox_Con_Datos_Activos_DEPARTAMENTO_Descripcion(Me.cboVIACDEPA, Me.cboVIACDEPA.SelectedIndex)
        End If
    End Sub
    Private Sub cboVIACMUNI_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboVIACMUNI.KeyDown
        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
            fun_Cargar_ComboBox_Con_Datos_Activos_MUNICIPIO_X_DEPARTAMENTO_Descripcion(Me.cboVIACMUNI, Me.cboVIACMUNI.SelectedIndex, Me.cboVIACDEPA)
        End If
    End Sub
    Private Sub cboVIACCLSE_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboVIACCLSE.KeyDown
        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
            fun_Cargar_ComboBox_Con_Datos_Activos_CLASSECT_Descripcion(Me.cboVIACCLSE, Me.cboVIACCLSE.SelectedIndex)
        End If
    End Sub
    Private Sub cboVIACVIAC_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboVIACVIAC.KeyDown
        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
            fun_Cargar_ComboBox_Con_Datos_Activos_VIGENCIA_Descripcion(Me.cboVIACVIAC, Me.cboVIACVIAC.SelectedIndex)
        End If
    End Sub
    Private Sub cboVIACESTA_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboVIACESTA.KeyDown
        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
            fun_Cargar_ComboBox_Con_Datos_Activos_ESTADO(Me.cboVIACESTA, Me.cboVIACESTA.SelectedIndex)
        End If
    End Sub

#End Region

#Region "KeyPress"

    Private Sub txt_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboVIACDEPA.KeyPress, cboVIACMUNI.KeyPress, cboVIACCLSE.KeyPress, txtVIACRESO.KeyPress, txtVIACDESC.KeyPress, cboVIACVIAC.KeyPress, txtVIACPOIN.KeyPress, rbdVIACACTU.KeyPress, rbdVIACCONS.KeyPress, cboVIACESTA.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Or e.KeyChar = Convert.ToChar(Keys.Tab) Then
            pp_pro_SaltarCampo()
        End If
    End Sub

#End Region

#Region "GotFocus"

    Private Sub txt_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtVIACRESO.GotFocus, txtVIACDESC.GotFocus, txtVIACPOIN.GotFocus
        pp_pro_SobrearCampo(sender)
        pp_pro_DescripcionCampo(Me.strBARRESTA.Items(0), sender)
    End Sub
    Private Sub cmd_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdGUARDAR.GotFocus, cmdSALIR.GotFocus
        pp_pro_DescripcionCampo(Me.strBARRESTA.Items(0), sender)
    End Sub
    Private Sub cbo_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboVIACDEPA.GotFocus, cboVIACMUNI.GotFocus, cboVIACCLSE.GotFocus, cboVIACVIAC.GotFocus, cboVIACESTA.GotFocus
        pp_pro_DescripcionCampo(Me.strBARRESTA.Items(0), sender)
    End Sub
    Private Sub rbd_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles rbdVIACACTU.GotFocus, rbdVIACCONS.GotFocus
        pp_pro_DescripcionCampo(Me.strBARRESTA.Items(0), sender)
    End Sub

#End Region

#Region "Click"

    Private Sub cboVIACDEPA_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboVIACDEPA.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_DEPARTAMENTO_Descripcion(Me.cboVIACDEPA, Me.cboVIACDEPA.SelectedIndex)
    End Sub
    Private Sub cboVIACMUNI_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboVIACMUNI.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_MUNICIPIO_X_DEPARTAMENTO_Descripcion(Me.cboVIACMUNI, Me.cboVIACMUNI.SelectedIndex, Me.cboVIACDEPA)
    End Sub
    Private Sub cboVIACCLSE_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboVIACCLSE.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_CLASSECT_Descripcion(Me.cboVIACCLSE, Me.cboVIACCLSE.SelectedIndex)
    End Sub
    Private Sub cboVIACVIAC_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboVIACVIAC.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_VIGENCIA_Descripcion(Me.cboVIACVIAC, Me.cboVIACVIAC.SelectedIndex)
    End Sub
    Private Sub cboVIACESTA_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboVIACESTA.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_ESTADO(Me.cboVIACESTA, Me.cboVIACESTA.SelectedIndex)
    End Sub

#End Region

#Region "SelectedIndexChanged"

    Private Sub cboVIACDEPA_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboVIACDEPA.SelectedIndexChanged
        Me.lblVIACDEPA.Text = CType(fun_Buscar_Lista_Valores_DEPARTAMENTO_Codigo(Me.cboVIACDEPA), String)

        Me.cboVIACMUNI.DataSource = New DataTable
        Me.lblVIACMUNI.Text = ""

    End Sub
    Private Sub cboVIACMUNI_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboVIACMUNI.SelectedIndexChanged
        Me.lblVIACMUNI.Text = CType(fun_Buscar_Lista_Valores_MUNICIPIO_Codigo(Me.cboVIACDEPA, Me.cboVIACMUNI), String)
    End Sub
    Private Sub cboVIACCLSE_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboVIACCLSE.SelectedIndexChanged
        Me.lblVIACCLSE.Text = CType(fun_Buscar_Lista_Valores_CLASSECT_Codigo(Me.cboVIACCLSE), String)
    End Sub
    Private Sub cboVIACVIAC_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboVIACVIAC.SelectedIndexChanged
        Me.lblVIACVIAC.Text = CType(fun_Buscar_Lista_Valores_VIGENCIA_Codigo(Me.cboVIACVIAC), String)
    End Sub

#End Region

#Region "Validated"

    Private Sub txtVIACPOIN_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtVIACPOIN.Validated
        If Trim(Me.txtVIACPOIN.Text) = "" Then
            Me.txtVIACPOIN.Text = "1.000"
        Else
            Me.txtVIACPOIN.Text = fun_Formato_Decimal_3_Decimales(Trim(Me.txtVIACPOIN.Text))
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