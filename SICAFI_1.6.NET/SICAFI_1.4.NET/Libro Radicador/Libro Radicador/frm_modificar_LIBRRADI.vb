Imports REGLAS_DEL_NEGOCIO
Imports System.IO

Public Class frm_modificar_LIBRRADI

    '=================================
    '*** MODIFICAR LIBRO RADICADOR ***
    '=================================

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
            Dim objdatos8 As New cla_LIBRRADI
            Dim tbl As New DataTable

            tbl = objdatos8.fun_Buscar_ID_LIBRRADI(inID_REGISTRO)

            Me.txtREMUSECU.Text = CStr(Trim(tbl.Rows(0).Item("LIRASECU")))

            Dim objdatos2 As New cla_ACTOADMI

            Me.cboLIRAACAD.DataSource = objdatos2.fun_Consultar_CAMPOS_MANT_ACTOADMI
            Me.cboLIRAACAD.DisplayMember = "ACADDESC"
            Me.cboLIRAACAD.ValueMember = "ACADCODI"

            Me.cboLIRAACAD.SelectedValue = tbl.Rows(0).Item("LIRAACAD")

            Dim objdatos3 As New cla_MEDIRESE

            Me.cboLIRAMERE.DataSource = objdatos3.fun_Consultar_CAMPOS_MANT_MEDIRESE
            Me.cboLIRAMERE.DisplayMember = "MEREDESC"
            Me.cboLIRAMERE.ValueMember = "MERECODI"

            Me.cboLIRAMERE.SelectedValue = tbl.Rows(0).Item("LIRAMERE")

            Me.txtLIRANURA.Text = Trim(tbl.Rows(0).Item("LIRANURA"))
            Me.txtLIRAFERA.Text = Trim(tbl.Rows(0).Item("LIRAFERA"))
            Me.txtLIRAASUN.Text = Trim(tbl.Rows(0).Item("LIRAASUN"))

            Dim objdatos5 As New cla_MEDINOTI

            Me.cboLIRAMENO.DataSource = objdatos5.fun_Consultar_CAMPOS_MANT_MEDINOTI
            Me.cboLIRAMENO.DisplayMember = "MENODESC"
            Me.cboLIRAMENO.ValueMember = "MENOCODI"

            Me.cboLIRAMENO.SelectedValue = tbl.Rows(0).Item("LIRAMENO")

            Me.txtLIRAFEMN.Text = Trim(tbl.Rows(0).Item("LIRAFEMN"))

            Dim objdatos6 As New cla_DIVISION

            Me.cboLIRADIVI.DataSource = objdatos6.fun_Consultar_CAMPOS_MANT_DIVISION
            Me.cboLIRADIVI.DisplayMember = "DIVIDESC"
            Me.cboLIRADIVI.ValueMember = "DIVICODI"

            Me.cboLIRADIVI.SelectedValue = tbl.Rows(0).Item("LIRADIVI")

            Dim objdatos7 As New cla_ESTADO

            Me.cboLIRAESTA.DataSource = objdatos7.fun_Consultar_TODOS_LOS_ESTADOS
            Me.cboLIRAESTA.DisplayMember = "ESTADESC"
            Me.cboLIRAESTA.ValueMember = "ESTACODI"

            Me.cboLIRAESTA.SelectedValue = tbl.Rows(0).Item("LIRAESTA")

            Me.txtLIRAFEAS.Text = Trim(tbl.Rows(0).Item("LIRAFEAS"))
            Me.txtLIRAOFSA.Text = Trim(tbl.Rows(0).Item("LIRAOFSA"))

            Me.lblLIRAACAD.Text = CType(fun_Buscar_Lista_Valores_ACTOADMI_Codigo(Me.cboLIRAACAD), String)
            Me.lblLIRAMERE.Text = CType(fun_Buscar_Lista_Valores_MEDIRESE_Codigo(Me.cboLIRAMERE), String)
            Me.lblLIRAMENO.Text = CType(fun_Buscar_Lista_Valores_MEDINOTI_Codigo(Me.cboLIRAMENO), String)
            Me.lblLIRADIVI.Text = CType(fun_Buscar_Lista_Valores_DIVISION_Codigo(Me.cboLIRADIVI), String)

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub pro_LimpiarCampos()

        Me.cboLIRAACAD.DataSource = New DataTable
        Me.cboLIRAMERE.DataSource = New DataTable
        Me.cboLIRAMENO.DataSource = New DataTable
        Me.cboLIRADIVI.DataSource = New DataTable
        Me.cboLIRAESTA.DataSource = New DataTable

        Me.txtREMUSECU.Text = "0"
        Me.lblLIRAACAD.Text = ""
        Me.lblLIRAMERE.Text = ""
        Me.txtLIRAASUN.Text = ""
        Me.txtLIRANURA.Text = ""
        Me.txtLIRAFERA.Text = ""
        Me.lblLIRAMENO.Text = ""
        Me.txtLIRAFEMN.Text = ""
        Me.lblLIRADIVI.Text = ""
        Me.txtLIRAFEAS.Text = ""

    End Sub

