Imports REGLAS_DEL_NEGOCIO
Imports System.IO

Public Class frm_insertar_MUTAMATR

    '====================================
    '*** INSERTAR MATRICULAS ADJUNTAS ***
    '====================================

#Region "VARIABLE"

    Dim vl_inMUTAIDRE As Integer = 0
    Dim vl_inMUTASECU As Integer = 0
    Dim vl_inMUTANUFI As Integer = 0
    Dim vl_inMUTAMAIN As Integer = 0

    Dim boINSERTAR As Boolean = False
    Dim boMODIFICAR As Boolean = False

#End Region

#Region "CONSTRUCTOR"

    Public Sub New(ByVal inSECU As Integer)
        vl_inMUTASECU = inSECU

        boINSERTAR = True

        InitializeComponent()
        pro_LimpiarCampos()
        pro_inicializarControles()

    End Sub
    Public Sub New(ByVal inIDRE As Integer, ByVal inSECU As Integer, ByVal inNUFI As Integer, ByVal inMAIN As Integer)
        vl_inMUTAIDRE = inIDRE
        vl_inMUTASECU = inSECU
        vl_inMUTANUFI = inNUFI
        vl_inMUTAMAIN = inMAIN

        boMODIFICAR = True

        InitializeComponent()
        pro_LimpiarCampos()
        pro_inicializarControles()

    End Sub

#End Region

