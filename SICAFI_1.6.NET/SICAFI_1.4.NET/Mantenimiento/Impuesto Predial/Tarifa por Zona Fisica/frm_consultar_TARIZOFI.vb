Imports REGLAS_DEL_NEGOCIO

Public Class frm_consultar_TARIZOFI

    '===================================
    '*** CONSULTA TARIFA ZONA FÍSICA ***
    '===================================

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
            Dim stTAZFDEPA As String = ""
            Dim stTAZFMUNI As String = ""
            Dim stTAZFCLSE As String = ""
            Dim stTAZFVIGE As String = ""
            Dim stTAZFZOEC As String = ""
            Dim stTAZFZOAP As String = ""
            Dim stTAZFTA01 As String = ""
            Dim stTAZFTA02 As String = ""
            Dim stTAZFTA03 As String = ""
            Dim stTAZFTA04 As String = ""
            Dim stTAZFTA05 As String = ""
            Dim stTAZFTA06 As String = ""
            Dim stTAZFESTA As String = ""

            ' carga los campos
            If Trim(Me.txtTAZFDEPA.Text) = "" Then
                stTAZFDEPA = "%"
            Else
                stTAZFDEPA = Trim(Me.txtTAZFDEPA.Text)
            End If

            ' carga los campos
            If Trim(Me.txtTAZFMUNI.Text) = "" Then
                stTAZFMUNI = "%"
            Else
                stTAZFMUNI = Trim(Me.txtTAZFMUNI.Text)
            End If

            ' carga los campos
            If Trim(Me.txtTAZFCLSE.Text) = "" Then
                stTAZFCLSE = "%"
            Else
                stTAZFCLSE = Trim(Me.txtTAZFCLSE.Text)
            End If

            ' carga los campos
            If Trim(Me.txtTAZFVIGE.Text) = "" Then
                stTAZFVIGE = "%"
            Else
                stTAZFVIGE = Trim(Me.txtTAZFVIGE.Text)
            End If

            ' carga los campos
            If Trim(Me.txtTAZFZOEC.Text) = "" Then
                stTAZFZOEC = "%"
            Else
                stTAZFZOEC = Trim(Me.txtTAZFZOEC.Text)
            End If

            ' carga los campos
            If Trim(Me.txtTAZFZOAP.Text) = "" Then
                stTAZFZOAP = "%"
            Else
                stTAZFZOAP = Trim(Me.txtTAZFZOAP.Text)
            End If

            ' carga los campos
            If Trim(Me.txtTAZFTA01.Text) = "" Then
                stTAZFTA01 = "%"
            Else
                stTAZFTA01 = Trim(Me.txtTAZFTA01.Text)
            End If

            ' carga los campos
            If Trim(Me.txtTAZFTA02.Text) = "" Then
                stTAZFTA02 = "%"
            Else
                stTAZFTA02 = Trim(Me.txtTAZFTA02.Text)
            End If

            ' carga los campos
            If Trim(Me.txtTAZFTA03.Text) = "" Then
                stTAZFTA03 = "%"
            Else
                stTAZFTA03 = Trim(Me.txtTAZFTA03.Text)
            End If

            ' carga los campos
            If Trim(Me.txtTAZFTA04.Text) = "" Then
                stTAZFTA04 = "%"
            Else
                stTAZFTA04 = Trim(Me.txtTAZFTA04.Text)
            End If

            ' carga los campos
            If Trim(Me.txtTAZFTA05.Text) = "" Then
                stTAZFTA05 = "%"
            Else
                stTAZFTA05 = Trim(Me.txtTAZFTA05.Text)
            End If

            ' carga los campos
            If Trim(Me.txtTAZFTA06.Text) = "" Then
                stTAZFTA06 = "%"
            Else
                stTAZFTA06 = Trim(Me.txtTAZFTA06.Text)
            End If

            ' carga los campos
            If Trim(Me.txtTAZFESTA.Text) = "" Then
                stTAZFESTA = "%"
            Else
                stTAZFESTA = Trim(Me.txtTAZFESTA.Text)
            End If

            'concatena la consulta
            stConsulta += "Select "
            stConsulta += "TAZFIDRE , "
            stConsulta += "TAZFDEPA as 'Departamento', "
            stConsulta += "TAZFMUNI as 'Municipio', "
            stConsulta += "TAZFCLSE as 'Sector', "
            stConsulta += "TAZFVIGE as 'Vigencia', "
            stConsulta += "TAZFZOEC as 'Zona fisica', "
            stConsulta += "TAZFZOAP as 'Zona aplicada', "
            stConsulta += "TAZFTA01 as 'Tarifa 01', "
            stConsulta += "TAZFTA02 as 'Tarifa 02', "
            stConsulta += "TAZFTA03 as 'Tarifa 03', "
            stConsulta += "TAZFTA04 as 'Tarifa 04', "
            stConsulta += "TAZFTA05 as 'Tarifa 05', "
            stConsulta += "TAZFTA06 as 'Tarifa 06', "
            stConsulta += "TAZFESTA as 'Estado' "
            stConsulta += "From TARIZOFI "
            stConsulta += "Where "
            stConsulta += "TAZFDEPA like '" & stTAZFDEPA & "' and "
            stConsulta += "TAZFMUNI like '" & stTAZFMUNI & "' and "
            stConsulta += "TAZFCLSE like '" & stTAZFCLSE & "' and "
            stConsulta += "TAZFVIGE like '" & stTAZFVIGE & "' and "
            stConsulta += "TAZFZOEC like '" & stTAZFZOEC & "' and "
            stConsulta += "TAZFZOAP like '" & stTAZFZOAP & "' and "
            stConsulta += "TAZFTA01 like '" & stTAZFTA01 & "' and "
            stConsulta += "TAZFTA02 like '" & stTAZFTA02 & "' and "
            stConsulta += "TAZFTA03 like '" & stTAZFTA03 & "' and "
            stConsulta += "TAZFTA04 like '" & stTAZFTA04 & "' and "
            stConsulta += "TAZFTA05 like '" & stTAZFTA05 & "' and "
            stConsulta += "TAZFTA06 like '" & stTAZFTA06 & "' and "
            stConsulta += "TAZFESTA like '" & stTAZFESTA & "' "
            stConsulta += "Order by TAZFDEPA, TAZFMUNI, TAZFVIGE, TAZFCLSE "

            ' instancia la clase y almacena la consulta
            Dim oConsulta As New cla_Consulta_ConexionString

            dt = oConsulta.fun_Consultar_ConexionString(stConsulta)

            Me.dgvCONSULTA.DataSource = dt

            Me.dgvCONSULTA.Columns(0).Visible = False

            ' verifica si existen datos consultados
            If Me.dgvCONSULTA.RowCount = 0 Then
                mod_MENSAJE.No_Se_Encontro_Ningun_registro()
                Me.cmdAceptar.Enabled = False
                Me.txtTAZFDEPA.Focus()
            Else
                Me.cmdAceptar.Enabled = True
            End If

            Me.strBARRESTA.Items(2).Text = "Registros : " & dt.Rows.Count

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub pro_LimpiarCampos()

        Me.txtTAZFDEPA.Text = ""
        Me.txtTAZFMUNI.Text = ""
        Me.txtTAZFCLSE.Text = ""
        Me.txtTAZFVIGE.Text = ""
        Me.txtTAZFZOEC.Text = ""
        Me.txtTAZFZOAP.Text = ""
        Me.txtTAZFTA01.Text = ""
        Me.txtTAZFTA02.Text = ""
        Me.txtTAZFTA03.Text = ""
        Me.txtTAZFTA04.Text = ""
        Me.txtTAZFTA05.Text = ""
        Me.txtTAZFTA06.Text = ""
        Me.txtTAZFESTA.Text = ""

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
            Dim inId_Reg As New frm_TARIZOFI(Integer.Parse(Me.dgvCONSULTA.SelectedRows.Item(0).Cells(0).Value.ToString()))
            Me.txtTAZFDEPA.Focus()
            Me.Close()
        End If

    End Sub
    Private Sub cmdLimpiar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdLimpiar.Click
        pro_LimpiarCampos()
        Me.txtTAZFDEPA.Focus()
    End Sub
    Private Sub cmdSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSalir.Click
        Me.Close()
    End Sub

