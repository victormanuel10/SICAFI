Imports REGLAS_DEL_NEGOCIO

Public Class frm_insertar_TARIZOFI

    '==========================================
    '*** INSERTAR TARIFAS POR ZONAS FÍSICAS ***
    '==========================================

#Region "VARIABLES"

    Dim vl_boSWVerificaDatoAlGuardar As Boolean = True

#End Region

#Region "PROCEDIMIENTOS"

    Private Sub pro_LimpiarCampos()

        Me.cboTAZFDEPA.DataSource = New DataTable
        Me.cboTAZFMUNI.DataSource = New DataTable
        Me.cboTAZFCLSE.DataSource = New DataTable
        Me.cboTAZFVIGE.DataSource = New DataTable
        Me.cboTAZFZOFI.DataSource = New DataTable
        Me.cboTAZFZOAP.DataSource = New DataTable

        Me.lblTAZFDEPA.Text = ""
        Me.lblTAZFMUNI.Text = ""
        Me.lblTAZFCLSE.Text = ""
        Me.lblTAZFVIGE.Text = ""
        Me.lblTAZFZOFI.Text = ""
        Me.lblTAZFZOAP.Text = ""

        Me.txtTAZFTA01.Text = "0.00"
        Me.txtTAZFTA02.Text = "0.00"
        Me.txtTAZFTA03.Text = "0.00"
        Me.txtTAZFTA04.Text = "0.00"
        Me.txtTAZFTA05.Text = "0.00"
        Me.txtTAZFTA06.Text = "0.00"
        Me.txtTAZFTALO.Text = "0.00"

        Me.strBARRESTA.Items(1).Text = ""

    End Sub
    Private Sub pro_LimpiarCamposInsertar()

        Me.cboTAZFZOFI.DataSource = New DataTable
        Me.cboTAZFZOAP.DataSource = New DataTable

        Me.lblTAZFZOFI.Text = ""
        Me.lblTAZFZOAP.Text = ""

        Me.txtTAZFTA01.Text = "0.00"
        Me.txtTAZFTA02.Text = "0.00"
        Me.txtTAZFTA03.Text = "0.00"
        Me.txtTAZFTA04.Text = "0.00"
        Me.txtTAZFTA05.Text = "0.00"
        Me.txtTAZFTA06.Text = "0.00"
        Me.txtTAZFTALO.Text = "0.00"

        Me.strBARRESTA.Items(1).Text = ""

    End Sub

#End Region

