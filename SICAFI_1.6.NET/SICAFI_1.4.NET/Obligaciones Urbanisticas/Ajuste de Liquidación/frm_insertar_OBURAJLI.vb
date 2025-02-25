Imports REGLAS_DEL_NEGOCIO
Imports System
Imports System.IO
Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration
Imports System.Text

Public Class frm_insertar_OBURAJLI

    '================================================================
    '*** INSERTAR AJUSTE DE LIQUIDACION OBLIGACIONES URBANISTICAS ***
    '================================================================

#Region "VARIABLE"

    Private oEjecutar As New SqlCommand
    Private oConexion As New SqlConnection
    Private oAdapter As New SqlDataAdapter
    Private oReader As SqlDataReader
    Private ds As New DataSet
    Private dt As New DataTable

    Dim inOUALIDRE As Integer
    Dim inOUIGIDRE As Integer
    Dim inOUIGSECU As Integer
    Dim stOUIGCLEN As String
    Dim inOUIGNURE As Integer
    Dim stOUIGFERE As String
    Dim inOUIGCLOU As Integer
    Dim inOUIGNULI As Integer
    Dim inOUIGNUAL As Integer

    Dim boINSERTAR As Boolean = False
    Dim boMODIFICAR As Boolean = False

    Dim vl_loLiquidacionFormulada As Long = 0
    Dim vl_loLiquidacionAjustada As Long = 0

#End Region

#Region "CONSTRUCTOR"

    Public Sub New(ByVal inIDRE As Integer, _
                   ByVal inSECU As Integer, _
                   ByVal stCLEN As String, _
                   ByVal inNURE As Integer, _
                   ByVal stFERE As String, _
                   ByVal inCLOU As Integer, _
                   ByVal inNULI As Integer, _
                   ByVal inNUAL As Integer)

        inOUALIDRE = inIDRE
        inOUIGSECU = inSECU
        stOUIGCLEN = stCLEN
        inOUIGNURE = inNURE
        stOUIGFERE = stFERE
        inOUIGCLOU = inCLOU
        inOUIGNULI = inNULI
        inOUIGNUAL = inNUAL

        boMODIFICAR = True

        InitializeComponent()
        pro_LimpiarCampos()
        pro_inicializarControles()

    End Sub
    Public Sub New(ByVal inIDRE As Integer, _
                   ByVal inSECU As Integer, _
                   ByVal stCLEN As String, _
                   ByVal inNURE As Integer, _
                   ByVal stFERE As String, _
                   ByVal inCLOU As Integer, _
                   ByVal inNULI As Integer)

        inOUIGIDRE = inIDRE
        inOUIGSECU = inSECU
        stOUIGCLEN = stCLEN
        inOUIGNURE = inNURE
        stOUIGFERE = stFERE
        inOUIGCLOU = inCLOU
        inOUIGNULI = inNULI

        boINSERTAR = True

        InitializeComponent()
        pro_LimpiarCampos()
        pro_inicializarControles()

    End Sub

#End Region

