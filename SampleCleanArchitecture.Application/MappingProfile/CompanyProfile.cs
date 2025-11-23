namespace SampleCleanArchitecture.Application.MappingProfile;

public class CompanyProfile : Profile
{
    public CompanyProfile()
    {
       
        // Company
        CreateMap<Company, CompanyDto>();
        CreateMap<Company, CompanyForCreationDto>().ReverseMap();
        CreateMap<CompanyForUpdateDto, Company>();


    }
}