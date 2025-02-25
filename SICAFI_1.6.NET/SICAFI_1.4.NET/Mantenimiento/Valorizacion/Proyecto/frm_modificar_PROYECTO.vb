Imports REGLAS_DEL_NEGOCIO

Public Class frm_modificar_PROYECTO

    '==========================
    '*** MODIFICAR PROYECTO ***
    '==========================

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

        Dim objdatos1 As New cla_DEPARTAMENTO

        Me.cboPROYDEPA.DataSource = objdatos1.fun_Consultar_CAMPOS_MANT_DEPARTAMENTO
        Me.cboPROYDEPA.DisplayMember = "DEPADESC"
        Me.cboPROYDEPA.ValueMember = "DEPACODI"

        Dim objdatos2 As New cla_CLASSECT

        Me.cboPROYCLSE.DataSource = objdatos2.fun_Consultar_CAMPOS_MANT_CLASSECT
        Me.cboPROYCLSE.DisplayMember = "CLSEDESC"
        Me.cboPROYCLSE.ValueMember = "CLSECODI"

        Dim objdatos As New cla_ESTADO

        Me.cboPROYESTA.DataSource = objdatos.fun_Consultar_TODOS_LOS_ESTADOS
        Me.cboPROYESTA.DisplayMember = "ESTADESC"
        Me.cboPROYESTA.ValueMember = "ESTACODI"

        Dim objdatos16 As New cla_PROYECTO
        Dim tbl As New DataTable

        tbl = objdatos16.fun_Buscar_ID_PROYECTO(inID_REGISTRO)

        Me.cboPROYDEPA.SelectedValue = tbl.Rows(0).Item("PROYDEPA")

        Dim objdatos7 As New cla_MUNICIPIO

        Me.cboPROYMUNI.DataSource = objdatos7.fun_Consultar_CAMPOS_MANT_MUNICIPIO
        Me.cboPROYMUNI.DisplayMember = "MUNIDESC"
        Me.cboPROYMUNI.ValueMember = "MUNICODI"

        Me.cboPROYMUNI.SelectedValue = tbl.Rows(0).Item("PROYMUNI")
        Me.cboPROYCLSE.SelectedValue = tbl.Rows(0).Item("PROYCLSE")
        Me.txtPROYCODI.Text = Trim(tbl.Rows(0).Item("PROYCODI").ToString)
        Me.txtPROYDESC.Text = Trim(tbl.Rows(0).Item("PROYDESC").ToString)
        Me.cboPROYESTA.SelectedValue = tbl.Rows(0).Item("PROYESTA").ToString

        Me.txtPROYALCA.Text = Trim(tbl.Rows(0).Item("PROYALCA").ToString)
        Me.txtPROYRECU.Text = Trim(tbl.Rows(0).Item("PROYRECU").ToString)
        Me.txtPROYJUST.Text = Trim(tbl.Rows(0).Item("PROYJUST").ToString)
        Me.txtPROYOBJE.Text = Trim(tbl.Rows(0).Item("PROYOBJE").ToString)
        Me.txtPROYFINA.Text = Trim(tbl.Rows(0).Item("PROYFINA").ToString)
        Me.txtPROYOBSE.Text = Trim(tbl.Rows(0).Item("PROYOBSE").ToString)
        Me.txtPROYCONV.Text = Trim(tbl.Rows(0).Item("PROYCONV").ToString)
        Me.txtPROYCOMP.Text = Trim(tbl.Rows(0).Item("PROYCOMP").ToString)
        Me.txtPROYNORM.Text = Trim(tbl.Rows(0).Item("PROYNORM").ToString)

        Dim boPROYDEPA As Boolean = fun_Buscar_Dato_DEPARTAMENTO(Me.cboPROYDEPA.SelectedValue)
        Dim boPROYMUNI As Boolean = fun_Buscar_Dato_MUNICIPIO(Me.cboPROYDEPA.SelectedValue, Me.cboPROYMUNI.SelectedValue)
        Dim boPROYCLSE As Boolean = fun_Buscar_Dato_CLASSECT(Me.cboPROYCLSE.SelectedValue)

        If boPROYDEPA = True OrElse _
           boPROYMUNI = True OrElse _
           boPROYCLSE = True Then

            Me.lblPROYDEPA.Text = CType(fun_Buscar_Lista_Valores_DEPARTAMENTO_Codigo(Me.cboPROYDEPA), String)
            Me.lblPROYMUNI.Text = CType(fun_Buscar_Lista_Valores_MUNICIPIO_Codigo(Me.cboPROYDEPA, Me.cboPROYMUNI), String)
            Me.lblPROYCLSE.Text = CType(fun_Buscar_Lista_Valores_CLASSECT_Codigo(Me.cboPROYCLSE), String)

        Else
            frm_INCO_modifircar_registros_sin_listas_de_valores.ShowDialog()
        End If

    End Sub

#End Region

#Region "MENU"

    Private Sub cmdGUARDAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGUARDAR.Click
        Try

            Dim objVerifica As New cla_Verificar_Dato

            Dim boPROYDEPA As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboPROYDEPA)
            Dim boPROYMUNI As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboPROYMUNI)
            Dim boPROYCLSE As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboPROYCLSE)
            Dim boPROYCODI As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Numerico(Me.txtPROYCODI)
            Dim boPROYDESC As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.txtPROYDESC)
            Dim boPROYESTA As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboPROYESTA)

            ' verifica los datos del formulario 
            If boPROYDEPA = True And _
                boPROYMUNI = True And _
                boPROYCLSE = True And _
                boPROYCODI = True And _
                boPROYDESC = True And _
                boPROYESTA = True Then

                Dim objdatos As New cla_PROYECTO

                If objdatos.fun_Actualizar_PROYECTO(inID_REGISTRO, _
                                                    Me.cboPROYDEPA.SelectedValue, _
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
                                                    Me.txtPROYNORM.Text) = True Then
                    Me.txtPROYDESC.Focus()
                    Me.Close()

                    mod_MENSAJE.Se_Modificaron_Los_Datos_Correctamente()
                Else
                    mod_MENSAJE.No_Se_Modifico_El_Registro_En_La_Base_De_Datos()
                End If
            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub cmdCANCELAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSALIR.Click
        Me.txtPROYDESC.Focus()
        Me.Close()
    End Sub

#End Region

#Region "FORMULARIO"

#Region "KeyPress"

    Private Sub txt_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboPROYDEPA.KeyPress, cboPROYMUNI.KeyPress, cboPROYCLSE.KeyPress, txtPROYCODI.KeyPress, txtPROYDESC.KeyPress, cboPROYESTA.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Or e.KeyChar = Convert.ToChar(Keys.Tab) Then
            pp_pro_SaltarCampo()
        End If
    End Sub

#End Region

#Region "KeyDown"

    Private Sub cboPROYESTA_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboPROYESTA.KeyDown
        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
            fun_Cargar_ComboBox_Con_Datos_Activos_ESTADO(Me.cboPROYESTA, Me.cboPROYESTA.SelectedIndex)
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
    Private Sub cbo_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboPROYDEPA.GotFocus, cboPROYMUNI.GotFocus, cboPROYCLSE.GotFocus, cboPROYESTA.GotFocus
        pp_pro_DescripcionCampo(Me.strBARRESTA.Items(0), sender)
    End Sub

#End Region

#Region "Click"

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