#Region "PROCEDIMIENTOS"

    Private Sub pro_inicializarControles()

        Try
            ' asigna la secuencia
            Me.txtMUMASECU.Text = CStr(vl_inMUTASECU)

            If boMODIFICAR = True Then

                ' instancia la clase
                Dim objdatos As New cla_MUTAMATR
                Dim tbl As New DataTable

                tbl = objdatos.fun_Buscar_CODIGO_X_MUTAMATR(vl_inMUTASECU, vl_inMUTANUFI, vl_inMUTAMAIN)

                If tbl.Rows.Count > 0 Then

                    Me.Text = "Modificar registro"
                    Me.fraMUTAMATR.Text = "MODIFICAR MATRICULA ADJUNTA"

                    Me.txtMUMANUFI.Enabled = False
                    Me.txtMUMAMAIN.Enabled = False

                    Me.txtMUMASECU.Text = vl_inMUTASECU

                    Me.txtMUMANUFI.Text = Trim(tbl.Rows(0).Item("MUMANUFI"))
                    Me.txtMUMAMAIN.Text = Trim(tbl.Rows(0).Item("MUMAMAIN"))
                    Me.txtMUMAVACO.Text = fun_Formato_Mascara_Pesos_Enteros(Trim(tbl.Rows(0).Item("MUMAVACO")))

                Else
                    boINSERTAR = True

                    Me.Text = "Insertar registro"
                    Me.fraMUTAMATR.Text = "INSERTAR MATRICULA ADJUNTA"

                    Me.txtMUMAMAIN.Focus()

                End If

            Else
                boINSERTAR = True

                Me.Text = "Insertar registro"
                Me.fraMUTAMATR.Text = "INSERTAR MATRICULA ADJUNTA"

                Me.txtMUMASECU.Text = vl_inMUTASECU

                Me.txtMUMANUFI.Focus()

            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub pro_diligenciarCedulaCatastral(ByVal stFIPRNUFI As String)

        Try
            Dim obFICHPRED As New cla_FICHPRED
            Dim dtFICHPRED As New DataTable

            dtFICHPRED = obFICHPRED.fun_Consultar_FICHA_PREDIAL_X_NRO_FICHA_PREDIAL(stFIPRNUFI)

            If dtFICHPRED.Rows.Count > 0 Then

                Me.txtMUTAMUNI.Text = Trim(dtFICHPRED.Rows(0).Item("FIPRMUNI"))
                Me.txtMUTACORR.Text = Trim(dtFICHPRED.Rows(0).Item("FIPRCORR"))
                Me.txtMUTABARR.Text = Trim(dtFICHPRED.Rows(0).Item("FIPRBARR"))
                Me.txtMUTAMANZ.Text = Trim(dtFICHPRED.Rows(0).Item("FIPRMANZ"))
                Me.txtMUTAPRED.Text = Trim(dtFICHPRED.Rows(0).Item("FIPRPRED"))
                Me.txtMUTAEDIF.Text = Trim(dtFICHPRED.Rows(0).Item("FIPREDIF"))
                Me.txtMUTAUNPR.Text = Trim(dtFICHPRED.Rows(0).Item("FIPRUNPR"))

                Dim objdatos2 As New cla_CLASSECT

                Me.cboMUTACLSE.DataSource = objdatos2.fun_Consultar_CAMPOS_MANT_CLASSECT
                Me.cboMUTACLSE.DisplayMember = "CLSEDESC"
                Me.cboMUTACLSE.ValueMember = "CLSECODI"

                Me.cboMUTACLSE.SelectedValue = dtFICHPRED.Rows(0).Item("FIPRCLSE")

            End If

        Catch ex As Exception

        End Try

    End Sub
    Private Sub pro_diligenciarCedulaCatastralConMatricula(ByVal stFPPRMAIN As String)

        Try
            Dim obFIPRPROP As New cla_FIPRPROP
            Dim dtFIPRPROP As New DataTable

            Dim stMATRICULA As String = Trim("001-" & fun_Formato_Mascara_7_Reales(Trim(stFPPRMAIN)))

            dtFIPRPROP = obFIPRPROP.fun_Buscar_MATRICULA_FIPRPROP(stMATRICULA)

            If dtFIPRPROP.Rows.Count > 0 Then

                Dim stFIPRNUFI As String = Trim(dtFIPRPROP.Rows(0).Item(0).ToString)

                Dim obFICHPRED As New cla_FICHPRED
                Dim dtFICHPRED As New DataTable

                dtFICHPRED = obFICHPRED.fun_Consultar_FICHA_PREDIAL_X_NRO_FICHA_PREDIAL(stFIPRNUFI)

                If dtFICHPRED.Rows.Count > 0 Then

                    Me.txtMUMANUFI.Text = Trim(dtFICHPRED.Rows(0).Item("FIPRNUFI"))
                    Me.txtMUTAMUNI.Text = Trim(dtFICHPRED.Rows(0).Item("FIPRMUNI"))
                    Me.txtMUTACORR.Text = Trim(dtFICHPRED.Rows(0).Item("FIPRCORR"))
                    Me.txtMUTABARR.Text = Trim(dtFICHPRED.Rows(0).Item("FIPRBARR"))
                    Me.txtMUTAMANZ.Text = Trim(dtFICHPRED.Rows(0).Item("FIPRMANZ"))
                    Me.txtMUTAPRED.Text = Trim(dtFICHPRED.Rows(0).Item("FIPRPRED"))
                    Me.txtMUTAEDIF.Text = Trim(dtFICHPRED.Rows(0).Item("FIPREDIF"))
                    Me.txtMUTAUNPR.Text = Trim(dtFICHPRED.Rows(0).Item("FIPRUNPR"))

                    Dim objdatos2 As New cla_CLASSECT

                    Me.cboMUTACLSE.DataSource = objdatos2.fun_Consultar_CAMPOS_MANT_CLASSECT
                    Me.cboMUTACLSE.DisplayMember = "CLSEDESC"
                    Me.cboMUTACLSE.ValueMember = "CLSECODI"

                    Me.cboMUTACLSE.SelectedValue = dtFICHPRED.Rows(0).Item("FIPRCLSE")

                End If
            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub pro_LimpiarCampos()

        Me.txtMUMANUFI.Text = "0"
        Me.txtMUMAMAIN.Text = ""
        Me.txtMUMAVACO.Text = "0"

        Me.txtMUMANUFI.Text = ""
        Me.txtMUTAMUNI.Text = ""
        Me.txtMUTACORR.Text = ""
        Me.txtMUTABARR.Text = ""
        Me.txtMUTAMANZ.Text = ""
        Me.txtMUTAPRED.Text = ""
        Me.txtMUTAEDIF.Text = ""
        Me.txtMUTAUNPR.Text = ""

        Me.cboMUTACLSE.DataSource = New DataTable

    End Sub

