Imports REGLAS_DEL_NEGOCIO

Public Class frm_consulta_trabajo_de_campo_TRABCAMP

    '=================================
    '*** CONSULTA TRABAJO DE CAMPO ***
    '=================================

#Region "VARIABLES"

    Dim boCONSULTA As Boolean = False
    Dim stORDERBY As String = ""
    Dim inID_REGISTRO As Integer

    Dim dt As DataTable

#End Region

#Region "INSTANCIAR FORMULARIO"

    Private Shared frm_Instance = Nothing

    Public Shared Function instance() As frm_consulta_trabajo_de_campo_TRABCAMP
        If frm_Instance Is Nothing OrElse frm_Instance.isdisposed = True Then
            frm_Instance = New frm_consulta_trabajo_de_campo_TRABCAMP
        End If

        frm_Instance.bringtofront()

        Return frm_Instance

    End Function

    Private Sub New()
        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()
        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
    End Sub

#End Region

#Region "PROCEDIMIENTOS"

    Private Sub pro_Reconsultar()

        Try
            ' instancia un dt
            dt = New DataTable

            ' crea la variable de consulta
            Dim stConsulta As String = ""

            ' crea la variable de los campos
            Dim stTRCAMUNI As String = ""
            Dim stTRCACORR As String = ""
            Dim stTRCABARR As String = ""
            Dim stTRCAMANZ As String = ""
            Dim stTRCAPRED As String = ""
            Dim stTRCACLSE As String = ""
            Dim stTRCAVIGE As String = ""
            Dim stTRCACAAC As String = ""
            Dim stTRCAFEES As String = ""
            Dim stTRCAESCR As String = ""
            Dim stTRCANODE As String = ""
            Dim stTRCANOMU As String = ""
            Dim stTRCANOTA As String = ""
            Dim stTRCAMAIN As String = ""
            Dim stTRCAESTA As String = ""
            Dim stTRCAOBSE As String = ""
            Dim stTRCAFEIN As String = ""
            Dim stTRCADESC As String = ""

            ' carga los campos
            If Trim(Me.txtTRCAMUNI.Text) = "" Then
                stTRCAMUNI = "%"
            Else
                stTRCAMUNI = Trim(Me.txtTRCAMUNI.Text)
            End If

            ' carga los campos
            If Trim(Me.txtTRCACORR.Text) = "" Then
                stTRCACORR = "%"
            Else
                stTRCACORR = Trim(Me.txtTRCACORR.Text)
            End If

            ' carga los campos
            If Trim(Me.txtTRCABARR.Text) = "" Then
                stTRCABARR = "%"
            Else
                stTRCABARR = Trim(Me.txtTRCABARR.Text)
            End If

            ' carga los campos
            If Trim(Me.txtTRCAMANZ.Text) = "" Then
                stTRCAMANZ = "%"
            Else
                stTRCAMANZ = Trim(Me.txtTRCAMANZ.Text)
            End If

            ' carga los campos
            If Trim(Me.txtTRCAPRED.Text) = "" Then
                stTRCAPRED = "%"
            Else
                stTRCAPRED = Trim(Me.txtTRCAPRED.Text)
            End If

            ' carga los campos
            If Trim(Me.txtTRCACLSE.Text) = "" Then
                stTRCACLSE = "%"
            Else
                stTRCACLSE = Trim(Me.txtTRCACLSE.Text)
            End If

            ' carga los campos
            If Trim(Me.txtTRCAVIGE.Text) = "" Then
                stTRCAVIGE = "%"
            Else
                stTRCAVIGE = Trim(Me.txtTRCAVIGE.Text)
            End If

            ' carga los campos
            If Trim(Me.txtTRCACAAC.Text) = "" Then
                stTRCACAAC = "%"
            Else
                stTRCACAAC = Trim(Me.txtTRCACAAC.Text)
            End If

            ' carga los campos
            If Trim(Me.txtTRCAFEES.Text) = "" Then
                stTRCAFEES = "%"
            Else
                stTRCAFEES = Trim(Me.txtTRCAFEES.Text)
            End If

            ' carga los campos
            If Trim(Me.txtTRCAESCR.Text) = "" Then
                stTRCAESCR = "%"
            Else
                stTRCAESCR = Trim(Me.txtTRCAESCR.Text)
            End If

            ' carga los campos
            If Trim(Me.txtTRCANODE.Text) = "" Then
                stTRCANODE = "%"
            Else
                stTRCANODE = Trim(Me.txtTRCANODE.Text)
            End If

            ' carga los campos
            If Trim(Me.txtTRCANOMU.Text) = "" Then
                stTRCANOMU = "%"
            Else
                stTRCANOMU = Trim(Me.txtTRCANOMU.Text)
            End If

            ' carga los campos
            If Trim(Me.txtTRCANOTA.Text) = "" Then
                stTRCANOTA = "%"
            Else
                stTRCANOTA = Trim(Me.txtTRCANOTA.Text)
            End If

            ' carga los campos
            If Trim(Me.txtTRCAMAIN.Text) = "" Then
                stTRCAMAIN = "%"
            Else
                stTRCAMAIN = Trim(Me.txtTRCAMAIN.Text)
            End If

            ' carga los campos
            If Trim(Me.txtTRCAESTA.Text) = "" Then
                stTRCAESTA = "%"
            Else
                stTRCAESTA = Trim(Me.txtTRCAESTA.Text)
            End If

            ' carga los campos
            If Trim(Me.txtTRCADESC.Text) = "" Then
                stTRCADESC = "%"
            Else
                stTRCADESC = Trim(Me.txtTRCADESC.Text)
            End If

            'concatena la consulta
            stConsulta += "Select "
            stConsulta += "TRCAIDRE , "
            stConsulta += "TRCAMUNI as 'Municipio', "
            stConsulta += "TRCACORR as 'Correg', "
            stConsulta += "TRCABARR as 'Barrio', "
            stConsulta += "TRCAMANZ as 'Manzana', "
            stConsulta += "TRCAPRED as 'Predio', "
            stConsulta += "TRCACLSE as 'Sector', "
            stConsulta += "TRCAVIGE as 'Vigencia', "
            stConsulta += "TRCAFEIN as 'Fecha_de_ingreso', "
            stConsulta += "TRCAESCR as 'Escritura', "
            stConsulta += "TRCAFEES as 'Fecha_escritura', "
            stConsulta += "TRCANODE as 'Departamento_Notaria', "
            stConsulta += "TRCANOMU as 'Municipio_Notaria', "
            stConsulta += "TRCANOTA as 'Notaria', "
            stConsulta += "TRCACAAC as 'Causa', "
            stConsulta += "CAACDESC as 'Causa_Descripcion', "
            stConsulta += "TRCAMAIN as 'Matricula', "
            stConsulta += "TRCAPRNU as 'Predios_nuevos', "
            stConsulta += "TRCAPRMO as 'Predios_modificados', "
            stConsulta += "TRCAPREL as 'Predios_eliminados', "
            stConsulta += "TRCADESC as 'Descripción', "
            stConsulta += "TRCAESTA as 'Estado' "
          

            stConsulta += "From TRABCAMP, MANT_CAUSACTO "
            stConsulta += "Where "
            stConsulta += "TRCACAAC = CAACCODI and "
            stConsulta += "TRCAMUNI like '" & stTRCAMUNI & "' and "
            stConsulta += "TRCACORR like '" & stTRCACORR & "' and "
            stConsulta += "TRCABARR like '" & stTRCABARR & "' and "
            stConsulta += "TRCAMANZ like '" & stTRCAMANZ & "' and "
            stConsulta += "TRCAPRED like '" & stTRCAPRED & "' and "
            stConsulta += "TRCACLSE like '" & stTRCACLSE & "' and "
            stConsulta += "TRCAVIGE like '" & stTRCAVIGE & "' and "
            stConsulta += "TRCACAAC like '" & stTRCACAAC & "' and "
            stConsulta += "TRCAFEES like '" & stTRCAFEES & "' and "
            stConsulta += "TRCAESCR like '" & stTRCAESCR & "' and "
            stConsulta += "TRCANODE like '" & stTRCANODE & "' and "
            stConsulta += "TRCANOMU like '" & stTRCANOMU & "' and "
            stConsulta += "TRCANOTA like '" & stTRCANOTA & "' and "
            stConsulta += "TRCAMAIN like '%" & stTRCAMAIN & "%' and "
            stConsulta += "TRCAESTA like '" & stTRCAESTA & "' and "
            stConsulta += "TRCADESC like '%" & stTRCADESC & "%'  "
            stConsulta += "Order by TRCACLSE, TRCAMUNI, TRCACORR, TRCABARR, TRCAMANZ, TRCAPRED "

            ' instancia la clase y almacena la consulta
            Dim oConsulta As New cla_Consulta_ConexionString

            dt = oConsulta.fun_Consultar_ConexionString(stConsulta)

            Me.dgvCONSULTA.DataSource = dt

            Me.dgvCONSULTA.Columns(0).Visible = False

            ' verifica si existen datos consultados
            If Me.dgvCONSULTA.RowCount = 0 Then
                mod_MENSAJE.No_Se_Encontro_Ningun_registro()
                Me.txtTRCAMUNI.Focus()
            End If

            Me.strBARRESTA.Items(2).Text = "Registros : " & dt.Rows.Count

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub pro_ListaDeValores()

        Try
            ' encuestra la posición seleccionada
            Dim I, SW As Byte

            While I < Me.dgvCONSULTA.RowCount And SW = 0
                If Me.dgvCONSULTA.SelectedRows.Item(0).Cells(I).Selected Then

                    Me.txtTRCAMUNI.Text = Trim(Me.dgvCONSULTA.SelectedRows.Item(0).Cells(1).Value.ToString())
                    Me.txtTRCACORR.Text = Trim(Me.dgvCONSULTA.SelectedRows.Item(0).Cells(2).Value.ToString())
                    Me.txtTRCABARR.Text = Trim(Me.dgvCONSULTA.SelectedRows.Item(0).Cells(3).Value.ToString())
                    Me.txtTRCAMANZ.Text = Trim(Me.dgvCONSULTA.SelectedRows.Item(0).Cells(4).Value.ToString())
                    Me.txtTRCAPRED.Text = Trim(Me.dgvCONSULTA.SelectedRows.Item(0).Cells(5).Value.ToString())
                    Me.txtTRCACLSE.Text = Trim(Me.dgvCONSULTA.SelectedRows.Item(0).Cells(6).Value.ToString())
                    Me.txtTRCAVIGE.Text = Trim(Me.dgvCONSULTA.SelectedRows.Item(0).Cells(7).Value.ToString())
                    Me.txtTRCACAAC.Text = Trim(Me.dgvCONSULTA.SelectedRows.Item(0).Cells(11).Value.ToString())
                    Me.txtTRCAESTA.Text = Trim(Me.dgvCONSULTA.SelectedRows.Item(0).Cells(18).Value.ToString())
                    Me.txtTRCAESCR.Text = Trim(Me.dgvCONSULTA.SelectedRows.Item(0).Cells(9).Value.ToString())
                    Me.txtTRCAFEES.Text = Trim(Me.dgvCONSULTA.SelectedRows.Item(0).Cells(10).Value.ToString())
                    Me.txtTRCANODE.Text = Trim(Me.dgvCONSULTA.SelectedRows.Item(0).Cells(19).Value.ToString())
                    Me.txtTRCANOMU.Text = Trim(Me.dgvCONSULTA.SelectedRows.Item(0).Cells(20).Value.ToString())
                    Me.txtTRCANOTA.Text = Trim(Me.dgvCONSULTA.SelectedRows.Item(0).Cells(21).Value.ToString())
                    Me.txtTRCAMAIN.Text = Trim(Me.dgvCONSULTA.SelectedRows.Item(0).Cells(13).Value.ToString())
                    Me.txtTRCADESC.Text = Trim(Me.dgvCONSULTA.SelectedRows.Item(0).Cells(17).Value.ToString())

                    SW = 1
                Else
                    I = I + 1
                End If
            End While

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub pro_LimpiarCampos()

        Me.txtTRCAMUNI.Text = ""
        Me.txtTRCACORR.Text = ""
        Me.txtTRCABARR.Text = ""
        Me.txtTRCAMANZ.Text = ""
        Me.txtTRCAPRED.Text = ""
        Me.txtTRCACLSE.Text = ""
        Me.txtTRCAVIGE.Text = ""
        Me.txtTRCACAAC.Text = ""
        Me.txtTRCAESTA.Text = ""
        Me.txtTRCAESCR.Text = ""
        Me.txtTRCAFEES.Text = ""
        Me.txtTRCANODE.Text = ""
        Me.txtTRCANOMU.Text = ""
        Me.txtTRCANOTA.Text = ""
        Me.txtTRCAMAIN.Text = ""
        Me.txtTRCADESC.Text = ""

        Me.strBARRESTA.Items(2).Text = "Registros: 0"

        Me.dgvCONSULTA.DataSource = New DataTable

    End Sub

