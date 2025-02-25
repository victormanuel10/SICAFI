Imports REGLAS_DEL_NEGOCIO

Public Class frm_estrato_ESTRFIPR

    '=============================
    '*** ESTRATO FICHA PREDIAL ***
    '=============================

#Region "VARIABLE"

    Dim vl_inFIPRNUFI As Integer = 0
    Dim vl_inFIPRESTR As Integer = 0

    Dim vl_boGUARDAR As Boolean = False
    Dim vl_boMODIFICAR As Boolean = False

#End Region

#Region "CONSTRUCTOR"

    Public Sub New(ByVal inFIPRNUFI As Integer)
        vl_inFIPRNUFI = inFIPRNUFI

        InitializeComponent()
        pro_LimpiarCampos()
        pro_inicializarControles()

    End Sub
    Public Sub New(ByVal inFIPRNUFI As Integer, ByVal inFIPRESTR As Integer)
        vl_inFIPRNUFI = inFIPRNUFI
        vl_inFIPRESTR = inFIPRESTR

        InitializeComponent()
        pro_LimpiarCampos()
        pro_inicializarControles()

    End Sub

#End Region

#Region "PROCEDIMIENTOS"

    Private Sub pro_inicializarControles()

        Try
            ' instancia la clase
            Dim objdatos1 As New cla_ESTRFIPR
            Dim tbl1 As New DataTable

            tbl1 = objdatos1.fun_Buscar_ESTRATO_X_NRO_DE_FICHA(vl_inFIPRNUFI)

            If tbl1.Rows.Count > 0 Then

                Dim objdatos As New cla_ESTADO

                Me.cboESFPESTA.DataSource = objdatos.fun_Consultar_TODOS_LOS_ESTADOS
                Me.cboESFPESTA.DisplayMember = "ESTADESC"
                Me.cboESFPESTA.ValueMember = "ESTACODI"

                Dim objdatos11 As New cla_ESTRATO

                Me.cboESFPESTR.DataSource = objdatos11.fun_Consultar_CAMPOS_MANT_ESTRATO
                Me.cboESFPESTR.DisplayMember = "ESTRCODI"
                Me.cboESFPESTR.ValueMember = "ESTRCODI"

                Me.cboESFPESTR.SelectedValue = tbl1.Rows(0).Item("ESFPESTR")
                Me.cboESFPESTA.SelectedValue = tbl1.Rows(0).Item("ESFPESTA")

                vl_inFIPRNUFI = tbl1.Rows(0).Item("ESFPNUFI")
                vl_inFIPRESTR = tbl1.Rows(0).Item("ESFPESTR")

                vl_boMODIFICAR = True
            Else
                vl_boGUARDAR = True

            End If

            pro_ListaDeValores()

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub pro_ListaDeValores()

        Try
            If Me.cboESFPESTR.Text <> "" Then

                Me.lblESFPESTR.Text = CStr(fun_Buscar_Lista_Valores_ESTRATO(Trim(Me.cboESFPESTR.Text)))
            Else
                Me.lblESFPESTR.Text = ""

            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub pro_LimpiarCampos()

        Me.cboESFPESTR.DataSource = New DataTable
        Me.cboESFPESTA.DataSource = New DataTable

        Me.lblESFPESTR.Text = ""

    End Sub

#End Region

#Region "MENU"

    Private Sub cmdGUARDAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGUARDAR.Click

        Try

            Dim objVerifica As New cla_Verificar_Dato

            Dim boESFPESTR As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboESFPESTR)
            Dim boESFPESTA As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboESFPESTA)

            ' verifica los datos del formulario 
            If boESFPESTR = True And _
               boESFPESTA = True Then

       
                ' guarda el registro
                If vl_boGUARDAR = True Then

                    Dim objdatos22 As New cla_ESTRFIPR

                    If (objdatos22.fun_Insertar_ESTRFIPR(vl_inFIPRNUFI, _
                                                         Me.cboESFPESTR.SelectedValue, _
                                                         Me.cboESFPESTA.SelectedValue)) = True Then

                        mod_MENSAJE.Se_Guardaron_Los_Datos_Correctamente()
                        Me.Close()
                    Else

                        mod_MENSAJE.No_Se_Guardo_El_Registro_En_La_Base_De_Datos()

                    End If

                    ' modifica el registro
                ElseIf vl_boMODIFICAR = True Then

                    Dim objdatos23 As New cla_ESTRFIPR

                    If objdatos23.fun_Eliminar_ESTRFIPR_X_NRO_FICHA_Y_ESTRATO(vl_inFIPRNUFI, vl_inFIPRESTR) = True Then

                        If (objdatos23.fun_Insertar_ESTRFIPR(vl_inFIPRNUFI, _
                                                             Me.cboESFPESTR.SelectedValue, _
                                                             Me.cboESFPESTA.SelectedValue)) = True Then

                            mod_MENSAJE.Se_Guardaron_Los_Datos_Correctamente()
                            Me.Close()

                        Else

                            mod_MENSAJE.No_Se_Guardo_El_Registro_En_La_Base_De_Datos()

                        End If

                    End If

                End If
            End If
             
        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub cmdCANCELAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSALIR.Click
        Me.cboESFPESTR.Focus()
        Me.Close()
    End Sub

#End Region

#Region "FORMULARIO"

#Region "Load"

    Private Sub frm_insertar_TARIALPU_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.cboESFPESTR.Focus()
    End Sub

#End Region

#Region "GotFocus"

    Private Sub frm_estrato_ESTRFIPR_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.GotFocus
        pro_ListaDeValores()
    End Sub

#End Region

#Region "KeyPress"

    Private Sub txt_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboESFPESTR.KeyPress, cboESFPESTA.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Or e.KeyChar = Convert.ToChar(Keys.Tab) Then
            pp_pro_SaltarCampo()
        End If
    End Sub

#End Region

#Region "KeyDown"

    Private Sub cboESFPESTR_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboESFPESTR.KeyDown
        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
            fun_Cargar_ComboBox_Con_Datos_Activos_ESTRATO(Me.cboESFPESTR, Me.cboESFPESTR.SelectedIndex)
        End If
    End Sub
    Private Sub cboESFPESTA_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboESFPESTA.KeyDown
        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
            fun_Cargar_ComboBox_Con_Datos_Activos_ESTADO(Me.cboESFPESTA, Me.cboESFPESTA.SelectedIndex)
        End If
    End Sub

#End Region

#Region "GotFocus"

     Private Sub cmd_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdGUARDAR.GotFocus, cmdSALIR.GotFocus
        pp_pro_DescripcionCampo(Me.strBARRESTA.Items(0), sender)
    End Sub
    Private Sub cbo_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboESFPESTR.GotFocus, cboESFPESTA.GotFocus
        pp_pro_DescripcionCampo(Me.strBARRESTA.Items(0), sender)
    End Sub

#End Region

#Region "SelectedIndexChanged"

    Private Sub cboESFPESTR_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboESFPESTR.SelectedIndexChanged
        Me.lblESFPESTR.Text = CType(fun_Buscar_Lista_Valores_ESTRATO(Me.cboESFPESTR.Text), String)
    End Sub

#End Region

#Region "Click"

    Private Sub cboESFPESTR_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboESFPESTR.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_ESTRATO(Me.cboESFPESTR, Me.cboESFPESTR.SelectedIndex)
    End Sub
    Private Sub cboPRANESTA_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboESFPESTA.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_ESTADO(Me.cboESFPESTA, Me.cboESFPESTA.SelectedIndex)
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