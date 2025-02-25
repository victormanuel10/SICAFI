Public NotInheritable Class frm_ACERCA_DE

#Region "INSTANCIAR FORMULARIO"

    Private Shared frm_Instance = Nothing

    Public Shared Function instance() As frm_ACERCA_DE
        If frm_Instance Is Nothing OrElse frm_Instance.isdisposed = True Then
            frm_Instance = New frm_ACERCA_DE
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

    Private Sub frm_ACERCA_DE_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        ' Establezca el título del formulario.
        Dim ApplicationTitle As String

        If My.Application.Info.Title <> "" Then
            ApplicationTitle = My.Application.Info.Title
        Else
            ApplicationTitle = System.IO.Path.GetFileNameWithoutExtension(My.Application.Info.AssemblyName)
        End If

        Me.Text = String.Format("Acerca de {0}", ApplicationTitle)
        ' Inicialice el texto mostrado en el cuadro Acerca de.
        ' TODO: Personalice la información del ensamblado de la aplicación en el panel "Aplicación" del 
        '    cuadro de diálogo propiedades del proyecto (bajo el menú "Proyecto").

        Me.LabelProductName.Text = My.Application.Info.ProductName
        Me.LabelVersion.Text = String.Format("Versión aplicativo: {0}", My.Application.Info.Version.ToString & " - " & "Versión actualización: " & vp_stVersionActualizacion)
        Me.LabelCopyright.Text = My.Application.Info.Copyright
        Me.LabelCompanyName.Text = My.Application.Info.CompanyName
        Me.TextBoxDescription.Text = My.Application.Info.Description

    End Sub
    Private Sub OKButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OKButton.Click
        Me.Close()
    End Sub

  
End Class