#Region "PROCEDIMIENTOS"

    Private Sub pro_LimpiarCampos()

        Me.txtOUALNUAL.Text = ""
        Me.txtOUALLIQU.Text = ""
        Me.txtOUALLIAJ.Text = ""
        Me.txtOUALOBSE.Text = ""

    End Sub
    Private Sub pro_inicializarControles()

        Try
            If boMODIFICAR = True Then

                ' instancia la clase
                Dim objdatos As New cla_OBURAJLI
                Dim tbl As New DataTable

                tbl = objdatos.fun_Buscar_ID_OBURAJLI(inOUALIDRE)

                If tbl.Rows.Count > 0 Then

                    Me.Text = "Modificar registro"
                    Me.fraCEDUCATA.Text = "MODIFICAR AJUSTE DE LIQUIDACIÓN"

                    Me.txtOUALLIQU.Text = fun_Formato_Mascara_Pesos_Enteros(Trim(tbl.Rows(0).Item("OUALLIQU")))
                    Me.txtOUALLIAJ.Text = fun_Formato_Mascara_Pesos_Enteros(Trim(tbl.Rows(0).Item("OUALLIAJ")))
                    Me.txtOUALOBSE.Text = Trim(tbl.Rows(0).Item("OUALOBSE"))

                End If

            ElseIf boINSERTAR = True Then

                ' instancia la clase
                Dim objdatos As New cla_OBURINGE
                Dim tbl As New DataTable

                tbl = objdatos.fun_Buscar_ID_OBURINGE(inOUIGIDRE)

                If tbl.Rows.Count > 0 Then

                    Me.Text = "Modificar registro"
                    Me.fraCEDUCATA.Text = "MODIFICAR AJUSTE DE LIQUIDACIÓN"

                    Me.txtOUALLIQU.Text = fun_Formato_Mascara_Pesos_Enteros(Trim(tbl.Rows(0).Item("OUIGLIQU")))

                End If

                Me.Text = "Insertar registro"
                Me.fraCEDUCATA.Text = "INSERTAR AJUSTE DE LIQUIDACIÓN"

            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub pro_ActualizaLiquidacionConJustesObligacionUrbanistica()

        Try
            ' buscar cadena de conexion
            Dim oCadenaConexion As New REGLAS_DEL_NEGOCIO.cla_ConnectionString
            Dim stCadenaConexion As String = oCadenaConexion.fun_ConnectionString

            ' crear conexión
            oAdapter = New SqlDataAdapter
            oConexion = New SqlConnection(stCadenaConexion)

            ' abre la conexion
            oConexion.Open()

            ' declara la variable
            Dim boOBURAJLI As Boolean = True

            ' parametros de la consulta
            Dim ParametrosConsulta As String = ""

            ' Concatena la condicion de la consulta
            ParametrosConsulta += "UPDATE "
            ParametrosConsulta += "OBLIURBA "
            ParametrosConsulta += "SET "
            ParametrosConsulta += "OBURAJLI = '" & CBool(boOBURAJLI) & "' "
            ParametrosConsulta += "WHERE "
            ParametrosConsulta += "OBURSECU = '" & CInt(inOUIGSECU) & "' AND "
            ParametrosConsulta += "OBURCLEN = '" & CStr(Trim(stOUIGCLEN)) & "' AND "
            ParametrosConsulta += "OBURNURE = '" & CInt(inOUIGNURE) & "' AND "
            ParametrosConsulta += "OBURFERE = '" & CStr(Trim(stOUIGFERE)) & "' "

            ' ejecuta la consulta
            oEjecutar = New SqlCommand(ParametrosConsulta, oConexion)

            ' procesa la consulta 
            oEjecutar.CommandTimeout = 0
            oEjecutar.CommandType = CommandType.Text

            oReader = oEjecutar.ExecuteReader

            ' cierra la conexion
            oConexion.Close()
            oReader = Nothing

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub pro_ActualizaLiquidacionConJustesInformacionGeneral(ByVal loOUIGLIQU As Long, ByVal boOUIGAJLI As Boolean)

        Try
            ' buscar cadena de conexion
            Dim oCadenaConexion As New REGLAS_DEL_NEGOCIO.cla_ConnectionString
            Dim stCadenaConexion As String = oCadenaConexion.fun_ConnectionString

            ' crear conexión
            oAdapter = New SqlDataAdapter
            oConexion = New SqlConnection(stCadenaConexion)

            ' abre la conexion
            oConexion.Open()

            ' declara la variable
            Dim boOBURAJLI As Boolean = True

            ' parametros de la consulta
            Dim ParametrosConsulta As String = ""

            ' Concatena la condicion de la consulta
            ParametrosConsulta += "UPDATE "
            ParametrosConsulta += "OBURINGE "
            ParametrosConsulta += "SET "
            ParametrosConsulta += "OUIGLIQU = '" & CLng(loOUIGLIQU) & "', "
            ParametrosConsulta += "OUIGAJLI = '" & CBool(boOBURAJLI) & "' "
            ParametrosConsulta += "WHERE "
            ParametrosConsulta += "OUIGSECU = '" & CInt(inOUIGSECU) & "' AND "
            ParametrosConsulta += "OUIGCLEN = '" & CStr(Trim(stOUIGCLEN)) & "' AND "
            ParametrosConsulta += "OUIGNURE = '" & CInt(inOUIGNURE) & "' AND "
            ParametrosConsulta += "OUIGFERE = '" & CStr(Trim(stOUIGFERE)) & "' AND "
            ParametrosConsulta += "OUIGCLOU = '" & CInt(inOUIGCLOU) & "' AND "
            ParametrosConsulta += "OUIGNULI = '" & CInt(inOUIGNULI) & "' "

            ' ejecuta la consulta
            oEjecutar = New SqlCommand(ParametrosConsulta, oConexion)

            ' procesa la consulta 
            oEjecutar.CommandTimeout = 0
            oEjecutar.CommandType = CommandType.Text

            oReader = oEjecutar.ExecuteReader

            ' cierra la conexion
            oConexion.Close()
            oReader = Nothing

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub

#End Region

#Region "FUNCIONES"

    Private Function fun_NumeroDeSecuenciaDeRegistro() As Integer

        Try
            Dim inOBURSECU As Integer = 0

            Dim objdatos5 As New cla_OBURAJLI
            Dim tbl10 As New DataTable

            tbl10 = objdatos5.fun_Buscar_SECUENCIA_X_OBURAJLI(inOUIGSECU, Trim(stOUIGCLEN), inOUIGNURE, Trim(stOUIGFERE), inOUIGCLOU, inOUIGNULI)

            If tbl10.Rows.Count = 0 Then
                inOBURSECU = 1
            Else
                Dim i As Integer
                Dim NroMayor As Integer
                Dim Posicion As Integer

                Posicion = Val(tbl10.Rows(0).Item("OUALNUAL"))

                For i = 0 To tbl10.Rows.Count - 1
                    NroMayor = Val(tbl10.Rows(i).Item("OUALNUAL"))

                    If NroMayor > Posicion Then
                        inOBURSECU = NroMayor
                        Posicion = NroMayor
                    Else
                        inOBURSECU = Posicion
                    End If
                Next

                inOBURSECU += 1
            End If

            Return inOBURSECU

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Function

#End Region

#Region "MENU"

    Private Sub cmdGUARDAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGUARDAR.Click

        Try
            ' inserta el registro
            If boINSERTAR = True Then

                ' quita letras
                Me.txtOUALLIQU.Text = fun_Quita_Letras(Trim(Me.txtOUALLIQU.Text))
                Me.txtOUALLIAJ.Text = fun_Quita_Letras(Trim(Me.txtOUALLIAJ.Text))

                Me.txtOUALNUAL.Text = fun_NumeroDeSecuenciaDeRegistro()

                ' instancia la clase
                Dim objdatos As New cla_OBURAJLI

                Dim boLLAVEPRIMARIA As Boolean = objdatos.fun_Verifica_llave_Primaria_OBURAJLI(stOUIGCLEN, inOUIGNURE, stOUIGFERE, inOUIGCLOU, inOUIGNULI, Me.txtOUALNUAL)

                ' instancia la clase
                Dim objVerifica As New cla_Verificar_Dato

                Dim boOUALLIQU As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Numerico(Me.txtOUALLIQU)
                Dim boOUALLIAJ As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Numerico(Me.txtOUALLIAJ)
                Dim boOUALOBSE As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.txtOUALOBSE)

                ' verifica los datos del formulario 
                If boLLAVEPRIMARIA = True And _
                   boOUALLIQU = True And _
                   boOUALLIAJ = True And _
                   boOUALOBSE = True Then

                    Dim objdatos22 As New cla_OBURAJLI

                    If (objdatos22.fun_Insertar_OBURAJLI(inOUIGSECU, _
                                                         stOUIGCLEN, _
                                                         inOUIGNURE, _
                                                         stOUIGFERE, _
                                                         inOUIGCLOU, _
                                                         inOUIGNULI, _
                                                         Me.txtOUALNUAL.Text, _
                                                         Me.txtOUALLIQU.Text, _
                                                         Me.txtOUALLIAJ.Text, _
                                                         Me.txtOUALOBSE.Text)) = True Then

                        ' actualiza la obligacion urbanistica
                        pro_ActualizaLiquidacionConJustesObligacionUrbanistica()

                        ' actualiza la informacion general
                        pro_ActualizaLiquidacionConJustesInformacionGeneral(Me.txtOUALLIAJ.Text, True)

                        ' mensaje de actualizacion
                        mod_MENSAJE.Se_Guardaron_Los_Datos_Correctamente()
                        Me.txtOUALLIAJ.Focus()
                        Me.Close()
                    Else
                        mod_MENSAJE.No_Se_Guardo_El_Registro_En_La_Base_De_Datos()
                    End If

                End If

                ' modifica el registro
            ElseIf boMODIFICAR = True Then

                 ' quita letras
                Me.txtOUALLIQU.Text = fun_Quita_Letras(Trim(Me.txtOUALLIQU.Text))
                Me.txtOUALLIAJ.Text = fun_Quita_Letras(Trim(Me.txtOUALLIAJ.Text))

                ' instancia la clase
                Dim objVerifica As New cla_Verificar_Dato

                Dim boOUALLIQU As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Numerico(Me.txtOUALLIQU)
                Dim boOUALLIAJ As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Numerico(Me.txtOUALLIAJ)
                Dim boOUALOBSE As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.txtOUALOBSE)

                ' verifica los datos del formulario 
                If boOUALLIQU = True And _
                   boOUALLIAJ = True And _
                   boOUALOBSE = True Then

                    Dim objdatos22 As New cla_OBURAJLI

                    If (objdatos22.fun_Actualizar_OBURAJLI(inOUALIDRE, _
                                                           inOUIGSECU, _
                                                           stOUIGCLEN, _
                                                           inOUIGNURE, _
                                                           stOUIGFERE, _
                                                           inOUIGCLOU, _
                                                           inOUIGNULI, _
                                                           inOUIGNUAL, _
                                                           Me.txtOUALLIQU.Text, _
                                                           Me.txtOUALLIAJ.Text, _
                                                           Me.txtOUALOBSE.Text)) = True Then

                        ' actualiza la obligacion urbanistica
                        pro_ActualizaLiquidacionConJustesObligacionUrbanistica()

                        ' actualiza la informacion general
                        pro_ActualizaLiquidacionConJustesInformacionGeneral(Me.txtOUALLIAJ.Text, True)

                        mod_MENSAJE.Se_Modificaron_Los_Datos_Correctamente()
                        Me.txtOUALLIAJ.Focus()
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
        Me.txtOUALLIAJ.Focus()
        Me.Close()
    End Sub

