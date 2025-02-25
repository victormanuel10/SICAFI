Imports REGLAS_DEL_NEGOCIO

Public Class frm_PROPANTE

    '=======================================
    '*** FORMULARIO PROPIETARIO ANTERIOR ***
    '=======================================

#Region "INSTANCIAR FORMULARIO"

    Private Shared frm_Instance = Nothing

    Public Shared Function instance() As frm_PROPANTE
        If frm_Instance Is Nothing OrElse frm_Instance.isdisposed = True Then
            frm_Instance = New frm_PROPANTE
        End If

        frm_Instance.bringtofront()

        Return frm_Instance

    End Function

    Private Sub New()
        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()
        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
    End Sub

#End Region

#Region "VARIABLES"

    Dim boCONSULTA As Boolean = False

    Dim dt_CargaPropietarioActual As New DataTable

#End Region

#Region "CONSTRUCTORES"

    Public Sub New(ByVal o_dtCONSULTA As DataTable)

        vp_tblConsulta = o_dtCONSULTA

        InitializeComponent()

    End Sub

#End Region

#Region "PROCEDIMIENTOS"

    Private Sub pro_Reconsultar()

        Try

            Dim objdatos As New cla_PROPANTE

            ' verica por cual se realizo la consulta
            If boCONSULTA = False Then

                pro_LimpiarCampos()

            ElseIf boCONSULTA = True Then

                ' llena el datagrid de ficha predial
                Me.dgvCONSULTA.DataSource = vp_tblConsulta

                ' oculta la columna
                Me.dgvCONSULTA.Columns("FIPRIDRE").Visible = False

                ' llena el datagrid de propietario actual
                Dim objdatos123 As New cla_FIPRPROP
                Dim tbl123 As New DataTable

                tbl123 = objdatos123.fun_Consultar_FIPRPROP_X_FICHA_PREDIAL(Me.dgvCONSULTA.SelectedRows.Item(0).Cells(1).Value.ToString)

                ' verifica la existencia de registros
                If tbl123.Rows.Count > 0 Then

                    ' crea una nueva tabla
                    dt_CargaPropietarioActual = New DataTable

                    ' Crea las columnas
                    dt_CargaPropietarioActual.Columns.Add(New DataColumn("Nro_Ficha", GetType(String)))
                    dt_CargaPropietarioActual.Columns.Add(New DataColumn("Nro_Documento", GetType(String)))
                    dt_CargaPropietarioActual.Columns.Add(New DataColumn("Primer_Apellido", GetType(String)))
                    dt_CargaPropietarioActual.Columns.Add(New DataColumn("Segundo_Apellido", GetType(String)))
                    dt_CargaPropietarioActual.Columns.Add(New DataColumn("Nombre", GetType(String)))
                    dt_CargaPropietarioActual.Columns.Add(New DataColumn("Derecho", GetType(String)))

                    ' declara las variables
                    Dim stFPPRNUFI As String = ""
                    Dim stFPPRNUDO As String = ""
                    Dim stFPPRPRAP As String = ""
                    Dim stFPPRSEAP As String = ""
                    Dim stFIPRNOMB As String = ""
                    Dim stFIPRDERE As String = ""

                    ' crea el datarow
                    Dim dr1 As DataRow

                    Dim i As Integer = 0

                    For i = 0 To tbl123.Rows.Count - 1

                        stFPPRNUFI = tbl123.Rows(i).Item("FPPRNUFI").ToString
                        stFPPRNUDO = Trim(tbl123.Rows(i).Item("FPPRNUDO").ToString)
                        stFPPRPRAP = Trim(tbl123.Rows(i).Item("FPPRPRAP").ToString)
                        stFPPRSEAP = Trim(tbl123.Rows(i).Item("FPPRSEAP").ToString)
                        stFIPRNOMB = Trim(tbl123.Rows(i).Item("FPPRNOMB").ToString)
                        stFIPRDERE = Trim(tbl123.Rows(i).Item("FPPRDERE").ToString)

                        ' almacena la inconsistencia 
                        dr1 = dt_CargaPropietarioActual.NewRow()

                        dr1("Nro_Ficha") = stFPPRNUFI
                        dr1("Nro_Documento") = stFPPRNUDO
                        dr1("Primer_Apellido") = stFPPRPRAP
                        dr1("Segundo_Apellido") = stFPPRSEAP
                        dr1("Nombre") = stFIPRNOMB
                        dr1("Derecho") = stFIPRDERE

                        dt_CargaPropietarioActual.Rows.Add(dr1)

                    Next

                    ' carga el propietario actual
                    Me.dgvPROPACTU.DataSource = dt_CargaPropietarioActual

                    ' oculta la columna
                    Me.dgvPROPACTU.Columns("Nro_Ficha").Visible = False

                    ' instancia la clase
                    Dim objdatos1 As New cla_PROPANTE

                    BindingSource_PROPANTE_1.DataSource = objdatos1.fun_Buscar_PROPIETARIOS_X_NRO_DE_FICHA_Y_NRO_DE_DOCUMENTO(Trim(Me.dgvPROPACTU.SelectedRows.Item(0).Cells(0).Value.ToString), Trim(Me.dgvPROPACTU.SelectedRows.Item(0).Cells(1).Value.ToString))

                    Me.dgvPROPANTE.DataSource = BindingSource_PROPANTE_1

                    ' oculta la columna
                    Me.dgvPROPANTE.Columns("PRANIDRE").Visible = False
                    Me.dgvPROPANTE.Columns("PRANNUFI").Visible = False
                    Me.dgvPROPANTE.Columns("PRANNUDO").Visible = False
                    Me.dgvPROPANTE.Columns("PRANOBSE").Visible = False
                    Me.dgvPROPANTE.Columns("PRANESTA").Visible = False

                    Me.dgvPROPANTE.Columns("PRANCAAC").HeaderText = "Causa"
                    Me.dgvPROPANTE.Columns("PRANNUDO").HeaderText = "Nro_Documento"
                    Me.dgvPROPANTE.Columns("PRANPRAP").HeaderText = "Primer_Apellido"
                    Me.dgvPROPANTE.Columns("PRANSEAP").HeaderText = "Segundo_Apellido"
                    Me.dgvPROPANTE.Columns("PRANNOMB").HeaderText = "Nombre"

                    BindingNavigator_PROPANTE_1.BindingSource = BindingSource_PROPANTE_1

                End If

            End If

            '=================================================
            '*** CONFIGURA OBJETOS DEL FORMULARIO MAESTRO ***
            '=================================================

            Me.strBARRESTA.Items(2).Text = "Registros : " & BindingSource_PROPANTE_1.Count

            '==================================================
            '*** ASIGNA LOS PRIVILEGIOS DE LA BARRA DE MENU ***
            '==================================================

            Dim ContarRegistros As Integer = BindingSource_PROPANTE_1.Count

            Dim boCONTAGRE As Boolean = False
            Dim boCONTMODI As Boolean = False
            Dim boCONTELIM As Boolean = False
            Dim boCONTCONS As Boolean = True
            Dim boCONTRECO As Boolean = True

            pro_Permiso_Barra_De_Menu_Formulario_Formulario(ContarRegistros, Trim(Me.Name), boCONTAGRE, boCONTMODI, boCONTELIM, boCONTCONS, boCONTRECO)

            Me.cmdAGREGAR.Enabled = boCONTAGRE
            Me.cmdMODIFICAR.Enabled = boCONTMODI
            Me.cmdELIMINAR.Enabled = boCONTELIM
            Me.cmdCONSULTAR.Enabled = boCONTCONS
            Me.cmdRECONSULTAR.Enabled = boCONTRECO

            Me.cmdCONSULTAR.Enabled = True
            Me.cmdRECONSULTAR.Enabled = True
            Me.cmdAGREGAR.Enabled = True


        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub pro_ListaDeValoresPredios()

        Try
            ' verifica que existen registros
            If Me.dgvCONSULTA.RowCount > 0 Then

                ' llena el datagrid de propietario actual
                Dim objdatos123 As New cla_FIPRPROP
                Dim tbl123 As New DataTable

                tbl123 = objdatos123.fun_Consultar_FIPRPROP_X_FICHA_PREDIAL(Me.dgvCONSULTA.SelectedRows.Item(0).Cells(1).Value.ToString)

                ' verifica la existencia de registros
                If tbl123.Rows.Count > 0 Then

                    ' crea una nueva tabla
                    dt_CargaPropietarioActual = New DataTable

                    ' Crea las columnas
                    dt_CargaPropietarioActual.Columns.Add(New DataColumn("Nro_Ficha", GetType(String)))
                    dt_CargaPropietarioActual.Columns.Add(New DataColumn("Nro_Documento", GetType(String)))
                    dt_CargaPropietarioActual.Columns.Add(New DataColumn("Primer_Apellido", GetType(String)))
                    dt_CargaPropietarioActual.Columns.Add(New DataColumn("Segundo_Apellido", GetType(String)))
                    dt_CargaPropietarioActual.Columns.Add(New DataColumn("Nombre", GetType(String)))
                    dt_CargaPropietarioActual.Columns.Add(New DataColumn("Derecho", GetType(String)))

                    ' declara las variables
                    Dim stFPPRNUFI As String = ""
                    Dim stFPPRNUDO As String = ""
                    Dim stFPPRPRAP As String = ""
                    Dim stFPPRSEAP As String = ""
                    Dim stFIPRNOMB As String = ""
                    Dim stFIPRDERE As String = ""

                    ' crea el datarow
                    Dim dr1 As DataRow

                    Dim i As Integer = 0

                    For i = 0 To tbl123.Rows.Count - 1

                        stFPPRNUFI = tbl123.Rows(i).Item("FPPRNUFI").ToString
                        stFPPRNUDO = Trim(tbl123.Rows(i).Item("FPPRNUDO").ToString)
                        stFPPRPRAP = Trim(tbl123.Rows(i).Item("FPPRPRAP").ToString)
                        stFPPRSEAP = Trim(tbl123.Rows(i).Item("FPPRSEAP").ToString)
                        stFIPRNOMB = Trim(tbl123.Rows(i).Item("FPPRNOMB").ToString)
                        stFIPRDERE = Trim(tbl123.Rows(i).Item("FPPRDERE").ToString)

                        ' almacena la inconsistencia 
                        dr1 = dt_CargaPropietarioActual.NewRow()

                        dr1("Nro_Ficha") = stFPPRNUFI
                        dr1("Nro_Documento") = stFPPRNUDO
                        dr1("Primer_Apellido") = stFPPRPRAP
                        dr1("Segundo_Apellido") = stFPPRSEAP
                        dr1("Nombre") = stFIPRNOMB
                        dr1("Derecho") = stFIPRDERE

                        dt_CargaPropietarioActual.Rows.Add(dr1)

                    Next

                    ' carga el propietario actual
                    Me.dgvPROPACTU.DataSource = dt_CargaPropietarioActual

                    ' oculta la columna
                    Me.dgvPROPACTU.Columns("Nro_Ficha").Visible = False

                    ' instancia la clase
                    Dim objdatos1 As New cla_PROPANTE

                    Me.BindingSource_PROPANTE_1.DataSource = objdatos1.fun_Buscar_PROPIETARIOS_X_NRO_DE_FICHA_Y_NRO_DE_DOCUMENTO(Trim(Me.dgvPROPACTU.SelectedRows.Item(0).Cells(0).Value.ToString), Trim(Me.dgvPROPACTU.SelectedRows.Item(0).Cells(1).Value.ToString))

                    Me.dgvPROPANTE.DataSource = BindingSource_PROPANTE_1

                    ' oculta la columna
                    Me.dgvPROPANTE.Columns("PRANIDRE").Visible = False
                    Me.dgvPROPANTE.Columns("PRANNUFI").Visible = False
                    Me.dgvPROPANTE.Columns("PRANNUDO").Visible = False
                    Me.dgvPROPANTE.Columns("PRANOBSE").Visible = False
                    Me.dgvPROPANTE.Columns("PRANESTA").Visible = False

                    Me.dgvPROPANTE.Columns("PRANCAAC").HeaderText = "Causa"
                    Me.dgvPROPANTE.Columns("PRANNUDO").HeaderText = "Nro_Documento"
                    Me.dgvPROPANTE.Columns("PRANPRAP").HeaderText = "Primer_Apellido"
                    Me.dgvPROPANTE.Columns("PRANSEAP").HeaderText = "Segundo_Apellido"
                    Me.dgvPROPANTE.Columns("PRANNOMB").HeaderText = "Nombre"

                    Me.BindingNavigator_PROPANTE_1.BindingSource = Me.BindingSource_PROPANTE_1

                    ' verifica que existan registros
                    If Me.dgvPROPANTE.RowCount > 0 Then

                        ' carga los campos
                        Me.txtPRANESTA.Text = Trim(Me.dgvPROPANTE.SelectedRows.Item(0).Cells("PRANESTA").Value.ToString)
                        Me.txtPRANOBSE.Text = Trim(Me.dgvPROPANTE.SelectedRows.Item(0).Cells("PRANOBSE").Value.ToString)

                        'lista de valores
                        Me.lblPRANCAAC.Text = CStr(fun_Buscar_Lista_Valores_CAUSACTO(Trim(Me.dgvPROPANTE.SelectedRows.Item(0).Cells("PRANCAAC").Value.ToString)))
                        Me.lblPRANESTA.Text = CStr(fun_Buscar_Lista_Valores_ESTADO(Trim(Me.dgvPROPANTE.SelectedRows.Item(0).Cells("PRANESTA").Value.ToString)))

                    Else
                        pro_LimpiarCamposPropietarioAnterior()
                    End If

                End If
            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub pro_ListaDeValoresPropieariosActuales()

        Try
            If Me.dgvPROPACTU.RowCount > 0 Then

                ' instancia la clase
                Dim objdatos1 As New cla_PROPANTE

                Me.BindingSource_PROPANTE_1.DataSource = objdatos1.fun_Buscar_PROPIETARIOS_X_NRO_DE_FICHA_Y_NRO_DE_DOCUMENTO(Trim(Me.dgvPROPACTU.SelectedRows.Item(0).Cells(0).Value.ToString), Trim(Me.dgvPROPACTU.SelectedRows.Item(0).Cells(1).Value.ToString))

                Me.dgvPROPANTE.DataSource = BindingSource_PROPANTE_1

                ' oculta la columna
                Me.dgvPROPANTE.Columns("PRANIDRE").Visible = False
                Me.dgvPROPANTE.Columns("PRANNUFI").Visible = False
                Me.dgvPROPANTE.Columns("PRANNUDO").Visible = False
                Me.dgvPROPANTE.Columns("PRANOBSE").Visible = False
                Me.dgvPROPANTE.Columns("PRANESTA").Visible = False

                Me.dgvPROPANTE.Columns("PRANCAAC").HeaderText = "Causa"
                Me.dgvPROPANTE.Columns("PRANNUDO").HeaderText = "Nro_Documento"
                Me.dgvPROPANTE.Columns("PRANPRAP").HeaderText = "Primer_Apellido"
                Me.dgvPROPANTE.Columns("PRANSEAP").HeaderText = "Segundo_Apellido"
                Me.dgvPROPANTE.Columns("PRANNOMB").HeaderText = "Nombre"

                Me.BindingNavigator_PROPANTE_1.BindingSource = Me.BindingSource_PROPANTE_1

                ' verifica que existan registros
                If Me.dgvPROPANTE.RowCount > 0 Then

                    ' carga los campos
                    Me.txtPRANESTA.Text = Trim(Me.dgvPROPANTE.SelectedRows.Item(0).Cells("PRANESTA").Value.ToString)
                    Me.txtPRANOBSE.Text = Trim(Me.dgvPROPANTE.SelectedRows.Item(0).Cells("PRANOBSE").Value.ToString)

                    'lista de valores
                    Me.lblPRANCAAC.Text = CStr(fun_Buscar_Lista_Valores_CAUSACTO(Trim(Me.dgvPROPANTE.SelectedRows.Item(0).Cells("PRANCAAC").Value.ToString)))
                    Me.lblPRANESTA.Text = CStr(fun_Buscar_Lista_Valores_ESTADO(Trim(Me.dgvPROPANTE.SelectedRows.Item(0).Cells("PRANESTA").Value.ToString)))

                Else
                    pro_LimpiarCamposPropietarioAnterior()
                End If


            End If


        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub pro_ListaDeValoresPropieariosAnteriores()

        Try

            ' verifica que existan registros
            If Me.dgvPROPANTE.RowCount > 0 Then

                ' carga los campos
                Me.txtPRANESTA.Text = Trim(Me.dgvPROPANTE.SelectedRows.Item(0).Cells("PRANESTA").Value.ToString)
                Me.txtPRANOBSE.Text = Trim(Me.dgvPROPANTE.SelectedRows.Item(0).Cells("PRANOBSE").Value.ToString)

                'lista de valores
                Me.lblPRANCAAC.Text = CStr(fun_Buscar_Lista_Valores_CAUSACTO(Trim(Me.dgvPROPANTE.SelectedRows.Item(0).Cells("PRANCAAC").Value.ToString)))
                Me.lblPRANESTA.Text = CStr(fun_Buscar_Lista_Valores_ESTADO(Trim(Me.dgvPROPANTE.SelectedRows.Item(0).Cells("PRANESTA").Value.ToString)))

            Else
                pro_LimpiarCamposPropietarioAnterior()
            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub pro_LimpiarCampos()

        Me.dgvCONSULTA.DataSource = New DataTable
        Me.dgvPROPACTU.DataSource = New DataTable
        Me.dgvPROPANTE.DataSource = New DataTable

        Me.lblPRANCAAC.Text = ""

        Me.strBARRESTA.Items(0).Text = "Propietario anterior"

    End Sub
    Private Sub pro_LimpiarCamposPropietarioAnterior()

        Me.lblPRANCAAC.Text = ""
        Me.lblPRANESTA.Text = ""
        Me.txtPRANESTA.Text = ""
        Me.txtPRANOBSE.Text = ""

    End Sub
    Private Sub pro_PermisoMenuPrincipal()

        If Me.dgvPROPANTE.RowCount > 0 Then

            Me.cmdAGREGAR.Enabled = False
            Me.cmdMODIFICAR.Enabled = True
            Me.cmdELIMINAR.Enabled = True
            Me.cmdCONSULTAR.Enabled = True
            Me.cmdRECONSULTAR.Enabled = False

        ElseIf Me.dgvPROPACTU.RowCount > 0 And Me.dgvCONSULTA.RowCount > 0 Then

            Me.cmdAGREGAR.Enabled = True
            Me.cmdMODIFICAR.Enabled = False
            Me.cmdELIMINAR.Enabled = False
            Me.cmdCONSULTAR.Enabled = True
            Me.cmdRECONSULTAR.Enabled = False

        Else
            Me.cmdAGREGAR.Enabled = False
            Me.cmdMODIFICAR.Enabled = False
            Me.cmdELIMINAR.Enabled = False
            Me.cmdCONSULTAR.Enabled = True
            Me.cmdRECONSULTAR.Enabled = False

        End If

    End Sub

