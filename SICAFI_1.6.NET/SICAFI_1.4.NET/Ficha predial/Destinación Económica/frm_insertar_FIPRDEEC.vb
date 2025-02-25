Imports REGLAS_DEL_NEGOCIO

Public Class frm_insertar_FIPRDEEC

    '=====================================
    '*** INSERTAR DETINACIÓN ECONÓMICA ***
    '=====================================

#Region "CONSTRUCTORES"

    Public Sub New(ByVal inFIPRNUFI As Integer, ByVal inFIPRNURE As Integer, ByVal stRESODEPA As String, ByVal stRESOMUNI As String, ByVal inRESOTIRE As Integer, ByVal inRESOCLSE As Integer, ByVal inRESOVIGE As Integer, ByVal inRESORESO As Integer)

        vp_FichaPredial = inFIPRNUFI
        vl_inFIPRNURE = inFIPRNURE
        vl_stRESODEPA = stRESODEPA
        vl_stRESOMUNI = stRESOMUNI
        vl_inRESOTIRE = inRESOTIRE
        vl_inRESOCLSE = inRESOCLSE
        vl_inRESOVIGE = inRESOVIGE
        vl_inRESORESO = inRESORESO

        InitializeComponent()
        pro_LimpiarCampos()
        pro_inicializarControles()
        pro_NumeroDeSecuenciaDeRegistro()
        pro_ReconsultarDestinoEconomico()
        pro_Sumar_Porcentaje()

    End Sub

#End Region
    
#Region "VARIABLES LOCALES"

    '*** VARIABLES QUE RECIBE DEL FORMULARIO DE FICHA PREDIAL ***
    Dim vl_inFIPRNURE As Integer
    Dim vl_stRESODEPA As String
    Dim vl_stRESOMUNI As String
    Dim vl_inRESOTIRE As Integer
    Dim vl_inRESOCLSE As Integer
    Dim vl_inRESOVIGE As Integer
    Dim vl_inRESORESO As Integer

#End Region

#Region "PROCEDIMIENTOS"

    Private Sub pro_inicializarControles()

        '=========================================
        ' CARGA LOS COMBOBOX CON LOS DATOS ACTIVOS
        '=========================================

        Dim objdatos4 As New cla_ESTADO

        cboFPDEESTA.DataSource = objdatos4.fun_Consultar_ESTADO_X_ESTADO
        cboFPDEESTA.DisplayMember = "ESTADESC"
        cboFPDEESTA.ValueMember = "ESTACODI"

        Me.cboFPDEDEEC.Focus()

    End Sub
    Private Sub pro_ReconsultarDestinoEconomico()
        Try
            Dim objdatos As New cla_FIPRDEEC

            BindingSource_FIPRDEEC_1.DataSource = objdatos.fun_Consultar_FIPRDEEC(vp_FichaPredial)
            dgvFIPRDEEC.DataSource = BindingSource_FIPRDEEC_1.DataSource
            BindingNavigator_FIPRDEEC_1.BindingSource = BindingSource_FIPRDEEC_1

            dgvFIPRDEEC.Columns(0).Visible = False
            dgvFIPRDEEC.Columns(1).Visible = False

            strBARRESTA.Items(2).Text = "Registros : " & BindingSource_FIPRDEEC_1.Count

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub pro_NumeroDeSecuenciaDeRegistro()
        Dim inFPDESECU As Integer = 0

        Dim objdatos5 As New cla_FIPRDEEC
        Dim tbl10 As New DataTable

        tbl10 = objdatos5.fun_Buscar_NRO_SECUENCIA_FIPRDEEC_X_FICHA_PREDIAL(Val(vp_FichaPredial))

        If tbl10.Rows.Count = 0 Then
            inFPDESECU = 1
        Else
            Dim i As Integer
            Dim NroMayor As Integer
            Dim Posicion As Integer

            Posicion = Val(tbl10.Rows(0).Item(10))

            For i = 0 To tbl10.Rows.Count - 1
                NroMayor = Val(tbl10.Rows(i).Item(10))

                If NroMayor > Posicion Then
                    inFPDESECU = NroMayor
                    Posicion = NroMayor
                Else
                    inFPDESECU = Posicion
                End If
            Next

            inFPDESECU = inFPDESECU + 1
        End If

        txtFPDESECU.Text = inFPDESECU
    End Sub
    Private Sub pro_LimpiarCampos()

        Me.txtFPDEPORC.Text = ""

        strBARRESTA.Items(1).Text = ""
        ErrorProvider1.SetError(Me.cboFPDEDEEC, "")

        Dim tbl As New DataTable

        Me.cboFPDEDEEC.DataSource = tbl

    End Sub
    Private Sub pro_Sumar_Porcentaje()
        Dim objdatos2 As New cla_FIPRDEEC
        Dim tbl1 As New DataTable
        Dim tbl2 As New DataTable
        tbl1.Clear()

        tbl2 = objdatos2.fun_Consultar_FIPRDEEC(Val(vp_FichaPredial))

        If tbl2.Rows.Count > 0 Then

            tbl1 = objdatos2.fun_Consultar_SUMA_X_FPDEPORC_FIPRDEEC(Val(vp_FichaPredial))

            Dim i As Integer
            Dim inTOTAL As Integer

            ' ciclo debido que el dato se almacena en un campo string
            For i = 0 To tbl1.Rows.Count - 1
                inTOTAL += CType(tbl1.Rows(i).Item("FPDEPORC"), Integer)
            Next

            lblFPDETOTA.Text = inTOTAL.ToString

        Else
            lblFPDETOTA.Text = "0"

        End If
    End Sub

