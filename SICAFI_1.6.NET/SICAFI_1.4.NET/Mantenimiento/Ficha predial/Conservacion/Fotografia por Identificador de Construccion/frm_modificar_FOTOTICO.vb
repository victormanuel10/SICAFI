Imports REGLAS_DEL_NEGOCIO

Public Class frm_modificar_FOTOTICO

    '==============================================================
    '*** MODIFICAR FOTOGRAFIA POR IDENTIFICADOR DE CONSTRUCCIÓN ***
    '==============================================================

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

            Dim objdatos8 As New cla_FOTOTICO
            Dim tbl As New DataTable

            tbl = objdatos8.fun_Buscar_ID_MANT_FOTOTICO(inID_REGISTRO)

            Dim objdatos11 As New cla_DEPARTAMENTO

            Me.cboFOTCDEPA.DataSource = objdatos11.fun_Consultar_CAMPOS_MANT_DEPARTAMENTO
            Me.cboFOTCDEPA.DisplayMember = "DEPADESC"
            Me.cboFOTCDEPA.ValueMember = "DEPACODI"

            Me.cboFOTCDEPA.SelectedValue = tbl.Rows(0).Item("FOTCDEPA")

            Dim objdatos12 As New cla_MUNICIPIO

            Me.cboFOTCMUNI.DataSource = objdatos12.fun_Consultar_CAMPOS_MANT_MUNICIPIO
            Me.cboFOTCMUNI.DisplayMember = "MUNIDESC"
            Me.cboFOTCMUNI.ValueMember = "MUNICODI"

            Me.cboFOTCMUNI.SelectedValue = tbl.Rows(0).Item("FOTCMUNI")

            Dim objdatos1 As New cla_CLASSECT

            Me.cboFOTCCLSE.DataSource = objdatos1.fun_Consultar_CAMPOS_MANT_CLASSECT
            Me.cboFOTCCLSE.DisplayMember = "CLSEDESC"
            Me.cboFOTCCLSE.ValueMember = "CLSECODI"

            Me.cboFOTCCLSE.SelectedValue = tbl.Rows(0).Item("FOTCCLSE")

            Dim objdatos23 As New cla_TIPOCALI

            Me.cboFOTCTIPO.DataSource = objdatos23.fun_Consultar_CAMPOS_MANT_TIPOCALI
            Me.cboFOTCTIPO.DisplayMember = "TICADESC"
            Me.cboFOTCTIPO.ValueMember = "TICACODI"

            Me.cboFOTCTIPO.SelectedValue = tbl.Rows(0).Item("FOTCTIPO")

            Dim objdatos25 As New cla_CLASCONS

            Me.cboFOTCCLCO.DataSource = objdatos25.fun_Consultar_CAMPOS_MANT_CLASCONS
            Me.cboFOTCCLCO.DisplayMember = "CLCODESC"
            Me.cboFOTCCLCO.ValueMember = "CLCOCODI"

            Me.cboFOTCCLCO.SelectedValue = tbl.Rows(0).Item("FOTCCLCO")

            Dim objdatos26 As New cla_TIPOCONS

            Me.cboFOTCTICO.DataSource = objdatos26.fun_Consultar_CAMPOS_MANT_TIPOCONS
            Me.cboFOTCTICO.DisplayMember = "TICODESC"
            Me.cboFOTCTICO.ValueMember = "TICOCODI"

            Me.cboFOTCTICO.SelectedValue = tbl.Rows(0).Item("FOTCTICO")

            Dim objdatos18 As New cla_CARPFOTO

            Me.cboFOTCCAFO.DataSource = objdatos18.fun_Consultar_CAMPOS_MANT_CARPFOTO
            Me.cboFOTCCAFO.DisplayMember = "CAFODESC"
            Me.cboFOTCCAFO.ValueMember = "CAFOCODI"

            Me.cboFOTCCAFO.SelectedValue = tbl.Rows(0).Item("FOTCCAFO")

            Dim objdatos16 As New cla_ESTADO

            Me.cboFOTCESTA.DataSource = objdatos16.fun_Consultar_TODOS_LOS_ESTADOS
            Me.cboFOTCESTA.DisplayMember = "ESTADESC"
            Me.cboFOTCESTA.ValueMember = "ESTACODI"

            Me.cboFOTCESTA.SelectedValue = tbl.Rows(0).Item("FOTCESTA")

            ' Lista de valores
            Me.lblFOTCDEPA.Text = CType(fun_Buscar_Lista_Valores_DEPARTAMENTO_Codigo(Me.cboFOTCDEPA), String)
            Me.lblFOTCMUNI.Text = CType(fun_Buscar_Lista_Valores_MUNICIPIO_Codigo(Me.cboFOTCDEPA, Me.cboFOTCMUNI), String)
            Me.lblFOTCCLSE.Text = CType(fun_Buscar_Lista_Valores_CLASSECT_Codigo(Me.cboFOTCCLSE), String)
            Me.lblFOTCCAFO.Text = CType(fun_Buscar_Lista_Valores_CARPFOTO_Codigo(Me.cboFOTCCAFO), String)
            Me.lblFOTCTIPO.Text = CType(fun_Buscar_Lista_Valores_TIPOCALI_Codigo(Me.cboFOTCTIPO), String)
            Me.lblFOTCCLCO.Text = CType(fun_Buscar_Lista_Valores_CLASCONS_Codigo(Me.cboFOTCCLCO), String)
            Me.lblFOTCTICO.Text = CType(fun_Buscar_Lista_Valores_TIPOCONS_Codigo(Me.cboFOTCDEPA, Me.cboFOTCMUNI, Me.cboFOTCCLCO, Me.cboFOTCCLSE, Me.cboFOTCTICO), String)

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub pro_LimpiarCampos()

        Me.lblFOTCDEPA.Text = ""
        Me.lblFOTCMUNI.Text = ""
        Me.lblFOTCCLSE.Text = ""
        Me.lblFOTCTIPO.Text = ""
        Me.lblFOTCCLCO.Text = ""
        Me.lblFOTCTICO.Text = ""
        Me.lblFOTCCAFO.Text = ""

        Me.cboFOTCDEPA.DataSource = New DataTable
        Me.cboFOTCMUNI.DataSource = New DataTable
        Me.cboFOTCCLSE.DataSource = New DataTable
        Me.cboFOTCTIPO.DataSource = New DataTable
        Me.cboFOTCCLCO.DataSource = New DataTable
        Me.cboFOTCTICO.DataSource = New DataTable
        Me.cboFOTCCAFO.DataSource = New DataTable

    End Sub

