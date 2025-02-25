Imports REGLAS_DEL_NEGOCIO

Public Class frm_Historico_De_Zonas

    '===================================================
    ' *** HISTORICO DE ZONAS FICHA PREDIAL Y RESUMEN ***
    '===================================================

#Region "VARIABLES"

    Dim vl_stFIPRDEPA As String
    Dim vl_inFIPRNUFI As Integer
    Dim vl_stFIPRMUNI As String
    Dim vl_stFIPRCORR As String
    Dim vl_stFIPRBARR As String
    Dim vl_stFIPRMANZ As String
    Dim vl_stFIPRPRED As String
    Dim vl_stFIPREDIF As String
    Dim vl_stFIPRUNPR As String
    Dim vl_inFIPRCLSE As Integer
    Dim vl_inFIPRTIFI As Integer

#End Region

#Region "CONSTRUCTOR"

    Public Sub New(ByVal inFIPRNUFI As Integer)

        vl_inFIPRNUFI = inFIPRNUFI

        InitializeComponent()
        pro_LimpiarCampos()
        pro_Reconsultar()

    End Sub

#End Region

#Region "PROCEDIMIENTO"

    Private Sub pro_Reconsultar()

        Try
            Dim objdatos0 As New cla_FICHPRED
            Dim tbl0 As New DataTable

            tbl0 = objdatos0.fun_Consultar_FICHA_PREDIAL_X_NRO_FICHA_PREDIAL(vl_inFIPRNUFI)

            If tbl0.Rows.Count > 0 Then

                ' variables de ficha predial
                vl_stFIPRDEPA = "05"
                vl_stFIPRMUNI = Trim(tbl0.Rows(0).Item("FIPRMUNI"))
                vl_stFIPRCORR = Trim(tbl0.Rows(0).Item("FIPRCORR"))
                vl_stFIPRBARR = Trim(tbl0.Rows(0).Item("FIPRBARR"))
                vl_stFIPRMANZ = Trim(tbl0.Rows(0).Item("FIPRMANZ"))
                vl_stFIPRPRED = Trim(tbl0.Rows(0).Item("FIPRPRED"))
                vl_stFIPREDIF = Trim(tbl0.Rows(0).Item("FIPREDIF"))
                vl_stFIPRUNPR = Trim(tbl0.Rows(0).Item("FIPRUNPR"))
                vl_inFIPRCLSE = Trim(tbl0.Rows(0).Item("FIPRCLSE"))

                ' consulta zona económica ficha predial
                Dim obj_ZonaEconomicaPredial As New cla_HISTZONA
                Dim tbl_ZonaEconomicaPredial As New DataTable

                tbl_ZonaEconomicaPredial = obj_ZonaEconomicaPredial.fun_Consultar_CEDULA_CATASTRAL_X_HISTZONA(vl_stFIPRDEPA, vl_stFIPRMUNI, vl_stFIPRCORR, vl_stFIPRBARR, vl_stFIPRMANZ, vl_stFIPRPRED, vl_stFIPREDIF, vl_stFIPRUNPR, vl_inFIPRCLSE, "0")

                If tbl_ZonaEconomicaPredial.Rows.Count > 0 Then

                    Me.dgvZOECFIP0.DataSource = tbl_ZonaEconomicaPredial

                    Me.dgvZOECFIP0.Columns("HIZOVIGE").HeaderText = "Vigencia"
                    Me.dgvZOECFIP0.Columns("HIZOZOEC").HeaderText = "Zona Economica"
                    Me.dgvZOECFIP0.Columns("HIZOPORC").HeaderText = "Porcentaje(%)"
                    Me.dgvZOECFIP0.Columns("HIZOESTA").HeaderText = "Estado"

                    Me.dgvZOECFIP0.Columns("HIZOIDRE").Visible = False
                    Me.dgvZOECFIP0.Columns("HIZONUFI").Visible = False
                    Me.dgvZOECFIP0.Columns("HIZODEPA").Visible = False
                    Me.dgvZOECFIP0.Columns("HIZOMUNI").Visible = False
                    Me.dgvZOECFIP0.Columns("HIZOCORR").Visible = False
                    Me.dgvZOECFIP0.Columns("HIZOBARR").Visible = False
                    Me.dgvZOECFIP0.Columns("HIZOMANZ").Visible = False
                    Me.dgvZOECFIP0.Columns("HIZOPRED").Visible = False
                    Me.dgvZOECFIP0.Columns("HIZOEDIF").Visible = False
                    Me.dgvZOECFIP0.Columns("HIZOUNPR").Visible = False
                    Me.dgvZOECFIP0.Columns("HIZOTIFI").Visible = False
                    Me.dgvZOECFIP0.Columns("HIZOCLSE").Visible = False

                End If

                ' consulta zona económica ficha resumen
                Dim obj_ZonaEconomicaResumen As New cla_HISTZONA
                Dim tbl_ZonaEconomicaResumen As New DataTable

                tbl_ZonaEconomicaResumen = obj_ZonaEconomicaResumen.fun_Consultar_CEDULA_CATASTRAL_X_HISTZONA(vl_stFIPRDEPA, vl_stFIPRMUNI, vl_stFIPRCORR, vl_stFIPRBARR, vl_stFIPRMANZ, vl_stFIPRPRED, vl_stFIPREDIF, "00000", vl_inFIPRCLSE, "2")

                If tbl_ZonaEconomicaResumen.Rows.Count > 0 Then

                    Me.dgvZOECFIP2.DataSource = tbl_ZonaEconomicaResumen

                    Me.dgvZOECFIP2.Columns("HIZOVIGE").HeaderText = "Vigencia"
                    Me.dgvZOECFIP2.Columns("HIZOZOEC").HeaderText = "Zona Economica"
                    Me.dgvZOECFIP2.Columns("HIZOPORC").HeaderText = "Porcentaje(%)"
                    Me.dgvZOECFIP2.Columns("HIZOESTA").HeaderText = "Estado"

                    Me.dgvZOECFIP2.Columns("HIZOIDRE").Visible = False
                    Me.dgvZOECFIP2.Columns("HIZONUFI").Visible = False
                    Me.dgvZOECFIP2.Columns("HIZODEPA").Visible = False
                    Me.dgvZOECFIP2.Columns("HIZOMUNI").Visible = False
                    Me.dgvZOECFIP2.Columns("HIZOCORR").Visible = False
                    Me.dgvZOECFIP2.Columns("HIZOBARR").Visible = False
                    Me.dgvZOECFIP2.Columns("HIZOMANZ").Visible = False
                    Me.dgvZOECFIP2.Columns("HIZOPRED").Visible = False
                    Me.dgvZOECFIP2.Columns("HIZOEDIF").Visible = False
                    Me.dgvZOECFIP2.Columns("HIZOUNPR").Visible = False
                    Me.dgvZOECFIP2.Columns("HIZOTIFI").Visible = False
                    Me.dgvZOECFIP2.Columns("HIZOCLSE").Visible = False

                End If

                ' consulta zona fisica ficha predial
                Dim obj_ZonaFisicaPredial As New cla_HISTZOFI
                Dim tbl_ZonaFisicaPredial As New DataTable

                tbl_ZonaFisicaPredial = obj_ZonaFisicaPredial.fun_Consultar_CEDULA_CATASTRAL_X_HISTZOFI(vl_stFIPRDEPA, vl_stFIPRMUNI, vl_stFIPRCORR, vl_stFIPRBARR, vl_stFIPRMANZ, vl_stFIPRPRED, vl_stFIPREDIF, vl_stFIPRUNPR, vl_inFIPRCLSE, "0")

                If tbl_ZonaFisicaPredial.Rows.Count > 0 Then

                    Me.dgvZOECFIP0.DataSource = tbl_ZonaFisicaPredial

                    Me.dgvZOECFIP0.Columns("HIZFVIGE").HeaderText = "Vigencia"
                    Me.dgvZOECFIP0.Columns("HIZFZOEC").HeaderText = "Zona Fisica"
                    Me.dgvZOECFIP0.Columns("HIZFPORC").HeaderText = "Porcentaje(%)"
                    Me.dgvZOECFIP0.Columns("HIZFESTA").HeaderText = "Estado"

                    Me.dgvZOECFIP0.Columns("HIZFIDRE").Visible = False
                    Me.dgvZOECFIP0.Columns("HIZFNUFI").Visible = False
                    Me.dgvZOECFIP0.Columns("HIZFDEPA").Visible = False
                    Me.dgvZOECFIP0.Columns("HIZFMUNI").Visible = False
                    Me.dgvZOECFIP0.Columns("HIZFCORR").Visible = False
                    Me.dgvZOECFIP0.Columns("HIZFBARR").Visible = False
                    Me.dgvZOECFIP0.Columns("HIZFMANZ").Visible = False
                    Me.dgvZOECFIP0.Columns("HIZFPRED").Visible = False
                    Me.dgvZOECFIP0.Columns("HIZFEDIF").Visible = False
                    Me.dgvZOECFIP0.Columns("HIZFUNPR").Visible = False
                    Me.dgvZOECFIP0.Columns("HIZFTIFI").Visible = False
                    Me.dgvZOECFIP0.Columns("HIZFCLSE").Visible = False

                End If

                ' consulta zona económica ficha resumen
                Dim obj_ZonaFisicaResumen As New cla_HISTZOFI
                Dim tbl_ZonaFisicaResumen As New DataTable

                tbl_ZonaFisicaResumen = obj_ZonaFisicaResumen.fun_Consultar_CEDULA_CATASTRAL_X_HISTZOFI(vl_stFIPRDEPA, vl_stFIPRMUNI, vl_stFIPRCORR, vl_stFIPRBARR, vl_stFIPRMANZ, vl_stFIPRPRED, vl_stFIPREDIF, "00000", vl_inFIPRCLSE, "2")

                If tbl_ZonaFisicaResumen.Rows.Count > 0 Then

                    Me.dgvZOECFIP2.DataSource = tbl_ZonaFisicaResumen

                    Me.dgvZOECFIP2.Columns("HIZFVIGE").HeaderText = "Vigencia"
                    Me.dgvZOECFIP2.Columns("HIZFZOEC").HeaderText = "Zona Fisica"
                    Me.dgvZOECFIP2.Columns("HIZFPORC").HeaderText = "Porcentaje(%)"
                    Me.dgvZOECFIP2.Columns("HIZFESTA").HeaderText = "Estado"

                    Me.dgvZOECFIP2.Columns("HIZFIDRE").Visible = False
                    Me.dgvZOECFIP2.Columns("HIZFNUFI").Visible = False
                    Me.dgvZOECFIP2.Columns("HIZFDEPA").Visible = False
                    Me.dgvZOECFIP2.Columns("HIZFMUNI").Visible = False
                    Me.dgvZOECFIP2.Columns("HIZFCORR").Visible = False
                    Me.dgvZOECFIP2.Columns("HIZFBARR").Visible = False
                    Me.dgvZOECFIP2.Columns("HIZFMANZ").Visible = False
                    Me.dgvZOECFIP2.Columns("HIZFPRED").Visible = False
                    Me.dgvZOECFIP2.Columns("HIZFEDIF").Visible = False
                    Me.dgvZOECFIP2.Columns("HIZFUNPR").Visible = False
                    Me.dgvZOECFIP2.Columns("HIZFTIFI").Visible = False
                    Me.dgvZOECFIP2.Columns("HIZFCLSE").Visible = False

                End If

            End If

            pro_ListaDeValores()

            Me.strBARRESTA.Items(2).Text = "Registros : 0 "

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub pro_ListaDeValores()

        Try
            ' zonas economicas
            If Me.dgvZOECFIP0.RowCount > 0 Then

                Me.lblZOECVIG0.Text = CStr(Trim(fun_Buscar_Lista_Valores_VIGENCIA(Me.dgvZOECFIP0.SelectedRows.Item(0).Cells("HIZOVIGE").Value.ToString)))
                Me.lblZOECZON0.Text = CStr(Trim(fun_Buscar_Lista_Valores_ZONAECON(Me.dgvZOECFIP0.SelectedRows.Item(0).Cells("HIZODEPA").Value.ToString, Me.dgvZOECFIP0.SelectedRows.Item(0).Cells("HIZOMUNI").Value.ToString, Me.dgvZOECFIP0.SelectedRows.Item(0).Cells("HIZOCLSE").Value.ToString, Me.dgvZOECFIP0.SelectedRows.Item(0).Cells("HIZOZOEC").Value.ToString)))

            End If

            If Me.dgvZOECFIP2.RowCount > 0 Then

                Me.lblZOECVIG2.Text = CStr(Trim(fun_Buscar_Lista_Valores_VIGENCIA(Me.dgvZOECFIP2.SelectedRows.Item(0).Cells("HIZOVIGE").Value.ToString)))
                Me.lblZOECZON2.Text = CStr(Trim(fun_Buscar_Lista_Valores_ZONAECON(Me.dgvZOECFIP2.SelectedRows.Item(0).Cells("HIZODEPA").Value.ToString, Me.dgvZOECFIP2.SelectedRows.Item(0).Cells("HIZOMUNI").Value.ToString, Me.dgvZOECFIP2.SelectedRows.Item(0).Cells("HIZOCLSE").Value.ToString, Me.dgvZOECFIP2.SelectedRows.Item(0).Cells("HIZOZOEC").Value.ToString)))

            End If

            ' zonas fisicas
            If Me.dgvZOFIFIP0.RowCount > 0 Then

                Me.lblZOFIVIG0.Text = CStr(Trim(fun_Buscar_Lista_Valores_VIGENCIA(Me.dgvZOFIFIP0.SelectedRows.Item(0).Cells("HIZFVIGE").Value.ToString)))
                Me.lblZOFIZON0.Text = CStr(Trim(fun_Buscar_Lista_Valores_ZONAFISI(Me.dgvZOFIFIP0.SelectedRows.Item(0).Cells("HIZFDEPA").Value.ToString, Me.dgvZOFIFIP0.SelectedRows.Item(0).Cells("HIZFMUNI").Value.ToString, Me.dgvZOFIFIP0.SelectedRows.Item(0).Cells("HIZFCLSE").Value.ToString, Me.dgvZOFIFIP0.SelectedRows.Item(0).Cells("HIZFZOFI").Value.ToString)))

            End If

            If Me.dgvZOFIFIP2.RowCount > 0 Then

                Me.lblZOFIVIG2.Text = CStr(Trim(fun_Buscar_Lista_Valores_VIGENCIA(Me.dgvZOFIFIP2.SelectedRows.Item(0).Cells("HIZFVIGE").Value.ToString)))
                Me.lblZOFIZON2.Text = CStr(Trim(fun_Buscar_Lista_Valores_ZONAFISI(Me.dgvZOFIFIP2.SelectedRows.Item(0).Cells("HIZFDEPA").Value.ToString, Me.dgvZOFIFIP2.SelectedRows.Item(0).Cells("HIZFMUNI").Value.ToString, Me.dgvZOFIFIP2.SelectedRows.Item(0).Cells("HIZFCLSE").Value.ToString, Me.dgvZOFIFIP2.SelectedRows.Item(0).Cells("HIZFZOFI").Value.ToString)))

            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub pro_LimpiarCampos()

        Me.dgvZOECFIP0.DataSource = New DataTable
        Me.dgvZOECFIP2.DataSource = New DataTable

        Me.lblZOECZON0.Text = ""
        Me.lblZOECZON2.Text = ""

        Me.dgvZOFIFIP0.DataSource = New DataTable
        Me.dgvZOFIFIP2.DataSource = New DataTable

        Me.lblZOFIZON0.Text = ""
        Me.lblZOFIZON2.Text = ""

    End Sub

