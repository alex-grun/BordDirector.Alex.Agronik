using BordDirector.Alex.Agronik.Infra.Models;
using BordDirector.Alex.Agronik.Utilities;
using Microsoft.Web.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace BordDirector.Alex.Agronik.Controllers
{
    [ApiVersion("2.0")]
    [RoutePrefix("api/v{version:apiVersion}/vehicles")]
    [CustomAuthorize]
    public class VehiclesV2Controller : ApiController
    {
        // GET api/vehicles
        [Route]
        public async Task<IEnumerable<VehicleDTO>> Get()
        {
            return null;
        }

        // POST api/vehicles
        [Route]
        public async Task Post([FromBody] VehicleDTO vehicle)
        {
        }

        // PUT api/values
        [Route]
        public async Task Put([FromBody] List<VehicleDTO> values)
        {
        }

        // DELETE api/vehicles
        [Route]
        public async Task Delete([FromBody] int[] ids)
        {
        }
    }
}
