Imports REGLAS_DEL_NEGOCIO

Public Class frm_TIPOCONS

    '==========================================
    '*** MANTENIMIENTO TIPO DE CONSTRUCCIÓN ***
    '==========================================

#Region "VARIABLES LOCALES"

    Dim boCONSULTA As Boolean = False

#End Region

#Region "INSTANCIAR FORMULARIO"

    Private Shared frm_Instance = Nothing

    Public Shared Function instance() As frm_TIPOCONS
        If frm_Instance Is Nothing OrElse frm_Instance.isdisposed = True Then
            frm_Instance = New frm_TIPOCONS
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

            Dim objdatos As New cla_TIPOCONS

            If boCONSULTA = False Then
                Me.BindingSource_TIPOCONS_1.DataSource = objdatos.fun_Consultar_MANT_TIPOCONS
            Else

            End If

            Me.dgvTICOTICO.DataSource = BindingSource_TIPOCONS_1
            Me.dgvTICOTICO1.DataSource = BindingSource_TIPOCONS_1
            Me.BindingNavigator_TIPOCONS_1.BindingSource = BindingSource_TIPOCONS_1

            '==================================================
            '*** CONFUGURA OBJETOS DEL FORMULARIO MAESTRO ***
            '==================================================

            Me.strBARRESTA.Items(2).Text = "Registros : " & BindingSource_TIPOCONS_1.Count

            Me.dgvTICOTICO.Columns(0).Visible = False
            Me.dgvTICOTICO.Columns(8).Visible = False
            Me.dgvTICOTICO.Columns(9).Visible = False
            Me.dgvTICOTICO.Columns(10).Visible = False
            Me.dgvTICOTICO.Columns(11).Visible = False
            Me.dgvTICOTICO.Columns(12).Visible = False
            Me.dgvTICOTICO.Columns(13).Visible = False
            Me.dgvTICOTICO.Columns(14).Visible = False
            Me.dgvTICOTICO.Columns(15).Visible = False

            Me.dgvTICOTICO1.Columns(0).Visible = False
            Me.dgvTICOTICO1.Columns(1).Visible = False
            Me.dgvTICOTICO1.Columns(2).Visible = False
            Me.dgvTICOTICO1.Columns(3).Visible = False
            Me.dgvTICOTICO1.Columns(4).Visible = False
            Me.dgvTICOTICO1.Columns(5).Visible = False
            Me.dgvTICOTICO1.Columns(6).Visible = False
            Me.dgvTICOTICO1.Columns(7).Visible = False
            Me.dgvTICOTICO1.Columns(8).Visible = True

            Me.dgvTICOTICO.Columns(1).Width = 100
            Me.dgvTICOTICO.Columns(2).Width = 100
            Me.dgvTICOTICO.Columns(3).Width = 100
            Me.dgvTICOTICO.Columns(4).Width = 100
            Me.dgvTICOTICO.Columns(5).Width = 100
            Me.dgvTICOTICO.Columns(6).Width = 100
            Me.dgvTICOTICO.Columns(7).Width = 200

            '==================================================
            '*** ASIGNA LOS PRIVILEGIOS DE LA BARRA DE MENU ***
            '==================================================

            Dim ContarRegistros As Integer = BindingSource_TIPOCONS_1.Count

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

        Dim ContarRegistros As Integer = BindingSource_TIPOCONS_1.Count

        If ContarRegistros > 0 Then

            '================================================
            'BUSCA LAS DESCRIPCIONES DE LAS LISTAS DE VALORES
            '================================================
            Try
                lblTICODEPA.Text = CType(fun_Buscar_Lista_Valores_DEPARTAMENTO(dgvTICOTICO.CurrentRow.Cells(1).Value.ToString()), String)
                lblTICOMUNI.Text = CType(fun_Buscar_Lista_Valores_MUNICIPIO(dgvTICOTICO.CurrentRow.Cells(1).Value.ToString(), dgvTICOTICO.CurrentRow.Cells(2).Value.ToString()), String)
                lblTICOCLCO.Text = CType(fun_Buscar_Lista_Valores_CLASCONS(dgvTICOTICO.CurrentRow.Cells(3).Value.ToString()), String)
                lblTICOCLSE.Text = CType(fun_Buscar_Lista_Valores_CLASSECT(dgvTICOTICO.CurrentRow.Cells(5).Value.ToString()), String)
                chkTICOARCO.Checked = CType(fun_Buscar_Lista_Valores_BOOLEAN(dgvTICOTICO.CurrentRow.Cells(13).Value.ToString()), Boolean)

                '======================================
                'SELECCIONA OPCIONES Y CAJAS DE CHEQUEO
                '======================================

                Dim idTipo As String = (dgvTICOTICO.CurrentRow.Cells(4).Value.ToString())

                If Trim(idTipo) = "R" Then
                    rbdTICOTIPO_R.Checked = True
                ElseIf Trim(idTipo) = "C" Then
                    rbdTICOTIPO_C.Checked = True
                ElseIf Trim(idTipo) = "I" Then
                    rbdTICOTIPO_I.Checked = True
                ElseIf Trim(idTipo) = "O" Then
                    rbdTICOTIPO_O.Checked = True
                Else
                    rbdTICOTIPO_R.Checked = False
                    rbdTICOTIPO_C.Checked = False
                    rbdTICOTIPO_I.Checked = False
                    rbdTICOTIPO_O.Checked = False
                End If

            Catch ex As Exception
                MessageBox.Show(Err.Description)
            End Try

        End If

    End Sub
    Private Sub pro_LimpiarCampos()

        lblTICODEPA.Text = ""
        lblTICOMUNI.Text = ""
        lblTICOCLCO.Text = ""
        lblTICOCLSE.Text = ""
        chkTICOARCO.Checked = False
        rbdTICOTIPO_R.Checked = False
        rbdTICOTIPO_C.Checked = False
        rbdTICOTIPO_I.Checked = False
        rbdTICOTIPO_O.Checked = False

    End Sub

