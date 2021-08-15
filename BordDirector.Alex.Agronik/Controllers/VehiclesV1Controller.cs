using BordDirector.Alex.Agronik.Infra.Interfaces;
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
    [ApiVersion("1.0")]
    [RoutePrefix("api/v{version:apiVersion}/vehicles")]
    [CustomAuthorize]
    public class VehiclesV1Controller : ApiController
    {
        private readonly IVehicleServices _VehicleServices;

        public VehiclesV1Controller(IVehicleServices vehicleServices)
        {
            this._VehicleServices = vehicleServices;
        }

        // GET api/vehicles
        [Route]
        public async Task<IEnumerable<VehicleDTO>> Get()
        {
            var result = await _VehicleServices.GetAll();
            return result;
        }

        // POST api/vehicles
        [Route]
        public async Task Post([FromBody] VehicleDTO vehicle)
        {
            await _VehicleServices.Create(vehicle);
        }

        // PUT api/values
        [Route]
        public async Task Put([FromBody] List<VehicleDTO> values)
        {
            await _VehicleServices.Update(values);
        }

        // DELETE api/vehicles
        [Route]
        public async Task Delete([FromBody]int[] ids)
        {
            await _VehicleServices.Delete(ids);
        }
    }
}
