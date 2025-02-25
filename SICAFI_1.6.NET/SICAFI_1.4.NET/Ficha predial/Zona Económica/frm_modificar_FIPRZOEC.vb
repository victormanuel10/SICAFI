Imports REGLAS_DEL_NEGOCIO

Public Class frm_modificar_FIPRZOEC

    '================================
    '*** MODIFICAR ZONA ECONÓMICA ***
    '================================

#Region "CONSTRUCTORES"

    Public Sub New(ByVal inFPZEIDRE As Integer, _
                   ByVal inFIPRNUFI As Integer, _
                   ByVal inFIPRNURE As Integer, _
                   ByVal idRESODEPA As String, _
                   ByVal idRESOMUNI As String, _
                   ByVal idRESOTIRE As Integer, _
                   ByVal idRESOCLSE As Integer, _
                   ByVal idRESOVIGE As Integer, _
                   ByVal idRESORESO As Integer)

        vl_inFPZEIDRE = inFPZEIDRE
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
    Dim vl_inFPZEIDRE As Integer
    Dim vl_inFPZEZOEC As Integer

#End Region

#Region "PROCEDIMIENTOS"

    Private Sub pro_inicializarControles()

        '=================================
        ' CARGA LOS COMBOBOX CON LOS DATOS 
        '=================================

        fun_Cargar_ComboBox_Con_Todos_Los_Datos_ZONAECON(cboFPZEZOEC, cboFPZEZOEC.SelectedValue, vl_stRESODEPA, vl_stRESOMUNI, vl_inRESOCLSE)
        fun_Cargar_ComboBox_Con_Datos_Activos_ESTADO(cboFPZEESTA, cboFPZEESTA.SelectedValue)

        '==================================
        ' LLENA LOS CAMPOS DE ACUERDO AL ID
        '==================================

        Dim objdatos As New cla_FIPRZOEC
        Dim tbl As New DataTable

        tbl = objdatos.fun_Buscar_ID_FIPRZOEC(vl_inFPZEIDRE)

        cboFPZEZOEC.SelectedValue = Trim(tbl.Rows(0).Item(2))
        txtFPZEPORC.Text = Trim(tbl.Rows(0).Item(3))
        cboFPZEESTA.SelectedValue = tbl.Rows(0).Item(12)

        vl_inFPZEZOEC = Val(Trim(tbl.Rows(0).Item(2)))

        '==========================================================
        ' CARGA LA DESCRIPCIÓN (Los reg. activos ya estan cargados)
        '==========================================================
        Try
            Dim boFPZEZOEC As Boolean = fun_Buscar_Dato_ZONAECON(Trim(cboFPZEZOEC.Text))

            If boFPZEZOEC = True Then
                lblFPZEDESC.Text = CType(fun_Buscar_Lista_Valores_ZONAECON(vl_stRESODEPA, vl_stRESOMUNI, vl_inRESOCLSE, Trim(cboFPZEZOEC.Text)), String)
            Else
                frm_INCO_insertar_registro_sin_listas_de_valores.ShowDialog()
            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

        txtFPZEPORC.Focus()

    End Sub
    Private Sub pro_LimpiarCampos()

        txtFPZEPORC.Text = ""
        strBARRESTA.Items(1).Text = ""

    End Sub

#End Region

