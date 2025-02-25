Imports REGLAS_DEL_NEGOCIO
Imports System
Imports System.IO
Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration
Imports System.Text

Public Class frm_BITAMOVI

    '===============================
    '*** BITACORA DE MOVIMIENTOS ***
    '===============================

#Region "VARIABLES"

    Private boCONSULTA_RECTIFICACIONES As Boolean = False
    Private boCONSULTA_REVIAVAL As Boolean = False

    Private oEjecutar As New SqlCommand
    Private oConexion As New SqlConnection
    Private oAdapter As New SqlDataAdapter
    Private oReader As SqlDataReader
    Private ds As New DataSet
    Private dt As New DataTable

#End Region

#Region "INSTANCIAR FORMULARIO"

    Private Shared frm_Instance = Nothing

    Public Shared Function instance() As frm_BITAMOVI
        If frm_Instance Is Nothing OrElse frm_Instance.isdisposed = True Then
            frm_Instance = New frm_BITAMOVI
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

#End Region

#Region "FUNCIONES RECTIFICACIONES"

    Private Function fun_ContarTramitesPendienteRectificaciones() As Integer

        Try
            Dim inCantidad As Integer = 0

            If Me.dgvRECTIFICACIONES_1.RowCount > 0 Then
                inCantidad = Me.dgvRECTIFICACIONES_1.RowCount
            End If

            Return inCantidad

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Function
    Private Function fun_ContarTramitesSinRadicadoOVCRectificaciones() As Integer

        Try
            Dim inCantidad As Integer = 0

            Dim objdatos As New cla_RECLAMOS
            Dim tbldatos As New DataTable

            If boCONSULTA_RECTIFICACIONES = False Then
                tbldatos = objdatos.fun_Consultar_RECLAMOS_X_BITACORA
            Else
                tbldatos = objdatos.fun_Consultar_RECLAMOS_X_BITACORA(CStr(Trim(vp_cedula)))
            End If

            If tbldatos.Rows.Count > 0 Then

                Dim i As Integer = 0

                For i = 0 To tbldatos.Rows.Count - 1

                    If CInt(tbldatos.Rows(i).Item("RECLRAED").ToString) = 0 Then
                        inCantidad += 1
                    End If

                Next

            End If

            Return inCantidad

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Function
    Private Function fun_ContarTramitesRiesgoBajoRectificaciones(ByVal stUsuario As String) As Integer

        Try
            Dim inCantidad As Integer = 0

            Dim obRECLAMOS As New cla_RECLAMOS
            Dim dtRECLAMOS As New DataTable

            dtRECLAMOS = obRECLAMOS.fun_Consultar_Cantidad_x_Usuario_RECLAMOS(CStr(Trim(stUsuario)))

            If dtRECLAMOS.Rows.Count > 0 Then

                Dim i As Integer = 0

                For i = 0 To dtRECLAMOS.Rows.Count - 1

                    Dim inValor As Integer = CInt(dtRECLAMOS.Rows(i).Item("Cantidad").ToString)

                    If (inValor >= 0 And inValor <= 15) Then

                        inCantidad += 1

                    End If

                Next

            End If

            Return inCantidad

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Function
    Private Function fun_ContarTramitesRiesgoMedioRectificaciones(ByVal stUsuario As String) As Integer

        Try
            Dim inCantidad As Integer = 0

            Dim obRECLAMOS As New cla_RECLAMOS
            Dim dtRECLAMOS As New DataTable

            dtRECLAMOS = obRECLAMOS.fun_Consultar_Cantidad_x_Usuario_RECLAMOS(CStr(Trim(stUsuario)))

            If dtRECLAMOS.Rows.Count > 0 Then

                Dim i As Integer = 0

                For i = 0 To dtRECLAMOS.Rows.Count - 1

                    Dim inValor As Integer = CInt(dtRECLAMOS.Rows(i).Item("Cantidad").ToString)

                    If (inValor >= 16 And inValor <= 30) Then

                        inCantidad += 1

                    End If

                Next

            End If

            Return inCantidad

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Function
    Private Function fun_ContarTramitesRiesgoAltoRectificaciones(ByVal stUsuario As String) As Integer

        Try
            Dim inCantidad As Integer = 0

            Dim obRECLAMOS As New cla_RECLAMOS
            Dim dtRECLAMOS As New DataTable

            dtRECLAMOS = obRECLAMOS.fun_Consultar_Cantidad_x_Usuario_RECLAMOS(CStr(Trim(stUsuario)))

            If dtRECLAMOS.Rows.Count > 0 Then

                Dim i As Integer = 0

                For i = 0 To dtRECLAMOS.Rows.Count - 1

                    Dim inValor As Integer = CInt(dtRECLAMOS.Rows(i).Item("Cantidad").ToString)

                    If (inValor >= 31) Then

                        inCantidad += 1

                    End If

                Next

            End If

            Return inCantidad

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Function
    Private Function fun_ContarTramitesSinRadicadoOVCRectificaciones(ByVal stUsuario As String) As Integer

        Try
            Dim inCantidad As Integer = 0

            Dim obRECLAMOS As New cla_RECLAMOS
            Dim dtRECLAMOS As New DataTable

            dtRECLAMOS = obRECLAMOS.fun_Consultar_Cantidad_x_Usuario_RECLAMOS(CStr(Trim(stUsuario)))

            If dtRECLAMOS.Rows.Count > 0 Then

                Dim i As Integer = 0

                For i = 0 To dtRECLAMOS.Rows.Count - 1

                    Dim inValor As Integer = CInt(dtRECLAMOS.Rows(i).Item("RECLRAED").ToString)

                    If (inValor = 0) Then

                        inCantidad += 1

                    End If

                Next

            End If

            Return inCantidad

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Function
    Private Function fun_ContarTramitesPorVigenciaRectificaciones(ByVal inVigencia As Integer, ByVal stEstado As String) As Integer

        Try
            Dim inCantidad As Integer = 0

            Dim obRECLAMOS As New cla_RECLAMOS
            Dim dtRECLAMOS As New DataTable

            dtRECLAMOS = obRECLAMOS.fun_Consultar_Cantidad_x_Usuario_y_Vigencia_RECLAMOS(CInt(inVigencia), CStr(Trim(stEstado)))

            If dtRECLAMOS.Rows.Count > 0 Then

                inCantidad = CInt(dtRECLAMOS.Rows(0).Item("Cantidad").ToString)

            End If

            Return inCantidad

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Function
    Private Function fun_ContarTramitesPorUsuarioVigenciaRectificaciones(ByVal stUsuario As String, ByVal inVigencia As Integer, ByVal stEstado As String) As Integer

        Try
            Dim inCantidad As Integer = 0

            Dim obRECLAMOS As New cla_RECLAMOS
            Dim dtRECLAMOS As New DataTable

            dtRECLAMOS = obRECLAMOS.fun_Consultar_Cantidad_x_Usuario_y_Vigencia_RECLAMOS(CStr(Trim(stUsuario)), CInt(inVigencia), CStr(Trim(stEstado)))

            If dtRECLAMOS.Rows.Count > 0 Then

                inCantidad = CInt(dtRECLAMOS.Rows(0).Item("Cantidad").ToString)

            End If

            Return inCantidad

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Function

#End Region

