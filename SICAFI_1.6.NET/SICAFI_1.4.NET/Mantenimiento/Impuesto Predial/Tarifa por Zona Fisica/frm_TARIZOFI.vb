Imports REGLAS_DEL_NEGOCIO

Public Class frm_TARIZOFI

    '=================================
    '*** TARIFAS POR ZONAS FÍSICAS ***
    '=================================

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

    Public Shared Function instance() As frm_TARIZOFI
        If frm_Instance Is Nothing OrElse frm_Instance.isdisposed = True Then
            frm_Instance = New frm_TARIZOFI
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

            Dim objdatos As New cla_TARIZOFI

            If boCONSULTA = False Then
                Me.BindingSource_TARIZOFI_1.DataSource = objdatos.fun_Consultar_TARIZOFI
            Else
                Me.BindingSource_TARIZOFI_1.DataSource = objdatos.fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_TARIZOFI(vp_inConsulta)
            End If

            Me.dgvTARIZOFI.DataSource = BindingSource_TARIZOFI_1
            Me.BindingNavigator_TARIZOFI_1.BindingSource = BindingSource_TARIZOFI_1

            '==================================================
            '*** CONFIGURA OBJETOS DEL FORMULARIO MAESTRO ***
            '==================================================

            Me.strBARRESTA.Items(2).Text = "Registros : " & Me.BindingSource_TARIZOFI_1.Count

            Me.dgvTARIZOFI.Columns("TAZFDEPA").HeaderText = "Departamento"
            Me.dgvTARIZOFI.Columns("TAZFMUNI").HeaderText = "Municipio"
            Me.dgvTARIZOFI.Columns("TAZFCLSE").HeaderText = "Sector"
            Me.dgvTARIZOFI.Columns("TAZFVIGE").HeaderText = "Vigencia"
            Me.dgvTARIZOFI.Columns("TAZFZOFI").HeaderText = "Zona física"
            Me.dgvTARIZOFI.Columns("TAZFTA01").HeaderText = "Bajo-Bajo 0 a 10"
            Me.dgvTARIZOFI.Columns("TAZFTA02").HeaderText = "Bajo 11 a 28"
            Me.dgvTARIZOFI.Columns("TAZFTA03").HeaderText = "Medio-Bajo 29 a 46"
            Me.dgvTARIZOFI.Columns("TAZFTA04").HeaderText = "Medio 47 a 64"
            Me.dgvTARIZOFI.Columns("TAZFTA05").HeaderText = "Medio-Alto 65 a 84"
            Me.dgvTARIZOFI.Columns("TAZFTA06").HeaderText = "Alto 85 a 100"
            Me.dgvTARIZOFI.Columns("TAZFZOAP").HeaderText = "Zona aplicada"
            Me.dgvTARIZOFI.Columns("TAZFESTA").HeaderText = "Estado"
            Me.dgvTARIZOFI.Columns("TAZFSIGN").HeaderText = "Signo"
            Me.dgvTARIZOFI.Columns("TAZFPORC").HeaderText = "Por(%)"
            Me.dgvTARIZOFI.Columns("TAZFTALO").HeaderText = "Tarifa lote"

            Me.dgvTARIZOFI.Columns("TAZFIDRE").Visible = False

            '==================================================
            '*** ASIGNA LOS PRIVILEGIOS DE LA BARRA DE MENU ***
            '==================================================

            Dim ContarRegistros As Integer = Me.BindingSource_TARIZOFI_1.Count

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
            If Me.BindingSource_TARIZOFI_1.Count > 0 Then

                Me.lblTAZFDEPA.Text = CType(fun_Buscar_Lista_Valores_DEPARTAMENTO(Me.dgvTARIZOFI.CurrentRow.Cells("TAZFDEPA").Value.ToString()), String)
                Me.lblTAZFMUNI.Text = CType(fun_Buscar_Lista_Valores_MUNICIPIO(Me.dgvTARIZOFI.CurrentRow.Cells("TAZFDEPA").Value.ToString(), Me.dgvTARIZOFI.CurrentRow.Cells("TAZFMUNI").Value.ToString()), String)
                Me.lblTAZFCLSE.Text = CType(fun_Buscar_Lista_Valores_CLASSECT(Me.dgvTARIZOFI.CurrentRow.Cells("TAZFCLSE").Value.ToString()), String)
                Me.lblTAZFZOFI.Text = CType(fun_Buscar_Lista_Valores_ZONAFISI(Me.dgvTARIZOFI.CurrentRow.Cells("TAZFDEPA").Value.ToString(), Me.dgvTARIZOFI.CurrentRow.Cells("TAZFMUNI").Value.ToString(), Me.dgvTARIZOFI.CurrentRow.Cells("TAZFCLSE").Value.ToString(), Me.dgvTARIZOFI.CurrentRow.Cells("TAZFZOFI").Value.ToString()), String)
                Me.lblTAZFZOAP.Text = CType(fun_Buscar_Lista_Valores_ZONAFISI(Me.dgvTARIZOFI.CurrentRow.Cells("TAZFDEPA").Value.ToString(), Me.dgvTARIZOFI.CurrentRow.Cells("TAZFMUNI").Value.ToString(), Me.dgvTARIZOFI.CurrentRow.Cells("TAZFCLSE").Value.ToString(), Me.dgvTARIZOFI.CurrentRow.Cells("TAZFZOAP").Value.ToString()), String)
                Me.lblTAZFVIGE.Text = CType(fun_Buscar_Lista_Valores_VIGENCIA(Me.dgvTARIZOFI.CurrentRow.Cells.Item("TAZFVIGE").Value.ToString()), String)

            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub pro_LimpiarCampos()

        Me.lblTAZFMUNI.Text = ""
        Me.lblTAZFDEPA.Text = ""
        Me.lblTAZFCLSE.Text = ""
        Me.lblTAZFVIGE.Text = ""
        Me.lblTAZFZOFI.Text = ""
        Me.lblTAZFZOAP.Text = ""

    End Sub

