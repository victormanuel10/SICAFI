Imports REGLAS_DEL_NEGOCIO

Public Class frm_consultar_PREDEXNI

    '========================================
    '*** CONSULTA PREDIOS EXENTOS POR NIT ***
    '========================================

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
            Dim stPRENDEPA As String = ""
            Dim stPRENMUNI As String = ""
            Dim stPRENCLSE As String = ""
            Dim stPRENTIIM As String = ""
            Dim stPRENCONC As String = ""
            Dim stPRENNUDO As String = ""
            Dim stPRENTIDO As String = ""
            Dim stPRENCAPR As String = ""
            Dim stPRENSEXO As String = ""
            Dim stPRENDESC As String = ""
            Dim stPRENESTA As String = ""

            ' carga los campos
            If Trim(Me.txtPRENDEPA.Text) = "" Then
                stPRENDEPA = "%"
            Else
                stPRENDEPA = Trim(Me.txtPRENDEPA.Text)
            End If

            ' carga los campos
            If Trim(Me.txtPRENMUNI.Text) = "" Then
                stPRENMUNI = "%"
            Else
                stPRENMUNI = Trim(Me.txtPRENMUNI.Text)
            End If

            ' carga los campos
            If Trim(Me.txtPRENCLSE.Text) = "" Then
                stPRENCLSE = "%"
            Else
                stPRENCLSE = Trim(Me.txtPRENCLSE.Text)
            End If

            ' carga los campos
            If Trim(Me.txtPRENTIIM.Text) = "" Then
                stPRENTIIM = "%"
            Else
                stPRENTIIM = Trim(Me.txtPRENTIIM.Text)
            End If

            ' carga los campos
            If Trim(Me.txtPRENCONC.Text) = "" Then
                stPRENCONC = "%"
            Else
                stPRENCONC = Trim(Me.txtPRENCONC.Text)
            End If

            ' carga los campos
            If Trim(Me.txtPRENNUDO.Text) = "" Then
                stPRENNUDO = "%"
            Else
                stPRENNUDO = Trim(Me.txtPRENNUDO.Text)
            End If

            ' carga los campos
            If Trim(Me.txtPRENTIDO.Text) = "" Then
                stPRENTIDO = "%"
            Else
                stPRENTIDO = Trim(Me.txtPRENTIDO.Text)
            End If

            ' carga los campos
            If Trim(Me.txtPRENCAPR.Text) = "" Then
                stPRENCAPR = "%"
            Else
                stPRENCAPR = Trim(Me.txtPRENCAPR.Text)
            End If

            ' carga los campos
            If Trim(Me.txtPRENSEXO.Text) = "" Then
                stPRENSEXO = "%"
            Else
                stPRENSEXO = Trim(Me.txtPRENSEXO.Text)
            End If

            ' carga los campos
            If Trim(Me.txtPRENDESC.Text) = "" Then
                stPRENDESC = "%"
            Else
                stPRENDESC = Trim(Me.txtPRENDESC.Text)
            End If

            ' carga los campos
            If Trim(Me.txtPRENESTA.Text) = "" Then
                stPRENESTA = "%"
            Else
                stPRENESTA = Trim(Me.txtPRENESTA.Text)
            End If

            'concatena la consulta
            stConsulta += "Select "
            stConsulta += "PRENIDRE , "
            stConsulta += "PRENDEPA as 'Departamento', "
            stConsulta += "PRENMUNI as 'Municipio', "
            stConsulta += "PRENCLSE as 'Sector', "
            stConsulta += "PRENTIIM as 'Tipo impuesto', "
            stConsulta += "PRENCONC as 'Concepto', "
            stConsulta += "PRENTIDO as 'Tipo documento', "
            stConsulta += "PRENCAPR as 'Calidad propietario', "
            stConsulta += "PRENSEXO as 'Sexo', "
            stConsulta += "PRENNUDO as 'Nro. documento', "
            stConsulta += "PRENESTA as 'Estado', "
            stConsulta += "PRENDESC as 'Descripción' "
            stConsulta += "From PREDEXNI "
            stConsulta += "Where "
            stConsulta += "PRENDEPA like '" & stPRENDEPA & "' and "
            stConsulta += "PRENMUNI like '" & stPRENMUNI & "' and "
            stConsulta += "PRENCLSE like '" & stPRENCLSE & "' and "
            stConsulta += "PRENTIIM like '" & stPRENTIIM & "' and "
            stConsulta += "PRENCONC like '" & stPRENCONC & "' and "
            stConsulta += "PRENTIDO like '" & stPRENTIDO & "' and "
            stConsulta += "PRENCAPR like '" & stPRENCAPR & "' and "
            stConsulta += "PRENSEXO like '" & stPRENSEXO & "' and "
            stConsulta += "PRENNUDO like '" & stPRENNUDO & "' and "
            stConsulta += "PRENDESC like '" & stPRENDESC & "' and "
            stConsulta += "PRENESTA like '" & stPRENESTA & "' "
            stConsulta += "Order by PRENDEPA, PRENMUNI, PRENCLSE, PRENTIIM, PRENCONC "

            ' instancia la clase y almacena la consulta
            Dim oConsulta As New cla_Consulta_ConexionString

            dt = oConsulta.fun_Consultar_ConexionString(stConsulta)

            Me.dgvCONSULTA.DataSource = dt

            Me.dgvCONSULTA.Columns(0).Visible = False

            ' verifica si existen datos consultados
            If Me.dgvCONSULTA.RowCount = 0 Then
                mod_MENSAJE.No_Se_Encontro_Ningun_registro()
                Me.cmdAceptar.Enabled = False
                Me.txtPRENDEPA.Focus()
            Else
                Me.cmdAceptar.Enabled = True
            End If

            Me.strBARRESTA.Items(2).Text = "Registros : " & dt.Rows.Count

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub pro_LimpiarCampos()

        Me.txtPRENDEPA.Text = ""
        Me.txtPRENMUNI.Text = ""
        Me.txtPRENCLSE.Text = ""
        Me.txtPRENTIIM.Text = ""
        Me.txtPRENCONC.Text = ""
        Me.txtPRENTIDO.Text = ""
        Me.txtPRENCAPR.Text = ""
        Me.txtPRENSEXO.Text = ""
        Me.txtPRENNUDO.Text = ""
        Me.txtPRENDESC.Text = ""
        Me.txtPRENESTA.Text = ""
       
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
            Dim inId_Reg As New frm_PREDEXNI(Integer.Parse(Me.dgvCONSULTA.SelectedRows.Item(0).Cells(0).Value.ToString()))
            Me.txtPRENDEPA.Focus()
            Me.Close()
        End If

    End Sub
    Private Sub cmdLimpiar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdLimpiar.Click
        pro_LimpiarCampos()
        Me.txtPRENDEPA.Focus()
    End Sub
    Private Sub cmdSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSalir.Click
        Me.Close()
    End Sub

