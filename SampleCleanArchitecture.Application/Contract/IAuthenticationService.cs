using System.Security.Claims;

namespace SampleCleanArchitecture.Application.Contract
{
    public interface IAuthenticationService
    {
        Task<IdentityResult> RegisterUser(UserForRegistrationDto userForRegistration);
        Task<bool> ValidateUser(UserForAuthenticationDto userForAuth);
        Task<TokenDto> CreateToken(bool populateExp);

        Task<TokenDto> RefreshToken(TokenDto tokenDto);
        ClaimsPrincipal GetPrincipalFromExpiredToken(string token);
    }
}
