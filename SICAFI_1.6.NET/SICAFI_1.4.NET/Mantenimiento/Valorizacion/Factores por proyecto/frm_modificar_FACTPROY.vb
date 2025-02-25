Imports REGLAS_DEL_NEGOCIO

Public Class frm_modificar_FACTPROY

    '==========================
    '*** MODIFICAR FACTORES ***
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

            Dim objdatos11 As New cla_FACTPROY
            Dim tbl As New DataTable

            tbl = objdatos11.fun_Buscar_ID_MANT_FACTPROY(inID_REGISTRO)

            Dim objdatos1 As New cla_DEPARTAMENTO

            Me.cboFAPRDEPA.DataSource = objdatos1.fun_Consultar_CAMPOS_MANT_DEPARTAMENTO
            Me.cboFAPRDEPA.DisplayMember = "DEPADESC"
            Me.cboFAPRDEPA.ValueMember = "DEPACODI"

            Me.cboFAPRDEPA.SelectedValue = Trim(tbl.Rows(0).Item("FAPRDEPA"))

            Dim objdatos7 As New cla_MUNICIPIO

            Me.cboFAPRMUNI.DataSource = objdatos7.fun_Consultar_CAMPOS_MANT_MUNICIPIO
            Me.cboFAPRMUNI.DisplayMember = "MUNIDESC"
            Me.cboFAPRMUNI.ValueMember = "MUNICODI"

            Me.cboFAPRMUNI.SelectedValue = tbl.Rows(0).Item("FAPRMUNI")

            Dim objdatos2 As New cla_CLASSECT

            Me.cboFAPRCLSE.DataSource = objdatos2.fun_Consultar_CAMPOS_MANT_CLASSECT
            Me.cboFAPRCLSE.DisplayMember = "CLSEDESC"
            Me.cboFAPRCLSE.ValueMember = "CLSECODI"

            Me.cboFAPRCLSE.SelectedValue = tbl.Rows(0).Item("FAPRCLSE")

            Dim objdatos29 As New cla_PROYECTO

            Me.cboFAPRPROY.DataSource = objdatos29.fun_Consultar_CAMPOS_PROYECTO
            Me.cboFAPRPROY.DisplayMember = "PROYDESC"
            Me.cboFAPRPROY.ValueMember = "PROYCODI"

            Me.cboFAPRPROY.SelectedValue = tbl.Rows(0).Item("FAPRPROY")

            Dim objdatos28 As New cla_TIPOVARI

            Me.cboFAPRTIVA.DataSource = objdatos28.fun_Consultar_CAMPOS_MANT_TIPOVARI
            Me.cboFAPRTIVA.DisplayMember = "TIVADESC"
            Me.cboFAPRTIVA.ValueMember = "TIVACODI"

            Me.cboFAPRTIVA.SelectedValue = tbl.Rows(0).Item("FAPRTIVA")

            Dim objdatos77 As New cla_VARIABLE

            Me.cboFAPRVARI.DataSource = objdatos77.fun_Consultar_CAMPOS_MANT_VARIABLE
            Me.cboFAPRVARI.DisplayMember = "VARIDESC"
            Me.cboFAPRVARI.ValueMember = "VARICODI"

            Me.cboFAPRVARI.SelectedValue = tbl.Rows(0).Item("FAPRVARI")
            Me.txtFAPRDESC.Text = Trim(tbl.Rows(0).Item("FAPRDESC"))
            Me.txtFAPRFAIN.Text = Trim(tbl.Rows(0).Item("FAPRFAIN"))
            Me.txtFAPRFAFI.Text = Trim(tbl.Rows(0).Item("FAPRFAFI"))
            Me.txtFAPRFAAP.Text = Trim(tbl.Rows(0).Item("FAPRFAAP"))
            Me.chkFAPRAPRA.Checked = tbl.Rows(0).Item("FAPRAPRA")

            Dim objdatos As New cla_ESTADO

            Me.cboFAPRESTA.DataSource = objdatos.fun_Consultar_TODOS_LOS_ESTADOS
            Me.cboFAPRESTA.DisplayMember = "ESTADESC"
            Me.cboFAPRESTA.ValueMember = "ESTACODI"

            Me.cboFAPRESTA.SelectedValue = tbl.Rows(0).Item("FAPRESTA")

            Dim boFACTDEPA As Boolean = fun_Buscar_Dato_DEPARTAMENTO(Me.cboFAPRDEPA.SelectedValue)
            Dim boFACTMUNI As Boolean = fun_Buscar_Dato_MUNICIPIO(Me.cboFAPRDEPA.SelectedValue, Me.cboFAPRMUNI.SelectedValue)
            Dim boFACTCLSE As Boolean = fun_Buscar_Dato_CLASSECT(Me.cboFAPRCLSE.SelectedValue)
            Dim boFACTPROY As Boolean = fun_Buscar_Dato_PROYECTO(Me.cboFAPRDEPA.SelectedValue, Me.cboFAPRMUNI.SelectedValue, Me.cboFAPRCLSE.SelectedValue, Me.cboFAPRPROY.SelectedValue)
            Dim boFACTTIVA As Boolean = fun_Buscar_Dato_TIPOVARI(Me.cboFAPRTIVA.SelectedValue)
            Dim boFACTVARI As Boolean = fun_Buscar_Dato_VARIABLE(Me.cboFAPRTIVA.SelectedValue, Me.cboFAPRVARI.SelectedValue)

            If boFACTDEPA = True And _
                boFACTMUNI = True And _
                boFACTCLSE = True And _
                boFACTPROY = True And _
                boFACTTIVA = True And _
                boFACTVARI = True Then

                Me.lblFAPRDEPA.Text = CType(fun_Buscar_Lista_Valores_DEPARTAMENTO_Codigo(Me.cboFAPRDEPA), String)
                Me.lblFAPRMUNI.Text = CType(fun_Buscar_Lista_Valores_MUNICIPIO_Codigo(Me.cboFAPRDEPA, Me.cboFAPRMUNI), String)
                Me.lblFAPRCLSE.Text = CType(fun_Buscar_Lista_Valores_CLASSECT_Codigo(Me.cboFAPRCLSE), String)
                Me.lblFAPRPROY.Text = CType(fun_Buscar_Lista_Valores_PROYECTO_Codigo(Me.cboFAPRDEPA, Me.cboFAPRMUNI, Me.cboFAPRCLSE, Me.cboFAPRPROY), String)
                Me.lblFAPRTIVA.Text = CType(fun_Buscar_Lista_Valores_TIPOVARI_Codigo(Me.cboFAPRTIVA), String)
                Me.lblFAPRVARI.Text = CType(fun_Buscar_Lista_Valores_VARIABLE_Codigo(Me.cboFAPRTIVA, Me.cboFAPRVARI), String)
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

            Dim boFACTDEPA As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboFAPRDEPA)
            Dim boFACTMUNI As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboFAPRMUNI)
            Dim boFACTPROY As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboFAPRPROY)
            Dim boFACTTIVA As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboFAPRTIVA)
            Dim boCONCVARI As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboFAPRVARI)
            Dim boCONCDESC As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.txtFAPRDESC)
            Dim boFACTFAIN As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Decimal(Me.txtFAPRFAIN)
            Dim boFACTFAFI As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Decimal(Me.txtFAPRFAFI)
            Dim boFACTFAAP As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Decimal(Me.txtFAPRFAAP)
            Dim boCONCESTA As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboFAPRESTA)

            ' verifica los datos del formulario 
            If boFACTDEPA = True And _
               boFACTMUNI = True And _
               boFACTPROY = True And _
               boFACTTIVA = True And _
               boCONCVARI = True And _
               boCONCDESC = True And _
               boFACTFAIN = True And _
               boFACTFAFI = True And _
               boFACTFAAP = True And _
               boCONCESTA = True Then

                Dim objdatos As New cla_FACTPROY

                If objdatos.fun_Actualizar_MANT_FACTPROY(inID_REGISTRO, _
                                                         Me.cboFAPRDEPA.SelectedValue, _
                                                         Me.cboFAPRMUNI.SelectedValue, _
                                                         Me.cboFAPRCLSE.SelectedValue, _
                                                         Me.cboFAPRPROY.SelectedValue, _
                                                         Me.cboFAPRTIVA.SelectedValue, _
                                                         Me.cboFAPRVARI.SelectedValue, _
                                                         Me.txtFAPRDESC.Text, _
                                                         Me.txtFAPRFAIN.Text, _
                                                         Me.txtFAPRFAFI.Text, _
                                                         Me.txtFAPRFAAP.Text, _
                                                         Me.cboFAPRESTA.SelectedValue, _
                                                         Me.chkFAPRAPRA.Checked) = True Then
                    Me.txtFAPRDESC.Focus()
                    Me.Close()

                    mod_MENSAJE.Se_Modificaron_Los_Datos_Correctamente()
                Else
                    mod_MENSAJE.No_Se_Modifico_El_Registro_En_La_Base_De_Datos()
                End If
            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub cmdCANCELAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSALIR.Click
        Me.txtFAPRDESC.Focus()
        Me.Close()
    End Sub

