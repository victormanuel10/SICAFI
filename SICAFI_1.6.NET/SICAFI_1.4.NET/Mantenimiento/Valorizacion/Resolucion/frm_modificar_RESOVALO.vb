Imports REGLAS_DEL_NEGOCIO

Public Class frm_modificar_RESOVALO

    '============================================
    '*** MODIFICAR RESOLUCIÓN DE VALORIZACIÓN ***
    '============================================


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

        Dim objdatos16 As New cla_RESOVALO
        Dim tbl As New DataTable

        tbl = objdatos16.fun_Buscar_ID_RESOVALO(inID_REGISTRO)

        Dim objdatos1 As New cla_DEPARTAMENTO

        Me.cboREVADEPA.DataSource = objdatos1.fun_Consultar_CAMPOS_MANT_DEPARTAMENTO
        Me.cboREVADEPA.DisplayMember = "DEPADESC"
        Me.cboREVADEPA.ValueMember = "DEPACODI"

        Me.cboREVADEPA.SelectedValue = tbl.Rows(0).Item("REVADEPA")

        Dim objdatos7 As New cla_MUNICIPIO

        Me.cboREVAMUNI.DataSource = objdatos7.fun_Consultar_CAMPOS_MANT_MUNICIPIO
        Me.cboREVAMUNI.DisplayMember = "MUNIDESC"
        Me.cboREVAMUNI.ValueMember = "MUNICODI"

        Me.cboREVAMUNI.SelectedValue = tbl.Rows(0).Item("REVAMUNI")

        Dim objdatos2 As New cla_CLASSECT

        Me.cboREVACLSE.DataSource = objdatos2.fun_Consultar_CAMPOS_MANT_CLASSECT
        Me.cboREVACLSE.DisplayMember = "CLSEDESC"
        Me.cboREVACLSE.ValueMember = "CLSECODI"

        Me.cboREVACLSE.SelectedValue = tbl.Rows(0).Item("REVACLSE")

        Dim objdatos233 As New cla_VIGENCIA

        Me.cboREVAVIGE.DataSource = objdatos233.fun_Consultar_CAMPOS_VIGENCIA
        Me.cboREVAVIGE.DisplayMember = "VIGEDESC"
        Me.cboREVAVIGE.ValueMember = "VIGECODI"

        Me.cboREVAVIGE.SelectedValue = tbl.Rows(0).Item("REVAVIGE")

        Dim objdatos236 As New cla_PROYECTO

        Me.cboREVAPROY.DataSource = objdatos236.fun_Consultar_CAMPOS_PROYECTO
        Me.cboREVAPROY.DisplayMember = "PROYDESC"
        Me.cboREVAPROY.ValueMember = "PROYCODI"

        Me.cboREVAPROY.SelectedValue = tbl.Rows(0).Item("REVAPROY")

        Dim objdatos239 As New cla_TIPORESO

        Me.cboREVATIRE.DataSource = objdatos239.fun_Consultar_CAMPOS_MANT_TIPORESO
        Me.cboREVATIRE.DisplayMember = "TIREDESC"
        Me.cboREVATIRE.ValueMember = "TIRECODI"

        Me.cboREVATIRE.SelectedValue = tbl.Rows(0).Item("REVATIRE")

        Me.txtREVADECR.Text = Trim(tbl.Rows(0).Item("REVADECR").ToString)
        Me.txtREVADESC.Text = Trim(tbl.Rows(0).Item("REVADESC").ToString)
        Me.txtREVAFECH.Text = Trim(tbl.Rows(0).Item("REVAFECH").ToString)

        Dim objdatos As New cla_ESTADO

        Me.cboREVAESTA.DataSource = objdatos.fun_Consultar_TODOS_LOS_ESTADOS
        Me.cboREVAESTA.DisplayMember = "ESTADESC"
        Me.cboREVAESTA.ValueMember = "ESTACODI"

        Me.cboREVAESTA.SelectedValue = tbl.Rows(0).Item("REVAESTA").ToString

        Me.rbdREVARETO.Checked = tbl.Rows(0).Item("REVARETO")
        Me.rbdREVAREPA.Checked = tbl.Rows(0).Item("REVAREPA")



        Dim boREVADEPA As Boolean = fun_Buscar_Dato_DEPARTAMENTO(Me.cboREVADEPA.SelectedValue)
        Dim boREVAMUNI As Boolean = fun_Buscar_Dato_MUNICIPIO(Me.cboREVADEPA.SelectedValue, Me.cboREVAMUNI.SelectedValue)
        Dim boREVACLSE As Boolean = fun_Buscar_Dato_CLASSECT(Me.cboREVACLSE.SelectedValue)
        Dim boREVAVIGE As Boolean = fun_Buscar_Dato_VIGENCIA(Me.cboREVAVIGE.SelectedValue)
        Dim boREVAPROY As Boolean = fun_Buscar_Dato_PROYECTO(Me.cboREVADEPA.SelectedValue, Me.cboREVAMUNI.SelectedValue, Me.cboREVACLSE.SelectedValue, Me.cboREVAPROY.SelectedValue)
        Dim boREVATIRE As Boolean = fun_Buscar_Dato_TIPORESU(Me.cboREVATIRE.SelectedValue)

        If boREVADEPA = True OrElse _
           boREVAMUNI = True OrElse _
           boREVACLSE = True OrElse _
           boREVAVIGE = True OrElse _
           boREVAPROY = True OrElse _
           boREVATIRE = True Then

            Me.lblREVADEPA.Text = CType(fun_Buscar_Lista_Valores_DEPARTAMENTO_Codigo(Me.cboREVADEPA), String)
            Me.lblREVAMUNI.Text = CType(fun_Buscar_Lista_Valores_MUNICIPIO_Codigo(Me.cboREVADEPA, Me.cboREVAMUNI), String)
            Me.lblREVACLSE.Text = CType(fun_Buscar_Lista_Valores_CLASSECT_Codigo(Me.cboREVACLSE), String)
            Me.lblREVAVIGE.Text = CType(fun_Buscar_Lista_Valores_VIGENCIA_Codigo(Me.cboREVAVIGE), String)
            Me.lblREVAPROY.Text = CType(fun_Buscar_Lista_Valores_PROYECTO_Codigo(Me.cboREVADEPA, Me.cboREVAMUNI, Me.cboREVACLSE, Me.cboREVAPROY), String)
            Me.lblREVATIRE.Text = CType(fun_Buscar_Lista_Valores_TIPORESO_Codigo(Me.cboREVATIRE), String)

        Else
            frm_INCO_modifircar_registros_sin_listas_de_valores.ShowDialog()
        End If

    End Sub

