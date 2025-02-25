Imports REGLAS_DEL_NEGOCIO

Public Class frm_consultar_REGIMUTA

    '=======================================
    '*** CONSULTA REGISTRO DE MUTACIONES ***
    '=======================================

#Region "VARIABLES"

    Dim boCONSULTA As Boolean = False
    Dim stORDERBY As String = ""
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

    Private Sub pro_Reconsultar()

        Try
            ' instancia un dt
            dt = New DataTable

            ' crea la variable de los campos
            Dim stREMUMES As String = ""
            Dim stREMUVIGE As String = ""

            ' carga los campos
            If Trim(Me.txtREMUMES.Text) = "" Then
                stREMUMES = "%"
            Else
                stREMUMES = Trim(Me.txtREMUMES.Text)
            End If

            ' carga los campos
            If Trim(Me.txtREMUVIGE.Text) = "" Then
                stREMUVIGE = "%"
            Else
                stREMUVIGE = Trim(Me.txtREMUVIGE.Text)
            End If

            ' crea la variable de consulta
            Dim stConsulta As String = ""

            If Me.rbdListadoPorMesVigencia.Checked = True Then

                'concatena la consulta
                stConsulta += "Select "
                stConsulta += "REMUIDRE , "
                stConsulta += "REMUMES as 'Mes', "
                stConsulta += "REMUVIGE as 'Vigencia', "
                stConsulta += "REMUFEIN as 'Fecha ingreso', "
                stConsulta += "REMUFEAS as 'Fecha asignación', "
                stConsulta += "REMUFEFI as 'Fecha finalización', "
                stConsulta += "REMUUSUA as 'Usuario', "
                stConsulta += "REMUNUPR as 'Nro. Predios', "
                stConsulta += "REMUNUAR as 'Nro. Archivos' "
                stConsulta += "From REGIMUTA "
                stConsulta += "Where "
                stConsulta += "REMUMES like '" & stREMUMES & "' and "
                stConsulta += "REMUVIGE like '" & stREMUVIGE & "'  "

            ElseIf Me.rbdListadoPorPredios.Checked = True Then

                'concatena la consulta
                stConsulta += "Select "
                stConsulta += "REMUIDRE , "
                stConsulta += "REMUMES as 'Mes', "
                stConsulta += "REMUVIGE as 'Vigencia', "
                stConsulta += "RMPRMUNI as 'Municipio', "
                stConsulta += "RMPRCORR as 'Correg,', "
                stConsulta += "RMPRBARR as 'Barrio', "
                stConsulta += "RMPRMANZ as 'Manzana - Vereda', "
                stConsulta += "RMPRPRED as 'Predio', "
                stConsulta += "RMPREDIF as 'Edificio', "
                stConsulta += "RMPRUNPR as 'Unidad Predial', "
                stConsulta += "RMPRCLSE as 'Clase o Sector', "
                stConsulta += "RMPRVIGE as 'Vigencia', "
                stConsulta += "RMPRNURE as 'Nro. Resolución', "
                stConsulta += "RMPRFERE as 'Fecha resolución', "
                stConsulta += "RMPRESCR as 'Escritura', "
                stConsulta += "RMPRFEES as 'Fecha escritura', "
                stConsulta += "RMPRNUFI as 'Nro. Ficha', "
                stConsulta += "RMPRMAIN as 'Matricula' "
                stConsulta += "From REMUPRED, REGIMUTA "
                stConsulta += "Where "
                stConsulta += "REMUSECU = RMPRSECU and REMUMES like '" & stREMUMES & "' and REMUVIGE like '" & stREMUVIGE & "' "

            End If

            ' instancia la clase y almacena la consulta
            Dim oConsulta As New cla_Consulta_ConexionString

            dt = oConsulta.fun_Consultar_ConexionString(stConsulta)

            Me.dgvCONSULTA.DataSource = dt

            Me.dgvCONSULTA.Columns(0).Visible = False

            ' verifica si existen datos consultados
            If Me.dgvCONSULTA.RowCount = 0 Then
                mod_MENSAJE.No_Se_Encontro_Ningun_registro()
                Me.cmdAceptar.Enabled = False
                Me.txtREMUMES.Focus()
            Else
                Me.cmdAceptar.Enabled = True
            End If

            Me.strBARRESTA.Items(2).Text = "Registros : " & dt.Rows.Count

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub pro_LimpiarCampos()

        Me.txtREMUMES.Text = ""
        Me.txtREMUVIGE.Text = ""

        Me.strBARRESTA.Items(2).Text = "Registros : 0"

        Me.dgvCONSULTA.DataSource = New DataTable

    End Sub

#End Region

#Region "MENU"

    Private Sub cmdConsultar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdConsultar.Click

        Try
            pro_Reconsultar()

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub cmdAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAceptar.Click

        If Me.dgvCONSULTA.RowCount = 0 Then
            MessageBox.Show("No existen registro seleccionados", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
        Else
            Dim inId_Reg As New frm_REGIMUTA(Integer.Parse(Me.dgvCONSULTA.SelectedRows.Item(0).Cells(0).Value.ToString()))
            Me.txtREMUMES.Focus()
            Me.Close()
        End If

    End Sub
    Private Sub cmdLimpiar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdLimpiar.Click
        pro_LimpiarCampos()
        Me.txtREMUMES.Focus()
    End Sub
    Private Sub cmdSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSalir.Click
        Dim inNroIdRe As New frm_REGIMUTA(inID_REGISTRO)
        Me.Close()
    End Sub
    Private Sub cmdExportarExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExportarExcel.Click
        Try
            If Me.dgvCONSULTA.RowCount = 0 Then
                MessageBox.Show("No existe datos para exportar", "Mensaje ...", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1)
            Else
                Dim oExp As New cla_ExportarTablaExcel
                oExp.DataTableToExcel(CType(Me.dgvCONSULTA.DataSource, DataTable))
            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try
    End Sub

#End Region

#Region "FORMULARIO"

#Region "Load"

    Private Sub Frm_Consultar_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        pro_LimpiarCampos()

    End Sub

#End Region

#Region "GotFocus"

    Private Sub frm_consultar_TRABCAMP_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.GotFocus
        Me.txtREMUMES.Focus()
    End Sub

#End Region

#Region "KeyPress"

    Private Sub txt_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtREMUMES.KeyPress, txtREMUVIGE.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Or e.KeyChar = Convert.ToChar(Keys.Tab) Then
            pp_pro_SaltarCampo()
        End If
    End Sub


#End Region

#Region "GotFocus"

    Private Sub txt_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtREMUVIGE.GotFocus, txtREMUMES.GotFocus
        pp_pro_SobrearCampo(sender)
        pp_pro_DescripcionCampo(Me.strBARRESTA.Items(0), sender)
    End Sub
    Private Sub cmd_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdAceptar.GotFocus, cmdSalir.GotFocus, cmdConsultar.GotFocus, cmdLimpiar.GotFocus
        pp_pro_DescripcionCampo(Me.strBARRESTA.Items(0), sender)
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