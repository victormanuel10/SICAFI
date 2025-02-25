Imports REGLAS_DEL_NEGOCIO

Public Class frm_CAMPOS

    '============================
    '*** MANTENIMIENTO CAMPOS ***
    '============================

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

    Public Shared Function instance() As frm_CAMPOS
        If frm_Instance Is Nothing OrElse frm_Instance.isdisposed = True Then
            frm_Instance = New frm_CAMPOS
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
            Dim objdatos As New cla_CAMPOS

            If boCONSULTA = False Then
                Me.BindingSource_CAMPOS_1.DataSource = objdatos.fun_Consultar_MANT_CAMPOS
            Else
                Me.BindingSource_CAMPOS_1.DataSource = objdatos.fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_MANT_CAMPOS(vp_inConsulta)
            End If

            Me.dgvCAMPOS1.DataSource = BindingSource_CAMPOS_1
            Me.dgvCAMPOS2.DataSource = BindingSource_CAMPOS_1
            Me.BindingNavigator_CAMPOS_1.BindingSource = BindingSource_CAMPOS_1

            '================================================
            '*** CONFIGURA OBJETOS DEL FORMULARIO MAESTRO ***
            '================================================

            Me.strBARRESTA.Items(2).Text = "Registros : " & BindingSource_CAMPOS_1.Count

            Me.dgvCAMPOS1.Columns("CAMPPROC").HeaderText = "Procedimiento"
            Me.dgvCAMPOS1.Columns("CAMPTABL").HeaderText = "Tabla"
            Me.dgvCAMPOS1.Columns("CAMPCODI").HeaderText = "Campo"
            Me.dgvCAMPOS1.Columns("CAMPDESC").HeaderText = "Descripción"
            Me.dgvCAMPOS1.Columns("CAMPLLPR").HeaderText = "Llave primaria"
            Me.dgvCAMPOS1.Columns("CAMPREQU").HeaderText = "Requerido"

            Me.dgvCAMPOS2.Columns("CAMPTIDA").HeaderText = "Tipo de dato"
            Me.dgvCAMPOS2.Columns("CAMPLONG").HeaderText = "Longitud"
            Me.dgvCAMPOS2.Columns("CAMPCOND").HeaderText = "Condicional"
            Me.dgvCAMPOS2.Columns("CAMPMANT").HeaderText = "Mantenimiento"
            Me.dgvCAMPOS2.Columns("CAMPTAMA").HeaderText = "Tabla Mantenimiento"
            Me.dgvCAMPOS2.Columns("CAMPSIST").HeaderText = "Sistema"
            Me.dgvCAMPOS2.Columns("CAMPTASI").HeaderText = "Tabla Sistema"
            Me.dgvCAMPOS2.Columns("CAMPESTA").HeaderText = "Estado"
            Me.dgvCAMPOS2.Columns("CAMPLLMA").HeaderText = "Llave Mantenimiento"
            Me.dgvCAMPOS2.Columns("CAMPLLSI").HeaderText = "Llave Sistema"

            Me.dgvCAMPOS1.Columns("CAMPIDRE").Visible = False
            Me.dgvCAMPOS1.Columns("CAMPTIDA").Visible = False
            Me.dgvCAMPOS1.Columns("CAMPLONG").Visible = False
            Me.dgvCAMPOS1.Columns("CAMPCOND").Visible = False
            Me.dgvCAMPOS1.Columns("CAMPMANT").Visible = False
            Me.dgvCAMPOS1.Columns("CAMPTAMA").Visible = False
            Me.dgvCAMPOS1.Columns("CAMPSIST").Visible = False
            Me.dgvCAMPOS1.Columns("CAMPTASI").Visible = False
            Me.dgvCAMPOS1.Columns("CAMPESTA").Visible = False
            Me.dgvCAMPOS1.Columns("CAMPLLMA").Visible = False
            Me.dgvCAMPOS1.Columns("CAMPLLSI").Visible = False

            Me.dgvCAMPOS2.Columns("CAMPIDRE").Visible = False
            Me.dgvCAMPOS2.Columns("CAMPPROC").Visible = False
            Me.dgvCAMPOS2.Columns("CAMPTABL").Visible = False
            Me.dgvCAMPOS2.Columns("CAMPCODI").Visible = False
            Me.dgvCAMPOS2.Columns("CAMPDESC").Visible = False
            Me.dgvCAMPOS2.Columns("CAMPLLPR").Visible = False
            Me.dgvCAMPOS2.Columns("CAMPREQU").Visible = False

            Me.dgvCAMPOS1.Columns("CAMPPROC").Width = 150
            Me.dgvCAMPOS1.Columns("CAMPTABL").Width = 150
            Me.dgvCAMPOS1.Columns("CAMPCODI").Width = 150
            Me.dgvCAMPOS1.Columns("CAMPDESC").Width = 200
            Me.dgvCAMPOS1.Columns("CAMPLLPR").Width = 110
            Me.dgvCAMPOS1.Columns("CAMPREQU").Width = 110

            '==================================================
            '*** ASIGNA LOS PRIVILEGIOS DE LA BARRA DE MENU ***
            '==================================================

            Dim ContarRegistros As Integer = BindingSource_CAMPOS_1.Count

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
            If Me.BindingSource_CAMPOS_1.Count > 0 Then

                Me.lblCAMPPROC.Text = CType(fun_Buscar_Lista_Valores_PROCEDIMIENTO(Me.dgvCAMPOS1.CurrentRow.Cells("CAMPPROC").Value.ToString()), String)
                Me.lblCAMPTABL.Text = CType(fun_Buscar_Lista_Valores_TABLAS(Me.dgvCAMPOS1.CurrentRow.Cells("CAMPTABL").Value.ToString()), String)
                Me.lblCAMPTAMA.Text = CType(fun_Buscar_Lista_Valores_TABLAS(Me.dgvCAMPOS2.CurrentRow.Cells("CAMPTAMA").Value.ToString()), String)
                Me.lblCAMPTASI.Text = CType(fun_Buscar_Lista_Valores_TABLAS(Me.dgvCAMPOS2.CurrentRow.Cells("CAMPTASI").Value.ToString()), String)

            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub pro_LimpiarCampos()

        Me.lblCAMPPROC.Text = ""
        Me.lblCAMPTABL.Text = ""
        Me.lblCAMPTAMA.Text = ""
        Me.lblCAMPTASI.Text = ""

    End Sub

