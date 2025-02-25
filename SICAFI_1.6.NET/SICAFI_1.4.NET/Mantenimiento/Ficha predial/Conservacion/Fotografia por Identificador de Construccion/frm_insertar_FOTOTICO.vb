Imports REGLAS_DEL_NEGOCIO

Public Class frm_insertar_FOTOTICO

    '=============================================================
    '*** INSERTAR FOTOGRAFIA POR IDENTIFICADOR DE CONSTRUCCIÓN ***
    '=============================================================

#Region "PROCEDIMIENTOS"

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
            Dim objdatos As New cla_FOTOTICO

            Dim boLLAVEPRIMARIA As Boolean = objdatos.fun_Verifica_llave_Primaria_MANT_FOTOTICO(Me.cboFOTCDEPA, _
                                                                                                Me.cboFOTCMUNI, _
                                                                                                Me.cboFOTCCLSE, _
                                                                                                Me.cboFOTCTIPO, _
                                                                                                Me.cboFOTCCLCO, _
                                                                                                Me.cboFOTCTICO, _
                                                                                                Me.cboFOTCCAFO)

            ' instancia la clase
            Dim objVerifica As New cla_Verificar_Dato

            Dim boOBINDEPA As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboFOTCDEPA)
            Dim boOBINMUNI As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboFOTCMUNI)
            Dim boOBINCLSE As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboFOTCCLSE)
            Dim boOBINTIPO As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboFOTCTIPO)
            Dim boOBINCLCO As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboFOTCCLCO)
            Dim boOBINTICO As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboFOTCTICO)
            Dim boOBINCAFO As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboFOTCCAFO)
            Dim boOBINESTA As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboFOTCESTA)

            ' verifica los datos del formulario 
            If boLLAVEPRIMARIA = True And _
               boOBINDEPA = True And _
               boOBINMUNI = True And _
               boOBINCAFO = True And _
               boOBINCLSE = True And _
               boOBINTIPO = True And _
               boOBINCLCO = True And _
               boOBINTICO = True And _
               boOBINESTA = True Then

                Dim objdatos22 As New cla_FOTOTICO

                If (objdatos22.fun_Insertar_MANT_FOTOTICO(Me.cboFOTCDEPA.SelectedValue, _
                                                          Me.cboFOTCMUNI.SelectedValue, _
                                                          Me.cboFOTCCLSE.SelectedValue, _
                                                          Me.cboFOTCTIPO.SelectedValue, _
                                                          Me.cboFOTCCLCO.SelectedValue, _
                                                          Me.cboFOTCTICO.SelectedValue, _
                                                          Me.cboFOTCCAFO.SelectedValue, _
                                                          Me.cboFOTCESTA.SelectedValue)) = True Then

                    mod_MENSAJE.Se_Guardaron_Los_Datos_Correctamente()

                    If MessageBox.Show("¿ Desea agregar otro registro ?", "Mensaje...", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.No Then
                        Me.cboFOTCDEPA.Focus()
                        Me.Close()
                    Else
                        'pro_LimpiarCampos()
                        Me.cboFOTCDEPA.Focus()
                    End If

                Else
                    mod_MENSAJE.No_Se_Guardo_El_Registro_En_La_Base_De_Datos()
                End If
            End If


        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub cmdCANCELAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSALIR.Click
        Me.cboFOTCDEPA.Focus()
        Me.Close()
    End Sub

#End Region

#Region "FORMULARIO"

#Region "Load"

    Private Sub frm_insertar_OBSEINMO_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        pro_LimpiarCampos()
        Me.cboFOTCDEPA.Focus()
    End Sub

#End Region

#Region "KeyPress"

    Private Sub txt_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboFOTCDEPA.KeyPress, cboFOTCMUNI.KeyPress, cboFOTCCAFO.KeyPress, cboFOTCCLSE.KeyPress, cboFOTCTIPO.KeyPress, cboFOTCCLCO.KeyPress, cboFOTCTICO.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Or e.KeyChar = Convert.ToChar(Keys.Tab) Then
            pp_pro_SaltarCampo()
        End If
    End Sub

#End Region

#Region "KeyDown"

    Private Sub cboOBINDEPA_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboFOTCDEPA.KeyDown
        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
            fun_Cargar_ComboBox_Con_Datos_Activos_DEPARTAMENTO_Descripcion(Me.cboFOTCDEPA, Me.cboFOTCDEPA.SelectedIndex)
        End If
    End Sub
    Private Sub cboOBINMUNI_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboFOTCMUNI.KeyDown
        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
            fun_Cargar_ComboBox_Con_Datos_Activos_MUNICIPIO_X_DEPARTAMENTO_Descripcion(Me.cboFOTCMUNI, Me.cboFOTCMUNI.SelectedIndex, Me.cboFOTCDEPA)
        End If
    End Sub
    Private Sub cboRUCFCAFO_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboFOTCCAFO.KeyDown
        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
            fun_Cargar_ComboBox_Con_Datos_Activos_CARPFOTO_Descripcion(Me.cboFOTCCAFO, Me.cboFOTCCAFO.SelectedIndex)
        End If
    End Sub
    Private Sub cboOBINCLSE_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboFOTCCLSE.KeyDown
        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
            fun_Cargar_ComboBox_Con_Datos_Activos_CLASSECT_Descripcion(Me.cboFOTCCLSE, Me.cboFOTCCLSE.SelectedIndex)
        End If
    End Sub
    Private Sub cboOBINESTA_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboFOTCESTA.KeyDown
        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
            fun_Cargar_ComboBox_Con_Datos_Activos_ESTADO_Descripcion(Me.cboFOTCESTA, Me.cboFOTCESTA.SelectedIndex)
        End If
    End Sub
    Private Sub cboOBINTIPO_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboFOTCTIPO.KeyDown
        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
            fun_Cargar_ComboBox_Con_Datos_Activos_TIPOCALI_Descripcion(Me.cboFOTCTIPO, Me.cboFOTCTIPO.SelectedIndex)
        End If
    End Sub
    Private Sub cboOBINCLCO_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboFOTCCLCO.KeyDown
        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
            fun_Cargar_ComboBox_Con_Datos_Activos_CLASCONS_Descripcion(Me.cboFOTCCLCO, Me.cboFOTCCLCO.SelectedIndex)
        End If
    End Sub
    Private Sub cboOBINTICO_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboFOTCTICO.KeyDown
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

    Private Sub cboOBINDEPA_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboFOTCDEPA.SelectedIndexChanged
        Me.lblFOTCDEPA.Text = CType(fun_Buscar_Lista_Valores_DEPARTAMENTO_Codigo(Me.cboFOTCDEPA), String)

        Me.cboFOTCMUNI.DataSource = New DataTable
        Me.lblFOTCMUNI.Text = ""
    End Sub
    Private Sub cboOBINMUNI_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboFOTCMUNI.SelectedIndexChanged
        Me.lblFOTCMUNI.Text = CType(fun_Buscar_Lista_Valores_MUNICIPIO_Codigo(Me.cboFOTCDEPA, Me.cboFOTCMUNI), String)
    End Sub
    Private Sub cboRUCFCAFO_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboFOTCCAFO.SelectedIndexChanged
        Me.lblFOTCCAFO.Text = CType(fun_Buscar_Lista_Valores_CARPFOTO_Codigo(Me.cboFOTCCAFO), String)
    End Sub
    Private Sub cboOBINCLSE_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboFOTCCLSE.SelectedIndexChanged
        Me.lblFOTCCLSE.Text = CType(fun_Buscar_Lista_Valores_CLASSECT_Codigo(Me.cboFOTCCLSE), String)
    End Sub
    Private Sub cboOBINTIPO_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboFOTCTIPO.SelectedIndexChanged
        Me.lblFOTCTIPO.Text = CType(fun_Buscar_Lista_Valores_TIPOCALI_Codigo(Me.cboFOTCTIPO), String)
    End Sub
    Private Sub cboOBINCLCO_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboFOTCCLCO.SelectedIndexChanged
        Me.lblFOTCCLCO.Text = CType(fun_Buscar_Lista_Valores_CLASCONS_Codigo(Me.cboFOTCCLCO), String)

        Me.cboFOTCTICO.DataSource = New DataTable
        Me.lblFOTCTICO.Text = ""
    End Sub
    Private Sub cboOBINTICO_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboFOTCTICO.SelectedIndexChanged
        Me.lblFOTCTICO.Text = CType(fun_Buscar_Lista_Valores_TIPOCONS_Codigo(Me.cboFOTCDEPA, Me.cboFOTCMUNI, Me.cboFOTCCLCO, Me.cboFOTCCLSE, Me.cboFOTCTICO), String)
    End Sub

#End Region

#Region "Click"

    Private Sub cboOBINNODE_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboFOTCDEPA.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_DEPARTAMENTO_Descripcion(Me.cboFOTCDEPA, Me.cboFOTCDEPA.SelectedIndex)
    End Sub
    Private Sub cboOBINMUNI_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboFOTCMUNI.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_MUNICIPIO_X_DEPARTAMENTO_Descripcion(Me.cboFOTCMUNI, Me.cboFOTCMUNI.SelectedIndex, Me.cboFOTCDEPA)
    End Sub
    Private Sub cboRUCFCAFO_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboFOTCCAFO.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_CARPFOTO_Descripcion(Me.cboFOTCCAFO, Me.cboFOTCCAFO.SelectedIndex)
    End Sub
    Private Sub cboOBINCLSE_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboFOTCCLSE.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_CLASSECT_Descripcion(Me.cboFOTCCLSE, Me.cboFOTCCLSE.SelectedIndex)
    End Sub
    Private Sub cboOBINESTA_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboFOTCESTA.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_ESTADO_Descripcion(Me.cboFOTCESTA, Me.cboFOTCESTA.SelectedIndex)
    End Sub
    Private Sub cboOBINTIPO_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboFOTCTIPO.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_TIPOCALI_Descripcion(Me.cboFOTCTIPO, Me.cboFOTCTIPO.SelectedIndex)
    End Sub
    Private Sub cboOBINCLCO_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboFOTCCLCO.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_CLASCONS_Descripcion(Me.cboFOTCCLCO, Me.cboFOTCCLCO.SelectedIndex)
    End Sub
    Private Sub cboOBINTICO_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboFOTCTICO.Click
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