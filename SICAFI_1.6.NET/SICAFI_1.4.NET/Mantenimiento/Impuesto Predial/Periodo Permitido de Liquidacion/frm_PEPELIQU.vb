Imports REGLAS_DEL_NEGOCIO

Public Class frm_PEPELIQU

    '========================================
    '*** PERIODO PERMITIDO DE LIQUIDACI�N ***
    '========================================

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

    Public Shared Function instance() As frm_PEPELIQU
        If frm_Instance Is Nothing OrElse frm_Instance.isdisposed = True Then
            frm_Instance = New frm_PEPELIQU
        End If

        frm_Instance.bringtofront()

        Return frm_Instance

    End Function

    Private Sub New()
        ' Llamada necesaria para el Dise�ador de Windows Forms.
        InitializeComponent()
        ' Agregue cualquier inicializaci�n despu�s de la llamada a InitializeComponent().
    End Sub

#End Region

#Region "PROCEDIMIENTOS"

    Private Sub pro_Reconsultar()
        Try

            Dim objdatos As New cla_PEPELIQU

            If boCONSULTA = False Then
                Me.BindingSource_PEPELIQU_1.DataSource = objdatos.fun_Consultar_PEPELIQU
            Else
                Me.BindingSource_PEPELIQU_1.DataSource = objdatos.fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_PEPELIQU(vp_inConsulta)
            End If

            Me.dgvPEPELIQU_1.DataSource = BindingSource_PEPELIQU_1
            Me.dgvPEPELIQU_2.DataSource = BindingSource_PEPELIQU_1
            Me.BindingNavigator_PEPELIQU_1.BindingSource = BindingSource_PEPELIQU_1

            '==================================================
            '*** CONFIGURA OBJETOS DEL FORMULARIO MAESTRO ***
            '==================================================

            Me.strBARRESTA.Items(2).Text = "Registros : " & Me.BindingSource_PEPELIQU_1.Count

            Me.dgvPEPELIQU_1.Columns("PPLIDEPA").HeaderText = "Departamento"
            Me.dgvPEPELIQU_1.Columns("PPLIMUNI").HeaderText = "Municipio"
            Me.dgvPEPELIQU_1.Columns("PPLICLSE").HeaderText = "Sector"
            Me.dgvPEPELIQU_1.Columns("PPLIVIGE").HeaderText = "Vigencia"
            Me.dgvPEPELIQU_1.Columns("PPLITIIM").HeaderText = "Tipo Impuesto"
            Me.dgvPEPELIQU_1.Columns("PPLICONC").HeaderText = "Concepto"

            Me.dgvPEPELIQU_2.Columns("PPLIDESC").HeaderText = "Descripci�n"
            Me.dgvPEPELIQU_2.Columns("PPLIHIAV").HeaderText = "Historico aval�o"
            Me.dgvPEPELIQU_2.Columns("PPLIHILI").HeaderText = "Historico liquidaci�n"
            Me.dgvPEPELIQU_2.Columns("PPLIAFSI").HeaderText = "Aforo impuesto"
            Me.dgvPEPELIQU_2.Columns("PPLIESTA").HeaderText = "Estado"

            Me.dgvPEPELIQU_1.Columns("PPLIIDRE").Visible = False
            Me.dgvPEPELIQU_1.Columns("PPLIDESC").Visible = False
            Me.dgvPEPELIQU_1.Columns("PPLIHIAV").Visible = False
            Me.dgvPEPELIQU_1.Columns("PPLIHILI").Visible = False
            Me.dgvPEPELIQU_1.Columns("PPLIAFSI").Visible = False
            Me.dgvPEPELIQU_1.Columns("PPLIESTA").Visible = False
            
            Me.dgvPEPELIQU_2.Columns("PPLIIDRE").Visible = False
            Me.dgvPEPELIQU_2.Columns("PPLIDEPA").Visible = False
            Me.dgvPEPELIQU_2.Columns("PPLIMUNI").Visible = False
            Me.dgvPEPELIQU_2.Columns("PPLICLSE").Visible = False
            Me.dgvPEPELIQU_2.Columns("PPLIVIGE").Visible = False
            Me.dgvPEPELIQU_2.Columns("PPLITIIM").Visible = False
            Me.dgvPEPELIQU_2.Columns("PPLICONC").Visible = False
            
            Me.dgvPEPELIQU_2.Columns("PPLIDESC").Width = 300

            '==================================================
            '*** ASIGNA LOS PRIVILEGIOS DE LA BARRA DE MENU ***
            '==================================================

            Dim ContarRegistros As Integer = Me.BindingSource_PEPELIQU_1.Count

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
            If Me.BindingSource_PEPELIQU_1.Count > 0 Then

                Me.lblPPLIDEPA.Text = CType(fun_Buscar_Lista_Valores_DEPARTAMENTO(Me.dgvPEPELIQU_1.CurrentRow.Cells("PPLIDEPA").Value.ToString()), String)
                Me.lblPPLIMUNI.Text = CType(fun_Buscar_Lista_Valores_MUNICIPIO(Me.dgvPEPELIQU_1.CurrentRow.Cells("PPLIDEPA").Value.ToString(), Me.dgvPEPELIQU_1.CurrentRow.Cells("PPLIMUNI").Value.ToString()), String)
                Me.lblPPLICLSE.Text = CType(fun_Buscar_Lista_Valores_CLASSECT(Me.dgvPEPELIQU_1.CurrentRow.Cells("PPLICLSE").Value.ToString()), String)
                Me.lblPPLIVIGE.Text = CType(fun_Buscar_Lista_Valores_VIGENCIA(Me.dgvPEPELIQU_1.CurrentRow.Cells("PPLIVIGE").Value.ToString()), String)
                Me.lblPPLITIIM.Text = CType(fun_Buscar_Lista_Valores_TIPOIMPU(Me.dgvPEPELIQU_1.CurrentRow.Cells("PPLITIIM").Value.ToString()), String)
                Me.lblPPLICONC.Text = CType(fun_Buscar_Lista_Valores_CONCEPTO(Me.dgvPEPELIQU_1.CurrentRow.Cells("PPLITIIM").Value.ToString(), Me.dgvPEPELIQU_1.CurrentRow.Cells("PPLICONC").Value.ToString()), String)

            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub pro_LimpiarCampos()

        Me.lblPPLIMUNI.Text = ""
        Me.lblPPLIDEPA.Text = ""
        Me.lblPPLICLSE.Text = ""
        Me.lblPPLIVIGE.Text = ""
        Me.lblPPLITIIM.Text = ""
        Me.lblPPLICONC.Text = ""

    End Sub

