﻿using Autofac;
using Autofac.Integration.WebApi;
using BordDirector.Alex.Agronik.Infra;
using Swashbuckle.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace BordDirector.Alex.Agronik
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            //AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            //BundleConfig.RegisterBundles(BundleTable.Bundles);
            var builder = new ContainerBuilder();
            Container.RegisterModules(builder, new List<Autofac.Module> { new BordDirector.Alex.Agronik.Services.SevicesModule() });
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());
            var container = builder.Build();
            Container.SetContainer(container);
            GlobalConfiguration.Configuration.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        }
    }
}