#End Region

#Region "MENU"

    Private Sub cmdGUARDAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGUARDAR.Click

        Try
            
            ' instancia la clase
            Dim objVerifica As New cla_Verificar_Dato

            Dim boFOTCDEPA As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboFOTCDEPA)
            Dim boFOTCMUNI As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboFOTCMUNI)
            Dim boFOTCCLSE As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboFOTCCLSE)
            Dim boFOTCTIPO As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboFOTCTIPO)
            Dim boFOTCCLCO As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboFOTCCLCO)
            Dim boFOTCTICO As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboFOTCTICO)
            Dim boFOTCCAFO As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboFOTCCAFO)
            Dim boFOTCESTA As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboFOTCESTA)

            ' verifica los datos del formulario 
            If boFOTCDEPA = True And _
               boFOTCMUNI = True And _
               boFOTCCAFO = True And _
               boFOTCCLSE = True And _
               boFOTCTIPO = True And _
               boFOTCCLCO = True And _
               boFOTCTICO = True And _
               boFOTCESTA = True Then

                Dim objdatos22 As New cla_FOTOTICO

                If (objdatos22.fun_Actualizar_MANT_FOTOTICO(inID_REGISTRO, _
                                                            Me.cboFOTCDEPA.SelectedValue, _
                                                            Me.cboFOTCMUNI.SelectedValue, _
                                                            Me.cboFOTCCLSE.SelectedValue, _
                                                            Me.cboFOTCTIPO.SelectedValue, _
                                                            Me.cboFOTCCLCO.SelectedValue, _
                                                            Me.cboFOTCTICO.SelectedValue, _
                                                            Me.cboFOTCCAFO.SelectedValue, _
                                                            Me.cboFOTCESTA.SelectedValue)) = True Then

                    mod_MENSAJE.Se_Guardaron_Los_Datos_Correctamente()

                    Me.cboFOTCDEPA.Focus()
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
        Dim inNroIdRe As New frm_FOTOTICO(0)
        Me.cboFOTCDEPA.Focus()
        Me.Close()
    End Sub

