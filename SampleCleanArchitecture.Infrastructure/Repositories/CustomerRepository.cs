using SampleCleanArchitecture.Infrastructure.Repositories.Extensions;
using SampleCleanArchitecture.Infrastructure.RepositoryContract;

namespace SampleCleanArchitecture.Infrastructure.Repositories;

public class CustomerRepository : RepositoryBase<Customer>, ICustomerRepository
{
    public CustomerRepository(ApplicationDbContext repositoryContext) 
        : base(repositoryContext)
    {
    }


    public async Task<PagedList<Customer>> GetCustomersByCompanyAsync(
     Guid companyId,
     CustomerParameters customerParameters,
     bool trackChanges)
    {
        // Step 1: Build the base query
        var baseQuery = FindByCondition(c => !c.IsDeleted && c.RefCompanyId == companyId, trackChanges)
            .Search(customerParameters)
            .Include(c => c.RefCustomerType)
            .Sort(customerParameters.OrderBy);

        // Step 2: Get total count before pagination
        var count = await baseQuery.CountAsync();

        // Step 3: Apply pagination
        var customers = await baseQuery
            .Skip((customerParameters.PageNumber - 1) * customerParameters.PageSize)
            .Take(customerParameters.PageSize)
            .ToListAsync();

        // Step 4: Return paged result
        return new PagedList<Customer>(
            customers,
            count,
            customerParameters.PageNumber,
            customerParameters.PageSize
        );
    }

}