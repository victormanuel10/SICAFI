Imports REGLAS_DEL_NEGOCIO

Public Class frm_modificar_RANGARTE

    '====================================================
    '*** MODIFICAR TARIFAS POR DESTINACIÓN ECONÓMICAS ***
    '====================================================

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
            Dim objdatos3 As New cla_RANGARTE
            Dim tbl As New DataTable

            tbl = objdatos3.fun_Buscar_ID_RANGARTE(inID_REGISTRO)

            Dim objdatos1 As New cla_DEPARTAMENTO

            Me.cboRAATDEPA.DataSource = objdatos1.fun_Consultar_CAMPOS_MANT_DEPARTAMENTO
            Me.cboRAATDEPA.DisplayMember = "DEPADESC"
            Me.cboRAATDEPA.ValueMember = "DEPACODI"

            Me.cboRAATDEPA.SelectedValue = tbl.Rows(0).Item("RAATDEPA")

            Dim objdatos7 As New cla_MUNICIPIO

            Me.cboRAATMUNI.DataSource = objdatos7.fun_Consultar_CAMPOS_MANT_MUNICIPIO
            Me.cboRAATMUNI.DisplayMember = "MUNIDESC"
            Me.cboRAATMUNI.ValueMember = "MUNICODI"

            Me.cboRAATMUNI.SelectedValue = tbl.Rows(0).Item("RAATMUNI")

            Dim objdatos2 As New cla_CLASSECT

            Me.cboRAATCLSE.DataSource = objdatos2.fun_Consultar_CAMPOS_MANT_CLASSECT
            Me.cboRAATCLSE.DisplayMember = "CLSEDESC"
            Me.cboRAATCLSE.ValueMember = "CLSECODI"

            Me.cboRAATCLSE.SelectedValue = tbl.Rows(0).Item("RAATCLSE")

            Dim objdatos As New cla_ESTADO

            Me.cboRAATESTA.DataSource = objdatos.fun_Consultar_ESTADO_X_ESTADO
            Me.cboRAATESTA.DisplayMember = "ESTADESC"
            Me.cboRAATESTA.ValueMember = "ESTACODI"

            Me.txtRAATATIN.Text = Trim(tbl.Rows(0).Item("RAATATIN"))
            Me.txtRAATATFI.Text = Trim(tbl.Rows(0).Item("RAATATFI"))
            Me.txtRAATPORC.Text = Trim(tbl.Rows(0).Item("RAATPORC"))
            Me.cboRAATESTA.SelectedValue = tbl.Rows(0).Item("RAATESTA")

            Dim boRAATDEPA As Boolean = fun_Buscar_Dato_DEPARTAMENTO(Me.cboRAATDEPA.SelectedValue)
            Dim boRAATMUNI As Boolean = fun_Buscar_Dato_MUNICIPIO(Me.cboRAATDEPA.SelectedValue, Me.cboRAATMUNI.SelectedValue)
            Dim boRAATCLSE As Boolean = fun_Buscar_Dato_CLASSECT(Me.cboRAATCLSE.SelectedValue)

            If boRAATDEPA = True OrElse boRAATMUNI = True OrElse boRAATCLSE = True Then

                Me.lblRAATDEPA.Text = CType(fun_Buscar_Lista_Valores_DEPARTAMENTO_Codigo(Me.cboRAATDEPA), String)
                Me.lblRAATMUNI.Text = CType(fun_Buscar_Lista_Valores_MUNICIPIO_Codigo(Me.cboRAATDEPA, Me.cboRAATMUNI), String)
                Me.lblRAATCLSE.Text = CType(fun_Buscar_Lista_Valores_CLASSECT_Codigo(Me.cboRAATCLSE), String)
            Else
                frm_INCO_modifircar_registros_sin_listas_de_valores.ShowDialog()
            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub pro_LimpiarCampos()

        Me.txtRAATPORC.Text = "0.00"
        Me.lblRAATDEPA.Text = ""
        Me.lblRAATMUNI.Text = ""
        Me.lblRAATCLSE.Text = ""
        Me.txtRAATATIN.Text = ""
        Me.txtRAATATFI.Text = ""

        Me.strBARRESTA.Items(1).Text = ""

        Me.cboRAATDEPA.DataSource = New DataTable
        Me.cboRAATMUNI.DataSource = New DataTable
        Me.cboRAATCLSE.DataSource = New DataTable
        Me.cboRAATESTA.DataSource = New DataTable

    End Sub

#End Region

#Region "MENU"

    Private Sub cmdGUARDAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGUARDAR.Click

        Try

            ' instancia la clase
            Dim objVerifica As New cla_Verificar_Dato

            Dim boRAATDEPA As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboRAATDEPA)
            Dim boRAATMUNI As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboRAATMUNI)
            Dim boRAATCLSE As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboRAATCLSE)
            Dim boRAATATIN As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Numerico(Me.txtRAATATIN)
            Dim boRAATATFI As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Numerico(Me.txtRAATATFI)
            Dim boRAATPORC As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Decimal(Me.txtRAATPORC)
            Dim boRAATESTA As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboRAATESTA)

            ' verifica los datos del formulario 
            If boRAATDEPA = True And _
               boRAATMUNI = True And _
               boRAATCLSE = True And _
               boRAATATIN = True And _
               boRAATATFI = True And _
               boRAATPORC = True And _
               boRAATESTA = True Then

                Dim objdatos22 As New cla_RANGARTE

                If (objdatos22.fun_Actualizar_RANGARTE(inID_REGISTRO, _
                                                     Me.cboRAATDEPA.SelectedValue, _
                                                     Me.cboRAATMUNI.SelectedValue, _
                                                     Me.cboRAATCLSE.SelectedValue, _
                                                     Me.txtRAATATIN.Text, _
                                                     Me.txtRAATATFI.Text, _
                                                     Me.txtRAATPORC.Text, _
                                                     Me.cboRAATESTA.SelectedValue)) = True Then

                    mod_MENSAJE.Se_Guardaron_Los_Datos_Correctamente()
                    Me.cboRAATDEPA.Focus()
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
        Me.cboRAATDEPA.Focus()
        Me.Close()
    End Sub

