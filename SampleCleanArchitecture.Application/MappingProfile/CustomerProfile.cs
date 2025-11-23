namespace SampleCleanArchitecture.Application.MappingProfile;

public class CustomerProfile : Profile
{
    public CustomerProfile()
    {
       
        // Customer
        CreateMap<Customer, CustomerDto>();
        CreateMap<Customer, CustomerForCreationDto>().ReverseMap();
        CreateMap<CustomerForUpdateDto, Customer>();
        CreateMap<CustomerForUpdateDto, Customer>().ReverseMap();

        CreateMap<CustomerType, CustomerTypeDto>();

    }
}