
Imports Estudiantes.DAO
Imports Estudiantes.EN

Public Class EstudiantesBLL
    Public Shared Function Instancia() As EstudiantesBLL
        Return New EstudiantesBLL
    End Function

    Public Function GetEstudiantesActivos() As Reply(Of List(Of EN.estudiantes))
        Dim res As Reply(Of List(Of EN.estudiantes)) = Nothing
        Try
            res = Consultas_Estudiantes.Instancia.getListEstudiantesActivos()
        Catch ex As Exception

        End Try
        Return res
    End Function

    Public Function GetEstudiantesInactivos() As Reply(Of List(Of EN.estudiantes))
        Dim res As Reply(Of List(Of EN.estudiantes)) = Nothing
        Try
            res = Consultas_Estudiantes.Instancia.getListEstudiantesInactivos()
        Catch ex As Exception

        End Try
        Return res
    End Function

    Public Function AddEstudiante(estudiante As EN.estudiantes) As Reply(Of String)
        Dim res As Reply(Of String) = Nothing
        Try
            Dim data = Consultas_Estudiantes.Instancia.getOne(estudiante.nombre, estudiante.email)
            If data Is Nothing Then
                res = Consultas_Estudiantes.Instancia.agregarEstudiante(estudiante)
            Else
                res.Obj = -1
                res.Msj = "Ya existe un estudiante con ese nombre y correo"
                res.OK = False
            End If
        Catch ex As Exception

        End Try
        Return res
    End Function

    Public Function UpdateEstudiante(estudiante As EN.estudiantes) As Reply(Of String)
        Dim res As Reply(Of String) = Nothing
        Try
            res = Consultas_Estudiantes.Instancia.editarEstudiante(estudiante)
        Catch ex As Exception

        End Try
        Return res
    End Function

    Public Function ActivarEstudiante(estudianteId As Integer) As Reply(Of String)
        Dim res As Reply(Of String) = Nothing
        Try
            Dim data = Consultas_Estudiantes.Instancia.getOne2(estudianteId)
            If data Is Nothing Then
                res = Consultas_Estudiantes.Instancia.activarEstudiante(estudianteId)
            Else
                res.Obj = -1
                res.Msj = "No existe un cliente con ese id"
                res.OK = False
            End If
            res = Consultas_Estudiantes.Instancia.activarEstudiante(estudianteId)
        Catch ex As Exception

        End Try
        Return res
    End Function

    Public Function DesactivarEstudiante(estudianteId As Integer) As Reply(Of String)
        Dim res As Reply(Of String) = Nothing
        Try
            Dim data = Consultas_Estudiantes.Instancia.getOne2(estudianteId)
            If data Is Nothing Then
                res = Consultas_Estudiantes.Instancia.desactivarEstudiante(estudianteId)
            Else
                res.Obj = -1
                res.Msj = "No existe un cliente con ese id"
                res.OK = False
            End If
            res = Consultas_Estudiantes.Instancia.activarEstudiante(estudianteId)
        Catch ex As Exception

        End Try
        Return res
    End Function

End Class
