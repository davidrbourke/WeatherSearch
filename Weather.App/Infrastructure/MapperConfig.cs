using AutoMapper;

namespace Weather.App.Infrastructure
{
    public static class MapperConfig
    {
        public static void MapIntialise()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<Infrastructure.Models.External.Atmosphere, Domain.Atmosphere>();
                cfg.CreateMap<Infrastructure.Models.External.Astronomy, Domain.Astronomy>();
                cfg.CreateMap<Infrastructure.Models.External.Condition, Domain.Condition>();
                cfg.CreateMap<Infrastructure.Models.External.Image, Domain.Image>();
                cfg.CreateMap<Infrastructure.Models.External.Location, Domain.Location>();
                cfg.CreateMap<Infrastructure.Models.External.Units, Domain.Units>();
                cfg.CreateMap<Infrastructure.Models.External.Wind, Domain.Wind>();
             });
        }
    }
}
