using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Dispatcher;

namespace BordDirector.Alex.Agronik.Utilities
{
    public class CustomHttpControllerSelector : IHttpControllerSelector
    {
        private HttpConfiguration _config;

        public IHttpControllerSelector PreviousSelector { get; set; }

        public CustomHttpControllerSelector(HttpConfiguration configuration)
        {
            _config = configuration;
        }

        public IDictionary<string, HttpControllerDescriptor> GetControllerMapping()
        {
            return PreviousSelector?.GetControllerMapping();
        }

        public HttpControllerDescriptor SelectController(HttpRequestMessage request)
        {
            //returns all possible API Controllers
            var controllers = GetControllerMapping();
            //return the information about the route
            var routeData = request.GetRouteData();
            //get the controller name passed
            var controllerName = routeData.Values["controller"].ToString();
            string apiVersion = "1";
            //Custom Header Name to be check
            string customHeaderForVersion = "X-API-Version";

            if (request.Headers.Contains(customHeaderForVersion))
                apiVersion = request.Headers.GetValues(customHeaderForVersion).FirstOrDefault();

            switch (apiVersion)
            {
                case "2":
                    controllerName = $"{controllerName}V2";
                    break;
                default:
                    controllerName = $"{controllerName}V1";
                    break;
            }

            //check the value in controllers dictionary. TryGetValue is an efficient way to check the value existence
            if (controllers.TryGetValue(controllerName, out var controllerDescriptor))
                return controllerDescriptor;
            
            return null;
        }
    }
}