Imports REGLAS_DEL_NEGOCIO

Public Class frm_modificar_RUTAS

    '=======================
    '*** MODIFICAR RUTAS ***
    '=======================

#Region "VARIABLE"

    Dim inID_REGISTRO As Integer

#End Region

#Region "CONSTRUCTOR"

    Public Sub New(ByVal inInRegistro As Integer)
        inID_REGISTRO = inInRegistro

        InitializeComponent()
        pro_inicializarControles()
    End Sub

#End Region

#Region "PROCEDIMIENTOS"

    Private Sub pro_inicializarControles()

        Dim objdatos As New cla_ESTADO

        Me.cboRUTAESTA.DataSource = objdatos.fun_Consultar_TODOS_LOS_ESTADOS
        Me.cboRUTAESTA.DisplayMember = "ESTADESC"
        Me.cboRUTAESTA.ValueMember = "ESTACODI"

        Dim objdatos1 As New cla_RUTAS
        Dim tbl As New DataTable

        tbl = objdatos1.fun_Buscar_ID_MANT_RUTAS(inID_REGISTRO)

        Me.txtRUTACODI.Text = Trim(tbl.Rows(0).Item("RUTACODI"))
        Me.txtRUTADESC.Text = Trim(tbl.Rows(0).Item("RUTADESC"))
        Me.txtRUTARUTA.Text = Trim(tbl.Rows(0).Item("RUTARUTA"))
        Me.cboRUTAESTA.SelectedValue = tbl.Rows(0).Item("RUTAESTA")


    End Sub
    Private Sub pro_LimpiarCampos()

        pp_pro_LimpiarCampos(fraRUTAS)

    End Sub

#End Region

#Region "MENU"

    Private Sub cmdGUARDAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGUARDAR.Click

        Try
            Dim objVerifica As New cla_Verificar_Dato

            Dim boRUTACODI As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Numerico(Me.txtRUTACODI)
            Dim boRUTADESC As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.txtRUTADESC)
            Dim boRUTARUTA As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.txtRUTARUTA)
            Dim boRUTAESTA As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboRUTAESTA)

            ' verifica los datos del formulario 
            If boRUTACODI = True And boRUTADESC = True And boRUTARUTA = True And boRUTAESTA = True Then

                Dim objdatos22 As New cla_RUTAS

                If (objdatos22.fun_Actualizar_MANT_RUTAS(inID_REGISTRO, Me.txtRUTACODI.Text, Me.txtRUTADESC.Text, Me.txtRUTARUTA.Text, Me.cboRUTAESTA.SelectedValue)) Then
                    mod_MENSAJE.Se_Guardaron_Los_Datos_Correctamente()
                    Me.txtRUTACODI.Focus()
                    Me.Close()
                Else
                    mod_MENSAJE.No_Se_Guardo_El_Registro_En_La_Base_De_Datos()
                End If
            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description & "Guardar")
        End Try

    End Sub
    Private Sub cmdCANCELAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSALIR.Click
        Me.txtRUTACODI.Focus()
        Me.Close()
    End Sub
    Private Sub cmdCARPETA_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCARPETA.Click

        Dim oCarpetas As New FolderBrowserDialog
        Dim stNewPath As String = ""

        oCarpetas.ShowDialog()
        stNewPath = oCarpetas.SelectedPath

        Me.txtRUTARUTA.Text = stNewPath

        If Trim(stNewPath) = "" Then
            MessageBox.Show("Se debe introducir una ruta valida", "Mensaje ...", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1)
        End If

    End Sub

#End Region

#Region "FORMULARIO"

#Region "KeyPress"

    Private Sub txt_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtRUTACODI.KeyPress, txtRUTADESC.KeyPress, cboRUTAESTA.KeyPress, txtRUTARUTA.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Or e.KeyChar = Convert.ToChar(Keys.Tab) Then
            pp_pro_SaltarCampo()
        End If
    End Sub

#End Region

#Region "KeyDown"

    Private Sub cboRUTAESTA_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboRUTAESTA.KeyDown
        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
            fun_Cargar_ComboBox_Con_Datos_Activos_ESTADO(Me.cboRUTAESTA, Me.cboRUTAESTA.SelectedIndex)
        End If
    End Sub

#End Region

#Region "GotFocus"

    Private Sub txt_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtRUTACODI.GotFocus, txtRUTADESC.GotFocus, txtRUTARUTA.GotFocus
        pp_pro_SobrearCampo(sender)
        pp_pro_DescripcionCampo(Me.strBARRESTA.Items(0), sender)
    End Sub
    Private Sub cmd_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdGUARDAR.GotFocus, cmdSALIR.GotFocus, cmdCARPETA.GotFocus
        pp_pro_DescripcionCampo(Me.strBARRESTA.Items(0), sender)
    End Sub
    Private Sub cbo_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboRUTAESTA.GotFocus
        pp_pro_DescripcionCampo(Me.strBARRESTA.Items(0), sender)
    End Sub


#End Region

#Region "Click"

    Private Sub cboMOLIESTA_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboRUTAESTA.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_ESTADO(cboRUTAESTA, cboRUTAESTA.SelectedIndex)
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