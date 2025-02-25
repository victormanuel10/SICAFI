Imports REGLAS_DEL_NEGOCIO

Public Class frm_insertar_FIPRLIND

    '====================================
    '*** FORMULARIO INSERTAR LINDEROS ***
    '====================================

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
        pro_ReconsultarLinderos()

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

        cboFPLIESTA.DataSource = objdatos4.fun_Consultar_ESTADO_X_ESTADO
        cboFPLIESTA.DisplayMember = "ESTADESC"
        cboFPLIESTA.ValueMember = "ESTACODI"

        Me.cboFPLIPUCA.Focus()

    End Sub
    Private Sub pro_ReconsultarLinderos()
        Try
            Dim objdatos As New cla_FIPRLIND

            BindingSource_FIPRLIND_1.DataSource = objdatos.fun_Consultar_FIPRLIND(vp_FichaPredial)
            dgvFIPRLIND.DataSource = BindingSource_FIPRLIND_1.DataSource
            BindingNavigator_FIPRLIND_1.BindingSource = BindingSource_FIPRLIND_1

            dgvFIPRLIND.Columns(0).Visible = False
            dgvFIPRLIND.Columns(1).Visible = False

            strBARRESTA.Items(2).Text = "Registros : " & BindingSource_FIPRLIND_1.Count

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub pro_NumeroDeSecuenciaDeRegistro()
        Dim inFPLISECU As Integer = 0

        Dim objdatos5 As New cla_FIPRLIND
        Dim tbl10 As New DataTable

        tbl10 = objdatos5.fun_Buscar_NRO_SECUENCIA_FIPRLIND_X_FICHA_PREDIAL(Val(vp_FichaPredial))

        If tbl10.Rows.Count = 0 Then
            inFPLISECU = 1
        Else
            Dim i As Integer
            Dim NroMayor As Integer
            Dim Posicion As Integer

            Posicion = Val(tbl10.Rows(0).Item(10))

            For i = 0 To tbl10.Rows.Count - 1
                NroMayor = Val(tbl10.Rows(i).Item(10))

                If NroMayor > Posicion Then
                    inFPLISECU = NroMayor
                    Posicion = NroMayor
                Else
                    inFPLISECU = Posicion
                End If
            Next

            inFPLISECU = inFPLISECU + 1
        End If

        lblFPLISECU.Text = inFPLISECU
    End Sub
    Private Sub pro_LimpiarCampos()

        Me.txtFPLICOLI.Text = ""

        Me.strBARRESTA.Items(1).Text = ""

        Me.cboFPLIPUCA.DataSource = New DataTable

    End Sub
    Private Sub pro_ConsultarColindatesPredios()

        Try
            ' instancia la clase
            Dim obFICHPRED As New cla_FICHPRED
            Dim dtFICHPRED As New DataTable

            ' consulta por ficha 
            dtFICHPRED = obFICHPRED.fun_Consultar_FICHA_PREDIAL_X_NRO_FICHA_PREDIAL(vp_FichaPredial)

            If dtFICHPRED.Rows.Count > 0 Then

                Dim stFIPRMUNI As String = Trim(dtFICHPRED.Rows(0).Item("FIPRMUNI").ToString)
                Dim stFIPRCLSE As String = Trim(dtFICHPRED.Rows(0).Item("FIPRCLSE").ToString)
                Dim stFIPRCORR As String = Trim(dtFICHPRED.Rows(0).Item("FIPRCORR").ToString)
                Dim stFIPRBARR As String = Trim(dtFICHPRED.Rows(0).Item("FIPRBARR").ToString)
                Dim stFIPRMANZ As String = Trim(dtFICHPRED.Rows(0).Item("FIPRMANZ").ToString)
                Dim stFIPRPRED As String = Trim(dtFICHPRED.Rows(0).Item("FIPRPRED").ToString)

                ' instancia la clase
                Dim obFICHPRED1 As New cla_FICHPRED
                Dim dtFICHPRED1 As New DataTable

                ' consulta por ficha 
                dtFICHPRED1 = obFICHPRED1.fun_Consultar_FICHA_PREDIAL_x_CEDULA(stFIPRMUNI, stFIPRCLSE, stFIPRCORR, stFIPRBARR, stFIPRMANZ)

                If dtFICHPRED1.Rows.Count > 0 Then

                    Me.lstFPLICOLI_PREDIO.Items.Clear()

                    ' Crea objeto registros
                    Dim dr1 As DataRow

                    ' crea la tabla
                    Dim dt_LINDERO As New DataTable

                    dt_LINDERO.Columns.Add(New DataColumn("Colindante", GetType(String)))

                    Dim i As Integer = 0

                    For i = 0 To dtFICHPRED1.Rows.Count - 1

                        dr1 = dt_LINDERO.NewRow()

                        dr1("Colindante") = fun_Formato_Mascara_3_String(Trim(dtFICHPRED1.Rows(i).Item("FIPRMUNI").ToString)) & _
                                                                         Trim(dtFICHPRED1.Rows(i).Item("FIPRCLSE").ToString) & _
                                            fun_Formato_Mascara_3_String(Trim(dtFICHPRED1.Rows(i).Item("FIPRCORR").ToString)) & _
                                            fun_Formato_Mascara_3_String(Trim(dtFICHPRED1.Rows(i).Item("FIPRBARR").ToString)) & _
                                            fun_Formato_Mascara_4_String(Trim(dtFICHPRED1.Rows(i).Item("FIPRMANZ").ToString)) & _
                                            fun_Formato_Mascara_5_String(Trim(dtFICHPRED1.Rows(i).Item("FIPRPRED").ToString))

                        dt_LINDERO.Rows.Add(dr1)

                        Me.lstFPLICOLI_PREDIO.Items.Add(dt_LINDERO.Rows(i).Item("Colindante").ToString)

                    Next

                End If

            End If


        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub pro_ConsultarColindatesPredioUnidad()

        Try
            ' instancia la clase
            Dim obFICHPRED As New cla_FICHPRED
            Dim dtFICHPRED As New DataTable

            ' consulta por ficha 
            dtFICHPRED = obFICHPRED.fun_Consultar_FICHA_PREDIAL_X_NRO_FICHA_PREDIAL(vp_FichaPredial)

            If dtFICHPRED.Rows.Count > 0 Then

                If CInt(dtFICHPRED.Rows(0).Item("FIPRCAPR")) = 2 Or _
                   CInt(dtFICHPRED.Rows(0).Item("FIPRCAPR")) = 3 Or _
                   CInt(dtFICHPRED.Rows(0).Item("FIPRCAPR")) = 4 Or _
                   CInt(dtFICHPRED.Rows(0).Item("FIPRCAPR")) = 5 Then

                    Dim stFIPRMUNI As String = Trim(dtFICHPRED.Rows(0).Item("FIPRMUNI").ToString)
                    Dim stFIPRCLSE As String = Trim(dtFICHPRED.Rows(0).Item("FIPRCLSE").ToString)
                    Dim stFIPRCORR As String = Trim(dtFICHPRED.Rows(0).Item("FIPRCORR").ToString)
                    Dim stFIPRBARR As String = Trim(dtFICHPRED.Rows(0).Item("FIPRBARR").ToString)
                    Dim stFIPRMANZ As String = Trim(dtFICHPRED.Rows(0).Item("FIPRMANZ").ToString)
                    Dim stFIPRPRED As String = Trim(dtFICHPRED.Rows(0).Item("FIPRPRED").ToString)

                    ' instancia la clase
                    Dim obFICHPRED1 As New cla_FICHPRED
                    Dim dtFICHPRED1 As New DataTable

                    ' consulta por ficha 
                    dtFICHPRED1 = obFICHPRED1.fun_Consultar_FICHA_PREDIAL_x_CEDULA(stFIPRMUNI, stFIPRCLSE, stFIPRCORR, stFIPRBARR, stFIPRMANZ, stFIPRPRED)

                    If dtFICHPRED1.Rows.Count > 0 Then

                        Me.lstFPLICOLI_PREDIO_UNIDAD.Items.Clear()

                        ' Crea objeto registros
                        Dim dr1 As DataRow

                        ' crea la tabla
                        Dim dt_LINDERO As New DataTable

                        dt_LINDERO.Columns.Add(New DataColumn("Colindante", GetType(String)))

                        Dim i As Integer = 0

                        For i = 0 To dtFICHPRED1.Rows.Count - 1

                            dr1 = dt_LINDERO.NewRow()

                            dr1("Colindante") = fun_Formato_Mascara_3_String(Trim(dtFICHPRED1.Rows(i).Item("FIPRMUNI").ToString)) & _
                                                                             Trim(dtFICHPRED1.Rows(i).Item("FIPRCLSE").ToString) & _
                                                fun_Formato_Mascara_3_String(Trim(dtFICHPRED1.Rows(i).Item("FIPRCORR").ToString)) & _
                                                fun_Formato_Mascara_3_String(Trim(dtFICHPRED1.Rows(i).Item("FIPRBARR").ToString)) & _
                                                fun_Formato_Mascara_4_String(Trim(dtFICHPRED1.Rows(i).Item("FIPRMANZ").ToString)) & _
                                                fun_Formato_Mascara_5_String(Trim(dtFICHPRED1.Rows(i).Item("FIPRPRED").ToString)) & _
                                                fun_Formato_Mascara_4_String(Trim(dtFICHPRED1.Rows(i).Item("FIPREDIF").ToString)) & _
                                                fun_Formato_Mascara_5_String(Trim(dtFICHPRED1.Rows(i).Item("FIPRUNPR").ToString))

                            dt_LINDERO.Rows.Add(dr1)

                            Me.lstFPLICOLI_PREDIO_UNIDAD.Items.Add(dt_LINDERO.Rows(i).Item("Colindante").ToString)

                        Next

                    End If

                Else
                    Me.lstFPLICOLI_PREDIO_UNIDAD.Items.Clear()

                End If

            End If


        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub pro_ConsultarColindatesUnidad()

        Try
            ' instancia la clase
            Dim obFICHPRED As New cla_FICHPRED
            Dim dtFICHPRED As New DataTable

            ' consulta por ficha 
            dtFICHPRED = obFICHPRED.fun_Consultar_FICHA_PREDIAL_X_NRO_FICHA_PREDIAL(vp_FichaPredial)

            If dtFICHPRED.Rows.Count > 0 Then

                If CInt(dtFICHPRED.Rows(0).Item("FIPRCAPR")) = 2 Or _
                   CInt(dtFICHPRED.Rows(0).Item("FIPRCAPR")) = 3 Or _
                   CInt(dtFICHPRED.Rows(0).Item("FIPRCAPR")) = 4 Or _
                   CInt(dtFICHPRED.Rows(0).Item("FIPRCAPR")) = 5 Then

                    Dim stFIPRMUNI As String = Trim(dtFICHPRED.Rows(0).Item("FIPRMUNI").ToString)
                    Dim stFIPRCLSE As String = Trim(dtFICHPRED.Rows(0).Item("FIPRCLSE").ToString)
                    Dim stFIPRCORR As String = Trim(dtFICHPRED.Rows(0).Item("FIPRCORR").ToString)
                    Dim stFIPRBARR As String = Trim(dtFICHPRED.Rows(0).Item("FIPRBARR").ToString)
                    Dim stFIPRMANZ As String = Trim(dtFICHPRED.Rows(0).Item("FIPRMANZ").ToString)
                    Dim stFIPRPRED As String = Trim(dtFICHPRED.Rows(0).Item("FIPRPRED").ToString)

                    ' instancia la clase
                    Dim obFICHPRED1 As New cla_FICHPRED
                    Dim dtFICHPRED1 As New DataTable

                    ' consulta por ficha 
                    dtFICHPRED1 = obFICHPRED1.fun_Consultar_FICHA_PREDIAL_x_CEDULA(stFIPRMUNI, stFIPRCLSE, stFIPRCORR, stFIPRBARR, stFIPRMANZ, stFIPRPRED)

                    If dtFICHPRED1.Rows.Count > 0 Then

                        Me.lstFPLICOLI_UNIDAD.Items.Clear()

                        ' Crea objeto registros
                        Dim dr1 As DataRow

                        ' crea la tabla
                        Dim dt_LINDERO As New DataTable

                        dt_LINDERO.Columns.Add(New DataColumn("Colindante", GetType(String)))

                        Dim i As Integer = 0

                        For i = 0 To dtFICHPRED1.Rows.Count - 1

                            dr1 = dt_LINDERO.NewRow()

                            dr1("Colindante") = fun_Formato_Mascara_5_String(Trim(dtFICHPRED1.Rows(i).Item("FIPRUNPR").ToString))

                            dt_LINDERO.Rows.Add(dr1)

                            Me.lstFPLICOLI_UNIDAD.Items.Add(dt_LINDERO.Rows(i).Item("Colindante").ToString)

                        Next

                    End If

                Else
                    Me.lstFPLICOLI_UNIDAD.Items.Clear()

                End If

            End If


        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub

#End Region

#Region "MENU"

    Private Sub cmdGUARDAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGUARDAR.Click

        Try
            If fun_Verificar_Campos_Llenos_3_DATOS(Trim(Me.cboFPLIPUCA.Text), _
                                                   Trim(Me.txtFPLICOLI.Text), _
                                                   Trim(Me.cboFPLIESTA.Text)) = False Then
                mod_MENSAJE.Existen_Campos_Sin_Diligenciar()
                cboFPLIPUCA.Focus()
            Else
                Dim objdatos As New cla_FIPRLIND
                Dim inFPLISECU As Integer = 0

                Dim objdatos5 As New cla_FIPRLIND
                Dim tbl10 As New DataTable

                tbl10 = objdatos5.fun_Buscar_NRO_SECUENCIA_FIPRLIND_X_FICHA_PREDIAL(Val(vp_FichaPredial))

                If tbl10.Rows.Count = 0 Then
                    inFPLISECU = 1
                Else
                    Dim i As Integer
                    Dim NroMayor As Integer
                    Dim Posicion As Integer

                    Posicion = Val(tbl10.Rows(0).Item(10))

                    For i = 0 To tbl10.Rows.Count - 1
                        NroMayor = Val(tbl10.Rows(i).Item(10))

                        If NroMayor > Posicion Then
                            inFPLISECU = NroMayor
                            Posicion = NroMayor
                        Else
                            inFPLISECU = Posicion
                        End If
                    Next
                    inFPLISECU = inFPLISECU + 1
                End If

                lblFPLISECU.Text = inFPLISECU

                If (objdatos.fun_Insertar_FIPRLIND(vp_FichaPredial, _
                                                   Me.cboFPLIPUCA.SelectedValue, _
                                                   Me.txtFPLICOLI.Text, _
                                                   vl_stRESODEPA, _
                                                   vl_stRESOMUNI, _
                                                   vl_inRESOTIRE, _
                                                   vl_inRESOCLSE, _
                                                   vl_inRESOVIGE, _
                                                   vl_inRESORESO, _
                                                   inFPLISECU, _
                                                   vl_inFIPRNURE, _
                                                   Me.cboFPLIESTA.SelectedValue)) Then
                    mod_MENSAJE.Se_Guardaron_Los_Datos_Correctamente()

                    If MessageBox.Show("¿ Desea agregar otro registro ?", "Mensaje...", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.No Then
                        cboFPLIPUCA.Focus()
                        Me.Close()
                    End If

                    cboFPLIPUCA.Focus()
                    pro_NumeroDeSecuenciaDeRegistro()
                    pro_ReconsultarLinderos()
                    pro_LimpiarCampos()

                Else
                    mod_MENSAJE.No_Se_Guardo_El_Registro_En_La_Base_De_Datos()

                End If
            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description & "Guardar")
        End Try

    End Sub
    Private Sub cmdCANCELAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSALIR.Click
        cboFPLIPUCA.Focus()
        Me.Close()
    End Sub

