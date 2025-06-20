using BookReadingManager.API.Controllers.Base;
using BookReadingManager.Application.DTOs.Auth;
using BookReadingManager.Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookReadingManager.API.Controllers
{
    [Route("api/[controller]")]
    public class AuthController : MainController
    {
        private readonly IAuthService _authService;
        public AuthController(INotificador notificador, IAuthService authService) : base(notificador)
        {
            _authService = authService;
        }

        [HttpPost("register")]
        public async Task<ActionResult> Register(RegisterUserDto dto)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            var result = await _authService.RegisterAsync(dto);
            if (!result)
            {
                NotificarErro("Usuário já registrado.");
                return CustomResponse();
            }

            return CustomResponse("Usuário registrado com sucesso.");
        }

        [HttpPost("login")]
        public async Task<ActionResult> Login(LoginUserDto dto)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            var token = await _authService.AuthenticateAsync(dto);
            if (token == null)
            {
                NotificarErro("Usuário ou senha inválidos.");
                return CustomResponse();
            }

            return CustomResponse(token);
        }
    }
}
