Imports REGLAS_DEL_NEGOCIO

Public Class frm_insertar_MATEREGI

    '=====================================
    '*** INSERTAR MATERIAL DE REGISTRO ***
    '=====================================

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
        Me.dgvMATEREGI.DataSource = New DataTable

        Me.txtMAREFECH.Text = ""
        Me.txtMAREOBSE.Text = ""

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

                Me.dgvMATECAMP.Columns("MACACODI").HeaderText = "C�digo"
                Me.dgvMATECAMP.Columns("MACADESC").HeaderText = "Descripci�n"

                Me.dgvMATECAMP.Columns("MACACODI").Width = 25
                Me.dgvMATECAMP.Columns("MACADESC").Width = 250

            End If

            Dim objdatos9 As New cla_MATEREGI
            Dim tbl9 As New DataTable

            tbl9 = objdatos9.fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_MATEREGI(inID_REGISTRO)

            If tbl9.Rows.Count > 0 Then

                Me.txtMAREFECH.Text = Trim(tbl9.Rows(0).Item("MAREFECH"))
                'Me.txtMAREOBSE.Text = Trim(tbl9.Rows(0).Item("MAREOBSE").ToString)

                ' Crea objeto de columnas y registros
                dt1 = New DataTable

                ' Crea las columnas
                dt1.Columns.Add(New DataColumn("C�digo", GetType(String)))
                dt1.Columns.Add(New DataColumn("Descripci�n", GetType(String)))

                Dim i As Integer = 0

                For i = 0 To tbl9.Rows.Count - 1

                    dr1 = dt1.NewRow()

                    dr1("C�digo") = Trim(tbl9.Rows(i).Item("MAREMACA").ToString)
                    dr1("Descripci�n") = Trim(tbl9.Rows(i).Item("MACADESC").ToString)

                    dt1.Rows.Add(dr1)

                Next

                Me.dgvMATEREGI.DataSource = dt1

                Me.dgvMATEREGI.Columns("C�digo").Width = 25
                Me.dgvMATEREGI.Columns("Descripci�n").Width = 250

            Else

                Me.txtMAREFECH.Text = fun_fecha()

                ' Crea objeto de columnas y registros
                dt1 = New DataTable

                ' Crea las columnas
                dt1.Columns.Add(New DataColumn("C�digo", GetType(String)))
                dt1.Columns.Add(New DataColumn("Descripci�n", GetType(String)))

                Me.dgvMATEREGI.DataSource = dt1

                Me.dgvMATEREGI.Columns("C�digo").Width = 25
                Me.dgvMATEREGI.Columns("Descripci�n").Width = 250

            End If


        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub

#End Region

