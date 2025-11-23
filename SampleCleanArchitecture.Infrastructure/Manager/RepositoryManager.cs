using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using SampleCleanArchitecture.Infrastructure.RepositoryContract;


namespace SampleCleanArchitecture.Infrastructure.Manager
{
    public class RepositoryManager : IRepositoryManager
    {
        

        private readonly ApplicationDbContext _applicationDbContext;
        private readonly IDateTimeService _iDateTimeService;
        private readonly Lazy<ICompanyRepository> _companyRepository;
        
        
        private readonly Lazy<ICustomerRepository> _customerRepository;
        

        protected readonly IHttpContextAccessor _httpContextAccessor;
        public  string userId = string.Empty;
        public RepositoryManager(ApplicationDbContext applicationDbContext, IHttpContextAccessor httpContextAccessor, IDateTimeService idateTimeService)
        {
            _httpContextAccessor = httpContextAccessor;
            _iDateTimeService = idateTimeService;
            _applicationDbContext = applicationDbContext;
           
            _companyRepository = new Lazy<ICompanyRepository>(() => new CompanyRepository(applicationDbContext));
            
            _customerRepository = new Lazy<ICustomerRepository>(() => new CustomerRepository(applicationDbContext));
         

        }
        public ICompanyRepository Company => _companyRepository.Value;

        public ICustomerRepository Customer => _customerRepository.Value;
        
        public async Task SaveAsync()
        {
            DisplayStates(_applicationDbContext.ChangeTracker.Entries());
            await _applicationDbContext.SaveChangesAsync();
        }

        private void DisplayStates(IEnumerable<EntityEntry> entries)
        {
            var userId = _httpContextAccessor?.HttpContext?.User?.FindFirstValue(ClaimTypes.NameIdentifier) ?? "System";

            foreach (var entry in entries)
            {
                if (entry.Entity is BaseEntities baseEntity)
                {
                    switch (entry.State)
                    {
                        case EntityState.Added:
                            baseEntity.CreatedBy = userId;
                            baseEntity.CreatedDate = _iDateTimeService.GetDate();
                            baseEntity.ModifiedBy = userId;
                            baseEntity.ModifiedDate = _iDateTimeService.GetDate();
                            baseEntity.IsActive = true;
                            baseEntity.IsDeleted = false;
                            break;

                        case EntityState.Modified:
                            baseEntity.ModifiedBy = userId;
                            baseEntity.ModifiedDate = _iDateTimeService.GetDate();
                            break;
                    }

                    Console.WriteLine($"Entity {entry.Entity.GetType().Name} (Id={baseEntity.Id}) state: {entry.State}");
                }
            }
        }

    }
}
