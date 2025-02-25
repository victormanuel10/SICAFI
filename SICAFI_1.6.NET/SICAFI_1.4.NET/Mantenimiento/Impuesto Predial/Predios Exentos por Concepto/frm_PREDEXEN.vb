Imports REGLAS_DEL_NEGOCIO

Public Class frm_PREDEXEN

    '================================================
    '*** PREDIOS EXENTOS DE IMPUESTO POR CONCEPTO ***
    '================================================

#Region "VARIABLES"

    Dim boCONSULTA As Boolean = False

#End Region

#Region "CONSTRUCTOR"

    Public Sub New(ByVal idCodigo As Integer)

        vp_inConsulta = idCodigo
        InitializeComponent()

    End Sub

#End Region

#Region "INSTANCIAR FORMULARIO"

    Private Shared frm_Instance = Nothing

    Public Shared Function instance() As frm_PREDEXEN
        If frm_Instance Is Nothing OrElse frm_Instance.isdisposed = True Then
            frm_Instance = New frm_PREDEXEN
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

#Region "PROCEDIMIENTOS"

    Private Sub pro_Reconsultar()
        Try

            Dim objdatos As New cla_PREDEXEN

            If boCONSULTA = False Then
                Me.BindingSource_PREDEXEN_1.DataSource = objdatos.fun_Consultar_PREDEXEN
            Else
                Me.BindingSource_PREDEXEN_1.DataSource = objdatos.fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_PREDEXEN(vp_inConsulta)
            End If

            Me.dgvPREDEXEN_1.DataSource = BindingSource_PREDEXEN_1
            Me.dgvPREDEXEN_2.DataSource = BindingSource_PREDEXEN_1
            Me.BindingNavigator_PREDEXEN_1.BindingSource = BindingSource_PREDEXEN_1

            '==================================================
            '*** CONFIGURA OBJETOS DEL FORMULARIO MAESTRO ***
            '==================================================

            Me.strBARRESTA.Items(2).Text = "Registros : " & Me.BindingSource_PREDEXEN_1.Count

            Me.dgvPREDEXEN_1.Columns("PREXDEPA").HeaderText = "Departamento"
            Me.dgvPREDEXEN_1.Columns("PREXMUNI").HeaderText = "Municipio"
            Me.dgvPREDEXEN_1.Columns("PREXCLSE").HeaderText = "Sector"
            Me.dgvPREDEXEN_1.Columns("PREXNUFI").HeaderText = "Nro. Ficha"
            Me.dgvPREDEXEN_1.Columns("PREXTIIM").HeaderText = "Tipo Impuesto"
            Me.dgvPREDEXEN_1.Columns("PREXCONC").HeaderText = "Concepto"

            Me.dgvPREDEXEN_2.Columns("PREXVIIN").HeaderText = "Vigencia Inicial"
            Me.dgvPREDEXEN_2.Columns("PREXVIFI").HeaderText = "Vigencia Final"
            Me.dgvPREDEXEN_2.Columns("PREXPOAP").HeaderText = "Porcentaje(%) Aplicado"
            Me.dgvPREDEXEN_2.Columns("PREXRESO").HeaderText = "Resolución"
            Me.dgvPREDEXEN_2.Columns("PREXFECH").HeaderText = "Fecha Resolución"
            Me.dgvPREDEXEN_2.Columns("PREXOBSE").HeaderText = "Observación"
            Me.dgvPREDEXEN_2.Columns("PREXESTA").HeaderText = "Estado"

            Me.dgvPREDEXEN_1.Columns("PREXIDRE").Visible = False
            Me.dgvPREDEXEN_1.Columns("PREXVIIN").Visible = False
            Me.dgvPREDEXEN_1.Columns("PREXVIFI").Visible = False
            Me.dgvPREDEXEN_1.Columns("PREXPOAP").Visible = False
            Me.dgvPREDEXEN_1.Columns("PREXRESO").Visible = False
            Me.dgvPREDEXEN_1.Columns("PREXFECH").Visible = False
            Me.dgvPREDEXEN_1.Columns("PREXOBSE").Visible = False
            Me.dgvPREDEXEN_1.Columns("PREXESTA").Visible = False

            Me.dgvPREDEXEN_2.Columns("PREXIDRE").Visible = False
            Me.dgvPREDEXEN_2.Columns("PREXDEPA").Visible = False
            Me.dgvPREDEXEN_2.Columns("PREXMUNI").Visible = False
            Me.dgvPREDEXEN_2.Columns("PREXCLSE").Visible = False
            Me.dgvPREDEXEN_2.Columns("PREXNUFI").Visible = False
            Me.dgvPREDEXEN_2.Columns("PREXTIIM").Visible = False
            Me.dgvPREDEXEN_2.Columns("PREXCONC").Visible = False
            Me.dgvPREDEXEN_2.Columns("PREXOBSE").Visible = False

            '==================================================
            '*** ASIGNA LOS PRIVILEGIOS DE LA BARRA DE MENU ***
            '==================================================

            Dim ContarRegistros As Integer = Me.BindingSource_PREDEXEN_1.Count

            Dim boCONTAGRE As Boolean = False
            Dim boCONTMODI As Boolean = False
            Dim boCONTELIM As Boolean = False
            Dim boCONTCONS As Boolean = False
            Dim boCONTRECO As Boolean = False

            pro_Permiso_Barra_De_Menu_Formulario_Formulario(ContarRegistros, Trim(Me.Name), boCONTAGRE, boCONTMODI, boCONTELIM, boCONTCONS, boCONTRECO)

            Me.cmdAGREGAR.Enabled = boCONTAGRE
            Me.cmdMODIFICAR.Enabled = boCONTMODI
            Me.cmdELIMINAR.Enabled = boCONTELIM
            Me.cmdCONSULTAR.Enabled = boCONTCONS
            Me.cmdRECONSULTAR.Enabled = boCONTRECO

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub pro_ListaDeValores()

        Try
            If Me.BindingSource_PREDEXEN_1.Count > 0 Then

                Me.lblPREXDEPA.Text = CType(fun_Buscar_Lista_Valores_DEPARTAMENTO(Me.dgvPREDEXEN_1.CurrentRow.Cells("PREXDEPA").Value.ToString()), String)
                Me.lblPREXMUNI.Text = CType(fun_Buscar_Lista_Valores_MUNICIPIO(Me.dgvPREDEXEN_1.CurrentRow.Cells("PREXDEPA").Value.ToString(), Me.dgvPREDEXEN_1.CurrentRow.Cells("PREXMUNI").Value.ToString()), String)
                Me.lblPREXCLSE.Text = CType(fun_Buscar_Lista_Valores_CLASSECT(Me.dgvPREDEXEN_1.CurrentRow.Cells("PREXCLSE").Value.ToString()), String)
                Me.lblPREXVIIN.Text = CType(fun_Buscar_Lista_Valores_VIGENCIA(Me.dgvPREDEXEN_1.CurrentRow.Cells("PREXVIIN").Value.ToString()), String)
                Me.lblPREXVIFI.Text = CType(fun_Buscar_Lista_Valores_VIGENCIA(Me.dgvPREDEXEN_1.CurrentRow.Cells("PREXVIFI").Value.ToString()), String)
                Me.lblPREXTIIM.Text = CType(fun_Buscar_Lista_Valores_TIPOIMPU(Me.dgvPREDEXEN_1.CurrentRow.Cells("PREXTIIM").Value.ToString()), String)
                Me.lblPREXCONC.Text = CType(fun_Buscar_Lista_Valores_CONCEPTO(Me.dgvPREDEXEN_1.CurrentRow.Cells("PREXTIIM").Value.ToString(), Me.dgvPREDEXEN_1.CurrentRow.Cells("PREXCONC").Value.ToString()), String)
                Me.lblPREXOBSE.Text = CType(Me.dgvPREDEXEN_1.CurrentRow.Cells("PREXOBSE").Value.ToString(), String)

            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub pro_LimpiarCampos()

        Me.lblPREXMUNI.Text = ""
        Me.lblPREXDEPA.Text = ""
        Me.lblPREXCLSE.Text = ""
        Me.lblPREXVIFI.Text = ""
        Me.lblPREXTIIM.Text = ""
        Me.lblPREXCONC.Text = ""
        Me.lblPREXVIIN.Text = ""
        Me.lblPREXOBSE.Text = ""

    End Sub