#Region "MENU"

    Private Sub cmdGUARDAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGUARDAR.Click

        Try
            ' inserta la observaci�n
            Dim obTRCAOBME As New cla_TRCAOBMR
            Dim dtTRCAOBME As New DataTable

            dtTRCAOBME = obTRCAOBME.fun_Buscar_CODIGO_X_TRCAOBMR(inID_REGISTRO)

            If dtTRCAOBME.Rows.Count = 0 Then
                obTRCAOBME.fun_Insertar_TRCAOBMR(inID_REGISTRO, " Nota ingresada por: " & vp_usuario & " " & fun_fecha() & " : " & Trim(Me.txtMAREOBSE.Text) & ". ")
            Else

                Dim stMAUSOBSE_NUEVA As String = Trim(Me.txtMAREOBSE.Text)
                Dim stMAUSOBSE_ANTERIOR As String = Trim(dtTRCAOBME.Rows(0).Item("TCMROBSE"))

                If Trim(stMAUSOBSE_NUEVA) <> "" Then
                    stMAUSOBSE_ANTERIOR += " Nota ingresada por: " & vp_usuario & " " & fun_fecha() & " : " & stMAUSOBSE_NUEVA & ". "
                End If

                obTRCAOBME.fun_Actualizar_TRCAOBMR(inID_REGISTRO, Trim(stMAUSOBSE_ANTERIOR))
            End If

            If Me.dgvMATEREGI.RowCount = 0 Then
                Dim objdatos15 As New cla_MATEREGI
                objdatos15.fun_Eliminar_SECU_MATEREGI(inID_REGISTRO)

                mod_MENSAJE.Se_Guardaron_Los_Datos_Correctamente()
                Me.Close()
            Else
                ' elimina los registros
                Dim objdatos11 As New cla_MATEREGI
                objdatos11.fun_Eliminar_SECU_MATEREGI(inID_REGISTRO)

                Dim tbl As New DataTable
                tbl = Me.dgvMATEREGI.DataSource

                Dim obj_MATEFALT As New cla_MATEFALT
                Dim dt_MATEFALT As New DataTable

                dt_MATEFALT = obj_MATEFALT.fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_MATEFALT(inID_REGISTRO)

                Dim i As Integer = 0

                For i = 0 To tbl.Rows.Count - 1

                    Dim stCODIGO As String = Trim(tbl.Rows(i).Item("C�digo").ToString)

                    Dim sw1 As Byte = 0
                    Dim j1 As Integer = 0

                    ' elimina los registros del material de registro
                    While j1 < dt_MATEFALT.Rows.Count And sw1 = 0
                        If tbl.Rows(i).Item("C�digo") = dt_MATEFALT.Rows(j1).Item("MAFAMACA") Then
                            sw1 = 1

                            Dim objEliminaMaterialFaltante As New cla_MATEFALT
                            objEliminaMaterialFaltante.fun_Eliminar_SECU_X_MACA_MATEFALT(inID_REGISTRO, dt_MATEFALT.Rows(j1).Item("MAFAMACA"))
                        Else
                            j1 = j1 + 1
                        End If
                    End While

                    Dim objdatos12 As New cla_MATEREGI
                    objdatos12.fun_Insertar_MATEREGI(inID_REGISTRO, stCODIGO, Me.txtMAREFECH.Text, Me.txtMAREOBSE.Text)

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

                tbl = Me.dgvMATEREGI.DataSource

                Dim i As Integer = 0
                Dim bySW As Byte = 0

                For i = 0 To tbl.Rows.Count - 1

                    If Trim(tbl.Rows(i).Item("C�digo").ToString) = Trim(stMACACODI) Then
                        bySW = 1
                    End If

                Next

                If bySW = 1 Then
                    MessageBox.Show("C�digo existente en material de registro", "Mensaje ...", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1)
                Else
                    dr1 = dt1.NewRow()

                    dr1("C�digo") = Trim(stMACACODI)
                    dr1("Descripci�n") = Trim(stDESCRIPCION)

                    dt1.Rows.Add(dr1)
                End If

            Else
                MessageBox.Show("Seleccione un c�digo del material de campo", "Mensaje ...", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub cmdELIMINAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdELIMINAR.Click

        Try
            If Me.dgvMATEREGI.SelectedRows.Count > 0 Then
                Me.dgvMATEREGI.Rows.RemoveAt(Me.dgvMATEREGI.SelectedRows(0).Index)
            Else
                MessageBox.Show("Seleccione un c�digo del material de registro", "Mensaje ...", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub

#End Region

#Region "FORMULARIO"

#Region "KeyPress"

    Private Sub txt_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtMAREOBSE.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Or e.KeyChar = Convert.ToChar(Keys.Tab) Then
            pp_pro_SaltarCampo()
        End If
    End Sub

#End Region

#Region "KeyDown"

    Private Sub cboTRCACLSE_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgvMATEREGI.KeyDown
        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then

        End If
    End Sub

#End Region

#Region "GotFocus"

    Private Sub txt_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtMAREOBSE.GotFocus, txtMAREFECH.GotFocus
        pp_pro_SobrearCampo(sender)
        pp_pro_DescripcionCampo(Me.strBARRESTA.Items(0), sender)
    End Sub
    Private Sub cmd_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdGUARDAR.GotFocus, cmdSALIR.GotFocus
        pp_pro_DescripcionCampo(Me.strBARRESTA.Items(0), sender)
    End Sub

    Private Sub dgv_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvMATECAMP.GotFocus, dgvMATEREGI.GotFocus
        pp_pro_DescripcionCampo(Me.strBARRESTA.Items(0), sender)
    End Sub

#End Region

#Region "CellDoubleClick"

    Private Sub dgvMATECAMP_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvMATECAMP.CellDoubleClick
        Me.cmdAGREGAR.PerformClick()
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

#End Region

End Class