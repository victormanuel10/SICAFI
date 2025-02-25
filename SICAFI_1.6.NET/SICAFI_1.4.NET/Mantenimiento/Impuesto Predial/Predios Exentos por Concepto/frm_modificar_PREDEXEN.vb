Imports REGLAS_DEL_NEGOCIO

Public Class frm_modificar_PREDEXEN

    '=================================
    '*** MODIFICAR PREDIOS EXENTOS ***
    '=================================

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

            Me.cboPREXDEPA.DataSource = objdatos1.fun_Consultar_CAMPOS_MANT_DEPARTAMENTO
            Me.cboPREXDEPA.DisplayMember = "DEPADESC"
            Me.cboPREXDEPA.ValueMember = "DEPACODI"

            Dim objdatos2 As New cla_CLASSECT

            Me.cboPREXCLSE.DataSource = objdatos2.fun_Consultar_CAMPOS_MANT_CLASSECT
            Me.cboPREXCLSE.DisplayMember = "CLSEDESC"
            Me.cboPREXCLSE.ValueMember = "CLSECODI"

            Dim objdatos27 As New cla_VIGENCIA

            Me.cboPREXVIIN.DataSource = objdatos27.fun_Consultar_CAMPOS_VIGENCIA
            Me.cboPREXVIIN.DisplayMember = "VIGEDESC"
            Me.cboPREXVIIN.ValueMember = "VIGECODI"

            Me.cboPREXVIFI.DataSource = objdatos27.fun_Consultar_CAMPOS_VIGENCIA
            Me.cboPREXVIFI.DisplayMember = "VIGEDESC"
            Me.cboPREXVIFI.ValueMember = "VIGECODI"

            Dim objdatos50 As New cla_TIPOIMPU

            Me.cboPREXTIIM.DataSource = objdatos50.fun_Consultar_CAMPOS_MANT_TIPOIMPU
            Me.cboPREXTIIM.DisplayMember = "TIIMDESC"
            Me.cboPREXTIIM.ValueMember = "TIIMCODI"

            Dim objdatos As New cla_ESTADO

            Me.cboPREXESTA.DataSource = objdatos.fun_Consultar_TODOS_LOS_ESTADOS
            Me.cboPREXESTA.DisplayMember = "ESTADESC"
            Me.cboPREXESTA.ValueMember = "ESTACODI"

            Dim objdatos3 As New cla_PREDEXEN
            Dim tbl As New DataTable

            tbl = objdatos3.fun_Buscar_ID_PREDEXEN(inID_REGISTRO)

            Me.cboPREXDEPA.SelectedValue = tbl.Rows(0).Item("PREXDEPA")

            Dim objdatos7 As New cla_MUNICIPIO

            Me.cboPREXMUNI.DataSource = objdatos7.fun_Consultar_CAMPOS_MANT_MUNICIPIO
            Me.cboPREXMUNI.DisplayMember = "MUNIDESC"
            Me.cboPREXMUNI.ValueMember = "MUNICODI"

            Me.cboPREXMUNI.SelectedValue = tbl.Rows(0).Item("PREXMUNI")
            Me.cboPREXCLSE.SelectedValue = tbl.Rows(0).Item("PREXCLSE")
            Me.txtPREXNUFI.Text = Trim(tbl.Rows(0).Item("PREXNUFI"))
            Me.cboPREXVIIN.SelectedValue = tbl.Rows(0).Item("PREXVIIN")
            Me.cboPREXVIFI.SelectedValue = tbl.Rows(0).Item("PREXVIFI")
            Me.cboPREXTIIM.SelectedValue = tbl.Rows(0).Item("PREXTIIM")

            Dim objdatos51 As New cla_CONCEPTO

            Me.cboPREXCONC.DataSource = objdatos51.fun_Consultar_CAMPOS_MANT_CONCEPTO
            Me.cboPREXCONC.DisplayMember = "CONCDESC"
            Me.cboPREXCONC.ValueMember = "CONCCODI"

            Me.cboPREXCONC.SelectedValue = tbl.Rows(0).Item("PREXCONC")
            Me.txtPREXPOAP.Text = Trim(tbl.Rows(0).Item("PREXPOAP"))
            Me.txtPREXRESO.Text = Trim(tbl.Rows(0).Item("PREXRESO"))
            Me.txtPREXFECH.Text = Trim(tbl.Rows(0).Item("PREXFECH"))
            Me.txtPREXOBSE.Text = Trim(tbl.Rows(0).Item("PREXOBSE"))
            Me.cboPREXESTA.SelectedValue = tbl.Rows(0).Item("PREXESTA")

            Dim boPREXDEPA As Boolean = fun_Buscar_Dato_DEPARTAMENTO(Me.cboPREXDEPA.SelectedValue)
            Dim boPREXMUNI As Boolean = fun_Buscar_Dato_MUNICIPIO(Me.cboPREXDEPA.SelectedValue, Me.cboPREXMUNI.SelectedValue)
            Dim boPREXCLSE As Boolean = fun_Buscar_Dato_CLASSECT(Me.cboPREXCLSE.SelectedValue)
            Dim boPREXVIIN As Boolean = fun_Buscar_Dato_VIGENCIA(Me.cboPREXVIIN.SelectedValue)
            Dim boPREXVIFI As Boolean = fun_Buscar_Dato_VIGENCIA(Me.cboPREXVIFI.SelectedValue)
            Dim boPREXTIIM As Boolean = fun_Buscar_Dato_TIPOIMPU(Me.cboPREXTIIM.SelectedValue)
            Dim boPREXCONC As Boolean = fun_Buscar_Dato_CONCEPTO(Me.cboPREXTIIM.SelectedValue, Me.cboPREXCONC.SelectedValue)
           
            If boPREXDEPA = True OrElse _
               boPREXMUNI = True OrElse _
               boPREXCLSE = True OrElse _
               boPREXVIIN = True OrElse _
               boPREXTIIM = True OrElse _
               boPREXCONC = True OrElse _
               boPREXVIFI = True Then

                Me.lblPREXDEPA.Text = CType(fun_Buscar_Lista_Valores_DEPARTAMENTO_Codigo(Me.cboPREXDEPA), String)
                Me.lblPREXMUNI.Text = CType(fun_Buscar_Lista_Valores_MUNICIPIO_Codigo(Me.cboPREXDEPA, Me.cboPREXMUNI), String)
                Me.lblPREXCLSE.Text = CType(fun_Buscar_Lista_Valores_CLASSECT_Codigo(Me.cboPREXCLSE), String)
                Me.lblPREXVIIN.Text = CType(fun_Buscar_Lista_Valores_VIGENCIA_Codigo(Me.cboPREXVIIN), String)
                Me.lblPREXVIFI.Text = CType(fun_Buscar_Lista_Valores_VIGENCIA_Codigo(Me.cboPREXVIFI), String)
                Me.lblPREXTIIM.Text = CType(fun_Buscar_Lista_Valores_TIPOIMPU_Codigo(Me.cboPREXTIIM), String)
                Me.lblPREXCONC.Text = CType(fun_Buscar_Lista_Valores_CONCEPTO_Codigo(Me.cboPREXTIIM, Me.cboPREXCONC), String)
          
            Else
                frm_INCO_modifircar_registros_sin_listas_de_valores.ShowDialog()
            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub pro_LimpiarCampos()

        Me.cboPREXDEPA.DataSource = New DataTable
        Me.cboPREXMUNI.DataSource = New DataTable
        Me.cboPREXCLSE.DataSource = New DataTable
        Me.cboPREXTIIM.DataSource = New DataTable
        Me.cboPREXCONC.DataSource = New DataTable
        Me.cboPREXVIIN.DataSource = New DataTable
        Me.cboPREXVIFI.DataSource = New DataTable
        Me.cboPREXESTA.DataSource = New DataTable

        Me.lblPREXDEPA.Text = ""
        Me.lblPREXMUNI.Text = ""
        Me.lblPREXCLSE.Text = ""
        Me.lblPREXVIIN.Text = ""
        Me.lblPREXVIFI.Text = ""
        Me.lblPREXTIIM.Text = ""
        Me.lblPREXCONC.Text = ""

        Me.txtPREXNUFI.Text = ""
        Me.txtPREXFECH.Text = ""
        Me.txtPREXPOAP.Text = "100"
        Me.txtPREXRESO.Text = ""
        Me.txtPREXOBSE.Text = ""

    End Sub

