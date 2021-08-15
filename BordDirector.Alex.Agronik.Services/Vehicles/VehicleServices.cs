using AutoMapper;
using BordDirector.Alex.Agronik.DB;
using BordDirector.Alex.Agronik.DB.Tables;
using BordDirector.Alex.Agronik.Infra.Helpers;
using BordDirector.Alex.Agronik.Infra.Interfaces;
using BordDirector.Alex.Agronik.Infra.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BordDirector.Alex.Agronik.Services.Vehicles
{
    public class VehicleServices : BaseServices, IVehicleServices
    {
        private readonly CustomDBContext _CurrentDbContext;
        private readonly IMapper _MapperFromEntity;
        private readonly IMapper _MapperToEntity;

        public VehicleServices()
        {
            _CurrentDbContext = new CustomDBContext();
            _MapperToEntity = CreateMapper<VehicleDTO, Vehicle>();
            _MapperFromEntity = CreateMapper<Vehicle, VehicleDTO>();
        }

        public async Task<int> Create(VehicleDTO vehicle)
        {
            return await Task.Run(() => {
                var item = _MapperToEntity.Map<VehicleDTO, Vehicle>(vehicle);
                item.Id = ++_CurrentDbContext.VehiclesIndex;
                _CurrentDbContext.Vehicles.Add(item);
                return item.Id;
            });
        }

        public async Task Delete(int[] ids)
        {
            await Task.Run(() => _CurrentDbContext.Vehicles.RemoveAll(x => ids.ToList().Contains(x.Id)));
        }

        public async Task<List<VehicleDTO>> GetAll(PaginationData paging) //, FilterData<VehicleDTO> filters)
        {
            var result = await Task.Run(() => _CurrentDbContext.Vehicles.Select(x => _MapperFromEntity.Map<Vehicle, VehicleDTO>(x)).Skip(paging.Skip).Take(paging.ItemsOnPage).ToList());
            return result;
        }

        public async Task Update(List<VehicleDTO> vehicles)
        {
            await Task.Run(() => { });
        }
    }
}
