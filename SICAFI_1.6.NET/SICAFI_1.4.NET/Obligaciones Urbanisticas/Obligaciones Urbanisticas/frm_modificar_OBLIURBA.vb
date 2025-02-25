Imports REGLAS_DEL_NEGOCIO
Imports System.IO

Public Class frm_modificar_OBLIURBA

    '===========================================
    '*** MODIFICAR OBLIGACIONES URBANISTICAS ***
    '===========================================

#Region "VARIABLE"

    Dim inID_REGISTRO As Integer

#End Region

#Region "CONSTRUCTOR"

    Public Sub New(ByVal inInRegistro As Integer)
        inID_REGISTRO = inInRegistro

        InitializeComponent()
        pro_LimpiarCampos()
        pro_inicializarControles()

    End Sub
    Public Sub New()

        InitializeComponent()

    End Sub

#End Region

#Region "PROCEDIMIENTOS"

    Private Sub pro_inicializarControles()

        Try
            Dim objdatos8 As New cla_OBLIURBA
            Dim tbl As New DataTable

            tbl = objdatos8.fun_Buscar_ID_OBLIURBA(inID_REGISTRO)

            Me.txtOBURSECU.Text = CStr(Trim(tbl.Rows(0).Item("OBURSECU")))

            Dim objdatos2 As New cla_CLASENTI

            Me.cboOBURCLEN.DataSource = objdatos2.fun_Consultar_CAMPOS_MANT_CLASENTI
            Me.cboOBURCLEN.DisplayMember = "CLENDESC"
            Me.cboOBURCLEN.ValueMember = "CLENCODI"

            Me.cboOBURCLEN.SelectedValue = tbl.Rows(0).Item("OBURCLEN")

            Me.txtOBURNURE.Text = Trim(tbl.Rows(0).Item("OBURNURE"))
            Me.txtOBURFERE.Text = Trim(tbl.Rows(0).Item("OBURFERE"))

            Dim objdatos5 As New cla_VIGENCIA

            Me.cboOBURVIRE.DataSource = objdatos5.fun_Consultar_CAMPOS_VIGENCIA
            Me.cboOBURVIRE.DisplayMember = "VIGEDESC"
            Me.cboOBURVIRE.ValueMember = "VIGECODI"

            Me.cboOBURVIRE.SelectedValue = tbl.Rows(0).Item("OBURVIRE")

            Dim objdatos7 As New cla_ESTADO

            Me.cboOBURESTA.DataSource = objdatos7.fun_Consultar_TODOS_LOS_ESTADOS
            Me.cboOBURESTA.DisplayMember = "ESTADESC"
            Me.cboOBURESTA.ValueMember = "ESTACODI"

            Me.cboOBURESTA.SelectedValue = tbl.Rows(0).Item("OBURESTA")

            Me.lblOBURCLEN.Text = CType(fun_Buscar_Lista_Valores_CLASENTI_Codigo(Me.cboOBURCLEN), String)
            Me.lblOBURVIRE.Text = CType(fun_Buscar_Lista_Valores_VIGENCIA_Codigo(Me.cboOBURVIRE), String)


        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub pro_LimpiarCampos()

        Me.cboOBURCLEN.DataSource = New DataTable
        Me.cboOBURVIRE.DataSource = New DataTable
        Me.cboOBURESTA.DataSource = New DataTable

        Me.txtOBURSECU.Text = "0"
        Me.lblOBURCLEN.Text = ""
        Me.txtOBURNURE.Text = ""
        Me.txtOBURFERE.Text = ""
        Me.lblOBURVIRE.Text = ""

    End Sub

#End Region

