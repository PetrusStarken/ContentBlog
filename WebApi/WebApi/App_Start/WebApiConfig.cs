namespace WebApi
{
    using System.Configuration;
    using System.Web.Http;
    using System.Web.Http.Cors;

    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Enabling CORS for our webapp
            var webAppAddress = ConfigurationManager.AppSettings["webAppAddress"].ToString();
            var corsAttr = new EnableCorsAttribute(webAppAddress, "*", "*");
            config.EnableCors(corsAttr);
            // Web API configuration and services

            UnityConfig.RegisterComponents();

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
