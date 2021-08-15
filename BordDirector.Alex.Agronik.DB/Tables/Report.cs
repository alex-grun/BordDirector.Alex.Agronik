using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace BordDirector.Alex.Agronik.DB.Tables
{
    public class Report
    {
        public int VehicleId { get; set; }
        public string RequestMethod { get; set; }
        public DateTime RequestTime { get; set; }
    }
}