#End Region

#Region "FUNCIONES"

    Function fun_ConsultarMatricula(ByVal inNroFicha As Integer) As String

        Try
            ' declaro la variable
            Dim stMatricula As String = ""
            Dim inTamano As Integer = 0
            Dim stLetra As String = ""

            ' instancia la clase
            Dim obFIPRPROP As New cla_FIPRPROP
            Dim tdFIPRPROP As New DataTable

            tdFIPRPROP = obFIPRPROP.fun_Consultar_FIPRPROP_X_FICHA_PREDIAL(inNroFicha)

            If tdFIPRPROP.Rows.Count > 0 Then

                ' declaro la variable
                Dim i As Integer = 0

                For i = 0 To tdFIPRPROP.Rows.Count - 1

                    stMatricula = Trim(tdFIPRPROP.Rows(i).Item("FPPRMAIN"))

                Next

                ' almaceno la longitud
                inTamano = stMatricula.ToString.Length

                ' declaro la variable 
                Dim inSeparador As Integer = 0
                Dim stSeparador As String = ""
                Dim ii As Integer = 0

                For ii = 0 To inTamano - 1

                    stSeparador = stMatricula.ToString.Substring(ii, 1)

                    If inSeparador = 1 Then
                        stLetra += stMatricula.ToString.Substring(ii, 1)
                    End If

                    If stSeparador = "-" Then
                        inSeparador = 1
                    End If

                Next

                ' llena la matricula 
                stMatricula = stLetra

            End If

            Return stMatricula

        Catch ex As Exception
            Return ""
            MessageBox.Show(Err.Description)
        End Try

    End Function

