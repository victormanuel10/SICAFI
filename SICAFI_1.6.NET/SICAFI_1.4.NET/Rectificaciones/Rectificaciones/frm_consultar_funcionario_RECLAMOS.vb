Imports REGLAS_DEL_NEGOCIO

Public Class frm_consultar_funcionario_RECLAMOS

    '=========================================
    '*** CONSULTA POR FUNCIONARIO RECLAMOS ***
    '=========================================

#Region "VARIABLES"

    Dim boCONSULTA As Boolean = False

    Dim dt As DataTable

#End Region

#Region "PROCEDIMIENTOS"

    Private Sub pro_Reconsultar()

        Try
            ' instancia un dt
            dt = New DataTable

            ' crea la variable de los campos
            Dim stRECLNUDO As String = ""
            Dim stRECLVIGE As String = ""
            Dim stRECLESTA As String = ""

            ' carga los campos
            If Trim(Me.cboRECLNUDO.Text) = "" Then
                stRECLNUDO = "%"
            Else
                stRECLNUDO = Trim(Me.cboRECLNUDO.SelectedValue)
            End If

            If Trim(Me.cboRECLESTA.Text) = "" Then
                stRECLESTA = "%"
            Else
                stRECLESTA = Trim(Me.cboRECLESTA.SelectedValue)
            End If

            If Trim(Me.cboRECLVIGE.Text) = "" Then
                stRECLVIGE = "%"
            Else
                stRECLVIGE = Trim(Me.cboRECLVIGE.SelectedValue)
            End If

            ' crea la variable de consulta
            Dim stConsulta As String = ""

            'concatena la consulta
            stConsulta += "Select "
            stConsulta += "RECLIDRE , "
            stConsulta += "RECLMUNI as 'Municipio', "
            stConsulta += "RECLCORR as 'Correg', "
            stConsulta += "RECLBARR as 'Barrio', "
            stConsulta += "RECLMANZ as 'Manzana', "
            stConsulta += "RECLPRED as 'Predio', "
            stConsulta += "RECLEDIF as 'Edificio', "
            stConsulta += "RECLUNPR as 'Unidad', "
            stConsulta += "RECLCLSE as 'Sector', "
            stConsulta += "RECLVIGE as 'Vigencia', "
            stConsulta += "RECLMAIN as 'Matricula', "
            stConsulta += "RECLNUDO as 'Nro Documento', "
            stConsulta += "RECLNOMB as 'Nombre', "
            stConsulta += "RECLPRAP as 'Primer apellido', "
            stConsulta += "RECLSEAP as 'Segundo apellido', "
            stConsulta += "RECLRAMU as 'Rad. Municipio', "
            stConsulta += "RECLFEMU as 'Fecha Municipio', "
            stConsulta += "RECLRADE as 'Rad. Departamento', "
            stConsulta += "RECLFEDE as 'Fecha Departamento' "
            stConsulta += "from RECLAMOS "
            stConsulta += "where "
            stConsulta += "RECLMACA like '" & stRECLNUDO & "' and "
            stConsulta += "RECLVIGE like '" & stRECLVIGE & "' and "
            stConsulta += "RECLESTA like '" & stRECLESTA & "' "
            stConsulta += "Order by RECLMUNI, RECLCORR, RECLBARR, RECLMANZ, RECLPRED, RECLCLSE, RECLVIGE "

            ' instancia la clase y almacena la consulta
            Dim oConsulta As New cla_Consulta_ConexionString

            dt = oConsulta.fun_Consultar_ConexionString(stConsulta)

            Me.dgvCONSULTA.DataSource = dt

            ' verifica si existen datos consultados
            If Me.dgvCONSULTA.RowCount = 0 Then
                mod_MENSAJE.No_Se_Encontro_Ningun_registro()
                Me.cmdAceptar.Enabled = False
                Me.cboRECLNUDO.Focus()

            Else
                Me.dgvCONSULTA.Columns(0).Visible = False
                Me.cmdAceptar.Enabled = True

            End If

            Me.strBARRESTA.Items(2).Text = "Registros : " & dt.Rows.Count

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub pro_LimpiarCampos()

        Me.cboRECLNUDO.DataSource = New DataTable
        Me.cboRECLESTA.DataSource = New DataTable
        Me.cboRECLVIGE.DataSource = New DataTable
        Me.dgvCONSULTA.DataSource = New DataTable

        Me.strBARRESTA.Items(2).Text = "Registros : 0"

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
            Dim inId_Reg As New frm_TRABCAMP(Integer.Parse(Me.dgvCONSULTA.SelectedRows.Item(0).Cells(0).Value.ToString()))
            Me.cboRECLNUDO.Focus()
            Me.Close()
        End If

    End Sub
    Private Sub cmdLimpiar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdLimpiar.Click
        pro_LimpiarCampos()
        Me.cboRECLNUDO.Focus()
    End Sub
    Private Sub cmdSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSalir.Click
        Me.Close()
    End Sub

#End Region

#Region "FORMULARIO"

#Region "Load"

    Private Sub frm_consultar_funcionario_TRABCAMP_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        pro_LimpiarCampos()
    End Sub

#End Region

#Region "GotFocus"

    Private Sub frm_consultar_funcionario_TRABCAMP_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.GotFocus
        Me.cboRECLNUDO.Focus()
    End Sub

#End Region

#Region "KeyPress"

    Private Sub txt_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If e.KeyChar = Convert.ToChar(Keys.Enter) Or e.KeyChar = Convert.ToChar(Keys.Tab) Then
            pp_pro_SaltarCampo()
        End If
    End Sub


#End Region

#Region "GotFocus"

    Private Sub txt_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs)
        pp_pro_SobrearCampo(sender)
        pp_pro_DescripcionCampo(Me.strBARRESTA.Items(0), sender)
    End Sub
    Private Sub cmd_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdAceptar.GotFocus, cmdSalir.GotFocus, cmdConsultar.GotFocus, cmdLimpiar.GotFocus
        pp_pro_DescripcionCampo(Me.strBARRESTA.Items(0), sender)
    End Sub

#End Region

#Region "Click"

    Private Sub cboLIQUNUDO_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboRECLNUDO.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_USUARIO_Descripcion(Me.cboRECLNUDO, Me.cboRECLNUDO.SelectedIndex)
    End Sub
    Private Sub cboTRCAESTA_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboRECLESTA.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_ESTADO(Me.cboRECLESTA, Me.cboRECLESTA.SelectedIndex)
    End Sub
    Private Sub cboFIPRVIGE_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboRECLVIGE.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_VIGENCIA_Descripcion(Me.cboRECLVIGE, Me.cboRECLVIGE.SelectedIndex)
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