#End Region

#Region "FORMULARIO"

#Region "KeyPress"

    Private Sub txt_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtOUALLIQU.KeyPress, txtOUALLIAJ.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Or e.KeyChar = Convert.ToChar(Keys.Tab) Then
            pp_pro_SaltarCampo()
        End If
    End Sub

#End Region

#Region "GotFocus"

    Private Sub txt_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtOUALLIQU.GotFocus, txtOUALLIAJ.GotFocus
        pp_pro_SobrearCampo(sender)
        pp_pro_DescripcionCampo(Me.strBARRESTA.Items(0), sender)
    End Sub

#End Region

#Region "Validated"

    Private Sub txtOUIGAVCA_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtOUALLIQU.Validated, txtOUALLIAJ.Validated

        If Trim(sender.text) = "" Then
            sender.text = ""
        Else

            If fun_Verificar_Dato_Numerico_Evento_Validated(Me.txtOUALLIQU.Text) = True Then
                Me.txtOUALLIQU.Text = fun_Formato_Mascara_Pesos_Enteros(Me.txtOUALLIQU.Text)
            End If

            If fun_Verificar_Dato_Numerico_Evento_Validated(Me.txtOUALLIAJ.Text) = True Then
                Me.txtOUALLIAJ.Text = fun_Formato_Mascara_Pesos_Enteros(Me.txtOUALLIAJ.Text)
            End If

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