#End Region

#Region "MENU"

    Private Sub cmdGUARDAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGUARDAR.Click

        Try

            ' instancia la clase
            Dim objVerifica As New cla_Verificar_Dato

            Dim boLIRAACAD As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboLIRAACAD)
            Dim boLIRAMERE As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboLIRAMERE)
            Dim boLIRANURA As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Numerico(Me.txtLIRANURA)
            Dim boLIRAFERA As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Fecha(Me.txtLIRAFERA)
            Dim boLIRAASUN As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.txtLIRAASUN)
            Dim boLIRADIVI As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboLIRADIVI)
            Dim boLIRAESTA As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboLIRAESTA)
            Dim boLIRAFEAS As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Fecha(Me.txtLIRAFEAS)

            ' verifica los datos del formulario 
            If boLIRAACAD = True And _
               boLIRAMERE = True And _
               boLIRANURA = True And _
               boLIRAFERA = True And
               boLIRAASUN = True And _
               boLIRADIVI = True And _
               boLIRAFEAS = True And _
               boLIRAESTA = True Then

                Dim objdatos22 As New cla_LIBRRADI

                If (objdatos22.fun_Actualizar_LIBRRADI(inID_REGISTRO, _
                                                       Me.txtREMUSECU.Text, _
                                                       Me.cboLIRAACAD.SelectedValue, _
                                                       Me.cboLIRAMERE.SelectedValue, _
                                                       Me.txtLIRANURA.Text, _
                                                       Me.txtLIRAFERA.Text, _
                                                       Me.txtLIRAASUN.Text, _
                                                       Me.cboLIRAMENO.SelectedValue, _
                                                       Me.txtLIRAFEMN.Text, _
                                                       Me.cboLIRADIVI.SelectedValue, _
                                                       vp_cedula, _
                                                       vp_usuario, _
                                                       Me.txtLIRAOFSA.Text, _
                                                       Me.cboLIRAESTA.SelectedValue, _
                                                       Me.txtLIRAFEAS.Text)) = True Then

                    ' instancia la clase
                    Dim objRutas As New cla_RUTAS
                    Dim tblRutas As New DataTable

                    tblRutas = objRutas.fun_Buscar_CODIGO_MANT_RUTAS(17)

                    If tblRutas.Rows.Count > 0 Then

                        Dim stRuta As String = Trim(Me.txtLIRANURA.Text) & "-" & Trim(Me.txtLIRAFERA.Text)

                        If System.IO.Directory.Exists(Trim(tblRutas.Rows(0).Item("RUTARUTA")) & "\" & stRuta) = False Then

                            System.IO.Directory.CreateDirectory(Trim(tblRutas.Rows(0).Item("RUTARUTA")) & "\" & stRuta)

                        End If

                    End If

                    mod_MENSAJE.Se_Modificaron_Los_Datos_Correctamente()

                    Me.cboLIRAACAD.Focus()
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
        Dim inNroIdRe As New frm_LIBRRADI(inID_REGISTRO)
        Me.cboLIRAACAD.Focus()
        Me.Close()
    End Sub

#End Region

#Region "FORMULARIO"

#Region "KeyPress"

    Private Sub txt_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboLIRAACAD.KeyPress, cboLIRAMERE.KeyPress, txtLIRANURA.KeyPress, txtLIRAFERA.KeyPress, txtLIRAASUN.KeyPress, cboLIRAMENO.KeyPress, txtLIRAFEMN.KeyPress, cboLIRADIVI.KeyPress, cboLIRAESTA.KeyPress, txtLIRAFEAS.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Or e.KeyChar = Convert.ToChar(Keys.Tab) Then
            pp_pro_SaltarCampo()
        End If
    End Sub

#End Region

#Region "KeyDown"

    Private Sub cboLIRAACAD_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboLIRAACAD.KeyDown
        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
            fun_Cargar_ComboBox_Con_Datos_Activos_ACTOADMI_Descripcion(Me.cboLIRAACAD, Me.cboLIRAACAD.SelectedIndex)
        End If
    End Sub
    Private Sub cboLIRAMERE_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboLIRAMERE.KeyDown
        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
            fun_Cargar_ComboBox_Con_Datos_Activos_MEDIRESE_Descripcion(Me.cboLIRAMERE, Me.cboLIRAMERE.SelectedIndex)
        End If
    End Sub
    Private Sub cboLIRAMENO_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboLIRAMENO.KeyDown
        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
            fun_Cargar_ComboBox_Con_Datos_Activos_MEDINOTI_Descripcion(Me.cboLIRAMENO, Me.cboLIRAMENO.SelectedIndex)
        End If
    End Sub
    Private Sub cboLIRADIVI_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboLIRADIVI.KeyDown
        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
            fun_Cargar_ComboBox_Con_Datos_Activos_DIVISION_Descripcion(Me.cboLIRADIVI, Me.cboLIRADIVI.SelectedIndex)
        End If
    End Sub
    Private Sub cboLIRAESTA_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboLIRAESTA.KeyDown
        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
            fun_Cargar_ComboBox_Con_Datos_Activos_ESTADO(Me.cboLIRAESTA, Me.cboLIRAESTA.SelectedIndex)
        End If
    End Sub

#End Region

#Region "GotFocus"

    Private Sub txt_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtLIRAASUN.GotFocus, txtLIRAFEMN.GotFocus, txtLIRAFERA.GotFocus, txtLIRANURA.GotFocus, txtLIRAFEAS.GotFocus
        pp_pro_SobrearCampo(sender)
        pp_pro_DescripcionCampo(Me.strBARRESTA.Items(0), sender)
    End Sub
    Private Sub cmd_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdGUARDAR.GotFocus, cmdSALIR.GotFocus
        pp_pro_DescripcionCampo(Me.strBARRESTA.Items(0), sender)
    End Sub
    Private Sub cbo_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboLIRAACAD.GotFocus, cboLIRAESTA.GotFocus, cboLIRAMERE.GotFocus, cboLIRADIVI.GotFocus, cboLIRAMENO.GotFocus
        pp_pro_DescripcionCampo(Me.strBARRESTA.Items(0), sender)
    End Sub

#End Region

#Region "SelectedIndexChanged"

    Private Sub cboLIRAACAD_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboLIRAACAD.SelectedIndexChanged
        Me.lblLIRAACAD.Text = CType(fun_Buscar_Lista_Valores_ACTOADMI_Codigo(Me.cboLIRAACAD), String)
    End Sub
    Private Sub cboLIRAMERE_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboLIRAMERE.SelectedIndexChanged
        Me.lblLIRAMERE.Text = CType(fun_Buscar_Lista_Valores_MEDIRESE_Codigo(Me.cboLIRAMERE), String)
    End Sub
    Private Sub cboLIRAMENO_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboLIRAMENO.SelectedIndexChanged
        Me.lblLIRAMENO.Text = CType(fun_Buscar_Lista_Valores_MEDINOTI_Codigo(Me.cboLIRAMENO), String)
    End Sub
    Private Sub cboLIRADIVI_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboLIRADIVI.SelectedIndexChanged
        Me.lblLIRADIVI.Text = CType(fun_Buscar_Lista_Valores_DIVISION_Codigo(Me.cboLIRADIVI), String)
    End Sub

#End Region

#Region "Click"

    Private Sub cboLIRAACAD_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboLIRAACAD.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_ACTOADMI_Descripcion(Me.cboLIRAACAD, Me.cboLIRAACAD.SelectedIndex)
    End Sub
    Private Sub cboLIRAMERE_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboLIRAMERE.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_MEDIRESE_Descripcion(Me.cboLIRAMERE, Me.cboLIRAMERE.SelectedIndex)
    End Sub
    Private Sub cboLIRAMENO_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboLIRAMENO.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_MEDINOTI_Descripcion(Me.cboLIRAMENO, Me.cboLIRAMENO.SelectedIndex)
    End Sub
    Private Sub cboREMUUSUA_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboLIRADIVI.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_DIVISION_Descripcion(Me.cboLIRADIVI, Me.cboLIRADIVI.SelectedIndex)
    End Sub
    Private Sub cboMUTAESTA_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboLIRAESTA.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_ESTADO(Me.cboLIRAESTA, Me.cboLIRAESTA.SelectedIndex)
    End Sub

#End Region

#Region "ValueChanged"

    Private Sub dtpLIRAFERA_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpLIRAFERA.ValueChanged
        Me.txtLIRAFERA.Text = Me.dtpLIRAFERA.Value
    End Sub
    Private Sub dtpMUTAFERA_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpLIRAFEMN.ValueChanged
        Me.txtLIRAFEMN.Text = Me.dtpLIRAFEMN.Value
    End Sub
    Private Sub dtpLIRAFEAS_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpLIRAFEAS.ValueChanged
        Me.txtLIRAFEAS.Text = Me.dtpLIRAFEAS.Value
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