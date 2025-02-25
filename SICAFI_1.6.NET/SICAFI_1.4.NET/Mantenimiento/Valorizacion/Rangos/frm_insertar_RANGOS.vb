Imports REGLAS_DEL_NEGOCIO

Public Class frm_insertar_RANGOS

    '=======================
    '*** INSERTAR RANGOS ***
    '=======================

#Region "VARIABLE"

    Dim inID_REGISTRO As Integer = 0

    Dim vl_stRANGDEPA As String = ""
    Dim vl_stRANGMUNI As String = ""
    Dim vl_inRANGCLSE As Integer = 0
    Dim vl_inRANGPROY As Integer = 0
    Dim vl_inRANGTIVA As Integer = 0
    Dim vl_inRANGVARI As Integer = 0

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

            Me.cboRANGDEPA.DataSource = objdatos1.fun_Consultar_CAMPOS_MANT_DEPARTAMENTO
            Me.cboRANGDEPA.DisplayMember = "DEPADESC"
            Me.cboRANGDEPA.ValueMember = "DEPACODI"

            Me.cboRANGDEPA.SelectedValue = Trim(tbl.Rows(0).Item("FAPRDEPA"))

            Dim objdatos7 As New cla_MUNICIPIO

            Me.cboRANGMUNI.DataSource = objdatos7.fun_Consultar_CAMPOS_MANT_MUNICIPIO
            Me.cboRANGMUNI.DisplayMember = "MUNIDESC"
            Me.cboRANGMUNI.ValueMember = "MUNICODI"

            Me.cboRANGMUNI.SelectedValue = tbl.Rows(0).Item("FAPRMUNI")

            Dim objdatos2 As New cla_CLASSECT

            Me.cboRANGCLSE.DataSource = objdatos2.fun_Consultar_CAMPOS_MANT_CLASSECT
            Me.cboRANGCLSE.DisplayMember = "CLSEDESC"
            Me.cboRANGCLSE.ValueMember = "CLSECODI"

            Me.cboRANGCLSE.SelectedValue = tbl.Rows(0).Item("FAPRCLSE")

            Dim objdatos29 As New cla_PROYECTO

            Me.cboRANGPROY.DataSource = objdatos29.fun_Consultar_CAMPOS_PROYECTO
            Me.cboRANGPROY.DisplayMember = "PROYDESC"
            Me.cboRANGPROY.ValueMember = "PROYCODI"

            Me.cboRANGPROY.SelectedValue = tbl.Rows(0).Item("FAPRPROY")

            Dim objdatos28 As New cla_TIPOVARI

            Me.cboRANGTIVA.DataSource = objdatos28.fun_Consultar_CAMPOS_MANT_TIPOVARI
            Me.cboRANGTIVA.DisplayMember = "TIVADESC"
            Me.cboRANGTIVA.ValueMember = "TIVACODI"

            Me.cboRANGTIVA.SelectedValue = tbl.Rows(0).Item("FAPRTIVA")

            Dim objdatos77 As New cla_VARIABLE

            Me.cboRANGVARI.DataSource = objdatos77.fun_Consultar_CAMPOS_MANT_VARIABLE
            Me.cboRANGVARI.DisplayMember = "VARIDESC"
            Me.cboRANGVARI.ValueMember = "VARICODI"

            Me.cboRANGVARI.SelectedValue = tbl.Rows(0).Item("FAPRVARI")

            'Me.txtRANGDESC.Text = Trim(tbl.Rows(0).Item("FAPRDESC"))
            'Me.txtRANGFAIN.Text = Trim(tbl.Rows(0).Item("FAPRFAIN"))
            'Me.txtRANGFAFI.Text = Trim(tbl.Rows(0).Item("FAPRFAFI"))
            'Me.txtRANGFAAP.Text = Trim(tbl.Rows(0).Item("FAPRFAAP"))

            'Dim objdatos As New cla_ESTADO

            'Me.cboRANGESTA.DataSource = objdatos.fun_Consultar_TODOS_LOS_ESTADOS
            'Me.cboRANGESTA.DisplayMember = "ESTADESC"
            'Me.cboRANGESTA.ValueMember = "ESTACODI"

            'Me.cboRANGESTA.SelectedValue = tbl.Rows(0).Item("FAPRESTA")

            Dim boFACTDEPA As Boolean = fun_Buscar_Dato_DEPARTAMENTO(Me.cboRANGDEPA.SelectedValue)
            Dim boFACTMUNI As Boolean = fun_Buscar_Dato_MUNICIPIO(Me.cboRANGDEPA.SelectedValue, Me.cboRANGMUNI.SelectedValue)
            Dim boFACTCLSE As Boolean = fun_Buscar_Dato_CLASSECT(Me.cboRANGCLSE.SelectedValue)
            Dim boFACTPROY As Boolean = fun_Buscar_Dato_PROYECTO(Me.cboRANGDEPA.SelectedValue, Me.cboRANGMUNI.SelectedValue, Me.cboRANGCLSE.SelectedValue, Me.cboRANGPROY.SelectedValue)
            Dim boFACTTIVA As Boolean = fun_Buscar_Dato_TIPOVARI(Me.cboRANGTIVA.SelectedValue)
            Dim boFACTVARI As Boolean = fun_Buscar_Dato_VARIABLE(Me.cboRANGTIVA.SelectedValue, Me.cboRANGVARI.SelectedValue)

            If boFACTDEPA = True And _
                boFACTMUNI = True And _
                boFACTCLSE = True And _
                boFACTPROY = True And _
                boFACTTIVA = True And _
                boFACTVARI = True Then

                Me.lblRANGDEPA.Text = CType(fun_Buscar_Lista_Valores_DEPARTAMENTO_Codigo(Me.cboRANGDEPA), String)
                Me.lblRANGMUNI.Text = CType(fun_Buscar_Lista_Valores_MUNICIPIO_Codigo(Me.cboRANGDEPA, Me.cboRANGMUNI), String)
                Me.lblRANGCLSE.Text = CType(fun_Buscar_Lista_Valores_CLASSECT_Codigo(Me.cboRANGCLSE), String)
                Me.lblRANGPROY.Text = CType(fun_Buscar_Lista_Valores_PROYECTO_Codigo(Me.cboRANGDEPA, Me.cboRANGMUNI, Me.cboRANGCLSE, Me.cboRANGPROY), String)
                Me.lblRANGTIVA.Text = CType(fun_Buscar_Lista_Valores_TIPOVARI_Codigo(Me.cboRANGTIVA), String)
                Me.lblRANGVARI.Text = CType(fun_Buscar_Lista_Valores_VARIABLE_Codigo(Me.cboRANGTIVA, Me.cboRANGVARI), String)
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
            Me.txtRANGRAIN.Text = fun_Quita_Letras(Me.txtRANGRAIN.Text)
            Me.txtRANGRAFI.Text = fun_Quita_Letras(Me.txtRANGRAFI.Text)

            ' instancia la clase
            Dim objdatos1111 As New cla_RANGOS

            Dim boLLAVEPRIMARIA As Boolean = objdatos1111.fun_Verifica_llave_Primaria_MANT_RANGOS(Me.cboRANGDEPA, _
                                                                                                  Me.cboRANGMUNI, _
                                                                                                  Me.cboRANGCLSE, _
                                                                                                  Me.cboRANGPROY, _
                                                                                                  Me.cboRANGTIVA, _
                                                                                                  Me.cboRANGVARI, _
                                                                                                  Me.txtRANGRAIN, _
                                                                                                  Me.txtRANGRAFI)
            Dim objVerifica As New cla_Verificar_Dato

            Dim boFACTDEPA As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboRANGDEPA)
            Dim boFACTMUNI As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboRANGMUNI)
            Dim boFACTPROY As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboRANGPROY)
            Dim boFACTTIVA As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboRANGTIVA)
            Dim boCONCVARI As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboRANGVARI)
            Dim boFACTFAIN As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Decimal(Me.txtRANGFAIN)
            Dim boFACTFAFI As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Decimal(Me.txtRANGFAFI)
            Dim boFACTFAAP As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Decimal(Me.txtRANGFAAP)
            Dim boFACTRAIN As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Numerico(Me.txtRANGRAIN)
            Dim boFACTRAFI As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Numerico(Me.txtRANGRAFI)
            Dim boCONCESTA As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboRANGESTA)

            ' verifica los datos del formulario 
            If boLLAVEPRIMARIA = True And _
               boFACTDEPA = True And _
               boFACTMUNI = True And _
               boFACTPROY = True And _
               boFACTTIVA = True And _
               boCONCVARI = True And _
               boFACTFAIN = True And _
               boFACTFAFI = True And _
               boFACTFAAP = True And _
               boFACTRAIN = True And _
               boFACTRAFI = True And _
               boCONCESTA = True Then

                Dim objdatos As New cla_RANGOS

                If objdatos.fun_Insertar_MANT_RANGOS(Me.cboRANGDEPA.SelectedValue, _
                                                     Me.cboRANGMUNI.SelectedValue, _
                                                     Me.cboRANGCLSE.SelectedValue, _
                                                     Me.cboRANGPROY.SelectedValue, _
                                                     Me.cboRANGTIVA.SelectedValue, _
                                                     Me.cboRANGVARI.SelectedValue, _
                                                     Me.txtRANGRAIN.Text, _
                                                     Me.txtRANGRAFI.Text, _
                                                     Me.txtRANGFAIN.Text, _
                                                     Me.txtRANGFAFI.Text, _
                                                     Me.txtRANGFAAP.Text, _
                                                     Me.cboRANGESTA.SelectedValue) = True Then
                    Me.txtRANGFAIN.Focus()
                    Me.Close()

                    mod_MENSAJE.Se_Guardaron_Los_Datos_Correctamente()
                Else
                    mod_MENSAJE.No_Se_Modifico_El_Registro_En_La_Base_De_Datos()
                End If
            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub cmdCANCELAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSALIR.Click
        Me.txtRANGFAIN.Focus()
        Me.Close()
    End Sub

