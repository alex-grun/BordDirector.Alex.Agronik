using BordDirector.Alex.Agronik.Infra.Enums;
using BordDirector.Alex.Agronik.Infra.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BordDirector.Alex.Agronik.Infra.Interfaces
{
    public interface IReportServices
    {
        Task<List<ReportDTO>> GetBy(SelectByEnum vehicleId);
        Task<List<ReportDTO>> GetMostActive();
        Task Write(ReportDTO item);
    }
}
