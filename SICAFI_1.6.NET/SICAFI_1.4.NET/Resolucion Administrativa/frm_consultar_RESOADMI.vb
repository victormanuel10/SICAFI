Imports REGLAS_DEL_NEGOCIO

Public Class frm_consultar_RESOADMI

    '==========================================
    '*** CONSULTA RESOLUCION ADMINISTRATIVA ***
    '==========================================

#Region "VARIABLES"

    Dim inID_REGISTRO As Integer

    Dim dt As DataTable

#End Region

#Region "CONSTRUCTOR"

    Public Sub New()
        InitializeComponent()
    End Sub
    Public Sub New(ByVal inInRegistro As Integer)
        inID_REGISTRO = inInRegistro

        InitializeComponent()
    End Sub

#End Region

#Region "PROCEDIMIENTOS"

    Private Sub pro_ReconsultarResolucionDeConservacion()

        Try
            ' instancia un dt
            dt = New DataTable

            ' crea la variable de los campos
            Dim stRECONURE As String = ""
            Dim stRECOFERE As String = ""

            ' carga los campos
            If Trim(Me.txtREADNURE.Text) = "" Then
                stRECONURE = "%"
            Else
                stRECONURE = Trim(Me.txtREADNURE.Text)
            End If

            ' carga los campos
            If Trim(Me.txtREADFERE.Text) = "" Then
                stRECOFERE = "%"
            Else
                stRECOFERE = Trim(Me.txtREADFERE.Text)
            End If

            ' crea la variable de consulta
            Dim stConsultaSQL As String = ""

            'concatena la consulta
            stConsultaSQL += "Select "
            stConsultaSQL += "READIDRE, "
            stConsultaSQL += "READNURE as 'Nro. Resolución', "
            stConsultaSQL += "READFERE as 'Fecha de resolución', "
            stConsultaSQL += "CLASDESC as 'Clasificación', "
            stConsultaSQL += "TIREDESC as 'Tipo de resolución', "
            stConsultaSQL += "CLSEDESC as 'Sector', "
            stConsultaSQL += "READVIRE as 'Vigencia resolución', "
            stConsultaSQL += "ESTADESC as 'Estado' "

            stConsultaSQL += "FROM "
            stConsultaSQL += "RESOADMI, MANT_CLASIFICACION, MANT_CLASSECT, MANT_TIPORESO, ESTADO "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "READCLSE = CLSECODI AND "
            stConsultaSQL += "READTIRE = TIRECODI AND "
            stConsultaSQL += "READCLAS = CLASCODI AND "
            stConsultaSQL += "READESTA = ESTACODI AND "
            stConsultaSQL += "READNURE LIKE '" & stRECONURE & "' AND "
            stConsultaSQL += "READFERE LIKE '" & stRECOFERE & "' "
            
            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "READNURE, READFERE "


            ' instancia la clase y almacena la consulta
            Dim oConsulta As New cla_Consulta_ConexionString

            dt = oConsulta.fun_Consultar_ConexionString(stConsultaSQL)

            Me.dgvCONSULTA_RESOCONS.DataSource = dt

            Me.dgvCONSULTA_RESOCONS.Columns(0).Visible = False

            ' verifica si existen datos consultados
            If Me.dgvCONSULTA_RESOCONS.RowCount = 0 Then
                mod_MENSAJE.No_Se_Encontro_Ningun_registro()
                Me.cmdAceptarResolucionConservacion.Enabled = False
                Me.txtREADNURE.Focus()
            Else
                Me.cmdAceptarResolucionConservacion.Enabled = True
            End If

            Me.strBARRESTA.Items(2).Text = "Registros : " & dt.Rows.Count


        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub pro_LimpiarCamposResolucionDeConservacion()

        Me.txtREADNURE.Text = ""
        Me.txtREADFERE.Text = ""

        Me.strBARRESTA.Items(2).Text = "Registros : 0"

        Me.dgvCONSULTA_RESOCONS.DataSource = New DataTable

        Me.cmdAceptarResolucionConservacion.Enabled = False

    End Sub

#End Region

#Region "MENU"

    Private Sub cmdConsultarResolucionConservacion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdConsultarResolucionConservacion.Click

        Try
            pro_ReconsultarResolucionDeConservacion()

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub cmdAceptarLibroRadicador_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAceptarResolucionConservacion.Click

        If Me.dgvCONSULTA_RESOCONS.RowCount = 0 Then
            MessageBox.Show("No existen registro seleccionados", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
        Else
            Dim inId_Reg As New frm_RESOCONS(Integer.Parse(Me.dgvCONSULTA_RESOCONS.SelectedRows.Item(0).Cells(0).Value.ToString()))
            Me.txtREADNURE.Focus()
            Me.Close()
        End If

    End Sub
    Private Sub cmdLimpiar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdLimpiarResolucionConservacion.Click
        pro_LimpiarCamposResolucionDeConservacion()
        Me.txtREADNURE.Focus()
    End Sub
    Private Sub cmdSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSalir.Click
        Dim inNroIdRe As New frm_RESOCONS(inID_REGISTRO)
        Me.Close()
    End Sub

#End Region

#Region "FORMULARIO"

#Region "Load"

    Private Sub Frm_Consultar_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        pro_LimpiarCamposResolucionDeConservacion()
    End Sub

#End Region

#Region "GotFocus"

    Private Sub frm_consultar_TRABCAMP_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.GotFocus
        Me.txtREADNURE.Focus()
    End Sub

#End Region

#Region "KeyPress"

    Private Sub txt_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtREADNURE.KeyPress, txtREADFERE.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Or e.KeyChar = Convert.ToChar(Keys.Tab) Then
            pp_pro_SaltarCampo()
        End If
    End Sub


#End Region

#Region "GotFocus"

    Private Sub txt_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtREADFERE.GotFocus, txtREADNURE.GotFocus
        pp_pro_SobrearCampo(sender)
        pp_pro_DescripcionCampo(Me.strBARRESTA.Items(0), sender)
    End Sub
    Private Sub cmd_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdAceptarResolucionConservacion.GotFocus, cmdSalir.GotFocus, cmdConsultarResolucionConservacion.GotFocus, cmdLimpiarResolucionConservacion.GotFocus
        pp_pro_DescripcionCampo(Me.strBARRESTA.Items(0), sender)
    End Sub

#End Region

#Region "CellDoubleClick"

    Private Sub dgvCONSULTA_RESOCONS_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvCONSULTA_RESOCONS.CellDoubleClick
        Me.cmdAceptarResolucionConservacion.PerformClick()
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