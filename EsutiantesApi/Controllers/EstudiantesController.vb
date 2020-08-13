Imports System.Net
Imports System.Web.Http
Imports Estudiantes
Imports Estudiantes.BLL
Imports Estudiantes.EN

Namespace Controllers

    Public Class EstudiantesController
        Inherits ApiController

        'Metodo que obtiene los estudiantes
        <HttpGet>
        <Route("api/Estudiantes/ListEstudiantesActivos")>
        Public Function ListEstudiantesActivos() As IHttpActionResult
            Return Json(EstudiantesBLL.Instancia.GetEstudiantesActivos)
        End Function

        <HttpGet>
        <Route("api/Estudiantes/ListEstudiantesInactivos")>
        Public Function ListEstudiantesInactivos() As IHttpActionResult
            Return Json(EstudiantesBLL.Instancia.GetEstudiantesInactivos)
        End Function

        <HttpGet>
        <Route("api/Estudiantes/Activar")>
        Public Function Activar(estudianteId As Integer) As IHttpActionResult
            Return Json(EstudiantesBLL.Instancia.ActivarEstudiante(estudianteId))
        End Function

        <HttpGet>
        <Route("api/Estudiantes/Inactivar")>
        Public Function Inactivar(estudianteId As Integer) As IHttpActionResult
            Return Json(EstudiantesBLL.Instancia.DesactivarEstudiante(estudianteId))
        End Function

        <HttpPost>
        <Route("api/Estudiantes/AddEstudiante")>
        Public Function AddEstudiante(estudiante As EN.estudiantes) As IHttpActionResult
            Return Json(EstudiantesBLL.Instancia.AddEstudiante(estudiante))
        End Function

        <HttpPost>
        <Route("api/Estudiantes/EditarEstudiante")>
        Public Function EditarEstudiante(estudiante As EN.estudiantes) As IHttpActionResult
            Return Json(EstudiantesBLL.Instancia.UpdateEstudiante(estudiante))
        End Function

    End Class
End Namespace