#End Region

#Region "MENU"

    Private Sub cmdAGREGAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAGREGAR.Click

        Try
            frm_insertar_PREDEXEN.ShowDialog()
            boCONSULTA = False
            pro_Reconsultar()
            pro_ListaDeValores()

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub cmdELIMINAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdELIMINAR.Click

        Try
            If MessageBox.Show("¿ Desea eliminar el registro seleccionado ? ", "Mensaje...", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then
                Dim objdatos As New cla_PREDEXEN

                If objdatos.fun_Eliminar_PREDEXEN(Integer.Parse(Me.dgvPREDEXEN_1.SelectedRows.Item(0).Cells(0).Value.ToString())) Then
                    boCONSULTA = False
                    pro_Reconsultar()
                    pro_LimpiarCampos()
                    pro_ListaDeValores()
                Else
                    frm_INCO_eliminar_registro_padre_con_relación_de_registros_hijos.ShowDialog()
                End If

            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub cmdMODIFICAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdMODIFICAR.Click

        Try
            Dim frm_modificar As New frm_modificar_PREDEXEN(Integer.Parse(Me.dgvPREDEXEN_1.SelectedRows.Item(0).Cells(0).Value.ToString()))

            frm_modificar.ShowDialog()
            pro_Reconsultar()
            pro_ListaDeValores()

        Catch ex As Exception
            frm_INCO_modifircar_registros_sin_listas_de_valores.ShowDialog()
        End Try

    End Sub
    Private Sub cmdCONSULTAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCONSULTAR.Click

        Try
            vp_inConsulta = 0

            frm_consultar_PREDEXEN.ShowDialog()

            If vp_inConsulta > 0 Then
                boCONSULTA = True
            Else
                boCONSULTA = False
            End If

            pro_Reconsultar()
            pro_ListaDeValores()

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub cmdRECONSULTAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdRECONSULTAR.Click
        boCONSULTA = False
        pro_Reconsultar()
        pro_ListaDeValores()
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

#Region "Load"

    Private Sub frm_ALUMPUBL_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        pro_Reconsultar()
    End Sub

#End Region

#Region "GotFocus"

    Private Sub frm_ALUMPUBL_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.GotFocus
        pro_ListaDeValores()
    End Sub
    Private Sub dgvALUMPUBL_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvPREDEXEN_1.GotFocus, dgvPREDEXEN_2.GotFocus
        Me.strBARRESTA.Items(0).Text = dgvPREDEXEN_1.AccessibleDescription
    End Sub

#End Region

#Region "KeyDown"

    Private Sub dgvALUMPUBL_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgvPREDEXEN_1.KeyDown, dgvPREDEXEN_2.KeyDown
        '===============================================================================================
        '*** INSERTAR REGISTROS ***
        '===============================================================================================


        If e.KeyCode = Keys.F2 Then
            If cmdAGREGAR.Enabled = True Then
                cmdAGREGAR.PerformClick()
            Else
                mod_MENSAJE.Usuario_No_Tiene_Permiso_Para_Realizar_La_Operacion()
            End If
        End If

        '===============================================================================================
        'MODIFICAR REGISTROS
        '===============================================================================================

        If e.KeyCode = Keys.F3 Then
            If cmdMODIFICAR.Enabled = True Then
                cmdMODIFICAR.PerformClick()
            Else
                Dim ContarRegistros As Integer = BindingSource_PREDEXEN_1.Count

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
                cmdELIMINAR.PerformClick()
            Else
                Dim ContarRegistros As Integer = BindingSource_PREDEXEN_1.Count

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
            If cmdCONSULTAR.Enabled = True Then
                cmdCONSULTAR.PerformClick()
            Else
                mod_MENSAJE.No_Existen_Registros_En_Base_De_Datos()
            End If
        End If

        '===============================================================================================
        '*** RECONSULTAR REGISTROS ***
        '===============================================================================================

        If e.KeyCode = Keys.F8 Then
            If cmdCONSULTAR.Enabled = True Then
                cmdRECONSULTAR.PerformClick()
            Else
                mod_MENSAJE.No_Existen_Registros_En_Base_De_Datos()
            End If
        End If

    End Sub

#End Region

#Region "KeyUp"

    Private Sub dgvALUMPUBL_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgvPREDEXEN_1.KeyUp, dgvPREDEXEN_2.KeyUp
        If e.KeyCode = Keys.Down Or e.KeyCode = Keys.Up Or e.KeyCode = Keys.Enter Or e.KeyCode = Keys.PageUp Or e.KeyCode = Keys.PageDown Then
            pro_ListaDeValores()
        End If
    End Sub

#End Region

#Region "CellClick"

    Private Sub dgvALUMPUBL_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvPREDEXEN_1.CellClick, dgvPREDEXEN_2.CellClick
        pro_ListaDeValores()
    End Sub

#End Region

#End Region


End Class