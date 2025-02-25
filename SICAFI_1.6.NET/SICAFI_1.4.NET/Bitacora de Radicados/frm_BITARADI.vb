Imports REGLAS_DEL_NEGOCIO
Imports System
Imports System.IO
Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration
Imports System.Text

Public Class frm_BITARADI

    '=============================
    '*** BITACORA DE RADICADOS ***
    '=============================

#Region "VARIABLES"

    Private boCONSULTA_LIBRRADI As Boolean = False

    Private oEjecutar As New SqlCommand
    Private oConexion As New SqlConnection
    Private oAdapter As New SqlDataAdapter
    Private oReader As SqlDataReader
    Private ds As New DataSet
    Private dt As New DataTable

#End Region

#Region "INSTANCIAR FORMULARIO"

    Private Shared frm_Instance = Nothing

    Public Shared Function instance() As frm_BITARADI
        If frm_Instance Is Nothing OrElse frm_Instance.isdisposed = True Then
            frm_Instance = New frm_BITARADI
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

#Region "CONSTRUCTOR"

    Public Sub New(ByVal stNroDocumento As String)

        vp_cedula = stNroDocumento
        InitializeComponent()

    End Sub
    Public Sub New(ByVal stNroDocumento As String, ByVal stEstado As String)

        vp_cedula = stNroDocumento
        vp_stEstado = stEstado

        InitializeComponent()

    End Sub

#End Region