#End Region

#Region "MENU"

    Private Sub cmdGUARDAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGUARDAR.Click
        Try

            Dim objVerifica As New cla_Verificar_Dato

            Dim boREVADEPA As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboREVADEPA)
            Dim boREVAMUNI As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboREVAMUNI)
            Dim boREVACLSE As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboREVACLSE)
            Dim boREVAVIGE As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboREVAVIGE)
            Dim boREVAPROY As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboREVAPROY)
            Dim boREVATIRE As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboREVATIRE)
            Dim boREVARESO As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Numerico(Me.txtREVADECR)
            Dim boREVADESC As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.txtREVADESC)
            Dim boREVAESTA As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboREVAESTA)
            Dim boREVAFECH As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Fecha(Me.txtREVAFECH)

            ' verifica los datos del formulario 
            If boREVADEPA = True And _
                boREVAMUNI = True And _
                boREVACLSE = True And _
                boREVAVIGE = True And _
                boREVAPROY = True And _
                boREVATIRE = True And _
                boREVARESO = True And _
                boREVADESC = True And _
                boREVAFECH = True And _
                boREVAESTA = True Then

                Dim objdatos As New cla_RESOVALO

                If objdatos.fun_Actualizar_RESOVALO(inID_REGISTRO, _
                                                    Me.cboREVADEPA.SelectedValue, _
                                                    Me.cboREVAMUNI.SelectedValue, _
                                                    Me.cboREVACLSE.SelectedValue, _
                                                    Me.cboREVAPROY.SelectedValue, _
                                                    Me.txtREVADECR.Text, _
                                                    Me.cboREVATIRE.SelectedValue, _
                                                    Me.cboREVAVIGE.SelectedValue, _
                                                    Me.txtREVADESC.Text, _
                                                    Me.cboREVAESTA.SelectedValue, _
                                                    Me.rbdREVARETO.Checked, _
                                                    Me.rbdREVAREPA.Checked, _
                                                    Me.txtREVAFECH.Text) = True Then
                    Me.txtREVADESC.Focus()
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
        Me.txtREVADESC.Focus()
        Me.Close()
    End Sub

#End Region

#Region "FORMULARIO"

#Region "KeyPress"

    Private Sub txt_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboREVADEPA.KeyPress, cboREVAMUNI.KeyPress, cboREVACLSE.KeyPress, txtREVADECR.KeyPress, txtREVADESC.KeyPress, cboREVAESTA.KeyPress, txtREVAFECH.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Or e.KeyChar = Convert.ToChar(Keys.Tab) Then
            pp_pro_SaltarCampo()
        End If
    End Sub

#End Region

#Region "KeyDown"

    Private Sub cboREVAESTA_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboREVAESTA.KeyDown
        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
            fun_Cargar_ComboBox_Con_Datos_Activos_ESTADO(Me.cboREVAESTA, Me.cboREVAESTA.SelectedIndex)
        End If
    End Sub

#End Region

#Region "GotFocus"

    Private Sub txt_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtREVADECR.GotFocus, txtREVADESC.GotFocus, txtREVAFECH.GotFocus
        pp_pro_SobrearCampo(sender)
        pp_pro_DescripcionCampo(Me.strBARRESTA.Items(0), sender)
    End Sub
    Private Sub cmd_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdGUARDAR.GotFocus, cmdSALIR.GotFocus
        pp_pro_DescripcionCampo(Me.strBARRESTA.Items(0), sender)
    End Sub
    Private Sub cbo_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboREVADEPA.GotFocus, cboREVAMUNI.GotFocus, cboREVACLSE.GotFocus, cboREVAESTA.GotFocus
        pp_pro_DescripcionCampo(Me.strBARRESTA.Items(0), sender)
    End Sub

#End Region

#Region "Click"

    Private Sub cboMOLIESTA_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboREVAESTA.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_ESTADO(cboREVAESTA, cboREVAESTA.SelectedIndex)
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