#Region "FUNCIONES REVISION DE AVALUO"

    Private Function fun_ContarTramitesPendienteRevisionDeAvaluo() As Integer

        Try
            Dim inCantidad As Integer = 0

            If Me.dgvREVIAVAL_1.RowCount > 0 Then
                inCantidad = Me.dgvREVIAVAL_1.RowCount
            End If

            Return inCantidad

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Function
    Private Function fun_ContarTramitesSinRadicadoOVCRevisionDeAvaluo() As Integer

        Try
            Dim inCantidad As Integer = 0

            Dim objdatos As New cla_REVIAVAL
            Dim tbldatos As New DataTable

            If boCONSULTA_REVIAVAL = False Then
                tbldatos = objdatos.fun_Consultar_REVIAVAL_X_BITACORA
            Else
                tbldatos = objdatos.fun_Consultar_REVIAVAL_X_BITACORA(CStr(Trim(vp_cedula)))
            End If

            If tbldatos.Rows.Count > 0 Then

                Dim i As Integer = 0

                For i = 0 To tbldatos.Rows.Count - 1

                    If CInt(tbldatos.Rows(i).Item("REAVRAED").ToString) = 0 Then
                        inCantidad += 1
                    End If

                Next

            End If

            Return inCantidad

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Function
    Private Function fun_ContarTramitesRiesgoBajoRevisionDeAvaluo(ByVal stUsuario As String) As Integer

        Try
            Dim inCantidad As Integer = 0

            Dim obREVIAVAL As New cla_REVIAVAL
            Dim dtREVIAVAL As New DataTable

            dtREVIAVAL = obREVIAVAL.fun_Consultar_Cantidad_x_Usuario_REVIAVAL(CStr(Trim(stUsuario)))

            If dtREVIAVAL.Rows.Count > 0 Then

                Dim i As Integer = 0

                For i = 0 To dtREVIAVAL.Rows.Count - 1

                    Dim inValor As Integer = CInt(dtREVIAVAL.Rows(i).Item("Cantidad").ToString)

                    If (inValor >= 0 And inValor <= 15) Then

                        inCantidad += 1

                    End If

                Next

            End If

            Return inCantidad

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Function
    Private Function fun_ContarTramitesRiesgoMedioRevisionDeAvaluo(ByVal stUsuario As String) As Integer

        Try
            Dim inCantidad As Integer = 0

            Dim obREVIAVAL As New cla_REVIAVAL
            Dim dtREVIAVAL As New DataTable

            dtREVIAVAL = obREVIAVAL.fun_Consultar_Cantidad_x_Usuario_REVIAVAL(CStr(Trim(stUsuario)))

            If dtREVIAVAL.Rows.Count > 0 Then

                Dim i As Integer = 0

                For i = 0 To dtREVIAVAL.Rows.Count - 1

                    Dim inValor As Integer = CInt(dtREVIAVAL.Rows(i).Item("Cantidad").ToString)

                    If (inValor >= 16 And inValor <= 30) Then

                        inCantidad += 1

                    End If

                Next

            End If

            Return inCantidad

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Function
    Private Function fun_ContarTramitesRiesgoAltoRevisionDeAvaluo(ByVal stUsuario As String) As Integer

        Try
            Dim inCantidad As Integer = 0

            Dim obREVIAVAL As New cla_REVIAVAL
            Dim dtREVIAVAL As New DataTable

            dtREVIAVAL = obREVIAVAL.fun_Consultar_Cantidad_x_Usuario_REVIAVAL(CStr(Trim(stUsuario)))

            If dtREVIAVAL.Rows.Count > 0 Then

                Dim i As Integer = 0

                For i = 0 To dtREVIAVAL.Rows.Count - 1

                    Dim inValor As Integer = CInt(dtREVIAVAL.Rows(i).Item("Cantidad").ToString)

                    If (inValor >= 31) Then

                        inCantidad += 1

                    End If

                Next

            End If

            Return inCantidad

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Function
    Private Function fun_ContarTramitesSinRadicadoOVCRevisionDeAvaluo(ByVal stUsuario As String) As Integer

        Try
            Dim inCantidad As Integer = 0

            Dim obREVIAVAL As New cla_REVIAVAL
            Dim dtREVIAVAL As New DataTable

            dtREVIAVAL = obREVIAVAL.fun_Consultar_Cantidad_x_Usuario_REVIAVAL(CStr(Trim(stUsuario)))

            If dtREVIAVAL.Rows.Count > 0 Then

                Dim i As Integer = 0

                For i = 0 To dtREVIAVAL.Rows.Count - 1

                    Dim inValor As Integer = CInt(dtREVIAVAL.Rows(i).Item("REAVRAED").ToString)

                    If (inValor = 0) Then

                        inCantidad += 1

                    End If

                Next

            End If

            Return inCantidad

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Function
    Private Function fun_ContarTramitesPorVigenciaRevisionDeAvaluo(ByVal inVigencia As Integer, ByVal stEstado As String) As Integer

        Try
            Dim inCantidad As Integer = 0

            Dim obREVIAVAL As New cla_REVIAVAL
            Dim dtREVIAVAL As New DataTable

            dtREVIAVAL = obREVIAVAL.fun_Consultar_Cantidad_x_Usuario_y_Vigencia_REVIAVAL(CInt(inVigencia), CStr(Trim(stEstado)))

            If dtREVIAVAL.Rows.Count > 0 Then

                inCantidad = CInt(dtREVIAVAL.Rows(0).Item("Cantidad").ToString)

            End If

            Return inCantidad

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Function
    Private Function fun_ContarTramitesPorUsuarioVigenciaRevisionDeAvaluo(ByVal stUsuario As String, ByVal inVigencia As Integer, ByVal stEstado As String) As Integer

        Try
            Dim inCantidad As Integer = 0

            Dim obREVIAVAL As New cla_REVIAVAL
            Dim dtREVIAVAL As New DataTable

            dtREVIAVAL = obREVIAVAL.fun_Consultar_Cantidad_x_Usuario_y_Vigencia_REVIAVAL(CStr(Trim(stUsuario)), CInt(inVigencia), CStr(Trim(stEstado)))

            If dtREVIAVAL.Rows.Count > 0 Then

                inCantidad = CInt(dtREVIAVAL.Rows(0).Item("Cantidad").ToString)

            End If

            Return inCantidad

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Function

#End Region

