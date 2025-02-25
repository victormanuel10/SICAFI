Imports REGLAS_DEL_NEGOCIO

Public Class frm_comandos_CAMPOS

    '=======================
    '*** COMANDOS CAMPOS ***
    '=======================

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

            Me.ClientSize = New System.Drawing.Size(690, 400)
            Me.MaximumSize = New System.Drawing.Size(690, 400)
            Me.MinimumSize = New System.Drawing.Size(690, 400)
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

            Dim objdatos11 As New cla_PROCEDIMIENTO

            Me.cboCAMPPROC.DataSource = objdatos11.fun_Consultar_CAMPOS_PROCEDIMIENTO
            Me.cboCAMPPROC.DisplayMember = "PROCDESC"
            Me.cboCAMPPROC.ValueMember = "PROCCODI"

            Dim objdatos12 As New cla_TABLAS

            Me.cboCAMPTABL.DataSource = objdatos12.fun_Consultar_CAMPOS_MANT_TABLAS
            Me.cboCAMPTABL.DisplayMember = "TABLDESC"
            Me.cboCAMPTABL.ValueMember = "TABLCODI"

            Dim objdatos As New cla_ESTADO

            Me.cboCAMPESTA.DataSource = objdatos.fun_Consultar_TODOS_LOS_ESTADOS
            Me.cboCAMPESTA.DisplayMember = "ESTADESC"
            Me.cboCAMPESTA.ValueMember = "ESTACODI"

            Dim objdatos1 As New cla_CAMPOS
            Dim tbl As New DataTable

            tbl = objdatos1.fun_Buscar_ID_MANT_CAMPOS(inIDREGISTRO)

            Me.cboCAMPPROC.SelectedValue = tbl.Rows(0).Item("CAMPPROC")
            Me.cboCAMPTABL.SelectedValue = tbl.Rows(0).Item("CAMPTABL")
            Me.txtCAMPCODI.Text = CStr(Trim(tbl.Rows(0).Item("CAMPCODI")))
            Me.txtCAMPDESC.Text = CStr(Trim(tbl.Rows(0).Item("CAMPDESC")))
            Me.chkCAMPLLPR.Checked = CBool(tbl.Rows(0).Item("CAMPLLPR"))
            Me.chkCAMPREQU.Checked = CBool(tbl.Rows(0).Item("CAMPREQU"))

            If CStr(Trim(tbl.Rows(0).Item("CAMPTIDA").ToString)) = "A" Then
                Me.rbdCAMPTIDA_ALFA.Checked = True
            ElseIf CStr(Trim(tbl.Rows(0).Item("CAMPTIDA").ToString)) = "N" Then
                Me.rbdCAMPTIDA_NUME.Checked = True
            ElseIf CStr(Trim(tbl.Rows(0).Item("CAMPTIDA").ToString)) = "D" Then
                Me.rbdCAMPTIDA_DECI.Checked = True
            End If

            Me.txtCAMPLONG.Text = CInt(tbl.Rows(0).Item("CAMPLONG"))
            Me.chkCAMPCOND.Checked = CBool(tbl.Rows(0).Item("CAMPCOND"))
            Me.chkCAMPMANT.Checked = CBool(tbl.Rows(0).Item("CAMPMANT"))
            Me.chkCAMPSIST.Checked = CBool(tbl.Rows(0).Item("CAMPSIST"))

            Dim stTABLMANT As String = Trim(tbl.Rows(0).Item("CAMPTAMA"))
            Dim stTABLSIST As String = Trim(tbl.Rows(0).Item("CAMPTASI"))

            If Trim(stTABLMANT) <> "" Then

                Dim objdatos13 As New cla_TABLAS

                Me.cboCAMPTAMA.DataSource = objdatos13.fun_Consultar_CAMPOS_MANT_TABLAS
                Me.cboCAMPTAMA.DisplayMember = "TABLDESC"
                Me.cboCAMPTAMA.ValueMember = "TABLCODI"

                Me.cboCAMPTAMA.SelectedValue = tbl.Rows(0).Item("CAMPTAMA")

                Dim boCAMPTAMA As Boolean = fun_Buscar_Dato_TABLAS(Me.cboCAMPTAMA.SelectedValue)

                If boCAMPTAMA = True Then
                    Me.lblCAMPTAMA.Text = CType(fun_Buscar_Lista_Valores_TABLAS_Codigo(Me.cboCAMPTAMA), String)
                End If
            Else
                Me.txtCAMPLLMA.Enabled = False

            End If

            If Trim(stTABLSIST) <> "" Then

                Dim objdatos14 As New cla_TABLAS

                Me.cboCAMPTASI.DataSource = objdatos14.fun_Consultar_CAMPOS_MANT_TABLAS
                Me.cboCAMPTASI.DisplayMember = "TABLDESC"
                Me.cboCAMPTASI.ValueMember = "TABLCODI"

                Me.cboCAMPTASI.SelectedValue = tbl.Rows(0).Item("CAMPTASI")

                Dim boCAMPTASI As Boolean = fun_Buscar_Dato_TABLAS(Me.cboCAMPTASI.SelectedValue)

                If boCAMPTASI = True Then
                    Me.lblCAMPTASI.Text = CType(fun_Buscar_Lista_Valores_TABLAS_Codigo(Me.cboCAMPTASI), String)
                End If
            Else
                Me.txtCAMPLLSI.Enabled = False

            End If

            Me.cboCAMPESTA.SelectedValue = tbl.Rows(0).Item("CAMPESTA")
            Me.txtCAMPLLMA.Text = Trim(tbl.Rows(0).Item("CAMPLLMA"))
            Me.txtCAMPLLSI.Text = Trim(tbl.Rows(0).Item("CAMPLLSI"))

            Dim boCAMPPROC As Boolean = fun_Buscar_Dato_PROCEDIMIENTO(Me.cboCAMPPROC.SelectedValue)
            Dim boCAMPTABL As Boolean = fun_Buscar_Dato_TABLAS(Me.cboCAMPTABL.SelectedValue)

            If boCAMPPROC = True And boCAMPTABL = True Then
                Me.lblCAMPPROC.Text = CType(fun_Buscar_Lista_Valores_PROCEDIMIENTO_Codigo(Me.cboCAMPPROC), String)
                Me.lblCAMPTABL.Text = CType(fun_Buscar_Lista_Valores_TABLAS_Codigo(Me.cboCAMPTABL), String)
            End If

            Me.cboCAMPPROC.Enabled = False
            Me.cboCAMPTABL.Enabled = False
            Me.txtCAMPCODI.ReadOnly = True
            Me.ClientSize = New System.Drawing.Size(690, 400)
            Me.MaximumSize = New System.Drawing.Size(690, 400)
            Me.MinimumSize = New System.Drawing.Size(690, 400)
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

            Me.ClientSize = New System.Drawing.Size(690, 627)
            Me.MaximumSize = New System.Drawing.Size(690, 627)
            Me.MinimumSize = New System.Drawing.Size(690, 627)
            Me.fraCOMANDOS2.Visible = True
            Me.fraCONSULTA.Visible = True
            Me.cmdGUARDAR.Visible = False

            boCONSULTAR = True

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try



    End Sub

    Private Sub pro_LimpiarCampos()

        pp_pro_LimpiarCampos(fraCAMPOS)

        Me.lblCAMPPROC.Text = ""
        Me.lblCAMPTABL.Text = ""
        Me.lblCAMPTAMA.Text = ""
        Me.lblCAMPTASI.Text = ""

        Me.dgvCONSULTA.DataSource = New DataTable

    End Sub
    Private Sub pro_Consultar()

        Try
            ' instancia un dt
            dtTABLA = New DataTable

            ' crea la variable de consulta
            Dim stConsulta As String = ""

            ' crea la variable de los campos
            Dim stCAMPPROC As String = ""
            Dim stCAMPTABL As String = ""
            Dim stCAMPCODI As String = ""
            Dim stCAMPDESC As String = ""
            Dim stCAMPLONG As String = ""
            Dim stCAMPTAMA As String = ""
            Dim stCAMPTASI As String = ""
            Dim stCAMPESTA As String = ""
            Dim stCAMPLLMA As String = ""
            Dim stCAMPLLSI As String = ""

            ' carga los campos
            If Trim(Me.cboCAMPPROC.SelectedValue) = "" Then
                stCAMPPROC = "%"
            Else
                stCAMPPROC = Trim(Me.cboCAMPPROC.SelectedValue)
            End If

            If Trim(Me.cboCAMPTABL.SelectedValue) = "" Then
                stCAMPTABL = "%"
            Else
                stCAMPTABL = Trim(Me.cboCAMPTABL.SelectedValue)
            End If

            If Trim(Me.txtCAMPCODI.Text) = "" Then
                stCAMPCODI = "%"
            Else
                stCAMPCODI = Trim(Me.txtCAMPCODI.Text)
            End If

            If Trim(Me.txtCAMPDESC.Text) = "" Then
                stCAMPDESC = "%"
            Else
                stCAMPDESC = Trim(Me.txtCAMPDESC.Text)
            End If

            If Trim(Me.txtCAMPLONG.Text) = "" Then
                stCAMPLONG = "%"
            Else
                stCAMPLONG = Trim(Me.txtCAMPLONG.Text)
            End If

            If Trim(Me.cboCAMPTAMA.SelectedValue) = "" Then
                stCAMPTAMA = "%"
            Else
                stCAMPTAMA = Trim(Me.cboCAMPTAMA.SelectedValue)
            End If

            If Trim(Me.cboCAMPTASI.SelectedValue) = "" Then
                stCAMPTASI = "%"
            Else
                stCAMPTASI = Trim(Me.cboCAMPTASI.SelectedValue)
            End If

            If Trim(Me.cboCAMPESTA.SelectedValue) = "" Then
                stCAMPESTA = "%"
            Else
                stCAMPESTA = Trim(Me.cboCAMPESTA.SelectedValue)
            End If

            If Trim(Me.txtCAMPLLMA.Text) = "" Then
                stCAMPLLMA = "%"
            Else
                stCAMPLLMA = Trim(Me.txtCAMPLLMA.Text)
            End If

            If Trim(Me.txtCAMPLLSI.Text) = "" Then
                stCAMPLLSI = "%"
            Else
                stCAMPLLSI = Trim(Me.txtCAMPLLSI.Text)
            End If

            ' concatena la consulta
            stConsulta += "Select "
            stConsulta += "CAMPIDRE , "
            stConsulta += "CAMPPROC as 'Procedimiento', "
            stConsulta += "CAMPTABL as 'Tabla', "
            stConsulta += "CAMPCODI as 'Campo', "
            stConsulta += "CAMPDESC as 'Descripción', "
            stConsulta += "CAMPLONG as 'Longitud', "
            stConsulta += "CAMPTIDA as 'Tipo Dato', "
            stConsulta += "CAMPLLPR as 'Llave primaria', "
            stConsulta += "CAMPREQU as 'Requerido', "
            stConsulta += "CAMPCOND as 'Condicional', "
            stConsulta += "CAMPMANT as 'Mantenimiento', "
            stConsulta += "CAMPTAMA as 'Tabla Mant.', "
            stConsulta += "CAMPSIST as 'Sistema', "
            stConsulta += "CAMPTASI as 'Table Sist.', "
            stConsulta += "CAMPESTA as 'Estado', "
            stConsulta += "CAMPLLMA as 'Llave mantenimiento', "
            stConsulta += "CAMPLLSI as 'Llave sistema' "
            stConsulta += "From MANT_CAMPOS "
            stConsulta += "Where "
            stConsulta += "CAMPPROC like '" & stCAMPPROC & "' and "
            stConsulta += "CAMPTABL like '" & stCAMPTABL & "' and "
            stConsulta += "CAMPCODI like '" & stCAMPCODI & "' and "
            stConsulta += "CAMPDESC like '" & stCAMPDESC & "' and "
            stConsulta += "CAMPLONG like '" & stCAMPLONG & "' and "
            stConsulta += "CAMPTAMA like '" & stCAMPTAMA & "' and "
            stConsulta += "CAMPTASI like '" & stCAMPTASI & "' and "
            stConsulta += "CAMPESTA like '" & stCAMPESTA & "' and "
            stConsulta += "CAMPLLMA like '" & stCAMPLLMA & "' and "
            stConsulta += "CAMPLLSI like '" & stCAMPLLSI & "' "
            stConsulta += "Order by CAMPPROC, CAMPTABL, CAMPCODI"

            ' instancia la clase y almacena la consulta
            Dim oConsulta As New cla_Consulta_ConexionString

            dtTABLA = oConsulta.fun_Consultar_ConexionString(stConsulta)

            Me.dgvCONSULTA.DataSource = dtTABLA

            Me.dgvCONSULTA.Columns(0).Visible = False

            ' verifica si existen datos consultados
            If Me.dgvCONSULTA.RowCount = 0 Then
                mod_MENSAJE.No_Se_Encontro_Ningun_registro()
                Me.cmdACEPTAR.Enabled = False
                Me.txtCAMPCODI.Focus()
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
            Dim objdatos As New cla_CAMPOS

            Dim boLLAVEPRIMARIA As Boolean = objdatos.fun_Verifica_llave_Primaria_MANT_CAMPOS(Me.cboCAMPPROC, Me.cboCAMPTABL, Me.txtCAMPCODI)

            Dim objVerifica As New cla_Verificar_Dato

            Dim boCAMPPROC As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboCAMPPROC)
            Dim boCAMPTABL As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboCAMPTABL)
            Dim boCAMPCODI As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.txtCAMPCODI)
            Dim boCAMPDESC As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.txtCAMPDESC)
            Dim boCAMPLONG As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Numerico(Me.txtCAMPLONG)
            Dim boCAMPESTA As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboCAMPESTA)

            ' verifica los datos del formulario 
            If boLLAVEPRIMARIA = True And _
               boCAMPPROC = True And _
               boCAMPTABL = True And _
               boCAMPCODI = True And _
               boCAMPDESC = True And _
               boCAMPLONG = True And _
               boCAMPESTA = True Then

                Dim stCAMPTIDA As String = ""

                If Me.rbdCAMPTIDA_NUME.Checked = True Then
                    stCAMPTIDA = "N"
                ElseIf Me.rbdCAMPTIDA_ALFA.Checked = True Then
                    stCAMPTIDA = "A"
                ElseIf Me.rbdCAMPTIDA_DECI.Checked = True Then
                    stCAMPTIDA = "D"
                End If

                Dim objdatos22 As New cla_CAMPOS

                If objdatos22.fun_Insertar_MANT_CAMPOS(Me.cboCAMPPROC.SelectedValue, _
                                                        Me.cboCAMPTABL.SelectedValue, _
                                                        Me.txtCAMPCODI.Text, _
                                                        Me.txtCAMPDESC.Text, _
                                                        Me.chkCAMPLLPR.Checked, _
                                                        Me.chkCAMPREQU.Checked, _
                                                        stCAMPTIDA, _
                                                        Me.txtCAMPLONG.Text, _
                                                        Me.chkCAMPCOND.Checked, _
                                                        Me.chkCAMPMANT.Checked, _
                                                        Me.cboCAMPTAMA.SelectedValue, _
                                                        Me.chkCAMPSIST.Checked, _
                                                        Me.cboCAMPTASI.SelectedValue, _
                                                        Me.cboCAMPESTA.SelectedValue, _
                                                        Me.txtCAMPLLMA.Text, _
                                                        Me.txtCAMPLLSI.Text) = True Then
                    mod_MENSAJE.Se_Guardaron_Los_Datos_Correctamente()

                    If MessageBox.Show("¿ Desea agregar otro registro ?", "Mensaje...", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.No Then
                        Me.cboCAMPPROC.Focus()
                        Me.Close()
                    Else
                        'pro_LimpiarCampos()
                        Me.cboCAMPPROC.Focus()
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

            Dim boCAMPPROC As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboCAMPPROC)
            Dim boCAMPTABL As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboCAMPTABL)
            Dim boCAMPCODI As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.txtCAMPCODI)
            Dim boCAMPDESC As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.txtCAMPDESC)
            Dim boCAMPLONG As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Numerico(Me.txtCAMPLONG)
            Dim boCAMPESTA As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboCAMPESTA)

            ' verifica los datos del formulario 
            If boCAMPPROC = True And _
               boCAMPTABL = True And _
               boCAMPCODI = True And _
               boCAMPDESC = True And _
               boCAMPLONG = True And _
               boCAMPESTA = True Then

                If Me.chkCAMPMANT.Checked = True Then
                    Dim boCAMPTAMA As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboCAMPTAMA)
                    Dim boCAMPLLMA As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.txtCAMPLLMA)

                    If boCAMPTAMA = False Or boCAMPLLMA = False Then
                        Exit Sub
                    End If
                End If

                If Me.chkCAMPSIST.Checked = True Then
                    Dim boCAMPTASI As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboCAMPTASI)
                    Dim boCAMPLLSI As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.txtCAMPLLSI)

                    If boCAMPTASI = False Or boCAMPLLSI = False Then
                        Exit Sub
                    End If
                End If

                Dim stCAMPTIDA As String = ""

                If Me.rbdCAMPTIDA_NUME.Checked = True Then
                    stCAMPTIDA = "N"
                ElseIf Me.rbdCAMPTIDA_ALFA.Checked = True Then
                    stCAMPTIDA = "A"
                ElseIf Me.rbdCAMPTIDA_DECI.Checked = True Then
                    stCAMPTIDA = "D"
                End If

                Dim objdatos As New cla_CAMPOS

                If objdatos.fun_Actualizar_MANT_CAMPOS(inIDREGISTRO, _
                                                       Me.cboCAMPPROC.SelectedValue, _
                                                        Me.cboCAMPTABL.SelectedValue, _
                                                        Me.txtCAMPCODI.Text, _
                                                        Me.txtCAMPDESC.Text, _
                                                        Me.chkCAMPLLPR.Checked, _
                                                        Me.chkCAMPREQU.Checked, _
                                                        stCAMPTIDA, _
                                                        Me.txtCAMPLONG.Text, _
                                                        Me.chkCAMPCOND.Checked, _
                                                        Me.chkCAMPMANT.Checked, _
                                                        Me.cboCAMPTAMA.SelectedValue, _
                                                        Me.chkCAMPSIST.Checked, _
                                                        Me.cboCAMPTASI.SelectedValue, _
                                                        Me.cboCAMPESTA.SelectedValue, _
                                                        Me.txtCAMPLLMA.Text, _
                                                        Me.txtCAMPLLSI.Text) = True Then
                    Me.txtCAMPDESC.Focus()
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
            Dim inId_Reg As New frm_CAMPOS(Integer.Parse(Me.dgvCONSULTA.SelectedRows.Item(0).Cells(0).Value.ToString()))
            Me.txtCAMPCODI.Focus()
            Me.Close()
        End If

    End Sub
    Private Sub cmdLIMPIAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdLIMPIAR.Click
        pro_LimpiarCampos()
        Me.txtCAMPCODI.Focus()
    End Sub
    Private Sub cmdCANCELAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSALIR.Click
        Me.txtCAMPCODI.Focus()
        Me.Close()
    End Sub