#End Region

#Region "FORMULARIO"

#Region "KeyDown"

    Private Sub cboCONCESTA_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboRANGESTA.KeyDown
        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
            fun_Cargar_ComboBox_Con_Datos_Activos_ESTADO(Me.cboRANGESTA, Me.cboRANGESTA.SelectedIndex)
        End If
    End Sub

#End Region

#Region "KeyPress"

    Private Sub txt_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboRANGESTA.KeyPress, cboRANGTIVA.KeyPress, txtRANGFAIN.KeyPress, txtRANGFAFI.KeyPress, txtRANGFAAP.KeyPress, cboRANGPROY.KeyPress, txtRANGRAIN.KeyPress, txtRANGRAFI.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Or e.KeyChar = Convert.ToChar(Keys.Tab) Then
            pp_pro_SaltarCampo()
        End If
    End Sub

#End Region

#Region "GotFocus"

    Private Sub txt_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtRANGFAAP.GotFocus, txtRANGFAFI.GotFocus, txtRANGFAIN.GotFocus, txtRANGRAFI.GotFocus, txtRANGRAIN.GotFocus
        pp_pro_SobrearCampo(sender)
        pp_pro_DescripcionCampo(Me.strBARRESTA.Items(0), sender)
    End Sub
    Private Sub cmd_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdGUARDAR.GotFocus, cmdSALIR.GotFocus
        pp_pro_DescripcionCampo(Me.strBARRESTA.Items(0), sender)
    End Sub
    Private Sub cbo_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboRANGESTA.GotFocus, cboRANGTIVA.GotFocus, cboRANGPROY.GotFocus
        pp_pro_DescripcionCampo(Me.strBARRESTA.Items(0), sender)
    End Sub

