Imports REGLAS_DEL_NEGOCIO

Public Class frm_insertar_OBUREJOB

    '============================================================
    '*** INSERTAR EJECUCION DE OBRA OBLIGACIONES URBANISTICAS ***
    '============================================================

#Region "VARIABLE"

    Dim inOUEOIDRE As Integer
    Dim stOUEOCLEN As String
    Dim inOUEONURE As Integer
    Dim stOUEOFERE As String
    Dim inOUEOCLOU As Integer
    Dim inOUEOSECU As Integer
    Dim stOUEONDSU As String

    Dim boINSERTAR As Boolean = False
    Dim boMODIFICAR As Boolean = False

#End Region

#Region "CONSTRUCTOR"

    Public Sub New(ByVal inIDRE As Integer, ByVal inSECU As Integer, ByVal stCLEN As String, ByVal inNURE As Integer, ByVal stFERE As String, ByVal stNDSU As String)
        inOUEOIDRE = inIDRE
        inOUEOSECU = inSECU
        stOUEOCLEN = stCLEN
        inOUEONURE = inNURE
        stOUEOFERE = stFERE
        stOUEONDSU = stNDSU

        boMODIFICAR = True

        InitializeComponent()
        pro_LimpiarCampos()
        pro_inicializarControles()

    End Sub
    Public Sub New(ByVal inSECU As Integer, ByVal stCLEN As String, ByVal inNURE As Integer, ByVal stFERE As String)
        inOUEOSECU = inSECU
        stOUEOCLEN = stCLEN
        inOUEONURE = inNURE
        stOUEOFERE = stFERE

        boINSERTAR = True

        InitializeComponent()
        pro_LimpiarCampos()
        pro_inicializarControles()
    End Sub

#End Region

