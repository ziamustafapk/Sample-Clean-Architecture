namespace SampleCleanArchitecture.Application.Contract;

public interface ICustomerService
{
    Task<(LinkResponse linkResponse, MetaData metaData)> GetAllCustomerByCompanyAsync(Guid companyId,
        LinkParameters linkParameters, bool trackChanges);
   Task<ApiBaseResponse> GetCustomerByIdAsync(Guid companyId, Guid customerId, bool trackChanges);

    Task<CustomerDto> CreateCustomerForCompanyAsync(Guid companyId, CustomerForCreationDto customerForCreationDto,
        bool trackChanges);

    Task UpdateCustomerForCompanyAsync(Guid companyId, Guid id, CustomerForUpdateDto customerForUpdateDto,
        bool compTrackChanges, bool cusTrackChanges);

    Task DeleteCustomerForCompanyAsync(Guid companyId, Guid id, bool trackChanges);
    Task<(CustomerForUpdateDto customerToPatch, Customer customerEntity)> GetCustomerForPatchAsync
        (Guid companyId, Guid id, bool compTrackChanges, bool customerTrackChanges);

    Task SaveChangesForPatchAsync(CustomerForUpdateDto customerToPatch, Customer customerEntity);
}