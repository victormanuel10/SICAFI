Imports REGLAS_DEL_NEGOCIO

Public Class frm_CARGBENE

    '==========================================================
    '*** MANTENIMIENTO CARGAS Y BENEFICIOS DEL PLAN PARCIAL ***
    '==========================================================

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

    Public Shared Function instance() As frm_CARGBENE
        If frm_Instance Is Nothing OrElse frm_Instance.isdisposed = True Then
            frm_Instance = New frm_CARGBENE
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
            Dim objdatos As New cla_CARGBENE

            If boCONSULTA = False Then
                Me.BindingSource_CARGBENE_1.DataSource = objdatos.fun_Consultar_MANT_CARGBENE
            ElseIf boCONSULTA = True Then
                Me.BindingSource_CARGBENE_1.DataSource = objdatos.fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_MANT_CARGBENE(vp_inConsulta)
            End If

            Me.dgvCARGBENE.DataSource = Me.BindingSource_CARGBENE_1
            Me.BindingNavigator_CARGBENE_1.BindingSource = Me.BindingSource_CARGBENE_1

            '================================================
            '*** CONFIGURA OBJETOS DEL FORMULARIO MAESTRO ***
            '================================================

            Me.dgvCARGBENE.Columns("CABENURE").HeaderText = "Nro. Resolución"
            Me.dgvCARGBENE.Columns("CABEFERE").HeaderText = "Fecha Resolución"
            Me.dgvCARGBENE.Columns("CABEUAU").HeaderText = "U. A. U."
            Me.dgvCARGBENE.Columns("CABECEEP").HeaderText = "Cesión de espacio público m2"
            Me.dgvCARGBENE.Columns("CABECOEP").HeaderText = "Construcción adecuación espacio público m2"
            Me.dgvCARGBENE.Columns("CABECEVI").HeaderText = "Cesión en suelo vias m2"
            Me.dgvCARGBENE.Columns("CABECOVI").HeaderText = "Construcción de vias en m2"
            Me.dgvCARGBENE.Columns("CABECOEQ").HeaderText = "Construcción de equipamiento en m2"
            Me.dgvCARGBENE.Columns("CABECVAI").HeaderText = "Construcción de vias fuera del A.I. m2"
            Me.dgvCARGBENE.Columns("CABECEDI").HeaderText = "Cesión en dinero esterior P.P. m2"
            Me.dgvCARGBENE.Columns("ESTADESC").HeaderText = "Estado"

            Me.dgvCARGBENE.Columns("CABEIDRE").Visible = False
            Me.dgvCARGBENE.Columns("CABEDESC").Visible = False
            Me.dgvCARGBENE.Columns("CABEESTA").Visible = False

            Me.strBARRESTA.Items(2).Text = "Registros : " & BindingSource_CARGBENE_1.Count

            '==================================================
            '*** ASIGNA LOS PRIVILEGIOS DE LA BARRA DE MENU ***
            '==================================================

            Dim ContarRegistros As Integer = Me.BindingSource_CARGBENE_1.Count

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
            If BindingSource_CARGBENE_1.Count > 0 Then

                ' declara la variable
                Dim stPLPANURE As String = ""
                Dim stPLPAFERE As String = ""

                ' instancia de clase
                Dim obPLANPARC As New cla_PLANPARC
                Dim dtPLANPARC As New DataTable

                dtPLANPARC = obPLANPARC.fun_Buscar_CODIGO_PLANPARC(Me.dgvCARGBENE.CurrentRow.Cells("CABENURE").Value.ToString(), Me.dgvCARGBENE.CurrentRow.Cells("CABEFERE").Value.ToString())

                If dtPLANPARC.Rows.Count > 0 Then

                    stPLPANURE = CStr(Trim(dtPLANPARC.Rows(0).Item("PLPANURE")))
                    stPLPAFERE = CStr(Trim(dtPLANPARC.Rows(0).Item("PLPAFERE")))

                End If

                Me.lblCABEPLPA.Text = CType(fun_Buscar_Lista_Valores_PLAN_PARCIAL(Trim(stPLPANURE), Trim(stPLPAFERE)), String)
                Me.lblCABEUAU.Text = CType(fun_Buscar_Lista_Valores_CARGBENE(Trim(stPLPANURE), Trim(stPLPAFERE), Me.dgvCARGBENE.CurrentRow.Cells("CABEUAU").Value.ToString()), String)

            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description & "Lista de valores")
        End Try

    End Sub

#End Region

#Region "MENU"

    Private Sub cmdAGREGAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAGREGAR.Click

        Try
            frm_insertar_CARGBENE.ShowDialog()

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

                Dim objdatos As New cla_CARGBENE

                If objdatos.fun_Eliminar_MANT_CARGBENE(Integer.Parse(Me.dgvCARGBENE.SelectedRows.Item(0).Cells(0).Value.ToString())) = True Then
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
            Dim frm_modificar_CARGBENE As New frm_modificar_CARGBENE(Me.dgvCARGBENE.SelectedRows.Item(0).Cells("CABEIDRE").Value.ToString(), _
                                                                     Me.dgvCARGBENE.SelectedRows.Item(0).Cells("CABENURE").Value.ToString(), _
                                                                     Me.dgvCARGBENE.SelectedRows.Item(0).Cells("CABEFERE").Value.ToString(), _
                                                                     Me.dgvCARGBENE.SelectedRows.Item(0).Cells("CABEUAU").Value.ToString())
            frm_modificar_CARGBENE.ShowDialog()

            pro_Reconsultar()
            pro_ListaDeValores()

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub cmdCONSULTAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCONSULTAR.Click

        Try
            vp_inConsulta = 0

            frm_consultar_CARGBENE.ShowDialog()

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
    Private Sub dgv_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvCARGBENE.GotFocus
        strBARRESTA.Items(0).Text = dgvCARGBENE.AccessibleDescription
    End Sub

#End Region

#Region "KeyDown"

    Private Sub dgv_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgvCARGBENE.KeyDown
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
                Dim ContarRegistros As Integer = Me.BindingSource_CARGBENE_1.Count

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
                Dim ContarRegistros As Integer = Me.BindingSource_CARGBENE_1.Count

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

    Private Sub dgvCARGBENE_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgvCARGBENE.KeyUp
        If e.KeyCode = Keys.Down Or e.KeyCode = Keys.Up Or e.KeyCode = Keys.Enter Or e.KeyCode = Keys.PageUp Or e.KeyCode = Keys.PageDown Then
            pro_ListaDeValores()
        End If
    End Sub

#End Region

#Region "CellClick"

    Private Sub dgvCARGBENE_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvCARGBENE.CellClick
        pro_ListaDeValores()
    End Sub

#End Region

#End Region

End Class