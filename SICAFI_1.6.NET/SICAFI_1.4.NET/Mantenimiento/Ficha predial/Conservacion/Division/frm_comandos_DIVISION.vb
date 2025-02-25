Imports REGLAS_DEL_NEGOCIO

Public Class frm_comandos_DIVISION

    '=========================
    '*** COMANDOS DIVISION ***
    '=========================

#Region "VARIABLES"

    Dim boINSERTAR As Boolean = False
    Dim boMODIFICAR As Boolean = False
    Dim boCONSULTAR As Boolean = False

    Dim inIDREGISTRO As Integer = 0

    Dim dtTABLA As DataTable

#End Region

#Region "CONSTRUCTOR"

    ''' <summary>
    ''' constructor para insertar
    ''' </summary>
    Public Sub New(ByVal inRegistroInsertar As Boolean, ByVal inRegistroConsultar As Boolean)
        boINSERTAR = inRegistroInsertar
        boCONSULTAR = inRegistroConsultar

        InitializeComponent()

        If boINSERTAR = True Then

            pro_LimpiarCampos()
            pro_InicializarControlesInsertar()

        End If

        If boCONSULTAR = True Then

            pro_LimpiarCampos()
            pro_InicializarControlesConsultar()

        End If

    End Sub

    ''' <summary>
    ''' constructor para modificar
    ''' </summary>
    Public Sub New(ByVal inRegistroModificar As Integer)
        inIDREGISTRO = inRegistroModificar

        InitializeComponent()

        pro_LimpiarCampos()
        pro_InicializarControlesModificar()

    End Sub

#End Region

