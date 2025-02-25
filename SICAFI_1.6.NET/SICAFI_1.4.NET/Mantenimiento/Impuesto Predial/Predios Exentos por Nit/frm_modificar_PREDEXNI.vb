Imports REGLAS_DEL_NEGOCIO

Public Class frm_modificar_PREDEXNI

    '=========================================
    '*** MODIFICAR PREDIOS EXENTOS POR NIT ***
    '=========================================

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

            Me.cboPRENDEPA.DataSource = objdatos1.fun_Consultar_CAMPOS_MANT_DEPARTAMENTO
            Me.cboPRENDEPA.DisplayMember = "DEPADESC"
            Me.cboPRENDEPA.ValueMember = "DEPACODI"

            Dim objdatos2 As New cla_CLASSECT

            Me.cboPRENCLSE.DataSource = objdatos2.fun_Consultar_CAMPOS_MANT_CLASSECT
            Me.cboPRENCLSE.DisplayMember = "CLSEDESC"
            Me.cboPRENCLSE.ValueMember = "CLSECODI"

            Dim objdatos50 As New cla_TIPOIMPU

            Me.cboPRENTIIM.DataSource = objdatos50.fun_Consultar_CAMPOS_MANT_TIPOIMPU
            Me.cboPRENTIIM.DisplayMember = "TIIMDESC"
            Me.cboPRENTIIM.ValueMember = "TIIMCODI"

            Dim objdatos27 As New cla_TIPODOCU

            Me.cboPRENTIDO.DataSource = objdatos27.fun_Consultar_CAMPOS_MANT_TIPODOCU
            Me.cboPRENTIDO.DisplayMember = "TIDODESC"
            Me.cboPRENTIDO.ValueMember = "TIDOCODI"

            Dim objdatos88 As New cla_CALIPROP

            Me.cboPRENCAPR.DataSource = objdatos88.fun_Consultar_CAMPOS_MANT_CALIPROP
            Me.cboPRENCAPR.DisplayMember = "CAPRDESC"
            Me.cboPRENCAPR.ValueMember = "CAPRCODI"

            Dim objdatos89 As New cla_SEXO

            Me.cboPRENSEXO.DataSource = objdatos89.fun_Consultar_CAMPOS_MANT_SEXO
            Me.cboPRENSEXO.DisplayMember = "SEXODESC"
            Me.cboPRENSEXO.ValueMember = "SEXOCODI"

            Dim objdatos As New cla_ESTADO

            Me.cboPRENESTA.DataSource = objdatos.fun_Consultar_TODOS_LOS_ESTADOS
            Me.cboPRENESTA.DisplayMember = "ESTADESC"
            Me.cboPRENESTA.ValueMember = "ESTACODI"

            Dim objdatos3 As New cla_PREDEXNI
            Dim tbl As New DataTable

            tbl = objdatos3.fun_Buscar_ID_PREDEXNI(inID_REGISTRO)

            Me.cboPRENDEPA.SelectedValue = tbl.Rows(0).Item("PRENDEPA")

            Dim objdatos7 As New cla_MUNICIPIO

            Me.cboPRENMUNI.DataSource = objdatos7.fun_Consultar_CAMPOS_MANT_MUNICIPIO
            Me.cboPRENMUNI.DisplayMember = "MUNIDESC"
            Me.cboPRENMUNI.ValueMember = "MUNICODI"

            Me.cboPRENMUNI.SelectedValue = tbl.Rows(0).Item("PRENMUNI")
            Me.cboPRENCLSE.SelectedValue = tbl.Rows(0).Item("PRENCLSE")
            Me.cboPRENTIIM.SelectedValue = tbl.Rows(0).Item("PRENTIIM")

            Dim objdatos51 As New cla_CONCEPTO

            Me.cboPRENCONC.DataSource = objdatos51.fun_Consultar_CAMPOS_MANT_CONCEPTO
            Me.cboPRENCONC.DisplayMember = "CONCDESC"
            Me.cboPRENCONC.ValueMember = "CONCCODI"

            Me.cboPRENCONC.SelectedValue = tbl.Rows(0).Item("PRENCONC")
            Me.cboPRENTIDO.SelectedValue = tbl.Rows(0).Item("PRENTIDO")
            Me.cboPRENCAPR.SelectedValue = tbl.Rows(0).Item("PRENCAPR")
            Me.cboPRENSEXO.SelectedValue = tbl.Rows(0).Item("PRENSEXO")
            Me.txtPRENNUDO.Text = Trim(tbl.Rows(0).Item("PRENNUDO"))
            Me.txtPRENDESC.Text = Trim(tbl.Rows(0).Item("PRENDESC"))
            Me.cboPRENESTA.SelectedValue = tbl.Rows(0).Item("PRENESTA")

            Dim boPRENDEPA As Boolean = fun_Buscar_Dato_DEPARTAMENTO(Me.cboPRENDEPA.SelectedValue)
            Dim boPRENMUNI As Boolean = fun_Buscar_Dato_MUNICIPIO(Me.cboPRENDEPA.SelectedValue, Me.cboPRENMUNI.SelectedValue)
            Dim boPRENCLSE As Boolean = fun_Buscar_Dato_CLASSECT(Me.cboPRENCLSE.SelectedValue)
            Dim boPRENTIIM As Boolean = fun_Buscar_Dato_TIPOIMPU(Me.cboPRENTIIM.SelectedValue)
            Dim boPRENCONC As Boolean = fun_Buscar_Dato_CONCEPTO(Me.cboPRENTIIM.SelectedValue, Me.cboPRENCONC.SelectedValue)
            Dim boPRENTIDO As Boolean = fun_Buscar_Dato_TIPODOCU(Me.cboPRENTIDO.SelectedValue)
            Dim boPRENCAPR As Boolean = fun_Buscar_Dato_CALIPROP(Me.cboPRENCAPR.SelectedValue)
            Dim boPRENSEXO As Boolean = fun_Buscar_Dato_SEXO(Me.cboPRENSEXO.SelectedValue)

            If boPRENDEPA = True OrElse _
               boPRENMUNI = True OrElse _
               boPRENCLSE = True OrElse _
               boPRENTIIM = True OrElse _
               boPRENCONC = True OrElse _
               boPRENTIDO = True OrElse _
               boPRENCAPR = True OrElse _
               boPRENSEXO = True Then

                Me.lblPRENDEPA.Text = CType(fun_Buscar_Lista_Valores_DEPARTAMENTO_Codigo(Me.cboPRENDEPA), String)
                Me.lblPRENMUNI.Text = CType(fun_Buscar_Lista_Valores_MUNICIPIO_Codigo(Me.cboPRENDEPA, Me.cboPRENMUNI), String)
                Me.lblPRENCLSE.Text = CType(fun_Buscar_Lista_Valores_CLASSECT_Codigo(Me.cboPRENCLSE), String)
                Me.lblPRENTIIM.Text = CType(fun_Buscar_Lista_Valores_TIPOIMPU_Codigo(Me.cboPRENTIIM), String)
                Me.lblPRENCONC.Text = CType(fun_Buscar_Lista_Valores_CONCEPTO_Codigo(Me.cboPRENTIIM, Me.cboPRENCONC), String)
                Me.lblPRENTIDO.Text = CType(fun_Buscar_Lista_Valores_TIPODOCU_Codigo(Me.cboPRENTIDO), String)
                Me.lblPRENCAPR.Text = CType(fun_Buscar_Lista_Valores_CALIPROP_Codigo(Me.cboPRENCAPR), String)
                Me.lblPRENSEXO.Text = CType(fun_Buscar_Lista_Valores_SEXO_Codigo(Me.cboPRENSEXO), String)

            Else
                frm_INCO_modifircar_registros_sin_listas_de_valores.ShowDialog()
            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub pro_LimpiarCampos()

        Me.cboPRENDEPA.DataSource = New DataTable
        Me.cboPRENMUNI.DataSource = New DataTable
        Me.cboPRENCLSE.DataSource = New DataTable
        Me.cboPRENTIIM.DataSource = New DataTable
        Me.cboPRENCONC.DataSource = New DataTable
        Me.cboPRENTIDO.DataSource = New DataTable
        Me.cboPRENCAPR.DataSource = New DataTable
        Me.cboPRENSEXO.DataSource = New DataTable
        Me.cboPRENESTA.DataSource = New DataTable

        Me.lblPRENDEPA.Text = ""
        Me.lblPRENMUNI.Text = ""
        Me.lblPRENCLSE.Text = ""
        Me.lblPRENTIIM.Text = ""
        Me.lblPRENCONC.Text = ""
        Me.lblPRENTIDO.Text = ""
        Me.lblPRENCAPR.Text = ""
        Me.lblPRENSEXO.Text = ""

        Me.txtPRENNUDO.Text = ""
        Me.txtPRENDESC.Text = ""

    End Sub

