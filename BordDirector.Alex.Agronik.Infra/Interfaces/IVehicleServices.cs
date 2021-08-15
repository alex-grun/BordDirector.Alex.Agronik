using BordDirector.Alex.Agronik.Infra.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BordDirector.Alex.Agronik.Infra.Interfaces
{
    public interface IVehicleServices
    {
        Task<List<VehicleDTO>> GetAll();
        Task Create(VehicleDTO vehicle);
        Task Update(List<VehicleDTO> vehicles);
        Task Delete(int[] ids);
    }
}