#Region "PROCEDIMIENTOS"

    Private Sub pro_LimpiarCampos()

        Me.txtOUEONUME.Text = ""
        Me.txtOUEONUOF.Text = "0"
        Me.txtOUEOVAOB.Text = "0"
        Me.txtOUEOVADI.Text = "0"
        Me.txtOUEOACLI.Text = ""
        Me.txtOUEODESC.Text = ""
        Me.txtOUEOOBSE.Text = ""
        Me.lblOUEONDSU.Text = ""

        Me.cboOUEOCLOU.DataSource = New DataTable
        Me.cboOUEOSUPE.DataSource = New DataTable
        Me.cboOUEOESTA.DataSource = New DataTable

    End Sub
    Private Sub pro_inicializarControles()

        Try
            If boMODIFICAR = True Then

                ' instancia la clase
                Dim objdatos As New cla_OBUREJOB
                Dim tbl As New DataTable

                tbl = objdatos.fun_Buscar_ID_OBUREJOB(inOUEOIDRE)

                If tbl.Rows.Count > 0 Then

                    Me.Text = "Modificar registro"
                    Me.fraCEDUCATA.Text = "MODIFICAR EJECUCIÓN DE OBRA"

                    Me.txtOUEONUME.ReadOnly = True

                    Me.txtOUEONUME.Text = Trim(tbl.Rows(0).Item("OUEONUME"))
                    Me.txtOUEOCOCO.Text = Trim(tbl.Rows(0).Item("OUEOCOCO"))
                    Me.txtOUEOCOOB.Text = Trim(tbl.Rows(0).Item("OUEOCOOB"))

                    Dim objdatos11 As New cla_CLASOBUR

                    Me.cboOUEOCLOU.DataSource = objdatos11.fun_Consultar_CAMPOS_MANT_CLASOBUR
                    Me.cboOUEOCLOU.DisplayMember = "CLOUDESC"
                    Me.cboOUEOCLOU.ValueMember = "CLOUCODI"

                    Me.cboOUEOCLOU.SelectedValue = tbl.Rows(0).Item("OUEOCLOU")

                    Me.txtOUEONUOF.Text = Trim(tbl.Rows(0).Item("OUEONUOF"))
                    Me.txtOUEOCONT.Text = Trim(tbl.Rows(0).Item("OUEOCONT"))

                    Dim objdatos2 As New cla_USUARIO

                    Me.cboOUEOSUPE.DataSource = objdatos2.fun_Buscar_CODIGO_USUARIO(Trim(stOUEONDSU))
                    Me.cboOUEOSUPE.DisplayMember = "USUANOMB"
                    Me.cboOUEOSUPE.ValueMember = "USUANUDO"

                    Me.lblOUEONDSU.Text = Trim(tbl.Rows(0).Item("OUEONDSU"))

                    Me.txtOUEOVAOB.Text = fun_Formato_Mascara_Pesos_Enteros(Trim(tbl.Rows(0).Item("OUEOVAOB")))
                    Me.txtOUEOVACO.Text = fun_Formato_Mascara_Pesos_Enteros(Trim(tbl.Rows(0).Item("OUEOVACO")))
                    Me.txtOUEOVADI.Text = fun_Formato_Mascara_Pesos_Enteros(Trim(tbl.Rows(0).Item("OUEOVADI")))

                    Dim objdatos12 As New cla_FOPAPLPA

                    Me.cboOUEOFOPA.DataSource = objdatos12.fun_Consultar_CAMPOS_MANT_FOPAPLPA
                    Me.cboOUEOFOPA.DisplayMember = "FPPPDESC"
                    Me.cboOUEOFOPA.ValueMember = "FPPPCODI"

                    Me.cboOUEOCLOU.SelectedValue = tbl.Rows(0).Item("OUEOFOPA")

                    Me.nudOUEONUCU.Value = tbl.Rows(0).Item("OUEONUCU")
                    Me.chkOUEOAPCO.Checked = tbl.Rows(0).Item("OUEOAPCO")

                    Me.txtOUEONUPO.Text = Trim(tbl.Rows(0).Item("OUEONUPO"))
                    Me.txtOUEONUCA.Text = Trim(tbl.Rows(0).Item("OUEONUCA"))
                    Me.txtOUEOACLI.Text = Trim(tbl.Rows(0).Item("OUEOACLI"))

                    Me.nudOUEOPLDI.Value = tbl.Rows(0).Item("OUEOPLDI")

                    Me.txtOUEOFEIN.Text = Trim(tbl.Rows(0).Item("OUEOFEIN"))
                    Me.txtOUEOFEFI.Text = Trim(tbl.Rows(0).Item("OUEOFEFI"))
                    Me.txtOUEODESC.Text = Trim(tbl.Rows(0).Item("OUEODESC"))
                    Me.txtOUEOOBCO.Text = Trim(tbl.Rows(0).Item("OUEOOBCO"))
                    Me.txtOUEOOBSE.Text = Trim(tbl.Rows(0).Item("OUEOOBSE"))

                    Dim objdatos3 As New cla_ESTADO

                    Me.cboOUEOESTA.DataSource = objdatos3.fun_Consultar_TODOS_LOS_ESTADOS
                    Me.cboOUEOESTA.DisplayMember = "ESTADESC"
                    Me.cboOUEOESTA.ValueMember = "ESTACODI"

                    Me.cboOUEOESTA.SelectedValue = tbl.Rows(0).Item("OUEOESTA")

                    Me.lblOUEOCLOU.Text = CType(fun_Buscar_Lista_Valores_CLASOBUR_Codigo(Me.cboOUEOCLOU), String)
                    Me.lblOUEOFOPA.Text = CType(fun_Buscar_Lista_Valores_FOPAPLPA_Codigo(Me.cboOUEOFOPA), String)

                End If

            ElseIf boINSERTAR = True Then

                Me.Text = "Insertar registro"
                Me.fraCEDUCATA.Text = "INSERTAR EJECUCIÓN DE OBRA"

                Me.txtOUEONUME.Text = fun_NumeroDeSecuenciaDeRegistro()

            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub

#End Region

