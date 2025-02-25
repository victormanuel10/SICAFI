Imports REGLAS_DEL_NEGOCIO
Imports System
Imports System.IO
Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration
Imports System.Text

Public Class frm_bitacora_pendientes_inactivar_RESOCONS

    '=============================================
    '*** RESOLUCIONES PENDIENTES POR INACTIVAR ***
    '=============================================

#Region "VARIABLES"

    Private boCONSULTA_BITACORA As Boolean = False
    Dim inID_REGISTRO As Integer = 0
    Dim vl_inBITAIDRE As Integer = 0

    Private oEjecutar As New SqlCommand
    Private oConexion As New SqlConnection
    Private oAdapter As New SqlDataAdapter
    Private oReader As SqlDataReader
    Private ds As New DataSet
    Private dt As New DataTable

#End Region

#Region "CONSTRUCTOR"

    Public Sub New()
        InitializeComponent()
    End Sub
    Public Sub New(ByVal inInRegistro As Integer)
        inID_REGISTRO = inInRegistro

        InitializeComponent()
    End Sub

#End Region

#Region "FUNCIONES"

    Private Function fun_ContarDiasHabiles(ByVal inDiasCalendario As Integer) As Integer

        Try
            Dim inDiasHabiles As Integer = inDiasCalendario * (5 / 7)

            Return inDiasHabiles

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Function
    Private Function fun_ContarTramitesActivos() As Integer

        Try
            Dim inCantidad As Integer = 0

            If Me.dgvRESOCONS.RowCount > 0 Then
                inCantidad = Me.dgvRESOCONS.RowCount
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
            Dim obRESOCONS As New cla_RESOCONS
            Dim dtRESOCONS As New DataTable

            dtRESOCONS = obRESOCONS.fun_Consultar_RESOCONS_X_ESTADO(Trim("fi"))

            If dtRESOCONS.Rows.Count > 0 Then
                inCantidad = dtRESOCONS.Rows.Count
            End If

            Return inCantidad

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Function
    Private Function fun_ContarTramitesPorEstadoPorusuario(ByVal stRECOUSFI As String, ByVal stRECOESTA As String) As Integer

        Try
            ' declara la variables
            Dim inCantidad As Integer = 0

            ' instancia la clase
            Dim obRESOCONS As New cla_RESOCONS
            Dim dtRESOCONS As New DataTable

            dtRESOCONS = obRESOCONS.fun_Consultar_Cantidad_de_Usuario_x_Estado_RESOCONS(CStr(Trim(stRECOUSFI)), CStr(Trim(stRECOESTA)))

            If dtRESOCONS.Rows.Count > 0 Then
                inCantidad = CInt(dtRESOCONS.Rows(0).Item("Cantidad"))
            End If

            Return inCantidad

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Function

#End Region

