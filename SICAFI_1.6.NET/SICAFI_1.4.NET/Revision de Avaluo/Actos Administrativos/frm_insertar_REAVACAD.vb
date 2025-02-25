Imports REGLAS_DEL_NEGOCIO
Imports System
Imports System.IO

Public Class frm_insertar_REAVACAD

    '=====================================================
    '*** INSERTAR ACTOS ADMINISTRAD REVISION DE AVALUO ***
    '=====================================================

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

        Me.cboRAAAACAD.DataSource = New DataTable
        Me.cboRAAATITR.DataSource = New DataTable

        Me.txtRAAANUEM.Text = "0"
        Me.txtRAAAFEEM.Text = ""
        Me.txtRAAANURA.Text = "0"
        Me.txtRAAAFERA.Text = ""
        Me.txtRAAANURR.Text = "0"
        Me.txtRAAAFERR.Text = ""
        Me.txtRAAAOBSE.Text = ""

    End Sub
    Private Sub pro_inicializarControles()

        Try

            ' instancia la clase
            Dim objdatos As New cla_REAVACAD
            Dim tbl As New DataTable

            tbl = objdatos.fun_Consultar_REAVACAD(inACADSECU)

            If tbl.Rows.Count > 0 Then
                boMODIFICAR = True

                Me.Text = "Modificar registro"
                Me.fraINFOUSUA.Text = "MODIFICAR ACTO ADMINISTRATIVO"

                Dim objdatos2 As New cla_TIPOTRAM

                Me.cboRAAATITR.DataSource = objdatos2.fun_Consultar_CAMPOS_MANT_TIPOTRAM
                Me.cboRAAATITR.DisplayMember = "TITRDESC"
                Me.cboRAAATITR.ValueMember = "TITRCODI"

                Me.cboRAAATITR.SelectedValue = tbl.Rows(0).Item("RAAATITR")

                Dim objdatos1 As New cla_ACTOADMI

                Me.cboRAAAACAD.DataSource = objdatos1.fun_Consultar_CAMPOS_MANT_ACTOADMI
                Me.cboRAAAACAD.DisplayMember = "ACADDESC"
                Me.cboRAAAACAD.ValueMember = "ACADCODI"

                Me.cboRAAAACAD.SelectedValue = tbl.Rows(0).Item("RAAAACAD")

                Me.txtRAAANUEM.Text = CStr(Trim(tbl.Rows(0).Item("RAAANUEM")))
                Me.txtRAAAFEEM.Text = CStr(Trim(tbl.Rows(0).Item("RAAAFEEM")))
                Me.txtRAAANURA.Text = CStr(Trim(tbl.Rows(0).Item("RAAANURA")))
                Me.txtRAAAFERA.Text = CStr(Trim(tbl.Rows(0).Item("RAAAFERA")))
                Me.txtRAAANURR.Text = CStr(Trim(tbl.Rows(0).Item("RAAANURR")))
                Me.txtRAAAFERR.Text = CStr(Trim(tbl.Rows(0).Item("RAAAFERR")))
                Me.txtRAAAOBSE.Text = CStr(Trim(tbl.Rows(0).Item("RAAAOBSE")))

                If fun_Verificar_Dato_Fecha_Evento_Validated(Me.txtRAAAFEEM.Text) = True Then
                    Me.dtpRAAAFEEM.Value = CDate(tbl.Rows(0).Item("RAAAFEEM"))
                End If

                If fun_Verificar_Dato_Fecha_Evento_Validated(Me.txtRAAAFERA.Text) = True Then
                    Me.dtpRAAAFERA.Value = CDate(tbl.Rows(0).Item("RAAAFERA"))
                End If

                If fun_Verificar_Dato_Fecha_Evento_Validated(Me.txtRAAAFERR.Text) = True Then
                    Me.dtpRAAAFERR.Value = CDate(tbl.Rows(0).Item("RAAAFERR"))
                End If

            Else
                boINSERTAR = True

                Me.Text = "Insertar registro"
                Me.fraINFOUSUA.Text = "INSERTAR INFORMACIÓN DEL USUARIO"

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

                Dim boRAAAACAD As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboRAAAACAD)
                Dim boRAAATITR As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboRAAATITR)
                Dim boRAAANUEM As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.txtRAAANUEM)
                Dim boRAAANURA As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Numerico(Me.txtRAAANURA)
                Dim boRAAANURR As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Numerico(Me.txtRAAANURR)

                ' verifica los datos del formulario 
                If boRAAAACAD = True And _
                   boRAAATITR = True And _
                   boRAAANURA = True And _
                   boRAAANURR = True And _
                   boRAAANUEM = True Then

                    Dim objdatos22 As New cla_REAVACAD

                    If (objdatos22.fun_Insertar_REAVACAD(inACADSECU, _
                                                         Me.cboRAAAACAD.SelectedValue, _
                                                         Me.cboRAAATITR.SelectedValue, _
                                                         Me.txtRAAANUEM.Text, _
                                                         Me.txtRAAAFEEM.Text, _
                                                         Me.txtRAAANURA.Text, _
                                                         Me.txtRAAAFERA.Text, _
                                                         Me.txtRAAANURR.Text, _
                                                         Me.txtRAAAFERR.Text, _
                                                         Me.txtRAAAOBSE.Text)) = True Then

                        ' instancia la clase
                        Dim objRutas As New cla_RUTAS
                        Dim tblRutas As New DataTable

                        tblRutas = objRutas.fun_Buscar_CODIGO_MANT_RUTAS(14)

                        If tblRutas.Rows.Count > 0 Then

                            If tblRutas.Rows.Count > 0 AndAlso Trim(Me.txtRAAANUEM.Text) <> "" AndAlso Trim(Me.txtRAAAFEEM.Text).ToString.Length = 10 Then

                                Dim stRuta As String = fun_Formato_Mascara_3_String(Trim(Me.txtRAAANUEM.Text)) & "-" & fun_Formato_Mascara_4_String(Trim(Me.txtRAAAFEEM.Text.ToString.Substring(6, 4)))

                                If System.IO.Directory.Exists(Trim(tblRutas.Rows(0).Item("RUTARUTA")) & "\" & stRuta) = False Then

                                    System.IO.Directory.CreateDirectory(Trim(tblRutas.Rows(0).Item("RUTARUTA")) & "\" & stRuta)

                                End If

                            End If

                        End If

                        Dim objRutas1 As New cla_RUTAS
                        Dim tblRutas1 As New DataTable

                        tblRutas1 = objRutas1.fun_Buscar_CODIGO_MANT_RUTAS(5)

                        If tblRutas1.Rows.Count > 0 Then

                            If tblRutas1.Rows.Count > 0 AndAlso Trim(Me.txtRAAANURA.Text) <> "" AndAlso Trim(Me.txtRAAAFERA.Text).ToString.Length = 10 Then

                                Dim stRuta As String = Trim(Me.txtRAAANURA.Text) & "-" & fun_Formato_Mascara_4_String(Trim(Me.txtRAAAFERA.Text.ToString.Substring(6, 4)))

                                If System.IO.Directory.Exists(Trim(tblRutas1.Rows(0).Item("RUTARUTA")) & "\" & stRuta) = False Then

                                    System.IO.Directory.CreateDirectory(Trim(tblRutas1.Rows(0).Item("RUTARUTA")) & "\" & stRuta)

                                End If

                            End If

                        End If

                        mod_MENSAJE.Se_Guardaron_Los_Datos_Correctamente()
                        Me.cboRAAAACAD.Focus()
                        Me.Close()
                    Else
                        mod_MENSAJE.No_Se_Guardo_El_Registro_En_La_Base_De_Datos()
                    End If

                End If

                ' modifica el registro
            ElseIf boMODIFICAR = True Then

                ' instancia la clase
                Dim objVerifica As New cla_Verificar_Dato


                Dim boRAAAACAD As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboRAAAACAD)
                Dim boRAAATITR As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboRAAATITR)
                Dim boRAAANUEM As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.txtRAAANUEM)
                Dim boRAAANURA As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Numerico(Me.txtRAAANURA)
                Dim boRAAANURR As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Numerico(Me.txtRAAANURR)

                ' verifica los datos del formulario 
                If boRAAAACAD = True And _
                   boRAAATITR = True And _
                   boRAAANURA = True And _
                   boRAAANURR = True And _
                   boRAAANUEM = True Then

                    Dim objdatos22 As New cla_REAVACAD

                    If (objdatos22.fun_Actualizar_SECU_X_REAVACAD(inACADSECU, _
                                                                  Me.cboRAAAACAD.SelectedValue, _
                                                                  Me.cboRAAATITR.SelectedValue, _
                                                                  Me.txtRAAANUEM.Text, _
                                                                  Me.txtRAAAFEEM.Text, _
                                                                  Me.txtRAAANURA.Text, _
                                                                  Me.txtRAAAFERA.Text, _
                                                                  Me.txtRAAANURR.Text, _
                                                                  Me.txtRAAAFERR.Text, _
                                                                  Me.txtRAAAOBSE.Text)) = True Then

                        ' instancia la clase
                        Dim objRutas As New cla_RUTAS
                        Dim tblRutas As New DataTable

                        tblRutas = objRutas.fun_Buscar_CODIGO_MANT_RUTAS(14)

                        If tblRutas.Rows.Count > 0 Then

                            If tblRutas.Rows.Count > 0 AndAlso Trim(Me.txtRAAANUEM.Text) <> "" AndAlso Trim(Me.txtRAAAFEEM.Text).ToString.Length = 10 Then

                                Dim stRuta As String = fun_Formato_Mascara_3_String(Trim(Me.txtRAAANUEM.Text)) & "-" & fun_Formato_Mascara_4_String(Trim(Me.txtRAAAFEEM.Text.ToString.Substring(6, 4)))

                                If System.IO.Directory.Exists(Trim(tblRutas.Rows(0).Item("RUTARUTA")) & "\" & stRuta) = False Then

                                    System.IO.Directory.CreateDirectory(Trim(tblRutas.Rows(0).Item("RUTARUTA")) & "\" & stRuta)

                                End If

                            End If

                        End If

                        Dim objRutas1 As New cla_RUTAS
                        Dim tblRutas1 As New DataTable

                        tblRutas1 = objRutas1.fun_Buscar_CODIGO_MANT_RUTAS(5)

                        If tblRutas1.Rows.Count > 0 Then

                            If tblRutas1.Rows.Count > 0 AndAlso Trim(Me.txtRAAANURA.Text) <> "" AndAlso Trim(Me.txtRAAAFERA.Text).ToString.Length = 10 Then

                                Dim stRuta As String = Trim(Me.txtRAAANURA.Text) & "-" & fun_Formato_Mascara_4_String(Trim(Me.txtRAAAFERA.Text.ToString.Substring(6, 4)))

                                If System.IO.Directory.Exists(Trim(tblRutas1.Rows(0).Item("RUTARUTA")) & "\" & stRuta) = False Then

                                    System.IO.Directory.CreateDirectory(Trim(tblRutas1.Rows(0).Item("RUTARUTA")) & "\" & stRuta)

                                End If

                            End If

                        End If

                        mod_MENSAJE.Se_Guardaron_Los_Datos_Correctamente()
                        Me.cboRAAAACAD.Focus()
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
        Me.cboRAAAACAD.Focus()
        Me.Close()
    End Sub

#End Region

#Region "FORMULARIO"

#Region "KeyPress"

    Private Sub txt_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboRAAAACAD.KeyPress, cboRAAATITR.KeyPress, txtRAAANUEM.KeyPress, txtRAAAFEEM.KeyPress, txtRAAANURA.KeyPress, txtRAAAFERA.KeyPress, txtRAAANURR.KeyPress, txtRAAAFERR.KeyPress, txtRAAAOBSE.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Or e.KeyChar = Convert.ToChar(Keys.Tab) Then
            pp_pro_SaltarCampo()
        End If
    End Sub

#End Region

#Region "GotFocus"

    Private Sub txt_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtRAAANUEM.GotFocus, txtRAAAFEEM.GotFocus, txtRAAANURA.GotFocus, txtRAAAFERA.GotFocus, txtRAAANURR.GotFocus, txtRAAAFERR.GotFocus, txtRAAAOBSE.GotFocus
        pp_pro_SobrearCampo(sender)
        pp_pro_DescripcionCampo(Me.strBARRESTA.Items(0), sender)
    End Sub
    Private Sub cmd_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdGUARDAR.GotFocus, cmdSALIR.GotFocus
        pp_pro_DescripcionCampo(Me.strBARRESTA.Items(0), sender)
    End Sub
    Private Sub cbo_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboRAAAACAD.GotFocus, cboRAAATITR.GotFocus
        pp_pro_DescripcionCampo(Me.strBARRESTA.Items(0), sender)
    End Sub

#End Region

#Region "ValueChanged"

    Private Sub dtpRAAAFEEM_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpRAAAFEEM.ValueChanged
        Me.txtRAAAFEEM.Text = Me.dtpRAAAFEEM.Value
    End Sub
    Private Sub dtpRAAAFERA_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpRAAAFERA.ValueChanged
        Me.txtRAAAFERA.Text = Me.dtpRAAAFERA.Value
    End Sub
    Private Sub dtpRAAAFERR_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpRAAAFERR.ValueChanged
        Me.txtRAAAFERR.Text = Me.dtpRAAAFERR.Value
    End Sub

#End Region

#Region "SelectedIndexChanged"

    Private Sub cboRAAAACAD_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboRAAAACAD.SelectedIndexChanged
        Me.lblRAAAACAD.Text = CType(fun_Buscar_Lista_Valores_ACTOADMI_Codigo(Me.cboRAAAACAD), String)
    End Sub
    Private Sub cboRAAATITR_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboRAAATITR.SelectedIndexChanged
        Me.lblRAAATITR.Text = CType(fun_Buscar_Lista_Valores_TIPOTRAM_Codigo(Me.cboRAAATITR), String)
    End Sub

#End Region

#Region "Click"

    Private Sub cboRAAAACAD_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboRAAAACAD.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_ACTOADMI_Descripcion(Me.cboRAAAACAD, Me.cboRAAAACAD.SelectedIndex)
    End Sub
    Private Sub cboRAAATITR_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboRAAATITR.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_TIPOTRAM_Descripcion(Me.cboRAAATITR, Me.cboRAAATITR.SelectedIndex)
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