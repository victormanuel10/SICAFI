Imports REGLAS_DEL_NEGOCIO
Imports System
Imports System.IO
Imports System.Data
Imports System.Data.Sqlclient
Imports System.Configuration
Imports System.Text

Public Class frm_exportar_planos_ZONAS

    '=============================================================
    '*** FORMULARIO EXPORTAR PLANOS ZONAS FISICAS Y ECONOMICAS ***
    '=============================================================

#Region "INSTANCIAR FORMULARIO"

    Private Shared frm_Instance = Nothing

    Public Shared Function instance() As frm_exportar_planos_ZONAS
        If frm_Instance Is Nothing OrElse frm_Instance.isdisposed = True Then
            frm_Instance = New frm_exportar_planos_ZONAS
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

#Region "VARIABLES LOCALES"

   Private vl_stFIPRNUFI As String
   Private vl_stFIPRFIIN As String
   Private vl_stFIPRFIFI As String
   Private vl_stFIPRMUNI As String
   Private vl_stFIPRCORR As String
   Private vl_stFIPRBARR As String
   Private vl_stFIPRMANZ As String
   Private vl_stFIPRPRED As String
   Private vl_stFIPREDIF As String
   Private vl_stFIPRUNPR As String
   Private vl_stFIPRCLSE As String
   Private vl_stFIPRVIGE As String
   Private vl_stFIPRFEPA As String
   Private vl_stFIPRTIFI As String

   Private vl_stFPZEZONA As String
   Private vl_stFPZEPORC As String

   Private vl_stFPZFZONA As String
   Private vl_stFPZFPORC As String

   Private dt_FICHPRED As New DataTable
   Private dt_FIPRZONA As New DataTable
   Private dt As New DataTable

   Private oEjecutar As New SqlCommand
   Private oConexion As New SqlConnection
   Private oAdapter As New SqlDataAdapter
   Private oReader As SqlDataReader
   Private oCrear As New SaveFileDialog

   Private stRutaArchivo As String
   Private inProceso As Integer

#End Region

#Region "PROCEDIMIENTOS"

Private Sub pro_LimpiarCampos()

        Me.txtFIPRFIIN.Text = "0"
        Me.txtFIPRFIFI.Text = "999999999"
        Me.txtFIPRMUNI.Text = "%"
        Me.txtFIPRCORR.Text = "%"
        Me.txtFIPRBARR.Text = "%"
        Me.txtFIPRMANZ.Text = "%"
        Me.txtFIPRPRED.Text = "%"
        Me.txtFIPREDIF.Text = "%"
        Me.txtFIPRUNPR.Text = "%"
        Me.txtFIPRCLSE.Text = "%"

        Me.lblRutaArchivo.Text = ""

        dt_FICHPRED = New DataTable
        dt_FIPRZONA = New DataTable

End Sub
Private Sub pro_VerificarCampos()

   If Me.txtFIPRMUNI.Text = "" Then
      vl_stFIPRMUNI = "%"
   Else
      vl_stFIPRMUNI = Trim(Me.txtFIPRMUNI.Text)
   End If

   If Me.txtFIPRCORR.Text = "" Then
      vl_stFIPRCORR = "%"
   Else
      vl_stFIPRCORR = Trim(Me.txtFIPRCORR.Text)
   End If

   If Me.txtFIPRBARR.Text = "" Then
      vl_stFIPRBARR = "%"
   Else
      vl_stFIPRBARR = Trim(Me.txtFIPRBARR.Text)
   End If

   If Me.txtFIPRMANZ.Text = "" Then
      vl_stFIPRMANZ = "%"
   Else
      vl_stFIPRMANZ = Trim(Me.txtFIPRMANZ.Text)
   End If

   If Me.txtFIPRPRED.Text = "" Then
      vl_stFIPRPRED = "%"
   Else
      vl_stFIPRPRED = Trim(Me.txtFIPRPRED.Text)
   End If

   If Me.txtFIPREDIF.Text = "" Then
      vl_stFIPREDIF = "%"
   Else
      vl_stFIPREDIF = Trim(Me.txtFIPREDIF.Text)
   End If

   If Me.txtFIPRUNPR.Text = "" Then
      vl_stFIPRUNPR = "%"
   Else
      vl_stFIPRUNPR = Trim(Me.txtFIPRUNPR.Text)
   End If

   If Me.txtFIPRCLSE.Text = "" Then
      vl_stFIPRCLSE = "%"
   Else
      vl_stFIPRCLSE = Trim(Me.txtFIPRCLSE.Text)
   End If

