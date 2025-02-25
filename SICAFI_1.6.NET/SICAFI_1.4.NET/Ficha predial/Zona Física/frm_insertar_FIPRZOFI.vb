Imports REGLAS_DEL_NEGOCIO

Public Class frm_insertar_FIPRZOFI

    '============================
    '*** INSERTAR ZONA FÍSICA ***
    '============================

#Region "CONSTRUCTORES"

    Public Sub New(ByVal inFIPRNUFI As Integer, _
                   ByVal inFIPRNURE As Integer, _
                   ByVal stRESODEPA As String, _
                   ByVal stRESOMUNI As String, _
                   ByVal inRESOTIRE As Integer, _
                   ByVal inRESOCLSE As Integer, _
                   ByVal inRESOVIGE As Integer, _
                   ByVal inRESORESO As Integer)

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
        pro_ReconsultarZonaFisica()
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

        cboFPZFESTA.DataSource = objdatos4.fun_Consultar_ESTADO_X_ESTADO
        cboFPZFESTA.DisplayMember = "ESTADESC"
        cboFPZFESTA.ValueMember = "ESTACODI"

        Me.cboFPZFZOFI.Focus()

    End Sub
    Private Sub pro_ReconsultarZonaFisica()
        Try
            Dim objdatos As New cla_FIPRZOFI

            BindingSource_FIPRZOFI_1.DataSource = objdatos.fun_Consultar_FIPRZOFI(vp_FichaPredial)
            dgvFIPRZOFI.DataSource = BindingSource_FIPRZOFI_1.DataSource
            BindingNavigator_FIPRZOFI_1.BindingSource = BindingSource_FIPRZOFI_1

            dgvFIPRZOFI.Columns(0).Visible = False
            dgvFIPRZOFI.Columns(1).Visible = False

            strBARRESTA.Items(2).Text = "Registros : " & BindingSource_FIPRZOFI_1.Count

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub pro_NumeroDeSecuenciaDeRegistro()
        Dim inFPZFSECU As Integer = 0

        Dim objdatos5 As New cla_FIPRZOFI
        Dim tbl10 As New DataTable

        tbl10 = objdatos5.fun_Buscar_NRO_SECUENCIA_FIPRZOFI_X_FICHA_PREDIAL(Val(vp_FichaPredial))

        If tbl10.Rows.Count = 0 Then
            inFPZFSECU = 1
        Else
            Dim i As Integer
            Dim NroMayor As Integer
            Dim Posicion As Integer

            Posicion = Val(tbl10.Rows(0).Item("FPZFSECU"))

            For i = 0 To tbl10.Rows.Count - 1
                NroMayor = Val(tbl10.Rows(i).Item("FPZFSECU"))

                If NroMayor > Posicion Then
                    inFPZFSECU = NroMayor
                    Posicion = NroMayor
                Else
                    inFPZFSECU = Posicion
                End If
            Next

            inFPZFSECU = inFPZFSECU + 1
        End If

        lblFPZFSECU.Text = inFPZFSECU

    End Sub
    Private Sub pro_LimpiarCampos()

        txtFPZFPORC.Text = ""

        strBARRESTA.Items(1).Text = ""
        ErrorProvider1.SetError(Me.cboFPZFZOFI, "")

        Dim tbl As New DataTable

        Me.cboFPZFZOFI.DataSource = tbl

    End Sub
    Private Sub pro_Sumar_Porcentaje()
        Dim objdatos2 As New cla_FIPRZOFI
        Dim tbl1 As New DataTable
        Dim tbl2 As New DataTable
        tbl1.Clear()

        tbl2 = objdatos2.fun_Consultar_FIPRZOFI(Val(vp_FichaPredial))

        If tbl2.Rows.Count > 0 Then

            tbl1 = objdatos2.fun_Consultar_SUMA_X_FPZFPORC_FIPRZOFI(Val(vp_FichaPredial))

            Dim i As Integer
            Dim inTOTAL As Integer

            ' ciclo debido que el dato se almacena en un campo string
            For i = 0 To tbl1.Rows.Count - 1
                inTOTAL += CType(tbl1.Rows(i).Item("FPZFPORC"), Integer)
            Next

            lblFPZFTOTA.Text = inTOTAL.ToString

        Else
            lblFPZFTOTA.Text = "0"

        End If
    End Sub

#End Region

