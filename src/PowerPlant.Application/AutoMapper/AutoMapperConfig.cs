using AutoMapper;

namespace PowerPlant.Application.AutoMapper
{
    public class AutoMapperConfig
    {
        public static MapperConfiguration RegisterMappings()
        {
            return new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new DTOToDomainMappingProfile());
            });
        }
    }
}
