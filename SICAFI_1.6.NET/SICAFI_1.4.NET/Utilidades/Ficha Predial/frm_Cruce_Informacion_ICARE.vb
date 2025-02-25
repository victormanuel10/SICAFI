Imports REGLAS_DEL_NEGOCIO
Imports System
Imports System.IO
Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration
Imports System.Text

Public Class frm_Cruce_Informacion_ICARE

    '==========================================
    '*** FORMULARIO CRUCE INFORMACION ICARE ***
    '==========================================

#Region "INSTANCIAR FORMULARIO"

    Private Shared frm_Instance = Nothing

    Public Shared Function instance() As frm_Cruce_Informacion_ICARE
        If frm_Instance Is Nothing OrElse frm_Instance.isdisposed = True Then
            frm_Instance = New frm_Cruce_Informacion_ICARE
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

    Dim oLeer As New OpenFileDialog

    ' crea los objetos datatable
    Dim dt_CargaInformacionICARE As New DataTable
    Dim dt_CruzarMatriculasICAREvsBD As New DataTable
    Dim dt_CruzarCedulasICAREvsBD As New DataTable

    ' otros procesos
    Dim stRutaArchivoMunicipio As String
    Dim stRutaArchivoRegistro As String

    Dim inProceso As Integer = 0
    Dim inTotalRegistros As Integer = 0

#End Region

#Region "FUNCIONES"

    Private Function fun_ExtraerCirculoDeRegistro(ByVal stCirculo As String) As String

        Try
            Dim stCirculoDeRegistro As String = ""

            If Trim(stCirculo) <> "" Then

                Dim inLongitud As Integer = stCirculo.ToString.Length

                Dim sw1 As Byte = 0
                Dim j1 As Integer = 0

                While j1 < inLongitud And sw1 = 0
                    If fun_Verificar_Dato_Numerico_Evento_Validated(Trim(stCirculo).ToString.Substring(j1, 1)) = True Then
                        stCirculoDeRegistro += Trim(stCirculo).ToString.Substring(j1, 1)
                        j1 = j1 + 1
                    Else
                        sw1 = 1
                    End If
                End While

            End If

            Return stCirculoDeRegistro

        Catch ex As Exception
            Return ""
            MessageBox.Show(Err.Description)
        End Try

    End Function
    Private Function fun_ExtraerMatriculaInmobiliria(ByVal stMatricula As String) As String

        Try
            Dim stMatriculaInmobiliaria As String = ""

            If Trim(stMatricula) <> "" Then

                Dim inLongitud As Integer = stMatricula.ToString.Length

                Dim boGuion As Boolean = False
                Dim sw1 As Byte = 0
                Dim j1 As Integer = 0

                While j1 < inLongitud And sw1 = 0

                    If Trim(stMatricula).ToString.Substring(j1, 1) = "-" Then

                        boGuion = True

                        If fun_Verificar_Dato_Numerico_Evento_Validated(Trim(stMatricula).ToString.Substring(j1, 1)) = True Then
                            stMatriculaInmobiliaria += Trim(stMatricula).ToString.Substring(j1, 1)
                        End If

                        j1 = j1 + 1
                    Else
                        If boGuion = True Then

                            If fun_Verificar_Dato_Numerico_Evento_Validated(Trim(stMatricula).ToString.Substring(j1, 1)) = True Then
                                stMatriculaInmobiliaria += Trim(stMatricula).ToString.Substring(j1, 1)
                            End If

                        End If

                        j1 = j1 + 1

                    End If

                End While

            End If

            Return stMatriculaInmobiliaria

        Catch ex As Exception
            Return ""
            MessageBox.Show(Err.Description)
        End Try

    End Function
    Private Function fun_ConsultarMatriculaInmobiliariaBD(ByVal stDepartamento As String, ByVal stMunicipio As String, ByVal inSector As Integer) As DataTable

        Try
            ' instancia la clase
            Dim obFIPRPROP As New cla_FIPRPROP
            Dim dtFIPRPROP As New DataTable

            dtFIPRPROP = obFIPRPROP.fun_Consultar_PREDIOS_Y_MATRICULA_X_PROPIETARIOS(Trim(stDepartamento), Trim(stMunicipio), inSector)






        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Function
    Private Function fun_ConsultarMatriculaInmobiliariaICARE(ByVal stDepartamento As String, ByVal stMunicipio As String, ByVal inSector As Integer) As DataTable

        Try

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Function

