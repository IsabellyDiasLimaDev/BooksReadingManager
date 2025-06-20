using BookReadingManager.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace BookReadingManager.API.Controllers.Base
{
    [ApiController]
    public class MainController : ControllerBase
    {
        protected readonly INotificador _notificador;

        protected MainController(INotificador notificador)
        {
            _notificador = notificador;
        }
        protected bool OperacaoValida()
        {
            return !ModelState.Values.Any(v => v.Errors.Count > 0);
        }

        protected ActionResult CustomResponse(object? result = null)
        {
            if (OperacaoValida())
            {
                return Ok(result);
            }

            return BadRequest(new
            {
                success = false,
                errors = ModelState.Values.SelectMany(e => e.Errors).Select(e => e.ErrorMessage)
            });
        }

        protected void NotificarErroModelInvalida(ModelStateDictionary modelState)
        {
            var erros = modelState.Values.SelectMany(e => e.Errors);
            foreach (var erro in erros)
            {
                NotificarErro(erro.ErrorMessage);
            }
        }

        protected void NotificarErro(string mensagem)
        {
            ModelState.AddModelError(string.Empty, mensagem); // ou usar um Notificador customizado
        }
    }
}
