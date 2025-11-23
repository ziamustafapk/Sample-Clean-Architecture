using Microsoft.AspNetCore.Http;


namespace SampleCleanArchitecture.Application.Contract
{
    public interface ICustomerLinks
    {
        LinkResponse TryGenerateLinks(IEnumerable<CustomerDto> customersDto,
            string fields, Guid companyId, HttpContext httpContext);
    }



}
