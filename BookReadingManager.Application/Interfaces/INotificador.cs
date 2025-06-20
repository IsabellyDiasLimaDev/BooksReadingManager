using BookReadingManager.Domain.Notificacoes;

namespace BookReadingManager.Application.Interfaces
{
    public interface INotificador
    {
        void Handle(Notificacao notificacao);
        List<Notificacao> ObterNotificacoes();
        bool TemNotificacoes();
    }

}
