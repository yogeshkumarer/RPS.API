using AutoMapper;

namespace RPS.Api.Mappers
{
    public class MapperConfig
    {
        public static IMapper Mapper { get; set; }

        public static IMapper CreateMapper()
        {
            if (Mapper == null)
            {
                Mapper = Configure().CreateMapper();
            }

            return Mapper;
        }

        public static MapperConfiguration Configure()
        {
            var configuration = new MapperConfiguration(config =>
            {
            });

            configuration.AssertConfigurationIsValid();

            return configuration;
        }
    }
}
