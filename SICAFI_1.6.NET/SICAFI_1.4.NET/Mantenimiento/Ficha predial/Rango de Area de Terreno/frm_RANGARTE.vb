Imports REGLAS_DEL_NEGOCIO

Public Class frm_RANGARTE

    '================================
    '*** RANGO DE AREA DE TERRENO ***
    '================================

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

    Public Shared Function instance() As frm_RANGARTE
        If frm_Instance Is Nothing OrElse frm_Instance.isdisposed = True Then
            frm_Instance = New frm_RANGARTE
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
            Dim objdatos As New cla_RANGARTE

            If boCONSULTA = False Then
                Me.BindingSource_RANGARTE_1.DataSource = objdatos.fun_Consultar_RANGARTE
            Else
                Me.BindingSource_RANGARTE_1.DataSource = objdatos.fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_RANGARTE(vp_inConsulta)
            End If

            Me.dgvRANGARTE.DataSource = Me.BindingSource_RANGARTE_1
            Me.BindingNavigator_RANGARTE_1.BindingSource = Me.BindingSource_RANGARTE_1

            '================================================
            '*** CONFIGURA OBJETOS DEL FORMULARIO MAESTRO ***
            '================================================

            Me.strBARRESTA.Items(2).Text = "Registros : " & Me.BindingSource_RANGARTE_1.Count

            Me.dgvRANGARTE.Columns("DEPADESC").HeaderText = "Departamento"
            Me.dgvRANGARTE.Columns("MUNIDESC").HeaderText = "Municipio"
            Me.dgvRANGARTE.Columns("CLSEDESC").HeaderText = "Sector"
            Me.dgvRANGARTE.Columns("RAATATIN").HeaderText = "Area inicial mts2"
            Me.dgvRANGARTE.Columns("RAATATFI").HeaderText = "Area final mts2"
            Me.dgvRANGARTE.Columns("RAATPORC").HeaderText = "Porc(%)"
            Me.dgvRANGARTE.Columns("ESTADESC").HeaderText = "Estado"

            Me.dgvRANGARTE.Columns("RAATATIN").DefaultCellStyle.Format = "n"
            Me.dgvRANGARTE.Columns("RAATATFI").DefaultCellStyle.Format = "n"

            Me.dgvRANGARTE.Columns("RAATATIN").DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopRight
            Me.dgvRANGARTE.Columns("RAATATFI").DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopRight

            Me.dgvRANGARTE.Columns("RAATIDRE").Visible = False
            Me.dgvRANGARTE.Columns("RAATDEPA").Visible = False
            Me.dgvRANGARTE.Columns("RAATMUNI").Visible = False
            Me.dgvRANGARTE.Columns("RAATCLSE").Visible = False
            Me.dgvRANGARTE.Columns("RAATESTA").Visible = False

            '==================================================
            '*** ASIGNA LOS PRIVILEGIOS DE LA BARRA DE MENU ***
            '==================================================

            Dim ContarRegistros As Integer = BindingSource_RANGARTE_1.Count

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
            If Me.BindingSource_RANGARTE_1.Count > 0 Then

                Me.lblRAATDEPA.Text = CType(fun_Buscar_Lista_Valores_Formulario_Principal_DEPARTAMENTO_Codigo(Me.dgvRANGARTE.CurrentRow.Cells("RAATDEPA").Value.ToString()), String)
                Me.lblRAATMUNI.Text = CType(fun_Buscar_Lista_Valores_Formulario_Principal_MUNICIPIO_Codigo(Me.dgvRANGARTE.CurrentRow.Cells("RAATDEPA").Value.ToString(), Me.dgvRANGARTE.CurrentRow.Cells("RAATMUNI").Value.ToString()), String)
                Me.lblRAATCLSE.Text = CType(fun_Buscar_Lista_Valores_Formulario_Principal_CLASSECT_Codigo(Me.dgvRANGARTE.CurrentRow.Cells("RAATCLSE").Value.ToString()), String)

            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try


    End Sub
    Private Sub pro_LimpiarCampos()

        Me.lblRAATMUNI.Text = ""
        Me.lblRAATDEPA.Text = ""
        Me.lblRAATCLSE.Text = ""

    End Sub

#End Region

#Region "MENU"

    Private Sub cmdAGREGAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAGREGAR.Click

        Try
            frm_insertar_RANGARTE.ShowDialog()
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
                Dim objdatos As New cla_RANGARTE

                If objdatos.fun_Eliminar_RANGARTE(Integer.Parse(Me.dgvRANGARTE.SelectedRows.Item(0).Cells(0).Value.ToString())) Then
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
            Dim frm_modificar As New frm_modificar_RANGARTE(Integer.Parse(dgvRANGARTE.CurrentRow.Cells(0).Value.ToString()))

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

            frm_consultar_RANGARTE.ShowDialog()

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

    Private Sub frm_ZONAECON_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        pro_Reconsultar()
    End Sub

#End Region

#Region "GotFocus"

    Private Sub frm_RANGARTE_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.GotFocus
        pro_ListaDeValores()
    End Sub
    Private Sub dgvRANGARTE_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvRANGARTE.GotFocus
        Me.strBARRESTA.Items(0).Text = Me.dgvRANGARTE.AccessibleDescription
    End Sub

#End Region

#Region "KeyDown"

    Private Sub dgvRANGARTE_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgvRANGARTE.KeyDown
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
                Dim ContarRegistros As Integer = BindingSource_RANGARTE_1.Count

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
                Dim ContarRegistros As Integer = BindingSource_RANGARTE_1.Count

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

    Private Sub dgvRANGARTE_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgvRANGARTE.KeyUp
        If e.KeyCode = Keys.Down Or e.KeyCode = Keys.Up Or e.KeyCode = Keys.Enter Or e.KeyCode = Keys.PageUp Or e.KeyCode = Keys.PageDown Then
            pro_ListaDeValores()
        End If
    End Sub

#End Region

#Region "CellClick"

    Private Sub dgvRANGARTE_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvRANGARTE.CellClick
        pro_ListaDeValores()
    End Sub

#End Region

#End Region

End Class