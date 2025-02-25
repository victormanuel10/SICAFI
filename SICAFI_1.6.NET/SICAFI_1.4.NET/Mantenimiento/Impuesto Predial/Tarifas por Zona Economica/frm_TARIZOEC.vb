Imports REGLAS_DEL_NEGOCIO

Public Class frm_TARIZOEC

    '====================================
    '*** TARIFAS POR ZONAS ECONÓMICAS ***
    '====================================

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

    Public Shared Function instance() As frm_TARIZOEC
        If frm_Instance Is Nothing OrElse frm_Instance.isdisposed = True Then
            frm_Instance = New frm_TARIZOEC
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

            Dim objdatos As New cla_TARIZOEC

            If boCONSULTA = False Then
                Me.BindingSource_TARIZOEC_1.DataSource = objdatos.fun_Consultar_TARIZOEC
            Else
                Me.BindingSource_TARIZOEC_1.DataSource = objdatos.fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_TARIZOEC(vp_inConsulta)
            End If

            Me.dgvTARIZOEC.DataSource = BindingSource_TARIZOEC_1
            Me.BindingNavigator_TARIZOEC_1.BindingSource = BindingSource_TARIZOEC_1

            '==================================================
            '*** CONFIGURA OBJETOS DEL FORMULARIO MAESTRO ***
            '==================================================

            Me.strBARRESTA.Items(2).Text = "Registros : " & Me.BindingSource_TARIZOEC_1.Count

            Me.dgvTARIZOEC.Columns("TAZEDEPA").HeaderText = "Departamento"
            Me.dgvTARIZOEC.Columns("TAZEMUNI").HeaderText = "Municipio"
            Me.dgvTARIZOEC.Columns("TAZECLSE").HeaderText = "Sector"
            Me.dgvTARIZOEC.Columns("TAZEVIGE").HeaderText = "Vigencia"
            Me.dgvTARIZOEC.Columns("TAZEZOEC").HeaderText = "Zona económica"
            Me.dgvTARIZOEC.Columns("TAZETA01").HeaderText = "Bajo-Bajo 0 a 10"
            Me.dgvTARIZOEC.Columns("TAZETA02").HeaderText = "Bajo 11 a 28"
            Me.dgvTARIZOEC.Columns("TAZETA03").HeaderText = "Medio-Bajo 29 a 46"
            Me.dgvTARIZOEC.Columns("TAZETA04").HeaderText = "Medio 47 a 64"
            Me.dgvTARIZOEC.Columns("TAZETA05").HeaderText = "Medio-Alto 65 a 84"
            Me.dgvTARIZOEC.Columns("TAZETA06").HeaderText = "Alto 85 a 100"
            Me.dgvTARIZOEC.Columns("TAZEZOAP").HeaderText = "Zona aplicada"
            Me.dgvTARIZOEC.Columns("TAZEESTA").HeaderText = "Estado"
            Me.dgvTARIZOEC.Columns("TAZESIGN").HeaderText = "Signo"
            Me.dgvTARIZOEC.Columns("TAZEPORC").HeaderText = "Por(%)"
            Me.dgvTARIZOEC.Columns("TAZETALO").HeaderText = "Tarifa lote"

            Me.dgvTARIZOEC.Columns("TAZEIDRE").Visible = False

            '==================================================
            '*** ASIGNA LOS PRIVILEGIOS DE LA BARRA DE MENU ***
            '==================================================

            Dim ContarRegistros As Integer = Me.BindingSource_TARIZOEC_1.Count

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
            If Me.BindingSource_TARIZOEC_1.Count > 0 Then

                Me.lblTAZEDEPA.Text = CType(fun_Buscar_Lista_Valores_DEPARTAMENTO(Me.dgvTARIZOEC.CurrentRow.Cells("TAZEDEPA").Value.ToString()), String)
                Me.lblTAZEMUNI.Text = CType(fun_Buscar_Lista_Valores_MUNICIPIO(Me.dgvTARIZOEC.CurrentRow.Cells("TAZEDEPA").Value.ToString(), Me.dgvTARIZOEC.CurrentRow.Cells("TAZEMUNI").Value.ToString()), String)
                Me.lblTAZECLSE.Text = CType(fun_Buscar_Lista_Valores_CLASSECT(Me.dgvTARIZOEC.CurrentRow.Cells("TAZECLSE").Value.ToString()), String)
                Me.lblTAZEZOEC.Text = CType(fun_Buscar_Lista_Valores_ZONAECON(Me.dgvTARIZOEC.CurrentRow.Cells("TAZEDEPA").Value.ToString(), Me.dgvTARIZOEC.CurrentRow.Cells("TAZEMUNI").Value.ToString(), Me.dgvTARIZOEC.CurrentRow.Cells("TAZECLSE").Value.ToString(), Me.dgvTARIZOEC.CurrentRow.Cells("TAZEZOEC").Value.ToString()), String)
                Me.lblTAZEZOAP.Text = CType(fun_Buscar_Lista_Valores_ZONAECON(Me.dgvTARIZOEC.CurrentRow.Cells("TAZEDEPA").Value.ToString(), Me.dgvTARIZOEC.CurrentRow.Cells("TAZEMUNI").Value.ToString(), Me.dgvTARIZOEC.CurrentRow.Cells("TAZECLSE").Value.ToString(), Me.dgvTARIZOEC.CurrentRow.Cells("TAZEZOAP").Value.ToString()), String)
                Me.lblTAZEVIGE.Text = CType(fun_Buscar_Lista_Valores_VIGENCIA(Me.dgvTARIZOEC.CurrentRow.Cells.Item("TAZEVIGE").Value.ToString()), String)

            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub pro_LimpiarCampos()

        Me.lblTAZEMUNI.Text = ""
        Me.lblTAZEDEPA.Text = ""
        Me.lblTAZECLSE.Text = ""
        Me.lblTAZEVIGE.Text = ""
        Me.lblTAZEZOEC.Text = ""
        Me.lblTAZEZOAP.Text = ""

    End Sub

