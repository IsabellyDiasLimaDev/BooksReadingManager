using BookReadingManager.Application.DTOs.Auth;

namespace BookReadingManager.Application.Interfaces
{
    public interface IAuthService
    {
        Task<UserTokenDto?> AuthenticateAsync(LoginUserDto dto);
        Task<bool> RegisterAsync(RegisterUserDto dto);
    }
}
