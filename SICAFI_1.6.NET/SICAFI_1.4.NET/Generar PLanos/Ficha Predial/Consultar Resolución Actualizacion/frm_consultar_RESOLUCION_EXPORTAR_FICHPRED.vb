Imports REGLAS_DEL_NEGOCIO

Public Class frm_consultar_RESOLUCION_EXPORTAR_FICHPRED

    '=========================================================
    '*** CONSULTAR RESOLUCIÓN EXPORTAR PLANO FICHA PREDIAL ***
    '=========================================================

#Region "PROCEDIMIENTOS"

    Private Sub pro_Reconsultar()
        Try
            Dim objdatos As New cla_RESOLUCION

            Me.BindingSource_RESOLUCION_1.DataSource = objdatos.fun_Consultar_RESOLUCION_X_ESTADO

            Me.dgvRESOLUCION.DataSource = Me.BindingSource_RESOLUCION_1
            Me.BindingNavigator_RESOLUCION_1.BindingSource = Me.BindingSource_RESOLUCION_1

            Me.strBARRESTA.Items(2).Text = "Registros : Me." & Me.BindingSource_RESOLUCION_1.Count

            'Oculta la columna del DataGridView
            Me.dgvRESOLUCION.Columns(0).Visible = False
            Me.dgvRESOLUCION.Columns(7).Visible = False
            Me.dgvRESOLUCION.Columns(8).Visible = False
            Me.dgvRESOLUCION.Columns(9).Visible = False
            Me.dgvRESOLUCION.Columns(10).Visible = False
            Me.dgvRESOLUCION.Columns(11).Visible = False
            Me.dgvRESOLUCION.Columns(12).Visible = False
            Me.dgvRESOLUCION.Columns(14).Visible = False

            If Me.dgvRESOLUCION.RowCount = 0 Then
                cmdACEPTAR.Enabled = False
            Else
                cmdACEPTAR.Enabled = True
            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub pro_ListaDeValores()

        If Me.dgvRESOLUCION.RowCount > 0 Then

            '===========================================
            'CARGA LA DESCRIPCIÓN DE LA LISTA DE VALORES
            '===========================================
            Try
                lblRESODEPA.Text = CType(fun_Buscar_Lista_Valores_DEPARTAMENTO(dgvRESOLUCION.CurrentRow.Cells(1).Value.ToString()), String)
                lblRESOMUNI.Text = CType(fun_Buscar_Lista_Valores_MUNICIPIO(dgvRESOLUCION.CurrentRow.Cells(1).Value.ToString(), dgvRESOLUCION.CurrentRow.Cells(2).Value.ToString()), String)
                lblRESOTIRE.Text = CType(fun_Buscar_Lista_Valores_TIPORESO(dgvRESOLUCION.CurrentRow.Cells(3).Value.ToString()), String)
                lblRESOCLSE.Text = CType(fun_Buscar_Lista_Valores_CLASSECT(dgvRESOLUCION.CurrentRow.Cells(4).Value.ToString()), String)
                lblRESOVIGE.Text = CType(fun_Buscar_Lista_Valores_VIGENCIA(dgvRESOLUCION.CurrentRow.Cells(5).Value.ToString()), String)
                chkRESOPATO.Checked = CType(fun_Buscar_Lista_Valores_BOOLEAN(dgvRESOLUCION.CurrentRow.Cells(12).Value.ToString()), Boolean)
                lblRESOCODI.Text = CType(fun_Buscar_Lista_Valores_STRING(dgvRESOLUCION.CurrentRow.Cells(14).Value.ToString()), String)

            Catch ex As Exception
                MessageBox.Show(Err.Description)
            End Try

        End If

    End Sub
    Private Sub pro_LimpiarCampos()

        Me.lblRESODEPA.Text = ""
        Me.lblRESOMUNI.Text = ""
        Me.lblRESOTIRE.Text = ""
        Me.lblRESOCLSE.Text = ""
        Me.lblRESOVIGE.Text = ""
        Me.lblRESOCODI.Text = ""
        Me.chkRESOPATO.Checked = False

    End Sub

#End Region

#Region "MENU"

    Private Sub cmdACEPTAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdACEPTAR.Click
        Try
            Dim frm_exportar_planos_FICHA_PREDIAL As New frm_exportar_planos_FICHA_PREDIAL(Integer.Parse(dgvRESOLUCION.CurrentRow.Cells(0).Value.ToString()))
            Me.Close()

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try
    End Sub
    Private Sub cmdCANCELARR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSALIR.Click
        Dim frm_exportar_planos_FICHA_PREDIAL As New frm_exportar_planos_FICHA_PREDIAL(0)
        Me.Close()
    End Sub

    Private Sub BindingNavigatorMoveFirstItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BindingNavigatorMoveFirstItem.Click
        pro_ListaDeValores()
    End Sub
    Private Sub BindingNavigatorMovePreviousItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BindingNavigatorMovePreviousItem.Click
        pro_ListaDeValores()
    End Sub
    Private Sub BindingNavigatorMoveNextItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BindingNavigatorMoveNextItem.Click
        pro_ListaDeValores()
    End Sub
    Private Sub BindingNavigatorMoveLastItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BindingNavigatorMoveLastItem.Click
        pro_ListaDeValores()
    End Sub

#End Region

#Region "FORMULARIO"

    Private Sub frm_consultar_RESOLUCION_FICHPRED_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        pro_Reconsultar()
    End Sub
    Private Sub dgvRESOLUCION_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvRESOLUCION.GotFocus
        strBARRESTA.Items(0).Text = dgvRESOLUCION.AccessibleDescription
        pro_ListaDeValores()
    End Sub
    Private Sub dgvRESOLUCION_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvRESOLUCION.CellClick
        pro_ListaDeValores()
    End Sub
    Private Sub dgvRESOLUCION_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvRESOLUCION.CellDoubleClick
        Call cmdACEPTAR_Click(cmdACEPTAR, New System.EventArgs)
    End Sub
    Private Sub dgvRESOLUCION_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgvRESOLUCION.KeyUp
        If e.KeyCode = Keys.Down Or e.KeyCode = Keys.Up Or e.KeyCode = Keys.PageUp Or e.KeyCode = Keys.PageDown Then
            pro_ListaDeValores()
        End If
    End Sub

#End Region



End Class