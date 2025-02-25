Imports REGLAS_DEL_NEGOCIO
Imports System
Imports System.IO

Public Class frm_insertar_RECLACAD

    '===========================================
    '*** INSERTAR ACTOS ADMINISTRAD RECLAMOS ***
    '===========================================

#Region "VARIABLE"

    Dim inID_REGISTRO As Integer
    Dim inACADSECU As Integer

    Dim boINSERTAR As Boolean = False
    Dim boMODIFICAR As Boolean = False

#End Region

#Region "CONSTRUCTOR"

    Public Sub New(ByVal inIDRE As Integer)
        inID_REGISTRO = inIDRE
        inACADSECU = inIDRE

        boMODIFICAR = True

        InitializeComponent()
        pro_LimpiarCampos()
        pro_inicializarControles()
    End Sub
    Public Sub New(ByVal inIDRE As Integer, ByVal inSECU As Integer)
        inID_REGISTRO = inIDRE
        inACADSECU = inSECU

        boINSERTAR = True

        InitializeComponent()
        pro_LimpiarCampos()
        pro_inicializarControles()
    End Sub

#End Region

#Region "PROCEDIMIENTOS"

    Private Sub pro_LimpiarCampos()

        Me.cboREAAACAD.DataSource = New DataTable
        Me.cboREAATITR.DataSource = New DataTable

        Me.txtREAANUEM.Text = "0"
        Me.txtREAAFEEM.Text = ""
        Me.txtREAANURA.Text = "0"
        Me.txtREAAFERA.Text = ""
        Me.txtREAANURR.Text = "0"
        Me.txtREAAFERR.Text = ""
        Me.txtREAAOBSE.Text = ""

    End Sub
    Private Sub pro_inicializarControles()

        Try

            ' instancia la clase
            Dim objdatos As New cla_RECLACAD
            Dim tbl As New DataTable

            tbl = objdatos.fun_Consultar_RECLACAD(inACADSECU)

            If tbl.Rows.Count > 0 Then
                boMODIFICAR = True

                Me.Text = "Modificar registro"
                Me.fraINFOUSUA.Text = "MODIFICAR ACTO ADMINISTRATIVO"

                Dim objdatos2 As New cla_TIPOTRAM

                Me.cboREAATITR.DataSource = objdatos2.fun_Consultar_CAMPOS_MANT_TIPOTRAM
                Me.cboREAATITR.DisplayMember = "TITRDESC"
                Me.cboREAATITR.ValueMember = "TITRCODI"

                Me.cboREAATITR.SelectedValue = tbl.Rows(0).Item("REAATITR")

                Dim objdatos1 As New cla_ACTOADMI

                Me.cboREAAACAD.DataSource = objdatos1.fun_Consultar_CAMPOS_MANT_ACTOADMI
                Me.cboREAAACAD.DisplayMember = "ACADDESC"
                Me.cboREAAACAD.ValueMember = "ACADCODI"

                Me.cboREAAACAD.SelectedValue = tbl.Rows(0).Item("REAAACAD")

                Me.txtREAANUEM.Text = CStr(Trim(tbl.Rows(0).Item("REAANUEM")))
                Me.txtREAAFEEM.Text = CStr(Trim(tbl.Rows(0).Item("REAAFEEM")))
                Me.txtREAANURA.Text = CStr(Trim(tbl.Rows(0).Item("REAANURA")))
                Me.txtREAAFERA.Text = CStr(Trim(tbl.Rows(0).Item("REAAFERA")))
                Me.txtREAANURR.Text = CStr(Trim(tbl.Rows(0).Item("REAANURR")))
                Me.txtREAAFERR.Text = CStr(Trim(tbl.Rows(0).Item("REAAFERR")))
                Me.txtREAAOBSE.Text = CStr(Trim(tbl.Rows(0).Item("REAAOBSE")))

                If fun_Verificar_Dato_Fecha_Evento_Validated(Me.txtREAAFEEM.Text) = True Then
                    Me.dtpREAAFEEM.Value = CDate(tbl.Rows(0).Item("REAAFEEM"))
                End If

                If fun_Verificar_Dato_Fecha_Evento_Validated(Me.txtREAAFERA.Text) = True Then
                    Me.dtpREAAFERA.Value = CDate(tbl.Rows(0).Item("REAAFERA"))
                End If

                If fun_Verificar_Dato_Fecha_Evento_Validated(Me.txtREAAFERR.Text) = True Then
                    Me.dtpREAAFERR.Value = CDate(tbl.Rows(0).Item("REAAFERR"))
                End If

            Else
                boINSERTAR = True

                Me.Text = "Insertar registro"
                Me.fraINFOUSUA.Text = "INSERTAR INFORMACIÓN DEL USUARIO"

            End If

            If vp_usuario = "ADMINISTRADOR" Then
                Me.txtREAANUEM.ReadOnly = False
                Me.txtREAAFEEM.ReadOnly = False
                Me.dtpREAAFEEM.Enabled = True
            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub

