Imports REGLAS_DEL_NEGOCIO

Public Class frm_consultar_COMUNA

    '=======================
    '*** CONSULTA COMUNA ***
    '=======================

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
            Dim stCOMUDEPA As String = ""
            Dim stCOMUMUNI As String = ""
            Dim stCOMUCLSE As String = ""
            Dim stCOMUCODI As String = ""
            Dim stCOMUDESC As String = ""
            Dim stCOMUESTA As String = ""


            ' carga los campos
            If Trim(Me.txtCOMUDEPA.Text) = "" Then
                stCOMUDEPA = "%"
            Else
                stCOMUDEPA = Trim(Me.txtCOMUDEPA.Text)
            End If

            ' carga los campos
            If Trim(Me.txtCOMUMUNI.Text) = "" Then
                stCOMUMUNI = "%"
            Else
                stCOMUMUNI = Trim(Me.txtCOMUMUNI.Text)
            End If

            ' carga los campos
            If Trim(Me.txtCOMUCLSE.Text) = "" Then
                stCOMUCLSE = "%"
            Else
                stCOMUCLSE = Trim(Me.txtCOMUCLSE.Text)
            End If

            ' carga los campos
            If Trim(Me.txtCOMUCLSE.Text) = "" Then
                stCOMUCLSE = "%"
            Else
                stCOMUCLSE = Trim(Me.txtCOMUCLSE.Text)
            End If

            ' carga los campos
            If Trim(Me.txtCOMUCODI.Text) = "" Then
                stCOMUCODI = "%"
            Else
                stCOMUCODI = Trim(Me.txtCOMUCODI.Text)
            End If

            ' carga los campos
            If Trim(Me.txtCOMUDESC.Text) = "" Then
                stCOMUDESC = "%"
            Else
                stCOMUDESC = Trim(Me.txtCOMUDESC.Text)
            End If

            ' carga los campos
            If Trim(Me.txtCOMUESTA.Text) = "" Then
                stCOMUESTA = "%"
            Else
                stCOMUESTA = Trim(Me.txtCOMUESTA.Text)
            End If

            'concatena la consulta
            stConsulta += "Select "
            stConsulta += "COMUIDRE , "
            stConsulta += "COMUDEPA as 'Departamento', "
            stConsulta += "COMUMUNI as 'Municipio', "
            stConsulta += "COMUCLSE as 'Sector', "
            stConsulta += "COMUCODI as 'Comuna', "
            stConsulta += "COMUDESC as 'Descripción', "
            stConsulta += "COMUESTA as 'Estado' "
            stConsulta += "From MANT_COMUNA "
            stConsulta += "Where "
            stConsulta += "COMUDEPA like '" & stCOMUDEPA & "' and "
            stConsulta += "COMUMUNI like '" & stCOMUMUNI & "' and "
            stConsulta += "COMUCLSE like '" & stCOMUCLSE & "' and "
            stConsulta += "COMUCODI like '" & stCOMUCODI & "' and "
            stConsulta += "COMUDESC like '" & stCOMUDESC & "' and "
            stConsulta += "COMUESTA like '" & stCOMUESTA & "' "
            stConsulta += "Order by COMUDEPA, COMUMUNI, COMUCLSE "

            ' instancia la clase y almacena la consulta
            Dim oConsulta As New cla_Consulta_ConexionString

            dt = oConsulta.fun_Consultar_ConexionString(stConsulta)
            Me.dgvCONSULTA.DataSource = dt

            Me.dgvCONSULTA.Columns(0).Visible = False

            ' verifica si existen datos consultados
            If Me.dgvCONSULTA.RowCount = 0 Then
                mod_MENSAJE.No_Se_Encontro_Ningun_registro()
                Me.cmdAceptar.Enabled = False
                Me.txtCOMUDEPA.Focus()
            Else
                Me.cmdAceptar.Enabled = True
            End If

            Me.strBARRESTA.Items(2).Text = "Registros : " & dt.Rows.Count

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub pro_LimpiarCampos()

        Me.txtCOMUDEPA.Text = ""
        Me.txtCOMUMUNI.Text = ""
        Me.txtCOMUCLSE.Text = ""
        Me.txtCOMUCODI.Text = ""
        Me.txtCOMUDESC.Text = ""
        Me.txtCOMUESTA.Text = ""

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
            Dim inId_Reg As New frm_VIGEACTU(Integer.Parse(Me.dgvCONSULTA.SelectedRows.Item(0).Cells(0).Value.ToString()))
            Me.txtCOMUDEPA.Focus()
            Me.Close()
        End If

    End Sub
    Private Sub cmdLimpiar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdLimpiar.Click
        pro_LimpiarCampos()
        Me.txtCOMUDEPA.Focus()
    End Sub
    Private Sub cmdSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSalir.Click
        Me.Close()
    End Sub

#End Region

#Region "FORMULARIO"

#Region "Load"

    Private Sub Frm_Consultar_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        pro_LimpiarCampos()
        Me.txtCOMUDEPA.Focus()
    End Sub

#End Region

#Region "KeyPress"

    Private Sub txt_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCOMUDEPA.KeyPress, txtCOMUMUNI.KeyPress, txtCOMUCLSE.KeyPress, txtCOMUCODI.KeyPress, txtCOMUDESC.KeyPress, txtCOMUESTA.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            pp_pro_SaltarCampo()
        End If
    End Sub

#End Region

#Region "GotFocus"

    Private Sub txt_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCOMUDEPA.GotFocus, txtCOMUMUNI.GotFocus, txtCOMUCLSE.GotFocus, txtCOMUCODI.GotFocus, txtCOMUDESC.GotFocus, txtCOMUESTA.GotFocus
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