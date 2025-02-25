Imports REGLAS_DEL_NEGOCIO

Public Class frm_Comandos_CARPFOTO

    '======================================
    '*** INSERTAR CARPETAS FOTOGRAFICAS ***
    '======================================

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

            Me.cboCAFOESTA.DataSource = objdatos.fun_Consultar_TODOS_LOS_ESTADOS
            Me.cboCAFOESTA.DisplayMember = "ESTADESC"
            Me.cboCAFOESTA.ValueMember = "ESTACODI"

            Dim objdatos1 As New cla_CARPFOTO
            Dim tbl As New DataTable

            tbl = objdatos1.fun_Buscar_ID_MANT_CARPFOTO(inIDREGISTRO)

            Me.txtCAFOCODI.Text = CStr(Trim(tbl.Rows(0).Item("CAFOCODI").ToString))
            Me.txtCAFODESC.Text = CStr(Trim(tbl.Rows(0).Item("CAFODESC").ToString))
            Me.cboCAFOESTA.SelectedValue = tbl.Rows(0).Item("CAFOESTA").ToString

            Me.txtCAFOCODI.ReadOnly = True
            Me.ClientSize = New System.Drawing.Size(619, 230)
            Me.MaximumSize = New System.Drawing.Size(619, 230)
            Me.MinimumSize = New System.Drawing.Size(619, 230)
            Me.fraCOMANDOS2.Visible = False
            Me.fraCONSULTA.Visible = False
            Me.cmdGUARDAR.Visible = True

            boMODIFICAR = True

            Me.txtCAFOCODI.Enabled = False

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

        pp_pro_LimpiarCampos(fraCARPFOTO)

        Me.dgvCONSULTA.DataSource = New DataTable

    End Sub
    Private Sub pro_Consultar()

        Try
            ' instancia un dt
            dtTABLA = New DataTable

            ' crea la variable de consulta
            Dim stConsulta As String = ""

            ' crea la variable de los campos
            Dim stCLPRCODI As String = ""
            Dim stCLPRDESC As String = ""
            Dim stCLPRESTA As String = ""

            ' carga los campos
            If Trim(Me.txtCAFOCODI.Text) = "" Then
                stCLPRCODI = "%"
            Else
                stCLPRCODI = Trim(Me.txtCAFOCODI.Text)
            End If

            ' carga los campos
            If Trim(Me.txtCAFODESC.Text) = "" Then
                stCLPRDESC = "%"
            Else
                stCLPRDESC = Trim(Me.txtCAFODESC.Text)
            End If

            If Trim(Me.cboCAFOESTA.SelectedValue) = "" Then
                stCLPRESTA = "%"
            Else
                stCLPRESTA = Trim(Me.cboCAFOESTA.SelectedValue)
            End If

            'TIIMatena la consulta
            stConsulta += "Select "
            stConsulta += "CAFOIDRE , "
            stConsulta += "CAFOCODI as 'Codigo', "
            stConsulta += "CAFODESC as 'Descripción', "
            stConsulta += "CAFOESTA as 'Estado' "
            stConsulta += "From MANT_CARPFOTO "
            stConsulta += "Where "
            stConsulta += "CAFOCODI like '" & stCLPRCODI & "' and "
            stConsulta += "CAFODESC like '" & stCLPRDESC & "' and "
            stConsulta += "CAFOESTA like '" & stCLPRESTA & "' "
            stConsulta += "Order by CAFOCODI"

            ' instancia la clase y almacena la consulta
            Dim oConsulta As New cla_Consulta_ConexionString

            dtTABLA = oConsulta.fun_Consultar_ConexionString(stConsulta)

            Me.dgvCONSULTA.DataSource = dtTABLA

            Me.dgvCONSULTA.Columns(0).Visible = False

            ' verifica si existen datos consultados
            If Me.dgvCONSULTA.RowCount = 0 Then
                mod_MENSAJE.No_Se_Encontro_Ningun_registro()
                Me.cmdACEPTAR.Enabled = False
                Me.txtCAFOCODI.Focus()
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
            Dim objdatos As New cla_CARPFOTO

            Dim boLLAVEPRIMARIA As Boolean = objdatos.fun_Verifica_llave_Primaria_MANT_CARPFOTO(Me.txtCAFOCODI)

            Dim objVerifica As New cla_Verificar_Dato

            Dim boACADCODI As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Numerico(Me.txtCAFOCODI)
            Dim boACADDESC As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.txtCAFODESC)
            Dim boACADESTA As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboCAFOESTA)

            ' verifica los datos del formulario 
            If boLLAVEPRIMARIA = True And boACADCODI = True And boACADDESC = True And boACADESTA = True Then

                Dim objdatos22 As New cla_CARPFOTO

                If (objdatos22.fun_Insertar_MANT_CARPFOTO(Me.txtCAFOCODI.Text, Me.txtCAFODESC.Text, Me.cboCAFOESTA.SelectedValue)) Then
                    mod_MENSAJE.Se_Guardaron_Los_Datos_Correctamente()

                    If MessageBox.Show("¿ Desea agregar otro registro ?", "Mensaje...", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.No Then
                        Me.txtCAFOCODI.Focus()
                        Me.Close()
                    Else
                        pro_LimpiarCampos()
                        Me.txtCAFOCODI.Focus()
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

            Dim boTITRCODI As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Numerico(Me.txtCAFOCODI)
            Dim boTITRDESC As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.txtCAFODESC)
            Dim boTITRESTA As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboCAFOESTA)

            ' verifica los datos del formulario 
            If boTITRCODI = True And boTITRDESC = True And boTITRESTA = True Then

                Dim objdatos As New cla_CARPFOTO

                If objdatos.fun_Actualizar_MANT_CARPFOTO(inIDREGISTRO, Me.txtCAFOCODI.Text, Me.txtCAFODESC.Text, Me.cboCAFOESTA.SelectedValue) = True Then
                    Me.txtCAFODESC.Focus()
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
            Dim inId_Reg As New frm_ACTOADMI(Integer.Parse(Me.dgvCONSULTA.SelectedRows.Item(0).Cells(0).Value.ToString()))
            Me.txtCAFOCODI.Focus()
            Me.Close()
        End If

    End Sub
    Private Sub cmdLIMPIAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdLIMPIAR.Click
        pro_LimpiarCampos()
        Me.txtCAFOCODI.Focus()
    End Sub
    Private Sub cmdCANCELAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSALIR.Click
        Me.txtCAFOCODI.Focus()
        Me.Close()
    End Sub

