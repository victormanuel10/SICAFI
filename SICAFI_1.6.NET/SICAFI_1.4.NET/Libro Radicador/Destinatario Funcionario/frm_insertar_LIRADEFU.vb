Imports REGLAS_DEL_NEGOCIO

Public Class frm_insertar_LIRADEFU

    '=============================================
    '*** LIBRO RADICADOR DESTINATARIO DIVISION ***
    '=============================================

#Region "VARIABLE"

    Dim inLRDFIDRE As Integer
    Dim inLRDFSECU As Integer
    Dim inLRDFNURA As Integer
    Dim stLRDFFERA As String
    Dim stLRDFNUDO As String

    Dim boINSERTAR As Boolean = False
    Dim boMODIFICAR As Boolean = False

#End Region

#Region "CONSTRUCTOR"

    Public Sub New(ByVal inIDRE As Integer, ByVal inSECU As Integer, ByVal inNURA As Integer, ByVal stFERA As String, ByVal stNUDO As String)
        inLRDFIDRE = inIDRE
        inLRDFSECU = inSECU
        inLRDFNURA = inNURA
        stLRDFFERA = stFERA
        stLRDFNUDO = stNUDO

        boMODIFICAR = True

        InitializeComponent()
        pro_LimpiarCampos()
        pro_inicializarControles()

    End Sub
    Public Sub New(ByVal inSECU As Integer, ByVal inNURA As Integer, ByVal stFERA As String)
        inLRDFSECU = inSECU
        inLRDFNURA = inNURA
        stLRDFFERA = stFERA

        boINSERTAR = True

        InitializeComponent()
        pro_LimpiarCampos()
        pro_inicializarControles()
    End Sub

#End Region

#Region "FUNCIONES"

    Private Function fun_ConsultaNombreUsuario(ByVal stNUMEDOCU As String) As String

        Try
            ' declara la variable
            Dim stUSUARIO As String = ""

            ' declara la instancia
            Dim obCONTRASENA As New cla_CONTRASENA
            Dim dtCONTRASENA As New DataTable

            dtCONTRASENA = obCONTRASENA.fun_Buscar_CODIGO_CONTRASENA(Trim(stNUMEDOCU))

            If dtCONTRASENA.Rows.Count > 0 Then
                stUSUARIO = Trim(dtCONTRASENA.Rows(0).Item("CONTUSUA").ToString)
            End If

            Return stUSUARIO

        Catch ex As Exception
            Return Nothing
            MessageBox.Show(Err.Description)
        End Try

    End Function

#End Region

#Region "PROCEDIMIENTOS"

    Private Sub pro_LimpiarCampos()

        Me.cboLRDFNUDO.DataSource = New DataTable

        Me.lblLRDFNUDO.Text = ""
        Me.txtLRDFFEAS.Text = ""
        Me.txtLRDFNRDE.Text = "0"
        Me.txtLRDFFEDE.Text = ""
        Me.lblLRDFNUDO.Text = ""

    End Sub
    Private Sub pro_inicializarControles()

        Try

            If boMODIFICAR = True Then

                ' instancia la clase
                Dim objdatos As New cla_LIRADEFU
                Dim tbl As New DataTable

                tbl = objdatos.fun_Buscar_ID_LIRADEFU(inLRDFIDRE)

                If tbl.Rows.Count > 0 Then

                    Me.Text = "Modificar registro"
                    Me.fraRECLTRCA.Text = "MODIFICAR DESTINATARIO FUNCIONARIO"

                    Dim objdatos1 As New cla_USUARIO

                    Me.cboLRDFNUDO.DataSource = objdatos1.fun_Buscar_CODIGO_USUARIO(Trim(stLRDFNUDO))
                    Me.cboLRDFNUDO.DisplayMember = "USUANOMB"
                    Me.cboLRDFNUDO.ValueMember = "USUANUDO"

                    Me.lblLRDFNUDO.Text = Trim(tbl.Rows(0).Item("LRDFNUDO"))

                    Me.txtLRDFFEAS.Text = Trim(tbl.Rows(0).Item("LRDFFEAS"))
                    Me.txtLRDFNRDE.Text = Trim(tbl.Rows(0).Item("LRDFNRDE"))
                    Me.txtLRDFFEDE.Text = Trim(tbl.Rows(0).Item("LRDFFEDE"))

                    Me.cboLRDFNUDO.Enabled = False

                End If

            ElseIf boINSERTAR = True Then

                Me.Text = "Insertar registro"
                Me.fraRECLTRCA.Text = "INSERTAR DESTINATARIO FUNCIONARIO"

                Me.txtLRDFFEAS.Text = fun_fecha()
                Me.txtLRDFNRDE.Text = inLRDFNURA
                Me.txtLRDFFEDE.Text = stLRDFFERA

            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub

#End Region

