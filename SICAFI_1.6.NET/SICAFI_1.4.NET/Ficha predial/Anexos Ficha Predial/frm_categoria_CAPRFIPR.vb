Imports REGLAS_DEL_NEGOCIO

Public Class frm_categoria_CAPRFIPR

    '=========================================
    '*** CATEGORIA DE PREDIO FICHA PREDIAL ***
    '=========================================

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
            Dim objdatos1 As New cla_CAPRFIPR
            Dim tbl1 As New DataTable

            tbl1 = objdatos1.fun_Buscar_CATEGORIA_X_NRO_DE_FICHA(vl_inFIPRNUFI)

            If tbl1.Rows.Count > 0 Then

                Dim objdatos As New cla_ESTADO

                Me.cboCPFPESTA.DataSource = objdatos.fun_Consultar_TODOS_LOS_ESTADOS
                Me.cboCPFPESTA.DisplayMember = "ESTADESC"
                Me.cboCPFPESTA.ValueMember = "ESTACODI"

                Dim objdatos11 As New cla_CATEPRED

                Me.cboCPFPCAPR.DataSource = objdatos11.fun_Consultar_CAMPOS_MANT_CATEPRED
                Me.cboCPFPCAPR.DisplayMember = "CAPRCODI"
                Me.cboCPFPCAPR.ValueMember = "CAPRCODI"

                Me.cboCPFPCAPR.SelectedValue = tbl1.Rows(0).Item("CPFPCAPR")
                Me.cboCPFPESTA.SelectedValue = tbl1.Rows(0).Item("CPFPESTA")

                vl_inFIPRNUFI = tbl1.Rows(0).Item("CPFPNUFI")
                vl_inFIPRESTR = tbl1.Rows(0).Item("CPFPCAPR")

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
            If Me.cboCPFPCAPR.Text <> "" Then

                Me.lblCPFPCAPR.Text = CStr(fun_Buscar_Lista_Valores_CATEPRED(Trim(Me.cboCPFPCAPR.Text)))
            Else
                Me.lblCPFPCAPR.Text = ""

            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub pro_LimpiarCampos()

        Me.cboCPFPCAPR.DataSource = New DataTable
        Me.cboCPFPESTA.DataSource = New DataTable

        Me.lblCPFPCAPR.Text = ""

    End Sub

#End Region

#Region "MENU"

    Private Sub cmdGUARDAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGUARDAR.Click

        Try

            Dim objVerifica As New cla_Verificar_Dato

            Dim boCPFPCAPR As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboCPFPCAPR)
            Dim boCPFPESTA As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboCPFPESTA)

            ' verifica los datos del formulario 
            If boCPFPCAPR = True And _
               boCPFPESTA = True Then


                ' guarda el registro
                If vl_boGUARDAR = True Then

                    Dim objdatos22 As New cla_CAPRFIPR

                    If (objdatos22.fun_Insertar_CAPRFIPR(vl_inFIPRNUFI, _
                                                         Me.cboCPFPCAPR.SelectedValue, _
                                                         Me.cboCPFPESTA.SelectedValue)) = True Then

                        mod_MENSAJE.Se_Guardaron_Los_Datos_Correctamente()
                        Me.Close()
                    Else

                        mod_MENSAJE.No_Se_Guardo_El_Registro_En_La_Base_De_Datos()

                    End If

                    ' modifica el registro
                ElseIf vl_boMODIFICAR = True Then

                    Dim objdatos23 As New cla_CAPRFIPR

                    If objdatos23.fun_Eliminar_CAPRFIPR_X_NRO_FICHA_Y_CATEGORIA(vl_inFIPRNUFI, vl_inFIPRESTR) = True Then

                        If (objdatos23.fun_Insertar_CAPRFIPR(vl_inFIPRNUFI, _
                                                             Me.cboCPFPCAPR.SelectedValue, _
                                                             Me.cboCPFPESTA.SelectedValue)) = True Then

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
        Me.cboCPFPCAPR.Focus()
        Me.Close()
    End Sub

#End Region

#Region "FORMULARIO"

#Region "Load"

    Private Sub frm_insertar_TARIALPU_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.cboCPFPCAPR.Focus()
    End Sub

#End Region

#Region "GotFocus"

    Private Sub frm_CATEGORIA_CAPRFIPR_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.GotFocus
        pro_ListaDeValores()
    End Sub

#End Region

#Region "KeyPress"

    Private Sub txt_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboCPFPCAPR.KeyPress, cboCPFPESTA.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Or e.KeyChar = Convert.ToChar(Keys.Tab) Then
            pp_pro_SaltarCampo()
        End If
    End Sub

#End Region

#Region "KeyDown"

    Private Sub cboCPFPCAPR_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboCPFPCAPR.KeyDown
        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
            fun_Cargar_ComboBox_Con_Datos_Activos_CATEPRED(Me.cboCPFPCAPR, Me.cboCPFPCAPR.SelectedIndex)
        End If
    End Sub
    Private Sub cboCPFPESTA_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboCPFPESTA.KeyDown
        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
            fun_Cargar_ComboBox_Con_Datos_Activos_ESTADO(Me.cboCPFPESTA, Me.cboCPFPESTA.SelectedIndex)
        End If
    End Sub

#End Region

#Region "GotFocus"

    Private Sub cmd_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdGUARDAR.GotFocus, cmdSALIR.GotFocus
        pp_pro_DescripcionCampo(Me.strBARRESTA.Items(0), sender)
    End Sub
    Private Sub cbo_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboCPFPCAPR.GotFocus, cboCPFPESTA.GotFocus
        pp_pro_DescripcionCampo(Me.strBARRESTA.Items(0), sender)
    End Sub

#End Region

#Region "SelectedIndexChanged"

    Private Sub cboCPFPCAPR_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCPFPCAPR.SelectedIndexChanged
        Me.lblCPFPCAPR.Text = CType(fun_Buscar_Lista_Valores_CATEPRED(Me.cboCPFPCAPR.Text), String)
    End Sub

#End Region

#Region "Click"

    Private Sub cboCPFPCAPR_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboCPFPCAPR.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_CATEPRED(Me.cboCPFPCAPR, Me.cboCPFPCAPR.SelectedIndex)
    End Sub
    Private Sub cboPRANESTA_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboCPFPESTA.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_ESTADO(Me.cboCPFPESTA, Me.cboCPFPESTA.SelectedIndex)
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