#Region "MENU"

    Private Sub cmdGUARDAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGUARDAR.Click

        Try
            If fun_Verificar_Campos_Llenos_3_DATOS(Trim(Me.cboFPZFZOFI.Text), _
                                                   Trim(Me.txtFPZFPORC.Text), _
                                                   Trim(Me.cboFPZFESTA.Text)) = False Then
                mod_MENSAJE.Existen_Campos_Sin_Diligenciar()
                cboFPZFZOFI.Focus()
            Else
                Dim inZONAFISI As Integer = Val(cboFPZFZOFI.Text)

                Dim objdatos1 As New cla_FIPRZOFI
                Dim tbl As New DataTable

                tbl = objdatos1.fun_Buscar_CODIGO_FIPRZOFI(vp_FichaPredial, inZONAFISI)

                If tbl.Rows.Count > 0 Then
                    mod_MENSAJE.Codigo_Existente_En_Base_De_Datos()
                    cboFPZFZOFI.Focus()
                Else
                    Dim objdatos As New cla_FIPRZOFI
                    Dim inFPZFSECU As Integer = 0

                    Dim objdatos5 As New cla_FIPRZOFI
                    Dim tbl10 As New DataTable

                    tbl10 = objdatos5.fun_Buscar_NRO_SECUENCIA_FIPRZOFI_X_FICHA_PREDIAL(Val(vp_FichaPredial))

                    If tbl10.Rows.Count = 0 Then
                        inFPZFSECU = 1
                    Else
                        Dim i As Integer
                        Dim NroMayor As Integer
                        Dim Posicion As Integer

                        Posicion = Val(tbl10.Rows(0).Item("FPZFSECU"))

                        For i = 0 To tbl10.Rows.Count - 1
                            NroMayor = Val(tbl10.Rows(i).Item("FPZFSECU"))

                            If NroMayor > Posicion Then
                                inFPZFSECU = NroMayor
                                Posicion = NroMayor
                            Else
                                inFPZFSECU = Posicion
                            End If
                        Next
                        inFPZFSECU = inFPZFSECU + 1
                    End If

                    lblFPZFSECU.Text = inFPZFSECU

                    If (objdatos.fun_Insertar_FIPRZOFI(vp_FichaPredial, cboFPZFZOFI.SelectedValue, txtFPZFPORC.Text, vl_stRESODEPA, vl_stRESOMUNI, vl_inRESOTIRE, vl_inRESOCLSE, vl_inRESOVIGE, vl_inRESORESO, inFPZFSECU, vl_inFIPRNURE, cboFPZFESTA.SelectedValue)) Then
                        mod_MENSAJE.Se_Guardaron_Los_Datos_Correctamente()

                        Dim objdatos3 As New cla_FIPRZOFI
                        Dim tbl3 As New DataTable
                        Dim inTOTAL As Single
                        Dim i As Integer

                        tbl3 = objdatos3.fun_Consultar_SUMA_X_FPZFPORC_FIPRZOFI(vp_FichaPredial)

                        For i = 0 To tbl3.Rows.Count - 1
                            inTOTAL += CType(tbl3.Rows(i).Item("FPZFPORC"), Integer)
                        Next

                        If inTOTAL >= 100 Then
                            Me.Close()
                        Else
                            If MessageBox.Show("¿ Desea agregar otro registro ?", "Mensaje...", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.No Then
                                cboFPZFZOFI.Focus()
                                Me.Close()
                            End If

                            pro_NumeroDeSecuenciaDeRegistro()
                            pro_Sumar_Porcentaje()

                        End If

                        pro_ReconsultarZonaFisica()
                        pro_LimpiarCampos()
                        cboFPZFZOFI.Focus()
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
        cboFPZFZOFI.Focus()
        Me.Close()
    End Sub

#End Region

#Region "FORMULARIO"

#Region "Load"

    Private Sub frm_insertar_FIPRZOFI_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        strBARRESTA.Items(0).Text = "Zona física"
    End Sub

#End Region

#Region "Click"

    Private Sub cboFPZFZOFI_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboFPZFZOFI.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_ZONAFISI(cboFPZFZOFI, cboFPZFZOFI.SelectedIndex, vl_stRESODEPA, vl_stRESOMUNI, vl_inRESOCLSE)
    End Sub

#End Region

#Region "KeyDown"

    Private Sub cboFPZFZOFI_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboFPZFZOFI.KeyDown
        If e.KeyCode = Keys.F2 Then
            mod_LLAMAR_FORMULARIO_INSERTAR.pro_Llamar_formulario_frm_ZONAFISI()
        End If
    End Sub

#End Region

#Region "SelectedIndexChanged"

    Private Sub cboFPZFZOFI_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboFPZFZOFI.SelectedIndexChanged
        lblFPZFDESC.Text = CType(fun_Buscar_Lista_Valores_ZONAFISI(vl_stRESODEPA, vl_stRESOMUNI, vl_inRESOCLSE, Trim(cboFPZFZOFI.Text)), String)
    End Sub

#End Region

#Region "Validated"

    Private Sub cboFPZFZOFI_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboFPZFZOFI.Validated
        If Trim(cboFPZFZOFI.Text) = "" Then
            cboFPZFZOFI.Focus()
            strBARRESTA.Items(1).Text = IncoValoNume
            ErrorProvider1.SetError(Me.cboFPZFZOFI, "")
        Else
            strBARRESTA.Items(1).Text = ""

            Dim Codigo As Integer = Val(cboFPZFZOFI.SelectedValue)

            Dim objdatos As New cla_FIPRZOFI
            Dim tbl As New DataTable
            tbl = objdatos.fun_Buscar_CODIGO_FIPRZOFI(vp_FichaPredial, Codigo)

            If tbl.Rows.Count > 0 Then
                ErrorProvider1.SetError(Me.cboFPZFZOFI, "Código existente en la base de datos")
                strBARRESTA.Items(1).Text = "Código existente en la base de datos"
                cboFPZFZOFI.Focus()
            Else
                ErrorProvider1.SetError(Me.cboFPZFZOFI, "")
            End If
        End If
    End Sub
    Private Sub txtFPZFPORC_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFPZFPORC.Validated

        If Trim(txtFPZFPORC.Text) = "" Then
            txtFPZFPORC.Focus()
            strBARRESTA.Items(1).Text = IncoValoNume
        Else
            strBARRESTA.Items(1).Text = ""

            If Val(txtFPZFPORC.Text) > 100 Then
                strBARRESTA.Items(1).Text = "Porcentaje del destino mayor al 100 %"
                MessageBox.Show("Porcentaje de destino superior al 100 %", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1)

                txtFPZFPORC.Focus()

            Else
                Dim objdatos2 As New cla_FIPRZOFI
                Dim tbl1 As New DataTable
                Dim tbl2 As New DataTable

                tbl2 = objdatos2.fun_Consultar_FIPRZOFI(Val(vp_FichaPredial))

                If tbl2.Rows.Count > 0 Then

                    tbl1 = objdatos2.fun_Consultar_SUMA_X_FPZFPORC_FIPRZOFI(Val(vp_FichaPredial))

                    If tbl1.Rows.Count > 0 Then

                        Dim i As Integer
                        Dim inTOTAL_ZONA As Integer = 0
                        Dim inTOTAL As Integer = 0

                        For i = 0 To tbl1.Rows.Count - 1
                            inTOTAL += CType(tbl1.Rows(i).Item("FPZFPORC"), Integer)
                        Next

                        inTOTAL_ZONA = Val(inTOTAL) + Val(txtFPZFPORC.Text)

                        If inTOTAL_ZONA > 100 Then
                            strBARRESTA.Items(1).Text = "Porcentaje mayor al 100 %"

                            txtFPZFPORC.Focus()
                        End If
                    End If
                End If
            End If
        End If

    End Sub

#End Region

#Region "KeyPress"

    Private Sub cboFPZFZOFI_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboFPZFZOFI.KeyPress

        If fun_Verificar_Dato_Numerico_Evento_KeyPress(Short.Parse(Asc(e.KeyChar))) = False Then
            e.Handled = True
        ElseIf e.KeyChar = Convert.ToChar(Keys.Enter) Then
            txtFPZFPORC.Focus()
        ElseIf Char.IsNumber(e.KeyChar) Then
            fun_Cargar_ComboBox_Con_Datos_Activos_ZONAFISI(cboFPZFZOFI, cboFPZFZOFI.SelectedIndex, vl_stRESODEPA, vl_stRESOMUNI, vl_inRESOCLSE)
        End If

    End Sub
    Private Sub txtFPZFPORC_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFPZFPORC.KeyPress
        If fun_Verificar_Dato_Numerico_Evento_KeyPress(Short.Parse(Asc(e.KeyChar))) = False Then
            e.Handled = True
        ElseIf e.KeyChar = Convert.ToChar(Keys.Enter) Then
            cboFPZFESTA.Focus()
        End If
    End Sub
    Private Sub cboFPZFESTA_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboFPZFESTA.KeyPress
        If fun_Verificar_Dato_Numerico_Evento_KeyPress(Short.Parse(Asc(e.KeyChar))) = False Then
            e.Handled = True
        ElseIf e.KeyChar = Convert.ToChar(Keys.Enter) Then
            cmdGUARDAR.Focus()
        End If
    End Sub

#End Region

#Region "GotFocus"
    Private Sub dgvFIPRZOFI_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvFIPRZOFI.GotFocus
        strBARRESTA.Items(0).Text = dgvFIPRZOFI.AccessibleDescription
    End Sub
    Private Sub cboFPZFZOFI_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboFPZFZOFI.GotFocus
        strBARRESTA.Items(0).Text = cboFPZFZOFI.AccessibleDescription
    End Sub
    Private Sub txtFPZFPORC_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFPZFPORC.GotFocus
        txtFPZFPORC.SelectionStart = 0
        txtFPZFPORC.SelectionLength = Len(txtFPZFPORC.Text)
        strBARRESTA.Items(0).Text = txtFPZFPORC.AccessibleDescription
    End Sub
    Private Sub cboFPZFESTA_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboFPZFESTA.GotFocus
        strBARRESTA.Items(0).Text = cboFPZFESTA.AccessibleDescription
    End Sub
    Private Sub cmdGUARDAR_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdGUARDAR.GotFocus
        strBARRESTA.Items(0).Text = cmdGUARDAR.AccessibleDescription
    End Sub
    Private Sub cmdCANCELAR_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdSALIR.GotFocus
        strBARRESTA.Items(0).Text = cmdSALIR.AccessibleDescription
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