#Region "FUNCIONES"

    Private Function fun_NumeroDeSecuenciaDeRegistro() As Integer

        Try
            Dim inOBURSECU As Integer = 0

            Dim objdatos55 As New cla_OBUREJOB
            Dim tbl10 As New DataTable

            tbl10 = objdatos55.fun_Buscar_CODIGO_X_OBUREJOB(stOUEOCLEN, inOUEONURE, stOUEOFERE)

            If tbl10.Rows.Count = 0 Then
                inOBURSECU = 1
            Else
                Dim i As Integer
                Dim NroMayor As Integer
                Dim Posicion As Integer

                Posicion = Val(tbl10.Rows(0).Item("OUEONUME"))

                For i = 0 To tbl10.Rows.Count - 1
                    NroMayor = Val(tbl10.Rows(i).Item("OUEONUME"))

                    If NroMayor > Posicion Then
                        inOBURSECU = NroMayor
                        Posicion = NroMayor
                    Else
                        inOBURSECU = Posicion
                    End If
                Next

                inOBURSECU += 1
            End If

            Return inOBURSECU

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Function

#End Region

#Region "MENU"

    Private Sub cmdGUARDAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGUARDAR.Click

        Try
            ' inserta el registro
            If boINSERTAR = True Then

                ' quita letras
                Me.txtOUEOVAOB.Text = fun_Quita_Letras(Trim(Me.txtOUEOVAOB.Text))
                Me.txtOUEOVACO.Text = fun_Quita_Letras(Trim(Me.txtOUEOVACO.Text))
                Me.txtOUEOVADI.Text = fun_Quita_Letras(Trim(Me.txtOUEOVADI.Text))

                ' instancia la clase
                Dim objdatos As New cla_OBURADPR

                Dim boLLAVEPRIMARIA As Boolean = objdatos.fun_Verifica_llave_Primaria_OBURADPR(stOUEOCLEN, inOUEONURE, stOUEOFERE, Me.txtOUEONUME)

                ' instancia la clase
                Dim objVerifica As New cla_Verificar_Dato

                Dim boOUEOCOCO As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.txtOUEOCOCO)
                Dim boOUEOCOOB As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.txtOUEOCOOB)
                Dim boOUEOCLOU As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboOUEOCLOU)
                Dim boOUEONUME As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Numerico(Me.txtOUEONUME)
                Dim boOUEONUOF As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Numerico(Me.txtOUEONUOF)
                Dim boOUEOCONT As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.txtOUEOCONT)
                Dim boOUEOSUPE As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboOUEOSUPE)
                Dim boOUEOACLI As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Numerico(Me.txtOUEOACLI)
                Dim boOUEOVAOB As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Numerico(Me.txtOUEOVAOB)
                Dim boOUEOVACO As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Numerico(Me.txtOUEOVACO)
                Dim boOUEOVADI As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Numerico(Me.txtOUEOVADI)
                Dim boOUEOFOPA As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboOUEOFOPA)
                Dim boOUEOESTA As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboOUEOESTA)

                ' verifica los datos del formulario 
                If boLLAVEPRIMARIA = True And _
                   boOUEOCOCO = True And _
                   boOUEOCOOB = True And _
                   boOUEONUME = True And _
                   boOUEONUOF = True And _
                   boOUEOCONT = True And _
                   boOUEOACLI = True And _
                   boOUEOVAOB = True And _
                   boOUEOVACO = True And _
                   boOUEOVADI = True And _
                   boOUEOFOPA = True And _
                   boOUEOSUPE = True And _
                   boOUEOCLOU = True And _
                   boOUEOESTA = True Then

                    Dim objdatos22 As New cla_OBUREJOB

                    If (objdatos22.fun_Insertar_OBUREJOB(inOUEOSECU, _
                                                         stOUEOCLEN, _
                                                         inOUEONURE, _
                                                         stOUEOFERE, _
                                                         Me.txtOUEONUME.Text, _
                                                         Me.txtOUEOCOCO.Text, _
                                                         Me.txtOUEOCOOB.Text, _
                                                         Me.cboOUEOCLOU.SelectedValue, _
                                                         Me.txtOUEONUOF.Text, _
                                                         Me.txtOUEOCONT.Text, _
                                                         Me.cboOUEOSUPE.SelectedValue, _
                                                         Me.lblOUEONDSU.Text, _
                                                         Me.txtOUEOVAOB.Text, _
                                                         Me.txtOUEOVACO.Text, _
                                                         Me.txtOUEOVADI.Text, _
                                                         Me.cboOUEOFOPA.SelectedValue, _
                                                         Me.nudOUEONUCU.Value, _
                                                         Me.chkOUEOAPCO.Checked, _
                                                         Me.txtOUEONUPO.Text, _
                                                         Me.txtOUEONUCA.Text, _
                                                         Me.txtOUEOACLI.Text, _
                                                         Me.nudOUEOPLDI.Value, _
                                                         Me.txtOUEOFEIN.Text, _
                                                         Me.txtOUEOFEFI.Text, _
                                                         Me.txtOUEODESC.Text, _
                                                         Me.txtOUEOOBSE.Text, _
                                                         Me.txtOUEOOBCO.Text, _
                                                         Me.cboOUEOESTA.SelectedValue)) = True Then

                        mod_MENSAJE.Se_Guardaron_Los_Datos_Correctamente()
                        Me.cboOUEOCLOU.Focus()
                        Me.Close()
                    Else
                        mod_MENSAJE.No_Se_Guardo_El_Registro_En_La_Base_De_Datos()
                    End If

                End If

                ' modifica el registro
            ElseIf boMODIFICAR = True Then

                ' quita letras
                Me.txtOUEOVAOB.Text = fun_Quita_Letras(Trim(Me.txtOUEOVAOB.Text))
                Me.txtOUEOVACO.Text = fun_Quita_Letras(Trim(Me.txtOUEOVACO.Text))
                Me.txtOUEOVADI.Text = fun_Quita_Letras(Trim(Me.txtOUEOVADI.Text))

                ' instancia la clase
                Dim objVerifica As New cla_Verificar_Dato

                Dim boOUEOCOCO As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.txtOUEOCOCO)
                Dim boOUEOCOOB As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.txtOUEOCOOB)
                Dim boOUEOCLOU As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboOUEOCLOU)
                Dim boOUEONUME As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Numerico(Me.txtOUEONUME)
                Dim boOUEONUOF As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Numerico(Me.txtOUEONUOF)
                Dim boOUEOCONT As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.txtOUEOCONT)
                Dim boOUEOSUPE As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboOUEOSUPE)
                Dim boOUEOACLI As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Numerico(Me.txtOUEOACLI)
                Dim boOUEOVAOB As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Numerico(Me.txtOUEOVAOB)
                Dim boOUEOVACO As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Numerico(Me.txtOUEOVACO)
                Dim boOUEOVADI As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Numerico(Me.txtOUEOVADI)
                Dim boOUEOFOPA As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboOUEOFOPA)
                Dim boOUEOESTA As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboOUEOESTA)

                ' verifica los datos del formulario 
                If boOUEOCOCO = True And _
                   boOUEOCOOB = True And _
                   boOUEONUME = True And _
                   boOUEONUOF = True And _
                   boOUEOCONT = True And _
                   boOUEOACLI = True And _
                   boOUEOVAOB = True And _
                   boOUEOVACO = True And _
                   boOUEOVADI = True And _
                   boOUEOFOPA = True And _
                   boOUEOSUPE = True And _
                   boOUEOCLOU = True And _
                   boOUEOESTA = True Then

                    Dim objdatos22 As New cla_OBUREJOB

                    If (objdatos22.fun_Actualizar_OBUREJOB(inOUEOIDRE, _
                                                           inOUEOSECU, _
                                                           stOUEOCLEN, _
                                                           inOUEONURE, _
                                                           stOUEOFERE, _
                                                           Me.txtOUEONUME.Text, _
                                                           Me.txtOUEOCOCO.Text, _
                                                           Me.txtOUEOCOOB.Text, _
                                                           Me.cboOUEOCLOU.SelectedValue, _
                                                           Me.txtOUEONUOF.Text, _
                                                           Me.txtOUEOCONT.Text, _
                                                           Me.cboOUEOSUPE.SelectedValue, _
                                                           Me.lblOUEONDSU.Text, _
                                                           Me.txtOUEOVAOB.Text, _
                                                           Me.txtOUEOVACO.Text, _
                                                           Me.txtOUEOVADI.Text, _
                                                           Me.cboOUEOFOPA.SelectedValue, _
                                                           Me.nudOUEONUCU.Value, _
                                                           Me.chkOUEOAPCO.Checked, _
                                                           Me.txtOUEONUPO.Text, _
                                                           Me.txtOUEONUCA.Text, _
                                                           Me.txtOUEOACLI.Text, _
                                                           Me.nudOUEOPLDI.Value, _
                                                           Me.txtOUEOFEIN.Text, _
                                                           Me.txtOUEOFEFI.Text, _
                                                           Me.txtOUEODESC.Text, _
                                                           Me.txtOUEOOBSE.Text, _
                                                           Me.txtOUEOOBCO.Text, _
                                                           Me.cboOUEOESTA.SelectedValue)) = True Then

                        mod_MENSAJE.Se_Guardaron_Los_Datos_Correctamente()
                        Me.cboOUEOCLOU.Focus()
                        Me.Close()
                    Else
                        mod_MENSAJE.No_Se_Guardo_El_Registro_En_La_Base_De_Datos()
                    End If

                End If

            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub cmdCANCELAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSALIR.Click
        Me.cboOUEOCLOU.Focus()
        Me.Close()
    End Sub