#End Region

#Region "MENU"

    Private Sub cmdGUARDAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGUARDAR.Click

        Try
            ' instancia la clase
            Dim objVerifica As New cla_Verificar_Dato

            Dim boPREXDEPA As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboPREXDEPA)
            Dim boPREXMUNI As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboPREXMUNI)
            Dim boPREXCLSE As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboPREXCLSE)
            Dim boPREXNUFI As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Numerico(Me.txtPREXNUFI)
            Dim boPREXTIIM As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboPREXTIIM)
            Dim boPREXCONC As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboPREXCONC)
            Dim boPREXVIIN As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboPREXVIIN)
            Dim boPREXVIFI As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboPREXVIFI)
            Dim boPREXPOAP As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Numerico(Me.txtPREXPOAP)
            Dim boPREXRESO As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Numerico(Me.txtPREXRESO)
            Dim boPREXFECH As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Fecha(Me.txtPREXFECH)
            Dim boPREXESTA As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboPREXESTA)

            ' verifica los datos del formulario 
            If boPREXDEPA = True And _
               boPREXMUNI = True And _
               boPREXCLSE = True And _
               boPREXNUFI = True And _
               boPREXTIIM = True And _
               boPREXCONC = True And _
               boPREXVIIN = True And _
               boPREXVIFI = True And _
               boPREXPOAP = True And _
               boPREXRESO = True And _
               boPREXFECH = True And _
               boPREXESTA = True Then

                Dim objdatos22 As New cla_PREDEXEN

                If (objdatos22.fun_Actualizar_PREDEXEN(inID_REGISTRO, _
                                                     Me.cboPREXDEPA.SelectedValue, _
                                                     Me.cboPREXMUNI.SelectedValue, _
                                                     Me.cboPREXCLSE.SelectedValue, _
                                                     Me.txtPREXNUFI.Text, _
                                                     Me.cboPREXTIIM.SelectedValue, _
                                                     Me.cboPREXCONC.SelectedValue, _
                                                     Me.cboPREXVIIN.SelectedValue, _
                                                     Me.cboPREXVIFI.SelectedValue, _
                                                     Me.txtPREXPOAP.Text, _
                                                     Me.txtPREXRESO.Text, _
                                                     Me.txtPREXFECH.Text, _
                                                     Me.txtPREXOBSE.Text, _
                                                     Me.cboPREXESTA.SelectedValue)) = True Then

                    mod_MENSAJE.Se_Guardaron_Los_Datos_Correctamente()
                    Me.cboPREXDEPA.Focus()
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
        Me.cboPREXDEPA.Focus()
        Me.Close()
    End Sub