#End Region

#Region "FORMULARIO"

#Region "KeyDown"

    Private Sub cboACADESTA_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboCAFOESTA.KeyDown
        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
            fun_Cargar_ComboBox_Con_Datos_Activos_ESTADO(Me.cboCAFOESTA, Me.cboCAFOESTA.SelectedIndex)
        End If
    End Sub

#End Region

#Region "KeyPress"

    Private Sub txt_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCAFOCODI.KeyPress, txtCAFODESC.KeyPress, cboCAFOESTA.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Or e.KeyChar = Convert.ToChar(Keys.Tab) Then
            pp_pro_SaltarCampo()
        End If
    End Sub

#End Region

#Region "GotFocus"

    Private Sub txt_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCAFOCODI.GotFocus, txtCAFODESC.GotFocus
        pp_pro_SobrearCampo(sender)
        pp_pro_DescripcionCampo(Me.strBARRESTA.Items(0), sender)
    End Sub
    Private Sub cmd_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdGUARDAR.GotFocus, cmdSALIR.GotFocus
        pp_pro_DescripcionCampo(Me.strBARRESTA.Items(0), sender)
    End Sub
    Private Sub cbo_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboCAFOESTA.GotFocus
        pp_pro_DescripcionCampo(Me.strBARRESTA.Items(0), sender)
    End Sub


#End Region

#Region "Click"

    Private Sub cboMOLIESTA_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboCAFOESTA.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_ESTADO(cboCAFOESTA, cboCAFOESTA.SelectedIndex)
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