#End Region

#Region "FORMULARIO"

#Region "KeyPress"

    Private Sub txt_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboRAATDEPA.KeyPress, cboRAATMUNI.KeyPress, cboRAATCLSE.KeyPress, txtRAATPORC.KeyPress, cboRAATESTA.KeyPress, txtRAATATIN.KeyPress, txtRAATATFI.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Or e.KeyChar = Convert.ToChar(Keys.Tab) Then
            pp_pro_SaltarCampo()
        End If
    End Sub

#End Region

#Region "KeyDown"

    Private Sub cboTAPEDEPA_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboRAATDEPA.KeyDown
        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
            fun_Cargar_ComboBox_Con_Datos_Activos_DEPARTAMENTO_Descripcion(Me.cboRAATDEPA, Me.cboRAATDEPA.SelectedIndex)
        End If
    End Sub
    Private Sub cboTAPEMUNI_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboRAATMUNI.KeyDown
        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
            fun_Cargar_ComboBox_Con_Datos_Activos_MUNICIPIO_X_DEPARTAMENTO_Descripcion(Me.cboRAATMUNI, Me.cboRAATMUNI.SelectedIndex, Me.cboRAATDEPA)
        End If
    End Sub
    Private Sub cboTAPECLSE_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboRAATCLSE.KeyDown
        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
            fun_Cargar_ComboBox_Con_Datos_Activos_CLASSECT_Descripcion(Me.cboRAATCLSE, Me.cboRAATCLSE.SelectedIndex)
        End If
    End Sub
    Private Sub cboTAPEESTA_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboRAATESTA.KeyDown
        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
            fun_Cargar_ComboBox_Con_Datos_Activos_ESTADO(Me.cboRAATESTA, Me.cboRAATESTA.SelectedIndex)
        End If
    End Sub

#End Region

#Region "GotFocus"

    Private Sub txt_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtRAATPORC.GotFocus, txtRAATATIN.GotFocus, txtRAATATFI.GotFocus
        pp_pro_SobrearCampo(sender)
        pp_pro_DescripcionCampo(Me.strBARRESTA.Items(0), sender)
    End Sub
    Private Sub cmd_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdGUARDAR.GotFocus, cmdSALIR.GotFocus
        pp_pro_DescripcionCampo(Me.strBARRESTA.Items(0), sender)
    End Sub
    Private Sub cbo_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboRAATDEPA.GotFocus, cboRAATMUNI.GotFocus, cboRAATCLSE.GotFocus, cboRAATESTA.GotFocus
        pp_pro_DescripcionCampo(Me.strBARRESTA.Items(0), sender)
    End Sub

#End Region

#Region "SelectedIndexChanged"

    Private Sub cboTAPEDEPA_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboRAATDEPA.SelectedIndexChanged
        Me.lblRAATDEPA.Text = CType(fun_Buscar_Lista_Valores_DEPARTAMENTO_Codigo(Me.cboRAATDEPA), String)

        Me.cboRAATMUNI.DataSource = New DataTable
        Me.lblRAATMUNI.Text = ""

    End Sub
    Private Sub cboTAPEMUNI_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboRAATMUNI.SelectedIndexChanged
        Me.lblRAATMUNI.Text = CType(fun_Buscar_Lista_Valores_MUNICIPIO_Codigo(Me.cboRAATDEPA, Me.cboRAATMUNI), String)
    End Sub
    Private Sub cboTAPECLSE_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboRAATCLSE.SelectedIndexChanged
        Me.lblRAATCLSE.Text = CType(fun_Buscar_Lista_Valores_CLASSECT_Codigo(Me.cboRAATCLSE), String)
    End Sub

#End Region

#Region "Click"

    Private Sub cboTAPEDEPA_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboRAATDEPA.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_DEPARTAMENTO_Descripcion(Me.cboRAATDEPA, Me.cboRAATDEPA.SelectedIndex)
    End Sub
    Private Sub cboTAPEMUNI_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboRAATMUNI.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_MUNICIPIO_X_DEPARTAMENTO_Descripcion(Me.cboRAATMUNI, Me.cboRAATMUNI.SelectedIndex, Me.cboRAATDEPA)
    End Sub
    Private Sub cboTAPECLSE_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboRAATCLSE.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_CLASSECT_Descripcion(Me.cboRAATCLSE, Me.cboRAATCLSE.SelectedIndex)
    End Sub
    Private Sub cboTAPEESTA_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboRAATESTA.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_ESTADO(Me.cboRAATESTA, Me.cboRAATESTA.SelectedIndex)
    End Sub

#End Region

#Region "Validated"

    Private Sub txtTAAPAVFI_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtRAATPORC.Validated
        If Trim(sender.text) = "" Then
            sender.text = "0.00"
        Else
            If fun_Verificar_Dato_Decimal_Evento_Validated(Me.txtRAATPORC.Text) = True Then
                Me.txtRAATPORC.Text = fun_Formato_Decimal_2_Decimales(Me.txtRAATPORC.Text)
            End If

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