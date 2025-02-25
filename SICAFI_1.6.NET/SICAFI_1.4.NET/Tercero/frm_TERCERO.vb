Imports REGLAS_DEL_NEGOCIO

Public Class frm_TERCERO

    '==========================
    '*** FORMULARIO TERCERO ***
    '==========================

#Region "CONSTRUCTORES"

    Public Sub New(ByVal id As Integer)
        vp_inConsulta = id
        InitializeComponent()
    End Sub

#End Region

#Region "VARIABLES"

    Dim boCONSULTA As Boolean = False

    Dim stNroDocumento As String
    Dim stRutaImagen As String

#End Region

#Region "INSTANCIAR FORMULARIO"

    Private Shared frm_Instance = Nothing

    Public Shared Function instance() As frm_TERCERO
        If frm_Instance Is Nothing OrElse frm_Instance.isdisposed = True Then
            frm_Instance = New frm_TERCERO
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

#Region "PROCEDIMIENTOS"

    Private Sub pro_inicializarControles()

        Dim objdatos7 As New cla_ESTADO

        Me.cboTERCESTA.DataSource = objdatos7.fun_Consultar_TODOS_LOS_ESTADOS
        Me.cboTERCESTA.DisplayMember = "ESTADESC"
        Me.cboTERCESTA.ValueMember = "ESTACODI"

    End Sub
    Private Sub pro_Reconsultar()

        Dim objdatos As New cla_TERCERO

        If boCONSULTA = False Then
            Me.BindingSource_TERCERO_1.DataSource = New DataTable

        ElseIf boCONSULTA = True Then
            Me.BindingSource_TERCERO_1.DataSource = objdatos.fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_TERCERO(vp_inConsulta)

            Me.dgvTERCERO.Columns(0).Visible = False
            Me.dgvTERCERO.Columns(1).Visible = False
            Me.dgvTERCERO.Columns(2).Visible = False
            Me.dgvTERCERO.Columns(3).Visible = False
            Me.dgvTERCERO.Columns(8).Visible = False

        End If

        Me.dgvTERCERO.DataSource = BindingSource_TERCERO_1
        Me.BindingNavigator_TERCERO_1.BindingSource = BindingSource_TERCERO_1

        '==================================================
        '*** CONFIGURA OBJETOS DEL FORMULARIO MAESTRO ***
        '==================================================

        Me.strBARRESTA.Items(2).Text = "Registros : " & BindingSource_TERCERO_1.Count

        '==================================================
        '*** ASIGNA LOS PRIVILEGIOS DE LA BARRA DE MENU ***
        '==================================================

        Dim ContarRegistros As Integer = BindingSource_TERCERO_1.Count

        Dim boCONTAGRE As Boolean = False
        Dim boCONTMODI As Boolean = False
        Dim boCONTELIM As Boolean = False
        Dim boCONTCONS As Boolean = False
        Dim boCONTRECO As Boolean = False

        pro_Permiso_Barra_De_Menu_Formulario_Formulario(ContarRegistros, Trim(Me.Name), boCONTAGRE, boCONTMODI, boCONTELIM, boCONTCONS, boCONTRECO)

        Me.cmdAGREGAR.Enabled = boCONTAGRE
        Me.cmdMODIFICAR.Enabled = boCONTMODI
        Me.cmdELIMINAR.Enabled = boCONTELIM

        ' declara por defecto en verdadero
        boCONTCONS = True
        boCONTRECO = True

        Me.cmdCONSULTAR.Enabled = boCONTCONS
        Me.cmdRECONSULTAR.Enabled = boCONTRECO

    End Sub
    Private Sub pro_ListaDeValores()
        '============================================================
        'Verifica si existen registros para traer la lista de valores
        '============================================================



        '=============================
        'Carga los datos en los campos
        '=============================
        Try
            If BindingSource_TERCERO_1.Count > 0 Then

                Dim objdatos As New cla_TERCERO
                Dim tbl As New DataTable

                tbl = objdatos.fun_Buscar_ID_TERCERO(Integer.Parse(Me.dgvTERCERO.SelectedRows(0).Cells(0).Value.ToString))

                Me.lblTERCIDRE.Text = Trim(tbl.Rows(0).Item(0))
                Me.txtTERCNUDO.Text = Trim(tbl.Rows(0).Item(1))
                Me.txtTERCTIDO.Text = Trim(tbl.Rows(0).Item(2))
                Me.txtTERCCAPR.Text = Trim(tbl.Rows(0).Item(3))
                Me.txtTERCSEXO.Text = Trim(tbl.Rows(0).Item(4))
                Me.txtTERCNOMB.Text = Trim(tbl.Rows(0).Item(5))
                Me.txtTERCPRAP.Text = Trim(tbl.Rows(0).Item(6))
                Me.txtTERCSEAP.Text = Trim(tbl.Rows(0).Item(7))
                Me.txtTERCSICO.Text = Trim(tbl.Rows(0).Item(8))
                Me.txtTERCTEL1.Text = Trim(tbl.Rows(0).Item(9))
                Me.txtTERCTEL2.Text = Trim(tbl.Rows(0).Item(10))
                Me.txtTERCFAX1.Text = Trim(tbl.Rows(0).Item(11))
                Me.txtTERCDIRE.Text = Trim(tbl.Rows(0).Item(12))
                Me.cboTERCESTA.SelectedValue = tbl.Rows(0).Item(13)
                Me.txtTERCUSIN.Text = Trim(tbl.Rows(0).Item(14))
                Me.txtTERCUSMO.Text = Trim(tbl.Rows(0).Item(15))
                Me.txtTERCFEIN.Text = Trim(tbl.Rows(0).Item(16))
                Me.txtTERCFEMO.Text = Trim(tbl.Rows(0).Item(17))
                Me.txtTERCOBSE.Text = Trim(tbl.Rows(0).Item(18))

                Me.lblTERCTIDO.Text = CType(fun_Buscar_Lista_Valores_TIPODOCU(Me.txtTERCTIDO.Text), String)
                Me.lblTERCCAPR.Text = CType(fun_Buscar_Lista_Valores_CALIPROP(Me.txtTERCCAPR.Text), String)
                Me.lblTERCSEXO.Text = CType(fun_Buscar_Lista_Valores_SEXO(Me.txtTERCSEXO.Text), String)

            End If

            If Trim(Me.txtTERCUSMO.Text) = "" Then
                Me.txtTERCFEMO.Text = ""
            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description & "2")
        End Try

    End Sub
    Private Sub pro_LimpiarCampos()

        txtTERCNUDO.Text = ""
        txtTERCTIDO.Text = ""
        lblTERCTIDO.Text = ""
        txtTERCCAPR.Text = ""
        lblTERCCAPR.Text = ""
        txtTERCSEXO.Text = ""
        lblTERCSEXO.Text = ""
        txtTERCNOMB.Text = ""
        txtTERCPRAP.Text = ""
        txtTERCSEAP.Text = ""
        txtTERCSICO.Text = ""
        txtTERCTEL1.Text = ""
        txtTERCTEL2.Text = ""
        txtTERCFAX1.Text = ""
        txtTERCDIRE.Text = ""
        cboTERCESTA.Text = ""
        txtTERCUSIN.Text = ""
        txtTERCUSMO.Text = ""
        txtTERCFEIN.Text = ""
        txtTERCFEMO.Text = ""
        txtTERCOBSE.Text = ""

    End Sub

