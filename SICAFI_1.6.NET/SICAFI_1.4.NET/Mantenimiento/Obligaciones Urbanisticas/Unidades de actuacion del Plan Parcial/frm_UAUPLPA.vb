Imports REGLAS_DEL_NEGOCIO

Public Class frm_UAUPLPA

    '================================================================
    '*** MANTENIMIENTO UNIDADES DE ACTUALIZACION DEL PLAN PARCIAL ***
    '================================================================

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

    Public Shared Function instance() As frm_UAUPLPA
        If frm_Instance Is Nothing OrElse frm_Instance.isdisposed = True Then
            frm_Instance = New frm_UAUPLPA
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
            Dim objdatos As New cla_UAUPLPA

            If boCONSULTA = False Then
                Me.BindingSource_UAUPLPA_1.DataSource = objdatos.fun_Consultar_MANT_UAUPLPA
            ElseIf boCONSULTA = True Then
                Me.BindingSource_UAUPLPA_1.DataSource = objdatos.fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_MANT_UAUPLPA(vp_inConsulta)
            End If

            Me.dgvUAUPLPA.DataSource = Me.BindingSource_UAUPLPA_1
            Me.BindingNavigator_UAUPLPA_1.BindingSource = Me.BindingSource_UAUPLPA_1

            '================================================
            '*** CONFIGURA OBJETOS DEL FORMULARIO MAESTRO ***
            '================================================

            Me.dgvUAUPLPA.Columns("UAPPRESO").HeaderText = "Nro. Resolución"
            Me.dgvUAUPLPA.Columns("UAPPFECH").HeaderText = "Fecha Resolución"
            Me.dgvUAUPLPA.Columns("UAPPUAU").HeaderText = "U. A. U."
            Me.dgvUAUPLPA.Columns("PLPADESC").HeaderText = "Plan Parcial"
            Me.dgvUAUPLPA.Columns("ESTADESC").HeaderText = "Estado"

            Me.dgvUAUPLPA.Columns("UAPPIDRE").Visible = False
            Me.dgvUAUPLPA.Columns("UAPPESTA").Visible = False

            Me.dgvUAUPLPA.Columns("UAPPRESO").Width = 80
            Me.dgvUAUPLPA.Columns("UAPPFECH").Width = 80
            Me.dgvUAUPLPA.Columns("UAPPUAU").Width = 80
            Me.dgvUAUPLPA.Columns("PLPADESC").Width = 180
            Me.dgvUAUPLPA.Columns("ESTADESC").Width = 120

            Me.strBARRESTA.Items(2).Text = "Registros : " & BindingSource_UAUPLPA_1.Count

            '==================================================
            '*** ASIGNA LOS PRIVILEGIOS DE LA BARRA DE MENU ***
            '==================================================

            Dim ContarRegistros As Integer = Me.BindingSource_UAUPLPA_1.Count

            Dim boCONTAGRE, boCONTMODI, boCONTELIM, boCONTCONS, boCONTRECO As Boolean

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
            If BindingSource_UAUPLPA_1.Count > 0 Then

                ' declara la variable
                Dim stPLPANURE As String = ""
                Dim stPLPAFERE As String = ""

                ' instancia de clase
                Dim obPLANPARC As New cla_PLANPARC
                Dim dtPLANPARC As New DataTable

                dtPLANPARC = obPLANPARC.fun_Buscar_CODIGO_PLANPARC(Me.dgvUAUPLPA.CurrentRow.Cells("UAPPRESO").Value.ToString(), Me.dgvUAUPLPA.CurrentRow.Cells("UAPPFECH").Value.ToString())

                If dtPLANPARC.Rows.Count > 0 Then

                    stPLPANURE = CStr(Trim(dtPLANPARC.Rows(0).Item("PLPANURE")))
                    stPLPAFERE = CStr(Trim(dtPLANPARC.Rows(0).Item("PLPAFERE")))

                End If

                Me.lblUAUPLPA.Text = CType(fun_Buscar_Lista_Valores_PLAN_PARCIAL(Trim(stPLPANURE), Trim(stPLPAFERE)), String)

            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description & "Lista de valores")
        End Try

    End Sub
    Private Sub pro_LimpiarCampos()

        Me.lblUAUPLPA.Text = ""

    End Sub

#End Region

#Region "MENU"

    Private Sub cmdAGREGAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAGREGAR.Click

        Try
            frm_insertar_UAUPLPA.ShowDialog()

            boCONSULTA = False
            pro_Reconsultar()
            pro_ListaDeValores()

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub cmdELIMINAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdELIMINAR.Click

        Try
            If MessageBox.Show("¿ Desea eliminar el registro seleccionado ?", "Mensaje...", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then

                Dim objdatos As New cla_UAUPLPA

                If objdatos.fun_Eliminar_MANT_UAUPLPA(Integer.Parse(Me.dgvUAUPLPA.SelectedRows.Item(0).Cells(0).Value.ToString())) = True Then
                    boCONSULTA = False
                    pro_LimpiarCampos()
                    pro_Reconsultar()
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
            Dim frm_modificar_UAUPLPA As New frm_modificar_UAUPLPA(Me.dgvUAUPLPA.SelectedRows.Item(0).Cells("UAPPIDRE").Value.ToString(), _
                                                                   Me.dgvUAUPLPA.SelectedRows.Item(0).Cells("UAPPRESO").Value.ToString(), _
                                                                   Me.dgvUAUPLPA.SelectedRows.Item(0).Cells("UAPPFECH").Value.ToString(), _
                                                                   Me.dgvUAUPLPA.SelectedRows.Item(0).Cells("UAPPUAU").Value.ToString())
            frm_modificar_UAUPLPA.ShowDialog()

            pro_Reconsultar()
            pro_ListaDeValores()

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub cmdCONSULTAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCONSULTAR.Click

        Try
            vp_inConsulta = 0

            frm_consultar_UAUPLPA.ShowDialog()

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

#End Region

#Region "FORMULARIO"

#Region "Load"

    Private Sub frm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        pro_Reconsultar()
    End Sub

#End Region

#Region "GotFocus"

    Private Sub frm_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.GotFocus
        pro_ListaDeValores()
    End Sub
    Private Sub dgv_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvUAUPLPA.GotFocus
        strBARRESTA.Items(0).Text = dgvUAUPLPA.AccessibleDescription
    End Sub

#End Region

#Region "KeyDown"

    Private Sub dgv_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgvUAUPLPA.KeyDown
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
                Dim ContarRegistros As Integer = Me.BindingSource_UAUPLPA_1.Count

                If ContarRegistros = 0 Then
                    mod_MENSAJE.No_Existe_Un_Registro_Seleccionado()
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
                Dim ContarRegistros As Integer = Me.BindingSource_UAUPLPA_1.Count

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

    Private Sub dgvUAUPLPA_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgvUAUPLPA.KeyUp
        If e.KeyCode = Keys.Down Or e.KeyCode = Keys.Up Or e.KeyCode = Keys.Enter Or e.KeyCode = Keys.PageUp Or e.KeyCode = Keys.PageDown Then
            pro_ListaDeValores()
        End If
    End Sub

#End Region

#Region "CellClick"

    Private Sub dgvUAUPLPA_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvUAUPLPA.CellClick
        pro_ListaDeValores()
    End Sub

#End Region

#End Region

End Class