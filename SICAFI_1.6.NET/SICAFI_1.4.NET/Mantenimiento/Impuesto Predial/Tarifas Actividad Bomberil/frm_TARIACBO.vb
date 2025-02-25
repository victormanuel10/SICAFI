Imports REGLAS_DEL_NEGOCIO

Public Class frm_TARIACBO

    '==========================
    '*** ACTIVIDAD BOMBERIL ***
    '==========================

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

    Public Shared Function instance() As frm_TARIACBO
        If frm_Instance Is Nothing OrElse frm_Instance.isdisposed = True Then
            frm_Instance = New frm_TARIACBO
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

            Dim objdatos As New cla_TARIACBO

            If boCONSULTA = False Then
                Me.BindingSource_TARIACBO_1.DataSource = objdatos.fun_Consultar_TARIACBO
            Else
                Me.BindingSource_TARIACBO_1.DataSource = objdatos.fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_TARIACBO(vp_inConsulta)
            End If

            Me.dgvTARIACBO_1.DataSource = BindingSource_TARIACBO_1
            Me.dgvTARIACBO_2.DataSource = BindingSource_TARIACBO_1
            Me.BindingNavigator_TARIACBO_1.BindingSource = BindingSource_TARIACBO_1

            '==================================================
            '*** CONFIGURA OBJETOS DEL FORMULARIO MAESTRO ***
            '==================================================

            Me.strBARRESTA.Items(2).Text = "Registros : " & Me.BindingSource_TARIACBO_1.Count

            Me.dgvTARIACBO_1.Columns("TAABDEPA").HeaderText = "Departamento"
            Me.dgvTARIACBO_1.Columns("TAABMUNI").HeaderText = "Municipio"
            Me.dgvTARIACBO_1.Columns("TAABCLSE").HeaderText = "Sector"
            Me.dgvTARIACBO_1.Columns("TAABVIGE").HeaderText = "Vigencia"
            Me.dgvTARIACBO_1.Columns("TAABTIPO").HeaderText = "Tipo"
            Me.dgvTARIACBO_1.Columns("TAABTARE").HeaderText = "Tarifa residencial"
            Me.dgvTARIACBO_1.Columns("TAABTACO").HeaderText = "Tarifa comercial"
            Me.dgvTARIACBO_1.Columns("TAABTAIN").HeaderText = "Tarifa industrial"
            Me.dgvTARIACBO_1.Columns("TAABESTA").HeaderText = "Estado"

            Me.dgvTARIACBO_2.Columns("TAABESTR").HeaderText = "Estrato"
            Me.dgvTARIACBO_2.Columns("TAABTA01").HeaderText = "1. 0 a 10 Puntos"
            Me.dgvTARIACBO_2.Columns("TAABTA02").HeaderText = "2. 11 a 28 Puntos"
            Me.dgvTARIACBO_2.Columns("TAABTA03").HeaderText = "3. 29 a 46 Puntos"
            Me.dgvTARIACBO_2.Columns("TAABTA04").HeaderText = "4. 47 a 69 Puntos"
            Me.dgvTARIACBO_2.Columns("TAABTA05").HeaderText = "5. 70 a 100 Puntos"
            Me.dgvTARIACBO_2.Columns("TAABAVIN").HeaderText = "Avaluo inicial"
            Me.dgvTARIACBO_2.Columns("TAABAVFI").HeaderText = "Avaluo final"
            Me.dgvTARIACBO_2.Columns("TAABESTA").HeaderText = "Estado"

            Me.dgvTARIACBO_1.Columns("TAABIDRE").Visible = False
            Me.dgvTARIACBO_2.Columns("TAABIDRE").Visible = False
            Me.dgvTARIACBO_2.Columns("TAABDEPA").Visible = False
            Me.dgvTARIACBO_2.Columns("TAABMUNI").Visible = False
            Me.dgvTARIACBO_2.Columns("TAABCLSE").Visible = False
            Me.dgvTARIACBO_2.Columns("TAABVIGE").Visible = False
            Me.dgvTARIACBO_2.Columns("TAABTIPO").Visible = False
            Me.dgvTARIACBO_2.Columns("TAABTARE").Visible = False
            Me.dgvTARIACBO_2.Columns("TAABTACO").Visible = False
            Me.dgvTARIACBO_2.Columns("TAABTAIN").Visible = False
            Me.dgvTARIACBO_1.Columns("TAABESTR").Visible = False
            Me.dgvTARIACBO_1.Columns("TAABTA01").Visible = False
            Me.dgvTARIACBO_1.Columns("TAABTA02").Visible = False
            Me.dgvTARIACBO_1.Columns("TAABTA03").Visible = False
            Me.dgvTARIACBO_1.Columns("TAABTA04").Visible = False
            Me.dgvTARIACBO_1.Columns("TAABTA05").Visible = False
            Me.dgvTARIACBO_1.Columns("TAABAVIN").Visible = False
            Me.dgvTARIACBO_1.Columns("TAABAVFI").Visible = False

            Me.dgvTARIACBO_1.Columns("TAABTARE").DefaultCellStyle.Format = "c"
            Me.dgvTARIACBO_1.Columns("TAABTACO").DefaultCellStyle.Format = "c"
            Me.dgvTARIACBO_1.Columns("TAABTAIN").DefaultCellStyle.Format = "c"
            Me.dgvTARIACBO_2.Columns("TAABAVIN").DefaultCellStyle.Format = "c"
            Me.dgvTARIACBO_2.Columns("TAABAVFI").DefaultCellStyle.Format = "c"

            '==================================================
            '*** ASIGNA LOS PRIVILEGIOS DE LA BARRA DE MENU ***
            '==================================================

            Dim ContarRegistros As Integer = Me.BindingSource_TARIACBO_1.Count

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

            If Me.BindingSource_TARIACBO_1.Count > 0 Then

                Me.lblTAABDEPA.Text = CType(fun_Buscar_Lista_Valores_DEPARTAMENTO(Me.dgvTARIACBO_1.CurrentRow.Cells("TAABDEPA").Value.ToString()), String)
                Me.lblTAABMUNI.Text = CType(fun_Buscar_Lista_Valores_MUNICIPIO(Me.dgvTARIACBO_1.CurrentRow.Cells("TAABDEPA").Value.ToString(), Me.dgvTARIACBO_1.CurrentRow.Cells("TAABMUNI").Value.ToString()), String)
                Me.lblTAABCLSE.Text = CType(fun_Buscar_Lista_Valores_CLASSECT(Me.dgvTARIACBO_1.CurrentRow.Cells("TAABCLSE").Value.ToString()), String)
                Me.lblTAABVIGE.Text = CType(fun_Buscar_Lista_Valores_VIGENCIA(Me.dgvTARIACBO_1.CurrentRow.Cells("TAABVIGE").Value.ToString()), String)
                Me.lblTAABTIPO.Text = CType(fun_Buscar_Lista_Valores_TIPOCALI(Me.dgvTARIACBO_1.CurrentRow.Cells("TAABTIPO").Value.ToString()), String)
                Me.lblTAABESTR.Text = CType(fun_Buscar_Lista_Valores_ESTRATO(Me.dgvTARIACBO_1.CurrentRow.Cells("TAABESTR").Value.ToString()), String)

            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub pro_LimpiarCampos()

        Me.lblTAABMUNI.Text = ""
        Me.lblTAABDEPA.Text = ""
        Me.lblTAABCLSE.Text = ""
        Me.lblTAABVIGE.Text = ""
        Me.lblTAABTIPO.Text = ""
        Me.lblTAABESTR.Text = ""

    End Sub

