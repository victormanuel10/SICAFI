Imports REGLAS_DEL_NEGOCIO

Public Class frm_modificar_FIPRLIND

    '=====================================
    '*** FORMULARIO MODIFICAR LINDEROS ***
    '=====================================

#Region "CONSTRUCTORES"

    Public Sub New(ByVal inFPLIIDRE As Integer, _
                   ByVal inFIPRNUFI As Integer, _
                   ByVal inFIPRNURE As Integer, _
                   ByVal idRESODEPA As String, _
                   ByVal idRESOMUNI As String, _
                   ByVal idRESOTIRE As Integer, _
                   ByVal idRESOCLSE As Integer, _
                   ByVal idRESOVIGE As Integer, _
                   ByVal idRESORESO As Integer)

        vl_inFPLIIDRE = inFPLIIDRE
        vp_FichaPredial = inFIPRNUFI
        vl_inFIPRNURE = inFIPRNURE
        vl_stRESODEPA = idRESODEPA
        vl_stRESOMUNI = idRESOMUNI
        vl_inRESOTIRE = idRESOTIRE
        vl_inRESOCLSE = idRESOCLSE
        vl_inRESOVIGE = idRESOVIGE
        vl_inRESORESO = idRESORESO

        InitializeComponent()
        pro_inicializarControles()

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
    Dim vl_inFPLIIDRE As Integer
    Dim vl_inFPLIPUCA As Integer

    Private dt As New DataTable

#End Region

#Region "PROCEDIMIENTOS"

    Private Sub pro_inicializarControles()

        '=================================
        ' CARGA LOS COMBOBOX CON LOS DATOS 
        '=================================

        fun_Cargar_ComboBox_Con_Todos_Los_Datos_PUNTCARD(cboFPLIPUCA, cboFPLIPUCA.SelectedValue)
        fun_Cargar_ComboBox_Con_Datos_Activos_ESTADO(cboFPLIESTA, cboFPLIESTA.SelectedValue)

        '==================================
        ' LLENA LOS CAMPOS DE ACUERDO AL ID
        '==================================

        Dim objdatos As New cla_FIPRLIND
        Dim tbl As New DataTable

        tbl = objdatos.fun_Buscar_ID_FIPRLIND(vl_inFPLIIDRE)

        cboFPLIPUCA.SelectedValue = Trim(tbl.Rows(0).Item(2))
        txtFPLICOLI.Text = Trim(tbl.Rows(0).Item(3))
        cboFPLIESTA.SelectedValue = tbl.Rows(0).Item(12)

        vl_inFPLIPUCA = Val(Trim(tbl.Rows(0).Item(2)))

        '==========================================================
        ' CARGA LA DESCRIPCIÓN (Los reg. activos ya estan cargados)
        '==========================================================
        Try
            Dim boFPLIPUCA As Boolean = fun_Buscar_Dato_PUNTCARD(Trim(cboFPLIPUCA.Text))

            If boFPLIPUCA = True Then
                lblFPLIDESC.Text = CType(fun_Buscar_Lista_Valores_PUNTCARD(Trim(cboFPLIPUCA.Text)), String)
            Else
                frm_INCO_insertar_registro_sin_listas_de_valores.ShowDialog()
            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

        txtFPLICOLI.Focus()

    End Sub
    Private Sub pro_LimpiarCampos()

        Me.txtFPLICOLI.Text = ""
        Me.strBARRESTA.Items(1).Text = ""

        Me.lstFPLICOLI_PREDIO.Items.Clear()
        Me.lstFPLICOLI_PREDIO_UNIDAD.Items.Clear()
        Me.lstFPLICOLI_UNIDAD.Items.Clear()

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
            If fun_Verificar_Campos_Llenos_3_DATOS(cboFPLIPUCA.SelectedValue, _
                                                   txtFPLICOLI.Text, _
                                                   cboFPLIESTA.SelectedValue) = False Then
                mod_MENSAJE.Existen_Campos_Sin_Diligenciar()
                cboFPLIPUCA.Focus()
            Else
                '==========================================================
                ' ESTRAE LA INFORMACIÓN DEL REGISTRO A MODIFICAR ANTES DE..
                '==========================================================

                Dim objdatos As New cla_FIPRLIND
                Dim tbl As New DataTable

                tbl = objdatos.fun_Buscar_ID_FIPRLIND(vl_inFPLIIDRE)

                Dim inFPLISECU As Integer = tbl.Rows(0).Item(10)
                Dim inFPLINURE As Integer = tbl.Rows(0).Item(11)
                Dim stFPLIUSIN As String = tbl.Rows(0).Item(13)
                Dim daFPLIFEIN As Date = tbl.Rows(0).Item(15)

                If objdatos.fun_Actualizar_FIPRLIND(vl_inFPLIIDRE, _
                                                    vp_FichaPredial, _
                                                    Trim(cboFPLIPUCA.SelectedValue), _
                                                    Trim(txtFPLICOLI.Text), _
                                                    vl_stRESODEPA, _
                                                    vl_stRESOMUNI, _
                                                    vl_inRESOTIRE, _
                                                    vl_inRESOCLSE, _
                                                    vl_inRESOVIGE, _
                                                    vl_inRESORESO, _
                                                    inFPLISECU, _
                                                    inFPLINURE, _
                                                    cboFPLIESTA.SelectedValue, _
                                                    stFPLIUSIN, _
                                                    daFPLIFEIN) = True Then

                    mod_MENSAJE.Se_Guardaron_Los_Datos_Correctamente()
                    cboFPLIPUCA.Focus()
                    Me.Close()
                Else
                    mod_MENSAJE.No_Se_Guardo_El_Registro_En_La_Base_De_Datos()
                    cboFPLIPUCA.Focus()
                End If

            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub cmdCANCELAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSALIR.Click
        txtFPLICOLI.Focus()
        Me.Close()
    End Sub

#End Region

#Region "FORMULARIO"

#Region "Load"

    Private Sub frm_modificar_FIPRLIND_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        pro_ConsultarColindatesPredios()
        pro_ConsultarColindatesPredioUnidad()
        pro_ConsultarColindatesUnidad()

    End Sub

#End Region

#Region "KeyPress"

    Private Sub cboFPLIPUCA_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboFPLIPUCA.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            txtFPLICOLI.Focus()
        End If
    End Sub
    Private Sub txtFPLICOLI_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFPLICOLI.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            cboFPLIESTA.Focus()
        End If
    End Sub
    Private Sub cboFPLIESTA_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboFPLIESTA.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            cmdGUARDAR.Focus()
        End If
    End Sub

#End Region

#Region "GotFocus"

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

#Region "Click"

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

#End Region

#Region "DoubleClick"

    Private Sub lstFPLICOLI_PREDIO_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles lstFPLICOLI_PREDIO.DoubleClick

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

#Region "SelectedIndexChanged"

    Private Sub cboFPLIPUCA_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboFPLIPUCA.SelectedIndexChanged
        lblFPLIDESC.Text = CType(fun_Buscar_Lista_Valores_PUNTCARD(cboFPLIPUCA.Text), String)
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