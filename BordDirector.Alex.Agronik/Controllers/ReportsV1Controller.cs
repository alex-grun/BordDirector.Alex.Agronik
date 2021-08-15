using BordDirector.Alex.Agronik.Infra.Enums;
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
    [RoutePrefix("api/v{version:apiVersion}/reports")]
    [CustomAuthorize]
    public class ReportsV1Controller : ApiController
    {
        private readonly IReportServices _ReportServices;

        public ReportsV1Controller(IReportServices reportServices)
        {
            this._ReportServices = reportServices;
        }

        [Route("byhour")]
        public async Task<List<ReportDTO>> GetByHour()
        {
            return await GetBy(SelectByEnum.HOURSE);
        }        
        
        [Route("byday")]
        public async Task<List<ReportDTO>> GetByDay()
        {
            return await GetBy(SelectByEnum.DAY);
        }        
        
        [Route("byweek")]
        public async Task<List<ReportDTO>> GetByWeek()
        {
            return await GetBy(SelectByEnum.WEEK);
        }        
        
        [Route("bymonth")]
        public async Task<List<ReportDTO>> GetByMonth()
        {
            return await GetBy(SelectByEnum.YEAR);
        }        
        
        [Route("byyear")]
        public async Task<List<ReportDTO>> GetByYear()
        {
            return await GetBy(SelectByEnum.YEAR);
        }

        [Route("mostactive")]
        public async Task<List<ReportDTO>> GetMostActive()
        {
            return await _ReportServices.GetMostActive();
        }

        private async Task<List<ReportDTO>> GetBy(SelectByEnum val)
        {
            return await _ReportServices.GetBy(val);
        }
    }
}