#End Region

#Region "FORMULARIO"

#Region "KeyDown"

    Private Sub cboCONCESTA_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboFAPRESTA.KeyDown
        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
            fun_Cargar_ComboBox_Con_Datos_Activos_ESTADO(Me.cboFAPRESTA, Me.cboFAPRESTA.SelectedIndex)
        End If
    End Sub

#End Region

#Region "KeyPress"

    Private Sub txt_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFAPRDESC.KeyPress, cboFAPRESTA.KeyPress, cboFAPRTIVA.KeyPress, txtFAPRFAIN.KeyPress, txtFAPRFAFI.KeyPress, txtFAPRFAAP.KeyPress, cboFAPRPROY.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Or e.KeyChar = Convert.ToChar(Keys.Tab) Then
            pp_pro_SaltarCampo()
        End If
    End Sub

#End Region

#Region "GotFocus"

    Private Sub txt_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFAPRDESC.GotFocus
        pp_pro_SobrearCampo(sender)
        pp_pro_DescripcionCampo(Me.strBARRESTA.Items(0), sender)
    End Sub
    Private Sub cmd_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdGUARDAR.GotFocus, cmdSALIR.GotFocus
        pp_pro_DescripcionCampo(Me.strBARRESTA.Items(0), sender)
    End Sub
    Private Sub cbo_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboFAPRESTA.GotFocus, cboFAPRTIVA.GotFocus, cboFAPRPROY.GotFocus
        pp_pro_DescripcionCampo(Me.strBARRESTA.Items(0), sender)
    End Sub

