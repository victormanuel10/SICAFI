Imports REGLAS_DEL_NEGOCIO

Public Class frm_consulta_calificacion_FIPRCACO


    '================================================
    '*** CONSULTA DE CALIFICACIÓN DE CONSTRUCCIÓN ***
    '================================================

#Region "CONSTRUCTOR"

    Public Sub New(ByVal inFIPRNUFI As Integer, _
                     ByVal inFPCOUNID As Integer)

        vl_inFIPRNUFI = inFIPRNUFI
        vl_inFPCCUNID = inFPCOUNID

        InitializeComponent()
        pro_LimpiarCampos()

    End Sub

#End Region

#Region "VARIABLES"

    Dim vl_inFIPRNUFI As Integer
    Dim vl_inFPCCUNID As Integer

#End Region

#Region "PROCEDIMIENTO"

    Private Sub pro_ReconsultarCalificacion()

        Try
            Dim objdatos As New cla_FIPRCACO

            Me.BindingSource_FIPRCACO_1.DataSource = objdatos.fun_Consultar_FIPRCACO(vl_inFIPRNUFI, vl_inFPCCUNID)

            Me.dgvFIPRCACO.DataSource = Me.BindingSource_FIPRCACO_1.DataSource
            Me.BindingNavigator_FIPRCACO_1.BindingSource = Me.BindingSource_FIPRCACO_1

            Me.dgvFIPRCACO.Columns(0).Visible = False
            Me.dgvFIPRCACO.Columns(1).Visible = False

            Me.dgvFIPRCACO.Columns(2).Width = 50
            Me.dgvFIPRCACO.Columns(3).Width = 150
            Me.dgvFIPRCACO.Columns(4).Width = 50
            Me.dgvFIPRCACO.Columns(5).Width = 100

            strBARRESTA.Items(2).Text = "Registros : " & Me.BindingSource_FIPRCACO_1.Count

            If Me.BindingSource_FIPRCACO_1.Count > 0 Then

                Dim tbl As New DataTable

                tbl = BindingSource_FIPRCACO_1.DataSource

                Me.txtFPCCCODI.Text = Trim(tbl.Rows(0).Item(2))

                Me.lblFPCCCODI.Text = CType(fun_Buscar_Lista_Valores_CODICALI(Me.txtFPCCCODI.Text), String)
                Me.lblFPCCCOPA.Text = CType(fun_Buscar_Lista_Valores_CODICALI_COCACOPA(Me.txtFPCCCODI.Text), String)
                Me.lblFPCCCOHI.Text = CType(fun_Buscar_Lista_Valores_CODICALI_COCACOHI(Me.txtFPCCCODI.Text), String)

            Else
                pro_LimpiarCampos()
            End If


        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub pro_SumaPuntosDeCalificacionDeConstruccion()
        Dim objdatos2 As New cla_FIPRCACO
        Dim tbl1 As New DataTable

        tbl1 = objdatos2.fun_Consultar_SUMA_X_FPCCPUNT_FIPRCACO(vl_inFIPRNUFI, vl_inFPCCUNID)

        Dim i As Integer
        Dim inTOTAL As Integer

        If tbl1.Rows.Count > 0 Then

            For i = 0 To tbl1.Rows.Count - 1
                inTOTAL += CType(tbl1.Rows(i).Item(0), Integer)
            Next

        End If

        Me.lblFPCCTOTA.Text = CStr(inTOTAL)

    End Sub
    Private Sub pro_ListaDeValoresCalificacion()

        Try
            If Me.dgvFIPRCACO.RowCount > 0 Then

                Dim objdatos As New cla_FIPRCACO
                Dim tbl As New DataTable

                Dim id As Integer = (Integer.Parse(dgvFIPRCACO.CurrentRow.Cells(0).Value.ToString()))

                tbl = objdatos.fun_Buscar_ID_FIPRCACO(id)

                If tbl.Rows.Count > 0 Then

                    Me.txtFPCCCODI.Text = Trim(tbl.Rows(0).Item(2))

                    Me.lblFPCCCODI.Text = CType(fun_Buscar_Lista_Valores_CODICALI(txtFPCCCODI.Text), String)
                    Me.lblFPCCCOPA.Text = CType(fun_Buscar_Lista_Valores_CODICALI_COCACOPA(txtFPCCCODI.Text), String)
                    Me.lblFPCCCOHI.Text = CType(fun_Buscar_Lista_Valores_CODICALI_COCACOHI(txtFPCCCODI.Text), String)
                Else
                    Me.lblFPCCCODI.Text = ""
                    Me.lblFPCCCOPA.Text = ""
                    Me.lblFPCCCOHI.Text = ""
                End If

            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub pro_LimpiarCampos()
        txtFPCCCODI.Text = ""
        lblFPCCCOPA.Text = ""
        lblFPCCCOHI.Text = ""
        lblFPCCCODI.Text = ""
        lblFPCCTOTA.Text = ""
    End Sub

#End Region

#Region "MENU"

    Private Sub cmdCANCELAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCANCELAR.Click
        Me.Close()
    End Sub

#End Region

#Region "FORMULARIO"

#Region "Load"

    Private Sub frm_consulta_calificacion_FIPRCACO_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        pro_ReconsultarCalificacion()
        pro_SumaPuntosDeCalificacionDeConstruccion()


    End Sub

#End Region

#Region "Click"

    Private Sub dgvFIPRCACO_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvFIPRCACO.CellClick
        pro_ListaDeValoresCalificacion()
    End Sub

#End Region

#Region "KeyUp"

    Private Sub dgvFIPRCACO_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgvFIPRCACO.KeyUp
        If e.KeyCode = Keys.Down Or e.KeyCode = Keys.Up Or e.KeyCode = Keys.Enter Or e.KeyCode = Keys.PageUp Or e.KeyCode = Keys.PageDown Or e.KeyCode = Keys.PageUp Or e.KeyCode = Keys.PageDown Then
            pro_ListaDeValoresCalificacion()
        End If
    End Sub

#End Region

#Region "GotFocus"

    Private Sub frm_consulta_calificacion_FIPRCACO_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.GotFocus
        pro_ListaDeValoresCalificacion()
    End Sub
    Private Sub cmdCANCELAR_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdCANCELAR.GotFocus
        strBARRESTA.Items(0).Text = cmdCANCELAR.AccessibleDescription
    End Sub
    Private Sub dgvFIPRCACO_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvFIPRCACO.GotFocus
        strBARRESTA.Items(0).Text = dgvFIPRCACO.AccessibleDescription
    End Sub

#End Region

#Region "ResizeBegin"

    Private Sub frm_ResizeBegin(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.ResizeBegin
        Me.Opacity = 0.01
    End Sub

#End Region

#Region "ResizeEnd"

    Private Sub frm_ResizeEnd(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.ResizeEnd
        Dim opacity As Double = Convert.ToDouble(100)
        Me.Opacity = opacity
    End Sub

#End Region

#Region "MouseHover"

    Private Sub cmdTransparente_MouseHover(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdTransparente.MouseHover
        Call frm_ResizeBegin(Me, New System.EventArgs)
    End Sub


#End Region

#Region "MouseLeave"

    Private Sub cmdTransparente_MouseLeave1(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdTransparente.MouseLeave
        Call frm_ResizeEnd(Me, New System.EventArgs)
    End Sub

#End Region

#End Region

   
End Class