Imports REGLAS_DEL_NEGOCIO

Public Class frm_RESOLUCION

    '====================================
    ' *** RESOLUCIÓN DE ACTUALIZACIÓN ***
    '====================================

#Region "VARIABLES LOCALES"

    Dim boCONSULTA As Boolean = False

#End Region

#Region "INSTANCIAR FORMULARIO"

    Private Shared frm_Instance = Nothing

    Public Shared Function instance() As frm_RESOLUCION
        If frm_Instance Is Nothing OrElse frm_Instance.isdisposed = True Then
            frm_Instance = New frm_RESOLUCION
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
            Dim objdatos As New cla_RESOLUCION

            If boCONSULTA = False Then
                Me.BindingSource_RESOLUCION_1.DataSource = objdatos.fun_Consultar_RESOLUCION
            Else

            End If

            Me.dgvRESOLUCION_1.DataSource = Me.BindingSource_RESOLUCION_1
            Me.dgvRESOLUCION_2.DataSource = Me.BindingSource_RESOLUCION_1

            Me.BindingNavigator_RESOLUCION_1.BindingSource = Me.BindingSource_RESOLUCION_1

            '==================================================
            '*** CONFUGURA OBJETOS DEL FORMULARIO MAESTRO ***
            '==================================================

            Me.strBARRESTA.Items(2).Text = "Registros : " & BindingSource_RESOLUCION_1.Count

            Me.dgvRESOLUCION_1.Columns("RESOIDRE").Visible = False
            Me.dgvRESOLUCION_1.Columns("RESONURE").Visible = False
            Me.dgvRESOLUCION_1.Columns("RESOARTE").Visible = False
            Me.dgvRESOLUCION_1.Columns("RESOARCO").Visible = False
            Me.dgvRESOLUCION_1.Columns("RESOPUNT").Visible = False
            Me.dgvRESOLUCION_1.Columns("RESOTOPA").Visible = False
            Me.dgvRESOLUCION_1.Columns("RESORESO").Visible = False
            Me.dgvRESOLUCION_1.Columns("RESODEPA").Visible = False
            Me.dgvRESOLUCION_1.Columns("RESOMUNI").Visible = False
            Me.dgvRESOLUCION_1.Columns("RESOTIRE").Visible = False
            Me.dgvRESOLUCION_1.Columns("RESOCLSE").Visible = False
            Me.dgvRESOLUCION_1.Columns("RESOVIGE").Visible = False
            Me.dgvRESOLUCION_1.Columns("RESOESTA").Visible = False
            Me.dgvRESOLUCION_1.Columns("ESTADESC").Visible = False

            Me.dgvRESOLUCION_1.Columns("DEPADESC").HeaderText = "Departamento"
            Me.dgvRESOLUCION_1.Columns("MUNIDESC").HeaderText = "Municipio"
            Me.dgvRESOLUCION_1.Columns("TIREDESC").HeaderText = "Tipo Resolución"
            Me.dgvRESOLUCION_1.Columns("CLSEDESC").HeaderText = "Sector"
            Me.dgvRESOLUCION_1.Columns("VIGEDESC").HeaderText = "Vigencia"
            Me.dgvRESOLUCION_1.Columns("RESOCODI").HeaderText = "Resolución"
            Me.dgvRESOLUCION_1.Columns("RESODESC").HeaderText = "Descripción"

            Me.dgvRESOLUCION_2.Columns("RESOIDRE").Visible = False
            Me.dgvRESOLUCION_2.Columns("RESODEPA").Visible = False
            Me.dgvRESOLUCION_2.Columns("RESOMUNI").Visible = False
            Me.dgvRESOLUCION_2.Columns("RESOTIRE").Visible = False
            Me.dgvRESOLUCION_2.Columns("RESOCLSE").Visible = False
            Me.dgvRESOLUCION_2.Columns("RESOVIGE").Visible = False
            Me.dgvRESOLUCION_2.Columns("RESOCODI").Visible = False
            Me.dgvRESOLUCION_2.Columns("RESODESC").Visible = False
            Me.dgvRESOLUCION_2.Columns("DEPADESC").Visible = False
            Me.dgvRESOLUCION_2.Columns("MUNIDESC").Visible = False
            Me.dgvRESOLUCION_2.Columns("TIREDESC").Visible = False
            Me.dgvRESOLUCION_2.Columns("CLSEDESC").Visible = False
            Me.dgvRESOLUCION_2.Columns("VIGEDESC").Visible = False
            Me.dgvRESOLUCION_2.Columns("RESOESTA").Visible = False
            Me.dgvRESOLUCION_2.Columns("ESTADESC").Visible = True

            Me.dgvRESOLUCION_2.Columns("RESONURE").HeaderText = "Nro de registros"
            Me.dgvRESOLUCION_2.Columns("RESOARTE").HeaderText = "Área de terreno"
            Me.dgvRESOLUCION_2.Columns("RESOARCO").HeaderText = "Área de construcción"
            Me.dgvRESOLUCION_2.Columns("RESOPUNT").HeaderText = "Puntos"
            Me.dgvRESOLUCION_2.Columns("RESOTOPA").HeaderText = "Total - Parcial"
            Me.dgvRESOLUCION_2.Columns("RESORESO").HeaderText = "Codigo resolución"
            Me.dgvRESOLUCION_2.Columns("ESTADESC").HeaderText = "Estado"

            Me.dgvRESOLUCION_1.Columns("RESODESC").Width = 350

            Me.dgvRESOLUCION_2.Columns("RESONURE").DefaultCellStyle.Format = "n"
            Me.dgvRESOLUCION_2.Columns("RESOARTE").DefaultCellStyle.Format = "n"
            Me.dgvRESOLUCION_2.Columns("RESOARCO").DefaultCellStyle.Format = "n"
            Me.dgvRESOLUCION_2.Columns("RESOPUNT").DefaultCellStyle.Format = "n"

            Me.dgvRESOLUCION_2.Columns("RESONURE").DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopRight
            Me.dgvRESOLUCION_2.Columns("RESOARTE").DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopRight
            Me.dgvRESOLUCION_2.Columns("RESOARCO").DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopRight
            Me.dgvRESOLUCION_2.Columns("RESOPUNT").DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopRight



            '==================================================
            '*** ASIGNA LOS PRIVILEGIOS DE LA BARRA DE MENU ***
            '==================================================

            Dim boCONTAGRE As Boolean = False
            Dim boCONTMODI As Boolean = False
            Dim boCONTELIM As Boolean = False
            Dim boCONTCONS As Boolean = False
            Dim boCONTRECO As Boolean = False

            pro_Permiso_Barra_De_Menu_Formulario_Formulario(Me.BindingSource_RESOLUCION_1.Count, Trim(Me.Name), boCONTAGRE, boCONTMODI, boCONTELIM, boCONTCONS, boCONTRECO)

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
            If BindingSource_RESOLUCION_1.Count > 0 Then

                Me.lblRESODEPA.Text = CType(fun_Buscar_Lista_Valores_Formulario_Principal_DEPARTAMENTO_Codigo(Me.dgvRESOLUCION_1.CurrentRow.Cells("RESODEPA").Value.ToString()), String)
                Me.lblRESOMUNI.Text = CType(fun_Buscar_Lista_Valores_Formulario_Principal_MUNICIPIO_Codigo(Me.dgvRESOLUCION_1.CurrentRow.Cells("RESODEPA").Value.ToString(), Me.dgvRESOLUCION_1.CurrentRow.Cells("RESOMUNI").Value.ToString()), String)
                Me.lblRESOTIRE.Text = CType(fun_Buscar_Lista_Valores_Formulario_Principal_TIPORESO_Codigo(Me.dgvRESOLUCION_1.CurrentRow.Cells("RESOTIRE").Value.ToString()), String)
                Me.lblRESOCLSE.Text = CType(fun_Buscar_Lista_Valores_Formulario_Principal_CLASSECT_Codigo(Me.dgvRESOLUCION_1.CurrentRow.Cells("RESOCLSE").Value.ToString()), String)
                Me.lblRESOVIGE.Text = CType(fun_Buscar_Lista_Valores_Formulario_Principal_VIGENCIA_Codigo(Me.dgvRESOLUCION_1.CurrentRow.Cells("RESOVIGE").Value.ToString()), String)
                Me.chkRESOPATO.Checked = CType(fun_Buscar_Lista_Valores_BOOLEAN(Me.dgvRESOLUCION_1.CurrentRow.Cells("RESOTOPA").Value.ToString()), Boolean)
                Me.lblRESOCODI.Text = CType(fun_Buscar_Lista_Valores_STRING(Me.dgvRESOLUCION_1.CurrentRow.Cells("RESOCODI").Value.ToString()), String)

            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub pro_LimpiarCampos()

        Me.lblRESODEPA.Text = ""
        Me.lblRESOMUNI.Text = ""
        Me.lblRESOTIRE.Text = ""
        Me.lblRESOCLSE.Text = ""
        Me.lblRESOVIGE.Text = ""
        Me.lblRESOCODI.Text = ""
        Me.chkRESOPATO.Checked = False

    End Sub

