namespace SampleCleanArchitecture.Application.Service
{
    internal sealed class CompanyService : ICompanyService
    {
        private readonly IRepositoryManager _repository;
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;

        public CompanyService(IRepositoryManager repository, ILoggerManager logger, IMapper mapper)
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task<ApiBaseResponse> GetAllCompaniesAsync(bool trackChanges)
        {
            var companies = await _repository.Company.GetAllAsync(trackChanges);
            if (companies is null)
                throw new EntityNotFoundException(Guid.NewGuid(), "Companies");

            var companiesDto = _mapper.Map<IEnumerable<CompanyDto>>(companies);

            return new ApiOkResponse<IEnumerable<CompanyDto>>(companiesDto);
        }

        public async Task<ApiBaseResponse> GetCompanyAsync(Guid id, bool trackChanges)
        {
            var company = await GetCompanyAndCheckIfItExists(id, trackChanges);

            var companyDto = _mapper.Map<CompanyDto>(company);
            return new ApiOkResponse<CompanyDto>(companyDto);
        }

        public async Task<IEnumerable<CompanyDto>> GetByIdsAsync(IEnumerable<Guid> ids, bool trackChanges)
        {
            if (ids is null)
                throw new MessageNotFoundException("ids not Found");

            var companyEntities = await _repository.Company.GetByIdsAsync(ids, trackChanges);
            if (ids.Count() != companyEntities.Count())
                throw new MessageNotFoundException("Collection ids not Found");

            var companiesToReturn = _mapper.Map<IEnumerable<CompanyDto>>(companyEntities);

            return companiesToReturn;
        }

        public async Task<(IEnumerable<CompanyDto> companies, string ids)> CreateCompanyCollectionAsync
            (IEnumerable<CompanyForCreationDto> companyCollection)
        {
            if (companyCollection is null)
                throw new MessageNotFoundException("Collection ids not Found");

            var companyEntities = _mapper.Map<IEnumerable<Company>>(companyCollection);
            foreach (var company in companyEntities)
            {
                _repository.Company.CreateCompany(company);
            }

            await _repository.SaveAsync();

            var companyCollectionToReturn = _mapper.Map<IEnumerable<CompanyDto>>(companyEntities);
            var ids = string.Join(",", companyCollectionToReturn.Select(c => c.Id));

            return (companies: companyCollectionToReturn, ids: ids);
        }


        public async Task<CompanyDto> CreateCompany(CompanyForCreationDto createCompanyDto)
        {
            if (createCompanyDto.ParentCompanyId != null)
            {
                await CheckParentCompany((Guid)createCompanyDto.ParentCompanyId, false);
            }
               
            var companyEntity = _mapper.Map<Company>(createCompanyDto);
            companyEntity.CompanyCode = await GenerateCompanyCode(createCompanyDto.ParentCompanyId, false);
              _repository.Company.Create(companyEntity);
             await _repository.SaveAsync();

             var companyToReturn = _mapper.Map<CompanyDto>(companyEntity);
             return companyToReturn;
        }
        public async Task UpdateCompanyAsync(Guid companyId,
            CompanyForUpdateDto companyForUpdate, bool trackChanges)
        {
            var company = await GetCompanyAndCheckIfItExists(companyId, trackChanges);

            _mapper.Map(companyForUpdate, company);
            await _repository.SaveAsync();
        }
        private async Task<Company> GetCompanyAndCheckIfItExists(Guid id, bool trackChanges)
        {
            var company = await _repository.Company.GetCompanyByIdAsync(id, trackChanges);
            if (company is null)
                throw new EntityNotFoundException(id, "Company");

            return company;
        }
        private async Task CheckParentCompany(Guid parentCompanyId, bool trackChanges)
        {
            var company = await _repository.Company.FindByCondition(c => c.Id.Equals(parentCompanyId),trackChanges).FirstOrDefaultAsync();
            if (company == null)
                throw new EntityNotFoundException(parentCompanyId, "Parent Company");
        }
        private async Task<string> GenerateCompanyCode(Guid? parentCompanyId, bool trackChanges)
        {
            string companyCode = "001";
            int companyCount = 1;
            if (parentCompanyId != null)
            {
                var parentCompany = await _repository.Company.FindByCondition(c => c.Id.Equals(parentCompanyId), trackChanges).FirstOrDefaultAsync();

                companyCount = await _repository.Company
                    .FindByCondition(c => c.ParentCompanyId.Value.Equals(parentCompanyId), false).CountAsync();
                if(companyCount > 0)
                     return (parentCompany.CompanyCode + "-" + (companyCount +1).ToString().PadLeft(3, '0'));

                return parentCompany.CompanyCode + "-001";
            }
            else
            {
                companyCount = await _repository.Company
                    .FindByCondition(c => c.ParentCompanyId == null, false).CountAsync();
                if (companyCount > 0)
                    return (companyCount + 1).ToString().PadLeft(3, '0');
            }
            return companyCode;
        }
    }
}
