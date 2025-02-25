Imports REGLAS_DEL_NEGOCIO

Public Class frm_LISTVALOMANT

    '================================================
    '*** LISTA DE VALORES TABLAS DE MANTENIMIENTO ***
    '================================================

#Region "FORMULARIO"

    Private Sub frm_LISTVALOMANT_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Dim item As New ListViewItem
        Dim objdatos As New cla_LIVAMANT

        Dim ds As New DataSet

        ds = objdatos.fun_Consultar_TABLAS_MANT_FICHPRED

        If ds.Tables(0).Rows.Count > 0 Then
            Dim j As Integer

            '*** TIPO DE RESOLUCIÓN ***
            For j = 0 To ds.Tables(0).Rows.Count - 1
                item = lsvTIPORESO.Items.Add(ds.Tables(0).Rows(j).Item("TIRECODI"))
                item.SubItems.Add(ds.Tables(0).Rows(j).Item("TIREDESC"))
            Next

            '*** DESTINACIÓN ECONOMICA ***
            For j = 0 To ds.Tables(1).Rows.Count - 1
                item = lsvDESTECON.Items.Add(ds.Tables(1).Rows(j).Item("DEECCODI"))
                item.SubItems.Add(ds.Tables(1).Rows(j).Item("DEECDESC"))
            Next

            '*** MODO DE ADQUISICIÓN ***
            For j = 0 To ds.Tables(2).Rows.Count - 1
                item = lsvMODOADQU.Items.Add(ds.Tables(2).Rows(j).Item("MOADCODI"))
                item.SubItems.Add(ds.Tables(2).Rows(j).Item("MOADDESC"))
            Next

            '*** TIPO DE DOCUMENTO ***
            For j = 0 To ds.Tables(3).Rows.Count - 1
                item = lsvTIPODOCU.Items.Add(ds.Tables(3).Rows(j).Item("TIDOCODI"))
                item.SubItems.Add(ds.Tables(3).Rows(j).Item("TIDODESC"))
            Next

            '*** CLASE DE CONSTRUCCIÓN ***
            For j = 0 To ds.Tables(4).Rows.Count - 1
                item = lsvCLASCONS.Items.Add(ds.Tables(4).Rows(j).Item("CLCOCODI"))
                item.SubItems.Add(ds.Tables(4).Rows(j).Item("CLCODESC"))
            Next

            '*** CODIGO DE CALIFICACIÓN ***
            For j = 0 To ds.Tables(5).Rows.Count - 1
                item = lsvCODICALI.Items.Add(ds.Tables(5).Rows(j).Item("COCACODI"))
                item.SubItems.Add(ds.Tables(5).Rows(j).Item("COCADESC"))
            Next

            '*** MUNICIPIO ***
            For j = 0 To ds.Tables(6).Rows.Count - 1
                item = lsvMUNICIPIO.Items.Add(ds.Tables(6).Rows(j).Item("MUNICODI"))
                item.SubItems.Add(ds.Tables(6).Rows(j).Item("MUNIDESC"))
            Next

            '*** PUNTO CARDINAL ***
            For j = 0 To ds.Tables(7).Rows.Count - 1
                item = lsvPUNTCARD.Items.Add(ds.Tables(7).Rows(j).Item("PUCACODI"))
                item.SubItems.Add(ds.Tables(7).Rows(j).Item("PUCADESC"))
            Next

            '*** CLASE O SECTOR ***
            For j = 0 To ds.Tables(8).Rows.Count - 1
                item = lsvCLASSECT.Items.Add(ds.Tables(8).Rows(j).Item("CLSECODI"))
                item.SubItems.Add(ds.Tables(8).Rows(j).Item("CLSEDESC"))
            Next

            '*** CARACTERISTICA DE PREDIO ***
            For j = 0 To ds.Tables(9).Rows.Count - 1
                item = lsvCARAPRED.Items.Add(ds.Tables(9).Rows(j).Item("CAPRCODI"))
                item.SubItems.Add(ds.Tables(9).Rows(j).Item("CAPRDESC"))
            Next

            '*** DEPARTAMENTO ***
            For j = 0 To ds.Tables(10).Rows.Count - 1
                item = lsvDEPARTAMENTO.Items.Add(ds.Tables(10).Rows(j).Item("DEPACODI"))
                item.SubItems.Add(ds.Tables(10).Rows(j).Item("DEPADESC"))
            Next

            '*** CATEGORIA DE SUELO ***
            For j = 0 To ds.Tables(11).Rows.Count - 1
                item = lsvCATESUEL.Items.Add(ds.Tables(11).Rows(j).Item("CASUCODI"))
                item.SubItems.Add(ds.Tables(11).Rows(j).Item("CASUDESC"))
            Next

            '*** TIPO DE CONSTRUCCIÓN ***
            For j = 0 To ds.Tables(12).Rows.Count - 1
                item = lsvTIPOCONS.Items.Add(ds.Tables(12).Rows(j).Item("TICOCODI"))
                item.SubItems.Add(ds.Tables(12).Rows(j).Item("TICODESC"))
            Next

            '*** SEXO ***
            For j = 0 To ds.Tables(13).Rows.Count - 1
                item = lsvSEXO.Items.Add(ds.Tables(13).Rows(j).Item("SEXOCODI"))
                item.SubItems.Add(ds.Tables(13).Rows(j).Item("SEXODESC"))
            Next

        End If


    End Sub

#End Region

End Class