#Region "MENU"

    Private Sub cmdGUARDAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGUARDAR.Click

        Try
            ' inserta el registro
            If boINSERTAR = True Then

                ' instancia la clase
                Dim objdatos1 As New cla_LIRADEDI

                Dim boLLAVEPRIMARIA As Boolean = objdatos1.fun_Verifica_llave_Primaria_LIRADEDI(inLRDFNURA, Trim(stLRDFFERA), inLRDFSECU, Me.cboLRDFNUDO, Me.txtLRDFFEAS)

                ' instancia la clase
                Dim objVerifica As New cla_Verificar_Dato

                Dim boLRDFDIVI As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboLRDFNUDO)
                Dim boLRDFNRDE As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Numerico(Me.txtLRDFNRDE)
                Dim boLRDFFEAS As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Fecha(Me.txtLRDFFEAS)
                Dim boLEVAUSUA As Boolean = False

                Dim stMOGEUSUA As String = fun_ConsultaNombreUsuario(Trim(Me.lblLRDFNUDO.Text))

                If Trim(stMOGEUSUA) = "" Then
                    boLEVAUSUA = False
                    MessageBox.Show("El funcionario seleccionado no registra un perfil de usuario", "Mensaje...", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1)
                Else
                    boLEVAUSUA = True
                End If

                ' verifica los datos del formulario 
                If boLLAVEPRIMARIA = True And _
                   boLRDFDIVI = True And _
                   boLRDFNRDE = True And _
                   boLRDFFEAS = True And _
                   boLEVAUSUA = True Then

                    Dim objdatos22 As New cla_LIRADEFU

                    If (objdatos22.fun_Insertar_LIRADEFU(inLRDFNURA, _
                                                         stLRDFFERA, _
                                                         inLRDFSECU, _
                                                         Me.cboLRDFNUDO.SelectedValue, _
                                                         Me.txtLRDFFEAS.Text, _
                                                         stMOGEUSUA, _
                                                         Me.txtLRDFNRDE.Text, _
                                                         Me.txtLRDFFEDE.Text)) = True Then

                        mod_MENSAJE.Se_Guardaron_Los_Datos_Correctamente()
                        Me.cboLRDFNUDO.Focus()
                        Me.Close()
                    Else
                        mod_MENSAJE.No_Se_Guardo_El_Registro_En_La_Base_De_Datos()
                    End If

                End If

                ' modifica el registro
            ElseIf boMODIFICAR = True Then

                ' instancia la clase
                Dim objVerifica As New cla_Verificar_Dato

                Dim boLEVANUDO As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.lblLRDFNUDO)
                Dim boLRDFNRDE As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Numerico(Me.txtLRDFNRDE)
                Dim boLEVAFEEN As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Fecha(Me.txtLRDFFEAS)

                ' verifica los datos del formulario 
                If boLEVANUDO = True And _
                   boLRDFNRDE = True And _
                   boLEVAFEEN = True Then

                    Dim objdatos22 As New cla_LIRADEFU

                    If (objdatos22.fun_Actualizar_LIRADEFU(inLRDFIDRE, _
                                                           inLRDFNURA, _
                                                           stLRDFFERA, _
                                                           inLRDFSECU, _
                                                           stLRDFNUDO, _
                                                           Me.txtLRDFFEAS.Text, _
                                                           Me.txtLRDFNRDE.Text, _
                                                           Me.txtLRDFFEDE.Text)) = True Then

                        mod_MENSAJE.Se_Guardaron_Los_Datos_Correctamente()
                        Me.cboLRDFNUDO.Focus()
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
        Me.cboLRDFNUDO.Focus()
        Me.Close()
    End Sub

#End Region

#Region "FORMULARIO"

#Region "KeyPress"

    Private Sub txt_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboLRDFNUDO.KeyPress, txtLRDFFEAS.KeyPress, txtLRDFNRDE.KeyPress, txtLRDFFEDE.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Or e.KeyChar = Convert.ToChar(Keys.Tab) Then
            pp_pro_SaltarCampo()
        End If
    End Sub

#End Region

#Region "GotFocus"

    Private Sub txt_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtLRDFFEAS.GotFocus, txtLRDFNRDE.GotFocus
        pp_pro_SobrearCampo(sender)
        pp_pro_DescripcionCampo(Me.strBARRESTA.Items(0), sender)
    End Sub
    Private Sub cbo_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboLRDFNUDO.GotFocus
        pp_pro_DescripcionCampo(Me.strBARRESTA.Items(0), sender)
    End Sub
    Private Sub cmd_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdGUARDAR.GotFocus, cmdSALIR.GotFocus
        pp_pro_DescripcionCampo(Me.strBARRESTA.Items(0), sender)
    End Sub

#End Region

#Region "KeyDown"

    Private Sub cboLRDFDIVI_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboLRDFNUDO.KeyDown
        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
            fun_Cargar_ComboBox_Con_Datos_Activos_USUARIO_Descripcion(Me.cboLRDFNUDO, Me.cboLRDFNUDO.SelectedIndex)
        End If
    End Sub

#End Region

#Region "SelectedIndexChanged"

    Private Sub cboLEVANUDO_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboLRDFNUDO.SelectedIndexChanged
        Me.lblLRDFNUDO.Text = CType(fun_Buscar_Lista_Valores_USUARIO_Codigo(Me.cboLRDFNUDO), String)
    End Sub

#End Region

#Region "Click"

    Private Sub cboLRDFDIVI_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboLRDFNUDO.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_USUARIO_Descripcion(Me.cboLRDFNUDO, Me.cboLRDFNUDO.SelectedIndex)
    End Sub

#End Region

#Region "ValueChanged"

    Private Sub dtpLRDFFEDE_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpLRDFFEDE.ValueChanged
        Me.txtLRDFFEDE.Text = Me.dtpLRDFFEDE.Value
    End Sub
    Private Sub dtpLRDFFEAS_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpLRDFFEAS.ValueChanged
        Me.txtLRDFFEAS.Text = Me.dtpLRDFFEAS.Value
    End Sub

#End Region

#Region "Validated"

    Private Sub txtLRDFNRDE_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtLRDFNRDE.Validated

        If Trim(sender.text) = "" Then
            sender.text = 0
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