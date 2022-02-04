using System.Net.Http.Headers;
using System.Web.Http;
using System.Web.Http.Cors;
using WebApiColmap.Controllers;

namespace WebApiColmap
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            var cors = new EnableCorsAttribute("*", "*", "*");

            config.EnableCors(cors);

            // Configuración y servicios de API web

            // Rutas de API web
            config.MapHttpAttributeRoutes();

            config.Formatters.JsonFormatter.SupportedMediaTypes.Add(new MediaTypeHeaderValue("text/html"));
            //config.MessageHandlers.Add(new TokenValidationHandler());

            config.MessageHandlers.Add(new TokenValidationHandlerController());
            config.Routes.MapHttpRoute(
            name: "DefaultApi",
            routeTemplate: "api/{controller}/{id}",
            defaults: new { id = RouteParameter.Optional }
        );
        }
    }
}