#End Region

#Region "MENU"

    Private Sub cmdGUARDAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGUARDAR.Click

        Try
              ' instancia la clase
            Dim objVerifica As New cla_Verificar_Dato

            Dim boPRENDEPA As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboPRENDEPA)
            Dim boPRENMUNI As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboPRENMUNI)
            Dim boPRENCLSE As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboPRENCLSE)
            Dim boPRENTIIM As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboPRENTIIM)
            Dim boPRENCONC As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboPRENCONC)
            Dim boPRENTIDO As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboPRENTIDO)
            Dim boPRENCAPR As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboPRENCAPR)
            Dim boPRENSEXO As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboPRENSEXO)
            Dim boPRENNUDO As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.txtPRENNUDO)
            Dim boPRENESTA As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboPRENESTA)

            ' verifica los datos del formulario 
            If boPRENDEPA = True And _
               boPRENMUNI = True And _
               boPRENCLSE = True And _
               boPRENTIIM = True And _
               boPRENCONC = True And _
               boPRENTIDO = True And _
               boPRENCAPR = True And _
               boPRENSEXO = True And _
               boPRENNUDO = True And _
               boPRENESTA = True Then

                Dim objdatos22 As New cla_PREDEXNI

                If (objdatos22.fun_Actualizar_PREDEXNI(inID_REGISTRO, _
                                                     Me.cboPRENDEPA.SelectedValue, _
                                                     Me.cboPRENMUNI.SelectedValue, _
                                                     Me.cboPRENCLSE.SelectedValue, _
                                                     Me.cboPRENTIIM.SelectedValue, _
                                                     Me.cboPRENCONC.SelectedValue, _
                                                     Me.cboPRENTIDO.SelectedValue, _
                                                     Me.cboPRENCAPR.SelectedValue, _
                                                     Me.cboPRENSEXO.SelectedValue, _
                                                     Me.txtPRENNUDO.Text, _
                                                     Me.txtPRENDESC.Text, _
                                                     Me.cboPRENESTA.SelectedValue)) = True Then

                    mod_MENSAJE.Se_Guardaron_Los_Datos_Correctamente()
                    Me.cboPRENDEPA.Focus()
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
        Me.cboPRENDEPA.Focus()
        Me.Close()
    End Sub