#Region "PROCEDIMIENTOS"

    Private Sub pro_InicializarControlesInsertar()

        Try
            Me.Text = "Insertar registro"
            Me.ClientSize = New System.Drawing.Size(619, 230)
            Me.MaximumSize = New System.Drawing.Size(619, 230)
            Me.MinimumSize = New System.Drawing.Size(619, 230)
            Me.fraCOMANDOS2.Visible = False
            Me.fraCONSULTA.Visible = False
            Me.cmdGUARDAR.Visible = True

            boINSERTAR = True

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub pro_InicializarControlesModificar()

        Try
            Me.Text = "Modificar registro"

            Dim objdatos As New cla_ESTADO

            Me.cboDIVIESTA.DataSource = objdatos.fun_Consultar_TODOS_LOS_ESTADOS
            Me.cboDIVIESTA.DisplayMember = "ESTADESC"
            Me.cboDIVIESTA.ValueMember = "ESTACODI"

            Dim objdatos1 As New cla_DIVISION
            Dim tbl As New DataTable

            tbl = objdatos1.fun_Buscar_ID_MANT_DIVISION(inIDREGISTRO)

            Me.txtDIVICODI.Text = CStr(Trim(tbl.Rows(0).Item("DIVICODI").ToString))
            Me.txtDIVIDESC.Text = CStr(Trim(tbl.Rows(0).Item("DIVIDESC").ToString))
            Me.cboDIVIESTA.SelectedValue = tbl.Rows(0).Item("DIVIESTA").ToString

            Me.txtDIVICODI.ReadOnly = True
            Me.ClientSize = New System.Drawing.Size(619, 230)
            Me.MaximumSize = New System.Drawing.Size(619, 230)
            Me.MinimumSize = New System.Drawing.Size(619, 230)
            Me.fraCOMANDOS2.Visible = False
            Me.fraCONSULTA.Visible = False
            Me.cmdGUARDAR.Visible = True

            boMODIFICAR = True

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub pro_InicializarControlesConsultar()

        Try
            Me.Text = "Consultar registro"
            Me.ClientSize = New System.Drawing.Size(619, 483)
            Me.MaximumSize = New System.Drawing.Size(619, 483)
            Me.MinimumSize = New System.Drawing.Size(619, 483)
            Me.fraCOMANDOS2.Visible = True
            Me.fraCONSULTA.Visible = True
            Me.cmdGUARDAR.Visible = False

            boCONSULTAR = True

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try



    End Sub

    Private Sub pro_LimpiarCampos()

        pp_pro_LimpiarCampos(fraDIVISION)

        Me.dgvCONSULTA.DataSource = New DataTable

    End Sub
    Private Sub pro_Consultar()

        Try
            ' instancia un dt
            dtTABLA = New DataTable

            ' crea la variable de consulta
            Dim stConsulta As String = ""

            ' crea la variable de los campos
            Dim stDIVICODI As String = ""
            Dim stDIVIDESC As String = ""
            Dim stDIVIESTA As String = ""

            ' carga los campos
            If Trim(Me.txtDIVICODI.Text) = "" Then
                stDIVICODI = "%"
            Else
                stDIVICODI = Trim(Me.txtDIVICODI.Text)
            End If

            ' carga los campos
            If Trim(Me.txtDIVIDESC.Text) = "" Then
                stDIVIDESC = "%"
            Else
                stDIVIDESC = Trim(Me.txtDIVIDESC.Text)
            End If

            If Trim(Me.cboDIVIESTA.SelectedValue) = "" Then
                stDIVIESTA = "%"
            Else
                stDIVIESTA = Trim(Me.cboDIVIESTA.SelectedValue)
            End If

            'TIIMatena la consulta
            stConsulta += "Select "
            stConsulta += "DIVIIDRE , "
            stConsulta += "DIVICODI as 'Codigo', "
            stConsulta += "DIVIDESC as 'Descripción', "
            stConsulta += "DIVIESTA as 'Estado' "
            stConsulta += "From MANT_DIVISION "
            stConsulta += "Where "
            stConsulta += "DIVICODI like '" & stDIVICODI & "' and "
            stConsulta += "DIVIDESC like '" & stDIVIDESC & "' and "
            stConsulta += "DIVIESTA like '" & stDIVIESTA & "' "
            stConsulta += "Order by DIVICODI"

            ' instancia la clase y almacena la consulta
            Dim oConsulta As New cla_Consulta_ConexionString

            dtTABLA = oConsulta.fun_Consultar_ConexionString(stConsulta)

            Me.dgvCONSULTA.DataSource = dtTABLA

            Me.dgvCONSULTA.Columns(0).Visible = False

            ' verifica si existen datos consultados
            If Me.dgvCONSULTA.RowCount = 0 Then
                mod_MENSAJE.No_Se_Encontro_Ningun_registro()
                Me.cmdACEPTAR.Enabled = False
                Me.txtDIVICODI.Focus()
            Else
                Me.cmdACEPTAR.Enabled = True
            End If

            Me.strBARRESTA.Items(2).Text = "Registros : " & dtTABLA.Rows.Count

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub pro_Insertar()

        Try
            ' instancia la clase
            Dim objdatos As New cla_DIVISION

            Dim boLLAVEPRIMARIA As Boolean = objdatos.fun_Verifica_llave_Primaria_MANT_DIVISION(Me.txtDIVICODI)

            Dim objVerifica As New cla_Verificar_Dato

            Dim boDIVICODI As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Numerico(Me.txtDIVICODI)
            Dim boDIVIDESC As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.txtDIVIDESC)
            Dim boDIVIESTA As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboDIVIESTA)

            ' verifica los datos del formulario 
            If boLLAVEPRIMARIA = True And boDIVICODI = True And boDIVIDESC = True And boDIVIESTA = True Then

                Dim objdatos22 As New cla_DIVISION

                If (objdatos22.fun_Insertar_MANT_DIVISION(Me.txtDIVICODI.Text, Me.txtDIVIDESC.Text, Me.cboDIVIESTA.SelectedValue)) = True Then
                    mod_MENSAJE.Se_Guardaron_Los_Datos_Correctamente()

                    If MessageBox.Show("¿ Desea agregar otro registro ?", "Mensaje...", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.No Then
                        Me.txtDIVICODI.Focus()
                        Me.Close()
                    Else
                        pro_LimpiarCampos()
                        Me.txtDIVICODI.Focus()
                    End If

                Else
                    mod_MENSAJE.No_Se_Guardo_El_Registro_En_La_Base_De_Datos()
                End If
            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description & "Guardar")
        End Try

    End Sub
    Private Sub pro_Modificar()

        Try

            Dim objVerifica As New cla_Verificar_Dato

            Dim boTITRCODI As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Numerico(Me.txtDIVICODI)
            Dim boTITRDESC As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.txtDIVIDESC)
            Dim boTITRESTA As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboDIVIESTA)

            ' verifica los datos del formulario 
            If boTITRCODI = True And boTITRDESC = True And boTITRESTA = True Then

                Dim objdatos As New cla_DIVISION

                If objdatos.fun_Actualizar_MANT_DIVISION(inIDREGISTRO, Me.txtDIVICODI.Text, Me.txtDIVIDESC.Text, Me.cboDIVIESTA.SelectedValue) = True Then
                    Me.txtDIVIDESC.Focus()
                    Me.Close()

                    mod_MENSAJE.Se_Modificaron_Los_Datos_Correctamente()
                Else
                    mod_MENSAJE.No_Se_Modifico_El_Registro_En_La_Base_De_Datos()
                End If
            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub

