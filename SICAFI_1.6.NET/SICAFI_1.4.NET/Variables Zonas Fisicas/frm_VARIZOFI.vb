Imports REGLAS_DEL_NEGOCIO

Public Class frm_VARIZOFI

    '============================
    '*** VARIABLE ZONA FISICA ***
    '============================

#Region "VARIABLES"

    Dim boCONSULTA As Boolean = False

#End Region

#Region "CONSTRUCTOR"

    Public Sub New(ByVal idCodigo As Integer)

        vp_inConsulta = idCodigo
        InitializeComponent()

    End Sub

#End Region

#Region "INSTANCIAR FORMULARIO"

    Private Shared frm_Instance = Nothing

    Public Shared Function instance() As frm_VARIZOFI
        If frm_Instance Is Nothing OrElse frm_Instance.isdisposed = True Then
            frm_Instance = New frm_VARIZOFI
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

            Dim objdatos As New cla_VARIZOFI

            If boCONSULTA = False Then
                Me.BindingSource_VARIZOFI_1.DataSource = objdatos.fun_Consultar_MANT_VARIZOFI
            Else
                Me.BindingSource_VARIZOFI_1.DataSource = objdatos.fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_MANT_VARIZOFI(vp_inConsulta)
            End If

            Me.dgvVARIZOFI_1.DataSource = BindingSource_VARIZOFI_1
            Me.dgvVARIZOFI_2.DataSource = BindingSource_VARIZOFI_1
            Me.BindingNavigator_VARIZOFI_1.BindingSource = BindingSource_VARIZOFI_1

            '================================================
            '*** CONFIGURA OBJETOS DEL FORMULARIO MAESTRO ***
            '================================================

            Me.strBARRESTA.Items(2).Text = "Registros : " & Me.BindingSource_VARIZOFI_1.Count

            Me.dgvVARIZOFI_1.Columns("DEPADESC").HeaderText = "Departamento"
            Me.dgvVARIZOFI_1.Columns("MUNIDESC").HeaderText = "Municipio"
            Me.dgvVARIZOFI_1.Columns("CLSEDESC").HeaderText = "Sector"
            Me.dgvVARIZOFI_1.Columns("ZOFIDESC").HeaderText = "Zona física (2013)"
            Me.dgvVARIZOFI_1.Columns("VAZFZOFI").HeaderText = "Código zona física (2013)"
            Me.dgvVARIZOFI_1.Columns("ZFACDESC").HeaderText = "Descripción zona física"
            Me.dgvVARIZOFI_1.Columns("VAZFZFAC").HeaderText = "Código zona física"
            Me.dgvVARIZOFI_1.Columns("ZOECDESC").HeaderText = "Zona económica (2013)"
            Me.dgvVARIZOFI_1.Columns("VAZFZOEC").HeaderText = "Código zona econó. (2013)"
            Me.dgvVARIZOFI_1.Columns("ZEACDESC").HeaderText = "Descripción zona económica"
            Me.dgvVARIZOFI_1.Columns("VAZFZEAC").HeaderText = "Código zona económica"
            Me.dgvVARIZOFI_1.Columns("ZEACVACO").HeaderText = "Valor m2 Comercial"
            Me.dgvVARIZOFI_1.Columns("ZEACVACA").HeaderText = "Valor m2 Catastral (60%)"

            Me.dgvVARIZOFI_2.Columns("CLSUDESC").HeaderText = "Clase de suelo"
            Me.dgvVARIZOFI_2.Columns("ARACDESC").HeaderText = "Areas de actividad"
            Me.dgvVARIZOFI_2.Columns("TRURDESC").HeaderText = "Tratamientos urbanisticos"
            Me.dgvVARIZOFI_2.Columns("DESTDESC").HeaderText = "Destinación"
            Me.dgvVARIZOFI_2.Columns("SEDEDESC").HeaderText = "Tipo segun destino"
            Me.dgvVARIZOFI_2.Columns("SERVDESC").HeaderText = "Servicios"
            Me.dgvVARIZOFI_2.Columns("VIASDESC").HeaderText = "Vias"
            Me.dgvVARIZOFI_2.Columns("TOPODESC").HeaderText = "Topografia"
            Me.dgvVARIZOFI_2.Columns("AGUADESC").HeaderText = "Aguas"
            Me.dgvVARIZOFI_2.Columns("AHTDESC").HeaderText = "A. H. T."
            Me.dgvVARIZOFI_2.Columns("ESTADESC").HeaderText = "Estado"

            If Me.chkCruceZonas.Checked = False Then

                Me.dgvVARIZOFI_1.Columns("ZOFIDESC").Visible = False
                Me.dgvVARIZOFI_1.Columns("VAZFZOFI").Visible = False
                Me.dgvVARIZOFI_1.Columns("ZOECDESC").Visible = False
                Me.dgvVARIZOFI_1.Columns("VAZFZOEC").Visible = False
                Me.dgvVARIZOFI_1.Columns("ZEACDESC").Visible = False

            ElseIf Me.chkCruceZonas.Checked = True Then

                Me.dgvVARIZOFI_1.Columns("ZOFIDESC").Visible = True
                Me.dgvVARIZOFI_1.Columns("VAZFZOFI").Visible = True
                Me.dgvVARIZOFI_1.Columns("ZOECDESC").Visible = False
                Me.dgvVARIZOFI_1.Columns("VAZFZOEC").Visible = True
                Me.dgvVARIZOFI_1.Columns("ZEACDESC").Visible = False

            End If

            Me.dgvVARIZOFI_1.Columns("TRURDESC").Visible = False
            Me.dgvVARIZOFI_1.Columns("DESTDESC").Visible = False
            Me.dgvVARIZOFI_1.Columns("SEDEDESC").Visible = False
            Me.dgvVARIZOFI_1.Columns("SERVDESC").Visible = False
            Me.dgvVARIZOFI_1.Columns("VIASDESC").Visible = False
            Me.dgvVARIZOFI_1.Columns("TOPODESC").Visible = False
            Me.dgvVARIZOFI_1.Columns("AGUADESC").Visible = False
            Me.dgvVARIZOFI_1.Columns("AHTDESC").Visible = False
            Me.dgvVARIZOFI_1.Columns("ESTADESC").Visible = False

            Me.dgvVARIZOFI_2.Columns("DEPADESC").Visible = False
            Me.dgvVARIZOFI_2.Columns("MUNIDESC").Visible = False
            Me.dgvVARIZOFI_2.Columns("CLSEDESC").Visible = False
            Me.dgvVARIZOFI_2.Columns("ZOFIDESC").Visible = False
            Me.dgvVARIZOFI_1.Columns("CLSUDESC").Visible = False
            Me.dgvVARIZOFI_1.Columns("ARACDESC").Visible = False
          
            Me.dgvVARIZOFI_2.Columns("ZFACDESC").Visible = False
            Me.dgvVARIZOFI_2.Columns("VAZFZFAC").Visible = False
            Me.dgvVARIZOFI_2.Columns("VAZFZEAC").Visible = False
            Me.dgvVARIZOFI_2.Columns("ZOECDESC").Visible = False
            Me.dgvVARIZOFI_2.Columns("ZEACDESC").Visible = False
            Me.dgvVARIZOFI_2.Columns("VAZFZOEC").Visible = False
            Me.dgvVARIZOFI_2.Columns("ZEACVACO").Visible = False
            Me.dgvVARIZOFI_2.Columns("ZEACVACA").Visible = False

            Me.dgvVARIZOFI_1.Columns("VAZFIDRE").Visible = False
            Me.dgvVARIZOFI_1.Columns("VAZFDEPA").Visible = False
            Me.dgvVARIZOFI_1.Columns("VAZFMUNI").Visible = False
            Me.dgvVARIZOFI_1.Columns("VAZFCLSE").Visible = False
            Me.dgvVARIZOFI_1.Columns("VAZFCLSU").Visible = False
            Me.dgvVARIZOFI_1.Columns("VAZFARAC").Visible = False
            Me.dgvVARIZOFI_1.Columns("VAZFTRUR").Visible = False
            Me.dgvVARIZOFI_1.Columns("VAZFDEST").Visible = False
            Me.dgvVARIZOFI_1.Columns("VAZFSEDE").Visible = False
            Me.dgvVARIZOFI_1.Columns("VAZFSERV").Visible = False
            Me.dgvVARIZOFI_1.Columns("VAZFVIAS").Visible = False
            Me.dgvVARIZOFI_1.Columns("VAZFTOPO").Visible = False
            Me.dgvVARIZOFI_1.Columns("VAZFAGUA").Visible = False
            Me.dgvVARIZOFI_1.Columns("VAZFAHT").Visible = False
            Me.dgvVARIZOFI_1.Columns("VAZFESTA").Visible = False

            Me.dgvVARIZOFI_1.Columns("VAZFVA01").Visible = False
            Me.dgvVARIZOFI_1.Columns("VAZFVA02").Visible = False
            Me.dgvVARIZOFI_1.Columns("VAZFVA03").Visible = False
            Me.dgvVARIZOFI_1.Columns("VAZFVA04").Visible = False
            Me.dgvVARIZOFI_1.Columns("VAZFVA05").Visible = False
            Me.dgvVARIZOFI_1.Columns("VAZFVA06").Visible = False
            Me.dgvVARIZOFI_1.Columns("VAZFVA07").Visible = False
            Me.dgvVARIZOFI_1.Columns("VAZFVA08").Visible = False
            Me.dgvVARIZOFI_1.Columns("VAZFVA09").Visible = False
            Me.dgvVARIZOFI_1.Columns("VAZFVA10").Visible = False
            Me.dgvVARIZOFI_1.Columns("VAZFVACO").Visible = False
            Me.dgvVARIZOFI_1.Columns("VAZFVACA").Visible = False
            Me.dgvVARIZOFI_1.Columns("VAZFPOBL").Visible = False

            Me.dgvVARIZOFI_2.Columns("VAZFIDRE").Visible = False
            Me.dgvVARIZOFI_2.Columns("VAZFDEPA").Visible = False
            Me.dgvVARIZOFI_2.Columns("VAZFMUNI").Visible = False
            Me.dgvVARIZOFI_2.Columns("VAZFCLSE").Visible = False
            Me.dgvVARIZOFI_2.Columns("VAZFZOFI").Visible = False
            Me.dgvVARIZOFI_2.Columns("VAZFCLSU").Visible = False
            Me.dgvVARIZOFI_2.Columns("VAZFARAC").Visible = False
            Me.dgvVARIZOFI_2.Columns("VAZFTRUR").Visible = False
            Me.dgvVARIZOFI_2.Columns("VAZFDEST").Visible = False
            Me.dgvVARIZOFI_2.Columns("VAZFSEDE").Visible = False
            Me.dgvVARIZOFI_2.Columns("VAZFSERV").Visible = False
            Me.dgvVARIZOFI_2.Columns("VAZFVIAS").Visible = False
            Me.dgvVARIZOFI_2.Columns("VAZFTOPO").Visible = False
            Me.dgvVARIZOFI_2.Columns("VAZFAGUA").Visible = False
            Me.dgvVARIZOFI_2.Columns("VAZFAHT").Visible = False
            Me.dgvVARIZOFI_2.Columns("VAZFESTA").Visible = False

            Me.dgvVARIZOFI_2.Columns("VAZFVA01").Visible = False
            Me.dgvVARIZOFI_2.Columns("VAZFVA02").Visible = False
            Me.dgvVARIZOFI_2.Columns("VAZFVA03").Visible = False
            Me.dgvVARIZOFI_2.Columns("VAZFVA04").Visible = False
            Me.dgvVARIZOFI_2.Columns("VAZFVA05").Visible = False
            Me.dgvVARIZOFI_2.Columns("VAZFVA06").Visible = False
            Me.dgvVARIZOFI_2.Columns("VAZFVA07").Visible = False
            Me.dgvVARIZOFI_2.Columns("VAZFVA08").Visible = False
            Me.dgvVARIZOFI_2.Columns("VAZFVA09").Visible = False
            Me.dgvVARIZOFI_2.Columns("VAZFVA10").Visible = False
            Me.dgvVARIZOFI_2.Columns("VAZFVACO").Visible = False
            Me.dgvVARIZOFI_2.Columns("VAZFVACA").Visible = False
            Me.dgvVARIZOFI_2.Columns("VAZFPOBL").Visible = False

            Me.dgvVARIZOFI_1.Columns("DEPADESC").Width = 100
            Me.dgvVARIZOFI_1.Columns("MUNIDESC").Width = 100
            Me.dgvVARIZOFI_1.Columns("CLSEDESC").Width = 100
            Me.dgvVARIZOFI_1.Columns("VAZFZOFI").Width = 100
            Me.dgvVARIZOFI_1.Columns("ZOFIDESC").Width = 200
            Me.dgvVARIZOFI_1.Columns("VAZFZFAC").Width = 100
            Me.dgvVARIZOFI_1.Columns("VAZFZEAC").Width = 100
            Me.dgvVARIZOFI_1.Columns("ZFACDESC").Width = 300
            Me.dgvVARIZOFI_1.Columns("ZEACDESC").Width = 200
            Me.dgvVARIZOFI_1.Columns("VAZFZOEC").Width = 100
            Me.dgvVARIZOFI_1.Columns("ZOECDESC").Width = 200

            Me.dgvVARIZOFI_2.Columns("CLSUDESC").Width = 200
            Me.dgvVARIZOFI_2.Columns("ARACDESC").Width = 200
            Me.dgvVARIZOFI_2.Columns("TRURDESC").Width = 100
            Me.dgvVARIZOFI_2.Columns("DESTDESC").Width = 100
            Me.dgvVARIZOFI_2.Columns("SEDEDESC").Width = 200
            Me.dgvVARIZOFI_2.Columns("SERVDESC").Width = 200
            Me.dgvVARIZOFI_2.Columns("VIASDESC").Width = 100
            Me.dgvVARIZOFI_2.Columns("TOPODESC").Width = 100
            Me.dgvVARIZOFI_2.Columns("AGUADESC").Width = 100
            Me.dgvVARIZOFI_2.Columns("AHTDESC").Width = 100
            Me.dgvVARIZOFI_2.Columns("ESTADESC").Width = 100

            Me.dgvVARIZOFI_1.Columns("ZEACVACO").DefaultCellStyle.Format = "c"
            Me.dgvVARIZOFI_1.Columns("ZEACVACA").DefaultCellStyle.Format = "c"

            Me.dgvVARIZOFI_1.Columns("ZEACVACO").DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopRight
            Me.dgvVARIZOFI_1.Columns("ZEACVACA").DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopRight

            '==================================================
            '*** ASIGNA LOS PRIVILEGIOS DE LA BARRA DE MENU ***
            '==================================================

            Dim ContarRegistros As Integer = Me.BindingSource_VARIZOFI_1.Count

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
            If Me.BindingSource_VARIZOFI_1.Count > 0 Then

                Me.lblVAZFDEPA.Text = CType(fun_Buscar_Lista_Valores_Formulario_Principal_DEPARTAMENTO_Codigo(Me.dgvVARIZOFI_1.CurrentRow.Cells("VAZFDEPA").Value.ToString()), String)
                Me.lblVAZFMUNI.Text = CType(fun_Buscar_Lista_Valores_Formulario_Principal_MUNICIPIO_Codigo(Me.dgvVARIZOFI_1.CurrentRow.Cells("VAZFDEPA").Value.ToString(), Me.dgvVARIZOFI_1.CurrentRow.Cells("VAZFMUNI").Value.ToString()), String)
                Me.lblVAZFCLSE.Text = CType(fun_Buscar_Lista_Valores_Formulario_Principal_CLASSECT_Codigo(Me.dgvVARIZOFI_1.CurrentRow.Cells("VAZFCLSE").Value.ToString()), String)
                Me.lblVAZFZOFI.Text = CType(fun_Buscar_Lista_Valores_Formulario_Principal_VARIZOFI_Codigo(Me.dgvVARIZOFI_1.CurrentRow.Cells("VAZFDEPA").Value.ToString(), Me.dgvVARIZOFI_1.CurrentRow.Cells("VAZFMUNI").Value.ToString(), Me.dgvVARIZOFI_1.CurrentRow.Cells("VAZFCLSE").Value.ToString(), Me.dgvVARIZOFI_1.CurrentRow.Cells("VAZFZOFI").Value.ToString()), String)
                Me.lblVAZFCLSU.Text = CType(fun_Buscar_Lista_Valores_Formulario_Principal_CLASSUEL_Codigo(Me.dgvVARIZOFI_1.CurrentRow.Cells("VAZFCLSU").Value.ToString()), String)
                Me.lblVAZFARAC.Text = CType(fun_Buscar_Lista_Valores_Formulario_Principal_AREAACTI_Codigo(Me.dgvVARIZOFI_1.CurrentRow.Cells("VAZFARAC").Value.ToString()), String)
                Me.lblVAZFTRUR.Text = CType(fun_Buscar_Lista_Valores_Formulario_Principal_TRATURBA_Codigo(Me.dgvVARIZOFI_1.CurrentRow.Cells("VAZFTRUR").Value.ToString()), String)
                Me.lblVAZFDEST.Text = CType(fun_Buscar_Lista_Valores_Formulario_Principal_DESTINACION_Codigo(Me.dgvVARIZOFI_1.CurrentRow.Cells("VAZFDEST").Value.ToString()), String)
                Me.lblVAZFSEDE.Text = CType(fun_Buscar_Lista_Valores_Formulario_Principal_SEGUDEST_Codigo(Me.dgvVARIZOFI_1.CurrentRow.Cells("VAZFDEST").Value.ToString(), Me.dgvVARIZOFI_1.CurrentRow.Cells("VAZFSEDE").Value.ToString()), String)
                Me.lblVAZFSERV.Text = CType(fun_Buscar_Lista_Valores_Formulario_Principal_SERVICIOS_Codigo(Me.dgvVARIZOFI_1.CurrentRow.Cells("VAZFSERV").Value.ToString()), String)
                Me.lblVAZFVIAS.Text = CType(fun_Buscar_Lista_Valores_Formulario_Principal_VIAS_Codigo(Me.dgvVARIZOFI_1.CurrentRow.Cells("VAZFVIAS").Value.ToString()), String)
                Me.lblVAZFTOPO.Text = CType(fun_Buscar_Lista_Valores_Formulario_Principal_TOPOGRAFIA_Codigo(Me.dgvVARIZOFI_1.CurrentRow.Cells("VAZFTOPO").Value.ToString()), String)
              
                Me.txtVAZFVA01.Text = Me.dgvVARIZOFI_1.CurrentRow.Cells("VAZFVA01").Value.ToString()
                Me.txtVAZFVA02.Text = Me.dgvVARIZOFI_1.CurrentRow.Cells("VAZFVA02").Value.ToString()
                Me.txtVAZFVA03.Text = Me.dgvVARIZOFI_1.CurrentRow.Cells("VAZFVA03").Value.ToString()
                Me.txtVAZFVA04.Text = Me.dgvVARIZOFI_1.CurrentRow.Cells("VAZFVA04").Value.ToString()
                Me.txtVAZFVA05.Text = Me.dgvVARIZOFI_1.CurrentRow.Cells("VAZFVA05").Value.ToString()
                Me.txtVAZFVA06.Text = Me.dgvVARIZOFI_1.CurrentRow.Cells("VAZFVA06").Value.ToString()
                Me.txtVAZFVA07.Text = Me.dgvVARIZOFI_1.CurrentRow.Cells("VAZFVA07").Value.ToString()
                Me.txtVAZFVA08.Text = Me.dgvVARIZOFI_1.CurrentRow.Cells("VAZFVA08").Value.ToString()
                Me.txtVAZFVA09.Text = Me.dgvVARIZOFI_1.CurrentRow.Cells("VAZFVA09").Value.ToString()
                Me.txtVAZFVA10.Text = Me.dgvVARIZOFI_1.CurrentRow.Cells("VAZFVA10").Value.ToString()
                Me.txtVAZFVACO.Text = Me.dgvVARIZOFI_1.CurrentRow.Cells("VAZFVACO").Value.ToString()
                Me.txtVAZFVACA.Text = Me.dgvVARIZOFI_1.CurrentRow.Cells("VAZFVACA").Value.ToString()

                Me.txtVAZFVACO.Text = fun_Formato_Mascara_Pesos_Enteros(Me.txtVAZFVACO.Text)
                Me.txtVAZFVACA.Text = fun_Formato_Mascara_Pesos_Enteros(Me.txtVAZFVACA.Text)
                Me.txtVAZFVA01.Text = fun_Formato_Mascara_Pesos_Enteros(Me.txtVAZFVA01.Text)
                Me.txtVAZFVA02.Text = fun_Formato_Mascara_Pesos_Enteros(Me.txtVAZFVA02.Text)
                Me.txtVAZFVA03.Text = fun_Formato_Mascara_Pesos_Enteros(Me.txtVAZFVA03.Text)
                Me.txtVAZFVA04.Text = fun_Formato_Mascara_Pesos_Enteros(Me.txtVAZFVA04.Text)
                Me.txtVAZFVA05.Text = fun_Formato_Mascara_Pesos_Enteros(Me.txtVAZFVA05.Text)
                Me.txtVAZFVA06.Text = fun_Formato_Mascara_Pesos_Enteros(Me.txtVAZFVA06.Text)
                Me.txtVAZFVA07.Text = fun_Formato_Mascara_Pesos_Enteros(Me.txtVAZFVA07.Text)
                Me.txtVAZFVA08.Text = fun_Formato_Mascara_Pesos_Enteros(Me.txtVAZFVA08.Text)
                Me.txtVAZFVA09.Text = fun_Formato_Mascara_Pesos_Enteros(Me.txtVAZFVA09.Text)
                Me.txtVAZFVA10.Text = fun_Formato_Mascara_Pesos_Enteros(Me.txtVAZFVA10.Text)

            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub pro_LimpiarCampos()

        Me.lblVAZFDEPA.Text = ""
        Me.lblVAZFMUNI.Text = ""
        Me.lblVAZFCLSE.Text = ""
        Me.lblVAZFZOFI.Text = ""
        Me.lblVAZFCLSU.Text = ""
        Me.lblVAZFARAC.Text = ""
        Me.lblVAZFTRUR.Text = ""
        Me.lblVAZFDEST.Text = ""
        Me.lblVAZFSEDE.Text = ""
        Me.lblVAZFSERV.Text = ""
        Me.lblVAZFVIAS.Text = ""
        Me.lblVAZFTOPO.Text = ""

        Me.txtVAZFVA01.Text = ""
        Me.txtVAZFVA02.Text = ""
        Me.txtVAZFVA03.Text = ""
        Me.txtVAZFVA04.Text = ""
        Me.txtVAZFVA05.Text = ""
        Me.txtVAZFVA06.Text = ""
        Me.txtVAZFVA07.Text = ""
        Me.txtVAZFVA08.Text = ""
        Me.txtVAZFVA09.Text = ""
        Me.txtVAZFVA10.Text = ""
        Me.txtVAZFVACO.Text = ""
        Me.txtVAZFVACA.Text = ""

    End Sub

