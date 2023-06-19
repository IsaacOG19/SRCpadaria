using RelacionamentoPadaria.Models;

namespace RelacionamentoPadaria.Services
{
    public interface IEmailService
    {
        void EnviarEmail(EmailMensagemModel mensagem);

        List<EmailMensagemModel> ReceberEmail(int maximo = 10);
    }
}