#End Region

#Region "MENU"

    Private Sub cmdGUARDAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGUARDAR.Click

        If boINSERTAR = True Then
            pro_Insertar()

        ElseIf boMODIFICAR = True Then
            pro_Modificar()

        ElseIf boCONSULTAR Then
            pro_Consultar()

        End If

    End Sub
    Private Sub cmdCONSULTAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCONSULTAR.Click

        Try
            pro_Consultar()

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub cmdACEPTAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdACEPTAR.Click

        If Me.dgvCONSULTA.RowCount = 0 Then
            MessageBox.Show("No existen registro seleccionados", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
        Else
            Dim inId_Reg As New frm_DIVISION(Integer.Parse(Me.dgvCONSULTA.SelectedRows.Item(0).Cells(0).Value.ToString()))
            Me.txtDIVICODI.Focus()
            Me.Close()
        End If

    End Sub
    Private Sub cmdLIMPIAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdLIMPIAR.Click
        pro_LimpiarCampos()
        Me.txtDIVICODI.Focus()
    End Sub
    Private Sub cmdCANCELAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSALIR.Click
        Me.txtDIVICODI.Focus()
        Me.Close()
    End Sub

#End Region

#Region "FORMULARIO"

#Region "KeyDown"

    Private Sub cboDIVIESTA_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboDIVIESTA.KeyDown
        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
            fun_Cargar_ComboBox_Con_Datos_Activos_ESTADO(Me.cboDIVIESTA, Me.cboDIVIESTA.SelectedIndex)
        End If
    End Sub

#End Region

#Region "KeyPress"

    Private Sub txt_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtDIVICODI.KeyPress, txtDIVIDESC.KeyPress, cboDIVIESTA.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Or e.KeyChar = Convert.ToChar(Keys.Tab) Then
            pp_pro_SaltarCampo()
        End If
    End Sub

#End Region

#Region "GotFocus"

    Private Sub txt_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtDIVICODI.GotFocus, txtDIVIDESC.GotFocus
        pp_pro_SobrearCampo(sender)
        pp_pro_DescripcionCampo(Me.strBARRESTA.Items(0), sender)
    End Sub
    Private Sub cmd_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdGUARDAR.GotFocus, cmdSALIR.GotFocus
        pp_pro_DescripcionCampo(Me.strBARRESTA.Items(0), sender)
    End Sub
    Private Sub cbo_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboDIVIESTA.GotFocus
        pp_pro_DescripcionCampo(Me.strBARRESTA.Items(0), sender)
    End Sub


#End Region

#Region "Click"

    Private Sub cboMOLIESTA_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboDIVIESTA.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_ESTADO(cboDIVIESTA, cboDIVIESTA.SelectedIndex)
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