#Region "FUNCIONES LIBRO RADICADOR"

    Private Function fun_ContarDiasHabiles(ByVal inDiasCalendario As Integer) As Integer

        Try
            Dim inDiasHabiles As Integer = inDiasCalendario * (5 / 7)

            Return inDiasHabiles

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Function
    Private Function fun_ContarTramitesPendientes() As Integer

        Try
            Dim inCantidad As Integer = 0

            If Me.dgvLIBRRADI_1.RowCount > 0 Then
                inCantidad = Me.dgvLIBRRADI_1.RowCount
            End If

            Return inCantidad

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Function
    Private Function fun_ContarTramitesFinalizados() As Integer

        Try
            Dim inCantidad As Integer = 0

            ' instancia la clase
            Dim obLIBRRADI As New cla_LIBRRADI
            Dim dtLIBRRADI As New DataTable

            dtLIBRRADI = obLIBRRADI.fun_Consultar_LIBRRADI_X_ESTADO(Trim("fi"))

            If dtLIBRRADI.Rows.Count > 0 Then
                inCantidad = dtLIBRRADI.Rows.Count
            End If

            Return inCantidad

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Function
    Private Function fun_ContarTramitesPorEstadoPorusuario(ByVal stLRDFUSUA As String, ByVal stLIRAESTA As String) As Integer

        Try
            ' declara la variables
            Dim inCantidad As Integer = 0

            ' instancia la clase
            Dim obLIBRRADI As New cla_LIBRRADI
            Dim dtLIBRRADI As New DataTable

            dtLIBRRADI = obLIBRRADI.fun_Consultar_Cantidad_de_Usuario_x_Estado_LIBRRADI(CStr(Trim(stLRDFUSUA)), CStr(Trim(stLIRAESTA)))

            If dtLIBRRADI.Rows.Count > 0 Then
                inCantidad = CInt(dtLIBRRADI.Rows(0).Item("Cantidad"))
            End If

            Return inCantidad

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Function
    Private Function fun_ContarTramitesRiesgoBajoPorFuncionario(ByVal stUsuario As String) As Integer

        Try
            Dim inCantidad As Integer = 0

            Dim obLIBRRADI As New cla_LIBRRADI
            Dim dtLIBRRADI As New DataTable

            dtLIBRRADI = obLIBRRADI.fun_Consultar_Cantidad_x_Usuario_LIBRRADI(CStr(Trim(stUsuario)))

            If dtLIBRRADI.Rows.Count > 0 Then

                Dim i As Integer = 0

                For i = 0 To dtLIBRRADI.Rows.Count - 1

                    Dim inValor As Integer = (CInt(dtLIBRRADI.Rows(i).Item("Cantidad").ToString) * (5 / 7))

                    If (inValor >= 0 And inValor <= 7) Then

                        inCantidad += 1

                    End If

                Next

            End If

            Return inCantidad

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Function
    Private Function fun_ContarTramitesRiesgoMedioPorFuncionario(ByVal stUsuario As String) As Integer

        Try
            Dim inCantidad As Integer = 0

            Dim obLIBRRADI As New cla_LIBRRADI
            Dim dtLIBRRADI As New DataTable

            dtLIBRRADI = obLIBRRADI.fun_Consultar_Cantidad_x_Usuario_LIBRRADI(CStr(Trim(stUsuario)))

            If dtLIBRRADI.Rows.Count > 0 Then

                Dim i As Integer = 0

                For i = 0 To dtLIBRRADI.Rows.Count - 1

                    Dim inValor As Integer = (CInt(dtLIBRRADI.Rows(i).Item("Cantidad").ToString) * (5 / 7))

                    If (inValor >= 8 And inValor <= 15) Then

                        inCantidad += 1

                    End If

                Next

            End If

            Return inCantidad

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Function
    Private Function fun_ContarTramitesRiesgoAltoPorFuncionario(ByVal stUsuario As String) As Integer

        Try
            Dim inCantidad As Integer = 0

            Dim obLIBRRADI As New cla_LIBRRADI
            Dim dtLIBRRADI As New DataTable

            dtLIBRRADI = obLIBRRADI.fun_Consultar_Cantidad_x_Usuario_LIBRRADI(CStr(Trim(stUsuario)))

            If dtLIBRRADI.Rows.Count > 0 Then

                Dim i As Integer = 0

                For i = 0 To dtLIBRRADI.Rows.Count - 1

                    Dim inValor As Integer = (CInt(dtLIBRRADI.Rows(i).Item("Cantidad").ToString) * (5 / 7))

                    If (inValor >= 16) Then

                        inCantidad += 1

                    End If

                Next

            End If

            Return inCantidad

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Function

    Private Function fun_ContarTramitesPorVigenciaPorFuncionario(ByVal inVigencia As Integer, ByVal stEstado As String) As Integer

        Try
            Dim inCantidad As Integer = 0

            Dim obLIBRRADI As New cla_LIBRRADI
            Dim dtLIBRRADI As New DataTable

            dtLIBRRADI = obLIBRRADI.fun_Consultar_Cantidad_x_Usuario_y_Vigencia_LIBRRADI(CInt(inVigencia), CStr(Trim(stEstado)))

            If dtLIBRRADI.Rows.Count > 0 Then

                inCantidad = CInt(dtLIBRRADI.Rows(0).Item("Cantidad").ToString)

            End If

            Return inCantidad

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Function
    Private Function fun_ContarTramitesPorUsuarioVigenciaPorFuncionario(ByVal stUsuario As String, ByVal inVigencia As Integer, ByVal stEstado As String) As Integer

        Try
            Dim inCantidad As Integer = 0

            Dim obLIBRRADI As New cla_LIBRRADI
            Dim dtLIBRRADI As New DataTable

            dtLIBRRADI = obLIBRRADI.fun_Consultar_Cantidad_x_Usuario_y_Vigencia_LIBRRADI(CStr(Trim(stUsuario)), CInt(inVigencia), CStr(Trim(stEstado)))

            If dtLIBRRADI.Rows.Count > 0 Then

                inCantidad = CInt(dtLIBRRADI.Rows(0).Item("Cantidad").ToString)

            End If

            Return inCantidad

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Function

#End Region