#End Region

#Region "Click"

    Private Sub cboFACTESTA_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboRANGESTA.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_ESTADO(cboRANGESTA, cboRANGESTA.SelectedIndex)
    End Sub

#End Region

#Region "Validated"

    Private Sub txtFACTFAIN_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtRANGFAIN.Validated, txtRANGFAFI.Validated, txtRANGFAAP.Validated

        If Trim(sender.text) = "" Then
            sender.text = "0.0000"
        Else
            If fun_Verificar_Dato_Decimal_Evento_Validated(Me.txtRANGFAIN.Text) = True Then
                Me.txtRANGFAIN.Text = fun_Formato_Decimal_4_Decimales(Me.txtRANGFAIN.Text)
            End If

            If fun_Verificar_Dato_Decimal_Evento_Validated(Me.txtRANGFAFI.Text) = True Then
                Me.txtRANGFAFI.Text = fun_Formato_Decimal_4_Decimales(Me.txtRANGFAFI.Text)
            End If

            If fun_Verificar_Dato_Decimal_Evento_Validated(Me.txtRANGFAAP.Text) = True Then
                Me.txtRANGFAAP.Text = fun_Formato_Decimal_4_Decimales(Me.txtRANGFAAP.Text)
            End If

        End If

    End Sub
    Private Sub txtRANGRAIN_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtRANGRAFI.Validated, txtRANGRAIN.Validated

        If Trim(sender.text) = "" Then
            sender.text = "0"
        Else
            If fun_Verificar_Dato_Decimal_Evento_Validated(Me.txtRANGRAFI.Text) = True Then
                Me.txtRANGRAFI.Text = fun_Formato_Mascara_Pesos_Enteros(Me.txtRANGRAFI.Text)
            End If

            If fun_Verificar_Dato_Decimal_Evento_Validated(Me.txtRANGRAIN.Text) = True Then
                Me.txtRANGRAIN.Text = fun_Formato_Mascara_Pesos_Enteros(Me.txtRANGRAIN.Text)
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