#End Region

#Region "MENU"

    Private Sub cmdAGREGAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAGREGAR.Click

        Try
            frm_insertar_VARIZOFI.ShowDialog()
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
                Dim objdatos As New cla_VARIZOFI

                If objdatos.fun_Eliminar_MANT_VARIZOFI(Integer.Parse(Me.dgvVARIZOFI_1.SelectedRows.Item(0).Cells(0).Value.ToString())) Then
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
            Dim frm_modificar As New frm_modificar_VARIZOFI(Integer.Parse(Me.dgvVARIZOFI_1.SelectedRows.Item(0).Cells(0).Value.ToString()))

            frm_modificar.ShowDialog()
            pro_Reconsultar()
            pro_ListaDeValores()

        Catch ex As Exception
            frm_INCO_modifircar_registros_sin_listas_de_valores.ShowDialog()
        End Try

    End Sub
    Private Sub cmdCONSULTAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCONSULTAR.Click

        Try
            'vp_inConsulta = 0

            'frm_consultar_VARIZOFI.ShowDialog()

            'If vp_inConsulta > 0 Then
            '    boCONSULTA = True
            'Else
            '    boCONSULTA = False
            'End If

            'pro_Reconsultar()
            'pro_ListaDeValores()

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub cmdRECONSULTAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdRECONSULTAR.Click
        boCONSULTA = False
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

    Private Sub frm_ALUMPUBL_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        pro_Reconsultar()
    End Sub

