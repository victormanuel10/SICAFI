Imports REGLAS_DEL_NEGOCIO

Public Class frm_TARIALPU

    '=========================
    '*** ALUMBRADO PUBLICO ***
    '=========================

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

    Public Shared Function instance() As frm_TARIALPU
        If frm_Instance Is Nothing OrElse frm_Instance.isdisposed = True Then
            frm_Instance = New frm_TARIALPU
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

            Dim objdatos As New cla_TARIALPU

            If boCONSULTA = False Then
                Me.BindingSource_ALUMPUBL_1.DataSource = objdatos.fun_Consultar_TARIALPU
            Else
                Me.BindingSource_ALUMPUBL_1.DataSource = objdatos.fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_TARIALPU(vp_inConsulta)
            End If

            Me.dgvTARIALPU_1.DataSource = BindingSource_ALUMPUBL_1
            Me.dgvTARIALPU_2.DataSource = BindingSource_ALUMPUBL_1
            Me.BindingNavigator_ALUMPUBL_1.BindingSource = BindingSource_ALUMPUBL_1

            '==================================================
            '*** CONFIGURA OBJETOS DEL FORMULARIO MAESTRO ***
            '==================================================

            Me.strBARRESTA.Items(2).Text = "Registros : " & Me.BindingSource_ALUMPUBL_1.Count

            Me.dgvTARIALPU_1.Columns("TAAPDEPA").HeaderText = "Departamento"
            Me.dgvTARIALPU_1.Columns("TAAPMUNI").HeaderText = "Municipio"
            Me.dgvTARIALPU_1.Columns("TAAPCLSE").HeaderText = "Sector"
            Me.dgvTARIALPU_1.Columns("TAAPVIGE").HeaderText = "Vigencia"
            Me.dgvTARIALPU_1.Columns("TAAPTIPO").HeaderText = "Tipo"
            Me.dgvTARIALPU_1.Columns("TAAPTARE").HeaderText = "Tarifa residencial"
            Me.dgvTARIALPU_1.Columns("TAAPTACO").HeaderText = "Tarifa comercial"
            Me.dgvTARIALPU_1.Columns("TAAPTAIN").HeaderText = "Tarifa industrial"
            Me.dgvTARIALPU_1.Columns("TAAPESTA").HeaderText = "Estado"

            Me.dgvTARIALPU_2.Columns("TAAPESTR").HeaderText = "Estrato"
            Me.dgvTARIALPU_2.Columns("TAAPTA01").HeaderText = "1. 0 a 10 Puntos"
            Me.dgvTARIALPU_2.Columns("TAAPTA02").HeaderText = "2. 11 a 28 Puntos"
            Me.dgvTARIALPU_2.Columns("TAAPTA03").HeaderText = "3. 29 a 46 Puntos"
            Me.dgvTARIALPU_2.Columns("TAAPTA04").HeaderText = "4. 47 a 69 Puntos"
            Me.dgvTARIALPU_2.Columns("TAAPTA05").HeaderText = "5. 70 a 100 Puntos"
            Me.dgvTARIALPU_2.Columns("TAAPAVIN").HeaderText = "Avaluo inicial"
            Me.dgvTARIALPU_2.Columns("TAAPAVFI").HeaderText = "Avaluo final"
            Me.dgvTARIALPU_2.Columns("TAAPESTA").HeaderText = "Estado"
            
            Me.dgvTARIALPU_1.Columns("TAAPIDRE").Visible = False
            Me.dgvTARIALPU_2.Columns("TAAPIDRE").Visible = False
            Me.dgvTARIALPU_2.Columns("TAAPDEPA").Visible = False
            Me.dgvTARIALPU_2.Columns("TAAPMUNI").Visible = False
            Me.dgvTARIALPU_2.Columns("TAAPCLSE").Visible = False
            Me.dgvTARIALPU_2.Columns("TAAPVIGE").Visible = False
            Me.dgvTARIALPU_2.Columns("TAAPTIPO").Visible = False
            Me.dgvTARIALPU_2.Columns("TAAPTARE").Visible = False
            Me.dgvTARIALPU_2.Columns("TAAPTACO").Visible = False
            Me.dgvTARIALPU_2.Columns("TAAPTAIN").Visible = False
            Me.dgvTARIALPU_1.Columns("TAAPESTR").Visible = False
            Me.dgvTARIALPU_1.Columns("TAAPTA01").Visible = False
            Me.dgvTARIALPU_1.Columns("TAAPTA02").Visible = False
            Me.dgvTARIALPU_1.Columns("TAAPTA03").Visible = False
            Me.dgvTARIALPU_1.Columns("TAAPTA04").Visible = False
            Me.dgvTARIALPU_1.Columns("TAAPTA05").Visible = False
            Me.dgvTARIALPU_1.Columns("TAAPAVIN").Visible = False
            Me.dgvTARIALPU_1.Columns("TAAPAVFI").Visible = False

            Me.dgvTARIALPU_1.Columns("TAAPTARE").DefaultCellStyle.Format = "c"
            Me.dgvTARIALPU_1.Columns("TAAPTACO").DefaultCellStyle.Format = "c"
            Me.dgvTARIALPU_1.Columns("TAAPTAIN").DefaultCellStyle.Format = "c"
            Me.dgvTARIALPU_2.Columns("TAAPAVIN").DefaultCellStyle.Format = "c"
            Me.dgvTARIALPU_2.Columns("TAAPAVFI").DefaultCellStyle.Format = "c"

            '==================================================
            '*** ASIGNA LOS PRIVILEGIOS DE LA BARRA DE MENU ***
            '==================================================

            Dim ContarRegistros As Integer = Me.BindingSource_ALUMPUBL_1.Count

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

            If Me.BindingSource_ALUMPUBL_1.Count > 0 Then

                Me.lblTAAPDEPA.Text = CType(fun_Buscar_Lista_Valores_DEPARTAMENTO(Me.dgvTARIALPU_1.CurrentRow.Cells("TAAPDEPA").Value.ToString()), String)
                Me.lblTAAPMUNI.Text = CType(fun_Buscar_Lista_Valores_MUNICIPIO(Me.dgvTARIALPU_1.CurrentRow.Cells("TAAPDEPA").Value.ToString(), Me.dgvTARIALPU_1.CurrentRow.Cells("TAAPMUNI").Value.ToString()), String)
                Me.lblTAAPCLSE.Text = CType(fun_Buscar_Lista_Valores_CLASSECT(Me.dgvTARIALPU_1.CurrentRow.Cells("TAAPCLSE").Value.ToString()), String)
                Me.lblTAAPVIGE.Text = CType(fun_Buscar_Lista_Valores_VIGENCIA(Me.dgvTARIALPU_1.CurrentRow.Cells("TAAPVIGE").Value.ToString()), String)
                Me.lblTAAPTIPO.Text = CType(fun_Buscar_Lista_Valores_TIPOCALI(Me.dgvTARIALPU_1.CurrentRow.Cells("TAAPTIPO").Value.ToString()), String)
                Me.lblTAAPESTR.Text = CType(fun_Buscar_Lista_Valores_ESTRATO(Me.dgvTARIALPU_1.CurrentRow.Cells("TAAPESTR").Value.ToString()), String)

            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub pro_LimpiarCampos()

        Me.lblTAAPMUNI.Text = ""
        Me.lblTAAPDEPA.Text = ""
        Me.lblTAAPCLSE.Text = ""
        Me.lblTAAPVIGE.Text = ""
        Me.lblTAAPTIPO.Text = ""
        Me.lblTAAPESTR.Text = ""

    End Sub