#End Region

#Region "FORMULARIO"

#Region "Load"

    Private Sub frm_insertar_FIPRLIND_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Me.strBARRESTA.Items(0).Text = "Linderos"

        pro_ConsultarColindatesPredios()
        pro_ConsultarColindatesPredioUnidad()
        pro_ConsultarColindatesUnidad()

    End Sub

#End Region

#Region "Click"

    Private Sub cboFPLIPUCA_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboFPLIPUCA.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_PUNTCARD(cboFPLIPUCA, cboFPLIPUCA.SelectedIndex)
    End Sub
    Private Sub cmdCubierta_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCubierta.Click

        Dim stArchivo As String = "CUBIERTA"

        Me.txtFPLICOLI.Text = Trim(stArchivo)

    End Sub
    Private Sub cmdSubsuelo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSubsuelo.Click

        Dim stArchivo As String = "SUBSUELO"

        Me.txtFPLICOLI.Text = Trim(stArchivo)

    End Sub
    Private Sub cmdZonaComun_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdZonaComun.Click

        Dim stArchivo As String = "ZONA COMUN"

        Me.txtFPLICOLI.Text = Trim(stArchivo)

    End Sub
    Private Sub cmdCieloAbierto_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCieloAbierto.Click

        Dim stArchivo As String = "CIELO ABIERTO"

        Me.txtFPLICOLI.Text = Trim(stArchivo)

    End Sub
    Private Sub cmdServidumbre_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdServidumbre.Click

        Dim stArchivo As String = "SERVIDUMBRE"

        Me.txtFPLICOLI.Text = Trim(stArchivo)

    End Sub

    Private Sub cmdZonaVerde_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdZonaVerde.Click

        Dim stArchivo As String = "ZONA VERDE"

        Me.txtFPLICOLI.Text = Trim(stArchivo)

    End Sub