#Region "PROCEDIMIENTOS RECTIFICACIONES"

    Private Sub pro_ReconsultarRectificaciones()

        Try
            Dim objdatos As New cla_RECLAMOS

            If boCONSULTA_RECTIFICACIONES = False Then
                Me.BindingSource_RECTIFICACIONES_1.DataSource = objdatos.fun_Consultar_RECLAMOS_X_BITACORA
            Else
                Me.BindingSource_RECTIFICACIONES_1.DataSource = objdatos.fun_Consultar_RECLAMOS_X_BITACORA(CStr(Trim(vp_cedula)))
            End If

            Me.dgvRECTIFICACIONES_1.DataSource = BindingSource_RECTIFICACIONES_1
            Me.dgvRECTIFICACIONES_2.DataSource = BindingSource_RECTIFICACIONES_1
            Me.dgvRECTIFICACIONES_3.DataSource = BindingSource_RECTIFICACIONES_1

            Me.BindingNavigator_RECTIFICACIONES_1.BindingSource = BindingSource_RECTIFICACIONES_1

            ' procedimeintos para listar los datos
            pro_LlenarListadoPorUsuarioRectificaciones()
            pro_LlenarListadoPorVigenciaRectificaciones()
            pro_LlenarListadoPorVigenciaUsuarioRectificaciones()

            '=================================================
            '*** CONFIGURA OBJETOS DEL FORMULARIO MAESTRO ***
            '=================================================

            Me.strBARRESTA.Items(2).Text = "Registros : " & Me.BindingSource_RECTIFICACIONES_1.Count

            Me.dgvRECTIFICACIONES_1.Columns("RECLIDRE").HeaderText = "Id"
            Me.dgvRECTIFICACIONES_1.Columns("RECLSECU").HeaderText = "Secuencia"

            Me.dgvRECTIFICACIONES_1.Columns("RECLDEPA").HeaderText = "Departamento"
            Me.dgvRECTIFICACIONES_1.Columns("RECLMUNI").HeaderText = "Municipio"
            Me.dgvRECTIFICACIONES_1.Columns("RECLCORR").HeaderText = "Correg."
            Me.dgvRECTIFICACIONES_1.Columns("RECLBARR").HeaderText = "Barrio"
            Me.dgvRECTIFICACIONES_1.Columns("RECLMANZ").HeaderText = "Manzana Vereda"
            Me.dgvRECTIFICACIONES_1.Columns("RECLEDIF").HeaderText = "Edificio"
            Me.dgvRECTIFICACIONES_1.Columns("RECLUNPR").HeaderText = "Unidad Predial"
            Me.dgvRECTIFICACIONES_1.Columns("RECLPRED").HeaderText = "Predio"
            Me.dgvRECTIFICACIONES_1.Columns("CLSEDESC").HeaderText = "Sector"
            Me.dgvRECTIFICACIONES_1.Columns("RECLVIGE").HeaderText = "Vigencia"
            Me.dgvRECTIFICACIONES_1.Columns("ESTADESC").HeaderText = "Estado"

            Me.dgvRECTIFICACIONES_2.Columns("SOLIDESC").HeaderText = "Solicitante"
            Me.dgvRECTIFICACIONES_2.Columns("RECLNUDO").HeaderText = "Nro. Documento"
            Me.dgvRECTIFICACIONES_2.Columns("RECLNOMB").HeaderText = "Nombre(s)"
            Me.dgvRECTIFICACIONES_2.Columns("RECLPRAP").HeaderText = "Primer Apellido"
            Me.dgvRECTIFICACIONES_2.Columns("RECLSEAP").HeaderText = "Segundo Apellido"
            Me.dgvRECTIFICACIONES_2.Columns("RECLMAIN").HeaderText = "Matricula"

            Me.dgvRECTIFICACIONES_3.Columns("RECLUSMC").HeaderText = "Usuario"
            Me.dgvRECTIFICACIONES_3.Columns("RECLFEIN").HeaderText = "Fecha de Ingreso"
            Me.dgvRECTIFICACIONES_3.Columns("RECLFEMC").HeaderText = "Fecha de Asignación"
            Me.dgvRECTIFICACIONES_3.Columns("RECLDTFI").HeaderText = "Días Transcurri. Fecha Ingreso"
            Me.dgvRECTIFICACIONES_3.Columns("RECLDTFM").HeaderText = "Días Transcurri. Fecha Asignac."
            Me.dgvRECTIFICACIONES_3.Columns("RECLRADE").HeaderText = "Nro. Radicado Departamento"
            Me.dgvRECTIFICACIONES_3.Columns("RECLFEDE").HeaderText = "Fecha Radicado Departamento"
            Me.dgvRECTIFICACIONES_3.Columns("RECLRAMU").HeaderText = "Nro. Radicado Municipio"
            Me.dgvRECTIFICACIONES_3.Columns("RECLFEMU").HeaderText = "Fecha Radicado Municipio"
            Me.dgvRECTIFICACIONES_3.Columns("RECLRAED").HeaderText = "Nro. Radicado OVC"
            Me.dgvRECTIFICACIONES_3.Columns("RECLFEED").HeaderText = "Fecha radicado OVC"

            Me.dgvRECTIFICACIONES_1.Columns("RECLIDRE").Visible = False
            Me.dgvRECTIFICACIONES_1.Columns("RECLSECU").Visible = False

            Me.dgvRECTIFICACIONES_1.Columns("RECLDEPA").Visible = False
            Me.dgvRECTIFICACIONES_1.Columns("RECLRADE").Visible = False
            Me.dgvRECTIFICACIONES_1.Columns("RECLFEDE").Visible = False
            Me.dgvRECTIFICACIONES_1.Columns("RECLRAMU").Visible = False
            Me.dgvRECTIFICACIONES_1.Columns("RECLFEMU").Visible = False
            Me.dgvRECTIFICACIONES_1.Columns("RECLRAED").Visible = False
            Me.dgvRECTIFICACIONES_1.Columns("RECLFEED").Visible = False
            Me.dgvRECTIFICACIONES_1.Columns("RECLRADM").Visible = False
            Me.dgvRECTIFICACIONES_1.Columns("RECLFEDM").Visible = False
            Me.dgvRECTIFICACIONES_1.Columns("RECLFELC").Visible = False
            Me.dgvRECTIFICACIONES_1.Columns("RECLTITR").Visible = False
            Me.dgvRECTIFICACIONES_1.Columns("RECLOBSE").Visible = False
            Me.dgvRECTIFICACIONES_1.Columns("RECLNUDO").Visible = False
            Me.dgvRECTIFICACIONES_1.Columns("RECLNOMB").Visible = False
            Me.dgvRECTIFICACIONES_1.Columns("RECLPRAP").Visible = False
            Me.dgvRECTIFICACIONES_1.Columns("RECLSEAP").Visible = False
            Me.dgvRECTIFICACIONES_1.Columns("RECLMAIN").Visible = False
            Me.dgvRECTIFICACIONES_1.Columns("RECLMACA").Visible = False
            Me.dgvRECTIFICACIONES_1.Columns("RECLMIAN").Visible = False
            Me.dgvRECTIFICACIONES_1.Columns("RECLSOLI").Visible = False
            Me.dgvRECTIFICACIONES_1.Columns("RECLESTA").Visible = False
            Me.dgvRECTIFICACIONES_1.Columns("RECLCLSE").Visible = False
            Me.dgvRECTIFICACIONES_1.Columns("RECLFEMC").Visible = False
            Me.dgvRECTIFICACIONES_1.Columns("RECLUSMC").Visible = False
            Me.dgvRECTIFICACIONES_1.Columns("RECLFEIN").Visible = False
            Me.dgvRECTIFICACIONES_1.Columns("SOLIDESC").Visible = False
            Me.dgvRECTIFICACIONES_1.Columns("RECLDTFI").Visible = False
            Me.dgvRECTIFICACIONES_1.Columns("RECLDTFM").Visible = False

            Me.dgvRECTIFICACIONES_2.Columns("RECLIDRE").Visible = False
            Me.dgvRECTIFICACIONES_2.Columns("RECLSECU").Visible = False

            Me.dgvRECTIFICACIONES_2.Columns("RECLDEPA").Visible = False
            Me.dgvRECTIFICACIONES_2.Columns("RECLMUNI").Visible = False
            Me.dgvRECTIFICACIONES_2.Columns("RECLCORR").Visible = False
            Me.dgvRECTIFICACIONES_2.Columns("RECLBARR").Visible = False
            Me.dgvRECTIFICACIONES_2.Columns("RECLMANZ").Visible = False
            Me.dgvRECTIFICACIONES_2.Columns("RECLPRED").Visible = False
            Me.dgvRECTIFICACIONES_2.Columns("RECLEDIF").Visible = False
            Me.dgvRECTIFICACIONES_2.Columns("RECLUNPR").Visible = False
            Me.dgvRECTIFICACIONES_2.Columns("RECLCLSE").Visible = False
            Me.dgvRECTIFICACIONES_2.Columns("RECLVIGE").Visible = False
            Me.dgvRECTIFICACIONES_2.Columns("ESTADESC").Visible = False
            Me.dgvRECTIFICACIONES_2.Columns("RECLRADE").Visible = False
            Me.dgvRECTIFICACIONES_2.Columns("RECLFEDE").Visible = False
            Me.dgvRECTIFICACIONES_2.Columns("RECLRAMU").Visible = False
            Me.dgvRECTIFICACIONES_2.Columns("RECLFEMU").Visible = False
            Me.dgvRECTIFICACIONES_2.Columns("RECLRAED").Visible = False
            Me.dgvRECTIFICACIONES_2.Columns("RECLFEED").Visible = False
            Me.dgvRECTIFICACIONES_2.Columns("RECLRADM").Visible = False
            Me.dgvRECTIFICACIONES_2.Columns("RECLFEDM").Visible = False
            Me.dgvRECTIFICACIONES_2.Columns("RECLFELC").Visible = False
            Me.dgvRECTIFICACIONES_2.Columns("RECLTITR").Visible = False
            Me.dgvRECTIFICACIONES_2.Columns("RECLOBSE").Visible = False
            Me.dgvRECTIFICACIONES_2.Columns("RECLMACA").Visible = False
            Me.dgvRECTIFICACIONES_2.Columns("RECLMIAN").Visible = False
            Me.dgvRECTIFICACIONES_2.Columns("RECLSOLI").Visible = False
            Me.dgvRECTIFICACIONES_2.Columns("RECLESTA").Visible = False
            Me.dgvRECTIFICACIONES_2.Columns("CLSEDESC").Visible = False
            Me.dgvRECTIFICACIONES_2.Columns("RECLFEMC").Visible = False
            Me.dgvRECTIFICACIONES_2.Columns("RECLFEIN").Visible = False
            Me.dgvRECTIFICACIONES_2.Columns("RECLUSMC").Visible = False
            Me.dgvRECTIFICACIONES_2.Columns("RECLDTFI").Visible = False
            Me.dgvRECTIFICACIONES_2.Columns("RECLDTFM").Visible = False

            Me.dgvRECTIFICACIONES_3.Columns("RECLIDRE").Visible = False
            Me.dgvRECTIFICACIONES_3.Columns("RECLSECU").Visible = False

            Me.dgvRECTIFICACIONES_3.Columns("RECLDEPA").Visible = False
            Me.dgvRECTIFICACIONES_3.Columns("RECLMUNI").Visible = False
            Me.dgvRECTIFICACIONES_3.Columns("RECLCORR").Visible = False
            Me.dgvRECTIFICACIONES_3.Columns("RECLBARR").Visible = False
            Me.dgvRECTIFICACIONES_3.Columns("RECLMANZ").Visible = False
            Me.dgvRECTIFICACIONES_3.Columns("RECLPRED").Visible = False
            Me.dgvRECTIFICACIONES_3.Columns("RECLEDIF").Visible = False
            Me.dgvRECTIFICACIONES_3.Columns("RECLUNPR").Visible = False
            Me.dgvRECTIFICACIONES_3.Columns("RECLCLSE").Visible = False
            Me.dgvRECTIFICACIONES_3.Columns("RECLVIGE").Visible = False
            Me.dgvRECTIFICACIONES_3.Columns("ESTADESC").Visible = False
            Me.dgvRECTIFICACIONES_3.Columns("RECLNUDO").Visible = False
            Me.dgvRECTIFICACIONES_3.Columns("RECLNOMB").Visible = False
            Me.dgvRECTIFICACIONES_3.Columns("RECLPRAP").Visible = False
            Me.dgvRECTIFICACIONES_3.Columns("RECLSEAP").Visible = False
            Me.dgvRECTIFICACIONES_3.Columns("RECLMAIN").Visible = False
            Me.dgvRECTIFICACIONES_3.Columns("RECLRADE").Visible = False
            Me.dgvRECTIFICACIONES_3.Columns("RECLFEDE").Visible = False
            Me.dgvRECTIFICACIONES_3.Columns("RECLRADM").Visible = False
            Me.dgvRECTIFICACIONES_3.Columns("RECLFEDM").Visible = False
            Me.dgvRECTIFICACIONES_3.Columns("RECLFELC").Visible = False
            Me.dgvRECTIFICACIONES_3.Columns("RECLTITR").Visible = False
            Me.dgvRECTIFICACIONES_3.Columns("RECLOBSE").Visible = False
            Me.dgvRECTIFICACIONES_3.Columns("RECLMACA").Visible = False
            Me.dgvRECTIFICACIONES_3.Columns("RECLMIAN").Visible = False
            Me.dgvRECTIFICACIONES_3.Columns("RECLSOLI").Visible = False
            Me.dgvRECTIFICACIONES_3.Columns("RECLESTA").Visible = False
            Me.dgvRECTIFICACIONES_3.Columns("CLSEDESC").Visible = False
            Me.dgvRECTIFICACIONES_3.Columns("SOLIDESC").Visible = False


        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub pro_ListaDeValoresRectificaciones()

        Try
            If Me.dgvRECTIFICACIONES_1.RowCount > 0 Then

                Me.txtRECLOBSE.Text = Trim(Me.dgvRECTIFICACIONES_1.SelectedRows.Item(0).Cells("RECLOBSE").Value.ToString)

                Me.txtRECLTITR.Text = CType(fun_Buscar_Lista_Valores_TIPOTRAM(Me.dgvRECTIFICACIONES_1.SelectedRows.Item(0).Cells("RECLTITR").Value.ToString), String)
                Me.txtRECLUSMC.Text = CType(fun_Buscar_Lista_Valores_USUARIO(Me.dgvRECTIFICACIONES_1.SelectedRows.Item(0).Cells("RECLMACA").Value.ToString), String)

                Me.txtRECLNUTR.Text = fun_ContarTramitesPendienteRectificaciones()
                Me.txtRECLTOVC.Text = fun_ContarTramitesSinRadicadoOVCRectificaciones()

                pro_EstablecerEstadoRectificaciones()

            Else
                pro_LimpiarCamposRectificaciones()

            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub pro_EstablecerEstadoRectificaciones()

        Try
            Dim inCantidadFechaIngreso As Integer = CInt(Trim(Me.dgvRECTIFICACIONES_3.SelectedRows.Item(0).Cells("RECLDTFI").Value.ToString))
            Dim inCantidadFechaAsignacion As Integer = CInt(Trim(Me.dgvRECTIFICACIONES_3.SelectedRows.Item(0).Cells("RECLDTFM").Value.ToString))

            If (inCantidadFechaAsignacion >= 0 And inCantidadFechaAsignacion <= 15) Then
                Me.txtRECLESFA.BackColor = Color.GreenYellow
                Me.txtRECLESFA.Text = inCantidadFechaAsignacion

            ElseIf (inCantidadFechaAsignacion >= 16 And inCantidadFechaAsignacion <= 30) Then
                Me.txtRECLESFA.BackColor = Color.Yellow
                Me.txtRECLESFA.Text = inCantidadFechaAsignacion

            ElseIf (inCantidadFechaAsignacion >= 31) Then
                Me.txtRECLESFA.BackColor = Color.Tomato
                Me.txtRECLESFA.Text = inCantidadFechaAsignacion

            End If

            If (inCantidadFechaIngreso >= 0 And inCantidadFechaIngreso <= 15) Then
                Me.txtRECLESFI.BackColor = Color.GreenYellow
                Me.txtRECLESFI.Text = inCantidadFechaIngreso

            ElseIf (inCantidadFechaIngreso >= 16 And inCantidadFechaIngreso <= 30) Then
                Me.txtRECLESFI.BackColor = Color.Yellow
                Me.txtRECLESFI.Text = inCantidadFechaIngreso

            ElseIf (inCantidadFechaIngreso >= 31) Then
                Me.txtRECLESFI.BackColor = Color.Tomato
                Me.txtRECLESFI.Text = inCantidadFechaIngreso

            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub pro_LlenarListadoPorUsuarioRectificaciones()

        Try
            ' instancia la clase
            Dim obRECTIFICACIONES As New cla_RECLAMOS
            Dim dtRECTIFICACIONES As New DataTable

            dtRECTIFICACIONES = obRECTIFICACIONES.fun_Consultar_Cantidad_x_Usuario_RECLAMOS

            If dtRECTIFICACIONES.Rows.Count > 0 Then

                ' Crea objeto registros
                Dim dr1 As DataRow

                ' crea la tabla
                Dim dt_CargaDatos As New DataTable

                dt_CargaDatos.Columns.Add(New DataColumn("Usuario", GetType(String)))
                dt_CargaDatos.Columns.Add(New DataColumn("Pendientes", GetType(String)))
                dt_CargaDatos.Columns.Add(New DataColumn("Rango_1", GetType(String)))
                dt_CargaDatos.Columns.Add(New DataColumn("Rango_2", GetType(String)))
                dt_CargaDatos.Columns.Add(New DataColumn("Rango_3", GetType(String)))
                dt_CargaDatos.Columns.Add(New DataColumn("Rango_4", GetType(String)))

                ' declara la variable
                Dim inCantidadRiesgoBajo As Integer = 0
                Dim inCantidadRiesgoMedio As Integer = 0
                Dim inCantidadRiesgoAlto As Integer = 0

                Dim i As Integer = 0

                For i = 0 To dtRECTIFICACIONES.Rows.Count - 1

                    dr1 = dt_CargaDatos.NewRow()

                    dr1("Usuario") = CStr(dtRECTIFICACIONES.Rows(i).Item("Usuario").ToString)
                    dr1("Pendientes") = CStr(dtRECTIFICACIONES.Rows(i).Item("Pendientes").ToString)
                    dr1("Rango_1") = fun_ContarTramitesRiesgoBajoRectificaciones(CStr(dtRECTIFICACIONES.Rows(i).Item("Usuario").ToString))
                    dr1("Rango_2") = fun_ContarTramitesRiesgoMedioRectificaciones(CStr(dtRECTIFICACIONES.Rows(i).Item("Usuario").ToString))
                    dr1("Rango_3") = fun_ContarTramitesRiesgoAltoRectificaciones(CStr(dtRECTIFICACIONES.Rows(i).Item("Usuario").ToString))
                    dr1("Rango_4") = fun_ContarTramitesSinRadicadoOVCRectificaciones(CStr(dtRECTIFICACIONES.Rows(i).Item("Usuario").ToString))

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
                    item.SubItems.Add(dt_CargaDatos.Rows(j).Item("Rango_4"))

                Next

            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub pro_LlenarListadoPorVigenciaRectificaciones()

        Try
            ' instancia la clase
            Dim obRECTIFICACIONES As New cla_RECLAMOS
            Dim dtRECTIFICACIONES As New DataTable

            dtRECTIFICACIONES = obRECTIFICACIONES.fun_Consultar_Cantidad_x_Vigencia_RECLAMOS

            If dtRECTIFICACIONES.Rows.Count > 0 Then

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

                For i = 0 To dtRECTIFICACIONES.Rows.Count - 1

                    dr1 = dt_CargaDatos.NewRow()

                    dr1("Vigencia") = CStr(dtRECTIFICACIONES.Rows(i).Item("Vigencia").ToString)
                    dr1("Cantidad") = CStr(dtRECTIFICACIONES.Rows(i).Item("Cantidad").ToString)
                    dr1("Rango_1") = fun_ContarTramitesPorVigenciaRectificaciones(CInt(dtRECTIFICACIONES.Rows(i).Item("Vigencia").ToString), "ej")
                    dr1("Rango_2") = fun_ContarTramitesPorVigenciaRectificaciones(CInt(dtRECTIFICACIONES.Rows(i).Item("Vigencia").ToString), "fi")
                    dr1("Rango_3") = fun_ContarTramitesPorVigenciaRectificaciones(CInt(dtRECTIFICACIONES.Rows(i).Item("Vigencia").ToString), "ca")

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
    Private Sub pro_LlenarListadoPorVigenciaUsuarioRectificaciones()

        Try
            ' instancia la clase
            Dim obRECTIFICACIONES As New cla_RECLAMOS
            Dim dtRECTIFICACIONES As New DataTable

            dtRECTIFICACIONES = obRECTIFICACIONES.fun_Consultar_Cantidad_x_Vigencia_y_Usuario_RECLAMOS

            If dtRECTIFICACIONES.Rows.Count > 0 Then

                ' Crea objeto registros
                Dim dr1 As DataRow

                ' crea la tabla
                Dim dt_CargaDatos As New DataTable

                dt_CargaDatos.Columns.Add(New DataColumn("Usuario", GetType(String)))
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

                For i = 0 To dtRECTIFICACIONES.Rows.Count - 1

                    dr1 = dt_CargaDatos.NewRow()

                    dr1("Usuario") = CStr(dtRECTIFICACIONES.Rows(i).Item("Usuario").ToString)
                    dr1("Vigencia") = CStr(dtRECTIFICACIONES.Rows(i).Item("Vigencia").ToString)
                    dr1("Cantidad") = CStr(dtRECTIFICACIONES.Rows(i).Item("Cantidad").ToString)
                    dr1("Rango_1") = fun_ContarTramitesPorUsuarioVigenciaRectificaciones(CStr(dtRECTIFICACIONES.Rows(i).Item("Usuario").ToString), CInt(dtRECTIFICACIONES.Rows(i).Item("Vigencia").ToString), "ej")
                    dr1("Rango_2") = fun_ContarTramitesPorUsuarioVigenciaRectificaciones(CStr(dtRECTIFICACIONES.Rows(i).Item("Usuario").ToString), CInt(dtRECTIFICACIONES.Rows(i).Item("Vigencia").ToString), "fi")
                    dr1("Rango_3") = fun_ContarTramitesPorUsuarioVigenciaRectificaciones(CStr(dtRECTIFICACIONES.Rows(i).Item("Usuario").ToString), CInt(dtRECTIFICACIONES.Rows(i).Item("Vigencia").ToString), "ca")

                    dt_CargaDatos.Rows.Add(dr1)

                Next


                Dim item As New ListViewItem
                Dim j As Integer

                Me.lsvMovimientosPorVigenciaUsuarioRectificaciones.Items.Clear()

                For j = 0 To dt_CargaDatos.Rows.Count - 1

                    item = lsvMovimientosPorVigenciaUsuarioRectificaciones.Items.Add(dt_CargaDatos.Rows(j).Item("Usuario"))
                    item.SubItems.Add(dt_CargaDatos.Rows(j).Item("Vigencia"))
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
    Private Sub pro_LimpiarCamposRectificaciones()

        Me.txtRECLNUTR.Text = ""
        Me.txtRECLOBSE.Text = ""
        Me.txtRECLTITR.Text = ""
        Me.txtRECLUSMC.Text = ""
        Me.txtRECLTOVC.Text = ""

        Me.txtRECLESFI.BackColor = Color.White
        Me.txtRECLESFA.BackColor = Color.White

        Me.strBARRESTA.Items(2).Text = "Registros : 0"

    End Sub

