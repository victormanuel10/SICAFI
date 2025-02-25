Imports REGLAS_DEL_NEGOCIO

Public Class frm_insertar_OBURAVCO

    '===========================================================
    '*** INSERTAR AVALUO COMERCIAL OBLIGACIONES URBANISTICAS ***
    '===========================================================

#Region "VARIABLE"

    Dim inOUACIDRE As Integer
    Dim stOUACCLEN As String
    Dim inOUACNURE As Integer
    Dim stOUACFERE As String
    Dim inOUACSECU As Integer

    Dim boINSERTAR As Boolean = False
    Dim boMODIFICAR As Boolean = False

#End Region

#Region "CONSTRUCTOR"

    Public Sub New(ByVal inIDRE As Integer, ByVal inSECU As Integer, ByVal stCLEN As String, ByVal inNURE As Integer, ByVal stFERE As String)
        inOUACIDRE = inIDRE
        inOUACSECU = inSECU
        stOUACCLEN = stCLEN
        inOUACNURE = inNURE
        stOUACFERE = stFERE

        boMODIFICAR = True

        InitializeComponent()
        pro_LimpiarCampos()
        pro_inicializarControles()

    End Sub
    Public Sub New(ByVal inSECU As Integer, ByVal stCLEN As String, ByVal inNURE As Integer, ByVal stFERE As String)
        inOUACSECU = inSECU
        stOUACCLEN = stCLEN
        inOUACNURE = inNURE
        stOUACFERE = stFERE

        boINSERTAR = True

        InitializeComponent()
        pro_LimpiarCampos()
        pro_inicializarControles()
    End Sub

#End Region

