Imports REGLAS_DEL_NEGOCIO

Public Class frm_FORMMUNI

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

    Public Shared Function instance() As frm_FORMMUNI
        If frm_Instance Is Nothing OrElse frm_Instance.isdisposed = True Then
            frm_Instance = New frm_FORMMUNI
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

            Dim objdatos As New cla_FORMMUNI

            If boCONSULTA = False Then
                Me.BindingSource_FORMMUNI_1.DataSource = objdatos.fun_Consultar_FORMMUNI
            Else
                Me.BindingSource_FORMMUNI_1.DataSource = objdatos.fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_FORMMUNI(vp_inConsulta)
            End If

            Me.dgvFORMMUNI_1.DataSource = BindingSource_FORMMUNI_1
            Me.dgvFORMMUNI_2.DataSource = BindingSource_FORMMUNI_1
            Me.BindingNavigator_FORMMUNI_1.BindingSource = BindingSource_FORMMUNI_1

            '==================================================
            '*** CONFIGURA OBJETOS DEL FORMULARIO MAESTRO ***
            '==================================================

            Me.strBARRESTA.Items(2).Text = "Registros : " & Me.BindingSource_FORMMUNI_1.Count

            Me.dgvFORMMUNI_1.Columns("FOMUDEPA").HeaderText = "Departamento"
            Me.dgvFORMMUNI_1.Columns("FOMUMUNI").HeaderText = "Municipio"
            Me.dgvFORMMUNI_1.Columns("FOMUCLSE").HeaderText = "Sector"
            Me.dgvFORMMUNI_1.Columns("FOMUVIGE").HeaderText = "Vigencia"
            Me.dgvFORMMUNI_1.Columns("FOMUTIIM").HeaderText = "Tipo Impuesto"
            Me.dgvFORMMUNI_1.Columns("FOMUCONC").HeaderText = "Concepto"

            Me.dgvFORMMUNI_2.Columns("FOMUFORM").HeaderText = "Formula"
            Me.dgvFORMMUNI_2.Columns("FOMUDESC").HeaderText = "Descripción"
            Me.dgvFORMMUNI_2.Columns("FOMUIMPR").HeaderText = "Predial"
            Me.dgvFORMMUNI_2.Columns("FOMUACBO").HeaderText = "Acti. bomberil"
            Me.dgvFORMMUNI_2.Columns("FOMUALPU").HeaderText = "Alum. publico"
            Me.dgvFORMMUNI_2.Columns("FOMUTAAS").HeaderText = "Tasa de aseo"
            Me.dgvFORMMUNI_2.Columns("FOMUESTA").HeaderText = "Estado"

            Me.dgvFORMMUNI_1.Columns("FOMUIDRE").Visible = False
            Me.dgvFORMMUNI_1.Columns("FOMUDESC").Visible = False
            Me.dgvFORMMUNI_1.Columns("FOMUFORM").Visible = False
            Me.dgvFORMMUNI_1.Columns("FOMUIMPR").Visible = False
            Me.dgvFORMMUNI_1.Columns("FOMUACBO").Visible = False
            Me.dgvFORMMUNI_1.Columns("FOMUALPU").Visible = False
            Me.dgvFORMMUNI_1.Columns("FOMUTAAS").Visible = False
            Me.dgvFORMMUNI_1.Columns("FOMUESTA").Visible = False
            Me.dgvFORMMUNI_1.Columns("FOMUCO01").Visible = False
            Me.dgvFORMMUNI_1.Columns("FOMUCO02").Visible = False
            Me.dgvFORMMUNI_1.Columns("FOMUCO03").Visible = False
            Me.dgvFORMMUNI_1.Columns("FOMUCO04").Visible = False
            Me.dgvFORMMUNI_1.Columns("FOMUCO05").Visible = False

            Me.dgvFORMMUNI_2.Columns("FOMUIDRE").Visible = False
            Me.dgvFORMMUNI_2.Columns("FOMUDEPA").Visible = False
            Me.dgvFORMMUNI_2.Columns("FOMUMUNI").Visible = False
            Me.dgvFORMMUNI_2.Columns("FOMUCLSE").Visible = False
            Me.dgvFORMMUNI_2.Columns("FOMUVIGE").Visible = False
            Me.dgvFORMMUNI_2.Columns("FOMUTIIM").Visible = False
            Me.dgvFORMMUNI_2.Columns("FOMUCONC").Visible = False
            Me.dgvFORMMUNI_1.Columns("FOMUFORM").Visible = False
            Me.dgvFORMMUNI_2.Columns("FOMUCO01").Visible = False
            Me.dgvFORMMUNI_2.Columns("FOMUCO02").Visible = False
            Me.dgvFORMMUNI_2.Columns("FOMUCO03").Visible = False
            Me.dgvFORMMUNI_2.Columns("FOMUCO04").Visible = False
            Me.dgvFORMMUNI_2.Columns("FOMUCO05").Visible = False

            Me.dgvFORMMUNI_2.Columns("FOMUDESC").Width = 300

            '==================================================
            '*** ASIGNA LOS PRIVILEGIOS DE LA BARRA DE MENU ***
            '==================================================

            Dim ContarRegistros As Integer = Me.BindingSource_FORMMUNI_1.Count

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
            If Me.BindingSource_FORMMUNI_1.Count > 0 Then

                Me.lblFOMUDEPA.Text = CType(fun_Buscar_Lista_Valores_DEPARTAMENTO(Me.dgvFORMMUNI_1.CurrentRow.Cells("FOMUDEPA").Value.ToString()), String)
                Me.lblFOMUMUNI.Text = CType(fun_Buscar_Lista_Valores_MUNICIPIO(Me.dgvFORMMUNI_1.CurrentRow.Cells("FOMUDEPA").Value.ToString(), Me.dgvFORMMUNI_1.CurrentRow.Cells("FOMUMUNI").Value.ToString()), String)
                Me.lblFOMUCLSE.Text = CType(fun_Buscar_Lista_Valores_CLASSECT(Me.dgvFORMMUNI_1.CurrentRow.Cells("FOMUCLSE").Value.ToString()), String)
                Me.lblFOMUVIGE.Text = CType(fun_Buscar_Lista_Valores_VIGENCIA(Me.dgvFORMMUNI_1.CurrentRow.Cells("FOMUVIGE").Value.ToString()), String)
                Me.lblFOMUTIIM.Text = CType(fun_Buscar_Lista_Valores_TIPOIMPU(Me.dgvFORMMUNI_1.CurrentRow.Cells("FOMUTIIM").Value.ToString()), String)
                Me.lblFOMUCONC.Text = CType(fun_Buscar_Lista_Valores_CONCEPTO(Me.dgvFORMMUNI_1.CurrentRow.Cells("FOMUTIIM").Value.ToString(), Me.dgvFORMMUNI_1.CurrentRow.Cells("FOMUCONC").Value.ToString()), String)
                Me.lblFOMUFORM.Text = CType(fun_Buscar_Lista_Valores_FORMULA(Me.dgvFORMMUNI_1.CurrentRow.Cells("FOMUFORM").Value.ToString()), String)

            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub pro_LimpiarCampos()

        Me.lblFOMUMUNI.Text = ""
        Me.lblFOMUDEPA.Text = ""
        Me.lblFOMUCLSE.Text = ""
        Me.lblFOMUVIGE.Text = ""
        Me.lblFOMUTIIM.Text = ""
        Me.lblFOMUCONC.Text = ""
        Me.lblFOMUFORM.Text = ""

    End Sub