#End Region

#Region "MENU"

    Private Sub cmdAGREGAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAGREGAR.Click

        Try
            frm_insertar_TARIZOFI.ShowDialog()
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
                Dim objdatos As New cla_TARIZOFI

                If objdatos.fun_Eliminar_TARIZOFI(Integer.Parse(Me.dgvTARIZOFI.SelectedRows.Item(0).Cells(0).Value.ToString())) Then
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
            Dim frm_modificar As New frm_modificar_TARIZOFI(Integer.Parse(Me.dgvTARIZOFI.SelectedRows.Item(0).Cells(0).Value.ToString()))

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

            frm_consultar_TARIZOFI.ShowDialog()

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

    Private Sub frm_TARIZOFI_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.GotFocus
        pro_ListaDeValores()
    End Sub
    Private Sub dgvTARIZOFI_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvTARIZOFI.GotFocus
        strBARRESTA.Items(0).Text = dgvTARIZOFI.AccessibleDescription
    End Sub

#End Region

#Region "KeyDown"

    Private Sub dgvTARIZOFI_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgvTARIZOFI.KeyDown
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
                Dim ContarRegistros As Integer = BindingSource_TARIZOFI_1.Count

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
                Dim ContarRegistros As Integer = BindingSource_TARIZOFI_1.Count

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

    Private Sub dgvTARIZOFI_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgvTARIZOFI.KeyUp
        If e.KeyCode = Keys.Down Or e.KeyCode = Keys.Up Or e.KeyCode = Keys.Enter Or e.KeyCode = Keys.PageUp Or e.KeyCode = Keys.PageDown Then
            pro_ListaDeValores()
        End If
    End Sub

#End Region

#Region "CellClick"

    Private Sub dgvTARIZOFI_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvTARIZOFI.CellClick
        pro_ListaDeValores()
    End Sub

#End Region

#End Region

End Class