#End Region

#Region "SelectedIndexChanged"

    Private Sub cboFPLIPUCA_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboFPLIPUCA.SelectedIndexChanged
        lblFPLIDESC.Text = fun_Buscar_Lista_Valores_PUNTCARD(cboFPLIPUCA.Text)
    End Sub

#End Region

#Region "Validated"

    Private Sub cboFPLIPUCA_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboFPLIPUCA.Validated

        If Trim(cboFPLIPUCA.Text) = "" Then
            cboFPLIPUCA.Focus()
            strBARRESTA.Items(1).Text = IncoValoAlfa
        Else
            strBARRESTA.Items(1).Text = ""
        End If

    End Sub
    Private Sub txtFPLICOLI_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFPLICOLI.Validated

        If Trim(txtFPLICOLI.Text) = "" Then
            txtFPLICOLI.Focus()
            strBARRESTA.Items(1).Text = IncoValoNulo
        Else
            strBARRESTA.Items(1).Text = ""
        End If

    End Sub

#End Region

#Region "KeyPress"

    Private Sub cboFPLIPUCA_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboFPLIPUCA.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            txtFPLICOLI.Focus()
        ElseIf Char.IsLetter(e.KeyChar) Then
            fun_Cargar_ComboBox_Con_Datos_Activos_PUNTCARD(cboFPLIPUCA, cboFPLIPUCA.SelectedIndex)
        End If
    End Sub
    Private Sub txtFPLICOLI_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFPLICOLI.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            cmdGUARDAR.PerformClick()
        End If
    End Sub
    Private Sub cboFPliESTA_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboFPLIESTA.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            cmdGUARDAR.Focus()
        End If
    End Sub

