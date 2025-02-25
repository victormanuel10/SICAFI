Imports REGLAS_DEL_NEGOCIO
Imports System
Imports System.IO
Imports System.Data
Imports System.Data.Sqlclient
Imports System.Configuration
Imports System.Text

Public Class frm_Marcar_Predio_Como_Conjunto

    '===================================
    '*** MARCAR PREDIO COMO CONJUNTO ***
    '===================================

#Region "INSTANCIAR FORMULARIO"

    Private Shared frm_Instance = Nothing

    Public Shared Function instance() As frm_Marcar_Predio_Como_Conjunto
        If frm_Instance Is Nothing OrElse frm_Instance.isdisposed = True Then
            frm_Instance = New frm_Marcar_Predio_Como_Conjunto
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

#Region "VARIABLES"

    ' declara variables de conexion
    Private oEjecutar As New SqlCommand
    Private oConexion As New SqlConnection
    Private oAdapter As New SqlDataAdapter
    Private oReader As SqlDataReader
    Private ds As New DataSet
    Private dt As New DataTable

    Private dt_FIPRLIND As DataTable
    Private dt_FIPRLIND_DUPLICADO As DataTable
    Private dt_FIPRCART As DataTable

    Private inProceso As Integer

#End Region

#Region "PROCEDIMIENTOS"

    Private Sub pro_LimpiarCampos()

        txtFIPRFIIN.Text = "0"
        txtFIPRFIFI.Text = "999999999"
        txtFIPRTIFI.Text = "%"
        txtFIPRMUNI.Text = "%"
        txtFIPRCORR.Text = "%"
        txtFIPRBARR.Text = "%"
        txtFIPRMANZ.Text = "%"
        txtFIPRPRED.Text = "%"
        txtFIPREDIF.Text = "%"
        txtFIPRUNPR.Text = "%"
        txtFIPRCLSE.Text = "%"
        txtFIPRCASU.Text = "%"
        txtFIPRCAPR.Text = "%"
        txtFIPRMOAD.Text = "%"
        chkPredioEnConjunto.Checked = False
        lblFIPRCLSE.Text = ""
        lblFIPRCASU.Text = ""
        lblFIPRCAPR.Text = ""
        lblFIPRMOAD.Text = ""
        strBARRESTA.Items(2).Text = "Registros : 0"

        Me.cmdDepurarLinderos.Enabled = True
        Me.cmdDepurarCartografia.Enabled = True

    End Sub

#End Region

