Module mod_MENSAJE
    '==============================================================================================
    'Variables publicas que se utilizar para llevar el mensaje decesado a las validaciones que se
    'le realizan a los correspondientes compos del sistema sicafi.
    '==============================================================================================

    Public Const IncoValoNulo As String = "Ingrese un dato.   "
    Public Const IncoTeclaInvalidad As String = "Tecla inválida."
    Public Const IncoValoNume As String = "Ingrese un dato numérico o asociado al tipo del campo."
    Public Const IncoValoAlfa As String = "Ingrese un dato alfanumerico.      "
    Public Const IncoValoFech As String = "Ingrese un dato de fecha.          "
    Public Const IncoValoDeci As String = "Ingrese un dato decimal o asociado al tipo del campo."

    '=====================================================================
    '*** MENSAJES PARA LA VALIDACIÓN DE LOS OBJETOS DE LOS FORMULARIOS ***
    '=====================================================================

    Public Sub Inco_Valo_Nulo()
        MessageBox.Show(IncoValoNulo, "Mensaje ...", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1)
    End Sub

    Public Sub Inco_Valo_Nume()
        MessageBox.Show(IncoValoNume, "Mensaje ...", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1)
    End Sub

    Public Sub Inco_Tecla_Invalida()
        MessageBox.Show(IncoTeclaInvalidad, "Mensaje ...", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1)
    End Sub

    Public Sub Inco_Valo_Alfa()
        MessageBox.Show(IncoValoAlfa, "Mensaje ...", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1)
    End Sub

    Public Sub Inco_Valo_Fech()
        MessageBox.Show(IncoValoFech, "Mensaje ...", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1)
    End Sub

    Public Sub Inco_Valo_Deci()
        MessageBox.Show(IncoValoDeci, "Mensaje ...", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1)
    End Sub

    Public Sub Consulta_No_Encontro_Registros()
        MessageBox.Show("Consulta no encontro registros", "Mensaje...", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
    End Sub

    Public Sub Proceso_Termino_Correctamente()
        MessageBox.Show("Proceso termino correctamente", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
    End Sub

    Public Sub Proceso_Termino_Con_Inconsistencias()
        MessageBox.Show("Proceso termino con inconsistencias", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1)
    End Sub

    Public Sub No_Existen_Registros_En_Base_De_Datos()
        MessageBox.Show("No existen registros en la base de datos", "Mensaje...", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
    End Sub

    Public Sub Usuario_No_Tiene_Permiso_Para_Realizar_La_Operacion()
        MessageBox.Show("Usuario no tiene permiso para realizar la operación", "Mensaje...", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1)
    End Sub

    Public Sub Existen_Campos_Sin_Diligenciar()
        MessageBox.Show("Existen campos sin diligenciar", "Mensaje...", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1)
    End Sub

    Public Sub Se_Requiere_Realizar_Una_Seleccion()
        MessageBox.Show("Debe realizar una selección", "Mensaje...", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
    End Sub

    Public Sub No_Existe_Una_Vigencia_Actual_Seleccionada()
        MessageBox.Show("No existe una vigencia actual seleccionada", "Mensaje...", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
    End Sub

    Public Sub No_Se_Encontro_Ningun_registro()
        MessageBox.Show("No se encontro ningun registro", "Mensaje ...", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
    End Sub

    Public Sub No_Existe_Un_Registro_Seleccionado()
        MessageBox.Show("No existe un registro seleccionado", "Mensaje...", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1)
    End Sub

    Public Sub Codigo_Existente_En_Base_De_Datos()
        MessageBox.Show("Código existente en la base de datos", "Mensaje...", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1)
    End Sub
    Public Sub Se_Requiere_Seleccionar_Un_Sector()
        MessageBox.Show("Se requiere seleccionar un sector", "Mensaje...", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
    End Sub
    Public Sub Se_Guardaron_Los_Datos_Correctamente()
        MessageBox.Show("Se guardaron los datos correctamente", "Mensaje...", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
    End Sub

    Public Sub No_Se_Guardo_El_Registro_En_La_Base_De_Datos()
        MessageBox.Show("No se guardo el registro en la base de datos", "Mensaje...", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1)
    End Sub

    Public Sub Se_Modificaron_Los_Datos_Correctamente()
        MessageBox.Show("Se modificaron los datos correctamente", "Mensaje...", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
    End Sub

    Public Sub El_Archivo_Existe_En_La_Ruta_De_Destino()
        MessageBox.Show("El archivo existe en la ruta de destino", "Mensaje ...", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1)
    End Sub

    Public Sub No_Se_Modifico_El_Registro_En_La_Base_De_Datos()
        MessageBox.Show("No se modifico el registro en la base de datos", "Mensaje...", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1)
    End Sub

    Public Sub Sumatoria_Mayor_Al_100_Porciento()
        MessageBox.Show("Sumatoria mayor al 100 %", "Mensaje...", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1)
    End Sub

    Public Sub El_Resultado_De_La_consulta_No_Corresponde_a_una_Ficha_Predial()
        MessageBox.Show("El resultado de la consulta no corresponde a una ficha predial", "Mensaje...", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1)
    End Sub

    Public Sub No_Existe_Registros_Para_Exportar()
        MessageBox.Show("No existe registros para exportar", "Mensaje ...", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1)
    End Sub


End Module