#End Region

#Region "MENU"

    Private Sub cmdAGREGAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAGREGAR.Click

        Try
            Dim frm_insertar_CAMPOS As New frm_comandos_CAMPOS(True, False)
            frm_insertar_CAMPOS.ShowDialog()

            boCONSULTA = False
            pro_Reconsultar()

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub cmdELIMINAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdELIMINAR.Click

        Try

            If MessageBox.Show("¿ Desea eliminar el registro seleccionado ? ", "Mensaje...", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then
                Dim objdatos As New cla_CAMPOS

                If objdatos.fun_Eliminar_MANT_CAMPOS(Integer.Parse(Me.dgvCAMPOS1.SelectedRows.Item(0).Cells(0).Value.ToString())) Then
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
            Dim frm_modificar_CAMPOS As New frm_comandos_CAMPOS(Integer.Parse(Me.dgvCAMPOS1.SelectedRows.Item(0).Cells(0).Value.ToString()))

            frm_modificar_CAMPOS.ShowDialog()
            pro_Reconsultar()

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub cmdCONSULTAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCONSULTAR.Click

        Try
            vp_inConsulta = 0

            Dim frm_consultar_CAMPOS As New frm_comandos_CAMPOS(False, True)
            frm_consultar_CAMPOS.ShowDialog()

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

        Try
            boCONSULTA = False
            pro_Reconsultar()

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

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

    Private Sub frm_Mantenimiento_CONCEPTO_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        pro_Reconsultar()
    End Sub

#End Region

#Region "GotFocus"

    Private Sub frm_CONCEPTO_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.GotFocus
        pro_ListaDeValores()
    End Sub

#End Region

#Region "KeyDown"

    Private Sub dgvCLSECLSE_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgvCAMPOS1.KeyDown, dgvCAMPOS2.KeyDown
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
                Dim ContarRegistros As Integer = BindingSource_CAMPOS_1.Count

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
                Dim ContarRegistros As Integer = BindingSource_CAMPOS_1.Count

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

#Region "GotFocus"

    Private Sub dgvCLSECLSE_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvCAMPOS1.GotFocus, dgvCAMPOS2.GotFocus
        Me.strBARRESTA.Items(0).Text = Me.dgvCAMPOS1.AccessibleDescription
    End Sub

#End Region

#Region "KeyUp"

    Private Sub dgvCONCEPTO_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgvCAMPOS1.KeyUp, dgvCAMPOS2.KeyUp
        If e.KeyCode = Keys.Down Or e.KeyCode = Keys.Up Or e.KeyCode = Keys.Enter Or e.KeyCode = Keys.PageUp Or e.KeyCode = Keys.PageDown Then
            pro_ListaDeValores()
        End If
    End Sub

#End Region

#Region "CellClick"

    Private Sub dgvCONCEPTO_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvCAMPOS1.CellClick, dgvCAMPOS2.CellClick
        pro_ListaDeValores()
    End Sub

#End Region

#End Region

End Class