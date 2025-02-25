Imports REGLAS_DEL_NEGOCIO

Public Class frm_modificar_PEPELIQU

    '==================================================
    '*** MODIFICAR PERIODO PERMITIDO DE LIQUIDACIÓN ***
    '==================================================

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

            Me.cboPPLIDEPA.DataSource = objdatos1.fun_Consultar_CAMPOS_MANT_DEPARTAMENTO
            Me.cboPPLIDEPA.DisplayMember = "DEPADESC"
            Me.cboPPLIDEPA.ValueMember = "DEPACODI"

            Dim objdatos2 As New cla_CLASSECT

            Me.cboPPLICLSE.DataSource = objdatos2.fun_Consultar_CAMPOS_MANT_CLASSECT
            Me.cboPPLICLSE.DisplayMember = "CLSEDESC"
            Me.cboPPLICLSE.ValueMember = "CLSECODI"

            Dim objdatos27 As New cla_VIGENCIA

            Me.cboPPLIVIGE.DataSource = objdatos27.fun_Consultar_CAMPOS_VIGENCIA
            Me.cboPPLIVIGE.DisplayMember = "VIGEDESC"
            Me.cboPPLIVIGE.ValueMember = "VIGECODI"

            Dim objdatos50 As New cla_TIPOIMPU

            Me.cboPPLITIIM.DataSource = objdatos50.fun_Consultar_CAMPOS_MANT_TIPOIMPU
            Me.cboPPLITIIM.DisplayMember = "TIIMDESC"
            Me.cboPPLITIIM.ValueMember = "TIIMCODI"

            Dim objdatos As New cla_ESTADO

            Me.cboPPLIESTA.DataSource = objdatos.fun_Consultar_TODOS_LOS_ESTADOS
            Me.cboPPLIESTA.DisplayMember = "ESTADESC"
            Me.cboPPLIESTA.ValueMember = "ESTACODI"

            Dim objdatos3 As New cla_PEPELIQU
            Dim tbl As New DataTable

            tbl = objdatos3.fun_Buscar_ID_PEPELIQU(inID_REGISTRO)

            Me.cboPPLIDEPA.SelectedValue = tbl.Rows(0).Item("PPLIDEPA")

            Dim objdatos7 As New cla_MUNICIPIO

            Me.cboPPLIMUNI.DataSource = objdatos7.fun_Consultar_CAMPOS_MANT_MUNICIPIO
            Me.cboPPLIMUNI.DisplayMember = "MUNIDESC"
            Me.cboPPLIMUNI.ValueMember = "MUNICODI"

            Me.cboPPLIMUNI.SelectedValue = tbl.Rows(0).Item("PPLIMUNI")
            Me.cboPPLICLSE.SelectedValue = tbl.Rows(0).Item("PPLICLSE")
            Me.cboPPLIVIGE.SelectedValue = tbl.Rows(0).Item("PPLIVIGE")
            Me.cboPPLITIIM.SelectedValue = tbl.Rows(0).Item("PPLITIIM")

            Dim objdatos51 As New cla_CONCEPTO

            Me.cboPPLICONC.DataSource = objdatos51.fun_Consultar_CAMPOS_MANT_CONCEPTO
            Me.cboPPLICONC.DisplayMember = "CONCDESC"
            Me.cboPPLICONC.ValueMember = "CONCCODI"

            Me.cboPPLICONC.SelectedValue = tbl.Rows(0).Item("PPLICONC")
            Me.txtPPLIDESC.Text = Trim(tbl.Rows(0).Item("PPLIDESC"))
            Me.chkPPLIHIAV.Checked = tbl.Rows(0).Item("PPLIHIAV")
            Me.chkPPLIHILI.Checked = tbl.Rows(0).Item("PPLIHILI")
            Me.chkPPLIAFSI.Checked = tbl.Rows(0).Item("PPLIAFSI")
            Me.cboPPLIESTA.SelectedValue = tbl.Rows(0).Item("PPLIESTA")

            Dim boPPLIDEPA As Boolean = fun_Buscar_Dato_DEPARTAMENTO(Me.cboPPLIDEPA.SelectedValue)
            Dim boPPLIMUNI As Boolean = fun_Buscar_Dato_MUNICIPIO(Me.cboPPLIDEPA.SelectedValue, Me.cboPPLIMUNI.SelectedValue)
            Dim boPPLICLSE As Boolean = fun_Buscar_Dato_CLASSECT(Me.cboPPLICLSE.SelectedValue)
            Dim boPPLIVIGE As Boolean = fun_Buscar_Dato_VIGENCIA(Me.cboPPLIVIGE.SelectedValue)
            Dim boPPLITIIM As Boolean = fun_Buscar_Dato_TIPOIMPU(Me.cboPPLITIIM.SelectedValue)
            Dim boPPLICONC As Boolean = fun_Buscar_Dato_CONCEPTO(Me.cboPPLITIIM.SelectedValue, Me.cboPPLICONC.SelectedValue)
            
            If boPPLIDEPA = True OrElse _
               boPPLIMUNI = True OrElse _
               boPPLICLSE = True OrElse _
               boPPLIVIGE = True OrElse _
               boPPLITIIM = True OrElse _
               boPPLICONC = True Then

                Me.lblPPLIDEPA.Text = CType(fun_Buscar_Lista_Valores_DEPARTAMENTO_Codigo(Me.cboPPLIDEPA), String)
                Me.lblPPLIMUNI.Text = CType(fun_Buscar_Lista_Valores_MUNICIPIO_Codigo(Me.cboPPLIDEPA, Me.cboPPLIMUNI), String)
                Me.lblPPLICLSE.Text = CType(fun_Buscar_Lista_Valores_CLASSECT_Codigo(Me.cboPPLICLSE), String)
                Me.lblPPLIVIGE.Text = CType(fun_Buscar_Lista_Valores_VIGENCIA_Codigo(Me.cboPPLIVIGE), String)
                Me.lblPPLITIIM.Text = CType(fun_Buscar_Lista_Valores_TIPOIMPU_Codigo(Me.cboPPLITIIM), String)
                Me.lblPPLICONC.Text = CType(fun_Buscar_Lista_Valores_CONCEPTO_Codigo(Me.cboPPLITIIM, Me.cboPPLICONC), String)

            Else
                frm_INCO_modifircar_registros_sin_listas_de_valores.ShowDialog()
            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub pro_LimpiarCampos()

        Me.cboPPLIDEPA.DataSource = New DataTable
        Me.cboPPLIMUNI.DataSource = New DataTable
        Me.cboPPLICLSE.DataSource = New DataTable
        Me.cboPPLIVIGE.DataSource = New DataTable
        Me.cboPPLITIIM.DataSource = New DataTable
        Me.cboPPLICONC.DataSource = New DataTable
        Me.cboPPLIESTA.DataSource = New DataTable

        Me.chkPPLIHIAV.Checked = False
        Me.chkPPLIHILI.Checked = False
        Me.chkPPLIAFSI.Checked = False
       
        Me.lblPPLIDEPA.Text = ""
        Me.lblPPLIMUNI.Text = ""
        Me.lblPPLICLSE.Text = ""
        Me.lblPPLIVIGE.Text = ""
        Me.lblPPLITIIM.Text = ""
        Me.lblPPLICONC.Text = ""
        Me.txtPPLIDESC.Text = ""

    End Sub

