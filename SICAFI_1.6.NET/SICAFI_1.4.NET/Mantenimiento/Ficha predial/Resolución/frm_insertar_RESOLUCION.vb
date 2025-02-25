Imports REGLAS_DEL_NEGOCIO

Public Class frm_insertar_RESOLUCION

    '===========================
    '*** INSERTAR RESOLUCION ***
    '===========================

#Region "PROCEDIMIENTOS"

    Private Sub pro_LimpiarCampos()

        Me.txtRESOCODI.Text = ""
        Me.txtRESODESC.Text = ""
        Me.txtRESOCONT.Text = ""
        Me.chkRESOPATO.Checked = True

        Me.cboRESODEPA.DataSource = New DataTable
        Me.cboRESOMUNI.DataSource = New DataTable
        Me.cboRESOCLSE.DataSource = New DataTable
        Me.cboRESOTIRE.DataSource = New DataTable
        Me.cboRESOVIGE.DataSource = New DataTable
        Me.cboRESOESTA.DataSource = New DataTable

        Me.lblRESODEPA.Text = ""
        Me.lblRESOMUNI.Text = ""
        Me.lblRESOTIRE.Text = ""
        Me.lblRESOCLSE.Text = ""
        Me.lblRESOVIGE.Text = ""

    End Sub

#End Region