#End Region

#Region "MENU"

    Private Sub cmdAGREGAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAGREGAR.Click

        Try
            frm_insertar_TARIZOEC.ShowDialog()
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
                Dim objdatos As New cla_TARIZOEC

                If objdatos.fun_Eliminar_TARIZOEC(Integer.Parse(Me.dgvTARIZOEC.SelectedRows.Item(0).Cells(0).Value.ToString())) Then
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
            Dim frm_modificar As New frm_modificar_TARIZOEC(Integer.Parse(Me.dgvTARIZOEC.SelectedRows.Item(0).Cells(0).Value.ToString()))

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

            frm_consultar_TARIZOEC.ShowDialog()

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

    Private Sub frm_TARIZOEC_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.GotFocus
        pro_ListaDeValores()
    End Sub
    Private Sub dgvTARIZOEC_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvTARIZOEC.GotFocus
        strBARRESTA.Items(0).Text = dgvTARIZOEC.AccessibleDescription
    End Sub

#End Region

#Region "KeyDown"

    Private Sub dgvTARIZOEC_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgvTARIZOEC.KeyDown
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
                Dim ContarRegistros As Integer = BindingSource_TARIZOEC_1.Count

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
                Dim ContarRegistros As Integer = BindingSource_TARIZOEC_1.Count

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

    Private Sub dgvTARIZOEC_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgvTARIZOEC.KeyUp
        If e.KeyCode = Keys.Down Or e.KeyCode = Keys.Up Or e.KeyCode = Keys.Enter Or e.KeyCode = Keys.PageUp Or e.KeyCode = Keys.PageDown Then
            pro_ListaDeValores()
        End If
    End Sub

#End Region

#Region "CellClick"

    Private Sub dgvTARIZOEC_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvTARIZOEC.CellClick
        pro_ListaDeValores()
    End Sub

#End Region

#End Region

End Class