#End Region

#Region "FORMULARIO"

#Region "KeyPress"

    Private Sub txt_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboCAMPPROC.KeyPress, cboCAMPTABL.KeyPress, txtCAMPCODI.KeyPress, txtCAMPDESC.KeyPress, txtCAMPLONG.KeyPress, chkCAMPLLPR.KeyPress, chkCAMPREQU.KeyPress, chkCAMPCOND.KeyPress, chkCAMPMANT.KeyPress, cboCAMPTAMA.KeyPress, chkCAMPSIST.KeyPress, cboCAMPTASI.KeyPress, cboCAMPESTA.KeyPress, txtCAMPLLMA.KeyPress, txtCAMPLLSI.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Or e.KeyChar = Convert.ToChar(Keys.Tab) Then
            pp_pro_SaltarCampo()
        End If
    End Sub

#End Region

#Region "GotFocus"

    Private Sub txt_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCAMPCODI.GotFocus, txtCAMPDESC.GotFocus, txtCAMPLONG.GotFocus, txtCAMPLLMA.GotFocus, txtCAMPLLSI.GotFocus
        pp_pro_SobrearCampo(sender)
        pp_pro_DescripcionCampo(Me.strBARRESTA.Items(0), sender)
    End Sub
    Private Sub cmd_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdGUARDAR.GotFocus, cmdSALIR.GotFocus
        pp_pro_DescripcionCampo(Me.strBARRESTA.Items(0), sender)
    End Sub
    Private Sub cbo_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboCAMPESTA.GotFocus, cboCAMPPROC.GotFocus, cboCAMPTABL.GotFocus, cboCAMPTAMA.GotFocus, cboCAMPTASI.GotFocus
        pp_pro_DescripcionCampo(Me.strBARRESTA.Items(0), sender)
    End Sub