#End Region
#Region "MENU"

    Private Sub cmdGUARDAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGUARDAR.Click

        Try
            ' inserta el registro
            If boINSERTAR = True Then

                Me.txtMUMAVACO.Text = fun_Quita_Letras(Me.txtMUMAVACO)

                ' instancia la clase
                Dim objdatos As New cla_MUTAMATR

                Dim boLLAVEPRIMARIA As Boolean = objdatos.fun_Verifica_llave_Primaria_MUTAMATR(Me.txtMUMASECU, Me.txtMUMANUFI, Me.txtMUMAMAIN)

                ' instancia la clase
                Dim objVerifica As New cla_Verificar_Dato

                Dim boMUTANUFI As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Numerico(Me.txtMUMANUFI)
                Dim boMUTAMAIN As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Numerico(Me.txtMUMAMAIN)
                Dim boMUTAVACO As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Numerico(Me.txtMUMAVACO)

                ' verifica los datos del formulario 
                If boLLAVEPRIMARIA = True And _
                   boMUTANUFI = True And _
                   boMUTAMAIN = True And _
                   boMUTAVACO = True Then

                    Dim objdatos22 As New cla_MUTAMATR

                    If (objdatos22.fun_Insertar_MUTAMATR(Me.txtMUMASECU.Text, _
                                                         Me.txtMUMANUFI.Text, _
                                                         Me.txtMUMAMAIN.Text, _
                                                         Me.txtMUMAVACO.Text)) = True Then

                        mod_MENSAJE.Se_Guardaron_Los_Datos_Correctamente()

                        If MessageBox.Show("¿ Desea agregar otro registro ?", "Mensaje...", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.No Then

                            Dim objdatos1 As New cla_MUTACIONES
                            Dim tbl1 As New DataTable

                            tbl1 = objdatos1.fun_Buscar_CODIGO_X_MUTACIONES(CInt(Me.txtMUMASECU.Text))

                            If tbl1.Rows.Count > 0 Then
                                Dim inNroIdRe As New frm_MUTACIONES(tbl1.Rows(0).Item("MUTAIDRE"))
                            End If

                            Me.txtMUMANUFI.Focus()
                            Me.Close()
                        Else
                            pro_LimpiarCampos()
                            Me.txtMUMANUFI.Focus()
                        End If

                    Else
                        mod_MENSAJE.No_Se_Guardo_El_Registro_En_La_Base_De_Datos()
                    End If
                End If

                ' modifica el registro
            ElseIf boMODIFICAR = True Then

                Me.txtMUMAVACO.Text = fun_Quita_Letras(Me.txtMUMAVACO)

                ' instancia la clase
                Dim objVerifica As New cla_Verificar_Dato

                Dim boMUTANUFI As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Numerico(Me.txtMUMANUFI)
                Dim boMUTAMAIN As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Numerico(Me.txtMUMAMAIN)
                Dim boMUTAVACO As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Numerico(Me.txtMUMAVACO)

                ' verifica los datos del formulario 
                If boMUTANUFI = True And _
                   boMUTAMAIN = True And _
                   boMUTAVACO = True Then

                    Dim objdatos22 As New cla_MUTAMATR

                    If (objdatos22.fun_Actualizar_MUTAMATR(vl_inMUTAIDRE, _
                                                           vl_inMUTASECU, _
                                                           Me.txtMUMANUFI.Text, _
                                                           Me.txtMUMAMAIN.Text, _
                                                           Me.txtMUMAVACO.Text)) = True Then

                        mod_MENSAJE.Se_Guardaron_Los_Datos_Correctamente()

                        Me.txtMUMANUFI.Focus()
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
    Private Sub cmdCANCELAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim inNroIdRe As New frm_MUTACIONES(vl_inMUTAIDRE)
        Me.txtMUMANUFI.Focus()
        Me.Close()
    End Sub

#End Region

#Region "FORMULARIO"

#Region "KeyPress"

    Private Sub txt_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtMUMANUFI.KeyPress, txtMUMAMAIN.KeyPress, txtMUMAVACO.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Or e.KeyChar = Convert.ToChar(Keys.Tab) Then
            pp_pro_SaltarCampo()
        End If
    End Sub

#End Region

#Region "GotFocus"

    Private Sub txt_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtMUMANUFI.GotFocus, txtMUMAMAIN.GotFocus, txtMUMAVACO.GotFocus
        pp_pro_SobrearCampo(sender)
        pp_pro_DescripcionCampo(Me.strBARRESTA.Items(0), sender)
    End Sub
    Private Sub cmd_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdGUARDAR.GotFocus, cmdSALIR.GotFocus
        pp_pro_DescripcionCampo(Me.strBARRESTA.Items(0), sender)
    End Sub

#End Region

#Region "Validated"

    Private Sub txtMUMAVACO_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtMUMAVACO.Validated
        If Trim(sender.text) = "" Then
            sender.text = "0"
        Else
            If fun_Verificar_Dato_Numerico_Evento_Validated(Me.txtMUMAVACO.Text) = True Then
                Me.txtMUMAVACO.Text = fun_Formato_Mascara_Pesos_Enteros(Me.txtMUMAVACO.Text)
            End If

        End If
    End Sub
    Private Sub txtMUMANUFI_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtMUMANUFI.Validated
        If Trim(sender.text) = "" Then
            sender.text = 0
        Else
            pro_diligenciarCedulaCatastral(Trim(Me.txtMUMANUFI.Text))
            Me.txtMUMAMAIN.Text = fun_ConsultarMatricula(Trim(Me.txtMUMANUFI.Text))

            If Trim(Me.txtMUMAMAIN.Text) <> "" Then
                Me.txtMUMAMAIN.Text = CInt(Me.txtMUMAMAIN.Text)
                Me.txtMUTAVACO.Focus()
            End If

        End If
    End Sub
    Private Sub txtMUMAMAIN_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtMUMAMAIN.Validated

        If Trim(Me.txtMUMANUFI.Text) <> "0" Or Trim(Me.txtMUMANUFI.Text) <> "" Then

            pro_diligenciarCedulaCatastralConMatricula(Trim(Me.txtMUMAMAIN.Text))

            If Trim(Me.txtMUMAMAIN.Text) <> "" Then
                Me.txtMUMAMAIN.Text = CInt(Me.txtMUMAMAIN.Text)
                Me.txtMUMAVACO.Focus()
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