#End Region

#Region "PROCEDIMIENTOS REVISION DE AVALUO"

    Private Sub pro_ReconsultarRevisionDeAvaluo()

        Try
            Dim objdatos As New cla_REVIAVAL

            If boCONSULTA_REVIAVAL = False Then
                Me.BindingSource_REVIAVAL_1.DataSource = objdatos.fun_Consultar_REVIAVAL_X_BITACORA
            Else
                Me.BindingSource_REVIAVAL_1.DataSource = objdatos.fun_Consultar_REVIAVAL_X_BITACORA(CStr(Trim(vp_cedula)))
            End If

            Me.dgvREVIAVAL_1.DataSource = BindingSource_REVIAVAL_1
            Me.dgvREVIAVAL_2.DataSource = BindingSource_REVIAVAL_1
            Me.dgvREVIAVAL_3.DataSource = BindingSource_REVIAVAL_1

            Me.BindingNavigator_REVIAVAL_1.BindingSource = BindingSource_REVIAVAL_1

            ' procedimeintos para listar los datos
            pro_LlenarListadoPorUsuarioRevisionDeAvaluo()
            pro_LlenarListadoPorVigenciaRevisionDeAvaluo()
            pro_LlenarListadoPorVigenciaUsuarioRevisionDeAvaluo()

            '=================================================
            '*** CONFIGURA OBJETOS DEL FORMULARIO MAESTRO ***
            '=================================================

            Me.strBARRESTA.Items(2).Text = "Registros : " & Me.BindingSource_REVIAVAL_1.Count

            Me.dgvREVIAVAL_1.Columns("REAVIDRE").HeaderText = "Id"
            Me.dgvREVIAVAL_1.Columns("REAVSECU").HeaderText = "Secuencia"

            Me.dgvREVIAVAL_1.Columns("REAVDEPA").HeaderText = "Departamento"
            Me.dgvREVIAVAL_1.Columns("REAVMUNI").HeaderText = "Municipio"
            Me.dgvREVIAVAL_1.Columns("REAVCORR").HeaderText = "Correg."
            Me.dgvREVIAVAL_1.Columns("REAVBARR").HeaderText = "Barrio"
            Me.dgvREVIAVAL_1.Columns("REAVMANZ").HeaderText = "Manzana Vereda"
            Me.dgvREVIAVAL_1.Columns("REAVEDIF").HeaderText = "Edificio"
            Me.dgvREVIAVAL_1.Columns("REAVUNPR").HeaderText = "Unidad Predial"
            Me.dgvREVIAVAL_1.Columns("REAVPRED").HeaderText = "Predio"
            Me.dgvREVIAVAL_1.Columns("CLSEDESC").HeaderText = "Sector"
            Me.dgvREVIAVAL_1.Columns("REAVVIGE").HeaderText = "Vigencia"
            Me.dgvREVIAVAL_1.Columns("ESTADESC").HeaderText = "Estado"

            Me.dgvREVIAVAL_2.Columns("SOLIDESC").HeaderText = "Solicitante"
            Me.dgvREVIAVAL_2.Columns("REAVNUDO").HeaderText = "Nro. Documento"
            Me.dgvREVIAVAL_2.Columns("REAVNOMB").HeaderText = "Nombre(s)"
            Me.dgvREVIAVAL_2.Columns("REAVPRAP").HeaderText = "Primer Apellido"
            Me.dgvREVIAVAL_2.Columns("REAVSEAP").HeaderText = "Segundo Apellido"
            Me.dgvREVIAVAL_2.Columns("REAVMAIN").HeaderText = "Matricula"

            Me.dgvREVIAVAL_3.Columns("REAVUSMC").HeaderText = "Usuario"
            Me.dgvREVIAVAL_3.Columns("REAVFEIN").HeaderText = "Fecha de Ingreso"
            Me.dgvREVIAVAL_3.Columns("REAVFEMC").HeaderText = "Fecha de Asignación"
            Me.dgvREVIAVAL_3.Columns("REAVDTFI").HeaderText = "Días Transcurri. Fecha Ingreso"
            Me.dgvREVIAVAL_3.Columns("REAVDTFM").HeaderText = "Días Transcurri. Fecha Asignac."
            Me.dgvREVIAVAL_3.Columns("REAVRADE").HeaderText = "Nro. Radicado Departamento"
            Me.dgvREVIAVAL_3.Columns("REAVFEDE").HeaderText = "Fecha Radicado Departamento"
            Me.dgvREVIAVAL_3.Columns("REAVRAMU").HeaderText = "Nro. Radicado Municipio"
            Me.dgvREVIAVAL_3.Columns("REAVFEMU").HeaderText = "Fecha Radicado Municipio"
            Me.dgvREVIAVAL_3.Columns("REAVRAED").HeaderText = "Nro. Radicado OVC"
            Me.dgvREVIAVAL_3.Columns("REAVFEED").HeaderText = "Fecha radicado OVC"

            Me.dgvREVIAVAL_1.Columns("REAVIDRE").Visible = False
            Me.dgvREVIAVAL_1.Columns("REAVSECU").Visible = False

            Me.dgvREVIAVAL_1.Columns("REAVDEPA").Visible = False
            Me.dgvREVIAVAL_1.Columns("REAVRADE").Visible = False
            Me.dgvREVIAVAL_1.Columns("REAVFEDE").Visible = False
            Me.dgvREVIAVAL_1.Columns("REAVRAMU").Visible = False
            Me.dgvREVIAVAL_1.Columns("REAVFEMU").Visible = False
            Me.dgvREVIAVAL_1.Columns("REAVRAED").Visible = False
            Me.dgvREVIAVAL_1.Columns("REAVFEED").Visible = False
            Me.dgvREVIAVAL_1.Columns("REAVRADM").Visible = False
            Me.dgvREVIAVAL_1.Columns("REAVFEDM").Visible = False
            Me.dgvREVIAVAL_1.Columns("REAVFELC").Visible = False
            Me.dgvREVIAVAL_1.Columns("REAVTITR").Visible = False
            Me.dgvREVIAVAL_1.Columns("REAVOBSE").Visible = False
            Me.dgvREVIAVAL_1.Columns("REAVNUDO").Visible = False
            Me.dgvREVIAVAL_1.Columns("REAVNOMB").Visible = False
            Me.dgvREVIAVAL_1.Columns("REAVPRAP").Visible = False
            Me.dgvREVIAVAL_1.Columns("REAVSEAP").Visible = False
            Me.dgvREVIAVAL_1.Columns("REAVMAIN").Visible = False
            Me.dgvREVIAVAL_1.Columns("REAVMACA").Visible = False
            Me.dgvREVIAVAL_1.Columns("REAVMIAN").Visible = False
            Me.dgvREVIAVAL_1.Columns("REAVSOLI").Visible = False
            Me.dgvREVIAVAL_1.Columns("REAVESTA").Visible = False
            Me.dgvREVIAVAL_1.Columns("REAVCLSE").Visible = False
            Me.dgvREVIAVAL_1.Columns("REAVFEMC").Visible = False
            Me.dgvREVIAVAL_1.Columns("REAVUSMC").Visible = False
            Me.dgvREVIAVAL_1.Columns("REAVFEIN").Visible = False
            Me.dgvREVIAVAL_1.Columns("SOLIDESC").Visible = False
            Me.dgvREVIAVAL_1.Columns("REAVDTFI").Visible = False
            Me.dgvREVIAVAL_1.Columns("REAVDTFM").Visible = False

            Me.dgvREVIAVAL_2.Columns("REAVIDRE").Visible = False
            Me.dgvREVIAVAL_2.Columns("REAVSECU").Visible = False

            Me.dgvREVIAVAL_2.Columns("REAVDEPA").Visible = False
            Me.dgvREVIAVAL_2.Columns("REAVMUNI").Visible = False
            Me.dgvREVIAVAL_2.Columns("REAVCORR").Visible = False
            Me.dgvREVIAVAL_2.Columns("REAVBARR").Visible = False
            Me.dgvREVIAVAL_2.Columns("REAVMANZ").Visible = False
            Me.dgvREVIAVAL_2.Columns("REAVPRED").Visible = False
            Me.dgvREVIAVAL_2.Columns("REAVEDIF").Visible = False
            Me.dgvREVIAVAL_2.Columns("REAVUNPR").Visible = False
            Me.dgvREVIAVAL_2.Columns("REAVCLSE").Visible = False
            Me.dgvREVIAVAL_2.Columns("REAVVIGE").Visible = False
            Me.dgvREVIAVAL_2.Columns("ESTADESC").Visible = False
            Me.dgvREVIAVAL_2.Columns("REAVRADE").Visible = False
            Me.dgvREVIAVAL_2.Columns("REAVFEDE").Visible = False
            Me.dgvREVIAVAL_2.Columns("REAVRAMU").Visible = False
            Me.dgvREVIAVAL_2.Columns("REAVFEMU").Visible = False
            Me.dgvREVIAVAL_2.Columns("REAVRAED").Visible = False
            Me.dgvREVIAVAL_2.Columns("REAVFEED").Visible = False
            Me.dgvREVIAVAL_2.Columns("REAVRADM").Visible = False
            Me.dgvREVIAVAL_2.Columns("REAVFEDM").Visible = False
            Me.dgvREVIAVAL_2.Columns("REAVFELC").Visible = False
            Me.dgvREVIAVAL_2.Columns("REAVTITR").Visible = False
            Me.dgvREVIAVAL_2.Columns("REAVOBSE").Visible = False
            Me.dgvREVIAVAL_2.Columns("REAVMACA").Visible = False
            Me.dgvREVIAVAL_2.Columns("REAVMIAN").Visible = False
            Me.dgvREVIAVAL_2.Columns("REAVSOLI").Visible = False
            Me.dgvREVIAVAL_2.Columns("REAVESTA").Visible = False
            Me.dgvREVIAVAL_2.Columns("CLSEDESC").Visible = False
            Me.dgvREVIAVAL_2.Columns("REAVFEMC").Visible = False
            Me.dgvREVIAVAL_2.Columns("REAVFEIN").Visible = False
            Me.dgvREVIAVAL_2.Columns("REAVUSMC").Visible = False
            Me.dgvREVIAVAL_2.Columns("REAVDTFI").Visible = False
            Me.dgvREVIAVAL_2.Columns("REAVDTFM").Visible = False

            Me.dgvREVIAVAL_3.Columns("REAVIDRE").Visible = False
            Me.dgvREVIAVAL_3.Columns("REAVSECU").Visible = False

            Me.dgvREVIAVAL_3.Columns("REAVDEPA").Visible = False
            Me.dgvREVIAVAL_3.Columns("REAVMUNI").Visible = False
            Me.dgvREVIAVAL_3.Columns("REAVCORR").Visible = False
            Me.dgvREVIAVAL_3.Columns("REAVBARR").Visible = False
            Me.dgvREVIAVAL_3.Columns("REAVMANZ").Visible = False
            Me.dgvREVIAVAL_3.Columns("REAVPRED").Visible = False
            Me.dgvREVIAVAL_3.Columns("REAVEDIF").Visible = False
            Me.dgvREVIAVAL_3.Columns("REAVUNPR").Visible = False
            Me.dgvREVIAVAL_3.Columns("REAVCLSE").Visible = False
            Me.dgvREVIAVAL_3.Columns("REAVVIGE").Visible = False
            Me.dgvREVIAVAL_3.Columns("ESTADESC").Visible = False
            Me.dgvREVIAVAL_3.Columns("REAVNUDO").Visible = False
            Me.dgvREVIAVAL_3.Columns("REAVNOMB").Visible = False
            Me.dgvREVIAVAL_3.Columns("REAVPRAP").Visible = False
            Me.dgvREVIAVAL_3.Columns("REAVSEAP").Visible = False
            Me.dgvREVIAVAL_3.Columns("REAVMAIN").Visible = False
            Me.dgvREVIAVAL_3.Columns("REAVRADE").Visible = False
            Me.dgvREVIAVAL_3.Columns("REAVFEDE").Visible = False
            Me.dgvREVIAVAL_3.Columns("REAVRADM").Visible = False
            Me.dgvREVIAVAL_3.Columns("REAVFEDM").Visible = False
            Me.dgvREVIAVAL_3.Columns("REAVFELC").Visible = False
            Me.dgvREVIAVAL_3.Columns("REAVTITR").Visible = False
            Me.dgvREVIAVAL_3.Columns("REAVOBSE").Visible = False
            Me.dgvREVIAVAL_3.Columns("REAVMACA").Visible = False
            Me.dgvREVIAVAL_3.Columns("REAVMIAN").Visible = False
            Me.dgvREVIAVAL_3.Columns("REAVSOLI").Visible = False
            Me.dgvREVIAVAL_3.Columns("REAVESTA").Visible = False
            Me.dgvREVIAVAL_3.Columns("CLSEDESC").Visible = False
            Me.dgvREVIAVAL_3.Columns("SOLIDESC").Visible = False


        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub pro_ListaDeValoresRevisionDeAvaluo()

        Try
            If Me.dgvREVIAVAL_1.RowCount > 0 Then

                Me.txtREAVOBSE.Text = Trim(Me.dgvREVIAVAL_1.SelectedRows.Item(0).Cells("REAVOBSE").Value.ToString)

                Me.txtREAVTITR.Text = CType(fun_Buscar_Lista_Valores_TIPOTRAM(Me.dgvREVIAVAL_1.SelectedRows.Item(0).Cells("REAVTITR").Value.ToString), String)
                Me.txtREAVUSMC.Text = CType(fun_Buscar_Lista_Valores_USUARIO(Me.dgvREVIAVAL_1.SelectedRows.Item(0).Cells("REAVMACA").Value.ToString), String)

                Me.txtREAVNUTR.Text = fun_ContarTramitesPendienteRevisionDeAvaluo()
                Me.txtREAVTOVC.Text = fun_ContarTramitesSinRadicadoOVCRevisionDeAvaluo()

                pro_EstablecerEstadoRevisionDeAvaluo()

            Else
                pro_LimpiarCamposRevisionDeAvaluo()

            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub pro_EstablecerEstadoRevisionDeAvaluo()

        Try
            Dim inCantidadFechaIngreso As Integer = CInt(Trim(Me.dgvREVIAVAL_3.SelectedRows.Item(0).Cells("REAVDTFI").Value.ToString))
            Dim inCantidadFechaAsignacion As Integer = CInt(Trim(Me.dgvREVIAVAL_3.SelectedRows.Item(0).Cells("REAVDTFM").Value.ToString))

            If (inCantidadFechaAsignacion >= 0 And inCantidadFechaAsignacion <= 15) Then
                Me.txtREAVESFA.BackColor = Color.GreenYellow
                Me.txtREAVESFA.Text = inCantidadFechaAsignacion

            ElseIf (inCantidadFechaAsignacion >= 16 And inCantidadFechaAsignacion <= 30) Then
                Me.txtREAVESFA.BackColor = Color.Yellow
                Me.txtREAVESFA.Text = inCantidadFechaAsignacion

            ElseIf (inCantidadFechaAsignacion >= 31) Then
                Me.txtREAVESFA.BackColor = Color.Tomato
                Me.txtREAVESFA.Text = inCantidadFechaAsignacion

            End If

            If (inCantidadFechaIngreso >= 0 And inCantidadFechaIngreso <= 15) Then
                Me.txtREAVESFI.BackColor = Color.GreenYellow
                Me.txtREAVESFI.Text = inCantidadFechaIngreso

            ElseIf (inCantidadFechaIngreso >= 16 And inCantidadFechaIngreso <= 30) Then
                Me.txtREAVESFI.BackColor = Color.Yellow
                Me.txtREAVESFI.Text = inCantidadFechaIngreso

            ElseIf (inCantidadFechaIngreso >= 31) Then
                Me.txtREAVESFI.BackColor = Color.Tomato
                Me.txtREAVESFI.Text = inCantidadFechaIngreso

            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub pro_LlenarListadoPorUsuarioRevisionDeAvaluo()

        Try
            ' instancia la clase
            Dim obREVIAVAL As New cla_REVIAVAL
            Dim dtREVIAVAL As New DataTable

            dtREVIAVAL = obREVIAVAL.fun_Consultar_Cantidad_x_Usuario_REVIAVAL

            If dtREVIAVAL.Rows.Count > 0 Then

                ' Crea objeto registros
                Dim dr1 As DataRow

                ' crea la tabla
                Dim dt_CargaDatos As New DataTable

                dt_CargaDatos.Columns.Add(New DataColumn("Usuario", GetType(String)))
                dt_CargaDatos.Columns.Add(New DataColumn("Pendientes", GetType(String)))
                dt_CargaDatos.Columns.Add(New DataColumn("Rango_1", GetType(String)))
                dt_CargaDatos.Columns.Add(New DataColumn("Rango_2", GetType(String)))
                dt_CargaDatos.Columns.Add(New DataColumn("Rango_3", GetType(String)))
                dt_CargaDatos.Columns.Add(New DataColumn("Rango_4", GetType(String)))

                ' declara la variable
                Dim inCantidadRiesgoBajo As Integer = 0
                Dim inCantidadRiesgoMedio As Integer = 0
                Dim inCantidadRiesgoAlto As Integer = 0

                Dim i As Integer = 0

                For i = 0 To dtREVIAVAL.Rows.Count - 1

                    dr1 = dt_CargaDatos.NewRow()

                    dr1("Usuario") = CStr(dtREVIAVAL.Rows(i).Item("Usuario").ToString)
                    dr1("Pendientes") = CStr(dtREVIAVAL.Rows(i).Item("Pendientes").ToString)
                    dr1("Rango_1") = fun_ContarTramitesRiesgoBajoRevisionDeAvaluo(CStr(dtREVIAVAL.Rows(i).Item("Usuario").ToString))
                    dr1("Rango_2") = fun_ContarTramitesRiesgoMedioRevisionDeAvaluo(CStr(dtREVIAVAL.Rows(i).Item("Usuario").ToString))
                    dr1("Rango_3") = fun_ContarTramitesRiesgoAltoRevisionDeAvaluo(CStr(dtREVIAVAL.Rows(i).Item("Usuario").ToString))
                    dr1("Rango_4") = fun_ContarTramitesSinRadicadoOVCRevisionDeAvaluo(CStr(dtREVIAVAL.Rows(i).Item("Usuario").ToString))

                    dt_CargaDatos.Rows.Add(dr1)

                Next


                Dim item As New ListViewItem
                Dim j As Integer

                Me.lsvMovimientosPorUsuarioRevisionDeAvaluo.Items.Clear()

                For j = 0 To dt_CargaDatos.Rows.Count - 1

                    item = lsvMovimientosPorUsuarioRevisionDeAvaluo.Items.Add(dt_CargaDatos.Rows(j).Item("Usuario"))
                    item.SubItems.Add(dt_CargaDatos.Rows(j).Item("Pendientes"))
                    item.SubItems.Add(dt_CargaDatos.Rows(j).Item("Rango_1"))
                    item.SubItems.Add(dt_CargaDatos.Rows(j).Item("Rango_2"))
                    item.SubItems.Add(dt_CargaDatos.Rows(j).Item("Rango_3"))
                    item.SubItems.Add(dt_CargaDatos.Rows(j).Item("Rango_4"))

                Next

            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub pro_LlenarListadoPorVigenciaRevisionDeAvaluo()

        Try
            ' instancia la clase
            Dim obREVIAVAL As New cla_REVIAVAL
            Dim dtREVIAVAL As New DataTable

            dtREVIAVAL = obREVIAVAL.fun_Consultar_Cantidad_x_Vigencia_REVIAVAL

            If dtREVIAVAL.Rows.Count > 0 Then

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

                For i = 0 To dtREVIAVAL.Rows.Count - 1

                    dr1 = dt_CargaDatos.NewRow()

                    dr1("Vigencia") = CStr(dtREVIAVAL.Rows(i).Item("Vigencia").ToString)
                    dr1("Cantidad") = CStr(dtREVIAVAL.Rows(i).Item("Cantidad").ToString)
                    dr1("Rango_1") = fun_ContarTramitesPorVigenciaRevisionDeAvaluo(CInt(dtREVIAVAL.Rows(i).Item("Vigencia").ToString), "ej")
                    dr1("Rango_2") = fun_ContarTramitesPorVigenciaRevisionDeAvaluo(CInt(dtREVIAVAL.Rows(i).Item("Vigencia").ToString), "fi")
                    dr1("Rango_3") = fun_ContarTramitesPorVigenciaRevisionDeAvaluo(CInt(dtREVIAVAL.Rows(i).Item("Vigencia").ToString), "ca")

                    dt_CargaDatos.Rows.Add(dr1)

                Next


                Dim item As New ListViewItem
                Dim j As Integer

                Me.lsvMovimientosPorVigenciaRevisionDeAvaluo.Items.Clear()

                For j = 0 To dt_CargaDatos.Rows.Count - 1

                    item = lsvMovimientosPorVigenciaRevisionDeAvaluo.Items.Add(dt_CargaDatos.Rows(j).Item("Vigencia"))
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
    Private Sub pro_LlenarListadoPorVigenciaUsuarioRevisionDeAvaluo()

        Try
            ' instancia la clase
            Dim obREVIAVAL As New cla_REVIAVAL
            Dim dtREVIAVAL As New DataTable

            dtREVIAVAL = obREVIAVAL.fun_Consultar_Cantidad_x_Vigencia_y_Usuario_REVIAVAL

            If dtREVIAVAL.Rows.Count > 0 Then

                ' Crea objeto registros
                Dim dr1 As DataRow

                ' crea la tabla
                Dim dt_CargaDatos As New DataTable

                dt_CargaDatos.Columns.Add(New DataColumn("Usuario", GetType(String)))
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

                For i = 0 To dtREVIAVAL.Rows.Count - 1

                    dr1 = dt_CargaDatos.NewRow()

                    dr1("Usuario") = CStr(dtREVIAVAL.Rows(i).Item("Usuario").ToString)
                    dr1("Vigencia") = CStr(dtREVIAVAL.Rows(i).Item("Vigencia").ToString)
                    dr1("Cantidad") = CStr(dtREVIAVAL.Rows(i).Item("Cantidad").ToString)
                    dr1("Rango_1") = fun_ContarTramitesPorUsuarioVigenciaRevisionDeAvaluo(CStr(dtREVIAVAL.Rows(i).Item("Usuario").ToString), CInt(dtREVIAVAL.Rows(i).Item("Vigencia").ToString), "ej")
                    dr1("Rango_2") = fun_ContarTramitesPorUsuarioVigenciaRevisionDeAvaluo(CStr(dtREVIAVAL.Rows(i).Item("Usuario").ToString), CInt(dtREVIAVAL.Rows(i).Item("Vigencia").ToString), "fi")
                    dr1("Rango_3") = fun_ContarTramitesPorUsuarioVigenciaRevisionDeAvaluo(CStr(dtREVIAVAL.Rows(i).Item("Usuario").ToString), CInt(dtREVIAVAL.Rows(i).Item("Vigencia").ToString), "ca")

                    dt_CargaDatos.Rows.Add(dr1)

                Next


                Dim item As New ListViewItem
                Dim j As Integer

                Me.lsvMovimientosPorVigenciaUsuarioRevisionDeAvaluo.Items.Clear()

                For j = 0 To dt_CargaDatos.Rows.Count - 1

                    item = lsvMovimientosPorVigenciaUsuarioRevisionDeAvaluo.Items.Add(dt_CargaDatos.Rows(j).Item("Usuario"))
                    item.SubItems.Add(dt_CargaDatos.Rows(j).Item("Vigencia"))
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
    Private Sub pro_LimpiarCamposRevisionDeAvaluo()

        Me.txtREAVNUTR.Text = ""
        Me.txtREAVOBSE.Text = ""
        Me.txtREAVTITR.Text = ""
        Me.txtREAVUSMC.Text = ""
        Me.txtREAVTOVC.Text = ""

        Me.txtREAVESFI.BackColor = Color.White
        Me.txtREAVESFA.BackColor = Color.White

        Me.strBARRESTA.Items(2).Text = "Registros : 0"

    End Sub

