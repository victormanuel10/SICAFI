Imports REGLAS_DEL_NEGOCIO
Imports System.IO

Public Class frm_insertar_LIBRRADI

    '================================
    '*** INSERTAR LIBRO RADICADOR ***
    '================================

#Region "VARIABLE"

    Dim inID_REGISTRO As Integer

#End Region

#Region "CONSTRUCTOR"

    Public Sub New(ByVal inInRegistro As Integer)
        inID_REGISTRO = inInRegistro

        InitializeComponent()
    End Sub
    Public Sub New()

        InitializeComponent()

    End Sub

#End Region

#Region "PROCEDIMIENTOS"

    Private Sub pro_LimpiarCampos()

        Me.cboLIRAACAD.DataSource = New DataTable
        Me.cboLIRAMERE.DataSource = New DataTable
        Me.cboLIRAMENO.DataSource = New DataTable
        Me.cboLIRADIVI.DataSource = New DataTable
        Me.cboLIRAESTA.DataSource = New DataTable

        Me.txtLIRASECU.Text = "0"
        Me.lblLIRAACAD.Text = ""
        Me.lblLIRAMERE.Text = ""
        Me.txtLIRAASUN.Text = ""
        Me.txtLIRANURA.Text = ""
        Me.txtLIRAFERA.Text = ""
        Me.lblLIRAMENO.Text = ""
        Me.txtLIRAFEMN.Text = ""
        Me.lblLIRADIVI.Text = ""
        Me.txtLIRAOBSE.Text = ""
        Me.txtLIRAFEAS.Text = ""

    End Sub

#End Region

#Region "FUNCIONES"

    Private Function fun_NumeroDeSecuenciaDeRegistro() As Integer

        Try
            Dim inLIRASECU As Integer = 0

            Dim objdatos5 As New cla_LIBRRADI
            Dim tbl10 As New DataTable

            tbl10 = objdatos5.fun_Buscar_SECUENCIA_X_LIBRRADI

            If tbl10.Rows.Count = 0 Then
                inLIRASECU = 1
            Else
                Dim i As Integer
                Dim NroMayor As Integer
                Dim Posicion As Integer

                Posicion = Val(tbl10.Rows(0).Item("LIRASECU"))

                For i = 0 To tbl10.Rows.Count - 1
                    NroMayor = Val(tbl10.Rows(i).Item("LIRASECU"))

                    If NroMayor > Posicion Then
                        inLIRASECU = NroMayor
                        Posicion = NroMayor
                    Else
                        inLIRASECU = Posicion
                    End If
                Next

                inLIRASECU += 1
            End If

            Return inLIRASECU

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Function

#End Region

#Region "MENU"

    Private Sub cmdGUARDAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGUARDAR.Click

        Try

            ' instancia la clase
            Dim objdatos As New cla_LIBRRADI

            Dim boLLAVEPRIMARIA As Boolean = objdatos.fun_Verifica_llave_Primaria_LIBRRADI(Me.txtLIRANURA, Me.txtLIRAFERA)

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
            If boLLAVEPRIMARIA = True And _
               boLIRAACAD = True And _
               boLIRAMERE = True And _
               boLIRANURA = True And _
               boLIRAFERA = True And
               boLIRAASUN = True And _
               boLIRADIVI = True And _
               boLIRAFEAS = True And _
               boLIRAESTA = True Then

                If Trim(Me.txtLIRAOBSE.Text) <> "" Then
                    Me.txtLIRAOBSE.Text = " Nota ingresada por " & vp_usuario & " " & fun_fecha() & " : " & Trim(Me.txtLIRAOBSE.Text) & ". "
                End If

                Me.txtLIRASECU.Text = CStr(fun_NumeroDeSecuenciaDeRegistro())

                Dim objdatos22 As New cla_LIBRRADI

                If (objdatos22.fun_Insertar_LIBRRADI(Me.txtLIRASECU.Text, _
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
                                                     Me.txtLIRAOBSE.Text, _
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

                    mod_MENSAJE.Se_Guardaron_Los_Datos_Correctamente()

                    ' envia el ID al formulario principal
                    Dim objdatos1 As New cla_LIBRRADI
                    Dim tbl1 As New DataTable

                    tbl1 = objdatos1.fun_Buscar_CODIGO_X_LIBRRADI(CInt(Me.txtLIRASECU.Text))

                    If tbl1.Rows.Count > 0 Then

                        Dim inNroIdRe As New frm_LIBRRADI(tbl1.Rows(0).Item("LIRAIDRE"))

                    End If

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

#Region "Load"

    Private Sub frm_insertar_MUTACIONES_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        pro_LimpiarCampos()
        Me.txtLIRASECU.Text = fun_NumeroDeSecuenciaDeRegistro()
        Me.cboLIRAACAD.Focus()

    End Sub

#End Region

#Region "KeyPress"

    Private Sub txt_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboLIRAACAD.KeyPress, cboLIRAMERE.KeyPress, txtLIRANURA.KeyPress, txtLIRAFERA.KeyPress, txtLIRAASUN.KeyPress, cboLIRAMENO.KeyPress, txtLIRAFEMN.KeyPress, cboLIRADIVI.KeyPress, cboLIRAESTA.KeyPress, txtLIRAOBSE.KeyPress, txtLIRAFEAS.KeyPress
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

    Private Sub txt_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtLIRAOBSE.GotFocus, txtLIRAASUN.GotFocus, txtLIRAFEMN.GotFocus, txtLIRAFERA.GotFocus, txtLIRANURA.GotFocus, txtLIRAFEAS.GotFocus
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