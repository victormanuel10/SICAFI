Imports REGLAS_DEL_NEGOCIO
Imports System.IO

Public Class frm_insertar_RESOLICE

    '=========================================
    '*** INSERTAR RESOLUCIONES Y LICENCIAS ***
    '=========================================

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

    Private Sub pro_GuardarPropietarios()

        Try
            ' declara las variables
            Dim stCiuculoRegistral As String = "001-"
            Dim stNroMatricula As String = fun_Formato_Mascara_7_Reales(Trim(Me.txtRELIMAIN.Text))
            Dim stMatricula As String = stCiuculoRegistral & stNroMatricula

            ' instancia la clase
            Dim obFIPRPROP As New cla_FIPRPROP
            Dim dtFIPRPROP As New DataTable

            dtFIPRPROP = obFIPRPROP.fun_Buscar_FIPRPROP_X_MATRICULA(stMatricula)

            If dtFIPRPROP.Rows.Count > 0 Then

                ' declara la variable
                Dim i As Integer = 0

                For i = 0 To dtFIPRPROP.Rows.Count - 1

                    ' declara las variables
                    Dim stFPPRNUDO As String = Trim(dtFIPRPROP.Rows(i).Item("FPPRNUDO").ToString)
                    Dim stFPPRNOMB As String = Trim(dtFIPRPROP.Rows(i).Item("FPPRNOMB").ToString)
                    Dim stFPPRPRAP As String = Trim(dtFIPRPROP.Rows(i).Item("FPPRPRAP").ToString)
                    Dim stFPPRSEAP As String = Trim(dtFIPRPROP.Rows(i).Item("FPPRSEAP").ToString)
                    Dim stFPPRDERE As String = Trim(dtFIPRPROP.Rows(i).Item("FPPRDERE").ToString)

                    ' instancia la clase
                    Dim obRELIPROP As New cla_RELIPROP

                    obRELIPROP.fun_Insertar_RELIPROP(CInt(Me.txtRELINURA.Text), _
                                                     CStr(Me.txtRELIFERA.Text), _
                                                     CInt(Me.txtRELISECU.Text), _
                                                     stFPPRNUDO, _
                                                     stFPPRNOMB, _
                                                     stFPPRPRAP, _
                                                     stFPPRSEAP, _
                                                     stFPPRDERE)

                Next

            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub pro_GuardarPredio()

        Try
            ' declara las variables
            Dim stCiuculoRegistral As String = "001-"
            Dim stNroMatricula As String = fun_Formato_Mascara_7_Reales(Trim(Me.txtRELIMAIN.Text))
            Dim stMatricula As String = stCiuculoRegistral & stNroMatricula

            ' instancia la clase
            Dim obFIPRPROP As New cla_FIPRPROP
            Dim dtFIPRPROP As New DataTable

            dtFIPRPROP = obFIPRPROP.fun_Buscar_FIPRPROP_X_MATRICULA(stMatricula)

            If dtFIPRPROP.Rows.Count > 0 Then

                ' declara la clase
                Dim obFICHPRED As New cla_FICHPRED
                Dim dtFICHPRED As New DataTable

                dtFICHPRED = obFICHPRED.fun_Consultar_FICHA_PREDIAL_X_NRO_FICHA_PREDIAL(dtFIPRPROP.Rows(0).Item("FPPRNUFI").ToString)

                If dtFICHPRED.Rows.Count > 0 Then

                    ' declara las variables
                    Dim stFIPRNUFI As String = Trim(dtFICHPRED.Rows(0).Item("FIPRNUFI").ToString)
                    Dim stFIPRMUNI As String = Trim(dtFICHPRED.Rows(0).Item("FIPRMUNI").ToString)
                    Dim stFIPRCORR As String = Trim(dtFICHPRED.Rows(0).Item("FIPRCORR").ToString)
                    Dim stFIPRBARR As String = Trim(dtFICHPRED.Rows(0).Item("FIPRBARR").ToString)
                    Dim stFIPRMANZ As String = Trim(dtFICHPRED.Rows(0).Item("FIPRMANZ").ToString)
                    Dim stFIPRPRED As String = Trim(dtFICHPRED.Rows(0).Item("FIPRPRED").ToString)
                    Dim stFIPREDIF As String = Trim(dtFICHPRED.Rows(0).Item("FIPREDIF").ToString)
                    Dim stFIPRUNPR As String = Trim(dtFICHPRED.Rows(0).Item("FIPRUNPR").ToString)
                    Dim stFIPRCLSE As String = Trim(dtFICHPRED.Rows(0).Item("FIPRCLSE").ToString)

                    ' instancia la clase
                    Dim obRELIPROP As New cla_RELIPRED

                    obRELIPROP.fun_Insertar_RELIPRED(CInt(Me.txtRELINURA.Text), _
                                                     CStr(Me.txtRELIFERA.Text), _
                                                     CInt(Me.txtRELISECU.Text), _
                                                     Trim(Me.txtRELIMAIN.Text), _
                                                     stFIPRMUNI, _
                                                     stFIPRCORR, _
                                                     stFIPRBARR, _
                                                     stFIPRMANZ, _
                                                     stFIPRPRED, _
                                                     stFIPREDIF, _
                                                     stFIPRUNPR, _
                                                     stFIPRCLSE, _
                                                     stFIPRNUFI)

                End If

            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub pro_LimpiarCampos()

        Me.cboRELICLEN.DataSource = New DataTable
        Me.cboRELIVIGE.DataSource = New DataTable
        Me.cboRELIESTA.DataSource = New DataTable

        Me.txtRELISECU.Text = "0"
        Me.lblRELICLEN.Text = ""
        Me.txtRELIMAIN.Text = ""
        Me.txtRELINURA.Text = ""
        Me.txtRELIFERA.Text = ""
        Me.lblRELIVIGE.Text = ""
        Me.txtRELIOBSE.Text = ""
        Me.txtRELIFEAS.Text = ""

    End Sub