#End Region

#Region "MENU RECTIFICACIONES"

    Private Sub cmdRECONSULTAR_RECTIFICACIONES_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdRECONSULTAR_RECTIFICACIONES.Click
        boCONSULTA_RECTIFICACIONES = False
        pro_ReconsultarRectificaciones()
        pro_ListaDeValoresRectificaciones()
    End Sub
    Private Sub cmdCONSULTAR_RECTIFICACIONES_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCONSULTAR_RECTIFICACIONES.Click

        Try
            vp_cedula = ""

            frm_consultar_BITAMOVI.ShowDialog()

            If vp_cedula <> "" Then
                boCONSULTA_RECTIFICACIONES = True
            Else
                boCONSULTA_RECTIFICACIONES = False
            End If

            pro_ReconsultarRectificaciones()
            pro_ListaDeValoresRectificaciones()

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub cmdExportarExcelRectificaciones_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExportarExcelRectificaciones.Click

        Try
            If Me.dgvRECTIFICACIONES_1.RowCount = 0 Then
                MessageBox.Show("No existe datos para exportar", "Mensaje ...", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1)
            Else
                Dim objdatos As New cla_RECLAMOS
                Dim tbldatos As New DataTable

                If boCONSULTA_RECTIFICACIONES = False Then
                    tbldatos = objdatos.fun_Consultar_RECLAMOS_X_BITACORA
                Else
                    tbldatos = objdatos.fun_Consultar_RECLAMOS_X_BITACORA(CStr(Trim(vp_cedula)))
                End If

                If tbldatos.Rows.Count > 0 Then

                    ' Crea objeto registros
                    Dim dr1 As DataRow

                    ' crea la tabla
                    Dim dt_CargaDatos As New DataTable

                    dt_CargaDatos.Columns.Add(New DataColumn("Municipio", GetType(String)))
                    dt_CargaDatos.Columns.Add(New DataColumn("Corregimiento", GetType(String)))
                    dt_CargaDatos.Columns.Add(New DataColumn("Barrio", GetType(String)))
                    dt_CargaDatos.Columns.Add(New DataColumn("Manzana_Vereda", GetType(String)))
                    dt_CargaDatos.Columns.Add(New DataColumn("Predio", GetType(String)))
                    dt_CargaDatos.Columns.Add(New DataColumn("Edificio", GetType(String)))
                    dt_CargaDatos.Columns.Add(New DataColumn("Unidad_Predial", GetType(String)))
                    dt_CargaDatos.Columns.Add(New DataColumn("Sector", GetType(String)))
                    dt_CargaDatos.Columns.Add(New DataColumn("Vigencia", GetType(String)))
                    dt_CargaDatos.Columns.Add(New DataColumn("Matricula", GetType(String)))
                    dt_CargaDatos.Columns.Add(New DataColumn("Nro_Radicado_Muncipio", GetType(String)))
                    dt_CargaDatos.Columns.Add(New DataColumn("Fecha_Radicado_Municipio", GetType(String)))
                    dt_CargaDatos.Columns.Add(New DataColumn("Nro_Radicado_OVC", GetType(String)))
                    dt_CargaDatos.Columns.Add(New DataColumn("Fecha_Radicado_OVC", GetType(String)))
                    dt_CargaDatos.Columns.Add(New DataColumn("Fecha_Ingreso", GetType(String)))
                    dt_CargaDatos.Columns.Add(New DataColumn("Fecha_Asignacion", GetType(String)))
                    dt_CargaDatos.Columns.Add(New DataColumn("Dias_Trascurridos_Fecha_Ingreso", GetType(String)))
                    dt_CargaDatos.Columns.Add(New DataColumn("Dias_Trascurridos_Fecha_Asignacion", GetType(String)))

                    ' declara la variable
                    Dim i As Integer = 0

                    For i = 0 To tbldatos.Rows.Count - 1

                        dr1 = dt_CargaDatos.NewRow()

                        dr1("Municipio") = CStr(tbldatos.Rows(i).Item("RECLMUNI").ToString)
                        dr1("Corregimiento") = CStr(tbldatos.Rows(i).Item("RECLCORR").ToString)
                        dr1("Barrio") = CStr(tbldatos.Rows(i).Item("RECLBARR").ToString)
                        dr1("Manzana_Vereda") = CStr(tbldatos.Rows(i).Item("RECLMANZ").ToString)
                        dr1("Predio") = CStr(tbldatos.Rows(i).Item("RECLPRED").ToString)
                        dr1("Edificio") = CStr(tbldatos.Rows(i).Item("RECLEDIF").ToString)
                        dr1("Unidad_Predial") = CStr(tbldatos.Rows(i).Item("RECLUNPR").ToString)
                        dr1("Sector") = CStr(tbldatos.Rows(i).Item("RECLCLSE").ToString)
                        dr1("Vigencia") = CStr(tbldatos.Rows(i).Item("RECLVIGE").ToString)
                        dr1("Matricula") = CStr(tbldatos.Rows(i).Item("RECLMAIN").ToString)
                        dr1("Nro_Radicado_Muncipio") = CStr(tbldatos.Rows(i).Item("RECLRAMU").ToString)

                        If fun_Verificar_Dato_Fecha_Evento_Validated(CStr(tbldatos.Rows(i).Item("RECLFEMU").ToString)) = True Then
                            dr1("Fecha_Radicado_Municipio") = CStr(tbldatos.Rows(i).Item("RECLFEMU").ToString) & " _"
                        Else
                            dr1("Fecha_Radicado_Municipio") = CStr(tbldatos.Rows(i).Item("RECLFEMU").ToString)
                        End If

                        dr1("Nro_Radicado_OVC") = CStr(tbldatos.Rows(i).Item("RECLRAED").ToString)

                        If fun_Verificar_Dato_Fecha_Evento_Validated(CStr(tbldatos.Rows(i).Item("RECLFEED").ToString)) = True Then
                            dr1("Fecha_Radicado_OVC") = CStr(tbldatos.Rows(i).Item("RECLFEED").ToString) & " _"
                        Else
                            dr1("Fecha_Radicado_OVC") = CStr(tbldatos.Rows(i).Item("RECLFEED").ToString)
                        End If

                        dr1("Fecha_Ingreso") = CStr(tbldatos.Rows(i).Item("RECLFEIN").ToString) & " _"

                        If fun_Verificar_Dato_Fecha_Evento_Validated(CStr(tbldatos.Rows(i).Item("RECLFEMC").ToString)) = True Then
                            dr1("Fecha_Asignacion") = CStr(tbldatos.Rows(i).Item("RECLFEMC").ToString) & " _"
                        Else
                            dr1("Fecha_Asignacion") = CStr(tbldatos.Rows(i).Item("RECLFEMC").ToString)
                        End If

                        dr1("Dias_Trascurridos_Fecha_Ingreso") = CStr(tbldatos.Rows(i).Item("RECLDTFI").ToString)
                        dr1("Dias_Trascurridos_Fecha_Asignacion") = CStr(tbldatos.Rows(i).Item("RECLDTFM").ToString)

                        dt_CargaDatos.Rows.Add(dr1)

                    Next

                    Dim oExp As New cla_ExportarTablaExcel
                    oExp.DataTableToExcel(dt_CargaDatos)

                End If

            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub cmdSALIR_RECTIFICACIONES_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSALIR_RECTIFICACIONES.Click
        Me.Close()
    End Sub

