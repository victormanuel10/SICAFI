Imports REGLAS_DEL_NEGOCIO
Imports System
Imports System.IO
Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration
Imports System.Text

Public Class frm_reasignar_MOVIALFA

    '=========================================
    '*** REASIGNAR MOVIMIENTO ALFANUMERICO ***
    '=========================================

#Region "VARIABLE"

    Dim inID_REGISTRO As Integer
    Dim inMOALSECU As Integer

    Private oEjecutar As New SqlCommand
    Private oConexion As New SqlConnection
    Private oAdapter As New SqlDataAdapter
    Private oReader As SqlDataReader
    Private ds As New DataSet
    Private dt As New DataTable

#End Region

#Region "CONSTRUCTOR"

    Public Sub New(ByVal inSECU As Integer)
        inMOALSECU = inSECU

        InitializeComponent()
        pro_LimpiarCampos()
        pro_inicializarControles()

    End Sub
    Public Sub New(ByVal inIDRE As Integer, ByVal inSECU As Integer)
        inID_REGISTRO = inIDRE
        inMOALSECU = inSECU

        InitializeComponent()
        pro_LimpiarCampos()
        pro_inicializarControles()

    End Sub

#End Region

#Region "FUNCIONES"

    Private Function fun_ConsultaNombreUsuario(ByVal stNUMEDOCU As String) As String

        Try
            ' declara la variable
            Dim stUSUARIO As String = ""

            ' declara la instancia
            Dim obCONTRASENA As New cla_CONTRASENA
            Dim dtCONTRASENA As New DataTable

            dtCONTRASENA = obCONTRASENA.fun_Buscar_CODIGO_CONTRASENA(Trim(stNUMEDOCU))

            If dtCONTRASENA.Rows.Count > 0 Then
                stUSUARIO = Trim(dtCONTRASENA.Rows(0).Item("CONTUSUA").ToString)
            End If

            Return stUSUARIO

        Catch ex As Exception
            Return Nothing
            MessageBox.Show(Err.Description)
        End Try

    End Function

#End Region

#Region "PROCEDIMIENTOS"

    Private Sub pro_LimpiarCampos()

        Me.cboMOALNUDO.DataSource = New DataTable

        Me.txtMOALNUDO.Text = ""
        Me.txtMOALFEAS.Text = ""
        Me.txtMOALOBSE.Text = ""

    End Sub
    Private Sub pro_inicializarControles()

        Try
            Me.txtMOALFEAS.Text = fun_fecha()

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub

#End Region

