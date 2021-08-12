using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Dispatcher;

namespace BordDirector.Alex.Agronik.Utilities
{
    public class CustomHttpControllerSelector : IHttpControllerSelector
    {
        public IDictionary<string, HttpControllerDescriptor> GetControllerMapping()
        {
            throw new NotImplementedException();
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
            {
                apiVersion = request.Headers.GetValues(customHeaderForVersion).FirstOrDefault();
            }

            if (apiVersion == "1")
            {
                controllerName = controllerName + "V1";
            }
            else
            {
                controllerName = controllerName + "V2";
            }
            //
            HttpControllerDescriptor controllerDescriptor;
            //check the value in controllers dictionary. TryGetValue is an efficient way to check the value existence
            if (controllers.TryGetValue(controllerName, out controllerDescriptor))
            {
                return controllerDescriptor;
            }
            return null;
        }
    }
}