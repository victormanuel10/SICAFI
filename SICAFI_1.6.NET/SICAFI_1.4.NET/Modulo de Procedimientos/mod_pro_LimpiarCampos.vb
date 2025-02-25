Module mod_pro_LimpiarCampos

    Public Sub pp_pro_LimpiarCampos(ByVal oGroupBox As Object)

        ' limpia las cajas de texto
        For Each c As Control In oGroupBox.Controls
            If TypeOf c Is TextBox Then
                c.Text = ""
            End If
        Next

        '' limpia las cajas de descripcion
        'For Each c As Control In oGroupBox.Controls
        '    If TypeOf c Is Label Then
        '        c.Text = ""
        '    End If
        'Next

        ' Limpiar los cuadros de chequeo
        For Each b As Control In oGroupBox.Controls
            If TypeOf b Is CheckBox Then
                Dim ck As New CheckBox
                Try
                    ck = b
                    ck.CheckState = CheckState.Unchecked
                    b = ck
                Catch ex As Exception

                End Try
            End If
        Next

        ' limpia las opciones de chequeo
        For Each b As Control In oGroupBox.Controls
            If TypeOf b Is RadioButton Then
                Dim rb As New RadioButton
                Try
                    rb = b
                    rb.Checked = CheckState.Checked
                    b = rb
                Catch ex As Exception

                End Try
            End If
        Next

        ' limpia las opciones de chequeo
        For Each b As Control In oGroupBox.Controls
            If TypeOf b Is ComboBox Then
                Dim cb As New ComboBox
                Try
                    cb = b
                    cb.DataSource = New DataTable
                    b = cb
                Catch ex As Exception

                End Try
            End If
        Next

    End Sub

End Module
