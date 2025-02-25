Imports REGLAS_DEL_NEGOCIO

Public Class frm_consultar_funcionario_TRABCAMP

    '=================================================
    '*** CONSULTA POR FUNCIONARIO TRABAJO DE CAMPO ***
    '=================================================

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
            Dim stTRCANUDO As String = ""
            Dim stTRCAVIGE As String = ""
            Dim stTRCAESTA As String = ""
           
            ' carga los campos
            If Trim(Me.cboTRCANUDO.Text) = "" Then
                stTRCANUDO = "%"
            Else
                stTRCANUDO = Trim(Me.cboTRCANUDO.SelectedValue)
            End If

            If Trim(Me.cboTRCAESTA.Text) = "" Then
                stTRCAESTA = "%"
            Else
                stTRCAESTA = Trim(Me.cboTRCAESTA.SelectedValue)
            End If

            If Trim(Me.cboTRCAVIGE.Text) = "" Then
                stTRCAVIGE = "%"
            Else
                stTRCAVIGE = Trim(Me.cboTRCAVIGE.SelectedValue)
            End If

            ' crea la variable de consulta
            Dim stConsulta As String = ""

            'concatena la consulta
            stConsulta += "Select "
            stConsulta += "TRCAIDRE , "
            stConsulta += "TRCAMUNI as 'Municipio', "
            stConsulta += "TRCACORR as 'Correg', "
            stConsulta += "TRCABARR as 'Barrio', "
            stConsulta += "TRCAMANZ as 'Manzana', "
            stConsulta += "TRCAPRED as 'Predio', "
            stConsulta += "TRCACLSE as 'Sector', "
            stConsulta += "TRCAVIGE as 'Vigencia', "
            stConsulta += "TRCACAAC as 'Causa', "
            stConsulta += "TRCAFEES as 'Fecha escritura', "
            stConsulta += "TRCAFEIN as 'Fecha ingreso', "
            stConsulta += "TRCAPRNU as 'Predios nuevos', "
            stConsulta += "TRCAPRMO as 'Predios modificados', "
            stConsulta += "TRCAPREL as 'Predios eliminados', "
            stConsulta += "TRCAESTA as 'Estado', "

            If Me.rbdLEVANTAMIENTO.Checked = True Then

                stConsulta += "LEVANUDO as 'Nro. Documento', "
                stConsulta += "LEVAFEEN as 'Fecha entrega', "
                stConsulta += "LEVAFERE as 'Fecha terminación' "

                stConsulta += "From TRABCAMP, LEVANTAMIENTO "
                stConsulta += "Where "
                stConsulta += "LEVASECU = TRCASECU and "
                stConsulta += "LEVANUDO like '" & stTRCANUDO & "' and "
                stConsulta += "TRCAVIGE like '" & stTRCAVIGE & "' and "
                stConsulta += "TRCAESTA like '" & stTRCAESTA & "' "

            End If

            If Me.rbdDIGITACION.Checked = True Then

                stConsulta += "DIGINUDO as 'Nro. Documento', "
                stConsulta += "DIGIFEEN as 'Fecha entrega', "
                stConsulta += "DIGIFERE as 'Fecha terminación' "

                stConsulta += "From TRABCAMP, DIGITACION "
                stConsulta += "Where "
                stConsulta += "DIGISECU = TRCASECU and "
                stConsulta += "DIGINUDO like '" & stTRCANUDO & "' and "
                stConsulta += "TRCAVIGE like '" & stTRCAVIGE & "' and "
                stConsulta += "TRCAESTA like '" & stTRCAESTA & "' "

            End If

            If Me.rbdLIQUIDACION.Checked = True Then

                stConsulta += "LIQUNUDO as 'Nro. Documento', "
                stConsulta += "LIQUFEEN as 'Fecha entrega', "
                stConsulta += "LIQUFERE as 'Fecha terminación' "

                stConsulta += "From TRABCAMP, LIQUIDACION "
                stConsulta += "Where "
                stConsulta += "LIQUSECU = TRCASECU and "
                stConsulta += "LIQUNUDO like '" & stTRCANUDO & "' and "
                stConsulta += "TRCAVIGE like '" & stTRCAVIGE & "' and "
                stConsulta += "TRCAESTA like '" & stTRCAESTA & "' "

            End If

            If Me.rbdARCHIVO.Checked = True Then

                stConsulta += "ARCHNUDO as 'Nro. Documento', "
                stConsulta += "ARCHFEEN as 'Fecha entrega', "
                stConsulta += "ARCHFERE as 'Fecha terminación' "

                stConsulta += "From TRABCAMP, ARCHIVO "
                stConsulta += "Where "
                stConsulta += "ARCHSECU = TRCASECU and "
                stConsulta += "ARCHNUDO like '" & stTRCANUDO & "' and "
                stConsulta += "TRCAVIGE like '" & stTRCAVIGE & "' and "
                stConsulta += "TRCAESTA like '" & stTRCAESTA & "' "

            End If

            stConsulta += "Order by TRCAMUNI, TRCACORR, TRCABARR, TRCAMANZ, TRCAPRED, TRCACLSE, TRCAVIGE "

            ' instancia la clase y almacena la consulta
            Dim oConsulta As New cla_Consulta_ConexionString

            dt = oConsulta.fun_Consultar_ConexionString(stConsulta)

            Me.dgvCONSULTA.DataSource = dt

            ' verifica si existen datos consultados
            If Me.dgvCONSULTA.RowCount = 0 Then
                mod_MENSAJE.No_Se_Encontro_Ningun_registro()
                Me.cmdAceptar.Enabled = False
                Me.cboTRCANUDO.Focus()

                Me.txtTRCAPRNU.Text = "0"
                Me.txtTRCAPRMO.Text = "0"
                Me.txtTRCAPREL.Text = "0"
                Me.txtTOTAL.Text = "0"

            Else
                Me.dgvCONSULTA.Columns(0).Visible = False

                ' declaro variables
                Dim loTotalPredioNuevos As Long = 0
                Dim loTotalPrediosModificados As Long = 0
                Dim loTotalPrediosEliminados As Long = 0

                Dim i As Integer

                For i = 0 To dt.Rows.Count - 1

                    loTotalPredioNuevos += Integer.Parse(dgvCONSULTA.Item("Predios nuevos", i).Value.ToString)
                    loTotalPrediosModificados += Integer.Parse(dgvCONSULTA.Item("Predios modificados", i).Value.ToString)
                    loTotalPrediosEliminados += Integer.Parse(dgvCONSULTA.Item("Predios eliminados", i).Value.ToString)

                Next

                ' llena los totales
                Me.txtTRCAPRNU.Text = loTotalPredioNuevos
                Me.txtTRCAPRMO.Text = loTotalPrediosModificados
                Me.txtTRCAPREL.Text = loTotalPrediosEliminados
                Me.txtTOTAL.Text = loTotalPredioNuevos + loTotalPrediosModificados + loTotalPrediosEliminados

                Me.cmdAceptar.Enabled = True
            End If

            Me.strBARRESTA.Items(2).Text = "Registros : " & dt.Rows.Count

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub pro_LimpiarCampos()

        Me.txtTRCAPRNU.Text = ""
        Me.txtTRCAPRMO.Text = ""
        Me.txtTRCAPREL.Text = ""
        Me.txtTOTAL.Text = ""

        Me.cboTRCANUDO.DataSource = New DataTable
        Me.cboTRCAESTA.DataSource = New DataTable
        Me.cboTRCAVIGE.DataSource = New DataTable
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
            Me.cboTRCANUDO.Focus()
            Me.Close()
        End If

    End Sub
    Private Sub cmdLimpiar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdLimpiar.Click
        pro_LimpiarCampos()
        Me.cboTRCANUDO.Focus()
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
        Me.cboTRCANUDO.Focus()
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

    Private Sub cboLIQUNUDO_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboTRCANUDO.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_USUARIO_Descripcion(Me.cboTRCANUDO, Me.cboTRCANUDO.SelectedIndex)
    End Sub
    Private Sub cboTRCAESTA_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboTRCAESTA.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_ESTADO(Me.cboTRCAESTA, Me.cboTRCAESTA.SelectedIndex)
    End Sub
    Private Sub cboFIPRVIGE_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboTRCAVIGE.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_VIGENCIA_Descripcion(Me.cboTRCAVIGE, Me.cboTRCAVIGE.SelectedIndex)
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