#End Region

#Region "KeyDown"

    Private Sub cboCAMPPROC_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboCAMPPROC.KeyDown
        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
            fun_Cargar_ComboBox_Con_Datos_Activos_PROCEDIMIENTO_Descripcion(Me.cboCAMPPROC, Me.cboCAMPPROC.SelectedIndex)
        End If
    End Sub
    Private Sub cboCAMPTABL_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboCAMPTABL.KeyDown
        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
            fun_Cargar_ComboBox_Con_Datos_Activos_TABLAS_Descripcion(Me.cboCAMPTABL, Me.cboCAMPTABL.SelectedIndex)
        End If
    End Sub
    Private Sub cboCAMPTAMA_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboCAMPTAMA.KeyDown
        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
            fun_Cargar_ComboBox_Con_Datos_Activos_TABLAS_Descripcion(Me.cboCAMPTAMA, Me.cboCAMPTAMA.SelectedIndex)
        End If
    End Sub
    Private Sub cboCAMPTASI_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboCAMPTASI.KeyDown
        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
            fun_Cargar_ComboBox_Con_Datos_Activos_TABLAS_Descripcion(Me.cboCAMPTASI, Me.cboCAMPTASI.SelectedIndex)
        End If
    End Sub
    Private Sub cboCAMPESTA_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboCAMPESTA.KeyDown
        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
            fun_Cargar_ComboBox_Con_Datos_Activos_ESTADO(Me.cboCAMPESTA, Me.cboCAMPESTA.SelectedIndex)
        End If
    End Sub

