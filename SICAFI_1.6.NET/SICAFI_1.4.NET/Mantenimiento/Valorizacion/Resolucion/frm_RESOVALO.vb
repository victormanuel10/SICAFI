Imports REGLAS_DEL_NEGOCIO

Public Class frm_RESOVALO

    '====================================
    ' *** RESOLUCIÓN DE ACTUALIZACIÓN ***
    '====================================

#Region "VARIABLES LOCALES"

    Dim boCONSULTA As Boolean = False

#End Region

#Region "CONSULTA PARAMETRIZADA"

    Public Sub New(ByVal idCodigo As Integer)

        vp_inConsulta = idCodigo
        InitializeComponent()

    End Sub

#End Region

#Region "INSTANCIAR FORMULARIO"

    Private Shared frm_Instance = Nothing

    Public Shared Function instance() As frm_RESOVALO
        If frm_Instance Is Nothing OrElse frm_Instance.isdisposed = True Then
            frm_Instance = New frm_RESOVALO
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
            Dim objdatos As New cla_RESOVALO

            If boCONSULTA = False Then
                Me.BindingSource_RESOVALO_1.DataSource = objdatos.fun_Consultar_RESOVALO
            Else
                Me.BindingSource_RESOVALO_1.DataSource = objdatos.fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_RESOVALO(vp_inConsulta)

            End If

            Me.dgvRESOVALO_1.DataSource = Me.BindingSource_RESOVALO_1
            Me.dgvRESOVALO_2.DataSource = Me.BindingSource_RESOVALO_1

            Me.BindingNavigator_RESOVALO_1.BindingSource = Me.BindingSource_RESOVALO_1

            '==================================================
            '*** CONFUGURA OBJETOS DEL FORMULARIO MAESTRO ***
            '==================================================

            Me.strBARRESTA.Items(2).Text = "Registros : " & BindingSource_RESOVALO_1.Count

            Me.dgvRESOVALO_1.Columns("REVAIDRE").Visible = False
            Me.dgvRESOVALO_1.Columns("REVACONT").Visible = False

            Me.dgvRESOVALO_1.Columns("REVATIRE").Visible = False
            Me.dgvRESOVALO_1.Columns("REVAVIGE").Visible = False
            Me.dgvRESOVALO_1.Columns("REVADESC").Visible = False
            Me.dgvRESOVALO_1.Columns("REVAESTA").Visible = False
            Me.dgvRESOVALO_1.Columns("REVARETO").Visible = False
            Me.dgvRESOVALO_1.Columns("REVAREPA").Visible = False

            Me.dgvRESOVALO_1.Columns("REVADEPA").Visible = False
            Me.dgvRESOVALO_1.Columns("REVAMUNI").Visible = False
            Me.dgvRESOVALO_1.Columns("REVACLSE").Visible = False
            Me.dgvRESOVALO_1.Columns("REVAPROY").Visible = False
            Me.dgvRESOVALO_1.Columns("REVAESTA").Visible = False
            Me.dgvRESOVALO_1.Columns("ESTADESC").Visible = False
            Me.dgvRESOVALO_1.Columns("VIGEDESC").Visible = False
            Me.dgvRESOVALO_1.Columns("TIREDESC").Visible = False

            Me.dgvRESOVALO_1.Columns("DEPADESC").HeaderText = "Departamento"
            Me.dgvRESOVALO_1.Columns("MUNIDESC").HeaderText = "Municipio"
            Me.dgvRESOVALO_1.Columns("CLSEDESC").HeaderText = "Clase o Sector"
            Me.dgvRESOVALO_1.Columns("PROYDESC").HeaderText = "Proyecto"
            Me.dgvRESOVALO_1.Columns("REVADECR").HeaderText = "Decreto"
            Me.dgvRESOVALO_1.Columns("REVAFECH").HeaderText = "Fecha"

            Me.dgvRESOVALO_2.Columns("REVAIDRE").Visible = False
            Me.dgvRESOVALO_2.Columns("REVACONT").Visible = False

            Me.dgvRESOVALO_2.Columns("REVADEPA").Visible = False
            Me.dgvRESOVALO_2.Columns("REVAMUNI").Visible = False
            Me.dgvRESOVALO_2.Columns("REVACLSE").Visible = False
            Me.dgvRESOVALO_2.Columns("REVAPROY").Visible = False
            Me.dgvRESOVALO_2.Columns("REVADECR").Visible = False
            Me.dgvRESOVALO_2.Columns("DEPADESC").Visible = False
            Me.dgvRESOVALO_2.Columns("MUNIDESC").Visible = False
            Me.dgvRESOVALO_2.Columns("CLSEDESC").Visible = False
            Me.dgvRESOVALO_2.Columns("REVATIRE").Visible = False
            Me.dgvRESOVALO_2.Columns("REVAESTA").Visible = False
            Me.dgvRESOVALO_2.Columns("PROYDESC").Visible = False
            Me.dgvRESOVALO_2.Columns("REVAVIGE").Visible = False
            Me.dgvRESOVALO_2.Columns("REVAFECH").Visible = False

            Me.dgvRESOVALO_2.Columns("TIREDESC").HeaderText = "Tipo Resolución"
            Me.dgvRESOVALO_2.Columns("VIGEDESC").HeaderText = "Vigencia"
            Me.dgvRESOVALO_2.Columns("REVADESC").HeaderText = "Descripción"
            Me.dgvRESOVALO_2.Columns("ESTADESC").HeaderText = "Estado"
            Me.dgvRESOVALO_2.Columns("REVACONT").HeaderText = "Contraseña"
            Me.dgvRESOVALO_2.Columns("REVARETO").HeaderText = "Total"
            Me.dgvRESOVALO_2.Columns("REVAREPA").HeaderText = "Parcial"

            Me.dgvRESOVALO_1.Columns("PROYDESC").Width = 250
            Me.dgvRESOVALO_2.Columns("REVADESC").Width = 250


            '==================================================
            '*** ASIGNA LOS PRIVILEGIOS DE LA BARRA DE MENU ***
            '==================================================

            Dim boCONTAGRE As Boolean = False
            Dim boCONTMODI As Boolean = False
            Dim boCONTELIM As Boolean = False
            Dim boCONTCONS As Boolean = False
            Dim boCONTRECO As Boolean = False

            pro_Permiso_Barra_De_Menu_Formulario_Formulario(Me.BindingSource_RESOVALO_1.Count, Trim(Me.Name), boCONTAGRE, boCONTMODI, boCONTELIM, boCONTCONS, boCONTRECO)

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
            If BindingSource_RESOVALO_1.Count > 0 Then

                Me.lblREVADEPA.Text = CType(fun_Buscar_Lista_Valores_Formulario_Principal_DEPARTAMENTO_Codigo(Me.dgvRESOVALO_1.CurrentRow.Cells("REVADEPA").Value.ToString()), String)
                Me.lblREVAMUNI.Text = CType(fun_Buscar_Lista_Valores_Formulario_Principal_MUNICIPIO_Codigo(Me.dgvRESOVALO_1.CurrentRow.Cells("REVADEPA").Value.ToString(), Me.dgvRESOVALO_1.CurrentRow.Cells("REVAMUNI").Value.ToString()), String)
                Me.lblREVATIRE.Text = CType(fun_Buscar_Lista_Valores_Formulario_Principal_TIPORESO_Codigo(Me.dgvRESOVALO_1.CurrentRow.Cells("REVATIRE").Value.ToString()), String)
                Me.lblREVACLSE.Text = CType(fun_Buscar_Lista_Valores_Formulario_Principal_CLASSECT_Codigo(Me.dgvRESOVALO_1.CurrentRow.Cells("REVACLSE").Value.ToString()), String)
                Me.lblREVAVIGE.Text = CType(fun_Buscar_Lista_Valores_Formulario_Principal_VIGENCIA_Codigo(Me.dgvRESOVALO_1.CurrentRow.Cells("REVAVIGE").Value.ToString()), String)
                Me.lblREVAPROY.Text = CType(fun_Buscar_Lista_Valores_Formulario_Principal_PROYECTO_Codigo(Me.dgvRESOVALO_1.CurrentRow.Cells("REVADEPA").Value.ToString(), Me.dgvRESOVALO_1.CurrentRow.Cells("REVAMUNI").Value.ToString(), Me.dgvRESOVALO_1.CurrentRow.Cells("REVACLSE").Value.ToString(), Me.dgvRESOVALO_1.CurrentRow.Cells("REVAPROY").Value.ToString()), String)

            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub pro_LimpiarCampos()

        Me.lblREVADEPA.Text = ""
        Me.lblREVAMUNI.Text = ""
        Me.lblREVATIRE.Text = ""
        Me.lblREVACLSE.Text = ""
        Me.lblREVAVIGE.Text = ""
        Me.lblREVAPROY.Text = ""

    End Sub