#Region "PROCEDIMIENTOS"

    Private Sub pro_LimpiarCampos()

        Me.txtOUACNUAV.Text = ""
        Me.txtOUACEMPR.Text = ""
        Me.txtOUACFEVI.Text = ""
        Me.txtOUACFEIN.Text = ""
        Me.txtOUACSOLI.Text = ""
        Me.txtOUACPUNT.Text = ""
        Me.txtOUACPROY.Text = ""
        Me.txtOUACDIRE.Text = ""
        Me.txtOUACARTE.Text = "0"
        Me.txtOUACAVCO.Text = "0"
        Me.txtOUACACM2.Text = "0"

        Me.lblOUACVIAV.Text = ""

        Me.cboOUACVIAV.DataSource = New DataTable
        Me.cboOUACESTA.DataSource = New DataTable

    End Sub
    Private Sub pro_inicializarControles()

        Try
            If boMODIFICAR = True Then

                ' instancia la clase
                Dim objdatos As New cla_OBURAVCO
                Dim tbl As New DataTable

                tbl = objdatos.fun_Buscar_ID_OBURAVCO(inOUACIDRE)

                If tbl.Rows.Count > 0 Then

                    Me.Text = "Modificar registro"
                    Me.fraCEDUCATA.Text = "MODIFICAR AVALÚO COMERCIAL"

                    Me.txtOUACNUAV.Enabled = False
                    Me.cboOUACVIAV.Enabled = False

                    Me.txtOUACNUAV.Text = Trim(tbl.Rows(0).Item("OUACNUAV"))

                    Dim objdatos1 As New cla_VIGENCIA

                    Me.cboOUACVIAV.DataSource = objdatos1.fun_Consultar_CAMPOS_VIGENCIA
                    Me.cboOUACVIAV.DisplayMember = "VIGEDESC"
                    Me.cboOUACVIAV.ValueMember = "VIGECODI"

                    Me.cboOUACVIAV.SelectedValue = tbl.Rows(0).Item("OUACVIAV")

                    Me.txtOUACEMPR.Text = Trim(tbl.Rows(0).Item("OUACEMPR"))
                    Me.txtOUACFEVI.Text = Trim(tbl.Rows(0).Item("OUACFEVI"))
                    Me.txtOUACFEIN.Text = Trim(tbl.Rows(0).Item("OUACFEIN"))
                    Me.txtOUACSOLI.Text = Trim(tbl.Rows(0).Item("OUACSOLI"))
                    Me.txtOUACPUNT.Text = Trim(tbl.Rows(0).Item("OUACPUNT"))
                    Me.txtOUACPROY.Text = Trim(tbl.Rows(0).Item("OUACPROY"))
                    Me.txtOUACDIRE.Text = Trim(tbl.Rows(0).Item("OUACDIRE"))
                    Me.txtOUACARTE.Text = Trim(tbl.Rows(0).Item("OUACARTE"))

                    Me.txtOUACAVCO.Text = fun_Formato_Mascara_Pesos_Enteros(Trim(tbl.Rows(0).Item("OUACAVCO")))
                    Me.txtOUACACM2.Text = fun_Formato_Mascara_Pesos_Enteros(Trim(tbl.Rows(0).Item("OUACACM2")))

                    Dim objdatos3 As New cla_ESTADO

                    Me.cboOUACESTA.DataSource = objdatos3.fun_Consultar_TODOS_LOS_ESTADOS
                    Me.cboOUACESTA.DisplayMember = "ESTADESC"
                    Me.cboOUACESTA.ValueMember = "ESTACODI"

                    Me.cboOUACESTA.SelectedValue = tbl.Rows(0).Item("OUACESTA")

                    Me.lblOUACVIAV.Text = CType(fun_Buscar_Lista_Valores_VIGENCIA_Codigo(Me.cboOUACVIAV), String)

                End If

            ElseIf boINSERTAR = True Then

                Me.Text = "Insertar registro"
                Me.fraCEDUCATA.Text = "INSERTAR AVALÚO COMERCIAL"

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

                ' quita letras
                Me.txtOUACAVCO.Text = fun_Quita_Letras(Trim(Me.txtOUACAVCO.Text))
                Me.txtOUACACM2.Text = fun_Quita_Letras(Trim(Me.txtOUACACM2.Text))

                ' instancia la clase
                Dim objdatos As New cla_OBURAVCO

                Dim boLLAVEPRIMARIA As Boolean = objdatos.fun_Verifica_llave_Primaria_OBURAVCO(stOUACCLEN, inOUACNURE, stOUACFERE, Me.txtOUACNUAV, Me.cboOUACVIAV)

                ' instancia la clase
                Dim objVerifica As New cla_Verificar_Dato

                Dim boOUACNUAV As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Numerico(Me.txtOUACNUAV)
                Dim boOUACVIAV As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboOUACVIAV)
                Dim boOUACEMPR As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.txtOUACEMPR)
                Dim boOUACSOLI As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.txtOUACSOLI)
                Dim boOUACARTE As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Numerico(Me.txtOUACARTE)
                Dim boOUACAVCO As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Numerico(Me.txtOUACAVCO)
                Dim boOUACACM2 As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Numerico(Me.txtOUACACM2)
                Dim boOUACESTA As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboOUACESTA)

                ' verifica los datos del formulario 
                If boLLAVEPRIMARIA = True And _
                   boOUACNUAV = True And _
                   boOUACVIAV = True And _
                   boOUACEMPR = True And _
                   boOUACSOLI = True And _
                   boOUACARTE = True And _
                   boOUACAVCO = True And _
                   boOUACACM2 = True And _
                   boOUACESTA = True Then

                    Dim objdatos22 As New cla_OBURAVCO

                    If (objdatos22.fun_Insertar_OBURAVCO(inOUACSECU, _
                                                         stOUACCLEN, _
                                                         inOUACNURE, _
                                                         stOUACFERE, _
                                                         Me.txtOUACNUAV.Text, _
                                                         Me.cboOUACVIAV.SelectedValue, _
                                                         Me.txtOUACEMPR.Text, _
                                                         Me.txtOUACFEVI.Text, _
                                                         Me.txtOUACFEIN.Text, _
                                                         Me.txtOUACSOLI.Text, _
                                                         Me.txtOUACPUNT.Text, _
                                                         Me.txtOUACPROY.Text, _
                                                         Me.txtOUACDIRE.Text, _
                                                         Me.txtOUACARTE.Text, _
                                                         Me.txtOUACAVCO.Text, _
                                                         Me.txtOUACACM2.Text, _
                                                         Me.cboOUACESTA.SelectedValue)) = True Then

                        mod_MENSAJE.Se_Guardaron_Los_Datos_Correctamente()
                        Me.txtOUACNUAV.Focus()
                        Me.Close()
                    Else
                        mod_MENSAJE.No_Se_Guardo_El_Registro_En_La_Base_De_Datos()
                    End If

                End If

                ' modifica el registro
            ElseIf boMODIFICAR = True Then

                ' quita letras
                Me.txtOUACACM2.Text = fun_Quita_Letras(Trim(Me.txtOUACACM2.Text))
                Me.txtOUACAVCO.Text = fun_Quita_Letras(Trim(Me.txtOUACAVCO.Text))

                ' instancia la clase
                Dim objVerifica As New cla_Verificar_Dato

                Dim boOUACNUAV As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Numerico(Me.txtOUACNUAV)
                Dim boOUACVIAV As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboOUACVIAV)
                Dim boOUACEMPR As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.txtOUACEMPR)
                Dim boOUACSOLI As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.txtOUACSOLI)
                Dim boOUACARTE As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Numerico(Me.txtOUACARTE)
                Dim boOUACAVCO As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Numerico(Me.txtOUACAVCO)
                Dim boOUACACM2 As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Numerico(Me.txtOUACACM2)
                Dim boOUACESTA As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboOUACESTA)

                ' verifica los datos del formulario 
                If boOUACNUAV = True And _
                   boOUACVIAV = True And _
                   boOUACEMPR = True And _
                   boOUACSOLI = True And _
                   boOUACARTE = True And _
                   boOUACAVCO = True And _
                   boOUACACM2 = True And _
                   boOUACESTA = True Then

                    Dim objdatos22 As New cla_OBURAVCO

                    If (objdatos22.fun_Actualizar_OBURAVCO(inOUACIDRE, _
                                                           inOUACSECU, _
                                                           stOUACCLEN, _
                                                           inOUACNURE, _
                                                           stOUACFERE, _
                                                           Me.txtOUACNUAV.Text, _
                                                           Me.cboOUACVIAV.SelectedValue, _
                                                           Me.txtOUACEMPR.Text, _
                                                           Me.txtOUACFEVI.Text, _
                                                           Me.txtOUACFEIN.Text, _
                                                           Me.txtOUACSOLI.Text, _
                                                           Me.txtOUACPUNT.Text, _
                                                           Me.txtOUACPROY.Text, _
                                                           Me.txtOUACDIRE.Text, _
                                                           Me.txtOUACARTE.Text, _
                                                           Me.txtOUACAVCO.Text, _
                                                           Me.txtOUACACM2.Text, _
                                                           Me.cboOUACESTA.SelectedValue)) = True Then

                        mod_MENSAJE.Se_Guardaron_Los_Datos_Correctamente()
                        Me.txtOUACEMPR.Focus()
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
        Me.txtOUACNUAV.Focus()
        Me.Close()
    End Sub

