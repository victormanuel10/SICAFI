Imports REGLAS_DEL_NEGOCIO

Public Class frm_modificar_FIPRDEEC

    '=======================================
    '*** MODIFICAR DESTINACIÓN ECONÓMICA ***
    '=======================================

#Region "CONSTRUCTORES"

    Public Sub New(ByVal inFPDEIDRE As Integer, ByVal inFIPRNUFI As Integer, ByVal inFIPRNURE As Integer, ByVal idRESODEPA As String, ByVal idRESOMUNI As String, ByVal idRESOTIRE As Integer, ByVal idRESOCLSE As Integer, ByVal idRESOVIGE As Integer, ByVal idRESORESO As Integer)

        vl_inFPDEIDRE = inFPDEIDRE
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
    Dim vl_inFPDEIDRE As Integer
    Dim vl_inFPDEDEEC As Integer

#End Region

#Region "PROCEDIMIENTOS"

    Private Sub pro_inicializarControles()

        '=================================
        ' CARGA LOS COMBOBOX CON LOS DATOS 
        '=================================

        fun_Cargar_ComboBox_Con_Todos_Los_Datos_DESTECON(cboFPDEDEEC, cboFPDEDEEC.SelectedValue)
        fun_Cargar_ComboBox_Con_Datos_Activos_ESTADO(cboFPDEESTA, cboFPDEESTA.SelectedValue)

        '==================================
        ' LLENA LOS CAMPOS DE ACUERDO AL ID
        '==================================

        Dim objdatos As New cla_FIPRDEEC
        Dim tbl As New DataTable

        tbl = objdatos.fun_Buscar_ID_FIPRDEEC(vl_inFPDEIDRE)

        cboFPDEDEEC.SelectedValue = Trim(tbl.Rows(0).Item(2))
        txtFPDEPORC.Text = Trim(tbl.Rows(0).Item(3))
        cboFPDEESTA.SelectedValue = tbl.Rows(0).Item(12)

        vl_inFPDEDEEC = Val(Trim(tbl.Rows(0).Item(2)))

        '==========================================================
        ' CARGA LA DESCRIPCIÓN (Los reg. activos ya estan cargados)
        '==========================================================
        Try
            Dim boFPDEDEEC As Boolean = fun_Buscar_Dato_DESTECON(Trim(cboFPDEDEEC.Text))

            If boFPDEDEEC = True Then
                lblFPDEDESC.Text = CType(fun_Buscar_Lista_Valores_DESTECON(Trim(cboFPDEDEEC.Text)), String)
            Else
                frm_INCO_insertar_registro_sin_listas_de_valores.ShowDialog()
            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

        txtFPDEPORC.Focus()

    End Sub
    Private Sub pro_LimpiarCampos()

        txtFPDEPORC.Text = ""
        strBARRESTA.Items(1).Text = ""

    End Sub

#End Region

