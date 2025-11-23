namespace SampleCleanArchitecture.Application.MappingProfile;

public class ApplicationUserProfile : Profile
{
    public ApplicationUserProfile()
    {
        CreateMap<ApplicationUser, UserForRegistrationDto>().ReverseMap();


    }
}