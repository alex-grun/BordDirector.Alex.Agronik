using System;
using System.Collections.Generic;
using System.Text;

namespace BordDirector.Alex.Agronik.Infra.Models
{
    public class ReportDTO
    {
        public int VehicleId { get; set; }
        public string RequestMethod { get; set; }
        public DateTime RequestTime { get; set; }
    }
}
