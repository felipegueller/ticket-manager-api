using AutoMapper;

namespace TicketManager.DTO.User;

public class UserProfile : Profile
{
    public UserProfile()
    {
        CreateMap<UserDto, Model.Models.User>()
            .ForMember(dest => dest.Id, opt => opt.Ignore())
            .ReverseMap();
    }

    public static IMapper GetMapper()
    {
        MapperConfiguration mapperConfiguration = new(config =>
        {
            config.AddProfile<UserProfile>();
        }, null);

        mapperConfiguration.AssertConfigurationIsValid();

        return mapperConfiguration.CreateMapper();
    }

    public static T ObterObjetoMapeado<T>(object objeto) where T : class
    {
        IMapper mapper = GetMapper();

        return mapper.Map<T>(objeto);
    }

    public static IConfigurationProvider ObterMapperConfiguration()
        => GetMapper().ConfigurationProvider;
}