#End Region

#Region "MENU REVISION DE AVALUO"

    Private Sub cmdRECONSULTAR_REVIAVAL_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdRECONSULTAR_REVIAVAL.Click
        boCONSULTA_REVIAVAL = False
        pro_ReconsultarRevisionDeAvaluo()
        pro_ListaDeValoresRevisionDeAvaluo()
    End Sub
    Private Sub cmdCONSULTAR_REVIAVAL_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCONSULTAR_REVIAVAL.Click

        Try
            vp_cedula = ""

            frm_consultar_BITAMOVI.ShowDialog()

            If vp_cedula <> "" Then
                boCONSULTA_REVIAVAL = True
            Else
                boCONSULTA_REVIAVAL = False
            End If

            pro_ReconsultarRevisionDeAvaluo()
            pro_ListaDeValoresRevisionDeAvaluo()

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub cmdExportarExcelRevisionDeAvaluo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExportarExcelRevisionDeAvaluo.Click

        Try
            If Me.dgvREVIAVAL_1.RowCount = 0 Then
                MessageBox.Show("No existe datos para exportar", "Mensaje ...", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1)
            Else
                Dim objdatos As New cla_REVIAVAL
                Dim tbldatos As New DataTable

                If boCONSULTA_REVIAVAL = False Then
                    tbldatos = objdatos.fun_Consultar_REVIAVAL_X_BITACORA
                Else
                    tbldatos = objdatos.fun_Consultar_REVIAVAL_X_BITACORA(CStr(Trim(vp_cedula)))
                End If

                If tbldatos.Rows.Count > 0 Then

                    ' Crea objeto registros
                    Dim dr1 As DataRow

                    ' crea la tabla
                    Dim dt_CargaDatos As New DataTable

                    dt_CargaDatos.Columns.Add(New DataColumn("Municipio", GetType(String)))
                    dt_CargaDatos.Columns.Add(New DataColumn("Corregimiento", GetType(String)))
                    dt_CargaDatos.Columns.Add(New DataColumn("Barrio", GetType(String)))
                    dt_CargaDatos.Columns.Add(New DataColumn("Manzana_Vereda", GetType(String)))
                    dt_CargaDatos.Columns.Add(New DataColumn("Predio", GetType(String)))
                    dt_CargaDatos.Columns.Add(New DataColumn("Edificio", GetType(String)))
                    dt_CargaDatos.Columns.Add(New DataColumn("Unidad_Predial", GetType(String)))
                    dt_CargaDatos.Columns.Add(New DataColumn("Sector", GetType(String)))
                    dt_CargaDatos.Columns.Add(New DataColumn("Vigencia", GetType(String)))
                    dt_CargaDatos.Columns.Add(New DataColumn("Matricula", GetType(String)))
                    dt_CargaDatos.Columns.Add(New DataColumn("Nro_Radicado_Muncipio", GetType(String)))
                    dt_CargaDatos.Columns.Add(New DataColumn("Fecha_Radicado_Municipio", GetType(String)))
                    dt_CargaDatos.Columns.Add(New DataColumn("Nro_Radicado_OVC", GetType(String)))
                    dt_CargaDatos.Columns.Add(New DataColumn("Fecha_Radicado_OVC", GetType(String)))
                    dt_CargaDatos.Columns.Add(New DataColumn("Fecha_Ingreso", GetType(String)))
                    dt_CargaDatos.Columns.Add(New DataColumn("Fecha_Asignacion", GetType(String)))
                    dt_CargaDatos.Columns.Add(New DataColumn("Dias_Trascurridos_Fecha_Ingreso", GetType(String)))
                    dt_CargaDatos.Columns.Add(New DataColumn("Dias_Trascurridos_Fecha_Asignacion", GetType(String)))

                    ' declara la variable
                    Dim i As Integer = 0

                    For i = 0 To tbldatos.Rows.Count - 1

                        dr1 = dt_CargaDatos.NewRow()

                        dr1("Municipio") = CStr(tbldatos.Rows(i).Item("REAVMUNI").ToString)
                        dr1("Corregimiento") = CStr(tbldatos.Rows(i).Item("REAVCORR").ToString)
                        dr1("Barrio") = CStr(tbldatos.Rows(i).Item("REAVBARR").ToString)
                        dr1("Manzana_Vereda") = CStr(tbldatos.Rows(i).Item("REAVMANZ").ToString)
                        dr1("Predio") = CStr(tbldatos.Rows(i).Item("REAVPRED").ToString)
                        dr1("Edificio") = CStr(tbldatos.Rows(i).Item("REAVEDIF").ToString)
                        dr1("Unidad_Predial") = CStr(tbldatos.Rows(i).Item("REAVUNPR").ToString)
                        dr1("Sector") = CStr(tbldatos.Rows(i).Item("REAVCLSE").ToString)
                        dr1("Vigencia") = CStr(tbldatos.Rows(i).Item("REAVVIGE").ToString)
                        dr1("Matricula") = CStr(tbldatos.Rows(i).Item("REAVMAIN").ToString)
                        dr1("Nro_Radicado_Muncipio") = CStr(tbldatos.Rows(i).Item("REAVRAMU").ToString)

                        If fun_Verificar_Dato_Fecha_Evento_Validated(CStr(tbldatos.Rows(i).Item("REAVFEMU").ToString)) = True Then
                            dr1("Fecha_Radicado_Municipio") = CStr(tbldatos.Rows(i).Item("REAVFEMU").ToString) & " _"
                        Else
                            dr1("Fecha_Radicado_Municipio") = CStr(tbldatos.Rows(i).Item("REAVFEMU").ToString)
                        End If

                        dr1("Nro_Radicado_OVC") = CStr(tbldatos.Rows(i).Item("REAVRAED").ToString)

                        If fun_Verificar_Dato_Fecha_Evento_Validated(CStr(tbldatos.Rows(i).Item("REAVFEED").ToString)) = True Then
                            dr1("Fecha_Radicado_OVC") = CStr(tbldatos.Rows(i).Item("REAVFEED").ToString) & " _"
                        Else
                            dr1("Fecha_Radicado_OVC") = CStr(tbldatos.Rows(i).Item("REAVFEED").ToString)
                        End If

                        dr1("Fecha_Ingreso") = CStr(tbldatos.Rows(i).Item("REAVFEIN").ToString) & " _"

                        If fun_Verificar_Dato_Fecha_Evento_Validated(CStr(tbldatos.Rows(i).Item("REAVFEMC").ToString)) = True Then
                            dr1("Fecha_Asignacion") = CStr(tbldatos.Rows(i).Item("REAVFEMC").ToString) & " _"
                        Else
                            dr1("Fecha_Asignacion") = CStr(tbldatos.Rows(i).Item("REAVFEMC").ToString)
                        End If

                        dr1("Dias_Trascurridos_Fecha_Ingreso") = CStr(tbldatos.Rows(i).Item("REAVDTFI").ToString)
                        dr1("Dias_Trascurridos_Fecha_Asignacion") = CStr(tbldatos.Rows(i).Item("REAVDTFM").ToString)

                        dt_CargaDatos.Rows.Add(dr1)

                    Next

                    Dim oExp As New cla_ExportarTablaExcel
                    oExp.DataTableToExcel(dt_CargaDatos)

                End If

            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub cmdSALIR_REVIAVA_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSALIR_REVIAVAL.Click
        Me.Close()
    End Sub

