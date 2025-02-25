Imports REGLAS_DEL_NEGOCIO

Public Class frm_RESOADMI

    '=================================
    '*** RESOLUCION ADMINISTRATIVA ***
    '=================================

#Region "VARIABLES"

    Dim boCONSULTA As Boolean = False

#End Region

#Region "INSTANCIAR FORMULARIO"

    Private Shared frm_Instance = Nothing

    Public Shared Function instance() As frm_RESOADMI
        If frm_Instance Is Nothing OrElse frm_Instance.isdisposed = True Then
            frm_Instance = New frm_RESOADMI
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

#Region "CONSTRUCTOR"

    Public Sub New(ByVal idCodigo As Integer)

        vp_inConsulta = idCodigo
        InitializeComponent()

    End Sub

#End Region

#Region "PROCEDIMIENTOS RESOLUCION ADMINISTRATIVA"

    Private Sub pro_ReconsultarResolucionAdministrativa()

        Try
            Dim objdatos As New cla_RESOADMI

            If boCONSULTA = False Then
                Me.BindingSource_RESOADMI_1.DataSource = objdatos.fun_Consultar_RESOADMI
            Else
                Me.BindingSource_RESOADMI_1.DataSource = objdatos.fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_RESOADMI(vp_inConsulta)
            End If

            Me.dgvRESOADMI.DataSource = BindingSource_RESOADMI_1
            Me.BindingNavigator_RESOADMI_1.BindingSource = BindingSource_RESOADMI_1

            '=================================================
            '*** CONFIGURA OBJETOS DEL FORMULARIO MAESTRO ***
            '=================================================

            Me.strBARRESTA.Items(2).Text = "Registros : " & Me.BindingSource_RESOADMI_1.Count

            Me.dgvRESOADMI.Columns("CLASDESC").HeaderText = "Clasificación"
            Me.dgvRESOADMI.Columns("READNURE").HeaderText = "Nro. Resolución"
            Me.dgvRESOADMI.Columns("READFERE").HeaderText = "Fecha de Resolución"
            Me.dgvRESOADMI.Columns("TIREDESC").HeaderText = "Tipo de Resolución"
            Me.dgvRESOADMI.Columns("CLSEDESC").HeaderText = "Sector"
            Me.dgvRESOADMI.Columns("READVIRE").HeaderText = "Vigencia Resolución"
            Me.dgvRESOADMI.Columns("ESTADESC").HeaderText = "Estado"

            Me.dgvRESOADMI.Columns("READIDRE").Visible = False
            Me.dgvRESOADMI.Columns("READCLAS").Visible = False
            Me.dgvRESOADMI.Columns("READTIRE").Visible = False
            Me.dgvRESOADMI.Columns("READCLSE").Visible = False

            Me.dgvRESOADMI.Columns("TIREDESC").Width = 180

            '==================================================
            '*** ASIGNA LOS PRIVILEGIOS DE LA BARRA DE MENU ***
            '==================================================

            Dim ContarRegistros As Integer = Me.BindingSource_RESOADMI_1.Count

            Dim boCONTAGRE As Boolean = False
            Dim boCONTMODI As Boolean = False
            Dim boCONTELIM As Boolean = False
            Dim boCONTCONS As Boolean = False
            Dim boCONTRECO As Boolean = False

            pro_Permiso_Barra_De_Menu_Formulario_SubFormulario(ContarRegistros, Trim(Me.BindingNavigator_RESOADMI_1.Name), boCONTAGRE, boCONTMODI, boCONTELIM, boCONTCONS, boCONTRECO)

            Me.cmdAGREGAR_RESOADMI.Enabled = boCONTAGRE
            Me.cmdMODIFICAR_RESOADMI.Enabled = boCONTMODI
            Me.cmdELIMINAR_RESOADMI.Enabled = boCONTELIM
            Me.cmdCONSULTAR_RESOADMI.Enabled = True
            Me.cmdRECONSULTAR_RESOADMI.Enabled = boCONTRECO

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub pro_ListaDeValoresResolucionAdministrativa()

        Try

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub pro_LimpiarCamposResolucionDeConservacion()

        Me.strBARRESTA.Items(2).Text = "Registros : 0"

    End Sub


