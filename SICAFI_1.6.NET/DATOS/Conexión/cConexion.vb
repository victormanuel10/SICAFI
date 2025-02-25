Imports System.Data.SqlClient
Imports System.Data
Imports System.Security.Principal
Imports SYSTEM.Security.Permissions
Imports System.IO

Public Class cConexion

#Region "VARIABLES"

    Dim cnn As New SqlConnection
    Dim stMaquina As String = ""
    Dim stInstancia As String = ""

#End Region

#Region "PROCEDIMIENTOS"

    Private Sub Pro_Conexion_Soporte()

        Try
            If Trim(vp_st_Instancia) = "RED" Then

                stMaquina = "DESKTOP-3T43PDR"
                stInstancia = "SQLEXPRESS"
                cnn.ConnectionString = "Data Source=" & stMaquina & "\" & stInstancia & ";Initial Catalog=SICAFI;User ID=sa;Password=Sql#2o25*."

                ' variables de conexion 
                vp_stDataSource = CStr(Trim(stMaquina) & "\" & Trim(stInstancia))
                vp_stInitialCatalog = CStr(Trim("SICAFI"))
                vp_stUserID = CStr(Trim("sa"))
                vp_stPassword = CStr(Trim("Sql#2o25*."))

                vp_stConexionRED = cnn.ConnectionString.ToString

            ElseIf Trim(vp_st_Instancia) = "LOCAL" Then

                stMaquina = My.Computer.Name
                stInstancia = "SQLEXPRESS"
                cnn.ConnectionString = "Data Source=" & stMaquina & "\" & stInstancia & ";Initial Catalog=SICAFI;User ID=sa;Password=Sql#2o25*."

                ' variables de conexion 
                vp_stDataSource = CStr(Trim(stMaquina) & "\" & Trim(stInstancia))
                vp_stInitialCatalog = CStr(Trim("SICAFI"))
                vp_stUserID = CStr(Trim("sa"))
                vp_stPassword = CStr(Trim("Sql#2o25*."))

                vp_stConexionLOCAL = cnn.ConnectionString.ToString

            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub

    Private Sub Pro_Conexion_Pruebas()

        Try
            If Trim(vp_st_Instancia) = "RED" Then

                stMaquina = "RRM-HP"
                stInstancia = "SQL2017"
                cnn.ConnectionString = "Data Source=" & stMaquina & "\" & stInstancia & ";Initial Catalog=SICAFI;User ID=sa;Password=12345.*#"

                ' variables de conexion 
                vp_stDataSource = CStr(Trim(stMaquina) & "\" & Trim(stInstancia))
                vp_stInitialCatalog = CStr(Trim("SICAFI"))
                vp_stUserID = CStr(Trim("Backup"))
                vp_stPassword = CStr(Trim("Clave.Bck0"))

                vp_stConexionRED = cnn.ConnectionString.ToString

            ElseIf Trim(vp_st_Instancia) = "LOCAL" Then

                stMaquina = My.Computer.Name
                stInstancia = "SQL2017"
                cnn.ConnectionString = "Data Source=" & stMaquina & "\" & stInstancia & ";Initial Catalog=SICAFI;User ID=sa;Password=12345.*#"

                ' variables de conexion 
                vp_stDataSource = CStr(Trim(stMaquina) & "\" & Trim(stInstancia))
                vp_stInitialCatalog = CStr(Trim("SICAFI"))
                vp_stUserID = CStr(Trim("Backup"))
                vp_stPassword = CStr(Trim("Clave.Bck0"))

                vp_stConexionLOCAL = cnn.ConnectionString.ToString

            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub

    Public Function conexion() As SqlConnection

        Try
            cnn = New SqlConnection

            If cnn.State = 1 Then cnn.Close()

            ' Realiza la conexion
            Pro_Conexion_Soporte()
            'Pro_Conexion_Pruebas()

            vp_stConexionBD = cnn.ConnectionString.ToString

            cnn.Open()

            Return cnn

        Catch ex As Exception
            MessageBox.Show(Err.Description)
            Return Nothing
        End Try

    End Function
    Public Function cerrar_base() As Boolean
        cnn.Close()
    End Function

#End Region

End Class