#End Region

#Region "FORMULARIO"

#Region "KeyPress"

    Private Sub txt_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboFOTCDEPA.KeyPress, cboFOTCMUNI.KeyPress, cboFOTCCAFO.KeyPress, cboFOTCCLSE.KeyPress, cboFOTCTIPO.KeyPress, cboFOTCCLCO.KeyPress, cboFOTCTICO.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Or e.KeyChar = Convert.ToChar(Keys.Tab) Then
            pp_pro_SaltarCampo()
        End If
    End Sub

#End Region

#Region "KeyDown"

    Private Sub cboFOTCDEPA_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboFOTCDEPA.KeyDown
        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
            fun_Cargar_ComboBox_Con_Datos_Activos_DEPARTAMENTO_Descripcion(Me.cboFOTCDEPA, Me.cboFOTCDEPA.SelectedIndex)
        End If
    End Sub
    Private Sub cboFOTCMUNI_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboFOTCMUNI.KeyDown
        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
            fun_Cargar_ComboBox_Con_Datos_Activos_MUNICIPIO_X_DEPARTAMENTO_Descripcion(Me.cboFOTCMUNI, Me.cboFOTCMUNI.SelectedIndex, Me.cboFOTCDEPA)
        End If
    End Sub
    Private Sub cboFOTCCAFO_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboFOTCCAFO.KeyDown
        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
            fun_Cargar_ComboBox_Con_Datos_Activos_CARPFOTO_Descripcion(Me.cboFOTCCAFO, Me.cboFOTCCAFO.SelectedIndex)
        End If
    End Sub
    Private Sub cboFOTCCLSE_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboFOTCCLSE.KeyDown
        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
            fun_Cargar_ComboBox_Con_Datos_Activos_CLASSECT_Descripcion(Me.cboFOTCCLSE, Me.cboFOTCCLSE.SelectedIndex)
        End If
    End Sub
    Private Sub cboFOTCESTA_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboFOTCESTA.KeyDown
        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
            fun_Cargar_ComboBox_Con_Datos_Activos_ESTADO_Descripcion(Me.cboFOTCESTA, Me.cboFOTCESTA.SelectedIndex)
        End If
    End Sub
    Private Sub cboFOTCTIPO_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboFOTCTIPO.KeyDown
        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
            fun_Cargar_ComboBox_Con_Datos_Activos_TIPOCALI_Descripcion(Me.cboFOTCTIPO, Me.cboFOTCTIPO.SelectedIndex)
        End If
    End Sub
    Private Sub cboFOTCCLCO_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboFOTCCLCO.KeyDown
        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
            fun_Cargar_ComboBox_Con_Datos_Activos_CLASCONS_Descripcion(Me.cboFOTCCLCO, Me.cboFOTCCLCO.SelectedIndex)
        End If
    End Sub
    Private Sub cboFOTCTICO_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboFOTCTICO.KeyDown
        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
            fun_Cargar_ComboBox_Con_Datos_Activos_TIPOCONS_X_MUNICIPIO_Descripcion(Me.cboFOTCTICO, Me.cboFOTCTICO.SelectedIndex, Me.cboFOTCDEPA, Me.cboFOTCMUNI, Me.cboFOTCCLCO, Me.cboFOTCCLSE)
        End If
    End Sub

#End Region

#Region "GotFocus"

    Private Sub txt_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs)
        pp_pro_SobrearCampo(sender)
        pp_pro_DescripcionCampo(Me.strBARRESTA.Items(0), sender)
    End Sub
    Private Sub cmd_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdGUARDAR.GotFocus, cmdSALIR.GotFocus
        pp_pro_DescripcionCampo(Me.strBARRESTA.Items(0), sender)
    End Sub
    Private Sub cbo_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboFOTCDEPA.GotFocus, cboFOTCMUNI.GotFocus, cboFOTCCAFO.GotFocus, cboFOTCCLSE.GotFocus, cboFOTCTIPO.GotFocus, cboFOTCCLCO.GotFocus, cboFOTCTICO.GotFocus
        pp_pro_DescripcionCampo(Me.strBARRESTA.Items(0), sender)
    End Sub

#End Region