#End Region

#Region "MENU"

    Private Sub cmdGUARDAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGUARDAR.Click

        Try

            ' instancia la clase
            Dim objVerifica As New cla_Verificar_Dato

            Dim boPPLIDEPA As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboPPLIDEPA)
            Dim boPPLIMUNI As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboPPLIMUNI)
            Dim boPPLICLSE As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboPPLICLSE)
            Dim boPPLIVIGE As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboPPLIVIGE)
            Dim boPPLITIIM As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboPPLITIIM)
            Dim boPPLICONC As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboPPLICONC)
            Dim boPPLIESTA As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboPPLIESTA)

            ' verifica los datos del formulario 
            If boPPLIDEPA = True And _
               boPPLIMUNI = True And _
               boPPLICLSE = True And _
               boPPLIVIGE = True And _
               boPPLITIIM = True And _
               boPPLICONC = True And _
               boPPLIESTA = True Then

                Dim objdatos22 As New cla_PEPELIQU

                If (objdatos22.fun_Actualizar_PEPELIQU(inID_REGISTRO, _
                                                         Me.cboPPLIDEPA.SelectedValue, _
                                                         Me.cboPPLIMUNI.SelectedValue, _
                                                         Me.cboPPLICLSE.SelectedValue, _
                                                         Me.cboPPLIVIGE.SelectedValue, _
                                                         Me.cboPPLITIIM.SelectedValue, _
                                                         Me.cboPPLICONC.SelectedValue, _
                                                         Me.txtPPLIDESC.Text, _
                                                         Me.chkPPLIHIAV.Checked, _
                                                         Me.chkPPLIHILI.Checked, _
                                                         Me.chkPPLIAFSI.Checked, _
                                                         Me.cboPPLIESTA.SelectedValue)) = True Then

                    mod_MENSAJE.Se_Guardaron_Los_Datos_Correctamente()
                    Me.cboPPLIDEPA.Focus()
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
        Me.cboPPLIDEPA.Focus()
        Me.Close()
    End Sub