#End Region

#Region "FORMULARIO"

#Region "KeyPress"

    Private Sub txt_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboPRENDEPA.KeyPress, cboPRENMUNI.KeyPress, cboPRENCLSE.KeyPress, txtPRENNUDO.KeyPress, cboPRENTIDO.KeyPress, cboPRENCAPR.KeyPress, cboPRENSEXO.KeyPress, cboPRENTIIM.KeyPress, cboPRENCONC.KeyPress, cboPRENESTA.KeyPress, txtPRENDESC.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Or e.KeyChar = Convert.ToChar(Keys.Tab) Then
            pp_pro_SaltarCampo()
        End If
    End Sub

#End Region

#Region "KeyDown"

    Private Sub cboPRENDEPA_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboPRENDEPA.KeyDown
        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
            fun_Cargar_ComboBox_Con_Datos_Activos_DEPARTAMENTO_Descripcion(Me.cboPRENDEPA, Me.cboPRENDEPA.SelectedIndex)
        End If
    End Sub
    Private Sub cboPRENMUNI_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboPRENMUNI.KeyDown
        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
            fun_Cargar_ComboBox_Con_Datos_Activos_MUNICIPIO_X_DEPARTAMENTO_Descripcion(Me.cboPRENMUNI, Me.cboPRENMUNI.SelectedIndex, Me.cboPRENDEPA)
        End If
    End Sub
    Private Sub cboPRENCLSE_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboPRENCLSE.KeyDown
        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
            fun_Cargar_ComboBox_Con_Datos_Activos_CLASSECT_Descripcion(Me.cboPRENCLSE, Me.cboPRENCLSE.SelectedIndex)
        End If
    End Sub
    Private Sub cboPRENTIIM_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboPRENTIIM.KeyDown
        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
            fun_Cargar_ComboBox_Con_Datos_Activos_TIPOIMPU_Descripcion(Me.cboPRENTIIM, Me.cboPRENTIIM.SelectedIndex)
        End If
    End Sub
    Private Sub cboPRENCONC_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboPRENCONC.KeyDown
        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
            fun_Cargar_ComboBox_Con_Datos_Activos_CONCEPTO_Descripcion(Me.cboPRENCONC, Me.cboPRENCONC.SelectedIndex, Me.cboPRENDEPA)
        End If
    End Sub
    Private Sub cboPRENTIDO_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboPRENTIDO.KeyDown
        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
            fun_Cargar_ComboBox_Con_Datos_Activos_TIPODOCU_Descripcion(Me.cboPRENTIDO, Me.cboPRENTIDO.SelectedIndex)
        End If
    End Sub
    Private Sub cboPRENCAPR_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboPRENCAPR.KeyDown
        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
            fun_Cargar_ComboBox_Con_Datos_Activos_CALIPROP_Descripcion(Me.cboPRENCAPR, Me.cboPRENCAPR.SelectedIndex)
        End If
    End Sub
    Private Sub cboPRENSEXO_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboPRENSEXO.KeyDown
        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
            fun_Cargar_ComboBox_Con_Datos_Activos_SEXO_Descripcion(Me.cboPRENSEXO, Me.cboPRENSEXO.SelectedIndex)
        End If
    End Sub
    Private Sub cboPRENESTA_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboPRENESTA.KeyDown
        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
            fun_Cargar_ComboBox_Con_Datos_Activos_ESTADO(Me.cboPRENESTA, Me.cboPRENESTA.SelectedIndex)
        End If
    End Sub