#Region "SelectedIndexChanged"

    Private Sub cboFOTCDEPA_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboFOTCDEPA.SelectedIndexChanged
        Me.lblFOTCDEPA.Text = CType(fun_Buscar_Lista_Valores_DEPARTAMENTO_Codigo(Me.cboFOTCDEPA), String)

        Me.cboFOTCMUNI.DataSource = New DataTable
        Me.lblFOTCMUNI.Text = ""
    End Sub
    Private Sub cboFOTCMUNI_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboFOTCMUNI.SelectedIndexChanged
        Me.lblFOTCMUNI.Text = CType(fun_Buscar_Lista_Valores_MUNICIPIO_Codigo(Me.cboFOTCDEPA, Me.cboFOTCMUNI), String)
    End Sub
    Private Sub cboFOTCCAFO_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboFOTCCAFO.SelectedIndexChanged
        Me.lblFOTCCAFO.Text = CType(fun_Buscar_Lista_Valores_CARPFOTO_Codigo(Me.cboFOTCCAFO), String)
    End Sub
    Private Sub cboFOTCCLSE_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboFOTCCLSE.SelectedIndexChanged
        Me.lblFOTCCLSE.Text = CType(fun_Buscar_Lista_Valores_CLASSECT_Codigo(Me.cboFOTCCLSE), String)
    End Sub
    Private Sub cboFOTCTIPO_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboFOTCTIPO.SelectedIndexChanged
        Me.lblFOTCTIPO.Text = CType(fun_Buscar_Lista_Valores_TIPOCALI_Codigo(Me.cboFOTCTIPO), String)
    End Sub
    Private Sub cboFOTCCLCO_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboFOTCCLCO.SelectedIndexChanged
        Me.lblFOTCCLCO.Text = CType(fun_Buscar_Lista_Valores_CLASCONS_Codigo(Me.cboFOTCCLCO), String)

        Me.cboFOTCTICO.DataSource = New DataTable
        Me.lblFOTCTICO.Text = ""
    End Sub
    Private Sub cboFOTCTICO_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboFOTCTICO.SelectedIndexChanged
        Me.lblFOTCTICO.Text = CType(fun_Buscar_Lista_Valores_TIPOCONS_Codigo(Me.cboFOTCDEPA, Me.cboFOTCMUNI, Me.cboFOTCCLCO, Me.cboFOTCCLSE, Me.cboFOTCTICO), String)
    End Sub

#End Region

#Region "Click"

    Private Sub cboFOTCNODE_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboFOTCDEPA.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_DEPARTAMENTO_Descripcion(Me.cboFOTCDEPA, Me.cboFOTCDEPA.SelectedIndex)
    End Sub
    Private Sub cboFOTCMUNI_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboFOTCMUNI.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_MUNICIPIO_X_DEPARTAMENTO_Descripcion(Me.cboFOTCMUNI, Me.cboFOTCMUNI.SelectedIndex, Me.cboFOTCDEPA)
    End Sub
    Private Sub cboFOTCCAFO_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboFOTCCAFO.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_CARPFOTO_Descripcion(Me.cboFOTCCAFO, Me.cboFOTCCAFO.SelectedIndex)
    End Sub
    Private Sub cboFOTCCLSE_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboFOTCCLSE.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_CLASSECT_Descripcion(Me.cboFOTCCLSE, Me.cboFOTCCLSE.SelectedIndex)
    End Sub
    Private Sub cboFOTCESTA_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboFOTCESTA.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_ESTADO_Descripcion(Me.cboFOTCESTA, Me.cboFOTCESTA.SelectedIndex)
    End Sub
    Private Sub cboFOTCTIPO_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboFOTCTIPO.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_TIPOCALI_Descripcion(Me.cboFOTCTIPO, Me.cboFOTCTIPO.SelectedIndex)
    End Sub
    Private Sub cboFOTCCLCO_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboFOTCCLCO.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_CLASCONS_Descripcion(Me.cboFOTCCLCO, Me.cboFOTCCLCO.SelectedIndex)
    End Sub
    Private Sub cboFOTCTICO_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboFOTCTICO.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_TIPOCONS_X_MUNICIPIO_Descripcion(Me.cboFOTCTICO, Me.cboFOTCTICO.SelectedIndex, Me.cboFOTCDEPA, Me.cboFOTCMUNI, Me.cboFOTCCLCO, Me.cboFOTCCLSE)
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