#End Region

#Region "FORMULARIO"

#Region "SelectedIndexChanged"

    Private Sub cboOUIGCLOU_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboOUEOCLOU.SelectedIndexChanged
        Me.lblOUEOCLOU.Text = CType(fun_Buscar_Lista_Valores_CLASOBUR_Codigo(Me.cboOUEOCLOU), String)
    End Sub
    Private Sub cboOUEOFOPA_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboOUEOFOPA.SelectedIndexChanged
        Me.lblOUEOFOPA.Text = CType(fun_Buscar_Lista_Valores_FOPAPLPA_Codigo(Me.cboOUEOFOPA), String)
    End Sub
    Private Sub cboOUAPSUPE_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboOUEOSUPE.SelectedIndexChanged
        Me.lblOUEONDSU.Text = CType(fun_Buscar_Lista_Valores_USUARIO_Codigo(Me.cboOUEOSUPE), String)
    End Sub

#End Region

#Region "KeyPress"

    Private Sub txt_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtOUEONUME.KeyPress, txtOUEONUOF.KeyPress, txtOUEOACLI.KeyPress, txtOUEOVAOB.KeyPress, cboOUEOCLOU.KeyPress, cboOUEOSUPE.KeyPress, txtOUEOVADI.KeyPress, cboOUEOESTA.KeyPress, txtOUEOCOCO.KeyPress, txtOUEOCOOB.KeyPress, txtOUEOCONT.KeyPress, txtOUEOVACO.KeyPress, cboOUEOFOPA.KeyPress, nudOUEONUCU.KeyPress, nudOUEOPLDI.KeyPress, txtOUEOOBCO.KeyPress, txtOUEOFEIN.KeyPress, txtOUEOFEFI.KeyPress, chkOUEOAPCO.KeyPress, txtOUEONUPO.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Or e.KeyChar = Convert.ToChar(Keys.Tab) Then
            pp_pro_SaltarCampo()
        End If
    End Sub

