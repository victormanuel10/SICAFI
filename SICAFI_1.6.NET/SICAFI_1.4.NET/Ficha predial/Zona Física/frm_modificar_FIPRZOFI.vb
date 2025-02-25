Imports REGLAS_DEL_NEGOCIO

Public Class frm_modificar_FIPRZOFI

    '=============================
    '*** MODIFICAR ZONA FÍSICA ***
    '=============================

#Region "CONSTRUCTORES"

    Public Sub New(ByVal inFPZFIDRE As Integer, _
                   ByVal inFIPRNUFI As Integer, _
                   ByVal inFIPRNURE As Integer, _
                   ByVal idRESODEPA As String, _
                   ByVal idRESOMUNI As String, _
                   ByVal idRESOTIRE As Integer, _
                   ByVal idRESOCLSE As Integer, _
                   ByVal idRESOVIGE As Integer, _
                   ByVal idRESORESO As Integer)

        vl_inFPZFIDRE = inFPZFIDRE
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
    Dim vl_inFPZFIDRE As Integer
    Dim vl_inFPZFZOEC As Integer

#End Region

#Region "PROCEDIMIENTOS"

    Private Sub pro_inicializarControles()

        '=================================
        ' CARGA LOS COMBOBOX CON LOS DATOS 
        '=================================

        fun_Cargar_ComboBox_Con_Todos_Los_Datos_ZONAFISI(cboFPZFZOFI, cboFPZFZOFI.SelectedValue, vl_stRESODEPA, vl_stRESOMUNI, vl_inRESOCLSE)
        fun_Cargar_ComboBox_Con_Datos_Activos_ESTADO(cboFPZFESTA, cboFPZFESTA.SelectedValue)

        '==================================
        ' LLENA LOS CAMPOS DE ACUERDO AL ID
        '==================================

        Dim objdatos As New cla_FIPRZOFI
        Dim tbl As New DataTable

        tbl = objdatos.fun_Buscar_ID_FIPRZOFI(vl_inFPZFIDRE)

        cboFPZFZOFI.SelectedValue = Trim(tbl.Rows(0).Item(2))
        txtFPZFPORC.Text = Trim(tbl.Rows(0).Item(3))
        cboFPZFESTA.SelectedValue = tbl.Rows(0).Item(12)

        vl_inFPZFZOEC = Val(Trim(tbl.Rows(0).Item(2)))

        '==========================================================
        ' CARGA LA DESCRIPCIÓN (Los reg. activos ya estan cargados)
        '==========================================================
        Try
            Dim boFPZFZOFI As Boolean = fun_Buscar_Dato_ZONAFISI(Trim(cboFPZFZOFI.Text))

            If boFPZFZOFI = True Then
                lblFPZFDESC.Text = CType(fun_Buscar_Lista_Valores_ZONAFISI(vl_stRESODEPA, vl_stRESOMUNI, vl_inRESOCLSE, Trim(cboFPZFZOFI.Text)), String)
            Else
                frm_INCO_insertar_registro_sin_listas_de_valores.ShowDialog()
            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

        txtFPZFPORC.Focus()

    End Sub
    Private Sub pro_LimpiarCampos()

        txtFPZFPORC.Text = ""
        strBARRESTA.Items(1).Text = ""

    End Sub

#End Region