#End Region

#Region "PROCEDIMIENTOS"

    Private Sub pro_GuardarInformacionICARE()

        Try
            ' instancia la clase
            Dim objVerifica As New cla_Verificar_Dato

            Dim boICARDEPA As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboRUPMDEPA)
            Dim boICARMUNI As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboRUPMMUNI)
            Dim boICARCLSE As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboRUPMCLSE)

            If boICARDEPA = True And _
               boICARMUNI = True And _
               boICARCLSE = True Then

                Dim stICARDEPA As String = CStr(Trim(Me.cboRUPMDEPA.SelectedValue))
                Dim stICARMUNI As String = CStr(Trim(Me.cboRUPMMUNI.SelectedValue))
                Dim inICARCLSE As Integer = CInt(Me.cboRUPMCLSE.SelectedValue)

                ' declaro la variable
                Dim dtINFORMACION As New DataTable

                ' llena las tabla
                dtINFORMACION = Me.dgvCargaInformacionICARE.DataSource

                ' verifica la tabla
                If dtINFORMACION.Rows.Count > 0 Then

                    ' instancia la clase
                    Dim obICARE As New cla_CruceInformacionICARE

                    ' elimina los registros
                    obICARE.fun_Eliminar_ICARE(stICARDEPA, stICARMUNI, inICARCLSE)

                    ' declaro la variable
                    Dim boGuardoRegistro As Boolean = False

                    ' estado del boton
                    Me.cmdGuardarInformacionICARE.Enabled = False

                    ' Valores predeterminados ProgressBar
                    inProceso = 0
                    Me.pbPROCESO.Value = 0
                    Me.pbPROCESO.Maximum = dtINFORMACION.Rows.Count + 1
                    Me.Timer1.Enabled = True

                    ' declaro la variable
                    Dim i As Integer = 0

                    For i = 0 To dtINFORMACION.Rows.Count - 1

                        ' declara las variables
                        Dim stICARCIRE As String = fun_ExtraerCirculoDeRegistro(Trim(dtINFORMACION.Rows(i).Item(0).ToString))
                        Dim stICARMAIN As String = fun_ExtraerMatriculaInmobiliria(Trim(dtINFORMACION.Rows(i).Item(0).ToString))
                        Dim stICARPROR As String = Trim(dtINFORMACION.Rows(i).Item(1).ToString)
                        Dim stICARTIPO As String = Trim(dtINFORMACION.Rows(i).Item(2).ToString)
                        Dim stICARDIIC As String = Trim(dtINFORMACION.Rows(i).Item(3).ToString)
                        Dim stICARPRIC As String = Trim(dtINFORMACION.Rows(i).Item(4).ToString)
                        Dim stICARESTA As String = Trim(dtINFORMACION.Rows(i).Item(5).ToString)

                        ' inserta el registro
                        If obICARE.fun_Insertar_ICARE(stICARDEPA, stICARMUNI, inICARCLSE, stICARCIRE, stICARMAIN, stICARPROR, stICARTIPO, stICARDIIC, stICARPRIC, stICARESTA) = True Then
                            boGuardoRegistro = True
                        End If

                        ' Incrementa la barra
                        inProceso = inProceso + 1
                        Me.pbPROCESO.Value = inProceso

                    Next

                    ' inicia la barra de progreso
                    Me.pbPROCESO.Value = 0

                    mod_MENSAJE.Se_Guardaron_Los_Datos_Correctamente()

                    ' estado de los botones
                    If boGuardoRegistro = True Then
                        Me.cmdCruzarCedulasICAREvsBD.Enabled = True
                        Me.cmdCruzarMatriculasICAREvsBD.Enabled = True

                    ElseIf boGuardoRegistro = False Then
                        Me.cmdCruzarCedulasICAREvsBD.Enabled = False
                        Me.cmdCruzarMatriculasICAREvsBD.Enabled = False

                    End If

                End If

            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub pro_CruzarMatriculasICAREvsBD()

        Try
            ' comando de boton
            Me.cmdCruzarMatriculasICAREvsBD.Enabled = False

            ' instancia la clase
            Dim objVerifica As New cla_Verificar_Dato

            Dim boICARDEPA As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboRUPMDEPA)
            Dim boICARMUNI As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboRUPMMUNI)
            Dim boICARCLSE As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboRUPMCLSE)

            If boICARDEPA = True And _
               boICARMUNI = True And _
               boICARCLSE = True Then

                ' limpio la datagrig
                Me.dgvCruzarMatriculasICAREvsBD.DataSource = New DataTable

                ' instancia la clase
                Dim obICARE As New cla_CruceInformacionICARE
                Dim dtICARE As New DataTable

                dtICARE = obICARE.fun_Consultar_ICARE_X_DEPA_Y_MUNI(Me.cboRUPMDEPA.SelectedValue, Me.cboRUPMMUNI.SelectedValue)

                ' instancia la clase
                Dim obFIPRPROP As New cla_FIPRPROP
                Dim dtFIPRPROP As New DataTable

                dtFIPRPROP = obFIPRPROP.fun_Consultar_PREDIOS_Y_MATRICULA_X_PROPIETARIOS(Me.cboRUPMDEPA.SelectedValue, Me.cboRUPMMUNI.SelectedValue, Me.cboRUPMCLSE.SelectedValue)

                ' verifica que existan registros
                If dtICARE.Rows.Count > 0 AndAlso dtFIPRPROP.Rows.Count > 0 Then

                    ' Crea objeto registros
                    Dim dr1 As DataRow

                    ' crea la tabla
                    dt_CruzarMatriculasICAREvsBD = New DataTable

                    ' Crea las columnas
                    dt_CruzarMatriculasICAREvsBD.Columns.Add(New DataColumn("Departamento_Icare", GetType(String)))
                    dt_CruzarMatriculasICAREvsBD.Columns.Add(New DataColumn("Municipio_Icare", GetType(String)))
                    dt_CruzarMatriculasICAREvsBD.Columns.Add(New DataColumn("Sector_Icare", GetType(String)))
                    dt_CruzarMatriculasICAREvsBD.Columns.Add(New DataColumn("Circulo_Icare", GetType(String)))
                    dt_CruzarMatriculasICAREvsBD.Columns.Add(New DataColumn("Matricula_Icare", GetType(String)))
                    dt_CruzarMatriculasICAREvsBD.Columns.Add(New DataColumn("Propietario_Original", GetType(String)))
                    dt_CruzarMatriculasICAREvsBD.Columns.Add(New DataColumn("Tipo", GetType(String)))
                    dt_CruzarMatriculasICAREvsBD.Columns.Add(New DataColumn("Direccion_Icare", GetType(String)))
                    'dt_CruzarMatriculasICAREvsBD.Columns.Add(New DataColumn("Propietario_Icare", GetType(String)))
                    dt_CruzarMatriculasICAREvsBD.Columns.Add(New DataColumn("Estado_Icare", GetType(String)))
                    dt_CruzarMatriculasICAREvsBD.Columns.Add(New DataColumn("Nro_Ficha", GetType(String)))
                    dt_CruzarMatriculasICAREvsBD.Columns.Add(New DataColumn("Municipio", GetType(String)))
                    dt_CruzarMatriculasICAREvsBD.Columns.Add(New DataColumn("Corregimiento", GetType(String)))
                    dt_CruzarMatriculasICAREvsBD.Columns.Add(New DataColumn("Barrio", GetType(String)))
                    dt_CruzarMatriculasICAREvsBD.Columns.Add(New DataColumn("Manzana", GetType(String)))
                    dt_CruzarMatriculasICAREvsBD.Columns.Add(New DataColumn("Predio", GetType(String)))
                    dt_CruzarMatriculasICAREvsBD.Columns.Add(New DataColumn("Edificio", GetType(String)))
                    dt_CruzarMatriculasICAREvsBD.Columns.Add(New DataColumn("Unidad", GetType(String)))
                    dt_CruzarMatriculasICAREvsBD.Columns.Add(New DataColumn("Direccion", GetType(String)))
                    dt_CruzarMatriculasICAREvsBD.Columns.Add(New DataColumn("Circulo_Matricula", GetType(String)))
                    dt_CruzarMatriculasICAREvsBD.Columns.Add(New DataColumn("Descripcion", GetType(String)))

                    ' Valores predeterminados ProgressBar
                    inProceso = 0
                    pbPROCESO.Value = 0
                    pbPROCESO.Maximum = dtICARE.Rows.Count + 1
                    Timer1.Enabled = True

                    ' declaración de variables
                    Dim stCIRCULO As String = ""
                    Dim stMATRICULA As String = ""
                    Dim stCIRCULO_MATRICULA As String = ""

                    Dim i As Integer = 0

                    ' Recorro la tabla del municipio
                    For i = 0 To dtICARE.Rows.Count - 1

                        ' limpias las varaibles
                        stCIRCULO = ""
                        stMATRICULA = ""

                        ' carga la variable
                        stCIRCULO = fun_Formato_Mascara_3_String(Trim(dtICARE.Rows(i).Item("ICARCIRE")))
                        stMATRICULA = fun_Formato_Mascara_7_String(Trim(dtICARE.Rows(i).Item("ICARMAIN")))

                        ' carga la matricula con estructura
                        stCIRCULO_MATRICULA = stCIRCULO & "-" & stMATRICULA

                        Dim sw1 As Byte = 0
                        Dim j1 As Integer = 0
                        Dim bySW As Byte = 0

                        ' recorre los propietarios bd
                        While j1 < dtFIPRPROP.Rows.Count And sw1 = 0

                            If CStr(Trim(stCIRCULO_MATRICULA)) = CStr(Trim(dtFIPRPROP.Rows(j1).Item("FPPRMAIN"))) Then
                                bySW = 1
                                sw1 = 1
                            Else
                                j1 = j1 + 1
                            End If

                        End While

                        ' encuentra la matricula
                        If bySW = 1 Then

                            dr1 = dt_CruzarMatriculasICAREvsBD.NewRow()

                            dr1("Departamento_Icare") = Trim(dtICARE.Rows(i).Item("ICARDEPA").ToString)
                            dr1("Municipio_Icare") = Trim(dtICARE.Rows(i).Item("ICARMUNI").ToString)
                            dr1("Sector_Icare") = Trim(dtICARE.Rows(i).Item("ICARCLSE").ToString)
                            dr1("Circulo_Icare") = Trim(dtICARE.Rows(i).Item("ICARCIRE").ToString)
                            dr1("Matricula_Icare") = Trim(dtICARE.Rows(i).Item("ICARMAIN").ToString)
                            dr1("Propietario_Original") = Trim(dtICARE.Rows(i).Item("ICARPROR").ToString) & " _"
                            dr1("Tipo") = Trim(dtICARE.Rows(i).Item("ICARTIPO").ToString)
                            dr1("Direccion_Icare") = Trim(dtICARE.Rows(i).Item("ICARDIIC").ToString)
                            'dr1("Propietario_Icare") = Trim(dtICARE.Rows(i).Item("ICARPRIC").ToString)
                            dr1("Estado_Icare") = Trim(dtICARE.Rows(i).Item("ICARESTA").ToString)
                            dr1("Nro_Ficha") = Trim(dtFIPRPROP.Rows(j1).Item("FIPRNUFI"))
                            dr1("Municipio") = Trim(dtFIPRPROP.Rows(j1).Item("FIPRMUNI"))
                            dr1("Corregimiento") = Trim(dtFIPRPROP.Rows(j1).Item("FIPRCORR"))
                            dr1("Barrio") = Trim(dtFIPRPROP.Rows(j1).Item("FIPRBARR"))
                            dr1("Manzana") = Trim(dtFIPRPROP.Rows(j1).Item("FIPRMANZ"))
                            dr1("Predio") = Trim(dtFIPRPROP.Rows(j1).Item("FIPRPRED"))
                            dr1("Edificio") = Trim(dtFIPRPROP.Rows(j1).Item("FIPREDIF"))
                            dr1("Unidad") = Trim(dtFIPRPROP.Rows(j1).Item("FIPRUNPR"))
                            dr1("Direccion") = Trim(dtFIPRPROP.Rows(j1).Item("FIPRDIRE"))
                            dr1("Circulo_Matricula") = Trim(dtFIPRPROP.Rows(j1).Item("FPPRMAIN"))
                            dr1("Descripcion") = Trim("Matricula SI cruzada")

                            dt_CruzarMatriculasICAREvsBD.Rows.Add(dr1)

                        Else

                            dr1 = dt_CruzarMatriculasICAREvsBD.NewRow()

                            dr1("Departamento_Icare") = Trim(dtICARE.Rows(i).Item("ICARDEPA").ToString)
                            dr1("Municipio_Icare") = Trim(dtICARE.Rows(i).Item("ICARMUNI").ToString)
                            dr1("Sector_Icare") = Trim(dtICARE.Rows(i).Item("ICARCLSE").ToString)
                            dr1("Circulo_Icare") = Trim(dtICARE.Rows(i).Item("ICARCIRE").ToString)
                            dr1("Matricula_Icare") = Trim(dtICARE.Rows(i).Item("ICARMAIN").ToString)
                            dr1("Propietario_Original") = Trim(dtICARE.Rows(i).Item("ICARPROR").ToString) & " _"
                            dr1("Tipo") = Trim(dtICARE.Rows(i).Item("ICARTIPO").ToString)
                            dr1("Direccion_Icare") = Trim(dtICARE.Rows(i).Item("ICARDIIC").ToString)
                            'dr1("Propietario_Icare") = Trim(dtICARE.Rows(i).Item("ICARPRIC").ToString)
                            dr1("Estado_Icare") = Trim(dtICARE.Rows(i).Item("ICARESTA").ToString)
                            dr1("Nro_Ficha") = ""
                            dr1("Municipio") = ""
                            dr1("Corregimiento") = ""
                            dr1("Barrio") = ""
                            dr1("Manzana") = ""
                            dr1("Predio") = ""
                            dr1("Edificio") = ""
                            dr1("Unidad") = ""
                            dr1("Direccion") = ""
                            dr1("Circulo_Matricula") = Trim(stCIRCULO_MATRICULA)
                            dr1("Descripcion") = Trim("Matricula NO cruzada")

                            dt_CruzarMatriculasICAREvsBD.Rows.Add(dr1)

                        End If

                        ' Incrementa la barra
                        inProceso = inProceso + 1
                        Me.pbPROCESO.Value = inProceso

                    Next

                    ' inicia la barra de progreso
                    Me.pbPROCESO.Value = 0

                    ' verifica el resultado
                    If dt_CruzarMatriculasICAREvsBD.Rows.Count > 0 Then

                        MessageBox.Show("Cruce con resultados", "Mensaje ...", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                        Me.dgvCruzarMatriculasICAREvsBD.DataSource = dt_CruzarMatriculasICAREvsBD

                    Else
                        MessageBox.Show("Cruce sin resultados", "Mensaje ...", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                        Me.dgvCruzarMatriculasICAREvsBD.DataSource = New DataTable

                    End If

                    ' comando de boton
                    Me.cmdCruzarMatriculasICAREvsBD.Enabled = True

                Else
                    MessageBox.Show("Consulta sin resultados", "Mensaje ...", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                    Me.cmdCruzarMatriculasICAREvsBD.Enabled = True
                End If

            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub pro_CruzarCedulasICAREvsBD()

        Try

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub pro_AbrirArchivoRegistro()

        Try
            Me.dgvCargaInformacionICARE.DataSource = New DataTable

            ' selecciona archivo de excel
            If Me.rbdArchivoRegistroExcel.Checked = True Then

                ' declara variable
                inTotalRegistros = 0

                ' enruta el archivo
                oLeer.InitialDirectory = "C:\Documents and Settings\Estudiante\Mis documentos"
                oLeer.Filter = "Archivo de texto (*.xls)|*.xls" 'Colocar varias extensiones
                oLeer.FilterIndex = 1 'coloca por defecto el *.txt
                oLeer.FileName = ""
                oLeer.ShowDialog()

                stRutaArchivoRegistro = Trim(oLeer.FileName)

                Dim MyConnection As System.Data.OleDb.OleDbConnection
                Dim DtSet As System.Data.DataSet
                Dim MyCommand As System.Data.OleDb.OleDbDataAdapter

                MyConnection = New System.Data.OleDb.OleDbConnection("provider=Microsoft.Jet.OLEDB.4.0; Data Source='" & stRutaArchivoRegistro & "'; Extended Properties=Excel 8.0;")

                Dim stNombreLibro As String = InputBox("Ingrese el nombre de la hoja de excel", "Mensaje")

                If Trim(stNombreLibro) <> "" Then

                    MyCommand = New System.Data.OleDb.OleDbDataAdapter("select * from [" & stNombreLibro & "$]", MyConnection)

                    MyCommand.TableMappings.Add("Table", "TestTable")
                    DtSet = New System.Data.DataSet
                    MyCommand.Fill(DtSet)

                    Me.dgvCargaInformacionICARE.DataSource = DtSet.Tables(0)

                    Me.lblRutaInformacion.Text = Trim(oLeer.FileName)

                    inTotalRegistros = Me.dgvCargaInformacionICARE.RowCount

                    Me.lblCantidadRegistros.Text = inTotalRegistros

                    Me.strBARRESTA.Items(2).Text = "Registros : " & Me.dgvCargaInformacionICARE.RowCount

                    MyConnection.Close()

                Else
                    Me.lblCantidadRegistros.Text = "0"
                End If

                ' selecciona el archivo de access
            ElseIf Me.rbdArchivoMunicipioAccess.Checked = True Then

                ' declara variable
                inTotalRegistros = 0

                ' enruta el archivo
                oLeer.InitialDirectory = "C:\Documents and Settings\Estudiante\Mis documentos"
                oLeer.Filter = "Archivo de texto (*.mdb)|*.mdb" 'Colocar varias extensiones
                oLeer.FilterIndex = 1 'coloca por defecto el *.txt
                oLeer.FileName = ""
                oLeer.ShowDialog()

                stRutaArchivoRegistro = Trim(oLeer.FileName)

                Dim MyConnection As System.Data.OleDb.OleDbConnection
                Dim DtSet As System.Data.DataSet
                Dim MyCommand As System.Data.OleDb.OleDbDataAdapter

                MyConnection = New System.Data.OleDb.OleDbConnection("provider=Microsoft.Jet.OLEDB.4.0; Data Source='" & stRutaArchivoMunicipio & "'")

                Dim stNombreLibro As String = InputBox("Ingrese el nombre de la tabla de access", "Mensaje")

                If Trim(stNombreLibro) <> "" Then

                    MyCommand = New System.Data.OleDb.OleDbDataAdapter("select * from [" & stNombreLibro & "]", MyConnection)

                    MyCommand.TableMappings.Add("Table", "TestTable")
                    DtSet = New System.Data.DataSet
                    MyCommand.Fill(DtSet)

                   Me.dgvCargaInformacionICARE.DataSource = DtSet.Tables(0)

                    Me.lblRutaInformacion.Text = Trim(oLeer.FileName)

                    inTotalRegistros = Me.dgvCargaInformacionICARE.RowCount

                    Me.lblCantidadRegistros.Text = inTotalRegistros

                    Me.strBARRESTA.Items(2).Text = "Registros : " & Me.dgvCargaInformacionICARE.RowCount

                    MyConnection.Close()

                Else
                    Me.lblCantidadRegistros.Text = "0"
                End If

            End If

            ' opcion de boton guardar
            If inTotalRegistros > 0 Then
                Me.cmdGuardarInformacionICARE.Enabled = True
            Else
                Me.cmdGuardarInformacionICARE.Enabled = False
            End If

        Catch ex As Exception
            Me.lblRutaInformacion.Text = ""
            Me.lblCantidadRegistros.Text = "0"
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub pro_LimpiarCampos()

        Me.cboRUPMDEPA.DataSource = New DataTable
        Me.cboRUPMMUNI.DataSource = New DataTable
        Me.cboRUPMMUNI.DataSource = New DataTable

        Me.lblRutaInformacion.Text = ""
        Me.lblCantidadRegistros.Text = ""

        Me.strBARRESTA.Items(0).Text = "Cruce ICARE"
        Me.strBARRESTA.Items(2).Text = "Registros: 0"

        Me.cmdGuardarInformacionICARE.Enabled = False
        Me.cmdCruzarMatriculasICAREvsBD.Enabled = False
        Me.cmdCruzarCedulasICAREvsBD.Enabled = False

    End Sub

#End Region

#Region "MENU"

    Private Sub cmdGuardarInformacionICARE_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGuardarInformacionICARE.Click
        pro_GuardarInformacionICARE()
    End Sub
    Private Sub cmdCruzarMatriculasICAREvsBD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCruzarMatriculasICAREvsBD.Click
        pro_CruzarMatriculasICAREvsBD()
    End Sub
    Private Sub cmdCruzarCedulasICAREvsBD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCruzarCedulasICAREvsBD.Click
        pro_CruzarCedulasICAREvsBD()
    End Sub
    Private Sub cmdAbrirArchivoMunicipio_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAbrirArchivoMunicipio.Click
        pro_AbrirArchivoRegistro()
    End Sub
    Private Sub cmdExportarExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExportarExcel.Click

        Try
            If Me.rbdCargaInformaciónICARE.Checked = True Then

                If Me.dgvCargaInformacionICARE.RowCount = 0 Then
                    MessageBox.Show("No existe datos para exportar", "Mensaje ...", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1)
                Else
                    Dim oExp As New cla_ExportarTablaExcel
                    oExp.DataTableToExcel(CType(Me.dgvCargaInformacionICARE.DataSource, DataTable))
                End If

            ElseIf Me.rbdCruzanMatriculasICAREvsMatriculasBD.Checked = True Then

                If Me.dgvCruzarMatriculasICAREvsBD.RowCount = 0 Then
                    MessageBox.Show("No existe datos para exportar", "Mensaje ...", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1)
                Else
                    Dim oExp As New cla_ExportarTablaExcel
                    oExp.DataTableToExcel(CType(Me.dgvCruzarMatriculasICAREvsBD.DataSource, DataTable))
                End If

            ElseIf Me.rbdCruzanCedulasICAREvsCedulasBD.Checked = True Then

                If Me.dgvCruzarCedulasICAREvsBD.RowCount = 0 Then
                    MessageBox.Show("No existe datos para exportar", "Mensaje ...", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1)
                Else
                    Dim oExp As New cla_ExportarTablaExcel
                    oExp.DataTableToExcel(CType(Me.dgvCruzarCedulasICAREvsBD.DataSource, DataTable))
                End If

            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub

#End Region

#Region "FORMULARIO"

#Region "Load"

    Private Sub frm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        pro_LimpiarCampos()
    End Sub

#End Region

#Region "GotFocus"

    Private Sub cmd_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdSALIR.GotFocus
        pp_pro_DescripcionCampo(Me.strBARRESTA.Items(0), sender)
    End Sub
    Private Sub cbo_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboRUPMDEPA.GotFocus, cboRUPMMUNI.GotFocus, cboRUPMCLSE.GotFocus
        pp_pro_DescripcionCampo(Me.strBARRESTA.Items(0), sender)
    End Sub

#End Region

#Region "SelectedIndexChanged"

    Private Sub cboOBINDEPA_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboRUPMDEPA.SelectedIndexChanged
        Me.cboRUPMMUNI.DataSource = New DataTable
    End Sub

#End Region

#Region "Click"

    Private Sub cboOBINNODE_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboRUPMDEPA.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_DEPARTAMENTO_Descripcion(Me.cboRUPMDEPA, Me.cboRUPMDEPA.SelectedIndex)
    End Sub
    Private Sub cboOBINMUNI_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboRUPMMUNI.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_MUNICIPIO_X_DEPARTAMENTO_Descripcion(Me.cboRUPMMUNI, Me.cboRUPMMUNI.SelectedIndex, Me.cboRUPMDEPA)
    End Sub
    Private Sub cboOBINCLSE_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboRUPMCLSE.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_CLASSECT_Descripcion(Me.cboRUPMCLSE, Me.cboRUPMCLSE.SelectedIndex)
    End Sub

#End Region

#End Region

End Class