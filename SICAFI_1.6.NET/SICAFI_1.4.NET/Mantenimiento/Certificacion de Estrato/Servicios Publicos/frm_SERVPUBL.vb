Imports REGLAS_DEL_NEGOCIO

Public Class frm_SERVPUBL

    '==========================
    '*** SERVICIOS PUBLICOS ***
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

    Public Shared Function instance() As frm_SERVPUBL
        If frm_Instance Is Nothing OrElse frm_Instance.isdisposed = True Then
            frm_Instance = New frm_SERVPUBL
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
            Dim objdatos As New cla_SERVPUBL

            If boCONSULTA = False Then
                Me.BindingSource_SERVPUBL_1.DataSource = objdatos.fun_Consultar_MANT_SERVPUBL
            ElseIf boCONSULTA = True Then
                Me.BindingSource_SERVPUBL_1.DataSource = objdatos.fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_MANT_SERVPUBL(vp_inConsulta)
            End If

            Me.dgvSERVPUBL.DataSource = Me.BindingSource_SERVPUBL_1
            Me.BindingNavigator_SERVPUBL_1.BindingSource = Me.BindingSource_SERVPUBL_1

            '================================================
            '*** CONFIGURA OBJETOS DEL FORMULARIO MAESTRO ***
            '================================================

            Me.dgvSERVPUBL.Columns("SEPUCODI").HeaderText = "Codigo"
            Me.dgvSERVPUBL.Columns("SEPUDESC").HeaderText = "Descripción"
            Me.dgvSERVPUBL.Columns("ESTADESC").HeaderText = "Estado"

            Me.dgvSERVPUBL.Columns("SEPUIDRE").Visible = False
            Me.dgvSERVPUBL.Columns("SEPUESTA").Visible = False

            Me.dgvSERVPUBL.Columns("SEPUCODI").Width = 161
            Me.dgvSERVPUBL.Columns("SEPUDESC").Width = 300
            Me.dgvSERVPUBL.Columns("SEPUESTA").Width = 107

            Me.strBARRESTA.Items(2).Text = "Registros : " & BindingSource_SERVPUBL_1.Count

            '==================================================
            '*** SEPUNA LOS PRIVILEGIOS DE LA BARRA DE MENU ***
            '==================================================

            Dim ContarRegistros As Integer = Me.BindingSource_SERVPUBL_1.Count

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

#End Region

#Region "MENU"

    Private Sub cmdAGREGAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAGREGAR.Click

        Try
            frm_insertar_SERVPUBL.ShowDialog()

            boCONSULTA = False
            pro_Reconsultar()

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub cmdELIMINAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdELIMINAR.Click

        Try
            If MessageBox.Show("¿ Desea eliminar el registro seleccionado ?", "Mensaje...", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then

                Dim objdatos As New cla_SERVPUBL

                If objdatos.fun_Eliminar_MANT_SERVPUBL(Integer.Parse(Me.dgvSERVPUBL.SelectedRows.Item(0).Cells(0).Value.ToString())) = True Then
                    boCONSULTA = False
                    pro_Reconsultar()
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
            Dim frm_modificar_SERVPUBL As New frm_modificar_SERVPUBL(Integer.Parse(Me.dgvSERVPUBL.SelectedRows.Item(0).Cells(0).Value.ToString()))
            frm_modificar_SERVPUBL.ShowDialog()

            pro_Reconsultar()

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub cmdCONSULTAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCONSULTAR.Click

        Try
            vp_inConsulta = 0

            frm_consultar_SERVPUBL.ShowDialog()

            If vp_inConsulta > 0 Then
                boCONSULTA = True
            Else
                boCONSULTA = False
            End If

            pro_Reconsultar()

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub cmdRECONSULTAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdRECONSULTAR.Click
        boCONSULTA = False
        pro_Reconsultar()
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
        Me.dgvSERVPUBL.Focus()
    End Sub

#End Region

#Region "KeyDown"

    Private Sub dgv_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgvSERVPUBL.KeyDown
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
                Dim ContarRegistros As Integer = Me.BindingSource_SERVPUBL_1.Count

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
                Dim ContarRegistros As Integer = Me.BindingSource_SERVPUBL_1.Count

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

#Region "GotFocus"

    Private Sub dgv_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvSERVPUBL.GotFocus
        strBARRESTA.Items(0).Text = dgvSERVPUBL.AccessibleDescription
    End Sub

#End Region

#End Region

End Class