#End Region

#Region "MENU"

    Private Sub cmdAGREGAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAGREGAR.Click

        Try
            Dim frm_Insertar_PROPANTE As New frm_insertar_PROPANTE(Trim(Me.dgvPROPACTU.SelectedRows.Item(0).Cells(0).Value.ToString), Trim(Me.dgvPROPACTU.SelectedRows.Item(0).Cells(1).Value.ToString))
            frm_Insertar_PROPANTE.ShowDialog()

            pro_ListaDeValoresPropieariosActuales()

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub cmdMODIFICAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdMODIFICAR.Click

        Try
            Dim frm_modificar_PROPANTE As New frm_modificar_PROPANTE(Trim(Me.dgvPROPACTU.SelectedRows.Item(0).Cells(0).Value.ToString), Trim(Me.dgvPROPACTU.SelectedRows.Item(0).Cells(1).Value.ToString), Trim(Me.dgvPROPANTE.SelectedRows.Item(0).Cells(0).Value.ToString))
            frm_modificar_PROPANTE.ShowDialog()

            pro_ListaDeValoresPropieariosActuales()

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub cmdELIMINAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdELIMINAR.Click

        Try
            If MessageBox.Show("¿ Desea eliminar el registro seleccionado ? ", "Mensaje ...", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then
                Dim objdatos As New cla_PROPANTE

                If objdatos.fun_Eliminar_PROPANTE(Integer.Parse(Me.dgvPROPANTE.SelectedRows.Item(0).Cells(0).Value.ToString)) Then

                    pro_LimpiarCamposPropietarioAnterior()
                    pro_ListaDeValoresPropieariosActuales()
                    pro_PermisoMenuPrincipal()
                Else
                    frm_INCO_eliminar_registro_padre_con_relación_de_registros_hijos.ShowDialog()
                End If

            End If

        Catch ex As Exception
            mod_MENSAJE.No_Existe_Un_Registro_Seleccionado()
        End Try

    End Sub
    Private Sub cmdCONSULTAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCONSULTAR.Click

        Try
            vp_tblConsulta = New DataTable

            frm_consultar_PROPANTE.ShowDialog()

            If vp_tblConsulta.Rows.Count <> 0 Then
                boCONSULTA = True
                pro_Reconsultar()
                pro_ListaDeValoresPredios()
                pro_PermisoMenuPrincipal()
            Else
                boCONSULTA = False
            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub cmdRECONSULTAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdRECONSULTAR.Click

        If Me.dgvCONSULTA.RowCount > 0 Then

            boCONSULTA = True

            pro_Reconsultar()
            pro_ListaDeValoresPropieariosAnteriores()
            pro_PermisoMenuPrincipal()

        End If

    End Sub
    Private Sub cmdSALIR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSALIR.Click
        Me.Close()
    End Sub

    Private Sub BindingNavigatorMoveFirstItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BindingNavigatorMoveFirstItem.Click
        pro_ListaDeValoresPropieariosAnteriores()
        pro_PermisoMenuPrincipal()
    End Sub
    Private Sub BindingNavigatorMovePreviousItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BindingNavigatorMovePreviousItem.Click
        pro_ListaDeValoresPropieariosAnteriores()
        pro_PermisoMenuPrincipal()
    End Sub
    Private Sub BindingNavigatorMoveNextItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BindingNavigatorMoveNextItem.Click
        pro_ListaDeValoresPropieariosAnteriores()
        pro_PermisoMenuPrincipal()
    End Sub
    Private Sub BindingNavigatorMoveLastItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BindingNavigatorMoveLastItem.Click
        pro_ListaDeValoresPropieariosAnteriores()
        pro_PermisoMenuPrincipal()
    End Sub

#End Region

#Region "FORMULARIO"

#Region "Load"

    Private Sub Frm_PROPANTE_1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        pro_LimpiarCampos()
        pro_PermisoMenuPrincipal()

    End Sub

#End Region

#Region "CellClick"

    Private Sub dgvCONSULTA_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvCONSULTA.CellClick
        pro_ListaDeValoresPredios()
        pro_PermisoMenuPrincipal()
    End Sub
    Private Sub dgvPROPACTU_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvPROPACTU.CellClick
        pro_ListaDeValoresPropieariosActuales()
        pro_PermisoMenuPrincipal()
    End Sub
    Private Sub dgvPROPANTE_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvPROPANTE.CellClick
        pro_ListaDeValoresPropieariosAnteriores()
        pro_PermisoMenuPrincipal()
    End Sub

#End Region

#Region "KeyUp"

    Private Sub dgvCONSULTA_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgvCONSULTA.KeyUp
        If e.KeyCode = Keys.Down Or e.KeyCode = Keys.Up Or e.KeyCode = Keys.Enter Or e.KeyCode = Keys.PageUp Or e.KeyCode = Keys.PageDown Or e.KeyCode = Keys.PageUp Or e.KeyCode = Keys.PageDown Then
            pro_ListaDeValoresPredios()
            pro_PermisoMenuPrincipal()
        End If
    End Sub
    Private Sub dgvPROPACTU_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgvPROPACTU.KeyUp
        If e.KeyCode = Keys.Down Or e.KeyCode = Keys.Up Or e.KeyCode = Keys.Enter Or e.KeyCode = Keys.PageUp Or e.KeyCode = Keys.PageDown Or e.KeyCode = Keys.PageUp Or e.KeyCode = Keys.PageDown Then
            pro_ListaDeValoresPropieariosActuales()
            pro_PermisoMenuPrincipal()
        End If
    End Sub
    Private Sub dgvPROPANTE_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgvPROPANTE.KeyUp
        If e.KeyCode = Keys.Down Or e.KeyCode = Keys.Up Or e.KeyCode = Keys.Enter Or e.KeyCode = Keys.PageUp Or e.KeyCode = Keys.PageDown Or e.KeyCode = Keys.PageUp Or e.KeyCode = Keys.PageDown Then
            pro_ListaDeValoresPropieariosAnteriores()
            pro_PermisoMenuPrincipal()
        End If
    End Sub

#End Region

#Region "KeyDown"

    Private Sub dgvINTEGRANTE_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgvPROPACTU.KeyDown
        '===============================================================================================
        '*** INSERTAR REGISTROS ***
        '===============================================================================================


        If e.KeyCode = Keys.F2 Then
            If Me.cmdAGREGAR.Enabled = True Then
                Me.cmdAGREGAR.PerformClick()
            Else
                mod_MENSAJE.Usuario_No_Tiene_Permiso_Para_Realizar_La_Operacion()
            End If
        End If

        '===============================================================================================
        'MODIFICAR REGISTROS
        '===============================================================================================

        If e.KeyCode = Keys.F3 Then
            If Me.cmdMODIFICAR.Enabled = True Then
                Me.cmdMODIFICAR.PerformClick()
            Else
                Dim ContarRegistros As Integer = BindingSource_PROPANTE_1.Count

                If ContarRegistros = 0 Then
                    mod_MENSAJE.No_Existen_Registros_En_Base_De_Datos()
                Else
                    mod_MENSAJE.Usuario_No_Tiene_Permiso_Para_Realizar_La_Operacion()
                End If

            End If
        End If

        '===============================================================================================
        '*** ELIMINAR REGISTROS ***
        '===============================================================================================

        If e.KeyCode = Keys.Delete Then
            If cmdELIMINAR.Enabled = True Then
                Me.cmdELIMINAR.PerformClick()
            Else
                Dim ContarRegistros As Integer = BindingSource_PROPANTE_1.Count

                If ContarRegistros = 0 Then
                    mod_MENSAJE.No_Existen_Registros_En_Base_De_Datos()
                Else
                    mod_MENSAJE.Usuario_No_Tiene_Permiso_Para_Realizar_La_Operacion()
                End If

            End If
        End If

        '===============================================================================================
        '*** CONSULTAR REGISTROS ***
        '===============================================================================================

        If e.KeyCode = Keys.F7 Then
            If Me.cmdCONSULTAR.Enabled = True Then
                Me.cmdCONSULTAR.PerformClick()
            Else
                mod_MENSAJE.No_Existen_Registros_En_Base_De_Datos()
            End If
        End If

        '===============================================================================================
        '*** RECONSULTAR REGISTROS ***
        '===============================================================================================

        If e.KeyCode = Keys.F8 Then
            If Me.cmdCONSULTAR.Enabled = True Then
                Me.cmdRECONSULTAR.PerformClick()
            Else
                mod_MENSAJE.No_Existen_Registros_En_Base_De_Datos()
            End If
        End If

    End Sub

#End Region

#End Region

End Class