#End Region

#Region "MENU"

    Private Sub cmdAGREGAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAGREGAR.Click

        Try
            frm_insertar_TARIACBO.ShowDialog()
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
                Dim objdatos As New cla_TARIACBO

                If objdatos.fun_Eliminar_TARIACBO(Integer.Parse(Me.dgvTARIACBO_1.SelectedRows.Item(0).Cells(0).Value.ToString())) Then
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
            Dim frm_modificar As New frm_modificar_TARIACBO(Integer.Parse(Me.dgvTARIACBO_1.SelectedRows.Item(0).Cells(0).Value.ToString()))

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

            frm_consultar_TARIACBO.ShowDialog()

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
    Private Sub dgvALUMPUBL_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvTARIACBO_1.GotFocus, dgvTARIACBO_2.GotFocus
        Me.strBARRESTA.Items(0).Text = dgvTARIACBO_1.AccessibleDescription
    End Sub

#End Region

#Region "KeyDown"

    Private Sub dgvALUMPUBL_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgvTARIACBO_1.KeyDown, dgvTARIACBO_2.KeyDown
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
                Dim ContarRegistros As Integer = BindingSource_TARIACBO_1.Count

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
                Dim ContarRegistros As Integer = BindingSource_TARIACBO_1.Count

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

    Private Sub dgvALUMPUBL_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgvTARIACBO_1.KeyUp, dgvTARIACBO_2.KeyUp
        If e.KeyCode = Keys.Down Or e.KeyCode = Keys.Up Or e.KeyCode = Keys.Enter Or e.KeyCode = Keys.PageUp Or e.KeyCode = Keys.PageDown Then
            pro_ListaDeValores()
        End If
    End Sub

#End Region

#Region "CellClick"

    Private Sub dgvALUMPUBL_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvTARIACBO_1.CellClick, dgvTARIACBO_2.CellClick
        pro_ListaDeValores()
    End Sub

#End Region

#End Region


End Class