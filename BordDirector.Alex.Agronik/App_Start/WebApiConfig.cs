using BordDirector.Alex.Agronik.Utilities;
using Microsoft.Web.Http;
using Microsoft.Web.Http.Routing;
using Swashbuckle.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Description;
using System.Web.Http.Dispatcher;
using System.Web.Http.Routing;

namespace BordDirector.Alex.Agronik
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            var cors = new EnableCorsAttribute("*", "*", "*");
            config.EnableCors(cors);

            // Web API routes
            config.MapHttpAttributeRoutes(new DefaultInlineConstraintResolver { ConstraintMap = { ["apiVersion"] = typeof(ApiVersionRouteConstraint) } });

            //config.Routes.MapHttpRoute(
            //    name: "DefaultApi",
            //    routeTemplate: "api/{controller}/{id}",
            //    defaults: new { id = RouteParameter.Optional }
            //);

            config.AddApiVersioning(c =>
            {
                c.DefaultApiVersion = new ApiVersion(1, 0);
                c.AssumeDefaultVersionWhenUnspecified = true;
                c.ReportApiVersions = true;
            });

            var apiExplorer = config.AddVersionedApiExplorer(options =>
            {
                options.GroupNameFormat = "'v'VVV";
                options.SubstituteApiVersionInUrl = true;
            });

            config.EnableSwagger("swagger/docs/{apiVersion}", c =>
            {
                c.MultipleApiVersions(
                    (apiDescription, version) => apiDescription.GetGroupName() == version,
                    (vc) =>
                    {
                        foreach (var group in apiExplorer.ApiDescriptions)
                        {
                            vc.Version(group.Name, $"API{group.ApiVersion}");
                        }
                    });
                c.IgnoreObsoleteActions();
                c.ApiKey("apiKey")
                    .Description("API Key Authentication")
                    .Name("X-ApiKey-Test")
                    .In("header");
                c.SchemaFilter<SwaggerSkipPropertyFilter>();
            })
            .EnableSwaggerUi(c =>
            {
                c.EnableApiKeySupport("X-ApiKey-Test", "header");
            });
            //var previousSelector = config.Services.GetService(typeof(IHttpControllerSelector)) as IHttpControllerSelector;
            //config.Services.Replace(typeof(IHttpControllerSelector), new CustomHttpControllerSelector(config) { PreviousSelector = previousSelector });
        }
    }
}
