Imports REGLAS_DEL_NEGOCIO

Module Mod_VariablesPublicas

    ' Conserva el usuario
    Public vp_usuario As String = ""
    ' conserva los nombres completos del usuario en uso
    Public vp_nombres As String = ""
    ' conserva la cedula del usuario en uso
    Public vp_cedula As String = ""
    ' conserva el numero de la ficha predial que se agrega, modifica o consulta
    Public vp_FichaPredial As Integer = 0
    ' conserva el ID del registro que se consulta
    Public vp_inConsulta As Integer = 0
    ' conserva el datatable 
    Public vp_tblConsulta As DataTable
    ' almacena el departamento
    Public Const vp_Departamento As String = "05"
    ' variable publica para opacar los formularios
    Public Const vp_Opacity As Double = 0.4
    ' variable de instancia
    Public vp_Instancia As String = ""
    ' variable de coneccion
    Public vp_stConeccion As String = ""
    ' variable version de actualizacion
    Public vp_stVersionActualizacion As String = ""
    ' variable el estado del registro
    Public vp_stEstado As String = ""
End Module