#Region "MENU"

    Private Sub cmdGUARDAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGUARDAR.Click

        Try
            If fun_Verificar_Campos_Llenos_3_DATOS(cboFPDEDEEC.SelectedValue, txtFPDEPORC.Text, cboFPDEESTA.SelectedValue) = False Then
                mod_MENSAJE.Existen_Campos_Sin_Diligenciar()
                cboFPDEDEEC.Focus()
            Else
                '==========================================================
                ' ESTRAE LA INFORMACIÓN DEL REGISTRO A MODIFICAR ANTES DE..
                '==========================================================

                Dim objdatos As New cla_FIPRDEEC
                Dim tbl As New DataTable

                tbl = objdatos.fun_Buscar_ID_FIPRDEEC(vl_inFPDEIDRE)

                Dim inFPDESECU As Integer = tbl.Rows(0).Item(10)
                Dim inFPDENURE As Integer = tbl.Rows(0).Item(11)
                Dim stFPDEUSIN As String = tbl.Rows(0).Item(13)
                Dim daFPDEFEIN As Date = tbl.Rows(0).Item(15)

                If vl_inFPDEDEEC = Val(Trim(cboFPDEDEEC.SelectedValue)) Then

                    If objdatos.fun_Actualizar_FIPRDEEC(vl_inFPDEIDRE, _
                                                        vp_FichaPredial, _
                                                        cboFPDEDEEC.SelectedValue, _
                                                        txtFPDEPORC.Text, _
                                                        vl_stRESODEPA, _
                                                        vl_stRESOMUNI, _
                                                        vl_inRESOTIRE, _
                                                        vl_inRESOCLSE, _
                                                        vl_inRESOVIGE, _
                                                        vl_inRESORESO, _
                                                        inFPDESECU, _
                                                        inFPDENURE, _
                                                        cboFPDEESTA.SelectedValue, _
                                                        stFPDEUSIN, _
                                                        daFPDEFEIN) = True Then

                        mod_MENSAJE.Se_Guardaron_Los_Datos_Correctamente()
                        cboFPDEDEEC.Focus()
                        Me.Close()
                    Else
                        mod_MENSAJE.No_Se_Guardo_El_Registro_En_La_Base_De_Datos()
                        cboFPDEDEEC.Focus()
                    End If
                Else
                    '=======================================
                    ' BUSCA EL DESTINO EN LA BD SI YA EXISTE
                    '=======================================

                    Dim objdatos12 As New cla_FIPRDEEC
                    Dim tbl12 As New DataTable

                    tbl12 = objdatos12.fun_Buscar_CODIGO_FIPRDEEC(vp_FichaPredial, Val(Trim(cboFPDEDEEC.SelectedValue)))

                    If tbl12.Rows.Count > 0 Then
                        mod_MENSAJE.Codigo_Existente_En_Base_De_Datos()
                        cboFPDEDEEC.Focus()
                    Else

                        If objdatos.fun_Actualizar_FIPRDEEC(vl_inFPDEIDRE, _
                                                            vp_FichaPredial, _
                                                            cboFPDEDEEC.SelectedValue, _
                                                            txtFPDEPORC.Text, _
                                                            vl_stRESODEPA, _
                                                            vl_stRESOMUNI, _
                                                            vl_inRESOTIRE, _
                                                            vl_inRESOCLSE, _
                                                            vl_inRESOVIGE, _
                                                            vl_inRESORESO, _
                                                            inFPDESECU, _
                                                            inFPDENURE, _
                                                            cboFPDEESTA.SelectedValue, _
                                                            stFPDEUSIN, _
                                                            daFPDEFEIN) = True Then

                            mod_MENSAJE.Se_Guardaron_Los_Datos_Correctamente()
                            cboFPDEDEEC.Focus()
                            Me.Close()
                        Else
                            mod_MENSAJE.No_Se_Guardo_El_Registro_En_La_Base_De_Datos()
                            cboFPDEDEEC.Focus()
                        End If
                    End If
                End If
            End If


        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub cmdCANCELAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSALIR.Click
        txtFPDEPORC.Focus()
        Me.Close()
    End Sub

#End Region

#Region "FORMULARIO"

#Region "KeyPress"

    Private Sub cboFPDEDEEC_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboFPDEDEEC.KeyPress
        If fun_Verificar_Dato_Numerico_Evento_KeyPress(Short.Parse(Asc(e.KeyChar))) = False Then
            e.Handled = True
        ElseIf e.KeyChar = Convert.ToChar(Keys.Enter) Then
            txtFPDEPORC.Focus()
        End If

        If Char.IsNumber(e.KeyChar) Then
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
        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            cmdGUARDAR.Focus()
        End If
    End Sub

#End Region

#Region "GotFocus"

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

#Region "SelectedIndexChanged"

    Private Sub cboFPDEDEEC_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboFPDEDEEC.SelectedIndexChanged
        lblFPDEDESC.Text = CType(fun_Buscar_Lista_Valores_DESTECON(cboFPDEDEEC.Text), String)
    End Sub

#End Region

#Region "Click"

    Private Sub cboFPDEDEEC_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboFPDEDEEC.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_DESTECON(cboFPDEDEEC, cboFPDEDEEC.SelectedIndex)
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