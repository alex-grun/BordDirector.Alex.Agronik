using AutoMapper;
using BordDirector.Alex.Agronik.DB;
using BordDirector.Alex.Agronik.DB.Tables;
using BordDirector.Alex.Agronik.Infra.Enums;
using BordDirector.Alex.Agronik.Infra.Interfaces;
using BordDirector.Alex.Agronik.Infra.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BordDirector.Alex.Agronik.Services.Reports
{
    public class ReportServices : BaseServices, IReportServices
    {
        private readonly CustomDBContext _CurrentDbContext;
        private readonly IMapper _MapperFromEntity;
        private readonly IMapper _MapperToEntity;

        public ReportServices()
        {
            _CurrentDbContext = new CustomDBContext();
            _MapperToEntity = CreateMapper<ReportDTO, Report>();
            _MapperFromEntity = CreateMapper<Report, ReportDTO>();
        }

        public async Task<List<ReportDTO>> GetBy(SelectByEnum val)
        {
            throw new NotImplementedException();
        }

        public async Task<List<ReportDTO>> GetMostActive()
        {
            throw new NotImplementedException();
        }

        public async Task Write(ReportDTO report)
        {
            await Task.Run(() => {
                var item = _MapperToEntity.Map<ReportDTO, Report>(report);
                _CurrentDbContext.Reports.Add(item);
            });
        }
    }
}