#End Region

#Region "MENU RESOLUCION ADMINISTRATIVA"

    Private Sub cmdAGREGAR_RESOADMI_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAGREGAR_RESOADMI.Click

        Try
            If Me.dgvRESOADMI.RowCount > 0 Then
                Dim frm_insertar As New frm_insertar_RESOADMI(Integer.Parse(Me.dgvRESOADMI.SelectedRows.Item(0).Cells("READIDRE").Value.ToString()))
                frm_insertar.ShowDialog()
            Else
                frm_insertar_RESOADMI.ShowDialog()
            End If

            If vp_inConsulta > 0 Then
                boCONSULTA = True
            Else
                boCONSULTA = False
            End If

            pro_ReconsultarResolucionAdministrativa()
            pro_ListaDeValoresResolucionAdministrativa()

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub cmdMODIFICAR_RESOADMI_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdMODIFICAR_RESOADMI.Click

        Try
            Dim frm_modificar As New frm_modificar_RESOADMI(Integer.Parse(Me.dgvRESOADMI.SelectedRows.Item(0).Cells("READIDRE").Value.ToString()))
            frm_modificar.ShowDialog()

            If vp_inConsulta <> 0 Then
                boCONSULTA = True
            End If

            pro_ReconsultarResolucionAdministrativa()
            pro_ListaDeValoresResolucionAdministrativa()

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub cmdELIMINAR_RESOADMI_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdELIMINAR_RESOADMI.Click

        Try
            If MessageBox.Show("¿ Desea eliminar el registro seleccionado ? ", "Mensaje...", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then
                Dim objdatos As New cla_RESOADMI

                If objdatos.fun_Eliminar_IDRE_RESOADMI(Integer.Parse(Me.dgvRESOADMI.SelectedRows.Item(0).Cells("READIDRE").Value.ToString())) Then

                    boCONSULTA = False

                    pro_LimpiarCamposResolucionDeConservacion()
                    pro_ReconsultarResolucionAdministrativa()
                    pro_ListaDeValoresResolucionAdministrativa()
                Else
                    frm_INCO_eliminar_registro_padre_con_relación_de_registros_hijos.ShowDialog()
                End If

            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub cmdCONSULTAR_RESOADMI_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCONSULTAR_RESOADMI.Click

        Try
            vp_inConsulta = 0

            If Me.dgvRESOADMI.RowCount > 0 Then
                Dim frm_consultar As New frm_consultar_RESOADMI(Integer.Parse(Me.dgvRESOADMI.SelectedRows.Item(0).Cells("READIDRE").Value.ToString()))
                frm_consultar.ShowDialog()
            Else
                Dim frm_consultar As New frm_consultar_RESOADMI()
                frm_consultar.ShowDialog()
            End If

            If vp_inConsulta > 0 Then
                boCONSULTA = True
            Else
                boCONSULTA = False
            End If

            pro_ReconsultarResolucionAdministrativa()
            pro_ListaDeValoresResolucionAdministrativa()


        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub cmdRECONSULTAR_RESOADMI_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdRECONSULTAR_RESOADMI.Click

        Try
            boCONSULTA = False

            pro_ReconsultarResolucionAdministrativa()
            pro_ListaDeValoresResolucionAdministrativa()

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub cmdSALIR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSALIR.Click
        Me.Close()
    End Sub

#End Region

#Region "FORMULARIO"

#Region "Load"

    Private Sub frm_RESOCONS_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Me.Load

        pro_ReconsultarResolucionAdministrativa()
        Me.strBARRESTA.Items(0).Text = "Resolución Administrativa"

    End Sub

#End Region

#End Region
   
End Class