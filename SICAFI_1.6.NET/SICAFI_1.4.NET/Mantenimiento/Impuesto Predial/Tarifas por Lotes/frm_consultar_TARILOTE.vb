Imports REGLAS_DEL_NEGOCIO

Public Class frm_consultar_TARILOTE

    '==========================================
    '*** CONSULTA TARIFA PREDIOS ESPECIALES ***
    '==========================================

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
            Dim stTALODEPA As String = ""
            Dim stTALOMUNI As String = ""
            Dim stTALOCLSE As String = ""
            Dim stTALOVIGE As String = ""
            Dim stTALOZOEC As String = ""
            Dim stTALOTARI As String = ""
            Dim stTALOAVIN As String = ""
            Dim stTALOAVFI As String = ""
            Dim stTALOESTA As String = ""

            ' carga los campos
            If Trim(Me.txtTALODEPA.Text) = "" Then
                stTALODEPA = "%"
            Else
                stTALODEPA = Trim(Me.txtTALODEPA.Text)
            End If

            ' carga los campos
            If Trim(Me.txtTALOMUNI.Text) = "" Then
                stTALOMUNI = "%"
            Else
                stTALOMUNI = Trim(Me.txtTALOMUNI.Text)
            End If

            ' carga los campos
            If Trim(Me.txtTALOCLSE.Text) = "" Then
                stTALOCLSE = "%"
            Else
                stTALOCLSE = Trim(Me.txtTALOCLSE.Text)
            End If

            ' carga los campos
            If Trim(Me.txtTALOVIGE.Text) = "" Then
                stTALOVIGE = "%"
            Else
                stTALOVIGE = Trim(Me.txtTALOVIGE.Text)
            End If

            ' carga los campos
            If Trim(Me.txtTALOZOEC.Text) = "" Then
                stTALOZOEC = "%"
            Else
                stTALOZOEC = Trim(Me.txtTALOZOEC.Text)
            End If

            ' carga los campos
            If Trim(Me.txtTALOTARI.Text) = "" Then
                stTALOTARI = "%"
            Else
                stTALOTARI = Trim(Me.txtTALOTARI.Text)
            End If

            ' carga los campos
            If Trim(Me.txtTALOAVIN.Text) = "" Then
                stTALOAVIN = "%"
            Else
                stTALOAVIN = Trim(Me.txtTALOAVIN.Text)
            End If

            ' carga los campos
            If Trim(Me.txtTALOAVFI.Text) = "" Then
                stTALOAVFI = "%"
            Else
                stTALOAVFI = Trim(Me.txtTALOAVFI.Text)
            End If

            ' carga los campos
            If Trim(Me.txtTALOESTA.Text) = "" Then
                stTALOESTA = "%"
            Else
                stTALOESTA = Trim(Me.txtTALOESTA.Text)
            End If

            'concatena la consulta
            stConsulta += "Select "
            stConsulta += "TALOIDRE , "
            stConsulta += "TALODEPA as 'Departamento', "
            stConsulta += "TALOMUNI as 'Municipio', "
            stConsulta += "TALOCLSE as 'Sector', "
            stConsulta += "TALOVIGE as 'Vigencia', "
            stConsulta += "TALOZOEC as 'Zona económica', "
            stConsulta += "TALOTARI as 'Tarifa', "
            stConsulta += "TALOAVIN as 'Avalúo inicial', "
            stConsulta += "TALOAVFI as 'Avalúo final', "
            stConsulta += "TALOESTA as 'Estado' "
            stConsulta += "From TARILOTE "
            stConsulta += "Where "
            stConsulta += "TALODEPA like '" & stTALODEPA & "' and "
            stConsulta += "TALOMUNI like '" & stTALOMUNI & "' and "
            stConsulta += "TALOCLSE like '" & stTALOCLSE & "' and "
            stConsulta += "TALOVIGE like '" & stTALOVIGE & "' and "
            stConsulta += "TALOZOEC like '" & stTALOZOEC & "' and "
            stConsulta += "TALOTARI like '" & stTALOTARI & "' and "
            stConsulta += "TALOAVIN like '" & stTALOAVIN & "' and "
            stConsulta += "TALOAVFI like '" & stTALOAVFI & "' and "
            stConsulta += "TALOESTA like '" & stTALOESTA & "' "
            stConsulta += "Order by TALODEPA, TALOMUNI, TALOCLSE, TALOZOEC "

            ' instancia la clase y almacena la consulta
            Dim oConsulta As New cla_Consulta_ConexionString

            dt = oConsulta.fun_Consultar_ConexionString(stConsulta)

            Me.dgvCONSULTA.DataSource = dt

            Me.dgvCONSULTA.Columns(0).Visible = False

            ' verifica si existen datos consultados
            If Me.dgvCONSULTA.RowCount = 0 Then
                mod_MENSAJE.No_Se_Encontro_Ningun_registro()
                Me.cmdAceptar.Enabled = False
                Me.txtTALODEPA.Focus()
            Else
                Me.cmdAceptar.Enabled = True
            End If

            Me.strBARRESTA.Items(2).Text = "Registros : " & dt.Rows.Count

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub pro_LimpiarCampos()

        Me.txtTALODEPA.Text = ""
        Me.txtTALOMUNI.Text = ""
        Me.txtTALOCLSE.Text = ""
        Me.txtTALOVIGE.Text = ""
        Me.txtTALOZOEC.Text = ""
        Me.txtTALOTARI.Text = ""
        Me.txtTALOAVIN.Text = ""
        Me.txtTALOAVFI.Text = ""
        Me.txtTALOESTA.Text = ""

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
            Dim inId_Reg As New frm_TARILOTE(Integer.Parse(Me.dgvCONSULTA.SelectedRows.Item(0).Cells(0).Value.ToString()))
            Me.txtTALODEPA.Focus()
            Me.Close()
        End If

    End Sub
    Private Sub cmdLimpiar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdLimpiar.Click
        pro_LimpiarCampos()
        Me.txtTALODEPA.Focus()
    End Sub
    Private Sub cmdSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSalir.Click
        Me.Close()
    End Sub

#End Region

#Region "FORMULARIO"

#Region "Load"

    Private Sub Frm_Consultar_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        pro_LimpiarCampos()
        Me.txtTALODEPA.Focus()
    End Sub

#End Region

#Region "KeyPress"

    Private Sub txt_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtTALODEPA.KeyPress, txtTALOMUNI.KeyPress, txtTALOCLSE.KeyPress, txtTALOVIGE.KeyPress, txtTALOZOEC.KeyPress, txtTALOTARI.KeyPress, txtTALOTARI.KeyPress, txtTALOAVIN.KeyPress, txtTALOAVFI.KeyPress, txtTALOESTA.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            pp_pro_SaltarCampo()
        End If
    End Sub

#End Region

#Region "GotFocus"

    Private Sub txt_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtTALODEPA.GotFocus, txtTALOMUNI.GotFocus, txtTALOCLSE.GotFocus, txtTALOVIGE.GotFocus, txtTALOZOEC.GotFocus, txtTALOTARI.GotFocus, txtTALOTARI.GotFocus, txtTALOAVIN.GotFocus, txtTALOAVFI.GotFocus, txtTALOESTA.GotFocus
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