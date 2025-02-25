Imports REGLAS_DEL_NEGOCIO

Public Class frm_insertar_RECLMAFA

    '==================================
    '*** MATERIAL FALTANTE RECLAMOS ***
    '==================================

#Region "VARIABLE"

    Dim inID_REGISTRO As Integer
    Dim vl_stFORMULARIO As String = ""

    ' Crea objeto de columnas y registros
    Dim dt1 As New DataTable
    Dim dr1 As DataRow

#End Region

#Region "CONSTRUCTOR"

    Public Sub New(ByVal inInRegistro As Integer)
        inID_REGISTRO = inInRegistro

        InitializeComponent()
        pro_LimpiarCampos()
        pro_inicializarControles()
    End Sub
    Public Sub New(ByVal inInRegistro As Integer, ByVal stFORMULARIO As String)
        inID_REGISTRO = inInRegistro
        vl_stFORMULARIO = stFORMULARIO

        InitializeComponent()
        pro_LimpiarCampos()
        pro_inicializarControles()
    End Sub

#End Region

#Region "PROCEDIMIENTOS"

    Private Sub pro_LimpiarCampos()

        Me.dgvMATECAMP.DataSource = New DataTable
        Me.dgvMATEFALT.DataSource = New DataTable

        Me.txtREMFFECH.Text = ""
        Me.txtREMFOBSE.Text = ""

    End Sub
    Private Sub pro_inicializarControles()

        Try

            Dim objdatos8 As New cla_MACAFORM
            Dim tbl As New DataTable

            tbl = objdatos8.fun_Buscar_CODIGO_MACAFORM_X_FORMULARIO(Trim(vl_stFORMULARIO))

            If tbl.Rows.Count > 0 Then

                Me.dgvMATECAMP.DataSource = tbl

                Me.dgvMATECAMP.Columns("MACAIDRE").Visible = False
                Me.dgvMATECAMP.Columns("MACAESTA").Visible = False

                Me.dgvMATECAMP.Columns("MACACODI").HeaderText = "Código"
                Me.dgvMATECAMP.Columns("MACADESC").HeaderText = "Descripción"

                Me.dgvMATECAMP.Columns("MACACODI").Width = 25
                Me.dgvMATECAMP.Columns("MACADESC").Width = 250

            End If

            Dim objdatos9 As New cla_RECLMAFA
            Dim tbl9 As New DataTable

            tbl9 = objdatos9.fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_RECLMAFA(inID_REGISTRO)

            If tbl9.Rows.Count > 0 Then

                Me.txtREMFFECH.Text = Trim(tbl9.Rows(0).Item("REMFFECH"))
                'Me.txtREMFOBSE.Text = Trim(tbl9.Rows(0).Item("REMFOBSE").ToString)

                If fun_Verificar_Dato_Fecha_Evento_Validated(Me.txtREMFFECH.Text) = True Then
                    Me.DateTimePicker1.Value = CDate(tbl9.Rows(0).Item("REMFFECH"))
                End If

                ' Crea objeto de columnas y registros
                dt1 = New DataTable

                ' Crea las columnas
                dt1.Columns.Add(New DataColumn("Código", GetType(String)))
                dt1.Columns.Add(New DataColumn("Descripción", GetType(String)))

                Dim i As Integer = 0

                For i = 0 To tbl9.Rows.Count - 1

                    dr1 = dt1.NewRow()

                    dr1("Código") = Trim(tbl9.Rows(i).Item("REMFMACA").ToString)
                    dr1("Descripción") = Trim(tbl9.Rows(i).Item("MACADESC").ToString)

                    dt1.Rows.Add(dr1)

                Next

                Me.dgvMATEFALT.DataSource = dt1

                Me.dgvMATEFALT.Columns("Código").Width = 25
                Me.dgvMATEFALT.Columns("Descripción").Width = 250

            Else

                Me.txtREMFFECH.Text = fun_fecha()

                ' Crea objeto de columnas y registros
                dt1 = New DataTable

                ' Crea las columnas
                dt1.Columns.Add(New DataColumn("Código", GetType(String)))
                dt1.Columns.Add(New DataColumn("Descripción", GetType(String)))

                Me.dgvMATEFALT.DataSource = dt1

                Me.dgvMATEFALT.Columns("Código").Width = 25
                Me.dgvMATEFALT.Columns("Descripción").Width = 250

            End If


        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub

