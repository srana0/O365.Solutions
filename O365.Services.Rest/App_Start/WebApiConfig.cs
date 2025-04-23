namespace O365.Services.Rest
{
    #region Namespace

    using System.Configuration;
    using System.Web.Http;
    using System.Web.Http.Cors;
    using WebApiContrib.Formatting.Jsonp;

    #endregion
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            //Gets comma separated allowed origins from Web.config
            var cors = new EnableCorsAttribute(ConfigurationManager.AppSettings["CORSOrigins"].ToString(), "*", "*");
            config.EnableCors(cors);

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{Action}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            var json = config.Formatters.JsonFormatter;
            json.SerializerSettings.PreserveReferencesHandling = Newtonsoft.Json.PreserveReferencesHandling.Objects;
            config.Formatters.Insert(config.Formatters.Count - 1, new JsonpMediaTypeFormatter(json, null));

        }
    }
}