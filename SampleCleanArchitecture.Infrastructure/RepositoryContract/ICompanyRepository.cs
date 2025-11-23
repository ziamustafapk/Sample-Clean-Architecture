namespace SampleCleanArchitecture.Infrastructure.RepositoryContract
{
    public interface ICompanyRepository : IRepositoryBase<Company>
    {
        Task<IEnumerable<Company>> GetAllAsync(bool trackChanges);
        Task<Company> GetCompanyByIdAsync(Guid companyId, bool trackChanges);
        Task<IEnumerable<Company>> GetByIdsAsync(IEnumerable<Guid> ids, bool trackChanges);
        public void CreateCompany(Company company) => Create(company);
    }
}