#End Region

#Region "FORMULARIO"

#Region "KeyPress"

    Private Sub txt_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboPPLIDEPA.KeyPress, cboPPLIMUNI.KeyPress, cboPPLICLSE.KeyPress, cboPPLIVIGE.KeyPress, cboPPLITIIM.KeyPress, cboPPLIESTA.KeyPress, chkPPLIHIAV.KeyPress, chkPPLIHILI.KeyPress, chkPPLIAFSI.KeyPress, cboPPLICONC.KeyPress, txtPPLIDESC.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Or e.KeyChar = Convert.ToChar(Keys.Tab) Then
            pp_pro_SaltarCampo()
        End If
    End Sub

#End Region

#Region "KeyDown"

    Private Sub cboPPLIDEPA_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboPPLIDEPA.KeyDown
        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
            fun_Cargar_ComboBox_Con_Datos_Activos_DEPARTAMENTO_Descripcion(Me.cboPPLIDEPA, Me.cboPPLIDEPA.SelectedIndex)
        End If
    End Sub
    Private Sub cboPPLIMUNI_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboPPLIMUNI.KeyDown
        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
            fun_Cargar_ComboBox_Con_Datos_Activos_MUNICIPIO_X_DEPARTAMENTO_Descripcion(Me.cboPPLIMUNI, Me.cboPPLIMUNI.SelectedIndex, Me.cboPPLIDEPA)
        End If
    End Sub
    Private Sub cboPPLICLSE_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboPPLICLSE.KeyDown
        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
            fun_Cargar_ComboBox_Con_Datos_Activos_CLASSECT_Descripcion(Me.cboPPLICLSE, Me.cboPPLICLSE.SelectedIndex)
        End If
    End Sub
    Private Sub cboPPLIVIGE_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboPPLIVIGE.KeyDown
        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
            fun_Cargar_ComboBox_Con_Datos_Activos_VIGENCIA_Descripcion(Me.cboPPLIVIGE, Me.cboPPLIVIGE.SelectedIndex)
        End If
    End Sub
    Private Sub cboPPLITIIM_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboPPLITIIM.KeyDown
        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
            fun_Cargar_ComboBox_Con_Datos_Activos_TIPOIMPU_Descripcion(Me.cboPPLITIIM, Me.cboPPLITIIM.SelectedIndex)
        End If
    End Sub
    Private Sub cboPPLICONC_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboPPLICONC.KeyDown
        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
            fun_Cargar_ComboBox_Con_Datos_Activos_CONCEPTO_Descripcion(Me.cboPPLICONC, Me.cboPPLICONC.SelectedIndex, Me.cboPPLITIIM)
        End If
    End Sub
    Private Sub cboPPLIESTA_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboPPLIESTA.KeyDown
        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
            fun_Cargar_ComboBox_Con_Datos_Activos_ESTADO(Me.cboPPLIESTA, Me.cboPPLIESTA.SelectedIndex)
        End If
    End Sub

#End Region

