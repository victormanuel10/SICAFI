Imports REGLAS_DEL_NEGOCIO
Imports System.IO

Public Class frm_modificar_RESOCONS

    '==============================================
    '*** MODIFICAR RESOLUCIONES DE CONSERVACION ***
    '==============================================

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
            Dim objdatos8 As New cla_RESOCONS
            Dim tbl As New DataTable

            tbl = objdatos8.fun_Buscar_ID_RESOCONS(inID_REGISTRO)

            If tbl.Rows.Count > 0 Then

                Me.txtRECOSECU.Text = CStr(Trim(tbl.Rows(0).Item("RECOSECU")))

                Dim objdatos2 As New cla_CLASIFICACION

                Me.cboRECOCLAS.DataSource = objdatos2.fun_Consultar_CAMPOS_MANT_CLASIFICACION
                Me.cboRECOCLAS.DisplayMember = "CLASDESC"
                Me.cboRECOCLAS.ValueMember = "CLASCODI"

                Me.cboRECOCLAS.SelectedValue = tbl.Rows(0).Item("RECOCLAS")

                Me.txtRECONURE.Text = Trim(tbl.Rows(0).Item("RECONURE"))
                Me.txtRECOFERE.Text = Trim(tbl.Rows(0).Item("RECOFERE"))

                Dim objdatos55 As New cla_CLASSECT

                Me.cboRECOCLSE.DataSource = objdatos55.fun_Consultar_CAMPOS_MANT_CLASSECT
                Me.cboRECOCLSE.DisplayMember = "CLSEDESC"
                Me.cboRECOCLSE.ValueMember = "CLSECODI"

                Me.cboRECOCLSE.SelectedValue = tbl.Rows(0).Item("RECOCLSE")

                Dim objdatos5 As New cla_VIGENCIA

                Me.cboRECOVIRE.DataSource = objdatos5.fun_Consultar_CAMPOS_VIGENCIA
                Me.cboRECOVIRE.DisplayMember = "VIGEDESC"
                Me.cboRECOVIRE.ValueMember = "VIGECODI"

                Me.cboRECOVIRE.SelectedValue = tbl.Rows(0).Item("RECOVIRE")

                Dim objdatos57 As New cla_VIGENCIA

                Me.cboRECOVIFI.DataSource = objdatos57.fun_Consultar_CAMPOS_VIGENCIA
                Me.cboRECOVIFI.DisplayMember = "VIGEDESC"
                Me.cboRECOVIFI.ValueMember = "VIGECODI"

                Me.cboRECOVIFI.SelectedValue = tbl.Rows(0).Item("RECOVIFI")

                Me.txtRECONURA.Text = Trim(tbl.Rows(0).Item("RECONURA"))
                Me.txtRECOFERA.Text = Trim(tbl.Rows(0).Item("RECOFERA"))
                Me.txtRECODESC.Text = Trim(tbl.Rows(0).Item("RECODESC"))

                Dim objdatos7 As New cla_ESTADO

                Me.cboRECOESTA.DataSource = objdatos7.fun_Consultar_TODOS_LOS_ESTADOS
                Me.cboRECOESTA.DisplayMember = "ESTADESC"
                Me.cboRECOESTA.ValueMember = "ESTACODI"

                Me.cboRECOESTA.SelectedValue = tbl.Rows(0).Item("RECOESTA")
                Me.nudRECOUNID.Value = tbl.Rows(0).Item("RECOUNID")

                Me.txtRECOFEES.Text = CStr(Trim(tbl.Rows(0).Item("RECOFEES")))
                Me.chkRECOAJPR.Checked = CBool(tbl.Rows(0).Item("RECOAJPR"))
                Me.chkRECOAJVA.Checked = CBool(tbl.Rows(0).Item("RECOAJVA"))

            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub pro_LimpiarCampos()

        Me.cboRECOCLAS.DataSource = New DataTable
        Me.cboRECOCLSE.DataSource = New DataTable
        Me.cboRECOVIRE.DataSource = New DataTable
        Me.cboRECOVIFI.DataSource = New DataTable
        Me.cboRECOESTA.DataSource = New DataTable

        Me.txtRECOSECU.Text = "0"
        Me.txtRECONURE.Text = ""
        Me.txtRECOFERE.Text = ""
        Me.txtRECONURA.Text = ""
        Me.txtRECOFERA.Text = ""
        Me.txtRECODESC.Text = ""
        Me.txtRECOFEES.Text = ""

    End Sub

#End Region

