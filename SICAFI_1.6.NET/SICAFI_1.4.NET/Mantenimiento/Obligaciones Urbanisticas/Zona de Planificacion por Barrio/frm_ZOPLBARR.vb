Imports REGLAS_DEL_NEGOCIO

Public Class frm_ZOPLBARR

    '======================================================
    '*** MANTENIMIENTO ZONA DE PLANIFICACION POR BARRIO ***
    '======================================================

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

    Public Shared Function instance() As frm_ZOPLBARR
        If frm_Instance Is Nothing OrElse frm_Instance.isdisposed = True Then
            frm_Instance = New frm_ZOPLBARR
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

            Dim objdatos As New cla_ZOPLBARR

            If boCONSULTA = False Then
                Me.BindingSource_ZOPLBARR_1.DataSource = objdatos.fun_Consultar_ZOPLBARR
            Else
                Me.BindingSource_ZOPLBARR_1.DataSource = objdatos.fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_ZOPLBARR(vp_inConsulta)
            End If

            Me.dgvZOPLBARR.DataSource = BindingSource_ZOPLBARR_1
            Me.BindingNavigator_ZOPLBARR_1.BindingSource = BindingSource_ZOPLBARR_1

            '==================================================
            '*** CONFIGURA OBJETOS DEL FORMULARIO MAESTRO ***
            '==================================================

            Me.strBARRESTA.Items(2).Text = "Registros : " & BindingSource_ZOPLBARR_1.Count

            Me.dgvZOPLBARR.Columns("ZPBADEPA").HeaderText = "Departamento"
            Me.dgvZOPLBARR.Columns("ZPBAMUNI").HeaderText = "Municipio"
            Me.dgvZOPLBARR.Columns("ZPBACLSE").HeaderText = "Clase o Sector"
            Me.dgvZOPLBARR.Columns("ZPBACORR").HeaderText = "Corregimiento"
            Me.dgvZOPLBARR.Columns("ZPBABARR").HeaderText = "Barrio o Vereda"
            Me.dgvZOPLBARR.Columns("ZPBAZOPL").HeaderText = "Zona de Planificación"
            Me.dgvZOPLBARR.Columns("ZPBAESTA").HeaderText = "Estado"

            Me.dgvZOPLBARR.Columns("ZPBAIDRE").Visible = False

            '==================================================
            '*** ASIGNA LOS PRIVILEGIOS DE LA BARRA DE MENU ***
            '==================================================

            Dim ContarRegistros As Integer = BindingSource_ZOPLBARR_1.Count

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
            If BindingSource_ZOPLBARR_1.Count > 0 Then

                Me.lblZPBADEPA.Text = CType(fun_Buscar_Lista_Valores_DEPARTAMENTO(Me.dgvZOPLBARR.CurrentRow.Cells("ZPBADEPA").Value.ToString()), String)
                Me.lblZPBAMUNI.Text = CType(fun_Buscar_Lista_Valores_MUNICIPIO(Me.dgvZOPLBARR.CurrentRow.Cells("ZPBADEPA").Value.ToString(), Me.dgvZOPLBARR.CurrentRow.Cells("ZPBAMUNI").Value.ToString()), String)
                Me.lblZPBACLSE.Text = CType(fun_Buscar_Lista_Valores_CLASSECT(Me.dgvZOPLBARR.CurrentRow.Cells("ZPBACLSE").Value.ToString()), String)
                Me.lblZPBACORR.Text = CType(fun_Buscar_Lista_Valores_CORREGIMIENTO(Me.dgvZOPLBARR.CurrentRow.Cells("ZPBADEPA").Value.ToString(), Me.dgvZOPLBARR.CurrentRow.Cells("ZPBAMUNI").Value.ToString(), Me.dgvZOPLBARR.CurrentRow.Cells("ZPBACLSE").Value.ToString(), Me.dgvZOPLBARR.CurrentRow.Cells("ZPBACORR").Value.ToString()), String)
                Me.lblZPBABARR.Text = CType(fun_Buscar_Lista_Valores_BARRVERE(Me.dgvZOPLBARR.CurrentRow.Cells("ZPBADEPA").Value.ToString(), Me.dgvZOPLBARR.CurrentRow.Cells("ZPBAMUNI").Value.ToString(), Me.dgvZOPLBARR.CurrentRow.Cells("ZPBACLSE").Value.ToString(), Me.dgvZOPLBARR.CurrentRow.Cells("ZPBABARR").Value.ToString()), String)
                Me.lblZPBAZOPL.Text = CType(fun_Buscar_Lista_Valores_ZONAPLAN(Me.dgvZOPLBARR.CurrentRow.Cells("ZPBAZOPL").Value.ToString()), String)

            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description & "Lista de valores")
        End Try

    End Sub
    Private Sub pro_LimpiarCampos()

        Me.lblZPBAMUNI.Text = ""
        Me.lblZPBADEPA.Text = ""
        Me.lblZPBACLSE.Text = ""
        Me.lblZPBACORR.Text = ""
        Me.lblZPBABARR.Text = ""
        Me.lblZPBAZOPL.Text = ""

    End Sub

