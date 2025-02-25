Imports REGLAS_DEL_NEGOCIO

Public Class frm_modificar_VARIABLE

    '==========================
    '*** MODIFICAR VARIABLE ***
    '==========================

#Region "VARIABLE"

    Dim inID_REGISTRO As Integer

#End Region

#Region "CONSTRUCTOR"

    Public Sub New(ByVal inInRegistro As Integer)
        inID_REGISTRO = inInRegistro

        InitializeComponent()
        pro_inicializarControles()
    End Sub

#End Region

#Region "PROCEDIMIENTOS"

    Private Sub pro_inicializarControles()

        Try
            Dim objdatos28 As New cla_TIPOVARI

            Me.cboVARITIVA.DataSource = objdatos28.fun_Consultar_CAMPOS_MANT_TIPOVARI
            Me.cboVARITIVA.DisplayMember = "TIVADESC"
            Me.cboVARITIVA.ValueMember = "TIVACODI"

            Dim objdatos As New cla_ESTADO

            Me.cboVARIESTA.DataSource = objdatos.fun_Consultar_TODOS_LOS_ESTADOS
            Me.cboVARIESTA.DisplayMember = "ESTADESC"
            Me.cboVARIESTA.ValueMember = "ESTACODI"

            Dim objdatos1 As New cla_VARIABLE
            Dim tbl As New DataTable

            tbl = objdatos1.fun_Buscar_ID_MANT_VARIABLE(inID_REGISTRO)

            Me.cboVARITIVA.SelectedValue = Trim(tbl.Rows(0).Item("VARITIVA"))
            Me.txtVARICODI.Text = Trim(tbl.Rows(0).Item("VARICODI"))
            Me.txtVARIDESC.Text = Trim(tbl.Rows(0).Item("VARIDESC"))
            Me.cboVARIESTA.SelectedValue = tbl.Rows(0).Item("VARIESTA")

            Dim boVARITIVA As Boolean = fun_Buscar_Dato_TIPOVARI(Trim(Me.cboVARITIVA.SelectedValue))

            If boVARITIVA = True Then

                Me.lblVARITIVA.Text = fun_Buscar_Lista_Valores_TIPOVARI_Codigo(Me.cboVARITIVA)
            Else
                frm_INCO_modifircar_registros_sin_listas_de_valores.ShowDialog()
            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub

#End Region

#Region "MENU"

    Private Sub cmdGUARDAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGUARDAR.Click
        Try

            Dim objVerifica As New cla_Verificar_Dato

            Dim boVARITIVA As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboVARITIVA)
            Dim boVARICODI As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Numerico(Me.txtVARICODI)
            Dim boVARIDESC As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.txtVARIDESC)
            Dim boVARIESTA As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboVARIESTA)

            ' verifica los datos del formulario 
            If boVARITIVA = True And boVARICODI = True And boVARIDESC = True And boVARIESTA = True Then

                Dim objdatos As New cla_VARIABLE

                If objdatos.fun_Actualizar_MANT_VARIABLE(inID_REGISTRO, _
                                                         Me.cboVARITIVA.SelectedValue, _
                                                         Me.txtVARICODI.Text, _
                                                         Me.txtVARIDESC.Text, _
                                                         Me.cboVARIESTA.SelectedValue) = True Then
                    mod_MENSAJE.Se_Modificaron_Los_Datos_Correctamente()

                    Me.txtVARIDESC.Focus()
                    Me.Close()
                Else
                    mod_MENSAJE.No_Se_Modifico_El_Registro_En_La_Base_De_Datos()
                End If

            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub cmdCANCELAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSALIR.Click
        Me.txtVARIDESC.Focus()
        Me.Close()
    End Sub

#End Region

#Region "FORMULARIO"

#Region "KeyDown"

    Private Sub cboVARITIVA_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboVARITIVA.KeyDown
        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
            fun_Cargar_ComboBox_Con_Datos_Activos_TIPOVARI_Descripcion(Me.cboVARITIVA, Me.cboVARITIVA.SelectedIndex)
        End If
    End Sub
    Private Sub cboVARIESTA_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboVARIESTA.KeyDown
        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
            fun_Cargar_ComboBox_Con_Datos_Activos_ESTADO(Me.cboVARIESTA, Me.cboVARIESTA.SelectedIndex)
        End If
    End Sub

#End Region

#Region "KeyPress"

    Private Sub txt_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtVARICODI.KeyPress, txtVARIDESC.KeyPress, cboVARIESTA.KeyPress, cboVARITIVA.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Or e.KeyChar = Convert.ToChar(Keys.Tab) Then
            pp_pro_SaltarCampo()
        End If
    End Sub

#End Region

#Region "GotFocus"

    Private Sub txt_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtVARICODI.GotFocus, txtVARIDESC.GotFocus
        pp_pro_SobrearCampo(sender)
        pp_pro_DescripcionCampo(Me.strBARRESTA.Items(0), sender)
    End Sub
    Private Sub cmd_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdGUARDAR.GotFocus, cmdSALIR.GotFocus
        pp_pro_DescripcionCampo(Me.strBARRESTA.Items(0), sender)
    End Sub
    Private Sub cbo_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboVARIESTA.GotFocus, cboVARITIVA.GotFocus
        pp_pro_DescripcionCampo(Me.strBARRESTA.Items(0), sender)
    End Sub

#End Region

#Region "Click"

    Private Sub cboVARITIVA_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboVARITIVA.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_TIPOVARI_Descripcion(Me.cboVARITIVA, Me.cboVARITIVA.SelectedIndex)
    End Sub
    Private Sub cboMOLIESTA_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboVARIESTA.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_ESTADO(cboVARIESTA, cboVARIESTA.SelectedIndex)
    End Sub

#End Region

#Region "SelectedIndexChanged"

    Private Sub cboVARITIVA_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboVARITIVA.SelectedIndexChanged
        Me.lblVARITIVA.Text = CType(fun_Buscar_Lista_Valores_TIPOVARI_Codigo(Me.cboVARITIVA), String)
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