Imports REGLAS_DEL_NEGOCIO
Imports System
Imports System.IO
Imports System.Data
Imports System.Data.Sqlclient
Imports System.Configuration
Imports System.Text

Public Class frm_consultar_TERCERO

    '========================
    '*** CONSULTA TERCERO ***
    '========================

#Region "VARIABLES LOCALES"

    ' variables verificar datos
    Dim inTERCIDRE As Integer
    Dim stTERCNUDO As String
    Dim stTERCTIDO As String
    Dim stTERCCAPR As String
    Dim stTERCSEXO As String
    Dim stTERCNOMB As String
    Dim stTERCPRAP As String
    Dim stTERCSEAP As String
    Dim stTERCSICO As String
    Dim stTERCTEL1 As String
    Dim stTERCTEL2 As String
    Dim stTERCFAX1 As String
    Dim stTERCDIRE As String
    Dim stTERCESTA As String
    Dim Separador As String

    Private oEjecutar As New SqlCommand
    Private oConexion As New SqlConnection
    Private oAdapter As New SqlDataAdapter
    Private ds As New DataSet
    Private dt As New DataTable

    Dim tblCONSULTA As New DataTable

#End Region

#Region "PROCEDIMIENTOS"

    Private Sub pro_LimpiarCampos()

        ' limpiar los campos
        txtTERCNUDO.Text = ""
        cboTERCTIDO.Text = ""
        cboTERCCAPR.Text = ""
        cboTERCSEXO.Text = ""
        txtTERCNOMB.Text = ""
        txtTERCPRAP.Text = ""
        txtTERCSEAP.Text = ""
        txtTERCSICO.Text = ""
        txtTERCTEL1.Text = ""
        txtTERCTEL2.Text = ""
        txtTERCFAX1.Text = ""
        txtTERCDIRE.Text = ""
        cboTERCESTA.Text = ""
        lblTERCTIDO.Text = ""
        lblTERCCAPR.Text = ""
        lblTERCSEXO.Text = ""
        txtRUTA.Text = ""

        Me.dgvCONSULTA.DataSource = New DataTable

    End Sub
    Private Sub pro_VerificarDatos()

        If Trim(Me.txtTERCNUDO.Text) = "" Then
            stTERCNUDO = "%"
        Else
            stTERCNUDO = Trim(Me.txtTERCNUDO.Text)
        End If

        If Trim(Me.cboTERCTIDO.Text) = "" Then
            stTERCTIDO = "%"
        Else
            stTERCTIDO = Trim(Me.cboTERCTIDO.Text)
        End If

        If Trim(Me.cboTERCCAPR.Text) = "" Then
            stTERCCAPR = "%"
        Else
            stTERCCAPR = Trim(Me.cboTERCCAPR.Text)
        End If

        If Trim(Me.cboTERCSEXO.Text) = "" Then
            stTERCSEXO = "%"
        Else
            stTERCSEXO = Trim(Me.cboTERCSEXO.Text)
        End If

        If Trim(Me.txtTERCNOMB.Text) = "" Then
            stTERCNOMB = "%"
        Else
            stTERCNOMB = Trim(Me.txtTERCNOMB.Text)
        End If

        If Trim(Me.txtTERCPRAP.Text) = "" Then
            stTERCPRAP = "%"
        Else
            stTERCPRAP = Trim(Me.txtTERCPRAP.Text)
        End If

        If Trim(Me.txtTERCSEAP.Text) = "" Then
            stTERCSEAP = "%"
        Else
            stTERCSEAP = Trim(Me.txtTERCSEAP.Text)
        End If

        If Trim(Me.txtTERCSICO.Text) = "" Then
            stTERCSICO = "%"
        Else
            stTERCSICO = Trim(Me.txtTERCSICO.Text)
        End If

        If Trim(Me.txtTERCTEL1.Text) = "" Then
            stTERCTEL1 = "%"
        Else
            stTERCTEL1 = Trim(Me.txtTERCTEL1.Text)
        End If

        If Trim(Me.txtTERCTEL2.Text) = "" Then
            stTERCTEL2 = "%"
        Else
            stTERCTEL2 = Trim(Me.txtTERCTEL2.Text)
        End If

        If Trim(Me.txtTERCFAX1.Text) = "" Then
            stTERCFAX1 = "%"
        Else
            stTERCFAX1 = Trim(Me.txtTERCFAX1.Text)
        End If

        If Trim(Me.txtTERCDIRE.Text) = "" Then
            stTERCDIRE = "%"
        Else
            stTERCDIRE = Trim(Me.txtTERCDIRE.Text)
        End If

        If Trim(Me.cboTERCESTA.Text) = "" Then
            stTERCESTA = "%"
        Else
            stTERCESTA = Trim(Me.cboTERCESTA.Text)
        End If

    End Sub
    Private Sub pro_ListaDeValores()

        Try
            ' encuestra la posición seleccionada
            Dim I, SW As Byte

            While I < Me.dgvCONSULTA.RowCount And SW = 0
                If Me.dgvCONSULTA.CurrentRow.Cells(I).Selected Then

                    ' llena los campos con el registro seleccionado
                    inTERCIDRE = Me.dgvCONSULTA.CurrentRow.Cells(0).Value.ToString()
                    Me.txtTERCNUDO.Text = Trim(Me.dgvCONSULTA.CurrentRow.Cells(1).Value.ToString())
                    Me.cboTERCTIDO.Text = Trim(Me.dgvCONSULTA.CurrentRow.Cells(2).Value.ToString())
                    Me.cboTERCCAPR.Text = Trim(Me.dgvCONSULTA.CurrentRow.Cells(3).Value.ToString())
                    Me.cboTERCSEXO.Text = Trim(Me.dgvCONSULTA.CurrentRow.Cells(4).Value.ToString())
                    Me.txtTERCNOMB.Text = Trim(Me.dgvCONSULTA.CurrentRow.Cells(5).Value.ToString())
                    Me.txtTERCPRAP.Text = Trim(Me.dgvCONSULTA.CurrentRow.Cells(6).Value.ToString())
                    Me.txtTERCSEAP.Text = Trim(Me.dgvCONSULTA.CurrentRow.Cells(7).Value.ToString())
                    Me.txtTERCSICO.Text = Trim(Me.dgvCONSULTA.CurrentRow.Cells(8).Value.ToString())
                    Me.txtTERCTEL1.Text = Trim(Me.dgvCONSULTA.CurrentRow.Cells(9).Value.ToString())
                    Me.txtTERCTEL2.Text = Trim(Me.dgvCONSULTA.CurrentRow.Cells(10).Value.ToString())
                    Me.txtTERCFAX1.Text = Trim(Me.dgvCONSULTA.CurrentRow.Cells(11).Value.ToString())
                    Me.txtTERCDIRE.Text = Trim(Me.dgvCONSULTA.CurrentRow.Cells(12).Value.ToString())
                    Me.cboTERCESTA.Text = Trim(Me.dgvCONSULTA.CurrentRow.Cells(13).Value.ToString())

                    ' busca la lista de valores
                    Me.lblTERCTIDO.Text = CType(fun_Buscar_Lista_Valores_TIPODOCU(Trim(Me.cboTERCTIDO.Text)), String)
                    Me.lblTERCCAPR.Text = CType(fun_Buscar_Lista_Valores_CALIPROP(Trim(Me.cboTERCCAPR.Text)), String)
                    Me.lblTERCSEXO.Text = CType(fun_Buscar_Lista_Valores_SEXO(Trim(Me.cboTERCSEXO.Text)), String)

                    SW = 1
                Else
                    I = I + 1
                End If
            End While

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub

#End Region

#Region "MENU"

    Private Sub cmdACEPTAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdACEPTAR.Click
        Try

            ' se busca por el numero de documento
            Dim objdatos As New cla_TERCERO
            Dim tbl As New DataTable

            If Trim(txtTERCNUDO.Text) <> "" Then
                tbl = objdatos.fun_Buscar_CODIGO_TERCERO(Trim(txtTERCNUDO.Text))

                If tbl.Rows.Count = 0 Then
                    mod_MENSAJE.No_Se_Encontro_Ningun_registro()
                    txtTERCNUDO.Focus()
                Else
                    inTERCIDRE = CType(tbl.Rows(0).Item(0), Integer)

                    Dim inIdRegistro As New frm_TERCERO(Val(inTERCIDRE))
                    txtTERCNUDO.Focus()
                    Me.Close()
                End If
            Else
                If Me.dgvCONSULTA.RowCount > 0 Then
                    inTERCIDRE = Integer.Parse(Me.dgvCONSULTA.CurrentRow.Cells(0).Value.ToString())

                    Dim inIdRegistro As New frm_TERCERO(Val(inTERCIDRE))
                    txtTERCNUDO.Focus()
                    Me.Close()
                Else
                    mod_MENSAJE.No_Se_Encontro_Ningun_registro()
                    txtTERCNUDO.Focus()
                End If
            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try
    End Sub
    Private Sub cmdCONSULTAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCONSULTAR.Click

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

            ' verifica los datos de los campos
            pro_VerificarDatos()

            ' parametros de la consulta
            Dim ParametrosConsulta As String = ""

            ' Concatena la condicion de la consulta
            ParametrosConsulta += "Select "
            ParametrosConsulta += "TercIdre as ID, "
            ParametrosConsulta += "TercNudo as NroDocumento, "
            ParametrosConsulta += "TercTido as TipoDocu, "
            ParametrosConsulta += "TercCapr as CaliProp, "
            ParametrosConsulta += "TercSexo as Sexo, "
            ParametrosConsulta += "TercNomb as Nombre, "
            ParametrosConsulta += "TercPrap as PriApellido, "
            ParametrosConsulta += "TercSeap as SegApellido, "
            ParametrosConsulta += "TercSico as Sigla, "
            ParametrosConsulta += "TercTel1 as Telefono1, "
            ParametrosConsulta += "TercTel2 as Telefono2, "
            ParametrosConsulta += "TercFax1 as Fax1, "
            ParametrosConsulta += "TercDire as Direccion, "
            ParametrosConsulta += "TercEsta as Estado "
            ParametrosConsulta += "From Tercero where "
            ParametrosConsulta += "TercNudo like '" & CStr(Trim(stTERCNUDO)) & "' and "
            ParametrosConsulta += "TercTido like '" & CStr(Trim(stTERCTIDO)) & "' and "
            ParametrosConsulta += "TercCapr like '" & CStr(Trim(stTERCCAPR)) & "' and "
            ParametrosConsulta += "TercSexo like '" & CStr(Trim(stTERCSEXO)) & "' and "
            ParametrosConsulta += "TercNomb like '" & CStr(Trim(stTERCNOMB)) & "' and "
            ParametrosConsulta += "TercPrap like '" & CStr(Trim(stTERCPRAP)) & "' and "
            ParametrosConsulta += "TercSeap like '" & CStr(Trim(stTERCSEAP)) & "' and "
            ParametrosConsulta += "TercSico like '" & CStr(Trim(stTERCSICO)) & "' and "
            ParametrosConsulta += "TercTel1 like '" & CStr(Trim(stTERCTEL1)) & "' and "
            ParametrosConsulta += "TercTel2 like '" & CStr(Trim(stTERCTEL2)) & "' and "
            ParametrosConsulta += "TercFax1 like '" & CStr(Trim(stTERCFAX1)) & "' and "
            ParametrosConsulta += "TercDire like '" & CStr(Trim(stTERCDIRE)) & "' and "
            ParametrosConsulta += "TercEsta like '" & CStr(Trim(stTERCESTA)) & "' "
            ParametrosConsulta += "order by TercNudo,TercTido,TercNomb"

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

            ' llena el datagridview
            If dt.Rows.Count > 0 Then
                ' llenar el datagrid
                Me.dgvCONSULTA.DataSource = dt

                ' llena la lista de valores
                pro_ListaDeValores()

                ' oculta las columnas del datagridview
                Me.dgvCONSULTA.Columns(0).Visible = False
                Me.dgvCONSULTA.Columns(3).Visible = False
                Me.dgvCONSULTA.Columns(4).Visible = False
                Me.dgvCONSULTA.Columns(8).Visible = False
                Me.dgvCONSULTA.Columns(9).Visible = False
                Me.dgvCONSULTA.Columns(10).Visible = False
                Me.dgvCONSULTA.Columns(11).Visible = False
                Me.dgvCONSULTA.Columns(12).Visible = False

            Else
                Me.dgvCONSULTA.DataSource = New DataTable
                mod_MENSAJE.Consulta_No_Encontro_Registros()
            End If

            ' Numero de registros recuperados
            Me.strBARRESTA.Items(2).Text = "Registros : " & Me.dgvCONSULTA.RowCount.ToString

            Me.dgvCONSULTA.Focus()

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub cmdPLANO_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPLANO.Click
        Try

            If dgvCONSULTA.RowCount > 0 Then

                ' crea la instancia para crear y salvar
                Dim oCrear As New SaveFileDialog

                oCrear.InitialDirectory = My.Computer.FileSystem.SpecialDirectories.MyDocuments
                oCrear.Filter = "Archivo de texto (*.txt)|*.txt|Todos los archivos (*.*)|*.*" 'Colocar varias extensiones
                oCrear.FilterIndex = 1 'coloca por defecto el *.txt
                oCrear.ShowDialog() 'abre la caja de dialogo para guardar


                ' si existe una ruta seleccionada
                If Trim(oCrear.FileName) <> "" Then

                    ' lleba la ruta al label
                    txtRUTA.Text = oCrear.FileName

                    ' se carga el separador
                    Separador = Trim(txtSEPARADOR.Text)

                    'Nuevo objeto StreamWriter, para acceder al fichero y poder guardar las líneas
                    Using archivo As StreamWriter = New StreamWriter(oCrear.FileName)

                        ' variable para almacenar la línea actual del dataview
                        Dim linea As String = String.Empty

                        With dgvCONSULTA
                            ' Recorrer las filas del dataGridView
                            For fila As Integer = 0 To .RowCount - 1
                                ' vaciar la línea
                                linea = String.Empty

                                ' Recorrer la cantidad de columnas que contiene el dataGridView
                                For col As Integer = 0 To .Columns.Count - 1
                                    ' Almacenar el valor de toda la fila , y cada campo separado por el delimitador
                                    linea = linea & Trim(.Item(col, fila).Value.ToString) & Separador
                                Next

                                ' Escribir una línea con el método WriteLine
                                With archivo
                                    ' eliminar el último caracter ";" de la cadena
                                    linea = linea.Remove(linea.Length - 1).ToString
                                    ' escribir la fila
                                    .WriteLine(linea.ToString)
                                End With
                            Next
                        End With
                    End Using

                    MessageBox.Show("Plano generado correctamente", "Mensaje ...", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)

                    If MessageBox.Show("¿ Desea abrir el archivo plano ?", "Mensaje ...", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then
                        ' Abrir con Process.Start el archivo de texto
                        Process.Start(oCrear.FileName)
                    End If

                Else
                    txtRUTA.Text = ""
                    txtTERCNUDO.Focus()
                End If
            Else
                MessageBox.Show("Ejecute la consulta antes de exportar el plano", "Mensaje ...", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            End If
        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try
    End Sub
    Private Sub cmdLIMPIAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdLIMPIAR.Click
        pro_LimpiarCampos()
        txtTERCNUDO.Focus()
    End Sub
    Private Sub cmdSALIR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSALIR.Click
        Dim inIdRegistro As New frm_TERCERO(Val(0))
        pro_LimpiarCampos()
        txtTERCNUDO.Focus()
        Me.Close()
    End Sub

#End Region

#Region "FORMULARIO"

#Region "Load"

    Private Sub frm_consultar_TERCERO_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        pro_LimpiarCampos()
        cmdACEPTAR.Enabled = False
        txtTERCNUDO.Focus()
    End Sub

#End Region

#Region "KeyPress"

    Private Sub txtTERCNUDO_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtTERCNUDO.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            cboTERCTIDO.Focus()
        End If
    End Sub
    Private Sub cboTERCTIDO_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboTERCTIDO.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            cboTERCCAPR.Focus()
        End If
    End Sub
    Private Sub cboTERCCAPR_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboTERCCAPR.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            cboTERCSEXO.Focus()
        End If
    End Sub
    Private Sub cboTERCSEXO_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboTERCSEXO.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            txtTERCNOMB.Focus()
        End If
    End Sub
    Private Sub txtTERCNOMB_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtTERCNOMB.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            txtTERCPRAP.Focus()
        End If
    End Sub
    Private Sub txtTERCPRAP_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtTERCPRAP.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            txtTERCSEAP.Focus()
        End If
    End Sub
    Private Sub txtTERCSEAP_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtTERCSEAP.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            txtTERCSICO.Focus()
        End If
    End Sub
    Private Sub txtTERCSICO_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtTERCSICO.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            txtTERCTEL1.Focus()
        End If
    End Sub
    Private Sub txtTERCTEL1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtTERCTEL1.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            txtTERCTEL2.Focus()
        End If
    End Sub
    Private Sub txtTERCTEL2_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtTERCTEL2.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            txtTERCFAX1.Focus()
        End If
    End Sub
    Private Sub txtTERCFAX1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtTERCFAX1.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            txtTERCDIRE.Focus()
        End If
    End Sub
    Private Sub txtTERCDIRE_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtTERCDIRE.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            cboTERCESTA.Focus()
        End If
    End Sub
    Private Sub cboTERCESTA_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboTERCESTA.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            cmdCONSULTAR.Focus()
        End If
    End Sub

#End Region

#Region "GotFocus"

    Private Sub txtTERCNUDO_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtTERCNUDO.GotFocus
        txtTERCNUDO.SelectionStart = 0
        txtTERCNUDO.SelectionLength = Len(txtTERCNUDO.Text)
        strBARRESTA.Items(0).Text = txtTERCNUDO.AccessibleDescription
    End Sub
    Private Sub cboTERCTIDO_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboTERCTIDO.GotFocus
        cboTERCTIDO.SelectionStart = 0
        cboTERCTIDO.SelectionLength = Len(cboTERCTIDO.Text)
        strBARRESTA.Items(0).Text = cboTERCTIDO.AccessibleDescription
    End Sub
    Private Sub cboTERCCAPR_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboTERCCAPR.GotFocus
        cboTERCCAPR.SelectionStart = 0
        cboTERCCAPR.SelectionLength = Len(cboTERCCAPR.Text)
        strBARRESTA.Items(0).Text = cboTERCCAPR.AccessibleDescription
    End Sub
    Private Sub cboTERCSEXO_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboTERCSEXO.GotFocus
        cboTERCSEXO.SelectionStart = 0
        cboTERCSEXO.SelectionLength = Len(cboTERCSEXO.Text)
        strBARRESTA.Items(0).Text = cboTERCSEXO.AccessibleDescription
    End Sub
    Private Sub txtTERCNOMB_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtTERCNOMB.GotFocus
        txtTERCNOMB.SelectionStart = 0
        txtTERCNOMB.SelectionLength = Len(txtTERCNOMB.Text)
        strBARRESTA.Items(0).Text = txtTERCNOMB.AccessibleDescription
    End Sub
    Private Sub txtTERCPRAP_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtTERCPRAP.GotFocus
        txtTERCPRAP.SelectionStart = 0
        txtTERCPRAP.SelectionLength = Len(txtTERCPRAP.Text)
        strBARRESTA.Items(0).Text = txtTERCPRAP.AccessibleDescription
    End Sub
    Private Sub txtTERCSEAP_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtTERCSEAP.GotFocus
        txtTERCSEAP.SelectionStart = 0
        txtTERCSEAP.SelectionLength = Len(txtTERCSEAP.Text)
        strBARRESTA.Items(0).Text = txtTERCSEAP.AccessibleDescription
    End Sub
    Private Sub txtTERCSICO_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtTERCSICO.GotFocus
        txtTERCSICO.SelectionStart = 0
        txtTERCSICO.SelectionLength = Len(txtTERCSICO.Text)
        strBARRESTA.Items(0).Text = txtTERCSICO.AccessibleDescription
    End Sub
    Private Sub txtTERCTEL1_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtTERCTEL1.GotFocus
        txtTERCTEL1.SelectionStart = 0
        txtTERCTEL1.SelectionLength = Len(txtTERCTEL1.Text)
        strBARRESTA.Items(0).Text = txtTERCTEL1.AccessibleDescription
    End Sub
    Private Sub txtTERCTEL2_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtTERCTEL2.GotFocus
        txtTERCTEL2.SelectionStart = 0
        txtTERCTEL2.SelectionLength = Len(txtTERCTEL2.Text)
        strBARRESTA.Items(0).Text = txtTERCTEL2.AccessibleDescription
    End Sub
    Private Sub txtTERCFAX1_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtTERCFAX1.GotFocus
        txtTERCFAX1.SelectionStart = 0
        txtTERCFAX1.SelectionLength = Len(txtTERCFAX1.Text)
        strBARRESTA.Items(0).Text = txtTERCFAX1.AccessibleDescription
    End Sub
    Private Sub txtTERCDIRE_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtTERCDIRE.GotFocus
        txtTERCDIRE.SelectionStart = 0
        txtTERCDIRE.SelectionLength = Len(txtTERCDIRE.Text)
        strBARRESTA.Items(0).Text = txtTERCDIRE.AccessibleDescription
    End Sub
    Private Sub cboTERCESTA_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs)
        cboTERCESTA.SelectionStart = 0
        cboTERCESTA.SelectionLength = Len(cboTERCESTA.Text)
        strBARRESTA.Items(0).Text = cboTERCESTA.AccessibleDescription
    End Sub
    Private Sub cmdACEPTAR_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdACEPTAR.GotFocus
        strBARRESTA.Items(0).Text = cmdACEPTAR.AccessibleDescription
    End Sub
    Private Sub cmdCONSULTAR_GotFocus1(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdCONSULTAR.GotFocus
        strBARRESTA.Items(0).Text = cmdCONSULTAR.AccessibleDescription
    End Sub
    Private Sub cmdPLANO_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdPLANO.GotFocus
        strBARRESTA.Items(0).Text = cmdPLANO.AccessibleDescription
    End Sub
    Private Sub cmdLIMPIAR_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdLIMPIAR.GotFocus
        strBARRESTA.Items(0).Text = cmdLIMPIAR.AccessibleDescription
    End Sub
    Private Sub cmdSALIR_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdSALIR.GotFocus
        strBARRESTA.Items(0).Text = cmdSALIR.AccessibleDescription
    End Sub

#End Region

#Region "Validated"

    Private Sub cboTERCTIDO_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboTERCTIDO.Validated
        If fun_Verificar_Dato_Numerico_Evento_Validated(Trim(cboTERCTIDO.Text)) = False Then
            If Trim(cboTERCTIDO.Text) <> "" Then
                cboTERCTIDO.Focus()
                strBARRESTA.Items(1).Text = IncoValoNume
            Else
                strBARRESTA.Items(0).Text = ""
                strBARRESTA.Items(1).Text = ""
            End If
            lblTERCTIDO.Text = ""
        Else
            lblTERCTIDO.Text = CType(fun_Buscar_Lista_Valores_TIPODOCU(Trim(cboTERCTIDO.Text)), String)

            strBARRESTA.Items(0).Text = ""
            strBARRESTA.Items(1).Text = ""
        End If
    End Sub
    Private Sub cboTERCCAPR_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboTERCCAPR.Validated
        If fun_Verificar_Dato_Numerico_Evento_Validated(Trim(cboTERCCAPR.Text)) = False Then
            If Trim(cboTERCCAPR.Text) <> "" Then
                cboTERCCAPR.Focus()
                strBARRESTA.Items(1).Text = IncoValoNume
            Else
                strBARRESTA.Items(0).Text = ""
                strBARRESTA.Items(1).Text = ""
            End If
            lblTERCCAPR.Text = ""
        Else
            lblTERCCAPR.Text = CType(fun_Buscar_Lista_Valores_CALIPROP(Trim(cboTERCCAPR.Text)), String)

            strBARRESTA.Items(0).Text = ""
            strBARRESTA.Items(1).Text = ""
        End If
    End Sub
    Private Sub cboTERCSEXO_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboTERCSEXO.Validated
        If fun_Verificar_Dato_Numerico_Evento_Validated(Trim(cboTERCSEXO.Text)) = False Then
            If Trim(cboTERCSEXO.Text) <> "" Then
                cboTERCSEXO.Focus()
                strBARRESTA.Items(1).Text = IncoValoNume
            Else
                strBARRESTA.Items(0).Text = ""
                strBARRESTA.Items(1).Text = ""
            End If
            lblTERCSEXO.Text = ""
        Else
            lblTERCSEXO.Text = CType(fun_Buscar_Lista_Valores_SEXO(Trim(cboTERCSEXO.Text)), String)

            strBARRESTA.Items(0).Text = ""
            strBARRESTA.Items(1).Text = ""
        End If
    End Sub

#End Region

#Region "CellClick"

    Private Sub dgvCONSULTA_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvCONSULTA.CellClick
        pro_ListaDeValores()
    End Sub

#End Region

#Region "DoubleClick"

    Private Sub dgvCONSULTA_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvCONSULTA.DoubleClick
        Dim inIdRegistro As New frm_TERCERO(Val(inTERCIDRE))
        txtTERCNUDO.Focus()
        Me.Close()
    End Sub

#End Region

#Region "KeyUp"

   

    Private Sub dgvCONSULTA_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgvCONSULTA.KeyUp
        If e.KeyCode = Keys.Down Or e.KeyCode = Keys.Up Or e.KeyCode = Keys.Enter Or e.KeyCode = Keys.PageUp Or e.KeyCode = Keys.PageDown Or e.KeyCode = Keys.PageUp Or e.KeyCode = Keys.PageDown Then
            pro_ListaDeValores()
        End If
    End Sub

#End Region

#Region "KeyDown"

    Private Sub cmdCONSULTAR_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cmdCONSULTAR.KeyDown, txtTERCNUDO.KeyDown, txtTERCNOMB.KeyDown, txtTERCPRAP.KeyDown, txtTERCSEAP.KeyDown, txtTERCSICO.KeyDown, txtTERCTEL1.KeyDown, txtTERCTEL2.KeyDown, txtTERCFAX1.KeyDown, txtTERCDIRE.KeyDown, cboTERCCAPR.KeyDown, cboTERCESTA.KeyDown, cboTERCSEXO.KeyDown, cboTERCTIDO.KeyDown
        If e.KeyCode = Keys.F8 Then
            cmdCONSULTAR.PerformClick()
        End If

        If e.KeyCode = Keys.F7 Then
            pro_LimpiarCampos()
        End If

    End Sub

#End Region

#Region "TextChanged"

    Private Sub txtTERCNUDO_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtTERCNUDO.TextChanged
        If Trim(txtTERCNUDO.Text) <> "" Then
            cmdACEPTAR.Enabled = True
        Else
            cmdACEPTAR.Enabled = False
        End If
    End Sub

#End Region

#End Region

    
End Class