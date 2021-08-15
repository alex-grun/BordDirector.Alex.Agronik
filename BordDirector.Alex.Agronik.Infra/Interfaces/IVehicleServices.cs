using BordDirector.Alex.Agronik.Infra.Helpers;
using BordDirector.Alex.Agronik.Infra.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BordDirector.Alex.Agronik.Infra.Interfaces
{
    public interface IVehicleServices
    {
        Task<List<VehicleDTO>> GetAll(PaginationData paging); //, FilterData<VehicleDTO> filters)
        Task<int> Create(VehicleDTO vehicle);
        Task Update(List<VehicleDTO> vehicles);
        Task Delete(int[] ids);
    }
}
