using Autofac;
using BordDirector.Alex.Agronik.Infra.Interfaces;
using BordDirector.Alex.Agronik.Services.Vehicles;
using System;
using System.Collections.Generic;
using System.Text;

namespace BordDirector.Alex.Agronik.Services
{
    public class SevicesModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<VehicleServices>().As<IVehicleServices>().SingleInstance();
        }
    }
}