#End Region

#Region "FORMULARIO"

#Region "Load"

    Private Sub frm_TRABCAMP_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        boCONSULTA_RECTIFICACIONES = True
        boCONSULTA_REVIAVAL = True

        pro_ReconsultarRectificaciones()
        pro_ReconsultarRevisionDeAvaluo()
        Me.strBARRESTA.Items(0).Text = "Bitácora de movimiento"
    End Sub

#End Region

#Region "GotFocus"

    Private Sub frm_BITAMOVI_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.GotFocus
        pro_ListaDeValoresRectificaciones()
        pro_ListaDeValoresRevisionDeAvaluo()
        Me.dgvRECTIFICACIONES_1.Focus()
    End Sub

#End Region

#Region "LostFocus"

    Private Sub frm_BITAMOVI_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.LostFocus
        Me.dgvRECTIFICACIONES_1.Focus()
    End Sub

#End Region

#Region "KeyUp"

    Private Sub dgvRECTIFICACIONES_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgvRECTIFICACIONES_1.KeyUp, dgvRECTIFICACIONES_2.KeyUp, dgvRECTIFICACIONES_3.KeyUp
        If e.KeyCode = Keys.Down Or e.KeyCode = Keys.Up Or e.KeyCode = Keys.Enter Or e.KeyCode = Keys.PageUp Or e.KeyCode = Keys.PageDown Then
            pro_ListaDeValoresRectificaciones()
        End If
    End Sub
    Private Sub dgvREVIAVAL_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgvREVIAVAL_1.KeyUp, dgvREVIAVAL_2.KeyUp, dgvREVIAVAL_3.KeyUp
        If e.KeyCode = Keys.Down Or e.KeyCode = Keys.Up Or e.KeyCode = Keys.Enter Or e.KeyCode = Keys.PageUp Or e.KeyCode = Keys.PageDown Then
            pro_ListaDeValoresRevisionDeAvaluo()
        End If
    End Sub

#End Region

#Region "CellClick"

    Private Sub dgvRECTIFICACIONES_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvRECTIFICACIONES_1.CellClick, dgvRECTIFICACIONES_2.CellClick, dgvRECTIFICACIONES_3.CellClick
        pro_ListaDeValoresRectificaciones()
    End Sub
    Private Sub dgvREVIAVAL_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvREVIAVAL_1.CellClick, dgvREVIAVAL_2.CellClick, dgvREVIAVAL_3.CellClick
        pro_ListaDeValoresRevisionDeAvaluo()
    End Sub

#End Region

#End Region

End Class