#Region "MENU"

    Private Sub cmdGUARDAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGUARDAR.Click

        Try
            If fun_Verificar_Campos_Llenos_3_DATOS(cboFPZFZOFI.SelectedValue, txtFPZFPORC.Text, cboFPZFESTA.SelectedValue) = False Then
                mod_MENSAJE.Existen_Campos_Sin_Diligenciar()
                cboFPZFZOFI.Focus()
            Else
                '==========================================================
                ' ESTRAE LA INFORMACIÓN DEL REGISTRO A MODIFICAR ANTES DE..
                '==========================================================

                Dim objdatos As New cla_FIPRZOFI
                Dim tbl As New DataTable

                tbl = objdatos.fun_Buscar_ID_FIPRZOFI(vl_inFPZFIDRE)

                Dim inFPZFSECU As Integer = tbl.Rows(0).Item(10)
                Dim inFPZFNURE As Integer = tbl.Rows(0).Item(11)
                Dim stFPZFUSIN As String = tbl.Rows(0).Item(13)
                Dim daFPZFFEIN As Date = tbl.Rows(0).Item(15)

                If vl_inFPZFZOEC = Val(Trim(cboFPZFZOFI.SelectedValue)) Then

                    If objdatos.fun_Actualizar_FIPRZOFI(vl_inFPZFIDRE, _
                                                        vp_FichaPredial, _
                                                        cboFPZFZOFI.SelectedValue, _
                                                        txtFPZFPORC.Text, _
                                                        vl_stRESODEPA, _
                                                        vl_stRESOMUNI, _
                                                        vl_inRESOTIRE, _
                                                        vl_inRESOCLSE, _
                                                        vl_inRESOVIGE, _
                                                        vl_inRESORESO, _
                                                        inFPZFSECU, _
                                                        inFPZFNURE, _
                                                        cboFPZFESTA.SelectedValue, _
                                                        stFPZFUSIN, _
                                                        daFPZFFEIN) = True Then

                        mod_MENSAJE.Se_Guardaron_Los_Datos_Correctamente()
                        cboFPZFZOFI.Focus()
                        Me.Close()
                    Else
                        mod_MENSAJE.No_Se_Guardo_El_Registro_En_La_Base_De_Datos()
                        cboFPZFZOFI.Focus()
                    End If
                Else
                    '=======================================
                    ' BUSCA EL DESTINO EN LA BD SI YA EXISTE
                    '=======================================

                    Dim objdatos12 As New cla_FIPRZOFI
                    Dim tbl12 As New DataTable

                    tbl12 = objdatos12.fun_Buscar_CODIGO_FIPRZOFI(vp_FichaPredial, Val(Trim(cboFPZFZOFI.SelectedValue)))

                    If tbl12.Rows.Count > 0 Then
                        mod_MENSAJE.Codigo_Existente_En_Base_De_Datos()
                        cboFPZFZOFI.Focus()
                    Else

                        If objdatos.fun_Actualizar_FIPRZOFI(vl_inFPZFIDRE, _
                                                            vp_FichaPredial, _
                                                            cboFPZFZOFI.SelectedValue, _
                                                            txtFPZFPORC.Text, _
                                                            vl_stRESODEPA, _
                                                            vl_stRESOMUNI, _
                                                            vl_inRESOTIRE, _
                                                            vl_inRESOCLSE, _
                                                            vl_inRESOVIGE, _
                                                            vl_inRESORESO, _
                                                            inFPZFSECU, _
                                                            inFPZFNURE, _
                                                            cboFPZFESTA.SelectedValue, _
                                                            stFPZFUSIN, _
                                                            daFPZFFEIN) = True Then

                            mod_MENSAJE.Se_Guardaron_Los_Datos_Correctamente()
                            cboFPZFZOFI.Focus()
                            Me.Close()
                        Else
                            mod_MENSAJE.No_Se_Guardo_El_Registro_En_La_Base_De_Datos()
                            cboFPZFZOFI.Focus()
                        End If
                    End If
                End If
            End If


        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub cmdCANCELAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSALIR.Click
        txtFPZFPORC.Focus()
        Me.Close()
    End Sub

#End Region

#Region "FORMULARIO"

#Region "KeyPress"

    Private Sub cboFPZFZOFI_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboFPZFZOFI.KeyPress
        If fun_Verificar_Dato_Numerico_Evento_KeyPress(Short.Parse(Asc(e.KeyChar))) = False Then
            e.Handled = True
        ElseIf e.KeyChar = Convert.ToChar(Keys.Enter) Then
            txtFPZFPORC.Focus()
        End If

        If Char.IsNumber(e.KeyChar) Then
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
        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            cmdGUARDAR.Focus()
        End If
    End Sub

#End Region

#Region "GotFocus"

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

#Region "SelectedIndexChanged"

    Private Sub cboFPZFZOFI_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboFPZFZOFI.SelectedIndexChanged
        lblFPZFDESC.Text = CType(fun_Buscar_Lista_Valores_ZONAFISI(vl_stRESODEPA, vl_stRESOMUNI, vl_inRESOCLSE, cboFPZFZOFI.Text), String)
    End Sub

#End Region

#Region "Click"

    Private Sub cboFPZFZOFI_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboFPZFZOFI.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_ZONAFISI(cboFPZFZOFI, cboFPZFZOFI.SelectedIndex, vl_stRESODEPA, vl_stRESOMUNI, vl_inRESOCLSE)
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