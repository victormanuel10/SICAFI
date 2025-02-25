Imports REGLAS_DEL_NEGOCIO
Imports System
Imports System.IO
Imports System.Data
Imports System.Data.Sqlclient
Imports System.Configuration
Imports System.Text

Public Class frm_Remplazar_Identificador_Construccion

    '================================================
    '*** ACTUALIZAR IDENTIFICADOR DE CONSTRUCCIÓN ***
    '================================================

#Region "INSTANCIAR FORMULARIO"

    Private Shared frm_Instance = Nothing

    Public Shared Function instance() As frm_Remplazar_Identificador_Construccion
        If frm_Instance Is Nothing OrElse frm_Instance.isdisposed = True Then
            frm_Instance = New frm_Remplazar_Identificador_Construccion
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
        txtFPCOTICO_ACTUAL.Text = ""
        txtFPCOTICO_NUEVO.Text = ""
        lblFIPRCLSE.Text = ""
        lblFIPRCASU.Text = ""
        lblFIPRCAPR.Text = ""
        lblFIPRMOAD.Text = ""
        lblFPCOTICO_NUEVO.Text = ""
        lblFPCOTICO_ACTUAL.Text = ""
        strBARRESTA.Items(2).Text = "Registros : 0"

    End Sub

#End Region

#Region "MENU"

    Private Sub cmdAPLICAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAPLICAR.Click

        Try
            ' apaga el boton
            Me.cmdAPLICAR.Enabled = False

            ' verifica los campos vacios
            If fun_Verificar_Campos_Llenos_2_DATOS(Me.txtFPCOTICO_ACTUAL.Text, Me.txtFPCOTICO_NUEVO.Text) = False Then
                MessageBox.Show("Ingrese el identificador actual y/o nuevo", "Mensaje ...", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1)
            Else
                ' verifica si existe el identificador actual en BD
                If fun_Buscar_Dato_IDENTIFICADOR(fun_Formato_Mascara_3_Reales(Trim(Me.txtFPCOTICO_ACTUAL.Text))) = False Then
                    MessageBox.Show("No existe el identificador actual", "Mensaje ...", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1)
                Else
                    ' verifica si existe el identificador actual en BD
                    If fun_Buscar_Dato_IDENTIFICADOR(fun_Formato_Mascara_3_Reales(Trim(Me.txtFPCOTICO_NUEVO.Text))) = False Then
                        MessageBox.Show("No existe el identificador nuevo", "Mensaje ...", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1)
                    Else
                        ' verifica que los identificadores sean del mismo tipo de calificación
                        Dim objdatos As New cla_TIPOCONS
                        Dim tblIdenActual As New DataTable
                        Dim tblIdenNuevo As New DataTable

                        ' declaro las variables
                        Dim stTipoIdenActual As String = ""
                        Dim stTipoIdenNuevo As String = ""

                        ' llena las tablas
                        tblIdenActual = objdatos.fun_buscar_IDENTIFICADOR_MANT_TIPOCONS(Trim(Me.txtFPCOTICO_ACTUAL.Text))
                        tblIdenNuevo = objdatos.fun_buscar_IDENTIFICADOR_MANT_TIPOCONS(Trim(Me.txtFPCOTICO_NUEVO.Text))

                        ' verica las tablas 
                        If tblIdenActual.Rows.Count > 0 Then
                            stTipoIdenActual = Trim(tblIdenActual.Rows(0).Item("TICOTIPO").ToString)
                        End If

                        If tblIdenNuevo.Rows.Count > 0 Then
                            stTipoIdenNuevo = Trim(tblIdenNuevo.Rows(0).Item("TICOTIPO").ToString)
                        End If

                        ' compara los tipos de calificación
                        If Trim(stTipoIdenActual) <> Trim(stTipoIdenNuevo) Then
                            MessageBox.Show("El tipo de calificación del identificador actual es diferente al identificador nuevo", "Mensaje ...", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1)
                        Else
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
                            ParametrosConsulta += "Update FiprCons "
                            ParametrosConsulta += "Set FpcoTico = '" & Trim(Me.txtFPCOTICO_NUEVO.Text) & "' "
                            ParametrosConsulta += "Where Fpcoesta = 'ac' and "
                            ParametrosConsulta += "FpcoTico = '" & Trim(Me.txtFPCOTICO_ACTUAL.Text) & "' and "
                            ParametrosConsulta += "Exists(Select 1 from FichPred Where FiprNufi = FpcoNufi and "
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
                            ParametrosConsulta += "FiprEsta = 'ac') "

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

                        End If

                    End If
                End If
            End If

            ' prende el boton
            Me.cmdAPLICAR.Enabled = True

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
                        txtFPCOTICO_ACTUAL.Focus()
                    End If
                End If
            End If
        End If
    End Sub
    Private Sub txtFPCOTICO_ACTUAL_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFPCOTICO_ACTUAL.KeyPress
        If Not Char.IsNumber(e.KeyChar) Then
            If e.KeyChar <> Convert.ToChar(Keys.Back) Then
                If e.KeyChar <> Convert.ToChar(Keys.Enter) Then
                    e.Handled = True
                    strBARRESTA.Items(1).Text = IncoValoNume
                    mod_MENSAJE.Inco_Valo_Nume()
                Else
                    strBARRESTA.Items(1).Text = ""
                    txtFPCOTICO_NUEVO.Focus()
                End If
            End If
        End If
    End Sub
    Private Sub txtFPCOTICO_NUEVO_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFPCOTICO_NUEVO.KeyPress
        If Not Char.IsNumber(e.KeyChar) Then
            If e.KeyChar <> Convert.ToChar(Keys.Back) Then
                If e.KeyChar <> Convert.ToChar(Keys.Enter) Then
                    e.Handled = True
                    strBARRESTA.Items(1).Text = IncoValoNume
                    mod_MENSAJE.Inco_Valo_Nume()
                Else
                    strBARRESTA.Items(1).Text = ""
                    cmdAPLICAR.Focus()
                End If
            End If
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
    Private Sub txtFPCOTICO_ACTUAL_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFPCOTICO_ACTUAL.Validated
        Me.txtFPCOTICO_ACTUAL.Text = CType(fun_Formato_Mascara_3_Reales(Me.txtFPCOTICO_ACTUAL.Text), String)
    End Sub
    Private Sub txtFPCOTICO_NUEVO_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFPCOTICO_NUEVO.Validated
        Me.txtFPCOTICO_NUEVO.Text = CType(fun_Formato_Mascara_3_Reales(Me.txtFPCOTICO_NUEVO.Text), String)
    End Sub

#End Region

#End Region


  
End Class