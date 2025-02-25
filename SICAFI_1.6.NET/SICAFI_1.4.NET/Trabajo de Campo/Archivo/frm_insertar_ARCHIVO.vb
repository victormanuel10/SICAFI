Imports REGLAS_DEL_NEGOCIO

Public Class frm_insertar_ARCHIVO

    '========================
    '*** INSERTAR ARCHIVO ***
    '========================

#Region "VARIABLE"

    Dim inID_REGISTRO As Integer
    Dim inARCHSECU As Integer
    Dim stARCHNUDO As String

    Dim boINSERTAR As Boolean = False
    Dim boMODIFICAR As Boolean = False

#End Region

#Region "CONSTRUCTOR"

    Public Sub New(ByVal inSECU As Integer)
        inARCHSECU = inSECU

        boINSERTAR = True

        InitializeComponent()
        pro_LimpiarCampos()
        pro_inicializarControles()
    End Sub
    Public Sub New(ByVal inIDRE As Integer, ByVal inSECU As Integer, ByVal stNUDO As String)
        inID_REGISTRO = inIDRE
        inARCHSECU = inSECU
        stARCHNUDO = stNUDO

        boMODIFICAR = True

        InitializeComponent()
        pro_LimpiarCampos()
        pro_inicializarControles()
    End Sub

#End Region

#Region "PROCEDIMIENTOS"

    Private Sub pro_LimpiarCampos()

        Me.cboARCHNUDO.DataSource = New DataTable

        Me.txtARCHNUDO.Text = ""
        Me.txtARCHFEEN.Text = ""
        Me.txtARCHFERE.Text = ""
        Me.txtARCHOBSE.Text = ""

    End Sub
    Private Sub pro_inicializarControles()

        Try

            If boMODIFICAR = True Then

                ' instancia la clase
                Dim objdatos As New cla_ARCHIVO
                Dim tbl As New DataTable

                tbl = objdatos.fun_Buscar_CODIGO_X_ARCHIVO(inID_REGISTRO, inARCHSECU, Trim(stARCHNUDO))

                If tbl.Rows.Count > 0 Then

                    Me.Text = "Modificar registro"
                    Me.fraARCHIVO.Text = "MODIFICAR ARCHIVO"

                    Me.cboARCHNUDO.Enabled = False

                    Dim objdatos1 As New cla_USUARIO

                    Me.cboARCHNUDO.DataSource = objdatos1.fun_Buscar_CODIGO_USUARIO(stARCHNUDO)
                    Me.cboARCHNUDO.DisplayMember = "USUANOMB"
                    Me.cboARCHNUDO.ValueMember = "USUANUDO"

                    Me.txtARCHNUDO.Text = Trim(tbl.Rows(0).Item("ARCHNUDO"))
                    Me.txtARCHFEEN.Text = Trim(tbl.Rows(0).Item("ARCHFEEN"))
                    Me.txtARCHFERE.Text = Trim(tbl.Rows(0).Item("ARCHFERE"))
                    Me.txtARCHOBSE.Text = Trim(tbl.Rows(0).Item("ARCHOBSE"))

                    Me.txtARCHFEEN.Enabled = False
                    Me.dtpARCHFEEN.Enabled = False

                End If

            ElseIf boINSERTAR = True Then

                Me.Text = "Insertar registro"
                Me.fraARCHIVO.Text = "INSERTAR ARCHIVO"

                Me.dtpARCHFEEN.MaxDate = DateTime.Today
                Me.dtpARCHFERE.MaxDate = DateTime.Today

                Me.dtpARCHFEEN.Value = fun_fecha()
                'Me.dtpARCHFERE.Value = fun_fecha()

                Me.txtARCHFEEN.Text = fun_fecha()
                Me.txtARCHFERE.Text = ""

                Me.txtARCHFERE.Enabled = False
                Me.dtpARCHFERE.Enabled = False

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
                Dim objdatos1 As New cla_ARCHIVO

                'Dim boLLAVEPRIMARIA As Boolean = objdatos1.fun_Verifica_llave_Primaria_ARCHIVO(inARCHSECU, Me.txtARCHNUDO)

                ' instancia la clase
                Dim objVerifica As New cla_Verificar_Dato

                Dim boARCHNUDO As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.txtARCHNUDO)
                Dim boARCHFEEN As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Fecha(Me.txtARCHFEEN)

                ' verifica los datos del formulario 
                If boARCHNUDO = True And _
                   boARCHFEEN = True Then

                    Dim objdatos22 As New cla_ARCHIVO

                    If (objdatos22.fun_Insertar_ARCHIVO(inARCHSECU, _
                                                         Me.txtARCHNUDO.Text, _
                                                         Me.txtARCHFEEN.Text, _
                                                         Me.txtARCHFERE.Text, _
                                                         Me.txtARCHOBSE.Text)) = True Then

                        ' actualiza el material cargado al funcionario
                        Dim objTRABCAMP As New cla_TRABCAMP
                        objTRABCAMP.fun_Actualizar_MATECARG_X_TRABCAMP(inARCHSECU, Me.txtARCHNUDO.Text)

                        mod_MENSAJE.Se_Guardaron_Los_Datos_Correctamente()
                        Me.cboARCHNUDO.Focus()
                        Me.Close()
                    Else
                        mod_MENSAJE.No_Se_Guardo_El_Registro_En_La_Base_De_Datos()
                    End If

                End If

                ' modifica el registro
            ElseIf boMODIFICAR = True Then

                ' instancia la clase
                Dim objVerifica As New cla_Verificar_Dato

                Dim boARCHNUDO As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.txtARCHNUDO)
                Dim boARCHFEEN As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Fecha(Me.txtARCHFEEN)

                ' verifica los datos del formulario 
                If boARCHNUDO = True And _
                   boARCHFEEN = True Then

                    Dim objdatos22 As New cla_ARCHIVO

                    If (objdatos22.fun_Actualizar_ARCHIVO(inID_REGISTRO, _
                                                                inARCHSECU, _
                                                                Me.txtARCHNUDO.Text, _
                                                                Me.txtARCHFEEN.Text, _
                                                                Me.txtARCHFERE.Text, _
                                                                Me.txtARCHOBSE.Text)) = True Then

                        mod_MENSAJE.Se_Guardaron_Los_Datos_Correctamente()
                        Me.cboARCHNUDO.Focus()
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
        Me.cboARCHNUDO.Focus()
        Me.Close()
    End Sub