#Region "FUNCIONES"

    Private Function fun_NumeroDeSecuenciaDeRegistro() As Integer

        Try
            Dim inLIRASECU As Integer = 0

            Dim objdatos5 As New cla_RESOCONS
            Dim tbl10 As New DataTable

            tbl10 = objdatos5.fun_Buscar_SECUENCIA_X_RESOCONS

            If tbl10.Rows.Count = 0 Then
                inLIRASECU = 1
            Else
                Dim i As Integer
                Dim NroMayor As Integer
                Dim Posicion As Integer

                Posicion = Val(tbl10.Rows(0).Item("RECOSECU"))

                For i = 0 To tbl10.Rows.Count - 1
                    NroMayor = Val(tbl10.Rows(i).Item("RECOSECU"))

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
            Dim objVerifica As New cla_Verificar_Dato

            Dim boLIRACLEN As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboRECOCLAS)
            Dim boLIRANURE As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Numerico(Me.txtRECONURE)
            Dim boLIRAFERE As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Fecha(Me.txtRECOFERE)
            Dim boLIRAVIRE As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboRECOVIRE)
            Dim boLIRAVIFI As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboRECOVIFI)
            Dim boLIRANURA As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Numerico(Me.txtRECONURA)
            Dim boLIRAFERA As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Fecha(Me.txtRECOFERA)
            Dim boLIRAFEES As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Fecha(Me.txtRECOFEES)
            Dim boLIRAESTA As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboRECOESTA)

            ' verifica los datos del formulario 
            If boLIRACLEN = True And _
               boLIRANURE = True And _
               boLIRAFERE = True And _
               boLIRAVIRE = True And _
               boLIRAVIFI = True And _
               boLIRANURA = True And _
               boLIRAFERA = True And _
               boLIRAFEES = True And _
               boLIRAESTA = True Then

                Dim objdatos22 As New cla_RESOCONS

                If (objdatos22.fun_Actualizar_RESOCONS(inID_REGISTRO, _
                                                       Me.cboRECOCLAS.SelectedValue, _
                                                       Me.txtRECONURE.Text, _
                                                       Me.txtRECOFERE.Text, _
                                                       Me.cboRECOCLSE.SelectedValue, _
                                                       Me.cboRECOVIRE.SelectedValue, _
                                                       Me.cboRECOVIFI.SelectedValue, _
                                                       Me.txtRECONURA.Text, _
                                                       Me.txtRECOFERA.Text, _
                                                       Me.txtRECODESC.Text, _
                                                       Me.txtRECOFEES.Text, _
                                                       Me.chkRECOAJPR.Checked, _
                                                       Me.chkRECOAJVA.Checked, _
                                                       Me.nudRECOUNID.Value, _
                                                       Me.cboRECOESTA.SelectedValue)) = True Then


                    ' instancia la clase
                    Dim objRutas As New cla_RUTAS
                    Dim tblRutas As New DataTable

                    tblRutas = objRutas.fun_Buscar_CODIGO_MANT_RUTAS(20)

                    If tblRutas.Rows.Count > 0 Then

                        Dim stRuta As String = Trim(Me.txtRECONURE.Text) & "-" & Trim(Me.txtRECOFERE.Text)

                        If System.IO.Directory.Exists(Trim(tblRutas.Rows(0).Item("RUTARUTA")) & "\" & stRuta) = False Then

                            System.IO.Directory.CreateDirectory(Trim(tblRutas.Rows(0).Item("RUTARUTA")) & "\" & stRuta)

                        End If

                    End If

                    mod_MENSAJE.Se_Guardaron_Los_Datos_Correctamente()

                    ' envia el ID al formulario principal
                    Dim objdatos1 As New cla_RESOCONS
                    Dim tbl1 As New DataTable

                    tbl1 = objdatos1.fun_Buscar_CODIGO_X_RESOCONS(CInt(Me.txtRECOSECU.Text))

                    If tbl1.Rows.Count > 0 Then

                        Dim inNroIdRe As New frm_RESOCONS(tbl1.Rows(0).Item("RECOIDRE"))

                    End If

                    Me.cboRECOCLAS.Focus()
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
        Dim inNroIdRe As New frm_RESOCONS(inID_REGISTRO)
        Me.cboRECOCLAS.Focus()
        Me.Close()
    End Sub

#End Region

#Region "FORMULARIO"

#Region "Load"

    Private Sub frm_insertar_MUTACIONES_Load(ByVal sender As System.Object, ByVal e As System.EventArgs)

        pro_LimpiarCampos()

        Me.txtRECOSECU.Text = fun_NumeroDeSecuenciaDeRegistro()
        Me.cboRECOCLAS.Focus()

    End Sub

#End Region

#Region "KeyPress"

    Private Sub txt_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboRECOCLAS.KeyPress, txtRECONURE.KeyPress, txtRECOFERE.KeyPress, cboRECOCLSE.KeyPress, cboRECOVIRE.KeyPress, cboRECOVIFI.KeyPress, txtRECONURA.KeyPress, txtRECOFERA.KeyPress, txtRECODESC.KeyPress, cboRECOESTA.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Or e.KeyChar = Convert.ToChar(Keys.Tab) Then
            pp_pro_SaltarCampo()
        End If
    End Sub

#End Region

#Region "KeyDown"

    Private Sub cboRECOCLAS_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboRECOCLAS.KeyDown
        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
            fun_Cargar_ComboBox_Con_Datos_Activos_CLASIFICACION_Descripcion(Me.cboRECOCLAS, Me.cboRECOCLAS.SelectedIndex)
        End If
    End Sub
    Private Sub cboRECOCLSE_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboRECOCLSE.KeyDown
        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
            fun_Cargar_ComboBox_Con_Datos_Activos_CLASSECT_Descripcion(Me.cboRECOCLSE, Me.cboRECOCLSE.SelectedIndex)
        End If
    End Sub
    Private Sub cboRECOVIRE_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboRECOVIRE.KeyDown
        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
            fun_Cargar_ComboBox_Con_Datos_Activos_VIGENCIA_Descripcion(Me.cboRECOVIRE, Me.cboRECOVIRE.SelectedIndex)
        End If
    End Sub
    Private Sub cboRECOVIFI_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboRECOVIFI.KeyDown
        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
            fun_Cargar_ComboBox_Con_Datos_Activos_VIGENCIA_Descripcion(Me.cboRECOVIFI, Me.cboRECOVIFI.SelectedIndex)
        End If
    End Sub
    Private Sub cboRECOESTA_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboRECOESTA.KeyDown
        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
            fun_Cargar_ComboBox_Con_Datos_Activos_ESTADO(Me.cboRECOESTA, Me.cboRECOESTA.SelectedIndex)
        End If
    End Sub

#End Region

#Region "GotFocus"

    Private Sub txt_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtRECONURE.GotFocus, txtRECOFERE.GotFocus, txtRECONURA.GotFocus, txtRECOFERA.GotFocus, txtRECODESC.GotFocus
        pp_pro_SobrearCampo(sender)
        pp_pro_DescripcionCampo(Me.strBARRESTA.Items(0), sender)
    End Sub
    Private Sub cmd_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdGUARDAR.GotFocus, cmdSALIR.GotFocus
        pp_pro_DescripcionCampo(Me.strBARRESTA.Items(0), sender)
    End Sub
    Private Sub cbo_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboRECOCLAS.GotFocus, cboRECOESTA.GotFocus, cboRECOVIRE.GotFocus, cboRECOVIFI.GotFocus
        pp_pro_DescripcionCampo(Me.strBARRESTA.Items(0), sender)
    End Sub

#End Region

#Region "Click"

    Private Sub cboRECOCLAS_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboRECOCLAS.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_CLASIFICACION_Descripcion(Me.cboRECOCLAS, Me.cboRECOCLAS.SelectedIndex)
    End Sub
    Private Sub cboRECOCLSE_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboRECOCLSE.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_CLASSECT_Descripcion(Me.cboRECOCLSE, Me.cboRECOCLSE.SelectedIndex)
    End Sub
    Private Sub cboRECOVIRE_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboRECOVIRE.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_VIGENCIA_Descripcion(Me.cboRECOVIRE, Me.cboRECOVIRE.SelectedIndex)
    End Sub
    Private Sub cboRECOVIFI_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboRECOVIFI.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_VIGENCIA_Descripcion(Me.cboRECOVIFI, Me.cboRECOVIFI.SelectedIndex)
    End Sub
    Private Sub cboRECOESTA_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboRECOESTA.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_ESTADO(Me.cboRECOESTA, Me.cboRECOESTA.SelectedIndex)
    End Sub

#End Region

#Region "ValueChanged"

    Private Sub dtpRECOFERE_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpRECOFERE.ValueChanged
        Me.txtRECOFERE.Text = Me.dtpRECOFERE.Value
    End Sub
    Private Sub dtpRECOFERA_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpRECOFERA.ValueChanged
        Me.txtRECOFERA.Text = Me.dtpRECOFERA.Value
    End Sub
    Private Sub dtpRECOFEES_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpRECOFEES.ValueChanged
        Me.txtRECOFEES.Text = Me.dtpRECOFEES.Value
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