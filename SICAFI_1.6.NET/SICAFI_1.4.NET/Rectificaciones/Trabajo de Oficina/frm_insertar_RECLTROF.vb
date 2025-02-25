Imports REGLAS_DEL_NEGOCIO

Public Class frm_insertar_RECLTROF

    '===================================
    '*** TRABAJO DE OFICINA RECLAMOS ***
    '===================================

#Region "VARIABLE"

    Dim inID_REGISTRO As Integer
    Dim inLEVASECU As Integer
    Dim stLEVANUDO As String

    Dim boINSERTAR As Boolean = False
    Dim boMODIFICAR As Boolean = False

#End Region

#Region "CONSTRUCTOR"

    Public Sub New(ByVal inSECU As Integer)
        inLEVASECU = inSECU

        boINSERTAR = True

        InitializeComponent()
        pro_LimpiarCampos()
        pro_inicializarControles()
    End Sub
    Public Sub New(ByVal inIDRE As Integer, ByVal inSECU As Integer, ByVal stNUDO As String)
        inID_REGISTRO = inIDRE
        inLEVASECU = inSECU
        stLEVANUDO = stNUDO

        boMODIFICAR = True

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

        Me.cboRETONUDO.DataSource = New DataTable

        Me.txtRETONUDO.Text = ""
        Me.txtRETOFEEN.Text = ""
        Me.txtRETOOBSE.Text = ""

    End Sub
    Private Sub pro_inicializarControles()

        Try

            If boMODIFICAR = True Then

                ' instancia la clase
                Dim objdatos As New cla_RECLTROF
                Dim tbl As New DataTable

                tbl = objdatos.fun_Buscar_CODIGO_X_RECLTROF(inLEVASECU, Trim(stLEVANUDO))

                If tbl.Rows.Count > 0 Then

                    Me.Text = "Modificar registro"
                    Me.fraRECLTROF.Text = "MODIFICAR TRABAJO DE OFICINA"

                    Me.cboRETONUDO.Enabled = False

                    Dim objdatos1 As New cla_USUARIO

                    Me.cboRETONUDO.DataSource = objdatos1.fun_Buscar_CODIGO_USUARIO(stLEVANUDO)
                    Me.cboRETONUDO.DisplayMember = "USUANOMB"
                    Me.cboRETONUDO.ValueMember = "USUANUDO"

                    Me.txtRETONUDO.Text = Trim(tbl.Rows(0).Item("RETONUDO"))
                    Me.txtRETOFEEN.Text = Trim(tbl.Rows(0).Item("RETOFEEN"))
                    Me.txtRETOOBSE.Text = Trim(tbl.Rows(0).Item("RETOOBSE"))

                Else
                    boINSERTAR = True

                    Me.Text = "Insertar registro"
                    Me.fraRECLTROF.Text = "INSERTAR TRABAJO DE OFICINA"

                    Me.txtRETOFEEN.Text = fun_fecha()

                End If

            Else
                boINSERTAR = True

                Me.Text = "Insertar registro"
                Me.fraRECLTROF.Text = "INSERTAR TRABAJO DE OFICINA"

                Me.txtRETOFEEN.Text = fun_fecha()

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
                Dim objdatos1 As New cla_RECLTROF

                Dim boLLAVEPRIMARIA As Boolean = objdatos1.fun_Verifica_llave_Primaria_RECLTROF(inLEVASECU, Me.txtRETONUDO, Me.txtRETOFEEN)

                ' instancia la clase
                Dim objVerifica As New cla_Verificar_Dato

                Dim boLEVANUDO As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.txtRETONUDO)
                Dim boLEVAFEEN As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Fecha(Me.txtRETOFEEN)
                Dim boLEVAUSUA As Boolean = False

                Dim stMOGEUSUA As String = fun_ConsultaNombreUsuario(Trim(Me.txtRETONUDO.Text))

                If Trim(stMOGEUSUA) = "" Then
                    boLEVAUSUA = False
                    MessageBox.Show("El funcionario seleccionado no registra un perfil de usuario", "Mensaje...", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1)
                Else
                    boLEVAUSUA = True
                End If

                ' verifica los datos del formulario 
                If boLLAVEPRIMARIA = True And _
                   boLEVANUDO = True And _
                   boLEVAFEEN = True And _
                   boLEVAUSUA = True Then

                    Dim objdatos22 As New cla_RECLTROF

                    If (objdatos22.fun_Insertar_RECLTROF(inLEVASECU, _
                                                         Me.txtRETONUDO.Text, _
                                                         Me.txtRETOFEEN.Text, _
                                                         Me.txtRETOOBSE.Text)) = True Then

                        ' actualiza el material cargado al funcionario
                        Dim objTRABCAMP As New cla_RECLAMOS
                        objTRABCAMP.fun_Actualizar_MATECARG_X_RECLAMOS(inLEVASECU, Me.txtRETONUDO.Text, Me.txtRETOFEEN.Text, stMOGEUSUA)

                        mod_MENSAJE.Se_Guardaron_Los_Datos_Correctamente()
                        Me.cboRETONUDO.Focus()
                        Me.Close()
                    Else
                        mod_MENSAJE.No_Se_Guardo_El_Registro_En_La_Base_De_Datos()
                    End If

                End If

                ' modifica el registro
            ElseIf boMODIFICAR = True Then

                ' instancia la clase
                Dim objVerifica As New cla_Verificar_Dato

                Dim boLEVANUDO As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.txtRETONUDO)
                Dim boLEVAFEEN As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Fecha(Me.txtRETOFEEN)

                ' verifica los datos del formulario 
                If boLEVANUDO = True And _
                   boLEVAFEEN = True Then

                    Dim objdatos22 As New cla_RECLTROF

                    If (objdatos22.fun_Actualizar_RECLTROF(inID_REGISTRO, _
                                                                inLEVASECU, _
                                                                Me.txtRETONUDO.Text, _
                                                                Me.txtRETOFEEN.Text, _
                                                                Me.txtRETOOBSE.Text)) = True Then

                        mod_MENSAJE.Se_Guardaron_Los_Datos_Correctamente()
                        Me.cboRETONUDO.Focus()
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
        Me.cboRETONUDO.Focus()
        Me.Close()
    End Sub