#End Region

#Region "MENU"

    Private Sub cmdAGREGAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAGREGAR.Click
        Try
            frm_insertar_TIPOCONS.ShowDialog()
            pro_Reconsultar()
            pro_ListaDeValores()

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try
      

    End Sub
    Private Sub cmdELIMINAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdELIMINAR.Click
        Try
            Dim Codigo As Integer = (Integer.Parse(dgvTICOTICO.CurrentRow.Cells(1).Value.ToString()))

            If MessageBox.Show("¿ Desea eliminar el registro seleccionado ? " & Chr(Keys.Enter) & Chr(Keys.Enter) & "Nro código : " & Codigo, "Mensaje...", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then
                        Dim objdatos As New cla_TIPOCONS

                If objdatos.fun_Eliminar_MANT_TIPOCONS(Integer.Parse(dgvTICOTICO.CurrentRow.Cells(0).Value.ToString())) Then
                    pro_Reconsultar()
                    pro_LimpiarCampos()
                    pro_ListaDeValores()
                Else
                    frm_INCO_eliminar_registro_padre_con_relación_de_registros_hijos.ShowDialog()
                End If

            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description & "1")
        End Try

    End Sub
    Private Sub cmdMODIFICAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdMODIFICAR.Click
        Try
            Dim frm_modificar_TIPOCONS As New frm_modificar_TIPOCONS(Integer.Parse(dgvTICOTICO.CurrentRow.Cells(0).Value.ToString()))

            frm_modificar_TIPOCONS.ShowDialog()
            pro_Reconsultar()
            pro_ListaDeValores()

        Catch ex As Exception
            MessageBox.Show(Err.Description & "2")
        End Try

    End Sub
    Private Sub cmdCONSULTAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCONSULTAR.Click

    End Sub
    Private Sub cmdRECONSULTAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdRECONSULTAR.Click
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

    Private Sub frm_TIPOCONS_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        pro_Reconsultar()
    End Sub

#End Region
   
#Region "GotFocus"

    Private Sub frm_TIPOCONS_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.GotFocus
        pro_ListaDeValores()
    End Sub
    Private Sub dgvTICOTICO_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvTICOTICO.GotFocus, dgvTICOTICO1.GotFocus
        strBARRESTA.Items(0).Text = dgvTICOTICO.AccessibleDescription
    End Sub

#End Region
   
#Region "KeyDown"

    Private Sub dgvTICOTICO_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgvTICOTICO.KeyDown, dgvTICOTICO1.KeyDown
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
                Dim ContarRegistros As Integer = BindingSource_TIPOCONS_1.Count

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
                Dim ContarRegistros As Integer = BindingSource_TIPOCONS_1.Count

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

    Private Sub dgvTICOTICO_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgvTICOTICO.KeyUp, dgvTICOTICO1.KeyUp
        If e.KeyCode = Keys.Down Or e.KeyCode = Keys.Up Or e.KeyCode = Keys.Enter Or e.KeyCode = Keys.PageUp Or e.KeyCode = Keys.PageDown Then
            pro_ListaDeValores()
        End If
    End Sub

#End Region

#Region "CellClick"

    Private Sub dgvTICOTICO_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvTICOTICO.CellClick, dgvTICOTICO1.CellClick
        pro_ListaDeValores()
    End Sub

#End Region
   
#End Region

End Class