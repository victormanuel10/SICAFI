Imports REGLAS_DEL_NEGOCIO

Public Class frm_FIPRINCO

    '==============================
    ' INCONSISTENCIAS FICHA PREDIAL
    '==============================

#Region "CONSTRUCTOR"

    Public Sub New(ByVal inFIPRNUFI As Integer)

        vl_inFIPRNUFI = inFIPRNUFI

        InitializeComponent()
        pro_InicializarComponentes()

    End Sub

#End Region
   
#Region "VARIABLES LOCALES"

    Dim vl_inFIPRNUFI As Integer

#End Region

#Region "PROCEDIMIENTOS"

    Private Sub pro_InicializarComponentes()

        Dim objdatos As New cla_VALIFIPR
        Dim dt As New DataTable

        BindingSource_FIPRINCO_1.DataSource = objdatos.fun_Consultar_INCONSISTENCIA_X_FICHA_PREDIAL(vl_inFIPRNUFI)
        dgvFIPRINCO.DataSource = BindingSource_FIPRINCO_1.DataSource
        BindingNavigator_FIPRINCO_1.BindingSource = BindingSource_FIPRINCO_1

        strBARRESTA.Items(2).Text = "Registros : " & BindingSource_FIPRINCO_1.Count

        dgvFIPRINCO.Columns(1).HeaderText = "Código"
        dgvFIPRINCO.Columns(2).HeaderText = "Inconsistencia"

        Me.dgvFIPRINCO.Columns(1).Width = 50
        Me.dgvFIPRINCO.Columns(2).Width = 500

        dgvFIPRINCO.Columns(0).Visible = False
        dgvFIPRINCO.Columns(3).Visible = False
        dgvFIPRINCO.Columns(4).Visible = False
        dgvFIPRINCO.Columns(5).Visible = False
        dgvFIPRINCO.Columns(6).Visible = False
        dgvFIPRINCO.Columns(7).Visible = False
        dgvFIPRINCO.Columns(8).Visible = False
        dgvFIPRINCO.Columns(9).Visible = False
        dgvFIPRINCO.Columns(10).Visible = False
        dgvFIPRINCO.Columns(11).Visible = False


    End Sub


#End Region

#Region "MENU"

    Private Sub cmdSALIR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSALIR.Click
        Me.Close()
    End Sub

#End Region

#Region "FORMULARIO"

#Region "Load"

    Private Sub frm_FIPRINCO_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        strBARRESTA.Items(0).Text = "Inconsistencias"
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