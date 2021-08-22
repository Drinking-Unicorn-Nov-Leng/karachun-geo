using AutoMapper;
using AutoMapper.EquivalencyExpression;
using karachun_geo.Data;
using karachun_geo.Data.Entity;
using System;
using System.Linq;

namespace karachun_geo.API.Configurations.AutoMapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            // CreateMap<ClassDTO, ClassEntity>();
        }
    }
}