#End Region

#Region "KeyDown"

    Private Sub cboOUIGCLOU_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboOUEOCLOU.KeyDown
        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
            fun_Cargar_ComboBox_Con_Datos_Activos_CLASOBUR_Descripcion(Me.cboOUEOCLOU, Me.cboOUEOCLOU.SelectedIndex)
        End If
    End Sub
    Private Sub cboOUEOFOPA_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboOUEOFOPA.KeyDown
        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
            fun_Cargar_ComboBox_Con_Datos_Activos_FOPAPLPA_Descripcion(Me.cboOUEOFOPA, Me.cboOUEOFOPA.SelectedIndex)
        End If
    End Sub
    Private Sub cboOUAPSUPE_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboOUEOSUPE.KeyDown
        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
            fun_Cargar_ComboBox_Con_Datos_Activos_USUARIO_Descripcion(Me.cboOUEOSUPE, Me.cboOUEOSUPE.SelectedIndex)
        End If
    End Sub
    Private Sub cboOUAPESTA_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboOUEOESTA.KeyDown
        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
            fun_Cargar_ComboBox_Con_Datos_Activos_ESTADO_Descripcion(Me.cboOUEOESTA, Me.cboOUEOESTA.SelectedIndex)
        End If
    End Sub

#End Region

#Region "Click"

    Private Sub cboOUIGCLOU_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboOUEOCLOU.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_CLASOBUR_Descripcion(Me.cboOUEOCLOU, Me.cboOUEOCLOU.SelectedIndex)
    End Sub
    Private Sub cboOUEOFOPA_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboOUEOFOPA.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_FOPAPLPA_Descripcion(Me.cboOUEOFOPA, Me.cboOUEOFOPA.SelectedIndex)
    End Sub
    Private Sub cboOUAPSUPE_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboOUEOSUPE.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_USUARIO_Descripcion(Me.cboOUEOSUPE, Me.cboOUEOSUPE.SelectedIndex)
    End Sub
    Private Sub cboOUAPESTA_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboOUEOESTA.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_ESTADO_Descripcion(Me.cboOUEOESTA, Me.cboOUEOESTA.SelectedIndex)
    End Sub

