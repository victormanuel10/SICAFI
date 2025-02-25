Imports REGLAS_DEL_NEGOCIO
Imports System
Imports System.IO
Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration
Imports System.Text

Public Class frm_consulta_linderos_FIPRLIND

    '=================================
    ' CONSULTA LINDEROS FICHA PREDIAL
    '=================================

#Region "CONSTRUCTORES"

    Dim tblCONSULTA As New DataTable

#End Region

#Region "INSTANCIAR FORMULARIO"

    Private Shared frm_Instance = Nothing

    Public Shared Function instance() As frm_consulta_linderos_FIPRLIND
        If frm_Instance Is Nothing OrElse frm_Instance.isdisposed = True Then
            frm_Instance = New frm_consulta_linderos_FIPRLIND
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

    ' variables de conexión
    Private oEjecutar As New SqlCommand
    Private oConexion As New SqlConnection
    Private oAdapter As New SqlDataAdapter
    Private ds As New DataSet
    Private dt As New DataTable

    ' variables verificar datos
    Dim stFIPRNUFI As String
    Dim stFIPRDIRE As String
    Dim stFIPRMUNI As String
    Dim stFIPRCORR As String
    Dim stFIPRBARR As String
    Dim stFIPRMANZ As String
    Dim stFIPRPRED As String
    Dim stFIPREDIF As String
    Dim stFIPRUNPR As String
    Dim stFIPRCLSE As String
    Dim stFIPRCASU As String
    Dim stFIPRCAPR As String
    Dim stFIPRMOAD As String
    Dim stFIPRESTA As String
    Dim stFPLIPUCA As String
    Dim stFPLICOLI As String
    Dim stFPLIESTA As String
    Dim Separador As String

    ' variables guardar consulta
    Dim Guardar_stFIPRNUFI As String
    Dim Guardar_stFIPRDIRE As String
    Dim Guardar_stFIPRMUNI As String
    Dim Guardar_stFIPRCORR As String
    Dim Guardar_stFIPRBARR As String
    Dim Guardar_stFIPRMANZ As String
    Dim Guardar_stFIPRPRED As String
    Dim Guardar_stFIPREDIF As String
    Dim Guardar_stFIPRUNPR As String
    Dim Guardar_stFIPRCLSE As String
    Dim Guardar_stFIPRCASU As String
    Dim Guardar_stFIPRCAPR As String
    Dim Guardar_stFIPRMOAD As String
    Dim Guardar_stFIPRESTA As String
    Dim Guardar_stFPLIPUCA As String
    Dim Guardar_stFPLICOLI As String
    Dim Guardar_stFPLIESTA As String

#End Region

