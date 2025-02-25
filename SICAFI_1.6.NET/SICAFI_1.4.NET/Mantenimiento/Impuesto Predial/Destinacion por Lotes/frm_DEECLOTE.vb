Imports REGLAS_DEL_NEGOCIO

Public Class frm_DEECLOTE

    '=======================================
    '*** DESTINACIÓN ECONÓMICA POR LOTES ***
    '=======================================

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

    Public Shared Function instance() As frm_DEECLOTE
        If frm_Instance Is Nothing OrElse frm_Instance.isdisposed = True Then
            frm_Instance = New frm_DEECLOTE
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

            Dim objdatos As New cla_DEECLOTE

            If boCONSULTA = False Then
                Me.BindingSource_DEECLOTE_1.DataSource = objdatos.fun_Consultar_DEECLOTE
            Else
                Me.BindingSource_DEECLOTE_1.DataSource = objdatos.fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_DEECLOTE(vp_inConsulta)
            End If

            Me.dgvDEECLOTE_1.DataSource = BindingSource_DEECLOTE_1
            Me.dgvDEECLOTE_2.DataSource = BindingSource_DEECLOTE_1
            Me.BindingNavigator_DEECLOTE_1.BindingSource = BindingSource_DEECLOTE_1

            '==================================================
            '*** CONFIGURA OBJETOS DEL FORMULARIO MAESTRO ***
            '==================================================

            Me.strBARRESTA.Items(2).Text = "Registros : " & Me.BindingSource_DEECLOTE_1.Count

            Me.dgvDEECLOTE_1.Columns("DELODEPA").HeaderText = "Departamento"
            Me.dgvDEECLOTE_1.Columns("DELOMUNI").HeaderText = "Municipio"
            Me.dgvDEECLOTE_1.Columns("DELOCLSE").HeaderText = "Sector"
            Me.dgvDEECLOTE_1.Columns("DELOVIGE").HeaderText = "Vigencia"
            Me.dgvDEECLOTE_1.Columns("DELODEEC").HeaderText = "Destino"

            Me.dgvDEECLOTE_2.Columns("DELOLOTE").HeaderText = "Lote"
            Me.dgvDEECLOTE_2.Columns("DELOLE44").HeaderText = "Ley 44"
            Me.dgvDEECLOTE_2.Columns("DELOIMPR").HeaderText = "Predial"
            Me.dgvDEECLOTE_2.Columns("DELOACBO").HeaderText = "Acti. bomberil"
            Me.dgvDEECLOTE_2.Columns("DELOALPU").HeaderText = "Alum. publico"
            Me.dgvDEECLOTE_2.Columns("DELOTAAS").HeaderText = "Tasa de aseo"
            Me.dgvDEECLOTE_2.Columns("DELOESTA").HeaderText = "Estado"

            Me.dgvDEECLOTE_1.Columns("DELOIDRE").Visible = False
            Me.dgvDEECLOTE_1.Columns("DELOLOTE").Visible = False
            Me.dgvDEECLOTE_1.Columns("DELOLE44").Visible = False
            Me.dgvDEECLOTE_1.Columns("DELOIMPR").Visible = False
            Me.dgvDEECLOTE_1.Columns("DELOACBO").Visible = False
            Me.dgvDEECLOTE_1.Columns("DELOALPU").Visible = False
            Me.dgvDEECLOTE_1.Columns("DELOTAAS").Visible = False
            Me.dgvDEECLOTE_1.Columns("DELOESTA").Visible = False

            Me.dgvDEECLOTE_2.Columns("DELOIDRE").Visible = False
            Me.dgvDEECLOTE_2.Columns("DELODEPA").Visible = False
            Me.dgvDEECLOTE_2.Columns("DELOMUNI").Visible = False
            Me.dgvDEECLOTE_2.Columns("DELOCLSE").Visible = False
            Me.dgvDEECLOTE_2.Columns("DELOVIGE").Visible = False
            Me.dgvDEECLOTE_2.Columns("DELODEEC").Visible = False

            '==================================================
            '*** ASIGNA LOS PRIVILEGIOS DE LA BARRA DE MENU ***
            '==================================================

            Dim ContarRegistros As Integer = Me.BindingSource_DEECLOTE_1.Count

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
            If Me.BindingSource_DEECLOTE_1.Count > 0 Then

                Me.lblTAPEDEPA.Text = CType(fun_Buscar_Lista_Valores_DEPARTAMENTO(Me.dgvDEECLOTE_1.CurrentRow.Cells("DELODEPA").Value.ToString()), String)
                Me.lblTAPEMUNI.Text = CType(fun_Buscar_Lista_Valores_MUNICIPIO(Me.dgvDEECLOTE_1.CurrentRow.Cells("DELODEPA").Value.ToString(), Me.dgvDEECLOTE_1.CurrentRow.Cells("DELOMUNI").Value.ToString()), String)
                Me.lblTAPECLSE.Text = CType(fun_Buscar_Lista_Valores_CLASSECT(Me.dgvDEECLOTE_1.CurrentRow.Cells("DELOCLSE").Value.ToString()), String)
                Me.lblTAPEVIGE.Text = CType(fun_Buscar_Lista_Valores_VIGENCIA(Me.dgvDEECLOTE_1.CurrentRow.Cells("DELOVIGE").Value.ToString()), String)
                Me.lblTAPEDEEC.Text = CType(fun_Buscar_Lista_Valores_DESTECON(Me.dgvDEECLOTE_1.CurrentRow.Cells("DELODEEC").Value.ToString()), String)

            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub pro_LimpiarCampos()

        Me.lblTAPEMUNI.Text = ""
        Me.lblTAPEDEPA.Text = ""
        Me.lblTAPECLSE.Text = ""
        Me.lblTAPEVIGE.Text = ""
        Me.lblTAPEDEEC.Text = ""

    End Sub

