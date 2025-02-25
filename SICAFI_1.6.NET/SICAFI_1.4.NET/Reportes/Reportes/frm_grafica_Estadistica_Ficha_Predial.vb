Imports Graphing.V3

Public Class frm_grafica_Estadistica_Ficha_Predial

    '===========================
    '*** GRAFICO ESTADISTICO ***
    '===========================

#Region "VARIABLES"

    Dim lWidth As Integer = 0
    Dim lHeight As Integer = 0

    Dim dt_Consulta As New DataTable
    Dim vl_stLeyenda As String = ""

#End Region

#Region "CONSTRUCTOR"

    Public Sub New(ByVal dtTable As DataTable)

        dt_Consulta = dtTable
        InitializeComponent()

    End Sub
    Public Sub New(ByVal dtTable As DataTable, ByVal stLeyenda As String)

        Try
            dt_Consulta = dtTable
            vl_stLeyenda = stLeyenda
            InitializeComponent()

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try
      

    End Sub

#End Region

#Region "PROCEDIMIENTO"

    Private Sub pro_Grafica()

        Try

            Dim inNroColumnas As Integer = dt_Consulta.Rows.Count
            Dim inNroFilas As Integer = dt_Consulta.Columns.Count

            Me.AxMSChart2.RowCount = inNroColumnas
            Me.AxMSChart2.ColumnCount = 1

            Me.AxMSChart3.RowCount = inNroColumnas
            Me.AxMSChart3.ColumnCount = 1

            Me.AxMSChart4.RowCount = inNroColumnas
            Me.AxMSChart4.ColumnCount = 1

            Me.AxMSChart5.RowCount = inNroColumnas
            Me.AxMSChart5.ColumnCount = 1

            Me.AxMSChart6.RowCount = inNroColumnas
            Me.AxMSChart6.ColumnCount = 1

            Me.AxMSChart7.RowCount = inNroColumnas
            Me.AxMSChart7.ColumnCount = 1

            Me.AxMSChart8.RowCount = inNroColumnas
            Me.AxMSChart8.ColumnCount = 1

            Me.AxMSChart9.RowCount = inNroColumnas
            Me.AxMSChart9.ColumnCount = 1

            Dim i As Integer = 0

            For i = 1 To Me.dt_Consulta.Rows.Count

                Me.AxMSChart2.Row = i
                Me.AxMSChart3.Row = i
                Me.AxMSChart4.Row = i
                Me.AxMSChart5.Row = i
                Me.AxMSChart6.Row = i
                Me.AxMSChart7.Row = i
                Me.AxMSChart8.Row = i
                Me.AxMSChart9.Row = i

                Me.AxMSChart2.ColumnLabel = Trim(vl_stLeyenda)
                Me.AxMSChart3.ColumnLabel = Trim(vl_stLeyenda)
                Me.AxMSChart4.ColumnLabel = Trim(vl_stLeyenda)
                Me.AxMSChart5.ColumnLabel = Trim(vl_stLeyenda)
                Me.AxMSChart6.ColumnLabel = Trim(vl_stLeyenda)
                Me.AxMSChart7.ColumnLabel = Trim(vl_stLeyenda)
                Me.AxMSChart8.ColumnLabel = Trim(vl_stLeyenda)
                Me.AxMSChart9.ColumnLabel = Trim(vl_stLeyenda)

                Me.AxMSChart2.RowLabel = CStr(Trim(dt_Consulta.Rows(i - 1).Item(0))) & " - " & CStr(Trim(dt_Consulta.Rows(i - 1).Item(1))) & " - Nro: " & CStr(Trim(dt_Consulta.Rows(i - 1).Item(2))) & " - % " & CStr(Trim(dt_Consulta.Rows(i - 1).Item(3)))
                Me.AxMSChart3.RowLabel = CStr(Trim(dt_Consulta.Rows(i - 1).Item(0))) & " - " & CStr(Trim(dt_Consulta.Rows(i - 1).Item(1))) & " - Nro: " & CStr(Trim(dt_Consulta.Rows(i - 1).Item(2))) & " - % " & CStr(Trim(dt_Consulta.Rows(i - 1).Item(3)))
                Me.AxMSChart4.RowLabel = CStr(Trim(dt_Consulta.Rows(i - 1).Item(0))) & " - " & CStr(Trim(dt_Consulta.Rows(i - 1).Item(1))) & " - Nro: " & CStr(Trim(dt_Consulta.Rows(i - 1).Item(2))) & " - % " & CStr(Trim(dt_Consulta.Rows(i - 1).Item(3)))
                Me.AxMSChart5.RowLabel = CStr(Trim(dt_Consulta.Rows(i - 1).Item(0))) & " - " & CStr(Trim(dt_Consulta.Rows(i - 1).Item(1))) & " - Nro: " & CStr(Trim(dt_Consulta.Rows(i - 1).Item(2))) & " - % " & CStr(Trim(dt_Consulta.Rows(i - 1).Item(3)))
                Me.AxMSChart6.RowLabel = CStr(Trim(dt_Consulta.Rows(i - 1).Item(0))) & " - " & CStr(Trim(dt_Consulta.Rows(i - 1).Item(1))) & " - Nro: " & CStr(Trim(dt_Consulta.Rows(i - 1).Item(2))) & " - % " & CStr(Trim(dt_Consulta.Rows(i - 1).Item(3)))
                Me.AxMSChart7.RowLabel = CStr(Trim(dt_Consulta.Rows(i - 1).Item(0))) & " - " & CStr(Trim(dt_Consulta.Rows(i - 1).Item(1))) & " - Nro: " & CStr(Trim(dt_Consulta.Rows(i - 1).Item(2))) & " - % " & CStr(Trim(dt_Consulta.Rows(i - 1).Item(3)))
                Me.AxMSChart8.RowLabel = CStr(Trim(dt_Consulta.Rows(i - 1).Item(0))) & " - " & CStr(Trim(dt_Consulta.Rows(i - 1).Item(1))) & " - Nro: " & CStr(Trim(dt_Consulta.Rows(i - 1).Item(2))) & " - % " & CStr(Trim(dt_Consulta.Rows(i - 1).Item(3)))
                Me.AxMSChart9.RowLabel = CStr(Trim(dt_Consulta.Rows(i - 1).Item(0))) & " - " & CStr(Trim(dt_Consulta.Rows(i - 1).Item(1))) & " - Nro: " & CStr(Trim(dt_Consulta.Rows(i - 1).Item(2))) & " - % " & CStr(Trim(dt_Consulta.Rows(i - 1).Item(3)))

                Me.AxMSChart2.Column = 1
                Me.AxMSChart3.Column = 1
                Me.AxMSChart4.Column = 1
                Me.AxMSChart5.Column = 1
                Me.AxMSChart6.Column = 1
                Me.AxMSChart7.Column = 1
                Me.AxMSChart8.Column = 1
                Me.AxMSChart9.Column = 1

                Me.AxMSChart2.Data = CInt(Trim(dt_Consulta.Rows(i - 1).Item(2)))
                Me.AxMSChart3.Data = CInt(Trim(dt_Consulta.Rows(i - 1).Item(2)))
                Me.AxMSChart4.Data = CInt(Trim(dt_Consulta.Rows(i - 1).Item(2)))
                Me.AxMSChart5.Data = CInt(Trim(dt_Consulta.Rows(i - 1).Item(2)))
                Me.AxMSChart6.Data = CInt(Trim(dt_Consulta.Rows(i - 1).Item(2)))
                Me.AxMSChart7.Data = CInt(Trim(dt_Consulta.Rows(i - 1).Item(2)))
                Me.AxMSChart8.Data = CInt(Trim(dt_Consulta.Rows(i - 1).Item(2)))
                Me.AxMSChart9.Data = CInt(Trim(dt_Consulta.Rows(i - 1).Item(2)))

            Next

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try


    End Sub
    Private Sub pro_GraficaImagen()

        Try
            Dim oV2Pie As New Graphing.V3.Pie.PieChart()
            Dim renderer As New Render

            With oV2Pie

                .KeyTitle = "INFORME ESTADISTICO"
                .KeyTitleFontStyle = FontStyle.Bold
                .ImageSize = New Size(lWidth, lHeight)
                'Or Auto size
                .AutoSize = False
                .Diameter = 300
                .Thickness = 10
                'Background color for the chart
                .Color = Color.White
                'Adds a border around the pie.
                .GraphBorder = True

                .ImageSize = New Size(CInt(Me.PictureBox1.Size.Width), CInt(Me.PictureBox1.Size.Height))

                Dim i As Integer = 0

                For i = 1 To dt_Consulta.Rows.Count

                    .PieSliceCollection.Add(New Graphing.V3.Pie.PieSlice(CInt(dt_Consulta.Rows(i - 1).Item(2)), Color.FromArgb(fun_AsignarColor(13 * i - 1), fun_AsignarColor(26 * i - 1), fun_AsignarColor(39 * i - 1)), Trim(dt_Consulta.Rows(i - 1).Item(0)) & " - " & Trim(dt_Consulta.Rows(i - 1).Item(1)) & " - " & "Nro.: " & Trim(dt_Consulta.Rows(i - 1).Item(2)) & " - " & Trim(dt_Consulta.Rows(i - 1).Item(3) & " % ")))

                    Me.PictureBox2.Image = renderer.DrawKey(oV2Pie)
                    Me.PictureBox1.Image = renderer.DrawChart(oV2Pie)
                Next

            End With

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub

#End Region

#Region "FUNCIONES"

    Private Function fun_AsignarColor(ByVal inSecuencia As Integer) As Integer

        Try
            Dim inNumero As Integer = CInt(Rnd() * inSecuencia)

            If inSecuencia > 255 Then
                inNumero = CInt(255 / inNumero)
            ElseIf inNumero = 0 Then
                inNumero = 153
            ElseIf inNumero > 255 Then
                inNumero = CInt(255 / inNumero)
            End If

            Return inNumero

        Catch ex As Exception
            MessageBox.Show(Err.Description)
            Return 1
        End Try

    End Function

#End Region

#Region "MENU"

    Private Sub cmdGenerar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGenerar.Click

        pro_Grafica()
        pro_GraficaImagen()

    End Sub
    Private Sub cmdSALIR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSALIR.Click
        Me.Close()
    End Sub

#End Region

#Region "FORMULARIO"

    Private Sub frm_grafica_FIPRESTA_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        pro_Grafica()
        pro_GraficaImagen()
    End Sub

#End Region


End Class