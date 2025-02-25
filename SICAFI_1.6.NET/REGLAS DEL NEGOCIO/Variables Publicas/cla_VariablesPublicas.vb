Public Class cla_VariablesPublicas

    '=====================================================================================
    'Variables publicas que se reciben desde el formulario SICAFI debido que las clases 
    'necesitan el usuario que ingresa al sistema para guardar el registro historico de
    'las modificaciones realizadas.
    '=====================================================================================

    Public Sub New(ByVal usuario As String, ByVal nombre As String, ByVal cedula As String, ByVal instancia As String)
        vp_usuario = usuario
        vp_nombres = nombre
        vp_cedula = cedula
        vp_instancia = instancia

    End Sub
    Public Sub New(ByVal instancia As String)
        vp_instancia = instancia

        Dim stInstancia As New DATOS.cla_ConnectionInstance(vp_instancia)

    End Sub




End Class
