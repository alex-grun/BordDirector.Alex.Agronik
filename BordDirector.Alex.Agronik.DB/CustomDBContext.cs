using BordDirector.Alex.Agronik.DB.Tables;
using BordDirector.Alex.Agronik.Infra.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace BordDirector.Alex.Agronik.DB
{
    public class CustomDBContext
    {
        public List<Vehicle> Vehicles { get; }
        public int VehiclesIndex { get; set; }

        public CustomDBContext()
        {
            Vehicles = new List<Vehicle>();
        }
    }
}