#End Region

#Region "MENU"

    Private Sub cmdGUARDAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGUARDAR.Click

        Try
            If fun_Verificar_Campos_Llenos_3_DATOS(Trim(Me.cboFPDEDEEC.Text), _
                                                   Trim(Me.txtFPDEPORC.Text), _
                                                   Trim(Me.cboFPDEESTA.Text)) = False Then
                mod_MENSAJE.Existen_Campos_Sin_Diligenciar()
                cboFPDEDEEC.Focus()
            Else
                Dim id As Integer = Val(cboFPDEDEEC.Text)

                Dim objdatos1 As New cla_FIPRDEEC
                Dim tbl As New DataTable
                tbl = objdatos1.fun_Buscar_CODIGO_FIPRDEEC(vp_FichaPredial, id)

                If tbl.Rows.Count > 0 Then
                    mod_MENSAJE.Codigo_Existente_En_Base_De_Datos()
                    cboFPDEDEEC.Focus()
                Else
                    Dim objdatos As New cla_FIPRDEEC
                    Dim inFPDESECU As Integer = 0

                    Dim objdatos5 As New cla_FIPRDEEC
                    Dim tbl10 As New DataTable

                    tbl10 = objdatos5.fun_Buscar_NRO_SECUENCIA_FIPRDEEC_X_FICHA_PREDIAL(Val(vp_FichaPredial))

                    If tbl10.Rows.Count = 0 Then
                        inFPDESECU = 1
                    Else
                        Dim i As Integer
                        Dim NroMayor As Integer
                        Dim Posicion As Integer

                        Posicion = Val(tbl10.Rows(0).Item(10))

                        For i = 0 To tbl10.Rows.Count - 1
                            NroMayor = Val(tbl10.Rows(i).Item(10))

                            If NroMayor > Posicion Then
                                inFPDESECU = NroMayor
                                Posicion = NroMayor
                            Else
                                inFPDESECU = Posicion
                            End If
                        Next
                        inFPDESECU = inFPDESECU + 1
                    End If

                    txtFPDESECU.Text = inFPDESECU

                    If (objdatos.fun_Insertar_FIPRDEEC(vp_FichaPredial, cboFPDEDEEC.SelectedValue, txtFPDEPORC.Text, vl_stRESODEPA, vl_stRESOMUNI, vl_inRESOTIRE, vl_inRESOCLSE, vl_inRESOVIGE, vl_inRESORESO, inFPDESECU, vl_inFIPRNURE, cboFPDEESTA.SelectedValue)) Then
                        mod_MENSAJE.Se_Guardaron_Los_Datos_Correctamente()

                        Dim objdatos3 As New cla_FIPRDEEC
                        Dim tbl3 As New DataTable
                        Dim inTOTAL As Single
                        Dim i As Integer

                        tbl3 = objdatos3.fun_Consultar_SUMA_X_FPDEPORC_FIPRDEEC(vp_FichaPredial)

                        For i = 0 To tbl3.Rows.Count - 1
                            inTOTAL += CType(tbl3.Rows(i).Item("FPDEPORC"), Integer)
                        Next

                        If inTOTAL >= 100 Then
                            Me.Close()
                        Else
                            If MessageBox.Show("¿ Desea agregar otro registro ?", "Mensaje...", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.No Then
                                cboFPDEDEEC.Focus()
                                Me.Close()
                            End If

                            pro_NumeroDeSecuenciaDeRegistro()
                            pro_Sumar_Porcentaje()

                        End If

                        pro_ReconsultarDestinoEconomico()
                        pro_LimpiarCampos()
                        cboFPDEDEEC.Focus()
                    Else
                        mod_MENSAJE.No_Se_Guardo_El_Registro_En_La_Base_De_Datos()
                    End If
                End If
            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description & "Guardar")
        End Try

    End Sub
    Private Sub cmdCANCELAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSALIR.Click
        Me.cboFPDEDEEC.Focus()
        Me.Close()
    End Sub

