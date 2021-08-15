using Autofac;
using System;
using System.Collections.Generic;
using System.Text;

namespace BordDirector.Alex.Agronik.Infra
{
    public static class Container
    {
        static IContainer container;

        public static void BuildNewContainer(List<Module> modules)
        {
            var builder = new ContainerBuilder();
            RegisterModules(builder, modules);
            container = builder.Build();
        }

        public static void RegisterModules(ContainerBuilder builder, List<Module> modules)
        {
            foreach (var item in modules)
            {
                builder.RegisterModule(item);
            }
        }

        public static void SetContainer(IContainer container)
        {
            Container.container = container;
        }

        public static T Resolve<T>()
        {
            return container.Resolve<T>();
        }
    }
}