#End Region

#Region "FORMULARIO"

#Region "KeyPress"

    Private Sub txt_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboPREXDEPA.KeyPress, cboPREXMUNI.KeyPress, cboPREXCLSE.KeyPress, txtPREXNUFI.KeyPress, cboPREXVIIN.KeyPress, cboPREXVIFI.KeyPress, cboPREXTIIM.KeyPress, cboPREXCONC.KeyPress, cboPREXESTA.KeyPress, txtPREXPOAP.KeyPress, txtPREXRESO.KeyPress, txtPREXFECH.KeyPress, txtPREXOBSE.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Or e.KeyChar = Convert.ToChar(Keys.Tab) Then
            pp_pro_SaltarCampo()
        End If
    End Sub

#End Region

#Region "KeyDown"

    Private Sub cboPREXDEPA_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboPREXDEPA.KeyDown
        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
            fun_Cargar_ComboBox_Con_Datos_Activos_DEPARTAMENTO_Descripcion(Me.cboPREXDEPA, Me.cboPREXDEPA.SelectedIndex)
        End If
    End Sub
    Private Sub cboPREXMUNI_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboPREXMUNI.KeyDown
        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
            fun_Cargar_ComboBox_Con_Datos_Activos_MUNICIPIO_X_DEPARTAMENTO_Descripcion(Me.cboPREXMUNI, Me.cboPREXMUNI.SelectedIndex, Me.cboPREXDEPA)
        End If
    End Sub
    Private Sub cboPREXCLSE_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboPREXCLSE.KeyDown
        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
            fun_Cargar_ComboBox_Con_Datos_Activos_CLASSECT_Descripcion(Me.cboPREXCLSE, Me.cboPREXCLSE.SelectedIndex)
        End If
    End Sub
    Private Sub cboPREXVIIN_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboPREXVIIN.KeyDown
        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
            fun_Cargar_ComboBox_Con_Datos_Activos_VIGENCIA_Descripcion(Me.cboPREXVIIN, Me.cboPREXVIIN.SelectedIndex)
        End If
    End Sub
    Private Sub cboPREXVIFI_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboPREXVIFI.KeyDown
        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
            fun_Cargar_ComboBox_Con_Datos_Activos_VIGENCIA_Descripcion(Me.cboPREXVIFI, Me.cboPREXVIFI.SelectedIndex)
        End If
    End Sub
    Private Sub cboPREXTIIM_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboPREXTIIM.KeyDown
        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
            fun_Cargar_ComboBox_Con_Datos_Activos_TIPOIMPU_Descripcion(Me.cboPREXTIIM, Me.cboPREXTIIM.SelectedIndex)
        End If
    End Sub
    Private Sub cboPREXCONC_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboPREXCONC.KeyDown
        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
            fun_Cargar_ComboBox_Con_Datos_Activos_CONCEPTO_Descripcion(Me.cboPREXCONC, Me.cboPREXCONC.SelectedIndex, Me.cboPREXDEPA)
        End If
    End Sub
    Private Sub cboPREXESTA_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboPREXESTA.KeyDown
        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
            fun_Cargar_ComboBox_Con_Datos_Activos_ESTADO(Me.cboPREXESTA, Me.cboPREXESTA.SelectedIndex)
        End If
    End Sub