#End Region

#Region "MENU"

    Private Sub cmdAGREGAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAGREGAR.Click

        Try
            frm_insertar_FORMMUNI.ShowDialog()
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
                Dim objdatos As New cla_FORMMUNI

                If objdatos.fun_Eliminar_FORMMUNI(Integer.Parse(Me.dgvFORMMUNI_1.SelectedRows.Item(0).Cells(0).Value.ToString())) Then
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
            Dim frm_modificar As New frm_modificar_FORMMUNI(Integer.Parse(Me.dgvFORMMUNI_1.SelectedRows.Item(0).Cells(0).Value.ToString()))

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

            frm_consultar_FORMMUNI.ShowDialog()

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
    Private Sub dgvALUMPUBL_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvFORMMUNI_1.GotFocus, dgvFORMMUNI_2.GotFocus
        Me.strBARRESTA.Items(0).Text = dgvFORMMUNI_1.AccessibleDescription
    End Sub

#End Region

#Region "KeyDown"

    Private Sub dgvALUMPUBL_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgvFORMMUNI_1.KeyDown, dgvFORMMUNI_2.KeyDown
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
                Dim ContarRegistros As Integer = BindingSource_FORMMUNI_1.Count

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
                Dim ContarRegistros As Integer = BindingSource_FORMMUNI_1.Count

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

    Private Sub dgvALUMPUBL_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgvFORMMUNI_1.KeyUp, dgvFORMMUNI_2.KeyUp
        If e.KeyCode = Keys.Down Or e.KeyCode = Keys.Up Or e.KeyCode = Keys.Enter Or e.KeyCode = Keys.PageUp Or e.KeyCode = Keys.PageDown Then
            pro_ListaDeValores()
        End If
    End Sub

#End Region

#Region "CellClick"

    Private Sub dgvALUMPUBL_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvFORMMUNI_1.CellClick, dgvFORMMUNI_2.CellClick
        pro_ListaDeValores()
    End Sub

#End Region

#End Region

  
End Class