#End Region

#Region "FORMULARIO"

#Region "KeyPress"

    Private Sub txt_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtOUACEMPR.KeyPress, txtOUACSOLI.KeyPress, txtOUACPUNT.KeyPress, txtOUACPROY.KeyPress, txtOUACDIRE.KeyPress, txtOUACNUAV.KeyPress, cboOUACVIAV.KeyPress, cboOUACESTA.KeyPress, txtOUACARTE.KeyPress, txtOUACACM2.KeyPress, txtOUACAVCO.KeyPress, txtOUACFEVI.KeyPress, txtOUACFEIN.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Or e.KeyChar = Convert.ToChar(Keys.Tab) Then
            pp_pro_SaltarCampo()
        End If
    End Sub

#End Region

#Region "KeyDown"

    Private Sub cboOUACVIAV_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboOUACVIAV.KeyDown
        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
            fun_Cargar_ComboBox_Con_Datos_Activos_VIGENCIA_Descripcion(Me.cboOUACVIAV, Me.cboOUACVIAV.SelectedIndex)
        End If
    End Sub
    Private Sub cboOUACESTA_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboOUACESTA.KeyDown
        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
            fun_Cargar_ComboBox_Con_Datos_Activos_ESTADO_Descripcion(Me.cboOUACESTA, Me.cboOUACESTA.SelectedIndex)
        End If
    End Sub