#Region "PROCEDIMIENTOS"

    Private Sub pro_ReconsultarResolucionDeConservacion()

        Try
            Dim objdatos As New cla_RESOCONS

            If boCONSULTA_BITACORA = False Then
                Me.BindingSource_RESOCONS_1.DataSource = objdatos.fun_Consultar_RESOCONS_X_BITACORA("ac", True)

            ElseIf boCONSULTA_BITACORA = True Then
                Me.BindingSource_RESOCONS_1.DataSource = objdatos.fun_Consultar_RESOCONS_X_BITACORA(vl_inBITAIDRE)

            End If

            Me.dgvRESOCONS.DataSource = BindingSource_RESOCONS_1
            Me.BindingNavigator_RESOCONS_1.BindingSource = BindingSource_RESOCONS_1

            '=================================================
            '*** CONFIGURA OBJETOS DEL FORMULARIO MAESTRO ***
            '=================================================
            Me.strBARRESTA.Items(2).Text = "Registros : " & Me.BindingSource_RESOCONS_1.Count

            Me.dgvRESOCONS.Columns("RECONURE").HeaderText = "Nro. Resolucion"
            Me.dgvRESOCONS.Columns("RECOFERE").HeaderText = "Fecha de Resolucion"
            Me.dgvRESOCONS.Columns("RECOFEES").HeaderText = "Fecha de Escritura"
            Me.dgvRESOCONS.Columns("RECOVIFI").HeaderText = "Vigencia Fiscal"
            Me.dgvRESOCONS.Columns("RECOFEIN").HeaderText = "Fecha de Ingreso"
            Me.dgvRESOCONS.Columns("RECOFERE_1").HeaderText = "Días - Fecha Resolución"
            Me.dgvRESOCONS.Columns("RECOFEIN_1").HeaderText = "Días - Fecha Asignación"
            Me.dgvRESOCONS.Columns("RECOUNID").HeaderText = "Nro. Unidades"
            Me.dgvRESOCONS.Columns("RECOAJPR").HeaderText = "Ajuste Imp. Predial"
            Me.dgvRESOCONS.Columns("RECOAJVA").HeaderText = "Ajuste Valorización"
            Me.dgvRESOCONS.Columns("ESTADESC").HeaderText = "Estado"

            Me.dgvRESOCONS.Columns("RECOIDRE").Visible = False
            Me.dgvRESOCONS.Columns("RECOSECU").Visible = False
            Me.dgvRESOCONS.Columns("RECOESTA").Visible = False
            Me.dgvRESOCONS.Columns("RECOOBSE").Visible = False

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub pro_ListaDeValoresResolucionConservacion()

        Try
            If Me.dgvRESOCONS.RowCount > 0 Then

                Me.txtRECOOBSE.Text = Trim(Me.dgvRESOCONS.SelectedRows.Item(0).Cells("RECOOBSE").Value.ToString)

                Me.txtRECOREAC.Text = fun_ContarTramitesActivos()
                Me.txtRECOREFI.Text = fun_ContarTramitesFinalizados()

                pro_EstadisticaResolucionDeConservacionPorDestinatario()

                Me.cmdAceptar.Enabled = True

            Else
                pro_LimpiarCamposLibroRadicador()

            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub pro_EstadisticaResolucionDeConservacionPorDestinatario()

        Try
            ' conteo de dias calendario
            Dim inCantidadDiasCalendarioFechaDeResolucion As Integer = CInt(Trim(Me.dgvRESOCONS.SelectedRows.Item(0).Cells("RECOFERE_1").Value.ToString))
            Dim inCantidadDiasCalendarioFechaDeIngreso As Integer = CInt(Trim(Me.dgvRESOCONS.SelectedRows.Item(0).Cells("RECOFEIN_1").Value.ToString))

            If (inCantidadDiasCalendarioFechaDeResolucion >= 0 And inCantidadDiasCalendarioFechaDeResolucion <= 10) Then
                Me.txtRECOFERE_1.BackColor = Color.GreenYellow
                Me.txtRECOFERE_1.Text = inCantidadDiasCalendarioFechaDeResolucion

            ElseIf (inCantidadDiasCalendarioFechaDeResolucion >= 11 And inCantidadDiasCalendarioFechaDeResolucion <= 21) Then
                Me.txtRECOFERE_1.BackColor = Color.Yellow
                Me.txtRECOFERE_1.Text = inCantidadDiasCalendarioFechaDeResolucion

            ElseIf (inCantidadDiasCalendarioFechaDeResolucion >= 22) Then
                Me.txtRECOFERE_1.BackColor = Color.Tomato
                Me.txtRECOFERE_1.Text = inCantidadDiasCalendarioFechaDeResolucion

            End If

            If (inCantidadDiasCalendarioFechaDeIngreso >= 0 And inCantidadDiasCalendarioFechaDeIngreso <= 10) Then
                Me.txtRECOFEIN_1.BackColor = Color.GreenYellow
                Me.txtRECOFEIN_1.Text = inCantidadDiasCalendarioFechaDeIngreso

            ElseIf (inCantidadDiasCalendarioFechaDeIngreso >= 11 And inCantidadDiasCalendarioFechaDeIngreso <= 21) Then
                Me.txtRECOFEIN_1.BackColor = Color.Yellow
                Me.txtRECOFEIN_1.Text = inCantidadDiasCalendarioFechaDeIngreso

            ElseIf (inCantidadDiasCalendarioFechaDeIngreso >= 22) Then
                Me.txtRECOFEIN_1.BackColor = Color.Tomato
                Me.txtRECOFEIN_1.Text = inCantidadDiasCalendarioFechaDeIngreso

            End If


            ' conteo de dias habiles
            Dim inCantidadDiasHabilesFechaDeResolucion As Integer = fun_ContarDiasHabiles(inCantidadDiasCalendarioFechaDeResolucion)
            Dim inCantidadDiasHabilesFechaDeIngreso As Integer = fun_ContarDiasHabiles(inCantidadDiasCalendarioFechaDeIngreso)

            If (inCantidadDiasHabilesFechaDeResolucion >= 0 And inCantidadDiasHabilesFechaDeResolucion <= 7) Then
                Me.txtRECOFERE_2.BackColor = Color.GreenYellow
                Me.txtRECOFERE_2.Text = inCantidadDiasHabilesFechaDeResolucion

            ElseIf (inCantidadDiasHabilesFechaDeResolucion >= 8 And inCantidadDiasHabilesFechaDeResolucion <= 15) Then
                Me.txtRECOFERE_2.BackColor = Color.Yellow
                Me.txtRECOFERE_2.Text = inCantidadDiasHabilesFechaDeResolucion

            ElseIf (inCantidadDiasHabilesFechaDeResolucion >= 16) Then
                Me.txtRECOFERE_2.BackColor = Color.Tomato
                Me.txtRECOFERE_2.Text = inCantidadDiasHabilesFechaDeResolucion

            End If

            If (inCantidadDiasHabilesFechaDeIngreso >= 0 And inCantidadDiasHabilesFechaDeIngreso <= 7) Then
                Me.txtRECOFEIN_2.BackColor = Color.GreenYellow
                Me.txtRECOFEIN_2.Text = inCantidadDiasHabilesFechaDeIngreso

            ElseIf (inCantidadDiasHabilesFechaDeIngreso >= 8 And inCantidadDiasHabilesFechaDeIngreso <= 15) Then
                Me.txtRECOFEIN_2.BackColor = Color.Yellow
                Me.txtRECOFEIN_2.Text = inCantidadDiasHabilesFechaDeIngreso

            ElseIf (inCantidadDiasHabilesFechaDeIngreso >= 16) Then
                Me.txtRECOFEIN_2.BackColor = Color.Tomato
                Me.txtRECOFEIN_2.Text = inCantidadDiasHabilesFechaDeIngreso

            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub pro_LimpiarCamposLibroRadicador()

        Me.txtRECOREAC.Text = ""
        Me.txtRECOREFI.Text = ""
        Me.txtRECOOBSE.Text = ""
        Me.txtRECOFERE_1.Text = ""
        Me.txtRECOFEIN_1.Text = ""
        Me.txtRECOFERE_2.Text = ""
        Me.txtRECOFEIN_2.Text = ""
        Me.txtRECOFEIN_1.BackColor = Color.White
        Me.txtRECOFERE_1.BackColor = Color.White
        Me.txtRECOFEIN_2.BackColor = Color.White
        Me.txtRECOFERE_2.BackColor = Color.White

        Me.cmdAceptar.Enabled = False

        Me.strBARRESTA.Items(2).Text = "Registros : 0"

    End Sub
    Private Sub pro_EjecutarBotonFinalizar()

        Try
            If MessageBox.Show("¿ Desea finalizar la resolución Nro. " & Me.dgvRESOCONS.SelectedRows.Item(0).Cells("RECONURE").Value.ToString() & " ? ", "Mensaje...", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then

                Dim stRECLOBSE_ACTUAL As String = ""
                Dim stRECLOBSE_NUEVA As String = " Nota de registro: " & " El usuario: " & vp_usuario & " " & fun_fecha() & " finalizo el tramite. "

                Dim obRECLGEOG As New cla_RESOCONS
                Dim dtRECLGEOG As New DataTable

                dtRECLGEOG = obRECLGEOG.fun_Buscar_ID_RESOCONS(Me.dgvRESOCONS.SelectedRows.Item(0).Cells("RECOIDRE").Value.ToString())

                If dtRECLGEOG.Rows.Count > 0 Then
                    stRECLOBSE_ACTUAL = Trim(dtRECLGEOG.Rows(0).Item("RECOOBSE").ToString)
                End If

                If Trim(stRECLOBSE_ACTUAL) <> "" And Trim(stRECLOBSE_NUEVA) <> "" Then
                    stRECLOBSE_ACTUAL += vbCrLf & stRECLOBSE_NUEVA & ". "

                ElseIf Trim(stRECLOBSE_ACTUAL) = "" And Trim(stRECLOBSE_NUEVA) <> "" Then
                    stRECLOBSE_ACTUAL = stRECLOBSE_NUEVA & ". "

                End If

                ' buscar cadena de conexion
                Dim oCadenaConexion As New REGLAS_DEL_NEGOCIO.cla_ConnectionString
                Dim stCadenaConexion As String = oCadenaConexion.fun_ConnectionString

                ' crear conexión
                oAdapter = New SqlDataAdapter
                oConexion = New SqlConnection(stCadenaConexion)

                ' abre la conexion
                oConexion.Open()

                ' variables
                Dim inMOGEIDRE As Integer = Integer.Parse(Me.dgvRESOCONS.SelectedRows.Item(0).Cells("RECOIDRE").Value.ToString())
                Dim stMOGEESTA As String = "fi"

                Dim stLIRAFEFI As String = Trim(fun_fecha())

                ' parametros de la consulta
                Dim ParametrosConsulta As String = ""

                ' Concatena la condicion de la consulta
                ParametrosConsulta += "Update RESOCONS "
                ParametrosConsulta += "Set RECOESTA = '" & stMOGEESTA & "', "
                ParametrosConsulta += "RECOFEFI = '" & stLIRAFEFI & "', "
                ParametrosConsulta += "RECOUSFI = '" & vp_usuario & "', "
                ParametrosConsulta += "RECONDFI = '" & vp_cedula & "', "
                ParametrosConsulta += "RECOOBSE = '" & stRECLOBSE_ACTUAL & "' "
                ParametrosConsulta += "where RECOIDRE = '" & inMOGEIDRE & "' "

                ' ejecuta la consulta
                oEjecutar = New SqlCommand(ParametrosConsulta, oConexion)

                ' procesa la consulta 
                oEjecutar.CommandTimeout = 0
                oEjecutar.CommandType = CommandType.Text

                oReader = oEjecutar.ExecuteReader

                Dim ii As Integer = oReader.RecordsAffected

                ' cierra la conexion
                oConexion.Close()
                oReader = Nothing

                mod_MENSAJE.Se_Modificaron_Los_Datos_Correctamente()

            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub pro_EjecutarBotonObservaciones()

        Try
            If Me.dgvRESOCONS.RowCount > 0 Then

                If MessageBox.Show("¿ Desea ingresar una observación ? ", "Mensaje...", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then

                    Dim stObservacionNueva As String = InputBox("Ingrese la observación.", "Mensaje")

                    If Trim(stObservacionNueva) = "" Then
                        MessageBox.Show("Se requiere una observación.", "Mensaje...", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                        mod_MENSAJE.No_Se_Modifico_El_Registro_En_La_Base_De_Datos()
                    Else

                        Dim stREMUOBSE_ACTUAL As String = ""
                        Dim stREMUOBSE_NUEVA As String = Trim(stObservacionNueva.ToString.ToUpper)

                        Dim obMOGEGEOG As New cla_RESOCONS
                        Dim dtAJUSGEOG As New DataTable

                        dtAJUSGEOG = obMOGEGEOG.fun_Buscar_ID_RESOCONS(Me.dgvRESOCONS.SelectedRows.Item(0).Cells("RECOIDRE").Value.ToString())

                        If dtAJUSGEOG.Rows.Count > 0 Then
                            stREMUOBSE_ACTUAL = Trim(dtAJUSGEOG.Rows(0).Item("RECOOBSE").ToString)
                        End If

                        If Trim(stREMUOBSE_ACTUAL) <> "" And Trim(stREMUOBSE_NUEVA) <> "" Then
                            stREMUOBSE_ACTUAL += vbCrLf & " Nota ingresada por " & vp_usuario & " " & fun_fecha() & " : " & stREMUOBSE_NUEVA & ". "

                        ElseIf Trim(stREMUOBSE_ACTUAL) = "" And Trim(stREMUOBSE_NUEVA) <> "" Then
                            stREMUOBSE_ACTUAL = " Nota ingresada por " & vp_usuario & " " & fun_fecha() & " : " & stREMUOBSE_NUEVA & ". "

                        End If

                        ' buscar cadena de conexion
                        Dim oCadenaConexion As New REGLAS_DEL_NEGOCIO.cla_ConnectionString
                        Dim stCadenaConexion As String = oCadenaConexion.fun_ConnectionString

                        ' crear conexión
                        oAdapter = New SqlDataAdapter
                        oConexion = New SqlConnection(stCadenaConexion)

                        ' abre la conexion
                        oConexion.Open()

                        ' variables
                        Dim inMOGEIDRE As Integer = Integer.Parse(Me.dgvRESOCONS.SelectedRows.Item(0).Cells("RECOIDRE").Value.ToString())

                        ' parametros de la consulta
                        Dim ParametrosConsulta As String = ""

                        ' Concatena la condicion de la consulta
                        ParametrosConsulta += "update RESOCONS "
                        ParametrosConsulta += "set RECOOBSE = '" & stREMUOBSE_ACTUAL & "' "
                        ParametrosConsulta += "where RECOIDRE = '" & inMOGEIDRE & "' "

                        ' ejecuta la consulta
                        oEjecutar = New SqlCommand(ParametrosConsulta, oConexion)

                        ' procesa la consulta 
                        oEjecutar.CommandTimeout = 0
                        oEjecutar.CommandType = CommandType.Text

                        oReader = oEjecutar.ExecuteReader

                        Dim i As Integer = oReader.RecordsAffected

                        ' cierra la conexion
                        oConexion.Close()
                        oReader = Nothing

                        mod_MENSAJE.Se_Modificaron_Los_Datos_Correctamente()

                    End If

                End If
            Else
                mod_MENSAJE.No_Existe_Un_Registro_Seleccionado()
            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub

#End Region

#Region "MENU"

    Private Sub cmdAceptarLibroRadicador_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAceptar.Click

        If Me.dgvRESOCONS.RowCount = 0 Then
            MessageBox.Show("No existen registro seleccionados", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
        Else
            Dim inId_Reg As New frm_RESOCONS(Integer.Parse(Me.dgvRESOCONS.SelectedRows.Item(0).Cells(0).Value.ToString()))
            Me.Close()
        End If

    End Sub
    Private Sub cmdCONSULTAR_BITACORA_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCONSULTAR_BITACORA.Click

        Try
            Dim stNroResolucion As String = InputBox("Ingrese el Nro. Resolución.", "Mensaje ...")

            If Trim(stNroResolucion) = "" Then
                MessageBox.Show("No existe dato de busqueda.", "Mensaje ...", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1)
            Else
                If fun_Verificar_Dato_Numerico_Evento_Validated(Trim(stNroResolucion)) = False Then
                    MessageBox.Show("El dato no es numérico.", "Mensaje ...", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1)
                Else

                    ' instancia un dt
                    Dim dt As New DataTable

                    ' crea la variable de los campos
                    Dim stRECONURE As String = Trim(stNroResolucion)

                    ' carga los campos
                    If Trim(stRECONURE) = "" Then
                        stRECONURE = "%"
                    Else
                        stRECONURE = Trim(stRECONURE)
                    End If

                    ' crea la variable de consulta
                    Dim stConsultaSQL As String = ""

                    'concatena la consulta
                    stConsultaSQL += "Select "
                    stConsultaSQL += "RECOIDRE "

                    stConsultaSQL += "FROM "
                    stConsultaSQL += "RESOCONS "

                    stConsultaSQL += "WHERE "
                    stConsultaSQL += "RECONURE LIKE '" & stRECONURE & "' AND "
                    stConsultaSQL += "RECOESTA = 'ac' AND "
                    stConsultaSQL += "RECOAJLI = '1' "

                    stConsultaSQL += "ORDER BY "
                    stConsultaSQL += "RECONURE, RECOFERE "

                    ' instancia la clase y almacena la consulta
                    Dim oConsulta As New cla_Consulta_ConexionString

                    dt = oConsulta.fun_Consultar_ConexionString(stConsultaSQL)

                    If dt.Rows.Count > 0 Then

                        boCONSULTA_BITACORA = True
                        vl_inBITAIDRE = CInt(dt.Rows(0).Item(0))

                        pro_ReconsultarResolucionDeConservacion()
                        pro_ListaDeValoresResolucionConservacion()

                    Else
                        mod_MENSAJE.Consulta_No_Encontro_Registros()
                    End If

                End If

            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub cmdRECONSULTAR_BITACORA_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdRECONSULTAR_BITACORA.Click

        Try
            boCONSULTA_BITACORA = False
            pro_ReconsultarResolucionDeConservacion()
            pro_ListaDeValoresResolucionConservacion()

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub cmdSALIR_LIBRRADI_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSALIR_RESOCONS.Click
        Dim inNroIdRe As New frm_RESOCONS(inID_REGISTRO)
        Me.Close()
    End Sub
    Private Sub cmdFinalizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdFinalizar.Click

        If Me.dgvRESOCONS.RowCount > 0 Then
            pro_EjecutarBotonFinalizar()
            pro_EjecutarBotonObservaciones()
            pro_ReconsultarResolucionDeConservacion()
            pro_ListaDeValoresResolucionConservacion()
        Else
            mod_MENSAJE.No_Existe_Un_Registro_Seleccionado()
        End If

    End Sub

#End Region

#Region "FORMULARIO"

#Region "Load"

    Private Sub frm_BITARADI_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        pro_LimpiarCamposLibroRadicador()
        pro_ReconsultarResolucionDeConservacion()
        pro_ListaDeValoresResolucionConservacion()
        Me.strBARRESTA.Items(0).Text = "Bitácora"
    End Sub

#End Region

#Region "KeyUp"

    Private Sub dgvRECTIFICACIONES_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgvRESOCONS.KeyUp
        If e.KeyCode = Keys.Down Or e.KeyCode = Keys.Up Or e.KeyCode = Keys.Enter Or e.KeyCode = Keys.PageUp Or e.KeyCode = Keys.PageDown Then
            pro_ListaDeValoresResolucionConservacion()
        End If
    End Sub

#End Region

#Region "CellClick"

    Private Sub dgvRECTIFICACIONES_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvRESOCONS.CellClick
        pro_ListaDeValoresResolucionConservacion()
    End Sub

#End Region

#Region "CellDoubleClick"

    Private Sub dgvRESOCONS_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvRESOCONS.CellDoubleClick
        Me.cmdAceptar.PerformClick()
    End Sub

#End Region

#End Region

End Class