#End Region

#Region "MENU"

    Private Sub cmdGUARDAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGUARDAR.Click

        Try
            ' inserta la observación
            Dim obRECLOBME As New cla_RECLOBMF
            Dim dtRECLOBME As New DataTable

            dtRECLOBME = obRECLOBME.fun_Buscar_CODIGO_X_RECLOBMF(inID_REGISTRO)

            If dtRECLOBME.Rows.Count = 0 Then
                obRECLOBME.fun_Insertar_RECLOBMF(inID_REGISTRO, " Nota ingresada por: " & vp_usuario & " " & fun_fecha() & " : " & Trim(Me.txtREMFOBSE.Text) & ". ")
            Else

                Dim stMAUSOBSE_NUEVA As String = Trim(Me.txtREMFOBSE.Text)
                Dim stMAUSOBSE_ANTERIOR As String = Trim(dtRECLOBME.Rows(0).Item("ROMFOBSE"))

                If Trim(stMAUSOBSE_NUEVA) <> "" Then
                    stMAUSOBSE_ANTERIOR += vbCrLf & " Nota ingresada por: " & vp_usuario & " " & fun_fecha() & " : " & stMAUSOBSE_NUEVA & ". "
                End If

                obRECLOBME.fun_Actualizar_RECLOBMF(inID_REGISTRO, Trim(stMAUSOBSE_ANTERIOR))
            End If

            If Me.dgvMATEFALT.RowCount = 0 Then
                Dim objdatos15 As New cla_RECLMAFA
                objdatos15.fun_Eliminar_SECU_RECLMAFA(inID_REGISTRO)

                mod_MENSAJE.Se_Guardaron_Los_Datos_Correctamente()
                Me.Close()

            Else
                ' elimina los registros
                Dim objdatos11 As New cla_RECLMAFA
                objdatos11.fun_Eliminar_SECU_RECLMAFA(inID_REGISTRO)

                Dim tbl As New DataTable
                tbl = Me.dgvMATEFALT.DataSource

                Dim obj_RECLMAEN As New cla_RECLMAEN
                Dim dt_RECLMAEN As New DataTable

                dt_RECLMAEN = obj_RECLMAEN.fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_RECLMAEN(inID_REGISTRO)

                Dim i As Integer = 0

                For i = 0 To tbl.Rows.Count - 1

                    Dim stCODIGO As String = Trim(tbl.Rows(i).Item("Código").ToString)

                    Dim sw1 As Byte = 0
                    Dim j1 As Integer = 0

                    ' elimina los registros del material de registro
                    While j1 < dt_RECLMAEN.Rows.Count And sw1 = 0
                        If tbl.Rows(i).Item("Código") = dt_RECLMAEN.Rows(j1).Item("REMEMACA") Then
                            sw1 = 1

                            Dim objEliminaMaterialFaltante As New cla_RECLMAEN
                            objEliminaMaterialFaltante.fun_Eliminar_SECU_X_MACA_RECLMAEN(inID_REGISTRO, dt_RECLMAEN.Rows(j1).Item("REMEMACA"))
                        Else
                            j1 = j1 + 1
                        End If
                    End While

                    Dim objdatos12 As New cla_RECLMAFA
                    objdatos12.fun_Insertar_RECLMAFA(inID_REGISTRO, stCODIGO, Me.txtREMFFECH.Text, Me.txtREMFOBSE.Text)

                Next

                mod_MENSAJE.Se_Guardaron_Los_Datos_Correctamente()
                Me.Close()

            End If


        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub cmdCANCELAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSALIR.Click
        Me.dgvMATECAMP.Focus()
        Me.Close()
    End Sub

    Private Sub cmdAGREGAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAGREGAR.Click

        Try
            If Me.dgvMATECAMP.SelectedRows.Count > 0 Then

                Dim stMACACODI As String = Trim(Me.dgvMATECAMP.SelectedRows.Item(0).Cells("MACACODI").Value.ToString)
                Dim stDESCRIPCION As String = Trim(Me.dgvMATECAMP.SelectedRows.Item(0).Cells("MACADESC").Value.ToString)

                Dim tbl As New DataTable

                tbl = Me.dgvMATEFALT.DataSource

                Dim i As Integer = 0
                Dim bySW As Byte = 0

                For i = 0 To tbl.Rows.Count - 1

                    If Trim(tbl.Rows(i).Item("Código").ToString) = Trim(stMACACODI) Then
                        bySW = 1
                    End If

                Next

                If bySW = 1 Then
                    MessageBox.Show("El código ya se encuentra registrado", "Mensaje ...", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1)
                Else
                    dr1 = dt1.NewRow()

                    dr1("Código") = Trim(stMACACODI)
                    dr1("Descripción") = Trim(stDESCRIPCION)

                    dt1.Rows.Add(dr1)
                End If

            Else
                MessageBox.Show("Seleccione un código del material de campo", "Mensaje ...", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub cmdELIMINAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdELIMINAR.Click

        Try
            If Me.dgvMATEFALT.SelectedRows.Count > 0 Then
                Me.dgvMATEFALT.Rows.RemoveAt(Me.dgvMATEFALT.SelectedRows(0).Index)
            Else
                MessageBox.Show("Seleccione un código del material de usuario", "Mensaje ...", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub

#End Region

#Region "FORMULARIO"

#Region "KeyPress"

    Private Sub txt_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtREMFOBSE.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Or e.KeyChar = Convert.ToChar(Keys.Tab) Then
            pp_pro_SaltarCampo()
        End If
    End Sub

#End Region

#Region "KeyDown"

    Private Sub cboTRCACLSE_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgvMATEFALT.KeyDown
        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then

        End If
    End Sub

#End Region

#Region "GotFocus"

    Private Sub txt_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtREMFOBSE.GotFocus, txtREMFFECH.GotFocus
        pp_pro_SobrearCampo(sender)
        pp_pro_DescripcionCampo(Me.strBARRESTA.Items(0), sender)
    End Sub
    Private Sub cmd_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdGUARDAR.GotFocus, cmdSALIR.GotFocus
        pp_pro_DescripcionCampo(Me.strBARRESTA.Items(0), sender)
    End Sub
    Private Sub dgv_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvMATECAMP.GotFocus, dgvMATEFALT.GotFocus
        pp_pro_DescripcionCampo(Me.strBARRESTA.Items(0), sender)
    End Sub

#End Region

#Region "ResizeBegin"

    Private Sub frm_ResizeBegin(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.ResizeBegin
        Me.Opacity = vp_Opacity
    End Sub

#End Region

#Region "ResizeEnd"

    Private Sub frm_ResizeEnd(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.ResizeEnd
        Dim opacity As Double = Convert.ToDouble(100)
        Me.Opacity = opacity
    End Sub

#End Region

#Region "ValueChanged"

    Private Sub DateTimePicker1_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DateTimePicker1.ValueChanged
        Me.txtREMFFECH.Text = Me.DateTimePicker1.Value
    End Sub

#End Region

#Region "CellDoubleClick"

    Private Sub dgvMATECAMP_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvMATECAMP.CellDoubleClick
        Me.cmdAGREGAR.PerformClick()
    End Sub

#End Region

#End Region

End Class