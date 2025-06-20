using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using BookReadingManager.Application.DTOs.Auth;
using BookReadingManager.Application.Interfaces;
using BookReadingManager.Domain.Entities;
using BookReadingManager.Domain.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Identity;

public class AuthService : IAuthService
{
    private readonly IUserRepository _userRepository;
    private readonly IConfiguration _configuration;
    private readonly IPasswordHasher<User> _passwordHasher;

    public AuthService(IUserRepository userRepository, IConfiguration configuration)
    {
        _userRepository = userRepository;
        _configuration = configuration;
        _passwordHasher = new PasswordHasher<User>();
    }

    public async Task<bool> RegisterAsync(RegisterUserDto dto)
    {
        var existingUser = await _userRepository.GetByEmailAsync(dto.Email);
        if (existingUser != null) return false;

        var user = new User
        {
            Name = dto.Name,
            Email = dto.Email
        };

        user.PasswordHash = _passwordHasher.HashPassword(user, dto.Password);

        await _userRepository.AddAsync(user);
        return true;
    }

    public async Task<UserTokenDto?> AuthenticateAsync(LoginUserDto dto)
    {
        var user = await _userRepository.GetByEmailAsync(dto.Email);
        if (user == null) return null;

        var result = _passwordHasher.VerifyHashedPassword(user, user.PasswordHash, dto.Password);
        if (result == PasswordVerificationResult.Failed) return null;

        return GenerateToken(user);
    }

    private UserTokenDto GenerateToken(User user)
    {
        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]!));
        var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var claims = new[]
        {
            new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
            new Claim(ClaimTypes.Email, user.Email),
            new Claim(ClaimTypes.Name, user.Name)
        };

        var token = new JwtSecurityToken(
            issuer: _configuration["Jwt:Issuer"],
            audience: _configuration["Jwt:Audience"],
            claims: claims,
            expires: DateTime.UtcNow.AddHours(1),
            signingCredentials: credentials
        );

        return new UserTokenDto
        {
            Token = new JwtSecurityTokenHandler().WriteToken(token),
            Expiration = token.ValidTo
        };
    }
}