using BordDirector.Alex.Agronik.Infra.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace BordDirector.Alex.Agronik.Infra.Models
{
    public class VehicleDTO
    {
        [SwaggerIgnore]
        public int Id { get; set; }
        public string Model { get; set; }
        public string Owner { get; set; }
        public short Year { get; set; }
        public string LicenseNumber { get; set; }
        public short Power { get; set; }
        public short TopSpeed { get; set; }
        public float UpTo100km_h { get; set; }
        public string Torque { get; set; }
        public float CO2Emissions { get; set; }
    }
}