#End Region

#Region "FORMULARIO"

#Region "KeyPress"

    Private Sub txt_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboRETONUDO.KeyPress, txtRETOFEEN.KeyPress, txtRETOOBSE.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Or e.KeyChar = Convert.ToChar(Keys.Tab) Then
            pp_pro_SaltarCampo()
        End If
    End Sub

#End Region

#Region "GotFocus"

    Private Sub txt_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtRETOFEEN.GotFocus, txtRETOOBSE.GotFocus
        pp_pro_SobrearCampo(sender)
        pp_pro_DescripcionCampo(Me.strBARRESTA.Items(0), sender)
    End Sub
    Private Sub cbo_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboRETONUDO.GotFocus
        pp_pro_DescripcionCampo(Me.strBARRESTA.Items(0), sender)
    End Sub
    Private Sub cmd_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdGUARDAR.GotFocus, cmdSALIR.GotFocus
        pp_pro_DescripcionCampo(Me.strBARRESTA.Items(0), sender)
    End Sub

#End Region

#Region "KeyDown"

    Private Sub cboLEVANUDO_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboRETONUDO.KeyDown
        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
            fun_Cargar_ComboBox_Con_Datos_Activos_USUARIO_Descripcion(Me.cboRETONUDO, Me.cboRETONUDO.SelectedIndex)
        End If
    End Sub

#End Region

#Region "SelectedIndexChanged"

    Private Sub cboLEVANUDO_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboRETONUDO.SelectedIndexChanged
        Me.txtRETONUDO.Text = CType(fun_Buscar_Lista_Valores_USUARIO_Codigo(Me.cboRETONUDO), String)
    End Sub

#End Region

#Region "Click"

    Private Sub cboLEVANUDO_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboRETONUDO.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_USUARIO_Descripcion(Me.cboRETONUDO, Me.cboRETONUDO.SelectedIndex)
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