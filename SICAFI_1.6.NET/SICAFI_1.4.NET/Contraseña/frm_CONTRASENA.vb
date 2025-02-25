Imports REGLAS_DEL_NEGOCIO

Public Class frm_CONTRASENA

    '================================
    '*** MANTENIMIENTO CONTRASEÑA ***
    '================================

#Region "INSTANCIAR FORMULARIO"

    Private Shared frm_Instance = Nothing

    Public Shared Function instance() As frm_CONTRASENA
        If frm_Instance Is Nothing OrElse frm_Instance.isdisposed = True Then
            frm_Instance = New frm_CONTRASENA
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

        Dim objdatos As New cla_CONTRASENA

        Me.BindingSource_CONTRASENA_1.DataSource = objdatos.fun_Consultar_CONTRASENA
        Me.dgvCONTRASENA.DataSource = BindingSource_CONTRASENA_1
        Me.BindingNavigator_CONTRASENA_1.BindingSource = Me.BindingSource_CONTRASENA_1

        strBARRESTA.Items(2).Text = "Registros : " & Me.BindingSource_CONTRASENA_1.Count

        Me.dgvCONTRASENA.Columns("Sec").Visible = False
        Me.dgvCONTRASENA.Columns("Agregar").Visible = False
        Me.dgvCONTRASENA.Columns("Modificar").Visible = False
        Me.dgvCONTRASENA.Columns("Eliminar").Visible = False

        Dim ContarRegistros As Integer = Me.BindingSource_CONTRASENA_1.Count

        If ContarRegistros > 0 Then
            Me.cmdRESET.Enabled = True
        Else
            Me.cmdRESET.Enabled = False
        End If

        '==================================================
        '*** ASIGNA LOS PRIVILEGIOS DE LA BARRA DE MENU ***
        '==================================================

        Dim boCONTAGRE, boCONTMODI, boCONTELIM, boCONTCONS, boCONTRECO As Boolean

        pro_Permiso_Barra_De_Menu_Formulario_Formulario(ContarRegistros, Trim(Me.Name), boCONTAGRE, boCONTMODI, boCONTELIM, boCONTCONS, boCONTRECO)

        Me.cmdAGREGAR.Enabled = boCONTAGRE
        Me.cmdMODIFICAR.Enabled = boCONTMODI
        Me.cmdELIMINAR.Enabled = boCONTELIM

    End Sub
    Private Sub pro_ListaDeValores()

        Dim ContarRegistros As Integer = BindingSource_CONTRASENA_1.Count

        If ContarRegistros > 0 Then

            '=============================================
            'Limpia los campos si no encuentra registro ID
            '=============================================
            Try
                If (dgvCONTRASENA.CurrentRow.Cells(0).Value.ToString()) = "" Then
                    pro_LimpiarCampos()
                End If

            Catch ex As Exception
                MessageBox.Show(Err.Description & "1")
            End Try

            '======================================================
            'Pregunta si la columna esta vacia para que no se 
            'desborde por la consulta de tipo numerico
            '======================================================
            Try
                If (dgvCONTRASENA.CurrentRow.Cells(0).Value.ToString()) <> "" Then

                    Dim objdatos As New cla_USUARIO
                    Dim tbl As New DataTable

                    Dim idNroDocumento As String = (dgvCONTRASENA.CurrentRow.Cells(1).Value.ToString())
                    tbl = objdatos.fun_Buscar_CODIGO_USUARIO(idNroDocumento)

                    Dim nombre As String
                    Dim PrApellido As String
                    Dim SeApellido As String

                    Dim sw, j As Integer

                    While j < tbl.Rows.Count And sw = 0
                        If idNroDocumento = tbl.Rows(j).Item("USUANUDO") Then

                            nombre = Trim(tbl.Rows(j).Item("USUANOMB"))
                            PrApellido = Trim(tbl.Rows(j).Item("USUAPRAP"))
                            SeApellido = Trim(tbl.Rows(j).Item("USUASEAP"))

                            lblCONTNOMB.Text = nombre & " " & PrApellido & " " & SeApellido

                            sw = 1
                        Else
                            j = j + 1
                        End If
                    End While

                End If

            Catch ex As Exception
                MessageBox.Show(Err.Description & "lista de valores")
            End Try

        End If
    End Sub
    Private Sub pro_LimpiarCampos()
        lblCONTNOMB.Text = ""

    End Sub

#End Region