#Region "PROCEDIMIENTOS"

    Private Sub pro_LimpiarCampos()

        Me.txtFIPRNUFI.Text = ""
        Me.txtFIPRDIRE.Text = ""
        Me.txtFIPRMUNI.Text = ""
        Me.txtFIPRCORR.Text = ""
        Me.txtFIPRBARR.Text = ""
        Me.txtFIPRMANZ.Text = ""
        Me.txtFIPRPRED.Text = ""
        Me.txtFIPREDIF.Text = ""
        Me.txtFIPRUNPR.Text = ""
        Me.txtFIPRCLSE.Text = ""
        Me.txtFIPRCASU.Text = ""
        Me.txtFIPRCAPR.Text = ""
        Me.txtFIPRMOAD.Text = ""
        Me.txtFIPRESTA.Text = ""
        Me.lblFIPRCLSE.Text = ""
        Me.lblFIPRCASU.Text = ""
        Me.lblFIPRCAPR.Text = ""
        Me.lblFIPRMOAD.Text = ""
        Me.txtFPLIPUCA.Text = ""
        Me.txtFPLIPUCA.Text = ""
        Me.txtFPLICOLI.Text = ""
        Me.lblFPLIPUCA.Text = ""
        Me.txtFPLIESTA.Text = ""
        Me.strBARRESTA.Items(2).Text = "Registros : 0"

        Me.dgvCONSULTA.DataSource = New DataTable

    End Sub
    Private Sub pro_VerificarDatos()

        '*** VERIFICA DATOS DE FICHA PREDIAL ***

        If Trim(txtFIPRNUFI.Text) = "" Then
            stFIPRNUFI = "%"
        Else
            stFIPRNUFI = Trim(txtFIPRNUFI.Text)
        End If

        If Trim(txtFIPRDIRE.Text) = "" Then
            stFIPRDIRE = "%"
        Else
            stFIPRDIRE = Trim(txtFIPRDIRE.Text)
        End If

        If Trim(txtFIPRMUNI.Text) = "" Then
            stFIPRMUNI = "%"
        Else
            stFIPRMUNI = Trim(txtFIPRMUNI.Text)
        End If

        If Trim(txtFIPRCORR.Text) = "" Then
            stFIPRCORR = "%"
        Else
            stFIPRCORR = Trim(txtFIPRCORR.Text)
        End If

        If Trim(txtFIPRBARR.Text) = "" Then
            stFIPRBARR = "%"
        Else
            stFIPRBARR = Trim(txtFIPRBARR.Text)
        End If

        If Trim(txtFIPRMANZ.Text) = "" Then
            stFIPRMANZ = "%"
        Else
            stFIPRMANZ = Trim(txtFIPRMANZ.Text)
        End If

        If Trim(txtFIPRPRED.Text) = "" Then
            stFIPRPRED = "%"
        Else
            stFIPRPRED = Trim(txtFIPRPRED.Text)
        End If

        If Trim(txtFIPREDIF.Text) = "" Then
            stFIPREDIF = "%"
        Else
            stFIPREDIF = Trim(txtFIPREDIF.Text)
        End If

        If Trim(txtFIPRUNPR.Text) = "" Then
            stFIPRUNPR = "%"
        Else
            stFIPRUNPR = Trim(txtFIPRUNPR.Text)
        End If

        If Trim(txtFIPRCLSE.Text) = "" Then
            stFIPRCLSE = "%"
        Else
            stFIPRCLSE = Trim(txtFIPRCLSE.Text)
        End If

        If Trim(txtFIPRCASU.Text) = "" Then
            stFIPRCASU = "%"
        Else
            stFIPRCASU = Trim(txtFIPRCASU.Text)
        End If

        If Trim(txtFIPRCAPR.Text) = "" Then
            stFIPRCAPR = "%"
        Else
            stFIPRCAPR = Trim(txtFIPRCAPR.Text)
        End If

        If Trim(txtFIPRMOAD.Text) = "" Then
            stFIPRMOAD = "%"
        Else
            stFIPRMOAD = Trim(txtFIPRMOAD.Text)
        End If

        If Trim(txtFIPRESTA.Text) = "" Then
            stFIPRESTA = "%"
        Else
            stFIPRESTA = Trim(txtFIPRESTA.Text)
        End If

        '*** VERIFICA DATOS DE DESTINACION ***

        If Trim(txtFPLIPUCA.Text) = "" Then
            stFPLIPUCA = "%"
        Else
            stFPLIPUCA = Trim(txtFPLIPUCA.Text)
        End If

        If Trim(txtFPLICOLI.Text) = "" Then
            stFPLICOLI = "%"
        Else
            stFPLICOLI = Trim(txtFPLICOLI.Text)
        End If

        If Trim(txtFPLIESTA.Text) = "" Then
            stFPLIESTA = "%"
        Else
            stFPLIESTA = Trim(txtFPLIESTA.Text)
        End If

    End Sub
    Private Sub pro_ListaDeValores()

        Try
            ' encuestra la posición seleccionada
            Dim I, SW As Byte

            While I < dgvCONSULTA.RowCount And SW = 0
                If dgvCONSULTA.CurrentRow.Cells(I).Selected Then

                    ' llena los campos de ficha predial
                    txtFIPRNUFI.Text = Trim(dgvCONSULTA.CurrentRow.Cells(0).Value.ToString())

                    ' llena los campos de destinacion
                    txtFPLIPUCA.Text = Trim(dgvCONSULTA.CurrentRow.Cells(1).Value.ToString())
                    txtFPLICOLI.Text = Trim(dgvCONSULTA.CurrentRow.Cells(2).Value.ToString())
                    txtFPLIESTA.Text = Trim(dgvCONSULTA.CurrentRow.Cells(3).Value.ToString())

                    ' llena los campos de ficha predial
                    txtFIPRDIRE.Text = Trim(dgvCONSULTA.CurrentRow.Cells(4).Value.ToString())
                    txtFIPRMUNI.Text = Trim(dgvCONSULTA.CurrentRow.Cells(5).Value.ToString())
                    txtFIPRCORR.Text = Trim(dgvCONSULTA.CurrentRow.Cells(6).Value.ToString())
                    txtFIPRBARR.Text = Trim(dgvCONSULTA.CurrentRow.Cells(7).Value.ToString())
                    txtFIPRMANZ.Text = Trim(dgvCONSULTA.CurrentRow.Cells(8).Value.ToString())
                    txtFIPRPRED.Text = Trim(dgvCONSULTA.CurrentRow.Cells(9).Value.ToString())
                    txtFIPREDIF.Text = Trim(dgvCONSULTA.CurrentRow.Cells(10).Value.ToString())
                    txtFIPRUNPR.Text = Trim(dgvCONSULTA.CurrentRow.Cells(11).Value.ToString())
                    txtFIPRCLSE.Text = Trim(dgvCONSULTA.CurrentRow.Cells(12).Value.ToString())
                    txtFIPRCASU.Text = Trim(dgvCONSULTA.CurrentRow.Cells(13).Value.ToString())
                    txtFIPRCAPR.Text = Trim(dgvCONSULTA.CurrentRow.Cells(14).Value.ToString())
                    txtFIPRMOAD.Text = Trim(dgvCONSULTA.CurrentRow.Cells(15).Value.ToString())
                    txtFIPRESTA.Text = Trim(dgvCONSULTA.CurrentRow.Cells(16).Value.ToString())
                    txtRESOMUNI.Text = Trim(dgvCONSULTA.CurrentRow.Cells(5).Value.ToString())
                    txtRESOTIRE.Text = Trim(dgvCONSULTA.CurrentRow.Cells(17).Value.ToString())
                    txtRESOVIGE.Text = Trim(dgvCONSULTA.CurrentRow.Cells(18).Value.ToString())
                    txtRESORESO.Text = Trim(dgvCONSULTA.CurrentRow.Cells(19).Value.ToString())



                    ' busca la lista de valores de ficha predial
                    lblFIPRCLSE.Text = CType(fun_Buscar_Lista_Valores_CLASSECT(Trim(txtFIPRCLSE.Text)), String)
                    lblFIPRCASU.Text = CType(fun_Buscar_Lista_Valores_CATESUEL(Trim(txtFIPRCASU.Text)), String)
                    lblFIPRCAPR.Text = CType(fun_Buscar_Lista_Valores_CARAPRED(Trim(txtFIPRCAPR.Text)), String)
                    lblFIPRMOAD.Text = CType(fun_Buscar_Lista_Valores_MODOADQU(Trim(txtFIPRMOAD.Text)), String)

                    ' busca la lista de valores de destinacion
                    lblFPLIPUCA.Text = CType(fun_Buscar_Lista_Valores_PUNTCARD(Trim(txtFPLIPUCA.Text)), String)

                    SW = 1
                Else
                    I = I + 1
                End If
            End While

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub pro_GuardarConsulta()

        Guardar_stFIPRNUFI = Trim(txtFIPRNUFI.Text)
        Guardar_stFIPRDIRE = Trim(txtFIPRDIRE.Text)
        Guardar_stFIPRMUNI = Trim(txtFIPRMUNI.Text)
        Guardar_stFIPRCORR = Trim(txtFIPRCORR.Text)
        Guardar_stFIPRBARR = Trim(txtFIPRBARR.Text)
        Guardar_stFIPRMANZ = Trim(txtFIPRMANZ.Text)
        Guardar_stFIPRPRED = Trim(txtFIPRPRED.Text)
        Guardar_stFIPREDIF = Trim(txtFIPREDIF.Text)
        Guardar_stFIPRUNPR = Trim(txtFIPRUNPR.Text)
        Guardar_stFIPRCLSE = Trim(txtFIPRCLSE.Text)
        Guardar_stFIPRCASU = Trim(txtFIPRCASU.Text)
        Guardar_stFIPRCAPR = Trim(txtFIPRCAPR.Text)
        Guardar_stFIPRMOAD = Trim(txtFIPRMOAD.Text)
        Guardar_stFIPRESTA = Trim(txtFIPRESTA.Text)
        Guardar_stFPLIPUCA = Trim(txtFPLIPUCA.Text)
        Guardar_stFPLICOLI = Trim(txtFPLICOLI.Text)
        Guardar_stFPLIESTA = Trim(txtFPLIESTA.Text)

    End Sub
    Private Sub pro_ObtenerConsulta()

        txtFIPRNUFI.Text = Guardar_stFIPRNUFI
        txtFIPRDIRE.Text = Guardar_stFIPRDIRE
        txtFIPRMUNI.Text = Guardar_stFIPRMUNI
        txtFIPRCORR.Text = Guardar_stFIPRCORR
        txtFIPRBARR.Text = Guardar_stFIPRBARR
        txtFIPRMANZ.Text = Guardar_stFIPRMANZ
        txtFIPRPRED.Text = Guardar_stFIPRPRED
        txtFIPREDIF.Text = Guardar_stFIPREDIF
        txtFIPRUNPR.Text = Guardar_stFIPRUNPR
        txtFIPRCLSE.Text = Guardar_stFIPRCLSE
        txtFIPRCASU.Text = Guardar_stFIPRCASU
        txtFIPRCAPR.Text = Guardar_stFIPRCAPR
        txtFIPRMOAD.Text = Guardar_stFIPRMOAD
        txtFIPRESTA.Text = Guardar_stFIPRESTA
        txtFPLIPUCA.Text = Guardar_stFPLIPUCA
        txtFPLICOLI.Text = Guardar_stFPLICOLI
        txtFPLIESTA.Text = Guardar_stFPLIESTA


    End Sub
    Private Sub pro_PermisoControlDeComandos()

        Try

            Me.cmdExportarExcel.Enabled = fun_PermisoControlDeComandos(vp_usuario, Me.Name, Me.cmdExportarExcel.Name)
            Me.cmdExportarPlano.Enabled = fun_PermisoControlDeComandos(vp_usuario, Me.Name, Me.cmdExportarPlano.Name)

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub

