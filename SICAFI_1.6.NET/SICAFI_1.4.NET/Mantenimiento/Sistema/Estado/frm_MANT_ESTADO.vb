Public Class frm_MANT_ESTADO

    '============================
    '*** MANTENIMIENTO ESTADO ***
    '============================

#Region "PROCEDIMIENTOS"

    Private Sub pro_Reconsultar()

        Dim objdatos As New cla_ESTADO

        BindingSource_ESTADO_1.DataSource = objdatos.fun_Consultar_ESTADO
        dgvESTAESTA.DataSource = BindingSource_ESTADO_1
        BindingNavigator_ESTADO_1.BindingSource = BindingSource_ESTADO_1

        strBARRESTA.Items(2).Text = "Registros: " & BindingSource_ESTADO_1.Count

        'Como quitar columnas?
        dgvESTAESTA.Columns(0).Visible = False

        'Manejo del boton modificar al tener o no registros en el BindingSource
        Dim ContarRegistros As Integer = BindingSource_ESTADO_1.Count

        If ContarRegistros = 0 Then
            cmdMODIFICAR.Enabled = False
            cmdELIMINAR.Enabled = False
        Else
            cmdMODIFICAR.Enabled = True
            cmdELIMINAR.Enabled = True
        End If


    End Sub

#End Region

#Region "MENU"

    Private Sub cmdAGREGAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAGREGAR.Click
        frm_insertar_ESTADO.ShowDialog()
        pro_Reconsultar()

    End Sub

    Private Sub cmdELIMINAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdELIMINAR.Click
        Try
            Dim Codigo As String = dgvESTAESTA.CurrentRow.Cells(1).Value.ToString()

            If MessageBox.Show("¿ Desea eliminar el registro seleccionado ? " & Chr(Keys.Enter) & Chr(Keys.Enter) & "Nro código : " & Codigo, "Mansaje", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then
                Dim contrasena As String

                contrasena = InputBox("Favor ingrese la contraseña para autorizar la eliminación del registro", "Mensaje")
                contrasena = contrasena.ToUpper

                If Trim(contrasena) <> "" Then
                    If contrasena = ClaveEliminar Then
                        Dim objdatos As New cla_ESTADO

                        objdatos.fun_Eliminar_ESTADO(Integer.Parse(dgvESTAESTA.CurrentRow.Cells(0).Value.ToString()))
                        pro_Reconsultar()
                    Else
                        MessageBox.Show("Constraseña incorrecta", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                    End If
                Else
                    MessageBox.Show("Favor Ingrese la constraseña", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try
    End Sub
    Private Sub cmdMODIFICAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdMODIFICAR.Click
        Try

            Dim frm_modificar_ESTADO As New frm_modificar_ESTADO(Integer.Parse(dgvESTAESTA.CurrentRow.Cells(0).Value.ToString()))

            frm_modificar_ESTADO.ShowDialog()

            pro_Reconsultar()

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub cmdSALIR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSALIR.Click
        Me.Close()
    End Sub

#End Region

#Region "FORMULARIO"

    Private Sub frm_Mantenimiento_FPPRTIDO_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        pro_Reconsultar()

    End Sub

    Private Sub dgvESTAESTA_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgvESTAESTA.KeyDown
        '===============================================================================================
        '*** INSERTAR REGISTROS ***
        '===============================================================================================

        If e.KeyCode = Keys.F2 Then
            Call cmdAGREGAR_Click(cmdAGREGAR, New System.EventArgs)
            pro_Reconsultar()
        End If

        '===============================================================================================
        'MODIFICAR REGISTROS
        '===============================================================================================

        If e.KeyCode = Keys.F3 Then
            Call cmdMODIFICAR_Click(cmdMODIFICAR, New System.EventArgs)
            pro_Reconsultar()
        End If

        '===============================================================================================
        '*** ELIMINAR REGISTROS ***
        '===============================================================================================

        If e.KeyCode = Keys.Delete Then
            Call cmdELIMINAR_Click(cmdELIMINAR, New System.EventArgs)
            pro_Reconsultar()
        End If

    End Sub

    Private Sub dgvESTAESTA_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvESTAESTA.GotFocus
        strBARRESTA.Items(0).Text = dgvESTAESTA.AccessibleDescription
    End Sub

    Private Sub dgvESTAESTA_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvESTAESTA.LostFocus
        strBARRESTA.Items(0).Text = ""
        strBARRESTA.Items(1).Text = ""
    End Sub

#End Region


End Class