#End Region

#Region "GotFocus"

    Private Sub dgvFIPRLIND_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvFIPRLIND.GotFocus
        strBARRESTA.Items(0).Text = dgvFIPRLIND.AccessibleDescription
    End Sub
    Private Sub cboFPLIPUCA_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboFPLIPUCA.GotFocus
        strBARRESTA.Items(0).Text = cboFPLIPUCA.AccessibleDescription
    End Sub
    Private Sub txtFPLICOLI_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFPLICOLI.GotFocus
        txtFPLICOLI.SelectionStart = 0
        txtFPLICOLI.SelectionLength = Len(txtFPLICOLI.Text)
        strBARRESTA.Items(0).Text = txtFPLICOLI.AccessibleDescription
    End Sub
    Private Sub cboFPLIESTA_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboFPLIESTA.GotFocus
        strBARRESTA.Items(0).Text = cboFPLIESTA.AccessibleDescription
    End Sub
    Private Sub cmdGUARDAR_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdGUARDAR.GotFocus
        strBARRESTA.Items(0).Text = cmdGUARDAR.AccessibleDescription
    End Sub
    Private Sub cmdCANCELAR_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdSALIR.GotFocus
        strBARRESTA.Items(0).Text = cmdSALIR.AccessibleDescription
    End Sub
#End Region

#Region "DoubleClick"

    Private Sub lstFPLICOLI_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles lstFPLICOLI_PREDIO.DoubleClick

        If Me.lstFPLICOLI_PREDIO.SelectedIndex <> -1 Then

            Dim stArchivo As String = Me.lstFPLICOLI_PREDIO.SelectedItem

            Me.txtFPLICOLI.Text = Trim(stArchivo)

        End If

    End Sub
    Private Sub lstFPLICOLI_EDIFICIO_UNIDAD_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles lstFPLICOLI_PREDIO_UNIDAD.DoubleClick

        If Me.lstFPLICOLI_PREDIO_UNIDAD.SelectedIndex <> -1 Then

            Dim stArchivo As String = Me.lstFPLICOLI_PREDIO_UNIDAD.SelectedItem

            Me.txtFPLICOLI.Text = Trim(stArchivo)

        End If

    End Sub
    Private Sub lstFPLICOLI_UNIDAD_UNIDAD_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles lstFPLICOLI_UNIDAD.DoubleClick

        If Me.lstFPLICOLI_UNIDAD.SelectedIndex <> -1 Then

            Dim stArchivo As String = Me.lstFPLICOLI_UNIDAD.SelectedItem

            Me.txtFPLICOLI.Text = Trim(stArchivo)

        End If

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