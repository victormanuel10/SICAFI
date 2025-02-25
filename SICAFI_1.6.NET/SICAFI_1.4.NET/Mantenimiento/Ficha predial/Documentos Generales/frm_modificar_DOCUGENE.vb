Imports REGLAS_DEL_NEGOCIO

Public Class frm_modificar_DOCUGENE

    '======================================
    '*** MODIFICAR DOCUMENTOS GENERALES ***
    '======================================

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

#End Region

#Region "PROCEDIMIENTOS"

    Private Sub pro_inicializarControles()

        Try
            Dim objdatos1 As New cla_DEPARTAMENTO

            Me.cboDOGEDEPA.DataSource = objdatos1.fun_Consultar_CAMPOS_MANT_DEPARTAMENTO
            Me.cboDOGEDEPA.DisplayMember = "DEPADESC"
            Me.cboDOGEDEPA.ValueMember = "DEPACODI"

            Dim objdatos As New cla_ESTADO

            Me.cboDOGEESTA.DataSource = objdatos.fun_Consultar_ESTADO_X_ESTADO
            Me.cboDOGEESTA.DisplayMember = "ESTADESC"
            Me.cboDOGEESTA.ValueMember = "ESTACODI"

            Dim objdatos3 As New cla_DOCUGENE
            Dim tbl As New DataTable

            tbl = objdatos3.fun_Buscar_ID_MANT_DOCUGENE(inID_REGISTRO)

            Me.cboDOGEDEPA.SelectedValue = tbl.Rows(0).Item("DOGEDEPA")

            Dim objdatos7 As New cla_MUNICIPIO

            Me.cboDOGEMUNI.DataSource = objdatos7.fun_Consultar_CAMPOS_MANT_MUNICIPIO
            Me.cboDOGEMUNI.DisplayMember = "MUNIDESC"
            Me.cboDOGEMUNI.ValueMember = "MUNICODI"

            Me.cboDOGEMUNI.SelectedValue = tbl.Rows(0).Item("DOGEMUNI")
            Me.txtDOGECODI.Text = Trim(tbl.Rows(0).Item("DOGECODI"))
            Me.txtDOGEDESC.Text = Trim(tbl.Rows(0).Item("DOGEDESC"))
            Me.cboDOGEESTA.SelectedValue = tbl.Rows(0).Item("DOGEESTA")

            Dim boDOGEDEPA As Boolean = fun_Buscar_Dato_DEPARTAMENTO(Me.cboDOGEDEPA.SelectedValue)
            Dim boDOGEMUNI As Boolean = fun_Buscar_Dato_MUNICIPIO(Me.cboDOGEDEPA.SelectedValue, Me.cboDOGEMUNI.SelectedValue)

            If boDOGEDEPA = True OrElse boDOGEMUNI = True Then

                Me.lblDOGEDEPA.Text = CType(fun_Buscar_Lista_Valores_DEPARTAMENTO_Codigo(Me.cboDOGEDEPA), String)
                Me.lblDOGEMUNI.Text = CType(fun_Buscar_Lista_Valores_MUNICIPIO_Codigo(Me.cboDOGEDEPA, Me.cboDOGEMUNI), String)

            Else
                frm_INCO_modifircar_registros_sin_listas_de_valores.ShowDialog()
            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub pro_LimpiarCampos()

        pp_pro_LimpiarCampos(fraDOCUGENE)

    End Sub

#End Region

#Region "MENU"

    Private Sub cmdGUARDAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGUARDAR.Click

        Try

            ' instancia la clase
            Dim objVerifica As New cla_Verificar_Dato

            Dim boDOGEDEPA As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboDOGEDEPA)
            Dim boDOGEMUNI As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboDOGEMUNI)
            Dim boDOGECODI As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Numerico(Me.txtDOGECODI)
            Dim boDOGEDESC As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.txtDOGEDESC)
            Dim boDOGEESTA As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboDOGEESTA)

            ' verifica los datos del formulario 
            If boDOGEDEPA = True And _
               boDOGEMUNI = True And _
               boDOGECODI = True And _
               boDOGEDESC = True And _
               boDOGEESTA = True Then

                Dim objdatos22 As New cla_DOCUGENE

                If (objdatos22.fun_Actualizar_MANT_DOCUGENE(inID_REGISTRO, _
                                                            Me.cboDOGEDEPA.SelectedValue, _
                                                            Me.cboDOGEMUNI.SelectedValue, _
                                                            Me.txtDOGECODI.Text, _
                                                            Me.txtDOGEDESC.Text, _
                                                            Me.cboDOGEESTA.SelectedValue)) Then

                    mod_MENSAJE.Se_Guardaron_Los_Datos_Correctamente()

                    Me.cboDOGEDEPA.Focus()
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
        Me.cboDOGEDEPA.Focus()
        Me.Close()
    End Sub