#End Region

#Region "Click"

    Private Sub cboCAMPPROC_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboCAMPPROC.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_PROCEDIMIENTO_Descripcion(Me.cboCAMPPROC, Me.cboCAMPPROC.SelectedIndex)
    End Sub
    Private Sub cboCAMPTABL_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboCAMPTABL.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_TABLAS_Descripcion(Me.cboCAMPTABL, Me.cboCAMPTABL.SelectedIndex)
    End Sub
    Private Sub cboCAMPTAMA_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboCAMPTAMA.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_TABLAS_Descripcion(Me.cboCAMPTAMA, Me.cboCAMPTAMA.SelectedIndex)
    End Sub
    Private Sub cboCAMPTASI_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboCAMPTASI.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_TABLAS_Descripcion(Me.cboCAMPTASI, Me.cboCAMPTASI.SelectedIndex)
    End Sub
    Private Sub cboMOLIESTA_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboCAMPESTA.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_ESTADO(cboCAMPESTA, cboCAMPESTA.SelectedIndex)
    End Sub

#End Region

#Region "SelectedIndexChanged"

    Private Sub cboCAMPPROC_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCAMPPROC.SelectedIndexChanged
        Me.lblCAMPPROC.Text = CType(fun_Buscar_Lista_Valores_PROCEDIMIENTO_Codigo(Me.cboCAMPPROC), String)
    End Sub
    Private Sub cboCAMPTABL_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCAMPTABL.SelectedIndexChanged
        Me.lblCAMPTABL.Text = CType(fun_Buscar_Lista_Valores_TABLAS_Codigo(Me.cboCAMPTABL), String)
    End Sub
    Private Sub cboCAMPTAMA_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCAMPTAMA.SelectedIndexChanged
        Me.lblCAMPTAMA.Text = CType(fun_Buscar_Lista_Valores_TABLAS_Codigo(Me.cboCAMPTAMA), String)
    End Sub
    Private Sub cboCAMPTASI_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCAMPTASI.SelectedIndexChanged
        Me.lblCAMPTASI.Text = CType(fun_Buscar_Lista_Valores_TABLAS_Codigo(Me.cboCAMPTASI), String)
    End Sub

