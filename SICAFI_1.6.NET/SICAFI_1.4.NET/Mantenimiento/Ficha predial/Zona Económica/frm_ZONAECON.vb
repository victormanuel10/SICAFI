Imports REGLAS_DEL_NEGOCIO

Public Class frm_ZONAECON

    '====================================
    '*** MANTENIMIENTO ZONA ECONÓMICA ***
    '====================================

#Region "VARIABLES LOCALES"

    Dim boCONSULTA As Boolean = False

#End Region

#Region "INSTANCIAR FORMULARIO"

    Private Shared frm_Instance = Nothing

    Public Shared Function instance() As frm_ZONAECON
        If frm_Instance Is Nothing OrElse frm_Instance.isdisposed = True Then
            frm_Instance = New frm_ZONAECON
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

            Dim objdatos As New cla_ZONAECON

            If boCONSULTA = False Then
                Me.BindingSource_ZONAECON_1.DataSource = objdatos.fun_Consultar_MANT_ZONAECON
            Else

            End If

            Me.dgvZOECZOEC.DataSource = BindingSource_ZONAECON_1
            Me.BindingNavigator_ZONAECON_1.BindingSource = BindingSource_ZONAECON_1

            '==================================================
            '*** CONFIGURA OBJETOS DEL FORMULARIO MAESTRO ***
            '==================================================

            Me.strBARRESTA.Items(2).Text = "Registros : " & BindingSource_ZONAECON_1.Count
            Me.dgvZOECZOEC.Columns(0).Visible = False

            Me.dgvZOECZOEC.Columns(5).Width = 150

            Me.dgvZOECZOEC.Columns(6).DefaultCellStyle.Format = "c"
            Me.dgvZOECZOEC.Columns(10).DefaultCellStyle.Format = "c"

            '==================================================
            '*** ASIGNA LOS PRIVILEGIOS DE LA BARRA DE MENU ***
            '==================================================

            Dim ContarRegistros As Integer = BindingSource_ZONAECON_1.Count

            Dim boCONTAGRE As Boolean = False
            Dim boCONTMODI As Boolean = False
            Dim boCONTELIM As Boolean = False
            Dim boCONTCONS As Boolean = False
            Dim boCONTRECO As Boolean = False

            pro_Permiso_Barra_De_Menu_Formulario_Formulario(ContarRegistros, Trim(Me.Name), boCONTAGRE, boCONTMODI, boCONTELIM, boCONTCONS, boCONTRECO)

            cmdAGREGAR.Enabled = boCONTAGRE
            cmdMODIFICAR.Enabled = boCONTMODI
            cmdELIMINAR.Enabled = boCONTELIM
            cmdCONSULTAR.Enabled = boCONTCONS
            cmdRECONSULTAR.Enabled = boCONTRECO

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub pro_ListaDeValores()

        Dim ContarRegistros As Integer = BindingSource_ZONAECON_1.Count

        If ContarRegistros > 0 Then

            '===========================================
            'CARGA LA DESCRIPCION DE LA LISTA DE VALORES
            '===========================================
            Try
                lblZOECDEPA.Text = CType(fun_Buscar_Lista_Valores_DEPARTAMENTO(dgvZOECZOEC.CurrentRow.Cells(1).Value.ToString()), String)
                lblZOECMUNI.Text = CType(fun_Buscar_Lista_Valores_MUNICIPIO(dgvZOECZOEC.CurrentRow.Cells(1).Value.ToString(), dgvZOECZOEC.CurrentRow.Cells(2).Value.ToString()), String)
                lblZOECCLSE.Text = CType(fun_Buscar_Lista_Valores_CLASSECT(dgvZOECZOEC.CurrentRow.Cells(3).Value.ToString()), String)

            Catch ex As Exception
                MessageBox.Show(Err.Description & "3")
            End Try

        End If

    End Sub
    Private Sub pro_LimpiarCampos()
        lblZOECMUNI.Text = ""
        lblZOECDEPA.Text = ""
        lblZOECCLSE.Text = ""
    End Sub

#End Region

#Region "MENU"

    Private Sub cmdAGREGAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAGREGAR.Click
        Try
            frm_insertar_ZONAECON.ShowDialog()
            boCONSULTA = False
            pro_Reconsultar()
            pro_ListaDeValores()

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try
      

    End Sub
    Private Sub cmdELIMINAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdELIMINAR.Click
        Try
            Dim Codigo As Integer = (Integer.Parse(dgvZOECZOEC.CurrentRow.Cells(4).Value.ToString()))

            If MessageBox.Show("¿ Desea eliminar el registro seleccionado ? " & Chr(Keys.Enter) & Chr(Keys.Enter) & "Nro código : " & Codigo, "Mensaje...", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then
                     Dim objdatos As New cla_ZONAECON

                If objdatos.fun_Eliminar_MANT_ZONAECON(Integer.Parse(dgvZOECZOEC.CurrentRow.Cells(0).Value.ToString())) Then
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
            Dim frm_modificar As New frm_modificar_ZONAECON(Integer.Parse(dgvZOECZOEC.CurrentRow.Cells(0).Value.ToString()))

            frm_modificar.ShowDialog()
            pro_Reconsultar()
            pro_ListaDeValores()

        Catch ex As Exception
            frm_INCO_modifircar_registros_sin_listas_de_valores.ShowDialog()
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

    Private Sub frm_ZONAECON_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        pro_Reconsultar()
    End Sub

#End Region
   
#Region "GotFocus"

    Private Sub frm_ZONAECON_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.GotFocus
        pro_ListaDeValores()
    End Sub
    Private Sub dgvZOECZOEC_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvZOECZOEC.GotFocus
        strBARRESTA.Items(0).Text = dgvZOECZOEC.AccessibleDescription
    End Sub

#End Region
   
#Region "KeyDown"

    Private Sub dgvZOECZOEC_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgvZOECZOEC.KeyDown
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
                Dim ContarRegistros As Integer = BindingSource_ZONAECON_1.Count

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
                Dim ContarRegistros As Integer = BindingSource_ZONAECON_1.Count

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

    Private Sub dgvZOECZOEC_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgvZOECZOEC.KeyUp
        If e.KeyCode = Keys.Down Or e.KeyCode = Keys.Up Or e.KeyCode = Keys.Enter Or e.KeyCode = Keys.PageUp Or e.KeyCode = Keys.PageDown Then
            pro_ListaDeValores()
        End If
    End Sub

#End Region

#Region "CellClick"

    Private Sub dgvZOECZOEC_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvZOECZOEC.CellClick
        pro_ListaDeValores()
    End Sub

#End Region

#End Region

End Class