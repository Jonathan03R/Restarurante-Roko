Public Class frmAcercaDe
    Private Sub frmAcercaDe_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Información detallada del software y autor
        Dim acercaDeInfo As String = "Software: Restaurante Roko" & Environment.NewLine &
                                     "--------------------------------------------------" & Environment.NewLine &
                                     "Desarrollado por: Jonathan Jesus Roque Gonzales" & Environment.NewLine &
                                     "Soy el autor de este software de gestión para el restaurante Roko." & Environment.NewLine & Environment.NewLine &
                                     "Tiempo invertido: Aproximadamente 50 horas" & Environment.NewLine &
                                     "--------------------------------------------------" & Environment.NewLine &
                                     "Mi enfoque principal fue la arquitectura del sistema, implementando un modelo en n-capas:" & Environment.NewLine &
                                     "- Capa de persistencia" & Environment.NewLine &
                                     "- Capa de dominio" & Environment.NewLine &
                                     "- Capa de presentación" & Environment.NewLine &
                                     "- Capa de aplicación" & Environment.NewLine &
                                     "Cada una con las entidades correspondientes de acuerdo a la base de datos del restaurante." & Environment.NewLine & Environment.NewLine &
                                     "Procedimientos almacenados: Se implementaron aproximadamente 41 procedimientos almacenados." & Environment.NewLine &
                                     "El uso de estadísticas de costos fue clave para optimizar la extracción de datos." & Environment.NewLine & Environment.NewLine &
                                     "Características adicionales:" & Environment.NewLine &
                                     "- Uso de librerías para la generación de boletas en formato PDF." & Environment.NewLine & Environment.NewLine &
                                     "--------------------------------------------------" & Environment.NewLine &
                                     "¡Conéctate conmigo!" & Environment.NewLine &
                                     "LinkedIn: https://www.linkedin.com/in/jonathan-roque" & Environment.NewLine &
                                     "GitHub: https://github.com/jonathanroque" & Environment.NewLine

        ' Asignar la información a un Label o TextBox en el formulario
        LabelAcercaDe.Text = acercaDeInfo
    End Sub
End Class
