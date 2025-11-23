
using Microsoft.Extensions.DependencyInjection;
using SampleCleanArchitecture.Dto.Admin.Company;
using SampleCleanArchitecture.Dto.Application.Customer;

namespace SampleCleanArchitecture.Dto;

public static class DependencyInjection
{
    public static IServiceCollection AddDtoValidators(this IServiceCollection services)
    {
        // services.AddFluentValidationAutoValidation();
        
        services.AddScoped<IValidator<CompanyForManipulationDto>, CompanyValidator>();
        services.AddScoped<IValidator<CustomerForManipulationDto>, CustomerForManipulationValidator>();
       
        return services;
    }
   

}