#End Region

#Region "SelectedIndexChanged"

    Private Sub cboOUACVIAV_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboOUACVIAV.SelectedIndexChanged
        Me.lblOUACVIAV.Text = CType(fun_Buscar_Lista_Valores_VIGENCIA_Codigo(Me.cboOUACVIAV), String)
    End Sub

#End Region

#Region "Click"

    Private Sub cboOUACVIAV_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboOUACVIAV.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_VIGENCIA_Descripcion(Me.cboOUACVIAV, Me.cboOUACVIAV.SelectedIndex)
    End Sub
    Private Sub cboOUACESTA_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboOUACESTA.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_ESTADO_Descripcion(Me.cboOUACESTA, Me.cboOUACESTA.SelectedIndex)
    End Sub

#End Region

#Region "GotFocus"

    Private Sub txt_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtOUACEMPR.GotFocus, txtOUACSOLI.GotFocus, txtOUACPUNT.GotFocus, txtOUACPROY.GotFocus, txtOUACDIRE.GotFocus, txtOUACNUAV.GotFocus, txtOUACARTE.GotFocus, txtOUACACM2.GotFocus, txtOUACAVCO.GotFocus, txtOUACFEVI.GotFocus, txtOUACFEIN.GotFocus
        pp_pro_SobrearCampo(sender)
        pp_pro_DescripcionCampo(Me.strBARRESTA.Items(0), sender)
    End Sub
    Private Sub cmd_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdGUARDAR.GotFocus, cmdSALIR.GotFocus
        pp_pro_DescripcionCampo(Me.strBARRESTA.Items(0), sender)
    End Sub
    Private Sub cbo_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboOUACVIAV.GotFocus, cboOUACESTA.GotFocus
        pp_pro_DescripcionCampo(Me.strBARRESTA.Items(0), sender)
    End Sub

#End Region

#Region "Validated"

    Private Sub txtOUACNUAV_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtOUACNUAV.Validated, txtOUACARTE.Validated, txtOUACACM2.Validated, txtOUACAVCO.Validated

        If Trim(sender.text) = "" Then
            sender.text = 0
        Else

            If fun_Verificar_Dato_Numerico_Evento_Validated(Me.txtOUACACM2.Text) = True Then
                Me.txtOUACACM2.Text = fun_Formato_Mascara_Pesos_Enteros(Me.txtOUACACM2.Text)
            End If

            If fun_Verificar_Dato_Numerico_Evento_Validated(Me.txtOUACAVCO.Text) = True Then
                Me.txtOUACAVCO.Text = fun_Formato_Mascara_Pesos_Enteros(Me.txtOUACAVCO.Text)
            End If

        End If

    End Sub

#End Region

#Region "ValueChanged"

    Private Sub dtpLIRAFERA_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpOUACFEVI.ValueChanged
        Me.txtOUACFEVI.Text = Me.dtpOUACFEVI.Value
    End Sub
    Private Sub dtpLIRAFEAS_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpOUACFEIN.ValueChanged
        Me.txtOUACFEIN.Text = Me.dtpOUACFEIN.Value
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