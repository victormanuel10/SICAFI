Imports REGLAS_DEL_NEGOCIO

Public Class frm_insertar_FIPRZOEC

    '===============================
    '*** INSERTAR ZONA ECONÓMICA ***
    '===============================

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
        pro_ReconsultarZonaEconomica()
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

        cboFPZEESTA.DataSource = objdatos4.fun_Consultar_ESTADO_X_ESTADO
        cboFPZEESTA.DisplayMember = "ESTADESC"
        cboFPZEESTA.ValueMember = "ESTACODI"

        Me.cboFPZEZOEC.Focus()

    End Sub
    Private Sub pro_ReconsultarZonaEconomica()
        Try
            Dim objdatos As New cla_FIPRZOEC

            BindingSource_FIPRZOEC_1.DataSource = objdatos.fun_Consultar_FIPRZOEC(vp_FichaPredial)
            dgvFIPRZOEC.DataSource = BindingSource_FIPRZOEC_1.DataSource
            BindingNavigator_FIPRZOEC_1.BindingSource = BindingSource_FIPRZOEC_1

            dgvFIPRZOEC.Columns(0).Visible = False
            dgvFIPRZOEC.Columns(1).Visible = False

            strBARRESTA.Items(2).Text = "Registros : " & BindingSource_FIPRZOEC_1.Count

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub pro_NumeroDeSecuenciaDeRegistro()
        Dim inFPZESECU As Integer = 0

        Dim objdatos5 As New cla_FIPRZOEC
        Dim tbl10 As New DataTable

        tbl10 = objdatos5.fun_Buscar_NRO_SECUENCIA_FIPRZOEC_X_FICHA_PREDIAL(Val(vp_FichaPredial))

        If tbl10.Rows.Count = 0 Then
            inFPZESECU = 1
        Else
            Dim i As Integer
            Dim NroMayor As Integer
            Dim Posicion As Integer

            Posicion = Val(tbl10.Rows(0).Item("FPZESECU"))

            For i = 0 To tbl10.Rows.Count - 1
                NroMayor = Val(tbl10.Rows(i).Item("FPZESECU"))

                If NroMayor > Posicion Then
                    inFPZESECU = NroMayor
                    Posicion = NroMayor
                Else
                    inFPZESECU = Posicion
                End If
            Next

            inFPZESECU = inFPZESECU + 1
        End If

        lblFPZESECU.Text = inFPZESECU

    End Sub
    Private Sub pro_LimpiarCampos()

        Me.txtFPZEPORC.Text = ""

        strBARRESTA.Items(1).Text = ""
        ErrorProvider1.SetError(Me.cboFPZEZOEC, "")

        Dim tbl As DataTable

        Me.cboFPZEZOEC.DataSource = tbl

    End Sub
    Private Sub pro_Sumar_Porcentaje()
        Dim objdatos2 As New cla_FIPRZOEC
        Dim tbl1 As New DataTable
        Dim tbl2 As New DataTable
        tbl1.Clear()

        tbl2 = objdatos2.fun_Consultar_FIPRZOEC(Val(vp_FichaPredial))

        If tbl2.Rows.Count > 0 Then

            tbl1 = objdatos2.fun_Consultar_SUMA_X_FPZEPORC_FIPRZOEC(Val(vp_FichaPredial))

            Dim i As Integer
            Dim inTOTAL As Integer

            ' ciclo debido que el dato se almacena en un campo string
            For i = 0 To tbl1.Rows.Count - 1
                inTOTAL += CType(tbl1.Rows(i).Item("FPZEPORC"), Integer)
            Next

            lblFPZETOTA.Text = inTOTAL.ToString

        Else
            lblFPZETOTA.Text = "0"

        End If
    End Sub

#End Region