End Sub


#End Region

#Region "FUNCIONES"

Private Function fun_ConsultaFichaPredial() As DataTable

         Try
            ' declara las variables
            vl_stFIPRFIIN = Trim(Me.txtFIPRFIIN.Text)
            vl_stFIPRFIFI = Trim(Me.txtFIPRFIFI.Text)
            vl_stFIPRMUNI = Trim(Me.txtFIPRMUNI.Text)
            vl_stFIPRCORR = Trim(Me.txtFIPRCORR.Text)
            vl_stFIPRBARR = Trim(Me.txtFIPRBARR.Text)
            vl_stFIPRMANZ = Trim(Me.txtFIPRMANZ.Text)
            vl_stFIPRPRED = Trim(Me.txtFIPRPRED.Text)
            vl_stFIPREDIF = Trim(Me.txtFIPREDIF.Text)
            vl_stFIPRUNPR = Trim(Me.txtFIPRUNPR.Text)
            vl_stFIPRCLSE = Trim(Me.txtFIPRCLSE.Text)

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
            ParametrosConsulta += "Select "
            ParametrosConsulta += "FiprNufi, "
            ParametrosConsulta += "FiprMuni, "
            ParametrosConsulta += "FiprCorr, "
            ParametrosConsulta += "FiprBarr, "
            ParametrosConsulta += "FiprManz, "
            ParametrosConsulta += "FiprPred, "
            ParametrosConsulta += "FiprEdif, "
            ParametrosConsulta += "FiprUnpr, "
            ParametrosConsulta += "FiprClse, "
            ParametrosConsulta += "FiprVige, "
            ParametrosConsulta += "FiprTifi "
            ParametrosConsulta += "From FichPred where "
            ParametrosConsulta += "FiprMuni like '" & Trim(vl_stFIPRMUNI) & "' and "
            ParametrosConsulta += "FiprCorr like '" & Trim(vl_stFIPRCORR) & "' and "
            ParametrosConsulta += "FiprBarr like '" & Trim(vl_stFIPRBARR) & "' and "
            ParametrosConsulta += "FiprManz like '" & Trim(vl_stFIPRMANZ) & "' and "
            ParametrosConsulta += "FiprPred like '" & Trim(vl_stFIPRPRED) & "' and "
            ParametrosConsulta += "FiprEdif like '" & Trim(vl_stFIPREDIF) & "' and "
            ParametrosConsulta += "FiprUnpr like '" & Trim(vl_stFIPRUNPR) & "' and "
            ParametrosConsulta += "FiprClse like '" & Trim(vl_stFIPRCLSE) & "' and "
            ParametrosConsulta += "FiprNufi between '" & Trim(vl_stFIPRFIIN) & "' and '" & Trim(vl_stFIPRFIFI) & "' and "
            ParametrosConsulta += "FiprEsta = 'ac' and "
            ParametrosConsulta += "(exists(select 1 from fiprcons "
            ParametrosConsulta += "where fiprnufi = fpconufi and fpcoesta = 'ac' and fpcomejo = 0) "
            ParametrosConsulta += "or not exists(select 1 from fiprcons "
            ParametrosConsulta += "where fiprnufi = fpconufi)) "
            ParametrosConsulta += "order by FiprMuni,FiprCorr,FiprBarr,FiprManz,FiprPred,FiprEdif,FiprUnpr"

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

            Return dt

      Catch ex As Exception
        Return Nothing
        MessageBox.Show(Err.Description)
      End Try

End Function

#End Region

#Region "MENU"

Private Sub cmdRuraArchivo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdRuraArchivo.Click

          Try
            ' instacia la caja de dialogo
            oCrear = New SaveFileDialog

            ' llama la caja de dialogo
            oCrear.InitialDirectory = My.Computer.FileSystem.SpecialDirectories.MyDocuments
            oCrear.Filter = "Archivo de texto (*.txt)|*.txt"
            oCrear.FilterIndex = 1 'coloca por defecto el *.txt
            oCrear.FileName = ""
            oCrear.ShowDialog()

            stRutaArchivo = oCrear.FileName
            lblRutaArchivo.Text = oCrear.FileName

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

