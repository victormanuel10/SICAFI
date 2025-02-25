Imports REGLAS_DEL_NEGOCIO

Public Class frm_modificar_PERIODO

    '=========================
    '*** MODIFICAR PERIODO ***
    '=========================

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

            Dim objdatos As New cla_ESTADO

            Me.cboPERIESTA.DataSource = objdatos.fun_Consultar_TODOS_LOS_ESTADOS
            Me.cboPERIESTA.DisplayMember = "ESTADESC"
            Me.cboPERIESTA.ValueMember = "ESTACODI"

            Dim objdatos2 As New cla_PERIODO

            Me.cboPERIVIGE.DataSource = objdatos2.fun_Consultar_CAMPOS_MANT_PERIODO
            Me.cboPERIVIGE.DisplayMember = "PERIVIGE"
            Me.cboPERIVIGE.ValueMember = "PERIVIGE"

            Dim objdatos1 As New cla_PERIODO
            Dim tbl As New DataTable

            tbl = objdatos1.fun_Buscar_ID_MANT_PERIODO(inID_REGISTRO)

            Me.cboPERIVIGE.SelectedValue = tbl.Rows(0).Item("PERIVIGE")
            Me.txtPERIMES.Text = Trim(tbl.Rows(0).Item("PERIMES"))
            Me.txtPERIDESC.Text = Trim(tbl.Rows(0).Item("PERIDESC"))
            Me.chkPERIAPLI.Checked = tbl.Rows(0).Item("PERIAPLI")
            Me.cboPERIESTA.SelectedValue = tbl.Rows(0).Item("PERIESTA")

            Dim boPERIVIGE As Boolean = fun_Buscar_Dato_VIGENCIA(Me.cboPERIVIGE.SelectedValue)

            If boPERIVIGE = True Then
                lblPERIVIGE.Text = CType(fun_Buscar_Lista_Valores_VIGENCIA(cboPERIVIGE.SelectedValue), String)
            Else
                frm_INCO_insertar_registro_sin_listas_de_valores.ShowDialog()
            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub pro_LimpiarCampos()

        pp_pro_LimpiarCampos(fraPERIODO)

    End Sub

#End Region

#Region "MENU"

    Private Sub cmdGUARDAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGUARDAR.Click

        Try
            Dim objVerifica As New cla_Verificar_Dato

            Dim boPERIVIGE As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Numerico(Me.cboPERIVIGE)
            Dim boPERIMES As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Numerico(Me.txtPERIMES)
            Dim boPERIDESC As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.txtPERIDESC)
            Dim boPERIESTA As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboPERIESTA)

            ' verifica los datos del formulario 
            If boPERIVIGE = True And boPERIMES = True And boPERIDESC = True And boPERIESTA = True Then

                Dim objdatos22 As New cla_PERIODO

                If (objdatos22.fun_Actualizar_MANT_PERIODO(inID_REGISTRO, _
                                                         Me.cboPERIVIGE.SelectedValue, _
                                                         Me.txtPERIMES.Text, _
                                                         Me.txtPERIDESC.Text, _
                                                         Me.chkPERIAPLI.Checked, _
                                                         Me.cboPERIESTA.SelectedValue)) Then

                    mod_MENSAJE.Se_Guardaron_Los_Datos_Correctamente()
                    Me.cboPERIVIGE.Focus()
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
        Me.cboPERIVIGE.Focus()
        Me.Close()
    End Sub

#End Region

#Region "FORMULARIO"

#Region "KeyDown"

    Private Sub cboPERIVIGE_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboPERIVIGE.KeyDown
        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
            fun_Cargar_ComboBox_Con_Datos_Activos_VIGENCIA(Me.cboPERIVIGE, Me.cboPERIVIGE.SelectedIndex)
        End If
    End Sub
    Private Sub cboPERIESTA_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboPERIESTA.KeyDown
        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
            fun_Cargar_ComboBox_Con_Datos_Activos_ESTADO(Me.cboPERIESTA, Me.cboPERIESTA.SelectedIndex)
        End If
    End Sub

#End Region

#Region "KeyPress"

    Private Sub txt_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboPERIVIGE.KeyPress, txtPERIMES.KeyPress, txtPERIDESC.KeyPress, chkPERIAPLI.KeyPress, cboPERIESTA.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Or e.KeyChar = Convert.ToChar(Keys.Tab) Then
            pp_pro_SaltarCampo()
        End If
    End Sub

#End Region

#Region "GotFocus"

    Private Sub txt_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtPERIMES.GotFocus, txtPERIDESC.GotFocus
        pp_pro_SobrearCampo(sender)
        pp_pro_DescripcionCampo(Me.strBARRESTA.Items(0), sender)
    End Sub
    Private Sub cmd_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdGUARDAR.GotFocus, cmdSALIR.GotFocus
        pp_pro_DescripcionCampo(Me.strBARRESTA.Items(0), sender)
    End Sub
    Private Sub cbo_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboPERIVIGE.GotFocus, cboPERIESTA.GotFocus
        pp_pro_DescripcionCampo(Me.strBARRESTA.Items(0), sender)
    End Sub
    Private Sub chk_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkPERIAPLI.GotFocus
        pp_pro_DescripcionCampo(Me.strBARRESTA.Items(0), sender)
    End Sub


#End Region

#Region "Click"

    Private Sub cboPERIVIGE_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboPERIVIGE.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_VIGENCIA(Me.cboPERIVIGE, Me.cboPERIVIGE.SelectedIndex)
    End Sub
    Private Sub cboPERIESTA_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboPERIESTA.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_ESTADO(Me.cboPERIESTA, Me.cboPERIESTA.SelectedIndex)
    End Sub

#End Region

#Region "SelectedIndexChanged"

    Private Sub cboMUNIDEPA_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboPERIVIGE.SelectedIndexChanged
        lblPERIVIGE.Text = CType(fun_Buscar_Lista_Valores_VIGENCIA(cboPERIVIGE.Text), String)
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