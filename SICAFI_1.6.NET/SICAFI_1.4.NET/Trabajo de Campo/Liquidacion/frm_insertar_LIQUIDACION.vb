Imports REGLAS_DEL_NEGOCIO

Public Class frm_insertar_LIQUIDACION

    '============================
    '*** INSERTAR LIQUIDACIÓN ***
    '============================

#Region "VARIABLE"

    Dim inID_REGISTRO As Integer
    Dim inLIQUSECU As Integer
    Dim stLIQUNUDO As String

    Dim boINSERTAR As Boolean = False
    Dim boMODIFICAR As Boolean = False

#End Region

#Region "CONSTRUCTOR"

    Public Sub New(ByVal inSECU As Integer)
        inLIQUSECU = inSECU

        boINSERTAR = True

        InitializeComponent()
        pro_LimpiarCampos()
        pro_inicializarControles()
    End Sub
    Public Sub New(ByVal inIDRE As Integer, ByVal inSECU As Integer, ByVal stNUDO As String)
        inID_REGISTRO = inIDRE
        inLIQUSECU = inSECU
        stLIQUNUDO = stNUDO

        boMODIFICAR = True

        InitializeComponent()
        pro_LimpiarCampos()
        pro_inicializarControles()
    End Sub

#End Region

#Region "PROCEDIMIENTOS"

    Private Sub pro_LimpiarCampos()

        Me.cboLIQUNUDO.DataSource = New DataTable

        Me.txtLIQUNUDO.Text = ""
        Me.txtLIQUFEEN.Text = ""
        Me.txtLIQUFERE.Text = ""
        Me.txtLIQUOBSE.Text = ""

    End Sub
    Private Sub pro_inicializarControles()

        Try

            If boMODIFICAR = True Then

                ' instancia la clase
                Dim objdatos As New cla_LIQUIDACION
                Dim tbl As New DataTable

                tbl = objdatos.fun_Buscar_CODIGO_X_LIQUIDACION(inID_REGISTRO, inLIQUSECU, Trim(stLIQUNUDO))

                If tbl.Rows.Count > 0 Then

                    Me.Text = "Modificar registro"
                    Me.fraLIQUIDACION.Text = "MODIFICAR LIQUIDACION"

                    Me.cboLIQUNUDO.Enabled = False

                    Dim objdatos1 As New cla_USUARIO

                    Me.cboLIQUNUDO.DataSource = objdatos1.fun_Buscar_CODIGO_USUARIO(stLIQUNUDO)
                    Me.cboLIQUNUDO.DisplayMember = "USUANOMB"
                    Me.cboLIQUNUDO.ValueMember = "USUANUDO"

                    Me.txtLIQUNUDO.Text = Trim(tbl.Rows(0).Item("LIQUNUDO"))
                    Me.txtLIQUFEEN.Text = Trim(tbl.Rows(0).Item("LIQUFEEN"))
                    Me.txtLIQUFERE.Text = Trim(tbl.Rows(0).Item("LIQUFERE"))
                    Me.txtLIQUOBSE.Text = Trim(tbl.Rows(0).Item("LIQUOBSE"))

                    Me.txtLIQUFEEN.Enabled = False
                    Me.dtpLIQUFEEN.Enabled = False

                End If

            ElseIf boINSERTAR = True Then

                Me.Text = "Insertar registro"
                Me.fraLIQUIDACION.Text = "INSERTAR LIQUIDACION"

                Me.dtpLIQUFEEN.MaxDate = DateTime.Today
                Me.dtpLIQUFERE.MaxDate = DateTime.Today

                Me.dtpLIQUFEEN.Value = fun_fecha()
                'Me.dtpLIQUFERE.Value = fun_fecha()

                Me.txtLIQUFEEN.Text = fun_fecha()
                Me.txtLIQUFERE.Text = ""

                Me.txtLIQUFERE.Enabled = False
                Me.dtpLIQUFERE.Enabled = False

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
                Dim objdatos1 As New cla_LIQUIDACION

                'Dim boLLAVEPRIMARIA As Boolean = objdatos1.fun_Verifica_llave_Primaria_LIQUIDACION(inLIQUSECU, Me.txtLIQUNUDO)

                ' instancia la clase
                Dim objVerifica As New cla_Verificar_Dato

                Dim boLIQUNUDO As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.txtLIQUNUDO)
                Dim boLIQUFEEN As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Fecha(Me.txtLIQUFEEN)

                ' verifica los datos del formulario 
                If boLIQUNUDO = True And _
                   boLIQUFEEN = True Then

                    Dim objdatos22 As New cla_LIQUIDACION

                    If (objdatos22.fun_Insertar_LIQUIDACION(inLIQUSECU, _
                                                         Me.txtLIQUNUDO.Text, _
                                                         Me.txtLIQUFEEN.Text, _
                                                         Me.txtLIQUFERE.Text, _
                                                         Me.txtLIQUOBSE.Text)) = True Then

                        ' actualiza el material cargado al funcionario
                        Dim objTRABCAMP As New cla_TRABCAMP
                        objTRABCAMP.fun_Actualizar_MATECARG_X_TRABCAMP(inLIQUSECU, Me.txtLIQUNUDO.Text)

                        mod_MENSAJE.Se_Guardaron_Los_Datos_Correctamente()
                        Me.cboLIQUNUDO.Focus()
                        Me.Close()
                    Else
                        mod_MENSAJE.No_Se_Guardo_El_Registro_En_La_Base_De_Datos()
                    End If

                End If

                ' modifica el registro
            ElseIf boMODIFICAR = True Then

                ' instancia la clase
                Dim objVerifica As New cla_Verificar_Dato

                Dim boLIQUNUDO As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.txtLIQUNUDO)
                Dim boLIQUFEEN As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Fecha(Me.txtLIQUFEEN)

                ' verifica los datos del formulario 
                If boLIQUNUDO = True And _
                   boLIQUFEEN = True Then

                    Dim objdatos22 As New cla_LIQUIDACION

                    If (objdatos22.fun_Actualizar_LIQUIDACION(inID_REGISTRO, _
                                                                inLIQUSECU, _
                                                                Me.txtLIQUNUDO.Text, _
                                                                Me.txtLIQUFEEN.Text, _
                                                                Me.txtLIQUFERE.Text, _
                                                                Me.txtLIQUOBSE.Text)) = True Then

                        mod_MENSAJE.Se_Guardaron_Los_Datos_Correctamente()
                        Me.cboLIQUNUDO.Focus()
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
        Me.cboLIQUNUDO.Focus()
        Me.Close()
    End Sub