#End Region

#Region "MENU"

    Private Sub cmdAGREGAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAGREGAR.Click
        Try
            frm_insertar_RESOVALO.ShowDialog()
            boCONSULTA = False
            pro_Reconsultar()
            pro_ListaDeValores()

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub cmdELIMINAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdELIMINAR.Click
        Try
            Dim Codigo As String = dgvRESOVALO_1.CurrentRow.Cells(6).Value.ToString()

            If MessageBox.Show("¿ Desea eliminar el registro seleccionado ? " & Chr(Keys.Enter) & Chr(Keys.Enter) & "Nro código : " & Codigo, "Mensaje...", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then
                Dim objdatos As New cla_RESOVALO

                If objdatos.fun_Eliminar_RESOVALO(Integer.Parse(dgvRESOVALO_1.CurrentRow.Cells(0).Value.ToString())) Then
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

            Dim frm_modificar_RESOVALO As New frm_modificar_RESOVALO(Integer.Parse(Me.dgvRESOVALO_1.SelectedRows.Item(0).Cells(0).Value.ToString()))

            frm_modificar_RESOVALO.ShowDialog()
            pro_Reconsultar()
            pro_ListaDeValores()

        Catch ex As Exception
            Dim INCO As New frm_INCO_modifircar_registros_sin_listas_de_valores
            INCO.ShowDialog()
        End Try

    End Sub
    Private Sub cmdCONSULTAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCONSULTAR.Click

        Try
            vp_inConsulta = 0

            frm_consultar_RESOVALO.ShowDialog()

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

    Private Sub frm_RESOVALO_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        pro_Reconsultar()
    End Sub

#End Region

#Region "GotFocus"

    Private Sub frm_RESOVALO_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.GotFocus
        pro_ListaDeValores()
    End Sub
    Private Sub dgvRESOVALO_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvRESOVALO_1.GotFocus, dgvRESOVALO_2.GotFocus
        strBARRESTA.Items(0).Text = dgvRESOVALO_1.AccessibleDescription
    End Sub

#End Region

#Region "KeyDown"

    Private Sub dgvRESOVALO_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgvRESOVALO_1.KeyDown, dgvRESOVALO_2.KeyDown
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
                Dim ContarRegistros As Integer = BindingSource_RESOVALO_1.Count

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
                Dim ContarRegistros As Integer = BindingSource_RESOVALO_1.Count

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

#Region "CellClick"

    Private Sub dgvRESOVALO_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvRESOVALO_1.CellClick, dgvRESOVALO_2.CellClick
        pro_ListaDeValores()
    End Sub

#End Region

#Region "KeyUp"

    Private Sub dgvRESOVALO_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgvRESOVALO_1.KeyUp, dgvRESOVALO_2.KeyUp
        If e.KeyCode = Keys.Down Or e.KeyCode = Keys.Up Or e.KeyCode = Keys.Enter Or e.KeyCode = Keys.PageUp Or e.KeyCode = Keys.PageDown Then
            pro_ListaDeValores()
        End If
    End Sub

#End Region

#End Region

End Class