#End Region

#Region "MENU"

    Private Sub cmdAGREGAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAGREGAR.Click
        Try
            frm_insertar_RESOLUCION.ShowDialog()
            boCONSULTA = False
            pro_Reconsultar()
            pro_ListaDeValores()

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub cmdELIMINAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdELIMINAR.Click
        Try
            Dim Codigo As String = dgvRESOLUCION_1.CurrentRow.Cells(6).Value.ToString()

            If MessageBox.Show("¿ Desea eliminar el registro seleccionado ? " & Chr(Keys.Enter) & Chr(Keys.Enter) & "Nro código : " & Codigo, "Mensaje...", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then
                Dim objdatos As New cla_RESOLUCION

                If objdatos.fun_Eliminar_RESOLUCION(Integer.Parse(dgvRESOLUCION_1.CurrentRow.Cells(0).Value.ToString())) Then
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

            Dim frm_modificar_RESOLUCION As New frm_modificar_RESOLUCION(Integer.Parse(dgvRESOLUCION_1.CurrentRow.Cells(0).Value.ToString()))

            frm_modificar_RESOLUCION.ShowDialog()
            pro_Reconsultar()
            pro_ListaDeValores()

        Catch ex As Exception
            Dim INCO As New frm_INCO_modifircar_registros_sin_listas_de_valores
            INCO.ShowDialog()
        End Try

    End Sub
    Private Sub cmdCONSULTAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCONSULTAR.Click

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

    Private Sub frm_RESOLUCION_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        pro_Reconsultar()
    End Sub

#End Region

#Region "GotFocus"

    Private Sub frm_RESOLUCION_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.GotFocus
        pro_ListaDeValores()
    End Sub
    Private Sub dgvRESOLUCION_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvRESOLUCION_1.GotFocus, dgvRESOLUCION_2.GotFocus
        strBARRESTA.Items(0).Text = dgvRESOLUCION_1.AccessibleDescription
    End Sub

#End Region

#Region "KeyDown"

    Private Sub dgvRESOLUCION_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgvRESOLUCION_1.KeyDown, dgvRESOLUCION_2.KeyDown
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
                Dim ContarRegistros As Integer = BindingSource_RESOLUCION_1.Count

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
                Dim ContarRegistros As Integer = BindingSource_RESOLUCION_1.Count

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

    Private Sub dgvRESOLUCION_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvRESOLUCION_1.CellClick, dgvRESOLUCION_2.CellClick
        pro_ListaDeValores()
    End Sub

#End Region

#Region "KeyUp"

    Private Sub dgvRESOLUCION_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgvRESOLUCION_1.KeyUp, dgvRESOLUCION_2.KeyUp
        If e.KeyCode = Keys.Down Or e.KeyCode = Keys.Up Or e.KeyCode = Keys.Enter Or e.KeyCode = Keys.PageUp Or e.KeyCode = Keys.PageDown Then
            pro_ListaDeValores()
        End If
    End Sub

#End Region

#End Region

End Class