#End Region

#Region "MENU"

    Private Sub cmdAGREGAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAGREGAR.Click
        Try
            frm_insertar_TARIALPU.ShowDialog()
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
                Dim objdatos As New cla_TARIALPU

                If objdatos.fun_Eliminar_TARIALPU(Integer.Parse(Me.dgvTARIALPU_1.SelectedRows.Item(0).Cells(0).Value.ToString())) Then
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
            Dim frm_modificar As New frm_modificar_TARIALPU(Integer.Parse(Me.dgvTARIALPU_1.SelectedRows.Item(0).Cells(0).Value.ToString()))

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

            frm_consultar_TARIALPU.ShowDialog()

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
    Private Sub dgvALUMPUBL_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvTARIALPU_1.GotFocus, dgvTARIALPU_2.GotFocus
        Me.strBARRESTA.Items(0).Text = Me.dgvTARIALPU_1.AccessibleDescription
    End Sub

#End Region

#Region "KeyDown"

    Private Sub dgvALUMPUBL_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgvTARIALPU_1.KeyDown, dgvTARIALPU_2.KeyDown
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
                Dim ContarRegistros As Integer = BindingSource_ALUMPUBL_1.Count

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
                Dim ContarRegistros As Integer = BindingSource_ALUMPUBL_1.Count

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

    Private Sub dgvALUMPUBL_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgvTARIALPU_1.KeyUp, dgvTARIALPU_2.KeyUp
        If e.KeyCode = Keys.Down Or e.KeyCode = Keys.Up Or e.KeyCode = Keys.Enter Or e.KeyCode = Keys.PageUp Or e.KeyCode = Keys.PageDown Then
            pro_ListaDeValores()
        End If
    End Sub

#End Region

#Region "CellClick"

    Private Sub dgvALUMPUBL_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvTARIALPU_1.CellClick, dgvTARIALPU_2.CellClick
        pro_ListaDeValores()
    End Sub

#End Region

#End Region

  
End Class