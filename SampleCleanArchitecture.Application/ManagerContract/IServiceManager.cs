namespace SampleCleanArchitecture.Application.ManagerContract
{
    public interface IServiceManager
    {

        IAuthenticationService AuthenticationService { get; }

        ICompanyService CompanyService { get; }
        ICustomerService CustomerService { get; }
        
       
        
    }
}
