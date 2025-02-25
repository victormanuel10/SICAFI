Imports REGLAS_DEL_NEGOCIO
Imports System.IO

Public Class frm_insertar_REGIMUTA

    '=======================================
    '*** INSERTAR REGISTRO DE MUTACIONES ***
    '=======================================

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

        Me.cboREMUVIGE.DataSource = New DataTable
        Me.cboREMUMES.DataSource = New DataTable
        Me.cboREMUUSUA.DataSource = New DataTable
        Me.cboREMUESTA.DataSource = New DataTable

        Me.txtREMUSECU.Text = "0"
        Me.lblREMUVIGE.Text = ""
        Me.lblREMUMES.Text = ""
        Me.lblREMUUSUA.Text = ""
        Me.txtREMUOBSE.Text = ""

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

#Region "MENU"

    Private Sub cmdGUARDAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGUARDAR.Click

        Try

            ' instancia la clase
            Dim objdatos As New cla_REGIMUTA

            Dim boLLAVEPRIMARIA As Boolean = objdatos.fun_Verifica_llave_Primaria_REGIMUTA(Me.cboREMUVIGE, Me.cboREMUMES)

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
            If boLLAVEPRIMARIA = True And _
               boREMUVIGE = True And _
               boREMUMES = True And _
               boREMUNUDO = True And _
               boREMUUSUA = True And _
               boUSUARIO = True And _
               boREMUESTA = True Then

                If Trim(Me.txtREMUOBSE.Text) <> "" Then
                    Dim stREMUOBSE_ACTUAL As String = " Nota ingresada por " & vp_usuario & " " & fun_fecha() & " : " & Trim(Me.txtREMUOBSE.Text) & ". "
                End If

                Me.txtREMUSECU.Text = CStr(fun_NumeroDeSecuenciaDeRegistro())

                Dim objdatos22 As New cla_REGIMUTA

                If (objdatos22.fun_Insertar_REGIMUTA(Me.txtREMUSECU.Text, _
                                                     Me.cboREMUVIGE.SelectedValue, _
                                                     Me.cboREMUMES.SelectedValue, _
                                                     Me.txtREMUFEAS.Text.ToString.Replace("-", "/"), _
                                                     Me.txtREMUFEFI.Text.ToString.Replace("-", "/"), _
                                                     Trim(Me.lblREMUUSUA.Text), _
                                                     Trim(stREMUUSUA), _
                                                     Me.cboREMUESTA.SelectedValue, _
                                                     0,
                                                     0,
                                                     Me.txtREMUOBSE.Text)) = True Then

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

                    mod_MENSAJE.Se_Guardaron_Los_Datos_Correctamente()

                    If MessageBox.Show("¿ Desea agregar otro registro ?", "Mensaje...", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.No Then

                        Me.cboREMUVIGE.Focus()
                        Me.Close()
                    Else
                        pro_LimpiarCampos()
                        Me.txtREMUSECU.Text = fun_NumeroDeSecuenciaDeRegistro()
                        Me.cboREMUVIGE.Focus()
                    End If

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

#Region "Load"

    Private Sub frm_insertar_MUTACIONES_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        pro_LimpiarCampos()
        Me.txtREMUSECU.Text = fun_NumeroDeSecuenciaDeRegistro()
        Me.cboREMUVIGE.Focus()

    End Sub

#End Region

#Region "KeyPress"

    Private Sub txt_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboREMUESTA.KeyPress, txtREMUOBSE.KeyPress, cboREMUMES.KeyPress, cboREMUVIGE.KeyPress, cboREMUUSUA.KeyPress
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

    Private Sub txt_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtREMUOBSE.GotFocus
        pp_pro_SobrearCampo(sender)
        pp_pro_DescripcionCampo(Me.strBARRESTA.Items(0), sender)
    End Sub
    Private Sub cmd_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdGUARDAR.GotFocus, cmdSALIR.GotFocus
        pp_pro_DescripcionCampo(Me.strBARRESTA.Items(0), sender)
    End Sub
    Private Sub cbo_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboREMUVIGE.GotFocus, cboREMUESTA.GotFocus, cboREMUMES.GotFocus, cboREMUUSUA.GotFocus
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