#Region "MENU"

    Private Sub cmdDepurarLinderos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDepurarLinderos.Click

        Try
            ' buscar cadena de conexion
            Dim oCadenaConexion As New REGLAS_DEL_NEGOCIO.cla_ConnectionString
            Dim stCadenaConexion As String = oCadenaConexion.fun_ConnectionString

            ' crea el datatable
            dt = New DataTable

            ' crear conexión
            oAdapter = New SqlDataAdapter
            oConexion = New SqlConnection(stCadenaConexion)

            ' abre la conexion
            oConexion.Open()

            ' variable de la consulta
            Dim ParametrosConsulta As String = ""

            ' Concatena la condicion de la consulta
            ParametrosConsulta += "Select FIPRNUFI "
            ParametrosConsulta += "From FichPred where "
            ParametrosConsulta += "FiprMuni like '" & Trim(Me.txtFIPRMUNI.Text) & "' and "
            ParametrosConsulta += "FiprCorr like '" & Trim(Me.txtFIPRCORR.Text) & "' and "
            ParametrosConsulta += "FiprBarr like '" & Trim(Me.txtFIPRBARR.Text) & "' and "
            ParametrosConsulta += "FiprManz like '" & Trim(Me.txtFIPRMANZ.Text) & "' and "
            ParametrosConsulta += "FiprPred like '" & Trim(Me.txtFIPRPRED.Text) & "' and "
            ParametrosConsulta += "FiprEdif like '" & Trim(Me.txtFIPREDIF.Text) & "' and "
            ParametrosConsulta += "FiprUnpr like '" & Trim(Me.txtFIPRUNPR.Text) & "' and "
            ParametrosConsulta += "FiprClse like '" & Trim(Me.txtFIPRCLSE.Text) & "' and "
            ParametrosConsulta += "FiprTifi like '" & Trim(Me.txtFIPRTIFI.Text) & "' and "
            ParametrosConsulta += "FiprNufi between '" & Trim(Me.txtFIPRFIIN.Text) & "' and '" & Trim(Me.txtFIPRFIFI.Text) & "' and "
            ParametrosConsulta += "FiprEsta = 'ac' "
            ParametrosConsulta += "Order by FiprMuni,FiprCorr,FiprBarr,FiprManz,FiprPred,FiprEdif,FiprUnpr "

            ' ejecuta la consulta
            oEjecutar = New SqlCommand(ParametrosConsulta, oConexion)

            ' procesa la consulta 
            oEjecutar.CommandTimeout = 0
            oEjecutar.CommandType = CommandType.Text
            oAdapter.SelectCommand = oEjecutar

            ' llena el datatable 
            oAdapter.Fill(dt)

            ' cierra la conexion
            oConexion.Close()

            ' Valores predeterminados ProgressBar
            inProceso = 0
            pbPROCESO.Value = 0
            pbPROCESO.Maximum = dt.Rows.Count
            Timer1.Enabled = True

            Me.cmdDepurarLinderos.Enabled = False

            If dt.Rows.Count > 0 Then

                Dim i As Integer = 0

                For i = 0 To dt.Rows.Count - 1

                    Dim inFIPRNUFI As Integer = dt.Rows(i).Item("FIPRNUFI")

                    ' CONSULTA LA FICHA

                    ' buscar cadena de conexion
                    Dim oCadenaConexion2 As New REGLAS_DEL_NEGOCIO.cla_ConnectionString
                    Dim stCadenaConexion2 As String = oCadenaConexion2.fun_ConnectionString

                    ' crea el datatable
                    Dim dt2 As New DataTable

                    ' crear conexión
                    oAdapter = New SqlDataAdapter
                    oConexion = New SqlConnection(stCadenaConexion2)

                    ' abre la conexion
                    oConexion.Open()

                    ' variable de la consulta
                    Dim ParametrosConsulta2 As String = ""

                    ' Concatena la condicion de la consulta
                    ParametrosConsulta2 += "Select fplinufi, fplipuca, fplicoli, fpliesta, count(1) "
                    ParametrosConsulta2 += "From FIPRLIND where "
                    ParametrosConsulta2 += "exists(select 1 from fichpred where fiprnufi = fplinufi and "
                    ParametrosConsulta2 += "fiprnufi = '" & inFIPRNUFI & "') "
                    ParametrosConsulta2 += "group by fplinufi, fplipuca, fplicoli, fpliesta  "
                    ParametrosConsulta2 += "having count(1) > 1  "

                    ' ejecuta la consulta
                    oEjecutar = New SqlCommand(ParametrosConsulta2, oConexion)

                    ' procesa la consulta 
                    oEjecutar.CommandTimeout = 0
                    oEjecutar.CommandType = CommandType.Text
                    oAdapter.SelectCommand = oEjecutar

                    ' llena el datatable 
                    oAdapter.Fill(dt2)

                    ' cierra la conexion
                    oConexion.Close()

                    ' CONSULTA EL LINDERO

                    If dt2.Rows.Count > 0 Then

                        Dim ii As Integer = 0

                        For ii = 0 To dt2.Rows.Count - 1

                            ' buscar cadena de conexion
                            Dim oCadenaConexion3 As New REGLAS_DEL_NEGOCIO.cla_ConnectionString
                            Dim stCadenaConexion3 As String = oCadenaConexion3.fun_ConnectionString

                            ' crea el datatable
                            Dim dt3 As New DataTable

                            ' crear conexión
                            oAdapter = New SqlDataAdapter
                            oConexion = New SqlConnection(stCadenaConexion3)

                            ' abre la conexion
                            oConexion.Open()

                            ' variable de la consulta
                            Dim ParametrosConsulta3 As String = ""

                            ' Concatena la condicion de la consulta
                            ParametrosConsulta3 += "Select top 1 fpliidre, fplinufi, fplipuca, fplicoli, fpliesta "
                            ParametrosConsulta3 += "From FIPRLIND where "
                            ParametrosConsulta3 += "fplinufi = '" & dt2.Rows(ii).Item("fplinufi") & "' and "
                            ParametrosConsulta3 += "fplipuca = '" & dt2.Rows(ii).Item("fplipuca") & "' and "
                            ParametrosConsulta3 += "fplicoli = '" & dt2.Rows(ii).Item("fplicoli") & "' and "
                            ParametrosConsulta3 += "fpliesta = '" & dt2.Rows(ii).Item("fpliesta") & "' "

                            ' ejecuta la consulta
                            oEjecutar = New SqlCommand(ParametrosConsulta3, oConexion)

                            ' procesa la consulta 
                            oEjecutar.CommandTimeout = 0
                            oEjecutar.CommandType = CommandType.Text
                            oAdapter.SelectCommand = oEjecutar

                            ' llena el datatable 
                            oAdapter.Fill(dt3)

                            ' cierra la conexion
                            oConexion.Close()

                            ' ELIMINA EL COLINDATE

                            Dim inIDRELIND As Integer = CInt(dt3.Rows(0).Item("FPLIIDRE"))

                            Dim objdatos1 As New cla_FIPRLIND
                            objdatos1.fun_Eliminar_FIPRLIND(inIDRELIND)

                        Next

                    End If

                    ' Incrementa la barra
                    inProceso = inProceso + 1
                    pbPROCESO.Value = inProceso

                Next

            End If

            ' inicia la barra de progreso
            pbPROCESO.Value = 0

            Me.cmdDepurarLinderos.Enabled = True

            mod_MENSAJE.Se_Modificaron_Los_Datos_Correctamente()

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub cmdDepurarCartografia_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDepurarCartografia.Click

        Try
            ' buscar cadena de conexion
            Dim oCadenaConexion As New REGLAS_DEL_NEGOCIO.cla_ConnectionString
            Dim stCadenaConexion As String = oCadenaConexion.fun_ConnectionString

            ' crea el datatable
            dt = New DataTable

            ' crear conexión
            oAdapter = New SqlDataAdapter
            oConexion = New SqlConnection(stCadenaConexion)

            ' abre la conexion
            oConexion.Open()

            ' variable de la consulta
            Dim ParametrosConsulta As String = ""

            ' Concatena la condicion de la consulta
            ParametrosConsulta += "Select FIPRNUFI "
            ParametrosConsulta += "From FichPred where "
            ParametrosConsulta += "FiprMuni like '" & Trim(Me.txtFIPRMUNI.Text) & "' and "
            ParametrosConsulta += "FiprCorr like '" & Trim(Me.txtFIPRCORR.Text) & "' and "
            ParametrosConsulta += "FiprBarr like '" & Trim(Me.txtFIPRBARR.Text) & "' and "
            ParametrosConsulta += "FiprManz like '" & Trim(Me.txtFIPRMANZ.Text) & "' and "
            ParametrosConsulta += "FiprPred like '" & Trim(Me.txtFIPRPRED.Text) & "' and "
            ParametrosConsulta += "FiprEdif like '" & Trim(Me.txtFIPREDIF.Text) & "' and "
            ParametrosConsulta += "FiprUnpr like '" & Trim(Me.txtFIPRUNPR.Text) & "' and "
            ParametrosConsulta += "FiprClse like '" & Trim(Me.txtFIPRCLSE.Text) & "' and "
            ParametrosConsulta += "FiprTifi like '" & Trim(Me.txtFIPRTIFI.Text) & "' and "
            ParametrosConsulta += "FiprNufi between '" & Trim(Me.txtFIPRFIIN.Text) & "' and '" & Trim(Me.txtFIPRFIFI.Text) & "' and "
            ParametrosConsulta += "FiprEsta = 'ac' "
            ParametrosConsulta += "Order by FiprMuni,FiprCorr,FiprBarr,FiprManz,FiprPred,FiprEdif,FiprUnpr "

            ' ejecuta la consulta
            oEjecutar = New SqlCommand(ParametrosConsulta, oConexion)

            ' procesa la consulta 
            oEjecutar.CommandTimeout = 0
            oEjecutar.CommandType = CommandType.Text
            oAdapter.SelectCommand = oEjecutar

            ' llena el datatable 
            oAdapter.Fill(dt)

            ' cierra la conexion
            oConexion.Close()

            ' Valores predeterminados ProgressBar
            inProceso = 0
            pbPROCESO.Value = 0
            pbPROCESO.Maximum = dt.Rows.Count
            Timer1.Enabled = True

            Me.cmdDepurarCartografia.Enabled = False

            If dt.Rows.Count > 0 Then

                Dim i As Integer = 0

                For i = 0 To dt.Rows.Count - 1

                    Dim inFIPRNUFI As Integer = dt.Rows(i).Item("FIPRNUFI")

                    ' CONSULTA LA FICHA

                    ' buscar cadena de conexion
                    Dim oCadenaConexion2 As New REGLAS_DEL_NEGOCIO.cla_ConnectionString
                    Dim stCadenaConexion2 As String = oCadenaConexion2.fun_ConnectionString

                    ' crea el datatable
                    Dim dt2 As New DataTable

                    ' crear conexión
                    oAdapter = New SqlDataAdapter
                    oConexion = New SqlConnection(stCadenaConexion2)

                    ' abre la conexion
                    oConexion.Open()

                    ' variable de la consulta
                    Dim ParametrosConsulta2 As String = ""

                    ' Concatena la condicion de la consulta
                    ParametrosConsulta2 += "Select fpcanufi, fpcaplan, fpcavent, fpcaesgr, fpcavigr, fpcavuel, fpcafaja, fpcafoto, fpcaviae, fpcaesae, fpcaesta , count(1) "
                    ParametrosConsulta2 += "From fiprcart where "
                    ParametrosConsulta2 += "exists(select 1 from fichpred where fiprnufi = fpcanufi and "
                    ParametrosConsulta2 += "fiprnufi = '" & inFIPRNUFI & "') "
                    ParametrosConsulta2 += "group by fpcanufi, fpcaplan, fpcavent, fpcaesgr, fpcavigr, fpcavuel, fpcafaja, fpcafoto, fpcaviae, fpcaesae, fpcaesta  "
                    ParametrosConsulta2 += "having count(1) > 1  "

                    ' ejecuta la consulta
                    oEjecutar = New SqlCommand(ParametrosConsulta2, oConexion)

                    ' procesa la consulta 
                    oEjecutar.CommandTimeout = 0
                    oEjecutar.CommandType = CommandType.Text
                    oAdapter.SelectCommand = oEjecutar

                    ' llena el datatable 
                    oAdapter.Fill(dt2)

                    ' cierra la conexion
                    oConexion.Close()

                    ' CONSULTA EL LINDERO

                    If dt2.Rows.Count > 0 Then

                        Dim ii As Integer = 0

                            For ii = 0 To dt2.Rows.Count - 1

                                ' buscar cadena de conexion
                                Dim oCadenaConexion3 As New REGLAS_DEL_NEGOCIO.cla_ConnectionString
                                Dim stCadenaConexion3 As String = oCadenaConexion3.fun_ConnectionString

                                ' crea el datatable
                                Dim dt3 As New DataTable

                                ' crear conexión
                                oAdapter = New SqlDataAdapter
                                oConexion = New SqlConnection(stCadenaConexion3)

                                ' abre la conexion
                                oConexion.Open()

                                ' variable de la consulta
                                Dim ParametrosConsulta3 As String = ""

                                ' Concatena la condicion de la consulta
                                ParametrosConsulta3 += "Select top 1 fpcaidre,fpcanufi, fpcaplan, fpcavent, fpcaesgr, fpcavigr, fpcavuel, fpcafaja, fpcafoto, fpcaviae, fpcaesae, fpcaesta "
                                ParametrosConsulta3 += "From FIPRCART where "
                                ParametrosConsulta3 += "fpcanufi = '" & dt2.Rows(ii).Item("fpcanufi") & "' and "
                                ParametrosConsulta3 += "fpcaplan = '" & dt2.Rows(ii).Item("fpcaplan") & "' and "
                                ParametrosConsulta3 += "fpcavent = '" & dt2.Rows(ii).Item("fpcavent") & "' and "
                                ParametrosConsulta3 += "fpcaesgr = '" & dt2.Rows(ii).Item("fpcaesgr") & "' and "
                                ParametrosConsulta3 += "fpcavigr = '" & dt2.Rows(ii).Item("fpcavigr") & "' and "
                                ParametrosConsulta3 += "fpcavuel = '" & dt2.Rows(ii).Item("fpcavuel") & "' and "
                                ParametrosConsulta3 += "fpcafaja = '" & dt2.Rows(ii).Item("fpcafaja") & "' and "
                                ParametrosConsulta3 += "fpcafoto = '" & dt2.Rows(ii).Item("fpcafoto") & "' and "
                                ParametrosConsulta3 += "fpcaviae = '" & dt2.Rows(ii).Item("fpcaviae") & "' and "
                                ParametrosConsulta3 += "fpcaesae = '" & dt2.Rows(ii).Item("fpcaesae") & "' and "
                                ParametrosConsulta3 += "fpcaesta = '" & dt2.Rows(ii).Item("fpcaesta") & "' "

                                ' ejecuta la consulta
                                oEjecutar = New SqlCommand(ParametrosConsulta3, oConexion)

                                ' procesa la consulta 
                                oEjecutar.CommandTimeout = 0
                                oEjecutar.CommandType = CommandType.Text
                                oAdapter.SelectCommand = oEjecutar

                                ' llena el datatable 
                                oAdapter.Fill(dt3)

                                ' cierra la conexion
                                oConexion.Close()

                                ' ELIMINA LA CARTOGRAFIA

                                Dim inIDRECART As Integer = CInt(dt3.Rows(0).Item("FPCAIDRE"))

                                Dim objdatos1 As New cla_FIPRCART
                                objdatos1.fun_Eliminar_FIPRCART(inIDRECART)

                        Next

                    End If

                    ' Incrementa la barra
                    inProceso = inProceso + 1
                    pbPROCESO.Value = inProceso
                Next

            End If

            ' inicia la barra de progreso
            pbPROCESO.Value = 0

            Me.cmdDepurarCartografia.Enabled = True

            mod_MENSAJE.Se_Modificaron_Los_Datos_Correctamente()

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub cmdAPLICAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAPLICAR.Click

        Try
            If MessageBox.Show("¿ Desea actualizar los predios con los parametros establecidos ?", "Mensaje ...", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then

                ' apaga el boton
                Me.cmdAPLICAR.Enabled = False

                '================================================
                '*** ACTUALIZA EL REGISTRO DE IDENTIFICADORES ***
                '================================================

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
                ParametrosConsulta += "Update FichPred "
                ParametrosConsulta += "Set FiprConj = '" & Me.chkPredioEnConjunto.Checked & "' "
                ParametrosConsulta += "Where "
                ParametrosConsulta += "FiprMuni like '" & Trim(Me.txtFIPRMUNI.Text) & "' and "
                ParametrosConsulta += "FiprCorr like '" & Trim(Me.txtFIPRCORR.Text) & "' and "
                ParametrosConsulta += "FiprBarr like '" & Trim(Me.txtFIPRBARR.Text) & "' and "
                ParametrosConsulta += "FiprManz like '" & Trim(Me.txtFIPRMANZ.Text) & "' and "
                ParametrosConsulta += "FiprPred like '" & Trim(Me.txtFIPRPRED.Text) & "' and "
                ParametrosConsulta += "FiprEdif like '" & Trim(Me.txtFIPREDIF.Text) & "' and "
                ParametrosConsulta += "FiprUnpr like '" & Trim(Me.txtFIPRUNPR.Text) & "' and "
                ParametrosConsulta += "FiprClse like '" & Trim(Me.txtFIPRCLSE.Text) & "' and "
                ParametrosConsulta += "FiprCasu like '" & Trim(Me.txtFIPRCASU.Text) & "' and "
                ParametrosConsulta += "FiprCapr like '" & Trim(Me.txtFIPRCAPR.Text) & "' and "
                ParametrosConsulta += "FiprMoad like '" & Trim(Me.txtFIPRMOAD.Text) & "' and "
                ParametrosConsulta += "FiprTifi like '" & Trim(Me.txtFIPRTIFI.Text) & "' and "
                ParametrosConsulta += "FiprNufi between '" & Trim(Me.txtFIPRFIIN.Text) & "' and '" & Trim(Me.txtFIPRFIFI.Text) & "' and "
                ParametrosConsulta += "FiprEsta = 'ac' "

                ' ejecuta la consulta
                oEjecutar = New SqlCommand(ParametrosConsulta, oConexion)

                ' procesa la consulta 
                oEjecutar.CommandTimeout = 360
                oEjecutar.CommandType = CommandType.Text
                oReader = oEjecutar.ExecuteReader

                Dim inNroRegistroActualizados As Integer = oReader.RecordsAffected

                ' cierra la conexion
                oConexion.Close()
                oReader = Nothing

                If inNroRegistroActualizados > 0 Then
                    MessageBox.Show("Se actualizaron  " & inNroRegistroActualizados & " registros correctamente", "Mensaje ...", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                    strBARRESTA.Items(2).Text = "Registros : " & inNroRegistroActualizados
                Else
                    MessageBox.Show("No se actualizaron registros", "Mensaje ...", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                End If

                ' prende el boton
                Me.cmdAPLICAR.Enabled = True

            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub cmdLIMPIAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdLIMPIAR.Click
        pro_LimpiarCampos()
    End Sub
    Private Sub cmdSALIR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSALIR.Click
        Me.txtFIPRFIIN.Focus()
        Me.Close()
    End Sub

#End Region

#Region "FORMULARIO"

#Region "Load"

    Private Sub frm_Remplazar_Identificador_Construccion_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        strBARRESTA.Items(2).Text = "Registros : 0"
    End Sub

#End Region

#Region "KeyPress"

    Private Sub txtFIPRFIIN_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFIPRFIIN.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            txtFIPRFIFI.Focus()
        End If
    End Sub
    Private Sub txtFIPRFIFI_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFIPRFIFI.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            txtFIPRTIFI.Focus()
        End If
    End Sub
    Private Sub txtFIPRTIFI_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFIPRTIFI.KeyPress
        If Not Char.IsNumber(e.KeyChar) Then
            If e.KeyChar <> Convert.ToChar(Keys.Back) Then
                If e.KeyChar <> Convert.ToChar(37) Then
                    If e.KeyChar <> Convert.ToChar(Keys.Enter) Then
                        e.Handled = True
                        strBARRESTA.Items(1).Text = IncoValoNume
                        mod_MENSAJE.Inco_Valo_Nume()
                    Else
                        strBARRESTA.Items(1).Text = ""
                        txtFIPRMUNI.Focus()
                    End If
                End If
            End If
        End If
    End Sub
    Private Sub txtFIPRMUNI_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFIPRMUNI.KeyPress
        If Not Char.IsNumber(e.KeyChar) Then
            If e.KeyChar <> Convert.ToChar(Keys.Back) Then
                If e.KeyChar <> Convert.ToChar(37) Then
                    If e.KeyChar <> Convert.ToChar(Keys.Enter) Then
                        e.Handled = True
                        strBARRESTA.Items(1).Text = IncoValoNume
                        mod_MENSAJE.Inco_Valo_Nume()
                    Else
                        strBARRESTA.Items(1).Text = ""
                        txtFIPRCORR.Focus()
                    End If
                End If
            End If
        End If
    End Sub
    Private Sub txtFIPRCORR_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFIPRCORR.KeyPress
        If Not Char.IsNumber(e.KeyChar) Then
            If e.KeyChar <> Convert.ToChar(Keys.Back) Then
                If e.KeyChar <> Convert.ToChar(37) Then
                    If e.KeyChar <> Convert.ToChar(Keys.Enter) Then
                        e.Handled = True
                        strBARRESTA.Items(1).Text = IncoValoNume
                        mod_MENSAJE.Inco_Valo_Nume()
                    Else
                        strBARRESTA.Items(1).Text = ""
                        txtFIPRBARR.Focus()
                    End If
                End If
            End If
        End If

    End Sub
    Private Sub txtFIPRBARR_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFIPRBARR.KeyPress
        If Not Char.IsNumber(e.KeyChar) Then
            If e.KeyChar <> Convert.ToChar(Keys.Back) Then
                If e.KeyChar <> Convert.ToChar(37) Then
                    If e.KeyChar <> Convert.ToChar(Keys.Enter) Then
                        e.Handled = True
                        strBARRESTA.Items(1).Text = IncoValoNume
                        mod_MENSAJE.Inco_Valo_Nume()
                    Else
                        strBARRESTA.Items(1).Text = ""
                        txtFIPRMANZ.Focus()
                    End If
                End If
            End If
        End If

    End Sub
    Private Sub txtFIPRMANZ_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFIPRMANZ.KeyPress
        If Not Char.IsNumber(e.KeyChar) Then
            If e.KeyChar <> Convert.ToChar(Keys.Back) Then
                If e.KeyChar <> Convert.ToChar(37) Then
                    If e.KeyChar <> Convert.ToChar(Keys.Enter) Then
                        e.Handled = True
                        strBARRESTA.Items(1).Text = IncoValoNume
                        mod_MENSAJE.Inco_Valo_Nume()
                    Else
                        strBARRESTA.Items(1).Text = ""
                        txtFIPRPRED.Focus()
                    End If
                End If
            End If
        End If

    End Sub
    Private Sub txtFIPRPRED_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFIPRPRED.KeyPress
        If Not Char.IsNumber(e.KeyChar) Then
            If e.KeyChar <> Convert.ToChar(Keys.Back) Then
                If e.KeyChar <> Convert.ToChar(37) Then
                    If e.KeyChar <> Convert.ToChar(Keys.Enter) Then
                        e.Handled = True
                        strBARRESTA.Items(1).Text = IncoValoNume
                        mod_MENSAJE.Inco_Valo_Nume()
                    Else
                        strBARRESTA.Items(1).Text = ""
                        txtFIPREDIF.Focus()
                    End If
                End If
            End If
        End If

    End Sub
    Private Sub txtFIPREDIF_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFIPREDIF.KeyPress
        If Not Char.IsNumber(e.KeyChar) Then
            If e.KeyChar <> Convert.ToChar(Keys.Back) Then
                If e.KeyChar <> Convert.ToChar(37) Then
                    If e.KeyChar <> Convert.ToChar(Keys.Enter) Then
                        e.Handled = True
                        strBARRESTA.Items(1).Text = IncoValoNume
                        mod_MENSAJE.Inco_Valo_Nume()
                    Else
                        strBARRESTA.Items(1).Text = ""
                        txtFIPRUNPR.Focus()
                    End If
                End If
            End If
        End If

    End Sub
    Private Sub txtFIPRUNPR_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFIPRUNPR.KeyPress
        If Not Char.IsNumber(e.KeyChar) Then
            If e.KeyChar <> Convert.ToChar(Keys.Back) Then
                If e.KeyChar <> Convert.ToChar(37) Then
                    If e.KeyChar <> Convert.ToChar(Keys.Enter) Then
                        e.Handled = True
                        strBARRESTA.Items(1).Text = IncoValoNume
                        mod_MENSAJE.Inco_Valo_Nume()
                    Else
                        strBARRESTA.Items(1).Text = ""
                        txtFIPRCLSE.Focus()
                    End If
                End If
            End If
        End If

    End Sub
    Private Sub txtFIPRCLSE_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFIPRCLSE.KeyPress
        If Not Char.IsNumber(e.KeyChar) Then
            If e.KeyChar <> Convert.ToChar(Keys.Back) Then
                If e.KeyChar <> Convert.ToChar(37) Then
                    If e.KeyChar <> Convert.ToChar(Keys.Enter) Then
                        e.Handled = True
                        strBARRESTA.Items(1).Text = IncoValoNume
                        mod_MENSAJE.Inco_Valo_Nume()
                    Else
                        strBARRESTA.Items(1).Text = ""
                        txtFIPRCASU.Focus()
                    End If
                End If
            End If
        End If
    End Sub
    Private Sub txtFIPRCASU_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFIPRCASU.KeyPress
        If Not Char.IsNumber(e.KeyChar) Then
            If e.KeyChar <> Convert.ToChar(Keys.Back) Then
                If e.KeyChar <> Convert.ToChar(37) Then
                    If e.KeyChar <> Convert.ToChar(Keys.Enter) Then
                        e.Handled = True
                        strBARRESTA.Items(1).Text = IncoValoNume
                        mod_MENSAJE.Inco_Valo_Nume()
                    Else
                        strBARRESTA.Items(1).Text = ""
                        txtFIPRCAPR.Focus()
                    End If
                End If
            End If
        End If
    End Sub
    Private Sub txtFIPRCAPR_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFIPRCAPR.KeyPress
        If Not Char.IsNumber(e.KeyChar) Then
            If e.KeyChar <> Convert.ToChar(Keys.Back) Then
                If e.KeyChar <> Convert.ToChar(37) Then
                    If e.KeyChar <> Convert.ToChar(Keys.Enter) Then
                        e.Handled = True
                        strBARRESTA.Items(1).Text = IncoValoNume
                        mod_MENSAJE.Inco_Valo_Nume()
                    Else
                        strBARRESTA.Items(1).Text = ""
                        txtFIPRMOAD.Focus()
                    End If
                End If
            End If
        End If
    End Sub
    Private Sub txtFIPRMOAD_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFIPRMOAD.KeyPress
        If Not Char.IsNumber(e.KeyChar) Then
            If e.KeyChar <> Convert.ToChar(Keys.Back) Then
                If e.KeyChar <> Convert.ToChar(37) Then
                    If e.KeyChar <> Convert.ToChar(Keys.Enter) Then
                        e.Handled = True
                        strBARRESTA.Items(1).Text = IncoValoNume
                        mod_MENSAJE.Inco_Valo_Nume()
                    Else
                        strBARRESTA.Items(1).Text = ""
                        chkPredioEnConjunto.Focus()
                    End If
                End If
            End If
        End If
    End Sub
    Private Sub chkPredioEnConjunto_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles chkPredioEnConjunto.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            cmdAPLICAR.Focus()
        End If
    End Sub

#End Region

#Region "GotFocus"

    Private Sub txtFIPRFIIN_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFIPRFIIN.GotFocus
        txtFIPRFIIN.SelectionStart = 0
        txtFIPRFIIN.SelectionLength = Len(txtFIPRFIIN.Text)
        strBARRESTA.Items(0).Text = txtFIPRFIIN.AccessibleDescription
    End Sub
    Private Sub txtFIPRFIFI_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFIPRFIFI.GotFocus
        txtFIPRFIFI.SelectionStart = 0
        txtFIPRFIFI.SelectionLength = Len(txtFIPRFIFI.Text)
        strBARRESTA.Items(0).Text = txtFIPRFIFI.AccessibleDescription
    End Sub
    Private Sub txtFIPRTIFI_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFIPRTIFI.GotFocus
        txtFIPRTIFI.SelectionStart = 0
        txtFIPRTIFI.SelectionLength = Len(txtFIPRTIFI.Text)
        strBARRESTA.Items(0).Text = txtFIPRTIFI.AccessibleDescription
    End Sub
    Private Sub txtFIPRMUNI_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFIPRMUNI.GotFocus
        txtFIPRMUNI.SelectionStart = 0
        txtFIPRMUNI.SelectionLength = Len(txtFIPRMUNI.Text)
        strBARRESTA.Items(0).Text = txtFIPRMUNI.AccessibleDescription
    End Sub
    Private Sub txtFIPRCORR_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFIPRCORR.GotFocus
        txtFIPRCORR.SelectionStart = 0
        txtFIPRCORR.SelectionLength = Len(txtFIPRCORR.Text)
        strBARRESTA.Items(0).Text = txtFIPRCORR.AccessibleDescription
    End Sub
    Private Sub txtFIPRBARR_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFIPRBARR.GotFocus
        txtFIPRBARR.SelectionStart = 0
        txtFIPRBARR.SelectionLength = Len(txtFIPRBARR.Text)
        strBARRESTA.Items(0).Text = txtFIPRBARR.AccessibleDescription
    End Sub
    Private Sub txtFIPRMANZ_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFIPRMANZ.GotFocus
        txtFIPRMANZ.SelectionStart = 0
        txtFIPRMANZ.SelectionLength = Len(txtFIPRMANZ.Text)
        strBARRESTA.Items(0).Text = txtFIPRMANZ.AccessibleDescription
    End Sub
    Private Sub txtFIPRPRED_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFIPRPRED.GotFocus
        txtFIPRPRED.SelectionStart = 0
        txtFIPRPRED.SelectionLength = Len(txtFIPRPRED.Text)
        strBARRESTA.Items(0).Text = txtFIPRPRED.AccessibleDescription
    End Sub
    Private Sub txtFIPREDIF_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFIPREDIF.GotFocus
        txtFIPREDIF.SelectionStart = 0
        txtFIPREDIF.SelectionLength = Len(txtFIPREDIF.Text)
        strBARRESTA.Items(0).Text = txtFIPREDIF.AccessibleDescription
    End Sub
    Private Sub txtFIPRUNPR_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFIPRUNPR.GotFocus
        txtFIPRUNPR.SelectionStart = 0
        txtFIPRUNPR.SelectionLength = Len(txtFIPRUNPR.Text)
        strBARRESTA.Items(0).Text = txtFIPRUNPR.AccessibleDescription
    End Sub
    Private Sub txtFIPRCLSE_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFIPRCLSE.GotFocus
        txtFIPRCLSE.SelectionStart = 0
        txtFIPRCLSE.SelectionLength = Len(txtFIPRCLSE.Text)
        strBARRESTA.Items(0).Text = txtFIPRCLSE.AccessibleDescription
    End Sub
    Private Sub txtFIPRCASU_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFIPRCASU.GotFocus
        txtFIPRCASU.SelectionStart = 0
        txtFIPRCASU.SelectionLength = Len(txtFIPRCASU.Text)
        strBARRESTA.Items(0).Text = txtFIPRCASU.AccessibleDescription
    End Sub
    Private Sub txtFIPRCAPR_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFIPRCAPR.GotFocus
        txtFIPRCAPR.SelectionStart = 0
        txtFIPRCAPR.SelectionLength = Len(txtFIPRCAPR.Text)
        strBARRESTA.Items(0).Text = txtFIPRCAPR.AccessibleDescription
    End Sub
    Private Sub txtFIPRMOAD_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFIPRMOAD.GotFocus
        txtFIPRMOAD.SelectionStart = 0
        txtFIPRMOAD.SelectionLength = Len(txtFIPRMOAD.Text)
        strBARRESTA.Items(0).Text = txtFIPRMOAD.AccessibleDescription
    End Sub
    Private Sub cmdAPLICAR_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdAPLICAR.GotFocus
        strBARRESTA.Items(0).Text = cmdAPLICAR.AccessibleDescription
    End Sub
    Private Sub cmdLIMPIAR_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdLIMPIAR.GotFocus
        strBARRESTA.Items(0).Text = cmdLIMPIAR.AccessibleDescription
    End Sub
    Private Sub cmdSALIR_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdSALIR.GotFocus
        strBARRESTA.Items(0).Text = cmdSALIR.AccessibleDescription
    End Sub
    Private Sub chkPredioEnConjunto_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkPredioEnConjunto.GotFocus
        strBARRESTA.Items(0).Text = chkPredioEnConjunto.AccessibleDescription
    End Sub

#End Region

#Region "Validated"

    Private Sub txtFIPRFIIN_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFIPRFIIN.Validated
        If fun_Verificar_Dato_Numerico_Evento_Validated(Trim(Me.txtFIPRFIIN.Text)) = True Then
            Me.txtFIPRFIIN.Text = Val(Trim(Me.txtFIPRFIIN.Text))
        Else
            Me.txtFIPRFIIN.Focus()
            mod_MENSAJE.Inco_Valo_Nume()
        End If
        strBARRESTA.Items(1).Text = ""
    End Sub
    Private Sub txtFIPRFIFI_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFIPRFIFI.Validated
        If fun_Verificar_Dato_Numerico_Evento_Validated(Trim(Me.txtFIPRFIFI.Text)) = True Then
            Me.txtFIPRFIFI.Text = Val(Trim(Me.txtFIPRFIFI.Text))
        Else
            Me.txtFIPRFIFI.Focus()
            mod_MENSAJE.Inco_Valo_Nume()
        End If
        strBARRESTA.Items(1).Text = ""
    End Sub
    Private Sub txtFIPRTIFI_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFIPRTIFI.Validated
        strBARRESTA.Items(1).Text = ""
    End Sub
    Private Sub txtFIPRMUNI_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFIPRMUNI.Validated
        txtFIPRMUNI.Text = fun_Formato_Mascara_3_String(txtFIPRMUNI.Text)
        strBARRESTA.Items(1).Text = ""
    End Sub
    Private Sub txtFIPRCORR_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFIPRCORR.Validated
        txtFIPRCORR.Text = fun_Formato_Mascara_2_String(txtFIPRCORR.Text)
        strBARRESTA.Items(1).Text = ""
    End Sub
    Private Sub txtFIPRBARR_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFIPRBARR.Validated
        txtFIPRBARR.Text = fun_Formato_Mascara_3_String(txtFIPRBARR.Text)
        strBARRESTA.Items(1).Text = ""
    End Sub
    Private Sub txtFIPRMANZ_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFIPRMANZ.Validated
        txtFIPRMANZ.Text = fun_Formato_Mascara_3_String(txtFIPRMANZ.Text)
        strBARRESTA.Items(1).Text = ""
    End Sub
    Private Sub txtFIPRPRED_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFIPRPRED.Validated
        txtFIPRPRED.Text = fun_Formato_Mascara_5_String(txtFIPRPRED.Text)
        strBARRESTA.Items(1).Text = ""
    End Sub
    Private Sub txtFIPREDIF_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFIPREDIF.Validated
        txtFIPREDIF.Text = fun_Formato_Mascara_3_String(txtFIPREDIF.Text)
        strBARRESTA.Items(1).Text = ""
    End Sub
    Private Sub txtFIPRUNPR_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFIPRUNPR.Validated
        txtFIPRUNPR.Text = fun_Formato_Mascara_5_String(txtFIPRUNPR.Text)
        strBARRESTA.Items(1).Text = ""
    End Sub
    Private Sub txtFIPRCLSE_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFIPRCLSE.Validated
        Me.lblFIPRCLSE.Text = CType(fun_Buscar_Lista_Valores_CLASSECT(Me.txtFIPRCLSE.Text), String)
    End Sub
    Private Sub txtFIPRCASU_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFIPRCASU.Validated
        Me.lblFIPRCASU.Text = CType(fun_Buscar_Lista_Valores_CATESUEL(Me.txtFIPRCASU.Text), String)
    End Sub
    Private Sub txtFIPRCAPR_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFIPRCAPR.Validated
        Me.lblFIPRCAPR.Text = CType(fun_Buscar_Lista_Valores_CARAPRED(Me.txtFIPRCAPR.Text), String)
    End Sub
    Private Sub txtFIPRMOAD_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFIPRMOAD.Validated
        Me.lblFIPRMOAD.Text = CType(fun_Buscar_Lista_Valores_MODOADQU(Me.txtFIPRMOAD.Text), String)
    End Sub

#End Region

#End Region

  
End Class