#End Region

#Region "GotFocus"

    Private Sub txt_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtOUEONUOF.GotFocus, txtOUEOACLI.GotFocus, txtOUEOVAOB.GotFocus, txtOUEOVAOB.GotFocus, txtOUEOVADI.GotFocus, txtOUEOCOCO.GotFocus, txtOUEOCOOB.GotFocus, txtOUEOCONT.GotFocus, txtOUEOVACO.GotFocus, txtOUEONUPO.GotFocus, txtOUEONUCA.GotFocus
        pp_pro_SobrearCampo(sender)
        pp_pro_DescripcionCampo(Me.strBARRESTA.Items(0), sender)
    End Sub
    Private Sub cmd_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdGUARDAR.GotFocus, cmdSALIR.GotFocus
        pp_pro_DescripcionCampo(Me.strBARRESTA.Items(0), sender)
    End Sub
    Private Sub cbo_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboOUEOESTA.GotFocus, cboOUEOSUPE.GotFocus, cboOUEOCLOU.GotFocus, cboOUEOSUPE.GotFocus, cboOUEOESTA.GotFocus, cboOUEOFOPA.GotFocus, nudOUEONUCU.GotFocus, nudOUEOPLDI.GotFocus
        pp_pro_DescripcionCampo(Me.strBARRESTA.Items(0), sender)
    End Sub

#End Region

#Region "Validated"

    Private Sub txtOUAPMAIN_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtOUEOVAOB.Validated, txtOUEOVADI.Validated, txtOUEOVACO.Validated

        If Trim(sender.text) = "" Then
            sender.text = 0
        Else

            If fun_Verificar_Dato_Numerico_Evento_Validated(Me.txtOUEOVAOB.Text) = True Then
                Me.txtOUEOVAOB.Text = fun_Formato_Mascara_Pesos_Enteros(Me.txtOUEOVAOB.Text)
            End If

            If fun_Verificar_Dato_Numerico_Evento_Validated(Me.txtOUEOVADI.Text) = True Then
                Me.txtOUEOVADI.Text = fun_Formato_Mascara_Pesos_Enteros(Me.txtOUEOVADI.Text)
            End If

            If fun_Verificar_Dato_Numerico_Evento_Validated(Me.txtOUEOVACO.Text) = True Then
                Me.txtOUEOVACO.Text = fun_Formato_Mascara_Pesos_Enteros(Me.txtOUEOVACO.Text)
            End If

        End If

    End Sub

#End Region

#Region "ValueChanged"

    Private Sub dtpRECOFERE_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpOUEOFEIN.ValueChanged
        Me.txtOUEOFEIN.Text = Me.dtpOUEOFEIN.Value
    End Sub
    Private Sub dtpRECOFERA_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpOUEOFEFI.ValueChanged
        Me.txtOUEOFEFI.Text = Me.dtpOUEOFEFI.Value
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