Imports REGLAS_DEL_NEGOCIO

Public Class frm_insertar_LIRADEDI

    '=============================================
    '*** LIBRO RADICADOR DESTINATARIO DIVISION ***
    '=============================================

#Region "VARIABLE"

    Dim inLRDDIDRE As Integer
    Dim inLRDDSECU As Integer
    Dim inLRDDNURA As Integer
    Dim stLRDDFERA As String

    Dim boINSERTAR As Boolean = False
    Dim boMODIFICAR As Boolean = False

#End Region

#Region "CONSTRUCTOR"

    Public Sub New(ByVal inIDRE As Integer, ByVal inSECU As Integer, ByVal inNURA As Integer, ByVal stFERA As String)
        inLRDDIDRE = inIDRE
        inLRDDSECU = inSECU
        inLRDDNURA = inNURA
        stLRDDFERA = stFERA

        boMODIFICAR = True

        InitializeComponent()
        pro_LimpiarCampos()
        pro_inicializarControles()

    End Sub
    Public Sub New(ByVal inSECU As Integer, ByVal inNURA As Integer, ByVal stFERA As String)
        inLRDDSECU = inSECU
        inLRDDNURA = inNURA
        stLRDDFERA = stFERA

        boINSERTAR = True

        InitializeComponent()
        pro_LimpiarCampos()
        pro_inicializarControles()
    End Sub

#End Region

#Region "PROCEDIMIENTOS"

    Private Sub pro_LimpiarCampos()

        Me.cboLRDDDIVI.DataSource = New DataTable

        Me.lblLRDDDIVI.Text = ""
        Me.txtLRDDFEAS.Text = ""
        Me.txtLRDDNRDE.Text = "0"
        Me.txtLRDDFEDE.Text = ""
        Me.lblLRDDDIVI.Text = ""

    End Sub
    Private Sub pro_inicializarControles()

        Try

            If boMODIFICAR = True Then

                ' instancia la clase
                Dim objdatos As New cla_LIRADEDI
                Dim tbl As New DataTable

                tbl = objdatos.fun_Buscar_ID_LIRADEDI(inLRDDIDRE)

                If tbl.Rows.Count > 0 Then

                    Me.Text = "Modificar registro"
                    Me.fraRECLTRCA.Text = "MODIFICAR DESTINATARIO DIVISIÓN"

                    Dim objdatos1 As New cla_DIVISION

                    Me.cboLRDDDIVI.DataSource = objdatos1.fun_Consultar_CAMPOS_MANT_DIVISION
                    Me.cboLRDDDIVI.DisplayMember = "DIVIDESC"
                    Me.cboLRDDDIVI.ValueMember = "DIVICODI"

                    Me.cboLRDDDIVI.SelectedValue = tbl.Rows(0).Item("LRDDDIVI")

                    Me.txtLRDDFEAS.Text = Trim(tbl.Rows(0).Item("LRDDFEAS"))
                    Me.txtLRDDNRDE.Text = Trim(tbl.Rows(0).Item("LRDDNRDE"))
                    Me.txtLRDDFEDE.Text = Trim(tbl.Rows(0).Item("LRDDFEDE"))

                    Me.lblLRDDDIVI.Text = CType(fun_Buscar_Lista_Valores_DIVISION_Codigo(Me.cboLRDDDIVI), String)

                    Me.cboLRDDDIVI.Enabled = False

                End If

            ElseIf boINSERTAR = True Then

                Me.Text = "Insertar registro"
                Me.fraRECLTRCA.Text = "INSERTAR DESTINATARIO DIVISIÓN"

                Me.txtLRDDFEAS.Text = fun_fecha()
                Me.txtLRDDNRDE.Text = inLRDDNURA
                Me.txtLRDDFEDE.Text = stLRDDFERA

            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub

#End Region

