namespace SampleCleanArchitecture.Infrastructure.RepositoryContract;

public interface ICustomerRepository : IRepositoryBase<Customer>
{
    
    Task<PagedList<Customer>> GetCustomersByCompanyAsync(Guid companyId,
        CustomerParameters customerParameters, bool trackChanges);
}