#Region "MENU"

    Private Sub cmdGUARDAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGUARDAR.Click

        Try
            ' instancia la clase
            Dim objVerifica As New cla_Verificar_Dato

            Dim boMOALNUDO As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.txtMOALNUDO)
            Dim boMOALFEAS As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Fecha(Me.txtMOALFEAS)
            Dim boMOALOBSE As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.txtMOALOBSE)
            Dim boMOALUSUA As Boolean = False

            Dim stMOALUSUA As String = fun_ConsultaNombreUsuario(Me.cboMOALNUDO.SelectedValue)

            If Trim(stMOALUSUA) = "" Then
                boMOALUSUA = False
                MessageBox.Show("El funcionario seleccionado no registra un perfil de usuario", "Mensaje...", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1)
            Else
                boMOALUSUA = True
            End If

            ' verifica los datos del formulario 
            If boMOALNUDO = True And _
               boMOALFEAS = True And _
               boMOALOBSE = True And _
               boMOALUSUA = True Then

                Dim stRECLOBSE_ACTUAL As String = ""
                Dim stRECLOBSE_NUEVA As String = Trim(Me.txtMOALOBSE.Text.ToString.ToUpper)

                Dim obMOALGEOG As New cla_MOVIALFA
                Dim dtAJUSGEOG As New DataTable

                dtAJUSGEOG = obMOALGEOG.fun_Buscar_ID_MOVIALFA(inID_REGISTRO)

                If dtAJUSGEOG.Rows.Count > 0 Then
                    stRECLOBSE_ACTUAL = Trim(dtAJUSGEOG.Rows(0).Item("MOALOBSE").ToString)
                End If

                Dim stNotaReasignacion As String = " Nota de registro: " & " El usuario: " & vp_usuario & " reasigno el tramite al usuario: " & Trim(stMOALUSUA) & " " & fun_fecha()

                If Trim(stRECLOBSE_ACTUAL) <> "" And Trim(stRECLOBSE_NUEVA) <> "" Then
                    stRECLOBSE_ACTUAL += vbCrLf & " Nota ingresada por " & vp_usuario & " " & fun_fecha() & " : " & stRECLOBSE_NUEVA & ". " & vbCrLf & stNotaReasignacion

                ElseIf Trim(stRECLOBSE_ACTUAL) = "" And Trim(stRECLOBSE_NUEVA) <> "" Then
                    stRECLOBSE_ACTUAL = " Nota ingresada por " & vp_usuario & " " & fun_fecha() & " : " & stRECLOBSE_NUEVA & ". " & vbCrLf & stNotaReasignacion

                End If

                ' ajusta el formato de la fecha
                Dim stMOALFEAS As String = CStr(Trim(Me.txtMOALFEAS.Text)).ToString.Replace("-", "/")

                ' buscar cadena de conexion
                Dim oCadenaConexion As New REGLAS_DEL_NEGOCIO.cla_ConnectionString
                Dim stCadenaConexion As String = oCadenaConexion.fun_ConnectionString

                ' crear conexión
                oAdapter = New SqlDataAdapter
                oConexion = New SqlConnection(stCadenaConexion)

                ' abre la conexion
                oConexion.Open()

                ' parametros de la consulta
                Dim ParametrosConsulta As String = ""

                ' Concatena la condicion de la consulta
                ParametrosConsulta += "update MOVIALFA "
                ParametrosConsulta += "set MOALOBSE = '" & stRECLOBSE_ACTUAL & "', "
                ParametrosConsulta += "MOALUSUA = '" & CStr(Trim(stMOALUSUA)) & "', "
                ParametrosConsulta += "MOALNUDO = '" & CStr(Trim(Me.txtMOALNUDO.Text)) & "', "
                ParametrosConsulta += "MOALFEAS = '" & CStr(Trim(stMOALFEAS)) & "' "
                ParametrosConsulta += "where MOALIDRE = '" & inID_REGISTRO & "' "

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

                Dim inNroIdRe As New frm_MOVIALFA(inID_REGISTRO)

                mod_MENSAJE.Se_Guardaron_Los_Datos_Correctamente()
                Me.cboMOALNUDO.Focus()
                Me.Close()

            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub cmdCANCELAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSALIR.Click
        Me.cboMOALNUDO.Focus()
        Me.Close()
    End Sub

#End Region

#Region "FORMULARIO"

#Region "KeyPress"

    Private Sub txt_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboMOALNUDO.KeyPress, txtMOALFEAS.KeyPress, txtMOALOBSE.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Or e.KeyChar = Convert.ToChar(Keys.Tab) Then
            pp_pro_SaltarCampo()
        End If
    End Sub

#End Region

#Region "GotFocus"

    Private Sub txt_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtMOALFEAS.GotFocus, txtMOALOBSE.GotFocus
        pp_pro_SobrearCampo(sender)
        pp_pro_DescripcionCampo(Me.strBARRESTA.Items(0), sender)
    End Sub
    Private Sub cbo_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboMOALNUDO.GotFocus
        pp_pro_DescripcionCampo(Me.strBARRESTA.Items(0), sender)
    End Sub
    Private Sub cmd_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdGUARDAR.GotFocus, cmdSALIR.GotFocus
        pp_pro_DescripcionCampo(Me.strBARRESTA.Items(0), sender)
    End Sub

#End Region

#Region "KeyDown"

    Private Sub cboMOALNUDO_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboMOALNUDO.KeyDown
        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
            fun_Cargar_ComboBox_Con_Datos_Activos_USUARIO_Descripcion(Me.cboMOALNUDO, Me.cboMOALNUDO.SelectedIndex)
        End If
    End Sub

#End Region

#Region "SelectedIndexChanged"

    Private Sub cboMOALNUDO_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboMOALNUDO.SelectedIndexChanged
        Me.txtMOALNUDO.Text = CType(fun_Buscar_Lista_Valores_USUARIO_Codigo(Me.cboMOALNUDO), String)
    End Sub

#End Region

#Region "Click"

    Private Sub cboMOALNUDO_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboMOALNUDO.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_USUARIO_Descripcion(Me.cboMOALNUDO, Me.cboMOALNUDO.SelectedIndex)
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