#Region "MENU"

    Private Sub cmdGUARDAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGUARDAR.Click

        Try
            If fun_Verificar_Campos_Llenos_3_DATOS(Trim(Me.cboFPZEZOEC.Text), _
                                                   Trim(Me.txtFPZEPORC.Text), _
                                                   Trim(Me.cboFPZEESTA.Text)) = False Then
                mod_MENSAJE.Existen_Campos_Sin_Diligenciar()
                cboFPZEZOEC.Focus()
            Else
                Dim inZONAECON As Integer = Val(cboFPZEZOEC.Text)

                Dim objdatos1 As New cla_FIPRZOEC
                Dim tbl As New DataTable

                tbl = objdatos1.fun_Buscar_CODIGO_FIPRZOEC(vp_FichaPredial, inZONAECON)

                If tbl.Rows.Count > 0 Then
                    mod_MENSAJE.Codigo_Existente_En_Base_De_Datos()
                    cboFPZEZOEC.Focus()
                Else
                    Dim objdatos As New cla_FIPRZOEC
                    Dim inFPZESECU As Integer = 0

                    Dim objdatos5 As New cla_FIPRZOEC
                    Dim tbl10 As New DataTable

                    tbl10 = objdatos5.fun_Buscar_NRO_SECUENCIA_FIPRZOEC_X_FICHA_PREDIAL(Val(vp_FichaPredial))

                    If tbl10.Rows.Count = 0 Then
                        inFPZESECU = 1
                    Else
                        Dim i As Integer
                        Dim NroMayor As Integer
                        Dim Posicion As Integer

                        Posicion = Val(tbl10.Rows(0).Item("FPZESECU"))

                        For i = 0 To tbl10.Rows.Count - 1
                            NroMayor = Val(tbl10.Rows(i).Item("FPZESECU"))

                            If NroMayor > Posicion Then
                                inFPZESECU = NroMayor
                                Posicion = NroMayor
                            Else
                                inFPZESECU = Posicion
                            End If
                        Next
                        inFPZESECU = inFPZESECU + 1
                    End If

                    lblFPZESECU.Text = inFPZESECU

                    If (objdatos.fun_Insertar_FIPRZOEC(vp_FichaPredial, cboFPZEZOEC.SelectedValue, txtFPZEPORC.Text, vl_stRESODEPA, vl_stRESOMUNI, vl_inRESOTIRE, vl_inRESOCLSE, vl_inRESOVIGE, vl_inRESORESO, inFPZESECU, vl_inFIPRNURE, cboFPZEESTA.SelectedValue)) Then
                        mod_MENSAJE.Se_Guardaron_Los_Datos_Correctamente()

                        Dim objdatos3 As New cla_FIPRZOEC
                        Dim tbl3 As New DataTable
                        Dim inTOTAL As Single
                        Dim i As Integer

                        tbl3 = objdatos3.fun_Consultar_SUMA_X_FPZEPORC_FIPRZOEC(vp_FichaPredial)

                        For i = 0 To tbl3.Rows.Count - 1
                            inTOTAL += CType(tbl3.Rows(i).Item("FPZEPORC"), Integer)
                        Next

                        If inTOTAL >= 100 Then
                            Me.Close()
                        Else
                            If MessageBox.Show("¿ Desea agregar otro registro ?", "Mensaje...", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.No Then
                                cboFPZEZOEC.Focus()
                                Me.Close()
                            End If

                            pro_NumeroDeSecuenciaDeRegistro()
                            pro_Sumar_Porcentaje()

                        End If

                        pro_ReconsultarZonaEconomica()
                        pro_LimpiarCampos()
                        cboFPZEZOEC.Focus()
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
        cboFPZEZOEC.Focus()
        Me.Close()
    End Sub

#End Region

#Region "FORMULARIO"

#Region "Load"

    Private Sub frm_insertar_FIPRZOEC_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        strBARRESTA.Items(0).Text = "Zona económica"
    End Sub

#End Region

#Region "Click"

    Private Sub cboFPZEZOEC_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboFPZEZOEC.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_ZONAECON(cboFPZEZOEC, cboFPZEZOEC.SelectedIndex, vl_stRESODEPA, vl_stRESOMUNI, vl_inRESOCLSE)
    End Sub

#End Region

#Region "KeyDown"

    Private Sub cboFPZEZOEC_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboFPZEZOEC.KeyDown
        If e.KeyCode = Keys.F2 Then
            mod_LLAMAR_FORMULARIO_INSERTAR.pro_Llamar_formulario_frm_ZONAECON()
        End If
    End Sub

#End Region

#Region "SelectedIndexChanged"

    Private Sub cboFPZEZOEC_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboFPZEZOEC.SelectedIndexChanged
        lblFPZEDESC.Text = CType(fun_Buscar_Lista_Valores_ZONAECON(vl_stRESODEPA, vl_stRESOMUNI, vl_inRESOCLSE, Trim(cboFPZEZOEC.Text)), String)
    End Sub

#End Region

#Region "Validated"

    Private Sub cboFPZEZOEC_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboFPZEZOEC.Validated
        If Trim(cboFPZEZOEC.Text) = "" Then
            cboFPZEZOEC.Focus()
            strBARRESTA.Items(1).Text = IncoValoNume
            ErrorProvider1.SetError(Me.cboFPZEZOEC, "")
        Else
            strBARRESTA.Items(1).Text = ""

            Dim Codigo As Integer = Val(cboFPZEZOEC.SelectedValue)

            Dim objdatos As New cla_FIPRZOEC
            Dim tbl As New DataTable
            tbl = objdatos.fun_Buscar_CODIGO_FIPRZOEC(vp_FichaPredial, Codigo)

            If tbl.Rows.Count > 0 Then
                ErrorProvider1.SetError(Me.cboFPZEZOEC, "Código existente en la base de datos")
                strBARRESTA.Items(1).Text = "Código existente en la base de datos"
                cboFPZEZOEC.Focus()
            Else
                ErrorProvider1.SetError(Me.cboFPZEZOEC, "")
            End If
        End If
    End Sub
    Private Sub txtFPZEPORC_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFPZEPORC.Validated

        If Trim(txtFPZEPORC.Text) = "" Then
            txtFPZEPORC.Focus()
            strBARRESTA.Items(1).Text = IncoValoNume
        Else
            strBARRESTA.Items(1).Text = ""

            If Val(txtFPZEPORC.Text) > 100 Then
                strBARRESTA.Items(1).Text = "Porcentaje del destino mayor al 100 %"
                MessageBox.Show("Porcentaje de destino superior al 100 %", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1)

                txtFPZEPORC.Focus()

            Else
                Dim objdatos2 As New cla_FIPRZOEC
                Dim tbl1 As New DataTable
                Dim tbl2 As New DataTable

                tbl2 = objdatos2.fun_Consultar_FIPRZOEC(Val(vp_FichaPredial))

                If tbl2.Rows.Count > 0 Then

                    tbl1 = objdatos2.fun_Consultar_SUMA_X_FPZEPORC_FIPRZOEC(Val(vp_FichaPredial))

                    If tbl1.Rows.Count > 0 Then

                        Dim i As Integer
                        Dim inTOTAL_ZONA As Integer = 0
                        Dim inTOTAL As Integer = 0

                        For i = 0 To tbl1.Rows.Count - 1
                            inTOTAL += CType(tbl1.Rows(i).Item("FPZEPORC"), Integer)
                        Next

                        inTOTAL_ZONA = Val(inTOTAL) + Val(txtFPZEPORC.Text)

                        If inTOTAL_ZONA > 100 Then
                            strBARRESTA.Items(1).Text = "Porcentaje mayor al 100 %"

                            txtFPZEPORC.Focus()
                        End If
                    End If
                End If
            End If
        End If

    End Sub

#End Region

#Region "KeyPress"

    Private Sub cboFPZEZOEC_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboFPZEZOEC.KeyPress

        If fun_Verificar_Dato_Numerico_Evento_KeyPress(Short.Parse(Asc(e.KeyChar))) = False Then
            e.Handled = True
        ElseIf e.KeyChar = Convert.ToChar(Keys.Enter) Then
            txtFPZEPORC.Focus()
        ElseIf Char.IsNumber(e.KeyChar) Then
            fun_Cargar_ComboBox_Con_Datos_Activos_ZONAECON(cboFPZEZOEC, cboFPZEZOEC.SelectedIndex, vl_stRESODEPA, vl_stRESOMUNI, vl_inRESOCLSE)
        End If

    End Sub
    Private Sub txtFPZEPORC_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFPZEPORC.KeyPress
        If fun_Verificar_Dato_Numerico_Evento_KeyPress(Short.Parse(Asc(e.KeyChar))) = False Then
            e.Handled = True
        ElseIf e.KeyChar = Convert.ToChar(Keys.Enter) Then
            cboFPZEESTA.Focus()
        End If
    End Sub
    Private Sub cboFPZEESTA_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboFPZEESTA.KeyPress
        If fun_Verificar_Dato_Numerico_Evento_KeyPress(Short.Parse(Asc(e.KeyChar))) = False Then
            e.Handled = True
        ElseIf e.KeyChar = Convert.ToChar(Keys.Enter) Then
            cmdGUARDAR.Focus()
        End If
    End Sub

#End Region

#Region "GotFocus"
    Private Sub dgvFIPRZOEC_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvFIPRZOEC.GotFocus
        strBARRESTA.Items(0).Text = dgvFIPRZOEC.AccessibleDescription
    End Sub
    Private Sub cboFPZEZOEC_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboFPZEZOEC.GotFocus
        strBARRESTA.Items(0).Text = cboFPZEZOEC.AccessibleDescription
    End Sub
    Private Sub txtFPZEPORC_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFPZEPORC.GotFocus
        txtFPZEPORC.SelectionStart = 0
        txtFPZEPORC.SelectionLength = Len(txtFPZEPORC.Text)
        strBARRESTA.Items(0).Text = txtFPZEPORC.AccessibleDescription
    End Sub
    Private Sub cboFPZEESTA_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboFPZEESTA.GotFocus
        strBARRESTA.Items(0).Text = cboFPZEESTA.AccessibleDescription
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