#End Region

#Region "MENU"

    Private Sub cmdGUARDAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGUARDAR.Click

        Try
            ' inserta el registro
            If boINSERTAR = True Then

                ' instancia la clase
                Dim objVerifica As New cla_Verificar_Dato

                Dim boREAAACAD As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboREAAACAD)
                Dim boREAATITR As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboREAATITR)
                Dim boREAANUEM As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.txtREAANUEM)
                Dim boREAANURA As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Numerico(Me.txtREAANURA)
                Dim boREAANURR As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Numerico(Me.txtREAANURR)

                ' verifica los datos del formulario 
                If boREAAACAD = True And _
                   boREAATITR = True And _
                   boREAANURA = True And _
                   boREAANURR = True And _
                   boREAANUEM = True Then

                    Dim objdatos22 As New cla_RECLACAD

                    If (objdatos22.fun_Insertar_RECLACAD(inACADSECU, _
                                                         Me.cboREAAACAD.SelectedValue, _
                                                         Me.cboREAATITR.SelectedValue, _
                                                         Me.txtREAANUEM.Text, _
                                                         Me.txtREAAFEEM.Text, _
                                                         Me.txtREAANURA.Text, _
                                                         Me.txtREAAFERA.Text, _
                                                         Me.txtREAANURR.Text, _
                                                         Me.txtREAAFERR.Text, _
                                                         Me.txtREAAOBSE.Text)) = True Then

                        ' instancia la clase
                        Dim objRutas As New cla_RUTAS
                        Dim tblRutas As New DataTable

                        tblRutas = objRutas.fun_Buscar_CODIGO_MANT_RUTAS(4)

                        If tblRutas.Rows.Count > 0 Then

                            If tblRutas.Rows.Count > 0 AndAlso Trim(Me.txtREAANUEM.Text) <> "" AndAlso Trim(Me.txtREAAFEEM.Text).ToString.Length = 10 Then

                                Dim stRuta As String = fun_Formato_Mascara_3_String(Trim(Me.txtREAANUEM.Text)) & "-" & fun_Formato_Mascara_4_String(Trim(Me.txtREAAFEEM.Text.ToString.Substring(6, 4)))

                                If System.IO.Directory.Exists(Trim(tblRutas.Rows(0).Item("RUTARUTA")) & "\" & stRuta) = False Then

                                    System.IO.Directory.CreateDirectory(Trim(tblRutas.Rows(0).Item("RUTARUTA")) & "\" & stRuta)

                                End If

                            End If

                        End If

                        Dim objRutas1 As New cla_RUTAS
                        Dim tblRutas1 As New DataTable

                        tblRutas1 = objRutas1.fun_Buscar_CODIGO_MANT_RUTAS(5)

                        If tblRutas1.Rows.Count > 0 Then

                            If tblRutas1.Rows.Count > 0 AndAlso Trim(Me.txtREAANURA.Text) <> "" AndAlso Trim(Me.txtREAAFERA.Text).ToString.Length = 10 Then

                                Dim stRuta As String = Trim(Me.txtREAANURA.Text) & "-" & fun_Formato_Mascara_4_String(Trim(Me.txtREAAFERA.Text.ToString.Substring(6, 4)))

                                If System.IO.Directory.Exists(Trim(tblRutas1.Rows(0).Item("RUTARUTA")) & "\" & stRuta) = False Then

                                    System.IO.Directory.CreateDirectory(Trim(tblRutas1.Rows(0).Item("RUTARUTA")) & "\" & stRuta)

                                End If

                            End If

                        End If

                        mod_MENSAJE.Se_Guardaron_Los_Datos_Correctamente()
                        Me.cboREAAACAD.Focus()
                        Me.Close()
                    Else
                        mod_MENSAJE.No_Se_Guardo_El_Registro_En_La_Base_De_Datos()
                    End If

                End If

                ' modifica el registro
            ElseIf boMODIFICAR = True Then

                ' instancia la clase
                Dim objVerifica As New cla_Verificar_Dato


                Dim boREAAACAD As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboREAAACAD)
                Dim boREAATITR As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboREAATITR)
                Dim boREAANUEM As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.txtREAANUEM)
                Dim boREAANURA As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Numerico(Me.txtREAANURA)
                Dim boREAANURR As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Numerico(Me.txtREAANURR)

                ' verifica los datos del formulario 
                If boREAAACAD = True And _
                   boREAATITR = True And _
                   boREAANURA = True And _
                   boREAANURR = True And _
                   boREAANUEM = True Then

                    Dim objdatos22 As New cla_RECLACAD

                    If (objdatos22.fun_Actualizar_SECU_X_RECLACAD(inACADSECU, _
                                                                  Me.cboREAAACAD.SelectedValue, _
                                                                  Me.cboREAATITR.SelectedValue, _
                                                                  Me.txtREAANUEM.Text, _
                                                                  Me.txtREAAFEEM.Text, _
                                                                  Me.txtREAANURA.Text, _
                                                                  Me.txtREAAFERA.Text, _
                                                                  Me.txtREAANURR.Text, _
                                                                  Me.txtREAAFERR.Text, _
                                                                  Me.txtREAAOBSE.Text)) = True Then

                        ' instancia la clase
                        Dim objRutas As New cla_RUTAS
                        Dim tblRutas As New DataTable

                        tblRutas = objRutas.fun_Buscar_CODIGO_MANT_RUTAS(4)

                        If tblRutas.Rows.Count > 0 Then

                            If tblRutas.Rows.Count > 0 AndAlso Trim(Me.txtREAANUEM.Text) <> "" AndAlso Trim(Me.txtREAAFEEM.Text).ToString.Length = 10 Then

                                Dim stRuta As String = fun_Formato_Mascara_3_String(Trim(Me.txtREAANUEM.Text)) & "-" & fun_Formato_Mascara_4_String(Trim(Me.txtREAAFEEM.Text.ToString.Substring(6, 4)))

                                If System.IO.Directory.Exists(Trim(tblRutas.Rows(0).Item("RUTARUTA")) & "\" & stRuta) = False Then

                                    System.IO.Directory.CreateDirectory(Trim(tblRutas.Rows(0).Item("RUTARUTA")) & "\" & stRuta)

                                End If

                            End If

                        End If

                        Dim objRutas1 As New cla_RUTAS
                        Dim tblRutas1 As New DataTable

                        tblRutas1 = objRutas1.fun_Buscar_CODIGO_MANT_RUTAS(5)

                        If tblRutas1.Rows.Count > 0 Then

                            If tblRutas1.Rows.Count > 0 AndAlso Trim(Me.txtREAANURA.Text) <> "" AndAlso Trim(Me.txtREAAFERA.Text).ToString.Length = 10 Then

                                Dim stRuta As String = Trim(Me.txtREAANURA.Text) & "-" & fun_Formato_Mascara_4_String(Trim(Me.txtREAAFERA.Text.ToString.Substring(6, 4)))

                                If System.IO.Directory.Exists(Trim(tblRutas1.Rows(0).Item("RUTARUTA")) & "\" & stRuta) = False Then

                                    System.IO.Directory.CreateDirectory(Trim(tblRutas1.Rows(0).Item("RUTARUTA")) & "\" & stRuta)

                                End If

                            End If

                        End If

                        mod_MENSAJE.Se_Guardaron_Los_Datos_Correctamente()
                        Me.cboREAAACAD.Focus()
                        Me.Close()
                    Else
                        mod_MENSAJE.No_Se_Guardo_El_Registro_En_La_Base_De_Datos()
                    End If

                End If

            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub cmdCANCELAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSALIR.Click
        Me.cboREAAACAD.Focus()
        Me.Close()
    End Sub

#End Region

#Region "FORMULARIO"

#Region "KeyPress"

    Private Sub txt_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboREAAACAD.KeyPress, cboREAATITR.KeyPress, txtREAANUEM.KeyPress, txtREAAFEEM.KeyPress, txtREAANURA.KeyPress, txtREAAFERA.KeyPress, txtREAANURR.KeyPress, txtREAAFERR.KeyPress, txtREAAOBSE.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Or e.KeyChar = Convert.ToChar(Keys.Tab) Then
            pp_pro_SaltarCampo()
        End If
    End Sub

#End Region

#Region "GotFocus"

    Private Sub txt_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtREAANUEM.GotFocus, txtREAAFEEM.GotFocus, txtREAANURA.GotFocus, txtREAAFERA.GotFocus, txtREAANURR.GotFocus, txtREAAFERR.GotFocus, txtREAAOBSE.GotFocus
        pp_pro_SobrearCampo(sender)
        pp_pro_DescripcionCampo(Me.strBARRESTA.Items(0), sender)
    End Sub
    Private Sub cmd_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdGUARDAR.GotFocus, cmdSALIR.GotFocus
        pp_pro_DescripcionCampo(Me.strBARRESTA.Items(0), sender)
    End Sub
    Private Sub cbo_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboREAAACAD.GotFocus, cboREAATITR.GotFocus
        pp_pro_DescripcionCampo(Me.strBARRESTA.Items(0), sender)
    End Sub

#End Region

#Region "ValueChanged"

    Private Sub dtpREAAFEEM_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpREAAFEEM.ValueChanged
        Me.txtREAAFEEM.Text = Me.dtpREAAFEEM.Value
    End Sub
    Private Sub dtpREAAFERA_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpREAAFERA.ValueChanged
        Me.txtREAAFERA.Text = Me.dtpREAAFERA.Value
    End Sub
    Private Sub dtpREAAFERR_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpREAAFERR.ValueChanged
        Me.txtREAAFERR.Text = Me.dtpREAAFERR.Value
    End Sub

#End Region

#Region "SelectedIndexChanged"

    Private Sub cboREAAACAD_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboREAAACAD.SelectedIndexChanged
        Me.lblREAAACAD.Text = CType(fun_Buscar_Lista_Valores_ACTOADMI_Codigo(Me.cboREAAACAD), String)
    End Sub
    Private Sub cboREAATITR_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboREAATITR.SelectedIndexChanged
        Me.lblREAATITR.Text = CType(fun_Buscar_Lista_Valores_TIPOTRAM_Codigo(Me.cboREAATITR), String)
    End Sub

#End Region

#Region "Click"

    Private Sub cboREAAACAD_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboREAAACAD.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_ACTOADMI_Descripcion(Me.cboREAAACAD, Me.cboREAAACAD.SelectedIndex)
    End Sub
    Private Sub cboREAATITR_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboREAATITR.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_TIPOTRAM_Descripcion(Me.cboREAATITR, Me.cboREAATITR.SelectedIndex)
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