#End Region

#Region "GotFocus"

    Private Sub txt_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtPREXNUFI.GotFocus, txtPREXPOAP.GotFocus, txtPREXRESO.GotFocus, txtPREXFECH.GotFocus, txtPREXOBSE.GotFocus
        pp_pro_SobrearCampo(sender)
        pp_pro_DescripcionCampo(Me.strBARRESTA.Items(0), sender)
    End Sub
    Private Sub cmd_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdGUARDAR.GotFocus, cmdSALIR.GotFocus
        pp_pro_DescripcionCampo(Me.strBARRESTA.Items(0), sender)
    End Sub
    Private Sub cbo_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboPREXDEPA.GotFocus, cboPREXMUNI.GotFocus, cboPREXCLSE.GotFocus, cboPREXVIIN.GotFocus, cboPREXTIIM.GotFocus, cboPREXESTA.GotFocus, cboPREXCONC.GotFocus, cboPREXVIIN.GotFocus
        pp_pro_DescripcionCampo(Me.strBARRESTA.Items(0), sender)
    End Sub

#End Region

#Region "SelectedIndexChanged"

    Private Sub cboPREXDEPA_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboPREXDEPA.SelectedIndexChanged
        Me.lblPREXDEPA.Text = CType(fun_Buscar_Lista_Valores_DEPARTAMENTO_Codigo(Me.cboPREXDEPA), String)

        Me.cboPREXMUNI.DataSource = New DataTable
        Me.lblPREXMUNI.Text = ""
    End Sub
    Private Sub cboPREXMUNI_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboPREXMUNI.SelectedIndexChanged
        Me.lblPREXMUNI.Text = CType(fun_Buscar_Lista_Valores_MUNICIPIO_Codigo(Me.cboPREXDEPA, Me.cboPREXMUNI), String)
    End Sub
    Private Sub cboPREXCLSE_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboPREXCLSE.SelectedIndexChanged
        Me.lblPREXCLSE.Text = CType(fun_Buscar_Lista_Valores_CLASSECT_Codigo(Me.cboPREXCLSE), String)
    End Sub
    Private Sub cboPREXVIIN_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboPREXVIIN.SelectedIndexChanged
        Me.lblPREXVIIN.Text = CType(fun_Buscar_Lista_Valores_VIGENCIA_Codigo(Me.cboPREXVIIN), String)
    End Sub
    Private Sub cboPREXVIFI_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboPREXVIFI.SelectedIndexChanged
        Me.lblPREXVIFI.Text = CType(fun_Buscar_Lista_Valores_VIGENCIA_Codigo(Me.cboPREXVIFI), String)
    End Sub
    Private Sub cboPREXTIIM_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboPREXTIIM.SelectedIndexChanged
        Me.lblPREXTIIM.Text = CType(fun_Buscar_Lista_Valores_TIPOIMPU_Codigo(Me.cboPREXTIIM), String)

        Me.cboPREXCONC.DataSource = New DataTable
        Me.lblPREXCONC.Text = ""
    End Sub
    Private Sub cboPREXCONC_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboPREXCONC.SelectedIndexChanged
        Me.lblPREXCONC.Text = CType(fun_Buscar_Lista_Valores_CONCEPTO_Codigo(Me.cboPREXTIIM, Me.cboPREXCONC), String)
    End Sub

