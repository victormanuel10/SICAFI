Imports REGLAS_DEL_NEGOCIO

Public Class frm_consultar_RESOADMI_PUBLICA

    '===========================================
    '*** CONSULTAR RESOLUCIÓN ADMINISTRATIVA ***
    '===========================================

#Region "PROCEDIMIENTOS"

    Private Sub pro_Reconsultar()

        Try
            Dim objdatos As New cla_RESOADMI

            Me.BindingSource_RESOLUCION_1.DataSource = objdatos.fun_Consultar_RESOADMI
            Me.dgvRESOADMI.DataSource = BindingSource_RESOLUCION_1
            Me.BindingNavigator_RESOLUCION_1.BindingSource = BindingSource_RESOLUCION_1

            Me.strBARRESTA.Items(2).Text = "Registros : " & BindingSource_RESOLUCION_1.Count

            Me.dgvRESOADMI.Columns("CLASDESC").HeaderText = "Clasificación"
            Me.dgvRESOADMI.Columns("READNURE").HeaderText = "Nro. Resolución"
            Me.dgvRESOADMI.Columns("READFERE").HeaderText = "Fecha de Resolución"
            Me.dgvRESOADMI.Columns("TIREDESC").HeaderText = "Tipo de Resolución"
            Me.dgvRESOADMI.Columns("CLSEDESC").HeaderText = "Sector"
            Me.dgvRESOADMI.Columns("READVIRE").HeaderText = "Vigencia Resolución"
            Me.dgvRESOADMI.Columns("ESTADESC").HeaderText = "Estado"

            Me.dgvRESOADMI.Columns("READIDRE").Visible = False
            Me.dgvRESOADMI.Columns("READCLAS").Visible = False
            Me.dgvRESOADMI.Columns("READTIRE").Visible = False
            Me.dgvRESOADMI.Columns("READCLSE").Visible = False

            'Me.dgvRESOADMI.Columns("TIREDESC").Width = 180

            If Me.dgvRESOADMI.RowCount = 0 Then
                cmdACEPTAR.Enabled = False
            Else
                cmdACEPTAR.Enabled = True
            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub pro_ListaDeValores()


    End Sub
    Private Sub pro_LimpiarCampos()


    End Sub

#End Region

#Region "MENU"

    Private Sub cmdACEPTAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdACEPTAR.Click
        Try
            If Me.dgvRESOADMI.RowCount > 0 Then
                vp_inConsulta = (Integer.Parse(dgvRESOADMI.CurrentRow.Cells(0).Value.ToString()))
            Else
                vp_inConsulta = 0
            End If

            Me.Close()

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try
    End Sub
    Private Sub cmdSALIR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSALIR.Click
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
    Private Sub dgvRESOLUCION_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvRESOADMI.GotFocus
        strBARRESTA.Items(0).Text = dgvRESOADMI.AccessibleDescription
        pro_ListaDeValores()
    End Sub
    Private Sub dgvRESOLUCION_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvRESOADMI.CellClick
        pro_ListaDeValores()
    End Sub
    Private Sub dgvRESOLUCION_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvRESOADMI.CellDoubleClick
        Call cmdACEPTAR_Click(cmdACEPTAR, New System.EventArgs)
    End Sub
    Private Sub dgvRESOLUCION_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgvRESOADMI.KeyUp
        If e.KeyCode = Keys.Down Or e.KeyCode = Keys.Up Or e.KeyCode = Keys.PageUp Or e.KeyCode = Keys.PageDown Then
            pro_ListaDeValores()
        End If
    End Sub

#End Region

End Class