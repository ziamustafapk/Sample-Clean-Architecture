using Microsoft.AspNetCore.Identity;

namespace SampleCleanArchitecture.Domain.Models.Identity;

public class ApplicationUser : IdentityUser
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public Guid RefCompanyId { get; set; }
    public string? RefreshToken { get; set; }
    public DateTime RefreshTokenExpiryTime { get; set; }


}