#Region "MENU"

    Private Sub cmdGUARDAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGUARDAR.Click

        Try

            ' instancia la clase
            Dim objVerifica As New cla_Verificar_Dato

            Dim boOBURCLEN As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboOBURCLEN)
            Dim boOBURNURA As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Numerico(Me.txtOBURNURE)
            Dim boOBURFERA As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Fecha(Me.txtOBURFERE)
            Dim boOBURVIGE As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboOBURVIRE)
            Dim boOBURESTA As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboOBURESTA)

            ' verifica los datos del formulario 
            If boOBURCLEN = True And _
               boOBURNURA = True And _
               boOBURFERA = True And _
               boOBURVIGE = True And _
               boOBURESTA = True Then

                Dim objdatos22 As New cla_OBLIURBA

                If (objdatos22.fun_Actualizar_OBLIURBA(inID_REGISTRO, _
                                                       Me.txtOBURSECU.Text, _
                                                       Me.cboOBURCLEN.SelectedValue, _
                                                       Me.txtOBURNURE.Text, _
                                                       Me.txtOBURFERE.Text, _
                                                       Me.cboOBURVIRE.SelectedValue, _
                                                       Me.cboOBURESTA.SelectedValue)) = True Then

                    ' instancia la clase
                    Dim objRutas As New cla_RUTAS
                    Dim tblRutas As New DataTable

                    tblRutas = objRutas.fun_Buscar_CODIGO_MANT_RUTAS(22)

                    If tblRutas.Rows.Count > 0 Then

                        Dim stRuta As String = Trim(Me.cboOBURCLEN.SelectedValue) & "-" & Trim(Me.txtOBURNURE.Text) & "-" & Trim(Me.cboOBURVIRE.SelectedValue)

                        If System.IO.Directory.Exists(Trim(tblRutas.Rows(0).Item("RUTARUTA")) & "\" & stRuta) = False Then

                            System.IO.Directory.CreateDirectory(Trim(tblRutas.Rows(0).Item("RUTARUTA")) & "\" & stRuta)

                        End If

                    End If

                    mod_MENSAJE.Se_Guardaron_Los_Datos_Correctamente()

                    ' envia el ID al formulario principal
                    Dim objdatos1 As New cla_OBLIURBA
                    Dim tbl1 As New DataTable

                    tbl1 = objdatos1.fun_Buscar_CODIGO_X_OBLIURBA(CInt(Me.txtOBURSECU.Text))

                    If tbl1.Rows.Count > 0 Then

                        Dim inNroIdRe As New frm_OBLIURBA(tbl1.Rows(0).Item("OBURIDRE"))

                    End If

                    Me.cboOBURCLEN.Focus()
                    Me.Close()

                Else
                    mod_MENSAJE.No_Se_Guardo_El_Registro_En_La_Base_De_Datos()
                End If

            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub cmdCANCELAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSALIR.Click
        Dim inNroIdRe As New frm_OBLIURBA(inID_REGISTRO)
        Me.cboOBURCLEN.Focus()
        Me.Close()
    End Sub

#End Region

#Region "FORMULARIO"

#Region "KeyPress"

    Private Sub txt_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboOBURCLEN.KeyPress, txtOBURNURE.KeyPress, txtOBURFERE.KeyPress, cboOBURVIRE.KeyPress, cboOBURESTA.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Or e.KeyChar = Convert.ToChar(Keys.Tab) Then
            pp_pro_SaltarCampo()
        End If
    End Sub

#End Region

#Region "KeyDown"

    Private Sub cboOBURCLEN_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboOBURCLEN.KeyDown
        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
            fun_Cargar_ComboBox_Con_Datos_Activos_CLASENTI_Descripcion(Me.cboOBURCLEN, Me.cboOBURCLEN.SelectedIndex)
        End If
    End Sub
    Private Sub cboOBURMENO_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboOBURVIRE.KeyDown
        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
            fun_Cargar_ComboBox_Con_Datos_Activos_VIGENCIA_Descripcion(Me.cboOBURVIRE, Me.cboOBURVIRE.SelectedIndex)
        End If
    End Sub
    Private Sub cboOBURESTA_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboOBURESTA.KeyDown
        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
            fun_Cargar_ComboBox_Con_Datos_Activos_ESTADO(Me.cboOBURESTA, Me.cboOBURESTA.SelectedIndex)
        End If
    End Sub

#End Region

#Region "GotFocus"

    Private Sub txt_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtOBURFERE.GotFocus, txtOBURNURE.GotFocus
        pp_pro_SobrearCampo(sender)
        pp_pro_DescripcionCampo(Me.strBARRESTA.Items(0), sender)
    End Sub
    Private Sub cmd_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdGUARDAR.GotFocus, cmdSALIR.GotFocus
        pp_pro_DescripcionCampo(Me.strBARRESTA.Items(0), sender)
    End Sub
    Private Sub cbo_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboOBURCLEN.GotFocus, cboOBURESTA.GotFocus, cboOBURVIRE.GotFocus
        pp_pro_DescripcionCampo(Me.strBARRESTA.Items(0), sender)
    End Sub

#End Region

#Region "SelectedIndexChanged"

    Private Sub cboOBURCLEN_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboOBURCLEN.SelectedIndexChanged
        Me.lblOBURCLEN.Text = CType(fun_Buscar_Lista_Valores_CLASENTI_Codigo(Me.cboOBURCLEN), String)
    End Sub

    Private Sub cboOBURMENO_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboOBURVIRE.SelectedIndexChanged
        Me.lblOBURVIRE.Text = CType(fun_Buscar_Lista_Valores_VIGENCIA_Codigo(Me.cboOBURVIRE), String)
    End Sub

#End Region

#Region "Click"

    Private Sub cboOBURCLEN_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboOBURCLEN.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_CLASENTI_Descripcion(Me.cboOBURCLEN, Me.cboOBURCLEN.SelectedIndex)
    End Sub
    Private Sub cboOBURMENO_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboOBURVIRE.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_VIGENCIA_Descripcion(Me.cboOBURVIRE, Me.cboOBURVIRE.SelectedIndex)
    End Sub
    Private Sub cboMUTAESTA_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboOBURESTA.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_ESTADO(Me.cboOBURESTA, Me.cboOBURESTA.SelectedIndex)
    End Sub

#End Region

#Region "ValueChanged"

    Private Sub dtpOBURFERA_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpOBURFERE.ValueChanged
        Me.txtOBURFERE.Text = Me.dtpOBURFERE.Value
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