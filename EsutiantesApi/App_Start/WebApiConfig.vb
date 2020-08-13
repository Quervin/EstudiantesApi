Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Net.Http.Formatting
Imports System.Web.Http
Imports System.Web.Http.Cors
Imports MultipartDataMediaFormatter
Imports Newtonsoft.Json.Serialization

Public Module WebApiConfig
    Public Sub Register(ByVal config As HttpConfiguration)
        ' Web API configuration and services

        ' Web API routes
        config.MapHttpAttributeRoutes()

        Dim cors = New EnableCorsAttribute("*", "*", "*")
        config.EnableCors(cors)

        config.Routes.MapHttpRoute(
            name:="DefaultApi",
            routeTemplate:="api/{controller}/{id}",
            defaults:=New With {.id = RouteParameter.Optional}
        )

        Dim jsonFormatter = config.Formatters.OfType(Of JsonMediaTypeFormatter)().ToList()
        For Each jsonp As JsonMediaTypeFormatter In jsonFormatter
            jsonp.SerializerSettings.ContractResolver = New CamelCasePropertyNamesContractResolver()
        Next

        Dim json = config.Formatters.JsonFormatter
        config.Formatters.Remove(config.Formatters.XmlFormatter)
        'config.Formatters.Add(New FormMultipartEncodedMediaTypeFormatter())
        config.Formatters.JsonFormatter.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore

        config.Formatters.JsonFormatter.SerializerSettings.DateTimeZoneHandling = Newtonsoft.Json.DateTimeZoneHandling.Utc
        config.Formatters.Add(New FormMultipartEncodedMediaTypeFormatter())

    End Sub
End Module