#End Region

#Region "FORMULARIO"

#Region "Load"

    Private Sub Frm_Consultar_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        pro_LimpiarCampos()
        Me.txtTAZFDEPA.Focus()
    End Sub

#End Region

#Region "KeyPress"

    Private Sub txt_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtTAZFDEPA.KeyPress, txtTAZFMUNI.KeyPress, txtTAZFCLSE.KeyPress, txtTAZFVIGE.KeyPress, txtTAZFZOEC.KeyPress, txtTAZFZOAP.KeyPress, txtTAZFZOAP.KeyPress, txtTAZFTA01.KeyPress, txtTAZFTA02.KeyPress, txtTAZFTA03.KeyPress, txtTAZFTA04.KeyPress, txtTAZFTA05.KeyPress, txtTAZFESTA.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            pp_pro_SaltarCampo()
        End If
    End Sub

#End Region

#Region "GotFocus"

    Private Sub txt_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtTAZFDEPA.GotFocus, txtTAZFMUNI.GotFocus, txtTAZFCLSE.GotFocus, txtTAZFVIGE.GotFocus, txtTAZFZOEC.GotFocus, txtTAZFZOAP.GotFocus, txtTAZFZOAP.GotFocus, txtTAZFTA01.GotFocus, txtTAZFTA02.GotFocus, txtTAZFTA03.GotFocus, txtTAZFTA04.GotFocus, txtTAZFTA05.GotFocus, txtTAZFESTA.GotFocus
        pp_pro_SobrearCampo(sender)
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