#End Region

#Region "Click"

    Private Sub cboFACTESTA_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboFAPRESTA.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_ESTADO(cboFAPRESTA, cboFAPRESTA.SelectedIndex)
    End Sub

#End Region

#Region "Validated"

    Private Sub txtFACTFAIN_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFAPRFAIN.Validated, txtFAPRFAFI.Validated, txtFAPRFAAP.Validated

        If Trim(sender.text) = "" Then
            sender.text = "0.0000"
        Else
            If fun_Verificar_Dato_Decimal_Evento_Validated(Me.txtFAPRFAIN.Text) = True Then
                Me.txtFAPRFAIN.Text = fun_Formato_Decimal_4_Decimales(Me.txtFAPRFAIN.Text)
            End If

            If fun_Verificar_Dato_Decimal_Evento_Validated(Me.txtFAPRFAFI.Text) = True Then
                Me.txtFAPRFAFI.Text = fun_Formato_Decimal_4_Decimales(Me.txtFAPRFAFI.Text)
            End If

            If fun_Verificar_Dato_Decimal_Evento_Validated(Me.txtFAPRFAAP.Text) = True Then
                Me.txtFAPRFAAP.Text = fun_Formato_Decimal_4_Decimales(Me.txtFAPRFAAP.Text)
            End If

        End If

    End Sub

#End Region

#Region "CheckedChanged"

    Private Sub chkFACTAPRA_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkFAPRAPRA.CheckedChanged

        If Me.chkFAPRAPRA.Checked = True Then

            Me.txtFAPRFAIN.Text = "1.0000"
            Me.txtFAPRFAFI.Text = "1.0000"
            Me.txtFAPRFAAP.Text = "1.0000"

            Me.txtFAPRFAIN.Enabled = False
            Me.txtFAPRFAFI.Enabled = False
            Me.txtFAPRFAAP.Enabled = False

        ElseIf Me.chkFAPRAPRA.Checked = False Then

            Me.txtFAPRFAIN.Enabled = True
            Me.txtFAPRFAFI.Enabled = True
            Me.txtFAPRFAAP.Enabled = True

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