Imports REGLAS_DEL_NEGOCIO

Public Class frm_consultar_CIRCREGI

    '====================================
    '*** CONSULTA CIRCULO DE REGISTRO ***
    '====================================

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
            Dim stCIREDEPA As String = ""
            Dim stCIREMUNI As String = ""
            Dim stCIRECIRE As String = ""
            Dim stCIREDESC As String = ""
            Dim stCIREESTA As String = ""

            ' carga los campos
            If Trim(Me.txtCIREDEPA.Text) = "" Then
                stCIREDEPA = "%"
            Else
                stCIREDEPA = Trim(Me.txtCIREDEPA.Text)
            End If

            ' carga los campos
            If Trim(Me.txtCIREMUNI.Text) = "" Then
                stCIREMUNI = "%"
            Else
                stCIREMUNI = Trim(Me.txtCIREMUNI.Text)
            End If

            ' carga los campos
            If Trim(Me.txtCIRECIRE.Text) = "" Then
                stCIRECIRE = "%"
            Else
                stCIRECIRE = Trim(Me.txtCIRECIRE.Text)
            End If

            ' carga los campos
            If Trim(Me.txtCIREDESC.Text) = "" Then
                stCIREDESC = "%"
            Else
                stCIREDESC = Trim(Me.txtCIREDESC.Text)
            End If


            ' carga los campos
            If Trim(Me.txtCIREESTA.Text) = "" Then
                stCIREESTA = "%"
            Else
                stCIREESTA = Trim(Me.txtCIREESTA.Text)
            End If

            'concatena la consulta
            stConsulta += "Select "
            stConsulta += "CIREIDRE , "
            stConsulta += "CIREDEPA as 'Departamento', "
            stConsulta += "CIREMUNI as 'Municipio', "
            stConsulta += "CIRECIRE as 'Circulo registral', "
            stConsulta += "CIREDESC as 'Descripción', "
            stConsulta += "CIREESTA as 'Estado' "
            stConsulta += "From MANT_CIRCREGI "
            stConsulta += "Where "
            stConsulta += "CIREDEPA like '" & stCIREDEPA & "' and "
            stConsulta += "CIREMUNI like '" & stCIREMUNI & "' and "
            stConsulta += "CIRECIRE like '" & stCIRECIRE & "' and "
            stConsulta += "CIREDESC like '" & stCIREDESC & "' and "
            stConsulta += "CIREESTA like '" & stCIREESTA & "' "
            stConsulta += "Order by CIREDEPA, CIREMUNI, CIRECIRE "

            ' instancia la clase y almacena la consulta
            Dim oConsulta As New cla_Consulta_ConexionString

            dt = oConsulta.fun_Consultar_ConexionString(stConsulta)
            Me.dgvCONSULTA.DataSource = dt

            Me.dgvCONSULTA.Columns(0).Visible = False

            ' verifica si existen datos consultados
            If Me.dgvCONSULTA.RowCount = 0 Then
                mod_MENSAJE.No_Se_Encontro_Ningun_registro()
                Me.cmdAceptar.Enabled = False
                Me.txtCIREDEPA.Focus()
            Else
                Me.cmdAceptar.Enabled = True
            End If

            Me.strBARRESTA.Items(2).Text = "Registros : " & dt.Rows.Count

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub pro_LimpiarCampos()

        Me.txtCIREDEPA.Text = ""
        Me.txtCIREMUNI.Text = ""
        Me.txtCIRECIRE.Text = ""
        Me.txtCIREDESC.Text = ""
        Me.txtCIREESTA.Text = ""

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
            Dim inId_Reg As New frm_CIRCREGI(Integer.Parse(Me.dgvCONSULTA.SelectedRows.Item(0).Cells(0).Value.ToString()))
            Me.txtCIREDEPA.Focus()
            Me.Close()
        End If

    End Sub
    Private Sub cmdLimpiar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdLimpiar.Click
        pro_LimpiarCampos()
        Me.txtCIREDEPA.Focus()
    End Sub
    Private Sub cmdSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSalir.Click
        Me.Close()
    End Sub

#End Region

#Region "FORMULARIO"

#Region "Load"

    Private Sub Frm_Consultar_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        pro_LimpiarCampos()
        Me.txtCIREDEPA.Focus()
    End Sub

#End Region

#Region "KeyPress"

    Private Sub txt_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCIREDEPA.KeyPress, txtCIREMUNI.KeyPress, txtCIRECIRE.KeyPress, txtCIREDESC.KeyPress, txtCIREESTA.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            pp_pro_SaltarCampo()
        End If
    End Sub

#End Region

#Region "GotFocus"

    Private Sub txt_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCIREDEPA.GotFocus, txtCIREMUNI.GotFocus, txtCIRECIRE.GotFocus, txtCIREDESC.GotFocus, txtCIREESTA.GotFocus
        pp_pro_SobrearCampo(sender)
        pp_pro_DescripcionCampo(Me.strBARRESTA.Items(0), sender)
    End Sub
    Private Sub chk_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs)
        pp_pro_DescripcionCampo(Me.strBARRESTA.Items(0), sender)
    End Sub
    Private Sub cmdAceptar_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdAceptar.GotFocus, cmdLimpiar.GotFocus, cmdConsultar.GotFocus, cmdSalir.GotFocus
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