Imports REGLAS_DEL_NEGOCIO
Imports System.IO

Public Class frm_insertar_RESOADMI

    '=========================================
    '*** INSERTAR RESOLUCION ADMINISTRADOR ***
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

    Private Sub pro_LimpiarCampos()

        Me.cboREADCLAS.DataSource = New DataTable
        Me.cboREADCLSE.DataSource = New DataTable
        Me.cboREADVIRE.DataSource = New DataTable
        Me.cboREADTIRE.DataSource = New DataTable
        Me.cboREADESTA.DataSource = New DataTable

        Me.txtREADNURE.Text = ""
        Me.txtREADFERE.Text = ""

    End Sub

#End Region

#Region "MENU"

    Private Sub cmdGUARDAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGUARDAR.Click

        Try
            ' instancia la clase
            Dim objdatos As New cla_RESOADMI

            Dim boLLAVEPRIMARIA As Boolean = objdatos.fun_Verifica_llave_Primaria_RESOADMI(Me.txtREADNURE, Me.txtREADFERE)

            ' instancia la clase
            Dim objVerifica As New cla_Verificar_Dato

            Dim boREADCLEN As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboREADCLAS)
            Dim boREADNURE As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Numerico(Me.txtREADNURE)
            Dim boREADFERE As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Fecha(Me.txtREADFERE)
            Dim boREADTIRE As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboREADTIRE)
            Dim boREADCLSE As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboREADCLSE)
            Dim boREADVIRE As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboREADVIRE)
            Dim boREADESTA As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboREADESTA)

            ' verifica los datos del formulario 
            If boLLAVEPRIMARIA = True And _
               boREADCLEN = True And _
               boREADNURE = True And _
               boREADFERE = True And _
               boREADTIRE = True And _
               boREADCLSE = True And _
               boREADVIRE = True And _
               boREADESTA = True Then

                Dim objdatos22 As New cla_RESOADMI

                If (objdatos22.fun_Insertar_RESOADMI(Me.cboREADCLAS.SelectedValue, _
                                                     Me.txtREADNURE.Text, _
                                                     Me.txtREADFERE.Text, _
                                                     Me.cboREADTIRE.SelectedValue, _
                                                     Me.cboREADCLSE.SelectedValue, _
                                                     Me.cboREADVIRE.SelectedValue, _
                                                     Me.cboREADESTA.SelectedValue)) = True Then

                    mod_MENSAJE.Se_Guardaron_Los_Datos_Correctamente()

                    ' envia el ID al formulario principal
                    Dim objdatos1 As New cla_RESOADMI
                    Dim tbl1 As New DataTable

                    tbl1 = objdatos1.fun_Buscar_CODIGO_X_RESOADMI(CInt(Me.txtREADNURE.Text), CStr(Me.txtREADFERE.Text))

                    If tbl1.Rows.Count > 0 Then

                        Dim inNroIdRe As New frm_RESOADMI(tbl1.Rows(0).Item("READIDRE"))

                    End If


                    Me.cboREADCLAS.Focus()
                    Me.Close()

                Else
                    mod_MENSAJE.No_Se_Guardo_El_Registro_En_La_Base_De_Datos()
                End If

            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub cmdSALIR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSALIR.Click
        Me.cboREADCLAS.Focus()
        Me.Close()
    End Sub

#End Region

#Region "FORMULARIO"

#Region "Load"

    Private Sub frm_insertar_MUTACIONES_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        pro_LimpiarCampos()
        Me.cboREADCLAS.Focus()

    End Sub

#End Region

#Region "KeyPress"

    Private Sub txt_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboREADCLAS.KeyPress, txtREADNURE.KeyPress, txtREADFERE.KeyPress, cboREADCLSE.KeyPress, cboREADVIRE.KeyPress, cboREADTIRE.KeyPress, cboREADESTA.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Or e.KeyChar = Convert.ToChar(Keys.Tab) Then
            pp_pro_SaltarCampo()
        End If
    End Sub

#End Region

#Region "KeyDown"

    Private Sub cboRECOCLAS_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboREADCLAS.KeyDown
        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
            fun_Cargar_ComboBox_Con_Datos_Activos_CLASIFICACION_Descripcion(Me.cboREADCLAS, Me.cboREADCLAS.SelectedIndex)
        End If
    End Sub
    Private Sub cboRECOCLSE_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboREADCLSE.KeyDown
        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
            fun_Cargar_ComboBox_Con_Datos_Activos_CLASSECT_Descripcion(Me.cboREADCLSE, Me.cboREADCLSE.SelectedIndex)
        End If
    End Sub
    Private Sub cboRECOVIRE_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboREADVIRE.KeyDown
        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
            fun_Cargar_ComboBox_Con_Datos_Activos_VIGENCIA_Descripcion(Me.cboREADVIRE, Me.cboREADVIRE.SelectedIndex)
        End If
    End Sub
    Private Sub cboREADTIRE_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboREADTIRE.KeyDown
        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
            fun_Cargar_ComboBox_Con_Datos_Activos_TIPORESO_Descripcion(Me.cboREADTIRE, Me.cboREADTIRE.SelectedIndex)
        End If
    End Sub
    Private Sub cboRECOESTA_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboREADESTA.KeyDown
        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
            fun_Cargar_ComboBox_Con_Datos_Activos_ESTADO(Me.cboREADESTA, Me.cboREADESTA.SelectedIndex)
        End If
    End Sub

#End Region

#Region "GotFocus"

    Private Sub txt_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtREADNURE.GotFocus, txtREADFERE.GotFocus
        pp_pro_SobrearCampo(sender)
        pp_pro_DescripcionCampo(Me.strBARRESTA.Items(0), sender)
    End Sub
    Private Sub cmd_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdGUARDAR.GotFocus, cmdSALIR.GotFocus
        pp_pro_DescripcionCampo(Me.strBARRESTA.Items(0), sender)
    End Sub
    Private Sub cbo_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboREADCLAS.GotFocus, cboREADVIRE.GotFocus, cboREADTIRE.GotFocus, cboREADESTA.GotFocus
        pp_pro_DescripcionCampo(Me.strBARRESTA.Items(0), sender)
    End Sub

#End Region

#Region "Click"

    Private Sub cboRECOCLAS_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboREADCLAS.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_CLASIFICACION_Descripcion(Me.cboREADCLAS, Me.cboREADCLAS.SelectedIndex)
    End Sub
    Private Sub cboRECOCLSE_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboREADCLSE.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_CLASSECT_Descripcion(Me.cboREADCLSE, Me.cboREADCLSE.SelectedIndex)
    End Sub
    Private Sub cboRECOVIRE_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboREADVIRE.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_VIGENCIA_Descripcion(Me.cboREADVIRE, Me.cboREADVIRE.SelectedIndex)
    End Sub
    Private Sub cboRECOVIFI_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboREADTIRE.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_TIPORESO_Descripcion(Me.cboREADTIRE, Me.cboREADTIRE.SelectedIndex)
    End Sub
    Private Sub cboRECOESTA_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboREADESTA.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_ESTADO(Me.cboREADESTA, Me.cboREADESTA.SelectedIndex)
    End Sub

#End Region

#Region "ValueChanged"

    Private Sub dtpRECOFERE_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpREADFERE.ValueChanged
        Me.txtREADFERE.Text = Me.dtpREADFERE.Value
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