#End Region

#Region "MENU"

    Private Sub cmdAGREGAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAGREGAR.Click

        Try
            frm_insertar_PEPELIQU.ShowDialog()
            boCONSULTA = False
            pro_Reconsultar()
            pro_ListaDeValores()

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub cmdELIMINAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdELIMINAR.Click

        Try
            If MessageBox.Show("� Desea eliminar el registro seleccionado ? ", "Mensaje...", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then
                Dim objdatos As New cla_PEPELIQU

                If objdatos.fun_Eliminar_PEPELIQU(Integer.Parse(Me.dgvPEPELIQU_1.SelectedRows.Item(0).Cells(0).Value.ToString())) Then
                    boCONSULTA = False
                    pro_Reconsultar()
                    pro_LimpiarCampos()
                    pro_ListaDeValores()
                Else
                    frm_INCO_eliminar_registro_padre_con_relaci�n_de_registros_hijos.ShowDialog()
                End If

            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub cmdMODIFICAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdMODIFICAR.Click

        Try
            Dim frm_modificar As New frm_modificar_PEPELIQU(Integer.Parse(Me.dgvPEPELIQU_1.SelectedRows.Item(0).Cells(0).Value.ToString()))

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

            frm_consultar_PEPELIQU.ShowDialog()

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
    Private Sub dgvALUMPUBL_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvPEPELIQU_1.GotFocus, dgvPEPELIQU_2.GotFocus
        Me.strBARRESTA.Items(0).Text = dgvPEPELIQU_1.AccessibleDescription
    End Sub

#End Region

#Region "KeyDown"

    Private Sub dgvALUMPUBL_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgvPEPELIQU_1.KeyDown, dgvPEPELIQU_2.KeyDown
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
                Dim ContarRegistros As Integer = BindingSource_PEPELIQU_1.Count

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
                Dim ContarRegistros As Integer = BindingSource_PEPELIQU_1.Count

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

    Private Sub dgvALUMPUBL_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgvPEPELIQU_1.KeyUp, dgvPEPELIQU_2.KeyUp
        If e.KeyCode = Keys.Down Or e.KeyCode = Keys.Up Or e.KeyCode = Keys.Enter Or e.KeyCode = Keys.PageUp Or e.KeyCode = Keys.PageDown Then
            pro_ListaDeValores()
        End If
    End Sub

#End Region

#Region "CellClick"

    Private Sub dgvALUMPUBL_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvPEPELIQU_1.CellClick, dgvPEPELIQU_2.CellClick
        pro_ListaDeValores()
    End Sub

#End Region

#End Region


End Class