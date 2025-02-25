Imports REGLAS_DEL_NEGOCIO

Public Class frm_PROYECTO

    '================
    '*** PROYECTO ***
    '================

#Region "VARIABLES"

    Dim boCONSULTA As Boolean = False
    Dim vl_stRutaDocumentos As String = ""

#End Region

#Region "CONSULTA PARAMETRIZADA"

    Public Sub New(ByVal idCodigo As Integer)

        vp_inConsulta = idCodigo
        InitializeComponent()

    End Sub

#End Region

#Region "INSTANCIAR FORMULARIO"

    Private Shared frm_Instance = Nothing

    Public Shared Function instance() As frm_PROYECTO
        If frm_Instance Is Nothing OrElse frm_Instance.isdisposed = True Then
            frm_Instance = New frm_PROYECTO
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

    Private Sub pro_Reconsultar()

        Try
            Dim objdatos As New cla_PROYECTO

            If boCONSULTA = False Then
                Me.BindingSource_PROYECTO_1.DataSource = objdatos.fun_Consultar_PROYECTO
            Else
                Me.BindingSource_PROYECTO_1.DataSource = objdatos.fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_PROYECTO(vp_inConsulta)
            End If

            Me.dgvPROYECTO.DataSource = BindingSource_PROYECTO_1
            Me.BindingNavigator_PROYECTO_1.BindingSource = BindingSource_PROYECTO_1

            '================================================
            '*** CONFIGURA OBJETOS DEL FORMULARIO MAESTRO ***
            '================================================

            Me.strBARRESTA.Items(2).Text = "Registros : " & BindingSource_PROYECTO_1.Count

            Me.dgvPROYECTO.Columns("DEPADESC").HeaderText = "Departamento"
            Me.dgvPROYECTO.Columns("MUNIDESC").HeaderText = "Municipio"
            Me.dgvPROYECTO.Columns("CLSEDESC").HeaderText = "Clase o Sector"
            Me.dgvPROYECTO.Columns("PROYCODI").HeaderText = "Codigo"
            Me.dgvPROYECTO.Columns("PROYDESC").HeaderText = "Descripción"
            Me.dgvPROYECTO.Columns("ESTADESC").HeaderText = "Estado"

            Me.dgvPROYECTO.Columns("PROYIDRE").Visible = False
            Me.dgvPROYECTO.Columns("PROYDEPA").Visible = False
            Me.dgvPROYECTO.Columns("PROYMUNI").Visible = False
            Me.dgvPROYECTO.Columns("PROYCLSE").Visible = False
            Me.dgvPROYECTO.Columns("PROYESTA").Visible = False
            Me.dgvPROYECTO.Columns("PROYALCA").Visible = False
            Me.dgvPROYECTO.Columns("PROYRECU").Visible = False
            Me.dgvPROYECTO.Columns("PROYJUST").Visible = False
            Me.dgvPROYECTO.Columns("PROYOBJE").Visible = False
            Me.dgvPROYECTO.Columns("PROYFINA").Visible = False
            Me.dgvPROYECTO.Columns("PROYOBSE").Visible = False
            Me.dgvPROYECTO.Columns("PROYCONV").Visible = False
            Me.dgvPROYECTO.Columns("PROYCOMP").Visible = False
            Me.dgvPROYECTO.Columns("PROYNORM").Visible = False

            Me.dgvPROYECTO.Columns("DEPADESC").Width = 100
            Me.dgvPROYECTO.Columns("MUNIDESC").Width = 100
            Me.dgvPROYECTO.Columns("CLSEDESC").Width = 100
            Me.dgvPROYECTO.Columns("PROYCODI").Width = 100
            Me.dgvPROYECTO.Columns("PROYDESC").Width = 300
            Me.dgvPROYECTO.Columns("ESTADESC").Width = 100

            '==================================================
            '*** ASIGNA LOS PRIVILEGIOS DE LA BARRA DE MENU ***
            '==================================================

            Dim ContarRegistros As Integer = BindingSource_PROYECTO_1.Count

            Dim boCONTAGRE As Boolean = False
            Dim boCONTMODI As Boolean = False
            Dim boCONTELIM As Boolean = False
            Dim boCONTCONS As Boolean = False
            Dim boCONTRECO As Boolean = False

            pro_Permiso_Barra_De_Menu_Formulario_Formulario(ContarRegistros, Trim(Me.Name), boCONTAGRE, boCONTMODI, boCONTELIM, boCONTCONS, boCONTRECO)

            Me.cmdAGREGAR.Enabled = boCONTAGRE
            Me.cmdMODIFICAR.Enabled = boCONTMODI
            Me.cmdELIMINAR.Enabled = boCONTELIM
            Me.cmdCONSULTAR.Enabled = boCONTCONS
            Me.cmdRECONSULTAR.Enabled = boCONTRECO

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub pro_ListaDeValores()

        Try
            If Me.BindingSource_PROYECTO_1.Count > 0 Then

                Me.lblPROYDEPA.Text = CType(fun_Buscar_Lista_Valores_Formulario_Principal_DEPARTAMENTO_Codigo(Me.dgvPROYECTO.CurrentRow.Cells("PROYDEPA").Value.ToString()), String)
                Me.lblPROYMUNI.Text = CType(fun_Buscar_Lista_Valores_Formulario_Principal_MUNICIPIO_Codigo(Me.dgvPROYECTO.CurrentRow.Cells("PROYDEPA").Value.ToString(), Me.dgvPROYECTO.CurrentRow.Cells("PROYMUNI").Value.ToString()), String)
                Me.lblPROYCLSE.Text = CType(fun_Buscar_Lista_Valores_Formulario_Principal_CLASSECT_Codigo(Me.dgvPROYECTO.CurrentRow.Cells("PROYCLSE").Value.ToString()), String)

                Me.txtPROYALCA.Text = Me.dgvPROYECTO.CurrentRow.Cells("PROYALCA").Value.ToString()
                Me.txtPROYRECU.Text = Me.dgvPROYECTO.CurrentRow.Cells("PROYRECU").Value.ToString()
                Me.txtPROYJUST.Text = Me.dgvPROYECTO.CurrentRow.Cells("PROYJUST").Value.ToString()
                Me.txtPROYOBJE.Text = Me.dgvPROYECTO.CurrentRow.Cells("PROYOBJE").Value.ToString()
                Me.txtPROYFINA.Text = Me.dgvPROYECTO.CurrentRow.Cells("PROYFINA").Value.ToString()
                Me.txtPROYOBSE.Text = Me.dgvPROYECTO.CurrentRow.Cells("PROYOBSE").Value.ToString()
                Me.txtPROYCONV.Text = Me.dgvPROYECTO.CurrentRow.Cells("PROYCONV").Value.ToString()
                Me.txtPROYCOMP.Text = Me.dgvPROYECTO.CurrentRow.Cells("PROYCOMP").Value.ToString()
                Me.txtPROYNORM.Text = Me.dgvPROYECTO.CurrentRow.Cells("PROYNORM").Value.ToString()

                pro_ListadoArchivosDocumentosPDF()
            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub pro_LimpiarCampos()

        Me.lblPROYDEPA.Text = ""
        Me.lblPROYMUNI.Text = ""
        Me.lblPROYCLSE.Text = ""

        Me.txtPROYALCA.Text = ""
        Me.txtPROYRECU.Text = ""
        Me.txtPROYJUST.Text = ""
        Me.txtPROYOBJE.Text = ""
        Me.txtPROYFINA.Text = ""
        Me.txtPROYOBSE.Text = ""
        Me.txtPROYCONV.Text = ""
        Me.txtPROYCOMP.Text = ""
        Me.txtPROYNORM.Text = ""

    End Sub
    Private Sub pro_ListadoArchivosDocumentosPDF()

        Try
            Me.lstLISTADO_DOCUMENTOS_PDF.Items.Clear()

            ' declara la variable
            Dim stRuta As String = ""
            Dim stNewPath As String = ""
            Dim ContentItem As String

            ' instancia la clase
            Dim objRutas As New cla_RUTAS
            Dim tblRutas As New DataTable

            tblRutas = objRutas.fun_Buscar_CODIGO_MANT_RUTAS(9)

            If tblRutas.Rows.Count > 0 Then

                stNewPath = Trim(tblRutas.Rows(0).Item("RUTARUTA")) & "\" & Trim(Me.dgvPROYECTO.SelectedRows.Item(0).Cells("PROYDEPA").Value.ToString) & "-" & _
                                                                            Trim(Me.dgvPROYECTO.SelectedRows.Item(0).Cells("PROYMUNI").Value.ToString) & "-" & _
                                                                            Trim(Me.dgvPROYECTO.SelectedRows.Item(0).Cells("PROYCLSE").Value.ToString) & "-" & _
                                                                            Trim(Me.dgvPROYECTO.SelectedRows.Item(0).Cells("PROYCODI").Value.ToString)

                vl_stRutaDocumentos = stNewPath

                ChDir(stNewPath)

                Me.lstLISTADO_DOCUMENTOS_PDF.Items.Clear()

                ContentItem = Dir("*.pdf")

                If ContentItem <> "" Then
                    Me.lstLISTADO_DOCUMENTOS_PDF.Focus()
                End If

                Do Until ContentItem = ""
                    ' agrega a la lista
                    Me.lstLISTADO_DOCUMENTOS_PDF.Items.Add(ContentItem)

                    'desplaza el registro
                    ContentItem = Dir()
                Loop

            Else
                Me.lstLISTADO_DOCUMENTOS_PDF.Items.Clear()
            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub

