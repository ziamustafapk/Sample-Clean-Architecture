using SampleCleanArchitecture.Infrastructure.RepositoryContract;

namespace SampleCleanArchitecture.Infrastructure.Repositories
{
    public class CompanyRepository : RepositoryBase<Company>, ICompanyRepository
    {
        public CompanyRepository(ApplicationDbContext repositoryContext) 
            : base(repositoryContext)
        {
        }

        public async Task<IEnumerable<Company>> GetAllAsync(bool trackChanges)
        {

            var result = await FindAll(trackChanges).ToListAsync();
            return result;


        }

       public async Task<Company> GetCompanyByIdAsync(Guid companyId, bool trackChanges)
        {

            return await FindByCondition(c => c.Id.Equals(companyId), trackChanges).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Company>> GetByIdsAsync(IEnumerable<Guid> ids, bool trackChanges) =>
            await FindByCondition(x => ids.Contains(x.Id), trackChanges)
                .ToListAsync();

    }
}