#End Region

#Region "FORMULARIO"

#Region "KeyPress"

    Private Sub txt_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboLIQUNUDO.KeyPress, txtLIQUFEEN.KeyPress, txtLIQUFERE.KeyPress, txtLIQUOBSE.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Or e.KeyChar = Convert.ToChar(Keys.Tab) Then
            pp_pro_SaltarCampo()
        End If
    End Sub

#End Region

#Region "GotFocus"

    Private Sub txt_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtLIQUFEEN.GotFocus, txtLIQUFERE.GotFocus, txtLIQUOBSE.GotFocus
        pp_pro_SobrearCampo(sender)
        pp_pro_DescripcionCampo(Me.strBARRESTA.Items(0), sender)
    End Sub
    Private Sub cbo_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboLIQUNUDO.GotFocus
        pp_pro_DescripcionCampo(Me.strBARRESTA.Items(0), sender)
    End Sub
    Private Sub cmd_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdGUARDAR.GotFocus, cmdSALIR.GotFocus
        pp_pro_DescripcionCampo(Me.strBARRESTA.Items(0), sender)
    End Sub

#End Region

#Region "KeyDown"

    Private Sub cboLIQUNUDO_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboLIQUNUDO.KeyDown
        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
            fun_Cargar_ComboBox_Con_Datos_Activos_USUARIO_Descripcion(Me.cboLIQUNUDO, Me.cboLIQUNUDO.SelectedIndex)
        End If
    End Sub

#End Region

#Region "SelectedIndexChanged"

    Private Sub cboLIQUNUDO_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboLIQUNUDO.SelectedIndexChanged
        Me.txtLIQUNUDO.Text = CType(fun_Buscar_Lista_Valores_USUARIO_Codigo(Me.cboLIQUNUDO), String)
    End Sub

#End Region

#Region "ValueChanged"

    Private Sub dtpLEVAFEEN_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpLIQUFEEN.ValueChanged
        Me.txtLIQUFEEN.Text = Me.dtpLIQUFEEN.Value
    End Sub
    Private Sub dtpLEVAFERE_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpLIQUFERE.ValueChanged
        Me.txtLIQUFERE.Text = Me.dtpLIQUFERE.Value
    End Sub

#End Region

#Region "Click"

    Private Sub cboLIQUNUDO_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboLIQUNUDO.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_USUARIO_Descripcion(Me.cboLIQUNUDO, Me.cboLIQUNUDO.SelectedIndex)
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