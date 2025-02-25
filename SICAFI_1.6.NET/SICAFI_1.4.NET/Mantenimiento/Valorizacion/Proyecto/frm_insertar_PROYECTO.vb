Imports REGLAS_DEL_NEGOCIO

Public Class frm_insertar_PROYECTO

    '=========================
    '*** INSERTAR PROYECTO ***
    '=========================

#Region "PROCEDIMIENTOS"

    Private Sub pro_LimpiarCampos()

        pp_pro_LimpiarCampos(fraPROYECTO)

        Me.txtPROYALCA.Text = ""
        Me.txtPROYRECU.Text = ""
        Me.txtPROYJUST.Text = ""
        Me.txtPROYOBJE.Text = ""
        Me.txtPROYFINA.Text = ""
        Me.txtPROYOBSE.Text = ""
        Me.txtPROYCONV.Text = ""
        Me.txtPROYCOMP.Text = ""
        Me.txtPROYNORM.Text = ""

    End Sub

#End Region

#Region "MENU"

    Private Sub cmdGUARDAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGUARDAR.Click

        Try
            ' instancia la clase
            Dim objdatos As New cla_PROYECTO

            Dim boLLAVEPRIMARIA As Boolean = objdatos.fun_Verifica_llave_Primaria_PROYECTO(Me.cboPROYDEPA, _
                                                                                           Me.cboPROYMUNI, _
                                                                                           Me.cboPROYCLSE, _
                                                                                           Me.txtPROYCODI)

            Dim objVerifica As New cla_Verificar_Dato

            Dim boPROYDEPA As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboPROYDEPA)
            Dim boPROYMUNI As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboPROYMUNI)
            Dim boPROYCLSE As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboPROYCLSE)
            Dim boPROYCODI As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Numerico(Me.txtPROYCODI)
            Dim boPROYDESC As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.txtPROYDESC)
            Dim boPROYESTA As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboPROYESTA)

            ' verifica los datos del formulario 
            If boLLAVEPRIMARIA = True And _
                boPROYDEPA = True And _
                boPROYMUNI = True And _
                boPROYCLSE = True And _
                boPROYCODI = True And _
                boPROYDESC = True And _
                boPROYESTA = True Then

                Dim objdatos22 As New cla_PROYECTO

                If (objdatos22.fun_Insertar_PROYECTO(Me.cboPROYDEPA.SelectedValue, _
                                                     Me.cboPROYMUNI.SelectedValue, _
                                                     Me.cboPROYCLSE.SelectedValue, _
                                                     Me.txtPROYCODI.Text, _
                                                     Me.txtPROYDESC.Text, _
                                                     Me.cboPROYESTA.SelectedValue, _
                                                     Me.txtPROYALCA.Text, _
                                                     Me.txtPROYRECU.Text, _
                                                     Me.txtPROYJUST.Text, _
                                                     Me.txtPROYOBJE.Text, _
                                                     Me.txtPROYFINA.Text, _
                                                     Me.txtPROYOBSE.Text, _
                                                     Me.txtPROYCONV.Text, _
                                                     Me.txtPROYCOMP.Text, _
                                                     Me.txtPROYNORM.Text)) = True Then

                    ' instancia la clase
                    Dim objRutas As New cla_RUTAS
                    Dim tblRutas As New DataTable

                    tblRutas = objRutas.fun_Buscar_CODIGO_MANT_RUTAS(9)

                    If tblRutas.Rows.Count > 0 Then

                        Dim stRuta As String = Me.cboPROYDEPA.SelectedValue & "-" & Me.cboPROYMUNI.SelectedValue & "-" & Me.cboPROYCLSE.SelectedValue & "-" & Me.txtPROYCODI.Text

                        If System.IO.Directory.Exists(Trim(tblRutas.Rows(0).Item("RUTARUTA")) & "\" & stRuta) = False Then

                            System.IO.Directory.CreateDirectory(Trim(tblRutas.Rows(0).Item("RUTARUTA")) & "\" & stRuta)

                        End If

                    End If

                    mod_MENSAJE.Se_Guardaron_Los_Datos_Correctamente()

                    If MessageBox.Show("¿ Desea agregar otro registro ?", "Mensaje...", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.No Then
                        Me.txtPROYCODI.Focus()
                        Me.Close()
                    Else
                        pro_LimpiarCampos()
                        Me.txtPROYCODI.Focus()
                    End If

                Else
                    mod_MENSAJE.No_Se_Guardo_El_Registro_En_La_Base_De_Datos()
                End If
            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description & "Guardar")
        End Try

    End Sub
    Private Sub cmdCANCELAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSALIR.Click
        Me.txtPROYCODI.Focus()
        Me.Close()
    End Sub

#End Region

#Region "FORMULARIO"

#Region "Load"

    Private Sub frm_insertar_CONCEPTO_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        pro_LimpiarCampos()
    End Sub

#End Region

#Region "KeyDown"

    Private Sub cboFOMUDEPA_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboPROYDEPA.KeyDown
        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
            fun_Cargar_ComboBox_Con_Datos_Activos_DEPARTAMENTO_Descripcion(Me.cboPROYDEPA, Me.cboPROYDEPA.SelectedIndex)
        End If
    End Sub
    Private Sub cboFOMUMUNI_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboPROYMUNI.KeyDown
        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
            fun_Cargar_ComboBox_Con_Datos_Activos_MUNICIPIO_X_DEPARTAMENTO_Descripcion(Me.cboPROYMUNI, Me.cboPROYMUNI.SelectedIndex, Me.cboPROYDEPA)
        End If
    End Sub
    Private Sub cboFOMUCLSE_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboPROYCLSE.KeyDown
        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
            fun_Cargar_ComboBox_Con_Datos_Activos_CLASSECT_Descripcion(Me.cboPROYCLSE, Me.cboPROYCLSE.SelectedIndex)
        End If
    End Sub
    Private Sub cboPROYESTA_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboPROYESTA.KeyDown
        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
            fun_Cargar_ComboBox_Con_Datos_Activos_ESTADO(Me.cboPROYESTA, Me.cboPROYESTA.SelectedIndex)
        End If
    End Sub

#End Region

#Region "KeyPress"

    Private Sub txt_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtPROYCODI.KeyPress, txtPROYDESC.KeyPress, cboPROYESTA.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Or e.KeyChar = Convert.ToChar(Keys.Tab) Then
            pp_pro_SaltarCampo()
        End If
    End Sub

#End Region

#Region "GotFocus"

    Private Sub txt_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtPROYCODI.GotFocus, txtPROYDESC.GotFocus
        pp_pro_SobrearCampo(sender)
        pp_pro_DescripcionCampo(Me.strBARRESTA.Items(0), sender)
    End Sub
    Private Sub cmd_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdGUARDAR.GotFocus, cmdSALIR.GotFocus
        pp_pro_DescripcionCampo(Me.strBARRESTA.Items(0), sender)
    End Sub
    Private Sub cbo_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboPROYESTA.GotFocus, cboPROYDEPA.GotFocus, cboPROYMUNI.GotFocus, cboPROYCLSE.GotFocus
        pp_pro_DescripcionCampo(Me.strBARRESTA.Items(0), sender)
    End Sub


#End Region

#Region "SelectedIndexChanged"

    Private Sub cboFOMUDEPA_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboPROYDEPA.SelectedIndexChanged
        Me.lblPROYDEPA.Text = CType(fun_Buscar_Lista_Valores_DEPARTAMENTO_Codigo(Me.cboPROYDEPA), String)

        Me.cboPROYMUNI.DataSource = New DataTable
        Me.lblPROYMUNI.Text = ""
    End Sub
    Private Sub cboFOMUMUNI_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboPROYMUNI.SelectedIndexChanged
        Me.lblPROYMUNI.Text = CType(fun_Buscar_Lista_Valores_MUNICIPIO_Codigo(Me.cboPROYDEPA, Me.cboPROYMUNI), String)
    End Sub
    Private Sub cboFOMUCLSE_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboPROYCLSE.SelectedIndexChanged
        Me.lblPROYCLSE.Text = CType(fun_Buscar_Lista_Valores_CLASSECT_Codigo(Me.cboPROYCLSE), String)
    End Sub

#End Region

#Region "Click"

    Private Sub cboFOMUDEPA_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboPROYDEPA.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_DEPARTAMENTO_Descripcion(Me.cboPROYDEPA, Me.cboPROYDEPA.SelectedIndex)
    End Sub
    Private Sub cboFOMUMUNI_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboPROYMUNI.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_MUNICIPIO_X_DEPARTAMENTO_Descripcion(Me.cboPROYMUNI, Me.cboPROYMUNI.SelectedIndex, Me.cboPROYDEPA)
    End Sub
    Private Sub cboFOMUCLSE_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboPROYCLSE.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_CLASSECT_Descripcion(Me.cboPROYCLSE, Me.cboPROYCLSE.SelectedIndex)
    End Sub
    Private Sub cboMOLIESTA_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboPROYESTA.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_ESTADO(cboPROYESTA, cboPROYESTA.SelectedIndex)
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