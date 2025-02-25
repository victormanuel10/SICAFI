Imports REGLAS_DEL_NEGOCIO

Public Class frm_USUARIO

    '==========================
    '*** FORMULARIO USUARIO ***
    '==========================

#Region "INSTANCIAR FORMULARIO"

    Private Shared frm_Instance = Nothing

    Public Shared Function instance() As frm_USUARIO
        If frm_Instance Is Nothing OrElse frm_Instance.isdisposed = True Then
            frm_Instance = New frm_USUARIO
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

            Dim objdatos As New cla_USUARIO

            BindingSource_USUARIO_1.DataSource = objdatos.fun_Consultar_USUARIO
            dgvUSUARIO.DataSource = BindingSource_USUARIO_1
            BindingNavigator_USUARIO_1.BindingSource = BindingSource_USUARIO_1

            strBARRESTA.Items(2).Text = "Registros : " & BindingSource_USUARIO_1.Count

            'Oculta la columna del DataGridView
            dgvUSUARIO.Columns(0).Visible = False
            dgvUSUARIO.Columns(1).Visible = False
            dgvUSUARIO.Columns(2).Visible = False

            'Manejo del boton modificar al tener o no registros en el BindingSource
            Dim ContarRegistros As Integer = BindingSource_USUARIO_1.Count

            '==================================================
            '*** ASIGNA LOS PRIVILEGIOS DE LA BARRA DE MENU ***
            '==================================================

            Dim objdatos1 As New cla_CONTRASENA
            Dim tbl1 As New DataTable

            tbl1 = objdatos1.fun_Buscar_USUARIO_CONTRASENA(vp_usuario)

            Dim boCONTAGRE As Boolean = Trim(tbl1.Rows(0).Item(5))
            Dim boCONTMODI As Boolean = Trim(tbl1.Rows(0).Item(6))
            Dim boCONTELIM As Boolean = Trim(tbl1.Rows(0).Item(7))

            If boCONTAGRE = True Then
                cmdAGREGAR.Enabled = True
            Else
                cmdAGREGAR.Enabled = False
            End If

            If ContarRegistros = 0 Then
                cmdMODIFICAR.Enabled = False
            Else
                If boCONTMODI = True Then
                    cmdMODIFICAR.Enabled = True
                Else
                    cmdMODIFICAR.Enabled = False
                End If
            End If

            If ContarRegistros = 0 Then
                cmdELIMINAR.Enabled = False
            Else
                If boCONTELIM = True Then
                    cmdELIMINAR.Enabled = True
                Else
                    cmdELIMINAR.Enabled = False
                End If
            End If

            If ContarRegistros = 0 Then
                cmdCONSULTAR.Enabled = False
                cmdRECONSULTAR.Enabled = False
            Else
                cmdCONSULTAR.Enabled = True
                cmdRECONSULTAR.Enabled = True
            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub pro_inicializarControles()
        '=========================================
        ' CARGA LOS COMBOBOX CON LOS DATOS ACTIVOS
        '=========================================

        Dim objdatos7 As New cla_ESTADO

        cboUSUAESTA.DataSource = objdatos7.fun_Consultar_TODOS_LOS_ESTADOS
        cboUSUAESTA.DisplayMember = "ESTADESC"
        cboUSUAESTA.ValueMember = "ESTACODI"

    End Sub
    Private Sub pro_ListaDeValores()
        '============================================================
        'Verifica si existen registros para traer la lista de valores
        '============================================================
        Dim ContarRegistros As Integer = BindingSource_USUARIO_1.Count

        If ContarRegistros > 0 Then

            '=============================================
            'Limpia los campos si no encuentra registro ID
            '=============================================
            Try
                If (dgvUSUARIO.CurrentRow.Cells(0).Value.ToString()) = "" Then
                    pro_LimpiarCampos()
                End If

            Catch ex As Exception
                MessageBox.Show(Err.Description & "1")
            End Try

            '=============================
            'Carga los datos en los campos
            '=============================

            If (dgvUSUARIO.CurrentRow.Cells(0).Value.ToString()) <> "" Then

                Dim objdatos As New cla_USUARIO
                Dim tbl As New DataTable

                Dim id As Integer = (Integer.Parse(dgvUSUARIO.CurrentRow.Cells(0).Value.ToString()))

                tbl = objdatos.fun_Buscar_ID_USUARIO(id)

                txtUSUANUDO.Text = Trim(tbl.Rows(0).Item(1))
                txtUSUATIDO.Text = Trim(tbl.Rows(0).Item(2))
                txtUSUACAPR.Text = Trim(tbl.Rows(0).Item(3))
                txtUSUASEXO.Text = Trim(tbl.Rows(0).Item(4))
                txtUSUANOMB.Text = Trim(tbl.Rows(0).Item(5))
                txtUSUAPRAP.Text = Trim(tbl.Rows(0).Item(6))
                txtUSUASEAP.Text = Trim(tbl.Rows(0).Item(7))
                txtUSUASICO.Text = Trim(tbl.Rows(0).Item(8))
                txtUSUATEL1.Text = Trim(tbl.Rows(0).Item(9))
                txtUSUATEL2.Text = Trim(tbl.Rows(0).Item(10))
                txtUSUAFAX1.Text = Trim(tbl.Rows(0).Item(11))
                txtUSUADIRE.Text = Trim(tbl.Rows(0).Item(12))
                cboUSUAESTA.SelectedValue = tbl.Rows(0).Item(13)
                txtUSUAUSIN.Text = Trim(tbl.Rows(0).Item(14))
                txtUSUAUSMO.Text = Trim(tbl.Rows(0).Item(15))
                txtUSUAFEIN.Text = Trim(tbl.Rows(0).Item(16))
                txtUSUAFEMO.Text = Trim(tbl.Rows(0).Item(17))
                txtUSUAOBSE.Text = Trim(tbl.Rows(0).Item(18))

            End If

            '===========================================
            'CARGA LA DESCRIPCIÓN DE LA LISTA DE VALORES
            '===========================================

            Try
                If (dgvUSUARIO.CurrentRow.Cells(0).Value.ToString()) <> "" Then

                    Dim objdatos3 As New cla_TIPODOCU
                    Dim tbl3 As New DataTable
                    Dim idTipo As Integer = Val(txtUSUATIDO.Text) '(Integer.Parse(dgvUSUARIO.CurrentRow.Cells(3).Value.ToString()))

                    tbl3 = objdatos3.fun_Buscar_CODIGO_MANT_TIPODOCU(idTipo)

                    Dim sw3, j3 As Integer

                    While j3 < tbl3.Rows.Count And sw3 = 0
                        If idTipo = tbl3.Rows(j3).Item("TIDOCODI") Then
                            lblUSUATIDO.Text = tbl3.Rows(j3).Item("TIDODESC")
                            sw3 = 1
                        Else
                            j3 = j3 + 1
                        End If
                    End While


                End If

            Catch ex As Exception
                MessageBox.Show(Err.Description & "3")
            End Try


            '=================================================
            'Carga la descripción de la calidad de propietario
            '=================================================
            Try
                If (dgvUSUARIO.CurrentRow.Cells(0).Value.ToString()) <> "" Then

                    Dim objdatos1 As New cla_CALIPROP
                    Dim tbl1 As New DataTable
                    Dim idCalidadPropietario As Integer = Val(txtUSUACAPR.Text)

                    tbl1 = objdatos1.fun_Buscar_CODIGO_MANT_CALIPROP(idCalidadPropietario)

                    Dim sw1, j1 As Integer

                    While j1 < tbl1.Rows.Count And sw1 = 0
                        If idCalidadPropietario = tbl1.Rows(j1).Item("CAPRCODI") Then
                            lblUSUACAPR.Text = tbl1.Rows(j1).Item("CAPRDESC")
                            sw1 = 1
                        Else
                            j1 = j1 + 1
                        End If
                    End While

                End If

            Catch ex As Exception
                MessageBox.Show(Err.Description & "1")
            End Try


            '=============================
            'Carga la descripción del sexo
            '=============================
            Try
                If (dgvUSUARIO.CurrentRow.Cells(0).Value.ToString()) <> "" Then

                    Dim objdatos2 As New cla_SEXO
                    Dim tbl2 As New DataTable
                    Dim idSexo As Integer = Val(txtUSUASEXO.Text)

                    tbl2 = objdatos2.fun_Buscar_CODIGO_MANT_SEXO(idSexo)

                    Dim sw2, j2 As Integer

                    While j2 < tbl2.Rows.Count And sw2 = 0
                        If idSexo = tbl2.Rows(j2).Item("SEXOCODI") Then
                            lblUSUASEXO.Text = tbl2.Rows(j2).Item("SEXODESC")
                            sw2 = 1
                        Else
                            j2 = j2 + 1
                        End If
                    End While

                End If

            Catch ex As Exception
                MessageBox.Show(Err.Description & "2")
            End Try

            If Trim(txtUSUAUSMO.Text) = "" Then
                txtUSUAFEMO.Text = ""
            End If

        End If
    End Sub
    Private Sub pro_LimpiarCampos()

        txtUSUANUDO.Text = ""
        txtUSUATIDO.Text = ""
        lblUSUATIDO.Text = ""
        txtUSUACAPR.Text = ""
        lblUSUACAPR.Text = ""
        txtUSUASEXO.Text = ""
        lblUSUASEXO.Text = ""
        txtUSUANOMB.Text = ""
        txtUSUAPRAP.Text = ""
        txtUSUASEAP.Text = ""
        txtUSUASICO.Text = ""
        txtUSUATEL1.Text = ""
        txtUSUATEL2.Text = ""
        txtUSUAFAX1.Text = ""
        txtUSUADIRE.Text = ""
        cboUSUAESTA.Text = ""
        txtUSUAUSIN.Text = ""
        txtUSUAUSMO.Text = ""
        txtUSUAFEIN.Text = ""
        txtUSUAFEMO.Text = ""
        txtUSUAOBSE.Text = ""

    End Sub

