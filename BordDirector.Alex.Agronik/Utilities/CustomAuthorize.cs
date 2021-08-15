using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Controllers;


namespace BordDirector.Alex.Agronik.Utilities
{
    public class CustomAuthorize : AuthorizeAttribute
    {
        protected override bool IsAuthorized(HttpActionContext actionContext)
        {
            if (actionContext.Request.Headers.TryGetValues("X-ApiKey-Test", out var values))
                return values.Any(x => (bool)x?.Equals("Bord-Director-Alex-Agronik"));

            return false;
        }
    }
}