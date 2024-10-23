Public Class frmAcercaDe
    Private Sub frmAcercaDe_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Información detallada del software y autor
        Dim acercaDeInfo As String = "Software: Restaurante Roko" & Environment.NewLine &
                                     "--------------------------------------------------" & Environment.NewLine &
                                     "Desarrollado por: Jonathan Jesus Roque Gonzales" & Environment.NewLine &
                                     "Soy el autor de este software de gestión para el restaurante Roko." & Environment.NewLine & Environment.NewLine &
                                     "Tiempo invertido: Aproximadamente 50 horas" & Environment.NewLine &
                                     "--------------------------------------------------" & Environment.NewLine &
                                     "En este proyecto me enfoqué principalmente en la arquitectura del sistema para asegurar " & Environment.NewLine &
                                     "que el software sea escalable, mantenible y eficiente a largo plazo. Implementé el modelo n-capas:" & Environment.NewLine &
                                     "- Capa de persistencia: Gestiona todas las operaciones relacionadas con la base de datos, garantizando " & Environment.NewLine &
                                     "  la integridad de los datos y optimizando las consultas para un rendimiento eficiente." & Environment.NewLine &
                                     "- Capa de dominio: Contiene la lógica de negocio y las reglas fundamentales del restaurante, asegurando " & Environment.NewLine &
                                     "  que todas las operaciones del sistema se alineen con las necesidades reales del cliente." & Environment.NewLine &
                                     "- Capa de presentación: Aunque el diseño de las interfaces no fue mi enfoque principal, el sistema ofrece " & Environment.NewLine &
                                     "  una experiencia de usuario funcional para la gestión del restaurante, priorizando la funcionalidad sobre el diseño visual." & Environment.NewLine &
                                     "- Capa de aplicación: Actúa como intermediaria entre las otras capas, coordinando la lógica de negocio y " & Environment.NewLine &
                                     "  la persistencia de datos, asegurando que cada capa esté correctamente desacoplada." & Environment.NewLine & Environment.NewLine &
                                     "El diseño de las interfaces se mantuvo simple, ya que mi mayor esfuerzo se centró en desarrollar una arquitectura robusta que " & Environment.NewLine &
                                     "facilitara la escalabilidad y el rendimiento del sistema, dejando la posibilidad de mejorar el diseño visual en futuras versiones." & Environment.NewLine & Environment.NewLine &
                                     "Procedimientos almacenados: El sistema cuenta con aproximadamente 41 procedimientos almacenados que optimizan " & Environment.NewLine &
                                     "las interacciones con la base de datos. Hice un esfuerzo considerable en analizar los costos de las consultas para garantizar " & Environment.NewLine &
                                     "que los datos se extraigan de la forma más eficiente posible, especialmente para manejar grandes volúmenes de información en " & Environment.NewLine &
                                     "las operaciones del restaurante." & Environment.NewLine & Environment.NewLine &
                                     "Se implementaron funcionalidades avanzadas, como la generación de boletas en formato PDF utilizando librerías especializadas, " & Environment.NewLine &
                                     "lo cual facilita la gestión de comprobantes de pago de forma automática, brindando una experiencia fluida tanto para los empleados " & Environment.NewLine &
                                     "como para los clientes." & Environment.NewLine & Environment.NewLine &
                                     "Además, se respetaron las mejores prácticas en programación, asegurando que el código sea claro, bien estructurado y fácil de mantener." & Environment.NewLine & Environment.NewLine

        ' Asignar la información a un Label en el formulario
        LabelAcercaDe.Text = acercaDeInfo

        ' Configurar el LinkLabel con el enlace del repositorio
        LinkLabelRepositorio.Text = "Repositorio del proyecto: Restaurante Roko GitHub"
        LinkLabelRepositorio.Links.Add(0, LinkLabelRepositorio.Text.Length, "https://github.com/Jonathan03R/Restarurante-Roko.git")
    End Sub

    ' Evento para abrir el enlace al hacer clic en el LinkLabel
    Private Sub LinkLabelRepositorio_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabelRepositorio.LinkClicked
        System.Diagnostics.Process.Start(e.Link.LinkData.ToString())
    End Sub
End Class