#End Region

#Region "Click"

    Private Sub cboPREXDEPA_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboPREXDEPA.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_DEPARTAMENTO_Descripcion(Me.cboPREXDEPA, Me.cboPREXDEPA.SelectedIndex)
    End Sub
    Private Sub cboPREXMUNI_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboPREXMUNI.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_MUNICIPIO_X_DEPARTAMENTO_Descripcion(Me.cboPREXMUNI, Me.cboPREXMUNI.SelectedIndex, Me.cboPREXDEPA)
    End Sub
    Private Sub cboPREXCLSE_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboPREXCLSE.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_CLASSECT_Descripcion(Me.cboPREXCLSE, Me.cboPREXCLSE.SelectedIndex)
    End Sub
    Private Sub cboPREXVIIN_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboPREXVIIN.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_VIGENCIA_Descripcion(Me.cboPREXVIIN, Me.cboPREXVIIN.SelectedIndex)
    End Sub
    Private Sub cboPREXVIFI_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboPREXVIFI.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_VIGENCIA_Descripcion(Me.cboPREXVIFI, Me.cboPREXVIFI.SelectedIndex)
    End Sub
    Private Sub cboPREXTIIM_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboPREXTIIM.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_TIPOIMPU_Descripcion(Me.cboPREXTIIM, Me.cboPREXTIIM.SelectedIndex)
    End Sub
    Private Sub cboPREXCONC_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboPREXCONC.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_CONCEPTO_Descripcion(Me.cboPREXCONC, Me.cboPREXCONC.SelectedIndex, Me.cboPREXTIIM)
    End Sub
    Private Sub cboPREXESTA_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboPREXESTA.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_ESTADO(Me.cboPREXESTA, Me.cboPREXESTA.SelectedIndex)
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