#Region "MENU"

    Private Sub cmdAGREGAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAGREGAR.Click
        frm_insertar_CONTRASENA.ShowDialog()
        pro_Reconsultar()
        pro_ListaDeValores()

    End Sub
    Private Sub cmdELIMINAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdELIMINAR.Click
        Try
            Dim Codigo As String = dgvCONTRASENA.CurrentRow.Cells(1).Value.ToString()

            If MessageBox.Show("¿ Desea eliminar el registro seleccionado ? " & Chr(Keys.Enter) & Chr(Keys.Enter) & "Nro código : " & Codigo, "Mensaje...", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then
               
                    Dim objdatos As New cla_CONTRASENA

                If objdatos.fun_Eliminar_CONTRASENA(Integer.Parse(dgvCONTRASENA.CurrentRow.Cells(0).Value.ToString())) = True Then
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

            Dim frm_modificar_CONTRASENA As New frm_modificar_CONTRASENA(Integer.Parse(dgvCONTRASENA.CurrentRow.Cells(0).Value.ToString()))

            frm_modificar_CONTRASENA.ShowDialog()
            pro_Reconsultar()
            pro_ListaDeValores()

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

    Private Sub frm_CONTRASENA_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        pro_Reconsultar()

    End Sub

    Private Sub frm_CONTRASENA_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.GotFocus
        pro_ListaDeValores()
    End Sub

    Private Sub dgvCONTRASENA_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgvCONTRASENA.KeyDown
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
                Dim ContarRegistros As Integer = BindingSource_CONTRASENA_1.Count

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
                Dim ContarRegistros As Integer = BindingSource_CONTRASENA_1.Count

                If ContarRegistros = 0 Then
                    mod_MENSAJE.No_Existen_Registros_En_Base_De_Datos()
                Else
                    mod_MENSAJE.Usuario_No_Tiene_Permiso_Para_Realizar_La_Operacion()
                End If

            End If
        End If


    End Sub
    Private Sub dgvCONTRASENA_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvCONTRASENA.GotFocus
        strBARRESTA.Items(0).Text = dgvCONTRASENA.AccessibleDescription
    End Sub
    Private Sub dgvCONTRASENA_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvCONTRASENA.CellClick
        pro_ListaDeValores()
    End Sub
    Private Sub dgvCONTRASENA_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgvCONTRASENA.KeyUp
        If e.KeyCode = Keys.Down Or e.KeyCode = Keys.Up Or e.KeyCode = Keys.Enter Or e.KeyCode = Keys.PageUp Or e.KeyCode = Keys.PageDown Then
            pro_ListaDeValores()
        End If
    End Sub

    Private Sub cmdRESET_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdRESET.Click

        Try
            If (dgvCONTRASENA.CurrentRow.Cells(0).Value.ToString()) <> "" Then

                Dim id As Integer = (Integer.Parse(dgvCONTRASENA.CurrentRow.Cells(0).Value.ToString()))

                Dim objdatos2 As New cla_CONTRASENA
                Dim tbl As New DataTable

                tbl = objdatos2.fun_Buscar_ID_CONTRASENA(id)

                Dim stCONTNUDO As String = Trim(tbl.Rows(0).Item(1))
                Dim stCONTUSUA As String = Trim(tbl.Rows(0).Item(2))
                Dim stCONTESTA As String = Trim(tbl.Rows(0).Item(4))
                Dim boCONTAGRE As Boolean = Trim(tbl.Rows(0).Item(5))
                Dim boCONTMODI As Boolean = Trim(tbl.Rows(0).Item(6))
                Dim boCONTELIM As Boolean = Trim(tbl.Rows(0).Item(7))
                Dim boCONTCOFP As Boolean = Trim(tbl.Rows(0).Item(8))
                Dim boCONTCOSI As Boolean = Trim(tbl.Rows(0).Item(9))

                Dim objdatos5 As New cla_CRIPTOLOGIA
                Dim encriptar As String = objdatos5.EncriptarHash(stCONTUSUA)

                Dim objdatos As New cla_CONTRASENA

                Dim Nombre As String = Trim(lblCONTNOMB.Text)

                If MessageBox.Show("¿ Desea retablecer la contraseña del usuario ? " & stCONTNUDO & " " & Nombre, "Mensaje ...", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then
                    MessageBox.Show("Si la constraseña se resetea, esta asume login del usuario como contraseña actual", "Información ...", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)

                    If (objdatos.fun_Actualizar_CONTRASENA(id, stCONTNUDO, stCONTUSUA, encriptar, stCONTESTA, boCONTAGRE, boCONTMODI, boCONTELIM, boCONTCOFP, boCONTCOSI)) Then
                        mod_MENSAJE.Se_Modificaron_Los_Datos_Correctamente()
                    Else
                        mod_MENSAJE.No_Se_Modifico_El_Registro_En_La_Base_De_Datos()
                    End If

                End If
            Else
                MessageBox.Show("No existen registros en base de datos", "Mensaje ...", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description & "Guardar")
        End Try

    End Sub

#End Region


End Class