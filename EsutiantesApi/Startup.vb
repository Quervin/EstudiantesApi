Imports Owin
Imports Microsoft.Owin
Imports Microsoft.Owin.Security.OAuth
Imports System.Web.Http
Imports System.Web

Partial Public Class Startup
    Public Sub Configuration(app As IAppBuilder)
        Dim config As New HttpConfiguration
        ConfigureAuth(app)
        WebApiConfig.Register(config)
        app.UseCors(Microsoft.Owin.Cors.CorsOptions.AllowAll)
        app.UseWebApi(config)
        ConfigureAuth(app)
    End Sub

    Public Sub ConfigureAuth(app As IAppBuilder)
        app.UseOAuthBearerAuthentication(New OAuthBearerAuthenticationOptions())
    End Sub
End Class
