Imports REGLAS_DEL_NEGOCIO

Public Class frm_imagen_PREDIO

    '============================
    '*** IMAGEM FICHA PREDIAL ***
    '============================

 #Region "CONSTRUCTOR"

    Public Sub New(ByVal id As Integer)
        inNroFicha = id
        InitializeComponent()
        pro_InicializarControles()

    End Sub

#End Region

#Region "VARIABLES"

    Dim inNroFicha As Integer
    Dim oLeer As New OpenFileDialog
    Dim stRutaImagen As String

#End Region

#Region "PROCEDIMIENTOS"

    Private Sub pro_InicializarControles()
        Try

            Dim objdatos As New cla_FICHPRED
            Dim tbl As New DataTable

            tbl = objdatos.fun_Consultar_FICHA_PREDIAL_X_NRO_FICHA_PREDIAL(inNroFicha)

            If tbl.Rows.Count > 0 Then

                stRutaImagen = Trim(tbl.Rows(0).Item("FIPRRUIM"))

                If stRutaImagen <> "" And stRutaImagen <> "." Then

                    Me.lblRUTA.Text = stRutaImagen

                    Try
                        pibImagenPredio.Image = Image.FromFile(stRutaImagen)
                        pibImagenPredio.SizeMode = PictureBoxSizeMode.Zoom

                    Catch ex As Exception
                        Dim objdatos45 As New cla_FICHPRED
                        objdatos45.fun_actualizar_IMAGEN_FICHPRED(inNroFicha, ".")

                        pro_AsignarImagen()
                    End Try

                Else
                    pro_AsignarImagen()

                End If

            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "Revisar si el archivo se encuentra en la ruta determinada", "Mensaje ...", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1)
        End Try
        
    End Sub
    Private Sub pro_AsignarImagen()

        Try
            ' Consulta la ruta de las imagenes de ficha predial
            Dim objdatos33 As New cla_RUTAS
            Dim tbl33 As New DataTable

            tbl33 = objdatos33.fun_Buscar_CODIGO_MANT_RUTAS(1)

            If tbl33.Rows.Count > 0 Then

                stRutaImagen = Trim(tbl33.Rows(0).Item("RUTARUTA"))

                Dim ContentItem As String = (inNroFicha & ".jpg")

                If Trim(stRutaImagen) = "" Then
                    MessageBox.Show("Se debe introducir una ruta valida", "Mensaje ...", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                Else
                    If ContentItem = "" Then
                        MessageBox.Show("No se encontro el archivo de imagen", "Mensaje ...", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                    Else
                        Try
                            pibImagenPredio.Image = Image.FromFile(stRutaImagen & "\" & ContentItem)
                            pibImagenPredio.SizeMode = PictureBoxSizeMode.Zoom

                        Catch ex As Exception
                            MessageBox.Show("No se encontro el archivo de imagen", "Mensaje ...", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                        End Try

                        Me.lblRUTA.Text = stRutaImagen & "\" & ContentItem

                        Dim objdatos44 As New cla_FICHPRED
                        objdatos44.fun_actualizar_IMAGEN_FICHPRED(inNroFicha, Trim(stRutaImagen & "\" & ContentItem))

                    End If

                End If

            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub pro_LimpiarCampos()

        Me.lblRUTA.Text = ""
        Me.pibImagenPredio.Image = Nothing

    End Sub

#End Region

#Region "MENU"

    Private Sub cmdGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGuardar.Click
        Try
            If Trim(lblRUTA.Text) = "" Then
                MessageBox.Show("Seleccione la ruta de la imagen", "Mensaje ...", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1)

            Else
                Dim objdatos As New cla_FICHPRED

                If objdatos.fun_actualizar_IMAGEN_FICHPRED(inNroFicha, Trim(lblRUTA.Text)) Then
                    mod_MENSAJE.Se_Guardaron_Los_Datos_Correctamente()
                End If

            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try
    End Sub
    Private Sub cmdEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdEliminar.Click
        Try
            If Trim(Me.lblRUTA.Text) <> "" Then
                If MessageBox.Show("¿ Desea eliminar la ruta de la imagen seleccionada ?", "Mensaje ...", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then
                    pro_LimpiarCampos()

                    Dim stCampo As String = "."

                    Dim objdatos As New cla_FICHPRED

                    objdatos.fun_actualizar_IMAGEN_FICHPRED(inNroFicha, stCampo)

                End If
            Else
                MessageBox.Show("No existe imagen seleccionada", "Mensaje ...", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1)
            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try
    End Sub
    Private Sub cmdAbrirArchivo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAbrirArchivo.Click
        '*** LEER ***

        Try
            ' instancia la clase
            oLeer = New OpenFileDialog

            ' busca y almacena la ruta del archivo
            oLeer.InitialDirectory = My.Computer.FileSystem.SpecialDirectories.MyDocuments
            oLeer.Filter = "Archivo de imagen (*.jpg)|*.jpg|Archivo de imagen (*.bmp)|*.bmp|Archivo de icono (*.ico)|*.ico|Todos los archivos (*.*)|*.*" 'Colocar varias extensiones
            oLeer.FilterIndex = 1
            oLeer.ShowDialog()

            ' verifica la selección
            If Trim(oLeer.FileName) <> "" Then

                ' abre el archivo
                FileOpen(1, oLeer.FileName, OpenMode.Input) 'leer
                stRutaImagen = oLeer.FileName

                ' cierra la caja de dialogo
                FileClose(1)

                ' carga el picture box
                pibImagenPredio.Image = Image.FromFile(stRutaImagen)

                pibImagenPredio.SizeMode = PictureBoxSizeMode.Zoom

                ' llena el label con la ruta
                lblRUTA.Text = stRutaImagen

                If MessageBox.Show("¿ Desea guardar la imagen seleccionada ?", "Mensaje ...", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then
                    Me.cmdGuardar.PerformClick()
                End If
            End If

        Catch ex As Exception
            MsgBox(Err.Description)
        Finally
            FileClose(1)
        End Try

    End Sub
    Private Sub cmdLimpiar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdLimpiar.Click
        pro_LimpiarCampos()
    End Sub
    Private Sub cmdSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSalir.Click
        Me.cmdAbrirArchivo.Focus()
        Me.Close()
    End Sub

#End Region

#Region "FORMULARIO"

#Region "Click"

    Private Sub pibImagenPredio_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pibImagenPredio.Click
        pibImagenPredio.SizeMode = PictureBoxSizeMode.Zoom
    End Sub

#End Region

#Region "SelectedIndexChanged"

    Private Sub cboPresentacion_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboPresentacion.SelectedIndexChanged
        '*** PRESENTACIÓN DE COMBOBOX ***

        Dim Presentacion As Integer

        Presentacion = cboPresentacion.SelectedIndex

        Select Case Presentacion
            Case 0
                pibImagenPredio.SizeMode = PictureBoxSizeMode.StretchImage
            Case 1
                pibImagenPredio.SizeMode = PictureBoxSizeMode.CenterImage
            Case 2
                pibImagenPredio.SizeMode = PictureBoxSizeMode.Normal
            Case 3
                pibImagenPredio.SizeMode = PictureBoxSizeMode.Zoom
        End Select

    End Sub

#End Region

#Region "GotFocus"

    Private Sub cmdGuardar_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdGuardar.GotFocus
        strBARRESTA.Items(0).Text = cmdGuardar.AccessibleDescription
    End Sub
    Private Sub cmdEliminar_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdEliminar.GotFocus
        strBARRESTA.Items(0).Text = cmdEliminar.AccessibleDescription
    End Sub
    Private Sub cmdAbrirArchivo_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdAbrirArchivo.GotFocus
        strBARRESTA.Items(0).Text = cmdAbrirArchivo.AccessibleDescription
    End Sub
    Private Sub cmdLimpiar_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdLimpiar.GotFocus
        strBARRESTA.Items(0).Text = cmdLimpiar.AccessibleDescription
    End Sub
    Private Sub cmdSalir_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdSalir.GotFocus
        strBARRESTA.Items(0).Text = cmdSalir.AccessibleDescription
    End Sub
    Private Sub pibImagenPredio_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles pibImagenPredio.GotFocus
        strBARRESTA.Items(0).Text = pibImagenPredio.AccessibleDescription
    End Sub

#End Region

#Region "ResizeBegin"

    Private Sub frm_ResizeBegin(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.ResizeBegin
        Me.Opacity = vp_Opacity
    End Sub

#End Region

#Region "ResizeEnd"

    Private Sub frm_ResizeEnd(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.ResizeEnd
        Dim opacity As Double = Convert.ToDouble(100)
        Me.Opacity = opacity
    End Sub

#End Region

#End Region

End Class