#Region "PROCEDIMIENTOS LIBRO RADICADOR"

    Private Sub pro_ReconsultarLibroRadicador()

        Try
            Dim objdatos As New cla_LIBRRADI

            If boCONSULTA_LIBRRADI = False Then
                Me.BindingSource_LIBRRADI_1.DataSource = objdatos.fun_Consultar_LIBRRADI_X_BITACORA
            Else
                If CStr(Trim(vp_stEstado)) = "" Then
                    Me.BindingSource_LIBRRADI_1.DataSource = objdatos.fun_Consultar_LIBRRADI_X_BITACORA(CStr(Trim(vp_cedula)))
                Else
                    Me.BindingSource_LIBRRADI_1.DataSource = objdatos.fun_Consultar_LIBRRADI_X_BITACORA(CStr(Trim(vp_cedula)), CStr(Trim(vp_stEstado)))
                End If

            End If

            Me.dgvLIBRRADI_1.DataSource = BindingSource_LIBRRADI_1
            Me.dgvLIBRRADI_2.DataSource = BindingSource_LIBRRADI_1
            Me.dgvLIBRRADI_3.DataSource = BindingSource_LIBRRADI_1

            Me.BindingNavigator_LIBRRADI_1.BindingSource = BindingSource_LIBRRADI_1

            ' procedimeintos para listar los datos
            pro_LlenarListadoPorUsuarioLibroRadicador()
            pro_LlenarListadoPorVigenciaLibroRadicador()

            '=================================================
            '*** CONFIGURA OBJETOS DEL FORMULARIO MAESTRO ***
            '=================================================

            Me.strBARRESTA.Items(2).Text = "Registros : " & Me.BindingSource_LIBRRADI_1.Count

            Me.dgvLIBRRADI_1.Columns("LIRANURA").HeaderText = "Nro. Radicado"
            Me.dgvLIBRRADI_1.Columns("LIRAFERA").HeaderText = "Fecha de Radicado"
            Me.dgvLIBRRADI_1.Columns("LRDFFEAS").HeaderText = "Fecha de Asignación"
            Me.dgvLIBRRADI_1.Columns("LIRAFEIN").HeaderText = "Fecha de Ingreso"
            Me.dgvLIBRRADI_1.Columns("LIRAFEFI").HeaderText = "Fecha de Finalización"
            Me.dgvLIBRRADI_1.Columns("LIRAVIGE").HeaderText = "Vigencia"
            Me.dgvLIBRRADI_1.Columns("ESTADESC").HeaderText = "Estado"

            Me.dgvLIBRRADI_2.Columns("LIRAUSUA").HeaderText = "Usuario Remitente"
            Me.dgvLIBRRADI_2.Columns("LIRANUDO").HeaderText = "Nro. Documento"
            Me.dgvLIBRRADI_2.Columns("USUANOMB").HeaderText = "Nombre(s)"
            Me.dgvLIBRRADI_2.Columns("USUAPRAP").HeaderText = "Primer Apellido"
            Me.dgvLIBRRADI_2.Columns("USUASEAP").HeaderText = "Segundo Apellido"

            Me.dgvLIBRRADI_3.Columns("LRDFUSUA").HeaderText = "Usuario Destinario"
            Me.dgvLIBRRADI_3.Columns("LRDFNUDO").HeaderText = "Nro. Documento"
            Me.dgvLIBRRADI_3.Columns("USUANOMB1").HeaderText = "Nombre(s)"
            Me.dgvLIBRRADI_3.Columns("USUAPRAP1").HeaderText = "Primer Apellido"
            Me.dgvLIBRRADI_3.Columns("USUASEAP1").HeaderText = "Segundo Apellido"

            Me.dgvLIBRRADI_1.Columns("LIRAIDRE").Visible = False
            Me.dgvLIBRRADI_1.Columns("LIRASECU").Visible = False
            Me.dgvLIBRRADI_1.Columns("LIRAESTA").Visible = False
            Me.dgvLIBRRADI_1.Columns("LIRAASUN").Visible = False
            Me.dgvLIBRRADI_1.Columns("LIRAOBSE").Visible = False
            Me.dgvLIBRRADI_1.Columns("LIRADTFR").Visible = False
            Me.dgvLIBRRADI_1.Columns("LRDFDTFA").Visible = False
            Me.dgvLIBRRADI_1.Columns("LIRAUSUA").Visible = False
            Me.dgvLIBRRADI_1.Columns("LIRANUDO").Visible = False
            Me.dgvLIBRRADI_1.Columns("USUANOMB").Visible = False
            Me.dgvLIBRRADI_1.Columns("USUAPRAP").Visible = False
            Me.dgvLIBRRADI_1.Columns("USUASEAP").Visible = False
            Me.dgvLIBRRADI_1.Columns("LRDFUSUA").Visible = False
            Me.dgvLIBRRADI_1.Columns("LRDFNUDO").Visible = False
            Me.dgvLIBRRADI_1.Columns("USUANOMB1").Visible = False
            Me.dgvLIBRRADI_1.Columns("USUAPRAP1").Visible = False
            Me.dgvLIBRRADI_1.Columns("USUASEAP1").Visible = False
            Me.dgvLIBRRADI_1.Columns("LIRAFEAS").Visible = False

            Me.dgvLIBRRADI_2.Columns("LIRAIDRE").Visible = False
            Me.dgvLIBRRADI_2.Columns("LIRASECU").Visible = False
            Me.dgvLIBRRADI_2.Columns("LIRAESTA").Visible = False
            Me.dgvLIBRRADI_2.Columns("LIRAASUN").Visible = False
            Me.dgvLIBRRADI_2.Columns("LIRAOBSE").Visible = False
            Me.dgvLIBRRADI_2.Columns("LIRADTFR").Visible = False
            Me.dgvLIBRRADI_2.Columns("LRDFDTFA").Visible = False
            Me.dgvLIBRRADI_2.Columns("LIRANURA").Visible = False
            Me.dgvLIBRRADI_2.Columns("LIRAFERA").Visible = False
            Me.dgvLIBRRADI_2.Columns("LIRAFEIN").Visible = False
            Me.dgvLIBRRADI_2.Columns("LIRAFEFI").Visible = False
            Me.dgvLIBRRADI_2.Columns("LRDFFEAS").Visible = False
            Me.dgvLIBRRADI_2.Columns("LIRAVIGE").Visible = False
            Me.dgvLIBRRADI_2.Columns("ESTADESC").Visible = False
            Me.dgvLIBRRADI_2.Columns("LRDFUSUA").Visible = False
            Me.dgvLIBRRADI_2.Columns("LRDFNUDO").Visible = False
            Me.dgvLIBRRADI_2.Columns("USUANOMB1").Visible = False
            Me.dgvLIBRRADI_2.Columns("USUAPRAP1").Visible = False
            Me.dgvLIBRRADI_2.Columns("USUASEAP1").Visible = False
            Me.dgvLIBRRADI_2.Columns("LIRAFEAS").Visible = False

            Me.dgvLIBRRADI_3.Columns("LIRAIDRE").Visible = False
            Me.dgvLIBRRADI_3.Columns("LIRASECU").Visible = False
            Me.dgvLIBRRADI_3.Columns("LIRAESTA").Visible = False
            Me.dgvLIBRRADI_3.Columns("LIRAASUN").Visible = False
            Me.dgvLIBRRADI_3.Columns("LIRAOBSE").Visible = False
            Me.dgvLIBRRADI_3.Columns("LIRADTFR").Visible = False
            Me.dgvLIBRRADI_3.Columns("LRDFDTFA").Visible = False
            Me.dgvLIBRRADI_3.Columns("LIRANURA").Visible = False
            Me.dgvLIBRRADI_3.Columns("LIRAFERA").Visible = False
            Me.dgvLIBRRADI_3.Columns("LIRAFEIN").Visible = False
            Me.dgvLIBRRADI_3.Columns("LRDFFEAS").Visible = False
            Me.dgvLIBRRADI_3.Columns("LIRAFEFI").Visible = False
            Me.dgvLIBRRADI_3.Columns("LIRAVIGE").Visible = False
            Me.dgvLIBRRADI_3.Columns("ESTADESC").Visible = False
            Me.dgvLIBRRADI_3.Columns("LIRAUSUA").Visible = False
            Me.dgvLIBRRADI_3.Columns("LIRANUDO").Visible = False
            Me.dgvLIBRRADI_3.Columns("USUANOMB").Visible = False
            Me.dgvLIBRRADI_3.Columns("USUAPRAP").Visible = False
            Me.dgvLIBRRADI_3.Columns("USUASEAP").Visible = False
            Me.dgvLIBRRADI_3.Columns("LIRAFEAS").Visible = False

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub pro_ListaDeValoresLibroRadicador()

        Try
            If Me.dgvLIBRRADI_1.RowCount > 0 Then

                Me.txtRECLOBSE.Text = Trim(Me.dgvLIBRRADI_1.SelectedRows.Item(0).Cells("LIRAOBSE").Value.ToString)

                Me.txtLIRATRPE.Text = fun_ContarTramitesPendientes()
                Me.txtLIRATRFI.Text = fun_ContarTramitesFinalizados()

                pro_EstadisticaLibroRadicadorPorDestinatario()

            Else
                pro_LimpiarCamposLibroRadicador()

            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub pro_EstadisticaLibroRadicadorPorDestinatario()

        Try
            ' conteo de dias calendario
            Dim inCantidadDiasCalendarioFechaRadicado As Integer = CInt(Trim(Me.dgvLIBRRADI_3.SelectedRows.Item(0).Cells("LIRADTFR").Value.ToString))
            Dim inCantidadDiasCalendarioFechaAsignacionFuncionario As Integer = CInt(Trim(Me.dgvLIBRRADI_3.SelectedRows.Item(0).Cells("LRDFDTFA").Value.ToString))

            If (inCantidadDiasCalendarioFechaRadicado >= 0 And inCantidadDiasCalendarioFechaRadicado <= 10) Then
                Me.txtLIRAFERA_1.BackColor = Color.GreenYellow
                Me.txtLIRAFERA_1.Text = inCantidadDiasCalendarioFechaRadicado

            ElseIf (inCantidadDiasCalendarioFechaRadicado >= 11 And inCantidadDiasCalendarioFechaRadicado <= 21) Then
                Me.txtLIRAFERA_1.BackColor = Color.Yellow
                Me.txtLIRAFERA_1.Text = inCantidadDiasCalendarioFechaRadicado

            ElseIf (inCantidadDiasCalendarioFechaRadicado >= 22) Then
                Me.txtLIRAFERA_1.BackColor = Color.Tomato
                Me.txtLIRAFERA_1.Text = inCantidadDiasCalendarioFechaRadicado

            End If

            If (inCantidadDiasCalendarioFechaAsignacionFuncionario >= 0 And inCantidadDiasCalendarioFechaAsignacionFuncionario <= 10) Then
                Me.txtLRDFFEAS_1.BackColor = Color.GreenYellow
                Me.txtLRDFFEAS_1.Text = inCantidadDiasCalendarioFechaAsignacionFuncionario

            ElseIf (inCantidadDiasCalendarioFechaAsignacionFuncionario >= 11 And inCantidadDiasCalendarioFechaAsignacionFuncionario <= 21) Then
                Me.txtLRDFFEAS_1.BackColor = Color.Yellow
                Me.txtLRDFFEAS_1.Text = inCantidadDiasCalendarioFechaAsignacionFuncionario

            ElseIf (inCantidadDiasCalendarioFechaAsignacionFuncionario >= 22) Then
                Me.txtLRDFFEAS_1.BackColor = Color.Tomato
                Me.txtLRDFFEAS_1.Text = inCantidadDiasCalendarioFechaAsignacionFuncionario

            End If


            ' conteo de dias habiles
            Dim inCantidadDiasHabilesFechaRadicado As Integer = fun_ContarDiasHabiles(inCantidadDiasCalendarioFechaRadicado)
            Dim inCantidadDiasHabilesFechaAsignacionFuncionario As Integer = fun_ContarDiasHabiles(inCantidadDiasCalendarioFechaAsignacionFuncionario)

            If (inCantidadDiasHabilesFechaRadicado >= 0 And inCantidadDiasHabilesFechaRadicado <= 7) Then
                Me.txtLIRAFERA_2.BackColor = Color.GreenYellow
                Me.txtLIRAFERA_2.Text = inCantidadDiasHabilesFechaRadicado

            ElseIf (inCantidadDiasHabilesFechaRadicado >= 8 And inCantidadDiasHabilesFechaRadicado <= 15) Then
                Me.txtLIRAFERA_2.BackColor = Color.Yellow
                Me.txtLIRAFERA_2.Text = inCantidadDiasHabilesFechaRadicado

            ElseIf (inCantidadDiasHabilesFechaRadicado >= 16) Then
                Me.txtLIRAFERA_2.BackColor = Color.Tomato
                Me.txtLIRAFERA_2.Text = inCantidadDiasHabilesFechaRadicado

            End If

            If (inCantidadDiasHabilesFechaAsignacionFuncionario >= 0 And inCantidadDiasHabilesFechaAsignacionFuncionario <= 7) Then
                Me.txtLRDFFEAS_2.BackColor = Color.GreenYellow
                Me.txtLRDFFEAS_2.Text = inCantidadDiasHabilesFechaAsignacionFuncionario

            ElseIf (inCantidadDiasHabilesFechaAsignacionFuncionario >= 8 And inCantidadDiasHabilesFechaAsignacionFuncionario <= 15) Then
                Me.txtLRDFFEAS_2.BackColor = Color.Yellow
                Me.txtLRDFFEAS_2.Text = inCantidadDiasHabilesFechaAsignacionFuncionario

            ElseIf (inCantidadDiasHabilesFechaAsignacionFuncionario >= 16) Then
                Me.txtLRDFFEAS_2.BackColor = Color.Tomato
                Me.txtLRDFFEAS_2.Text = inCantidadDiasHabilesFechaAsignacionFuncionario

            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub pro_LlenarListadoPorUsuarioLibroRadicador()

        Try
            ' instancia la clase
            Dim obLIBRRADI As New cla_LIBRRADI
            Dim dtLIBRRADI As New DataTable

            dtLIBRRADI = obLIBRRADI.fun_Consultar_Cantidad_de_Usuario_LIBRRADI

            If dtLIBRRADI.Rows.Count > 0 Then

                ' Crea objeto registros
                Dim dr1 As DataRow

                ' crea la tabla
                Dim dt_CargaDatos As New DataTable

                dt_CargaDatos.Columns.Add(New DataColumn("Usuario", GetType(String)))
                dt_CargaDatos.Columns.Add(New DataColumn("Pendientes", GetType(String)))
                dt_CargaDatos.Columns.Add(New DataColumn("Rango_1", GetType(String)))
                dt_CargaDatos.Columns.Add(New DataColumn("Rango_2", GetType(String)))
                dt_CargaDatos.Columns.Add(New DataColumn("Rango_3", GetType(String)))
                dt_CargaDatos.Columns.Add(New DataColumn("Finalizados", GetType(String)))

                ' declara la variable
                Dim inCantidadRiesgoBajo As Integer = 0
                Dim inCantidadRiesgoMedio As Integer = 0
                Dim inCantidadRiesgoAlto As Integer = 0

                Dim i As Integer = 0

                For i = 0 To dtLIBRRADI.Rows.Count - 1

                    dr1 = dt_CargaDatos.NewRow()

                    dr1("Usuario") = CStr(dtLIBRRADI.Rows(i).Item("Usuario").ToString)
                    dr1("Pendientes") = CStr(fun_ContarTramitesPorEstadoPorusuario(CStr(dtLIBRRADI.Rows(i).Item("Usuario").ToString), "pe"))
                    dr1("Rango_1") = fun_ContarTramitesRiesgoBajoPorFuncionario(CStr(dtLIBRRADI.Rows(i).Item("Usuario").ToString))
                    dr1("Rango_2") = fun_ContarTramitesRiesgoMedioPorFuncionario(CStr(dtLIBRRADI.Rows(i).Item("Usuario").ToString))
                    dr1("Rango_3") = fun_ContarTramitesRiesgoAltoPorFuncionario(CStr(dtLIBRRADI.Rows(i).Item("Usuario").ToString))
                    dr1("Finalizados") = CStr(fun_ContarTramitesPorEstadoPorusuario(CStr(dtLIBRRADI.Rows(i).Item("Usuario").ToString), "fi"))

                    dt_CargaDatos.Rows.Add(dr1)

                Next


                Dim item As New ListViewItem
                Dim j As Integer

                Me.lsvMovimientosPorUsuarioRectificaciones.Items.Clear()

                For j = 0 To dt_CargaDatos.Rows.Count - 1

                    item = lsvMovimientosPorUsuarioRectificaciones.Items.Add(dt_CargaDatos.Rows(j).Item("Usuario"))
                    item.SubItems.Add(dt_CargaDatos.Rows(j).Item("Pendientes"))
                    item.SubItems.Add(dt_CargaDatos.Rows(j).Item("Rango_1"))
                    item.SubItems.Add(dt_CargaDatos.Rows(j).Item("Rango_2"))
                    item.SubItems.Add(dt_CargaDatos.Rows(j).Item("Rango_3"))
                    item.SubItems.Add(dt_CargaDatos.Rows(j).Item("Finalizados"))

                Next

            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub pro_LlenarListadoPorVigenciaLibroRadicador()

        Try
            ' instancia la clase
            Dim obLIBRRADI As New cla_LIBRRADI
            Dim dtLIBRRADI As New DataTable

            dtLIBRRADI = obLIBRRADI.fun_Consultar_Cantidad_x_Vigencia_LIBRRADI

            If dtLIBRRADI.Rows.Count > 0 Then

                ' Crea objeto registros
                Dim dr1 As DataRow

                ' crea la tabla
                Dim dt_CargaDatos As New DataTable

                dt_CargaDatos.Columns.Add(New DataColumn("Vigencia", GetType(String)))
                dt_CargaDatos.Columns.Add(New DataColumn("Cantidad", GetType(String)))
                dt_CargaDatos.Columns.Add(New DataColumn("Rango_1", GetType(String)))
                dt_CargaDatos.Columns.Add(New DataColumn("Rango_2", GetType(String)))
                dt_CargaDatos.Columns.Add(New DataColumn("Rango_3", GetType(String)))

                ' declara la variable
                Dim inCantidadPendientes As Integer = 0
                Dim inCantidadFinalizados As Integer = 0
                Dim inCantidadCancelados As Integer = 0

                Dim i As Integer = 0

                For i = 0 To dtLIBRRADI.Rows.Count - 1

                    dr1 = dt_CargaDatos.NewRow()

                    dr1("Vigencia") = CStr(dtLIBRRADI.Rows(i).Item("Vigencia").ToString)
                    dr1("Cantidad") = CStr(dtLIBRRADI.Rows(i).Item("Cantidad").ToString)
                    dr1("Rango_1") = fun_ContarTramitesPorVigenciaPorFuncionario(CInt(dtLIBRRADI.Rows(i).Item("Vigencia").ToString), "ej")
                    dr1("Rango_2") = fun_ContarTramitesPorVigenciaPorFuncionario(CInt(dtLIBRRADI.Rows(i).Item("Vigencia").ToString), "fi")
                    dr1("Rango_3") = fun_ContarTramitesPorVigenciaPorFuncionario(CInt(dtLIBRRADI.Rows(i).Item("Vigencia").ToString), "ca")

                    dt_CargaDatos.Rows.Add(dr1)

                Next


                Dim item As New ListViewItem
                Dim j As Integer

                Me.lsvMovimientosPorVigenciaRectificaciones.Items.Clear()

                For j = 0 To dt_CargaDatos.Rows.Count - 1

                    item = lsvMovimientosPorVigenciaRectificaciones.Items.Add(dt_CargaDatos.Rows(j).Item("Vigencia"))
                    item.SubItems.Add(dt_CargaDatos.Rows(j).Item("Rango_1"))
                    item.SubItems.Add(dt_CargaDatos.Rows(j).Item("Rango_2"))
                    item.SubItems.Add(dt_CargaDatos.Rows(j).Item("Rango_3"))
                    item.SubItems.Add(dt_CargaDatos.Rows(j).Item("Cantidad"))

                Next

            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub pro_LimpiarCamposLibroRadicador()

        Me.txtLIRATRPE.Text = ""
        Me.txtRECLOBSE.Text = ""
        Me.txtLIRATRFI.Text = ""

        Me.txtLRDFFEAS_1.BackColor = Color.White
        Me.txtLIRAFERA_1.BackColor = Color.White

        Me.strBARRESTA.Items(2).Text = "Registros : 0"

    End Sub

