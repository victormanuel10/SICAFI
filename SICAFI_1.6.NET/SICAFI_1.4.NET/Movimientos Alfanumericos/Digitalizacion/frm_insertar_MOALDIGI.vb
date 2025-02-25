Imports REGLAS_DEL_NEGOCIO

Public Class frm_insertar_MOALDIGI

    '========================================================
    '*** DIGITALIZACION GRAFICA MOVIMIENTOS ALFANUMERICOS ***
    '========================================================

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

#Region "PROCEDIMIENTOS"

    Private Sub pro_LimpiarCampos()

        Me.cboMADINUDO.DataSource = New DataTable

        Me.txtMADINUDO.Text = ""
        Me.txtMADIFEEN.Text = ""
        Me.txtMADIOBSE.Text = ""

    End Sub
    Private Sub pro_inicializarControles()

        Try

            If boMODIFICAR = True Then

                ' instancia la clase
                Dim objdatos As New cla_MOALDIGI
                Dim tbl As New DataTable

                tbl = objdatos.fun_Buscar_CODIGO_X_MOALDIGI(inLEVASECU, Trim(stLEVANUDO))

                If tbl.Rows.Count > 0 Then

                    Me.Text = "Modificar registro"
                    Me.fraMOALDIGI.Text = "MODIFICAR DIGITALIZACIÓN GRÁFICA"

                    Me.cboMADINUDO.Enabled = False

                    Dim objdatos1 As New cla_USUARIO

                    Me.cboMADINUDO.DataSource = objdatos1.fun_Buscar_CODIGO_USUARIO(stLEVANUDO)
                    Me.cboMADINUDO.DisplayMember = "USUANOMB"
                    Me.cboMADINUDO.ValueMember = "USUANUDO"

                    Me.txtMADINUDO.Text = Trim(tbl.Rows(0).Item("MADINUDO"))
                    Me.txtMADIFEEN.Text = Trim(tbl.Rows(0).Item("MADIFEEN"))
                    Me.txtMADIFEFI.Text = Trim(tbl.Rows(0).Item("MADIFEFI"))
                    Me.txtMADIOBSE.Text = Trim(tbl.Rows(0).Item("MADIOBSE"))

                End If

            ElseIf boINSERTAR = True Then

                Me.Text = "Insertar registro"
                Me.fraMOALDIGI.Text = "INSERTAR DIGITALIZACIÓN GRÁFICA"

                Me.txtMADIFEEN.Text = fun_fecha()

                Me.dtpDIGIFEFI.Enabled = False
                Me.txtMADIFEFI.Enabled = False

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
                Dim objdatos1 As New cla_MOALDIGI

                Dim boLLAVEPRIMARIA As Boolean = objdatos1.fun_Verifica_llave_Primaria_MOALDIGI(inLEVASECU, Me.txtMADINUDO, Me.txtMADIFEEN)

                ' instancia la clase
                Dim objVerifica As New cla_Verificar_Dato

                Dim boLEVANUDO As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.txtMADINUDO)
                Dim boLEVAFEEN As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Fecha(Me.txtMADIFEEN)

                ' verifica los datos del formulario 
                If boLLAVEPRIMARIA = True And _
                   boLEVANUDO = True And _
                   boLEVAFEEN = True Then

                    Dim objdatos22 As New cla_MOALDIGI

                    If (objdatos22.fun_Insertar_MOALDIGI(inLEVASECU, _
                                                         Me.txtMADINUDO.Text, _
                                                         Me.txtMADIFEEN.Text, _
                                                         Me.txtMADIFEFI.Text, _
                                                         Me.txtMADIOBSE.Text)) = True Then

                        mod_MENSAJE.Se_Guardaron_Los_Datos_Correctamente()
                        Me.cboMADINUDO.Focus()
                        Me.Close()
                    Else
                        mod_MENSAJE.No_Se_Guardo_El_Registro_En_La_Base_De_Datos()
                    End If

                End If

                ' modifica el registro
            ElseIf boMODIFICAR = True Then

                ' instancia la clase
                Dim objVerifica As New cla_Verificar_Dato

                Dim boLEVANUDO As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.txtMADINUDO)
                Dim boLEVAFEEN As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Fecha(Me.txtMADIFEEN)

                ' verifica los datos del formulario 
                If boLEVANUDO = True And _
                   boLEVAFEEN = True Then

                    Dim objdatos22 As New cla_MOALDIGI

                    If (objdatos22.fun_Actualizar_MOALDIGI(inID_REGISTRO, _
                                                           inLEVASECU, _
                                                           Me.txtMADINUDO.Text, _
                                                           Me.txtMADIFEEN.Text, _
                                                           Me.txtMADIFEFI.Text, _
                                                           Me.txtMADIOBSE.Text)) = True Then

                        mod_MENSAJE.Se_Guardaron_Los_Datos_Correctamente()
                        Me.cboMADINUDO.Focus()
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
        Me.cboMADINUDO.Focus()
        Me.Close()
    End Sub

#End Region

#Region "FORMULARIO"

#Region "KeyPress"

    Private Sub txt_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboMADINUDO.KeyPress, txtMADIFEEN.KeyPress, txtMADIOBSE.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Or e.KeyChar = Convert.ToChar(Keys.Tab) Then
            pp_pro_SaltarCampo()
        End If
    End Sub

#End Region

#Region "GotFocus"

    Private Sub txt_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtMADIFEEN.GotFocus, txtMADIOBSE.GotFocus
        pp_pro_SobrearCampo(sender)
        pp_pro_DescripcionCampo(Me.strBARRESTA.Items(0), sender)
    End Sub
    Private Sub cbo_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboMADINUDO.GotFocus
        pp_pro_DescripcionCampo(Me.strBARRESTA.Items(0), sender)
    End Sub
    Private Sub cmd_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdGUARDAR.GotFocus, cmdSALIR.GotFocus
        pp_pro_DescripcionCampo(Me.strBARRESTA.Items(0), sender)
    End Sub

#End Region

#Region "KeyDown"

    Private Sub cboLEVANUDO_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboMADINUDO.KeyDown
        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
            fun_Cargar_ComboBox_Con_Datos_Activos_USUARIO_Descripcion(Me.cboMADINUDO, Me.cboMADINUDO.SelectedIndex)
        End If
    End Sub

#End Region

#Region "SelectedIndexChanged"

    Private Sub cboLEVANUDO_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboMADINUDO.SelectedIndexChanged
        Me.txtMADINUDO.Text = CType(fun_Buscar_Lista_Valores_USUARIO_Codigo(Me.cboMADINUDO), String)
    End Sub

#End Region

#Region "Click"

    Private Sub cboLEVANUDO_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboMADINUDO.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_USUARIO_Descripcion(Me.cboMADINUDO, Me.cboMADINUDO.SelectedIndex)
    End Sub

#End Region

#Region "ValueChanged"

    Private Sub dtpLEVAFERE_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpDIGIFEFI.ValueChanged
        Me.txtMADIFEFI.Text = Me.dtpDIGIFEFI.Value
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