End Sub
Private Sub cmdExportarPlano_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExportarPlano.Click

        Try
            ' verifica la ruta del acchivo
            If Trim(stRutaArchivo) <> "" Then

                ' recorre el archivo a exportar
                FileOpen(1, oCrear.FileName, OpenMode.Output) 'crea y destruye si hay otro igual

                ' variable separador
                Dim stSeparador As String = Trim(Me.txtSEPARADOR.Text)

                ' apaga el boton
                Me.cmdExportarPlano.Enabled = False

                If Me.rbdZONAECON.Checked = True Then

                    ' condiciona los campos de la consulta
                    pro_VerificarCampos()

                    ' consulta la tabla ficha predial
                    dt_FICHPRED = New DataTable
                    dt_FICHPRED = fun_ConsultaFichaPredial()

                    ' verifica la tabla con registro
                    If dt_FICHPRED.Rows.Count > 0 Then

                        ' inicia la barra
                        inProceso = 0
                        pbPROCESO.Value = 0
                        pbPROCESO.Maximum = dt_FICHPRED.Rows.Count
                        Timer1.Enabled = True

                        ' declaro la variable
                        Dim i As Integer = 0

                        ' recorro la variable
                        For i = 0 To dt_FICHPRED.Rows.Count - 1

                            ' llena las variables
                            vl_stFIPRNUFI = Trim(dt_FICHPRED.Rows(i).Item("FIPRNUFI").ToString)
                            vl_stFIPRVIGE = Trim(dt_FICHPRED.Rows(i).Item("FIPRVIGE").ToString)
                            vl_stFIPRMUNI = Trim(dt_FICHPRED.Rows(i).Item("FIPRMUNI").ToString)
                            vl_stFIPRCLSE = Trim(dt_FICHPRED.Rows(i).Item("FIPRCLSE").ToString)
                            vl_stFIPRCORR = Trim(dt_FICHPRED.Rows(i).Item("FIPRCORR").ToString)
                            vl_stFIPRBARR = Trim(dt_FICHPRED.Rows(i).Item("FIPRBARR").ToString)
                            vl_stFIPRMANZ = Trim(dt_FICHPRED.Rows(i).Item("FIPRMANZ").ToString)
                            vl_stFIPRPRED = Trim(dt_FICHPRED.Rows(i).Item("FIPRPRED").ToString)
                            vl_stFIPREDIF = Trim(dt_FICHPRED.Rows(i).Item("FIPREDIF").ToString)
                            vl_stFIPRUNPR = Trim(dt_FICHPRED.Rows(i).Item("FIPRUNPR").ToString)
                            vl_stFIPRFEPA = "01-jan-" & Trim(vl_stFIPRVIGE.Substring(2, 2).ToString)
                            vl_stFIPRTIFI = Trim(dt_FICHPRED.Rows(i).Item("FIPRTIFI").ToString)

                            ' instancia las clase
                            Dim objZONAECON As New cla_FIPRZOEC
                            Dim tblZONAECON As New DataTable

                            tblZONAECON = objZONAECON.fun_Consultar_FIPRZOEC_X_FICHA_PREDIAL(vl_stFIPRNUFI)

                            ' verifica la tabla con registro
                            If tblZONAECON.Rows.Count > 0 Then

                                ' declara la variable
                                Dim k As Integer = 0

                                ' recorre la tabla
                                For k = 0 To tblZONAECON.Rows.Count - 1

                                    vl_stFPZEZONA = Trim(tblZONAECON.Rows(k).Item("FPZEZOEC").ToString)
                                    vl_stFPZEPORC = Trim(tblZONAECON.Rows(k).Item("FPZEPORC").ToString)

                                    ' formato vigencia
                                    vl_stFIPRVIGE = vl_stFIPRVIGE.PadLeft(4, "0")
                                    vl_stFIPRVIGE = vl_stFIPRVIGE.Substring(0, 4)

                                    ' formato municipio
                                    vl_stFIPRMUNI = vl_stFIPRMUNI.PadLeft(3, "0")
                                    vl_stFIPRMUNI = vl_stFIPRMUNI.Substring(0, 3)

                                    ' formato clase o sector
                                    vl_stFIPRCLSE = vl_stFIPRCLSE.PadLeft(1, "0")
                                    vl_stFIPRCLSE = vl_stFIPRCLSE.Substring(0, 1)

                                    ' formato corregimiento
                                    vl_stFIPRCORR = vl_stFIPRCORR.PadLeft(3, "0")
                                    vl_stFIPRCORR = vl_stFIPRCORR.Substring(0, 3)

                                    ' formato barrio
                                    vl_stFIPRBARR = vl_stFIPRBARR.PadLeft(3, "0")
                                    vl_stFIPRBARR = vl_stFIPRBARR.Substring(0, 3)

                                    ' formato manzana
                                    vl_stFIPRMANZ = vl_stFIPRMANZ.PadLeft(4, "0")
                                    vl_stFIPRMANZ = vl_stFIPRMANZ.Substring(0, 4)

                                    ' formato predio
                                    vl_stFIPRPRED = vl_stFIPRPRED.PadLeft(5, "0")
                                    vl_stFIPRPRED = vl_stFIPRPRED.Substring(0, 5)

                                    ' formato edificio
                                    vl_stFIPREDIF = vl_stFIPREDIF.PadLeft(4, "0")
                                    vl_stFIPREDIF = vl_stFIPREDIF.Substring(0, 4)

                                    ' formato unidad de predial
                                    vl_stFIPRUNPR = vl_stFIPRUNPR.PadLeft(5, "0")
                                    vl_stFIPRUNPR = vl_stFIPRUNPR.Substring(0, 5)

                                    ' formato zona
                                    vl_stFPZEZONA = vl_stFPZEZONA.PadLeft(3, "0")
                                    vl_stFPZEZONA = vl_stFPZEZONA.Substring(0, 3)

                                    ' formato porcentaje
                                    vl_stFPZEPORC = vl_stFPZEPORC.PadLeft(3, "0")
                                    vl_stFPZEPORC = vl_stFPZEPORC.Substring(0, 3)

                                    ' formato tipo de ficha
                                    vl_stFIPRTIFI = vl_stFIPRTIFI.PadLeft(1, "0")
                                    vl_stFIPRTIFI = vl_stFIPRTIFI.Substring(0, 1)


                                    ' exportar los datos
                                    PrintLine(1, vl_stFIPRVIGE & stSeparador & _
                                                 vl_stFIPRMUNI & stSeparador & _
                                                 vl_stFIPRCLSE & stSeparador & _
                                                 vl_stFIPRCORR & stSeparador & _
                                                 vl_stFIPRBARR & stSeparador & _
                                                 vl_stFIPRMANZ & stSeparador & _
                                                 vl_stFIPRPRED & stSeparador & _
                                                 vl_stFIPREDIF & stSeparador & _
                                                 vl_stFIPRUNPR & stSeparador & _
                                                 vl_stFPZEZONA & stSeparador & _
                                                 vl_stFPZEPORC & stSeparador & _
                                                 vl_stFIPRFEPA & stSeparador & _
                                                 vl_stFIPRTIFI)

                                Next

                            End If

                            ' Incrementa la barra
                            inProceso = inProceso + 1
                            pbPROCESO.Value = inProceso

                        Next

                    Else
                        MessageBox.Show("No existen registros en base de datos", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1)
                        Me.cmdExportarPlano.Focus()
                    End If

                End If

                ' opcion de zona física
                If Me.rbdZONAFISI.Checked = True Then

                    ' condiciona los campos de la consulta
                    pro_VerificarCampos()

                    ' consulta la tabla ficha predial
                    dt_FICHPRED = New DataTable
                    dt_FICHPRED = fun_ConsultaFichaPredial()

                    ' verifica la tabla con registro
                    If dt_FICHPRED.Rows.Count > 0 Then

                        ' inicia la barra
                        inProceso = 0
                        pbPROCESO.Value = 0
                        pbPROCESO.Maximum = dt_FICHPRED.Rows.Count
                        Timer1.Enabled = True

                        ' declaro la variable
                        Dim i As Integer = 0

                        ' recorro la variable
                        For i = 0 To dt_FICHPRED.Rows.Count - 1

                            ' llena las variables
                            vl_stFIPRNUFI = Trim(dt_FICHPRED.Rows(i).Item("FIPRNUFI").ToString)
                            vl_stFIPRVIGE = Trim(dt_FICHPRED.Rows(i).Item("FIPRVIGE").ToString)
                            vl_stFIPRMUNI = Trim(dt_FICHPRED.Rows(i).Item("FIPRMUNI").ToString)
                            vl_stFIPRCLSE = Trim(dt_FICHPRED.Rows(i).Item("FIPRCLSE").ToString)
                            vl_stFIPRCORR = Trim(dt_FICHPRED.Rows(i).Item("FIPRCORR").ToString)
                            vl_stFIPRBARR = Trim(dt_FICHPRED.Rows(i).Item("FIPRBARR").ToString)
                            vl_stFIPRMANZ = Trim(dt_FICHPRED.Rows(i).Item("FIPRMANZ").ToString)
                            vl_stFIPRPRED = Trim(dt_FICHPRED.Rows(i).Item("FIPRPRED").ToString)
                            vl_stFIPREDIF = Trim(dt_FICHPRED.Rows(i).Item("FIPREDIF").ToString)
                            vl_stFIPRUNPR = Trim(dt_FICHPRED.Rows(i).Item("FIPRUNPR").ToString)
                            vl_stFIPRFEPA = "01-jan-" & Trim(vl_stFIPRVIGE.Substring(2, 2).ToString)
                            vl_stFIPRTIFI = Trim(dt_FICHPRED.Rows(i).Item("FIPRTIFI").ToString)

                            ' instancia las clase
                            Dim objZONAFISI As New cla_FIPRZOFI
                            Dim tblZONAFISI As New DataTable

                            tblZONAFISI = objZONAFISI.fun_Consultar_FIPRZOFI_X_FICHA_PREDIAL(vl_stFIPRNUFI)

                            ' verifica la tabla con registro
                            If tblZONAFISI.Rows.Count > 0 Then

                                ' declara la variable
                                Dim k As Integer = 0

                                ' recorre la tabla
                                For k = 0 To tblZONAFISI.Rows.Count - 1

                                    vl_stFPZFZONA = Trim(tblZONAFISI.Rows(k).Item("FPZFZOFI").ToString)
                                    vl_stFPZFPORC = Trim(tblZONAFISI.Rows(k).Item("FPZFPORC").ToString)

                                    ' formato vigencia
                                    vl_stFIPRVIGE = vl_stFIPRVIGE.PadLeft(4, "0")
                                    vl_stFIPRVIGE = vl_stFIPRVIGE.Substring(0, 4)

                                    ' formato municipio
                                    vl_stFIPRMUNI = vl_stFIPRMUNI.PadLeft(3, "0")
                                    vl_stFIPRMUNI = vl_stFIPRMUNI.Substring(0, 3)

                                    ' formato clase o sector
                                    vl_stFIPRCLSE = vl_stFIPRCLSE.PadLeft(1, "0")
                                    vl_stFIPRCLSE = vl_stFIPRCLSE.Substring(0, 1)

                                    ' formato corregimiento
                                    vl_stFIPRCORR = vl_stFIPRCORR.PadLeft(3, "0")
                                    vl_stFIPRCORR = vl_stFIPRCORR.Substring(0, 3)

                                    ' formato barrio
                                    vl_stFIPRBARR = vl_stFIPRBARR.PadLeft(3, "0")
                                    vl_stFIPRBARR = vl_stFIPRBARR.Substring(0, 3)

                                    ' formato manzana
                                    vl_stFIPRMANZ = vl_stFIPRMANZ.PadLeft(4, "0")
                                    vl_stFIPRMANZ = vl_stFIPRMANZ.Substring(0, 4)

                                    ' formato predio
                                    vl_stFIPRPRED = vl_stFIPRPRED.PadLeft(5, "0")
                                    vl_stFIPRPRED = vl_stFIPRPRED.Substring(0, 5)

                                    ' formato edificio
                                    vl_stFIPREDIF = vl_stFIPREDIF.PadLeft(4, "0")
                                    vl_stFIPREDIF = vl_stFIPREDIF.Substring(0, 4)

                                    ' formato unidad de predial
                                    vl_stFIPRUNPR = vl_stFIPRUNPR.PadLeft(5, "0")
                                    vl_stFIPRUNPR = vl_stFIPRUNPR.Substring(0, 5)

                                    ' formato zona
                                    vl_stFPZFZONA = vl_stFPZFZONA.PadLeft(3, "0")
                                    vl_stFPZFZONA = vl_stFPZFZONA.Substring(0, 3)

                                    ' formato porcentaje
                                    vl_stFPZFPORC = vl_stFPZFPORC.PadLeft(3, "0")
                                    vl_stFPZFPORC = vl_stFPZFPORC.Substring(0, 3)

                                    ' formato tipo de ficha
                                    vl_stFIPRTIFI = vl_stFIPRTIFI.PadLeft(1, "0")
                                    vl_stFIPRTIFI = vl_stFIPRTIFI.Substring(0, 1)


                                    ' exportar los datos
                                    PrintLine(1, vl_stFIPRVIGE & stSeparador & _
                                                 vl_stFIPRMUNI & stSeparador & _
                                                 vl_stFIPRCLSE & stSeparador & _
                                                 vl_stFIPRCORR & stSeparador & _
                                                 vl_stFIPRBARR & stSeparador & _
                                                 vl_stFIPRMANZ & stSeparador & _
                                                 vl_stFIPRPRED & stSeparador & _
                                                 vl_stFIPREDIF & stSeparador & _
                                                 vl_stFIPRUNPR & stSeparador & _
                                                 vl_stFPZFZONA & stSeparador & _
                                                 vl_stFPZFPORC & stSeparador & _
                                                 vl_stFIPRFEPA & stSeparador & _
                                                 vl_stFIPRTIFI)

                                Next

                            End If

                            ' Incrementa la barra
                            inProceso = inProceso + 1
                            pbPROCESO.Value = inProceso

                        Next

                    Else
                        MessageBox.Show("No existen registros en base de datos", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1)
                        Me.cmdExportarPlano.Focus()
                    End If

                End If

                ' coloca la barra en cero
                Me.pbPROCESO.Value = 0
                MessageBox.Show("Archivo plano creado corectamente", "Mensaje ...", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)

                ' prende el boton
                Me.cmdExportarPlano.Enabled = True

                If MessageBox.Show("¿ Desea abrir el archivo plano ?", "Mensaje ...", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then
                    ' Abrir con Process.Start el archivo de texto
                    Process.Start(stRutaArchivo)
                End If

            Else
                MessageBox.Show("No existe ruta seleccionada", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1)
                cmdExportarPlano.Focus()
            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        Finally
            FileClose(1)
        End Try

End Sub
Private Sub cmdLimpiar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdLimpiar.Click
  pro_LimpiarCampos()
End Sub
Private Sub cmdSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSalir.Click
  Me.Close()
End Sub

#End Region

#Region "FORMULARIO"

#Region "Validated"

    Private Sub txtFIPRFIIN_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFIPRFIIN.Validated
        If fun_Verificar_Dato_Numerico_Evento_Validated(Trim(Me.txtFIPRFIIN.Text)) = True Then
            Me.txtFIPRFIIN.Text = Val(Trim(Me.txtFIPRFIIN.Text))
        Else
            mod_MENSAJE.Inco_Valo_Nume()
            Me.txtFIPRFIIN.Focus()
        End If
    End Sub
    Private Sub txtFIPRFIFI_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFIPRFIFI.Validated
        If fun_Verificar_Dato_Numerico_Evento_Validated(Trim(Me.txtFIPRFIFI.Text)) = True Then
            Me.txtFIPRFIFI.Text = Val(Trim(Me.txtFIPRFIFI.Text))
        Else
            mod_MENSAJE.Inco_Valo_Nume()
            Me.txtFIPRFIFI.Focus()
        End If
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

#End Region

#Region "TextChanged"

    Private Sub lblRutaArchivo_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles lblRutaArchivo.TextChanged

        If lblRutaArchivo.Text.Length > 0 Then
            cmdExportarPlano.Enabled = True
        Else
            cmdExportarPlano.Enabled = False
        End If

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
            txtFIPRCLSE.Focus()
        End If
    End Sub
    Private Sub txtFIPRCLSE_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFIPRCLSE.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            cmdRuraArchivo.Focus()
        End If
    End Sub

#End Region

#Region "GotFocus"

    Private Sub rbdFichaPredial_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles rbdZONAECON.GotFocus
        strBARRESTA.Items(0).Text = rbdZONAECON.AccessibleDescription
    End Sub
    Private Sub rbdFichaResumen_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles rbdZONAFISI.GotFocus
        strBARRESTA.Items(0).Text = rbdZONAFISI.AccessibleDescription
    End Sub
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
       Private Sub cmdRuraArchivo_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdRuraArchivo.GotFocus
        strBARRESTA.Items(0).Text = cmdRuraArchivo.AccessibleDescription
    End Sub
    Private Sub cmdExportarPlano_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdExportarPlano.GotFocus
        strBARRESTA.Items(0).Text = cmdExportarPlano.AccessibleDescription
    End Sub
    Private Sub cmdLimpiar_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdLimpiar.GotFocus
        strBARRESTA.Items(0).Text = cmdLimpiar.AccessibleDescription
    End Sub
    Private Sub cmdSalir_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdSalir.GotFocus
        strBARRESTA.Items(0).Text = cmdSalir.AccessibleDescription
    End Sub

#End Region

#End Region

End Class