#Region "MENU"

    Private Sub cmdGUARDAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGUARDAR.Click

        Try
            ' instancia la clase
            Dim objdatos As New cla_TARIZOFI

            Dim boLLAVEPRIMARIA As Boolean = objdatos.fun_Verifica_llave_Primaria_TARIZOFI(Me.cboTAZFDEPA, _
                                                                                           Me.cboTAZFMUNI, _
                                                                                           Me.cboTAZFCLSE, _
                                                                                           Me.cboTAZFVIGE, _
                                                                                           Me.cboTAZFZOFI)
            ' instancia la clase
            Dim objVerifica As New cla_Verificar_Dato

            Dim boTAZFDEPA As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboTAZFDEPA)
            Dim boTAZFMUNI As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboTAZFMUNI)
            Dim boTAZFCLSE As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboTAZFCLSE)
            Dim boTAZFVIGE As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboTAZFVIGE)
            Dim boTAZFZOEC As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboTAZFZOFI)
            Dim boTAZFTA01 As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Decimal(Me.txtTAZFTA01)
            Dim boTAZFTA02 As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Decimal(Me.txtTAZFTA02)
            Dim boTAZFTA03 As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Decimal(Me.txtTAZFTA03)
            Dim boTAZFTA04 As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Decimal(Me.txtTAZFTA04)
            Dim boTAZFTA05 As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Decimal(Me.txtTAZFTA05)
            Dim boTAZFTA06 As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Decimal(Me.txtTAZFTA06)
            Dim boTAZFZOAP As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboTAZFZOAP)
            Dim boTAZFESTA As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboTAZFESTA)
            Dim boTAZFSIGN As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboTAZFSIGN)
            Dim boTAZFPORC As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Decimal(Me.txtTAZFPORC)
            Dim boTAZFTALO As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Decimal(Me.txtTAZFTALO)

            ' verifica los datos del formulario 
            If boLLAVEPRIMARIA = True And _
               boTAZFDEPA = True And _
               boTAZFMUNI = True And _
               boTAZFCLSE = True And _
               boTAZFVIGE = True And _
               boTAZFZOEC = True And _
               boTAZFTA01 = True And _
               boTAZFTA02 = True And _
               boTAZFTA03 = True And _
               boTAZFTA04 = True And _
               boTAZFTA05 = True And _
               boTAZFTA06 = True And _
               boTAZFZOAP = True And _
               boTAZFESTA = True And _
               boTAZFSIGN = True And _
               boTAZFPORC = True And _
               boTAZFTALO Then

                Dim objdatos22 As New cla_TARIZOFI

                If (objdatos22.fun_Insertar_TARIZOFI(Me.cboTAZFDEPA.SelectedValue, _
                                                     Me.cboTAZFMUNI.SelectedValue, _
                                                     Me.cboTAZFCLSE.SelectedValue, _
                                                     Me.cboTAZFZOFI.SelectedValue, _
                                                     Me.txtTAZFTA01.Text, _
                                                     Me.txtTAZFTA02.Text, _
                                                     Me.txtTAZFTA03.Text, _
                                                     Me.txtTAZFTA04.Text, _
                                                     Me.txtTAZFTA05.Text, _
                                                     Me.txtTAZFTA06.Text, _
                                                     Me.cboTAZFZOAP.SelectedValue, _
                                                     Me.cboTAZFESTA.SelectedValue, _
                                                     Me.cboTAZFVIGE.SelectedValue, _
                                                     Me.cboTAZFSIGN.Text, _
                                                     Me.txtTAZFPORC.Text, _
                                                     Me.txtTAZFTALO.Text)) = True Then

                    mod_MENSAJE.Se_Guardaron_Los_Datos_Correctamente()

                    If MessageBox.Show("¿ Desea agregar otro registro ?", "Mensaje...", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.No Then
                        Me.cboTAZFDEPA.Focus()
                        Me.Close()
                    Else
                        'pro_LimpiarCampos()
                        pro_LimpiarCamposInsertar()
                        Me.cboTAZFDEPA.Focus()
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
        Me.cboTAZFDEPA.Focus()
        Me.Close()
    End Sub

#End Region

#Region "FORMULARIO"

#Region "Load"

    Private Sub frm_insertar_ZONAECON_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        pro_LimpiarCampos()
        Me.cboTAZFDEPA.Focus()
    End Sub

#End Region

#Region "KeyPress"

    Private Sub txt_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboTAZFDEPA.KeyPress, cboTAZFMUNI.KeyPress, cboTAZFCLSE.KeyPress, cboTAZFVIGE.KeyPress, cboTAZFZOFI.KeyPress, cboTAZFZOAP.KeyPress, cboTAZFESTA.KeyPress, txtTAZFTA01.KeyPress, txtTAZFTA02.KeyPress, txtTAZFTA03.KeyPress, txtTAZFTA04.KeyPress, txtTAZFTA05.KeyPress, txtTAZFTA06.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Or e.KeyChar = Convert.ToChar(Keys.Tab) Then
            pp_pro_SaltarCampo()
        End If
    End Sub

#End Region

#Region "KeyDown"

    Private Sub cboTAZFDEPA_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboTAZFDEPA.KeyDown
        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
            fun_Cargar_ComboBox_Con_Datos_Activos_DEPARTAMENTO_Descripcion(Me.cboTAZFDEPA, Me.cboTAZFDEPA.SelectedIndex)
        End If
    End Sub
    Private Sub cboTAZFMUNI_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboTAZFMUNI.KeyDown
        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
            fun_Cargar_ComboBox_Con_Datos_Activos_MUNICIPIO_X_DEPARTAMENTO_Descripcion(Me.cboTAZFMUNI, Me.cboTAZFMUNI.SelectedIndex, Me.cboTAZFDEPA)
        End If
    End Sub
    Private Sub cboTAZFCLSE_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboTAZFCLSE.KeyDown
        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
            fun_Cargar_ComboBox_Con_Datos_Activos_CLASSECT_Descripcion(Me.cboTAZFCLSE, Me.cboTAZFCLSE.SelectedIndex)
        End If
    End Sub
    Private Sub cboTAZFVIGE_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboTAZFVIGE.KeyDown
        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
            fun_Cargar_ComboBox_Con_Datos_Activos_VIGENCIA_Descripcion(Me.cboTAZFVIGE, Me.cboTAZFVIGE.SelectedIndex)
        End If
    End Sub
    Private Sub cboTAZFZOEC_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboTAZFZOFI.KeyDown
        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
            fun_Cargar_ComboBox_Con_Datos_Activos_ZONAFISI_Descripcion(Me.cboTAZFZOFI, Me.cboTAZFZOFI.SelectedIndex, Me.cboTAZFDEPA, Me.cboTAZFMUNI, Me.cboTAZFCLSE)
        End If
    End Sub
    Private Sub cboTAZFZOAP_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboTAZFZOAP.KeyDown
        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
            fun_Cargar_ComboBox_Con_Datos_Activos_ZONAFISI_Descripcion(Me.cboTAZFZOAP, Me.cboTAZFZOAP.SelectedIndex, Me.cboTAZFDEPA, Me.cboTAZFMUNI, Me.cboTAZFCLSE)
        End If
    End Sub
    Private Sub cboTAZFESTA_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboTAZFESTA.KeyDown
        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
            fun_Cargar_ComboBox_Con_Datos_Activos_ESTADO(Me.cboTAZFESTA, Me.cboTAZFESTA.SelectedIndex)
        End If
    End Sub

#End Region

#Region "GotFocus"

    Private Sub txt_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtTAZFTA01.GotFocus, txtTAZFTA02.GotFocus, txtTAZFTA03.GotFocus, txtTAZFTA04.GotFocus, txtTAZFTA05.GotFocus, txtTAZFTA06.GotFocus
        pp_pro_SobrearCampo(sender)
        pp_pro_DescripcionCampo(Me.strBARRESTA.Items(0), sender)
    End Sub
    Private Sub cmd_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdGUARDAR.GotFocus, cmdSALIR.GotFocus
        pp_pro_DescripcionCampo(Me.strBARRESTA.Items(0), sender)
    End Sub
    Private Sub cbo_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboTAZFDEPA.GotFocus, cboTAZFMUNI.GotFocus, cboTAZFCLSE.GotFocus, cboTAZFVIGE.GotFocus, cboTAZFZOFI.GotFocus, cboTAZFZOAP.GotFocus, cboTAZFESTA.GotFocus
        pp_pro_DescripcionCampo(Me.strBARRESTA.Items(0), sender)
    End Sub

#End Region

#Region "SelectedIndexChanged"

    Private Sub cboTAZFDEPA_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboTAZFDEPA.SelectedIndexChanged
        Me.lblTAZFDEPA.Text = CType(fun_Buscar_Lista_Valores_DEPARTAMENTO_Codigo(Me.cboTAZFDEPA), String)

        Me.cboTAZFMUNI.DataSource = New DataTable
        Me.lblTAZFMUNI.Text = ""

        Me.cboTAZFZOFI.DataSource = New DataTable
        Me.lblTAZFZOFI.Text = ""

        Me.cboTAZFZOAP.DataSource = New DataTable
        Me.lblTAZFZOAP.Text = ""
    End Sub
    Private Sub cboTAZFMUNI_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboTAZFMUNI.SelectedIndexChanged
        Me.lblTAZFMUNI.Text = CType(fun_Buscar_Lista_Valores_MUNICIPIO_Codigo(Me.cboTAZFDEPA, Me.cboTAZFMUNI), String)
    End Sub
    Private Sub cboTAZFCLSE_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboTAZFCLSE.SelectedIndexChanged
        Me.lblTAZFCLSE.Text = CType(fun_Buscar_Lista_Valores_CLASSECT_Codigo(Me.cboTAZFCLSE), String)
    End Sub
    Private Sub cboTAZFVIGE_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboTAZFVIGE.SelectedIndexChanged
        Me.lblTAZFVIGE.Text = CType(fun_Buscar_Lista_Valores_VIGENCIA_Codigo(Me.cboTAZFVIGE), String)
    End Sub
    Private Sub cboTAZFZOEC_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboTAZFZOFI.SelectedIndexChanged
        Me.lblTAZFZOFI.Text = CType(fun_Buscar_Lista_Valores_ZONAFISI_Codigo(Me.cboTAZFDEPA, Me.cboTAZFMUNI, Me.cboTAZFCLSE, Me.cboTAZFZOFI), String)
    End Sub
    Private Sub cboTAZFZOAP_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboTAZFZOAP.SelectedIndexChanged
        Me.lblTAZFZOAP.Text = CType(fun_Buscar_Lista_Valores_ZONAFISI_Codigo(Me.cboTAZFDEPA, Me.cboTAZFMUNI, Me.cboTAZFCLSE, Me.cboTAZFZOAP), String)
    End Sub

#End Region

#Region "Click"

    Private Sub cboTAZFDEPA_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboTAZFDEPA.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_DEPARTAMENTO_Descripcion(Me.cboTAZFDEPA, Me.cboTAZFDEPA.SelectedIndex)
    End Sub
    Private Sub cboTAZFMUNI_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboTAZFMUNI.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_MUNICIPIO_X_DEPARTAMENTO_Descripcion(Me.cboTAZFMUNI, Me.cboTAZFMUNI.SelectedIndex, Me.cboTAZFDEPA)
    End Sub
    Private Sub cboTAZFCLSE_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboTAZFCLSE.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_CLASSECT_Descripcion(Me.cboTAZFCLSE, Me.cboTAZFCLSE.SelectedIndex)
    End Sub
    Private Sub cboTAZFVIGE_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboTAZFVIGE.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_VIGENCIA_Descripcion(Me.cboTAZFVIGE, Me.cboTAZFVIGE.SelectedIndex)
    End Sub
    Private Sub cboTAZFZOEC_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboTAZFZOFI.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_ZONAFISI_Descripcion(Me.cboTAZFZOFI, Me.cboTAZFZOFI.SelectedIndex, Me.cboTAZFDEPA, Me.cboTAZFMUNI, Me.cboTAZFCLSE)
    End Sub
    Private Sub cboTAZFZOAP_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboTAZFZOAP.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_ZONAFISI_Descripcion(Me.cboTAZFZOAP, Me.cboTAZFZOAP.SelectedIndex, Me.cboTAZFDEPA, Me.cboTAZFMUNI, Me.cboTAZFCLSE)
    End Sub
    Private Sub cboTAZFESTA_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboTAZFESTA.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_ESTADO(Me.cboTAZFESTA, Me.cboTAZFESTA.SelectedIndex)
    End Sub

#End Region

#Region "Validated"

    Private Sub txt_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtTAZFTA01.Validated, txtTAZFTA02.Validated, txtTAZFTA03.Validated, txtTAZFTA04.Validated, txtTAZFTA05.Validated, txtTAZFTA06.Validated, txtTAZFPORC.Validated

        If Trim(sender.text) = "" Then
            sender.text = "0.00"
        Else
            If fun_Verificar_Dato_Decimal_Evento_Validated(Me.txtTAZFTA01.Text) = True Then
                Me.txtTAZFTA01.Text = fun_Formato_Decimal_2_Decimales(Me.txtTAZFTA01.Text)
            End If

            If fun_Verificar_Dato_Decimal_Evento_Validated(Me.txtTAZFTA02.Text) = True Then
                Me.txtTAZFTA02.Text = fun_Formato_Decimal_2_Decimales(Me.txtTAZFTA02.Text)
            End If

            If fun_Verificar_Dato_Decimal_Evento_Validated(Me.txtTAZFTA03.Text) = True Then
                Me.txtTAZFTA03.Text = fun_Formato_Decimal_2_Decimales(Me.txtTAZFTA03.Text)
            End If

            If fun_Verificar_Dato_Decimal_Evento_Validated(Me.txtTAZFTA04.Text) = True Then
                Me.txtTAZFTA04.Text = fun_Formato_Decimal_2_Decimales(Me.txtTAZFTA04.Text)
            End If

            If fun_Verificar_Dato_Decimal_Evento_Validated(Me.txtTAZFTA05.Text) = True Then
                Me.txtTAZFTA05.Text = fun_Formato_Decimal_2_Decimales(Me.txtTAZFTA05.Text)
            End If

            If fun_Verificar_Dato_Decimal_Evento_Validated(Me.txtTAZFTA06.Text) = True Then
                Me.txtTAZFTA06.Text = fun_Formato_Decimal_2_Decimales(Me.txtTAZFTA06.Text)
            End If

            If fun_Verificar_Dato_Decimal_Evento_Validated(Me.txtTAZFPORC.Text) = True Then
                Me.txtTAZFPORC.Text = fun_Formato_Decimal_2_Decimales(Me.txtTAZFPORC.Text)
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