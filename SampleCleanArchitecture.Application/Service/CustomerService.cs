namespace SampleCleanArchitecture.Application.Service;

internal sealed class CustomerService : ICustomerService
{
    private readonly IRepositoryManager _repository;
    private readonly ILoggerManager _logger;
    private readonly IMapper _mapper;
    //private readonly IDataShaper<CustomerDto> _dataShaper;
    private readonly ICustomerLinks _customerLinks;


    public CustomerService(IRepositoryManager repository, 
        ILoggerManager logger, IMapper mapper, ICustomerLinks customerLinks)
    {
        _repository = repository;
        _logger = logger;
        _mapper = mapper;
        _customerLinks = customerLinks;

    }
    
    public async Task<(LinkResponse linkResponse, MetaData metaData)> GetAllCustomerByCompanyAsync(Guid companyId, LinkParameters linkParameters, bool trackChanges)
    {
        await CheckIfCompanyExists(companyId, trackChanges);

        var customersWithMetaData = await _repository.Customer
            .GetCustomersByCompanyAsync( companyId, linkParameters.CustomerParameters, trackChanges);

        var customerDto = _mapper.Map<IEnumerable<CustomerDto>>(customersWithMetaData);
        var links = _customerLinks.TryGenerateLinks(customerDto, linkParameters.CustomerParameters.Fields, companyId,
            linkParameters.Context);
        return (linkResponse: links, metaData: customersWithMetaData.MetaData);
    }

    public async Task<ApiBaseResponse> GetCustomerByIdAsync(Guid companyId, Guid customerId, bool trackChanges)
    {
        await CheckIfCompanyExists(companyId, trackChanges);

        var customer = await GetCustomerForCompanyAndCheckIfExists(customerId, trackChanges);

        var customerDto = _mapper.Map<CustomerDto>(customer);
        return new ApiOkResponse<CustomerDto>(customerDto);
        
    }

    public async Task<CustomerDto> CreateCustomerForCompanyAsync(Guid companyId, CustomerForCreationDto customerForCreationDto, bool trackChanges)
    {
        using var scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled);
            await CheckIfCompanyExists(companyId, trackChanges);

            var customerEntity = _mapper.Map<Customer>(customerForCreationDto);
            customerEntity.RefCompanyId = companyId;
             _repository.Customer.Create(customerEntity);
            await _repository.SaveAsync();

        scope.Complete();

        var customerToReturn = _mapper.Map<CustomerDto>(customerEntity);
        return customerToReturn;
    }

    public async Task UpdateCustomerForCompanyAsync(Guid companyId, Guid id, CustomerForUpdateDto customerForUpdateDto, bool compTrackChanges, bool cusTrackChanges)
    {

        await CheckIfCompanyExists(companyId, compTrackChanges);
        var customerDb = await GetCustomerForCompanyAndCheckIfExists(id, cusTrackChanges);

        _mapper.Map( customerForUpdateDto, customerDb);
        
        await _repository.SaveAsync();

      
    }
    public async Task DeleteCustomerForCompanyAsync(Guid companyId, Guid id, bool trackChanges)
    {
        await CheckIfCompanyExists(companyId, trackChanges);
        var customerDb = await GetCustomerForCompanyAndCheckIfExists(id, trackChanges);
        customerDb.IsDeleted = true;
        
        await _repository.SaveAsync();
    }
    public async Task<(CustomerForUpdateDto customerToPatch, Customer customerEntity)> GetCustomerForPatchAsync
        (Guid companyId, Guid id, bool compTrackChanges, bool customerTrackChanges)
    {
        await CheckIfCompanyExists(companyId, compTrackChanges);

        var customerDb = await GetCustomerForCompanyAndCheckIfExists(id, customerTrackChanges);

        var customerToPatch = _mapper.Map<CustomerForUpdateDto>(customerDb);

        return (customerToPatch: customerToPatch, customerEntity: customerDb);
    }

    public async Task SaveChangesForPatchAsync(CustomerForUpdateDto customerToPatch, Customer customerEntity)
    {
        _mapper.Map(customerToPatch, customerEntity);
        await _repository.SaveAsync();
    }
    private async Task CheckIfCompanyExists(Guid companyId, bool trackChanges)
    {
        var company = await _repository.Company.GetCompanyByIdAsync(companyId, trackChanges);
        if (company is null)
            throw new EntityNotFoundException(companyId, "Company");
    }

    private async Task<Customer> GetCustomerForCompanyAndCheckIfExists(Guid id, bool trackChanges)
    {
        var customer = await _repository.Customer.FindByCondition(c =>c.Id.Equals(id), trackChanges).FirstOrDefaultAsync();
        if (customer is null)
            throw new EntityNotFoundException(id, "Customer");
        return customer;
    }

}