#Region "MENU"

    Private Sub cmdGUARDAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGUARDAR.Click

        Try
            ' inserta el registro
            If boINSERTAR = True Then

                ' instancia la clase
                Dim objdatos1 As New cla_LIRADEDI

                Dim boLLAVEPRIMARIA As Boolean = objdatos1.fun_Verifica_llave_Primaria_LIRADEDI(inLRDDNURA, Trim(stLRDDFERA), inLRDDSECU, Me.cboLRDDDIVI, Me.txtLRDDFEAS)

                ' instancia la clase
                Dim objVerifica As New cla_Verificar_Dato

                Dim boLRDDDIVI As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboLRDDDIVI)
                Dim boLRDDNRDE As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Numerico(Me.txtLRDDNRDE)
                Dim boLRDDFEAS As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Fecha(Me.txtLRDDFEAS)

                ' verifica los datos del formulario 
                If boLLAVEPRIMARIA = True And _
                   boLRDDDIVI = True And _
                   boLRDDNRDE = True And _
                   boLRDDFEAS = True Then

                    Dim objdatos22 As New cla_LIRADEDI

                    If (objdatos22.fun_Insertar_LIRADEDI(inLRDDNURA, _
                                                         stLRDDFERA, _
                                                         inLRDDSECU, _
                                                         Me.cboLRDDDIVI.SelectedValue, _
                                                         Me.txtLRDDFEAS.Text, _
                                                         vp_cedula, _
                                                         vp_usuario, _
                                                         Me.txtLRDDNRDE.Text, _
                                                         Me.txtLRDDFEDE.Text)) = True Then

                        mod_MENSAJE.Se_Guardaron_Los_Datos_Correctamente()
                        Me.cboLRDDDIVI.Focus()
                        Me.Close()
                    Else
                        mod_MENSAJE.No_Se_Guardo_El_Registro_En_La_Base_De_Datos()
                    End If

                End If

                ' modifica el registro
            ElseIf boMODIFICAR = True Then

                ' instancia la clase
                Dim objVerifica As New cla_Verificar_Dato

                Dim boLEVANUDO As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.lblLRDDDIVI)
                Dim boLRDDNRDE As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Numerico(Me.txtLRDDNRDE)
                Dim boLEVAFEEN As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Fecha(Me.txtLRDDFEAS)

                ' verifica los datos del formulario 
                If boLEVANUDO = True And _
                   boLRDDNRDE = True And _
                   boLEVAFEEN = True Then

                    Dim objdatos22 As New cla_LIRADEDI

                    If (objdatos22.fun_Actualizar_LIRADEDI(inLRDDIDRE, _
                                                           inLRDDNURA, _
                                                           stLRDDFERA, _
                                                           inLRDDSECU, _
                                                           Me.cboLRDDDIVI.SelectedValue, _
                                                           Me.txtLRDDFEAS.Text, _
                                                           Me.txtLRDDNRDE.Text, _
                                                           Me.txtLRDDFEDE.Text)) = True Then

                        mod_MENSAJE.Se_Guardaron_Los_Datos_Correctamente()
                        Me.cboLRDDDIVI.Focus()
                        Me.Close()
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
        Me.cboLRDDDIVI.Focus()
        Me.Close()
    End Sub

#End Region

#Region "FORMULARIO"

#Region "KeyPress"

    Private Sub txt_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboLRDDDIVI.KeyPress, txtLRDDFEAS.KeyPress, txtLRDDNRDE.KeyPress, txtLRDDFEDE.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Or e.KeyChar = Convert.ToChar(Keys.Tab) Then
            pp_pro_SaltarCampo()
        End If
    End Sub

#End Region

#Region "GotFocus"

    Private Sub txt_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtLRDDFEAS.GotFocus, txtLRDDNRDE.GotFocus
        pp_pro_SobrearCampo(sender)
        pp_pro_DescripcionCampo(Me.strBARRESTA.Items(0), sender)
    End Sub
    Private Sub cbo_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboLRDDDIVI.GotFocus
        pp_pro_DescripcionCampo(Me.strBARRESTA.Items(0), sender)
    End Sub
    Private Sub cmd_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdGUARDAR.GotFocus, cmdSALIR.GotFocus
        pp_pro_DescripcionCampo(Me.strBARRESTA.Items(0), sender)
    End Sub

#End Region

#Region "KeyDown"

    Private Sub cboLRDDDIVI_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboLRDDDIVI.KeyDown
        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
            fun_Cargar_ComboBox_Con_Datos_Activos_DIVISION_Descripcion(Me.cboLRDDDIVI, Me.cboLRDDDIVI.SelectedIndex)
        End If
    End Sub

#End Region

#Region "SelectedIndexChanged"

    Private Sub cboLEVANUDO_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboLRDDDIVI.SelectedIndexChanged
        Me.lblLRDDDIVI.Text = CType(fun_Buscar_Lista_Valores_DIVISION_Codigo(Me.cboLRDDDIVI), String)
    End Sub

#End Region

#Region "Click"

    Private Sub cboLRDDDIVI_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboLRDDDIVI.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_DIVISION_Descripcion(Me.cboLRDDDIVI, Me.cboLRDDDIVI.SelectedIndex)
    End Sub

#End Region

#Region "ValueChanged"

    Private Sub dtpLRDDFEDE_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpLRDDFEDE.ValueChanged
        Me.txtLRDDFEDE.Text = Me.dtpLRDDFEDE.Value
    End Sub

#End Region

#Region "Validated"

    Private Sub txtLRDDNRDE_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtLRDDNRDE.Validated

        If Trim(sender.text) = "" Then
            sender.text = 0
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