#End Region

#Region "MENU"

    Private Sub cmdAGREGAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAGREGAR.Click

        Try
            frm_insertar_ZOPLBARR.ShowDialog()
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

                Dim objdatos As New cla_ZOPLBARR

                If objdatos.fun_Eliminar_MANT_ZOPLBARR(Integer.Parse(Me.dgvZOPLBARR.SelectedRows.Item(0).Cells(0).Value.ToString())) Then
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
            'Dim frm_modificar As New frm_modificar_ZOPLBARR(Integer.Parse(Me.dgvZOPLBARR.SelectedRows.Item(0).Cells(0).Value.ToString()))

            'frm_modificar.ShowDialog()
            pro_Reconsultar()
            pro_ListaDeValores()

        Catch ex As Exception
            frm_INCO_modifircar_registros_sin_listas_de_valores.ShowDialog()
        End Try

    End Sub
    Private Sub cmdCONSULTAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCONSULTAR.Click

        Try
            'vp_inConsulta = 0

            'frm_consultar_ZOPLBARR.ShowDialog()

            'If vp_inConsulta > 0 Then
            '    boCONSULTA = True
            'Else
            '    boCONSULTA = False
            'End If

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

    Private Sub frm_VIGEACTU_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        pro_Reconsultar()
    End Sub

#End Region

#Region "GotFocus"

    Private Sub frm_VIGEACTU_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.GotFocus
        pro_ListaDeValores()
    End Sub
    Private Sub dgvZOECZOEC_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvZOPLBARR.GotFocus
        Me.strBARRESTA.Items(0).Text = Me.dgvZOPLBARR.AccessibleDescription
    End Sub

#End Region

#Region "KeyDown"

    Private Sub dgvZOECZOEC_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgvZOPLBARR.KeyDown
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
                Dim ContarRegistros As Integer = Me.BindingSource_ZOPLBARR_1.Count

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
            If Me.cmdELIMINAR.Enabled = True Then
                Me.cmdELIMINAR.PerformClick()
            Else
                Dim ContarRegistros As Integer = Me.BindingSource_ZOPLBARR_1.Count

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

#Region "KeyUp"

    Private Sub dgvZOECZOEC_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgvZOPLBARR.KeyUp
        If e.KeyCode = Keys.Down Or e.KeyCode = Keys.Up Or e.KeyCode = Keys.Enter Or e.KeyCode = Keys.PageUp Or e.KeyCode = Keys.PageDown Then
            pro_ListaDeValores()
        End If
    End Sub

#End Region

#Region "CellClick"

    Private Sub dgvZOECZOEC_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvZOPLBARR.CellClick
        pro_ListaDeValores()
    End Sub

#End Region

#End Region

End Class