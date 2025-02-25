Imports REGLAS_DEL_NEGOCIO

Public Class frm_consultar_DEPARTAMENTO

    '=============================
    '*** CONSULTA DEPARTAMENTO ***
    '=============================

#Region "PROCEDIMIENTOS"

    Private Sub pro_LimpiarCampos()
        txtDEPACODI.Text = ""

    End Sub

#End Region

#Region "MENU"

    Private Sub cmdCONSULTAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCONSULTAR.Click
        Try
            Dim objdatos1 As New cla_DEPARTAMENTO
            Dim tbl_Consulta1 As New DataTable
            Dim tbl_Consulta2 As New DataTable

            tbl_Consulta1 = objdatos1.fun_Buscar_CODIGO_MANT_DEPARTAMENTO(txtDEPACODI.Text)

            If tbl_Consulta1.Rows.Count > 0 Then
                Dim inConsulta As Integer = Trim(tbl_Consulta1.Rows(0).Item(0))

                Dim frm_consulta_DEPARTAMENTO As New frm_DEPARTAMENTO(Val(inConsulta))
                txtDEPACODI.Focus()
                Me.Close()
            Else
                mod_MENSAJE.No_Se_Encontro_Ningun_registro()
                txtDEPACODI.Focus()
            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "Consultar")
        End Try

    End Sub
    Private Sub cmdCANCELAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSALIR.Click
        txtDEPACODI.Focus()
        Me.Close()
    End Sub

#End Region

#Region "FORMULARIO"

    Private Sub frm_consultar_DEPARTAMENTO_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        pro_LimpiarCampos()
        txtDEPACODI.Focus()

    End Sub

    Private Sub txtDEPARTAMENTO_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtDEPACODI.KeyPress

        If Not Char.IsNumber(e.KeyChar) Then
            If e.KeyChar <> Convert.ToChar(Keys.Back) Then
                If e.KeyChar <> Convert.ToChar(Keys.Enter) Then
                    e.Handled = True
                    mod_MENSAJE.Inco_Valo_Nume()
                Else
                    cmdCONSULTAR.Focus()
                End If
            End If
        End If

    End Sub

    Private Sub txtDEPARTAMENTO_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtDEPACODI.GotFocus
        txtDEPACODI.SelectionStart = 0
        txtDEPACODI.SelectionLength = Len(txtDEPACODI.Text)
        strBARRESTA.Items(0).Text = txtDEPACODI.AccessibleDescription
    End Sub
    Private Sub cmdCONSULTAR_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdCONSULTAR.GotFocus
        strBARRESTA.Items(0).Text = cmdCONSULTAR.AccessibleDescription
    End Sub
    Private Sub cmdCANCELAR_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdSALIR.GotFocus
        strBARRESTA.Items(0).Text = cmdSALIR.AccessibleDescription
    End Sub

#End Region


End Class