#End Region

#Region "MENU"

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

            ' parametros de la consulta
            Dim ParametrosConsulta As String = ""

            ' guarda la consulta
            pro_GuardarConsulta()

            ' verifica los datos de los campos
            pro_VerificarDatos()

            ' Concatena la condicion de la consulta
            ParametrosConsulta += "Select "
            ParametrosConsulta += "FiprNufi as NroFicha, "
            ParametrosConsulta += "FpliPuca as PuntoCardinal, "
            ParametrosConsulta += "rtrim(FpliColi) + '_' as Colindante, "
            ParametrosConsulta += "FpliEsta as Estado, "
            ParametrosConsulta += "FiprDire as Direccion, "
            ParametrosConsulta += "FiprMuni as Municio, "
            ParametrosConsulta += "FiprCorr as Corregi, "
            ParametrosConsulta += "FiprBarr as Barrio, "
            ParametrosConsulta += "FiprManz as Manzana, "
            ParametrosConsulta += "FiprPred as Predio, "
            ParametrosConsulta += "FiprEdif as Edificio, "
            ParametrosConsulta += "FiprUnpr as UnidPred, "
            ParametrosConsulta += "FiprClse as Sector, "
            ParametrosConsulta += "FiprCasu as CateSuel, "
            ParametrosConsulta += "FiprCapr as CaraPred, "
            ParametrosConsulta += "FiprMoad as ModoAdqu, "
            ParametrosConsulta += "FiprEsta as Estado, "
            ParametrosConsulta += "FiprTire as TipoReso, "
            ParametrosConsulta += "FiprVige as Vigencia, "
            ParametrosConsulta += "FiprReso as Resoluci "
            ParametrosConsulta += "From FichPred, FiprLind where "
            ParametrosConsulta += "FiprNufi = FpliNufi and "
            ParametrosConsulta += "FiprNufi like '" & stFIPRNUFI & "' and "
            ParametrosConsulta += "FiprDire like '" & stFIPRDIRE & "' and "
            ParametrosConsulta += "FiprMuni like '" & stFIPRMUNI & "' and "
            ParametrosConsulta += "FiprCorr like '" & stFIPRCORR & "' and "
            ParametrosConsulta += "FiprBarr like '" & stFIPRBARR & "' and "
            ParametrosConsulta += "FiprManz like '" & stFIPRMANZ & "' and "
            ParametrosConsulta += "FiprPred like '" & stFIPRPRED & "' and "
            ParametrosConsulta += "FiprEdif like '" & stFIPREDIF & "' and "
            ParametrosConsulta += "FiprUnpr like '" & stFIPRUNPR & "' and "
            ParametrosConsulta += "FiprClse like '" & stFIPRCLSE & "' and "
            ParametrosConsulta += "FiprCasu like '" & stFIPRCASU & "' and "
            ParametrosConsulta += "FiprCapr like '" & stFIPRCAPR & "' and "
            ParametrosConsulta += "FiprMoad like '" & stFIPRMOAD & "' and "
            ParametrosConsulta += "FiprEsta like '" & stFIPRESTA & "' and "
            ParametrosConsulta += "FpliPuca like '" & stFPLIPUCA & "' and "
            ParametrosConsulta += "FpliColi like '" & stFPLICOLI & "' and "
            ParametrosConsulta += "FpliEsta like '" & stFPLIESTA & "' "
            ParametrosConsulta += "order by FiprNufi,FiprClse,FiprMuni,FiprCorr,FiprBarr,FiprManz,FiprPred,FiprEdif,FiprUnpr"

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

            ' cuenta los registros
            If dt.Rows.Count > 0 Then
                ' llena el datagridview
                If dt.Rows.Count > 500 Then
                    ' controla la sobregarga del datagridview
                    If MessageBox.Show("La consulta sobrecargara el sistema" & Chr(Keys.Enter) & Chr(Keys.Enter) & _
                                       "Nro. de registros para cargar :  " & dt.Rows.Count & Chr(Keys.Enter) & Chr(Keys.Enter) & _
                                       "¿ Desea continuar ?", "Mensaje ...", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then
                        ' llena el datagridview
                        Me.dgvCONSULTA.DataSource = dt
                    Else
                        ' sale del proceso de consulta
                        Exit Sub
                    End If
                End If

                ' llena el datagridview
                Me.dgvCONSULTA.DataSource = dt

                ' llena la lista de valores
                pro_ListaDeValores()
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
    Private Sub cmdULTIMACONSULTA_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdULTIMACONSULTA.Click
        pro_LimpiarCampos()
        pro_ObtenerConsulta()
        cmdCONSULTAR.Focus()
    End Sub
    Private Sub cmdPLANO_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExportarPlano.Click
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
                    'txtRUTA.Text = oCrear.FileName

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
                    'txtRUTA.Text = ""
                    txtFIPRNUFI.Focus()
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
        txtFPLIPUCA.Focus()
    End Sub
    Private Sub cmdExportarExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExportarExcel.Click
        Try
            If Me.dgvCONSULTA.RowCount = 0 Then
                MessageBox.Show("No existe datos para exportar", "Mensaje ...", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1)
            Else
                Dim oExp As New cla_ExportarTablaExcel
                oExp.DataTableToExcel(CType(Me.dgvCONSULTA.DataSource, DataTable))
            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try
    End Sub
    Private Sub cmdSALIR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSALIR.Click
        txtFPLIPUCA.Focus()
        Me.Close()
    End Sub

#End Region

#Region "FORMULARIO"

#Region "Load"

    Private Sub frm_consulta_propietario_FIPRPROP_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        pro_LimpiarCampos()
        txtFPLIPUCA.Focus()

        pro_PermisoControlDeComandos()

    End Sub

#End Region

#Region "GotFocus"

    Private Sub txtFIPRNUFI_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFIPRNUFI.GotFocus
        txtFIPRNUFI.SelectionStart = 0
        txtFIPRNUFI.SelectionLength = Len(txtFIPRNUFI.Text)
        strBARRESTA.Items(0).Text = txtFIPRNUFI.AccessibleDescription
    End Sub
    Private Sub txtFIPRDIRE_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFIPRDIRE.GotFocus
        txtFIPRDIRE.SelectionStart = 0
        txtFIPRDIRE.SelectionLength = Len(txtFIPRDIRE.Text)
        strBARRESTA.Items(0).Text = txtFIPRDIRE.AccessibleDescription
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
    Private Sub txtFIPRESTA_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFIPRESTA.GotFocus
        txtFIPRESTA.SelectionStart = 0
        txtFIPRESTA.SelectionLength = Len(txtFIPRESTA.Text)
        strBARRESTA.Items(0).Text = txtFIPRESTA.AccessibleDescription
    End Sub
    Private Sub txtFPDEDEEC_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFPLIPUCA.GotFocus
        txtFPLIPUCA.SelectionStart = 0
        txtFPLIPUCA.SelectionLength = Len(txtFPLIPUCA.Text)
        strBARRESTA.Items(0).Text = txtFPLIPUCA.AccessibleDescription
    End Sub
    Private Sub txtFPDEPORC_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFPLICOLI.GotFocus
        txtFPLICOLI.SelectionStart = 0
        txtFPLICOLI.SelectionLength = Len(txtFPLICOLI.Text)
        strBARRESTA.Items(0).Text = txtFPLICOLI.AccessibleDescription
    End Sub
    Private Sub txtFPDEESTA_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFPLIESTA.GotFocus
        txtFPLIESTA.SelectionStart = 0
        txtFPLIESTA.SelectionLength = Len(txtFPLIESTA.Text)
        strBARRESTA.Items(0).Text = txtFPLIESTA.AccessibleDescription
    End Sub
    Private Sub cmdCONSULTAR_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdCONSULTAR.GotFocus
        strBARRESTA.Items(0).Text = cmdCONSULTAR.AccessibleDescription
    End Sub
    Private Sub cmdPLANO_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdExportarPlano.GotFocus
        strBARRESTA.Items(0).Text = cmdExportarPlano.AccessibleDescription
    End Sub
    Private Sub cmdSALIR_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdSALIR.GotFocus
        strBARRESTA.Items(0).Text = cmdSALIR.AccessibleDescription
    End Sub
    Private Sub cmdLIMPIAR_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdLIMPIAR.GotFocus
        strBARRESTA.Items(0).Text = cmdLIMPIAR.AccessibleDescription
    End Sub
    Private Sub dgvCONSULTA_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvCONSULTA.GotFocus
        strBARRESTA.Items(0).Text = dgvCONSULTA.AccessibleDescription
    End Sub
    Private Sub cmdExportarExcel_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdExportarExcel.GotFocus
        strBARRESTA.Items(0).Text = cmdExportarExcel.AccessibleDescription
    End Sub

#End Region

#Region "KeyPress"

    Private Sub txtFIPRNUFI_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFIPRNUFI.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            txtFIPRDIRE.Focus()
        End If

    End Sub
    Private Sub txtFIPRDIRE_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFIPRDIRE.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            txtFIPRMUNI.Focus()
        End If
    End Sub
    Private Sub txtFIPRMUNI_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFIPRMUNI.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            txtFIPRCORR.Focus()
        End If

    End Sub
    Private Sub txtFIPRCORR_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFIPRCORR.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            txtFIPRBARR.Focus()
        End If

    End Sub
    Private Sub txtFIPRBARR_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFIPRBARR.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            txtFIPRMANZ.Focus()
        End If

    End Sub
    Private Sub txtFIPRMANZ_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFIPRMANZ.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            txtFIPRPRED.Focus()
        End If

    End Sub
    Private Sub txtFIPRPRED_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFIPRPRED.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            txtFIPREDIF.Focus()
        End If

    End Sub
    Private Sub txtFIPREDIF_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFIPREDIF.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            txtFIPRUNPR.Focus()
        End If

    End Sub
    Private Sub txtFIPRUNPR_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFIPRUNPR.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            txtFIPRESTA.Focus()
        End If

    End Sub
    Private Sub txtFIPRCLSE_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFIPRCLSE.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            txtFIPRCASU.Focus()
        End If
    End Sub
    Private Sub txtFIPRCASU_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFIPRCASU.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            txtFIPRCAPR.Focus()
        End If
    End Sub
    Private Sub txtFIPRCAPR_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFIPRCAPR.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            txtFIPRMOAD.Focus()
        End If
    End Sub
    Private Sub txtFIPRMOAD_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFIPRMOAD.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            cmdCONSULTAR.Focus()
        End If
    End Sub
    Private Sub txtFIPRESTA_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFIPRESTA.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            txtFIPRCLSE.Focus()
        End If
    End Sub
    Private Sub txtFPDEDEEC_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFPLIPUCA.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            txtFPLICOLI.Focus()
        End If
    End Sub
    Private Sub txtFPDEPORC_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFPLICOLI.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            txtFPLIESTA.Focus()
        End If
    End Sub
    Private Sub txtFPDEESTA_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFPLIESTA.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            txtFIPRNUFI.Focus()
        End If
    End Sub


#End Region

#Region "KeyDown"

    Private Sub cmdCONSULTAR_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cmdCONSULTAR.KeyDown, txtFIPRNUFI.KeyDown, txtFIPRDIRE.KeyDown, txtFIPRMUNI.KeyDown, txtFIPRCORR.KeyDown, txtFIPRBARR.KeyDown, txtFIPRMANZ.KeyDown, txtFIPRPRED.KeyDown, txtFIPREDIF.KeyDown, txtFIPRUNPR.KeyDown, txtFIPRCLSE.KeyDown, txtFIPRCASU.KeyDown, txtFIPRCAPR.KeyDown, txtFIPRMOAD.KeyDown, txtFIPRESTA.KeyDown, dgvCONSULTA.KeyDown, txtFPLIPUCA.KeyDown, txtFPLICOLI.KeyDown, txtFPLIESTA.KeyDown
        If e.KeyCode = Keys.F8 Then
            cmdCONSULTAR.PerformClick()
        End If

        If e.KeyCode = Keys.F7 Then
            cmdULTIMACONSULTA.PerformClick()
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

#Region "Validated"

    Private Sub txtFIPRCLSE_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFIPRCLSE.Validated
        If Trim(txtFIPRCLSE.Text) = "" Then
            lblFIPRCLSE.Text = ""
        Else
            lblFIPRCLSE.Text = CType(fun_Buscar_Lista_Valores_CLASSECT(Trim(txtFIPRCLSE.Text)), String)
        End If
    End Sub
    Private Sub txtFIPRCASU_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFIPRCASU.Validated
        If Trim(txtFIPRCASU.Text) = "" Then
            lblFIPRCASU.Text = ""
        Else
            lblFIPRCASU.Text = CType(fun_Buscar_Lista_Valores_CATESUEL(Trim(txtFIPRCASU.Text)), String)
        End If
    End Sub
    Private Sub txtFIPRCAPR_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFIPRCAPR.Validated
        If Trim(txtFIPRCAPR.Text) = "" Then
            lblFIPRCAPR.Text = ""
        Else
            lblFIPRCAPR.Text = CType(fun_Buscar_Lista_Valores_CARAPRED(Trim(txtFIPRCAPR.Text)), String)
        End If
    End Sub
    Private Sub txtFIPRMOAD_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFIPRMOAD.Validated
        If Trim(txtFIPRMOAD.Text) = "" Then
            lblFIPRMOAD.Text = ""
        Else
            lblFIPRMOAD.Text = CType(fun_Buscar_Lista_Valores_MODOADQU(Trim(txtFIPRMOAD.Text)), String)
        End If
    End Sub
    Private Sub txtFPDEDEEC_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFPLIPUCA.Validated
        If Trim(txtFPLIPUCA.Text) = "" Then
            lblFPLIPUCA.Text = ""
        Else
            lblFPLIPUCA.Text = CType(fun_Buscar_Lista_Valores_DESTECON(Trim(txtFPLIPUCA.Text)), String)
        End If
    End Sub
    Private Sub txtFIPRMUNI_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFIPRMUNI.Validated
        If Me.txtFIPRMUNI.Text <> "" And fun_Verificar_Dato_Numerico_Evento_Validated(Me.txtFIPRMUNI.Text) = True Then
            Me.txtFIPRMUNI.Text = fun_Formato_Mascara_3_String(Me.txtFIPRMUNI.Text)
        End If
    End Sub
    Private Sub txtFIPRCORR_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFIPRCORR.Validated
        If Me.txtFIPRCORR.Text <> "" And fun_Verificar_Dato_Numerico_Evento_Validated(Me.txtFIPRCORR.Text) = True Then
            Me.txtFIPRCORR.Text = fun_Formato_Mascara_2_String(Me.txtFIPRCORR.Text)
        End If
    End Sub
    Private Sub txtFIPRBARR_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFIPRBARR.Validated
        If Me.txtFIPRBARR.Text <> "" And fun_Verificar_Dato_Numerico_Evento_Validated(Me.txtFIPRBARR.Text) = True Then
            Me.txtFIPRBARR.Text = fun_Formato_Mascara_3_String(Me.txtFIPRBARR.Text)
        End If
    End Sub
    Private Sub txtFIPRMANZ_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFIPRMANZ.Validated
        If Me.txtFIPRMANZ.Text <> "" And fun_Verificar_Dato_Numerico_Evento_Validated(Me.txtFIPRMANZ.Text) = True Then
            Me.txtFIPRMANZ.Text = fun_Formato_Mascara_3_String(Me.txtFIPRMANZ.Text)
        End If
    End Sub
    Private Sub txtFIPRPRED_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFIPRPRED.Validated
        If Me.txtFIPRPRED.Text <> "" And fun_Verificar_Dato_Numerico_Evento_Validated(Me.txtFIPRPRED.Text) = True Then
            Me.txtFIPRPRED.Text = fun_Formato_Mascara_5_String(Me.txtFIPRPRED.Text)
        End If
    End Sub
    Private Sub txtFIPREDIF_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFIPREDIF.Validated
        If Me.txtFIPREDIF.Text <> "" And fun_Verificar_Dato_Numerico_Evento_Validated(Me.txtFIPREDIF.Text) = True Then
            Me.txtFIPREDIF.Text = fun_Formato_Mascara_3_String(Me.txtFIPREDIF.Text)
        End If
    End Sub
    Private Sub txtFIPRUNPR_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFIPRUNPR.Validated
        If Me.txtFIPRUNPR.Text <> "" And fun_Verificar_Dato_Numerico_Evento_Validated(Me.txtFIPRUNPR.Text) = True Then
            Me.txtFIPRUNPR.Text = fun_Formato_Mascara_5_String(Me.txtFIPRUNPR.Text)
        End If
    End Sub


#End Region

#Region "TextChanged"

    Private Sub tstBAESDESC_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tstBAESDESC.TextChanged
        If tstBAESDESC.Text <> "" Then
            MessageBox.Show(Trim(tstBAESDESC.Text), "Mensaje ...", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1)
        End If
    End Sub

#End Region

#End Region

End Class