#End Region

#Region "FORMULARIO"

#Region "Load"

    Private Sub frm_insertar_FIPRDEEC_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        strBARRESTA.Items(0).Text = "Destino económico"
    End Sub

#End Region

#Region "Click"

    Private Sub cboFPDEDEEC_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboFPDEDEEC.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_DESTECON(cboFPDEDEEC, cboFPDEDEEC.SelectedIndex)
    End Sub

#End Region

#Region "KeyDown"

    Private Sub cboFPDEDEEC_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboFPDEDEEC.KeyDown
        If e.KeyCode = Keys.F2 Then
            mod_LLAMAR_FORMULARIO_INSERTAR.pro_Llamar_formulario_frm_DESTECON()
        End If
    End Sub

#End Region

#Region "SelectedIndexChanged"

    Private Sub cboFPDEDEEC_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboFPDEDEEC.SelectedIndexChanged
        lblFPDEDESC.Text = fun_Buscar_Lista_Valores_DESTECON(Trim(cboFPDEDEEC.Text))
    End Sub

#End Region

#Region "Validated"

    Private Sub cboFPDEDEEC_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboFPDEDEEC.Validated
        If Trim(cboFPDEDEEC.Text) = "" Then
            cboFPDEDEEC.Focus()
            strBARRESTA.Items(1).Text = IncoValoNume
            ErrorProvider1.SetError(Me.cboFPDEDEEC, "")
        Else
            strBARRESTA.Items(1).Text = ""

            Dim Codigo As Integer = Val(cboFPDEDEEC.SelectedValue)

            Dim objdatos As New cla_FIPRDEEC
            Dim tbl As New DataTable
            tbl = objdatos.fun_Buscar_CODIGO_FIPRDEEC(vp_FichaPredial, Codigo)

            If tbl.Rows.Count > 0 Then
                ErrorProvider1.SetError(Me.cboFPDEDEEC, "Código existente en la base de datos")
                strBARRESTA.Items(1).Text = "Código existente en la base de datos"
                cboFPDEDEEC.Focus()
            Else
                ErrorProvider1.SetError(Me.cboFPDEDEEC, "")
            End If
        End If
    End Sub
    Private Sub txtFPDEPORC_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFPDEPORC.Validated

        If Trim(txtFPDEPORC.Text) = "" Then
            txtFPDEPORC.Focus()
            strBARRESTA.Items(1).Text = IncoValoNume
        Else
            strBARRESTA.Items(1).Text = ""

            If Val(txtFPDEPORC.Text) > 100 Then
                strBARRESTA.Items(1).Text = "Porcentaje del destino mayor al 100 %"
                MessageBox.Show("Porcentaje de destino superior al 100 %", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1)

                txtFPDEPORC.Focus()

            Else
                Dim objdatos2 As New cla_FIPRDEEC
                Dim tbl1 As New DataTable
                Dim tbl2 As New DataTable

                tbl2 = objdatos2.fun_Consultar_FIPRDEEC(Val(vp_FichaPredial))

                If tbl2.Rows.Count > 0 Then

                    tbl1 = objdatos2.fun_Consultar_SUMA_X_FPDEPORC_FIPRDEEC(Val(vp_FichaPredial))

                    If tbl1.Rows.Count > 0 Then

                        Dim i As Integer
                        Dim inTOTAL_DESTINO As Integer = 0
                        Dim inTOTAL As Integer = 0

                        For i = 0 To tbl1.Rows.Count - 1
                            inTOTAL += CType(tbl1.Rows(i).Item("FPDEPORC"), Integer)
                        Next

                        inTOTAL_DESTINO = Val(inTOTAL) + Val(txtFPDEPORC.Text)

                        If inTOTAL_DESTINO > 100 Then
                            strBARRESTA.Items(1).Text = "Porcentaje del destino mayor al 100 %"

                            txtFPDEPORC.Focus()
                        End If
                    End If
                End If
            End If
        End If

    End Sub