#End Region

#Region "FORMULARIO"

#Region "KeyPress"

    Private Sub txt_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboARCHNUDO.KeyPress, txtARCHFEEN.KeyPress, txtARCHFERE.KeyPress, txtARCHOBSE.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Or e.KeyChar = Convert.ToChar(Keys.Tab) Then
            pp_pro_SaltarCampo()
        End If
    End Sub

#End Region

#Region "GotFocus"

    Private Sub txt_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtARCHFEEN.GotFocus, txtARCHFERE.GotFocus, txtARCHOBSE.GotFocus
        pp_pro_SobrearCampo(sender)
        pp_pro_DescripcionCampo(Me.strBARRESTA.Items(0), sender)
    End Sub
    Private Sub cbo_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboARCHNUDO.GotFocus
        pp_pro_DescripcionCampo(Me.strBARRESTA.Items(0), sender)
    End Sub
    Private Sub cmd_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdGUARDAR.GotFocus, cmdSALIR.GotFocus
        pp_pro_DescripcionCampo(Me.strBARRESTA.Items(0), sender)
    End Sub

#End Region

#Region "KeyDown"

    Private Sub cboARCHNUDO_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboARCHNUDO.KeyDown
        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
            fun_Cargar_ComboBox_Con_Datos_Activos_USUARIO_Descripcion(Me.cboARCHNUDO, Me.cboARCHNUDO.SelectedIndex)
        End If
    End Sub

#End Region

#Region "SelectedIndexChanged"

    Private Sub cboARCHNUDO_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboARCHNUDO.SelectedIndexChanged
        Me.txtARCHNUDO.Text = CType(fun_Buscar_Lista_Valores_USUARIO_Codigo(Me.cboARCHNUDO), String)
    End Sub

#End Region

#Region "ValueChanged"

    Private Sub dtpLEVAFEEN_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpARCHFEEN.ValueChanged
        Me.txtARCHFEEN.Text = Me.dtpARCHFEEN.Value
    End Sub
    Private Sub dtpLEVAFERE_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpARCHFERE.ValueChanged
        Me.txtARCHFERE.Text = Me.dtpARCHFERE.Value
    End Sub

#End Region

#Region "Click"

    Private Sub cboARCHNUDO_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboARCHNUDO.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_USUARIO_Descripcion(Me.cboARCHNUDO, Me.cboARCHNUDO.SelectedIndex)
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