#End Region

#Region "MENU"

    Private Sub cmdConsultar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdConsultar.Click

        Try
            pro_Reconsultar()
            pro_ListaDeValores()

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub cmdAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        If Me.dgvCONSULTA.RowCount = 0 Then
            MessageBox.Show("No existen registro seleccionados", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
        Else
            Dim inId_Reg As New frm_TRABCAMP(Integer.Parse(Me.dgvCONSULTA.SelectedRows.Item(0).Cells(0).Value.ToString()))
            Me.txtTRCAMUNI.Focus()
            Me.Close()
        End If

    End Sub
    Private Sub cmdLimpiar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdLimpiar.Click
        pro_LimpiarCampos()
        Me.txtTRCAMUNI.Focus()
    End Sub
    Private Sub cmdSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSalir.Click
        Me.Close()
    End Sub
    Private Sub cmdExportarExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExportarExcel.Click

        Try
            If Me.dgvCONSULTA.RowCount = 0 Then
                MessageBox.Show("No existe datos para exportar", "Mensaje ...", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1)
            Else
                ' Crea objeto registros
                Dim dr1 As DataRow

                ' crea la tabla
                Dim dt_CargaDatos As New DataTable

                dt_CargaDatos.Columns.Add(New DataColumn("Municipio", GetType(String)))
                dt_CargaDatos.Columns.Add(New DataColumn("Correg", GetType(String)))
                dt_CargaDatos.Columns.Add(New DataColumn("Barrio", GetType(String)))
                dt_CargaDatos.Columns.Add(New DataColumn("Manzana", GetType(String)))
                dt_CargaDatos.Columns.Add(New DataColumn("Predio", GetType(String)))
                dt_CargaDatos.Columns.Add(New DataColumn("Sector", GetType(String)))
                dt_CargaDatos.Columns.Add(New DataColumn("Vigencia", GetType(String)))
                dt_CargaDatos.Columns.Add(New DataColumn("Causa", GetType(String)))
                dt_CargaDatos.Columns.Add(New DataColumn("Causa_Descripcion", GetType(String)))
                dt_CargaDatos.Columns.Add(New DataColumn("Matricula", GetType(String)))
                dt_CargaDatos.Columns.Add(New DataColumn("Fecha_escritura", GetType(String)))
                dt_CargaDatos.Columns.Add(New DataColumn("Predios_nuevos", GetType(String)))
                dt_CargaDatos.Columns.Add(New DataColumn("Predios_modificados", GetType(String)))
                dt_CargaDatos.Columns.Add(New DataColumn("Predios_eliminados", GetType(String)))
                dt_CargaDatos.Columns.Add(New DataColumn("Fecha_de_ingreso", GetType(String)))
                dt_CargaDatos.Columns.Add(New DataColumn("Descripción", GetType(String)))
                dt_CargaDatos.Columns.Add(New DataColumn("Estado", GetType(String)))

                ' declara la variable
                Dim i As Integer = 0

                For i = 0 To dt.Rows.Count - 1

                    dr1 = dt_CargaDatos.NewRow()

                    dr1("Municipio") = CStr(dt.Rows(i).Item("Municipio").ToString)
                    dr1("Correg") = CStr(dt.Rows(i).Item("Correg").ToString)
                    dr1("Barrio") = CStr(dt.Rows(i).Item("Barrio").ToString)
                    dr1("Manzana") = CStr(dt.Rows(i).Item("Manzana").ToString)
                    dr1("Predio") = CStr(dt.Rows(i).Item("Predio").ToString)
                    dr1("Sector") = CStr(dt.Rows(i).Item("Sector").ToString)
                    dr1("Vigencia") = CStr(dt.Rows(i).Item("Vigencia").ToString)
                    dr1("Causa") = CStr(dt.Rows(i).Item("Causa").ToString)

                    ' instancia la clase
                    Dim obCAUSACTO As New cla_CAUSACTO
                    Dim dtCAUSACTO As New DataTable

                    dtCAUSACTO = obCAUSACTO.fun_Buscar_CODIGO_MANT_CAUSACTO(CStr(dt.Rows(i).Item("Causa").ToString))

                    If dtCAUSACTO.Rows.Count > 0 Then
                        dr1("Causa_Descripcion") = CStr(dtCAUSACTO.Rows(0).Item("CAACDESC").ToString)
                    Else
                        dr1("Causa_Descripcion") = CStr("")
                    End If

                    dr1("Matricula") = CStr(dt.Rows(i).Item("Matricula").ToString)

                    If fun_Verificar_Dato_Fecha_Evento_Validated(dt.Rows(i).Item("Fecha_escritura").ToString) = True Then
                        dr1("Fecha_escritura") = CStr(Trim(dt.Rows(i).Item("Fecha_escritura").ToString)) & "."
                    Else
                        dr1("Fecha_escritura") = ""
                    End If

                    dr1("Predios_nuevos") = CStr(dt.Rows(i).Item("Predios_nuevos").ToString)
                    dr1("Predios_modificados") = CStr(dt.Rows(i).Item("Predios_modificados").ToString)
                    dr1("Predios_eliminados") = CStr(dt.Rows(i).Item("Predios_eliminados").ToString)

                    If fun_Verificar_Dato_Fecha_Evento_Validated(dt.Rows(i).Item("Fecha_de_ingreso").ToString) = True Then
                        dr1("Fecha_de_ingreso") = CStr(Trim(dt.Rows(i).Item("Fecha_de_ingreso").ToString)).ToString.Substring(0, 10).ToString.Replace("/", "-") & "."
                    Else
                        dr1("Fecha_de_ingreso") = ""
                    End If

                    dr1("Descripción") = CStr(dt.Rows(i).Item("Descripción").ToString)
                    dr1("Estado") = CStr(dt.Rows(i).Item("Estado").ToString)


                    dt_CargaDatos.Rows.Add(dr1)

                Next

                Dim oExp As New cla_ExportarTablaExcel
                oExp.DataTableToExcel(dt_CargaDatos)

            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try
    End Sub

#End Region

#Region "FORMULARIO"

#Region "Load"

    Private Sub Frm_Consultar_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        pro_LimpiarCampos()

    End Sub

#End Region

#Region "GotFocus"

    Private Sub frm_consultar_TRABCAMP_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.GotFocus
        Me.txtTRCAMUNI.Focus()
    End Sub

#End Region

#Region "KeyPress"

    Private Sub txt_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtTRCAMUNI.KeyPress, txtTRCACORR.KeyPress, txtTRCABARR.KeyPress, txtTRCAMANZ.KeyPress, txtTRCAPRED.KeyPress, txtTRCACLSE.KeyPress, txtTRCAVIGE.KeyPress, txtTRCACAAC.KeyPress, txtTRCAFEES.KeyPress, txtTRCAESCR.KeyPress, txtTRCANODE.KeyPress, txtTRCANOMU.KeyPress, txtTRCANOTA.KeyPress, txtTRCAMAIN.KeyPress, txtTRCAESTA.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Or e.KeyChar = Convert.ToChar(Keys.Tab) Then
            pp_pro_SaltarCampo()
        End If
    End Sub


#End Region

#Region "GotFocus"

    Private Sub txt_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtTRCAMUNI.GotFocus, txtTRCACORR.GotFocus, txtTRCABARR.GotFocus, txtTRCAMANZ.GotFocus, txtTRCAPRED.GotFocus, txtTRCAFEES.GotFocus, txtTRCAESCR.GotFocus, txtTRCAMAIN.GotFocus
        pp_pro_SobrearCampo(sender)
        pp_pro_DescripcionCampo(Me.strBARRESTA.Items(0), sender)
    End Sub
    Private Sub cmd_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdSalir.GotFocus, cmdConsultar.GotFocus, cmdLimpiar.GotFocus
        pp_pro_DescripcionCampo(Me.strBARRESTA.Items(0), sender)
    End Sub
    Private Sub cbo_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtTRCACLSE.GotFocus, txtTRCAVIGE.GotFocus, txtTRCACAAC.GotFocus, txtTRCANODE.GotFocus, txtTRCANOMU.GotFocus, txtTRCANOTA.GotFocus, txtTRCAESTA.GotFocus
        pp_pro_DescripcionCampo(Me.strBARRESTA.Items(0), sender)
    End Sub

#End Region

#Region "Validated"

    Private Sub txtTRCAMUNI_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtTRCAMUNI.Validated
        If Me.txtTRCAMUNI.Text <> "" And fun_Verificar_Dato_Numerico_Evento_Validated(Me.txtTRCAMUNI.Text) = True Then
            Me.txtTRCAMUNI.Text = fun_Formato_Mascara_3_String(Me.txtTRCAMUNI.Text)
        End If
    End Sub
    Private Sub txtTRCACORR_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtTRCACORR.Validated
        If Me.txtTRCACORR.Text <> "" And fun_Verificar_Dato_Numerico_Evento_Validated(Me.txtTRCACORR.Text) = True Then
            Me.txtTRCACORR.Text = fun_Formato_Mascara_2_String(Me.txtTRCACORR.Text)
        End If
    End Sub
    Private Sub txtTRCABARR_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtTRCABARR.Validated
        If Me.txtTRCABARR.Text <> "" And fun_Verificar_Dato_Numerico_Evento_Validated(Me.txtTRCABARR.Text) = True Then
            Me.txtTRCABARR.Text = fun_Formato_Mascara_3_String(Me.txtTRCABARR.Text)
        End If
    End Sub
    Private Sub txtTRCAMANZ_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtTRCAMANZ.Validated
        If Me.txtTRCAMANZ.Text <> "" And fun_Verificar_Dato_Numerico_Evento_Validated(Me.txtTRCAMANZ.Text) = True Then
            Me.txtTRCAMANZ.Text = fun_Formato_Mascara_3_String(Me.txtTRCAMANZ.Text)
        End If
    End Sub
    Private Sub txtTRCAPRED_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtTRCAPRED.Validated
        If Me.txtTRCAPRED.Text <> "" And fun_Verificar_Dato_Numerico_Evento_Validated(Me.txtTRCAPRED.Text) = True Then
            Me.txtTRCAPRED.Text = fun_Formato_Mascara_5_String(Me.txtTRCAPRED.Text)
        End If
    End Sub

#End Region

#Region "CellClick"

    Private Sub dgvCONSULTA_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvCONSULTA.CellClick
        pro_ListaDeValores()
    End Sub

#End Region

#Region "KeyUp"

    Private Sub dgvCONSULTA_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgvCONSULTA.KeyUp
        If e.KeyCode = Keys.Down Or e.KeyCode = Keys.Up Or e.KeyCode = Keys.Enter Or e.KeyCode = Keys.PageUp Or e.KeyCode = Keys.PageDown Or e.KeyCode = Keys.PageUp Or e.KeyCode = Keys.PageDown Then
            pro_ListaDeValores()
        End If
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