#End Region

#Region "KeyPress"

    Private Sub cboFPDEDEEC_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboFPDEDEEC.KeyPress

        If fun_Verificar_Dato_Numerico_Evento_KeyPress(Short.Parse(Asc(e.KeyChar))) = False Then
            e.Handled = True
        ElseIf e.KeyChar = Convert.ToChar(Keys.Enter) Then
            txtFPDEPORC.Focus()
        ElseIf Char.IsNumber(e.KeyChar) Then
            fun_Cargar_ComboBox_Con_Datos_Activos_DESTECON(cboFPDEDEEC, cboFPDEDEEC.SelectedIndex)
        End If

    End Sub
    Private Sub txtFPDEPORC_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFPDEPORC.KeyPress
        If fun_Verificar_Dato_Numerico_Evento_KeyPress(Short.Parse(Asc(e.KeyChar))) = False Then
            e.Handled = True
        ElseIf e.KeyChar = Convert.ToChar(Keys.Enter) Then
            cboFPDEESTA.Focus()
        End If
    End Sub
    Private Sub cboFPDEESTA_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboFPDEESTA.KeyPress
        If fun_Verificar_Dato_Numerico_Evento_KeyPress(Short.Parse(Asc(e.KeyChar))) = False Then
            e.Handled = True
        ElseIf e.KeyChar = Convert.ToChar(Keys.Enter) Then
            cmdGUARDAR.Focus()
        End If
    End Sub

#End Region

#Region "GotFocus"
    Private Sub dgvFIPRDEEC_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvFIPRDEEC.GotFocus
        strBARRESTA.Items(0).Text = dgvFIPRDEEC.AccessibleDescription
    End Sub
    Private Sub cboFPDEDEEC_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboFPDEDEEC.GotFocus
        strBARRESTA.Items(0).Text = cboFPDEDEEC.AccessibleDescription
    End Sub
    Private Sub txtFPDEPORC_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFPDEPORC.GotFocus
        txtFPDEPORC.SelectionStart = 0
        txtFPDEPORC.SelectionLength = Len(txtFPDEPORC.Text)
        strBARRESTA.Items(0).Text = txtFPDEPORC.AccessibleDescription
    End Sub
    Private Sub cboFPDEESTA_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboFPDEESTA.GotFocus
        strBARRESTA.Items(0).Text = cboFPDEESTA.AccessibleDescription
    End Sub
    Private Sub cmdGUARDAR_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdGUARDAR.GotFocus
        strBARRESTA.Items(0).Text = cmdGUARDAR.AccessibleDescription
    End Sub
    Private Sub cmdCANCELAR_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdSALIR.GotFocus
        strBARRESTA.Items(0).Text = cmdSALIR.AccessibleDescription
    End Sub
#End Region

#Region "TextChanged"

    Private Sub tstBAESDESC_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tstBAESDESC.TextChanged
        ' coloca en modo de mensaje el texto que se muestra en la barra
        'If strBARRESTA.Items(1).Text <> "" Then
        '    MessageBox.Show(strBARRESTA.Items(1).Text, "Mensaje ...", MessageBoxButtons.OK, MessageBoxIcon.Hand)
        'End If
    End Sub

#End Region

#Region "ResizeBegin"

    Private Sub frm_insertar_FICHPRED_ResizeBegin(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.ResizeBegin
        Me.Opacity = vp_Opacity
    End Sub

#End Region

#Region "ResizeEnd"

    Private Sub frm_insertar_FICHPRED_ResizeEnd(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.ResizeEnd
        Dim opacity As Double = Convert.ToDouble(100)
        Me.Opacity = opacity
    End Sub

#End Region

#End Region
   
End Class