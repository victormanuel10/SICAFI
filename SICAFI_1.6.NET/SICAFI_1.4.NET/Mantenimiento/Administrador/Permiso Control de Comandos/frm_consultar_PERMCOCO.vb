Imports REGLAS_DEL_NEGOCIO

Public Class frm_consultar_PERMCOCO

    '============================================
    '*** CONSULTA PERMISO CONTROL DE COMANDOS ***
    '============================================

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
            Dim stPECCUSUA As String = ""
            Dim stPECCFORM As String = ""
            Dim stPECCCOCO As String = ""
            Dim stPECCESTA As String = ""

            ' carga los campos
            If Trim(Me.txtPECCUSUA.Text) = "" Then
                stPECCUSUA = "%"
            Else
                stPECCUSUA = Trim(Me.txtPECCUSUA.Text)
            End If

            ' carga los campos
            If Trim(Me.txtPECCFORM.Text) = "" Then
                stPECCFORM = "%"
            Else
                stPECCFORM = Trim(Me.txtPECCFORM.Text)
            End If

            ' carga los campos
            If Trim(Me.txtPECCCOCO.Text) = "" Then
                stPECCCOCO = "%"
            Else
                stPECCCOCO = Trim(Me.txtPECCCOCO.Text)
            End If

            ' carga los campos
            If Trim(Me.txtPECCESTA.Text) = "" Then
                stPECCESTA = "%"
            Else
                stPECCESTA = Trim(Me.txtPECCESTA.Text)
            End If

            'concatena la consulta
            stConsulta += "Select "
            stConsulta += "PECCIDRE , "
            stConsulta += "PECCUSUA as 'Usuario', "
            stConsulta += "PECCFORM as 'Formulario', "
            stConsulta += "PECCCOCO as 'Control comandos', "
            stConsulta += "PECCESTA as 'Estado' "
            stConsulta += "From PERMCOCO "
            stConsulta += "Where "
            stConsulta += "PECCUSUA like '" & stPECCUSUA & "' and "
            stConsulta += "PECCFORM like '" & stPECCFORM & "' and "
            stConsulta += "PECCCOCO like '" & stPECCCOCO & "' and "
            stConsulta += "PECCESTA like '" & stPECCESTA & "' "
            stConsulta += "Order by PECCUSUA, PECCFORM, PECCCOCO, PECCESTA "

            ' instancia la clase y almacena la consulta
            Dim oConsulta As New cla_Consulta_ConexionString

            dt = oConsulta.fun_Consultar_ConexionString(stConsulta)

            Me.dgvCONSULTA.DataSource = dt

            Me.dgvCONSULTA.Columns(0).Visible = False

            ' verifica si existen datos consultados
            If Me.dgvCONSULTA.RowCount = 0 Then
                mod_MENSAJE.No_Se_Encontro_Ningun_registro()
                Me.cmdAceptar.Enabled = False
                Me.txtPECCUSUA.Focus()
            Else
                Me.cmdAceptar.Enabled = True
            End If

            Me.strBARRESTA.Items(2).Text = "Registros : " & dt.Rows.Count

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub pro_LimpiarCampos()

        Me.txtPECCUSUA.Text = ""
        Me.txtPECCFORM.Text = ""
        Me.txtPECCCOCO.Text = ""
        Me.txtPECCESTA.Text = ""

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
            Dim inId_Reg As New frm_DEECLOTE(Integer.Parse(Me.dgvCONSULTA.SelectedRows.Item(0).Cells(0).Value.ToString()))
            Me.txtPECCUSUA.Focus()
            Me.Close()
        End If

    End Sub
    Private Sub cmdLimpiar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdLimpiar.Click
        pro_LimpiarCampos()
        Me.txtPECCUSUA.Focus()
    End Sub
    Private Sub cmdSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSalir.Click
        Me.Close()
    End Sub

#End Region

#Region "FORMULARIO"

#Region "Load"

    Private Sub Frm_Consultar_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        pro_LimpiarCampos()
        Me.txtPECCUSUA.Focus()
    End Sub

#End Region

#Region "KeyPress"

    Private Sub txt_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtPECCUSUA.KeyPress, txtPECCFORM.KeyPress, txtPECCCOCO.KeyPress, txtPECCESTA.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            pp_pro_SaltarCampo()
        End If
    End Sub

#End Region

#Region "GotFocus"

    Private Sub txt_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtPECCUSUA.GotFocus, txtPECCFORM.GotFocus, txtPECCCOCO.GotFocus, txtPECCESTA.GotFocus
        pp_pro_SobrearCampo(sender)
        pp_pro_DescripcionCampo(Me.strBARRESTA.Items(0), sender)
    End Sub
    Private Sub cmd_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdAceptar.GotFocus, cmdLimpiar.GotFocus, cmdConsultar.GotFocus, cmdSalir.GotFocus
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

#End Region

End Class