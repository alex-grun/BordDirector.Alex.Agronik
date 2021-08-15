using BordDirector.Alex.Agronik.Infra.Helpers;
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
        private readonly IReportServices _ReportServices;

        public VehiclesV1Controller(IVehicleServices vehicleServices, IReportServices reportServices)
        {
            this._VehicleServices = vehicleServices;
            this._ReportServices = reportServices;
        }

        // GET api/vehicles
        [Route]
        public async Task<IEnumerable<VehicleDTO>> Get([FromUri] PaginationData paging) //, FilterData<VehicleDTO> filters)
        {
            if (paging == null)
                paging = new PaginationData { ItemsOnPage = 10, PageNumber = 1 };
            if (paging.ItemsOnPage < 10)
                paging.ItemsOnPage = 10;
            if (paging.PageNumber < 1)
                paging.PageNumber = 1;
            var result = await _VehicleServices.GetAll(paging); //, filters);
            await _ReportServices.Write(new ReportDTO { VehicleId = -1, RequestMethod = "GET", RequestTime = DateTime.Now });
            return result;
        }

        // POST api/vehicles
        [Route]
        public async Task Post([FromBody] VehicleDTO vehicle)
        {
            var id = await _VehicleServices.Create(vehicle);
            await _ReportServices.Write(new ReportDTO { VehicleId = id, RequestMethod = "POST", RequestTime = DateTime.Now });
        }

        // PUT api/values
        [Route]
        public async Task Put([FromBody] List<VehicleDTO> values)
        {
            await _VehicleServices.Update(values);
            foreach (var vehicle in values)
            {
                await _ReportServices.Write(new ReportDTO { VehicleId = vehicle.Id, RequestMethod = "PUT", RequestTime = DateTime.Now });
            }
        }

        // DELETE api/vehicles
        [Route]
        public async Task Delete([FromBody]int[] ids)
        {
            await _VehicleServices.Delete(ids);
            foreach (var id in ids)
            {
                await _ReportServices.Write(new ReportDTO { VehicleId = id, RequestMethod = "DELETE", RequestTime = DateTime.Now });
            }
        }
    }
}