#End Region

#Region "GotFocus"

    Private Sub txt_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtPRENNUDO.GotFocus, txtPRENDESC.GotFocus
        pp_pro_SobrearCampo(sender)
        pp_pro_DescripcionCampo(Me.strBARRESTA.Items(0), sender)
    End Sub
    Private Sub cmd_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdGUARDAR.GotFocus, cmdSALIR.GotFocus
        pp_pro_DescripcionCampo(Me.strBARRESTA.Items(0), sender)
    End Sub
    Private Sub cbo_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboPRENDEPA.GotFocus, cboPRENMUNI.GotFocus, cboPRENCLSE.GotFocus, cboPRENTIDO.GotFocus, cboPRENTIIM.GotFocus, cboPRENESTA.GotFocus, cboPRENCONC.GotFocus, cboPRENCAPR.GotFocus, cboPRENSEXO.GotFocus
        pp_pro_DescripcionCampo(Me.strBARRESTA.Items(0), sender)
    End Sub

#End Region

#Region "SelectedIndexChanged"

    Private Sub cboPRENDEPA_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboPRENDEPA.SelectedIndexChanged
        Me.lblPRENDEPA.Text = CType(fun_Buscar_Lista_Valores_DEPARTAMENTO_Codigo(Me.cboPRENDEPA), String)

        Me.cboPRENMUNI.DataSource = New DataTable
        Me.lblPRENMUNI.Text = ""
    End Sub
    Private Sub cboPRENMUNI_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboPRENMUNI.SelectedIndexChanged
        Me.lblPRENMUNI.Text = CType(fun_Buscar_Lista_Valores_MUNICIPIO_Codigo(Me.cboPRENDEPA, Me.cboPRENMUNI), String)
    End Sub
    Private Sub cboPRENCLSE_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboPRENCLSE.SelectedIndexChanged
        Me.lblPRENCLSE.Text = CType(fun_Buscar_Lista_Valores_CLASSECT_Codigo(Me.cboPRENCLSE), String)
    End Sub
    Private Sub cboPRENTIIM_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboPRENTIIM.SelectedIndexChanged
        Me.lblPRENTIIM.Text = CType(fun_Buscar_Lista_Valores_TIPOIMPU_Codigo(Me.cboPRENTIIM), String)

        Me.cboPRENCONC.DataSource = New DataTable
        Me.lblPRENCONC.Text = ""
    End Sub
    Private Sub cboPRENCONC_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboPRENCONC.SelectedIndexChanged
        Me.lblPRENCONC.Text = CType(fun_Buscar_Lista_Valores_CONCEPTO_Codigo(Me.cboPRENTIIM, Me.cboPRENCONC), String)
    End Sub
    Private Sub cboPRENTIDO_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboPRENTIDO.SelectedIndexChanged
        Me.lblPRENTIDO.Text = CType(fun_Buscar_Lista_Valores_TIPODOCU_Codigo(Me.cboPRENTIDO), String)
    End Sub
    Private Sub cboPRENCAPR_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboPRENCAPR.SelectedIndexChanged
        Me.lblPRENCAPR.Text = CType(fun_Buscar_Lista_Valores_CALIPROP_Codigo(Me.cboPRENCAPR), String)
    End Sub
    Private Sub cboPRENSEXO_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboPRENSEXO.SelectedIndexChanged
        Me.lblPRENSEXO.Text = CType(fun_Buscar_Lista_Valores_SEXO_Codigo(Me.cboPRENSEXO), String)
    End Sub