#End Region

#Region "FORMULARIO"

#Region "Load"

    Private Sub Frm_Consultar_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        pro_LimpiarCampos()
        Me.txtPRENDEPA.Focus()
    End Sub

#End Region

#Region "KeyPress"

    Private Sub txt_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtPRENDEPA.KeyPress, txtPRENMUNI.KeyPress, txtPRENCLSE.KeyPress, txtPRENTIDO.KeyPress, txtPRENTIIM.KeyPress, txtPRENESTA.KeyPress, txtPRENCONC.KeyPress, txtPRENNUDO.KeyPress, txtPRENCAPR.KeyPress, txtPRENDESC.KeyPress, txtPRENSEXO.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            pp_pro_SaltarCampo()
        End If
    End Sub

#End Region

#Region "GotFocus"

    Private Sub txt_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtPRENDEPA.GotFocus, txtPRENMUNI.GotFocus, txtPRENCLSE.GotFocus, txtPRENTIDO.GotFocus, txtPRENTIIM.GotFocus, txtPRENESTA.GotFocus, txtPRENCONC.GotFocus, txtPRENNUDO.GotFocus, txtPRENCAPR.GotFocus, txtPRENDESC.GotFocus, txtPRENSEXO.GotFocus
        pp_pro_SobrearCampo(sender)
        pp_pro_DescripcionCampo(Me.strBARRESTA.Items(0), sender)
    End Sub
    Private Sub cmd_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdAceptar.GotFocus, cmdLimpiar.GotFocus, cmdConsultar.GotFocus, cmdSalir.GotFocus
        pp_pro_DescripcionCampo(Me.strBARRESTA.Items(0), sender)
    End Sub
    Private Sub chk_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs)
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