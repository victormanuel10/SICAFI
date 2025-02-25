Imports REGLAS_DEL_NEGOCIO

Public Class frm_consultar_OBURPLPA

    '=========================================================
    '*** CONSULTAR RESOLUCIÓN EXPORTAR PLANO FICHA PREDIAL ***
    '=========================================================

#Region "VARIABLE"

    Dim vl_inOUIGIDRE As Integer = 0
    Dim vl_inOUIGSECU As Integer = 0
    Dim vl_stOUIGCLEN As String = ""
    Dim vl_inOUIGNURE As Integer = 0
    Dim vl_stOUIGFERE As String = ""
    Dim vl_inOUIGCLOU As Integer = 0
    Dim vl_inOUIGNULI As Integer = 0


#End Region

#Region "CONSTRUCTOR"

    Public Sub New(ByVal inOUIGIDRE As Integer, _
                   ByVal inOUIGSECU As Integer, _
                   ByVal stOUIGCLEN As String, _
                   ByVal inOUIGNURE As Integer, _
                   ByVal stOUIGFERE As String, _
                   ByVal inOUIGCLOU As Integer, _
                   ByVal inOUIGNULI As Integer)

        vl_inOUIGIDRE = inOUIGIDRE
        vl_inOUIGSECU = inOUIGSECU
        vl_stOUIGCLEN = stOUIGCLEN
        vl_inOUIGNURE = inOUIGNURE
        vl_stOUIGFERE = stOUIGFERE
        vl_inOUIGCLOU = inOUIGCLOU
        vl_inOUIGNULI = inOUIGNULI

        InitializeComponent()

    End Sub
    Public Sub New(ByVal inOUIGSECU As Integer, _
                   ByVal stOUIGCLEN As String, _
                   ByVal inOUIGNURE As Integer, _
                   ByVal stOUIGFERE As String, _
                   ByVal inOUIGCLOU As Integer, _
                   ByVal inOUIGNULI As Integer)

        vl_inOUIGSECU = inOUIGSECU
        vl_stOUIGCLEN = stOUIGCLEN
        vl_inOUIGNURE = inOUIGNURE
        vl_stOUIGFERE = stOUIGFERE
        vl_inOUIGCLOU = inOUIGCLOU
        vl_inOUIGNULI = inOUIGNULI

        InitializeComponent()

    End Sub
    Public Sub New()

        InitializeComponent()

    End Sub

#End Region

#Region "PROCEDIMIENTOS"

    Private Sub pro_Reconsultar()

        Try
            Dim objdatos As New cla_PLANPARC

            Me.BindingSource_PLANPARC_1.DataSource = objdatos.fun_Consultar_MANT_PLANPARC

            Me.dgvPLANPARC.DataSource = Me.BindingSource_PLANPARC_1
            Me.BindingNavigator_PLANPARC_1.BindingSource = Me.BindingSource_PLANPARC_1

            Me.strBARRESTA.Items(2).Text = "Registros : " & Me.BindingSource_PLANPARC_1.Count

            Me.dgvPLANPARC.Columns("PLPANURE").HeaderText = "Nro. Resolución"
            Me.dgvPLANPARC.Columns("PLPAFERE").HeaderText = "Fecha Resolución"
            Me.dgvPLANPARC.Columns("PLPADESC").HeaderText = "Descripción"
            Me.dgvPLANPARC.Columns("ESTADESC").HeaderText = "Estado"

            Me.dgvPLANPARC.Columns("PLPAIDRE").Visible = False
            Me.dgvPLANPARC.Columns("PLPAESTA").Visible = False

            Me.dgvPLANPARC.Columns("PLPANURE").Width = 100
            Me.dgvPLANPARC.Columns("PLPAFERE").Width = 100
            Me.dgvPLANPARC.Columns("PLPADESC").Width = 300
            Me.dgvPLANPARC.Columns("ESTADESC").Width = 100

            If Me.dgvPLANPARC.RowCount = 0 Then
                cmdACEPTAR.Enabled = False
            Else
                cmdACEPTAR.Enabled = True
            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub

#End Region

#Region "MENU"

    Private Sub cmdACEPTAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdACEPTAR.Click

        Try
            ' instancia la clase
            Dim obOBURPLPA As New cla_OBURPLPA
            Dim dtOBURPLPA As New DataTable

            dtOBURPLPA = obOBURPLPA.fun_Buscar_CONSULTA_PARAMETRIZADA_OBURPLPA(vl_inOUIGSECU, vl_inOUIGCLOU, vl_inOUIGNULI)

            If dtOBURPLPA.Rows.Count = 0 Then

                '' inserta el registro
                'If obOBURPLPA.fun_Insertar_OBURPLPA(vl_inOUIGSECU, _
                '                                    vl_stOUIGCLEN, _
                '                                    vl_inOUIGNURE, _
                '                                    vl_stOUIGFERE, _
                '                                    Me.dgvPLANPARC.SelectedRows.Item(0).Cells("PLPANURE").Value.ToString(), _
                '                                    Me.dgvPLANPARC.SelectedRows.Item(0).Cells("PLPAFERE").Value.ToString(), _
                '                                    vl_inOUIGCLOU, _
                '                                    vl_inOUIGNULI, _
                '                                    Me.dgvPLANPARC.SelectedRows.Item(0).Cells("PLPAESTA").Value.ToString()) = True Then

                '    mod_MENSAJE.Se_Guardaron_Los_Datos_Correctamente()

                'End If

            End If

            Me.Close()

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub cmdSALIR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSALIR.Click
        Me.Close()
    End Sub

#End Region

#Region "FORMULARIO"

#Region "Load"

    Private Sub frm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        pro_Reconsultar()
    End Sub

#End Region

#Region "GotFocus"

    Private Sub dgvPLANPARC_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvPLANPARC.GotFocus
        strBARRESTA.Items(0).Text = dgvPLANPARC.AccessibleDescription
    End Sub

#End Region

#Region "CellDoubleClick"

    Private Sub dgvPLANPARC_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvPLANPARC.CellDoubleClick
        Me.cmdACEPTAR.PerformClick()
    End Sub

#End Region

#End Region

End Class