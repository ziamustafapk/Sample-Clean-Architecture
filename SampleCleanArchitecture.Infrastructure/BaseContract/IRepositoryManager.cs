using SampleCleanArchitecture.Infrastructure.RepositoryContract;

namespace SampleCleanArchitecture.Infrastructure.BaseContract
{
    public interface IRepositoryManager
    {
        ICompanyRepository Company { get; }
        ICustomerRepository Customer { get; }
       
        Task SaveAsync();
    }
}