#End Region

#Region "MENU LIBRO RADICADOR"

    Private Sub cmdRECONSULTAR_LIBRRADI_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdRECONSULTAR_LIBRRADI.Click
        boCONSULTA_LIBRRADI = False
        pro_ReconsultarLibroRadicador()
        pro_ListaDeValoresLibroRadicador()
    End Sub
    Private Sub cmdCONSULTAR_LIBRRADI_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCONSULTAR_LIBRRADI.Click

        Try
            vp_cedula = ""
            vp_stEstado = ""

            frm_consultar_BITARADI.ShowDialog()

            If vp_cedula <> "" And vp_stEstado <> "" Then
                boCONSULTA_LIBRRADI = True
            Else
                boCONSULTA_LIBRRADI = False
            End If

            pro_ReconsultarLibroRadicador()
            pro_ListaDeValoresLibroRadicador()

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub cmdSALIR_LIBRRADI_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSALIR_RECTIFICACIONES.Click
        Me.Close()
    End Sub

#End Region

#Region "FORMULARIO"

#Region "Load"

    Private Sub frm_BITARADI_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        boCONSULTA_LIBRRADI = True

        pro_ReconsultarLibroRadicador()
        Me.strBARRESTA.Items(0).Text = "Bitácora de radicados"
    End Sub

#End Region

#Region "GotFocus"

    Private Sub frm_BITAMOVI_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.GotFocus
        pro_ListaDeValoresLibroRadicador()
        Me.dgvLIBRRADI_1.Focus()
    End Sub

#End Region

#Region "LostFocus"

    Private Sub frm_BITAMOVI_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.LostFocus
        Me.dgvLIBRRADI_1.Focus()
    End Sub

#End Region

#Region "KeyUp"

    Private Sub dgvRECTIFICACIONES_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgvLIBRRADI_1.KeyUp, dgvLIBRRADI_2.KeyUp, dgvLIBRRADI_3.KeyUp
        If e.KeyCode = Keys.Down Or e.KeyCode = Keys.Up Or e.KeyCode = Keys.Enter Or e.KeyCode = Keys.PageUp Or e.KeyCode = Keys.PageDown Then
            pro_ListaDeValoresLibroRadicador()
        End If
    End Sub

#End Region

#Region "CellClick"

    Private Sub dgvRECTIFICACIONES_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvLIBRRADI_1.CellClick, dgvLIBRRADI_2.CellClick, dgvLIBRRADI_3.CellClick
        pro_ListaDeValoresLibroRadicador()
    End Sub

#End Region

#End Region

End Class