#Region "MENU"

    Private Sub cmdGUARDAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGUARDAR.Click

        Try
            If fun_Verificar_Campos_Llenos_3_DATOS(cboFPZEZOEC.SelectedValue, txtFPZEPORC.Text, cboFPZEESTA.SelectedValue) = False Then
                mod_MENSAJE.Existen_Campos_Sin_Diligenciar()
                cboFPZEZOEC.Focus()
            Else
                '==========================================================
                ' ESTRAE LA INFORMACIÓN DEL REGISTRO A MODIFICAR ANTES DE..
                '==========================================================

                Dim objdatos As New cla_FIPRZOEC
                Dim tbl As New DataTable

                tbl = objdatos.fun_Buscar_ID_FIPRZOEC(vl_inFPZEIDRE)

                Dim inFPZESECU As Integer = tbl.Rows(0).Item(10)
                Dim inFPZENURE As Integer = tbl.Rows(0).Item(11)
                Dim stFPZEUSIN As String = tbl.Rows(0).Item(13)
                Dim daFPZEFEIN As Date = tbl.Rows(0).Item(15)

                If vl_inFPZEZOEC = Val(Trim(cboFPZEZOEC.SelectedValue)) Then

                    If objdatos.fun_Actualizar_FIPRZOEC(vl_inFPZEIDRE, _
                                                        vp_FichaPredial, _
                                                        cboFPZEZOEC.SelectedValue, _
                                                        txtFPZEPORC.Text, _
                                                        vl_stRESODEPA, _
                                                        vl_stRESOMUNI, _
                                                        vl_inRESOTIRE, _
                                                        vl_inRESOCLSE, _
                                                        vl_inRESOVIGE, _
                                                        vl_inRESORESO, _
                                                        inFPZESECU, _
                                                        inFPZENURE, _
                                                        cboFPZEESTA.SelectedValue, _
                                                        stFPZEUSIN, _
                                                        daFPZEFEIN) = True Then

                        mod_MENSAJE.Se_Guardaron_Los_Datos_Correctamente()
                        cboFPZEZOEC.Focus()
                        Me.Close()
                    Else
                        mod_MENSAJE.No_Se_Guardo_El_Registro_En_La_Base_De_Datos()
                        cboFPZEZOEC.Focus()
                    End If
                Else
                    '=======================================
                    ' BUSCA EL DESTINO EN LA BD SI YA EXISTE
                    '=======================================

                    Dim objdatos12 As New cla_FIPRZOEC
                    Dim tbl12 As New DataTable

                    tbl12 = objdatos12.fun_Buscar_CODIGO_FIPRZOEC(vp_FichaPredial, Val(Trim(cboFPZEZOEC.SelectedValue)))

                    If tbl12.Rows.Count > 0 Then
                        mod_MENSAJE.Codigo_Existente_En_Base_De_Datos()
                        cboFPZEZOEC.Focus()
                    Else

                        If objdatos.fun_Actualizar_FIPRZOEC(vl_inFPZEIDRE, _
                                                            vp_FichaPredial, _
                                                            cboFPZEZOEC.SelectedValue, _
                                                            txtFPZEPORC.Text, _
                                                            vl_stRESODEPA, _
                                                            vl_stRESOMUNI, _
                                                            vl_inRESOTIRE, _
                                                            vl_inRESOCLSE, _
                                                            vl_inRESOVIGE, _
                                                            vl_inRESORESO, _
                                                            inFPZESECU, _
                                                            inFPZENURE, _
                                                            cboFPZEESTA.SelectedValue, _
                                                            stFPZEUSIN, _
                                                            daFPZEFEIN) = True Then

                            mod_MENSAJE.Se_Guardaron_Los_Datos_Correctamente()
                            cboFPZEZOEC.Focus()
                            Me.Close()
                        Else
                            mod_MENSAJE.No_Se_Guardo_El_Registro_En_La_Base_De_Datos()
                            cboFPZEZOEC.Focus()
                        End If
                    End If
                End If
            End If


        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub cmdCANCELAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSALIR.Click
        txtFPZEPORC.Focus()
        Me.Close()
    End Sub

#End Region

#Region "FORMULARIO"

#Region "KeyPress"

    Private Sub cboFPZEZOEC_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboFPZEZOEC.KeyPress
        If fun_Verificar_Dato_Numerico_Evento_KeyPress(Short.Parse(Asc(e.KeyChar))) = False Then
            e.Handled = True
        ElseIf e.KeyChar = Convert.ToChar(Keys.Enter) Then
            txtFPZEPORC.Focus()
        End If

        If Char.IsNumber(e.KeyChar) Then
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
        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            cmdGUARDAR.Focus()
        End If
    End Sub

#End Region

#Region "GotFocus"

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

#Region "SelectedIndexChanged"

    Private Sub cboFPZEZOEC_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboFPZEZOEC.SelectedIndexChanged
        lblFPZEDESC.Text = CType(fun_Buscar_Lista_Valores_ZONAECON(vl_stRESODEPA, vl_stRESOMUNI, vl_inRESOCLSE, cboFPZEZOEC.Text), String)
    End Sub

#End Region

#Region "Click"

    Private Sub cboFPZEZOEC_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboFPZEZOEC.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_ZONAECON(cboFPZEZOEC, cboFPZEZOEC.SelectedIndex, vl_stRESODEPA, vl_stRESOMUNI, vl_inRESOCLSE)
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