#End Region

#Region "MENU"

    Private Sub cmdAGREGAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAGREGAR.Click

        Try
            frm_insertar_DEECLOTE.ShowDialog()
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
                Dim objdatos As New cla_DEECLOTE

                If objdatos.fun_Eliminar_DEECLOTE(Integer.Parse(Me.dgvDEECLOTE_1.SelectedRows.Item(0).Cells(0).Value.ToString())) Then
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
            Dim frm_modificar As New frm_modificar_DEECLOTE(Integer.Parse(Me.dgvDEECLOTE_1.SelectedRows.Item(0).Cells(0).Value.ToString()))

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

            frm_consultar_DEECLOTE.ShowDialog()

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
    Private Sub dgvALUMPUBL_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvDEECLOTE_1.GotFocus, dgvDEECLOTE_2.GotFocus
        Me.strBARRESTA.Items(0).Text = dgvDEECLOTE_1.AccessibleDescription
    End Sub

#End Region

#Region "KeyDown"

    Private Sub dgvALUMPUBL_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgvDEECLOTE_1.KeyDown, dgvDEECLOTE_2.KeyDown
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
                Dim ContarRegistros As Integer = BindingSource_DEECLOTE_1.Count

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
                Dim ContarRegistros As Integer = BindingSource_DEECLOTE_1.Count

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

    Private Sub dgvALUMPUBL_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgvDEECLOTE_1.KeyUp, dgvDEECLOTE_2.KeyUp
        If e.KeyCode = Keys.Down Or e.KeyCode = Keys.Up Or e.KeyCode = Keys.Enter Or e.KeyCode = Keys.PageUp Or e.KeyCode = Keys.PageDown Then
            pro_ListaDeValores()
        End If
    End Sub

#End Region

#Region "CellClick"

    Private Sub dgvALUMPUBL_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvDEECLOTE_1.CellClick, dgvDEECLOTE_2.CellClick
        pro_ListaDeValores()
    End Sub

#End Region

#End Region


End Class