#Region "GotFocus"

    Private Sub txt_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtPPLIDESC.GotFocus
        pp_pro_SobrearCampo(sender)
        pp_pro_DescripcionCampo(Me.strBARRESTA.Items(0), sender)
    End Sub
    Private Sub cmd_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdGUARDAR.GotFocus, cmdSALIR.GotFocus
        pp_pro_DescripcionCampo(Me.strBARRESTA.Items(0), sender)
    End Sub
    Private Sub cbo_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboPPLIDEPA.GotFocus, cboPPLIMUNI.GotFocus, cboPPLICLSE.GotFocus, cboPPLIVIGE.GotFocus, cboPPLITIIM.GotFocus, cboPPLIESTA.GotFocus, cboPPLICONC.GotFocus
        pp_pro_DescripcionCampo(Me.strBARRESTA.Items(0), sender)
    End Sub
    Private Sub chk_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkPPLIHIAV.GotFocus, chkPPLIHILI.GotFocus, chkPPLIAFSI.GotFocus
        pp_pro_DescripcionCampo(Me.strBARRESTA.Items(0), sender)
    End Sub

#End Region

#Region "SelectedIndexChanged"

    Private Sub cboPPLIDEPA_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboPPLIDEPA.SelectedIndexChanged
        Me.lblPPLIDEPA.Text = CType(fun_Buscar_Lista_Valores_DEPARTAMENTO_Codigo(Me.cboPPLIDEPA), String)

        Me.cboPPLIMUNI.DataSource = New DataTable
        Me.lblPPLIMUNI.Text = ""
    End Sub
    Private Sub cboPPLIMUNI_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboPPLIMUNI.SelectedIndexChanged
        Me.lblPPLIMUNI.Text = CType(fun_Buscar_Lista_Valores_MUNICIPIO_Codigo(Me.cboPPLIDEPA, Me.cboPPLIMUNI), String)
    End Sub
    Private Sub cboPPLICLSE_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboPPLICLSE.SelectedIndexChanged
        Me.lblPPLICLSE.Text = CType(fun_Buscar_Lista_Valores_CLASSECT_Codigo(Me.cboPPLICLSE), String)
    End Sub
    Private Sub cboPPLIVIGE_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboPPLIVIGE.SelectedIndexChanged
        Me.lblPPLIVIGE.Text = CType(fun_Buscar_Lista_Valores_VIGENCIA_Codigo(Me.cboPPLIVIGE), String)
    End Sub
    Private Sub cboPPLITIIM_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboPPLITIIM.SelectedIndexChanged
        Me.lblPPLITIIM.Text = CType(fun_Buscar_Lista_Valores_TIPOIMPU_Codigo(Me.cboPPLITIIM), String)

        Me.cboPPLICONC.DataSource = New DataTable
        Me.lblPPLICONC.Text = ""
    End Sub
    Private Sub cboPPLICONC_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboPPLICONC.SelectedIndexChanged
        Me.lblPPLICONC.Text = CType(fun_Buscar_Lista_Valores_CONCEPTO_Codigo(Me.cboPPLITIIM, Me.cboPPLICONC), String)
    End Sub

#End Region

#Region "Click"

    Private Sub cboPPLIDEPA_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboPPLIDEPA.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_DEPARTAMENTO_Descripcion(Me.cboPPLIDEPA, Me.cboPPLIDEPA.SelectedIndex)
    End Sub
    Private Sub cboPPLIMUNI_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboPPLIMUNI.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_MUNICIPIO_X_DEPARTAMENTO_Descripcion(Me.cboPPLIMUNI, Me.cboPPLIMUNI.SelectedIndex, Me.cboPPLIDEPA)
    End Sub
    Private Sub cboPPLICLSE_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboPPLICLSE.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_CLASSECT_Descripcion(Me.cboPPLICLSE, Me.cboPPLICLSE.SelectedIndex)
    End Sub
    Private Sub cboPPLIVIGE_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboPPLIVIGE.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_VIGENCIA_Descripcion(Me.cboPPLIVIGE, Me.cboPPLIVIGE.SelectedIndex)
    End Sub
    Private Sub cboPPLITIIM_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboPPLITIIM.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_TIPOIMPU_Descripcion(Me.cboPPLITIIM, Me.cboPPLITIIM.SelectedIndex)
    End Sub
    Private Sub cboPPLICONC_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboPPLICONC.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_CONCEPTO_Descripcion(Me.cboPPLICONC, Me.cboPPLICONC.SelectedIndex, Me.cboPPLITIIM)
    End Sub
    Private Sub cboPPLIESTA_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboPPLIESTA.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_ESTADO(Me.cboPPLIESTA, Me.cboPPLIESTA.SelectedIndex)
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