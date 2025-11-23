namespace SampleCleanArchitecture.Application.ManagerService
{
    public class ServiceManager : IServiceManager
    {
        private readonly Lazy<IAuthenticationService> _authenticationService;

       
        private readonly Lazy<ICompanyService> _companyService;

        private readonly Lazy<ICustomerService> _customerService;
        

        public ServiceManager(IRepositoryManager repositoryManager,
            ILoggerManager logger,
            UserManager<ApplicationUser> userManager,
            IOptions<JwtConfiguration> configuration,
            IMapper mapper, ICustomerLinks customerLinks
            )
        {

            _authenticationService = new Lazy<IAuthenticationService>(() =>
                new AuthenticationService(logger, mapper, userManager, configuration));
           
            _customerService = new Lazy<ICustomerService>(() =>
                new CustomerService(repositoryManager, logger, mapper, customerLinks));
          
        }
        
        public IAuthenticationService AuthenticationService => _authenticationService.Value;

        public ICompanyService CompanyService => _companyService.Value;

        public ICustomerService CustomerService => _customerService.Value;
       
        
    }
}
