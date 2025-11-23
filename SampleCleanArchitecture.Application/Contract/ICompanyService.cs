namespace SampleCleanArchitecture.Application.Contract
{
    public interface ICompanyService
    {
        Task<ApiBaseResponse> GetAllCompaniesAsync(bool trackChanges);
        Task<ApiBaseResponse> GetCompanyAsync(Guid companyId, bool trackChanges);
        Task<CompanyDto> CreateCompany(CompanyForCreationDto createCompanyDto);

        Task UpdateCompanyAsync(Guid companyId,
            CompanyForUpdateDto companyForUpdate, bool trackChanges);

        Task<(IEnumerable<CompanyDto> companies, string ids)> CreateCompanyCollectionAsync
            (IEnumerable<CompanyForCreationDto> companyCollection);

        Task<IEnumerable<CompanyDto>> GetByIdsAsync(IEnumerable<Guid> ids, bool trackChanges);
    }
}