#End Region

#Region "FORMULARIO"

#Region "KeyDown"

    Private Sub cboDOGEDEPA_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboDOGEDEPA.KeyDown
        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
            fun_Cargar_ComboBox_Con_Datos_Activos_DEPARTAMENTO_Descripcion(Me.cboDOGEDEPA, Me.cboDOGEDEPA.SelectedIndex)
        End If
    End Sub
    Private Sub cboDOGEMUNI_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboDOGEMUNI.KeyDown
        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
            fun_Cargar_ComboBox_Con_Datos_Activos_MUNICIPIO_X_DEPARTAMENTO_Descripcion(Me.cboDOGEMUNI, Me.cboDOGEMUNI.SelectedIndex, Me.cboDOGEDEPA)
        End If
    End Sub
    Private Sub cboDOGEESTA_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboDOGEESTA.KeyDown
        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
            fun_Cargar_ComboBox_Con_Datos_Activos_ESTADO(Me.cboDOGEESTA, Me.cboDOGEESTA.SelectedIndex)
        End If
    End Sub

#End Region

#Region "KeyPress"

    Private Sub txt_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboDOGEDEPA.KeyPress, cboDOGEMUNI.KeyPress, txtDOGECODI.KeyPress, txtDOGEDESC.KeyPress, cboDOGEESTA.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Or e.KeyChar = Convert.ToChar(Keys.Tab) Then
            pp_pro_SaltarCampo()
        End If
    End Sub

#End Region

#Region "GotFocus"

    Private Sub txt_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtDOGECODI.GotFocus, txtDOGEDESC.GotFocus
        pp_pro_SobrearCampo(sender)
        pp_pro_DescripcionCampo(Me.strBARRESTA.Items(0), sender)
    End Sub
    Private Sub cmd_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdGUARDAR.GotFocus, cmdSALIR.GotFocus
        pp_pro_DescripcionCampo(Me.strBARRESTA.Items(0), sender)
    End Sub
    Private Sub cbo_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboDOGEDEPA.GotFocus, cboDOGEMUNI.GotFocus, cboDOGEESTA.GotFocus
        pp_pro_DescripcionCampo(Me.strBARRESTA.Items(0), sender)
    End Sub
    Private Sub rbd_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs)
        pp_pro_DescripcionCampo(Me.strBARRESTA.Items(0), sender)
    End Sub

#End Region

#Region "Click"

    Private Sub cboDOGEDEPA_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboDOGEDEPA.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_DEPARTAMENTO_Descripcion(Me.cboDOGEDEPA, Me.cboDOGEDEPA.SelectedIndex)
    End Sub
    Private Sub cboDOGEMUNI_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboDOGEMUNI.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_MUNICIPIO_X_DEPARTAMENTO_Descripcion(Me.cboDOGEMUNI, Me.cboDOGEMUNI.SelectedIndex, Me.cboDOGEDEPA)
    End Sub
    Private Sub cboDOGEESTA_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboDOGEESTA.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_ESTADO(Me.cboDOGEESTA, Me.cboDOGEESTA.SelectedIndex)
    End Sub

#End Region

#Region "SelectedIndexChanged"

    Private Sub cboDOGEDEPA_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboDOGEDEPA.SelectedIndexChanged
        Me.lblDOGEDEPA.Text = CType(fun_Buscar_Lista_Valores_DEPARTAMENTO_Codigo(Me.cboDOGEDEPA), String)

        Me.cboDOGEMUNI.DataSource = New DataTable
        Me.lblDOGEMUNI.Text = ""

    End Sub
    Private Sub cboDOGEMUNI_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboDOGEMUNI.SelectedIndexChanged
        Me.lblDOGEMUNI.Text = CType(fun_Buscar_Lista_Valores_MUNICIPIO_Codigo(Me.cboDOGEDEPA, Me.cboDOGEMUNI), String)
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