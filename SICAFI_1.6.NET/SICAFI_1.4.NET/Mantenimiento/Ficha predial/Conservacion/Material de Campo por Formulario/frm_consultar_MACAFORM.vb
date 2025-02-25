Imports REGLAS_DEL_NEGOCIO

Public Class frm_consultar_MACAFORM

    '=================================================
    '*** CONSULTA MATERIAL DE CAMPO POR FORMULARIO ***
    '=================================================

#Region "VARIABLES"

    Dim boCONSULTA As Boolean = False

    Dim dt As DataTable

#End Region

#Region "PROCEDIMIENTOS"

    Private Sub pro_Reconsultar()
        Try
            ' instancia un dt
            dt = New DataTable

            ' crea la variable de consulta
            Dim stConsulta As String = ""

            ' crea la variable de los campos
            Dim stMCFOFORM As String = ""
            Dim stMCFOMACA As String = ""
            Dim stMCFOESTA As String = ""

            ' carga los campos
            If Trim(Me.txtMCFOFORM.Text) = "" Then
                stMCFOFORM = "%"
            Else
                stMCFOFORM = Trim(Me.txtMCFOFORM.Text)
            End If

            ' carga los campos
            If Trim(Me.txtMCFOMACA.Text) = "" Then
                stMCFOMACA = "%"
            Else
                stMCFOMACA = Trim(Me.txtMCFOMACA.Text)
            End If

            ' carga los campos
            If Trim(Me.txtMCFOESTA.Text) = "" Then
                stMCFOESTA = "%"
            Else
                stMCFOESTA = Trim(Me.txtMCFOESTA.Text)
            End If

            'VARIatena la consulta
            stConsulta += "Select "
            stConsulta += "MCFOIDRE , "
            stConsulta += "MCFOFORM as 'Formulario', "
            stConsulta += "MCFOMACA as 'Material de campo', "
            stConsulta += "MCFOESTA as 'Estado' "
            stConsulta += "From MANT_MACAFORM "
            stConsulta += "Where "
            stConsulta += "MCFOFORM like '" & stMCFOFORM & "' and "
            stConsulta += "MCFOMACA like '" & stMCFOMACA & "' and "
            stConsulta += "MCFOESTA like '" & stMCFOESTA & "' "
            stConsulta += "Order by MCFOFORM, MCFOMACA "

            ' instancia la clase y almacena la consulta
            Dim oConsulta As New cla_Consulta_ConexionString

            dt = oConsulta.fun_Consultar_ConexionString(stConsulta)

            Me.dgvCONSULTA.DataSource = dt

            Me.dgvCONSULTA.Columns(0).Visible = False

            ' verifica si existen datos consultados
            If Me.dgvCONSULTA.RowCount = 0 Then
                mod_MENSAJE.No_Se_Encontro_Ningun_registro()
                Me.cmdAceptar.Enabled = False
                Me.txtMCFOMACA.Focus()
            Else
                Me.cmdAceptar.Enabled = True
            End If

            Me.strBARRESTA.Items(2).Text = "Registros : " & dt.Rows.Count

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub pro_LimpiarCampos()

        Me.txtMCFOFORM.Text = ""
        Me.txtMCFOMACA.Text = ""
        Me.txtMCFOESTA.Text = ""

        Me.strBARRESTA.Items(2).Text = "Registros : 0"

        Me.dgvCONSULTA.DataSource = New DataTable

    End Sub

#End Region

#Region "MENU"

    Private Sub cmdConsultar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdConsultar.Click

        Try
            pro_Reconsultar()

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub cmdAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAceptar.Click

        If Me.dgvCONSULTA.RowCount = 0 Then
            MessageBox.Show("No existen registro seleccionados", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
        Else
            Dim inId_Reg As New frm_VARIABLE(Integer.Parse(Me.dgvCONSULTA.SelectedRows.Item(0).Cells(0).Value.ToString()))
            Me.txtMCFOMACA.Focus()
            Me.Close()
        End If

    End Sub
    Private Sub cmdLimpiar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdLimpiar.Click
        pro_LimpiarCampos()
        Me.txtMCFOMACA.Focus()
    End Sub
    Private Sub cmdSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSalir.Click
        Me.Close()
    End Sub

#End Region

#Region "FORMULARIO"

#Region "Load"

    Private Sub Frm_Consultar_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        pro_LimpiarCampos()
        Me.txtMCFOFORM.Focus()
    End Sub

#End Region

#Region "KeyPress"

    Private Sub txt_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtMCFOMACA.KeyPress, txtMCFOESTA.KeyPress, txtMCFOFORM.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            pp_pro_SaltarCampo()
        End If
    End Sub

#End Region

#Region "GotFocus"

    Private Sub txt_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtMCFOMACA.GotFocus, txtMCFOESTA.GotFocus, txtMCFOFORM.GotFocus
        pp_pro_SobrearCampo(sender)
        pp_pro_DescripcionCampo(Me.strBARRESTA.Items(0), sender)
    End Sub
    Private Sub cmdAceptar_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdAceptar.GotFocus, cmdLimpiar.GotFocus, cmdConsultar.GotFocus, cmdSalir.GotFocus
        pp_pro_DescripcionCampo(Me.strBARRESTA.Items(0), sender)
    End Sub

#End Region

#End Region

End Class