#End Region

#Region "CheckedChanged"

    Private Sub chkCAMPMANT_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkCAMPMANT.CheckedChanged

        If Me.chkCAMPMANT.Checked = False Then
            Me.cboCAMPTAMA.DataSource = New DataTable
            Me.cboCAMPTAMA.Enabled = False
            Me.txtCAMPLLMA.Text = ""
            Me.txtCAMPLLMA.Enabled = False
            Me.lblCAMPTAMA.Text = ""
            Me.chkCAMPREQU.Enabled = True
        Else
            Me.cboCAMPTAMA.DataSource = New DataTable
            Me.cboCAMPTAMA.Enabled = True
            Me.txtCAMPLLMA.Enabled = True
            Me.lblCAMPTAMA.Text = ""
            Me.chkCAMPREQU.Checked = True
            Me.chkCAMPREQU.Enabled = False
        End If

    End Sub
    Private Sub chkCAMPSIST_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkCAMPSIST.CheckedChanged

        If Me.chkCAMPSIST.Checked = False Then
            Me.cboCAMPTASI.DataSource = New DataTable
            Me.cboCAMPTASI.Enabled = False
            Me.txtCAMPLLSI.Text = ""
            Me.txtCAMPLLSI.Enabled = False
            Me.lblCAMPTASI.Text = ""
            Me.chkCAMPREQU.Enabled = True
        Else
            Me.cboCAMPTASI.DataSource = New DataTable
            Me.cboCAMPTASI.Enabled = True
            Me.txtCAMPLLSI.Enabled = True
            Me.lblCAMPTASI.Text = ""
            Me.chkCAMPREQU.Checked = True
            Me.chkCAMPREQU.Enabled = False
        End If

    End Sub
    Private Sub rbdCAMPTIDA_ALFA_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbdCAMPTIDA_ALFA.CheckedChanged
        If rbdCAMPTIDA_ALFA.Checked = True Then
            Me.chkCAMPREQU.Enabled = True
        End If
    End Sub
    Private Sub rbdCAMPTIDA_NUME_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbdCAMPTIDA_NUME.CheckedChanged
        If rbdCAMPTIDA_NUME.Checked = True Then
            Me.txtCAMPLONG.Text = 9
            Me.chkCAMPREQU.Checked = True
            Me.chkCAMPREQU.Enabled = False
        End If
    End Sub
    Private Sub rbdCAMPTIDA_DECI_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbdCAMPTIDA_DECI.CheckedChanged
        If rbdCAMPTIDA_DECI.Checked = True Then
            Me.txtCAMPLONG.Text = 9
            Me.chkCAMPREQU.Checked = True
            Me.chkCAMPREQU.Enabled = False
        End If
    End Sub
    Private Sub chkCAMPLLPR_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkCAMPLLPR.CheckedChanged
        If chkCAMPLLPR.Checked = True Then
            Me.chkCAMPREQU.Checked = True
            Me.chkCAMPREQU.Enabled = False
        Else
            Me.chkCAMPREQU.Enabled = True
        End If
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