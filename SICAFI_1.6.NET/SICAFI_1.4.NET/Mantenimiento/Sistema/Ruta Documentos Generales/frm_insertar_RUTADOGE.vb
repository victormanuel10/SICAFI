Imports REGLAS_DEL_NEGOCIO

Public Class frm_insertar_RUTADOGE

    '==========================================
    '*** INSERTAR RUTA DOCUMENTOS GENERALES ***
    '==========================================

#Region "PROCEDIMIENTOS"

    Private Sub pro_LimpiarCampos()

        Me.txtRUDGRUTA.Text = ""
        Me.lblRUDGDOGE.Text = ""
        Me.lblRUDGDEPA.Text = ""
        Me.lblRUDGMUNI.Text = ""

        Me.cboRUDGDOGE.DataSource = New DataTable
        Me.cboRUDGDEPA.DataSource = New DataTable
        Me.cboRUDGMUNI.DataSource = New DataTable

    End Sub

#End Region

#Region "MENU"

    Private Sub cmdGUARDAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGUARDAR.Click

        Try
            ' instancia la clase
            Dim objdatos As New cla_RUTADOGE

            Dim boLLAVEPRIMARIA As Boolean = objdatos.fun_Verifica_llave_Primaria_MANT_RUTADOGE(Me.cboRUDGDEPA, Me.cboRUDGMUNI, Me.cboRUDGDOGE)

            ' instancia la clase
            Dim objVerifica As New cla_Verificar_Dato

            Dim boOBINDEPA As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboRUDGDEPA)
            Dim boOBINMUNI As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboRUDGMUNI)
            Dim boOBINCAFO As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboRUDGDOGE)
            Dim boOBINESTA As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboRUDGESTA)
            Dim boRUTARUTA As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.txtRUDGRUTA)

            ' verifica los datos del formulario 
            If boLLAVEPRIMARIA = True And _
               boOBINDEPA = True And _
               boOBINMUNI = True And _
               boOBINCAFO = True And _
               boOBINESTA = True And _
               boRUTARUTA = True Then

                Dim objdatos22 As New cla_RUTADOGE

                If (objdatos22.fun_Insertar_MANT_RUTADOGE(Me.cboRUDGDEPA.SelectedValue, _
                                                          Me.cboRUDGMUNI.SelectedValue, _
                                                          Me.cboRUDGDOGE.SelectedValue, _
                                                          Me.txtRUDGRUTA.Text, _
                                                          Me.cboRUDGESTA.SelectedValue)) = True Then

                    mod_MENSAJE.Se_Guardaron_Los_Datos_Correctamente()

                    If MessageBox.Show("¿ Desea agregar otro registro ?", "Mensaje...", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.No Then
                        Me.cboRUDGDEPA.Focus()
                        Me.Close()
                    Else
                        pro_LimpiarCampos()
                        Me.cboRUDGDEPA.Focus()
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
        Me.cboRUDGDEPA.Focus()
        Me.Close()
    End Sub

#End Region

#Region "FORMULARIO"

#Region "Load"

    Private Sub frm_insertar_OBSEINMO_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        pro_LimpiarCampos()
        Me.cboRUDGDEPA.Focus()
    End Sub

#End Region

#Region "KeyPress"

    Private Sub txt_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboRUDGDEPA.KeyPress, cboRUDGMUNI.KeyPress, cboRUDGDOGE.KeyPress, txtRUDGRUTA.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Or e.KeyChar = Convert.ToChar(Keys.Tab) Then
            pp_pro_SaltarCampo()
        End If
    End Sub

#End Region

#Region "KeyDown"

    Private Sub cboOBINDEPA_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboRUDGDEPA.KeyDown
        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
            fun_Cargar_ComboBox_Con_Datos_Activos_DEPARTAMENTO_Descripcion(Me.cboRUDGDEPA, Me.cboRUDGDEPA.SelectedIndex)
        End If
    End Sub
    Private Sub cboOBINMUNI_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboRUDGMUNI.KeyDown
        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
            fun_Cargar_ComboBox_Con_Datos_Activos_MUNICIPIO_X_DEPARTAMENTO_Descripcion(Me.cboRUDGMUNI, Me.cboRUDGMUNI.SelectedIndex, Me.cboRUDGDEPA)
        End If
    End Sub
    Private Sub cboRUCFCAFO_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboRUDGDOGE.KeyDown
        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
            fun_Cargar_ComboBox_Con_Datos_Activos_DOCUGENE_Descripcion(Me.cboRUDGDOGE, Me.cboRUDGDOGE.SelectedIndex, Me.cboRUDGDEPA, Me.cboRUDGMUNI)
        End If
    End Sub
    Private Sub cboOBINESTA_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboRUDGESTA.KeyDown
        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
            fun_Cargar_ComboBox_Con_Datos_Activos_ESTADO_Descripcion(Me.cboRUDGESTA, Me.cboRUDGESTA.SelectedIndex)
        End If
    End Sub

#End Region

#Region "GotFocus"

    Private Sub txt_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtRUDGRUTA.GotFocus
        pp_pro_SobrearCampo(sender)
        pp_pro_DescripcionCampo(Me.strBARRESTA.Items(0), sender)
    End Sub
    Private Sub cmd_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdGUARDAR.GotFocus, cmdSALIR.GotFocus
        pp_pro_DescripcionCampo(Me.strBARRESTA.Items(0), sender)
    End Sub
    Private Sub cbo_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboRUDGDEPA.GotFocus, cboRUDGMUNI.GotFocus, cboRUDGDOGE.GotFocus
        pp_pro_DescripcionCampo(Me.strBARRESTA.Items(0), sender)
    End Sub

#End Region

#Region "SelectedIndexChanged"

    Private Sub cboOBINDEPA_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboRUDGDEPA.SelectedIndexChanged
        Me.lblRUDGDEPA.Text = CType(fun_Buscar_Lista_Valores_DEPARTAMENTO_Codigo(Me.cboRUDGDEPA), String)

        Me.cboRUDGMUNI.DataSource = New DataTable
        Me.lblRUDGMUNI.Text = ""

        Me.cboRUDGDOGE.DataSource = New DataTable
        Me.lblRUDGDOGE.Text = ""

    End Sub
    Private Sub cboOBINMUNI_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboRUDGMUNI.SelectedIndexChanged
        Me.lblRUDGMUNI.Text = CType(fun_Buscar_Lista_Valores_MUNICIPIO_Codigo(Me.cboRUDGDEPA, Me.cboRUDGMUNI), String)

        Me.cboRUDGDOGE.DataSource = New DataTable
        Me.lblRUDGDOGE.Text = ""

    End Sub
    Private Sub cboRUDGDOGE_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboRUDGDOGE.SelectedIndexChanged
        Me.lblRUDGDOGE.Text = CType(fun_Buscar_Lista_Valores_DOCUGENE_Codigo(Me.cboRUDGDEPA, Me.cboRUDGMUNI, Me.cboRUDGDOGE), String)

    End Sub

#End Region

#Region "Click"

    Private Sub cboOBINNODE_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboRUDGDEPA.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_DEPARTAMENTO_Descripcion(Me.cboRUDGDEPA, Me.cboRUDGDEPA.SelectedIndex)
    End Sub
    Private Sub cboOBINMUNI_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboRUDGMUNI.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_MUNICIPIO_X_DEPARTAMENTO_Descripcion(Me.cboRUDGMUNI, Me.cboRUDGMUNI.SelectedIndex, Me.cboRUDGDEPA)
    End Sub
    Private Sub cboRUCFCAFO_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboRUDGDOGE.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_DOCUGENE_Descripcion(Me.cboRUDGDOGE, Me.cboRUDGDOGE.SelectedIndex, Me.cboRUDGDEPA, Me.cboRUDGMUNI)
    End Sub
    Private Sub cboOBINESTA_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboRUDGESTA.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_ESTADO_Descripcion(Me.cboRUDGESTA, Me.cboRUDGESTA.SelectedIndex)
    End Sub
    Private Sub cmdCARPETA_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCARPETA.Click

        Dim oCarpetas As New FolderBrowserDialog
        Dim stNewPath As String = ""

        oCarpetas.ShowDialog()
        stNewPath = oCarpetas.SelectedPath

        Me.txtRUDGRUTA.Text = stNewPath

        Try
            '*** VERIFICA QUE LA RUTA ESTE CORRECTA ***
            ChDir(stNewPath)

        Catch ex As Exception When stNewPath = ""
            MessageBox.Show("Se debe introducir una ruta valida", "Mensaje ...", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
        End Try

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