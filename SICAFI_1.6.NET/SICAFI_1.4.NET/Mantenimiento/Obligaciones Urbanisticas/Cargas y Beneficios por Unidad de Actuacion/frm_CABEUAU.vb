Imports REGLAS_DEL_NEGOCIO

Public Class frm_CABEUAU

    '=================================================================
    '*** MANTENIMIENTO CARGAS Y BENEFICIOS POR UNIDAD DE ACTUACION ***
    '=================================================================

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

    Public Shared Function instance() As frm_CABEUAU
        If frm_Instance Is Nothing OrElse frm_Instance.isdisposed = True Then
            frm_Instance = New frm_CABEUAU
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
            Dim objdatos As New cla_CABEUAU

            If boCONSULTA = False Then
                Me.BindingSource_CABEUAU_1.DataSource = objdatos.fun_Consultar_MANT_CABEUAU
            ElseIf boCONSULTA = True Then
                Me.BindingSource_CABEUAU_1.DataSource = objdatos.fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_MANT_CABEUAU(vp_inConsulta)
            End If

            Me.dgvCABEUAU.DataSource = Me.BindingSource_CABEUAU_1
            Me.BindingNavigator_CABEUAU_1.BindingSource = Me.BindingSource_CABEUAU_1

            '================================================
            '*** CONFIGURA OBJETOS DEL FORMULARIO MAESTRO ***
            '================================================

            Me.dgvCABEUAU.Columns("CBUARESO").HeaderText = "Nro. Resolución"
            Me.dgvCABEUAU.Columns("CBUAFECH").HeaderText = "Fecha Resolución"
            Me.dgvCABEUAU.Columns("PLPADESC").HeaderText = "Plan Parcial"
            Me.dgvCABEUAU.Columns("CBPPDESC").HeaderText = "Carga y Beneficio"
            Me.dgvCABEUAU.Columns("CBUAUAPP").HeaderText = "U. A. U."
            Me.dgvCABEUAU.Columns("CBUAVALO").HeaderText = "Valor"
            Me.dgvCABEUAU.Columns("ESTADESC").HeaderText = "Estado"

            Me.dgvCABEUAU.Columns("CBUAIDRE").Visible = False
            Me.dgvCABEUAU.Columns("CBUAESTA").Visible = False
            Me.dgvCABEUAU.Columns("CBUARESO").Visible = False
            Me.dgvCABEUAU.Columns("CBUAFECH").Visible = False

            Me.dgvCABEUAU.Columns("CBUAVALO").DefaultCellStyle.Format = "n"
            Me.dgvCABEUAU.Columns("CBUAVALO").DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopRight

            Me.dgvCABEUAU.Columns("CBPPDESC").Width = 500

            Me.strBARRESTA.Items(2).Text = "Registros : " & BindingSource_CABEUAU_1.Count

            '==================================================
            '*** ASIGNA LOS PRIVILEGIOS DE LA BARRA DE MENU ***
            '==================================================

            Dim ContarRegistros As Integer = Me.BindingSource_CABEUAU_1.Count

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
            If BindingSource_CABEUAU_1.Count > 0 Then

                ' declara la variable
                Dim stPLPANURE As String = ""
                Dim stPLPAFERE As String = ""

                ' instancia de clase
                Dim obPLANPARC As New cla_PLANPARC
                Dim dtPLANPARC As New DataTable

                dtPLANPARC = obPLANPARC.fun_Buscar_CODIGO_PLANPARC(Me.dgvCABEUAU.CurrentRow.Cells("CBUARESO").Value.ToString(), Me.dgvCABEUAU.CurrentRow.Cells("CBUAFECH").Value.ToString())

                If dtPLANPARC.Rows.Count > 0 Then

                    stPLPANURE = CStr(Trim(dtPLANPARC.Rows(0).Item("PLPANURE")))
                    stPLPAFERE = CStr(Trim(dtPLANPARC.Rows(0).Item("PLPAFERE")))

                End If


            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description & "Lista de valores")
        End Try

    End Sub

#End Region

#Region "MENU"

    Private Sub cmdAGREGAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAGREGAR.Click

        Try
            frm_insertar_CABEUAU.ShowDialog()

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

                Dim objdatos As New cla_CABEUAU

                If objdatos.fun_Eliminar_MANT_CABEUAU(Integer.Parse(Me.dgvCABEUAU.SelectedRows.Item(0).Cells(0).Value.ToString())) = True Then
                    boCONSULTA = False
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
            Dim frm_modificar_CABEUAU As New frm_modificar_CABEUAU(Me.dgvCABEUAU.SelectedRows.Item(0).Cells("CBUAIDRE").Value.ToString(), _
                                                                   Me.dgvCABEUAU.SelectedRows.Item(0).Cells("CBUARESO").Value.ToString(), _
                                                                   Me.dgvCABEUAU.SelectedRows.Item(0).Cells("CBUAFECH").Value.ToString())
            frm_modificar_CABEUAU.ShowDialog()

            pro_Reconsultar()
            pro_ListaDeValores()

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub cmdCONSULTAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCONSULTAR.Click

        Try
            'vp_inConsulta = 0

            'frm_consultar_CABEUAU.ShowDialog()

            'If vp_inConsulta > 0 Then
            '    boCONSULTA = True
            'Else
            '    boCONSULTA = False
            'End If

            'pro_Reconsultar()
            'pro_ListaDeValores()

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
    Private Sub dgv_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvCABEUAU.GotFocus
        strBARRESTA.Items(0).Text = dgvCABEUAU.AccessibleDescription
    End Sub

#End Region

#Region "KeyDown"

    Private Sub dgv_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgvCABEUAU.KeyDown
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
                Dim ContarRegistros As Integer = Me.BindingSource_CABEUAU_1.Count

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
                Dim ContarRegistros As Integer = Me.BindingSource_CABEUAU_1.Count

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

    Private Sub dgvCABEUAU_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgvCABEUAU.KeyUp
        If e.KeyCode = Keys.Down Or e.KeyCode = Keys.Up Or e.KeyCode = Keys.Enter Or e.KeyCode = Keys.PageUp Or e.KeyCode = Keys.PageDown Then
            pro_ListaDeValores()
        End If
    End Sub

#End Region

#Region "CellClick"

    Private Sub dgvCABEUAU_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvCABEUAU.CellClick
        pro_ListaDeValores()
    End Sub

#End Region

#End Region

End Class