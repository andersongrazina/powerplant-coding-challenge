using AutoMapper;
using PowerPlant.Application.DTO;
using Models = PowerPlant.Domain.Models;

namespace PowerPlant.Application.AutoMapper
{
    public class DTOToDomainMappingProfile : Profile
    {
        public DTOToDomainMappingProfile()
        {
            CreateMap<PowerPlantDTO, Models.PowerPlant>()
                .ForMember(o => o.Name, m => m.MapFrom(s => s.Name))
                .ForMember(o => o.Efficiency, m => m.MapFrom(s => s.Efficiency))
                .ForMember(o => o.MinimumPowerAmount, m => m.MapFrom(s => s.Pmin))
                .ForMember(o => o.MaximumPowerAmount, m => m.MapFrom(s => s.Pmax));

            CreateMap<PowerPlantDTO, Models.GasfiredPlant>()
                .IncludeBase<PowerPlantDTO, Models.PowerPlant>();

            CreateMap<PowerPlantDTO, Models.TurboJetPlant>()
                .IncludeBase<PowerPlantDTO, Models.PowerPlant>();

            CreateMap<PowerPlantDTO, Models.WindTurbinePlant>()
                .IncludeBase<PowerPlantDTO, Models.PowerPlant>();
        }
    }
}
