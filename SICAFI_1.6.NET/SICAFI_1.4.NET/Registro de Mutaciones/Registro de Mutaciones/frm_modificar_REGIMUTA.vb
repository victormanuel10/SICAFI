Imports REGLAS_DEL_NEGOCIO
Imports System.IO

Public Class frm_modificar_REGIMUTA

    '=====================================
    '*** MODIFICAR REGISTRO MUTACIONES ***
    '=====================================

#Region "VARIABLE"

    Dim inID_REGISTRO As Integer
    Dim vl_stMOGENUDO As String = ""

#End Region

#Region "CONSTRUCTOR"

    Public Sub New(ByVal inInRegistro As Integer)
        inID_REGISTRO = inInRegistro

        InitializeComponent()
        pro_LimpiarCampos()
        pro_inicializarControles()
    End Sub
    Public Sub New(ByVal inInRegistro As Integer, ByVal stREMUNUDO As String)
        inID_REGISTRO = inInRegistro
        vl_stMOGENUDO = stREMUNUDO

        InitializeComponent()
        pro_LimpiarCampos()
        pro_inicializarControles()
    End Sub

#End Region

#Region "FUNCIONES"

    Private Function fun_NumeroDeSecuenciaDeRegistro() As Integer

        Try
            Dim inFPDESECU As Integer = 0

            Dim objdatos5 As New cla_REGIMUTA
            Dim tbl10 As New DataTable

            tbl10 = objdatos5.fun_Buscar_SECUENCIA_X_REGIMUTA

            If tbl10.Rows.Count = 0 Then
                inFPDESECU = 1
            Else
                Dim i As Integer
                Dim NroMayor As Integer
                Dim Posicion As Integer

                Posicion = Val(tbl10.Rows(0).Item("REMUSECU"))

                For i = 0 To tbl10.Rows.Count - 1
                    NroMayor = Val(tbl10.Rows(i).Item("REMUSECU"))

                    If NroMayor > Posicion Then
                        inFPDESECU = NroMayor
                        Posicion = NroMayor
                    Else
                        inFPDESECU = Posicion
                    End If
                Next

                inFPDESECU += 1
            End If

            Return inFPDESECU

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Function
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

    Private Sub pro_inicializarControles()

        Try
            Dim objdatos8 As New cla_REGIMUTA
            Dim tbl As New DataTable

            tbl = objdatos8.fun_Buscar_ID_REGIMUTA(inID_REGISTRO)

            Me.txtREMUSECU.Text = CStr(Trim(tbl.Rows(0).Item("REMUSECU")))

            Dim objdatos2 As New cla_VIGENCIA

            Me.cboREMUVIGE.DataSource = objdatos2.fun_Consultar_CAMPOS_VIGENCIA
            Me.cboREMUVIGE.DisplayMember = "VIGEDESC"
            Me.cboREMUVIGE.ValueMember = "VIGECODI"

            Me.cboREMUVIGE.SelectedValue = tbl.Rows(0).Item("REMUVIGE")

            Dim objdatos3 As New cla_PERIODO

            Me.cboREMUMES.DataSource = objdatos3.fun_Consultar_CAMPOS_MANT_PERIODO
            Me.cboREMUMES.DisplayMember = "PERIDESC"
            Me.cboREMUMES.ValueMember = "PERIMES"

            Me.cboREMUMES.SelectedValue = tbl.Rows(0).Item("REMUMES")

            Dim objdatos5 As New cla_USUARIO

            Me.cboREMUUSUA.DataSource = objdatos5.fun_Buscar_CODIGO_USUARIO(vl_stMOGENUDO)
            Me.cboREMUUSUA.DisplayMember = "USUANOMB"
            Me.cboREMUUSUA.ValueMember = "USUANUDO"

            Dim objdatos7 As New cla_ESTADO

            Me.cboREMUESTA.DataSource = objdatos7.fun_Consultar_TODOS_LOS_ESTADOS
            Me.cboREMUESTA.DisplayMember = "ESTADESC"
            Me.cboREMUESTA.ValueMember = "ESTACODI"

            Me.txtREMUFEAS.Text = Trim(tbl.Rows(0).Item("REMUFEAS"))
            Me.txtREMUFEFI.Text = Trim(tbl.Rows(0).Item("REMUFEFI"))

            Me.lblREMUVIGE.Text = CType(fun_Buscar_Lista_Valores_VIGENCIA_Codigo(Me.cboREMUVIGE), String)
            Me.lblREMUMES.Text = CType(fun_Buscar_Lista_Valores_MES_Codigo(Me.cboREMUVIGE, cboREMUMES), String)
            Me.lblREMUUSUA.Text = CType(fun_Buscar_Lista_Valores_USUARIO_Codigo(Me.cboREMUUSUA), String)

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub pro_LimpiarCampos()

        Me.cboREMUVIGE.DataSource = New DataTable
        Me.cboREMUMES.DataSource = New DataTable
        Me.cboREMUUSUA.DataSource = New DataTable
        Me.cboREMUESTA.DataSource = New DataTable

        Me.txtREMUSECU.Text = "0"
        Me.lblREMUVIGE.Text = ""
        Me.lblREMUMES.Text = ""
        Me.lblREMUUSUA.Text = ""

    End Sub

