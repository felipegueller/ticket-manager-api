using AutoMapper;
using Microsoft.Extensions.Logging.Abstractions;

namespace TicketManager.DTO.Authentication;

public class AuthenticationProfile : Profile
{
    public AuthenticationProfile()
    {
        CreateMap<RegisterDto, Model.ModelsNotMapped.Authentication.Register>()
            .ReverseMap();
    }

    public static IMapper GetMapper()
    {
        MapperConfiguration mapperConfiguration = new(config =>
        {
            config.AddProfile<AuthenticationProfile>();
        }, NullLoggerFactory.Instance);

        mapperConfiguration.AssertConfigurationIsValid();

        return mapperConfiguration.CreateMapper();
    }

    public static T GetMappedObject<T>(object objeto) where T : class
    {
        IMapper mapper = GetMapper();

        return mapper.Map<T>(objeto);
    }

    public static IConfigurationProvider GetMapperConfiguration()
        => GetMapper().ConfigurationProvider;
}