#End Region

#Region "MENU"

    Private Sub cmdAGREGAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAGREGAR.Click

        frm_insertar_TERCERO.ShowDialog()

        boCONSULTA = True
        pro_Reconsultar()
        pro_ListaDeValores()

    End Sub
    Private Sub cmdELIMINAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdELIMINAR.Click

        Try
            If MessageBox.Show("¿ Desea eliminar el registro seleccionado ? ", "Mensaje ...", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then

                Dim objdatos As New cla_TERCERO

                If objdatos.fun_Eliminar_TERCERO(Integer.Parse(Me.dgvTERCERO.SelectedRows(0).Cells(0).Value.ToString)) = True Then
                    boCONSULTA = False
                    pro_Reconsultar()
                    pro_LimpiarCampos()
                    pro_ListaDeValores()
                Else
                    frm_INCO_eliminar_registro_padre_con_relación_de_registros_hijos.ShowDialog()
                End If

            End If

        Catch ex As Exception
            mod_MENSAJE.No_Existe_Un_Registro_Seleccionado()
        End Try
    End Sub
    Private Sub cmdMODIFICAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdMODIFICAR.Click
        Try
            Dim frm_modificar As New frm_modificar_TERCERO(Integer.Parse(Me.dgvTERCERO.SelectedRows(0).Cells(0).Value.ToString))

            frm_modificar.ShowDialog()
            pro_Reconsultar()
            pro_ListaDeValores()

        Catch ex As Exception
            mod_MENSAJE.No_Existe_Un_Registro_Seleccionado()
        End Try

    End Sub
    Private Sub cmdCONSULTAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCONSULTAR.Click
        Try
            ' llama al formulario consultar tercero
            frm_consultar_TERCERO.ShowDialog()

            ' verifica si se selecciono un tercero
            If vp_inConsulta > 0 Then
                boCONSULTA = True

                ' reconsulta las propiedades del tercero
                pro_Reconsultar()
                pro_ListaDeValores()
            Else
                boCONSULTA = False
            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub cmdCONSULTAR_PDF_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCONSULTAR_PDF.Click


        Try
            ' Consulta imagenes de ficha predial
            If Me.dgvTERCERO.RowCount = 0 Then
                MessageBox.Show("Favor seleccionar un documento", "Mensaje ...", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            Else

                ' instancia la clase
                Dim objdatos33 As New cla_RUTAS
                Dim tbl33 As New DataTable

                ' almacena la consulta
                tbl33 = objdatos33.fun_Buscar_CODIGO_MANT_RUTAS(3)

                ' verifica que exista registros
                If tbl33.Rows.Count > 0 Then

                    ' declara las variables
                    Dim stRutaDocumentoPredios1 As String = ""
                    Dim stRutaDocumentoPredios11 As String = ""

                    ' almacena la variable ruta
                    stRutaDocumentoPredios1 = Trim(tbl33.Rows(0).Item("RUTARUTA"))

                    If Trim(stRutaDocumentoPredios1) = "" Then
                        MessageBox.Show("Se debe introducir una ruta valida", "Mensaje ...", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                    Else
                        ' verifica la ruta
                        ChDir(stRutaDocumentoPredios1)

                        stRutaDocumentoPredios11 = stRutaDocumentoPredios1

                        ' consulta los archivos por extension
                        stRutaDocumentoPredios1 = Dir("*.pdf")

                        ' verifica que exista archivos
                        If stRutaDocumentoPredios1 <> "" Then

                            ' declara la variable
                            Dim bySW As Byte = 0

                            ' recorre la consulta
                            Do Until stRutaDocumentoPredios1 = ""

                                ' compara la seleccion
                                If (Trim(Me.txtTERCNUDO.Text) & ".pdf") = Trim(stRutaDocumentoPredios1.ToString) And bySW = 0 Then

                                    bySW = 1

                                End If

                                '*** DESPLAZARSE AL SIGUIENTE REGISTRO ***
                                stRutaDocumentoPredios1 = Dir()
                            Loop

                            ' encontro el archivo
                            If bySW = 1 Then
                                Process.Start(stRutaDocumentoPredios11 & "\" & (Trim(Me.txtTERCNUDO.Text) & ".pdf"))
                            Else
                                MessageBox.Show("No se encontro archivo", "Mensaje ...", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                            End If

                        End If
                    End If
                End If

            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub cmdRECONSULTAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdRECONSULTAR.Click
        pro_Reconsultar()
        pro_ListaDeValores()
    End Sub
    Private Sub cmdSALIR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSALIR.Click
        Me.Close()
    End Sub

    Private Sub BindingNavigatorMoveFirstItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BindingNavigatorMoveFirstItem.Click
        pro_ListaDeValores()
    End Sub
    Private Sub BindingNavigatorMovePreviousItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BindingNavigatorMovePreviousItem.Click
        pro_ListaDeValores()
    End Sub
    Private Sub BindingNavigatorMoveNextItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BindingNavigatorMoveNextItem.Click
        pro_ListaDeValores()
    End Sub
    Private Sub BindingNavigatorMoveLastItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BindingNavigatorMoveLastItem.Click
        pro_ListaDeValores()
    End Sub

#End Region

#Region "FORMULARIO"

#Region "Load"

    Private Sub frm_TERCERO_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        pro_inicializarControles()
        pro_Reconsultar()

    End Sub

#End Region

#Region "GotFocus"

    Private Sub frm_TERCERO_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.GotFocus
        pro_ListaDeValores()
    End Sub

#End Region

#Region "KeyDown"

    Private Sub dgvTERCERO_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgvTERCERO.KeyDown
        '===============================================================================================
        '*** INSERTAR REGISTROS ***
        '===============================================================================================

        If e.KeyCode = Keys.F2 Then
            If Me.cmdAGREGAR.Enabled = True Then
                Me.cmdAGREGAR.PerformClick()
            Else
                mod_MENSAJE.Usuario_No_Tiene_Permiso_Para_Realizar_La_Operacion()
            End If
        End If

        '===============================================================================================
        'MODIFICAR REGISTROS
        '===============================================================================================

        If e.KeyCode = Keys.F3 Then
            If Me.cmdMODIFICAR.Enabled = True Then
                Me.cmdMODIFICAR.PerformClick()
            Else
                Dim ContarRegistros As Integer = BindingSource_TERCERO_1.Count

                If ContarRegistros = 0 Then
                    mod_MENSAJE.No_Existen_Registros_En_Base_De_Datos()
                Else
                    mod_MENSAJE.Usuario_No_Tiene_Permiso_Para_Realizar_La_Operacion()
                End If

            End If
        End If

        '===============================================================================================
        '*** ELIMINAR REGISTROS ***
        '===============================================================================================

        If e.KeyCode = Keys.Delete Then
            If Me.cmdELIMINAR.Enabled = True Then
                Me.cmdELIMINAR.PerformClick()
            Else
                Dim ContarRegistros As Integer = BindingSource_TERCERO_1.Count

                If ContarRegistros = 0 Then
                    mod_MENSAJE.No_Existen_Registros_En_Base_De_Datos()
                Else
                    mod_MENSAJE.Usuario_No_Tiene_Permiso_Para_Realizar_La_Operacion()
                End If

            End If
        End If

        '===============================================================================================
        '*** CONSULTAR REGISTROS ***
        '===============================================================================================

        If e.KeyCode = Keys.F7 Then
            If Me.cmdCONSULTAR.Enabled = True Then
                Me.cmdCONSULTAR.PerformClick()
            Else
                mod_MENSAJE.No_Existen_Registros_En_Base_De_Datos()
            End If
        End If

        '===============================================================================================
        '*** RECONSULTAR REGISTROS ***
        '===============================================================================================

        If e.KeyCode = Keys.F8 Then
            If Me.cmdCONSULTAR.Enabled = True Then
                Me.cmdRECONSULTAR.PerformClick()
            Else
                mod_MENSAJE.No_Existen_Registros_En_Base_De_Datos()
            End If
        End If

    End Sub

#End Region

#Region "GotFocus"

    Private Sub dgvTERCERO_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvTERCERO.GotFocus
        Me.strBARRESTA.Items(0).Text = dgvTERCERO.AccessibleDescription
    End Sub

#End Region

#Region "KeyUp"

    Private Sub dgvTERCERO_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgvTERCERO.KeyUp
        If e.KeyCode = Keys.Down Or e.KeyCode = Keys.Up Or e.KeyCode = Keys.Enter Or e.KeyCode = Keys.PageUp Or e.KeyCode = Keys.PageDown Or e.KeyCode = Keys.PageUp Or e.KeyCode = Keys.PageDown Then
            pro_ListaDeValores()
        End If

    End Sub

#End Region

#Region "CellClick"

    Private Sub dgvTERCERO_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvTERCERO.CellClick
        pro_ListaDeValores()
    End Sub

#End Region

#End Region

  
End Class