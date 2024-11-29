Imports System.Security.Cryptography
Imports System.Text
Imports System.Data.SqlClient

Public Class Login
    Private Sub btnIniciarSesion_Click(sender As Object, e As EventArgs) Handles btnIniciarSesion.Click
        Try
            ' Iniciar transacción desde el módulo
            IniciarTransaccion()

            ' Obtener el comando del procedimiento almacenado dentro de la transacción
            Dim comando As SqlCommand = ObtenerComandoDeProcedimiento("spAutenticacionUsuarios")

            ' Encriptar la contraseña ingresada con MD5
            Dim claveIngresada As String = txtPassword.Text
            Dim claveEncriptada As String = EncriptarClaveMD5(claveIngresada)

            ' Añadir parámetros al comando
            comando.Parameters.AddWithValue("@Nombre", txtUsuario.Text)
            comando.Parameters.AddWithValue("@Clave", claveEncriptada)

            ' Añadir parámetro para capturar el valor de retorno
            Dim paResultado As SqlParameter = comando.Parameters.Add("@Resultado", SqlDbType.Int)
            paResultado.Direction = ParameterDirection.ReturnValue

            ' Ejecutar el procedimiento almacenado
            comando.ExecuteNonQuery()

            ' Obtener el valor de retorno
            Dim resultado As Integer = Convert.ToInt32(paResultado.Value)

            ' Verificar el resultado
            If resultado = 1 Then
                MessageBox.Show("Inicio de sesión exitoso.")

                ' Confirmar la transacción
                TerminarTransaccion()

                ' Abrir la página principal
                Dim frmPrincipal As New PaginaPrincipal
                frmPrincipal.Show()
                Me.Hide()
            Else
                MessageBox.Show("Credenciales incorrectas o usuario inactivo.")

                ' Cancelar la transacción si el usuario no es válido
                CancelarTransaccion()
            End If
        Catch ex As Exception
            ' Cancelar la transacción en caso de error
            CancelarTransaccion()
            MessageBox.Show("Error durante el inicio de sesión: " & ex.Message)
        End Try
    End Sub

    ' Función para encriptar la contraseña usando MD5
    Private Function EncriptarClaveMD5(clave As String) As String
        Using md5 As MD5 = MD5.Create()
            Dim bytesClave As Byte() = Encoding.UTF8.GetBytes(clave)
            Dim hash As Byte() = md5.ComputeHash(bytesClave)
            Return BitConverter.ToString(hash).Replace("-", "").ToLower()
        End Using
    End Function
End Class