#End Region

#Region "FUNCIONES"

    Private Function fun_NumeroDeSecuenciaDeRegistro() As Integer

        Try
            Dim inLIRASECU As Integer = 0

            Dim objdatos5 As New cla_RESOLICE
            Dim tbl10 As New DataTable

            tbl10 = objdatos5.fun_Buscar_SECUENCIA_X_RESOLICE

            If tbl10.Rows.Count = 0 Then
                inLIRASECU = 1
            Else
                Dim i As Integer
                Dim NroMayor As Integer
                Dim Posicion As Integer

                Posicion = Val(tbl10.Rows(0).Item("RELISECU"))

                For i = 0 To tbl10.Rows.Count - 1
                    NroMayor = Val(tbl10.Rows(i).Item("RELISECU"))

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
            Dim objdatos As New cla_RESOLICE

            Dim boLLAVEPRIMARIA As Boolean = objdatos.fun_Verifica_llave_Primaria_RESOLICE(Me.txtRELINURA, Me.txtRELIFERA)

            ' instancia la clase
            Dim objVerifica As New cla_Verificar_Dato

            Dim boLIRACLEN As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboRELICLEN)
            Dim boLIRANURA As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Numerico(Me.txtRELINURA)
            Dim boLIRAFERA As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Fecha(Me.txtRELIFERA)
            Dim boLIRAVIGE As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboRELIVIGE)
            Dim boLIRAMAIN As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Numerico(Me.txtRELIMAIN)
            Dim boLIRAFEAS As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Fecha(Me.txtRELIFEAS)
            Dim boLIRAESTA As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboRELIESTA)

            ' verifica los datos del formulario 
            If boLLAVEPRIMARIA = True And _
               boLIRACLEN = True And _
               boLIRANURA = True And _
               boLIRAFERA = True And _
               boLIRAVIGE = True And _
               boLIRAMAIN = True And _
               boLIRAFEAS = True And _
               boLIRAESTA = True Then

                If Trim(Me.txtRELIOBSE.Text) <> "" Then
                    Me.txtRELIOBSE.Text = " Nota ingresada por " & vp_usuario & " " & fun_fecha() & " : " & Trim(Me.txtRELIOBSE.Text) & ". "
                End If

                Me.txtRELISECU.Text = CStr(fun_NumeroDeSecuenciaDeRegistro())

                Dim objdatos22 As New cla_RESOLICE

                If (objdatos22.fun_Insertar_RESOLICE(Me.txtRELISECU.Text, _
                                                     Me.cboRELICLEN.SelectedValue, _
                                                     Me.txtRELINURA.Text, _
                                                     Me.txtRELIFERA.Text, _
                                                     Me.cboRELIVIGE.SelectedValue, _
                                                     Me.txtRELIFEAS.Text, _
                                                     Me.txtRELIMAIN.Text, _
                                                     Me.txtRELIOBSE.Text, _
                                                     Me.cboRELIESTA.SelectedValue)) = True Then

                    pro_GuardarPropietarios()
                    pro_GuardarPredio()

                    ' instancia la clase
                    Dim objRutas As New cla_RUTAS
                    Dim tblRutas As New DataTable

                    tblRutas = objRutas.fun_Buscar_CODIGO_MANT_RUTAS(18)

                    If tblRutas.Rows.Count > 0 Then

                        Dim stRuta As String = Trim(Me.cboRELICLEN.SelectedValue) & "-" & Trim(Me.txtRELINURA.Text) & "-" & Trim(Me.cboRELIVIGE.SelectedValue)

                        If System.IO.Directory.Exists(Trim(tblRutas.Rows(0).Item("RUTARUTA")) & "\" & stRuta) = False Then

                            System.IO.Directory.CreateDirectory(Trim(tblRutas.Rows(0).Item("RUTARUTA")) & "\" & stRuta)

                        End If

                    End If

                    mod_MENSAJE.Se_Guardaron_Los_Datos_Correctamente()

                    ' envia el ID al formulario principal
                    Dim objdatos1 As New cla_RESOLICE
                    Dim tbl1 As New DataTable

                    tbl1 = objdatos1.fun_Buscar_CODIGO_X_RESOLICE(CInt(Me.txtRELISECU.Text))

                    If tbl1.Rows.Count > 0 Then

                        Dim inNroIdRe As New frm_RESOLICE(tbl1.Rows(0).Item("RELIIDRE"))

                    End If

                    Me.cboRELICLEN.Focus()
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
        Dim inNroIdRe As New frm_RESOLICE(inID_REGISTRO)
        Me.cboRELICLEN.Focus()
        Me.Close()
    End Sub

#End Region

#Region "FORMULARIO"

#Region "Load"

    Private Sub frm_insertar_MUTACIONES_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        pro_LimpiarCampos()
        Me.txtRELISECU.Text = fun_NumeroDeSecuenciaDeRegistro()
        Me.cboRELICLEN.Focus()

    End Sub

#End Region

#Region "KeyPress"

    Private Sub txt_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboRELICLEN.KeyPress, txtRELINURA.KeyPress, txtRELIFERA.KeyPress, txtRELIMAIN.KeyPress, cboRELIVIGE.KeyPress, cboRELIESTA.KeyPress, txtRELIOBSE.KeyPress, txtRELIFEAS.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Or e.KeyChar = Convert.ToChar(Keys.Tab) Then
            pp_pro_SaltarCampo()
        End If
    End Sub

#End Region

#Region "KeyDown"

    Private Sub cboRELICLEN_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboRELICLEN.KeyDown
        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
            fun_Cargar_ComboBox_Con_Datos_Activos_CLASENTI_Descripcion(Me.cboRELICLEN, Me.cboRELICLEN.SelectedIndex)
        End If
    End Sub
    Private Sub cboLIRAMENO_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboRELIVIGE.KeyDown
        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
            fun_Cargar_ComboBox_Con_Datos_Activos_VIGENCIA_Descripcion(Me.cboRELIVIGE, Me.cboRELIVIGE.SelectedIndex)
        End If
    End Sub
    Private Sub cboLIRAESTA_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboRELIESTA.KeyDown
        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
            fun_Cargar_ComboBox_Con_Datos_Activos_ESTADO(Me.cboRELIESTA, Me.cboRELIESTA.SelectedIndex)
        End If
    End Sub

#End Region

#Region "GotFocus"

    Private Sub txt_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtRELIOBSE.GotFocus, txtRELIMAIN.GotFocus, txtRELIFERA.GotFocus, txtRELINURA.GotFocus, txtRELIFEAS.GotFocus
        pp_pro_SobrearCampo(sender)
        pp_pro_DescripcionCampo(Me.strBARRESTA.Items(0), sender)
    End Sub
    Private Sub cmd_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdGUARDAR.GotFocus, cmdSALIR.GotFocus
        pp_pro_DescripcionCampo(Me.strBARRESTA.Items(0), sender)
    End Sub
    Private Sub cbo_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboRELICLEN.GotFocus, cboRELIESTA.GotFocus, cboRELIVIGE.GotFocus
        pp_pro_DescripcionCampo(Me.strBARRESTA.Items(0), sender)
    End Sub

#End Region

#Region "SelectedIndexChanged"

    Private Sub cboRELICLEN_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboRELICLEN.SelectedIndexChanged
        Me.lblRELICLEN.Text = CType(fun_Buscar_Lista_Valores_CLASENTI_Codigo(Me.cboRELICLEN), String)
    End Sub
 
    Private Sub cboLIRAMENO_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboRELIVIGE.SelectedIndexChanged
        Me.lblRELIVIGE.Text = CType(fun_Buscar_Lista_Valores_VIGENCIA_Codigo(Me.cboRELIVIGE), String)
    End Sub

#End Region

#Region "Click"

    Private Sub cboRELICLEN_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboRELICLEN.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_CLASENTI_Descripcion(Me.cboRELICLEN, Me.cboRELICLEN.SelectedIndex)
    End Sub
    Private Sub cboLIRAMENO_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboRELIVIGE.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_VIGENCIA_Descripcion(Me.cboRELIVIGE, Me.cboRELIVIGE.SelectedIndex)
    End Sub
    Private Sub cboMUTAESTA_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboRELIESTA.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_ESTADO(Me.cboRELIESTA, Me.cboRELIESTA.SelectedIndex)
    End Sub

#End Region

#Region "ValueChanged"

    Private Sub dtpLIRAFERA_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpRELIFERA.ValueChanged
        Me.txtRELIFERA.Text = Me.dtpRELIFERA.Value
    End Sub
    Private Sub dtpLIRAFEAS_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpRELIFEAS.ValueChanged
        Me.txtRELIFEAS.Text = Me.dtpRELIFEAS.Value
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