#End Region

#Region "MENU"

    Private Sub cmdSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSalir.Click
        Me.Close()
    End Sub

#End Region

#Region "FORMULARIO"

#Region "Click"

    Private Sub dgvFIPRCACO_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvZOECFIP0.CellClick, dgvZOECFIP2.CellClick, dgvZOFIFIP0.CellClick, dgvZOFIFIP2.CellClick
        pro_ListaDeValores()
    End Sub

#End Region

#Region "KeyUp"

    Private Sub dgvFIPRCACO_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgvZOECFIP0.KeyUp, dgvZOECFIP2.KeyUp, dgvZOFIFIP0.KeyUp, dgvZOFIFIP2.KeyUp
        If e.KeyCode = Keys.Down Or e.KeyCode = Keys.Up Or e.KeyCode = Keys.Enter Or e.KeyCode = Keys.PageUp Or e.KeyCode = Keys.PageDown Or e.KeyCode = Keys.PageUp Or e.KeyCode = Keys.PageDown Then
            pro_ListaDeValores()
        End If
    End Sub

#End Region

#Region "GotFocus"

    Private Sub dgvZONAFIP0_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvZOECFIP0.GotFocus
        strBARRESTA.Items(0).Text = dgvZOECFIP0.AccessibleDescription
    End Sub
    Private Sub dgvZONAFIP2_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvZOECFIP2.GotFocus
        strBARRESTA.Items(0).Text = dgvZOECFIP2.AccessibleDescription
    End Sub
    Private Sub dgvZOFIFIP0_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvZOFIFIP0.GotFocus
        strBARRESTA.Items(0).Text = dgvZOFIFIP0.AccessibleDescription
    End Sub
    Private Sub dgvZOFIFIP2_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvZOFIFIP2.GotFocus
        strBARRESTA.Items(0).Text = dgvZOFIFIP2.AccessibleDescription
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