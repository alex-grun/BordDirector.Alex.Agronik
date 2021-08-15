using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace BordDirector.Alex.Agronik.Services
{
    public class BaseServices
    {
        protected IMapper CreateMapper<T, S>()
        {
            var configFrom = new MapperConfiguration(cfg => {
                cfg.CreateMap<T, S>();
            });
            return configFrom.CreateMapper();
        }
    }
}