#Region "MENU"

    Private Sub cmdGUARDAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGUARDAR.Click

        Try
            ' instancia la clase
            Dim objdatos As New cla_RESOLUCION

            Dim boLLAVEPRIMARIA As Boolean = objdatos.fun_Verifica_llave_Primaria_RANGARTE(Me.cboRESODEPA, _
                                                                                           Me.cboRESOMUNI, _
                                                                                           Me.cboRESOCLSE, _
                                                                                           Me.cboRESOTIRE, _
                                                                                           Me.cboRESOVIGE, _
                                                                                           Me.txtRESOCODI)
            ' instancia la clase
            Dim objVerifica As New cla_Verificar_Dato

            Dim boRESODEPA As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboRESODEPA)
            Dim boRESOMUNI As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboRESOMUNI)
            Dim boRESOCLSE As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboRESOCLSE)
            Dim boRESOTIRE As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboRESOTIRE)
            Dim boRESOVIGE As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboRESOVIGE)
            Dim boRESOCODI As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Numerico(Me.txtRESOCODI)
            Dim boRESODESC As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.txtRESODESC)
            Dim boRESOCONT As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.txtRESOCONT)
            Dim boRESOESTA As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboRESOESTA)

            ' verifica los datos del formulario 
            If boLLAVEPRIMARIA = True And _
               boRESODEPA = True And _
               boRESOMUNI = True And _
               boRESOCLSE = True And _
               boRESOTIRE = True And _
               boRESOVIGE = True And _
               boRESOCODI = True And _
               boRESODESC = True And _
               boRESOCONT = True And _
               boRESOESTA = True Then

                Dim objdatosTexto As New cla_CRIPTOLOGIA

                ' desencripto el texto
                Dim stDesencriptarTexto As String = objdatosTexto.DesencriptarTexto(Trim(Me.txtRESOCONT.Text))

                ' verifica la encriptacion del municipio seleccionado vs encriptacion del campo de la forma
                If fun_Verificar_Municipio_Encriptado(fun_Formato_Mascara_2_Reales(Trim(Me.cboRESODEPA.SelectedValue)), fun_Formato_Mascara_3_Reales(Trim(Me.cboRESOMUNI.SelectedValue)), Me.cboRESOTIRE.SelectedValue, Me.cboRESOCLSE.SelectedValue, Trim(stDesencriptarTexto)) = False Then
                    MessageBox.Show("Contraseña invalida", "Mensaje ...", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1)
                Else

                    Dim objdatos55 As New cla_RESOLUCION

                    If (objdatos55.fun_Insertar_RESOLUCION(Me.cboRESODEPA.SelectedValue, _
                                                           Me.cboRESOMUNI.SelectedValue, _
                                                           Me.cboRESOTIRE.SelectedValue, _
                                                           Me.cboRESOCLSE.SelectedValue, _
                                                           Me.cboRESOVIGE.SelectedValue, _
                                                           Me.txtRESOCODI.Text, _
                                                           Me.txtRESODESC.Text, _
                                                           Me.chkRESOPATO.Checked, _
                                                           Me.cboRESOESTA.SelectedValue, _
                                                           Me.txtRESOCONT.Text)) = True Then

                        mod_MENSAJE.Se_Guardaron_Los_Datos_Correctamente()

                        If MessageBox.Show("¿ Desea agregar otro registro ?", "Mensaje...", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.No Then
                            Me.cboRESODEPA.Focus()
                            Me.Close()
                        Else
                            pro_LimpiarCampos()
                            Me.cboRESODEPA.Focus()
                        End If

                    Else
                        mod_MENSAJE.No_Se_Guardo_El_Registro_En_La_Base_De_Datos()
                    End If

                End If
            End If


        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub cmdCANCELAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSALIR.Click
        cboRESODEPA.Focus()
        Me.Close()
    End Sub

#End Region

#Region "FORMULARIO"

#Region "Load"

    Private Sub frm_insertar_RESOLUCION_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        pro_LimpiarCampos()
        Me.cboRESODEPA.Focus()
    End Sub

#End Region

#Region "KeyDown"

    Private Sub cboRESODEPA_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboRESODEPA.KeyDown
        If e.KeyCode = Keys.F2 Then
            mod_LLAMAR_FORMULARIO_INSERTAR.pro_Llamar_formulario_frm_DEPARTAMENTO()
        End If
    End Sub
    Private Sub cboRESOMUNI_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboRESOMUNI.KeyDown
        If e.KeyCode = Keys.F2 Then
            mod_LLAMAR_FORMULARIO_INSERTAR.pro_Llamar_formulario_frm_MUNICIPIO()
        End If
    End Sub
    Private Sub cboRESOTIRE_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboRESOTIRE.KeyDown
        If e.KeyCode = Keys.F2 Then
            mod_LLAMAR_FORMULARIO_INSERTAR.pro_Llamar_formulario_frm_TIPORESU()
        End If
    End Sub
    Private Sub cboRESOCLSE_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboRESOCLSE.KeyDown
        If e.KeyCode = Keys.F2 Then
            mod_LLAMAR_FORMULARIO_INSERTAR.pro_Llamar_formulario_frm_CLASSECT()
        End If
    End Sub
    Private Sub cboRESOVIGE_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboRESOVIGE.KeyDown
        If e.KeyCode = Keys.F2 Then
            mod_LLAMAR_FORMULARIO_INSERTAR.pro_Llamar_formulario_frm_VIGENCIA()
        End If
    End Sub

#End Region

#Region "KeyPress"

    Private Sub txt_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboRESODEPA.KeyPress, cboRESOMUNI.KeyPress, cboRESOTIRE.KeyPress, cboRESOCLSE.KeyPress, cboRESOVIGE.KeyPress, txtRESOCODI.KeyPress, txtRESODESC.KeyPress, cboRESOESTA.KeyPress, chkRESOPATO.KeyPress, txtRESOCONT.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Or e.KeyChar = Convert.ToChar(Keys.Tab) Then
            pp_pro_SaltarCampo()
        End If
    End Sub

#End Region

#Region "GotFocus"

    Private Sub cbo_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboRESODEPA.GotFocus, cboRESOMUNI.GotFocus, cboRESOTIRE.GotFocus, cboRESOCLSE.GotFocus, cboRESOVIGE.GotFocus, cboRESOESTA.GotFocus
        pp_pro_DescripcionCampo(Me.strBARRESTA.Items(0), sender)
    End Sub
    Private Sub txt_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtRESOCODI.GotFocus, txtRESODESC.GotFocus, txtRESOCONT.GotFocus
        pp_pro_SobrearCampo(sender)
        pp_pro_DescripcionCampo(Me.strBARRESTA.Items(0), sender)
    End Sub
    Private Sub chk_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkRESOPATO.GotFocus
        pp_pro_DescripcionCampo(Me.strBARRESTA.Items(0), sender)
    End Sub
    Private Sub cmdGUARDAR_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdGUARDAR.GotFocus, cmdSALIR.GotFocus
        pp_pro_DescripcionCampo(Me.strBARRESTA.Items(0), sender)
    End Sub

#End Region

#Region "SelectedIndexChanged"

    Private Sub cboRESODEPA_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboRESODEPA.SelectedIndexChanged
        Me.lblRESODEPA.Text = CType(fun_Buscar_Lista_Valores_DEPARTAMENTO_Codigo(Me.cboRESODEPA), String)

        Me.cboRESOMUNI.DataSource = New DataTable
        Me.lblRESOMUNI.Text = ""

        'Buscar el municipio del departamento seleccionado además la descripción del municipio.
        'Call cboRESOMUNI_Click(cboRESOMUNI, New System.EventArgs)
        'Call cboRESOMUNI_SelectedIndexChanged(cboRESOMUNI, New System.EventArgs)
    End Sub
    Private Sub cboRESOMUNI_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboRESOMUNI.SelectedIndexChanged
        Me.lblRESOMUNI.Text = CType(fun_Buscar_Lista_Valores_MUNICIPIO_Codigo(Me.cboRESODEPA, Me.cboRESOMUNI), String)
    End Sub
    Private Sub cboRESOTIRE_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboRESOTIRE.SelectedIndexChanged
        Me.lblRESOTIRE.Text = CType(fun_Buscar_Lista_Valores_TIPORESO_Codigo(Me.cboRESOTIRE), String)
    End Sub
    Private Sub cboRESOCLSE_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboRESOCLSE.SelectedIndexChanged
        Me.lblRESOCLSE.Text = CType(fun_Buscar_Lista_Valores_CLASSECT_Codigo(Me.cboRESOCLSE), String)
    End Sub
    Private Sub cboRESOVIGE_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboRESOVIGE.SelectedIndexChanged
        Me.lblRESOVIGE.Text = CType(fun_Buscar_Lista_Valores_VIGENCIA_Codigo(Me.cboRESOVIGE), String)
    End Sub

#End Region

#Region "Click"

    Private Sub cboRESODEPA_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboRESODEPA.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_DEPARTAMENTO_Descripcion(cboRESODEPA, cboRESODEPA.SelectedIndex)
    End Sub
    Private Sub cboRESOMUNI_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboRESOMUNI.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_MUNICIPIO_X_DEPARTAMENTO_Descripcion(Me.cboRESOMUNI, Me.cboRESOMUNI.SelectedIndex, Me.cboRESODEPA)
    End Sub
    Private Sub cboRESOTIRE_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboRESOTIRE.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_TIPORESO_Descripcion(cboRESOTIRE, cboRESOTIRE.SelectedIndex)
    End Sub
    Private Sub cboRESOCLSE_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboRESOCLSE.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_CLASSECT_Descripcion(cboRESOCLSE, cboRESOCLSE.SelectedIndex)
    End Sub
    Private Sub cboRESOVIGE_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboRESOVIGE.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_VIGENCIA_Descripcion(cboRESOVIGE, cboRESOVIGE.SelectedIndex)
    End Sub
    Private Sub cboRESOESTA_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboRESOESTA.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_ESTADO(Me.cboRESOESTA, Me.cboRESOESTA.SelectedIndex)
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