#End Region

#Region "MENU"

    Private Sub cmdGUARDAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGUARDAR.Click

        Try
            ' instancia la clase
            Dim objVerifica As New cla_Verificar_Dato

            Dim boREMUVIGE As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboREMUVIGE)
            Dim boREMUMES As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboREMUMES)
            Dim boREMUUSUA As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboREMUUSUA)
            Dim boREMUNUDO As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.lblREMUUSUA)
            Dim boREMUESTA As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboREMUESTA)
            Dim boUSUARIO As Boolean = False

            Dim stREMUUSUA As String = fun_ConsultaNombreUsuario(Me.cboREMUUSUA.SelectedValue)

            If Trim(stREMUUSUA) = "" Then
                boUSUARIO = False
                MessageBox.Show("El funcionario seleccionado no registra un perfil de usuario", "Mensaje...", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1)
            Else
                boUSUARIO = True
            End If

            ' verifica los datos del formulario 
            If boREMUVIGE = True And _
               boREMUMES = True And _
               boREMUNUDO = True And _
               boREMUUSUA = True And _
               boUSUARIO = True And _
               boREMUESTA = True Then

                ' instancia la clase
                Dim obREGIMUTA As New cla_REGIMUTA
                Dim dtREGIMUTA As New DataTable

                dtREGIMUTA = obREGIMUTA.fun_Buscar_ID_REGIMUTA(inID_REGISTRO)

                ' declara variables
                Dim stREMUOBSE As String = CStr(Trim(dtREGIMUTA.Rows(0).Item("REMUOBSE").ToString))
                Dim inREMUNUPR As String = CInt(dtREGIMUTA.Rows(0).Item("REMUNUPR").ToString)
                Dim inREMUNUAR As String = CInt(dtREGIMUTA.Rows(0).Item("REMUNUAR").ToString)

                If dtREGIMUTA.Rows.Count > 0 Then
                    stREMUOBSE = CStr(Trim(dtREGIMUTA.Rows(0).Item("REMUOBSE").ToString))
                End If

                Dim objdatos22 As New cla_REGIMUTA

                If (objdatos22.fun_Actualizar_REGIMUTA(inID_REGISTRO, _
                                                       Me.txtREMUSECU.Text, _
                                                       Me.cboREMUVIGE.SelectedValue, _
                                                       Me.cboREMUMES.SelectedValue, _
                                                       Me.txtREMUFEAS.Text.ToString.Replace("-", "/"), _
                                                       Me.txtREMUFEFI.Text.ToString.Replace("-", "/"), _
                                                       Trim(Me.lblREMUUSUA.Text), _
                                                       Trim(stREMUUSUA), _
                                                       Me.cboREMUESTA.SelectedValue, _
                                                       0,
                                                       0,
                                                       stREMUOBSE)) = True Then

                    mod_MENSAJE.Se_Modificaron_Los_Datos_Correctamente()

                    ' instancia la clase
                    Dim objRutas As New cla_RUTAS
                    Dim tblRutas As New DataTable

                    tblRutas = objRutas.fun_Buscar_CODIGO_MANT_RUTAS(15)

                    If tblRutas.Rows.Count > 0 Then

                        Dim stRuta As String = Me.cboREMUMES.SelectedValue & "-" & Me.cboREMUVIGE.SelectedValue

                        If System.IO.Directory.Exists(Trim(tblRutas.Rows(0).Item("RUTARUTA")) & "\" & stRuta) = False Then

                            System.IO.Directory.CreateDirectory(Trim(tblRutas.Rows(0).Item("RUTARUTA")) & "\" & stRuta)

                        End If

                    End If

                    Dim objdatos1 As New cla_REGIMUTA
                    Dim tbl1 As New DataTable

                    tbl1 = objdatos1.fun_Buscar_ID_REGIMUTA(CInt(inID_REGISTRO))

                    If tbl1.Rows.Count > 0 Then

                        Dim inNroIdRe As New frm_REGIMUTA(tbl1.Rows(0).Item("REMUIDRE"))

                    End If

                    Me.cboREMUVIGE.Focus()
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
        Dim inNroIdRe As New frm_REGIMUTA(inID_REGISTRO)
        Me.cboREMUVIGE.Focus()
        Me.Close()
    End Sub

#End Region

#Region "FORMULARIO"

#Region "KeyPress"

    Private Sub txt_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboREMUVIGE.KeyPress, cboREMUMES.KeyPress, cboREMUUSUA.KeyPress, cboREMUESTA.KeyPress, txtREMUFEAS.KeyPress, txtREMUFEFI.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Or e.KeyChar = Convert.ToChar(Keys.Tab) Then
            pp_pro_SaltarCampo()
        End If
    End Sub

#End Region

#Region "KeyDown"

    Private Sub cboREMUVIGE_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboREMUVIGE.KeyDown
        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
            fun_Cargar_ComboBox_Con_Datos_Activos_VIGENCIA_Descripcion(Me.cboREMUVIGE, Me.cboREMUVIGE.SelectedIndex)
        End If
    End Sub
    Private Sub cboREMUMES_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboREMUMES.KeyDown
        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
            fun_Cargar_ComboBox_Con_Datos_Activos_MES_X_VIGENCIA_Descripcion(Me.cboREMUMES, Me.cboREMUMES.SelectedIndex, Me.cboREMUVIGE)
        End If
    End Sub
    Private Sub cboREMUUSUA_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboREMUUSUA.KeyDown
        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
            fun_Cargar_ComboBox_Con_Datos_Activos_USUARIO_Descripcion(Me.cboREMUUSUA, Me.cboREMUUSUA.SelectedIndex)
        End If
    End Sub
    Private Sub cboMUTAESTA_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboREMUESTA.KeyDown
        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
            fun_Cargar_ComboBox_Con_Datos_Activos_ESTADO(Me.cboREMUESTA, Me.cboREMUESTA.SelectedIndex)
        End If
    End Sub

#End Region

#Region "GotFocus"

    Private Sub cmd_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdGUARDAR.GotFocus
        pp_pro_DescripcionCampo(Me.strBARRESTA.Items(0), sender)
    End Sub
    Private Sub cbo_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdSALIR.GotFocus
        pp_pro_DescripcionCampo(Me.strBARRESTA.Items(0), sender)
    End Sub

#End Region

#Region "SelectedIndexChanged"

    Private Sub cboMUTACLSE_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboREMUVIGE.SelectedIndexChanged
        Me.lblREMUVIGE.Text = CType(fun_Buscar_Lista_Valores_VIGENCIA_Codigo(Me.cboREMUVIGE), String)

        Me.cboREMUMES.DataSource = New DataTable
        Me.lblREMUMES.Text = ""
    End Sub
    Private Sub cboREMUMES_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboREMUMES.SelectedIndexChanged
        Me.lblREMUMES.Text = CType(fun_Buscar_Lista_Valores_MES_Codigo(Me.cboREMUVIGE, cboREMUMES), String)
    End Sub
    Private Sub cboMOGENUDO_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboREMUUSUA.SelectedIndexChanged
        Me.lblREMUUSUA.Text = CType(fun_Buscar_Lista_Valores_USUARIO_Codigo(Me.cboREMUUSUA), String)
    End Sub

#End Region

#Region "Click"

    Private Sub cboMUTACLSE_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboREMUVIGE.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_VIGENCIA_Descripcion(Me.cboREMUVIGE, Me.cboREMUVIGE.SelectedIndex)
    End Sub
    Private Sub cboREMUMES_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboREMUMES.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_MES_X_VIGENCIA_Descripcion(Me.cboREMUMES, Me.cboREMUMES.SelectedIndex, Me.cboREMUVIGE)
    End Sub
    Private Sub cboREMUUSUA_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboREMUUSUA.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_USUARIO_Descripcion(Me.cboREMUUSUA, Me.cboREMUUSUA.SelectedIndex)
    End Sub
    Private Sub cboMUTAESTA_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboREMUESTA.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_ESTADO(Me.cboREMUESTA, Me.cboREMUESTA.SelectedIndex)
    End Sub

#End Region

#Region "ValueChanged"

    Private Sub dtpTRCAFEES_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpREMUFEAS.ValueChanged
        Me.txtREMUFEAS.Text = Me.dtpREMUFEAS.Value
    End Sub
    Private Sub dtpMUTAFERA_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpREMUFEFI.ValueChanged
        Me.txtREMUFEFI.Text = Me.dtpREMUFEFI.Value
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