Imports REGLAS_DEL_NEGOCIO
Imports Microsoft.VisualBasic
Imports System
Imports System.Windows.Forms
Imports System.Drawing

Public Class frm_visor_imagen

    '=========================
    '*** VISOR DE IMAGENES ***
    '=========================

#Region "VARIABLE"

    Private vl_stRutaImagen As String

#End Region

#Region "CONSTRUCTOR"

    Public Sub New(ByVal stRuta As String)
        vl_stRutaImagen = stRuta

        InitializeComponent()

        If vl_stRutaImagen <> "0" Then
            pro_MostrarImagen()
        Else
            pro_Cerrar()
        End If

    End Sub

#End Region

#Region "PROCEDIMIENTOS"

    Private Sub pro_MostrarImagen()

        Try
            Me.pibImagenPredio.Image = Image.FromFile(vl_stRutaImagen)

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub pro_Cerrar()
        Me.pibImagenPredio.Image = Nothing
        Me.Close()
    End Sub
    Sub pro_Cambiar(ByVal Picbox As PictureBox, ByVal Escala As Single)

        Try
            ' declara la ubicacion del mause
            Dim position As Point = MousePosition

            ' declara la variable
            Dim PositionX As Single, PositionY As Single
            Dim Ancho As Single, Alto As Single

            PositionX = position.X
            PositionY = position.Y

            ' si hay una imagen ...  
            If Not Picbox.Image Is Nothing Then

                Picbox.SizeMode = PictureBoxSizeMode.Zoom

                With Picbox
                    ' Ancho y alto de la imagen     
                    Ancho = .Image.Width * Escala
                    Alto = .Image.Height * Escala

                    'Me.pibImagenPredio.Location = New System.Drawing.Point((PositionX), (PositionY))
                    'Ancho = PositionX * Escala
                    'Alto = PositionY * Escala

                    .Width = Ancho
                    .Height = Alto
                End With
            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub


#End Region

#Region "MENU"

    Private Sub cmdImprimiar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdImprimir.Click

        Try
            PrintDialog1.Document = PrintDocument1

            If PrintDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then

                PrintDocument1.PrinterSettings = PrintDocument1.PrinterSettings
                PrintDocument1.Print()

            End If

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

    Private Sub frm_visor_imagen_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        With Me.pibImagenPredio
            .SizeMode = PictureBoxSizeMode.Zoom
        End With
        With NumericUpDown1
            .Maximum = 10 ' valor máximo   
            .Minimum = 0 ' minimo  
            .Value = 1
            .Increment = 0.1
            .DecimalPlaces = 1
        End With

    End Sub

#End Region

#Region "Click"

    Private Sub cmdROTAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdROTAR.Click

        Dim bmp As Image = pibImagenPredio.Image

        If optRotarIzq.Checked Then
            bmp.RotateFlip(RotateFlipType.Rotate90FlipXY)
        ElseIf optRotarDer.Checked Then
            bmp.RotateFlip(RotateFlipType.Rotate270FlipXY)
        Else
            bmp.RotateFlip(RotateFlipType.Rotate90FlipNone)
        End If

        pibImagenPredio.Image = bmp

        'pibImagenPredio.SizeMode = PictureBoxSizeMode.StretchImage

    End Sub
    Private Sub pibImagenPredio_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pibImagenPredio.Click
        Me.Close()
    End Sub

#End Region

#Region "ValueChanged"

    Private Sub NumericUpDown1_MouseWheel(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles NumericUpDown1.MouseWheel

        Try
            'If e.Delta <> 0 Then
            '    If e.Delta <= 0 Then
            '        If Me.pibImagenPredio.Width < 500 Then Exit Sub
            '    Else
            '        If Me.pibImagenPredio.Anchor > 2000 Then Exit Sub

            '    End If

            '    Me.pibImagenPredio.Width += CInt(Me.pibImagenPredio.Width * e.Delta / 1000)
            '    Me.pibImagenPredio.Height += CInt(Me.pibImagenPredio.Height * e.Delta / 1000)

            'End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub

    Private Sub NumericUpDown1_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NumericUpDown1.ValueChanged

        ' cambia de tamaño el picbox según el valor de escala  
        If Me.chkHabilitarZoom.Checked = True Then
            pro_Cambiar(Me.pibImagenPredio, CSng(NumericUpDown1.Value))
        End If

    End Sub

#Region "CheckedChanged"

    Private Sub chkHabilitarZoom_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkHabilitarZoom.CheckedChanged

        ' cambia de tamaño el picbox según el valor de escala  
        If Me.chkHabilitarZoom.Checked = False Then
            NumericUpDown1.Visible = False
            NumericUpDown1.Enabled = False
            NumericUpDown1.Value = 1.0
            pro_Cambiar(Me.pibImagenPredio, CSng(NumericUpDown1.Value))
        Else
            NumericUpDown1.Visible = True
            NumericUpDown1.Enabled = True
            NumericUpDown1.Focus()
            pro_Cambiar(Me.pibImagenPredio, CSng(NumericUpDown1.Value))
        End If

    End Sub

#End Region

#End Region

#Region "PrintPage"

    Private Sub PrintDocument1_PrintPage(ByVal sender As System.Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles PrintDocument1.PrintPage
        e.Graphics.DrawImage(Me.pibImagenPredio.Image, 10, 20, 900, 920)
    End Sub

#End Region

#End Region

  
End Class