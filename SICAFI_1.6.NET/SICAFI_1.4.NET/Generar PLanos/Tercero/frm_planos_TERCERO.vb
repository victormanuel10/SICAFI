Imports REGLAS_DEL_NEGOCIO

Public Class frm_planos_TERCERO

    '=================================
    '*** FORMULARIO PLANOS TERCERO ***
    '=================================

#Region "INSTANCIAR FORMULARIO"

    Private Shared frm_Instance = Nothing

    Public Shared Function instance() As frm_planos_TERCERO
        If frm_Instance Is Nothing OrElse frm_Instance.isdisposed = True Then
            frm_Instance = New frm_planos_TERCERO
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

    Dim Separador As String
    Dim thisFile As Object
    Dim item As New ListViewItem

#End Region

#Region "EXPORTAR PLANO"

    Private Sub frm_planos_TERCERO_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cboGPEXSEPA.SelectedIndex = 0
        'txtGPIMRUTA.Text = CurDir()
        'txtGPIMRUTA.Text = "C:\TEMP"

    End Sub

    Private Sub cmdGEPLEXPO_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGEPLEXPO.Click
        Dim oCrear As New SaveFileDialog 'crea la instancia para crear y salvar

        Try
            oCrear.InitialDirectory = My.Computer.FileSystem.SpecialDirectories.MyDocuments
            'oCrear.InitialDirectory = "C:\Documents and Settings\Estudiante\Mis documentos"
            oCrear.Filter = "Archivo de texto (*.txt)|*.txt|Todos los archivos (*.*)|*.*" 'Colocar varias extensiones
            oCrear.FilterIndex = 1 'coloca por defecto el *.txt
            oCrear.ShowDialog() 'abre la caja de dialogo para guardar

            If Trim(oCrear.FileName) <> "" Then

                lblGPEXRUTA.Text = oCrear.FileName

                FileOpen(1, oCrear.FileName, OpenMode.Output) 'crea y destruye si hay otro igual
                '=======================================
                '*** EXPORTA LA INFORMACIÓN AL PLANO ***
                '=======================================

                Dim objdatos As New cla_TERCERO
                Dim tbl As New DataTable
                Dim NroReg As Integer
                Dim i As Integer

                tbl = objdatos.fun_Consultar_CAMPOS_TERCERO

                NroReg = tbl.Rows.Count

                For i = 0 To tbl.Rows.Count - 1

                    '================================
                    '*** DECLARACIÓN DE VARIABLES ***
                    '================================
                    Dim inTERCIDRE As String = "01"
                    Dim stTERCNUDO As String = tbl.Rows(i).Item(1)
                    Dim inTERCTIDO As String = tbl.Rows(i).Item(2)
                    Dim inTERCCAPR As String = tbl.Rows(i).Item(3)
                    Dim inTERCSEXO As String = tbl.Rows(i).Item(4)
                    Dim stTERCNOMB As String = tbl.Rows(i).Item(5)
                    Dim stTERCPRAP As String = tbl.Rows(i).Item(6)
                    Dim stTERCSEAP As String = tbl.Rows(i).Item(7)
                    Dim stTERCSICO As String = tbl.Rows(i).Item(8)
                    Dim stTERCTEL1 As String = tbl.Rows(i).Item(9)
                    Dim stTERCTEL2 As String = tbl.Rows(i).Item(10)
                    Dim stTERCFAX1 As String = tbl.Rows(i).Item(11)
                    Dim stTERCDIRE As String = tbl.Rows(i).Item(12)
                    Dim stTERCESTA As String = tbl.Rows(i).Item(13)

                    inTERCIDRE = inTERCIDRE.PadLeft(2, "0")
                    inTERCIDRE = inTERCIDRE.Substring(0, 2)

                    stTERCNUDO = stTERCNUDO.PadRight(14, " ")
                    stTERCNUDO = stTERCNUDO.Substring(0, 14)

                    inTERCTIDO = inTERCTIDO.PadLeft(1, "0")
                    inTERCTIDO = inTERCTIDO.Substring(0, 1)

                    inTERCCAPR = inTERCCAPR.PadLeft(2, "0")
                    inTERCCAPR = inTERCCAPR.Substring(0, 2)

                    inTERCSEXO = inTERCSEXO.PadLeft(1, "0")
                    inTERCSEXO = inTERCSEXO.Substring(0, 1)

                    stTERCNOMB = stTERCNOMB.PadRight(20, " ")
                    stTERCNOMB = stTERCNOMB.Substring(0, 20)

                    stTERCPRAP = stTERCPRAP.PadRight(15, " ")
                    stTERCPRAP = stTERCPRAP.Substring(0, 15)

                    stTERCSEAP = stTERCSEAP.PadRight(15, " ")
                    stTERCSEAP = stTERCSEAP.Substring(0, 15)

                    stTERCSICO = stTERCSICO.PadRight(20, " ")
                    stTERCSICO = stTERCSICO.Substring(0, 20)

                    stTERCTEL1 = stTERCTEL1.PadRight(15, " ")
                    stTERCTEL1 = stTERCTEL1.Substring(0, 15)

                    stTERCTEL2 = stTERCTEL2.PadRight(15, " ")
                    stTERCTEL2 = stTERCTEL2.Substring(0, 15)

                    stTERCFAX1 = stTERCFAX1.PadRight(15, " ")
                    stTERCFAX1 = stTERCFAX1.Substring(0, 15)

                    stTERCDIRE = stTERCDIRE.PadRight(49, " ")
                    stTERCDIRE = stTERCDIRE.Substring(0, 49)

                    stTERCESTA = stTERCESTA.PadRight(2, " ")
                    stTERCESTA = stTERCESTA.Substring(0, 2)

                    PrintLine(1, inTERCIDRE & Separador & _
                                 stTERCNUDO & Separador & _
                                 inTERCTIDO & Separador & _
                                 inTERCCAPR & Separador & _
                                 inTERCSEXO & Separador & _
                                 stTERCNOMB & Separador & _
                                 stTERCPRAP & Separador & _
                                 stTERCSEAP & Separador & _
                                 stTERCSICO & Separador & _
                                 stTERCTEL1 & Separador & _
                                 stTERCTEL2 & Separador & _
                                 stTERCFAX1 & Separador & _
                                 stTERCDIRE & Separador & _
                                 stTERCESTA)

                Next

                MessageBox.Show("Archivo creado exitosamente", "Archivo plano", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            End If

        Catch ex As Exception
            MsgBox(Err.Description)
        Finally
            FileClose(1)
        End Try


    End Sub

    Private Sub cboGPEXSEPA_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboGPEXSEPA.GotFocus
        strBARRESTA.Items(0).Text = cboGPEXSEPA.AccessibleDescription
    End Sub

    Private Sub cboGPEXSEPA_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboGPEXSEPA.SelectedIndexChanged
        Dim seleccion As String

        seleccion = cboGPEXSEPA.SelectedIndex

        Select Case seleccion
            Case 0
                Separador = ""
            Case 1
                Separador = "|"
            Case 2
                Separador = "-"
            Case 3
                Separador = "_"
            Case 4
                Separador = "/"
            Case 5
                Separador = " "

        End Select
    End Sub

#End Region

#Region "IMPORTAR PLANO"

    Private Sub cmdRUTA_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdRUTA.Click
        '================================
        '*** BUSCAR Y/O CREAR CARPETA ***
        '================================

        Dim oCarpetas As New FolderBrowserDialog
        Dim RUTA As String
        Dim ContentItem As String
        Dim NewPath As String

        oCarpetas.ShowDialog()
        RUTA = oCarpetas.SelectedPath
        txtGPIMRUTA.Text = RUTA

        NewPath = txtGPIMRUTA.Text

        Try
            '*** VERIFICA QUE LA RUTA ESTE CORRECTA ***
            ChDir(NewPath)

        Catch ex As Exception When NewPath = ""
            MessageBox.Show("Se debe introducir una ruta valida", "Mensaje ...", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
        End Try

        '===================================================
        '*** CARGA EL ListView CON LOS ARCHIVOS DE TEXTO ***
        '===================================================

        lstARCHIVO.Items.Clear()

        ContentItem = Dir("*.txt")

        If ContentItem = "" Then
            MessageBox.Show("No se encontro archivos textos", "Mensaje ...", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            cmdIMPOPLAN.Enabled = False

            'limpia los campos
            txtFechaAcceso.Text = ""
            txtTamano.Text = ""
            txtAtributos.Text = ""
        Else
            lstARCHIVO.Focus()
        End If

        Do Until ContentItem = ""
            '*** AGREGA A LA LISTA ***
            lstARCHIVO.Items.Add(ContentItem)
            '*** DESPLAZARSE AL SIGUIENTE REGISTRO ***
            ContentItem = Dir()
        Loop

    End Sub
    Private Sub lstARCHIVO_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lstARCHIVO.SelectedIndexChanged

        Try
            '=============================================
            '*** CARGA EL ARCHIVO TEXTO EN EL ListView ***
            '=============================================

            Dim Archivo_Plano As String

            With lstARCHIVO
                Archivo_Plano = .GetItemText(.SelectedItem) 'Archivo_Plano = lstARCHIVO.SelectedItem
            End With

            '*** PRENDE O APAGA EL BOTON IMPORTAR PLANO ***
            If Archivo_Plano = "" Then
                cmdIMPOPLAN.Enabled = False
            Else
                cmdIMPOPLAN.Enabled = True
            End If

            '============================================
            '*** CARGA EL ARCHIVO TEXTO EN EL TextBox ***
            '============================================

            Dim Attributes As FileAttribute
            Dim AttributeResult As String
            Dim LastAccess As Date
            Dim Length As Long

            thisFile = Archivo_Plano

            '*** COMPRUEBA QUE SE HALLA SELECCIONADO POR LO MENOS UN ARCHIVO ***
            If thisFile Is Nothing Then
                MessageBox.Show("No se ha seleccionado ningun archivo", "Mensaje...", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                cmdIMPOPLAN.Enabled = False
                Exit Sub
            End If

            '*** OPTIENE LOS ATRIBUTOS DEL ARCHIVO ***
            If chkATRIBUTOS.Checked = True Then
                Attributes = GetAttr(thisFile)

                If Attributes = FileAttribute.ReadOnly Then
                    AttributeResult = "ReadOnly"

                ElseIf Attributes = FileAttribute.Archive Then
                    AttributeResult = "Archive"

                ElseIf Attributes = 34 Then
                    AttributeResult = "ReadOnly y Archive"
                Else
                    AttributeResult = "Normal"
                End If
                txtAtributos.Text = AttributeResult
            Else
                txtAtributos.Text = ""
            End If

            '*** OPTIENE LA FECHA DE CREACIÓN DEL ARCHIVO ***
            If chkULTIMO_ACCESO.Checked = True Then
                LastAccess = FileDateTime(thisFile)
                txtFechaAcceso.Text = LastAccess

            ElseIf chkULTIMO_ACCESO.Checked = False Then
                txtFechaAcceso.Text = ""
            End If

            '*** OPTIENE EL TAMAÑO DEL ARCHIVO ***
            If chkTAMANO_ARCHIVO.Checked = True Then
                Length = FileLen(thisFile)
                txtTamano.Text = Length & " bytes"

            ElseIf chkTAMANO_ARCHIVO.Checked = False Then
                txtTamano.Text = ""
            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description & "Cargar el archivo plano")
        End Try

    End Sub
    Private Sub cmdIMPOPLAN_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdIMPOPLAN.Click

        Try
            '=======================================
            '*** GUARDO LA INFORMACIÓN DEL PLANO ***
            '=======================================

            If txtTamano.Text.Length > 0 Then

                ' apaga el boton
                cmdIMPOPLAN.Enabled = False

                ' variables
                Dim inContador As Integer = 0

                FileOpen(1, thisFile, OpenMode.Input)

                Dim ContenidoPlano As String

                Do Until EOF(1) 'repita hasta que se acabe las lineas

                    'ContenidoPlano = (InputString(1, 186))
                    ContenidoPlano = LineInput(1)

                    Dim inTERCIDRE As String = ContenidoPlano.Substring(0, 2)
                    Dim stTERCNUDO As String = ContenidoPlano.Substring(2, 14)
                    Dim inTERCTIDO As String = ContenidoPlano.Substring(16, 1)
                    Dim inTERCCAPR As String = ContenidoPlano.Substring(17, 2)
                    Dim inTERCSEXO As String = ContenidoPlano.Substring(19, 1)
                    Dim stTERCNOMB As String = ContenidoPlano.Substring(20, 20)
                    Dim stTERCPRAP As String = ContenidoPlano.Substring(40, 15)
                    Dim stTERCSEAP As String = ContenidoPlano.Substring(55, 15)
                    Dim stTERCSICO As String = ContenidoPlano.Substring(70, 20)
                    Dim stTERCTEL1 As String = ContenidoPlano.Substring(90, 15)
                    Dim stTERCTEL2 As String = ContenidoPlano.Substring(105, 15)
                    Dim stTERCFAX1 As String = ContenidoPlano.Substring(120, 15)
                    Dim stTERCDIRE As String = ContenidoPlano.Substring(135, 49)
                    Dim stTERCESTA As String = ContenidoPlano.Substring(184, 2)

                    ' instancia la clase tercero
                    Dim objdatos As New cla_TERCERO
                    Dim tbl As New DataTable

                    ' verifica si existe el tercero
                    tbl = objdatos.fun_Buscar_CODIGO_TERCERO(Trim(stTERCNUDO))

                    If tbl.Rows.Count = 0 Then

                        Dim objdatos1 As New cla_TERCERO

                        objdatos1.fun_Insertar_TERCERO(Trim(stTERCNUDO), _
                                                       Val(inTERCTIDO), _
                                                       Val(inTERCCAPR), _
                                                       Val(inTERCSEXO), _
                                                       stTERCNOMB, _
                                                       stTERCPRAP, _
                                                       stTERCSEAP, _
                                                       stTERCSICO, _
                                                       stTERCTEL1, _
                                                       stTERCTEL2, _
                                                       stTERCFAX1, _
                                                       stTERCDIRE, _
                                                       stTERCESTA, _
                                                       "")

                        inContador += 1

                    End If

                Loop

                MessageBox.Show("Archivo guardado correctamente" & Chr(Keys.Enter) & Chr(Keys.Enter) & "Se guardaron - " & inContador & " - tercero(s) en la base de datos", "Mensaje ...", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)

                ' prende el boton
                cmdIMPOPLAN.Enabled = True
            Else
                MessageBox.Show("Verifique que el archivo no este vacio", "Mensaje ...", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        Finally
            FileClose(1)
        End Try

    End Sub

#End Region

#Region "MENU"

    Private Sub cmdSALIR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSALIR.Click
        Me.Close()
    End Sub

#End Region

#Region "FORMULARIO"

#End Region

End Class