#End Region

#Region "GotFocus"

    Private Sub frm_ALUMPUBL_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.GotFocus
        pro_ListaDeValores()
    End Sub
    Private Sub dgvALUMPUBL_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvVARIZOFI_1.GotFocus, dgvVARIZOFI_2.GotFocus
        Me.strBARRESTA.Items(0).Text = dgvVARIZOFI_1.AccessibleDescription
    End Sub

#End Region

#Region "KeyDown"

    Private Sub dgvALUMPUBL_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgvVARIZOFI_1.KeyDown, dgvVARIZOFI_2.KeyDown
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
                Dim ContarRegistros As Integer = BindingSource_VARIZOFI_1.Count

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
                Dim ContarRegistros As Integer = BindingSource_VARIZOFI_1.Count

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

    Private Sub dgvALUMPUBL_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgvVARIZOFI_1.KeyUp, dgvVARIZOFI_2.KeyUp
        If e.KeyCode = Keys.Down Or e.KeyCode = Keys.Up Or e.KeyCode = Keys.Enter Or e.KeyCode = Keys.PageUp Or e.KeyCode = Keys.PageDown Then
            pro_ListaDeValores()
        End If
    End Sub

#End Region

#Region "CellClick"

    Private Sub dgvALUMPUBL_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvVARIZOFI_1.CellClick, dgvVARIZOFI_2.CellClick
        pro_ListaDeValores()
    End Sub

#End Region

#End Region

End Class