#End Region

#Region "MENU"

    Private Sub cmdAGREGAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAGREGAR.Click

        Try
            frm_insertar_PROYECTO.ShowDialog()
            boCONSULTA = False
            pro_Reconsultar()
            pro_ListaDeValores()

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub cmdELIMINAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdELIMINAR.Click

        Try

            If MessageBox.Show("¿ Desea eliminar el registro seleccionado ? ", "Mensaje...", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then
                Dim objdatos As New cla_PROYECTO

                If objdatos.fun_Eliminar_PROYECTO(Integer.Parse(Me.dgvPROYECTO.SelectedRows.Item(0).Cells(0).Value.ToString())) Then
                    boCONSULTA = False
                    pro_Reconsultar()
                    pro_LimpiarCampos()
                    pro_ListaDeValores()
                Else
                    frm_INCO_eliminar_registro_padre_con_relación_de_registros_hijos.ShowDialog()
                End If

            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub cmdMODIFICAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdMODIFICAR.Click

        Try
            Dim frm_modificar_PROYECTO As New frm_modificar_PROYECTO(Integer.Parse(Me.dgvPROYECTO.SelectedRows.Item(0).Cells(0).Value.ToString()))

            frm_modificar_PROYECTO.ShowDialog()
            pro_Reconsultar()
            pro_ListaDeValores()

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub cmdCONSULTAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCONSULTAR.Click

        Try
            vp_inConsulta = 0

            frm_consultar_PROYECTO.ShowDialog()

            If vp_inConsulta > 0 Then
                boCONSULTA = True
            Else
                boCONSULTA = False
            End If

            pro_Reconsultar()
            pro_ListaDeValores()

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub cmdRECONSULTAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdRECONSULTAR.Click

        Try
            boCONSULTA = False
            pro_Reconsultar()
            pro_ListaDeValores()

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

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

    Private Sub frm_Mantenimiento_PROYECTO_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        pro_Reconsultar()
    End Sub

#End Region

#Region "GotFocus"

    Private Sub frm_ALUMPUBL_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.GotFocus
        pro_ListaDeValores()
    End Sub
    Private Sub dgvALUMPUBL_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvPROYECTO.GotFocus
        Me.strBARRESTA.Items(0).Text = dgvPROYECTO.AccessibleDescription
    End Sub

#End Region

#Region "KeyDown"

    Private Sub dgvCLSECLSE_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgvPROYECTO.KeyDown, dgvPROYECTO.KeyDown
        '===============================================================================================
        '*** INSERTAR REGISTROS ***
        '===============================================================================================


        If e.KeyCode = Keys.F2 Then
            If cmdAGREGAR.Enabled = True Then
                cmdAGREGAR.PerformClick()
            Else
                mod_MENSAJE.Usuario_No_Tiene_Permiso_Para_Realizar_La_Operacion()
            End If
        End If

        '===============================================================================================
        'MODIFICAR REGISTROS
        '===============================================================================================

        If e.KeyCode = Keys.F3 Then
            If cmdMODIFICAR.Enabled = True Then
                cmdMODIFICAR.PerformClick()
            Else
                Dim ContarRegistros As Integer = BindingSource_PROYECTO_1.Count

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
            If cmdELIMINAR.Enabled = True Then
                cmdELIMINAR.PerformClick()
            Else
                Dim ContarRegistros As Integer = BindingSource_PROYECTO_1.Count

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
            If cmdCONSULTAR.Enabled = True Then
                cmdCONSULTAR.PerformClick()
            Else
                mod_MENSAJE.No_Existen_Registros_En_Base_De_Datos()
            End If
        End If

        '===============================================================================================
        '*** RECONSULTAR REGISTROS ***
        '===============================================================================================

        If e.KeyCode = Keys.F8 Then
            If cmdCONSULTAR.Enabled = True Then
                cmdRECONSULTAR.PerformClick()
            Else
                mod_MENSAJE.No_Existen_Registros_En_Base_De_Datos()
            End If
        End If

    End Sub

#End Region

#Region "KeyUp"

    Private Sub dgvALUMPUBL_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgvPROYECTO.KeyUp
        If e.KeyCode = Keys.Down Or e.KeyCode = Keys.Up Or e.KeyCode = Keys.Enter Or e.KeyCode = Keys.PageUp Or e.KeyCode = Keys.PageDown Then
            pro_ListaDeValores()
        End If
    End Sub

#End Region

#Region "CellClick"

    Private Sub dgvALUMPUBL_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvPROYECTO.CellClick
        pro_ListaDeValores()
    End Sub

#End Region

#Region "DoubleClick"

    Private Sub lstLISTADO_DOCUMENTOS_PDF_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles lstLISTADO_DOCUMENTOS_PDF.DoubleClick

        Try
            If lstLISTADO_DOCUMENTOS_PDF.SelectedIndex <> -1 Then

                Dim stArchivo As String = lstLISTADO_DOCUMENTOS_PDF.SelectedItem
                Process.Start(vl_stRutaDocumentos & "\" & stArchivo)
            Else

                If lstLISTADO_DOCUMENTOS_PDF.Items.Count > 0 Then
                    MessageBox.Show("Seleccione un archivo de la lista", "mensaje...", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                End If

            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub

#End Region


#End Region

End Class