#End Region

#Region "MENU"

    Private Sub cmdAGREGAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAGREGAR.Click
        Try
            frm_insertar_USUARIO.ShowDialog()
            pro_Reconsultar()
            pro_ListaDeValores()

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try
       

    End Sub
    Private Sub cmdELIMINAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdELIMINAR.Click
        Try
            Dim Codigo As String = dgvUSUARIO.CurrentRow.Cells(4).Value.ToString()

            If MessageBox.Show("¿ Desea eliminar el registro seleccionado ? " & Chr(Keys.Enter) & Chr(Keys.Enter) & "Nro documento : " & Codigo, "Mensaje...", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then
                Dim objdatos As New cla_USUARIO

                If objdatos.fun_Eliminar_USUARIO(Integer.Parse(dgvUSUARIO.CurrentRow.Cells(0).Value.ToString())) Then
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

            Dim frm_modificar As New frm_modificar_USUARIO(Integer.Parse(dgvUSUARIO.CurrentRow.Cells(0).Value.ToString()))

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

    Private Sub frm_USUARIO_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        pro_Reconsultar()
        pro_inicializarControles()
    End Sub
    Private Sub frm_USUARIO_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.GotFocus
        pro_ListaDeValores()
    End Sub

    Private Sub dgvUSUARIO_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgvUSUARIO.KeyDown
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
                Dim ContarRegistros As Integer = BindingSource_USUARIO_1.Count

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
                Dim ContarRegistros As Integer = BindingSource_USUARIO_1.Count

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
    Private Sub dgvUSUARIO_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvUSUARIO.GotFocus
        strBARRESTA.Items(0).Text = dgvUSUARIO.AccessibleDescription
    End Sub
    Private Sub dgvUSUARIO_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgvUSUARIO.KeyUp
        If e.KeyCode = Keys.Down Or e.KeyCode = Keys.Up Or e.KeyCode = Keys.Enter Or e.KeyCode = Keys.PageUp Or e.KeyCode = Keys.PageDown Then
            pro_ListaDeValores()
        End If

    End Sub
    Private Sub dgvUSUARIO_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvUSUARIO.CellClick
        pro_ListaDeValores()

    End Sub

#End Region


   
End Class