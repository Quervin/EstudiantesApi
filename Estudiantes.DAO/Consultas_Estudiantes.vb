Imports Estudiantes.EN

Public Class Consultas_Estudiantes

    Private db As New EstudiantesEntities

    Public Shared Function Instancia() As Consultas_Estudiantes
        Return New Consultas_Estudiantes
    End Function

    Public Function getListEstudiantesActivos() As Reply(Of List(Of EN.estudiantes))
        Dim reply As New Reply(Of List(Of EN.estudiantes))

        db.Configuration.ProxyCreationEnabled = False
        Try

            Dim list = db.estudiantes.Where(Function(a) a.estado = True).ToList()

            reply.OK = True
            reply.Msj = "Exito"
            reply.Obj = list

        Catch ex As Exception
            reply.OK = False
            reply.Msj = "A ocurrido un error " + ex.Message.ToString
            System.Diagnostics.EventLog.WriteEntry("Application", ex.TargetSite.ToString & " / " & ex.Message, EventLogEntryType.Error)
        End Try
        Return reply

    End Function


    Public Function getListEstudiantesInactivos() As Reply(Of List(Of EN.estudiantes))
        Dim reply As New Reply(Of List(Of EN.estudiantes))

        db.Configuration.ProxyCreationEnabled = False
        Try

            Dim list = db.estudiantes.Where(Function(a) a.estado = False).ToList()

            reply.OK = True
            reply.Msj = "Exito"
            reply.Obj = list

        Catch ex As Exception
            reply.OK = False
            reply.Msj = "A ocurrido un error " + ex.Message.ToString
            System.Diagnostics.EventLog.WriteEntry("Application", ex.TargetSite.ToString & " / " & ex.Message, EventLogEntryType.Error)
        End Try
        Return reply

    End Function

    Public Function editarEstudiante(estudiante As EN.estudiantes) As Reply(Of String)
        Dim reply As New Reply(Of String)

        db.Configuration.ProxyCreationEnabled = False
        Try

            Dim data = db.estudiantes.Where(Function(a) a.id = estudiante.id).SingleOrDefault()
            If data Is Nothing Then
                reply.OK = False
                reply.Msj = "El id no existe en nuestros registros"
                reply.Obj = -1
            Else
                data.id = estudiante.id
                data.nombre = estudiante.nombre
                data.telefono = estudiante.telefono
                data.estado = estudiante.estado
                db.SaveChanges()

                reply.OK = True
                reply.Msj = "Exito"
                reply.Obj = estudiante.id

            End If

        Catch ex As Exception
            reply.OK = False
            reply.Msj = "A ocurrido un error " + ex.Message.ToString
            System.Diagnostics.EventLog.WriteEntry("Application", ex.TargetSite.ToString & " / " & ex.Message, EventLogEntryType.Error)
        End Try
        Return reply

    End Function


    Public Function agregarEstudiante(estudiante As EN.estudiantes) As Reply(Of String)
        Dim reply As New Reply(Of String)

        db.Configuration.ProxyCreationEnabled = False
        Try

            Dim data = db.estudiantes.Add(estudiante)
            If data Is Nothing Then
                reply.OK = False
                reply.Msj = "El id no existe"
                reply.Obj = -1
            Else
                reply.OK = True
                reply.Msj = "Exito"
                reply.Obj = estudiante.id

            End If

        Catch ex As Exception
            reply.OK = False
            reply.Msj = "A ocurrido un error " + ex.Message.ToString
            System.Diagnostics.EventLog.WriteEntry("Application", ex.TargetSite.ToString & " / " & ex.Message, EventLogEntryType.Error)
        End Try
        Return reply

    End Function

    Public Function activarEstudiante(estudianteId As Integer) As Reply(Of String)
        Dim reply As New Reply(Of String)

        db.Configuration.ProxyCreationEnabled = False
        Try

            Dim data = db.estudiantes.Where(Function(a) a.id = estudianteId).SingleOrDefault()
            If data Is Nothing Then
                reply.OK = False
                reply.Msj = "El id no existe"
                reply.Obj = -1
            Else
                data.estado = True
                db.SaveChanges()

                reply.Obj = True
                reply.Msj = "Estudiante activado"
                reply.Obj = data.id
            End If

        Catch ex As Exception
            reply.OK = False
            reply.Msj = "A ocurrido un error " + ex.Message.ToString
            System.Diagnostics.EventLog.WriteEntry("Application", ex.TargetSite.ToString & " / " & ex.Message, EventLogEntryType.Error)
        End Try
        Return reply

    End Function


    Public Function desactivarEstudiante(estudianteID As Integer) As Reply(Of String)
        Dim reply As New Reply(Of String)

        db.Configuration.ProxyCreationEnabled = False
        Try

            Dim data = db.estudiantes.Where(Function(a) a.id = estudianteID).SingleOrDefault()
            If data Is Nothing Then
                reply.OK = False
                reply.Msj = "El id no existe"
                reply.Obj = -1
            Else
                reply.OK = True
                reply.Msj = "Estudiante desactivado"
                reply.Obj = data.id

            End If

        Catch ex As Exception
            reply.OK = False
            reply.Msj = "A ocurrido un error " + ex.Message.ToString
            System.Diagnostics.EventLog.WriteEntry("Application", ex.TargetSite.ToString & " / " & ex.Message, EventLogEntryType.Error)
        End Try
        Return reply

    End Function


    Public Function getOne(nombre As String, email As String) As EN.estudiantes
        Dim reply As New EN.estudiantes

        db.Configuration.ProxyCreationEnabled = False
        Try

            Dim estudiante = db.estudiantes.Where(Function(a) a.nombre = nombre And a.email = email).SingleOrDefault()

            If estudiante Is Nothing Then
                reply = Nothing
            Else
                reply = estudiante
            End If

        Catch ex As Exception
            reply = Nothing
            System.Diagnostics.EventLog.WriteEntry("Application", ex.TargetSite.ToString & " / " & ex.Message, EventLogEntryType.Error)
        End Try
        Return reply

    End Function

    Public Function getOne2(estudianteId As Integer) As EN.estudiantes
        Dim reply As New EN.estudiantes

        db.Configuration.ProxyCreationEnabled = False
        Try

            Dim estudiante = db.estudiantes.Where(Function(a) a.id = estudianteId).SingleOrDefault()

            If estudiante Is Nothing Then
                reply = Nothing
            Else
                reply = estudiante
            End If

        Catch ex As Exception
            reply = Nothing
            System.Diagnostics.EventLog.WriteEntry("Application", ex.TargetSite.ToString & " / " & ex.Message, EventLogEntryType.Error)
        End Try
        Return reply

    End Function


End Class