#End Region

#Region "Click"

    Private Sub cboPRENDEPA_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboPRENDEPA.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_DEPARTAMENTO_Descripcion(Me.cboPRENDEPA, Me.cboPRENDEPA.SelectedIndex)
    End Sub
    Private Sub cboPRENMUNI_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboPRENMUNI.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_MUNICIPIO_X_DEPARTAMENTO_Descripcion(Me.cboPRENMUNI, Me.cboPRENMUNI.SelectedIndex, Me.cboPRENDEPA)
    End Sub
    Private Sub cboPRENCLSE_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboPRENCLSE.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_CLASSECT_Descripcion(Me.cboPRENCLSE, Me.cboPRENCLSE.SelectedIndex)
    End Sub
    Private Sub cboPRENTIIM_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboPRENTIIM.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_TIPOIMPU_Descripcion(Me.cboPRENTIIM, Me.cboPRENTIIM.SelectedIndex)
    End Sub
    Private Sub cboPRENCONC_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboPRENCONC.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_CONCEPTO_Descripcion(Me.cboPRENCONC, Me.cboPRENCONC.SelectedIndex, Me.cboPRENTIIM)
    End Sub
    Private Sub cboPRENTIDO_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboPRENTIDO.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_TIPODOCU_Descripcion(Me.cboPRENTIDO, Me.cboPRENTIDO.SelectedIndex)
    End Sub
    Private Sub cboPRENCAPR_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboPRENCAPR.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_CALIPROP_Descripcion(Me.cboPRENCAPR, Me.cboPRENCAPR.SelectedIndex)
    End Sub
    Private Sub cboPRENSEXO_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboPRENSEXO.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_SEXO_Descripcion(Me.cboPRENSEXO, Me.cboPRENSEXO.SelectedIndex)
    End Sub
    Private Sub cboPRENESTA_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboPRENESTA.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_ESTADO(Me.cboPRENESTA, Me.cboPRENESTA.SelectedIndex)
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